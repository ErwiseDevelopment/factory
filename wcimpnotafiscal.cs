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
   public class wcimpnotafiscal : GXDataArea
   {
      public wcimpnotafiscal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wcimpnotafiscal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_PreviousStep ,
                           string aP1_CurrentStep ,
                           bool aP2_GoingBack )
      {
         this.AV8PreviousStep = aP0_PreviousStep;
         this.AV9CurrentStep = aP1_CurrentStep;
         this.AV7GoingBack = aP2_GoingBack;
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
            gxfirstwebparm = GetFirstPar( "PreviousStep");
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
               gxfirstwebparm = GetFirstPar( "PreviousStep");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "PreviousStep");
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.masterpagepfpj", "GeneXus.Programs.wwpbaseobjects.masterpagepfpj", new Object[] {context});
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
         PA8J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8J2( ) ;
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormWithFixedActions\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcimpnotafiscal"+UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.RTrim(AV9CurrentStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("wcimpnotafiscal") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWIZARDSTEPS", AV11WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWIZARDSTEPS", AV11WizardSteps);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWIZARDSTEPS", GetSecureSignedToken( "", AV11WizardSteps, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEPAUX", AV10CurrentStepAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10CurrentStepAux, "")), context));
         GxWebStd.gx_hidden_field( context, "vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vPREVIOUSSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8PreviousStep, "")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEP", AV9CurrentStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9CurrentStep, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, "gxhash_vGOINGBACK", GetSecureSignedToken( "", AV7GoingBack, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWIZARDSTEPS", AV11WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWIZARDSTEPS", AV11WizardSteps);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWIZARDSTEPS", GetSecureSignedToken( "", AV11WizardSteps, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEPAUX", AV10CurrentStepAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10CurrentStepAux, "")), context));
         GxWebStd.gx_hidden_field( context, "vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vPREVIOUSSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8PreviousStep, "")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEP", AV9CurrentStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9CurrentStep, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, "gxhash_vGOINGBACK", GetSecureSignedToken( "", AV7GoingBack, context));
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
         if ( ! ( WebComp_Steptitles == null ) )
         {
            WebComp_Steptitles.componentjscripts();
         }
         if ( ! ( WebComp_Wizardstepwc == null ) )
         {
            WebComp_Wizardstepwc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormWithFixedActions" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE8J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8J2( ) ;
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
         GXEncryptionTmp = "wcimpnotafiscal"+UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.RTrim(AV9CurrentStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
         return formatLink("wcimpnotafiscal") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WcImpNotaFiscal" ;
      }

      public override string GetPgmdesc( )
      {
         return "Importar nota fiscal" ;
      }

      protected void WB8J0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableWizardMainWithShadow TableMainFixedActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WizardStepsCell", "Center", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0009"+"", StringUtil.RTrim( WebComp_Steptitles_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0009"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSteptitles), StringUtil.Lower( WebComp_Steptitles_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0009"+"");
                  }
                  WebComp_Steptitles.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSteptitles), StringUtil.Lower( WebComp_Steptitles_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg CellPaddingBottom", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWizardstepdescription_Internalname, lblWizardstepdescription_Caption, "", "", lblWizardstepdescription_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WizardStepDescription", 0, "", 1, 1, 0, 0, "HLP_WcImpNotaFiscal.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WizardStepsPositionCell", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0015"+"", StringUtil.RTrim( WebComp_Wizardstepwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0015"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWizardstepwc), StringUtil.Lower( WebComp_Wizardstepwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0015"+"");
                  }
                  WebComp_Wizardstepwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWizardstepwc), StringUtil.Lower( WebComp_Wizardstepwc_Component)) != 0 )
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
            GxWebStd.gx_label_ctrl( context, lblCss_Internalname, lblCss_Caption, "", "", lblCss_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscal.htm");
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

      protected void START8J2( )
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
         Form.Meta.addItem("description", "Importar nota fiscal", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8J0( ) ;
      }

      protected void WS8J2( )
      {
         START8J2( ) ;
         EVT8J2( ) ;
      }

      protected void EVT8J2( )
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
                              E118J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E128J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E138J2 ();
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
                        if ( nCmpId == 9 )
                        {
                           OldSteptitles = cgiGet( "W0009");
                           if ( ( StringUtil.Len( OldSteptitles) == 0 ) || ( StringUtil.StrCmp(OldSteptitles, WebComp_Steptitles_Component) != 0 ) )
                           {
                              WebComp_Steptitles = getWebComponent(GetType(), "GeneXus.Programs", OldSteptitles, new Object[] {context} );
                              WebComp_Steptitles.ComponentInit();
                              WebComp_Steptitles.Name = "OldSteptitles";
                              WebComp_Steptitles_Component = OldSteptitles;
                           }
                           if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
                           {
                              WebComp_Steptitles.componentprocess("W0009", "", sEvt);
                           }
                           WebComp_Steptitles_Component = OldSteptitles;
                        }
                        else if ( nCmpId == 15 )
                        {
                           OldWizardstepwc = cgiGet( "W0015");
                           if ( ( StringUtil.Len( OldWizardstepwc) == 0 ) || ( StringUtil.StrCmp(OldWizardstepwc, WebComp_Wizardstepwc_Component) != 0 ) )
                           {
                              WebComp_Wizardstepwc = getWebComponent(GetType(), "GeneXus.Programs", OldWizardstepwc, new Object[] {context} );
                              WebComp_Wizardstepwc.ComponentInit();
                              WebComp_Wizardstepwc.Name = "OldWizardstepwc";
                              WebComp_Wizardstepwc_Component = OldWizardstepwc;
                           }
                           if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
                           {
                              WebComp_Wizardstepwc.componentprocess("W0015", "", sEvt);
                           }
                           WebComp_Wizardstepwc_Component = OldWizardstepwc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE8J2( )
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

      protected void PA8J2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcimpnotafiscal")), "wcimpnotafiscal") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcimpnotafiscal")))) ;
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
                  gxfirstwebparm = GetFirstPar( "PreviousStep");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV8PreviousStep = gxfirstwebparm;
                     AssignAttri("", false, "AV8PreviousStep", AV8PreviousStep);
                     GxWebStd.gx_hidden_field( context, "gxhash_vPREVIOUSSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8PreviousStep, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV9CurrentStep = GetPar( "CurrentStep");
                        AssignAttri("", false, "AV9CurrentStep", AV9CurrentStep);
                        GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9CurrentStep, "")), context));
                        AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                        AssignAttri("", false, "AV7GoingBack", AV7GoingBack);
                        GxWebStd.gx_hidden_field( context, "gxhash_vGOINGBACK", GetSecureSignedToken( "", AV7GoingBack, context));
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
         RF8J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV18Pgmname = "WcImpNotaFiscal";
      }

      protected void RF8J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E128J2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
               {
                  WebComp_Steptitles.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
               {
                  WebComp_Wizardstepwc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E138J2 ();
            WB8J0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes8J2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWIZARDSTEPS", AV11WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWIZARDSTEPS", AV11WizardSteps);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWIZARDSTEPS", GetSecureSignedToken( "", AV11WizardSteps, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEPAUX", AV10CurrentStepAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10CurrentStepAux, "")), context));
      }

      protected void before_start_formulas( )
      {
         AV18Pgmname = "WcImpNotaFiscal";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E118J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
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
         E118J2 ();
         if (returnInSub) return;
      }

      protected void E118J2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV11WizardSteps = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "Factory21");
         AV12WizardStep = new GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem(context);
         AV12WizardStep.gxTpr_Code = "ImportarXML";
         AV12WizardStep.gxTpr_Title = "Importar nota(s)";
         AV12WizardStep.gxTpr_Description = "Importar nota(s)";
         AV11WizardSteps.Add(AV12WizardStep, 0);
         AV12WizardStep = new GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem(context);
         AV12WizardStep.gxTpr_Code = "ProdutosNota";
         AV12WizardStep.gxTpr_Title = "Itens";
         AV12WizardStep.gxTpr_Description = "Itens";
         AV11WizardSteps.Add(AV12WizardStep, 0);
         AV12WizardStep = new GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem(context);
         AV12WizardStep.gxTpr_Code = "Revisao";
         AV12WizardStep.gxTpr_Title = "Revisão";
         AV12WizardStep.gxTpr_Description = "Revisão";
         AV11WizardSteps.Add(AV12WizardStep, 0);
         AV12WizardStep = new GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem(context);
         AV12WizardStep.gxTpr_Code = "Confirmacao";
         AV12WizardStep.gxTpr_Title = "Confirmação";
         AV12WizardStep.gxTpr_Description = "Confirmação";
         AV11WizardSteps.Add(AV12WizardStep, 0);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9CurrentStep)) )
         {
            AV10CurrentStepAux = "ImportarXML";
            AssignAttri("", false, "AV10CurrentStepAux", AV10CurrentStepAux);
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10CurrentStepAux, "")), context));
            AV5WebSession.Remove(AV18Pgmname+"_Data");
         }
         else
         {
            AV10CurrentStepAux = AV9CurrentStep;
            AssignAttri("", false, "AV10CurrentStepAux", AV10CurrentStepAux);
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10CurrentStepAux, "")), context));
         }
         /* Execute user subroutine: 'LOADWIZARDSTEPWC' */
         S112 ();
         if (returnInSub) return;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Steptitles = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Steptitles_Component), StringUtil.Lower( "WWPBaseObjects.WizardStepsBulletWC")) != 0 )
         {
            WebComp_Steptitles = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wizardstepsbulletwc", new Object[] {context} );
            WebComp_Steptitles.ComponentInit();
            WebComp_Steptitles.Name = "WWPBaseObjects.WizardStepsBulletWC";
            WebComp_Steptitles_Component = "WWPBaseObjects.WizardStepsBulletWC";
         }
         if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
         {
            WebComp_Steptitles.setjustcreated();
            WebComp_Steptitles.componentprepare(new Object[] {(string)"W0009",(string)"",(GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>)AV11WizardSteps,(string)AV10CurrentStepAux});
            WebComp_Steptitles.componentbind(new Object[] {(string)"",(string)""});
         }
         AV15HTML += "<style>";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += ".lista { display: flex; flex-direction: column; width: 100% }";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += ".cabecalho, .linha { font-family: ui-sans-serif, system-ui, -apple-system, BlinkMacSystemFont, \"Segoe UI\", Roboto, \"Helvetica Neue\", Arial, \"Noto Sans\", sans-serif,\"Apple Color Emoji\", \"Segoe UI Emoji\", \"Segoe UI Symbol\", \"Noto Color Emoji\"; border-bottom: 1px solid #ccc; padding: 8px;align-items: center; width: 100% }";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += ".col { padding: 8px 40px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap; flex: 1; min-width: 80px }";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += ".checkbox { flex: 0 0 40px }";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += ".numero { flex: 0 0 120px }";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += ".codigo { flex: 0 0 80px }";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += ".descricao { flex: 2; min-width: 150px }";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += ".quantidade, .preco, .total { text-align: right }";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += "@media (max-width: 1280px) { .descricao { min-width: 120px } .quantidade, .preco, .total { min-width: 80px } }";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += "@media (max-width: 768px) { .linha { flex-direction: column; align-items: flex-start; border-bottom: 1px solid #ddd; padding: 10px; gap: 4px }";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += ".col { width: 100%; flex: none; text-align: left !important } .checkbox { width: auto } }";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += "	.cabecalho {";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += "	background-color: #08A086;";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += "	color: white;";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += "	font-weight: bold;";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += "	padding: 8px 40px; align-items: center; width: 100%; border-top-left-radius: 8px; border-top-right-radius: 8px;";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += "	}";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += "	.linha:hover {";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += "	background-color: #eef6ff;";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += "	}";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         AV15HTML += "</style>";
         AssignAttri("", false, "AV15HTML", AV15HTML);
         lblCss_Caption = AV15HTML;
         AssignProp("", false, lblCss_Internalname, "Caption", lblCss_Caption, true);
      }

      protected void S112( )
      {
         /* 'LOADWIZARDSTEPWC' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV10CurrentStepAux, "ImportarXML") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wizardstepwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wizardstepwc_Component), StringUtil.Lower( "WcImpNotaFiscalImportarXML")) != 0 )
            {
               WebComp_Wizardstepwc = getWebComponent(GetType(), "GeneXus.Programs", "wcimpnotafiscalimportarxml", new Object[] {context} );
               WebComp_Wizardstepwc.ComponentInit();
               WebComp_Wizardstepwc.Name = "WcImpNotaFiscalImportarXML";
               WebComp_Wizardstepwc_Component = "WcImpNotaFiscalImportarXML";
            }
            if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
            {
               WebComp_Wizardstepwc.setjustcreated();
               WebComp_Wizardstepwc.componentprepare(new Object[] {(string)"W0015",(string)"",(string)AV18Pgmname+"_Data",(string)AV8PreviousStep,(bool)AV7GoingBack});
               WebComp_Wizardstepwc.componentbind(new Object[] {(string)""+""+"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wizardstepwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0015"+"");
               WebComp_Wizardstepwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(AV10CurrentStepAux, "ProdutosNota") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wizardstepwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wizardstepwc_Component), StringUtil.Lower( "WcImpNotaFiscalProdutosNota")) != 0 )
            {
               WebComp_Wizardstepwc = getWebComponent(GetType(), "GeneXus.Programs", "wcimpnotafiscalprodutosnota", new Object[] {context} );
               WebComp_Wizardstepwc.ComponentInit();
               WebComp_Wizardstepwc.Name = "WcImpNotaFiscalProdutosNota";
               WebComp_Wizardstepwc_Component = "WcImpNotaFiscalProdutosNota";
            }
            if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
            {
               WebComp_Wizardstepwc.setjustcreated();
               WebComp_Wizardstepwc.componentprepare(new Object[] {(string)"W0015",(string)"",(string)AV18Pgmname+"_Data",(string)AV8PreviousStep,(bool)AV7GoingBack});
               WebComp_Wizardstepwc.componentbind(new Object[] {(string)""+""+"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wizardstepwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0015"+"");
               WebComp_Wizardstepwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(AV10CurrentStepAux, "Revisao") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wizardstepwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wizardstepwc_Component), StringUtil.Lower( "WcImpNotaFiscalRevisao")) != 0 )
            {
               WebComp_Wizardstepwc = getWebComponent(GetType(), "GeneXus.Programs", "wcimpnotafiscalrevisao", new Object[] {context} );
               WebComp_Wizardstepwc.ComponentInit();
               WebComp_Wizardstepwc.Name = "WcImpNotaFiscalRevisao";
               WebComp_Wizardstepwc_Component = "WcImpNotaFiscalRevisao";
            }
            if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
            {
               WebComp_Wizardstepwc.setjustcreated();
               WebComp_Wizardstepwc.componentprepare(new Object[] {(string)"W0015",(string)"",(string)AV18Pgmname+"_Data",(string)AV8PreviousStep,(bool)AV7GoingBack});
               WebComp_Wizardstepwc.componentbind(new Object[] {(string)""+""+"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wizardstepwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0015"+"");
               WebComp_Wizardstepwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(AV10CurrentStepAux, "Confirmacao") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wizardstepwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wizardstepwc_Component), StringUtil.Lower( "WcImpNotaFiscalConfirmacao")) != 0 )
            {
               WebComp_Wizardstepwc = getWebComponent(GetType(), "GeneXus.Programs", "wcimpnotafiscalconfirmacao", new Object[] {context} );
               WebComp_Wizardstepwc.ComponentInit();
               WebComp_Wizardstepwc.Name = "WcImpNotaFiscalConfirmacao";
               WebComp_Wizardstepwc_Component = "WcImpNotaFiscalConfirmacao";
            }
            if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
            {
               WebComp_Wizardstepwc.setjustcreated();
               WebComp_Wizardstepwc.componentprepare(new Object[] {(string)"W0015",(string)"",(string)AV18Pgmname+"_Data",(string)AV8PreviousStep,(bool)AV7GoingBack});
               WebComp_Wizardstepwc.componentbind(new Object[] {(string)""+""+"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wizardstepwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0015"+"");
               WebComp_Wizardstepwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      protected void E128J2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         lblWizardstepdescription_Caption = "";
         AssignProp("", false, lblWizardstepdescription_Internalname, "Caption", lblWizardstepdescription_Caption, true);
         AV13StepNumber = 1;
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV11WizardSteps.Count )
         {
            AV12WizardStep = ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV11WizardSteps.Item(AV19GXV1));
            if ( StringUtil.StrCmp(AV12WizardStep.gxTpr_Code, AV10CurrentStepAux) == 0 )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12WizardStep.gxTpr_Description)) )
               {
                  lblWizardstepdescription_Caption = StringUtil.Format( "Step %1/%2 :: %3", StringUtil.Trim( StringUtil.Str( (decimal)(AV13StepNumber), 2, 0)), StringUtil.Trim( StringUtil.Str( (decimal)(AV11WizardSteps.Count), 9, 0)), AV12WizardStep.gxTpr_Description, "", "", "", "", "", "");
                  AssignProp("", false, lblWizardstepdescription_Internalname, "Caption", lblWizardstepdescription_Caption, true);
               }
            }
            else
            {
               AV13StepNumber = (short)(AV13StepNumber+1);
            }
            AV19GXV1 = (int)(AV19GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E138J2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8PreviousStep = (string)getParm(obj,0);
         AssignAttri("", false, "AV8PreviousStep", AV8PreviousStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vPREVIOUSSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8PreviousStep, "")), context));
         AV9CurrentStep = (string)getParm(obj,1);
         AssignAttri("", false, "AV9CurrentStep", AV9CurrentStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9CurrentStep, "")), context));
         AV7GoingBack = (bool)getParm(obj,2);
         AssignAttri("", false, "AV7GoingBack", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, "gxhash_vGOINGBACK", GetSecureSignedToken( "", AV7GoingBack, context));
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
         PA8J2( ) ;
         WS8J2( ) ;
         WE8J2( ) ;
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
         if ( ! ( WebComp_Steptitles == null ) )
         {
            if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
            {
               WebComp_Steptitles.componentthemes();
            }
         }
         if ( ! ( WebComp_Wizardstepwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
            {
               WebComp_Wizardstepwc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019273315", true, true);
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
         context.AddJavascriptSource("wcimpnotafiscal.js", "?202561019273316", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblWizardstepdescription_Internalname = "WIZARDSTEPDESCRIPTION";
         lblCss_Internalname = "CSS";
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
         lblCss_Caption = "<span></span>";
         lblWizardstepdescription_Caption = "Descrição do passo";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Importar nota fiscal";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV11WizardSteps","fld":"vWIZARDSTEPS","hsh":true,"type":""},{"av":"AV10CurrentStepAux","fld":"vCURRENTSTEPAUX","hsh":true,"type":"svchar"},{"av":"AV8PreviousStep","fld":"vPREVIOUSSTEP","hsh":true,"type":"svchar"},{"av":"AV9CurrentStep","fld":"vCURRENTSTEP","hsh":true,"type":"svchar"},{"av":"AV7GoingBack","fld":"vGOINGBACK","hsh":true,"type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"lblWizardstepdescription_Caption","ctrl":"WIZARDSTEPDESCRIPTION","prop":"Caption"}]}""");
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
         wcpOAV8PreviousStep = "";
         wcpOAV9CurrentStep = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11WizardSteps = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "Factory21");
         AV10CurrentStepAux = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         WebComp_Steptitles_Component = "";
         OldSteptitles = "";
         lblWizardstepdescription_Jsonclick = "";
         WebComp_Wizardstepwc_Component = "";
         OldWizardstepwc = "";
         lblCss_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV18Pgmname = "";
         AV12WizardStep = new GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem(context);
         AV5WebSession = context.GetSession();
         AV15HTML = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Steptitles = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wizardstepwc = new GeneXus.Http.GXNullWebComponent();
         AV18Pgmname = "WcImpNotaFiscal";
         /* GeneXus formulas. */
         AV18Pgmname = "WcImpNotaFiscal";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV13StepNumber ;
      private short nGXWrapped ;
      private int AV19GXV1 ;
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
      private string divTablemain_Internalname ;
      private string WebComp_Steptitles_Component ;
      private string OldSteptitles ;
      private string lblWizardstepdescription_Internalname ;
      private string lblWizardstepdescription_Caption ;
      private string lblWizardstepdescription_Jsonclick ;
      private string WebComp_Wizardstepwc_Component ;
      private string OldWizardstepwc ;
      private string lblCss_Internalname ;
      private string lblCss_Caption ;
      private string lblCss_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string AV18Pgmname ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Steptitles ;
      private bool bDynCreated_Wizardstepwc ;
      private string AV15HTML ;
      private string AV8PreviousStep ;
      private string AV9CurrentStep ;
      private string wcpOAV8PreviousStep ;
      private string wcpOAV9CurrentStep ;
      private string AV10CurrentStepAux ;
      private GXWebComponent WebComp_Steptitles ;
      private GXWebComponent WebComp_Wizardstepwc ;
      private IGxSession AV5WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem> AV11WizardSteps ;
      private GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem AV12WizardStep ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
