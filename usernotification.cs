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
   public class usernotification : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A381NotificationId = (int)(Math.Round(NumberUtil.Val( GetPar( "NotificationId"), "."), 18, MidpointRounding.ToEven));
            n381NotificationId = false;
            AssignAttri("", false, "A381NotificationId", ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A381NotificationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A388UserNotificationUserId = (short)(Math.Round(NumberUtil.Val( GetPar( "UserNotificationUserId"), "."), 18, MidpointRounding.ToEven));
            n388UserNotificationUserId = false;
            AssignAttri("", false, "A388UserNotificationUserId", ((0==A388UserNotificationUserId)&&IsIns( )||n388UserNotificationUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A388UserNotificationUserId), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A388UserNotificationUserId) ;
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
            }
         }
         Form.Meta.addItem("description", "User Notification", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUserNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public usernotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usernotification( IGxContext context )
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
         cmbUserNotificationStatus = new GXCombobox();
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
         if ( cmbUserNotificationStatus.ItemCount > 0 )
         {
            A389UserNotificationStatus = cmbUserNotificationStatus.getValidValue(A389UserNotificationStatus);
            n389UserNotificationStatus = false;
            AssignAttri("", false, "A389UserNotificationStatus", A389UserNotificationStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUserNotificationStatus.CurrentValue = StringUtil.RTrim( A389UserNotificationStatus);
            AssignProp("", false, cmbUserNotificationStatus_Internalname, "Values", cmbUserNotificationStatus.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "User Notification", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_UserNotification.htm");
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
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_UserNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_UserNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_UserNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_UserNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_UserNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUserNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUserNotificationId_Internalname, "Notification Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUserNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A387UserNotificationId), 9, 0, ",", "")), StringUtil.LTrim( ((edtUserNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A387UserNotificationId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A387UserNotificationId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUserNotificationId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_UserNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificationId_Internalname, "Notification Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificationId_Internalname, ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ",", ""))), ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( ((edtNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A381NotificationId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A381NotificationId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificationId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_UserNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUserNotificationUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUserNotificationUserId_Internalname, "User Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUserNotificationUserId_Internalname, ((0==A388UserNotificationUserId)&&IsIns( )||n388UserNotificationUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A388UserNotificationUserId), 4, 0, ",", ""))), ((0==A388UserNotificationUserId)&&IsIns( )||n388UserNotificationUserId ? "" : StringUtil.LTrim( ((edtUserNotificationUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A388UserNotificationUserId), "ZZZ9") : context.localUtil.Format( (decimal)(A388UserNotificationUserId), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserNotificationUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUserNotificationUserId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_UserNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbUserNotificationStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUserNotificationStatus_Internalname, "Notification Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUserNotificationStatus, cmbUserNotificationStatus_Internalname, StringUtil.RTrim( A389UserNotificationStatus), 1, cmbUserNotificationStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbUserNotificationStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_UserNotification.htm");
         cmbUserNotificationStatus.CurrentValue = StringUtil.RTrim( A389UserNotificationStatus);
         AssignProp("", false, cmbUserNotificationStatus_Internalname, "Values", (string)(cmbUserNotificationStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUserNotificationSentAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUserNotificationSentAt_Internalname, "Sent At", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUserNotificationSentAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUserNotificationSentAt_Internalname, context.localUtil.TToC( A390UserNotificationSentAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A390UserNotificationSentAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserNotificationSentAt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUserNotificationSentAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_UserNotification.htm");
         GxWebStd.gx_bitmap( context, edtUserNotificationSentAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUserNotificationSentAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_UserNotification.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUserNotificationReadAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUserNotificationReadAt_Internalname, "Read At", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUserNotificationReadAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUserNotificationReadAt_Internalname, context.localUtil.TToC( A391UserNotificationReadAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A391UserNotificationReadAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserNotificationReadAt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUserNotificationReadAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_UserNotification.htm");
         GxWebStd.gx_bitmap( context, edtUserNotificationReadAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUserNotificationReadAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_UserNotification.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_UserNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_UserNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_UserNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z387UserNotificationId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z387UserNotificationId"), ",", "."), 18, MidpointRounding.ToEven));
            Z389UserNotificationStatus = cgiGet( "Z389UserNotificationStatus");
            n389UserNotificationStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A389UserNotificationStatus)) ? true : false);
            Z390UserNotificationSentAt = context.localUtil.CToT( cgiGet( "Z390UserNotificationSentAt"), 0);
            n390UserNotificationSentAt = ((DateTime.MinValue==A390UserNotificationSentAt) ? true : false);
            Z391UserNotificationReadAt = context.localUtil.CToT( cgiGet( "Z391UserNotificationReadAt"), 0);
            n391UserNotificationReadAt = ((DateTime.MinValue==A391UserNotificationReadAt) ? true : false);
            Z381NotificationId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z381NotificationId"), ",", "."), 18, MidpointRounding.ToEven));
            n381NotificationId = ((0==A381NotificationId) ? true : false);
            Z388UserNotificationUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z388UserNotificationUserId"), ",", "."), 18, MidpointRounding.ToEven));
            n388UserNotificationUserId = ((0==A388UserNotificationUserId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtUserNotificationId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUserNotificationId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USERNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtUserNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A387UserNotificationId = 0;
               AssignAttri("", false, "A387UserNotificationId", StringUtil.LTrimStr( (decimal)(A387UserNotificationId), 9, 0));
            }
            else
            {
               A387UserNotificationId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUserNotificationId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A387UserNotificationId", StringUtil.LTrimStr( (decimal)(A387UserNotificationId), 9, 0));
            }
            n381NotificationId = ((StringUtil.StrCmp(cgiGet( edtNotificationId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtNotificationId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNotificationId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A381NotificationId = 0;
               n381NotificationId = false;
               AssignAttri("", false, "A381NotificationId", (n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ".", ""))));
            }
            else
            {
               A381NotificationId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNotificationId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A381NotificationId", (n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ".", ""))));
            }
            n388UserNotificationUserId = ((StringUtil.StrCmp(cgiGet( edtUserNotificationUserId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUserNotificationUserId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUserNotificationUserId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USERNOTIFICATIONUSERID");
               AnyError = 1;
               GX_FocusControl = edtUserNotificationUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A388UserNotificationUserId = 0;
               n388UserNotificationUserId = false;
               AssignAttri("", false, "A388UserNotificationUserId", (n388UserNotificationUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A388UserNotificationUserId), 4, 0, ".", ""))));
            }
            else
            {
               A388UserNotificationUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtUserNotificationUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A388UserNotificationUserId", (n388UserNotificationUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A388UserNotificationUserId), 4, 0, ".", ""))));
            }
            cmbUserNotificationStatus.CurrentValue = cgiGet( cmbUserNotificationStatus_Internalname);
            A389UserNotificationStatus = cgiGet( cmbUserNotificationStatus_Internalname);
            n389UserNotificationStatus = false;
            AssignAttri("", false, "A389UserNotificationStatus", A389UserNotificationStatus);
            n389UserNotificationStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A389UserNotificationStatus)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtUserNotificationSentAt_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"User Notification Sent At"}), 1, "USERNOTIFICATIONSENTAT");
               AnyError = 1;
               GX_FocusControl = edtUserNotificationSentAt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A390UserNotificationSentAt = (DateTime)(DateTime.MinValue);
               n390UserNotificationSentAt = false;
               AssignAttri("", false, "A390UserNotificationSentAt", context.localUtil.TToC( A390UserNotificationSentAt, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A390UserNotificationSentAt = context.localUtil.CToT( cgiGet( edtUserNotificationSentAt_Internalname));
               n390UserNotificationSentAt = false;
               AssignAttri("", false, "A390UserNotificationSentAt", context.localUtil.TToC( A390UserNotificationSentAt, 8, 5, 0, 3, "/", ":", " "));
            }
            n390UserNotificationSentAt = ((DateTime.MinValue==A390UserNotificationSentAt) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtUserNotificationReadAt_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"User Notification Read At"}), 1, "USERNOTIFICATIONREADAT");
               AnyError = 1;
               GX_FocusControl = edtUserNotificationReadAt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A391UserNotificationReadAt = (DateTime)(DateTime.MinValue);
               n391UserNotificationReadAt = false;
               AssignAttri("", false, "A391UserNotificationReadAt", context.localUtil.TToC( A391UserNotificationReadAt, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A391UserNotificationReadAt = context.localUtil.CToT( cgiGet( edtUserNotificationReadAt_Internalname));
               n391UserNotificationReadAt = false;
               AssignAttri("", false, "A391UserNotificationReadAt", context.localUtil.TToC( A391UserNotificationReadAt, 8, 5, 0, 3, "/", ":", " "));
            }
            n391UserNotificationReadAt = ((DateTime.MinValue==A391UserNotificationReadAt) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A387UserNotificationId = (int)(Math.Round(NumberUtil.Val( GetPar( "UserNotificationId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A387UserNotificationId", StringUtil.LTrimStr( (decimal)(A387UserNotificationId), 9, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1I57( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes1I57( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption1I0( )
      {
      }

      protected void ZM1I57( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z389UserNotificationStatus = T001I3_A389UserNotificationStatus[0];
               Z390UserNotificationSentAt = T001I3_A390UserNotificationSentAt[0];
               Z391UserNotificationReadAt = T001I3_A391UserNotificationReadAt[0];
               Z381NotificationId = T001I3_A381NotificationId[0];
               Z388UserNotificationUserId = T001I3_A388UserNotificationUserId[0];
            }
            else
            {
               Z389UserNotificationStatus = A389UserNotificationStatus;
               Z390UserNotificationSentAt = A390UserNotificationSentAt;
               Z391UserNotificationReadAt = A391UserNotificationReadAt;
               Z381NotificationId = A381NotificationId;
               Z388UserNotificationUserId = A388UserNotificationUserId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z387UserNotificationId = A387UserNotificationId;
            Z389UserNotificationStatus = A389UserNotificationStatus;
            Z390UserNotificationSentAt = A390UserNotificationSentAt;
            Z391UserNotificationReadAt = A391UserNotificationReadAt;
            Z381NotificationId = A381NotificationId;
            Z388UserNotificationUserId = A388UserNotificationUserId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load1I57( )
      {
         /* Using cursor T001I6 */
         pr_default.execute(4, new Object[] {A387UserNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound57 = 1;
            A389UserNotificationStatus = T001I6_A389UserNotificationStatus[0];
            n389UserNotificationStatus = T001I6_n389UserNotificationStatus[0];
            AssignAttri("", false, "A389UserNotificationStatus", A389UserNotificationStatus);
            A390UserNotificationSentAt = T001I6_A390UserNotificationSentAt[0];
            n390UserNotificationSentAt = T001I6_n390UserNotificationSentAt[0];
            AssignAttri("", false, "A390UserNotificationSentAt", context.localUtil.TToC( A390UserNotificationSentAt, 8, 5, 0, 3, "/", ":", " "));
            A391UserNotificationReadAt = T001I6_A391UserNotificationReadAt[0];
            n391UserNotificationReadAt = T001I6_n391UserNotificationReadAt[0];
            AssignAttri("", false, "A391UserNotificationReadAt", context.localUtil.TToC( A391UserNotificationReadAt, 8, 5, 0, 3, "/", ":", " "));
            A381NotificationId = T001I6_A381NotificationId[0];
            n381NotificationId = T001I6_n381NotificationId[0];
            AssignAttri("", false, "A381NotificationId", ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ".", ""))));
            A388UserNotificationUserId = T001I6_A388UserNotificationUserId[0];
            n388UserNotificationUserId = T001I6_n388UserNotificationUserId[0];
            AssignAttri("", false, "A388UserNotificationUserId", ((0==A388UserNotificationUserId)&&IsIns( )||n388UserNotificationUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A388UserNotificationUserId), 4, 0, ".", ""))));
            ZM1I57( -2) ;
         }
         pr_default.close(4);
         OnLoadActions1I57( ) ;
      }

      protected void OnLoadActions1I57( )
      {
      }

      protected void CheckExtendedTable1I57( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001I4 */
         pr_default.execute(2, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A381NotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'Notification'.", "ForeignKeyNotFound", 1, "NOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         /* Using cursor T001I5 */
         pr_default.execute(3, new Object[] {n388UserNotificationUserId, A388UserNotificationUserId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A388UserNotificationUserId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb User Notification'.", "ForeignKeyNotFound", 1, "USERNOTIFICATIONUSERID");
               AnyError = 1;
               GX_FocusControl = edtUserNotificationUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A389UserNotificationStatus, "Unread") == 0 ) || ( StringUtil.StrCmp(A389UserNotificationStatus, "Read") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A389UserNotificationStatus)) ) )
         {
            GX_msglist.addItem("Campo User Notification Status fora do intervalo", "OutOfRange", 1, "USERNOTIFICATIONSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbUserNotificationStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1I57( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A381NotificationId )
      {
         /* Using cursor T001I7 */
         pr_default.execute(5, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A381NotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'Notification'.", "ForeignKeyNotFound", 1, "NOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_4( short A388UserNotificationUserId )
      {
         /* Using cursor T001I8 */
         pr_default.execute(6, new Object[] {n388UserNotificationUserId, A388UserNotificationUserId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A388UserNotificationUserId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb User Notification'.", "ForeignKeyNotFound", 1, "USERNOTIFICATIONUSERID");
               AnyError = 1;
               GX_FocusControl = edtUserNotificationUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1I57( )
      {
         /* Using cursor T001I9 */
         pr_default.execute(7, new Object[] {A387UserNotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound57 = 1;
         }
         else
         {
            RcdFound57 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001I3 */
         pr_default.execute(1, new Object[] {A387UserNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1I57( 2) ;
            RcdFound57 = 1;
            A387UserNotificationId = T001I3_A387UserNotificationId[0];
            AssignAttri("", false, "A387UserNotificationId", StringUtil.LTrimStr( (decimal)(A387UserNotificationId), 9, 0));
            A389UserNotificationStatus = T001I3_A389UserNotificationStatus[0];
            n389UserNotificationStatus = T001I3_n389UserNotificationStatus[0];
            AssignAttri("", false, "A389UserNotificationStatus", A389UserNotificationStatus);
            A390UserNotificationSentAt = T001I3_A390UserNotificationSentAt[0];
            n390UserNotificationSentAt = T001I3_n390UserNotificationSentAt[0];
            AssignAttri("", false, "A390UserNotificationSentAt", context.localUtil.TToC( A390UserNotificationSentAt, 8, 5, 0, 3, "/", ":", " "));
            A391UserNotificationReadAt = T001I3_A391UserNotificationReadAt[0];
            n391UserNotificationReadAt = T001I3_n391UserNotificationReadAt[0];
            AssignAttri("", false, "A391UserNotificationReadAt", context.localUtil.TToC( A391UserNotificationReadAt, 8, 5, 0, 3, "/", ":", " "));
            A381NotificationId = T001I3_A381NotificationId[0];
            n381NotificationId = T001I3_n381NotificationId[0];
            AssignAttri("", false, "A381NotificationId", ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ".", ""))));
            A388UserNotificationUserId = T001I3_A388UserNotificationUserId[0];
            n388UserNotificationUserId = T001I3_n388UserNotificationUserId[0];
            AssignAttri("", false, "A388UserNotificationUserId", ((0==A388UserNotificationUserId)&&IsIns( )||n388UserNotificationUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A388UserNotificationUserId), 4, 0, ".", ""))));
            Z387UserNotificationId = A387UserNotificationId;
            sMode57 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1I57( ) ;
            if ( AnyError == 1 )
            {
               RcdFound57 = 0;
               InitializeNonKey1I57( ) ;
            }
            Gx_mode = sMode57;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound57 = 0;
            InitializeNonKey1I57( ) ;
            sMode57 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode57;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1I57( ) ;
         if ( RcdFound57 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound57 = 0;
         /* Using cursor T001I10 */
         pr_default.execute(8, new Object[] {A387UserNotificationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001I10_A387UserNotificationId[0] < A387UserNotificationId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001I10_A387UserNotificationId[0] > A387UserNotificationId ) ) )
            {
               A387UserNotificationId = T001I10_A387UserNotificationId[0];
               AssignAttri("", false, "A387UserNotificationId", StringUtil.LTrimStr( (decimal)(A387UserNotificationId), 9, 0));
               RcdFound57 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound57 = 0;
         /* Using cursor T001I11 */
         pr_default.execute(9, new Object[] {A387UserNotificationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001I11_A387UserNotificationId[0] > A387UserNotificationId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001I11_A387UserNotificationId[0] < A387UserNotificationId ) ) )
            {
               A387UserNotificationId = T001I11_A387UserNotificationId[0];
               AssignAttri("", false, "A387UserNotificationId", StringUtil.LTrimStr( (decimal)(A387UserNotificationId), 9, 0));
               RcdFound57 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1I57( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUserNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1I57( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound57 == 1 )
            {
               if ( A387UserNotificationId != Z387UserNotificationId )
               {
                  A387UserNotificationId = Z387UserNotificationId;
                  AssignAttri("", false, "A387UserNotificationId", StringUtil.LTrimStr( (decimal)(A387UserNotificationId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USERNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtUserNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUserNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1I57( ) ;
                  GX_FocusControl = edtUserNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A387UserNotificationId != Z387UserNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUserNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1I57( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USERNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtUserNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtUserNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1I57( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A387UserNotificationId != Z387UserNotificationId )
         {
            A387UserNotificationId = Z387UserNotificationId;
            AssignAttri("", false, "A387UserNotificationId", StringUtil.LTrimStr( (decimal)(A387UserNotificationId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USERNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtUserNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUserNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound57 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USERNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtUserNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtNotificationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1I57( ) ;
         if ( RcdFound57 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1I57( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound57 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound57 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1I57( ) ;
         if ( RcdFound57 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound57 != 0 )
            {
               ScanNext1I57( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1I57( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1I57( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001I2 */
            pr_default.execute(0, new Object[] {A387UserNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z389UserNotificationStatus, T001I2_A389UserNotificationStatus[0]) != 0 ) || ( Z390UserNotificationSentAt != T001I2_A390UserNotificationSentAt[0] ) || ( Z391UserNotificationReadAt != T001I2_A391UserNotificationReadAt[0] ) || ( Z381NotificationId != T001I2_A381NotificationId[0] ) || ( Z388UserNotificationUserId != T001I2_A388UserNotificationUserId[0] ) )
            {
               if ( StringUtil.StrCmp(Z389UserNotificationStatus, T001I2_A389UserNotificationStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("usernotification:[seudo value changed for attri]"+"UserNotificationStatus");
                  GXUtil.WriteLogRaw("Old: ",Z389UserNotificationStatus);
                  GXUtil.WriteLogRaw("Current: ",T001I2_A389UserNotificationStatus[0]);
               }
               if ( Z390UserNotificationSentAt != T001I2_A390UserNotificationSentAt[0] )
               {
                  GXUtil.WriteLog("usernotification:[seudo value changed for attri]"+"UserNotificationSentAt");
                  GXUtil.WriteLogRaw("Old: ",Z390UserNotificationSentAt);
                  GXUtil.WriteLogRaw("Current: ",T001I2_A390UserNotificationSentAt[0]);
               }
               if ( Z391UserNotificationReadAt != T001I2_A391UserNotificationReadAt[0] )
               {
                  GXUtil.WriteLog("usernotification:[seudo value changed for attri]"+"UserNotificationReadAt");
                  GXUtil.WriteLogRaw("Old: ",Z391UserNotificationReadAt);
                  GXUtil.WriteLogRaw("Current: ",T001I2_A391UserNotificationReadAt[0]);
               }
               if ( Z381NotificationId != T001I2_A381NotificationId[0] )
               {
                  GXUtil.WriteLog("usernotification:[seudo value changed for attri]"+"NotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z381NotificationId);
                  GXUtil.WriteLogRaw("Current: ",T001I2_A381NotificationId[0]);
               }
               if ( Z388UserNotificationUserId != T001I2_A388UserNotificationUserId[0] )
               {
                  GXUtil.WriteLog("usernotification:[seudo value changed for attri]"+"UserNotificationUserId");
                  GXUtil.WriteLogRaw("Old: ",Z388UserNotificationUserId);
                  GXUtil.WriteLogRaw("Current: ",T001I2_A388UserNotificationUserId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"UserNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1I57( )
      {
         BeforeValidate1I57( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1I57( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1I57( 0) ;
            CheckOptimisticConcurrency1I57( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1I57( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1I57( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001I12 */
                     pr_default.execute(10, new Object[] {n389UserNotificationStatus, A389UserNotificationStatus, n390UserNotificationSentAt, A390UserNotificationSentAt, n391UserNotificationReadAt, A391UserNotificationReadAt, n381NotificationId, A381NotificationId, n388UserNotificationUserId, A388UserNotificationUserId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001I13 */
                     pr_default.execute(11);
                     A387UserNotificationId = T001I13_A387UserNotificationId[0];
                     AssignAttri("", false, "A387UserNotificationId", StringUtil.LTrimStr( (decimal)(A387UserNotificationId), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("UserNotification");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1I0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1I57( ) ;
            }
            EndLevel1I57( ) ;
         }
         CloseExtendedTableCursors1I57( ) ;
      }

      protected void Update1I57( )
      {
         BeforeValidate1I57( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1I57( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1I57( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1I57( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1I57( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001I14 */
                     pr_default.execute(12, new Object[] {n389UserNotificationStatus, A389UserNotificationStatus, n390UserNotificationSentAt, A390UserNotificationSentAt, n391UserNotificationReadAt, A391UserNotificationReadAt, n381NotificationId, A381NotificationId, n388UserNotificationUserId, A388UserNotificationUserId, A387UserNotificationId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("UserNotification");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1I57( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1I0( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1I57( ) ;
         }
         CloseExtendedTableCursors1I57( ) ;
      }

      protected void DeferredUpdate1I57( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1I57( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1I57( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1I57( ) ;
            AfterConfirm1I57( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1I57( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001I15 */
                  pr_default.execute(13, new Object[] {A387UserNotificationId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("UserNotification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound57 == 0 )
                        {
                           InitAll1I57( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption1I0( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode57 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1I57( ) ;
         Gx_mode = sMode57;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1I57( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1I57( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1I57( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues1I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1I57( )
      {
         /* Using cursor T001I16 */
         pr_default.execute(14);
         RcdFound57 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound57 = 1;
            A387UserNotificationId = T001I16_A387UserNotificationId[0];
            AssignAttri("", false, "A387UserNotificationId", StringUtil.LTrimStr( (decimal)(A387UserNotificationId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1I57( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound57 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound57 = 1;
            A387UserNotificationId = T001I16_A387UserNotificationId[0];
            AssignAttri("", false, "A387UserNotificationId", StringUtil.LTrimStr( (decimal)(A387UserNotificationId), 9, 0));
         }
      }

      protected void ScanEnd1I57( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1I57( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1I57( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1I57( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1I57( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1I57( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1I57( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1I57( )
      {
         edtUserNotificationId_Enabled = 0;
         AssignProp("", false, edtUserNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserNotificationId_Enabled), 5, 0), true);
         edtNotificationId_Enabled = 0;
         AssignProp("", false, edtNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificationId_Enabled), 5, 0), true);
         edtUserNotificationUserId_Enabled = 0;
         AssignProp("", false, edtUserNotificationUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserNotificationUserId_Enabled), 5, 0), true);
         cmbUserNotificationStatus.Enabled = 0;
         AssignProp("", false, cmbUserNotificationStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUserNotificationStatus.Enabled), 5, 0), true);
         edtUserNotificationSentAt_Enabled = 0;
         AssignProp("", false, edtUserNotificationSentAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserNotificationSentAt_Enabled), 5, 0), true);
         edtUserNotificationReadAt_Enabled = 0;
         AssignProp("", false, edtUserNotificationReadAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserNotificationReadAt_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1I57( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1I0( )
      {
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
         MasterPageObj.master_styles();
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 133260), false, true);
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usernotification") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z387UserNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z387UserNotificationId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z389UserNotificationStatus", Z389UserNotificationStatus);
         GxWebStd.gx_hidden_field( context, "Z390UserNotificationSentAt", context.localUtil.TToC( Z390UserNotificationSentAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z391UserNotificationReadAt", context.localUtil.TToC( Z391UserNotificationReadAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z381NotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z381NotificationId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z388UserNotificationUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z388UserNotificationUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("usernotification")  ;
      }

      public override string GetPgmname( )
      {
         return "UserNotification" ;
      }

      public override string GetPgmdesc( )
      {
         return "User Notification" ;
      }

      protected void InitializeNonKey1I57( )
      {
         A381NotificationId = 0;
         n381NotificationId = false;
         AssignAttri("", false, "A381NotificationId", ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ".", ""))));
         n381NotificationId = ((0==A381NotificationId) ? true : false);
         A388UserNotificationUserId = 0;
         n388UserNotificationUserId = false;
         AssignAttri("", false, "A388UserNotificationUserId", ((0==A388UserNotificationUserId)&&IsIns( )||n388UserNotificationUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A388UserNotificationUserId), 4, 0, ".", ""))));
         n388UserNotificationUserId = ((0==A388UserNotificationUserId) ? true : false);
         A389UserNotificationStatus = "";
         n389UserNotificationStatus = false;
         AssignAttri("", false, "A389UserNotificationStatus", A389UserNotificationStatus);
         n389UserNotificationStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A389UserNotificationStatus)) ? true : false);
         A390UserNotificationSentAt = (DateTime)(DateTime.MinValue);
         n390UserNotificationSentAt = false;
         AssignAttri("", false, "A390UserNotificationSentAt", context.localUtil.TToC( A390UserNotificationSentAt, 8, 5, 0, 3, "/", ":", " "));
         n390UserNotificationSentAt = ((DateTime.MinValue==A390UserNotificationSentAt) ? true : false);
         A391UserNotificationReadAt = (DateTime)(DateTime.MinValue);
         n391UserNotificationReadAt = false;
         AssignAttri("", false, "A391UserNotificationReadAt", context.localUtil.TToC( A391UserNotificationReadAt, 8, 5, 0, 3, "/", ":", " "));
         n391UserNotificationReadAt = ((DateTime.MinValue==A391UserNotificationReadAt) ? true : false);
         Z389UserNotificationStatus = "";
         Z390UserNotificationSentAt = (DateTime)(DateTime.MinValue);
         Z391UserNotificationReadAt = (DateTime)(DateTime.MinValue);
         Z381NotificationId = 0;
         Z388UserNotificationUserId = 0;
      }

      protected void InitAll1I57( )
      {
         A387UserNotificationId = 0;
         AssignAttri("", false, "A387UserNotificationId", StringUtil.LTrimStr( (decimal)(A387UserNotificationId), 9, 0));
         InitializeNonKey1I57( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019163688", true, true);
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
         context.AddJavascriptSource("usernotification.js", "?202561019163689", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtUserNotificationId_Internalname = "USERNOTIFICATIONID";
         edtNotificationId_Internalname = "NOTIFICATIONID";
         edtUserNotificationUserId_Internalname = "USERNOTIFICATIONUSERID";
         cmbUserNotificationStatus_Internalname = "USERNOTIFICATIONSTATUS";
         edtUserNotificationSentAt_Internalname = "USERNOTIFICATIONSENTAT";
         edtUserNotificationReadAt_Internalname = "USERNOTIFICATIONREADAT";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "User Notification";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtUserNotificationReadAt_Jsonclick = "";
         edtUserNotificationReadAt_Enabled = 1;
         edtUserNotificationSentAt_Jsonclick = "";
         edtUserNotificationSentAt_Enabled = 1;
         cmbUserNotificationStatus_Jsonclick = "";
         cmbUserNotificationStatus.Enabled = 1;
         edtUserNotificationUserId_Jsonclick = "";
         edtUserNotificationUserId_Enabled = 1;
         edtNotificationId_Jsonclick = "";
         edtNotificationId_Enabled = 1;
         edtUserNotificationId_Jsonclick = "";
         edtUserNotificationId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         cmbUserNotificationStatus.Name = "USERNOTIFICATIONSTATUS";
         cmbUserNotificationStatus.WebTags = "";
         cmbUserNotificationStatus.addItem("Unread", "Unread", 0);
         cmbUserNotificationStatus.addItem("Read", "Read", 0);
         if ( cmbUserNotificationStatus.ItemCount > 0 )
         {
            A389UserNotificationStatus = cmbUserNotificationStatus.getValidValue(A389UserNotificationStatus);
            n389UserNotificationStatus = false;
            AssignAttri("", false, "A389UserNotificationStatus", A389UserNotificationStatus);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtNotificationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Usernotificationid( )
      {
         n389UserNotificationStatus = false;
         A389UserNotificationStatus = cmbUserNotificationStatus.CurrentValue;
         n389UserNotificationStatus = false;
         cmbUserNotificationStatus.CurrentValue = A389UserNotificationStatus;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbUserNotificationStatus.ItemCount > 0 )
         {
            A389UserNotificationStatus = cmbUserNotificationStatus.getValidValue(A389UserNotificationStatus);
            n389UserNotificationStatus = false;
            cmbUserNotificationStatus.CurrentValue = A389UserNotificationStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUserNotificationStatus.CurrentValue = StringUtil.RTrim( A389UserNotificationStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A381NotificationId", ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ".", ""))));
         AssignAttri("", false, "A388UserNotificationUserId", ((0==A388UserNotificationUserId)&&IsIns( )||n388UserNotificationUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A388UserNotificationUserId), 4, 0, ".", ""))));
         AssignAttri("", false, "A389UserNotificationStatus", A389UserNotificationStatus);
         cmbUserNotificationStatus.CurrentValue = StringUtil.RTrim( A389UserNotificationStatus);
         AssignProp("", false, cmbUserNotificationStatus_Internalname, "Values", cmbUserNotificationStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A390UserNotificationSentAt", context.localUtil.TToC( A390UserNotificationSentAt, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A391UserNotificationReadAt", context.localUtil.TToC( A391UserNotificationReadAt, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z387UserNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z387UserNotificationId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z381NotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z381NotificationId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z388UserNotificationUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z388UserNotificationUserId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z389UserNotificationStatus", Z389UserNotificationStatus);
         GxWebStd.gx_hidden_field( context, "Z390UserNotificationSentAt", context.localUtil.TToC( Z390UserNotificationSentAt, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z391UserNotificationReadAt", context.localUtil.TToC( Z391UserNotificationReadAt, 10, 8, 0, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Notificationid( )
      {
         /* Using cursor T001I17 */
         pr_default.execute(15, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A381NotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'Notification'.", "ForeignKeyNotFound", 1, "NOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtNotificationId_Internalname;
            }
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Usernotificationuserid( )
      {
         /* Using cursor T001I18 */
         pr_default.execute(16, new Object[] {n388UserNotificationUserId, A388UserNotificationUserId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A388UserNotificationUserId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb User Notification'.", "ForeignKeyNotFound", 1, "USERNOTIFICATIONUSERID");
               AnyError = 1;
               GX_FocusControl = edtUserNotificationUserId_Internalname;
            }
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_USERNOTIFICATIONID","""{"handler":"Valid_Usernotificationid","iparms":[{"av":"cmbUserNotificationStatus"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_USERNOTIFICATIONID",""","oparms":[{"av":"A381NotificationId","fld":"NOTIFICATIONID","pic":"ZZZZZZZZ9","nullAv":"n381NotificationId","type":"int"},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","nullAv":"n388UserNotificationUserId","type":"int"},{"av":"cmbUserNotificationStatus"},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS","type":"svchar"},{"av":"A390UserNotificationSentAt","fld":"USERNOTIFICATIONSENTAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A391UserNotificationReadAt","fld":"USERNOTIFICATIONREADAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z387UserNotificationId","type":"int"},{"av":"Z381NotificationId","type":"int"},{"av":"Z388UserNotificationUserId","type":"int"},{"av":"Z389UserNotificationStatus","type":"svchar"},{"av":"Z390UserNotificationSentAt","type":"dtime"},{"av":"Z391UserNotificationReadAt","type":"dtime"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_NOTIFICATIONID","""{"handler":"Valid_Notificationid","iparms":[{"av":"A381NotificationId","fld":"NOTIFICATIONID","pic":"ZZZZZZZZ9","nullAv":"n381NotificationId","type":"int"}]}""");
         setEventMetadata("VALID_USERNOTIFICATIONUSERID","""{"handler":"Valid_Usernotificationuserid","iparms":[{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID","pic":"ZZZ9","nullAv":"n388UserNotificationUserId","type":"int"}]}""");
         setEventMetadata("VALID_USERNOTIFICATIONSTATUS","""{"handler":"Valid_Usernotificationstatus","iparms":[]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z389UserNotificationStatus = "";
         Z390UserNotificationSentAt = (DateTime)(DateTime.MinValue);
         Z391UserNotificationReadAt = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A389UserNotificationStatus = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A390UserNotificationSentAt = (DateTime)(DateTime.MinValue);
         A391UserNotificationReadAt = (DateTime)(DateTime.MinValue);
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T001I6_A387UserNotificationId = new int[1] ;
         T001I6_A389UserNotificationStatus = new string[] {""} ;
         T001I6_n389UserNotificationStatus = new bool[] {false} ;
         T001I6_A390UserNotificationSentAt = new DateTime[] {DateTime.MinValue} ;
         T001I6_n390UserNotificationSentAt = new bool[] {false} ;
         T001I6_A391UserNotificationReadAt = new DateTime[] {DateTime.MinValue} ;
         T001I6_n391UserNotificationReadAt = new bool[] {false} ;
         T001I6_A381NotificationId = new int[1] ;
         T001I6_n381NotificationId = new bool[] {false} ;
         T001I6_A388UserNotificationUserId = new short[1] ;
         T001I6_n388UserNotificationUserId = new bool[] {false} ;
         T001I4_A381NotificationId = new int[1] ;
         T001I4_n381NotificationId = new bool[] {false} ;
         T001I5_A388UserNotificationUserId = new short[1] ;
         T001I5_n388UserNotificationUserId = new bool[] {false} ;
         T001I7_A381NotificationId = new int[1] ;
         T001I7_n381NotificationId = new bool[] {false} ;
         T001I8_A388UserNotificationUserId = new short[1] ;
         T001I8_n388UserNotificationUserId = new bool[] {false} ;
         T001I9_A387UserNotificationId = new int[1] ;
         T001I3_A387UserNotificationId = new int[1] ;
         T001I3_A389UserNotificationStatus = new string[] {""} ;
         T001I3_n389UserNotificationStatus = new bool[] {false} ;
         T001I3_A390UserNotificationSentAt = new DateTime[] {DateTime.MinValue} ;
         T001I3_n390UserNotificationSentAt = new bool[] {false} ;
         T001I3_A391UserNotificationReadAt = new DateTime[] {DateTime.MinValue} ;
         T001I3_n391UserNotificationReadAt = new bool[] {false} ;
         T001I3_A381NotificationId = new int[1] ;
         T001I3_n381NotificationId = new bool[] {false} ;
         T001I3_A388UserNotificationUserId = new short[1] ;
         T001I3_n388UserNotificationUserId = new bool[] {false} ;
         sMode57 = "";
         T001I10_A387UserNotificationId = new int[1] ;
         T001I11_A387UserNotificationId = new int[1] ;
         T001I2_A387UserNotificationId = new int[1] ;
         T001I2_A389UserNotificationStatus = new string[] {""} ;
         T001I2_n389UserNotificationStatus = new bool[] {false} ;
         T001I2_A390UserNotificationSentAt = new DateTime[] {DateTime.MinValue} ;
         T001I2_n390UserNotificationSentAt = new bool[] {false} ;
         T001I2_A391UserNotificationReadAt = new DateTime[] {DateTime.MinValue} ;
         T001I2_n391UserNotificationReadAt = new bool[] {false} ;
         T001I2_A381NotificationId = new int[1] ;
         T001I2_n381NotificationId = new bool[] {false} ;
         T001I2_A388UserNotificationUserId = new short[1] ;
         T001I2_n388UserNotificationUserId = new bool[] {false} ;
         T001I13_A387UserNotificationId = new int[1] ;
         T001I16_A387UserNotificationId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ389UserNotificationStatus = "";
         ZZ390UserNotificationSentAt = (DateTime)(DateTime.MinValue);
         ZZ391UserNotificationReadAt = (DateTime)(DateTime.MinValue);
         T001I17_A381NotificationId = new int[1] ;
         T001I17_n381NotificationId = new bool[] {false} ;
         T001I18_A388UserNotificationUserId = new short[1] ;
         T001I18_n388UserNotificationUserId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usernotification__default(),
            new Object[][] {
                new Object[] {
               T001I2_A387UserNotificationId, T001I2_A389UserNotificationStatus, T001I2_n389UserNotificationStatus, T001I2_A390UserNotificationSentAt, T001I2_n390UserNotificationSentAt, T001I2_A391UserNotificationReadAt, T001I2_n391UserNotificationReadAt, T001I2_A381NotificationId, T001I2_n381NotificationId, T001I2_A388UserNotificationUserId,
               T001I2_n388UserNotificationUserId
               }
               , new Object[] {
               T001I3_A387UserNotificationId, T001I3_A389UserNotificationStatus, T001I3_n389UserNotificationStatus, T001I3_A390UserNotificationSentAt, T001I3_n390UserNotificationSentAt, T001I3_A391UserNotificationReadAt, T001I3_n391UserNotificationReadAt, T001I3_A381NotificationId, T001I3_n381NotificationId, T001I3_A388UserNotificationUserId,
               T001I3_n388UserNotificationUserId
               }
               , new Object[] {
               T001I4_A381NotificationId
               }
               , new Object[] {
               T001I5_A388UserNotificationUserId
               }
               , new Object[] {
               T001I6_A387UserNotificationId, T001I6_A389UserNotificationStatus, T001I6_n389UserNotificationStatus, T001I6_A390UserNotificationSentAt, T001I6_n390UserNotificationSentAt, T001I6_A391UserNotificationReadAt, T001I6_n391UserNotificationReadAt, T001I6_A381NotificationId, T001I6_n381NotificationId, T001I6_A388UserNotificationUserId,
               T001I6_n388UserNotificationUserId
               }
               , new Object[] {
               T001I7_A381NotificationId
               }
               , new Object[] {
               T001I8_A388UserNotificationUserId
               }
               , new Object[] {
               T001I9_A387UserNotificationId
               }
               , new Object[] {
               T001I10_A387UserNotificationId
               }
               , new Object[] {
               T001I11_A387UserNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               T001I13_A387UserNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001I16_A387UserNotificationId
               }
               , new Object[] {
               T001I17_A381NotificationId
               }
               , new Object[] {
               T001I18_A388UserNotificationUserId
               }
            }
         );
      }

      private short Z388UserNotificationUserId ;
      private short GxWebError ;
      private short A388UserNotificationUserId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound57 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ388UserNotificationUserId ;
      private int Z387UserNotificationId ;
      private int Z381NotificationId ;
      private int A381NotificationId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A387UserNotificationId ;
      private int edtUserNotificationId_Enabled ;
      private int edtNotificationId_Enabled ;
      private int edtUserNotificationUserId_Enabled ;
      private int edtUserNotificationSentAt_Enabled ;
      private int edtUserNotificationReadAt_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ387UserNotificationId ;
      private int ZZ381NotificationId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtUserNotificationId_Internalname ;
      private string cmbUserNotificationStatus_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtUserNotificationId_Jsonclick ;
      private string edtNotificationId_Internalname ;
      private string edtNotificationId_Jsonclick ;
      private string edtUserNotificationUserId_Internalname ;
      private string edtUserNotificationUserId_Jsonclick ;
      private string cmbUserNotificationStatus_Jsonclick ;
      private string edtUserNotificationSentAt_Internalname ;
      private string edtUserNotificationSentAt_Jsonclick ;
      private string edtUserNotificationReadAt_Internalname ;
      private string edtUserNotificationReadAt_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode57 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z390UserNotificationSentAt ;
      private DateTime Z391UserNotificationReadAt ;
      private DateTime A390UserNotificationSentAt ;
      private DateTime A391UserNotificationReadAt ;
      private DateTime ZZ390UserNotificationSentAt ;
      private DateTime ZZ391UserNotificationReadAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n381NotificationId ;
      private bool n388UserNotificationUserId ;
      private bool wbErr ;
      private bool n389UserNotificationStatus ;
      private bool n390UserNotificationSentAt ;
      private bool n391UserNotificationReadAt ;
      private string Z389UserNotificationStatus ;
      private string A389UserNotificationStatus ;
      private string ZZ389UserNotificationStatus ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUserNotificationStatus ;
      private IDataStoreProvider pr_default ;
      private int[] T001I6_A387UserNotificationId ;
      private string[] T001I6_A389UserNotificationStatus ;
      private bool[] T001I6_n389UserNotificationStatus ;
      private DateTime[] T001I6_A390UserNotificationSentAt ;
      private bool[] T001I6_n390UserNotificationSentAt ;
      private DateTime[] T001I6_A391UserNotificationReadAt ;
      private bool[] T001I6_n391UserNotificationReadAt ;
      private int[] T001I6_A381NotificationId ;
      private bool[] T001I6_n381NotificationId ;
      private short[] T001I6_A388UserNotificationUserId ;
      private bool[] T001I6_n388UserNotificationUserId ;
      private int[] T001I4_A381NotificationId ;
      private bool[] T001I4_n381NotificationId ;
      private short[] T001I5_A388UserNotificationUserId ;
      private bool[] T001I5_n388UserNotificationUserId ;
      private int[] T001I7_A381NotificationId ;
      private bool[] T001I7_n381NotificationId ;
      private short[] T001I8_A388UserNotificationUserId ;
      private bool[] T001I8_n388UserNotificationUserId ;
      private int[] T001I9_A387UserNotificationId ;
      private int[] T001I3_A387UserNotificationId ;
      private string[] T001I3_A389UserNotificationStatus ;
      private bool[] T001I3_n389UserNotificationStatus ;
      private DateTime[] T001I3_A390UserNotificationSentAt ;
      private bool[] T001I3_n390UserNotificationSentAt ;
      private DateTime[] T001I3_A391UserNotificationReadAt ;
      private bool[] T001I3_n391UserNotificationReadAt ;
      private int[] T001I3_A381NotificationId ;
      private bool[] T001I3_n381NotificationId ;
      private short[] T001I3_A388UserNotificationUserId ;
      private bool[] T001I3_n388UserNotificationUserId ;
      private int[] T001I10_A387UserNotificationId ;
      private int[] T001I11_A387UserNotificationId ;
      private int[] T001I2_A387UserNotificationId ;
      private string[] T001I2_A389UserNotificationStatus ;
      private bool[] T001I2_n389UserNotificationStatus ;
      private DateTime[] T001I2_A390UserNotificationSentAt ;
      private bool[] T001I2_n390UserNotificationSentAt ;
      private DateTime[] T001I2_A391UserNotificationReadAt ;
      private bool[] T001I2_n391UserNotificationReadAt ;
      private int[] T001I2_A381NotificationId ;
      private bool[] T001I2_n381NotificationId ;
      private short[] T001I2_A388UserNotificationUserId ;
      private bool[] T001I2_n388UserNotificationUserId ;
      private int[] T001I13_A387UserNotificationId ;
      private int[] T001I16_A387UserNotificationId ;
      private int[] T001I17_A381NotificationId ;
      private bool[] T001I17_n381NotificationId ;
      private short[] T001I18_A388UserNotificationUserId ;
      private bool[] T001I18_n388UserNotificationUserId ;
   }

   public class usernotification__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001I2;
          prmT001I2 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmT001I3;
          prmT001I3 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmT001I4;
          prmT001I4 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001I5;
          prmT001I5 = new Object[] {
          new ParDef("UserNotificationUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001I6;
          prmT001I6 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmT001I7;
          prmT001I7 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001I8;
          prmT001I8 = new Object[] {
          new ParDef("UserNotificationUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001I9;
          prmT001I9 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmT001I10;
          prmT001I10 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmT001I11;
          prmT001I11 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmT001I12;
          prmT001I12 = new Object[] {
          new ParDef("UserNotificationStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("UserNotificationSentAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("UserNotificationReadAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("UserNotificationUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001I13;
          prmT001I13 = new Object[] {
          };
          Object[] prmT001I14;
          prmT001I14 = new Object[] {
          new ParDef("UserNotificationStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("UserNotificationSentAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("UserNotificationReadAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("UserNotificationUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmT001I15;
          prmT001I15 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmT001I16;
          prmT001I16 = new Object[] {
          };
          Object[] prmT001I17;
          prmT001I17 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001I18;
          prmT001I18 = new Object[] {
          new ParDef("UserNotificationUserId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001I2", "SELECT UserNotificationId, UserNotificationStatus, UserNotificationSentAt, UserNotificationReadAt, NotificationId, UserNotificationUserId FROM UserNotification WHERE UserNotificationId = :UserNotificationId  FOR UPDATE OF UserNotification NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001I2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001I3", "SELECT UserNotificationId, UserNotificationStatus, UserNotificationSentAt, UserNotificationReadAt, NotificationId, UserNotificationUserId FROM UserNotification WHERE UserNotificationId = :UserNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001I4", "SELECT NotificationId FROM Notification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001I5", "SELECT SecUserId AS UserNotificationUserId FROM SecUser WHERE SecUserId = :UserNotificationUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001I6", "SELECT TM1.UserNotificationId, TM1.UserNotificationStatus, TM1.UserNotificationSentAt, TM1.UserNotificationReadAt, TM1.NotificationId, TM1.UserNotificationUserId AS UserNotificationUserId FROM UserNotification TM1 WHERE TM1.UserNotificationId = :UserNotificationId ORDER BY TM1.UserNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001I7", "SELECT NotificationId FROM Notification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001I8", "SELECT SecUserId AS UserNotificationUserId FROM SecUser WHERE SecUserId = :UserNotificationUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001I9", "SELECT UserNotificationId FROM UserNotification WHERE UserNotificationId = :UserNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001I10", "SELECT UserNotificationId FROM UserNotification WHERE ( UserNotificationId > :UserNotificationId) ORDER BY UserNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001I11", "SELECT UserNotificationId FROM UserNotification WHERE ( UserNotificationId < :UserNotificationId) ORDER BY UserNotificationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001I12", "SAVEPOINT gxupdate;INSERT INTO UserNotification(UserNotificationStatus, UserNotificationSentAt, UserNotificationReadAt, NotificationId, UserNotificationUserId) VALUES(:UserNotificationStatus, :UserNotificationSentAt, :UserNotificationReadAt, :NotificationId, :UserNotificationUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001I12)
             ,new CursorDef("T001I13", "SELECT currval('UserNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001I14", "SAVEPOINT gxupdate;UPDATE UserNotification SET UserNotificationStatus=:UserNotificationStatus, UserNotificationSentAt=:UserNotificationSentAt, UserNotificationReadAt=:UserNotificationReadAt, NotificationId=:NotificationId, UserNotificationUserId=:UserNotificationUserId  WHERE UserNotificationId = :UserNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001I14)
             ,new CursorDef("T001I15", "SAVEPOINT gxupdate;DELETE FROM UserNotification  WHERE UserNotificationId = :UserNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001I15)
             ,new CursorDef("T001I16", "SELECT UserNotificationId FROM UserNotification ORDER BY UserNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I16,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001I17", "SELECT NotificationId FROM Notification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001I18", "SELECT SecUserId AS UserNotificationUserId FROM SecUser WHERE SecUserId = :UserNotificationUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001I18,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
