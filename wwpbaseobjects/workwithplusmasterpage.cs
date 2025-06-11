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
namespace GeneXus.Programs.wwpbaseobjects {
   public class workwithplusmasterpage : GXMasterPage
   {
      public workwithplusmasterpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithplusmasterpage( IGxContext context )
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            PA2A2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS2A2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE2A2( ) ;
               }
            }
         }
         cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            GXWebForm.AddResponsiveMetaHeaders((getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta);
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPROGRAMDESCRIPTION_MPAGE", AV12ProgramDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV12ProgramDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "vSEARCHAUX_MPAGE", AV18SearchAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHAUX_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV18SearchAux, "")), context));
         GxWebStd.gx_hidden_field( context, "vBREADCRUMB_MPAGE", AV35Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV35Breadcrumb, "")), context));
         GxWebStd.gx_hidden_field( context, "vINDEXTOADDITEMS_MPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11IndexToAddItems), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV11IndexToAddItems), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vBOOKMARKSDATA_MPAGE", AV6BookmarksData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBOOKMARKSDATA_MPAGE", AV6BookmarksData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vDVELOP_MENU_MPAGE", AV26DVelop_Menu);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDVELOP_MENU_MPAGE", AV26DVelop_Menu);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vDVELOP_MENU_USERDATA_MPAGE", AV37DVelop_Menu_UserData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDVELOP_MENU_USERDATA_MPAGE", AV37DVelop_Menu_UserData);
         }
         GxWebStd.gx_hidden_field( context, "vPROGRAMDESCRIPTION_MPAGE", AV12ProgramDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV12ProgramDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "vSEARCHAUX_MPAGE", AV18SearchAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHAUX_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV18SearchAux, "")), context));
         GxWebStd.gx_hidden_field( context, "vBREADCRUMB_MPAGE", AV35Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV35Breadcrumb, "")), context));
         GxWebStd.gx_hidden_field( context, "vINDEXTOADDITEMS_MPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11IndexToAddItems), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV11IndexToAddItems), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSOURCE_MPAGE", AV43Source);
         GxWebStd.gx_hidden_field( context, "USERNOTIFICATIONUSERID_MPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A388UserNotificationUserId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vWWPCONTEXT_MPAGE", AV44WWpContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT_MPAGE", AV44WWpContext);
         }
         GxWebStd.gx_hidden_field( context, "USERNOTIFICATIONSTATUS_MPAGE", A389UserNotificationStatus);
         GxWebStd.gx_hidden_field( context, "NOTIFICATIONTYPE_MPAGE", A384NotificationType);
         GxWebStd.gx_hidden_field( context, "USERNOTIFICATIONID_MPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A387UserNotificationId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vNOTIFICATIONINFO_MPAGE", AV14NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO_MPAGE", AV14NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Icontype", StringUtil.RTrim( Ddo_bookmarks_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Icon", StringUtil.RTrim( Ddo_bookmarks_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Tooltip", StringUtil.RTrim( Ddo_bookmarks_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Cls", StringUtil.RTrim( Ddo_bookmarks_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Titlecontrolalign", StringUtil.RTrim( Ddo_bookmarks_Titlecontrolalign));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icontype", StringUtil.RTrim( Ddc_notificationswc_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Caption", StringUtil.RTrim( Ddc_notificationswc_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Cls", StringUtil.RTrim( Ddc_notificationswc_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Icontype", StringUtil.RTrim( Ddc_adminag_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Icon", StringUtil.RTrim( Ddc_adminag_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Caption", StringUtil.RTrim( Ddc_adminag_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Cls", StringUtil.RTrim( Ddc_adminag_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_adminag_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Searchserviceurl", StringUtil.RTrim( Ucmenu_Searchserviceurl));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Searchminchars", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucmenu_Searchminchars), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Searchhelperdescription", StringUtil.RTrim( Ucmenu_Searchhelperdescription));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Allmenuitemsvisibleatload", StringUtil.BoolToStr( Ucmenu_Allmenuitemsvisibleatload));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Includetogglebutton", StringUtil.BoolToStr( Ucmenu_Includetogglebutton));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Togglebuttonposition", StringUtil.RTrim( Ucmenu_Togglebuttonposition));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Sidebarmainclass", StringUtil.RTrim( Ucmenu_Sidebarmainclass));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Scrollwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucmenu_Scrollwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Scrollalwaysvisible", StringUtil.BoolToStr( Ucmenu_Scrollalwaysvisible));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Hidescrollincompactmenu", StringUtil.BoolToStr( Ucmenu_Hidescrollincompactmenu));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Firstlevelisgrouping", StringUtil.BoolToStr( Ucmenu_Firstlevelisgrouping));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Width", StringUtil.RTrim( Ucmessage_Width));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Minheight", StringUtil.RTrim( Ucmessage_Minheight));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Stylingtype", StringUtil.RTrim( Ucmessage_Stylingtype));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Stoponerror", StringUtil.BoolToStr( Ucmessage_Stoponerror));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Effectin", StringUtil.RTrim( Ucmessage_Effectin));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Effectout", StringUtil.RTrim( Ucmessage_Effectout));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Animationspeed", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucmessage_Animationspeed), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Startposition", StringUtil.RTrim( Ucmessage_Startposition));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Nextmessageposition", StringUtil.RTrim( Ucmessage_Nextmessageposition));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enablefixobjectfitcover", StringUtil.BoolToStr( Wwputilities_Enablefixobjectfitcover));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enablefloatinglabels", StringUtil.BoolToStr( Wwputilities_Enablefloatinglabels));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Empowertabs", StringUtil.BoolToStr( Wwputilities_Empowertabs));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enableupdaterowselectionstatus", StringUtil.BoolToStr( Wwputilities_Enableupdaterowselectionstatus));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enableconvertcombotobootstrapselect", StringUtil.BoolToStr( Wwputilities_Enableconvertcombotobootstrapselect));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnresizing", StringUtil.BoolToStr( Wwputilities_Allowcolumnresizing));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnreordering", StringUtil.BoolToStr( Wwputilities_Allowcolumnreordering));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumndragging", StringUtil.BoolToStr( Wwputilities_Allowcolumndragging));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnsrestore", StringUtil.BoolToStr( Wwputilities_Allowcolumnsrestore));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Pagbarincludegoto", StringUtil.BoolToStr( Wwputilities_Pagbarincludegoto));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Comboloadtype", StringUtil.RTrim( Wwputilities_Comboloadtype));
         GxWebStd.gx_hidden_field( context, "TIMER_MPAGE_Tickinterval", StringUtil.LTrim( StringUtil.NToC( (decimal)(Timer_Tickinterval), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "BOOKMARK_MODAL_MPAGE_Width", StringUtil.RTrim( Bookmark_modal_Width));
         GxWebStd.gx_hidden_field( context, "BOOKMARK_MODAL_MPAGE_Title", StringUtil.RTrim( Bookmark_modal_Title));
         GxWebStd.gx_hidden_field( context, "BOOKMARK_MODAL_MPAGE_Confirmtype", StringUtil.RTrim( Bookmark_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "BOOKMARK_MODAL_MPAGE_Bodytype", StringUtil.RTrim( Bookmark_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Activeeventkey", StringUtil.RTrim( Ddo_bookmarks_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "vHTTPREQUEST_MPAGE_Baseurl", StringUtil.RTrim( AV30Httprequest.BaseURL));
         GxWebStd.gx_hidden_field( context, "FORM_MPAGE_Caption", StringUtil.RTrim( (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Activeeventkey", StringUtil.RTrim( Ddo_bookmarks_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "FORM_MPAGE_Caption", StringUtil.RTrim( (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
      }

      protected void RenderHtmlCloseForm2A2( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((string)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( ! ( WebComp_Wcwcmodule == null ) )
         {
            WebComp_Wcwcmodule.componentjscripts();
         }
         if ( ! ( WebComp_Wcwcmodule2 == null ) )
         {
            WebComp_Wcwcmodule2.componentjscripts();
         }
         if ( ! ( WebComp_Wcwcmodule3 == null ) )
         {
            WebComp_Wcwcmodule3.componentjscripts();
         }
         if ( ! ( WebComp_Wcwcmodule4 == null ) )
         {
            WebComp_Wcwcmodule4.componentjscripts();
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/slimscroll/jquery.slimscroll.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/SidebarMenu/BootstrapSidebarMenuRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Tooltip/BootstrapTooltipRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DatePicker/DatePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Chronometer/ChronometerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("wwpbaseobjects/workwithplusmasterpage.js", "?202561019232215", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WorkWithPlusMasterPage" ;
      }

      public override string GetPgmdesc( )
      {
         return "Master Page" ;
      }

      protected void WB2A0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MasterHeaderCell navbar-fixed-top", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "TableHeader", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelogologin_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HeaderImageCell", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "ImageTop" + " " + ((StringUtil.StrCmp(imgImageheader_gximage, "")==0) ? "GX_Image_(none)_Class" : "GX_Image_"+imgImageheader_gximage+"_Class");
            StyleString = "";
            sImgUrl = imgImageheader_Bitmap;
            GxWebStd.gx_bitmap( context, imgImageheader_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblShowmenu_Internalname, "<i class=\"fa fa-bars ImageMenuIcon\"></i>", "", "", lblShowmenu_Jsonclick, "'"+""+"'"+",true,"+"'"+"e112a1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemodules_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "MPW0022"+"", StringUtil.RTrim( WebComp_Wcwcmodule_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0022"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcmodule_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcmodule), StringUtil.Lower( WebComp_Wcwcmodule_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0022"+"");
                  }
                  WebComp_Wcwcmodule.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcmodule), StringUtil.Lower( WebComp_Wcwcmodule_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "MPW0024"+"", StringUtil.RTrim( WebComp_Wcwcmodule2_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0024"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcmodule2_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcmodule2), StringUtil.Lower( WebComp_Wcwcmodule2_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0024"+"");
                  }
                  WebComp_Wcwcmodule2.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcmodule2), StringUtil.Lower( WebComp_Wcwcmodule2_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "MPW0026"+"", StringUtil.RTrim( WebComp_Wcwcmodule3_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0026"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcmodule3_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcmodule3), StringUtil.Lower( WebComp_Wcwcmodule3_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0026"+"");
                  }
                  WebComp_Wcwcmodule3.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcmodule3), StringUtil.Lower( WebComp_Wcwcmodule3_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "MPW0028"+"", StringUtil.RTrim( WebComp_Wcwcmodule4_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0028"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcmodule4_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcmodule4), StringUtil.Lower( WebComp_Wcwcmodule4_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0028"+"");
                  }
                  WebComp_Wcwcmodule4.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcmodule4), StringUtil.Lower( WebComp_Wcwcmodule4_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableuserrole_Internalname, 1, 0, "px", 0, "px", "CellHeaderBar hidden-xs", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_bookmarks.SetProperty("IconType", Ddo_bookmarks_Icontype);
            ucDdo_bookmarks.SetProperty("Icon", Ddo_bookmarks_Icon);
            ucDdo_bookmarks.SetProperty("Caption", Ddo_bookmarks_Caption);
            ucDdo_bookmarks.SetProperty("Cls", Ddo_bookmarks_Cls);
            ucDdo_bookmarks.SetProperty("DropDownOptionsData", AV6BookmarksData);
            ucDdo_bookmarks.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_bookmarks_Internalname, "DDO_BOOKMARKS_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_notificationswc.SetProperty("IconType", Ddc_notificationswc_Icontype);
            ucDdc_notificationswc.SetProperty("Icon", Ddc_notificationswc_Icon);
            ucDdc_notificationswc.SetProperty("Caption", Ddc_notificationswc_Caption);
            ucDdc_notificationswc.SetProperty("Cls", Ddc_notificationswc_Cls);
            ucDdc_notificationswc.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_notificationswc_Internalname, "DDC_NOTIFICATIONSWC_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_adminag.SetProperty("IconType", Ddc_adminag_Icontype);
            ucDdc_adminag.SetProperty("Icon", Ddc_adminag_Icon);
            ucDdc_adminag.SetProperty("Caption", Ddc_adminag_Caption);
            ucDdc_adminag.SetProperty("Cls", Ddc_adminag_Cls);
            ucDdc_adminag.SetProperty("ComponentWidth", Ddc_adminag_Componentwidth);
            ucDdc_adminag.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_adminag_Internalname, "DDC_ADMINAG_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellTableContentMaster CellTableContentWithFooter", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "page-content MaterialStyle", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellTitleMaster", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletitle_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktitle_Internalname, lblTextblocktitle_Caption, "", "", lblTextblocktitle_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlockTitleMaster", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellContentHolder", "start", "top", "", "", "div");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
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
            /* User Defined Control */
            ucUcmenu.SetProperty("SearchServiceUrl", Ucmenu_Searchserviceurl);
            ucUcmenu.SetProperty("SearchMinChars", Ucmenu_Searchminchars);
            ucUcmenu.SetProperty("SearchHelperDescription", Ucmenu_Searchhelperdescription);
            ucUcmenu.SetProperty("AllMenuItemsVisibleAtLoad", Ucmenu_Allmenuitemsvisibleatload);
            ucUcmenu.SetProperty("IncludeToggleButton", Ucmenu_Includetogglebutton);
            ucUcmenu.SetProperty("ToggleButtonPosition", Ucmenu_Togglebuttonposition);
            ucUcmenu.SetProperty("SidebarMainClass", Ucmenu_Sidebarmainclass);
            ucUcmenu.SetProperty("ScrollWidth", Ucmenu_Scrollwidth);
            ucUcmenu.SetProperty("ScrollAlwaysVisible", Ucmenu_Scrollalwaysvisible);
            ucUcmenu.SetProperty("HideScrollInCompactMenu", Ucmenu_Hidescrollincompactmenu);
            ucUcmenu.SetProperty("FirstLevelIsGrouping", Ucmenu_Firstlevelisgrouping);
            ucUcmenu.SetProperty("SidebarMenuOptionsData", AV26DVelop_Menu);
            ucUcmenu.SetProperty("SidebarMenuUserData", AV37DVelop_Menu_UserData);
            ucUcmenu.Render(context, "dvelop.gxbootstrap.sidebarmenu", Ucmenu_Internalname, "UCMENU_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcmessage.SetProperty("Width", Ucmessage_Width);
            ucUcmessage.SetProperty("MinHeight", Ucmessage_Minheight);
            ucUcmessage.SetProperty("StylingType", Ucmessage_Stylingtype);
            ucUcmessage.SetProperty("StopOnError", Ucmessage_Stoponerror);
            ucUcmessage.SetProperty("EffectIn", Ucmessage_Effectin);
            ucUcmessage.SetProperty("EffectOut", Ucmessage_Effectout);
            ucUcmessage.SetProperty("AnimationSpeed", Ucmessage_Animationspeed);
            ucUcmessage.SetProperty("StartPosition", Ucmessage_Startposition);
            ucUcmessage.SetProperty("NextMessagePosition", Ucmessage_Nextmessageposition);
            ucUcmessage.Render(context, "dvelop.dvmessage", Ucmessage_Internalname, "UCMESSAGE_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUctooltip.Render(context, "dvelop.gxbootstrap.tooltip", Uctooltip_Internalname, "UCTOOLTIP_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucWwputilities.SetProperty("EnableFixObjectFitCover", Wwputilities_Enablefixobjectfitcover);
            ucWwputilities.SetProperty("EnableFloatingLabels", Wwputilities_Enablefloatinglabels);
            ucWwputilities.SetProperty("EmpowerTabs", Wwputilities_Empowertabs);
            ucWwputilities.SetProperty("EnableUpdateRowSelectionStatus", Wwputilities_Enableupdaterowselectionstatus);
            ucWwputilities.SetProperty("EnableConvertComboToBootstrapSelect", Wwputilities_Enableconvertcombotobootstrapselect);
            ucWwputilities.SetProperty("AllowColumnResizing", Wwputilities_Allowcolumnresizing);
            ucWwputilities.SetProperty("AllowColumnReordering", Wwputilities_Allowcolumnreordering);
            ucWwputilities.SetProperty("AllowColumnDragging", Wwputilities_Allowcolumndragging);
            ucWwputilities.SetProperty("AllowColumnsRestore", Wwputilities_Allowcolumnsrestore);
            ucWwputilities.SetProperty("PagBarIncludeGoTo", Wwputilities_Pagbarincludegoto);
            ucWwputilities.SetProperty("ComboLoadType", Wwputilities_Comboloadtype);
            ucWwputilities.Render(context, "wwp.workwithplusutilities_fal", Wwputilities_Internalname, "WWPUTILITIES_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucWwpdatepicker.Render(context, "wwp.datepicker", Wwpdatepicker_Internalname, "WWPDATEPICKER_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTimer.Render(context, "wwp.chronometer", Timer_Internalname, "TIMER_MPAGEContainer");
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
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',true,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavPickerdummyvariable_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavPickerdummyvariable_Internalname, context.localUtil.Format(AV36PickerDummyVariable, "99/99/99"), context.localUtil.Format( AV36PickerDummyVariable, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "", "", "", edtavPickerdummyvariable_Jsonclick, 0, "Invisible", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_bitmap( context, edtavPickerdummyvariable_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            context.WriteHtmlTextNl( "</div>") ;
            wb_table1_71_2A2( true) ;
         }
         else
         {
            wb_table1_71_2A2( false) ;
         }
         return  ;
      }

      protected void wb_table1_71_2A2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "MPW0077"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0077"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0077"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2A2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2A0( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS2A2( )
      {
         START2A2( ) ;
         EVT2A2( ) ;
      }

      protected void EVT2A2( )
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
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDO_BOOKMARKS_MPAGE.ONOPTIONCLICKED_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddo_bookmarks.Onoptionclicked */
                           E122A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddc_notificationswc.Onloadcomponent */
                           E132A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddc_adminag.Onloadcomponent */
                           E142A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Bookmark_modal.Close */
                           E152A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Bookmark_modal.Onloadcomponent */
                           E162A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E172A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DOACTIONSEARCH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'DoActionSearch' */
                           E182A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Onmessage_gx1 */
                           E192A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E202A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E212A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS_MPAGE.MASTER_CHANGEIMAGE_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E222A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS_MPAGE.MASTER_REFRESHNOTIFICATIONS_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E232A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E242A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
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
                        else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Onmessage_gx1 */
                           E192A2 ();
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  else if ( StringUtil.StrCmp(sEvtType, "M") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-2));
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-6));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 22 )
                     {
                        OldWcwcmodule = cgiGet( "MPW0022");
                        if ( ( StringUtil.Len( OldWcwcmodule) == 0 ) || ( StringUtil.StrCmp(OldWcwcmodule, WebComp_Wcwcmodule_Component) != 0 ) )
                        {
                           WebComp_Wcwcmodule = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcmodule, new Object[] {context} );
                           WebComp_Wcwcmodule.ComponentInit();
                           WebComp_Wcwcmodule.Name = "OldWcwcmodule";
                           WebComp_Wcwcmodule_Component = OldWcwcmodule;
                        }
                        if ( StringUtil.Len( WebComp_Wcwcmodule_Component) != 0 )
                        {
                           WebComp_Wcwcmodule.componentprocess("MPW0022", "", sEvt);
                        }
                        WebComp_Wcwcmodule_Component = OldWcwcmodule;
                     }
                     else if ( nCmpId == 24 )
                     {
                        OldWcwcmodule2 = cgiGet( "MPW0024");
                        if ( ( StringUtil.Len( OldWcwcmodule2) == 0 ) || ( StringUtil.StrCmp(OldWcwcmodule2, WebComp_Wcwcmodule2_Component) != 0 ) )
                        {
                           WebComp_Wcwcmodule2 = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcmodule2, new Object[] {context} );
                           WebComp_Wcwcmodule2.ComponentInit();
                           WebComp_Wcwcmodule2.Name = "OldWcwcmodule2";
                           WebComp_Wcwcmodule2_Component = OldWcwcmodule2;
                        }
                        if ( StringUtil.Len( WebComp_Wcwcmodule2_Component) != 0 )
                        {
                           WebComp_Wcwcmodule2.componentprocess("MPW0024", "", sEvt);
                        }
                        WebComp_Wcwcmodule2_Component = OldWcwcmodule2;
                     }
                     else if ( nCmpId == 26 )
                     {
                        OldWcwcmodule3 = cgiGet( "MPW0026");
                        if ( ( StringUtil.Len( OldWcwcmodule3) == 0 ) || ( StringUtil.StrCmp(OldWcwcmodule3, WebComp_Wcwcmodule3_Component) != 0 ) )
                        {
                           WebComp_Wcwcmodule3 = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcmodule3, new Object[] {context} );
                           WebComp_Wcwcmodule3.ComponentInit();
                           WebComp_Wcwcmodule3.Name = "OldWcwcmodule3";
                           WebComp_Wcwcmodule3_Component = OldWcwcmodule3;
                        }
                        if ( StringUtil.Len( WebComp_Wcwcmodule3_Component) != 0 )
                        {
                           WebComp_Wcwcmodule3.componentprocess("MPW0026", "", sEvt);
                        }
                        WebComp_Wcwcmodule3_Component = OldWcwcmodule3;
                     }
                     else if ( nCmpId == 28 )
                     {
                        OldWcwcmodule4 = cgiGet( "MPW0028");
                        if ( ( StringUtil.Len( OldWcwcmodule4) == 0 ) || ( StringUtil.StrCmp(OldWcwcmodule4, WebComp_Wcwcmodule4_Component) != 0 ) )
                        {
                           WebComp_Wcwcmodule4 = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcmodule4, new Object[] {context} );
                           WebComp_Wcwcmodule4.ComponentInit();
                           WebComp_Wcwcmodule4.Name = "OldWcwcmodule4";
                           WebComp_Wcwcmodule4_Component = OldWcwcmodule4;
                        }
                        if ( StringUtil.Len( WebComp_Wcwcmodule4_Component) != 0 )
                        {
                           WebComp_Wcwcmodule4.componentprocess("MPW0028", "", sEvt);
                        }
                        WebComp_Wcwcmodule4_Component = OldWcwcmodule4;
                     }
                     else if ( nCmpId == 77 )
                     {
                        OldWwpaux_wc = cgiGet( "MPW0077");
                        if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                        {
                           WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                           WebComp_Wwpaux_wc.ComponentInit();
                           WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                        {
                           WebComp_Wwpaux_wc.componentprocess("MPW0077", "", sEvt);
                        }
                        WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE2A2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2A2( ) ;
            }
         }
      }

      protected void PA2A2( )
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
               GX_FocusControl = edtavPickerdummyvariable_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
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
         RF2A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            /* Execute user event: Refresh */
            E202A2 ();
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( 1 != 0 )
               {
                  if ( StringUtil.Len( WebComp_Wcwcmodule_Component) != 0 )
                  {
                     WebComp_Wcwcmodule.componentstart();
                  }
               }
            }
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( 1 != 0 )
               {
                  if ( StringUtil.Len( WebComp_Wcwcmodule2_Component) != 0 )
                  {
                     WebComp_Wcwcmodule2.componentstart();
                  }
               }
            }
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( 1 != 0 )
               {
                  if ( StringUtil.Len( WebComp_Wcwcmodule3_Component) != 0 )
                  {
                     WebComp_Wcwcmodule3.componentstart();
                  }
               }
            }
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( 1 != 0 )
               {
                  if ( StringUtil.Len( WebComp_Wcwcmodule4_Component) != 0 )
                  {
                     WebComp_Wcwcmodule4.componentstart();
                  }
               }
            }
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( 1 != 0 )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     WebComp_Wwpaux_wc.componentstart();
                  }
               }
            }
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E242A2 ();
            WB2A0( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes2A2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E172A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vBOOKMARKSDATA_MPAGE"), AV6BookmarksData);
            ajax_req_read_hidden_sdt(cgiGet( "vDVELOP_MENU_MPAGE"), AV26DVelop_Menu);
            ajax_req_read_hidden_sdt(cgiGet( "vDVELOP_MENU_USERDATA_MPAGE"), AV37DVelop_Menu_UserData);
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO_MPAGE"), AV14NotificationInfo);
            /* Read saved values. */
            Ddo_bookmarks_Icontype = cgiGet( "DDO_BOOKMARKS_MPAGE_Icontype");
            Ddo_bookmarks_Icon = cgiGet( "DDO_BOOKMARKS_MPAGE_Icon");
            Ddo_bookmarks_Tooltip = cgiGet( "DDO_BOOKMARKS_MPAGE_Tooltip");
            Ddo_bookmarks_Cls = cgiGet( "DDO_BOOKMARKS_MPAGE_Cls");
            Ddo_bookmarks_Titlecontrolalign = cgiGet( "DDO_BOOKMARKS_MPAGE_Titlecontrolalign");
            Ddc_notificationswc_Icontype = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icontype");
            Ddc_notificationswc_Icon = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icon");
            Ddc_notificationswc_Caption = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Caption");
            Ddc_notificationswc_Cls = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Cls");
            Ddc_adminag_Icontype = cgiGet( "DDC_ADMINAG_MPAGE_Icontype");
            Ddc_adminag_Icon = cgiGet( "DDC_ADMINAG_MPAGE_Icon");
            Ddc_adminag_Caption = cgiGet( "DDC_ADMINAG_MPAGE_Caption");
            Ddc_adminag_Cls = cgiGet( "DDC_ADMINAG_MPAGE_Cls");
            Ddc_adminag_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_ADMINAG_MPAGE_Componentwidth"), ",", "."), 18, MidpointRounding.ToEven));
            Ucmenu_Searchserviceurl = cgiGet( "UCMENU_MPAGE_Searchserviceurl");
            Ucmenu_Searchminchars = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCMENU_MPAGE_Searchminchars"), ",", "."), 18, MidpointRounding.ToEven));
            Ucmenu_Searchhelperdescription = cgiGet( "UCMENU_MPAGE_Searchhelperdescription");
            Ucmenu_Allmenuitemsvisibleatload = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Allmenuitemsvisibleatload"));
            Ucmenu_Includetogglebutton = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Includetogglebutton"));
            Ucmenu_Togglebuttonposition = cgiGet( "UCMENU_MPAGE_Togglebuttonposition");
            Ucmenu_Sidebarmainclass = cgiGet( "UCMENU_MPAGE_Sidebarmainclass");
            Ucmenu_Scrollwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCMENU_MPAGE_Scrollwidth"), ",", "."), 18, MidpointRounding.ToEven));
            Ucmenu_Scrollalwaysvisible = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Scrollalwaysvisible"));
            Ucmenu_Hidescrollincompactmenu = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Hidescrollincompactmenu"));
            Ucmenu_Firstlevelisgrouping = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Firstlevelisgrouping"));
            Ucmessage_Width = cgiGet( "UCMESSAGE_MPAGE_Width");
            Ucmessage_Minheight = cgiGet( "UCMESSAGE_MPAGE_Minheight");
            Ucmessage_Stylingtype = cgiGet( "UCMESSAGE_MPAGE_Stylingtype");
            Ucmessage_Stoponerror = StringUtil.StrToBool( cgiGet( "UCMESSAGE_MPAGE_Stoponerror"));
            Ucmessage_Effectin = cgiGet( "UCMESSAGE_MPAGE_Effectin");
            Ucmessage_Effectout = cgiGet( "UCMESSAGE_MPAGE_Effectout");
            Ucmessage_Animationspeed = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCMESSAGE_MPAGE_Animationspeed"), ",", "."), 18, MidpointRounding.ToEven));
            Ucmessage_Startposition = cgiGet( "UCMESSAGE_MPAGE_Startposition");
            Ucmessage_Nextmessageposition = cgiGet( "UCMESSAGE_MPAGE_Nextmessageposition");
            Wwputilities_Enablefixobjectfitcover = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enablefixobjectfitcover"));
            Wwputilities_Enablefloatinglabels = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enablefloatinglabels"));
            Wwputilities_Empowertabs = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Empowertabs"));
            Wwputilities_Enableupdaterowselectionstatus = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enableupdaterowselectionstatus"));
            Wwputilities_Enableconvertcombotobootstrapselect = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enableconvertcombotobootstrapselect"));
            Wwputilities_Allowcolumnresizing = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnresizing"));
            Wwputilities_Allowcolumnreordering = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnreordering"));
            Wwputilities_Allowcolumndragging = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumndragging"));
            Wwputilities_Allowcolumnsrestore = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnsrestore"));
            Wwputilities_Pagbarincludegoto = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Pagbarincludegoto"));
            Wwputilities_Comboloadtype = cgiGet( "WWPUTILITIES_MPAGE_Comboloadtype");
            Timer_Tickinterval = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TIMER_MPAGE_Tickinterval"), ",", "."), 18, MidpointRounding.ToEven));
            Bookmark_modal_Width = cgiGet( "BOOKMARK_MODAL_MPAGE_Width");
            Bookmark_modal_Title = cgiGet( "BOOKMARK_MODAL_MPAGE_Title");
            Bookmark_modal_Confirmtype = cgiGet( "BOOKMARK_MODAL_MPAGE_Confirmtype");
            Bookmark_modal_Bodytype = cgiGet( "BOOKMARK_MODAL_MPAGE_Bodytype");
            Ddc_notificationswc_Icon = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icon");
            Ddo_bookmarks_Activeeventkey = cgiGet( "DDO_BOOKMARKS_MPAGE_Activeeventkey");
            (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption = cgiGet( "FORM_MPAGE_Caption");
            Ddc_notificationswc_Icon = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icon");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavPickerdummyvariable_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Picker Dummy Variable"}), 1, "vPICKERDUMMYVARIABLE_MPAGE");
               GX_FocusControl = edtavPickerdummyvariable_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV36PickerDummyVariable = DateTime.MinValue;
               AssignAttri("", true, "AV36PickerDummyVariable", context.localUtil.Format(AV36PickerDummyVariable, "99/99/99"));
            }
            else
            {
               AV36PickerDummyVariable = context.localUtil.CToD( cgiGet( edtavPickerdummyvariable_Internalname), 2);
               AssignAttri("", true, "AV36PickerDummyVariable", context.localUtil.Format(AV36PickerDummyVariable, "99/99/99"));
            }
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
         E172A2 ();
         if (returnInSub) return;
      }

      protected void E172A2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( (0==AV44WWpContext.gxTpr_Userid) )
         {
            GXt_SdtWWPContext1 = AV44WWpContext;
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
            AV44WWpContext = GXt_SdtWWPContext1;
         }
         Ddc_adminag_Caption = AV44WWpContext.gxTpr_Userfullname;
         ucDdc_adminag.SendProperty(context, "", true, Ddc_adminag_Internalname, "Caption", Ddc_adminag_Caption);
         /* Using cursor H002A2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A299ConfiguracoesId = H002A2_A299ConfiguracoesId[0];
            AV40Configuracoes.Load(A299ConfiguracoesId);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\""+context.convertURL( (string)(context.GetImagePath( "e9edf59f-db45-4e16-b6a6-2c2b6611a4a3", "", context.GetTheme( ))))+"\">";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml+"<meta charset=\"UTF-8\">";
         divLayoutmaintable_Class = "MainContainer";
         AssignProp("", true, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV39String = AV27WebSession.Get("DmSistema");
         AV38DmSistema = AV39String;
         if ( StringUtil.StrCmp(AV38DmSistema, "Vendas") == 0 )
         {
            GXt_objcol_SdtDVelop_Menu_Item2 = AV26DVelop_Menu;
            new GeneXus.Programs.wwpbaseobjects.menuoptionsdatavendas(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
            AV26DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
            AV47InDVelop_Menu.FromJSonString(AV26DVelop_Menu.ToJSonString(false), null);
            AV26DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
            new pfuncmenu(context ).execute(  AV47InDVelop_Menu, ref  AV26DVelop_Menu) ;
         }
         else if ( StringUtil.StrCmp(AV38DmSistema, "Financeiro") == 0 )
         {
            GXt_objcol_SdtDVelop_Menu_Item2 = AV26DVelop_Menu;
            new GeneXus.Programs.wwpbaseobjects.menuoptionsdata(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
            AV26DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
            AV47InDVelop_Menu.FromJSonString(AV26DVelop_Menu.ToJSonString(false), null);
            AV26DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
            new pfuncmenu(context ).execute(  AV47InDVelop_Menu, ref  AV26DVelop_Menu) ;
         }
         else if ( StringUtil.StrCmp(AV38DmSistema, "Contratos") == 0 )
         {
            GXt_objcol_SdtDVelop_Menu_Item2 = AV26DVelop_Menu;
            new GeneXus.Programs.wwpbaseobjects.menuoptionsdatacontratos(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
            AV26DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
            AV47InDVelop_Menu.FromJSonString(AV26DVelop_Menu.ToJSonString(false), null);
            AV26DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
            new pfuncmenu(context ).execute(  AV47InDVelop_Menu, ref  AV26DVelop_Menu) ;
         }
         else if ( StringUtil.StrCmp(AV38DmSistema, "Seguranca") == 0 )
         {
            GXt_objcol_SdtDVelop_Menu_Item2 = AV26DVelop_Menu;
            new GeneXus.Programs.wwpbaseobjects.menuoptionsdataseguranca(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
            AV26DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
            AV47InDVelop_Menu.FromJSonString(AV26DVelop_Menu.ToJSonString(false), null);
            AV26DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
            new pfuncmenu(context ).execute(  AV47InDVelop_Menu, ref  AV26DVelop_Menu) ;
         }
         AV49IsNotAccess = true;
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV26DVelop_Menu.Count )
         {
            AV48DVelop_MenuItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item)AV26DVelop_Menu.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV48DVelop_MenuItem.gxTpr_Authorizationkey, "") != 0 )
            {
               AV49IsNotAccess = false;
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV49IsNotAccess && ! (0==AV44WWpContext.gxTpr_Userid) )
         {
            CallWebObject(formatLink("notaccess") );
            context.wjLocDisableFrm = 1;
         }
         AV6BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV7BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV7BookmarksDataItem.gxTpr_Title = "Bookmark Page";
         AV7BookmarksDataItem.gxTpr_Fonticon = "fas fa-star FontIconTopRightActions";
         AV7BookmarksDataItem.gxTpr_Eventkey = "Bookmark";
         AV7BookmarksDataItem.gxTpr_Isdivider = false;
         AV6BookmarksData.Add(AV7BookmarksDataItem, 0);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcmodule = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcmodule_Component), StringUtil.Lower( "WcModule")) != 0 )
         {
            WebComp_Wcwcmodule = getWebComponent(GetType(), "GeneXus.Programs", "wcmodule", new Object[] {context} );
            WebComp_Wcwcmodule.ComponentInit();
            WebComp_Wcwcmodule.Name = "WcModule";
            WebComp_Wcwcmodule_Component = "WcModule";
         }
         if ( StringUtil.Len( WebComp_Wcwcmodule_Component) != 0 )
         {
            WebComp_Wcwcmodule.setjustcreated();
            WebComp_Wcwcmodule.componentprepare(new Object[] {(string)"MPW0022",(string)"",(string)"Comercial",(string)"fa-solid fa-money-bills",(string)formatLink("vendas") ,(string)"Vendas"});
            WebComp_Wcwcmodule.componentbind(new Object[] {(string)"",(string)"",(string)""+""+"",(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcmodule2 = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcmodule2_Component), StringUtil.Lower( "WcModule")) != 0 )
         {
            WebComp_Wcwcmodule2 = getWebComponent(GetType(), "GeneXus.Programs", "wcmodule", new Object[] {context} );
            WebComp_Wcwcmodule2.ComponentInit();
            WebComp_Wcwcmodule2.Name = "WcModule";
            WebComp_Wcwcmodule2_Component = "WcModule";
         }
         if ( StringUtil.Len( WebComp_Wcwcmodule2_Component) != 0 )
         {
            WebComp_Wcwcmodule2.setjustcreated();
            WebComp_Wcwcmodule2.componentprepare(new Object[] {(string)"MPW0024",(string)"",(string)"Financeiro",(string)"fa-solid fa-dollar-sign",(string)formatLink("financeiro") ,(string)"Financeiro"});
            WebComp_Wcwcmodule2.componentbind(new Object[] {(string)"",(string)"",(string)""+""+"",(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcmodule3 = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcmodule3_Component), StringUtil.Lower( "WcModule")) != 0 )
         {
            WebComp_Wcwcmodule3 = getWebComponent(GetType(), "GeneXus.Programs", "wcmodule", new Object[] {context} );
            WebComp_Wcwcmodule3.ComponentInit();
            WebComp_Wcwcmodule3.Name = "WcModule";
            WebComp_Wcwcmodule3_Component = "WcModule";
         }
         if ( StringUtil.Len( WebComp_Wcwcmodule3_Component) != 0 )
         {
            WebComp_Wcwcmodule3.setjustcreated();
            WebComp_Wcwcmodule3.componentprepare(new Object[] {(string)"MPW0026",(string)"",(string)"Contratos",(string)"fa-solid fa-file-signature",(string)formatLink("contratos") ,(string)"Contratos"});
            WebComp_Wcwcmodule3.componentbind(new Object[] {(string)"",(string)"",(string)""+""+"",(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcmodule4 = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcmodule4_Component), StringUtil.Lower( "WcModule")) != 0 )
         {
            WebComp_Wcwcmodule4 = getWebComponent(GetType(), "GeneXus.Programs", "wcmodule", new Object[] {context} );
            WebComp_Wcwcmodule4.ComponentInit();
            WebComp_Wcwcmodule4.Name = "WcModule";
            WebComp_Wcwcmodule4_Component = "WcModule";
         }
         if ( StringUtil.Len( WebComp_Wcwcmodule4_Component) != 0 )
         {
            WebComp_Wcwcmodule4.setjustcreated();
            WebComp_Wcwcmodule4.componentprepare(new Object[] {(string)"MPW0028",(string)"",(string)"Segurança",(string)"fa-solid fa-shield-halved",(string)formatLink("seguranca") ,(string)"Seguranca"});
            WebComp_Wcwcmodule4.componentbind(new Object[] {(string)"",(string)"",(string)""+""+"",(string)""});
         }
         Ddo_bookmarks_Tooltip = "Marcadores";
         ucDdo_bookmarks.SendProperty(context, "", true, Ddo_bookmarks_Internalname, "Tooltip", Ddo_bookmarks_Tooltip);
         Ddo_bookmarks_Titlecontrolalign = "Left";
         ucDdo_bookmarks.SendProperty(context, "", true, Ddo_bookmarks_Internalname, "TitleControlAlign", Ddo_bookmarks_Titlecontrolalign);
         if ( StringUtil.StrCmp(AV27WebSession.Get("ClientInformationSaved"), "Y") != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_registerwebclient(context ).execute(  new GeneXus.Core.genexus.client.SdtClientInformation(context).gxTpr_Id,  (short)(context.GetBrowserType( )),  context.GetBrowserVersion( ),  new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( )) ;
            AV27WebSession.Set("ClientInformationSaved", "Y");
         }
         /* Execute user subroutine: 'LOADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV30Httprequest.Method, "GET") == 0 )
         {
            GXt_SdtWWP_DesignSystemSettings3 = AV19WWP_DesignSystemSettings;
            new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings3) ;
            AV19WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings3;
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"base-color",AV19WWP_DesignSystemSettings.gxTpr_Basecolor}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"background-color",AV19WWP_DesignSystemSettings.gxTpr_Backgroundstyle}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"menu-color",AV19WWP_DesignSystemSettings.gxTpr_Menucolor}, false);
            this.executeExternalObjectMethod("", true, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Configuracoes.gxTpr_Configuracoesimagemheadernome)) )
         {
            AV43Source = "resources/Imagemheader." + AV40Configuracoes.gxTpr_Configuracoesimagemheaderextencao;
            AssignAttri("", true, "AV43Source", AV43Source);
            AV41File.Source = AV43Source;
            if ( AV41File.Exists() )
            {
               AV41File.Delete();
            }
            AV41File.Source = AV43Source;
            AV41File.FromBase64(context.FileToBase64( AV40Configuracoes.gxTpr_Configuracoesimagemheader));
            AV41File.Create();
            AV42IMGURL = StringUtil.Format( "file:///%1", AV41File.GetAbsoluteName(), "", "", "", "", "", "", "", "");
            imgImageheader_Bitmap = AV43Source;
            AssignProp("", true, imgImageheader_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgImageheader_Bitmap)), true);
            AssignProp("", true, imgImageheader_Internalname, "SrcSet", context.GetImageSrcSet( imgImageheader_Bitmap), true);
         }
         Timer_Tickinterval = 5;
         ucTimer.SendProperty(context, "", true, Timer_Internalname, "TickInterval", StringUtil.LTrimStr( (decimal)(Timer_Tickinterval), 9, 0));
      }

      protected void E122A2( )
      {
         /* Ddo_bookmarks_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_bookmarks_Activeeventkey, "Bookmark") == 0 )
         {
            /* Execute user subroutine: 'DO BOOKMARK' */
            S122 ();
            if (returnInSub) return;
         }
         if ( StringUtil.StrCmp(Ddo_bookmarks_Activeeventkey, "AddBookmark") == 0 )
         {
            this.executeUsercontrolMethod("", true, "BOOKMARK_MODAL_MPAGEContainer", "Confirm", "", new Object[] {});
         }
         else if ( StringUtil.StrCmp(Ddo_bookmarks_Activeeventkey, "ManageBookmarks") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("AppBookmarks"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
      }

      protected void E162A2( )
      {
         /* Bookmark_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.EditBookmark")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.editbookmark", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.EditBookmark";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.EditBookmark";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0077",(string)"",AV30Httprequest.BaseURL+AV30Httprequest.ScriptName+(String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV30Httprequest.QueryString))) ? "" : "?"+AV30Httprequest.QueryString),(string)AV12ProgramDescription});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""+""+""+""+""+""+""+""+""+"",(string)"",(string)""+""+""+"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0077"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E152A2( )
      {
         /* Bookmark_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E132A2( )
      {
         /* Ddc_notificationswc_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.notifications.common.wwp_masterpagenotificationswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0077",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0077"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E142A2( )
      {
         /* Ddc_adminag_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.WWP_MasterPageTopActionsWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wwp_masterpagetopactionswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.WWP_MasterPageTopActionsWC";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.WWP_MasterPageTopActionsWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0077",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0077"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'DO BOOKMARK' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", true, "BOOKMARK_MODAL_MPAGEContainer", "Confirm", "", new Object[] {});
      }

      protected void E182A2( )
      {
         /* 'DoActionSearch' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.wwp_search"+UrlEncode(StringUtil.RTrim(AV18SearchAux)) + "," + UrlEncode(StringUtil.BoolToStr(false)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("wwpbaseobjects.wwp_search") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E192A2( )
      {
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E202A2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV44WWpContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV44WWpContext = GXt_SdtWWPContext1;
         if ( (0==AV44WWpContext.gxTpr_Userid) )
         {
            CallWebObject(formatLink("login") );
            context.wjLocDisableFrm = 1;
         }
         lblTextblocktitle_Caption = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption;
         AssignProp("", true, lblTextblocktitle_Internalname, "Caption", lblTextblocktitle_Caption, true);
         GXt_boolean4 = false;
         new GeneXus.Programs.wwpbaseobjects.loadbreadcrumb(context ).execute(  AV26DVelop_Menu,  AV30Httprequest.ScriptName, ref  AV35Breadcrumb, ref  GXt_boolean4) ;
         AssignAttri("", true, "AV35Breadcrumb", AV35Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV35Breadcrumb, "")), context));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV35Breadcrumb))) )
         {
            AV35Breadcrumb = AV27WebSession.Get("LastBreadcrumb");
            AssignAttri("", true, "AV35Breadcrumb", AV35Breadcrumb);
            GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV35Breadcrumb, "")), context));
         }
         else
         {
            AV27WebSession.Set("LastBreadcrumb", AV35Breadcrumb);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35Breadcrumb)) )
         {
         }
         else
         {
         }
         /* Execute user subroutine: 'LOADBOOKMARKS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "AV44WWpContext", AV44WWpContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "AV6BookmarksData", AV6BookmarksData);
      }

      protected void E212A2( )
      {
         /* General\GlobalEvents_Master_refreshheader Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E222A2( )
      {
         /* General\GlobalEvents_Master_changeimage Routine */
         returnInSub = false;
         imgImageheader_Bitmap = AV43Source;
         AssignProp("", true, imgImageheader_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgImageheader_Bitmap)), true);
         AssignProp("", true, imgImageheader_Internalname, "SrcSet", context.GetImageSrcSet( imgImageheader_Bitmap), true);
      }

      protected void E232A2( )
      {
         /* General\GlobalEvents_Master_refreshnotifications Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'LOADNOTIFICATIONS' Routine */
         returnInSub = false;
         AV15NotificationsCount = 0;
         /* Using cursor H002A3 */
         pr_default.execute(1, new Object[] {AV44WWpContext.gxTpr_Userid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A381NotificationId = H002A3_A381NotificationId[0];
            n381NotificationId = H002A3_n381NotificationId[0];
            A384NotificationType = H002A3_A384NotificationType[0];
            n384NotificationType = H002A3_n384NotificationType[0];
            A389UserNotificationStatus = H002A3_A389UserNotificationStatus[0];
            n389UserNotificationStatus = H002A3_n389UserNotificationStatus[0];
            A388UserNotificationUserId = H002A3_A388UserNotificationUserId[0];
            n388UserNotificationUserId = H002A3_n388UserNotificationUserId[0];
            A387UserNotificationId = H002A3_A387UserNotificationId[0];
            A384NotificationType = H002A3_A384NotificationType[0];
            n384NotificationType = H002A3_n384NotificationType[0];
            AV46UserNotificationId = A387UserNotificationId;
            AV15NotificationsCount = (short)(AV15NotificationsCount+1);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         this.executeUsercontrolMethod("", true, "DDC_NOTIFICATIONSWC_MPAGEContainer", "Update", "", new Object[] {((AV15NotificationsCount>0) ? StringUtil.Trim( StringUtil.Str( (decimal)(AV15NotificationsCount), 4, 0)) : ""),(string)Ddc_notificationswc_Icon});
      }

      protected void S132( )
      {
         /* 'LOADBOOKMARKS' Routine */
         returnInSub = false;
         AV6BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV7BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV7BookmarksDataItem.gxTpr_Eventkey = "AddBookmark";
         AV7BookmarksDataItem.gxTpr_Isdivider = false;
         AV6BookmarksData.Add(AV7BookmarksDataItem, 0);
         AV12ProgramDescription = Contentholder.Pgmdesc;
         AssignAttri("", true, "AV12ProgramDescription", AV12ProgramDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV12ProgramDescription, "")), context));
         AV8CurrentURL = AV30Httprequest.BaseURL + AV30Httprequest.ScriptName + (String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV30Httprequest.QueryString))) ? "" : "?"+AV30Httprequest.QueryString);
         AV9GridStateCollection.FromXml(new GeneXus.Programs.wwpbaseobjects.loadmanagefiltersstate(context).executeUdp(  "AppBookmarks"), null, "Items", "");
         AV5BookmarkFound = false;
         AV53GXV2 = 1;
         while ( AV53GXV2 <= AV9GridStateCollection.Count )
         {
            AV10GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV9GridStateCollection.Item(AV53GXV2));
            if ( StringUtil.StrCmp(AV10GridStateCollectionItem.gxTpr_Gridstatexml, AV8CurrentURL) == 0 )
            {
               AV12ProgramDescription = AV10GridStateCollectionItem.gxTpr_Title;
               AssignAttri("", true, "AV12ProgramDescription", AV12ProgramDescription);
               GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV12ProgramDescription, "")), context));
               AV5BookmarkFound = true;
               if (true) break;
            }
            AV53GXV2 = (int)(AV53GXV2+1);
         }
         if ( AV5BookmarkFound )
         {
            this.executeUsercontrolMethod("", true, "DDO_BOOKMARKS_MPAGEContainer", "Update", "", new Object[] {(string)"",(string)"fas fa-star "+"FontColorIconBookmarkTitleAdded"});
            AV7BookmarksDataItem.gxTpr_Title = "Editar favorito para esta página";
            AV7BookmarksDataItem.gxTpr_Fonticon = "fas fa-star "+"FontColorIconBookmarkAdded";
         }
         else
         {
            this.executeUsercontrolMethod("", true, "DDO_BOOKMARKS_MPAGEContainer", "Update", "", new Object[] {(string)"",(string)"far fa-star "+"FontColorIconBookmarkTitle"});
            AV7BookmarksDataItem.gxTpr_Title = "Crie um favorito para esta página";
            AV7BookmarksDataItem.gxTpr_Fonticon = "far fa-star "+"FontColorIconBookmark";
         }
         if ( AV9GridStateCollection.Count > 0 )
         {
            AV7BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV7BookmarksDataItem.gxTpr_Isdivider = true;
            AV6BookmarksData.Add(AV7BookmarksDataItem, 0);
            AV54GXV3 = 1;
            while ( AV54GXV3 <= AV9GridStateCollection.Count )
            {
               AV10GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV9GridStateCollection.Item(AV54GXV3));
               AV7BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
               AV7BookmarksDataItem.gxTpr_Title = AV10GridStateCollectionItem.gxTpr_Title;
               AV7BookmarksDataItem.gxTpr_Link = AV10GridStateCollectionItem.gxTpr_Gridstatexml;
               GXt_char5 = AV13FontIcon;
               new GeneXus.Programs.wwpbaseobjects.getbookmarkfonticon(context ).execute(  StringUtil.StringReplace( AV10GridStateCollectionItem.gxTpr_Gridstatexml, AV30Httprequest.BaseURL, ""),  AV26DVelop_Menu, out  GXt_char5) ;
               AV13FontIcon = GXt_char5;
               AV7BookmarksDataItem.gxTpr_Fonticon = ((StringUtil.StrCmp(AV13FontIcon, "")==0) ? "FontColorIconBookmark fas fa-link" : "FontColorIconBookmark"+" "+AV13FontIcon);
               AV7BookmarksDataItem.gxTpr_Isdivider = false;
               AV6BookmarksData.Add(AV7BookmarksDataItem, 0);
               AV11IndexToAddItems = (short)(AV11IndexToAddItems+1);
               AssignAttri("", true, "AV11IndexToAddItems", StringUtil.LTrimStr( (decimal)(AV11IndexToAddItems), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV11IndexToAddItems), "ZZZ9"), context));
               AV54GXV3 = (int)(AV54GXV3+1);
            }
            AV7BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV7BookmarksDataItem.gxTpr_Isdivider = true;
            AV6BookmarksData.Add(AV7BookmarksDataItem, 0);
            AV7BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV7BookmarksDataItem.gxTpr_Title = "Bookmark manager";
            AV7BookmarksDataItem.gxTpr_Fonticon = "fas fa-cog "+"FontColorIconBookmark";
            AV7BookmarksDataItem.gxTpr_Eventkey = "ManageBookmarks";
            AV7BookmarksDataItem.gxTpr_Isdivider = false;
            AV6BookmarksData.Add(AV7BookmarksDataItem, 0);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E242A2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_71_2A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablebookmark_modal_Internalname, tblTablebookmark_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucBookmark_modal.SetProperty("Width", Bookmark_modal_Width);
            ucBookmark_modal.SetProperty("Title", Bookmark_modal_Title);
            ucBookmark_modal.SetProperty("ConfirmType", Bookmark_modal_Confirmtype);
            ucBookmark_modal.SetProperty("BodyType", Bookmark_modal_Bodytype);
            ucBookmark_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Bookmark_modal_Internalname, "BOOKMARK_MODAL_MPAGEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"BOOKMARK_MODAL_MPAGEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_71_2A2e( true) ;
         }
         else
         {
            wb_table1_71_2A2e( false) ;
         }
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
         PA2A2( ) ;
         WS2A2( ) ;
         WE2A2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/DVMessage/DVMessage.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/fontawesome_vlatest/css/all.min.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwcmodule == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcmodule_Component) != 0 )
            {
               WebComp_Wcwcmodule.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcwcmodule2 == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcmodule2_Component) != 0 )
            {
               WebComp_Wcwcmodule2.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcwcmodule3 == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcmodule3_Component) != 0 )
            {
               WebComp_Wcwcmodule3.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcwcmodule4 == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcmodule4_Component) != 0 )
            {
               WebComp_Wcwcmodule4.componentthemes();
            }
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?202561019233184", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/workwithplusmasterpage.js", "?202561019233187", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/slimscroll/jquery.slimscroll.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/SidebarMenu/BootstrapSidebarMenuRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Tooltip/BootstrapTooltipRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DatePicker/DatePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Chronometer/ChronometerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgImageheader_Internalname = "IMAGEHEADER_MPAGE";
         divTablelogologin_Internalname = "TABLELOGOLOGIN_MPAGE";
         lblShowmenu_Internalname = "SHOWMENU_MPAGE";
         divTablemodules_Internalname = "TABLEMODULES_MPAGE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1_MPAGE";
         Ddo_bookmarks_Internalname = "DDO_BOOKMARKS_MPAGE";
         Ddc_notificationswc_Internalname = "DDC_NOTIFICATIONSWC_MPAGE";
         Ddc_adminag_Internalname = "DDC_ADMINAG_MPAGE";
         divTableuserrole_Internalname = "TABLEUSERROLE_MPAGE";
         divTableheader_Internalname = "TABLEHEADER_MPAGE";
         lblTextblocktitle_Internalname = "TEXTBLOCKTITLE_MPAGE";
         divTabletitle_Internalname = "TABLETITLE_MPAGE";
         divTablecontent_Internalname = "TABLECONTENT_MPAGE";
         Ucmenu_Internalname = "UCMENU_MPAGE";
         Ucmessage_Internalname = "UCMESSAGE_MPAGE";
         Uctooltip_Internalname = "UCTOOLTIP_MPAGE";
         Wwputilities_Internalname = "WWPUTILITIES_MPAGE";
         Wwpdatepicker_Internalname = "WWPDATEPICKER_MPAGE";
         Timer_Internalname = "TIMER_MPAGE";
         divTablemain_Internalname = "TABLEMAIN_MPAGE";
         edtavPickerdummyvariable_Internalname = "vPICKERDUMMYVARIABLE_MPAGE";
         Bookmark_modal_Internalname = "BOOKMARK_MODAL_MPAGE";
         tblTablebookmark_modal_Internalname = "TABLEBOOKMARK_MODAL_MPAGE";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC_MPAGE";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS_MPAGE";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavPickerdummyvariable_Jsonclick = "";
         lblTextblocktitle_Caption = " Title";
         imgImageheader_Bitmap = "(none)";
         divLayoutmaintable_Class = "Table";
         Bookmark_modal_Bodytype = "WebComponent";
         Bookmark_modal_Confirmtype = "";
         Bookmark_modal_Title = "Add/Edit Bookmark";
         Bookmark_modal_Width = "735";
         Timer_Tickinterval = 1;
         Wwputilities_Comboloadtype = "InfiniteScrolling";
         Wwputilities_Pagbarincludegoto = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnsrestore = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumndragging = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnreordering = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnresizing = Convert.ToBoolean( -1);
         Wwputilities_Enableconvertcombotobootstrapselect = Convert.ToBoolean( -1);
         Wwputilities_Enableupdaterowselectionstatus = Convert.ToBoolean( -1);
         Wwputilities_Empowertabs = Convert.ToBoolean( -1);
         Wwputilities_Enablefloatinglabels = Convert.ToBoolean( -1);
         Wwputilities_Enablefixobjectfitcover = Convert.ToBoolean( -1);
         Ucmessage_Nextmessageposition = "down";
         Ucmessage_Startposition = "TopRight";
         Ucmessage_Animationspeed = 300;
         Ucmessage_Effectout = "slide";
         Ucmessage_Effectin = "slide";
         Ucmessage_Stoponerror = Convert.ToBoolean( -1);
         Ucmessage_Stylingtype = "fontawesome";
         Ucmessage_Minheight = "16";
         Ucmessage_Width = "500";
         Ucmenu_Firstlevelisgrouping = Convert.ToBoolean( 0);
         Ucmenu_Hidescrollincompactmenu = Convert.ToBoolean( 0);
         Ucmenu_Scrollalwaysvisible = Convert.ToBoolean( 0);
         Ucmenu_Scrollwidth = 10;
         Ucmenu_Sidebarmainclass = "page-sidebar sidebar-fixed MaterialStyle";
         Ucmenu_Togglebuttonposition = "Top";
         Ucmenu_Includetogglebutton = Convert.ToBoolean( 0);
         Ucmenu_Allmenuitemsvisibleatload = Convert.ToBoolean( 0);
         Ucmenu_Searchhelperdescription = "WWP_SearchMenuOption";
         Ucmenu_Searchminchars = 0;
         Ucmenu_Searchserviceurl = "xxx";
         Ddc_adminag_Componentwidth = 260;
         Ddc_adminag_Cls = "DropDownOptionsNoBackHover";
         Ddc_adminag_Caption = "";
         Ddc_adminag_Icon = "fas fa-user";
         Ddc_adminag_Icontype = "FontIcon";
         Ddc_notificationswc_Cls = "DropDownNotification";
         Ddc_notificationswc_Caption = "999";
         Ddc_notificationswc_Icon = "far fa-bell";
         Ddc_notificationswc_Icontype = "FontIcon";
         Ddo_bookmarks_Titlecontrolalign = "Automatic";
         Ddo_bookmarks_Cls = "DropDownOptionsNoBackHover";
         Ddo_bookmarks_Tooltip = "";
         Ddo_bookmarks_Icon = "far fa-star";
         Ddo_bookmarks_Icontype = "FontIcon";
         Contentholder.setDataArea(getDataAreaObject());
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
         setEventMetadata("REFRESH_MPAGE","""{"handler":"Refresh","iparms":[{"ctrl":"FORM_MPAGE","prop":"Caption"},{"av":"AV26DVelop_Menu","fld":"vDVELOP_MENU_MPAGE","type":""},{"av":"AV30Httprequest.BaseURL","ctrl":"vHTTPREQUEST_MPAGE","prop":"Baseurl"},{"av":"AV12ProgramDescription","fld":"vPROGRAMDESCRIPTION_MPAGE","hsh":true,"type":"svchar"},{"av":"AV18SearchAux","fld":"vSEARCHAUX_MPAGE","hsh":true,"type":"svchar"},{"av":"AV35Breadcrumb","fld":"vBREADCRUMB_MPAGE","hsh":true,"type":"svchar"},{"av":"AV11IndexToAddItems","fld":"vINDEXTOADDITEMS_MPAGE","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH_MPAGE",""","oparms":[{"av":"AV44WWpContext","fld":"vWWPCONTEXT_MPAGE","type":""},{"av":"lblTextblocktitle_Caption","ctrl":"TEXTBLOCKTITLE_MPAGE","prop":"Caption"},{"av":"AV35Breadcrumb","fld":"vBREADCRUMB_MPAGE","hsh":true,"type":"svchar"},{"av":"AV6BookmarksData","fld":"vBOOKMARKSDATA_MPAGE","type":""},{"av":"AV12ProgramDescription","fld":"vPROGRAMDESCRIPTION_MPAGE","hsh":true,"type":"svchar"},{"av":"AV11IndexToAddItems","fld":"vINDEXTOADDITEMS_MPAGE","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("DDO_BOOKMARKS_MPAGE.ONOPTIONCLICKED_MPAGE","""{"handler":"E122A2","iparms":[{"av":"Ddo_bookmarks_Activeeventkey","ctrl":"DDO_BOOKMARKS_MPAGE","prop":"ActiveEventKey"}]}""");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE","""{"handler":"E162A2","iparms":[{"av":"AV30Httprequest.BaseURL","ctrl":"vHTTPREQUEST_MPAGE","prop":"Baseurl"},{"av":"AV12ProgramDescription","fld":"vPROGRAMDESCRIPTION_MPAGE","hsh":true,"type":"svchar"}]""");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE",""","oparms":[{"ctrl":"WWPAUX_WC_MPAGE"}]}""");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE","""{"handler":"E152A2","iparms":[]}""");
         setEventMetadata("DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE","""{"handler":"E132A2","iparms":[]""");
         setEventMetadata("DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE",""","oparms":[{"ctrl":"WWPAUX_WC_MPAGE"}]}""");
         setEventMetadata("DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE","""{"handler":"E142A2","iparms":[]""");
         setEventMetadata("DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE",""","oparms":[{"ctrl":"WWPAUX_WC_MPAGE"}]}""");
         setEventMetadata("DOSHOWMENU_MPAGE","""{"handler":"E112A1","iparms":[]}""");
         setEventMetadata("DOACTIONSEARCH_MPAGE","""{"handler":"E182A2","iparms":[{"av":"AV18SearchAux","fld":"vSEARCHAUX_MPAGE","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE","""{"handler":"E212A2","iparms":[]}""");
         setEventMetadata("GLOBALEVENTS_MPAGE.MASTER_CHANGEIMAGE_MPAGE","""{"handler":"E222A2","iparms":[{"av":"AV43Source","fld":"vSOURCE_MPAGE","type":"svchar"}]}""");
         setEventMetadata("GLOBALEVENTS_MPAGE.MASTER_REFRESHNOTIFICATIONS_MPAGE","""{"handler":"E232A2","iparms":[{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID_MPAGE","pic":"ZZZ9","type":"int"},{"av":"AV44WWpContext","fld":"vWWPCONTEXT_MPAGE","type":""},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS_MPAGE","type":"svchar"},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE_MPAGE","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID_MPAGE","pic":"ZZZZZZZZ9","type":"int"},{"av":"Ddc_notificationswc_Icon","ctrl":"DDC_NOTIFICATIONSWC_MPAGE","prop":"Icon"}]}""");
         setEventMetadata("ONMESSAGE_GX1_MPAGE","""{"handler":"E192A2","iparms":[{"av":"AV14NotificationInfo","fld":"vNOTIFICATIONINFO_MPAGE","type":""},{"av":"A388UserNotificationUserId","fld":"USERNOTIFICATIONUSERID_MPAGE","pic":"ZZZ9","type":"int"},{"av":"AV44WWpContext","fld":"vWWPCONTEXT_MPAGE","type":""},{"av":"A389UserNotificationStatus","fld":"USERNOTIFICATIONSTATUS_MPAGE","type":"svchar"},{"av":"A384NotificationType","fld":"NOTIFICATIONTYPE_MPAGE","type":"svchar"},{"av":"A387UserNotificationId","fld":"USERNOTIFICATIONID_MPAGE","pic":"ZZZZZZZZ9","type":"int"},{"av":"Ddc_notificationswc_Icon","ctrl":"DDC_NOTIFICATIONSWC_MPAGE","prop":"Icon"}]}""");
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
         Contentholder = new GXDataAreaControl();
         Ddo_bookmarks_Activeeventkey = "";
         AV30Httprequest = new GxHttpRequest( context);
         AV12ProgramDescription = "";
         AV18SearchAux = "";
         AV35Breadcrumb = "";
         GXKey = "";
         AV6BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV26DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         AV37DVelop_Menu_UserData = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_UserData(context);
         AV43Source = "";
         AV44WWpContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         A389UserNotificationStatus = "";
         A384NotificationType = "";
         AV14NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         sPrefix = "";
         ClassString = "";
         imgImageheader_gximage = "";
         StyleString = "";
         sImgUrl = "";
         lblShowmenu_Jsonclick = "";
         WebComp_Wcwcmodule_Component = "";
         OldWcwcmodule = "";
         WebComp_Wcwcmodule2_Component = "";
         OldWcwcmodule2 = "";
         WebComp_Wcwcmodule3_Component = "";
         OldWcwcmodule3 = "";
         WebComp_Wcwcmodule4_Component = "";
         OldWcwcmodule4 = "";
         ucDdo_bookmarks = new GXUserControl();
         Ddo_bookmarks_Caption = "";
         ucDdc_notificationswc = new GXUserControl();
         ucDdc_adminag = new GXUserControl();
         lblTextblocktitle_Jsonclick = "";
         ucUcmenu = new GXUserControl();
         ucUcmessage = new GXUserControl();
         ucUctooltip = new GXUserControl();
         ucWwputilities = new GXUserControl();
         ucWwpdatepicker = new GXUserControl();
         ucTimer = new GXUserControl();
         TempTags = "";
         AV36PickerDummyVariable = DateTime.MinValue;
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GX_FocusControl = "";
         H002A2_A299ConfiguracoesId = new int[1] ;
         AV40Configuracoes = new SdtConfiguracoes(context);
         AV39String = "";
         AV27WebSession = context.GetSession();
         AV38DmSistema = "";
         AV47InDVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         GXt_objcol_SdtDVelop_Menu_Item2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         AV48DVelop_MenuItem = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         AV7BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV19WWP_DesignSystemSettings = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         GXt_SdtWWP_DesignSystemSettings3 = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         AV41File = new GxFile(context.GetPhysicalPath());
         AV42IMGURL = "";
         GXEncryptionTmp = "";
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H002A3_A381NotificationId = new int[1] ;
         H002A3_n381NotificationId = new bool[] {false} ;
         H002A3_A384NotificationType = new string[] {""} ;
         H002A3_n384NotificationType = new bool[] {false} ;
         H002A3_A389UserNotificationStatus = new string[] {""} ;
         H002A3_n389UserNotificationStatus = new bool[] {false} ;
         H002A3_A388UserNotificationUserId = new short[1] ;
         H002A3_n388UserNotificationUserId = new bool[] {false} ;
         H002A3_A387UserNotificationId = new int[1] ;
         AV8CurrentURL = "";
         AV9GridStateCollection = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item>( context, "Item", "");
         AV10GridStateCollectionItem = new GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item(context);
         AV13FontIcon = "";
         GXt_char5 = "";
         sStyleString = "";
         ucBookmark_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage__default(),
            new Object[][] {
                new Object[] {
               H002A2_A299ConfiguracoesId
               }
               , new Object[] {
               H002A3_A381NotificationId, H002A3_n381NotificationId, H002A3_A384NotificationType, H002A3_n384NotificationType, H002A3_A389UserNotificationStatus, H002A3_n389UserNotificationStatus, H002A3_A388UserNotificationUserId, H002A3_n388UserNotificationUserId, H002A3_A387UserNotificationId
               }
            }
         );
         WebComp_Wcwcmodule = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcwcmodule2 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcwcmodule3 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcwcmodule4 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short GxWebError ;
      private short AV11IndexToAddItems ;
      private short A388UserNotificationUserId ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV15NotificationsCount ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int A387UserNotificationId ;
      private int Ddc_adminag_Componentwidth ;
      private int Ucmenu_Searchminchars ;
      private int Ucmenu_Scrollwidth ;
      private int Ucmessage_Animationspeed ;
      private int Timer_Tickinterval ;
      private int A299ConfiguracoesId ;
      private int AV51GXV1 ;
      private int A381NotificationId ;
      private int AV46UserNotificationId ;
      private int AV53GXV2 ;
      private int AV54GXV3 ;
      private int idxLst ;
      private string Ddo_bookmarks_Activeeventkey ;
      private string Ddc_notificationswc_Icon ;
      private string GXKey ;
      private string Ddo_bookmarks_Icontype ;
      private string Ddo_bookmarks_Icon ;
      private string Ddo_bookmarks_Tooltip ;
      private string Ddo_bookmarks_Cls ;
      private string Ddo_bookmarks_Titlecontrolalign ;
      private string Ddc_notificationswc_Icontype ;
      private string Ddc_notificationswc_Caption ;
      private string Ddc_notificationswc_Cls ;
      private string Ddc_adminag_Icontype ;
      private string Ddc_adminag_Icon ;
      private string Ddc_adminag_Caption ;
      private string Ddc_adminag_Cls ;
      private string Ucmenu_Searchserviceurl ;
      private string Ucmenu_Searchhelperdescription ;
      private string Ucmenu_Togglebuttonposition ;
      private string Ucmenu_Sidebarmainclass ;
      private string Ucmessage_Width ;
      private string Ucmessage_Minheight ;
      private string Ucmessage_Stylingtype ;
      private string Ucmessage_Effectin ;
      private string Ucmessage_Effectout ;
      private string Ucmessage_Startposition ;
      private string Ucmessage_Nextmessageposition ;
      private string Wwputilities_Comboloadtype ;
      private string Bookmark_modal_Width ;
      private string Bookmark_modal_Title ;
      private string Bookmark_modal_Confirmtype ;
      private string Bookmark_modal_Bodytype ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divTablelogologin_Internalname ;
      private string ClassString ;
      private string imgImageheader_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImageheader_Internalname ;
      private string lblShowmenu_Internalname ;
      private string lblShowmenu_Jsonclick ;
      private string divTablemodules_Internalname ;
      private string WebComp_Wcwcmodule_Component ;
      private string OldWcwcmodule ;
      private string WebComp_Wcwcmodule2_Component ;
      private string OldWcwcmodule2 ;
      private string WebComp_Wcwcmodule3_Component ;
      private string OldWcwcmodule3 ;
      private string WebComp_Wcwcmodule4_Component ;
      private string OldWcwcmodule4 ;
      private string divTableuserrole_Internalname ;
      private string Ddo_bookmarks_Caption ;
      private string Ddo_bookmarks_Internalname ;
      private string Ddc_notificationswc_Internalname ;
      private string Ddc_adminag_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTabletitle_Internalname ;
      private string lblTextblocktitle_Internalname ;
      private string lblTextblocktitle_Caption ;
      private string lblTextblocktitle_Jsonclick ;
      private string Ucmenu_Internalname ;
      private string Ucmessage_Internalname ;
      private string Uctooltip_Internalname ;
      private string Wwputilities_Internalname ;
      private string Wwpdatepicker_Internalname ;
      private string Timer_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string TempTags ;
      private string edtavPickerdummyvariable_Internalname ;
      private string edtavPickerdummyvariable_Jsonclick ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GX_FocusControl ;
      private string GXEncryptionTmp ;
      private string GXt_char5 ;
      private string sStyleString ;
      private string tblTablebookmark_modal_Internalname ;
      private string Bookmark_modal_Internalname ;
      private string sDynURL ;
      private DateTime AV36PickerDummyVariable ;
      private bool Ucmenu_Allmenuitemsvisibleatload ;
      private bool Ucmenu_Includetogglebutton ;
      private bool Ucmenu_Scrollalwaysvisible ;
      private bool Ucmenu_Hidescrollincompactmenu ;
      private bool Ucmenu_Firstlevelisgrouping ;
      private bool Ucmessage_Stoponerror ;
      private bool Wwputilities_Enablefixobjectfitcover ;
      private bool Wwputilities_Enablefloatinglabels ;
      private bool Wwputilities_Empowertabs ;
      private bool Wwputilities_Enableupdaterowselectionstatus ;
      private bool Wwputilities_Enableconvertcombotobootstrapselect ;
      private bool Wwputilities_Allowcolumnresizing ;
      private bool Wwputilities_Allowcolumnreordering ;
      private bool Wwputilities_Allowcolumndragging ;
      private bool Wwputilities_Allowcolumnsrestore ;
      private bool Wwputilities_Pagbarincludegoto ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV49IsNotAccess ;
      private bool bDynCreated_Wcwcmodule ;
      private bool bDynCreated_Wcwcmodule2 ;
      private bool bDynCreated_Wcwcmodule3 ;
      private bool bDynCreated_Wcwcmodule4 ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean4 ;
      private bool n381NotificationId ;
      private bool n384NotificationType ;
      private bool n389UserNotificationStatus ;
      private bool n388UserNotificationUserId ;
      private bool AV5BookmarkFound ;
      private string AV12ProgramDescription ;
      private string AV18SearchAux ;
      private string AV35Breadcrumb ;
      private string AV43Source ;
      private string A389UserNotificationStatus ;
      private string A384NotificationType ;
      private string AV39String ;
      private string AV38DmSistema ;
      private string AV42IMGURL ;
      private string AV8CurrentURL ;
      private string AV13FontIcon ;
      private string imgImageheader_Bitmap ;
      private IGxSession AV27WebSession ;
      private GXWebComponent WebComp_Wcwcmodule ;
      private GXWebComponent WebComp_Wcwcmodule2 ;
      private GXWebComponent WebComp_Wcwcmodule3 ;
      private GXWebComponent WebComp_Wcwcmodule4 ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDdo_bookmarks ;
      private GXUserControl ucDdc_notificationswc ;
      private GXUserControl ucDdc_adminag ;
      private GXUserControl ucUcmenu ;
      private GXUserControl ucUcmessage ;
      private GXUserControl ucUctooltip ;
      private GXUserControl ucWwputilities ;
      private GXUserControl ucWwpdatepicker ;
      private GXUserControl ucTimer ;
      private GXUserControl ucBookmark_modal ;
      private GxHttpRequest AV30Httprequest ;
      private GxFile AV41File ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contentholder ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV6BookmarksData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV26DVelop_Menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_UserData AV37DVelop_Menu_UserData ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV44WWpContext ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV14NotificationInfo ;
      private IDataStoreProvider pr_default ;
      private int[] H002A2_A299ConfiguracoesId ;
      private SdtConfiguracoes AV40Configuracoes ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV47InDVelop_Menu ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV48DVelop_MenuItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV7BookmarksDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings AV19WWP_DesignSystemSettings ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings GXt_SdtWWP_DesignSystemSettings3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private int[] H002A3_A381NotificationId ;
      private bool[] H002A3_n381NotificationId ;
      private string[] H002A3_A384NotificationType ;
      private bool[] H002A3_n384NotificationType ;
      private string[] H002A3_A389UserNotificationStatus ;
      private bool[] H002A3_n389UserNotificationStatus ;
      private short[] H002A3_A388UserNotificationUserId ;
      private bool[] H002A3_n388UserNotificationUserId ;
      private int[] H002A3_A387UserNotificationId ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item> AV9GridStateCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item AV10GridStateCollectionItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class workwithplusmasterpage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002A2;
          prmH002A2 = new Object[] {
          };
          Object[] prmH002A3;
          prmH002A3 = new Object[] {
          new ParDef("AV44WWpContext__Userid",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002A2", "SELECT ConfiguracoesId FROM Configuracoes ORDER BY ConfiguracoesId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002A2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002A3", "SELECT DISTINCT NULL AS NotificationId, NULL AS NotificationType, NULL AS UserNotificationStatus, NULL AS UserNotificationUserId, UserNotificationId FROM ( SELECT T1.NotificationId, T2.NotificationType, T1.UserNotificationStatus, T1.UserNotificationUserId, T1.UserNotificationId FROM (UserNotification T1 LEFT JOIN Notification T2 ON T2.NotificationId = T1.NotificationId) WHERE (T1.UserNotificationUserId = :AV44WWpContext__Userid) AND (T1.UserNotificationStatus = ( 'Unread')) AND (T2.NotificationType = ( 'Internal')) ORDER BY T1.UserNotificationUserId) DistinctT ORDER BY UserNotificationUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002A3,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
