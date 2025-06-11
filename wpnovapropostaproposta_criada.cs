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
   public class wpnovapropostaproposta_criada : GXWebComponent
   {
      public wpnovapropostaproposta_criada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wpnovapropostaproposta_criada( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WebSessionKey ,
                           string aP1_PreviousStep ,
                           bool aP2_GoingBack )
      {
         this.AV6WebSessionKey = aP0_WebSessionKey;
         this.AV8PreviousStep = aP1_PreviousStep;
         this.AV7GoingBack = aP2_GoingBack;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV6WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
                  AV8PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
                  AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WebSessionKey,(string)AV8PreviousStep,(bool)AV7GoingBack});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA5O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS5O2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Wp Nova Proposta Proposta_Criada") ;
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
         }
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
         context.AddJavascriptSource("UserControls/UCPropostaComprovanteRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpnovapropostaproposta_criada"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpnovapropostaproposta_criada") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
      }

      protected void RenderHtmlCloseForm5O2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WpNovaPropostaProposta_Criada" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wp Nova Proposta Proposta_Criada" ;
      }

      protected void WB5O0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpnovapropostaproposta_criada");
               context.AddJavascriptSource("UserControls/UCPropostaComprovanteRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtndownload_Internalname, "", "Download", bttBtnbtndownload_Jsonclick, 7, "Download", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e115o1_client"+"'", TempTags, "", 2, "HLP_WpNovaPropostaProposta_Criada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtcomprovante_Internalname, lblTxtcomprovante_Caption, "", "", lblTxtcomprovante_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpNovaPropostaProposta_Criada.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDownload.Render(context, "ucpropostacomprovante", Download_Internalname, sPrefix+"DOWNLOADContainer");
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

      protected void START5O2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
               }
            }
            Form.Meta.addItem("description", "Wp Nova Proposta Proposta_Criada", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP5O0( ) ;
            }
         }
      }

      protected void WS5O2( )
      {
         START5O2( ) ;
         EVT5O2( ) ;
      }

      protected void EVT5O2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E125O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E135O2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E145O2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
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

      protected void WE5O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm5O2( ) ;
            }
         }
      }

      protected void PA5O2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpnovapropostaproposta_criada")), "wpnovapropostaproposta_criada") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpnovapropostaproposta_criada")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "WebSessionKey");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
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
         RF5O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF5O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E145O2 ();
            WB5O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5O2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E125O2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
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
         E125O2 ();
         if (returnInSub) return;
      }

      protected void E125O2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV23WwpContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV23WwpContext = GXt_SdtWWPContext1;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E135O2 ();
         if (returnInSub) return;
      }

      protected void E135O2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S122 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S132 ();
            if (returnInSub) return;
            AV5WebSession.Remove(AV6WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV12PropostaValor = AV11WizardData.gxTpr_Proposta.gxTpr_Propostavalor;
         AV14PropostaDescricao = AV11WizardData.gxTpr_Proposta.gxTpr_Propostadescricao;
         AV17ProcedimentosMedicosId = AV11WizardData.gxTpr_Proposta.gxTpr_Procedimentosmedicosid;
         AV15ClienteId = AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteid;
         AV30ConvenioId = AV11WizardData.gxTpr_Proposta.gxTpr_Convenioid;
         AssignAttri(sPrefix, false, "AV30ConvenioId", StringUtil.LTrimStr( (decimal)(AV30ConvenioId), 9, 0));
         /* Using cursor H005O2 */
         pr_default.execute(0, new Object[] {AV30ConvenioId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A410ConvenioId = H005O2_A410ConvenioId[0];
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV39SdComprovante.gxTpr_Clientedocumento = AV11WizardData.gxTpr_Novocliente.gxTpr_Clientedocumento;
         AV39SdComprovante.gxTpr_Clienterazaosocial = AV11WizardData.gxTpr_Novocliente.gxTpr_Clienterazaosocial;
         AV39SdComprovante.gxTpr_Clientetipopessoa = AV11WizardData.gxTpr_Novocliente.gxTpr_Clientetipopessoa;
         /* Using cursor H005O3 */
         pr_default.execute(1, new Object[] {AV11WizardData.gxTpr_Novocliente.gxTpr_Tipoclienteid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A192TipoClienteId = H005O3_A192TipoClienteId[0];
            A193TipoClienteDescricao = H005O3_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = H005O3_n193TipoClienteDescricao[0];
            AV20TipoClienteDescricao = A193TipoClienteDescricao;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV39SdComprovante.gxTpr_Clientetipoclientedescricao = AV20TipoClienteDescricao;
         AV39SdComprovante.gxTpr_Clientedatanascimento = AV11WizardData.gxTpr_Novocliente.gxTpr_Clientedatanascimento;
         AV39SdComprovante.gxTpr_Clienterg = AV11WizardData.gxTpr_Novocliente.gxTpr_Clienterg;
         /* Using cursor H005O4 */
         pr_default.execute(2, new Object[] {AV11WizardData.gxTpr_Novocliente.gxTpr_Clientenacionalidade});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A434NacionalidadeId = H005O4_A434NacionalidadeId[0];
            A435NacionalidadeNome = H005O4_A435NacionalidadeNome[0];
            n435NacionalidadeNome = H005O4_n435NacionalidadeNome[0];
            AV38NacionalidadeNome = A435NacionalidadeNome;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         AV39SdComprovante.gxTpr_Clientenacionalidadenome = AV38NacionalidadeNome;
         AV39SdComprovante.gxTpr_Clienteestadocivil = AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteestadocivil;
         /* Using cursor H005O5 */
         pr_default.execute(3, new Object[] {AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteprofissao});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A440ProfissaoId = H005O5_A440ProfissaoId[0];
            A441ProfissaoNome = H005O5_A441ProfissaoNome[0];
            n441ProfissaoNome = H005O5_n441ProfissaoNome[0];
            AV37ProfissaoNome = A441ProfissaoNome;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         AV39SdComprovante.gxTpr_Clienteprofissaonome = AV37ProfissaoNome;
         AV39SdComprovante.gxTpr_Clienteenderecocep = AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecocep;
         AV39SdComprovante.gxTpr_Clienteenderecologradouro = AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecologradouro;
         AV39SdComprovante.gxTpr_Clienteenderecobairro = AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecobairro;
         AV39SdComprovante.gxTpr_Clienteenderecocidade = AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecocidade;
         AV39SdComprovante.gxTpr_Clienteenderecomunicipionome = AV11WizardData.gxTpr_Novocliente.gxTpr_Municipionome;
         AV39SdComprovante.gxTpr_Clienteenderecomunicipiouf = AV11WizardData.gxTpr_Novocliente.gxTpr_Municipiouf;
         AV39SdComprovante.gxTpr_Clienteendereconumero = AV11WizardData.gxTpr_Novocliente.gxTpr_Endereconumero;
         AV39SdComprovante.gxTpr_Clienteenderecocomplemento = AV11WizardData.gxTpr_Novocliente.gxTpr_Enderecocomplemento;
         AV39SdComprovante.gxTpr_Contatoemail = AV11WizardData.gxTpr_Novocliente.gxTpr_Contatoemail;
         AV39SdComprovante.gxTpr_Contatoddd = AV11WizardData.gxTpr_Novocliente.gxTpr_Contatoddd;
         AV39SdComprovante.gxTpr_Contatonumero = AV11WizardData.gxTpr_Novocliente.gxTpr_Contatonumero;
         AV39SdComprovante.gxTpr_Responsaveldocumento = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientedocumento;
         AV39SdComprovante.gxTpr_Responsavelrazaosocial = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienterazaosocial;
         AV39SdComprovante.gxTpr_Responsaveltipopessoa = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientetipopessoa;
         AV20TipoClienteDescricao = "";
         /* Using cursor H005O6 */
         pr_default.execute(4, new Object[] {AV11WizardData.gxTpr_Responsavel.gxTpr_Responsaveltipoclienteid});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A192TipoClienteId = H005O6_A192TipoClienteId[0];
            A193TipoClienteDescricao = H005O6_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = H005O6_n193TipoClienteDescricao[0];
            AV20TipoClienteDescricao = A193TipoClienteDescricao;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         AV39SdComprovante.gxTpr_Responsaveltipoclientedescricao = AV20TipoClienteDescricao;
         AV39SdComprovante.gxTpr_Responsaveldatanascimento = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientedatanascimento;
         AV39SdComprovante.gxTpr_Responsavelrg = StringUtil.Trim( StringUtil.Str( (decimal)(AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienterg), 12, 0));
         AV38NacionalidadeNome = "";
         /* Using cursor H005O7 */
         pr_default.execute(5, new Object[] {AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientenacionalidade});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A434NacionalidadeId = H005O7_A434NacionalidadeId[0];
            A435NacionalidadeNome = H005O7_A435NacionalidadeNome[0];
            n435NacionalidadeNome = H005O7_n435NacionalidadeNome[0];
            AV38NacionalidadeNome = A435NacionalidadeNome;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
         AV39SdComprovante.gxTpr_Responsavelnacionalidade = AV38NacionalidadeNome;
         AV39SdComprovante.gxTpr_Responsavelestadocivil = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienteestadocivil;
         AV37ProfissaoNome = "";
         /* Using cursor H005O8 */
         pr_default.execute(6, new Object[] {AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienteprofissao});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A440ProfissaoId = H005O8_A440ProfissaoId[0];
            A441ProfissaoNome = H005O8_A441ProfissaoNome[0];
            n441ProfissaoNome = H005O8_n441ProfissaoNome[0];
            AV37ProfissaoNome = A441ProfissaoNome;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
         AV39SdComprovante.gxTpr_Responsavelprofissao = AV37ProfissaoNome;
         AV39SdComprovante.gxTpr_Responsavelcontatoemail = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatoemail;
         AV39SdComprovante.gxTpr_Responsavelcontatoddd = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatoddd;
         AV39SdComprovante.gxTpr_Responsavelcontatonumero = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatonumero;
         AV39SdComprovante.gxTpr_Bancopixtipo = ((StringUtil.StrCmp(AV11WizardData.gxTpr_Conta.gxTpr_Clientedepositotipo, "Pix")==0) ? "PIX" : "BANCO");
         AV39SdComprovante.gxTpr_Bancopixchave = StringUtil.Trim( AV11WizardData.gxTpr_Conta.gxTpr_Clientepix);
         /* Using cursor H005O9 */
         pr_default.execute(7, new Object[] {AV11WizardData.gxTpr_Conta.gxTpr_Bancoid});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A402BancoId = H005O9_A402BancoId[0];
            A403BancoNome = H005O9_A403BancoNome[0];
            n403BancoNome = H005O9_n403BancoNome[0];
            AV26BancoNome = A403BancoNome;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(7);
         AV39SdComprovante.gxTpr_Banconome = AV26BancoNome;
         AV39SdComprovante.gxTpr_Bancoagencia = AV11WizardData.gxTpr_Conta.gxTpr_Contaagencia;
         AV39SdComprovante.gxTpr_Bancoconta = AV11WizardData.gxTpr_Conta.gxTpr_Contanumero;
         /* Using cursor H005O10 */
         pr_default.execute(8, new Object[] {AV11WizardData.gxTpr_Proposta.gxTpr_Procedimentosmedicosid});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A376ProcedimentosMedicosId = H005O10_A376ProcedimentosMedicosId[0];
            A378ProcedimentosMedicosDescricao = H005O10_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = H005O10_n378ProcedimentosMedicosDescricao[0];
            AV22ProcedimentosMedicosDescricao = A378ProcedimentosMedicosDescricao;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(8);
         AV39SdComprovante.gxTpr_Propostaprocedimentosmedicos = AV22ProcedimentosMedicosDescricao;
         AV39SdComprovante.gxTpr_Propostavalor = AV11WizardData.gxTpr_Proposta.gxTpr_Propostavalor;
         /* Using cursor H005O11 */
         pr_default.execute(9, new Object[] {AV11WizardData.gxTpr_Proposta.gxTpr_Convenioid});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A410ConvenioId = H005O11_A410ConvenioId[0];
            A411ConvenioDescricao = H005O11_A411ConvenioDescricao[0];
            n411ConvenioDescricao = H005O11_n411ConvenioDescricao[0];
            AV40ConvenioDescricao = A411ConvenioDescricao;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(9);
         AV39SdComprovante.gxTpr_Propostaconvenio = AV40ConvenioDescricao;
         /* Using cursor H005O12 */
         pr_default.execute(10, new Object[] {AV11WizardData.gxTpr_Proposta.gxTpr_Conveniocategoriaid});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A493ConvenioCategoriaId = H005O12_A493ConvenioCategoriaId[0];
            A494ConvenioCategoriaDescricao = H005O12_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = H005O12_n494ConvenioCategoriaDescricao[0];
            AV41ConvenioCategoriaDescricao = A494ConvenioCategoriaDescricao;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(10);
         AV39SdComprovante.gxTpr_Propostacategoriaconvenio = AV41ConvenioCategoriaDescricao;
         AV39SdComprovante.gxTpr_Propostavencimentocarteirinha = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV11WizardData.gxTpr_Proposta.gxTpr_Conveniovencimentomes), 4, 0)), 2, "0"), StringUtil.Trim( StringUtil.Str( (decimal)(AV11WizardData.gxTpr_Proposta.gxTpr_Conveniovencimentoano), 4, 0)), "", "", "", "", "", "", "");
         new prhtmlcomprovante(context ).execute(  AV39SdComprovante, out  AV35HTML) ;
         lblTxtcomprovante_Caption = AV35HTML;
         AssignProp(sPrefix, false, lblTxtcomprovante_Internalname, "Caption", lblTxtcomprovante_Caption, true);
      }

      protected void S122( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S132( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
      }

      protected void nextLoad( )
      {
      }

      protected void E145O2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         AV8PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         AV7GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
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
         PA5O2( ) ;
         WS5O2( ) ;
         WE5O2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SESSION ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV6WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV8PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV7GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA5O2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpnovapropostaproposta_criada", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA5O2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
            AV8PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
            AV7GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
         wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
         wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WebSessionKey, wcpOAV6WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV8PreviousStep, wcpOAV8PreviousStep) != 0 ) || ( AV7GoingBack != wcpOAV7GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WebSessionKey = AV6WebSessionKey;
         wcpOAV8PreviousStep = AV8PreviousStep;
         wcpOAV7GoingBack = AV7GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV6WebSessionKey) > 0 )
         {
            AV6WebSessionKey = cgiGet( sCtrlAV6WebSessionKey);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         }
         else
         {
            AV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_PARM");
         }
         sCtrlAV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV8PreviousStep) > 0 )
         {
            AV8PreviousStep = cgiGet( sCtrlAV8PreviousStep);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         }
         else
         {
            AV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_PARM");
         }
         sCtrlAV7GoingBack = cgiGet( sPrefix+"AV7GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV7GoingBack) > 0 )
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV7GoingBack));
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         else
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV7GoingBack_PARM"));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA5O2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS5O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS5O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_PARM", AV6WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV6WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_PARM", AV8PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV8PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_PARM", StringUtil.BoolToStr( AV7GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_CTRL", StringUtil.RTrim( sCtrlAV7GoingBack));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE5O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019154423", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("wpnovapropostaproposta_criada.js", "?202561019154429", false, true);
         context.AddJavascriptSource("UserControls/UCPropostaComprovanteRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnbtndownload_Internalname = sPrefix+"BTNBTNDOWNLOAD";
         lblTxtcomprovante_Internalname = sPrefix+"TXTCOMPROVANTE";
         Download_Internalname = sPrefix+"DOWNLOAD";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         lblTxtcomprovante_Caption = "";
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"}]}""");
         setEventMetadata("ENTER","""{"handler":"E135O2","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""}]}""");
         setEventMetadata("'DOBTNDOWNLOAD'","""{"handler":"E115O1","iparms":[]}""");
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
         wcpOAV6WebSessionKey = "";
         wcpOAV8PreviousStep = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnbtndownload_Jsonclick = "";
         lblTxtcomprovante_Jsonclick = "";
         ucDownload = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV23WwpContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV5WebSession = context.GetSession();
         AV11WizardData = new SdtWpNovaPropostaData(context);
         AV14PropostaDescricao = "";
         H005O2_A410ConvenioId = new int[1] ;
         AV39SdComprovante = new SdtSdComprovante(context);
         H005O3_A192TipoClienteId = new short[1] ;
         H005O3_A193TipoClienteDescricao = new string[] {""} ;
         H005O3_n193TipoClienteDescricao = new bool[] {false} ;
         A193TipoClienteDescricao = "";
         AV20TipoClienteDescricao = "";
         H005O4_A434NacionalidadeId = new int[1] ;
         H005O4_A435NacionalidadeNome = new string[] {""} ;
         H005O4_n435NacionalidadeNome = new bool[] {false} ;
         A435NacionalidadeNome = "";
         AV38NacionalidadeNome = "";
         H005O5_A440ProfissaoId = new int[1] ;
         H005O5_A441ProfissaoNome = new string[] {""} ;
         H005O5_n441ProfissaoNome = new bool[] {false} ;
         A441ProfissaoNome = "";
         AV37ProfissaoNome = "";
         H005O6_A192TipoClienteId = new short[1] ;
         H005O6_A193TipoClienteDescricao = new string[] {""} ;
         H005O6_n193TipoClienteDescricao = new bool[] {false} ;
         H005O7_A434NacionalidadeId = new int[1] ;
         H005O7_A435NacionalidadeNome = new string[] {""} ;
         H005O7_n435NacionalidadeNome = new bool[] {false} ;
         H005O8_A440ProfissaoId = new int[1] ;
         H005O8_A441ProfissaoNome = new string[] {""} ;
         H005O8_n441ProfissaoNome = new bool[] {false} ;
         H005O9_A402BancoId = new int[1] ;
         H005O9_A403BancoNome = new string[] {""} ;
         H005O9_n403BancoNome = new bool[] {false} ;
         A403BancoNome = "";
         AV26BancoNome = "";
         H005O10_A376ProcedimentosMedicosId = new int[1] ;
         H005O10_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         H005O10_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         A378ProcedimentosMedicosDescricao = "";
         AV22ProcedimentosMedicosDescricao = "";
         H005O11_A410ConvenioId = new int[1] ;
         H005O11_A411ConvenioDescricao = new string[] {""} ;
         H005O11_n411ConvenioDescricao = new bool[] {false} ;
         A411ConvenioDescricao = "";
         AV40ConvenioDescricao = "";
         H005O12_A493ConvenioCategoriaId = new int[1] ;
         H005O12_A494ConvenioCategoriaDescricao = new string[] {""} ;
         H005O12_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         A494ConvenioCategoriaDescricao = "";
         AV41ConvenioCategoriaDescricao = "";
         AV35HTML = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpnovapropostaproposta_criada__default(),
            new Object[][] {
                new Object[] {
               H005O2_A410ConvenioId
               }
               , new Object[] {
               H005O3_A192TipoClienteId, H005O3_A193TipoClienteDescricao, H005O3_n193TipoClienteDescricao
               }
               , new Object[] {
               H005O4_A434NacionalidadeId, H005O4_A435NacionalidadeNome, H005O4_n435NacionalidadeNome
               }
               , new Object[] {
               H005O5_A440ProfissaoId, H005O5_A441ProfissaoNome, H005O5_n441ProfissaoNome
               }
               , new Object[] {
               H005O6_A192TipoClienteId, H005O6_A193TipoClienteDescricao, H005O6_n193TipoClienteDescricao
               }
               , new Object[] {
               H005O7_A434NacionalidadeId, H005O7_A435NacionalidadeNome, H005O7_n435NacionalidadeNome
               }
               , new Object[] {
               H005O8_A440ProfissaoId, H005O8_A441ProfissaoNome, H005O8_n441ProfissaoNome
               }
               , new Object[] {
               H005O9_A402BancoId, H005O9_A403BancoNome, H005O9_n403BancoNome
               }
               , new Object[] {
               H005O10_A376ProcedimentosMedicosId, H005O10_A378ProcedimentosMedicosDescricao, H005O10_n378ProcedimentosMedicosDescricao
               }
               , new Object[] {
               H005O11_A410ConvenioId, H005O11_A411ConvenioDescricao, H005O11_n411ConvenioDescricao
               }
               , new Object[] {
               H005O12_A493ConvenioCategoriaId, H005O12_A494ConvenioCategoriaDescricao, H005O12_n494ConvenioCategoriaDescricao
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_13 ;
      private short nIsMod_13 ;
      private short nRcdExists_12 ;
      private short nIsMod_12 ;
      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short A192TipoClienteId ;
      private short nGXWrapped ;
      private int AV17ProcedimentosMedicosId ;
      private int AV15ClienteId ;
      private int AV30ConvenioId ;
      private int A410ConvenioId ;
      private int A434NacionalidadeId ;
      private int A440ProfissaoId ;
      private int A402BancoId ;
      private int A376ProcedimentosMedicosId ;
      private int A493ConvenioCategoriaId ;
      private int idxLst ;
      private decimal AV12PropostaValor ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnbtndownload_Internalname ;
      private string bttBtnbtndownload_Jsonclick ;
      private string lblTxtcomprovante_Internalname ;
      private string lblTxtcomprovante_Caption ;
      private string lblTxtcomprovante_Jsonclick ;
      private string Download_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n193TipoClienteDescricao ;
      private bool n435NacionalidadeNome ;
      private bool n441ProfissaoNome ;
      private bool n403BancoNome ;
      private bool n378ProcedimentosMedicosDescricao ;
      private bool n411ConvenioDescricao ;
      private bool n494ConvenioCategoriaDescricao ;
      private string A378ProcedimentosMedicosDescricao ;
      private string AV22ProcedimentosMedicosDescricao ;
      private string AV35HTML ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV14PropostaDescricao ;
      private string A193TipoClienteDescricao ;
      private string AV20TipoClienteDescricao ;
      private string A435NacionalidadeNome ;
      private string AV38NacionalidadeNome ;
      private string A441ProfissaoNome ;
      private string AV37ProfissaoNome ;
      private string A403BancoNome ;
      private string AV26BancoNome ;
      private string A411ConvenioDescricao ;
      private string AV40ConvenioDescricao ;
      private string A494ConvenioCategoriaDescricao ;
      private string AV41ConvenioCategoriaDescricao ;
      private GXUserControl ucDownload ;
      private GXWebForm Form ;
      private IGxSession AV5WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV23WwpContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private SdtWpNovaPropostaData AV11WizardData ;
      private IDataStoreProvider pr_default ;
      private int[] H005O2_A410ConvenioId ;
      private SdtSdComprovante AV39SdComprovante ;
      private short[] H005O3_A192TipoClienteId ;
      private string[] H005O3_A193TipoClienteDescricao ;
      private bool[] H005O3_n193TipoClienteDescricao ;
      private int[] H005O4_A434NacionalidadeId ;
      private string[] H005O4_A435NacionalidadeNome ;
      private bool[] H005O4_n435NacionalidadeNome ;
      private int[] H005O5_A440ProfissaoId ;
      private string[] H005O5_A441ProfissaoNome ;
      private bool[] H005O5_n441ProfissaoNome ;
      private short[] H005O6_A192TipoClienteId ;
      private string[] H005O6_A193TipoClienteDescricao ;
      private bool[] H005O6_n193TipoClienteDescricao ;
      private int[] H005O7_A434NacionalidadeId ;
      private string[] H005O7_A435NacionalidadeNome ;
      private bool[] H005O7_n435NacionalidadeNome ;
      private int[] H005O8_A440ProfissaoId ;
      private string[] H005O8_A441ProfissaoNome ;
      private bool[] H005O8_n441ProfissaoNome ;
      private int[] H005O9_A402BancoId ;
      private string[] H005O9_A403BancoNome ;
      private bool[] H005O9_n403BancoNome ;
      private int[] H005O10_A376ProcedimentosMedicosId ;
      private string[] H005O10_A378ProcedimentosMedicosDescricao ;
      private bool[] H005O10_n378ProcedimentosMedicosDescricao ;
      private int[] H005O11_A410ConvenioId ;
      private string[] H005O11_A411ConvenioDescricao ;
      private bool[] H005O11_n411ConvenioDescricao ;
      private int[] H005O12_A493ConvenioCategoriaId ;
      private string[] H005O12_A494ConvenioCategoriaDescricao ;
      private bool[] H005O12_n494ConvenioCategoriaDescricao ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpnovapropostaproposta_criada__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005O2;
          prmH005O2 = new Object[] {
          new ParDef("AV30ConvenioId",GXType.Int32,9,0)
          };
          Object[] prmH005O3;
          prmH005O3 = new Object[] {
          new ParDef("AV11Wiza_1Novocliente_1Tipocl",GXType.Int16,4,0)
          };
          Object[] prmH005O4;
          prmH005O4 = new Object[] {
          new ParDef("AV11Wiza_2Novocliente_2Client",GXType.Int32,9,0)
          };
          Object[] prmH005O5;
          prmH005O5 = new Object[] {
          new ParDef("AV11Wiza_3Novocliente_3Client",GXType.Int32,9,0)
          };
          Object[] prmH005O6;
          prmH005O6 = new Object[] {
          new ParDef("AV11Wiza_4Responsavel_4Respon",GXType.Int16,4,0)
          };
          Object[] prmH005O7;
          prmH005O7 = new Object[] {
          new ParDef("AV11Wiza_5Responsavel_5Respon",GXType.Int32,9,0)
          };
          Object[] prmH005O8;
          prmH005O8 = new Object[] {
          new ParDef("AV11Wiza_6Responsavel_6Respon",GXType.Int32,9,0)
          };
          Object[] prmH005O9;
          prmH005O9 = new Object[] {
          new ParDef("AV11Wiza_7Conta_7Bancoid",GXType.Int32,9,0)
          };
          Object[] prmH005O10;
          prmH005O10 = new Object[] {
          new ParDef("AV11Wiza_8Proposta_8Procedime",GXType.Int32,9,0)
          };
          Object[] prmH005O11;
          prmH005O11 = new Object[] {
          new ParDef("AV11Wiza_9Proposta_9Convenioi",GXType.Int32,9,0)
          };
          Object[] prmH005O12;
          prmH005O12 = new Object[] {
          new ParDef("AV11Wiza_10Proposta_10Conveni",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005O2", "SELECT ConvenioId FROM Convenio WHERE ConvenioId = :AV30ConvenioId ORDER BY ConvenioId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H005O3", "SELECT TipoClienteId, TipoClienteDescricao FROM TipoCliente WHERE TipoClienteId = :AV11Wiza_1Novocliente_1Tipocl ORDER BY TipoClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H005O4", "SELECT NacionalidadeId, NacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :AV11Wiza_2Novocliente_2Client ORDER BY NacionalidadeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H005O5", "SELECT ProfissaoId, ProfissaoNome FROM Profissao WHERE ProfissaoId = :AV11Wiza_3Novocliente_3Client ORDER BY ProfissaoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H005O6", "SELECT TipoClienteId, TipoClienteDescricao FROM TipoCliente WHERE TipoClienteId = :AV11Wiza_4Responsavel_4Respon ORDER BY TipoClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H005O7", "SELECT NacionalidadeId, NacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :AV11Wiza_5Responsavel_5Respon ORDER BY NacionalidadeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H005O8", "SELECT ProfissaoId, ProfissaoNome FROM Profissao WHERE ProfissaoId = :AV11Wiza_6Responsavel_6Respon ORDER BY ProfissaoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H005O9", "SELECT BancoId, BancoNome FROM Banco WHERE BancoId = :AV11Wiza_7Conta_7Bancoid ORDER BY BancoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H005O10", "SELECT ProcedimentosMedicosId, ProcedimentosMedicosDescricao FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :AV11Wiza_8Proposta_8Procedime ORDER BY ProcedimentosMedicosId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H005O11", "SELECT ConvenioId, ConvenioDescricao FROM Convenio WHERE ConvenioId = :AV11Wiza_9Proposta_9Convenioi ORDER BY ConvenioId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O11,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H005O12", "SELECT ConvenioCategoriaId, ConvenioCategoriaDescricao FROM ConvenioCategoria WHERE ConvenioCategoriaId = :AV11Wiza_10Proposta_10Conveni ORDER BY ConvenioCategoriaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O12,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
