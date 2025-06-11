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
   public class emailqueue : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
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
            gxLoad_4( A381NotificationId) ;
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
         Form.Meta.addItem("description", "Email Queue", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEmailQueueId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public emailqueue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public emailqueue( IGxContext context )
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
         cmbEmailQueueStatus = new GXCombobox();
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
         if ( cmbEmailQueueStatus.ItemCount > 0 )
         {
            A394EmailQueueStatus = cmbEmailQueueStatus.getValidValue(A394EmailQueueStatus);
            n394EmailQueueStatus = false;
            AssignAttri("", false, "A394EmailQueueStatus", A394EmailQueueStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEmailQueueStatus.CurrentValue = StringUtil.RTrim( A394EmailQueueStatus);
            AssignProp("", false, cmbEmailQueueStatus_Internalname, "Values", cmbEmailQueueStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Email Queue", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_EmailQueue.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_EmailQueue.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_EmailQueue.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_EmailQueue.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_EmailQueue.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_EmailQueue.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmailQueueId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmailQueueId_Internalname, "Queue Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmailQueueId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A392EmailQueueId), 9, 0, ",", "")), StringUtil.LTrim( ((edtEmailQueueId_Enabled!=0) ? context.localUtil.Format( (decimal)(A392EmailQueueId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A392EmailQueueId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmailQueueId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmailQueueId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_EmailQueue.htm");
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
         GxWebStd.gx_single_line_edit( context, edtNotificationId_Internalname, ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ",", ""))), ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( ((edtNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A381NotificationId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A381NotificationId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNotificationId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_EmailQueue.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmailQueueRecipient_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmailQueueRecipient_Internalname, "Queue Recipient", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmailQueueRecipient_Internalname, A393EmailQueueRecipient, StringUtil.RTrim( context.localUtil.Format( A393EmailQueueRecipient, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A393EmailQueueRecipient, "", "", "", edtEmailQueueRecipient_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmailQueueRecipient_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_EmailQueue.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbEmailQueueStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbEmailQueueStatus_Internalname, "Queue Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbEmailQueueStatus, cmbEmailQueueStatus_Internalname, StringUtil.RTrim( A394EmailQueueStatus), 1, cmbEmailQueueStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbEmailQueueStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_EmailQueue.htm");
         cmbEmailQueueStatus.CurrentValue = StringUtil.RTrim( A394EmailQueueStatus);
         AssignProp("", false, cmbEmailQueueStatus_Internalname, "Values", (string)(cmbEmailQueueStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmailQueueSentAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmailQueueSentAt_Internalname, "Sent At", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtEmailQueueSentAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEmailQueueSentAt_Internalname, context.localUtil.TToC( A395EmailQueueSentAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A395EmailQueueSentAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmailQueueSentAt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmailQueueSentAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EmailQueue.htm");
         GxWebStd.gx_bitmap( context, edtEmailQueueSentAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEmailQueueSentAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_EmailQueue.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmailQueueErrorMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmailQueueErrorMessage_Internalname, "Error Message", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtEmailQueueErrorMessage_Internalname, A396EmailQueueErrorMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtEmailQueueErrorMessage_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_EmailQueue.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_EmailQueue.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_EmailQueue.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_EmailQueue.htm");
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
            Z392EmailQueueId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z392EmailQueueId"), ",", "."), 18, MidpointRounding.ToEven));
            Z393EmailQueueRecipient = cgiGet( "Z393EmailQueueRecipient");
            n393EmailQueueRecipient = (String.IsNullOrEmpty(StringUtil.RTrim( A393EmailQueueRecipient)) ? true : false);
            Z394EmailQueueStatus = cgiGet( "Z394EmailQueueStatus");
            n394EmailQueueStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A394EmailQueueStatus)) ? true : false);
            Z395EmailQueueSentAt = context.localUtil.CToT( cgiGet( "Z395EmailQueueSentAt"), 0);
            n395EmailQueueSentAt = ((DateTime.MinValue==A395EmailQueueSentAt) ? true : false);
            Z396EmailQueueErrorMessage = cgiGet( "Z396EmailQueueErrorMessage");
            n396EmailQueueErrorMessage = (String.IsNullOrEmpty(StringUtil.RTrim( A396EmailQueueErrorMessage)) ? true : false);
            Z381NotificationId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z381NotificationId"), ",", "."), 18, MidpointRounding.ToEven));
            n381NotificationId = ((0==A381NotificationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtEmailQueueId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmailQueueId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMAILQUEUEID");
               AnyError = 1;
               GX_FocusControl = edtEmailQueueId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A392EmailQueueId = 0;
               AssignAttri("", false, "A392EmailQueueId", StringUtil.LTrimStr( (decimal)(A392EmailQueueId), 9, 0));
            }
            else
            {
               A392EmailQueueId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEmailQueueId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A392EmailQueueId", StringUtil.LTrimStr( (decimal)(A392EmailQueueId), 9, 0));
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
            A393EmailQueueRecipient = cgiGet( edtEmailQueueRecipient_Internalname);
            n393EmailQueueRecipient = false;
            AssignAttri("", false, "A393EmailQueueRecipient", A393EmailQueueRecipient);
            n393EmailQueueRecipient = (String.IsNullOrEmpty(StringUtil.RTrim( A393EmailQueueRecipient)) ? true : false);
            cmbEmailQueueStatus.CurrentValue = cgiGet( cmbEmailQueueStatus_Internalname);
            A394EmailQueueStatus = cgiGet( cmbEmailQueueStatus_Internalname);
            n394EmailQueueStatus = false;
            AssignAttri("", false, "A394EmailQueueStatus", A394EmailQueueStatus);
            n394EmailQueueStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A394EmailQueueStatus)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtEmailQueueSentAt_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Email Queue Sent At"}), 1, "EMAILQUEUESENTAT");
               AnyError = 1;
               GX_FocusControl = edtEmailQueueSentAt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A395EmailQueueSentAt = (DateTime)(DateTime.MinValue);
               n395EmailQueueSentAt = false;
               AssignAttri("", false, "A395EmailQueueSentAt", context.localUtil.TToC( A395EmailQueueSentAt, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A395EmailQueueSentAt = context.localUtil.CToT( cgiGet( edtEmailQueueSentAt_Internalname));
               n395EmailQueueSentAt = false;
               AssignAttri("", false, "A395EmailQueueSentAt", context.localUtil.TToC( A395EmailQueueSentAt, 8, 5, 0, 3, "/", ":", " "));
            }
            n395EmailQueueSentAt = ((DateTime.MinValue==A395EmailQueueSentAt) ? true : false);
            A396EmailQueueErrorMessage = cgiGet( edtEmailQueueErrorMessage_Internalname);
            n396EmailQueueErrorMessage = false;
            AssignAttri("", false, "A396EmailQueueErrorMessage", A396EmailQueueErrorMessage);
            n396EmailQueueErrorMessage = (String.IsNullOrEmpty(StringUtil.RTrim( A396EmailQueueErrorMessage)) ? true : false);
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
               A392EmailQueueId = (int)(Math.Round(NumberUtil.Val( GetPar( "EmailQueueId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A392EmailQueueId", StringUtil.LTrimStr( (decimal)(A392EmailQueueId), 9, 0));
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
               InitAll1J58( ) ;
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
         DisableAttributes1J58( ) ;
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

      protected void ResetCaption1J0( )
      {
      }

      protected void ZM1J58( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z393EmailQueueRecipient = T001J3_A393EmailQueueRecipient[0];
               Z394EmailQueueStatus = T001J3_A394EmailQueueStatus[0];
               Z395EmailQueueSentAt = T001J3_A395EmailQueueSentAt[0];
               Z396EmailQueueErrorMessage = T001J3_A396EmailQueueErrorMessage[0];
               Z381NotificationId = T001J3_A381NotificationId[0];
            }
            else
            {
               Z393EmailQueueRecipient = A393EmailQueueRecipient;
               Z394EmailQueueStatus = A394EmailQueueStatus;
               Z395EmailQueueSentAt = A395EmailQueueSentAt;
               Z396EmailQueueErrorMessage = A396EmailQueueErrorMessage;
               Z381NotificationId = A381NotificationId;
            }
         }
         if ( GX_JID == -3 )
         {
            Z392EmailQueueId = A392EmailQueueId;
            Z393EmailQueueRecipient = A393EmailQueueRecipient;
            Z394EmailQueueStatus = A394EmailQueueStatus;
            Z395EmailQueueSentAt = A395EmailQueueSentAt;
            Z396EmailQueueErrorMessage = A396EmailQueueErrorMessage;
            Z381NotificationId = A381NotificationId;
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

      protected void Load1J58( )
      {
         /* Using cursor T001J5 */
         pr_default.execute(3, new Object[] {A392EmailQueueId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound58 = 1;
            A393EmailQueueRecipient = T001J5_A393EmailQueueRecipient[0];
            n393EmailQueueRecipient = T001J5_n393EmailQueueRecipient[0];
            AssignAttri("", false, "A393EmailQueueRecipient", A393EmailQueueRecipient);
            A394EmailQueueStatus = T001J5_A394EmailQueueStatus[0];
            n394EmailQueueStatus = T001J5_n394EmailQueueStatus[0];
            AssignAttri("", false, "A394EmailQueueStatus", A394EmailQueueStatus);
            A395EmailQueueSentAt = T001J5_A395EmailQueueSentAt[0];
            n395EmailQueueSentAt = T001J5_n395EmailQueueSentAt[0];
            AssignAttri("", false, "A395EmailQueueSentAt", context.localUtil.TToC( A395EmailQueueSentAt, 8, 5, 0, 3, "/", ":", " "));
            A396EmailQueueErrorMessage = T001J5_A396EmailQueueErrorMessage[0];
            n396EmailQueueErrorMessage = T001J5_n396EmailQueueErrorMessage[0];
            AssignAttri("", false, "A396EmailQueueErrorMessage", A396EmailQueueErrorMessage);
            A381NotificationId = T001J5_A381NotificationId[0];
            n381NotificationId = T001J5_n381NotificationId[0];
            AssignAttri("", false, "A381NotificationId", ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ".", ""))));
            ZM1J58( -3) ;
         }
         pr_default.close(3);
         OnLoadActions1J58( ) ;
      }

      protected void OnLoadActions1J58( )
      {
      }

      protected void CheckExtendedTable1J58( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001J4 */
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
         if ( ! ( GxRegex.IsMatch(A393EmailQueueRecipient,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A393EmailQueueRecipient)) ) )
         {
            GX_msglist.addItem("O valor de Email Queue Recipient não coincide com o padrão especificado", "OutOfRange", 1, "EMAILQUEUERECIPIENT");
            AnyError = 1;
            GX_FocusControl = edtEmailQueueRecipient_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A394EmailQueueStatus, "Pending") == 0 ) || ( StringUtil.StrCmp(A394EmailQueueStatus, "Sent") == 0 ) || ( StringUtil.StrCmp(A394EmailQueueStatus, "Failed") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A394EmailQueueStatus)) ) )
         {
            GX_msglist.addItem("Campo Email Queue Status fora do intervalo", "OutOfRange", 1, "EMAILQUEUESTATUS");
            AnyError = 1;
            GX_FocusControl = cmbEmailQueueStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1J58( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( int A381NotificationId )
      {
         /* Using cursor T001J6 */
         pr_default.execute(4, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(4) == 101) )
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
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1J58( )
      {
         /* Using cursor T001J7 */
         pr_default.execute(5, new Object[] {A392EmailQueueId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound58 = 1;
         }
         else
         {
            RcdFound58 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001J3 */
         pr_default.execute(1, new Object[] {A392EmailQueueId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1J58( 3) ;
            RcdFound58 = 1;
            A392EmailQueueId = T001J3_A392EmailQueueId[0];
            AssignAttri("", false, "A392EmailQueueId", StringUtil.LTrimStr( (decimal)(A392EmailQueueId), 9, 0));
            A393EmailQueueRecipient = T001J3_A393EmailQueueRecipient[0];
            n393EmailQueueRecipient = T001J3_n393EmailQueueRecipient[0];
            AssignAttri("", false, "A393EmailQueueRecipient", A393EmailQueueRecipient);
            A394EmailQueueStatus = T001J3_A394EmailQueueStatus[0];
            n394EmailQueueStatus = T001J3_n394EmailQueueStatus[0];
            AssignAttri("", false, "A394EmailQueueStatus", A394EmailQueueStatus);
            A395EmailQueueSentAt = T001J3_A395EmailQueueSentAt[0];
            n395EmailQueueSentAt = T001J3_n395EmailQueueSentAt[0];
            AssignAttri("", false, "A395EmailQueueSentAt", context.localUtil.TToC( A395EmailQueueSentAt, 8, 5, 0, 3, "/", ":", " "));
            A396EmailQueueErrorMessage = T001J3_A396EmailQueueErrorMessage[0];
            n396EmailQueueErrorMessage = T001J3_n396EmailQueueErrorMessage[0];
            AssignAttri("", false, "A396EmailQueueErrorMessage", A396EmailQueueErrorMessage);
            A381NotificationId = T001J3_A381NotificationId[0];
            n381NotificationId = T001J3_n381NotificationId[0];
            AssignAttri("", false, "A381NotificationId", ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ".", ""))));
            Z392EmailQueueId = A392EmailQueueId;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1J58( ) ;
            if ( AnyError == 1 )
            {
               RcdFound58 = 0;
               InitializeNonKey1J58( ) ;
            }
            Gx_mode = sMode58;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound58 = 0;
            InitializeNonKey1J58( ) ;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode58;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1J58( ) ;
         if ( RcdFound58 == 0 )
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
         RcdFound58 = 0;
         /* Using cursor T001J8 */
         pr_default.execute(6, new Object[] {A392EmailQueueId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001J8_A392EmailQueueId[0] < A392EmailQueueId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001J8_A392EmailQueueId[0] > A392EmailQueueId ) ) )
            {
               A392EmailQueueId = T001J8_A392EmailQueueId[0];
               AssignAttri("", false, "A392EmailQueueId", StringUtil.LTrimStr( (decimal)(A392EmailQueueId), 9, 0));
               RcdFound58 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound58 = 0;
         /* Using cursor T001J9 */
         pr_default.execute(7, new Object[] {A392EmailQueueId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001J9_A392EmailQueueId[0] > A392EmailQueueId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001J9_A392EmailQueueId[0] < A392EmailQueueId ) ) )
            {
               A392EmailQueueId = T001J9_A392EmailQueueId[0];
               AssignAttri("", false, "A392EmailQueueId", StringUtil.LTrimStr( (decimal)(A392EmailQueueId), 9, 0));
               RcdFound58 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1J58( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEmailQueueId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1J58( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound58 == 1 )
            {
               if ( A392EmailQueueId != Z392EmailQueueId )
               {
                  A392EmailQueueId = Z392EmailQueueId;
                  AssignAttri("", false, "A392EmailQueueId", StringUtil.LTrimStr( (decimal)(A392EmailQueueId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "EMAILQUEUEID");
                  AnyError = 1;
                  GX_FocusControl = edtEmailQueueId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEmailQueueId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1J58( ) ;
                  GX_FocusControl = edtEmailQueueId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A392EmailQueueId != Z392EmailQueueId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtEmailQueueId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1J58( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "EMAILQUEUEID");
                     AnyError = 1;
                     GX_FocusControl = edtEmailQueueId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtEmailQueueId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1J58( ) ;
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
         if ( A392EmailQueueId != Z392EmailQueueId )
         {
            A392EmailQueueId = Z392EmailQueueId;
            AssignAttri("", false, "A392EmailQueueId", StringUtil.LTrimStr( (decimal)(A392EmailQueueId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "EMAILQUEUEID");
            AnyError = 1;
            GX_FocusControl = edtEmailQueueId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEmailQueueId_Internalname;
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
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "EMAILQUEUEID");
            AnyError = 1;
            GX_FocusControl = edtEmailQueueId_Internalname;
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
         ScanStart1J58( ) ;
         if ( RcdFound58 == 0 )
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
         ScanEnd1J58( ) ;
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
         if ( RcdFound58 == 0 )
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
         if ( RcdFound58 == 0 )
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
         ScanStart1J58( ) ;
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound58 != 0 )
            {
               ScanNext1J58( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNotificationId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1J58( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1J58( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001J2 */
            pr_default.execute(0, new Object[] {A392EmailQueueId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmailQueue"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z393EmailQueueRecipient, T001J2_A393EmailQueueRecipient[0]) != 0 ) || ( StringUtil.StrCmp(Z394EmailQueueStatus, T001J2_A394EmailQueueStatus[0]) != 0 ) || ( Z395EmailQueueSentAt != T001J2_A395EmailQueueSentAt[0] ) || ( StringUtil.StrCmp(Z396EmailQueueErrorMessage, T001J2_A396EmailQueueErrorMessage[0]) != 0 ) || ( Z381NotificationId != T001J2_A381NotificationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z393EmailQueueRecipient, T001J2_A393EmailQueueRecipient[0]) != 0 )
               {
                  GXUtil.WriteLog("emailqueue:[seudo value changed for attri]"+"EmailQueueRecipient");
                  GXUtil.WriteLogRaw("Old: ",Z393EmailQueueRecipient);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A393EmailQueueRecipient[0]);
               }
               if ( StringUtil.StrCmp(Z394EmailQueueStatus, T001J2_A394EmailQueueStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("emailqueue:[seudo value changed for attri]"+"EmailQueueStatus");
                  GXUtil.WriteLogRaw("Old: ",Z394EmailQueueStatus);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A394EmailQueueStatus[0]);
               }
               if ( Z395EmailQueueSentAt != T001J2_A395EmailQueueSentAt[0] )
               {
                  GXUtil.WriteLog("emailqueue:[seudo value changed for attri]"+"EmailQueueSentAt");
                  GXUtil.WriteLogRaw("Old: ",Z395EmailQueueSentAt);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A395EmailQueueSentAt[0]);
               }
               if ( StringUtil.StrCmp(Z396EmailQueueErrorMessage, T001J2_A396EmailQueueErrorMessage[0]) != 0 )
               {
                  GXUtil.WriteLog("emailqueue:[seudo value changed for attri]"+"EmailQueueErrorMessage");
                  GXUtil.WriteLogRaw("Old: ",Z396EmailQueueErrorMessage);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A396EmailQueueErrorMessage[0]);
               }
               if ( Z381NotificationId != T001J2_A381NotificationId[0] )
               {
                  GXUtil.WriteLog("emailqueue:[seudo value changed for attri]"+"NotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z381NotificationId);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A381NotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EmailQueue"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1J58( )
      {
         BeforeValidate1J58( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1J58( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1J58( 0) ;
            CheckOptimisticConcurrency1J58( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1J58( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1J58( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001J10 */
                     pr_default.execute(8, new Object[] {n393EmailQueueRecipient, A393EmailQueueRecipient, n394EmailQueueStatus, A394EmailQueueStatus, n395EmailQueueSentAt, A395EmailQueueSentAt, n396EmailQueueErrorMessage, A396EmailQueueErrorMessage, n381NotificationId, A381NotificationId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001J11 */
                     pr_default.execute(9);
                     A392EmailQueueId = T001J11_A392EmailQueueId[0];
                     AssignAttri("", false, "A392EmailQueueId", StringUtil.LTrimStr( (decimal)(A392EmailQueueId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("EmailQueue");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1J0( ) ;
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
               Load1J58( ) ;
            }
            EndLevel1J58( ) ;
         }
         CloseExtendedTableCursors1J58( ) ;
      }

      protected void Update1J58( )
      {
         BeforeValidate1J58( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1J58( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1J58( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1J58( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1J58( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001J12 */
                     pr_default.execute(10, new Object[] {n393EmailQueueRecipient, A393EmailQueueRecipient, n394EmailQueueStatus, A394EmailQueueStatus, n395EmailQueueSentAt, A395EmailQueueSentAt, n396EmailQueueErrorMessage, A396EmailQueueErrorMessage, n381NotificationId, A381NotificationId, A392EmailQueueId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("EmailQueue");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmailQueue"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1J58( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1J0( ) ;
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
            EndLevel1J58( ) ;
         }
         CloseExtendedTableCursors1J58( ) ;
      }

      protected void DeferredUpdate1J58( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1J58( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1J58( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1J58( ) ;
            AfterConfirm1J58( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1J58( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001J13 */
                  pr_default.execute(11, new Object[] {A392EmailQueueId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("EmailQueue");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound58 == 0 )
                        {
                           InitAll1J58( ) ;
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
                        ResetCaption1J0( ) ;
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
         sMode58 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1J58( ) ;
         Gx_mode = sMode58;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1J58( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1J58( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1J58( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues1J0( ) ;
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

      public void ScanStart1J58( )
      {
         /* Using cursor T001J14 */
         pr_default.execute(12);
         RcdFound58 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound58 = 1;
            A392EmailQueueId = T001J14_A392EmailQueueId[0];
            AssignAttri("", false, "A392EmailQueueId", StringUtil.LTrimStr( (decimal)(A392EmailQueueId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1J58( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound58 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound58 = 1;
            A392EmailQueueId = T001J14_A392EmailQueueId[0];
            AssignAttri("", false, "A392EmailQueueId", StringUtil.LTrimStr( (decimal)(A392EmailQueueId), 9, 0));
         }
      }

      protected void ScanEnd1J58( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1J58( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1J58( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1J58( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1J58( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1J58( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1J58( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1J58( )
      {
         edtEmailQueueId_Enabled = 0;
         AssignProp("", false, edtEmailQueueId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmailQueueId_Enabled), 5, 0), true);
         edtNotificationId_Enabled = 0;
         AssignProp("", false, edtNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificationId_Enabled), 5, 0), true);
         edtEmailQueueRecipient_Enabled = 0;
         AssignProp("", false, edtEmailQueueRecipient_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmailQueueRecipient_Enabled), 5, 0), true);
         cmbEmailQueueStatus.Enabled = 0;
         AssignProp("", false, cmbEmailQueueStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEmailQueueStatus.Enabled), 5, 0), true);
         edtEmailQueueSentAt_Enabled = 0;
         AssignProp("", false, edtEmailQueueSentAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmailQueueSentAt_Enabled), 5, 0), true);
         edtEmailQueueErrorMessage_Enabled = 0;
         AssignProp("", false, edtEmailQueueErrorMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmailQueueErrorMessage_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1J58( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1J0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("emailqueue") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z392EmailQueueId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z392EmailQueueId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z393EmailQueueRecipient", Z393EmailQueueRecipient);
         GxWebStd.gx_hidden_field( context, "Z394EmailQueueStatus", Z394EmailQueueStatus);
         GxWebStd.gx_hidden_field( context, "Z395EmailQueueSentAt", context.localUtil.TToC( Z395EmailQueueSentAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z396EmailQueueErrorMessage", Z396EmailQueueErrorMessage);
         GxWebStd.gx_hidden_field( context, "Z381NotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z381NotificationId), 9, 0, ",", "")));
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
         return formatLink("emailqueue")  ;
      }

      public override string GetPgmname( )
      {
         return "EmailQueue" ;
      }

      public override string GetPgmdesc( )
      {
         return "Email Queue" ;
      }

      protected void InitializeNonKey1J58( )
      {
         A381NotificationId = 0;
         n381NotificationId = false;
         AssignAttri("", false, "A381NotificationId", ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ".", ""))));
         n381NotificationId = ((0==A381NotificationId) ? true : false);
         A393EmailQueueRecipient = "";
         n393EmailQueueRecipient = false;
         AssignAttri("", false, "A393EmailQueueRecipient", A393EmailQueueRecipient);
         n393EmailQueueRecipient = (String.IsNullOrEmpty(StringUtil.RTrim( A393EmailQueueRecipient)) ? true : false);
         A394EmailQueueStatus = "";
         n394EmailQueueStatus = false;
         AssignAttri("", false, "A394EmailQueueStatus", A394EmailQueueStatus);
         n394EmailQueueStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A394EmailQueueStatus)) ? true : false);
         A395EmailQueueSentAt = (DateTime)(DateTime.MinValue);
         n395EmailQueueSentAt = false;
         AssignAttri("", false, "A395EmailQueueSentAt", context.localUtil.TToC( A395EmailQueueSentAt, 8, 5, 0, 3, "/", ":", " "));
         n395EmailQueueSentAt = ((DateTime.MinValue==A395EmailQueueSentAt) ? true : false);
         A396EmailQueueErrorMessage = "";
         n396EmailQueueErrorMessage = false;
         AssignAttri("", false, "A396EmailQueueErrorMessage", A396EmailQueueErrorMessage);
         n396EmailQueueErrorMessage = (String.IsNullOrEmpty(StringUtil.RTrim( A396EmailQueueErrorMessage)) ? true : false);
         Z393EmailQueueRecipient = "";
         Z394EmailQueueStatus = "";
         Z395EmailQueueSentAt = (DateTime)(DateTime.MinValue);
         Z396EmailQueueErrorMessage = "";
         Z381NotificationId = 0;
      }

      protected void InitAll1J58( )
      {
         A392EmailQueueId = 0;
         AssignAttri("", false, "A392EmailQueueId", StringUtil.LTrimStr( (decimal)(A392EmailQueueId), 9, 0));
         InitializeNonKey1J58( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019164165", true, true);
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
         context.AddJavascriptSource("emailqueue.js", "?202561019164165", false, true);
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
         edtEmailQueueId_Internalname = "EMAILQUEUEID";
         edtNotificationId_Internalname = "NOTIFICATIONID";
         edtEmailQueueRecipient_Internalname = "EMAILQUEUERECIPIENT";
         cmbEmailQueueStatus_Internalname = "EMAILQUEUESTATUS";
         edtEmailQueueSentAt_Internalname = "EMAILQUEUESENTAT";
         edtEmailQueueErrorMessage_Internalname = "EMAILQUEUEERRORMESSAGE";
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
         Form.Caption = "Email Queue";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtEmailQueueErrorMessage_Enabled = 1;
         edtEmailQueueSentAt_Jsonclick = "";
         edtEmailQueueSentAt_Enabled = 1;
         cmbEmailQueueStatus_Jsonclick = "";
         cmbEmailQueueStatus.Enabled = 1;
         edtEmailQueueRecipient_Jsonclick = "";
         edtEmailQueueRecipient_Enabled = 1;
         edtNotificationId_Jsonclick = "";
         edtNotificationId_Enabled = 1;
         edtEmailQueueId_Jsonclick = "";
         edtEmailQueueId_Enabled = 1;
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
         cmbEmailQueueStatus.Name = "EMAILQUEUESTATUS";
         cmbEmailQueueStatus.WebTags = "";
         cmbEmailQueueStatus.addItem("Pending", "Pending", 0);
         cmbEmailQueueStatus.addItem("Sent", "Sent", 0);
         cmbEmailQueueStatus.addItem("Failed", "Failed", 0);
         if ( cmbEmailQueueStatus.ItemCount > 0 )
         {
            A394EmailQueueStatus = cmbEmailQueueStatus.getValidValue(A394EmailQueueStatus);
            n394EmailQueueStatus = false;
            AssignAttri("", false, "A394EmailQueueStatus", A394EmailQueueStatus);
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

      public void Valid_Emailqueueid( )
      {
         n394EmailQueueStatus = false;
         A394EmailQueueStatus = cmbEmailQueueStatus.CurrentValue;
         n394EmailQueueStatus = false;
         cmbEmailQueueStatus.CurrentValue = A394EmailQueueStatus;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbEmailQueueStatus.ItemCount > 0 )
         {
            A394EmailQueueStatus = cmbEmailQueueStatus.getValidValue(A394EmailQueueStatus);
            n394EmailQueueStatus = false;
            cmbEmailQueueStatus.CurrentValue = A394EmailQueueStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEmailQueueStatus.CurrentValue = StringUtil.RTrim( A394EmailQueueStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A381NotificationId", ((0==A381NotificationId)&&IsIns( )||n381NotificationId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A381NotificationId), 9, 0, ".", ""))));
         AssignAttri("", false, "A393EmailQueueRecipient", A393EmailQueueRecipient);
         AssignAttri("", false, "A394EmailQueueStatus", A394EmailQueueStatus);
         cmbEmailQueueStatus.CurrentValue = StringUtil.RTrim( A394EmailQueueStatus);
         AssignProp("", false, cmbEmailQueueStatus_Internalname, "Values", cmbEmailQueueStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A395EmailQueueSentAt", context.localUtil.TToC( A395EmailQueueSentAt, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A396EmailQueueErrorMessage", A396EmailQueueErrorMessage);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z392EmailQueueId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z392EmailQueueId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z381NotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z381NotificationId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z393EmailQueueRecipient", Z393EmailQueueRecipient);
         GxWebStd.gx_hidden_field( context, "Z394EmailQueueStatus", Z394EmailQueueStatus);
         GxWebStd.gx_hidden_field( context, "Z395EmailQueueSentAt", context.localUtil.TToC( Z395EmailQueueSentAt, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z396EmailQueueErrorMessage", Z396EmailQueueErrorMessage);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Notificationid( )
      {
         /* Using cursor T001J15 */
         pr_default.execute(13, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A381NotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'Notification'.", "ForeignKeyNotFound", 1, "NOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtNotificationId_Internalname;
            }
         }
         pr_default.close(13);
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
         setEventMetadata("VALID_EMAILQUEUEID","""{"handler":"Valid_Emailqueueid","iparms":[{"av":"cmbEmailQueueStatus"},{"av":"A394EmailQueueStatus","fld":"EMAILQUEUESTATUS","type":"svchar"},{"av":"A392EmailQueueId","fld":"EMAILQUEUEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_EMAILQUEUEID",""","oparms":[{"av":"A381NotificationId","fld":"NOTIFICATIONID","pic":"ZZZZZZZZ9","nullAv":"n381NotificationId","type":"int"},{"av":"A393EmailQueueRecipient","fld":"EMAILQUEUERECIPIENT","type":"svchar"},{"av":"cmbEmailQueueStatus"},{"av":"A394EmailQueueStatus","fld":"EMAILQUEUESTATUS","type":"svchar"},{"av":"A395EmailQueueSentAt","fld":"EMAILQUEUESENTAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A396EmailQueueErrorMessage","fld":"EMAILQUEUEERRORMESSAGE","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z392EmailQueueId","type":"int"},{"av":"Z381NotificationId","type":"int"},{"av":"Z393EmailQueueRecipient","type":"svchar"},{"av":"Z394EmailQueueStatus","type":"svchar"},{"av":"Z395EmailQueueSentAt","type":"dtime"},{"av":"Z396EmailQueueErrorMessage","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_NOTIFICATIONID","""{"handler":"Valid_Notificationid","iparms":[{"av":"A381NotificationId","fld":"NOTIFICATIONID","pic":"ZZZZZZZZ9","nullAv":"n381NotificationId","type":"int"}]}""");
         setEventMetadata("VALID_EMAILQUEUERECIPIENT","""{"handler":"Valid_Emailqueuerecipient","iparms":[]}""");
         setEventMetadata("VALID_EMAILQUEUESTATUS","""{"handler":"Valid_Emailqueuestatus","iparms":[]}""");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z393EmailQueueRecipient = "";
         Z394EmailQueueStatus = "";
         Z395EmailQueueSentAt = (DateTime)(DateTime.MinValue);
         Z396EmailQueueErrorMessage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A394EmailQueueStatus = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A393EmailQueueRecipient = "";
         A395EmailQueueSentAt = (DateTime)(DateTime.MinValue);
         A396EmailQueueErrorMessage = "";
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
         T001J5_A392EmailQueueId = new int[1] ;
         T001J5_A393EmailQueueRecipient = new string[] {""} ;
         T001J5_n393EmailQueueRecipient = new bool[] {false} ;
         T001J5_A394EmailQueueStatus = new string[] {""} ;
         T001J5_n394EmailQueueStatus = new bool[] {false} ;
         T001J5_A395EmailQueueSentAt = new DateTime[] {DateTime.MinValue} ;
         T001J5_n395EmailQueueSentAt = new bool[] {false} ;
         T001J5_A396EmailQueueErrorMessage = new string[] {""} ;
         T001J5_n396EmailQueueErrorMessage = new bool[] {false} ;
         T001J5_A381NotificationId = new int[1] ;
         T001J5_n381NotificationId = new bool[] {false} ;
         T001J4_A381NotificationId = new int[1] ;
         T001J4_n381NotificationId = new bool[] {false} ;
         T001J6_A381NotificationId = new int[1] ;
         T001J6_n381NotificationId = new bool[] {false} ;
         T001J7_A392EmailQueueId = new int[1] ;
         T001J3_A392EmailQueueId = new int[1] ;
         T001J3_A393EmailQueueRecipient = new string[] {""} ;
         T001J3_n393EmailQueueRecipient = new bool[] {false} ;
         T001J3_A394EmailQueueStatus = new string[] {""} ;
         T001J3_n394EmailQueueStatus = new bool[] {false} ;
         T001J3_A395EmailQueueSentAt = new DateTime[] {DateTime.MinValue} ;
         T001J3_n395EmailQueueSentAt = new bool[] {false} ;
         T001J3_A396EmailQueueErrorMessage = new string[] {""} ;
         T001J3_n396EmailQueueErrorMessage = new bool[] {false} ;
         T001J3_A381NotificationId = new int[1] ;
         T001J3_n381NotificationId = new bool[] {false} ;
         sMode58 = "";
         T001J8_A392EmailQueueId = new int[1] ;
         T001J9_A392EmailQueueId = new int[1] ;
         T001J2_A392EmailQueueId = new int[1] ;
         T001J2_A393EmailQueueRecipient = new string[] {""} ;
         T001J2_n393EmailQueueRecipient = new bool[] {false} ;
         T001J2_A394EmailQueueStatus = new string[] {""} ;
         T001J2_n394EmailQueueStatus = new bool[] {false} ;
         T001J2_A395EmailQueueSentAt = new DateTime[] {DateTime.MinValue} ;
         T001J2_n395EmailQueueSentAt = new bool[] {false} ;
         T001J2_A396EmailQueueErrorMessage = new string[] {""} ;
         T001J2_n396EmailQueueErrorMessage = new bool[] {false} ;
         T001J2_A381NotificationId = new int[1] ;
         T001J2_n381NotificationId = new bool[] {false} ;
         T001J11_A392EmailQueueId = new int[1] ;
         T001J14_A392EmailQueueId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ393EmailQueueRecipient = "";
         ZZ394EmailQueueStatus = "";
         ZZ395EmailQueueSentAt = (DateTime)(DateTime.MinValue);
         ZZ396EmailQueueErrorMessage = "";
         T001J15_A381NotificationId = new int[1] ;
         T001J15_n381NotificationId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.emailqueue__default(),
            new Object[][] {
                new Object[] {
               T001J2_A392EmailQueueId, T001J2_A393EmailQueueRecipient, T001J2_n393EmailQueueRecipient, T001J2_A394EmailQueueStatus, T001J2_n394EmailQueueStatus, T001J2_A395EmailQueueSentAt, T001J2_n395EmailQueueSentAt, T001J2_A396EmailQueueErrorMessage, T001J2_n396EmailQueueErrorMessage, T001J2_A381NotificationId,
               T001J2_n381NotificationId
               }
               , new Object[] {
               T001J3_A392EmailQueueId, T001J3_A393EmailQueueRecipient, T001J3_n393EmailQueueRecipient, T001J3_A394EmailQueueStatus, T001J3_n394EmailQueueStatus, T001J3_A395EmailQueueSentAt, T001J3_n395EmailQueueSentAt, T001J3_A396EmailQueueErrorMessage, T001J3_n396EmailQueueErrorMessage, T001J3_A381NotificationId,
               T001J3_n381NotificationId
               }
               , new Object[] {
               T001J4_A381NotificationId
               }
               , new Object[] {
               T001J5_A392EmailQueueId, T001J5_A393EmailQueueRecipient, T001J5_n393EmailQueueRecipient, T001J5_A394EmailQueueStatus, T001J5_n394EmailQueueStatus, T001J5_A395EmailQueueSentAt, T001J5_n395EmailQueueSentAt, T001J5_A396EmailQueueErrorMessage, T001J5_n396EmailQueueErrorMessage, T001J5_A381NotificationId,
               T001J5_n381NotificationId
               }
               , new Object[] {
               T001J6_A381NotificationId
               }
               , new Object[] {
               T001J7_A392EmailQueueId
               }
               , new Object[] {
               T001J8_A392EmailQueueId
               }
               , new Object[] {
               T001J9_A392EmailQueueId
               }
               , new Object[] {
               }
               , new Object[] {
               T001J11_A392EmailQueueId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001J14_A392EmailQueueId
               }
               , new Object[] {
               T001J15_A381NotificationId
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound58 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z392EmailQueueId ;
      private int Z381NotificationId ;
      private int A381NotificationId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A392EmailQueueId ;
      private int edtEmailQueueId_Enabled ;
      private int edtNotificationId_Enabled ;
      private int edtEmailQueueRecipient_Enabled ;
      private int edtEmailQueueSentAt_Enabled ;
      private int edtEmailQueueErrorMessage_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ392EmailQueueId ;
      private int ZZ381NotificationId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEmailQueueId_Internalname ;
      private string cmbEmailQueueStatus_Internalname ;
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
      private string edtEmailQueueId_Jsonclick ;
      private string edtNotificationId_Internalname ;
      private string edtNotificationId_Jsonclick ;
      private string edtEmailQueueRecipient_Internalname ;
      private string edtEmailQueueRecipient_Jsonclick ;
      private string cmbEmailQueueStatus_Jsonclick ;
      private string edtEmailQueueSentAt_Internalname ;
      private string edtEmailQueueSentAt_Jsonclick ;
      private string edtEmailQueueErrorMessage_Internalname ;
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
      private string sMode58 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z395EmailQueueSentAt ;
      private DateTime A395EmailQueueSentAt ;
      private DateTime ZZ395EmailQueueSentAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n381NotificationId ;
      private bool wbErr ;
      private bool n394EmailQueueStatus ;
      private bool n393EmailQueueRecipient ;
      private bool n395EmailQueueSentAt ;
      private bool n396EmailQueueErrorMessage ;
      private string Z393EmailQueueRecipient ;
      private string Z394EmailQueueStatus ;
      private string Z396EmailQueueErrorMessage ;
      private string A394EmailQueueStatus ;
      private string A393EmailQueueRecipient ;
      private string A396EmailQueueErrorMessage ;
      private string ZZ393EmailQueueRecipient ;
      private string ZZ394EmailQueueStatus ;
      private string ZZ396EmailQueueErrorMessage ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbEmailQueueStatus ;
      private IDataStoreProvider pr_default ;
      private int[] T001J5_A392EmailQueueId ;
      private string[] T001J5_A393EmailQueueRecipient ;
      private bool[] T001J5_n393EmailQueueRecipient ;
      private string[] T001J5_A394EmailQueueStatus ;
      private bool[] T001J5_n394EmailQueueStatus ;
      private DateTime[] T001J5_A395EmailQueueSentAt ;
      private bool[] T001J5_n395EmailQueueSentAt ;
      private string[] T001J5_A396EmailQueueErrorMessage ;
      private bool[] T001J5_n396EmailQueueErrorMessage ;
      private int[] T001J5_A381NotificationId ;
      private bool[] T001J5_n381NotificationId ;
      private int[] T001J4_A381NotificationId ;
      private bool[] T001J4_n381NotificationId ;
      private int[] T001J6_A381NotificationId ;
      private bool[] T001J6_n381NotificationId ;
      private int[] T001J7_A392EmailQueueId ;
      private int[] T001J3_A392EmailQueueId ;
      private string[] T001J3_A393EmailQueueRecipient ;
      private bool[] T001J3_n393EmailQueueRecipient ;
      private string[] T001J3_A394EmailQueueStatus ;
      private bool[] T001J3_n394EmailQueueStatus ;
      private DateTime[] T001J3_A395EmailQueueSentAt ;
      private bool[] T001J3_n395EmailQueueSentAt ;
      private string[] T001J3_A396EmailQueueErrorMessage ;
      private bool[] T001J3_n396EmailQueueErrorMessage ;
      private int[] T001J3_A381NotificationId ;
      private bool[] T001J3_n381NotificationId ;
      private int[] T001J8_A392EmailQueueId ;
      private int[] T001J9_A392EmailQueueId ;
      private int[] T001J2_A392EmailQueueId ;
      private string[] T001J2_A393EmailQueueRecipient ;
      private bool[] T001J2_n393EmailQueueRecipient ;
      private string[] T001J2_A394EmailQueueStatus ;
      private bool[] T001J2_n394EmailQueueStatus ;
      private DateTime[] T001J2_A395EmailQueueSentAt ;
      private bool[] T001J2_n395EmailQueueSentAt ;
      private string[] T001J2_A396EmailQueueErrorMessage ;
      private bool[] T001J2_n396EmailQueueErrorMessage ;
      private int[] T001J2_A381NotificationId ;
      private bool[] T001J2_n381NotificationId ;
      private int[] T001J11_A392EmailQueueId ;
      private int[] T001J14_A392EmailQueueId ;
      private int[] T001J15_A381NotificationId ;
      private bool[] T001J15_n381NotificationId ;
   }

   public class emailqueue__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001J2;
          prmT001J2 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmT001J3;
          prmT001J3 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmT001J4;
          prmT001J4 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001J5;
          prmT001J5 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmT001J6;
          prmT001J6 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001J7;
          prmT001J7 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmT001J8;
          prmT001J8 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmT001J9;
          prmT001J9 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmT001J10;
          prmT001J10 = new Object[] {
          new ParDef("EmailQueueRecipient",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmailQueueStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmailQueueSentAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("EmailQueueErrorMessage",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001J11;
          prmT001J11 = new Object[] {
          };
          Object[] prmT001J12;
          prmT001J12 = new Object[] {
          new ParDef("EmailQueueRecipient",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmailQueueStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmailQueueSentAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("EmailQueueErrorMessage",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmT001J13;
          prmT001J13 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmT001J14;
          prmT001J14 = new Object[] {
          };
          Object[] prmT001J15;
          prmT001J15 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001J2", "SELECT EmailQueueId, EmailQueueRecipient, EmailQueueStatus, EmailQueueSentAt, EmailQueueErrorMessage, NotificationId FROM EmailQueue WHERE EmailQueueId = :EmailQueueId  FOR UPDATE OF EmailQueue NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001J2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001J3", "SELECT EmailQueueId, EmailQueueRecipient, EmailQueueStatus, EmailQueueSentAt, EmailQueueErrorMessage, NotificationId FROM EmailQueue WHERE EmailQueueId = :EmailQueueId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001J4", "SELECT NotificationId FROM Notification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001J5", "SELECT TM1.EmailQueueId, TM1.EmailQueueRecipient, TM1.EmailQueueStatus, TM1.EmailQueueSentAt, TM1.EmailQueueErrorMessage, TM1.NotificationId FROM EmailQueue TM1 WHERE TM1.EmailQueueId = :EmailQueueId ORDER BY TM1.EmailQueueId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001J6", "SELECT NotificationId FROM Notification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001J7", "SELECT EmailQueueId FROM EmailQueue WHERE EmailQueueId = :EmailQueueId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001J8", "SELECT EmailQueueId FROM EmailQueue WHERE ( EmailQueueId > :EmailQueueId) ORDER BY EmailQueueId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001J9", "SELECT EmailQueueId FROM EmailQueue WHERE ( EmailQueueId < :EmailQueueId) ORDER BY EmailQueueId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001J10", "SAVEPOINT gxupdate;INSERT INTO EmailQueue(EmailQueueRecipient, EmailQueueStatus, EmailQueueSentAt, EmailQueueErrorMessage, NotificationId) VALUES(:EmailQueueRecipient, :EmailQueueStatus, :EmailQueueSentAt, :EmailQueueErrorMessage, :NotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001J10)
             ,new CursorDef("T001J11", "SELECT currval('EmailQueueId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001J12", "SAVEPOINT gxupdate;UPDATE EmailQueue SET EmailQueueRecipient=:EmailQueueRecipient, EmailQueueStatus=:EmailQueueStatus, EmailQueueSentAt=:EmailQueueSentAt, EmailQueueErrorMessage=:EmailQueueErrorMessage, NotificationId=:NotificationId  WHERE EmailQueueId = :EmailQueueId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001J12)
             ,new CursorDef("T001J13", "SAVEPOINT gxupdate;DELETE FROM EmailQueue  WHERE EmailQueueId = :EmailQueueId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001J13)
             ,new CursorDef("T001J14", "SELECT EmailQueueId FROM EmailQueue ORDER BY EmailQueueId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001J15", "SELECT NotificationId FROM Notification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J15,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
       }
    }

 }

}
