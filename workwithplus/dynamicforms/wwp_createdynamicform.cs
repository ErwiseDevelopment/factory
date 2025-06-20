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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_createdynamicform : GXDataArea
   {
      public wwp_createdynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_createdynamicform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId ,
                           string aP1_WWPDynamicFormMode ,
                           string aP2_DefaultFormType ,
                           short aP3_WWPFormType )
      {
         this.AV31WWPFormId = aP0_WWPFormId;
         this.AV26WWPDynamicFormMode = aP1_WWPDynamicFormMode;
         this.AV6DefaultFormType = aP2_DefaultFormType;
         this.AV43WWPFormType = aP3_WWPFormType;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavDynamicsectiontoupdate = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "WWPFormId");
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
               gxfirstwebparm = GetFirstPar( "WWPFormId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "WWPFormId");
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
         PA0Z2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0Z2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform"+UrlEncode(StringUtil.LTrimStr(AV31WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV26WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.RTrim(AV6DefaultFormType)) + "," + UrlEncode(StringUtil.LTrimStr(AV43WWPFormType,1,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_createdynamicform") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31WWPFormId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV26WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26WWPDynamicFormMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vDEFAULTFORMTYPE", AV6DefaultFormType);
         GxWebStd.gx_hidden_field( context, "gxhash_vDEFAULTFORMTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DefaultFormType, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43WWPFormType), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV43WWPFormType), "9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vREFRESHMASTERTITLE", AV12RefreshMasterTitle);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPFORM", AV27WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPFORM", AV27WWPForm);
         }
         GxWebStd.gx_hidden_field( context, "vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV26WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26WWPDynamicFormMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vADDEDSTEPINDEX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AddedStepIndex), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43WWPFormType), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV43WWPFormType), "9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENT", AV7Element);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENT", AV7Element);
         }
         GxWebStd.gx_hidden_field( context, "WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A94WWPFormId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32WWPFormVersionNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A95WWPFormVersionNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31WWPFormId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "WWPFORMINSTANTIATED", A122WWPFormInstantiated);
         GxWebStd.gx_hidden_field( context, "WWPFORMDATE", context.localUtil.TToC( A119WWPFormDate, 10, 8, 0, 0, "/", ":", " "));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV11Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV11Messages);
         }
         GxWebStd.gx_hidden_field( context, "vDEFAULTFORMTYPE", AV6DefaultFormType);
         GxWebStd.gx_hidden_field( context, "gxhash_vDEFAULTFORMTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DefaultFormType, "")), context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Width", StringUtil.RTrim( Dvpanel_unnamedtable1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Cls", StringUtil.RTrim( Dvpanel_unnamedtable1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Title", StringUtil.RTrim( Dvpanel_unnamedtable1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "SETTINGS_MODAL_Width", StringUtil.RTrim( Settings_modal_Width));
         GxWebStd.gx_hidden_field( context, "SETTINGS_MODAL_Title", StringUtil.RTrim( Settings_modal_Title));
         GxWebStd.gx_hidden_field( context, "SETTINGS_MODAL_Confirmtype", StringUtil.RTrim( Settings_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "SETTINGS_MODAL_Bodytype", StringUtil.RTrim( Settings_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "vWWPFORM_Wwpformtitle", AV27WWPForm.gxTpr_Wwpformtitle);
         GxWebStd.gx_hidden_field( context, "SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
         GxWebStd.gx_hidden_field( context, "SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
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
         if ( ! ( WebComp_Wcwwp_dynamicformfs_wc == null ) )
         {
            WebComp_Wcwwp_dynamicformfs_wc.componentjscripts();
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
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
            WE0Z2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0Z2( ) ;
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
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform"+UrlEncode(StringUtil.LTrimStr(AV31WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV26WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.RTrim(AV6DefaultFormType)) + "," + UrlEncode(StringUtil.LTrimStr(AV43WWPFormType,1,0));
         return formatLink("workwithplus.dynamicforms.wwp_createdynamicform") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.DynamicForms.WWP_CreateDynamicForm" ;
      }

      public override string GetPgmdesc( )
      {
         return "Dynamic form" ;
      }

      protected void WB0Z0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", divTablemain_Class, "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDvpanel_unnamedtable1_cell_Internalname, 1, 0, "px", 0, "px", divDvpanel_unnamedtable1_cell_Class, "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable1.SetProperty("Width", Dvpanel_unnamedtable1_Width);
            ucDvpanel_unnamedtable1.SetProperty("AutoWidth", Dvpanel_unnamedtable1_Autowidth);
            ucDvpanel_unnamedtable1.SetProperty("AutoHeight", Dvpanel_unnamedtable1_Autoheight);
            ucDvpanel_unnamedtable1.SetProperty("Cls", Dvpanel_unnamedtable1_Cls);
            ucDvpanel_unnamedtable1.SetProperty("Title", Dvpanel_unnamedtable1_Title);
            ucDvpanel_unnamedtable1.SetProperty("Collapsible", Dvpanel_unnamedtable1_Collapsible);
            ucDvpanel_unnamedtable1.SetProperty("Collapsed", Dvpanel_unnamedtable1_Collapsed);
            ucDvpanel_unnamedtable1.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable1_Showcollapseicon);
            ucDvpanel_unnamedtable1.SetProperty("IconPosition", Dvpanel_unnamedtable1_Iconposition);
            ucDvpanel_unnamedtable1.SetProperty("AutoScroll", Dvpanel_unnamedtable1_Autoscroll);
            ucDvpanel_unnamedtable1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable1_Internalname, "DVPANEL_UNNAMEDTABLE1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE1Container"+"UnnamedTable1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavDynamicsectiontoupdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicsectiontoupdate_Internalname, "Dynamic Section", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicsectiontoupdate, cmbavDynamicsectiontoupdate_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV42DynamicSectionToUpdate), 4, 0)), 1, cmbavDynamicsectiontoupdate_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICSECTIONTOUPDATE.CLICK."+"'", "int", "", 1, cmbavDynamicsectiontoupdate.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_CreateDynamicForm.htm");
            cmbavDynamicsectiontoupdate.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42DynamicSectionToUpdate), 4, 0));
            AssignProp("", false, cmbavDynamicsectiontoupdate_Internalname, "Values", (string)(cmbavDynamicsectiontoupdate.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0025"+"", StringUtil.RTrim( WebComp_Wcwwp_dynamicformfs_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0025"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwwp_dynamicformfs_wc), StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0025"+"");
                  }
                  WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwwp_dynamicformfs_wc), StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component)) != 0 )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_CreateDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_CreateDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsettings_Internalname, "", "UASettings", bttBtnsettings_Jsonclick, 7, "UASettings", "", StyleString, ClassString, bttBtnsettings_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110z1_client"+"'", TempTags, "", 2, "HLP_WorkWithPlus/DynamicForms/WWP_CreateDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FixingTopInvisible", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnrefreshgrid_Internalname, "", "UARefreshGrid", bttBtnrefreshgrid_Jsonclick, 5, "UARefreshGrid", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREFRESHGRID\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_CreateDynamicForm.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSessionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SessionId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13SessionId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSessionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSessionid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_CreateDynamicForm.htm");
            wb_table1_42_0Z2( true) ;
         }
         else
         {
            wb_table1_42_0Z2( false) ;
         }
         return  ;
      }

      protected void wb_table1_42_0Z2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0048"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0048"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0048"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
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
         }
         wbLoad = true;
      }

      protected void START0Z2( )
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
         Form.Meta.addItem("description", "Dynamic form", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0Z0( ) ;
      }

      protected void WS0Z2( )
      {
         START0Z2( ) ;
         EVT0Z2( ) ;
      }

      protected void EVT0Z2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Settings_modal.Close */
                              E120Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Settings_modal.Onloadcomponent */
                              E130Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E140Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREFRESHGRID'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoRefreshGrid' */
                              E150Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E160Z2 ();
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
                                    E170Z2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICSECTIONTOUPDATE.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E180Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E190Z2 ();
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
                        if ( nCmpId == 25 )
                        {
                           OldWcwwp_dynamicformfs_wc = cgiGet( "W0025");
                           if ( ( StringUtil.Len( OldWcwwp_dynamicformfs_wc) == 0 ) || ( StringUtil.StrCmp(OldWcwwp_dynamicformfs_wc, WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 ) )
                           {
                              WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWcwwp_dynamicformfs_wc, new Object[] {context} );
                              WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
                              WebComp_Wcwwp_dynamicformfs_wc.Name = "OldWcwwp_dynamicformfs_wc";
                              WebComp_Wcwwp_dynamicformfs_wc_Component = OldWcwwp_dynamicformfs_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
                           {
                              WebComp_Wcwwp_dynamicformfs_wc.componentprocess("W0025", "", sEvt);
                           }
                           WebComp_Wcwwp_dynamicformfs_wc_Component = OldWcwwp_dynamicformfs_wc;
                        }
                        else if ( nCmpId == 48 )
                        {
                           OldWwpaux_wc = cgiGet( "W0048");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0048", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0Z2( )
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

      protected void PA0Z2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_createdynamicform")), "workwithplus.dynamicforms.wwp_createdynamicform") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_createdynamicform")))) ;
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
                  gxfirstwebparm = GetFirstPar( "WWPFormId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV31WWPFormId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV31WWPFormId", StringUtil.LTrimStr( (decimal)(AV31WWPFormId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31WWPFormId), "ZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV26WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                        AssignAttri("", false, "AV26WWPDynamicFormMode", AV26WWPDynamicFormMode);
                        GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26WWPDynamicFormMode, "")), context));
                        AV6DefaultFormType = GetPar( "DefaultFormType");
                        AssignAttri("", false, "AV6DefaultFormType", AV6DefaultFormType);
                        GxWebStd.gx_hidden_field( context, "gxhash_vDEFAULTFORMTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DefaultFormType, "")), context));
                        AV43WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV43WWPFormType", StringUtil.Str( (decimal)(AV43WWPFormType), 1, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV43WWPFormType), "9"), context));
                     }
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
               GX_FocusControl = cmbavDynamicsectiontoupdate_Internalname;
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
         if ( cmbavDynamicsectiontoupdate.ItemCount > 0 )
         {
            AV42DynamicSectionToUpdate = (short)(Math.Round(NumberUtil.Val( cmbavDynamicsectiontoupdate.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV42DynamicSectionToUpdate), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV42DynamicSectionToUpdate", StringUtil.LTrimStr( (decimal)(AV42DynamicSectionToUpdate), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicsectiontoupdate.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV42DynamicSectionToUpdate), 4, 0));
            AssignProp("", false, cmbavDynamicsectiontoupdate_Internalname, "Values", cmbavDynamicsectiontoupdate.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E160Z2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
               {
                  WebComp_Wcwwp_dynamicformfs_wc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E190Z2 ();
            WB0Z0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0Z2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E140Z2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_unnamedtable1_Width = cgiGet( "DVPANEL_UNNAMEDTABLE1_Width");
            Dvpanel_unnamedtable1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autowidth"));
            Dvpanel_unnamedtable1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoheight"));
            Dvpanel_unnamedtable1_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE1_Cls");
            Dvpanel_unnamedtable1_Title = cgiGet( "DVPANEL_UNNAMEDTABLE1_Title");
            Dvpanel_unnamedtable1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsible"));
            Dvpanel_unnamedtable1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsed"));
            Dvpanel_unnamedtable1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Showcollapseicon"));
            Dvpanel_unnamedtable1_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE1_Iconposition");
            Dvpanel_unnamedtable1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoscroll"));
            Settings_modal_Width = cgiGet( "SETTINGS_MODAL_Width");
            Settings_modal_Title = cgiGet( "SETTINGS_MODAL_Title");
            Settings_modal_Confirmtype = cgiGet( "SETTINGS_MODAL_Confirmtype");
            Settings_modal_Bodytype = cgiGet( "SETTINGS_MODAL_Bodytype");
            Settings_modal_Result = cgiGet( "SETTINGS_MODAL_Result");
            /* Read variables values. */
            cmbavDynamicsectiontoupdate.CurrentValue = cgiGet( cmbavDynamicsectiontoupdate_Internalname);
            AV42DynamicSectionToUpdate = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicsectiontoupdate_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV42DynamicSectionToUpdate", StringUtil.LTrimStr( (decimal)(AV42DynamicSectionToUpdate), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSessionid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSessionid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSESSIONID");
               GX_FocusControl = edtavSessionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13SessionId = 0;
               AssignAttri("", false, "AV13SessionId", StringUtil.LTrimStr( (decimal)(AV13SessionId), 4, 0));
            }
            else
            {
               AV13SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavSessionid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13SessionId", StringUtil.LTrimStr( (decimal)(AV13SessionId), 4, 0));
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
         E140Z2 ();
         if (returnInSub) return;
      }

      protected void E140Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV9HttpRequest.Method, "GET") == 0 )
         {
            AV13SessionId = (short)(NumberUtil.Random( )*10000);
            AssignAttri("", false, "AV13SessionId", StringUtil.LTrimStr( (decimal)(AV13SessionId), 4, 0));
            if ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "INS") == 0 )
            {
               AV27WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6DefaultFormType)) )
               {
                  AV27WWPForm.gxTpr_Wwpformiswizard = (bool)(((StringUtil.StrCmp(AV6DefaultFormType, "Wizard")==0)));
               }
               AV27WWPForm.gxTpr_Wwpformtype = 0;
            }
            else
            {
               /* Using cursor H000Z2 */
               pr_default.execute(0, new Object[] {AV31WWPFormId});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A94WWPFormId = H000Z2_A94WWPFormId[0];
                  A95WWPFormVersionNumber = H000Z2_A95WWPFormVersionNumber[0];
                  AV32WWPFormVersionNumber = A95WWPFormVersionNumber;
                  AssignAttri("", false, "AV32WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV32WWPFormVersionNumber), 4, 0));
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               if ( (0==AV32WWPFormVersionNumber) )
               {
                  GX_msglist.addItem("Registro n�o encontrado");
                  bttBtnenter_Visible = 0;
                  AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
               }
               else
               {
                  AV27WWPForm.Load(AV31WWPFormId, AV32WWPFormVersionNumber);
                  AV27WWPForm.gxTpr_Element.Sort("WWPFormElementOrderIndex");
                  if ( ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "UPD") == 0 ) || ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "DLT") == 0 ) )
                  {
                     bttBtnenter_Caption = ((StringUtil.StrCmp(AV26WWPDynamicFormMode, "UPD")==0) ? "Confirmar" : "Eliminar");
                     AssignProp("", false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
                  }
                  else
                  {
                     bttBtnenter_Visible = 0;
                     AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
                  }
               }
               if ( AV43WWPFormType == 0 )
               {
                  Form.Caption = AV27WWPForm.gxTpr_Wwpformtitle;
                  AssignProp("", false, "FORM", "Caption", Form.Caption, true);
               }
               else
               {
                  Form.Caption = StringUtil.Format( "Sec��es din�micas para % 1", AV27WWPForm.gxTpr_Wwpformreferencename, "", "", "", "", "", "", "", "");
                  AssignProp("", false, "FORM", "Caption", Form.Caption, true);
                  divTablemain_Class = "TableMainDynamicForm TableMainDynamicSections";
                  AssignProp("", false, divTablemain_Internalname, "Class", divTablemain_Class, true);
               }
            }
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveformdefinition(context ).execute(  AV13SessionId,  AV27WWPForm) ;
            if ( AV43WWPFormType == 1 )
            {
               AV47GXV1 = 1;
               while ( AV47GXV1 <= AV27WWPForm.gxTpr_Element.Count )
               {
                  AV44WWPFormElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV27WWPForm.gxTpr_Element.Item(AV47GXV1));
                  if ( AV44WWPFormElement.gxTpr_Wwpformelementparentid == 0 )
                  {
                     cmbavDynamicsectiontoupdate.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV44WWPFormElement.gxTpr_Wwpformelementid), 4, 0)), AV44WWPFormElement.gxTpr_Wwpformelementreferenceid, 0);
                     if ( (0==AV42DynamicSectionToUpdate) )
                     {
                        AV42DynamicSectionToUpdate = AV44WWPFormElement.gxTpr_Wwpformelementid;
                        AssignAttri("", false, "AV42DynamicSectionToUpdate", StringUtil.LTrimStr( (decimal)(AV42DynamicSectionToUpdate), 4, 0));
                     }
                  }
                  AV47GXV1 = (int)(AV47GXV1+1);
               }
            }
         }
         bttBtnsettings_Visible = 0;
         AssignProp("", false, bttBtnsettings_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsettings_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "DSP") == 0 )
         {
            divTablemain_Class = "TableMainDynamicForm TableMainDynamicFormDSP";
            AssignProp("", false, divTablemain_Internalname, "Class", divTablemain_Class, true);
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         edtavSessionid_Visible = 0;
         AssignProp("", false, edtavSessionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSessionid_Visible), 5, 0), true);
      }

      protected void E130Z2( )
      {
         /* Settings_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_AddElement")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_addelement", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_AddElement";
            WebComp_Wwpaux_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_AddElement";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0048",(string)"",(string)"UPD",(short)0,(short)0,(short)AV13SessionId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"vSESSIONID"});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0048"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E150Z2( )
      {
         /* 'DoRefreshGrid' Routine */
         returnInSub = false;
         GXt_SdtWWP_Form1 = AV27WWPForm;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV13SessionId, out  GXt_SdtWWP_Form1) ;
         AV27WWPForm = GXt_SdtWWP_Form1;
         AV12RefreshMasterTitle = true;
         AssignAttri("", false, "AV12RefreshMasterTitle", AV12RefreshMasterTitle);
         AV5AddedStepIndex = (short)(Math.Round(NumberUtil.Val( AV16WebSession.Get("WWPDynFormCreation_DefaultStep"), "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV5AddedStepIndex", StringUtil.LTrimStr( (decimal)(AV5AddedStepIndex), 4, 0));
         AV16WebSession.Remove("WWPDynFormCreation_DefaultStep");
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27WWPForm", AV27WWPForm);
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( AV43WWPFormType == 1 ) ) )
         {
            divDvpanel_unnamedtable1_cell_Class = "Invisible";
            AssignProp("", false, divDvpanel_unnamedtable1_cell_Internalname, "Class", divDvpanel_unnamedtable1_cell_Class, true);
         }
         else
         {
            divDvpanel_unnamedtable1_cell_Class = "col-xs-12 CellMarginBottom15";
            AssignProp("", false, divDvpanel_unnamedtable1_cell_Internalname, "Class", divDvpanel_unnamedtable1_cell_Class, true);
         }
      }

      protected void E160Z2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( AV12RefreshMasterTitle )
         {
            Form.Caption = AV27WWPForm.gxTpr_Wwpformtitle;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            this.executeExternalObjectMethod("", false, "GlobalEvents", "Master_RefreshTitle", new Object[] {AV27WWPForm.gxTpr_Wwpformtitle}, true);
            AV12RefreshMasterTitle = false;
            AssignAttri("", false, "AV12RefreshMasterTitle", AV12RefreshMasterTitle);
         }
         if ( AV27WWPForm.gxTpr_Wwpformiswizard )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcwwp_dynamicformfs_wc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_Wizard_WC")) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_wizard_wc", new Object[] {context} );
               WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
               WebComp_Wcwwp_dynamicformfs_wc.Name = "WorkWithPlus.DynamicForms.WWP_DFC_Wizard_WC";
               WebComp_Wcwwp_dynamicformfs_wc_Component = "WorkWithPlus.DynamicForms.WWP_DFC_Wizard_WC";
            }
            if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc.setjustcreated();
               WebComp_Wcwwp_dynamicformfs_wc.componentprepare(new Object[] {(string)"W0025",(string)"",(string)AV26WWPDynamicFormMode,(short)AV13SessionId,(short)AV5AddedStepIndex,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV27WWPForm});
               WebComp_Wcwwp_dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)"vSESSIONID",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwwp_dynamicformfs_wc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0025"+"");
               WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            AV5AddedStepIndex = 0;
            AssignAttri("", false, "AV5AddedStepIndex", StringUtil.LTrimStr( (decimal)(AV5AddedStepIndex), 4, 0));
         }
         else
         {
            AV45WWPFormElementId = (short)(((AV43WWPFormType==0) ? 0 : AV42DynamicSectionToUpdate));
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcwwp_dynamicformfs_wc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_FS_WC")) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_fs_wc", new Object[] {context} );
               WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
               WebComp_Wcwwp_dynamicformfs_wc.Name = "WorkWithPlus.DynamicForms.WWP_DFC_FS_WC";
               WebComp_Wcwwp_dynamicformfs_wc_Component = "WorkWithPlus.DynamicForms.WWP_DFC_FS_WC";
            }
            if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc.setjustcreated();
               WebComp_Wcwwp_dynamicformfs_wc.componentprepare(new Object[] {(string)"W0025",(string)"",(string)AV26WWPDynamicFormMode,(short)AV45WWPFormElementId,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV27WWPForm});
               WebComp_Wcwwp_dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)"",(string)"vSESSIONID",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwwp_dynamicformfs_wc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0025"+"");
               WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( ( StringUtil.StrCmp(AV9HttpRequest.Method, "GET") == 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( AV27WWPForm.gxTpr_Wwpformtitle)) && ( AV43WWPFormType == 0 ) )
         {
            this.executeUsercontrolMethod("", false, "SETTINGS_MODALContainer", "Confirm", "", new Object[] {});
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E170Z2 ();
         if (returnInSub) return;
      }

      protected void E170Z2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_SdtWWP_Form1 = AV27WWPForm;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV13SessionId, out  GXt_SdtWWP_Form1) ;
         AV27WWPForm = GXt_SdtWWP_Form1;
         if ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "DLT") != 0 )
         {
            /* Execute user subroutine: 'VALIDATE ELEMENTS CONDITIONS' */
            S122 ();
            if (returnInSub) return;
         }
         if ( ( AV11Messages.Count == 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( AV27WWPForm.gxTpr_Wwpformreferencename)) )
         {
            AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV41WWPFormElementType = AV7Element.gxTpr_Wwpformelementtype;
            GXt_char2 = AV38ElementTitle;
            new WorkWithPlus.workwithplus_dynamicforms.wwp_df_elementtypeenumerationdescription(context ).execute(  AV41WWPFormElementType, out  GXt_char2) ;
            GXt_char3 = AV38ElementTitle;
            new WorkWithPlus.workwithplus_dynamicforms.wwp_df_elementtypeenumerationdescription(context ).execute(  AV41WWPFormElementType, out  GXt_char3) ;
            AV38ElementTitle = (String.IsNullOrEmpty(StringUtil.RTrim( AV7Element.gxTpr_Wwpformelementtitle)) ? GXt_char3 : AV7Element.gxTpr_Wwpformelementtitle);
            AV10Message.gxTpr_Description = "O nome de refer�ncia � necess�rio.";
            AV11Messages.Add(AV10Message, 0);
         }
         if ( AV11Messages.Count == 0 )
         {
            if ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "INS") == 0 )
            {
               /* Using cursor H000Z3 */
               pr_default.execute(1);
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A94WWPFormId = H000Z3_A94WWPFormId[0];
                  AV27WWPForm.gxTpr_Wwpformid = A94WWPFormId;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV27WWPForm.gxTpr_Wwpformid = (short)(AV27WWPForm.gxTpr_Wwpformid+1);
               AV27WWPForm.gxTpr_Wwpformversionnumber = 1;
               AV27WWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
               AV27WWPForm.Save();
               if ( AV27WWPForm.Success() )
               {
                  context.CommitDataStores("workwithplus.dynamicforms.wwp_createdynamicform",pr_default);
               }
               else
               {
                  AV11Messages = AV27WWPForm.GetMessages();
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "DSP") != 0 ) && ! (0==AV32WWPFormVersionNumber) )
               {
                  /* Using cursor H000Z4 */
                  pr_default.execute(2, new Object[] {AV31WWPFormId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A94WWPFormId = H000Z4_A94WWPFormId[0];
                     A122WWPFormInstantiated = H000Z4_A122WWPFormInstantiated[0];
                     A119WWPFormDate = H000Z4_A119WWPFormDate[0];
                     A95WWPFormVersionNumber = H000Z4_A95WWPFormVersionNumber[0];
                     AV32WWPFormVersionNumber = A95WWPFormVersionNumber;
                     AssignAttri("", false, "AV32WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV32WWPFormVersionNumber), 4, 0));
                     AV28FormWasInstantiated = A122WWPFormInstantiated;
                     AV30WWPFormDate = A119WWPFormDate;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     pr_default.readNext(2);
                  }
                  pr_default.close(2);
                  if ( ( AV32WWPFormVersionNumber > AV27WWPForm.gxTpr_Wwpformversionnumber ) || ( AV30WWPFormDate != AV27WWPForm.gxTpr_Wwpformdate ) )
                  {
                     AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
                     AV10Message.gxTpr_Description = StringUtil.Format( "%1 foi modificada.", "Dynamic form", "", "", "", "", "", "", "", "");
                     AV11Messages.Add(AV10Message, 0);
                  }
                  else
                  {
                     if ( AV28FormWasInstantiated )
                     {
                        AV29NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
                        AV29NewWWPForm.gxTpr_Wwpformid = AV27WWPForm.gxTpr_Wwpformid;
                        AV29NewWWPForm.gxTpr_Wwpformversionnumber = (short)(AV27WWPForm.gxTpr_Wwpformversionnumber+1);
                        AV29NewWWPForm.gxTpr_Wwpformreferencename = AV27WWPForm.gxTpr_Wwpformreferencename;
                        AV29NewWWPForm.gxTpr_Wwpformtitle = AV27WWPForm.gxTpr_Wwpformtitle;
                        AV29NewWWPForm.gxTpr_Wwpformiswizard = AV27WWPForm.gxTpr_Wwpformiswizard;
                        AV29NewWWPForm.gxTpr_Wwpformvalidations = AV27WWPForm.gxTpr_Wwpformvalidations;
                        AV29NewWWPForm.gxTpr_Wwpformresume = AV27WWPForm.gxTpr_Wwpformresume;
                        AV29NewWWPForm.gxTpr_Wwpformresumemessage = AV27WWPForm.gxTpr_Wwpformresumemessage;
                        AV29NewWWPForm.gxTpr_Wwpformtype = AV27WWPForm.gxTpr_Wwpformtype;
                        AV29NewWWPForm.gxTpr_Wwpformsectionrefelements = AV27WWPForm.gxTpr_Wwpformsectionrefelements;
                        AV29NewWWPForm.gxTpr_Wwpformisfordynamicvalidations = AV27WWPForm.gxTpr_Wwpformisfordynamicvalidations;
                        AV50GXV2 = 1;
                        while ( AV50GXV2 <= AV27WWPForm.gxTpr_Element.Count )
                        {
                           AV7Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV27WWPForm.gxTpr_Element.Item(AV50GXV2));
                           if ( AV7Element.gxTpr_Wwpformelementparentid >= 0 )
                           {
                              AV29NewWWPForm.gxTpr_Element.Add(AV7Element, 0);
                           }
                           AV50GXV2 = (int)(AV50GXV2+1);
                        }
                        AV29NewWWPForm.gxTpr_Element.Sort("WWPFormElementId");
                        AV27WWPForm = AV29NewWWPForm;
                     }
                     else
                     {
                        if ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "UPD") == 0 )
                        {
                           AV27WWPForm.gxTpr_Element.Sort("WWPFormElementParentId");
                        }
                     }
                     AV27WWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
                     AV27WWPForm.Save();
                     if ( AV27WWPForm.Success() )
                     {
                        context.CommitDataStores("workwithplus.dynamicforms.wwp_createdynamicform",pr_default);
                     }
                     else
                     {
                        AV11Messages = AV27WWPForm.GetMessages();
                     }
                  }
               }
            }
         }
         if ( AV11Messages.Count > 0 )
         {
            AV51GXV3 = 1;
            while ( AV51GXV3 <= AV11Messages.Count )
            {
               AV10Message = ((GeneXus.Utils.SdtMessages_Message)AV11Messages.Item(AV51GXV3));
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV10Message.gxTpr_Description,  "error",  "",  "true",  ""));
               AV51GXV3 = (int)(AV51GXV3+1);
            }
         }
         else
         {
            AV16WebSession.Remove(StringUtil.Format( "WWP_DynamicFormDef_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV13SessionId), 4, 0)), "", "", "", "", "", "", "", ""));
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11Messages", AV11Messages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27WWPForm", AV27WWPForm);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Element", AV7Element);
      }

      protected void E180Z2( )
      {
         /* Dynamicsectiontoupdate_Click Routine */
         returnInSub = false;
         GXt_SdtWWP_Form1 = AV27WWPForm;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV13SessionId, out  GXt_SdtWWP_Form1) ;
         AV27WWPForm = GXt_SdtWWP_Form1;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwwp_dynamicformfs_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwwp_dynamicformfs_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DFC_FS_WC")) != 0 )
         {
            WebComp_Wcwwp_dynamicformfs_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_dfc_fs_wc", new Object[] {context} );
            WebComp_Wcwwp_dynamicformfs_wc.ComponentInit();
            WebComp_Wcwwp_dynamicformfs_wc.Name = "WorkWithPlus.DynamicForms.WWP_DFC_FS_WC";
            WebComp_Wcwwp_dynamicformfs_wc_Component = "WorkWithPlus.DynamicForms.WWP_DFC_FS_WC";
         }
         if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
         {
            WebComp_Wcwwp_dynamicformfs_wc.setjustcreated();
            WebComp_Wcwwp_dynamicformfs_wc.componentprepare(new Object[] {(string)"W0025",(string)"",(string)AV26WWPDynamicFormMode,(short)AV42DynamicSectionToUpdate,(short)AV13SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV27WWPForm});
            WebComp_Wcwwp_dynamicformfs_wc.componentbind(new Object[] {(string)"",(string)"vDYNAMICSECTIONTOUPDATE",(string)"vSESSIONID",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwwp_dynamicformfs_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0025"+"");
            WebComp_Wcwwp_dynamicformfs_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27WWPForm", AV27WWPForm);
      }

      protected void E120Z2( )
      {
         /* Settings_modal_Close Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Settings_modal_Result, "OK_AND_REFRESH") == 0 ) || ( StringUtil.StrCmp(Settings_modal_Result, "OK") == 0 ) )
         {
            GXt_SdtWWP_Form1 = AV27WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV13SessionId, out  GXt_SdtWWP_Form1) ;
            AV27WWPForm = GXt_SdtWWP_Form1;
            AV12RefreshMasterTitle = true;
            AssignAttri("", false, "AV12RefreshMasterTitle", AV12RefreshMasterTitle);
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27WWPForm", AV27WWPForm);
      }

      protected void S122( )
      {
         /* 'VALIDATE ELEMENTS CONDITIONS' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26WWPDynamicFormMode, "INS") == 0 )
         {
            AV8HasDeletedElements = false;
         }
         else
         {
            AV8HasDeletedElements = StringUtil.Contains( AV27WWPForm.ToJSonString(true, true), "\"Mode\":\"DLT\"");
         }
         GXt_char3 = AV34VarCharAux;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getavailablevariables(context ).execute(  AV13SessionId,  false,  0,  9999,  "", out  GXt_char3) ;
         AV34VarCharAux = GXt_char3;
         AV33AllReferenceIds.FromJSonString(StringUtil.Lower( AV34VarCharAux), null);
         AV52GXV4 = 1;
         while ( AV52GXV4 <= AV27WWPForm.gxTpr_Element.Count )
         {
            AV7Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV27WWPForm.gxTpr_Element.Item(AV52GXV4));
            if ( ! AV8HasDeletedElements || ! StringUtil.Contains( AV7Element.ToJSonString(true, true), "\"Mode\":\"DLT\"") )
            {
               AV15VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
               AV14Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Factory21");
               if ( AV7Element.gxTpr_Wwpformelementtype == 1 )
               {
                  if ( AV7Element.gxTpr_Wwpformelementdatatype == 1 )
                  {
                     AV17WWP_DF_BooleanMetadata.FromJSonString(AV7Element.gxTpr_Wwpformelementmetadata, null);
                     AV15VisibleCondition = AV17WWP_DF_BooleanMetadata.gxTpr_Visiblecondition;
                     AV14Validations = AV17WWP_DF_BooleanMetadata.gxTpr_Validations;
                  }
                  else if ( ( AV7Element.gxTpr_Wwpformelementdatatype == 2 ) || ( AV7Element.gxTpr_Wwpformelementdatatype == 6 ) || ( AV7Element.gxTpr_Wwpformelementdatatype == 7 ) || ( AV7Element.gxTpr_Wwpformelementdatatype == 8 ) )
                  {
                     AV18WWP_DF_CharMetadata.FromJSonString(AV7Element.gxTpr_Wwpformelementmetadata, null);
                     AV15VisibleCondition = AV18WWP_DF_CharMetadata.gxTpr_Visiblecondition;
                     AV14Validations = AV18WWP_DF_CharMetadata.gxTpr_Validations;
                  }
                  else if ( AV7Element.gxTpr_Wwpformelementdatatype == 3 )
                  {
                     AV24WWP_DF_NumericMetadata.FromJSonString(AV7Element.gxTpr_Wwpformelementmetadata, null);
                     AV15VisibleCondition = AV24WWP_DF_NumericMetadata.gxTpr_Visiblecondition;
                     AV14Validations = AV24WWP_DF_NumericMetadata.gxTpr_Validations;
                  }
                  else if ( ( AV7Element.gxTpr_Wwpformelementdatatype == 4 ) || ( AV7Element.gxTpr_Wwpformelementdatatype == 5 ) )
                  {
                     AV19WWP_DF_DateMetadata.FromJSonString(AV7Element.gxTpr_Wwpformelementmetadata, null);
                     AV15VisibleCondition = AV19WWP_DF_DateMetadata.gxTpr_Visiblecondition;
                     AV14Validations = AV19WWP_DF_DateMetadata.gxTpr_Validations;
                  }
                  else if ( ( AV7Element.gxTpr_Wwpformelementdatatype == 9 ) || ( AV7Element.gxTpr_Wwpformelementdatatype == 10 ) )
                  {
                     AV21WWP_DF_ImageMetadata.FromJSonString(AV7Element.gxTpr_Wwpformelementmetadata, null);
                     AV15VisibleCondition = AV21WWP_DF_ImageMetadata.gxTpr_Visiblecondition;
                     AV14Validations = AV21WWP_DF_ImageMetadata.gxTpr_Validations;
                  }
               }
               else if ( AV7Element.gxTpr_Wwpformelementtype == 2 )
               {
                  AV20WWP_DF_GroupMetadata.FromJSonString(AV7Element.gxTpr_Wwpformelementmetadata, null);
                  AV15VisibleCondition = AV20WWP_DF_GroupMetadata.gxTpr_Visiblecondition;
               }
               else if ( AV7Element.gxTpr_Wwpformelementtype == 3 )
               {
                  AV23WWP_DF_MultipleMetadata.FromJSonString(AV7Element.gxTpr_Wwpformelementmetadata, null);
                  AV15VisibleCondition = AV23WWP_DF_MultipleMetadata.gxTpr_Visiblecondition;
               }
               else if ( AV7Element.gxTpr_Wwpformelementtype == 4 )
               {
                  AV22WWP_DF_LabelMetadata.FromJSonString(AV7Element.gxTpr_Wwpformelementmetadata, null);
                  AV15VisibleCondition = AV22WWP_DF_LabelMetadata.gxTpr_Visiblecondition;
               }
               else if ( AV7Element.gxTpr_Wwpformelementtype == 5 )
               {
                  AV25WWP_DF_StepMetadata.FromJSonString(AV7Element.gxTpr_Wwpformelementmetadata, null);
                  AV15VisibleCondition = AV25WWP_DF_StepMetadata.gxTpr_Visiblecondition;
                  AV14Validations = AV25WWP_DF_StepMetadata.gxTpr_Validations;
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV15VisibleCondition.gxTpr_Expression))) || ( AV14Validations.Count > 0 ) )
               {
                  GXt_int4 = AV36CurrentElementMultipleDataId;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getparentmultipledataid(context ).execute( ref  AV27WWPForm,  AV7Element.gxTpr_Wwpformelementid, out  GXt_int4) ;
                  AV36CurrentElementMultipleDataId = GXt_int4;
                  if ( (0==AV36CurrentElementMultipleDataId) )
                  {
                     AV35AllPossibleReferenceIds = AV33AllReferenceIds;
                  }
                  else
                  {
                     GXt_char3 = AV34VarCharAux;
                     new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getavailablevariables(context ).execute(  AV13SessionId,  false,  AV7Element.gxTpr_Wwpformelementid,  9999,  "", out  GXt_char3) ;
                     AV34VarCharAux = GXt_char3;
                     AV35AllPossibleReferenceIds = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "Factory21");
                     AV35AllPossibleReferenceIds.FromJSonString(StringUtil.Lower( AV34VarCharAux), null);
                  }
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV15VisibleCondition.gxTpr_Expression))) )
                  {
                     new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getconditionmentionsandvalidate(context ).execute(  AV27WWPForm,  AV15VisibleCondition.gxTpr_Expression,  false,  false,  AV7Element.gxTpr_Wwpformelementreferenceid,  AV7Element.gxTpr_Wwpformelementdatatype, ref  AV35AllPossibleReferenceIds, out  AV40VarCharList, out  AV37ConditionError) ;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ConditionError)) )
                     {
                        AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
                        AV41WWPFormElementType = AV7Element.gxTpr_Wwpformelementtype;
                        GXt_char3 = AV38ElementTitle;
                        new WorkWithPlus.workwithplus_dynamicforms.wwp_df_elementtypeenumerationdescription(context ).execute(  AV41WWPFormElementType, out  GXt_char3) ;
                        GXt_char2 = AV38ElementTitle;
                        new WorkWithPlus.workwithplus_dynamicforms.wwp_df_elementtypeenumerationdescription(context ).execute(  AV41WWPFormElementType, out  GXt_char2) ;
                        AV38ElementTitle = (String.IsNullOrEmpty(StringUtil.RTrim( AV7Element.gxTpr_Wwpformelementtitle)) ? GXt_char2 : AV7Element.gxTpr_Wwpformelementtitle);
                        AV10Message.gxTpr_Description = StringUtil.Format( "A condi��o vis�vel de %1 n�o � v�lida ( %2)", AV38ElementTitle, AV37ConditionError, "", "", "", "", "", "", "");
                        AV11Messages.Add(AV10Message, 0);
                     }
                  }
                  if ( ( AV11Messages.Count == 0 ) && ( AV14Validations.Count > 0 ) )
                  {
                     AV53GXV5 = 1;
                     while ( AV53GXV5 <= AV14Validations.Count )
                     {
                        AV39Validation = ((WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation)AV14Validations.Item(AV53GXV5));
                        new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getconditionmentionsandvalidate(context ).execute(  AV27WWPForm,  AV39Validation.gxTpr_Condition.gxTpr_Expression,  true,  false,  AV7Element.gxTpr_Wwpformelementreferenceid,  AV7Element.gxTpr_Wwpformelementdatatype, ref  AV35AllPossibleReferenceIds, out  AV40VarCharList, out  AV37ConditionError) ;
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ConditionError)) )
                        {
                           AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
                           AV41WWPFormElementType = AV7Element.gxTpr_Wwpformelementtype;
                           GXt_char3 = AV38ElementTitle;
                           new WorkWithPlus.workwithplus_dynamicforms.wwp_df_elementtypeenumerationdescription(context ).execute(  AV41WWPFormElementType, out  GXt_char3) ;
                           GXt_char2 = AV38ElementTitle;
                           new WorkWithPlus.workwithplus_dynamicforms.wwp_df_elementtypeenumerationdescription(context ).execute(  AV41WWPFormElementType, out  GXt_char2) ;
                           AV38ElementTitle = (String.IsNullOrEmpty(StringUtil.RTrim( AV7Element.gxTpr_Wwpformelementtitle)) ? GXt_char2 : AV7Element.gxTpr_Wwpformelementtitle);
                           AV10Message.gxTpr_Description = StringUtil.Format( "Alguma valida��o de %1 n�o � v�lida ( %2)", AV38ElementTitle, AV37ConditionError, "", "", "", "", "", "", "");
                           AV11Messages.Add(AV10Message, 0);
                        }
                        AV53GXV5 = (int)(AV53GXV5+1);
                     }
                  }
               }
            }
            AV52GXV4 = (int)(AV52GXV4+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E190Z2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_42_0Z2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablesettings_modal_Internalname, tblTablesettings_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucSettings_modal.SetProperty("Width", Settings_modal_Width);
            ucSettings_modal.SetProperty("Title", Settings_modal_Title);
            ucSettings_modal.SetProperty("ConfirmType", Settings_modal_Confirmtype);
            ucSettings_modal.SetProperty("BodyType", Settings_modal_Bodytype);
            ucSettings_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Settings_modal_Internalname, "SETTINGS_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"SETTINGS_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_42_0Z2e( true) ;
         }
         else
         {
            wb_table1_42_0Z2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV31WWPFormId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV31WWPFormId", StringUtil.LTrimStr( (decimal)(AV31WWPFormId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31WWPFormId), "ZZZ9"), context));
         AV26WWPDynamicFormMode = (string)getParm(obj,1);
         AssignAttri("", false, "AV26WWPDynamicFormMode", AV26WWPDynamicFormMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPDYNAMICFORMMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26WWPDynamicFormMode, "")), context));
         AV6DefaultFormType = (string)getParm(obj,2);
         AssignAttri("", false, "AV6DefaultFormType", AV6DefaultFormType);
         GxWebStd.gx_hidden_field( context, "gxhash_vDEFAULTFORMTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DefaultFormType, "")), context));
         AV43WWPFormType = Convert.ToInt16(getParm(obj,3));
         AssignAttri("", false, "AV43WWPFormType", StringUtil.Str( (decimal)(AV43WWPFormType), 1, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV43WWPFormType), "9"), context));
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
         PA0Z2( ) ;
         WS0Z2( ) ;
         WE0Z2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwwp_dynamicformfs_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwwp_dynamicformfs_wc_Component) != 0 )
            {
               WebComp_Wcwwp_dynamicformfs_wc.componentthemes();
            }
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019231497", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_createdynamicform.js", "?202561019231499", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicsectiontoupdate.Name = "vDYNAMICSECTIONTOUPDATE";
         cmbavDynamicsectiontoupdate.WebTags = "";
         if ( cmbavDynamicsectiontoupdate.ItemCount > 0 )
         {
            AV42DynamicSectionToUpdate = (short)(Math.Round(NumberUtil.Val( cmbavDynamicsectiontoupdate.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV42DynamicSectionToUpdate), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV42DynamicSectionToUpdate", StringUtil.LTrimStr( (decimal)(AV42DynamicSectionToUpdate), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavDynamicsectiontoupdate_Internalname = "vDYNAMICSECTIONTOUPDATE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Dvpanel_unnamedtable1_Internalname = "DVPANEL_UNNAMEDTABLE1";
         divDvpanel_unnamedtable1_cell_Internalname = "DVPANEL_UNNAMEDTABLE1_CELL";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         bttBtnsettings_Internalname = "BTNSETTINGS";
         bttBtnrefreshgrid_Internalname = "BTNREFRESHGRID";
         divTablemain_Internalname = "TABLEMAIN";
         edtavSessionid_Internalname = "vSESSIONID";
         Settings_modal_Internalname = "SETTINGS_MODAL";
         tblTablesettings_modal_Internalname = "TABLESETTINGS_MODAL";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
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
         edtavSessionid_Jsonclick = "";
         edtavSessionid_Visible = 1;
         bttBtnsettings_Visible = 1;
         bttBtnenter_Caption = "Create";
         bttBtnenter_Visible = 1;
         cmbavDynamicsectiontoupdate_Jsonclick = "";
         cmbavDynamicsectiontoupdate.Enabled = 1;
         divDvpanel_unnamedtable1_cell_Class = "col-xs-12";
         divTablemain_Class = "TableMainDynamicForm";
         Settings_modal_Bodytype = "WebComponent";
         Settings_modal_Confirmtype = "";
         Settings_modal_Title = "Element settings";
         Settings_modal_Width = "800";
         Dvpanel_unnamedtable1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Iconposition = "Right";
         Dvpanel_unnamedtable1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Title = "";
         Dvpanel_unnamedtable1_Cls = "PanelNoHeader";
         Dvpanel_unnamedtable1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Dynamic form";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV12RefreshMasterTitle","fld":"vREFRESHMASTERTITLE","type":"boolean"},{"av":"AV27WWPForm","fld":"vWWPFORM","type":""},{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9","type":"int"},{"av":"AV5AddedStepIndex","fld":"vADDEDSTEPINDEX","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicsectiontoupdate"},{"av":"AV42DynamicSectionToUpdate","fld":"vDYNAMICSECTIONTOUPDATE","pic":"ZZZ9","type":"int"},{"av":"AV26WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true,"type":"char"},{"av":"AV43WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true,"type":"int"},{"av":"AV31WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV6DefaultFormType","fld":"vDEFAULTFORMTYPE","hsh":true,"type":"svchar"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"FORM","prop":"Caption"},{"av":"AV12RefreshMasterTitle","fld":"vREFRESHMASTERTITLE","type":"boolean"},{"av":"AV5AddedStepIndex","fld":"vADDEDSTEPINDEX","pic":"ZZZ9","type":"int"},{"ctrl":"WCWWP_DYNAMICFORMFS_WC"}]}""");
         setEventMetadata("'DOSETTINGS'","""{"handler":"E110Z1","iparms":[]}""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT","""{"handler":"E130Z2","iparms":[{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("'DOREFRESHGRID'","""{"handler":"E150Z2","iparms":[{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("'DOREFRESHGRID'",""","oparms":[{"av":"AV27WWPForm","fld":"vWWPFORM","type":""},{"av":"AV12RefreshMasterTitle","fld":"vREFRESHMASTERTITLE","type":"boolean"},{"av":"AV5AddedStepIndex","fld":"vADDEDSTEPINDEX","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("ENTER","""{"handler":"E170Z2","iparms":[{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9","type":"int"},{"av":"AV26WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true,"type":"char"},{"av":"AV7Element","fld":"vELEMENT","type":""},{"av":"A94WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","type":"int"},{"av":"AV32WWPFormVersionNumber","fld":"vWWPFORMVERSIONNUMBER","pic":"ZZZ9","type":"int"},{"av":"A95WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","type":"int"},{"av":"AV31WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A122WWPFormInstantiated","fld":"WWPFORMINSTANTIATED","type":"boolean"},{"av":"A119WWPFormDate","fld":"WWPFORMDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV27WWPForm","fld":"vWWPFORM","type":""},{"av":"AV11Messages","fld":"vMESSAGES","type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11Messages","fld":"vMESSAGES","type":""},{"av":"AV27WWPForm","fld":"vWWPFORM","type":""},{"av":"AV32WWPFormVersionNumber","fld":"vWWPFORMVERSIONNUMBER","pic":"ZZZ9","type":"int"},{"av":"AV7Element","fld":"vELEMENT","type":""}]}""");
         setEventMetadata("VDYNAMICSECTIONTOUPDATE.CLICK","""{"handler":"E180Z2","iparms":[{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9","type":"int"},{"av":"AV26WWPDynamicFormMode","fld":"vWWPDYNAMICFORMMODE","hsh":true,"type":"char"},{"av":"cmbavDynamicsectiontoupdate"},{"av":"AV42DynamicSectionToUpdate","fld":"vDYNAMICSECTIONTOUPDATE","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("VDYNAMICSECTIONTOUPDATE.CLICK",""","oparms":[{"av":"AV27WWPForm","fld":"vWWPFORM","type":""},{"ctrl":"WCWWP_DYNAMICFORMFS_WC"}]}""");
         setEventMetadata("SETTINGS_MODAL.CLOSE","""{"handler":"E120Z2","iparms":[{"av":"Settings_modal_Result","ctrl":"SETTINGS_MODAL","prop":"Result"},{"av":"AV13SessionId","fld":"vSESSIONID","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("SETTINGS_MODAL.CLOSE",""","oparms":[{"av":"AV27WWPForm","fld":"vWWPFORM","type":""},{"av":"AV12RefreshMasterTitle","fld":"vREFRESHMASTERTITLE","type":"boolean"}]}""");
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
         wcpOAV26WWPDynamicFormMode = "";
         wcpOAV6DefaultFormType = "";
         AV27WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         Settings_modal_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV7Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         A119WWPFormDate = (DateTime)(DateTime.MinValue);
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_unnamedtable1 = new GXUserControl();
         TempTags = "";
         WebComp_Wcwwp_dynamicformfs_wc_Component = "";
         OldWcwwp_dynamicformfs_wc = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         bttBtnsettings_Jsonclick = "";
         bttBtnrefreshgrid_Jsonclick = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV9HttpRequest = new GxHttpRequest( context);
         H000Z2_A94WWPFormId = new short[1] ;
         H000Z2_A95WWPFormVersionNumber = new short[1] ;
         AV44WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV16WebSession = context.GetSession();
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV38ElementTitle = "";
         H000Z3_A95WWPFormVersionNumber = new short[1] ;
         H000Z3_A94WWPFormId = new short[1] ;
         H000Z4_A94WWPFormId = new short[1] ;
         H000Z4_A122WWPFormInstantiated = new bool[] {false} ;
         H000Z4_A119WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         H000Z4_A95WWPFormVersionNumber = new short[1] ;
         AV30WWPFormDate = (DateTime)(DateTime.MinValue);
         AV29NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         GXt_SdtWWP_Form1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV34VarCharAux = "";
         AV33AllReferenceIds = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "Factory21");
         AV15VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         AV14Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Factory21");
         AV17WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
         AV18WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV24WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
         AV19WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
         AV21WWP_DF_ImageMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata(context);
         AV20WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
         AV23WWP_DF_MultipleMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
         AV22WWP_DF_LabelMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata(context);
         AV25WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
         AV35AllPossibleReferenceIds = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "Factory21");
         AV40VarCharList = new GxSimpleCollection<string>();
         AV37ConditionError = "";
         AV39Validation = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation(context);
         GXt_char3 = "";
         GXt_char2 = "";
         sStyleString = "";
         ucSettings_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_createdynamicform__default(),
            new Object[][] {
                new Object[] {
               H000Z2_A94WWPFormId, H000Z2_A95WWPFormVersionNumber
               }
               , new Object[] {
               H000Z3_A95WWPFormVersionNumber, H000Z3_A94WWPFormId
               }
               , new Object[] {
               H000Z4_A94WWPFormId, H000Z4_A122WWPFormInstantiated, H000Z4_A119WWPFormDate, H000Z4_A95WWPFormVersionNumber
               }
            }
         );
         WebComp_Wcwwp_dynamicformfs_wc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV31WWPFormId ;
      private short AV43WWPFormType ;
      private short wcpOAV31WWPFormId ;
      private short wcpOAV43WWPFormType ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short AV5AddedStepIndex ;
      private short A94WWPFormId ;
      private short AV32WWPFormVersionNumber ;
      private short A95WWPFormVersionNumber ;
      private short wbEnd ;
      private short wbStart ;
      private short AV42DynamicSectionToUpdate ;
      private short AV13SessionId ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV45WWPFormElementId ;
      private short AV41WWPFormElementType ;
      private short AV36CurrentElementMultipleDataId ;
      private short GXt_int4 ;
      private short nGXWrapped ;
      private int bttBtnenter_Visible ;
      private int bttBtnsettings_Visible ;
      private int edtavSessionid_Visible ;
      private int AV47GXV1 ;
      private int AV50GXV2 ;
      private int AV51GXV3 ;
      private int AV52GXV4 ;
      private int AV53GXV5 ;
      private int idxLst ;
      private string AV26WWPDynamicFormMode ;
      private string wcpOAV26WWPDynamicFormMode ;
      private string Settings_modal_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_unnamedtable1_Width ;
      private string Dvpanel_unnamedtable1_Cls ;
      private string Dvpanel_unnamedtable1_Title ;
      private string Dvpanel_unnamedtable1_Iconposition ;
      private string Settings_modal_Width ;
      private string Settings_modal_Title ;
      private string Settings_modal_Confirmtype ;
      private string Settings_modal_Bodytype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablemain_Class ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divDvpanel_unnamedtable1_cell_Internalname ;
      private string divDvpanel_unnamedtable1_cell_Class ;
      private string Dvpanel_unnamedtable1_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string cmbavDynamicsectiontoupdate_Internalname ;
      private string TempTags ;
      private string cmbavDynamicsectiontoupdate_Jsonclick ;
      private string WebComp_Wcwwp_dynamicformfs_wc_Component ;
      private string OldWcwwp_dynamicformfs_wc ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string bttBtnsettings_Internalname ;
      private string bttBtnsettings_Jsonclick ;
      private string bttBtnrefreshgrid_Internalname ;
      private string bttBtnrefreshgrid_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavSessionid_Internalname ;
      private string edtavSessionid_Jsonclick ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string sStyleString ;
      private string tblTablesettings_modal_Internalname ;
      private string Settings_modal_Internalname ;
      private DateTime A119WWPFormDate ;
      private DateTime AV30WWPFormDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12RefreshMasterTitle ;
      private bool A122WWPFormInstantiated ;
      private bool Dvpanel_unnamedtable1_Autowidth ;
      private bool Dvpanel_unnamedtable1_Autoheight ;
      private bool Dvpanel_unnamedtable1_Collapsible ;
      private bool Dvpanel_unnamedtable1_Collapsed ;
      private bool Dvpanel_unnamedtable1_Showcollapseicon ;
      private bool Dvpanel_unnamedtable1_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool bDynCreated_Wcwwp_dynamicformfs_wc ;
      private bool AV28FormWasInstantiated ;
      private bool AV8HasDeletedElements ;
      private string AV6DefaultFormType ;
      private string wcpOAV6DefaultFormType ;
      private string AV38ElementTitle ;
      private string AV34VarCharAux ;
      private string AV37ConditionError ;
      private IGxSession AV16WebSession ;
      private GXWebComponent WebComp_Wcwwp_dynamicformfs_wc ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDvpanel_unnamedtable1 ;
      private GXUserControl ucSettings_modal ;
      private GxHttpRequest AV9HttpRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicsectiontoupdate ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV27WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV7Element ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private IDataStoreProvider pr_default ;
      private short[] H000Z2_A94WWPFormId ;
      private short[] H000Z2_A95WWPFormVersionNumber ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV44WWPFormElement ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
      private short[] H000Z3_A95WWPFormVersionNumber ;
      private short[] H000Z3_A94WWPFormId ;
      private short[] H000Z4_A94WWPFormId ;
      private bool[] H000Z4_A122WWPFormInstantiated ;
      private DateTime[] H000Z4_A119WWPFormDate ;
      private short[] H000Z4_A95WWPFormVersionNumber ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV29NewWWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem> AV33AllReferenceIds ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV15VisibleCondition ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV14Validations ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata AV17WWP_DF_BooleanMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV18WWP_DF_CharMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata AV24WWP_DF_NumericMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata AV19WWP_DF_DateMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata AV21WWP_DF_ImageMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata AV20WWP_DF_GroupMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV23WWP_DF_MultipleMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata AV22WWP_DF_LabelMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata AV25WWP_DF_StepMetadata ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem> AV35AllPossibleReferenceIds ;
      private GxSimpleCollection<string> AV40VarCharList ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation AV39Validation ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_createdynamicform__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000Z2;
          prmH000Z2 = new Object[] {
          new ParDef("AV31WWPFormId",GXType.Int16,4,0)
          };
          Object[] prmH000Z3;
          prmH000Z3 = new Object[] {
          };
          Object[] prmH000Z4;
          prmH000Z4 = new Object[] {
          new ParDef("AV31WWPFormId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000Z2", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :AV31WWPFormId ORDER BY WWPFormId, WWPFormVersionNumber DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Z2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H000Z3", "SELECT WWPFormVersionNumber, WWPFormId FROM WWP_Form ORDER BY WWPFormId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Z3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H000Z4", "SELECT WWPFormId, WWPFormInstantiated, WWPFormDate, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :AV31WWPFormId ORDER BY WWPFormId, WWPFormVersionNumber DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Z4,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
