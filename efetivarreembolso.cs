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
   public class efetivarreembolso : GXDataArea
   {
      public efetivarreembolso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public efetivarreembolso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ReembolsoId ,
                           int aP1_PropostaId )
      {
         this.AV19ReembolsoId = aP0_ReembolsoId;
         this.AV20PropostaId = aP1_PropostaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavFinalizarreembolso = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ReembolsoId");
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
               gxfirstwebparm = GetFirstPar( "ReembolsoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ReembolsoId");
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
         PA7Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7Q2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
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
         GXEncryptionTmp = "efetivarreembolso"+UrlEncode(StringUtil.LTrimStr(AV19ReembolsoId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV20PropostaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("efetivarreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOSALDOVALOR", GetSecureSignedToken( "", context.localUtil.Format( AV31ReembolsoSaldoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vINITIALDATE", GetSecureSignedToken( "", AV22InitialDate, context));
         GxWebStd.gx_hidden_field( context, "vJUROSPORDIA", StringUtil.LTrim( StringUtil.NToC( AV28JurosPorDia, 9, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vJUROSPORDIA", GetSecureSignedToken( "", context.localUtil.Format( AV28JurosPorDia, "ZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vCONTRATOTAXA", StringUtil.LTrim( StringUtil.NToC( AV24ContratoTaxa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOTAXA", GetSecureSignedToken( "", context.localUtil.Format( AV24ContratoTaxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "vIOFVALOR", StringUtil.LTrim( StringUtil.NToC( AV39IOFValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIOFVALOR", GetSecureSignedToken( "", context.localUtil.Format( AV39IOFValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19ReembolsoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20PropostaId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"EfetivarReembolso");
         forbiddenHiddens.Add("ReembolsoSaldoValor", context.localUtil.Format( AV31ReembolsoSaldoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("InitialDate", context.localUtil.Format(AV22InitialDate, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("efetivarreembolso:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPOPAGAMENTOID_DATA", AV35TipoPagamentoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPOPAGAMENTOID_DATA", AV35TipoPagamentoId_Data);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV15CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19ReembolsoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TIPOPAGAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TIPOPAGAMENTONOME", A289TipoPagamentoNome);
         GxWebStd.gx_hidden_field( context, "vJUROSPORDIA", StringUtil.LTrim( StringUtil.NToC( AV28JurosPorDia, 9, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vJUROSPORDIA", GetSecureSignedToken( "", context.localUtil.Format( AV28JurosPorDia, "ZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vCONTRATOTAXA", StringUtil.LTrim( StringUtil.NToC( AV24ContratoTaxa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOTAXA", GetSecureSignedToken( "", context.localUtil.Format( AV24ContratoTaxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "vIOFVALOR", StringUtil.LTrim( StringUtil.NToC( AV39IOFValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIOFVALOR", GetSecureSignedToken( "", context.localUtil.Format( AV39IOFValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vDIAVALOR", StringUtil.LTrim( StringUtil.NToC( AV29DiaValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Cls", StringUtil.RTrim( Combo_tipopagamentoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Selectedvalue_set", StringUtil.RTrim( Combo_tipopagamentoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Emptyitem", StringUtil.BoolToStr( Combo_tipopagamentoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Includeaddnewoption", StringUtil.BoolToStr( Combo_tipopagamentoid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Width", StringUtil.RTrim( Ucmessage_Width));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Minheight", StringUtil.RTrim( Ucmessage_Minheight));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Stylingtype", StringUtil.RTrim( Ucmessage_Stylingtype));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Stoponerror", StringUtil.BoolToStr( Ucmessage_Stoponerror));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Effectin", StringUtil.RTrim( Ucmessage_Effectin));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Effectout", StringUtil.RTrim( Ucmessage_Effectout));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Animationspeed", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucmessage_Animationspeed), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Startposition", StringUtil.RTrim( Ucmessage_Startposition));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Nextmessageposition", StringUtil.RTrim( Ucmessage_Nextmessageposition));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Ddointernalname", StringUtil.RTrim( Combo_tipopagamentoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Selectedvalue_get", StringUtil.RTrim( Combo_tipopagamentoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Ddointernalname", StringUtil.RTrim( Combo_tipopagamentoid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Selectedvalue_get", StringUtil.RTrim( Combo_tipopagamentoid_Selectedvalue_get));
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
            WE7Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7Q2( ) ;
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
         GXEncryptionTmp = "efetivarreembolso"+UrlEncode(StringUtil.LTrimStr(AV19ReembolsoId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV20PropostaId,9,0));
         return formatLink("efetivarreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "EfetivarReembolso" ;
      }

      public override string GetPgmdesc( )
      {
         return "Efetivar Reembolso" ;
      }

      protected void WB7Q0( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirmar_Internalname, "", "Confirmar", bttBtnconfirmar_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCONFIRMAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostapacienteclienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostapacienteclienterazaosocial_Internalname, "Paciente", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostapacienteclienterazaosocial_Internalname, AV10PropostaPacienteClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV10PropostaPacienteClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostapacienteclienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostapacienteclienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Clinica", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV11ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV11ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostavalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostavalor_Internalname, "Valor da proposta", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostavalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV5PropostaValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavPropostavalor_Enabled!=0) ? context.localUtil.Format( AV5PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV5PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostavalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostavalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsosaldovalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsosaldovalor_Internalname, "Saldo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsosaldovalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV31ReembolsoSaldoValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavReembolsosaldovalor_Enabled!=0) ? context.localUtil.Format( AV31ReembolsoSaldoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV31ReembolsoSaldoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsosaldovalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsosaldovalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavInitialdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavInitialdate_Internalname, "Data da proposta", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavInitialdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavInitialdate_Internalname, context.localUtil.Format(AV22InitialDate, "99/99/9999"), context.localUtil.Format( AV22InitialDate, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavInitialdate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavInitialdate_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_bitmap( context, edtavInitialdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavInitialdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_EfetivarReembolso.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProcedimentosmedicosnome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProcedimentosmedicosnome_Internalname, "Procedimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavProcedimentosmedicosnome_Internalname, AV30ProcedimentosMedicosNome, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", 0, 1, edtavProcedimentosmedicosnome_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsoparcelasvalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoparcelasvalor_Internalname, "Valor reembolsado", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoparcelasvalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV6ReembolsoParcelasValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavReembolsoparcelasvalor_Enabled!=0) ? context.localUtil.Format( AV6ReembolsoParcelasValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV6ReembolsoParcelasValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoparcelasvalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsoparcelasvalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsoparcelasdata_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoparcelasdata_Internalname, "Data do depósito", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavReembolsoparcelasdata_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavReembolsoparcelasdata_Internalname, context.localUtil.Format(AV12ReembolsoParcelasData, "99/99/9999"), context.localUtil.Format( AV12ReembolsoParcelasData, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoparcelasdata_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsoparcelasdata_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_bitmap( context, edtavReembolsoparcelasdata_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavReembolsoparcelasdata_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_EfetivarReembolso.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedtipopagamentoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_tipopagamentoid_Internalname, "Tipo de pagamento", "", "", lblTextblockcombo_tipopagamentoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_tipopagamentoid.SetProperty("Caption", Combo_tipopagamentoid_Caption);
            ucCombo_tipopagamentoid.SetProperty("Cls", Combo_tipopagamentoid_Cls);
            ucCombo_tipopagamentoid.SetProperty("EmptyItem", Combo_tipopagamentoid_Emptyitem);
            ucCombo_tipopagamentoid.SetProperty("IncludeAddNewOption", Combo_tipopagamentoid_Includeaddnewoption);
            ucCombo_tipopagamentoid.SetProperty("DropDownOptionsData", AV35TipoPagamentoId_Data);
            ucCombo_tipopagamentoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tipopagamentoid_Internalname, "COMBO_TIPOPAGAMENTOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsoparcelasobservacao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoparcelasobservacao_Internalname, "Observação", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoparcelasobservacao_Internalname, AV13ReembolsoParcelasObservacao, StringUtil.RTrim( context.localUtil.Format( AV13ReembolsoParcelasObservacao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoparcelasobservacao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsoparcelasobservacao_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletaxa_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsoparcelastaxavalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoparcelastaxavalor_Internalname, "Valor da taxa", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoparcelastaxavalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV16ReembolsoParcelasTaxaValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavReembolsoparcelastaxavalor_Enabled!=0) ? context.localUtil.Format( AV16ReembolsoParcelasTaxaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV16ReembolsoParcelasTaxaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoparcelastaxavalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsoparcelastaxavalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsoparcelasjurosvalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoparcelasjurosvalor_Internalname, "Valor do juros", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoparcelasjurosvalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV17ReembolsoParcelasJurosValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavReembolsoparcelasjurosvalor_Enabled!=0) ? context.localUtil.Format( AV17ReembolsoParcelasJurosValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV17ReembolsoParcelasJurosValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoparcelasjurosvalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsoparcelasjurosvalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsoparcelasdiaspjuros_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoparcelasdiaspjuros_Internalname, "Dias juros/mora", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoparcelasdiaspjuros_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ReembolsoParcelasDiasPJuros), 4, 0, ",", "")), StringUtil.LTrim( ((edtavReembolsoparcelasdiaspjuros_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ReembolsoParcelasDiasPJuros), "ZZZ9") : context.localUtil.Format( (decimal)(AV18ReembolsoParcelasDiasPJuros), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoparcelasdiaspjuros_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsoparcelasdiaspjuros_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EfetivarReembolso.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedfinalizarreembolso_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfinalizarreembolso_Internalname, "Deseja finalizar o reembolso?", "", "", lblTextblockfinalizarreembolso_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table1_87_7Q2( true) ;
         }
         else
         {
            wb_table1_87_7Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_87_7Q2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            /* User Defined Control */
            ucUcmessage.SetProperty("Width", Ucmessage_Width);
            ucUcmessage.SetProperty("MinHeight", Ucmessage_Minheight);
            ucUcmessage.SetProperty("StylingType", Ucmessage_Stylingtype);
            ucUcmessage.SetProperty("StopOnError", Ucmessage_Stoponerror);
            ucUcmessage.SetProperty("EffectIn", Ucmessage_Effectin);
            ucUcmessage.SetProperty("EffectOut", Ucmessage_Effectout);
            ucUcmessage.SetProperty("AnimationSpeed", Ucmessage_Animationspeed);
            ucUcmessage.SetProperty("StartPosition", Ucmessage_Startposition);
            ucUcmessage.SetProperty("NextMessagePosition", Ucmessage_Nextmessageposition);
            ucUcmessage.Render(context, "dvelop.dvmessage", Ucmessage_Internalname, "UCMESSAGEContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipopagamentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34TipoPagamentoId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TipoPagamentoId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipopagamentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipopagamentoid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START7Q2( )
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
         Form.Meta.addItem("description", "Efetivar Reembolso", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7Q0( ) ;
      }

      protected void WS7Q2( )
      {
         START7Q2( ) ;
         EVT7Q2( ) ;
      }

      protected void EVT7Q2( )
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
                              E117Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E127Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCONFIRMAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoConfirmar' */
                              E137Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E147Q2 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7Q2( )
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

      protected void PA7Q2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "efetivarreembolso")), "efetivarreembolso") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "efetivarreembolso")))) ;
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
                  gxfirstwebparm = GetFirstPar( "ReembolsoId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV19ReembolsoId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV19ReembolsoId", StringUtil.LTrimStr( (decimal)(AV19ReembolsoId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19ReembolsoId), "ZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV20PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV20PropostaId", StringUtil.LTrimStr( (decimal)(AV20PropostaId), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20PropostaId), "ZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavPropostapacienteclienterazaosocial_Internalname;
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
         if ( cmbavFinalizarreembolso.ItemCount > 0 )
         {
            AV14FinalizarReembolso = StringUtil.StrToBool( cmbavFinalizarreembolso.getValidValue(StringUtil.BoolToStr( AV14FinalizarReembolso)));
            AssignAttri("", false, "AV14FinalizarReembolso", AV14FinalizarReembolso);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFinalizarreembolso.CurrentValue = StringUtil.BoolToStr( AV14FinalizarReembolso);
            AssignProp("", false, cmbavFinalizarreembolso_Internalname, "Values", cmbavFinalizarreembolso.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavPropostapacienteclienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavPropostapacienteclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial_Enabled), 5, 0), true);
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavPropostavalor_Enabled = 0;
         AssignProp("", false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
         edtavReembolsosaldovalor_Enabled = 0;
         AssignProp("", false, edtavReembolsosaldovalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsosaldovalor_Enabled), 5, 0), true);
         edtavInitialdate_Enabled = 0;
         AssignProp("", false, edtavInitialdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavInitialdate_Enabled), 5, 0), true);
         edtavProcedimentosmedicosnome_Enabled = 0;
         AssignProp("", false, edtavProcedimentosmedicosnome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProcedimentosmedicosnome_Enabled), 5, 0), true);
         edtavReembolsoparcelastaxavalor_Enabled = 0;
         AssignProp("", false, edtavReembolsoparcelastaxavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsoparcelastaxavalor_Enabled), 5, 0), true);
         edtavReembolsoparcelasjurosvalor_Enabled = 0;
         AssignProp("", false, edtavReembolsoparcelasjurosvalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsoparcelasjurosvalor_Enabled), 5, 0), true);
         edtavReembolsoparcelasdiaspjuros_Enabled = 0;
         AssignProp("", false, edtavReembolsoparcelasdiaspjuros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsoparcelasdiaspjuros_Enabled), 5, 0), true);
      }

      protected void RF7Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E147Q2 ();
            WB7Q0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7Q2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOSALDOVALOR", GetSecureSignedToken( "", context.localUtil.Format( AV31ReembolsoSaldoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vINITIALDATE", GetSecureSignedToken( "", AV22InitialDate, context));
         GxWebStd.gx_hidden_field( context, "vJUROSPORDIA", StringUtil.LTrim( StringUtil.NToC( AV28JurosPorDia, 9, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vJUROSPORDIA", GetSecureSignedToken( "", context.localUtil.Format( AV28JurosPorDia, "ZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vCONTRATOTAXA", StringUtil.LTrim( StringUtil.NToC( AV24ContratoTaxa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOTAXA", GetSecureSignedToken( "", context.localUtil.Format( AV24ContratoTaxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         GxWebStd.gx_hidden_field( context, "vIOFVALOR", StringUtil.LTrim( StringUtil.NToC( AV39IOFValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIOFVALOR", GetSecureSignedToken( "", context.localUtil.Format( AV39IOFValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
      }

      protected void before_start_formulas( )
      {
         edtavPropostapacienteclienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavPropostapacienteclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostapacienteclienterazaosocial_Enabled), 5, 0), true);
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavPropostavalor_Enabled = 0;
         AssignProp("", false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
         edtavReembolsosaldovalor_Enabled = 0;
         AssignProp("", false, edtavReembolsosaldovalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsosaldovalor_Enabled), 5, 0), true);
         edtavInitialdate_Enabled = 0;
         AssignProp("", false, edtavInitialdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavInitialdate_Enabled), 5, 0), true);
         edtavProcedimentosmedicosnome_Enabled = 0;
         AssignProp("", false, edtavProcedimentosmedicosnome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProcedimentosmedicosnome_Enabled), 5, 0), true);
         edtavReembolsoparcelastaxavalor_Enabled = 0;
         AssignProp("", false, edtavReembolsoparcelastaxavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsoparcelastaxavalor_Enabled), 5, 0), true);
         edtavReembolsoparcelasjurosvalor_Enabled = 0;
         AssignProp("", false, edtavReembolsoparcelasjurosvalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsoparcelasjurosvalor_Enabled), 5, 0), true);
         edtavReembolsoparcelasdiaspjuros_Enabled = 0;
         AssignProp("", false, edtavReembolsoparcelasdiaspjuros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsoparcelasdiaspjuros_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E127Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vTIPOPAGAMENTOID_DATA"), AV35TipoPagamentoId_Data);
            /* Read saved values. */
            AV24ContratoTaxa = context.localUtil.CToN( cgiGet( "vCONTRATOTAXA"), ",", ".");
            AssignAttri("", false, "AV24ContratoTaxa", StringUtil.LTrimStr( AV24ContratoTaxa, 16, 4));
            GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOTAXA", GetSecureSignedToken( "", context.localUtil.Format( AV24ContratoTaxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
            AV28JurosPorDia = context.localUtil.CToN( cgiGet( "vJUROSPORDIA"), ",", ".");
            AssignAttri("", false, "AV28JurosPorDia", StringUtil.LTrimStr( AV28JurosPorDia, 9, 2));
            GxWebStd.gx_hidden_field( context, "gxhash_vJUROSPORDIA", GetSecureSignedToken( "", context.localUtil.Format( AV28JurosPorDia, "ZZZZZ9.99"), context));
            AV29DiaValor = context.localUtil.CToN( cgiGet( "vDIAVALOR"), ",", ".");
            AV39IOFValor = context.localUtil.CToN( cgiGet( "vIOFVALOR"), ",", ".");
            AssignAttri("", false, "AV39IOFValor", StringUtil.LTrimStr( AV39IOFValor, 18, 2));
            GxWebStd.gx_hidden_field( context, "gxhash_vIOFVALOR", GetSecureSignedToken( "", context.localUtil.Format( AV39IOFValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            Combo_tipopagamentoid_Cls = cgiGet( "COMBO_TIPOPAGAMENTOID_Cls");
            Combo_tipopagamentoid_Selectedvalue_set = cgiGet( "COMBO_TIPOPAGAMENTOID_Selectedvalue_set");
            Combo_tipopagamentoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Emptyitem"));
            Combo_tipopagamentoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Includeaddnewoption"));
            Ucmessage_Width = cgiGet( "UCMESSAGE_Width");
            Ucmessage_Minheight = cgiGet( "UCMESSAGE_Minheight");
            Ucmessage_Stylingtype = cgiGet( "UCMESSAGE_Stylingtype");
            Ucmessage_Stoponerror = StringUtil.StrToBool( cgiGet( "UCMESSAGE_Stoponerror"));
            Ucmessage_Effectin = cgiGet( "UCMESSAGE_Effectin");
            Ucmessage_Effectout = cgiGet( "UCMESSAGE_Effectout");
            Ucmessage_Animationspeed = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCMESSAGE_Animationspeed"), ",", "."), 18, MidpointRounding.ToEven));
            Ucmessage_Startposition = cgiGet( "UCMESSAGE_Startposition");
            Ucmessage_Nextmessageposition = cgiGet( "UCMESSAGE_Nextmessageposition");
            Combo_tipopagamentoid_Ddointernalname = cgiGet( "COMBO_TIPOPAGAMENTOID_Ddointernalname");
            Combo_tipopagamentoid_Selectedvalue_get = cgiGet( "COMBO_TIPOPAGAMENTOID_Selectedvalue_get");
            /* Read variables values. */
            AV10PropostaPacienteClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavPropostapacienteclienterazaosocial_Internalname));
            AssignAttri("", false, "AV10PropostaPacienteClienteRazaoSocial", AV10PropostaPacienteClienteRazaoSocial);
            AV11ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AssignAttri("", false, "AV11ClienteRazaoSocial", AV11ClienteRazaoSocial);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAVALOR");
               GX_FocusControl = edtavPropostavalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5PropostaValor = 0;
               AssignAttri("", false, "AV5PropostaValor", StringUtil.LTrimStr( AV5PropostaValor, 18, 2));
            }
            else
            {
               AV5PropostaValor = context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".");
               AssignAttri("", false, "AV5PropostaValor", StringUtil.LTrimStr( AV5PropostaValor, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavReembolsosaldovalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavReembolsosaldovalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREEMBOLSOSALDOVALOR");
               GX_FocusControl = edtavReembolsosaldovalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31ReembolsoSaldoValor = 0;
               AssignAttri("", false, "AV31ReembolsoSaldoValor", StringUtil.LTrimStr( AV31ReembolsoSaldoValor, 18, 2));
               GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOSALDOVALOR", GetSecureSignedToken( "", context.localUtil.Format( AV31ReembolsoSaldoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            }
            else
            {
               AV31ReembolsoSaldoValor = context.localUtil.CToN( cgiGet( edtavReembolsosaldovalor_Internalname), ",", ".");
               AssignAttri("", false, "AV31ReembolsoSaldoValor", StringUtil.LTrimStr( AV31ReembolsoSaldoValor, 18, 2));
               GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOSALDOVALOR", GetSecureSignedToken( "", context.localUtil.Format( AV31ReembolsoSaldoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavInitialdate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Initial Date"}), 1, "vINITIALDATE");
               GX_FocusControl = edtavInitialdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22InitialDate = DateTime.MinValue;
               AssignAttri("", false, "AV22InitialDate", context.localUtil.Format(AV22InitialDate, "99/99/9999"));
               GxWebStd.gx_hidden_field( context, "gxhash_vINITIALDATE", GetSecureSignedToken( "", AV22InitialDate, context));
            }
            else
            {
               AV22InitialDate = context.localUtil.CToD( cgiGet( edtavInitialdate_Internalname), 2);
               AssignAttri("", false, "AV22InitialDate", context.localUtil.Format(AV22InitialDate, "99/99/9999"));
               GxWebStd.gx_hidden_field( context, "gxhash_vINITIALDATE", GetSecureSignedToken( "", AV22InitialDate, context));
            }
            AV30ProcedimentosMedicosNome = cgiGet( edtavProcedimentosmedicosnome_Internalname);
            AssignAttri("", false, "AV30ProcedimentosMedicosNome", AV30ProcedimentosMedicosNome);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavReembolsoparcelasvalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavReembolsoparcelasvalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREEMBOLSOPARCELASVALOR");
               GX_FocusControl = edtavReembolsoparcelasvalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6ReembolsoParcelasValor = 0;
               AssignAttri("", false, "AV6ReembolsoParcelasValor", StringUtil.LTrimStr( AV6ReembolsoParcelasValor, 18, 2));
            }
            else
            {
               AV6ReembolsoParcelasValor = context.localUtil.CToN( cgiGet( edtavReembolsoparcelasvalor_Internalname), ",", ".");
               AssignAttri("", false, "AV6ReembolsoParcelasValor", StringUtil.LTrimStr( AV6ReembolsoParcelasValor, 18, 2));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavReembolsoparcelasdata_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Reembolso Parcelas Data"}), 1, "vREEMBOLSOPARCELASDATA");
               GX_FocusControl = edtavReembolsoparcelasdata_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12ReembolsoParcelasData = DateTime.MinValue;
               AssignAttri("", false, "AV12ReembolsoParcelasData", context.localUtil.Format(AV12ReembolsoParcelasData, "99/99/9999"));
            }
            else
            {
               AV12ReembolsoParcelasData = context.localUtil.CToD( cgiGet( edtavReembolsoparcelasdata_Internalname), 2);
               AssignAttri("", false, "AV12ReembolsoParcelasData", context.localUtil.Format(AV12ReembolsoParcelasData, "99/99/9999"));
            }
            AV13ReembolsoParcelasObservacao = cgiGet( edtavReembolsoparcelasobservacao_Internalname);
            AssignAttri("", false, "AV13ReembolsoParcelasObservacao", AV13ReembolsoParcelasObservacao);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavReembolsoparcelastaxavalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavReembolsoparcelastaxavalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREEMBOLSOPARCELASTAXAVALOR");
               GX_FocusControl = edtavReembolsoparcelastaxavalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16ReembolsoParcelasTaxaValor = 0;
               AssignAttri("", false, "AV16ReembolsoParcelasTaxaValor", StringUtil.LTrimStr( AV16ReembolsoParcelasTaxaValor, 18, 2));
            }
            else
            {
               AV16ReembolsoParcelasTaxaValor = context.localUtil.CToN( cgiGet( edtavReembolsoparcelastaxavalor_Internalname), ",", ".");
               AssignAttri("", false, "AV16ReembolsoParcelasTaxaValor", StringUtil.LTrimStr( AV16ReembolsoParcelasTaxaValor, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavReembolsoparcelasjurosvalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavReembolsoparcelasjurosvalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREEMBOLSOPARCELASJUROSVALOR");
               GX_FocusControl = edtavReembolsoparcelasjurosvalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17ReembolsoParcelasJurosValor = 0;
               AssignAttri("", false, "AV17ReembolsoParcelasJurosValor", StringUtil.LTrimStr( AV17ReembolsoParcelasJurosValor, 18, 2));
            }
            else
            {
               AV17ReembolsoParcelasJurosValor = context.localUtil.CToN( cgiGet( edtavReembolsoparcelasjurosvalor_Internalname), ",", ".");
               AssignAttri("", false, "AV17ReembolsoParcelasJurosValor", StringUtil.LTrimStr( AV17ReembolsoParcelasJurosValor, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavReembolsoparcelasdiaspjuros_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavReembolsoparcelasdiaspjuros_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREEMBOLSOPARCELASDIASPJUROS");
               GX_FocusControl = edtavReembolsoparcelasdiaspjuros_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18ReembolsoParcelasDiasPJuros = 0;
               AssignAttri("", false, "AV18ReembolsoParcelasDiasPJuros", StringUtil.LTrimStr( (decimal)(AV18ReembolsoParcelasDiasPJuros), 4, 0));
            }
            else
            {
               AV18ReembolsoParcelasDiasPJuros = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavReembolsoparcelasdiaspjuros_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18ReembolsoParcelasDiasPJuros", StringUtil.LTrimStr( (decimal)(AV18ReembolsoParcelasDiasPJuros), 4, 0));
            }
            cmbavFinalizarreembolso.CurrentValue = cgiGet( cmbavFinalizarreembolso_Internalname);
            AV14FinalizarReembolso = StringUtil.StrToBool( cgiGet( cmbavFinalizarreembolso_Internalname));
            AssignAttri("", false, "AV14FinalizarReembolso", AV14FinalizarReembolso);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTipopagamentoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTipopagamentoid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIPOPAGAMENTOID");
               GX_FocusControl = edtavTipopagamentoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34TipoPagamentoId = 0;
               AssignAttri("", false, "AV34TipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV34TipoPagamentoId), 9, 0));
            }
            else
            {
               AV34TipoPagamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavTipopagamentoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV34TipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV34TipoPagamentoId), 9, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"EfetivarReembolso");
            AV31ReembolsoSaldoValor = context.localUtil.CToN( cgiGet( edtavReembolsosaldovalor_Internalname), ",", ".");
            AssignAttri("", false, "AV31ReembolsoSaldoValor", StringUtil.LTrimStr( AV31ReembolsoSaldoValor, 18, 2));
            GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOSALDOVALOR", GetSecureSignedToken( "", context.localUtil.Format( AV31ReembolsoSaldoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            forbiddenHiddens.Add("ReembolsoSaldoValor", context.localUtil.Format( AV31ReembolsoSaldoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
            AV22InitialDate = context.localUtil.CToD( cgiGet( edtavInitialdate_Internalname), 2);
            AssignAttri("", false, "AV22InitialDate", context.localUtil.Format(AV22InitialDate, "99/99/9999"));
            GxWebStd.gx_hidden_field( context, "gxhash_vINITIALDATE", GetSecureSignedToken( "", AV22InitialDate, context));
            forbiddenHiddens.Add("InitialDate", context.localUtil.Format(AV22InitialDate, "99/99/9999"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("efetivarreembolso:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E127Q2 ();
         if (returnInSub) return;
      }

      protected void E127Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H007Q2 */
         pr_default.execute(0, new Object[] {AV20PropostaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A376ProcedimentosMedicosId = H007Q2_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = H007Q2_n376ProcedimentosMedicosId[0];
            A504PropostaPacienteClienteId = H007Q2_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = H007Q2_n504PropostaPacienteClienteId[0];
            A323PropostaId = H007Q2_A323PropostaId[0];
            A505PropostaPacienteClienteRazaoSocial = H007Q2_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H007Q2_n505PropostaPacienteClienteRazaoSocial[0];
            A643PropostaClinicaNome = H007Q2_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = H007Q2_n643PropostaClinicaNome[0];
            A326PropostaValor = H007Q2_A326PropostaValor[0];
            n326PropostaValor = H007Q2_n326PropostaValor[0];
            A327PropostaCreatedAt = H007Q2_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = H007Q2_n327PropostaCreatedAt[0];
            A377ProcedimentosMedicosNome = H007Q2_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = H007Q2_n377ProcedimentosMedicosNome[0];
            A642PropostaClinicaId = H007Q2_A642PropostaClinicaId[0];
            n642PropostaClinicaId = H007Q2_n642PropostaClinicaId[0];
            A377ProcedimentosMedicosNome = H007Q2_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = H007Q2_n377ProcedimentosMedicosNome[0];
            A505PropostaPacienteClienteRazaoSocial = H007Q2_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H007Q2_n505PropostaPacienteClienteRazaoSocial[0];
            A643PropostaClinicaNome = H007Q2_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = H007Q2_n643PropostaClinicaNome[0];
            AV10PropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            AssignAttri("", false, "AV10PropostaPacienteClienteRazaoSocial", AV10PropostaPacienteClienteRazaoSocial);
            AV11ClienteRazaoSocial = A643PropostaClinicaNome;
            AssignAttri("", false, "AV11ClienteRazaoSocial", AV11ClienteRazaoSocial);
            AV5PropostaValor = A326PropostaValor;
            AssignAttri("", false, "AV5PropostaValor", StringUtil.LTrimStr( AV5PropostaValor, 18, 2));
            AV22InitialDate = DateTimeUtil.ResetTime(A327PropostaCreatedAt);
            AssignAttri("", false, "AV22InitialDate", context.localUtil.Format(AV22InitialDate, "99/99/9999"));
            GxWebStd.gx_hidden_field( context, "gxhash_vINITIALDATE", GetSecureSignedToken( "", AV22InitialDate, context));
            AV30ProcedimentosMedicosNome = A377ProcedimentosMedicosNome;
            AssignAttri("", false, "AV30ProcedimentosMedicosNome", AV30ProcedimentosMedicosNome);
            new getclinicataxbyclienteid(context ).execute(  A642PropostaClinicaId, out  AV24ContratoTaxa, out  AV25ContratoSLA, out  AV26ContratoJurosMora, out  AV27ContratoIOFMinimo) ;
            AssignAttri("", false, "AV24ContratoTaxa", StringUtil.LTrimStr( AV24ContratoTaxa, 16, 4));
            GxWebStd.gx_hidden_field( context, "gxhash_vCONTRATOTAXA", GetSecureSignedToken( "", context.localUtil.Format( AV24ContratoTaxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor H007Q4 */
         pr_default.execute(1, new Object[] {AV19ReembolsoId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A518ReembolsoId = H007Q4_A518ReembolsoId[0];
            n518ReembolsoId = H007Q4_n518ReembolsoId[0];
            A645ReembolsoValorReembolsado_F = H007Q4_A645ReembolsoValorReembolsado_F[0];
            n645ReembolsoValorReembolsado_F = H007Q4_n645ReembolsoValorReembolsado_F[0];
            A645ReembolsoValorReembolsado_F = H007Q4_A645ReembolsoValorReembolsado_F[0];
            n645ReembolsoValorReembolsado_F = H007Q4_n645ReembolsoValorReembolsado_F[0];
            AV32ReembolsoValorReembolsado_F = A645ReembolsoValorReembolsado_F;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV31ReembolsoSaldoValor = (decimal)(AV5PropostaValor-AV32ReembolsoValorReembolsado_F);
         AssignAttri("", false, "AV31ReembolsoSaldoValor", StringUtil.LTrimStr( AV31ReembolsoSaldoValor, 18, 2));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOSALDOVALOR", GetSecureSignedToken( "", context.localUtil.Format( AV31ReembolsoSaldoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         AV28JurosPorDia = (decimal)(AV26ContratoJurosMora/ (decimal)(30));
         AssignAttri("", false, "AV28JurosPorDia", StringUtil.LTrimStr( AV28JurosPorDia, 9, 2));
         GxWebStd.gx_hidden_field( context, "gxhash_vJUROSPORDIA", GetSecureSignedToken( "", context.localUtil.Format( AV28JurosPorDia, "ZZZZZ9.99"), context));
         if ( ! (Convert.ToDecimal(0)==AV27ContratoIOFMinimo) )
         {
            AV39IOFValor = (decimal)(AV5PropostaValor*(AV27ContratoIOFMinimo/ (decimal)(100)));
            AssignAttri("", false, "AV39IOFValor", StringUtil.LTrimStr( AV39IOFValor, 18, 2));
            GxWebStd.gx_hidden_field( context, "gxhash_vIOFVALOR", GetSecureSignedToken( "", context.localUtil.Format( AV39IOFValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         }
         edtavTipopagamentoid_Visible = 0;
         AssignProp("", false, edtavTipopagamentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipopagamentoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTIPOPAGAMENTOID' */
         S112 ();
         if (returnInSub) return;
         cmbavFinalizarreembolso.Visible = 0;
         AssignProp("", false, cmbavFinalizarreembolso_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavFinalizarreembolso.Visible), 5, 0), true);
      }

      protected void E137Q2( )
      {
         /* 'DoConfirmar' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV15CheckRequiredFieldsResult )
         {
            new prefetivarreembolso(context ).execute(  AV20PropostaId,  AV19ReembolsoId,  AV12ReembolsoParcelasData,  AV18ReembolsoParcelasDiasPJuros,  AV17ReembolsoParcelasJurosValor,  AV13ReembolsoParcelasObservacao,  AV16ReembolsoParcelasTaxaValor,  AV6ReembolsoParcelasValor,  AV14FinalizarReembolso,  AV31ReembolsoSaldoValor,  AV34TipoPagamentoId, out  AV33SdErro) ;
            if ( AV33SdErro.gxTpr_Internalcode == 0 )
            {
               context.CommitDataStores("efetivarreembolso",pr_default);
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               context.RollbackDataStores("efetivarreembolso",pr_default);
               GXt_char1 = AV33SdErro.gxTpr_Msg;
               new message(context ).gxep_erro( ref  GXt_char1) ;
               AV33SdErro.gxTpr_Msg = GXt_char1;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E117Q2( )
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
            AV37ComboSelectedValue = AV38Session.Get("TIPOPAGAMENTOID");
            AV38Session.Remove("TIPOPAGAMENTOID");
            Combo_tipopagamentoid_Selectedvalue_set = AV37ComboSelectedValue;
            ucCombo_tipopagamentoid.SendProperty(context, "", false, Combo_tipopagamentoid_Internalname, "SelectedValue_set", Combo_tipopagamentoid_Selectedvalue_set);
            AV34TipoPagamentoId = (int)(Math.Round(NumberUtil.Val( AV37ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV34TipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV34TipoPagamentoId), 9, 0));
         }
         else
         {
            AV34TipoPagamentoId = (int)(Math.Round(NumberUtil.Val( Combo_tipopagamentoid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV34TipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV34TipoPagamentoId), 9, 0));
            /* Execute user subroutine: 'LOADCOMBOTIPOPAGAMENTOID' */
            S112 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35TipoPagamentoId_Data", AV35TipoPagamentoId_Data);
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV15CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV15CheckRequiredFieldsResult", AV15CheckRequiredFieldsResult);
         if ( (Convert.ToDecimal(0)==AV6ReembolsoParcelasValor) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Digite o valor para reembolso",  "error",  edtavReembolsoparcelasvalor_Internalname,  "true",  ""));
            AV15CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV15CheckRequiredFieldsResult", AV15CheckRequiredFieldsResult);
         }
         if ( (DateTime.MinValue==AV12ReembolsoParcelasData) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Digite a data que foi feito o reembolso",  "error",  edtavReembolsoparcelasdata_Internalname,  "true",  ""));
            AV15CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV15CheckRequiredFieldsResult", AV15CheckRequiredFieldsResult);
         }
         if ( (0==AV34TipoPagamentoId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Escolha o tipo de pagamento",  "error",  Combo_tipopagamentoid_Ddointernalname,  "true",  ""));
            AV15CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV15CheckRequiredFieldsResult", AV15CheckRequiredFieldsResult);
         }
         if ( AV31ReembolsoSaldoValor < AV6ReembolsoParcelasValor )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Valor excede o saldo dessa proposta",  "error",  edtavReembolsoparcelasvalor_Internalname,  "true",  ""));
            AV15CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV15CheckRequiredFieldsResult", AV15CheckRequiredFieldsResult);
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOTIPOPAGAMENTOID' Routine */
         returnInSub = false;
         AV35TipoPagamentoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H007Q5 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A288TipoPagamentoId = H007Q5_A288TipoPagamentoId[0];
            A289TipoPagamentoNome = H007Q5_A289TipoPagamentoNome[0];
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A288TipoPagamentoId), 9, 0));
            AV36Combo_DataItem.gxTpr_Title = A289TipoPagamentoNome;
            AV35TipoPagamentoId_Data.Add(AV36Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_tipopagamentoid_Selectedvalue_set = ((0==AV34TipoPagamentoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV34TipoPagamentoId), 9, 0)));
         ucCombo_tipopagamentoid.SendProperty(context, "", false, Combo_tipopagamentoid_Internalname, "SelectedValue_set", Combo_tipopagamentoid_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E147Q2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_87_7Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedfinalizarreembolso_Internalname, tblTablemergedfinalizarreembolso_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFinalizarreembolso_Internalname, "Finalizar Reembolso", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFinalizarreembolso, cmbavFinalizarreembolso_Internalname, StringUtil.BoolToStr( AV14FinalizarReembolso), 1, cmbavFinalizarreembolso_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavFinalizarreembolso.Visible, cmbavFinalizarreembolso.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_EfetivarReembolso.htm");
            cmbavFinalizarreembolso.CurrentValue = StringUtil.BoolToStr( AV14FinalizarReembolso);
            AssignProp("", false, cmbavFinalizarreembolso_Internalname, "Values", (string)(cmbavFinalizarreembolso.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFinalizarreembolso_righttext_Internalname, "Se sim vamos fechar o reembolso e não esperamos uma reanalize.", "", "", lblFinalizarreembolso_righttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_EfetivarReembolso.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_87_7Q2e( true) ;
         }
         else
         {
            wb_table1_87_7Q2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV19ReembolsoId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV19ReembolsoId", StringUtil.LTrimStr( (decimal)(AV19ReembolsoId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19ReembolsoId), "ZZZZZZZZ9"), context));
         AV20PropostaId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV20PropostaId", StringUtil.LTrimStr( (decimal)(AV20PropostaId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20PropostaId), "ZZZZZZZZ9"), context));
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
         PA7Q2( ) ;
         WS7Q2( ) ;
         WE7Q2( ) ;
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
         AddStyleSheetFile("DVelop/DVMessage/DVMessage.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019265223", true, true);
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
         context.AddJavascriptSource("efetivarreembolso.js", "?202561019265223", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavFinalizarreembolso.Name = "vFINALIZARREEMBOLSO";
         cmbavFinalizarreembolso.WebTags = "";
         cmbavFinalizarreembolso.addItem(StringUtil.BoolToStr( false), "Não", 0);
         cmbavFinalizarreembolso.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         if ( cmbavFinalizarreembolso.ItemCount > 0 )
         {
            AV14FinalizarReembolso = StringUtil.StrToBool( cmbavFinalizarreembolso.getValidValue(StringUtil.BoolToStr( AV14FinalizarReembolso)));
            AssignAttri("", false, "AV14FinalizarReembolso", AV14FinalizarReembolso);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnconfirmar_Internalname = "BTNCONFIRMAR";
         edtavPropostapacienteclienterazaosocial_Internalname = "vPROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         edtavClienterazaosocial_Internalname = "vCLIENTERAZAOSOCIAL";
         edtavPropostavalor_Internalname = "vPROPOSTAVALOR";
         edtavReembolsosaldovalor_Internalname = "vREEMBOLSOSALDOVALOR";
         edtavInitialdate_Internalname = "vINITIALDATE";
         edtavProcedimentosmedicosnome_Internalname = "vPROCEDIMENTOSMEDICOSNOME";
         edtavReembolsoparcelasvalor_Internalname = "vREEMBOLSOPARCELASVALOR";
         edtavReembolsoparcelasdata_Internalname = "vREEMBOLSOPARCELASDATA";
         lblTextblockcombo_tipopagamentoid_Internalname = "TEXTBLOCKCOMBO_TIPOPAGAMENTOID";
         Combo_tipopagamentoid_Internalname = "COMBO_TIPOPAGAMENTOID";
         divTablesplittedtipopagamentoid_Internalname = "TABLESPLITTEDTIPOPAGAMENTOID";
         edtavReembolsoparcelasobservacao_Internalname = "vREEMBOLSOPARCELASOBSERVACAO";
         edtavReembolsoparcelastaxavalor_Internalname = "vREEMBOLSOPARCELASTAXAVALOR";
         edtavReembolsoparcelasjurosvalor_Internalname = "vREEMBOLSOPARCELASJUROSVALOR";
         edtavReembolsoparcelasdiaspjuros_Internalname = "vREEMBOLSOPARCELASDIASPJUROS";
         divTabletaxa_Internalname = "TABLETAXA";
         lblTextblockfinalizarreembolso_Internalname = "TEXTBLOCKFINALIZARREEMBOLSO";
         cmbavFinalizarreembolso_Internalname = "vFINALIZARREEMBOLSO";
         lblFinalizarreembolso_righttext_Internalname = "FINALIZARREEMBOLSO_RIGHTTEXT";
         tblTablemergedfinalizarreembolso_Internalname = "TABLEMERGEDFINALIZARREEMBOLSO";
         divTablesplittedfinalizarreembolso_Internalname = "TABLESPLITTEDFINALIZARREEMBOLSO";
         divTablecontent_Internalname = "TABLECONTENT";
         Ucmessage_Internalname = "UCMESSAGE";
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
         cmbavFinalizarreembolso_Jsonclick = "";
         cmbavFinalizarreembolso.Enabled = 1;
         cmbavFinalizarreembolso.Visible = 1;
         edtavTipopagamentoid_Jsonclick = "";
         edtavTipopagamentoid_Visible = 1;
         edtavReembolsoparcelasdiaspjuros_Jsonclick = "";
         edtavReembolsoparcelasdiaspjuros_Enabled = 1;
         edtavReembolsoparcelasjurosvalor_Jsonclick = "";
         edtavReembolsoparcelasjurosvalor_Enabled = 1;
         edtavReembolsoparcelastaxavalor_Jsonclick = "";
         edtavReembolsoparcelastaxavalor_Enabled = 1;
         edtavReembolsoparcelasobservacao_Jsonclick = "";
         edtavReembolsoparcelasobservacao_Enabled = 1;
         edtavReembolsoparcelasdata_Jsonclick = "";
         edtavReembolsoparcelasdata_Enabled = 1;
         edtavReembolsoparcelasvalor_Jsonclick = "";
         edtavReembolsoparcelasvalor_Enabled = 1;
         edtavProcedimentosmedicosnome_Enabled = 1;
         edtavInitialdate_Jsonclick = "";
         edtavInitialdate_Enabled = 1;
         edtavReembolsosaldovalor_Jsonclick = "";
         edtavReembolsosaldovalor_Enabled = 1;
         edtavPropostavalor_Jsonclick = "";
         edtavPropostavalor_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         edtavPropostapacienteclienterazaosocial_Jsonclick = "";
         edtavPropostapacienteclienterazaosocial_Enabled = 1;
         Ucmessage_Nextmessageposition = "down";
         Ucmessage_Startposition = "TopRight";
         Ucmessage_Animationspeed = 300;
         Ucmessage_Effectout = "slide";
         Ucmessage_Effectin = "slide";
         Ucmessage_Stoponerror = Convert.ToBoolean( -1);
         Ucmessage_Stylingtype = "fontawesome";
         Ucmessage_Minheight = "16";
         Ucmessage_Width = "500";
         Combo_tipopagamentoid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_tipopagamentoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_tipopagamentoid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Efetivar Reembolso";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV20PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV28JurosPorDia","fld":"vJUROSPORDIA","pic":"ZZZZZ9.99","hsh":true,"type":"decimal"},{"av":"AV24ContratoTaxa","fld":"vCONTRATOTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV39IOFValor","fld":"vIOFVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"AV31ReembolsoSaldoValor","fld":"vREEMBOLSOSALDOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"AV22InitialDate","fld":"vINITIALDATE","hsh":true,"type":"date"}]}""");
         setEventMetadata("'DOCONFIRMAR'","""{"handler":"E137Q2","iparms":[{"av":"AV15CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV20PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19ReembolsoId","fld":"vREEMBOLSOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV12ReembolsoParcelasData","fld":"vREEMBOLSOPARCELASDATA","type":"date"},{"av":"AV18ReembolsoParcelasDiasPJuros","fld":"vREEMBOLSOPARCELASDIASPJUROS","pic":"ZZZ9","type":"int"},{"av":"AV17ReembolsoParcelasJurosValor","fld":"vREEMBOLSOPARCELASJUROSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV13ReembolsoParcelasObservacao","fld":"vREEMBOLSOPARCELASOBSERVACAO","type":"svchar"},{"av":"AV16ReembolsoParcelasTaxaValor","fld":"vREEMBOLSOPARCELASTAXAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV6ReembolsoParcelasValor","fld":"vREEMBOLSOPARCELASVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavFinalizarreembolso"},{"av":"AV14FinalizarReembolso","fld":"vFINALIZARREEMBOLSO","type":"boolean"},{"av":"AV31ReembolsoSaldoValor","fld":"vREEMBOLSOSALDOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"AV34TipoPagamentoId","fld":"vTIPOPAGAMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Combo_tipopagamentoid_Ddointernalname","ctrl":"COMBO_TIPOPAGAMENTOID","prop":"DDOInternalName"}]""");
         setEventMetadata("'DOCONFIRMAR'",""","oparms":[{"av":"AV15CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("COMBO_TIPOPAGAMENTOID.ONOPTIONCLICKED","""{"handler":"E117Q2","iparms":[{"av":"Combo_tipopagamentoid_Selectedvalue_get","ctrl":"COMBO_TIPOPAGAMENTOID","prop":"SelectedValue_get"},{"av":"A288TipoPagamentoId","fld":"TIPOPAGAMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A289TipoPagamentoNome","fld":"TIPOPAGAMENTONOME","type":"svchar"},{"av":"AV34TipoPagamentoId","fld":"vTIPOPAGAMENTOID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("COMBO_TIPOPAGAMENTOID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_tipopagamentoid_Selectedvalue_set","ctrl":"COMBO_TIPOPAGAMENTOID","prop":"SelectedValue_set"},{"av":"AV34TipoPagamentoId","fld":"vTIPOPAGAMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35TipoPagamentoId_Data","fld":"vTIPOPAGAMENTOID_DATA","type":""}]}""");
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
         Combo_tipopagamentoid_Ddointernalname = "";
         Combo_tipopagamentoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV22InitialDate = DateTime.MinValue;
         forbiddenHiddens = new GXProperties();
         AV35TipoPagamentoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A289TipoPagamentoNome = "";
         Combo_tipopagamentoid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnconfirmar_Jsonclick = "";
         AV10PropostaPacienteClienteRazaoSocial = "";
         AV11ClienteRazaoSocial = "";
         AV30ProcedimentosMedicosNome = "";
         AV12ReembolsoParcelasData = DateTime.MinValue;
         lblTextblockcombo_tipopagamentoid_Jsonclick = "";
         ucCombo_tipopagamentoid = new GXUserControl();
         Combo_tipopagamentoid_Caption = "";
         AV13ReembolsoParcelasObservacao = "";
         lblTextblockfinalizarreembolso_Jsonclick = "";
         ucUcmessage = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         hsh = "";
         H007Q2_A376ProcedimentosMedicosId = new int[1] ;
         H007Q2_n376ProcedimentosMedicosId = new bool[] {false} ;
         H007Q2_A504PropostaPacienteClienteId = new int[1] ;
         H007Q2_n504PropostaPacienteClienteId = new bool[] {false} ;
         H007Q2_A323PropostaId = new int[1] ;
         H007Q2_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H007Q2_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H007Q2_A643PropostaClinicaNome = new string[] {""} ;
         H007Q2_n643PropostaClinicaNome = new bool[] {false} ;
         H007Q2_A326PropostaValor = new decimal[1] ;
         H007Q2_n326PropostaValor = new bool[] {false} ;
         H007Q2_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H007Q2_n327PropostaCreatedAt = new bool[] {false} ;
         H007Q2_A377ProcedimentosMedicosNome = new string[] {""} ;
         H007Q2_n377ProcedimentosMedicosNome = new bool[] {false} ;
         H007Q2_A642PropostaClinicaId = new int[1] ;
         H007Q2_n642PropostaClinicaId = new bool[] {false} ;
         A505PropostaPacienteClienteRazaoSocial = "";
         A643PropostaClinicaNome = "";
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         A377ProcedimentosMedicosNome = "";
         H007Q4_A518ReembolsoId = new int[1] ;
         H007Q4_n518ReembolsoId = new bool[] {false} ;
         H007Q4_A645ReembolsoValorReembolsado_F = new decimal[1] ;
         H007Q4_n645ReembolsoValorReembolsado_F = new bool[] {false} ;
         AV33SdErro = new SdtSdErro(context);
         GXt_char1 = "";
         AV37ComboSelectedValue = "";
         AV38Session = context.GetSession();
         H007Q5_A288TipoPagamentoId = new int[1] ;
         H007Q5_A289TipoPagamentoNome = new string[] {""} ;
         AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         sStyleString = "";
         lblFinalizarreembolso_righttext_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.efetivarreembolso__default(),
            new Object[][] {
                new Object[] {
               H007Q2_A376ProcedimentosMedicosId, H007Q2_n376ProcedimentosMedicosId, H007Q2_A504PropostaPacienteClienteId, H007Q2_n504PropostaPacienteClienteId, H007Q2_A323PropostaId, H007Q2_A505PropostaPacienteClienteRazaoSocial, H007Q2_n505PropostaPacienteClienteRazaoSocial, H007Q2_A643PropostaClinicaNome, H007Q2_n643PropostaClinicaNome, H007Q2_A326PropostaValor,
               H007Q2_n326PropostaValor, H007Q2_A327PropostaCreatedAt, H007Q2_n327PropostaCreatedAt, H007Q2_A377ProcedimentosMedicosNome, H007Q2_n377ProcedimentosMedicosNome, H007Q2_A642PropostaClinicaId, H007Q2_n642PropostaClinicaId
               }
               , new Object[] {
               H007Q4_A518ReembolsoId, H007Q4_A645ReembolsoValorReembolsado_F, H007Q4_n645ReembolsoValorReembolsado_F
               }
               , new Object[] {
               H007Q5_A288TipoPagamentoId, H007Q5_A289TipoPagamentoNome
               }
            }
         );
         /* GeneXus formulas. */
         edtavPropostapacienteclienterazaosocial_Enabled = 0;
         edtavClienterazaosocial_Enabled = 0;
         edtavPropostavalor_Enabled = 0;
         edtavReembolsosaldovalor_Enabled = 0;
         edtavInitialdate_Enabled = 0;
         edtavProcedimentosmedicosnome_Enabled = 0;
         edtavReembolsoparcelastaxavalor_Enabled = 0;
         edtavReembolsoparcelasjurosvalor_Enabled = 0;
         edtavReembolsoparcelasdiaspjuros_Enabled = 0;
      }

      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV18ReembolsoParcelasDiasPJuros ;
      private short nDonePA ;
      private short AV25ContratoSLA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV19ReembolsoId ;
      private int AV20PropostaId ;
      private int wcpOAV19ReembolsoId ;
      private int wcpOAV20PropostaId ;
      private int A288TipoPagamentoId ;
      private int Ucmessage_Animationspeed ;
      private int edtavPropostapacienteclienterazaosocial_Enabled ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavPropostavalor_Enabled ;
      private int edtavReembolsosaldovalor_Enabled ;
      private int edtavInitialdate_Enabled ;
      private int edtavProcedimentosmedicosnome_Enabled ;
      private int edtavReembolsoparcelasvalor_Enabled ;
      private int edtavReembolsoparcelasdata_Enabled ;
      private int edtavReembolsoparcelasobservacao_Enabled ;
      private int edtavReembolsoparcelastaxavalor_Enabled ;
      private int edtavReembolsoparcelasjurosvalor_Enabled ;
      private int edtavReembolsoparcelasdiaspjuros_Enabled ;
      private int AV34TipoPagamentoId ;
      private int edtavTipopagamentoid_Visible ;
      private int A376ProcedimentosMedicosId ;
      private int A504PropostaPacienteClienteId ;
      private int A323PropostaId ;
      private int A642PropostaClinicaId ;
      private int A518ReembolsoId ;
      private int idxLst ;
      private decimal AV31ReembolsoSaldoValor ;
      private decimal AV28JurosPorDia ;
      private decimal AV24ContratoTaxa ;
      private decimal AV39IOFValor ;
      private decimal AV29DiaValor ;
      private decimal AV5PropostaValor ;
      private decimal AV6ReembolsoParcelasValor ;
      private decimal AV16ReembolsoParcelasTaxaValor ;
      private decimal AV17ReembolsoParcelasJurosValor ;
      private decimal A326PropostaValor ;
      private decimal AV26ContratoJurosMora ;
      private decimal AV27ContratoIOFMinimo ;
      private decimal A645ReembolsoValorReembolsado_F ;
      private decimal AV32ReembolsoValorReembolsado_F ;
      private string Combo_tipopagamentoid_Ddointernalname ;
      private string Combo_tipopagamentoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_tipopagamentoid_Cls ;
      private string Combo_tipopagamentoid_Selectedvalue_set ;
      private string Ucmessage_Width ;
      private string Ucmessage_Minheight ;
      private string Ucmessage_Stylingtype ;
      private string Ucmessage_Effectin ;
      private string Ucmessage_Effectout ;
      private string Ucmessage_Startposition ;
      private string Ucmessage_Nextmessageposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnconfirmar_Internalname ;
      private string bttBtnconfirmar_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string edtavPropostapacienteclienterazaosocial_Internalname ;
      private string edtavPropostapacienteclienterazaosocial_Jsonclick ;
      private string edtavClienterazaosocial_Internalname ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string edtavPropostavalor_Internalname ;
      private string edtavPropostavalor_Jsonclick ;
      private string edtavReembolsosaldovalor_Internalname ;
      private string edtavReembolsosaldovalor_Jsonclick ;
      private string edtavInitialdate_Internalname ;
      private string edtavInitialdate_Jsonclick ;
      private string edtavProcedimentosmedicosnome_Internalname ;
      private string edtavReembolsoparcelasvalor_Internalname ;
      private string edtavReembolsoparcelasvalor_Jsonclick ;
      private string edtavReembolsoparcelasdata_Internalname ;
      private string edtavReembolsoparcelasdata_Jsonclick ;
      private string divTablesplittedtipopagamentoid_Internalname ;
      private string lblTextblockcombo_tipopagamentoid_Internalname ;
      private string lblTextblockcombo_tipopagamentoid_Jsonclick ;
      private string Combo_tipopagamentoid_Caption ;
      private string Combo_tipopagamentoid_Internalname ;
      private string edtavReembolsoparcelasobservacao_Internalname ;
      private string edtavReembolsoparcelasobservacao_Jsonclick ;
      private string divTabletaxa_Internalname ;
      private string edtavReembolsoparcelastaxavalor_Internalname ;
      private string edtavReembolsoparcelastaxavalor_Jsonclick ;
      private string edtavReembolsoparcelasjurosvalor_Internalname ;
      private string edtavReembolsoparcelasjurosvalor_Jsonclick ;
      private string edtavReembolsoparcelasdiaspjuros_Internalname ;
      private string edtavReembolsoparcelasdiaspjuros_Jsonclick ;
      private string divTablesplittedfinalizarreembolso_Internalname ;
      private string lblTextblockfinalizarreembolso_Internalname ;
      private string lblTextblockfinalizarreembolso_Jsonclick ;
      private string Ucmessage_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavTipopagamentoid_Internalname ;
      private string edtavTipopagamentoid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string cmbavFinalizarreembolso_Internalname ;
      private string hsh ;
      private string GXt_char1 ;
      private string sStyleString ;
      private string tblTablemergedfinalizarreembolso_Internalname ;
      private string cmbavFinalizarreembolso_Jsonclick ;
      private string lblFinalizarreembolso_righttext_Internalname ;
      private string lblFinalizarreembolso_righttext_Jsonclick ;
      private DateTime A327PropostaCreatedAt ;
      private DateTime AV22InitialDate ;
      private DateTime AV12ReembolsoParcelasData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15CheckRequiredFieldsResult ;
      private bool Combo_tipopagamentoid_Emptyitem ;
      private bool Combo_tipopagamentoid_Includeaddnewoption ;
      private bool Ucmessage_Stoponerror ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV14FinalizarReembolso ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n376ProcedimentosMedicosId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n643PropostaClinicaNome ;
      private bool n326PropostaValor ;
      private bool n327PropostaCreatedAt ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n642PropostaClinicaId ;
      private bool n518ReembolsoId ;
      private bool n645ReembolsoValorReembolsado_F ;
      private string A289TipoPagamentoNome ;
      private string AV10PropostaPacienteClienteRazaoSocial ;
      private string AV11ClienteRazaoSocial ;
      private string AV30ProcedimentosMedicosNome ;
      private string AV13ReembolsoParcelasObservacao ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A643PropostaClinicaNome ;
      private string A377ProcedimentosMedicosNome ;
      private string AV37ComboSelectedValue ;
      private IGxSession AV38Session ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_tipopagamentoid ;
      private GXUserControl ucUcmessage ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavFinalizarreembolso ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV35TipoPagamentoId_Data ;
      private IDataStoreProvider pr_default ;
      private int[] H007Q2_A376ProcedimentosMedicosId ;
      private bool[] H007Q2_n376ProcedimentosMedicosId ;
      private int[] H007Q2_A504PropostaPacienteClienteId ;
      private bool[] H007Q2_n504PropostaPacienteClienteId ;
      private int[] H007Q2_A323PropostaId ;
      private string[] H007Q2_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H007Q2_n505PropostaPacienteClienteRazaoSocial ;
      private string[] H007Q2_A643PropostaClinicaNome ;
      private bool[] H007Q2_n643PropostaClinicaNome ;
      private decimal[] H007Q2_A326PropostaValor ;
      private bool[] H007Q2_n326PropostaValor ;
      private DateTime[] H007Q2_A327PropostaCreatedAt ;
      private bool[] H007Q2_n327PropostaCreatedAt ;
      private string[] H007Q2_A377ProcedimentosMedicosNome ;
      private bool[] H007Q2_n377ProcedimentosMedicosNome ;
      private int[] H007Q2_A642PropostaClinicaId ;
      private bool[] H007Q2_n642PropostaClinicaId ;
      private int[] H007Q4_A518ReembolsoId ;
      private bool[] H007Q4_n518ReembolsoId ;
      private decimal[] H007Q4_A645ReembolsoValorReembolsado_F ;
      private bool[] H007Q4_n645ReembolsoValorReembolsado_F ;
      private SdtSdErro AV33SdErro ;
      private int[] H007Q5_A288TipoPagamentoId ;
      private string[] H007Q5_A289TipoPagamentoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV36Combo_DataItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class efetivarreembolso__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH007Q2;
          prmH007Q2 = new Object[] {
          new ParDef("AV20PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH007Q4;
          prmH007Q4 = new Object[] {
          new ParDef("AV19ReembolsoId",GXType.Int32,9,0)
          };
          Object[] prmH007Q5;
          prmH007Q5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H007Q2", "SELECT T1.ProcedimentosMedicosId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaId, T3.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T4.ClienteRazaoSocial AS PropostaClinicaNome, T1.PropostaValor, T1.PropostaCreatedAt, T2.ProcedimentosMedicosNome, T1.PropostaClinicaId AS PropostaClinicaId FROM (((Proposta T1 LEFT JOIN ProcedimentosMedicos T2 ON T2.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaClinicaId) WHERE T1.PropostaId = :AV20PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007Q2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H007Q4", "SELECT T1.ReembolsoId, COALESCE( T2.ReembolsoValorReembolsado_F, 0) AS ReembolsoValorReembolsado_F FROM (Reembolso T1 LEFT JOIN LATERAL (SELECT SUM(ReembolsoParcelasValor) AS ReembolsoValorReembolsado_F, ReembolsoId FROM ReembolsoParcelas WHERE T1.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T2 ON T2.ReembolsoId = T1.ReembolsoId) WHERE T1.ReembolsoId = :AV19ReembolsoId ORDER BY T1.ReembolsoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007Q4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H007Q5", "SELECT TipoPagamentoId, TipoPagamentoNome FROM TipoPagamento ORDER BY TipoPagamentoNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007Q5,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
