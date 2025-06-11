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
namespace GeneXus.Programs {
   public class signature : GXDataArea
   {
      public signature( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public signature( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_AssinaturaParticipanteId ,
                           string aP1_Codigo )
      {
         this.AV5AssinaturaParticipanteId = aP0_AssinaturaParticipanteId;
         this.AV31Codigo = aP1_Codigo;
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
            gxfirstwebparm = GetFirstPar( "AssinaturaParticipanteId");
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
               gxfirstwebparm = GetFirstPar( "AssinaturaParticipanteId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AssinaturaParticipanteId");
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageempty", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageempty", new Object[] {context});
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
         PA4N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4N2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCPdfViewerRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCLocationRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Chronometer/ChronometerRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCIPRender.js", "", false, true);
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
         GXEncryptionTmp = "signature"+UrlEncode(StringUtil.LTrimStr(AV5AssinaturaParticipanteId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV31Codigo));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("signature") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11AssinaturaId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAUXASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12AuxAssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12AuxAssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPARTICIPANTEDOCUMENTO", AV26ParticipanteDocumento);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEDOCUMENTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26ParticipanteDocumento, "")), context));
         GxWebStd.gx_hidden_field( context, "vPARTICIPANTEEMAIL", AV27ParticipanteEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27ParticipanteEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "vASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCODIGO", AV31Codigo);
         GxWebStd.gx_hidden_field( context, "gxhash_vCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31Codigo, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11AssinaturaId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAUXASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12AuxAssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12AuxAssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPARTICIPANTEDOCUMENTO", AV26ParticipanteDocumento);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEDOCUMENTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26ParticipanteDocumento, "")), context));
         GxWebStd.gx_hidden_field( context, "vPARTICIPANTEEMAIL", AV27ParticipanteEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27ParticipanteEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "ASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ASSINATURAPARTICIPANTESTATUS", A353AssinaturaParticipanteStatus);
         GxWebStd.gx_hidden_field( context, "vTICK", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20Tick), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISSUCESS", AV21ISSucess);
         GxWebStd.gx_hidden_field( context, "vASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCODIGO", AV31Codigo);
         GxWebStd.gx_hidden_field( context, "gxhash_vCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31Codigo, "")), context));
         GxWebStd.gx_hidden_field( context, "DDC_PARTICIPANTES_Icontype", StringUtil.RTrim( Ddc_participantes_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_PARTICIPANTES_Icon", StringUtil.RTrim( Ddc_participantes_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_PARTICIPANTES_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_participantes_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PDFVIEWE_Path", StringUtil.RTrim( Pdfviewe_Path));
         GxWebStd.gx_hidden_field( context, "USERCONTROL2_Latitude", StringUtil.RTrim( Usercontrol2_Latitude));
         GxWebStd.gx_hidden_field( context, "USERCONTROL2_Longitude", StringUtil.RTrim( Usercontrol2_Longitude));
         GxWebStd.gx_hidden_field( context, "TIMER_Tickinterval", StringUtil.LTrim( StringUtil.NToC( (decimal)(Timer_Tickinterval), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCIP_Campoip", StringUtil.RTrim( Ucip_Campoip));
         GxWebStd.gx_hidden_field( context, "vHTTPREQUEST_Baseurl", StringUtil.RTrim( AV14HTTPRequest.BaseURL));
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
            WE4N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4N2( ) ;
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
         GXEncryptionTmp = "signature"+UrlEncode(StringUtil.LTrimStr(AV5AssinaturaParticipanteId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV31Codigo));
         return formatLink("signature") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "signature" ;
      }

      public override string GetPgmdesc( )
      {
         return "signature" ;
      }

      protected void WB4N0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCampos_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavIp_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavIp_Internalname, AV30IP, StringUtil.RTrim( context.localUtil.Format( AV30IP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavIp_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavIp_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_signature.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLongitudenumber_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLongitude_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLongitude_Internalname, AV16Longitude, StringUtil.RTrim( context.localUtil.Format( AV16Longitude, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLongitude_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavLongitude_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_signature.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLatitudenumber_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLatitude_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLatitude_Internalname, AV17Latitude, StringUtil.RTrim( context.localUtil.Format( AV17Latitude, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLatitude_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavLatitude_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_signature.htm");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_participantes.SetProperty("IconType", Ddc_participantes_Icontype);
            ucDdc_participantes.SetProperty("Icon", Ddc_participantes_Icon);
            ucDdc_participantes.SetProperty("Caption", Ddc_participantes_Caption);
            ucDdc_participantes.SetProperty("ComponentWidth", Ddc_participantes_Componentwidth);
            ucDdc_participantes.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_participantes_Internalname, "DDC_PARTICIPANTESContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepdf_Internalname, 1, 0, "px", 0, "px", "table-signature", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblThehtml_Internalname, "<div id=\"the-canvas\"></div>", "", "", lblThehtml_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_signature.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucPdfviewe.Render(context, "ucpdfviewer", Pdfviewe_Internalname, "PDFVIEWEContainer");
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
            GxWebStd.gx_div_start( context, divTablemensagem_Internalname, divTablemensagem_Visible, 0, "px", 0, "px", "table-footer-signature", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap;justify-content:center;align-items:center;align-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtmsg_Internalname, lblTxtmsg_Caption, "", "", lblTxtmsg_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_signature.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebuttons_Internalname, divTablebuttons_Visible, 0, "px", 0, "px", "table-footer-signature", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap;justify-content:center;align-items:center;align-content:space-around;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = "table-footer-signature-button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnassinar_Internalname, "", "Assinar", bttBtnassinar_Jsonclick, 5, "Assinar", "", StyleString, ClassString, bttBtnassinar_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOASSINAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_signature.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:flex-end;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "table-footer-signature-button-reject";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnrejeitar_Internalname, "", "Rejeitar", bttBtnrejeitar_Jsonclick, 7, "Rejeitar", "", StyleString, ClassString, bttBtnrejeitar_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e114n1_client"+"'", TempTags, "", 2, "HLP_signature.htm");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtcss_Internalname, "<style>overflow: hidden;</style>", "", "", lblTxtcss_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_signature.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUsercontrol2.Render(context, "uclocation", Usercontrol2_Internalname, "USERCONTROL2Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTimer.Render(context, "wwp.chronometer", Timer_Internalname, "TIMERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcip.Render(context, "ucip", Ucip_Internalname, "UCIPContainer");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0071"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0071"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0071"+"");
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

      protected void START4N2( )
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
         Form.Meta.addItem("description", "signature", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4N0( ) ;
      }

      protected void WS4N2( )
      {
         START4N2( ) ;
         EVT4N2( ) ;
      }

      protected void EVT4N2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDC_PARTICIPANTES.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_participantes.Onloadcomponent */
                              E124N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E134N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOASSINAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAssinar' */
                              E144N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E154N2 ();
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
                        if ( nCmpId == 71 )
                        {
                           OldWwpaux_wc = cgiGet( "W0071");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0071", "", sEvt);
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

      protected void WE4N2( )
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

      protected void PA4N2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "signature")), "signature") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "signature")))) ;
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
                  gxfirstwebparm = GetFirstPar( "AssinaturaParticipanteId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV5AssinaturaParticipanteId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV5AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(AV5AssinaturaParticipanteId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV31Codigo = GetPar( "Codigo");
                        AssignAttri("", false, "AV31Codigo", AV31Codigo);
                        GxWebStd.gx_hidden_field( context, "gxhash_vCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31Codigo, "")), context));
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
               GX_FocusControl = edtavIp_Internalname;
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
         RF4N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF4N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
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
            E154N2 ();
            WB4N0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4N2( )
      {
         GxWebStd.gx_hidden_field( context, "vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11AssinaturaId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAUXASSINATURAPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12AuxAssinaturaParticipanteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12AuxAssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPARTICIPANTEDOCUMENTO", AV26ParticipanteDocumento);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEDOCUMENTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26ParticipanteDocumento, "")), context));
         GxWebStd.gx_hidden_field( context, "vPARTICIPANTEEMAIL", AV27ParticipanteEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27ParticipanteEmail, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E134N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV21ISSucess = StringUtil.StrToBool( cgiGet( "vISSUCESS"));
            AV20Tick = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vTICK"), ",", "."), 18, MidpointRounding.ToEven));
            Ddc_participantes_Icontype = cgiGet( "DDC_PARTICIPANTES_Icontype");
            Ddc_participantes_Icon = cgiGet( "DDC_PARTICIPANTES_Icon");
            Ddc_participantes_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_PARTICIPANTES_Componentwidth"), ",", "."), 18, MidpointRounding.ToEven));
            Pdfviewe_Path = cgiGet( "PDFVIEWE_Path");
            Usercontrol2_Latitude = cgiGet( "USERCONTROL2_Latitude");
            Usercontrol2_Longitude = cgiGet( "USERCONTROL2_Longitude");
            Timer_Tickinterval = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TIMER_Tickinterval"), ",", "."), 18, MidpointRounding.ToEven));
            Ucip_Campoip = cgiGet( "UCIP_Campoip");
            /* Read variables values. */
            AV30IP = cgiGet( edtavIp_Internalname);
            AssignAttri("", false, "AV30IP", AV30IP);
            AV16Longitude = cgiGet( edtavLongitude_Internalname);
            AssignAttri("", false, "AV16Longitude", AV16Longitude);
            AV17Latitude = cgiGet( edtavLatitude_Internalname);
            AssignAttri("", false, "AV17Latitude", AV17Latitude);
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
         E134N2 ();
         if (returnInSub) return;
      }

      protected void E134N2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV32DateTime = DateTimeUtil.ServerNow( context, pr_default);
         AssignAttri("", false, "AV32DateTime", context.localUtil.TToC( AV32DateTime, 8, 5, 0, 3, "/", ":", " "));
         AV36GXLvl5 = 0;
         /* Using cursor H004N2 */
         pr_default.execute(0, new Object[] {AV32DateTime, AV5AssinaturaParticipanteId, AV31Codigo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A557AssinaturaParticipanteTokenContent = H004N2_A557AssinaturaParticipanteTokenContent[0];
            n557AssinaturaParticipanteTokenContent = H004N2_n557AssinaturaParticipanteTokenContent[0];
            A555AssinaturaParticipanteTokenExpire = H004N2_A555AssinaturaParticipanteTokenExpire[0];
            n555AssinaturaParticipanteTokenExpire = H004N2_n555AssinaturaParticipanteTokenExpire[0];
            A242AssinaturaParticipanteId = H004N2_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = H004N2_n242AssinaturaParticipanteId[0];
            A554AssinaturaParticipanteTokenId = H004N2_A554AssinaturaParticipanteTokenId[0];
            AV36GXLvl5 = 1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV36GXLvl5 == 0 )
         {
            GXt_char1 = AV34Chave;
            new prchave(context ).execute( out  GXt_char1) ;
            AV34Chave = GXt_char1;
            AV35Parametro = Encrypt64( StringUtil.Trim( StringUtil.Str( (decimal)(AV5AssinaturaParticipanteId), 9, 0)), AV34Chave);
            CallWebObject(formatLink("confirmacao", new object[] {UrlEncode(StringUtil.RTrim(AV35Parametro))}, new string[] {"Parametro"}) );
            context.wjLocDisableFrm = 1;
         }
         divTablemensagem_Visible = 0;
         AssignProp("", false, divTablemensagem_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemensagem_Visible), 5, 0), true);
         Ucip_Campoip = edtavIp_Internalname;
         ucUcip.SendProperty(context, "", false, Ucip_Internalname, "CampoIP", Ucip_Campoip);
         /* Using cursor H004N3 */
         pr_default.execute(1, new Object[] {AV5AssinaturaParticipanteId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A233ParticipanteId = H004N3_A233ParticipanteId[0];
            n233ParticipanteId = H004N3_n233ParticipanteId[0];
            A242AssinaturaParticipanteId = H004N3_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = H004N3_n242AssinaturaParticipanteId[0];
            A255ArquivoNome = H004N3_A255ArquivoNome[0];
            n255ArquivoNome = H004N3_n255ArquivoNome[0];
            A232ArquivoBlob_Filename = A255ArquivoNome;
            A254ArquivoExtensao = H004N3_A254ArquivoExtensao[0];
            n254ArquivoExtensao = H004N3_n254ArquivoExtensao[0];
            A232ArquivoBlob_Filetype = A254ArquivoExtensao;
            A238AssinaturaId = H004N3_A238AssinaturaId[0];
            n238AssinaturaId = H004N3_n238AssinaturaId[0];
            A231ArquivoId = H004N3_A231ArquivoId[0];
            n231ArquivoId = H004N3_n231ArquivoId[0];
            A246AssinaturaParticipanteKey = H004N3_A246AssinaturaParticipanteKey[0];
            n246AssinaturaParticipanteKey = H004N3_n246AssinaturaParticipanteKey[0];
            A235ParticipanteEmail = H004N3_A235ParticipanteEmail[0];
            n235ParticipanteEmail = H004N3_n235ParticipanteEmail[0];
            A234ParticipanteDocumento = H004N3_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = H004N3_n234ParticipanteDocumento[0];
            A353AssinaturaParticipanteStatus = H004N3_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = H004N3_n353AssinaturaParticipanteStatus[0];
            A232ArquivoBlob = H004N3_A232ArquivoBlob[0];
            n232ArquivoBlob = H004N3_n232ArquivoBlob[0];
            A235ParticipanteEmail = H004N3_A235ParticipanteEmail[0];
            n235ParticipanteEmail = H004N3_n235ParticipanteEmail[0];
            A234ParticipanteDocumento = H004N3_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = H004N3_n234ParticipanteDocumento[0];
            A231ArquivoId = H004N3_A231ArquivoId[0];
            n231ArquivoId = H004N3_n231ArquivoId[0];
            A255ArquivoNome = H004N3_A255ArquivoNome[0];
            n255ArquivoNome = H004N3_n255ArquivoNome[0];
            A232ArquivoBlob_Filename = A255ArquivoNome;
            A254ArquivoExtensao = H004N3_A254ArquivoExtensao[0];
            n254ArquivoExtensao = H004N3_n254ArquivoExtensao[0];
            A232ArquivoBlob_Filetype = A254ArquivoExtensao;
            A232ArquivoBlob = H004N3_A232ArquivoBlob[0];
            n232ArquivoBlob = H004N3_n232ArquivoBlob[0];
            AV12AuxAssinaturaParticipanteId = A242AssinaturaParticipanteId;
            AssignAttri("", false, "AV12AuxAssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(AV12AuxAssinaturaParticipanteId), 9, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vAUXASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12AuxAssinaturaParticipanteId), "ZZZZZZZZ9"), context));
            AV11AssinaturaId = A238AssinaturaId;
            AssignAttri("", false, "AV11AssinaturaId", StringUtil.LTrimStr( (decimal)(AV11AssinaturaId), 10, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11AssinaturaId), "ZZZZZZZZZ9"), context));
            AV6ArquivoId = A231ArquivoId;
            AV7ArquivoBlob = A232ArquivoBlob;
            AV18AssinaturaParticipanteKey = A246AssinaturaParticipanteKey;
            AV27ParticipanteEmail = A235ParticipanteEmail;
            AssignAttri("", false, "AV27ParticipanteEmail", AV27ParticipanteEmail);
            GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27ParticipanteEmail, "")), context));
            AV26ParticipanteDocumento = A234ParticipanteDocumento;
            AssignAttri("", false, "AV26ParticipanteDocumento", AV26ParticipanteDocumento);
            GxWebStd.gx_hidden_field( context, "gxhash_vPARTICIPANTEDOCUMENTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26ParticipanteDocumento, "")), context));
            if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Assinado") == 0 )
            {
               lblTxtmsg_Caption = "<span>Contrato já foi assinado por você.</span>";
               AssignProp("", false, lblTxtmsg_Internalname, "Caption", lblTxtmsg_Caption, true);
               bttBtnassinar_Visible = 0;
               AssignProp("", false, bttBtnassinar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnassinar_Visible), 5, 0), true);
               bttBtnrejeitar_Visible = 0;
               AssignProp("", false, bttBtnrejeitar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnrejeitar_Visible), 5, 0), true);
               divTablemensagem_Visible = 1;
               AssignProp("", false, divTablemensagem_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemensagem_Visible), 5, 0), true);
            }
            if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Recusado") == 0 )
            {
               lblTxtmsg_Caption = "<span>Contrato já foi recusado por você.</span>";
               AssignProp("", false, lblTxtmsg_Internalname, "Caption", lblTxtmsg_Caption, true);
               bttBtnassinar_Visible = 0;
               AssignProp("", false, bttBtnassinar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnassinar_Visible), 5, 0), true);
               bttBtnrejeitar_Visible = 0;
               AssignProp("", false, bttBtnrejeitar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnrejeitar_Visible), 5, 0), true);
               divTablemensagem_Visible = 1;
               AssignProp("", false, divTablemensagem_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemensagem_Visible), 5, 0), true);
            }
            AV19AssinaturaParticipante.Load(A242AssinaturaParticipanteId);
            AV19AssinaturaParticipante.gxTpr_Assinaturaparticipantedatavisualizacao = DateTimeUtil.ServerNow( context, pr_default);
            AV19AssinaturaParticipante.Save();
            context.CommitDataStores("signature",pr_default);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         Usercontrol2_Latitude = edtavLatitude_Internalname;
         ucUsercontrol2.SendProperty(context, "", false, Usercontrol2_Internalname, "Latitude", Usercontrol2_Latitude);
         Usercontrol2_Longitude = edtavLongitude_Internalname;
         ucUsercontrol2.SendProperty(context, "", false, Usercontrol2_Internalname, "Longitude", Usercontrol2_Longitude);
         AV22NomeDoArquivo = Guid.NewGuid( ).ToString();
         AV23Path = "./PrivateTempStorage/" + AV22NomeDoArquivo + ".pdf";
         AV8File.Source = AV23Path;
         Pdfviewe_Path = AV23Path;
         ucPdfviewe.SendProperty(context, "", false, Pdfviewe_Internalname, "path", Pdfviewe_Path);
         if ( AV8File.Exists() )
         {
            AV8File.Delete();
         }
         AV8File.FromBase64(context.FileToBase64( AV7ArquivoBlob));
         AV8File.Create();
         Timer_Tickinterval = 1;
         ucTimer.SendProperty(context, "", false, Timer_Internalname, "TickInterval", StringUtil.LTrimStr( (decimal)(Timer_Tickinterval), 9, 0));
      }

      protected void E124N2( )
      {
         /* Ddc_participantes_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WcUsersSignature")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wcuserssignature", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WcUsersSignature";
            WebComp_Wwpaux_wc_Component = "WcUsersSignature";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0071",(string)"",(long)AV11AssinaturaId,(int)AV12AuxAssinaturaParticipanteId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0071"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E144N2( )
      {
         /* 'DoAssinar' Routine */
         returnInSub = false;
         bttBtnassinar_Visible = 0;
         AssignProp("", false, bttBtnassinar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnassinar_Visible), 5, 0), true);
         bttBtnrejeitar_Visible = 0;
         AssignProp("", false, bttBtnrejeitar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnrejeitar_Visible), 5, 0), true);
         divTablemensagem_Visible = 1;
         AssignProp("", false, divTablemensagem_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablemensagem_Visible), 5, 0), true);
         divTablebuttons_Visible = 0;
         AssignProp("", false, divTablebuttons_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablebuttons_Visible), 5, 0), true);
         AV20Tick = 1;
         AssignAttri("", false, "AV20Tick", StringUtil.LTrimStr( (decimal)(AV20Tick), 4, 0));
         this.executeUsercontrolMethod("", false, "TIMERContainer", "Start", "", new Object[] {});
         AV13SdGetSignature = new SdtSdGetSignature(context);
         AV13SdGetSignature.gxTpr_Enderecoip = AV30IP;
         AV13SdGetSignature.gxTpr_Geolocalizacao = StringUtil.Format( "%1, %2", AV17Latitude, AV16Longitude, "", "", "", "", "", "", "");
         AV13SdGetSignature.gxTpr_Dispositivo = AV14HTTPRequest.GetHeader("User-Agent");
         AV13SdGetSignature.gxTpr_Datahora = DateTimeUtil.ServerNow( context, pr_default);
         GXt_char1 = "";
         new prformatacpf(context ).execute(  AV26ParticipanteDocumento, out  GXt_char1) ;
         AV13SdGetSignature.gxTpr_Cpf = GXt_char1;
         AV13SdGetSignature.gxTpr_Nascimento = context.localUtil.YMDToD( 1998, 4, 29);
         AV13SdGetSignature.gxTpr_Email = AV27ParticipanteEmail;
         AV19AssinaturaParticipante.Load(AV12AuxAssinaturaParticipanteId);
         AV19AssinaturaParticipante.gxTpr_Assinaturaparticipanteremoteaddres = AV13SdGetSignature.gxTpr_Enderecoip;
         AV19AssinaturaParticipante.gxTpr_Assinaturaparticipantegeolocalizacao = AV13SdGetSignature.gxTpr_Geolocalizacao;
         AV19AssinaturaParticipante.gxTpr_Assinaturaparticipantedispositivo = AV13SdGetSignature.gxTpr_Dispositivo;
         AV19AssinaturaParticipante.gxTpr_Assinaturaparticipantedataconclusao = AV13SdGetSignature.gxTpr_Datahora;
         AV19AssinaturaParticipante.gxTpr_Assinaturaparticipantecpf = AV13SdGetSignature.gxTpr_Cpf;
         AV19AssinaturaParticipante.gxTpr_Assinaturaparticipanteemail = AV13SdGetSignature.gxTpr_Email;
         AV19AssinaturaParticipante.gxTpr_Assinaturaparticipantenascimento = AV13SdGetSignature.gxTpr_Nascimento;
         AV19AssinaturaParticipante.gxTpr_Assinaturaparticipantestatus = "Assinado";
         AV19AssinaturaParticipante.Save();
         AV21ISSucess = true;
         AssignAttri("", false, "AV21ISSucess", AV21ISSucess);
         if ( AV19AssinaturaParticipante.Success() )
         {
            /* Execute user subroutine: 'VERIFICATODOSASSINADOS' */
            S112 ();
            if (returnInSub) return;
            context.CommitDataStores("signature",pr_default);
         }
         else
         {
            context.RollbackDataStores("signature",pr_default);
            AV21ISSucess = false;
            AssignAttri("", false, "AV21ISSucess", AV21ISSucess);
            lblTxtmsg_Caption = "<span>Ocorreu um erro na coleta da assinatura, tente novamente</span>";
            AssignProp("", false, lblTxtmsg_Internalname, "Caption", lblTxtmsg_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'VERIFICATODOSASSINADOS' Routine */
         returnInSub = false;
         AV24IsFaltaAssinar = false;
         /* Using cursor H004N4 */
         pr_default.execute(2, new Object[] {AV11AssinaturaId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A353AssinaturaParticipanteStatus = H004N4_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = H004N4_n353AssinaturaParticipanteStatus[0];
            A238AssinaturaId = H004N4_A238AssinaturaId[0];
            n238AssinaturaId = H004N4_n238AssinaturaId[0];
            AV24IsFaltaAssinar = true;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( ! AV24IsFaltaAssinar )
         {
            AV33BaseUrl = AV14HTTPRequest.BaseURL;
            new prfinalizarcontrato(context ).execute(  AV11AssinaturaId,  AV33BaseUrl, out  AV29SdErro) ;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E154N2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5AssinaturaParticipanteId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV5AssinaturaParticipanteId", StringUtil.LTrimStr( (decimal)(AV5AssinaturaParticipanteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAPARTICIPANTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5AssinaturaParticipanteId), "ZZZZZZZZ9"), context));
         AV31Codigo = (string)getParm(obj,1);
         AssignAttri("", false, "AV31Codigo", AV31Codigo);
         GxWebStd.gx_hidden_field( context, "gxhash_vCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV31Codigo, "")), context));
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
         PA4N2( ) ;
         WS4N2( ) ;
         WE4N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019243769", true, true);
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
         context.AddJavascriptSource("signature.js", "?202561019243770", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCPdfViewerRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCLocationRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Chronometer/ChronometerRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCIPRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavIp_Internalname = "vIP";
         edtavLongitude_Internalname = "vLONGITUDE";
         divLongitudenumber_Internalname = "LONGITUDENUMBER";
         edtavLatitude_Internalname = "vLATITUDE";
         divLatitudenumber_Internalname = "LATITUDENUMBER";
         divCampos_Internalname = "CAMPOS";
         Ddc_participantes_Internalname = "DDC_PARTICIPANTES";
         lblThehtml_Internalname = "THEHTML";
         Pdfviewe_Internalname = "PDFVIEWE";
         divTablepdf_Internalname = "TABLEPDF";
         lblTxtmsg_Internalname = "TXTMSG";
         divTablemensagem_Internalname = "TABLEMENSAGEM";
         bttBtnassinar_Internalname = "BTNASSINAR";
         bttBtnrejeitar_Internalname = "BTNREJEITAR";
         divTablebuttons_Internalname = "TABLEBUTTONS";
         divTablecontent_Internalname = "TABLECONTENT";
         lblTxtcss_Internalname = "TXTCSS";
         Usercontrol2_Internalname = "USERCONTROL2";
         Timer_Internalname = "TIMER";
         Ucip_Internalname = "UCIP";
         divTablemain_Internalname = "TABLEMAIN";
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
         bttBtnrejeitar_Visible = 1;
         bttBtnassinar_Visible = 1;
         divTablebuttons_Visible = 1;
         lblTxtmsg_Caption = "<h2 style=\"margin-top: 46px;\">Contrato assinado com sucesso!</h3>";
         divTablemensagem_Visible = 1;
         Ddc_participantes_Caption = "";
         edtavLatitude_Jsonclick = "";
         edtavLatitude_Enabled = 1;
         edtavLongitude_Jsonclick = "";
         edtavLongitude_Enabled = 1;
         edtavIp_Jsonclick = "";
         edtavIp_Enabled = 1;
         Ucip_Campoip = "";
         Timer_Tickinterval = 1;
         Pdfviewe_Path = "";
         Ddc_participantes_Componentwidth = 735;
         Ddc_participantes_Icon = "fas fa-user-group";
         Ddc_participantes_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "signature";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV11AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV12AuxAssinaturaParticipanteId","fld":"vAUXASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV26ParticipanteDocumento","fld":"vPARTICIPANTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV27ParticipanteEmail","fld":"vPARTICIPANTEEMAIL","hsh":true,"type":"svchar"},{"av":"AV5AssinaturaParticipanteId","fld":"vASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV31Codigo","fld":"vCODIGO","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("DDC_PARTICIPANTES.ONLOADCOMPONENT","""{"handler":"E124N2","iparms":[{"av":"AV11AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV12AuxAssinaturaParticipanteId","fld":"vAUXASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("DDC_PARTICIPANTES.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("'DOASSINAR'","""{"handler":"E144N2","iparms":[{"av":"AV30IP","fld":"vIP","type":"svchar"},{"av":"AV17Latitude","fld":"vLATITUDE","type":"svchar"},{"av":"AV16Longitude","fld":"vLONGITUDE","type":"svchar"},{"av":"AV26ParticipanteDocumento","fld":"vPARTICIPANTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV27ParticipanteEmail","fld":"vPARTICIPANTEEMAIL","hsh":true,"type":"svchar"},{"av":"AV12AuxAssinaturaParticipanteId","fld":"vAUXASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV11AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A353AssinaturaParticipanteStatus","fld":"ASSINATURAPARTICIPANTESTATUS","type":"svchar"},{"av":"AV14HTTPRequest.BaseURL","ctrl":"vHTTPREQUEST","prop":"Baseurl"}]""");
         setEventMetadata("'DOASSINAR'",""","oparms":[{"ctrl":"BTNASSINAR","prop":"Visible"},{"ctrl":"BTNREJEITAR","prop":"Visible"},{"av":"divTablemensagem_Visible","ctrl":"TABLEMENSAGEM","prop":"Visible"},{"av":"divTablebuttons_Visible","ctrl":"TABLEBUTTONS","prop":"Visible"},{"av":"AV20Tick","fld":"vTICK","pic":"ZZZ9","type":"int"},{"av":"AV21ISSucess","fld":"vISSUCESS","type":"boolean"},{"av":"lblTxtmsg_Caption","ctrl":"TXTMSG","prop":"Caption"}]}""");
         setEventMetadata("'DOREJEITAR'","""{"handler":"E114N1","iparms":[]}""");
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
         wcpOAV31Codigo = "";
         AV14HTTPRequest = new GxHttpRequest( context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV26ParticipanteDocumento = "";
         AV27ParticipanteEmail = "";
         A353AssinaturaParticipanteStatus = "";
         Usercontrol2_Latitude = "";
         Usercontrol2_Longitude = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV30IP = "";
         AV16Longitude = "";
         AV17Latitude = "";
         ucDdc_participantes = new GXUserControl();
         lblThehtml_Jsonclick = "";
         ucPdfviewe = new GXUserControl();
         lblTxtmsg_Jsonclick = "";
         bttBtnassinar_Jsonclick = "";
         bttBtnrejeitar_Jsonclick = "";
         lblTxtcss_Jsonclick = "";
         ucUsercontrol2 = new GXUserControl();
         ucTimer = new GXUserControl();
         ucUcip = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV32DateTime = (DateTime)(DateTime.MinValue);
         H004N2_A557AssinaturaParticipanteTokenContent = new string[] {""} ;
         H004N2_n557AssinaturaParticipanteTokenContent = new bool[] {false} ;
         H004N2_A555AssinaturaParticipanteTokenExpire = new DateTime[] {DateTime.MinValue} ;
         H004N2_n555AssinaturaParticipanteTokenExpire = new bool[] {false} ;
         H004N2_A242AssinaturaParticipanteId = new int[1] ;
         H004N2_n242AssinaturaParticipanteId = new bool[] {false} ;
         H004N2_A554AssinaturaParticipanteTokenId = new int[1] ;
         A557AssinaturaParticipanteTokenContent = "";
         A555AssinaturaParticipanteTokenExpire = (DateTime)(DateTime.MinValue);
         AV34Chave = "";
         AV35Parametro = "";
         H004N3_A233ParticipanteId = new int[1] ;
         H004N3_n233ParticipanteId = new bool[] {false} ;
         H004N3_A242AssinaturaParticipanteId = new int[1] ;
         H004N3_n242AssinaturaParticipanteId = new bool[] {false} ;
         H004N3_A255ArquivoNome = new string[] {""} ;
         H004N3_n255ArquivoNome = new bool[] {false} ;
         H004N3_A254ArquivoExtensao = new string[] {""} ;
         H004N3_n254ArquivoExtensao = new bool[] {false} ;
         H004N3_A238AssinaturaId = new long[1] ;
         H004N3_n238AssinaturaId = new bool[] {false} ;
         H004N3_A231ArquivoId = new int[1] ;
         H004N3_n231ArquivoId = new bool[] {false} ;
         H004N3_A246AssinaturaParticipanteKey = new Guid[] {Guid.Empty} ;
         H004N3_n246AssinaturaParticipanteKey = new bool[] {false} ;
         H004N3_A235ParticipanteEmail = new string[] {""} ;
         H004N3_n235ParticipanteEmail = new bool[] {false} ;
         H004N3_A234ParticipanteDocumento = new string[] {""} ;
         H004N3_n234ParticipanteDocumento = new bool[] {false} ;
         H004N3_A353AssinaturaParticipanteStatus = new string[] {""} ;
         H004N3_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         H004N3_A232ArquivoBlob = new string[] {""} ;
         H004N3_n232ArquivoBlob = new bool[] {false} ;
         A255ArquivoNome = "";
         A232ArquivoBlob = "";
         A232ArquivoBlob_Filename = "";
         A254ArquivoExtensao = "";
         A232ArquivoBlob_Filetype = "";
         A246AssinaturaParticipanteKey = Guid.Empty;
         A235ParticipanteEmail = "";
         A234ParticipanteDocumento = "";
         AV7ArquivoBlob = "";
         AV18AssinaturaParticipanteKey = Guid.Empty;
         AV19AssinaturaParticipante = new SdtAssinaturaParticipante(context);
         AV22NomeDoArquivo = "";
         AV23Path = "";
         AV8File = new GxFile(context.GetPhysicalPath());
         AV13SdGetSignature = new SdtSdGetSignature(context);
         GXt_char1 = "";
         H004N4_A242AssinaturaParticipanteId = new int[1] ;
         H004N4_n242AssinaturaParticipanteId = new bool[] {false} ;
         H004N4_A353AssinaturaParticipanteStatus = new string[] {""} ;
         H004N4_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         H004N4_A238AssinaturaId = new long[1] ;
         H004N4_n238AssinaturaId = new bool[] {false} ;
         AV33BaseUrl = "";
         AV29SdErro = new SdtSdErro(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.signature__default(),
            new Object[][] {
                new Object[] {
               H004N2_A557AssinaturaParticipanteTokenContent, H004N2_n557AssinaturaParticipanteTokenContent, H004N2_A555AssinaturaParticipanteTokenExpire, H004N2_n555AssinaturaParticipanteTokenExpire, H004N2_A242AssinaturaParticipanteId, H004N2_n242AssinaturaParticipanteId, H004N2_A554AssinaturaParticipanteTokenId
               }
               , new Object[] {
               H004N3_A233ParticipanteId, H004N3_n233ParticipanteId, H004N3_A242AssinaturaParticipanteId, H004N3_A255ArquivoNome, H004N3_n255ArquivoNome, H004N3_A254ArquivoExtensao, H004N3_n254ArquivoExtensao, H004N3_A238AssinaturaId, H004N3_n238AssinaturaId, H004N3_A231ArquivoId,
               H004N3_n231ArquivoId, H004N3_A246AssinaturaParticipanteKey, H004N3_n246AssinaturaParticipanteKey, H004N3_A235ParticipanteEmail, H004N3_n235ParticipanteEmail, H004N3_A234ParticipanteDocumento, H004N3_n234ParticipanteDocumento, H004N3_A353AssinaturaParticipanteStatus, H004N3_n353AssinaturaParticipanteStatus, H004N3_A232ArquivoBlob,
               H004N3_n232ArquivoBlob
               }
               , new Object[] {
               H004N4_A242AssinaturaParticipanteId, H004N4_A353AssinaturaParticipanteStatus, H004N4_n353AssinaturaParticipanteStatus, H004N4_A238AssinaturaId, H004N4_n238AssinaturaId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
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
      private short AV20Tick ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV36GXLvl5 ;
      private short nGXWrapped ;
      private int AV5AssinaturaParticipanteId ;
      private int wcpOAV5AssinaturaParticipanteId ;
      private int AV12AuxAssinaturaParticipanteId ;
      private int Ddc_participantes_Componentwidth ;
      private int Timer_Tickinterval ;
      private int edtavIp_Enabled ;
      private int edtavLongitude_Enabled ;
      private int edtavLatitude_Enabled ;
      private int divTablemensagem_Visible ;
      private int divTablebuttons_Visible ;
      private int bttBtnassinar_Visible ;
      private int bttBtnrejeitar_Visible ;
      private int A242AssinaturaParticipanteId ;
      private int A554AssinaturaParticipanteTokenId ;
      private int A233ParticipanteId ;
      private int A231ArquivoId ;
      private int AV6ArquivoId ;
      private int idxLst ;
      private long AV11AssinaturaId ;
      private long A238AssinaturaId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Ddc_participantes_Icontype ;
      private string Ddc_participantes_Icon ;
      private string Pdfviewe_Path ;
      private string Usercontrol2_Latitude ;
      private string Usercontrol2_Longitude ;
      private string Ucip_Campoip ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divCampos_Internalname ;
      private string edtavIp_Internalname ;
      private string TempTags ;
      private string edtavIp_Jsonclick ;
      private string divLongitudenumber_Internalname ;
      private string edtavLongitude_Internalname ;
      private string edtavLongitude_Jsonclick ;
      private string divLatitudenumber_Internalname ;
      private string edtavLatitude_Internalname ;
      private string edtavLatitude_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string Ddc_participantes_Caption ;
      private string Ddc_participantes_Internalname ;
      private string divTablepdf_Internalname ;
      private string lblThehtml_Internalname ;
      private string lblThehtml_Jsonclick ;
      private string Pdfviewe_Internalname ;
      private string divTablemensagem_Internalname ;
      private string lblTxtmsg_Internalname ;
      private string lblTxtmsg_Caption ;
      private string lblTxtmsg_Jsonclick ;
      private string divTablebuttons_Internalname ;
      private string bttBtnassinar_Internalname ;
      private string bttBtnassinar_Jsonclick ;
      private string bttBtnrejeitar_Internalname ;
      private string bttBtnrejeitar_Jsonclick ;
      private string lblTxtcss_Internalname ;
      private string lblTxtcss_Jsonclick ;
      private string Usercontrol2_Internalname ;
      private string Timer_Internalname ;
      private string Ucip_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string A232ArquivoBlob_Filename ;
      private string A232ArquivoBlob_Filetype ;
      private string GXt_char1 ;
      private DateTime AV32DateTime ;
      private DateTime A555AssinaturaParticipanteTokenExpire ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV21ISSucess ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n557AssinaturaParticipanteTokenContent ;
      private bool n555AssinaturaParticipanteTokenExpire ;
      private bool n242AssinaturaParticipanteId ;
      private bool n233ParticipanteId ;
      private bool n255ArquivoNome ;
      private bool n254ArquivoExtensao ;
      private bool n238AssinaturaId ;
      private bool n231ArquivoId ;
      private bool n246AssinaturaParticipanteKey ;
      private bool n235ParticipanteEmail ;
      private bool n234ParticipanteDocumento ;
      private bool n353AssinaturaParticipanteStatus ;
      private bool n232ArquivoBlob ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV24IsFaltaAssinar ;
      private string AV31Codigo ;
      private string wcpOAV31Codigo ;
      private string AV26ParticipanteDocumento ;
      private string AV27ParticipanteEmail ;
      private string A353AssinaturaParticipanteStatus ;
      private string AV30IP ;
      private string AV16Longitude ;
      private string AV17Latitude ;
      private string A557AssinaturaParticipanteTokenContent ;
      private string AV34Chave ;
      private string AV35Parametro ;
      private string A255ArquivoNome ;
      private string A254ArquivoExtensao ;
      private string A235ParticipanteEmail ;
      private string A234ParticipanteDocumento ;
      private string AV22NomeDoArquivo ;
      private string AV23Path ;
      private string AV33BaseUrl ;
      private Guid A246AssinaturaParticipanteKey ;
      private Guid AV18AssinaturaParticipanteKey ;
      private string A232ArquivoBlob ;
      private string AV7ArquivoBlob ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDdc_participantes ;
      private GXUserControl ucPdfviewe ;
      private GXUserControl ucUsercontrol2 ;
      private GXUserControl ucTimer ;
      private GXUserControl ucUcip ;
      private GxHttpRequest AV14HTTPRequest ;
      private GxFile AV8File ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H004N2_A557AssinaturaParticipanteTokenContent ;
      private bool[] H004N2_n557AssinaturaParticipanteTokenContent ;
      private DateTime[] H004N2_A555AssinaturaParticipanteTokenExpire ;
      private bool[] H004N2_n555AssinaturaParticipanteTokenExpire ;
      private int[] H004N2_A242AssinaturaParticipanteId ;
      private bool[] H004N2_n242AssinaturaParticipanteId ;
      private int[] H004N2_A554AssinaturaParticipanteTokenId ;
      private int[] H004N3_A233ParticipanteId ;
      private bool[] H004N3_n233ParticipanteId ;
      private int[] H004N3_A242AssinaturaParticipanteId ;
      private bool[] H004N3_n242AssinaturaParticipanteId ;
      private string[] H004N3_A255ArquivoNome ;
      private bool[] H004N3_n255ArquivoNome ;
      private string[] H004N3_A254ArquivoExtensao ;
      private bool[] H004N3_n254ArquivoExtensao ;
      private long[] H004N3_A238AssinaturaId ;
      private bool[] H004N3_n238AssinaturaId ;
      private int[] H004N3_A231ArquivoId ;
      private bool[] H004N3_n231ArquivoId ;
      private Guid[] H004N3_A246AssinaturaParticipanteKey ;
      private bool[] H004N3_n246AssinaturaParticipanteKey ;
      private string[] H004N3_A235ParticipanteEmail ;
      private bool[] H004N3_n235ParticipanteEmail ;
      private string[] H004N3_A234ParticipanteDocumento ;
      private bool[] H004N3_n234ParticipanteDocumento ;
      private string[] H004N3_A353AssinaturaParticipanteStatus ;
      private bool[] H004N3_n353AssinaturaParticipanteStatus ;
      private string[] H004N3_A232ArquivoBlob ;
      private bool[] H004N3_n232ArquivoBlob ;
      private SdtAssinaturaParticipante AV19AssinaturaParticipante ;
      private SdtSdGetSignature AV13SdGetSignature ;
      private int[] H004N4_A242AssinaturaParticipanteId ;
      private bool[] H004N4_n242AssinaturaParticipanteId ;
      private string[] H004N4_A353AssinaturaParticipanteStatus ;
      private bool[] H004N4_n353AssinaturaParticipanteStatus ;
      private long[] H004N4_A238AssinaturaId ;
      private bool[] H004N4_n238AssinaturaId ;
      private SdtSdErro AV29SdErro ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class signature__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004N2;
          prmH004N2 = new Object[] {
          new ParDef("AV32DateTime",GXType.DateTime,8,5) ,
          new ParDef("AV5AssinaturaParticipanteId",GXType.Int32,9,0) ,
          new ParDef("AV31Codigo",GXType.VarChar,40,0)
          };
          Object[] prmH004N3;
          prmH004N3 = new Object[] {
          new ParDef("AV5AssinaturaParticipanteId",GXType.Int32,9,0)
          };
          Object[] prmH004N4;
          prmH004N4 = new Object[] {
          new ParDef("AV11AssinaturaId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004N2", "SELECT AssinaturaParticipanteTokenContent, AssinaturaParticipanteTokenExpire, AssinaturaParticipanteId, AssinaturaParticipanteTokenId FROM AssinaturaParticipanteToken WHERE (AssinaturaParticipanteTokenExpire > :AV32DateTime) AND (AssinaturaParticipanteId = :AV5AssinaturaParticipanteId) AND (AssinaturaParticipanteTokenContent = ( :AV31Codigo)) ORDER BY AssinaturaParticipanteTokenId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004N2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004N3", "SELECT T1.ParticipanteId, T1.AssinaturaParticipanteId, T4.ArquivoNome, T4.ArquivoExtensao, T1.AssinaturaId, T3.ArquivoId, T1.AssinaturaParticipanteKey, T2.ParticipanteEmail, T2.ParticipanteDocumento, T1.AssinaturaParticipanteStatus, T4.ArquivoBlob FROM (((AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId) LEFT JOIN Assinatura T3 ON T3.AssinaturaId = T1.AssinaturaId) LEFT JOIN Arquivo T4 ON T4.ArquivoId = T3.ArquivoId) WHERE T1.AssinaturaParticipanteId = :AV5AssinaturaParticipanteId ORDER BY T1.AssinaturaParticipanteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004N3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H004N4", "SELECT AssinaturaParticipanteId, AssinaturaParticipanteStatus, AssinaturaId FROM AssinaturaParticipante WHERE (AssinaturaId = :AV11AssinaturaId) AND (AssinaturaParticipanteStatus <> ( 'Assinado')) ORDER BY AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004N4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((Guid[]) buf[11])[0] = rslt.getGuid(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getBLOBFile(11, rslt.getVarchar(4), rslt.getVarchar(3));
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
