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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_masterpagenotificationswc : GXWebComponent
   {
      public wwp_masterpagenotificationswc( )
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

      public wwp_masterpagenotificationswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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
         cmbavUsernotificationstatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetNextPar( );
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
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
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
                  gxfirstwebparm = GetNextPar( );
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetNextPar( );
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freegrid") == 0 )
               {
                  gxnrFreegrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Freegrid") == 0 )
               {
                  gxgrFreegrid_refresh_invoke( ) ;
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

      protected void gxnrFreegrid_newrow_invoke( )
      {
         nRC_GXsfl_12 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
         sPrefix = GetPar( "sPrefix");
         edtavNotificationlink_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavNotificationlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotificationlink_Visible), 5, 0), !bGXsfl_12_Refreshing);
         cmbavUsernotificationstatus.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, cmbavUsernotificationstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtavUsernotificationid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUsernotificationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsernotificationid_Visible), 5, 0), !bGXsfl_12_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreegrid_newrow( ) ;
         /* End function gxnrFreegrid_newrow_invoke */
      }

      protected void gxgrFreegrid_refresh_invoke( )
      {
         edtavNotificationlink_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavNotificationlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotificationlink_Visible), 5, 0), !bGXsfl_12_Refreshing);
         cmbavUsernotificationstatus.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, cmbavUsernotificationstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtavUsernotificationid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUsernotificationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsernotificationid_Visible), 5, 0), !bGXsfl_12_Refreshing);
         A385NotificationCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "NotificationCreatedAt"));
         n385NotificationCreatedAt = false;
         A388UserNotificationUserId = (short)(Math.Round(NumberUtil.Val( GetPar( "UserNotificationUserId"), "."), 18, MidpointRounding.ToEven));
         n388UserNotificationUserId = false;
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10WWPContext);
         A384NotificationType = GetPar( "NotificationType");
         n384NotificationType = false;
         A389UserNotificationStatus = GetPar( "UserNotificationStatus");
         n389UserNotificationStatus = false;
         A383NotificationMessage = GetPar( "NotificationMessage");
         n383NotificationMessage = false;
         A397NotificationLink = GetPar( "NotificationLink");
         n397NotificationLink = false;
         A387UserNotificationId = (int)(Math.Round(NumberUtil.Val( GetPar( "UserNotificationId"), "."), 18, MidpointRounding.ToEven));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreegrid_refresh( A385NotificationCreatedAt, A388UserNotificationUserId, AV10WWPContext, A384NotificationType, A389UserNotificationStatus, A383NotificationMessage, A397NotificationLink, A387UserNotificationId, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFreegrid_refresh_invoke */
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
            PA0X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS0X2( ) ;
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
            context.SendWebValue( "Master Page Notifications") ;
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
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_masterpagenotificationswc") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV10WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV10WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV10WWPContext, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"NOTIFICATIONCREATEDAT", context.localUtil.TToC( A385NotificationCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"USERNOTIFICATIONUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A388UserNotificationUserId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV10WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV10WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV10WWPContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"NOTIFICATIONTYPE", A384NotificationType);
         GxWebStd.gx_hidden_field( context, sPrefix+"USERNOTIFICATIONSTATUS", A389UserNotificationStatus);
         GxWebStd.gx_hidden_field( context, sPrefix+"NOTIFICATIONMESSAGE", A383NotificationMessage);
         GxWebStd.gx_hidden_field( context, sPrefix+"NOTIFICATIONLINK", A397NotificationLink);
         GxWebStd.gx_hidden_field( context, sPrefix+"USERNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A387UserNotificationId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subFreegrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREEGRID_Class", StringUtil.RTrim( subFreegrid_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREEGRID_Flexdirection", StringUtil.RTrim( subFreegrid_Flexdirection));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOTIFICATIONLINK_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationlink_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERNOTIFICATIONSTATUS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERNOTIFICATIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsernotificationid_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0X2( )
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
         return "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Master Page Notifications" ;
      }

      protected void WB0X0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.notifications.common.wwp_masterpagenotificationswc");
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNotificationcontent_Internalname, 1, 0, "px", 0, "px", "NotificationContent", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            FreegridContainer.SetIsFreestyle(true);
            FreegridContainer.SetWrapped(nGXWrapped);
            StartGridControl12( ) ;
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
            if ( FreegridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"FreegridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Freegrid", FreegridContainer, subFreegrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FreegridContainerData", FreegridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"FreegridContainerData"+"V", FreegridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FreegridContainerData"+"V"+"\" value='"+FreegridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonNotificationCheckAll";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncheckallnotif_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(12), 2, 0)+","+"null"+");", "Ver todas notificações >", bttBtncheckallnotif_Jsonclick, 5, "Ver todas notificações >", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCHECKALLNOTIF\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_MasterPageNotificationsWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FreegridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"FreegridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Freegrid", FreegridContainer, subFreegrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FreegridContainerData", FreegridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"FreegridContainerData"+"V", FreegridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"FreegridContainerData"+"V"+"\" value='"+FreegridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0X2( )
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
            Form.Meta.addItem("description", "Master Page Notifications", 0) ;
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
               STRUP0X0( ) ;
            }
         }
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
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
                                 STRUP0X0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOCHECKALLNOTIF'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoCheckAllNotif' */
                                    E110X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavNotificationlink_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "FREEGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'DOMARCARCOMOLIDA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DOIRPARALINK'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'DOMARCARCOMOLIDA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DOIRPARALINK'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              AV12NotificationLink = cgiGet( edtavNotificationlink_Internalname);
                              AssignAttri(sPrefix, false, edtavNotificationlink_Internalname, AV12NotificationLink);
                              cmbavUsernotificationstatus.Name = cmbavUsernotificationstatus_Internalname;
                              cmbavUsernotificationstatus.CurrentValue = cgiGet( cmbavUsernotificationstatus_Internalname);
                              AV14UserNotificationStatus = cgiGet( cmbavUsernotificationstatus_Internalname);
                              AssignAttri(sPrefix, false, cmbavUsernotificationstatus_Internalname, AV14UserNotificationStatus);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavUsernotificationid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsernotificationid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSERNOTIFICATIONID");
                                 GX_FocusControl = edtavUsernotificationid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV15UserNotificationId = 0;
                                 AssignAttri(sPrefix, false, edtavUsernotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV15UserNotificationId), 9, 0));
                              }
                              else
                              {
                                 AV15UserNotificationId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsernotificationid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavUsernotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV15UserNotificationId), 9, 0));
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
                                          GX_FocusControl = edtavNotificationlink_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E120X2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREEGRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationlink_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Freegrid.Load */
                                          E130X2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOMARCARCOMOLIDA'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationlink_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoMarcarComoLida' */
                                          E140X2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOIRPARALINK'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationlink_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoIrParaLink' */
                                          E150X2 ();
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
                                       STRUP0X0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavNotificationlink_Internalname;
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

      protected void WE0X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0X2( ) ;
            }
         }
      }

      protected void PA0X2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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

      protected void gxnrFreegrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subFreegrid_Islastpage==1)&&(nGXsfl_12_idx+1>subFreegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FreegridContainer)) ;
         /* End function gxnrFreegrid_newrow */
      }

      protected void gxgrFreegrid_refresh( DateTime A385NotificationCreatedAt ,
                                           short A388UserNotificationUserId ,
                                           GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ,
                                           string A384NotificationType ,
                                           string A389UserNotificationStatus ,
                                           string A383NotificationMessage ,
                                           string A397NotificationLink ,
                                           int A387UserNotificationId ,
                                           string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREEGRID_nCurrentRecord = 0;
         RF0X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFreegrid_refresh */
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
         RF0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FreegridContainer.ClearRows();
         }
         wbStart = 12;
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         FreegridContainer.AddObjectProperty("GridName", "Freegrid");
         FreegridContainer.AddObjectProperty("CmpContext", sPrefix);
         FreegridContainer.AddObjectProperty("InMasterPage", "false");
         FreegridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FreegridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FreegridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FreegridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FreegridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Backcolorstyle), 1, 0, ".", "")));
         FreegridContainer.PageSize = subFreegrid_fnc_Recordsperpage( );
         if ( subFreegrid_Islastpage != 0 )
         {
            FREEGRID_nFirstRecordOnPage = (long)(subFreegrid_fnc_Recordcount( )-subFreegrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"FREEGRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREEGRID_nFirstRecordOnPage), 15, 0, ".", "")));
            FreegridContainer.AddObjectProperty("FREEGRID_nFirstRecordOnPage", FREEGRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            /* Execute user event: Freegrid.Load */
            E130X2 ();
            wbEnd = 12;
            WB0X0( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV10WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV10WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV10WWPContext, context));
      }

      protected int subFreegrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFreegrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFreegrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFreegrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120X2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ",", "."), 18, MidpointRounding.ToEven));
            subFreegrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subFreegrid_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            subFreegrid_Class = cgiGet( sPrefix+"FREEGRID_Class");
            subFreegrid_Flexdirection = cgiGet( sPrefix+"FREEGRID_Flexdirection");
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
         E120X2 ();
         if (returnInSub) return;
      }

      protected void E120X2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV10WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV10WWPContext = GXt_SdtWWPContext1;
         edtavNotificationlink_Visible = 0;
         AssignProp(sPrefix, false, edtavNotificationlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotificationlink_Visible), 5, 0), !bGXsfl_12_Refreshing);
         cmbavUsernotificationstatus.Visible = 0;
         AssignProp(sPrefix, false, cmbavUsernotificationstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtavUsernotificationid_Visible = 0;
         AssignProp(sPrefix, false, edtavUsernotificationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsernotificationid_Visible), 5, 0), !bGXsfl_12_Refreshing);
      }

      private void E130X2( )
      {
         /* Freegrid_Load Routine */
         returnInSub = false;
         AV11Count = 0;
         /* Using cursor H000X2 */
         pr_default.execute(0, new Object[] {AV10WWPContext.gxTpr_Userid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A381NotificationId = H000X2_A381NotificationId[0];
            n381NotificationId = H000X2_n381NotificationId[0];
            A388UserNotificationUserId = H000X2_A388UserNotificationUserId[0];
            n388UserNotificationUserId = H000X2_n388UserNotificationUserId[0];
            A384NotificationType = H000X2_A384NotificationType[0];
            n384NotificationType = H000X2_n384NotificationType[0];
            A389UserNotificationStatus = H000X2_A389UserNotificationStatus[0];
            n389UserNotificationStatus = H000X2_n389UserNotificationStatus[0];
            A383NotificationMessage = H000X2_A383NotificationMessage[0];
            n383NotificationMessage = H000X2_n383NotificationMessage[0];
            A397NotificationLink = H000X2_A397NotificationLink[0];
            n397NotificationLink = H000X2_n397NotificationLink[0];
            A387UserNotificationId = H000X2_A387UserNotificationId[0];
            A385NotificationCreatedAt = H000X2_A385NotificationCreatedAt[0];
            n385NotificationCreatedAt = H000X2_n385NotificationCreatedAt[0];
            A384NotificationType = H000X2_A384NotificationType[0];
            n384NotificationType = H000X2_n384NotificationType[0];
            A383NotificationMessage = H000X2_A383NotificationMessage[0];
            n383NotificationMessage = H000X2_n383NotificationMessage[0];
            A397NotificationLink = H000X2_A397NotificationLink[0];
            n397NotificationLink = H000X2_n397NotificationLink[0];
            A385NotificationCreatedAt = H000X2_A385NotificationCreatedAt[0];
            n385NotificationCreatedAt = H000X2_n385NotificationCreatedAt[0];
            lblNovamenssagem_Caption = StringUtil.Format( "<h4><i style=\"margin-right:5px; font-size: 24px;\" class=\"fa-regular fa-envelope\"></i>%1</h4>", A383NotificationMessage, "", "", "", "", "", "", "", "");
            AV12NotificationLink = A397NotificationLink;
            AssignAttri(sPrefix, false, edtavNotificationlink_Internalname, AV12NotificationLink);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12NotificationLink)) && ( StringUtil.StrCmp(A389UserNotificationStatus, "Unread") == 0 ) )
            {
               new prreadnotification(context ).execute(  A387UserNotificationId) ;
            }
            AV15UserNotificationId = A387UserNotificationId;
            AssignAttri(sPrefix, false, edtavUsernotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV15UserNotificationId), 9, 0));
            if ( StringUtil.StrCmp(A389UserNotificationStatus, "Unread") == 0 )
            {
               lblMarcarcomolida_Visible = 1;
            }
            else
            {
               lblMarcarcomolida_Visible = 0;
            }
            if ( StringUtil.StrCmp(AV12NotificationLink, "") != 0 )
            {
               lblIrparalink_Visible = 1;
            }
            else
            {
               lblIrparalink_Visible = 0;
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 12;
            }
            sendrow_122( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
            {
               DoAjaxLoad(12, FreegridRow);
            }
            AV11Count = (short)(AV11Count+1);
            if ( AV11Count == 5 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /*  Sending Event outputs  */
      }

      protected void E110X2( )
      {
         /* 'DoCheckAllNotif' Routine */
         returnInSub = false;
         CallWebObject(formatLink("visualizarnotificacoes") );
         context.wjLocDisableFrm = 1;
      }

      protected void E140X2( )
      {
         /* 'DoMarcarComoLida' Routine */
         returnInSub = false;
         AV13UserNotification.Load(AV15UserNotificationId);
         AV13UserNotification.gxTpr_Usernotificationstatus = "Read";
         AV13UserNotification.Save();
         context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_masterpagenotificationswc",pr_default);
         gxgrFreegrid_refresh( A385NotificationCreatedAt, A388UserNotificationUserId, AV10WWPContext, A384NotificationType, A389UserNotificationStatus, A383NotificationMessage, A397NotificationLink, A387UserNotificationId, sPrefix) ;
         this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "Master_RefreshNotifications", new Object[] {}, true);
      }

      protected void E150X2( )
      {
         /* 'DoIrParaLink' Routine */
         returnInSub = false;
         AV13UserNotification.Load(AV15UserNotificationId);
         AV13UserNotification.gxTpr_Usernotificationstatus = "Read";
         AV13UserNotification.Save();
         context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_masterpagenotificationswc",pr_default);
         CallWebObject(formatLink(AV12NotificationLink) );
         context.wjLocDisableFrm = 0;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
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
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0X2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\notifications\\common\\wwp_masterpagenotificationswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0X2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         PA0X2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0X2( ) ;
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
         WS0X2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
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
         WE0X2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019163894", true, true);
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
            context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_masterpagenotificationswc.js", "?202561019163894", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         lblMarcarcomolida_Internalname = sPrefix+"MARCARCOMOLIDA_"+sGXsfl_12_idx;
         lblNovamenssagem_Internalname = sPrefix+"NOVAMENSSAGEM_"+sGXsfl_12_idx;
         lblIrparalink_Internalname = sPrefix+"IRPARALINK_"+sGXsfl_12_idx;
         edtavNotificationlink_Internalname = sPrefix+"vNOTIFICATIONLINK_"+sGXsfl_12_idx;
         cmbavUsernotificationstatus_Internalname = sPrefix+"vUSERNOTIFICATIONSTATUS_"+sGXsfl_12_idx;
         edtavUsernotificationid_Internalname = sPrefix+"vUSERNOTIFICATIONID_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         lblMarcarcomolida_Internalname = sPrefix+"MARCARCOMOLIDA_"+sGXsfl_12_fel_idx;
         lblNovamenssagem_Internalname = sPrefix+"NOVAMENSSAGEM_"+sGXsfl_12_fel_idx;
         lblIrparalink_Internalname = sPrefix+"IRPARALINK_"+sGXsfl_12_fel_idx;
         edtavNotificationlink_Internalname = sPrefix+"vNOTIFICATIONLINK_"+sGXsfl_12_fel_idx;
         cmbavUsernotificationstatus_Internalname = sPrefix+"vUSERNOTIFICATIONSTATUS_"+sGXsfl_12_fel_idx;
         edtavUsernotificationid_Internalname = sPrefix+"vUSERNOTIFICATIONID_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB0X0( ) ;
         FreegridRow = GXWebRow.GetNew(context,FreegridContainer);
         if ( subFreegrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFreegrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subFreegrid_Class, "") != 0 )
            {
               subFreegrid_Linesclass = subFreegrid_Class+"Odd";
            }
         }
         else if ( subFreegrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFreegrid_Backstyle = 0;
            subFreegrid_Backcolor = subFreegrid_Allbackcolor;
            if ( StringUtil.StrCmp(subFreegrid_Class, "") != 0 )
            {
               subFreegrid_Linesclass = subFreegrid_Class+"Uniform";
            }
         }
         else if ( subFreegrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFreegrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subFreegrid_Class, "") != 0 )
            {
               subFreegrid_Linesclass = subFreegrid_Class+"Odd";
            }
            subFreegrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFreegrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFreegrid_Backstyle = 1;
            subFreegrid_Backcolor = (int)(0xFFFFFF);
            if ( StringUtil.StrCmp(subFreegrid_Class, "") != 0 )
            {
               subFreegrid_Linesclass = subFreegrid_Class+"Odd";
            }
         }
         /* Start of Columns property logic. */
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFreegridlayouttable_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablecontentline_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"NotificationCardTable",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Text block */
         FreegridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblMarcarcomolida_Internalname,(string)"<i class=\"Icon24 far fa-eye\"></i>",(string)"",(string)"",(string)lblMarcarcomolida_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOMARCARCOMOLIDA\\'."+sGXsfl_12_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)"",(int)lblMarcarcomolida_Visible,(short)1,(short)0,(short)1});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-8",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Text block */
         FreegridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNovamenssagem_Internalname,(string)lblNovamenssagem_Caption,(string)"",(string)"",(string)lblNovamenssagem_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"end",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Text block */
         FreegridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblIrparalink_Internalname,(string)"<i class=\"Icon24 fas fa-arrow-up-right-from-square\"></i>",(string)"",(string)"",(string)lblIrparalink_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOIRPARALINK\\'."+sGXsfl_12_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)"",(int)lblIrparalink_Visible,(short)1,(short)0,(short)1});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"end",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Table start */
         FreegridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfreegrid_Internalname+"_"+sGXsfl_12_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Attribute/Variable Label */
         FreegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationlink_Internalname,(string)"Notification Link",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',12)\"";
         ROClassString = "Attribute";
         FreegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationlink_Internalname,(string)AV12NotificationLink,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationlink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavNotificationlink_Visible,(short)1,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)1000,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            FreegridContainer.CloseTag("cell");
         }
         FreegridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Attribute/Variable Label */
         FreegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)cmbavUsernotificationstatus_Internalname,(string)"User Notification Status",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',12)\"";
         if ( ( cmbavUsernotificationstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vUSERNOTIFICATIONSTATUS_" + sGXsfl_12_idx;
            cmbavUsernotificationstatus.Name = GXCCtl;
            cmbavUsernotificationstatus.WebTags = "";
            cmbavUsernotificationstatus.addItem("Unread", "Unread", 0);
            cmbavUsernotificationstatus.addItem("Read", "Read", 0);
            if ( cmbavUsernotificationstatus.ItemCount > 0 )
            {
               AV14UserNotificationStatus = cmbavUsernotificationstatus.getValidValue(AV14UserNotificationStatus);
               AssignAttri(sPrefix, false, cmbavUsernotificationstatus_Internalname, AV14UserNotificationStatus);
            }
         }
         /* ComboBox */
         FreegridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavUsernotificationstatus,(string)cmbavUsernotificationstatus_Internalname,StringUtil.RTrim( AV14UserNotificationStatus),(short)1,(string)cmbavUsernotificationstatus_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",cmbavUsernotificationstatus.Visible,(short)1,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"",(string)"",(bool)true,(short)0});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         cmbavUsernotificationstatus.CurrentValue = StringUtil.RTrim( AV14UserNotificationStatus);
         AssignProp(sPrefix, false, cmbavUsernotificationstatus_Internalname, "Values", (string)(cmbavUsernotificationstatus.ToJavascriptSource()), !bGXsfl_12_Refreshing);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            FreegridContainer.CloseTag("cell");
         }
         FreegridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Attribute/Variable Label */
         FreegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavUsernotificationid_Internalname,(string)"User Notification Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',12)\"";
         ROClassString = "Attribute";
         FreegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsernotificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15UserNotificationId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15UserNotificationId), "ZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsernotificationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavUsernotificationid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)9,(string)"chr",(short)1,(string)"row",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            FreegridContainer.CloseTag("cell");
         }
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            FreegridContainer.CloseTag("row");
         }
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            FreegridContainer.CloseTag("table");
         }
         /* End of table */
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         send_integrity_lvl_hashes0X2( ) ;
         /* End of Columns property logic. */
         FreegridContainer.AddRow(FreegridRow);
         nGXsfl_12_idx = ((subFreegrid_Islastpage==1)&&(nGXsfl_12_idx+1>subFreegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vUSERNOTIFICATIONSTATUS_" + sGXsfl_12_idx;
         cmbavUsernotificationstatus.Name = GXCCtl;
         cmbavUsernotificationstatus.WebTags = "";
         cmbavUsernotificationstatus.addItem("Unread", "Unread", 0);
         cmbavUsernotificationstatus.addItem("Read", "Read", 0);
         if ( cmbavUsernotificationstatus.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl12( )
      {
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"FreegridContainer"+"DivS\" data-gxgridid=\"12\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFreegrid_Internalname, subFreegrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FreegridContainer.AddObjectProperty("GridName", "Freegrid");
         }
         else
         {
            FreegridContainer.AddObjectProperty("GridName", "Freegrid");
            FreegridContainer.AddObjectProperty("Header", subFreegrid_Header);
            FreegridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FreegridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FreegridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Backcolorstyle), 1, 0, ".", "")));
            FreegridContainer.AddObjectProperty("CmpContext", sPrefix);
            FreegridContainer.AddObjectProperty("InMasterPage", "false");
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridColumn.AddObjectProperty("Value", lblMarcarcomolida_Caption);
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridColumn.AddObjectProperty("Value", lblNovamenssagem_Caption);
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridColumn.AddObjectProperty("Value", lblIrparalink_Caption);
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV12NotificationLink));
            FreegridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationlink_Visible), 5, 0, ".", "")));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV14UserNotificationStatus));
            FreegridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0, ".", "")));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15UserNotificationId), 9, 0, ".", ""))));
            FreegridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsernotificationid_Visible), 5, 0, ".", "")));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Selectedindex), 4, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Allowselection), 1, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Selectioncolor), 9, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Allowhovering), 1, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Hoveringcolor), 9, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Allowcollapsing), 1, 0, ".", "")));
            FreegridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblMarcarcomolida_Internalname = sPrefix+"MARCARCOMOLIDA";
         lblNovamenssagem_Internalname = sPrefix+"NOVAMENSSAGEM";
         lblIrparalink_Internalname = sPrefix+"IRPARALINK";
         divTablecontentline_Internalname = sPrefix+"TABLECONTENTLINE";
         edtavNotificationlink_Internalname = sPrefix+"vNOTIFICATIONLINK";
         cmbavUsernotificationstatus_Internalname = sPrefix+"vUSERNOTIFICATIONSTATUS";
         edtavUsernotificationid_Internalname = sPrefix+"vUSERNOTIFICATIONID";
         tblUnnamedtablecontentfsfreegrid_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSFREEGRID";
         divFreegridlayouttable_Internalname = sPrefix+"FREEGRIDLAYOUTTABLE";
         divNotificationcontent_Internalname = sPrefix+"NOTIFICATIONCONTENT";
         bttBtncheckallnotif_Internalname = sPrefix+"BTNCHECKALLNOTIF";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subFreegrid_Internalname = sPrefix+"FREEGRID";
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
         subFreegrid_Allowcollapsing = 0;
         lblIrparalink_Caption = "<i class=\"Icon24 fas fa-arrow-up-right-from-square\"></i>";
         lblNovamenssagem_Caption = "<h4><i style=\"margin-right:5px; font-size: 24px;\" class=\"fa-regular fa-envelope\"></i>Você tem uma nova mensagem</h4>";
         lblMarcarcomolida_Caption = "<i class=\"Icon24 far fa-eye\"></i>";
         edtavUsernotificationid_Jsonclick = "";
         cmbavUsernotificationstatus_Jsonclick = "";
         edtavNotificationlink_Jsonclick = "";
         lblIrparalink_Visible = 1;
         lblNovamenssagem_Caption = "<h4><i style=\"margin-right:5px; font-size: 24px;\" class=\"fa-regular fa-envelope\"></i>Você tem uma nova mensagem</h4>";
         lblMarcarcomolida_Visible = 1;
         subFreegrid_Backcolorstyle = 0;
         subFreegrid_Flexdirection = "column";
         subFreegrid_Class = "FreeStyleGrid";
         edtavUsernotificationid_Visible = 1;
         cmbavUsernotificationstatus.Visible = 1;
         edtavNotificationlink_Visible = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"edtavNotificationlink_Visible","ctrl":"vNOTIFICATIONLINK","prop":"Visible"},{"av":"cmbavUsernotificationstatus"},{"av":"edtavUsernotificationid_Visible","ctrl":"vUSERNOTIFICATIONID","prop":"Visible"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV10WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("FREEGRID.LOAD","""{"handler":"E130X2","iparms":[{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"AV10WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("FREEGRID.LOAD",""","oparms":[{"av":"lblNovamenssagem_Caption","ctrl":"NOVAMENSSAGEM","prop":"Caption"},{"av":"AV12NotificationLink","fld":"vNOTIFICATIONLINK","type":"svchar"},{"av":"AV15UserNotificationId","fld":"vUSERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"lblMarcarcomolida_Visible","ctrl":"MARCARCOMOLIDA","prop":"Visible"},{"av":"lblIrparalink_Visible","ctrl":"IRPARALINK","prop":"Visible"}]}""");
         setEventMetadata("'DOCHECKALLNOTIF'","""{"handler":"E110X2","iparms":[]}""");
         setEventMetadata("'DOMARCARCOMOLIDA'","""{"handler":"E140X2","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"edtavNotificationlink_Visible","ctrl":"vNOTIFICATIONLINK","prop":"Visible"},{"av":"cmbavUsernotificationstatus"},{"av":"edtavUsernotificationid_Visible","ctrl":"vUSERNOTIFICATIONID","prop":"Visible"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"AV10WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV15UserNotificationId","fld":"vUSERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("'DOIRPARALINK'","""{"handler":"E150X2","iparms":[{"av":"AV15UserNotificationId","fld":"vUSERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12NotificationLink","fld":"vNOTIFICATIONLINK","type":"svchar"}]}""");
         setEventMetadata("VALIDV_NOTIFICATIONLINK","""{"handler":"Validv_Notificationlink","iparms":[]}""");
         setEventMetadata("VALIDV_USERNOTIFICATIONSTATUS","""{"handler":"Validv_Usernotificationstatus","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Usernotificationid","iparms":[]}""");
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
         sPrefix = "";
         A385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         A384NotificationType = "";
         A389UserNotificationStatus = "";
         A383NotificationMessage = "";
         A397NotificationLink = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         FreegridContainer = new GXWebGrid( context);
         sStyleString = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtncheckallnotif_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV12NotificationLink = "";
         AV14UserNotificationStatus = "";
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H000X2_A381NotificationId = new int[1] ;
         H000X2_n381NotificationId = new bool[] {false} ;
         H000X2_A388UserNotificationUserId = new short[1] ;
         H000X2_n388UserNotificationUserId = new bool[] {false} ;
         H000X2_A384NotificationType = new string[] {""} ;
         H000X2_n384NotificationType = new bool[] {false} ;
         H000X2_A389UserNotificationStatus = new string[] {""} ;
         H000X2_n389UserNotificationStatus = new bool[] {false} ;
         H000X2_A383NotificationMessage = new string[] {""} ;
         H000X2_n383NotificationMessage = new bool[] {false} ;
         H000X2_A397NotificationLink = new string[] {""} ;
         H000X2_n397NotificationLink = new bool[] {false} ;
         H000X2_A387UserNotificationId = new int[1] ;
         H000X2_A385NotificationCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H000X2_n385NotificationCreatedAt = new bool[] {false} ;
         FreegridRow = new GXWebRow();
         AV13UserNotification = new SdtUserNotification(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subFreegrid_Linesclass = "";
         FreegridColumn = new GXWebColumn();
         lblMarcarcomolida_Jsonclick = "";
         lblNovamenssagem_Jsonclick = "";
         lblIrparalink_Jsonclick = "";
         ROClassString = "";
         GXCCtl = "";
         subFreegrid_Header = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_masterpagenotificationswc__default(),
            new Object[][] {
                new Object[] {
               H000X2_A381NotificationId, H000X2_n381NotificationId, H000X2_A388UserNotificationUserId, H000X2_n388UserNotificationUserId, H000X2_A384NotificationType, H000X2_n384NotificationType, H000X2_A389UserNotificationStatus, H000X2_n389UserNotificationStatus, H000X2_A383NotificationMessage, H000X2_n383NotificationMessage,
               H000X2_A397NotificationLink, H000X2_n397NotificationLink, H000X2_A387UserNotificationId, H000X2_A385NotificationCreatedAt, H000X2_n385NotificationCreatedAt
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A388UserNotificationUserId ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subFreegrid_Backcolorstyle ;
      private short AV11Count ;
      private short FREEGRID_nEOF ;
      private short subFreegrid_Backstyle ;
      private short subFreegrid_Allowselection ;
      private short subFreegrid_Allowhovering ;
      private short subFreegrid_Allowcollapsing ;
      private short subFreegrid_Collapsed ;
      private int edtavNotificationlink_Visible ;
      private int edtavUsernotificationid_Visible ;
      private int nRC_GXsfl_12 ;
      private int subFreegrid_Recordcount ;
      private int nGXsfl_12_idx=1 ;
      private int A387UserNotificationId ;
      private int AV15UserNotificationId ;
      private int subFreegrid_Islastpage ;
      private int A381NotificationId ;
      private int lblMarcarcomolida_Visible ;
      private int lblIrparalink_Visible ;
      private int idxLst ;
      private int subFreegrid_Backcolor ;
      private int subFreegrid_Allbackcolor ;
      private int subFreegrid_Selectedindex ;
      private int subFreegrid_Selectioncolor ;
      private int subFreegrid_Hoveringcolor ;
      private long FREEGRID_nCurrentRecord ;
      private long FREEGRID_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string edtavNotificationlink_Internalname ;
      private string cmbavUsernotificationstatus_Internalname ;
      private string edtavUsernotificationid_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string subFreegrid_Class ;
      private string subFreegrid_Flexdirection ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divNotificationcontent_Internalname ;
      private string sStyleString ;
      private string subFreegrid_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtncheckallnotif_Internalname ;
      private string bttBtncheckallnotif_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string lblNovamenssagem_Caption ;
      private string lblMarcarcomolida_Internalname ;
      private string lblNovamenssagem_Internalname ;
      private string lblIrparalink_Internalname ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subFreegrid_Linesclass ;
      private string divFreegridlayouttable_Internalname ;
      private string divTablecontentline_Internalname ;
      private string lblMarcarcomolida_Jsonclick ;
      private string lblNovamenssagem_Jsonclick ;
      private string lblIrparalink_Jsonclick ;
      private string tblUnnamedtablecontentfsfreegrid_Internalname ;
      private string ROClassString ;
      private string edtavNotificationlink_Jsonclick ;
      private string GXCCtl ;
      private string cmbavUsernotificationstatus_Jsonclick ;
      private string edtavUsernotificationid_Jsonclick ;
      private string subFreegrid_Header ;
      private string lblMarcarcomolida_Caption ;
      private string lblIrparalink_Caption ;
      private DateTime A385NotificationCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool n385NotificationCreatedAt ;
      private bool n388UserNotificationUserId ;
      private bool n384NotificationType ;
      private bool n389UserNotificationStatus ;
      private bool n383NotificationMessage ;
      private bool n397NotificationLink ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n381NotificationId ;
      private string A384NotificationType ;
      private string A389UserNotificationStatus ;
      private string A383NotificationMessage ;
      private string A397NotificationLink ;
      private string AV12NotificationLink ;
      private string AV14UserNotificationStatus ;
      private GXWebGrid FreegridContainer ;
      private GXWebRow FreegridRow ;
      private GXWebColumn FreegridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavUsernotificationstatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private int[] H000X2_A381NotificationId ;
      private bool[] H000X2_n381NotificationId ;
      private short[] H000X2_A388UserNotificationUserId ;
      private bool[] H000X2_n388UserNotificationUserId ;
      private string[] H000X2_A384NotificationType ;
      private bool[] H000X2_n384NotificationType ;
      private string[] H000X2_A389UserNotificationStatus ;
      private bool[] H000X2_n389UserNotificationStatus ;
      private string[] H000X2_A383NotificationMessage ;
      private bool[] H000X2_n383NotificationMessage ;
      private string[] H000X2_A397NotificationLink ;
      private bool[] H000X2_n397NotificationLink ;
      private int[] H000X2_A387UserNotificationId ;
      private DateTime[] H000X2_A385NotificationCreatedAt ;
      private bool[] H000X2_n385NotificationCreatedAt ;
      private SdtUserNotification AV13UserNotification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_masterpagenotificationswc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000X2;
          prmH000X2 = new Object[] {
          new ParDef("AV10WWPContext__Userid",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000X2", "SELECT T1.NotificationId, T1.UserNotificationUserId, T2.NotificationType, T1.UserNotificationStatus, T2.NotificationMessage, T2.NotificationLink, T1.UserNotificationId, T2.NotificationCreatedAt FROM (UserNotification T1 LEFT JOIN Notification T2 ON T2.NotificationId = T1.NotificationId) WHERE (T1.UserNotificationUserId = :AV10WWPContext__Userid) AND (T2.NotificationType = ( 'Internal')) AND (T1.UserNotificationStatus = ( 'Unread')) ORDER BY T2.NotificationCreatedAt DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
