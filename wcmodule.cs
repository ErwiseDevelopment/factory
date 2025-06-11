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
   public class wcmodule : GXWebComponent
   {
      public wcmodule( )
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

      public wcmodule( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Nome ,
                           string aP1_Icon ,
                           string aP2_Link ,
                           string aP3_DmSistema )
      {
         this.AV5Nome = aP0_Nome;
         this.AV6Icon = aP1_Icon;
         this.AV7Link = aP2_Link;
         this.AV8DmSistema = aP3_DmSistema;
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
               gxfirstwebparm = GetFirstPar( "Nome");
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
                  AV5Nome = GetPar( "Nome");
                  AssignAttri(sPrefix, false, "AV5Nome", AV5Nome);
                  AV6Icon = GetPar( "Icon");
                  AssignAttri(sPrefix, false, "AV6Icon", AV6Icon);
                  AV7Link = GetPar( "Link");
                  AssignAttri(sPrefix, false, "AV7Link", AV7Link);
                  AV8DmSistema = GetPar( "DmSistema");
                  AssignAttri(sPrefix, false, "AV8DmSistema", AV8DmSistema);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV5Nome,(string)AV6Icon,(string)AV7Link,(string)AV8DmSistema});
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
                  gxfirstwebparm = GetFirstPar( "Nome");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "Nome");
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
            PA9Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS9Y2( ) ;
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
            context.SendWebValue( "Wc Module") ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wcmodule"+UrlEncode(StringUtil.RTrim(AV5Nome)) + "," + UrlEncode(StringUtil.RTrim(AV6Icon)) + "," + UrlEncode(StringUtil.RTrim(AV7Link)) + "," + UrlEncode(StringUtil.RTrim(AV8DmSistema));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcmodule") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXDMSISTEMA", AV11AuxDmSistema);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vAUXDMSISTEMA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV11AuxDmSistema, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV5Nome", wcpOAV5Nome);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6Icon", wcpOAV6Icon);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7Link", wcpOAV7Link);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8DmSistema", wcpOAV8DmSistema);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDMSISTEMA", AV8DmSistema);
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXDMSISTEMA", AV11AuxDmSistema);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vAUXDMSISTEMA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV11AuxDmSistema, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vQTDACESSO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14QtdAcesso), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLINK", AV7Link);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDVELOP_MENU", AV12DVelop_Menu);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDVELOP_MENU", AV12DVelop_Menu);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOME", AV5Nome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vICON", AV6Icon);
      }

      protected void RenderHtmlCloseForm9Y2( )
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
         return "WcModule" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wc Module" ;
      }

      protected void WB9Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcmodule");
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
            wb_table1_6_9Y2( true) ;
         }
         else
         {
            wb_table1_6_9Y2( false) ;
         }
         return  ;
      }

      protected void wb_table1_6_9Y2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START9Y2( )
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
            Form.Meta.addItem("description", "Wc Module", 0) ;
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
               STRUP9Y0( ) ;
            }
         }
      }

      protected void WS9Y2( )
      {
         START9Y2( ) ;
         EVT9Y2( ) ;
      }

      protected void EVT9Y2( )
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
                                 STRUP9Y0( ) ;
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
                                 STRUP9Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E119Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TABLEMAIN.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Tablemain.Click */
                                    E129Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E139Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9Y0( ) ;
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
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP9Y0( ) ;
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

      protected void WE9Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm9Y2( ) ;
            }
         }
      }

      protected void PA9Y2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcmodule")), "wcmodule") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcmodule")))) ;
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
                     gxfirstwebparm = GetFirstPar( "Nome");
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
         RF9Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E139Y2 ();
            WB9Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes9Y2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXDMSISTEMA", AV11AuxDmSistema);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vAUXDMSISTEMA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV11AuxDmSistema, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E119Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV5Nome = cgiGet( sPrefix+"wcpOAV5Nome");
            wcpOAV6Icon = cgiGet( sPrefix+"wcpOAV6Icon");
            wcpOAV7Link = cgiGet( sPrefix+"wcpOAV7Link");
            wcpOAV8DmSistema = cgiGet( sPrefix+"wcpOAV8DmSistema");
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
         E119Y2 ();
         if (returnInSub) return;
      }

      protected void E119Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV10String = AV9WEBSESSION.Get("DmSistema");
         AV11AuxDmSistema = AV10String;
         AssignAttri(sPrefix, false, "AV11AuxDmSistema", AV11AuxDmSistema);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vAUXDMSISTEMA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV11AuxDmSistema, "")), context));
         if ( StringUtil.StrCmp(AV11AuxDmSistema, AV8DmSistema) == 0 )
         {
            lblLabel_Caption = StringUtil.Format( "<div style=\"display: inline-flex;align-items: center;background-color: #03846d;color: #ffffff;padding: 6px 12px;border-radius: 4px;font-family: Arial, sans-serif;font-size: 18px;\"><i class=\"%2\"style=\"font-size:20px; margin-right:8px;\"aria-hidden=\"true\"></i><span>%1</span></div>", AV5Nome, AV6Icon, "", "", "", "", "", "", "");
            AssignProp(sPrefix, false, lblLabel_Internalname, "Caption", lblLabel_Caption, true);
         }
         else
         {
            lblLabel_Caption = StringUtil.Format( "<div style=\"display: inline-flex;align-items: center;background-color: #08A086;color: #ffffff;padding: 6px 12px;border-radius: 4px;font-family: Arial, sans-serif;font-size: 14px;cursor: pointer;transition: background-color 0.2s;\"onmouseover=\"this.style.backgroundColor=%2;\"onmouseout=\"this.style.backgroundColor=%1;\"><i class=\"%4\"style=\"font-size:16px; margin-right:8px;\"aria-hidden=\"true\"></i><span>%3</span></div>", "'#08A086'", "'#03846d'", AV5Nome, AV6Icon, "", "", "", "", "");
            AssignProp(sPrefix, false, lblLabel_Internalname, "Caption", lblLabel_Caption, true);
         }
      }

      protected void E129Y2( )
      {
         /* Tablemain_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV8DmSistema, AV11AuxDmSistema) != 0 )
         {
            AV9WEBSESSION.Set("DmSistema", AV8DmSistema);
            /* Execute user subroutine: 'VERIFICASETEMACESSO' */
            S112 ();
            if (returnInSub) return;
            if ( AV14QtdAcesso > 0 )
            {
               CallWebObject(formatLink(AV7Link) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               GXt_char1 = "Você não possui permissão para acessar este módulo";
               new message(context ).gxep_erro( ref  GXt_char1) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12DVelop_Menu", AV12DVelop_Menu);
      }

      protected void S112( )
      {
         /* 'VERIFICASETEMACESSO' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV8DmSistema, "Financeiro") == 0 )
         {
            GXt_objcol_SdtDVelop_Menu_Item2 = AV12DVelop_Menu;
            new GeneXus.Programs.wwpbaseobjects.menuoptionsdata(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
            AV12DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
            /* Execute user subroutine: 'VERMENU' */
            S122 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV8DmSistema, "Contratos") == 0 )
         {
            GXt_objcol_SdtDVelop_Menu_Item2 = AV12DVelop_Menu;
            new GeneXus.Programs.wwpbaseobjects.menuoptionsdatacontratos(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
            AV12DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
            /* Execute user subroutine: 'VERMENU' */
            S122 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV8DmSistema, "Vendas") == 0 )
         {
            GXt_objcol_SdtDVelop_Menu_Item2 = AV12DVelop_Menu;
            new GeneXus.Programs.wwpbaseobjects.menuoptionsdatavendas(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
            AV12DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
            /* Execute user subroutine: 'VERMENU' */
            S122 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(AV8DmSistema, "Seguranca") == 0 )
         {
            GXt_objcol_SdtDVelop_Menu_Item2 = AV12DVelop_Menu;
            new GeneXus.Programs.wwpbaseobjects.menuoptionsdataseguranca(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
            AV12DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
            /* Execute user subroutine: 'VERMENU' */
            S122 ();
            if (returnInSub) return;
         }
      }

      protected void S122( )
      {
         /* 'VERMENU' Routine */
         returnInSub = false;
         AV13InDVelop_Menu.FromJSonString(AV12DVelop_Menu.ToJSonString(false), null);
         AV12DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         new pfuncmenu(context ).execute(  AV13InDVelop_Menu, ref  AV12DVelop_Menu) ;
         AV14QtdAcesso = (short)(AV12DVelop_Menu.Count);
         AssignAttri(sPrefix, false, "AV14QtdAcesso", StringUtil.LTrimStr( (decimal)(AV14QtdAcesso), 4, 0));
      }

      protected void nextLoad( )
      {
      }

      protected void E139Y2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_6_9Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_9_9Y2( true) ;
         }
         else
         {
            wb_table2_9_9Y2( false) ;
         }
         return  ;
      }

      protected void wb_table2_9_9Y2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_6_9Y2e( true) ;
         }
         else
         {
            wb_table1_6_9Y2e( false) ;
         }
      }

      protected void wb_table2_9_9Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablecontent_Internalname, tblTablecontent_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabel_Internalname, lblLabel_Caption, "", "", lblLabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcModule.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_9_9Y2e( true) ;
         }
         else
         {
            wb_table2_9_9Y2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5Nome = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV5Nome", AV5Nome);
         AV6Icon = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV6Icon", AV6Icon);
         AV7Link = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV7Link", AV7Link);
         AV8DmSistema = (string)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV8DmSistema", AV8DmSistema);
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
         PA9Y2( ) ;
         WS9Y2( ) ;
         WE9Y2( ) ;
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
         sCtrlAV5Nome = (string)((string)getParm(obj,0));
         sCtrlAV6Icon = (string)((string)getParm(obj,1));
         sCtrlAV7Link = (string)((string)getParm(obj,2));
         sCtrlAV8DmSistema = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA9Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcmodule", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA9Y2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV5Nome = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV5Nome", AV5Nome);
            AV6Icon = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV6Icon", AV6Icon);
            AV7Link = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7Link", AV7Link);
            AV8DmSistema = (string)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV8DmSistema", AV8DmSistema);
         }
         wcpOAV5Nome = cgiGet( sPrefix+"wcpOAV5Nome");
         wcpOAV6Icon = cgiGet( sPrefix+"wcpOAV6Icon");
         wcpOAV7Link = cgiGet( sPrefix+"wcpOAV7Link");
         wcpOAV8DmSistema = cgiGet( sPrefix+"wcpOAV8DmSistema");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV5Nome, wcpOAV5Nome) != 0 ) || ( StringUtil.StrCmp(AV6Icon, wcpOAV6Icon) != 0 ) || ( StringUtil.StrCmp(AV7Link, wcpOAV7Link) != 0 ) || ( StringUtil.StrCmp(AV8DmSistema, wcpOAV8DmSistema) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV5Nome = AV5Nome;
         wcpOAV6Icon = AV6Icon;
         wcpOAV7Link = AV7Link;
         wcpOAV8DmSistema = AV8DmSistema;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV5Nome = cgiGet( sPrefix+"AV5Nome_CTRL");
         if ( StringUtil.Len( sCtrlAV5Nome) > 0 )
         {
            AV5Nome = cgiGet( sCtrlAV5Nome);
            AssignAttri(sPrefix, false, "AV5Nome", AV5Nome);
         }
         else
         {
            AV5Nome = cgiGet( sPrefix+"AV5Nome_PARM");
         }
         sCtrlAV6Icon = cgiGet( sPrefix+"AV6Icon_CTRL");
         if ( StringUtil.Len( sCtrlAV6Icon) > 0 )
         {
            AV6Icon = cgiGet( sCtrlAV6Icon);
            AssignAttri(sPrefix, false, "AV6Icon", AV6Icon);
         }
         else
         {
            AV6Icon = cgiGet( sPrefix+"AV6Icon_PARM");
         }
         sCtrlAV7Link = cgiGet( sPrefix+"AV7Link_CTRL");
         if ( StringUtil.Len( sCtrlAV7Link) > 0 )
         {
            AV7Link = cgiGet( sCtrlAV7Link);
            AssignAttri(sPrefix, false, "AV7Link", AV7Link);
         }
         else
         {
            AV7Link = cgiGet( sPrefix+"AV7Link_PARM");
         }
         sCtrlAV8DmSistema = cgiGet( sPrefix+"AV8DmSistema_CTRL");
         if ( StringUtil.Len( sCtrlAV8DmSistema) > 0 )
         {
            AV8DmSistema = cgiGet( sCtrlAV8DmSistema);
            AssignAttri(sPrefix, false, "AV8DmSistema", AV8DmSistema);
         }
         else
         {
            AV8DmSistema = cgiGet( sPrefix+"AV8DmSistema_PARM");
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
         PA9Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS9Y2( ) ;
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
         WS9Y2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV5Nome_PARM", AV5Nome);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV5Nome)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV5Nome_CTRL", StringUtil.RTrim( sCtrlAV5Nome));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6Icon_PARM", AV6Icon);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6Icon)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6Icon_CTRL", StringUtil.RTrim( sCtrlAV6Icon));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7Link_PARM", AV7Link);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7Link)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7Link_CTRL", StringUtil.RTrim( sCtrlAV7Link));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8DmSistema_PARM", AV8DmSistema);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8DmSistema)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8DmSistema_CTRL", StringUtil.RTrim( sCtrlAV8DmSistema));
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
         WE9Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101963187", true, true);
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
         context.AddJavascriptSource("wcmodule.js", "?20256101963187", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLabel_Internalname = sPrefix+"LABEL";
         tblTablecontent_Internalname = sPrefix+"TABLECONTENT";
         tblTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         lblLabel_Caption = "<div style=\"display: inline-flex;align-items: center;background-color: #08A086;color: #ffffff;padding: 6px 12px;border-radius: 4px;font-family: Arial, sans-serif;font-size: 14px;cursor: pointer;transition: background-color 0.2s;\"onmouseover=\"this.style.backgroundColor='#03846d';\"onmouseout=\"this.style.backgroundColor='#08A086';\"><i class=\"fas fa-money-bill-alt\"style=\"font-size:16px; margin-right:8px;\"aria-hidden=\"true\"></i><span>Vendas</span></div>";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV11AuxDmSistema","fld":"vAUXDMSISTEMA","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("TABLEMAIN.CLICK","""{"handler":"E129Y2","iparms":[{"av":"AV8DmSistema","fld":"vDMSISTEMA","type":"svchar"},{"av":"AV11AuxDmSistema","fld":"vAUXDMSISTEMA","hsh":true,"type":"svchar"},{"av":"AV14QtdAcesso","fld":"vQTDACESSO","pic":"ZZZ9","type":"int"},{"av":"AV7Link","fld":"vLINK","type":"svchar"},{"av":"AV12DVelop_Menu","fld":"vDVELOP_MENU","type":""}]""");
         setEventMetadata("TABLEMAIN.CLICK",""","oparms":[{"av":"AV12DVelop_Menu","fld":"vDVELOP_MENU","type":""},{"av":"AV14QtdAcesso","fld":"vQTDACESSO","pic":"ZZZ9","type":"int"}]}""");
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
         wcpOAV5Nome = "";
         wcpOAV6Icon = "";
         wcpOAV7Link = "";
         wcpOAV8DmSistema = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11AuxDmSistema = "";
         AV12DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV10String = "";
         AV9WEBSESSION = context.GetSession();
         GXt_char1 = "";
         GXt_objcol_SdtDVelop_Menu_Item2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         AV13InDVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         sStyleString = "";
         lblLabel_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV5Nome = "";
         sCtrlAV6Icon = "";
         sCtrlAV7Link = "";
         sCtrlAV8DmSistema = "";
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14QtdAcesso ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int idxLst ;
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
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string lblLabel_Caption ;
      private string lblLabel_Internalname ;
      private string GXt_char1 ;
      private string sStyleString ;
      private string tblTablemain_Internalname ;
      private string tblTablecontent_Internalname ;
      private string lblLabel_Jsonclick ;
      private string sCtrlAV5Nome ;
      private string sCtrlAV6Icon ;
      private string sCtrlAV7Link ;
      private string sCtrlAV8DmSistema ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV5Nome ;
      private string AV6Icon ;
      private string AV7Link ;
      private string AV8DmSistema ;
      private string wcpOAV5Nome ;
      private string wcpOAV6Icon ;
      private string wcpOAV7Link ;
      private string wcpOAV8DmSistema ;
      private string AV11AuxDmSistema ;
      private string AV10String ;
      private IGxSession AV9WEBSESSION ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV12DVelop_Menu ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV13InDVelop_Menu ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
