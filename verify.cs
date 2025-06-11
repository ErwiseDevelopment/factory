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
   public class verify : GXDataArea
   {
      public verify( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public verify( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_AssinaturaId )
      {
         this.AV5AssinaturaId = aP0_AssinaturaId;
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
            gxfirstwebparm = GetFirstPar( "AssinaturaId");
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
               gxfirstwebparm = GetFirstPar( "AssinaturaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AssinaturaId");
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
         PA7B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7B2( ) ;
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
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
         GXEncryptionTmp = "verify"+UrlEncode(StringUtil.LTrimStr(AV5AssinaturaId,10,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("verify") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vARQUIVOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13ArquivoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vARQUIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13ArquivoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vARQUIVOASSINADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ArquivoAssinadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vARQUIVOASSINADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19ArquivoAssinadoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5AssinaturaId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vARQUIVOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13ArquivoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vARQUIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13ArquivoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vARQUIVOASSINADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ArquivoAssinadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vARQUIVOASSINADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19ArquivoAssinadoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5AssinaturaId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "NOVAJANELA_Target", StringUtil.RTrim( Novajanela_Target));
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
            WE7B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7B2( ) ;
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
         GXEncryptionTmp = "verify"+UrlEncode(StringUtil.LTrimStr(AV5AssinaturaId,10,0));
         return formatLink("verify") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Verify" ;
      }

      public override string GetPgmdesc( )
      {
         return "Verify" ;
      }

      protected void WB7B0( )
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
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Verify.htm");
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
            GxWebStd.gx_div_start( context, divTablebuttons_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndownloaddocumentooriginal_Internalname, "", "Documento original", bttBtndownloaddocumentooriginal_Jsonclick, 5, "Documento original", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DODOWNLOADDOCUMENTOORIGINAL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Verify.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndownloaddocumentoassinado_Internalname, "", "Documento assinado", bttBtndownloaddocumentoassinado_Jsonclick, 5, "Documento assinado", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DODOWNLOADDOCUMENTOASSINADO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Verify.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtlista_Internalname, lblTxtlista_Caption, "", "", lblTxtlista_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_Verify.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucNovajanela.Render(context, "innewwindow", Novajanela_Internalname, "NOVAJANELAContainer");
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

      protected void START7B2( )
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
         Form.Meta.addItem("description", "Verify", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7B0( ) ;
      }

      protected void WS7B2( )
      {
         START7B2( ) ;
         EVT7B2( ) ;
      }

      protected void EVT7B2( )
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
                              E117B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODOWNLOADDOCUMENTOORIGINAL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoDownloadDocumentoOriginal' */
                              E127B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODOWNLOADDOCUMENTOASSINADO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoDownloadDocumentoAssinado' */
                              E137B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E147B2 ();
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

      protected void WE7B2( )
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

      protected void PA7B2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "verify")), "verify") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "verify")))) ;
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
                  gxfirstwebparm = GetFirstPar( "AssinaturaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV5AssinaturaId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV5AssinaturaId", StringUtil.LTrimStr( (decimal)(AV5AssinaturaId), 10, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5AssinaturaId), "ZZZZZZZZZ9"), context));
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
         RF7B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E147B2 ();
            WB7B0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7B2( )
      {
         GxWebStd.gx_hidden_field( context, "vARQUIVOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13ArquivoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vARQUIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13ArquivoId), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vARQUIVOASSINADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ArquivoAssinadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vARQUIVOASSINADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19ArquivoAssinadoId), "ZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E117B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Novajanela_Target = cgiGet( "NOVAJANELA_Target");
            /* Read variables values. */
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
         E117B2 ();
         if (returnInSub) return;
      }

      protected void E117B2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H007B2 */
         pr_default.execute(0, new Object[] {AV5AssinaturaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = H007B2_A227ContratoId[0];
            n227ContratoId = H007B2_n227ContratoId[0];
            A238AssinaturaId = H007B2_A238AssinaturaId[0];
            n238AssinaturaId = H007B2_n238AssinaturaId[0];
            A255ArquivoNome = H007B2_A255ArquivoNome[0];
            n255ArquivoNome = H007B2_n255ArquivoNome[0];
            A232ArquivoBlob_Filename = A255ArquivoNome;
            A257AssinaturaArquivoAssinadoNome = H007B2_A257AssinaturaArquivoAssinadoNome[0];
            n257AssinaturaArquivoAssinadoNome = H007B2_n257AssinaturaArquivoAssinadoNome[0];
            A240AssinaturaArquivoAssinado_Filename = A257AssinaturaArquivoAssinadoNome;
            A254ArquivoExtensao = H007B2_A254ArquivoExtensao[0];
            n254ArquivoExtensao = H007B2_n254ArquivoExtensao[0];
            A232ArquivoBlob_Filetype = A254ArquivoExtensao;
            A256AssinaturaArquivoAssinadoExtensao = H007B2_A256AssinaturaArquivoAssinadoExtensao[0];
            n256AssinaturaArquivoAssinadoExtensao = H007B2_n256AssinaturaArquivoAssinadoExtensao[0];
            A240AssinaturaArquivoAssinado_Filetype = A256AssinaturaArquivoAssinadoExtensao;
            A366AssinaturaFinalizadoData = H007B2_A366AssinaturaFinalizadoData[0];
            n366AssinaturaFinalizadoData = H007B2_n366AssinaturaFinalizadoData[0];
            A241AssinaturaPublicKey = H007B2_A241AssinaturaPublicKey[0];
            n241AssinaturaPublicKey = H007B2_n241AssinaturaPublicKey[0];
            A228ContratoNome = H007B2_A228ContratoNome[0];
            n228ContratoNome = H007B2_n228ContratoNome[0];
            A231ArquivoId = H007B2_A231ArquivoId[0];
            n231ArquivoId = H007B2_n231ArquivoId[0];
            A578ArquivoAssinadoId = H007B2_A578ArquivoAssinadoId[0];
            n578ArquivoAssinadoId = H007B2_n578ArquivoAssinadoId[0];
            A232ArquivoBlob = H007B2_A232ArquivoBlob[0];
            n232ArquivoBlob = H007B2_n232ArquivoBlob[0];
            A240AssinaturaArquivoAssinado = H007B2_A240AssinaturaArquivoAssinado[0];
            n240AssinaturaArquivoAssinado = H007B2_n240AssinaturaArquivoAssinado[0];
            A228ContratoNome = H007B2_A228ContratoNome[0];
            n228ContratoNome = H007B2_n228ContratoNome[0];
            A255ArquivoNome = H007B2_A255ArquivoNome[0];
            n255ArquivoNome = H007B2_n255ArquivoNome[0];
            A232ArquivoBlob_Filename = A255ArquivoNome;
            A254ArquivoExtensao = H007B2_A254ArquivoExtensao[0];
            n254ArquivoExtensao = H007B2_n254ArquivoExtensao[0];
            A232ArquivoBlob_Filetype = A254ArquivoExtensao;
            A232ArquivoBlob = H007B2_A232ArquivoBlob[0];
            n232ArquivoBlob = H007B2_n232ArquivoBlob[0];
            AV8AssinaturaFinalizadoData = DateTimeUtil.ServerNow( context, pr_default);
            AV7Array_SdParticipantesContrato = new GXBaseCollection<SdtSdParticipantesContrato>( context, "SdParticipantesContrato", "Factory21");
            /* Using cursor H007B3 */
            pr_default.execute(1, new Object[] {n238AssinaturaId, A238AssinaturaId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A233ParticipanteId = H007B3_A233ParticipanteId[0];
               n233ParticipanteId = H007B3_n233ParticipanteId[0];
               A248ParticipanteNome = H007B3_A248ParticipanteNome[0];
               n248ParticipanteNome = H007B3_n248ParticipanteNome[0];
               A235ParticipanteEmail = H007B3_A235ParticipanteEmail[0];
               n235ParticipanteEmail = H007B3_n235ParticipanteEmail[0];
               A350AssinaturaParticipanteCPF = H007B3_A350AssinaturaParticipanteCPF[0];
               n350AssinaturaParticipanteCPF = H007B3_n350AssinaturaParticipanteCPF[0];
               A352AssinaturaParticipanteNascimento = H007B3_A352AssinaturaParticipanteNascimento[0];
               n352AssinaturaParticipanteNascimento = H007B3_n352AssinaturaParticipanteNascimento[0];
               A245AssinaturaParticipanteDataConclusao = H007B3_A245AssinaturaParticipanteDataConclusao[0];
               n245AssinaturaParticipanteDataConclusao = H007B3_n245AssinaturaParticipanteDataConclusao[0];
               A246AssinaturaParticipanteKey = H007B3_A246AssinaturaParticipanteKey[0];
               n246AssinaturaParticipanteKey = H007B3_n246AssinaturaParticipanteKey[0];
               A346AssinaturaParticipanteRemoteAddres = H007B3_A346AssinaturaParticipanteRemoteAddres[0];
               n346AssinaturaParticipanteRemoteAddres = H007B3_n346AssinaturaParticipanteRemoteAddres[0];
               A347AssinaturaParticipanteGeolocalizacao = H007B3_A347AssinaturaParticipanteGeolocalizacao[0];
               n347AssinaturaParticipanteGeolocalizacao = H007B3_n347AssinaturaParticipanteGeolocalizacao[0];
               A348AssinaturaParticipanteDispositivo = H007B3_A348AssinaturaParticipanteDispositivo[0];
               n348AssinaturaParticipanteDispositivo = H007B3_n348AssinaturaParticipanteDispositivo[0];
               A248ParticipanteNome = H007B3_A248ParticipanteNome[0];
               n248ParticipanteNome = H007B3_n248ParticipanteNome[0];
               A235ParticipanteEmail = H007B3_A235ParticipanteEmail[0];
               n235ParticipanteEmail = H007B3_n235ParticipanteEmail[0];
               AV6SdParticipantesContrato = new SdtSdParticipantesContrato(context);
               AV6SdParticipantesContrato.gxTpr_Participantenome = A248ParticipanteNome;
               AV6SdParticipantesContrato.gxTpr_Participanteemail = A235ParticipanteEmail;
               AV6SdParticipantesContrato.gxTpr_Assinaturaparticipantecpf = A350AssinaturaParticipanteCPF;
               AV6SdParticipantesContrato.gxTpr_Assinaturaparticipantenascimento = A352AssinaturaParticipanteNascimento;
               AV6SdParticipantesContrato.gxTpr_Assinaturaparticipantedataconclusao = A245AssinaturaParticipanteDataConclusao;
               GXt_char1 = "";
               new prcensuratoken(context ).execute(  A246AssinaturaParticipanteKey.ToString(), out  GXt_char1) ;
               AV6SdParticipantesContrato.gxTpr_Assinaturaparticipantekey = GXt_char1;
               AV6SdParticipantesContrato.gxTpr_Assinaturaparticipanteremoteaddres = A346AssinaturaParticipanteRemoteAddres;
               AV6SdParticipantesContrato.gxTpr_Assinaturaparticipantegeolocalizacao = A347AssinaturaParticipanteGeolocalizacao;
               AV6SdParticipantesContrato.gxTpr_Assinaturaparticipantedispositivo = A348AssinaturaParticipanteDispositivo;
               AV7Array_SdParticipantesContrato.Add(AV6SdParticipantesContrato, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV8AssinaturaFinalizadoData = A366AssinaturaFinalizadoData;
            AV9ArquivoBlob = A232ArquivoBlob;
            AV10AssinaturaPublicKey = A241AssinaturaPublicKey;
            new prhtmlfimcontratoconsulta(context ).execute(  A228ContratoNome,  A241AssinaturaPublicKey,  AV8AssinaturaFinalizadoData,  AV7Array_SdParticipantesContrato, out  AV11HTML) ;
            lblTxtlista_Caption = AV11HTML;
            AssignProp("", false, lblTxtlista_Internalname, "Caption", lblTxtlista_Caption, true);
            AV14assinaturaarquivoassinado = A240AssinaturaArquivoAssinado;
            AV13ArquivoId = A231ArquivoId;
            AssignAttri("", false, "AV13ArquivoId", StringUtil.LTrimStr( (decimal)(AV13ArquivoId), 8, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vARQUIVOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13ArquivoId), "ZZZZZZZ9"), context));
            AV19ArquivoAssinadoId = A578ArquivoAssinadoId;
            AssignAttri("", false, "AV19ArquivoAssinadoId", StringUtil.LTrimStr( (decimal)(AV19ArquivoAssinadoId), 8, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vARQUIVOASSINADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19ArquivoAssinadoId), "ZZZZZZZ9"), context));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void E127B2( )
      {
         /* 'DoDownloadDocumentoOriginal' Routine */
         returnInSub = false;
         AV18Arquivo = new SdtArquivo(context);
         AV18Arquivo.Load(AV13ArquivoId);
         AV15GUID = Guid.NewGuid( );
         AV16Source = "./PrivateTempStorage/" + StringUtil.Trim( AV15GUID.ToString()) + ".pdf";
         AV17File = new GxFile(context.GetPhysicalPath());
         AV17File.Source = AV16Source;
         AV17File.FromBase64(context.FileToBase64( AV18Arquivo.gxTpr_Arquivoblob));
         AV17File.Create();
         Novajanela_Target = AV16Source;
         ucNovajanela.SendProperty(context, "", false, Novajanela_Internalname, "Target", Novajanela_Target);
         this.executeUsercontrolMethod("", false, "NOVAJANELAContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E137B2( )
      {
         /* 'DoDownloadDocumentoAssinado' Routine */
         returnInSub = false;
         AV18Arquivo = new SdtArquivo(context);
         AV18Arquivo.Load(AV19ArquivoAssinadoId);
         AV15GUID = Guid.NewGuid( );
         AV16Source = "./PrivateTempStorage/" + StringUtil.Trim( AV15GUID.ToString()) + ".pdf";
         AV17File = new GxFile(context.GetPhysicalPath());
         AV17File.Source = AV16Source;
         AV17File.FromBase64(context.FileToBase64( AV18Arquivo.gxTpr_Arquivoblob));
         AV17File.Create();
         Novajanela_Target = AV16Source;
         ucNovajanela.SendProperty(context, "", false, Novajanela_Internalname, "Target", Novajanela_Target);
         this.executeUsercontrolMethod("", false, "NOVAJANELAContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E147B2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5AssinaturaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV5AssinaturaId", StringUtil.LTrimStr( (decimal)(AV5AssinaturaId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5AssinaturaId), "ZZZZZZZZZ9"), context));
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
         PA7B2( ) ;
         WS7B2( ) ;
         WE7B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019263333", true, true);
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
         context.AddJavascriptSource("verify.js", "?202561019263333", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtndownloaddocumentooriginal_Internalname = "BTNDOWNLOADDOCUMENTOORIGINAL";
         bttBtndownloaddocumentoassinado_Internalname = "BTNDOWNLOADDOCUMENTOASSINADO";
         divTablebuttons_Internalname = "TABLEBUTTONS";
         lblTxtlista_Internalname = "TXTLISTA";
         divTablecontent_Internalname = "TABLECONTENT";
         Novajanela_Internalname = "NOVAJANELA";
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
         lblTxtlista_Caption = "";
         Novajanela_Target = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Verify";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV13ArquivoId","fld":"vARQUIVOID","pic":"ZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19ArquivoAssinadoId","fld":"vARQUIVOASSINADOID","pic":"ZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV5AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DODOWNLOADDOCUMENTOORIGINAL'","""{"handler":"E127B2","iparms":[{"av":"AV13ArquivoId","fld":"vARQUIVOID","pic":"ZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'DODOWNLOADDOCUMENTOORIGINAL'",""","oparms":[{"av":"Novajanela_Target","ctrl":"NOVAJANELA","prop":"Target"}]}""");
         setEventMetadata("'DODOWNLOADDOCUMENTOASSINADO'","""{"handler":"E137B2","iparms":[{"av":"AV19ArquivoAssinadoId","fld":"vARQUIVOASSINADOID","pic":"ZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'DODOWNLOADDOCUMENTOASSINADO'",""","oparms":[{"av":"Novajanela_Target","ctrl":"NOVAJANELA","prop":"Target"}]}""");
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
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtndownloaddocumentooriginal_Jsonclick = "";
         bttBtndownloaddocumentoassinado_Jsonclick = "";
         lblTxtlista_Jsonclick = "";
         ucNovajanela = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H007B2_A227ContratoId = new int[1] ;
         H007B2_n227ContratoId = new bool[] {false} ;
         H007B2_A238AssinaturaId = new long[1] ;
         H007B2_n238AssinaturaId = new bool[] {false} ;
         H007B2_A255ArquivoNome = new string[] {""} ;
         H007B2_n255ArquivoNome = new bool[] {false} ;
         H007B2_A257AssinaturaArquivoAssinadoNome = new string[] {""} ;
         H007B2_n257AssinaturaArquivoAssinadoNome = new bool[] {false} ;
         H007B2_A254ArquivoExtensao = new string[] {""} ;
         H007B2_n254ArquivoExtensao = new bool[] {false} ;
         H007B2_A256AssinaturaArquivoAssinadoExtensao = new string[] {""} ;
         H007B2_n256AssinaturaArquivoAssinadoExtensao = new bool[] {false} ;
         H007B2_A366AssinaturaFinalizadoData = new DateTime[] {DateTime.MinValue} ;
         H007B2_n366AssinaturaFinalizadoData = new bool[] {false} ;
         H007B2_A241AssinaturaPublicKey = new Guid[] {Guid.Empty} ;
         H007B2_n241AssinaturaPublicKey = new bool[] {false} ;
         H007B2_A228ContratoNome = new string[] {""} ;
         H007B2_n228ContratoNome = new bool[] {false} ;
         H007B2_A231ArquivoId = new int[1] ;
         H007B2_n231ArquivoId = new bool[] {false} ;
         H007B2_A578ArquivoAssinadoId = new int[1] ;
         H007B2_n578ArquivoAssinadoId = new bool[] {false} ;
         H007B2_A232ArquivoBlob = new string[] {""} ;
         H007B2_n232ArquivoBlob = new bool[] {false} ;
         H007B2_A240AssinaturaArquivoAssinado = new string[] {""} ;
         H007B2_n240AssinaturaArquivoAssinado = new bool[] {false} ;
         A255ArquivoNome = "";
         A232ArquivoBlob = "";
         A232ArquivoBlob_Filename = "";
         A257AssinaturaArquivoAssinadoNome = "";
         A240AssinaturaArquivoAssinado = "";
         A240AssinaturaArquivoAssinado_Filename = "";
         A254ArquivoExtensao = "";
         A232ArquivoBlob_Filetype = "";
         A256AssinaturaArquivoAssinadoExtensao = "";
         A240AssinaturaArquivoAssinado_Filetype = "";
         A366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         A241AssinaturaPublicKey = Guid.Empty;
         A228ContratoNome = "";
         AV8AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         AV7Array_SdParticipantesContrato = new GXBaseCollection<SdtSdParticipantesContrato>( context, "SdParticipantesContrato", "Factory21");
         H007B3_A242AssinaturaParticipanteId = new int[1] ;
         H007B3_A233ParticipanteId = new int[1] ;
         H007B3_n233ParticipanteId = new bool[] {false} ;
         H007B3_A238AssinaturaId = new long[1] ;
         H007B3_n238AssinaturaId = new bool[] {false} ;
         H007B3_A248ParticipanteNome = new string[] {""} ;
         H007B3_n248ParticipanteNome = new bool[] {false} ;
         H007B3_A235ParticipanteEmail = new string[] {""} ;
         H007B3_n235ParticipanteEmail = new bool[] {false} ;
         H007B3_A350AssinaturaParticipanteCPF = new string[] {""} ;
         H007B3_n350AssinaturaParticipanteCPF = new bool[] {false} ;
         H007B3_A352AssinaturaParticipanteNascimento = new DateTime[] {DateTime.MinValue} ;
         H007B3_n352AssinaturaParticipanteNascimento = new bool[] {false} ;
         H007B3_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         H007B3_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         H007B3_A246AssinaturaParticipanteKey = new Guid[] {Guid.Empty} ;
         H007B3_n246AssinaturaParticipanteKey = new bool[] {false} ;
         H007B3_A346AssinaturaParticipanteRemoteAddres = new string[] {""} ;
         H007B3_n346AssinaturaParticipanteRemoteAddres = new bool[] {false} ;
         H007B3_A347AssinaturaParticipanteGeolocalizacao = new string[] {""} ;
         H007B3_n347AssinaturaParticipanteGeolocalizacao = new bool[] {false} ;
         H007B3_A348AssinaturaParticipanteDispositivo = new string[] {""} ;
         H007B3_n348AssinaturaParticipanteDispositivo = new bool[] {false} ;
         A248ParticipanteNome = "";
         A235ParticipanteEmail = "";
         A350AssinaturaParticipanteCPF = "";
         A352AssinaturaParticipanteNascimento = DateTime.MinValue;
         A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         A246AssinaturaParticipanteKey = Guid.Empty;
         A346AssinaturaParticipanteRemoteAddres = "";
         A347AssinaturaParticipanteGeolocalizacao = "";
         A348AssinaturaParticipanteDispositivo = "";
         AV6SdParticipantesContrato = new SdtSdParticipantesContrato(context);
         GXt_char1 = "";
         AV9ArquivoBlob = "";
         AV10AssinaturaPublicKey = Guid.Empty;
         AV11HTML = "";
         AV14assinaturaarquivoassinado = "";
         AV18Arquivo = new SdtArquivo(context);
         AV15GUID = Guid.Empty;
         AV16Source = "";
         AV17File = new GxFile(context.GetPhysicalPath());
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.verify__default(),
            new Object[][] {
                new Object[] {
               H007B2_A227ContratoId, H007B2_n227ContratoId, H007B2_A238AssinaturaId, H007B2_A255ArquivoNome, H007B2_n255ArquivoNome, H007B2_A257AssinaturaArquivoAssinadoNome, H007B2_n257AssinaturaArquivoAssinadoNome, H007B2_A254ArquivoExtensao, H007B2_n254ArquivoExtensao, H007B2_A256AssinaturaArquivoAssinadoExtensao,
               H007B2_n256AssinaturaArquivoAssinadoExtensao, H007B2_A366AssinaturaFinalizadoData, H007B2_n366AssinaturaFinalizadoData, H007B2_A241AssinaturaPublicKey, H007B2_n241AssinaturaPublicKey, H007B2_A228ContratoNome, H007B2_n228ContratoNome, H007B2_A231ArquivoId, H007B2_n231ArquivoId, H007B2_A578ArquivoAssinadoId,
               H007B2_n578ArquivoAssinadoId, H007B2_A232ArquivoBlob, H007B2_n232ArquivoBlob, H007B2_A240AssinaturaArquivoAssinado, H007B2_n240AssinaturaArquivoAssinado
               }
               , new Object[] {
               H007B3_A242AssinaturaParticipanteId, H007B3_A233ParticipanteId, H007B3_n233ParticipanteId, H007B3_A238AssinaturaId, H007B3_n238AssinaturaId, H007B3_A248ParticipanteNome, H007B3_n248ParticipanteNome, H007B3_A235ParticipanteEmail, H007B3_n235ParticipanteEmail, H007B3_A350AssinaturaParticipanteCPF,
               H007B3_n350AssinaturaParticipanteCPF, H007B3_A352AssinaturaParticipanteNascimento, H007B3_n352AssinaturaParticipanteNascimento, H007B3_A245AssinaturaParticipanteDataConclusao, H007B3_n245AssinaturaParticipanteDataConclusao, H007B3_A246AssinaturaParticipanteKey, H007B3_n246AssinaturaParticipanteKey, H007B3_A346AssinaturaParticipanteRemoteAddres, H007B3_n346AssinaturaParticipanteRemoteAddres, H007B3_A347AssinaturaParticipanteGeolocalizacao,
               H007B3_n347AssinaturaParticipanteGeolocalizacao, H007B3_A348AssinaturaParticipanteDispositivo, H007B3_n348AssinaturaParticipanteDispositivo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV13ArquivoId ;
      private int AV19ArquivoAssinadoId ;
      private int A227ContratoId ;
      private int A231ArquivoId ;
      private int A578ArquivoAssinadoId ;
      private int A233ParticipanteId ;
      private int idxLst ;
      private long AV5AssinaturaId ;
      private long wcpOAV5AssinaturaId ;
      private long A238AssinaturaId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Novajanela_Target ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string divTablebuttons_Internalname ;
      private string bttBtndownloaddocumentooriginal_Internalname ;
      private string bttBtndownloaddocumentooriginal_Jsonclick ;
      private string bttBtndownloaddocumentoassinado_Internalname ;
      private string bttBtndownloaddocumentoassinado_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string lblTxtlista_Internalname ;
      private string lblTxtlista_Caption ;
      private string lblTxtlista_Jsonclick ;
      private string Novajanela_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string A232ArquivoBlob_Filename ;
      private string A240AssinaturaArquivoAssinado_Filename ;
      private string A232ArquivoBlob_Filetype ;
      private string A240AssinaturaArquivoAssinado_Filetype ;
      private string GXt_char1 ;
      private DateTime A366AssinaturaFinalizadoData ;
      private DateTime AV8AssinaturaFinalizadoData ;
      private DateTime A245AssinaturaParticipanteDataConclusao ;
      private DateTime A352AssinaturaParticipanteNascimento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n227ContratoId ;
      private bool n238AssinaturaId ;
      private bool n255ArquivoNome ;
      private bool n257AssinaturaArquivoAssinadoNome ;
      private bool n254ArquivoExtensao ;
      private bool n256AssinaturaArquivoAssinadoExtensao ;
      private bool n366AssinaturaFinalizadoData ;
      private bool n241AssinaturaPublicKey ;
      private bool n228ContratoNome ;
      private bool n231ArquivoId ;
      private bool n578ArquivoAssinadoId ;
      private bool n232ArquivoBlob ;
      private bool n240AssinaturaArquivoAssinado ;
      private bool n233ParticipanteId ;
      private bool n248ParticipanteNome ;
      private bool n235ParticipanteEmail ;
      private bool n350AssinaturaParticipanteCPF ;
      private bool n352AssinaturaParticipanteNascimento ;
      private bool n245AssinaturaParticipanteDataConclusao ;
      private bool n246AssinaturaParticipanteKey ;
      private bool n346AssinaturaParticipanteRemoteAddres ;
      private bool n347AssinaturaParticipanteGeolocalizacao ;
      private bool n348AssinaturaParticipanteDispositivo ;
      private string AV11HTML ;
      private string A255ArquivoNome ;
      private string A257AssinaturaArquivoAssinadoNome ;
      private string A254ArquivoExtensao ;
      private string A256AssinaturaArquivoAssinadoExtensao ;
      private string A228ContratoNome ;
      private string A248ParticipanteNome ;
      private string A235ParticipanteEmail ;
      private string A350AssinaturaParticipanteCPF ;
      private string A346AssinaturaParticipanteRemoteAddres ;
      private string A347AssinaturaParticipanteGeolocalizacao ;
      private string A348AssinaturaParticipanteDispositivo ;
      private string AV16Source ;
      private Guid A241AssinaturaPublicKey ;
      private Guid A246AssinaturaParticipanteKey ;
      private Guid AV10AssinaturaPublicKey ;
      private Guid AV15GUID ;
      private string A232ArquivoBlob ;
      private string A240AssinaturaArquivoAssinado ;
      private string AV9ArquivoBlob ;
      private string AV14assinaturaarquivoassinado ;
      private GXUserControl ucNovajanela ;
      private GxFile AV17File ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H007B2_A227ContratoId ;
      private bool[] H007B2_n227ContratoId ;
      private long[] H007B2_A238AssinaturaId ;
      private bool[] H007B2_n238AssinaturaId ;
      private string[] H007B2_A255ArquivoNome ;
      private bool[] H007B2_n255ArquivoNome ;
      private string[] H007B2_A257AssinaturaArquivoAssinadoNome ;
      private bool[] H007B2_n257AssinaturaArquivoAssinadoNome ;
      private string[] H007B2_A254ArquivoExtensao ;
      private bool[] H007B2_n254ArquivoExtensao ;
      private string[] H007B2_A256AssinaturaArquivoAssinadoExtensao ;
      private bool[] H007B2_n256AssinaturaArquivoAssinadoExtensao ;
      private DateTime[] H007B2_A366AssinaturaFinalizadoData ;
      private bool[] H007B2_n366AssinaturaFinalizadoData ;
      private Guid[] H007B2_A241AssinaturaPublicKey ;
      private bool[] H007B2_n241AssinaturaPublicKey ;
      private string[] H007B2_A228ContratoNome ;
      private bool[] H007B2_n228ContratoNome ;
      private int[] H007B2_A231ArquivoId ;
      private bool[] H007B2_n231ArquivoId ;
      private int[] H007B2_A578ArquivoAssinadoId ;
      private bool[] H007B2_n578ArquivoAssinadoId ;
      private string[] H007B2_A232ArquivoBlob ;
      private bool[] H007B2_n232ArquivoBlob ;
      private string[] H007B2_A240AssinaturaArquivoAssinado ;
      private bool[] H007B2_n240AssinaturaArquivoAssinado ;
      private GXBaseCollection<SdtSdParticipantesContrato> AV7Array_SdParticipantesContrato ;
      private int[] H007B3_A242AssinaturaParticipanteId ;
      private int[] H007B3_A233ParticipanteId ;
      private bool[] H007B3_n233ParticipanteId ;
      private long[] H007B3_A238AssinaturaId ;
      private bool[] H007B3_n238AssinaturaId ;
      private string[] H007B3_A248ParticipanteNome ;
      private bool[] H007B3_n248ParticipanteNome ;
      private string[] H007B3_A235ParticipanteEmail ;
      private bool[] H007B3_n235ParticipanteEmail ;
      private string[] H007B3_A350AssinaturaParticipanteCPF ;
      private bool[] H007B3_n350AssinaturaParticipanteCPF ;
      private DateTime[] H007B3_A352AssinaturaParticipanteNascimento ;
      private bool[] H007B3_n352AssinaturaParticipanteNascimento ;
      private DateTime[] H007B3_A245AssinaturaParticipanteDataConclusao ;
      private bool[] H007B3_n245AssinaturaParticipanteDataConclusao ;
      private Guid[] H007B3_A246AssinaturaParticipanteKey ;
      private bool[] H007B3_n246AssinaturaParticipanteKey ;
      private string[] H007B3_A346AssinaturaParticipanteRemoteAddres ;
      private bool[] H007B3_n346AssinaturaParticipanteRemoteAddres ;
      private string[] H007B3_A347AssinaturaParticipanteGeolocalizacao ;
      private bool[] H007B3_n347AssinaturaParticipanteGeolocalizacao ;
      private string[] H007B3_A348AssinaturaParticipanteDispositivo ;
      private bool[] H007B3_n348AssinaturaParticipanteDispositivo ;
      private SdtSdParticipantesContrato AV6SdParticipantesContrato ;
      private SdtArquivo AV18Arquivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class verify__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH007B2;
          prmH007B2 = new Object[] {
          new ParDef("AV5AssinaturaId",GXType.Int64,10,0)
          };
          Object[] prmH007B3;
          prmH007B3 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("H007B2", "SELECT T1.ContratoId, T1.AssinaturaId, T3.ArquivoNome, T1.AssinaturaArquivoAssinadoNome, T3.ArquivoExtensao, T1.AssinaturaArquivoAssinadoExtensao, T1.AssinaturaFinalizadoData, T1.AssinaturaPublicKey, T2.ContratoNome, T1.ArquivoId, T1.ArquivoAssinadoId, T3.ArquivoBlob, T1.AssinaturaArquivoAssinado FROM ((Assinatura T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN Arquivo T3 ON T3.ArquivoId = T1.ArquivoId) WHERE T1.AssinaturaId = :AV5AssinaturaId ORDER BY T1.AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007B2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H007B3", "SELECT T1.AssinaturaParticipanteId, T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteNome, T2.ParticipanteEmail, T1.AssinaturaParticipanteCPF, T1.AssinaturaParticipanteNascimento, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteKey, T1.AssinaturaParticipanteRemoteAddres, T1.AssinaturaParticipanteGeolocalizacao, T1.AssinaturaParticipanteDispositivo FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId) WHERE T1.AssinaturaId = :AssinaturaId ORDER BY T1.AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007B3,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getBLOBFile(12, rslt.getVarchar(5), rslt.getVarchar(3));
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getBLOBFile(13, rslt.getVarchar(6), rslt.getVarchar(4));
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((Guid[]) buf[15])[0] = rslt.getGuid(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
       }
    }

 }

}
