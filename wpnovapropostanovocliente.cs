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
   public class wpnovapropostanovocliente : GXWebComponent
   {
      public wpnovapropostanovocliente( )
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

      public wpnovapropostanovocliente( IGxContext context )
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
         cmbavClienteestadocivil = new GXCombobox();
         cmbavPossuiresponsavel = new GXCombobox();
         cmbavClientetipopessoa = new GXCombobox();
         cmbavClientestatus = new GXCombobox();
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
            PA5M2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavMunicipionome_Enabled = 0;
               AssignProp(sPrefix, false, edtavMunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipionome_Enabled), 5, 0), true);
               edtavMunicipiouf_Enabled = 0;
               AssignProp(sPrefix, false, edtavMunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiouf_Enabled), 5, 0), true);
               WS5M2( ) ;
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
            context.SendWebValue( "Wp Nova Proposta Novo Cliente") ;
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
            GXEncryptionTmp = "wpnovapropostanovocliente"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpnovapropostanovocliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLIENTENACIONALIDADE_DATA", AV54ClienteNacionalidade_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLIENTENACIONALIDADE_DATA", AV54ClienteNacionalidade_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLIENTEPROFISSAO_DATA", AV55ClienteProfissao_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLIENTEPROFISSAO_DATA", AV55ClienteProfissao_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vENDERECOTIPO", AV22EnderecoTipo);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCONTATODDI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38ContatoDDI), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCONTATOTELEFONEDDI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ContatoTelefoneDDI), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV42CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLIENTEBC", AV12ClienteBC);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLIENTEBC", AV12ClienteBC);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORIGINALPOSSUIRESPONSAVEL", AV61OriginalPossuiResponsavel);
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vENDERECOCOMPLETO", AV48EnderecoCompleto);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vENDERECOCOMPLETO", AV48EnderecoCompleto);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_CLIENTENACIONALIDADE_Ddointernalname", StringUtil.RTrim( Combo_clientenacionalidade_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_CLIENTEPROFISSAO_Ddointernalname", StringUtil.RTrim( Combo_clienteprofissao_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_CLIENTEPROFISSAO_Selectedvalue_get", StringUtil.RTrim( Combo_clienteprofissao_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_CLIENTENACIONALIDADE_Selectedvalue_get", StringUtil.RTrim( Combo_clientenacionalidade_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_CLIENTENACIONALIDADE_Ddointernalname", StringUtil.RTrim( Combo_clientenacionalidade_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_CLIENTEPROFISSAO_Ddointernalname", StringUtil.RTrim( Combo_clienteprofissao_Ddointernalname));
      }

      protected void RenderHtmlCloseForm5M2( )
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
         return "WpNovaPropostaNovoCliente" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wp Nova Proposta Novo Cliente" ;
      }

      protected void WB5M0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpnovapropostanovocliente");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento_Internalname, "Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento_Internalname, AV13ClienteDocumento, StringUtil.RTrim( context.localUtil.Format( AV13ClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "CPF", edtavClientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientedocumento_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientedatanascimento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedatanascimento_Internalname, "Data Nascimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavClientedatanascimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavClientedatanascimento_Internalname, context.localUtil.Format(AV58ClienteDataNascimento, "99/99/9999"), context.localUtil.Format( AV58ClienteDataNascimento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedatanascimento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientedatanascimento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_bitmap( context, edtavClientedatanascimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavClientedatanascimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpNovaPropostaNovoCliente.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV14ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV14ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterg_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterg_Internalname, "RG", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterg_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57ClienteRG), 12, 0, ",", "")), StringUtil.LTrim( ((edtavClienterg_Enabled!=0) ? context.localUtil.Format( (decimal)(AV57ClienteRG), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV57ClienteRG), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterg_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterg_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedclientenacionalidade_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_clientenacionalidade_Internalname, "Nacionalidade", "", "", lblTextblockcombo_clientenacionalidade_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_clientenacionalidade.SetProperty("Caption", Combo_clientenacionalidade_Caption);
            ucCombo_clientenacionalidade.SetProperty("Cls", Combo_clientenacionalidade_Cls);
            ucCombo_clientenacionalidade.SetProperty("EmptyItem", Combo_clientenacionalidade_Emptyitem);
            ucCombo_clientenacionalidade.SetProperty("DropDownOptionsData", AV54ClienteNacionalidade_Data);
            ucCombo_clientenacionalidade.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_clientenacionalidade_Internalname, sPrefix+"COMBO_CLIENTENACIONALIDADEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavClienteestadocivil_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavClienteestadocivil_Internalname, "Estado civil", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClienteestadocivil, cmbavClienteestadocivil_Internalname, StringUtil.RTrim( AV52ClienteEstadoCivil), 1, cmbavClienteestadocivil_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavClienteestadocivil.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_WpNovaPropostaNovoCliente.htm");
            cmbavClienteestadocivil.CurrentValue = StringUtil.RTrim( AV52ClienteEstadoCivil);
            AssignProp(sPrefix, false, cmbavClienteestadocivil_Internalname, "Values", (string)(cmbavClienteestadocivil.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedclienteprofissao_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_clienteprofissao_Internalname, "Profissão", "", "", lblTextblockcombo_clienteprofissao_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_clienteprofissao.SetProperty("Caption", Combo_clienteprofissao_Caption);
            ucCombo_clienteprofissao.SetProperty("Cls", Combo_clienteprofissao_Cls);
            ucCombo_clienteprofissao.SetProperty("EmptyItem", Combo_clienteprofissao_Emptyitem);
            ucCombo_clienteprofissao.SetProperty("DropDownOptionsData", AV55ClienteProfissao_Data);
            ucCombo_clienteprofissao.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_clienteprofissao_Internalname, sPrefix+"COMBO_CLIENTEPROFISSAOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavPossuiresponsavel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPossuiresponsavel_Internalname, "Possui responsável?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPossuiresponsavel, cmbavPossuiresponsavel_Internalname, StringUtil.BoolToStr( AV59PossuiResponsavel), 1, cmbavPossuiresponsavel_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavPossuiresponsavel.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "", true, 0, "HLP_WpNovaPropostaNovoCliente.htm");
            cmbavPossuiresponsavel.CurrentValue = StringUtil.BoolToStr( AV59PossuiResponsavel);
            AssignProp(sPrefix, false, cmbavPossuiresponsavel_Internalname, "Values", (string)(cmbavPossuiresponsavel.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenomefantasia_Internalname, divTablenomefantasia_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientenomefantasia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenomefantasia_Internalname, "Nome fantasia", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenomefantasia_Internalname, AV15ClienteNomeFantasia, StringUtil.RTrim( context.localUtil.Format( AV15ClienteNomeFantasia, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,65);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenomefantasia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientenomefantasia_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Endereço", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovaPropostaNovoCliente.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCep_Internalname, AV41CEP, StringUtil.RTrim( context.localUtil.Format( AV41CEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCep_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCep_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnderecologradouro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnderecologradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecologradouro_Internalname, AV24EnderecoLogradouro, StringUtil.RTrim( context.localUtil.Format( AV24EnderecoLogradouro, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,78);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecologradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEnderecologradouro_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEndereconumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEndereconumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEndereconumero_Internalname, AV30EnderecoNumero, StringUtil.RTrim( context.localUtil.Format( AV30EnderecoNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEndereconumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEndereconumero_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnderecocomplemento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnderecocomplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecocomplemento_Internalname, AV31EnderecoComplemento, StringUtil.RTrim( context.localUtil.Format( AV31EnderecoComplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecocomplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEnderecocomplemento_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnderecobairro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnderecobairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecobairro_Internalname, AV25EnderecoBairro, StringUtil.RTrim( context.localUtil.Format( AV25EnderecoBairro, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,91);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecobairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEnderecobairro_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnderecocidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnderecocidade_Internalname, "Cidade", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecocidade_Internalname, AV26EnderecoCidade, StringUtil.RTrim( context.localUtil.Format( AV26EnderecoCidade, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,95);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecocidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEnderecocidade_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMunicipionome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome_Internalname, "Município", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome_Internalname, AV28MunicipioNome, StringUtil.RTrim( context.localUtil.Format( AV28MunicipioNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,100);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMunicipionome_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipiouf_Internalname, AV29MunicipioUF, StringUtil.RTrim( context.localUtil.Format( AV29MunicipioUF, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,104);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipiouf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMunicipiouf_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Contato", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovaPropostaNovoCliente.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontato_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatoemail_Internalname, AV33ContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV33ContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatoemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcontatoddd_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcontatoddd_Internalname, "Celular", "", "", lblTextblockcontatoddd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_121_5M2( true) ;
         }
         else
         {
            wb_table1_121_5M2( false) ;
         }
         return  ;
      }

      protected void wb_table1_121_5M2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTablesplittedcontatotelefoneddd_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcontatotelefoneddd_Internalname, "Telefone", "", "", lblTextblockcontatotelefoneddd_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table2_135_5M2( true) ;
         }
         else
         {
            wb_table2_135_5M2( false) ;
         }
         return  ;
      }

      protected void wb_table2_135_5M2e( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenacionalidade_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51ClienteNacionalidade), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV51ClienteNacionalidade), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,153);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenacionalidade_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientenacionalidade_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaNovoCliente.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteprofissao_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53ClienteProfissao), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV53ClienteProfissao), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,154);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteprofissao_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteprofissao_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaNovoCliente.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClientetipopessoa, cmbavClientetipopessoa_Internalname, StringUtil.RTrim( AV16ClienteTipoPessoa), 1, cmbavClientetipopessoa_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavClientetipopessoa.Visible, cmbavClientetipopessoa.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,155);\"", "", true, 0, "HLP_WpNovaPropostaNovoCliente.htm");
            cmbavClientetipopessoa.CurrentValue = StringUtil.RTrim( AV16ClienteTipoPessoa);
            AssignProp(sPrefix, false, cmbavClientetipopessoa_Internalname, "Values", (string)(cmbavClientetipopessoa.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17TipoClienteId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17TipoClienteId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,156);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclienteid_Visible, edtavTipoclienteid_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaNovoCliente.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39ClienteId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39ClienteId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,157);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaNovoCliente.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClientestatus, cmbavClientestatus_Internalname, StringUtil.BoolToStr( AV19ClienteStatus), 1, cmbavClientestatus_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavClientestatus.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,158);\"", "", true, 0, "HLP_WpNovaPropostaNovoCliente.htm");
            cmbavClientestatus.CurrentValue = StringUtil.BoolToStr( AV19ClienteStatus);
            AssignProp(sPrefix, false, cmbavClientestatus_Internalname, "Values", (string)(cmbavClientestatus.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecocep_Internalname, AV23EnderecoCEP, StringUtil.RTrim( context.localUtil.Format( AV23EnderecoCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecocep_Jsonclick, 0, "Attribute", "", "", "", "", edtavEnderecocep_Visible, edtavEnderecocep_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipiocodigo_Internalname, AV27MunicipioCodigo, StringUtil.RTrim( context.localUtil.Format( AV27MunicipioCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,160);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipiocodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipiocodigo_Visible, edtavMunicipiocodigo_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5M2( )
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
            Form.Meta.addItem("description", "Wp Nova Proposta Novo Cliente", 0) ;
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
               STRUP5M0( ) ;
            }
         }
      }

      protected void WS5M2( )
      {
         START5M2( ) ;
         EVT5M2( ) ;
      }

      protected void EVT5M2( )
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
                                 STRUP5M0( ) ;
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
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E115M2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
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
                                          E125M2 ();
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
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E135M2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCLIENTEDATANASCIMENTO.ISVALID") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E145M2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCLIENTEDOCUMENTO.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E155M2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCEP.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E165M2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E175M2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavClientedocumento_Internalname;
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

      protected void WE5M2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm5M2( ) ;
            }
         }
      }

      protected void PA5M2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpnovapropostanovocliente")), "wpnovapropostanovocliente") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpnovapropostanovocliente")))) ;
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
               GX_FocusControl = edtavClientedocumento_Internalname;
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
         if ( cmbavClienteestadocivil.ItemCount > 0 )
         {
            AV52ClienteEstadoCivil = cmbavClienteestadocivil.getValidValue(AV52ClienteEstadoCivil);
            AssignAttri(sPrefix, false, "AV52ClienteEstadoCivil", AV52ClienteEstadoCivil);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClienteestadocivil.CurrentValue = StringUtil.RTrim( AV52ClienteEstadoCivil);
            AssignProp(sPrefix, false, cmbavClienteestadocivil_Internalname, "Values", cmbavClienteestadocivil.ToJavascriptSource(), true);
         }
         if ( cmbavPossuiresponsavel.ItemCount > 0 )
         {
            AV59PossuiResponsavel = StringUtil.StrToBool( cmbavPossuiresponsavel.getValidValue(StringUtil.BoolToStr( AV59PossuiResponsavel)));
            AssignAttri(sPrefix, false, "AV59PossuiResponsavel", AV59PossuiResponsavel);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPossuiresponsavel.CurrentValue = StringUtil.BoolToStr( AV59PossuiResponsavel);
            AssignProp(sPrefix, false, cmbavPossuiresponsavel_Internalname, "Values", cmbavPossuiresponsavel.ToJavascriptSource(), true);
         }
         if ( cmbavClientetipopessoa.ItemCount > 0 )
         {
            AV16ClienteTipoPessoa = cmbavClientetipopessoa.getValidValue(AV16ClienteTipoPessoa);
            AssignAttri(sPrefix, false, "AV16ClienteTipoPessoa", AV16ClienteTipoPessoa);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClientetipopessoa.CurrentValue = StringUtil.RTrim( AV16ClienteTipoPessoa);
            AssignProp(sPrefix, false, cmbavClientetipopessoa_Internalname, "Values", cmbavClientetipopessoa.ToJavascriptSource(), true);
         }
         if ( cmbavClientestatus.ItemCount > 0 )
         {
            AV19ClienteStatus = StringUtil.StrToBool( cmbavClientestatus.getValidValue(StringUtil.BoolToStr( AV19ClienteStatus)));
            AssignAttri(sPrefix, false, "AV19ClienteStatus", AV19ClienteStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClientestatus.CurrentValue = StringUtil.BoolToStr( AV19ClienteStatus);
            AssignProp(sPrefix, false, cmbavClientestatus_Internalname, "Values", cmbavClientestatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavMunicipionome_Enabled = 0;
         AssignProp(sPrefix, false, edtavMunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipionome_Enabled), 5, 0), true);
         edtavMunicipiouf_Enabled = 0;
         AssignProp(sPrefix, false, edtavMunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiouf_Enabled), 5, 0), true);
      }

      protected void RF5M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E175M2 ();
            WB5M0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5M2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SECUSERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         edtavMunicipionome_Enabled = 0;
         AssignProp(sPrefix, false, edtavMunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipionome_Enabled), 5, 0), true);
         edtavMunicipiouf_Enabled = 0;
         AssignProp(sPrefix, false, edtavMunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiouf_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115M2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCLIENTENACIONALIDADE_DATA"), AV54ClienteNacionalidade_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCLIENTEPROFISSAO_DATA"), AV55ClienteProfissao_Data);
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            AV61OriginalPossuiResponsavel = StringUtil.StrToBool( cgiGet( sPrefix+"vORIGINALPOSSUIRESPONSAVEL"));
            Combo_clientenacionalidade_Ddointernalname = cgiGet( sPrefix+"COMBO_CLIENTENACIONALIDADE_Ddointernalname");
            Combo_clienteprofissao_Ddointernalname = cgiGet( sPrefix+"COMBO_CLIENTEPROFISSAO_Ddointernalname");
            /* Read variables values. */
            AV13ClienteDocumento = cgiGet( edtavClientedocumento_Internalname);
            AssignAttri(sPrefix, false, "AV13ClienteDocumento", AV13ClienteDocumento);
            if ( context.localUtil.VCDate( cgiGet( edtavClientedatanascimento_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Cliente Data Nascimento"}), 1, "vCLIENTEDATANASCIMENTO");
               GX_FocusControl = edtavClientedatanascimento_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV58ClienteDataNascimento = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV58ClienteDataNascimento", context.localUtil.Format(AV58ClienteDataNascimento, "99/99/9999"));
            }
            else
            {
               AV58ClienteDataNascimento = context.localUtil.CToD( cgiGet( edtavClientedatanascimento_Internalname), 2);
               AssignAttri(sPrefix, false, "AV58ClienteDataNascimento", context.localUtil.Format(AV58ClienteDataNascimento, "99/99/9999"));
            }
            AV14ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AssignAttri(sPrefix, false, "AV14ClienteRazaoSocial", AV14ClienteRazaoSocial);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavClienterg_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavClienterg_Internalname), ",", ".") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCLIENTERG");
               GX_FocusControl = edtavClienterg_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV57ClienteRG = 0;
               AssignAttri(sPrefix, false, "AV57ClienteRG", StringUtil.LTrimStr( (decimal)(AV57ClienteRG), 12, 0));
            }
            else
            {
               AV57ClienteRG = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavClienterg_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV57ClienteRG", StringUtil.LTrimStr( (decimal)(AV57ClienteRG), 12, 0));
            }
            cmbavClienteestadocivil.CurrentValue = cgiGet( cmbavClienteestadocivil_Internalname);
            AV52ClienteEstadoCivil = cgiGet( cmbavClienteestadocivil_Internalname);
            AssignAttri(sPrefix, false, "AV52ClienteEstadoCivil", AV52ClienteEstadoCivil);
            cmbavPossuiresponsavel.CurrentValue = cgiGet( cmbavPossuiresponsavel_Internalname);
            AV59PossuiResponsavel = StringUtil.StrToBool( cgiGet( cmbavPossuiresponsavel_Internalname));
            AssignAttri(sPrefix, false, "AV59PossuiResponsavel", AV59PossuiResponsavel);
            AV15ClienteNomeFantasia = StringUtil.Upper( cgiGet( edtavClientenomefantasia_Internalname));
            AssignAttri(sPrefix, false, "AV15ClienteNomeFantasia", AV15ClienteNomeFantasia);
            AV41CEP = cgiGet( edtavCep_Internalname);
            AssignAttri(sPrefix, false, "AV41CEP", AV41CEP);
            AV24EnderecoLogradouro = StringUtil.Upper( cgiGet( edtavEnderecologradouro_Internalname));
            AssignAttri(sPrefix, false, "AV24EnderecoLogradouro", AV24EnderecoLogradouro);
            AV30EnderecoNumero = cgiGet( edtavEndereconumero_Internalname);
            AssignAttri(sPrefix, false, "AV30EnderecoNumero", AV30EnderecoNumero);
            AV31EnderecoComplemento = cgiGet( edtavEnderecocomplemento_Internalname);
            AssignAttri(sPrefix, false, "AV31EnderecoComplemento", AV31EnderecoComplemento);
            AV25EnderecoBairro = StringUtil.Upper( cgiGet( edtavEnderecobairro_Internalname));
            AssignAttri(sPrefix, false, "AV25EnderecoBairro", AV25EnderecoBairro);
            AV26EnderecoCidade = StringUtil.Upper( cgiGet( edtavEnderecocidade_Internalname));
            AssignAttri(sPrefix, false, "AV26EnderecoCidade", AV26EnderecoCidade);
            AV28MunicipioNome = StringUtil.Upper( cgiGet( edtavMunicipionome_Internalname));
            AssignAttri(sPrefix, false, "AV28MunicipioNome", AV28MunicipioNome);
            AV29MunicipioUF = StringUtil.Upper( cgiGet( edtavMunicipiouf_Internalname));
            AssignAttri(sPrefix, false, "AV29MunicipioUF", AV29MunicipioUF);
            AV33ContatoEmail = cgiGet( edtavContatoemail_Internalname);
            AssignAttri(sPrefix, false, "AV33ContatoEmail", AV33ContatoEmail);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContatoddd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContatoddd_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTATODDD");
               GX_FocusControl = edtavContatoddd_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV32ContatoDDD = 0;
               AssignAttri(sPrefix, false, "AV32ContatoDDD", StringUtil.LTrimStr( (decimal)(AV32ContatoDDD), 4, 0));
            }
            else
            {
               AV32ContatoDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavContatoddd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV32ContatoDDD", StringUtil.LTrimStr( (decimal)(AV32ContatoDDD), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContatonumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContatonumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTATONUMERO");
               GX_FocusControl = edtavContatonumero_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34ContatoNumero = 0;
               AssignAttri(sPrefix, false, "AV34ContatoNumero", StringUtil.LTrimStr( (decimal)(AV34ContatoNumero), 18, 0));
            }
            else
            {
               AV34ContatoNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavContatonumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV34ContatoNumero", StringUtil.LTrimStr( (decimal)(AV34ContatoNumero), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContatotelefoneddd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContatotelefoneddd_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTATOTELEFONEDDD");
               GX_FocusControl = edtavContatotelefoneddd_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV36ContatoTelefoneDDD = 0;
               AssignAttri(sPrefix, false, "AV36ContatoTelefoneDDD", StringUtil.LTrimStr( (decimal)(AV36ContatoTelefoneDDD), 4, 0));
            }
            else
            {
               AV36ContatoTelefoneDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavContatotelefoneddd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV36ContatoTelefoneDDD", StringUtil.LTrimStr( (decimal)(AV36ContatoTelefoneDDD), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContatotelefonenumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContatotelefonenumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTATOTELEFONENUMERO");
               GX_FocusControl = edtavContatotelefonenumero_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV35ContatoTelefoneNumero = 0;
               AssignAttri(sPrefix, false, "AV35ContatoTelefoneNumero", StringUtil.LTrimStr( (decimal)(AV35ContatoTelefoneNumero), 18, 0));
            }
            else
            {
               AV35ContatoTelefoneNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavContatotelefonenumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV35ContatoTelefoneNumero", StringUtil.LTrimStr( (decimal)(AV35ContatoTelefoneNumero), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavClientenacionalidade_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavClientenacionalidade_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCLIENTENACIONALIDADE");
               GX_FocusControl = edtavClientenacionalidade_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV51ClienteNacionalidade = 0;
               AssignAttri(sPrefix, false, "AV51ClienteNacionalidade", StringUtil.LTrimStr( (decimal)(AV51ClienteNacionalidade), 9, 0));
            }
            else
            {
               AV51ClienteNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavClientenacionalidade_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV51ClienteNacionalidade", StringUtil.LTrimStr( (decimal)(AV51ClienteNacionalidade), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavClienteprofissao_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavClienteprofissao_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCLIENTEPROFISSAO");
               GX_FocusControl = edtavClienteprofissao_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV53ClienteProfissao = 0;
               AssignAttri(sPrefix, false, "AV53ClienteProfissao", StringUtil.LTrimStr( (decimal)(AV53ClienteProfissao), 9, 0));
            }
            else
            {
               AV53ClienteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavClienteprofissao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV53ClienteProfissao", StringUtil.LTrimStr( (decimal)(AV53ClienteProfissao), 9, 0));
            }
            cmbavClientetipopessoa.CurrentValue = cgiGet( cmbavClientetipopessoa_Internalname);
            AV16ClienteTipoPessoa = cgiGet( cmbavClientetipopessoa_Internalname);
            AssignAttri(sPrefix, false, "AV16ClienteTipoPessoa", AV16ClienteTipoPessoa);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTipoclienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTipoclienteid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIPOCLIENTEID");
               GX_FocusControl = edtavTipoclienteid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17TipoClienteId = 0;
               AssignAttri(sPrefix, false, "AV17TipoClienteId", StringUtil.LTrimStr( (decimal)(AV17TipoClienteId), 4, 0));
            }
            else
            {
               AV17TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavTipoclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV17TipoClienteId", StringUtil.LTrimStr( (decimal)(AV17TipoClienteId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavClienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavClienteid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCLIENTEID");
               GX_FocusControl = edtavClienteid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39ClienteId = 0;
               AssignAttri(sPrefix, false, "AV39ClienteId", StringUtil.LTrimStr( (decimal)(AV39ClienteId), 9, 0));
            }
            else
            {
               AV39ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavClienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV39ClienteId", StringUtil.LTrimStr( (decimal)(AV39ClienteId), 9, 0));
            }
            cmbavClientestatus.CurrentValue = cgiGet( cmbavClientestatus_Internalname);
            AV19ClienteStatus = StringUtil.StrToBool( cgiGet( cmbavClientestatus_Internalname));
            AssignAttri(sPrefix, false, "AV19ClienteStatus", AV19ClienteStatus);
            AV23EnderecoCEP = cgiGet( edtavEnderecocep_Internalname);
            AssignAttri(sPrefix, false, "AV23EnderecoCEP", AV23EnderecoCEP);
            AV27MunicipioCodigo = cgiGet( edtavMunicipiocodigo_Internalname);
            AssignAttri(sPrefix, false, "AV27MunicipioCodigo", AV27MunicipioCodigo);
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
         E115M2 ();
         if (returnInSub) return;
      }

      protected void E115M2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavClienteprofissao_Visible = 0;
         AssignProp(sPrefix, false, edtavClienteprofissao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteprofissao_Visible), 5, 0), true);
         edtavClientenacionalidade_Visible = 0;
         AssignProp(sPrefix, false, edtavClientenacionalidade_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientenacionalidade_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCLIENTENACIONALIDADE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCLIENTEPROFISSAO' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S142 ();
         if (returnInSub) return;
         cmbavClientetipopessoa.Visible = 0;
         AssignProp(sPrefix, false, cmbavClientetipopessoa_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavClientetipopessoa.Visible), 5, 0), true);
         edtavTipoclienteid_Visible = 0;
         AssignProp(sPrefix, false, edtavTipoclienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclienteid_Visible), 5, 0), true);
         edtavClienteid_Visible = 0;
         AssignProp(sPrefix, false, edtavClienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteid_Visible), 5, 0), true);
         cmbavClientestatus.Visible = 0;
         AssignProp(sPrefix, false, cmbavClientestatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavClientestatus.Visible), 5, 0), true);
         edtavEnderecocep_Visible = 0;
         AssignProp(sPrefix, false, edtavEnderecocep_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEnderecocep_Visible), 5, 0), true);
         edtavMunicipiocodigo_Visible = 0;
         AssignProp(sPrefix, false, edtavMunicipiocodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipiocodigo_Visible), 5, 0), true);
         AV16ClienteTipoPessoa = "FISICA";
         AssignAttri(sPrefix, false, "AV16ClienteTipoPessoa", AV16ClienteTipoPessoa);
         /* Using cursor H005M2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A219TipoClienteFinancia = H005M2_A219TipoClienteFinancia[0];
            n219TipoClienteFinancia = H005M2_n219TipoClienteFinancia[0];
            A192TipoClienteId = H005M2_A192TipoClienteId[0];
            n192TipoClienteId = H005M2_n192TipoClienteId[0];
            AV17TipoClienteId = A192TipoClienteId;
            AssignAttri(sPrefix, false, "AV17TipoClienteId", StringUtil.LTrimStr( (decimal)(AV17TipoClienteId), 4, 0));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E125M2 ();
         if (returnInSub) return;
      }

      protected void E125M2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( (0==AV39ClienteId) )
         {
            AV12ClienteBC = new SdtCliente(context);
         }
         else
         {
            AV12ClienteBC.Load(AV39ClienteId);
         }
         AV12ClienteBC.gxTpr_Clientedocumento = AV13ClienteDocumento;
         AV12ClienteBC.gxTpr_Clienterazaosocial = AV14ClienteRazaoSocial;
         AV12ClienteBC.gxTpr_Clientenomefantasia = AV15ClienteNomeFantasia;
         AV12ClienteBC.gxTpr_Clientetipopessoa = AV16ClienteTipoPessoa;
         AV12ClienteBC.gxTpr_Tipoclienteid = AV17TipoClienteId;
         AV12ClienteBC.gxTpr_Clientestatus = AV19ClienteStatus;
         AV12ClienteBC.gxTpr_Clienteupdatedat = DateTimeUtil.Now( context);
         AV12ClienteBC.gxTpr_Clienteloguser = AV21SecUserId;
         AV12ClienteBC.gxTpr_Clienteprofissao = AV53ClienteProfissao;
         AV12ClienteBC.gxTpr_Clientenacionalidade = AV51ClienteNacionalidade;
         AV12ClienteBC.gxTpr_Clienteestadocivil = AV52ClienteEstadoCivil;
         AV12ClienteBC.gxTpr_Clienterg = AV57ClienteRG;
         AV12ClienteBC.gxTpr_Enderecotipo = AV22EnderecoTipo;
         AV12ClienteBC.gxTpr_Enderecocep = AV41CEP;
         AV12ClienteBC.gxTpr_Enderecologradouro = AV24EnderecoLogradouro;
         AV12ClienteBC.gxTpr_Enderecobairro = AV25EnderecoBairro;
         AV12ClienteBC.gxTpr_Enderecocidade = AV26EnderecoCidade;
         AV12ClienteBC.gxTpr_Municipiocodigo = AV27MunicipioCodigo;
         AV12ClienteBC.gxTpr_Endereconumero = AV30EnderecoNumero;
         AV12ClienteBC.gxTpr_Enderecocomplemento = AV31EnderecoComplemento;
         AV12ClienteBC.gxTpr_Clientedatanascimento = AV58ClienteDataNascimento;
         AV12ClienteBC.gxTpr_Contatoemail = AV33ContatoEmail;
         AV12ClienteBC.gxTpr_Contatoddd = AV32ContatoDDD;
         AV12ClienteBC.gxTpr_Contatoddi = AV38ContatoDDI;
         AV12ClienteBC.gxTpr_Contatonumero = AV34ContatoNumero;
         AV12ClienteBC.gxTpr_Contatotelefonenumero = AV35ContatoTelefoneNumero;
         AV12ClienteBC.gxTpr_Contatotelefoneddd = AV36ContatoTelefoneDDD;
         AV12ClienteBC.gxTpr_Contatotelefoneddi = AV37ContatoTelefoneDDI;
         AV12ClienteBC.Save();
         if ( AV12ClienteBC.Success() )
         {
            AV39ClienteId = AV12ClienteBC.gxTpr_Clienteid;
            AssignAttri(sPrefix, false, "AV39ClienteId", StringUtil.LTrimStr( (decimal)(AV39ClienteId), 9, 0));
            context.CommitDataStores("wpnovapropostanovocliente",pr_default);
            if ( AV59PossuiResponsavel )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S152 ();
               if (returnInSub) return;
               if ( AV42CheckRequiredFieldsResult && ! AV10HasValidationErrors )
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
                  GXEncryptionTmp = "wpnovaproposta"+UrlEncode(StringUtil.RTrim("NovoCliente")) + "," + UrlEncode(StringUtil.RTrim("Responsavel")) + "," + UrlEncode(StringUtil.BoolToStr(false));
                  CallWebObject(formatLink("wpnovaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                  context.wjLocDisableFrm = 1;
               }
            }
            else
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S152 ();
               if (returnInSub) return;
               if ( AV42CheckRequiredFieldsResult && ! AV10HasValidationErrors )
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
                  GXEncryptionTmp = "wpnovaproposta"+UrlEncode(StringUtil.RTrim("NovoCliente")) + "," + UrlEncode(StringUtil.RTrim("Conta")) + "," + UrlEncode(StringUtil.BoolToStr(false));
                  CallWebObject(formatLink("wpnovaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                  context.wjLocDisableFrm = 1;
               }
            }
         }
         else
         {
            context.RollbackDataStores("wpnovapropostanovocliente",pr_default);
            new showmessages(context ).execute( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12ClienteBC", AV12ClienteBC);
      }

      protected void E135M2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         AV12ClienteBC.gxTpr_Clientedocumento = AV13ClienteDocumento;
         AV12ClienteBC.gxTpr_Clienterazaosocial = AV14ClienteRazaoSocial;
         AV12ClienteBC.gxTpr_Clientenomefantasia = AV15ClienteNomeFantasia;
         AV12ClienteBC.gxTpr_Clientetipopessoa = AV16ClienteTipoPessoa;
         AV12ClienteBC.gxTpr_Tipoclienteid = AV17TipoClienteId;
         AV12ClienteBC.gxTpr_Clientestatus = AV19ClienteStatus;
         AV12ClienteBC.gxTpr_Clienteupdatedat = DateTimeUtil.Now( context);
         AV12ClienteBC.gxTpr_Clienteloguser = AV21SecUserId;
         AV12ClienteBC.gxTpr_Enderecotipo = AV22EnderecoTipo;
         AV12ClienteBC.gxTpr_Enderecocep = AV23EnderecoCEP;
         AV12ClienteBC.gxTpr_Enderecologradouro = AV24EnderecoLogradouro;
         AV12ClienteBC.gxTpr_Enderecobairro = AV25EnderecoBairro;
         AV12ClienteBC.gxTpr_Enderecocidade = AV26EnderecoCidade;
         AV12ClienteBC.gxTpr_Municipiocodigo = AV27MunicipioCodigo;
         AV12ClienteBC.gxTpr_Endereconumero = AV30EnderecoNumero;
         AV12ClienteBC.gxTpr_Enderecocomplemento = AV31EnderecoComplemento;
         AV12ClienteBC.gxTpr_Contatoemail = AV33ContatoEmail;
         AV12ClienteBC.gxTpr_Contatoddd = AV32ContatoDDD;
         AV12ClienteBC.gxTpr_Contatoddi = AV38ContatoDDI;
         AV12ClienteBC.gxTpr_Contatonumero = AV34ContatoNumero;
         AV12ClienteBC.gxTpr_Contatotelefonenumero = AV35ContatoTelefoneNumero;
         AV12ClienteBC.gxTpr_Contatotelefoneddd = AV36ContatoTelefoneDDD;
         AV12ClienteBC.gxTpr_Contatotelefoneddi = AV37ContatoTelefoneDDI;
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
         GXEncryptionTmp = "wpnovaproposta"+UrlEncode(StringUtil.RTrim("NovoCliente")) + "," + UrlEncode(StringUtil.RTrim("iniProposta")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wpnovaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12ClienteBC", AV12ClienteBC);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV13ClienteDocumento = AV11WizardData.gxTpr_Novocliente.gxTpr_Clientedocumento;
         AssignAttri(sPrefix, false, "AV13ClienteDocumento", AV13ClienteDocumento);
         AV16ClienteTipoPessoa = AV11WizardData.gxTpr_Novocliente.gxTpr_Clientetipopessoa;
         AssignAttri(sPrefix, false, "AV16ClienteTipoPessoa", AV16ClienteTipoPessoa);
         AV17TipoClienteId = AV11WizardData.gxTpr_Novocliente.gxTpr_Tipoclienteid;
         AssignAttri(sPrefix, false, "AV17TipoClienteId", StringUtil.LTrimStr( (decimal)(AV17TipoClienteId), 4, 0));
         AV39ClienteId = AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteid;
         AssignAttri(sPrefix, false, "AV39ClienteId", StringUtil.LTrimStr( (decimal)(AV39ClienteId), 9, 0));
         AV58ClienteDataNascimento = AV11WizardData.gxTpr_Novocliente.gxTpr_Clientedatanascimento;
         AssignAttri(sPrefix, false, "AV58ClienteDataNascimento", context.localUtil.Format(AV58ClienteDataNascimento, "99/99/9999"));
         AV14ClienteRazaoSocial = AV11WizardData.gxTpr_Novocliente.gxTpr_Clienterazaosocial;
         AssignAttri(sPrefix, false, "AV14ClienteRazaoSocial", AV14ClienteRazaoSocial);
         AV57ClienteRG = AV11WizardData.gxTpr_Novocliente.gxTpr_Clienterg;
         AssignAttri(sPrefix, false, "AV57ClienteRG", StringUtil.LTrimStr( (decimal)(AV57ClienteRG), 12, 0));
         AV51ClienteNacionalidade = AV11WizardData.gxTpr_Novocliente.gxTpr_Clientenacionalidade;
         AssignAttri(sPrefix, false, "AV51ClienteNacionalidade", StringUtil.LTrimStr( (decimal)(AV51ClienteNacionalidade), 9, 0));
         AV52ClienteEstadoCivil = AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteestadocivil;
         AssignAttri(sPrefix, false, "AV52ClienteEstadoCivil", AV52ClienteEstadoCivil);
         AV53ClienteProfissao = AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteprofissao;
         AssignAttri(sPrefix, false, "AV53ClienteProfissao", StringUtil.LTrimStr( (decimal)(AV53ClienteProfissao), 9, 0));
         AV19ClienteStatus = AV11WizardData.gxTpr_Novocliente.gxTpr_Clientestatus;
         AssignAttri(sPrefix, false, "AV19ClienteStatus", AV19ClienteStatus);
         AV59PossuiResponsavel = AV11WizardData.gxTpr_Novocliente.gxTpr_Possuiresponsavel;
         AssignAttri(sPrefix, false, "AV59PossuiResponsavel", AV59PossuiResponsavel);
         AV33ContatoEmail = AV11WizardData.gxTpr_Novocliente.gxTpr_Contatoemail;
         AssignAttri(sPrefix, false, "AV33ContatoEmail", AV33ContatoEmail);
         AV32ContatoDDD = AV11WizardData.gxTpr_Novocliente.gxTpr_Contatoddd;
         AssignAttri(sPrefix, false, "AV32ContatoDDD", StringUtil.LTrimStr( (decimal)(AV32ContatoDDD), 4, 0));
         AV34ContatoNumero = AV11WizardData.gxTpr_Novocliente.gxTpr_Contatonumero;
         AssignAttri(sPrefix, false, "AV34ContatoNumero", StringUtil.LTrimStr( (decimal)(AV34ContatoNumero), 18, 0));
         AV36ContatoTelefoneDDD = AV11WizardData.gxTpr_Novocliente.gxTpr_Contatotelefoneddd;
         AssignAttri(sPrefix, false, "AV36ContatoTelefoneDDD", StringUtil.LTrimStr( (decimal)(AV36ContatoTelefoneDDD), 4, 0));
         AV35ContatoTelefoneNumero = AV11WizardData.gxTpr_Novocliente.gxTpr_Contatotelefonenumero;
         AssignAttri(sPrefix, false, "AV35ContatoTelefoneNumero", StringUtil.LTrimStr( (decimal)(AV35ContatoTelefoneNumero), 18, 0));
         AV41CEP = AV11WizardData.gxTpr_Novocliente.gxTpr_Cep;
         AssignAttri(sPrefix, false, "AV41CEP", AV41CEP);
         AV23EnderecoCEP = AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecocep;
         AssignAttri(sPrefix, false, "AV23EnderecoCEP", AV23EnderecoCEP);
         AV24EnderecoLogradouro = AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecologradouro;
         AssignAttri(sPrefix, false, "AV24EnderecoLogradouro", AV24EnderecoLogradouro);
         AV30EnderecoNumero = AV11WizardData.gxTpr_Novocliente.gxTpr_Endereconumero;
         AssignAttri(sPrefix, false, "AV30EnderecoNumero", AV30EnderecoNumero);
         AV31EnderecoComplemento = AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecocomplemento;
         AssignAttri(sPrefix, false, "AV31EnderecoComplemento", AV31EnderecoComplemento);
         AV25EnderecoBairro = AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecobairro;
         AssignAttri(sPrefix, false, "AV25EnderecoBairro", AV25EnderecoBairro);
         AV26EnderecoCidade = AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecocidade;
         AssignAttri(sPrefix, false, "AV26EnderecoCidade", AV26EnderecoCidade);
         AV27MunicipioCodigo = AV11WizardData.gxTpr_Novocliente.gxTpr_Municipiocodigo;
         AssignAttri(sPrefix, false, "AV27MunicipioCodigo", AV27MunicipioCodigo);
         AV28MunicipioNome = AV11WizardData.gxTpr_Novocliente.gxTpr_Municipionome;
         AssignAttri(sPrefix, false, "AV28MunicipioNome", AV28MunicipioNome);
         AV29MunicipioUF = AV11WizardData.gxTpr_Novocliente.gxTpr_Municipiouf;
         AssignAttri(sPrefix, false, "AV29MunicipioUF", AV29MunicipioUF);
         AV15ClienteNomeFantasia = AV11WizardData.gxTpr_Novocliente.gxTpr_Clientenomefantasia;
         AssignAttri(sPrefix, false, "AV15ClienteNomeFantasia", AV15ClienteNomeFantasia);
      }

      protected void S162( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Novocliente.gxTpr_Clientedocumento = AV13ClienteDocumento;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Clientetipopessoa = AV16ClienteTipoPessoa;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Tipoclienteid = AV17TipoClienteId;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteid = AV39ClienteId;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Clientedatanascimento = AV58ClienteDataNascimento;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Clienterazaosocial = AV14ClienteRazaoSocial;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Clienterg = AV57ClienteRG;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Clientenacionalidade = AV51ClienteNacionalidade;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteestadocivil = AV52ClienteEstadoCivil;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteprofissao = AV53ClienteProfissao;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Clientestatus = AV19ClienteStatus;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Possuiresponsavel = AV59PossuiResponsavel;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Contatoemail = AV33ContatoEmail;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Contatoddd = AV32ContatoDDD;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Contatonumero = AV34ContatoNumero;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Contatotelefoneddd = AV36ContatoTelefoneDDD;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Contatotelefonenumero = AV35ContatoTelefoneNumero;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Cep = AV41CEP;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecocep = AV23EnderecoCEP;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecologradouro = AV24EnderecoLogradouro;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Endereconumero = AV30EnderecoNumero;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecocomplemento = AV31EnderecoComplemento;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecobairro = AV25EnderecoBairro;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecocidade = AV26EnderecoCidade;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Municipiocodigo = AV27MunicipioCodigo;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Municipionome = AV28MunicipioNome;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Municipiouf = AV29MunicipioUF;
         AV11WizardData.gxTpr_Novocliente.gxTpr_Clientenomefantasia = AV15ClienteNomeFantasia;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S152( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV42CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV42CheckRequiredFieldsResult", AV42CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13ClienteDocumento)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Documento", "", "", "", "", "", "", "", ""),  "error",  edtavClientedocumento_Internalname,  "true",  ""));
            AV42CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV42CheckRequiredFieldsResult", AV42CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14ClienteRazaoSocial)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""),  "error",  edtavClienterazaosocial_Internalname,  "true",  ""));
            AV42CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV42CheckRequiredFieldsResult", AV42CheckRequiredFieldsResult);
         }
         if ( (0==AV51ClienteNacionalidade) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nacionalidade", "", "", "", "", "", "", "", ""),  "error",  Combo_clientenacionalidade_Ddointernalname,  "true",  ""));
            AV42CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV42CheckRequiredFieldsResult", AV42CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52ClienteEstadoCivil)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Estado civil", "", "", "", "", "", "", "", ""),  "error",  cmbavClienteestadocivil_Internalname,  "true",  ""));
            AV42CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV42CheckRequiredFieldsResult", AV42CheckRequiredFieldsResult);
         }
         if ( (0==AV53ClienteProfissao) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Profissão", "", "", "", "", "", "", "", ""),  "error",  Combo_clienteprofissao_Ddointernalname,  "true",  ""));
            AV42CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV42CheckRequiredFieldsResult", AV42CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41CEP)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CEP", "", "", "", "", "", "", "", ""),  "error",  edtavCep_Internalname,  "true",  ""));
            AV42CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV42CheckRequiredFieldsResult", AV42CheckRequiredFieldsResult);
         }
      }

      protected void S142( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divTablenomefantasia_Visible = (((1==2)) ? 1 : 0);
         AssignProp(sPrefix, false, divTablenomefantasia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablenomefantasia_Visible), 5, 0), true);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCLIENTEPROFISSAO' Routine */
         returnInSub = false;
         /* Using cursor H005M3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A440ProfissaoId = H005M3_A440ProfissaoId[0];
            A441ProfissaoNome = H005M3_A441ProfissaoNome[0];
            n441ProfissaoNome = H005M3_n441ProfissaoNome[0];
            AV46Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV46Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A440ProfissaoId), 9, 0));
            AV46Combo_DataItem.gxTpr_Title = A441ProfissaoNome;
            AV55ClienteProfissao_Data.Add(AV46Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_clienteprofissao_Selectedvalue_set = ((0==AV53ClienteProfissao) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV53ClienteProfissao), 9, 0)));
         ucCombo_clienteprofissao.SendProperty(context, sPrefix, false, Combo_clienteprofissao_Internalname, "SelectedValue_set", Combo_clienteprofissao_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOCLIENTENACIONALIDADE' Routine */
         returnInSub = false;
         /* Using cursor H005M4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A434NacionalidadeId = H005M4_A434NacionalidadeId[0];
            A435NacionalidadeNome = H005M4_A435NacionalidadeNome[0];
            n435NacionalidadeNome = H005M4_n435NacionalidadeNome[0];
            AV46Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV46Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A434NacionalidadeId), 9, 0));
            AV46Combo_DataItem.gxTpr_Title = A435NacionalidadeNome;
            AV54ClienteNacionalidade_Data.Add(AV46Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_clientenacionalidade_Selectedvalue_set = ((0==AV51ClienteNacionalidade) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV51ClienteNacionalidade), 9, 0)));
         ucCombo_clientenacionalidade.SendProperty(context, sPrefix, false, Combo_clientenacionalidade_Internalname, "SelectedValue_set", Combo_clientenacionalidade_Selectedvalue_set);
      }

      protected void E145M2( )
      {
         /* Clientedatanascimento_Isvalid Routine */
         returnInSub = false;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV58ClienteDataNascimento ) ;
         AV60Idade = (short)(DateTimeUtil.Age( GXt_dtime1, DateTimeUtil.Now( context)));
         if ( AV60Idade < 18 )
         {
            AV59PossuiResponsavel = true;
            AssignAttri(sPrefix, false, "AV59PossuiResponsavel", AV59PossuiResponsavel);
            cmbavPossuiresponsavel.Enabled = 0;
            AssignProp(sPrefix, false, cmbavPossuiresponsavel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavPossuiresponsavel.Enabled), 5, 0), true);
         }
         else
         {
            AV59PossuiResponsavel = AV61OriginalPossuiResponsavel;
            AssignAttri(sPrefix, false, "AV59PossuiResponsavel", AV59PossuiResponsavel);
            cmbavPossuiresponsavel.Enabled = 1;
            AssignProp(sPrefix, false, cmbavPossuiresponsavel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavPossuiresponsavel.Enabled), 5, 0), true);
         }
         /*  Sending Event outputs  */
         cmbavPossuiresponsavel.CurrentValue = StringUtil.BoolToStr( AV59PossuiResponsavel);
         AssignProp(sPrefix, false, cmbavPossuiresponsavel_Internalname, "Values", cmbavPossuiresponsavel.ToJavascriptSource(), true);
      }

      protected void E155M2( )
      {
         /* Clientedocumento_Controlvaluechanged Routine */
         returnInSub = false;
         AV65GXLvl343 = 0;
         /* Using cursor H005M5 */
         pr_default.execute(3, new Object[] {AV13ClienteDocumento});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A457EspecialidadeId = H005M5_A457EspecialidadeId[0];
            n457EspecialidadeId = H005M5_n457EspecialidadeId[0];
            A597EspecialidadeCreatedBy = H005M5_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = H005M5_n597EspecialidadeCreatedBy[0];
            A169ClienteDocumento = H005M5_A169ClienteDocumento[0];
            n169ClienteDocumento = H005M5_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = H005M5_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H005M5_n170ClienteRazaoSocial[0];
            A171ClienteNomeFantasia = H005M5_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = H005M5_n171ClienteNomeFantasia[0];
            A172ClienteTipoPessoa = H005M5_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = H005M5_n172ClienteTipoPessoa[0];
            A192TipoClienteId = H005M5_A192TipoClienteId[0];
            n192TipoClienteId = H005M5_n192TipoClienteId[0];
            A193TipoClienteDescricao = H005M5_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = H005M5_n193TipoClienteDescricao[0];
            A174ClienteStatus = H005M5_A174ClienteStatus[0];
            n174ClienteStatus = H005M5_n174ClienteStatus[0];
            A141SecUserName = H005M5_A141SecUserName[0];
            n141SecUserName = H005M5_n141SecUserName[0];
            A181EnderecoTipo = H005M5_A181EnderecoTipo[0];
            n181EnderecoTipo = H005M5_n181EnderecoTipo[0];
            A182EnderecoCEP = H005M5_A182EnderecoCEP[0];
            n182EnderecoCEP = H005M5_n182EnderecoCEP[0];
            A183EnderecoLogradouro = H005M5_A183EnderecoLogradouro[0];
            n183EnderecoLogradouro = H005M5_n183EnderecoLogradouro[0];
            A184EnderecoBairro = H005M5_A184EnderecoBairro[0];
            n184EnderecoBairro = H005M5_n184EnderecoBairro[0];
            A185EnderecoCidade = H005M5_A185EnderecoCidade[0];
            n185EnderecoCidade = H005M5_n185EnderecoCidade[0];
            A186MunicipioCodigo = H005M5_A186MunicipioCodigo[0];
            n186MunicipioCodigo = H005M5_n186MunicipioCodigo[0];
            A187MunicipioNome = H005M5_A187MunicipioNome[0];
            n187MunicipioNome = H005M5_n187MunicipioNome[0];
            A189MunicipioUF = H005M5_A189MunicipioUF[0];
            n189MunicipioUF = H005M5_n189MunicipioUF[0];
            A190EnderecoNumero = H005M5_A190EnderecoNumero[0];
            n190EnderecoNumero = H005M5_n190EnderecoNumero[0];
            A191EnderecoComplemento = H005M5_A191EnderecoComplemento[0];
            n191EnderecoComplemento = H005M5_n191EnderecoComplemento[0];
            A201ContatoEmail = H005M5_A201ContatoEmail[0];
            n201ContatoEmail = H005M5_n201ContatoEmail[0];
            A198ContatoDDD = H005M5_A198ContatoDDD[0];
            n198ContatoDDD = H005M5_n198ContatoDDD[0];
            A199ContatoDDI = H005M5_A199ContatoDDI[0];
            n199ContatoDDI = H005M5_n199ContatoDDI[0];
            A200ContatoNumero = H005M5_A200ContatoNumero[0];
            n200ContatoNumero = H005M5_n200ContatoNumero[0];
            A202ContatoTelefoneNumero = H005M5_A202ContatoTelefoneNumero[0];
            n202ContatoTelefoneNumero = H005M5_n202ContatoTelefoneNumero[0];
            A203ContatoTelefoneDDD = H005M5_A203ContatoTelefoneDDD[0];
            n203ContatoTelefoneDDD = H005M5_n203ContatoTelefoneDDD[0];
            A204ContatoTelefoneDDI = H005M5_A204ContatoTelefoneDDI[0];
            n204ContatoTelefoneDDI = H005M5_n204ContatoTelefoneDDI[0];
            A459ClienteDataNascimento = H005M5_A459ClienteDataNascimento[0];
            n459ClienteDataNascimento = H005M5_n459ClienteDataNascimento[0];
            A421ClienteRG = H005M5_A421ClienteRG[0];
            n421ClienteRG = H005M5_n421ClienteRG[0];
            A484ClienteNacionalidade = H005M5_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = H005M5_n484ClienteNacionalidade[0];
            A486ClienteEstadoCivil = H005M5_A486ClienteEstadoCivil[0];
            n486ClienteEstadoCivil = H005M5_n486ClienteEstadoCivil[0];
            A487ClienteProfissao = H005M5_A487ClienteProfissao[0];
            n487ClienteProfissao = H005M5_n487ClienteProfissao[0];
            A168ClienteId = H005M5_A168ClienteId[0];
            A597EspecialidadeCreatedBy = H005M5_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = H005M5_n597EspecialidadeCreatedBy[0];
            A141SecUserName = H005M5_A141SecUserName[0];
            n141SecUserName = H005M5_n141SecUserName[0];
            A193TipoClienteDescricao = H005M5_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = H005M5_n193TipoClienteDescricao[0];
            A187MunicipioNome = H005M5_A187MunicipioNome[0];
            n187MunicipioNome = H005M5_n187MunicipioNome[0];
            A189MunicipioUF = H005M5_A189MunicipioUF[0];
            n189MunicipioUF = H005M5_n189MunicipioUF[0];
            AV65GXLvl343 = 1;
            AV13ClienteDocumento = A169ClienteDocumento;
            AssignAttri(sPrefix, false, "AV13ClienteDocumento", AV13ClienteDocumento);
            AV14ClienteRazaoSocial = A170ClienteRazaoSocial;
            AssignAttri(sPrefix, false, "AV14ClienteRazaoSocial", AV14ClienteRazaoSocial);
            AV15ClienteNomeFantasia = A171ClienteNomeFantasia;
            AssignAttri(sPrefix, false, "AV15ClienteNomeFantasia", AV15ClienteNomeFantasia);
            AV16ClienteTipoPessoa = A172ClienteTipoPessoa;
            AssignAttri(sPrefix, false, "AV16ClienteTipoPessoa", AV16ClienteTipoPessoa);
            AV17TipoClienteId = A192TipoClienteId;
            AssignAttri(sPrefix, false, "AV17TipoClienteId", StringUtil.LTrimStr( (decimal)(AV17TipoClienteId), 4, 0));
            AV18TipoClienteDescricao = A193TipoClienteDescricao;
            AV19ClienteStatus = A174ClienteStatus;
            AssignAttri(sPrefix, false, "AV19ClienteStatus", AV19ClienteStatus);
            AV21SecUserId = A133SecUserId;
            AssignAttri(sPrefix, false, "AV21SecUserId", StringUtil.LTrimStr( (decimal)(AV21SecUserId), 4, 0));
            AV20SecUserName = A141SecUserName;
            AV22EnderecoTipo = A181EnderecoTipo;
            AssignAttri(sPrefix, false, "AV22EnderecoTipo", AV22EnderecoTipo);
            AV23EnderecoCEP = A182EnderecoCEP;
            AssignAttri(sPrefix, false, "AV23EnderecoCEP", AV23EnderecoCEP);
            AV24EnderecoLogradouro = A183EnderecoLogradouro;
            AssignAttri(sPrefix, false, "AV24EnderecoLogradouro", AV24EnderecoLogradouro);
            AV25EnderecoBairro = A184EnderecoBairro;
            AssignAttri(sPrefix, false, "AV25EnderecoBairro", AV25EnderecoBairro);
            AV26EnderecoCidade = A185EnderecoCidade;
            AssignAttri(sPrefix, false, "AV26EnderecoCidade", AV26EnderecoCidade);
            AV27MunicipioCodigo = A186MunicipioCodigo;
            AssignAttri(sPrefix, false, "AV27MunicipioCodigo", AV27MunicipioCodigo);
            AV28MunicipioNome = A187MunicipioNome;
            AssignAttri(sPrefix, false, "AV28MunicipioNome", AV28MunicipioNome);
            AV29MunicipioUF = A189MunicipioUF;
            AssignAttri(sPrefix, false, "AV29MunicipioUF", AV29MunicipioUF);
            AV30EnderecoNumero = A190EnderecoNumero;
            AssignAttri(sPrefix, false, "AV30EnderecoNumero", AV30EnderecoNumero);
            AV31EnderecoComplemento = A191EnderecoComplemento;
            AssignAttri(sPrefix, false, "AV31EnderecoComplemento", AV31EnderecoComplemento);
            AV33ContatoEmail = A201ContatoEmail;
            AssignAttri(sPrefix, false, "AV33ContatoEmail", AV33ContatoEmail);
            AV32ContatoDDD = A198ContatoDDD;
            AssignAttri(sPrefix, false, "AV32ContatoDDD", StringUtil.LTrimStr( (decimal)(AV32ContatoDDD), 4, 0));
            AV38ContatoDDI = A199ContatoDDI;
            AssignAttri(sPrefix, false, "AV38ContatoDDI", StringUtil.LTrimStr( (decimal)(AV38ContatoDDI), 4, 0));
            AV34ContatoNumero = A200ContatoNumero;
            AssignAttri(sPrefix, false, "AV34ContatoNumero", StringUtil.LTrimStr( (decimal)(AV34ContatoNumero), 18, 0));
            AV35ContatoTelefoneNumero = A202ContatoTelefoneNumero;
            AssignAttri(sPrefix, false, "AV35ContatoTelefoneNumero", StringUtil.LTrimStr( (decimal)(AV35ContatoTelefoneNumero), 18, 0));
            AV36ContatoTelefoneDDD = A203ContatoTelefoneDDD;
            AssignAttri(sPrefix, false, "AV36ContatoTelefoneDDD", StringUtil.LTrimStr( (decimal)(AV36ContatoTelefoneDDD), 4, 0));
            AV37ContatoTelefoneDDI = A204ContatoTelefoneDDI;
            AssignAttri(sPrefix, false, "AV37ContatoTelefoneDDI", StringUtil.LTrimStr( (decimal)(AV37ContatoTelefoneDDI), 4, 0));
            AV58ClienteDataNascimento = A459ClienteDataNascimento;
            AssignAttri(sPrefix, false, "AV58ClienteDataNascimento", context.localUtil.Format(AV58ClienteDataNascimento, "99/99/9999"));
            AV57ClienteRG = A421ClienteRG;
            AssignAttri(sPrefix, false, "AV57ClienteRG", StringUtil.LTrimStr( (decimal)(AV57ClienteRG), 12, 0));
            AV51ClienteNacionalidade = A484ClienteNacionalidade;
            AssignAttri(sPrefix, false, "AV51ClienteNacionalidade", StringUtil.LTrimStr( (decimal)(AV51ClienteNacionalidade), 9, 0));
            AV52ClienteEstadoCivil = A486ClienteEstadoCivil;
            AssignAttri(sPrefix, false, "AV52ClienteEstadoCivil", AV52ClienteEstadoCivil);
            AV53ClienteProfissao = A487ClienteProfissao;
            AssignAttri(sPrefix, false, "AV53ClienteProfissao", StringUtil.LTrimStr( (decimal)(AV53ClienteProfissao), 9, 0));
            Combo_clientenacionalidade_Selectedvalue_set = ((0==AV51ClienteNacionalidade) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV51ClienteNacionalidade), 9, 0)));
            ucCombo_clientenacionalidade.SendProperty(context, sPrefix, false, Combo_clientenacionalidade_Internalname, "SelectedValue_set", Combo_clientenacionalidade_Selectedvalue_set);
            Combo_clienteprofissao_Selectedvalue_set = ((0==AV53ClienteProfissao) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV53ClienteProfissao), 9, 0)));
            ucCombo_clienteprofissao.SendProperty(context, sPrefix, false, Combo_clienteprofissao_Internalname, "SelectedValue_set", Combo_clienteprofissao_Selectedvalue_set);
            AV39ClienteId = A168ClienteId;
            AssignAttri(sPrefix, false, "AV39ClienteId", StringUtil.LTrimStr( (decimal)(AV39ClienteId), 9, 0));
            /* Execute user subroutine: 'LOADCOMBOTIPOCLIENTEID' */
            S176 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            AV41CEP = A182EnderecoCEP;
            AssignAttri(sPrefix, false, "AV41CEP", AV41CEP);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A182EnderecoCEP)) )
            {
               edtavCep_Enabled = 0;
               AssignProp(sPrefix, false, edtavCep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCep_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ClienteRazaoSocial)) )
            {
               edtavClienterazaosocial_Enabled = 0;
               AssignProp(sPrefix, false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ClienteNomeFantasia)) )
            {
               edtavClientenomefantasia_Enabled = 0;
               AssignProp(sPrefix, false, edtavClientenomefantasia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientenomefantasia_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ClienteTipoPessoa)) )
            {
               cmbavClientetipopessoa.Enabled = 0;
               AssignProp(sPrefix, false, cmbavClientetipopessoa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavClientetipopessoa.Enabled), 5, 0), true);
            }
            if ( ! (0==AV17TipoClienteId) )
            {
               edtavTipoclienteid_Enabled = 0;
               AssignProp(sPrefix, false, edtavTipoclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTipoclienteid_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ClienteTipoPessoa)) )
            {
            }
            if ( ! (0==AV17TipoClienteId) )
            {
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23EnderecoCEP)) )
            {
               edtavEnderecocep_Enabled = 0;
               AssignProp(sPrefix, false, edtavEnderecocep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecocep_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24EnderecoLogradouro)) )
            {
               edtavEnderecologradouro_Enabled = 0;
               AssignProp(sPrefix, false, edtavEnderecologradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecologradouro_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25EnderecoBairro)) )
            {
               edtavEnderecobairro_Enabled = 0;
               AssignProp(sPrefix, false, edtavEnderecobairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecobairro_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26EnderecoCidade)) )
            {
               edtavEnderecocidade_Enabled = 0;
               AssignProp(sPrefix, false, edtavEnderecocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecocidade_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27MunicipioCodigo)) )
            {
               edtavMunicipiocodigo_Enabled = 0;
               AssignProp(sPrefix, false, edtavMunicipiocodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiocodigo_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28MunicipioNome)) )
            {
               edtavMunicipionome_Enabled = 0;
               AssignProp(sPrefix, false, edtavMunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipionome_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29MunicipioUF)) )
            {
               edtavMunicipiouf_Enabled = 0;
               AssignProp(sPrefix, false, edtavMunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiouf_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30EnderecoNumero)) )
            {
               edtavEndereconumero_Enabled = 0;
               AssignProp(sPrefix, false, edtavEndereconumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEndereconumero_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31EnderecoComplemento)) )
            {
               edtavEnderecocomplemento_Enabled = 0;
               AssignProp(sPrefix, false, edtavEnderecocomplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecocomplemento_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ContatoEmail)) )
            {
               edtavContatoemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
            }
            if ( ! (0==AV34ContatoNumero) )
            {
               edtavContatonumero_Enabled = 0;
               AssignProp(sPrefix, false, edtavContatonumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatonumero_Enabled), 5, 0), true);
            }
            if ( ! (0==AV35ContatoTelefoneNumero) )
            {
               edtavContatotelefonenumero_Enabled = 0;
               AssignProp(sPrefix, false, edtavContatotelefonenumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatotelefonenumero_Enabled), 5, 0), true);
            }
            if ( ! (0==AV36ContatoTelefoneDDD) )
            {
               edtavContatotelefoneddd_Enabled = 0;
               AssignProp(sPrefix, false, edtavContatotelefoneddd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatotelefoneddd_Enabled), 5, 0), true);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ContatoEmail)) )
            {
               edtavContatoemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         if ( AV65GXLvl343 == 0 )
         {
            AV39ClienteId = 0;
            AssignAttri(sPrefix, false, "AV39ClienteId", StringUtil.LTrimStr( (decimal)(AV39ClienteId), 9, 0));
            edtavClientedocumento_Enabled = 1;
            AssignProp(sPrefix, false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), true);
            edtavClienterazaosocial_Enabled = 1;
            AssignProp(sPrefix, false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
            edtavClientenomefantasia_Enabled = 1;
            AssignProp(sPrefix, false, edtavClientenomefantasia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientenomefantasia_Enabled), 5, 0), true);
            cmbavClientetipopessoa.Enabled = 1;
            AssignProp(sPrefix, false, cmbavClientetipopessoa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavClientetipopessoa.Enabled), 5, 0), true);
            edtavTipoclienteid_Enabled = 1;
            AssignProp(sPrefix, false, edtavTipoclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTipoclienteid_Enabled), 5, 0), true);
            edtavEnderecocep_Enabled = 1;
            AssignProp(sPrefix, false, edtavEnderecocep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecocep_Enabled), 5, 0), true);
            edtavEnderecologradouro_Enabled = 1;
            AssignProp(sPrefix, false, edtavEnderecologradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecologradouro_Enabled), 5, 0), true);
            edtavEnderecobairro_Enabled = 1;
            AssignProp(sPrefix, false, edtavEnderecobairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecobairro_Enabled), 5, 0), true);
            edtavEnderecocidade_Enabled = 1;
            AssignProp(sPrefix, false, edtavEnderecocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecocidade_Enabled), 5, 0), true);
            edtavMunicipiocodigo_Enabled = 1;
            AssignProp(sPrefix, false, edtavMunicipiocodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiocodigo_Enabled), 5, 0), true);
            edtavEndereconumero_Enabled = 1;
            AssignProp(sPrefix, false, edtavEndereconumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEndereconumero_Enabled), 5, 0), true);
            edtavEnderecocomplemento_Enabled = 1;
            AssignProp(sPrefix, false, edtavEnderecocomplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecocomplemento_Enabled), 5, 0), true);
            edtavContatoemail_Enabled = 1;
            AssignProp(sPrefix, false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
            /* Execute user subroutine: 'LOADCOMBOTIPOCLIENTEID' */
            S176 ();
            if (returnInSub) return;
            edtavContatonumero_Enabled = 1;
            AssignProp(sPrefix, false, edtavContatonumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatonumero_Enabled), 5, 0), true);
            edtavContatotelefonenumero_Enabled = 1;
            AssignProp(sPrefix, false, edtavContatotelefonenumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatotelefonenumero_Enabled), 5, 0), true);
            edtavContatotelefoneddd_Enabled = 1;
            AssignProp(sPrefix, false, edtavContatotelefoneddd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatotelefoneddd_Enabled), 5, 0), true);
         }
         /*  Sending Event outputs  */
         cmbavClientetipopessoa.CurrentValue = StringUtil.RTrim( AV16ClienteTipoPessoa);
         AssignProp(sPrefix, false, cmbavClientetipopessoa_Internalname, "Values", cmbavClientetipopessoa.ToJavascriptSource(), true);
         cmbavClientestatus.CurrentValue = StringUtil.BoolToStr( AV19ClienteStatus);
         AssignProp(sPrefix, false, cmbavClientestatus_Internalname, "Values", cmbavClientestatus.ToJavascriptSource(), true);
         cmbavClienteestadocivil.CurrentValue = StringUtil.RTrim( AV52ClienteEstadoCivil);
         AssignProp(sPrefix, false, cmbavClienteestadocivil_Internalname, "Values", cmbavClienteestadocivil.ToJavascriptSource(), true);
      }

      protected void E165M2( )
      {
         /* Cep_Controlvaluechanged Routine */
         returnInSub = false;
         AV41CEP = StringUtil.StringReplace( AV41CEP, "-", "");
         AssignAttri(sPrefix, false, "AV41CEP", AV41CEP);
         AV48EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41CEP)) )
         {
            new GeneXus.Programs.myobjects.viacep.cepparaendereco(context ).execute(  AV41CEP, out  AV49ModeloRetorno, out  AV50Mensagem) ;
            AV48EnderecoCompleto.FromJSonString(AV49ModeloRetorno, null);
            /* Execute user subroutine: 'VALIDACEP' */
            S182 ();
            if (returnInSub) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48EnderecoCompleto.gxTpr_Cep)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CEP inválido",  "error",  edtavCep_Internalname,  "true",  ""));
         }
         AV25EnderecoBairro = AV48EnderecoCompleto.gxTpr_Bairro;
         AssignAttri(sPrefix, false, "AV25EnderecoBairro", AV25EnderecoBairro);
         AV26EnderecoCidade = AV48EnderecoCompleto.gxTpr_Localidade;
         AssignAttri(sPrefix, false, "AV26EnderecoCidade", AV26EnderecoCidade);
         AV24EnderecoLogradouro = AV48EnderecoCompleto.gxTpr_Logradouro;
         AssignAttri(sPrefix, false, "AV24EnderecoLogradouro", AV24EnderecoLogradouro);
         AV27MunicipioCodigo = AV48EnderecoCompleto.gxTpr_Ibge;
         AssignAttri(sPrefix, false, "AV27MunicipioCodigo", AV27MunicipioCodigo);
         /* Using cursor H005M6 */
         pr_default.execute(4, new Object[] {AV27MunicipioCodigo});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A186MunicipioCodigo = H005M6_A186MunicipioCodigo[0];
            n186MunicipioCodigo = H005M6_n186MunicipioCodigo[0];
            A187MunicipioNome = H005M6_A187MunicipioNome[0];
            n187MunicipioNome = H005M6_n187MunicipioNome[0];
            A189MunicipioUF = H005M6_A189MunicipioUF[0];
            n189MunicipioUF = H005M6_n189MunicipioUF[0];
            AV28MunicipioNome = A187MunicipioNome;
            AssignAttri(sPrefix, false, "AV28MunicipioNome", AV28MunicipioNome);
            AV29MunicipioUF = A189MunicipioUF;
            AssignAttri(sPrefix, false, "AV29MunicipioUF", AV29MunicipioUF);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         edtavEnderecobairro_Enabled = (String.IsNullOrEmpty(StringUtil.RTrim( AV48EnderecoCompleto.gxTpr_Bairro)) ? 1 : 0);
         AssignProp(sPrefix, false, edtavEnderecobairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecobairro_Enabled), 5, 0), true);
         edtavEnderecocidade_Enabled = (String.IsNullOrEmpty(StringUtil.RTrim( AV48EnderecoCompleto.gxTpr_Localidade)) ? 1 : 0);
         AssignProp(sPrefix, false, edtavEnderecocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecocidade_Enabled), 5, 0), true);
         edtavEnderecologradouro_Enabled = (String.IsNullOrEmpty(StringUtil.RTrim( AV48EnderecoCompleto.gxTpr_Logradouro)) ? 1 : 0);
         AssignProp(sPrefix, false, edtavEnderecologradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecologradouro_Enabled), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV48EnderecoCompleto", AV48EnderecoCompleto);
      }

      protected void S182( )
      {
         /* 'VALIDACEP' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48EnderecoCompleto.gxTpr_Cep)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CEP não encontrado",  "error",  edtavCep_Internalname,  "true",  ""));
            AV42CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV42CheckRequiredFieldsResult", AV42CheckRequiredFieldsResult);
         }
      }

      protected void S176( )
      {
         /* 'LOADCOMBOTIPOCLIENTEID' Routine */
         returnInSub = false;
      }

      protected void nextLoad( )
      {
      }

      protected void E175M2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_135_5M2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedcontatotelefoneddd_Internalname, tblTablemergedcontatotelefoneddd_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatotelefoneddd_Internalname, "DDD", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatotelefoneddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36ContatoTelefoneDDD), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36ContatoTelefoneDDD), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,139);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "DDD", edtavContatotelefoneddd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavContatotelefoneddd_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatotelefonenumero_Internalname, "Número", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatotelefonenumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35ContatoTelefoneNumero), 18, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35ContatoTelefoneNumero), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,142);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Número", edtavContatotelefonenumero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavContatotelefonenumero_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_135_5M2e( true) ;
         }
         else
         {
            wb_table2_135_5M2e( false) ;
         }
      }

      protected void wb_table1_121_5M2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedcontatoddd_Internalname, tblTablemergedcontatoddd_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatoddd_Internalname, "DDD", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatoddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32ContatoDDD), 4, 0, ",", "")), StringUtil.LTrim( ((edtavContatoddd_Enabled!=0) ? context.localUtil.Format( (decimal)(AV32ContatoDDD), "ZZZ9") : context.localUtil.Format( (decimal)(AV32ContatoDDD), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,125);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "DDD", edtavContatoddd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavContatoddd_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatonumero_Internalname, "Número", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatonumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ContatoNumero), 18, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34ContatoNumero), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,128);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Número", edtavContatonumero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavContatonumero_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaNovoCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_121_5M2e( true) ;
         }
         else
         {
            wb_table1_121_5M2e( false) ;
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
         PA5M2( ) ;
         WS5M2( ) ;
         WE5M2( ) ;
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
         PA5M2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpnovapropostanovocliente", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA5M2( ) ;
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
         PA5M2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS5M2( ) ;
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
         WS5M2( ) ;
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
         WE5M2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019134712", true, true);
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
         context.AddJavascriptSource("wpnovapropostanovocliente.js", "?202561019134713", false, true);
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
         cmbavClienteestadocivil.Name = "vCLIENTEESTADOCIVIL";
         cmbavClienteestadocivil.WebTags = "";
         cmbavClienteestadocivil.addItem("SOLTEIRO", "Solteiro(a)", 0);
         cmbavClienteestadocivil.addItem("CASADO", "Casado(a)", 0);
         cmbavClienteestadocivil.addItem("DIVORCIADO", "Divorciado(a)", 0);
         cmbavClienteestadocivil.addItem("VIUVO", "Viúvo(a)", 0);
         cmbavClienteestadocivil.addItem("SEPARADO", "Separado(a)", 0);
         cmbavClienteestadocivil.addItem("UNIAO_ESTAVEL", "União Estável", 0);
         if ( cmbavClienteestadocivil.ItemCount > 0 )
         {
         }
         cmbavPossuiresponsavel.Name = "vPOSSUIRESPONSAVEL";
         cmbavPossuiresponsavel.WebTags = "";
         cmbavPossuiresponsavel.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavPossuiresponsavel.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavPossuiresponsavel.ItemCount > 0 )
         {
         }
         cmbavClientetipopessoa.Name = "vCLIENTETIPOPESSOA";
         cmbavClientetipopessoa.WebTags = "";
         cmbavClientetipopessoa.addItem("FISICA", "Física", 0);
         cmbavClientetipopessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbavClientetipopessoa.ItemCount > 0 )
         {
         }
         cmbavClientestatus.Name = "vCLIENTESTATUS";
         cmbavClientestatus.WebTags = "";
         cmbavClientestatus.addItem(StringUtil.BoolToStr( true), "ATIVO", 0);
         cmbavClientestatus.addItem(StringUtil.BoolToStr( false), "INATIVO", 0);
         if ( cmbavClientestatus.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavClientedocumento_Internalname = sPrefix+"vCLIENTEDOCUMENTO";
         edtavClientedatanascimento_Internalname = sPrefix+"vCLIENTEDATANASCIMENTO";
         edtavClienterazaosocial_Internalname = sPrefix+"vCLIENTERAZAOSOCIAL";
         edtavClienterg_Internalname = sPrefix+"vCLIENTERG";
         lblTextblockcombo_clientenacionalidade_Internalname = sPrefix+"TEXTBLOCKCOMBO_CLIENTENACIONALIDADE";
         Combo_clientenacionalidade_Internalname = sPrefix+"COMBO_CLIENTENACIONALIDADE";
         divTablesplittedclientenacionalidade_Internalname = sPrefix+"TABLESPLITTEDCLIENTENACIONALIDADE";
         cmbavClienteestadocivil_Internalname = sPrefix+"vCLIENTEESTADOCIVIL";
         lblTextblockcombo_clienteprofissao_Internalname = sPrefix+"TEXTBLOCKCOMBO_CLIENTEPROFISSAO";
         Combo_clienteprofissao_Internalname = sPrefix+"COMBO_CLIENTEPROFISSAO";
         divTablesplittedclienteprofissao_Internalname = sPrefix+"TABLESPLITTEDCLIENTEPROFISSAO";
         cmbavPossuiresponsavel_Internalname = sPrefix+"vPOSSUIRESPONSAVEL";
         edtavClientenomefantasia_Internalname = sPrefix+"vCLIENTENOMEFANTASIA";
         divTablenomefantasia_Internalname = sPrefix+"TABLENOMEFANTASIA";
         edtavCep_Internalname = sPrefix+"vCEP";
         edtavEnderecologradouro_Internalname = sPrefix+"vENDERECOLOGRADOURO";
         edtavEndereconumero_Internalname = sPrefix+"vENDERECONUMERO";
         edtavEnderecocomplemento_Internalname = sPrefix+"vENDERECOCOMPLEMENTO";
         edtavEnderecobairro_Internalname = sPrefix+"vENDERECOBAIRRO";
         edtavEnderecocidade_Internalname = sPrefix+"vENDERECOCIDADE";
         edtavMunicipionome_Internalname = sPrefix+"vMUNICIPIONOME";
         edtavMunicipiouf_Internalname = sPrefix+"vMUNICIPIOUF";
         divTableendereco_Internalname = sPrefix+"TABLEENDERECO";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         edtavContatoemail_Internalname = sPrefix+"vCONTATOEMAIL";
         lblTextblockcontatoddd_Internalname = sPrefix+"TEXTBLOCKCONTATODDD";
         edtavContatoddd_Internalname = sPrefix+"vCONTATODDD";
         edtavContatonumero_Internalname = sPrefix+"vCONTATONUMERO";
         tblTablemergedcontatoddd_Internalname = sPrefix+"TABLEMERGEDCONTATODDD";
         divTablesplittedcontatoddd_Internalname = sPrefix+"TABLESPLITTEDCONTATODDD";
         lblTextblockcontatotelefoneddd_Internalname = sPrefix+"TEXTBLOCKCONTATOTELEFONEDDD";
         edtavContatotelefoneddd_Internalname = sPrefix+"vCONTATOTELEFONEDDD";
         edtavContatotelefonenumero_Internalname = sPrefix+"vCONTATOTELEFONENUMERO";
         tblTablemergedcontatotelefoneddd_Internalname = sPrefix+"TABLEMERGEDCONTATOTELEFONEDDD";
         divTablesplittedcontatotelefoneddd_Internalname = sPrefix+"TABLESPLITTEDCONTATOTELEFONEDDD";
         divTablecontato_Internalname = sPrefix+"TABLECONTATO";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = sPrefix+"DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavClientenacionalidade_Internalname = sPrefix+"vCLIENTENACIONALIDADE";
         edtavClienteprofissao_Internalname = sPrefix+"vCLIENTEPROFISSAO";
         cmbavClientetipopessoa_Internalname = sPrefix+"vCLIENTETIPOPESSOA";
         edtavTipoclienteid_Internalname = sPrefix+"vTIPOCLIENTEID";
         edtavClienteid_Internalname = sPrefix+"vCLIENTEID";
         cmbavClientestatus_Internalname = sPrefix+"vCLIENTESTATUS";
         edtavEnderecocep_Internalname = sPrefix+"vENDERECOCEP";
         edtavMunicipiocodigo_Internalname = sPrefix+"vMUNICIPIOCODIGO";
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
         edtavContatonumero_Jsonclick = "";
         edtavContatoddd_Jsonclick = "";
         edtavContatoddd_Enabled = 1;
         edtavContatotelefonenumero_Jsonclick = "";
         edtavContatotelefoneddd_Jsonclick = "";
         edtavContatotelefoneddd_Enabled = 1;
         edtavContatotelefonenumero_Enabled = 1;
         edtavContatonumero_Enabled = 1;
         edtavMunicipiocodigo_Jsonclick = "";
         edtavMunicipiocodigo_Enabled = 1;
         edtavMunicipiocodigo_Visible = 1;
         edtavEnderecocep_Jsonclick = "";
         edtavEnderecocep_Enabled = 1;
         edtavEnderecocep_Visible = 1;
         cmbavClientestatus_Jsonclick = "";
         cmbavClientestatus.Visible = 1;
         edtavClienteid_Jsonclick = "";
         edtavClienteid_Visible = 1;
         edtavTipoclienteid_Jsonclick = "";
         edtavTipoclienteid_Enabled = 1;
         edtavTipoclienteid_Visible = 1;
         cmbavClientetipopessoa_Jsonclick = "";
         cmbavClientetipopessoa.Visible = 1;
         cmbavClientetipopessoa.Enabled = 1;
         edtavClienteprofissao_Jsonclick = "";
         edtavClienteprofissao_Visible = 1;
         edtavClientenacionalidade_Jsonclick = "";
         edtavClientenacionalidade_Visible = 1;
         Btnwizardnext_Class = "Button ButtonWizard";
         Btnwizardnext_Caption = "Próximo";
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardprevious_Caption = "Anterior";
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         edtavContatoemail_Jsonclick = "";
         edtavContatoemail_Enabled = 1;
         edtavMunicipiouf_Jsonclick = "";
         edtavMunicipiouf_Enabled = 1;
         edtavMunicipionome_Jsonclick = "";
         edtavMunicipionome_Enabled = 1;
         edtavEnderecocidade_Jsonclick = "";
         edtavEnderecocidade_Enabled = 1;
         edtavEnderecobairro_Jsonclick = "";
         edtavEnderecobairro_Enabled = 1;
         edtavEnderecocomplemento_Jsonclick = "";
         edtavEnderecocomplemento_Enabled = 1;
         edtavEndereconumero_Jsonclick = "";
         edtavEndereconumero_Enabled = 1;
         edtavEnderecologradouro_Jsonclick = "";
         edtavEnderecologradouro_Enabled = 1;
         edtavCep_Jsonclick = "";
         edtavCep_Enabled = 1;
         edtavClientenomefantasia_Jsonclick = "";
         edtavClientenomefantasia_Enabled = 1;
         divTablenomefantasia_Visible = 1;
         cmbavPossuiresponsavel_Jsonclick = "";
         cmbavPossuiresponsavel.Enabled = 1;
         Combo_clienteprofissao_Emptyitem = Convert.ToBoolean( 0);
         Combo_clienteprofissao_Cls = "ExtendedCombo AttributeFL";
         cmbavClienteestadocivil_Jsonclick = "";
         cmbavClienteestadocivil.Enabled = 1;
         Combo_clientenacionalidade_Emptyitem = Convert.ToBoolean( 0);
         Combo_clientenacionalidade_Cls = "ExtendedCombo AttributeFL";
         edtavClienterg_Jsonclick = "";
         edtavClienterg_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         edtavClientedatanascimento_Jsonclick = "";
         edtavClientedatanascimento_Enabled = 1;
         edtavClientedocumento_Jsonclick = "";
         edtavClientedocumento_Enabled = 1;
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
         setEventMetadata("ENTER","""{"handler":"E125M2","iparms":[{"av":"AV39ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV13ClienteDocumento","fld":"vCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV14ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV15ClienteNomeFantasia","fld":"vCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"cmbavClientetipopessoa"},{"av":"AV16ClienteTipoPessoa","fld":"vCLIENTETIPOPESSOA","type":"svchar"},{"av":"AV17TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"cmbavClientestatus"},{"av":"AV19ClienteStatus","fld":"vCLIENTESTATUS","type":"boolean"},{"av":"AV21SecUserId","fld":"vSECUSERID","pic":"ZZZ9","type":"int"},{"av":"AV53ClienteProfissao","fld":"vCLIENTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51ClienteNacionalidade","fld":"vCLIENTENACIONALIDADE","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavClienteestadocivil"},{"av":"AV52ClienteEstadoCivil","fld":"vCLIENTEESTADOCIVIL","type":"svchar"},{"av":"AV57ClienteRG","fld":"vCLIENTERG","pic":"ZZZZZZZZZZZ9","type":"int"},{"av":"AV22EnderecoTipo","fld":"vENDERECOTIPO","type":"svchar"},{"av":"AV41CEP","fld":"vCEP","type":"svchar"},{"av":"AV24EnderecoLogradouro","fld":"vENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"AV25EnderecoBairro","fld":"vENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"AV26EnderecoCidade","fld":"vENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"AV27MunicipioCodigo","fld":"vMUNICIPIOCODIGO","type":"svchar"},{"av":"AV30EnderecoNumero","fld":"vENDERECONUMERO","type":"svchar"},{"av":"AV31EnderecoComplemento","fld":"vENDERECOCOMPLEMENTO","type":"svchar"},{"av":"AV58ClienteDataNascimento","fld":"vCLIENTEDATANASCIMENTO","type":"date"},{"av":"AV33ContatoEmail","fld":"vCONTATOEMAIL","type":"svchar"},{"av":"AV32ContatoDDD","fld":"vCONTATODDD","pic":"ZZZ9","type":"int"},{"av":"AV38ContatoDDI","fld":"vCONTATODDI","pic":"ZZZ9","type":"int"},{"av":"AV34ContatoNumero","fld":"vCONTATONUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV35ContatoTelefoneNumero","fld":"vCONTATOTELEFONENUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV36ContatoTelefoneDDD","fld":"vCONTATOTELEFONEDDD","pic":"ZZZ9","type":"int"},{"av":"AV37ContatoTelefoneDDI","fld":"vCONTATOTELEFONEDDI","pic":"ZZZ9","type":"int"},{"av":"cmbavPossuiresponsavel"},{"av":"AV59PossuiResponsavel","fld":"vPOSSUIRESPONSAVEL","type":"boolean"},{"av":"AV42CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"Combo_clientenacionalidade_Ddointernalname","ctrl":"COMBO_CLIENTENACIONALIDADE","prop":"DDOInternalName"},{"av":"Combo_clienteprofissao_Ddointernalname","ctrl":"COMBO_CLIENTEPROFISSAO","prop":"DDOInternalName"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV23EnderecoCEP","fld":"vENDERECOCEP","type":"svchar"},{"av":"AV28MunicipioNome","fld":"vMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV29MunicipioUF","fld":"vMUNICIPIOUF","pic":"@!","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV12ClienteBC","fld":"vCLIENTEBC","type":""},{"av":"AV39ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV42CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E135M2","iparms":[{"av":"AV13ClienteDocumento","fld":"vCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV12ClienteBC","fld":"vCLIENTEBC","type":""},{"av":"AV14ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV15ClienteNomeFantasia","fld":"vCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"cmbavClientetipopessoa"},{"av":"AV16ClienteTipoPessoa","fld":"vCLIENTETIPOPESSOA","type":"svchar"},{"av":"AV17TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"cmbavClientestatus"},{"av":"AV19ClienteStatus","fld":"vCLIENTESTATUS","type":"boolean"},{"av":"AV21SecUserId","fld":"vSECUSERID","pic":"ZZZ9","type":"int"},{"av":"AV22EnderecoTipo","fld":"vENDERECOTIPO","type":"svchar"},{"av":"AV23EnderecoCEP","fld":"vENDERECOCEP","type":"svchar"},{"av":"AV24EnderecoLogradouro","fld":"vENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"AV25EnderecoBairro","fld":"vENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"AV26EnderecoCidade","fld":"vENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"AV27MunicipioCodigo","fld":"vMUNICIPIOCODIGO","type":"svchar"},{"av":"AV30EnderecoNumero","fld":"vENDERECONUMERO","type":"svchar"},{"av":"AV31EnderecoComplemento","fld":"vENDERECOCOMPLEMENTO","type":"svchar"},{"av":"AV33ContatoEmail","fld":"vCONTATOEMAIL","type":"svchar"},{"av":"AV32ContatoDDD","fld":"vCONTATODDD","pic":"ZZZ9","type":"int"},{"av":"AV38ContatoDDI","fld":"vCONTATODDI","pic":"ZZZ9","type":"int"},{"av":"AV34ContatoNumero","fld":"vCONTATONUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV35ContatoTelefoneNumero","fld":"vCONTATOTELEFONENUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV36ContatoTelefoneDDD","fld":"vCONTATOTELEFONEDDD","pic":"ZZZ9","type":"int"},{"av":"AV37ContatoTelefoneDDI","fld":"vCONTATOTELEFONEDDI","pic":"ZZZ9","type":"int"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV39ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV58ClienteDataNascimento","fld":"vCLIENTEDATANASCIMENTO","type":"date"},{"av":"AV57ClienteRG","fld":"vCLIENTERG","pic":"ZZZZZZZZZZZ9","type":"int"},{"av":"AV51ClienteNacionalidade","fld":"vCLIENTENACIONALIDADE","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavClienteestadocivil"},{"av":"AV52ClienteEstadoCivil","fld":"vCLIENTEESTADOCIVIL","type":"svchar"},{"av":"AV53ClienteProfissao","fld":"vCLIENTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavPossuiresponsavel"},{"av":"AV59PossuiResponsavel","fld":"vPOSSUIRESPONSAVEL","type":"boolean"},{"av":"AV41CEP","fld":"vCEP","type":"svchar"},{"av":"AV28MunicipioNome","fld":"vMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV29MunicipioUF","fld":"vMUNICIPIOUF","pic":"@!","type":"svchar"}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV12ClienteBC","fld":"vCLIENTEBC","type":""}]}""");
         setEventMetadata("VCLIENTEDATANASCIMENTO.ISVALID","""{"handler":"E145M2","iparms":[{"av":"AV58ClienteDataNascimento","fld":"vCLIENTEDATANASCIMENTO","type":"date"},{"av":"AV61OriginalPossuiResponsavel","fld":"vORIGINALPOSSUIRESPONSAVEL","type":"boolean"}]""");
         setEventMetadata("VCLIENTEDATANASCIMENTO.ISVALID",""","oparms":[{"av":"cmbavPossuiresponsavel"},{"av":"AV59PossuiResponsavel","fld":"vPOSSUIRESPONSAVEL","type":"boolean"}]}""");
         setEventMetadata("VCLIENTEDOCUMENTO.CONTROLVALUECHANGED","""{"handler":"E155M2","iparms":[{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"},{"av":"AV13ClienteDocumento","fld":"vCLIENTEDOCUMENTO","type":"svchar"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A171ClienteNomeFantasia","fld":"CLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"A172ClienteTipoPessoa","fld":"CLIENTETIPOPESSOA","type":"svchar"},{"av":"A192TipoClienteId","fld":"TIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"A193TipoClienteDescricao","fld":"TIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"A174ClienteStatus","fld":"CLIENTESTATUS","type":"boolean"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A141SecUserName","fld":"SECUSERNAME","pic":"@!","type":"svchar"},{"av":"A181EnderecoTipo","fld":"ENDERECOTIPO","type":"svchar"},{"av":"A182EnderecoCEP","fld":"ENDERECOCEP","type":"svchar"},{"av":"A183EnderecoLogradouro","fld":"ENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"A184EnderecoBairro","fld":"ENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"A185EnderecoCidade","fld":"ENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"A186MunicipioCodigo","fld":"MUNICIPIOCODIGO","type":"svchar"},{"av":"A187MunicipioNome","fld":"MUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"A189MunicipioUF","fld":"MUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"A190EnderecoNumero","fld":"ENDERECONUMERO","type":"svchar"},{"av":"A191EnderecoComplemento","fld":"ENDERECOCOMPLEMENTO","type":"svchar"},{"av":"A201ContatoEmail","fld":"CONTATOEMAIL","type":"svchar"},{"av":"A198ContatoDDD","fld":"CONTATODDD","pic":"ZZZ9","type":"int"},{"av":"A199ContatoDDI","fld":"CONTATODDI","pic":"ZZZ9","type":"int"},{"av":"A200ContatoNumero","fld":"CONTATONUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"A202ContatoTelefoneNumero","fld":"CONTATOTELEFONENUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"A203ContatoTelefoneDDD","fld":"CONTATOTELEFONEDDD","pic":"ZZZ9","type":"int"},{"av":"A204ContatoTelefoneDDI","fld":"CONTATOTELEFONEDDI","pic":"ZZZ9","type":"int"},{"av":"A459ClienteDataNascimento","fld":"CLIENTEDATANASCIMENTO","type":"date"},{"av":"A421ClienteRG","fld":"CLIENTERG","pic":"ZZZZZZZZZZZ9","type":"int"},{"av":"A484ClienteNacionalidade","fld":"CLIENTENACIONALIDADE","pic":"ZZZZZZZZ9","type":"int"},{"av":"A486ClienteEstadoCivil","fld":"CLIENTEESTADOCIVIL","type":"svchar"},{"av":"A487ClienteProfissao","fld":"CLIENTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VCLIENTEDOCUMENTO.CONTROLVALUECHANGED",""","oparms":[{"av":"AV13ClienteDocumento","fld":"vCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV14ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV15ClienteNomeFantasia","fld":"vCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"cmbavClientetipopessoa"},{"av":"AV16ClienteTipoPessoa","fld":"vCLIENTETIPOPESSOA","type":"svchar"},{"av":"AV17TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"cmbavClientestatus"},{"av":"AV19ClienteStatus","fld":"vCLIENTESTATUS","type":"boolean"},{"av":"AV21SecUserId","fld":"vSECUSERID","pic":"ZZZ9","type":"int"},{"av":"AV22EnderecoTipo","fld":"vENDERECOTIPO","type":"svchar"},{"av":"AV23EnderecoCEP","fld":"vENDERECOCEP","type":"svchar"},{"av":"AV24EnderecoLogradouro","fld":"vENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"AV25EnderecoBairro","fld":"vENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"AV26EnderecoCidade","fld":"vENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"AV27MunicipioCodigo","fld":"vMUNICIPIOCODIGO","type":"svchar"},{"av":"AV28MunicipioNome","fld":"vMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV29MunicipioUF","fld":"vMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"AV30EnderecoNumero","fld":"vENDERECONUMERO","type":"svchar"},{"av":"AV31EnderecoComplemento","fld":"vENDERECOCOMPLEMENTO","type":"svchar"},{"av":"AV33ContatoEmail","fld":"vCONTATOEMAIL","type":"svchar"},{"av":"AV32ContatoDDD","fld":"vCONTATODDD","pic":"ZZZ9","type":"int"},{"av":"AV38ContatoDDI","fld":"vCONTATODDI","pic":"ZZZ9","type":"int"},{"av":"AV34ContatoNumero","fld":"vCONTATONUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV35ContatoTelefoneNumero","fld":"vCONTATOTELEFONENUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV36ContatoTelefoneDDD","fld":"vCONTATOTELEFONEDDD","pic":"ZZZ9","type":"int"},{"av":"AV37ContatoTelefoneDDI","fld":"vCONTATOTELEFONEDDI","pic":"ZZZ9","type":"int"},{"av":"AV58ClienteDataNascimento","fld":"vCLIENTEDATANASCIMENTO","type":"date"},{"av":"AV57ClienteRG","fld":"vCLIENTERG","pic":"ZZZZZZZZZZZ9","type":"int"},{"av":"AV51ClienteNacionalidade","fld":"vCLIENTENACIONALIDADE","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavClienteestadocivil"},{"av":"AV52ClienteEstadoCivil","fld":"vCLIENTEESTADOCIVIL","type":"svchar"},{"av":"AV53ClienteProfissao","fld":"vCLIENTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"Combo_clientenacionalidade_Selectedvalue_set","ctrl":"COMBO_CLIENTENACIONALIDADE","prop":"SelectedValue_set"},{"av":"Combo_clienteprofissao_Selectedvalue_set","ctrl":"COMBO_CLIENTEPROFISSAO","prop":"SelectedValue_set"},{"av":"AV39ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV41CEP","fld":"vCEP","type":"svchar"},{"av":"edtavCep_Enabled","ctrl":"vCEP","prop":"Enabled"},{"av":"edtavClienterazaosocial_Enabled","ctrl":"vCLIENTERAZAOSOCIAL","prop":"Enabled"},{"av":"edtavClientenomefantasia_Enabled","ctrl":"vCLIENTENOMEFANTASIA","prop":"Enabled"},{"av":"edtavTipoclienteid_Enabled","ctrl":"vTIPOCLIENTEID","prop":"Enabled"},{"av":"edtavEnderecocep_Enabled","ctrl":"vENDERECOCEP","prop":"Enabled"},{"av":"edtavEnderecologradouro_Enabled","ctrl":"vENDERECOLOGRADOURO","prop":"Enabled"},{"av":"edtavEnderecobairro_Enabled","ctrl":"vENDERECOBAIRRO","prop":"Enabled"},{"av":"edtavEnderecocidade_Enabled","ctrl":"vENDERECOCIDADE","prop":"Enabled"},{"av":"edtavMunicipiocodigo_Enabled","ctrl":"vMUNICIPIOCODIGO","prop":"Enabled"},{"av":"edtavMunicipionome_Enabled","ctrl":"vMUNICIPIONOME","prop":"Enabled"},{"av":"edtavMunicipiouf_Enabled","ctrl":"vMUNICIPIOUF","prop":"Enabled"},{"av":"edtavEndereconumero_Enabled","ctrl":"vENDERECONUMERO","prop":"Enabled"},{"av":"edtavEnderecocomplemento_Enabled","ctrl":"vENDERECOCOMPLEMENTO","prop":"Enabled"},{"av":"edtavContatoemail_Enabled","ctrl":"vCONTATOEMAIL","prop":"Enabled"},{"av":"edtavContatonumero_Enabled","ctrl":"vCONTATONUMERO","prop":"Enabled"},{"av":"edtavContatotelefonenumero_Enabled","ctrl":"vCONTATOTELEFONENUMERO","prop":"Enabled"},{"av":"edtavContatotelefoneddd_Enabled","ctrl":"vCONTATOTELEFONEDDD","prop":"Enabled"},{"av":"edtavClientedocumento_Enabled","ctrl":"vCLIENTEDOCUMENTO","prop":"Enabled"}]}""");
         setEventMetadata("VCEP.CONTROLVALUECHANGED","""{"handler":"E165M2","iparms":[{"av":"AV41CEP","fld":"vCEP","type":"svchar"},{"av":"A186MunicipioCodigo","fld":"MUNICIPIOCODIGO","type":"svchar"},{"av":"A187MunicipioNome","fld":"MUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"A189MunicipioUF","fld":"MUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"AV48EnderecoCompleto","fld":"vENDERECOCOMPLETO","type":""}]""");
         setEventMetadata("VCEP.CONTROLVALUECHANGED",""","oparms":[{"av":"AV41CEP","fld":"vCEP","type":"svchar"},{"av":"AV48EnderecoCompleto","fld":"vENDERECOCOMPLETO","type":""},{"av":"AV25EnderecoBairro","fld":"vENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"AV26EnderecoCidade","fld":"vENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"AV24EnderecoLogradouro","fld":"vENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"AV27MunicipioCodigo","fld":"vMUNICIPIOCODIGO","type":"svchar"},{"av":"AV28MunicipioNome","fld":"vMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV29MunicipioUF","fld":"vMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"edtavEnderecobairro_Enabled","ctrl":"vENDERECOBAIRRO","prop":"Enabled"},{"av":"edtavEnderecocidade_Enabled","ctrl":"vENDERECOCIDADE","prop":"Enabled"},{"av":"edtavEnderecologradouro_Enabled","ctrl":"vENDERECOLOGRADOURO","prop":"Enabled"},{"av":"AV42CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VALIDV_CLIENTEDOCUMENTO","""{"handler":"Validv_Clientedocumento","iparms":[]}""");
         setEventMetadata("VALIDV_CLIENTEESTADOCIVIL","""{"handler":"Validv_Clienteestadocivil","iparms":[]}""");
         setEventMetadata("VALIDV_CONTATOEMAIL","""{"handler":"Validv_Contatoemail","iparms":[]}""");
         setEventMetadata("VALIDV_CLIENTETIPOPESSOA","""{"handler":"Validv_Clientetipopessoa","iparms":[]}""");
         setEventMetadata("VALIDV_MUNICIPIOCODIGO","""{"handler":"Validv_Municipiocodigo","iparms":[]}""");
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
         Combo_clientenacionalidade_Ddointernalname = "";
         Combo_clienteprofissao_Ddointernalname = "";
         Combo_clienteprofissao_Selectedvalue_get = "";
         Combo_clientenacionalidade_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV54ClienteNacionalidade_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV55ClienteProfissao_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV22EnderecoTipo = "";
         AV12ClienteBC = new SdtCliente(context);
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
         AV48EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         AV13ClienteDocumento = "";
         AV58ClienteDataNascimento = DateTime.MinValue;
         AV14ClienteRazaoSocial = "";
         lblTextblockcombo_clientenacionalidade_Jsonclick = "";
         ucCombo_clientenacionalidade = new GXUserControl();
         Combo_clientenacionalidade_Caption = "";
         AV52ClienteEstadoCivil = "";
         lblTextblockcombo_clienteprofissao_Jsonclick = "";
         ucCombo_clienteprofissao = new GXUserControl();
         Combo_clienteprofissao_Caption = "";
         AV15ClienteNomeFantasia = "";
         AV41CEP = "";
         AV24EnderecoLogradouro = "";
         AV30EnderecoNumero = "";
         AV31EnderecoComplemento = "";
         AV25EnderecoBairro = "";
         AV26EnderecoCidade = "";
         AV28MunicipioNome = "";
         AV29MunicipioUF = "";
         AV33ContatoEmail = "";
         lblTextblockcontatoddd_Jsonclick = "";
         lblTextblockcontatotelefoneddd_Jsonclick = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         AV16ClienteTipoPessoa = "";
         AV23EnderecoCEP = "";
         AV27MunicipioCodigo = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H005M2_A219TipoClienteFinancia = new bool[] {false} ;
         H005M2_n219TipoClienteFinancia = new bool[] {false} ;
         H005M2_A192TipoClienteId = new short[1] ;
         H005M2_n192TipoClienteId = new bool[] {false} ;
         AV11WizardData = new SdtWpNovaPropostaData(context);
         AV5WebSession = context.GetSession();
         H005M3_A440ProfissaoId = new int[1] ;
         H005M3_A441ProfissaoNome = new string[] {""} ;
         H005M3_n441ProfissaoNome = new bool[] {false} ;
         A441ProfissaoNome = "";
         AV46Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         Combo_clienteprofissao_Selectedvalue_set = "";
         H005M4_A434NacionalidadeId = new int[1] ;
         H005M4_A435NacionalidadeNome = new string[] {""} ;
         H005M4_n435NacionalidadeNome = new bool[] {false} ;
         A435NacionalidadeNome = "";
         Combo_clientenacionalidade_Selectedvalue_set = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         H005M5_A457EspecialidadeId = new int[1] ;
         H005M5_n457EspecialidadeId = new bool[] {false} ;
         H005M5_A597EspecialidadeCreatedBy = new short[1] ;
         H005M5_n597EspecialidadeCreatedBy = new bool[] {false} ;
         H005M5_A169ClienteDocumento = new string[] {""} ;
         H005M5_n169ClienteDocumento = new bool[] {false} ;
         H005M5_A170ClienteRazaoSocial = new string[] {""} ;
         H005M5_n170ClienteRazaoSocial = new bool[] {false} ;
         H005M5_A171ClienteNomeFantasia = new string[] {""} ;
         H005M5_n171ClienteNomeFantasia = new bool[] {false} ;
         H005M5_A172ClienteTipoPessoa = new string[] {""} ;
         H005M5_n172ClienteTipoPessoa = new bool[] {false} ;
         H005M5_A192TipoClienteId = new short[1] ;
         H005M5_n192TipoClienteId = new bool[] {false} ;
         H005M5_A193TipoClienteDescricao = new string[] {""} ;
         H005M5_n193TipoClienteDescricao = new bool[] {false} ;
         H005M5_A174ClienteStatus = new bool[] {false} ;
         H005M5_n174ClienteStatus = new bool[] {false} ;
         H005M5_A141SecUserName = new string[] {""} ;
         H005M5_n141SecUserName = new bool[] {false} ;
         H005M5_A181EnderecoTipo = new string[] {""} ;
         H005M5_n181EnderecoTipo = new bool[] {false} ;
         H005M5_A182EnderecoCEP = new string[] {""} ;
         H005M5_n182EnderecoCEP = new bool[] {false} ;
         H005M5_A183EnderecoLogradouro = new string[] {""} ;
         H005M5_n183EnderecoLogradouro = new bool[] {false} ;
         H005M5_A184EnderecoBairro = new string[] {""} ;
         H005M5_n184EnderecoBairro = new bool[] {false} ;
         H005M5_A185EnderecoCidade = new string[] {""} ;
         H005M5_n185EnderecoCidade = new bool[] {false} ;
         H005M5_A186MunicipioCodigo = new string[] {""} ;
         H005M5_n186MunicipioCodigo = new bool[] {false} ;
         H005M5_A187MunicipioNome = new string[] {""} ;
         H005M5_n187MunicipioNome = new bool[] {false} ;
         H005M5_A189MunicipioUF = new string[] {""} ;
         H005M5_n189MunicipioUF = new bool[] {false} ;
         H005M5_A190EnderecoNumero = new string[] {""} ;
         H005M5_n190EnderecoNumero = new bool[] {false} ;
         H005M5_A191EnderecoComplemento = new string[] {""} ;
         H005M5_n191EnderecoComplemento = new bool[] {false} ;
         H005M5_A201ContatoEmail = new string[] {""} ;
         H005M5_n201ContatoEmail = new bool[] {false} ;
         H005M5_A198ContatoDDD = new short[1] ;
         H005M5_n198ContatoDDD = new bool[] {false} ;
         H005M5_A199ContatoDDI = new short[1] ;
         H005M5_n199ContatoDDI = new bool[] {false} ;
         H005M5_A200ContatoNumero = new long[1] ;
         H005M5_n200ContatoNumero = new bool[] {false} ;
         H005M5_A202ContatoTelefoneNumero = new long[1] ;
         H005M5_n202ContatoTelefoneNumero = new bool[] {false} ;
         H005M5_A203ContatoTelefoneDDD = new short[1] ;
         H005M5_n203ContatoTelefoneDDD = new bool[] {false} ;
         H005M5_A204ContatoTelefoneDDI = new short[1] ;
         H005M5_n204ContatoTelefoneDDI = new bool[] {false} ;
         H005M5_A459ClienteDataNascimento = new DateTime[] {DateTime.MinValue} ;
         H005M5_n459ClienteDataNascimento = new bool[] {false} ;
         H005M5_A421ClienteRG = new long[1] ;
         H005M5_n421ClienteRG = new bool[] {false} ;
         H005M5_A484ClienteNacionalidade = new int[1] ;
         H005M5_n484ClienteNacionalidade = new bool[] {false} ;
         H005M5_A486ClienteEstadoCivil = new string[] {""} ;
         H005M5_n486ClienteEstadoCivil = new bool[] {false} ;
         H005M5_A487ClienteProfissao = new int[1] ;
         H005M5_n487ClienteProfissao = new bool[] {false} ;
         H005M5_A168ClienteId = new int[1] ;
         AV18TipoClienteDescricao = "";
         AV20SecUserName = "";
         AV49ModeloRetorno = "";
         AV50Mensagem = "";
         H005M6_A186MunicipioCodigo = new string[] {""} ;
         H005M6_n186MunicipioCodigo = new bool[] {false} ;
         H005M6_A187MunicipioNome = new string[] {""} ;
         H005M6_n187MunicipioNome = new bool[] {false} ;
         H005M6_A189MunicipioUF = new string[] {""} ;
         H005M6_n189MunicipioUF = new bool[] {false} ;
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpnovapropostanovocliente__default(),
            new Object[][] {
                new Object[] {
               H005M2_A219TipoClienteFinancia, H005M2_n219TipoClienteFinancia, H005M2_A192TipoClienteId
               }
               , new Object[] {
               H005M3_A440ProfissaoId, H005M3_A441ProfissaoNome, H005M3_n441ProfissaoNome
               }
               , new Object[] {
               H005M4_A434NacionalidadeId, H005M4_A435NacionalidadeNome, H005M4_n435NacionalidadeNome
               }
               , new Object[] {
               H005M5_A457EspecialidadeId, H005M5_n457EspecialidadeId, H005M5_A597EspecialidadeCreatedBy, H005M5_n597EspecialidadeCreatedBy, H005M5_A169ClienteDocumento, H005M5_n169ClienteDocumento, H005M5_A170ClienteRazaoSocial, H005M5_n170ClienteRazaoSocial, H005M5_A171ClienteNomeFantasia, H005M5_n171ClienteNomeFantasia,
               H005M5_A172ClienteTipoPessoa, H005M5_n172ClienteTipoPessoa, H005M5_A192TipoClienteId, H005M5_n192TipoClienteId, H005M5_A193TipoClienteDescricao, H005M5_n193TipoClienteDescricao, H005M5_A174ClienteStatus, H005M5_n174ClienteStatus, H005M5_A141SecUserName, H005M5_n141SecUserName,
               H005M5_A181EnderecoTipo, H005M5_n181EnderecoTipo, H005M5_A182EnderecoCEP, H005M5_n182EnderecoCEP, H005M5_A183EnderecoLogradouro, H005M5_n183EnderecoLogradouro, H005M5_A184EnderecoBairro, H005M5_n184EnderecoBairro, H005M5_A185EnderecoCidade, H005M5_n185EnderecoCidade,
               H005M5_A186MunicipioCodigo, H005M5_n186MunicipioCodigo, H005M5_A187MunicipioNome, H005M5_n187MunicipioNome, H005M5_A189MunicipioUF, H005M5_n189MunicipioUF, H005M5_A190EnderecoNumero, H005M5_n190EnderecoNumero, H005M5_A191EnderecoComplemento, H005M5_n191EnderecoComplemento,
               H005M5_A201ContatoEmail, H005M5_n201ContatoEmail, H005M5_A198ContatoDDD, H005M5_n198ContatoDDD, H005M5_A199ContatoDDI, H005M5_n199ContatoDDI, H005M5_A200ContatoNumero, H005M5_n200ContatoNumero, H005M5_A202ContatoTelefoneNumero, H005M5_n202ContatoTelefoneNumero,
               H005M5_A203ContatoTelefoneDDD, H005M5_n203ContatoTelefoneDDD, H005M5_A204ContatoTelefoneDDI, H005M5_n204ContatoTelefoneDDI, H005M5_A459ClienteDataNascimento, H005M5_n459ClienteDataNascimento, H005M5_A421ClienteRG, H005M5_n421ClienteRG, H005M5_A484ClienteNacionalidade, H005M5_n484ClienteNacionalidade,
               H005M5_A486ClienteEstadoCivil, H005M5_n486ClienteEstadoCivil, H005M5_A487ClienteProfissao, H005M5_n487ClienteProfissao, H005M5_A168ClienteId
               }
               , new Object[] {
               H005M6_A186MunicipioCodigo, H005M6_A187MunicipioNome, H005M6_n187MunicipioNome, H005M6_A189MunicipioUF, H005M6_n189MunicipioUF
               }
            }
         );
         /* GeneXus formulas. */
         edtavMunicipionome_Enabled = 0;
         edtavMunicipiouf_Enabled = 0;
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
      private short AV21SecUserId ;
      private short AV38ContatoDDI ;
      private short AV37ContatoTelefoneDDI ;
      private short A192TipoClienteId ;
      private short A198ContatoDDD ;
      private short A199ContatoDDI ;
      private short A203ContatoTelefoneDDD ;
      private short A204ContatoTelefoneDDI ;
      private short wbEnd ;
      private short wbStart ;
      private short AV17TipoClienteId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV32ContatoDDD ;
      private short AV36ContatoTelefoneDDD ;
      private short gxcookieaux ;
      private short AV60Idade ;
      private short AV65GXLvl343 ;
      private short A597EspecialidadeCreatedBy ;
      private short nGXWrapped ;
      private int edtavMunicipionome_Enabled ;
      private int edtavMunicipiouf_Enabled ;
      private int A484ClienteNacionalidade ;
      private int A487ClienteProfissao ;
      private int A168ClienteId ;
      private int edtavClientedocumento_Enabled ;
      private int edtavClientedatanascimento_Enabled ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavClienterg_Enabled ;
      private int divTablenomefantasia_Visible ;
      private int edtavClientenomefantasia_Enabled ;
      private int edtavCep_Enabled ;
      private int edtavEnderecologradouro_Enabled ;
      private int edtavEndereconumero_Enabled ;
      private int edtavEnderecocomplemento_Enabled ;
      private int edtavEnderecobairro_Enabled ;
      private int edtavEnderecocidade_Enabled ;
      private int edtavContatoemail_Enabled ;
      private int AV51ClienteNacionalidade ;
      private int edtavClientenacionalidade_Visible ;
      private int AV53ClienteProfissao ;
      private int edtavClienteprofissao_Visible ;
      private int edtavTipoclienteid_Visible ;
      private int edtavTipoclienteid_Enabled ;
      private int AV39ClienteId ;
      private int edtavClienteid_Visible ;
      private int edtavEnderecocep_Visible ;
      private int edtavEnderecocep_Enabled ;
      private int edtavMunicipiocodigo_Visible ;
      private int edtavMunicipiocodigo_Enabled ;
      private int A440ProfissaoId ;
      private int A434NacionalidadeId ;
      private int A457EspecialidadeId ;
      private int edtavContatonumero_Enabled ;
      private int edtavContatotelefonenumero_Enabled ;
      private int edtavContatotelefoneddd_Enabled ;
      private int edtavContatoddd_Enabled ;
      private int idxLst ;
      private long A200ContatoNumero ;
      private long A202ContatoTelefoneNumero ;
      private long A421ClienteRG ;
      private long AV57ClienteRG ;
      private long AV34ContatoNumero ;
      private long AV35ContatoTelefoneNumero ;
      private string Combo_clientenacionalidade_Ddointernalname ;
      private string Combo_clienteprofissao_Ddointernalname ;
      private string Combo_clienteprofissao_Selectedvalue_get ;
      private string Combo_clientenacionalidade_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavMunicipionome_Internalname ;
      private string edtavMunicipiouf_Internalname ;
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
      private string edtavClientedocumento_Internalname ;
      private string TempTags ;
      private string edtavClientedocumento_Jsonclick ;
      private string edtavClientedatanascimento_Internalname ;
      private string edtavClientedatanascimento_Jsonclick ;
      private string edtavClienterazaosocial_Internalname ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string edtavClienterg_Internalname ;
      private string edtavClienterg_Jsonclick ;
      private string divTablesplittedclientenacionalidade_Internalname ;
      private string lblTextblockcombo_clientenacionalidade_Internalname ;
      private string lblTextblockcombo_clientenacionalidade_Jsonclick ;
      private string Combo_clientenacionalidade_Caption ;
      private string Combo_clientenacionalidade_Cls ;
      private string Combo_clientenacionalidade_Internalname ;
      private string cmbavClienteestadocivil_Internalname ;
      private string cmbavClienteestadocivil_Jsonclick ;
      private string divTablesplittedclienteprofissao_Internalname ;
      private string lblTextblockcombo_clienteprofissao_Internalname ;
      private string lblTextblockcombo_clienteprofissao_Jsonclick ;
      private string Combo_clienteprofissao_Caption ;
      private string Combo_clienteprofissao_Cls ;
      private string Combo_clienteprofissao_Internalname ;
      private string cmbavPossuiresponsavel_Internalname ;
      private string cmbavPossuiresponsavel_Jsonclick ;
      private string divTablenomefantasia_Internalname ;
      private string edtavClientenomefantasia_Internalname ;
      private string edtavClientenomefantasia_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableendereco_Internalname ;
      private string edtavCep_Internalname ;
      private string edtavCep_Jsonclick ;
      private string edtavEnderecologradouro_Internalname ;
      private string edtavEnderecologradouro_Jsonclick ;
      private string edtavEndereconumero_Internalname ;
      private string edtavEndereconumero_Jsonclick ;
      private string edtavEnderecocomplemento_Internalname ;
      private string edtavEnderecocomplemento_Jsonclick ;
      private string edtavEnderecobairro_Internalname ;
      private string edtavEnderecobairro_Jsonclick ;
      private string edtavEnderecocidade_Internalname ;
      private string edtavEnderecocidade_Jsonclick ;
      private string edtavMunicipionome_Jsonclick ;
      private string edtavMunicipiouf_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTablecontato_Internalname ;
      private string edtavContatoemail_Internalname ;
      private string edtavContatoemail_Jsonclick ;
      private string divTablesplittedcontatoddd_Internalname ;
      private string lblTextblockcontatoddd_Internalname ;
      private string lblTextblockcontatoddd_Jsonclick ;
      private string divTablesplittedcontatotelefoneddd_Internalname ;
      private string lblTextblockcontatotelefoneddd_Internalname ;
      private string lblTextblockcontatotelefoneddd_Jsonclick ;
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
      private string edtavClientenacionalidade_Internalname ;
      private string edtavClientenacionalidade_Jsonclick ;
      private string edtavClienteprofissao_Internalname ;
      private string edtavClienteprofissao_Jsonclick ;
      private string cmbavClientetipopessoa_Internalname ;
      private string cmbavClientetipopessoa_Jsonclick ;
      private string edtavTipoclienteid_Internalname ;
      private string edtavTipoclienteid_Jsonclick ;
      private string edtavClienteid_Internalname ;
      private string edtavClienteid_Jsonclick ;
      private string cmbavClientestatus_Internalname ;
      private string cmbavClientestatus_Jsonclick ;
      private string edtavEnderecocep_Internalname ;
      private string edtavEnderecocep_Jsonclick ;
      private string edtavMunicipiocodigo_Internalname ;
      private string edtavMunicipiocodigo_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string edtavContatoddd_Internalname ;
      private string edtavContatonumero_Internalname ;
      private string edtavContatotelefoneddd_Internalname ;
      private string edtavContatotelefonenumero_Internalname ;
      private string Combo_clienteprofissao_Selectedvalue_set ;
      private string Combo_clientenacionalidade_Selectedvalue_set ;
      private string sStyleString ;
      private string tblTablemergedcontatotelefoneddd_Internalname ;
      private string edtavContatotelefoneddd_Jsonclick ;
      private string edtavContatotelefonenumero_Jsonclick ;
      private string tblTablemergedcontatoddd_Internalname ;
      private string edtavContatoddd_Jsonclick ;
      private string edtavContatonumero_Jsonclick ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private DateTime GXt_dtime1 ;
      private DateTime A459ClienteDataNascimento ;
      private DateTime AV58ClienteDataNascimento ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV42CheckRequiredFieldsResult ;
      private bool AV61OriginalPossuiResponsavel ;
      private bool A174ClienteStatus ;
      private bool wbLoad ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_clientenacionalidade_Emptyitem ;
      private bool Combo_clienteprofissao_Emptyitem ;
      private bool AV59PossuiResponsavel ;
      private bool AV19ClienteStatus ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A219TipoClienteFinancia ;
      private bool n219TipoClienteFinancia ;
      private bool n192TipoClienteId ;
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
      private string AV49ModeloRetorno ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV22EnderecoTipo ;
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
      private string AV13ClienteDocumento ;
      private string AV14ClienteRazaoSocial ;
      private string AV52ClienteEstadoCivil ;
      private string AV15ClienteNomeFantasia ;
      private string AV41CEP ;
      private string AV24EnderecoLogradouro ;
      private string AV30EnderecoNumero ;
      private string AV31EnderecoComplemento ;
      private string AV25EnderecoBairro ;
      private string AV26EnderecoCidade ;
      private string AV28MunicipioNome ;
      private string AV29MunicipioUF ;
      private string AV33ContatoEmail ;
      private string AV16ClienteTipoPessoa ;
      private string AV23EnderecoCEP ;
      private string AV27MunicipioCodigo ;
      private string A441ProfissaoNome ;
      private string A435NacionalidadeNome ;
      private string AV18TipoClienteDescricao ;
      private string AV20SecUserName ;
      private string AV50Mensagem ;
      private IGxSession AV5WebSession ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_clientenacionalidade ;
      private GXUserControl ucCombo_clienteprofissao ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavClienteestadocivil ;
      private GXCombobox cmbavPossuiresponsavel ;
      private GXCombobox cmbavClientetipopessoa ;
      private GXCombobox cmbavClientestatus ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV54ClienteNacionalidade_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV55ClienteProfissao_Data ;
      private SdtCliente AV12ClienteBC ;
      private GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto AV48EnderecoCompleto ;
      private IDataStoreProvider pr_default ;
      private bool[] H005M2_A219TipoClienteFinancia ;
      private bool[] H005M2_n219TipoClienteFinancia ;
      private short[] H005M2_A192TipoClienteId ;
      private bool[] H005M2_n192TipoClienteId ;
      private SdtWpNovaPropostaData AV11WizardData ;
      private int[] H005M3_A440ProfissaoId ;
      private string[] H005M3_A441ProfissaoNome ;
      private bool[] H005M3_n441ProfissaoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV46Combo_DataItem ;
      private int[] H005M4_A434NacionalidadeId ;
      private string[] H005M4_A435NacionalidadeNome ;
      private bool[] H005M4_n435NacionalidadeNome ;
      private int[] H005M5_A457EspecialidadeId ;
      private bool[] H005M5_n457EspecialidadeId ;
      private short[] H005M5_A597EspecialidadeCreatedBy ;
      private bool[] H005M5_n597EspecialidadeCreatedBy ;
      private string[] H005M5_A169ClienteDocumento ;
      private bool[] H005M5_n169ClienteDocumento ;
      private string[] H005M5_A170ClienteRazaoSocial ;
      private bool[] H005M5_n170ClienteRazaoSocial ;
      private string[] H005M5_A171ClienteNomeFantasia ;
      private bool[] H005M5_n171ClienteNomeFantasia ;
      private string[] H005M5_A172ClienteTipoPessoa ;
      private bool[] H005M5_n172ClienteTipoPessoa ;
      private short[] H005M5_A192TipoClienteId ;
      private bool[] H005M5_n192TipoClienteId ;
      private string[] H005M5_A193TipoClienteDescricao ;
      private bool[] H005M5_n193TipoClienteDescricao ;
      private bool[] H005M5_A174ClienteStatus ;
      private bool[] H005M5_n174ClienteStatus ;
      private string[] H005M5_A141SecUserName ;
      private bool[] H005M5_n141SecUserName ;
      private string[] H005M5_A181EnderecoTipo ;
      private bool[] H005M5_n181EnderecoTipo ;
      private string[] H005M5_A182EnderecoCEP ;
      private bool[] H005M5_n182EnderecoCEP ;
      private string[] H005M5_A183EnderecoLogradouro ;
      private bool[] H005M5_n183EnderecoLogradouro ;
      private string[] H005M5_A184EnderecoBairro ;
      private bool[] H005M5_n184EnderecoBairro ;
      private string[] H005M5_A185EnderecoCidade ;
      private bool[] H005M5_n185EnderecoCidade ;
      private string[] H005M5_A186MunicipioCodigo ;
      private bool[] H005M5_n186MunicipioCodigo ;
      private string[] H005M5_A187MunicipioNome ;
      private bool[] H005M5_n187MunicipioNome ;
      private string[] H005M5_A189MunicipioUF ;
      private bool[] H005M5_n189MunicipioUF ;
      private string[] H005M5_A190EnderecoNumero ;
      private bool[] H005M5_n190EnderecoNumero ;
      private string[] H005M5_A191EnderecoComplemento ;
      private bool[] H005M5_n191EnderecoComplemento ;
      private string[] H005M5_A201ContatoEmail ;
      private bool[] H005M5_n201ContatoEmail ;
      private short[] H005M5_A198ContatoDDD ;
      private bool[] H005M5_n198ContatoDDD ;
      private short[] H005M5_A199ContatoDDI ;
      private bool[] H005M5_n199ContatoDDI ;
      private long[] H005M5_A200ContatoNumero ;
      private bool[] H005M5_n200ContatoNumero ;
      private long[] H005M5_A202ContatoTelefoneNumero ;
      private bool[] H005M5_n202ContatoTelefoneNumero ;
      private short[] H005M5_A203ContatoTelefoneDDD ;
      private bool[] H005M5_n203ContatoTelefoneDDD ;
      private short[] H005M5_A204ContatoTelefoneDDI ;
      private bool[] H005M5_n204ContatoTelefoneDDI ;
      private DateTime[] H005M5_A459ClienteDataNascimento ;
      private bool[] H005M5_n459ClienteDataNascimento ;
      private long[] H005M5_A421ClienteRG ;
      private bool[] H005M5_n421ClienteRG ;
      private int[] H005M5_A484ClienteNacionalidade ;
      private bool[] H005M5_n484ClienteNacionalidade ;
      private string[] H005M5_A486ClienteEstadoCivil ;
      private bool[] H005M5_n486ClienteEstadoCivil ;
      private int[] H005M5_A487ClienteProfissao ;
      private bool[] H005M5_n487ClienteProfissao ;
      private int[] H005M5_A168ClienteId ;
      private string[] H005M6_A186MunicipioCodigo ;
      private bool[] H005M6_n186MunicipioCodigo ;
      private string[] H005M6_A187MunicipioNome ;
      private bool[] H005M6_n187MunicipioNome ;
      private string[] H005M6_A189MunicipioUF ;
      private bool[] H005M6_n189MunicipioUF ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpnovapropostanovocliente__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH005M2;
          prmH005M2 = new Object[] {
          };
          Object[] prmH005M3;
          prmH005M3 = new Object[] {
          };
          Object[] prmH005M4;
          prmH005M4 = new Object[] {
          };
          Object[] prmH005M5;
          prmH005M5 = new Object[] {
          new ParDef("AV13ClienteDocumento",GXType.VarChar,20,0)
          };
          Object[] prmH005M6;
          prmH005M6 = new Object[] {
          new ParDef("AV27MunicipioCodigo",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005M2", "SELECT TipoClienteFinancia, TipoClienteId FROM TipoCliente WHERE TipoClienteFinancia ORDER BY TipoClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005M2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005M3", "SELECT ProfissaoId, ProfissaoNome FROM Profissao ORDER BY ProfissaoNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005M3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005M4", "SELECT NacionalidadeId, NacionalidadeNome FROM Nacionalidade ORDER BY NacionalidadeNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005M4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005M5", "SELECT T1.EspecialidadeId, T2.EspecialidadeCreatedBy AS EspecialidadeCreatedBy, T1.ClienteDocumento, T1.ClienteRazaoSocial, T1.ClienteNomeFantasia, T1.ClienteTipoPessoa, T1.TipoClienteId, T4.TipoClienteDescricao, T1.ClienteStatus, T3.SecUserName, T1.EnderecoTipo, T1.EnderecoCEP, T1.EnderecoLogradouro, T1.EnderecoBairro, T1.EnderecoCidade, T1.MunicipioCodigo, T5.MunicipioNome, T5.MunicipioUF, T1.EnderecoNumero, T1.EnderecoComplemento, T1.ContatoEmail, T1.ContatoDDD, T1.ContatoDDI, T1.ContatoNumero, T1.ContatoTelefoneNumero, T1.ContatoTelefoneDDD, T1.ContatoTelefoneDDI, T1.ClienteDataNascimento, T1.ClienteRG, T1.ClienteNacionalidade, T1.ClienteEstadoCivil, T1.ClienteProfissao, T1.ClienteId FROM ((((Cliente T1 LEFT JOIN Especialidade T2 ON T2.EspecialidadeId = T1.EspecialidadeId) LEFT JOIN SecUser T3 ON T3.SecUserId = T2.EspecialidadeCreatedBy) LEFT JOIN TipoCliente T4 ON T4.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T5 ON T5.MunicipioCodigo = T1.MunicipioCodigo) WHERE T1.ClienteDocumento = ( :AV13ClienteDocumento) ORDER BY T1.ClienteDocumento ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005M5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H005M6", "SELECT MunicipioCodigo, MunicipioNome, MunicipioUF FROM Municipio WHERE MunicipioCodigo = ( :AV27MunicipioCodigo) ORDER BY MunicipioCodigo ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005M6,1, GxCacheFrequency.OFF ,false,true )
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
