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
   public class wreembolso : GXDataArea
   {
      public wreembolso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wreembolso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId )
      {
         this.AV7PropostaId = aP0_PropostaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
         PA722( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START722( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wreembolso"+UrlEncode(StringUtil.LTrimStr(AV7PropostaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34ReembolsoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOPROTOCOLO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5ReembolsoProtocolo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSODATAABERTURACONVENIO", GetSecureSignedToken( "", AV6ReembolsoDataAberturaConvenio, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV11WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV11WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV11WWPContext, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISUPDATE", AV17IsUpdate);
         GxWebStd.gx_hidden_field( context, "gxhash_vISUPDATE", GetSecureSignedToken( "", AV17IsUpdate, context));
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", AV18ReembolsoPropostaPacienteClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ReembolsoPropostaPacienteClienteRazaoSocial, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONLINK", AV22NotificationLink);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONLINK", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22NotificationLink, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PropostaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WReembolso");
         forbiddenHiddens.Add("ReembolsoProtocolo", StringUtil.RTrim( context.localUtil.Format( AV5ReembolsoProtocolo, "")));
         forbiddenHiddens.Add("ReembolsoDataAberturaConvenio", context.localUtil.Format(AV6ReembolsoDataAberturaConvenio, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wreembolso:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34ReembolsoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vJSON", AV9JSON);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vREEMBOLSO", AV10Reembolso);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vREEMBOLSO", AV10Reembolso);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV11WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV11WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV11WWPContext, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARRAY_SDDOCUMENTOSREEMBOLSO", AV8Array_SdDocumentosReembolso);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARRAY_SDDOCUMENTOSREEMBOLSO", AV8Array_SdDocumentosReembolso);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISUPDATE", AV17IsUpdate);
         GxWebStd.gx_hidden_field( context, "gxhash_vISUPDATE", GetSecureSignedToken( "", AV17IsUpdate, context));
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", AV18ReembolsoPropostaPacienteClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ReembolsoPropostaPacienteClienteRazaoSocial, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONLINK", AV22NotificationLink);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONLINK", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22NotificationLink, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "APROVADORESSTATUS", A380AprovadoresStatus);
         GxWebStd.gx_hidden_field( context, "SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSEREMAIL", A144SecUserEmail);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARRAY_EMAIL", AV25Array_Email);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARRAY_EMAIL", AV25Array_Email);
         }
         GxWebStd.gx_hidden_field( context, "vMESSAGE", AV26message);
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
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
         if ( ! ( WebComp_Wcwcdocumentosobrigatoriosreembolso == null ) )
         {
            WebComp_Wcwcdocumentosobrigatoriosreembolso.componentjscripts();
         }
         if ( ! ( WebComp_Wcwctitulosproposta == null ) )
         {
            WebComp_Wcwctitulosproposta.componentjscripts();
         }
         if ( ! ( WebComp_Wcreembolsoassinaturasww == null ) )
         {
            WebComp_Wcreembolsoassinaturasww.componentjscripts();
         }
         if ( ! ( WebComp_Wcreembolsoflowlogww == null ) )
         {
            WebComp_Wcreembolsoflowlogww.componentjscripts();
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
            WE722( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT722( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wreembolso"+UrlEncode(StringUtil.LTrimStr(AV7PropostaId,9,0));
         return formatLink("wreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WReembolso" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reembolso" ;
      }

      protected void WB720( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnefetivar_Internalname, "", "Efetivar reembolso", bttBtnefetivar_Jsonclick, 5, "Efetivar reembolso", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEFETIVAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WReembolso.htm");
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
            GxWebStd.gx_label_ctrl( context, lblGeral_title_Internalname, "Informações gerais", "", "", lblGeral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WReembolso.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Geral") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablereembolso_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Paciente", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV30ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV30ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WReembolso.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento_Internalname, AV29ClienteDocumento, StringUtil.RTrim( context.localUtil.Format( AV29ClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientedocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WReembolso.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatoemail_Internalname, AV28ContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV28ContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatoemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsoprotocolo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoprotocolo_Internalname, "Protocolo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoprotocolo_Internalname, AV5ReembolsoProtocolo, StringUtil.RTrim( context.localUtil.Format( AV5ReembolsoProtocolo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoprotocolo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsoprotocolo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsodataaberturaconvenio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsodataaberturaconvenio_Internalname, "Data abertura no convênio", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavReembolsodataaberturaconvenio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavReembolsodataaberturaconvenio_Internalname, context.localUtil.Format(AV6ReembolsoDataAberturaConvenio, "99/99/9999"), context.localUtil.Format( AV6ReembolsoDataAberturaConvenio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsodataaberturaconvenio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsodataaberturaconvenio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WReembolso.htm");
            GxWebStd.gx_bitmap( context, edtavReembolsodataaberturaconvenio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavReembolsodataaberturaconvenio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WReembolso.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablevalores_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsopropostavalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsopropostavalor_Internalname, "Valor do procedimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsopropostavalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV27ReembolsoPropostaValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavReembolsopropostavalor_Enabled!=0) ? context.localUtil.Format( AV27ReembolsoPropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV27ReembolsoPropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsopropostavalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsopropostavalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsovalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsovalor_Internalname, "Valor do reembolso", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsovalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV32ReembolsoValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavReembolsovalor_Enabled!=0) ? context.localUtil.Format( AV32ReembolsoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV32ReembolsoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsovalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsovalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavValorsaldo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValorsaldo_Internalname, "Saldo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValorsaldo_Internalname, StringUtil.LTrim( StringUtil.NToC( AV33ValorSaldo, 18, 2, ",", "")), StringUtil.LTrim( ((edtavValorsaldo_Enabled!=0) ? context.localUtil.Format( AV33ValorSaldo, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV33ValorSaldo, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValorsaldo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavValorsaldo_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_WReembolso.htm");
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
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0068"+"", StringUtil.RTrim( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0068"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcdocumentosobrigatoriosreembolso), StringUtil.Lower( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0068"+"");
                  }
                  WebComp_Wcwcdocumentosobrigatoriosreembolso.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcdocumentosobrigatoriosreembolso), StringUtil.Lower( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitulos_title_Internalname, "Titulos", "", "", lblTitulos_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WReembolso.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Titulos") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0076"+"", StringUtil.RTrim( WebComp_Wcwctitulosproposta_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0076"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwctitulosproposta_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwctitulosproposta), StringUtil.Lower( WebComp_Wcwctitulosproposta_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0076"+"");
                  }
                  WebComp_Wcwctitulosproposta.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwctitulosproposta), StringUtil.Lower( WebComp_Wcwctitulosproposta_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAssinaturas_title_Internalname, "Assinaturas", "", "", lblAssinaturas_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WReembolso.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Assinaturas") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0084"+"", StringUtil.RTrim( WebComp_Wcreembolsoassinaturasww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0084"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcreembolsoassinaturasww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcreembolsoassinaturasww), StringUtil.Lower( WebComp_Wcreembolsoassinaturasww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0084"+"");
                  }
                  WebComp_Wcreembolsoassinaturasww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcreembolsoassinaturasww), StringUtil.Lower( WebComp_Wcreembolsoassinaturasww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEtapas_title_Internalname, "Histórico de passos", "", "", lblEtapas_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WReembolso.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Etapas") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0092"+"", StringUtil.RTrim( WebComp_Wcreembolsoflowlogww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0092"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcreembolsoflowlogww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcreembolsoflowlogww), StringUtil.Lower( WebComp_Wcreembolsoflowlogww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0092"+"");
                  }
                  WebComp_Wcreembolsoflowlogww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcreembolsoflowlogww), StringUtil.Lower( WebComp_Wcreembolsoflowlogww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START722( )
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
         Form.Meta.addItem("description", "Reembolso", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP720( ) ;
      }

      protected void WS722( )
      {
         START722( ) ;
         EVT722( ) ;
      }

      protected void EVT722( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11722 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEFETIVAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoEfetivar' */
                              E12722 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E13722 ();
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
                                    E14722 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E15722 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
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
                        if ( nCmpId == 68 )
                        {
                           OldWcwcdocumentosobrigatoriosreembolso = cgiGet( "W0068");
                           if ( ( StringUtil.Len( OldWcwcdocumentosobrigatoriosreembolso) == 0 ) || ( StringUtil.StrCmp(OldWcwcdocumentosobrigatoriosreembolso, WebComp_Wcwcdocumentosobrigatoriosreembolso_Component) != 0 ) )
                           {
                              WebComp_Wcwcdocumentosobrigatoriosreembolso = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcdocumentosobrigatoriosreembolso, new Object[] {context} );
                              WebComp_Wcwcdocumentosobrigatoriosreembolso.ComponentInit();
                              WebComp_Wcwcdocumentosobrigatoriosreembolso.Name = "OldWcwcdocumentosobrigatoriosreembolso";
                              WebComp_Wcwcdocumentosobrigatoriosreembolso_Component = OldWcwcdocumentosobrigatoriosreembolso;
                           }
                           if ( StringUtil.Len( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component) != 0 )
                           {
                              WebComp_Wcwcdocumentosobrigatoriosreembolso.componentprocess("W0068", "", sEvt);
                           }
                           WebComp_Wcwcdocumentosobrigatoriosreembolso_Component = OldWcwcdocumentosobrigatoriosreembolso;
                        }
                        else if ( nCmpId == 76 )
                        {
                           OldWcwctitulosproposta = cgiGet( "W0076");
                           if ( ( StringUtil.Len( OldWcwctitulosproposta) == 0 ) || ( StringUtil.StrCmp(OldWcwctitulosproposta, WebComp_Wcwctitulosproposta_Component) != 0 ) )
                           {
                              WebComp_Wcwctitulosproposta = getWebComponent(GetType(), "GeneXus.Programs", OldWcwctitulosproposta, new Object[] {context} );
                              WebComp_Wcwctitulosproposta.ComponentInit();
                              WebComp_Wcwctitulosproposta.Name = "OldWcwctitulosproposta";
                              WebComp_Wcwctitulosproposta_Component = OldWcwctitulosproposta;
                           }
                           if ( StringUtil.Len( WebComp_Wcwctitulosproposta_Component) != 0 )
                           {
                              WebComp_Wcwctitulosproposta.componentprocess("W0076", "", sEvt);
                           }
                           WebComp_Wcwctitulosproposta_Component = OldWcwctitulosproposta;
                        }
                        else if ( nCmpId == 84 )
                        {
                           OldWcreembolsoassinaturasww = cgiGet( "W0084");
                           if ( ( StringUtil.Len( OldWcreembolsoassinaturasww) == 0 ) || ( StringUtil.StrCmp(OldWcreembolsoassinaturasww, WebComp_Wcreembolsoassinaturasww_Component) != 0 ) )
                           {
                              WebComp_Wcreembolsoassinaturasww = getWebComponent(GetType(), "GeneXus.Programs", OldWcreembolsoassinaturasww, new Object[] {context} );
                              WebComp_Wcreembolsoassinaturasww.ComponentInit();
                              WebComp_Wcreembolsoassinaturasww.Name = "OldWcreembolsoassinaturasww";
                              WebComp_Wcreembolsoassinaturasww_Component = OldWcreembolsoassinaturasww;
                           }
                           if ( StringUtil.Len( WebComp_Wcreembolsoassinaturasww_Component) != 0 )
                           {
                              WebComp_Wcreembolsoassinaturasww.componentprocess("W0084", "", sEvt);
                           }
                           WebComp_Wcreembolsoassinaturasww_Component = OldWcreembolsoassinaturasww;
                        }
                        else if ( nCmpId == 92 )
                        {
                           OldWcreembolsoflowlogww = cgiGet( "W0092");
                           if ( ( StringUtil.Len( OldWcreembolsoflowlogww) == 0 ) || ( StringUtil.StrCmp(OldWcreembolsoflowlogww, WebComp_Wcreembolsoflowlogww_Component) != 0 ) )
                           {
                              WebComp_Wcreembolsoflowlogww = getWebComponent(GetType(), "GeneXus.Programs", OldWcreembolsoflowlogww, new Object[] {context} );
                              WebComp_Wcreembolsoflowlogww.ComponentInit();
                              WebComp_Wcreembolsoflowlogww.Name = "OldWcreembolsoflowlogww";
                              WebComp_Wcreembolsoflowlogww_Component = OldWcreembolsoflowlogww;
                           }
                           if ( StringUtil.Len( WebComp_Wcreembolsoflowlogww_Component) != 0 )
                           {
                              WebComp_Wcreembolsoflowlogww.componentprocess("W0092", "", sEvt);
                           }
                           WebComp_Wcreembolsoflowlogww_Component = OldWcreembolsoflowlogww;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE722( )
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

      protected void PA722( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wreembolso")), "wreembolso") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wreembolso")))) ;
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
                     AV7PropostaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV7PropostaId", StringUtil.LTrimStr( (decimal)(AV7PropostaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PropostaId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavClienterazaosocial_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         RF722( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavClientedocumento_Enabled = 0;
         AssignProp("", false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), true);
         edtavContatoemail_Enabled = 0;
         AssignProp("", false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
         edtavReembolsoprotocolo_Enabled = 0;
         AssignProp("", false, edtavReembolsoprotocolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsoprotocolo_Enabled), 5, 0), true);
         edtavReembolsodataaberturaconvenio_Enabled = 0;
         AssignProp("", false, edtavReembolsodataaberturaconvenio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsodataaberturaconvenio_Enabled), 5, 0), true);
         edtavReembolsopropostavalor_Enabled = 0;
         AssignProp("", false, edtavReembolsopropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsopropostavalor_Enabled), 5, 0), true);
         edtavReembolsovalor_Enabled = 0;
         AssignProp("", false, edtavReembolsovalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsovalor_Enabled), 5, 0), true);
         edtavValorsaldo_Enabled = 0;
         AssignProp("", false, edtavValorsaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValorsaldo_Enabled), 5, 0), true);
      }

      protected void RF722( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E13722 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component) != 0 )
               {
                  WebComp_Wcwcdocumentosobrigatoriosreembolso.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwctitulosproposta_Component) != 0 )
               {
                  WebComp_Wcwctitulosproposta.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcreembolsoassinaturasww_Component) != 0 )
               {
                  WebComp_Wcreembolsoassinaturasww.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcreembolsoflowlogww_Component) != 0 )
               {
                  WebComp_Wcreembolsoflowlogww.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15722 ();
            WB720( ) ;
         }
      }

      protected void send_integrity_lvl_hashes722( )
      {
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34ReembolsoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOPROTOCOLO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5ReembolsoProtocolo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSODATAABERTURACONVENIO", GetSecureSignedToken( "", AV6ReembolsoDataAberturaConvenio, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV11WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV11WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV11WWPContext, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISUPDATE", AV17IsUpdate);
         GxWebStd.gx_hidden_field( context, "gxhash_vISUPDATE", GetSecureSignedToken( "", AV17IsUpdate, context));
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", AV18ReembolsoPropostaPacienteClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ReembolsoPropostaPacienteClienteRazaoSocial, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONLINK", AV22NotificationLink);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICATIONLINK", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22NotificationLink, "")), context));
      }

      protected void before_start_formulas( )
      {
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavClientedocumento_Enabled = 0;
         AssignProp("", false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), true);
         edtavContatoemail_Enabled = 0;
         AssignProp("", false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
         edtavReembolsoprotocolo_Enabled = 0;
         AssignProp("", false, edtavReembolsoprotocolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsoprotocolo_Enabled), 5, 0), true);
         edtavReembolsodataaberturaconvenio_Enabled = 0;
         AssignProp("", false, edtavReembolsodataaberturaconvenio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsodataaberturaconvenio_Enabled), 5, 0), true);
         edtavReembolsopropostavalor_Enabled = 0;
         AssignProp("", false, edtavReembolsopropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsopropostavalor_Enabled), 5, 0), true);
         edtavReembolsovalor_Enabled = 0;
         AssignProp("", false, edtavReembolsovalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsovalor_Enabled), 5, 0), true);
         edtavValorsaldo_Enabled = 0;
         AssignProp("", false, edtavValorsaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValorsaldo_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP720( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11722 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vARRAY_SDDOCUMENTOSREEMBOLSO"), AV8Array_SdDocumentosReembolso);
            /* Read saved values. */
            AV9JSON = cgiGet( "vJSON");
            Gxuitabspanel_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
            /* Read variables values. */
            AV30ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AssignAttri("", false, "AV30ClienteRazaoSocial", AV30ClienteRazaoSocial);
            AV29ClienteDocumento = cgiGet( edtavClientedocumento_Internalname);
            AssignAttri("", false, "AV29ClienteDocumento", AV29ClienteDocumento);
            AV28ContatoEmail = cgiGet( edtavContatoemail_Internalname);
            AssignAttri("", false, "AV28ContatoEmail", AV28ContatoEmail);
            AV5ReembolsoProtocolo = cgiGet( edtavReembolsoprotocolo_Internalname);
            AssignAttri("", false, "AV5ReembolsoProtocolo", AV5ReembolsoProtocolo);
            GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOPROTOCOLO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5ReembolsoProtocolo, "")), context));
            if ( context.localUtil.VCDate( cgiGet( edtavReembolsodataaberturaconvenio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Reembolso Data Abertura Convenio"}), 1, "vREEMBOLSODATAABERTURACONVENIO");
               GX_FocusControl = edtavReembolsodataaberturaconvenio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6ReembolsoDataAberturaConvenio = DateTime.MinValue;
               AssignAttri("", false, "AV6ReembolsoDataAberturaConvenio", context.localUtil.Format(AV6ReembolsoDataAberturaConvenio, "99/99/9999"));
               GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSODATAABERTURACONVENIO", GetSecureSignedToken( "", AV6ReembolsoDataAberturaConvenio, context));
            }
            else
            {
               AV6ReembolsoDataAberturaConvenio = context.localUtil.CToD( cgiGet( edtavReembolsodataaberturaconvenio_Internalname), 2);
               AssignAttri("", false, "AV6ReembolsoDataAberturaConvenio", context.localUtil.Format(AV6ReembolsoDataAberturaConvenio, "99/99/9999"));
               GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSODATAABERTURACONVENIO", GetSecureSignedToken( "", AV6ReembolsoDataAberturaConvenio, context));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavReembolsopropostavalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavReembolsopropostavalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREEMBOLSOPROPOSTAVALOR");
               GX_FocusControl = edtavReembolsopropostavalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27ReembolsoPropostaValor = 0;
               AssignAttri("", false, "AV27ReembolsoPropostaValor", StringUtil.LTrimStr( AV27ReembolsoPropostaValor, 18, 2));
            }
            else
            {
               AV27ReembolsoPropostaValor = context.localUtil.CToN( cgiGet( edtavReembolsopropostavalor_Internalname), ",", ".");
               AssignAttri("", false, "AV27ReembolsoPropostaValor", StringUtil.LTrimStr( AV27ReembolsoPropostaValor, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavReembolsovalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavReembolsovalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREEMBOLSOVALOR");
               GX_FocusControl = edtavReembolsovalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV32ReembolsoValor = 0;
               AssignAttri("", false, "AV32ReembolsoValor", StringUtil.LTrimStr( AV32ReembolsoValor, 18, 2));
            }
            else
            {
               AV32ReembolsoValor = context.localUtil.CToN( cgiGet( edtavReembolsovalor_Internalname), ",", ".");
               AssignAttri("", false, "AV32ReembolsoValor", StringUtil.LTrimStr( AV32ReembolsoValor, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValorsaldo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValorsaldo_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALORSALDO");
               GX_FocusControl = edtavValorsaldo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV33ValorSaldo = 0;
               AssignAttri("", false, "AV33ValorSaldo", StringUtil.LTrimStr( AV33ValorSaldo, 18, 2));
            }
            else
            {
               AV33ValorSaldo = context.localUtil.CToN( cgiGet( edtavValorsaldo_Internalname), ",", ".");
               AssignAttri("", false, "AV33ValorSaldo", StringUtil.LTrimStr( AV33ValorSaldo, 18, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"WReembolso");
            AV5ReembolsoProtocolo = cgiGet( edtavReembolsoprotocolo_Internalname);
            AssignAttri("", false, "AV5ReembolsoProtocolo", AV5ReembolsoProtocolo);
            GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOPROTOCOLO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5ReembolsoProtocolo, "")), context));
            forbiddenHiddens.Add("ReembolsoProtocolo", StringUtil.RTrim( context.localUtil.Format( AV5ReembolsoProtocolo, "")));
            AV6ReembolsoDataAberturaConvenio = context.localUtil.CToD( cgiGet( edtavReembolsodataaberturaconvenio_Internalname), 2);
            AssignAttri("", false, "AV6ReembolsoDataAberturaConvenio", context.localUtil.Format(AV6ReembolsoDataAberturaConvenio, "99/99/9999"));
            GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSODATAABERTURACONVENIO", GetSecureSignedToken( "", AV6ReembolsoDataAberturaConvenio, context));
            forbiddenHiddens.Add("ReembolsoDataAberturaConvenio", context.localUtil.Format(AV6ReembolsoDataAberturaConvenio, "99/99/9999"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wreembolso:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11722 ();
         if (returnInSub) return;
      }

      protected void E11722( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV11WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV11WWPContext = GXt_SdtWWPContext1;
         AV17IsUpdate = false;
         AssignAttri("", false, "AV17IsUpdate", AV17IsUpdate);
         GxWebStd.gx_hidden_field( context, "gxhash_vISUPDATE", GetSecureSignedToken( "", AV17IsUpdate, context));
         AV8Array_SdDocumentosReembolso = new GXBaseCollection<SdtSdDocumentosReembolso>( context, "SdDocumentosReembolso", "Factory21");
         AV35GXLvl8 = 0;
         /* Using cursor H00723 */
         pr_default.execute(0, new Object[] {AV7PropostaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A518ReembolsoId = H00723_A518ReembolsoId[0];
            n518ReembolsoId = H00723_n518ReembolsoId[0];
            A542ReembolsoPropostaId = H00723_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = H00723_n542ReembolsoPropostaId[0];
            A546ReembolsoProtocolo = H00723_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = H00723_n546ReembolsoProtocolo[0];
            A525ReembolsoDataAberturaConvenio = H00723_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = H00723_n525ReembolsoDataAberturaConvenio[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = H00723_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = H00723_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A543ReembolsoPropostaValor = H00723_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = H00723_n543ReembolsoPropostaValor[0];
            A558ReembolsoPropostaPacienteClienteId = H00723_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = H00723_n558ReembolsoPropostaPacienteClienteId[0];
            A645ReembolsoValorReembolsado_F = H00723_A645ReembolsoValorReembolsado_F[0];
            n645ReembolsoValorReembolsado_F = H00723_n645ReembolsoValorReembolsado_F[0];
            A645ReembolsoValorReembolsado_F = H00723_A645ReembolsoValorReembolsado_F[0];
            n645ReembolsoValorReembolsado_F = H00723_n645ReembolsoValorReembolsado_F[0];
            A543ReembolsoPropostaValor = H00723_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = H00723_n543ReembolsoPropostaValor[0];
            A558ReembolsoPropostaPacienteClienteId = H00723_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = H00723_n558ReembolsoPropostaPacienteClienteId[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = H00723_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = H00723_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            AV35GXLvl8 = 1;
            AV34ReembolsoId = A518ReembolsoId;
            AssignAttri("", false, "AV34ReembolsoId", StringUtil.LTrimStr( (decimal)(AV34ReembolsoId), 9, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34ReembolsoId), "ZZZZZZZZ9"), context));
            AV10Reembolso.Load(A518ReembolsoId);
            AV17IsUpdate = true;
            AssignAttri("", false, "AV17IsUpdate", AV17IsUpdate);
            GxWebStd.gx_hidden_field( context, "gxhash_vISUPDATE", GetSecureSignedToken( "", AV17IsUpdate, context));
            AV5ReembolsoProtocolo = A546ReembolsoProtocolo;
            AssignAttri("", false, "AV5ReembolsoProtocolo", AV5ReembolsoProtocolo);
            GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOPROTOCOLO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5ReembolsoProtocolo, "")), context));
            AV6ReembolsoDataAberturaConvenio = A525ReembolsoDataAberturaConvenio;
            AssignAttri("", false, "AV6ReembolsoDataAberturaConvenio", context.localUtil.Format(AV6ReembolsoDataAberturaConvenio, "99/99/9999"));
            GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSODATAABERTURACONVENIO", GetSecureSignedToken( "", AV6ReembolsoDataAberturaConvenio, context));
            AV18ReembolsoPropostaPacienteClienteRazaoSocial = A550ReembolsoPropostaPacienteClienteRazaoSocial;
            AssignAttri("", false, "AV18ReembolsoPropostaPacienteClienteRazaoSocial", AV18ReembolsoPropostaPacienteClienteRazaoSocial);
            GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ReembolsoPropostaPacienteClienteRazaoSocial, "@!")), context));
            AV27ReembolsoPropostaValor = A543ReembolsoPropostaValor;
            AssignAttri("", false, "AV27ReembolsoPropostaValor", StringUtil.LTrimStr( AV27ReembolsoPropostaValor, 18, 2));
            AV32ReembolsoValor = A645ReembolsoValorReembolsado_F;
            AssignAttri("", false, "AV32ReembolsoValor", StringUtil.LTrimStr( AV32ReembolsoValor, 18, 2));
            AV33ValorSaldo = (decimal)(AV27ReembolsoPropostaValor-AV32ReembolsoValor);
            AssignAttri("", false, "AV33ValorSaldo", StringUtil.LTrimStr( AV33ValorSaldo, 18, 2));
            /* Using cursor H00724 */
            pr_default.execute(1, new Object[] {n518ReembolsoId, A518ReembolsoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A526ReembolsoEtapaId = H00724_A526ReembolsoEtapaId[0];
               n526ReembolsoEtapaId = H00724_n526ReembolsoEtapaId[0];
               A530ReembolsoDocumentoNome = H00724_A530ReembolsoDocumentoNome[0];
               n530ReembolsoDocumentoNome = H00724_n530ReembolsoDocumentoNome[0];
               A532ReembolsoDocumentoBlobExt = H00724_A532ReembolsoDocumentoBlobExt[0];
               n532ReembolsoDocumentoBlobExt = H00724_n532ReembolsoDocumentoBlobExt[0];
               A405DocumentosId = H00724_A405DocumentosId[0];
               n405DocumentosId = H00724_n405DocumentosId[0];
               A529ReembolsoDocumentoId = H00724_A529ReembolsoDocumentoId[0];
               A549ReembolsoDocumentoStatus = H00724_A549ReembolsoDocumentoStatus[0];
               n549ReembolsoDocumentoStatus = H00724_n549ReembolsoDocumentoStatus[0];
               A531ReembolsoDocumentoBlob = H00724_A531ReembolsoDocumentoBlob[0];
               n531ReembolsoDocumentoBlob = H00724_n531ReembolsoDocumentoBlob[0];
               AV13SdDocumentosReembolso = new SdtSdDocumentosReembolso(context);
               AV13SdDocumentosReembolso.gxTpr_Documentonome = A530ReembolsoDocumentoNome;
               AV13SdDocumentosReembolso.gxTpr_Documentoblob = A531ReembolsoDocumentoBlob;
               AV13SdDocumentosReembolso.gxTpr_Documentoextensao = A532ReembolsoDocumentoBlobExt;
               AV13SdDocumentosReembolso.gxTpr_Documentosid = A405DocumentosId;
               AV13SdDocumentosReembolso.gxTpr_Reembolsodocumentoid = A529ReembolsoDocumentoId;
               AV13SdDocumentosReembolso.gxTpr_Reembolsodocumentostatus = A549ReembolsoDocumentoStatus;
               AV13SdDocumentosReembolso.gxTpr_Isupdated = false;
               AV8Array_SdDocumentosReembolso.Add(AV13SdDocumentosReembolso, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV31ReembolsoPropostaPacienteClienteId = A558ReembolsoPropostaPacienteClienteId;
            AssignAttri("", false, "AV31ReembolsoPropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(AV31ReembolsoPropostaPacienteClienteId), 9, 0));
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV35GXLvl8 == 0 )
         {
            /* Using cursor H00725 */
            pr_default.execute(2, new Object[] {AV7PropostaId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A504PropostaPacienteClienteId = H00725_A504PropostaPacienteClienteId[0];
               n504PropostaPacienteClienteId = H00725_n504PropostaPacienteClienteId[0];
               A323PropostaId = H00725_A323PropostaId[0];
               A505PropostaPacienteClienteRazaoSocial = H00725_A505PropostaPacienteClienteRazaoSocial[0];
               n505PropostaPacienteClienteRazaoSocial = H00725_n505PropostaPacienteClienteRazaoSocial[0];
               A505PropostaPacienteClienteRazaoSocial = H00725_A505PropostaPacienteClienteRazaoSocial[0];
               n505PropostaPacienteClienteRazaoSocial = H00725_n505PropostaPacienteClienteRazaoSocial[0];
               AV18ReembolsoPropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
               AssignAttri("", false, "AV18ReembolsoPropostaPacienteClienteRazaoSocial", AV18ReembolsoPropostaPacienteClienteRazaoSocial);
               GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ReembolsoPropostaPacienteClienteRazaoSocial, "@!")), context));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV10Reembolso = new SdtReembolso(context);
         }
         /* Using cursor H00726 */
         pr_default.execute(3, new Object[] {AV31ReembolsoPropostaPacienteClienteId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A168ClienteId = H00726_A168ClienteId[0];
            A170ClienteRazaoSocial = H00726_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H00726_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = H00726_A169ClienteDocumento[0];
            n169ClienteDocumento = H00726_n169ClienteDocumento[0];
            A201ContatoEmail = H00726_A201ContatoEmail[0];
            n201ContatoEmail = H00726_n201ContatoEmail[0];
            AV30ClienteRazaoSocial = A170ClienteRazaoSocial;
            AssignAttri("", false, "AV30ClienteRazaoSocial", AV30ClienteRazaoSocial);
            AV29ClienteDocumento = A169ClienteDocumento;
            AssignAttri("", false, "AV29ClienteDocumento", AV29ClienteDocumento);
            AV28ContatoEmail = A201ContatoEmail;
            AssignAttri("", false, "AV28ContatoEmail", AV28ContatoEmail);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         AV16INJSON = AV8Array_SdDocumentosReembolso.ToJSonString(false);
         if ( 1 == 2 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcreembolsoflowlogww = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcreembolsoflowlogww_Component), StringUtil.Lower( "ReembolsoFlowLogWW")) != 0 )
            {
               WebComp_Wcreembolsoflowlogww = getWebComponent(GetType(), "GeneXus.Programs", "reembolsoflowlogww", new Object[] {context} );
               WebComp_Wcreembolsoflowlogww.ComponentInit();
               WebComp_Wcreembolsoflowlogww.Name = "ReembolsoFlowLogWW";
               WebComp_Wcreembolsoflowlogww_Component = "ReembolsoFlowLogWW";
            }
            if ( StringUtil.Len( WebComp_Wcreembolsoflowlogww_Component) != 0 )
            {
               WebComp_Wcreembolsoflowlogww.setjustcreated();
               WebComp_Wcreembolsoflowlogww.componentprepare(new Object[] {(string)"W0092",(string)"",(int)AV34ReembolsoId});
               WebComp_Wcreembolsoflowlogww.componentbind(new Object[] {(string)""});
            }
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcreembolsoassinaturasww = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcreembolsoassinaturasww_Component), StringUtil.Lower( "ReembolsoAssinaturasWW")) != 0 )
            {
               WebComp_Wcreembolsoassinaturasww = getWebComponent(GetType(), "GeneXus.Programs", "reembolsoassinaturasww", new Object[] {context} );
               WebComp_Wcreembolsoassinaturasww.ComponentInit();
               WebComp_Wcreembolsoassinaturasww.Name = "ReembolsoAssinaturasWW";
               WebComp_Wcreembolsoassinaturasww_Component = "ReembolsoAssinaturasWW";
            }
            if ( StringUtil.Len( WebComp_Wcreembolsoassinaturasww_Component) != 0 )
            {
               WebComp_Wcreembolsoassinaturasww.setjustcreated();
               WebComp_Wcreembolsoassinaturasww.componentprepare(new Object[] {(string)"W0084",(string)"",(int)AV7PropostaId,(int)AV34ReembolsoId});
               WebComp_Wcreembolsoassinaturasww.componentbind(new Object[] {(string)"",(string)""});
            }
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcwctitulosproposta = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwctitulosproposta_Component), StringUtil.Lower( "WCTitulosProposta")) != 0 )
            {
               WebComp_Wcwctitulosproposta = getWebComponent(GetType(), "GeneXus.Programs", "wctitulosproposta", new Object[] {context} );
               WebComp_Wcwctitulosproposta.ComponentInit();
               WebComp_Wcwctitulosproposta.Name = "WCTitulosProposta";
               WebComp_Wcwctitulosproposta_Component = "WCTitulosProposta";
            }
            if ( StringUtil.Len( WebComp_Wcwctitulosproposta_Component) != 0 )
            {
               WebComp_Wcwctitulosproposta.setjustcreated();
               WebComp_Wcwctitulosproposta.componentprepare(new Object[] {(string)"W0076",(string)"",(int)AV7PropostaId,(bool)true});
               WebComp_Wcwctitulosproposta.componentbind(new Object[] {(string)"",(string)""});
            }
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcwcdocumentosobrigatoriosreembolso = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component), StringUtil.Lower( "WcDocumentosReembolso")) != 0 )
            {
               WebComp_Wcwcdocumentosobrigatoriosreembolso = getWebComponent(GetType(), "GeneXus.Programs", "wcdocumentosreembolso", new Object[] {context} );
               WebComp_Wcwcdocumentosobrigatoriosreembolso.ComponentInit();
               WebComp_Wcwcdocumentosobrigatoriosreembolso.Name = "WcDocumentosReembolso";
               WebComp_Wcwcdocumentosobrigatoriosreembolso_Component = "WcDocumentosReembolso";
            }
            if ( StringUtil.Len( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component) != 0 )
            {
               WebComp_Wcwcdocumentosobrigatoriosreembolso.setjustcreated();
               WebComp_Wcwcdocumentosobrigatoriosreembolso.componentprepare(new Object[] {(string)"W0068",(string)"",(string)AV16INJSON});
               WebComp_Wcwcdocumentosobrigatoriosreembolso.componentbind(new Object[] {(string)""});
            }
         }
         else
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcreembolsoassinaturasww = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcreembolsoassinaturasww_Component), StringUtil.Lower( "ReembolsoAssinaturasWW")) != 0 )
            {
               WebComp_Wcreembolsoassinaturasww = getWebComponent(GetType(), "GeneXus.Programs", "reembolsoassinaturasww", new Object[] {context} );
               WebComp_Wcreembolsoassinaturasww.ComponentInit();
               WebComp_Wcreembolsoassinaturasww.Name = "ReembolsoAssinaturasWW";
               WebComp_Wcreembolsoassinaturasww_Component = "ReembolsoAssinaturasWW";
            }
            if ( StringUtil.Len( WebComp_Wcreembolsoassinaturasww_Component) != 0 )
            {
               WebComp_Wcreembolsoassinaturasww.setjustcreated();
               WebComp_Wcreembolsoassinaturasww.componentprepare(new Object[] {(string)"W0084",(string)"",(int)AV7PropostaId,(int)AV34ReembolsoId});
               WebComp_Wcreembolsoassinaturasww.componentbind(new Object[] {(string)"",(string)""});
            }
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcwcdocumentosobrigatoriosreembolso = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component), StringUtil.Lower( "WcDocumentosReembolso")) != 0 )
            {
               WebComp_Wcwcdocumentosobrigatoriosreembolso = getWebComponent(GetType(), "GeneXus.Programs", "wcdocumentosreembolso", new Object[] {context} );
               WebComp_Wcwcdocumentosobrigatoriosreembolso.ComponentInit();
               WebComp_Wcwcdocumentosobrigatoriosreembolso.Name = "WcDocumentosReembolso";
               WebComp_Wcwcdocumentosobrigatoriosreembolso_Component = "WcDocumentosReembolso";
            }
            if ( StringUtil.Len( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component) != 0 )
            {
               WebComp_Wcwcdocumentosobrigatoriosreembolso.setjustcreated();
               WebComp_Wcwcdocumentosobrigatoriosreembolso.componentprepare(new Object[] {(string)"W0068",(string)"",(string)AV16INJSON});
               WebComp_Wcwcdocumentosobrigatoriosreembolso.componentbind(new Object[] {(string)""});
            }
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcreembolsoflowlogww = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcreembolsoflowlogww_Component), StringUtil.Lower( "ReembolsoFlowLogWW")) != 0 )
            {
               WebComp_Wcreembolsoflowlogww = getWebComponent(GetType(), "GeneXus.Programs", "reembolsoflowlogww", new Object[] {context} );
               WebComp_Wcreembolsoflowlogww.ComponentInit();
               WebComp_Wcreembolsoflowlogww.Name = "ReembolsoFlowLogWW";
               WebComp_Wcreembolsoflowlogww_Component = "ReembolsoFlowLogWW";
            }
            if ( StringUtil.Len( WebComp_Wcreembolsoflowlogww_Component) != 0 )
            {
               WebComp_Wcreembolsoflowlogww.setjustcreated();
               WebComp_Wcreembolsoflowlogww.componentprepare(new Object[] {(string)"W0092",(string)"",(int)AV34ReembolsoId});
               WebComp_Wcreembolsoflowlogww.componentbind(new Object[] {(string)""});
            }
         }
      }

      protected void E12722( )
      {
         /* 'DoEfetivar' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "efetivarreembolso"+UrlEncode(StringUtil.LTrimStr(AV34ReembolsoId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PropostaId,9,0));
         context.PopUp(formatLink("efetivarreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void E13722( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwctitulosproposta = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwctitulosproposta_Component), StringUtil.Lower( "WCTitulosProposta")) != 0 )
         {
            WebComp_Wcwctitulosproposta = getWebComponent(GetType(), "GeneXus.Programs", "wctitulosproposta", new Object[] {context} );
            WebComp_Wcwctitulosproposta.ComponentInit();
            WebComp_Wcwctitulosproposta.Name = "WCTitulosProposta";
            WebComp_Wcwctitulosproposta_Component = "WCTitulosProposta";
         }
         if ( StringUtil.Len( WebComp_Wcwctitulosproposta_Component) != 0 )
         {
            WebComp_Wcwctitulosproposta.setjustcreated();
            WebComp_Wcwctitulosproposta.componentprepare(new Object[] {(string)"W0076",(string)"",(int)AV7PropostaId,(bool)true});
            WebComp_Wcwctitulosproposta.componentbind(new Object[] {(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwctitulosproposta )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0076"+"");
            WebComp_Wcwctitulosproposta.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E14722 ();
         if (returnInSub) return;
      }

      protected void E14722( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV10Reembolso.gxTpr_Reembolsopropostaid = AV7PropostaId;
         AV10Reembolso.gxTpr_Reembolsoprotocolo = AV5ReembolsoProtocolo;
         AV10Reembolso.gxTpr_Reembolsocreatedat = DateTimeUtil.ServerNow( context, pr_default);
         AV10Reembolso.gxTpr_Reembolsodataaberturaconvenio = AV6ReembolsoDataAberturaConvenio;
         AV10Reembolso.gxTpr_Reembolsocreatedby = AV11WWPContext.gxTpr_Userid;
         AV10Reembolso.Save();
         if ( AV10Reembolso.Success() )
         {
            AV12ReembolsoEtapa = new SdtReembolsoEtapa(context);
            AV12ReembolsoEtapa.gxTpr_Reembolsoid = AV10Reembolso.gxTpr_Reembolsoid;
            AV12ReembolsoEtapa.gxTpr_Reembolsoetapacreatedat = DateTimeUtil.ServerNow( context, pr_default);
            AV12ReembolsoEtapa.gxTpr_Reembolsoetapastatus = "EM_ANALISE";
            AV12ReembolsoEtapa.Save();
            if ( AV12ReembolsoEtapa.Success() )
            {
               AV15isOk = true;
               AV39GXV1 = 1;
               while ( AV39GXV1 <= AV8Array_SdDocumentosReembolso.Count )
               {
                  AV13SdDocumentosReembolso = ((SdtSdDocumentosReembolso)AV8Array_SdDocumentosReembolso.Item(AV39GXV1));
                  AV14ReembolsoDocumento = new SdtReembolsoDocumento(context);
                  AV14ReembolsoDocumento.gxTpr_Reembolsoetapaid = AV12ReembolsoEtapa.gxTpr_Reembolsoetapaid;
                  AV14ReembolsoDocumento.gxTpr_Reembolsodocumentonome = AV13SdDocumentosReembolso.gxTpr_Documentonome;
                  AV14ReembolsoDocumento.gxTpr_Reembolsodocumentoblob = AV13SdDocumentosReembolso.gxTpr_Documentoblob;
                  AV14ReembolsoDocumento.gxTpr_Reembolsodocumentoblobext = AV13SdDocumentosReembolso.gxTpr_Documentoextensao;
                  AV14ReembolsoDocumento.gxTpr_Reembolsodocumentocreatedat = DateTimeUtil.ServerNow( context, pr_default);
                  AV14ReembolsoDocumento.gxTpr_Documentosid = AV13SdDocumentosReembolso.gxTpr_Documentosid;
                  if ( AV13SdDocumentosReembolso.gxTpr_Isupdated )
                  {
                     AV14ReembolsoDocumento.gxTpr_Reembolsodocumentostatus = "AGUARDANDO_ANALISE";
                  }
                  AV14ReembolsoDocumento.Save();
                  if ( AV14ReembolsoDocumento.Fail() )
                  {
                     AV15isOk = false;
                     if (true) break;
                  }
                  AV39GXV1 = (int)(AV39GXV1+1);
               }
               if ( AV15isOk )
               {
                  if ( AV17IsUpdate )
                  {
                     GXt_char2 = "Reembolso atualizado";
                     new message(context ).gxep_sucesso( ref  GXt_char2) ;
                  }
                  else
                  {
                     GXt_char3 = "Reembolso iniciado";
                     new message(context ).gxep_sucesso( ref  GXt_char3) ;
                     GXt_char3 = AV19HTML;
                     new premailnotificainicioreembolso(context ).execute(  AV18ReembolsoPropostaPacienteClienteRazaoSocial,  AV14ReembolsoDocumento.gxTpr_Reembolsodocumentocreatedat, out  GXt_char3) ;
                     AV19HTML = GXt_char3;
                     AV21NotMessage = "Reembolso iniciado do paciente " + AV18ReembolsoPropostaPacienteClienteRazaoSocial;
                     AV23BcNotification = new SdtBCNotification(context);
                     AV23BcNotification.gxTpr_Notificationtitle = "Novo Reembolso";
                     AV23BcNotification.gxTpr_Notificationmessage = AV21NotMessage;
                     AV23BcNotification.gxTpr_Notificationtype = "Internal";
                     AV23BcNotification.gxTpr_Secuserid = AV11WWPContext.gxTpr_Userid;
                     AV23BcNotification.gxTpr_Notificationlink = AV22NotificationLink;
                     new insertnotification(context ).execute(  AV23BcNotification, out  AV20Messages) ;
                     if ( (0==AV20Messages.Count) )
                     {
                        /* Using cursor H00727 */
                        pr_default.execute(4);
                        while ( (pr_default.getStatus(4) != 101) )
                        {
                           A380AprovadoresStatus = H00727_A380AprovadoresStatus[0];
                           n380AprovadoresStatus = H00727_n380AprovadoresStatus[0];
                           A133SecUserId = H00727_A133SecUserId[0];
                           n133SecUserId = H00727_n133SecUserId[0];
                           A144SecUserEmail = H00727_A144SecUserEmail[0];
                           n144SecUserEmail = H00727_n144SecUserEmail[0];
                           A144SecUserEmail = H00727_A144SecUserEmail[0];
                           n144SecUserEmail = H00727_n144SecUserEmail[0];
                           AV24UserNotification = new SdtUserNotification(context);
                           AV24UserNotification.gxTpr_Notificationid = AV23BcNotification.gxTpr_Notificationid;
                           AV24UserNotification.gxTpr_Usernotificationuserid = A133SecUserId;
                           AV24UserNotification.gxTv_SdtUserNotification_Usernotificationreadat_SetNull();
                           AV25Array_Email.Add(A144SecUserEmail, 0);
                           new insertusernotification(context ).execute(  AV24UserNotification, out  AV20Messages) ;
                           if ( ! (0==AV20Messages.Count) )
                           {
                              context.RollbackDataStores("wreembolso",pr_default);
                              context.setWebReturnParms(new Object[] {});
                              context.setWebReturnParmsMetadata(new Object[] {});
                              context.wjLocDisableFrm = 1;
                              context.nUserReturn = 1;
                              pr_default.close(4);
                              returnInSub = true;
                              if (true) return;
                              new showmessages(context ).execute( ) ;
                           }
                           pr_default.readNext(4);
                        }
                        pr_default.close(4);
                        new sendemail(context).executeSubmit(  "Novo reembolso",  AV19HTML,  AV25Array_Email, out  AV26message) ;
                     }
                     else
                     {
                        context.RollbackDataStores("wreembolso",pr_default);
                        context.setWebReturnParms(new Object[] {});
                        context.setWebReturnParmsMetadata(new Object[] {});
                        context.wjLocDisableFrm = 1;
                        context.nUserReturn = 1;
                        returnInSub = true;
                        if (true) return;
                        new showmessages(context ).execute( ) ;
                     }
                  }
                  context.CommitDataStores("wreembolso",pr_default);
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Reembolso", AV10Reembolso);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25Array_Email", AV25Array_Email);
      }

      protected void nextLoad( )
      {
      }

      protected void E15722( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7PropostaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV7PropostaId", StringUtil.LTrimStr( (decimal)(AV7PropostaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PropostaId), "ZZZZZZZZ9"), context));
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
         PA722( ) ;
         WS722( ) ;
         WE722( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwcdocumentosobrigatoriosreembolso == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component) != 0 )
            {
               WebComp_Wcwcdocumentosobrigatoriosreembolso.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcwctitulosproposta == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwctitulosproposta_Component) != 0 )
            {
               WebComp_Wcwctitulosproposta.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcreembolsoassinaturasww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcreembolsoassinaturasww_Component) != 0 )
            {
               WebComp_Wcreembolsoassinaturasww.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcreembolsoflowlogww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcreembolsoflowlogww_Component) != 0 )
            {
               WebComp_Wcreembolsoflowlogww.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101926232", true, true);
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
         context.AddJavascriptSource("wreembolso.js", "?20256101926233", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnefetivar_Internalname = "BTNEFETIVAR";
         lblGeral_title_Internalname = "GERAL_TITLE";
         edtavClienterazaosocial_Internalname = "vCLIENTERAZAOSOCIAL";
         edtavClientedocumento_Internalname = "vCLIENTEDOCUMENTO";
         edtavContatoemail_Internalname = "vCONTATOEMAIL";
         edtavReembolsoprotocolo_Internalname = "vREEMBOLSOPROTOCOLO";
         edtavReembolsodataaberturaconvenio_Internalname = "vREEMBOLSODATAABERTURACONVENIO";
         edtavReembolsopropostavalor_Internalname = "vREEMBOLSOPROPOSTAVALOR";
         edtavReembolsovalor_Internalname = "vREEMBOLSOVALOR";
         edtavValorsaldo_Internalname = "vVALORSALDO";
         divTablevalores_Internalname = "TABLEVALORES";
         divTablereembolso_Internalname = "TABLEREEMBOLSO";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         lblTitulos_title_Internalname = "TITULOS_TITLE";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         lblAssinaturas_title_Internalname = "ASSINATURAS_TITLE";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblEtapas_title_Internalname = "ETAPAS_TITLE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavValorsaldo_Jsonclick = "";
         edtavValorsaldo_Enabled = 1;
         edtavReembolsovalor_Jsonclick = "";
         edtavReembolsovalor_Enabled = 1;
         edtavReembolsopropostavalor_Jsonclick = "";
         edtavReembolsopropostavalor_Enabled = 1;
         edtavReembolsodataaberturaconvenio_Jsonclick = "";
         edtavReembolsodataaberturaconvenio_Enabled = 1;
         edtavReembolsoprotocolo_Jsonclick = "";
         edtavReembolsoprotocolo_Enabled = 1;
         edtavContatoemail_Jsonclick = "";
         edtavContatoemail_Enabled = 1;
         edtavClientedocumento_Jsonclick = "";
         edtavClientedocumento_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 4;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Reembolso";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV34ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV7PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV11WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV17IsUpdate","fld":"vISUPDATE","hsh":true,"type":"boolean"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV22NotificationLink","fld":"vNOTIFICATIONLINK","hsh":true,"type":"svchar"},{"av":"AV5ReembolsoProtocolo","fld":"vREEMBOLSOPROTOCOLO","hsh":true,"type":"svchar"},{"av":"AV6ReembolsoDataAberturaConvenio","fld":"vREEMBOLSODATAABERTURACONVENIO","hsh":true,"type":"date"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"WCWCTITULOSPROPOSTA"}]}""");
         setEventMetadata("'DOEFETIVAR'","""{"handler":"E12722","iparms":[{"av":"AV34ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV7PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("ENTER","""{"handler":"E14722","iparms":[{"av":"AV7PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV10Reembolso","fld":"vREEMBOLSO","type":""},{"av":"AV5ReembolsoProtocolo","fld":"vREEMBOLSOPROTOCOLO","hsh":true,"type":"svchar"},{"av":"AV6ReembolsoDataAberturaConvenio","fld":"vREEMBOLSODATAABERTURACONVENIO","hsh":true,"type":"date"},{"av":"AV11WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV8Array_SdDocumentosReembolso","fld":"vARRAY_SDDOCUMENTOSREEMBOLSO","type":""},{"av":"AV17IsUpdate","fld":"vISUPDATE","hsh":true,"type":"boolean"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV22NotificationLink","fld":"vNOTIFICATIONLINK","hsh":true,"type":"svchar"},{"av":"A380AprovadoresStatus","fld":"APROVADORESSTATUS","type":"boolean"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","type":"int"},{"av":"A144SecUserEmail","fld":"SECUSEREMAIL","type":"svchar"},{"av":"AV25Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV26message","fld":"vMESSAGE","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV10Reembolso","fld":"vREEMBOLSO","type":""},{"av":"AV25Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV26message","fld":"vMESSAGE","type":"svchar"}]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5ReembolsoProtocolo = "";
         AV6ReembolsoDataAberturaConvenio = DateTime.MinValue;
         AV11WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV18ReembolsoPropostaPacienteClienteRazaoSocial = "";
         AV22NotificationLink = "";
         forbiddenHiddens = new GXProperties();
         AV9JSON = "";
         AV10Reembolso = new SdtReembolso(context);
         AV8Array_SdDocumentosReembolso = new GXBaseCollection<SdtSdDocumentosReembolso>( context, "SdDocumentosReembolso", "Factory21");
         A144SecUserEmail = "";
         AV25Array_Email = new GxSimpleCollection<string>();
         AV26message = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnefetivar_Jsonclick = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblGeral_title_Jsonclick = "";
         AV30ClienteRazaoSocial = "";
         AV29ClienteDocumento = "";
         AV28ContatoEmail = "";
         WebComp_Wcwcdocumentosobrigatoriosreembolso_Component = "";
         OldWcwcdocumentosobrigatoriosreembolso = "";
         lblTitulos_title_Jsonclick = "";
         WebComp_Wcwctitulosproposta_Component = "";
         OldWcwctitulosproposta = "";
         lblAssinaturas_title_Jsonclick = "";
         WebComp_Wcreembolsoassinaturasww_Component = "";
         OldWcreembolsoassinaturasww = "";
         lblEtapas_title_Jsonclick = "";
         WebComp_Wcreembolsoflowlogww_Component = "";
         OldWcreembolsoflowlogww = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         hsh = "";
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H00723_A518ReembolsoId = new int[1] ;
         H00723_n518ReembolsoId = new bool[] {false} ;
         H00723_A542ReembolsoPropostaId = new int[1] ;
         H00723_n542ReembolsoPropostaId = new bool[] {false} ;
         H00723_A546ReembolsoProtocolo = new string[] {""} ;
         H00723_n546ReembolsoProtocolo = new bool[] {false} ;
         H00723_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         H00723_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         H00723_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H00723_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H00723_A543ReembolsoPropostaValor = new decimal[1] ;
         H00723_n543ReembolsoPropostaValor = new bool[] {false} ;
         H00723_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         H00723_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         H00723_A645ReembolsoValorReembolsado_F = new decimal[1] ;
         H00723_n645ReembolsoValorReembolsado_F = new bool[] {false} ;
         A546ReembolsoProtocolo = "";
         A525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         H00724_A526ReembolsoEtapaId = new int[1] ;
         H00724_n526ReembolsoEtapaId = new bool[] {false} ;
         H00724_A518ReembolsoId = new int[1] ;
         H00724_n518ReembolsoId = new bool[] {false} ;
         H00724_A530ReembolsoDocumentoNome = new string[] {""} ;
         H00724_n530ReembolsoDocumentoNome = new bool[] {false} ;
         H00724_A532ReembolsoDocumentoBlobExt = new string[] {""} ;
         H00724_n532ReembolsoDocumentoBlobExt = new bool[] {false} ;
         H00724_A405DocumentosId = new int[1] ;
         H00724_n405DocumentosId = new bool[] {false} ;
         H00724_A529ReembolsoDocumentoId = new int[1] ;
         H00724_A549ReembolsoDocumentoStatus = new string[] {""} ;
         H00724_n549ReembolsoDocumentoStatus = new bool[] {false} ;
         H00724_A531ReembolsoDocumentoBlob = new string[] {""} ;
         H00724_n531ReembolsoDocumentoBlob = new bool[] {false} ;
         A530ReembolsoDocumentoNome = "";
         A532ReembolsoDocumentoBlobExt = "";
         A549ReembolsoDocumentoStatus = "";
         A531ReembolsoDocumentoBlob = "";
         AV13SdDocumentosReembolso = new SdtSdDocumentosReembolso(context);
         H00725_A504PropostaPacienteClienteId = new int[1] ;
         H00725_n504PropostaPacienteClienteId = new bool[] {false} ;
         H00725_A323PropostaId = new int[1] ;
         H00725_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H00725_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         A505PropostaPacienteClienteRazaoSocial = "";
         H00726_A168ClienteId = new int[1] ;
         H00726_A170ClienteRazaoSocial = new string[] {""} ;
         H00726_n170ClienteRazaoSocial = new bool[] {false} ;
         H00726_A169ClienteDocumento = new string[] {""} ;
         H00726_n169ClienteDocumento = new bool[] {false} ;
         H00726_A201ContatoEmail = new string[] {""} ;
         H00726_n201ContatoEmail = new bool[] {false} ;
         A170ClienteRazaoSocial = "";
         A169ClienteDocumento = "";
         A201ContatoEmail = "";
         AV16INJSON = "";
         AV12ReembolsoEtapa = new SdtReembolsoEtapa(context);
         AV14ReembolsoDocumento = new SdtReembolsoDocumento(context);
         GXt_char2 = "";
         AV19HTML = "";
         GXt_char3 = "";
         AV21NotMessage = "";
         AV23BcNotification = new SdtBCNotification(context);
         AV20Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         H00727_A375AprovadoresId = new int[1] ;
         H00727_A380AprovadoresStatus = new bool[] {false} ;
         H00727_n380AprovadoresStatus = new bool[] {false} ;
         H00727_A133SecUserId = new short[1] ;
         H00727_n133SecUserId = new bool[] {false} ;
         H00727_A144SecUserEmail = new string[] {""} ;
         H00727_n144SecUserEmail = new bool[] {false} ;
         AV24UserNotification = new SdtUserNotification(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wreembolso__default(),
            new Object[][] {
                new Object[] {
               H00723_A518ReembolsoId, H00723_A542ReembolsoPropostaId, H00723_n542ReembolsoPropostaId, H00723_A546ReembolsoProtocolo, H00723_n546ReembolsoProtocolo, H00723_A525ReembolsoDataAberturaConvenio, H00723_n525ReembolsoDataAberturaConvenio, H00723_A550ReembolsoPropostaPacienteClienteRazaoSocial, H00723_n550ReembolsoPropostaPacienteClienteRazaoSocial, H00723_A543ReembolsoPropostaValor,
               H00723_n543ReembolsoPropostaValor, H00723_A558ReembolsoPropostaPacienteClienteId, H00723_n558ReembolsoPropostaPacienteClienteId, H00723_A645ReembolsoValorReembolsado_F, H00723_n645ReembolsoValorReembolsado_F
               }
               , new Object[] {
               H00724_A526ReembolsoEtapaId, H00724_n526ReembolsoEtapaId, H00724_A518ReembolsoId, H00724_n518ReembolsoId, H00724_A530ReembolsoDocumentoNome, H00724_n530ReembolsoDocumentoNome, H00724_A532ReembolsoDocumentoBlobExt, H00724_n532ReembolsoDocumentoBlobExt, H00724_A405DocumentosId, H00724_n405DocumentosId,
               H00724_A529ReembolsoDocumentoId, H00724_A549ReembolsoDocumentoStatus, H00724_n549ReembolsoDocumentoStatus, H00724_A531ReembolsoDocumentoBlob, H00724_n531ReembolsoDocumentoBlob
               }
               , new Object[] {
               H00725_A504PropostaPacienteClienteId, H00725_n504PropostaPacienteClienteId, H00725_A323PropostaId, H00725_A505PropostaPacienteClienteRazaoSocial, H00725_n505PropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               H00726_A168ClienteId, H00726_A170ClienteRazaoSocial, H00726_n170ClienteRazaoSocial, H00726_A169ClienteDocumento, H00726_n169ClienteDocumento, H00726_A201ContatoEmail, H00726_n201ContatoEmail
               }
               , new Object[] {
               H00727_A375AprovadoresId, H00727_A380AprovadoresStatus, H00727_n380AprovadoresStatus, H00727_A133SecUserId, H00727_n133SecUserId, H00727_A144SecUserEmail, H00727_n144SecUserEmail
               }
            }
         );
         WebComp_Wcwcdocumentosobrigatoriosreembolso = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcwctitulosproposta = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcreembolsoassinaturasww = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcreembolsoflowlogww = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavClienterazaosocial_Enabled = 0;
         edtavClientedocumento_Enabled = 0;
         edtavContatoemail_Enabled = 0;
         edtavReembolsoprotocolo_Enabled = 0;
         edtavReembolsodataaberturaconvenio_Enabled = 0;
         edtavReembolsopropostavalor_Enabled = 0;
         edtavReembolsovalor_Enabled = 0;
         edtavValorsaldo_Enabled = 0;
      }

      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short A133SecUserId ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV35GXLvl8 ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV7PropostaId ;
      private int wcpOAV7PropostaId ;
      private int AV34ReembolsoId ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavClientedocumento_Enabled ;
      private int edtavContatoemail_Enabled ;
      private int edtavReembolsoprotocolo_Enabled ;
      private int edtavReembolsodataaberturaconvenio_Enabled ;
      private int edtavReembolsopropostavalor_Enabled ;
      private int edtavReembolsovalor_Enabled ;
      private int edtavValorsaldo_Enabled ;
      private int A518ReembolsoId ;
      private int A542ReembolsoPropostaId ;
      private int A558ReembolsoPropostaPacienteClienteId ;
      private int A526ReembolsoEtapaId ;
      private int A405DocumentosId ;
      private int A529ReembolsoDocumentoId ;
      private int AV31ReembolsoPropostaPacienteClienteId ;
      private int A504PropostaPacienteClienteId ;
      private int A323PropostaId ;
      private int A168ClienteId ;
      private int AV39GXV1 ;
      private int idxLst ;
      private decimal AV27ReembolsoPropostaValor ;
      private decimal AV32ReembolsoValor ;
      private decimal AV33ValorSaldo ;
      private decimal A543ReembolsoPropostaValor ;
      private decimal A645ReembolsoValorReembolsado_F ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Gxuitabspanel_tabs1_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string TempTags ;
      private string bttBtnefetivar_Internalname ;
      private string bttBtnefetivar_Jsonclick ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblGeral_title_Internalname ;
      private string lblGeral_title_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string divTablereembolso_Internalname ;
      private string edtavClienterazaosocial_Internalname ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string edtavClientedocumento_Internalname ;
      private string edtavClientedocumento_Jsonclick ;
      private string edtavContatoemail_Internalname ;
      private string edtavContatoemail_Jsonclick ;
      private string edtavReembolsoprotocolo_Internalname ;
      private string edtavReembolsoprotocolo_Jsonclick ;
      private string edtavReembolsodataaberturaconvenio_Internalname ;
      private string edtavReembolsodataaberturaconvenio_Jsonclick ;
      private string divTablevalores_Internalname ;
      private string edtavReembolsopropostavalor_Internalname ;
      private string edtavReembolsopropostavalor_Jsonclick ;
      private string edtavReembolsovalor_Internalname ;
      private string edtavReembolsovalor_Jsonclick ;
      private string edtavValorsaldo_Internalname ;
      private string edtavValorsaldo_Jsonclick ;
      private string WebComp_Wcwcdocumentosobrigatoriosreembolso_Component ;
      private string OldWcwcdocumentosobrigatoriosreembolso ;
      private string lblTitulos_title_Internalname ;
      private string lblTitulos_title_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string WebComp_Wcwctitulosproposta_Component ;
      private string OldWcwctitulosproposta ;
      private string lblAssinaturas_title_Internalname ;
      private string lblAssinaturas_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string WebComp_Wcreembolsoassinaturasww_Component ;
      private string OldWcreembolsoassinaturasww ;
      private string lblEtapas_title_Internalname ;
      private string lblEtapas_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string WebComp_Wcreembolsoflowlogww_Component ;
      private string OldWcreembolsoflowlogww ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string hsh ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private DateTime AV6ReembolsoDataAberturaConvenio ;
      private DateTime A525ReembolsoDataAberturaConvenio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17IsUpdate ;
      private bool A380AprovadoresStatus ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n518ReembolsoId ;
      private bool n542ReembolsoPropostaId ;
      private bool n546ReembolsoProtocolo ;
      private bool n525ReembolsoDataAberturaConvenio ;
      private bool n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool n543ReembolsoPropostaValor ;
      private bool n558ReembolsoPropostaPacienteClienteId ;
      private bool n645ReembolsoValorReembolsado_F ;
      private bool n526ReembolsoEtapaId ;
      private bool n530ReembolsoDocumentoNome ;
      private bool n532ReembolsoDocumentoBlobExt ;
      private bool n405DocumentosId ;
      private bool n549ReembolsoDocumentoStatus ;
      private bool n531ReembolsoDocumentoBlob ;
      private bool n504PropostaPacienteClienteId ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n170ClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n201ContatoEmail ;
      private bool bDynCreated_Wcreembolsoflowlogww ;
      private bool bDynCreated_Wcreembolsoassinaturasww ;
      private bool bDynCreated_Wcwctitulosproposta ;
      private bool bDynCreated_Wcwcdocumentosobrigatoriosreembolso ;
      private bool AV15isOk ;
      private bool n380AprovadoresStatus ;
      private bool n133SecUserId ;
      private bool n144SecUserEmail ;
      private string AV9JSON ;
      private string AV16INJSON ;
      private string AV19HTML ;
      private string AV5ReembolsoProtocolo ;
      private string AV18ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string AV22NotificationLink ;
      private string A144SecUserEmail ;
      private string AV26message ;
      private string AV30ClienteRazaoSocial ;
      private string AV29ClienteDocumento ;
      private string AV28ContatoEmail ;
      private string A546ReembolsoProtocolo ;
      private string A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string A530ReembolsoDocumentoNome ;
      private string A532ReembolsoDocumentoBlobExt ;
      private string A549ReembolsoDocumentoStatus ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A170ClienteRazaoSocial ;
      private string A169ClienteDocumento ;
      private string A201ContatoEmail ;
      private string AV21NotMessage ;
      private string A531ReembolsoDocumentoBlob ;
      private GXWebComponent WebComp_Wcwcdocumentosobrigatoriosreembolso ;
      private GXWebComponent WebComp_Wcwctitulosproposta ;
      private GXWebComponent WebComp_Wcreembolsoassinaturasww ;
      private GXWebComponent WebComp_Wcreembolsoflowlogww ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
      private SdtReembolso AV10Reembolso ;
      private GXBaseCollection<SdtSdDocumentosReembolso> AV8Array_SdDocumentosReembolso ;
      private GxSimpleCollection<string> AV25Array_Email ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private int[] H00723_A518ReembolsoId ;
      private bool[] H00723_n518ReembolsoId ;
      private int[] H00723_A542ReembolsoPropostaId ;
      private bool[] H00723_n542ReembolsoPropostaId ;
      private string[] H00723_A546ReembolsoProtocolo ;
      private bool[] H00723_n546ReembolsoProtocolo ;
      private DateTime[] H00723_A525ReembolsoDataAberturaConvenio ;
      private bool[] H00723_n525ReembolsoDataAberturaConvenio ;
      private string[] H00723_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] H00723_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private decimal[] H00723_A543ReembolsoPropostaValor ;
      private bool[] H00723_n543ReembolsoPropostaValor ;
      private int[] H00723_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] H00723_n558ReembolsoPropostaPacienteClienteId ;
      private decimal[] H00723_A645ReembolsoValorReembolsado_F ;
      private bool[] H00723_n645ReembolsoValorReembolsado_F ;
      private int[] H00724_A526ReembolsoEtapaId ;
      private bool[] H00724_n526ReembolsoEtapaId ;
      private int[] H00724_A518ReembolsoId ;
      private bool[] H00724_n518ReembolsoId ;
      private string[] H00724_A530ReembolsoDocumentoNome ;
      private bool[] H00724_n530ReembolsoDocumentoNome ;
      private string[] H00724_A532ReembolsoDocumentoBlobExt ;
      private bool[] H00724_n532ReembolsoDocumentoBlobExt ;
      private int[] H00724_A405DocumentosId ;
      private bool[] H00724_n405DocumentosId ;
      private int[] H00724_A529ReembolsoDocumentoId ;
      private string[] H00724_A549ReembolsoDocumentoStatus ;
      private bool[] H00724_n549ReembolsoDocumentoStatus ;
      private string[] H00724_A531ReembolsoDocumentoBlob ;
      private bool[] H00724_n531ReembolsoDocumentoBlob ;
      private SdtSdDocumentosReembolso AV13SdDocumentosReembolso ;
      private int[] H00725_A504PropostaPacienteClienteId ;
      private bool[] H00725_n504PropostaPacienteClienteId ;
      private int[] H00725_A323PropostaId ;
      private string[] H00725_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H00725_n505PropostaPacienteClienteRazaoSocial ;
      private int[] H00726_A168ClienteId ;
      private string[] H00726_A170ClienteRazaoSocial ;
      private bool[] H00726_n170ClienteRazaoSocial ;
      private string[] H00726_A169ClienteDocumento ;
      private bool[] H00726_n169ClienteDocumento ;
      private string[] H00726_A201ContatoEmail ;
      private bool[] H00726_n201ContatoEmail ;
      private SdtReembolsoEtapa AV12ReembolsoEtapa ;
      private SdtReembolsoDocumento AV14ReembolsoDocumento ;
      private SdtBCNotification AV23BcNotification ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV20Messages ;
      private int[] H00727_A375AprovadoresId ;
      private bool[] H00727_A380AprovadoresStatus ;
      private bool[] H00727_n380AprovadoresStatus ;
      private short[] H00727_A133SecUserId ;
      private bool[] H00727_n133SecUserId ;
      private string[] H00727_A144SecUserEmail ;
      private bool[] H00727_n144SecUserEmail ;
      private SdtUserNotification AV24UserNotification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wreembolso__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00723;
          prmH00723 = new Object[] {
          new ParDef("AV7PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH00724;
          prmH00724 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmH00725;
          prmH00725 = new Object[] {
          new ParDef("AV7PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH00726;
          prmH00726 = new Object[] {
          new ParDef("AV31ReembolsoPropostaPacienteClienteId",GXType.Int32,9,0)
          };
          Object[] prmH00727;
          prmH00727 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00723", "SELECT T1.ReembolsoId, T1.ReembolsoPropostaId AS ReembolsoPropostaId, T1.ReembolsoProtocolo, T1.ReembolsoDataAberturaConvenio, T4.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T3.PropostaValor AS ReembolsoPropostaValor, T3.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, COALESCE( T2.ReembolsoValorReembolsado_F, 0) AS ReembolsoValorReembolsado_F FROM (((Reembolso T1 LEFT JOIN LATERAL (SELECT SUM(ReembolsoParcelasValor) AS ReembolsoValorReembolsado_F, ReembolsoId FROM ReembolsoParcelas WHERE T1.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T2 ON T2.ReembolsoId = T1.ReembolsoId) LEFT JOIN Proposta T3 ON T3.PropostaId = T1.ReembolsoPropostaId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.PropostaPacienteClienteId) WHERE T1.ReembolsoPropostaId = :AV7PropostaId ORDER BY T1.ReembolsoPropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00723,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00724", "SELECT T1.ReembolsoEtapaId, T2.ReembolsoId, T1.ReembolsoDocumentoNome, T1.ReembolsoDocumentoBlobExt, T1.DocumentosId, T1.ReembolsoDocumentoId, T1.ReembolsoDocumentoStatus, T1.ReembolsoDocumentoBlob FROM (ReembolsoDocumento T1 LEFT JOIN ReembolsoEtapa T2 ON T2.ReembolsoEtapaId = T1.ReembolsoEtapaId) WHERE T2.ReembolsoId = :ReembolsoId ORDER BY T1.ReembolsoDocumentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00724,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00725", "SELECT T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaId, T2.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial FROM (Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaPacienteClienteId) WHERE T1.PropostaId = :AV7PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00725,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00726", "SELECT ClienteId, ClienteRazaoSocial, ClienteDocumento, ContatoEmail FROM Cliente WHERE ClienteId = :AV31ReembolsoPropostaPacienteClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00726,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00727", "SELECT T1.AprovadoresId, T1.AprovadoresStatus, T1.SecUserId, T2.SecUserEmail FROM (Aprovadores T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId) WHERE T1.AprovadoresStatus ORDER BY T1.AprovadoresId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00727,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getBLOBFile(8, "tmp", "");
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
