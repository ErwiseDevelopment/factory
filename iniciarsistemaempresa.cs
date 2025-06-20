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
   public class iniciarsistemaempresa : GXWebComponent
   {
      public iniciarsistemaempresa( )
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

      public iniciarsistemaempresa( IGxContext context )
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
         cmbavEmpresapixtipo = new GXCombobox();
         cmbavEmpresasede = new GXCombobox();
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
            PA7K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS7K2( ) ;
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
            context.SendWebValue( "Iniciar Sistema Empresa") ;
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
            GXEncryptionTmp = "iniciarsistemaempresa"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("iniciarsistemaempresa") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPRESABANCOID_DATA", AV34EmpresaBancoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPRESABANCOID_DATA", AV34EmpresaBancoId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV37CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_EMPRESABANCOID_Selectedvalue_get", StringUtil.RTrim( Combo_empresabancoid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm7K2( )
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
         return "IniciarSistemaEmpresa" ;
      }

      public override string GetPgmdesc( )
      {
         return "Iniciar Sistema Empresa" ;
      }

      protected void WB7K0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "iniciarsistemaempresa");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresacnpj_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresacnpj_Internalname, "CNPJ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresacnpj_Internalname, AV12EmpresaCNPJ, StringUtil.RTrim( context.localUtil.Format( AV12EmpresaCNPJ, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresacnpj_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresacnpj_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresarazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresarazaosocial_Internalname, "Raz�o social", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresarazaosocial_Internalname, AV21EmpresaRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV21EmpresaRazaoSocial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresarazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresarazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresanomefantasia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresanomefantasia_Internalname, "Nome fantasia", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresanomefantasia_Internalname, AV18EmpresaNomeFantasia, StringUtil.RTrim( context.localUtil.Format( AV18EmpresaNomeFantasia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresanomefantasia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresanomefantasia_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresaemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresaemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresaemail_Internalname, AV17EmpresaEmail, StringUtil.RTrim( context.localUtil.Format( AV17EmpresaEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresaemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresaemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Conta / PIX", 1, 0, "px", 0, "px", "Group", "", "HLP_IniciarSistemaEmpresa.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontas_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedempresabancoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_empresabancoid_Internalname, "Banco", "", "", lblTextblockcombo_empresabancoid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_empresabancoid.SetProperty("Caption", Combo_empresabancoid_Caption);
            ucCombo_empresabancoid.SetProperty("Cls", Combo_empresabancoid_Cls);
            ucCombo_empresabancoid.SetProperty("EmptyItem", Combo_empresabancoid_Emptyitem);
            ucCombo_empresabancoid.SetProperty("DropDownOptionsData", AV34EmpresaBancoId_Data);
            ucCombo_empresabancoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_empresabancoid_Internalname, sPrefix+"COMBO_EMPRESABANCOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresaagencia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresaagencia_Internalname, "Ag�ncia", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresaagencia_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13EmpresaAgencia), 9, 0, ",", "")), StringUtil.LTrim( ((edtavEmpresaagencia_Enabled!=0) ? context.localUtil.Format( (decimal)(AV13EmpresaAgencia), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV13EmpresaAgencia), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresaagencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresaagencia_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresaagenciadigito_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresaagenciadigito_Internalname, "Digito", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresaagenciadigito_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14EmpresaAgenciaDigito), 9, 0, ",", "")), StringUtil.LTrim( ((edtavEmpresaagenciadigito_Enabled!=0) ? context.localUtil.Format( (decimal)(AV14EmpresaAgenciaDigito), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV14EmpresaAgenciaDigito), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresaagenciadigito_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresaagenciadigito_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresaconta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresaconta_Internalname, "Conta", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresaconta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16EmpresaConta), 8, 0, ",", "")), StringUtil.LTrim( ((edtavEmpresaconta_Enabled!=0) ? context.localUtil.Format( (decimal)(AV16EmpresaConta), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV16EmpresaConta), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,55);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresaconta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresaconta_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavEmpresapixtipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEmpresapixtipo_Internalname, "Tipo do pix", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEmpresapixtipo, cmbavEmpresapixtipo_Internalname, StringUtil.RTrim( AV20EmpresaPixTipo), 1, cmbavEmpresapixtipo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavEmpresapixtipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", false, 0, "HLP_IniciarSistemaEmpresa.htm");
            cmbavEmpresapixtipo.CurrentValue = StringUtil.RTrim( AV20EmpresaPixTipo);
            AssignProp(sPrefix, false, cmbavEmpresapixtipo_Internalname, "Values", (string)(cmbavEmpresapixtipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresapix_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresapix_Internalname, "Chave pix", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresapix_Internalname, AV19EmpresaPix, StringUtil.RTrim( context.localUtil.Format( AV19EmpresaPix, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresapix_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresapix_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_IniciarSistemaEmpresa.htm");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Endere�o", 1, 0, "px", 0, "px", "Group", "", "HLP_IniciarSistemaEmpresa.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableendereco_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresacep_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresacep_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresacep_Internalname, AV26EmpresaCEP, StringUtil.RTrim( context.localUtil.Format( AV26EmpresaCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresacep_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresacep_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresalogradouro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresalogradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresalogradouro_Internalname, AV28EmpresaLogradouro, StringUtil.RTrim( context.localUtil.Format( AV28EmpresaLogradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresalogradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresalogradouro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresalogradouronumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresalogradouronumero_Internalname, "N�mero", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresalogradouronumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29EmpresaLogradouroNumero), 10, 0, ",", "")), StringUtil.LTrim( ((edtavEmpresalogradouronumero_Enabled!=0) ? context.localUtil.Format( (decimal)(AV29EmpresaLogradouroNumero), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV29EmpresaLogradouroNumero), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,81);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresalogradouronumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresalogradouronumero_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresabairro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresabairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresabairro_Internalname, AV25EmpresaBairro, StringUtil.RTrim( context.localUtil.Format( AV25EmpresaBairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresabairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresabairro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresacomplemento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresacomplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresacomplemento_Internalname, AV27EmpresaComplemento, StringUtil.RTrim( context.localUtil.Format( AV27EmpresaComplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresacomplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresacomplemento_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMunicipionome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome_Internalname, "Municipio", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome_Internalname, AV31MunicipioNome, StringUtil.RTrim( context.localUtil.Format( AV31MunicipioNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,95);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMunicipionome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMunicipiouf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipiouf_Internalname, "UF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipiouf_Internalname, AV32MunicipioUF, StringUtil.RTrim( context.localUtil.Format( AV32MunicipioUF, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,99);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipiouf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMunicipiouf_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_IniciarSistemaEmpresa.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresabancoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15EmpresaBancoId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15EmpresaBancoId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,108);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresabancoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmpresabancoid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_IniciarSistemaEmpresa.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEmpresasede, cmbavEmpresasede_Internalname, StringUtil.BoolToStr( AV22EmpresaSede), 1, cmbavEmpresasede_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavEmpresasede.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "", false, 0, "HLP_IniciarSistemaEmpresa.htm");
            cmbavEmpresasede.CurrentValue = StringUtil.BoolToStr( AV22EmpresaSede);
            AssignProp(sPrefix, false, cmbavEmpresasede_Internalname, "Values", (string)(cmbavEmpresasede.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipiocodigo_Internalname, AV30MunicipioCodigo, StringUtil.RTrim( context.localUtil.Format( AV30MunicipioCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipiocodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipiocodigo_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_IniciarSistemaEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START7K2( )
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
            Form.Meta.addItem("description", "Iniciar Sistema Empresa", 0) ;
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
               STRUP7K0( ) ;
            }
         }
      }

      protected void WS7K2( )
      {
         START7K2( ) ;
         EVT7K2( ) ;
      }

      protected void EVT7K2( )
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
                                 STRUP7K0( ) ;
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
                                 STRUP7K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E117K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7K0( ) ;
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
                                          E127K2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VEMPRESACNPJ.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E137K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E147K2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP7K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavEmpresacnpj_Internalname;
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

      protected void WE7K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7K2( ) ;
            }
         }
      }

      protected void PA7K2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "iniciarsistemaempresa")), "iniciarsistemaempresa") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "iniciarsistemaempresa")))) ;
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
               GX_FocusControl = edtavEmpresacnpj_Internalname;
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
         if ( cmbavEmpresapixtipo.ItemCount > 0 )
         {
            AV20EmpresaPixTipo = cmbavEmpresapixtipo.getValidValue(AV20EmpresaPixTipo);
            AssignAttri(sPrefix, false, "AV20EmpresaPixTipo", AV20EmpresaPixTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEmpresapixtipo.CurrentValue = StringUtil.RTrim( AV20EmpresaPixTipo);
            AssignProp(sPrefix, false, cmbavEmpresapixtipo_Internalname, "Values", cmbavEmpresapixtipo.ToJavascriptSource(), true);
         }
         if ( cmbavEmpresasede.ItemCount > 0 )
         {
            AV22EmpresaSede = StringUtil.StrToBool( cmbavEmpresasede.getValidValue(StringUtil.BoolToStr( AV22EmpresaSede)));
            AssignAttri(sPrefix, false, "AV22EmpresaSede", AV22EmpresaSede);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEmpresasede.CurrentValue = StringUtil.BoolToStr( AV22EmpresaSede);
            AssignProp(sPrefix, false, cmbavEmpresasede_Internalname, "Values", cmbavEmpresasede.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E147K2 ();
            WB7K0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7K2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E117K2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vEMPRESABANCOID_DATA"), AV34EmpresaBancoId_Data);
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
         E117K2 ();
         if (returnInSub) return;
      }

      protected void E117K2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavEmpresabancoid_Visible = 0;
         AssignProp(sPrefix, false, edtavEmpresabancoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmpresabancoid_Visible), 5, 0), true);
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char1) ;
         Combo_empresabancoid_Htmltemplate = GXt_char1;
         ucCombo_empresabancoid.SendProperty(context, sPrefix, false, Combo_empresabancoid_Internalname, "HTMLTemplate", Combo_empresabancoid_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOEMPRESABANCOID' */
         S122 ();
         if (returnInSub) return;
         cmbavEmpresasede.Visible = 0;
         AssignProp(sPrefix, false, cmbavEmpresasede_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavEmpresasede.Visible), 5, 0), true);
         edtavMunicipiocodigo_Visible = 0;
         AssignProp(sPrefix, false, edtavMunicipiocodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipiocodigo_Visible), 5, 0), true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E127K2 ();
         if (returnInSub) return;
      }

      protected void E127K2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S132 ();
         if (returnInSub) return;
         if ( AV37CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S142 ();
            if (returnInSub) return;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "iniciarsistema"+UrlEncode(StringUtil.RTrim("Empresa")) + "," + UrlEncode(StringUtil.RTrim("Usuario")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("iniciarsistema") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV12EmpresaCNPJ = AV11WizardData.gxTpr_Empresa.gxTpr_Empresacnpj;
         AssignAttri(sPrefix, false, "AV12EmpresaCNPJ", AV12EmpresaCNPJ);
         AV21EmpresaRazaoSocial = AV11WizardData.gxTpr_Empresa.gxTpr_Empresarazaosocial;
         AssignAttri(sPrefix, false, "AV21EmpresaRazaoSocial", AV21EmpresaRazaoSocial);
         AV18EmpresaNomeFantasia = AV11WizardData.gxTpr_Empresa.gxTpr_Empresanomefantasia;
         AssignAttri(sPrefix, false, "AV18EmpresaNomeFantasia", AV18EmpresaNomeFantasia);
         AV17EmpresaEmail = AV11WizardData.gxTpr_Empresa.gxTpr_Empresaemail;
         AssignAttri(sPrefix, false, "AV17EmpresaEmail", AV17EmpresaEmail);
         AV22EmpresaSede = AV11WizardData.gxTpr_Empresa.gxTpr_Empresasede;
         AssignAttri(sPrefix, false, "AV22EmpresaSede", AV22EmpresaSede);
         AV26EmpresaCEP = AV11WizardData.gxTpr_Empresa.gxTpr_Empresacep;
         AssignAttri(sPrefix, false, "AV26EmpresaCEP", AV26EmpresaCEP);
         AV28EmpresaLogradouro = AV11WizardData.gxTpr_Empresa.gxTpr_Empresalogradouro;
         AssignAttri(sPrefix, false, "AV28EmpresaLogradouro", AV28EmpresaLogradouro);
         AV29EmpresaLogradouroNumero = AV11WizardData.gxTpr_Empresa.gxTpr_Empresalogradouronumero;
         AssignAttri(sPrefix, false, "AV29EmpresaLogradouroNumero", StringUtil.LTrimStr( (decimal)(AV29EmpresaLogradouroNumero), 10, 0));
         AV25EmpresaBairro = AV11WizardData.gxTpr_Empresa.gxTpr_Empresabairro;
         AssignAttri(sPrefix, false, "AV25EmpresaBairro", AV25EmpresaBairro);
         AV27EmpresaComplemento = AV11WizardData.gxTpr_Empresa.gxTpr_Empresacomplemento;
         AssignAttri(sPrefix, false, "AV27EmpresaComplemento", AV27EmpresaComplemento);
         AV30MunicipioCodigo = AV11WizardData.gxTpr_Empresa.gxTpr_Municipiocodigo;
         AssignAttri(sPrefix, false, "AV30MunicipioCodigo", AV30MunicipioCodigo);
         AV31MunicipioNome = AV11WizardData.gxTpr_Empresa.gxTpr_Municipionome;
         AssignAttri(sPrefix, false, "AV31MunicipioNome", AV31MunicipioNome);
         AV32MunicipioUF = AV11WizardData.gxTpr_Empresa.gxTpr_Municipiouf;
         AssignAttri(sPrefix, false, "AV32MunicipioUF", AV32MunicipioUF);
         AV15EmpresaBancoId = AV11WizardData.gxTpr_Empresa.gxTpr_Empresabancoid;
         AssignAttri(sPrefix, false, "AV15EmpresaBancoId", StringUtil.LTrimStr( (decimal)(AV15EmpresaBancoId), 9, 0));
         AV13EmpresaAgencia = AV11WizardData.gxTpr_Empresa.gxTpr_Empresaagencia;
         AssignAttri(sPrefix, false, "AV13EmpresaAgencia", StringUtil.LTrimStr( (decimal)(AV13EmpresaAgencia), 9, 0));
         AV14EmpresaAgenciaDigito = AV11WizardData.gxTpr_Empresa.gxTpr_Empresaagenciadigito;
         AssignAttri(sPrefix, false, "AV14EmpresaAgenciaDigito", StringUtil.LTrimStr( (decimal)(AV14EmpresaAgenciaDigito), 9, 0));
         AV16EmpresaConta = AV11WizardData.gxTpr_Empresa.gxTpr_Empresaconta;
         AssignAttri(sPrefix, false, "AV16EmpresaConta", StringUtil.LTrimStr( (decimal)(AV16EmpresaConta), 8, 0));
         AV20EmpresaPixTipo = AV11WizardData.gxTpr_Empresa.gxTpr_Empresapixtipo;
         AssignAttri(sPrefix, false, "AV20EmpresaPixTipo", AV20EmpresaPixTipo);
         AV19EmpresaPix = AV11WizardData.gxTpr_Empresa.gxTpr_Empresapix;
         AssignAttri(sPrefix, false, "AV19EmpresaPix", AV19EmpresaPix);
      }

      protected void S142( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresacnpj = AV12EmpresaCNPJ;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresarazaosocial = AV21EmpresaRazaoSocial;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresanomefantasia = AV18EmpresaNomeFantasia;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresaemail = AV17EmpresaEmail;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresasede = AV22EmpresaSede;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresacep = AV26EmpresaCEP;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresalogradouro = AV28EmpresaLogradouro;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresalogradouronumero = AV29EmpresaLogradouroNumero;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresabairro = AV25EmpresaBairro;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresacomplemento = AV27EmpresaComplemento;
         AV11WizardData.gxTpr_Empresa.gxTpr_Municipiocodigo = AV30MunicipioCodigo;
         AV11WizardData.gxTpr_Empresa.gxTpr_Municipionome = AV31MunicipioNome;
         AV11WizardData.gxTpr_Empresa.gxTpr_Municipiouf = AV32MunicipioUF;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresabancoid = AV15EmpresaBancoId;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresaagencia = AV13EmpresaAgencia;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresaagenciadigito = AV14EmpresaAgenciaDigito;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresaconta = AV16EmpresaConta;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresapixtipo = AV20EmpresaPixTipo;
         AV11WizardData.gxTpr_Empresa.gxTpr_Empresapix = AV19EmpresaPix;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV37CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV37CheckRequiredFieldsResult", AV37CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12EmpresaCNPJ)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "CNPJ", "", "", "", "", "", "", "", ""),  "error",  edtavEmpresacnpj_Internalname,  "true",  ""));
            AV37CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV37CheckRequiredFieldsResult", AV37CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21EmpresaRazaoSocial)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "Raz�o social", "", "", "", "", "", "", "", ""),  "error",  edtavEmpresarazaosocial_Internalname,  "true",  ""));
            AV37CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV37CheckRequiredFieldsResult", AV37CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17EmpresaEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 � obrigat�rio.", "E-mail", "", "", "", "", "", "", "", ""),  "error",  edtavEmpresaemail_Internalname,  "true",  ""));
            AV37CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV37CheckRequiredFieldsResult", AV37CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOEMPRESABANCOID' Routine */
         returnInSub = false;
         /* Using cursor H007K2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A402BancoId = H007K2_A402BancoId[0];
            A404BancoCodigo = H007K2_A404BancoCodigo[0];
            n404BancoCodigo = H007K2_n404BancoCodigo[0];
            A403BancoNome = H007K2_A403BancoNome[0];
            n403BancoNome = H007K2_n403BancoNome[0];
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A402BancoId), 9, 0));
            AV33ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV33ComboTitles.Add(A403BancoNome, 0);
            AV33ComboTitles.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(A404BancoCodigo), "ZZZZZZZZ9")), 0);
            AV36Combo_DataItem.gxTpr_Title = AV33ComboTitles.ToJSonString(false);
            AV34EmpresaBancoId_Data.Add(AV36Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_empresabancoid_Selectedvalue_set = ((0==AV15EmpresaBancoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV15EmpresaBancoId), 9, 0)));
         ucCombo_empresabancoid.SendProperty(context, sPrefix, false, Combo_empresabancoid_Internalname, "SelectedValue_set", Combo_empresabancoid_Selectedvalue_set);
      }

      protected void E137K2( )
      {
         /* Empresacnpj_Controlvaluechanged Routine */
         returnInSub = false;
         AV12EmpresaCNPJ = StringUtil.StringReplace( AV12EmpresaCNPJ, ".", "");
         AssignAttri(sPrefix, false, "AV12EmpresaCNPJ", AV12EmpresaCNPJ);
         AV12EmpresaCNPJ = StringUtil.StringReplace( AV12EmpresaCNPJ, "-", "");
         AssignAttri(sPrefix, false, "AV12EmpresaCNPJ", AV12EmpresaCNPJ);
         GXt_char1 = "";
         new prvalidcpf(context ).execute(  "JURIDICA",  AV12EmpresaCNPJ, out  AV23IsOK, out  GXt_char1) ;
         if ( ! AV23IsOK )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CNPJ inv�lido, verifique!",  "error",  edtavEmpresacnpj_Internalname,  "true",  ""));
         }
         else
         {
            new prgetempresaapi(context ).execute(  AV12EmpresaCNPJ, out  AV24SdEmpresas) ;
            AV18EmpresaNomeFantasia = AV24SdEmpresas.gxTpr_Alias;
            AssignAttri(sPrefix, false, "AV18EmpresaNomeFantasia", AV18EmpresaNomeFantasia);
            AV21EmpresaRazaoSocial = AV24SdEmpresas.gxTpr_Company.gxTpr_Name;
            AssignAttri(sPrefix, false, "AV21EmpresaRazaoSocial", AV21EmpresaRazaoSocial);
            AV28EmpresaLogradouro = AV24SdEmpresas.gxTpr_Address.gxTpr_Street;
            AssignAttri(sPrefix, false, "AV28EmpresaLogradouro", AV28EmpresaLogradouro);
            AV29EmpresaLogradouroNumero = (long)(Math.Round(NumberUtil.Val( AV24SdEmpresas.gxTpr_Address.gxTpr_Number, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV29EmpresaLogradouroNumero", StringUtil.LTrimStr( (decimal)(AV29EmpresaLogradouroNumero), 10, 0));
            AV25EmpresaBairro = AV24SdEmpresas.gxTpr_Address.gxTpr_District;
            AssignAttri(sPrefix, false, "AV25EmpresaBairro", AV25EmpresaBairro);
            AV26EmpresaCEP = AV24SdEmpresas.gxTpr_Address.gxTpr_Zip;
            AssignAttri(sPrefix, false, "AV26EmpresaCEP", AV26EmpresaCEP);
            AV27EmpresaComplemento = AV24SdEmpresas.gxTpr_Address.gxTpr_Details;
            AssignAttri(sPrefix, false, "AV27EmpresaComplemento", AV27EmpresaComplemento);
            AV17EmpresaEmail = ((SdtSdEmpresas_emailsItem)AV24SdEmpresas.gxTpr_Emails.Item(1)).gxTpr_Address;
            AssignAttri(sPrefix, false, "AV17EmpresaEmail", AV17EmpresaEmail);
            AV30MunicipioCodigo = StringUtil.Trim( StringUtil.Str( AV24SdEmpresas.gxTpr_Address.gxTpr_Municipality, 10, 5));
            AssignAttri(sPrefix, false, "AV30MunicipioCodigo", AV30MunicipioCodigo);
            AV31MunicipioNome = AV24SdEmpresas.gxTpr_Address.gxTpr_City;
            AssignAttri(sPrefix, false, "AV31MunicipioNome", AV31MunicipioNome);
            AV32MunicipioUF = AV24SdEmpresas.gxTpr_Address.gxTpr_State;
            AssignAttri(sPrefix, false, "AV32MunicipioUF", AV32MunicipioUF);
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E147K2( )
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
         PA7K2( ) ;
         WS7K2( ) ;
         WE7K2( ) ;
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
         PA7K2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "iniciarsistemaempresa", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA7K2( ) ;
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
         PA7K2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS7K2( ) ;
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
         WS7K2( ) ;
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
         WE7K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101964711", true, true);
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
         context.AddJavascriptSource("iniciarsistemaempresa.js", "?20256101964712", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavEmpresapixtipo.Name = "vEMPRESAPIXTIPO";
         cmbavEmpresapixtipo.WebTags = "";
         cmbavEmpresapixtipo.addItem("CPF", "CPF", 0);
         cmbavEmpresapixtipo.addItem("CNPJ", "CNPJ", 0);
         cmbavEmpresapixtipo.addItem("Telefone", "Telefone", 0);
         cmbavEmpresapixtipo.addItem("Email", "E-mail", 0);
         cmbavEmpresapixtipo.addItem("ChaveAleatoria", "Chave aleat�ria", 0);
         if ( cmbavEmpresapixtipo.ItemCount > 0 )
         {
         }
         cmbavEmpresasede.Name = "vEMPRESASEDE";
         cmbavEmpresasede.WebTags = "";
         cmbavEmpresasede.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavEmpresasede.addItem(StringUtil.BoolToStr( false), "N�o", 0);
         if ( cmbavEmpresasede.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavEmpresacnpj_Internalname = sPrefix+"vEMPRESACNPJ";
         edtavEmpresarazaosocial_Internalname = sPrefix+"vEMPRESARAZAOSOCIAL";
         edtavEmpresanomefantasia_Internalname = sPrefix+"vEMPRESANOMEFANTASIA";
         edtavEmpresaemail_Internalname = sPrefix+"vEMPRESAEMAIL";
         lblTextblockcombo_empresabancoid_Internalname = sPrefix+"TEXTBLOCKCOMBO_EMPRESABANCOID";
         Combo_empresabancoid_Internalname = sPrefix+"COMBO_EMPRESABANCOID";
         divTablesplittedempresabancoid_Internalname = sPrefix+"TABLESPLITTEDEMPRESABANCOID";
         edtavEmpresaagencia_Internalname = sPrefix+"vEMPRESAAGENCIA";
         edtavEmpresaagenciadigito_Internalname = sPrefix+"vEMPRESAAGENCIADIGITO";
         edtavEmpresaconta_Internalname = sPrefix+"vEMPRESACONTA";
         cmbavEmpresapixtipo_Internalname = sPrefix+"vEMPRESAPIXTIPO";
         edtavEmpresapix_Internalname = sPrefix+"vEMPRESAPIX";
         divTablecontas_Internalname = sPrefix+"TABLECONTAS";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         edtavEmpresacep_Internalname = sPrefix+"vEMPRESACEP";
         edtavEmpresalogradouro_Internalname = sPrefix+"vEMPRESALOGRADOURO";
         edtavEmpresalogradouronumero_Internalname = sPrefix+"vEMPRESALOGRADOURONUMERO";
         edtavEmpresabairro_Internalname = sPrefix+"vEMPRESABAIRRO";
         edtavEmpresacomplemento_Internalname = sPrefix+"vEMPRESACOMPLEMENTO";
         edtavMunicipionome_Internalname = sPrefix+"vMUNICIPIONOME";
         edtavMunicipiouf_Internalname = sPrefix+"vMUNICIPIOUF";
         divTableendereco_Internalname = sPrefix+"TABLEENDERECO";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavEmpresabancoid_Internalname = sPrefix+"vEMPRESABANCOID";
         cmbavEmpresasede_Internalname = sPrefix+"vEMPRESASEDE";
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
         Combo_empresabancoid_Htmltemplate = "";
         edtavMunicipiocodigo_Jsonclick = "";
         edtavMunicipiocodigo_Visible = 1;
         cmbavEmpresasede_Jsonclick = "";
         cmbavEmpresasede.Visible = 1;
         edtavEmpresabancoid_Jsonclick = "";
         edtavEmpresabancoid_Visible = 1;
         Btnwizardnext_Class = "Button ButtonWizard";
         Btnwizardnext_Caption = "Pr�ximo";
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         edtavMunicipiouf_Jsonclick = "";
         edtavMunicipiouf_Enabled = 1;
         edtavMunicipionome_Jsonclick = "";
         edtavMunicipionome_Enabled = 1;
         edtavEmpresacomplemento_Jsonclick = "";
         edtavEmpresacomplemento_Enabled = 1;
         edtavEmpresabairro_Jsonclick = "";
         edtavEmpresabairro_Enabled = 1;
         edtavEmpresalogradouronumero_Jsonclick = "";
         edtavEmpresalogradouronumero_Enabled = 1;
         edtavEmpresalogradouro_Jsonclick = "";
         edtavEmpresalogradouro_Enabled = 1;
         edtavEmpresacep_Jsonclick = "";
         edtavEmpresacep_Enabled = 1;
         edtavEmpresapix_Jsonclick = "";
         edtavEmpresapix_Enabled = 1;
         cmbavEmpresapixtipo_Jsonclick = "";
         cmbavEmpresapixtipo.Enabled = 1;
         edtavEmpresaconta_Jsonclick = "";
         edtavEmpresaconta_Enabled = 1;
         edtavEmpresaagenciadigito_Jsonclick = "";
         edtavEmpresaagenciadigito_Enabled = 1;
         edtavEmpresaagencia_Jsonclick = "";
         edtavEmpresaagencia_Enabled = 1;
         Combo_empresabancoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_empresabancoid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         edtavEmpresaemail_Jsonclick = "";
         edtavEmpresaemail_Enabled = 1;
         edtavEmpresanomefantasia_Jsonclick = "";
         edtavEmpresanomefantasia_Enabled = 1;
         edtavEmpresarazaosocial_Jsonclick = "";
         edtavEmpresarazaosocial_Enabled = 1;
         edtavEmpresacnpj_Jsonclick = "";
         edtavEmpresacnpj_Enabled = 1;
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
         setEventMetadata("ENTER","""{"handler":"E127K2","iparms":[{"av":"AV37CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV12EmpresaCNPJ","fld":"vEMPRESACNPJ","type":"svchar"},{"av":"AV21EmpresaRazaoSocial","fld":"vEMPRESARAZAOSOCIAL","type":"svchar"},{"av":"AV17EmpresaEmail","fld":"vEMPRESAEMAIL","type":"svchar"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV18EmpresaNomeFantasia","fld":"vEMPRESANOMEFANTASIA","type":"svchar"},{"av":"cmbavEmpresasede"},{"av":"AV22EmpresaSede","fld":"vEMPRESASEDE","type":"boolean"},{"av":"AV26EmpresaCEP","fld":"vEMPRESACEP","type":"svchar"},{"av":"AV28EmpresaLogradouro","fld":"vEMPRESALOGRADOURO","type":"svchar"},{"av":"AV29EmpresaLogradouroNumero","fld":"vEMPRESALOGRADOURONUMERO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV25EmpresaBairro","fld":"vEMPRESABAIRRO","type":"svchar"},{"av":"AV27EmpresaComplemento","fld":"vEMPRESACOMPLEMENTO","type":"svchar"},{"av":"AV30MunicipioCodigo","fld":"vMUNICIPIOCODIGO","type":"svchar"},{"av":"AV31MunicipioNome","fld":"vMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV32MunicipioUF","fld":"vMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"AV15EmpresaBancoId","fld":"vEMPRESABANCOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV13EmpresaAgencia","fld":"vEMPRESAAGENCIA","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV14EmpresaAgenciaDigito","fld":"vEMPRESAAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV16EmpresaConta","fld":"vEMPRESACONTA","pic":"ZZZZZZZ9","type":"int"},{"av":"cmbavEmpresapixtipo"},{"av":"AV20EmpresaPixTipo","fld":"vEMPRESAPIXTIPO","type":"svchar"},{"av":"AV19EmpresaPix","fld":"vEMPRESAPIX","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV37CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VEMPRESACNPJ.CONTROLVALUECHANGED","""{"handler":"E137K2","iparms":[{"av":"AV12EmpresaCNPJ","fld":"vEMPRESACNPJ","type":"svchar"}]""");
         setEventMetadata("VEMPRESACNPJ.CONTROLVALUECHANGED",""","oparms":[{"av":"AV12EmpresaCNPJ","fld":"vEMPRESACNPJ","type":"svchar"},{"av":"AV18EmpresaNomeFantasia","fld":"vEMPRESANOMEFANTASIA","type":"svchar"},{"av":"AV21EmpresaRazaoSocial","fld":"vEMPRESARAZAOSOCIAL","type":"svchar"},{"av":"AV28EmpresaLogradouro","fld":"vEMPRESALOGRADOURO","type":"svchar"},{"av":"AV29EmpresaLogradouroNumero","fld":"vEMPRESALOGRADOURONUMERO","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV25EmpresaBairro","fld":"vEMPRESABAIRRO","type":"svchar"},{"av":"AV26EmpresaCEP","fld":"vEMPRESACEP","type":"svchar"},{"av":"AV27EmpresaComplemento","fld":"vEMPRESACOMPLEMENTO","type":"svchar"},{"av":"AV17EmpresaEmail","fld":"vEMPRESAEMAIL","type":"svchar"},{"av":"AV30MunicipioCodigo","fld":"vMUNICIPIOCODIGO","type":"svchar"},{"av":"AV31MunicipioNome","fld":"vMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV32MunicipioUF","fld":"vMUNICIPIOUF","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALIDV_EMPRESAEMAIL","""{"handler":"Validv_Empresaemail","iparms":[]}""");
         setEventMetadata("VALIDV_EMPRESAPIXTIPO","""{"handler":"Validv_Empresapixtipo","iparms":[]}""");
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
         Combo_empresabancoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV34EmpresaBancoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV12EmpresaCNPJ = "";
         AV21EmpresaRazaoSocial = "";
         AV18EmpresaNomeFantasia = "";
         AV17EmpresaEmail = "";
         lblTextblockcombo_empresabancoid_Jsonclick = "";
         ucCombo_empresabancoid = new GXUserControl();
         Combo_empresabancoid_Caption = "";
         AV20EmpresaPixTipo = "";
         AV19EmpresaPix = "";
         AV26EmpresaCEP = "";
         AV28EmpresaLogradouro = "";
         AV25EmpresaBairro = "";
         AV27EmpresaComplemento = "";
         AV31MunicipioNome = "";
         AV32MunicipioUF = "";
         ucBtnwizardnext = new GXUserControl();
         AV30MunicipioCodigo = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV11WizardData = new SdtIniciarSistemaData(context);
         AV5WebSession = context.GetSession();
         H007K2_A402BancoId = new int[1] ;
         H007K2_A404BancoCodigo = new int[1] ;
         H007K2_n404BancoCodigo = new bool[] {false} ;
         H007K2_A403BancoNome = new string[] {""} ;
         H007K2_n403BancoNome = new bool[] {false} ;
         A403BancoNome = "";
         AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV33ComboTitles = new GxSimpleCollection<string>();
         Combo_empresabancoid_Selectedvalue_set = "";
         GXt_char1 = "";
         AV24SdEmpresas = new SdtSdEmpresas(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.iniciarsistemaempresa__default(),
            new Object[][] {
                new Object[] {
               H007K2_A402BancoId, H007K2_A404BancoCodigo, H007K2_n404BancoCodigo, H007K2_A403BancoNome, H007K2_n403BancoNome
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
      private int edtavEmpresacnpj_Enabled ;
      private int edtavEmpresarazaosocial_Enabled ;
      private int edtavEmpresanomefantasia_Enabled ;
      private int edtavEmpresaemail_Enabled ;
      private int AV13EmpresaAgencia ;
      private int edtavEmpresaagencia_Enabled ;
      private int AV14EmpresaAgenciaDigito ;
      private int edtavEmpresaagenciadigito_Enabled ;
      private int AV16EmpresaConta ;
      private int edtavEmpresaconta_Enabled ;
      private int edtavEmpresapix_Enabled ;
      private int edtavEmpresacep_Enabled ;
      private int edtavEmpresalogradouro_Enabled ;
      private int edtavEmpresalogradouronumero_Enabled ;
      private int edtavEmpresabairro_Enabled ;
      private int edtavEmpresacomplemento_Enabled ;
      private int edtavMunicipionome_Enabled ;
      private int edtavMunicipiouf_Enabled ;
      private int AV15EmpresaBancoId ;
      private int edtavEmpresabancoid_Visible ;
      private int edtavMunicipiocodigo_Visible ;
      private int A402BancoId ;
      private int A404BancoCodigo ;
      private int idxLst ;
      private long AV29EmpresaLogradouroNumero ;
      private string Combo_empresabancoid_Selectedvalue_get ;
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
      private string edtavEmpresacnpj_Internalname ;
      private string TempTags ;
      private string edtavEmpresacnpj_Jsonclick ;
      private string edtavEmpresarazaosocial_Internalname ;
      private string edtavEmpresarazaosocial_Jsonclick ;
      private string edtavEmpresanomefantasia_Internalname ;
      private string edtavEmpresanomefantasia_Jsonclick ;
      private string edtavEmpresaemail_Internalname ;
      private string edtavEmpresaemail_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontas_Internalname ;
      private string divTablesplittedempresabancoid_Internalname ;
      private string lblTextblockcombo_empresabancoid_Internalname ;
      private string lblTextblockcombo_empresabancoid_Jsonclick ;
      private string Combo_empresabancoid_Caption ;
      private string Combo_empresabancoid_Cls ;
      private string Combo_empresabancoid_Internalname ;
      private string edtavEmpresaagencia_Internalname ;
      private string edtavEmpresaagencia_Jsonclick ;
      private string edtavEmpresaagenciadigito_Internalname ;
      private string edtavEmpresaagenciadigito_Jsonclick ;
      private string edtavEmpresaconta_Internalname ;
      private string edtavEmpresaconta_Jsonclick ;
      private string cmbavEmpresapixtipo_Internalname ;
      private string cmbavEmpresapixtipo_Jsonclick ;
      private string edtavEmpresapix_Internalname ;
      private string edtavEmpresapix_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTableendereco_Internalname ;
      private string edtavEmpresacep_Internalname ;
      private string edtavEmpresacep_Jsonclick ;
      private string edtavEmpresalogradouro_Internalname ;
      private string edtavEmpresalogradouro_Jsonclick ;
      private string edtavEmpresalogradouronumero_Internalname ;
      private string edtavEmpresalogradouronumero_Jsonclick ;
      private string edtavEmpresabairro_Internalname ;
      private string edtavEmpresabairro_Jsonclick ;
      private string edtavEmpresacomplemento_Internalname ;
      private string edtavEmpresacomplemento_Jsonclick ;
      private string edtavMunicipionome_Internalname ;
      private string edtavMunicipionome_Jsonclick ;
      private string edtavMunicipiouf_Internalname ;
      private string edtavMunicipiouf_Jsonclick ;
      private string divTableactions_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Aftericonclass ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavEmpresabancoid_Internalname ;
      private string edtavEmpresabancoid_Jsonclick ;
      private string cmbavEmpresasede_Internalname ;
      private string cmbavEmpresasede_Jsonclick ;
      private string edtavMunicipiocodigo_Internalname ;
      private string edtavMunicipiocodigo_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Combo_empresabancoid_Htmltemplate ;
      private string Combo_empresabancoid_Selectedvalue_set ;
      private string GXt_char1 ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV37CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Combo_empresabancoid_Emptyitem ;
      private bool AV22EmpresaSede ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n404BancoCodigo ;
      private bool n403BancoNome ;
      private bool AV23IsOK ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV12EmpresaCNPJ ;
      private string AV21EmpresaRazaoSocial ;
      private string AV18EmpresaNomeFantasia ;
      private string AV17EmpresaEmail ;
      private string AV20EmpresaPixTipo ;
      private string AV19EmpresaPix ;
      private string AV26EmpresaCEP ;
      private string AV28EmpresaLogradouro ;
      private string AV25EmpresaBairro ;
      private string AV27EmpresaComplemento ;
      private string AV31MunicipioNome ;
      private string AV32MunicipioUF ;
      private string AV30MunicipioCodigo ;
      private string A403BancoNome ;
      private IGxSession AV5WebSession ;
      private GXUserControl ucCombo_empresabancoid ;
      private GXUserControl ucBtnwizardnext ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavEmpresapixtipo ;
      private GXCombobox cmbavEmpresasede ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV34EmpresaBancoId_Data ;
      private SdtIniciarSistemaData AV11WizardData ;
      private IDataStoreProvider pr_default ;
      private int[] H007K2_A402BancoId ;
      private int[] H007K2_A404BancoCodigo ;
      private bool[] H007K2_n404BancoCodigo ;
      private string[] H007K2_A403BancoNome ;
      private bool[] H007K2_n403BancoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV36Combo_DataItem ;
      private GxSimpleCollection<string> AV33ComboTitles ;
      private SdtSdEmpresas AV24SdEmpresas ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class iniciarsistemaempresa__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH007K2;
          prmH007K2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H007K2", "SELECT BancoId, BancoCodigo, BancoNome FROM Banco ORDER BY BancoNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007K2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
