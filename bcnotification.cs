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
   public class bcnotification : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A133SecUserId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
            n133SecUserId = false;
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A133SecUserId) ;
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
         Form.Meta.addItem("description", "BCNotification", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public bcnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public bcnotification( IGxContext context )
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
         cmbNotificationType = new GXCombobox();
         cmbNotificationStatus = new GXCombobox();
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
         if ( cmbNotificationType.ItemCount > 0 )
         {
            A384NotificationType = cmbNotificationType.getValidValue(A384NotificationType);
            n384NotificationType = false;
            AssignAttri("", false, "A384NotificationType", A384NotificationType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificationType.CurrentValue = StringUtil.RTrim( A384NotificationType);
            AssignProp("", false, cmbNotificationType_Internalname, "Values", cmbNotificationType.ToJavascriptSource(), true);
         }
         if ( cmbNotificationStatus.ItemCount > 0 )
         {
            A386NotificationStatus = cmbNotificationStatus.getValidValue(A386NotificationStatus);
            n386NotificationStatus = false;
            AssignAttri("", false, "A386NotificationStatus", A386NotificationStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificationStatus.CurrentValue = StringUtil.RTrim( A386NotificationStatus);
            AssignProp("", false, cmbNotificationStatus_Internalname, "Values", cmbNotificationStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "BCNotification", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_BCNotification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_BCNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_BCNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_BCNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_BCNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_BCNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificationId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ",", "")), StringUtil.LTrim( ((edtNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A381NotificationId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A381NotificationId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificationId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_BCNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificationTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificationTitle_Internalname, "Title", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificationTitle_Internalname, A382NotificationTitle, StringUtil.RTrim( context.localUtil.Format( A382NotificationTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificationTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificationTitle_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_BCNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificationMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificationMessage_Internalname, "Message", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificationMessage_Internalname, A383NotificationMessage, StringUtil.RTrim( context.localUtil.Format( A383NotificationMessage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificationMessage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificationMessage_Enabled, 0, "text", "", 80, "chr", 1, "row", 106, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_BCNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotificationType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotificationType_Internalname, "Type", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotificationType, cmbNotificationType_Internalname, StringUtil.RTrim( A384NotificationType), 1, cmbNotificationType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNotificationType.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_BCNotification.htm");
         cmbNotificationType.CurrentValue = StringUtil.RTrim( A384NotificationType);
         AssignProp("", false, cmbNotificationType_Internalname, "Values", (string)(cmbNotificationType.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificationCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificationCreatedAt_Internalname, "Created At", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNotificationCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNotificationCreatedAt_Internalname, context.localUtil.TToC( A385NotificationCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A385NotificationCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificationCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificationCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_BCNotification.htm");
         GxWebStd.gx_bitmap( context, edtNotificationCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNotificationCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_BCNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotificationStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotificationStatus_Internalname, "Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotificationStatus, cmbNotificationStatus_Internalname, StringUtil.RTrim( A386NotificationStatus), 1, cmbNotificationStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNotificationStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_BCNotification.htm");
         cmbNotificationStatus.CurrentValue = StringUtil.RTrim( A386NotificationStatus);
         AssignProp("", false, cmbNotificationStatus_Internalname, "Values", (string)(cmbNotificationStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserId_Internalname, "Usuário", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserId_Internalname, ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", ""))), ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( ((edtSecUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9") : context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecUserId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_BCNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificationLink_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificationLink_Internalname, "Link", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificationLink_Internalname, A397NotificationLink, StringUtil.RTrim( context.localUtil.Format( A397NotificationLink, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", A397NotificationLink, "_blank", "", "", edtNotificationLink_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificationLink_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_BCNotification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_BCNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_BCNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_BCNotification.htm");
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
            Z381NotificationId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z381NotificationId"), ",", "."), 18, MidpointRounding.ToEven));
            Z382NotificationTitle = cgiGet( "Z382NotificationTitle");
            n382NotificationTitle = (String.IsNullOrEmpty(StringUtil.RTrim( A382NotificationTitle)) ? true : false);
            Z383NotificationMessage = cgiGet( "Z383NotificationMessage");
            n383NotificationMessage = (String.IsNullOrEmpty(StringUtil.RTrim( A383NotificationMessage)) ? true : false);
            Z384NotificationType = cgiGet( "Z384NotificationType");
            n384NotificationType = (String.IsNullOrEmpty(StringUtil.RTrim( A384NotificationType)) ? true : false);
            Z385NotificationCreatedAt = context.localUtil.CToT( cgiGet( "Z385NotificationCreatedAt"), 0);
            n385NotificationCreatedAt = ((DateTime.MinValue==A385NotificationCreatedAt) ? true : false);
            Z386NotificationStatus = cgiGet( "Z386NotificationStatus");
            n386NotificationStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A386NotificationStatus)) ? true : false);
            Z397NotificationLink = cgiGet( "Z397NotificationLink");
            n397NotificationLink = (String.IsNullOrEmpty(StringUtil.RTrim( A397NotificationLink)) ? true : false);
            Z133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z133SecUserId"), ",", "."), 18, MidpointRounding.ToEven));
            n133SecUserId = ((0==A133SecUserId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtNotificationId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNotificationId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A381NotificationId = 0;
               n381NotificationId = false;
               AssignAttri("", false, "A381NotificationId", StringUtil.LTrimStr( (decimal)(A381NotificationId), 9, 0));
            }
            else
            {
               A381NotificationId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNotificationId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n381NotificationId = false;
               AssignAttri("", false, "A381NotificationId", StringUtil.LTrimStr( (decimal)(A381NotificationId), 9, 0));
            }
            A382NotificationTitle = cgiGet( edtNotificationTitle_Internalname);
            n382NotificationTitle = false;
            AssignAttri("", false, "A382NotificationTitle", A382NotificationTitle);
            n382NotificationTitle = (String.IsNullOrEmpty(StringUtil.RTrim( A382NotificationTitle)) ? true : false);
            A383NotificationMessage = cgiGet( edtNotificationMessage_Internalname);
            n383NotificationMessage = false;
            AssignAttri("", false, "A383NotificationMessage", A383NotificationMessage);
            n383NotificationMessage = (String.IsNullOrEmpty(StringUtil.RTrim( A383NotificationMessage)) ? true : false);
            cmbNotificationType.CurrentValue = cgiGet( cmbNotificationType_Internalname);
            A384NotificationType = cgiGet( cmbNotificationType_Internalname);
            n384NotificationType = false;
            AssignAttri("", false, "A384NotificationType", A384NotificationType);
            n384NotificationType = (String.IsNullOrEmpty(StringUtil.RTrim( A384NotificationType)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtNotificationCreatedAt_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Notification Created At"}), 1, "NOTIFICATIONCREATEDAT");
               AnyError = 1;
               GX_FocusControl = edtNotificationCreatedAt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
               n385NotificationCreatedAt = false;
               AssignAttri("", false, "A385NotificationCreatedAt", context.localUtil.TToC( A385NotificationCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A385NotificationCreatedAt = context.localUtil.CToT( cgiGet( edtNotificationCreatedAt_Internalname));
               n385NotificationCreatedAt = false;
               AssignAttri("", false, "A385NotificationCreatedAt", context.localUtil.TToC( A385NotificationCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            n385NotificationCreatedAt = ((DateTime.MinValue==A385NotificationCreatedAt) ? true : false);
            cmbNotificationStatus.CurrentValue = cgiGet( cmbNotificationStatus_Internalname);
            A386NotificationStatus = cgiGet( cmbNotificationStatus_Internalname);
            n386NotificationStatus = false;
            AssignAttri("", false, "A386NotificationStatus", A386NotificationStatus);
            n386NotificationStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A386NotificationStatus)) ? true : false);
            n133SecUserId = ((StringUtil.StrCmp(cgiGet( edtSecUserId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A133SecUserId = 0;
               n133SecUserId = false;
               AssignAttri("", false, "A133SecUserId", (n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            }
            else
            {
               A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A133SecUserId", (n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            }
            A397NotificationLink = cgiGet( edtNotificationLink_Internalname);
            n397NotificationLink = false;
            AssignAttri("", false, "A397NotificationLink", A397NotificationLink);
            n397NotificationLink = (String.IsNullOrEmpty(StringUtil.RTrim( A397NotificationLink)) ? true : false);
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
               A381NotificationId = (int)(Math.Round(NumberUtil.Val( GetPar( "NotificationId"), "."), 18, MidpointRounding.ToEven));
               n381NotificationId = false;
               AssignAttri("", false, "A381NotificationId", StringUtil.LTrimStr( (decimal)(A381NotificationId), 9, 0));
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
               InitAll1H56( ) ;
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
         DisableAttributes1H56( ) ;
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

      protected void ResetCaption1H0( )
      {
      }

      protected void ZM1H56( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z382NotificationTitle = T001H3_A382NotificationTitle[0];
               Z383NotificationMessage = T001H3_A383NotificationMessage[0];
               Z384NotificationType = T001H3_A384NotificationType[0];
               Z385NotificationCreatedAt = T001H3_A385NotificationCreatedAt[0];
               Z386NotificationStatus = T001H3_A386NotificationStatus[0];
               Z397NotificationLink = T001H3_A397NotificationLink[0];
               Z133SecUserId = T001H3_A133SecUserId[0];
            }
            else
            {
               Z382NotificationTitle = A382NotificationTitle;
               Z383NotificationMessage = A383NotificationMessage;
               Z384NotificationType = A384NotificationType;
               Z385NotificationCreatedAt = A385NotificationCreatedAt;
               Z386NotificationStatus = A386NotificationStatus;
               Z397NotificationLink = A397NotificationLink;
               Z133SecUserId = A133SecUserId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z381NotificationId = A381NotificationId;
            Z382NotificationTitle = A382NotificationTitle;
            Z383NotificationMessage = A383NotificationMessage;
            Z384NotificationType = A384NotificationType;
            Z385NotificationCreatedAt = A385NotificationCreatedAt;
            Z386NotificationStatus = A386NotificationStatus;
            Z397NotificationLink = A397NotificationLink;
            Z133SecUserId = A133SecUserId;
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

      protected void Load1H56( )
      {
         /* Using cursor T001H5 */
         pr_default.execute(3, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound56 = 1;
            A382NotificationTitle = T001H5_A382NotificationTitle[0];
            n382NotificationTitle = T001H5_n382NotificationTitle[0];
            AssignAttri("", false, "A382NotificationTitle", A382NotificationTitle);
            A383NotificationMessage = T001H5_A383NotificationMessage[0];
            n383NotificationMessage = T001H5_n383NotificationMessage[0];
            AssignAttri("", false, "A383NotificationMessage", A383NotificationMessage);
            A384NotificationType = T001H5_A384NotificationType[0];
            n384NotificationType = T001H5_n384NotificationType[0];
            AssignAttri("", false, "A384NotificationType", A384NotificationType);
            A385NotificationCreatedAt = T001H5_A385NotificationCreatedAt[0];
            n385NotificationCreatedAt = T001H5_n385NotificationCreatedAt[0];
            AssignAttri("", false, "A385NotificationCreatedAt", context.localUtil.TToC( A385NotificationCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A386NotificationStatus = T001H5_A386NotificationStatus[0];
            n386NotificationStatus = T001H5_n386NotificationStatus[0];
            AssignAttri("", false, "A386NotificationStatus", A386NotificationStatus);
            A397NotificationLink = T001H5_A397NotificationLink[0];
            n397NotificationLink = T001H5_n397NotificationLink[0];
            AssignAttri("", false, "A397NotificationLink", A397NotificationLink);
            A133SecUserId = T001H5_A133SecUserId[0];
            n133SecUserId = T001H5_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            ZM1H56( -5) ;
         }
         pr_default.close(3);
         OnLoadActions1H56( ) ;
      }

      protected void OnLoadActions1H56( )
      {
         if ( (0==A133SecUserId) )
         {
            A133SecUserId = 0;
            n133SecUserId = false;
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            n133SecUserId = true;
            n133SecUserId = true;
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
         }
      }

      protected void CheckExtendedTable1H56( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A384NotificationType, "Internal") == 0 ) || ( StringUtil.StrCmp(A384NotificationType, "Email") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A384NotificationType)) ) )
         {
            GX_msglist.addItem("Campo Notification Type fora do intervalo", "OutOfRange", 1, "NOTIFICATIONTYPE");
            AnyError = 1;
            GX_FocusControl = cmbNotificationType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A386NotificationStatus, "Pending") == 0 ) || ( StringUtil.StrCmp(A386NotificationStatus, "Sent") == 0 ) || ( StringUtil.StrCmp(A386NotificationStatus, "Read") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A386NotificationStatus)) ) )
         {
            GX_msglist.addItem("Campo Notification Status fora do intervalo", "OutOfRange", 1, "NOTIFICATIONSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbNotificationStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A133SecUserId) )
         {
            A133SecUserId = 0;
            n133SecUserId = false;
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            n133SecUserId = true;
            n133SecUserId = true;
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
         }
         /* Using cursor T001H4 */
         pr_default.execute(2, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A397NotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || String.IsNullOrEmpty(StringUtil.RTrim( A397NotificationLink)) ) )
         {
            GX_msglist.addItem("O valor de Notification Link não coincide com o padrão especificado", "OutOfRange", 1, "NOTIFICATIONLINK");
            AnyError = 1;
            GX_FocusControl = edtNotificationLink_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1H56( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( short A133SecUserId )
      {
         /* Using cursor T001H6 */
         pr_default.execute(4, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1H56( )
      {
         /* Using cursor T001H7 */
         pr_default.execute(5, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound56 = 1;
         }
         else
         {
            RcdFound56 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001H3 */
         pr_default.execute(1, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1H56( 5) ;
            RcdFound56 = 1;
            A381NotificationId = T001H3_A381NotificationId[0];
            n381NotificationId = T001H3_n381NotificationId[0];
            AssignAttri("", false, "A381NotificationId", StringUtil.LTrimStr( (decimal)(A381NotificationId), 9, 0));
            A382NotificationTitle = T001H3_A382NotificationTitle[0];
            n382NotificationTitle = T001H3_n382NotificationTitle[0];
            AssignAttri("", false, "A382NotificationTitle", A382NotificationTitle);
            A383NotificationMessage = T001H3_A383NotificationMessage[0];
            n383NotificationMessage = T001H3_n383NotificationMessage[0];
            AssignAttri("", false, "A383NotificationMessage", A383NotificationMessage);
            A384NotificationType = T001H3_A384NotificationType[0];
            n384NotificationType = T001H3_n384NotificationType[0];
            AssignAttri("", false, "A384NotificationType", A384NotificationType);
            A385NotificationCreatedAt = T001H3_A385NotificationCreatedAt[0];
            n385NotificationCreatedAt = T001H3_n385NotificationCreatedAt[0];
            AssignAttri("", false, "A385NotificationCreatedAt", context.localUtil.TToC( A385NotificationCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A386NotificationStatus = T001H3_A386NotificationStatus[0];
            n386NotificationStatus = T001H3_n386NotificationStatus[0];
            AssignAttri("", false, "A386NotificationStatus", A386NotificationStatus);
            A397NotificationLink = T001H3_A397NotificationLink[0];
            n397NotificationLink = T001H3_n397NotificationLink[0];
            AssignAttri("", false, "A397NotificationLink", A397NotificationLink);
            A133SecUserId = T001H3_A133SecUserId[0];
            n133SecUserId = T001H3_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            Z381NotificationId = A381NotificationId;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1H56( ) ;
            if ( AnyError == 1 )
            {
               RcdFound56 = 0;
               InitializeNonKey1H56( ) ;
            }
            Gx_mode = sMode56;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound56 = 0;
            InitializeNonKey1H56( ) ;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode56;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1H56( ) ;
         if ( RcdFound56 == 0 )
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
         RcdFound56 = 0;
         /* Using cursor T001H8 */
         pr_default.execute(6, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001H8_A381NotificationId[0] < A381NotificationId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001H8_A381NotificationId[0] > A381NotificationId ) ) )
            {
               A381NotificationId = T001H8_A381NotificationId[0];
               n381NotificationId = T001H8_n381NotificationId[0];
               AssignAttri("", false, "A381NotificationId", StringUtil.LTrimStr( (decimal)(A381NotificationId), 9, 0));
               RcdFound56 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound56 = 0;
         /* Using cursor T001H9 */
         pr_default.execute(7, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001H9_A381NotificationId[0] > A381NotificationId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001H9_A381NotificationId[0] < A381NotificationId ) ) )
            {
               A381NotificationId = T001H9_A381NotificationId[0];
               n381NotificationId = T001H9_n381NotificationId[0];
               AssignAttri("", false, "A381NotificationId", StringUtil.LTrimStr( (decimal)(A381NotificationId), 9, 0));
               RcdFound56 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1H56( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1H56( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound56 == 1 )
            {
               if ( A381NotificationId != Z381NotificationId )
               {
                  A381NotificationId = Z381NotificationId;
                  n381NotificationId = false;
                  AssignAttri("", false, "A381NotificationId", StringUtil.LTrimStr( (decimal)(A381NotificationId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "NOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1H56( ) ;
                  GX_FocusControl = edtNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A381NotificationId != Z381NotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1H56( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "NOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1H56( ) ;
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
         if ( A381NotificationId != Z381NotificationId )
         {
            A381NotificationId = Z381NotificationId;
            n381NotificationId = false;
            AssignAttri("", false, "A381NotificationId", StringUtil.LTrimStr( (decimal)(A381NotificationId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "NOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNotificationId_Internalname;
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
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "NOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1H56( ) ;
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1H56( ) ;
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
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificationTitle_Internalname;
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
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificationTitle_Internalname;
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
         ScanStart1H56( ) ;
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound56 != 0 )
            {
               ScanNext1H56( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1H56( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1H56( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001H2 */
            pr_default.execute(0, new Object[] {n381NotificationId, A381NotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Notification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z382NotificationTitle, T001H2_A382NotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z383NotificationMessage, T001H2_A383NotificationMessage[0]) != 0 ) || ( StringUtil.StrCmp(Z384NotificationType, T001H2_A384NotificationType[0]) != 0 ) || ( Z385NotificationCreatedAt != T001H2_A385NotificationCreatedAt[0] ) || ( StringUtil.StrCmp(Z386NotificationStatus, T001H2_A386NotificationStatus[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z397NotificationLink, T001H2_A397NotificationLink[0]) != 0 ) || ( Z133SecUserId != T001H2_A133SecUserId[0] ) )
            {
               if ( StringUtil.StrCmp(Z382NotificationTitle, T001H2_A382NotificationTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("bcnotification:[seudo value changed for attri]"+"NotificationTitle");
                  GXUtil.WriteLogRaw("Old: ",Z382NotificationTitle);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A382NotificationTitle[0]);
               }
               if ( StringUtil.StrCmp(Z383NotificationMessage, T001H2_A383NotificationMessage[0]) != 0 )
               {
                  GXUtil.WriteLog("bcnotification:[seudo value changed for attri]"+"NotificationMessage");
                  GXUtil.WriteLogRaw("Old: ",Z383NotificationMessage);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A383NotificationMessage[0]);
               }
               if ( StringUtil.StrCmp(Z384NotificationType, T001H2_A384NotificationType[0]) != 0 )
               {
                  GXUtil.WriteLog("bcnotification:[seudo value changed for attri]"+"NotificationType");
                  GXUtil.WriteLogRaw("Old: ",Z384NotificationType);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A384NotificationType[0]);
               }
               if ( Z385NotificationCreatedAt != T001H2_A385NotificationCreatedAt[0] )
               {
                  GXUtil.WriteLog("bcnotification:[seudo value changed for attri]"+"NotificationCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z385NotificationCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A385NotificationCreatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z386NotificationStatus, T001H2_A386NotificationStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("bcnotification:[seudo value changed for attri]"+"NotificationStatus");
                  GXUtil.WriteLogRaw("Old: ",Z386NotificationStatus);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A386NotificationStatus[0]);
               }
               if ( StringUtil.StrCmp(Z397NotificationLink, T001H2_A397NotificationLink[0]) != 0 )
               {
                  GXUtil.WriteLog("bcnotification:[seudo value changed for attri]"+"NotificationLink");
                  GXUtil.WriteLogRaw("Old: ",Z397NotificationLink);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A397NotificationLink[0]);
               }
               if ( Z133SecUserId != T001H2_A133SecUserId[0] )
               {
                  GXUtil.WriteLog("bcnotification:[seudo value changed for attri]"+"SecUserId");
                  GXUtil.WriteLogRaw("Old: ",Z133SecUserId);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A133SecUserId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Notification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1H56( )
      {
         BeforeValidate1H56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H56( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1H56( 0) ;
            CheckOptimisticConcurrency1H56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1H56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001H10 */
                     pr_default.execute(8, new Object[] {n382NotificationTitle, A382NotificationTitle, n383NotificationMessage, A383NotificationMessage, n384NotificationType, A384NotificationType, n385NotificationCreatedAt, A385NotificationCreatedAt, n386NotificationStatus, A386NotificationStatus, n397NotificationLink, A397NotificationLink, n133SecUserId, A133SecUserId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001H11 */
                     pr_default.execute(9);
                     A381NotificationId = T001H11_A381NotificationId[0];
                     n381NotificationId = T001H11_n381NotificationId[0];
                     AssignAttri("", false, "A381NotificationId", StringUtil.LTrimStr( (decimal)(A381NotificationId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Notification");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1H0( ) ;
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
               Load1H56( ) ;
            }
            EndLevel1H56( ) ;
         }
         CloseExtendedTableCursors1H56( ) ;
      }

      protected void Update1H56( )
      {
         BeforeValidate1H56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H56( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1H56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001H12 */
                     pr_default.execute(10, new Object[] {n382NotificationTitle, A382NotificationTitle, n383NotificationMessage, A383NotificationMessage, n384NotificationType, A384NotificationType, n385NotificationCreatedAt, A385NotificationCreatedAt, n386NotificationStatus, A386NotificationStatus, n397NotificationLink, A397NotificationLink, n133SecUserId, A133SecUserId, n381NotificationId, A381NotificationId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Notification");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Notification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1H56( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1H0( ) ;
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
            EndLevel1H56( ) ;
         }
         CloseExtendedTableCursors1H56( ) ;
      }

      protected void DeferredUpdate1H56( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1H56( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H56( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1H56( ) ;
            AfterConfirm1H56( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1H56( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001H13 */
                  pr_default.execute(11, new Object[] {n381NotificationId, A381NotificationId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Notification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound56 == 0 )
                        {
                           InitAll1H56( ) ;
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
                        ResetCaption1H0( ) ;
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
         sMode56 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1H56( ) ;
         Gx_mode = sMode56;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1H56( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001H14 */
            pr_default.execute(12, new Object[] {n381NotificationId, A381NotificationId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"EmailQueue"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T001H15 */
            pr_default.execute(13, new Object[] {n381NotificationId, A381NotificationId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"UserNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel1H56( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1H56( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues1H0( ) ;
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

      public void ScanStart1H56( )
      {
         /* Using cursor T001H16 */
         pr_default.execute(14);
         RcdFound56 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound56 = 1;
            A381NotificationId = T001H16_A381NotificationId[0];
            n381NotificationId = T001H16_n381NotificationId[0];
            AssignAttri("", false, "A381NotificationId", StringUtil.LTrimStr( (decimal)(A381NotificationId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1H56( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound56 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound56 = 1;
            A381NotificationId = T001H16_A381NotificationId[0];
            n381NotificationId = T001H16_n381NotificationId[0];
            AssignAttri("", false, "A381NotificationId", StringUtil.LTrimStr( (decimal)(A381NotificationId), 9, 0));
         }
      }

      protected void ScanEnd1H56( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1H56( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1H56( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1H56( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1H56( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1H56( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1H56( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1H56( )
      {
         edtNotificationId_Enabled = 0;
         AssignProp("", false, edtNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificationId_Enabled), 5, 0), true);
         edtNotificationTitle_Enabled = 0;
         AssignProp("", false, edtNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificationTitle_Enabled), 5, 0), true);
         edtNotificationMessage_Enabled = 0;
         AssignProp("", false, edtNotificationMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificationMessage_Enabled), 5, 0), true);
         cmbNotificationType.Enabled = 0;
         AssignProp("", false, cmbNotificationType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificationType.Enabled), 5, 0), true);
         edtNotificationCreatedAt_Enabled = 0;
         AssignProp("", false, edtNotificationCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificationCreatedAt_Enabled), 5, 0), true);
         cmbNotificationStatus.Enabled = 0;
         AssignProp("", false, cmbNotificationStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificationStatus.Enabled), 5, 0), true);
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         edtNotificationLink_Enabled = 0;
         AssignProp("", false, edtNotificationLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificationLink_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1H56( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1H0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("bcnotification") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z381NotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z381NotificationId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z382NotificationTitle", Z382NotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z383NotificationMessage", Z383NotificationMessage);
         GxWebStd.gx_hidden_field( context, "Z384NotificationType", Z384NotificationType);
         GxWebStd.gx_hidden_field( context, "Z385NotificationCreatedAt", context.localUtil.TToC( Z385NotificationCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z386NotificationStatus", Z386NotificationStatus);
         GxWebStd.gx_hidden_field( context, "Z397NotificationLink", Z397NotificationLink);
         GxWebStd.gx_hidden_field( context, "Z133SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133SecUserId), 4, 0, ",", "")));
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
         return formatLink("bcnotification")  ;
      }

      public override string GetPgmname( )
      {
         return "BCNotification" ;
      }

      public override string GetPgmdesc( )
      {
         return "BCNotification" ;
      }

      protected void InitializeNonKey1H56( )
      {
         A382NotificationTitle = "";
         n382NotificationTitle = false;
         AssignAttri("", false, "A382NotificationTitle", A382NotificationTitle);
         n382NotificationTitle = (String.IsNullOrEmpty(StringUtil.RTrim( A382NotificationTitle)) ? true : false);
         A383NotificationMessage = "";
         n383NotificationMessage = false;
         AssignAttri("", false, "A383NotificationMessage", A383NotificationMessage);
         n383NotificationMessage = (String.IsNullOrEmpty(StringUtil.RTrim( A383NotificationMessage)) ? true : false);
         A384NotificationType = "";
         n384NotificationType = false;
         AssignAttri("", false, "A384NotificationType", A384NotificationType);
         n384NotificationType = (String.IsNullOrEmpty(StringUtil.RTrim( A384NotificationType)) ? true : false);
         A385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
         n385NotificationCreatedAt = false;
         AssignAttri("", false, "A385NotificationCreatedAt", context.localUtil.TToC( A385NotificationCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         n385NotificationCreatedAt = ((DateTime.MinValue==A385NotificationCreatedAt) ? true : false);
         A386NotificationStatus = "";
         n386NotificationStatus = false;
         AssignAttri("", false, "A386NotificationStatus", A386NotificationStatus);
         n386NotificationStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A386NotificationStatus)) ? true : false);
         A133SecUserId = 0;
         n133SecUserId = false;
         AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
         n133SecUserId = ((0==A133SecUserId) ? true : false);
         A397NotificationLink = "";
         n397NotificationLink = false;
         AssignAttri("", false, "A397NotificationLink", A397NotificationLink);
         n397NotificationLink = (String.IsNullOrEmpty(StringUtil.RTrim( A397NotificationLink)) ? true : false);
         Z382NotificationTitle = "";
         Z383NotificationMessage = "";
         Z384NotificationType = "";
         Z385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
         Z386NotificationStatus = "";
         Z397NotificationLink = "";
         Z133SecUserId = 0;
      }

      protected void InitAll1H56( )
      {
         A381NotificationId = 0;
         n381NotificationId = false;
         AssignAttri("", false, "A381NotificationId", StringUtil.LTrimStr( (decimal)(A381NotificationId), 9, 0));
         InitializeNonKey1H56( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019162783", true, true);
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
         context.AddJavascriptSource("bcnotification.js", "?202561019162783", false, true);
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
         edtNotificationId_Internalname = "NOTIFICATIONID";
         edtNotificationTitle_Internalname = "NOTIFICATIONTITLE";
         edtNotificationMessage_Internalname = "NOTIFICATIONMESSAGE";
         cmbNotificationType_Internalname = "NOTIFICATIONTYPE";
         edtNotificationCreatedAt_Internalname = "NOTIFICATIONCREATEDAT";
         cmbNotificationStatus_Internalname = "NOTIFICATIONSTATUS";
         edtSecUserId_Internalname = "SECUSERID";
         edtNotificationLink_Internalname = "NOTIFICATIONLINK";
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
         Form.Caption = "BCNotification";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtNotificationLink_Jsonclick = "";
         edtNotificationLink_Enabled = 1;
         edtSecUserId_Jsonclick = "";
         edtSecUserId_Enabled = 1;
         cmbNotificationStatus_Jsonclick = "";
         cmbNotificationStatus.Enabled = 1;
         edtNotificationCreatedAt_Jsonclick = "";
         edtNotificationCreatedAt_Enabled = 1;
         cmbNotificationType_Jsonclick = "";
         cmbNotificationType.Enabled = 1;
         edtNotificationMessage_Jsonclick = "";
         edtNotificationMessage_Enabled = 1;
         edtNotificationTitle_Jsonclick = "";
         edtNotificationTitle_Enabled = 1;
         edtNotificationId_Jsonclick = "";
         edtNotificationId_Enabled = 1;
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
         cmbNotificationType.Name = "NOTIFICATIONTYPE";
         cmbNotificationType.WebTags = "";
         cmbNotificationType.addItem("Internal", "Internal", 0);
         cmbNotificationType.addItem("Email", "Email", 0);
         if ( cmbNotificationType.ItemCount > 0 )
         {
            A384NotificationType = cmbNotificationType.getValidValue(A384NotificationType);
            n384NotificationType = false;
            AssignAttri("", false, "A384NotificationType", A384NotificationType);
         }
         cmbNotificationStatus.Name = "NOTIFICATIONSTATUS";
         cmbNotificationStatus.WebTags = "";
         cmbNotificationStatus.addItem("Pending", "Pending", 0);
         cmbNotificationStatus.addItem("Sent", "Sent", 0);
         cmbNotificationStatus.addItem("Read", "Read", 0);
         if ( cmbNotificationStatus.ItemCount > 0 )
         {
            A386NotificationStatus = cmbNotificationStatus.getValidValue(A386NotificationStatus);
            n386NotificationStatus = false;
            AssignAttri("", false, "A386NotificationStatus", A386NotificationStatus);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtNotificationTitle_Internalname;
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

      public void Valid_Notificationid( )
      {
         n386NotificationStatus = false;
         A386NotificationStatus = cmbNotificationStatus.CurrentValue;
         n386NotificationStatus = false;
         cmbNotificationStatus.CurrentValue = A386NotificationStatus;
         n384NotificationType = false;
         A384NotificationType = cmbNotificationType.CurrentValue;
         n384NotificationType = false;
         cmbNotificationType.CurrentValue = A384NotificationType;
         n381NotificationId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbNotificationType.ItemCount > 0 )
         {
            A384NotificationType = cmbNotificationType.getValidValue(A384NotificationType);
            n384NotificationType = false;
            cmbNotificationType.CurrentValue = A384NotificationType;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificationType.CurrentValue = StringUtil.RTrim( A384NotificationType);
         }
         if ( cmbNotificationStatus.ItemCount > 0 )
         {
            A386NotificationStatus = cmbNotificationStatus.getValidValue(A386NotificationStatus);
            n386NotificationStatus = false;
            cmbNotificationStatus.CurrentValue = A386NotificationStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificationStatus.CurrentValue = StringUtil.RTrim( A386NotificationStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A382NotificationTitle", A382NotificationTitle);
         AssignAttri("", false, "A383NotificationMessage", A383NotificationMessage);
         AssignAttri("", false, "A384NotificationType", A384NotificationType);
         cmbNotificationType.CurrentValue = StringUtil.RTrim( A384NotificationType);
         AssignProp("", false, cmbNotificationType_Internalname, "Values", cmbNotificationType.ToJavascriptSource(), true);
         AssignAttri("", false, "A385NotificationCreatedAt", context.localUtil.TToC( A385NotificationCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A386NotificationStatus", A386NotificationStatus);
         cmbNotificationStatus.CurrentValue = StringUtil.RTrim( A386NotificationStatus);
         AssignProp("", false, cmbNotificationStatus_Internalname, "Values", cmbNotificationStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A397NotificationLink", A397NotificationLink);
         AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z381NotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z381NotificationId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z382NotificationTitle", Z382NotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z383NotificationMessage", Z383NotificationMessage);
         GxWebStd.gx_hidden_field( context, "Z384NotificationType", Z384NotificationType);
         GxWebStd.gx_hidden_field( context, "Z385NotificationCreatedAt", context.localUtil.TToC( Z385NotificationCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z386NotificationStatus", Z386NotificationStatus);
         GxWebStd.gx_hidden_field( context, "Z397NotificationLink", Z397NotificationLink);
         GxWebStd.gx_hidden_field( context, "Z133SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133SecUserId), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Secuserid( )
      {
         if ( (0==A133SecUserId) )
         {
            A133SecUserId = 0;
            n133SecUserId = false;
            n133SecUserId = true;
            n133SecUserId = true;
         }
         /* Using cursor T001H17 */
         pr_default.execute(15, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
            }
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_NOTIFICATIONID","""{"handler":"Valid_Notificationid","iparms":[{"av":"cmbNotificationStatus"},{"av":"A386NotificationStatus","fld":"NOTIFICATIONSTATUS","type":"svchar"},{"av":"cmbNotificationType"},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A381NotificationId","fld":"NOTIFICATIONID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_NOTIFICATIONID",""","oparms":[{"av":"A382NotificationTitle","fld":"NOTIFICATIONTITLE","type":"svchar"},{"av":"A383NotificationMessage","fld":"NOTIFICATIONMESSAGE","type":"svchar"},{"av":"cmbNotificationType"},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE","type":"svchar"},{"av":"A385NotificationCreatedAt","fld":"NOTIFICATIONCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"cmbNotificationStatus"},{"av":"A386NotificationStatus","fld":"NOTIFICATIONSTATUS","type":"svchar"},{"av":"A397NotificationLink","fld":"NOTIFICATIONLINK","type":"svchar"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","nullAv":"n133SecUserId","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z381NotificationId","type":"int"},{"av":"Z382NotificationTitle","type":"svchar"},{"av":"Z383NotificationMessage","type":"svchar"},{"av":"Z384NotificationType","type":"svchar"},{"av":"Z385NotificationCreatedAt","type":"dtime"},{"av":"Z386NotificationStatus","type":"svchar"},{"av":"Z397NotificationLink","type":"svchar"},{"av":"Z133SecUserId","type":"int"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_NOTIFICATIONTYPE","""{"handler":"Valid_Notificationtype","iparms":[]}""");
         setEventMetadata("VALID_NOTIFICATIONSTATUS","""{"handler":"Valid_Notificationstatus","iparms":[]}""");
         setEventMetadata("VALID_SECUSERID","""{"handler":"Valid_Secuserid","iparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","nullAv":"n133SecUserId","type":"int"}]""");
         setEventMetadata("VALID_SECUSERID",""","oparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","nullAv":"n133SecUserId","type":"int"}]}""");
         setEventMetadata("VALID_NOTIFICATIONLINK","""{"handler":"Valid_Notificationlink","iparms":[]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z382NotificationTitle = "";
         Z383NotificationMessage = "";
         Z384NotificationType = "";
         Z385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
         Z386NotificationStatus = "";
         Z397NotificationLink = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A384NotificationType = "";
         A386NotificationStatus = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A382NotificationTitle = "";
         A383NotificationMessage = "";
         A385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
         A397NotificationLink = "";
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
         T001H5_A381NotificationId = new int[1] ;
         T001H5_n381NotificationId = new bool[] {false} ;
         T001H5_A382NotificationTitle = new string[] {""} ;
         T001H5_n382NotificationTitle = new bool[] {false} ;
         T001H5_A383NotificationMessage = new string[] {""} ;
         T001H5_n383NotificationMessage = new bool[] {false} ;
         T001H5_A384NotificationType = new string[] {""} ;
         T001H5_n384NotificationType = new bool[] {false} ;
         T001H5_A385NotificationCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001H5_n385NotificationCreatedAt = new bool[] {false} ;
         T001H5_A386NotificationStatus = new string[] {""} ;
         T001H5_n386NotificationStatus = new bool[] {false} ;
         T001H5_A397NotificationLink = new string[] {""} ;
         T001H5_n397NotificationLink = new bool[] {false} ;
         T001H5_A133SecUserId = new short[1] ;
         T001H5_n133SecUserId = new bool[] {false} ;
         T001H4_A133SecUserId = new short[1] ;
         T001H4_n133SecUserId = new bool[] {false} ;
         T001H6_A133SecUserId = new short[1] ;
         T001H6_n133SecUserId = new bool[] {false} ;
         T001H7_A381NotificationId = new int[1] ;
         T001H7_n381NotificationId = new bool[] {false} ;
         T001H3_A381NotificationId = new int[1] ;
         T001H3_n381NotificationId = new bool[] {false} ;
         T001H3_A382NotificationTitle = new string[] {""} ;
         T001H3_n382NotificationTitle = new bool[] {false} ;
         T001H3_A383NotificationMessage = new string[] {""} ;
         T001H3_n383NotificationMessage = new bool[] {false} ;
         T001H3_A384NotificationType = new string[] {""} ;
         T001H3_n384NotificationType = new bool[] {false} ;
         T001H3_A385NotificationCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001H3_n385NotificationCreatedAt = new bool[] {false} ;
         T001H3_A386NotificationStatus = new string[] {""} ;
         T001H3_n386NotificationStatus = new bool[] {false} ;
         T001H3_A397NotificationLink = new string[] {""} ;
         T001H3_n397NotificationLink = new bool[] {false} ;
         T001H3_A133SecUserId = new short[1] ;
         T001H3_n133SecUserId = new bool[] {false} ;
         sMode56 = "";
         T001H8_A381NotificationId = new int[1] ;
         T001H8_n381NotificationId = new bool[] {false} ;
         T001H9_A381NotificationId = new int[1] ;
         T001H9_n381NotificationId = new bool[] {false} ;
         T001H2_A381NotificationId = new int[1] ;
         T001H2_n381NotificationId = new bool[] {false} ;
         T001H2_A382NotificationTitle = new string[] {""} ;
         T001H2_n382NotificationTitle = new bool[] {false} ;
         T001H2_A383NotificationMessage = new string[] {""} ;
         T001H2_n383NotificationMessage = new bool[] {false} ;
         T001H2_A384NotificationType = new string[] {""} ;
         T001H2_n384NotificationType = new bool[] {false} ;
         T001H2_A385NotificationCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001H2_n385NotificationCreatedAt = new bool[] {false} ;
         T001H2_A386NotificationStatus = new string[] {""} ;
         T001H2_n386NotificationStatus = new bool[] {false} ;
         T001H2_A397NotificationLink = new string[] {""} ;
         T001H2_n397NotificationLink = new bool[] {false} ;
         T001H2_A133SecUserId = new short[1] ;
         T001H2_n133SecUserId = new bool[] {false} ;
         T001H11_A381NotificationId = new int[1] ;
         T001H11_n381NotificationId = new bool[] {false} ;
         T001H14_A392EmailQueueId = new int[1] ;
         T001H15_A387UserNotificationId = new int[1] ;
         T001H16_A381NotificationId = new int[1] ;
         T001H16_n381NotificationId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ382NotificationTitle = "";
         ZZ383NotificationMessage = "";
         ZZ384NotificationType = "";
         ZZ385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
         ZZ386NotificationStatus = "";
         ZZ397NotificationLink = "";
         T001H17_A133SecUserId = new short[1] ;
         T001H17_n133SecUserId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bcnotification__default(),
            new Object[][] {
                new Object[] {
               T001H2_A381NotificationId, T001H2_A382NotificationTitle, T001H2_n382NotificationTitle, T001H2_A383NotificationMessage, T001H2_n383NotificationMessage, T001H2_A384NotificationType, T001H2_n384NotificationType, T001H2_A385NotificationCreatedAt, T001H2_n385NotificationCreatedAt, T001H2_A386NotificationStatus,
               T001H2_n386NotificationStatus, T001H2_A397NotificationLink, T001H2_n397NotificationLink, T001H2_A133SecUserId, T001H2_n133SecUserId
               }
               , new Object[] {
               T001H3_A381NotificationId, T001H3_A382NotificationTitle, T001H3_n382NotificationTitle, T001H3_A383NotificationMessage, T001H3_n383NotificationMessage, T001H3_A384NotificationType, T001H3_n384NotificationType, T001H3_A385NotificationCreatedAt, T001H3_n385NotificationCreatedAt, T001H3_A386NotificationStatus,
               T001H3_n386NotificationStatus, T001H3_A397NotificationLink, T001H3_n397NotificationLink, T001H3_A133SecUserId, T001H3_n133SecUserId
               }
               , new Object[] {
               T001H4_A133SecUserId
               }
               , new Object[] {
               T001H5_A381NotificationId, T001H5_A382NotificationTitle, T001H5_n382NotificationTitle, T001H5_A383NotificationMessage, T001H5_n383NotificationMessage, T001H5_A384NotificationType, T001H5_n384NotificationType, T001H5_A385NotificationCreatedAt, T001H5_n385NotificationCreatedAt, T001H5_A386NotificationStatus,
               T001H5_n386NotificationStatus, T001H5_A397NotificationLink, T001H5_n397NotificationLink, T001H5_A133SecUserId, T001H5_n133SecUserId
               }
               , new Object[] {
               T001H6_A133SecUserId
               }
               , new Object[] {
               T001H7_A381NotificationId
               }
               , new Object[] {
               T001H8_A381NotificationId
               }
               , new Object[] {
               T001H9_A381NotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               T001H11_A381NotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001H14_A392EmailQueueId
               }
               , new Object[] {
               T001H15_A387UserNotificationId
               }
               , new Object[] {
               T001H16_A381NotificationId
               }
               , new Object[] {
               T001H17_A133SecUserId
               }
            }
         );
      }

      private short Z133SecUserId ;
      private short GxWebError ;
      private short A133SecUserId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound56 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ133SecUserId ;
      private int Z381NotificationId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A381NotificationId ;
      private int edtNotificationId_Enabled ;
      private int edtNotificationTitle_Enabled ;
      private int edtNotificationMessage_Enabled ;
      private int edtNotificationCreatedAt_Enabled ;
      private int edtSecUserId_Enabled ;
      private int edtNotificationLink_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ381NotificationId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNotificationId_Internalname ;
      private string cmbNotificationType_Internalname ;
      private string cmbNotificationStatus_Internalname ;
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
      private string edtNotificationId_Jsonclick ;
      private string edtNotificationTitle_Internalname ;
      private string edtNotificationTitle_Jsonclick ;
      private string edtNotificationMessage_Internalname ;
      private string edtNotificationMessage_Jsonclick ;
      private string cmbNotificationType_Jsonclick ;
      private string edtNotificationCreatedAt_Internalname ;
      private string edtNotificationCreatedAt_Jsonclick ;
      private string cmbNotificationStatus_Jsonclick ;
      private string edtSecUserId_Internalname ;
      private string edtSecUserId_Jsonclick ;
      private string edtNotificationLink_Internalname ;
      private string edtNotificationLink_Jsonclick ;
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
      private string sMode56 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z385NotificationCreatedAt ;
      private DateTime A385NotificationCreatedAt ;
      private DateTime ZZ385NotificationCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n133SecUserId ;
      private bool wbErr ;
      private bool n384NotificationType ;
      private bool n386NotificationStatus ;
      private bool n382NotificationTitle ;
      private bool n383NotificationMessage ;
      private bool n385NotificationCreatedAt ;
      private bool n397NotificationLink ;
      private bool n381NotificationId ;
      private bool Gx_longc ;
      private string Z382NotificationTitle ;
      private string Z383NotificationMessage ;
      private string Z384NotificationType ;
      private string Z386NotificationStatus ;
      private string Z397NotificationLink ;
      private string A384NotificationType ;
      private string A386NotificationStatus ;
      private string A382NotificationTitle ;
      private string A383NotificationMessage ;
      private string A397NotificationLink ;
      private string ZZ382NotificationTitle ;
      private string ZZ383NotificationMessage ;
      private string ZZ384NotificationType ;
      private string ZZ386NotificationStatus ;
      private string ZZ397NotificationLink ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbNotificationType ;
      private GXCombobox cmbNotificationStatus ;
      private IDataStoreProvider pr_default ;
      private int[] T001H5_A381NotificationId ;
      private bool[] T001H5_n381NotificationId ;
      private string[] T001H5_A382NotificationTitle ;
      private bool[] T001H5_n382NotificationTitle ;
      private string[] T001H5_A383NotificationMessage ;
      private bool[] T001H5_n383NotificationMessage ;
      private string[] T001H5_A384NotificationType ;
      private bool[] T001H5_n384NotificationType ;
      private DateTime[] T001H5_A385NotificationCreatedAt ;
      private bool[] T001H5_n385NotificationCreatedAt ;
      private string[] T001H5_A386NotificationStatus ;
      private bool[] T001H5_n386NotificationStatus ;
      private string[] T001H5_A397NotificationLink ;
      private bool[] T001H5_n397NotificationLink ;
      private short[] T001H5_A133SecUserId ;
      private bool[] T001H5_n133SecUserId ;
      private short[] T001H4_A133SecUserId ;
      private bool[] T001H4_n133SecUserId ;
      private short[] T001H6_A133SecUserId ;
      private bool[] T001H6_n133SecUserId ;
      private int[] T001H7_A381NotificationId ;
      private bool[] T001H7_n381NotificationId ;
      private int[] T001H3_A381NotificationId ;
      private bool[] T001H3_n381NotificationId ;
      private string[] T001H3_A382NotificationTitle ;
      private bool[] T001H3_n382NotificationTitle ;
      private string[] T001H3_A383NotificationMessage ;
      private bool[] T001H3_n383NotificationMessage ;
      private string[] T001H3_A384NotificationType ;
      private bool[] T001H3_n384NotificationType ;
      private DateTime[] T001H3_A385NotificationCreatedAt ;
      private bool[] T001H3_n385NotificationCreatedAt ;
      private string[] T001H3_A386NotificationStatus ;
      private bool[] T001H3_n386NotificationStatus ;
      private string[] T001H3_A397NotificationLink ;
      private bool[] T001H3_n397NotificationLink ;
      private short[] T001H3_A133SecUserId ;
      private bool[] T001H3_n133SecUserId ;
      private int[] T001H8_A381NotificationId ;
      private bool[] T001H8_n381NotificationId ;
      private int[] T001H9_A381NotificationId ;
      private bool[] T001H9_n381NotificationId ;
      private int[] T001H2_A381NotificationId ;
      private bool[] T001H2_n381NotificationId ;
      private string[] T001H2_A382NotificationTitle ;
      private bool[] T001H2_n382NotificationTitle ;
      private string[] T001H2_A383NotificationMessage ;
      private bool[] T001H2_n383NotificationMessage ;
      private string[] T001H2_A384NotificationType ;
      private bool[] T001H2_n384NotificationType ;
      private DateTime[] T001H2_A385NotificationCreatedAt ;
      private bool[] T001H2_n385NotificationCreatedAt ;
      private string[] T001H2_A386NotificationStatus ;
      private bool[] T001H2_n386NotificationStatus ;
      private string[] T001H2_A397NotificationLink ;
      private bool[] T001H2_n397NotificationLink ;
      private short[] T001H2_A133SecUserId ;
      private bool[] T001H2_n133SecUserId ;
      private int[] T001H11_A381NotificationId ;
      private bool[] T001H11_n381NotificationId ;
      private int[] T001H14_A392EmailQueueId ;
      private int[] T001H15_A387UserNotificationId ;
      private int[] T001H16_A381NotificationId ;
      private bool[] T001H16_n381NotificationId ;
      private short[] T001H17_A133SecUserId ;
      private bool[] T001H17_n133SecUserId ;
   }

   public class bcnotification__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001H2;
          prmT001H2 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001H3;
          prmT001H3 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001H4;
          prmT001H4 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001H5;
          prmT001H5 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001H6;
          prmT001H6 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001H7;
          prmT001H7 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001H8;
          prmT001H8 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001H9;
          prmT001H9 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001H10;
          prmT001H10 = new Object[] {
          new ParDef("NotificationTitle",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotificationMessage",GXType.VarChar,106,0){Nullable=true} ,
          new ParDef("NotificationType",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotificationCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificationStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotificationLink",GXType.VarChar,1000,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001H11;
          prmT001H11 = new Object[] {
          };
          Object[] prmT001H12;
          prmT001H12 = new Object[] {
          new ParDef("NotificationTitle",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotificationMessage",GXType.VarChar,106,0){Nullable=true} ,
          new ParDef("NotificationType",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotificationCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificationStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotificationLink",GXType.VarChar,1000,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001H13;
          prmT001H13 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001H14;
          prmT001H14 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001H15;
          prmT001H15 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001H16;
          prmT001H16 = new Object[] {
          };
          Object[] prmT001H17;
          prmT001H17 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001H2", "SELECT NotificationId, NotificationTitle, NotificationMessage, NotificationType, NotificationCreatedAt, NotificationStatus, NotificationLink, SecUserId FROM Notification WHERE NotificationId = :NotificationId  FOR UPDATE OF Notification NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001H2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001H3", "SELECT NotificationId, NotificationTitle, NotificationMessage, NotificationType, NotificationCreatedAt, NotificationStatus, NotificationLink, SecUserId FROM Notification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001H4", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001H5", "SELECT TM1.NotificationId, TM1.NotificationTitle, TM1.NotificationMessage, TM1.NotificationType, TM1.NotificationCreatedAt, TM1.NotificationStatus, TM1.NotificationLink, TM1.SecUserId FROM Notification TM1 WHERE TM1.NotificationId = :NotificationId ORDER BY TM1.NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001H6", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001H7", "SELECT NotificationId FROM Notification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001H8", "SELECT NotificationId FROM Notification WHERE ( NotificationId > :NotificationId) ORDER BY NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001H9", "SELECT NotificationId FROM Notification WHERE ( NotificationId < :NotificationId) ORDER BY NotificationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001H10", "SAVEPOINT gxupdate;INSERT INTO Notification(NotificationTitle, NotificationMessage, NotificationType, NotificationCreatedAt, NotificationStatus, NotificationLink, SecUserId) VALUES(:NotificationTitle, :NotificationMessage, :NotificationType, :NotificationCreatedAt, :NotificationStatus, :NotificationLink, :SecUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001H10)
             ,new CursorDef("T001H11", "SELECT currval('NotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001H12", "SAVEPOINT gxupdate;UPDATE Notification SET NotificationTitle=:NotificationTitle, NotificationMessage=:NotificationMessage, NotificationType=:NotificationType, NotificationCreatedAt=:NotificationCreatedAt, NotificationStatus=:NotificationStatus, NotificationLink=:NotificationLink, SecUserId=:SecUserId  WHERE NotificationId = :NotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001H12)
             ,new CursorDef("T001H13", "SAVEPOINT gxupdate;DELETE FROM Notification  WHERE NotificationId = :NotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001H13)
             ,new CursorDef("T001H14", "SELECT EmailQueueId FROM EmailQueue WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001H15", "SELECT UserNotificationId FROM UserNotification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001H16", "SELECT NotificationId FROM Notification ORDER BY NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H16,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001H17", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H17,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
