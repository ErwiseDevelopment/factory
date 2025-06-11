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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_visualizeallnotifications : GXDataArea
   {
      public wwp_visualizeallnotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_visualizeallnotifications( IGxContext context )
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

      protected override void createObjects( )
      {
         cmbavUsernotificationstatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_22 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_22"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_22_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_22_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_22_idx = GetPar( "sGXsfl_22_idx");
         edtavNotificationlink_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavNotificationlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotificationlink_Visible), 5, 0), !bGXsfl_22_Refreshing);
         cmbavUsernotificationstatus.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, cmbavUsernotificationstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0), !bGXsfl_22_Refreshing);
         edtavUsernotificationid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavUsernotificationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsernotificationid_Visible), 5, 0), !bGXsfl_22_Refreshing);
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
         AV28Pgmname = GetPar( "Pgmname");
         edtavNotificationlink_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavNotificationlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotificationlink_Visible), 5, 0), !bGXsfl_22_Refreshing);
         cmbavUsernotificationstatus.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, cmbavUsernotificationstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0), !bGXsfl_22_Refreshing);
         edtavUsernotificationid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavUsernotificationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsernotificationid_Visible), 5, 0), !bGXsfl_22_Refreshing);
         A385NotificationCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "NotificationCreatedAt"));
         n385NotificationCreatedAt = false;
         A388UserNotificationUserId = (short)(Math.Round(NumberUtil.Val( GetPar( "UserNotificationUserId"), "."), 18, MidpointRounding.ToEven));
         n388UserNotificationUserId = false;
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6WWPContext);
         A384NotificationType = GetPar( "NotificationType");
         n384NotificationType = false;
         A389UserNotificationStatus = GetPar( "UserNotificationStatus");
         n389UserNotificationStatus = false;
         A383NotificationMessage = GetPar( "NotificationMessage");
         n383NotificationMessage = false;
         A397NotificationLink = GetPar( "NotificationLink");
         n397NotificationLink = false;
         A387UserNotificationId = (int)(Math.Round(NumberUtil.Val( GetPar( "UserNotificationId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A385NotificationCreatedAt, A388UserNotificationUserId, AV6WWPContext, A384NotificationType, A389UserNotificationStatus, A383NotificationMessage, A397NotificationLink, A387UserNotificationId) ;
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
         PA0T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0T2( ) ;
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV6WWPContext, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_22", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_22), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "NOTIFICATIONCREATEDAT", context.localUtil.TToC( A385NotificationCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "USERNOTIFICATIONUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A388UserNotificationUserId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV6WWPContext, context));
         GxWebStd.gx_hidden_field( context, "NOTIFICATIONTYPE", A384NotificationType);
         GxWebStd.gx_hidden_field( context, "USERNOTIFICATIONSTATUS", A389UserNotificationStatus);
         GxWebStd.gx_hidden_field( context, "NOTIFICATIONMESSAGE", A383NotificationMessage);
         GxWebStd.gx_hidden_field( context, "NOTIFICATIONLINK", A397NotificationLink);
         GxWebStd.gx_hidden_field( context, "USERNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A387UserNotificationId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Class", StringUtil.RTrim( subGrid_Class));
         GxWebStd.gx_hidden_field( context, "GRID_Flexdirection", StringUtil.RTrim( subGrid_Flexdirection));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONLINK_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationlink_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUSERNOTIFICATIONSTATUS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUSERNOTIFICATIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsernotificationid_Visible), 5, 0, ".", "")));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE0T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0T2( ) ;
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
         return formatLink("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications" ;
      }

      public override string GetPgmdesc( )
      {
         return "Visualizar todas notificações" ;
      }

      protected void WB0T0( )
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnmarkallasread_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(22), 2, 0)+","+"null"+");", "Marcar tudo como lido", bttBtnmarkallasread_Jsonclick, 5, "Marcar tudo como lido", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOMARKALLASREAD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_VisualizeAllNotifications.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNonotifications_Internalname, "Você não recebeu nehuma notificação ainda", "", "", lblNonotifications_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleWWP", 0, "", lblNonotifications_Visible, 1, 0, 0, "HLP_WWPBaseObjects/Notifications/Common/WWP_VisualizeAllNotifications.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGrid2_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl22( ) ;
         }
         if ( wbEnd == 22 )
         {
            wbEnd = 0;
            nRC_GXsfl_22 = (int)(nGXsfl_22_idx-1);
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 22 )
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
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0T2( )
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
         Form.Meta.addItem("description", "Visualizar todas notificações", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0T0( ) ;
      }

      protected void WS0T2( )
      {
         START0T2( ) ;
         EVT0T2( ) ;
      }

      protected void EVT0T2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOMARKALLASREAD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoMarkAllAsRead' */
                              E110T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'DOMARCARCOMOLIDA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DOIRPARALINK'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'DOMARCARCOMOLIDA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DOIRPARALINK'") == 0 ) )
                           {
                              nGXsfl_22_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
                              SubsflControlProps_222( ) ;
                              AV22NotificationLink = cgiGet( edtavNotificationlink_Internalname);
                              AssignAttri("", false, edtavNotificationlink_Internalname, AV22NotificationLink);
                              cmbavUsernotificationstatus.Name = cmbavUsernotificationstatus_Internalname;
                              cmbavUsernotificationstatus.CurrentValue = cgiGet( cmbavUsernotificationstatus_Internalname);
                              AV23UserNotificationStatus = cgiGet( cmbavUsernotificationstatus_Internalname);
                              AssignAttri("", false, cmbavUsernotificationstatus_Internalname, AV23UserNotificationStatus);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavUsernotificationid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsernotificationid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSERNOTIFICATIONID");
                                 GX_FocusControl = edtavUsernotificationid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV24UserNotificationId = 0;
                                 AssignAttri("", false, edtavUsernotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV24UserNotificationId), 9, 0));
                              }
                              else
                              {
                                 AV24UserNotificationId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsernotificationid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavUsernotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV24UserNotificationId), 9, 0));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E120T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E130T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E140T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOMARCARCOMOLIDA'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMarcarComoLida' */
                                    E150T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOIRPARALINK'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoIrParaLink' */
                                    E160T2 ();
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

      protected void WE0T2( )
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

      protected void PA0T2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_222( ) ;
         while ( nGXsfl_22_idx <= nRC_GXsfl_22 )
         {
            sendrow_222( ) ;
            nGXsfl_22_idx = ((subGrid_Islastpage==1)&&(nGXsfl_22_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_22_idx+1);
            sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
            SubsflControlProps_222( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV28Pgmname ,
                                       DateTime A385NotificationCreatedAt ,
                                       short A388UserNotificationUserId ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ,
                                       string A384NotificationType ,
                                       string A389UserNotificationStatus ,
                                       string A383NotificationMessage ,
                                       string A397NotificationLink ,
                                       int A387UserNotificationId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_22_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         RF0T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV28Pgmname = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
      }

      protected void RF0T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 22;
         /* Execute user event: Refresh */
         E130T2 ();
         nGXsfl_22_idx = (int)(1+GRID_nFirstRecordOnPage);
         sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
         SubsflControlProps_222( ) ;
         bGXsfl_22_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_222( ) ;
            /* Execute user event: Grid.Load */
            E140T2 ();
            wbEnd = 22;
            WB0T0( ) ;
         }
         bGXsfl_22_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0T2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV6WWPContext, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(((subGrid_Recordcount==0) ? GRID_nFirstRecordOnPage+1 : subGrid_Recordcount)) ;
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
         return (int)(((subGrid_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGrid_fnc_Recordcount( )/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGrid_fnc_Recordcount( )) % (subGrid_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A385NotificationCreatedAt, A388UserNotificationUserId, AV6WWPContext, A384NotificationType, A389UserNotificationStatus, A383NotificationMessage, A397NotificationLink, A387UserNotificationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         if ( GRID_nEOF == 1 )
         {
            GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A385NotificationCreatedAt, A388UserNotificationUserId, AV6WWPContext, A384NotificationType, A389UserNotificationStatus, A383NotificationMessage, A397NotificationLink, A387UserNotificationId) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A385NotificationCreatedAt, A388UserNotificationUserId, AV6WWPContext, A384NotificationType, A389UserNotificationStatus, A383NotificationMessage, A397NotificationLink, A387UserNotificationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A385NotificationCreatedAt, A388UserNotificationUserId, AV6WWPContext, A384NotificationType, A389UserNotificationStatus, A383NotificationMessage, A397NotificationLink, A387UserNotificationId) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A385NotificationCreatedAt, A388UserNotificationUserId, AV6WWPContext, A384NotificationType, A389UserNotificationStatus, A383NotificationMessage, A397NotificationLink, A387UserNotificationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV28Pgmname = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_22 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_22"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            subGrid_Class = cgiGet( "GRID_Class");
            subGrid_Flexdirection = cgiGet( "GRID_Flexdirection");
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
         E120T2 ();
         if (returnInSub) return;
      }

      protected void E120T2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavNotificationlink_Visible = 0;
         AssignProp("", false, edtavNotificationlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotificationlink_Visible), 5, 0), !bGXsfl_22_Refreshing);
         cmbavUsernotificationstatus.Visible = 0;
         AssignProp("", false, cmbavUsernotificationstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0), !bGXsfl_22_Refreshing);
         edtavUsernotificationid_Visible = 0;
         AssignProp("", false, edtavUsernotificationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsernotificationid_Visible), 5, 0), !bGXsfl_22_Refreshing);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "Visualizar todas notificações";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         GXt_SdtWWPContext1 = AV6WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV6WWPContext = GXt_SdtWWPContext1;
      }

      protected void E130T2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
      }

      private void E140T2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV26GXLvl36 = 0;
         /* Using cursor H000T2 */
         pr_default.execute(0, new Object[] {AV6WWPContext.gxTpr_Userid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A381NotificationId = H000T2_A381NotificationId[0];
            n381NotificationId = H000T2_n381NotificationId[0];
            A388UserNotificationUserId = H000T2_A388UserNotificationUserId[0];
            n388UserNotificationUserId = H000T2_n388UserNotificationUserId[0];
            A384NotificationType = H000T2_A384NotificationType[0];
            n384NotificationType = H000T2_n384NotificationType[0];
            A389UserNotificationStatus = H000T2_A389UserNotificationStatus[0];
            n389UserNotificationStatus = H000T2_n389UserNotificationStatus[0];
            A383NotificationMessage = H000T2_A383NotificationMessage[0];
            n383NotificationMessage = H000T2_n383NotificationMessage[0];
            A397NotificationLink = H000T2_A397NotificationLink[0];
            n397NotificationLink = H000T2_n397NotificationLink[0];
            A387UserNotificationId = H000T2_A387UserNotificationId[0];
            A385NotificationCreatedAt = H000T2_A385NotificationCreatedAt[0];
            n385NotificationCreatedAt = H000T2_n385NotificationCreatedAt[0];
            A384NotificationType = H000T2_A384NotificationType[0];
            n384NotificationType = H000T2_n384NotificationType[0];
            A383NotificationMessage = H000T2_A383NotificationMessage[0];
            n383NotificationMessage = H000T2_n383NotificationMessage[0];
            A397NotificationLink = H000T2_A397NotificationLink[0];
            n397NotificationLink = H000T2_n397NotificationLink[0];
            A385NotificationCreatedAt = H000T2_A385NotificationCreatedAt[0];
            n385NotificationCreatedAt = H000T2_n385NotificationCreatedAt[0];
            AV26GXLvl36 = 1;
            lblNovamenssagem_Caption = StringUtil.Format( "<h4><i style=\"margin-right:5px; font-size: 24px;\" class=\"fa-regular fa-envelope\"></i>%1</h4>", A383NotificationMessage, "", "", "", "", "", "", "", "");
            AV22NotificationLink = A397NotificationLink;
            AssignAttri("", false, edtavNotificationlink_Internalname, AV22NotificationLink);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22NotificationLink)) && ( StringUtil.StrCmp(A389UserNotificationStatus, "Unread") == 0 ) )
            {
               new prreadnotification(context ).execute(  A387UserNotificationId) ;
            }
            AV24UserNotificationId = A387UserNotificationId;
            AssignAttri("", false, edtavUsernotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV24UserNotificationId), 9, 0));
            if ( StringUtil.StrCmp(AV22NotificationLink, "") != 0 )
            {
               lblIrparalink_Visible = 1;
            }
            else
            {
               lblIrparalink_Visible = 0;
            }
            lblNonotifications_Visible = 0;
            AssignProp("", false, lblNonotifications_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNonotifications_Visible), 5, 0), true);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 22;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_222( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            subGrid_Recordcount = (int)(GRID_nCurrentRecord);
            if ( isFullAjaxMode( ) && ! bGXsfl_22_Refreshing )
            {
               DoAjaxLoad(22, GridRow);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV26GXLvl36 == 0 )
         {
            lblNonotifications_Visible = 1;
            AssignProp("", false, lblNonotifications_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNonotifications_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E150T2( )
      {
         /* 'DoMarcarComoLida' Routine */
         returnInSub = false;
         AV25UserNotification.Load(AV24UserNotificationId);
         AV25UserNotification.gxTpr_Usernotificationstatus = "Read";
         AV25UserNotification.Save();
         context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications",pr_default);
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
      }

      protected void E160T2( )
      {
         /* 'DoIrParaLink' Routine */
         returnInSub = false;
         AV25UserNotification.Load(AV24UserNotificationId);
         AV25UserNotification.gxTpr_Usernotificationstatus = "Read";
         AV25UserNotification.Save();
         context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications",pr_default);
         CallWebObject(formatLink(AV22NotificationLink) );
         context.wjLocDisableFrm = 0;
      }

      protected void E110T2( )
      {
         /* 'DoMarkAllAsRead' Routine */
         returnInSub = false;
         /* Using cursor H000T3 */
         pr_default.execute(1, new Object[] {AV6WWPContext.gxTpr_Userid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A389UserNotificationStatus = H000T3_A389UserNotificationStatus[0];
            n389UserNotificationStatus = H000T3_n389UserNotificationStatus[0];
            A388UserNotificationUserId = H000T3_A388UserNotificationUserId[0];
            n388UserNotificationUserId = H000T3_n388UserNotificationUserId[0];
            A387UserNotificationId = H000T3_A387UserNotificationId[0];
            AV25UserNotification = new SdtUserNotification(context);
            AV25UserNotification.Load(A387UserNotificationId);
            AV25UserNotification.gxTpr_Usernotificationstatus = "Read";
            AV25UserNotification.Save();
            pr_default.readNext(1);
         }
         pr_default.close(1);
         context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications",pr_default);
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_22_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         gxgrGrid_refresh( subGrid_Rows, AV28Pgmname, A385NotificationCreatedAt, A388UserNotificationUserId, AV6WWPContext, A384NotificationType, A389UserNotificationStatus, A383NotificationMessage, A397NotificationLink, A387UserNotificationId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV13Session.Get(AV28Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV28Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV13Session.Get(AV28Pgmname+"GridState"), null, "", "");
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV13Session.Get(AV28Pgmname+"GridState"), null, "", "");
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV28Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV28Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "WWPBaseObjects.Notifications.Common.WWP_Notification";
         AV13Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         PA0T2( ) ;
         WS0T2( ) ;
         WE0T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019225674", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_visualizeallnotifications.js", "?202561019225675", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_222( )
      {
         lblMarcarcomolida_Internalname = "MARCARCOMOLIDA_"+sGXsfl_22_idx;
         lblNovamenssagem_Internalname = "NOVAMENSSAGEM_"+sGXsfl_22_idx;
         lblIrparalink_Internalname = "IRPARALINK_"+sGXsfl_22_idx;
         edtavNotificationlink_Internalname = "vNOTIFICATIONLINK_"+sGXsfl_22_idx;
         cmbavUsernotificationstatus_Internalname = "vUSERNOTIFICATIONSTATUS_"+sGXsfl_22_idx;
         edtavUsernotificationid_Internalname = "vUSERNOTIFICATIONID_"+sGXsfl_22_idx;
      }

      protected void SubsflControlProps_fel_222( )
      {
         lblMarcarcomolida_Internalname = "MARCARCOMOLIDA_"+sGXsfl_22_fel_idx;
         lblNovamenssagem_Internalname = "NOVAMENSSAGEM_"+sGXsfl_22_fel_idx;
         lblIrparalink_Internalname = "IRPARALINK_"+sGXsfl_22_fel_idx;
         edtavNotificationlink_Internalname = "vNOTIFICATIONLINK_"+sGXsfl_22_fel_idx;
         cmbavUsernotificationstatus_Internalname = "vUSERNOTIFICATIONSTATUS_"+sGXsfl_22_fel_idx;
         edtavUsernotificationid_Internalname = "vUSERNOTIFICATIONID_"+sGXsfl_22_fel_idx;
      }

      protected void sendrow_222( )
      {
         sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
         SubsflControlProps_222( ) ;
         WB0T0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_22_idx - GRID_nFirstRecordOnPage <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               subGrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            /* Start of Columns property logic. */
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTableline_Internalname+"_"+sGXsfl_22_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"NotificationCardTable",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablecontentline_Internalname+"_"+sGXsfl_22_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Text block */
            GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblMarcarcomolida_Internalname,(string)"<i class=\"Icon24 far fa-eye\"></i>",(string)"",(string)"",(string)lblMarcarcomolida_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'DOMARCARCOMOLIDA\\'."+sGXsfl_22_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)"",(short)1,(short)1,(short)0,(short)1});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-8",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Text block */
            GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNovamenssagem_Internalname,(string)lblNovamenssagem_Caption,(string)"",(string)"",(string)lblNovamenssagem_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"end",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Text block */
            GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblIrparalink_Internalname,(string)"<i class=\"Icon24 fas fa-arrow-up-right-from-square\"></i>",(string)"",(string)"",(string)lblIrparalink_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'DOIRPARALINK\\'."+sGXsfl_22_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)"",(int)lblIrparalink_Visible,(short)1,(short)0,(short)1});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"end",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrid_Internalname+"_"+sGXsfl_22_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationlink_Internalname,(string)"Notification Link",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_22_idx + "',22)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationlink_Internalname,(string)AV22NotificationLink,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationlink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavNotificationlink_Visible,(short)1,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)1000,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)cmbavUsernotificationstatus_Internalname,(string)"User Notification Status",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_22_idx + "',22)\"";
            if ( ( cmbavUsernotificationstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vUSERNOTIFICATIONSTATUS_" + sGXsfl_22_idx;
               cmbavUsernotificationstatus.Name = GXCCtl;
               cmbavUsernotificationstatus.WebTags = "";
               cmbavUsernotificationstatus.addItem("Unread", "Unread", 0);
               cmbavUsernotificationstatus.addItem("Read", "Read", 0);
               if ( cmbavUsernotificationstatus.ItemCount > 0 )
               {
                  AV23UserNotificationStatus = cmbavUsernotificationstatus.getValidValue(AV23UserNotificationStatus);
                  AssignAttri("", false, cmbavUsernotificationstatus_Internalname, AV23UserNotificationStatus);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavUsernotificationstatus,(string)cmbavUsernotificationstatus_Internalname,StringUtil.RTrim( AV23UserNotificationStatus),(short)1,(string)cmbavUsernotificationstatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",cmbavUsernotificationstatus.Visible,(short)1,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"",(bool)true,(short)0});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            cmbavUsernotificationstatus.CurrentValue = StringUtil.RTrim( AV23UserNotificationStatus);
            AssignProp("", false, cmbavUsernotificationstatus_Internalname, "Values", (string)(cmbavUsernotificationstatus.ToJavascriptSource()), !bGXsfl_22_Refreshing);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavUsernotificationid_Internalname,(string)"User Notification Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_22_idx + "',22)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsernotificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24UserNotificationId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV24UserNotificationId), "ZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsernotificationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavUsernotificationid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)9,(string)"chr",(short)1,(string)"row",(short)9,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
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
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            send_integrity_lvl_hashes0T2( ) ;
            /* End of Columns property logic. */
            GridContainer.AddRow(GridRow);
            nGXsfl_22_idx = ((subGrid_Islastpage==1)&&(nGXsfl_22_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_22_idx+1);
            sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
            SubsflControlProps_222( ) ;
         }
         /* End function sendrow_222 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vUSERNOTIFICATIONSTATUS_" + sGXsfl_22_idx;
         cmbavUsernotificationstatus.Name = GXCCtl;
         cmbavUsernotificationstatus.WebTags = "";
         cmbavUsernotificationstatus.addItem("Unread", "Unread", 0);
         cmbavUsernotificationstatus.addItem("Read", "Read", 0);
         if ( cmbavUsernotificationstatus.ItemCount > 0 )
         {
            AV23UserNotificationStatus = cmbavUsernotificationstatus.getValidValue(AV23UserNotificationStatus);
            AssignAttri("", false, cmbavUsernotificationstatus_Internalname, AV23UserNotificationStatus);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl22( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"22\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
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
            GridColumn.AddObjectProperty("Value", lblMarcarcomolida_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblNovamenssagem_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblIrparalink_Caption);
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV22NotificationLink));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationlink_Visible), 5, 0, ".", "")));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV23UserNotificationStatus));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0, ".", "")));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24UserNotificationId), 9, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsernotificationid_Visible), 5, 0, ".", "")));
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
         bttBtnmarkallasread_Internalname = "BTNMARKALLASREAD";
         divTableheader_Internalname = "TABLEHEADER";
         lblNonotifications_Internalname = "NONOTIFICATIONS";
         lblMarcarcomolida_Internalname = "MARCARCOMOLIDA";
         lblNovamenssagem_Internalname = "NOVAMENSSAGEM";
         lblIrparalink_Internalname = "IRPARALINK";
         divTablecontentline_Internalname = "TABLECONTENTLINE";
         edtavNotificationlink_Internalname = "vNOTIFICATIONLINK";
         cmbavUsernotificationstatus_Internalname = "vUSERNOTIFICATIONSTATUS";
         edtavUsernotificationid_Internalname = "vUSERNOTIFICATIONID";
         tblUnnamedtablecontentfsgrid_Internalname = "UNNAMEDTABLECONTENTFSGRID";
         divTableline_Internalname = "TABLELINE";
         divGrid2_Internalname = "GRID2";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         lblIrparalink_Caption = "<i class=\"Icon24 fas fa-arrow-up-right-from-square\"></i>";
         lblNovamenssagem_Caption = "<h4><i style=\"margin-right:5px; font-size: 24px;\" class=\"fa-regular fa-envelope\"></i>Você tem uma nova mensagem</h4>";
         lblMarcarcomolida_Caption = "<i class=\"Icon24 far fa-eye\"></i>";
         edtavUsernotificationid_Jsonclick = "";
         cmbavUsernotificationstatus_Jsonclick = "";
         edtavNotificationlink_Jsonclick = "";
         lblIrparalink_Visible = 1;
         lblNovamenssagem_Caption = "<h4><i style=\"margin-right:5px; font-size: 24px;\" class=\"fa-regular fa-envelope\"></i>Você tem uma nova mensagem</h4>";
         subGrid_Backcolorstyle = 0;
         lblNonotifications_Visible = 1;
         subGrid_Flexdirection = "column";
         subGrid_Class = "FreeStyleGrid";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Visualizar todas notificações";
         edtavUsernotificationid_Visible = 1;
         cmbavUsernotificationstatus.Visible = 1;
         edtavNotificationlink_Visible = 1;
         subGrid_Rows = 50;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"edtavNotificationlink_Visible","ctrl":"vNOTIFICATIONLINK","prop":"Visible"},{"av":"cmbavUsernotificationstatus"},{"av":"edtavUsernotificationid_Visible","ctrl":"vUSERNOTIFICATIONID","prop":"Visible"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E140T2","iparms":[{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"lblNovamenssagem_Caption","ctrl":"NOVAMENSSAGEM","prop":"Caption"},{"av":"AV22NotificationLink","fld":"vNOTIFICATIONLINK","type":"svchar"},{"av":"AV24UserNotificationId","fld":"vUSERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"lblIrparalink_Visible","ctrl":"IRPARALINK","prop":"Visible"},{"av":"lblNonotifications_Visible","ctrl":"NONOTIFICATIONS","prop":"Visible"}]}""");
         setEventMetadata("'DOMARCARCOMOLIDA'","""{"handler":"E150T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV28Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"edtavNotificationlink_Visible","ctrl":"vNOTIFICATIONLINK","prop":"Visible"},{"av":"cmbavUsernotificationstatus"},{"av":"edtavUsernotificationid_Visible","ctrl":"vUSERNOTIFICATIONID","prop":"Visible"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV24UserNotificationId","fld":"vUSERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("'DOMARCARCOMOLIDA'",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("'DOIRPARALINK'","""{"handler":"E160T2","iparms":[{"av":"AV24UserNotificationId","fld":"vUSERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV22NotificationLink","fld":"vNOTIFICATIONLINK","type":"svchar"}]}""");
         setEventMetadata("'DOMARKALLASREAD'","""{"handler":"E110T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV28Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"edtavNotificationlink_Visible","ctrl":"vNOTIFICATIONLINK","prop":"Visible"},{"av":"cmbavUsernotificationstatus"},{"av":"edtavUsernotificationid_Visible","ctrl":"vUSERNOTIFICATIONID","prop":"Visible"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("'DOMARKALLASREAD'",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"edtavNotificationlink_Visible","ctrl":"vNOTIFICATIONLINK","prop":"Visible"},{"av":"cmbavUsernotificationstatus"},{"av":"edtavUsernotificationid_Visible","ctrl":"vUSERNOTIFICATIONID","prop":"Visible"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"edtavNotificationlink_Visible","ctrl":"vNOTIFICATIONLINK","prop":"Visible"},{"av":"cmbavUsernotificationstatus"},{"av":"edtavUsernotificationid_Visible","ctrl":"vUSERNOTIFICATIONID","prop":"Visible"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"edtavNotificationlink_Visible","ctrl":"vNOTIFICATIONLINK","prop":"Visible"},{"av":"cmbavUsernotificationstatus"},{"av":"edtavUsernotificationid_Visible","ctrl":"vUSERNOTIFICATIONID","prop":"Visible"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"edtavNotificationlink_Visible","ctrl":"vNOTIFICATIONLINK","prop":"Visible"},{"av":"cmbavUsernotificationstatus"},{"av":"edtavUsernotificationid_Visible","ctrl":"vUSERNOTIFICATIONID","prop":"Visible"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"subGrid_Recordcount","type":"int"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""}]}""");
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
         AV28Pgmname = "";
         A385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         A384NotificationType = "";
         A389UserNotificationStatus = "";
         A383NotificationMessage = "";
         A397NotificationLink = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnmarkallasread_Jsonclick = "";
         lblNonotifications_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV22NotificationLink = "";
         AV23UserNotificationStatus = "";
         GXCCtl = "";
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H000T2_A381NotificationId = new int[1] ;
         H000T2_n381NotificationId = new bool[] {false} ;
         H000T2_A388UserNotificationUserId = new short[1] ;
         H000T2_n388UserNotificationUserId = new bool[] {false} ;
         H000T2_A384NotificationType = new string[] {""} ;
         H000T2_n384NotificationType = new bool[] {false} ;
         H000T2_A389UserNotificationStatus = new string[] {""} ;
         H000T2_n389UserNotificationStatus = new bool[] {false} ;
         H000T2_A383NotificationMessage = new string[] {""} ;
         H000T2_n383NotificationMessage = new bool[] {false} ;
         H000T2_A397NotificationLink = new string[] {""} ;
         H000T2_n397NotificationLink = new bool[] {false} ;
         H000T2_A387UserNotificationId = new int[1] ;
         H000T2_A385NotificationCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H000T2_n385NotificationCreatedAt = new bool[] {false} ;
         GridRow = new GXWebRow();
         AV25UserNotification = new SdtUserNotification(context);
         H000T3_A389UserNotificationStatus = new string[] {""} ;
         H000T3_n389UserNotificationStatus = new bool[] {false} ;
         H000T3_A388UserNotificationUserId = new short[1] ;
         H000T3_n388UserNotificationUserId = new bool[] {false} ;
         H000T3_A387UserNotificationId = new int[1] ;
         AV13Session = context.GetSession();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         lblMarcarcomolida_Jsonclick = "";
         lblNovamenssagem_Jsonclick = "";
         lblIrparalink_Jsonclick = "";
         ROClassString = "";
         subGrid_Header = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_visualizeallnotifications__default(),
            new Object[][] {
                new Object[] {
               H000T2_A381NotificationId, H000T2_n381NotificationId, H000T2_A388UserNotificationUserId, H000T2_n388UserNotificationUserId, H000T2_A384NotificationType, H000T2_n384NotificationType, H000T2_A389UserNotificationStatus, H000T2_n389UserNotificationStatus, H000T2_A383NotificationMessage, H000T2_n383NotificationMessage,
               H000T2_A397NotificationLink, H000T2_n397NotificationLink, H000T2_A387UserNotificationId, H000T2_A385NotificationCreatedAt, H000T2_n385NotificationCreatedAt
               }
               , new Object[] {
               H000T3_A389UserNotificationStatus, H000T3_n389UserNotificationStatus, H000T3_A388UserNotificationUserId, H000T3_n388UserNotificationUserId, H000T3_A387UserNotificationId
               }
            }
         );
         AV28Pgmname = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         /* GeneXus formulas. */
         AV28Pgmname = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
      }

      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short A388UserNotificationUserId ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short AV26GXLvl36 ;
      private short subGrid_Backstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtavNotificationlink_Visible ;
      private int edtavUsernotificationid_Visible ;
      private int nRC_GXsfl_22 ;
      private int subGrid_Recordcount ;
      private int subGrid_Rows ;
      private int nGXsfl_22_idx=1 ;
      private int A387UserNotificationId ;
      private int lblNonotifications_Visible ;
      private int AV24UserNotificationId ;
      private int subGrid_Islastpage ;
      private int A381NotificationId ;
      private int lblIrparalink_Visible ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_22_idx="0001" ;
      private string edtavNotificationlink_Internalname ;
      private string cmbavUsernotificationstatus_Internalname ;
      private string edtavUsernotificationid_Internalname ;
      private string AV28Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string subGrid_Class ;
      private string subGrid_Flexdirection ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string TempTags ;
      private string bttBtnmarkallasread_Internalname ;
      private string bttBtnmarkallasread_Jsonclick ;
      private string lblNonotifications_Internalname ;
      private string lblNonotifications_Jsonclick ;
      private string divGrid2_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXCCtl ;
      private string lblNovamenssagem_Caption ;
      private string lblMarcarcomolida_Internalname ;
      private string lblNovamenssagem_Internalname ;
      private string lblIrparalink_Internalname ;
      private string sGXsfl_22_fel_idx="0001" ;
      private string subGrid_Linesclass ;
      private string divTableline_Internalname ;
      private string divTablecontentline_Internalname ;
      private string lblMarcarcomolida_Jsonclick ;
      private string lblNovamenssagem_Jsonclick ;
      private string lblIrparalink_Jsonclick ;
      private string tblUnnamedtablecontentfsgrid_Internalname ;
      private string ROClassString ;
      private string edtavNotificationlink_Jsonclick ;
      private string cmbavUsernotificationstatus_Jsonclick ;
      private string edtavUsernotificationid_Jsonclick ;
      private string subGrid_Header ;
      private string lblMarcarcomolida_Caption ;
      private string lblIrparalink_Caption ;
      private DateTime A385NotificationCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_22_Refreshing=false ;
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
      private bool gx_refresh_fired ;
      private bool n381NotificationId ;
      private string A384NotificationType ;
      private string A389UserNotificationStatus ;
      private string A383NotificationMessage ;
      private string A397NotificationLink ;
      private string AV22NotificationLink ;
      private string AV23UserNotificationStatus ;
      private IGxSession AV13Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavUsernotificationstatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private int[] H000T2_A381NotificationId ;
      private bool[] H000T2_n381NotificationId ;
      private short[] H000T2_A388UserNotificationUserId ;
      private bool[] H000T2_n388UserNotificationUserId ;
      private string[] H000T2_A384NotificationType ;
      private bool[] H000T2_n384NotificationType ;
      private string[] H000T2_A389UserNotificationStatus ;
      private bool[] H000T2_n389UserNotificationStatus ;
      private string[] H000T2_A383NotificationMessage ;
      private bool[] H000T2_n383NotificationMessage ;
      private string[] H000T2_A397NotificationLink ;
      private bool[] H000T2_n397NotificationLink ;
      private int[] H000T2_A387UserNotificationId ;
      private DateTime[] H000T2_A385NotificationCreatedAt ;
      private bool[] H000T2_n385NotificationCreatedAt ;
      private SdtUserNotification AV25UserNotification ;
      private string[] H000T3_A389UserNotificationStatus ;
      private bool[] H000T3_n389UserNotificationStatus ;
      private short[] H000T3_A388UserNotificationUserId ;
      private bool[] H000T3_n388UserNotificationUserId ;
      private int[] H000T3_A387UserNotificationId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_visualizeallnotifications__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000T2;
          prmH000T2 = new Object[] {
          new ParDef("AV6WWPContext__Userid",GXType.Int16,4,0)
          };
          Object[] prmH000T3;
          prmH000T3 = new Object[] {
          new ParDef("AV6WWPContext__Userid",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000T2", "SELECT T1.NotificationId, T1.UserNotificationUserId, T2.NotificationType, T1.UserNotificationStatus, T2.NotificationMessage, T2.NotificationLink, T1.UserNotificationId, T2.NotificationCreatedAt FROM (UserNotification T1 LEFT JOIN Notification T2 ON T2.NotificationId = T1.NotificationId) WHERE (T1.UserNotificationUserId = :AV6WWPContext__Userid) AND (T2.NotificationType = ( 'Internal')) AND (T1.UserNotificationStatus = ( 'Unread')) ORDER BY T2.NotificationCreatedAt DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000T2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000T3", "SELECT UserNotificationStatus, UserNotificationUserId, UserNotificationId FROM UserNotification WHERE (UserNotificationUserId = :AV6WWPContext__Userid) AND (UserNotificationStatus = ( 'Unread')) ORDER BY UserNotificationUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000T3,100, GxCacheFrequency.OFF ,true,false )
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
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
