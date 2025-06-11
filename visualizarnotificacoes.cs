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
   public class visualizarnotificacoes : GXDataArea
   {
      public visualizarnotificacoes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visualizarnotificacoes( IGxContext context )
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
         chkavVerlidas = new GXCheckbox();
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrFreegrid_newrow_invoke( )
      {
         nRC_GXsfl_30 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_30"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_30_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_30_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_30_idx = GetPar( "sGXsfl_30_idx");
         edtavNotificationlink_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavNotificationlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotificationlink_Visible), 5, 0), !bGXsfl_30_Refreshing);
         cmbavUsernotificationstatus.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, cmbavUsernotificationstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0), !bGXsfl_30_Refreshing);
         edtavUsernotificationid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavUsernotificationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsernotificationid_Visible), 5, 0), !bGXsfl_30_Refreshing);
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
         AssignProp("", false, edtavNotificationlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotificationlink_Visible), 5, 0), !bGXsfl_30_Refreshing);
         cmbavUsernotificationstatus.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, cmbavUsernotificationstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0), !bGXsfl_30_Refreshing);
         edtavUsernotificationid_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavUsernotificationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsernotificationid_Visible), 5, 0), !bGXsfl_30_Refreshing);
         A385NotificationCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "NotificationCreatedAt"));
         n385NotificationCreatedAt = false;
         A388UserNotificationUserId = (short)(Math.Round(NumberUtil.Val( GetPar( "UserNotificationUserId"), "."), 18, MidpointRounding.ToEven));
         n388UserNotificationUserId = false;
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5WWPContext);
         A384NotificationType = GetPar( "NotificationType");
         n384NotificationType = false;
         AV10VerLidas = StringUtil.StrToBool( GetPar( "VerLidas"));
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
         gxgrFreegrid_refresh( A385NotificationCreatedAt, A388UserNotificationUserId, AV5WWPContext, A384NotificationType, AV10VerLidas, A389UserNotificationStatus, A383NotificationMessage, A397NotificationLink, A387UserNotificationId) ;
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
         PA7P2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7P2( ) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("visualizarnotificacoes") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV5WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV5WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV5WWPContext, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_30", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_30), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "NOTIFICATIONCREATEDAT", context.localUtil.TToC( A385NotificationCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "USERNOTIFICATIONUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A388UserNotificationUserId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV5WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV5WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV5WWPContext, context));
         GxWebStd.gx_hidden_field( context, "NOTIFICATIONTYPE", A384NotificationType);
         GxWebStd.gx_hidden_field( context, "USERNOTIFICATIONSTATUS", A389UserNotificationStatus);
         GxWebStd.gx_hidden_field( context, "NOTIFICATIONMESSAGE", A383NotificationMessage);
         GxWebStd.gx_hidden_field( context, "NOTIFICATIONLINK", A397NotificationLink);
         GxWebStd.gx_hidden_field( context, "USERNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A387UserNotificationId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "subFreegrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreegrid_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "FREEGRID_Class", StringUtil.RTrim( subFreegrid_Class));
         GxWebStd.gx_hidden_field( context, "FREEGRID_Flexdirection", StringUtil.RTrim( subFreegrid_Flexdirection));
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
            WE7P2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7P2( ) ;
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
         return formatLink("visualizarnotificacoes")  ;
      }

      public override string GetPgmname( )
      {
         return "VisualizarNotificacoes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Todas notificações" ;
      }

      protected void WB7P0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnmarkallasread_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(30), 2, 0)+","+"null"+");", "Marcar tudo como lido", bttBtnmarkallasread_Jsonclick, 5, "Marcar tudo como lido", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOMARKALLASREAD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_VisualizarNotificacoes.htm");
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
            GxWebStd.gx_label_ctrl( context, lblNonotifications_Internalname, "Você não recebeu nehuma notificação ainda", "", "", lblNonotifications_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleWWP", 0, "", lblNonotifications_Visible, 1, 0, 0, "HLP_VisualizarNotificacoes.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavVerlidas_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavVerlidas_Internalname, "Ver lidas", "col-sm-6 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-6 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_30_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavVerlidas_Internalname, StringUtil.BoolToStr( AV10VerLidas), "", "Ver lidas", 1, chkavVerlidas.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(27, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,27);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /*  Grid Control  */
            FreegridContainer.SetIsFreestyle(true);
            FreegridContainer.SetWrapped(nGXWrapped);
            StartGridControl30( ) ;
         }
         if ( wbEnd == 30 )
         {
            wbEnd = 0;
            nRC_GXsfl_30 = (int)(nGXsfl_30_idx-1);
            if ( FreegridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"FreegridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freegrid", FreegridContainer, subFreegrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FreegridContainerData", FreegridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FreegridContainerData"+"V", FreegridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FreegridContainerData"+"V"+"\" value='"+FreegridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 30 )
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
                  context.WriteHtmlText( "<div id=\""+"FreegridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Freegrid", FreegridContainer, subFreegrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FreegridContainerData", FreegridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FreegridContainerData"+"V", FreegridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FreegridContainerData"+"V"+"\" value='"+FreegridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START7P2( )
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
         Form.Meta.addItem("description", "Todas notificações", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7P0( ) ;
      }

      protected void WS7P2( )
      {
         START7P2( ) ;
         EVT7P2( ) ;
      }

      protected void EVT7P2( )
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
                              E117P2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "FREEGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DOIRPARALINK'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'DOMARCARCOMOLIDA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'DOMARCARCOMOLIDA'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DOIRPARALINK'") == 0 ) )
                           {
                              nGXsfl_30_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
                              SubsflControlProps_302( ) ;
                              AV7NotificationLink = cgiGet( edtavNotificationlink_Internalname);
                              AssignAttri("", false, edtavNotificationlink_Internalname, AV7NotificationLink);
                              cmbavUsernotificationstatus.Name = cmbavUsernotificationstatus_Internalname;
                              cmbavUsernotificationstatus.CurrentValue = cgiGet( cmbavUsernotificationstatus_Internalname);
                              AV9UserNotificationStatus = cgiGet( cmbavUsernotificationstatus_Internalname);
                              AssignAttri("", false, cmbavUsernotificationstatus_Internalname, AV9UserNotificationStatus);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavUsernotificationid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavUsernotificationid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vUSERNOTIFICATIONID");
                                 GX_FocusControl = edtavUsernotificationid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV8UserNotificationId = 0;
                                 AssignAttri("", false, edtavUsernotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV8UserNotificationId), 9, 0));
                              }
                              else
                              {
                                 AV8UserNotificationId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavUsernotificationid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavUsernotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV8UserNotificationId), 9, 0));
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
                                    E127P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREEGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Freegrid.Load */
                                    E137P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOIRPARALINK'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoIrParaLink' */
                                    E147P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOMARCARCOMOLIDA'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMarcarComoLida' */
                                    E157P2 ();
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

      protected void WE7P2( )
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

      protected void PA7P2( )
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
               GX_FocusControl = chkavVerlidas_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_302( ) ;
         while ( nGXsfl_30_idx <= nRC_GXsfl_30 )
         {
            sendrow_302( ) ;
            nGXsfl_30_idx = ((subFreegrid_Islastpage==1)&&(nGXsfl_30_idx+1>subFreegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_30_idx+1);
            sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
            SubsflControlProps_302( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FreegridContainer)) ;
         /* End function gxnrFreegrid_newrow */
      }

      protected void gxgrFreegrid_refresh( DateTime A385NotificationCreatedAt ,
                                           short A388UserNotificationUserId ,
                                           GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV5WWPContext ,
                                           string A384NotificationType ,
                                           bool AV10VerLidas ,
                                           string A389UserNotificationStatus ,
                                           string A383NotificationMessage ,
                                           string A397NotificationLink ,
                                           int A387UserNotificationId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREEGRID_nCurrentRecord = 0;
         RF7P2( ) ;
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
         AV10VerLidas = StringUtil.StrToBool( StringUtil.BoolToStr( AV10VerLidas));
         AssignAttri("", false, "AV10VerLidas", AV10VerLidas);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FreegridContainer.ClearRows();
         }
         wbStart = 30;
         nGXsfl_30_idx = 1;
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         bGXsfl_30_Refreshing = true;
         FreegridContainer.AddObjectProperty("GridName", "Freegrid");
         FreegridContainer.AddObjectProperty("CmpContext", "");
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
            GxWebStd.gx_hidden_field( context, "FREEGRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREEGRID_nFirstRecordOnPage), 15, 0, ".", "")));
            FreegridContainer.AddObjectProperty("FREEGRID_nFirstRecordOnPage", FREEGRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_302( ) ;
            /* Execute user event: Freegrid.Load */
            E137P2 ();
            wbEnd = 30;
            WB7P0( ) ;
         }
         bGXsfl_30_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7P2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV5WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV5WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV5WWPContext, context));
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

      protected void STRUP7P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E127P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_30 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_30"), ",", "."), 18, MidpointRounding.ToEven));
            subFreegrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subFreegrid_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            subFreegrid_Class = cgiGet( "FREEGRID_Class");
            subFreegrid_Flexdirection = cgiGet( "FREEGRID_Flexdirection");
            /* Read variables values. */
            AV10VerLidas = StringUtil.StrToBool( cgiGet( chkavVerlidas_Internalname));
            AssignAttri("", false, "AV10VerLidas", AV10VerLidas);
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
         E127P2 ();
         if (returnInSub) return;
      }

      protected void E127P2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV5WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV5WWPContext = GXt_SdtWWPContext1;
         edtavNotificationlink_Visible = 0;
         AssignProp("", false, edtavNotificationlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNotificationlink_Visible), 5, 0), !bGXsfl_30_Refreshing);
         cmbavUsernotificationstatus.Visible = 0;
         AssignProp("", false, cmbavUsernotificationstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavUsernotificationstatus.Visible), 5, 0), !bGXsfl_30_Refreshing);
         edtavUsernotificationid_Visible = 0;
         AssignProp("", false, edtavUsernotificationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsernotificationid_Visible), 5, 0), !bGXsfl_30_Refreshing);
      }

      private void E137P2( )
      {
         /* Freegrid_Load Routine */
         returnInSub = false;
         AV11GXLvl18 = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10VerLidas ,
                                              A389UserNotificationStatus ,
                                              A388UserNotificationUserId ,
                                              AV5WWPContext.gxTpr_Userid ,
                                              A384NotificationType } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H007P2 */
         pr_default.execute(0, new Object[] {AV5WWPContext.gxTpr_Userid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A381NotificationId = H007P2_A381NotificationId[0];
            n381NotificationId = H007P2_n381NotificationId[0];
            A388UserNotificationUserId = H007P2_A388UserNotificationUserId[0];
            n388UserNotificationUserId = H007P2_n388UserNotificationUserId[0];
            A384NotificationType = H007P2_A384NotificationType[0];
            n384NotificationType = H007P2_n384NotificationType[0];
            A389UserNotificationStatus = H007P2_A389UserNotificationStatus[0];
            n389UserNotificationStatus = H007P2_n389UserNotificationStatus[0];
            A383NotificationMessage = H007P2_A383NotificationMessage[0];
            n383NotificationMessage = H007P2_n383NotificationMessage[0];
            A397NotificationLink = H007P2_A397NotificationLink[0];
            n397NotificationLink = H007P2_n397NotificationLink[0];
            A387UserNotificationId = H007P2_A387UserNotificationId[0];
            A385NotificationCreatedAt = H007P2_A385NotificationCreatedAt[0];
            n385NotificationCreatedAt = H007P2_n385NotificationCreatedAt[0];
            A384NotificationType = H007P2_A384NotificationType[0];
            n384NotificationType = H007P2_n384NotificationType[0];
            A383NotificationMessage = H007P2_A383NotificationMessage[0];
            n383NotificationMessage = H007P2_n383NotificationMessage[0];
            A397NotificationLink = H007P2_A397NotificationLink[0];
            n397NotificationLink = H007P2_n397NotificationLink[0];
            A385NotificationCreatedAt = H007P2_A385NotificationCreatedAt[0];
            n385NotificationCreatedAt = H007P2_n385NotificationCreatedAt[0];
            AV11GXLvl18 = 1;
            lblNovamenssagem_Caption = StringUtil.Format( "<h4><i style=\"margin-right:5px; font-size: 24px;\" class=\"fa-regular fa-envelope\"></i>%1</h4>", A383NotificationMessage, "", "", "", "", "", "", "", "");
            AV7NotificationLink = A397NotificationLink;
            AssignAttri("", false, edtavNotificationlink_Internalname, AV7NotificationLink);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7NotificationLink)) && ( StringUtil.StrCmp(A389UserNotificationStatus, "Unread") == 0 ) )
            {
               new prreadnotification(context ).execute(  A387UserNotificationId) ;
            }
            AV8UserNotificationId = A387UserNotificationId;
            AssignAttri("", false, edtavUsernotificationid_Internalname, StringUtil.LTrimStr( (decimal)(AV8UserNotificationId), 9, 0));
            if ( StringUtil.StrCmp(AV7NotificationLink, "") != 0 )
            {
               lblIrparalink_Visible = 1;
            }
            else
            {
               lblIrparalink_Visible = 0;
            }
            if ( StringUtil.StrCmp(A389UserNotificationStatus, "Read") == 0 )
            {
               lblLida_Visible = 1;
            }
            else
            {
               lblLida_Visible = 0;
            }
            if ( StringUtil.StrCmp(A389UserNotificationStatus, "Unread") == 0 )
            {
               lblMarcarcomolida_Visible = 1;
            }
            else
            {
               lblMarcarcomolida_Visible = 0;
            }
            lblNonotifications_Visible = 0;
            AssignProp("", false, lblNonotifications_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNonotifications_Visible), 5, 0), true);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 30;
            }
            sendrow_302( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_30_Refreshing )
            {
               DoAjaxLoad(30, FreegridRow);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV11GXLvl18 == 0 )
         {
            lblNonotifications_Visible = 1;
            AssignProp("", false, lblNonotifications_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNonotifications_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E147P2( )
      {
         /* 'DoIrParaLink' Routine */
         returnInSub = false;
         AV6UserNotification.Load(AV8UserNotificationId);
         AV6UserNotification.gxTpr_Usernotificationstatus = "Read";
         AV6UserNotification.Save();
         context.CommitDataStores("visualizarnotificacoes",pr_default);
         CallWebObject(formatLink(AV7NotificationLink) );
         context.wjLocDisableFrm = 0;
      }

      protected void E157P2( )
      {
         /* 'DoMarcarComoLida' Routine */
         returnInSub = false;
         AV6UserNotification.Load(AV8UserNotificationId);
         AV6UserNotification.gxTpr_Usernotificationstatus = "Read";
         AV6UserNotification.Save();
         context.CommitDataStores("visualizarnotificacoes",pr_default);
         gxgrFreegrid_refresh( A385NotificationCreatedAt, A388UserNotificationUserId, AV5WWPContext, A384NotificationType, AV10VerLidas, A389UserNotificationStatus, A383NotificationMessage, A397NotificationLink, A387UserNotificationId) ;
         this.executeExternalObjectMethod("", false, "GlobalEvents", "Master_RefreshNotifications", new Object[] {}, true);
      }

      protected void E117P2( )
      {
         /* 'DoMarkAllAsRead' Routine */
         returnInSub = false;
         /* Using cursor H007P3 */
         pr_default.execute(1, new Object[] {AV5WWPContext.gxTpr_Userid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A389UserNotificationStatus = H007P3_A389UserNotificationStatus[0];
            n389UserNotificationStatus = H007P3_n389UserNotificationStatus[0];
            A388UserNotificationUserId = H007P3_A388UserNotificationUserId[0];
            n388UserNotificationUserId = H007P3_n388UserNotificationUserId[0];
            A387UserNotificationId = H007P3_A387UserNotificationId[0];
            AV6UserNotification = new SdtUserNotification(context);
            AV6UserNotification.Load(A387UserNotificationId);
            AV6UserNotification.gxTpr_Usernotificationstatus = "Read";
            AV6UserNotification.Save();
            pr_default.readNext(1);
         }
         pr_default.close(1);
         context.CommitDataStores("visualizarnotificacoes",pr_default);
         this.executeExternalObjectMethod("", false, "GlobalEvents", "Master_RefreshNotifications", new Object[] {}, true);
         gxgrFreegrid_refresh( A385NotificationCreatedAt, A388UserNotificationUserId, AV5WWPContext, A384NotificationType, AV10VerLidas, A389UserNotificationStatus, A383NotificationMessage, A397NotificationLink, A387UserNotificationId) ;
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
         PA7P2( ) ;
         WS7P2( ) ;
         WE7P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019264839", true, true);
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
            context.AddJavascriptSource("visualizarnotificacoes.js", "?202561019264839", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_302( )
      {
         lblLida_Internalname = "LIDA_"+sGXsfl_30_idx;
         lblMarcarcomolida_Internalname = "MARCARCOMOLIDA_"+sGXsfl_30_idx;
         lblNovamenssagem_Internalname = "NOVAMENSSAGEM_"+sGXsfl_30_idx;
         lblIrparalink_Internalname = "IRPARALINK_"+sGXsfl_30_idx;
         edtavNotificationlink_Internalname = "vNOTIFICATIONLINK_"+sGXsfl_30_idx;
         cmbavUsernotificationstatus_Internalname = "vUSERNOTIFICATIONSTATUS_"+sGXsfl_30_idx;
         edtavUsernotificationid_Internalname = "vUSERNOTIFICATIONID_"+sGXsfl_30_idx;
      }

      protected void SubsflControlProps_fel_302( )
      {
         lblLida_Internalname = "LIDA_"+sGXsfl_30_fel_idx;
         lblMarcarcomolida_Internalname = "MARCARCOMOLIDA_"+sGXsfl_30_fel_idx;
         lblNovamenssagem_Internalname = "NOVAMENSSAGEM_"+sGXsfl_30_fel_idx;
         lblIrparalink_Internalname = "IRPARALINK_"+sGXsfl_30_fel_idx;
         edtavNotificationlink_Internalname = "vNOTIFICATIONLINK_"+sGXsfl_30_fel_idx;
         cmbavUsernotificationstatus_Internalname = "vUSERNOTIFICATIONSTATUS_"+sGXsfl_30_fel_idx;
         edtavUsernotificationid_Internalname = "vUSERNOTIFICATIONID_"+sGXsfl_30_fel_idx;
      }

      protected void sendrow_302( )
      {
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         WB7P0( ) ;
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
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFreegridlayouttable_Internalname+"_"+sGXsfl_30_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"NotificationCardTable",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
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
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablecontentline_Internalname+"_"+sGXsfl_30_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable1_Internalname+"_"+sGXsfl_30_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Text block */
         FreegridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblLida_Internalname,(string)"<i class=\"fas fa-check\"></i>",(string)"",(string)"",(string)lblLida_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+"e167p2_client"+"'",(string)"",(string)"TextBlock",(short)7,(string)"",(int)lblLida_Visible,(short)1,(short)0,(short)1});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         FreegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Div Control */
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Text block */
         FreegridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblMarcarcomolida_Internalname,(string)"<i class=\"Icon24 far fa-eye\"></i>",(string)"",(string)"",(string)lblMarcarcomolida_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'DOMARCARCOMOLIDA\\'."+sGXsfl_30_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)"",(int)lblMarcarcomolida_Visible,(short)1,(short)0,(short)1});
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
         FreegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-9",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         /* Text block */
         FreegridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNovamenssagem_Internalname,(string)lblNovamenssagem_Caption,(string)"",(string)"",(string)lblNovamenssagem_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
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
         FreegridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblIrparalink_Internalname,(string)"<i class=\"Icon24 fas fa-arrow-up-right-from-square\"></i>",(string)"",(string)"",(string)lblIrparalink_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'DOIRPARALINK\\'."+sGXsfl_30_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)"",(int)lblIrparalink_Visible,(short)1,(short)0,(short)1});
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
         FreegridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfreegrid_Internalname+"_"+sGXsfl_30_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_30_idx + "',30)\"";
         ROClassString = "Attribute";
         FreegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationlink_Internalname,(string)AV7NotificationLink,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationlink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavNotificationlink_Visible,(short)1,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)1000,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_30_idx + "',30)\"";
         if ( ( cmbavUsernotificationstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vUSERNOTIFICATIONSTATUS_" + sGXsfl_30_idx;
            cmbavUsernotificationstatus.Name = GXCCtl;
            cmbavUsernotificationstatus.WebTags = "";
            cmbavUsernotificationstatus.addItem("Unread", "Unread", 0);
            cmbavUsernotificationstatus.addItem("Read", "Read", 0);
            if ( cmbavUsernotificationstatus.ItemCount > 0 )
            {
               AV9UserNotificationStatus = cmbavUsernotificationstatus.getValidValue(AV9UserNotificationStatus);
               AssignAttri("", false, cmbavUsernotificationstatus_Internalname, AV9UserNotificationStatus);
            }
         }
         /* ComboBox */
         FreegridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavUsernotificationstatus,(string)cmbavUsernotificationstatus_Internalname,StringUtil.RTrim( AV9UserNotificationStatus),(short)1,(string)cmbavUsernotificationstatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",cmbavUsernotificationstatus.Visible,(short)1,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"",(bool)true,(short)0});
         FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FreegridRow.AddRenderProperties(FreegridColumn);
         cmbavUsernotificationstatus.CurrentValue = StringUtil.RTrim( AV9UserNotificationStatus);
         AssignProp("", false, cmbavUsernotificationstatus_Internalname, "Values", (string)(cmbavUsernotificationstatus.ToJavascriptSource()), !bGXsfl_30_Refreshing);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_30_idx + "',30)\"";
         ROClassString = "Attribute";
         FreegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsernotificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8UserNotificationId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8UserNotificationId), "ZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsernotificationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavUsernotificationid_Visible,(short)1,(short)0,(string)"text",(string)"1",(short)9,(string)"chr",(short)1,(string)"row",(short)9,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
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
         send_integrity_lvl_hashes7P2( ) ;
         /* End of Columns property logic. */
         FreegridContainer.AddRow(FreegridRow);
         nGXsfl_30_idx = ((subFreegrid_Islastpage==1)&&(nGXsfl_30_idx+1>subFreegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_30_idx+1);
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         /* End function sendrow_302 */
      }

      protected void init_web_controls( )
      {
         chkavVerlidas.Name = "vVERLIDAS";
         chkavVerlidas.WebTags = "";
         chkavVerlidas.Caption = "Ver lidas";
         AssignProp("", false, chkavVerlidas_Internalname, "TitleCaption", chkavVerlidas.Caption, true);
         chkavVerlidas.CheckedValue = "false";
         AV10VerLidas = StringUtil.StrToBool( StringUtil.BoolToStr( AV10VerLidas));
         AssignAttri("", false, "AV10VerLidas", AV10VerLidas);
         GXCCtl = "vUSERNOTIFICATIONSTATUS_" + sGXsfl_30_idx;
         cmbavUsernotificationstatus.Name = GXCCtl;
         cmbavUsernotificationstatus.WebTags = "";
         cmbavUsernotificationstatus.addItem("Unread", "Unread", 0);
         cmbavUsernotificationstatus.addItem("Read", "Read", 0);
         if ( cmbavUsernotificationstatus.ItemCount > 0 )
         {
            AV9UserNotificationStatus = cmbavUsernotificationstatus.getValidValue(AV9UserNotificationStatus);
            AssignAttri("", false, cmbavUsernotificationstatus_Internalname, AV9UserNotificationStatus);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl30( )
      {
         if ( FreegridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"FreegridContainer"+"DivS\" data-gxgridid=\"30\">") ;
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
            FreegridContainer.AddObjectProperty("CmpContext", "");
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
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridContainer.AddColumnProperties(FreegridColumn);
            FreegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FreegridColumn.AddObjectProperty("Value", lblLida_Caption);
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
            FreegridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV7NotificationLink));
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
            FreegridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV9UserNotificationStatus));
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
            FreegridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8UserNotificationId), 9, 0, ".", ""))));
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
         bttBtnmarkallasread_Internalname = "BTNMARKALLASREAD";
         divTableheader_Internalname = "TABLEHEADER";
         lblNonotifications_Internalname = "NONOTIFICATIONS";
         chkavVerlidas_Internalname = "vVERLIDAS";
         lblLida_Internalname = "LIDA";
         lblMarcarcomolida_Internalname = "MARCARCOMOLIDA";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         lblNovamenssagem_Internalname = "NOVAMENSSAGEM";
         lblIrparalink_Internalname = "IRPARALINK";
         divTablecontentline_Internalname = "TABLECONTENTLINE";
         edtavNotificationlink_Internalname = "vNOTIFICATIONLINK";
         cmbavUsernotificationstatus_Internalname = "vUSERNOTIFICATIONSTATUS";
         edtavUsernotificationid_Internalname = "vUSERNOTIFICATIONID";
         tblUnnamedtablecontentfsfreegrid_Internalname = "UNNAMEDTABLECONTENTFSFREEGRID";
         divFreegridlayouttable_Internalname = "FREEGRIDLAYOUTTABLE";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subFreegrid_Internalname = "FREEGRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subFreegrid_Allowcollapsing = 0;
         lblIrparalink_Caption = "<i class=\"Icon24 fas fa-arrow-up-right-from-square\"></i>";
         lblNovamenssagem_Caption = "<h4><i style=\"margin-right:5px; font-size: 24px;\" class=\"fa-regular fa-envelope\"></i>Você tem uma nova mensagem</h4>";
         lblMarcarcomolida_Caption = "<i class=\"Icon24 far fa-eye\"></i>";
         lblLida_Caption = "<i class=\"fas fa-check\"></i>";
         chkavVerlidas.Caption = "Ver lidas";
         edtavUsernotificationid_Jsonclick = "";
         cmbavUsernotificationstatus_Jsonclick = "";
         edtavNotificationlink_Jsonclick = "";
         lblIrparalink_Visible = 1;
         lblNovamenssagem_Caption = "<h4><i style=\"margin-right:5px; font-size: 24px;\" class=\"fa-regular fa-envelope\"></i>Você tem uma nova mensagem</h4>";
         lblMarcarcomolida_Visible = 1;
         lblLida_Visible = 1;
         subFreegrid_Backcolorstyle = 0;
         chkavVerlidas.Enabled = 1;
         lblNonotifications_Visible = 1;
         subFreegrid_Flexdirection = "column";
         subFreegrid_Class = "FreeStyleGrid";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Todas notificações";
         edtavUsernotificationid_Visible = 1;
         cmbavUsernotificationstatus.Visible = 1;
         edtavNotificationlink_Visible = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"edtavNotificationlink_Visible","ctrl":"vNOTIFICATIONLINK","prop":"Visible"},{"av":"cmbavUsernotificationstatus"},{"av":"edtavUsernotificationid_Visible","ctrl":"vUSERNOTIFICATIONID","prop":"Visible"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV10VerLidas","fld":"vVERLIDAS","type":"boolean"},{"av":"AV5WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("FREEGRID.LOAD","""{"handler":"E137P2","iparms":[{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"AV5WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"AV10VerLidas","fld":"vVERLIDAS","type":"boolean"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("FREEGRID.LOAD",""","oparms":[{"av":"lblNovamenssagem_Caption","ctrl":"NOVAMENSSAGEM","prop":"Caption"},{"av":"AV7NotificationLink","fld":"vNOTIFICATIONLINK","type":"svchar"},{"av":"AV8UserNotificationId","fld":"vUSERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"lblIrparalink_Visible","ctrl":"IRPARALINK","prop":"Visible"},{"av":"lblLida_Visible","ctrl":"LIDA","prop":"Visible"},{"av":"lblMarcarcomolida_Visible","ctrl":"MARCARCOMOLIDA","prop":"Visible"},{"av":"lblNonotifications_Visible","ctrl":"NONOTIFICATIONS","prop":"Visible"}]}""");
         setEventMetadata("'DOIRPARALINK'","""{"handler":"E147P2","iparms":[{"av":"AV8UserNotificationId","fld":"vUSERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV7NotificationLink","fld":"vNOTIFICATIONLINK","type":"svchar"}]}""");
         setEventMetadata("'DOLIDA'","""{"handler":"E167P2","iparms":[]}""");
         setEventMetadata("'DOMARCARCOMOLIDA'","""{"handler":"E157P2","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"edtavNotificationlink_Visible","ctrl":"vNOTIFICATIONLINK","prop":"Visible"},{"av":"cmbavUsernotificationstatus"},{"av":"edtavUsernotificationid_Visible","ctrl":"vUSERNOTIFICATIONID","prop":"Visible"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"AV5WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"AV10VerLidas","fld":"vVERLIDAS","type":"boolean"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV8UserNotificationId","fld":"vUSERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("'DOMARKALLASREAD'","""{"handler":"E117P2","iparms":[{"av":"FREEGRID_nFirstRecordOnPage","type":"int"},{"av":"FREEGRID_nEOF","type":"int"},{"av":"edtavNotificationlink_Visible","ctrl":"vNOTIFICATIONLINK","prop":"Visible"},{"av":"cmbavUsernotificationstatus"},{"av":"edtavUsernotificationid_Visible","ctrl":"vUSERNOTIFICATIONID","prop":"Visible"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","type":"int"},{"av":"AV5WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"AV10VerLidas","fld":"vVERLIDAS","type":"boolean"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"}]}""");
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
         A385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
         AV5WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
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
         FreegridContainer = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV7NotificationLink = "";
         AV9UserNotificationStatus = "";
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H007P2_A381NotificationId = new int[1] ;
         H007P2_n381NotificationId = new bool[] {false} ;
         H007P2_A388UserNotificationUserId = new short[1] ;
         H007P2_n388UserNotificationUserId = new bool[] {false} ;
         H007P2_A384NotificationType = new string[] {""} ;
         H007P2_n384NotificationType = new bool[] {false} ;
         H007P2_A389UserNotificationStatus = new string[] {""} ;
         H007P2_n389UserNotificationStatus = new bool[] {false} ;
         H007P2_A383NotificationMessage = new string[] {""} ;
         H007P2_n383NotificationMessage = new bool[] {false} ;
         H007P2_A397NotificationLink = new string[] {""} ;
         H007P2_n397NotificationLink = new bool[] {false} ;
         H007P2_A387UserNotificationId = new int[1] ;
         H007P2_A385NotificationCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H007P2_n385NotificationCreatedAt = new bool[] {false} ;
         FreegridRow = new GXWebRow();
         AV6UserNotification = new SdtUserNotification(context);
         H007P3_A389UserNotificationStatus = new string[] {""} ;
         H007P3_n389UserNotificationStatus = new bool[] {false} ;
         H007P3_A388UserNotificationUserId = new short[1] ;
         H007P3_n388UserNotificationUserId = new bool[] {false} ;
         H007P3_A387UserNotificationId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subFreegrid_Linesclass = "";
         FreegridColumn = new GXWebColumn();
         lblLida_Jsonclick = "";
         lblMarcarcomolida_Jsonclick = "";
         lblNovamenssagem_Jsonclick = "";
         lblIrparalink_Jsonclick = "";
         ROClassString = "";
         GXCCtl = "";
         subFreegrid_Header = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.visualizarnotificacoes__default(),
            new Object[][] {
                new Object[] {
               H007P2_A381NotificationId, H007P2_n381NotificationId, H007P2_A388UserNotificationUserId, H007P2_n388UserNotificationUserId, H007P2_A384NotificationType, H007P2_n384NotificationType, H007P2_A389UserNotificationStatus, H007P2_n389UserNotificationStatus, H007P2_A383NotificationMessage, H007P2_n383NotificationMessage,
               H007P2_A397NotificationLink, H007P2_n397NotificationLink, H007P2_A387UserNotificationId, H007P2_A385NotificationCreatedAt, H007P2_n385NotificationCreatedAt
               }
               , new Object[] {
               H007P3_A389UserNotificationStatus, H007P3_n389UserNotificationStatus, H007P3_A388UserNotificationUserId, H007P3_n388UserNotificationUserId, H007P3_A387UserNotificationId
               }
            }
         );
         /* GeneXus formulas. */
      }

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
      private short subFreegrid_Backcolorstyle ;
      private short AV11GXLvl18 ;
      private short AV5WWPContext_gxTpr_Userid ;
      private short FREEGRID_nEOF ;
      private short subFreegrid_Backstyle ;
      private short subFreegrid_Allowselection ;
      private short subFreegrid_Allowhovering ;
      private short subFreegrid_Allowcollapsing ;
      private short subFreegrid_Collapsed ;
      private int edtavNotificationlink_Visible ;
      private int edtavUsernotificationid_Visible ;
      private int nRC_GXsfl_30 ;
      private int subFreegrid_Recordcount ;
      private int nGXsfl_30_idx=1 ;
      private int A387UserNotificationId ;
      private int lblNonotifications_Visible ;
      private int AV8UserNotificationId ;
      private int subFreegrid_Islastpage ;
      private int A381NotificationId ;
      private int lblIrparalink_Visible ;
      private int lblLida_Visible ;
      private int lblMarcarcomolida_Visible ;
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
      private string sGXsfl_30_idx="0001" ;
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
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string TempTags ;
      private string bttBtnmarkallasread_Internalname ;
      private string bttBtnmarkallasread_Jsonclick ;
      private string lblNonotifications_Internalname ;
      private string lblNonotifications_Jsonclick ;
      private string chkavVerlidas_Internalname ;
      private string sStyleString ;
      private string subFreegrid_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string lblNovamenssagem_Caption ;
      private string lblLida_Internalname ;
      private string lblMarcarcomolida_Internalname ;
      private string lblNovamenssagem_Internalname ;
      private string lblIrparalink_Internalname ;
      private string sGXsfl_30_fel_idx="0001" ;
      private string subFreegrid_Linesclass ;
      private string divFreegridlayouttable_Internalname ;
      private string divTablecontentline_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string lblLida_Jsonclick ;
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
      private string lblLida_Caption ;
      private string lblMarcarcomolida_Caption ;
      private string lblIrparalink_Caption ;
      private DateTime A385NotificationCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_30_Refreshing=false ;
      private bool n385NotificationCreatedAt ;
      private bool n388UserNotificationUserId ;
      private bool n384NotificationType ;
      private bool AV10VerLidas ;
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
      private string AV7NotificationLink ;
      private string AV9UserNotificationStatus ;
      private GXWebGrid FreegridContainer ;
      private GXWebRow FreegridRow ;
      private GXWebColumn FreegridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavVerlidas ;
      private GXCombobox cmbavUsernotificationstatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV5WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private int[] H007P2_A381NotificationId ;
      private bool[] H007P2_n381NotificationId ;
      private short[] H007P2_A388UserNotificationUserId ;
      private bool[] H007P2_n388UserNotificationUserId ;
      private string[] H007P2_A384NotificationType ;
      private bool[] H007P2_n384NotificationType ;
      private string[] H007P2_A389UserNotificationStatus ;
      private bool[] H007P2_n389UserNotificationStatus ;
      private string[] H007P2_A383NotificationMessage ;
      private bool[] H007P2_n383NotificationMessage ;
      private string[] H007P2_A397NotificationLink ;
      private bool[] H007P2_n397NotificationLink ;
      private int[] H007P2_A387UserNotificationId ;
      private DateTime[] H007P2_A385NotificationCreatedAt ;
      private bool[] H007P2_n385NotificationCreatedAt ;
      private SdtUserNotification AV6UserNotification ;
      private string[] H007P3_A389UserNotificationStatus ;
      private bool[] H007P3_n389UserNotificationStatus ;
      private short[] H007P3_A388UserNotificationUserId ;
      private bool[] H007P3_n388UserNotificationUserId ;
      private int[] H007P3_A387UserNotificationId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class visualizarnotificacoes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007P2( IGxContext context ,
                                             bool AV10VerLidas ,
                                             string A389UserNotificationStatus ,
                                             short A388UserNotificationUserId ,
                                             short AV5WWPContext_gxTpr_Userid ,
                                             string A384NotificationType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.NotificationId, T1.UserNotificationUserId, T2.NotificationType, T1.UserNotificationStatus, T2.NotificationMessage, T2.NotificationLink, T1.UserNotificationId, T2.NotificationCreatedAt FROM (UserNotification T1 LEFT JOIN Notification T2 ON T2.NotificationId = T1.NotificationId)";
         AddWhere(sWhereString, "(T1.UserNotificationUserId = :AV5WWPContext__Userid)");
         AddWhere(sWhereString, "(T2.NotificationType = ( 'Internal'))");
         if ( ! AV10VerLidas )
         {
            AddWhere(sWhereString, "(T1.UserNotificationStatus = ( 'Unread'))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.NotificationCreatedAt DESC";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H007P2(context, (bool)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH007P3;
          prmH007P3 = new Object[] {
          new ParDef("AV5WWPContext__Userid",GXType.Int16,4,0)
          };
          Object[] prmH007P2;
          prmH007P2 = new Object[] {
          new ParDef("AV5WWPContext__Userid",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007P2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007P3", "SELECT UserNotificationStatus, UserNotificationUserId, UserNotificationId FROM UserNotification WHERE (UserNotificationUserId = :AV5WWPContext__Userid) AND (UserNotificationStatus = ( 'Unread')) ORDER BY UserNotificationUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007P3,100, GxCacheFrequency.OFF ,true,false )
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
