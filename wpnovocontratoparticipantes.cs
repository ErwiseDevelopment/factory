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
   public class wpnovocontratoparticipantes : GXWebComponent
   {
      public wpnovocontratoparticipantes( )
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

      public wpnovocontratoparticipantes( IGxContext context )
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
         cmbavAssinaturaparticipantetipo = new GXCombobox();
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
            PA4I2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS4I2( ) ;
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
            context.SendWebValue( "Wp Novo Contrato Participantes") ;
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
            GXEncryptionTmp = "wpnovocontratoparticipantes"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpnovocontratoparticipantes") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONGUID", AV29SessionGUID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSESSIONGUID", GetSecureSignedToken( sPrefix, AV29SessionGUID, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDERRO", AV35SdErro);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDERRO", AV35SdErro);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDERRO", GetSecureSignedToken( sPrefix, AV35SdErro, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPARTICIPANTEID_DATA", AV17ParticipanteId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPARTICIPANTEID_DATA", AV17ParticipanteId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONGUID", AV29SessionGUID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSESSIONGUID", GetSecureSignedToken( sPrefix, AV29SessionGUID, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDERRO", AV35SdErro);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDERRO", AV35SdErro);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDERRO", GetSecureSignedToken( sPrefix, AV35SdErro, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV13CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"PARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A233ParticipanteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PARTICIPANTEDOCUMENTO", A234ParticipanteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"PARTICIPANTENOME", A248ParticipanteNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"PARTICIPANTEEMAIL", A235ParticipanteEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GXCCtlgxBlob = "vARQUIVOBLOB" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtlgxBlob, AV26ArquivoBlob);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PARTICIPANTEID_Selectedvalue_get", StringUtil.RTrim( Combo_participanteid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PARTICIPANTEID_Selectedvalue_get", StringUtil.RTrim( Combo_participanteid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm4I2( )
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
            if ( ! ( WebComp_Wcwcparticipantes == null ) )
            {
               WebComp_Wcwcparticipantes.componentjscripts();
            }
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
         return "WpNovoContratoParticipantes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wp Novo Contrato Participantes" ;
      }

      protected void WB4I0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpnovocontratoparticipantes");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablearquivo_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;align-items:flex-start;align-content:flex-start;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavArquivoblob_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavArquivoblob_Internalname, "Arquivo", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            ClassString = "AttributeFL";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            edtavArquivoblob_Filetype = "tmp";
            AssignProp(sPrefix, false, edtavArquivoblob_Internalname, "Filetype", edtavArquivoblob_Filetype, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ArquivoBlob)) )
            {
               gxblobfileaux.Source = AV26ArquivoBlob;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavArquivoblob_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavArquivoblob_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV26ArquivoBlob = gxblobfileaux.GetURI();
                  AssignProp(sPrefix, false, edtavArquivoblob_Internalname, "URL", context.PathToRelativeUrl( AV26ArquivoBlob), true);
                  edtavArquivoblob_Filetype = gxblobfileaux.GetExtension();
                  AssignProp(sPrefix, false, edtavArquivoblob_Internalname, "Filetype", edtavArquivoblob_Filetype, true);
               }
               AssignProp(sPrefix, false, edtavArquivoblob_Internalname, "URL", context.PathToRelativeUrl( AV26ArquivoBlob), true);
            }
            GxWebStd.gx_blob_field( context, edtavArquivoblob_Internalname, StringUtil.RTrim( AV26ArquivoBlob), context.PathToRelativeUrl( AV26ArquivoBlob), (String.IsNullOrEmpty(StringUtil.RTrim( edtavArquivoblob_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavArquivoblob_Filetype)) ? AV26ArquivoBlob : edtavArquivoblob_Filetype)) : edtavArquivoblob_Contenttype), false, "", edtavArquivoblob_Parameters, 0, edtavArquivoblob_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtavArquivoblob_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", "", "HLP_WpNovoContratoParticipantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavContratonome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome_Internalname, "Descrição do contrato", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome_Internalname, AV12ContratoNome, StringUtil.RTrim( context.localUtil.Format( AV12ContratoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContratonome_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovoContratoParticipantes.htm");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Participante", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovoContratoParticipantes.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divParty_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;align-items:flex-start;align-content:flex-start;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL DscTop ExtendedComboCell", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedparticipanteid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_participanteid_Internalname, "Nome", "", "", lblTextblockcombo_participanteid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovoContratoParticipantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_participanteid.SetProperty("Caption", Combo_participanteid_Caption);
            ucCombo_participanteid.SetProperty("Cls", Combo_participanteid_Cls);
            ucCombo_participanteid.SetProperty("EmptyItem", Combo_participanteid_Emptyitem);
            ucCombo_participanteid.SetProperty("IncludeAddNewOption", Combo_participanteid_Includeaddnewoption);
            ucCombo_participanteid.SetProperty("DropDownOptionsData", AV17ParticipanteId_Data);
            ucCombo_participanteid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_participanteid_Internalname, sPrefix+"COMBO_PARTICIPANTEIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableassinatura_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableassinaturaparticipantetipo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockassinaturaparticipantetipo_Internalname, "Tipo", "", "", lblTextblockassinaturaparticipantetipo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovoContratoParticipantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssinaturaparticipantetipo_Internalname, "Assinatura Participante Tipo", "col-sm-3 AttributeFLLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssinaturaparticipantetipo, cmbavAssinaturaparticipantetipo_Internalname, StringUtil.RTrim( AV15AssinaturaParticipanteTipo), 1, cmbavAssinaturaparticipantetipo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavAssinaturaparticipantetipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_WpNovoContratoParticipantes.htm");
            cmbavAssinaturaparticipantetipo.CurrentValue = StringUtil.RTrim( AV15AssinaturaParticipanteTipo);
            AssignProp(sPrefix, false, cmbavAssinaturaparticipantetipo_Internalname, "Values", (string)(cmbavAssinaturaparticipantetipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:flex-end;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnadicionar_Internalname, "", "Adicionar", bttBtnadicionar_Jsonclick, 5, "Adicionar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOADICIONAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpNovoContratoParticipantes.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-4", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0051"+"", StringUtil.RTrim( WebComp_Wcwcparticipantes_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0051"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcparticipantes_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcparticipantes), StringUtil.Lower( WebComp_Wcwcparticipantes_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0051"+"");
                  }
                  WebComp_Wcwcparticipantes.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcparticipantes), StringUtil.Lower( WebComp_Wcwcparticipantes_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
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
            ucBtnwizardfirstprevious.SetProperty("TooltipText", Btnwizardfirstprevious_Tooltiptext);
            ucBtnwizardfirstprevious.SetProperty("BeforeIconClass", Btnwizardfirstprevious_Beforeiconclass);
            ucBtnwizardfirstprevious.SetProperty("Caption", Btnwizardfirstprevious_Caption);
            ucBtnwizardfirstprevious.SetProperty("Class", Btnwizardfirstprevious_Class);
            ucBtnwizardfirstprevious.Render(context, "wwp_iconbutton", Btnwizardfirstprevious_Internalname, sPrefix+"BTNWIZARDFIRSTPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardlastnext.SetProperty("TooltipText", Btnwizardlastnext_Tooltiptext);
            ucBtnwizardlastnext.SetProperty("AfterIconClass", Btnwizardlastnext_Aftericonclass);
            ucBtnwizardlastnext.SetProperty("Caption", Btnwizardlastnext_Caption);
            ucBtnwizardlastnext.SetProperty("Class", Btnwizardlastnext_Class);
            ucBtnwizardlastnext.Render(context, "wwp_iconbutton", Btnwizardlastnext_Internalname, sPrefix+"BTNWIZARDLASTNEXTContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavParticipanteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14ParticipanteId), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV14ParticipanteId), "ZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,62);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavParticipanteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavParticipanteid_Visible, 1, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovoContratoParticipantes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4I2( )
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
            Form.Meta.addItem("description", "Wp Novo Contrato Participantes", 0) ;
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
               STRUP4I0( ) ;
            }
         }
      }

      protected void WS4I2( )
      {
         START4I2( ) ;
         EVT4I2( ) ;
      }

      protected void EVT4I2( )
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
                                 STRUP4I0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PARTICIPANTEID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_participanteid.Onoptionclicked */
                                    E114I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E124I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E134I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4I0( ) ;
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
                                          E144I2 ();
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
                                 STRUP4I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E154I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADICIONAR'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAdicionar' */
                                    E164I2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E174I2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4I0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavArquivoblob_Internalname;
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 51 )
                        {
                           OldWcwcparticipantes = cgiGet( sPrefix+"W0051");
                           if ( ( StringUtil.Len( OldWcwcparticipantes) == 0 ) || ( StringUtil.StrCmp(OldWcwcparticipantes, WebComp_Wcwcparticipantes_Component) != 0 ) )
                           {
                              WebComp_Wcwcparticipantes = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcparticipantes, new Object[] {context} );
                              WebComp_Wcwcparticipantes.ComponentInit();
                              WebComp_Wcwcparticipantes.Name = "OldWcwcparticipantes";
                              WebComp_Wcwcparticipantes_Component = OldWcwcparticipantes;
                           }
                           if ( StringUtil.Len( WebComp_Wcwcparticipantes_Component) != 0 )
                           {
                              WebComp_Wcwcparticipantes.componentprocess(sPrefix+"W0051", "", sEvt);
                           }
                           WebComp_Wcwcparticipantes_Component = OldWcwcparticipantes;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4I2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4I2( ) ;
            }
         }
      }

      protected void PA4I2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpnovocontratoparticipantes")), "wpnovocontratoparticipantes") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpnovocontratoparticipantes")))) ;
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
               GX_FocusControl = edtavArquivoblob_Internalname;
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
         if ( cmbavAssinaturaparticipantetipo.ItemCount > 0 )
         {
            AV15AssinaturaParticipanteTipo = cmbavAssinaturaparticipantetipo.getValidValue(AV15AssinaturaParticipanteTipo);
            AssignAttri(sPrefix, false, "AV15AssinaturaParticipanteTipo", AV15AssinaturaParticipanteTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssinaturaparticipantetipo.CurrentValue = StringUtil.RTrim( AV15AssinaturaParticipanteTipo);
            AssignProp(sPrefix, false, cmbavAssinaturaparticipantetipo_Internalname, "Values", cmbavAssinaturaparticipantetipo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF4I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E134I2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwcparticipantes_Component) != 0 )
               {
                  WebComp_Wcwcparticipantes.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E174I2 ();
            WB4I0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4I2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONGUID", AV29SessionGUID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSESSIONGUID", GetSecureSignedToken( sPrefix, AV29SessionGUID, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDERRO", AV35SdErro);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDERRO", AV35SdErro);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDERRO", GetSecureSignedToken( sPrefix, AV35SdErro, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E124I2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPARTICIPANTEID_DATA"), AV17ParticipanteId_Data);
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            Combo_participanteid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_PARTICIPANTEID_Selectedvalue_get");
            /* Read variables values. */
            AV26ArquivoBlob = cgiGet( edtavArquivoblob_Internalname);
            AV12ContratoNome = cgiGet( edtavContratonome_Internalname);
            AssignAttri(sPrefix, false, "AV12ContratoNome", AV12ContratoNome);
            cmbavAssinaturaparticipantetipo.CurrentValue = cgiGet( cmbavAssinaturaparticipantetipo_Internalname);
            AV15AssinaturaParticipanteTipo = cgiGet( cmbavAssinaturaparticipantetipo_Internalname);
            AssignAttri(sPrefix, false, "AV15AssinaturaParticipanteTipo", AV15AssinaturaParticipanteTipo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavParticipanteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavParticipanteid_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPARTICIPANTEID");
               GX_FocusControl = edtavParticipanteid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14ParticipanteId = 0;
               AssignAttri(sPrefix, false, "AV14ParticipanteId", StringUtil.LTrimStr( (decimal)(AV14ParticipanteId), 8, 0));
            }
            else
            {
               AV14ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavParticipanteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV14ParticipanteId", StringUtil.LTrimStr( (decimal)(AV14ParticipanteId), 8, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26ArquivoBlob)) )
            {
               GXCCtlgxBlob = "vARQUIVOBLOB" + "_gxBlob";
               AV26ArquivoBlob = cgiGet( sPrefix+GXCCtlgxBlob);
            }
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
         E124I2 ();
         if (returnInSub) return;
      }

      protected void E124I2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavParticipanteid_Visible = 0;
         AssignProp(sPrefix, false, edtavParticipanteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavParticipanteid_Visible), 5, 0), true);
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char1) ;
         Combo_participanteid_Htmltemplate = GXt_char1;
         ucCombo_participanteid.SendProperty(context, sPrefix, false, Combo_participanteid_Internalname, "HTMLTemplate", Combo_participanteid_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOPARTICIPANTEID' */
         S122 ();
         if (returnInSub) return;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wcwcparticipantes = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcparticipantes_Component), StringUtil.Lower( "WcParticipantes")) != 0 )
         {
            WebComp_Wcwcparticipantes = getWebComponent(GetType(), "GeneXus.Programs", "wcparticipantes", new Object[] {context} );
            WebComp_Wcwcparticipantes.ComponentInit();
            WebComp_Wcwcparticipantes.Name = "WcParticipantes";
            WebComp_Wcwcparticipantes_Component = "WcParticipantes";
         }
         if ( StringUtil.Len( WebComp_Wcwcparticipantes_Component) != 0 )
         {
            WebComp_Wcwcparticipantes.setjustcreated();
            WebComp_Wcwcparticipantes.componentprepare(new Object[] {(string)sPrefix+"W0051",(string)""});
            WebComp_Wcwcparticipantes.componentbind(new Object[] {});
         }
         AV29SessionGUID = Guid.NewGuid( );
         AssignAttri(sPrefix, false, "AV29SessionGUID", AV29SessionGUID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSESSIONGUID", GetSecureSignedToken( sPrefix, AV29SessionGUID, context));
      }

      protected void E134I2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E144I2 ();
         if (returnInSub) return;
      }

      protected void E144I2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV36String = AV5WebSession.Get(AV29SessionGUID.ToString());
         AV24Array_SdParticipantes.FromJSonString(AV36String, null);
         if ( AV35SdErro.gxTpr_Status == 200 )
         {
            new prmessage(context ).gxep_sucesso(  "Assinatura criada!") ;
            context.CommitDataStores("wpnovocontratoparticipantes",pr_default);
         }
         else
         {
            new prmessage(context ).gxep_erro(  AV35SdErro) ;
            context.RollbackDataStores("wpnovocontratoparticipantes",pr_default);
         }
         if ( 1 == 2 )
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S142 ();
            if (returnInSub) return;
            if ( AV13CheckRequiredFieldsResult && ! AV10HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S152 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'FINISHWIZARD' */
               S162 ();
               if (returnInSub) return;
               AV5WebSession.Remove(AV6WebSessionKey);
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E154I2( )
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

      protected void E164I2( )
      {
         /* 'DoAdicionar' Routine */
         returnInSub = false;
         /* Using cursor H004I2 */
         pr_default.execute(0, new Object[] {AV14ParticipanteId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A233ParticipanteId = H004I2_A233ParticipanteId[0];
            A234ParticipanteDocumento = H004I2_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = H004I2_n234ParticipanteDocumento[0];
            A248ParticipanteNome = H004I2_A248ParticipanteNome[0];
            n248ParticipanteNome = H004I2_n248ParticipanteNome[0];
            A235ParticipanteEmail = H004I2_A235ParticipanteEmail[0];
            n235ParticipanteEmail = H004I2_n235ParticipanteEmail[0];
            AV23ParticipanteDocumento = A234ParticipanteDocumento;
            AV22ParticipanteNome = A248ParticipanteNome;
            AV21ParticipanteEmail = A235ParticipanteEmail;
            AV25SdParticipantes = new SdtSdParticipantes(context);
            AV25SdParticipantes.gxTpr_Participantedocumento = A234ParticipanteDocumento;
            AV25SdParticipantes.gxTpr_Participanteid = A233ParticipanteId;
            AV25SdParticipantes.gxTpr_Participanteemail = A235ParticipanteEmail;
            AV25SdParticipantes.gxTpr_Participantenome = A248ParticipanteNome;
            AV25SdParticipantes.gxTpr_Assinaturaparticipantetipo = AV15AssinaturaParticipanteTipo;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "WcParticipantes_Participantes", new Object[] {(SdtSdParticipantes)AV25SdParticipantes,(Guid)AV29SessionGUID}, true);
      }

      protected void E114I2( )
      {
         /* Combo_participanteid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_participanteid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "participante"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(AV14ParticipanteId,8,0));
            context.PopUp(formatLink("participante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_participanteid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOPARTICIPANTEID' */
            S122 ();
            if (returnInSub) return;
            AV18ComboSelectedValue = AV20Session.Get("PARTICIPANTEID");
            AV20Session.Remove("PARTICIPANTEID");
            Combo_participanteid_Selectedvalue_set = AV18ComboSelectedValue;
            ucCombo_participanteid.SendProperty(context, sPrefix, false, Combo_participanteid_Internalname, "SelectedValue_set", Combo_participanteid_Selectedvalue_set);
            AV14ParticipanteId = (int)(Math.Round(NumberUtil.Val( AV18ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV14ParticipanteId", StringUtil.LTrimStr( (decimal)(AV14ParticipanteId), 8, 0));
         }
         else
         {
            AV14ParticipanteId = (int)(Math.Round(NumberUtil.Val( Combo_participanteid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV14ParticipanteId", StringUtil.LTrimStr( (decimal)(AV14ParticipanteId), 8, 0));
            /* Execute user subroutine: 'LOADCOMBOPARTICIPANTEID' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17ParticipanteId_Data", AV17ParticipanteId_Data);
      }

      protected void S132( )
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
         AV14ParticipanteId = AV11WizardData.gxTpr_Participantes.gxTpr_Participanteid;
         AssignAttri(sPrefix, false, "AV14ParticipanteId", StringUtil.LTrimStr( (decimal)(AV14ParticipanteId), 8, 0));
         AV15AssinaturaParticipanteTipo = AV11WizardData.gxTpr_Participantes.gxTpr_Assinaturaparticipantetipo;
         AssignAttri(sPrefix, false, "AV15AssinaturaParticipanteTipo", AV15AssinaturaParticipanteTipo);
         AV26ArquivoBlob = AV11WizardData.gxTpr_Participantes.gxTpr_Arquivoblob;
         AssignProp(sPrefix, false, edtavArquivoblob_Internalname, "URL", context.PathToRelativeUrl( AV26ArquivoBlob), true);
         AV12ContratoNome = AV11WizardData.gxTpr_Participantes.gxTpr_Contratonome;
         AssignAttri(sPrefix, false, "AV12ContratoNome", AV12ContratoNome);
      }

      protected void S152( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Participantes.gxTpr_Participanteid = AV14ParticipanteId;
         AV11WizardData.gxTpr_Participantes.gxTpr_Assinaturaparticipantetipo = AV15AssinaturaParticipanteTipo;
         AV11WizardData.gxTpr_Participantes.gxTpr_Arquivoblob = AV26ArquivoBlob;
         AV11WizardData.gxTpr_Participantes.gxTpr_Contratonome = AV12ContratoNome;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S162( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV13CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV13CheckRequiredFieldsResult", AV13CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12ContratoNome)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Descrição do contrato", "", "", "", "", "", "", "", ""),  "error",  edtavContratonome_Internalname,  "true",  ""));
            AV13CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV13CheckRequiredFieldsResult", AV13CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPARTICIPANTEID' Routine */
         returnInSub = false;
         AV17ParticipanteId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H004I3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A233ParticipanteId = H004I3_A233ParticipanteId[0];
            A234ParticipanteDocumento = H004I3_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = H004I3_n234ParticipanteDocumento[0];
            A248ParticipanteNome = H004I3_A248ParticipanteNome[0];
            n248ParticipanteNome = H004I3_n248ParticipanteNome[0];
            AV19Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV19Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A233ParticipanteId), 8, 0));
            AV16ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV16ComboTitles.Add(A248ParticipanteNome, 0);
            AV16ComboTitles.Add(A234ParticipanteDocumento, 0);
            AV19Combo_DataItem.gxTpr_Title = AV16ComboTitles.ToJSonString(false);
            AV17ParticipanteId_Data.Add(AV19Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_participanteid_Selectedvalue_set = ((0==AV14ParticipanteId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV14ParticipanteId), 8, 0)));
         ucCombo_participanteid.SendProperty(context, sPrefix, false, Combo_participanteid_Internalname, "SelectedValue_set", Combo_participanteid_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E174I2( )
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
         PA4I2( ) ;
         WS4I2( ) ;
         WE4I2( ) ;
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
         PA4I2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpnovocontratoparticipantes", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4I2( ) ;
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
         PA4I2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4I2( ) ;
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
         WS4I2( ) ;
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
         WE4I2( ) ;
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
         if ( ! ( WebComp_Wcwcparticipantes == null ) )
         {
            WebComp_Wcwcparticipantes.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwcparticipantes == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcparticipantes_Component) != 0 )
            {
               WebComp_Wcwcparticipantes.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019142219", true, true);
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
         context.AddJavascriptSource("wpnovocontratoparticipantes.js", "?202561019142221", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavAssinaturaparticipantetipo.Name = "vASSINATURAPARTICIPANTETIPO";
         cmbavAssinaturaparticipantetipo.WebTags = "";
         cmbavAssinaturaparticipantetipo.addItem("Contratado", "Contratada", 0);
         cmbavAssinaturaparticipantetipo.addItem("Contratante", "Contratante", 0);
         cmbavAssinaturaparticipantetipo.addItem("Testemunha", "Testemunha", 0);
         cmbavAssinaturaparticipantetipo.addItem("Sacado", "Sacado", 0);
         if ( cmbavAssinaturaparticipantetipo.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavArquivoblob_Internalname = sPrefix+"vARQUIVOBLOB";
         edtavContratonome_Internalname = sPrefix+"vCONTRATONOME";
         divTablearquivo_Internalname = sPrefix+"TABLEARQUIVO";
         lblTextblockcombo_participanteid_Internalname = sPrefix+"TEXTBLOCKCOMBO_PARTICIPANTEID";
         Combo_participanteid_Internalname = sPrefix+"COMBO_PARTICIPANTEID";
         divTablesplittedparticipanteid_Internalname = sPrefix+"TABLESPLITTEDPARTICIPANTEID";
         lblTextblockassinaturaparticipantetipo_Internalname = sPrefix+"TEXTBLOCKASSINATURAPARTICIPANTETIPO";
         cmbavAssinaturaparticipantetipo_Internalname = sPrefix+"vASSINATURAPARTICIPANTETIPO";
         divUnnamedtableassinaturaparticipantetipo_Internalname = sPrefix+"UNNAMEDTABLEASSINATURAPARTICIPANTETIPO";
         bttBtnadicionar_Internalname = sPrefix+"BTNADICIONAR";
         divTableassinatura_Internalname = sPrefix+"TABLEASSINATURA";
         divParty_Internalname = sPrefix+"PARTY";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         Btnwizardlastnext_Internalname = sPrefix+"BTNWIZARDLASTNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavParticipanteid_Internalname = sPrefix+"vPARTICIPANTEID";
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
         Combo_participanteid_Htmltemplate = "";
         edtavParticipanteid_Jsonclick = "";
         edtavParticipanteid_Visible = 1;
         Btnwizardlastnext_Class = "Button ButtonWizard";
         Btnwizardlastnext_Caption = "Finalizar";
         Btnwizardlastnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardlastnext_Tooltiptext = "";
         Btnwizardfirstprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = "Fechar";
         Btnwizardfirstprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardfirstprevious_Tooltiptext = "";
         cmbavAssinaturaparticipantetipo_Jsonclick = "";
         cmbavAssinaturaparticipantetipo.Enabled = 1;
         Combo_participanteid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_participanteid_Emptyitem = Convert.ToBoolean( 0);
         Combo_participanteid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         edtavContratonome_Jsonclick = "";
         edtavContratonome_Enabled = 1;
         edtavArquivoblob_Jsonclick = "";
         edtavArquivoblob_Parameters = "";
         edtavArquivoblob_Contenttype = "";
         edtavArquivoblob_Filetype = "";
         edtavArquivoblob_Enabled = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7GoingBack","fld":"vGOINGBACK","type":"boolean"},{"av":"AV29SessionGUID","fld":"vSESSIONGUID","hsh":true,"type":"guid"},{"av":"AV35SdErro","fld":"vSDERRO","hsh":true,"type":""},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E144I2","iparms":[{"av":"AV29SessionGUID","fld":"vSESSIONGUID","hsh":true,"type":"guid"},{"av":"AV35SdErro","fld":"vSDERRO","hsh":true,"type":""},{"av":"AV13CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV12ContratoNome","fld":"vCONTRATONOME","type":"svchar"},{"av":"AV14ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"cmbavAssinaturaparticipantetipo"},{"av":"AV15AssinaturaParticipanteTipo","fld":"vASSINATURAPARTICIPANTETIPO","type":"svchar"},{"av":"AV26ArquivoBlob","fld":"vARQUIVOBLOB","type":"bitstr"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E154I2","iparms":[]}""");
         setEventMetadata("'DOADICIONAR'","""{"handler":"E164I2","iparms":[{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"AV14ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"A234ParticipanteDocumento","fld":"PARTICIPANTEDOCUMENTO","type":"svchar"},{"av":"A248ParticipanteNome","fld":"PARTICIPANTENOME","type":"svchar"},{"av":"A235ParticipanteEmail","fld":"PARTICIPANTEEMAIL","type":"svchar"},{"av":"cmbavAssinaturaparticipantetipo"},{"av":"AV15AssinaturaParticipanteTipo","fld":"vASSINATURAPARTICIPANTETIPO","type":"svchar"},{"av":"AV29SessionGUID","fld":"vSESSIONGUID","hsh":true,"type":"guid"}]}""");
         setEventMetadata("COMBO_PARTICIPANTEID.ONOPTIONCLICKED","""{"handler":"E114I2","iparms":[{"av":"Combo_participanteid_Selectedvalue_get","ctrl":"COMBO_PARTICIPANTEID","prop":"SelectedValue_get"},{"av":"AV14ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"A248ParticipanteNome","fld":"PARTICIPANTENOME","type":"svchar"},{"av":"A233ParticipanteId","fld":"PARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"A234ParticipanteDocumento","fld":"PARTICIPANTEDOCUMENTO","type":"svchar"}]""");
         setEventMetadata("COMBO_PARTICIPANTEID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_participanteid_Selectedvalue_set","ctrl":"COMBO_PARTICIPANTEID","prop":"SelectedValue_set"},{"av":"AV14ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"},{"av":"AV17ParticipanteId_Data","fld":"vPARTICIPANTEID_DATA","type":""}]}""");
         setEventMetadata("VALIDV_ASSINATURAPARTICIPANTETIPO","""{"handler":"Validv_Assinaturaparticipantetipo","iparms":[]}""");
         setEventMetadata("VALIDV_PARTICIPANTEID","""{"handler":"Validv_Participanteid","iparms":[]}""");
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
         Combo_participanteid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV29SessionGUID = Guid.Empty;
         AV35SdErro = new SdtSdErro(context);
         AV17ParticipanteId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A234ParticipanteDocumento = "";
         A248ParticipanteNome = "";
         A235ParticipanteEmail = "";
         GXCCtlgxBlob = "";
         AV26ArquivoBlob = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         AV12ContratoNome = "";
         lblTextblockcombo_participanteid_Jsonclick = "";
         ucCombo_participanteid = new GXUserControl();
         Combo_participanteid_Caption = "";
         lblTextblockassinaturaparticipantetipo_Jsonclick = "";
         AV15AssinaturaParticipanteTipo = "";
         bttBtnadicionar_Jsonclick = "";
         WebComp_Wcwcparticipantes_Component = "";
         OldWcwcparticipantes = "";
         ucBtnwizardfirstprevious = new GXUserControl();
         ucBtnwizardlastnext = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         GXt_char1 = "";
         AV36String = "";
         AV5WebSession = context.GetSession();
         AV24Array_SdParticipantes = new GXBaseCollection<SdtSdParticipantes>( context, "SdParticipantes", "Factory21");
         H004I2_A233ParticipanteId = new int[1] ;
         H004I2_A234ParticipanteDocumento = new string[] {""} ;
         H004I2_n234ParticipanteDocumento = new bool[] {false} ;
         H004I2_A248ParticipanteNome = new string[] {""} ;
         H004I2_n248ParticipanteNome = new bool[] {false} ;
         H004I2_A235ParticipanteEmail = new string[] {""} ;
         H004I2_n235ParticipanteEmail = new bool[] {false} ;
         AV23ParticipanteDocumento = "";
         AV22ParticipanteNome = "";
         AV21ParticipanteEmail = "";
         AV25SdParticipantes = new SdtSdParticipantes(context);
         AV18ComboSelectedValue = "";
         AV20Session = context.GetSession();
         Combo_participanteid_Selectedvalue_set = "";
         AV11WizardData = new SdtWpNovoContratoData(context);
         H004I3_A233ParticipanteId = new int[1] ;
         H004I3_A234ParticipanteDocumento = new string[] {""} ;
         H004I3_n234ParticipanteDocumento = new bool[] {false} ;
         H004I3_A248ParticipanteNome = new string[] {""} ;
         H004I3_n248ParticipanteNome = new bool[] {false} ;
         AV19Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV16ComboTitles = new GxSimpleCollection<string>();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpnovocontratoparticipantes__default(),
            new Object[][] {
                new Object[] {
               H004I2_A233ParticipanteId, H004I2_A234ParticipanteDocumento, H004I2_n234ParticipanteDocumento, H004I2_A248ParticipanteNome, H004I2_n248ParticipanteNome, H004I2_A235ParticipanteEmail, H004I2_n235ParticipanteEmail
               }
               , new Object[] {
               H004I3_A233ParticipanteId, H004I3_A234ParticipanteDocumento, H004I3_n234ParticipanteDocumento, H004I3_A248ParticipanteNome, H004I3_n248ParticipanteNome
               }
            }
         );
         WebComp_Wcwcparticipantes = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A233ParticipanteId ;
      private int edtavArquivoblob_Enabled ;
      private int edtavContratonome_Enabled ;
      private int AV14ParticipanteId ;
      private int edtavParticipanteid_Visible ;
      private int idxLst ;
      private string Combo_participanteid_Selectedvalue_get ;
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
      private string GXCCtlgxBlob ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divTablearquivo_Internalname ;
      private string edtavArquivoblob_Internalname ;
      private string TempTags ;
      private string edtavArquivoblob_Filetype ;
      private string edtavArquivoblob_Contenttype ;
      private string edtavArquivoblob_Parameters ;
      private string edtavArquivoblob_Jsonclick ;
      private string edtavContratonome_Internalname ;
      private string edtavContratonome_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divParty_Internalname ;
      private string divTablesplittedparticipanteid_Internalname ;
      private string lblTextblockcombo_participanteid_Internalname ;
      private string lblTextblockcombo_participanteid_Jsonclick ;
      private string Combo_participanteid_Caption ;
      private string Combo_participanteid_Cls ;
      private string Combo_participanteid_Internalname ;
      private string divTableassinatura_Internalname ;
      private string divUnnamedtableassinaturaparticipantetipo_Internalname ;
      private string lblTextblockassinaturaparticipantetipo_Internalname ;
      private string lblTextblockassinaturaparticipantetipo_Jsonclick ;
      private string cmbavAssinaturaparticipantetipo_Internalname ;
      private string cmbavAssinaturaparticipantetipo_Jsonclick ;
      private string bttBtnadicionar_Internalname ;
      private string bttBtnadicionar_Jsonclick ;
      private string WebComp_Wcwcparticipantes_Component ;
      private string OldWcwcparticipantes ;
      private string divTableactions_Internalname ;
      private string Btnwizardfirstprevious_Tooltiptext ;
      private string Btnwizardfirstprevious_Beforeiconclass ;
      private string Btnwizardfirstprevious_Caption ;
      private string Btnwizardfirstprevious_Class ;
      private string Btnwizardfirstprevious_Internalname ;
      private string Btnwizardlastnext_Tooltiptext ;
      private string Btnwizardlastnext_Aftericonclass ;
      private string Btnwizardlastnext_Caption ;
      private string Btnwizardlastnext_Class ;
      private string Btnwizardlastnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavParticipanteid_Internalname ;
      private string edtavParticipanteid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Combo_participanteid_Htmltemplate ;
      private string GXt_char1 ;
      private string Combo_participanteid_Selectedvalue_set ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV13CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Combo_participanteid_Emptyitem ;
      private bool Combo_participanteid_Includeaddnewoption ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcwcparticipantes ;
      private bool n234ParticipanteDocumento ;
      private bool n248ParticipanteNome ;
      private bool n235ParticipanteEmail ;
      private bool Btnwizardfirstprevious_Visible ;
      private string AV36String ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string A234ParticipanteDocumento ;
      private string A248ParticipanteNome ;
      private string A235ParticipanteEmail ;
      private string AV12ContratoNome ;
      private string AV15AssinaturaParticipanteTipo ;
      private string AV23ParticipanteDocumento ;
      private string AV22ParticipanteNome ;
      private string AV21ParticipanteEmail ;
      private string AV18ComboSelectedValue ;
      private Guid AV29SessionGUID ;
      private string AV26ArquivoBlob ;
      private IGxSession AV5WebSession ;
      private IGxSession AV20Session ;
      private GXWebComponent WebComp_Wcwcparticipantes ;
      private GxFile gxblobfileaux ;
      private GXUserControl ucCombo_participanteid ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucBtnwizardlastnext ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavAssinaturaparticipantetipo ;
      private SdtSdErro AV35SdErro ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17ParticipanteId_Data ;
      private GXBaseCollection<SdtSdParticipantes> AV24Array_SdParticipantes ;
      private IDataStoreProvider pr_default ;
      private int[] H004I2_A233ParticipanteId ;
      private string[] H004I2_A234ParticipanteDocumento ;
      private bool[] H004I2_n234ParticipanteDocumento ;
      private string[] H004I2_A248ParticipanteNome ;
      private bool[] H004I2_n248ParticipanteNome ;
      private string[] H004I2_A235ParticipanteEmail ;
      private bool[] H004I2_n235ParticipanteEmail ;
      private SdtSdParticipantes AV25SdParticipantes ;
      private SdtWpNovoContratoData AV11WizardData ;
      private int[] H004I3_A233ParticipanteId ;
      private string[] H004I3_A234ParticipanteDocumento ;
      private bool[] H004I3_n234ParticipanteDocumento ;
      private string[] H004I3_A248ParticipanteNome ;
      private bool[] H004I3_n248ParticipanteNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV19Combo_DataItem ;
      private GxSimpleCollection<string> AV16ComboTitles ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpnovocontratoparticipantes__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004I2;
          prmH004I2 = new Object[] {
          new ParDef("AV14ParticipanteId",GXType.Int32,8,0)
          };
          Object[] prmH004I3;
          prmH004I3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H004I2", "SELECT ParticipanteId, ParticipanteDocumento, ParticipanteNome, ParticipanteEmail FROM Participante WHERE ParticipanteId = :AV14ParticipanteId ORDER BY ParticipanteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004I2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H004I3", "SELECT ParticipanteId, ParticipanteDocumento, ParticipanteNome FROM Participante ORDER BY ParticipanteNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004I3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
