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
   public class wpbaixatitulo : GXDataArea
   {
      public wpbaixatitulo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpbaixatitulo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_TituloId )
      {
         this.AV5TituloId = aP0_TituloId;
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
            gxfirstwebparm = GetFirstPar( "TituloId");
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
               gxfirstwebparm = GetFirstPar( "TituloId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TituloId");
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
         PA4S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4S2( ) ;
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
         GXEncryptionTmp = "wpbaixatitulo"+UrlEncode(StringUtil.LTrimStr(AV5TituloId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("wpbaixatitulo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vTITULOVENCIMENTO", GetSecureSignedToken( "", AV25TituloVencimento, context));
         GxWebStd.gx_hidden_field( context, "vJUROSMORA", StringUtil.LTrim( StringUtil.NToC( AV24JurosMora, 6, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vJUROSMORA", GetSecureSignedToken( "", context.localUtil.Format( AV24JurosMora, "ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTITULOSALDO_F", GetSecureSignedToken( "", context.localUtil.Format( AV7TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vPREFERENCIASMULTA", StringUtil.LTrim( StringUtil.NToC( AV23PreferenciasMulta, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPREFERENCIASMULTA", GetSecureSignedToken( "", context.localUtil.Format( AV23PreferenciasMulta, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5TituloId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WpBaixaTitulo");
         forbiddenHiddens.Add("TituloSaldo_F", context.localUtil.Format( AV7TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("TituloVencimento", context.localUtil.Format(AV25TituloVencimento, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wpbaixatitulo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPOPAGAMENTOID_DATA", AV13TipoPagamentoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPOPAGAMENTOID_DATA", AV13TipoPagamentoId_Data);
         }
         GxWebStd.gx_hidden_field( context, "TIPOPAGAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TIPOPAGAMENTONOME", A289TipoPagamentoNome);
         GxWebStd.gx_hidden_field( context, "vJUROSMORA", StringUtil.LTrim( StringUtil.NToC( AV24JurosMora, 6, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vJUROSMORA", GetSecureSignedToken( "", context.localUtil.Format( AV24JurosMora, "ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vPREFERENCIASMULTA", StringUtil.LTrim( StringUtil.NToC( AV23PreferenciasMulta, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPREFERENCIASMULTA", GetSecureSignedToken( "", context.localUtil.Format( AV23PreferenciasMulta, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV17CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vJUROSMORAATUAL", StringUtil.LTrim( StringUtil.NToC( AV27JurosMoraAtual, 6, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vDIFERENCA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Diferenca), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Cls", StringUtil.RTrim( Combo_tipopagamentoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Selectedvalue_set", StringUtil.RTrim( Combo_tipopagamentoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Emptyitem", StringUtil.BoolToStr( Combo_tipopagamentoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Includeaddnewoption", StringUtil.BoolToStr( Combo_tipopagamentoid_Includeaddnewoption));
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
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Selectedvalue_get", StringUtil.RTrim( Combo_tipopagamentoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Ddointernalname", StringUtil.RTrim( Combo_tipopagamentoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Selectedvalue_get", StringUtil.RTrim( Combo_tipopagamentoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Ddointernalname", StringUtil.RTrim( Combo_tipopagamentoid_Ddointernalname));
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
            WE4S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4S2( ) ;
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
         GXEncryptionTmp = "wpbaixatitulo"+UrlEncode(StringUtil.LTrimStr(AV5TituloId,9,0));
         return formatLink("wpbaixatitulo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpBaixaTitulo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Baixar título" ;
      }

      protected void WB4S0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableconsul_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Cliente", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV6ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV6ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpBaixaTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTituloid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTituloid_Internalname, "Título", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTituloid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5TituloId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavTituloid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5TituloId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5TituloId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTituloid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTituloid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpBaixaTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTitulosaldo_f_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulosaldo_f_Internalname, "Saldo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulosaldo_f_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7TituloSaldo_F, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulosaldo_f_Enabled!=0) ? context.localUtil.Format( AV7TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV7TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulosaldo_f_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTitulosaldo_f_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpBaixaTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-7 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTitulovencimento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulovencimento_Internalname, "Vencimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTitulovencimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTitulovencimento_Internalname, context.localUtil.Format(AV25TituloVencimento, "99/99/9999"), context.localUtil.Format( AV25TituloVencimento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulovencimento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTitulovencimento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpBaixaTitulo.htm");
            GxWebStd.gx_bitmap( context, edtavTitulovencimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTitulovencimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpBaixaTitulo.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTitulomovimentodatacredito_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulomovimentodatacredito_Internalname, "Data de crédito", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTitulomovimentodatacredito_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTitulomovimentodatacredito_Internalname, context.localUtil.Format(AV8TituloMovimentoDataCredito, "99/99/9999"), context.localUtil.Format( AV8TituloMovimentoDataCredito, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulomovimentodatacredito_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTitulomovimentodatacredito_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpBaixaTitulo.htm");
            GxWebStd.gx_bitmap( context, edtavTitulomovimentodatacredito_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTitulomovimentodatacredito_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WpBaixaTitulo.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedtipopagamentoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_tipopagamentoid_Internalname, "Tipo de pagamento", "", "", lblTextblockcombo_tipopagamentoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpBaixaTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_tipopagamentoid.SetProperty("Caption", Combo_tipopagamentoid_Caption);
            ucCombo_tipopagamentoid.SetProperty("Cls", Combo_tipopagamentoid_Cls);
            ucCombo_tipopagamentoid.SetProperty("EmptyItem", Combo_tipopagamentoid_Emptyitem);
            ucCombo_tipopagamentoid.SetProperty("IncludeAddNewOption", Combo_tipopagamentoid_Includeaddnewoption);
            ucCombo_tipopagamentoid.SetProperty("DropDownOptionsData", AV13TipoPagamentoId_Data);
            ucCombo_tipopagamentoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tipopagamentoid_Internalname, "COMBO_TIPOPAGAMENTOIDContainer");
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
            GxWebStd.gx_div_start( context, divTablevalore_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTitulomovimentovalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulomovimentovalor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulomovimentovalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9TituloMovimentoValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulomovimentovalor_Enabled!=0) ? context.localUtil.Format( AV9TituloMovimentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV9TituloMovimentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulomovimentovalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTitulomovimentovalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpBaixaTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTitulomovimentovalorjuros_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulomovimentovalorjuros_Internalname, "Juros", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulomovimentovalorjuros_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10TituloMovimentoValorJuros, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulomovimentovalorjuros_Enabled!=0) ? context.localUtil.Format( AV10TituloMovimentoValorJuros, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV10TituloMovimentoValorJuros, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulomovimentovalorjuros_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTitulomovimentovalorjuros_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpBaixaTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTitulomovimentovalormulta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulomovimentovalormulta_Internalname, "Multa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulomovimentovalormulta_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11TituloMovimentoValorMulta, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulomovimentovalormulta_Enabled!=0) ? context.localUtil.Format( AV11TituloMovimentoValorMulta, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV11TituloMovimentoValorMulta, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulomovimentovalormulta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTitulomovimentovalormulta_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpBaixaTitulo.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpBaixaTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpBaixaTitulo.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipopagamentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12TipoPagamentoId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12TipoPagamentoId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipopagamentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipopagamentoid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpBaixaTitulo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4S2( )
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
         Form.Meta.addItem("description", "Baixar título", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4S0( ) ;
      }

      protected void WS4S2( )
      {
         START4S2( ) ;
         EVT4S2( ) ;
      }

      protected void EVT4S2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_TIPOPAGAMENTOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_tipopagamentoid.Onoptionclicked */
                              E114S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E124S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VTITULOMOVIMENTOVALOR.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134S2 ();
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
                                    E144S2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E154S2 ();
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

      protected void WE4S2( )
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

      protected void PA4S2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpbaixatitulo")), "wpbaixatitulo") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpbaixatitulo")))) ;
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
                  gxfirstwebparm = GetFirstPar( "TituloId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV5TituloId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV5TituloId", StringUtil.LTrimStr( (decimal)(AV5TituloId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vTITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5TituloId), "ZZZZZZZZ9"), context));
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
         RF4S2( ) ;
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
         edtavTituloid_Enabled = 0;
         AssignProp("", false, edtavTituloid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTituloid_Enabled), 5, 0), true);
         edtavTitulosaldo_f_Enabled = 0;
         AssignProp("", false, edtavTitulosaldo_f_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitulosaldo_f_Enabled), 5, 0), true);
         edtavTitulovencimento_Enabled = 0;
         AssignProp("", false, edtavTitulovencimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitulovencimento_Enabled), 5, 0), true);
      }

      protected void RF4S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E154S2 ();
            WB4S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4S2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vTITULOVENCIMENTO", GetSecureSignedToken( "", AV25TituloVencimento, context));
         GxWebStd.gx_hidden_field( context, "vJUROSMORA", StringUtil.LTrim( StringUtil.NToC( AV24JurosMora, 6, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vJUROSMORA", GetSecureSignedToken( "", context.localUtil.Format( AV24JurosMora, "ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTITULOSALDO_F", GetSecureSignedToken( "", context.localUtil.Format( AV7TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vPREFERENCIASMULTA", StringUtil.LTrim( StringUtil.NToC( AV23PreferenciasMulta, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPREFERENCIASMULTA", GetSecureSignedToken( "", context.localUtil.Format( AV23PreferenciasMulta, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
      }

      protected void before_start_formulas( )
      {
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavTituloid_Enabled = 0;
         AssignProp("", false, edtavTituloid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTituloid_Enabled), 5, 0), true);
         edtavTitulosaldo_f_Enabled = 0;
         AssignProp("", false, edtavTitulosaldo_f_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitulosaldo_f_Enabled), 5, 0), true);
         edtavTitulovencimento_Enabled = 0;
         AssignProp("", false, edtavTitulovencimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitulovencimento_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E124S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vTIPOPAGAMENTOID_DATA"), AV13TipoPagamentoId_Data);
            /* Read saved values. */
            AV23PreferenciasMulta = context.localUtil.CToN( cgiGet( "vPREFERENCIASMULTA"), ",", ".");
            AssignAttri("", false, "AV23PreferenciasMulta", StringUtil.LTrimStr( AV23PreferenciasMulta, 16, 4));
            GxWebStd.gx_hidden_field( context, "gxhash_vPREFERENCIASMULTA", GetSecureSignedToken( "", context.localUtil.Format( AV23PreferenciasMulta, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
            AV24JurosMora = context.localUtil.CToN( cgiGet( "vJUROSMORA"), ",", ".");
            AssignAttri("", false, "AV24JurosMora", StringUtil.LTrimStr( AV24JurosMora, 6, 2));
            GxWebStd.gx_hidden_field( context, "gxhash_vJUROSMORA", GetSecureSignedToken( "", context.localUtil.Format( AV24JurosMora, "ZZ9.99"), context));
            AV27JurosMoraAtual = context.localUtil.CToN( cgiGet( "vJUROSMORAATUAL"), ",", ".");
            AV26Diferenca = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vDIFERENCA"), ",", "."), 18, MidpointRounding.ToEven));
            Combo_tipopagamentoid_Cls = cgiGet( "COMBO_TIPOPAGAMENTOID_Cls");
            Combo_tipopagamentoid_Selectedvalue_set = cgiGet( "COMBO_TIPOPAGAMENTOID_Selectedvalue_set");
            Combo_tipopagamentoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Emptyitem"));
            Combo_tipopagamentoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Includeaddnewoption"));
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
            Combo_tipopagamentoid_Selectedvalue_get = cgiGet( "COMBO_TIPOPAGAMENTOID_Selectedvalue_get");
            Combo_tipopagamentoid_Ddointernalname = cgiGet( "COMBO_TIPOPAGAMENTOID_Ddointernalname");
            /* Read variables values. */
            AV6ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AssignAttri("", false, "AV6ClienteRazaoSocial", AV6ClienteRazaoSocial);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulosaldo_f_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulosaldo_f_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOSALDO_F");
               GX_FocusControl = edtavTitulosaldo_f_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7TituloSaldo_F = 0;
               AssignAttri("", false, "AV7TituloSaldo_F", StringUtil.LTrimStr( AV7TituloSaldo_F, 18, 2));
               GxWebStd.gx_hidden_field( context, "gxhash_vTITULOSALDO_F", GetSecureSignedToken( "", context.localUtil.Format( AV7TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            }
            else
            {
               AV7TituloSaldo_F = context.localUtil.CToN( cgiGet( edtavTitulosaldo_f_Internalname), ",", ".");
               AssignAttri("", false, "AV7TituloSaldo_F", StringUtil.LTrimStr( AV7TituloSaldo_F, 18, 2));
               GxWebStd.gx_hidden_field( context, "gxhash_vTITULOSALDO_F", GetSecureSignedToken( "", context.localUtil.Format( AV7TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTitulovencimento_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Titulo Vencimento"}), 1, "vTITULOVENCIMENTO");
               GX_FocusControl = edtavTitulovencimento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25TituloVencimento = DateTime.MinValue;
               AssignAttri("", false, "AV25TituloVencimento", context.localUtil.Format(AV25TituloVencimento, "99/99/9999"));
               GxWebStd.gx_hidden_field( context, "gxhash_vTITULOVENCIMENTO", GetSecureSignedToken( "", AV25TituloVencimento, context));
            }
            else
            {
               AV25TituloVencimento = context.localUtil.CToD( cgiGet( edtavTitulovencimento_Internalname), 2);
               AssignAttri("", false, "AV25TituloVencimento", context.localUtil.Format(AV25TituloVencimento, "99/99/9999"));
               GxWebStd.gx_hidden_field( context, "gxhash_vTITULOVENCIMENTO", GetSecureSignedToken( "", AV25TituloVencimento, context));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTitulomovimentodatacredito_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Titulo Movimento Data Credito"}), 1, "vTITULOMOVIMENTODATACREDITO");
               GX_FocusControl = edtavTitulomovimentodatacredito_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8TituloMovimentoDataCredito = DateTime.MinValue;
               AssignAttri("", false, "AV8TituloMovimentoDataCredito", context.localUtil.Format(AV8TituloMovimentoDataCredito, "99/99/9999"));
            }
            else
            {
               AV8TituloMovimentoDataCredito = context.localUtil.CToD( cgiGet( edtavTitulomovimentodatacredito_Internalname), 2);
               AssignAttri("", false, "AV8TituloMovimentoDataCredito", context.localUtil.Format(AV8TituloMovimentoDataCredito, "99/99/9999"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulomovimentovalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulomovimentovalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOMOVIMENTOVALOR");
               GX_FocusControl = edtavTitulomovimentovalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9TituloMovimentoValor = 0;
               AssignAttri("", false, "AV9TituloMovimentoValor", StringUtil.LTrimStr( AV9TituloMovimentoValor, 18, 2));
            }
            else
            {
               AV9TituloMovimentoValor = context.localUtil.CToN( cgiGet( edtavTitulomovimentovalor_Internalname), ",", ".");
               AssignAttri("", false, "AV9TituloMovimentoValor", StringUtil.LTrimStr( AV9TituloMovimentoValor, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulomovimentovalorjuros_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulomovimentovalorjuros_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOMOVIMENTOVALORJUROS");
               GX_FocusControl = edtavTitulomovimentovalorjuros_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10TituloMovimentoValorJuros = 0;
               AssignAttri("", false, "AV10TituloMovimentoValorJuros", StringUtil.LTrimStr( AV10TituloMovimentoValorJuros, 18, 2));
            }
            else
            {
               AV10TituloMovimentoValorJuros = context.localUtil.CToN( cgiGet( edtavTitulomovimentovalorjuros_Internalname), ",", ".");
               AssignAttri("", false, "AV10TituloMovimentoValorJuros", StringUtil.LTrimStr( AV10TituloMovimentoValorJuros, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulomovimentovalormulta_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulomovimentovalormulta_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOMOVIMENTOVALORMULTA");
               GX_FocusControl = edtavTitulomovimentovalormulta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11TituloMovimentoValorMulta = 0;
               AssignAttri("", false, "AV11TituloMovimentoValorMulta", StringUtil.LTrimStr( AV11TituloMovimentoValorMulta, 18, 2));
            }
            else
            {
               AV11TituloMovimentoValorMulta = context.localUtil.CToN( cgiGet( edtavTitulomovimentovalormulta_Internalname), ",", ".");
               AssignAttri("", false, "AV11TituloMovimentoValorMulta", StringUtil.LTrimStr( AV11TituloMovimentoValorMulta, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTipopagamentoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTipopagamentoid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIPOPAGAMENTOID");
               GX_FocusControl = edtavTipopagamentoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12TipoPagamentoId = 0;
               AssignAttri("", false, "AV12TipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV12TipoPagamentoId), 9, 0));
            }
            else
            {
               AV12TipoPagamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavTipopagamentoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12TipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV12TipoPagamentoId), 9, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"WpBaixaTitulo");
            AV7TituloSaldo_F = context.localUtil.CToN( cgiGet( edtavTitulosaldo_f_Internalname), ",", ".");
            AssignAttri("", false, "AV7TituloSaldo_F", StringUtil.LTrimStr( AV7TituloSaldo_F, 18, 2));
            GxWebStd.gx_hidden_field( context, "gxhash_vTITULOSALDO_F", GetSecureSignedToken( "", context.localUtil.Format( AV7TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            forbiddenHiddens.Add("TituloSaldo_F", context.localUtil.Format( AV7TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
            AV25TituloVencimento = context.localUtil.CToD( cgiGet( edtavTitulovencimento_Internalname), 2);
            AssignAttri("", false, "AV25TituloVencimento", context.localUtil.Format(AV25TituloVencimento, "99/99/9999"));
            GxWebStd.gx_hidden_field( context, "gxhash_vTITULOVENCIMENTO", GetSecureSignedToken( "", AV25TituloVencimento, context));
            forbiddenHiddens.Add("TituloVencimento", context.localUtil.Format(AV25TituloVencimento, "99/99/9999"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wpbaixatitulo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E124S2 ();
         if (returnInSub) return;
      }

      protected void E124S2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H004S3 */
         pr_default.execute(0, new Object[] {AV5TituloId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A890NotaFiscalParcelamentoID = H004S3_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = H004S3_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = H004S3_A794NotaFiscalId[0];
            n794NotaFiscalId = H004S3_n794NotaFiscalId[0];
            A168ClienteId = H004S3_A168ClienteId[0];
            n168ClienteId = H004S3_n168ClienteId[0];
            A261TituloId = H004S3_A261TituloId[0];
            n261TituloId = H004S3_n261TituloId[0];
            A170ClienteRazaoSocial = H004S3_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H004S3_n170ClienteRazaoSocial[0];
            A263TituloVencimento = H004S3_A263TituloVencimento[0];
            n263TituloVencimento = H004S3_n263TituloVencimento[0];
            A273TituloTotalMovimento_F = H004S3_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = H004S3_n273TituloTotalMovimento_F[0];
            A276TituloDesconto = H004S3_A276TituloDesconto[0];
            n276TituloDesconto = H004S3_n276TituloDesconto[0];
            A262TituloValor = H004S3_A262TituloValor[0];
            n262TituloValor = H004S3_n262TituloValor[0];
            A794NotaFiscalId = H004S3_A794NotaFiscalId[0];
            n794NotaFiscalId = H004S3_n794NotaFiscalId[0];
            A168ClienteId = H004S3_A168ClienteId[0];
            n168ClienteId = H004S3_n168ClienteId[0];
            A170ClienteRazaoSocial = H004S3_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H004S3_n170ClienteRazaoSocial[0];
            A273TituloTotalMovimento_F = H004S3_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = H004S3_n273TituloTotalMovimento_F[0];
            A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
            AssignAttri("", false, "A275TituloSaldo_F", StringUtil.LTrimStr( A275TituloSaldo_F, 18, 2));
            AV6ClienteRazaoSocial = A170ClienteRazaoSocial;
            AssignAttri("", false, "AV6ClienteRazaoSocial", AV6ClienteRazaoSocial);
            AV7TituloSaldo_F = A275TituloSaldo_F;
            AssignAttri("", false, "AV7TituloSaldo_F", StringUtil.LTrimStr( AV7TituloSaldo_F, 18, 2));
            GxWebStd.gx_hidden_field( context, "gxhash_vTITULOSALDO_F", GetSecureSignedToken( "", context.localUtil.Format( AV7TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            AV25TituloVencimento = A263TituloVencimento;
            AssignAttri("", false, "AV25TituloVencimento", context.localUtil.Format(AV25TituloVencimento, "99/99/9999"));
            GxWebStd.gx_hidden_field( context, "gxhash_vTITULOVENCIMENTO", GetSecureSignedToken( "", AV25TituloVencimento, context));
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV23PreferenciasMulta = (decimal)(2);
         AssignAttri("", false, "AV23PreferenciasMulta", StringUtil.LTrimStr( AV23PreferenciasMulta, 16, 4));
         GxWebStd.gx_hidden_field( context, "gxhash_vPREFERENCIASMULTA", GetSecureSignedToken( "", context.localUtil.Format( AV23PreferenciasMulta, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         AV22PreferenciasJuros = (decimal)(1);
         AV24JurosMora = (decimal)(AV22PreferenciasJuros/ (decimal)(30));
         AssignAttri("", false, "AV24JurosMora", StringUtil.LTrimStr( AV24JurosMora, 6, 2));
         GxWebStd.gx_hidden_field( context, "gxhash_vJUROSMORA", GetSecureSignedToken( "", context.localUtil.Format( AV24JurosMora, "ZZ9.99"), context));
         edtavTipopagamentoid_Visible = 0;
         AssignProp("", false, edtavTipopagamentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipopagamentoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTIPOPAGAMENTOID' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E114S2( )
      {
         /* Combo_tipopagamentoid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_tipopagamentoid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "tipopagamento"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            context.PopUp(formatLink("tipopagamento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_tipopagamentoid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOTIPOPAGAMENTOID' */
            S112 ();
            if (returnInSub) return;
            AV15ComboSelectedValue = AV16Session.Get("TIPOPAGAMENTOID");
            AV16Session.Remove("TIPOPAGAMENTOID");
            Combo_tipopagamentoid_Selectedvalue_set = AV15ComboSelectedValue;
            ucCombo_tipopagamentoid.SendProperty(context, "", false, Combo_tipopagamentoid_Internalname, "SelectedValue_set", Combo_tipopagamentoid_Selectedvalue_set);
            AV12TipoPagamentoId = (int)(Math.Round(NumberUtil.Val( AV15ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12TipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV12TipoPagamentoId), 9, 0));
         }
         else
         {
            AV12TipoPagamentoId = (int)(Math.Round(NumberUtil.Val( Combo_tipopagamentoid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12TipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV12TipoPagamentoId), 9, 0));
            /* Execute user subroutine: 'LOADCOMBOTIPOPAGAMENTOID' */
            S112 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13TipoPagamentoId_Data", AV13TipoPagamentoId_Data);
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV17CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV17CheckRequiredFieldsResult", AV17CheckRequiredFieldsResult);
         if ( (DateTime.MinValue==AV8TituloMovimentoDataCredito) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Data de crédito", "", "", "", "", "", "", "", ""),  "error",  edtavTitulomovimentodatacredito_Internalname,  "true",  ""));
            AV17CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV17CheckRequiredFieldsResult", AV17CheckRequiredFieldsResult);
         }
         if ( (0==AV12TipoPagamentoId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Tipo de pagamento", "", "", "", "", "", "", "", ""),  "error",  Combo_tipopagamentoid_Ddointernalname,  "true",  ""));
            AV17CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV17CheckRequiredFieldsResult", AV17CheckRequiredFieldsResult);
         }
         if ( (Convert.ToDecimal(0)==AV9TituloMovimentoValor) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Valor", "", "", "", "", "", "", "", ""),  "error",  edtavTitulomovimentovalor_Internalname,  "true",  ""));
            AV17CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV17CheckRequiredFieldsResult", AV17CheckRequiredFieldsResult);
         }
         /* Execute user subroutine: 'VALIDAVALOR' */
         S122 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOTIPOPAGAMENTOID' Routine */
         returnInSub = false;
         AV13TipoPagamentoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H004S4 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A288TipoPagamentoId = H004S4_A288TipoPagamentoId[0];
            A289TipoPagamentoNome = H004S4_A289TipoPagamentoNome[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A288TipoPagamentoId), 9, 0));
            AV14Combo_DataItem.gxTpr_Title = A289TipoPagamentoNome;
            AV13TipoPagamentoId_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_tipopagamentoid_Selectedvalue_set = ((0==AV12TipoPagamentoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV12TipoPagamentoId), 9, 0)));
         ucCombo_tipopagamentoid.SendProperty(context, "", false, Combo_tipopagamentoid_Internalname, "SelectedValue_set", Combo_tipopagamentoid_Selectedvalue_set);
      }

      protected void E134S2( )
      {
         /* Titulomovimentovalor_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDAVALOR' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E144S2 ();
         if (returnInSub) return;
      }

      protected void E144S2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S132 ();
         if (returnInSub) return;
         if ( AV17CheckRequiredFieldsResult )
         {
            /* Execute user subroutine: 'MOVIMENTOS' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'VALIDAVALOR' Routine */
         returnInSub = false;
         if ( AV9TituloMovimentoValor > AV7TituloSaldo_F )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Valor não pode ultrapassar saldo do título",  "error",  edtavTitulomovimentovalor_Internalname,  "na",  ""));
            AV17CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV17CheckRequiredFieldsResult", AV17CheckRequiredFieldsResult);
         }
      }

      protected void S142( )
      {
         /* 'MOVIMENTOS' Routine */
         returnInSub = false;
         AV18Array_SdTituloMovimento = new GXBaseCollection<SdtSdTituloMovimento>( context, "SdTituloMovimento", "Factory21");
         AV19SdTituloMovimento = new SdtSdTituloMovimento(context);
         AV19SdTituloMovimento.gxTpr_Tipopagamentoid = AV12TipoPagamentoId;
         AV19SdTituloMovimento.gxTpr_Tituloid = AV5TituloId;
         AV19SdTituloMovimento.gxTpr_Titulomovimentovalor = AV9TituloMovimentoValor;
         AV19SdTituloMovimento.gxTpr_Titulomovimentotipo = "Baixa";
         AV19SdTituloMovimento.gxTpr_Titulomovimentosoma = true;
         AV19SdTituloMovimento.gxTpr_Titulomovimentodatacredito = AV8TituloMovimentoDataCredito;
         AV18Array_SdTituloMovimento.Add(AV19SdTituloMovimento, 0);
         if ( ! (Convert.ToDecimal(0)==AV10TituloMovimentoValorJuros) )
         {
            AV19SdTituloMovimento = new SdtSdTituloMovimento(context);
            AV19SdTituloMovimento.gxTpr_Tipopagamentoid = AV12TipoPagamentoId;
            AV19SdTituloMovimento.gxTpr_Tituloid = AV5TituloId;
            AV19SdTituloMovimento.gxTpr_Titulomovimentovalor = AV10TituloMovimentoValorJuros;
            AV19SdTituloMovimento.gxTpr_Titulomovimentotipo = "Juros";
            AV19SdTituloMovimento.gxTpr_Titulomovimentosoma = false;
            AV19SdTituloMovimento.gxTpr_Titulomovimentodatacredito = AV8TituloMovimentoDataCredito;
            AV18Array_SdTituloMovimento.Add(AV19SdTituloMovimento, 0);
         }
         if ( ! (Convert.ToDecimal(0)==AV11TituloMovimentoValorMulta) )
         {
            AV19SdTituloMovimento = new SdtSdTituloMovimento(context);
            AV19SdTituloMovimento.gxTpr_Tipopagamentoid = AV12TipoPagamentoId;
            AV19SdTituloMovimento.gxTpr_Tituloid = AV5TituloId;
            AV19SdTituloMovimento.gxTpr_Titulomovimentovalor = AV11TituloMovimentoValorMulta;
            AV19SdTituloMovimento.gxTpr_Titulomovimentotipo = "Multa";
            AV19SdTituloMovimento.gxTpr_Titulomovimentosoma = false;
            AV19SdTituloMovimento.gxTpr_Titulomovimentodatacredito = AV8TituloMovimentoDataCredito;
            AV18Array_SdTituloMovimento.Add(AV19SdTituloMovimento, 0);
         }
         new prcriarntitulomovimentos(context ).execute(  AV18Array_SdTituloMovimento, out  AV20SdErro) ;
         if ( AV20SdErro.gxTpr_Status == 200 )
         {
            context.CommitDataStores("wpbaixatitulo",pr_default);
            AV21WEBSESSION.Set("WpBaixaTitulo", "Sucesso");
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            context.RollbackDataStores("wpbaixatitulo",pr_default);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Erro",  AV20SdErro.gxTpr_Msg,  "error",  "",  "true",  ""));
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E154S2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5TituloId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV5TituloId", StringUtil.LTrimStr( (decimal)(AV5TituloId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5TituloId), "ZZZZZZZZ9"), context));
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
         PA4S2( ) ;
         WS4S2( ) ;
         WE4S2( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101925399", true, true);
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
         context.AddJavascriptSource("wpbaixatitulo.js", "?20256101925399", false, true);
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
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavClienterazaosocial_Internalname = "vCLIENTERAZAOSOCIAL";
         edtavTituloid_Internalname = "vTITULOID";
         edtavTitulosaldo_f_Internalname = "vTITULOSALDO_F";
         edtavTitulovencimento_Internalname = "vTITULOVENCIMENTO";
         divTableconsul_Internalname = "TABLECONSUL";
         edtavTitulomovimentodatacredito_Internalname = "vTITULOMOVIMENTODATACREDITO";
         lblTextblockcombo_tipopagamentoid_Internalname = "TEXTBLOCKCOMBO_TIPOPAGAMENTOID";
         Combo_tipopagamentoid_Internalname = "COMBO_TIPOPAGAMENTOID";
         divTablesplittedtipopagamentoid_Internalname = "TABLESPLITTEDTIPOPAGAMENTOID";
         edtavTitulomovimentovalor_Internalname = "vTITULOMOVIMENTOVALOR";
         edtavTitulomovimentovalorjuros_Internalname = "vTITULOMOVIMENTOVALORJUROS";
         edtavTitulomovimentovalormulta_Internalname = "vTITULOMOVIMENTOVALORMULTA";
         divTablevalore_Internalname = "TABLEVALORE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavTipopagamentoid_Internalname = "vTIPOPAGAMENTOID";
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
         edtavTipopagamentoid_Jsonclick = "";
         edtavTipopagamentoid_Visible = 1;
         edtavTitulomovimentovalormulta_Jsonclick = "";
         edtavTitulomovimentovalormulta_Enabled = 1;
         edtavTitulomovimentovalorjuros_Jsonclick = "";
         edtavTitulomovimentovalorjuros_Enabled = 1;
         edtavTitulomovimentovalor_Jsonclick = "";
         edtavTitulomovimentovalor_Enabled = 1;
         edtavTitulomovimentodatacredito_Jsonclick = "";
         edtavTitulomovimentodatacredito_Enabled = 1;
         edtavTitulovencimento_Jsonclick = "";
         edtavTitulovencimento_Enabled = 1;
         edtavTitulosaldo_f_Jsonclick = "";
         edtavTitulosaldo_f_Enabled = 1;
         edtavTituloid_Jsonclick = "";
         edtavTituloid_Enabled = 0;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
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
         Combo_tipopagamentoid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_tipopagamentoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_tipopagamentoid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Baixar título";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV24JurosMora","fld":"vJUROSMORA","pic":"ZZ9.99","hsh":true,"type":"decimal"},{"av":"AV23PreferenciasMulta","fld":"vPREFERENCIASMULTA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV25TituloVencimento","fld":"vTITULOVENCIMENTO","hsh":true,"type":"date"},{"av":"AV7TituloSaldo_F","fld":"vTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"AV5TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("COMBO_TIPOPAGAMENTOID.ONOPTIONCLICKED","""{"handler":"E114S2","iparms":[{"av":"Combo_tipopagamentoid_Selectedvalue_get","ctrl":"COMBO_TIPOPAGAMENTOID","prop":"SelectedValue_get"},{"av":"A288TipoPagamentoId","fld":"TIPOPAGAMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A289TipoPagamentoNome","fld":"TIPOPAGAMENTONOME","type":"svchar"},{"av":"AV12TipoPagamentoId","fld":"vTIPOPAGAMENTOID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("COMBO_TIPOPAGAMENTOID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_tipopagamentoid_Selectedvalue_set","ctrl":"COMBO_TIPOPAGAMENTOID","prop":"SelectedValue_set"},{"av":"AV12TipoPagamentoId","fld":"vTIPOPAGAMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV13TipoPagamentoId_Data","fld":"vTIPOPAGAMENTOID_DATA","type":""}]}""");
         setEventMetadata("VTITULOMOVIMENTOVALOR.CONTROLVALUECHANGED","""{"handler":"E134S2","iparms":[{"av":"AV9TituloMovimentoValor","fld":"vTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV7TituloSaldo_F","fld":"vTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"}]""");
         setEventMetadata("VTITULOMOVIMENTOVALOR.CONTROLVALUECHANGED",""","oparms":[{"av":"AV17CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("ENTER","""{"handler":"E144S2","iparms":[{"av":"AV17CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV8TituloMovimentoDataCredito","fld":"vTITULOMOVIMENTODATACREDITO","type":"date"},{"av":"AV12TipoPagamentoId","fld":"vTIPOPAGAMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Combo_tipopagamentoid_Ddointernalname","ctrl":"COMBO_TIPOPAGAMENTOID","prop":"DDOInternalName"},{"av":"AV9TituloMovimentoValor","fld":"vTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV5TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV10TituloMovimentoValorJuros","fld":"vTITULOMOVIMENTOVALORJUROS","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV11TituloMovimentoValorMulta","fld":"vTITULOMOVIMENTOVALORMULTA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV7TituloSaldo_F","fld":"vTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV17CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VALIDV_TITULOID","""{"handler":"Validv_Tituloid","iparms":[]}""");
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
         Combo_tipopagamentoid_Selectedvalue_get = "";
         Combo_tipopagamentoid_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV25TituloVencimento = DateTime.MinValue;
         forbiddenHiddens = new GXProperties();
         AV13TipoPagamentoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A289TipoPagamentoNome = "";
         Combo_tipopagamentoid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         AV6ClienteRazaoSocial = "";
         AV8TituloMovimentoDataCredito = DateTime.MinValue;
         lblTextblockcombo_tipopagamentoid_Jsonclick = "";
         ucCombo_tipopagamentoid = new GXUserControl();
         Combo_tipopagamentoid_Caption = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         hsh = "";
         H004S3_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H004S3_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H004S3_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H004S3_n794NotaFiscalId = new bool[] {false} ;
         H004S3_A168ClienteId = new int[1] ;
         H004S3_n168ClienteId = new bool[] {false} ;
         H004S3_A261TituloId = new int[1] ;
         H004S3_n261TituloId = new bool[] {false} ;
         H004S3_A170ClienteRazaoSocial = new string[] {""} ;
         H004S3_n170ClienteRazaoSocial = new bool[] {false} ;
         H004S3_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         H004S3_n263TituloVencimento = new bool[] {false} ;
         H004S3_A273TituloTotalMovimento_F = new decimal[1] ;
         H004S3_n273TituloTotalMovimento_F = new bool[] {false} ;
         H004S3_A276TituloDesconto = new decimal[1] ;
         H004S3_n276TituloDesconto = new bool[] {false} ;
         H004S3_A262TituloValor = new decimal[1] ;
         H004S3_n262TituloValor = new bool[] {false} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         A170ClienteRazaoSocial = "";
         A263TituloVencimento = DateTime.MinValue;
         AV15ComboSelectedValue = "";
         AV16Session = context.GetSession();
         H004S4_A288TipoPagamentoId = new int[1] ;
         H004S4_A289TipoPagamentoNome = new string[] {""} ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV18Array_SdTituloMovimento = new GXBaseCollection<SdtSdTituloMovimento>( context, "SdTituloMovimento", "Factory21");
         AV19SdTituloMovimento = new SdtSdTituloMovimento(context);
         AV20SdErro = new SdtSdErro(context);
         AV21WEBSESSION = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpbaixatitulo__default(),
            new Object[][] {
                new Object[] {
               H004S3_A890NotaFiscalParcelamentoID, H004S3_n890NotaFiscalParcelamentoID, H004S3_A794NotaFiscalId, H004S3_n794NotaFiscalId, H004S3_A168ClienteId, H004S3_n168ClienteId, H004S3_A261TituloId, H004S3_A170ClienteRazaoSocial, H004S3_n170ClienteRazaoSocial, H004S3_A263TituloVencimento,
               H004S3_n263TituloVencimento, H004S3_A273TituloTotalMovimento_F, H004S3_n273TituloTotalMovimento_F, H004S3_A276TituloDesconto, H004S3_n276TituloDesconto, H004S3_A262TituloValor, H004S3_n262TituloValor
               }
               , new Object[] {
               H004S4_A288TipoPagamentoId, H004S4_A289TipoPagamentoNome
               }
            }
         );
         /* GeneXus formulas. */
         edtavClienterazaosocial_Enabled = 0;
         edtavTituloid_Enabled = 0;
         edtavTitulosaldo_f_Enabled = 0;
         edtavTitulovencimento_Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short AV26Diferenca ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV5TituloId ;
      private int wcpOAV5TituloId ;
      private int A288TipoPagamentoId ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavTituloid_Enabled ;
      private int edtavTitulosaldo_f_Enabled ;
      private int edtavTitulovencimento_Enabled ;
      private int edtavTitulomovimentodatacredito_Enabled ;
      private int edtavTitulomovimentovalor_Enabled ;
      private int edtavTitulomovimentovalorjuros_Enabled ;
      private int edtavTitulomovimentovalormulta_Enabled ;
      private int AV12TipoPagamentoId ;
      private int edtavTipopagamentoid_Visible ;
      private int A168ClienteId ;
      private int A261TituloId ;
      private int idxLst ;
      private decimal AV24JurosMora ;
      private decimal AV7TituloSaldo_F ;
      private decimal AV23PreferenciasMulta ;
      private decimal AV27JurosMoraAtual ;
      private decimal AV9TituloMovimentoValor ;
      private decimal AV10TituloMovimentoValorJuros ;
      private decimal AV11TituloMovimentoValorMulta ;
      private decimal A273TituloTotalMovimento_F ;
      private decimal A276TituloDesconto ;
      private decimal A262TituloValor ;
      private decimal A275TituloSaldo_F ;
      private decimal AV22PreferenciasJuros ;
      private string Combo_tipopagamentoid_Selectedvalue_get ;
      private string Combo_tipopagamentoid_Ddointernalname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_tipopagamentoid_Cls ;
      private string Combo_tipopagamentoid_Selectedvalue_set ;
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
      private string divTableconsul_Internalname ;
      private string edtavClienterazaosocial_Internalname ;
      private string TempTags ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string edtavTituloid_Internalname ;
      private string edtavTituloid_Jsonclick ;
      private string edtavTitulosaldo_f_Internalname ;
      private string edtavTitulosaldo_f_Jsonclick ;
      private string edtavTitulovencimento_Internalname ;
      private string edtavTitulovencimento_Jsonclick ;
      private string edtavTitulomovimentodatacredito_Internalname ;
      private string edtavTitulomovimentodatacredito_Jsonclick ;
      private string divTablesplittedtipopagamentoid_Internalname ;
      private string lblTextblockcombo_tipopagamentoid_Internalname ;
      private string lblTextblockcombo_tipopagamentoid_Jsonclick ;
      private string Combo_tipopagamentoid_Caption ;
      private string Combo_tipopagamentoid_Internalname ;
      private string divTablevalore_Internalname ;
      private string edtavTitulomovimentovalor_Internalname ;
      private string edtavTitulomovimentovalor_Jsonclick ;
      private string edtavTitulomovimentovalorjuros_Internalname ;
      private string edtavTitulomovimentovalorjuros_Jsonclick ;
      private string edtavTitulomovimentovalormulta_Internalname ;
      private string edtavTitulomovimentovalormulta_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavTipopagamentoid_Internalname ;
      private string edtavTipopagamentoid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string hsh ;
      private DateTime AV25TituloVencimento ;
      private DateTime AV8TituloMovimentoDataCredito ;
      private DateTime A263TituloVencimento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17CheckRequiredFieldsResult ;
      private bool Combo_tipopagamentoid_Emptyitem ;
      private bool Combo_tipopagamentoid_Includeaddnewoption ;
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
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n168ClienteId ;
      private bool n261TituloId ;
      private bool n170ClienteRazaoSocial ;
      private bool n263TituloVencimento ;
      private bool n273TituloTotalMovimento_F ;
      private bool n276TituloDesconto ;
      private bool n262TituloValor ;
      private string A289TipoPagamentoNome ;
      private string AV6ClienteRazaoSocial ;
      private string A170ClienteRazaoSocial ;
      private string AV15ComboSelectedValue ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV16Session ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_tipopagamentoid ;
      private IGxSession AV21WEBSESSION ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13TipoPagamentoId_Data ;
      private IDataStoreProvider pr_default ;
      private Guid[] H004S3_A890NotaFiscalParcelamentoID ;
      private bool[] H004S3_n890NotaFiscalParcelamentoID ;
      private Guid[] H004S3_A794NotaFiscalId ;
      private bool[] H004S3_n794NotaFiscalId ;
      private int[] H004S3_A168ClienteId ;
      private bool[] H004S3_n168ClienteId ;
      private int[] H004S3_A261TituloId ;
      private bool[] H004S3_n261TituloId ;
      private string[] H004S3_A170ClienteRazaoSocial ;
      private bool[] H004S3_n170ClienteRazaoSocial ;
      private DateTime[] H004S3_A263TituloVencimento ;
      private bool[] H004S3_n263TituloVencimento ;
      private decimal[] H004S3_A273TituloTotalMovimento_F ;
      private bool[] H004S3_n273TituloTotalMovimento_F ;
      private decimal[] H004S3_A276TituloDesconto ;
      private bool[] H004S3_n276TituloDesconto ;
      private decimal[] H004S3_A262TituloValor ;
      private bool[] H004S3_n262TituloValor ;
      private int[] H004S4_A288TipoPagamentoId ;
      private string[] H004S4_A289TipoPagamentoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
      private GXBaseCollection<SdtSdTituloMovimento> AV18Array_SdTituloMovimento ;
      private SdtSdTituloMovimento AV19SdTituloMovimento ;
      private SdtSdErro AV20SdErro ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpbaixatitulo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004S3;
          prmH004S3 = new Object[] {
          new ParDef("AV5TituloId",GXType.Int32,9,0)
          };
          Object[] prmH004S4;
          prmH004S4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H004S3", "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T3.ClienteId, T1.TituloId, T4.ClienteRazaoSocial, T1.TituloVencimento, COALESCE( T5.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, T1.TituloDesconto, T1.TituloValor FROM ((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.ClienteId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T1.TituloId) WHERE T1.TituloId = :AV5TituloId ORDER BY T1.TituloId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004S3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H004S4", "SELECT TipoPagamentoId, TipoPagamentoNome FROM TipoPagamento ORDER BY TipoPagamentoNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004S4,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
