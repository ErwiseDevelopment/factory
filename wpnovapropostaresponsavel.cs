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
   public class wpnovapropostaresponsavel : GXWebComponent
   {
      public wpnovapropostaresponsavel( )
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

      public wpnovapropostaresponsavel( IGxContext context )
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
         cmbavResponsavelclienteestadocivil = new GXCombobox();
         cmbavResponsavelclientetipopessoa = new GXCombobox();
         cmbavResponsavelclientestatus = new GXCombobox();
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
            PA6P2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavResponsavelmunicipionome_Enabled = 0;
               AssignProp(sPrefix, false, edtavResponsavelmunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipionome_Enabled), 5, 0), true);
               edtavResponsavelmunicipiouf_Enabled = 0;
               AssignProp(sPrefix, false, edtavResponsavelmunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipiouf_Enabled), 5, 0), true);
               WS6P2( ) ;
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
            context.SendWebValue( "Wp Nova Proposta Responsavel") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GXEncryptionTmp = "wpnovapropostaresponsavel"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpnovapropostaresponsavel") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SECUSERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESPONSAVELCLIENTENACIONALIDADE_DATA", AV39ResponsavelClienteNacionalidade_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESPONSAVELCLIENTENACIONALIDADE_DATA", AV39ResponsavelClienteNacionalidade_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESPONSAVELCLIENTEPROFISSAO_DATA", AV42ResponsavelClienteProfissao_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESPONSAVELCLIENTEPROFISSAO_DATA", AV42ResponsavelClienteProfissao_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESPONSAVELCLIENTENOMEFANTASIA", AV47ResponsavelClienteNomeFantasia);
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESPONSAVELSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48ResponsavelSecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESPONSAVELENDERECOTIPO", AV49ResponsavelEnderecoTipo);
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESPONSAVELCONTATODDI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50ResponsavelContatoDDI), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESPONSAVELCONTATOTELEFONEDDI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51ResponsavelContatoTelefoneDDI), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV38CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFISSAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A440ProfissaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFISSAONOME", A441ProfissaoNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTEDOCUMENTO", A169ClienteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTERAZAOSOCIAL", A170ClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTENOMEFANTASIA", A171ClienteNomeFantasia);
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTETIPOPESSOA", A172ClienteTipoPessoa);
         GxWebStd.gx_hidden_field( context, sPrefix+"TIPOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TIPOCLIENTEDESCRICAO", A193TipoClienteDescricao);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"CLIENTESTATUS", A174ClienteStatus);
         GxWebStd.gx_hidden_field( context, sPrefix+"SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SECUSERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"SECUSERNAME", A141SecUserName);
         GxWebStd.gx_hidden_field( context, sPrefix+"ENDERECOTIPO", A181EnderecoTipo);
         GxWebStd.gx_hidden_field( context, sPrefix+"ENDERECOCEP", A182EnderecoCEP);
         GxWebStd.gx_hidden_field( context, sPrefix+"ENDERECOLOGRADOURO", A183EnderecoLogradouro);
         GxWebStd.gx_hidden_field( context, sPrefix+"ENDERECOBAIRRO", A184EnderecoBairro);
         GxWebStd.gx_hidden_field( context, sPrefix+"ENDERECOCIDADE", A185EnderecoCidade);
         GxWebStd.gx_hidden_field( context, sPrefix+"MUNICIPIOCODIGO", A186MunicipioCodigo);
         GxWebStd.gx_hidden_field( context, sPrefix+"MUNICIPIONOME", A187MunicipioNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"MUNICIPIOUF", A189MunicipioUF);
         GxWebStd.gx_hidden_field( context, sPrefix+"ENDERECONUMERO", A190EnderecoNumero);
         GxWebStd.gx_hidden_field( context, sPrefix+"ENDERECOCOMPLEMENTO", A191EnderecoComplemento);
         GxWebStd.gx_hidden_field( context, sPrefix+"CONTATOEMAIL", A201ContatoEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"CONTATODDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A198ContatoDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CONTATODDI", StringUtil.LTrim( StringUtil.NToC( (decimal)(A199ContatoDDI), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CONTATONUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A200ContatoNumero), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CONTATOTELEFONENUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A202ContatoTelefoneNumero), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CONTATOTELEFONEDDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A203ContatoTelefoneDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CONTATOTELEFONEDDI", StringUtil.LTrim( StringUtil.NToC( (decimal)(A204ContatoTelefoneDDI), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTEDATANASCIMENTO", context.localUtil.DToC( A459ClienteDataNascimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTERG", StringUtil.LTrim( StringUtil.NToC( (decimal)(A421ClienteRG), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTENACIONALIDADE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A484ClienteNacionalidade), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTEESTADOCIVIL", A486ClienteEstadoCivil);
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTEPROFISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A487ClienteProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vENDERECOCOMPLETO", AV59EnderecoCompleto);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vENDERECOCOMPLETO", AV59EnderecoCompleto);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESPONSAVELENDERECOCOMPLETO", AV56ResponsavelEnderecoCompleto);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESPONSAVELENDERECOCOMPLETO", AV56ResponsavelEnderecoCompleto);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESPONSAVELCLIENTENACIONALIDADE_Ddointernalname", StringUtil.RTrim( Combo_responsavelclientenacionalidade_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESPONSAVELCLIENTEPROFISSAO_Ddointernalname", StringUtil.RTrim( Combo_responsavelclienteprofissao_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESPONSAVELCLIENTEPROFISSAO_Selectedvalue_get", StringUtil.RTrim( Combo_responsavelclienteprofissao_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESPONSAVELCLIENTENACIONALIDADE_Selectedvalue_get", StringUtil.RTrim( Combo_responsavelclientenacionalidade_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESPONSAVELCLIENTENACIONALIDADE_Ddointernalname", StringUtil.RTrim( Combo_responsavelclientenacionalidade_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESPONSAVELCLIENTEPROFISSAO_Ddointernalname", StringUtil.RTrim( Combo_responsavelclienteprofissao_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESPONSAVELCLIENTEPROFISSAO_Selectedvalue_get", StringUtil.RTrim( Combo_responsavelclienteprofissao_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm6P2( )
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
         return "WpNovaPropostaResponsavel" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wp Nova Proposta Responsavel" ;
      }

      protected void WB6P0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpnovapropostaresponsavel");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
            ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
            ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
            ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
            ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
            ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
            ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
            ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
            ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
            ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
            ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, sPrefix+"DVPANEL_TABLEATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelclientedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelclientedocumento_Internalname, "Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelclientedocumento_Internalname, AV12ResponsavelClienteDocumento, StringUtil.RTrim( context.localUtil.Format( AV12ResponsavelClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "CPF", edtavResponsavelclientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelclientedocumento_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelclientedatanascimento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelclientedatanascimento_Internalname, "Data Nascimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavResponsavelclientedatanascimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavResponsavelclientedatanascimento_Internalname, context.localUtil.Format(AV16ResponsavelClienteDataNascimento, "99/99/9999"), context.localUtil.Format( AV16ResponsavelClienteDataNascimento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelclientedatanascimento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelclientedatanascimento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_bitmap( context, edtavResponsavelclientedatanascimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavResponsavelclientedatanascimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpNovaPropostaResponsavel.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelclienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelclienterazaosocial_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelclienterazaosocial_Internalname, AV17ResponsavelClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV17ResponsavelClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelclienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelclienterazaosocial_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelclienterg_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelclienterg_Internalname, "RG", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelclienterg_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ResponsavelClienteRG), 12, 0, ",", "")), StringUtil.LTrim( ((edtavResponsavelclienterg_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ResponsavelClienteRG), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV18ResponsavelClienteRG), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelclienterg_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelclienterg_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresponsavelclientenacionalidade_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_responsavelclientenacionalidade_Internalname, "Nacionalidade", "", "", lblTextblockcombo_responsavelclientenacionalidade_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_responsavelclientenacionalidade.SetProperty("Caption", Combo_responsavelclientenacionalidade_Caption);
            ucCombo_responsavelclientenacionalidade.SetProperty("Cls", Combo_responsavelclientenacionalidade_Cls);
            ucCombo_responsavelclientenacionalidade.SetProperty("EmptyItem", Combo_responsavelclientenacionalidade_Emptyitem);
            ucCombo_responsavelclientenacionalidade.SetProperty("DropDownOptionsData", AV39ResponsavelClienteNacionalidade_Data);
            ucCombo_responsavelclientenacionalidade.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_responsavelclientenacionalidade_Internalname, sPrefix+"COMBO_RESPONSAVELCLIENTENACIONALIDADEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavResponsavelclienteestadocivil_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResponsavelclienteestadocivil_Internalname, "Estado civil", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResponsavelclienteestadocivil, cmbavResponsavelclienteestadocivil_Internalname, StringUtil.RTrim( AV20ResponsavelClienteEstadoCivil), 1, cmbavResponsavelclienteestadocivil_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavResponsavelclienteestadocivil.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_WpNovaPropostaResponsavel.htm");
            cmbavResponsavelclienteestadocivil.CurrentValue = StringUtil.RTrim( AV20ResponsavelClienteEstadoCivil);
            AssignProp(sPrefix, false, cmbavResponsavelclienteestadocivil_Internalname, "Values", (string)(cmbavResponsavelclienteestadocivil.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresponsavelclienteprofissao_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_responsavelclienteprofissao_Internalname, "Profissão", "", "", lblTextblockcombo_responsavelclienteprofissao_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_responsavelclienteprofissao.SetProperty("Caption", Combo_responsavelclienteprofissao_Caption);
            ucCombo_responsavelclienteprofissao.SetProperty("Cls", Combo_responsavelclienteprofissao_Cls);
            ucCombo_responsavelclienteprofissao.SetProperty("EmptyItem", Combo_responsavelclienteprofissao_Emptyitem);
            ucCombo_responsavelclienteprofissao.SetProperty("IncludeAddNewOption", Combo_responsavelclienteprofissao_Includeaddnewoption);
            ucCombo_responsavelclienteprofissao.SetProperty("DropDownOptionsData", AV42ResponsavelClienteProfissao_Data);
            ucCombo_responsavelclienteprofissao.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_responsavelclienteprofissao_Internalname, sPrefix+"COMBO_RESPONSAVELCLIENTEPROFISSAOContainer");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Endereço", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovaPropostaResponsavel.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableendereco_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelcep_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelcep_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelcep_Internalname, AV28ResponsavelCEP, StringUtil.RTrim( context.localUtil.Format( AV28ResponsavelCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelcep_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelcep_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelenderecologradouro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelenderecologradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelenderecologradouro_Internalname, AV30ResponsavelEnderecoLogradouro, StringUtil.RTrim( context.localUtil.Format( AV30ResponsavelEnderecoLogradouro, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,67);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelenderecologradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelenderecologradouro_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelendereconumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelendereconumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelendereconumero_Internalname, AV31ResponsavelEnderecoNumero, StringUtil.RTrim( context.localUtil.Format( AV31ResponsavelEnderecoNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelendereconumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelendereconumero_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelenderecocomplemento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelenderecocomplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelenderecocomplemento_Internalname, AV32ResponsavelEnderecoComplemento, StringUtil.RTrim( context.localUtil.Format( AV32ResponsavelEnderecoComplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelenderecocomplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelenderecocomplemento_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelenderecobairro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelenderecobairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelenderecobairro_Internalname, AV33ResponsavelEnderecoBairro, StringUtil.RTrim( context.localUtil.Format( AV33ResponsavelEnderecoBairro, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,80);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelenderecobairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelenderecobairro_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelenderecocidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelenderecocidade_Internalname, "Cidade", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelenderecocidade_Internalname, AV34ResponsavelEnderecoCidade, StringUtil.RTrim( context.localUtil.Format( AV34ResponsavelEnderecoCidade, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelenderecocidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelenderecocidade_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelmunicipionome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipionome_Internalname, "Município", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipionome_Internalname, AV36ResponsavelMunicipioNome, StringUtil.RTrim( context.localUtil.Format( AV36ResponsavelMunicipioNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,89);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipionome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelmunicipionome_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelmunicipiouf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelmunicipiouf_Internalname, "UF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipiouf_Internalname, AV37ResponsavelMunicipioUF, StringUtil.RTrim( context.localUtil.Format( AV37ResponsavelMunicipioUF, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,93);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipiouf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelmunicipiouf_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Contato", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovaPropostaResponsavel.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontato_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelcontatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelcontatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelcontatoemail_Internalname, AV23ResponsavelContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV23ResponsavelContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelcontatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelcontatoemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresponsavelcontatoddd_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockresponsavelcontatoddd_Internalname, "Celular", "", "", lblTextblockresponsavelcontatoddd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_110_6P2( true) ;
         }
         else
         {
            wb_table1_110_6P2( false) ;
         }
         return  ;
      }

      protected void wb_table1_110_6P2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresponsavelcontatotelefoneddd_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockresponsavelcontatotelefoneddd_Internalname, "Telefone", "", "", lblTextblockresponsavelcontatotelefoneddd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table2_124_6P2( true) ;
         }
         else
         {
            wb_table2_124_6P2( false) ;
         }
         return  ;
      }

      protected void wb_table2_124_6P2e( bool wbgen )
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
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "Center", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelclientenacionalidade_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ResponsavelClienteNacionalidade), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19ResponsavelClienteNacionalidade), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,142);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelclientenacionalidade_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelclientenacionalidade_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResponsavel.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelclienteprofissao_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ResponsavelClienteProfissao), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV21ResponsavelClienteProfissao), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,143);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelclienteprofissao_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelclienteprofissao_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResponsavel.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResponsavelclientetipopessoa, cmbavResponsavelclientetipopessoa_Internalname, StringUtil.RTrim( AV13ResponsavelClienteTipoPessoa), 1, cmbavResponsavelclientetipopessoa_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavResponsavelclientetipopessoa.Visible, cmbavResponsavelclientetipopessoa.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "", true, 0, "HLP_WpNovaPropostaResponsavel.htm");
            cmbavResponsavelclientetipopessoa.CurrentValue = StringUtil.RTrim( AV13ResponsavelClienteTipoPessoa);
            AssignProp(sPrefix, false, cmbavResponsavelclientetipopessoa_Internalname, "Values", (string)(cmbavResponsavelclientetipopessoa.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsaveltipoclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14ResponsavelTipoClienteId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV14ResponsavelTipoClienteId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,145);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsaveltipoclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsaveltipoclienteid_Visible, edtavResponsaveltipoclienteid_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResponsavel.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15ResponsavelClienteId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15ResponsavelClienteId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,146);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelclienteid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResponsavel.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResponsavelclientestatus, cmbavResponsavelclientestatus_Internalname, StringUtil.BoolToStr( AV22ResponsavelClienteStatus), 1, cmbavResponsavelclientestatus_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavResponsavelclientestatus.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", "", true, 0, "HLP_WpNovaPropostaResponsavel.htm");
            cmbavResponsavelclientestatus.CurrentValue = StringUtil.BoolToStr( AV22ResponsavelClienteStatus);
            AssignProp(sPrefix, false, cmbavResponsavelclientestatus_Internalname, "Values", (string)(cmbavResponsavelclientestatus.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelenderecocep_Internalname, AV29ResponsavelEnderecoCEP, StringUtil.RTrim( context.localUtil.Format( AV29ResponsavelEnderecoCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelenderecocep_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelenderecocep_Visible, edtavResponsavelenderecocep_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelmunicipiocodigo_Internalname, AV35ResponsavelMunicipioCodigo, StringUtil.RTrim( context.localUtil.Format( AV35ResponsavelMunicipioCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelmunicipiocodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavResponsavelmunicipiocodigo_Visible, edtavResponsavelmunicipiocodigo_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6P2( )
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
            Form.Meta.addItem("description", "Wp Nova Proposta Responsavel", 0) ;
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
               STRUP6P0( ) ;
            }
         }
      }

      protected void WS6P2( )
      {
         START6P2( ) ;
         EVT6P2( ) ;
      }

      protected void EVT6P2( )
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
                                 STRUP6P0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_RESPONSAVELCLIENTEPROFISSAO.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_responsavelclienteprofissao.Onoptionclicked */
                                    E116P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E126P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6P0( ) ;
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
                                          E136P2 ();
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
                                 STRUP6P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E146P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESPONSAVELCLIENTEDATANASCIMENTO.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E156P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESPONSAVELCLIENTEDOCUMENTO.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E166P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESPONSAVELCEP.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E176P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E186P2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavResponsavelclientedocumento_Internalname;
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

      protected void WE6P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6P2( ) ;
            }
         }
      }

      protected void PA6P2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpnovapropostaresponsavel")), "wpnovapropostaresponsavel") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpnovapropostaresponsavel")))) ;
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
               GX_FocusControl = edtavResponsavelclientedocumento_Internalname;
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
         if ( cmbavResponsavelclienteestadocivil.ItemCount > 0 )
         {
            AV20ResponsavelClienteEstadoCivil = cmbavResponsavelclienteestadocivil.getValidValue(AV20ResponsavelClienteEstadoCivil);
            AssignAttri(sPrefix, false, "AV20ResponsavelClienteEstadoCivil", AV20ResponsavelClienteEstadoCivil);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResponsavelclienteestadocivil.CurrentValue = StringUtil.RTrim( AV20ResponsavelClienteEstadoCivil);
            AssignProp(sPrefix, false, cmbavResponsavelclienteestadocivil_Internalname, "Values", cmbavResponsavelclienteestadocivil.ToJavascriptSource(), true);
         }
         if ( cmbavResponsavelclientetipopessoa.ItemCount > 0 )
         {
            AV13ResponsavelClienteTipoPessoa = cmbavResponsavelclientetipopessoa.getValidValue(AV13ResponsavelClienteTipoPessoa);
            AssignAttri(sPrefix, false, "AV13ResponsavelClienteTipoPessoa", AV13ResponsavelClienteTipoPessoa);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResponsavelclientetipopessoa.CurrentValue = StringUtil.RTrim( AV13ResponsavelClienteTipoPessoa);
            AssignProp(sPrefix, false, cmbavResponsavelclientetipopessoa_Internalname, "Values", cmbavResponsavelclientetipopessoa.ToJavascriptSource(), true);
         }
         if ( cmbavResponsavelclientestatus.ItemCount > 0 )
         {
            AV22ResponsavelClienteStatus = StringUtil.StrToBool( cmbavResponsavelclientestatus.getValidValue(StringUtil.BoolToStr( AV22ResponsavelClienteStatus)));
            AssignAttri(sPrefix, false, "AV22ResponsavelClienteStatus", AV22ResponsavelClienteStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResponsavelclientestatus.CurrentValue = StringUtil.BoolToStr( AV22ResponsavelClienteStatus);
            AssignProp(sPrefix, false, cmbavResponsavelclientestatus_Internalname, "Values", cmbavResponsavelclientestatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavResponsavelmunicipionome_Enabled = 0;
         AssignProp(sPrefix, false, edtavResponsavelmunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipionome_Enabled), 5, 0), true);
         edtavResponsavelmunicipiouf_Enabled = 0;
         AssignProp(sPrefix, false, edtavResponsavelmunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipiouf_Enabled), 5, 0), true);
      }

      protected void RF6P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E186P2 ();
            WB6P0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6P2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SECUSERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         edtavResponsavelmunicipionome_Enabled = 0;
         AssignProp(sPrefix, false, edtavResponsavelmunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipionome_Enabled), 5, 0), true);
         edtavResponsavelmunicipiouf_Enabled = 0;
         AssignProp(sPrefix, false, edtavResponsavelmunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipiouf_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E126P2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRESPONSAVELCLIENTENACIONALIDADE_DATA"), AV39ResponsavelClienteNacionalidade_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRESPONSAVELCLIENTEPROFISSAO_DATA"), AV42ResponsavelClienteProfissao_Data);
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            Combo_responsavelclientenacionalidade_Ddointernalname = cgiGet( sPrefix+"COMBO_RESPONSAVELCLIENTENACIONALIDADE_Ddointernalname");
            Combo_responsavelclienteprofissao_Ddointernalname = cgiGet( sPrefix+"COMBO_RESPONSAVELCLIENTEPROFISSAO_Ddointernalname");
            Combo_responsavelclienteprofissao_Selectedvalue_get = cgiGet( sPrefix+"COMBO_RESPONSAVELCLIENTEPROFISSAO_Selectedvalue_get");
            /* Read variables values. */
            AV12ResponsavelClienteDocumento = cgiGet( edtavResponsavelclientedocumento_Internalname);
            AssignAttri(sPrefix, false, "AV12ResponsavelClienteDocumento", AV12ResponsavelClienteDocumento);
            if ( context.localUtil.VCDate( cgiGet( edtavResponsavelclientedatanascimento_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Responsavel Cliente Data Nascimento"}), 1, "vRESPONSAVELCLIENTEDATANASCIMENTO");
               GX_FocusControl = edtavResponsavelclientedatanascimento_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16ResponsavelClienteDataNascimento = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV16ResponsavelClienteDataNascimento", context.localUtil.Format(AV16ResponsavelClienteDataNascimento, "99/99/9999"));
            }
            else
            {
               AV16ResponsavelClienteDataNascimento = context.localUtil.CToD( cgiGet( edtavResponsavelclientedatanascimento_Internalname), 2);
               AssignAttri(sPrefix, false, "AV16ResponsavelClienteDataNascimento", context.localUtil.Format(AV16ResponsavelClienteDataNascimento, "99/99/9999"));
            }
            AV17ResponsavelClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavResponsavelclienterazaosocial_Internalname));
            AssignAttri(sPrefix, false, "AV17ResponsavelClienteRazaoSocial", AV17ResponsavelClienteRazaoSocial);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavelclienterg_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavelclienterg_Internalname), ",", ".") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELCLIENTERG");
               GX_FocusControl = edtavResponsavelclienterg_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18ResponsavelClienteRG = 0;
               AssignAttri(sPrefix, false, "AV18ResponsavelClienteRG", StringUtil.LTrimStr( (decimal)(AV18ResponsavelClienteRG), 12, 0));
            }
            else
            {
               AV18ResponsavelClienteRG = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavelclienterg_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV18ResponsavelClienteRG", StringUtil.LTrimStr( (decimal)(AV18ResponsavelClienteRG), 12, 0));
            }
            cmbavResponsavelclienteestadocivil.CurrentValue = cgiGet( cmbavResponsavelclienteestadocivil_Internalname);
            AV20ResponsavelClienteEstadoCivil = cgiGet( cmbavResponsavelclienteestadocivil_Internalname);
            AssignAttri(sPrefix, false, "AV20ResponsavelClienteEstadoCivil", AV20ResponsavelClienteEstadoCivil);
            AV28ResponsavelCEP = cgiGet( edtavResponsavelcep_Internalname);
            AssignAttri(sPrefix, false, "AV28ResponsavelCEP", AV28ResponsavelCEP);
            AV30ResponsavelEnderecoLogradouro = StringUtil.Upper( cgiGet( edtavResponsavelenderecologradouro_Internalname));
            AssignAttri(sPrefix, false, "AV30ResponsavelEnderecoLogradouro", AV30ResponsavelEnderecoLogradouro);
            AV31ResponsavelEnderecoNumero = cgiGet( edtavResponsavelendereconumero_Internalname);
            AssignAttri(sPrefix, false, "AV31ResponsavelEnderecoNumero", AV31ResponsavelEnderecoNumero);
            AV32ResponsavelEnderecoComplemento = cgiGet( edtavResponsavelenderecocomplemento_Internalname);
            AssignAttri(sPrefix, false, "AV32ResponsavelEnderecoComplemento", AV32ResponsavelEnderecoComplemento);
            AV33ResponsavelEnderecoBairro = StringUtil.Upper( cgiGet( edtavResponsavelenderecobairro_Internalname));
            AssignAttri(sPrefix, false, "AV33ResponsavelEnderecoBairro", AV33ResponsavelEnderecoBairro);
            AV34ResponsavelEnderecoCidade = StringUtil.Upper( cgiGet( edtavResponsavelenderecocidade_Internalname));
            AssignAttri(sPrefix, false, "AV34ResponsavelEnderecoCidade", AV34ResponsavelEnderecoCidade);
            AV36ResponsavelMunicipioNome = StringUtil.Upper( cgiGet( edtavResponsavelmunicipionome_Internalname));
            AssignAttri(sPrefix, false, "AV36ResponsavelMunicipioNome", AV36ResponsavelMunicipioNome);
            AV37ResponsavelMunicipioUF = StringUtil.Upper( cgiGet( edtavResponsavelmunicipiouf_Internalname));
            AssignAttri(sPrefix, false, "AV37ResponsavelMunicipioUF", AV37ResponsavelMunicipioUF);
            AV23ResponsavelContatoEmail = cgiGet( edtavResponsavelcontatoemail_Internalname);
            AssignAttri(sPrefix, false, "AV23ResponsavelContatoEmail", AV23ResponsavelContatoEmail);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavelcontatoddd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavelcontatoddd_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELCONTATODDD");
               GX_FocusControl = edtavResponsavelcontatoddd_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV24ResponsavelContatoDDD = 0;
               AssignAttri(sPrefix, false, "AV24ResponsavelContatoDDD", StringUtil.LTrimStr( (decimal)(AV24ResponsavelContatoDDD), 4, 0));
            }
            else
            {
               AV24ResponsavelContatoDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavelcontatoddd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV24ResponsavelContatoDDD", StringUtil.LTrimStr( (decimal)(AV24ResponsavelContatoDDD), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavelcontatonumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavelcontatonumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELCONTATONUMERO");
               GX_FocusControl = edtavResponsavelcontatonumero_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25ResponsavelContatoNumero = 0;
               AssignAttri(sPrefix, false, "AV25ResponsavelContatoNumero", StringUtil.LTrimStr( (decimal)(AV25ResponsavelContatoNumero), 18, 0));
            }
            else
            {
               AV25ResponsavelContatoNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavelcontatonumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV25ResponsavelContatoNumero", StringUtil.LTrimStr( (decimal)(AV25ResponsavelContatoNumero), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavelcontatotelefoneddd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavelcontatotelefoneddd_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELCONTATOTELEFONEDDD");
               GX_FocusControl = edtavResponsavelcontatotelefoneddd_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26ResponsavelContatoTelefoneDDD = 0;
               AssignAttri(sPrefix, false, "AV26ResponsavelContatoTelefoneDDD", StringUtil.LTrimStr( (decimal)(AV26ResponsavelContatoTelefoneDDD), 4, 0));
            }
            else
            {
               AV26ResponsavelContatoTelefoneDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavelcontatotelefoneddd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV26ResponsavelContatoTelefoneDDD", StringUtil.LTrimStr( (decimal)(AV26ResponsavelContatoTelefoneDDD), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavelcontatotelefonenumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavelcontatotelefonenumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELCONTATOTELEFONENUMERO");
               GX_FocusControl = edtavResponsavelcontatotelefonenumero_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27ResponsavelContatoTelefoneNumero = 0;
               AssignAttri(sPrefix, false, "AV27ResponsavelContatoTelefoneNumero", StringUtil.LTrimStr( (decimal)(AV27ResponsavelContatoTelefoneNumero), 18, 0));
            }
            else
            {
               AV27ResponsavelContatoTelefoneNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavelcontatotelefonenumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV27ResponsavelContatoTelefoneNumero", StringUtil.LTrimStr( (decimal)(AV27ResponsavelContatoTelefoneNumero), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavelclientenacionalidade_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavelclientenacionalidade_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELCLIENTENACIONALIDADE");
               GX_FocusControl = edtavResponsavelclientenacionalidade_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19ResponsavelClienteNacionalidade = 0;
               AssignAttri(sPrefix, false, "AV19ResponsavelClienteNacionalidade", StringUtil.LTrimStr( (decimal)(AV19ResponsavelClienteNacionalidade), 9, 0));
            }
            else
            {
               AV19ResponsavelClienteNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavelclientenacionalidade_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV19ResponsavelClienteNacionalidade", StringUtil.LTrimStr( (decimal)(AV19ResponsavelClienteNacionalidade), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavelclienteprofissao_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavelclienteprofissao_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELCLIENTEPROFISSAO");
               GX_FocusControl = edtavResponsavelclienteprofissao_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV21ResponsavelClienteProfissao = 0;
               AssignAttri(sPrefix, false, "AV21ResponsavelClienteProfissao", StringUtil.LTrimStr( (decimal)(AV21ResponsavelClienteProfissao), 9, 0));
            }
            else
            {
               AV21ResponsavelClienteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavelclienteprofissao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21ResponsavelClienteProfissao", StringUtil.LTrimStr( (decimal)(AV21ResponsavelClienteProfissao), 9, 0));
            }
            cmbavResponsavelclientetipopessoa.CurrentValue = cgiGet( cmbavResponsavelclientetipopessoa_Internalname);
            AV13ResponsavelClienteTipoPessoa = cgiGet( cmbavResponsavelclientetipopessoa_Internalname);
            AssignAttri(sPrefix, false, "AV13ResponsavelClienteTipoPessoa", AV13ResponsavelClienteTipoPessoa);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsaveltipoclienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsaveltipoclienteid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELTIPOCLIENTEID");
               GX_FocusControl = edtavResponsaveltipoclienteid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14ResponsavelTipoClienteId = 0;
               AssignAttri(sPrefix, false, "AV14ResponsavelTipoClienteId", StringUtil.LTrimStr( (decimal)(AV14ResponsavelTipoClienteId), 4, 0));
            }
            else
            {
               AV14ResponsavelTipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsaveltipoclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV14ResponsavelTipoClienteId", StringUtil.LTrimStr( (decimal)(AV14ResponsavelTipoClienteId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResponsavelclienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResponsavelclienteid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESPONSAVELCLIENTEID");
               GX_FocusControl = edtavResponsavelclienteid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15ResponsavelClienteId = 0;
               AssignAttri(sPrefix, false, "AV15ResponsavelClienteId", StringUtil.LTrimStr( (decimal)(AV15ResponsavelClienteId), 9, 0));
            }
            else
            {
               AV15ResponsavelClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavResponsavelclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV15ResponsavelClienteId", StringUtil.LTrimStr( (decimal)(AV15ResponsavelClienteId), 9, 0));
            }
            cmbavResponsavelclientestatus.CurrentValue = cgiGet( cmbavResponsavelclientestatus_Internalname);
            AV22ResponsavelClienteStatus = StringUtil.StrToBool( cgiGet( cmbavResponsavelclientestatus_Internalname));
            AssignAttri(sPrefix, false, "AV22ResponsavelClienteStatus", AV22ResponsavelClienteStatus);
            AV29ResponsavelEnderecoCEP = cgiGet( edtavResponsavelenderecocep_Internalname);
            AssignAttri(sPrefix, false, "AV29ResponsavelEnderecoCEP", AV29ResponsavelEnderecoCEP);
            AV35ResponsavelMunicipioCodigo = cgiGet( edtavResponsavelmunicipiocodigo_Internalname);
            AssignAttri(sPrefix, false, "AV35ResponsavelMunicipioCodigo", AV35ResponsavelMunicipioCodigo);
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
         E126P2 ();
         if (returnInSub) return;
      }

      protected void E126P2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavResponsavelclienteprofissao_Visible = 0;
         AssignProp(sPrefix, false, edtavResponsavelclienteprofissao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelclienteprofissao_Visible), 5, 0), true);
         edtavResponsavelclientenacionalidade_Visible = 0;
         AssignProp(sPrefix, false, edtavResponsavelclientenacionalidade_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelclientenacionalidade_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBORESPONSAVELCLIENTENACIONALIDADE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBORESPONSAVELCLIENTEPROFISSAO' */
         S132 ();
         if (returnInSub) return;
         cmbavResponsavelclientetipopessoa.Visible = 0;
         AssignProp(sPrefix, false, cmbavResponsavelclientetipopessoa_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavResponsavelclientetipopessoa.Visible), 5, 0), true);
         edtavResponsaveltipoclienteid_Visible = 0;
         AssignProp(sPrefix, false, edtavResponsaveltipoclienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsaveltipoclienteid_Visible), 5, 0), true);
         edtavResponsavelclienteid_Visible = 0;
         AssignProp(sPrefix, false, edtavResponsavelclienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelclienteid_Visible), 5, 0), true);
         cmbavResponsavelclientestatus.Visible = 0;
         AssignProp(sPrefix, false, cmbavResponsavelclientestatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavResponsavelclientestatus.Visible), 5, 0), true);
         edtavResponsavelenderecocep_Visible = 0;
         AssignProp(sPrefix, false, edtavResponsavelenderecocep_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecocep_Visible), 5, 0), true);
         edtavResponsavelmunicipiocodigo_Visible = 0;
         AssignProp(sPrefix, false, edtavResponsavelmunicipiocodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipiocodigo_Visible), 5, 0), true);
         AV45ClienteTipoPessoa = "FISICA";
         /* Using cursor H006P2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A219TipoClienteFinancia = H006P2_A219TipoClienteFinancia[0];
            n219TipoClienteFinancia = H006P2_n219TipoClienteFinancia[0];
            A192TipoClienteId = H006P2_A192TipoClienteId[0];
            n192TipoClienteId = H006P2_n192TipoClienteId[0];
            AV44TipoClienteId = A192TipoClienteId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E136P2 ();
         if (returnInSub) return;
      }

      protected void E136P2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( (0==AV15ResponsavelClienteId) )
         {
            AV46ClienteBC = new SdtCliente(context);
         }
         else
         {
            AV46ClienteBC.Load(AV15ResponsavelClienteId);
         }
         AV46ClienteBC.gxTpr_Clientedocumento = AV12ResponsavelClienteDocumento;
         AV46ClienteBC.gxTpr_Clienterazaosocial = AV17ResponsavelClienteRazaoSocial;
         AV46ClienteBC.gxTpr_Clientenomefantasia = AV47ResponsavelClienteNomeFantasia;
         AV46ClienteBC.gxTpr_Clientetipopessoa = AV13ResponsavelClienteTipoPessoa;
         AV46ClienteBC.gxTpr_Tipoclienteid = AV14ResponsavelTipoClienteId;
         AV46ClienteBC.gxTpr_Clientestatus = AV22ResponsavelClienteStatus;
         AV46ClienteBC.gxTpr_Clienteupdatedat = DateTimeUtil.Now( context);
         AV46ClienteBC.gxTpr_Clienteloguser = AV48ResponsavelSecUserId;
         AV46ClienteBC.gxTpr_Clienteprofissao = AV21ResponsavelClienteProfissao;
         AV46ClienteBC.gxTpr_Clientenacionalidade = AV19ResponsavelClienteNacionalidade;
         AV46ClienteBC.gxTpr_Clienteestadocivil = AV20ResponsavelClienteEstadoCivil;
         AV46ClienteBC.gxTpr_Clienterg = AV18ResponsavelClienteRG;
         AV46ClienteBC.gxTpr_Enderecotipo = AV49ResponsavelEnderecoTipo;
         AV46ClienteBC.gxTpr_Enderecocep = AV28ResponsavelCEP;
         AV46ClienteBC.gxTpr_Enderecologradouro = AV30ResponsavelEnderecoLogradouro;
         AV46ClienteBC.gxTpr_Enderecobairro = AV33ResponsavelEnderecoBairro;
         AV46ClienteBC.gxTpr_Enderecocidade = AV34ResponsavelEnderecoCidade;
         AV46ClienteBC.gxTpr_Municipiocodigo = AV35ResponsavelMunicipioCodigo;
         AV46ClienteBC.gxTpr_Endereconumero = AV31ResponsavelEnderecoNumero;
         AV46ClienteBC.gxTpr_Enderecocomplemento = AV32ResponsavelEnderecoComplemento;
         AV46ClienteBC.gxTpr_Clientedatanascimento = AV16ResponsavelClienteDataNascimento;
         AV46ClienteBC.gxTpr_Contatoemail = AV23ResponsavelContatoEmail;
         AV46ClienteBC.gxTpr_Contatoddd = AV24ResponsavelContatoDDD;
         AV46ClienteBC.gxTpr_Contatoddi = AV50ResponsavelContatoDDI;
         AV46ClienteBC.gxTpr_Contatonumero = AV25ResponsavelContatoNumero;
         AV46ClienteBC.gxTpr_Contatotelefonenumero = AV27ResponsavelContatoTelefoneNumero;
         AV46ClienteBC.gxTpr_Contatotelefoneddd = AV26ResponsavelContatoTelefoneDDD;
         AV46ClienteBC.gxTpr_Contatotelefoneddi = AV51ResponsavelContatoTelefoneDDI;
         AV46ClienteBC.Save();
         if ( AV46ClienteBC.Success() )
         {
            AV15ResponsavelClienteId = AV46ClienteBC.gxTpr_Clienteid;
            AssignAttri(sPrefix, false, "AV15ResponsavelClienteId", StringUtil.LTrimStr( (decimal)(AV15ResponsavelClienteId), 9, 0));
            new prverificaresponsavel(context ).execute(  AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteid,  AV15ResponsavelClienteId, out  AV53IsCadastrado) ;
            if ( ! AV53IsCadastrado )
            {
               AV52ClienteResponsavel = new SdtClienteReponsavel(context);
               AV52ClienteResponsavel.gxTpr_Reponsavelclienteid = AV15ResponsavelClienteId;
               AV52ClienteResponsavel.gxTpr_Clienteid = AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteid;
               AV52ClienteResponsavel.Save();
               if ( AV52ClienteResponsavel.Success() )
               {
                  AV53IsCadastrado = true;
               }
               else
               {
                  GXt_char1 = ((GeneXus.Utils.SdtMessages_Message)AV52ClienteResponsavel.GetMessages().Item(1)).gxTpr_Description;
                  new message(context ).gxep_erro( ref  GXt_char1) ;
                  ((GeneXus.Utils.SdtMessages_Message)AV52ClienteResponsavel.GetMessages().Item(1)).gxTpr_Description = GXt_char1;
               }
            }
            if ( AV53IsCadastrado )
            {
               context.CommitDataStores("wpnovapropostaresponsavel",pr_default);
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S142 ();
               if (returnInSub) return;
               if ( AV38CheckRequiredFieldsResult && ! AV10HasValidationErrors )
               {
                  /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
                  S152 ();
                  if (returnInSub) return;
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                     {
                        gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                     }
                  }
                  GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                  GXEncryptionTmp = "wpnovaproposta"+UrlEncode(StringUtil.RTrim("Responsavel")) + "," + UrlEncode(StringUtil.RTrim("Conta")) + "," + UrlEncode(StringUtil.BoolToStr(false));
                  CallWebObject(formatLink("wpnovaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                  context.wjLocDisableFrm = 1;
               }
            }
            else
            {
               context.RollbackDataStores("wpnovapropostaresponsavel",pr_default);
            }
         }
         else
         {
            GXt_char1 = ((GeneXus.Utils.SdtMessages_Message)AV46ClienteBC.GetMessages().Item(1)).gxTpr_Description;
            new message(context ).gxep_erro( ref  GXt_char1) ;
            ((GeneXus.Utils.SdtMessages_Message)AV46ClienteBC.GetMessages().Item(1)).gxTpr_Description = GXt_char1;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E146P2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S152 ();
         if (returnInSub) return;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpnovaproposta"+UrlEncode(StringUtil.RTrim("Responsavel")) + "," + UrlEncode(StringUtil.RTrim("NovoCliente")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wpnovaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E116P2( )
      {
         /* Combo_responsavelclienteprofissao_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_responsavelclienteprofissao_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "profissao"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            context.PopUp(formatLink("profissao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_responsavelclienteprofissao_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBORESPONSAVELCLIENTEPROFISSAO' */
            S132 ();
            if (returnInSub) return;
            AV40ComboSelectedValue = AV43Session.Get("PROFISSAOID");
            AV43Session.Remove("PROFISSAOID");
            Combo_responsavelclienteprofissao_Selectedvalue_set = AV40ComboSelectedValue;
            ucCombo_responsavelclienteprofissao.SendProperty(context, sPrefix, false, Combo_responsavelclienteprofissao_Internalname, "SelectedValue_set", Combo_responsavelclienteprofissao_Selectedvalue_set);
            AV21ResponsavelClienteProfissao = (int)(Math.Round(NumberUtil.Val( AV40ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21ResponsavelClienteProfissao", StringUtil.LTrimStr( (decimal)(AV21ResponsavelClienteProfissao), 9, 0));
         }
         else
         {
            AV21ResponsavelClienteProfissao = (int)(Math.Round(NumberUtil.Val( Combo_responsavelclienteprofissao_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21ResponsavelClienteProfissao", StringUtil.LTrimStr( (decimal)(AV21ResponsavelClienteProfissao), 9, 0));
            /* Execute user subroutine: 'LOADCOMBORESPONSAVELCLIENTEPROFISSAO' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV42ResponsavelClienteProfissao_Data", AV42ResponsavelClienteProfissao_Data);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV12ResponsavelClienteDocumento = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientedocumento;
         AssignAttri(sPrefix, false, "AV12ResponsavelClienteDocumento", AV12ResponsavelClienteDocumento);
         AV13ResponsavelClienteTipoPessoa = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientetipopessoa;
         AssignAttri(sPrefix, false, "AV13ResponsavelClienteTipoPessoa", AV13ResponsavelClienteTipoPessoa);
         AV14ResponsavelTipoClienteId = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsaveltipoclienteid;
         AssignAttri(sPrefix, false, "AV14ResponsavelTipoClienteId", StringUtil.LTrimStr( (decimal)(AV14ResponsavelTipoClienteId), 4, 0));
         AV15ResponsavelClienteId = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienteid;
         AssignAttri(sPrefix, false, "AV15ResponsavelClienteId", StringUtil.LTrimStr( (decimal)(AV15ResponsavelClienteId), 9, 0));
         AV16ResponsavelClienteDataNascimento = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientedatanascimento;
         AssignAttri(sPrefix, false, "AV16ResponsavelClienteDataNascimento", context.localUtil.Format(AV16ResponsavelClienteDataNascimento, "99/99/9999"));
         AV17ResponsavelClienteRazaoSocial = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienterazaosocial;
         AssignAttri(sPrefix, false, "AV17ResponsavelClienteRazaoSocial", AV17ResponsavelClienteRazaoSocial);
         AV18ResponsavelClienteRG = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienterg;
         AssignAttri(sPrefix, false, "AV18ResponsavelClienteRG", StringUtil.LTrimStr( (decimal)(AV18ResponsavelClienteRG), 12, 0));
         AV19ResponsavelClienteNacionalidade = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientenacionalidade;
         AssignAttri(sPrefix, false, "AV19ResponsavelClienteNacionalidade", StringUtil.LTrimStr( (decimal)(AV19ResponsavelClienteNacionalidade), 9, 0));
         AV20ResponsavelClienteEstadoCivil = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienteestadocivil;
         AssignAttri(sPrefix, false, "AV20ResponsavelClienteEstadoCivil", AV20ResponsavelClienteEstadoCivil);
         AV21ResponsavelClienteProfissao = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienteprofissao;
         AssignAttri(sPrefix, false, "AV21ResponsavelClienteProfissao", StringUtil.LTrimStr( (decimal)(AV21ResponsavelClienteProfissao), 9, 0));
         AV22ResponsavelClienteStatus = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientestatus;
         AssignAttri(sPrefix, false, "AV22ResponsavelClienteStatus", AV22ResponsavelClienteStatus);
         AV23ResponsavelContatoEmail = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatoemail;
         AssignAttri(sPrefix, false, "AV23ResponsavelContatoEmail", AV23ResponsavelContatoEmail);
         AV24ResponsavelContatoDDD = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatoddd;
         AssignAttri(sPrefix, false, "AV24ResponsavelContatoDDD", StringUtil.LTrimStr( (decimal)(AV24ResponsavelContatoDDD), 4, 0));
         AV25ResponsavelContatoNumero = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatonumero;
         AssignAttri(sPrefix, false, "AV25ResponsavelContatoNumero", StringUtil.LTrimStr( (decimal)(AV25ResponsavelContatoNumero), 18, 0));
         AV26ResponsavelContatoTelefoneDDD = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatotelefoneddd;
         AssignAttri(sPrefix, false, "AV26ResponsavelContatoTelefoneDDD", StringUtil.LTrimStr( (decimal)(AV26ResponsavelContatoTelefoneDDD), 4, 0));
         AV27ResponsavelContatoTelefoneNumero = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatotelefonenumero;
         AssignAttri(sPrefix, false, "AV27ResponsavelContatoTelefoneNumero", StringUtil.LTrimStr( (decimal)(AV27ResponsavelContatoTelefoneNumero), 18, 0));
         AV28ResponsavelCEP = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcep;
         AssignAttri(sPrefix, false, "AV28ResponsavelCEP", AV28ResponsavelCEP);
         AV29ResponsavelEnderecoCEP = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelenderecocep;
         AssignAttri(sPrefix, false, "AV29ResponsavelEnderecoCEP", AV29ResponsavelEnderecoCEP);
         AV30ResponsavelEnderecoLogradouro = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelenderecologradouro;
         AssignAttri(sPrefix, false, "AV30ResponsavelEnderecoLogradouro", AV30ResponsavelEnderecoLogradouro);
         AV31ResponsavelEnderecoNumero = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelendereconumero;
         AssignAttri(sPrefix, false, "AV31ResponsavelEnderecoNumero", AV31ResponsavelEnderecoNumero);
         AV32ResponsavelEnderecoComplemento = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelenderecocomplemento;
         AssignAttri(sPrefix, false, "AV32ResponsavelEnderecoComplemento", AV32ResponsavelEnderecoComplemento);
         AV33ResponsavelEnderecoBairro = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelenderecobairro;
         AssignAttri(sPrefix, false, "AV33ResponsavelEnderecoBairro", AV33ResponsavelEnderecoBairro);
         AV34ResponsavelEnderecoCidade = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelenderecocidade;
         AssignAttri(sPrefix, false, "AV34ResponsavelEnderecoCidade", AV34ResponsavelEnderecoCidade);
         AV35ResponsavelMunicipioCodigo = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelmunicipiocodigo;
         AssignAttri(sPrefix, false, "AV35ResponsavelMunicipioCodigo", AV35ResponsavelMunicipioCodigo);
         AV36ResponsavelMunicipioNome = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelmunicipionome;
         AssignAttri(sPrefix, false, "AV36ResponsavelMunicipioNome", AV36ResponsavelMunicipioNome);
         AV37ResponsavelMunicipioUF = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelmunicipiouf;
         AssignAttri(sPrefix, false, "AV37ResponsavelMunicipioUF", AV37ResponsavelMunicipioUF);
      }

      protected void S152( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientedocumento = AV12ResponsavelClienteDocumento;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientetipopessoa = AV13ResponsavelClienteTipoPessoa;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsaveltipoclienteid = AV14ResponsavelTipoClienteId;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienteid = AV15ResponsavelClienteId;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientedatanascimento = AV16ResponsavelClienteDataNascimento;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienterazaosocial = AV17ResponsavelClienteRazaoSocial;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienterg = AV18ResponsavelClienteRG;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientenacionalidade = AV19ResponsavelClienteNacionalidade;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienteestadocivil = AV20ResponsavelClienteEstadoCivil;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienteprofissao = AV21ResponsavelClienteProfissao;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientestatus = AV22ResponsavelClienteStatus;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatoemail = AV23ResponsavelContatoEmail;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatoddd = AV24ResponsavelContatoDDD;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatonumero = AV25ResponsavelContatoNumero;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatotelefoneddd = AV26ResponsavelContatoTelefoneDDD;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatotelefonenumero = AV27ResponsavelContatoTelefoneNumero;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcep = AV28ResponsavelCEP;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelenderecocep = AV29ResponsavelEnderecoCEP;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelenderecologradouro = AV30ResponsavelEnderecoLogradouro;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelendereconumero = AV31ResponsavelEnderecoNumero;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelenderecocomplemento = AV32ResponsavelEnderecoComplemento;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelenderecobairro = AV33ResponsavelEnderecoBairro;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelenderecocidade = AV34ResponsavelEnderecoCidade;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelmunicipiocodigo = AV35ResponsavelMunicipioCodigo;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelmunicipionome = AV36ResponsavelMunicipioNome;
         AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelmunicipiouf = AV37ResponsavelMunicipioUF;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV38CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV38CheckRequiredFieldsResult", AV38CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12ResponsavelClienteDocumento)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Documento", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavelclientedocumento_Internalname,  "true",  ""));
            AV38CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV38CheckRequiredFieldsResult", AV38CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17ResponsavelClienteRazaoSocial)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavelclienterazaosocial_Internalname,  "true",  ""));
            AV38CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV38CheckRequiredFieldsResult", AV38CheckRequiredFieldsResult);
         }
         if ( (0==AV19ResponsavelClienteNacionalidade) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nacionalidade", "", "", "", "", "", "", "", ""),  "error",  Combo_responsavelclientenacionalidade_Ddointernalname,  "true",  ""));
            AV38CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV38CheckRequiredFieldsResult", AV38CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20ResponsavelClienteEstadoCivil)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Estado civil", "", "", "", "", "", "", "", ""),  "error",  cmbavResponsavelclienteestadocivil_Internalname,  "true",  ""));
            AV38CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV38CheckRequiredFieldsResult", AV38CheckRequiredFieldsResult);
         }
         if ( (0==AV21ResponsavelClienteProfissao) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Profissão", "", "", "", "", "", "", "", ""),  "error",  Combo_responsavelclienteprofissao_Ddointernalname,  "true",  ""));
            AV38CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV38CheckRequiredFieldsResult", AV38CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28ResponsavelCEP)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CEP", "", "", "", "", "", "", "", ""),  "error",  edtavResponsavelcep_Internalname,  "true",  ""));
            AV38CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV38CheckRequiredFieldsResult", AV38CheckRequiredFieldsResult);
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBORESPONSAVELCLIENTEPROFISSAO' Routine */
         returnInSub = false;
         AV42ResponsavelClienteProfissao_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H006P3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A440ProfissaoId = H006P3_A440ProfissaoId[0];
            A441ProfissaoNome = H006P3_A441ProfissaoNome[0];
            n441ProfissaoNome = H006P3_n441ProfissaoNome[0];
            AV41Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV41Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A440ProfissaoId), 9, 0));
            AV41Combo_DataItem.gxTpr_Title = A441ProfissaoNome;
            AV42ResponsavelClienteProfissao_Data.Add(AV41Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_responsavelclienteprofissao_Selectedvalue_set = ((0==AV21ResponsavelClienteProfissao) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV21ResponsavelClienteProfissao), 9, 0)));
         ucCombo_responsavelclienteprofissao.SendProperty(context, sPrefix, false, Combo_responsavelclienteprofissao_Internalname, "SelectedValue_set", Combo_responsavelclienteprofissao_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBORESPONSAVELCLIENTENACIONALIDADE' Routine */
         returnInSub = false;
         /* Using cursor H006P4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A434NacionalidadeId = H006P4_A434NacionalidadeId[0];
            A435NacionalidadeNome = H006P4_A435NacionalidadeNome[0];
            n435NacionalidadeNome = H006P4_n435NacionalidadeNome[0];
            AV41Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV41Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A434NacionalidadeId), 9, 0));
            AV41Combo_DataItem.gxTpr_Title = A435NacionalidadeNome;
            AV39ResponsavelClienteNacionalidade_Data.Add(AV41Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_responsavelclientenacionalidade_Selectedvalue_set = ((0==AV19ResponsavelClienteNacionalidade) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV19ResponsavelClienteNacionalidade), 9, 0)));
         ucCombo_responsavelclientenacionalidade.SendProperty(context, sPrefix, false, Combo_responsavelclientenacionalidade_Internalname, "SelectedValue_set", Combo_responsavelclientenacionalidade_Selectedvalue_set);
      }

      protected void E156P2( )
      {
         /* Responsavelclientedatanascimento_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_dtime2 = DateTimeUtil.ResetTime( AV16ResponsavelClienteDataNascimento ) ;
         AV60Idade = (short)(DateTimeUtil.Age( GXt_dtime2, DateTimeUtil.Now( context)));
         if ( AV60Idade < 18 )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Responsável deve ser maior.",  "error",  edtavResponsavelclientedatanascimento_Internalname,  "true",  ""));
         }
      }

      protected void E166P2( )
      {
         /* Responsavelclientedocumento_Controlvaluechanged Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV12ResponsavelClienteDocumento, AV11WizardData.gxTpr_Novocliente.gxTpr_Clientedocumento) == 0 )
         {
            GXt_char1 = "O responsável não pode ser o próprio paciente. Por favor, selecione outra pessoa como responsável.";
            new message(context ).gxep_regular( ref  GXt_char1) ;
         }
         else
         {
            AV64GXLvl319 = 0;
            /* Using cursor H006P5 */
            pr_default.execute(3, new Object[] {AV12ResponsavelClienteDocumento});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A457EspecialidadeId = H006P5_A457EspecialidadeId[0];
               n457EspecialidadeId = H006P5_n457EspecialidadeId[0];
               A597EspecialidadeCreatedBy = H006P5_A597EspecialidadeCreatedBy[0];
               n597EspecialidadeCreatedBy = H006P5_n597EspecialidadeCreatedBy[0];
               A169ClienteDocumento = H006P5_A169ClienteDocumento[0];
               n169ClienteDocumento = H006P5_n169ClienteDocumento[0];
               A170ClienteRazaoSocial = H006P5_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H006P5_n170ClienteRazaoSocial[0];
               A171ClienteNomeFantasia = H006P5_A171ClienteNomeFantasia[0];
               n171ClienteNomeFantasia = H006P5_n171ClienteNomeFantasia[0];
               A172ClienteTipoPessoa = H006P5_A172ClienteTipoPessoa[0];
               n172ClienteTipoPessoa = H006P5_n172ClienteTipoPessoa[0];
               A192TipoClienteId = H006P5_A192TipoClienteId[0];
               n192TipoClienteId = H006P5_n192TipoClienteId[0];
               A193TipoClienteDescricao = H006P5_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H006P5_n193TipoClienteDescricao[0];
               A174ClienteStatus = H006P5_A174ClienteStatus[0];
               n174ClienteStatus = H006P5_n174ClienteStatus[0];
               A141SecUserName = H006P5_A141SecUserName[0];
               n141SecUserName = H006P5_n141SecUserName[0];
               A181EnderecoTipo = H006P5_A181EnderecoTipo[0];
               n181EnderecoTipo = H006P5_n181EnderecoTipo[0];
               A182EnderecoCEP = H006P5_A182EnderecoCEP[0];
               n182EnderecoCEP = H006P5_n182EnderecoCEP[0];
               A183EnderecoLogradouro = H006P5_A183EnderecoLogradouro[0];
               n183EnderecoLogradouro = H006P5_n183EnderecoLogradouro[0];
               A184EnderecoBairro = H006P5_A184EnderecoBairro[0];
               n184EnderecoBairro = H006P5_n184EnderecoBairro[0];
               A185EnderecoCidade = H006P5_A185EnderecoCidade[0];
               n185EnderecoCidade = H006P5_n185EnderecoCidade[0];
               A186MunicipioCodigo = H006P5_A186MunicipioCodigo[0];
               n186MunicipioCodigo = H006P5_n186MunicipioCodigo[0];
               A187MunicipioNome = H006P5_A187MunicipioNome[0];
               n187MunicipioNome = H006P5_n187MunicipioNome[0];
               A189MunicipioUF = H006P5_A189MunicipioUF[0];
               n189MunicipioUF = H006P5_n189MunicipioUF[0];
               A190EnderecoNumero = H006P5_A190EnderecoNumero[0];
               n190EnderecoNumero = H006P5_n190EnderecoNumero[0];
               A191EnderecoComplemento = H006P5_A191EnderecoComplemento[0];
               n191EnderecoComplemento = H006P5_n191EnderecoComplemento[0];
               A201ContatoEmail = H006P5_A201ContatoEmail[0];
               n201ContatoEmail = H006P5_n201ContatoEmail[0];
               A198ContatoDDD = H006P5_A198ContatoDDD[0];
               n198ContatoDDD = H006P5_n198ContatoDDD[0];
               A199ContatoDDI = H006P5_A199ContatoDDI[0];
               n199ContatoDDI = H006P5_n199ContatoDDI[0];
               A200ContatoNumero = H006P5_A200ContatoNumero[0];
               n200ContatoNumero = H006P5_n200ContatoNumero[0];
               A202ContatoTelefoneNumero = H006P5_A202ContatoTelefoneNumero[0];
               n202ContatoTelefoneNumero = H006P5_n202ContatoTelefoneNumero[0];
               A203ContatoTelefoneDDD = H006P5_A203ContatoTelefoneDDD[0];
               n203ContatoTelefoneDDD = H006P5_n203ContatoTelefoneDDD[0];
               A204ContatoTelefoneDDI = H006P5_A204ContatoTelefoneDDI[0];
               n204ContatoTelefoneDDI = H006P5_n204ContatoTelefoneDDI[0];
               A459ClienteDataNascimento = H006P5_A459ClienteDataNascimento[0];
               n459ClienteDataNascimento = H006P5_n459ClienteDataNascimento[0];
               A421ClienteRG = H006P5_A421ClienteRG[0];
               n421ClienteRG = H006P5_n421ClienteRG[0];
               A484ClienteNacionalidade = H006P5_A484ClienteNacionalidade[0];
               n484ClienteNacionalidade = H006P5_n484ClienteNacionalidade[0];
               A486ClienteEstadoCivil = H006P5_A486ClienteEstadoCivil[0];
               n486ClienteEstadoCivil = H006P5_n486ClienteEstadoCivil[0];
               A487ClienteProfissao = H006P5_A487ClienteProfissao[0];
               n487ClienteProfissao = H006P5_n487ClienteProfissao[0];
               A168ClienteId = H006P5_A168ClienteId[0];
               A597EspecialidadeCreatedBy = H006P5_A597EspecialidadeCreatedBy[0];
               n597EspecialidadeCreatedBy = H006P5_n597EspecialidadeCreatedBy[0];
               A141SecUserName = H006P5_A141SecUserName[0];
               n141SecUserName = H006P5_n141SecUserName[0];
               A193TipoClienteDescricao = H006P5_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H006P5_n193TipoClienteDescricao[0];
               A187MunicipioNome = H006P5_A187MunicipioNome[0];
               n187MunicipioNome = H006P5_n187MunicipioNome[0];
               A189MunicipioUF = H006P5_A189MunicipioUF[0];
               n189MunicipioUF = H006P5_n189MunicipioUF[0];
               AV64GXLvl319 = 1;
               AV12ResponsavelClienteDocumento = A169ClienteDocumento;
               AssignAttri(sPrefix, false, "AV12ResponsavelClienteDocumento", AV12ResponsavelClienteDocumento);
               AV17ResponsavelClienteRazaoSocial = A170ClienteRazaoSocial;
               AssignAttri(sPrefix, false, "AV17ResponsavelClienteRazaoSocial", AV17ResponsavelClienteRazaoSocial);
               AV47ResponsavelClienteNomeFantasia = A171ClienteNomeFantasia;
               AssignAttri(sPrefix, false, "AV47ResponsavelClienteNomeFantasia", AV47ResponsavelClienteNomeFantasia);
               AV13ResponsavelClienteTipoPessoa = A172ClienteTipoPessoa;
               AssignAttri(sPrefix, false, "AV13ResponsavelClienteTipoPessoa", AV13ResponsavelClienteTipoPessoa);
               AV14ResponsavelTipoClienteId = A192TipoClienteId;
               AssignAttri(sPrefix, false, "AV14ResponsavelTipoClienteId", StringUtil.LTrimStr( (decimal)(AV14ResponsavelTipoClienteId), 4, 0));
               AV54ResponsavelTipoClienteDescricao = A193TipoClienteDescricao;
               AV22ResponsavelClienteStatus = A174ClienteStatus;
               AssignAttri(sPrefix, false, "AV22ResponsavelClienteStatus", AV22ResponsavelClienteStatus);
               AV48ResponsavelSecUserId = A133SecUserId;
               AssignAttri(sPrefix, false, "AV48ResponsavelSecUserId", StringUtil.LTrimStr( (decimal)(AV48ResponsavelSecUserId), 4, 0));
               AV55ResponsavelSecUserName = A141SecUserName;
               AV49ResponsavelEnderecoTipo = A181EnderecoTipo;
               AssignAttri(sPrefix, false, "AV49ResponsavelEnderecoTipo", AV49ResponsavelEnderecoTipo);
               AV29ResponsavelEnderecoCEP = A182EnderecoCEP;
               AssignAttri(sPrefix, false, "AV29ResponsavelEnderecoCEP", AV29ResponsavelEnderecoCEP);
               AV30ResponsavelEnderecoLogradouro = A183EnderecoLogradouro;
               AssignAttri(sPrefix, false, "AV30ResponsavelEnderecoLogradouro", AV30ResponsavelEnderecoLogradouro);
               AV33ResponsavelEnderecoBairro = A184EnderecoBairro;
               AssignAttri(sPrefix, false, "AV33ResponsavelEnderecoBairro", AV33ResponsavelEnderecoBairro);
               AV34ResponsavelEnderecoCidade = A185EnderecoCidade;
               AssignAttri(sPrefix, false, "AV34ResponsavelEnderecoCidade", AV34ResponsavelEnderecoCidade);
               AV35ResponsavelMunicipioCodigo = A186MunicipioCodigo;
               AssignAttri(sPrefix, false, "AV35ResponsavelMunicipioCodigo", AV35ResponsavelMunicipioCodigo);
               AV36ResponsavelMunicipioNome = A187MunicipioNome;
               AssignAttri(sPrefix, false, "AV36ResponsavelMunicipioNome", AV36ResponsavelMunicipioNome);
               AV37ResponsavelMunicipioUF = A189MunicipioUF;
               AssignAttri(sPrefix, false, "AV37ResponsavelMunicipioUF", AV37ResponsavelMunicipioUF);
               AV31ResponsavelEnderecoNumero = A190EnderecoNumero;
               AssignAttri(sPrefix, false, "AV31ResponsavelEnderecoNumero", AV31ResponsavelEnderecoNumero);
               AV32ResponsavelEnderecoComplemento = A191EnderecoComplemento;
               AssignAttri(sPrefix, false, "AV32ResponsavelEnderecoComplemento", AV32ResponsavelEnderecoComplemento);
               AV23ResponsavelContatoEmail = A201ContatoEmail;
               AssignAttri(sPrefix, false, "AV23ResponsavelContatoEmail", AV23ResponsavelContatoEmail);
               AV24ResponsavelContatoDDD = A198ContatoDDD;
               AssignAttri(sPrefix, false, "AV24ResponsavelContatoDDD", StringUtil.LTrimStr( (decimal)(AV24ResponsavelContatoDDD), 4, 0));
               AV50ResponsavelContatoDDI = A199ContatoDDI;
               AssignAttri(sPrefix, false, "AV50ResponsavelContatoDDI", StringUtil.LTrimStr( (decimal)(AV50ResponsavelContatoDDI), 4, 0));
               AV25ResponsavelContatoNumero = A200ContatoNumero;
               AssignAttri(sPrefix, false, "AV25ResponsavelContatoNumero", StringUtil.LTrimStr( (decimal)(AV25ResponsavelContatoNumero), 18, 0));
               AV27ResponsavelContatoTelefoneNumero = A202ContatoTelefoneNumero;
               AssignAttri(sPrefix, false, "AV27ResponsavelContatoTelefoneNumero", StringUtil.LTrimStr( (decimal)(AV27ResponsavelContatoTelefoneNumero), 18, 0));
               AV26ResponsavelContatoTelefoneDDD = A203ContatoTelefoneDDD;
               AssignAttri(sPrefix, false, "AV26ResponsavelContatoTelefoneDDD", StringUtil.LTrimStr( (decimal)(AV26ResponsavelContatoTelefoneDDD), 4, 0));
               AV51ResponsavelContatoTelefoneDDI = A204ContatoTelefoneDDI;
               AssignAttri(sPrefix, false, "AV51ResponsavelContatoTelefoneDDI", StringUtil.LTrimStr( (decimal)(AV51ResponsavelContatoTelefoneDDI), 4, 0));
               AV16ResponsavelClienteDataNascimento = A459ClienteDataNascimento;
               AssignAttri(sPrefix, false, "AV16ResponsavelClienteDataNascimento", context.localUtil.Format(AV16ResponsavelClienteDataNascimento, "99/99/9999"));
               AV18ResponsavelClienteRG = A421ClienteRG;
               AssignAttri(sPrefix, false, "AV18ResponsavelClienteRG", StringUtil.LTrimStr( (decimal)(AV18ResponsavelClienteRG), 12, 0));
               AV19ResponsavelClienteNacionalidade = A484ClienteNacionalidade;
               AssignAttri(sPrefix, false, "AV19ResponsavelClienteNacionalidade", StringUtil.LTrimStr( (decimal)(AV19ResponsavelClienteNacionalidade), 9, 0));
               AV20ResponsavelClienteEstadoCivil = A486ClienteEstadoCivil;
               AssignAttri(sPrefix, false, "AV20ResponsavelClienteEstadoCivil", AV20ResponsavelClienteEstadoCivil);
               AV21ResponsavelClienteProfissao = A487ClienteProfissao;
               AssignAttri(sPrefix, false, "AV21ResponsavelClienteProfissao", StringUtil.LTrimStr( (decimal)(AV21ResponsavelClienteProfissao), 9, 0));
               Combo_responsavelclientenacionalidade_Selectedvalue_set = ((0==AV19ResponsavelClienteNacionalidade) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV19ResponsavelClienteNacionalidade), 9, 0)));
               ucCombo_responsavelclientenacionalidade.SendProperty(context, sPrefix, false, Combo_responsavelclientenacionalidade_Internalname, "SelectedValue_set", Combo_responsavelclientenacionalidade_Selectedvalue_set);
               Combo_responsavelclienteprofissao_Selectedvalue_set = ((0==AV21ResponsavelClienteProfissao) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV21ResponsavelClienteProfissao), 9, 0)));
               ucCombo_responsavelclienteprofissao.SendProperty(context, sPrefix, false, Combo_responsavelclienteprofissao_Internalname, "SelectedValue_set", Combo_responsavelclienteprofissao_Selectedvalue_set);
               AV15ResponsavelClienteId = A168ClienteId;
               AssignAttri(sPrefix, false, "AV15ResponsavelClienteId", StringUtil.LTrimStr( (decimal)(AV15ResponsavelClienteId), 9, 0));
               AV28ResponsavelCEP = A182EnderecoCEP;
               AssignAttri(sPrefix, false, "AV28ResponsavelCEP", AV28ResponsavelCEP);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ResponsavelEnderecoCEP)) )
               {
                  edtavResponsavelcep_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelcep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcep_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17ResponsavelClienteRazaoSocial)) )
               {
                  edtavResponsavelclienterazaosocial_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclienterazaosocial_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13ResponsavelClienteTipoPessoa)) )
               {
                  cmbavResponsavelclientetipopessoa.Enabled = 0;
                  AssignProp(sPrefix, false, cmbavResponsavelclientetipopessoa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavResponsavelclientetipopessoa.Enabled), 5, 0), true);
               }
               if ( ! (0==AV14ResponsavelTipoClienteId) )
               {
                  edtavResponsaveltipoclienteid_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsaveltipoclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsaveltipoclienteid_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13ResponsavelClienteTipoPessoa)) )
               {
               }
               if ( ! (0==AV14ResponsavelTipoClienteId) )
               {
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ResponsavelEnderecoCEP)) )
               {
                  edtavResponsavelenderecocep_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelenderecocep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecocep_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ResponsavelEnderecoLogradouro)) )
               {
                  edtavResponsavelenderecologradouro_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelenderecologradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecologradouro_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ResponsavelEnderecoBairro)) )
               {
                  edtavResponsavelenderecobairro_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelenderecobairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecobairro_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ResponsavelEnderecoCidade)) )
               {
                  edtavResponsavelenderecocidade_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelenderecocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecocidade_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ResponsavelMunicipioCodigo)) )
               {
                  edtavResponsavelmunicipiocodigo_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelmunicipiocodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipiocodigo_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36ResponsavelMunicipioNome)) )
               {
                  edtavResponsavelmunicipionome_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelmunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipionome_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ResponsavelMunicipioUF)) )
               {
                  edtavResponsavelmunicipiouf_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelmunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipiouf_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ResponsavelEnderecoNumero)) )
               {
                  edtavResponsavelendereconumero_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelendereconumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelendereconumero_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32ResponsavelEnderecoComplemento)) )
               {
                  edtavResponsavelenderecocomplemento_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelenderecocomplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecocomplemento_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ResponsavelContatoEmail)) )
               {
                  edtavResponsavelcontatoemail_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelcontatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatoemail_Enabled), 5, 0), true);
               }
               if ( ! (0==AV25ResponsavelContatoNumero) )
               {
                  edtavResponsavelcontatonumero_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelcontatonumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatonumero_Enabled), 5, 0), true);
               }
               if ( ! (0==AV27ResponsavelContatoTelefoneNumero) )
               {
                  edtavResponsavelcontatotelefonenumero_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelcontatotelefonenumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatotelefonenumero_Enabled), 5, 0), true);
               }
               if ( ! (0==AV26ResponsavelContatoTelefoneDDD) )
               {
                  edtavResponsavelcontatotelefoneddd_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelcontatotelefoneddd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatotelefoneddd_Enabled), 5, 0), true);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ResponsavelContatoEmail)) )
               {
                  edtavResponsavelcontatoemail_Enabled = 0;
                  AssignProp(sPrefix, false, edtavResponsavelcontatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatoemail_Enabled), 5, 0), true);
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            if ( AV64GXLvl319 == 0 )
            {
               AV15ResponsavelClienteId = 0;
               AssignAttri(sPrefix, false, "AV15ResponsavelClienteId", StringUtil.LTrimStr( (decimal)(AV15ResponsavelClienteId), 9, 0));
               edtavResponsavelclientedocumento_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelclientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclientedocumento_Enabled), 5, 0), true);
               edtavResponsavelclienterazaosocial_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclienterazaosocial_Enabled), 5, 0), true);
               cmbavResponsavelclientetipopessoa.Enabled = 1;
               AssignProp(sPrefix, false, cmbavResponsavelclientetipopessoa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavResponsavelclientetipopessoa.Enabled), 5, 0), true);
               edtavResponsaveltipoclienteid_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsaveltipoclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsaveltipoclienteid_Enabled), 5, 0), true);
               edtavResponsavelenderecocep_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelenderecocep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecocep_Enabled), 5, 0), true);
               edtavResponsavelenderecologradouro_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelenderecologradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecologradouro_Enabled), 5, 0), true);
               edtavResponsavelenderecobairro_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelenderecobairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecobairro_Enabled), 5, 0), true);
               edtavResponsavelenderecocidade_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelenderecocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecocidade_Enabled), 5, 0), true);
               edtavResponsavelmunicipiocodigo_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelmunicipiocodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelmunicipiocodigo_Enabled), 5, 0), true);
               edtavResponsavelendereconumero_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelendereconumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelendereconumero_Enabled), 5, 0), true);
               edtavResponsavelenderecocomplemento_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelenderecocomplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecocomplemento_Enabled), 5, 0), true);
               edtavResponsavelcontatoemail_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelcontatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatoemail_Enabled), 5, 0), true);
               edtavResponsavelcontatonumero_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelcontatonumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatonumero_Enabled), 5, 0), true);
               edtavResponsavelcontatotelefonenumero_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelcontatotelefonenumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatotelefonenumero_Enabled), 5, 0), true);
               edtavResponsavelcontatotelefoneddd_Enabled = 1;
               AssignProp(sPrefix, false, edtavResponsavelcontatotelefoneddd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatotelefoneddd_Enabled), 5, 0), true);
            }
         }
         /*  Sending Event outputs  */
         cmbavResponsavelclientetipopessoa.CurrentValue = StringUtil.RTrim( AV13ResponsavelClienteTipoPessoa);
         AssignProp(sPrefix, false, cmbavResponsavelclientetipopessoa_Internalname, "Values", cmbavResponsavelclientetipopessoa.ToJavascriptSource(), true);
         cmbavResponsavelclientestatus.CurrentValue = StringUtil.BoolToStr( AV22ResponsavelClienteStatus);
         AssignProp(sPrefix, false, cmbavResponsavelclientestatus_Internalname, "Values", cmbavResponsavelclientestatus.ToJavascriptSource(), true);
         cmbavResponsavelclienteestadocivil.CurrentValue = StringUtil.RTrim( AV20ResponsavelClienteEstadoCivil);
         AssignProp(sPrefix, false, cmbavResponsavelclienteestadocivil_Internalname, "Values", cmbavResponsavelclienteestadocivil.ToJavascriptSource(), true);
      }

      protected void E176P2( )
      {
         /* Responsavelcep_Controlvaluechanged Routine */
         returnInSub = false;
         AV28ResponsavelCEP = StringUtil.StringReplace( AV28ResponsavelCEP, "-", "");
         AssignAttri(sPrefix, false, "AV28ResponsavelCEP", AV28ResponsavelCEP);
         AV56ResponsavelEnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ResponsavelCEP)) )
         {
            new GeneXus.Programs.myobjects.viacep.cepparaendereco(context ).execute(  AV28ResponsavelCEP, out  AV57ModeloRetorno, out  AV58Mensagem) ;
            AV59EnderecoCompleto.FromJSonString(AV57ModeloRetorno, null);
            /* Execute user subroutine: 'VALIDACEP' */
            S162 ();
            if (returnInSub) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56ResponsavelEnderecoCompleto.gxTpr_Cep)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CEP inválido",  "error",  edtavResponsavelcep_Internalname,  "true",  ""));
         }
         AV33ResponsavelEnderecoBairro = AV59EnderecoCompleto.gxTpr_Bairro;
         AssignAttri(sPrefix, false, "AV33ResponsavelEnderecoBairro", AV33ResponsavelEnderecoBairro);
         AV34ResponsavelEnderecoCidade = AV59EnderecoCompleto.gxTpr_Localidade;
         AssignAttri(sPrefix, false, "AV34ResponsavelEnderecoCidade", AV34ResponsavelEnderecoCidade);
         AV30ResponsavelEnderecoLogradouro = AV59EnderecoCompleto.gxTpr_Logradouro;
         AssignAttri(sPrefix, false, "AV30ResponsavelEnderecoLogradouro", AV30ResponsavelEnderecoLogradouro);
         AV35ResponsavelMunicipioCodigo = AV59EnderecoCompleto.gxTpr_Ibge;
         AssignAttri(sPrefix, false, "AV35ResponsavelMunicipioCodigo", AV35ResponsavelMunicipioCodigo);
         /* Using cursor H006P6 */
         pr_default.execute(4, new Object[] {AV35ResponsavelMunicipioCodigo});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A186MunicipioCodigo = H006P6_A186MunicipioCodigo[0];
            n186MunicipioCodigo = H006P6_n186MunicipioCodigo[0];
            A187MunicipioNome = H006P6_A187MunicipioNome[0];
            n187MunicipioNome = H006P6_n187MunicipioNome[0];
            A189MunicipioUF = H006P6_A189MunicipioUF[0];
            n189MunicipioUF = H006P6_n189MunicipioUF[0];
            AV36ResponsavelMunicipioNome = A187MunicipioNome;
            AssignAttri(sPrefix, false, "AV36ResponsavelMunicipioNome", AV36ResponsavelMunicipioNome);
            AV37ResponsavelMunicipioUF = A189MunicipioUF;
            AssignAttri(sPrefix, false, "AV37ResponsavelMunicipioUF", AV37ResponsavelMunicipioUF);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         edtavResponsavelenderecobairro_Enabled = (String.IsNullOrEmpty(StringUtil.RTrim( AV59EnderecoCompleto.gxTpr_Bairro)) ? 1 : 0);
         AssignProp(sPrefix, false, edtavResponsavelenderecobairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecobairro_Enabled), 5, 0), true);
         edtavResponsavelenderecocidade_Enabled = (String.IsNullOrEmpty(StringUtil.RTrim( AV59EnderecoCompleto.gxTpr_Localidade)) ? 1 : 0);
         AssignProp(sPrefix, false, edtavResponsavelenderecocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecocidade_Enabled), 5, 0), true);
         edtavResponsavelenderecologradouro_Enabled = (String.IsNullOrEmpty(StringUtil.RTrim( AV59EnderecoCompleto.gxTpr_Logradouro)) ? 1 : 0);
         AssignProp(sPrefix, false, edtavResponsavelenderecologradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelenderecologradouro_Enabled), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV56ResponsavelEnderecoCompleto", AV56ResponsavelEnderecoCompleto);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV59EnderecoCompleto", AV59EnderecoCompleto);
      }

      protected void S162( )
      {
         /* 'VALIDACEP' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56ResponsavelEnderecoCompleto.gxTpr_Cep)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CEP não encontrado",  "error",  edtavResponsavelcep_Internalname,  "true",  ""));
            AV38CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV38CheckRequiredFieldsResult", AV38CheckRequiredFieldsResult);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E186P2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_124_6P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedresponsavelcontatotelefoneddd_Internalname, tblTablemergedresponsavelcontatotelefoneddd_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelcontatotelefoneddd_Internalname, "Responsavel Contato Telefone DDD", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelcontatotelefoneddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ResponsavelContatoTelefoneDDD), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV26ResponsavelContatoTelefoneDDD), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,128);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "DDD", edtavResponsavelcontatotelefoneddd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResponsavelcontatotelefoneddd_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelcontatotelefonenumero_Internalname, "Responsavel Contato Telefone Numero", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelcontatotelefonenumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27ResponsavelContatoTelefoneNumero), 18, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV27ResponsavelContatoTelefoneNumero), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,131);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Número", edtavResponsavelcontatotelefonenumero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResponsavelcontatotelefonenumero_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_124_6P2e( true) ;
         }
         else
         {
            wb_table2_124_6P2e( false) ;
         }
      }

      protected void wb_table1_110_6P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedresponsavelcontatoddd_Internalname, tblTablemergedresponsavelcontatoddd_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelcontatoddd_Internalname, "Responsavel Contato DDD", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelcontatoddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ResponsavelContatoDDD), 4, 0, ",", "")), StringUtil.LTrim( ((edtavResponsavelcontatoddd_Enabled!=0) ? context.localUtil.Format( (decimal)(AV24ResponsavelContatoDDD), "ZZZ9") : context.localUtil.Format( (decimal)(AV24ResponsavelContatoDDD), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,114);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "DDD", edtavResponsavelcontatoddd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResponsavelcontatoddd_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelcontatonumero_Internalname, "Responsavel Contato Numero", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelcontatonumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ResponsavelContatoNumero), 18, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV25ResponsavelContatoNumero), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,117);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Número", edtavResponsavelcontatonumero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResponsavelcontatonumero_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResponsavel.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_110_6P2e( true) ;
         }
         else
         {
            wb_table1_110_6P2e( false) ;
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
         PA6P2( ) ;
         WS6P2( ) ;
         WE6P2( ) ;
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
         PA6P2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpnovapropostaresponsavel", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6P2( ) ;
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
         PA6P2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6P2( ) ;
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
         WS6P2( ) ;
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
         WE6P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019192865", true, true);
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
         context.AddJavascriptSource("wpnovapropostaresponsavel.js", "?202561019192866", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavResponsavelclienteestadocivil.Name = "vRESPONSAVELCLIENTEESTADOCIVIL";
         cmbavResponsavelclienteestadocivil.WebTags = "";
         cmbavResponsavelclienteestadocivil.addItem("SOLTEIRO", "Solteiro(a)", 0);
         cmbavResponsavelclienteestadocivil.addItem("CASADO", "Casado(a)", 0);
         cmbavResponsavelclienteestadocivil.addItem("DIVORCIADO", "Divorciado(a)", 0);
         cmbavResponsavelclienteestadocivil.addItem("VIUVO", "Viúvo(a)", 0);
         cmbavResponsavelclienteestadocivil.addItem("SEPARADO", "Separado(a)", 0);
         cmbavResponsavelclienteestadocivil.addItem("UNIAO_ESTAVEL", "União Estável", 0);
         if ( cmbavResponsavelclienteestadocivil.ItemCount > 0 )
         {
         }
         cmbavResponsavelclientetipopessoa.Name = "vRESPONSAVELCLIENTETIPOPESSOA";
         cmbavResponsavelclientetipopessoa.WebTags = "";
         cmbavResponsavelclientetipopessoa.addItem("FISICA", "Física", 0);
         cmbavResponsavelclientetipopessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbavResponsavelclientetipopessoa.ItemCount > 0 )
         {
         }
         cmbavResponsavelclientestatus.Name = "vRESPONSAVELCLIENTESTATUS";
         cmbavResponsavelclientestatus.WebTags = "";
         cmbavResponsavelclientestatus.addItem(StringUtil.BoolToStr( true), "ATIVO", 0);
         cmbavResponsavelclientestatus.addItem(StringUtil.BoolToStr( false), "INATIVO", 0);
         if ( cmbavResponsavelclientestatus.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavResponsavelclientedocumento_Internalname = sPrefix+"vRESPONSAVELCLIENTEDOCUMENTO";
         edtavResponsavelclientedatanascimento_Internalname = sPrefix+"vRESPONSAVELCLIENTEDATANASCIMENTO";
         edtavResponsavelclienterazaosocial_Internalname = sPrefix+"vRESPONSAVELCLIENTERAZAOSOCIAL";
         edtavResponsavelclienterg_Internalname = sPrefix+"vRESPONSAVELCLIENTERG";
         lblTextblockcombo_responsavelclientenacionalidade_Internalname = sPrefix+"TEXTBLOCKCOMBO_RESPONSAVELCLIENTENACIONALIDADE";
         Combo_responsavelclientenacionalidade_Internalname = sPrefix+"COMBO_RESPONSAVELCLIENTENACIONALIDADE";
         divTablesplittedresponsavelclientenacionalidade_Internalname = sPrefix+"TABLESPLITTEDRESPONSAVELCLIENTENACIONALIDADE";
         cmbavResponsavelclienteestadocivil_Internalname = sPrefix+"vRESPONSAVELCLIENTEESTADOCIVIL";
         lblTextblockcombo_responsavelclienteprofissao_Internalname = sPrefix+"TEXTBLOCKCOMBO_RESPONSAVELCLIENTEPROFISSAO";
         Combo_responsavelclienteprofissao_Internalname = sPrefix+"COMBO_RESPONSAVELCLIENTEPROFISSAO";
         divTablesplittedresponsavelclienteprofissao_Internalname = sPrefix+"TABLESPLITTEDRESPONSAVELCLIENTEPROFISSAO";
         edtavResponsavelcep_Internalname = sPrefix+"vRESPONSAVELCEP";
         edtavResponsavelenderecologradouro_Internalname = sPrefix+"vRESPONSAVELENDERECOLOGRADOURO";
         edtavResponsavelendereconumero_Internalname = sPrefix+"vRESPONSAVELENDERECONUMERO";
         edtavResponsavelenderecocomplemento_Internalname = sPrefix+"vRESPONSAVELENDERECOCOMPLEMENTO";
         edtavResponsavelenderecobairro_Internalname = sPrefix+"vRESPONSAVELENDERECOBAIRRO";
         edtavResponsavelenderecocidade_Internalname = sPrefix+"vRESPONSAVELENDERECOCIDADE";
         edtavResponsavelmunicipionome_Internalname = sPrefix+"vRESPONSAVELMUNICIPIONOME";
         edtavResponsavelmunicipiouf_Internalname = sPrefix+"vRESPONSAVELMUNICIPIOUF";
         divTableendereco_Internalname = sPrefix+"TABLEENDERECO";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         edtavResponsavelcontatoemail_Internalname = sPrefix+"vRESPONSAVELCONTATOEMAIL";
         lblTextblockresponsavelcontatoddd_Internalname = sPrefix+"TEXTBLOCKRESPONSAVELCONTATODDD";
         edtavResponsavelcontatoddd_Internalname = sPrefix+"vRESPONSAVELCONTATODDD";
         edtavResponsavelcontatonumero_Internalname = sPrefix+"vRESPONSAVELCONTATONUMERO";
         tblTablemergedresponsavelcontatoddd_Internalname = sPrefix+"TABLEMERGEDRESPONSAVELCONTATODDD";
         divTablesplittedresponsavelcontatoddd_Internalname = sPrefix+"TABLESPLITTEDRESPONSAVELCONTATODDD";
         lblTextblockresponsavelcontatotelefoneddd_Internalname = sPrefix+"TEXTBLOCKRESPONSAVELCONTATOTELEFONEDDD";
         edtavResponsavelcontatotelefoneddd_Internalname = sPrefix+"vRESPONSAVELCONTATOTELEFONEDDD";
         edtavResponsavelcontatotelefonenumero_Internalname = sPrefix+"vRESPONSAVELCONTATOTELEFONENUMERO";
         tblTablemergedresponsavelcontatotelefoneddd_Internalname = sPrefix+"TABLEMERGEDRESPONSAVELCONTATOTELEFONEDDD";
         divTablesplittedresponsavelcontatotelefoneddd_Internalname = sPrefix+"TABLESPLITTEDRESPONSAVELCONTATOTELEFONEDDD";
         divTablecontato_Internalname = sPrefix+"TABLECONTATO";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = sPrefix+"DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavResponsavelclientenacionalidade_Internalname = sPrefix+"vRESPONSAVELCLIENTENACIONALIDADE";
         edtavResponsavelclienteprofissao_Internalname = sPrefix+"vRESPONSAVELCLIENTEPROFISSAO";
         cmbavResponsavelclientetipopessoa_Internalname = sPrefix+"vRESPONSAVELCLIENTETIPOPESSOA";
         edtavResponsaveltipoclienteid_Internalname = sPrefix+"vRESPONSAVELTIPOCLIENTEID";
         edtavResponsavelclienteid_Internalname = sPrefix+"vRESPONSAVELCLIENTEID";
         cmbavResponsavelclientestatus_Internalname = sPrefix+"vRESPONSAVELCLIENTESTATUS";
         edtavResponsavelenderecocep_Internalname = sPrefix+"vRESPONSAVELENDERECOCEP";
         edtavResponsavelmunicipiocodigo_Internalname = sPrefix+"vRESPONSAVELMUNICIPIOCODIGO";
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
         edtavResponsavelcontatonumero_Jsonclick = "";
         edtavResponsavelcontatoddd_Jsonclick = "";
         edtavResponsavelcontatoddd_Enabled = 1;
         edtavResponsavelcontatotelefonenumero_Jsonclick = "";
         edtavResponsavelcontatotelefoneddd_Jsonclick = "";
         edtavResponsavelcontatotelefoneddd_Enabled = 1;
         edtavResponsavelcontatotelefonenumero_Enabled = 1;
         edtavResponsavelcontatonumero_Enabled = 1;
         edtavResponsavelmunicipiocodigo_Jsonclick = "";
         edtavResponsavelmunicipiocodigo_Enabled = 1;
         edtavResponsavelmunicipiocodigo_Visible = 1;
         edtavResponsavelenderecocep_Jsonclick = "";
         edtavResponsavelenderecocep_Enabled = 1;
         edtavResponsavelenderecocep_Visible = 1;
         cmbavResponsavelclientestatus_Jsonclick = "";
         cmbavResponsavelclientestatus.Visible = 1;
         edtavResponsavelclienteid_Jsonclick = "";
         edtavResponsavelclienteid_Visible = 1;
         edtavResponsaveltipoclienteid_Jsonclick = "";
         edtavResponsaveltipoclienteid_Enabled = 1;
         edtavResponsaveltipoclienteid_Visible = 1;
         cmbavResponsavelclientetipopessoa_Jsonclick = "";
         cmbavResponsavelclientetipopessoa.Visible = 1;
         cmbavResponsavelclientetipopessoa.Enabled = 1;
         edtavResponsavelclienteprofissao_Jsonclick = "";
         edtavResponsavelclienteprofissao_Visible = 1;
         edtavResponsavelclientenacionalidade_Jsonclick = "";
         edtavResponsavelclientenacionalidade_Visible = 1;
         Btnwizardnext_Class = "Button ButtonWizard";
         Btnwizardnext_Caption = "Próximo";
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardprevious_Caption = "Anterior";
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         edtavResponsavelcontatoemail_Jsonclick = "";
         edtavResponsavelcontatoemail_Enabled = 1;
         edtavResponsavelmunicipiouf_Jsonclick = "";
         edtavResponsavelmunicipiouf_Enabled = 1;
         edtavResponsavelmunicipionome_Jsonclick = "";
         edtavResponsavelmunicipionome_Enabled = 1;
         edtavResponsavelenderecocidade_Jsonclick = "";
         edtavResponsavelenderecocidade_Enabled = 1;
         edtavResponsavelenderecobairro_Jsonclick = "";
         edtavResponsavelenderecobairro_Enabled = 1;
         edtavResponsavelenderecocomplemento_Jsonclick = "";
         edtavResponsavelenderecocomplemento_Enabled = 1;
         edtavResponsavelendereconumero_Jsonclick = "";
         edtavResponsavelendereconumero_Enabled = 1;
         edtavResponsavelenderecologradouro_Jsonclick = "";
         edtavResponsavelenderecologradouro_Enabled = 1;
         edtavResponsavelcep_Jsonclick = "";
         edtavResponsavelcep_Enabled = 1;
         Combo_responsavelclienteprofissao_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_responsavelclienteprofissao_Emptyitem = Convert.ToBoolean( 0);
         Combo_responsavelclienteprofissao_Cls = "ExtendedCombo AttributeFL";
         cmbavResponsavelclienteestadocivil_Jsonclick = "";
         cmbavResponsavelclienteestadocivil.Enabled = 1;
         Combo_responsavelclientenacionalidade_Emptyitem = Convert.ToBoolean( 0);
         Combo_responsavelclientenacionalidade_Cls = "ExtendedCombo AttributeFL";
         edtavResponsavelclienterg_Jsonclick = "";
         edtavResponsavelclienterg_Enabled = 1;
         edtavResponsavelclienterazaosocial_Jsonclick = "";
         edtavResponsavelclienterazaosocial_Enabled = 1;
         edtavResponsavelclientedatanascimento_Jsonclick = "";
         edtavResponsavelclientedatanascimento_Enabled = 1;
         edtavResponsavelclientedocumento_Jsonclick = "";
         edtavResponsavelclientedocumento_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "";
         Dvpanel_tableattributes_Cls = "PanelLine_Gray";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("ENTER","""{"handler":"E136P2","iparms":[{"av":"AV15ResponsavelClienteId","fld":"vRESPONSAVELCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12ResponsavelClienteDocumento","fld":"vRESPONSAVELCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV17ResponsavelClienteRazaoSocial","fld":"vRESPONSAVELCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV47ResponsavelClienteNomeFantasia","fld":"vRESPONSAVELCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"cmbavResponsavelclientetipopessoa"},{"av":"AV13ResponsavelClienteTipoPessoa","fld":"vRESPONSAVELCLIENTETIPOPESSOA","type":"svchar"},{"av":"AV14ResponsavelTipoClienteId","fld":"vRESPONSAVELTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"cmbavResponsavelclientestatus"},{"av":"AV22ResponsavelClienteStatus","fld":"vRESPONSAVELCLIENTESTATUS","type":"boolean"},{"av":"AV48ResponsavelSecUserId","fld":"vRESPONSAVELSECUSERID","pic":"ZZZ9","type":"int"},{"av":"AV21ResponsavelClienteProfissao","fld":"vRESPONSAVELCLIENTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV19ResponsavelClienteNacionalidade","fld":"vRESPONSAVELCLIENTENACIONALIDADE","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavResponsavelclienteestadocivil"},{"av":"AV20ResponsavelClienteEstadoCivil","fld":"vRESPONSAVELCLIENTEESTADOCIVIL","type":"svchar"},{"av":"AV18ResponsavelClienteRG","fld":"vRESPONSAVELCLIENTERG","pic":"ZZZZZZZZZZZ9","type":"int"},{"av":"AV49ResponsavelEnderecoTipo","fld":"vRESPONSAVELENDERECOTIPO","type":"svchar"},{"av":"AV28ResponsavelCEP","fld":"vRESPONSAVELCEP","type":"svchar"},{"av":"AV30ResponsavelEnderecoLogradouro","fld":"vRESPONSAVELENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"AV33ResponsavelEnderecoBairro","fld":"vRESPONSAVELENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"AV34ResponsavelEnderecoCidade","fld":"vRESPONSAVELENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"AV35ResponsavelMunicipioCodigo","fld":"vRESPONSAVELMUNICIPIOCODIGO","type":"svchar"},{"av":"AV31ResponsavelEnderecoNumero","fld":"vRESPONSAVELENDERECONUMERO","type":"svchar"},{"av":"AV32ResponsavelEnderecoComplemento","fld":"vRESPONSAVELENDERECOCOMPLEMENTO","type":"svchar"},{"av":"AV16ResponsavelClienteDataNascimento","fld":"vRESPONSAVELCLIENTEDATANASCIMENTO","type":"date"},{"av":"AV23ResponsavelContatoEmail","fld":"vRESPONSAVELCONTATOEMAIL","type":"svchar"},{"av":"AV24ResponsavelContatoDDD","fld":"vRESPONSAVELCONTATODDD","pic":"ZZZ9","type":"int"},{"av":"AV50ResponsavelContatoDDI","fld":"vRESPONSAVELCONTATODDI","pic":"ZZZ9","type":"int"},{"av":"AV25ResponsavelContatoNumero","fld":"vRESPONSAVELCONTATONUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ResponsavelContatoTelefoneNumero","fld":"vRESPONSAVELCONTATOTELEFONENUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV26ResponsavelContatoTelefoneDDD","fld":"vRESPONSAVELCONTATOTELEFONEDDD","pic":"ZZZ9","type":"int"},{"av":"AV51ResponsavelContatoTelefoneDDI","fld":"vRESPONSAVELCONTATOTELEFONEDDI","pic":"ZZZ9","type":"int"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""},{"av":"AV38CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"Combo_responsavelclientenacionalidade_Ddointernalname","ctrl":"COMBO_RESPONSAVELCLIENTENACIONALIDADE","prop":"DDOInternalName"},{"av":"Combo_responsavelclienteprofissao_Ddointernalname","ctrl":"COMBO_RESPONSAVELCLIENTEPROFISSAO","prop":"DDOInternalName"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV29ResponsavelEnderecoCEP","fld":"vRESPONSAVELENDERECOCEP","type":"svchar"},{"av":"AV36ResponsavelMunicipioNome","fld":"vRESPONSAVELMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV37ResponsavelMunicipioUF","fld":"vRESPONSAVELMUNICIPIOUF","pic":"@!","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV15ResponsavelClienteId","fld":"vRESPONSAVELCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E146P2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV12ResponsavelClienteDocumento","fld":"vRESPONSAVELCLIENTEDOCUMENTO","type":"svchar"},{"av":"cmbavResponsavelclientetipopessoa"},{"av":"AV13ResponsavelClienteTipoPessoa","fld":"vRESPONSAVELCLIENTETIPOPESSOA","type":"svchar"},{"av":"AV14ResponsavelTipoClienteId","fld":"vRESPONSAVELTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV15ResponsavelClienteId","fld":"vRESPONSAVELCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV16ResponsavelClienteDataNascimento","fld":"vRESPONSAVELCLIENTEDATANASCIMENTO","type":"date"},{"av":"AV17ResponsavelClienteRazaoSocial","fld":"vRESPONSAVELCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV18ResponsavelClienteRG","fld":"vRESPONSAVELCLIENTERG","pic":"ZZZZZZZZZZZ9","type":"int"},{"av":"AV19ResponsavelClienteNacionalidade","fld":"vRESPONSAVELCLIENTENACIONALIDADE","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavResponsavelclienteestadocivil"},{"av":"AV20ResponsavelClienteEstadoCivil","fld":"vRESPONSAVELCLIENTEESTADOCIVIL","type":"svchar"},{"av":"AV21ResponsavelClienteProfissao","fld":"vRESPONSAVELCLIENTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavResponsavelclientestatus"},{"av":"AV22ResponsavelClienteStatus","fld":"vRESPONSAVELCLIENTESTATUS","type":"boolean"},{"av":"AV23ResponsavelContatoEmail","fld":"vRESPONSAVELCONTATOEMAIL","type":"svchar"},{"av":"AV24ResponsavelContatoDDD","fld":"vRESPONSAVELCONTATODDD","pic":"ZZZ9","type":"int"},{"av":"AV25ResponsavelContatoNumero","fld":"vRESPONSAVELCONTATONUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV26ResponsavelContatoTelefoneDDD","fld":"vRESPONSAVELCONTATOTELEFONEDDD","pic":"ZZZ9","type":"int"},{"av":"AV27ResponsavelContatoTelefoneNumero","fld":"vRESPONSAVELCONTATOTELEFONENUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV28ResponsavelCEP","fld":"vRESPONSAVELCEP","type":"svchar"},{"av":"AV29ResponsavelEnderecoCEP","fld":"vRESPONSAVELENDERECOCEP","type":"svchar"},{"av":"AV30ResponsavelEnderecoLogradouro","fld":"vRESPONSAVELENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"AV31ResponsavelEnderecoNumero","fld":"vRESPONSAVELENDERECONUMERO","type":"svchar"},{"av":"AV32ResponsavelEnderecoComplemento","fld":"vRESPONSAVELENDERECOCOMPLEMENTO","type":"svchar"},{"av":"AV33ResponsavelEnderecoBairro","fld":"vRESPONSAVELENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"AV34ResponsavelEnderecoCidade","fld":"vRESPONSAVELENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"AV35ResponsavelMunicipioCodigo","fld":"vRESPONSAVELMUNICIPIOCODIGO","type":"svchar"},{"av":"AV36ResponsavelMunicipioNome","fld":"vRESPONSAVELMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV37ResponsavelMunicipioUF","fld":"vRESPONSAVELMUNICIPIOUF","pic":"@!","type":"svchar"}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""}]}""");
         setEventMetadata("COMBO_RESPONSAVELCLIENTEPROFISSAO.ONOPTIONCLICKED","""{"handler":"E116P2","iparms":[{"av":"Combo_responsavelclienteprofissao_Selectedvalue_get","ctrl":"COMBO_RESPONSAVELCLIENTEPROFISSAO","prop":"SelectedValue_get"},{"av":"A440ProfissaoId","fld":"PROFISSAOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A441ProfissaoNome","fld":"PROFISSAONOME","pic":"@!","type":"svchar"},{"av":"AV21ResponsavelClienteProfissao","fld":"vRESPONSAVELCLIENTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("COMBO_RESPONSAVELCLIENTEPROFISSAO.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_responsavelclienteprofissao_Selectedvalue_set","ctrl":"COMBO_RESPONSAVELCLIENTEPROFISSAO","prop":"SelectedValue_set"},{"av":"AV21ResponsavelClienteProfissao","fld":"vRESPONSAVELCLIENTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV42ResponsavelClienteProfissao_Data","fld":"vRESPONSAVELCLIENTEPROFISSAO_DATA","type":""}]}""");
         setEventMetadata("VRESPONSAVELCLIENTEDATANASCIMENTO.CONTROLVALUECHANGED","""{"handler":"E156P2","iparms":[{"av":"AV16ResponsavelClienteDataNascimento","fld":"vRESPONSAVELCLIENTEDATANASCIMENTO","type":"date"}]}""");
         setEventMetadata("VRESPONSAVELCLIENTEDOCUMENTO.CONTROLVALUECHANGED","""{"handler":"E166P2","iparms":[{"av":"AV12ResponsavelClienteDocumento","fld":"vRESPONSAVELCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""},{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A171ClienteNomeFantasia","fld":"CLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"A172ClienteTipoPessoa","fld":"CLIENTETIPOPESSOA","type":"svchar"},{"av":"A192TipoClienteId","fld":"TIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"A193TipoClienteDescricao","fld":"TIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A141SecUserName","fld":"SECUSERNAME","pic":"@!","type":"svchar"},{"av":"A181EnderecoTipo","fld":"ENDERECOTIPO","type":"svchar"},{"av":"A182EnderecoCEP","fld":"ENDERECOCEP","type":"svchar"},{"av":"A183EnderecoLogradouro","fld":"ENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"A184EnderecoBairro","fld":"ENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"A185EnderecoCidade","fld":"ENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"A186MunicipioCodigo","fld":"MUNICIPIOCODIGO","type":"svchar"},{"av":"A187MunicipioNome","fld":"MUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"A189MunicipioUF","fld":"MUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"A190EnderecoNumero","fld":"ENDERECONUMERO","type":"svchar"},{"av":"A191EnderecoComplemento","fld":"ENDERECOCOMPLEMENTO","type":"svchar"},{"av":"A201ContatoEmail","fld":"CONTATOEMAIL","type":"svchar"},{"av":"A198ContatoDDD","fld":"CONTATODDD","pic":"ZZZ9","type":"int"},{"av":"A199ContatoDDI","fld":"CONTATODDI","pic":"ZZZ9","type":"int"},{"av":"A200ContatoNumero","fld":"CONTATONUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"A202ContatoTelefoneNumero","fld":"CONTATOTELEFONENUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"A203ContatoTelefoneDDD","fld":"CONTATOTELEFONEDDD","pic":"ZZZ9","type":"int"},{"av":"A204ContatoTelefoneDDI","fld":"CONTATOTELEFONEDDI","pic":"ZZZ9","type":"int"},{"av":"A459ClienteDataNascimento","fld":"CLIENTEDATANASCIMENTO","type":"date"},{"av":"A421ClienteRG","fld":"CLIENTERG","pic":"ZZZZZZZZZZZ9","type":"int"},{"av":"A484ClienteNacionalidade","fld":"CLIENTENACIONALIDADE","pic":"ZZZZZZZZ9","type":"int"},{"av":"A486ClienteEstadoCivil","fld":"CLIENTEESTADOCIVIL","type":"svchar"},{"av":"A487ClienteProfissao","fld":"CLIENTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VRESPONSAVELCLIENTEDOCUMENTO.CONTROLVALUECHANGED",""","oparms":[{"av":"AV12ResponsavelClienteDocumento","fld":"vRESPONSAVELCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV17ResponsavelClienteRazaoSocial","fld":"vRESPONSAVELCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV47ResponsavelClienteNomeFantasia","fld":"vRESPONSAVELCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"cmbavResponsavelclientetipopessoa"},{"av":"AV13ResponsavelClienteTipoPessoa","fld":"vRESPONSAVELCLIENTETIPOPESSOA","type":"svchar"},{"av":"AV14ResponsavelTipoClienteId","fld":"vRESPONSAVELTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"cmbavResponsavelclientestatus"},{"av":"AV22ResponsavelClienteStatus","fld":"vRESPONSAVELCLIENTESTATUS","type":"boolean"},{"av":"AV48ResponsavelSecUserId","fld":"vRESPONSAVELSECUSERID","pic":"ZZZ9","type":"int"},{"av":"AV49ResponsavelEnderecoTipo","fld":"vRESPONSAVELENDERECOTIPO","type":"svchar"},{"av":"AV29ResponsavelEnderecoCEP","fld":"vRESPONSAVELENDERECOCEP","type":"svchar"},{"av":"AV30ResponsavelEnderecoLogradouro","fld":"vRESPONSAVELENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"AV33ResponsavelEnderecoBairro","fld":"vRESPONSAVELENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"AV34ResponsavelEnderecoCidade","fld":"vRESPONSAVELENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"AV35ResponsavelMunicipioCodigo","fld":"vRESPONSAVELMUNICIPIOCODIGO","type":"svchar"},{"av":"AV36ResponsavelMunicipioNome","fld":"vRESPONSAVELMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV37ResponsavelMunicipioUF","fld":"vRESPONSAVELMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"AV31ResponsavelEnderecoNumero","fld":"vRESPONSAVELENDERECONUMERO","type":"svchar"},{"av":"AV32ResponsavelEnderecoComplemento","fld":"vRESPONSAVELENDERECOCOMPLEMENTO","type":"svchar"},{"av":"AV23ResponsavelContatoEmail","fld":"vRESPONSAVELCONTATOEMAIL","type":"svchar"},{"av":"AV24ResponsavelContatoDDD","fld":"vRESPONSAVELCONTATODDD","pic":"ZZZ9","type":"int"},{"av":"AV50ResponsavelContatoDDI","fld":"vRESPONSAVELCONTATODDI","pic":"ZZZ9","type":"int"},{"av":"AV25ResponsavelContatoNumero","fld":"vRESPONSAVELCONTATONUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV27ResponsavelContatoTelefoneNumero","fld":"vRESPONSAVELCONTATOTELEFONENUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV26ResponsavelContatoTelefoneDDD","fld":"vRESPONSAVELCONTATOTELEFONEDDD","pic":"ZZZ9","type":"int"},{"av":"AV51ResponsavelContatoTelefoneDDI","fld":"vRESPONSAVELCONTATOTELEFONEDDI","pic":"ZZZ9","type":"int"},{"av":"AV16ResponsavelClienteDataNascimento","fld":"vRESPONSAVELCLIENTEDATANASCIMENTO","type":"date"},{"av":"AV18ResponsavelClienteRG","fld":"vRESPONSAVELCLIENTERG","pic":"ZZZZZZZZZZZ9","type":"int"},{"av":"AV19ResponsavelClienteNacionalidade","fld":"vRESPONSAVELCLIENTENACIONALIDADE","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavResponsavelclienteestadocivil"},{"av":"AV20ResponsavelClienteEstadoCivil","fld":"vRESPONSAVELCLIENTEESTADOCIVIL","type":"svchar"},{"av":"AV21ResponsavelClienteProfissao","fld":"vRESPONSAVELCLIENTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"Combo_responsavelclientenacionalidade_Selectedvalue_set","ctrl":"COMBO_RESPONSAVELCLIENTENACIONALIDADE","prop":"SelectedValue_set"},{"av":"Combo_responsavelclienteprofissao_Selectedvalue_set","ctrl":"COMBO_RESPONSAVELCLIENTEPROFISSAO","prop":"SelectedValue_set"},{"av":"AV15ResponsavelClienteId","fld":"vRESPONSAVELCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ResponsavelCEP","fld":"vRESPONSAVELCEP","type":"svchar"},{"av":"edtavResponsavelcep_Enabled","ctrl":"vRESPONSAVELCEP","prop":"Enabled"},{"av":"edtavResponsavelclienterazaosocial_Enabled","ctrl":"vRESPONSAVELCLIENTERAZAOSOCIAL","prop":"Enabled"},{"av":"edtavResponsaveltipoclienteid_Enabled","ctrl":"vRESPONSAVELTIPOCLIENTEID","prop":"Enabled"},{"av":"edtavResponsavelenderecocep_Enabled","ctrl":"vRESPONSAVELENDERECOCEP","prop":"Enabled"},{"av":"edtavResponsavelenderecologradouro_Enabled","ctrl":"vRESPONSAVELENDERECOLOGRADOURO","prop":"Enabled"},{"av":"edtavResponsavelenderecobairro_Enabled","ctrl":"vRESPONSAVELENDERECOBAIRRO","prop":"Enabled"},{"av":"edtavResponsavelenderecocidade_Enabled","ctrl":"vRESPONSAVELENDERECOCIDADE","prop":"Enabled"},{"av":"edtavResponsavelmunicipiocodigo_Enabled","ctrl":"vRESPONSAVELMUNICIPIOCODIGO","prop":"Enabled"},{"av":"edtavResponsavelmunicipionome_Enabled","ctrl":"vRESPONSAVELMUNICIPIONOME","prop":"Enabled"},{"av":"edtavResponsavelmunicipiouf_Enabled","ctrl":"vRESPONSAVELMUNICIPIOUF","prop":"Enabled"},{"av":"edtavResponsavelendereconumero_Enabled","ctrl":"vRESPONSAVELENDERECONUMERO","prop":"Enabled"},{"av":"edtavResponsavelenderecocomplemento_Enabled","ctrl":"vRESPONSAVELENDERECOCOMPLEMENTO","prop":"Enabled"},{"av":"edtavResponsavelcontatoemail_Enabled","ctrl":"vRESPONSAVELCONTATOEMAIL","prop":"Enabled"},{"av":"edtavResponsavelcontatonumero_Enabled","ctrl":"vRESPONSAVELCONTATONUMERO","prop":"Enabled"},{"av":"edtavResponsavelcontatotelefonenumero_Enabled","ctrl":"vRESPONSAVELCONTATOTELEFONENUMERO","prop":"Enabled"},{"av":"edtavResponsavelcontatotelefoneddd_Enabled","ctrl":"vRESPONSAVELCONTATOTELEFONEDDD","prop":"Enabled"},{"av":"edtavResponsavelclientedocumento_Enabled","ctrl":"vRESPONSAVELCLIENTEDOCUMENTO","prop":"Enabled"}]}""");
         setEventMetadata("VRESPONSAVELCEP.CONTROLVALUECHANGED","""{"handler":"E176P2","iparms":[{"av":"AV28ResponsavelCEP","fld":"vRESPONSAVELCEP","type":"svchar"},{"av":"AV59EnderecoCompleto","fld":"vENDERECOCOMPLETO","type":""},{"av":"A186MunicipioCodigo","fld":"MUNICIPIOCODIGO","type":"svchar"},{"av":"A187MunicipioNome","fld":"MUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"A189MunicipioUF","fld":"MUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"AV56ResponsavelEnderecoCompleto","fld":"vRESPONSAVELENDERECOCOMPLETO","type":""}]""");
         setEventMetadata("VRESPONSAVELCEP.CONTROLVALUECHANGED",""","oparms":[{"av":"AV28ResponsavelCEP","fld":"vRESPONSAVELCEP","type":"svchar"},{"av":"AV56ResponsavelEnderecoCompleto","fld":"vRESPONSAVELENDERECOCOMPLETO","type":""},{"av":"AV59EnderecoCompleto","fld":"vENDERECOCOMPLETO","type":""},{"av":"AV33ResponsavelEnderecoBairro","fld":"vRESPONSAVELENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"AV34ResponsavelEnderecoCidade","fld":"vRESPONSAVELENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"AV30ResponsavelEnderecoLogradouro","fld":"vRESPONSAVELENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"AV35ResponsavelMunicipioCodigo","fld":"vRESPONSAVELMUNICIPIOCODIGO","type":"svchar"},{"av":"AV36ResponsavelMunicipioNome","fld":"vRESPONSAVELMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV37ResponsavelMunicipioUF","fld":"vRESPONSAVELMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"edtavResponsavelenderecobairro_Enabled","ctrl":"vRESPONSAVELENDERECOBAIRRO","prop":"Enabled"},{"av":"edtavResponsavelenderecocidade_Enabled","ctrl":"vRESPONSAVELENDERECOCIDADE","prop":"Enabled"},{"av":"edtavResponsavelenderecologradouro_Enabled","ctrl":"vRESPONSAVELENDERECOLOGRADOURO","prop":"Enabled"},{"av":"AV38CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VALIDV_RESPONSAVELCLIENTEDOCUMENTO","""{"handler":"Validv_Responsavelclientedocumento","iparms":[]}""");
         setEventMetadata("VALIDV_RESPONSAVELCLIENTEESTADOCIVIL","""{"handler":"Validv_Responsavelclienteestadocivil","iparms":[]}""");
         setEventMetadata("VALIDV_RESPONSAVELCONTATOEMAIL","""{"handler":"Validv_Responsavelcontatoemail","iparms":[]}""");
         setEventMetadata("VALIDV_RESPONSAVELCLIENTETIPOPESSOA","""{"handler":"Validv_Responsavelclientetipopessoa","iparms":[]}""");
         setEventMetadata("VALIDV_RESPONSAVELMUNICIPIOCODIGO","""{"handler":"Validv_Responsavelmunicipiocodigo","iparms":[]}""");
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
         Combo_responsavelclientenacionalidade_Ddointernalname = "";
         Combo_responsavelclienteprofissao_Ddointernalname = "";
         Combo_responsavelclienteprofissao_Selectedvalue_get = "";
         Combo_responsavelclientenacionalidade_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV39ResponsavelClienteNacionalidade_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV42ResponsavelClienteProfissao_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV47ResponsavelClienteNomeFantasia = "";
         AV49ResponsavelEnderecoTipo = "";
         AV11WizardData = new SdtWpNovaPropostaData(context);
         A441ProfissaoNome = "";
         A169ClienteDocumento = "";
         A170ClienteRazaoSocial = "";
         A171ClienteNomeFantasia = "";
         A172ClienteTipoPessoa = "";
         A193TipoClienteDescricao = "";
         A141SecUserName = "";
         A181EnderecoTipo = "";
         A182EnderecoCEP = "";
         A183EnderecoLogradouro = "";
         A184EnderecoBairro = "";
         A185EnderecoCidade = "";
         A186MunicipioCodigo = "";
         A187MunicipioNome = "";
         A189MunicipioUF = "";
         A190EnderecoNumero = "";
         A191EnderecoComplemento = "";
         A201ContatoEmail = "";
         A459ClienteDataNascimento = DateTime.MinValue;
         A486ClienteEstadoCivil = "";
         AV59EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         AV56ResponsavelEnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         AV12ResponsavelClienteDocumento = "";
         AV16ResponsavelClienteDataNascimento = DateTime.MinValue;
         AV17ResponsavelClienteRazaoSocial = "";
         lblTextblockcombo_responsavelclientenacionalidade_Jsonclick = "";
         ucCombo_responsavelclientenacionalidade = new GXUserControl();
         Combo_responsavelclientenacionalidade_Caption = "";
         AV20ResponsavelClienteEstadoCivil = "";
         lblTextblockcombo_responsavelclienteprofissao_Jsonclick = "";
         ucCombo_responsavelclienteprofissao = new GXUserControl();
         Combo_responsavelclienteprofissao_Caption = "";
         AV28ResponsavelCEP = "";
         AV30ResponsavelEnderecoLogradouro = "";
         AV31ResponsavelEnderecoNumero = "";
         AV32ResponsavelEnderecoComplemento = "";
         AV33ResponsavelEnderecoBairro = "";
         AV34ResponsavelEnderecoCidade = "";
         AV36ResponsavelMunicipioNome = "";
         AV37ResponsavelMunicipioUF = "";
         AV23ResponsavelContatoEmail = "";
         lblTextblockresponsavelcontatoddd_Jsonclick = "";
         lblTextblockresponsavelcontatotelefoneddd_Jsonclick = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         AV13ResponsavelClienteTipoPessoa = "";
         AV29ResponsavelEnderecoCEP = "";
         AV35ResponsavelMunicipioCodigo = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV45ClienteTipoPessoa = "";
         H006P2_A219TipoClienteFinancia = new bool[] {false} ;
         H006P2_n219TipoClienteFinancia = new bool[] {false} ;
         H006P2_A192TipoClienteId = new short[1] ;
         H006P2_n192TipoClienteId = new bool[] {false} ;
         AV46ClienteBC = new SdtCliente(context);
         AV52ClienteResponsavel = new SdtClienteReponsavel(context);
         AV40ComboSelectedValue = "";
         AV43Session = context.GetSession();
         Combo_responsavelclienteprofissao_Selectedvalue_set = "";
         AV5WebSession = context.GetSession();
         H006P3_A440ProfissaoId = new int[1] ;
         H006P3_A441ProfissaoNome = new string[] {""} ;
         H006P3_n441ProfissaoNome = new bool[] {false} ;
         AV41Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H006P4_A434NacionalidadeId = new int[1] ;
         H006P4_A435NacionalidadeNome = new string[] {""} ;
         H006P4_n435NacionalidadeNome = new bool[] {false} ;
         A435NacionalidadeNome = "";
         Combo_responsavelclientenacionalidade_Selectedvalue_set = "";
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         GXt_char1 = "";
         H006P5_A457EspecialidadeId = new int[1] ;
         H006P5_n457EspecialidadeId = new bool[] {false} ;
         H006P5_A597EspecialidadeCreatedBy = new short[1] ;
         H006P5_n597EspecialidadeCreatedBy = new bool[] {false} ;
         H006P5_A169ClienteDocumento = new string[] {""} ;
         H006P5_n169ClienteDocumento = new bool[] {false} ;
         H006P5_A170ClienteRazaoSocial = new string[] {""} ;
         H006P5_n170ClienteRazaoSocial = new bool[] {false} ;
         H006P5_A171ClienteNomeFantasia = new string[] {""} ;
         H006P5_n171ClienteNomeFantasia = new bool[] {false} ;
         H006P5_A172ClienteTipoPessoa = new string[] {""} ;
         H006P5_n172ClienteTipoPessoa = new bool[] {false} ;
         H006P5_A192TipoClienteId = new short[1] ;
         H006P5_n192TipoClienteId = new bool[] {false} ;
         H006P5_A193TipoClienteDescricao = new string[] {""} ;
         H006P5_n193TipoClienteDescricao = new bool[] {false} ;
         H006P5_A174ClienteStatus = new bool[] {false} ;
         H006P5_n174ClienteStatus = new bool[] {false} ;
         H006P5_A141SecUserName = new string[] {""} ;
         H006P5_n141SecUserName = new bool[] {false} ;
         H006P5_A181EnderecoTipo = new string[] {""} ;
         H006P5_n181EnderecoTipo = new bool[] {false} ;
         H006P5_A182EnderecoCEP = new string[] {""} ;
         H006P5_n182EnderecoCEP = new bool[] {false} ;
         H006P5_A183EnderecoLogradouro = new string[] {""} ;
         H006P5_n183EnderecoLogradouro = new bool[] {false} ;
         H006P5_A184EnderecoBairro = new string[] {""} ;
         H006P5_n184EnderecoBairro = new bool[] {false} ;
         H006P5_A185EnderecoCidade = new string[] {""} ;
         H006P5_n185EnderecoCidade = new bool[] {false} ;
         H006P5_A186MunicipioCodigo = new string[] {""} ;
         H006P5_n186MunicipioCodigo = new bool[] {false} ;
         H006P5_A187MunicipioNome = new string[] {""} ;
         H006P5_n187MunicipioNome = new bool[] {false} ;
         H006P5_A189MunicipioUF = new string[] {""} ;
         H006P5_n189MunicipioUF = new bool[] {false} ;
         H006P5_A190EnderecoNumero = new string[] {""} ;
         H006P5_n190EnderecoNumero = new bool[] {false} ;
         H006P5_A191EnderecoComplemento = new string[] {""} ;
         H006P5_n191EnderecoComplemento = new bool[] {false} ;
         H006P5_A201ContatoEmail = new string[] {""} ;
         H006P5_n201ContatoEmail = new bool[] {false} ;
         H006P5_A198ContatoDDD = new short[1] ;
         H006P5_n198ContatoDDD = new bool[] {false} ;
         H006P5_A199ContatoDDI = new short[1] ;
         H006P5_n199ContatoDDI = new bool[] {false} ;
         H006P5_A200ContatoNumero = new long[1] ;
         H006P5_n200ContatoNumero = new bool[] {false} ;
         H006P5_A202ContatoTelefoneNumero = new long[1] ;
         H006P5_n202ContatoTelefoneNumero = new bool[] {false} ;
         H006P5_A203ContatoTelefoneDDD = new short[1] ;
         H006P5_n203ContatoTelefoneDDD = new bool[] {false} ;
         H006P5_A204ContatoTelefoneDDI = new short[1] ;
         H006P5_n204ContatoTelefoneDDI = new bool[] {false} ;
         H006P5_A459ClienteDataNascimento = new DateTime[] {DateTime.MinValue} ;
         H006P5_n459ClienteDataNascimento = new bool[] {false} ;
         H006P5_A421ClienteRG = new long[1] ;
         H006P5_n421ClienteRG = new bool[] {false} ;
         H006P5_A484ClienteNacionalidade = new int[1] ;
         H006P5_n484ClienteNacionalidade = new bool[] {false} ;
         H006P5_A486ClienteEstadoCivil = new string[] {""} ;
         H006P5_n486ClienteEstadoCivil = new bool[] {false} ;
         H006P5_A487ClienteProfissao = new int[1] ;
         H006P5_n487ClienteProfissao = new bool[] {false} ;
         H006P5_A168ClienteId = new int[1] ;
         AV54ResponsavelTipoClienteDescricao = "";
         AV55ResponsavelSecUserName = "";
         AV57ModeloRetorno = "";
         AV58Mensagem = "";
         H006P6_A186MunicipioCodigo = new string[] {""} ;
         H006P6_n186MunicipioCodigo = new bool[] {false} ;
         H006P6_A187MunicipioNome = new string[] {""} ;
         H006P6_n187MunicipioNome = new bool[] {false} ;
         H006P6_A189MunicipioUF = new string[] {""} ;
         H006P6_n189MunicipioUF = new bool[] {false} ;
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpnovapropostaresponsavel__default(),
            new Object[][] {
                new Object[] {
               H006P2_A219TipoClienteFinancia, H006P2_n219TipoClienteFinancia, H006P2_A192TipoClienteId
               }
               , new Object[] {
               H006P3_A440ProfissaoId, H006P3_A441ProfissaoNome, H006P3_n441ProfissaoNome
               }
               , new Object[] {
               H006P4_A434NacionalidadeId, H006P4_A435NacionalidadeNome, H006P4_n435NacionalidadeNome
               }
               , new Object[] {
               H006P5_A457EspecialidadeId, H006P5_n457EspecialidadeId, H006P5_A597EspecialidadeCreatedBy, H006P5_n597EspecialidadeCreatedBy, H006P5_A169ClienteDocumento, H006P5_n169ClienteDocumento, H006P5_A170ClienteRazaoSocial, H006P5_n170ClienteRazaoSocial, H006P5_A171ClienteNomeFantasia, H006P5_n171ClienteNomeFantasia,
               H006P5_A172ClienteTipoPessoa, H006P5_n172ClienteTipoPessoa, H006P5_A192TipoClienteId, H006P5_n192TipoClienteId, H006P5_A193TipoClienteDescricao, H006P5_n193TipoClienteDescricao, H006P5_A174ClienteStatus, H006P5_n174ClienteStatus, H006P5_A141SecUserName, H006P5_n141SecUserName,
               H006P5_A181EnderecoTipo, H006P5_n181EnderecoTipo, H006P5_A182EnderecoCEP, H006P5_n182EnderecoCEP, H006P5_A183EnderecoLogradouro, H006P5_n183EnderecoLogradouro, H006P5_A184EnderecoBairro, H006P5_n184EnderecoBairro, H006P5_A185EnderecoCidade, H006P5_n185EnderecoCidade,
               H006P5_A186MunicipioCodigo, H006P5_n186MunicipioCodigo, H006P5_A187MunicipioNome, H006P5_n187MunicipioNome, H006P5_A189MunicipioUF, H006P5_n189MunicipioUF, H006P5_A190EnderecoNumero, H006P5_n190EnderecoNumero, H006P5_A191EnderecoComplemento, H006P5_n191EnderecoComplemento,
               H006P5_A201ContatoEmail, H006P5_n201ContatoEmail, H006P5_A198ContatoDDD, H006P5_n198ContatoDDD, H006P5_A199ContatoDDI, H006P5_n199ContatoDDI, H006P5_A200ContatoNumero, H006P5_n200ContatoNumero, H006P5_A202ContatoTelefoneNumero, H006P5_n202ContatoTelefoneNumero,
               H006P5_A203ContatoTelefoneDDD, H006P5_n203ContatoTelefoneDDD, H006P5_A204ContatoTelefoneDDI, H006P5_n204ContatoTelefoneDDI, H006P5_A459ClienteDataNascimento, H006P5_n459ClienteDataNascimento, H006P5_A421ClienteRG, H006P5_n421ClienteRG, H006P5_A484ClienteNacionalidade, H006P5_n484ClienteNacionalidade,
               H006P5_A486ClienteEstadoCivil, H006P5_n486ClienteEstadoCivil, H006P5_A487ClienteProfissao, H006P5_n487ClienteProfissao, H006P5_A168ClienteId
               }
               , new Object[] {
               H006P6_A186MunicipioCodigo, H006P6_A187MunicipioNome, H006P6_n187MunicipioNome, H006P6_A189MunicipioUF, H006P6_n189MunicipioUF
               }
            }
         );
         /* GeneXus formulas. */
         edtavResponsavelmunicipionome_Enabled = 0;
         edtavResponsavelmunicipiouf_Enabled = 0;
      }

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
      private short A133SecUserId ;
      private short AV48ResponsavelSecUserId ;
      private short AV50ResponsavelContatoDDI ;
      private short AV51ResponsavelContatoTelefoneDDI ;
      private short A192TipoClienteId ;
      private short A198ContatoDDD ;
      private short A199ContatoDDI ;
      private short A203ContatoTelefoneDDD ;
      private short A204ContatoTelefoneDDI ;
      private short wbEnd ;
      private short wbStart ;
      private short AV14ResponsavelTipoClienteId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV24ResponsavelContatoDDD ;
      private short AV26ResponsavelContatoTelefoneDDD ;
      private short AV44TipoClienteId ;
      private short gxcookieaux ;
      private short AV60Idade ;
      private short AV64GXLvl319 ;
      private short A597EspecialidadeCreatedBy ;
      private short nGXWrapped ;
      private int edtavResponsavelmunicipionome_Enabled ;
      private int edtavResponsavelmunicipiouf_Enabled ;
      private int A440ProfissaoId ;
      private int A484ClienteNacionalidade ;
      private int A487ClienteProfissao ;
      private int A168ClienteId ;
      private int edtavResponsavelclientedocumento_Enabled ;
      private int edtavResponsavelclientedatanascimento_Enabled ;
      private int edtavResponsavelclienterazaosocial_Enabled ;
      private int edtavResponsavelclienterg_Enabled ;
      private int edtavResponsavelcep_Enabled ;
      private int edtavResponsavelenderecologradouro_Enabled ;
      private int edtavResponsavelendereconumero_Enabled ;
      private int edtavResponsavelenderecocomplemento_Enabled ;
      private int edtavResponsavelenderecobairro_Enabled ;
      private int edtavResponsavelenderecocidade_Enabled ;
      private int edtavResponsavelcontatoemail_Enabled ;
      private int AV19ResponsavelClienteNacionalidade ;
      private int edtavResponsavelclientenacionalidade_Visible ;
      private int AV21ResponsavelClienteProfissao ;
      private int edtavResponsavelclienteprofissao_Visible ;
      private int edtavResponsaveltipoclienteid_Visible ;
      private int edtavResponsaveltipoclienteid_Enabled ;
      private int AV15ResponsavelClienteId ;
      private int edtavResponsavelclienteid_Visible ;
      private int edtavResponsavelenderecocep_Visible ;
      private int edtavResponsavelenderecocep_Enabled ;
      private int edtavResponsavelmunicipiocodigo_Visible ;
      private int edtavResponsavelmunicipiocodigo_Enabled ;
      private int A434NacionalidadeId ;
      private int A457EspecialidadeId ;
      private int edtavResponsavelcontatonumero_Enabled ;
      private int edtavResponsavelcontatotelefonenumero_Enabled ;
      private int edtavResponsavelcontatotelefoneddd_Enabled ;
      private int edtavResponsavelcontatoddd_Enabled ;
      private int idxLst ;
      private long A200ContatoNumero ;
      private long A202ContatoTelefoneNumero ;
      private long A421ClienteRG ;
      private long AV18ResponsavelClienteRG ;
      private long AV25ResponsavelContatoNumero ;
      private long AV27ResponsavelContatoTelefoneNumero ;
      private string Combo_responsavelclientenacionalidade_Ddointernalname ;
      private string Combo_responsavelclienteprofissao_Ddointernalname ;
      private string Combo_responsavelclienteprofissao_Selectedvalue_get ;
      private string Combo_responsavelclientenacionalidade_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavResponsavelmunicipionome_Internalname ;
      private string edtavResponsavelmunicipiouf_Internalname ;
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
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavResponsavelclientedocumento_Internalname ;
      private string TempTags ;
      private string edtavResponsavelclientedocumento_Jsonclick ;
      private string edtavResponsavelclientedatanascimento_Internalname ;
      private string edtavResponsavelclientedatanascimento_Jsonclick ;
      private string edtavResponsavelclienterazaosocial_Internalname ;
      private string edtavResponsavelclienterazaosocial_Jsonclick ;
      private string edtavResponsavelclienterg_Internalname ;
      private string edtavResponsavelclienterg_Jsonclick ;
      private string divTablesplittedresponsavelclientenacionalidade_Internalname ;
      private string lblTextblockcombo_responsavelclientenacionalidade_Internalname ;
      private string lblTextblockcombo_responsavelclientenacionalidade_Jsonclick ;
      private string Combo_responsavelclientenacionalidade_Caption ;
      private string Combo_responsavelclientenacionalidade_Cls ;
      private string Combo_responsavelclientenacionalidade_Internalname ;
      private string cmbavResponsavelclienteestadocivil_Internalname ;
      private string cmbavResponsavelclienteestadocivil_Jsonclick ;
      private string divTablesplittedresponsavelclienteprofissao_Internalname ;
      private string lblTextblockcombo_responsavelclienteprofissao_Internalname ;
      private string lblTextblockcombo_responsavelclienteprofissao_Jsonclick ;
      private string Combo_responsavelclienteprofissao_Caption ;
      private string Combo_responsavelclienteprofissao_Cls ;
      private string Combo_responsavelclienteprofissao_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableendereco_Internalname ;
      private string edtavResponsavelcep_Internalname ;
      private string edtavResponsavelcep_Jsonclick ;
      private string edtavResponsavelenderecologradouro_Internalname ;
      private string edtavResponsavelenderecologradouro_Jsonclick ;
      private string edtavResponsavelendereconumero_Internalname ;
      private string edtavResponsavelendereconumero_Jsonclick ;
      private string edtavResponsavelenderecocomplemento_Internalname ;
      private string edtavResponsavelenderecocomplemento_Jsonclick ;
      private string edtavResponsavelenderecobairro_Internalname ;
      private string edtavResponsavelenderecobairro_Jsonclick ;
      private string edtavResponsavelenderecocidade_Internalname ;
      private string edtavResponsavelenderecocidade_Jsonclick ;
      private string edtavResponsavelmunicipionome_Jsonclick ;
      private string edtavResponsavelmunicipiouf_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTablecontato_Internalname ;
      private string edtavResponsavelcontatoemail_Internalname ;
      private string edtavResponsavelcontatoemail_Jsonclick ;
      private string divTablesplittedresponsavelcontatoddd_Internalname ;
      private string lblTextblockresponsavelcontatoddd_Internalname ;
      private string lblTextblockresponsavelcontatoddd_Jsonclick ;
      private string divTablesplittedresponsavelcontatotelefoneddd_Internalname ;
      private string lblTextblockresponsavelcontatotelefoneddd_Internalname ;
      private string lblTextblockresponsavelcontatotelefoneddd_Jsonclick ;
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
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavResponsavelclientenacionalidade_Internalname ;
      private string edtavResponsavelclientenacionalidade_Jsonclick ;
      private string edtavResponsavelclienteprofissao_Internalname ;
      private string edtavResponsavelclienteprofissao_Jsonclick ;
      private string cmbavResponsavelclientetipopessoa_Internalname ;
      private string cmbavResponsavelclientetipopessoa_Jsonclick ;
      private string edtavResponsaveltipoclienteid_Internalname ;
      private string edtavResponsaveltipoclienteid_Jsonclick ;
      private string edtavResponsavelclienteid_Internalname ;
      private string edtavResponsavelclienteid_Jsonclick ;
      private string cmbavResponsavelclientestatus_Internalname ;
      private string cmbavResponsavelclientestatus_Jsonclick ;
      private string edtavResponsavelenderecocep_Internalname ;
      private string edtavResponsavelenderecocep_Jsonclick ;
      private string edtavResponsavelmunicipiocodigo_Internalname ;
      private string edtavResponsavelmunicipiocodigo_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string edtavResponsavelcontatoddd_Internalname ;
      private string edtavResponsavelcontatonumero_Internalname ;
      private string edtavResponsavelcontatotelefoneddd_Internalname ;
      private string edtavResponsavelcontatotelefonenumero_Internalname ;
      private string Combo_responsavelclienteprofissao_Selectedvalue_set ;
      private string Combo_responsavelclientenacionalidade_Selectedvalue_set ;
      private string GXt_char1 ;
      private string sStyleString ;
      private string tblTablemergedresponsavelcontatotelefoneddd_Internalname ;
      private string edtavResponsavelcontatotelefoneddd_Jsonclick ;
      private string edtavResponsavelcontatotelefonenumero_Jsonclick ;
      private string tblTablemergedresponsavelcontatoddd_Internalname ;
      private string edtavResponsavelcontatoddd_Jsonclick ;
      private string edtavResponsavelcontatonumero_Jsonclick ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private DateTime GXt_dtime2 ;
      private DateTime A459ClienteDataNascimento ;
      private DateTime AV16ResponsavelClienteDataNascimento ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV38CheckRequiredFieldsResult ;
      private bool A174ClienteStatus ;
      private bool wbLoad ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_responsavelclientenacionalidade_Emptyitem ;
      private bool Combo_responsavelclienteprofissao_Emptyitem ;
      private bool Combo_responsavelclienteprofissao_Includeaddnewoption ;
      private bool AV22ResponsavelClienteStatus ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A219TipoClienteFinancia ;
      private bool n219TipoClienteFinancia ;
      private bool n192TipoClienteId ;
      private bool AV53IsCadastrado ;
      private bool n441ProfissaoNome ;
      private bool n435NacionalidadeNome ;
      private bool n457EspecialidadeId ;
      private bool n597EspecialidadeCreatedBy ;
      private bool n169ClienteDocumento ;
      private bool n170ClienteRazaoSocial ;
      private bool n171ClienteNomeFantasia ;
      private bool n172ClienteTipoPessoa ;
      private bool n193TipoClienteDescricao ;
      private bool n174ClienteStatus ;
      private bool n141SecUserName ;
      private bool n181EnderecoTipo ;
      private bool n182EnderecoCEP ;
      private bool n183EnderecoLogradouro ;
      private bool n184EnderecoBairro ;
      private bool n185EnderecoCidade ;
      private bool n186MunicipioCodigo ;
      private bool n187MunicipioNome ;
      private bool n189MunicipioUF ;
      private bool n190EnderecoNumero ;
      private bool n191EnderecoComplemento ;
      private bool n201ContatoEmail ;
      private bool n198ContatoDDD ;
      private bool n199ContatoDDI ;
      private bool n200ContatoNumero ;
      private bool n202ContatoTelefoneNumero ;
      private bool n203ContatoTelefoneDDD ;
      private bool n204ContatoTelefoneDDI ;
      private bool n459ClienteDataNascimento ;
      private bool n421ClienteRG ;
      private bool n484ClienteNacionalidade ;
      private bool n486ClienteEstadoCivil ;
      private bool n487ClienteProfissao ;
      private string AV57ModeloRetorno ;
      private string AV58Mensagem ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV47ResponsavelClienteNomeFantasia ;
      private string AV49ResponsavelEnderecoTipo ;
      private string A441ProfissaoNome ;
      private string A169ClienteDocumento ;
      private string A170ClienteRazaoSocial ;
      private string A171ClienteNomeFantasia ;
      private string A172ClienteTipoPessoa ;
      private string A193TipoClienteDescricao ;
      private string A141SecUserName ;
      private string A181EnderecoTipo ;
      private string A182EnderecoCEP ;
      private string A183EnderecoLogradouro ;
      private string A184EnderecoBairro ;
      private string A185EnderecoCidade ;
      private string A186MunicipioCodigo ;
      private string A187MunicipioNome ;
      private string A189MunicipioUF ;
      private string A190EnderecoNumero ;
      private string A191EnderecoComplemento ;
      private string A201ContatoEmail ;
      private string A486ClienteEstadoCivil ;
      private string AV12ResponsavelClienteDocumento ;
      private string AV17ResponsavelClienteRazaoSocial ;
      private string AV20ResponsavelClienteEstadoCivil ;
      private string AV28ResponsavelCEP ;
      private string AV30ResponsavelEnderecoLogradouro ;
      private string AV31ResponsavelEnderecoNumero ;
      private string AV32ResponsavelEnderecoComplemento ;
      private string AV33ResponsavelEnderecoBairro ;
      private string AV34ResponsavelEnderecoCidade ;
      private string AV36ResponsavelMunicipioNome ;
      private string AV37ResponsavelMunicipioUF ;
      private string AV23ResponsavelContatoEmail ;
      private string AV13ResponsavelClienteTipoPessoa ;
      private string AV29ResponsavelEnderecoCEP ;
      private string AV35ResponsavelMunicipioCodigo ;
      private string AV45ClienteTipoPessoa ;
      private string AV40ComboSelectedValue ;
      private string A435NacionalidadeNome ;
      private string AV54ResponsavelTipoClienteDescricao ;
      private string AV55ResponsavelSecUserName ;
      private IGxSession AV43Session ;
      private IGxSession AV5WebSession ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_responsavelclientenacionalidade ;
      private GXUserControl ucCombo_responsavelclienteprofissao ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavResponsavelclienteestadocivil ;
      private GXCombobox cmbavResponsavelclientetipopessoa ;
      private GXCombobox cmbavResponsavelclientestatus ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV39ResponsavelClienteNacionalidade_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV42ResponsavelClienteProfissao_Data ;
      private SdtWpNovaPropostaData AV11WizardData ;
      private GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto AV59EnderecoCompleto ;
      private GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto AV56ResponsavelEnderecoCompleto ;
      private IDataStoreProvider pr_default ;
      private bool[] H006P2_A219TipoClienteFinancia ;
      private bool[] H006P2_n219TipoClienteFinancia ;
      private short[] H006P2_A192TipoClienteId ;
      private bool[] H006P2_n192TipoClienteId ;
      private SdtCliente AV46ClienteBC ;
      private SdtClienteReponsavel AV52ClienteResponsavel ;
      private int[] H006P3_A440ProfissaoId ;
      private string[] H006P3_A441ProfissaoNome ;
      private bool[] H006P3_n441ProfissaoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV41Combo_DataItem ;
      private int[] H006P4_A434NacionalidadeId ;
      private string[] H006P4_A435NacionalidadeNome ;
      private bool[] H006P4_n435NacionalidadeNome ;
      private int[] H006P5_A457EspecialidadeId ;
      private bool[] H006P5_n457EspecialidadeId ;
      private short[] H006P5_A597EspecialidadeCreatedBy ;
      private bool[] H006P5_n597EspecialidadeCreatedBy ;
      private string[] H006P5_A169ClienteDocumento ;
      private bool[] H006P5_n169ClienteDocumento ;
      private string[] H006P5_A170ClienteRazaoSocial ;
      private bool[] H006P5_n170ClienteRazaoSocial ;
      private string[] H006P5_A171ClienteNomeFantasia ;
      private bool[] H006P5_n171ClienteNomeFantasia ;
      private string[] H006P5_A172ClienteTipoPessoa ;
      private bool[] H006P5_n172ClienteTipoPessoa ;
      private short[] H006P5_A192TipoClienteId ;
      private bool[] H006P5_n192TipoClienteId ;
      private string[] H006P5_A193TipoClienteDescricao ;
      private bool[] H006P5_n193TipoClienteDescricao ;
      private bool[] H006P5_A174ClienteStatus ;
      private bool[] H006P5_n174ClienteStatus ;
      private string[] H006P5_A141SecUserName ;
      private bool[] H006P5_n141SecUserName ;
      private string[] H006P5_A181EnderecoTipo ;
      private bool[] H006P5_n181EnderecoTipo ;
      private string[] H006P5_A182EnderecoCEP ;
      private bool[] H006P5_n182EnderecoCEP ;
      private string[] H006P5_A183EnderecoLogradouro ;
      private bool[] H006P5_n183EnderecoLogradouro ;
      private string[] H006P5_A184EnderecoBairro ;
      private bool[] H006P5_n184EnderecoBairro ;
      private string[] H006P5_A185EnderecoCidade ;
      private bool[] H006P5_n185EnderecoCidade ;
      private string[] H006P5_A186MunicipioCodigo ;
      private bool[] H006P5_n186MunicipioCodigo ;
      private string[] H006P5_A187MunicipioNome ;
      private bool[] H006P5_n187MunicipioNome ;
      private string[] H006P5_A189MunicipioUF ;
      private bool[] H006P5_n189MunicipioUF ;
      private string[] H006P5_A190EnderecoNumero ;
      private bool[] H006P5_n190EnderecoNumero ;
      private string[] H006P5_A191EnderecoComplemento ;
      private bool[] H006P5_n191EnderecoComplemento ;
      private string[] H006P5_A201ContatoEmail ;
      private bool[] H006P5_n201ContatoEmail ;
      private short[] H006P5_A198ContatoDDD ;
      private bool[] H006P5_n198ContatoDDD ;
      private short[] H006P5_A199ContatoDDI ;
      private bool[] H006P5_n199ContatoDDI ;
      private long[] H006P5_A200ContatoNumero ;
      private bool[] H006P5_n200ContatoNumero ;
      private long[] H006P5_A202ContatoTelefoneNumero ;
      private bool[] H006P5_n202ContatoTelefoneNumero ;
      private short[] H006P5_A203ContatoTelefoneDDD ;
      private bool[] H006P5_n203ContatoTelefoneDDD ;
      private short[] H006P5_A204ContatoTelefoneDDI ;
      private bool[] H006P5_n204ContatoTelefoneDDI ;
      private DateTime[] H006P5_A459ClienteDataNascimento ;
      private bool[] H006P5_n459ClienteDataNascimento ;
      private long[] H006P5_A421ClienteRG ;
      private bool[] H006P5_n421ClienteRG ;
      private int[] H006P5_A484ClienteNacionalidade ;
      private bool[] H006P5_n484ClienteNacionalidade ;
      private string[] H006P5_A486ClienteEstadoCivil ;
      private bool[] H006P5_n486ClienteEstadoCivil ;
      private int[] H006P5_A487ClienteProfissao ;
      private bool[] H006P5_n487ClienteProfissao ;
      private int[] H006P5_A168ClienteId ;
      private string[] H006P6_A186MunicipioCodigo ;
      private bool[] H006P6_n186MunicipioCodigo ;
      private string[] H006P6_A187MunicipioNome ;
      private bool[] H006P6_n187MunicipioNome ;
      private string[] H006P6_A189MunicipioUF ;
      private bool[] H006P6_n189MunicipioUF ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpnovapropostaresponsavel__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH006P2;
          prmH006P2 = new Object[] {
          };
          Object[] prmH006P3;
          prmH006P3 = new Object[] {
          };
          Object[] prmH006P4;
          prmH006P4 = new Object[] {
          };
          Object[] prmH006P5;
          prmH006P5 = new Object[] {
          new ParDef("AV12ResponsavelClienteDocumento",GXType.VarChar,20,0)
          };
          Object[] prmH006P6;
          prmH006P6 = new Object[] {
          new ParDef("AV35ResponsavelMunicipioCodigo",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006P2", "SELECT TipoClienteFinancia, TipoClienteId FROM TipoCliente WHERE TipoClienteFinancia ORDER BY TipoClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006P2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006P3", "SELECT ProfissaoId, ProfissaoNome FROM Profissao ORDER BY ProfissaoNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006P3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006P4", "SELECT NacionalidadeId, NacionalidadeNome FROM Nacionalidade ORDER BY NacionalidadeNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006P4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006P5", "SELECT T1.EspecialidadeId, T2.EspecialidadeCreatedBy AS EspecialidadeCreatedBy, T1.ClienteDocumento, T1.ClienteRazaoSocial, T1.ClienteNomeFantasia, T1.ClienteTipoPessoa, T1.TipoClienteId, T4.TipoClienteDescricao, T1.ClienteStatus, T3.SecUserName, T1.EnderecoTipo, T1.EnderecoCEP, T1.EnderecoLogradouro, T1.EnderecoBairro, T1.EnderecoCidade, T1.MunicipioCodigo, T5.MunicipioNome, T5.MunicipioUF, T1.EnderecoNumero, T1.EnderecoComplemento, T1.ContatoEmail, T1.ContatoDDD, T1.ContatoDDI, T1.ContatoNumero, T1.ContatoTelefoneNumero, T1.ContatoTelefoneDDD, T1.ContatoTelefoneDDI, T1.ClienteDataNascimento, T1.ClienteRG, T1.ClienteNacionalidade, T1.ClienteEstadoCivil, T1.ClienteProfissao, T1.ClienteId FROM ((((Cliente T1 LEFT JOIN Especialidade T2 ON T2.EspecialidadeId = T1.EspecialidadeId) LEFT JOIN SecUser T3 ON T3.SecUserId = T2.EspecialidadeCreatedBy) LEFT JOIN TipoCliente T4 ON T4.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T5 ON T5.MunicipioCodigo = T1.MunicipioCodigo) WHERE T1.ClienteDocumento = ( :AV12ResponsavelClienteDocumento) ORDER BY T1.ClienteDocumento ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006P5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H006P6", "SELECT MunicipioCodigo, MunicipioNome, MunicipioUF FROM Municipio WHERE MunicipioCodigo = ( :AV35ResponsavelMunicipioCodigo) ORDER BY MunicipioCodigo ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006P6,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[2])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((bool[]) buf[16])[0] = rslt.getBool(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getVarchar(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getVarchar(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((short[]) buf[42])[0] = rslt.getShort(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((short[]) buf[44])[0] = rslt.getShort(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((long[]) buf[46])[0] = rslt.getLong(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((long[]) buf[48])[0] = rslt.getLong(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((short[]) buf[50])[0] = rslt.getShort(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((short[]) buf[52])[0] = rslt.getShort(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((DateTime[]) buf[54])[0] = rslt.getGXDate(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((long[]) buf[56])[0] = rslt.getLong(29);
                ((bool[]) buf[57])[0] = rslt.wasNull(29);
                ((int[]) buf[58])[0] = rslt.getInt(30);
                ((bool[]) buf[59])[0] = rslt.wasNull(30);
                ((string[]) buf[60])[0] = rslt.getVarchar(31);
                ((bool[]) buf[61])[0] = rslt.wasNull(31);
                ((int[]) buf[62])[0] = rslt.getInt(32);
                ((bool[]) buf[63])[0] = rslt.wasNull(32);
                ((int[]) buf[64])[0] = rslt.getInt(33);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
