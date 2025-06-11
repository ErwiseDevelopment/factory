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
   public class wpconsultaeditarepresentante : GXDataArea
   {
      public wpconsultaeditarepresentante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpconsultaeditarepresentante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ClienteId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV12ClienteId = aP1_ClienteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCargo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
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
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
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
         PA992( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START992( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         GXEncryptionTmp = "wpconsultaeditarepresentante"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV12ClienteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpconsultaeditarepresentante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV29WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV29WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV29WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vCLIENTESITUACAO", StringUtil.RTrim( AV28ClienteSituacao));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTESITUACAO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28ClienteSituacao, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTE", AV11Cliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTE", AV11Cliente);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTE", GetSecureSignedToken( "", AV11Cliente, context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12ClienteId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV29WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV29WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV29WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vCLIENTESITUACAO", StringUtil.RTrim( AV28ClienteSituacao));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTESITUACAO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28ClienteSituacao, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTE", AV11Cliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTE", AV11Cliente);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTE", GetSecureSignedToken( "", AV11Cliente, context));
         GxWebStd.gx_hidden_field( context, "vCOMPANYISFOUND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20CompanyIsFound), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISVALID", AV21IsValid);
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Title", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_representante_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_representante_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_representante_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_representante_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_representante_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_representante_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_representante_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Comment", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_representante_Comment));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Bodycontentinternalname", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_representante_Bodycontentinternalname));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_representante_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Result", StringUtil.RTrim( Dvelop_confirmpanel_btnaprovar_representante_Result));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE992( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT992( ) ;
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
         GXEncryptionTmp = "wpconsultaeditarepresentante"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV12ClienteId,9,0));
         return formatLink("wpconsultaeditarepresentante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpConsultaEditaRepresentante" ;
      }

      public override string GetPgmdesc( )
      {
         return "Representante" ;
      }

      protected void WB990( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaprovar_representante_Internalname, "", "Aprovar representante", bttBtnaprovar_representante_Jsonclick, 7, "Aprovar representante", "", StyleString, ClassString, bttBtnaprovar_representante_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11991_client"+"'", TempTags, "", 2, "HLP_WpConsultaEditaRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_label_ctrl( context, lblTabrepresentante_title_Internalname, "Representante", "", "", lblTabrepresentante_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpConsultaEditaRepresentante.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabRepresentante") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNome_Internalname, "Nome do Representante", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNome_Internalname, AV6Nome, StringUtil.RTrim( context.localUtil.Format( AV6Nome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavNome_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaEditaRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavCargo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCargo_Internalname, "Cargo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCargo, cmbavCargo_Internalname, StringUtil.RTrim( AV7Cargo), 1, cmbavCargo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavCargo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_WpConsultaEditaRepresentante.htm");
            cmbavCargo.CurrentValue = StringUtil.RTrim( AV7Cargo);
            AssignProp("", false, cmbavCargo_Internalname, "Values", (string)(cmbavCargo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV8Email, StringUtil.RTrim( context.localUtil.Format( AV8Email, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaEditaRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCelular_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCelular_Internalname, "Celular", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCelular_Internalname, AV9Celular, StringUtil.RTrim( context.localUtil.Format( AV9Celular, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCelular_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCelular_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaEditaRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCpf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpf_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpf_Internalname, AV10CPF, StringUtil.RTrim( context.localUtil.Format( AV10CPF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCpf_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaEditaRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabempresa_title_Internalname, "Empresa", "", "", lblTabempresa_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpConsultaEditaRepresentante.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabEmpresa") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCnpj_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCnpj_Internalname, "CNPJ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCnpj_Internalname, AV5CNPJ, StringUtil.RTrim( context.localUtil.Format( AV5CNPJ, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCnpj_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCnpj_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaEditaRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuasearch_Internalname, "", "Buscar Empresa", bttBtnuasearch_Jsonclick, 5, "Buscar Empresa", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUASEARCH\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpConsultaEditaRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Dados da Empresa", 1, 0, "px", 0, "px", grpUnnamedgroup2_Class, "", "HLP_WpConsultaEditaRepresentante.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresanome_Internalname, AV13EmpresaNome, StringUtil.RTrim( context.localUtil.Format( AV13EmpresaNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresanome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresanome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaEditaRepresentante.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresaendereco_Internalname, AV14EmpresaEndereco, StringUtil.RTrim( context.localUtil.Format( AV14EmpresaEndereco, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresaendereco_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresaendereco_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaEditaRepresentante.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmpresaatividadeeconomica_Internalname, AV15EmpresaAtividadeEconomica, StringUtil.RTrim( context.localUtil.Format( AV15EmpresaAtividadeEconomica, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmpresaatividadeeconomica_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEmpresaatividadeeconomica_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConsultaEditaRepresentante.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpConsultaEditaRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpConsultaEditaRepresentante.htm");
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
            wb_table1_91_992( true) ;
         }
         else
         {
            wb_table1_91_992( false) ;
         }
         return  ;
      }

      protected void wb_table1_91_992e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_dvelop_confirmpanel_btnaprovar_representante_body_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "ConfirmComment";
            StyleString = "";
            ClassString = "ConfirmComment";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDvelop_confirmpanel_btnaprovar_representante_comment_Internalname, AV27DVelop_ConfirmPanel_BtnAprovar_Representante_Comment, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", 0, 1, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "Descrição da aprovação", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WpConsultaEditaRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START992( )
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
         Form.Meta.addItem("description", "Representante", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP990( ) ;
      }

      protected void WS992( )
      {
         START992( ) ;
         EVT992( ) ;
      }

      protected void EVT992( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_btnaprovar_representante.Close */
                              E12992 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E13992 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E14992 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUASEARCH'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUaSearch' */
                              E15992 ();
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
                                    E16992 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCELULAR.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E17992 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E18992 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE992( )
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

      protected void PA992( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpconsultaeditarepresentante")), "wpconsultaeditarepresentante") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpconsultaeditarepresentante")))) ;
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
                  gxfirstwebparm = GetFirstPar( "Mode");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     Gx_mode = gxfirstwebparm;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV12ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV12ClienteId", StringUtil.LTrimStr( (decimal)(AV12ClienteId), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12ClienteId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavNome_Internalname;
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
         if ( cmbavCargo.ItemCount > 0 )
         {
            AV7Cargo = cmbavCargo.getValidValue(AV7Cargo);
            AssignAttri("", false, "AV7Cargo", AV7Cargo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCargo.CurrentValue = StringUtil.RTrim( AV7Cargo);
            AssignProp("", false, cmbavCargo_Internalname, "Values", cmbavCargo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF992( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavEmpresanome_Enabled = 0;
         AssignProp("", false, edtavEmpresanome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresanome_Enabled), 5, 0), true);
         edtavEmpresaendereco_Enabled = 0;
         AssignProp("", false, edtavEmpresaendereco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresaendereco_Enabled), 5, 0), true);
         edtavEmpresaatividadeeconomica_Enabled = 0;
         AssignProp("", false, edtavEmpresaatividadeeconomica_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresaatividadeeconomica_Enabled), 5, 0), true);
      }

      protected void RF992( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E14992 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E18992 ();
            WB990( ) ;
         }
      }

      protected void send_integrity_lvl_hashes992( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV29WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV29WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV29WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vCLIENTESITUACAO", StringUtil.RTrim( AV28ClienteSituacao));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTESITUACAO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28ClienteSituacao, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTE", AV11Cliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTE", AV11Cliente);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTE", GetSecureSignedToken( "", AV11Cliente, context));
      }

      protected void before_start_formulas( )
      {
         edtavEmpresanome_Enabled = 0;
         AssignProp("", false, edtavEmpresanome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresanome_Enabled), 5, 0), true);
         edtavEmpresaendereco_Enabled = 0;
         AssignProp("", false, edtavEmpresaendereco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresaendereco_Enabled), 5, 0), true);
         edtavEmpresaatividadeeconomica_Enabled = 0;
         AssignProp("", false, edtavEmpresaatividadeeconomica_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmpresaatividadeeconomica_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP990( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13992 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Gxuitabspanel_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
            Dvelop_confirmpanel_btnaprovar_representante_Title = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Title");
            Dvelop_confirmpanel_btnaprovar_representante_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Confirmationtext");
            Dvelop_confirmpanel_btnaprovar_representante_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Yesbuttoncaption");
            Dvelop_confirmpanel_btnaprovar_representante_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Nobuttoncaption");
            Dvelop_confirmpanel_btnaprovar_representante_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Cancelbuttoncaption");
            Dvelop_confirmpanel_btnaprovar_representante_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Yesbuttonposition");
            Dvelop_confirmpanel_btnaprovar_representante_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Confirmtype");
            Dvelop_confirmpanel_btnaprovar_representante_Comment = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Comment");
            Dvelop_confirmpanel_btnaprovar_representante_Bodycontentinternalname = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Bodycontentinternalname");
            Dvelop_confirmpanel_btnaprovar_representante_Result = cgiGet( "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_Result");
            /* Read variables values. */
            AV6Nome = cgiGet( edtavNome_Internalname);
            AssignAttri("", false, "AV6Nome", AV6Nome);
            cmbavCargo.CurrentValue = cgiGet( cmbavCargo_Internalname);
            AV7Cargo = cgiGet( cmbavCargo_Internalname);
            AssignAttri("", false, "AV7Cargo", AV7Cargo);
            AV8Email = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV8Email", AV8Email);
            AV9Celular = cgiGet( edtavCelular_Internalname);
            AssignAttri("", false, "AV9Celular", AV9Celular);
            AV10CPF = cgiGet( edtavCpf_Internalname);
            AssignAttri("", false, "AV10CPF", AV10CPF);
            AV5CNPJ = cgiGet( edtavCnpj_Internalname);
            AssignAttri("", false, "AV5CNPJ", AV5CNPJ);
            AV13EmpresaNome = cgiGet( edtavEmpresanome_Internalname);
            AssignAttri("", false, "AV13EmpresaNome", AV13EmpresaNome);
            AV14EmpresaEndereco = cgiGet( edtavEmpresaendereco_Internalname);
            AssignAttri("", false, "AV14EmpresaEndereco", AV14EmpresaEndereco);
            AV15EmpresaAtividadeEconomica = cgiGet( edtavEmpresaatividadeeconomica_Internalname);
            AssignAttri("", false, "AV15EmpresaAtividadeEconomica", AV15EmpresaAtividadeEconomica);
            AV27DVelop_ConfirmPanel_BtnAprovar_Representante_Comment = cgiGet( edtavDvelop_confirmpanel_btnaprovar_representante_comment_Internalname);
            AssignAttri("", false, "AV27DVelop_ConfirmPanel_BtnAprovar_Representante_Comment", AV27DVelop_ConfirmPanel_BtnAprovar_Representante_Comment);
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
         E13992 ();
         if (returnInSub) return;
      }

      protected void E13992( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV29WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV29WWPContext = GXt_SdtWWPContext1;
         /* Execute user subroutine: 'LOADDATA' */
         S112 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            edtavNome_Enabled = 0;
            AssignProp("", false, edtavNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNome_Enabled), 5, 0), true);
            edtavEmail_Enabled = 0;
            AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), true);
            edtavCpf_Enabled = 0;
            AssignProp("", false, edtavCpf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCpf_Enabled), 5, 0), true);
            edtavCelular_Enabled = 0;
            AssignProp("", false, edtavCelular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCelular_Enabled), 5, 0), true);
            cmbavCargo.Enabled = 0;
            AssignProp("", false, cmbavCargo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavCargo.Enabled), 5, 0), true);
            edtavCnpj_Enabled = 0;
            AssignProp("", false, edtavCnpj_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCnpj_Enabled), 5, 0), true);
         }
         Dvelop_confirmpanel_btnaprovar_representante_Bodycontentinternalname = edtavDvelop_confirmpanel_btnaprovar_representante_comment_Internalname;
         ucDvelop_confirmpanel_btnaprovar_representante.SendProperty(context, "", false, Dvelop_confirmpanel_btnaprovar_representante_Internalname, "BodyContentInternalName", Dvelop_confirmpanel_btnaprovar_representante_Bodycontentinternalname);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E14992( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E12992( )
      {
         /* Dvelop_confirmpanel_btnaprovar_representante_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btnaprovar_representante_Result, "Yes") == 0 )
         {
            GXt_SdtSdErro2 = AV23SdErro;
            new praprovarrepresentante(context ).execute(  AV11Cliente.gxTpr_Clienteid, out  GXt_SdtSdErro2) ;
            AV23SdErro = GXt_SdtSdErro2;
            if ( (0==AV23SdErro.gxTpr_Internalcode) )
            {
               context.CommitDataStores("wpconsultaeditarepresentante",pr_default);
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Trim( AV23SdErro.gxTpr_Msg),  "error",  "",  "true",  ""));
            }
         }
      }

      protected void E15992( )
      {
         /* 'DoUaSearch' Routine */
         returnInSub = false;
         GXt_char3 = AV16CNPJDigitos;
         new prretornadigitos(context ).execute(  AV5CNPJ, out  GXt_char3) ;
         AV16CNPJDigitos = GXt_char3;
         new prvalidcpf(context ).execute(  "JURIDICA",  AV16CNPJDigitos, out  AV17IsCNPJValid, out  AV18ErrorMessage) ;
         if ( AV17IsCNPJValid )
         {
            GXt_SdtSdEmpresas4 = AV19SdEmpresas;
            GXt_char3 = "";
            new prretornadigitos(context ).execute(  AV16CNPJDigitos, out  GXt_char3) ;
            new prgetempresaapi(context ).execute(  GXt_char3, out  GXt_SdtSdEmpresas4) ;
            AV19SdEmpresas = GXt_SdtSdEmpresas4;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SdEmpresas.gxTpr_Taxid)) )
            {
               AV20CompanyIsFound = (short)(Convert.ToInt16(true));
               AssignAttri("", false, "AV20CompanyIsFound", StringUtil.LTrimStr( (decimal)(AV20CompanyIsFound), 4, 0));
               /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
               S122 ();
               if (returnInSub) return;
               AV13EmpresaNome = StringUtil.Trim( AV19SdEmpresas.gxTpr_Company.gxTpr_Name);
               AssignAttri("", false, "AV13EmpresaNome", AV13EmpresaNome);
               AV14EmpresaEndereco = StringUtil.Format( "%1, %2 - %3/%4", StringUtil.Trim( AV19SdEmpresas.gxTpr_Address.gxTpr_Street), StringUtil.Trim( AV19SdEmpresas.gxTpr_Address.gxTpr_Number), StringUtil.Trim( AV19SdEmpresas.gxTpr_Address.gxTpr_City), StringUtil.Trim( AV19SdEmpresas.gxTpr_Address.gxTpr_State), "", "", "", "", "");
               AssignAttri("", false, "AV14EmpresaEndereco", AV14EmpresaEndereco);
               AV15EmpresaAtividadeEconomica = StringUtil.Trim( AV19SdEmpresas.gxTpr_Mainactivity.gxTpr_Text);
               AssignAttri("", false, "AV15EmpresaAtividadeEconomica", AV15EmpresaAtividadeEconomica);
            }
            else
            {
               /* Execute user subroutine: 'RESETDADOSEMPRESA' */
               S142 ();
               if (returnInSub) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'RESETDADOSEMPRESA' */
            S142 ();
            if (returnInSub) return;
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CNPJ Inválido. Verifique!",  "error",  edtavCnpj_Internalname,  "true",  ""));
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( AV29WWPContext.gxTpr_Isaprover && ( StringUtil.StrCmp(AV28ClienteSituacao, "P") == 0 ) ) )
         {
            bttBtnaprovar_representante_Visible = 0;
            AssignProp("", false, bttBtnaprovar_representante_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnaprovar_representante_Visible), 5, 0), true);
         }
      }

      protected void S162( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV25CheckRequiredFieldsResult = true;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6Nome)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome do Representante", "", "", "", "", "", "", "", ""),  "error",  edtavNome_Internalname,  "true",  ""));
            AV25CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8Email)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "E-mail", "", "", "", "", "", "", "", ""),  "error",  edtavEmail_Internalname,  "true",  ""));
            AV25CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9Celular)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Celular", "", "", "", "", "", "", "", ""),  "error",  edtavCelular_Internalname,  "true",  ""));
            AV25CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10CPF)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CPF", "", "", "", "", "", "", "", ""),  "error",  edtavCpf_Internalname,  "true",  ""));
            AV25CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5CNPJ)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CNPJ", "", "", "", "", "", "", "", ""),  "error",  edtavCnpj_Internalname,  "true",  ""));
            AV25CheckRequiredFieldsResult = false;
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( AV20CompanyIsFound == 1 ) ) )
         {
            grpUnnamedgroup2_Class = "Invisible";
            AssignProp("", false, grpUnnamedgroup2_Internalname, "Class", grpUnnamedgroup2_Class, true);
         }
         else
         {
            grpUnnamedgroup2_Class = "Group";
            AssignProp("", false, grpUnnamedgroup2_Internalname, "Class", grpUnnamedgroup2_Class, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E16992 ();
         if (returnInSub) return;
      }

      protected void E16992( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            /* Execute user subroutine: 'VALIDADADOS' */
            S152 ();
            if (returnInSub) return;
            if ( AV21IsValid )
            {
               AV22SdCadastroRepresentante = new SdtSdCadastroRepresentante(context);
               AV22SdCadastroRepresentante.gxTpr_Id = AV12ClienteId;
               AV22SdCadastroRepresentante.gxTpr_Nome = AV6Nome;
               AV22SdCadastroRepresentante.gxTpr_Cargo = AV7Cargo;
               AV22SdCadastroRepresentante.gxTpr_Celular = AV9Celular;
               AV22SdCadastroRepresentante.gxTpr_Cpf = AV10CPF;
               AV22SdCadastroRepresentante.gxTpr_Email = AV8Email;
               AV22SdCadastroRepresentante.gxTpr_Empresacnpj = AV5CNPJ;
               GXt_SdtSdErro2 = AV23SdErro;
               new prcadastrarrepresentante(context ).execute(  "UPD",  AV22SdCadastroRepresentante, out  GXt_SdtSdErro2) ;
               AV23SdErro = GXt_SdtSdErro2;
               if ( AV23SdErro.gxTpr_Status == 200 )
               {
                  context.setWebReturnParms(new Object[] {});
                  context.setWebReturnParmsMetadata(new Object[] {});
                  context.wjLocDisableFrm = 1;
                  context.nUserReturn = 1;
                  returnInSub = true;
                  if (true) return;
               }
               else
               {
                  GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Trim( AV23SdErro.gxTpr_Msg),  "error",  "",  "true",  ""));
               }
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E17992( )
      {
         /* Celular_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_char3 = AV9Celular;
         new prformatacelular(context ).execute(  AV9Celular, out  GXt_char3) ;
         AV9Celular = GXt_char3;
         AssignAttri("", false, "AV9Celular", AV9Celular);
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'RESETDADOSEMPRESA' Routine */
         returnInSub = false;
         AV20CompanyIsFound = (short)(Convert.ToInt16(false));
         AssignAttri("", false, "AV20CompanyIsFound", StringUtil.LTrimStr( (decimal)(AV20CompanyIsFound), 4, 0));
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         AV13EmpresaNome = "";
         AssignAttri("", false, "AV13EmpresaNome", AV13EmpresaNome);
         AV14EmpresaEndereco = "";
         AssignAttri("", false, "AV14EmpresaEndereco", AV14EmpresaEndereco);
         AV15EmpresaAtividadeEconomica = "";
         AssignAttri("", false, "AV15EmpresaAtividadeEconomica", AV15EmpresaAtividadeEconomica);
      }

      protected void S112( )
      {
         /* 'LOADDATA' Routine */
         returnInSub = false;
         AV11Cliente.Load(AV12ClienteId);
         AV6Nome = StringUtil.Trim( AV11Cliente.gxTpr_Responsavelnome);
         AssignAttri("", false, "AV6Nome", AV6Nome);
         AV8Email = StringUtil.Trim( AV11Cliente.gxTpr_Responsavelemail);
         AssignAttri("", false, "AV8Email", AV8Email);
         AV10CPF = StringUtil.Trim( AV11Cliente.gxTpr_Responsavelcpf);
         AssignAttri("", false, "AV10CPF", AV10CPF);
         AV9Celular = StringUtil.Trim( AV11Cliente.gxTpr_Responsavelcelular_f);
         AssignAttri("", false, "AV9Celular", AV9Celular);
         AV7Cargo = StringUtil.Trim( AV11Cliente.gxTpr_Responsavelcargo);
         AssignAttri("", false, "AV7Cargo", AV7Cargo);
         AV5CNPJ = StringUtil.Trim( AV11Cliente.gxTpr_Clientedocumento);
         AssignAttri("", false, "AV5CNPJ", AV5CNPJ);
         AV28ClienteSituacao = StringUtil.Trim( AV11Cliente.gxTpr_Clientesituacao);
         AssignAttri("", false, "AV28ClienteSituacao", AV28ClienteSituacao);
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTESITUACAO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28ClienteSituacao, "")), context));
      }

      protected void S152( )
      {
         /* 'VALIDADADOS' Routine */
         returnInSub = false;
         AV21IsValid = true;
         AssignAttri("", false, "AV21IsValid", AV21IsValid);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6Nome)) )
         {
            AV21IsValid = false;
            AssignAttri("", false, "AV21IsValid", AV21IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Nome do Representante é obrigatório!",  "error",  edtavNome_Internalname,  "true",  ""));
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8Email)) )
         {
            AV21IsValid = false;
            AssignAttri("", false, "AV21IsValid", AV21IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Email do Representante é obrigatório!",  "error",  edtavEmail_Internalname,  "true",  ""));
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9Celular)) )
         {
            AV21IsValid = false;
            AssignAttri("", false, "AV21IsValid", AV21IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Celular do Representante é obrigatório!",  "error",  edtavCelular_Internalname,  "true",  ""));
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10CPF)) )
         {
            AV21IsValid = false;
            AssignAttri("", false, "AV21IsValid", AV21IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CPF do Representante é obrigatório!",  "error",  edtavCpf_Internalname,  "true",  ""));
         }
         if ( ! new prvalidaemail(context).executeUdp(  AV8Email) )
         {
            AV21IsValid = false;
            AssignAttri("", false, "AV21IsValid", AV21IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Email do Representante inválido. Verifique!",  "error",  edtavEmail_Internalname,  "true",  ""));
         }
         new prvalidcpf(context ).execute(  "FISICA",  new prretornadigitos(context).executeUdp(  AV10CPF), out  AV24IsCPFValid, out  AV18ErrorMessage) ;
         if ( ! AV24IsCPFValid )
         {
            AV21IsValid = false;
            AssignAttri("", false, "AV21IsValid", AV21IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CPF do Representante inválido. Verifique!",  "error",  edtavCpf_Internalname,  "true",  ""));
         }
         if ( StringUtil.Len( new prretornadigitos(context).executeUdp(  AV9Celular)) < 10 )
         {
            AV21IsValid = false;
            AssignAttri("", false, "AV21IsValid", AV21IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Telefone inválido. Digite um celular no padrão (99)9999-9999 ou (99)99999-9999",  "error",  edtavCelular_Internalname,  "true",  ""));
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5CNPJ)) )
         {
            AV21IsValid = false;
            AssignAttri("", false, "AV21IsValid", AV21IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CNPJ da Empresa é obrigatório. Verifique!",  "error",  edtavCnpj_Internalname,  "true",  ""));
         }
         new prvalidcpf(context ).execute(  "JURIDICA",  new prretornadigitos(context).executeUdp(  AV5CNPJ), out  AV17IsCNPJValid, out  AV18ErrorMessage) ;
         if ( ! AV17IsCNPJValid )
         {
            AV21IsValid = false;
            AssignAttri("", false, "AV21IsValid", AV21IsValid);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CNPJ da Empresa inválido. Verifique!",  "error",  edtavCnpj_Internalname,  "true",  ""));
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E18992( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_91_992( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btnaprovar_representante_Internalname, tblTabledvelop_confirmpanel_btnaprovar_representante_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btnaprovar_representante.SetProperty("Title", Dvelop_confirmpanel_btnaprovar_representante_Title);
            ucDvelop_confirmpanel_btnaprovar_representante.SetProperty("ConfirmationText", Dvelop_confirmpanel_btnaprovar_representante_Confirmationtext);
            ucDvelop_confirmpanel_btnaprovar_representante.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btnaprovar_representante_Yesbuttoncaption);
            ucDvelop_confirmpanel_btnaprovar_representante.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btnaprovar_representante_Nobuttoncaption);
            ucDvelop_confirmpanel_btnaprovar_representante.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btnaprovar_representante_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btnaprovar_representante.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btnaprovar_representante_Yesbuttonposition);
            ucDvelop_confirmpanel_btnaprovar_representante.SetProperty("ConfirmType", Dvelop_confirmpanel_btnaprovar_representante_Confirmtype);
            ucDvelop_confirmpanel_btnaprovar_representante.SetProperty("Comment", Dvelop_confirmpanel_btnaprovar_representante_Comment);
            ucDvelop_confirmpanel_btnaprovar_representante.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btnaprovar_representante_Internalname, "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_91_992e( true) ;
         }
         else
         {
            wb_table1_91_992e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV12ClienteId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV12ClienteId", StringUtil.LTrimStr( (decimal)(AV12ClienteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12ClienteId), "ZZZZZZZZ9"), context));
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
         PA992( ) ;
         WS992( ) ;
         WE992( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101928240", true, true);
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
         context.AddJavascriptSource("wpconsultaeditarepresentante.js", "?20256101928241", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavCargo.Name = "vCARGO";
         cmbavCargo.WebTags = "";
         cmbavCargo.addItem("DIRETOR", "DIRETOR", 0);
         cmbavCargo.addItem("GERENTE", "GERENTE", 0);
         cmbavCargo.addItem("COORDENADOR", "COORDENADOR", 0);
         cmbavCargo.addItem("SUPERVISOR", "SUPERVISOR", 0);
         cmbavCargo.addItem("ANALISTA", "ANALISTA", 0);
         cmbavCargo.addItem("ASSISTENTE", "ASSISTENTE", 0);
         cmbavCargo.addItem("ESTAGIARIO", "ESTAGIARIO", 0);
         cmbavCargo.addItem("OUTRO", "OUTRO", 0);
         if ( cmbavCargo.ItemCount > 0 )
         {
            AV7Cargo = cmbavCargo.getValidValue(AV7Cargo);
            AssignAttri("", false, "AV7Cargo", AV7Cargo);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnaprovar_representante_Internalname = "BTNAPROVAR_REPRESENTANTE";
         lblTabrepresentante_title_Internalname = "TABREPRESENTANTE_TITLE";
         edtavNome_Internalname = "vNOME";
         cmbavCargo_Internalname = "vCARGO";
         edtavEmail_Internalname = "vEMAIL";
         edtavCelular_Internalname = "vCELULAR";
         edtavCpf_Internalname = "vCPF";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         lblTabempresa_title_Internalname = "TABEMPRESA_TITLE";
         edtavCnpj_Internalname = "vCNPJ";
         bttBtnuasearch_Internalname = "BTNUASEARCH";
         edtavEmpresanome_Internalname = "vEMPRESANOME";
         edtavEmpresaendereco_Internalname = "vEMPRESAENDERECO";
         edtavEmpresaatividadeeconomica_Internalname = "vEMPRESAATIVIDADEECONOMICA";
         divDadosempresa_Internalname = "DADOSEMPRESA";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         Dvelop_confirmpanel_btnaprovar_representante_Internalname = "DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE";
         tblTabledvelop_confirmpanel_btnaprovar_representante_Internalname = "TABLEDVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE";
         edtavDvelop_confirmpanel_btnaprovar_representante_comment_Internalname = "vDVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_COMMENT";
         divDiv_dvelop_confirmpanel_btnaprovar_representante_body_Internalname = "DIV_DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_BODY";
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
         edtavEmpresaatividadeeconomica_Jsonclick = "";
         edtavEmpresaatividadeeconomica_Enabled = 1;
         edtavEmpresaendereco_Jsonclick = "";
         edtavEmpresaendereco_Enabled = 1;
         edtavEmpresanome_Jsonclick = "";
         edtavEmpresanome_Enabled = 1;
         grpUnnamedgroup2_Class = "Group";
         edtavCnpj_Jsonclick = "";
         edtavCnpj_Enabled = 1;
         edtavCpf_Jsonclick = "";
         edtavCpf_Enabled = 1;
         edtavCelular_Jsonclick = "";
         edtavCelular_Enabled = 1;
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         cmbavCargo_Jsonclick = "";
         cmbavCargo.Enabled = 1;
         edtavNome_Jsonclick = "";
         edtavNome_Enabled = 1;
         bttBtnaprovar_representante_Visible = 1;
         Dvelop_confirmpanel_btnaprovar_representante_Comment = "Required";
         Dvelop_confirmpanel_btnaprovar_representante_Confirmtype = "1";
         Dvelop_confirmpanel_btnaprovar_representante_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btnaprovar_representante_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btnaprovar_representante_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btnaprovar_representante_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btnaprovar_representante_Confirmationtext = "Deixe um comentário da sua decisão para prosseguir.";
         Dvelop_confirmpanel_btnaprovar_representante_Title = "Aprovação";
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 2;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Representante";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV29WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV28ClienteSituacao","fld":"vCLIENTESITUACAO","hsh":true,"type":"char"},{"av":"AV11Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV12ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNAPROVAR_REPRESENTANTE","prop":"Visible"}]}""");
         setEventMetadata("'DOAPROVAR_REPRESENTANTE'","""{"handler":"E11991","iparms":[]""");
         setEventMetadata("'DOAPROVAR_REPRESENTANTE'",""","oparms":[{"av":"AV27DVelop_ConfirmPanel_BtnAprovar_Representante_Comment","fld":"vDVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE_COMMENT","type":"vchar"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE.CLOSE","""{"handler":"E12992","iparms":[{"av":"Dvelop_confirmpanel_btnaprovar_representante_Result","ctrl":"DVELOP_CONFIRMPANEL_BTNAPROVAR_REPRESENTANTE","prop":"Result"},{"av":"AV11Cliente","fld":"vCLIENTE","hsh":true,"type":""}]}""");
         setEventMetadata("'DOUASEARCH'","""{"handler":"E15992","iparms":[{"av":"AV5CNPJ","fld":"vCNPJ","type":"svchar"},{"av":"AV20CompanyIsFound","fld":"vCOMPANYISFOUND","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("'DOUASEARCH'",""","oparms":[{"av":"AV20CompanyIsFound","fld":"vCOMPANYISFOUND","pic":"ZZZ9","type":"int"},{"av":"AV13EmpresaNome","fld":"vEMPRESANOME","type":"svchar"},{"av":"AV14EmpresaEndereco","fld":"vEMPRESAENDERECO","type":"svchar"},{"av":"AV15EmpresaAtividadeEconomica","fld":"vEMPRESAATIVIDADEECONOMICA","type":"svchar"},{"av":"grpUnnamedgroup2_Class","ctrl":"UNNAMEDGROUP2","prop":"Class"}]}""");
         setEventMetadata("ENTER","""{"handler":"E16992","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV21IsValid","fld":"vISVALID","type":"boolean"},{"av":"AV12ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV6Nome","fld":"vNOME","type":"svchar"},{"av":"cmbavCargo"},{"av":"AV7Cargo","fld":"vCARGO","type":"svchar"},{"av":"AV9Celular","fld":"vCELULAR","type":"svchar"},{"av":"AV10CPF","fld":"vCPF","type":"svchar"},{"av":"AV8Email","fld":"vEMAIL","type":"svchar"},{"av":"AV5CNPJ","fld":"vCNPJ","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV21IsValid","fld":"vISVALID","type":"boolean"}]}""");
         setEventMetadata("VCELULAR.CONTROLVALUECHANGED","""{"handler":"E17992","iparms":[{"av":"AV9Celular","fld":"vCELULAR","type":"svchar"}]""");
         setEventMetadata("VCELULAR.CONTROLVALUECHANGED",""","oparms":[{"av":"AV9Celular","fld":"vCELULAR","type":"svchar"}]}""");
         setEventMetadata("VALIDV_CARGO","""{"handler":"Validv_Cargo","iparms":[]}""");
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
         wcpOGx_mode = "";
         Dvelop_confirmpanel_btnaprovar_representante_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV29WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28ClienteSituacao = "";
         AV11Cliente = new SdtCliente(context);
         Dvelop_confirmpanel_btnaprovar_representante_Bodycontentinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnaprovar_representante_Jsonclick = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblTabrepresentante_title_Jsonclick = "";
         AV6Nome = "";
         AV7Cargo = "";
         AV8Email = "";
         AV9Celular = "";
         AV10CPF = "";
         lblTabempresa_title_Jsonclick = "";
         AV5CNPJ = "";
         bttBtnuasearch_Jsonclick = "";
         AV13EmpresaNome = "";
         AV14EmpresaEndereco = "";
         AV15EmpresaAtividadeEconomica = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         AV27DVelop_ConfirmPanel_BtnAprovar_Representante_Comment = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         ucDvelop_confirmpanel_btnaprovar_representante = new GXUserControl();
         AV23SdErro = new SdtSdErro(context);
         AV16CNPJDigitos = "";
         AV18ErrorMessage = "";
         AV19SdEmpresas = new SdtSdEmpresas(context);
         GXt_SdtSdEmpresas4 = new SdtSdEmpresas(context);
         AV22SdCadastroRepresentante = new SdtSdCadastroRepresentante(context);
         GXt_SdtSdErro2 = new SdtSdErro(context);
         GXt_char3 = "";
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpconsultaeditarepresentante__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavEmpresanome_Enabled = 0;
         edtavEmpresaendereco_Enabled = 0;
         edtavEmpresaatividadeeconomica_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short AV20CompanyIsFound ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV12ClienteId ;
      private int wcpOAV12ClienteId ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int bttBtnaprovar_representante_Visible ;
      private int edtavNome_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavCelular_Enabled ;
      private int edtavCpf_Enabled ;
      private int edtavCnpj_Enabled ;
      private int edtavEmpresanome_Enabled ;
      private int edtavEmpresaendereco_Enabled ;
      private int edtavEmpresaatividadeeconomica_Enabled ;
      private int idxLst ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string Dvelop_confirmpanel_btnaprovar_representante_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV28ClienteSituacao ;
      private string Gxuitabspanel_tabs1_Class ;
      private string Dvelop_confirmpanel_btnaprovar_representante_Title ;
      private string Dvelop_confirmpanel_btnaprovar_representante_Confirmationtext ;
      private string Dvelop_confirmpanel_btnaprovar_representante_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btnaprovar_representante_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btnaprovar_representante_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btnaprovar_representante_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btnaprovar_representante_Confirmtype ;
      private string Dvelop_confirmpanel_btnaprovar_representante_Comment ;
      private string Dvelop_confirmpanel_btnaprovar_representante_Bodycontentinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string bttBtnaprovar_representante_Internalname ;
      private string bttBtnaprovar_representante_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblTabrepresentante_title_Internalname ;
      private string lblTabrepresentante_title_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string edtavNome_Internalname ;
      private string edtavNome_Jsonclick ;
      private string cmbavCargo_Internalname ;
      private string cmbavCargo_Jsonclick ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Jsonclick ;
      private string edtavCelular_Internalname ;
      private string edtavCelular_Jsonclick ;
      private string edtavCpf_Internalname ;
      private string edtavCpf_Jsonclick ;
      private string lblTabempresa_title_Internalname ;
      private string lblTabempresa_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string edtavCnpj_Internalname ;
      private string edtavCnpj_Jsonclick ;
      private string bttBtnuasearch_Internalname ;
      private string bttBtnuasearch_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string grpUnnamedgroup2_Class ;
      private string divDadosempresa_Internalname ;
      private string edtavEmpresanome_Internalname ;
      private string edtavEmpresanome_Jsonclick ;
      private string edtavEmpresaendereco_Internalname ;
      private string edtavEmpresaendereco_Jsonclick ;
      private string edtavEmpresaatividadeeconomica_Internalname ;
      private string edtavEmpresaatividadeeconomica_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_dvelop_confirmpanel_btnaprovar_representante_body_Internalname ;
      private string edtavDvelop_confirmpanel_btnaprovar_representante_comment_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Dvelop_confirmpanel_btnaprovar_representante_Internalname ;
      private string GXt_char3 ;
      private string sStyleString ;
      private string tblTabledvelop_confirmpanel_btnaprovar_representante_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV21IsValid ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV17IsCNPJValid ;
      private bool AV25CheckRequiredFieldsResult ;
      private bool AV24IsCPFValid ;
      private string AV27DVelop_ConfirmPanel_BtnAprovar_Representante_Comment ;
      private string AV6Nome ;
      private string AV7Cargo ;
      private string AV8Email ;
      private string AV9Celular ;
      private string AV10CPF ;
      private string AV5CNPJ ;
      private string AV13EmpresaNome ;
      private string AV14EmpresaEndereco ;
      private string AV15EmpresaAtividadeEconomica ;
      private string AV16CNPJDigitos ;
      private string AV18ErrorMessage ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucDvelop_confirmpanel_btnaprovar_representante ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCargo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV29WWPContext ;
      private SdtCliente AV11Cliente ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private SdtSdErro AV23SdErro ;
      private IDataStoreProvider pr_default ;
      private SdtSdEmpresas AV19SdEmpresas ;
      private SdtSdEmpresas GXt_SdtSdEmpresas4 ;
      private SdtSdCadastroRepresentante AV22SdCadastroRepresentante ;
      private SdtSdErro GXt_SdtSdErro2 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpconsultaeditarepresentante__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
