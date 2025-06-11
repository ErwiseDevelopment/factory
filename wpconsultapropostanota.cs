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
   public class wpconsultapropostanota : GXDataArea
   {
      public wpconsultapropostanota( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpconsultapropostanota( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId )
      {
         this.AV17PropostaId = aP0_PropostaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavResponsavelcargo = new GXCombobox();
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
         PA9C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9C2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         GXEncryptionTmp = "wpconsultapropostanota"+UrlEncode(StringUtil.LTrimStr(AV17PropostaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpconsultapropostanota") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17PropostaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELLEFT_Width", StringUtil.RTrim( Dvpanel_tablepanelleft_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELLEFT_Autowidth", StringUtil.BoolToStr( Dvpanel_tablepanelleft_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELLEFT_Autoheight", StringUtil.BoolToStr( Dvpanel_tablepanelleft_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELLEFT_Cls", StringUtil.RTrim( Dvpanel_tablepanelleft_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELLEFT_Title", StringUtil.RTrim( Dvpanel_tablepanelleft_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELLEFT_Collapsible", StringUtil.BoolToStr( Dvpanel_tablepanelleft_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELLEFT_Collapsed", StringUtil.BoolToStr( Dvpanel_tablepanelleft_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELLEFT_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablepanelleft_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELLEFT_Iconposition", StringUtil.RTrim( Dvpanel_tablepanelleft_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELLEFT_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablepanelleft_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELCLIENTINFORMATION_Width", StringUtil.RTrim( Dvpanel_tablepanelclientinformation_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELCLIENTINFORMATION_Autowidth", StringUtil.BoolToStr( Dvpanel_tablepanelclientinformation_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELCLIENTINFORMATION_Autoheight", StringUtil.BoolToStr( Dvpanel_tablepanelclientinformation_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELCLIENTINFORMATION_Cls", StringUtil.RTrim( Dvpanel_tablepanelclientinformation_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELCLIENTINFORMATION_Title", StringUtil.RTrim( Dvpanel_tablepanelclientinformation_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELCLIENTINFORMATION_Collapsible", StringUtil.BoolToStr( Dvpanel_tablepanelclientinformation_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELCLIENTINFORMATION_Collapsed", StringUtil.BoolToStr( Dvpanel_tablepanelclientinformation_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELCLIENTINFORMATION_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablepanelclientinformation_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELCLIENTINFORMATION_Iconposition", StringUtil.RTrim( Dvpanel_tablepanelclientinformation_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELCLIENTINFORMATION_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablepanelclientinformation_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELPROPOSALSUMMARY_Width", StringUtil.RTrim( Dvpanel_tablepanelproposalsummary_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELPROPOSALSUMMARY_Autowidth", StringUtil.BoolToStr( Dvpanel_tablepanelproposalsummary_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELPROPOSALSUMMARY_Autoheight", StringUtil.BoolToStr( Dvpanel_tablepanelproposalsummary_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELPROPOSALSUMMARY_Cls", StringUtil.RTrim( Dvpanel_tablepanelproposalsummary_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELPROPOSALSUMMARY_Title", StringUtil.RTrim( Dvpanel_tablepanelproposalsummary_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELPROPOSALSUMMARY_Collapsible", StringUtil.BoolToStr( Dvpanel_tablepanelproposalsummary_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELPROPOSALSUMMARY_Collapsed", StringUtil.BoolToStr( Dvpanel_tablepanelproposalsummary_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELPROPOSALSUMMARY_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablepanelproposalsummary_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELPROPOSALSUMMARY_Iconposition", StringUtil.RTrim( Dvpanel_tablepanelproposalsummary_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELPROPOSALSUMMARY_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablepanelproposalsummary_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELHISTORY_Width", StringUtil.RTrim( Dvpanel_tablepanelhistory_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELHISTORY_Autowidth", StringUtil.BoolToStr( Dvpanel_tablepanelhistory_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELHISTORY_Autoheight", StringUtil.BoolToStr( Dvpanel_tablepanelhistory_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELHISTORY_Cls", StringUtil.RTrim( Dvpanel_tablepanelhistory_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELHISTORY_Title", StringUtil.RTrim( Dvpanel_tablepanelhistory_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELHISTORY_Collapsible", StringUtil.BoolToStr( Dvpanel_tablepanelhistory_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELHISTORY_Collapsed", StringUtil.BoolToStr( Dvpanel_tablepanelhistory_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELHISTORY_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablepanelhistory_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELHISTORY_Iconposition", StringUtil.RTrim( Dvpanel_tablepanelhistory_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEPANELHISTORY_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablepanelhistory_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNREPROVAR_Title", StringUtil.RTrim( Dvelop_confirmpanel_btnreprovar_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNREPROVAR_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_btnreprovar_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNREPROVAR_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnreprovar_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNREPROVAR_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnreprovar_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNREPROVAR_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnreprovar_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNREPROVAR_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_btnreprovar_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNREPROVAR_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_btnreprovar_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_Title", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNREPROVAR_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnreprovar_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNREPROVAR_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnreprovar_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_Result));
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
         if ( ! ( WebComp_Wcnotafiscalitemlistaitensww == null ) )
         {
            WebComp_Wcnotafiscalitemlistaitensww.componentjscripts();
         }
         if ( ! ( WebComp_Wcnotafiscalparcelamentoww == null ) )
         {
            WebComp_Wcnotafiscalparcelamentoww.componentjscripts();
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
            WE9C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9C2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpconsultapropostanota"+UrlEncode(StringUtil.LTrimStr(AV17PropostaId,9,0));
         return formatLink("wpconsultapropostanota") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpConsultaPropostaNota" ;
      }

      public override string GetPgmdesc( )
      {
         return "Proposta" ;
      }

      protected void WB9C0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablevoltar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextvoltar_Internalname, "<span class=\"fa-back-btn-chevron\"><i class=\"fas fa-chevron-left\"></i> Voltar para propostas</span>", "", "", lblTextvoltar_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableleft_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablepanelleft.SetProperty("Width", Dvpanel_tablepanelleft_Width);
            ucDvpanel_tablepanelleft.SetProperty("AutoWidth", Dvpanel_tablepanelleft_Autowidth);
            ucDvpanel_tablepanelleft.SetProperty("AutoHeight", Dvpanel_tablepanelleft_Autoheight);
            ucDvpanel_tablepanelleft.SetProperty("Cls", Dvpanel_tablepanelleft_Cls);
            ucDvpanel_tablepanelleft.SetProperty("Title", Dvpanel_tablepanelleft_Title);
            ucDvpanel_tablepanelleft.SetProperty("Collapsible", Dvpanel_tablepanelleft_Collapsible);
            ucDvpanel_tablepanelleft.SetProperty("Collapsed", Dvpanel_tablepanelleft_Collapsed);
            ucDvpanel_tablepanelleft.SetProperty("ShowCollapseIcon", Dvpanel_tablepanelleft_Showcollapseicon);
            ucDvpanel_tablepanelleft.SetProperty("IconPosition", Dvpanel_tablepanelleft_Iconposition);
            ucDvpanel_tablepanelleft.SetProperty("AutoScroll", Dvpanel_tablepanelleft_Autoscroll);
            ucDvpanel_tablepanelleft.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablepanelleft_Internalname, "DVPANEL_TABLEPANELLEFTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEPANELLEFTContainer"+"TablePanelLeft"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanelleft_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblstatusheader_Internalname, lblLblstatusheader_Caption, "", "", lblLblstatusheader_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPanelheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablepropostaprotocolo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockpropostaprotocolo_Internalname, "Protocolo", "", "", lblTextblockpropostaprotocolo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaprotocolo_Internalname, "Proposta Protocolo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaprotocolo_Internalname, AV15PropostaProtocolo, StringUtil.RTrim( context.localUtil.Format( AV15PropostaProtocolo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaprotocolo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPropostaprotocolo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableclienterazaosocial_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockclienterazaosocial_Internalname, "Cliente", "", "", lblTextblockclienterazaosocial_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Cliente Razao Social", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV16ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV16ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaPropostaNota.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divPanelheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablepropostacreatedat_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockpropostacreatedat_Internalname, "Data de Envio", "", "", lblTextblockpropostacreatedat_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostacreatedat_Internalname, "Proposta Created At", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavPropostacreatedat_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavPropostacreatedat_Internalname, context.localUtil.TToC( AV13PropostaCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV13PropostaCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostacreatedat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPropostacreatedat_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_bitmap( context, edtavPropostacreatedat_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavPropostacreatedat_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpConsultaPropostaNota.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablepropostasumitensnota_f_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockpropostasumitensnota_f_Internalname, "Valor Total", "", "", lblTextblockpropostasumitensnota_f_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostasumitensnota_f_Internalname, "Proposta Sum Itensnota_F", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostasumitensnota_f_Internalname, StringUtil.LTrim( StringUtil.NToC( AV14PropostaSumItensnota_F, 18, 2, ",", "")), StringUtil.LTrim( ((edtavPropostasumitensnota_f_Enabled!=0) ? context.localUtil.Format( AV14PropostaSumItensnota_F, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV14PropostaSumItensnota_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostasumitensnota_f_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPropostasumitensnota_f_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConsultaPropostaNota.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotaitens_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextitensincludes_Internalname, "<h4>Itens Incluídos</h4>", "", "", lblTextitensincludes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0073"+"", StringUtil.RTrim( WebComp_Wcnotafiscalitemlistaitensww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0073"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcnotafiscalitemlistaitensww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnotafiscalitemlistaitensww), StringUtil.Lower( WebComp_Wcnotafiscalitemlistaitensww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0073"+"");
                  }
                  WebComp_Wcnotafiscalitemlistaitensww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnotafiscalitemlistaitensww), StringUtil.Lower( WebComp_Wcnotafiscalitemlistaitensww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextdup_Internalname, "<h4>Duplicatas (Parcelas)</h4>", "", "", lblTextdup_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0079"+"", StringUtil.RTrim( WebComp_Wcnotafiscalparcelamentoww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0079"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcnotafiscalparcelamentoww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnotafiscalparcelamentoww), StringUtil.Lower( WebComp_Wcnotafiscalparcelamentoww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0079"+"");
                  }
                  WebComp_Wcnotafiscalparcelamentoww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnotafiscalparcelamentoww), StringUtil.Lower( WebComp_Wcnotafiscalparcelamentoww_Component)) != 0 )
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
            GxWebStd.gx_div_start( context, divTabledecisionnotes_Internalname, divTabledecisionnotes_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDecisao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDecisao_Internalname, "Decisão", " AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDecisao_Internalname, AV9Decisao, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", 0, 1, edtavDecisao_Enabled, 1, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "256", -1, 0, "", "Descreva sua decisão", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "app-btn-action app-btn-reject";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnreprovar_Internalname, "", "Reprovar", bttBtnbtnreprovar_Jsonclick, 7, "Reprovar", "", StyleString, ClassString, bttBtnbtnreprovar_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e119c1_client"+"'", TempTags, "", 2, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "app-btn-action app-btn-approve";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtnaprovar_Internalname, "", "Aprovar", bttBtnbtnaprovar_Jsonclick, 7, "Aprovar", "", StyleString, ClassString, bttBtnbtnaprovar_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e129c1_client"+"'", TempTags, "", 2, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontrato_Internalname, divTablecontrato_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "app-btn-action app-btn-approve";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtngerarcontrato_Internalname, "", "Gerar contrato", bttBtngerarcontrato_Jsonclick, 7, "Gerar contrato", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e139c1_client"+"'", TempTags, "", 2, "HLP_WpConsultaPropostaNota.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableright_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablepanelclientinformation.SetProperty("Width", Dvpanel_tablepanelclientinformation_Width);
            ucDvpanel_tablepanelclientinformation.SetProperty("AutoWidth", Dvpanel_tablepanelclientinformation_Autowidth);
            ucDvpanel_tablepanelclientinformation.SetProperty("AutoHeight", Dvpanel_tablepanelclientinformation_Autoheight);
            ucDvpanel_tablepanelclientinformation.SetProperty("Cls", Dvpanel_tablepanelclientinformation_Cls);
            ucDvpanel_tablepanelclientinformation.SetProperty("Title", Dvpanel_tablepanelclientinformation_Title);
            ucDvpanel_tablepanelclientinformation.SetProperty("Collapsible", Dvpanel_tablepanelclientinformation_Collapsible);
            ucDvpanel_tablepanelclientinformation.SetProperty("Collapsed", Dvpanel_tablepanelclientinformation_Collapsed);
            ucDvpanel_tablepanelclientinformation.SetProperty("ShowCollapseIcon", Dvpanel_tablepanelclientinformation_Showcollapseicon);
            ucDvpanel_tablepanelclientinformation.SetProperty("IconPosition", Dvpanel_tablepanelclientinformation_Iconposition);
            ucDvpanel_tablepanelclientinformation.SetProperty("AutoScroll", Dvpanel_tablepanelclientinformation_Autoscroll);
            ucDvpanel_tablepanelclientinformation.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablepanelclientinformation_Internalname, "DVPANEL_TABLEPANELCLIENTINFORMATIONContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEPANELCLIENTINFORMATIONContainer"+"TablePanelClientInformation"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanelclientinformation_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavInfoclienterazaosocial_Internalname, "Info Cliente Razao Social", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavInfoclienterazaosocial_Internalname, AV10InfoClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV10InfoClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavInfoclienterazaosocial_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavInfoclienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableconsultascorecliente_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclientescorebutton_Internalname, "<div style=\"margin-top:3px;margin-bottom:3px;display:flex; width:100%; align-items:center;justify-content: space-between;\"><button class=\"serasa-check-btn\">Consultar Score</button></div>", "", "", lblLblclientescorebutton_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpConsultaPropostaNota.htm");
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
            GxWebStd.gx_div_start( context, divTablescorecliente_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclientescore_Internalname, "<div style=\"margin-top:3px;margin-bottom:3px;display:flex; width:100%; align-items:center;justify-content: space-between;\"><strong>Score</strong> <span class=\"score-badge score-excelente\">850 - Excelente</span></div>", "", "", lblLblclientescore_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextlinerep_Internalname, "<div style=\"border-top: 1px solid gainsboro; width: 100%;\"></div>", "", "", lblTextlinerep_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "<span><strong>Representante</strong></span>", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresponsavelnome_Internalname, "<h4>Alessandro Piazza</h4>", "", "", lblLblresponsavelnome_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResponsavelcargo_Internalname, "Responsavel Cargo", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResponsavelcargo, cmbavResponsavelcargo_Internalname, StringUtil.RTrim( AV11ResponsavelCargo), 1, cmbavResponsavelcargo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavResponsavelcargo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "", true, 0, "HLP_WpConsultaPropostaNota.htm");
            cmbavResponsavelcargo.CurrentValue = StringUtil.RTrim( AV11ResponsavelCargo);
            AssignProp("", false, cmbavResponsavelcargo_Internalname, "Values", (string)(cmbavResponsavelcargo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelemail_Internalname, "Responsavel Email", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelemail_Internalname, AV12ResponsavelEmail, StringUtil.RTrim( context.localUtil.Format( AV12ResponsavelEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,140);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResponsavelemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
            ClassString = "profile-button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnverperfilcliente_Internalname, "", "Ver Perfil do Cliente", bttBtnverperfilcliente_Jsonclick, 7, "Ver Perfil do Cliente", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e149c1_client"+"'", TempTags, "", 2, "HLP_WpConsultaPropostaNota.htm");
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
            /* User Defined Control */
            ucDvpanel_tablepanelproposalsummary.SetProperty("Width", Dvpanel_tablepanelproposalsummary_Width);
            ucDvpanel_tablepanelproposalsummary.SetProperty("AutoWidth", Dvpanel_tablepanelproposalsummary_Autowidth);
            ucDvpanel_tablepanelproposalsummary.SetProperty("AutoHeight", Dvpanel_tablepanelproposalsummary_Autoheight);
            ucDvpanel_tablepanelproposalsummary.SetProperty("Cls", Dvpanel_tablepanelproposalsummary_Cls);
            ucDvpanel_tablepanelproposalsummary.SetProperty("Title", Dvpanel_tablepanelproposalsummary_Title);
            ucDvpanel_tablepanelproposalsummary.SetProperty("Collapsible", Dvpanel_tablepanelproposalsummary_Collapsible);
            ucDvpanel_tablepanelproposalsummary.SetProperty("Collapsed", Dvpanel_tablepanelproposalsummary_Collapsed);
            ucDvpanel_tablepanelproposalsummary.SetProperty("ShowCollapseIcon", Dvpanel_tablepanelproposalsummary_Showcollapseicon);
            ucDvpanel_tablepanelproposalsummary.SetProperty("IconPosition", Dvpanel_tablepanelproposalsummary_Iconposition);
            ucDvpanel_tablepanelproposalsummary.SetProperty("AutoScroll", Dvpanel_tablepanelproposalsummary_Autoscroll);
            ucDvpanel_tablepanelproposalsummary.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablepanelproposalsummary_Internalname, "DVPANEL_TABLEPANELPROPOSALSUMMARYContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEPANELPROPOSALSUMMARYContainer"+"TablePanelProposalSummary"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanelproposalsummary_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavItensresumo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavItensresumo_Internalname, "Itens", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavItensresumo_Internalname, AV5ItensResumo, StringUtil.RTrim( context.localUtil.Format( AV5ItensResumo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,153);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavItensresumo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavItensresumo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNotasresumo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNotasresumo_Internalname, "Notas", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNotasresumo_Internalname, AV6NotasResumo, StringUtil.RTrim( context.localUtil.Format( AV6NotasResumo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,158);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNotasresumo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNotasresumo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavValorresumo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValorresumo_Internalname, "Valor Total", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValorresumo_Internalname, AV7ValorResumo, StringUtil.RTrim( context.localUtil.Format( AV7ValorResumo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,163);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValorresumo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavValorresumo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextline_Internalname, "<div style=\"border-top: 1px solid gainsboro; width: 100%;\"></div>", "", "", lblTextline_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpConsultaPropostaNota.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblstatussummary_Internalname, lblLblstatussummary_Caption, "", "", lblLblstatussummary_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpConsultaPropostaNota.htm");
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
            /* User Defined Control */
            ucDvpanel_tablepanelhistory.SetProperty("Width", Dvpanel_tablepanelhistory_Width);
            ucDvpanel_tablepanelhistory.SetProperty("AutoWidth", Dvpanel_tablepanelhistory_Autowidth);
            ucDvpanel_tablepanelhistory.SetProperty("AutoHeight", Dvpanel_tablepanelhistory_Autoheight);
            ucDvpanel_tablepanelhistory.SetProperty("Cls", Dvpanel_tablepanelhistory_Cls);
            ucDvpanel_tablepanelhistory.SetProperty("Title", Dvpanel_tablepanelhistory_Title);
            ucDvpanel_tablepanelhistory.SetProperty("Collapsible", Dvpanel_tablepanelhistory_Collapsible);
            ucDvpanel_tablepanelhistory.SetProperty("Collapsed", Dvpanel_tablepanelhistory_Collapsed);
            ucDvpanel_tablepanelhistory.SetProperty("ShowCollapseIcon", Dvpanel_tablepanelhistory_Showcollapseicon);
            ucDvpanel_tablepanelhistory.SetProperty("IconPosition", Dvpanel_tablepanelhistory_Iconposition);
            ucDvpanel_tablepanelhistory.SetProperty("AutoScroll", Dvpanel_tablepanelhistory_Autoscroll);
            ucDvpanel_tablepanelhistory.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablepanelhistory_Internalname, "DVPANEL_TABLEPANELHISTORYContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEPANELHISTORYContainer"+"TablePanelHistory"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanelhistory_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            wb_table1_178_9C2( true) ;
         }
         else
         {
            wb_table1_178_9C2( false) ;
         }
         return  ;
      }

      protected void wb_table1_178_9C2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_183_9C2( true) ;
         }
         else
         {
            wb_table2_183_9C2( false) ;
         }
         return  ;
      }

      protected void wb_table2_183_9C2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START9C2( )
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
         Form.Meta.addItem("description", "Proposta", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9C0( ) ;
      }

      protected void WS9C2( )
      {
         START9C2( ) ;
         EVT9C2( ) ;
      }

      protected void EVT9C2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNREPROVAR.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_btnreprovar.Close */
                              E159C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNAPROVAR.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_btnaprovar.Close */
                              E169C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E179C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TABLEVOLTAR.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Tablevoltar.Click */
                              E189C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E199C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
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
                        if ( nCmpId == 73 )
                        {
                           OldWcnotafiscalitemlistaitensww = cgiGet( "W0073");
                           if ( ( StringUtil.Len( OldWcnotafiscalitemlistaitensww) == 0 ) || ( StringUtil.StrCmp(OldWcnotafiscalitemlistaitensww, WebComp_Wcnotafiscalitemlistaitensww_Component) != 0 ) )
                           {
                              WebComp_Wcnotafiscalitemlistaitensww = getWebComponent(GetType(), "GeneXus.Programs", OldWcnotafiscalitemlistaitensww, new Object[] {context} );
                              WebComp_Wcnotafiscalitemlistaitensww.ComponentInit();
                              WebComp_Wcnotafiscalitemlistaitensww.Name = "OldWcnotafiscalitemlistaitensww";
                              WebComp_Wcnotafiscalitemlistaitensww_Component = OldWcnotafiscalitemlistaitensww;
                           }
                           if ( StringUtil.Len( WebComp_Wcnotafiscalitemlistaitensww_Component) != 0 )
                           {
                              WebComp_Wcnotafiscalitemlistaitensww.componentprocess("W0073", "", sEvt);
                           }
                           WebComp_Wcnotafiscalitemlistaitensww_Component = OldWcnotafiscalitemlistaitensww;
                        }
                        else if ( nCmpId == 79 )
                        {
                           OldWcnotafiscalparcelamentoww = cgiGet( "W0079");
                           if ( ( StringUtil.Len( OldWcnotafiscalparcelamentoww) == 0 ) || ( StringUtil.StrCmp(OldWcnotafiscalparcelamentoww, WebComp_Wcnotafiscalparcelamentoww_Component) != 0 ) )
                           {
                              WebComp_Wcnotafiscalparcelamentoww = getWebComponent(GetType(), "GeneXus.Programs", OldWcnotafiscalparcelamentoww, new Object[] {context} );
                              WebComp_Wcnotafiscalparcelamentoww.ComponentInit();
                              WebComp_Wcnotafiscalparcelamentoww.Name = "OldWcnotafiscalparcelamentoww";
                              WebComp_Wcnotafiscalparcelamentoww_Component = OldWcnotafiscalparcelamentoww;
                           }
                           if ( StringUtil.Len( WebComp_Wcnotafiscalparcelamentoww_Component) != 0 )
                           {
                              WebComp_Wcnotafiscalparcelamentoww.componentprocess("W0079", "", sEvt);
                           }
                           WebComp_Wcnotafiscalparcelamentoww_Component = OldWcnotafiscalparcelamentoww;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE9C2( )
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

      protected void PA9C2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpconsultapropostanota")), "wpconsultapropostanota") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpconsultapropostanota")))) ;
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
                     AV17PropostaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV17PropostaId", StringUtil.LTrimStr( (decimal)(AV17PropostaId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17PropostaId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavPropostaprotocolo_Internalname;
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
         if ( cmbavResponsavelcargo.ItemCount > 0 )
         {
            AV11ResponsavelCargo = cmbavResponsavelcargo.getValidValue(AV11ResponsavelCargo);
            AssignAttri("", false, "AV11ResponsavelCargo", AV11ResponsavelCargo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResponsavelcargo.CurrentValue = StringUtil.RTrim( AV11ResponsavelCargo);
            AssignProp("", false, cmbavResponsavelcargo_Internalname, "Values", cmbavResponsavelcargo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavPropostaprotocolo_Enabled = 0;
         AssignProp("", false, edtavPropostaprotocolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostaprotocolo_Enabled), 5, 0), true);
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavPropostacreatedat_Enabled = 0;
         AssignProp("", false, edtavPropostacreatedat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostacreatedat_Enabled), 5, 0), true);
         edtavPropostasumitensnota_f_Enabled = 0;
         AssignProp("", false, edtavPropostasumitensnota_f_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostasumitensnota_f_Enabled), 5, 0), true);
         edtavInfoclienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavInfoclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavInfoclienterazaosocial_Enabled), 5, 0), true);
         cmbavResponsavelcargo.Enabled = 0;
         AssignProp("", false, cmbavResponsavelcargo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavResponsavelcargo.Enabled), 5, 0), true);
         edtavResponsavelemail_Enabled = 0;
         AssignProp("", false, edtavResponsavelemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelemail_Enabled), 5, 0), true);
         edtavItensresumo_Enabled = 0;
         AssignProp("", false, edtavItensresumo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavItensresumo_Enabled), 5, 0), true);
         edtavNotasresumo_Enabled = 0;
         AssignProp("", false, edtavNotasresumo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotasresumo_Enabled), 5, 0), true);
         edtavValorresumo_Enabled = 0;
         AssignProp("", false, edtavValorresumo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValorresumo_Enabled), 5, 0), true);
      }

      protected void RF9C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcnotafiscalitemlistaitensww_Component) != 0 )
               {
                  WebComp_Wcnotafiscalitemlistaitensww.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcnotafiscalparcelamentoww_Component) != 0 )
               {
                  WebComp_Wcnotafiscalparcelamentoww.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E199C2 ();
            WB9C0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes9C2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavPropostaprotocolo_Enabled = 0;
         AssignProp("", false, edtavPropostaprotocolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostaprotocolo_Enabled), 5, 0), true);
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavPropostacreatedat_Enabled = 0;
         AssignProp("", false, edtavPropostacreatedat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostacreatedat_Enabled), 5, 0), true);
         edtavPropostasumitensnota_f_Enabled = 0;
         AssignProp("", false, edtavPropostasumitensnota_f_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostasumitensnota_f_Enabled), 5, 0), true);
         edtavInfoclienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavInfoclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavInfoclienterazaosocial_Enabled), 5, 0), true);
         cmbavResponsavelcargo.Enabled = 0;
         AssignProp("", false, cmbavResponsavelcargo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavResponsavelcargo.Enabled), 5, 0), true);
         edtavResponsavelemail_Enabled = 0;
         AssignProp("", false, edtavResponsavelemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelemail_Enabled), 5, 0), true);
         edtavItensresumo_Enabled = 0;
         AssignProp("", false, edtavItensresumo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavItensresumo_Enabled), 5, 0), true);
         edtavNotasresumo_Enabled = 0;
         AssignProp("", false, edtavNotasresumo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotasresumo_Enabled), 5, 0), true);
         edtavValorresumo_Enabled = 0;
         AssignProp("", false, edtavValorresumo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavValorresumo_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E179C2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_tablepanelleft_Width = cgiGet( "DVPANEL_TABLEPANELLEFT_Width");
            Dvpanel_tablepanelleft_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELLEFT_Autowidth"));
            Dvpanel_tablepanelleft_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELLEFT_Autoheight"));
            Dvpanel_tablepanelleft_Cls = cgiGet( "DVPANEL_TABLEPANELLEFT_Cls");
            Dvpanel_tablepanelleft_Title = cgiGet( "DVPANEL_TABLEPANELLEFT_Title");
            Dvpanel_tablepanelleft_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELLEFT_Collapsible"));
            Dvpanel_tablepanelleft_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELLEFT_Collapsed"));
            Dvpanel_tablepanelleft_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELLEFT_Showcollapseicon"));
            Dvpanel_tablepanelleft_Iconposition = cgiGet( "DVPANEL_TABLEPANELLEFT_Iconposition");
            Dvpanel_tablepanelleft_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELLEFT_Autoscroll"));
            Dvpanel_tablepanelclientinformation_Width = cgiGet( "DVPANEL_TABLEPANELCLIENTINFORMATION_Width");
            Dvpanel_tablepanelclientinformation_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELCLIENTINFORMATION_Autowidth"));
            Dvpanel_tablepanelclientinformation_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELCLIENTINFORMATION_Autoheight"));
            Dvpanel_tablepanelclientinformation_Cls = cgiGet( "DVPANEL_TABLEPANELCLIENTINFORMATION_Cls");
            Dvpanel_tablepanelclientinformation_Title = cgiGet( "DVPANEL_TABLEPANELCLIENTINFORMATION_Title");
            Dvpanel_tablepanelclientinformation_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELCLIENTINFORMATION_Collapsible"));
            Dvpanel_tablepanelclientinformation_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELCLIENTINFORMATION_Collapsed"));
            Dvpanel_tablepanelclientinformation_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELCLIENTINFORMATION_Showcollapseicon"));
            Dvpanel_tablepanelclientinformation_Iconposition = cgiGet( "DVPANEL_TABLEPANELCLIENTINFORMATION_Iconposition");
            Dvpanel_tablepanelclientinformation_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELCLIENTINFORMATION_Autoscroll"));
            Dvpanel_tablepanelproposalsummary_Width = cgiGet( "DVPANEL_TABLEPANELPROPOSALSUMMARY_Width");
            Dvpanel_tablepanelproposalsummary_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELPROPOSALSUMMARY_Autowidth"));
            Dvpanel_tablepanelproposalsummary_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELPROPOSALSUMMARY_Autoheight"));
            Dvpanel_tablepanelproposalsummary_Cls = cgiGet( "DVPANEL_TABLEPANELPROPOSALSUMMARY_Cls");
            Dvpanel_tablepanelproposalsummary_Title = cgiGet( "DVPANEL_TABLEPANELPROPOSALSUMMARY_Title");
            Dvpanel_tablepanelproposalsummary_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELPROPOSALSUMMARY_Collapsible"));
            Dvpanel_tablepanelproposalsummary_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELPROPOSALSUMMARY_Collapsed"));
            Dvpanel_tablepanelproposalsummary_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELPROPOSALSUMMARY_Showcollapseicon"));
            Dvpanel_tablepanelproposalsummary_Iconposition = cgiGet( "DVPANEL_TABLEPANELPROPOSALSUMMARY_Iconposition");
            Dvpanel_tablepanelproposalsummary_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELPROPOSALSUMMARY_Autoscroll"));
            Dvpanel_tablepanelhistory_Width = cgiGet( "DVPANEL_TABLEPANELHISTORY_Width");
            Dvpanel_tablepanelhistory_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELHISTORY_Autowidth"));
            Dvpanel_tablepanelhistory_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELHISTORY_Autoheight"));
            Dvpanel_tablepanelhistory_Cls = cgiGet( "DVPANEL_TABLEPANELHISTORY_Cls");
            Dvpanel_tablepanelhistory_Title = cgiGet( "DVPANEL_TABLEPANELHISTORY_Title");
            Dvpanel_tablepanelhistory_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELHISTORY_Collapsible"));
            Dvpanel_tablepanelhistory_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELHISTORY_Collapsed"));
            Dvpanel_tablepanelhistory_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELHISTORY_Showcollapseicon"));
            Dvpanel_tablepanelhistory_Iconposition = cgiGet( "DVPANEL_TABLEPANELHISTORY_Iconposition");
            Dvpanel_tablepanelhistory_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEPANELHISTORY_Autoscroll"));
            Dvelop_confirmpanel_btnreprovar_Title = cgiGet( "DVELOP_CONFIRMPANEL_BTNREPROVAR_Title");
            Dvelop_confirmpanel_btnreprovar_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_BTNREPROVAR_Confirmationtext");
            Dvelop_confirmpanel_btnreprovar_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNREPROVAR_Yesbuttoncaption");
            Dvelop_confirmpanel_btnreprovar_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNREPROVAR_Nobuttoncaption");
            Dvelop_confirmpanel_btnreprovar_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNREPROVAR_Cancelbuttoncaption");
            Dvelop_confirmpanel_btnreprovar_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_BTNREPROVAR_Yesbuttonposition");
            Dvelop_confirmpanel_btnreprovar_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_BTNREPROVAR_Confirmtype");
            Dvelop_confirmpanel_btnaprovar_Title = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_Title");
            Dvelop_confirmpanel_btnaprovar_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_Confirmationtext");
            Dvelop_confirmpanel_btnaprovar_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_Yesbuttoncaption");
            Dvelop_confirmpanel_btnaprovar_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_Nobuttoncaption");
            Dvelop_confirmpanel_btnaprovar_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_Cancelbuttoncaption");
            Dvelop_confirmpanel_btnaprovar_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_Yesbuttonposition");
            Dvelop_confirmpanel_btnaprovar_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_Confirmtype");
            Dvelop_confirmpanel_btnreprovar_Result = cgiGet( "DVELOP_CONFIRMPANEL_BTNREPROVAR_Result");
            Dvelop_confirmpanel_btnaprovar_Result = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_Result");
            /* Read variables values. */
            AV15PropostaProtocolo = cgiGet( edtavPropostaprotocolo_Internalname);
            AssignAttri("", false, "AV15PropostaProtocolo", AV15PropostaProtocolo);
            AV16ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AssignAttri("", false, "AV16ClienteRazaoSocial", AV16ClienteRazaoSocial);
            if ( context.localUtil.VCDateTime( cgiGet( edtavPropostacreatedat_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Proposta Created At"}), 1, "vPROPOSTACREATEDAT");
               GX_FocusControl = edtavPropostacreatedat_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13PropostaCreatedAt = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV13PropostaCreatedAt", context.localUtil.TToC( AV13PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV13PropostaCreatedAt = context.localUtil.CToT( cgiGet( edtavPropostacreatedat_Internalname));
               AssignAttri("", false, "AV13PropostaCreatedAt", context.localUtil.TToC( AV13PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostasumitensnota_f_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostasumitensnota_f_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTASUMITENSNOTA_F");
               GX_FocusControl = edtavPropostasumitensnota_f_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14PropostaSumItensnota_F = 0;
               AssignAttri("", false, "AV14PropostaSumItensnota_F", StringUtil.LTrimStr( AV14PropostaSumItensnota_F, 18, 2));
            }
            else
            {
               AV14PropostaSumItensnota_F = context.localUtil.CToN( cgiGet( edtavPropostasumitensnota_f_Internalname), ",", ".");
               AssignAttri("", false, "AV14PropostaSumItensnota_F", StringUtil.LTrimStr( AV14PropostaSumItensnota_F, 18, 2));
            }
            AV9Decisao = cgiGet( edtavDecisao_Internalname);
            AssignAttri("", false, "AV9Decisao", AV9Decisao);
            AV10InfoClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavInfoclienterazaosocial_Internalname));
            AssignAttri("", false, "AV10InfoClienteRazaoSocial", AV10InfoClienteRazaoSocial);
            cmbavResponsavelcargo.CurrentValue = cgiGet( cmbavResponsavelcargo_Internalname);
            AV11ResponsavelCargo = cgiGet( cmbavResponsavelcargo_Internalname);
            AssignAttri("", false, "AV11ResponsavelCargo", AV11ResponsavelCargo);
            AV12ResponsavelEmail = cgiGet( edtavResponsavelemail_Internalname);
            AssignAttri("", false, "AV12ResponsavelEmail", AV12ResponsavelEmail);
            AV5ItensResumo = cgiGet( edtavItensresumo_Internalname);
            AssignAttri("", false, "AV5ItensResumo", AV5ItensResumo);
            AV6NotasResumo = cgiGet( edtavNotasresumo_Internalname);
            AssignAttri("", false, "AV6NotasResumo", AV6NotasResumo);
            AV7ValorResumo = cgiGet( edtavValorresumo_Internalname);
            AssignAttri("", false, "AV7ValorResumo", AV7ValorResumo);
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
         E179C2 ();
         if (returnInSub) return;
      }

      protected void E179C2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV22WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV22WWPContext = GXt_SdtWWPContext1;
         AV24Array_NotaFiscalId = (GxSimpleCollection<Guid>)(new GxSimpleCollection<Guid>());
         /* Using cursor H009C2 */
         pr_default.execute(0, new Object[] {AV17PropostaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A323PropostaId = H009C2_A323PropostaId[0];
            n323PropostaId = H009C2_n323PropostaId[0];
            A794NotaFiscalId = H009C2_A794NotaFiscalId[0];
            n794NotaFiscalId = H009C2_n794NotaFiscalId[0];
            AV24Array_NotaFiscalId.Add(A794NotaFiscalId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV25ParcelamentoJSON = AV24Array_NotaFiscalId.ToJSonString(false);
         if ( ! AV22WWPContext.gxTpr_Isaprover )
         {
            divTabledecisionnotes_Visible = 0;
            AssignProp("", false, divTabledecisionnotes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTabledecisionnotes_Visible), 5, 0), true);
         }
         /* Using cursor H009C4 */
         pr_default.execute(1, new Object[] {AV17PropostaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A323PropostaId = H009C4_A323PropostaId[0];
            n323PropostaId = H009C4_n323PropostaId[0];
            A853PropostaProtocolo = H009C4_A853PropostaProtocolo[0];
            n853PropostaProtocolo = H009C4_n853PropostaProtocolo[0];
            A850PropostaEmpresaClienteId = H009C4_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = H009C4_n850PropostaEmpresaClienteId[0];
            A327PropostaCreatedAt = H009C4_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = H009C4_n327PropostaCreatedAt[0];
            A329PropostaStatus = H009C4_A329PropostaStatus[0];
            n329PropostaStatus = H009C4_n329PropostaStatus[0];
            A887PropostaSumItensnota_F = H009C4_A887PropostaSumItensnota_F[0];
            n887PropostaSumItensnota_F = H009C4_n887PropostaSumItensnota_F[0];
            A887PropostaSumItensnota_F = H009C4_A887PropostaSumItensnota_F[0];
            n887PropostaSumItensnota_F = H009C4_n887PropostaSumItensnota_F[0];
            AV15PropostaProtocolo = A853PropostaProtocolo;
            AssignAttri("", false, "AV15PropostaProtocolo", AV15PropostaProtocolo);
            AV18PropostaEmpresaClienteId = A850PropostaEmpresaClienteId;
            AssignAttri("", false, "AV18PropostaEmpresaClienteId", StringUtil.LTrimStr( (decimal)(AV18PropostaEmpresaClienteId), 9, 0));
            AV13PropostaCreatedAt = A327PropostaCreatedAt;
            AssignAttri("", false, "AV13PropostaCreatedAt", context.localUtil.TToC( AV13PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            AV14PropostaSumItensnota_F = A887PropostaSumItensnota_F;
            AssignAttri("", false, "AV14PropostaSumItensnota_F", StringUtil.LTrimStr( AV14PropostaSumItensnota_F, 18, 2));
            GXt_char2 = "";
            new prpropostastatuselement(context ).execute(  A329PropostaStatus,  false, out  GXt_char2) ;
            lblLblstatusheader_Caption = GXt_char2;
            AssignProp("", false, lblLblstatusheader_Internalname, "Caption", lblLblstatusheader_Caption, true);
            GXt_char2 = "";
            new prpropostastatuselement(context ).execute(  A329PropostaStatus,  true, out  GXt_char2) ;
            lblLblstatussummary_Caption = GXt_char2;
            AssignProp("", false, lblLblstatussummary_Internalname, "Caption", lblLblstatussummary_Caption, true);
            AV26PropostaStatus = A329PropostaStatus;
            AssignAttri("", false, "AV26PropostaStatus", AV26PropostaStatus);
            /* Using cursor H009C5 */
            pr_default.execute(2, new Object[] {n323PropostaId, A323PropostaId, AV22WWPContext.gxTpr_Aprovadorid});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A375AprovadoresId = H009C5_A375AprovadoresId[0];
               n375AprovadoresId = H009C5_n375AprovadoresId[0];
               A338AprovacaoDecisao = H009C5_A338AprovacaoDecisao[0];
               n338AprovacaoDecisao = H009C5_n338AprovacaoDecisao[0];
               /* Execute user subroutine: 'DECIDIDOELEMENTOS' */
               S115 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
               AV9Decisao = A338AprovacaoDecisao;
               AssignAttri("", false, "AV9Decisao", AV9Decisao);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         /* Using cursor H009C6 */
         pr_default.execute(3, new Object[] {AV18PropostaEmpresaClienteId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A168ClienteId = H009C6_A168ClienteId[0];
            A170ClienteRazaoSocial = H009C6_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H009C6_n170ClienteRazaoSocial[0];
            A885ResponsavelCargo = H009C6_A885ResponsavelCargo[0];
            n885ResponsavelCargo = H009C6_n885ResponsavelCargo[0];
            A456ResponsavelEmail = H009C6_A456ResponsavelEmail[0];
            n456ResponsavelEmail = H009C6_n456ResponsavelEmail[0];
            AV16ClienteRazaoSocial = A170ClienteRazaoSocial;
            AssignAttri("", false, "AV16ClienteRazaoSocial", AV16ClienteRazaoSocial);
            AV10InfoClienteRazaoSocial = A170ClienteRazaoSocial;
            AssignAttri("", false, "AV10InfoClienteRazaoSocial", AV10InfoClienteRazaoSocial);
            AV11ResponsavelCargo = A885ResponsavelCargo;
            AssignAttri("", false, "AV11ResponsavelCargo", AV11ResponsavelCargo);
            AV12ResponsavelEmail = A456ResponsavelEmail;
            AssignAttri("", false, "AV12ResponsavelEmail", AV12ResponsavelEmail);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcnotafiscalitemlistaitensww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcnotafiscalitemlistaitensww_Component), StringUtil.Lower( "NotaFiscalItemListaItensWW")) != 0 )
         {
            WebComp_Wcnotafiscalitemlistaitensww = getWebComponent(GetType(), "GeneXus.Programs", "notafiscalitemlistaitensww", new Object[] {context} );
            WebComp_Wcnotafiscalitemlistaitensww.ComponentInit();
            WebComp_Wcnotafiscalitemlistaitensww.Name = "NotaFiscalItemListaItensWW";
            WebComp_Wcnotafiscalitemlistaitensww_Component = "NotaFiscalItemListaItensWW";
         }
         if ( StringUtil.Len( WebComp_Wcnotafiscalitemlistaitensww_Component) != 0 )
         {
            WebComp_Wcnotafiscalitemlistaitensww.setjustcreated();
            WebComp_Wcnotafiscalitemlistaitensww.componentprepare(new Object[] {(string)"W0073",(string)"",(int)AV17PropostaId});
            WebComp_Wcnotafiscalitemlistaitensww.componentbind(new Object[] {(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcnotafiscalparcelamentoww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcnotafiscalparcelamentoww_Component), StringUtil.Lower( "NotaFiscalParcelamentoWW")) != 0 )
         {
            WebComp_Wcnotafiscalparcelamentoww = getWebComponent(GetType(), "GeneXus.Programs", "notafiscalparcelamentoww", new Object[] {context} );
            WebComp_Wcnotafiscalparcelamentoww.ComponentInit();
            WebComp_Wcnotafiscalparcelamentoww.Name = "NotaFiscalParcelamentoWW";
            WebComp_Wcnotafiscalparcelamentoww_Component = "NotaFiscalParcelamentoWW";
         }
         if ( StringUtil.Len( WebComp_Wcnotafiscalparcelamentoww_Component) != 0 )
         {
            WebComp_Wcnotafiscalparcelamentoww.setjustcreated();
            WebComp_Wcnotafiscalparcelamentoww.componentprepare(new Object[] {(string)"W0079",(string)"",(string)AV25ParcelamentoJSON});
            WebComp_Wcnotafiscalparcelamentoww.componentbind(new Object[] {(string)""});
         }
      }

      protected void E159C2( )
      {
         /* Dvelop_confirmpanel_btnreprovar_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btnreprovar_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION BTNREPROVAR' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E169C2( )
      {
         /* Dvelop_confirmpanel_btnaprovar_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btnaprovar_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION BTNAPROVAR' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'DO ACTION BTNREPROVAR' Routine */
         returnInSub = false;
         AV21DmAprovacaoStatus = "REPROVADO";
         /* Execute user subroutine: 'DECISAO' */
         S152 ();
         if (returnInSub) return;
      }

      protected void S142( )
      {
         /* 'DO ACTION BTNAPROVAR' Routine */
         returnInSub = false;
         AV21DmAprovacaoStatus = "APROVADO";
         /* Execute user subroutine: 'DECISAO' */
         S152 ();
         if (returnInSub) return;
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divTabledecisionnotes_Visible = (((StringUtil.StrCmp(AV26PropostaStatus, "EM_ANALISE")==0)) ? 1 : 0);
         AssignProp("", false, divTabledecisionnotes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTabledecisionnotes_Visible), 5, 0), true);
         divTablecontrato_Visible = (((StringUtil.StrCmp(AV26PropostaStatus, "APROVADO")==0)) ? 1 : 0);
         AssignProp("", false, divTablecontrato_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontrato_Visible), 5, 0), true);
      }

      protected void E189C2( )
      {
         /* Tablevoltar_Click Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S152( )
      {
         /* 'DECISAO' Routine */
         returnInSub = false;
         new prdecisaocompratitulos(context ).execute(  AV17PropostaId,  AV9Decisao,  "APROVADO", out  AV20SdErro) ;
         if ( AV20SdErro.gxTpr_Internalcode == 0 )
         {
            GXt_char2 = AV20SdErro.gxTpr_Msg;
            new message(context ).gxep_sucesso( ref  GXt_char2) ;
            AV20SdErro.gxTpr_Msg = GXt_char2;
            /* Execute user subroutine: 'DECIDIDOELEMENTOS' */
            S115 ();
            if (returnInSub) return;
         }
         else
         {
            GXt_char3 = AV20SdErro.gxTpr_Msg;
            new message(context ).gxep_erro( ref  GXt_char3) ;
            AV20SdErro.gxTpr_Msg = GXt_char3;
         }
      }

      protected void S115( )
      {
         /* 'DECIDIDOELEMENTOS' Routine */
         returnInSub = false;
         bttBtnbtnaprovar_Visible = 0;
         AssignProp("", false, bttBtnbtnaprovar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnbtnaprovar_Visible), 5, 0), true);
         bttBtnbtnreprovar_Visible = 0;
         AssignProp("", false, bttBtnbtnreprovar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnbtnreprovar_Visible), 5, 0), true);
         edtavDecisao_Enabled = 0;
         AssignProp("", false, edtavDecisao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDecisao_Enabled), 5, 0), true);
      }

      protected void nextLoad( )
      {
      }

      protected void E199C2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_183_9C2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btnaprovar_Internalname, tblTabledvelop_confirmpanel_btnaprovar_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btnaprovar.SetProperty("Title", Dvelop_confirmpanel_btnaprovar_Title);
            ucDvelop_confirmpanel_btnaprovar.SetProperty("ConfirmationText", Dvelop_confirmpanel_btnaprovar_Confirmationtext);
            ucDvelop_confirmpanel_btnaprovar.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btnaprovar_Yesbuttoncaption);
            ucDvelop_confirmpanel_btnaprovar.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btnaprovar_Nobuttoncaption);
            ucDvelop_confirmpanel_btnaprovar.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btnaprovar_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btnaprovar.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btnaprovar_Yesbuttonposition);
            ucDvelop_confirmpanel_btnaprovar.SetProperty("ConfirmType", Dvelop_confirmpanel_btnaprovar_Confirmtype);
            ucDvelop_confirmpanel_btnaprovar.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btnaprovar_Internalname, "DVELOP_CONFIRMPANEL_BTNAPROVARContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_BTNAPROVARContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_183_9C2e( true) ;
         }
         else
         {
            wb_table2_183_9C2e( false) ;
         }
      }

      protected void wb_table1_178_9C2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btnreprovar_Internalname, tblTabledvelop_confirmpanel_btnreprovar_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btnreprovar.SetProperty("Title", Dvelop_confirmpanel_btnreprovar_Title);
            ucDvelop_confirmpanel_btnreprovar.SetProperty("ConfirmationText", Dvelop_confirmpanel_btnreprovar_Confirmationtext);
            ucDvelop_confirmpanel_btnreprovar.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btnreprovar_Yesbuttoncaption);
            ucDvelop_confirmpanel_btnreprovar.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btnreprovar_Nobuttoncaption);
            ucDvelop_confirmpanel_btnreprovar.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btnreprovar_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btnreprovar.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btnreprovar_Yesbuttonposition);
            ucDvelop_confirmpanel_btnreprovar.SetProperty("ConfirmType", Dvelop_confirmpanel_btnreprovar_Confirmtype);
            ucDvelop_confirmpanel_btnreprovar.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btnreprovar_Internalname, "DVELOP_CONFIRMPANEL_BTNREPROVARContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_BTNREPROVARContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_178_9C2e( true) ;
         }
         else
         {
            wb_table1_178_9C2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV17PropostaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV17PropostaId", StringUtil.LTrimStr( (decimal)(AV17PropostaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17PropostaId), "ZZZZZZZZ9"), context));
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
         PA9C2( ) ;
         WS9C2( ) ;
         WE9C2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcnotafiscalitemlistaitensww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcnotafiscalitemlistaitensww_Component) != 0 )
            {
               WebComp_Wcnotafiscalitemlistaitensww.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcnotafiscalparcelamentoww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcnotafiscalparcelamentoww_Component) != 0 )
            {
               WebComp_Wcnotafiscalparcelamentoww.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101928761", true, true);
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
         context.AddJavascriptSource("wpconsultapropostanota.js", "?20256101928761", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavResponsavelcargo.Name = "vRESPONSAVELCARGO";
         cmbavResponsavelcargo.WebTags = "";
         cmbavResponsavelcargo.addItem("DIRETOR", "DIRETOR", 0);
         cmbavResponsavelcargo.addItem("GERENTE", "GERENTE", 0);
         cmbavResponsavelcargo.addItem("COORDENADOR", "COORDENADOR", 0);
         cmbavResponsavelcargo.addItem("SUPERVISOR", "SUPERVISOR", 0);
         cmbavResponsavelcargo.addItem("ANALISTA", "ANALISTA", 0);
         cmbavResponsavelcargo.addItem("ASSISTENTE", "ASSISTENTE", 0);
         cmbavResponsavelcargo.addItem("ESTAGIARIO", "ESTAGIARIO", 0);
         cmbavResponsavelcargo.addItem("OUTRO", "OUTRO", 0);
         if ( cmbavResponsavelcargo.ItemCount > 0 )
         {
            AV11ResponsavelCargo = cmbavResponsavelcargo.getValidValue(AV11ResponsavelCargo);
            AssignAttri("", false, "AV11ResponsavelCargo", AV11ResponsavelCargo);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextvoltar_Internalname = "TEXTVOLTAR";
         divTablevoltar_Internalname = "TABLEVOLTAR";
         lblLblstatusheader_Internalname = "LBLSTATUSHEADER";
         lblTextblockpropostaprotocolo_Internalname = "TEXTBLOCKPROPOSTAPROTOCOLO";
         edtavPropostaprotocolo_Internalname = "vPROPOSTAPROTOCOLO";
         divUnnamedtablepropostaprotocolo_Internalname = "UNNAMEDTABLEPROPOSTAPROTOCOLO";
         lblTextblockclienterazaosocial_Internalname = "TEXTBLOCKCLIENTERAZAOSOCIAL";
         edtavClienterazaosocial_Internalname = "vCLIENTERAZAOSOCIAL";
         divUnnamedtableclienterazaosocial_Internalname = "UNNAMEDTABLECLIENTERAZAOSOCIAL";
         divPanelheader_Internalname = "PANELHEADER";
         lblTextblockpropostacreatedat_Internalname = "TEXTBLOCKPROPOSTACREATEDAT";
         edtavPropostacreatedat_Internalname = "vPROPOSTACREATEDAT";
         divUnnamedtablepropostacreatedat_Internalname = "UNNAMEDTABLEPROPOSTACREATEDAT";
         lblTextblockpropostasumitensnota_f_Internalname = "TEXTBLOCKPROPOSTASUMITENSNOTA_F";
         edtavPropostasumitensnota_f_Internalname = "vPROPOSTASUMITENSNOTA_F";
         divUnnamedtablepropostasumitensnota_f_Internalname = "UNNAMEDTABLEPROPOSTASUMITENSNOTA_F";
         divPanelheadercontent_Internalname = "PANELHEADERCONTENT";
         lblTextitensincludes_Internalname = "TEXTITENSINCLUDES";
         lblTextdup_Internalname = "TEXTDUP";
         divTablenotaitens_Internalname = "TABLENOTAITENS";
         edtavDecisao_Internalname = "vDECISAO";
         bttBtnbtnreprovar_Internalname = "BTNBTNREPROVAR";
         bttBtnbtnaprovar_Internalname = "BTNBTNAPROVAR";
         divTabledecisionnotes_Internalname = "TABLEDECISIONNOTES";
         bttBtngerarcontrato_Internalname = "BTNGERARCONTRATO";
         divTablecontrato_Internalname = "TABLECONTRATO";
         divTablepanelleft_Internalname = "TABLEPANELLEFT";
         Dvpanel_tablepanelleft_Internalname = "DVPANEL_TABLEPANELLEFT";
         divTableleft_Internalname = "TABLELEFT";
         edtavInfoclienterazaosocial_Internalname = "vINFOCLIENTERAZAOSOCIAL";
         lblLblclientescorebutton_Internalname = "LBLCLIENTESCOREBUTTON";
         divTableconsultascorecliente_Internalname = "TABLECONSULTASCORECLIENTE";
         lblLblclientescore_Internalname = "LBLCLIENTESCORE";
         divTablescorecliente_Internalname = "TABLESCORECLIENTE";
         lblTextlinerep_Internalname = "TEXTLINEREP";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblLblresponsavelnome_Internalname = "LBLRESPONSAVELNOME";
         cmbavResponsavelcargo_Internalname = "vRESPONSAVELCARGO";
         edtavResponsavelemail_Internalname = "vRESPONSAVELEMAIL";
         bttBtnverperfilcliente_Internalname = "BTNVERPERFILCLIENTE";
         divTablepanelclientinformation_Internalname = "TABLEPANELCLIENTINFORMATION";
         Dvpanel_tablepanelclientinformation_Internalname = "DVPANEL_TABLEPANELCLIENTINFORMATION";
         edtavItensresumo_Internalname = "vITENSRESUMO";
         edtavNotasresumo_Internalname = "vNOTASRESUMO";
         edtavValorresumo_Internalname = "vVALORRESUMO";
         lblTextline_Internalname = "TEXTLINE";
         lblLblstatussummary_Internalname = "LBLSTATUSSUMMARY";
         divTablepanelproposalsummary_Internalname = "TABLEPANELPROPOSALSUMMARY";
         Dvpanel_tablepanelproposalsummary_Internalname = "DVPANEL_TABLEPANELPROPOSALSUMMARY";
         divTablepanelhistory_Internalname = "TABLEPANELHISTORY";
         Dvpanel_tablepanelhistory_Internalname = "DVPANEL_TABLEPANELHISTORY";
         divTableright_Internalname = "TABLERIGHT";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         Dvelop_confirmpanel_btnreprovar_Internalname = "DVELOP_CONFIRMPANEL_BTNREPROVAR";
         tblTabledvelop_confirmpanel_btnreprovar_Internalname = "TABLEDVELOP_CONFIRMPANEL_BTNREPROVAR";
         Dvelop_confirmpanel_btnaprovar_Internalname = "DVELOP_CONFIRMPANEL_BTNAPROVAR";
         tblTabledvelop_confirmpanel_btnaprovar_Internalname = "TABLEDVELOP_CONFIRMPANEL_BTNAPROVAR";
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
         lblLblstatussummary_Caption = "<div style=\"margin-top:3px;display:flex; width:100%; align-items:center;justify-content: space-between;\"><strong>Status</strong> <span class=\"status-badge status-awaiting\">Aguardando Aprovação</span></div>";
         edtavValorresumo_Jsonclick = "";
         edtavValorresumo_Enabled = 1;
         edtavNotasresumo_Jsonclick = "";
         edtavNotasresumo_Enabled = 1;
         edtavItensresumo_Jsonclick = "";
         edtavItensresumo_Enabled = 1;
         edtavResponsavelemail_Jsonclick = "";
         edtavResponsavelemail_Enabled = 1;
         cmbavResponsavelcargo_Jsonclick = "";
         cmbavResponsavelcargo.Enabled = 1;
         edtavInfoclienterazaosocial_Jsonclick = "";
         edtavInfoclienterazaosocial_Enabled = 1;
         divTablecontrato_Visible = 1;
         bttBtnbtnaprovar_Visible = 1;
         bttBtnbtnreprovar_Visible = 1;
         edtavDecisao_Enabled = 1;
         divTabledecisionnotes_Visible = 1;
         edtavPropostasumitensnota_f_Jsonclick = "";
         edtavPropostasumitensnota_f_Enabled = 1;
         edtavPropostacreatedat_Jsonclick = "";
         edtavPropostacreatedat_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         edtavPropostaprotocolo_Jsonclick = "";
         edtavPropostaprotocolo_Enabled = 1;
         lblLblstatusheader_Caption = "<span class=\"status-badge status-awaiting\">Aguardando Aprovação</span>";
         Dvelop_confirmpanel_btnaprovar_Confirmtype = "1";
         Dvelop_confirmpanel_btnaprovar_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btnaprovar_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btnaprovar_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btnaprovar_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btnaprovar_Confirmationtext = "Você deseja continuar com a aprovação desta proposta? Clique em 'Sim' para confirmar ou 'Não' para interromper";
         Dvelop_confirmpanel_btnaprovar_Title = "Aprovação";
         Dvelop_confirmpanel_btnreprovar_Confirmtype = "1";
         Dvelop_confirmpanel_btnreprovar_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btnreprovar_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btnreprovar_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btnreprovar_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btnreprovar_Confirmationtext = "Você deseja continuar com a reprovação desta proposta? Clique em 'Sim' para confirmar ou 'Não' para interromper";
         Dvelop_confirmpanel_btnreprovar_Title = "Reprovar";
         Dvpanel_tablepanelhistory_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablepanelhistory_Iconposition = "Right";
         Dvpanel_tablepanelhistory_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablepanelhistory_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablepanelhistory_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablepanelhistory_Title = "Histórico";
         Dvpanel_tablepanelhistory_Cls = "PanelCard_GrayTitle panel-list-item";
         Dvpanel_tablepanelhistory_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablepanelhistory_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablepanelhistory_Width = "100%";
         Dvpanel_tablepanelproposalsummary_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablepanelproposalsummary_Iconposition = "Right";
         Dvpanel_tablepanelproposalsummary_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablepanelproposalsummary_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablepanelproposalsummary_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablepanelproposalsummary_Title = "Resumo da proposta";
         Dvpanel_tablepanelproposalsummary_Cls = "PanelCard_GrayTitle panel-list-item";
         Dvpanel_tablepanelproposalsummary_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablepanelproposalsummary_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablepanelproposalsummary_Width = "100%";
         Dvpanel_tablepanelclientinformation_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablepanelclientinformation_Iconposition = "Right";
         Dvpanel_tablepanelclientinformation_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablepanelclientinformation_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablepanelclientinformation_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablepanelclientinformation_Title = "Informações do Cliente";
         Dvpanel_tablepanelclientinformation_Cls = "PanelCard_GrayTitle";
         Dvpanel_tablepanelclientinformation_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablepanelclientinformation_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablepanelclientinformation_Width = "100%";
         Dvpanel_tablepanelleft_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablepanelleft_Iconposition = "Right";
         Dvpanel_tablepanelleft_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablepanelleft_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablepanelleft_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablepanelleft_Title = "Proposta";
         Dvpanel_tablepanelleft_Cls = "PanelCard_GrayTitle";
         Dvpanel_tablepanelleft_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablepanelleft_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablepanelleft_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Proposta";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV17PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOVERPERFILCLIENTE'","""{"handler":"E149C1","iparms":[]}""");
         setEventMetadata("'DOGERARCONTRATO'","""{"handler":"E139C1","iparms":[]}""");
         setEventMetadata("'DOBTNREPROVAR'","""{"handler":"E119C1","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNREPROVAR.CLOSE","""{"handler":"E159C2","iparms":[{"av":"Dvelop_confirmpanel_btnreprovar_Result","ctrl":"DVELOP_CONFIRMPANEL_BTNREPROVAR","prop":"Result"},{"av":"AV17PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV9Decisao","fld":"vDECISAO","type":"svchar"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNREPROVAR.CLOSE",""","oparms":[{"ctrl":"BTNBTNAPROVAR","prop":"Visible"},{"ctrl":"BTNBTNREPROVAR","prop":"Visible"},{"av":"edtavDecisao_Enabled","ctrl":"vDECISAO","prop":"Enabled"}]}""");
         setEventMetadata("'DOBTNAPROVAR'","""{"handler":"E129C1","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNAPROVAR.CLOSE","""{"handler":"E169C2","iparms":[{"av":"Dvelop_confirmpanel_btnaprovar_Result","ctrl":"DVELOP_CONFIRMPANEL_BTNAPROVAR","prop":"Result"},{"av":"AV17PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV9Decisao","fld":"vDECISAO","type":"svchar"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNAPROVAR.CLOSE",""","oparms":[{"ctrl":"BTNBTNAPROVAR","prop":"Visible"},{"ctrl":"BTNBTNREPROVAR","prop":"Visible"},{"av":"edtavDecisao_Enabled","ctrl":"vDECISAO","prop":"Enabled"}]}""");
         setEventMetadata("TABLEVOLTAR.CLICK","""{"handler":"E189C2","iparms":[]}""");
         setEventMetadata("VALIDV_RESPONSAVELCARGO","""{"handler":"Validv_Responsavelcargo","iparms":[]}""");
         setEventMetadata("VALIDV_RESPONSAVELEMAIL","""{"handler":"Validv_Responsavelemail","iparms":[]}""");
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
         Dvelop_confirmpanel_btnreprovar_Result = "";
         Dvelop_confirmpanel_btnaprovar_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextvoltar_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tablepanelleft = new GXUserControl();
         lblLblstatusheader_Jsonclick = "";
         lblTextblockpropostaprotocolo_Jsonclick = "";
         TempTags = "";
         AV15PropostaProtocolo = "";
         lblTextblockclienterazaosocial_Jsonclick = "";
         AV16ClienteRazaoSocial = "";
         lblTextblockpropostacreatedat_Jsonclick = "";
         AV13PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         lblTextblockpropostasumitensnota_f_Jsonclick = "";
         lblTextitensincludes_Jsonclick = "";
         WebComp_Wcnotafiscalitemlistaitensww_Component = "";
         OldWcnotafiscalitemlistaitensww = "";
         lblTextdup_Jsonclick = "";
         WebComp_Wcnotafiscalparcelamentoww_Component = "";
         OldWcnotafiscalparcelamentoww = "";
         AV9Decisao = "";
         bttBtnbtnreprovar_Jsonclick = "";
         bttBtnbtnaprovar_Jsonclick = "";
         bttBtngerarcontrato_Jsonclick = "";
         ucDvpanel_tablepanelclientinformation = new GXUserControl();
         AV10InfoClienteRazaoSocial = "";
         lblLblclientescorebutton_Jsonclick = "";
         lblLblclientescore_Jsonclick = "";
         lblTextlinerep_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblLblresponsavelnome_Jsonclick = "";
         AV11ResponsavelCargo = "";
         AV12ResponsavelEmail = "";
         bttBtnverperfilcliente_Jsonclick = "";
         ucDvpanel_tablepanelproposalsummary = new GXUserControl();
         AV5ItensResumo = "";
         AV6NotasResumo = "";
         AV7ValorResumo = "";
         lblTextline_Jsonclick = "";
         lblLblstatussummary_Jsonclick = "";
         ucDvpanel_tablepanelhistory = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV22WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV24Array_NotaFiscalId = new GxSimpleCollection<Guid>();
         H009C2_A323PropostaId = new int[1] ;
         H009C2_n323PropostaId = new bool[] {false} ;
         H009C2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H009C2_n794NotaFiscalId = new bool[] {false} ;
         A794NotaFiscalId = Guid.Empty;
         AV25ParcelamentoJSON = "";
         H009C4_A323PropostaId = new int[1] ;
         H009C4_n323PropostaId = new bool[] {false} ;
         H009C4_A853PropostaProtocolo = new string[] {""} ;
         H009C4_n853PropostaProtocolo = new bool[] {false} ;
         H009C4_A850PropostaEmpresaClienteId = new int[1] ;
         H009C4_n850PropostaEmpresaClienteId = new bool[] {false} ;
         H009C4_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H009C4_n327PropostaCreatedAt = new bool[] {false} ;
         H009C4_A329PropostaStatus = new string[] {""} ;
         H009C4_n329PropostaStatus = new bool[] {false} ;
         H009C4_A887PropostaSumItensnota_F = new decimal[1] ;
         H009C4_n887PropostaSumItensnota_F = new bool[] {false} ;
         A853PropostaProtocolo = "";
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         A329PropostaStatus = "";
         AV26PropostaStatus = "";
         H009C5_A336AprovacaoId = new int[1] ;
         H009C5_A323PropostaId = new int[1] ;
         H009C5_n323PropostaId = new bool[] {false} ;
         H009C5_A375AprovadoresId = new int[1] ;
         H009C5_n375AprovadoresId = new bool[] {false} ;
         H009C5_A338AprovacaoDecisao = new string[] {""} ;
         H009C5_n338AprovacaoDecisao = new bool[] {false} ;
         A338AprovacaoDecisao = "";
         H009C6_A168ClienteId = new int[1] ;
         H009C6_A170ClienteRazaoSocial = new string[] {""} ;
         H009C6_n170ClienteRazaoSocial = new bool[] {false} ;
         H009C6_A885ResponsavelCargo = new string[] {""} ;
         H009C6_n885ResponsavelCargo = new bool[] {false} ;
         H009C6_A456ResponsavelEmail = new string[] {""} ;
         H009C6_n456ResponsavelEmail = new bool[] {false} ;
         A170ClienteRazaoSocial = "";
         A885ResponsavelCargo = "";
         A456ResponsavelEmail = "";
         AV21DmAprovacaoStatus = "";
         AV20SdErro = new SdtSdErro(context);
         GXt_char2 = "";
         GXt_char3 = "";
         sStyleString = "";
         ucDvelop_confirmpanel_btnaprovar = new GXUserControl();
         ucDvelop_confirmpanel_btnreprovar = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpconsultapropostanota__default(),
            new Object[][] {
                new Object[] {
               H009C2_A323PropostaId, H009C2_n323PropostaId, H009C2_A794NotaFiscalId, H009C2_n794NotaFiscalId
               }
               , new Object[] {
               H009C4_A323PropostaId, H009C4_A853PropostaProtocolo, H009C4_n853PropostaProtocolo, H009C4_A850PropostaEmpresaClienteId, H009C4_n850PropostaEmpresaClienteId, H009C4_A327PropostaCreatedAt, H009C4_n327PropostaCreatedAt, H009C4_A329PropostaStatus, H009C4_n329PropostaStatus, H009C4_A887PropostaSumItensnota_F,
               H009C4_n887PropostaSumItensnota_F
               }
               , new Object[] {
               H009C5_A336AprovacaoId, H009C5_A323PropostaId, H009C5_n323PropostaId, H009C5_A375AprovadoresId, H009C5_n375AprovadoresId, H009C5_A338AprovacaoDecisao, H009C5_n338AprovacaoDecisao
               }
               , new Object[] {
               H009C6_A168ClienteId, H009C6_A170ClienteRazaoSocial, H009C6_n170ClienteRazaoSocial, H009C6_A885ResponsavelCargo, H009C6_n885ResponsavelCargo, H009C6_A456ResponsavelEmail, H009C6_n456ResponsavelEmail
               }
            }
         );
         WebComp_Wcnotafiscalitemlistaitensww = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcnotafiscalparcelamentoww = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavPropostaprotocolo_Enabled = 0;
         edtavClienterazaosocial_Enabled = 0;
         edtavPropostacreatedat_Enabled = 0;
         edtavPropostasumitensnota_f_Enabled = 0;
         edtavInfoclienterazaosocial_Enabled = 0;
         cmbavResponsavelcargo.Enabled = 0;
         edtavResponsavelemail_Enabled = 0;
         edtavItensresumo_Enabled = 0;
         edtavNotasresumo_Enabled = 0;
         edtavValorresumo_Enabled = 0;
      }

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
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV17PropostaId ;
      private int wcpOAV17PropostaId ;
      private int edtavPropostaprotocolo_Enabled ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavPropostacreatedat_Enabled ;
      private int edtavPropostasumitensnota_f_Enabled ;
      private int divTabledecisionnotes_Visible ;
      private int edtavDecisao_Enabled ;
      private int bttBtnbtnreprovar_Visible ;
      private int bttBtnbtnaprovar_Visible ;
      private int divTablecontrato_Visible ;
      private int edtavInfoclienterazaosocial_Enabled ;
      private int edtavResponsavelemail_Enabled ;
      private int edtavItensresumo_Enabled ;
      private int edtavNotasresumo_Enabled ;
      private int edtavValorresumo_Enabled ;
      private int A323PropostaId ;
      private int A850PropostaEmpresaClienteId ;
      private int AV18PropostaEmpresaClienteId ;
      private int A375AprovadoresId ;
      private int A168ClienteId ;
      private int idxLst ;
      private decimal AV14PropostaSumItensnota_F ;
      private decimal A887PropostaSumItensnota_F ;
      private string Dvelop_confirmpanel_btnreprovar_Result ;
      private string Dvelop_confirmpanel_btnaprovar_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_tablepanelleft_Width ;
      private string Dvpanel_tablepanelleft_Cls ;
      private string Dvpanel_tablepanelleft_Title ;
      private string Dvpanel_tablepanelleft_Iconposition ;
      private string Dvpanel_tablepanelclientinformation_Width ;
      private string Dvpanel_tablepanelclientinformation_Cls ;
      private string Dvpanel_tablepanelclientinformation_Title ;
      private string Dvpanel_tablepanelclientinformation_Iconposition ;
      private string Dvpanel_tablepanelproposalsummary_Width ;
      private string Dvpanel_tablepanelproposalsummary_Cls ;
      private string Dvpanel_tablepanelproposalsummary_Title ;
      private string Dvpanel_tablepanelproposalsummary_Iconposition ;
      private string Dvpanel_tablepanelhistory_Width ;
      private string Dvpanel_tablepanelhistory_Cls ;
      private string Dvpanel_tablepanelhistory_Title ;
      private string Dvpanel_tablepanelhistory_Iconposition ;
      private string Dvelop_confirmpanel_btnreprovar_Title ;
      private string Dvelop_confirmpanel_btnreprovar_Confirmationtext ;
      private string Dvelop_confirmpanel_btnreprovar_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btnreprovar_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btnreprovar_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btnreprovar_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btnreprovar_Confirmtype ;
      private string Dvelop_confirmpanel_btnaprovar_Title ;
      private string Dvelop_confirmpanel_btnaprovar_Confirmationtext ;
      private string Dvelop_confirmpanel_btnaprovar_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btnaprovar_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btnaprovar_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btnaprovar_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btnaprovar_Confirmtype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablevoltar_Internalname ;
      private string lblTextvoltar_Internalname ;
      private string lblTextvoltar_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableleft_Internalname ;
      private string Dvpanel_tablepanelleft_Internalname ;
      private string divTablepanelleft_Internalname ;
      private string lblLblstatusheader_Internalname ;
      private string lblLblstatusheader_Caption ;
      private string lblLblstatusheader_Jsonclick ;
      private string divPanelheader_Internalname ;
      private string divUnnamedtablepropostaprotocolo_Internalname ;
      private string lblTextblockpropostaprotocolo_Internalname ;
      private string lblTextblockpropostaprotocolo_Jsonclick ;
      private string edtavPropostaprotocolo_Internalname ;
      private string TempTags ;
      private string edtavPropostaprotocolo_Jsonclick ;
      private string divUnnamedtableclienterazaosocial_Internalname ;
      private string lblTextblockclienterazaosocial_Internalname ;
      private string lblTextblockclienterazaosocial_Jsonclick ;
      private string edtavClienterazaosocial_Internalname ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string divPanelheadercontent_Internalname ;
      private string divUnnamedtablepropostacreatedat_Internalname ;
      private string lblTextblockpropostacreatedat_Internalname ;
      private string lblTextblockpropostacreatedat_Jsonclick ;
      private string edtavPropostacreatedat_Internalname ;
      private string edtavPropostacreatedat_Jsonclick ;
      private string divUnnamedtablepropostasumitensnota_f_Internalname ;
      private string lblTextblockpropostasumitensnota_f_Internalname ;
      private string lblTextblockpropostasumitensnota_f_Jsonclick ;
      private string edtavPropostasumitensnota_f_Internalname ;
      private string edtavPropostasumitensnota_f_Jsonclick ;
      private string divTablenotaitens_Internalname ;
      private string lblTextitensincludes_Internalname ;
      private string lblTextitensincludes_Jsonclick ;
      private string WebComp_Wcnotafiscalitemlistaitensww_Component ;
      private string OldWcnotafiscalitemlistaitensww ;
      private string lblTextdup_Internalname ;
      private string lblTextdup_Jsonclick ;
      private string WebComp_Wcnotafiscalparcelamentoww_Component ;
      private string OldWcnotafiscalparcelamentoww ;
      private string divTabledecisionnotes_Internalname ;
      private string edtavDecisao_Internalname ;
      private string bttBtnbtnreprovar_Internalname ;
      private string bttBtnbtnreprovar_Jsonclick ;
      private string bttBtnbtnaprovar_Internalname ;
      private string bttBtnbtnaprovar_Jsonclick ;
      private string divTablecontrato_Internalname ;
      private string bttBtngerarcontrato_Internalname ;
      private string bttBtngerarcontrato_Jsonclick ;
      private string divTableright_Internalname ;
      private string Dvpanel_tablepanelclientinformation_Internalname ;
      private string divTablepanelclientinformation_Internalname ;
      private string edtavInfoclienterazaosocial_Internalname ;
      private string edtavInfoclienterazaosocial_Jsonclick ;
      private string divTableconsultascorecliente_Internalname ;
      private string lblLblclientescorebutton_Internalname ;
      private string lblLblclientescorebutton_Jsonclick ;
      private string divTablescorecliente_Internalname ;
      private string lblLblclientescore_Internalname ;
      private string lblLblclientescore_Jsonclick ;
      private string lblTextlinerep_Internalname ;
      private string lblTextlinerep_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string lblLblresponsavelnome_Internalname ;
      private string lblLblresponsavelnome_Jsonclick ;
      private string cmbavResponsavelcargo_Internalname ;
      private string cmbavResponsavelcargo_Jsonclick ;
      private string edtavResponsavelemail_Internalname ;
      private string edtavResponsavelemail_Jsonclick ;
      private string bttBtnverperfilcliente_Internalname ;
      private string bttBtnverperfilcliente_Jsonclick ;
      private string Dvpanel_tablepanelproposalsummary_Internalname ;
      private string divTablepanelproposalsummary_Internalname ;
      private string edtavItensresumo_Internalname ;
      private string edtavItensresumo_Jsonclick ;
      private string edtavNotasresumo_Internalname ;
      private string edtavNotasresumo_Jsonclick ;
      private string edtavValorresumo_Internalname ;
      private string edtavValorresumo_Jsonclick ;
      private string lblTextline_Internalname ;
      private string lblTextline_Jsonclick ;
      private string lblLblstatussummary_Internalname ;
      private string lblLblstatussummary_Caption ;
      private string lblLblstatussummary_Jsonclick ;
      private string Dvpanel_tablepanelhistory_Internalname ;
      private string divTablepanelhistory_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string sStyleString ;
      private string tblTabledvelop_confirmpanel_btnaprovar_Internalname ;
      private string Dvelop_confirmpanel_btnaprovar_Internalname ;
      private string tblTabledvelop_confirmpanel_btnreprovar_Internalname ;
      private string Dvelop_confirmpanel_btnreprovar_Internalname ;
      private DateTime AV13PropostaCreatedAt ;
      private DateTime A327PropostaCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tablepanelleft_Autowidth ;
      private bool Dvpanel_tablepanelleft_Autoheight ;
      private bool Dvpanel_tablepanelleft_Collapsible ;
      private bool Dvpanel_tablepanelleft_Collapsed ;
      private bool Dvpanel_tablepanelleft_Showcollapseicon ;
      private bool Dvpanel_tablepanelleft_Autoscroll ;
      private bool Dvpanel_tablepanelclientinformation_Autowidth ;
      private bool Dvpanel_tablepanelclientinformation_Autoheight ;
      private bool Dvpanel_tablepanelclientinformation_Collapsible ;
      private bool Dvpanel_tablepanelclientinformation_Collapsed ;
      private bool Dvpanel_tablepanelclientinformation_Showcollapseicon ;
      private bool Dvpanel_tablepanelclientinformation_Autoscroll ;
      private bool Dvpanel_tablepanelproposalsummary_Autowidth ;
      private bool Dvpanel_tablepanelproposalsummary_Autoheight ;
      private bool Dvpanel_tablepanelproposalsummary_Collapsible ;
      private bool Dvpanel_tablepanelproposalsummary_Collapsed ;
      private bool Dvpanel_tablepanelproposalsummary_Showcollapseicon ;
      private bool Dvpanel_tablepanelproposalsummary_Autoscroll ;
      private bool Dvpanel_tablepanelhistory_Autowidth ;
      private bool Dvpanel_tablepanelhistory_Autoheight ;
      private bool Dvpanel_tablepanelhistory_Collapsible ;
      private bool Dvpanel_tablepanelhistory_Collapsed ;
      private bool Dvpanel_tablepanelhistory_Showcollapseicon ;
      private bool Dvpanel_tablepanelhistory_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n323PropostaId ;
      private bool n794NotaFiscalId ;
      private bool n853PropostaProtocolo ;
      private bool n850PropostaEmpresaClienteId ;
      private bool n327PropostaCreatedAt ;
      private bool n329PropostaStatus ;
      private bool n887PropostaSumItensnota_F ;
      private bool n375AprovadoresId ;
      private bool n338AprovacaoDecisao ;
      private bool n170ClienteRazaoSocial ;
      private bool n885ResponsavelCargo ;
      private bool n456ResponsavelEmail ;
      private bool bDynCreated_Wcnotafiscalitemlistaitensww ;
      private bool bDynCreated_Wcnotafiscalparcelamentoww ;
      private string AV25ParcelamentoJSON ;
      private string AV15PropostaProtocolo ;
      private string AV16ClienteRazaoSocial ;
      private string AV9Decisao ;
      private string AV10InfoClienteRazaoSocial ;
      private string AV11ResponsavelCargo ;
      private string AV12ResponsavelEmail ;
      private string AV5ItensResumo ;
      private string AV6NotasResumo ;
      private string AV7ValorResumo ;
      private string A853PropostaProtocolo ;
      private string A329PropostaStatus ;
      private string AV26PropostaStatus ;
      private string A338AprovacaoDecisao ;
      private string A170ClienteRazaoSocial ;
      private string A885ResponsavelCargo ;
      private string A456ResponsavelEmail ;
      private string AV21DmAprovacaoStatus ;
      private Guid A794NotaFiscalId ;
      private GXWebComponent WebComp_Wcnotafiscalitemlistaitensww ;
      private GXWebComponent WebComp_Wcnotafiscalparcelamentoww ;
      private GXUserControl ucDvpanel_tablepanelleft ;
      private GXUserControl ucDvpanel_tablepanelclientinformation ;
      private GXUserControl ucDvpanel_tablepanelproposalsummary ;
      private GXUserControl ucDvpanel_tablepanelhistory ;
      private GXUserControl ucDvelop_confirmpanel_btnaprovar ;
      private GXUserControl ucDvelop_confirmpanel_btnreprovar ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavResponsavelcargo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV22WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private GxSimpleCollection<Guid> AV24Array_NotaFiscalId ;
      private IDataStoreProvider pr_default ;
      private int[] H009C2_A323PropostaId ;
      private bool[] H009C2_n323PropostaId ;
      private Guid[] H009C2_A794NotaFiscalId ;
      private bool[] H009C2_n794NotaFiscalId ;
      private int[] H009C4_A323PropostaId ;
      private bool[] H009C4_n323PropostaId ;
      private string[] H009C4_A853PropostaProtocolo ;
      private bool[] H009C4_n853PropostaProtocolo ;
      private int[] H009C4_A850PropostaEmpresaClienteId ;
      private bool[] H009C4_n850PropostaEmpresaClienteId ;
      private DateTime[] H009C4_A327PropostaCreatedAt ;
      private bool[] H009C4_n327PropostaCreatedAt ;
      private string[] H009C4_A329PropostaStatus ;
      private bool[] H009C4_n329PropostaStatus ;
      private decimal[] H009C4_A887PropostaSumItensnota_F ;
      private bool[] H009C4_n887PropostaSumItensnota_F ;
      private int[] H009C5_A336AprovacaoId ;
      private int[] H009C5_A323PropostaId ;
      private bool[] H009C5_n323PropostaId ;
      private int[] H009C5_A375AprovadoresId ;
      private bool[] H009C5_n375AprovadoresId ;
      private string[] H009C5_A338AprovacaoDecisao ;
      private bool[] H009C5_n338AprovacaoDecisao ;
      private int[] H009C6_A168ClienteId ;
      private string[] H009C6_A170ClienteRazaoSocial ;
      private bool[] H009C6_n170ClienteRazaoSocial ;
      private string[] H009C6_A885ResponsavelCargo ;
      private bool[] H009C6_n885ResponsavelCargo ;
      private string[] H009C6_A456ResponsavelEmail ;
      private bool[] H009C6_n456ResponsavelEmail ;
      private SdtSdErro AV20SdErro ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpconsultapropostanota__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH009C2;
          prmH009C2 = new Object[] {
          new ParDef("AV17PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH009C4;
          prmH009C4 = new Object[] {
          new ParDef("AV17PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH009C5;
          prmH009C5 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AV22WWPContext__Aprovadorid",GXType.Int16,4,0)
          };
          Object[] prmH009C6;
          prmH009C6 = new Object[] {
          new ParDef("AV18PropostaEmpresaClienteId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009C2", "SELECT DISTINCT NULL AS PropostaId, NotaFiscalId FROM ( SELECT PropostaId, NotaFiscalId FROM NotaFiscalItem WHERE PropostaId = :AV17PropostaId ORDER BY NotaFiscalId) DistinctT ORDER BY NotaFiscalId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009C2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009C4", "SELECT T1.PropostaId, T1.PropostaProtocolo, T1.PropostaEmpresaClienteId, T1.PropostaCreatedAt, T1.PropostaStatus, COALESCE( T2.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F FROM (Proposta T1 LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F, PropostaId FROM NotaFiscalItem WHERE T1.PropostaId = PropostaId GROUP BY PropostaId ) T2 ON T2.PropostaId = T1.PropostaId) WHERE T1.PropostaId = :AV17PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009C4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H009C5", "SELECT AprovacaoId, PropostaId, AprovadoresId, AprovacaoDecisao FROM Aprovacao WHERE (PropostaId = :PropostaId) AND (AprovadoresId = :AV22WWPContext__Aprovadorid) ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009C5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009C6", "SELECT ClienteId, ClienteRazaoSocial, ResponsavelCargo, ResponsavelEmail FROM Cliente WHERE ClienteId = :AV18PropostaEmpresaClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009C6,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
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
       }
    }

 }

}
