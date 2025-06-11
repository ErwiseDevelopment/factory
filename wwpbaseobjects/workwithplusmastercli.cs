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
   public class workwithplusmastercli : GXMasterPage
   {
      public workwithplusmastercli( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithplusmastercli( IGxContext context )
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
            PA632( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS632( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE632( ) ;
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
         GxWebStd.gx_hidden_field( context, "vPROGRAMDESCRIPTION_MPAGE", AV13ProgramDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV13ProgramDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "vSEARCHAUX_MPAGE", AV18SearchAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHAUX_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV18SearchAux, "")), context));
         GxWebStd.gx_hidden_field( context, "vBREADCRUMB_MPAGE", AV27Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV27Breadcrumb, "")), context));
         GxWebStd.gx_hidden_field( context, "vINDEXTOADDITEMS_MPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12IndexToAddItems), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV12IndexToAddItems), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vBOOKMARKSDATA_MPAGE", AV7BookmarksData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBOOKMARKSDATA_MPAGE", AV7BookmarksData);
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vDVELOP_MENU_USERDATA_MPAGE", AV5DVelop_Menu_UserData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDVELOP_MENU_USERDATA_MPAGE", AV5DVelop_Menu_UserData);
         }
         GxWebStd.gx_hidden_field( context, "vPROGRAMDESCRIPTION_MPAGE", AV13ProgramDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV13ProgramDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "vSEARCHAUX_MPAGE", AV18SearchAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHAUX_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV18SearchAux, "")), context));
         GxWebStd.gx_hidden_field( context, "vBREADCRUMB_MPAGE", AV27Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV27Breadcrumb, "")), context));
         GxWebStd.gx_hidden_field( context, "vINDEXTOADDITEMS_MPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12IndexToAddItems), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV12IndexToAddItems), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSOURCE_MPAGE", AV38Source);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vNOTIFICATIONINFO_MPAGE", AV15NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO_MPAGE", AV15NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Icontype", StringUtil.RTrim( Ddo_bookmarks_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Icon", StringUtil.RTrim( Ddo_bookmarks_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Tooltip", StringUtil.RTrim( Ddo_bookmarks_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Cls", StringUtil.RTrim( Ddo_bookmarks_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Titlecontrolalign", StringUtil.RTrim( Ddo_bookmarks_Titlecontrolalign));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Icontype", StringUtil.RTrim( Ddc_adminag_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Icon", StringUtil.RTrim( Ddc_adminag_Icon));
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
         GxWebStd.gx_hidden_field( context, "vHTTPREQUEST_MPAGE_Baseurl", StringUtil.RTrim( AV31Httprequest.BaseURL));
         GxWebStd.gx_hidden_field( context, "FORM_MPAGE_Caption", StringUtil.RTrim( (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Activeeventkey", StringUtil.RTrim( Ddo_bookmarks_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "FORM_MPAGE_Caption", StringUtil.RTrim( (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption));
      }

      protected void RenderHtmlCloseForm632( )
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
         context.AddJavascriptSource("wwpbaseobjects/workwithplusmastercli.js", "?202561019254626", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WorkWithPlusMasterCli" ;
      }

      public override string GetPgmdesc( )
      {
         return "Master Page" ;
      }

      protected void WB630( )
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
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
            GxWebStd.gx_bitmap( context, imgImageheader_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects/WorkWithPlusMasterCli.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblShowmenu_Internalname, "<i class=\"fa fa-bars ImageMenuIcon\"></i>", "", "", lblShowmenu_Jsonclick, "'"+""+"'"+",true,"+"'"+"e11631_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/WorkWithPlusMasterCli.htm");
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
            ucDdo_bookmarks.SetProperty("DropDownOptionsData", AV7BookmarksData);
            ucDdo_bookmarks.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_bookmarks_Internalname, "DDO_BOOKMARKS_MPAGEContainer");
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
            GxWebStd.gx_label_ctrl( context, lblTextblocktitle_Internalname, lblTextblocktitle_Caption, "", "", lblTextblocktitle_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlockTitleMaster", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WorkWithPlusMasterCli.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSubtitle_Internalname, lblSubtitle_Caption, "", "", lblSubtitle_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", lblSubtitle_Visible, 1, 0, 1, "HLP_WWPBaseObjects/WorkWithPlusMasterCli.htm");
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
            ucUcmenu.SetProperty("SidebarMenuUserData", AV5DVelop_Menu_UserData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',true,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavPickerdummyvariable_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavPickerdummyvariable_Internalname, context.localUtil.Format(AV32PickerDummyVariable, "99/99/99"), context.localUtil.Format( AV32PickerDummyVariable, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "", "", "", edtavPickerdummyvariable_Jsonclick, 0, "Invisible", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/WorkWithPlusMasterCli.htm");
            GxWebStd.gx_bitmap( context, edtavPickerdummyvariable_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/WorkWithPlusMasterCli.htm");
            context.WriteHtmlTextNl( "</div>") ;
            wb_table1_62_632( true) ;
         }
         else
         {
            wb_table1_62_632( false) ;
         }
         return  ;
      }

      protected void wb_table1_62_632e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "MPW0068"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0068"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0068"+"");
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

      protected void START632( )
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
         STRUP630( ) ;
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

      protected void WS632( )
      {
         START632( ) ;
         EVT632( ) ;
      }

      protected void EVT632( )
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
                           E12632 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddc_adminag.Onloadcomponent */
                           E13632 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Bookmark_modal.Close */
                           E14632 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Bookmark_modal.Onloadcomponent */
                           E15632 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E16632 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DOACTIONSEARCH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'DoActionSearch' */
                           E17632 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E18632 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E19632 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS_MPAGE.MASTER_CHANGEIMAGE_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E20632 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E21632 ();
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
                     if ( nCmpId == 68 )
                     {
                        OldWwpaux_wc = cgiGet( "MPW0068");
                        if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                        {
                           WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                           WebComp_Wwpaux_wc.ComponentInit();
                           WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                        {
                           WebComp_Wwpaux_wc.componentprocess("MPW0068", "", sEvt);
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

      protected void WE632( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm632( ) ;
            }
         }
      }

      protected void PA632( )
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
         RF632( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF632( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            /* Execute user event: Refresh */
            E18632 ();
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
            E21632 ();
            WB630( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes632( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP630( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16632 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vBOOKMARKSDATA_MPAGE"), AV7BookmarksData);
            ajax_req_read_hidden_sdt(cgiGet( "vDVELOP_MENU_MPAGE"), AV26DVelop_Menu);
            ajax_req_read_hidden_sdt(cgiGet( "vDVELOP_MENU_USERDATA_MPAGE"), AV5DVelop_Menu_UserData);
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO_MPAGE"), AV15NotificationInfo);
            /* Read saved values. */
            Ddo_bookmarks_Icontype = cgiGet( "DDO_BOOKMARKS_MPAGE_Icontype");
            Ddo_bookmarks_Icon = cgiGet( "DDO_BOOKMARKS_MPAGE_Icon");
            Ddo_bookmarks_Tooltip = cgiGet( "DDO_BOOKMARKS_MPAGE_Tooltip");
            Ddo_bookmarks_Cls = cgiGet( "DDO_BOOKMARKS_MPAGE_Cls");
            Ddo_bookmarks_Titlecontrolalign = cgiGet( "DDO_BOOKMARKS_MPAGE_Titlecontrolalign");
            Ddc_adminag_Icontype = cgiGet( "DDC_ADMINAG_MPAGE_Icontype");
            Ddc_adminag_Icon = cgiGet( "DDC_ADMINAG_MPAGE_Icon");
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
            Ddo_bookmarks_Activeeventkey = cgiGet( "DDO_BOOKMARKS_MPAGE_Activeeventkey");
            (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption = cgiGet( "FORM_MPAGE_Caption");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavPickerdummyvariable_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Picker Dummy Variable"}), 1, "vPICKERDUMMYVARIABLE_MPAGE");
               GX_FocusControl = edtavPickerdummyvariable_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV32PickerDummyVariable = DateTime.MinValue;
               AssignAttri("", true, "AV32PickerDummyVariable", context.localUtil.Format(AV32PickerDummyVariable, "99/99/99"));
            }
            else
            {
               AV32PickerDummyVariable = context.localUtil.CToD( cgiGet( edtavPickerdummyvariable_Internalname), 2);
               AssignAttri("", true, "AV32PickerDummyVariable", context.localUtil.Format(AV32PickerDummyVariable, "99/99/99"));
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
         E16632 ();
         if (returnInSub) return;
      }

      protected void E16632( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( (0==AV39WWpContext.gxTpr_Userid) )
         {
            GXt_SdtWWPContext1 = AV39WWpContext;
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
            AV39WWpContext = GXt_SdtWWPContext1;
         }
         /* Using cursor H00632 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A299ConfiguracoesId = H00632_A299ConfiguracoesId[0];
            AV35Configuracoes.Load(A299ConfiguracoesId);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\""+context.convertURL( (string)(context.GetImagePath( "e9edf59f-db45-4e16-b6a6-2c2b6611a4a3", "", context.GetTheme( ))))+"\">";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml+"<meta charset=\"UTF-8\">";
         divLayoutmaintable_Class = "MainContainer";
         AssignProp("", true, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         GXt_objcol_SdtDVelop_Menu_Item2 = AV26DVelop_Menu;
         new GeneXus.Programs.wwpbaseobjects.menuoptionsdatacliente(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
         AV26DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
         AV7BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV8BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV8BookmarksDataItem.gxTpr_Title = "Bookmark Page";
         AV8BookmarksDataItem.gxTpr_Fonticon = "fas fa-star FontIconTopRightActions";
         AV8BookmarksDataItem.gxTpr_Eventkey = "Bookmark";
         AV8BookmarksDataItem.gxTpr_Isdivider = false;
         AV7BookmarksData.Add(AV8BookmarksDataItem, 0);
         Ddo_bookmarks_Tooltip = "Marcadores";
         ucDdo_bookmarks.SendProperty(context, "", true, Ddo_bookmarks_Internalname, "Tooltip", Ddo_bookmarks_Tooltip);
         Ddo_bookmarks_Titlecontrolalign = "Left";
         ucDdo_bookmarks.SendProperty(context, "", true, Ddo_bookmarks_Internalname, "TitleControlAlign", Ddo_bookmarks_Titlecontrolalign);
         if ( StringUtil.StrCmp(AV28WebSession.Get("ClientInformationSaved"), "Y") != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_registerwebclient(context ).execute(  new GeneXus.Core.genexus.client.SdtClientInformation(context).gxTpr_Id,  (short)(context.GetBrowserType( )),  context.GetBrowserVersion( ),  new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( )) ;
            AV28WebSession.Set("ClientInformationSaved", "Y");
         }
         if ( StringUtil.StrCmp(AV31Httprequest.Method, "GET") == 0 )
         {
            GXt_SdtWWP_DesignSystemSettings3 = AV19WWP_DesignSystemSettings;
            new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings3) ;
            AV19WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings3;
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"base-color",AV19WWP_DesignSystemSettings.gxTpr_Basecolor}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"background-color",AV19WWP_DesignSystemSettings.gxTpr_Backgroundstyle}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"menu-color",AV19WWP_DesignSystemSettings.gxTpr_Menucolor}, false);
            this.executeExternalObjectMethod("", true, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35Configuracoes.gxTpr_Configuracoesimagemheadernome)) )
         {
            AV38Source = "resources/Imagemheader." + AV35Configuracoes.gxTpr_Configuracoesimagemheaderextencao;
            AssignAttri("", true, "AV38Source", AV38Source);
            AV36File.Source = AV38Source;
            if ( AV36File.Exists() )
            {
               AV36File.Delete();
            }
            AV36File.Source = AV38Source;
            AV36File.FromBase64(context.FileToBase64( AV35Configuracoes.gxTpr_Configuracoesimagemheader));
            AV36File.Create();
            AV37IMGURL = StringUtil.Format( "file:///%1", AV36File.GetAbsoluteName(), "", "", "", "", "", "", "", "");
            imgImageheader_Bitmap = AV38Source;
            AssignProp("", true, imgImageheader_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgImageheader_Bitmap)), true);
            AssignProp("", true, imgImageheader_Internalname, "SrcSet", context.GetImageSrcSet( imgImageheader_Bitmap), true);
         }
         Timer_Tickinterval = 5;
         ucTimer.SendProperty(context, "", true, Timer_Internalname, "TickInterval", StringUtil.LTrimStr( (decimal)(Timer_Tickinterval), 9, 0));
      }

      protected void E12632( )
      {
         /* Ddo_bookmarks_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_bookmarks_Activeeventkey, "Bookmark") == 0 )
         {
            /* Execute user subroutine: 'DO BOOKMARK' */
            S112 ();
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

      protected void E15632( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0068",(string)"",AV31Httprequest.BaseURL+AV31Httprequest.ScriptName+(String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV31Httprequest.QueryString))) ? "" : "?"+AV31Httprequest.QueryString),(string)AV13ProgramDescription});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""+""+""+""+""+""+""+""+""+"",(string)"",(string)""+""+""+"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0068"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E14632( )
      {
         /* Bookmark_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E13632( )
      {
         /* Ddc_adminag_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.MpTopActionsClinica")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.mptopactionsclinica", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.MpTopActionsClinica";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.MpTopActionsClinica";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0068",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0068"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'DO BOOKMARK' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", true, "BOOKMARK_MODAL_MPAGEContainer", "Confirm", "", new Object[] {});
      }

      protected void E17632( )
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

      protected void E18632( )
      {
         /* Refresh Routine */
         returnInSub = false;
         lblTextblocktitle_Caption = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption;
         AssignProp("", true, lblTextblocktitle_Internalname, "Caption", lblTextblocktitle_Caption, true);
         GXt_boolean4 = false;
         new GeneXus.Programs.wwpbaseobjects.loadbreadcrumb(context ).execute(  AV26DVelop_Menu,  AV31Httprequest.ScriptName, ref  AV27Breadcrumb, ref  GXt_boolean4) ;
         AssignAttri("", true, "AV27Breadcrumb", AV27Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV27Breadcrumb, "")), context));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV27Breadcrumb))) )
         {
            AV27Breadcrumb = AV28WebSession.Get("LastBreadcrumb");
            AssignAttri("", true, "AV27Breadcrumb", AV27Breadcrumb);
            GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV27Breadcrumb, "")), context));
         }
         else
         {
            AV28WebSession.Set("LastBreadcrumb", AV27Breadcrumb);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27Breadcrumb)) )
         {
            lblSubtitle_Visible = 0;
            AssignProp("", true, lblSubtitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSubtitle_Visible), 5, 0), true);
         }
         else
         {
            lblSubtitle_Visible = 1;
            AssignProp("", true, lblSubtitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblSubtitle_Visible), 5, 0), true);
         }
         lblSubtitle_Caption = (String.IsNullOrEmpty(StringUtil.RTrim( AV27Breadcrumb)) ? StringUtil.Format( "<span class=\"%2\">%1</span>", Contentholder.Pgmdesc, "BreadCrumb", "", "", "", "", "", "", "") : AV27Breadcrumb);
         AssignProp("", true, lblSubtitle_Internalname, "Caption", lblSubtitle_Caption, true);
         /* Execute user subroutine: 'LOADBOOKMARKS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "AV7BookmarksData", AV7BookmarksData);
      }

      protected void E19632( )
      {
         /* General\GlobalEvents_Master_refreshheader Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E20632( )
      {
         /* General\GlobalEvents_Master_changeimage Routine */
         returnInSub = false;
         imgImageheader_Bitmap = AV38Source;
         AssignProp("", true, imgImageheader_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgImageheader_Bitmap)), true);
         AssignProp("", true, imgImageheader_Internalname, "SrcSet", context.GetImageSrcSet( imgImageheader_Bitmap), true);
      }

      protected void S122( )
      {
         /* 'LOADBOOKMARKS' Routine */
         returnInSub = false;
         AV7BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV8BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV8BookmarksDataItem.gxTpr_Eventkey = "AddBookmark";
         AV8BookmarksDataItem.gxTpr_Isdivider = false;
         AV7BookmarksData.Add(AV8BookmarksDataItem, 0);
         AV13ProgramDescription = Contentholder.Pgmdesc;
         AssignAttri("", true, "AV13ProgramDescription", AV13ProgramDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV13ProgramDescription, "")), context));
         AV9CurrentURL = AV31Httprequest.BaseURL + AV31Httprequest.ScriptName + (String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV31Httprequest.QueryString))) ? "" : "?"+AV31Httprequest.QueryString);
         AV10GridStateCollection.FromXml(new GeneXus.Programs.wwpbaseobjects.loadmanagefiltersstate(context).executeUdp(  "AppBookmarks"), null, "Items", "");
         AV6BookmarkFound = false;
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV10GridStateCollection.Count )
         {
            AV11GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV10GridStateCollection.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV11GridStateCollectionItem.gxTpr_Gridstatexml, AV9CurrentURL) == 0 )
            {
               AV13ProgramDescription = AV11GridStateCollectionItem.gxTpr_Title;
               AssignAttri("", true, "AV13ProgramDescription", AV13ProgramDescription);
               GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV13ProgramDescription, "")), context));
               AV6BookmarkFound = true;
               if (true) break;
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
         if ( AV6BookmarkFound )
         {
            this.executeUsercontrolMethod("", true, "DDO_BOOKMARKS_MPAGEContainer", "Update", "", new Object[] {(string)"",(string)"fas fa-star "+"FontColorIconBookmarkTitleAdded"});
            AV8BookmarksDataItem.gxTpr_Title = "Editar favorito para esta página";
            AV8BookmarksDataItem.gxTpr_Fonticon = "fas fa-star "+"FontColorIconBookmarkAdded";
         }
         else
         {
            this.executeUsercontrolMethod("", true, "DDO_BOOKMARKS_MPAGEContainer", "Update", "", new Object[] {(string)"",(string)"far fa-star "+"FontColorIconBookmarkTitle"});
            AV8BookmarksDataItem.gxTpr_Title = "Crie um favorito para esta página";
            AV8BookmarksDataItem.gxTpr_Fonticon = "far fa-star "+"FontColorIconBookmark";
         }
         if ( AV10GridStateCollection.Count > 0 )
         {
            AV8BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV8BookmarksDataItem.gxTpr_Isdivider = true;
            AV7BookmarksData.Add(AV8BookmarksDataItem, 0);
            AV43GXV2 = 1;
            while ( AV43GXV2 <= AV10GridStateCollection.Count )
            {
               AV11GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV10GridStateCollection.Item(AV43GXV2));
               AV8BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
               AV8BookmarksDataItem.gxTpr_Title = AV11GridStateCollectionItem.gxTpr_Title;
               AV8BookmarksDataItem.gxTpr_Link = AV11GridStateCollectionItem.gxTpr_Gridstatexml;
               GXt_char5 = AV14FontIcon;
               new GeneXus.Programs.wwpbaseobjects.getbookmarkfonticon(context ).execute(  StringUtil.StringReplace( AV11GridStateCollectionItem.gxTpr_Gridstatexml, AV31Httprequest.BaseURL, ""),  AV26DVelop_Menu, out  GXt_char5) ;
               AV14FontIcon = GXt_char5;
               AV8BookmarksDataItem.gxTpr_Fonticon = ((StringUtil.StrCmp(AV14FontIcon, "")==0) ? "FontColorIconBookmark fas fa-link" : "FontColorIconBookmark"+" "+AV14FontIcon);
               AV8BookmarksDataItem.gxTpr_Isdivider = false;
               AV7BookmarksData.Add(AV8BookmarksDataItem, 0);
               AV12IndexToAddItems = (short)(AV12IndexToAddItems+1);
               AssignAttri("", true, "AV12IndexToAddItems", StringUtil.LTrimStr( (decimal)(AV12IndexToAddItems), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV12IndexToAddItems), "ZZZ9"), context));
               AV43GXV2 = (int)(AV43GXV2+1);
            }
            AV8BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV8BookmarksDataItem.gxTpr_Isdivider = true;
            AV7BookmarksData.Add(AV8BookmarksDataItem, 0);
            AV8BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV8BookmarksDataItem.gxTpr_Title = "Bookmark manager";
            AV8BookmarksDataItem.gxTpr_Fonticon = "fas fa-cog "+"FontColorIconBookmark";
            AV8BookmarksDataItem.gxTpr_Eventkey = "ManageBookmarks";
            AV8BookmarksDataItem.gxTpr_Isdivider = false;
            AV7BookmarksData.Add(AV8BookmarksDataItem, 0);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E21632( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_62_632( bool wbgen )
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
            wb_table1_62_632e( true) ;
         }
         else
         {
            wb_table1_62_632e( false) ;
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
         PA632( ) ;
         WS632( ) ;
         WE632( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?202561019255099", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/workwithplusmastercli.js", "?20256101925510", false, true);
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
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1_MPAGE";
         Ddo_bookmarks_Internalname = "DDO_BOOKMARKS_MPAGE";
         Ddc_adminag_Internalname = "DDC_ADMINAG_MPAGE";
         divTableuserrole_Internalname = "TABLEUSERROLE_MPAGE";
         divTableheader_Internalname = "TABLEHEADER_MPAGE";
         lblTextblocktitle_Internalname = "TEXTBLOCKTITLE_MPAGE";
         lblSubtitle_Internalname = "SUBTITLE_MPAGE";
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
         lblSubtitle_Caption = "Developer Menu > Person";
         lblSubtitle_Visible = 1;
         lblTextblocktitle_Caption = " Title";
         Ddc_adminag_Caption = "";
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
         Ddc_adminag_Icon = "fas fa-user";
         Ddc_adminag_Icontype = "FontIcon";
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
         setEventMetadata("REFRESH_MPAGE","""{"handler":"Refresh","iparms":[{"ctrl":"FORM_MPAGE","prop":"Caption"},{"av":"AV26DVelop_Menu","fld":"vDVELOP_MENU_MPAGE","type":""},{"av":"AV31Httprequest.BaseURL","ctrl":"vHTTPREQUEST_MPAGE","prop":"Baseurl"},{"av":"AV13ProgramDescription","fld":"vPROGRAMDESCRIPTION_MPAGE","hsh":true,"type":"svchar"},{"av":"AV18SearchAux","fld":"vSEARCHAUX_MPAGE","hsh":true,"type":"svchar"},{"av":"AV27Breadcrumb","fld":"vBREADCRUMB_MPAGE","hsh":true,"type":"svchar"},{"av":"AV12IndexToAddItems","fld":"vINDEXTOADDITEMS_MPAGE","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH_MPAGE",""","oparms":[{"av":"lblTextblocktitle_Caption","ctrl":"TEXTBLOCKTITLE_MPAGE","prop":"Caption"},{"av":"AV27Breadcrumb","fld":"vBREADCRUMB_MPAGE","hsh":true,"type":"svchar"},{"av":"lblSubtitle_Visible","ctrl":"SUBTITLE_MPAGE","prop":"Visible"},{"av":"lblSubtitle_Caption","ctrl":"SUBTITLE_MPAGE","prop":"Caption"},{"av":"AV7BookmarksData","fld":"vBOOKMARKSDATA_MPAGE","type":""},{"av":"AV13ProgramDescription","fld":"vPROGRAMDESCRIPTION_MPAGE","hsh":true,"type":"svchar"},{"av":"AV12IndexToAddItems","fld":"vINDEXTOADDITEMS_MPAGE","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("DDO_BOOKMARKS_MPAGE.ONOPTIONCLICKED_MPAGE","""{"handler":"E12632","iparms":[{"av":"Ddo_bookmarks_Activeeventkey","ctrl":"DDO_BOOKMARKS_MPAGE","prop":"ActiveEventKey"}]}""");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE","""{"handler":"E15632","iparms":[{"av":"AV31Httprequest.BaseURL","ctrl":"vHTTPREQUEST_MPAGE","prop":"Baseurl"},{"av":"AV13ProgramDescription","fld":"vPROGRAMDESCRIPTION_MPAGE","hsh":true,"type":"svchar"}]""");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE",""","oparms":[{"ctrl":"WWPAUX_WC_MPAGE"}]}""");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE","""{"handler":"E14632","iparms":[]}""");
         setEventMetadata("DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE","""{"handler":"E13632","iparms":[]""");
         setEventMetadata("DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE",""","oparms":[{"ctrl":"WWPAUX_WC_MPAGE"}]}""");
         setEventMetadata("DOSHOWMENU_MPAGE","""{"handler":"E11631","iparms":[]}""");
         setEventMetadata("DOACTIONSEARCH_MPAGE","""{"handler":"E17632","iparms":[{"av":"AV18SearchAux","fld":"vSEARCHAUX_MPAGE","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE","""{"handler":"E19632","iparms":[]}""");
         setEventMetadata("GLOBALEVENTS_MPAGE.MASTER_CHANGEIMAGE_MPAGE","""{"handler":"E20632","iparms":[{"av":"AV38Source","fld":"vSOURCE_MPAGE","type":"svchar"}]}""");
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
         AV31Httprequest = new GxHttpRequest( context);
         AV13ProgramDescription = "";
         AV18SearchAux = "";
         AV27Breadcrumb = "";
         GXKey = "";
         AV7BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV26DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         AV5DVelop_Menu_UserData = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_UserData(context);
         AV38Source = "";
         AV15NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         sPrefix = "";
         ClassString = "";
         imgImageheader_gximage = "";
         StyleString = "";
         sImgUrl = "";
         lblShowmenu_Jsonclick = "";
         ucDdo_bookmarks = new GXUserControl();
         Ddo_bookmarks_Caption = "";
         ucDdc_adminag = new GXUserControl();
         lblTextblocktitle_Jsonclick = "";
         lblSubtitle_Jsonclick = "";
         ucUcmenu = new GXUserControl();
         ucUcmessage = new GXUserControl();
         ucUctooltip = new GXUserControl();
         ucWwputilities = new GXUserControl();
         ucWwpdatepicker = new GXUserControl();
         ucTimer = new GXUserControl();
         TempTags = "";
         AV32PickerDummyVariable = DateTime.MinValue;
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GX_FocusControl = "";
         AV39WWpContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H00632_A299ConfiguracoesId = new int[1] ;
         AV35Configuracoes = new SdtConfiguracoes(context);
         GXt_objcol_SdtDVelop_Menu_Item2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         AV8BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV28WebSession = context.GetSession();
         AV19WWP_DesignSystemSettings = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         GXt_SdtWWP_DesignSystemSettings3 = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         AV36File = new GxFile(context.GetPhysicalPath());
         AV37IMGURL = "";
         GXEncryptionTmp = "";
         AV9CurrentURL = "";
         AV10GridStateCollection = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item>( context, "Item", "");
         AV11GridStateCollectionItem = new GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item(context);
         AV14FontIcon = "";
         GXt_char5 = "";
         sStyleString = "";
         ucBookmark_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.workwithplusmastercli__default(),
            new Object[][] {
                new Object[] {
               H00632_A299ConfiguracoesId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short GxWebError ;
      private short AV12IndexToAddItems ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int Ddc_adminag_Componentwidth ;
      private int Ucmenu_Searchminchars ;
      private int Ucmenu_Scrollwidth ;
      private int Ucmessage_Animationspeed ;
      private int Timer_Tickinterval ;
      private int lblSubtitle_Visible ;
      private int A299ConfiguracoesId ;
      private int AV42GXV1 ;
      private int AV43GXV2 ;
      private int idxLst ;
      private string Ddo_bookmarks_Activeeventkey ;
      private string GXKey ;
      private string Ddo_bookmarks_Icontype ;
      private string Ddo_bookmarks_Icon ;
      private string Ddo_bookmarks_Tooltip ;
      private string Ddo_bookmarks_Cls ;
      private string Ddo_bookmarks_Titlecontrolalign ;
      private string Ddc_adminag_Icontype ;
      private string Ddc_adminag_Icon ;
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
      private string divTableuserrole_Internalname ;
      private string Ddo_bookmarks_Caption ;
      private string Ddo_bookmarks_Internalname ;
      private string Ddc_adminag_Caption ;
      private string Ddc_adminag_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTabletitle_Internalname ;
      private string lblTextblocktitle_Internalname ;
      private string lblTextblocktitle_Caption ;
      private string lblTextblocktitle_Jsonclick ;
      private string lblSubtitle_Internalname ;
      private string lblSubtitle_Caption ;
      private string lblSubtitle_Jsonclick ;
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
      private DateTime AV32PickerDummyVariable ;
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
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean4 ;
      private bool AV6BookmarkFound ;
      private string AV13ProgramDescription ;
      private string AV18SearchAux ;
      private string AV27Breadcrumb ;
      private string AV38Source ;
      private string AV37IMGURL ;
      private string AV9CurrentURL ;
      private string AV14FontIcon ;
      private string imgImageheader_Bitmap ;
      private IGxSession AV28WebSession ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDdo_bookmarks ;
      private GXUserControl ucDdc_adminag ;
      private GXUserControl ucUcmenu ;
      private GXUserControl ucUcmessage ;
      private GXUserControl ucUctooltip ;
      private GXUserControl ucWwputilities ;
      private GXUserControl ucWwpdatepicker ;
      private GXUserControl ucTimer ;
      private GXUserControl ucBookmark_modal ;
      private GxHttpRequest AV31Httprequest ;
      private GxFile AV36File ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contentholder ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV7BookmarksData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV26DVelop_Menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_UserData AV5DVelop_Menu_UserData ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV15NotificationInfo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV39WWpContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private int[] H00632_A299ConfiguracoesId ;
      private SdtConfiguracoes AV35Configuracoes ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV8BookmarksDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings AV19WWP_DesignSystemSettings ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings GXt_SdtWWP_DesignSystemSettings3 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item> AV10GridStateCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item AV11GridStateCollectionItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class workwithplusmastercli__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00632;
          prmH00632 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00632", "SELECT ConfiguracoesId FROM Configuracoes ORDER BY ConfiguracoesId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00632,100, GxCacheFrequency.OFF ,true,false )
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
       }
    }

 }

}
