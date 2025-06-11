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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscriptionspanel : GXWebComponent
   {
      public wwp_subscriptionspanel( )
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

      public wwp_subscriptionspanel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPEntityName ,
                           short aP1_WWPNotificationAppliesTo ,
                           string aP2_WWPSubscriptionEntityRecordId ,
                           string aP3_RecordAttDescription )
      {
         this.AV6WWPEntityName = aP0_WWPEntityName;
         this.AV7WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         this.AV20WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV14RecordAttDescription = aP3_RecordAttDescription;
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
         chkavIncludenotification = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WWPEntityName");
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
                  AV6WWPEntityName = GetPar( "WWPEntityName");
                  AssignAttri(sPrefix, false, "AV6WWPEntityName", AV6WWPEntityName);
                  AV7WWPNotificationAppliesTo = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationAppliesTo"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV7WWPNotificationAppliesTo", StringUtil.Str( (decimal)(AV7WWPNotificationAppliesTo), 1, 0));
                  AV20WWPSubscriptionEntityRecordId = GetPar( "WWPSubscriptionEntityRecordId");
                  AssignAttri(sPrefix, false, "AV20WWPSubscriptionEntityRecordId", AV20WWPSubscriptionEntityRecordId);
                  AV14RecordAttDescription = GetPar( "RecordAttDescription");
                  AssignAttri(sPrefix, false, "AV14RecordAttDescription", AV14RecordAttDescription);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WWPEntityName,(short)AV7WWPNotificationAppliesTo,(string)AV20WWPSubscriptionEntityRecordId,(string)AV14RecordAttDescription});
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
                  gxfirstwebparm = GetFirstPar( "WWPEntityName");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPEntityName");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  gxnrGrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  gxgrGrid_refresh_invoke( ) ;
                  return  ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_9 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_9"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_9_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_9_idx = GetPar( "sGXsfl_9_idx");
         sPrefix = GetPar( "sPrefix");
         edtWWPNotificationDefinitionId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtWWPNotificationDefinitionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0), !bGXsfl_9_Refreshing);
         edtavWwpsubscriptionid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV5WWPEntityId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPEntityId"), "."), 18, MidpointRounding.ToEven));
         AV7WWPNotificationAppliesTo = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationAppliesTo"), "."), 18, MidpointRounding.ToEven));
         AV27Pgmname = GetPar( "Pgmname");
         edtWWPNotificationDefinitionId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtWWPNotificationDefinitionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0), !bGXsfl_9_Refreshing);
         edtavWwpsubscriptionid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
         A7WWPUserExtendedId = GetPar( "WWPUserExtendedId");
         n7WWPUserExtendedId = false;
         AV30Udparg1 = GetPar( "Udparg1");
         A27WWPSubscriptionSubscribed = StringUtil.StrToBool( GetPar( "WWPSubscriptionSubscribed"));
         A19WWPSubscriptionRoleId = GetPar( "WWPSubscriptionRoleId");
         n19WWPSubscriptionRoleId = false;
         ajax_req_read_hidden_sdt(GetNextPar( ), AV23WWPSubscriptionRoleIdCollection);
         AV8WWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationId"), "."), 18, MidpointRounding.ToEven));
         A26WWPSubscriptionEntityRecordId = GetPar( "WWPSubscriptionEntityRecordId");
         AV20WWPSubscriptionEntityRecordId = GetPar( "WWPSubscriptionEntityRecordId");
         A25WWPSubscriptionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPSubscriptionId"), "."), 18, MidpointRounding.ToEven));
         AV24WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV27Pgmname, A7WWPUserExtendedId, AV30Udparg1, A27WWPSubscriptionSubscribed, A19WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A26WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A25WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            PA0W2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV27Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
               WS0W2( ) ;
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
            context.SendWebValue( "Subscriptions of an Entity/Record") ;
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
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
            if ( nGXWrapped != 1 )
            {
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "wwpbaseobjects.subscriptions.wwp_subscriptionspanel"+UrlEncode(StringUtil.RTrim(AV6WWPEntityName)) + "," + UrlEncode(StringUtil.LTrimStr(AV7WWPNotificationAppliesTo,1,0)) + "," + UrlEncode(StringUtil.RTrim(AV20WWPSubscriptionEntityRecordId)) + "," + UrlEncode(StringUtil.RTrim(AV14RecordAttDescription));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionspanel") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG1", StringUtil.RTrim( AV30Udparg1));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV30Udparg1, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPSUBSCRIPTIONROLEIDCOLLECTION", GetSecureSignedToken( sPrefix, AV23WWPSubscriptionRoleIdCollection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8WWPNotificationId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24WWPNotificationDefinitionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONDEFINITIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV24WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WWPEntityName", wcpOAV6WWPEntityName);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7WWPNotificationAppliesTo", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7WWPNotificationAppliesTo), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20WWPSubscriptionEntityRecordId", wcpOAV20WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV14RecordAttDescription", wcpOAV14RecordAttDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPUSEREXTENDEDID", StringUtil.RTrim( A7WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG1", StringUtil.RTrim( AV30Udparg1));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV30Udparg1, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONSUBSCRIBED", A27WWPSubscriptionSubscribed);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONROLEID", StringUtil.RTrim( A19WWPSubscriptionRoleId));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPSUBSCRIPTIONROLEIDCOLLECTION", GetSecureSignedToken( sPrefix, AV23WWPSubscriptionRoleIdCollection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8WWPNotificationId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONENTITYRECORDID", A26WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONENTITYRECORDID", AV20WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPSUBSCRIPTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25WWPSubscriptionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24WWPNotificationDefinitionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONDEFINITIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV24WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRECORDATTDESCRIPTION", AV14RecordAttDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPENTITYNAME", AV6WWPEntityName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONAPPLIESTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPNotificationAppliesTo), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5WWPEntityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPSUBSCRIPTIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0W2( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel" ;
      }

      public override string GetPgmdesc( )
      {
         return "Subscriptions of an Entity/Record" ;
      }

      protected void WB0W0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainSubscriptions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SubscriptionsPanelCell", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl9( ) ;
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            nRC_GXsfl_9 = (int)(nGXsfl_9_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0W2( )
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
            Form.Meta.addItem("description", "Subscriptions of an Entity/Record", 0) ;
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
               STRUP0W0( ) ;
            }
         }
      }

      protected void WS0W2( )
      {
         START0W2( ) ;
         EVT0W2( ) ;
      }

      protected void EVT0W2( )
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
                                 STRUP0W0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "TABLESUBSCRIPTIONITEM.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Tablesubscriptionitem.Click */
                                    E110W2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0W0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavIncludenotification_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0W0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 27), "TABLESUBSCRIPTIONITEM.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0W0( ) ;
                              }
                              nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              AV12IncludeNotification = StringUtil.StrToBool( cgiGet( chkavIncludenotification_Internalname));
                              AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
                              A29WWPNotificationDefinitionDescription = cgiGet( edtWWPNotificationDefinitionDescription_Internalname);
                              A23WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPSUBSCRIPTIONID");
                                 GX_FocusControl = edtavWwpsubscriptionid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV22WWPSubscriptionId = 0;
                                 AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
                              }
                              else
                              {
                                 AV22WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E120W2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E130W2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E140W2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "TABLESUBSCRIPTIONITEM.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Tablesubscriptionitem.Click */
                                          E110W2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
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
                                       STRUP0W0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavIncludenotification_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0W2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0W2( ) ;
            }
         }
      }

      protected void PA0W2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.subscriptions.wwp_subscriptionspanel")), "wwpbaseobjects.subscriptions.wwp_subscriptionspanel") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.subscriptions.wwp_subscriptionspanel")))) ;
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
                     gxfirstwebparm = GetFirstPar( "WWPEntityName");
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

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_92( ) ;
         while ( nGXsfl_9_idx <= nRC_GXsfl_9 )
         {
            sendrow_92( ) ;
            nGXsfl_9_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       long AV5WWPEntityId ,
                                       short AV7WWPNotificationAppliesTo ,
                                       string AV27Pgmname ,
                                       string A7WWPUserExtendedId ,
                                       string AV30Udparg1 ,
                                       bool A27WWPSubscriptionSubscribed ,
                                       string A19WWPSubscriptionRoleId ,
                                       GxSimpleCollection<string> AV23WWPSubscriptionRoleIdCollection ,
                                       long AV8WWPNotificationId ,
                                       string A26WWPSubscriptionEntityRecordId ,
                                       string AV20WWPSubscriptionEntityRecordId ,
                                       long A25WWPSubscriptionId ,
                                       long AV24WWPNotificationDefinitionId ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0W2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_WWPNOTIFICATIONDEFINITIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A23WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", "")));
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
         RF0W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV27Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
      }

      protected void RF0W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 9;
         /* Execute user event: Refresh */
         E130W2 ();
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_92( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H000W2 */
            pr_default.execute(0, new Object[] {AV7WWPNotificationAppliesTo, AV5WWPEntityId, GXPagingFrom2, GXPagingTo2});
            nGXsfl_9_idx = 1;
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A31WWPNotificationDefinitionAllowUserSubscription = H000W2_A31WWPNotificationDefinitionAllowUserSubscription[0];
               A30WWPNotificationDefinitionAppliesTo = H000W2_A30WWPNotificationDefinitionAppliesTo[0];
               A20WWPEntityId = H000W2_A20WWPEntityId[0];
               A68WWPNotificationDefinitionIsAuthorized = H000W2_A68WWPNotificationDefinitionIsAuthorized[0];
               A23WWPNotificationDefinitionId = H000W2_A23WWPNotificationDefinitionId[0];
               A29WWPNotificationDefinitionDescription = H000W2_A29WWPNotificationDefinitionDescription[0];
               A67WWPNotificationDefinitionSecFuncionality = H000W2_A67WWPNotificationDefinitionSecFuncionality[0];
               /* Execute user event: Grid.Load */
               E140W2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 9;
            WB0W0( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0W2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG1", StringUtil.RTrim( AV30Udparg1));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV30Udparg1, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPSUBSCRIPTIONROLEIDCOLLECTION", AV23WWPSubscriptionRoleIdCollection);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPSUBSCRIPTIONROLEIDCOLLECTION", GetSecureSignedToken( sPrefix, AV23WWPSubscriptionRoleIdCollection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8WWPNotificationId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24WWPNotificationDefinitionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONDEFINITIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV24WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_WWPNOTIFICATIONDEFINITIONID"+"_"+sGXsfl_9_idx, GetSecureSignedToken( sPrefix+sGXsfl_9_idx, context.localUtil.Format( (decimal)(A23WWPNotificationDefinitionId), "ZZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV30Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Using cursor H000W3 */
         pr_default.execute(1, new Object[] {AV7WWPNotificationAppliesTo, AV5WWPEntityId});
         GRID_nRecordCount = H000W3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV27Pgmname, A7WWPUserExtendedId, AV30Udparg1, A27WWPSubscriptionSubscribed, A19WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A26WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A25WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV27Pgmname, A7WWPUserExtendedId, AV30Udparg1, A27WWPSubscriptionSubscribed, A19WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A26WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A25WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV27Pgmname, A7WWPUserExtendedId, AV30Udparg1, A27WWPSubscriptionSubscribed, A19WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A26WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A25WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV27Pgmname, A7WWPUserExtendedId, AV30Udparg1, A27WWPSubscriptionSubscribed, A19WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A26WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A25WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV5WWPEntityId, AV7WWPNotificationAppliesTo, AV27Pgmname, A7WWPUserExtendedId, AV30Udparg1, A27WWPSubscriptionSubscribed, A19WWPSubscriptionRoleId, AV23WWPSubscriptionRoleIdCollection, AV8WWPNotificationId, A26WWPSubscriptionEntityRecordId, AV20WWPSubscriptionEntityRecordId, A25WWPSubscriptionId, AV24WWPNotificationDefinitionId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV27Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         edtWWPNotificationDefinitionDescription_Enabled = 0;
         edtWWPNotificationDefinitionId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120W2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV6WWPEntityName = cgiGet( sPrefix+"wcpOAV6WWPEntityName");
            wcpOAV7WWPNotificationAppliesTo = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPNotificationAppliesTo"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV20WWPSubscriptionEntityRecordId = cgiGet( sPrefix+"wcpOAV20WWPSubscriptionEntityRecordId");
            wcpOAV14RecordAttDescription = cgiGet( sPrefix+"wcpOAV14RecordAttDescription");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E120W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120W2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtWWPNotificationDefinitionId_Visible = 0;
         AssignProp(sPrefix, false, edtWWPNotificationDefinitionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0), !bGXsfl_9_Refreshing);
         edtavWwpsubscriptionid_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpsubscriptionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0), !bGXsfl_9_Refreshing);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_int1 = AV5WWPEntityId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  AV6WWPEntityName, out  GXt_int1) ;
         AV5WWPEntityId = GXt_int1;
         AssignAttri(sPrefix, false, "AV5WWPEntityId", StringUtil.LTrimStr( (decimal)(AV5WWPEntityId), 10, 0));
         GXt_objcol_char2 = AV23WWPSubscriptionRoleIdCollection;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserroles(context ).execute( out  GXt_objcol_char2) ;
         AV23WWPSubscriptionRoleIdCollection = GXt_objcol_char2;
      }

      protected void E130W2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV19WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E140W2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADCHECKINCLUDENOTIFICATIONS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV8WWPNotificationId = A23WWPNotificationDefinitionId;
         AssignAttri(sPrefix, false, "AV8WWPNotificationId", StringUtil.LTrimStr( (decimal)(AV8WWPNotificationId), 10, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPNOTIFICATIONID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV8WWPNotificationId), "ZZZZZZZZZ9"), context));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 9;
         }
         sendrow_92( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
         {
            DoAjaxLoad(9, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV27Pgmname+"GridState"), "") == 0 )
         {
            AV9GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV27Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV9GridState.FromXml(AV16Session.Get(AV27Pgmname+"GridState"), null, "", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV9GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV9GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV9GridState.gxTpr_Currentpage) ;
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV9GridState.FromXml(AV16Session.Get(AV27Pgmname+"GridState"), null, "", "");
         AV9GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV9GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV27Pgmname+"GridState",  AV9GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV17TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV17TrnContext.gxTpr_Callerobject = AV27Pgmname;
         AV17TrnContext.gxTpr_Callerondelete = true;
         AV17TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV17TrnContext.gxTpr_Transactionname = "WWPBaseObjects.Notifications.Common.WWP_NotificationDefinition";
         AV16Session.Set("TrnContext", AV17TrnContext.ToXml(false, true, "", ""));
      }

      protected void E110W2( )
      {
         /* Tablesubscriptionitem_Click Routine */
         returnInSub = false;
         AV12IncludeNotification = (bool)(!AV12IncludeNotification);
         AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
         new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_userupdatesubscription(context ).execute(  AV12IncludeNotification, ref  AV22WWPSubscriptionId,  A23WWPNotificationDefinitionId,  AV20WWPSubscriptionEntityRecordId,  AV14RecordAttDescription) ;
         AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
         if ( 1 == 0 )
         {
            /* Start For Each Line */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), ",", "."), 18, MidpointRounding.ToEven));
            nGXsfl_9_fel_idx = 0;
            while ( nGXsfl_9_fel_idx < nRC_GXsfl_9 )
            {
               nGXsfl_9_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_fel_idx+1);
               sGXsfl_9_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_92( ) ;
               AV12IncludeNotification = StringUtil.StrToBool( cgiGet( chkavIncludenotification_Internalname));
               A29WWPNotificationDefinitionDescription = cgiGet( edtWWPNotificationDefinitionDescription_Internalname);
               A23WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               if ( ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWWPSUBSCRIPTIONID");
                  GX_FocusControl = edtavWwpsubscriptionid_Internalname;
                  wbErr = true;
                  AV22WWPSubscriptionId = 0;
               }
               else
               {
                  AV22WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavWwpsubscriptionid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               }
               /* End For Each Line */
            }
            if ( nGXsfl_9_fel_idx == 0 )
            {
               nGXsfl_9_idx = 1;
               sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
               SubsflControlProps_92( ) ;
            }
            nGXsfl_9_fel_idx = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'LOADCHECKINCLUDENOTIFICATIONS' Routine */
         returnInSub = false;
         AV12IncludeNotification = false;
         AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
         AV30Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A19WWPSubscriptionRoleId ,
                                              AV23WWPSubscriptionRoleIdCollection ,
                                              AV20WWPSubscriptionEntityRecordId ,
                                              A26WWPSubscriptionEntityRecordId ,
                                              A7WWPUserExtendedId ,
                                              AV30Udparg1 ,
                                              A27WWPSubscriptionSubscribed ,
                                              AV8WWPNotificationId ,
                                              A23WWPNotificationDefinitionId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H000W4 */
         pr_default.execute(2, new Object[] {AV8WWPNotificationId, AV30Udparg1, AV20WWPSubscriptionEntityRecordId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A26WWPSubscriptionEntityRecordId = H000W4_A26WWPSubscriptionEntityRecordId[0];
            A23WWPNotificationDefinitionId = H000W4_A23WWPNotificationDefinitionId[0];
            A19WWPSubscriptionRoleId = H000W4_A19WWPSubscriptionRoleId[0];
            n19WWPSubscriptionRoleId = H000W4_n19WWPSubscriptionRoleId[0];
            A27WWPSubscriptionSubscribed = H000W4_A27WWPSubscriptionSubscribed[0];
            A7WWPUserExtendedId = H000W4_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = H000W4_n7WWPUserExtendedId[0];
            A25WWPSubscriptionId = H000W4_A25WWPSubscriptionId[0];
            AV22WWPSubscriptionId = A25WWPSubscriptionId;
            AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
            AV12IncludeNotification = true;
            AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A19WWPSubscriptionRoleId)) )
            {
               GXt_boolean3 = AV12IncludeNotification;
               new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_checkuserisnotunsubscribed(context ).execute(  AV24WWPNotificationDefinitionId, ref  AV22WWPSubscriptionId, ref  GXt_boolean3) ;
               AssignAttri(sPrefix, false, edtavWwpsubscriptionid_Internalname, StringUtil.LTrimStr( (decimal)(AV22WWPSubscriptionId), 10, 0));
               AV12IncludeNotification = GXt_boolean3;
               AssignAttri(sPrefix, false, chkavIncludenotification_Internalname, AV12IncludeNotification);
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6WWPEntityName = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6WWPEntityName", AV6WWPEntityName);
         AV7WWPNotificationAppliesTo = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV7WWPNotificationAppliesTo", StringUtil.Str( (decimal)(AV7WWPNotificationAppliesTo), 1, 0));
         AV20WWPSubscriptionEntityRecordId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV20WWPSubscriptionEntityRecordId", AV20WWPSubscriptionEntityRecordId);
         AV14RecordAttDescription = (string)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV14RecordAttDescription", AV14RecordAttDescription);
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
         PA0W2( ) ;
         WS0W2( ) ;
         WE0W2( ) ;
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
         sCtrlAV6WWPEntityName = (string)((string)getParm(obj,0));
         sCtrlAV7WWPNotificationAppliesTo = (string)((string)getParm(obj,1));
         sCtrlAV20WWPSubscriptionEntityRecordId = (string)((string)getParm(obj,2));
         sCtrlAV14RecordAttDescription = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0W2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\subscriptions\\wwp_subscriptionspanel", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0W2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6WWPEntityName = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6WWPEntityName", AV6WWPEntityName);
            AV7WWPNotificationAppliesTo = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7WWPNotificationAppliesTo", StringUtil.Str( (decimal)(AV7WWPNotificationAppliesTo), 1, 0));
            AV20WWPSubscriptionEntityRecordId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV20WWPSubscriptionEntityRecordId", AV20WWPSubscriptionEntityRecordId);
            AV14RecordAttDescription = (string)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV14RecordAttDescription", AV14RecordAttDescription);
         }
         wcpOAV6WWPEntityName = cgiGet( sPrefix+"wcpOAV6WWPEntityName");
         wcpOAV7WWPNotificationAppliesTo = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPNotificationAppliesTo"), ",", "."), 18, MidpointRounding.ToEven));
         wcpOAV20WWPSubscriptionEntityRecordId = cgiGet( sPrefix+"wcpOAV20WWPSubscriptionEntityRecordId");
         wcpOAV14RecordAttDescription = cgiGet( sPrefix+"wcpOAV14RecordAttDescription");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WWPEntityName, wcpOAV6WWPEntityName) != 0 ) || ( AV7WWPNotificationAppliesTo != wcpOAV7WWPNotificationAppliesTo ) || ( StringUtil.StrCmp(AV20WWPSubscriptionEntityRecordId, wcpOAV20WWPSubscriptionEntityRecordId) != 0 ) || ( StringUtil.StrCmp(AV14RecordAttDescription, wcpOAV14RecordAttDescription) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WWPEntityName = AV6WWPEntityName;
         wcpOAV7WWPNotificationAppliesTo = AV7WWPNotificationAppliesTo;
         wcpOAV20WWPSubscriptionEntityRecordId = AV20WWPSubscriptionEntityRecordId;
         wcpOAV14RecordAttDescription = AV14RecordAttDescription;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6WWPEntityName = cgiGet( sPrefix+"AV6WWPEntityName_CTRL");
         if ( StringUtil.Len( sCtrlAV6WWPEntityName) > 0 )
         {
            AV6WWPEntityName = cgiGet( sCtrlAV6WWPEntityName);
            AssignAttri(sPrefix, false, "AV6WWPEntityName", AV6WWPEntityName);
         }
         else
         {
            AV6WWPEntityName = cgiGet( sPrefix+"AV6WWPEntityName_PARM");
         }
         sCtrlAV7WWPNotificationAppliesTo = cgiGet( sPrefix+"AV7WWPNotificationAppliesTo_CTRL");
         if ( StringUtil.Len( sCtrlAV7WWPNotificationAppliesTo) > 0 )
         {
            AV7WWPNotificationAppliesTo = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV7WWPNotificationAppliesTo), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV7WWPNotificationAppliesTo", StringUtil.Str( (decimal)(AV7WWPNotificationAppliesTo), 1, 0));
         }
         else
         {
            AV7WWPNotificationAppliesTo = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV7WWPNotificationAppliesTo_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
         sCtrlAV20WWPSubscriptionEntityRecordId = cgiGet( sPrefix+"AV20WWPSubscriptionEntityRecordId_CTRL");
         if ( StringUtil.Len( sCtrlAV20WWPSubscriptionEntityRecordId) > 0 )
         {
            AV20WWPSubscriptionEntityRecordId = cgiGet( sCtrlAV20WWPSubscriptionEntityRecordId);
            AssignAttri(sPrefix, false, "AV20WWPSubscriptionEntityRecordId", AV20WWPSubscriptionEntityRecordId);
         }
         else
         {
            AV20WWPSubscriptionEntityRecordId = cgiGet( sPrefix+"AV20WWPSubscriptionEntityRecordId_PARM");
         }
         sCtrlAV14RecordAttDescription = cgiGet( sPrefix+"AV14RecordAttDescription_CTRL");
         if ( StringUtil.Len( sCtrlAV14RecordAttDescription) > 0 )
         {
            AV14RecordAttDescription = cgiGet( sCtrlAV14RecordAttDescription);
            AssignAttri(sPrefix, false, "AV14RecordAttDescription", AV14RecordAttDescription);
         }
         else
         {
            AV14RecordAttDescription = cgiGet( sPrefix+"AV14RecordAttDescription_PARM");
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
         PA0W2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0W2( ) ;
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
         WS0W2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WWPEntityName_PARM", AV6WWPEntityName);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WWPEntityName)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WWPEntityName_CTRL", StringUtil.RTrim( sCtrlAV6WWPEntityName));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPNotificationAppliesTo_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPNotificationAppliesTo), 1, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7WWPNotificationAppliesTo)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPNotificationAppliesTo_CTRL", StringUtil.RTrim( sCtrlAV7WWPNotificationAppliesTo));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20WWPSubscriptionEntityRecordId_PARM", AV20WWPSubscriptionEntityRecordId);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20WWPSubscriptionEntityRecordId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20WWPSubscriptionEntityRecordId_CTRL", StringUtil.RTrim( sCtrlAV20WWPSubscriptionEntityRecordId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV14RecordAttDescription_PARM", AV14RecordAttDescription);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14RecordAttDescription)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14RecordAttDescription_CTRL", StringUtil.RTrim( sCtrlAV14RecordAttDescription));
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
         WE0W2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019123494", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("wwpbaseobjects/subscriptions/wwp_subscriptionspanel.js", "?202561019123494", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_92( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION_"+sGXsfl_9_idx;
         edtWWPNotificationDefinitionDescription_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONDESCRIPTION_"+sGXsfl_9_idx;
         edtWWPNotificationDefinitionId_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONID_"+sGXsfl_9_idx;
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION_"+sGXsfl_9_fel_idx;
         edtWWPNotificationDefinitionDescription_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONDESCRIPTION_"+sGXsfl_9_fel_idx;
         edtWWPNotificationDefinitionId_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONID_"+sGXsfl_9_fel_idx;
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         WB0W0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_9_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0xFFFFFF);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_9_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
            }
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsgrid_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 SubscriptionItem",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablesubscriptionitem_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavIncludenotification_Internalname,(string)"Include Notification",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',9)\"";
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "vINCLUDENOTIFICATION_" + sGXsfl_9_idx;
            chkavIncludenotification.Name = GXCCtl;
            chkavIncludenotification.WebTags = "";
            chkavIncludenotification.Caption = "Include Notification";
            AssignProp(sPrefix, false, chkavIncludenotification_Internalname, "TitleCaption", chkavIncludenotification.Caption, !bGXsfl_9_Refreshing);
            chkavIncludenotification.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIncludenotification_Internalname,StringUtil.BoolToStr( AV12IncludeNotification),(string)"",(string)"Include Notification",(short)1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(16, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,16);\""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionDescription_Internalname,(string)"Notification Definition Description",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionDescription_Internalname,(string)A29WWPNotificationDefinitionDescription,(string)"",(string)"",(short)0,(short)1,(short)0,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrid_Internalname+"_"+sGXsfl_9_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionId_Internalname,(string)"Notification Definition Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationDefinitionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A23WWPNotificationDefinitionId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPNotificationDefinitionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtWWPNotificationDefinitionId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"end",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionid_Internalname,(string)"WWPSubscription Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',9)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpsubscriptionid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22WWPSubscriptionId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22WWPSubscriptionId), "ZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,29);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpsubscriptionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavWwpsubscriptionid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("row");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("table");
            }
            /* End of table */
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            send_integrity_lvl_hashes0W2( ) ;
            /* End of Columns property logic. */
            GridContainer.AddRow(GridRow);
            nGXsfl_9_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         /* End function sendrow_92 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vINCLUDENOTIFICATION_" + sGXsfl_9_idx;
         chkavIncludenotification.Name = GXCCtl;
         chkavIncludenotification.WebTags = "";
         chkavIncludenotification.Caption = "Include Notification";
         AssignProp(sPrefix, false, chkavIncludenotification_Internalname, "TitleCaption", chkavIncludenotification.Caption, !bGXsfl_9_Refreshing);
         chkavIncludenotification.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl9( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"9\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV12IncludeNotification)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A29WWPNotificationDefinitionDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationDefinitionId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22WWPSubscriptionId), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpsubscriptionid_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         chkavIncludenotification_Internalname = sPrefix+"vINCLUDENOTIFICATION";
         edtWWPNotificationDefinitionDescription_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONDESCRIPTION";
         divTablesubscriptionitem_Internalname = sPrefix+"TABLESUBSCRIPTIONITEM";
         edtWWPNotificationDefinitionId_Internalname = sPrefix+"WWPNOTIFICATIONDEFINITIONID";
         edtavWwpsubscriptionid_Internalname = sPrefix+"vWWPSUBSCRIPTIONID";
         tblUnnamedtablecontentfsgrid_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSGRID";
         divUnnamedtablefsgrid_Internalname = sPrefix+"UNNAMEDTABLEFSGRID";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         subGrid_Allowcollapsing = 0;
         edtavWwpsubscriptionid_Jsonclick = "";
         edtWWPNotificationDefinitionId_Jsonclick = "";
         chkavIncludenotification.Caption = "Include Notification";
         subGrid_Class = "FreeStyleGrid";
         edtWWPNotificationDefinitionId_Enabled = 0;
         edtWWPNotificationDefinitionDescription_Enabled = 0;
         subGrid_Backcolorstyle = 0;
         edtavWwpsubscriptionid_Visible = 1;
         edtWWPNotificationDefinitionId_Visible = 1;
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV5WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV7WWPNotificationAppliesTo","fld":"vWWPNOTIFICATIONAPPLIESTO","pic":"9","type":"int"},{"av":"edtWWPNotificationDefinitionId_Visible","ctrl":"WWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID","type":"char"},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED","type":"boolean"},{"av":"A19WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID","type":"char"},{"av":"A26WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"A25WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"sPrefix","type":"char"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV30Udparg1","fld":"vUDPARG1","hsh":true,"type":"char"},{"av":"AV23WWPSubscriptionRoleIdCollection","fld":"vWWPSUBSCRIPTIONROLEIDCOLLECTION","hsh":true,"type":""},{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV24WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E140W2","iparms":[{"av":"A23WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID","type":"char"},{"av":"AV30Udparg1","fld":"vUDPARG1","hsh":true,"type":"char"},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED","type":"boolean"},{"av":"A19WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID","type":"char"},{"av":"AV23WWPSubscriptionRoleIdCollection","fld":"vWWPSUBSCRIPTIONROLEIDCOLLECTION","hsh":true,"type":""},{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A26WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"A25WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV24WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV12IncludeNotification","fld":"vINCLUDENOTIFICATION","type":"boolean"},{"av":"AV22WWPSubscriptionId","fld":"vWWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("TABLESUBSCRIPTIONITEM.CLICK","""{"handler":"E110W2","iparms":[{"av":"AV12IncludeNotification","fld":"vINCLUDENOTIFICATION","grid":9,"type":"boolean"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_9","ctrl":"GRID","prop":"GridRC","grid":9,"type":"int"},{"av":"AV22WWPSubscriptionId","fld":"vWWPSUBSCRIPTIONID","grid":9,"pic":"ZZZZZZZZZ9","type":"int"},{"av":"A23WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","grid":9,"pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"AV14RecordAttDescription","fld":"vRECORDATTDESCRIPTION","type":"svchar"}]""");
         setEventMetadata("TABLESUBSCRIPTIONITEM.CLICK",""","oparms":[{"av":"AV12IncludeNotification","fld":"vINCLUDENOTIFICATION","type":"boolean"},{"av":"AV22WWPSubscriptionId","fld":"vWWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV5WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV7WWPNotificationAppliesTo","fld":"vWWPNOTIFICATIONAPPLIESTO","pic":"9","type":"int"},{"av":"edtWWPNotificationDefinitionId_Visible","ctrl":"WWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID","type":"char"},{"av":"AV30Udparg1","fld":"vUDPARG1","hsh":true,"type":"char"},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED","type":"boolean"},{"av":"A19WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID","type":"char"},{"av":"AV23WWPSubscriptionRoleIdCollection","fld":"vWWPSUBSCRIPTIONROLEIDCOLLECTION","hsh":true,"type":""},{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A26WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"A25WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV24WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV5WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV7WWPNotificationAppliesTo","fld":"vWWPNOTIFICATIONAPPLIESTO","pic":"9","type":"int"},{"av":"edtWWPNotificationDefinitionId_Visible","ctrl":"WWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID","type":"char"},{"av":"AV30Udparg1","fld":"vUDPARG1","hsh":true,"type":"char"},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED","type":"boolean"},{"av":"A19WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID","type":"char"},{"av":"AV23WWPSubscriptionRoleIdCollection","fld":"vWWPSUBSCRIPTIONROLEIDCOLLECTION","hsh":true,"type":""},{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A26WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"A25WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV24WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV5WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV7WWPNotificationAppliesTo","fld":"vWWPNOTIFICATIONAPPLIESTO","pic":"9","type":"int"},{"av":"edtWWPNotificationDefinitionId_Visible","ctrl":"WWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID","type":"char"},{"av":"AV30Udparg1","fld":"vUDPARG1","hsh":true,"type":"char"},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED","type":"boolean"},{"av":"A19WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID","type":"char"},{"av":"AV23WWPSubscriptionRoleIdCollection","fld":"vWWPSUBSCRIPTIONROLEIDCOLLECTION","hsh":true,"type":""},{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A26WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"A25WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV24WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV5WWPEntityId","fld":"vWWPENTITYID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV7WWPNotificationAppliesTo","fld":"vWWPNOTIFICATIONAPPLIESTO","pic":"9","type":"int"},{"av":"edtWWPNotificationDefinitionId_Visible","ctrl":"WWPNOTIFICATIONDEFINITIONID","prop":"Visible"},{"av":"edtavWwpsubscriptionid_Visible","ctrl":"vWWPSUBSCRIPTIONID","prop":"Visible"},{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID","type":"char"},{"av":"AV30Udparg1","fld":"vUDPARG1","hsh":true,"type":"char"},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED","type":"boolean"},{"av":"A19WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID","type":"char"},{"av":"AV23WWPSubscriptionRoleIdCollection","fld":"vWWPSUBSCRIPTIONROLEIDCOLLECTION","hsh":true,"type":""},{"av":"AV8WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A26WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"AV20WWPSubscriptionEntityRecordId","fld":"vWWPSUBSCRIPTIONENTITYRECORDID","type":"svchar"},{"av":"A25WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV24WWPNotificationDefinitionId","fld":"vWWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV27Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Wwpsubscriptionid","iparms":[]}""");
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
         wcpOAV6WWPEntityName = "";
         wcpOAV20WWPSubscriptionEntityRecordId = "";
         wcpOAV14RecordAttDescription = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV27Pgmname = "";
         A7WWPUserExtendedId = "";
         AV30Udparg1 = "";
         A19WWPSubscriptionRoleId = "";
         AV23WWPSubscriptionRoleIdCollection = new GxSimpleCollection<string>();
         A26WWPSubscriptionEntityRecordId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A29WWPNotificationDefinitionDescription = "";
         GXDecQS = "";
         H000W2_A31WWPNotificationDefinitionAllowUserSubscription = new bool[] {false} ;
         H000W2_A30WWPNotificationDefinitionAppliesTo = new short[1] ;
         H000W2_A20WWPEntityId = new long[1] ;
         H000W2_A68WWPNotificationDefinitionIsAuthorized = new bool[] {false} ;
         H000W2_A23WWPNotificationDefinitionId = new long[1] ;
         H000W2_A29WWPNotificationDefinitionDescription = new string[] {""} ;
         H000W2_A67WWPNotificationDefinitionSecFuncionality = new string[] {""} ;
         A67WWPNotificationDefinitionSecFuncionality = "";
         H000W3_AGRID_nRecordCount = new long[1] ;
         GXt_objcol_char2 = new GxSimpleCollection<string>();
         AV19WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV16Session = context.GetSession();
         AV9GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         H000W4_A26WWPSubscriptionEntityRecordId = new string[] {""} ;
         H000W4_A23WWPNotificationDefinitionId = new long[1] ;
         H000W4_A19WWPSubscriptionRoleId = new string[] {""} ;
         H000W4_n19WWPSubscriptionRoleId = new bool[] {false} ;
         H000W4_A27WWPSubscriptionSubscribed = new bool[] {false} ;
         H000W4_A7WWPUserExtendedId = new string[] {""} ;
         H000W4_n7WWPUserExtendedId = new bool[] {false} ;
         H000W4_A25WWPSubscriptionId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WWPEntityName = "";
         sCtrlAV7WWPNotificationAppliesTo = "";
         sCtrlAV20WWPSubscriptionEntityRecordId = "";
         sCtrlAV14RecordAttDescription = "";
         subGrid_Linesclass = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         GXCCtl = "";
         ROClassString = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscriptionspanel__default(),
            new Object[][] {
                new Object[] {
               H000W2_A31WWPNotificationDefinitionAllowUserSubscription, H000W2_A30WWPNotificationDefinitionAppliesTo, H000W2_A20WWPEntityId, H000W2_A68WWPNotificationDefinitionIsAuthorized, H000W2_A23WWPNotificationDefinitionId, H000W2_A29WWPNotificationDefinitionDescription, H000W2_A67WWPNotificationDefinitionSecFuncionality
               }
               , new Object[] {
               H000W3_AGRID_nRecordCount
               }
               , new Object[] {
               H000W4_A26WWPSubscriptionEntityRecordId, H000W4_A23WWPNotificationDefinitionId, H000W4_A19WWPSubscriptionRoleId, H000W4_n19WWPSubscriptionRoleId, H000W4_A27WWPSubscriptionSubscribed, H000W4_A7WWPUserExtendedId, H000W4_n7WWPUserExtendedId, H000W4_A25WWPSubscriptionId
               }
            }
         );
         AV27Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         /* GeneXus formulas. */
         AV27Pgmname = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
      }

      private short AV7WWPNotificationAppliesTo ;
      private short wcpOAV7WWPNotificationAppliesTo ;
      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short A30WWPNotificationDefinitionAppliesTo ;
      private short subGrid_Backstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtWWPNotificationDefinitionId_Visible ;
      private int edtavWwpsubscriptionid_Visible ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWWPNotificationDefinitionDescription_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int nGXsfl_9_fel_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV5WWPEntityId ;
      private long AV8WWPNotificationId ;
      private long A25WWPSubscriptionId ;
      private long AV24WWPNotificationDefinitionId ;
      private long A23WWPNotificationDefinitionId ;
      private long AV22WWPSubscriptionId ;
      private long GRID_nCurrentRecord ;
      private long A20WWPEntityId ;
      private long GRID_nRecordCount ;
      private long GXt_int1 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_9_idx="0001" ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtavWwpsubscriptionid_Internalname ;
      private string AV27Pgmname ;
      private string A7WWPUserExtendedId ;
      private string AV30Udparg1 ;
      private string A19WWPSubscriptionRoleId ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavIncludenotification_Internalname ;
      private string edtWWPNotificationDefinitionDescription_Internalname ;
      private string GXDecQS ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string sCtrlAV6WWPEntityName ;
      private string sCtrlAV7WWPNotificationAppliesTo ;
      private string sCtrlAV20WWPSubscriptionEntityRecordId ;
      private string sCtrlAV14RecordAttDescription ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string divUnnamedtablefsgrid_Internalname ;
      private string divTablesubscriptionitem_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string GXCCtl ;
      private string tblUnnamedtablecontentfsgrid_Internalname ;
      private string ROClassString ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtavWwpsubscriptionid_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool n7WWPUserExtendedId ;
      private bool A27WWPSubscriptionSubscribed ;
      private bool n19WWPSubscriptionRoleId ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV12IncludeNotification ;
      private bool gxdyncontrolsrefreshing ;
      private bool A31WWPNotificationDefinitionAllowUserSubscription ;
      private bool A68WWPNotificationDefinitionIsAuthorized ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean3 ;
      private string AV6WWPEntityName ;
      private string AV20WWPSubscriptionEntityRecordId ;
      private string AV14RecordAttDescription ;
      private string wcpOAV6WWPEntityName ;
      private string wcpOAV20WWPSubscriptionEntityRecordId ;
      private string wcpOAV14RecordAttDescription ;
      private string A26WWPSubscriptionEntityRecordId ;
      private string A29WWPNotificationDefinitionDescription ;
      private string A67WWPNotificationDefinitionSecFuncionality ;
      private IGxSession AV16Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIncludenotification ;
      private GxSimpleCollection<string> AV23WWPSubscriptionRoleIdCollection ;
      private IDataStoreProvider pr_default ;
      private bool[] H000W2_A31WWPNotificationDefinitionAllowUserSubscription ;
      private short[] H000W2_A30WWPNotificationDefinitionAppliesTo ;
      private long[] H000W2_A20WWPEntityId ;
      private bool[] H000W2_A68WWPNotificationDefinitionIsAuthorized ;
      private long[] H000W2_A23WWPNotificationDefinitionId ;
      private string[] H000W2_A29WWPNotificationDefinitionDescription ;
      private string[] H000W2_A67WWPNotificationDefinitionSecFuncionality ;
      private long[] H000W3_AGRID_nRecordCount ;
      private GxSimpleCollection<string> GXt_objcol_char2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV19WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV9GridState ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV17TrnContext ;
      private string[] H000W4_A26WWPSubscriptionEntityRecordId ;
      private long[] H000W4_A23WWPNotificationDefinitionId ;
      private string[] H000W4_A19WWPSubscriptionRoleId ;
      private bool[] H000W4_n19WWPSubscriptionRoleId ;
      private bool[] H000W4_A27WWPSubscriptionSubscribed ;
      private string[] H000W4_A7WWPUserExtendedId ;
      private bool[] H000W4_n7WWPUserExtendedId ;
      private long[] H000W4_A25WWPSubscriptionId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_subscriptionspanel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000W4( IGxContext context ,
                                             string A19WWPSubscriptionRoleId ,
                                             GxSimpleCollection<string> AV23WWPSubscriptionRoleIdCollection ,
                                             string AV20WWPSubscriptionEntityRecordId ,
                                             string A26WWPSubscriptionEntityRecordId ,
                                             string A7WWPUserExtendedId ,
                                             string AV30Udparg1 ,
                                             bool A27WWPSubscriptionSubscribed ,
                                             long AV8WWPNotificationId ,
                                             long A23WWPNotificationDefinitionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[3];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT WWPSubscriptionEntityRecordId, WWPNotificationDefinitionId, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPUserExtendedId, WWPSubscriptionId FROM WWP_Subscription";
         AddWhere(sWhereString, "(WWPNotificationDefinitionId = :AV8WWPNotificationId)");
         AddWhere(sWhereString, "(( WWPUserExtendedId = ( :AV30Udparg1) and WWPSubscriptionSubscribed) or "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV23WWPSubscriptionRoleIdCollection, "WWPSubscriptionRoleId IN (", ")")+")");
         if ( StringUtil.StrCmp(AV20WWPSubscriptionEntityRecordId, "") != 0 )
         {
            AddWhere(sWhereString, "(WWPSubscriptionEntityRecordId = ( :AV20WWPSubscriptionEntityRecordId))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPNotificationDefinitionId";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_H000W4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH000W2;
          prmH000W2 = new Object[] {
          new ParDef("AV7WWPNotificationAppliesTo",GXType.Int16,1,0) ,
          new ParDef("AV5WWPEntityId",GXType.Int64,10,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000W3;
          prmH000W3 = new Object[] {
          new ParDef("AV7WWPNotificationAppliesTo",GXType.Int16,1,0) ,
          new ParDef("AV5WWPEntityId",GXType.Int64,10,0)
          };
          Object[] prmH000W4;
          prmH000W4 = new Object[] {
          new ParDef("AV8WWPNotificationId",GXType.Int64,10,0) ,
          new ParDef("AV30Udparg1",GXType.Char,40,0) ,
          new ParDef("AV20WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000W2", "SELECT WWPNotificationDefinitionAllowUserSubscription, WWPNotificationDefinitionAppliesTo, WWPEntityId, CASE  WHEN (char_length(trim(trailing ' ' from WWPNotificationDefinitionSecFuncionality))=0) THEN TRUE END AS WWPNotificationDefinitionIsAuthorized, WWPNotificationDefinitionId, WWPNotificationDefinitionDescription, WWPNotificationDefinitionSecFuncionality FROM WWP_NotificationDefinition WHERE (WWPNotificationDefinitionAllowUserSubscription = TRUE) AND (WWPNotificationDefinitionAppliesTo = :AV7WWPNotificationAppliesTo) AND (WWPEntityId = :AV5WWPEntityId) AND (CASE  WHEN (char_length(trim(trailing ' ' from WWPNotificationDefinitionSecFuncionality))=0) THEN TRUE END = TRUE) ORDER BY WWPNotificationDefinitionId  OFFSET :GXPagingFrom2 LIMIT CASE WHEN :GXPagingTo2 > 0 THEN :GXPagingTo2 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000W2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000W3", "SELECT COUNT(*) FROM WWP_NotificationDefinition WHERE (WWPNotificationDefinitionAllowUserSubscription = TRUE) AND (WWPNotificationDefinitionAppliesTo = :AV7WWPNotificationAppliesTo) AND (WWPEntityId = :AV5WWPEntityId) AND (CASE  WHEN (char_length(trim(trailing ' ' from WWPNotificationDefinitionSecFuncionality))=0) THEN TRUE END = TRUE) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000W3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000W4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000W4,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 40);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
