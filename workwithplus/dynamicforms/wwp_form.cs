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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_form : GXWebComponent
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
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
               Gx_mode = GetPar( "Mode");
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               AV7WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV7WWPFormId", StringUtil.LTrimStr( (decimal)(AV7WWPFormId), 4, 0));
               AV8WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV8WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV8WWPFormVersionNumber), 4, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(short)AV7WWPFormId,(short)AV8WWPFormVersionNumber});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel1"+"_"+"WWPFORMLATESTVERSIONNUMBER") == 0 )
            {
               A94WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GX1ASAWWPFORMLATESTVERSIONNUMBER0C13( A94WWPFormId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
            {
               A94WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
               A95WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
               A99WWPFormElementParentId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementParentId"), "."), 18, MidpointRounding.ToEven));
               n99WWPFormElementParentId = false;
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_16( A94WWPFormId, A95WWPFormVersionNumber, A99WWPFormElementParentId) ;
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
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_element") == 0 )
            {
               gxnrGridlevel_element_newrow_invoke( ) ;
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_form")), "workwithplus.dynamicforms.wwp_form") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_form")))) ;
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
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "Mode");
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
               }
            }
            Form.Meta.addItem("description", "WWPForm", 0) ;
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
            if ( nDynComponent == 0 )
            {
               context.HttpContext.Response.StatusCode = 404;
               GXUtil.WriteLog("send_http_error_code " + 404.ToString());
               GxWebError = 1;
            }
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGridlevel_element_newrow_invoke( )
      {
         nRC_GXsfl_53 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_53"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_53_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_53_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_53_idx = GetPar( "sGXsfl_53_idx");
         sPrefix = GetPar( "sPrefix");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_element_newrow( ) ;
         /* End function gxnrGridlevel_element_newrow_invoke */
      }

      public wwp_form( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wwp_form( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_WWPFormId ,
                           short aP2_WWPFormVersionNumber )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7WWPFormId = aP1_WWPFormId;
         this.AV8WWPFormVersionNumber = aP2_WWPFormVersionNumber;
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
         chkWWPFormIsWizard = new GXCheckbox();
         cmbWWPFormElementType = new GXCombobox();
         cmbWWPFormElementDataType = new GXCombobox();
         cmbWWPFormElementParentType = new GXCombobox();
         cmbWWPFormElementCaption = new GXCombobox();
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
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

      protected void fix_multi_value_controls( )
      {
         A120WWPFormIsWizard = StringUtil.StrToBool( StringUtil.BoolToStr( A120WWPFormIsWizard));
         AssignAttri(sPrefix, false, "A120WWPFormIsWizard", A120WWPFormIsWizard);
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
            RenderHtmlCloseForm0C13( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            RenderHtmlHeaders( ) ;
         }
         RenderHtmlOpenForm( ) ;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_form");
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, sPrefix+"DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormId_Internalname, "Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A94WWPFormId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A94WWPFormId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWWPFormId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormVersionNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormVersionNumber_Internalname, "Form Version #", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormVersionNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A95WWPFormVersionNumber), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A95WWPFormVersionNumber), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,27);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormVersionNumber_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWWPFormVersionNumber_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormDate_Internalname, "Date", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A119WWPFormDate", context.localUtil.TToC( A119WWPFormDate, 8, 5, 0, 3, "/", ":", " "));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPFormDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPFormDate_Internalname, context.localUtil.TToC( A119WWPFormDate, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A119WWPFormDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormDate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWWPFormDate_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
         GxWebStd.gx_bitmap( context, edtWWPFormDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPFormDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPFormIsWizard_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPFormIsWizard_Internalname, "Is Wizard", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A120WWPFormIsWizard", A120WWPFormIsWizard);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPFormIsWizard_Internalname, StringUtil.BoolToStr( A120WWPFormIsWizard), "", "Is Wizard", 1, chkWWPFormIsWizard.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(37, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,37);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormReferenceName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormReferenceName_Internalname, "Reference Name", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A96WWPFormReferenceName", A96WWPFormReferenceName);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormReferenceName_Internalname, A96WWPFormReferenceName, StringUtil.RTrim( context.localUtil.Format( A96WWPFormReferenceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormReferenceName_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWWPFormReferenceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormTitle_Internalname, "Title", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormTitle_Internalname, A97WWPFormTitle, StringUtil.RTrim( context.localUtil.Format( A97WWPFormTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormTitle_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWWPFormTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_element_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "start", "top", "", "", "div");
         gxdraw_Gridlevel_element( ) ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_Form.htm");
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

      protected void gxdraw_Gridlevel_element( )
      {
         /*  Grid Control  */
         StartGridControl53( ) ;
         nGXsfl_53_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount14 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_14 = 1;
               ScanStart0C14( ) ;
               while ( RcdFound14 != 0 )
               {
                  init_level_properties14( ) ;
                  getByPrimaryKey0C14( ) ;
                  AddRow0C14( ) ;
                  ScanNext0C14( ) ;
               }
               ScanEnd0C14( ) ;
               nBlankRcdCount14 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0C14( ) ;
            standaloneModal0C14( ) ;
            sMode14 = Gx_mode;
            while ( nGXsfl_53_idx < nRC_GXsfl_53 )
            {
               bGXsfl_53_Refreshing = true;
               ReadRow0C14( ) ;
               edtWWPFormElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtWWPFormElementTitle_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtWWPFormElementReferenceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementReferenceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               cmbWWPFormElementType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, cmbWWPFormElementType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementType.Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtWWPFormElementOrderIndex_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementOrderIndex_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               cmbWWPFormElementDataType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtWWPFormElementParentId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementParentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtWWPFormElementParentName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementParentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               cmbWWPFormElementParentType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, cmbWWPFormElementParentType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtWWPFormElementMetadata_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               cmbWWPFormElementCaption.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, cmbWWPFormElementCaption_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0), !bGXsfl_53_Refreshing);
               if ( ( nRcdExists_14 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  standaloneModal0C14( ) ;
               }
               SendRow0C14( ) ;
               bGXsfl_53_Refreshing = false;
            }
            Gx_mode = sMode14;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount14 = 5;
            nRcdExists_14 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0C14( ) ;
               while ( RcdFound14 != 0 )
               {
                  sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5314( ) ;
                  init_level_properties14( ) ;
                  standaloneNotModal0C14( ) ;
                  getByPrimaryKey0C14( ) ;
                  standaloneModal0C14( ) ;
                  AddRow0C14( ) ;
                  ScanNext0C14( ) ;
               }
               ScanEnd0C14( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode14 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
            SubsflControlProps_5314( ) ;
            InitAll0C14( ) ;
            init_level_properties14( ) ;
            nRcdExists_14 = 0;
            nIsMod_14 = 0;
            nRcdDeleted_14 = 0;
            nBlankRcdCount14 = (short)(nBlankRcdUsr14+nBlankRcdCount14);
            fRowAdded = 0;
            while ( nBlankRcdCount14 > 0 )
            {
               standaloneNotModal0C14( ) ;
               standaloneModal0C14( ) ;
               AddRow0C14( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtWWPFormElementId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount14 = (short)(nBlankRcdCount14-1);
            }
            Gx_mode = sMode14;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+sPrefix+"Gridlevel_elementContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridlevel_element", Gridlevel_elementContainer, subGridlevel_element_Internalname);
         if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gridlevel_elementContainerData", Gridlevel_elementContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gridlevel_elementContainerData"+"V", Gridlevel_elementContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridlevel_elementContainerData"+"V"+"\" value='"+Gridlevel_elementContainer.GridValuesHidden()+"'/>") ;
         }
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
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               standaloneStartupServer( ) ;
            }
         }
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110C2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         nDoneStart = 1;
         if ( AnyError == 0 )
         {
            sXEvt = cgiGet( "_EventName");
            if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z94WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z94WWPFormId"), ",", "."), 18, MidpointRounding.ToEven));
               Z95WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z95WWPFormVersionNumber"), ",", "."), 18, MidpointRounding.ToEven));
               Z96WWPFormReferenceName = cgiGet( sPrefix+"Z96WWPFormReferenceName");
               Z97WWPFormTitle = cgiGet( sPrefix+"Z97WWPFormTitle");
               Z119WWPFormDate = context.localUtil.CToT( cgiGet( sPrefix+"Z119WWPFormDate"), 0);
               Z120WWPFormIsWizard = StringUtil.StrToBool( cgiGet( sPrefix+"Z120WWPFormIsWizard"));
               Z104WWPFormResume = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z104WWPFormResume"), ",", "."), 18, MidpointRounding.ToEven));
               Z122WWPFormInstantiated = StringUtil.StrToBool( cgiGet( sPrefix+"Z122WWPFormInstantiated"));
               Z290WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z290WWPFormType"), ",", "."), 18, MidpointRounding.ToEven));
               Z291WWPFormSectionRefElements = cgiGet( sPrefix+"Z291WWPFormSectionRefElements");
               Z292WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sPrefix+"Z292WWPFormIsForDynamicValidations"));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPFormId"), ",", "."), 18, MidpointRounding.ToEven));
               wcpOAV8WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8WWPFormVersionNumber"), ",", "."), 18, MidpointRounding.ToEven));
               A104WWPFormResume = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z104WWPFormResume"), ",", "."), 18, MidpointRounding.ToEven));
               A122WWPFormInstantiated = StringUtil.StrToBool( cgiGet( sPrefix+"Z122WWPFormInstantiated"));
               A290WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z290WWPFormType"), ",", "."), 18, MidpointRounding.ToEven));
               A291WWPFormSectionRefElements = cgiGet( sPrefix+"Z291WWPFormSectionRefElements");
               A292WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sPrefix+"Z292WWPFormIsForDynamicValidations"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( sPrefix+"Mode");
               nRC_GXsfl_53 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_53"), ",", "."), 18, MidpointRounding.ToEven));
               A107WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMLATESTVERSIONNUMBER"), ",", "."), 18, MidpointRounding.ToEven));
               AV7WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vWWPFORMID"), ",", "."), 18, MidpointRounding.ToEven));
               AV8WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vWWPFORMVERSIONNUMBER"), ",", "."), 18, MidpointRounding.ToEven));
               A104WWPFormResume = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMRESUME"), ",", "."), 18, MidpointRounding.ToEven));
               A123WWPFormResumeMessage = cgiGet( sPrefix+"WWPFORMRESUMEMESSAGE");
               A121WWPFormValidations = cgiGet( sPrefix+"WWPFORMVALIDATIONS");
               A122WWPFormInstantiated = StringUtil.StrToBool( cgiGet( sPrefix+"WWPFORMINSTANTIATED"));
               A290WWPFormType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMTYPE"), ",", "."), 18, MidpointRounding.ToEven));
               A291WWPFormSectionRefElements = cgiGet( sPrefix+"WWPFORMSECTIONREFELEMENTS");
               A292WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( sPrefix+"WWPFORMISFORDYNAMICVALIDATIONS"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A126WWPFormElementExcludeFromExport = StringUtil.StrToBool( cgiGet( sPrefix+"WWPFORMELEMENTEXCLUDEFROMEXPORT"));
               Dvpanel_tableattributes_Objectcall = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Titletype = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Titletype");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPFORMID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A94WWPFormId = 0;
                  AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
               }
               else
               {
                  A94WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPFORMVERSIONNUMBER");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormVersionNumber_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A95WWPFormVersionNumber = 0;
                  AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
               }
               else
               {
                  A95WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtWWPFormDate_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"WWPForm Date"}), 1, "WWPFORMDATE");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormDate_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A119WWPFormDate = (DateTime)(DateTime.MinValue);
                  AssignAttri(sPrefix, false, "A119WWPFormDate", context.localUtil.TToC( A119WWPFormDate, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A119WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname));
                  AssignAttri(sPrefix, false, "A119WWPFormDate", context.localUtil.TToC( A119WWPFormDate, 8, 5, 0, 3, "/", ":", " "));
               }
               A120WWPFormIsWizard = StringUtil.StrToBool( cgiGet( chkWWPFormIsWizard_Internalname));
               AssignAttri(sPrefix, false, "A120WWPFormIsWizard", A120WWPFormIsWizard);
               A96WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
               AssignAttri(sPrefix, false, "A96WWPFormReferenceName", A96WWPFormReferenceName);
               A97WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
               AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WWP_Form");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("WWPFormResume", context.localUtil.Format( (decimal)(A104WWPFormResume), "9"));
               forbiddenHiddens.Add("WWPFormInstantiated", StringUtil.BoolToStr( A122WWPFormInstantiated));
               forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A290WWPFormType), "9"));
               forbiddenHiddens.Add("WWPFormSectionRefElements", StringUtil.RTrim( context.localUtil.Format( A291WWPFormSectionRefElements, "")));
               forbiddenHiddens.Add("WWPFormIsForDynamicValidations", StringUtil.BoolToStr( A292WWPFormIsForDynamicValidations));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A94WWPFormId != Z94WWPFormId ) || ( A95WWPFormVersionNumber != Z95WWPFormVersionNumber ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("workwithplus\\dynamicforms\\wwp_form:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  A94WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
                  A95WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode13 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode13;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound13 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "WWPFORMID");
                        AnyError = 1;
                        GX_FocusControl = edtWWPFormId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E110C2 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: After Trn */
                                 E120C2 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 if ( ! IsDsp( ) )
                                 {
                                    btn_enter( ) ;
                                 }
                              }
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            /* Execute user event: After Trn */
            E120C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0C13( ) ;
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
         bttBtntrn_delete_Visible = 0;
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0C13( ) ;
         }
         AssignProp(sPrefix, false, edtWWPFormDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormDate_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkWWPFormIsWizard_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormIsWizard.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtWWPFormReferenceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormReferenceName_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtWWPFormTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C13( ) ;
            }
            else
            {
               CheckExtendedTable0C13( ) ;
               CloseExtendedTableCursors0C13( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode13 = Gx_mode;
            CONFIRM_0C14( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode13;
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode13;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0C14( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow0C14( ) ;
            if ( ( nRcdExists_14 != 0 ) || ( nIsMod_14 != 0 ) )
            {
               GetKey0C14( ) ;
               if ( ( nRcdExists_14 == 0 ) && ( nRcdDeleted_14 == 0 ) )
               {
                  if ( RcdFound14 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     BeforeValidate0C14( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0C14( ) ;
                        CloseExtendedTableCursors0C14( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_53_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtWWPFormElementId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound14 != 0 )
                  {
                     if ( nRcdDeleted_14 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0C14( ) ;
                        Load0C14( ) ;
                        BeforeValidate0C14( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0C14( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_14 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                           BeforeValidate0C14( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0C14( ) ;
                              CloseExtendedTableCursors0C14( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_14 == 0 )
                     {
                        GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPFormElementId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( sPrefix+edtWWPFormElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A98WWPFormElementId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementTitle_Internalname, A117WWPFormElementTitle) ;
            ChangePostValue( sPrefix+edtWWPFormElementReferenceId_Internalname, A101WWPFormElementReferenceId) ;
            ChangePostValue( sPrefix+cmbWWPFormElementType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A105WWPFormElementType), 1, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementOrderIndex_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A100WWPFormElementOrderIndex), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+cmbWWPFormElementDataType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106WWPFormElementDataType), 2, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementParentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A99WWPFormElementParentId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementParentName_Internalname, A116WWPFormElementParentName) ;
            ChangePostValue( sPrefix+cmbWWPFormElementParentType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WWPFormElementParentType), 1, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementMetadata_Internalname, A124WWPFormElementMetadata) ;
            ChangePostValue( sPrefix+cmbWWPFormElementCaption_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPFormElementCaption), 1, 0, ".", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z98WWPFormElementId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98WWPFormElementId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z125WWPFormElementCaption_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125WWPFormElementCaption), 1, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z105WWPFormElementType_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z105WWPFormElementType), 1, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z100WWPFormElementOrderIndex_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z100WWPFormElementOrderIndex), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z106WWPFormElementDataType_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106WWPFormElementDataType), 2, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z101WWPFormElementReferenceId_"+sGXsfl_53_idx, Z101WWPFormElementReferenceId) ;
            ChangePostValue( sPrefix+"ZT_"+"Z126WWPFormElementExcludeFromExport_"+sGXsfl_53_idx, StringUtil.BoolToStr( Z126WWPFormElementExcludeFromExport)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z99WWPFormElementParentId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z99WWPFormElementParentId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nRcdDeleted_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nRcdExists_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nIsMod_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, ",", ""))) ;
            if ( nIsMod_14 != 0 )
            {
               ChangePostValue( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0C0( )
      {
      }

      protected void E110C2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0C13( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z96WWPFormReferenceName = T000C6_A96WWPFormReferenceName[0];
               Z97WWPFormTitle = T000C6_A97WWPFormTitle[0];
               Z119WWPFormDate = T000C6_A119WWPFormDate[0];
               Z120WWPFormIsWizard = T000C6_A120WWPFormIsWizard[0];
               Z104WWPFormResume = T000C6_A104WWPFormResume[0];
               Z122WWPFormInstantiated = T000C6_A122WWPFormInstantiated[0];
               Z290WWPFormType = T000C6_A290WWPFormType[0];
               Z291WWPFormSectionRefElements = T000C6_A291WWPFormSectionRefElements[0];
               Z292WWPFormIsForDynamicValidations = T000C6_A292WWPFormIsForDynamicValidations[0];
            }
            else
            {
               Z96WWPFormReferenceName = A96WWPFormReferenceName;
               Z97WWPFormTitle = A97WWPFormTitle;
               Z119WWPFormDate = A119WWPFormDate;
               Z120WWPFormIsWizard = A120WWPFormIsWizard;
               Z104WWPFormResume = A104WWPFormResume;
               Z122WWPFormInstantiated = A122WWPFormInstantiated;
               Z290WWPFormType = A290WWPFormType;
               Z291WWPFormSectionRefElements = A291WWPFormSectionRefElements;
               Z292WWPFormIsForDynamicValidations = A292WWPFormIsForDynamicValidations;
            }
         }
         if ( GX_JID == -14 )
         {
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            Z96WWPFormReferenceName = A96WWPFormReferenceName;
            Z97WWPFormTitle = A97WWPFormTitle;
            Z119WWPFormDate = A119WWPFormDate;
            Z120WWPFormIsWizard = A120WWPFormIsWizard;
            Z104WWPFormResume = A104WWPFormResume;
            Z123WWPFormResumeMessage = A123WWPFormResumeMessage;
            Z121WWPFormValidations = A121WWPFormValidations;
            Z122WWPFormInstantiated = A122WWPFormInstantiated;
            Z290WWPFormType = A290WWPFormType;
            Z291WWPFormSectionRefElements = A291WWPFormSectionRefElements;
            Z292WWPFormIsForDynamicValidations = A292WWPFormIsForDynamicValidations;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7WWPFormId) )
         {
            A94WWPFormId = AV7WWPFormId;
            AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
         }
         if ( ! (0==AV7WWPFormId) )
         {
            edtWWPFormId_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         }
         else
         {
            edtWWPFormId_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7WWPFormId) )
         {
            edtWWPFormId_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8WWPFormVersionNumber) )
         {
            A95WWPFormVersionNumber = AV8WWPFormVersionNumber;
            AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
         }
         if ( ! (0==AV8WWPFormVersionNumber) )
         {
            edtWWPFormVersionNumber_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         }
         else
         {
            edtWWPFormVersionNumber_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8WWPFormVersionNumber) )
         {
            edtWWPFormVersionNumber_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp(sPrefix, false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            GXt_int1 = A107WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
            A107WWPFormLatestVersionNumber = GXt_int1;
            AssignAttri(sPrefix, false, "A107WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A107WWPFormLatestVersionNumber), 4, 0));
         }
      }

      protected void Load0C13( )
      {
         /* Using cursor T000C7 */
         pr_default.execute(5, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound13 = 1;
            A96WWPFormReferenceName = T000C7_A96WWPFormReferenceName[0];
            AssignAttri(sPrefix, false, "A96WWPFormReferenceName", A96WWPFormReferenceName);
            A97WWPFormTitle = T000C7_A97WWPFormTitle[0];
            AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
            A119WWPFormDate = T000C7_A119WWPFormDate[0];
            AssignAttri(sPrefix, false, "A119WWPFormDate", context.localUtil.TToC( A119WWPFormDate, 8, 5, 0, 3, "/", ":", " "));
            A120WWPFormIsWizard = T000C7_A120WWPFormIsWizard[0];
            AssignAttri(sPrefix, false, "A120WWPFormIsWizard", A120WWPFormIsWizard);
            A104WWPFormResume = T000C7_A104WWPFormResume[0];
            A123WWPFormResumeMessage = T000C7_A123WWPFormResumeMessage[0];
            A121WWPFormValidations = T000C7_A121WWPFormValidations[0];
            A122WWPFormInstantiated = T000C7_A122WWPFormInstantiated[0];
            A290WWPFormType = T000C7_A290WWPFormType[0];
            A291WWPFormSectionRefElements = T000C7_A291WWPFormSectionRefElements[0];
            A292WWPFormIsForDynamicValidations = T000C7_A292WWPFormIsForDynamicValidations[0];
            ZM0C13( -14) ;
         }
         pr_default.close(5);
         OnLoadActions0C13( ) ;
      }

      protected void OnLoadActions0C13( )
      {
         GXt_int1 = A107WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
         A107WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri(sPrefix, false, "A107WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A107WWPFormLatestVersionNumber), 4, 0));
      }

      protected void CheckExtendedTable0C13( )
      {
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         GXt_int1 = A107WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
         A107WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri(sPrefix, false, "A107WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A107WWPFormLatestVersionNumber), 4, 0));
         if ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  A94WWPFormId,  A96WWPFormReferenceName) )
         {
            GX_msglist.addItem("O nome de referência deve ser único.", 1, "WWPFORMID");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0C13( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C13( )
      {
         /* Using cursor T000C8 */
         pr_default.execute(6, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C6 */
         pr_default.execute(4, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0C13( 14) ;
            RcdFound13 = 1;
            A94WWPFormId = T000C6_A94WWPFormId[0];
            AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
            A95WWPFormVersionNumber = T000C6_A95WWPFormVersionNumber[0];
            AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
            A96WWPFormReferenceName = T000C6_A96WWPFormReferenceName[0];
            AssignAttri(sPrefix, false, "A96WWPFormReferenceName", A96WWPFormReferenceName);
            A97WWPFormTitle = T000C6_A97WWPFormTitle[0];
            AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
            A119WWPFormDate = T000C6_A119WWPFormDate[0];
            AssignAttri(sPrefix, false, "A119WWPFormDate", context.localUtil.TToC( A119WWPFormDate, 8, 5, 0, 3, "/", ":", " "));
            A120WWPFormIsWizard = T000C6_A120WWPFormIsWizard[0];
            AssignAttri(sPrefix, false, "A120WWPFormIsWizard", A120WWPFormIsWizard);
            A104WWPFormResume = T000C6_A104WWPFormResume[0];
            A123WWPFormResumeMessage = T000C6_A123WWPFormResumeMessage[0];
            A121WWPFormValidations = T000C6_A121WWPFormValidations[0];
            A122WWPFormInstantiated = T000C6_A122WWPFormInstantiated[0];
            A290WWPFormType = T000C6_A290WWPFormType[0];
            A291WWPFormSectionRefElements = T000C6_A291WWPFormSectionRefElements[0];
            A292WWPFormIsForDynamicValidations = T000C6_A292WWPFormIsForDynamicValidations[0];
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0C13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0C13( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0C13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C13( ) ;
         if ( RcdFound13 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound13 = 0;
         /* Using cursor T000C9 */
         pr_default.execute(7, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000C9_A94WWPFormId[0] < A94WWPFormId ) || ( T000C9_A94WWPFormId[0] == A94WWPFormId ) && ( T000C9_A95WWPFormVersionNumber[0] < A95WWPFormVersionNumber ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000C9_A94WWPFormId[0] > A94WWPFormId ) || ( T000C9_A94WWPFormId[0] == A94WWPFormId ) && ( T000C9_A95WWPFormVersionNumber[0] > A95WWPFormVersionNumber ) ) )
            {
               A94WWPFormId = T000C9_A94WWPFormId[0];
               AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
               A95WWPFormVersionNumber = T000C9_A95WWPFormVersionNumber[0];
               AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000C10 */
         pr_default.execute(8, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000C10_A94WWPFormId[0] > A94WWPFormId ) || ( T000C10_A94WWPFormId[0] == A94WWPFormId ) && ( T000C10_A95WWPFormVersionNumber[0] > A95WWPFormVersionNumber ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000C10_A94WWPFormId[0] < A94WWPFormId ) || ( T000C10_A94WWPFormId[0] == A94WWPFormId ) && ( T000C10_A95WWPFormVersionNumber[0] < A95WWPFormVersionNumber ) ) )
            {
               A94WWPFormId = T000C10_A94WWPFormId[0];
               AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
               A95WWPFormVersionNumber = T000C10_A95WWPFormVersionNumber[0];
               AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0C13( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( ( A94WWPFormId != Z94WWPFormId ) || ( A95WWPFormVersionNumber != Z95WWPFormVersionNumber ) )
               {
                  A94WWPFormId = Z94WWPFormId;
                  AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
                  A95WWPFormVersionNumber = Z95WWPFormVersionNumber;
                  AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPFORMID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0C13( ) ;
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A94WWPFormId != Z94WWPFormId ) || ( A95WWPFormVersionNumber != Z95WWPFormVersionNumber ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtWWPFormId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0C13( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPFORMID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPFormId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtWWPFormId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0C13( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( ( A94WWPFormId != Z94WWPFormId ) || ( A95WWPFormVersionNumber != Z95WWPFormVersionNumber ) )
         {
            A94WWPFormId = Z94WWPFormId;
            AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
            A95WWPFormVersionNumber = Z95WWPFormVersionNumber;
            AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPFORMID");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0C13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C5 */
            pr_default.execute(3, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Form"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z96WWPFormReferenceName, T000C5_A96WWPFormReferenceName[0]) != 0 ) || ( StringUtil.StrCmp(Z97WWPFormTitle, T000C5_A97WWPFormTitle[0]) != 0 ) || ( Z119WWPFormDate != T000C5_A119WWPFormDate[0] ) || ( Z120WWPFormIsWizard != T000C5_A120WWPFormIsWizard[0] ) || ( Z104WWPFormResume != T000C5_A104WWPFormResume[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z122WWPFormInstantiated != T000C5_A122WWPFormInstantiated[0] ) || ( Z290WWPFormType != T000C5_A290WWPFormType[0] ) || ( StringUtil.StrCmp(Z291WWPFormSectionRefElements, T000C5_A291WWPFormSectionRefElements[0]) != 0 ) || ( Z292WWPFormIsForDynamicValidations != T000C5_A292WWPFormIsForDynamicValidations[0] ) )
            {
               if ( StringUtil.StrCmp(Z96WWPFormReferenceName, T000C5_A96WWPFormReferenceName[0]) != 0 )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormReferenceName");
                  GXUtil.WriteLogRaw("Old: ",Z96WWPFormReferenceName);
                  GXUtil.WriteLogRaw("Current: ",T000C5_A96WWPFormReferenceName[0]);
               }
               if ( StringUtil.StrCmp(Z97WWPFormTitle, T000C5_A97WWPFormTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormTitle");
                  GXUtil.WriteLogRaw("Old: ",Z97WWPFormTitle);
                  GXUtil.WriteLogRaw("Current: ",T000C5_A97WWPFormTitle[0]);
               }
               if ( Z119WWPFormDate != T000C5_A119WWPFormDate[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormDate");
                  GXUtil.WriteLogRaw("Old: ",Z119WWPFormDate);
                  GXUtil.WriteLogRaw("Current: ",T000C5_A119WWPFormDate[0]);
               }
               if ( Z120WWPFormIsWizard != T000C5_A120WWPFormIsWizard[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormIsWizard");
                  GXUtil.WriteLogRaw("Old: ",Z120WWPFormIsWizard);
                  GXUtil.WriteLogRaw("Current: ",T000C5_A120WWPFormIsWizard[0]);
               }
               if ( Z104WWPFormResume != T000C5_A104WWPFormResume[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormResume");
                  GXUtil.WriteLogRaw("Old: ",Z104WWPFormResume);
                  GXUtil.WriteLogRaw("Current: ",T000C5_A104WWPFormResume[0]);
               }
               if ( Z122WWPFormInstantiated != T000C5_A122WWPFormInstantiated[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormInstantiated");
                  GXUtil.WriteLogRaw("Old: ",Z122WWPFormInstantiated);
                  GXUtil.WriteLogRaw("Current: ",T000C5_A122WWPFormInstantiated[0]);
               }
               if ( Z290WWPFormType != T000C5_A290WWPFormType[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormType");
                  GXUtil.WriteLogRaw("Old: ",Z290WWPFormType);
                  GXUtil.WriteLogRaw("Current: ",T000C5_A290WWPFormType[0]);
               }
               if ( StringUtil.StrCmp(Z291WWPFormSectionRefElements, T000C5_A291WWPFormSectionRefElements[0]) != 0 )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormSectionRefElements");
                  GXUtil.WriteLogRaw("Old: ",Z291WWPFormSectionRefElements);
                  GXUtil.WriteLogRaw("Current: ",T000C5_A291WWPFormSectionRefElements[0]);
               }
               if ( Z292WWPFormIsForDynamicValidations != T000C5_A292WWPFormIsForDynamicValidations[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormIsForDynamicValidations");
                  GXUtil.WriteLogRaw("Old: ",Z292WWPFormIsForDynamicValidations);
                  GXUtil.WriteLogRaw("Current: ",T000C5_A292WWPFormIsForDynamicValidations[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Form"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C13( 0) ;
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C11 */
                     pr_default.execute(9, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A96WWPFormReferenceName, A97WWPFormTitle, A119WWPFormDate, A120WWPFormIsWizard, A104WWPFormResume, A123WWPFormResumeMessage, A121WWPFormValidations, A122WWPFormInstantiated, A290WWPFormType, A291WWPFormSectionRefElements, A292WWPFormIsForDynamicValidations});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
                     if ( (pr_default.getStatus(9) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0C13( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0C0( ) ;
                           }
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
               Load0C13( ) ;
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void Update0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C12 */
                     pr_default.execute(10, new Object[] {A96WWPFormReferenceName, A97WWPFormTitle, A119WWPFormDate, A120WWPFormIsWizard, A104WWPFormResume, A123WWPFormResumeMessage, A121WWPFormValidations, A122WWPFormInstantiated, A290WWPFormType, A291WWPFormSectionRefElements, A292WWPFormIsForDynamicValidations, A94WWPFormId, A95WWPFormVersionNumber});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Form"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0C13( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
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
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void DeferredUpdate0C13( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C13( ) ;
            AfterConfirm0C13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C13( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0C14( ) ;
                  while ( RcdFound14 != 0 )
                  {
                     getByPrimaryKey0C14( ) ;
                     Delete0C14( ) ;
                     ScanNext0C14( ) ;
                  }
                  ScanEnd0C14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C13 */
                     pr_default.execute(11, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
                              {
                                 context.nUserReturn = 1;
                              }
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
            }
         }
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0C13( ) ;
         Gx_mode = sMode13;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_int1 = A107WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
            A107WWPFormLatestVersionNumber = GXt_int1;
            AssignAttri(sPrefix, false, "A107WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A107WWPFormLatestVersionNumber), 4, 0));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000C14 */
            pr_default.execute(12, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWPForm Instance"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000C15 */
            pr_default.execute(13, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Element"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel0C14( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow0C14( ) ;
            if ( ( nRcdExists_14 != 0 ) || ( nIsMod_14 != 0 ) )
            {
               standaloneNotModal0C14( ) ;
               GetKey0C14( ) ;
               if ( ( nRcdExists_14 == 0 ) && ( nRcdDeleted_14 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  Insert0C14( ) ;
               }
               else
               {
                  if ( RcdFound14 != 0 )
                  {
                     if ( ( nRcdDeleted_14 != 0 ) && ( nRcdExists_14 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        Delete0C14( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_14 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                           Update0C14( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_14 == 0 )
                     {
                        GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPFormElementId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( sPrefix+edtWWPFormElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A98WWPFormElementId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementTitle_Internalname, A117WWPFormElementTitle) ;
            ChangePostValue( sPrefix+edtWWPFormElementReferenceId_Internalname, A101WWPFormElementReferenceId) ;
            ChangePostValue( sPrefix+cmbWWPFormElementType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A105WWPFormElementType), 1, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementOrderIndex_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A100WWPFormElementOrderIndex), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+cmbWWPFormElementDataType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106WWPFormElementDataType), 2, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementParentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A99WWPFormElementParentId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementParentName_Internalname, A116WWPFormElementParentName) ;
            ChangePostValue( sPrefix+cmbWWPFormElementParentType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WWPFormElementParentType), 1, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementMetadata_Internalname, A124WWPFormElementMetadata) ;
            ChangePostValue( sPrefix+cmbWWPFormElementCaption_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPFormElementCaption), 1, 0, ".", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z98WWPFormElementId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98WWPFormElementId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z125WWPFormElementCaption_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125WWPFormElementCaption), 1, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z105WWPFormElementType_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z105WWPFormElementType), 1, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z100WWPFormElementOrderIndex_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z100WWPFormElementOrderIndex), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z106WWPFormElementDataType_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106WWPFormElementDataType), 2, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z101WWPFormElementReferenceId_"+sGXsfl_53_idx, Z101WWPFormElementReferenceId) ;
            ChangePostValue( sPrefix+"ZT_"+"Z126WWPFormElementExcludeFromExport_"+sGXsfl_53_idx, StringUtil.BoolToStr( Z126WWPFormElementExcludeFromExport)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z99WWPFormElementParentId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z99WWPFormElementParentId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nRcdDeleted_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nRcdExists_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nIsMod_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, ",", ""))) ;
            if ( nIsMod_14 != 0 )
            {
               ChangePostValue( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0C14( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_14 = 0;
         nIsMod_14 = 0;
         nRcdDeleted_14 = 0;
      }

      protected void ProcessLevel0C13( )
      {
         /* Save parent mode. */
         sMode13 = Gx_mode;
         ProcessNestedLevel0C14( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode13;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0C13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
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

      public void ScanStart0C13( )
      {
         /* Scan By routine */
         /* Using cursor T000C16 */
         pr_default.execute(14);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound13 = 1;
            A94WWPFormId = T000C16_A94WWPFormId[0];
            AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
            A95WWPFormVersionNumber = T000C16_A95WWPFormVersionNumber[0];
            AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C13( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound13 = 1;
            A94WWPFormId = T000C16_A94WWPFormId[0];
            AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
            A95WWPFormVersionNumber = T000C16_A95WWPFormVersionNumber[0];
            AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
         }
      }

      protected void ScanEnd0C13( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0C13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C13( )
      {
         edtWWPFormId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         edtWWPFormVersionNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         edtWWPFormDate_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormDate_Enabled), 5, 0), true);
         chkWWPFormIsWizard.Enabled = 0;
         AssignProp(sPrefix, false, chkWWPFormIsWizard_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormIsWizard.Enabled), 5, 0), true);
         edtWWPFormReferenceName_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormReferenceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormReferenceName_Enabled), 5, 0), true);
         edtWWPFormTitle_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Enabled), 5, 0), true);
      }

      protected void ZM0C14( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z125WWPFormElementCaption = T000C3_A125WWPFormElementCaption[0];
               Z105WWPFormElementType = T000C3_A105WWPFormElementType[0];
               Z100WWPFormElementOrderIndex = T000C3_A100WWPFormElementOrderIndex[0];
               Z106WWPFormElementDataType = T000C3_A106WWPFormElementDataType[0];
               Z101WWPFormElementReferenceId = T000C3_A101WWPFormElementReferenceId[0];
               Z126WWPFormElementExcludeFromExport = T000C3_A126WWPFormElementExcludeFromExport[0];
               Z99WWPFormElementParentId = T000C3_A99WWPFormElementParentId[0];
            }
            else
            {
               Z125WWPFormElementCaption = A125WWPFormElementCaption;
               Z105WWPFormElementType = A105WWPFormElementType;
               Z100WWPFormElementOrderIndex = A100WWPFormElementOrderIndex;
               Z106WWPFormElementDataType = A106WWPFormElementDataType;
               Z101WWPFormElementReferenceId = A101WWPFormElementReferenceId;
               Z126WWPFormElementExcludeFromExport = A126WWPFormElementExcludeFromExport;
               Z99WWPFormElementParentId = A99WWPFormElementParentId;
            }
         }
         if ( GX_JID == -15 )
         {
            Z98WWPFormElementId = A98WWPFormElementId;
            Z125WWPFormElementCaption = A125WWPFormElementCaption;
            Z117WWPFormElementTitle = A117WWPFormElementTitle;
            Z105WWPFormElementType = A105WWPFormElementType;
            Z100WWPFormElementOrderIndex = A100WWPFormElementOrderIndex;
            Z106WWPFormElementDataType = A106WWPFormElementDataType;
            Z124WWPFormElementMetadata = A124WWPFormElementMetadata;
            Z101WWPFormElementReferenceId = A101WWPFormElementReferenceId;
            Z126WWPFormElementExcludeFromExport = A126WWPFormElementExcludeFromExport;
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            Z99WWPFormElementParentId = A99WWPFormElementParentId;
            Z116WWPFormElementParentName = A116WWPFormElementParentName;
            Z118WWPFormElementParentType = A118WWPFormElementParentType;
         }
      }

      protected void standaloneNotModal0C14( )
      {
      }

      protected void standaloneModal0C14( )
      {
         if ( IsIns( )  && (0==A125WWPFormElementCaption) && ( Gx_BScreen == 0 ) )
         {
            A125WWPFormElementCaption = 1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtWWPFormElementId_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         else
         {
            edtWWPFormElementId_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0C14( )
      {
         /* Using cursor T000C17 */
         pr_default.execute(15, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound14 = 1;
            A125WWPFormElementCaption = T000C17_A125WWPFormElementCaption[0];
            A117WWPFormElementTitle = T000C17_A117WWPFormElementTitle[0];
            A105WWPFormElementType = T000C17_A105WWPFormElementType[0];
            A100WWPFormElementOrderIndex = T000C17_A100WWPFormElementOrderIndex[0];
            A106WWPFormElementDataType = T000C17_A106WWPFormElementDataType[0];
            A116WWPFormElementParentName = T000C17_A116WWPFormElementParentName[0];
            A118WWPFormElementParentType = T000C17_A118WWPFormElementParentType[0];
            A124WWPFormElementMetadata = T000C17_A124WWPFormElementMetadata[0];
            A101WWPFormElementReferenceId = T000C17_A101WWPFormElementReferenceId[0];
            A126WWPFormElementExcludeFromExport = T000C17_A126WWPFormElementExcludeFromExport[0];
            A99WWPFormElementParentId = T000C17_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = T000C17_n99WWPFormElementParentId[0];
            ZM0C14( -15) ;
         }
         pr_default.close(15);
         OnLoadActions0C14( ) ;
      }

      protected void OnLoadActions0C14( )
      {
      }

      protected void CheckExtendedTable0C14( )
      {
         nIsDirty_14 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0C14( ) ;
         /* Using cursor T000C4 */
         pr_default.execute(2, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A94WWPFormId) || (0==A95WWPFormVersionNumber) || (0==A99WWPFormElementParentId) ) )
            {
               GXCCtl = "WWPFORMELEMENTPARENTID_" + sGXsfl_53_idx;
               GX_msglist.addItem("Não existe 'WWPForm Element Parent'.", "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtWWPFormElementParentId_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A116WWPFormElementParentName = T000C4_A116WWPFormElementParentName[0];
         A118WWPFormElementParentType = T000C4_A118WWPFormElementParentType[0];
         pr_default.close(2);
         if ( ! ( ( A105WWPFormElementType == 1 ) || ( A105WWPFormElementType == 2 ) || ( A105WWPFormElementType == 3 ) || ( A105WWPFormElementType == 4 ) || ( A105WWPFormElementType == 5 ) ) )
         {
            GXCCtl = "WWPFORMELEMENTTYPE_" + sGXsfl_53_idx;
            GX_msglist.addItem("Campo WWPForm Element Type fora do intervalo", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbWWPFormElementType_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( A106WWPFormElementDataType == 1 ) || ( A106WWPFormElementDataType == 2 ) || ( A106WWPFormElementDataType == 3 ) || ( A106WWPFormElementDataType == 4 ) || ( A106WWPFormElementDataType == 5 ) || ( A106WWPFormElementDataType == 6 ) || ( A106WWPFormElementDataType == 7 ) || ( A106WWPFormElementDataType == 8 ) || ( A106WWPFormElementDataType == 9 ) || ( A106WWPFormElementDataType == 10 ) ) )
         {
            GXCCtl = "WWPFORMELEMENTDATATYPE_" + sGXsfl_53_idx;
            GX_msglist.addItem("Campo WWPForm Element Data Type fora do intervalo", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbWWPFormElementDataType_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( A125WWPFormElementCaption == 1 ) || ( A125WWPFormElementCaption == 2 ) || ( A125WWPFormElementCaption == 3 ) ) )
         {
            GXCCtl = "WWPFORMELEMENTCAPTION_" + sGXsfl_53_idx;
            GX_msglist.addItem("Campo WWPForm Element Caption fora do intervalo", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbWWPFormElementCaption_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0C14( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0C14( )
      {
      }

      protected void gxLoad_16( short A94WWPFormId ,
                                short A95WWPFormVersionNumber ,
                                short A99WWPFormElementParentId )
      {
         /* Using cursor T000C18 */
         pr_default.execute(16, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A94WWPFormId) || (0==A95WWPFormVersionNumber) || (0==A99WWPFormElementParentId) ) )
            {
               GXCCtl = "WWPFORMELEMENTPARENTID_" + sGXsfl_53_idx;
               GX_msglist.addItem("Não existe 'WWPForm Element Parent'.", "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtWWPFormElementParentId_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A116WWPFormElementParentName = T000C18_A116WWPFormElementParentName[0];
         A118WWPFormElementParentType = T000C18_A118WWPFormElementParentType[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A116WWPFormElementParentName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WWPFormElementParentType), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void GetKey0C14( )
      {
         /* Using cursor T000C19 */
         pr_default.execute(17, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey0C14( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C14( 15) ;
            RcdFound14 = 1;
            InitializeNonKey0C14( ) ;
            A98WWPFormElementId = T000C3_A98WWPFormElementId[0];
            A125WWPFormElementCaption = T000C3_A125WWPFormElementCaption[0];
            A117WWPFormElementTitle = T000C3_A117WWPFormElementTitle[0];
            A105WWPFormElementType = T000C3_A105WWPFormElementType[0];
            A100WWPFormElementOrderIndex = T000C3_A100WWPFormElementOrderIndex[0];
            A106WWPFormElementDataType = T000C3_A106WWPFormElementDataType[0];
            A124WWPFormElementMetadata = T000C3_A124WWPFormElementMetadata[0];
            A101WWPFormElementReferenceId = T000C3_A101WWPFormElementReferenceId[0];
            A126WWPFormElementExcludeFromExport = T000C3_A126WWPFormElementExcludeFromExport[0];
            A99WWPFormElementParentId = T000C3_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = T000C3_n99WWPFormElementParentId[0];
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            Z98WWPFormElementId = A98WWPFormElementId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0C14( ) ;
            Gx_mode = sMode14;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0C14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal0C14( ) ;
            Gx_mode = sMode14;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0C14( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0C14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormElement"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z125WWPFormElementCaption != T000C2_A125WWPFormElementCaption[0] ) || ( Z105WWPFormElementType != T000C2_A105WWPFormElementType[0] ) || ( Z100WWPFormElementOrderIndex != T000C2_A100WWPFormElementOrderIndex[0] ) || ( Z106WWPFormElementDataType != T000C2_A106WWPFormElementDataType[0] ) || ( StringUtil.StrCmp(Z101WWPFormElementReferenceId, T000C2_A101WWPFormElementReferenceId[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z126WWPFormElementExcludeFromExport != T000C2_A126WWPFormElementExcludeFromExport[0] ) || ( Z99WWPFormElementParentId != T000C2_A99WWPFormElementParentId[0] ) )
            {
               if ( Z125WWPFormElementCaption != T000C2_A125WWPFormElementCaption[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementCaption");
                  GXUtil.WriteLogRaw("Old: ",Z125WWPFormElementCaption);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A125WWPFormElementCaption[0]);
               }
               if ( Z105WWPFormElementType != T000C2_A105WWPFormElementType[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementType");
                  GXUtil.WriteLogRaw("Old: ",Z105WWPFormElementType);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A105WWPFormElementType[0]);
               }
               if ( Z100WWPFormElementOrderIndex != T000C2_A100WWPFormElementOrderIndex[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementOrderIndex");
                  GXUtil.WriteLogRaw("Old: ",Z100WWPFormElementOrderIndex);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A100WWPFormElementOrderIndex[0]);
               }
               if ( Z106WWPFormElementDataType != T000C2_A106WWPFormElementDataType[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementDataType");
                  GXUtil.WriteLogRaw("Old: ",Z106WWPFormElementDataType);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A106WWPFormElementDataType[0]);
               }
               if ( StringUtil.StrCmp(Z101WWPFormElementReferenceId, T000C2_A101WWPFormElementReferenceId[0]) != 0 )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementReferenceId");
                  GXUtil.WriteLogRaw("Old: ",Z101WWPFormElementReferenceId);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A101WWPFormElementReferenceId[0]);
               }
               if ( Z126WWPFormElementExcludeFromExport != T000C2_A126WWPFormElementExcludeFromExport[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementExcludeFromExport");
                  GXUtil.WriteLogRaw("Old: ",Z126WWPFormElementExcludeFromExport);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A126WWPFormElementExcludeFromExport[0]);
               }
               if ( Z99WWPFormElementParentId != T000C2_A99WWPFormElementParentId[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_form:[seudo value changed for attri]"+"WWPFormElementParentId");
                  GXUtil.WriteLogRaw("Old: ",Z99WWPFormElementParentId);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A99WWPFormElementParentId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormElement"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C14( )
      {
         BeforeValidate0C14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C14( 0) ;
            CheckOptimisticConcurrency0C14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C20 */
                     pr_default.execute(18, new Object[] {A98WWPFormElementId, A125WWPFormElementCaption, A117WWPFormElementTitle, A105WWPFormElementType, A100WWPFormElementOrderIndex, A106WWPFormElementDataType, A124WWPFormElementMetadata, A101WWPFormElementReferenceId, A126WWPFormElementExcludeFromExport, A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                     if ( (pr_default.getStatus(18) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load0C14( ) ;
            }
            EndLevel0C14( ) ;
         }
         CloseExtendedTableCursors0C14( ) ;
      }

      protected void Update0C14( )
      {
         BeforeValidate0C14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C14( ) ;
         }
         if ( ( nIsMod_14 != 0 ) || ( nIsDirty_14 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0C14( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0C14( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0C14( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000C21 */
                        pr_default.execute(19, new Object[] {A125WWPFormElementCaption, A117WWPFormElementTitle, A105WWPFormElementType, A100WWPFormElementOrderIndex, A106WWPFormElementDataType, A124WWPFormElementMetadata, A101WWPFormElementReferenceId, A126WWPFormElementExcludeFromExport, n99WWPFormElementParentId, A99WWPFormElementParentId, A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
                        pr_default.close(19);
                        pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                        if ( (pr_default.getStatus(19) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormElement"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0C14( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0C14( ) ;
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
               EndLevel0C14( ) ;
            }
         }
         CloseExtendedTableCursors0C14( ) ;
      }

      protected void DeferredUpdate0C14( )
      {
      }

      protected void Delete0C14( )
      {
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         BeforeValidate0C14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C14( ) ;
            AfterConfirm0C14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C22 */
                  pr_default.execute(20, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
                  pr_default.close(20);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0C14( ) ;
         Gx_mode = sMode14;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C14( )
      {
         standaloneModal0C14( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000C23 */
            pr_default.execute(21, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
            A116WWPFormElementParentName = T000C23_A116WWPFormElementParentName[0];
            A118WWPFormElementParentType = T000C23_A118WWPFormElementParentType[0];
            pr_default.close(21);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000C24 */
            pr_default.execute(22, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Element"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
         }
      }

      protected void EndLevel0C14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C14( )
      {
         /* Scan By routine */
         /* Using cursor T000C25 */
         pr_default.execute(23, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         RcdFound14 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound14 = 1;
            A98WWPFormElementId = T000C25_A98WWPFormElementId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C14( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound14 = 1;
            A98WWPFormElementId = T000C25_A98WWPFormElementId[0];
         }
      }

      protected void ScanEnd0C14( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm0C14( )
      {
         /* After Confirm Rules */
         if ( (0==A99WWPFormElementParentId) )
         {
            A99WWPFormElementParentId = 0;
            n99WWPFormElementParentId = false;
            n99WWPFormElementParentId = true;
            n99WWPFormElementParentId = true;
         }
      }

      protected void BeforeInsert0C14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C14( )
      {
         edtWWPFormElementId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtWWPFormElementTitle_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtWWPFormElementReferenceId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementReferenceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         cmbWWPFormElementType.Enabled = 0;
         AssignProp(sPrefix, false, cmbWWPFormElementType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementType.Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtWWPFormElementOrderIndex_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementOrderIndex_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         cmbWWPFormElementDataType.Enabled = 0;
         AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtWWPFormElementParentId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementParentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtWWPFormElementParentName_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementParentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         cmbWWPFormElementParentType.Enabled = 0;
         AssignProp(sPrefix, false, cmbWWPFormElementParentType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtWWPFormElementMetadata_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         cmbWWPFormElementCaption.Enabled = 0;
         AssignProp(sPrefix, false, cmbWWPFormElementCaption_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void send_integrity_lvl_hashes0C14( )
      {
      }

      protected void send_integrity_lvl_hashes0C13( )
      {
      }

      protected void SubsflControlProps_5314( )
      {
         edtWWPFormElementId_Internalname = sPrefix+"WWPFORMELEMENTID_"+sGXsfl_53_idx;
         edtWWPFormElementTitle_Internalname = sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_53_idx;
         edtWWPFormElementReferenceId_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_53_idx;
         cmbWWPFormElementType_Internalname = sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_53_idx;
         edtWWPFormElementOrderIndex_Internalname = sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_53_idx;
         cmbWWPFormElementDataType_Internalname = sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_53_idx;
         edtWWPFormElementParentId_Internalname = sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_53_idx;
         edtWWPFormElementParentName_Internalname = sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_53_idx;
         cmbWWPFormElementParentType_Internalname = sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_53_idx;
         edtWWPFormElementMetadata_Internalname = sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_53_idx;
         cmbWWPFormElementCaption_Internalname = sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_5314( )
      {
         edtWWPFormElementId_Internalname = sPrefix+"WWPFORMELEMENTID_"+sGXsfl_53_fel_idx;
         edtWWPFormElementTitle_Internalname = sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_53_fel_idx;
         edtWWPFormElementReferenceId_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_53_fel_idx;
         cmbWWPFormElementType_Internalname = sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_53_fel_idx;
         edtWWPFormElementOrderIndex_Internalname = sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_53_fel_idx;
         cmbWWPFormElementDataType_Internalname = sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_53_fel_idx;
         edtWWPFormElementParentId_Internalname = sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_53_fel_idx;
         edtWWPFormElementParentName_Internalname = sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_53_fel_idx;
         cmbWWPFormElementParentType_Internalname = sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_53_fel_idx;
         edtWWPFormElementMetadata_Internalname = sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_53_fel_idx;
         cmbWWPFormElementCaption_Internalname = sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_53_fel_idx;
      }

      protected void AddRow0C14( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5314( ) ;
         SendRow0C14( ) ;
      }

      protected void SendRow0C14( )
      {
         Gridlevel_elementRow = GXWebRow.GetNew(context);
         if ( subGridlevel_element_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_element_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
            {
               subGridlevel_element_Linesclass = subGridlevel_element_Class+"Odd";
            }
         }
         else if ( subGridlevel_element_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_element_Backstyle = 0;
            subGridlevel_element_Backcolor = subGridlevel_element_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
            {
               subGridlevel_element_Linesclass = subGridlevel_element_Class+"Uniform";
            }
         }
         else if ( subGridlevel_element_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_element_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
            {
               subGridlevel_element_Linesclass = subGridlevel_element_Class+"Odd";
            }
            subGridlevel_element_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_element_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_element_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridlevel_element_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
               {
                  subGridlevel_element_Linesclass = subGridlevel_element_Class+"Even";
               }
            }
            else
            {
               subGridlevel_element_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_element_Class, "") != 0 )
               {
                  subGridlevel_element_Linesclass = subGridlevel_element_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A98WWPFormElementId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A98WWPFormElementId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementTitle_Internalname,(string)A117WWPFormElementTitle,(string)A117WWPFormElementTitle,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementTitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementTitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)53,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementReferenceId_Internalname,(string)A101WWPFormElementReferenceId,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementReferenceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementReferenceId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'" + sGXsfl_53_idx + "',53)\"";
         if ( ( cmbWWPFormElementType.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "WWPFORMELEMENTTYPE_" + sGXsfl_53_idx;
            cmbWWPFormElementType.Name = GXCCtl;
            cmbWWPFormElementType.WebTags = "";
            cmbWWPFormElementType.addItem("1", "Simples", 0);
            cmbWWPFormElementType.addItem("2", "Contenedor", 0);
            cmbWWPFormElementType.addItem("3", "Repetidor de Elemento", 0);
            cmbWWPFormElementType.addItem("4", "Rótulo", 0);
            cmbWWPFormElementType.addItem("5", "Passado", 0);
            if ( cmbWWPFormElementType.ItemCount > 0 )
            {
               A105WWPFormElementType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A105WWPFormElementType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            }
         }
         /* ComboBox */
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementType,(string)cmbWWPFormElementType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A105WWPFormElementType), 1, 0)),(short)1,(string)cmbWWPFormElementType_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementType.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A105WWPFormElementType), 1, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementType_Internalname, "Values", (string)(cmbWWPFormElementType.ToJavascriptSource()), !bGXsfl_53_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementOrderIndex_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A100WWPFormElementOrderIndex), 4, 0, ",", "")),StringUtil.LTrim( ((edtWWPFormElementOrderIndex_Enabled!=0) ? context.localUtil.Format( (decimal)(A100WWPFormElementOrderIndex), "ZZZ9") : context.localUtil.Format( (decimal)(A100WWPFormElementOrderIndex), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementOrderIndex_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementOrderIndex_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'" + sGXsfl_53_idx + "',53)\"";
         if ( ( cmbWWPFormElementDataType.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "WWPFORMELEMENTDATATYPE_" + sGXsfl_53_idx;
            cmbWWPFormElementDataType.Name = GXCCtl;
            cmbWWPFormElementDataType.WebTags = "";
            cmbWWPFormElementDataType.addItem("1", "Boleano", 0);
            cmbWWPFormElementDataType.addItem("2", "Caracteres", 0);
            cmbWWPFormElementDataType.addItem("3", "Numérico", 0);
            cmbWWPFormElementDataType.addItem("4", "Data", 0);
            cmbWWPFormElementDataType.addItem("5", "Data e hora", 0);
            cmbWWPFormElementDataType.addItem("6", "Senha", 0);
            cmbWWPFormElementDataType.addItem("7", "Correio eletrônico", 0);
            cmbWWPFormElementDataType.addItem("8", "URL", 0);
            cmbWWPFormElementDataType.addItem("9", "Arquivo", 0);
            cmbWWPFormElementDataType.addItem("10", "Imagem", 0);
            if ( cmbWWPFormElementDataType.ItemCount > 0 )
            {
               A106WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementDataType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A106WWPFormElementDataType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            }
         }
         /* ComboBox */
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementDataType,(string)cmbWWPFormElementDataType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A106WWPFormElementDataType), 2, 0)),(short)1,(string)cmbWWPFormElementDataType_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementDataType.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementDataType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106WWPFormElementDataType), 2, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Values", (string)(cmbWWPFormElementDataType.ToJavascriptSource()), !bGXsfl_53_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementParentId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A99WWPFormElementParentId), 4, 0, ",", "")),StringUtil.LTrim( ((edtWWPFormElementParentId_Enabled!=0) ? context.localUtil.Format( (decimal)(A99WWPFormElementParentId), "ZZZ9") : context.localUtil.Format( (decimal)(A99WWPFormElementParentId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,60);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementParentId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementParentId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementParentName_Internalname,(string)A116WWPFormElementParentName,(string)A116WWPFormElementParentName,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementParentName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementParentName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)53,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'" + sGXsfl_53_idx + "',53)\"";
         GXCCtl = "WWPFORMELEMENTPARENTTYPE_" + sGXsfl_53_idx;
         cmbWWPFormElementParentType.Name = GXCCtl;
         cmbWWPFormElementParentType.WebTags = "";
         cmbWWPFormElementParentType.addItem("1", "Simples", 0);
         cmbWWPFormElementParentType.addItem("2", "Contenedor", 0);
         cmbWWPFormElementParentType.addItem("3", "Repetidor de Elemento", 0);
         cmbWWPFormElementParentType.addItem("4", "Rótulo", 0);
         cmbWWPFormElementParentType.addItem("5", "Passado", 0);
         if ( cmbWWPFormElementParentType.ItemCount > 0 )
         {
            A118WWPFormElementParentType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementParentType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118WWPFormElementParentType), 1, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* ComboBox */
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementParentType,(string)cmbWWPFormElementParentType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A118WWPFormElementParentType), 1, 0)),(short)1,(string)cmbWWPFormElementParentType_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementParentType.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementParentType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118WWPFormElementParentType), 1, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementParentType_Internalname, "Values", (string)(cmbWWPFormElementParentType.ToJavascriptSource()), !bGXsfl_53_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementMetadata_Internalname,(string)A124WWPFormElementMetadata,(string)A124WWPFormElementMetadata,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementMetadata_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementMetadata_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)53,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'" + sGXsfl_53_idx + "',53)\"";
         GXCCtl = "WWPFORMELEMENTCAPTION_" + sGXsfl_53_idx;
         cmbWWPFormElementCaption.Name = GXCCtl;
         cmbWWPFormElementCaption.WebTags = "";
         cmbWWPFormElementCaption.addItem("1", "Rótulo", 0);
         cmbWWPFormElementCaption.addItem("2", "Qualificação", 0);
         cmbWWPFormElementCaption.addItem("3", "Nenhum", 0);
         if ( cmbWWPFormElementCaption.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A125WWPFormElementCaption) )
            {
               A125WWPFormElementCaption = 1;
            }
         }
         /* ComboBox */
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementCaption,(string)cmbWWPFormElementCaption_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A125WWPFormElementCaption), 1, 0)),(short)1,(string)cmbWWPFormElementCaption_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementCaption.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementCaption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A125WWPFormElementCaption), 1, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementCaption_Internalname, "Values", (string)(cmbWWPFormElementCaption.ToJavascriptSource()), !bGXsfl_53_Refreshing);
         ajax_sending_grid_row(Gridlevel_elementRow);
         send_integrity_lvl_hashes0C14( ) ;
         GXCCtl = "Z98WWPFormElementId_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98WWPFormElementId), 4, 0, ",", "")));
         GXCCtl = "Z125WWPFormElementCaption_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125WWPFormElementCaption), 1, 0, ",", "")));
         GXCCtl = "Z105WWPFormElementType_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z105WWPFormElementType), 1, 0, ",", "")));
         GXCCtl = "Z100WWPFormElementOrderIndex_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z100WWPFormElementOrderIndex), 4, 0, ",", "")));
         GXCCtl = "Z106WWPFormElementDataType_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106WWPFormElementDataType), 2, 0, ",", "")));
         GXCCtl = "Z101WWPFormElementReferenceId_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z101WWPFormElementReferenceId);
         GXCCtl = "Z126WWPFormElementExcludeFromExport_" + sGXsfl_53_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z126WWPFormElementExcludeFromExport);
         GXCCtl = "Z99WWPFormElementParentId_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z99WWPFormElementParentId), 4, 0, ",", "")));
         GXCCtl = "nRcdDeleted_14_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_14_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, ",", "")));
         GXCCtl = "nIsMod_14_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vWWPFORMID_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormId), 4, 0, ",", "")));
         GXCCtl = "vWWPFORMVERSIONNUMBER_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPFormVersionNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementType.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_elementContainer.AddRow(Gridlevel_elementRow);
      }

      protected void ReadRow0C14( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5314( ) ;
         edtWWPFormElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormElementTitle_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormElementReferenceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         cmbWWPFormElementType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTYPE_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormElementOrderIndex_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTORDERINDEX_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         cmbWWPFormElementDataType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormElementParentId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormElementParentName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTNAME_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         cmbWWPFormElementParentType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTTYPE_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormElementMetadata_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTMETADATA_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         cmbWWPFormElementCaption.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTCAPTION_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementId_Internalname;
            wbErr = true;
            A98WWPFormElementId = 0;
         }
         else
         {
            A98WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormElementId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         A117WWPFormElementTitle = cgiGet( edtWWPFormElementTitle_Internalname);
         A101WWPFormElementReferenceId = cgiGet( edtWWPFormElementReferenceId_Internalname);
         cmbWWPFormElementType.Name = cmbWWPFormElementType_Internalname;
         cmbWWPFormElementType.CurrentValue = cgiGet( cmbWWPFormElementType_Internalname);
         A105WWPFormElementType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormElementType_Internalname), "."), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementOrderIndex_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementOrderIndex_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "WWPFORMELEMENTORDERINDEX_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementOrderIndex_Internalname;
            wbErr = true;
            A100WWPFormElementOrderIndex = 0;
         }
         else
         {
            A100WWPFormElementOrderIndex = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormElementOrderIndex_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         cmbWWPFormElementDataType.Name = cmbWWPFormElementDataType_Internalname;
         cmbWWPFormElementDataType.CurrentValue = cgiGet( cmbWWPFormElementDataType_Internalname);
         A106WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormElementDataType_Internalname), "."), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementParentId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementParentId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "WWPFORMELEMENTPARENTID_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementParentId_Internalname;
            wbErr = true;
            A99WWPFormElementParentId = 0;
            n99WWPFormElementParentId = false;
         }
         else
         {
            A99WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormElementParentId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n99WWPFormElementParentId = false;
         }
         n99WWPFormElementParentId = ((0==A99WWPFormElementParentId) ? true : false);
         A116WWPFormElementParentName = cgiGet( edtWWPFormElementParentName_Internalname);
         cmbWWPFormElementParentType.Name = cmbWWPFormElementParentType_Internalname;
         cmbWWPFormElementParentType.CurrentValue = cgiGet( cmbWWPFormElementParentType_Internalname);
         A118WWPFormElementParentType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormElementParentType_Internalname), "."), 18, MidpointRounding.ToEven));
         A124WWPFormElementMetadata = cgiGet( edtWWPFormElementMetadata_Internalname);
         cmbWWPFormElementCaption.Name = cmbWWPFormElementCaption_Internalname;
         cmbWWPFormElementCaption.CurrentValue = cgiGet( cmbWWPFormElementCaption_Internalname);
         A125WWPFormElementCaption = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormElementCaption_Internalname), "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z98WWPFormElementId_" + sGXsfl_53_idx;
         Z98WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z125WWPFormElementCaption_" + sGXsfl_53_idx;
         Z125WWPFormElementCaption = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z105WWPFormElementType_" + sGXsfl_53_idx;
         Z105WWPFormElementType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z100WWPFormElementOrderIndex_" + sGXsfl_53_idx;
         Z100WWPFormElementOrderIndex = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z106WWPFormElementDataType_" + sGXsfl_53_idx;
         Z106WWPFormElementDataType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z101WWPFormElementReferenceId_" + sGXsfl_53_idx;
         Z101WWPFormElementReferenceId = cgiGet( sPrefix+GXCCtl);
         GXCCtl = "Z126WWPFormElementExcludeFromExport_" + sGXsfl_53_idx;
         Z126WWPFormElementExcludeFromExport = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         GXCCtl = "Z99WWPFormElementParentId_" + sGXsfl_53_idx;
         Z99WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         n99WWPFormElementParentId = ((0==A99WWPFormElementParentId) ? true : false);
         GXCCtl = "Z126WWPFormElementExcludeFromExport_" + sGXsfl_53_idx;
         A126WWPFormElementExcludeFromExport = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         GXCCtl = "nRcdDeleted_14_" + sGXsfl_53_idx;
         nRcdDeleted_14 = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_14_" + sGXsfl_53_idx;
         nRcdExists_14 = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_14_" + sGXsfl_53_idx;
         nIsMod_14 = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtWWPFormElementId_Enabled = edtWWPFormElementId_Enabled;
      }

      protected void ConfirmValues0C0( )
      {
         nGXsfl_53_idx = 0;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5314( ) ;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_5314( ) ;
            ChangePostValue( sPrefix+"Z98WWPFormElementId_"+sGXsfl_53_idx, cgiGet( sPrefix+"ZT_"+"Z98WWPFormElementId_"+sGXsfl_53_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z98WWPFormElementId_"+sGXsfl_53_idx) ;
            ChangePostValue( sPrefix+"Z125WWPFormElementCaption_"+sGXsfl_53_idx, cgiGet( sPrefix+"ZT_"+"Z125WWPFormElementCaption_"+sGXsfl_53_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z125WWPFormElementCaption_"+sGXsfl_53_idx) ;
            ChangePostValue( sPrefix+"Z105WWPFormElementType_"+sGXsfl_53_idx, cgiGet( sPrefix+"ZT_"+"Z105WWPFormElementType_"+sGXsfl_53_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z105WWPFormElementType_"+sGXsfl_53_idx) ;
            ChangePostValue( sPrefix+"Z100WWPFormElementOrderIndex_"+sGXsfl_53_idx, cgiGet( sPrefix+"ZT_"+"Z100WWPFormElementOrderIndex_"+sGXsfl_53_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z100WWPFormElementOrderIndex_"+sGXsfl_53_idx) ;
            ChangePostValue( sPrefix+"Z106WWPFormElementDataType_"+sGXsfl_53_idx, cgiGet( sPrefix+"ZT_"+"Z106WWPFormElementDataType_"+sGXsfl_53_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z106WWPFormElementDataType_"+sGXsfl_53_idx) ;
            ChangePostValue( sPrefix+"Z101WWPFormElementReferenceId_"+sGXsfl_53_idx, cgiGet( sPrefix+"ZT_"+"Z101WWPFormElementReferenceId_"+sGXsfl_53_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z101WWPFormElementReferenceId_"+sGXsfl_53_idx) ;
            ChangePostValue( sPrefix+"Z126WWPFormElementExcludeFromExport_"+sGXsfl_53_idx, cgiGet( sPrefix+"ZT_"+"Z126WWPFormElementExcludeFromExport_"+sGXsfl_53_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z126WWPFormElementExcludeFromExport_"+sGXsfl_53_idx) ;
            ChangePostValue( sPrefix+"Z99WWPFormElementParentId_"+sGXsfl_53_idx, cgiGet( sPrefix+"ZT_"+"Z99WWPFormElementParentId_"+sGXsfl_53_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z99WWPFormElementParentId_"+sGXsfl_53_idx) ;
         }
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
            context.SendWebValue( "WWPForm") ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            bodyStyle += "-moz-opacity:0;opacity:0;";
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_form"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7WWPFormId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV8WWPFormVersionNumber,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_form") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WWP_Form");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("WWPFormResume", context.localUtil.Format( (decimal)(A104WWPFormResume), "9"));
         forbiddenHiddens.Add("WWPFormInstantiated", StringUtil.BoolToStr( A122WWPFormInstantiated));
         forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A290WWPFormType), "9"));
         forbiddenHiddens.Add("WWPFormSectionRefElements", StringUtil.RTrim( context.localUtil.Format( A291WWPFormSectionRefElements, "")));
         forbiddenHiddens.Add("WWPFormIsForDynamicValidations", StringUtil.BoolToStr( A292WWPFormIsForDynamicValidations));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("workwithplus\\dynamicforms\\wwp_form:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z94WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z94WWPFormId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z95WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z95WWPFormVersionNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z96WWPFormReferenceName", Z96WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z97WWPFormTitle", Z97WWPFormTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z119WWPFormDate", context.localUtil.TToC( Z119WWPFormDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z120WWPFormIsWizard", Z120WWPFormIsWizard);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z104WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z104WWPFormResume), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z122WWPFormInstantiated", Z122WWPFormInstantiated);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z290WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z290WWPFormType), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z291WWPFormSectionRefElements", Z291WWPFormSectionRefElements);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z292WWPFormIsForDynamicValidations", Z292WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7WWPFormId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8WWPFormVersionNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_53", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_53_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMLATESTVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A107WWPFormLatestVersionNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPFormVersionNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMRESUME", StringUtil.LTrim( StringUtil.NToC( (decimal)(A104WWPFormResume), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMRESUMEMESSAGE", A123WWPFormResumeMessage);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMVALIDATIONS", A121WWPFormValidations);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPFORMINSTANTIATED", A122WWPFormInstantiated);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A290WWPFormType), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMSECTIONREFELEMENTS", A291WWPFormSectionRefElements);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPFORMISFORDYNAMICVALIDATIONS", A292WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"WWPFORMELEMENTEXCLUDEFROMEXPORT", A126WWPFormElementExcludeFromExport);
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
      }

      protected void RenderHtmlCloseForm0C13( )
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
            context.WriteHtmlTextNl( "</form>") ;
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
         return "WorkWithPlus.DynamicForms.WWP_Form" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWPForm" ;
      }

      protected void InitializeNonKey0C13( )
      {
         A107WWPFormLatestVersionNumber = 0;
         AssignAttri(sPrefix, false, "A107WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A107WWPFormLatestVersionNumber), 4, 0));
         A96WWPFormReferenceName = "";
         AssignAttri(sPrefix, false, "A96WWPFormReferenceName", A96WWPFormReferenceName);
         A97WWPFormTitle = "";
         AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
         A119WWPFormDate = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "A119WWPFormDate", context.localUtil.TToC( A119WWPFormDate, 8, 5, 0, 3, "/", ":", " "));
         A120WWPFormIsWizard = false;
         AssignAttri(sPrefix, false, "A120WWPFormIsWizard", A120WWPFormIsWizard);
         A104WWPFormResume = 0;
         AssignAttri(sPrefix, false, "A104WWPFormResume", StringUtil.Str( (decimal)(A104WWPFormResume), 1, 0));
         A123WWPFormResumeMessage = "";
         AssignAttri(sPrefix, false, "A123WWPFormResumeMessage", A123WWPFormResumeMessage);
         A121WWPFormValidations = "";
         AssignAttri(sPrefix, false, "A121WWPFormValidations", A121WWPFormValidations);
         A122WWPFormInstantiated = false;
         AssignAttri(sPrefix, false, "A122WWPFormInstantiated", A122WWPFormInstantiated);
         A290WWPFormType = 0;
         AssignAttri(sPrefix, false, "A290WWPFormType", StringUtil.Str( (decimal)(A290WWPFormType), 1, 0));
         A291WWPFormSectionRefElements = "";
         AssignAttri(sPrefix, false, "A291WWPFormSectionRefElements", A291WWPFormSectionRefElements);
         A292WWPFormIsForDynamicValidations = false;
         AssignAttri(sPrefix, false, "A292WWPFormIsForDynamicValidations", A292WWPFormIsForDynamicValidations);
         Z96WWPFormReferenceName = "";
         Z97WWPFormTitle = "";
         Z119WWPFormDate = (DateTime)(DateTime.MinValue);
         Z120WWPFormIsWizard = false;
         Z104WWPFormResume = 0;
         Z122WWPFormInstantiated = false;
         Z290WWPFormType = 0;
         Z291WWPFormSectionRefElements = "";
         Z292WWPFormIsForDynamicValidations = false;
      }

      protected void InitAll0C13( )
      {
         A94WWPFormId = 0;
         AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
         A95WWPFormVersionNumber = 0;
         AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
         InitializeNonKey0C13( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0C14( )
      {
         A117WWPFormElementTitle = "";
         A105WWPFormElementType = 0;
         A100WWPFormElementOrderIndex = 0;
         A106WWPFormElementDataType = 0;
         A99WWPFormElementParentId = 0;
         n99WWPFormElementParentId = false;
         A116WWPFormElementParentName = "";
         A118WWPFormElementParentType = 0;
         A124WWPFormElementMetadata = "";
         A101WWPFormElementReferenceId = "";
         A126WWPFormElementExcludeFromExport = false;
         AssignAttri(sPrefix, false, "A126WWPFormElementExcludeFromExport", A126WWPFormElementExcludeFromExport);
         A125WWPFormElementCaption = 1;
         Z125WWPFormElementCaption = 0;
         Z105WWPFormElementType = 0;
         Z100WWPFormElementOrderIndex = 0;
         Z106WWPFormElementDataType = 0;
         Z101WWPFormElementReferenceId = "";
         Z126WWPFormElementExcludeFromExport = false;
         Z99WWPFormElementParentId = 0;
      }

      protected void InitAll0C14( )
      {
         A98WWPFormElementId = 0;
         InitializeNonKey0C14( ) ;
      }

      protected void StandaloneModalInsert0C14( )
      {
         A125WWPFormElementCaption = i125WWPFormElementCaption;
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
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7WWPFormId = (string)((string)getParm(obj,1));
         sCtrlAV8WWPFormVersionNumber = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            initialize_properties( ) ;
         }
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         if ( nDoneStart == 0 )
         {
            createObjects();
            initialize();
         }
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_form", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITENV( ) ;
            INITTRN( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV7WWPFormId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7WWPFormId", StringUtil.LTrimStr( (decimal)(AV7WWPFormId), 4, 0));
            AV8WWPFormVersionNumber = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV8WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV8WWPFormVersionNumber), 4, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPFormId"), ",", "."), 18, MidpointRounding.ToEven));
         wcpOAV8WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8WWPFormVersionNumber"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7WWPFormId != wcpOAV7WWPFormId ) || ( AV8WWPFormVersionNumber != wcpOAV8WWPFormVersionNumber ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7WWPFormId = AV7WWPFormId;
         wcpOAV8WWPFormVersionNumber = AV8WWPFormVersionNumber;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV7WWPFormId = cgiGet( sPrefix+"AV7WWPFormId_CTRL");
         if ( StringUtil.Len( sCtrlAV7WWPFormId) > 0 )
         {
            AV7WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV7WWPFormId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV7WWPFormId", StringUtil.LTrimStr( (decimal)(AV7WWPFormId), 4, 0));
         }
         else
         {
            AV7WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV7WWPFormId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
         sCtrlAV8WWPFormVersionNumber = cgiGet( sPrefix+"AV8WWPFormVersionNumber_CTRL");
         if ( StringUtil.Len( sCtrlAV8WWPFormVersionNumber) > 0 )
         {
            AV8WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8WWPFormVersionNumber), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV8WWPFormVersionNumber), 4, 0));
         }
         else
         {
            AV8WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8WWPFormVersionNumber_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         INITENV( ) ;
         INITTRN( ) ;
         nDraw = 0;
         sEvt = sCompEvt;
         if ( isFullAjaxMode( ) )
         {
            UserMain( ) ;
         }
         else
         {
            WCParametersGet( ) ;
         }
         Process( ) ;
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
         UserMain( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPFormId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7WWPFormId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPFormId_CTRL", StringUtil.RTrim( sCtrlAV7WWPFormId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPFormVersionNumber_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPFormVersionNumber), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8WWPFormVersionNumber)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPFormVersionNumber_CTRL", StringUtil.RTrim( sCtrlAV8WWPFormVersionNumber));
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
         Draw( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101974658", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_form.js", "?20256101974658", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties14( )
      {
         edtWWPFormElementId_Enabled = defedtWWPFormElementId_Enabled;
         AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void StartGridControl53( )
      {
         Gridlevel_elementContainer.AddObjectProperty("GridName", "Gridlevel_element");
         Gridlevel_elementContainer.AddObjectProperty("Header", subGridlevel_element_Header);
         Gridlevel_elementContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
         Gridlevel_elementContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("CmpContext", sPrefix);
         Gridlevel_elementContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A98WWPFormElementId), 4, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A117WWPFormElementTitle));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A101WWPFormElementReferenceId));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A105WWPFormElementType), 1, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementType.Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A100WWPFormElementOrderIndex), 4, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementOrderIndex_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106WWPFormElementDataType), 2, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A99WWPFormElementParentId), 4, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A116WWPFormElementParentName));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentName_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WWPFormElementParentType), 1, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementParentType.Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A124WWPFormElementMetadata));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementMetadata_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPFormElementCaption), 1, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementCaption.Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Selectedindex), 4, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Allowselection), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Allowhovering), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_elementContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_element_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtWWPFormId_Internalname = sPrefix+"WWPFORMID";
         edtWWPFormVersionNumber_Internalname = sPrefix+"WWPFORMVERSIONNUMBER";
         edtWWPFormDate_Internalname = sPrefix+"WWPFORMDATE";
         chkWWPFormIsWizard_Internalname = sPrefix+"WWPFORMISWIZARD";
         edtWWPFormReferenceName_Internalname = sPrefix+"WWPFORMREFERENCENAME";
         edtWWPFormTitle_Internalname = sPrefix+"WWPFORMTITLE";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = sPrefix+"DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         edtWWPFormElementId_Internalname = sPrefix+"WWPFORMELEMENTID";
         edtWWPFormElementTitle_Internalname = sPrefix+"WWPFORMELEMENTTITLE";
         edtWWPFormElementReferenceId_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID";
         cmbWWPFormElementType_Internalname = sPrefix+"WWPFORMELEMENTTYPE";
         edtWWPFormElementOrderIndex_Internalname = sPrefix+"WWPFORMELEMENTORDERINDEX";
         cmbWWPFormElementDataType_Internalname = sPrefix+"WWPFORMELEMENTDATATYPE";
         edtWWPFormElementParentId_Internalname = sPrefix+"WWPFORMELEMENTPARENTID";
         edtWWPFormElementParentName_Internalname = sPrefix+"WWPFORMELEMENTPARENTNAME";
         cmbWWPFormElementParentType_Internalname = sPrefix+"WWPFORMELEMENTPARENTTYPE";
         edtWWPFormElementMetadata_Internalname = sPrefix+"WWPFORMELEMENTMETADATA";
         cmbWWPFormElementCaption_Internalname = sPrefix+"WWPFORMELEMENTCAPTION";
         divTableleaflevel_element_Internalname = sPrefix+"TABLELEAFLEVEL_ELEMENT";
         bttBtntrn_enter_Internalname = sPrefix+"BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = sPrefix+"BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = sPrefix+"BTNTRN_DELETE";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridlevel_element_Internalname = sPrefix+"GRIDLEVEL_ELEMENT";
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
         subGridlevel_element_Allowcollapsing = 0;
         subGridlevel_element_Allowselection = 0;
         subGridlevel_element_Header = "";
         cmbWWPFormElementCaption_Jsonclick = "";
         edtWWPFormElementMetadata_Jsonclick = "";
         cmbWWPFormElementParentType_Jsonclick = "";
         edtWWPFormElementParentName_Jsonclick = "";
         edtWWPFormElementParentId_Jsonclick = "";
         cmbWWPFormElementDataType_Jsonclick = "";
         edtWWPFormElementOrderIndex_Jsonclick = "";
         cmbWWPFormElementType_Jsonclick = "";
         edtWWPFormElementReferenceId_Jsonclick = "";
         edtWWPFormElementTitle_Jsonclick = "";
         edtWWPFormElementId_Jsonclick = "";
         subGridlevel_element_Class = "GridWithBorderColor WorkWith";
         subGridlevel_element_Backcolorstyle = 0;
         cmbWWPFormElementCaption.Enabled = 1;
         edtWWPFormElementMetadata_Enabled = 1;
         cmbWWPFormElementParentType.Enabled = 0;
         edtWWPFormElementParentName_Enabled = 0;
         edtWWPFormElementParentId_Enabled = 1;
         cmbWWPFormElementDataType.Enabled = 1;
         edtWWPFormElementOrderIndex_Enabled = 1;
         cmbWWPFormElementType.Enabled = 1;
         edtWWPFormElementReferenceId_Enabled = 1;
         edtWWPFormElementTitle_Enabled = 1;
         edtWWPFormElementId_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtWWPFormTitle_Jsonclick = "";
         edtWWPFormTitle_Enabled = 1;
         edtWWPFormReferenceName_Jsonclick = "";
         edtWWPFormReferenceName_Enabled = 1;
         chkWWPFormIsWizard.Enabled = 1;
         edtWWPFormDate_Jsonclick = "";
         edtWWPFormDate_Enabled = 1;
         edtWWPFormVersionNumber_Jsonclick = "";
         edtWWPFormVersionNumber_Enabled = 1;
         edtWWPFormId_Jsonclick = "";
         edtWWPFormId_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX1ASAWWPFORMLATESTVERSIONNUMBER0C13( short A94WWPFormId )
      {
         GXt_int1 = A107WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
         A107WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri(sPrefix, false, "A107WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A107WWPFormLatestVersionNumber), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A107WWPFormLatestVersionNumber), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_element_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         SubsflControlProps_5314( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0C14( ) ;
            standaloneModal0C14( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0C14( ) ;
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_5314( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_elementContainer)) ;
         /* End function gxnrGridlevel_element_newrow */
      }

      protected void init_web_controls( )
      {
         chkWWPFormIsWizard.Name = "WWPFORMISWIZARD";
         chkWWPFormIsWizard.WebTags = "";
         chkWWPFormIsWizard.Caption = "Is Wizard";
         AssignProp(sPrefix, false, chkWWPFormIsWizard_Internalname, "TitleCaption", chkWWPFormIsWizard.Caption, true);
         chkWWPFormIsWizard.CheckedValue = "false";
         GXCCtl = "WWPFORMELEMENTTYPE_" + sGXsfl_53_idx;
         cmbWWPFormElementType.Name = GXCCtl;
         cmbWWPFormElementType.WebTags = "";
         cmbWWPFormElementType.addItem("1", "Simples", 0);
         cmbWWPFormElementType.addItem("2", "Contenedor", 0);
         cmbWWPFormElementType.addItem("3", "Repetidor de Elemento", 0);
         cmbWWPFormElementType.addItem("4", "Rótulo", 0);
         cmbWWPFormElementType.addItem("5", "Passado", 0);
         if ( cmbWWPFormElementType.ItemCount > 0 )
         {
         }
         GXCCtl = "WWPFORMELEMENTDATATYPE_" + sGXsfl_53_idx;
         cmbWWPFormElementDataType.Name = GXCCtl;
         cmbWWPFormElementDataType.WebTags = "";
         cmbWWPFormElementDataType.addItem("1", "Boleano", 0);
         cmbWWPFormElementDataType.addItem("2", "Caracteres", 0);
         cmbWWPFormElementDataType.addItem("3", "Numérico", 0);
         cmbWWPFormElementDataType.addItem("4", "Data", 0);
         cmbWWPFormElementDataType.addItem("5", "Data e hora", 0);
         cmbWWPFormElementDataType.addItem("6", "Senha", 0);
         cmbWWPFormElementDataType.addItem("7", "Correio eletrônico", 0);
         cmbWWPFormElementDataType.addItem("8", "URL", 0);
         cmbWWPFormElementDataType.addItem("9", "Arquivo", 0);
         cmbWWPFormElementDataType.addItem("10", "Imagem", 0);
         if ( cmbWWPFormElementDataType.ItemCount > 0 )
         {
         }
         GXCCtl = "WWPFORMELEMENTPARENTTYPE_" + sGXsfl_53_idx;
         cmbWWPFormElementParentType.Name = GXCCtl;
         cmbWWPFormElementParentType.WebTags = "";
         cmbWWPFormElementParentType.addItem("1", "Simples", 0);
         cmbWWPFormElementParentType.addItem("2", "Contenedor", 0);
         cmbWWPFormElementParentType.addItem("3", "Repetidor de Elemento", 0);
         cmbWWPFormElementParentType.addItem("4", "Rótulo", 0);
         cmbWWPFormElementParentType.addItem("5", "Passado", 0);
         if ( cmbWWPFormElementParentType.ItemCount > 0 )
         {
         }
         GXCCtl = "WWPFORMELEMENTCAPTION_" + sGXsfl_53_idx;
         cmbWWPFormElementCaption.Name = GXCCtl;
         cmbWWPFormElementCaption.WebTags = "";
         cmbWWPFormElementCaption.addItem("1", "Rótulo", 0);
         cmbWWPFormElementCaption.addItem("2", "Qualificação", 0);
         cmbWWPFormElementCaption.addItem("3", "Nenhum", 0);
         if ( cmbWWPFormElementCaption.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A125WWPFormElementCaption) )
            {
               A125WWPFormElementCaption = 1;
            }
         }
         /* End function init_web_controls */
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

      public void Valid_Wwpformid( )
      {
         GXt_int1 = A107WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A94WWPFormId, out  GXt_int1) ;
         A107WWPFormLatestVersionNumber = GXt_int1;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A107WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A107WWPFormLatestVersionNumber), 4, 0, ".", "")));
      }

      public void Valid_Wwpformreferencename( )
      {
         if ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  A94WWPFormId,  A96WWPFormReferenceName) )
         {
            GX_msglist.addItem("O nome de referência deve ser único.", 1, "WWPFORMREFERENCENAME");
            AnyError = 1;
            GX_FocusControl = edtWWPFormReferenceName_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Wwpformelementparentid( )
      {
         n99WWPFormElementParentId = false;
         A118WWPFormElementParentType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementParentType.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormElementParentType.CurrentValue = StringUtil.Str( (decimal)(A118WWPFormElementParentType), 1, 0);
         /* Using cursor T000C23 */
         pr_default.execute(21, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A94WWPFormId) || (0==A95WWPFormVersionNumber) || (0==A99WWPFormElementParentId) ) )
            {
               GX_msglist.addItem("Não existe 'WWPForm Element Parent'.", "ForeignKeyNotFound", 1, "WWPFORMELEMENTPARENTID");
               AnyError = 1;
               GX_FocusControl = edtWWPFormElementParentId_Internalname;
            }
         }
         A116WWPFormElementParentName = T000C23_A116WWPFormElementParentName[0];
         A118WWPFormElementParentType = T000C23_A118WWPFormElementParentType[0];
         cmbWWPFormElementParentType.CurrentValue = StringUtil.Str( (decimal)(A118WWPFormElementParentType), 1, 0);
         pr_default.close(21);
         dynload_actions( ) ;
         if ( cmbWWPFormElementParentType.ItemCount > 0 )
         {
            A118WWPFormElementParentType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementParentType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118WWPFormElementParentType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPFormElementParentType.CurrentValue = StringUtil.Str( (decimal)(A118WWPFormElementParentType), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormElementParentType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118WWPFormElementParentType), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A116WWPFormElementParentName", A116WWPFormElementParentName);
         AssignAttri(sPrefix, false, "A118WWPFormElementParentType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WWPFormElementParentType), 1, 0, ".", "")));
         cmbWWPFormElementParentType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118WWPFormElementParentType), 1, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementParentType_Internalname, "Values", cmbWWPFormElementParentType.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"componentprocess","iparms":[{"postForm":true},{"sPrefix":true},{"sSFPrefix":true},{"sCompEvt":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"AV7WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","type":"int"},{"av":"AV8WWPFormVersionNumber","fld":"vWWPFORMVERSIONNUMBER","pic":"ZZZ9","type":"int"},{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A104WWPFormResume","fld":"WWPFORMRESUME","pic":"9","type":"int"},{"av":"A122WWPFormInstantiated","fld":"WWPFORMINSTANTIATED","type":"boolean"},{"av":"A290WWPFormType","fld":"WWPFORMTYPE","pic":"9","type":"int"},{"av":"A291WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS","type":"svchar"},{"av":"A292WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS","type":"boolean"},{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120C2","iparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[{"av":"A94WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","type":"int"},{"av":"A107WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9","type":"int"},{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]""");
         setEventMetadata("VALID_WWPFORMID",""","oparms":[{"av":"A107WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9","type":"int"},{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER",""","oparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]}""");
         setEventMetadata("VALID_WWPFORMREFERENCENAME","""{"handler":"Valid_Wwpformreferencename","iparms":[{"av":"A94WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","type":"int"},{"av":"A96WWPFormReferenceName","fld":"WWPFORMREFERENCENAME","type":"svchar"},{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]""");
         setEventMetadata("VALID_WWPFORMREFERENCENAME",""","oparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]}""");
         setEventMetadata("VALID_WWPFORMELEMENTID","""{"handler":"Valid_Wwpformelementid","iparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]""");
         setEventMetadata("VALID_WWPFORMELEMENTID",""","oparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]}""");
         setEventMetadata("VALID_WWPFORMELEMENTTYPE","""{"handler":"Valid_Wwpformelementtype","iparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]""");
         setEventMetadata("VALID_WWPFORMELEMENTTYPE",""","oparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]}""");
         setEventMetadata("VALID_WWPFORMELEMENTDATATYPE","""{"handler":"Valid_Wwpformelementdatatype","iparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]""");
         setEventMetadata("VALID_WWPFORMELEMENTDATATYPE",""","oparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]}""");
         setEventMetadata("VALID_WWPFORMELEMENTPARENTID","""{"handler":"Valid_Wwpformelementparentid","iparms":[{"av":"A94WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","type":"int"},{"av":"A95WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","type":"int"},{"av":"A99WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9","type":"int"},{"av":"A116WWPFormElementParentName","fld":"WWPFORMELEMENTPARENTNAME","type":"vchar"},{"av":"cmbWWPFormElementParentType"},{"av":"A118WWPFormElementParentType","fld":"WWPFORMELEMENTPARENTTYPE","pic":"9","type":"int"},{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]""");
         setEventMetadata("VALID_WWPFORMELEMENTPARENTID",""","oparms":[{"av":"A116WWPFormElementParentName","fld":"WWPFORMELEMENTPARENTNAME","type":"vchar"},{"av":"cmbWWPFormElementParentType"},{"av":"A118WWPFormElementParentType","fld":"WWPFORMELEMENTPARENTTYPE","pic":"9","type":"int"},{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]}""");
         setEventMetadata("VALID_WWPFORMELEMENTCAPTION","""{"handler":"Valid_Wwpformelementcaption","iparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]""");
         setEventMetadata("VALID_WWPFORMELEMENTCAPTION",""","oparms":[{"av":"A120WWPFormIsWizard","fld":"WWPFORMISWIZARD","type":"boolean"}]}""");
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
         pr_default.close(21);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z96WWPFormReferenceName = "";
         Z97WWPFormTitle = "";
         Z119WWPFormDate = (DateTime)(DateTime.MinValue);
         Z291WWPFormSectionRefElements = "";
         Z101WWPFormElementReferenceId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         sXEvt = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A119WWPFormDate = (DateTime)(DateTime.MinValue);
         A96WWPFormReferenceName = "";
         A97WWPFormTitle = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_elementContainer = new GXWebGrid( context);
         sMode14 = "";
         sStyleString = "";
         A291WWPFormSectionRefElements = "";
         A123WWPFormResumeMessage = "";
         A121WWPFormValidations = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode13 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A117WWPFormElementTitle = "";
         A101WWPFormElementReferenceId = "";
         A116WWPFormElementParentName = "";
         A124WWPFormElementMetadata = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z123WWPFormResumeMessage = "";
         Z121WWPFormValidations = "";
         T000C7_A94WWPFormId = new short[1] ;
         T000C7_A95WWPFormVersionNumber = new short[1] ;
         T000C7_A96WWPFormReferenceName = new string[] {""} ;
         T000C7_A97WWPFormTitle = new string[] {""} ;
         T000C7_A119WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T000C7_A120WWPFormIsWizard = new bool[] {false} ;
         T000C7_A104WWPFormResume = new short[1] ;
         T000C7_A123WWPFormResumeMessage = new string[] {""} ;
         T000C7_A121WWPFormValidations = new string[] {""} ;
         T000C7_A122WWPFormInstantiated = new bool[] {false} ;
         T000C7_A290WWPFormType = new short[1] ;
         T000C7_A291WWPFormSectionRefElements = new string[] {""} ;
         T000C7_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         T000C8_A94WWPFormId = new short[1] ;
         T000C8_A95WWPFormVersionNumber = new short[1] ;
         T000C6_A94WWPFormId = new short[1] ;
         T000C6_A95WWPFormVersionNumber = new short[1] ;
         T000C6_A96WWPFormReferenceName = new string[] {""} ;
         T000C6_A97WWPFormTitle = new string[] {""} ;
         T000C6_A119WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T000C6_A120WWPFormIsWizard = new bool[] {false} ;
         T000C6_A104WWPFormResume = new short[1] ;
         T000C6_A123WWPFormResumeMessage = new string[] {""} ;
         T000C6_A121WWPFormValidations = new string[] {""} ;
         T000C6_A122WWPFormInstantiated = new bool[] {false} ;
         T000C6_A290WWPFormType = new short[1] ;
         T000C6_A291WWPFormSectionRefElements = new string[] {""} ;
         T000C6_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         T000C9_A94WWPFormId = new short[1] ;
         T000C9_A95WWPFormVersionNumber = new short[1] ;
         T000C10_A94WWPFormId = new short[1] ;
         T000C10_A95WWPFormVersionNumber = new short[1] ;
         T000C5_A94WWPFormId = new short[1] ;
         T000C5_A95WWPFormVersionNumber = new short[1] ;
         T000C5_A96WWPFormReferenceName = new string[] {""} ;
         T000C5_A97WWPFormTitle = new string[] {""} ;
         T000C5_A119WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T000C5_A120WWPFormIsWizard = new bool[] {false} ;
         T000C5_A104WWPFormResume = new short[1] ;
         T000C5_A123WWPFormResumeMessage = new string[] {""} ;
         T000C5_A121WWPFormValidations = new string[] {""} ;
         T000C5_A122WWPFormInstantiated = new bool[] {false} ;
         T000C5_A290WWPFormType = new short[1] ;
         T000C5_A291WWPFormSectionRefElements = new string[] {""} ;
         T000C5_A292WWPFormIsForDynamicValidations = new bool[] {false} ;
         T000C14_A102WWPFormInstanceId = new int[1] ;
         T000C15_A94WWPFormId = new short[1] ;
         T000C15_A95WWPFormVersionNumber = new short[1] ;
         T000C15_A99WWPFormElementParentId = new short[1] ;
         T000C15_n99WWPFormElementParentId = new bool[] {false} ;
         T000C16_A94WWPFormId = new short[1] ;
         T000C16_A95WWPFormVersionNumber = new short[1] ;
         Z117WWPFormElementTitle = "";
         Z124WWPFormElementMetadata = "";
         Z116WWPFormElementParentName = "";
         T000C17_A98WWPFormElementId = new short[1] ;
         T000C17_A125WWPFormElementCaption = new short[1] ;
         T000C17_A117WWPFormElementTitle = new string[] {""} ;
         T000C17_A105WWPFormElementType = new short[1] ;
         T000C17_A100WWPFormElementOrderIndex = new short[1] ;
         T000C17_A106WWPFormElementDataType = new short[1] ;
         T000C17_A116WWPFormElementParentName = new string[] {""} ;
         T000C17_A118WWPFormElementParentType = new short[1] ;
         T000C17_A124WWPFormElementMetadata = new string[] {""} ;
         T000C17_A101WWPFormElementReferenceId = new string[] {""} ;
         T000C17_A126WWPFormElementExcludeFromExport = new bool[] {false} ;
         T000C17_A94WWPFormId = new short[1] ;
         T000C17_A95WWPFormVersionNumber = new short[1] ;
         T000C17_A99WWPFormElementParentId = new short[1] ;
         T000C17_n99WWPFormElementParentId = new bool[] {false} ;
         T000C4_A116WWPFormElementParentName = new string[] {""} ;
         T000C4_A118WWPFormElementParentType = new short[1] ;
         T000C18_A116WWPFormElementParentName = new string[] {""} ;
         T000C18_A118WWPFormElementParentType = new short[1] ;
         T000C19_A94WWPFormId = new short[1] ;
         T000C19_A95WWPFormVersionNumber = new short[1] ;
         T000C19_A98WWPFormElementId = new short[1] ;
         T000C3_A98WWPFormElementId = new short[1] ;
         T000C3_A125WWPFormElementCaption = new short[1] ;
         T000C3_A117WWPFormElementTitle = new string[] {""} ;
         T000C3_A105WWPFormElementType = new short[1] ;
         T000C3_A100WWPFormElementOrderIndex = new short[1] ;
         T000C3_A106WWPFormElementDataType = new short[1] ;
         T000C3_A124WWPFormElementMetadata = new string[] {""} ;
         T000C3_A101WWPFormElementReferenceId = new string[] {""} ;
         T000C3_A126WWPFormElementExcludeFromExport = new bool[] {false} ;
         T000C3_A94WWPFormId = new short[1] ;
         T000C3_A95WWPFormVersionNumber = new short[1] ;
         T000C3_A99WWPFormElementParentId = new short[1] ;
         T000C3_n99WWPFormElementParentId = new bool[] {false} ;
         T000C2_A98WWPFormElementId = new short[1] ;
         T000C2_A125WWPFormElementCaption = new short[1] ;
         T000C2_A117WWPFormElementTitle = new string[] {""} ;
         T000C2_A105WWPFormElementType = new short[1] ;
         T000C2_A100WWPFormElementOrderIndex = new short[1] ;
         T000C2_A106WWPFormElementDataType = new short[1] ;
         T000C2_A124WWPFormElementMetadata = new string[] {""} ;
         T000C2_A101WWPFormElementReferenceId = new string[] {""} ;
         T000C2_A126WWPFormElementExcludeFromExport = new bool[] {false} ;
         T000C2_A94WWPFormId = new short[1] ;
         T000C2_A95WWPFormVersionNumber = new short[1] ;
         T000C2_A99WWPFormElementParentId = new short[1] ;
         T000C2_n99WWPFormElementParentId = new bool[] {false} ;
         T000C23_A116WWPFormElementParentName = new string[] {""} ;
         T000C23_A118WWPFormElementParentType = new short[1] ;
         T000C24_A94WWPFormId = new short[1] ;
         T000C24_A95WWPFormVersionNumber = new short[1] ;
         T000C24_A99WWPFormElementParentId = new short[1] ;
         T000C24_n99WWPFormElementParentId = new bool[] {false} ;
         T000C25_A94WWPFormId = new short[1] ;
         T000C25_A95WWPFormVersionNumber = new short[1] ;
         T000C25_A98WWPFormElementId = new short[1] ;
         Gridlevel_elementRow = new GXWebRow();
         subGridlevel_element_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         sCtrlGx_mode = "";
         sCtrlAV7WWPFormId = "";
         sCtrlAV8WWPFormVersionNumber = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         Gridlevel_elementColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_form__default(),
            new Object[][] {
                new Object[] {
               T000C2_A98WWPFormElementId, T000C2_A125WWPFormElementCaption, T000C2_A117WWPFormElementTitle, T000C2_A105WWPFormElementType, T000C2_A100WWPFormElementOrderIndex, T000C2_A106WWPFormElementDataType, T000C2_A124WWPFormElementMetadata, T000C2_A101WWPFormElementReferenceId, T000C2_A126WWPFormElementExcludeFromExport, T000C2_A94WWPFormId,
               T000C2_A95WWPFormVersionNumber, T000C2_A99WWPFormElementParentId, T000C2_n99WWPFormElementParentId
               }
               , new Object[] {
               T000C3_A98WWPFormElementId, T000C3_A125WWPFormElementCaption, T000C3_A117WWPFormElementTitle, T000C3_A105WWPFormElementType, T000C3_A100WWPFormElementOrderIndex, T000C3_A106WWPFormElementDataType, T000C3_A124WWPFormElementMetadata, T000C3_A101WWPFormElementReferenceId, T000C3_A126WWPFormElementExcludeFromExport, T000C3_A94WWPFormId,
               T000C3_A95WWPFormVersionNumber, T000C3_A99WWPFormElementParentId, T000C3_n99WWPFormElementParentId
               }
               , new Object[] {
               T000C4_A116WWPFormElementParentName, T000C4_A118WWPFormElementParentType
               }
               , new Object[] {
               T000C5_A94WWPFormId, T000C5_A95WWPFormVersionNumber, T000C5_A96WWPFormReferenceName, T000C5_A97WWPFormTitle, T000C5_A119WWPFormDate, T000C5_A120WWPFormIsWizard, T000C5_A104WWPFormResume, T000C5_A123WWPFormResumeMessage, T000C5_A121WWPFormValidations, T000C5_A122WWPFormInstantiated,
               T000C5_A290WWPFormType, T000C5_A291WWPFormSectionRefElements, T000C5_A292WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T000C6_A94WWPFormId, T000C6_A95WWPFormVersionNumber, T000C6_A96WWPFormReferenceName, T000C6_A97WWPFormTitle, T000C6_A119WWPFormDate, T000C6_A120WWPFormIsWizard, T000C6_A104WWPFormResume, T000C6_A123WWPFormResumeMessage, T000C6_A121WWPFormValidations, T000C6_A122WWPFormInstantiated,
               T000C6_A290WWPFormType, T000C6_A291WWPFormSectionRefElements, T000C6_A292WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T000C7_A94WWPFormId, T000C7_A95WWPFormVersionNumber, T000C7_A96WWPFormReferenceName, T000C7_A97WWPFormTitle, T000C7_A119WWPFormDate, T000C7_A120WWPFormIsWizard, T000C7_A104WWPFormResume, T000C7_A123WWPFormResumeMessage, T000C7_A121WWPFormValidations, T000C7_A122WWPFormInstantiated,
               T000C7_A290WWPFormType, T000C7_A291WWPFormSectionRefElements, T000C7_A292WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T000C8_A94WWPFormId, T000C8_A95WWPFormVersionNumber
               }
               , new Object[] {
               T000C9_A94WWPFormId, T000C9_A95WWPFormVersionNumber
               }
               , new Object[] {
               T000C10_A94WWPFormId, T000C10_A95WWPFormVersionNumber
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C14_A102WWPFormInstanceId
               }
               , new Object[] {
               T000C15_A94WWPFormId, T000C15_A95WWPFormVersionNumber, T000C15_A99WWPFormElementParentId
               }
               , new Object[] {
               T000C16_A94WWPFormId, T000C16_A95WWPFormVersionNumber
               }
               , new Object[] {
               T000C17_A98WWPFormElementId, T000C17_A125WWPFormElementCaption, T000C17_A117WWPFormElementTitle, T000C17_A105WWPFormElementType, T000C17_A100WWPFormElementOrderIndex, T000C17_A106WWPFormElementDataType, T000C17_A116WWPFormElementParentName, T000C17_A118WWPFormElementParentType, T000C17_A124WWPFormElementMetadata, T000C17_A101WWPFormElementReferenceId,
               T000C17_A126WWPFormElementExcludeFromExport, T000C17_A94WWPFormId, T000C17_A95WWPFormVersionNumber, T000C17_A99WWPFormElementParentId, T000C17_n99WWPFormElementParentId
               }
               , new Object[] {
               T000C18_A116WWPFormElementParentName, T000C18_A118WWPFormElementParentType
               }
               , new Object[] {
               T000C19_A94WWPFormId, T000C19_A95WWPFormVersionNumber, T000C19_A98WWPFormElementId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C23_A116WWPFormElementParentName, T000C23_A118WWPFormElementParentType
               }
               , new Object[] {
               T000C24_A94WWPFormId, T000C24_A95WWPFormVersionNumber, T000C24_A99WWPFormElementParentId
               }
               , new Object[] {
               T000C25_A94WWPFormId, T000C25_A95WWPFormVersionNumber, T000C25_A98WWPFormElementId
               }
            }
         );
         Z125WWPFormElementCaption = 1;
         A125WWPFormElementCaption = 1;
         i125WWPFormElementCaption = 1;
      }

      private short wcpOAV7WWPFormId ;
      private short wcpOAV8WWPFormVersionNumber ;
      private short Z94WWPFormId ;
      private short Z95WWPFormVersionNumber ;
      private short Z104WWPFormResume ;
      private short Z290WWPFormType ;
      private short Z98WWPFormElementId ;
      private short Z125WWPFormElementCaption ;
      private short Z105WWPFormElementType ;
      private short Z100WWPFormElementOrderIndex ;
      private short Z106WWPFormElementDataType ;
      private short Z99WWPFormElementParentId ;
      private short nRcdDeleted_14 ;
      private short nRcdExists_14 ;
      private short nIsMod_14 ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV7WWPFormId ;
      private short AV8WWPFormVersionNumber ;
      private short A94WWPFormId ;
      private short A95WWPFormVersionNumber ;
      private short A99WWPFormElementParentId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount14 ;
      private short RcdFound14 ;
      private short nBlankRcdUsr14 ;
      private short nDraw ;
      private short nDoneStart ;
      private short A104WWPFormResume ;
      private short A290WWPFormType ;
      private short A107WWPFormLatestVersionNumber ;
      private short RcdFound13 ;
      private short A98WWPFormElementId ;
      private short A105WWPFormElementType ;
      private short A100WWPFormElementOrderIndex ;
      private short A106WWPFormElementDataType ;
      private short A118WWPFormElementParentType ;
      private short A125WWPFormElementCaption ;
      private short Z118WWPFormElementParentType ;
      private short nIsDirty_14 ;
      private short subGridlevel_element_Backcolorstyle ;
      private short subGridlevel_element_Backstyle ;
      private short i125WWPFormElementCaption ;
      private short subGridlevel_element_Allowselection ;
      private short subGridlevel_element_Allowhovering ;
      private short subGridlevel_element_Allowcollapsing ;
      private short subGridlevel_element_Collapsed ;
      private short GXt_int1 ;
      private short Z107WWPFormLatestVersionNumber ;
      private int nRC_GXsfl_53 ;
      private int nGXsfl_53_idx=1 ;
      private int trnEnded ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormDate_Enabled ;
      private int edtWWPFormReferenceName_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtWWPFormElementId_Enabled ;
      private int edtWWPFormElementTitle_Enabled ;
      private int edtWWPFormElementReferenceId_Enabled ;
      private int edtWWPFormElementOrderIndex_Enabled ;
      private int edtWWPFormElementParentId_Enabled ;
      private int edtWWPFormElementParentName_Enabled ;
      private int edtWWPFormElementMetadata_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int subGridlevel_element_Backcolor ;
      private int subGridlevel_element_Allbackcolor ;
      private int defedtWWPFormElementId_Enabled ;
      private int idxLst ;
      private int subGridlevel_element_Selectedindex ;
      private int subGridlevel_element_Selectioncolor ;
      private int subGridlevel_element_Hoveringcolor ;
      private long GRIDLEVEL_ELEMENT_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sXEvt ;
      private string GX_FocusControl ;
      private string edtWWPFormId_Internalname ;
      private string sGXsfl_53_idx="0001" ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormDate_Internalname ;
      private string edtWWPFormDate_Jsonclick ;
      private string chkWWPFormIsWizard_Internalname ;
      private string edtWWPFormReferenceName_Internalname ;
      private string edtWWPFormReferenceName_Jsonclick ;
      private string edtWWPFormTitle_Internalname ;
      private string edtWWPFormTitle_Jsonclick ;
      private string divTableleaflevel_element_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode14 ;
      private string edtWWPFormElementId_Internalname ;
      private string edtWWPFormElementTitle_Internalname ;
      private string edtWWPFormElementReferenceId_Internalname ;
      private string cmbWWPFormElementType_Internalname ;
      private string edtWWPFormElementOrderIndex_Internalname ;
      private string cmbWWPFormElementDataType_Internalname ;
      private string edtWWPFormElementParentId_Internalname ;
      private string edtWWPFormElementParentName_Internalname ;
      private string cmbWWPFormElementParentType_Internalname ;
      private string edtWWPFormElementMetadata_Internalname ;
      private string cmbWWPFormElementCaption_Internalname ;
      private string sStyleString ;
      private string subGridlevel_element_Internalname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode13 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sGXsfl_53_fel_idx="0001" ;
      private string subGridlevel_element_Class ;
      private string subGridlevel_element_Linesclass ;
      private string ROClassString ;
      private string edtWWPFormElementId_Jsonclick ;
      private string edtWWPFormElementTitle_Jsonclick ;
      private string edtWWPFormElementReferenceId_Jsonclick ;
      private string cmbWWPFormElementType_Jsonclick ;
      private string edtWWPFormElementOrderIndex_Jsonclick ;
      private string cmbWWPFormElementDataType_Jsonclick ;
      private string edtWWPFormElementParentId_Jsonclick ;
      private string edtWWPFormElementParentName_Jsonclick ;
      private string cmbWWPFormElementParentType_Jsonclick ;
      private string edtWWPFormElementMetadata_Jsonclick ;
      private string cmbWWPFormElementCaption_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string sCtrlGx_mode ;
      private string sCtrlAV7WWPFormId ;
      private string sCtrlAV8WWPFormVersionNumber ;
      private string subGridlevel_element_Header ;
      private DateTime Z119WWPFormDate ;
      private DateTime A119WWPFormDate ;
      private bool Z120WWPFormIsWizard ;
      private bool Z122WWPFormInstantiated ;
      private bool Z292WWPFormIsForDynamicValidations ;
      private bool Z126WWPFormElementExcludeFromExport ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n99WWPFormElementParentId ;
      private bool wbErr ;
      private bool A120WWPFormIsWizard ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_53_Refreshing=false ;
      private bool A122WWPFormInstantiated ;
      private bool A292WWPFormIsForDynamicValidations ;
      private bool A126WWPFormElementExcludeFromExport ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A123WWPFormResumeMessage ;
      private string A121WWPFormValidations ;
      private string A117WWPFormElementTitle ;
      private string A116WWPFormElementParentName ;
      private string A124WWPFormElementMetadata ;
      private string Z123WWPFormResumeMessage ;
      private string Z121WWPFormValidations ;
      private string Z117WWPFormElementTitle ;
      private string Z124WWPFormElementMetadata ;
      private string Z116WWPFormElementParentName ;
      private string Z96WWPFormReferenceName ;
      private string Z97WWPFormTitle ;
      private string Z291WWPFormSectionRefElements ;
      private string Z101WWPFormElementReferenceId ;
      private string A96WWPFormReferenceName ;
      private string A97WWPFormTitle ;
      private string A291WWPFormSectionRefElements ;
      private string A101WWPFormElementReferenceId ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_elementContainer ;
      private GXWebRow Gridlevel_elementRow ;
      private GXWebColumn Gridlevel_elementColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPFormIsWizard ;
      private GXCombobox cmbWWPFormElementType ;
      private GXCombobox cmbWWPFormElementDataType ;
      private GXCombobox cmbWWPFormElementParentType ;
      private GXCombobox cmbWWPFormElementCaption ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T000C7_A94WWPFormId ;
      private short[] T000C7_A95WWPFormVersionNumber ;
      private string[] T000C7_A96WWPFormReferenceName ;
      private string[] T000C7_A97WWPFormTitle ;
      private DateTime[] T000C7_A119WWPFormDate ;
      private bool[] T000C7_A120WWPFormIsWizard ;
      private short[] T000C7_A104WWPFormResume ;
      private string[] T000C7_A123WWPFormResumeMessage ;
      private string[] T000C7_A121WWPFormValidations ;
      private bool[] T000C7_A122WWPFormInstantiated ;
      private short[] T000C7_A290WWPFormType ;
      private string[] T000C7_A291WWPFormSectionRefElements ;
      private bool[] T000C7_A292WWPFormIsForDynamicValidations ;
      private short[] T000C8_A94WWPFormId ;
      private short[] T000C8_A95WWPFormVersionNumber ;
      private short[] T000C6_A94WWPFormId ;
      private short[] T000C6_A95WWPFormVersionNumber ;
      private string[] T000C6_A96WWPFormReferenceName ;
      private string[] T000C6_A97WWPFormTitle ;
      private DateTime[] T000C6_A119WWPFormDate ;
      private bool[] T000C6_A120WWPFormIsWizard ;
      private short[] T000C6_A104WWPFormResume ;
      private string[] T000C6_A123WWPFormResumeMessage ;
      private string[] T000C6_A121WWPFormValidations ;
      private bool[] T000C6_A122WWPFormInstantiated ;
      private short[] T000C6_A290WWPFormType ;
      private string[] T000C6_A291WWPFormSectionRefElements ;
      private bool[] T000C6_A292WWPFormIsForDynamicValidations ;
      private short[] T000C9_A94WWPFormId ;
      private short[] T000C9_A95WWPFormVersionNumber ;
      private short[] T000C10_A94WWPFormId ;
      private short[] T000C10_A95WWPFormVersionNumber ;
      private short[] T000C5_A94WWPFormId ;
      private short[] T000C5_A95WWPFormVersionNumber ;
      private string[] T000C5_A96WWPFormReferenceName ;
      private string[] T000C5_A97WWPFormTitle ;
      private DateTime[] T000C5_A119WWPFormDate ;
      private bool[] T000C5_A120WWPFormIsWizard ;
      private short[] T000C5_A104WWPFormResume ;
      private string[] T000C5_A123WWPFormResumeMessage ;
      private string[] T000C5_A121WWPFormValidations ;
      private bool[] T000C5_A122WWPFormInstantiated ;
      private short[] T000C5_A290WWPFormType ;
      private string[] T000C5_A291WWPFormSectionRefElements ;
      private bool[] T000C5_A292WWPFormIsForDynamicValidations ;
      private int[] T000C14_A102WWPFormInstanceId ;
      private short[] T000C15_A94WWPFormId ;
      private short[] T000C15_A95WWPFormVersionNumber ;
      private short[] T000C15_A99WWPFormElementParentId ;
      private bool[] T000C15_n99WWPFormElementParentId ;
      private short[] T000C16_A94WWPFormId ;
      private short[] T000C16_A95WWPFormVersionNumber ;
      private short[] T000C17_A98WWPFormElementId ;
      private short[] T000C17_A125WWPFormElementCaption ;
      private string[] T000C17_A117WWPFormElementTitle ;
      private short[] T000C17_A105WWPFormElementType ;
      private short[] T000C17_A100WWPFormElementOrderIndex ;
      private short[] T000C17_A106WWPFormElementDataType ;
      private string[] T000C17_A116WWPFormElementParentName ;
      private short[] T000C17_A118WWPFormElementParentType ;
      private string[] T000C17_A124WWPFormElementMetadata ;
      private string[] T000C17_A101WWPFormElementReferenceId ;
      private bool[] T000C17_A126WWPFormElementExcludeFromExport ;
      private short[] T000C17_A94WWPFormId ;
      private short[] T000C17_A95WWPFormVersionNumber ;
      private short[] T000C17_A99WWPFormElementParentId ;
      private bool[] T000C17_n99WWPFormElementParentId ;
      private string[] T000C4_A116WWPFormElementParentName ;
      private short[] T000C4_A118WWPFormElementParentType ;
      private string[] T000C18_A116WWPFormElementParentName ;
      private short[] T000C18_A118WWPFormElementParentType ;
      private short[] T000C19_A94WWPFormId ;
      private short[] T000C19_A95WWPFormVersionNumber ;
      private short[] T000C19_A98WWPFormElementId ;
      private short[] T000C3_A98WWPFormElementId ;
      private short[] T000C3_A125WWPFormElementCaption ;
      private string[] T000C3_A117WWPFormElementTitle ;
      private short[] T000C3_A105WWPFormElementType ;
      private short[] T000C3_A100WWPFormElementOrderIndex ;
      private short[] T000C3_A106WWPFormElementDataType ;
      private string[] T000C3_A124WWPFormElementMetadata ;
      private string[] T000C3_A101WWPFormElementReferenceId ;
      private bool[] T000C3_A126WWPFormElementExcludeFromExport ;
      private short[] T000C3_A94WWPFormId ;
      private short[] T000C3_A95WWPFormVersionNumber ;
      private short[] T000C3_A99WWPFormElementParentId ;
      private bool[] T000C3_n99WWPFormElementParentId ;
      private short[] T000C2_A98WWPFormElementId ;
      private short[] T000C2_A125WWPFormElementCaption ;
      private string[] T000C2_A117WWPFormElementTitle ;
      private short[] T000C2_A105WWPFormElementType ;
      private short[] T000C2_A100WWPFormElementOrderIndex ;
      private short[] T000C2_A106WWPFormElementDataType ;
      private string[] T000C2_A124WWPFormElementMetadata ;
      private string[] T000C2_A101WWPFormElementReferenceId ;
      private bool[] T000C2_A126WWPFormElementExcludeFromExport ;
      private short[] T000C2_A94WWPFormId ;
      private short[] T000C2_A95WWPFormVersionNumber ;
      private short[] T000C2_A99WWPFormElementParentId ;
      private bool[] T000C2_n99WWPFormElementParentId ;
      private string[] T000C23_A116WWPFormElementParentName ;
      private short[] T000C23_A118WWPFormElementParentType ;
      private short[] T000C24_A94WWPFormId ;
      private short[] T000C24_A95WWPFormVersionNumber ;
      private short[] T000C24_A99WWPFormElementParentId ;
      private bool[] T000C24_n99WWPFormElementParentId ;
      private short[] T000C25_A94WWPFormId ;
      private short[] T000C25_A95WWPFormVersionNumber ;
      private short[] T000C25_A98WWPFormElementId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_form__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000C2;
          prmT000C2 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmT000C3;
          prmT000C3 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmT000C4;
          prmT000C4 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000C5;
          prmT000C5 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000C6;
          prmT000C6 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000C7;
          prmT000C7 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000C8;
          prmT000C8 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000C9;
          prmT000C9 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000C10;
          prmT000C10 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000C11;
          prmT000C11 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("WWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("WWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("WWPFormIsWizard",GXType.Boolean,4,0) ,
          new ParDef("WWPFormResume",GXType.Int16,1,0) ,
          new ParDef("WWPFormResumeMessage",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormValidations",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormInstantiated",GXType.Boolean,4,0) ,
          new ParDef("WWPFormType",GXType.Int16,1,0) ,
          new ParDef("WWPFormSectionRefElements",GXType.VarChar,400,0) ,
          new ParDef("WWPFormIsForDynamicValidations",GXType.Boolean,4,0)
          };
          Object[] prmT000C12;
          prmT000C12 = new Object[] {
          new ParDef("WWPFormReferenceName",GXType.VarChar,100,0) ,
          new ParDef("WWPFormTitle",GXType.VarChar,100,0) ,
          new ParDef("WWPFormDate",GXType.DateTime,8,5) ,
          new ParDef("WWPFormIsWizard",GXType.Boolean,4,0) ,
          new ParDef("WWPFormResume",GXType.Int16,1,0) ,
          new ParDef("WWPFormResumeMessage",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormValidations",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormInstantiated",GXType.Boolean,4,0) ,
          new ParDef("WWPFormType",GXType.Int16,1,0) ,
          new ParDef("WWPFormSectionRefElements",GXType.VarChar,400,0) ,
          new ParDef("WWPFormIsForDynamicValidations",GXType.Boolean,4,0) ,
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000C13;
          prmT000C13 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000C14;
          prmT000C14 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000C15;
          prmT000C15 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000C16;
          prmT000C16 = new Object[] {
          };
          Object[] prmT000C17;
          prmT000C17 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmT000C18;
          prmT000C18 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000C19;
          prmT000C19 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmT000C20;
          prmT000C20 = new Object[] {
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementCaption",GXType.Int16,1,0) ,
          new ParDef("WWPFormElementTitle",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormElementType",GXType.Int16,1,0) ,
          new ParDef("WWPFormElementOrderIndex",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementDataType",GXType.Int16,2,0) ,
          new ParDef("WWPFormElementMetadata",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormElementReferenceId",GXType.VarChar,100,0) ,
          new ParDef("WWPFormElementExcludeFromExport",GXType.Boolean,4,0) ,
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000C21;
          prmT000C21 = new Object[] {
          new ParDef("WWPFormElementCaption",GXType.Int16,1,0) ,
          new ParDef("WWPFormElementTitle",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormElementType",GXType.Int16,1,0) ,
          new ParDef("WWPFormElementOrderIndex",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementDataType",GXType.Int16,2,0) ,
          new ParDef("WWPFormElementMetadata",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPFormElementReferenceId",GXType.VarChar,100,0) ,
          new ParDef("WWPFormElementExcludeFromExport",GXType.Boolean,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmT000C22;
          prmT000C22 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmT000C23;
          prmT000C23 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000C24;
          prmT000C24 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmT000C25;
          prmT000C25 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000C2", "SELECT WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExport, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId  FOR UPDATE OF WWP_FormElement NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C3", "SELECT WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExport, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C4", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C5", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber  FOR UPDATE OF WWP_Form NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C6", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C7", "SELECT TM1.WWPFormId, TM1.WWPFormVersionNumber, TM1.WWPFormReferenceName, TM1.WWPFormTitle, TM1.WWPFormDate, TM1.WWPFormIsWizard, TM1.WWPFormResume, TM1.WWPFormResumeMessage, TM1.WWPFormValidations, TM1.WWPFormInstantiated, TM1.WWPFormType, TM1.WWPFormSectionRefElements, TM1.WWPFormIsForDynamicValidations FROM WWP_Form TM1 WHERE TM1.WWPFormId = :WWPFormId and TM1.WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY TM1.WWPFormId, TM1.WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C8", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C9", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE ( WWPFormId > :WWPFormId or WWPFormId = :WWPFormId and WWPFormVersionNumber > :WWPFormVersionNumber) ORDER BY WWPFormId, WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C10", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE ( WWPFormId < :WWPFormId or WWPFormId = :WWPFormId and WWPFormVersionNumber < :WWPFormVersionNumber) ORDER BY WWPFormId DESC, WWPFormVersionNumber DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C11", "SAVEPOINT gxupdate;INSERT INTO WWP_Form(WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations) VALUES(:WWPFormId, :WWPFormVersionNumber, :WWPFormReferenceName, :WWPFormTitle, :WWPFormDate, :WWPFormIsWizard, :WWPFormResume, :WWPFormResumeMessage, :WWPFormValidations, :WWPFormInstantiated, :WWPFormType, :WWPFormSectionRefElements, :WWPFormIsForDynamicValidations);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000C11)
             ,new CursorDef("T000C12", "SAVEPOINT gxupdate;UPDATE WWP_Form SET WWPFormReferenceName=:WWPFormReferenceName, WWPFormTitle=:WWPFormTitle, WWPFormDate=:WWPFormDate, WWPFormIsWizard=:WWPFormIsWizard, WWPFormResume=:WWPFormResume, WWPFormResumeMessage=:WWPFormResumeMessage, WWPFormValidations=:WWPFormValidations, WWPFormInstantiated=:WWPFormInstantiated, WWPFormType=:WWPFormType, WWPFormSectionRefElements=:WWPFormSectionRefElements, WWPFormIsForDynamicValidations=:WWPFormIsForDynamicValidations  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C12)
             ,new CursorDef("T000C13", "SAVEPOINT gxupdate;DELETE FROM WWP_Form  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C13)
             ,new CursorDef("T000C14", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C15", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId AS WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C16", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form ORDER BY WWPFormId, WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C16,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C17", "SELECT T1.WWPFormElementId, T1.WWPFormElementCaption, T1.WWPFormElementTitle, T1.WWPFormElementType, T1.WWPFormElementOrderIndex, T1.WWPFormElementDataType, T2.WWPFormElementTitle AS WWPFormElementParentName, T2.WWPFormElementType AS WWPFormElementParentType, T1.WWPFormElementMetadata, T1.WWPFormElementReferenceId, T1.WWPFormElementExcludeFromExport, T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementParentId AS WWPFormElementParentId FROM (WWP_FormElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementParentId) WHERE T1.WWPFormId = :WWPFormId and T1.WWPFormVersionNumber = :WWPFormVersionNumber and T1.WWPFormElementId = :WWPFormElementId ORDER BY T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C17,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C18", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C19", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C20", "SAVEPOINT gxupdate;INSERT INTO WWP_FormElement(WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExport, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId) VALUES(:WWPFormElementId, :WWPFormElementCaption, :WWPFormElementTitle, :WWPFormElementType, :WWPFormElementOrderIndex, :WWPFormElementDataType, :WWPFormElementMetadata, :WWPFormElementReferenceId, :WWPFormElementExcludeFromExport, :WWPFormId, :WWPFormVersionNumber, :WWPFormElementParentId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000C20)
             ,new CursorDef("T000C21", "SAVEPOINT gxupdate;UPDATE WWP_FormElement SET WWPFormElementCaption=:WWPFormElementCaption, WWPFormElementTitle=:WWPFormElementTitle, WWPFormElementType=:WWPFormElementType, WWPFormElementOrderIndex=:WWPFormElementOrderIndex, WWPFormElementDataType=:WWPFormElementDataType, WWPFormElementMetadata=:WWPFormElementMetadata, WWPFormElementReferenceId=:WWPFormElementReferenceId, WWPFormElementExcludeFromExport=:WWPFormElementExcludeFromExport, WWPFormElementParentId=:WWPFormElementParentId  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C21)
             ,new CursorDef("T000C22", "SAVEPOINT gxupdate;DELETE FROM WWP_FormElement  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C22)
             ,new CursorDef("T000C23", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C24", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId AS WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementParentId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C24,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C25", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId and WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C25,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((bool[]) buf[10])[0] = rslt.getBool(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((bool[]) buf[14])[0] = rslt.wasNull(14);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
