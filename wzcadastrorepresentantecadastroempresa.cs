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
   public class wzcadastrorepresentantecadastroempresa : GXWebComponent
   {
      public wzcadastrorepresentantecadastroempresa( )
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

      public wzcadastrorepresentantecadastroempresa( IGxContext context )
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
         chkavCompanyisfound = new GXCheckbox();
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
            PA972( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavEmpresanome_Enabled = 0;
               AssignProp(sPrefix, false, edtavEmpresanome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresanome_Enabled), 5, 0), true);
               edtavEmpresaendereco_Enabled = 0;
               AssignProp(sPrefix, false, edtavEmpresaendereco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresaendereco_Enabled), 5, 0), true);
               edtavEmpresaatividadeeconomica_Enabled = 0;
               AssignProp(sPrefix, false, edtavEmpresaatividadeeconomica_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresaatividadeeconomica_Enabled), 5, 0), true);
               WS972( ) ;
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
            context.SendWebValue( "Wz Cadastro Representante Cadastro Empresa") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
            GXEncryptionTmp = "wzcadastrorepresentantecadastroempresa"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wzcadastrorepresentantecadastroempresa") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISVALID", AV22IsValid);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDEMPRESAS", AV16SdEmpresas);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDEMPRESAS", AV16SdEmpresas);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
      }

      protected void RenderHtmlCloseForm972( )
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
         return "WzCadastroRepresentanteCadastroEmpresa" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wz Cadastro Representante Cadastro Empresa" ;
      }

      protected void WB970( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wzcadastrorepresentantecadastroempresa");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCnpj_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCnpj_Internalname, "CNPJ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCnpj_Internalname, AV12CNPJ, StringUtil.RTrim( context.localUtil.Format( AV12CNPJ, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCnpj_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCnpj_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WzCadastroRepresentanteCadastroEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuasearch_Internalname, "", "Buscar Empresa", bttBtnuasearch_Jsonclick, 5, "Buscar Empresa", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUASEARCH\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WzCadastroRepresentanteCadastroEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Dados da Empresa", 1, 0, "px", 0, "px", grpUnnamedgroup1_Class, "", "HLP_WzCadastroRepresentanteCadastroEmpresa.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDadosempresa_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresanome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresanome_Internalname, "Nome da Empresa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresanome_Internalname, AV18EmpresaNome, StringUtil.RTrim( context.localUtil.Format( AV18EmpresaNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresanome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresanome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WzCadastroRepresentanteCadastroEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresaendereco_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresaendereco_Internalname, "Endereço da Empresa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresaendereco_Internalname, AV19EmpresaEndereco, StringUtil.RTrim( context.localUtil.Format( AV19EmpresaEndereco, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresaendereco_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresaendereco_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WzCadastroRepresentanteCadastroEmpresa.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmpresaatividadeeconomica_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmpresaatividadeeconomica_Internalname, "Atividade Economica da Empresa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresaatividadeeconomica_Internalname, AV20EmpresaAtividadeEconomica, StringUtil.RTrim( context.localUtil.Format( AV20EmpresaAtividadeEconomica, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresaatividadeeconomica_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresaatividadeeconomica_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WzCadastroRepresentanteCadastroEmpresa.htm");
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
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCompanyisfound_Internalname, StringUtil.BoolToStr( AV21CompanyIsFound), "", "", chkavCompanyisfound.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(55, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,55);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START972( )
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
            Form.Meta.addItem("description", "Wz Cadastro Representante Cadastro Empresa", 0) ;
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
               STRUP970( ) ;
            }
         }
      }

      protected void WS972( )
      {
         START972( ) ;
         EVT972( ) ;
      }

      protected void EVT972( )
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
                                 STRUP970( ) ;
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
                                 STRUP970( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11972 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP970( ) ;
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
                                          E12972 ();
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
                                 STRUP970( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E13972 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUASEARCH'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP970( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUaSearch' */
                                    E14972 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP970( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E15972 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP970( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavCnpj_Internalname;
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

      protected void WE972( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm972( ) ;
            }
         }
      }

      protected void PA972( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wzcadastrorepresentantecadastroempresa")), "wzcadastrorepresentantecadastroempresa") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wzcadastrorepresentantecadastroempresa")))) ;
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
               GX_FocusControl = edtavCnpj_Internalname;
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
         AV21CompanyIsFound = StringUtil.StrToBool( StringUtil.BoolToStr( AV21CompanyIsFound));
         AssignAttri(sPrefix, false, "AV21CompanyIsFound", AV21CompanyIsFound);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF972( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavEmpresanome_Enabled = 0;
         AssignProp(sPrefix, false, edtavEmpresanome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresanome_Enabled), 5, 0), true);
         edtavEmpresaendereco_Enabled = 0;
         AssignProp(sPrefix, false, edtavEmpresaendereco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresaendereco_Enabled), 5, 0), true);
         edtavEmpresaatividadeeconomica_Enabled = 0;
         AssignProp(sPrefix, false, edtavEmpresaatividadeeconomica_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresaatividadeeconomica_Enabled), 5, 0), true);
      }

      protected void RF972( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15972 ();
            WB970( ) ;
         }
      }

      protected void send_integrity_lvl_hashes972( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         edtavEmpresanome_Enabled = 0;
         AssignProp(sPrefix, false, edtavEmpresanome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresanome_Enabled), 5, 0), true);
         edtavEmpresaendereco_Enabled = 0;
         AssignProp(sPrefix, false, edtavEmpresaendereco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresaendereco_Enabled), 5, 0), true);
         edtavEmpresaatividadeeconomica_Enabled = 0;
         AssignProp(sPrefix, false, edtavEmpresaatividadeeconomica_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresaatividadeeconomica_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP970( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11972 ();
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
            AV12CNPJ = cgiGet( edtavCnpj_Internalname);
            AssignAttri(sPrefix, false, "AV12CNPJ", AV12CNPJ);
            AV18EmpresaNome = cgiGet( edtavEmpresanome_Internalname);
            AssignAttri(sPrefix, false, "AV18EmpresaNome", AV18EmpresaNome);
            AV19EmpresaEndereco = cgiGet( edtavEmpresaendereco_Internalname);
            AssignAttri(sPrefix, false, "AV19EmpresaEndereco", AV19EmpresaEndereco);
            AV20EmpresaAtividadeEconomica = cgiGet( edtavEmpresaatividadeeconomica_Internalname);
            AssignAttri(sPrefix, false, "AV20EmpresaAtividadeEconomica", AV20EmpresaAtividadeEconomica);
            AV21CompanyIsFound = StringUtil.StrToBool( cgiGet( chkavCompanyisfound_Internalname));
            AssignAttri(sPrefix, false, "AV21CompanyIsFound", AV21CompanyIsFound);
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
         E11972 ();
         if (returnInSub) return;
      }

      protected void E11972( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         chkavCompanyisfound.Visible = 0;
         AssignProp(sPrefix, false, chkavCompanyisfound_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavCompanyisfound.Visible), 5, 0), true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12972 ();
         if (returnInSub) return;
      }

      protected void E12972( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV10HasValidationErrors )
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

      protected void E13972( )
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
         GXEncryptionTmp = "wzcadastrorepresentante"+UrlEncode(StringUtil.RTrim("CadastroEmpresa")) + "," + UrlEncode(StringUtil.RTrim("CadastroRepresentante")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wzcadastrorepresentante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E14972( )
      {
         /* 'DoUaSearch' Routine */
         returnInSub = false;
         GXt_char1 = AV17CNPJDigitos;
         new prretornadigitos(context ).execute(  AV12CNPJ, out  GXt_char1) ;
         AV17CNPJDigitos = GXt_char1;
         new prvalidcpf(context ).execute(  "JURIDICA",  AV17CNPJDigitos, out  AV14IsCNPJValid, out  AV15ErrorMessage) ;
         if ( AV14IsCNPJValid )
         {
            GXt_SdtSdEmpresas2 = AV16SdEmpresas;
            GXt_char1 = "";
            new prretornadigitos(context ).execute(  AV17CNPJDigitos, out  GXt_char1) ;
            new prgetempresaapi(context ).execute(  GXt_char1, out  GXt_SdtSdEmpresas2) ;
            AV16SdEmpresas = GXt_SdtSdEmpresas2;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16SdEmpresas.gxTpr_Taxid)) )
            {
               AV21CompanyIsFound = true;
               AssignAttri(sPrefix, false, "AV21CompanyIsFound", AV21CompanyIsFound);
               /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
               S122 ();
               if (returnInSub) return;
               AV18EmpresaNome = StringUtil.Trim( AV16SdEmpresas.gxTpr_Company.gxTpr_Name);
               AssignAttri(sPrefix, false, "AV18EmpresaNome", AV18EmpresaNome);
               AV19EmpresaEndereco = StringUtil.Format( "%1, %2 - %3/%4", StringUtil.Trim( AV16SdEmpresas.gxTpr_Address.gxTpr_Street), StringUtil.Trim( AV16SdEmpresas.gxTpr_Address.gxTpr_Number), StringUtil.Trim( AV16SdEmpresas.gxTpr_Address.gxTpr_City), StringUtil.Trim( AV16SdEmpresas.gxTpr_Address.gxTpr_State), "", "", "", "", "");
               AssignAttri(sPrefix, false, "AV19EmpresaEndereco", AV19EmpresaEndereco);
               AV20EmpresaAtividadeEconomica = StringUtil.Trim( AV16SdEmpresas.gxTpr_Mainactivity.gxTpr_Text);
               AssignAttri(sPrefix, false, "AV20EmpresaAtividadeEconomica", AV20EmpresaAtividadeEconomica);
            }
            else
            {
               /* Execute user subroutine: 'RESETDADOSEMPRESA' */
               S152 ();
               if (returnInSub) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'RESETDADOSEMPRESA' */
            S152 ();
            if (returnInSub) return;
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CNPJ Inválido. Verifique!",  "error",  edtavCnpj_Internalname,  "true",  ""));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV16SdEmpresas", AV16SdEmpresas);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV12CNPJ = AV11WizardData.gxTpr_Cadastroempresa.gxTpr_Cnpj;
         AssignAttri(sPrefix, false, "AV12CNPJ", AV12CNPJ);
         AV21CompanyIsFound = AV11WizardData.gxTpr_Cadastroempresa.gxTpr_Companyisfound;
         AssignAttri(sPrefix, false, "AV21CompanyIsFound", AV21CompanyIsFound);
         AV18EmpresaNome = AV11WizardData.gxTpr_Cadastroempresa.gxTpr_Empresanome;
         AssignAttri(sPrefix, false, "AV18EmpresaNome", AV18EmpresaNome);
         AV19EmpresaEndereco = AV11WizardData.gxTpr_Cadastroempresa.gxTpr_Empresaendereco;
         AssignAttri(sPrefix, false, "AV19EmpresaEndereco", AV19EmpresaEndereco);
         AV20EmpresaAtividadeEconomica = AV11WizardData.gxTpr_Cadastroempresa.gxTpr_Empresaatividadeeconomica;
         AssignAttri(sPrefix, false, "AV20EmpresaAtividadeEconomica", AV20EmpresaAtividadeEconomica);
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Cadastroempresa.gxTpr_Cnpj = AV12CNPJ;
         AV11WizardData.gxTpr_Cadastroempresa.gxTpr_Companyisfound = AV21CompanyIsFound;
         AV11WizardData.gxTpr_Cadastroempresa.gxTpr_Empresanome = AV18EmpresaNome;
         AV11WizardData.gxTpr_Cadastroempresa.gxTpr_Empresaendereco = AV19EmpresaEndereco;
         AV11WizardData.gxTpr_Cadastroempresa.gxTpr_Empresaatividadeeconomica = AV20EmpresaAtividadeEconomica;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDADADOS' */
         S162 ();
         if (returnInSub) return;
         if ( AV22IsValid )
         {
            AV24SdCadastroRepresentante = new SdtSdCadastroRepresentante(context);
            AV24SdCadastroRepresentante.gxTpr_Nome = StringUtil.Trim( AV11WizardData.gxTpr_Cadastrorepresentante.gxTpr_Nome);
            AV24SdCadastroRepresentante.gxTpr_Cargo = StringUtil.Trim( AV11WizardData.gxTpr_Cadastrorepresentante.gxTpr_Cargo);
            AV24SdCadastroRepresentante.gxTpr_Celular = StringUtil.Trim( AV11WizardData.gxTpr_Cadastrorepresentante.gxTpr_Celular);
            AV24SdCadastroRepresentante.gxTpr_Cpf = StringUtil.Trim( AV11WizardData.gxTpr_Cadastrorepresentante.gxTpr_Cpf);
            AV24SdCadastroRepresentante.gxTpr_Email = StringUtil.Trim( AV11WizardData.gxTpr_Cadastrorepresentante.gxTpr_Email);
            AV24SdCadastroRepresentante.gxTpr_Empresacnpj = StringUtil.Trim( AV12CNPJ);
            GXt_SdtSdErro3 = AV25SdErro;
            new prcadastrarrepresentante(context ).execute(  "INS",  AV24SdCadastroRepresentante, out  GXt_SdtSdErro3) ;
            AV25SdErro = GXt_SdtSdErro3;
            if ( AV25SdErro.gxTpr_Status == 201 )
            {
               CallWebObject(formatLink("clienterepresentantesww") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Trim( AV25SdErro.gxTpr_Msg),  "error",  "",  "true",  ""));
            }
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( AV21CompanyIsFound ) ) )
         {
            grpUnnamedgroup1_Class = "Invisible";
            AssignProp(sPrefix, false, grpUnnamedgroup1_Internalname, "Class", grpUnnamedgroup1_Class, true);
         }
         else
         {
            grpUnnamedgroup1_Class = "Group";
            AssignProp(sPrefix, false, grpUnnamedgroup1_Internalname, "Class", grpUnnamedgroup1_Class, true);
         }
      }

      protected void S162( )
      {
         /* 'VALIDADADOS' Routine */
         returnInSub = false;
         AV22IsValid = true;
         AssignAttri(sPrefix, false, "AV22IsValid", AV22IsValid);
         if ( new prexisterepresentantecadastrado(context).executeUdp(  AV16SdEmpresas.gxTpr_Taxid) )
         {
            AV22IsValid = false;
            AssignAttri(sPrefix, false, "AV22IsValid", AV22IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Já existe uma empresa cadastrada com mesmo CNPJ. Verifique!",  "error",  "",  "true",  ""));
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11WizardData.gxTpr_Cadastrorepresentante.gxTpr_Nome)) )
         {
            AV22IsValid = false;
            AssignAttri(sPrefix, false, "AV22IsValid", AV22IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Nome do Representante é obrigatório!",  "error",  "",  "true",  ""));
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11WizardData.gxTpr_Cadastrorepresentante.gxTpr_Email)) )
         {
            AV22IsValid = false;
            AssignAttri(sPrefix, false, "AV22IsValid", AV22IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Email do Representante é obrigatório!",  "error",  "",  "true",  ""));
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11WizardData.gxTpr_Cadastrorepresentante.gxTpr_Celular)) )
         {
            AV22IsValid = false;
            AssignAttri(sPrefix, false, "AV22IsValid", AV22IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Celular do Representante é obrigatório!",  "error",  "",  "true",  ""));
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11WizardData.gxTpr_Cadastrorepresentante.gxTpr_Cpf)) )
         {
            AV22IsValid = false;
            AssignAttri(sPrefix, false, "AV22IsValid", AV22IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CPF do Representante é obrigatório!",  "error",  "",  "true",  ""));
         }
         if ( ! new prvalidaemail(context).executeUdp(  AV11WizardData.gxTpr_Cadastrorepresentante.gxTpr_Email) )
         {
            AV22IsValid = false;
            AssignAttri(sPrefix, false, "AV22IsValid", AV22IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Email do Representante inválido. Verifique!",  "error",  "",  "true",  ""));
         }
         new prvalidcpf(context ).execute(  "FISICA",  new prretornadigitos(context).executeUdp(  AV11WizardData.gxTpr_Cadastrorepresentante.gxTpr_Cpf), out  AV23IsCPFValid, out  AV15ErrorMessage) ;
         if ( ! AV23IsCPFValid )
         {
            AV22IsValid = false;
            AssignAttri(sPrefix, false, "AV22IsValid", AV22IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CPF do Representante inválido. Verifique!",  "error",  "",  "true",  ""));
         }
         if ( StringUtil.Len( new prretornadigitos(context).executeUdp(  AV11WizardData.gxTpr_Cadastrorepresentante.gxTpr_Celular)) < 10 )
         {
            AV22IsValid = false;
            AssignAttri(sPrefix, false, "AV22IsValid", AV22IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Telefone inválido. Digite um celular no padrão (99)9999-9999 ou (99)99999-9999",  "error",  "",  "true",  ""));
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12CNPJ)) )
         {
            AV22IsValid = false;
            AssignAttri(sPrefix, false, "AV22IsValid", AV22IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CNPJ da Empresa é obrigatório. Verifique!",  "error",  edtavCnpj_Internalname,  "true",  ""));
         }
         new prvalidcpf(context ).execute(  "JURIDICA",  new prretornadigitos(context).executeUdp(  AV12CNPJ), out  AV14IsCNPJValid, out  AV15ErrorMessage) ;
         if ( ! AV14IsCNPJValid )
         {
            AV22IsValid = false;
            AssignAttri(sPrefix, false, "AV22IsValid", AV22IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CNPJ da Empresa inválido. Verifique!",  "error",  edtavCnpj_Internalname,  "true",  ""));
         }
      }

      protected void S152( )
      {
         /* 'RESETDADOSEMPRESA' Routine */
         returnInSub = false;
         AV21CompanyIsFound = false;
         AssignAttri(sPrefix, false, "AV21CompanyIsFound", AV21CompanyIsFound);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         AV18EmpresaNome = "";
         AssignAttri(sPrefix, false, "AV18EmpresaNome", AV18EmpresaNome);
         AV19EmpresaEndereco = "";
         AssignAttri(sPrefix, false, "AV19EmpresaEndereco", AV19EmpresaEndereco);
         AV20EmpresaAtividadeEconomica = "";
         AssignAttri(sPrefix, false, "AV20EmpresaAtividadeEconomica", AV20EmpresaAtividadeEconomica);
      }

      protected void nextLoad( )
      {
      }

      protected void E15972( )
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
         PA972( ) ;
         WS972( ) ;
         WE972( ) ;
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
         PA972( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wzcadastrorepresentantecadastroempresa", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA972( ) ;
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
         PA972( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS972( ) ;
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
         WS972( ) ;
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
         WE972( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101964168", true, true);
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
         context.AddJavascriptSource("wzcadastrorepresentantecadastroempresa.js", "?20256101964168", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavCompanyisfound.Name = "vCOMPANYISFOUND";
         chkavCompanyisfound.WebTags = "";
         chkavCompanyisfound.Caption = "";
         AssignProp(sPrefix, false, chkavCompanyisfound_Internalname, "TitleCaption", chkavCompanyisfound.Caption, true);
         chkavCompanyisfound.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavCnpj_Internalname = sPrefix+"vCNPJ";
         bttBtnuasearch_Internalname = sPrefix+"BTNUASEARCH";
         edtavEmpresanome_Internalname = sPrefix+"vEMPRESANOME";
         edtavEmpresaendereco_Internalname = sPrefix+"vEMPRESAENDERECO";
         edtavEmpresaatividadeeconomica_Internalname = sPrefix+"vEMPRESAATIVIDADEECONOMICA";
         divDadosempresa_Internalname = sPrefix+"DADOSEMPRESA";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = sPrefix+"DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardlastnext_Internalname = sPrefix+"BTNWIZARDLASTNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         chkavCompanyisfound_Internalname = sPrefix+"vCOMPANYISFOUND";
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
         chkavCompanyisfound.Caption = "";
         chkavCompanyisfound.Visible = 1;
         Btnwizardlastnext_Class = "Button ButtonWizard";
         Btnwizardlastnext_Caption = "Finalizar";
         Btnwizardlastnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardlastnext_Tooltiptext = "";
         Btnwizardprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardprevious_Caption = "Anterior";
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         edtavEmpresaatividadeeconomica_Jsonclick = "";
         edtavEmpresaatividadeeconomica_Enabled = 1;
         edtavEmpresaendereco_Jsonclick = "";
         edtavEmpresaendereco_Enabled = 1;
         edtavEmpresanome_Jsonclick = "";
         edtavEmpresanome_Enabled = 1;
         grpUnnamedgroup1_Class = "Group";
         edtavCnpj_Jsonclick = "";
         edtavCnpj_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Cadastro da Empresa";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV21CompanyIsFound","fld":"vCOMPANYISFOUND","type":"boolean"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"}]}""");
         setEventMetadata("ENTER","""{"handler":"E12972","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV12CNPJ","fld":"vCNPJ","type":"svchar"},{"av":"AV21CompanyIsFound","fld":"vCOMPANYISFOUND","type":"boolean"},{"av":"AV18EmpresaNome","fld":"vEMPRESANOME","type":"svchar"},{"av":"AV19EmpresaEndereco","fld":"vEMPRESAENDERECO","type":"svchar"},{"av":"AV20EmpresaAtividadeEconomica","fld":"vEMPRESAATIVIDADEECONOMICA","type":"svchar"},{"av":"AV22IsValid","fld":"vISVALID","type":"boolean"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""},{"av":"AV16SdEmpresas","fld":"vSDEMPRESAS","type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""},{"av":"AV22IsValid","fld":"vISVALID","type":"boolean"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E13972","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV12CNPJ","fld":"vCNPJ","type":"svchar"},{"av":"AV21CompanyIsFound","fld":"vCOMPANYISFOUND","type":"boolean"},{"av":"AV18EmpresaNome","fld":"vEMPRESANOME","type":"svchar"},{"av":"AV19EmpresaEndereco","fld":"vEMPRESAENDERECO","type":"svchar"},{"av":"AV20EmpresaAtividadeEconomica","fld":"vEMPRESAATIVIDADEECONOMICA","type":"svchar"}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""}]}""");
         setEventMetadata("'DOUASEARCH'","""{"handler":"E14972","iparms":[{"av":"AV12CNPJ","fld":"vCNPJ","type":"svchar"},{"av":"AV21CompanyIsFound","fld":"vCOMPANYISFOUND","type":"boolean"}]""");
         setEventMetadata("'DOUASEARCH'",""","oparms":[{"av":"AV16SdEmpresas","fld":"vSDEMPRESAS","type":""},{"av":"AV21CompanyIsFound","fld":"vCOMPANYISFOUND","type":"boolean"},{"av":"AV18EmpresaNome","fld":"vEMPRESANOME","type":"svchar"},{"av":"AV19EmpresaEndereco","fld":"vEMPRESAENDERECO","type":"svchar"},{"av":"AV20EmpresaAtividadeEconomica","fld":"vEMPRESAATIVIDADEECONOMICA","type":"svchar"},{"av":"grpUnnamedgroup1_Class","ctrl":"UNNAMEDGROUP1","prop":"Class"}]}""");
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
         AV11WizardData = new SdtWzCadastroRepresentanteData(context);
         AV16SdEmpresas = new SdtSdEmpresas(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         AV12CNPJ = "";
         bttBtnuasearch_Jsonclick = "";
         AV18EmpresaNome = "";
         AV19EmpresaEndereco = "";
         AV20EmpresaAtividadeEconomica = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardlastnext = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV5WebSession = context.GetSession();
         AV17CNPJDigitos = "";
         AV15ErrorMessage = "";
         GXt_SdtSdEmpresas2 = new SdtSdEmpresas(context);
         GXt_char1 = "";
         AV24SdCadastroRepresentante = new SdtSdCadastroRepresentante(context);
         AV25SdErro = new SdtSdErro(context);
         GXt_SdtSdErro3 = new SdtSdErro(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         /* GeneXus formulas. */
         edtavEmpresanome_Enabled = 0;
         edtavEmpresaendereco_Enabled = 0;
         edtavEmpresaatividadeeconomica_Enabled = 0;
      }

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
      private int edtavEmpresanome_Enabled ;
      private int edtavEmpresaendereco_Enabled ;
      private int edtavEmpresaatividadeeconomica_Enabled ;
      private int edtavCnpj_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavEmpresanome_Internalname ;
      private string edtavEmpresaendereco_Internalname ;
      private string edtavEmpresaatividadeeconomica_Internalname ;
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
      private string edtavCnpj_Internalname ;
      private string TempTags ;
      private string edtavCnpj_Jsonclick ;
      private string bttBtnuasearch_Internalname ;
      private string bttBtnuasearch_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string grpUnnamedgroup1_Class ;
      private string divDadosempresa_Internalname ;
      private string edtavEmpresanome_Jsonclick ;
      private string edtavEmpresaendereco_Jsonclick ;
      private string edtavEmpresaatividadeeconomica_Jsonclick ;
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
      private string chkavCompanyisfound_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string GXt_char1 ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV22IsValid ;
      private bool wbLoad ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool AV21CompanyIsFound ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV14IsCNPJValid ;
      private bool AV23IsCPFValid ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV12CNPJ ;
      private string AV18EmpresaNome ;
      private string AV19EmpresaEndereco ;
      private string AV20EmpresaAtividadeEconomica ;
      private string AV17CNPJDigitos ;
      private string AV15ErrorMessage ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardlastnext ;
      private GXWebForm Form ;
      private IGxSession AV5WebSession ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCompanyisfound ;
      private SdtWzCadastroRepresentanteData AV11WizardData ;
      private SdtSdEmpresas AV16SdEmpresas ;
      private SdtSdEmpresas GXt_SdtSdEmpresas2 ;
      private SdtSdCadastroRepresentante AV24SdCadastroRepresentante ;
      private SdtSdErro AV25SdErro ;
      private SdtSdErro GXt_SdtSdErro3 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
