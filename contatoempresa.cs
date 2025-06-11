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
   public class contatoempresa : GXWebComponent
   {
      public contatoempresa( )
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

      public contatoempresa( IGxContext context )
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
            PA8N2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS8N2( ) ;
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
            context.SendWebValue( "Contato Empresa") ;
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
            GXEncryptionTmp = "contatoempresa"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contatoempresa") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV23CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
      }

      protected void RenderHtmlCloseForm8N2( )
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
         return "ContatoEmpresa" ;
      }

      public override string GetPgmdesc( )
      {
         return "Contato Empresa" ;
      }

      protected void WB8N0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "contatoempresa");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "table-contact-content", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientenomefantasia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientenomefantasia_Internalname, "Nome fantasia", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientenomefantasia_Internalname, AV12ClienteNomeFantasia, StringUtil.RTrim( context.localUtil.Format( AV12ClienteNomeFantasia, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,15);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientenomefantasia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientenomefantasia_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Razão social", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV13ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV13ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnderecocep_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnderecocep_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecocep_Internalname, AV17EnderecoCEP, StringUtil.RTrim( context.localUtil.Format( AV17EnderecoCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecocep_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEnderecocep_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnderecologradouro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnderecologradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecologradouro_Internalname, AV14EnderecoLogradouro, StringUtil.RTrim( context.localUtil.Format( AV14EnderecoLogradouro, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecologradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEnderecologradouro_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEndereconumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEndereconumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEndereconumero_Internalname, AV15EnderecoNumero, StringUtil.RTrim( context.localUtil.Format( AV15EnderecoNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEndereconumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEndereconumero_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnderecobairro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnderecobairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecobairro_Internalname, AV16EnderecoBairro, StringUtil.RTrim( context.localUtil.Format( AV16EnderecoBairro, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,40);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecobairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEnderecobairro_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnderecocomplemento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnderecocomplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecocomplemento_Internalname, AV18EnderecoComplemento, StringUtil.RTrim( context.localUtil.Format( AV18EnderecoComplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecocomplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEnderecocomplemento_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatoemail_Internalname, AV19ContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV19ContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatoemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMunicipionome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome_Internalname, "Município", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome_Internalname, AV20MunicipioNome, StringUtil.RTrim( context.localUtil.Format( AV20MunicipioNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,55);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMunicipionome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMunicipiouf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipiouf_Internalname, "Municipio UF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipiouf_Internalname, AV21MunicipioUF, StringUtil.RTrim( context.localUtil.Format( AV21MunicipioUF, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,60);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipiouf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMunicipiouf_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Celular", 1, 0, "px", 0, "px", "Group", "", "HLP_ContatoEmpresa.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecel_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatoddd_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatoddd_Internalname, "DDD", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatoddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ContatoDDD), 4, 0, ",", "")), StringUtil.LTrim( ((edtavContatoddd_Enabled!=0) ? context.localUtil.Format( (decimal)(AV26ContatoDDD), "ZZZ9") : context.localUtil.Format( (decimal)(AV26ContatoDDD), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatoddd_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatoddd_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatonumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatonumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatonumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27ContatoNumero), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContatonumero_Enabled!=0) ? context.localUtil.Format( (decimal)(AV27ContatoNumero), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV27ContatoNumero), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,73);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatonumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatonumero_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_ContatoEmpresa.htm");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Telefone", 1, 0, "px", 0, "px", "Group", "", "HLP_ContatoEmpresa.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTelefone_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatotelefoneddd_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatotelefoneddd_Internalname, "DDD", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatotelefoneddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24ContatoTelefoneDDD), 4, 0, ",", "")), StringUtil.LTrim( ((edtavContatotelefoneddd_Enabled!=0) ? context.localUtil.Format( (decimal)(AV24ContatoTelefoneDDD), "ZZZ9") : context.localUtil.Format( (decimal)(AV24ContatoTelefoneDDD), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatotelefoneddd_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatotelefoneddd_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatotelefonenumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatotelefonenumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatotelefonenumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ContatoTelefoneNumero), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContatotelefonenumero_Enabled!=0) ? context.localUtil.Format( (decimal)(AV25ContatoTelefoneNumero), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV25ContatoTelefoneNumero), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,86);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatotelefonenumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatotelefonenumero_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_ContatoEmpresa.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ActionGroupFixedBottomWizard", "start", "top", "", "flex-grow:1;", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipiocodigo_Internalname, AV22MunicipioCodigo, StringUtil.RTrim( context.localUtil.Format( AV22MunicipioCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipiocodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipiocodigo_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_ContatoEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START8N2( )
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
            Form.Meta.addItem("description", "Contato Empresa", 0) ;
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
               STRUP8N0( ) ;
            }
         }
      }

      protected void WS8N2( )
      {
         START8N2( ) ;
         EVT8N2( ) ;
      }

      protected void EVT8N2( )
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
                                 STRUP8N0( ) ;
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
                                 STRUP8N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E118N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8N0( ) ;
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
                                          E128N2 ();
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
                                 STRUP8N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E138N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E148N2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavClientenomefantasia_Internalname;
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

      protected void WE8N2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm8N2( ) ;
            }
         }
      }

      protected void PA8N2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contatoempresa")), "contatoempresa") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contatoempresa")))) ;
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
               GX_FocusControl = edtavClientenomefantasia_Internalname;
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
         RF8N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF8N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E148N2 ();
            WB8N0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes8N2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E118N2 ();
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
         E118N2 ();
         if (returnInSub) return;
      }

      protected void E118N2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavMunicipiocodigo_Visible = 0;
         AssignProp(sPrefix, false, edtavMunicipiocodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipiocodigo_Visible), 5, 0), true);
         AV12ClienteNomeFantasia = AV11WizardData.gxTpr_Cnpj.gxTpr_Clientenomefantasia;
         AssignAttri(sPrefix, false, "AV12ClienteNomeFantasia", AV12ClienteNomeFantasia);
         AV13ClienteRazaoSocial = AV11WizardData.gxTpr_Cnpj.gxTpr_Clienterazaosocial;
         AssignAttri(sPrefix, false, "AV13ClienteRazaoSocial", AV13ClienteRazaoSocial);
         AV14EnderecoLogradouro = AV11WizardData.gxTpr_Cnpj.gxTpr_Enderecologradouro;
         AssignAttri(sPrefix, false, "AV14EnderecoLogradouro", AV14EnderecoLogradouro);
         AV15EnderecoNumero = AV11WizardData.gxTpr_Cnpj.gxTpr_Endereconumero;
         AssignAttri(sPrefix, false, "AV15EnderecoNumero", AV15EnderecoNumero);
         AV16EnderecoBairro = AV11WizardData.gxTpr_Cnpj.gxTpr_Enderecobairro;
         AssignAttri(sPrefix, false, "AV16EnderecoBairro", AV16EnderecoBairro);
         AV17EnderecoCEP = AV11WizardData.gxTpr_Cnpj.gxTpr_Enderecocep;
         AssignAttri(sPrefix, false, "AV17EnderecoCEP", AV17EnderecoCEP);
         AV18EnderecoComplemento = AV11WizardData.gxTpr_Cnpj.gxTpr_Enderecocomplemento;
         AssignAttri(sPrefix, false, "AV18EnderecoComplemento", AV18EnderecoComplemento);
         AV19ContatoEmail = AV11WizardData.gxTpr_Cnpj.gxTpr_Contatoemail;
         AssignAttri(sPrefix, false, "AV19ContatoEmail", AV19ContatoEmail);
         AV22MunicipioCodigo = AV11WizardData.gxTpr_Cnpj.gxTpr_Municipiocodigo;
         AssignAttri(sPrefix, false, "AV22MunicipioCodigo", AV22MunicipioCodigo);
         AV20MunicipioNome = AV11WizardData.gxTpr_Cnpj.gxTpr_Municipionome;
         AssignAttri(sPrefix, false, "AV20MunicipioNome", AV20MunicipioNome);
         AV21MunicipioUF = AV11WizardData.gxTpr_Cnpj.gxTpr_Municipiouf;
         AssignAttri(sPrefix, false, "AV21MunicipioUF", AV21MunicipioUF);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E128N2 ();
         if (returnInSub) return;
      }

      protected void E128N2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV23CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
            AV5WebSession.Remove(AV6WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E138N2( )
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
         GXEncryptionTmp = "contato"+UrlEncode(StringUtil.RTrim("Empresa")) + "," + UrlEncode(StringUtil.RTrim("CNPJ")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("contato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV12ClienteNomeFantasia = AV11WizardData.gxTpr_Empresa.gxTpr_Clientenomefantasia;
         AssignAttri(sPrefix, false, "AV12ClienteNomeFantasia", AV12ClienteNomeFantasia);
         AV13ClienteRazaoSocial = AV11WizardData.gxTpr_Empresa.gxTpr_Clienterazaosocial;
         AssignAttri(sPrefix, false, "AV13ClienteRazaoSocial", AV13ClienteRazaoSocial);
         AV17EnderecoCEP = AV11WizardData.gxTpr_Empresa.gxTpr_Enderecocep;
         AssignAttri(sPrefix, false, "AV17EnderecoCEP", AV17EnderecoCEP);
         AV14EnderecoLogradouro = AV11WizardData.gxTpr_Empresa.gxTpr_Enderecologradouro;
         AssignAttri(sPrefix, false, "AV14EnderecoLogradouro", AV14EnderecoLogradouro);
         AV15EnderecoNumero = AV11WizardData.gxTpr_Empresa.gxTpr_Endereconumero;
         AssignAttri(sPrefix, false, "AV15EnderecoNumero", AV15EnderecoNumero);
         AV16EnderecoBairro = AV11WizardData.gxTpr_Empresa.gxTpr_Enderecobairro;
         AssignAttri(sPrefix, false, "AV16EnderecoBairro", AV16EnderecoBairro);
         AV18EnderecoComplemento = AV11WizardData.gxTpr_Empresa.gxTpr_Enderecocomplemento;
         AssignAttri(sPrefix, false, "AV18EnderecoComplemento", AV18EnderecoComplemento);
         AV19ContatoEmail = AV11WizardData.gxTpr_Empresa.gxTpr_Contatoemail;
         AssignAttri(sPrefix, false, "AV19ContatoEmail", AV19ContatoEmail);
         AV20MunicipioNome = AV11WizardData.gxTpr_Empresa.gxTpr_Municipionome;
         AssignAttri(sPrefix, false, "AV20MunicipioNome", AV20MunicipioNome);
         AV21MunicipioUF = AV11WizardData.gxTpr_Empresa.gxTpr_Municipiouf;
         AssignAttri(sPrefix, false, "AV21MunicipioUF", AV21MunicipioUF);
         AV22MunicipioCodigo = AV11WizardData.gxTpr_Empresa.gxTpr_Municipiocodigo;
         AssignAttri(sPrefix, false, "AV22MunicipioCodigo", AV22MunicipioCodigo);
         AV24ContatoTelefoneDDD = AV11WizardData.gxTpr_Empresa.gxTpr_Contatotelefoneddd;
         AssignAttri(sPrefix, false, "AV24ContatoTelefoneDDD", StringUtil.LTrimStr( (decimal)(AV24ContatoTelefoneDDD), 4, 0));
         AV25ContatoTelefoneNumero = AV11WizardData.gxTpr_Empresa.gxTpr_Contatotelefonenumero;
         AssignAttri(sPrefix, false, "AV25ContatoTelefoneNumero", StringUtil.LTrimStr( (decimal)(AV25ContatoTelefoneNumero), 18, 0));
         AV26ContatoDDD = AV11WizardData.gxTpr_Empresa.gxTpr_Contatoddd;
         AssignAttri(sPrefix, false, "AV26ContatoDDD", StringUtil.LTrimStr( (decimal)(AV26ContatoDDD), 4, 0));
         AV27ContatoNumero = AV11WizardData.gxTpr_Empresa.gxTpr_Contatonumero;
         AssignAttri(sPrefix, false, "AV27ContatoNumero", StringUtil.LTrimStr( (decimal)(AV27ContatoNumero), 18, 0));
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Empresa.gxTpr_Clientenomefantasia = AV12ClienteNomeFantasia;
         AV11WizardData.gxTpr_Empresa.gxTpr_Clienterazaosocial = AV13ClienteRazaoSocial;
         AV11WizardData.gxTpr_Empresa.gxTpr_Enderecocep = AV17EnderecoCEP;
         AV11WizardData.gxTpr_Empresa.gxTpr_Enderecologradouro = AV14EnderecoLogradouro;
         AV11WizardData.gxTpr_Empresa.gxTpr_Endereconumero = AV15EnderecoNumero;
         AV11WizardData.gxTpr_Empresa.gxTpr_Enderecobairro = AV16EnderecoBairro;
         AV11WizardData.gxTpr_Empresa.gxTpr_Enderecocomplemento = AV18EnderecoComplemento;
         AV11WizardData.gxTpr_Empresa.gxTpr_Contatoemail = AV19ContatoEmail;
         AV11WizardData.gxTpr_Empresa.gxTpr_Municipionome = AV20MunicipioNome;
         AV11WizardData.gxTpr_Empresa.gxTpr_Municipiouf = AV21MunicipioUF;
         AV11WizardData.gxTpr_Empresa.gxTpr_Municipiocodigo = AV22MunicipioCodigo;
         AV11WizardData.gxTpr_Empresa.gxTpr_Contatotelefoneddd = AV24ContatoTelefoneDDD;
         AV11WizardData.gxTpr_Empresa.gxTpr_Contatotelefonenumero = AV25ContatoTelefoneNumero;
         AV11WizardData.gxTpr_Empresa.gxTpr_Contatoddd = AV26ContatoDDD;
         AV11WizardData.gxTpr_Empresa.gxTpr_Contatonumero = AV27ContatoNumero;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV23CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV23CheckRequiredFieldsResult", AV23CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12ClienteNomeFantasia)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome fantasia", "", "", "", "", "", "", "", ""),  "error",  edtavClientenomefantasia_Internalname,  "true",  ""));
            AV23CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV23CheckRequiredFieldsResult", AV23CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13ClienteRazaoSocial)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Razão social", "", "", "", "", "", "", "", ""),  "error",  edtavClienterazaosocial_Internalname,  "true",  ""));
            AV23CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV23CheckRequiredFieldsResult", AV23CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17EnderecoCEP)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CEP", "", "", "", "", "", "", "", ""),  "error",  edtavEnderecocep_Internalname,  "true",  ""));
            AV23CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV23CheckRequiredFieldsResult", AV23CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14EnderecoLogradouro)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Logradouro", "", "", "", "", "", "", "", ""),  "error",  edtavEnderecologradouro_Internalname,  "true",  ""));
            AV23CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV23CheckRequiredFieldsResult", AV23CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15EnderecoNumero)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Número", "", "", "", "", "", "", "", ""),  "error",  edtavEndereconumero_Internalname,  "true",  ""));
            AV23CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV23CheckRequiredFieldsResult", AV23CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16EnderecoBairro)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Bairro", "", "", "", "", "", "", "", ""),  "error",  edtavEnderecobairro_Internalname,  "true",  ""));
            AV23CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV23CheckRequiredFieldsResult", AV23CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19ContatoEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "E-mail", "", "", "", "", "", "", "", ""),  "error",  edtavContatoemail_Internalname,  "true",  ""));
            AV23CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV23CheckRequiredFieldsResult", AV23CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20MunicipioNome)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Município", "", "", "", "", "", "", "", ""),  "error",  edtavMunicipionome_Internalname,  "true",  ""));
            AV23CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV23CheckRequiredFieldsResult", AV23CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21MunicipioUF)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Municipio UF", "", "", "", "", "", "", "", ""),  "error",  edtavMunicipiouf_Internalname,  "true",  ""));
            AV23CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV23CheckRequiredFieldsResult", AV23CheckRequiredFieldsResult);
         }
         if ( (0==AV26ContatoDDD) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "DDD", "", "", "", "", "", "", "", ""),  "error",  edtavContatoddd_Internalname,  "true",  ""));
            AV23CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV23CheckRequiredFieldsResult", AV23CheckRequiredFieldsResult);
         }
         if ( (0==AV27ContatoNumero) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Número", "", "", "", "", "", "", "", ""),  "error",  edtavContatonumero_Internalname,  "true",  ""));
            AV23CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV23CheckRequiredFieldsResult", AV23CheckRequiredFieldsResult);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E148N2( )
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
         PA8N2( ) ;
         WS8N2( ) ;
         WE8N2( ) ;
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
         PA8N2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "contatoempresa", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA8N2( ) ;
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
         PA8N2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS8N2( ) ;
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
         WS8N2( ) ;
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
         WE8N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101963498", true, true);
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
         context.AddJavascriptSource("contatoempresa.js", "?20256101963498", false, true);
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
         edtavClientenomefantasia_Internalname = sPrefix+"vCLIENTENOMEFANTASIA";
         edtavClienterazaosocial_Internalname = sPrefix+"vCLIENTERAZAOSOCIAL";
         edtavEnderecocep_Internalname = sPrefix+"vENDERECOCEP";
         edtavEnderecologradouro_Internalname = sPrefix+"vENDERECOLOGRADOURO";
         edtavEndereconumero_Internalname = sPrefix+"vENDERECONUMERO";
         edtavEnderecobairro_Internalname = sPrefix+"vENDERECOBAIRRO";
         edtavEnderecocomplemento_Internalname = sPrefix+"vENDERECOCOMPLEMENTO";
         edtavContatoemail_Internalname = sPrefix+"vCONTATOEMAIL";
         edtavMunicipionome_Internalname = sPrefix+"vMUNICIPIONOME";
         edtavMunicipiouf_Internalname = sPrefix+"vMUNICIPIOUF";
         edtavContatoddd_Internalname = sPrefix+"vCONTATODDD";
         edtavContatonumero_Internalname = sPrefix+"vCONTATONUMERO";
         divTablecel_Internalname = sPrefix+"TABLECEL";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         edtavContatotelefoneddd_Internalname = sPrefix+"vCONTATOTELEFONEDDD";
         edtavContatotelefonenumero_Internalname = sPrefix+"vCONTATOTELEFONENUMERO";
         divTelefone_Internalname = sPrefix+"TELEFONE";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardlastnext_Internalname = sPrefix+"BTNWIZARDLASTNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         edtavMunicipiocodigo_Jsonclick = "";
         edtavMunicipiocodigo_Visible = 1;
         Btnwizardlastnext_Class = "Button ButtonWizard";
         Btnwizardlastnext_Caption = "Finalizar";
         Btnwizardlastnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardlastnext_Tooltiptext = "";
         Btnwizardprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardprevious_Caption = "Anterior";
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         edtavContatotelefonenumero_Jsonclick = "";
         edtavContatotelefonenumero_Enabled = 1;
         edtavContatotelefoneddd_Jsonclick = "";
         edtavContatotelefoneddd_Enabled = 1;
         edtavContatonumero_Jsonclick = "";
         edtavContatonumero_Enabled = 1;
         edtavContatoddd_Jsonclick = "";
         edtavContatoddd_Enabled = 1;
         edtavMunicipiouf_Jsonclick = "";
         edtavMunicipiouf_Enabled = 1;
         edtavMunicipionome_Jsonclick = "";
         edtavMunicipionome_Enabled = 1;
         edtavContatoemail_Jsonclick = "";
         edtavContatoemail_Enabled = 1;
         edtavEnderecocomplemento_Jsonclick = "";
         edtavEnderecocomplemento_Enabled = 1;
         edtavEnderecobairro_Jsonclick = "";
         edtavEnderecobairro_Enabled = 1;
         edtavEndereconumero_Jsonclick = "";
         edtavEndereconumero_Enabled = 1;
         edtavEnderecologradouro_Jsonclick = "";
         edtavEnderecologradouro_Enabled = 1;
         edtavEnderecocep_Jsonclick = "";
         edtavEnderecocep_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         edtavClientenomefantasia_Jsonclick = "";
         edtavClientenomefantasia_Enabled = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"}]}""");
         setEventMetadata("ENTER","""{"handler":"E128N2","iparms":[{"av":"AV23CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV12ClienteNomeFantasia","fld":"vCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV13ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV17EnderecoCEP","fld":"vENDERECOCEP","type":"svchar"},{"av":"AV14EnderecoLogradouro","fld":"vENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"AV15EnderecoNumero","fld":"vENDERECONUMERO","type":"svchar"},{"av":"AV16EnderecoBairro","fld":"vENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"AV19ContatoEmail","fld":"vCONTATOEMAIL","type":"svchar"},{"av":"AV20MunicipioNome","fld":"vMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV21MunicipioUF","fld":"vMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"AV26ContatoDDD","fld":"vCONTATODDD","pic":"ZZZ9","type":"int"},{"av":"AV27ContatoNumero","fld":"vCONTATONUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV18EnderecoComplemento","fld":"vENDERECOCOMPLEMENTO","type":"svchar"},{"av":"AV22MunicipioCodigo","fld":"vMUNICIPIOCODIGO","type":"svchar"},{"av":"AV24ContatoTelefoneDDD","fld":"vCONTATOTELEFONEDDD","pic":"ZZZ9","type":"int"},{"av":"AV25ContatoTelefoneNumero","fld":"vCONTATOTELEFONENUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV23CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E138N2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV12ClienteNomeFantasia","fld":"vCLIENTENOMEFANTASIA","pic":"@!","type":"svchar"},{"av":"AV13ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV17EnderecoCEP","fld":"vENDERECOCEP","type":"svchar"},{"av":"AV14EnderecoLogradouro","fld":"vENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"AV15EnderecoNumero","fld":"vENDERECONUMERO","type":"svchar"},{"av":"AV16EnderecoBairro","fld":"vENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"AV18EnderecoComplemento","fld":"vENDERECOCOMPLEMENTO","type":"svchar"},{"av":"AV19ContatoEmail","fld":"vCONTATOEMAIL","type":"svchar"},{"av":"AV20MunicipioNome","fld":"vMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV21MunicipioUF","fld":"vMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"AV22MunicipioCodigo","fld":"vMUNICIPIOCODIGO","type":"svchar"},{"av":"AV24ContatoTelefoneDDD","fld":"vCONTATOTELEFONEDDD","pic":"ZZZ9","type":"int"},{"av":"AV25ContatoTelefoneNumero","fld":"vCONTATOTELEFONENUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV26ContatoDDD","fld":"vCONTATODDD","pic":"ZZZ9","type":"int"},{"av":"AV27ContatoNumero","fld":"vCONTATONUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""}]}""");
         setEventMetadata("VALIDV_CONTATOEMAIL","""{"handler":"Validv_Contatoemail","iparms":[]}""");
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
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV12ClienteNomeFantasia = "";
         AV13ClienteRazaoSocial = "";
         AV17EnderecoCEP = "";
         AV14EnderecoLogradouro = "";
         AV15EnderecoNumero = "";
         AV16EnderecoBairro = "";
         AV18EnderecoComplemento = "";
         AV19ContatoEmail = "";
         AV20MunicipioNome = "";
         AV21MunicipioUF = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardlastnext = new GXUserControl();
         AV22MunicipioCodigo = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV11WizardData = new SdtContatoData(context);
         AV5WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short AV26ContatoDDD ;
      private short AV24ContatoTelefoneDDD ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavClientenomefantasia_Enabled ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavEnderecocep_Enabled ;
      private int edtavEnderecologradouro_Enabled ;
      private int edtavEndereconumero_Enabled ;
      private int edtavEnderecobairro_Enabled ;
      private int edtavEnderecocomplemento_Enabled ;
      private int edtavContatoemail_Enabled ;
      private int edtavMunicipionome_Enabled ;
      private int edtavMunicipiouf_Enabled ;
      private int edtavContatoddd_Enabled ;
      private int edtavContatonumero_Enabled ;
      private int edtavContatotelefoneddd_Enabled ;
      private int edtavContatotelefonenumero_Enabled ;
      private int edtavMunicipiocodigo_Visible ;
      private int idxLst ;
      private long AV27ContatoNumero ;
      private long AV25ContatoTelefoneNumero ;
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
      private string edtavClientenomefantasia_Internalname ;
      private string TempTags ;
      private string edtavClientenomefantasia_Jsonclick ;
      private string edtavClienterazaosocial_Internalname ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string edtavEnderecocep_Internalname ;
      private string edtavEnderecocep_Jsonclick ;
      private string edtavEnderecologradouro_Internalname ;
      private string edtavEnderecologradouro_Jsonclick ;
      private string edtavEndereconumero_Internalname ;
      private string edtavEndereconumero_Jsonclick ;
      private string edtavEnderecobairro_Internalname ;
      private string edtavEnderecobairro_Jsonclick ;
      private string edtavEnderecocomplemento_Internalname ;
      private string edtavEnderecocomplemento_Jsonclick ;
      private string edtavContatoemail_Internalname ;
      private string edtavContatoemail_Jsonclick ;
      private string edtavMunicipionome_Internalname ;
      private string edtavMunicipionome_Jsonclick ;
      private string edtavMunicipiouf_Internalname ;
      private string edtavMunicipiouf_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecel_Internalname ;
      private string edtavContatoddd_Internalname ;
      private string edtavContatoddd_Jsonclick ;
      private string edtavContatonumero_Internalname ;
      private string edtavContatonumero_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTelefone_Internalname ;
      private string edtavContatotelefoneddd_Internalname ;
      private string edtavContatotelefoneddd_Jsonclick ;
      private string edtavContatotelefonenumero_Internalname ;
      private string edtavContatotelefonenumero_Jsonclick ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Beforeiconclass ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string Btnwizardlastnext_Tooltiptext ;
      private string Btnwizardlastnext_Aftericonclass ;
      private string Btnwizardlastnext_Caption ;
      private string Btnwizardlastnext_Class ;
      private string Btnwizardlastnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavMunicipiocodigo_Internalname ;
      private string edtavMunicipiocodigo_Jsonclick ;
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
      private bool AV23CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV12ClienteNomeFantasia ;
      private string AV13ClienteRazaoSocial ;
      private string AV17EnderecoCEP ;
      private string AV14EnderecoLogradouro ;
      private string AV15EnderecoNumero ;
      private string AV16EnderecoBairro ;
      private string AV18EnderecoComplemento ;
      private string AV19ContatoEmail ;
      private string AV20MunicipioNome ;
      private string AV21MunicipioUF ;
      private string AV22MunicipioCodigo ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardlastnext ;
      private GXWebForm Form ;
      private IGxSession AV5WebSession ;
      private IGxDataStore dsDefault ;
      private SdtContatoData AV11WizardData ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
