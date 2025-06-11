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
   public class newpassword : GXDataArea
   {
      public newpassword( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public newpassword( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Key )
      {
         this.AV7Key = aP0_Key;
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
            gxfirstwebparm = GetFirstPar( "Key");
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
               gxfirstwebparm = GetFirstPar( "Key");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Key");
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
         PA3G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3G2( ) ;
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
         GXEncryptionTmp = "newpassword"+UrlEncode(StringUtil.RTrim(AV7Key));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("newpassword") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SecUserid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13SecUserid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECUSERTOKENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18SecUserTokenID), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERTOKENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18SecUserTokenID), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vKEY", AV7Key);
         GxWebStd.gx_hidden_field( context, "gxhash_vKEY", GetSecureSignedToken( "", AV7Key, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SecUserid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13SecUserid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECUSERTOKENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18SecUserTokenID), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERTOKENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18SecUserTokenID), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vKEY", AV7Key);
         GxWebStd.gx_hidden_field( context, "gxhash_vKEY", GetSecureSignedToken( "", AV7Key, context));
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
            WE3G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3G2( ) ;
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
         GXEncryptionTmp = "newpassword"+UrlEncode(StringUtil.RTrim(AV7Key));
         return formatLink("newpassword") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "NewPassword" ;
      }

      public override string GetPgmdesc( )
      {
         return "New Password" ;
      }

      protected void WB3G0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_6_3G2( true) ;
         }
         else
         {
            wb_table1_6_3G2( false) ;
         }
         return  ;
      }

      protected void wb_table1_6_3G2e( bool wbgen )
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

      protected void START3G2( )
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
         Form.Meta.addItem("description", "New Password", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3G0( ) ;
      }

      protected void WS3G2( )
      {
         START3G2( ) ;
         EVT3G2( ) ;
      }

      protected void EVT3G2( )
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
                              E113G2 ();
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
                                    E123G2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E133G2 ();
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

      protected void WE3G2( )
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

      protected void PA3G2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "newpassword")), "newpassword") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "newpassword")))) ;
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
                  gxfirstwebparm = GetFirstPar( "Key");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV7Key = gxfirstwebparm;
                     AssignAttri("", false, "AV7Key", AV7Key);
                     GxWebStd.gx_hidden_field( context, "gxhash_vKEY", GetSecureSignedToken( "", AV7Key, context));
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
               GX_FocusControl = edtavNewpassword_Internalname;
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
         RF3G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E133G2 ();
            WB3G0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3G2( )
      {
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SecUserid), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13SecUserid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECUSERTOKENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18SecUserTokenID), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERTOKENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18SecUserTokenID), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV11NewPassword = cgiGet( edtavNewpassword_Internalname);
            AssignAttri("", false, "AV11NewPassword", AV11NewPassword);
            AV12NewPasswordConfirm = cgiGet( edtavNewpasswordconfirm_Internalname);
            AssignAttri("", false, "AV12NewPasswordConfirm", AV12NewPasswordConfirm);
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
         E113G2 ();
         if (returnInSub) return;
      }

      protected void E113G2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( 1 == 2 )
         {
         }
         AV9ServerNow = DateTimeUtil.ServerNow( context, pr_default);
         AssignAttri("", false, "AV9ServerNow", context.localUtil.TToC( AV9ServerNow, 10, 8, 0, 3, "/", ":", " "));
         AV19GXLvl16 = 0;
         /* Using cursor H003G2 */
         pr_default.execute(0, new Object[] {AV9ServerNow, AV7Key});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A167SecUserTokenUsed = H003G2_A167SecUserTokenUsed[0];
            n167SecUserTokenUsed = H003G2_n167SecUserTokenUsed[0];
            A166SecUserTokenDateTime = H003G2_A166SecUserTokenDateTime[0];
            n166SecUserTokenDateTime = H003G2_n166SecUserTokenDateTime[0];
            A165SecUserTokenKey = H003G2_A165SecUserTokenKey[0];
            n165SecUserTokenKey = H003G2_n165SecUserTokenKey[0];
            A164SecUserTokenID = H003G2_A164SecUserTokenID[0];
            A133SecUserId = H003G2_A133SecUserId[0];
            n133SecUserId = H003G2_n133SecUserId[0];
            AV19GXLvl16 = 1;
            AV18SecUserTokenID = A164SecUserTokenID;
            AssignAttri("", false, "AV18SecUserTokenID", StringUtil.LTrimStr( (decimal)(AV18SecUserTokenID), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERTOKENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18SecUserTokenID), "ZZZ9"), context));
            AV13SecUserid = A133SecUserId;
            AssignAttri("", false, "AV13SecUserid", StringUtil.LTrimStr( (decimal)(AV13SecUserid), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13SecUserid), "ZZZ9"), context));
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV19GXLvl16 == 0 )
         {
            CallWebObject(formatLink("expiredtoken") );
            context.wjLocDisableFrm = 1;
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E123G2 ();
         if (returnInSub) return;
      }

      protected void E123G2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV14IsOk = true;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11NewPassword)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Digite sua senha",  "notice",  "",  "true",  ""));
            AV14IsOk = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12NewPasswordConfirm)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Confirme sua senha",  "notice",  "",  "true",  ""));
            AV14IsOk = false;
         }
         if ( ( StringUtil.StrCmp(AV11NewPassword, AV12NewPasswordConfirm) != 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11NewPassword)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12NewPasswordConfirm)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Senhas não conferem",  "notice",  "",  "true",  ""));
            AV14IsOk = false;
         }
         if ( AV14IsOk )
         {
            new prnewpassword(context ).execute(  AV13SecUserid,  AV11NewPassword, out  AV17SdErro) ;
            if ( AV17SdErro.gxTpr_Status == 200 )
            {
               AV10SecUserToken.Load(AV18SecUserTokenID);
               AV10SecUserToken.gxTpr_Secusertokenused = true;
               AV10SecUserToken.Save();
               context.CommitDataStores("newpassword",pr_default);
               CallWebObject(formatLink("passwordchanged") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Erro!",  StringUtil.Trim( StringUtil.Str( (decimal)(AV17SdErro.gxTpr_Internalcode), 6, 0))+" - "+StringUtil.Trim( AV17SdErro.gxTpr_Msg),  "error",  "true",  "",  ""));
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E133G2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_6_3G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "recover-new-password-container", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "recover-new-password-content", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignin_Internalname, "RECUPERAR SENHA", "", "", lblSignin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_NewPassword.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNewpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNewpassword_Internalname, "Nova senha", "col-sm-4 AttributeLoginLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNewpassword_Internalname, AV11NewPassword, StringUtil.RTrim( context.localUtil.Format( AV11NewPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNewpassword_Jsonclick, 0, "AttributeLogin", "", "", "", "", 1, edtavNewpassword_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_NewPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNewpasswordconfirm_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNewpasswordconfirm_Internalname, "Confirmar senha", "col-sm-4 AttributeLoginLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNewpasswordconfirm_Internalname, AV12NewPasswordConfirm, StringUtil.RTrim( context.localUtil.Format( AV12NewPasswordConfirm, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNewpasswordconfirm_Jsonclick, 0, "AttributeLogin", "", "", "", "", 1, edtavNewpasswordconfirm_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_NewPassword.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_NewPassword.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_6_3G2e( true) ;
         }
         else
         {
            wb_table1_6_3G2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7Key = (string)getParm(obj,0);
         AssignAttri("", false, "AV7Key", AV7Key);
         GxWebStd.gx_hidden_field( context, "gxhash_vKEY", GetSecureSignedToken( "", AV7Key, context));
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
         PA3G2( ) ;
         WS3G2( ) ;
         WE3G2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019235055", true, true);
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
         context.AddJavascriptSource("newpassword.js", "?202561019235055", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblSignin_Internalname = "SIGNIN";
         edtavNewpassword_Internalname = "vNEWPASSWORD";
         edtavNewpasswordconfirm_Internalname = "vNEWPASSWORDCONFIRM";
         bttBtnenter_Internalname = "BTNENTER";
         divTablecontent_Internalname = "TABLECONTENT";
         tblTablemain_Internalname = "TABLEMAIN";
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
         edtavNewpasswordconfirm_Jsonclick = "";
         edtavNewpasswordconfirm_Enabled = 1;
         edtavNewpassword_Jsonclick = "";
         edtavNewpassword_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "New Password";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV13SecUserid","fld":"vSECUSERID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV18SecUserTokenID","fld":"vSECUSERTOKENID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV7Key","fld":"vKEY","hsh":true,"type":"vchar"}]}""");
         setEventMetadata("ENTER","""{"handler":"E123G2","iparms":[{"av":"AV11NewPassword","fld":"vNEWPASSWORD","type":"svchar"},{"av":"AV12NewPasswordConfirm","fld":"vNEWPASSWORDCONFIRM","type":"svchar"},{"av":"AV13SecUserid","fld":"vSECUSERID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV18SecUserTokenID","fld":"vSECUSERTOKENID","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
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
         wcpOAV7Key = "";
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
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV11NewPassword = "";
         AV12NewPasswordConfirm = "";
         AV9ServerNow = (DateTime)(DateTime.MinValue);
         H003G2_A167SecUserTokenUsed = new bool[] {false} ;
         H003G2_n167SecUserTokenUsed = new bool[] {false} ;
         H003G2_A166SecUserTokenDateTime = new DateTime[] {DateTime.MinValue} ;
         H003G2_n166SecUserTokenDateTime = new bool[] {false} ;
         H003G2_A165SecUserTokenKey = new string[] {""} ;
         H003G2_n165SecUserTokenKey = new bool[] {false} ;
         H003G2_A164SecUserTokenID = new short[1] ;
         H003G2_A133SecUserId = new short[1] ;
         H003G2_n133SecUserId = new bool[] {false} ;
         A166SecUserTokenDateTime = (DateTime)(DateTime.MinValue);
         A165SecUserTokenKey = "";
         AV17SdErro = new SdtSdErro(context);
         AV10SecUserToken = new SdtSecUserToken(context);
         sStyleString = "";
         lblSignin_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnenter_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.newpassword__default(),
            new Object[][] {
                new Object[] {
               H003G2_A167SecUserTokenUsed, H003G2_n167SecUserTokenUsed, H003G2_A166SecUserTokenDateTime, H003G2_n166SecUserTokenDateTime, H003G2_A165SecUserTokenKey, H003G2_n165SecUserTokenKey, H003G2_A164SecUserTokenID, H003G2_A133SecUserId, H003G2_n133SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short AV13SecUserid ;
      private short AV18SecUserTokenID ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short AV19GXLvl16 ;
      private short A164SecUserTokenID ;
      private short A133SecUserId ;
      private short nGXWrapped ;
      private int edtavNewpassword_Enabled ;
      private int edtavNewpasswordconfirm_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string edtavNewpassword_Internalname ;
      private string edtavNewpasswordconfirm_Internalname ;
      private string sStyleString ;
      private string tblTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string lblSignin_Internalname ;
      private string lblSignin_Jsonclick ;
      private string TempTags ;
      private string edtavNewpassword_Jsonclick ;
      private string edtavNewpasswordconfirm_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private DateTime AV9ServerNow ;
      private DateTime A166SecUserTokenDateTime ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A167SecUserTokenUsed ;
      private bool n167SecUserTokenUsed ;
      private bool n166SecUserTokenDateTime ;
      private bool n165SecUserTokenKey ;
      private bool n133SecUserId ;
      private bool AV14IsOk ;
      private string AV7Key ;
      private string wcpOAV7Key ;
      private string A165SecUserTokenKey ;
      private string AV11NewPassword ;
      private string AV12NewPasswordConfirm ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] H003G2_A167SecUserTokenUsed ;
      private bool[] H003G2_n167SecUserTokenUsed ;
      private DateTime[] H003G2_A166SecUserTokenDateTime ;
      private bool[] H003G2_n166SecUserTokenDateTime ;
      private string[] H003G2_A165SecUserTokenKey ;
      private bool[] H003G2_n165SecUserTokenKey ;
      private short[] H003G2_A164SecUserTokenID ;
      private short[] H003G2_A133SecUserId ;
      private bool[] H003G2_n133SecUserId ;
      private SdtSdErro AV17SdErro ;
      private SdtSecUserToken AV10SecUserToken ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class newpassword__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003G2;
          prmH003G2 = new Object[] {
          new ParDef("AV9ServerNow",GXType.DateTime,10,8) ,
          new ParDef("AV7Key",GXType.LongVarChar,2097152,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003G2", "SELECT SecUserTokenUsed, SecUserTokenDateTime, SecUserTokenKey, SecUserTokenID, SecUserId FROM SecUserToken WHERE (SecUserTokenDateTime >= :AV9ServerNow) AND (Not SecUserTokenUsed) AND (SecUserTokenKey = ( :AV7Key)) ORDER BY SecUserTokenID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003G2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
