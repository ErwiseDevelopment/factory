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
   public class wprepresentante : GXDataArea
   {
      public wprepresentante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wprepresentante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           int aP1_RepresentanteId ,
                           int aP2_ClienteId )
      {
         this.AV12TrnMode = aP0_TrnMode;
         this.AV16RepresentanteId = aP1_RepresentanteId;
         this.AV26ClienteId = aP2_ClienteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavRepresentante_representantetipo = new GXCombobox();
         cmbavRepresentante_representanteestadocivil = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TrnMode");
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
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
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
         PA9O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9O2( ) ;
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormWithFixedActions\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wprepresentante"+UrlEncode(StringUtil.RTrim(AV12TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV16RepresentanteId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV26ClienteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("wprepresentante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormWithFixedActions", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPROFISSAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ProfissaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFISSAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22ProfissaoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV12TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vREPRESENTANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16RepresentanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREPRESENTANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16RepresentanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26ClienteId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Representante", AV5Representante);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Representante", AV5Representante);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vREPRESENTANTE_REPRESENTANTEPROFISSAO_DATA", AV6Representante_RepresentanteProfissao_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vREPRESENTANTE_REPRESENTANTEPROFISSAO_DATA", AV6Representante_RepresentanteProfissao_Data);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV12TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROFISSAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ProfissaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFISSAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22ProfissaoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROFISSAONOME", A441ProfissaoNome);
         GxWebStd.gx_hidden_field( context, "PROFISSAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A440ProfissaoId), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV14CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV11Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV11Messages);
         }
         GxWebStd.gx_hidden_field( context, "vREPRESENTANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16RepresentanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREPRESENTANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16RepresentanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26ClienteId), "ZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vREPRESENTANTE", AV5Representante);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vREPRESENTANTE", AV5Representante);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Cls", StringUtil.RTrim( Combo_representante_representanteprofissao_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Selectedvalue_set", StringUtil.RTrim( Combo_representante_representanteprofissao_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Enabled", StringUtil.BoolToStr( Combo_representante_representanteprofissao_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Emptyitem", StringUtil.BoolToStr( Combo_representante_representanteprofissao_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Includeaddnewoption", StringUtil.BoolToStr( Combo_representante_representanteprofissao_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Selectedvalue_get", StringUtil.RTrim( Combo_representante_representanteprofissao_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Selectedvalue_get", StringUtil.RTrim( Combo_representante_representanteprofissao_Selectedvalue_get));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormWithFixedActions" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE9O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9O2( ) ;
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
         GXEncryptionTmp = "wprepresentante"+UrlEncode(StringUtil.RTrim(AV12TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV16RepresentanteId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV26ClienteId,9,0));
         return formatLink("wprepresentante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpRepresentante" ;
      }

      public override string GetPgmdesc( )
      {
         return "Representante" ;
      }

      protected void WB9O0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction TableMainFixedActions", "start", "top", "", "", "div");
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
            ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavRepresentante_representantetipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRepresentante_representantetipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRepresentante_representantetipo, cmbavRepresentante_representantetipo_Internalname, StringUtil.RTrim( AV5Representante.gxTpr_Representantetipo), 1, cmbavRepresentante_representantetipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavRepresentante_representantetipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_WpRepresentante.htm");
            cmbavRepresentante_representantetipo.CurrentValue = StringUtil.RTrim( AV5Representante.gxTpr_Representantetipo);
            AssignProp("", false, cmbavRepresentante_representantetipo_Internalname, "Values", (string)(cmbavRepresentante_representantetipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representantenome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representantenome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representantenome_Internalname, AV5Representante.gxTpr_Representantenome, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representantenome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representantenome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representantenome_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representanterg_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representanterg_Internalname, "RG", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representanterg_Internalname, AV5Representante.gxTpr_Representanterg, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representanterg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representanterg_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representanterg_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representanteorgaoexpedidor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representanteorgaoexpedidor_Internalname, "Órgão expedidor", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representanteorgaoexpedidor_Internalname, AV5Representante.gxTpr_Representanteorgaoexpedidor, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representanteorgaoexpedidor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representanteorgaoexpedidor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representanteorgaoexpedidor_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representanterguf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representanterguf_Internalname, "UF do RG", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representanterguf_Internalname, AV5Representante.gxTpr_Representanterguf, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representanterguf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representanterguf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representanterguf_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representantecpf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representantecpf_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representantecpf_Internalname, AV5Representante.gxTpr_Representantecpf, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representantecpf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representantecpf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representantecpf_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavRepresentante_representanteestadocivil_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRepresentante_representanteestadocivil_Internalname, "Estado civil", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRepresentante_representanteestadocivil, cmbavRepresentante_representanteestadocivil_Internalname, StringUtil.RTrim( AV5Representante.gxTpr_Representanteestadocivil), 1, cmbavRepresentante_representanteestadocivil_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavRepresentante_representanteestadocivil.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_WpRepresentante.htm");
            cmbavRepresentante_representanteestadocivil.CurrentValue = StringUtil.RTrim( AV5Representante.gxTpr_Representanteestadocivil);
            AssignProp("", false, cmbavRepresentante_representanteestadocivil_Internalname, "Values", (string)(cmbavRepresentante_representanteestadocivil.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representantenacionalidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representantenacionalidade_Internalname, "Nacionalidade", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representantenacionalidade_Internalname, AV5Representante.gxTpr_Representantenacionalidade, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representantenacionalidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representantenacionalidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representantenacionalidade_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedrepresentante_representanteprofissao_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_representante_representanteprofissao_Internalname, "Profissao", "", "", lblTextblockcombo_representante_representanteprofissao_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_representante_representanteprofissao.SetProperty("Caption", Combo_representante_representanteprofissao_Caption);
            ucCombo_representante_representanteprofissao.SetProperty("Cls", Combo_representante_representanteprofissao_Cls);
            ucCombo_representante_representanteprofissao.SetProperty("EmptyItem", Combo_representante_representanteprofissao_Emptyitem);
            ucCombo_representante_representanteprofissao.SetProperty("IncludeAddNewOption", Combo_representante_representanteprofissao_Includeaddnewoption);
            ucCombo_representante_representanteprofissao.SetProperty("DropDownOptionsData", AV6Representante_RepresentanteProfissao_Data);
            ucCombo_representante_representanteprofissao.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_representante_representanteprofissao_Internalname, "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representanteemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representanteemail_Internalname, "Email", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representanteemail_Internalname, AV5Representante.gxTpr_Representanteemail, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representanteemail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representanteemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representanteemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representanteddd_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representanteddd_Internalname, "DDD", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representanteddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Representante.gxTpr_Representanteddd), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Representante.gxTpr_Representanteddd), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representanteddd_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representanteddd_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representantenumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representantenumero_Internalname, "Numero", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representantenumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Representante.gxTpr_Representantenumero), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Representante.gxTpr_Representantenumero), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representantenumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representantenumero_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Endereço", 1, 0, "px", 0, "px", "Group", "", "HLP_WpRepresentante.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEndereco_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representantecep_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representantecep_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representantecep_Internalname, AV5Representante.gxTpr_Representantecep, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representantecep, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representantecep_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representantecep_Enabled, 1, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representantelogradouro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representantelogradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representantelogradouro_Internalname, AV5Representante.gxTpr_Representantelogradouro, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representantelogradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representantelogradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representantelogradouro_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representantelogradouronumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representantelogradouronumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representantelogradouronumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Representante.gxTpr_Representantelogradouronumero), 10, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Representante.gxTpr_Representantelogradouronumero), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representantelogradouronumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representantelogradouronumero_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representantebairro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representantebairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representantebairro_Internalname, AV5Representante.gxTpr_Representantebairro, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representantebairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representantebairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representantebairro_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representantecidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representantecidade_Internalname, "Cidade", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representantecidade_Internalname, AV5Representante.gxTpr_Representantecidade, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representantecidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representantecidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representantecidade_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavRepresentante_representantecomplemento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRepresentante_representantecomplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representantecomplemento_Internalname, AV5Representante.gxTpr_Representantecomplemento, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representantecomplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representantecomplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavRepresentante_representantecomplemento_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMunicipionome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipionome_Internalname, "Municipio", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome_Internalname, AV23MunicipioNome, StringUtil.RTrim( context.localUtil.Format( AV23MunicipioNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMunicipionome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMunicipiouf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipiouf_Internalname, "UF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipiouf_Internalname, AV25MunicipioUF, StringUtil.RTrim( context.localUtil.Format( AV25MunicipioUF, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipiouf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMunicipiouf_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpRepresentante.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representanteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Representante.gxTpr_Representanteid), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Representante.gxTpr_Representanteid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representanteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavRepresentante_representanteid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpRepresentante.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_clienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Representante.gxTpr_Clienteid), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Representante.gxTpr_Clienteid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,130);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_clienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavRepresentante_clienteid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpRepresentante.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRepresentante_representantemunicipio_Internalname, AV5Representante.gxTpr_Representantemunicipio, StringUtil.RTrim( context.localUtil.Format( AV5Representante.gxTpr_Representantemunicipio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRepresentante_representantemunicipio_Jsonclick, 0, "Attribute", "", "", "", "", edtavRepresentante_representantemunicipio_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpRepresentante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START9O2( )
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
         STRUP9O0( ) ;
      }

      protected void WS9O2( )
      {
         START9O2( ) ;
         EVT9O2( ) ;
      }

      protected void EVT9O2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_representante_representanteprofissao.Onoptionclicked */
                              E119O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E129O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E139O2 ();
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
                                    E149O2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REPRESENTANTE_REPRESENTANTECEP.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Representante_representantecep.Controlvaluechanged */
                              E159O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E169O2 ();
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

      protected void WE9O2( )
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

      protected void PA9O2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wprepresentante")), "wprepresentante") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wprepresentante")))) ;
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
                  gxfirstwebparm = GetFirstPar( "TrnMode");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV12TrnMode = gxfirstwebparm;
                     AssignAttri("", false, "AV12TrnMode", AV12TrnMode);
                     GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV16RepresentanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "RepresentanteId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV16RepresentanteId", StringUtil.LTrimStr( (decimal)(AV16RepresentanteId), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vREPRESENTANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16RepresentanteId), "ZZZZZZZZ9"), context));
                        AV26ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV26ClienteId", StringUtil.LTrimStr( (decimal)(AV26ClienteId), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26ClienteId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = cmbavRepresentante_representantetipo_Internalname;
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
         if ( cmbavRepresentante_representantetipo.ItemCount > 0 )
         {
            AV5Representante.gxTpr_Representantetipo = cmbavRepresentante_representantetipo.getValidValue(AV5Representante.gxTpr_Representantetipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRepresentante_representantetipo.CurrentValue = StringUtil.RTrim( AV5Representante.gxTpr_Representantetipo);
            AssignProp("", false, cmbavRepresentante_representantetipo_Internalname, "Values", cmbavRepresentante_representantetipo.ToJavascriptSource(), true);
         }
         if ( cmbavRepresentante_representanteestadocivil.ItemCount > 0 )
         {
            AV5Representante.gxTpr_Representanteestadocivil = cmbavRepresentante_representanteestadocivil.getValidValue(AV5Representante.gxTpr_Representanteestadocivil);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRepresentante_representanteestadocivil.CurrentValue = StringUtil.RTrim( AV5Representante.gxTpr_Representanteestadocivil);
            AssignProp("", false, cmbavRepresentante_representanteestadocivil_Internalname, "Values", cmbavRepresentante_representanteestadocivil.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavMunicipionome_Enabled = 0;
         AssignProp("", false, edtavMunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipionome_Enabled), 5, 0), true);
         edtavMunicipiouf_Enabled = 0;
         AssignProp("", false, edtavMunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiouf_Enabled), 5, 0), true);
      }

      protected void RF9O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E139O2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E169O2 ();
            WB9O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes9O2( )
      {
         GxWebStd.gx_hidden_field( context, "vPROFISSAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ProfissaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFISSAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22ProfissaoId), "ZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         edtavMunicipionome_Enabled = 0;
         AssignProp("", false, edtavMunicipionome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipionome_Enabled), 5, 0), true);
         edtavMunicipiouf_Enabled = 0;
         AssignProp("", false, edtavMunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiouf_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E129O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vREPRESENTANTE"), AV5Representante);
            ajax_req_read_hidden_sdt(cgiGet( "Representante"), AV5Representante);
            ajax_req_read_hidden_sdt(cgiGet( "vREPRESENTANTE_REPRESENTANTEPROFISSAO_DATA"), AV6Representante_RepresentanteProfissao_Data);
            /* Read saved values. */
            Combo_representante_representanteprofissao_Cls = cgiGet( "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Cls");
            Combo_representante_representanteprofissao_Selectedvalue_set = cgiGet( "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Selectedvalue_set");
            Combo_representante_representanteprofissao_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Enabled"));
            Combo_representante_representanteprofissao_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Emptyitem"));
            Combo_representante_representanteprofissao_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Includeaddnewoption"));
            Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
            Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
            Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
            Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
            Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
            Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
            Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
            Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
            Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
            Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
            Combo_representante_representanteprofissao_Selectedvalue_get = cgiGet( "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO_Selectedvalue_get");
            /* Read variables values. */
            cmbavRepresentante_representantetipo.CurrentValue = cgiGet( cmbavRepresentante_representantetipo_Internalname);
            AV5Representante.gxTpr_Representantetipo = cgiGet( cmbavRepresentante_representantetipo_Internalname);
            AV5Representante.gxTpr_Representantenome = cgiGet( edtavRepresentante_representantenome_Internalname);
            AV5Representante.gxTpr_Representanterg = cgiGet( edtavRepresentante_representanterg_Internalname);
            AV5Representante.gxTpr_Representanteorgaoexpedidor = cgiGet( edtavRepresentante_representanteorgaoexpedidor_Internalname);
            AV5Representante.gxTpr_Representanterguf = cgiGet( edtavRepresentante_representanterguf_Internalname);
            AV5Representante.gxTpr_Representantecpf = cgiGet( edtavRepresentante_representantecpf_Internalname);
            cmbavRepresentante_representanteestadocivil.CurrentValue = cgiGet( cmbavRepresentante_representanteestadocivil_Internalname);
            AV5Representante.gxTpr_Representanteestadocivil = cgiGet( cmbavRepresentante_representanteestadocivil_Internalname);
            AV5Representante.gxTpr_Representantenacionalidade = cgiGet( edtavRepresentante_representantenacionalidade_Internalname);
            AV5Representante.gxTpr_Representanteemail = cgiGet( edtavRepresentante_representanteemail_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepresentante_representanteddd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepresentante_representanteddd_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPRESENTANTE_REPRESENTANTEDDD");
               GX_FocusControl = edtavRepresentante_representanteddd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Representante.gxTpr_Representanteddd = 0;
            }
            else
            {
               AV5Representante.gxTpr_Representanteddd = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavRepresentante_representanteddd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepresentante_representantenumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepresentante_representantenumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPRESENTANTE_REPRESENTANTENUMERO");
               GX_FocusControl = edtavRepresentante_representantenumero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Representante.gxTpr_Representantenumero = 0;
            }
            else
            {
               AV5Representante.gxTpr_Representantenumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavRepresentante_representantenumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV5Representante.gxTpr_Representantecep = cgiGet( edtavRepresentante_representantecep_Internalname);
            AV5Representante.gxTpr_Representantelogradouro = cgiGet( edtavRepresentante_representantelogradouro_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepresentante_representantelogradouronumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepresentante_representantelogradouronumero_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPRESENTANTE_REPRESENTANTELOGRADOURONUMERO");
               GX_FocusControl = edtavRepresentante_representantelogradouronumero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Representante.gxTpr_Representantelogradouronumero = 0;
            }
            else
            {
               AV5Representante.gxTpr_Representantelogradouronumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavRepresentante_representantelogradouronumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV5Representante.gxTpr_Representantebairro = cgiGet( edtavRepresentante_representantebairro_Internalname);
            AV5Representante.gxTpr_Representantecidade = cgiGet( edtavRepresentante_representantecidade_Internalname);
            AV5Representante.gxTpr_Representantecomplemento = cgiGet( edtavRepresentante_representantecomplemento_Internalname);
            AV23MunicipioNome = StringUtil.Upper( cgiGet( edtavMunicipionome_Internalname));
            AssignAttri("", false, "AV23MunicipioNome", AV23MunicipioNome);
            AV25MunicipioUF = StringUtil.Upper( cgiGet( edtavMunicipiouf_Internalname));
            AssignAttri("", false, "AV25MunicipioUF", AV25MunicipioUF);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepresentante_representanteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepresentante_representanteid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPRESENTANTE_REPRESENTANTEID");
               GX_FocusControl = edtavRepresentante_representanteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Representante.gxTpr_Representanteid = 0;
            }
            else
            {
               AV5Representante.gxTpr_Representanteid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavRepresentante_representanteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRepresentante_clienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRepresentante_clienteid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPRESENTANTE_CLIENTEID");
               GX_FocusControl = edtavRepresentante_clienteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Representante.gxTpr_Clienteid = 0;
            }
            else
            {
               AV5Representante.gxTpr_Clienteid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavRepresentante_clienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV5Representante.gxTpr_Representantemunicipio = cgiGet( edtavRepresentante_representantemunicipio_Internalname);
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
         E129O2 ();
         if (returnInSub) return;
      }

      protected void E129O2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV13LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV12TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV12TrnMode, "INS") == 0 ) ) || ( ( StringUtil.StrCmp(AV12TrnMode, "UPD") == 0 ) ) || ( ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 ) ) )
         {
            if ( StringUtil.StrCmp(AV12TrnMode, "INS") != 0 )
            {
               AV5Representante.Load(AV16RepresentanteId);
               AV13LoadSuccess = AV5Representante.Success();
               if ( ! AV13LoadSuccess )
               {
                  AV11Messages = AV5Representante.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV12TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 ) )
               {
                  cmbavRepresentante_representantetipo.Enabled = 0;
                  AssignProp("", false, cmbavRepresentante_representantetipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavRepresentante_representantetipo.Enabled), 5, 0), true);
                  edtavRepresentante_representantenome_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representantenome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantenome_Enabled), 5, 0), true);
                  edtavRepresentante_representanterg_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representanterg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representanterg_Enabled), 5, 0), true);
                  edtavRepresentante_representanteorgaoexpedidor_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representanteorgaoexpedidor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representanteorgaoexpedidor_Enabled), 5, 0), true);
                  edtavRepresentante_representanterguf_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representanterguf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representanterguf_Enabled), 5, 0), true);
                  edtavRepresentante_representantecpf_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representantecpf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantecpf_Enabled), 5, 0), true);
                  cmbavRepresentante_representanteestadocivil.Enabled = 0;
                  AssignProp("", false, cmbavRepresentante_representanteestadocivil_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavRepresentante_representanteestadocivil.Enabled), 5, 0), true);
                  edtavRepresentante_representantenacionalidade_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representantenacionalidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantenacionalidade_Enabled), 5, 0), true);
                  Combo_representante_representanteprofissao_Enabled = false;
                  ucCombo_representante_representanteprofissao.SendProperty(context, "", false, Combo_representante_representanteprofissao_Internalname, "Enabled", StringUtil.BoolToStr( Combo_representante_representanteprofissao_Enabled));
                  edtavRepresentante_representanteemail_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representanteemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representanteemail_Enabled), 5, 0), true);
                  edtavRepresentante_representanteddd_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representanteddd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representanteddd_Enabled), 5, 0), true);
                  edtavRepresentante_representantenumero_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representantenumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantenumero_Enabled), 5, 0), true);
                  edtavRepresentante_representantecep_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representantecep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantecep_Enabled), 5, 0), true);
                  edtavRepresentante_representantelogradouro_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representantelogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantelogradouro_Enabled), 5, 0), true);
                  edtavRepresentante_representantelogradouronumero_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representantelogradouronumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantelogradouronumero_Enabled), 5, 0), true);
                  edtavRepresentante_representantebairro_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representantebairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantebairro_Enabled), 5, 0), true);
                  edtavRepresentante_representantecidade_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representantecidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantecidade_Enabled), 5, 0), true);
                  edtavRepresentante_representantecomplemento_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representantecomplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantecomplemento_Enabled), 5, 0), true);
               }
            }
         }
         else
         {
            AV13LoadSuccess = false;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( AV13LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem("Confirme a eliminação dos dados.");
            }
         }
         /* Execute user subroutine: 'LOADCOMBOREPRESENTANTE_REPRESENTANTEPROFISSAO' */
         S122 ();
         if (returnInSub) return;
         edtavRepresentante_representanteid_Visible = 0;
         AssignProp("", false, edtavRepresentante_representanteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representanteid_Visible), 5, 0), true);
         edtavRepresentante_clienteid_Visible = 0;
         AssignProp("", false, edtavRepresentante_clienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentante_clienteid_Visible), 5, 0), true);
         edtavRepresentante_representantemunicipio_Visible = 0;
         AssignProp("", false, edtavRepresentante_representantemunicipio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantemunicipio_Visible), 5, 0), true);
         AV5Representante.gxTpr_Clienteid = AV26ClienteId;
         if ( StringUtil.StrCmp(AV12TrnMode, "UPD") == 0 )
         {
            AV23MunicipioNome = AV5Representante.gxTpr_Representantemunicipionome;
            AssignAttri("", false, "AV23MunicipioNome", AV23MunicipioNome);
            AV25MunicipioUF = AV5Representante.gxTpr_Representantemunicipiouf;
            AssignAttri("", false, "AV25MunicipioUF", AV25MunicipioUF);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5Representante.gxTpr_Representantecep)) )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5Representante.gxTpr_Representantebairro)) )
               {
                  edtavRepresentante_representantebairro_Enabled = 0;
                  AssignProp("", false, edtavRepresentante_representantebairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantebairro_Enabled), 5, 0), true);
               }
               edtavRepresentante_representantecidade_Enabled = 0;
               AssignProp("", false, edtavRepresentante_representantecidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantecidade_Enabled), 5, 0), true);
               edtavRepresentante_representantelogradouro_Enabled = 0;
               AssignProp("", false, edtavRepresentante_representantelogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantelogradouro_Enabled), 5, 0), true);
            }
         }
      }

      protected void E139O2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E119O2( )
      {
         /* Combo_representante_representanteprofissao_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_representante_representanteprofissao_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "profissao"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            context.PopUp(formatLink("profissao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_representante_representanteprofissao_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOREPRESENTANTE_REPRESENTANTEPROFISSAO' */
            S122 ();
            if (returnInSub) return;
            AV8ComboSelectedValue = AV9Session.Get("PROFISSAOID");
            AV9Session.Remove("PROFISSAOID");
            Combo_representante_representanteprofissao_Selectedvalue_set = AV8ComboSelectedValue;
            ucCombo_representante_representanteprofissao.SendProperty(context, "", false, Combo_representante_representanteprofissao_Internalname, "SelectedValue_set", Combo_representante_representanteprofissao_Selectedvalue_set);
            AV5Representante.gxTpr_Representanteprofissao = (int)(Math.Round(NumberUtil.Val( AV8ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         }
         else
         {
            AV5Representante.gxTpr_Representanteprofissao = (int)(Math.Round(NumberUtil.Val( Combo_representante_representanteprofissao_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            /* Execute user subroutine: 'LOADCOMBOREPRESENTANTE_REPRESENTANTEPROFISSAO' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Representante", AV5Representante);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6Representante_RepresentanteProfissao_Data", AV6Representante_RepresentanteProfissao_Data);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E149O2 ();
         if (returnInSub) return;
      }

      protected void E149O2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV12TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV12TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S142 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 ) || AV14CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 )
               {
                  AV5Representante.Delete();
               }
               else
               {
                  AV5Representante.Save();
               }
               if ( AV5Representante.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S152 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV11Messages = AV5Representante.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Representante", AV5Representante);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11Messages", AV11Messages);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV12TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOREPRESENTANTE_REPRESENTANTEPROFISSAO' Routine */
         returnInSub = false;
         AV6Representante_RepresentanteProfissao_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H009O2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A440ProfissaoId = H009O2_A440ProfissaoId[0];
            A441ProfissaoNome = H009O2_A441ProfissaoNome[0];
            n441ProfissaoNome = H009O2_n441ProfissaoNome[0];
            AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV7Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A440ProfissaoId), 9, 0));
            AV7Combo_DataItem.gxTpr_Title = A441ProfissaoNome;
            AV6Representante_RepresentanteProfissao_Data.Add(AV7Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_representante_representanteprofissao_Selectedvalue_set = ((0==AV5Representante.gxTpr_Representanteprofissao) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5Representante.gxTpr_Representanteprofissao), 9, 0)));
         ucCombo_representante_representanteprofissao.SendProperty(context, "", false, Combo_representante_representanteprofissao_Internalname, "SelectedValue_set", Combo_representante_representanteprofissao_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV48GXV21 = 1;
         while ( AV48GXV21 <= AV11Messages.Count )
         {
            AV10Message = ((GeneXus.Utils.SdtMessages_Message)AV11Messages.Item(AV48GXV21));
            GX_msglist.addItem(AV10Message.gxTpr_Description);
            AV48GXV21 = (int)(AV48GXV21+1);
         }
      }

      protected void S152( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("wprepresentante",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV14CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
      }

      protected void E159O2( )
      {
         /* Representante_representantecep_Controlvaluechanged Routine */
         returnInSub = false;
         AV5Representante.gxTpr_Representantemunicipionome = "";
         AV5Representante.gxTpr_Representantemunicipiouf = "";
         AV17CEP = AV5Representante.gxTpr_Representantecep;
         AV17CEP = StringUtil.StringReplace( AV17CEP, "-", "");
         AV17CEP = StringUtil.StringReplace( AV17CEP, ".", "");
         AV18EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17CEP)) )
         {
            new GeneXus.Programs.myobjects.viacep.cepparaendereco(context ).execute(  AV17CEP, out  AV19ModeloRetorno, out  AV20Mensagem) ;
            AV18EnderecoCompleto.FromJSonString(AV19ModeloRetorno, null);
         }
         AV5Representante.gxTpr_Representantebairro = AV18EnderecoCompleto.gxTpr_Bairro;
         AV5Representante.gxTpr_Representantecidade = AV18EnderecoCompleto.gxTpr_Localidade;
         AV5Representante.gxTpr_Representantelogradouro = AV18EnderecoCompleto.gxTpr_Logradouro;
         AV5Representante.gxTpr_Representantemunicipio = AV18EnderecoCompleto.gxTpr_Ibge;
         AV23MunicipioNome = AV18EnderecoCompleto.gxTpr_Localidade;
         AssignAttri("", false, "AV23MunicipioNome", AV23MunicipioNome);
         AV25MunicipioUF = AV18EnderecoCompleto.gxTpr_Uf;
         AssignAttri("", false, "AV25MunicipioUF", AV25MunicipioUF);
         AV21Municipio.Load(AV5Representante.gxTpr_Representantemunicipio);
         if ( AV21Municipio.Fail() )
         {
            AV21Municipio.gxTpr_Municipionome = AV18EnderecoCompleto.gxTpr_Localidade;
            AV21Municipio.gxTpr_Municipiouf = AV18EnderecoCompleto.gxTpr_Uf;
            AV21Municipio.Save();
            if ( AV21Municipio.Success() )
            {
               context.CommitDataStores("wprepresentante",pr_default);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5Representante.gxTpr_Representantebairro)) )
         {
            edtavRepresentante_representantebairro_Enabled = 0;
            AssignProp("", false, edtavRepresentante_representantebairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantebairro_Enabled), 5, 0), true);
         }
         edtavRepresentante_representantecidade_Enabled = 0;
         AssignProp("", false, edtavRepresentante_representantecidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantecidade_Enabled), 5, 0), true);
         edtavRepresentante_representantelogradouro_Enabled = 0;
         AssignProp("", false, edtavRepresentante_representantelogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRepresentante_representantelogradouro_Enabled), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5Representante", AV5Representante);
      }

      protected void nextLoad( )
      {
      }

      protected void E169O2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV12TrnMode", AV12TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
         AV16RepresentanteId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV16RepresentanteId", StringUtil.LTrimStr( (decimal)(AV16RepresentanteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vREPRESENTANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16RepresentanteId), "ZZZZZZZZ9"), context));
         AV26ClienteId = Convert.ToInt32(getParm(obj,2));
         AssignAttri("", false, "AV26ClienteId", StringUtil.LTrimStr( (decimal)(AV26ClienteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26ClienteId), "ZZZZZZZZ9"), context));
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
         PA9O2( ) ;
         WS9O2( ) ;
         WE9O2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019284175", true, true);
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
         context.AddJavascriptSource("wprepresentante.js", "?202561019284176", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavRepresentante_representantetipo.Name = "REPRESENTANTE_REPRESENTANTETIPO";
         cmbavRepresentante_representantetipo.WebTags = "";
         cmbavRepresentante_representantetipo.addItem("Representante", "Representante", 0);
         cmbavRepresentante_representantetipo.addItem("Responsavel_solidario", "Responsável Solidário", 0);
         if ( cmbavRepresentante_representantetipo.ItemCount > 0 )
         {
            AV5Representante.gxTpr_Representantetipo = cmbavRepresentante_representantetipo.getValidValue(AV5Representante.gxTpr_Representantetipo);
         }
         cmbavRepresentante_representanteestadocivil.Name = "REPRESENTANTE_REPRESENTANTEESTADOCIVIL";
         cmbavRepresentante_representanteestadocivil.WebTags = "";
         cmbavRepresentante_representanteestadocivil.addItem("SOLTEIRO", "Solteiro(a)", 0);
         cmbavRepresentante_representanteestadocivil.addItem("CASADO", "Casado(a)", 0);
         cmbavRepresentante_representanteestadocivil.addItem("DIVORCIADO", "Divorciado(a)", 0);
         cmbavRepresentante_representanteestadocivil.addItem("VIUVO", "Viúvo(a)", 0);
         cmbavRepresentante_representanteestadocivil.addItem("SEPARADO", "Separado(a)", 0);
         cmbavRepresentante_representanteestadocivil.addItem("UNIAO_ESTAVEL", "União Estável", 0);
         if ( cmbavRepresentante_representanteestadocivil.ItemCount > 0 )
         {
            AV5Representante.gxTpr_Representanteestadocivil = cmbavRepresentante_representanteestadocivil.getValidValue(AV5Representante.gxTpr_Representanteestadocivil);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavRepresentante_representantetipo_Internalname = "REPRESENTANTE_REPRESENTANTETIPO";
         edtavRepresentante_representantenome_Internalname = "REPRESENTANTE_REPRESENTANTENOME";
         edtavRepresentante_representanterg_Internalname = "REPRESENTANTE_REPRESENTANTERG";
         edtavRepresentante_representanteorgaoexpedidor_Internalname = "REPRESENTANTE_REPRESENTANTEORGAOEXPEDIDOR";
         edtavRepresentante_representanterguf_Internalname = "REPRESENTANTE_REPRESENTANTERGUF";
         edtavRepresentante_representantecpf_Internalname = "REPRESENTANTE_REPRESENTANTECPF";
         cmbavRepresentante_representanteestadocivil_Internalname = "REPRESENTANTE_REPRESENTANTEESTADOCIVIL";
         edtavRepresentante_representantenacionalidade_Internalname = "REPRESENTANTE_REPRESENTANTENACIONALIDADE";
         lblTextblockcombo_representante_representanteprofissao_Internalname = "TEXTBLOCKCOMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO";
         Combo_representante_representanteprofissao_Internalname = "COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO";
         divTablesplittedrepresentante_representanteprofissao_Internalname = "TABLESPLITTEDREPRESENTANTE_REPRESENTANTEPROFISSAO";
         edtavRepresentante_representanteemail_Internalname = "REPRESENTANTE_REPRESENTANTEEMAIL";
         edtavRepresentante_representanteddd_Internalname = "REPRESENTANTE_REPRESENTANTEDDD";
         edtavRepresentante_representantenumero_Internalname = "REPRESENTANTE_REPRESENTANTENUMERO";
         edtavRepresentante_representantecep_Internalname = "REPRESENTANTE_REPRESENTANTECEP";
         edtavRepresentante_representantelogradouro_Internalname = "REPRESENTANTE_REPRESENTANTELOGRADOURO";
         edtavRepresentante_representantelogradouronumero_Internalname = "REPRESENTANTE_REPRESENTANTELOGRADOURONUMERO";
         edtavRepresentante_representantebairro_Internalname = "REPRESENTANTE_REPRESENTANTEBAIRRO";
         edtavRepresentante_representantecidade_Internalname = "REPRESENTANTE_REPRESENTANTECIDADE";
         edtavRepresentante_representantecomplemento_Internalname = "REPRESENTANTE_REPRESENTANTECOMPLEMENTO";
         edtavMunicipionome_Internalname = "vMUNICIPIONOME";
         edtavMunicipiouf_Internalname = "vMUNICIPIOUF";
         divEndereco_Internalname = "ENDERECO";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavRepresentante_representanteid_Internalname = "REPRESENTANTE_REPRESENTANTEID";
         edtavRepresentante_clienteid_Internalname = "REPRESENTANTE_CLIENTEID";
         edtavRepresentante_representantemunicipio_Internalname = "REPRESENTANTE_REPRESENTANTEMUNICIPIO";
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
         edtavRepresentante_representantecomplemento_Enabled = 1;
         edtavRepresentante_representantecidade_Enabled = 1;
         edtavRepresentante_representantebairro_Enabled = 1;
         edtavRepresentante_representantelogradouronumero_Enabled = 1;
         edtavRepresentante_representantelogradouro_Enabled = 1;
         edtavRepresentante_representantecep_Enabled = 1;
         edtavRepresentante_representantenumero_Enabled = 1;
         edtavRepresentante_representanteddd_Enabled = 1;
         edtavRepresentante_representanteemail_Enabled = 1;
         edtavRepresentante_representantenacionalidade_Enabled = 1;
         cmbavRepresentante_representanteestadocivil.Enabled = 1;
         edtavRepresentante_representantecpf_Enabled = 1;
         edtavRepresentante_representanterguf_Enabled = 1;
         edtavRepresentante_representanteorgaoexpedidor_Enabled = 1;
         edtavRepresentante_representanterg_Enabled = 1;
         edtavRepresentante_representantenome_Enabled = 1;
         cmbavRepresentante_representantetipo.Enabled = 1;
         edtavRepresentante_representantemunicipio_Jsonclick = "";
         edtavRepresentante_representantemunicipio_Visible = 1;
         edtavRepresentante_clienteid_Jsonclick = "";
         edtavRepresentante_clienteid_Visible = 1;
         edtavRepresentante_representanteid_Jsonclick = "";
         edtavRepresentante_representanteid_Visible = 1;
         bttBtnenter_Visible = 1;
         edtavMunicipiouf_Jsonclick = "";
         edtavMunicipiouf_Enabled = 1;
         edtavMunicipionome_Jsonclick = "";
         edtavMunicipionome_Enabled = 1;
         edtavRepresentante_representantecomplemento_Jsonclick = "";
         edtavRepresentante_representantecomplemento_Enabled = 1;
         edtavRepresentante_representantecidade_Jsonclick = "";
         edtavRepresentante_representantecidade_Enabled = 1;
         edtavRepresentante_representantebairro_Jsonclick = "";
         edtavRepresentante_representantebairro_Enabled = 1;
         edtavRepresentante_representantelogradouronumero_Jsonclick = "";
         edtavRepresentante_representantelogradouronumero_Enabled = 1;
         edtavRepresentante_representantelogradouro_Jsonclick = "";
         edtavRepresentante_representantelogradouro_Enabled = 1;
         edtavRepresentante_representantecep_Jsonclick = "";
         edtavRepresentante_representantecep_Enabled = 1;
         edtavRepresentante_representantenumero_Jsonclick = "";
         edtavRepresentante_representantenumero_Enabled = 1;
         edtavRepresentante_representanteddd_Jsonclick = "";
         edtavRepresentante_representanteddd_Enabled = 1;
         edtavRepresentante_representanteemail_Jsonclick = "";
         edtavRepresentante_representanteemail_Enabled = 1;
         edtavRepresentante_representantenacionalidade_Jsonclick = "";
         edtavRepresentante_representantenacionalidade_Enabled = 1;
         cmbavRepresentante_representanteestadocivil_Jsonclick = "";
         cmbavRepresentante_representanteestadocivil.Enabled = 1;
         edtavRepresentante_representantecpf_Jsonclick = "";
         edtavRepresentante_representantecpf_Enabled = 1;
         edtavRepresentante_representanterguf_Jsonclick = "";
         edtavRepresentante_representanterguf_Enabled = 1;
         edtavRepresentante_representanteorgaoexpedidor_Jsonclick = "";
         edtavRepresentante_representanteorgaoexpedidor_Enabled = 1;
         edtavRepresentante_representanterg_Jsonclick = "";
         edtavRepresentante_representanterg_Enabled = 1;
         edtavRepresentante_representantenome_Jsonclick = "";
         edtavRepresentante_representantenome_Enabled = 1;
         cmbavRepresentante_representantetipo_Jsonclick = "";
         cmbavRepresentante_representantetipo.Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         Combo_representante_representanteprofissao_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_representante_representanteprofissao_Emptyitem = Convert.ToBoolean( 0);
         Combo_representante_representanteprofissao_Enabled = Convert.ToBoolean( -1);
         Combo_representante_representanteprofissao_Cls = "ExtendedCombo AttributeFL";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV12TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"},{"av":"AV22ProfissaoId","fld":"vPROFISSAOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV16RepresentanteId","fld":"vREPRESENTANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV26ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO.ONOPTIONCLICKED","""{"handler":"E119O2","iparms":[{"av":"Combo_representante_representanteprofissao_Selectedvalue_get","ctrl":"COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO","prop":"SelectedValue_get"},{"av":"AV22ProfissaoId","fld":"vPROFISSAOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV5Representante","fld":"vREPRESENTANTE","type":""},{"av":"A441ProfissaoNome","fld":"PROFISSAONOME","pic":"@!","type":"svchar"},{"av":"A440ProfissaoId","fld":"PROFISSAOID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_representante_representanteprofissao_Selectedvalue_set","ctrl":"COMBO_REPRESENTANTE_REPRESENTANTEPROFISSAO","prop":"SelectedValue_set"},{"av":"AV5Representante","fld":"vREPRESENTANTE","type":""},{"av":"AV6Representante_RepresentanteProfissao_Data","fld":"vREPRESENTANTE_REPRESENTANTEPROFISSAO_DATA","type":""}]}""");
         setEventMetadata("ENTER","""{"handler":"E149O2","iparms":[{"av":"AV12TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"},{"av":"AV14CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV5Representante","fld":"vREPRESENTANTE","type":""},{"av":"AV11Messages","fld":"vMESSAGES","type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5Representante","fld":"vREPRESENTANTE","type":""},{"av":"AV11Messages","fld":"vMESSAGES","type":""},{"av":"AV14CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("REPRESENTANTE_REPRESENTANTECEP.CONTROLVALUECHANGED","""{"handler":"E159O2","iparms":[{"av":"AV5Representante","fld":"vREPRESENTANTE","type":""}]""");
         setEventMetadata("REPRESENTANTE_REPRESENTANTECEP.CONTROLVALUECHANGED",""","oparms":[{"av":"AV5Representante","fld":"vREPRESENTANTE","type":""},{"av":"AV23MunicipioNome","fld":"vMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV25MunicipioUF","fld":"vMUNICIPIOUF","pic":"@!","type":"svchar"},{"ctrl":"REPRESENTANTE_REPRESENTANTEBAIRRO","prop":"Enabled"},{"ctrl":"REPRESENTANTE_REPRESENTANTECIDADE","prop":"Enabled"},{"ctrl":"REPRESENTANTE_REPRESENTANTELOGRADOURO","prop":"Enabled"}]}""");
         setEventMetadata("VALIDV_GXV1","""{"handler":"Validv_Gxv1","iparms":[]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("VALIDV_GXV9","""{"handler":"Validv_Gxv9","iparms":[]}""");
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
         wcpOAV12TrnMode = "";
         Combo_representante_representanteprofissao_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5Representante = new SdtRepresentante(context);
         AV6Representante_RepresentanteProfissao_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A441ProfissaoNome = "";
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Combo_representante_representanteprofissao_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblockcombo_representante_representanteprofissao_Jsonclick = "";
         ucCombo_representante_representanteprofissao = new GXUserControl();
         Combo_representante_representanteprofissao_Caption = "";
         AV23MunicipioNome = "";
         AV25MunicipioUF = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV8ComboSelectedValue = "";
         AV9Session = context.GetSession();
         H009O2_A440ProfissaoId = new int[1] ;
         H009O2_A441ProfissaoNome = new string[] {""} ;
         H009O2_n441ProfissaoNome = new bool[] {false} ;
         AV7Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV17CEP = "";
         AV18EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         AV19ModeloRetorno = "";
         AV20Mensagem = "";
         AV21Municipio = new SdtMunicipio(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wprepresentante__default(),
            new Object[][] {
                new Object[] {
               H009O2_A440ProfissaoId, H009O2_A441ProfissaoNome, H009O2_n441ProfissaoNome
               }
            }
         );
         /* GeneXus formulas. */
         edtavMunicipionome_Enabled = 0;
         edtavMunicipiouf_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV16RepresentanteId ;
      private int AV26ClienteId ;
      private int wcpOAV16RepresentanteId ;
      private int wcpOAV26ClienteId ;
      private int AV22ProfissaoId ;
      private int A440ProfissaoId ;
      private int edtavRepresentante_representantenome_Enabled ;
      private int edtavRepresentante_representanterg_Enabled ;
      private int edtavRepresentante_representanteorgaoexpedidor_Enabled ;
      private int edtavRepresentante_representanterguf_Enabled ;
      private int edtavRepresentante_representantecpf_Enabled ;
      private int edtavRepresentante_representantenacionalidade_Enabled ;
      private int edtavRepresentante_representanteemail_Enabled ;
      private int edtavRepresentante_representanteddd_Enabled ;
      private int edtavRepresentante_representantenumero_Enabled ;
      private int edtavRepresentante_representantecep_Enabled ;
      private int edtavRepresentante_representantelogradouro_Enabled ;
      private int edtavRepresentante_representantelogradouronumero_Enabled ;
      private int edtavRepresentante_representantebairro_Enabled ;
      private int edtavRepresentante_representantecidade_Enabled ;
      private int edtavRepresentante_representantecomplemento_Enabled ;
      private int edtavMunicipionome_Enabled ;
      private int edtavMunicipiouf_Enabled ;
      private int bttBtnenter_Visible ;
      private int edtavRepresentante_representanteid_Visible ;
      private int edtavRepresentante_clienteid_Visible ;
      private int edtavRepresentante_representantemunicipio_Visible ;
      private int AV48GXV21 ;
      private int idxLst ;
      private string AV12TrnMode ;
      private string wcpOAV12TrnMode ;
      private string Combo_representante_representanteprofissao_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_representante_representanteprofissao_Cls ;
      private string Combo_representante_representanteprofissao_Selectedvalue_set ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string cmbavRepresentante_representantetipo_Internalname ;
      private string TempTags ;
      private string cmbavRepresentante_representantetipo_Jsonclick ;
      private string edtavRepresentante_representantenome_Internalname ;
      private string edtavRepresentante_representantenome_Jsonclick ;
      private string edtavRepresentante_representanterg_Internalname ;
      private string edtavRepresentante_representanterg_Jsonclick ;
      private string edtavRepresentante_representanteorgaoexpedidor_Internalname ;
      private string edtavRepresentante_representanteorgaoexpedidor_Jsonclick ;
      private string edtavRepresentante_representanterguf_Internalname ;
      private string edtavRepresentante_representanterguf_Jsonclick ;
      private string edtavRepresentante_representantecpf_Internalname ;
      private string edtavRepresentante_representantecpf_Jsonclick ;
      private string cmbavRepresentante_representanteestadocivil_Internalname ;
      private string cmbavRepresentante_representanteestadocivil_Jsonclick ;
      private string edtavRepresentante_representantenacionalidade_Internalname ;
      private string edtavRepresentante_representantenacionalidade_Jsonclick ;
      private string divTablesplittedrepresentante_representanteprofissao_Internalname ;
      private string lblTextblockcombo_representante_representanteprofissao_Internalname ;
      private string lblTextblockcombo_representante_representanteprofissao_Jsonclick ;
      private string Combo_representante_representanteprofissao_Caption ;
      private string Combo_representante_representanteprofissao_Internalname ;
      private string edtavRepresentante_representanteemail_Internalname ;
      private string edtavRepresentante_representanteemail_Jsonclick ;
      private string edtavRepresentante_representanteddd_Internalname ;
      private string edtavRepresentante_representanteddd_Jsonclick ;
      private string edtavRepresentante_representantenumero_Internalname ;
      private string edtavRepresentante_representantenumero_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divEndereco_Internalname ;
      private string edtavRepresentante_representantecep_Internalname ;
      private string edtavRepresentante_representantecep_Jsonclick ;
      private string edtavRepresentante_representantelogradouro_Internalname ;
      private string edtavRepresentante_representantelogradouro_Jsonclick ;
      private string edtavRepresentante_representantelogradouronumero_Internalname ;
      private string edtavRepresentante_representantelogradouronumero_Jsonclick ;
      private string edtavRepresentante_representantebairro_Internalname ;
      private string edtavRepresentante_representantebairro_Jsonclick ;
      private string edtavRepresentante_representantecidade_Internalname ;
      private string edtavRepresentante_representantecidade_Jsonclick ;
      private string edtavRepresentante_representantecomplemento_Internalname ;
      private string edtavRepresentante_representantecomplemento_Jsonclick ;
      private string edtavMunicipionome_Internalname ;
      private string edtavMunicipionome_Jsonclick ;
      private string edtavMunicipiouf_Internalname ;
      private string edtavMunicipiouf_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavRepresentante_representanteid_Internalname ;
      private string edtavRepresentante_representanteid_Jsonclick ;
      private string edtavRepresentante_clienteid_Internalname ;
      private string edtavRepresentante_clienteid_Jsonclick ;
      private string edtavRepresentante_representantemunicipio_Internalname ;
      private string edtavRepresentante_representantemunicipio_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14CheckRequiredFieldsResult ;
      private bool Combo_representante_representanteprofissao_Enabled ;
      private bool Combo_representante_representanteprofissao_Emptyitem ;
      private bool Combo_representante_representanteprofissao_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV13LoadSuccess ;
      private bool n441ProfissaoNome ;
      private string AV19ModeloRetorno ;
      private string A441ProfissaoNome ;
      private string AV23MunicipioNome ;
      private string AV25MunicipioUF ;
      private string AV8ComboSelectedValue ;
      private string AV17CEP ;
      private string AV20Mensagem ;
      private IGxSession AV9Session ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_representante_representanteprofissao ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavRepresentante_representantetipo ;
      private GXCombobox cmbavRepresentante_representanteestadocivil ;
      private SdtRepresentante AV5Representante ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV6Representante_RepresentanteProfissao_Data ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private IDataStoreProvider pr_default ;
      private int[] H009O2_A440ProfissaoId ;
      private string[] H009O2_A441ProfissaoNome ;
      private bool[] H009O2_n441ProfissaoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV7Combo_DataItem ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
      private GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto AV18EnderecoCompleto ;
      private SdtMunicipio AV21Municipio ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wprepresentante__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH009O2;
          prmH009O2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H009O2", "SELECT ProfissaoId, ProfissaoNome FROM Profissao ORDER BY ProfissaoNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009O2,100, GxCacheFrequency.OFF ,false,false )
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
                return;
       }
    }

 }

}
