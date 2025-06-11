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
   public class wpropostaproposta : GXWebComponent
   {
      public wpropostaproposta( )
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

      public wpropostaproposta( IGxContext context )
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
         cmbavConveniovencimentoano = new GXCombobox();
         cmbavConveniovencimentomes = new GXCombobox();
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
            PA6X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS6X2( ) ;
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
            context.SendWebValue( "WProposta Proposta") ;
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
            GXEncryptionTmp = "wpropostaproposta"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpropostaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPROCEDIMENTOSMEDICOSID_DATA", AV24ProcedimentosMedicosId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPROCEDIMENTOSMEDICOSID_DATA", AV24ProcedimentosMedicosId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCONVENIOID_DATA", AV30ConvenioId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCONVENIOID_DATA", AV30ConvenioId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCONVENIOCATEGORIAID_DATA", AV32ConvenioCategoriaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCONVENIOCATEGORIAID_DATA", AV32ConvenioCategoriaId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV16CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"CONVENIOCATEGORIADESCRICAO", A494ConvenioCategoriaDescricao);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"CONVENIOCATEGORIASTATUS", A495ConvenioCategoriaStatus);
         GxWebStd.gx_hidden_field( context, sPrefix+"CONVENIOCATEGORIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CONVENIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PROCEDIMENTOSMEDICOSID_Ddointernalname", StringUtil.RTrim( Combo_procedimentosmedicosid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_CONVENIOCATEGORIAID_Selectedvalue_get", StringUtil.RTrim( Combo_conveniocategoriaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_CONVENIOID_Selectedvalue_get", StringUtil.RTrim( Combo_convenioid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PROCEDIMENTOSMEDICOSID_Selectedvalue_get", StringUtil.RTrim( Combo_procedimentosmedicosid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PROCEDIMENTOSMEDICOSID_Ddointernalname", StringUtil.RTrim( Combo_procedimentosmedicosid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_CONVENIOID_Selectedvalue_get", StringUtil.RTrim( Combo_convenioid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm6X2( )
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
         return "WPropostaProposta" ;
      }

      public override string GetPgmdesc( )
      {
         return "WProposta Proposta" ;
      }

      protected void WB6X0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpropostaproposta");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedprocedimentosmedicosid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_procedimentosmedicosid_Internalname, "Procedimento", "", "", lblTextblockcombo_procedimentosmedicosid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPropostaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_procedimentosmedicosid.SetProperty("Caption", Combo_procedimentosmedicosid_Caption);
            ucCombo_procedimentosmedicosid.SetProperty("Cls", Combo_procedimentosmedicosid_Cls);
            ucCombo_procedimentosmedicosid.SetProperty("EmptyItem", Combo_procedimentosmedicosid_Emptyitem);
            ucCombo_procedimentosmedicosid.SetProperty("DropDownOptionsData", AV24ProcedimentosMedicosId_Data);
            ucCombo_procedimentosmedicosid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_procedimentosmedicosid_Internalname, sPrefix+"COMBO_PROCEDIMENTOSMEDICOSIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostavalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostavalor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostavalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV14PropostaValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavPropostavalor_Enabled!=0) ? context.localUtil.Format( AV14PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV14PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostavalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostavalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPropostaProposta.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostadescricao_Internalname, AV15PropostaDescricao, StringUtil.RTrim( context.localUtil.Format( AV15PropostaDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostadescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostadescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPropostaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbl1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconvenioid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_convenioid_Internalname, "Convênio", "", "", lblTextblockcombo_convenioid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPropostaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_convenioid.SetProperty("Caption", Combo_convenioid_Caption);
            ucCombo_convenioid.SetProperty("Cls", Combo_convenioid_Cls);
            ucCombo_convenioid.SetProperty("EmptyItem", Combo_convenioid_Emptyitem);
            ucCombo_convenioid.SetProperty("DropDownOptionsData", AV30ConvenioId_Data);
            ucCombo_convenioid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_convenioid_Internalname, sPrefix+"COMBO_CONVENIOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconveniocategoriaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_conveniocategoriaid_Internalname, "Categoria do convênio", "", "", lblTextblockcombo_conveniocategoriaid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPropostaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_conveniocategoriaid.SetProperty("Caption", Combo_conveniocategoriaid_Caption);
            ucCombo_conveniocategoriaid.SetProperty("Cls", Combo_conveniocategoriaid_Cls);
            ucCombo_conveniocategoriaid.SetProperty("EmptyItem", Combo_conveniocategoriaid_Emptyitem);
            ucCombo_conveniocategoriaid.SetProperty("DropDownOptionsData", AV32ConvenioCategoriaId_Data);
            ucCombo_conveniocategoriaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_conveniocategoriaid_Internalname, sPrefix+"COMBO_CONVENIOCATEGORIAIDContainer");
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
            GxWebStd.gx_div_start( context, divTableanomes_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavConveniovencimentoano_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConveniovencimentoano_Internalname, "Ano vencimento carteira", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConveniovencimentoano, cmbavConveniovencimentoano_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV33ConvenioVencimentoAno), 4, 0)), 1, cmbavConveniovencimentoano_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavConveniovencimentoano.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_WPropostaProposta.htm");
            cmbavConveniovencimentoano.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33ConvenioVencimentoAno), 4, 0));
            AssignProp(sPrefix, false, cmbavConveniovencimentoano_Internalname, "Values", (string)(cmbavConveniovencimentoano.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavConveniovencimentomes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConveniovencimentomes_Internalname, "Mês vencimento carteira", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConveniovencimentomes, cmbavConveniovencimentomes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV34ConvenioVencimentoMes), 4, 0)), 1, cmbavConveniovencimentomes_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavConveniovencimentomes.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 0, "HLP_WPropostaProposta.htm");
            cmbavConveniovencimentomes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34ConvenioVencimentoMes), 4, 0));
            AssignProp(sPrefix, false, cmbavConveniovencimentomes_Internalname, "Values", (string)(cmbavConveniovencimentomes.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProcedimentosmedicosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ProcedimentosMedicosId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22ProcedimentosMedicosId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProcedimentosmedicosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavProcedimentosmedicosid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPropostaProposta.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConvenioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ConvenioId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV29ConvenioId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,75);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConvenioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavConvenioid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPropostaProposta.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ConvenioCategoriaId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31ConvenioCategoriaId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavConveniocategoriaid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WPropostaProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6X2( )
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
            Form.Meta.addItem("description", "WProposta Proposta", 0) ;
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
               STRUP6X0( ) ;
            }
         }
      }

      protected void WS6X2( )
      {
         START6X2( ) ;
         EVT6X2( ) ;
      }

      protected void EVT6X2( )
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
                                 STRUP6X0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_CONVENIOID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_convenioid.Onoptionclicked */
                                    E116X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E126X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6X0( ) ;
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
                                          E136X2 ();
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
                                 STRUP6X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E146X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E156X2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavPropostavalor_Internalname;
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

      protected void WE6X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6X2( ) ;
            }
         }
      }

      protected void PA6X2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpropostaproposta")), "wpropostaproposta") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpropostaproposta")))) ;
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
               GX_FocusControl = edtavPropostavalor_Internalname;
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
         if ( cmbavConveniovencimentoano.ItemCount > 0 )
         {
            AV33ConvenioVencimentoAno = (short)(Math.Round(NumberUtil.Val( cmbavConveniovencimentoano.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV33ConvenioVencimentoAno), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV33ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV33ConvenioVencimentoAno), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConveniovencimentoano.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33ConvenioVencimentoAno), 4, 0));
            AssignProp(sPrefix, false, cmbavConveniovencimentoano_Internalname, "Values", cmbavConveniovencimentoano.ToJavascriptSource(), true);
         }
         if ( cmbavConveniovencimentomes.ItemCount > 0 )
         {
            AV34ConvenioVencimentoMes = (short)(Math.Round(NumberUtil.Val( cmbavConveniovencimentomes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV34ConvenioVencimentoMes), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV34ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV34ConvenioVencimentoMes), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConveniovencimentomes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34ConvenioVencimentoMes), 4, 0));
            AssignProp(sPrefix, false, cmbavConveniovencimentomes_Internalname, "Values", cmbavConveniovencimentomes.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF6X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E156X2 ();
            WB6X0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6X2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E126X2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPROCEDIMENTOSMEDICOSID_DATA"), AV24ProcedimentosMedicosId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCONVENIOID_DATA"), AV30ConvenioId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCONVENIOCATEGORIAID_DATA"), AV32ConvenioCategoriaId_Data);
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            Combo_procedimentosmedicosid_Ddointernalname = cgiGet( sPrefix+"COMBO_PROCEDIMENTOSMEDICOSID_Ddointernalname");
            Combo_convenioid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_CONVENIOID_Selectedvalue_get");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAVALOR");
               GX_FocusControl = edtavPropostavalor_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14PropostaValor = 0;
               AssignAttri(sPrefix, false, "AV14PropostaValor", StringUtil.LTrimStr( AV14PropostaValor, 18, 2));
            }
            else
            {
               AV14PropostaValor = context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".");
               AssignAttri(sPrefix, false, "AV14PropostaValor", StringUtil.LTrimStr( AV14PropostaValor, 18, 2));
            }
            AV15PropostaDescricao = cgiGet( edtavPropostadescricao_Internalname);
            AssignAttri(sPrefix, false, "AV15PropostaDescricao", AV15PropostaDescricao);
            cmbavConveniovencimentoano.CurrentValue = cgiGet( cmbavConveniovencimentoano_Internalname);
            AV33ConvenioVencimentoAno = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavConveniovencimentoano_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV33ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV33ConvenioVencimentoAno), 4, 0));
            cmbavConveniovencimentomes.CurrentValue = cgiGet( cmbavConveniovencimentomes_Internalname);
            AV34ConvenioVencimentoMes = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavConveniovencimentomes_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV34ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV34ConvenioVencimentoMes), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProcedimentosmedicosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProcedimentosmedicosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROCEDIMENTOSMEDICOSID");
               GX_FocusControl = edtavProcedimentosmedicosid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22ProcedimentosMedicosId = 0;
               AssignAttri(sPrefix, false, "AV22ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV22ProcedimentosMedicosId), 9, 0));
            }
            else
            {
               AV22ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavProcedimentosmedicosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV22ProcedimentosMedicosId), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConvenioid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConvenioid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONVENIOID");
               GX_FocusControl = edtavConvenioid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV29ConvenioId = 0;
               AssignAttri(sPrefix, false, "AV29ConvenioId", StringUtil.LTrimStr( (decimal)(AV29ConvenioId), 9, 0));
            }
            else
            {
               AV29ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavConvenioid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV29ConvenioId", StringUtil.LTrimStr( (decimal)(AV29ConvenioId), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConveniocategoriaid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConveniocategoriaid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONVENIOCATEGORIAID");
               GX_FocusControl = edtavConveniocategoriaid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31ConvenioCategoriaId = 0;
               AssignAttri(sPrefix, false, "AV31ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV31ConvenioCategoriaId), 9, 0));
            }
            else
            {
               AV31ConvenioCategoriaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavConveniocategoriaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV31ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV31ConvenioCategoriaId), 9, 0));
            }
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
         E126X2 ();
         if (returnInSub) return;
      }

      protected void E126X2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV21WwpContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV21WwpContext = GXt_SdtWWPContext1;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavConveniocategoriaid_Visible = 0;
         AssignProp(sPrefix, false, edtavConveniocategoriaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriaid_Visible), 5, 0), true);
         edtavConvenioid_Visible = 0;
         AssignProp(sPrefix, false, edtavConvenioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConvenioid_Visible), 5, 0), true);
         edtavProcedimentosmedicosid_Visible = 0;
         AssignProp(sPrefix, false, edtavProcedimentosmedicosid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProcedimentosmedicosid_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char2) ;
         Combo_procedimentosmedicosid_Htmltemplate = GXt_char2;
         ucCombo_procedimentosmedicosid.SendProperty(context, sPrefix, false, Combo_procedimentosmedicosid_Internalname, "HTMLTemplate", Combo_procedimentosmedicosid_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOPROCEDIMENTOSMEDICOSID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCONVENIOID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCONVENIOCATEGORIAID' */
         S142 ();
         if (returnInSub) return;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E136X2 ();
         if (returnInSub) return;
      }

      protected void E136X2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S152 ();
         if (returnInSub) return;
         if ( AV16CheckRequiredFieldsResult && ! AV10HasValidationErrors )
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
            GXEncryptionTmp = "wproposta"+UrlEncode(StringUtil.RTrim("Proposta")) + "," + UrlEncode(StringUtil.RTrim("Documentos")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("wproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E146X2( )
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
         GXEncryptionTmp = "wproposta"+UrlEncode(StringUtil.RTrim("Proposta")) + "," + UrlEncode(StringUtil.RTrim("Conta")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
      }

      protected void E116X2( )
      {
         /* Combo_convenioid_Onoptionclicked Routine */
         returnInSub = false;
         AV29ConvenioId = (int)(Math.Round(NumberUtil.Val( Combo_convenioid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri(sPrefix, false, "AV29ConvenioId", StringUtil.LTrimStr( (decimal)(AV29ConvenioId), 9, 0));
         /* Execute user subroutine: 'LOADCOMBOCONVENIOCATEGORIAID' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32ConvenioCategoriaId_Data", AV32ConvenioCategoriaId_Data);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV22ProcedimentosMedicosId = AV11WizardData.gxTpr_Proposta.gxTpr_Procedimentosmedicosid;
         AssignAttri(sPrefix, false, "AV22ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV22ProcedimentosMedicosId), 9, 0));
         AV14PropostaValor = AV11WizardData.gxTpr_Proposta.gxTpr_Propostavalor;
         AssignAttri(sPrefix, false, "AV14PropostaValor", StringUtil.LTrimStr( AV14PropostaValor, 18, 2));
         AV15PropostaDescricao = AV11WizardData.gxTpr_Proposta.gxTpr_Propostadescricao;
         AssignAttri(sPrefix, false, "AV15PropostaDescricao", AV15PropostaDescricao);
         AV29ConvenioId = AV11WizardData.gxTpr_Proposta.gxTpr_Convenioid;
         AssignAttri(sPrefix, false, "AV29ConvenioId", StringUtil.LTrimStr( (decimal)(AV29ConvenioId), 9, 0));
         AV31ConvenioCategoriaId = AV11WizardData.gxTpr_Proposta.gxTpr_Conveniocategoriaid;
         AssignAttri(sPrefix, false, "AV31ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV31ConvenioCategoriaId), 9, 0));
         AV33ConvenioVencimentoAno = AV11WizardData.gxTpr_Proposta.gxTpr_Conveniovencimentoano;
         AssignAttri(sPrefix, false, "AV33ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV33ConvenioVencimentoAno), 4, 0));
         AV34ConvenioVencimentoMes = AV11WizardData.gxTpr_Proposta.gxTpr_Conveniovencimentomes;
         AssignAttri(sPrefix, false, "AV34ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV34ConvenioVencimentoMes), 4, 0));
      }

      protected void S162( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Proposta.gxTpr_Procedimentosmedicosid = AV22ProcedimentosMedicosId;
         AV11WizardData.gxTpr_Proposta.gxTpr_Propostavalor = AV14PropostaValor;
         AV11WizardData.gxTpr_Proposta.gxTpr_Propostadescricao = AV15PropostaDescricao;
         AV11WizardData.gxTpr_Proposta.gxTpr_Convenioid = AV29ConvenioId;
         AV11WizardData.gxTpr_Proposta.gxTpr_Conveniocategoriaid = AV31ConvenioCategoriaId;
         AV11WizardData.gxTpr_Proposta.gxTpr_Conveniovencimentoano = AV33ConvenioVencimentoAno;
         AV11WizardData.gxTpr_Proposta.gxTpr_Conveniovencimentomes = AV34ConvenioVencimentoMes;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S152( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV16CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV16CheckRequiredFieldsResult", AV16CheckRequiredFieldsResult);
         if ( (0==AV22ProcedimentosMedicosId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Procedimento", "", "", "", "", "", "", "", ""),  "error",  Combo_procedimentosmedicosid_Ddointernalname,  "true",  ""));
            AV16CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV16CheckRequiredFieldsResult", AV16CheckRequiredFieldsResult);
         }
         if ( (Convert.ToDecimal(0)==AV14PropostaValor) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Valor", "", "", "", "", "", "", "", ""),  "error",  edtavPropostavalor_Internalname,  "true",  ""));
            AV16CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV16CheckRequiredFieldsResult", AV16CheckRequiredFieldsResult);
         }
      }

      protected void S142( )
      {
         /* 'LOADCOMBOCONVENIOCATEGORIAID' Routine */
         returnInSub = false;
         if ( 1 == 2 )
         {
            /* Using cursor H006X2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A495ConvenioCategoriaStatus = H006X2_A495ConvenioCategoriaStatus[0];
               n495ConvenioCategoriaStatus = H006X2_n495ConvenioCategoriaStatus[0];
               A493ConvenioCategoriaId = H006X2_A493ConvenioCategoriaId[0];
               A494ConvenioCategoriaDescricao = H006X2_A494ConvenioCategoriaDescricao[0];
               n494ConvenioCategoriaDescricao = H006X2_n494ConvenioCategoriaDescricao[0];
               AV26Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV26Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A493ConvenioCategoriaId), 9, 0));
               AV26Combo_DataItem.gxTpr_Title = A494ConvenioCategoriaDescricao;
               AV32ConvenioCategoriaId_Data.Add(AV26Combo_DataItem, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            Combo_conveniocategoriaid_Selectedvalue_set = ((0==AV31ConvenioCategoriaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV31ConvenioCategoriaId), 9, 0)));
            ucCombo_conveniocategoriaid.SendProperty(context, sPrefix, false, Combo_conveniocategoriaid_Internalname, "SelectedValue_set", Combo_conveniocategoriaid_Selectedvalue_set);
         }
         AV32ConvenioCategoriaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H006X3 */
         pr_default.execute(1, new Object[] {AV29ConvenioId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A495ConvenioCategoriaStatus = H006X3_A495ConvenioCategoriaStatus[0];
            n495ConvenioCategoriaStatus = H006X3_n495ConvenioCategoriaStatus[0];
            A410ConvenioId = H006X3_A410ConvenioId[0];
            n410ConvenioId = H006X3_n410ConvenioId[0];
            A493ConvenioCategoriaId = H006X3_A493ConvenioCategoriaId[0];
            A494ConvenioCategoriaDescricao = H006X3_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = H006X3_n494ConvenioCategoriaDescricao[0];
            AV26Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV26Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A493ConvenioCategoriaId), 9, 0));
            AV26Combo_DataItem.gxTpr_Title = A494ConvenioCategoriaDescricao;
            AV32ConvenioCategoriaId_Data.Add(AV26Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_conveniocategoriaid_Selectedvalue_set = ((0==AV31ConvenioCategoriaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV31ConvenioCategoriaId), 9, 0)));
         ucCombo_conveniocategoriaid.SendProperty(context, sPrefix, false, Combo_conveniocategoriaid_Internalname, "SelectedValue_set", Combo_conveniocategoriaid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCONVENIOID' Routine */
         returnInSub = false;
         /* Using cursor H006X4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A412ConvenioStatus = H006X4_A412ConvenioStatus[0];
            A410ConvenioId = H006X4_A410ConvenioId[0];
            n410ConvenioId = H006X4_n410ConvenioId[0];
            A411ConvenioDescricao = H006X4_A411ConvenioDescricao[0];
            n411ConvenioDescricao = H006X4_n411ConvenioDescricao[0];
            AV26Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV26Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A410ConvenioId), 9, 0));
            AV26Combo_DataItem.gxTpr_Title = A411ConvenioDescricao;
            AV30ConvenioId_Data.Add(AV26Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_convenioid_Selectedvalue_set = ((0==AV29ConvenioId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV29ConvenioId), 9, 0)));
         ucCombo_convenioid.SendProperty(context, sPrefix, false, Combo_convenioid_Internalname, "SelectedValue_set", Combo_convenioid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPROCEDIMENTOSMEDICOSID' Routine */
         returnInSub = false;
         /* Using cursor H006X5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A376ProcedimentosMedicosId = H006X5_A376ProcedimentosMedicosId[0];
            A379ProcedimentosMedicosArea = H006X5_A379ProcedimentosMedicosArea[0];
            n379ProcedimentosMedicosArea = H006X5_n379ProcedimentosMedicosArea[0];
            A377ProcedimentosMedicosNome = H006X5_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = H006X5_n377ProcedimentosMedicosNome[0];
            AV26Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV26Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A376ProcedimentosMedicosId), 9, 0));
            AV23ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV23ComboTitles.Add(A377ProcedimentosMedicosNome, 0);
            AV23ComboTitles.Add(A379ProcedimentosMedicosArea, 0);
            AV26Combo_DataItem.gxTpr_Title = AV23ComboTitles.ToJSonString(false);
            AV24ProcedimentosMedicosId_Data.Add(AV26Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_procedimentosmedicosid_Selectedvalue_set = ((0==AV22ProcedimentosMedicosId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV22ProcedimentosMedicosId), 9, 0)));
         ucCombo_procedimentosmedicosid.SendProperty(context, sPrefix, false, Combo_procedimentosmedicosid_Internalname, "SelectedValue_set", Combo_procedimentosmedicosid_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E156X2( )
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
         PA6X2( ) ;
         WS6X2( ) ;
         WE6X2( ) ;
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
         PA6X2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpropostaproposta", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6X2( ) ;
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
         PA6X2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6X2( ) ;
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
         WS6X2( ) ;
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
         WE6X2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101915366", true, true);
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
         context.AddJavascriptSource("wpropostaproposta.js", "?20256101915367", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
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
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
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
         cmbavConveniovencimentoano_Internalname = sPrefix+"vCONVENIOVENCIMENTOANO";
         cmbavConveniovencimentomes_Internalname = sPrefix+"vCONVENIOVENCIMENTOMES";
         divTableanomes_Internalname = sPrefix+"TABLEANOMES";
         divTbl1_Internalname = sPrefix+"TBL1";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = sPrefix+"DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavProcedimentosmedicosid_Internalname = sPrefix+"vPROCEDIMENTOSMEDICOSID";
         edtavConvenioid_Internalname = sPrefix+"vCONVENIOID";
         edtavConveniocategoriaid_Internalname = sPrefix+"vCONVENIOCATEGORIAID";
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
         Combo_procedimentosmedicosid_Htmltemplate = "";
         edtavConveniocategoriaid_Jsonclick = "";
         edtavConveniocategoriaid_Visible = 1;
         edtavConvenioid_Jsonclick = "";
         edtavConvenioid_Visible = 1;
         edtavProcedimentosmedicosid_Jsonclick = "";
         edtavProcedimentosmedicosid_Visible = 1;
         Btnwizardnext_Class = "Button ButtonWizard";
         Btnwizardnext_Caption = "Próximo";
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardprevious_Caption = "Anterior";
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         cmbavConveniovencimentomes_Jsonclick = "";
         cmbavConveniovencimentomes.Enabled = 1;
         cmbavConveniovencimentoano_Jsonclick = "";
         cmbavConveniovencimentoano.Enabled = 1;
         Combo_conveniocategoriaid_Emptyitem = Convert.ToBoolean( 0);
         Combo_conveniocategoriaid_Cls = "ExtendedCombo AttributeFL";
         Combo_convenioid_Emptyitem = Convert.ToBoolean( 0);
         Combo_convenioid_Cls = "ExtendedCombo AttributeFL";
         edtavPropostadescricao_Jsonclick = "";
         edtavPropostadescricao_Enabled = 1;
         edtavPropostavalor_Jsonclick = "";
         edtavPropostavalor_Enabled = 1;
         Combo_procedimentosmedicosid_Emptyitem = Convert.ToBoolean( 0);
         Combo_procedimentosmedicosid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"}]}""");
         setEventMetadata("ENTER","""{"handler":"E136X2","iparms":[{"av":"AV16CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV22ProcedimentosMedicosId","fld":"vPROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Combo_procedimentosmedicosid_Ddointernalname","ctrl":"COMBO_PROCEDIMENTOSMEDICOSID","prop":"DDOInternalName"},{"av":"AV14PropostaValor","fld":"vPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV15PropostaDescricao","fld":"vPROPOSTADESCRICAO","type":"svchar"},{"av":"AV29ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV31ConvenioCategoriaId","fld":"vCONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavConveniovencimentoano"},{"av":"AV33ConvenioVencimentoAno","fld":"vCONVENIOVENCIMENTOANO","pic":"ZZZ9","type":"int"},{"av":"cmbavConveniovencimentomes"},{"av":"AV34ConvenioVencimentoMes","fld":"vCONVENIOVENCIMENTOMES","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV16CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E146X2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV22ProcedimentosMedicosId","fld":"vPROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV14PropostaValor","fld":"vPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV15PropostaDescricao","fld":"vPROPOSTADESCRICAO","type":"svchar"},{"av":"AV29ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV31ConvenioCategoriaId","fld":"vCONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavConveniovencimentoano"},{"av":"AV33ConvenioVencimentoAno","fld":"vCONVENIOVENCIMENTOANO","pic":"ZZZ9","type":"int"},{"av":"cmbavConveniovencimentomes"},{"av":"AV34ConvenioVencimentoMes","fld":"vCONVENIOVENCIMENTOMES","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("COMBO_CONVENIOID.ONOPTIONCLICKED","""{"handler":"E116X2","iparms":[{"av":"Combo_convenioid_Selectedvalue_get","ctrl":"COMBO_CONVENIOID","prop":"SelectedValue_get"},{"av":"A494ConvenioCategoriaDescricao","fld":"CONVENIOCATEGORIADESCRICAO","type":"svchar"},{"av":"A495ConvenioCategoriaStatus","fld":"CONVENIOCATEGORIASTATUS","type":"boolean"},{"av":"A493ConvenioCategoriaId","fld":"CONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV32ConvenioCategoriaId_Data","fld":"vCONVENIOCATEGORIAID_DATA","type":""},{"av":"AV31ConvenioCategoriaId","fld":"vCONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A410ConvenioId","fld":"CONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV29ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("COMBO_CONVENIOID.ONOPTIONCLICKED",""","oparms":[{"av":"AV29ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV32ConvenioCategoriaId_Data","fld":"vCONVENIOCATEGORIAID_DATA","type":""},{"av":"Combo_conveniocategoriaid_Selectedvalue_set","ctrl":"COMBO_CONVENIOCATEGORIAID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("VALIDV_CONVENIOVENCIMENTOANO","""{"handler":"Validv_Conveniovencimentoano","iparms":[]}""");
         setEventMetadata("VALIDV_CONVENIOVENCIMENTOMES","""{"handler":"Validv_Conveniovencimentomes","iparms":[]}""");
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
         Combo_procedimentosmedicosid_Ddointernalname = "";
         Combo_conveniocategoriaid_Selectedvalue_get = "";
         Combo_convenioid_Selectedvalue_get = "";
         Combo_procedimentosmedicosid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV24ProcedimentosMedicosId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV30ConvenioId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV32ConvenioCategoriaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A494ConvenioCategoriaDescricao = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblockcombo_procedimentosmedicosid_Jsonclick = "";
         ucCombo_procedimentosmedicosid = new GXUserControl();
         Combo_procedimentosmedicosid_Caption = "";
         TempTags = "";
         AV15PropostaDescricao = "";
         lblTextblockcombo_convenioid_Jsonclick = "";
         ucCombo_convenioid = new GXUserControl();
         Combo_convenioid_Caption = "";
         lblTextblockcombo_conveniocategoriaid_Jsonclick = "";
         ucCombo_conveniocategoriaid = new GXUserControl();
         Combo_conveniocategoriaid_Caption = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV21WwpContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         AV11WizardData = new SdtWPropostaData(context);
         AV5WebSession = context.GetSession();
         H006X2_A495ConvenioCategoriaStatus = new bool[] {false} ;
         H006X2_n495ConvenioCategoriaStatus = new bool[] {false} ;
         H006X2_A493ConvenioCategoriaId = new int[1] ;
         H006X2_A494ConvenioCategoriaDescricao = new string[] {""} ;
         H006X2_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         AV26Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         Combo_conveniocategoriaid_Selectedvalue_set = "";
         H006X3_A495ConvenioCategoriaStatus = new bool[] {false} ;
         H006X3_n495ConvenioCategoriaStatus = new bool[] {false} ;
         H006X3_A410ConvenioId = new int[1] ;
         H006X3_n410ConvenioId = new bool[] {false} ;
         H006X3_A493ConvenioCategoriaId = new int[1] ;
         H006X3_A494ConvenioCategoriaDescricao = new string[] {""} ;
         H006X3_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         H006X4_A412ConvenioStatus = new bool[] {false} ;
         H006X4_A410ConvenioId = new int[1] ;
         H006X4_n410ConvenioId = new bool[] {false} ;
         H006X4_A411ConvenioDescricao = new string[] {""} ;
         H006X4_n411ConvenioDescricao = new bool[] {false} ;
         A411ConvenioDescricao = "";
         Combo_convenioid_Selectedvalue_set = "";
         H006X5_A376ProcedimentosMedicosId = new int[1] ;
         H006X5_A379ProcedimentosMedicosArea = new string[] {""} ;
         H006X5_n379ProcedimentosMedicosArea = new bool[] {false} ;
         H006X5_A377ProcedimentosMedicosNome = new string[] {""} ;
         H006X5_n377ProcedimentosMedicosNome = new bool[] {false} ;
         A379ProcedimentosMedicosArea = "";
         A377ProcedimentosMedicosNome = "";
         AV23ComboTitles = new GxSimpleCollection<string>();
         Combo_procedimentosmedicosid_Selectedvalue_set = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpropostaproposta__default(),
            new Object[][] {
                new Object[] {
               H006X2_A495ConvenioCategoriaStatus, H006X2_n495ConvenioCategoriaStatus, H006X2_A493ConvenioCategoriaId, H006X2_A494ConvenioCategoriaDescricao, H006X2_n494ConvenioCategoriaDescricao
               }
               , new Object[] {
               H006X3_A495ConvenioCategoriaStatus, H006X3_n495ConvenioCategoriaStatus, H006X3_A410ConvenioId, H006X3_n410ConvenioId, H006X3_A493ConvenioCategoriaId, H006X3_A494ConvenioCategoriaDescricao, H006X3_n494ConvenioCategoriaDescricao
               }
               , new Object[] {
               H006X4_A412ConvenioStatus, H006X4_A410ConvenioId, H006X4_A411ConvenioDescricao, H006X4_n411ConvenioDescricao
               }
               , new Object[] {
               H006X5_A376ProcedimentosMedicosId, H006X5_A379ProcedimentosMedicosArea, H006X5_n379ProcedimentosMedicosArea, H006X5_A377ProcedimentosMedicosNome, H006X5_n377ProcedimentosMedicosNome
               }
            }
         );
         /* GeneXus formulas. */
      }

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
      private short wbEnd ;
      private short wbStart ;
      private short AV33ConvenioVencimentoAno ;
      private short AV34ConvenioVencimentoMes ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A493ConvenioCategoriaId ;
      private int A410ConvenioId ;
      private int edtavPropostavalor_Enabled ;
      private int edtavPropostadescricao_Enabled ;
      private int AV22ProcedimentosMedicosId ;
      private int edtavProcedimentosmedicosid_Visible ;
      private int AV29ConvenioId ;
      private int edtavConvenioid_Visible ;
      private int AV31ConvenioCategoriaId ;
      private int edtavConveniocategoriaid_Visible ;
      private int A376ProcedimentosMedicosId ;
      private int idxLst ;
      private decimal AV14PropostaValor ;
      private string Combo_procedimentosmedicosid_Ddointernalname ;
      private string Combo_conveniocategoriaid_Selectedvalue_get ;
      private string Combo_convenioid_Selectedvalue_get ;
      private string Combo_procedimentosmedicosid_Selectedvalue_get ;
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
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTablesplittedprocedimentosmedicosid_Internalname ;
      private string lblTextblockcombo_procedimentosmedicosid_Internalname ;
      private string lblTextblockcombo_procedimentosmedicosid_Jsonclick ;
      private string Combo_procedimentosmedicosid_Caption ;
      private string Combo_procedimentosmedicosid_Cls ;
      private string Combo_procedimentosmedicosid_Internalname ;
      private string edtavPropostavalor_Internalname ;
      private string TempTags ;
      private string edtavPropostavalor_Jsonclick ;
      private string edtavPropostadescricao_Internalname ;
      private string edtavPropostadescricao_Jsonclick ;
      private string divTbl1_Internalname ;
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
      private string divTableanomes_Internalname ;
      private string cmbavConveniovencimentoano_Internalname ;
      private string cmbavConveniovencimentoano_Jsonclick ;
      private string cmbavConveniovencimentomes_Internalname ;
      private string cmbavConveniovencimentomes_Jsonclick ;
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
      private string edtavProcedimentosmedicosid_Internalname ;
      private string edtavProcedimentosmedicosid_Jsonclick ;
      private string edtavConvenioid_Internalname ;
      private string edtavConvenioid_Jsonclick ;
      private string edtavConveniocategoriaid_Internalname ;
      private string edtavConveniocategoriaid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Combo_procedimentosmedicosid_Htmltemplate ;
      private string GXt_char2 ;
      private string Combo_conveniocategoriaid_Selectedvalue_set ;
      private string Combo_convenioid_Selectedvalue_set ;
      private string Combo_procedimentosmedicosid_Selectedvalue_set ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV16CheckRequiredFieldsResult ;
      private bool A495ConvenioCategoriaStatus ;
      private bool wbLoad ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_procedimentosmedicosid_Emptyitem ;
      private bool Combo_convenioid_Emptyitem ;
      private bool Combo_conveniocategoriaid_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n495ConvenioCategoriaStatus ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n410ConvenioId ;
      private bool A412ConvenioStatus ;
      private bool n411ConvenioDescricao ;
      private bool n379ProcedimentosMedicosArea ;
      private bool n377ProcedimentosMedicosNome ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string A494ConvenioCategoriaDescricao ;
      private string AV15PropostaDescricao ;
      private string A411ConvenioDescricao ;
      private string A379ProcedimentosMedicosArea ;
      private string A377ProcedimentosMedicosNome ;
      private IGxSession AV5WebSession ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_procedimentosmedicosid ;
      private GXUserControl ucCombo_convenioid ;
      private GXUserControl ucCombo_conveniocategoriaid ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavConveniovencimentoano ;
      private GXCombobox cmbavConveniovencimentomes ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV24ProcedimentosMedicosId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV30ConvenioId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV32ConvenioCategoriaId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV21WwpContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private SdtWPropostaData AV11WizardData ;
      private IDataStoreProvider pr_default ;
      private bool[] H006X2_A495ConvenioCategoriaStatus ;
      private bool[] H006X2_n495ConvenioCategoriaStatus ;
      private int[] H006X2_A493ConvenioCategoriaId ;
      private string[] H006X2_A494ConvenioCategoriaDescricao ;
      private bool[] H006X2_n494ConvenioCategoriaDescricao ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV26Combo_DataItem ;
      private bool[] H006X3_A495ConvenioCategoriaStatus ;
      private bool[] H006X3_n495ConvenioCategoriaStatus ;
      private int[] H006X3_A410ConvenioId ;
      private bool[] H006X3_n410ConvenioId ;
      private int[] H006X3_A493ConvenioCategoriaId ;
      private string[] H006X3_A494ConvenioCategoriaDescricao ;
      private bool[] H006X3_n494ConvenioCategoriaDescricao ;
      private bool[] H006X4_A412ConvenioStatus ;
      private int[] H006X4_A410ConvenioId ;
      private bool[] H006X4_n410ConvenioId ;
      private string[] H006X4_A411ConvenioDescricao ;
      private bool[] H006X4_n411ConvenioDescricao ;
      private int[] H006X5_A376ProcedimentosMedicosId ;
      private string[] H006X5_A379ProcedimentosMedicosArea ;
      private bool[] H006X5_n379ProcedimentosMedicosArea ;
      private string[] H006X5_A377ProcedimentosMedicosNome ;
      private bool[] H006X5_n377ProcedimentosMedicosNome ;
      private GxSimpleCollection<string> AV23ComboTitles ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpropostaproposta__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH006X2;
          prmH006X2 = new Object[] {
          };
          Object[] prmH006X3;
          prmH006X3 = new Object[] {
          new ParDef("AV29ConvenioId",GXType.Int32,9,0)
          };
          Object[] prmH006X4;
          prmH006X4 = new Object[] {
          };
          Object[] prmH006X5;
          prmH006X5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H006X2", "SELECT ConvenioCategoriaStatus, ConvenioCategoriaId, ConvenioCategoriaDescricao FROM ConvenioCategoria WHERE ConvenioCategoriaStatus = TRUE ORDER BY ConvenioCategoriaDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006X2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006X3", "SELECT ConvenioCategoriaStatus, ConvenioId, ConvenioCategoriaId, ConvenioCategoriaDescricao FROM ConvenioCategoria WHERE (ConvenioCategoriaStatus = TRUE) AND (ConvenioId = :AV29ConvenioId) ORDER BY ConvenioCategoriaDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006X3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006X4", "SELECT ConvenioStatus, ConvenioId, ConvenioDescricao FROM Convenio WHERE ConvenioStatus = TRUE ORDER BY ConvenioDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006X4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006X5", "SELECT ProcedimentosMedicosId, ProcedimentosMedicosArea, ProcedimentosMedicosNome FROM ProcedimentosMedicos ORDER BY ProcedimentosMedicosNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006X5,100, GxCacheFrequency.OFF ,false,false )
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
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
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
       }
    }

 }

}
