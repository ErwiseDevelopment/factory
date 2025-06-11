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
   public class wpreembolso : GXDataArea
   {
      public wpreembolso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpreembolso( IGxContext context )
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmastercli", "GeneXus.Programs.wwpbaseobjects.workwithplusmastercli", new Object[] {context});
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
         PA6L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6L2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXEncryptionTmp = "wpreembolso"+UrlEncode(StringUtil.LTrimStr(AV7PropostaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31ReembolsoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PropostaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWORKFLOWCONVENIOID_DATA", AV29WorkflowConvenioId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWORKFLOWCONVENIOID_DATA", AV29WorkflowConvenioId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vJSON", AV9JSON);
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV28CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PropostaId), "ZZZZZZZZ9"), context));
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
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31ReembolsoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COMBO_WORKFLOWCONVENIOID_Cls", StringUtil.RTrim( Combo_workflowconvenioid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_WORKFLOWCONVENIOID_Selectedvalue_set", StringUtil.RTrim( Combo_workflowconvenioid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_WORKFLOWCONVENIOID_Emptyitem", StringUtil.BoolToStr( Combo_workflowconvenioid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "COMBO_WORKFLOWCONVENIOID_Selectedvalue_get", StringUtil.RTrim( Combo_workflowconvenioid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_WORKFLOWCONVENIOID_Ddointernalname", StringUtil.RTrim( Combo_workflowconvenioid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_WORKFLOWCONVENIOID_Ddointernalname", StringUtil.RTrim( Combo_workflowconvenioid_Ddointernalname));
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
            WE6L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6L2( ) ;
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
         GXEncryptionTmp = "wpreembolso"+UrlEncode(StringUtil.LTrimStr(AV7PropostaId,9,0));
         return formatLink("wpreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpReembolso" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reembolso" ;
      }

      protected void WB6L0( )
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
            /* User Defined Control */
            ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
            ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
            ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, "GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeral_title_Internalname, "Informações gerais", "", "", lblGeral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpReembolso.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Geral") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablereembolso_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsoprotocolo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoprotocolo_Internalname, "Protocolo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoprotocolo_Internalname, AV5ReembolsoProtocolo, StringUtil.RTrim( context.localUtil.Format( AV5ReembolsoProtocolo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoprotocolo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsoprotocolo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsodataaberturaconvenio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsodataaberturaconvenio_Internalname, "Data abertura no convênio", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavReembolsodataaberturaconvenio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavReembolsodataaberturaconvenio_Internalname, context.localUtil.Format(AV6ReembolsoDataAberturaConvenio, "99/99/9999"), context.localUtil.Format( AV6ReembolsoDataAberturaConvenio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsodataaberturaconvenio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsodataaberturaconvenio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpReembolso.htm");
            GxWebStd.gx_bitmap( context, edtavReembolsodataaberturaconvenio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavReembolsodataaberturaconvenio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpReembolso.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedworkflowconvenioid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_workflowconvenioid_Internalname, "Passo", "", "", lblTextblockcombo_workflowconvenioid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_workflowconvenioid.SetProperty("Caption", Combo_workflowconvenioid_Caption);
            ucCombo_workflowconvenioid.SetProperty("Cls", Combo_workflowconvenioid_Cls);
            ucCombo_workflowconvenioid.SetProperty("EmptyItem", Combo_workflowconvenioid_Emptyitem);
            ucCombo_workflowconvenioid.SetProperty("DropDownOptionsData", AV29WorkflowConvenioId_Data);
            ucCombo_workflowconvenioid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_workflowconvenioid_Internalname, "COMBO_WORKFLOWCONVENIOIDContainer");
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
               GxWebStd.gx_hidden_field( context, "W0043"+"", StringUtil.RTrim( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0043"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcdocumentosobrigatoriosreembolso), StringUtil.Lower( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPasso_title_Internalname, "Histórico de passos", "", "", lblPasso_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpReembolso.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Passo") ;
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
               GxWebStd.gx_hidden_field( context, "W0051"+"", StringUtil.RTrim( WebComp_Wcreembolsoflowlogww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0051"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcreembolsoflowlogww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcreembolsoflowlogww), StringUtil.Lower( WebComp_Wcreembolsoflowlogww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0051"+"");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpReembolso.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWorkflowconvenioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27WorkflowConvenioId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV27WorkflowConvenioId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWorkflowconvenioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavWorkflowconvenioid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6L2( )
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
         STRUP6L0( ) ;
      }

      protected void WS6L2( )
      {
         START6L2( ) ;
         EVT6L2( ) ;
      }

      protected void EVT6L2( )
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
                              E116L2 ();
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
                                    E126L2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E136L2 ();
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
                        if ( nCmpId == 43 )
                        {
                           OldWcwcdocumentosobrigatoriosreembolso = cgiGet( "W0043");
                           if ( ( StringUtil.Len( OldWcwcdocumentosobrigatoriosreembolso) == 0 ) || ( StringUtil.StrCmp(OldWcwcdocumentosobrigatoriosreembolso, WebComp_Wcwcdocumentosobrigatoriosreembolso_Component) != 0 ) )
                           {
                              WebComp_Wcwcdocumentosobrigatoriosreembolso = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcdocumentosobrigatoriosreembolso, new Object[] {context} );
                              WebComp_Wcwcdocumentosobrigatoriosreembolso.ComponentInit();
                              WebComp_Wcwcdocumentosobrigatoriosreembolso.Name = "OldWcwcdocumentosobrigatoriosreembolso";
                              WebComp_Wcwcdocumentosobrigatoriosreembolso_Component = OldWcwcdocumentosobrigatoriosreembolso;
                           }
                           if ( StringUtil.Len( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component) != 0 )
                           {
                              WebComp_Wcwcdocumentosobrigatoriosreembolso.componentprocess("W0043", "", sEvt);
                           }
                           WebComp_Wcwcdocumentosobrigatoriosreembolso_Component = OldWcwcdocumentosobrigatoriosreembolso;
                        }
                        else if ( nCmpId == 51 )
                        {
                           OldWcreembolsoflowlogww = cgiGet( "W0051");
                           if ( ( StringUtil.Len( OldWcreembolsoflowlogww) == 0 ) || ( StringUtil.StrCmp(OldWcreembolsoflowlogww, WebComp_Wcreembolsoflowlogww_Component) != 0 ) )
                           {
                              WebComp_Wcreembolsoflowlogww = getWebComponent(GetType(), "GeneXus.Programs", OldWcreembolsoflowlogww, new Object[] {context} );
                              WebComp_Wcreembolsoflowlogww.ComponentInit();
                              WebComp_Wcreembolsoflowlogww.Name = "OldWcreembolsoflowlogww";
                              WebComp_Wcreembolsoflowlogww_Component = OldWcreembolsoflowlogww;
                           }
                           if ( StringUtil.Len( WebComp_Wcreembolsoflowlogww_Component) != 0 )
                           {
                              WebComp_Wcreembolsoflowlogww.componentprocess("W0051", "", sEvt);
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

      protected void WE6L2( )
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

      protected void PA6L2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpreembolso")), "wpreembolso") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpreembolso")))) ;
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
               GX_FocusControl = edtavReembolsoprotocolo_Internalname;
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
         RF6L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF6L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
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
            E136L2 ();
            WB6L0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6L2( )
      {
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
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31ReembolsoId), "ZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E116L2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vWORKFLOWCONVENIOID_DATA"), AV29WorkflowConvenioId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vARRAY_SDDOCUMENTOSREEMBOLSO"), AV8Array_SdDocumentosReembolso);
            /* Read saved values. */
            AV9JSON = cgiGet( "vJSON");
            Combo_workflowconvenioid_Cls = cgiGet( "COMBO_WORKFLOWCONVENIOID_Cls");
            Combo_workflowconvenioid_Selectedvalue_set = cgiGet( "COMBO_WORKFLOWCONVENIOID_Selectedvalue_set");
            Combo_workflowconvenioid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_WORKFLOWCONVENIOID_Emptyitem"));
            Gxuitabspanel_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
            Combo_workflowconvenioid_Ddointernalname = cgiGet( "COMBO_WORKFLOWCONVENIOID_Ddointernalname");
            /* Read variables values. */
            AV5ReembolsoProtocolo = cgiGet( edtavReembolsoprotocolo_Internalname);
            AssignAttri("", false, "AV5ReembolsoProtocolo", AV5ReembolsoProtocolo);
            if ( context.localUtil.VCDate( cgiGet( edtavReembolsodataaberturaconvenio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Reembolso Data Abertura Convenio"}), 1, "vREEMBOLSODATAABERTURACONVENIO");
               GX_FocusControl = edtavReembolsodataaberturaconvenio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6ReembolsoDataAberturaConvenio = DateTime.MinValue;
               AssignAttri("", false, "AV6ReembolsoDataAberturaConvenio", context.localUtil.Format(AV6ReembolsoDataAberturaConvenio, "99/99/9999"));
            }
            else
            {
               AV6ReembolsoDataAberturaConvenio = context.localUtil.CToD( cgiGet( edtavReembolsodataaberturaconvenio_Internalname), 2);
               AssignAttri("", false, "AV6ReembolsoDataAberturaConvenio", context.localUtil.Format(AV6ReembolsoDataAberturaConvenio, "99/99/9999"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWorkflowconvenioid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWorkflowconvenioid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWORKFLOWCONVENIOID");
               GX_FocusControl = edtavWorkflowconvenioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27WorkflowConvenioId = 0;
               AssignAttri("", false, "AV27WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(AV27WorkflowConvenioId), 9, 0));
            }
            else
            {
               AV27WorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavWorkflowconvenioid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(AV27WorkflowConvenioId), 9, 0));
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
         E116L2 ();
         if (returnInSub) return;
      }

      protected void E116L2( )
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
         AV33Array_ClientesIds = (GxSimpleCollection<int>)(new GxSimpleCollection<int>());
         /* Using cursor H006L2 */
         pr_default.execute(0, new Object[] {AV7PropostaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A323PropostaId = H006L2_A323PropostaId[0];
            A504PropostaPacienteClienteId = H006L2_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = H006L2_n504PropostaPacienteClienteId[0];
            AV33Array_ClientesIds.Add(A504PropostaPacienteClienteId, 0);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV32ClientesIds.FromJSonString(AV33Array_ClientesIds.ToJSonString(false), null);
         AV35GXLvl13 = 0;
         /* Using cursor H006L3 */
         pr_default.execute(1, new Object[] {AV7PropostaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A558ReembolsoPropostaPacienteClienteId = H006L3_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = H006L3_n558ReembolsoPropostaPacienteClienteId[0];
            A518ReembolsoId = H006L3_A518ReembolsoId[0];
            n518ReembolsoId = H006L3_n518ReembolsoId[0];
            A542ReembolsoPropostaId = H006L3_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = H006L3_n542ReembolsoPropostaId[0];
            A546ReembolsoProtocolo = H006L3_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = H006L3_n546ReembolsoProtocolo[0];
            A525ReembolsoDataAberturaConvenio = H006L3_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = H006L3_n525ReembolsoDataAberturaConvenio[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = H006L3_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = H006L3_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A742WorkflowConvenioId = H006L3_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = H006L3_n742WorkflowConvenioId[0];
            A558ReembolsoPropostaPacienteClienteId = H006L3_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = H006L3_n558ReembolsoPropostaPacienteClienteId[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = H006L3_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = H006L3_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            AV35GXLvl13 = 1;
            AV31ReembolsoId = A518ReembolsoId;
            AssignAttri("", false, "AV31ReembolsoId", StringUtil.LTrimStr( (decimal)(AV31ReembolsoId), 9, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31ReembolsoId), "ZZZZZZZZ9"), context));
            AV10Reembolso.Load(A518ReembolsoId);
            AV17IsUpdate = true;
            AssignAttri("", false, "AV17IsUpdate", AV17IsUpdate);
            GxWebStd.gx_hidden_field( context, "gxhash_vISUPDATE", GetSecureSignedToken( "", AV17IsUpdate, context));
            AV5ReembolsoProtocolo = A546ReembolsoProtocolo;
            AssignAttri("", false, "AV5ReembolsoProtocolo", AV5ReembolsoProtocolo);
            AV6ReembolsoDataAberturaConvenio = A525ReembolsoDataAberturaConvenio;
            AssignAttri("", false, "AV6ReembolsoDataAberturaConvenio", context.localUtil.Format(AV6ReembolsoDataAberturaConvenio, "99/99/9999"));
            AV18ReembolsoPropostaPacienteClienteRazaoSocial = A550ReembolsoPropostaPacienteClienteRazaoSocial;
            AssignAttri("", false, "AV18ReembolsoPropostaPacienteClienteRazaoSocial", AV18ReembolsoPropostaPacienteClienteRazaoSocial);
            GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ReembolsoPropostaPacienteClienteRazaoSocial, "@!")), context));
            AV27WorkflowConvenioId = A742WorkflowConvenioId;
            AssignAttri("", false, "AV27WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(AV27WorkflowConvenioId), 9, 0));
            /* Using cursor H006L4 */
            pr_default.execute(2, new Object[] {n518ReembolsoId, A518ReembolsoId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A526ReembolsoEtapaId = H006L4_A526ReembolsoEtapaId[0];
               n526ReembolsoEtapaId = H006L4_n526ReembolsoEtapaId[0];
               A530ReembolsoDocumentoNome = H006L4_A530ReembolsoDocumentoNome[0];
               n530ReembolsoDocumentoNome = H006L4_n530ReembolsoDocumentoNome[0];
               A532ReembolsoDocumentoBlobExt = H006L4_A532ReembolsoDocumentoBlobExt[0];
               n532ReembolsoDocumentoBlobExt = H006L4_n532ReembolsoDocumentoBlobExt[0];
               A405DocumentosId = H006L4_A405DocumentosId[0];
               n405DocumentosId = H006L4_n405DocumentosId[0];
               A529ReembolsoDocumentoId = H006L4_A529ReembolsoDocumentoId[0];
               A549ReembolsoDocumentoStatus = H006L4_A549ReembolsoDocumentoStatus[0];
               n549ReembolsoDocumentoStatus = H006L4_n549ReembolsoDocumentoStatus[0];
               A531ReembolsoDocumentoBlob = H006L4_A531ReembolsoDocumentoBlob[0];
               n531ReembolsoDocumentoBlob = H006L4_n531ReembolsoDocumentoBlob[0];
               AV13SdDocumentosReembolso = new SdtSdDocumentosReembolso(context);
               AV13SdDocumentosReembolso.gxTpr_Documentonome = A530ReembolsoDocumentoNome;
               AV13SdDocumentosReembolso.gxTpr_Documentoblob = A531ReembolsoDocumentoBlob;
               AV13SdDocumentosReembolso.gxTpr_Documentoextensao = A532ReembolsoDocumentoBlobExt;
               AV13SdDocumentosReembolso.gxTpr_Documentosid = A405DocumentosId;
               AV13SdDocumentosReembolso.gxTpr_Reembolsodocumentoid = A529ReembolsoDocumentoId;
               AV13SdDocumentosReembolso.gxTpr_Reembolsodocumentostatus = A549ReembolsoDocumentoStatus;
               AV13SdDocumentosReembolso.gxTpr_Isupdated = false;
               AV8Array_SdDocumentosReembolso.Add(AV13SdDocumentosReembolso, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV35GXLvl13 == 0 )
         {
            /* Using cursor H006L5 */
            pr_default.execute(3, new Object[] {AV7PropostaId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A504PropostaPacienteClienteId = H006L5_A504PropostaPacienteClienteId[0];
               n504PropostaPacienteClienteId = H006L5_n504PropostaPacienteClienteId[0];
               A323PropostaId = H006L5_A323PropostaId[0];
               A505PropostaPacienteClienteRazaoSocial = H006L5_A505PropostaPacienteClienteRazaoSocial[0];
               n505PropostaPacienteClienteRazaoSocial = H006L5_n505PropostaPacienteClienteRazaoSocial[0];
               A505PropostaPacienteClienteRazaoSocial = H006L5_A505PropostaPacienteClienteRazaoSocial[0];
               n505PropostaPacienteClienteRazaoSocial = H006L5_n505PropostaPacienteClienteRazaoSocial[0];
               AV18ReembolsoPropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
               AssignAttri("", false, "AV18ReembolsoPropostaPacienteClienteRazaoSocial", AV18ReembolsoPropostaPacienteClienteRazaoSocial);
               GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ReembolsoPropostaPacienteClienteRazaoSocial, "@!")), context));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            AV10Reembolso = new SdtReembolso(context);
         }
         AV16INJSON = AV8Array_SdDocumentosReembolso.ToJSonString(false);
         edtavWorkflowconvenioid_Visible = 0;
         AssignProp("", false, edtavWorkflowconvenioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWorkflowconvenioid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOWORKFLOWCONVENIOID' */
         S112 ();
         if (returnInSub) return;
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
            WebComp_Wcreembolsoflowlogww.componentprepare(new Object[] {(string)"W0051",(string)"",(int)AV31ReembolsoId});
            WebComp_Wcreembolsoflowlogww.componentbind(new Object[] {(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcdocumentosobrigatoriosreembolso = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component), StringUtil.Lower( "WcDocumentosObrigatoriosReembolso")) != 0 )
         {
            WebComp_Wcwcdocumentosobrigatoriosreembolso = getWebComponent(GetType(), "GeneXus.Programs", "wcdocumentosobrigatoriosreembolso", new Object[] {context} );
            WebComp_Wcwcdocumentosobrigatoriosreembolso.ComponentInit();
            WebComp_Wcwcdocumentosobrigatoriosreembolso.Name = "WcDocumentosObrigatoriosReembolso";
            WebComp_Wcwcdocumentosobrigatoriosreembolso_Component = "WcDocumentosObrigatoriosReembolso";
         }
         if ( StringUtil.Len( WebComp_Wcwcdocumentosobrigatoriosreembolso_Component) != 0 )
         {
            WebComp_Wcwcdocumentosobrigatoriosreembolso.setjustcreated();
            WebComp_Wcwcdocumentosobrigatoriosreembolso.componentprepare(new Object[] {(string)"W0043",(string)"",(string)AV16INJSON});
            WebComp_Wcwcdocumentosobrigatoriosreembolso.componentbind(new Object[] {(string)""});
         }
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV28CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV28CheckRequiredFieldsResult", AV28CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5ReembolsoProtocolo)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Protocolo", "", "", "", "", "", "", "", ""),  "error",  edtavReembolsoprotocolo_Internalname,  "true",  ""));
            AV28CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV28CheckRequiredFieldsResult", AV28CheckRequiredFieldsResult);
         }
         if ( (DateTime.MinValue==AV6ReembolsoDataAberturaConvenio) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Data abertura no convênio", "", "", "", "", "", "", "", ""),  "error",  edtavReembolsodataaberturaconvenio_Internalname,  "true",  ""));
            AV28CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV28CheckRequiredFieldsResult", AV28CheckRequiredFieldsResult);
         }
         if ( (0==AV27WorkflowConvenioId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Passo", "", "", "", "", "", "", "", ""),  "error",  Combo_workflowconvenioid_Ddointernalname,  "true",  ""));
            AV28CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV28CheckRequiredFieldsResult", AV28CheckRequiredFieldsResult);
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOWORKFLOWCONVENIOID' Routine */
         returnInSub = false;
         /* Using cursor H006L6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A737WorkflowConvenioStatus = H006L6_A737WorkflowConvenioStatus[0];
            n737WorkflowConvenioStatus = H006L6_n737WorkflowConvenioStatus[0];
            A742WorkflowConvenioId = H006L6_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = H006L6_n742WorkflowConvenioId[0];
            A736WorkflowConvenioDesc = H006L6_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = H006L6_n736WorkflowConvenioDesc[0];
            AV30Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV30Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A742WorkflowConvenioId), 9, 0));
            AV30Combo_DataItem.gxTpr_Title = A736WorkflowConvenioDesc;
            AV29WorkflowConvenioId_Data.Add(AV30Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_workflowconvenioid_Selectedvalue_set = ((0==AV27WorkflowConvenioId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV27WorkflowConvenioId), 9, 0)));
         ucCombo_workflowconvenioid.SendProperty(context, "", false, Combo_workflowconvenioid_Internalname, "SelectedValue_set", Combo_workflowconvenioid_Selectedvalue_set);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E126L2 ();
         if (returnInSub) return;
      }

      protected void E126L2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV28CheckRequiredFieldsResult )
         {
            AV10Reembolso.gxTpr_Reembolsopropostaid = AV7PropostaId;
            AV10Reembolso.gxTpr_Reembolsoprotocolo = AV5ReembolsoProtocolo;
            AV10Reembolso.gxTpr_Reembolsocreatedat = DateTimeUtil.ServerNow( context, pr_default);
            AV10Reembolso.gxTpr_Reembolsodataaberturaconvenio = AV6ReembolsoDataAberturaConvenio;
            AV10Reembolso.gxTpr_Reembolsocreatedby = AV11WWPContext.gxTpr_Userid;
            AV10Reembolso.gxTpr_Workflowconvenioid = AV27WorkflowConvenioId;
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
                           /* Using cursor H006L7 */
                           pr_default.execute(5);
                           while ( (pr_default.getStatus(5) != 101) )
                           {
                              A380AprovadoresStatus = H006L7_A380AprovadoresStatus[0];
                              n380AprovadoresStatus = H006L7_n380AprovadoresStatus[0];
                              A133SecUserId = H006L7_A133SecUserId[0];
                              n133SecUserId = H006L7_n133SecUserId[0];
                              A144SecUserEmail = H006L7_A144SecUserEmail[0];
                              n144SecUserEmail = H006L7_n144SecUserEmail[0];
                              A144SecUserEmail = H006L7_A144SecUserEmail[0];
                              n144SecUserEmail = H006L7_n144SecUserEmail[0];
                              AV24UserNotification = new SdtUserNotification(context);
                              AV24UserNotification.gxTpr_Notificationid = AV23BcNotification.gxTpr_Notificationid;
                              AV24UserNotification.gxTpr_Usernotificationuserid = A133SecUserId;
                              AV24UserNotification.gxTv_SdtUserNotification_Usernotificationreadat_SetNull();
                              AV25Array_Email.Add(A144SecUserEmail, 0);
                              new insertusernotification(context ).execute(  AV24UserNotification, out  AV20Messages) ;
                              if ( ! (0==AV20Messages.Count) )
                              {
                                 context.RollbackDataStores("wpreembolso",pr_default);
                                 context.setWebReturnParms(new Object[] {});
                                 context.setWebReturnParmsMetadata(new Object[] {});
                                 context.wjLocDisableFrm = 1;
                                 context.nUserReturn = 1;
                                 pr_default.close(5);
                                 returnInSub = true;
                                 if (true) return;
                                 new showmessages(context ).execute( ) ;
                              }
                              pr_default.readNext(5);
                           }
                           pr_default.close(5);
                           new sendemail(context).executeSubmit(  "Novo reembolso",  AV19HTML,  AV25Array_Email, out  AV26message) ;
                        }
                        else
                        {
                           context.RollbackDataStores("wpreembolso",pr_default);
                           context.setWebReturnParms(new Object[] {});
                           context.setWebReturnParmsMetadata(new Object[] {});
                           context.wjLocDisableFrm = 1;
                           context.nUserReturn = 1;
                           returnInSub = true;
                           if (true) return;
                           new showmessages(context ).execute( ) ;
                        }
                     }
                     context.CommitDataStores("wpreembolso",pr_default);
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
                        WebComp_Wcreembolsoflowlogww.componentprepare(new Object[] {(string)"W0051",(string)"",(int)AV31ReembolsoId});
                        WebComp_Wcreembolsoflowlogww.componentbind(new Object[] {(string)""});
                     }
                     if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcreembolsoflowlogww )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0051"+"");
                        WebComp_Wcreembolsoflowlogww.componentdraw();
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
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

      protected void E136L2( )
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
         PA6L2( ) ;
         WS6L2( ) ;
         WE6L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019261473", true, true);
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
         context.AddJavascriptSource("wpreembolso.js", "?202561019261474", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblGeral_title_Internalname = "GERAL_TITLE";
         edtavReembolsoprotocolo_Internalname = "vREEMBOLSOPROTOCOLO";
         edtavReembolsodataaberturaconvenio_Internalname = "vREEMBOLSODATAABERTURACONVENIO";
         lblTextblockcombo_workflowconvenioid_Internalname = "TEXTBLOCKCOMBO_WORKFLOWCONVENIOID";
         Combo_workflowconvenioid_Internalname = "COMBO_WORKFLOWCONVENIOID";
         divTablesplittedworkflowconvenioid_Internalname = "TABLESPLITTEDWORKFLOWCONVENIOID";
         divTablereembolso_Internalname = "TABLEREEMBOLSO";
         divTablecontent_Internalname = "TABLECONTENT";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblPasso_title_Internalname = "PASSO_TITLE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavWorkflowconvenioid_Internalname = "vWORKFLOWCONVENIOID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         edtavWorkflowconvenioid_Jsonclick = "";
         edtavWorkflowconvenioid_Visible = 1;
         edtavReembolsodataaberturaconvenio_Jsonclick = "";
         edtavReembolsodataaberturaconvenio_Enabled = 1;
         edtavReembolsoprotocolo_Jsonclick = "";
         edtavReembolsoprotocolo_Enabled = 1;
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 2;
         Combo_workflowconvenioid_Emptyitem = Convert.ToBoolean( 0);
         Combo_workflowconvenioid_Cls = "ExtendedCombo AttributeFL";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV11WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV17IsUpdate","fld":"vISUPDATE","hsh":true,"type":"boolean"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV22NotificationLink","fld":"vNOTIFICATIONLINK","hsh":true,"type":"svchar"},{"av":"AV31ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("ENTER","""{"handler":"E126L2","iparms":[{"av":"AV28CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV7PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV10Reembolso","fld":"vREEMBOLSO","type":""},{"av":"AV5ReembolsoProtocolo","fld":"vREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV6ReembolsoDataAberturaConvenio","fld":"vREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV11WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV27WorkflowConvenioId","fld":"vWORKFLOWCONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV8Array_SdDocumentosReembolso","fld":"vARRAY_SDDOCUMENTOSREEMBOLSO","type":""},{"av":"AV17IsUpdate","fld":"vISUPDATE","hsh":true,"type":"boolean"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV22NotificationLink","fld":"vNOTIFICATIONLINK","hsh":true,"type":"svchar"},{"av":"A380AprovadoresStatus","fld":"APROVADORESSTATUS","type":"boolean"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","type":"int"},{"av":"A144SecUserEmail","fld":"SECUSEREMAIL","type":"svchar"},{"av":"AV25Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV26message","fld":"vMESSAGE","type":"svchar"},{"av":"AV31ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Combo_workflowconvenioid_Ddointernalname","ctrl":"COMBO_WORKFLOWCONVENIOID","prop":"DDOInternalName"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV10Reembolso","fld":"vREEMBOLSO","type":""},{"av":"AV25Array_Email","fld":"vARRAY_EMAIL","type":""},{"av":"AV26message","fld":"vMESSAGE","type":"svchar"},{"ctrl":"WCREEMBOLSOFLOWLOGWW"},{"av":"AV28CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
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
         Combo_workflowconvenioid_Selectedvalue_get = "";
         Combo_workflowconvenioid_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV18ReembolsoPropostaPacienteClienteRazaoSocial = "";
         AV22NotificationLink = "";
         AV29WorkflowConvenioId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9JSON = "";
         AV10Reembolso = new SdtReembolso(context);
         AV8Array_SdDocumentosReembolso = new GXBaseCollection<SdtSdDocumentosReembolso>( context, "SdDocumentosReembolso", "Factory21");
         A144SecUserEmail = "";
         AV25Array_Email = new GxSimpleCollection<string>();
         AV26message = "";
         Combo_workflowconvenioid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblGeral_title_Jsonclick = "";
         TempTags = "";
         AV5ReembolsoProtocolo = "";
         AV6ReembolsoDataAberturaConvenio = DateTime.MinValue;
         lblTextblockcombo_workflowconvenioid_Jsonclick = "";
         ucCombo_workflowconvenioid = new GXUserControl();
         Combo_workflowconvenioid_Caption = "";
         WebComp_Wcwcdocumentosobrigatoriosreembolso_Component = "";
         OldWcwcdocumentosobrigatoriosreembolso = "";
         lblPasso_title_Jsonclick = "";
         WebComp_Wcreembolsoflowlogww_Component = "";
         OldWcreembolsoflowlogww = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33Array_ClientesIds = new GxSimpleCollection<int>();
         H006L2_A323PropostaId = new int[1] ;
         H006L2_A504PropostaPacienteClienteId = new int[1] ;
         H006L2_n504PropostaPacienteClienteId = new bool[] {false} ;
         AV32ClientesIds = new GxSimpleCollection<string>();
         H006L3_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         H006L3_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         H006L3_A518ReembolsoId = new int[1] ;
         H006L3_n518ReembolsoId = new bool[] {false} ;
         H006L3_A542ReembolsoPropostaId = new int[1] ;
         H006L3_n542ReembolsoPropostaId = new bool[] {false} ;
         H006L3_A546ReembolsoProtocolo = new string[] {""} ;
         H006L3_n546ReembolsoProtocolo = new bool[] {false} ;
         H006L3_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         H006L3_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         H006L3_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H006L3_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H006L3_A742WorkflowConvenioId = new int[1] ;
         H006L3_n742WorkflowConvenioId = new bool[] {false} ;
         A546ReembolsoProtocolo = "";
         A525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         H006L4_A526ReembolsoEtapaId = new int[1] ;
         H006L4_n526ReembolsoEtapaId = new bool[] {false} ;
         H006L4_A518ReembolsoId = new int[1] ;
         H006L4_n518ReembolsoId = new bool[] {false} ;
         H006L4_A530ReembolsoDocumentoNome = new string[] {""} ;
         H006L4_n530ReembolsoDocumentoNome = new bool[] {false} ;
         H006L4_A532ReembolsoDocumentoBlobExt = new string[] {""} ;
         H006L4_n532ReembolsoDocumentoBlobExt = new bool[] {false} ;
         H006L4_A405DocumentosId = new int[1] ;
         H006L4_n405DocumentosId = new bool[] {false} ;
         H006L4_A529ReembolsoDocumentoId = new int[1] ;
         H006L4_A549ReembolsoDocumentoStatus = new string[] {""} ;
         H006L4_n549ReembolsoDocumentoStatus = new bool[] {false} ;
         H006L4_A531ReembolsoDocumentoBlob = new string[] {""} ;
         H006L4_n531ReembolsoDocumentoBlob = new bool[] {false} ;
         A530ReembolsoDocumentoNome = "";
         A532ReembolsoDocumentoBlobExt = "";
         A549ReembolsoDocumentoStatus = "";
         A531ReembolsoDocumentoBlob = "";
         AV13SdDocumentosReembolso = new SdtSdDocumentosReembolso(context);
         H006L5_A504PropostaPacienteClienteId = new int[1] ;
         H006L5_n504PropostaPacienteClienteId = new bool[] {false} ;
         H006L5_A323PropostaId = new int[1] ;
         H006L5_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H006L5_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         A505PropostaPacienteClienteRazaoSocial = "";
         AV16INJSON = "";
         H006L6_A737WorkflowConvenioStatus = new bool[] {false} ;
         H006L6_n737WorkflowConvenioStatus = new bool[] {false} ;
         H006L6_A742WorkflowConvenioId = new int[1] ;
         H006L6_n742WorkflowConvenioId = new bool[] {false} ;
         H006L6_A736WorkflowConvenioDesc = new string[] {""} ;
         H006L6_n736WorkflowConvenioDesc = new bool[] {false} ;
         A736WorkflowConvenioDesc = "";
         AV30Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV12ReembolsoEtapa = new SdtReembolsoEtapa(context);
         AV14ReembolsoDocumento = new SdtReembolsoDocumento(context);
         GXt_char2 = "";
         AV19HTML = "";
         GXt_char3 = "";
         AV21NotMessage = "";
         AV23BcNotification = new SdtBCNotification(context);
         AV20Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         H006L7_A375AprovadoresId = new int[1] ;
         H006L7_A380AprovadoresStatus = new bool[] {false} ;
         H006L7_n380AprovadoresStatus = new bool[] {false} ;
         H006L7_A133SecUserId = new short[1] ;
         H006L7_n133SecUserId = new bool[] {false} ;
         H006L7_A144SecUserEmail = new string[] {""} ;
         H006L7_n144SecUserEmail = new bool[] {false} ;
         AV24UserNotification = new SdtUserNotification(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpreembolso__default(),
            new Object[][] {
                new Object[] {
               H006L2_A323PropostaId, H006L2_A504PropostaPacienteClienteId, H006L2_n504PropostaPacienteClienteId
               }
               , new Object[] {
               H006L3_A558ReembolsoPropostaPacienteClienteId, H006L3_n558ReembolsoPropostaPacienteClienteId, H006L3_A518ReembolsoId, H006L3_A542ReembolsoPropostaId, H006L3_n542ReembolsoPropostaId, H006L3_A546ReembolsoProtocolo, H006L3_n546ReembolsoProtocolo, H006L3_A525ReembolsoDataAberturaConvenio, H006L3_n525ReembolsoDataAberturaConvenio, H006L3_A550ReembolsoPropostaPacienteClienteRazaoSocial,
               H006L3_n550ReembolsoPropostaPacienteClienteRazaoSocial, H006L3_A742WorkflowConvenioId, H006L3_n742WorkflowConvenioId
               }
               , new Object[] {
               H006L4_A526ReembolsoEtapaId, H006L4_n526ReembolsoEtapaId, H006L4_A518ReembolsoId, H006L4_n518ReembolsoId, H006L4_A530ReembolsoDocumentoNome, H006L4_n530ReembolsoDocumentoNome, H006L4_A532ReembolsoDocumentoBlobExt, H006L4_n532ReembolsoDocumentoBlobExt, H006L4_A405DocumentosId, H006L4_n405DocumentosId,
               H006L4_A529ReembolsoDocumentoId, H006L4_A549ReembolsoDocumentoStatus, H006L4_n549ReembolsoDocumentoStatus, H006L4_A531ReembolsoDocumentoBlob, H006L4_n531ReembolsoDocumentoBlob
               }
               , new Object[] {
               H006L5_A504PropostaPacienteClienteId, H006L5_n504PropostaPacienteClienteId, H006L5_A323PropostaId, H006L5_A505PropostaPacienteClienteRazaoSocial, H006L5_n505PropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               H006L6_A737WorkflowConvenioStatus, H006L6_n737WorkflowConvenioStatus, H006L6_A742WorkflowConvenioId, H006L6_A736WorkflowConvenioDesc, H006L6_n736WorkflowConvenioDesc
               }
               , new Object[] {
               H006L7_A375AprovadoresId, H006L7_A380AprovadoresStatus, H006L7_n380AprovadoresStatus, H006L7_A133SecUserId, H006L7_n133SecUserId, H006L7_A144SecUserEmail, H006L7_n144SecUserEmail
               }
            }
         );
         WebComp_Wcwcdocumentosobrigatoriosreembolso = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcreembolsoflowlogww = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short A133SecUserId ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV35GXLvl13 ;
      private short nGXWrapped ;
      private int AV7PropostaId ;
      private int wcpOAV7PropostaId ;
      private int AV31ReembolsoId ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int edtavReembolsoprotocolo_Enabled ;
      private int edtavReembolsodataaberturaconvenio_Enabled ;
      private int AV27WorkflowConvenioId ;
      private int edtavWorkflowconvenioid_Visible ;
      private int A323PropostaId ;
      private int A504PropostaPacienteClienteId ;
      private int A558ReembolsoPropostaPacienteClienteId ;
      private int A518ReembolsoId ;
      private int A542ReembolsoPropostaId ;
      private int A742WorkflowConvenioId ;
      private int A526ReembolsoEtapaId ;
      private int A405DocumentosId ;
      private int A529ReembolsoDocumentoId ;
      private int AV39GXV1 ;
      private int idxLst ;
      private string Combo_workflowconvenioid_Selectedvalue_get ;
      private string Combo_workflowconvenioid_Ddointernalname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_workflowconvenioid_Cls ;
      private string Combo_workflowconvenioid_Selectedvalue_set ;
      private string Gxuitabspanel_tabs1_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblGeral_title_Internalname ;
      private string lblGeral_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTablereembolso_Internalname ;
      private string edtavReembolsoprotocolo_Internalname ;
      private string TempTags ;
      private string edtavReembolsoprotocolo_Jsonclick ;
      private string edtavReembolsodataaberturaconvenio_Internalname ;
      private string edtavReembolsodataaberturaconvenio_Jsonclick ;
      private string divTablesplittedworkflowconvenioid_Internalname ;
      private string lblTextblockcombo_workflowconvenioid_Internalname ;
      private string lblTextblockcombo_workflowconvenioid_Jsonclick ;
      private string Combo_workflowconvenioid_Caption ;
      private string Combo_workflowconvenioid_Internalname ;
      private string WebComp_Wcwcdocumentosobrigatoriosreembolso_Component ;
      private string OldWcwcdocumentosobrigatoriosreembolso ;
      private string lblPasso_title_Internalname ;
      private string lblPasso_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string WebComp_Wcreembolsoflowlogww_Component ;
      private string OldWcreembolsoflowlogww ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavWorkflowconvenioid_Internalname ;
      private string edtavWorkflowconvenioid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private DateTime AV6ReembolsoDataAberturaConvenio ;
      private DateTime A525ReembolsoDataAberturaConvenio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17IsUpdate ;
      private bool AV28CheckRequiredFieldsResult ;
      private bool A380AprovadoresStatus ;
      private bool Combo_workflowconvenioid_Emptyitem ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n504PropostaPacienteClienteId ;
      private bool n558ReembolsoPropostaPacienteClienteId ;
      private bool n518ReembolsoId ;
      private bool n542ReembolsoPropostaId ;
      private bool n546ReembolsoProtocolo ;
      private bool n525ReembolsoDataAberturaConvenio ;
      private bool n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool n742WorkflowConvenioId ;
      private bool n526ReembolsoEtapaId ;
      private bool n530ReembolsoDocumentoNome ;
      private bool n532ReembolsoDocumentoBlobExt ;
      private bool n405DocumentosId ;
      private bool n549ReembolsoDocumentoStatus ;
      private bool n531ReembolsoDocumentoBlob ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool bDynCreated_Wcreembolsoflowlogww ;
      private bool bDynCreated_Wcwcdocumentosobrigatoriosreembolso ;
      private bool A737WorkflowConvenioStatus ;
      private bool n737WorkflowConvenioStatus ;
      private bool n736WorkflowConvenioDesc ;
      private bool AV15isOk ;
      private bool n380AprovadoresStatus ;
      private bool n133SecUserId ;
      private bool n144SecUserEmail ;
      private string AV9JSON ;
      private string AV16INJSON ;
      private string AV19HTML ;
      private string AV18ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string AV22NotificationLink ;
      private string A144SecUserEmail ;
      private string AV26message ;
      private string AV5ReembolsoProtocolo ;
      private string A546ReembolsoProtocolo ;
      private string A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string A530ReembolsoDocumentoNome ;
      private string A532ReembolsoDocumentoBlobExt ;
      private string A549ReembolsoDocumentoStatus ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A736WorkflowConvenioDesc ;
      private string AV21NotMessage ;
      private string A531ReembolsoDocumentoBlob ;
      private GXWebComponent WebComp_Wcwcdocumentosobrigatoriosreembolso ;
      private GXWebComponent WebComp_Wcreembolsoflowlogww ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucCombo_workflowconvenioid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV29WorkflowConvenioId_Data ;
      private SdtReembolso AV10Reembolso ;
      private GXBaseCollection<SdtSdDocumentosReembolso> AV8Array_SdDocumentosReembolso ;
      private GxSimpleCollection<string> AV25Array_Email ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private GxSimpleCollection<int> AV33Array_ClientesIds ;
      private IDataStoreProvider pr_default ;
      private int[] H006L2_A323PropostaId ;
      private int[] H006L2_A504PropostaPacienteClienteId ;
      private bool[] H006L2_n504PropostaPacienteClienteId ;
      private GxSimpleCollection<string> AV32ClientesIds ;
      private int[] H006L3_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] H006L3_n558ReembolsoPropostaPacienteClienteId ;
      private int[] H006L3_A518ReembolsoId ;
      private bool[] H006L3_n518ReembolsoId ;
      private int[] H006L3_A542ReembolsoPropostaId ;
      private bool[] H006L3_n542ReembolsoPropostaId ;
      private string[] H006L3_A546ReembolsoProtocolo ;
      private bool[] H006L3_n546ReembolsoProtocolo ;
      private DateTime[] H006L3_A525ReembolsoDataAberturaConvenio ;
      private bool[] H006L3_n525ReembolsoDataAberturaConvenio ;
      private string[] H006L3_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] H006L3_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private int[] H006L3_A742WorkflowConvenioId ;
      private bool[] H006L3_n742WorkflowConvenioId ;
      private int[] H006L4_A526ReembolsoEtapaId ;
      private bool[] H006L4_n526ReembolsoEtapaId ;
      private int[] H006L4_A518ReembolsoId ;
      private bool[] H006L4_n518ReembolsoId ;
      private string[] H006L4_A530ReembolsoDocumentoNome ;
      private bool[] H006L4_n530ReembolsoDocumentoNome ;
      private string[] H006L4_A532ReembolsoDocumentoBlobExt ;
      private bool[] H006L4_n532ReembolsoDocumentoBlobExt ;
      private int[] H006L4_A405DocumentosId ;
      private bool[] H006L4_n405DocumentosId ;
      private int[] H006L4_A529ReembolsoDocumentoId ;
      private string[] H006L4_A549ReembolsoDocumentoStatus ;
      private bool[] H006L4_n549ReembolsoDocumentoStatus ;
      private string[] H006L4_A531ReembolsoDocumentoBlob ;
      private bool[] H006L4_n531ReembolsoDocumentoBlob ;
      private SdtSdDocumentosReembolso AV13SdDocumentosReembolso ;
      private int[] H006L5_A504PropostaPacienteClienteId ;
      private bool[] H006L5_n504PropostaPacienteClienteId ;
      private int[] H006L5_A323PropostaId ;
      private string[] H006L5_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H006L5_n505PropostaPacienteClienteRazaoSocial ;
      private bool[] H006L6_A737WorkflowConvenioStatus ;
      private bool[] H006L6_n737WorkflowConvenioStatus ;
      private int[] H006L6_A742WorkflowConvenioId ;
      private bool[] H006L6_n742WorkflowConvenioId ;
      private string[] H006L6_A736WorkflowConvenioDesc ;
      private bool[] H006L6_n736WorkflowConvenioDesc ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV30Combo_DataItem ;
      private SdtReembolsoEtapa AV12ReembolsoEtapa ;
      private SdtReembolsoDocumento AV14ReembolsoDocumento ;
      private SdtBCNotification AV23BcNotification ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV20Messages ;
      private int[] H006L7_A375AprovadoresId ;
      private bool[] H006L7_A380AprovadoresStatus ;
      private bool[] H006L7_n380AprovadoresStatus ;
      private short[] H006L7_A133SecUserId ;
      private bool[] H006L7_n133SecUserId ;
      private string[] H006L7_A144SecUserEmail ;
      private bool[] H006L7_n144SecUserEmail ;
      private SdtUserNotification AV24UserNotification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpreembolso__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH006L2;
          prmH006L2 = new Object[] {
          new ParDef("AV7PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH006L3;
          prmH006L3 = new Object[] {
          new ParDef("AV7PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH006L4;
          prmH006L4 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmH006L5;
          prmH006L5 = new Object[] {
          new ParDef("AV7PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH006L6;
          prmH006L6 = new Object[] {
          };
          Object[] prmH006L7;
          prmH006L7 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H006L2", "SELECT PropostaId, PropostaPacienteClienteId FROM Proposta WHERE PropostaId = :AV7PropostaId ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006L2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H006L3", "SELECT T2.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T1.ReembolsoId, T1.ReembolsoPropostaId AS ReembolsoPropostaId, T1.ReembolsoProtocolo, T1.ReembolsoDataAberturaConvenio, T3.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T1.WorkflowConvenioId FROM ((Reembolso T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.ReembolsoPropostaId) LEFT JOIN Cliente T3 ON T3.ClienteId = T2.PropostaPacienteClienteId) WHERE T1.ReembolsoPropostaId = :AV7PropostaId ORDER BY T1.ReembolsoPropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006L3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006L4", "SELECT T1.ReembolsoEtapaId, T2.ReembolsoId, T1.ReembolsoDocumentoNome, T1.ReembolsoDocumentoBlobExt, T1.DocumentosId, T1.ReembolsoDocumentoId, T1.ReembolsoDocumentoStatus, T1.ReembolsoDocumentoBlob FROM (ReembolsoDocumento T1 LEFT JOIN ReembolsoEtapa T2 ON T2.ReembolsoEtapaId = T1.ReembolsoEtapaId) WHERE T2.ReembolsoId = :ReembolsoId ORDER BY T1.ReembolsoDocumentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006L4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006L5", "SELECT T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaId, T2.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial FROM (Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaPacienteClienteId) WHERE T1.PropostaId = :AV7PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006L5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H006L6", "SELECT WorkflowConvenioStatus, WorkflowConvenioId, WorkflowConvenioDesc FROM WorkflowConvenio WHERE WorkflowConvenioStatus ORDER BY WorkflowConvenioDesc ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006L6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006L7", "SELECT T1.AprovadoresId, T1.AprovadoresStatus, T1.SecUserId, T2.SecUserEmail FROM (Aprovadores T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId) WHERE T1.AprovadoresStatus ORDER BY T1.AprovadoresId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006L7,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 2 :
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
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 4 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 5 :
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
