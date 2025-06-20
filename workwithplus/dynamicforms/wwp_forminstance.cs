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
   public class wwp_forminstance : GXWebComponent
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
               AV7WWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV7WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV7WWPFormInstanceId), 6, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV7WWPFormInstanceId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
            {
               A94WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
               A95WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_13( A94WWPFormId, A95WWPFormVersionNumber) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
            {
               A94WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
               A95WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
               A98WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_15( A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId) ;
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_forminstance")), "workwithplus.dynamicforms.wwp_forminstance") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_forminstance")))) ;
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
            Form.Meta.addItem("description", "WWPForm Instance", 0) ;
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
            GX_FocusControl = edtWWPFormInstanceDate_Internalname;
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
         nRC_GXsfl_48 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_48"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_48_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_48_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_48_idx = GetPar( "sGXsfl_48_idx");
         sPrefix = GetPar( "sPrefix");
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

      public wwp_forminstance( )
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

      public wwp_forminstance( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_WWPFormInstanceId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7WWPFormInstanceId = aP1_WWPFormInstanceId;
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
         cmbWWPFormElementDataType = new GXCombobox();
         chkWWPFormInstanceElemBoolean = new GXCheckbox();
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
            RenderHtmlCloseForm0D15( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_forminstance");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormInstanceId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormInstanceId_Internalname, "Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormInstanceId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A102WWPFormInstanceId), 6, 0, ",", "")), StringUtil.LTrim( ((edtWWPFormInstanceId_Enabled!=0) ? context.localUtil.Format( (decimal)(A102WWPFormInstanceId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A102WWPFormInstanceId), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormInstanceId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWWPFormInstanceId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormInstanceDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormInstanceDate_Internalname, "Date", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A127WWPFormInstanceDate", context.localUtil.Format(A127WWPFormInstanceDate, "99/99/99"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPFormInstanceDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPFormInstanceDate_Internalname, context.localUtil.Format(A127WWPFormInstanceDate, "99/99/99"), context.localUtil.Format( A127WWPFormInstanceDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,27);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormInstanceDate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWWPFormInstanceDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         GxWebStd.gx_bitmap( context, edtWWPFormInstanceDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPFormInstanceDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormId_Internalname, "WWPForm Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A94WWPFormId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A94WWPFormId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWWPFormId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
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
         GxWebStd.gx_label_element( context, edtWWPFormVersionNumber_Internalname, "WWPForm Version Number", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormVersionNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A95WWPFormVersionNumber), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A95WWPFormVersionNumber), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,37);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormVersionNumber_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWWPFormVersionNumber_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
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
         GxWebStd.gx_label_element( context, edtWWPFormTitle_Internalname, "WWPForm Title", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormTitle_Internalname, A97WWPFormTitle, StringUtil.RTrim( context.localUtil.Format( A97WWPFormTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormTitle_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWWPFormTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_FormInstance.htm");
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
         StartGridControl48( ) ;
         nGXsfl_48_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount16 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_16 = 1;
               ScanStart0D16( ) ;
               while ( RcdFound16 != 0 )
               {
                  init_level_properties16( ) ;
                  getByPrimaryKey0D16( ) ;
                  AddRow0D16( ) ;
                  ScanNext0D16( ) ;
               }
               ScanEnd0D16( ) ;
               nBlankRcdCount16 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0D16( ) ;
            standaloneModal0D16( ) ;
            sMode16 = Gx_mode;
            while ( nGXsfl_48_idx < nRC_GXsfl_48 )
            {
               bGXsfl_48_Refreshing = true;
               ReadRow0D16( ) ;
               edtWWPFormElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtWWPFormInstanceElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtWWPFormElementTitle_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               cmbWWPFormElementDataType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtWWPFormInstanceElemChar_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemChar_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtWWPFormInstanceElemDate_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemDate_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtWWPFormInstanceElemNumeric_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemNumeric_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemNumeric_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtWWPFormInstanceElemBlob_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemBlob_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               chkWWPFormInstanceElemBoolean.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, chkWWPFormInstanceElemBoolean_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormInstanceElemBoolean.Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtWWPFormElementReferenceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementReferenceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtWWPFormElementParentId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormElementParentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtWWPFormInstanceElemDateTime_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemDateTime_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtWWPFormInstanceElemBlobFileName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAME_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemBlobFileName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemBlobFileName_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtWWPFormInstanceElemBlobFileType_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYPE_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp(sPrefix, false, edtWWPFormInstanceElemBlobFileType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemBlobFileType_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               if ( ( nRcdExists_16 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  standaloneModal0D16( ) ;
               }
               SendRow0D16( ) ;
               bGXsfl_48_Refreshing = false;
            }
            Gx_mode = sMode16;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount16 = 5;
            nRcdExists_16 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0D16( ) ;
               while ( RcdFound16 != 0 )
               {
                  sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_4816( ) ;
                  init_level_properties16( ) ;
                  standaloneNotModal0D16( ) ;
                  getByPrimaryKey0D16( ) ;
                  standaloneModal0D16( ) ;
                  AddRow0D16( ) ;
                  ScanNext0D16( ) ;
               }
               ScanEnd0D16( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode16 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx+1), 4, 0), 4, "0");
            SubsflControlProps_4816( ) ;
            InitAll0D16( ) ;
            init_level_properties16( ) ;
            nRcdExists_16 = 0;
            nIsMod_16 = 0;
            nRcdDeleted_16 = 0;
            nBlankRcdCount16 = (short)(nBlankRcdUsr16+nBlankRcdCount16);
            fRowAdded = 0;
            while ( nBlankRcdCount16 > 0 )
            {
               standaloneNotModal0D16( ) ;
               standaloneModal0D16( ) ;
               AddRow0D16( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtWWPFormElementId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount16 = (short)(nBlankRcdCount16-1);
            }
            Gx_mode = sMode16;
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
         E110D2 ();
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
               Z102WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z102WWPFormInstanceId"), ",", "."), 18, MidpointRounding.ToEven));
               Z127WWPFormInstanceDate = context.localUtil.CToD( cgiGet( sPrefix+"Z127WWPFormInstanceDate"), 0);
               Z94WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z94WWPFormId"), ",", "."), 18, MidpointRounding.ToEven));
               Z95WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"Z95WWPFormVersionNumber"), ",", "."), 18, MidpointRounding.ToEven));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPFormInstanceId"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( sPrefix+"Mode");
               nRC_GXsfl_48 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_48"), ",", "."), 18, MidpointRounding.ToEven));
               N94WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"N94WWPFormId"), ",", "."), 18, MidpointRounding.ToEven));
               N95WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"N95WWPFormVersionNumber"), ",", "."), 18, MidpointRounding.ToEven));
               AV7WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vWWPFORMINSTANCEID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_WWPFORMID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV11Insert_WWPFormId", StringUtil.LTrimStr( (decimal)(AV11Insert_WWPFormId), 4, 0));
               AV12Insert_WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_WWPFORMVERSIONNUMBER"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV12Insert_WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV12Insert_WWPFormVersionNumber), 4, 0));
               Gx_date = context.localUtil.CToD( cgiGet( sPrefix+"vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A293WWPFormInstanceRecordKey = cgiGet( sPrefix+"WWPFORMINSTANCERECORDKEY");
               n293WWPFormInstanceRecordKey = false;
               n293WWPFormInstanceRecordKey = (String.IsNullOrEmpty(StringUtil.RTrim( A293WWPFormInstanceRecordKey)) ? true : false);
               A104WWPFormResume = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMRESUME"), ",", "."), 18, MidpointRounding.ToEven));
               A121WWPFormValidations = cgiGet( sPrefix+"WWPFORMVALIDATIONS");
               AV16Pgmname = cgiGet( sPrefix+"vPGMNAME");
               A105WWPFormElementType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTYPE"), ",", "."), 18, MidpointRounding.ToEven));
               A124WWPFormElementMetadata = cgiGet( sPrefix+"WWPFORMELEMENTMETADATA");
               A125WWPFormElementCaption = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTCAPTION"), ",", "."), 18, MidpointRounding.ToEven));
               A118WWPFormElementParentType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTTYPE"), ",", "."), 18, MidpointRounding.ToEven));
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
               A102WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormInstanceId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
               if ( context.localUtil.VCDate( cgiGet( edtWWPFormInstanceDate_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Instance Date"}), 1, "WWPFORMINSTANCEDATE");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormInstanceDate_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A127WWPFormInstanceDate = DateTime.MinValue;
                  AssignAttri(sPrefix, false, "A127WWPFormInstanceDate", context.localUtil.Format(A127WWPFormInstanceDate, "99/99/99"));
               }
               else
               {
                  A127WWPFormInstanceDate = context.localUtil.CToD( cgiGet( edtWWPFormInstanceDate_Internalname), 2);
                  AssignAttri(sPrefix, false, "A127WWPFormInstanceDate", context.localUtil.Format(A127WWPFormInstanceDate, "99/99/99"));
               }
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
               A97WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
               AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WWP_FormInstance");
               forbiddenHiddens.Add("Insert_WWPFormId", context.localUtil.Format( (decimal)(AV11Insert_WWPFormId), "ZZZ9"));
               forbiddenHiddens.Add("Insert_WWPFormVersionNumber", context.localUtil.Format( (decimal)(AV12Insert_WWPFormVersionNumber), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A102WWPFormInstanceId != Z102WWPFormInstanceId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("workwithplus\\dynamicforms\\wwp_forminstance:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A102WWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
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
                     sMode15 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode15;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound15 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0D0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "WWPFORMINSTANCEID");
                        AnyError = 1;
                        GX_FocusControl = edtWWPFormInstanceId_Internalname;
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
                                 E110D2 ();
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
                                 E120D2 ();
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
            E120D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0D15( ) ;
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
            DisableAttributes0D15( ) ;
         }
         AssignProp(sPrefix, false, edtWWPFormInstanceDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceDate_Enabled), 5, 0), true);
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D15( ) ;
            }
            else
            {
               CheckExtendedTable0D15( ) ;
               CloseExtendedTableCursors0D15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode15 = Gx_mode;
            CONFIRM_0D16( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode15;
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode15;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0D16( )
      {
         nGXsfl_48_idx = 0;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            ReadRow0D16( ) ;
            if ( ( nRcdExists_16 != 0 ) || ( nIsMod_16 != 0 ) )
            {
               GetKey0D16( ) ;
               if ( ( nRcdExists_16 == 0 ) && ( nRcdDeleted_16 == 0 ) )
               {
                  if ( RcdFound16 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     BeforeValidate0D16( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0D16( ) ;
                        CloseExtendedTableCursors0D16( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_48_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtWWPFormElementId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound16 != 0 )
                  {
                     if ( nRcdDeleted_16 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0D16( ) ;
                        Load0D16( ) ;
                        BeforeValidate0D16( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0D16( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_16 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                           BeforeValidate0D16( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0D16( ) ;
                              CloseExtendedTableCursors0D16( ) ;
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
                     if ( nRcdDeleted_16 == 0 )
                     {
                        GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_48_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPFormElementId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( sPrefix+edtWWPFormElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A98WWPFormElementId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A103WWPFormInstanceElementId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementTitle_Internalname, A117WWPFormElementTitle) ;
            ChangePostValue( sPrefix+cmbWWPFormElementDataType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106WWPFormElementDataType), 2, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemChar_Internalname, A109WWPFormInstanceElemChar) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemDate_Internalname, context.localUtil.Format(A108WWPFormInstanceElemDate, "99/99/99")) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemNumeric_Internalname, StringUtil.LTrim( StringUtil.NToC( A110WWPFormInstanceElemNumeric, 21, 5, ",", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemBlob_Internalname, A111WWPFormInstanceElemBlob) ;
            ChangePostValue( sPrefix+chkWWPFormInstanceElemBoolean_Internalname, StringUtil.BoolToStr( A114WWPFormInstanceElemBoolean)) ;
            ChangePostValue( sPrefix+edtWWPFormElementReferenceId_Internalname, A101WWPFormElementReferenceId) ;
            ChangePostValue( sPrefix+edtWWPFormElementParentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A99WWPFormElementParentId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemDateTime_Internalname, context.localUtil.TToC( A115WWPFormInstanceElemDateTime, 10, 8, 0, 3, "/", ":", " ")) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemBlobFileName_Internalname, A113WWPFormInstanceElemBlobFileName) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemBlobFileType_Internalname, A112WWPFormInstanceElemBlobFileType) ;
            ChangePostValue( sPrefix+"ZT_"+"Z98WWPFormElementId_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98WWPFormElementId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z103WWPFormInstanceElementId_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z103WWPFormInstanceElementId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z108WWPFormInstanceElemDate_"+sGXsfl_48_idx, context.localUtil.DToC( Z108WWPFormInstanceElemDate, 0, "/")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z115WWPFormInstanceElemDateTime_"+sGXsfl_48_idx, context.localUtil.TToC( Z115WWPFormInstanceElemDateTime, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z110WWPFormInstanceElemNumeric_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( Z110WWPFormInstanceElemNumeric, 18, 5, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z114WWPFormInstanceElemBoolean_"+sGXsfl_48_idx, StringUtil.BoolToStr( Z114WWPFormInstanceElemBoolean)) ;
            ChangePostValue( sPrefix+"nRcdDeleted_16_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_16), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nRcdExists_16_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_16), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nIsMod_16_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_16), 4, 0, ",", ""))) ;
            if ( nIsMod_16 != 0 )
            {
               ChangePostValue( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemChar_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDate_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemNumeric_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlob_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkWWPFormInstanceElemBoolean.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDateTime_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAME_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYPE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileType_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0D0( )
      {
      }

      protected void E110D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri(sPrefix, false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "WWPFormId") == 0 )
               {
                  AV11Insert_WWPFormId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV11Insert_WWPFormId", StringUtil.LTrimStr( (decimal)(AV11Insert_WWPFormId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "WWPFormVersionNumber") == 0 )
               {
                  AV12Insert_WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV12Insert_WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV12Insert_WWPFormVersionNumber), 4, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri(sPrefix, false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
      }

      protected void E120D2( )
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

      protected void ZM0D15( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z127WWPFormInstanceDate = T000D7_A127WWPFormInstanceDate[0];
               Z94WWPFormId = T000D7_A94WWPFormId[0];
               Z95WWPFormVersionNumber = T000D7_A95WWPFormVersionNumber[0];
            }
            else
            {
               Z127WWPFormInstanceDate = A127WWPFormInstanceDate;
               Z94WWPFormId = A94WWPFormId;
               Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            }
         }
         if ( GX_JID == -12 )
         {
            Z102WWPFormInstanceId = A102WWPFormInstanceId;
            Z127WWPFormInstanceDate = A127WWPFormInstanceDate;
            Z293WWPFormInstanceRecordKey = A293WWPFormInstanceRecordKey;
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            Z97WWPFormTitle = A97WWPFormTitle;
            Z104WWPFormResume = A104WWPFormResume;
            Z121WWPFormValidations = A121WWPFormValidations;
         }
      }

      protected void standaloneNotModal( )
      {
         edtWWPFormInstanceId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceId_Enabled), 5, 0), true);
         AV16Pgmname = "WorkWithPlus.DynamicForms.WWP_FormInstance";
         AssignAttri(sPrefix, false, "AV16Pgmname", AV16Pgmname);
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         edtWWPFormInstanceId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp(sPrefix, false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7WWPFormInstanceId) )
         {
            A102WWPFormInstanceId = AV7WWPFormInstanceId;
            AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_WWPFormId) )
         {
            edtWWPFormId_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         }
         else
         {
            edtWWPFormId_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_WWPFormVersionNumber) )
         {
            edtWWPFormVersionNumber_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         }
         else
         {
            edtWWPFormVersionNumber_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_WWPFormVersionNumber) )
         {
            A95WWPFormVersionNumber = AV12Insert_WWPFormVersionNumber;
            AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_WWPFormId) )
         {
            A94WWPFormId = AV11Insert_WWPFormId;
            AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
         }
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
         if ( IsIns( )  && (DateTime.MinValue==A127WWPFormInstanceDate) && ( Gx_BScreen == 0 ) )
         {
            A127WWPFormInstanceDate = Gx_date;
            AssignAttri(sPrefix, false, "A127WWPFormInstanceDate", context.localUtil.Format(A127WWPFormInstanceDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000D8 */
            pr_default.execute(6, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
            A97WWPFormTitle = T000D8_A97WWPFormTitle[0];
            AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
            A104WWPFormResume = T000D8_A104WWPFormResume[0];
            A121WWPFormValidations = T000D8_A121WWPFormValidations[0];
            pr_default.close(6);
         }
      }

      protected void Load0D15( )
      {
         /* Using cursor T000D9 */
         pr_default.execute(7, new Object[] {A102WWPFormInstanceId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound15 = 1;
            A127WWPFormInstanceDate = T000D9_A127WWPFormInstanceDate[0];
            AssignAttri(sPrefix, false, "A127WWPFormInstanceDate", context.localUtil.Format(A127WWPFormInstanceDate, "99/99/99"));
            A97WWPFormTitle = T000D9_A97WWPFormTitle[0];
            AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
            A104WWPFormResume = T000D9_A104WWPFormResume[0];
            A121WWPFormValidations = T000D9_A121WWPFormValidations[0];
            A293WWPFormInstanceRecordKey = T000D9_A293WWPFormInstanceRecordKey[0];
            n293WWPFormInstanceRecordKey = T000D9_n293WWPFormInstanceRecordKey[0];
            A94WWPFormId = T000D9_A94WWPFormId[0];
            AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
            A95WWPFormVersionNumber = T000D9_A95WWPFormVersionNumber[0];
            AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
            ZM0D15( -12) ;
         }
         pr_default.close(7);
         OnLoadActions0D15( ) ;
      }

      protected void OnLoadActions0D15( )
      {
      }

      protected void CheckExtendedTable0D15( )
      {
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000D8 */
         pr_default.execute(6, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("N�o existe 'Dynamic Form'.", "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A97WWPFormTitle = T000D8_A97WWPFormTitle[0];
         AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
         A104WWPFormResume = T000D8_A104WWPFormResume[0];
         A121WWPFormValidations = T000D8_A121WWPFormValidations[0];
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors0D15( )
      {
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( short A94WWPFormId ,
                                short A95WWPFormVersionNumber )
      {
         /* Using cursor T000D10 */
         pr_default.execute(8, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("N�o existe 'Dynamic Form'.", "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A97WWPFormTitle = T000D10_A97WWPFormTitle[0];
         AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
         A104WWPFormResume = T000D10_A104WWPFormResume[0];
         A121WWPFormValidations = T000D10_A121WWPFormValidations[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A97WWPFormTitle)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A104WWPFormResume), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A121WWPFormValidations)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0D15( )
      {
         /* Using cursor T000D11 */
         pr_default.execute(9, new Object[] {A102WWPFormInstanceId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000D7 */
         pr_default.execute(5, new Object[] {A102WWPFormInstanceId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0D15( 12) ;
            RcdFound15 = 1;
            A102WWPFormInstanceId = T000D7_A102WWPFormInstanceId[0];
            AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
            A127WWPFormInstanceDate = T000D7_A127WWPFormInstanceDate[0];
            AssignAttri(sPrefix, false, "A127WWPFormInstanceDate", context.localUtil.Format(A127WWPFormInstanceDate, "99/99/99"));
            A293WWPFormInstanceRecordKey = T000D7_A293WWPFormInstanceRecordKey[0];
            n293WWPFormInstanceRecordKey = T000D7_n293WWPFormInstanceRecordKey[0];
            A94WWPFormId = T000D7_A94WWPFormId[0];
            AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
            A95WWPFormVersionNumber = T000D7_A95WWPFormVersionNumber[0];
            AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
            Z102WWPFormInstanceId = A102WWPFormInstanceId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0D15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0D15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0D15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D15( ) ;
         if ( RcdFound15 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound15 = 0;
         /* Using cursor T000D12 */
         pr_default.execute(10, new Object[] {A102WWPFormInstanceId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000D12_A102WWPFormInstanceId[0] < A102WWPFormInstanceId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000D12_A102WWPFormInstanceId[0] > A102WWPFormInstanceId ) ) )
            {
               A102WWPFormInstanceId = T000D12_A102WWPFormInstanceId[0];
               AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000D13 */
         pr_default.execute(11, new Object[] {A102WWPFormInstanceId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000D13_A102WWPFormInstanceId[0] > A102WWPFormInstanceId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000D13_A102WWPFormInstanceId[0] < A102WWPFormInstanceId ) ) )
            {
               A102WWPFormInstanceId = T000D13_A102WWPFormInstanceId[0];
               AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0D15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPFormInstanceDate_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0D15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A102WWPFormInstanceId != Z102WWPFormInstanceId )
               {
                  A102WWPFormInstanceId = Z102WWPFormInstanceId;
                  AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPFORMINSTANCEID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPFormInstanceId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPFormInstanceDate_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0D15( ) ;
                  GX_FocusControl = edtWWPFormInstanceDate_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A102WWPFormInstanceId != Z102WWPFormInstanceId )
               {
                  /* Insert record */
                  GX_FocusControl = edtWWPFormInstanceDate_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0D15( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPFORMINSTANCEID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPFormInstanceId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtWWPFormInstanceDate_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0D15( ) ;
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
         if ( A102WWPFormInstanceId != Z102WWPFormInstanceId )
         {
            A102WWPFormInstanceId = Z102WWPFormInstanceId;
            AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPFORMINSTANCEID");
            AnyError = 1;
            GX_FocusControl = edtWWPFormInstanceId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPFormInstanceDate_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0D15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000D6 */
            pr_default.execute(4, new Object[] {A102WWPFormInstanceId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstance"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( DateTimeUtil.ResetTime ( Z127WWPFormInstanceDate ) != DateTimeUtil.ResetTime ( T000D6_A127WWPFormInstanceDate[0] ) ) || ( Z94WWPFormId != T000D6_A94WWPFormId[0] ) || ( Z95WWPFormVersionNumber != T000D6_A95WWPFormVersionNumber[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z127WWPFormInstanceDate ) != DateTimeUtil.ResetTime ( T000D6_A127WWPFormInstanceDate[0] ) )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormInstanceDate");
                  GXUtil.WriteLogRaw("Old: ",Z127WWPFormInstanceDate);
                  GXUtil.WriteLogRaw("Current: ",T000D6_A127WWPFormInstanceDate[0]);
               }
               if ( Z94WWPFormId != T000D6_A94WWPFormId[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormId");
                  GXUtil.WriteLogRaw("Old: ",Z94WWPFormId);
                  GXUtil.WriteLogRaw("Current: ",T000D6_A94WWPFormId[0]);
               }
               if ( Z95WWPFormVersionNumber != T000D6_A95WWPFormVersionNumber[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormVersionNumber");
                  GXUtil.WriteLogRaw("Old: ",Z95WWPFormVersionNumber);
                  GXUtil.WriteLogRaw("Current: ",T000D6_A95WWPFormVersionNumber[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormInstance"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D15( )
      {
         BeforeValidate0D15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D15( 0) ;
            CheckOptimisticConcurrency0D15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D14 */
                     pr_default.execute(12, new Object[] {A127WWPFormInstanceDate, n293WWPFormInstanceRecordKey, A293WWPFormInstanceRecordKey, A94WWPFormId, A95WWPFormVersionNumber});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000D15 */
                     pr_default.execute(13);
                     A102WWPFormInstanceId = T000D15_A102WWPFormInstanceId[0];
                     AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0D15( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0D0( ) ;
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
               Load0D15( ) ;
            }
            EndLevel0D15( ) ;
         }
         CloseExtendedTableCursors0D15( ) ;
      }

      protected void Update0D15( )
      {
         BeforeValidate0D15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D16 */
                     pr_default.execute(14, new Object[] {A127WWPFormInstanceDate, n293WWPFormInstanceRecordKey, A293WWPFormInstanceRecordKey, A94WWPFormId, A95WWPFormVersionNumber, A102WWPFormInstanceId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstance"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0D15( ) ;
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
            EndLevel0D15( ) ;
         }
         CloseExtendedTableCursors0D15( ) ;
      }

      protected void DeferredUpdate0D15( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0D15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D15( ) ;
            AfterConfirm0D15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D15( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0D16( ) ;
                  while ( RcdFound16 != 0 )
                  {
                     getByPrimaryKey0D16( ) ;
                     Delete0D16( ) ;
                     ScanNext0D16( ) ;
                  }
                  ScanEnd0D16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D17 */
                     pr_default.execute(15, new Object[] {A102WWPFormInstanceId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0D15( ) ;
         Gx_mode = sMode15;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0D15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000D18 */
            pr_default.execute(16, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
            A97WWPFormTitle = T000D18_A97WWPFormTitle[0];
            AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
            A104WWPFormResume = T000D18_A104WWPFormResume[0];
            A121WWPFormValidations = T000D18_A121WWPFormValidations[0];
            pr_default.close(16);
         }
      }

      protected void ProcessNestedLevel0D16( )
      {
         nGXsfl_48_idx = 0;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            ReadRow0D16( ) ;
            if ( ( nRcdExists_16 != 0 ) || ( nIsMod_16 != 0 ) )
            {
               standaloneNotModal0D16( ) ;
               GetKey0D16( ) ;
               if ( ( nRcdExists_16 == 0 ) && ( nRcdDeleted_16 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  Insert0D16( ) ;
               }
               else
               {
                  if ( RcdFound16 != 0 )
                  {
                     if ( ( nRcdDeleted_16 != 0 ) && ( nRcdExists_16 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        Delete0D16( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_16 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                           Update0D16( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_16 == 0 )
                     {
                        GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_48_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPFormElementId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( sPrefix+edtWWPFormElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A98WWPFormElementId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A103WWPFormInstanceElementId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormElementTitle_Internalname, A117WWPFormElementTitle) ;
            ChangePostValue( sPrefix+cmbWWPFormElementDataType_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106WWPFormElementDataType), 2, 0, ".", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemChar_Internalname, A109WWPFormInstanceElemChar) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemDate_Internalname, context.localUtil.Format(A108WWPFormInstanceElemDate, "99/99/99")) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemNumeric_Internalname, StringUtil.LTrim( StringUtil.NToC( A110WWPFormInstanceElemNumeric, 21, 5, ",", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemBlob_Internalname, A111WWPFormInstanceElemBlob) ;
            ChangePostValue( sPrefix+chkWWPFormInstanceElemBoolean_Internalname, StringUtil.BoolToStr( A114WWPFormInstanceElemBoolean)) ;
            ChangePostValue( sPrefix+edtWWPFormElementReferenceId_Internalname, A101WWPFormElementReferenceId) ;
            ChangePostValue( sPrefix+edtWWPFormElementParentId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A99WWPFormElementParentId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemDateTime_Internalname, context.localUtil.TToC( A115WWPFormInstanceElemDateTime, 10, 8, 0, 3, "/", ":", " ")) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemBlobFileName_Internalname, A113WWPFormInstanceElemBlobFileName) ;
            ChangePostValue( sPrefix+edtWWPFormInstanceElemBlobFileType_Internalname, A112WWPFormInstanceElemBlobFileType) ;
            ChangePostValue( sPrefix+"ZT_"+"Z98WWPFormElementId_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98WWPFormElementId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z103WWPFormInstanceElementId_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z103WWPFormInstanceElementId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z108WWPFormInstanceElemDate_"+sGXsfl_48_idx, context.localUtil.DToC( Z108WWPFormInstanceElemDate, 0, "/")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z115WWPFormInstanceElemDateTime_"+sGXsfl_48_idx, context.localUtil.TToC( Z115WWPFormInstanceElemDateTime, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z110WWPFormInstanceElemNumeric_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( Z110WWPFormInstanceElemNumeric, 18, 5, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z114WWPFormInstanceElemBoolean_"+sGXsfl_48_idx, StringUtil.BoolToStr( Z114WWPFormInstanceElemBoolean)) ;
            ChangePostValue( sPrefix+"nRcdDeleted_16_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_16), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nRcdExists_16_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_16), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nIsMod_16_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_16), 4, 0, ",", ""))) ;
            if ( nIsMod_16 != 0 )
            {
               ChangePostValue( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemChar_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDate_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemNumeric_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlob_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkWWPFormInstanceElemBoolean.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDateTime_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAME_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYPE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileType_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0D16( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_16 = 0;
         nIsMod_16 = 0;
         nRcdDeleted_16 = 0;
      }

      protected void ProcessLevel0D15( )
      {
         /* Save parent mode. */
         sMode15 = Gx_mode;
         ProcessNestedLevel0D16( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode15;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0D15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D15( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues0D0( ) ;
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

      public void ScanStart0D15( )
      {
         /* Scan By routine */
         /* Using cursor T000D19 */
         pr_default.execute(17);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound15 = 1;
            A102WWPFormInstanceId = T000D19_A102WWPFormInstanceId[0];
            AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0D15( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound15 = 1;
            A102WWPFormInstanceId = T000D19_A102WWPFormInstanceId[0];
            AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
         }
      }

      protected void ScanEnd0D15( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0D15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D15( )
      {
         edtWWPFormInstanceId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceId_Enabled), 5, 0), true);
         edtWWPFormInstanceDate_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceDate_Enabled), 5, 0), true);
         edtWWPFormId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         edtWWPFormVersionNumber_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         edtWWPFormTitle_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Enabled), 5, 0), true);
      }

      protected void ZM0D16( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z108WWPFormInstanceElemDate = T000D3_A108WWPFormInstanceElemDate[0];
               Z115WWPFormInstanceElemDateTime = T000D3_A115WWPFormInstanceElemDateTime[0];
               Z110WWPFormInstanceElemNumeric = T000D3_A110WWPFormInstanceElemNumeric[0];
               Z114WWPFormInstanceElemBoolean = T000D3_A114WWPFormInstanceElemBoolean[0];
            }
            else
            {
               Z108WWPFormInstanceElemDate = A108WWPFormInstanceElemDate;
               Z115WWPFormInstanceElemDateTime = A115WWPFormInstanceElemDateTime;
               Z110WWPFormInstanceElemNumeric = A110WWPFormInstanceElemNumeric;
               Z114WWPFormInstanceElemBoolean = A114WWPFormInstanceElemBoolean;
            }
         }
         if ( GX_JID == -14 )
         {
            Z102WWPFormInstanceId = A102WWPFormInstanceId;
            Z103WWPFormInstanceElementId = A103WWPFormInstanceElementId;
            Z109WWPFormInstanceElemChar = A109WWPFormInstanceElemChar;
            Z108WWPFormInstanceElemDate = A108WWPFormInstanceElemDate;
            Z115WWPFormInstanceElemDateTime = A115WWPFormInstanceElemDateTime;
            Z110WWPFormInstanceElemNumeric = A110WWPFormInstanceElemNumeric;
            Z111WWPFormInstanceElemBlob = A111WWPFormInstanceElemBlob;
            Z114WWPFormInstanceElemBoolean = A114WWPFormInstanceElemBoolean;
            Z112WWPFormInstanceElemBlobFileType = A112WWPFormInstanceElemBlobFileType;
            Z113WWPFormInstanceElemBlobFileName = A113WWPFormInstanceElemBlobFileName;
            Z98WWPFormElementId = A98WWPFormElementId;
            Z94WWPFormId = A94WWPFormId;
            Z95WWPFormVersionNumber = A95WWPFormVersionNumber;
            Z117WWPFormElementTitle = A117WWPFormElementTitle;
            Z101WWPFormElementReferenceId = A101WWPFormElementReferenceId;
            Z106WWPFormElementDataType = A106WWPFormElementDataType;
            Z105WWPFormElementType = A105WWPFormElementType;
            Z124WWPFormElementMetadata = A124WWPFormElementMetadata;
            Z125WWPFormElementCaption = A125WWPFormElementCaption;
            Z99WWPFormElementParentId = A99WWPFormElementParentId;
            Z118WWPFormElementParentType = A118WWPFormElementParentType;
         }
      }

      protected void standaloneNotModal0D16( )
      {
      }

      protected void standaloneModal0D16( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtWWPFormElementId_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         }
         else
         {
            edtWWPFormElementId_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtWWPFormInstanceElementId_Enabled = 0;
            AssignProp(sPrefix, false, edtWWPFormInstanceElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         }
         else
         {
            edtWWPFormInstanceElementId_Enabled = 1;
            AssignProp(sPrefix, false, edtWWPFormInstanceElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         }
      }

      protected void Load0D16( )
      {
         /* Using cursor T000D20 */
         pr_default.execute(18, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A102WWPFormInstanceId, A103WWPFormInstanceElementId, A98WWPFormElementId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound16 = 1;
            A117WWPFormElementTitle = T000D20_A117WWPFormElementTitle[0];
            A101WWPFormElementReferenceId = T000D20_A101WWPFormElementReferenceId[0];
            A106WWPFormElementDataType = T000D20_A106WWPFormElementDataType[0];
            A118WWPFormElementParentType = T000D20_A118WWPFormElementParentType[0];
            A105WWPFormElementType = T000D20_A105WWPFormElementType[0];
            A124WWPFormElementMetadata = T000D20_A124WWPFormElementMetadata[0];
            A125WWPFormElementCaption = T000D20_A125WWPFormElementCaption[0];
            A109WWPFormInstanceElemChar = T000D20_A109WWPFormInstanceElemChar[0];
            n109WWPFormInstanceElemChar = T000D20_n109WWPFormInstanceElemChar[0];
            A108WWPFormInstanceElemDate = T000D20_A108WWPFormInstanceElemDate[0];
            n108WWPFormInstanceElemDate = T000D20_n108WWPFormInstanceElemDate[0];
            A115WWPFormInstanceElemDateTime = T000D20_A115WWPFormInstanceElemDateTime[0];
            n115WWPFormInstanceElemDateTime = T000D20_n115WWPFormInstanceElemDateTime[0];
            A110WWPFormInstanceElemNumeric = T000D20_A110WWPFormInstanceElemNumeric[0];
            n110WWPFormInstanceElemNumeric = T000D20_n110WWPFormInstanceElemNumeric[0];
            A114WWPFormInstanceElemBoolean = T000D20_A114WWPFormInstanceElemBoolean[0];
            n114WWPFormInstanceElemBoolean = T000D20_n114WWPFormInstanceElemBoolean[0];
            A112WWPFormInstanceElemBlobFileType = T000D20_A112WWPFormInstanceElemBlobFileType[0];
            edtWWPFormInstanceElemBlob_Filetype = A112WWPFormInstanceElemBlobFileType;
            AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Filetype", edtWWPFormInstanceElemBlob_Filetype, !bGXsfl_48_Refreshing);
            A113WWPFormInstanceElemBlobFileName = T000D20_A113WWPFormInstanceElemBlobFileName[0];
            edtWWPFormInstanceElemBlob_Filename = A113WWPFormInstanceElemBlobFileName;
            A99WWPFormElementParentId = T000D20_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = T000D20_n99WWPFormElementParentId[0];
            A111WWPFormInstanceElemBlob = T000D20_A111WWPFormInstanceElemBlob[0];
            n111WWPFormInstanceElemBlob = T000D20_n111WWPFormInstanceElemBlob[0];
            AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "URL", context.PathToRelativeUrl( A111WWPFormInstanceElemBlob), !bGXsfl_48_Refreshing);
            ZM0D16( -14) ;
         }
         pr_default.close(18);
         OnLoadActions0D16( ) ;
      }

      protected void OnLoadActions0D16( )
      {
      }

      protected void CheckExtendedTable0D16( )
      {
         nIsDirty_16 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0D16( ) ;
         /* Using cursor T000D4 */
         pr_default.execute(2, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_48_idx;
            GX_msglist.addItem("N�o existe 'Element'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A117WWPFormElementTitle = T000D4_A117WWPFormElementTitle[0];
         A101WWPFormElementReferenceId = T000D4_A101WWPFormElementReferenceId[0];
         A106WWPFormElementDataType = T000D4_A106WWPFormElementDataType[0];
         A105WWPFormElementType = T000D4_A105WWPFormElementType[0];
         A124WWPFormElementMetadata = T000D4_A124WWPFormElementMetadata[0];
         A125WWPFormElementCaption = T000D4_A125WWPFormElementCaption[0];
         A99WWPFormElementParentId = T000D4_A99WWPFormElementParentId[0];
         n99WWPFormElementParentId = T000D4_n99WWPFormElementParentId[0];
         pr_default.close(2);
         /* Using cursor T000D5 */
         pr_default.execute(3, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A94WWPFormId) || (0==A95WWPFormVersionNumber) || (0==A99WWPFormElementParentId) ) )
            {
               GXCCtl = "WWPFORMELEMENTPARENTID_" + sGXsfl_48_idx;
               GX_msglist.addItem("N�o existe 'WWPForm Element Parent'.", "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtWWPFormId_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A118WWPFormElementParentType = T000D5_A118WWPFormElementParentType[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0D16( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0D16( )
      {
      }

      protected void gxLoad_15( short A94WWPFormId ,
                                short A95WWPFormVersionNumber ,
                                short A98WWPFormElementId )
      {
         /* Using cursor T000D21 */
         pr_default.execute(19, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_48_idx;
            GX_msglist.addItem("N�o existe 'Element'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A117WWPFormElementTitle = T000D21_A117WWPFormElementTitle[0];
         A101WWPFormElementReferenceId = T000D21_A101WWPFormElementReferenceId[0];
         A106WWPFormElementDataType = T000D21_A106WWPFormElementDataType[0];
         A105WWPFormElementType = T000D21_A105WWPFormElementType[0];
         A124WWPFormElementMetadata = T000D21_A124WWPFormElementMetadata[0];
         A125WWPFormElementCaption = T000D21_A125WWPFormElementCaption[0];
         A99WWPFormElementParentId = T000D21_A99WWPFormElementParentId[0];
         n99WWPFormElementParentId = T000D21_n99WWPFormElementParentId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A117WWPFormElementTitle)+"\""+","+"\""+GXUtil.EncodeJSConstant( A101WWPFormElementReferenceId)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106WWPFormElementDataType), 2, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A105WWPFormElementType), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A124WWPFormElementMetadata)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPFormElementCaption), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A99WWPFormElementParentId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_16( short A94WWPFormId ,
                                short A95WWPFormVersionNumber ,
                                short A99WWPFormElementParentId )
      {
         /* Using cursor T000D22 */
         pr_default.execute(20, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A94WWPFormId) || (0==A95WWPFormVersionNumber) || (0==A99WWPFormElementParentId) ) )
            {
               GXCCtl = "WWPFORMELEMENTPARENTID_" + sGXsfl_48_idx;
               GX_msglist.addItem("N�o existe 'WWPForm Element Parent'.", "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtWWPFormId_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A118WWPFormElementParentType = T000D22_A118WWPFormElementParentType[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WWPFormElementParentType), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey0D16( )
      {
         /* Using cursor T000D23 */
         pr_default.execute(21, new Object[] {A102WWPFormInstanceId, A98WWPFormElementId, A103WWPFormInstanceElementId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey0D16( )
      {
         /* Using cursor T000D3 */
         pr_default.execute(1, new Object[] {A102WWPFormInstanceId, A98WWPFormElementId, A103WWPFormInstanceElementId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D16( 14) ;
            RcdFound16 = 1;
            InitializeNonKey0D16( ) ;
            A103WWPFormInstanceElementId = T000D3_A103WWPFormInstanceElementId[0];
            A109WWPFormInstanceElemChar = T000D3_A109WWPFormInstanceElemChar[0];
            n109WWPFormInstanceElemChar = T000D3_n109WWPFormInstanceElemChar[0];
            A108WWPFormInstanceElemDate = T000D3_A108WWPFormInstanceElemDate[0];
            n108WWPFormInstanceElemDate = T000D3_n108WWPFormInstanceElemDate[0];
            A115WWPFormInstanceElemDateTime = T000D3_A115WWPFormInstanceElemDateTime[0];
            n115WWPFormInstanceElemDateTime = T000D3_n115WWPFormInstanceElemDateTime[0];
            A110WWPFormInstanceElemNumeric = T000D3_A110WWPFormInstanceElemNumeric[0];
            n110WWPFormInstanceElemNumeric = T000D3_n110WWPFormInstanceElemNumeric[0];
            A114WWPFormInstanceElemBoolean = T000D3_A114WWPFormInstanceElemBoolean[0];
            n114WWPFormInstanceElemBoolean = T000D3_n114WWPFormInstanceElemBoolean[0];
            A112WWPFormInstanceElemBlobFileType = T000D3_A112WWPFormInstanceElemBlobFileType[0];
            edtWWPFormInstanceElemBlob_Filetype = A112WWPFormInstanceElemBlobFileType;
            AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Filetype", edtWWPFormInstanceElemBlob_Filetype, !bGXsfl_48_Refreshing);
            A113WWPFormInstanceElemBlobFileName = T000D3_A113WWPFormInstanceElemBlobFileName[0];
            edtWWPFormInstanceElemBlob_Filename = A113WWPFormInstanceElemBlobFileName;
            A98WWPFormElementId = T000D3_A98WWPFormElementId[0];
            A111WWPFormInstanceElemBlob = T000D3_A111WWPFormInstanceElemBlob[0];
            n111WWPFormInstanceElemBlob = T000D3_n111WWPFormInstanceElemBlob[0];
            AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "URL", context.PathToRelativeUrl( A111WWPFormInstanceElemBlob), !bGXsfl_48_Refreshing);
            Z102WWPFormInstanceId = A102WWPFormInstanceId;
            Z98WWPFormElementId = A98WWPFormElementId;
            Z103WWPFormInstanceElementId = A103WWPFormInstanceElementId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0D16( ) ;
            Gx_mode = sMode16;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0D16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal0D16( ) ;
            Gx_mode = sMode16;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0D16( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0D16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000D2 */
            pr_default.execute(0, new Object[] {A102WWPFormInstanceId, A98WWPFormElementId, A103WWPFormInstanceElementId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstanceElement"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z108WWPFormInstanceElemDate ) != DateTimeUtil.ResetTime ( T000D2_A108WWPFormInstanceElemDate[0] ) ) || ( Z115WWPFormInstanceElemDateTime != T000D2_A115WWPFormInstanceElemDateTime[0] ) || ( Z110WWPFormInstanceElemNumeric != T000D2_A110WWPFormInstanceElemNumeric[0] ) || ( Z114WWPFormInstanceElemBoolean != T000D2_A114WWPFormInstanceElemBoolean[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z108WWPFormInstanceElemDate ) != DateTimeUtil.ResetTime ( T000D2_A108WWPFormInstanceElemDate[0] ) )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormInstanceElemDate");
                  GXUtil.WriteLogRaw("Old: ",Z108WWPFormInstanceElemDate);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A108WWPFormInstanceElemDate[0]);
               }
               if ( Z115WWPFormInstanceElemDateTime != T000D2_A115WWPFormInstanceElemDateTime[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormInstanceElemDateTime");
                  GXUtil.WriteLogRaw("Old: ",Z115WWPFormInstanceElemDateTime);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A115WWPFormInstanceElemDateTime[0]);
               }
               if ( Z110WWPFormInstanceElemNumeric != T000D2_A110WWPFormInstanceElemNumeric[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormInstanceElemNumeric");
                  GXUtil.WriteLogRaw("Old: ",Z110WWPFormInstanceElemNumeric);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A110WWPFormInstanceElemNumeric[0]);
               }
               if ( Z114WWPFormInstanceElemBoolean != T000D2_A114WWPFormInstanceElemBoolean[0] )
               {
                  GXUtil.WriteLog("workwithplus.dynamicforms.wwp_forminstance:[seudo value changed for attri]"+"WWPFormInstanceElemBoolean");
                  GXUtil.WriteLogRaw("Old: ",Z114WWPFormInstanceElemBoolean);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A114WWPFormInstanceElemBoolean[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormInstanceElement"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D16( )
      {
         BeforeValidate0D16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D16( 0) ;
            CheckOptimisticConcurrency0D16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D24 */
                     A112WWPFormInstanceElemBlobFileType = edtWWPFormInstanceElemBlob_Filetype;
                     A113WWPFormInstanceElemBlobFileName = edtWWPFormInstanceElemBlob_Filename;
                     pr_default.execute(22, new Object[] {A102WWPFormInstanceId, A103WWPFormInstanceElementId, n109WWPFormInstanceElemChar, A109WWPFormInstanceElemChar, n108WWPFormInstanceElemDate, A108WWPFormInstanceElemDate, n115WWPFormInstanceElemDateTime, A115WWPFormInstanceElemDateTime, n110WWPFormInstanceElemNumeric, A110WWPFormInstanceElemNumeric, n111WWPFormInstanceElemBlob, A111WWPFormInstanceElemBlob, n114WWPFormInstanceElemBoolean, A114WWPFormInstanceElemBoolean, A112WWPFormInstanceElemBlobFileType, A113WWPFormInstanceElemBlobFileName, A98WWPFormElementId});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
                     if ( (pr_default.getStatus(22) == 1) )
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
               Load0D16( ) ;
            }
            EndLevel0D16( ) ;
         }
         CloseExtendedTableCursors0D16( ) ;
      }

      protected void Update0D16( )
      {
         BeforeValidate0D16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D16( ) ;
         }
         if ( ( nIsMod_16 != 0 ) || ( nIsDirty_16 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0D16( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0D16( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0D16( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000D25 */
                        A112WWPFormInstanceElemBlobFileType = edtWWPFormInstanceElemBlob_Filetype;
                        A113WWPFormInstanceElemBlobFileName = edtWWPFormInstanceElemBlob_Filename;
                        pr_default.execute(23, new Object[] {n109WWPFormInstanceElemChar, A109WWPFormInstanceElemChar, n108WWPFormInstanceElemDate, A108WWPFormInstanceElemDate, n115WWPFormInstanceElemDateTime, A115WWPFormInstanceElemDateTime, n110WWPFormInstanceElemNumeric, A110WWPFormInstanceElemNumeric, n114WWPFormInstanceElemBoolean, A114WWPFormInstanceElemBoolean, A112WWPFormInstanceElemBlobFileType, A113WWPFormInstanceElemBlobFileName, A102WWPFormInstanceId, A98WWPFormElementId, A103WWPFormInstanceElementId});
                        pr_default.close(23);
                        pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
                        if ( (pr_default.getStatus(23) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstanceElement"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0D16( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0D16( ) ;
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
               EndLevel0D16( ) ;
            }
         }
         CloseExtendedTableCursors0D16( ) ;
      }

      protected void DeferredUpdate0D16( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000D26 */
            pr_default.execute(24, new Object[] {n111WWPFormInstanceElemBlob, A111WWPFormInstanceElemBlob, A102WWPFormInstanceId, A98WWPFormElementId, A103WWPFormInstanceElementId});
            pr_default.close(24);
            pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
         }
      }

      protected void Delete0D16( )
      {
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         BeforeValidate0D16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D16( ) ;
            AfterConfirm0D16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D16( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000D27 */
                  pr_default.execute(25, new Object[] {A102WWPFormInstanceId, A98WWPFormElementId, A103WWPFormInstanceElementId});
                  pr_default.close(25);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0D16( ) ;
         Gx_mode = sMode16;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0D16( )
      {
         standaloneModal0D16( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000D28 */
            pr_default.execute(26, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
            A117WWPFormElementTitle = T000D28_A117WWPFormElementTitle[0];
            A101WWPFormElementReferenceId = T000D28_A101WWPFormElementReferenceId[0];
            A106WWPFormElementDataType = T000D28_A106WWPFormElementDataType[0];
            A105WWPFormElementType = T000D28_A105WWPFormElementType[0];
            A124WWPFormElementMetadata = T000D28_A124WWPFormElementMetadata[0];
            A125WWPFormElementCaption = T000D28_A125WWPFormElementCaption[0];
            A99WWPFormElementParentId = T000D28_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = T000D28_n99WWPFormElementParentId[0];
            pr_default.close(26);
            /* Using cursor T000D29 */
            pr_default.execute(27, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
            A118WWPFormElementParentType = T000D29_A118WWPFormElementParentType[0];
            pr_default.close(27);
         }
      }

      protected void EndLevel0D16( )
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

      public void ScanStart0D16( )
      {
         /* Scan By routine */
         /* Using cursor T000D30 */
         pr_default.execute(28, new Object[] {A102WWPFormInstanceId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound16 = 1;
            A98WWPFormElementId = T000D30_A98WWPFormElementId[0];
            A103WWPFormInstanceElementId = T000D30_A103WWPFormInstanceElementId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0D16( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound16 = 1;
            A98WWPFormElementId = T000D30_A98WWPFormElementId[0];
            A103WWPFormInstanceElementId = T000D30_A103WWPFormInstanceElementId[0];
         }
      }

      protected void ScanEnd0D16( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm0D16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D16( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D16( )
      {
         edtWWPFormElementId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtWWPFormInstanceElementId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtWWPFormElementTitle_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         cmbWWPFormElementDataType.Enabled = 0;
         AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtWWPFormInstanceElemChar_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemChar_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtWWPFormInstanceElemDate_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemDate_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtWWPFormInstanceElemNumeric_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemNumeric_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemNumeric_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtWWPFormInstanceElemBlob_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemBlob_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         chkWWPFormInstanceElemBoolean.Enabled = 0;
         AssignProp(sPrefix, false, chkWWPFormInstanceElemBoolean_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormInstanceElemBoolean.Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtWWPFormElementReferenceId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementReferenceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtWWPFormElementParentId_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormElementParentId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtWWPFormInstanceElemDateTime_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemDateTime_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtWWPFormInstanceElemBlobFileName_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemBlobFileName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemBlobFileName_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtWWPFormInstanceElemBlobFileType_Enabled = 0;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemBlobFileType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElemBlobFileType_Enabled), 5, 0), !bGXsfl_48_Refreshing);
      }

      protected void send_integrity_lvl_hashes0D16( )
      {
      }

      protected void send_integrity_lvl_hashes0D15( )
      {
      }

      protected void SubsflControlProps_4816( )
      {
         edtWWPFormElementId_Internalname = sPrefix+"WWPFORMELEMENTID_"+sGXsfl_48_idx;
         edtWWPFormInstanceElementId_Internalname = sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_48_idx;
         edtWWPFormElementTitle_Internalname = sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_48_idx;
         cmbWWPFormElementDataType_Internalname = sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_48_idx;
         edtWWPFormInstanceElemChar_Internalname = sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_48_idx;
         edtWWPFormInstanceElemDate_Internalname = sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_48_idx;
         edtWWPFormInstanceElemNumeric_Internalname = sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_48_idx;
         edtWWPFormInstanceElemBlob_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_48_idx;
         chkWWPFormInstanceElemBoolean_Internalname = sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_48_idx;
         edtWWPFormElementReferenceId_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_48_idx;
         edtWWPFormElementParentId_Internalname = sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_48_idx;
         edtWWPFormInstanceElemDateTime_Internalname = sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_48_idx;
         edtWWPFormInstanceElemBlobFileName_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAME_"+sGXsfl_48_idx;
         edtWWPFormInstanceElemBlobFileType_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYPE_"+sGXsfl_48_idx;
      }

      protected void SubsflControlProps_fel_4816( )
      {
         edtWWPFormElementId_Internalname = sPrefix+"WWPFORMELEMENTID_"+sGXsfl_48_fel_idx;
         edtWWPFormInstanceElementId_Internalname = sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_48_fel_idx;
         edtWWPFormElementTitle_Internalname = sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_48_fel_idx;
         cmbWWPFormElementDataType_Internalname = sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_48_fel_idx;
         edtWWPFormInstanceElemChar_Internalname = sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_48_fel_idx;
         edtWWPFormInstanceElemDate_Internalname = sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_48_fel_idx;
         edtWWPFormInstanceElemNumeric_Internalname = sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_48_fel_idx;
         edtWWPFormInstanceElemBlob_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_48_fel_idx;
         chkWWPFormInstanceElemBoolean_Internalname = sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_48_fel_idx;
         edtWWPFormElementReferenceId_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_48_fel_idx;
         edtWWPFormElementParentId_Internalname = sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_48_fel_idx;
         edtWWPFormInstanceElemDateTime_Internalname = sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_48_fel_idx;
         edtWWPFormInstanceElemBlobFileName_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAME_"+sGXsfl_48_fel_idx;
         edtWWPFormInstanceElemBlobFileType_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYPE_"+sGXsfl_48_fel_idx;
      }

      protected void AddRow0D16( )
      {
         nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_4816( ) ;
         SendRow0D16( ) ;
      }

      protected void SendRow0D16( )
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
            if ( ((int)((nGXsfl_48_idx) % (2))) == 0 )
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
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A98WWPFormElementId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A98WWPFormElementId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElementId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A103WWPFormInstanceElementId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A103WWPFormInstanceElementId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,50);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElementId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElementId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementTitle_Internalname,(string)A117WWPFormElementTitle,(string)A117WWPFormElementTitle,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementTitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementTitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)48,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         GXCCtl = "WWPFORMELEMENTDATATYPE_" + sGXsfl_48_idx;
         cmbWWPFormElementDataType.Name = GXCCtl;
         cmbWWPFormElementDataType.WebTags = "";
         cmbWWPFormElementDataType.addItem("1", "Boleano", 0);
         cmbWWPFormElementDataType.addItem("2", "Caracteres", 0);
         cmbWWPFormElementDataType.addItem("3", "Num�rico", 0);
         cmbWWPFormElementDataType.addItem("4", "Data", 0);
         cmbWWPFormElementDataType.addItem("5", "Data e hora", 0);
         cmbWWPFormElementDataType.addItem("6", "Senha", 0);
         cmbWWPFormElementDataType.addItem("7", "Correio eletr�nico", 0);
         cmbWWPFormElementDataType.addItem("8", "URL", 0);
         cmbWWPFormElementDataType.addItem("9", "Arquivo", 0);
         cmbWWPFormElementDataType.addItem("10", "Imagem", 0);
         if ( cmbWWPFormElementDataType.ItemCount > 0 )
         {
            A106WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementDataType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A106WWPFormElementDataType), 2, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* ComboBox */
         Gridlevel_elementRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWWPFormElementDataType,(string)cmbWWPFormElementDataType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A106WWPFormElementDataType), 2, 0)),(short)1,(string)cmbWWPFormElementDataType_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbWWPFormElementDataType.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"",(bool)true,(short)0});
         cmbWWPFormElementDataType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106WWPFormElementDataType), 2, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Values", (string)(cmbWWPFormElementDataType.ToJavascriptSource()), !bGXsfl_48_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemChar_Internalname,(string)A109WWPFormInstanceElemChar,(string)A109WWPFormInstanceElemChar,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElemChar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElemChar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)48,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemDate_Internalname,context.localUtil.Format(A108WWPFormInstanceElemDate, "99/99/99"),context.localUtil.Format( A108WWPFormInstanceElemDate, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,54);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElemDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElemDate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemNumeric_Internalname,((Convert.ToDecimal(0)==A110WWPFormInstanceElemNumeric)&&IsIns( )||n110WWPFormInstanceElemNumeric ? "" : StringUtil.LTrim( StringUtil.NToC( A110WWPFormInstanceElemNumeric, 21, 5, ",", ""))),((Convert.ToDecimal(0)==A110WWPFormInstanceElemNumeric)&&IsIns( )||n110WWPFormInstanceElemNumeric ? "" : StringUtil.LTrim( ((edtWWPFormInstanceElemNumeric_Enabled!=0) ? context.localUtil.Format( A110WWPFormInstanceElemNumeric, "ZZZ,ZZZ,ZZZ,ZZ9.99999") : context.localUtil.Format( A110WWPFormInstanceElemNumeric, "ZZZ,ZZZ,ZZZ,ZZ9.99999")))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','5');"+";gx.evt.onblur(this,55);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElemNumeric_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElemNumeric_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         ClassString = "Attribute";
         StyleString = "";
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         edtWWPFormInstanceElemBlob_Filename = A113WWPFormInstanceElemBlobFileName;
         edtWWPFormInstanceElemBlob_Filetype = "";
         AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Filetype", edtWWPFormInstanceElemBlob_Filetype, !bGXsfl_48_Refreshing);
         edtWWPFormInstanceElemBlob_Filetype = A112WWPFormInstanceElemBlobFileType;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Filetype", edtWWPFormInstanceElemBlob_Filetype, !bGXsfl_48_Refreshing);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A111WWPFormInstanceElemBlob)) )
         {
            gxblobfileaux.Source = A111WWPFormInstanceElemBlob;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtWWPFormInstanceElemBlob_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtWWPFormInstanceElemBlob_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A111WWPFormInstanceElemBlob = gxblobfileaux.GetURI();
               n111WWPFormInstanceElemBlob = false;
               AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "URL", context.PathToRelativeUrl( A111WWPFormInstanceElemBlob), !bGXsfl_48_Refreshing);
               edtWWPFormInstanceElemBlob_Filetype = gxblobfileaux.GetExtension();
               AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "Filetype", edtWWPFormInstanceElemBlob_Filetype, !bGXsfl_48_Refreshing);
            }
            AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "URL", context.PathToRelativeUrl( A111WWPFormInstanceElemBlob), !bGXsfl_48_Refreshing);
         }
         Gridlevel_elementRow.AddColumnProperties("blob", 2, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemBlob_Internalname,StringUtil.RTrim( A111WWPFormInstanceElemBlob),context.PathToRelativeUrl( A111WWPFormInstanceElemBlob),(String.IsNullOrEmpty(StringUtil.RTrim( edtWWPFormInstanceElemBlob_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtWWPFormInstanceElemBlob_Filetype)) ? A111WWPFormInstanceElemBlob : edtWWPFormInstanceElemBlob_Filetype)) : edtWWPFormInstanceElemBlob_Contenttype),(bool)true,(string)"",(string)edtWWPFormInstanceElemBlob_Parameters,(short)0,(int)edtWWPFormInstanceElemBlob_Enabled,(short)-1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)60,(string)"px",(short)0,(short)0,(short)0,(string)edtWWPFormInstanceElemBlob_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"",(string)""});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "WWPFORMINSTANCEELEMBOOLEAN_" + sGXsfl_48_idx;
         chkWWPFormInstanceElemBoolean.Name = GXCCtl;
         chkWWPFormInstanceElemBoolean.WebTags = "";
         chkWWPFormInstanceElemBoolean.Caption = "";
         AssignProp(sPrefix, false, chkWWPFormInstanceElemBoolean_Internalname, "TitleCaption", chkWWPFormInstanceElemBoolean.Caption, !bGXsfl_48_Refreshing);
         chkWWPFormInstanceElemBoolean.CheckedValue = "false";
         Gridlevel_elementRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkWWPFormInstanceElemBoolean_Internalname,StringUtil.BoolToStr( A114WWPFormInstanceElemBoolean),(string)"",(string)"",(short)-1,chkWWPFormInstanceElemBoolean.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(57, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,57);\""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementReferenceId_Internalname,(string)A101WWPFormElementReferenceId,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementReferenceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementReferenceId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormElementParentId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A99WWPFormElementParentId), 4, 0, ",", "")),StringUtil.LTrim( ((edtWWPFormElementParentId_Enabled!=0) ? context.localUtil.Format( (decimal)(A99WWPFormElementParentId), "ZZZ9") : context.localUtil.Format( (decimal)(A99WWPFormElementParentId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormElementParentId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormElementParentId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemDateTime_Internalname,context.localUtil.TToC( A115WWPFormInstanceElemDateTime, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A115WWPFormInstanceElemDateTime, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,60);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElemDateTime_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElemDateTime_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemBlobFileName_Internalname,(string)A113WWPFormInstanceElemBlobFileName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElemBlobFileName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElemBlobFileName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridlevel_elementRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceElemBlobFileType_Internalname,(string)A112WWPFormInstanceElemBlobFileType,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceElemBlobFileType_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtWWPFormInstanceElemBlobFileType_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_elementRow);
         send_integrity_lvl_hashes0D16( ) ;
         GXCCtl = "Z98WWPFormElementId_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98WWPFormElementId), 4, 0, ",", "")));
         GXCCtl = "Z103WWPFormInstanceElementId_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z103WWPFormInstanceElementId), 4, 0, ",", "")));
         GXCCtl = "Z108WWPFormInstanceElemDate_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, context.localUtil.DToC( Z108WWPFormInstanceElemDate, 0, "/"));
         GXCCtl = "Z115WWPFormInstanceElemDateTime_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, context.localUtil.TToC( Z115WWPFormInstanceElemDateTime, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z110WWPFormInstanceElemNumeric_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z110WWPFormInstanceElemNumeric, 18, 5, ",", "")));
         GXCCtl = "Z114WWPFormInstanceElemBoolean_" + sGXsfl_48_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z114WWPFormInstanceElemBoolean);
         GXCCtl = "nRcdDeleted_16_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_16), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_16_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_16), 4, 0, ",", "")));
         GXCCtl = "nIsMod_16_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_16), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vWWPFORMINSTANCEID_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormInstanceId), 6, 0, ",", "")));
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_" + sGXsfl_48_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtlgxBlob, A111WWPFormInstanceElemBlob);
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filetype_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( edtWWPFormInstanceElemBlob_Filetype));
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filename_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( edtWWPFormInstanceElemBlob_Filename));
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filename_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( edtWWPFormInstanceElemBlob_Filename));
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filetype_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( edtWWPFormInstanceElemBlob_Filetype));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemChar_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDate_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemNumeric_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlob_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkWWPFormInstanceElemBoolean.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDateTime_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAME_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYPE_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileType_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_elementContainer.AddRow(Gridlevel_elementRow);
      }

      protected void ReadRow0D16( )
      {
         nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_4816( ) ;
         edtWWPFormElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTID_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElementId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMENTID_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormElementTitle_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTTITLE_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         cmbWWPFormElementDataType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTDATATYPE_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemChar_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMCHAR_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemDate_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMDATE_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemNumeric_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMNUMERIC_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemBlob_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBLOB_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         chkWWPFormInstanceElemBoolean.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBOOLEAN_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormElementReferenceId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTREFERENCEID_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormElementParentId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMELEMENTPARENTID_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemDateTime_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMDATETIME_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemBlobFileName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAME_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPFormInstanceElemBlobFileType_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYPE_"+sGXsfl_48_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filetype_" + sGXsfl_48_idx;
         edtWWPFormInstanceElemBlob_Filetype = cgiGet( sPrefix+GXCCtl);
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filename_" + sGXsfl_48_idx;
         edtWWPFormInstanceElemBlob_Filename = cgiGet( sPrefix+GXCCtl);
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filename_" + sGXsfl_48_idx;
         edtWWPFormInstanceElemBlob_Filename = cgiGet( sPrefix+GXCCtl);
         GXCCtl = "WWPFORMINSTANCEELEMBLOB_Filetype_" + sGXsfl_48_idx;
         edtWWPFormInstanceElemBlob_Filetype = cgiGet( sPrefix+GXCCtl);
         if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormElementId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "WWPFORMELEMENTID_" + sGXsfl_48_idx;
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
         if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormInstanceElementId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormInstanceElementId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "WWPFORMINSTANCEELEMENTID_" + sGXsfl_48_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormInstanceElementId_Internalname;
            wbErr = true;
            A103WWPFormInstanceElementId = 0;
         }
         else
         {
            A103WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormInstanceElementId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         A117WWPFormElementTitle = cgiGet( edtWWPFormElementTitle_Internalname);
         cmbWWPFormElementDataType.Name = cmbWWPFormElementDataType_Internalname;
         cmbWWPFormElementDataType.CurrentValue = cgiGet( cmbWWPFormElementDataType_Internalname);
         A106WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormElementDataType_Internalname), "."), 18, MidpointRounding.ToEven));
         A109WWPFormInstanceElemChar = cgiGet( edtWWPFormInstanceElemChar_Internalname);
         n109WWPFormInstanceElemChar = false;
         n109WWPFormInstanceElemChar = (String.IsNullOrEmpty(StringUtil.RTrim( A109WWPFormInstanceElemChar)) ? true : false);
         if ( context.localUtil.VCDate( cgiGet( edtWWPFormInstanceElemDate_Internalname), 2) == 0 )
         {
            GXCCtl = "WWPFORMINSTANCEELEMDATE_" + sGXsfl_48_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"WWPForm Instance Elem Date"}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormInstanceElemDate_Internalname;
            wbErr = true;
            A108WWPFormInstanceElemDate = DateTime.MinValue;
            n108WWPFormInstanceElemDate = false;
         }
         else
         {
            A108WWPFormInstanceElemDate = context.localUtil.CToD( cgiGet( edtWWPFormInstanceElemDate_Internalname), 2);
            n108WWPFormInstanceElemDate = false;
         }
         n108WWPFormInstanceElemDate = ((DateTime.MinValue==A108WWPFormInstanceElemDate) ? true : false);
         n110WWPFormInstanceElemNumeric = ((StringUtil.StrCmp(cgiGet( edtWWPFormInstanceElemNumeric_Internalname), "")==0) ? true : false);
         if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormInstanceElemNumeric_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormInstanceElemNumeric_Internalname), ",", ".") > 999999999999.99999m ) ) )
         {
            GXCCtl = "WWPFORMINSTANCEELEMNUMERIC_" + sGXsfl_48_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormInstanceElemNumeric_Internalname;
            wbErr = true;
            A110WWPFormInstanceElemNumeric = 0;
            n110WWPFormInstanceElemNumeric = false;
         }
         else
         {
            A110WWPFormInstanceElemNumeric = context.localUtil.CToN( cgiGet( edtWWPFormInstanceElemNumeric_Internalname), ",", ".");
         }
         A111WWPFormInstanceElemBlob = cgiGet( edtWWPFormInstanceElemBlob_Internalname);
         n111WWPFormInstanceElemBlob = false;
         n111WWPFormInstanceElemBlob = (String.IsNullOrEmpty(StringUtil.RTrim( A111WWPFormInstanceElemBlob)) ? true : false);
         A114WWPFormInstanceElemBoolean = StringUtil.StrToBool( cgiGet( chkWWPFormInstanceElemBoolean_Internalname));
         n114WWPFormInstanceElemBoolean = false;
         n114WWPFormInstanceElemBoolean = ((false==A114WWPFormInstanceElemBoolean) ? true : false);
         A101WWPFormElementReferenceId = cgiGet( edtWWPFormElementReferenceId_Internalname);
         A99WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormElementParentId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         n99WWPFormElementParentId = false;
         if ( context.localUtil.VCDateTime( cgiGet( edtWWPFormInstanceElemDateTime_Internalname), 2, 0) == 0 )
         {
            GXCCtl = "WWPFORMINSTANCEELEMDATETIME_" + sGXsfl_48_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"WWPForm Instance Elem Date Time"}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtWWPFormInstanceElemDateTime_Internalname;
            wbErr = true;
            A115WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
            n115WWPFormInstanceElemDateTime = false;
         }
         else
         {
            A115WWPFormInstanceElemDateTime = context.localUtil.CToT( cgiGet( edtWWPFormInstanceElemDateTime_Internalname));
            n115WWPFormInstanceElemDateTime = false;
         }
         n115WWPFormInstanceElemDateTime = ((DateTime.MinValue==A115WWPFormInstanceElemDateTime) ? true : false);
         GXCCtl = "Z98WWPFormElementId_" + sGXsfl_48_idx;
         Z98WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z103WWPFormInstanceElementId_" + sGXsfl_48_idx;
         Z103WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z108WWPFormInstanceElemDate_" + sGXsfl_48_idx;
         Z108WWPFormInstanceElemDate = context.localUtil.CToD( cgiGet( sPrefix+GXCCtl), 0);
         n108WWPFormInstanceElemDate = ((DateTime.MinValue==A108WWPFormInstanceElemDate) ? true : false);
         GXCCtl = "Z115WWPFormInstanceElemDateTime_" + sGXsfl_48_idx;
         Z115WWPFormInstanceElemDateTime = context.localUtil.CToT( cgiGet( sPrefix+GXCCtl), 0);
         n115WWPFormInstanceElemDateTime = ((DateTime.MinValue==A115WWPFormInstanceElemDateTime) ? true : false);
         GXCCtl = "Z110WWPFormInstanceElemNumeric_" + sGXsfl_48_idx;
         Z110WWPFormInstanceElemNumeric = context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", ".");
         n110WWPFormInstanceElemNumeric = ((Convert.ToDecimal(0)==A110WWPFormInstanceElemNumeric) ? true : false);
         GXCCtl = "Z114WWPFormInstanceElemBoolean_" + sGXsfl_48_idx;
         Z114WWPFormInstanceElemBoolean = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n114WWPFormInstanceElemBoolean = ((false==A114WWPFormInstanceElemBoolean) ? true : false);
         GXCCtl = "nRcdDeleted_16_" + sGXsfl_48_idx;
         nRcdDeleted_16 = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_16_" + sGXsfl_48_idx;
         nRcdExists_16 = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_16_" + sGXsfl_48_idx;
         nIsMod_16 = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         if ( ( nRcdDeleted_16 == 0 ) && ( nIsMod_16 == 1 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( A111WWPFormInstanceElemBlob)) )
         {
            edtWWPFormInstanceElemBlob_Filename = (string)(CGIGetFileName(edtWWPFormInstanceElemBlob_Internalname));
            edtWWPFormInstanceElemBlob_Filetype = (string)(CGIGetFileType(edtWWPFormInstanceElemBlob_Internalname));
         }
         A112WWPFormInstanceElemBlobFileType = edtWWPFormInstanceElemBlob_Filetype;
         A113WWPFormInstanceElemBlobFileName = edtWWPFormInstanceElemBlob_Filename;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A111WWPFormInstanceElemBlob)) )
         {
            GXCCtl = "WWPFORMINSTANCEELEMBLOB_" + sGXsfl_48_idx;
            GXCCtlgxBlob = GXCCtl + "_gxBlob";
            A111WWPFormInstanceElemBlob = cgiGet( sPrefix+GXCCtlgxBlob);
            n111WWPFormInstanceElemBlob = false;
         }
      }

      protected void assign_properties_default( )
      {
         defedtWWPFormInstanceElementId_Enabled = edtWWPFormInstanceElementId_Enabled;
         defedtWWPFormElementId_Enabled = edtWWPFormElementId_Enabled;
      }

      protected void ConfirmValues0D0( )
      {
         nGXsfl_48_idx = 0;
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_4816( ) ;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_4816( ) ;
            ChangePostValue( sPrefix+"Z98WWPFormElementId_"+sGXsfl_48_idx, cgiGet( sPrefix+"ZT_"+"Z98WWPFormElementId_"+sGXsfl_48_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z98WWPFormElementId_"+sGXsfl_48_idx) ;
            ChangePostValue( sPrefix+"Z103WWPFormInstanceElementId_"+sGXsfl_48_idx, cgiGet( sPrefix+"ZT_"+"Z103WWPFormInstanceElementId_"+sGXsfl_48_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z103WWPFormInstanceElementId_"+sGXsfl_48_idx) ;
            ChangePostValue( sPrefix+"Z108WWPFormInstanceElemDate_"+sGXsfl_48_idx, cgiGet( sPrefix+"ZT_"+"Z108WWPFormInstanceElemDate_"+sGXsfl_48_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z108WWPFormInstanceElemDate_"+sGXsfl_48_idx) ;
            ChangePostValue( sPrefix+"Z115WWPFormInstanceElemDateTime_"+sGXsfl_48_idx, cgiGet( sPrefix+"ZT_"+"Z115WWPFormInstanceElemDateTime_"+sGXsfl_48_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z115WWPFormInstanceElemDateTime_"+sGXsfl_48_idx) ;
            ChangePostValue( sPrefix+"Z110WWPFormInstanceElemNumeric_"+sGXsfl_48_idx, cgiGet( sPrefix+"ZT_"+"Z110WWPFormInstanceElemNumeric_"+sGXsfl_48_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z110WWPFormInstanceElemNumeric_"+sGXsfl_48_idx) ;
            ChangePostValue( sPrefix+"Z114WWPFormInstanceElemBoolean_"+sGXsfl_48_idx, cgiGet( sPrefix+"ZT_"+"Z114WWPFormInstanceElemBoolean_"+sGXsfl_48_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z114WWPFormInstanceElemBoolean_"+sGXsfl_48_idx) ;
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
            context.SendWebValue( "WWPForm Instance") ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_forminstance"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7WWPFormInstanceId,6,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_forminstance") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WWP_FormInstance");
         forbiddenHiddens.Add("Insert_WWPFormId", context.localUtil.Format( (decimal)(AV11Insert_WWPFormId), "ZZZ9"));
         forbiddenHiddens.Add("Insert_WWPFormVersionNumber", context.localUtil.Format( (decimal)(AV12Insert_WWPFormVersionNumber), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("workwithplus\\dynamicforms\\wwp_forminstance:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z102WWPFormInstanceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z102WWPFormInstanceId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z127WWPFormInstanceDate", context.localUtil.DToC( Z127WWPFormInstanceDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z94WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z94WWPFormId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z95WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z95WWPFormVersionNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7WWPFormInstanceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7WWPFormInstanceId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_48", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_48_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N94WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A94WWPFormId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N95WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A95WWPFormVersionNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormInstanceId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_WWPFormId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_WWPFormVersionNumber), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMINSTANCERECORDKEY", A293WWPFormInstanceRecordKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMRESUME", StringUtil.LTrim( StringUtil.NToC( (decimal)(A104WWPFormResume), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMVALIDATIONS", A121WWPFormValidations);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV16Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A105WWPFormElementType), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTMETADATA", A124WWPFormElementMetadata);
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTCAPTION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPFormElementCaption), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPFORMELEMENTPARENTTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WWPFormElementParentType), 1, 0, ",", "")));
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

      protected void RenderHtmlCloseForm0D15( )
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
         return "WorkWithPlus.DynamicForms.WWP_FormInstance" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWPForm Instance" ;
      }

      protected void InitializeNonKey0D15( )
      {
         A94WWPFormId = 0;
         AssignAttri(sPrefix, false, "A94WWPFormId", StringUtil.LTrimStr( (decimal)(A94WWPFormId), 4, 0));
         A95WWPFormVersionNumber = 0;
         AssignAttri(sPrefix, false, "A95WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A95WWPFormVersionNumber), 4, 0));
         A97WWPFormTitle = "";
         AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
         A104WWPFormResume = 0;
         AssignAttri(sPrefix, false, "A104WWPFormResume", StringUtil.Str( (decimal)(A104WWPFormResume), 1, 0));
         A121WWPFormValidations = "";
         AssignAttri(sPrefix, false, "A121WWPFormValidations", A121WWPFormValidations);
         A293WWPFormInstanceRecordKey = "";
         n293WWPFormInstanceRecordKey = false;
         AssignAttri(sPrefix, false, "A293WWPFormInstanceRecordKey", A293WWPFormInstanceRecordKey);
         A127WWPFormInstanceDate = Gx_date;
         AssignAttri(sPrefix, false, "A127WWPFormInstanceDate", context.localUtil.Format(A127WWPFormInstanceDate, "99/99/99"));
         Z127WWPFormInstanceDate = DateTime.MinValue;
         Z94WWPFormId = 0;
         Z95WWPFormVersionNumber = 0;
      }

      protected void InitAll0D15( )
      {
         A102WWPFormInstanceId = 0;
         AssignAttri(sPrefix, false, "A102WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(A102WWPFormInstanceId), 6, 0));
         InitializeNonKey0D15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A127WWPFormInstanceDate = i127WWPFormInstanceDate;
         AssignAttri(sPrefix, false, "A127WWPFormInstanceDate", context.localUtil.Format(A127WWPFormInstanceDate, "99/99/99"));
      }

      protected void InitializeNonKey0D16( )
      {
         A117WWPFormElementTitle = "";
         A101WWPFormElementReferenceId = "";
         A106WWPFormElementDataType = 0;
         A99WWPFormElementParentId = 0;
         n99WWPFormElementParentId = false;
         A118WWPFormElementParentType = 0;
         AssignAttri(sPrefix, false, "A118WWPFormElementParentType", StringUtil.Str( (decimal)(A118WWPFormElementParentType), 1, 0));
         A105WWPFormElementType = 0;
         AssignAttri(sPrefix, false, "A105WWPFormElementType", StringUtil.Str( (decimal)(A105WWPFormElementType), 1, 0));
         A124WWPFormElementMetadata = "";
         AssignAttri(sPrefix, false, "A124WWPFormElementMetadata", A124WWPFormElementMetadata);
         A125WWPFormElementCaption = 0;
         AssignAttri(sPrefix, false, "A125WWPFormElementCaption", StringUtil.Str( (decimal)(A125WWPFormElementCaption), 1, 0));
         A109WWPFormInstanceElemChar = "";
         n109WWPFormInstanceElemChar = false;
         A108WWPFormInstanceElemDate = DateTime.MinValue;
         n108WWPFormInstanceElemDate = false;
         A115WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         n115WWPFormInstanceElemDateTime = false;
         A110WWPFormInstanceElemNumeric = 0;
         n110WWPFormInstanceElemNumeric = false;
         A111WWPFormInstanceElemBlob = "";
         n111WWPFormInstanceElemBlob = false;
         AssignProp(sPrefix, false, edtWWPFormInstanceElemBlob_Internalname, "URL", context.PathToRelativeUrl( A111WWPFormInstanceElemBlob), !bGXsfl_48_Refreshing);
         A114WWPFormInstanceElemBoolean = false;
         n114WWPFormInstanceElemBoolean = false;
         A112WWPFormInstanceElemBlobFileType = "";
         A113WWPFormInstanceElemBlobFileName = "";
         Z108WWPFormInstanceElemDate = DateTime.MinValue;
         Z115WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         Z110WWPFormInstanceElemNumeric = 0;
         Z114WWPFormInstanceElemBoolean = false;
      }

      protected void InitAll0D16( )
      {
         A98WWPFormElementId = 0;
         A103WWPFormInstanceElementId = 0;
         InitializeNonKey0D16( ) ;
      }

      protected void StandaloneModalInsert0D16( )
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
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7WWPFormInstanceId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_forminstance", GetJustCreated( ));
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
            AV7WWPFormInstanceId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV7WWPFormInstanceId), 6, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7WWPFormInstanceId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7WWPFormInstanceId != wcpOAV7WWPFormInstanceId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7WWPFormInstanceId = AV7WWPFormInstanceId;
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
         sCtrlAV7WWPFormInstanceId = cgiGet( sPrefix+"AV7WWPFormInstanceId_CTRL");
         if ( StringUtil.Len( sCtrlAV7WWPFormInstanceId) > 0 )
         {
            AV7WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV7WWPFormInstanceId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV7WWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV7WWPFormInstanceId), 6, 0));
         }
         else
         {
            AV7WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV7WWPFormInstanceId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPFormInstanceId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPFormInstanceId), 6, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7WWPFormInstanceId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7WWPFormInstanceId_CTRL", StringUtil.RTrim( sCtrlAV7WWPFormInstanceId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101971488", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_forminstance.js", "?20256101971488", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties16( )
      {
         edtWWPFormInstanceElementId_Enabled = defedtWWPFormInstanceElementId_Enabled;
         AssignProp(sPrefix, false, edtWWPFormInstanceElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtWWPFormElementId_Enabled = defedtWWPFormElementId_Enabled;
         AssignProp(sPrefix, false, edtWWPFormElementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormElementId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
      }

      protected void StartGridControl48( )
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
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A103WWPFormInstanceElementId), 4, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElementId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A117WWPFormElementTitle));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementTitle_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106WWPFormElementDataType), 2, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbWWPFormElementDataType.Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A109WWPFormInstanceElemChar));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemChar_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A108WWPFormInstanceElemDate, "99/99/99")));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDate_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A110WWPFormInstanceElemNumeric, 21, 5, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemNumeric_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A111WWPFormInstanceElemBlob));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlob_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A114WWPFormInstanceElemBoolean)));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkWWPFormInstanceElemBoolean.Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A101WWPFormElementReferenceId));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementReferenceId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A99WWPFormElementParentId), 4, 0, ".", ""))));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormElementParentId_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A115WWPFormInstanceElemDateTime, 10, 8, 0, 3, "/", ":", " ")));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemDateTime_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A113WWPFormInstanceElemBlobFileName));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileName_Enabled), 5, 0, ".", "")));
         Gridlevel_elementContainer.AddColumnProperties(Gridlevel_elementColumn);
         Gridlevel_elementColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_elementColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A112WWPFormInstanceElemBlobFileType));
         Gridlevel_elementColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormInstanceElemBlobFileType_Enabled), 5, 0, ".", "")));
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
         edtWWPFormInstanceId_Internalname = sPrefix+"WWPFORMINSTANCEID";
         edtWWPFormInstanceDate_Internalname = sPrefix+"WWPFORMINSTANCEDATE";
         edtWWPFormId_Internalname = sPrefix+"WWPFORMID";
         edtWWPFormVersionNumber_Internalname = sPrefix+"WWPFORMVERSIONNUMBER";
         edtWWPFormTitle_Internalname = sPrefix+"WWPFORMTITLE";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = sPrefix+"DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         edtWWPFormElementId_Internalname = sPrefix+"WWPFORMELEMENTID";
         edtWWPFormInstanceElementId_Internalname = sPrefix+"WWPFORMINSTANCEELEMENTID";
         edtWWPFormElementTitle_Internalname = sPrefix+"WWPFORMELEMENTTITLE";
         cmbWWPFormElementDataType_Internalname = sPrefix+"WWPFORMELEMENTDATATYPE";
         edtWWPFormInstanceElemChar_Internalname = sPrefix+"WWPFORMINSTANCEELEMCHAR";
         edtWWPFormInstanceElemDate_Internalname = sPrefix+"WWPFORMINSTANCEELEMDATE";
         edtWWPFormInstanceElemNumeric_Internalname = sPrefix+"WWPFORMINSTANCEELEMNUMERIC";
         edtWWPFormInstanceElemBlob_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOB";
         chkWWPFormInstanceElemBoolean_Internalname = sPrefix+"WWPFORMINSTANCEELEMBOOLEAN";
         edtWWPFormElementReferenceId_Internalname = sPrefix+"WWPFORMELEMENTREFERENCEID";
         edtWWPFormElementParentId_Internalname = sPrefix+"WWPFORMELEMENTPARENTID";
         edtWWPFormInstanceElemDateTime_Internalname = sPrefix+"WWPFORMINSTANCEELEMDATETIME";
         edtWWPFormInstanceElemBlobFileName_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOBFILENAME";
         edtWWPFormInstanceElemBlobFileType_Internalname = sPrefix+"WWPFORMINSTANCEELEMBLOBFILETYPE";
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
         edtWWPFormInstanceElemBlobFileType_Jsonclick = "";
         edtWWPFormInstanceElemBlobFileName_Jsonclick = "";
         edtWWPFormInstanceElemDateTime_Jsonclick = "";
         edtWWPFormElementParentId_Jsonclick = "";
         edtWWPFormElementReferenceId_Jsonclick = "";
         chkWWPFormInstanceElemBoolean.Caption = "";
         edtWWPFormInstanceElemBlob_Jsonclick = "";
         edtWWPFormInstanceElemBlob_Parameters = "";
         edtWWPFormInstanceElemBlob_Contenttype = "";
         edtWWPFormInstanceElemNumeric_Jsonclick = "";
         edtWWPFormInstanceElemDate_Jsonclick = "";
         edtWWPFormInstanceElemChar_Jsonclick = "";
         cmbWWPFormElementDataType_Jsonclick = "";
         edtWWPFormElementTitle_Jsonclick = "";
         edtWWPFormInstanceElementId_Jsonclick = "";
         edtWWPFormElementId_Jsonclick = "";
         subGridlevel_element_Class = "GridWithBorderColor WorkWith";
         subGridlevel_element_Backcolorstyle = 0;
         edtWWPFormInstanceElemBlob_Filename = "";
         edtWWPFormInstanceElemBlob_Filetype = "";
         edtWWPFormInstanceElemBlobFileType_Enabled = 1;
         edtWWPFormInstanceElemBlobFileName_Enabled = 1;
         edtWWPFormInstanceElemDateTime_Enabled = 1;
         edtWWPFormElementParentId_Enabled = 0;
         edtWWPFormElementReferenceId_Enabled = 0;
         chkWWPFormInstanceElemBoolean.Enabled = 1;
         edtWWPFormInstanceElemBlob_Enabled = 1;
         edtWWPFormInstanceElemNumeric_Enabled = 1;
         edtWWPFormInstanceElemDate_Enabled = 1;
         edtWWPFormInstanceElemChar_Enabled = 1;
         cmbWWPFormElementDataType.Enabled = 0;
         edtWWPFormElementTitle_Enabled = 0;
         edtWWPFormInstanceElementId_Enabled = 1;
         edtWWPFormElementId_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtWWPFormTitle_Jsonclick = "";
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormVersionNumber_Jsonclick = "";
         edtWWPFormVersionNumber_Enabled = 1;
         edtWWPFormId_Jsonclick = "";
         edtWWPFormId_Enabled = 1;
         edtWWPFormInstanceDate_Jsonclick = "";
         edtWWPFormInstanceDate_Enabled = 1;
         edtWWPFormInstanceId_Jsonclick = "";
         edtWWPFormInstanceId_Enabled = 0;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informa��es Gerais";
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

      protected void gxnrGridlevel_element_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         SubsflControlProps_4816( ) ;
         while ( nGXsfl_48_idx <= nRC_GXsfl_48 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0D16( ) ;
            standaloneModal0D16( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0D16( ) ;
            nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_4816( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_elementContainer)) ;
         /* End function gxnrGridlevel_element_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "WWPFORMELEMENTDATATYPE_" + sGXsfl_48_idx;
         cmbWWPFormElementDataType.Name = GXCCtl;
         cmbWWPFormElementDataType.WebTags = "";
         cmbWWPFormElementDataType.addItem("1", "Boleano", 0);
         cmbWWPFormElementDataType.addItem("2", "Caracteres", 0);
         cmbWWPFormElementDataType.addItem("3", "Num�rico", 0);
         cmbWWPFormElementDataType.addItem("4", "Data", 0);
         cmbWWPFormElementDataType.addItem("5", "Data e hora", 0);
         cmbWWPFormElementDataType.addItem("6", "Senha", 0);
         cmbWWPFormElementDataType.addItem("7", "Correio eletr�nico", 0);
         cmbWWPFormElementDataType.addItem("8", "URL", 0);
         cmbWWPFormElementDataType.addItem("9", "Arquivo", 0);
         cmbWWPFormElementDataType.addItem("10", "Imagem", 0);
         if ( cmbWWPFormElementDataType.ItemCount > 0 )
         {
         }
         GXCCtl = "WWPFORMINSTANCEELEMBOOLEAN_" + sGXsfl_48_idx;
         chkWWPFormInstanceElemBoolean.Name = GXCCtl;
         chkWWPFormInstanceElemBoolean.WebTags = "";
         chkWWPFormInstanceElemBoolean.Caption = "";
         AssignProp(sPrefix, false, chkWWPFormInstanceElemBoolean_Internalname, "TitleCaption", chkWWPFormInstanceElemBoolean.Caption, !bGXsfl_48_Refreshing);
         chkWWPFormInstanceElemBoolean.CheckedValue = "false";
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

      public void Valid_Wwpformversionnumber( )
      {
         /* Using cursor T000D18 */
         pr_default.execute(16, new Object[] {A94WWPFormId, A95WWPFormVersionNumber});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("N�o existe 'Dynamic Form'.", "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
         }
         A97WWPFormTitle = T000D18_A97WWPFormTitle[0];
         A104WWPFormResume = T000D18_A104WWPFormResume[0];
         A121WWPFormValidations = T000D18_A121WWPFormValidations[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A97WWPFormTitle", A97WWPFormTitle);
         AssignAttri(sPrefix, false, "A104WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(A104WWPFormResume), 1, 0, ".", "")));
         AssignAttri(sPrefix, false, "A121WWPFormValidations", A121WWPFormValidations);
      }

      public void Valid_Wwpformelementid( )
      {
         n99WWPFormElementParentId = false;
         A106WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementDataType.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormElementDataType.CurrentValue = StringUtil.LTrimStr( (decimal)(A106WWPFormElementDataType), 2, 0);
         /* Using cursor T000D28 */
         pr_default.execute(26, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, A98WWPFormElementId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("N�o existe 'Element'.", "ForeignKeyNotFound", 1, "WWPFORMELEMENTID");
            AnyError = 1;
            GX_FocusControl = edtWWPFormElementId_Internalname;
         }
         A117WWPFormElementTitle = T000D28_A117WWPFormElementTitle[0];
         A101WWPFormElementReferenceId = T000D28_A101WWPFormElementReferenceId[0];
         A106WWPFormElementDataType = T000D28_A106WWPFormElementDataType[0];
         cmbWWPFormElementDataType.CurrentValue = StringUtil.LTrimStr( (decimal)(A106WWPFormElementDataType), 2, 0);
         A105WWPFormElementType = T000D28_A105WWPFormElementType[0];
         A124WWPFormElementMetadata = T000D28_A124WWPFormElementMetadata[0];
         A125WWPFormElementCaption = T000D28_A125WWPFormElementCaption[0];
         A99WWPFormElementParentId = T000D28_A99WWPFormElementParentId[0];
         n99WWPFormElementParentId = T000D28_n99WWPFormElementParentId[0];
         pr_default.close(26);
         /* Using cursor T000D29 */
         pr_default.execute(27, new Object[] {A94WWPFormId, A95WWPFormVersionNumber, n99WWPFormElementParentId, A99WWPFormElementParentId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            if ( ! ( (0==A94WWPFormId) || (0==A95WWPFormVersionNumber) || (0==A99WWPFormElementParentId) ) )
            {
               GX_msglist.addItem("N�o existe 'WWPForm Element Parent'.", "ForeignKeyNotFound", 1, "WWPFORMELEMENTPARENTID");
               AnyError = 1;
               GX_FocusControl = edtWWPFormId_Internalname;
            }
         }
         A118WWPFormElementParentType = T000D29_A118WWPFormElementParentType[0];
         pr_default.close(27);
         dynload_actions( ) ;
         if ( cmbWWPFormElementDataType.ItemCount > 0 )
         {
            A106WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormElementDataType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A106WWPFormElementDataType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPFormElementDataType.CurrentValue = StringUtil.LTrimStr( (decimal)(A106WWPFormElementDataType), 2, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormElementDataType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106WWPFormElementDataType), 2, 0));
         }
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A117WWPFormElementTitle", A117WWPFormElementTitle);
         AssignAttri(sPrefix, false, "A101WWPFormElementReferenceId", A101WWPFormElementReferenceId);
         AssignAttri(sPrefix, false, "A106WWPFormElementDataType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106WWPFormElementDataType), 2, 0, ".", "")));
         cmbWWPFormElementDataType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A106WWPFormElementDataType), 2, 0));
         AssignProp(sPrefix, false, cmbWWPFormElementDataType_Internalname, "Values", cmbWWPFormElementDataType.ToJavascriptSource(), true);
         AssignAttri(sPrefix, false, "A105WWPFormElementType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A105WWPFormElementType), 1, 0, ".", "")));
         AssignAttri(sPrefix, false, "A124WWPFormElementMetadata", A124WWPFormElementMetadata);
         AssignAttri(sPrefix, false, "A125WWPFormElementCaption", StringUtil.LTrim( StringUtil.NToC( (decimal)(A125WWPFormElementCaption), 1, 0, ".", "")));
         AssignAttri(sPrefix, false, "A99WWPFormElementParentId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A99WWPFormElementParentId), 4, 0, ".", "")));
         AssignAttri(sPrefix, false, "A118WWPFormElementParentType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WWPFormElementParentType), 1, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"componentprocess","iparms":[{"postForm":true},{"sPrefix":true},{"sSFPrefix":true},{"sCompEvt":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"AV7WWPFormInstanceId","fld":"vWWPFORMINSTANCEID","pic":"ZZZZZ9","type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV11Insert_WWPFormId","fld":"vINSERT_WWPFORMID","pic":"ZZZ9","type":"int"},{"av":"AV12Insert_WWPFormVersionNumber","fld":"vINSERT_WWPFORMVERSIONNUMBER","pic":"ZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120D2","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMINSTANCEID","""{"handler":"Valid_Wwpforminstanceid","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[{"av":"A94WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","type":"int"},{"av":"A95WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","type":"int"},{"av":"A97WWPFormTitle","fld":"WWPFORMTITLE","type":"svchar"},{"av":"A104WWPFormResume","fld":"WWPFORMRESUME","pic":"9","type":"int"},{"av":"A121WWPFormValidations","fld":"WWPFORMVALIDATIONS","type":"vchar"}]""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER",""","oparms":[{"av":"A97WWPFormTitle","fld":"WWPFORMTITLE","type":"svchar"},{"av":"A104WWPFormResume","fld":"WWPFORMRESUME","pic":"9","type":"int"},{"av":"A121WWPFormValidations","fld":"WWPFORMVALIDATIONS","type":"vchar"}]}""");
         setEventMetadata("VALID_WWPFORMELEMENTID","""{"handler":"Valid_Wwpformelementid","iparms":[{"av":"A94WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","type":"int"},{"av":"A95WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","type":"int"},{"av":"A98WWPFormElementId","fld":"WWPFORMELEMENTID","pic":"ZZZ9","type":"int"},{"av":"A99WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9","type":"int"},{"av":"A117WWPFormElementTitle","fld":"WWPFORMELEMENTTITLE","type":"vchar"},{"av":"A101WWPFormElementReferenceId","fld":"WWPFORMELEMENTREFERENCEID","type":"svchar"},{"av":"cmbWWPFormElementDataType"},{"av":"A106WWPFormElementDataType","fld":"WWPFORMELEMENTDATATYPE","pic":"Z9","type":"int"},{"av":"A105WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9","type":"int"},{"av":"A124WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA","type":"vchar"},{"av":"A125WWPFormElementCaption","fld":"WWPFORMELEMENTCAPTION","pic":"9","type":"int"},{"av":"A118WWPFormElementParentType","fld":"WWPFORMELEMENTPARENTTYPE","pic":"9","type":"int"}]""");
         setEventMetadata("VALID_WWPFORMELEMENTID",""","oparms":[{"av":"A117WWPFormElementTitle","fld":"WWPFORMELEMENTTITLE","type":"vchar"},{"av":"A101WWPFormElementReferenceId","fld":"WWPFORMELEMENTREFERENCEID","type":"svchar"},{"av":"cmbWWPFormElementDataType"},{"av":"A106WWPFormElementDataType","fld":"WWPFORMELEMENTDATATYPE","pic":"Z9","type":"int"},{"av":"A105WWPFormElementType","fld":"WWPFORMELEMENTTYPE","pic":"9","type":"int"},{"av":"A124WWPFormElementMetadata","fld":"WWPFORMELEMENTMETADATA","type":"vchar"},{"av":"A125WWPFormElementCaption","fld":"WWPFORMELEMENTCAPTION","pic":"9","type":"int"},{"av":"A99WWPFormElementParentId","fld":"WWPFORMELEMENTPARENTID","pic":"ZZZ9","type":"int"},{"av":"A118WWPFormElementParentType","fld":"WWPFORMELEMENTPARENTTYPE","pic":"9","type":"int"}]}""");
         setEventMetadata("VALID_WWPFORMINSTANCEELEMENTID","""{"handler":"Valid_Wwpforminstanceelementid","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMELEMENTPARENTID","""{"handler":"Valid_Wwpformelementparentid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Wwpforminstanceelemblobfiletype","iparms":[]}""");
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
         pr_default.close(26);
         pr_default.close(27);
         pr_default.close(5);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z127WWPFormInstanceDate = DateTime.MinValue;
         Z108WWPFormInstanceElemDate = DateTime.MinValue;
         Z115WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
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
         A127WWPFormInstanceDate = DateTime.MinValue;
         A97WWPFormTitle = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_elementContainer = new GXWebGrid( context);
         sMode16 = "";
         sStyleString = "";
         Gx_date = DateTime.MinValue;
         A293WWPFormInstanceRecordKey = "";
         A121WWPFormValidations = "";
         AV16Pgmname = "";
         A124WWPFormElementMetadata = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode15 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A117WWPFormElementTitle = "";
         A109WWPFormInstanceElemChar = "";
         A108WWPFormInstanceElemDate = DateTime.MinValue;
         A111WWPFormInstanceElemBlob = "";
         A101WWPFormElementReferenceId = "";
         A115WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         A113WWPFormInstanceElemBlobFileName = "";
         A112WWPFormInstanceElemBlobFileType = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z293WWPFormInstanceRecordKey = "";
         Z97WWPFormTitle = "";
         Z121WWPFormValidations = "";
         T000D8_A97WWPFormTitle = new string[] {""} ;
         T000D8_A104WWPFormResume = new short[1] ;
         T000D8_A121WWPFormValidations = new string[] {""} ;
         T000D9_A102WWPFormInstanceId = new int[1] ;
         T000D9_A127WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         T000D9_A97WWPFormTitle = new string[] {""} ;
         T000D9_A104WWPFormResume = new short[1] ;
         T000D9_A121WWPFormValidations = new string[] {""} ;
         T000D9_A293WWPFormInstanceRecordKey = new string[] {""} ;
         T000D9_n293WWPFormInstanceRecordKey = new bool[] {false} ;
         T000D9_A94WWPFormId = new short[1] ;
         T000D9_A95WWPFormVersionNumber = new short[1] ;
         T000D10_A97WWPFormTitle = new string[] {""} ;
         T000D10_A104WWPFormResume = new short[1] ;
         T000D10_A121WWPFormValidations = new string[] {""} ;
         T000D11_A102WWPFormInstanceId = new int[1] ;
         T000D7_A102WWPFormInstanceId = new int[1] ;
         T000D7_A127WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         T000D7_A293WWPFormInstanceRecordKey = new string[] {""} ;
         T000D7_n293WWPFormInstanceRecordKey = new bool[] {false} ;
         T000D7_A94WWPFormId = new short[1] ;
         T000D7_A95WWPFormVersionNumber = new short[1] ;
         T000D12_A102WWPFormInstanceId = new int[1] ;
         T000D13_A102WWPFormInstanceId = new int[1] ;
         T000D6_A102WWPFormInstanceId = new int[1] ;
         T000D6_A127WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         T000D6_A293WWPFormInstanceRecordKey = new string[] {""} ;
         T000D6_n293WWPFormInstanceRecordKey = new bool[] {false} ;
         T000D6_A94WWPFormId = new short[1] ;
         T000D6_A95WWPFormVersionNumber = new short[1] ;
         T000D15_A102WWPFormInstanceId = new int[1] ;
         T000D18_A97WWPFormTitle = new string[] {""} ;
         T000D18_A104WWPFormResume = new short[1] ;
         T000D18_A121WWPFormValidations = new string[] {""} ;
         T000D19_A102WWPFormInstanceId = new int[1] ;
         Z109WWPFormInstanceElemChar = "";
         Z111WWPFormInstanceElemBlob = "";
         Z112WWPFormInstanceElemBlobFileType = "";
         Z113WWPFormInstanceElemBlobFileName = "";
         Z117WWPFormElementTitle = "";
         Z101WWPFormElementReferenceId = "";
         Z124WWPFormElementMetadata = "";
         T000D20_A94WWPFormId = new short[1] ;
         T000D20_A95WWPFormVersionNumber = new short[1] ;
         T000D20_A102WWPFormInstanceId = new int[1] ;
         T000D20_A103WWPFormInstanceElementId = new short[1] ;
         T000D20_A117WWPFormElementTitle = new string[] {""} ;
         T000D20_A101WWPFormElementReferenceId = new string[] {""} ;
         T000D20_A106WWPFormElementDataType = new short[1] ;
         T000D20_A118WWPFormElementParentType = new short[1] ;
         T000D20_A105WWPFormElementType = new short[1] ;
         T000D20_A124WWPFormElementMetadata = new string[] {""} ;
         T000D20_A125WWPFormElementCaption = new short[1] ;
         T000D20_A109WWPFormInstanceElemChar = new string[] {""} ;
         T000D20_n109WWPFormInstanceElemChar = new bool[] {false} ;
         T000D20_A108WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         T000D20_n108WWPFormInstanceElemDate = new bool[] {false} ;
         T000D20_A115WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         T000D20_n115WWPFormInstanceElemDateTime = new bool[] {false} ;
         T000D20_A110WWPFormInstanceElemNumeric = new decimal[1] ;
         T000D20_n110WWPFormInstanceElemNumeric = new bool[] {false} ;
         T000D20_A114WWPFormInstanceElemBoolean = new bool[] {false} ;
         T000D20_n114WWPFormInstanceElemBoolean = new bool[] {false} ;
         T000D20_A112WWPFormInstanceElemBlobFileType = new string[] {""} ;
         T000D20_A113WWPFormInstanceElemBlobFileName = new string[] {""} ;
         T000D20_A98WWPFormElementId = new short[1] ;
         T000D20_A99WWPFormElementParentId = new short[1] ;
         T000D20_n99WWPFormElementParentId = new bool[] {false} ;
         T000D20_A111WWPFormInstanceElemBlob = new string[] {""} ;
         T000D20_n111WWPFormInstanceElemBlob = new bool[] {false} ;
         T000D4_A94WWPFormId = new short[1] ;
         T000D4_A95WWPFormVersionNumber = new short[1] ;
         T000D4_A117WWPFormElementTitle = new string[] {""} ;
         T000D4_A101WWPFormElementReferenceId = new string[] {""} ;
         T000D4_A106WWPFormElementDataType = new short[1] ;
         T000D4_A105WWPFormElementType = new short[1] ;
         T000D4_A124WWPFormElementMetadata = new string[] {""} ;
         T000D4_A125WWPFormElementCaption = new short[1] ;
         T000D4_A99WWPFormElementParentId = new short[1] ;
         T000D4_n99WWPFormElementParentId = new bool[] {false} ;
         T000D5_A118WWPFormElementParentType = new short[1] ;
         T000D21_A94WWPFormId = new short[1] ;
         T000D21_A95WWPFormVersionNumber = new short[1] ;
         T000D21_A117WWPFormElementTitle = new string[] {""} ;
         T000D21_A101WWPFormElementReferenceId = new string[] {""} ;
         T000D21_A106WWPFormElementDataType = new short[1] ;
         T000D21_A105WWPFormElementType = new short[1] ;
         T000D21_A124WWPFormElementMetadata = new string[] {""} ;
         T000D21_A125WWPFormElementCaption = new short[1] ;
         T000D21_A99WWPFormElementParentId = new short[1] ;
         T000D21_n99WWPFormElementParentId = new bool[] {false} ;
         T000D22_A118WWPFormElementParentType = new short[1] ;
         T000D23_A102WWPFormInstanceId = new int[1] ;
         T000D23_A98WWPFormElementId = new short[1] ;
         T000D23_A103WWPFormInstanceElementId = new short[1] ;
         T000D3_A102WWPFormInstanceId = new int[1] ;
         T000D3_A103WWPFormInstanceElementId = new short[1] ;
         T000D3_A109WWPFormInstanceElemChar = new string[] {""} ;
         T000D3_n109WWPFormInstanceElemChar = new bool[] {false} ;
         T000D3_A108WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         T000D3_n108WWPFormInstanceElemDate = new bool[] {false} ;
         T000D3_A115WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         T000D3_n115WWPFormInstanceElemDateTime = new bool[] {false} ;
         T000D3_A110WWPFormInstanceElemNumeric = new decimal[1] ;
         T000D3_n110WWPFormInstanceElemNumeric = new bool[] {false} ;
         T000D3_A114WWPFormInstanceElemBoolean = new bool[] {false} ;
         T000D3_n114WWPFormInstanceElemBoolean = new bool[] {false} ;
         T000D3_A112WWPFormInstanceElemBlobFileType = new string[] {""} ;
         T000D3_A113WWPFormInstanceElemBlobFileName = new string[] {""} ;
         T000D3_A98WWPFormElementId = new short[1] ;
         T000D3_A111WWPFormInstanceElemBlob = new string[] {""} ;
         T000D3_n111WWPFormInstanceElemBlob = new bool[] {false} ;
         T000D2_A102WWPFormInstanceId = new int[1] ;
         T000D2_A103WWPFormInstanceElementId = new short[1] ;
         T000D2_A109WWPFormInstanceElemChar = new string[] {""} ;
         T000D2_n109WWPFormInstanceElemChar = new bool[] {false} ;
         T000D2_A108WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         T000D2_n108WWPFormInstanceElemDate = new bool[] {false} ;
         T000D2_A115WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         T000D2_n115WWPFormInstanceElemDateTime = new bool[] {false} ;
         T000D2_A110WWPFormInstanceElemNumeric = new decimal[1] ;
         T000D2_n110WWPFormInstanceElemNumeric = new bool[] {false} ;
         T000D2_A114WWPFormInstanceElemBoolean = new bool[] {false} ;
         T000D2_n114WWPFormInstanceElemBoolean = new bool[] {false} ;
         T000D2_A112WWPFormInstanceElemBlobFileType = new string[] {""} ;
         T000D2_A113WWPFormInstanceElemBlobFileName = new string[] {""} ;
         T000D2_A98WWPFormElementId = new short[1] ;
         T000D2_A111WWPFormInstanceElemBlob = new string[] {""} ;
         T000D2_n111WWPFormInstanceElemBlob = new bool[] {false} ;
         T000D28_A117WWPFormElementTitle = new string[] {""} ;
         T000D28_A101WWPFormElementReferenceId = new string[] {""} ;
         T000D28_A106WWPFormElementDataType = new short[1] ;
         T000D28_A105WWPFormElementType = new short[1] ;
         T000D28_A124WWPFormElementMetadata = new string[] {""} ;
         T000D28_A125WWPFormElementCaption = new short[1] ;
         T000D28_A99WWPFormElementParentId = new short[1] ;
         T000D28_n99WWPFormElementParentId = new bool[] {false} ;
         T000D29_A118WWPFormElementParentType = new short[1] ;
         T000D30_A102WWPFormInstanceId = new int[1] ;
         T000D30_A98WWPFormElementId = new short[1] ;
         T000D30_A103WWPFormInstanceElementId = new short[1] ;
         Gridlevel_elementRow = new GXWebRow();
         subGridlevel_element_Linesclass = "";
         ROClassString = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i127WWPFormInstanceDate = DateTime.MinValue;
         sCtrlGx_mode = "";
         sCtrlAV7WWPFormInstanceId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         Gridlevel_elementColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_forminstance__default(),
            new Object[][] {
                new Object[] {
               T000D2_A102WWPFormInstanceId, T000D2_A103WWPFormInstanceElementId, T000D2_A109WWPFormInstanceElemChar, T000D2_n109WWPFormInstanceElemChar, T000D2_A108WWPFormInstanceElemDate, T000D2_n108WWPFormInstanceElemDate, T000D2_A115WWPFormInstanceElemDateTime, T000D2_n115WWPFormInstanceElemDateTime, T000D2_A110WWPFormInstanceElemNumeric, T000D2_n110WWPFormInstanceElemNumeric,
               T000D2_A114WWPFormInstanceElemBoolean, T000D2_n114WWPFormInstanceElemBoolean, T000D2_A112WWPFormInstanceElemBlobFileType, T000D2_A113WWPFormInstanceElemBlobFileName, T000D2_A98WWPFormElementId, T000D2_A111WWPFormInstanceElemBlob, T000D2_n111WWPFormInstanceElemBlob
               }
               , new Object[] {
               T000D3_A102WWPFormInstanceId, T000D3_A103WWPFormInstanceElementId, T000D3_A109WWPFormInstanceElemChar, T000D3_n109WWPFormInstanceElemChar, T000D3_A108WWPFormInstanceElemDate, T000D3_n108WWPFormInstanceElemDate, T000D3_A115WWPFormInstanceElemDateTime, T000D3_n115WWPFormInstanceElemDateTime, T000D3_A110WWPFormInstanceElemNumeric, T000D3_n110WWPFormInstanceElemNumeric,
               T000D3_A114WWPFormInstanceElemBoolean, T000D3_n114WWPFormInstanceElemBoolean, T000D3_A112WWPFormInstanceElemBlobFileType, T000D3_A113WWPFormInstanceElemBlobFileName, T000D3_A98WWPFormElementId, T000D3_A111WWPFormInstanceElemBlob, T000D3_n111WWPFormInstanceElemBlob
               }
               , new Object[] {
               T000D4_A94WWPFormId, T000D4_A95WWPFormVersionNumber, T000D4_A117WWPFormElementTitle, T000D4_A101WWPFormElementReferenceId, T000D4_A106WWPFormElementDataType, T000D4_A105WWPFormElementType, T000D4_A124WWPFormElementMetadata, T000D4_A125WWPFormElementCaption, T000D4_A99WWPFormElementParentId, T000D4_n99WWPFormElementParentId
               }
               , new Object[] {
               T000D5_A118WWPFormElementParentType
               }
               , new Object[] {
               T000D6_A102WWPFormInstanceId, T000D6_A127WWPFormInstanceDate, T000D6_A293WWPFormInstanceRecordKey, T000D6_n293WWPFormInstanceRecordKey, T000D6_A94WWPFormId, T000D6_A95WWPFormVersionNumber
               }
               , new Object[] {
               T000D7_A102WWPFormInstanceId, T000D7_A127WWPFormInstanceDate, T000D7_A293WWPFormInstanceRecordKey, T000D7_n293WWPFormInstanceRecordKey, T000D7_A94WWPFormId, T000D7_A95WWPFormVersionNumber
               }
               , new Object[] {
               T000D8_A97WWPFormTitle, T000D8_A104WWPFormResume, T000D8_A121WWPFormValidations
               }
               , new Object[] {
               T000D9_A102WWPFormInstanceId, T000D9_A127WWPFormInstanceDate, T000D9_A97WWPFormTitle, T000D9_A104WWPFormResume, T000D9_A121WWPFormValidations, T000D9_A293WWPFormInstanceRecordKey, T000D9_n293WWPFormInstanceRecordKey, T000D9_A94WWPFormId, T000D9_A95WWPFormVersionNumber
               }
               , new Object[] {
               T000D10_A97WWPFormTitle, T000D10_A104WWPFormResume, T000D10_A121WWPFormValidations
               }
               , new Object[] {
               T000D11_A102WWPFormInstanceId
               }
               , new Object[] {
               T000D12_A102WWPFormInstanceId
               }
               , new Object[] {
               T000D13_A102WWPFormInstanceId
               }
               , new Object[] {
               }
               , new Object[] {
               T000D15_A102WWPFormInstanceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000D18_A97WWPFormTitle, T000D18_A104WWPFormResume, T000D18_A121WWPFormValidations
               }
               , new Object[] {
               T000D19_A102WWPFormInstanceId
               }
               , new Object[] {
               T000D20_A94WWPFormId, T000D20_A95WWPFormVersionNumber, T000D20_A102WWPFormInstanceId, T000D20_A103WWPFormInstanceElementId, T000D20_A117WWPFormElementTitle, T000D20_A101WWPFormElementReferenceId, T000D20_A106WWPFormElementDataType, T000D20_A118WWPFormElementParentType, T000D20_A105WWPFormElementType, T000D20_A124WWPFormElementMetadata,
               T000D20_A125WWPFormElementCaption, T000D20_A109WWPFormInstanceElemChar, T000D20_n109WWPFormInstanceElemChar, T000D20_A108WWPFormInstanceElemDate, T000D20_n108WWPFormInstanceElemDate, T000D20_A115WWPFormInstanceElemDateTime, T000D20_n115WWPFormInstanceElemDateTime, T000D20_A110WWPFormInstanceElemNumeric, T000D20_n110WWPFormInstanceElemNumeric, T000D20_A114WWPFormInstanceElemBoolean,
               T000D20_n114WWPFormInstanceElemBoolean, T000D20_A112WWPFormInstanceElemBlobFileType, T000D20_A113WWPFormInstanceElemBlobFileName, T000D20_A98WWPFormElementId, T000D20_A99WWPFormElementParentId, T000D20_n99WWPFormElementParentId, T000D20_A111WWPFormInstanceElemBlob, T000D20_n111WWPFormInstanceElemBlob
               }
               , new Object[] {
               T000D21_A94WWPFormId, T000D21_A95WWPFormVersionNumber, T000D21_A117WWPFormElementTitle, T000D21_A101WWPFormElementReferenceId, T000D21_A106WWPFormElementDataType, T000D21_A105WWPFormElementType, T000D21_A124WWPFormElementMetadata, T000D21_A125WWPFormElementCaption, T000D21_A99WWPFormElementParentId, T000D21_n99WWPFormElementParentId
               }
               , new Object[] {
               T000D22_A118WWPFormElementParentType
               }
               , new Object[] {
               T000D23_A102WWPFormInstanceId, T000D23_A98WWPFormElementId, T000D23_A103WWPFormInstanceElementId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000D28_A117WWPFormElementTitle, T000D28_A101WWPFormElementReferenceId, T000D28_A106WWPFormElementDataType, T000D28_A105WWPFormElementType, T000D28_A124WWPFormElementMetadata, T000D28_A125WWPFormElementCaption, T000D28_A99WWPFormElementParentId, T000D28_n99WWPFormElementParentId
               }
               , new Object[] {
               T000D29_A118WWPFormElementParentType
               }
               , new Object[] {
               T000D30_A102WWPFormInstanceId, T000D30_A98WWPFormElementId, T000D30_A103WWPFormInstanceElementId
               }
            }
         );
         AV16Pgmname = "WorkWithPlus.DynamicForms.WWP_FormInstance";
         Z127WWPFormInstanceDate = DateTime.MinValue;
         A127WWPFormInstanceDate = DateTime.MinValue;
         i127WWPFormInstanceDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short Z94WWPFormId ;
      private short Z95WWPFormVersionNumber ;
      private short N94WWPFormId ;
      private short N95WWPFormVersionNumber ;
      private short Z98WWPFormElementId ;
      private short Z103WWPFormInstanceElementId ;
      private short nRcdDeleted_16 ;
      private short nRcdExists_16 ;
      private short nIsMod_16 ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A94WWPFormId ;
      private short A95WWPFormVersionNumber ;
      private short A98WWPFormElementId ;
      private short A99WWPFormElementParentId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount16 ;
      private short RcdFound16 ;
      private short nBlankRcdUsr16 ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV11Insert_WWPFormId ;
      private short AV12Insert_WWPFormVersionNumber ;
      private short Gx_BScreen ;
      private short A104WWPFormResume ;
      private short A105WWPFormElementType ;
      private short A125WWPFormElementCaption ;
      private short A118WWPFormElementParentType ;
      private short RcdFound15 ;
      private short A103WWPFormInstanceElementId ;
      private short A106WWPFormElementDataType ;
      private short Z104WWPFormResume ;
      private short Z106WWPFormElementDataType ;
      private short Z105WWPFormElementType ;
      private short Z125WWPFormElementCaption ;
      private short Z99WWPFormElementParentId ;
      private short Z118WWPFormElementParentType ;
      private short nIsDirty_16 ;
      private short subGridlevel_element_Backcolorstyle ;
      private short subGridlevel_element_Backstyle ;
      private short subGridlevel_element_Allowselection ;
      private short subGridlevel_element_Allowhovering ;
      private short subGridlevel_element_Allowcollapsing ;
      private short subGridlevel_element_Collapsed ;
      private int wcpOAV7WWPFormInstanceId ;
      private int Z102WWPFormInstanceId ;
      private int nRC_GXsfl_48 ;
      private int nGXsfl_48_idx=1 ;
      private int AV7WWPFormInstanceId ;
      private int trnEnded ;
      private int A102WWPFormInstanceId ;
      private int edtWWPFormInstanceId_Enabled ;
      private int edtWWPFormInstanceDate_Enabled ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtWWPFormElementId_Enabled ;
      private int edtWWPFormInstanceElementId_Enabled ;
      private int edtWWPFormElementTitle_Enabled ;
      private int edtWWPFormInstanceElemChar_Enabled ;
      private int edtWWPFormInstanceElemDate_Enabled ;
      private int edtWWPFormInstanceElemNumeric_Enabled ;
      private int edtWWPFormInstanceElemBlob_Enabled ;
      private int edtWWPFormElementReferenceId_Enabled ;
      private int edtWWPFormElementParentId_Enabled ;
      private int edtWWPFormInstanceElemDateTime_Enabled ;
      private int edtWWPFormInstanceElemBlobFileName_Enabled ;
      private int edtWWPFormInstanceElemBlobFileType_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV17GXV1 ;
      private int subGridlevel_element_Backcolor ;
      private int subGridlevel_element_Allbackcolor ;
      private int defedtWWPFormInstanceElementId_Enabled ;
      private int defedtWWPFormElementId_Enabled ;
      private int idxLst ;
      private int subGridlevel_element_Selectedindex ;
      private int subGridlevel_element_Selectioncolor ;
      private int subGridlevel_element_Hoveringcolor ;
      private long GRIDLEVEL_ELEMENT_nFirstRecordOnPage ;
      private decimal Z110WWPFormInstanceElemNumeric ;
      private decimal A110WWPFormInstanceElemNumeric ;
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
      private string edtWWPFormInstanceDate_Internalname ;
      private string sGXsfl_48_idx="0001" ;
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
      private string edtWWPFormInstanceId_Internalname ;
      private string TempTags ;
      private string edtWWPFormInstanceId_Jsonclick ;
      private string edtWWPFormInstanceDate_Jsonclick ;
      private string edtWWPFormId_Internalname ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormTitle_Internalname ;
      private string edtWWPFormTitle_Jsonclick ;
      private string divTableleaflevel_element_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode16 ;
      private string edtWWPFormElementId_Internalname ;
      private string edtWWPFormInstanceElementId_Internalname ;
      private string edtWWPFormElementTitle_Internalname ;
      private string cmbWWPFormElementDataType_Internalname ;
      private string edtWWPFormInstanceElemChar_Internalname ;
      private string edtWWPFormInstanceElemDate_Internalname ;
      private string edtWWPFormInstanceElemNumeric_Internalname ;
      private string edtWWPFormInstanceElemBlob_Internalname ;
      private string chkWWPFormInstanceElemBoolean_Internalname ;
      private string edtWWPFormElementReferenceId_Internalname ;
      private string edtWWPFormElementParentId_Internalname ;
      private string edtWWPFormInstanceElemDateTime_Internalname ;
      private string edtWWPFormInstanceElemBlobFileName_Internalname ;
      private string edtWWPFormInstanceElemBlobFileType_Internalname ;
      private string sStyleString ;
      private string subGridlevel_element_Internalname ;
      private string AV16Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode15 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string edtWWPFormInstanceElemBlob_Filetype ;
      private string edtWWPFormInstanceElemBlob_Filename ;
      private string sGXsfl_48_fel_idx="0001" ;
      private string subGridlevel_element_Class ;
      private string subGridlevel_element_Linesclass ;
      private string ROClassString ;
      private string edtWWPFormElementId_Jsonclick ;
      private string edtWWPFormInstanceElementId_Jsonclick ;
      private string edtWWPFormElementTitle_Jsonclick ;
      private string cmbWWPFormElementDataType_Jsonclick ;
      private string edtWWPFormInstanceElemChar_Jsonclick ;
      private string edtWWPFormInstanceElemDate_Jsonclick ;
      private string edtWWPFormInstanceElemNumeric_Jsonclick ;
      private string edtWWPFormInstanceElemBlob_Contenttype ;
      private string edtWWPFormInstanceElemBlob_Parameters ;
      private string edtWWPFormInstanceElemBlob_Jsonclick ;
      private string edtWWPFormElementReferenceId_Jsonclick ;
      private string edtWWPFormElementParentId_Jsonclick ;
      private string edtWWPFormInstanceElemDateTime_Jsonclick ;
      private string edtWWPFormInstanceElemBlobFileName_Jsonclick ;
      private string edtWWPFormInstanceElemBlobFileType_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string sCtrlGx_mode ;
      private string sCtrlAV7WWPFormInstanceId ;
      private string subGridlevel_element_Header ;
      private DateTime Z115WWPFormInstanceElemDateTime ;
      private DateTime A115WWPFormInstanceElemDateTime ;
      private DateTime Z127WWPFormInstanceDate ;
      private DateTime Z108WWPFormInstanceElemDate ;
      private DateTime A127WWPFormInstanceDate ;
      private DateTime Gx_date ;
      private DateTime A108WWPFormInstanceElemDate ;
      private DateTime i127WWPFormInstanceDate ;
      private bool Z114WWPFormInstanceElemBoolean ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n99WWPFormElementParentId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_48_Refreshing=false ;
      private bool n293WWPFormInstanceRecordKey ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool A114WWPFormInstanceElemBoolean ;
      private bool returnInSub ;
      private bool n109WWPFormInstanceElemChar ;
      private bool n108WWPFormInstanceElemDate ;
      private bool n115WWPFormInstanceElemDateTime ;
      private bool n110WWPFormInstanceElemNumeric ;
      private bool n114WWPFormInstanceElemBoolean ;
      private bool n111WWPFormInstanceElemBlob ;
      private string A293WWPFormInstanceRecordKey ;
      private string A121WWPFormValidations ;
      private string A124WWPFormElementMetadata ;
      private string A117WWPFormElementTitle ;
      private string A109WWPFormInstanceElemChar ;
      private string Z293WWPFormInstanceRecordKey ;
      private string Z121WWPFormValidations ;
      private string Z109WWPFormInstanceElemChar ;
      private string Z117WWPFormElementTitle ;
      private string Z124WWPFormElementMetadata ;
      private string A97WWPFormTitle ;
      private string A101WWPFormElementReferenceId ;
      private string A113WWPFormInstanceElemBlobFileName ;
      private string A112WWPFormInstanceElemBlobFileType ;
      private string Z97WWPFormTitle ;
      private string Z112WWPFormInstanceElemBlobFileType ;
      private string Z113WWPFormInstanceElemBlobFileName ;
      private string Z101WWPFormElementReferenceId ;
      private string A111WWPFormInstanceElemBlob ;
      private string Z111WWPFormInstanceElemBlob ;
      private IGxSession AV10WebSession ;
      private GxFile gxblobfileaux ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_elementContainer ;
      private GXWebRow Gridlevel_elementRow ;
      private GXWebColumn Gridlevel_elementColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPFormElementDataType ;
      private GXCheckbox chkWWPFormInstanceElemBoolean ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000D8_A97WWPFormTitle ;
      private short[] T000D8_A104WWPFormResume ;
      private string[] T000D8_A121WWPFormValidations ;
      private int[] T000D9_A102WWPFormInstanceId ;
      private DateTime[] T000D9_A127WWPFormInstanceDate ;
      private string[] T000D9_A97WWPFormTitle ;
      private short[] T000D9_A104WWPFormResume ;
      private string[] T000D9_A121WWPFormValidations ;
      private string[] T000D9_A293WWPFormInstanceRecordKey ;
      private bool[] T000D9_n293WWPFormInstanceRecordKey ;
      private short[] T000D9_A94WWPFormId ;
      private short[] T000D9_A95WWPFormVersionNumber ;
      private string[] T000D10_A97WWPFormTitle ;
      private short[] T000D10_A104WWPFormResume ;
      private string[] T000D10_A121WWPFormValidations ;
      private int[] T000D11_A102WWPFormInstanceId ;
      private int[] T000D7_A102WWPFormInstanceId ;
      private DateTime[] T000D7_A127WWPFormInstanceDate ;
      private string[] T000D7_A293WWPFormInstanceRecordKey ;
      private bool[] T000D7_n293WWPFormInstanceRecordKey ;
      private short[] T000D7_A94WWPFormId ;
      private short[] T000D7_A95WWPFormVersionNumber ;
      private int[] T000D12_A102WWPFormInstanceId ;
      private int[] T000D13_A102WWPFormInstanceId ;
      private int[] T000D6_A102WWPFormInstanceId ;
      private DateTime[] T000D6_A127WWPFormInstanceDate ;
      private string[] T000D6_A293WWPFormInstanceRecordKey ;
      private bool[] T000D6_n293WWPFormInstanceRecordKey ;
      private short[] T000D6_A94WWPFormId ;
      private short[] T000D6_A95WWPFormVersionNumber ;
      private int[] T000D15_A102WWPFormInstanceId ;
      private string[] T000D18_A97WWPFormTitle ;
      private short[] T000D18_A104WWPFormResume ;
      private string[] T000D18_A121WWPFormValidations ;
      private int[] T000D19_A102WWPFormInstanceId ;
      private short[] T000D20_A94WWPFormId ;
      private short[] T000D20_A95WWPFormVersionNumber ;
      private int[] T000D20_A102WWPFormInstanceId ;
      private short[] T000D20_A103WWPFormInstanceElementId ;
      private string[] T000D20_A117WWPFormElementTitle ;
      private string[] T000D20_A101WWPFormElementReferenceId ;
      private short[] T000D20_A106WWPFormElementDataType ;
      private short[] T000D20_A118WWPFormElementParentType ;
      private short[] T000D20_A105WWPFormElementType ;
      private string[] T000D20_A124WWPFormElementMetadata ;
      private short[] T000D20_A125WWPFormElementCaption ;
      private string[] T000D20_A109WWPFormInstanceElemChar ;
      private bool[] T000D20_n109WWPFormInstanceElemChar ;
      private DateTime[] T000D20_A108WWPFormInstanceElemDate ;
      private bool[] T000D20_n108WWPFormInstanceElemDate ;
      private DateTime[] T000D20_A115WWPFormInstanceElemDateTime ;
      private bool[] T000D20_n115WWPFormInstanceElemDateTime ;
      private decimal[] T000D20_A110WWPFormInstanceElemNumeric ;
      private bool[] T000D20_n110WWPFormInstanceElemNumeric ;
      private bool[] T000D20_A114WWPFormInstanceElemBoolean ;
      private bool[] T000D20_n114WWPFormInstanceElemBoolean ;
      private string[] T000D20_A112WWPFormInstanceElemBlobFileType ;
      private string[] T000D20_A113WWPFormInstanceElemBlobFileName ;
      private short[] T000D20_A98WWPFormElementId ;
      private short[] T000D20_A99WWPFormElementParentId ;
      private bool[] T000D20_n99WWPFormElementParentId ;
      private string[] T000D20_A111WWPFormInstanceElemBlob ;
      private bool[] T000D20_n111WWPFormInstanceElemBlob ;
      private short[] T000D4_A94WWPFormId ;
      private short[] T000D4_A95WWPFormVersionNumber ;
      private string[] T000D4_A117WWPFormElementTitle ;
      private string[] T000D4_A101WWPFormElementReferenceId ;
      private short[] T000D4_A106WWPFormElementDataType ;
      private short[] T000D4_A105WWPFormElementType ;
      private string[] T000D4_A124WWPFormElementMetadata ;
      private short[] T000D4_A125WWPFormElementCaption ;
      private short[] T000D4_A99WWPFormElementParentId ;
      private bool[] T000D4_n99WWPFormElementParentId ;
      private short[] T000D5_A118WWPFormElementParentType ;
      private short[] T000D21_A94WWPFormId ;
      private short[] T000D21_A95WWPFormVersionNumber ;
      private string[] T000D21_A117WWPFormElementTitle ;
      private string[] T000D21_A101WWPFormElementReferenceId ;
      private short[] T000D21_A106WWPFormElementDataType ;
      private short[] T000D21_A105WWPFormElementType ;
      private string[] T000D21_A124WWPFormElementMetadata ;
      private short[] T000D21_A125WWPFormElementCaption ;
      private short[] T000D21_A99WWPFormElementParentId ;
      private bool[] T000D21_n99WWPFormElementParentId ;
      private short[] T000D22_A118WWPFormElementParentType ;
      private int[] T000D23_A102WWPFormInstanceId ;
      private short[] T000D23_A98WWPFormElementId ;
      private short[] T000D23_A103WWPFormInstanceElementId ;
      private int[] T000D3_A102WWPFormInstanceId ;
      private short[] T000D3_A103WWPFormInstanceElementId ;
      private string[] T000D3_A109WWPFormInstanceElemChar ;
      private bool[] T000D3_n109WWPFormInstanceElemChar ;
      private DateTime[] T000D3_A108WWPFormInstanceElemDate ;
      private bool[] T000D3_n108WWPFormInstanceElemDate ;
      private DateTime[] T000D3_A115WWPFormInstanceElemDateTime ;
      private bool[] T000D3_n115WWPFormInstanceElemDateTime ;
      private decimal[] T000D3_A110WWPFormInstanceElemNumeric ;
      private bool[] T000D3_n110WWPFormInstanceElemNumeric ;
      private bool[] T000D3_A114WWPFormInstanceElemBoolean ;
      private bool[] T000D3_n114WWPFormInstanceElemBoolean ;
      private string[] T000D3_A112WWPFormInstanceElemBlobFileType ;
      private string[] T000D3_A113WWPFormInstanceElemBlobFileName ;
      private short[] T000D3_A98WWPFormElementId ;
      private string[] T000D3_A111WWPFormInstanceElemBlob ;
      private bool[] T000D3_n111WWPFormInstanceElemBlob ;
      private int[] T000D2_A102WWPFormInstanceId ;
      private short[] T000D2_A103WWPFormInstanceElementId ;
      private string[] T000D2_A109WWPFormInstanceElemChar ;
      private bool[] T000D2_n109WWPFormInstanceElemChar ;
      private DateTime[] T000D2_A108WWPFormInstanceElemDate ;
      private bool[] T000D2_n108WWPFormInstanceElemDate ;
      private DateTime[] T000D2_A115WWPFormInstanceElemDateTime ;
      private bool[] T000D2_n115WWPFormInstanceElemDateTime ;
      private decimal[] T000D2_A110WWPFormInstanceElemNumeric ;
      private bool[] T000D2_n110WWPFormInstanceElemNumeric ;
      private bool[] T000D2_A114WWPFormInstanceElemBoolean ;
      private bool[] T000D2_n114WWPFormInstanceElemBoolean ;
      private string[] T000D2_A112WWPFormInstanceElemBlobFileType ;
      private string[] T000D2_A113WWPFormInstanceElemBlobFileName ;
      private short[] T000D2_A98WWPFormElementId ;
      private string[] T000D2_A111WWPFormInstanceElemBlob ;
      private bool[] T000D2_n111WWPFormInstanceElemBlob ;
      private string[] T000D28_A117WWPFormElementTitle ;
      private string[] T000D28_A101WWPFormElementReferenceId ;
      private short[] T000D28_A106WWPFormElementDataType ;
      private short[] T000D28_A105WWPFormElementType ;
      private string[] T000D28_A124WWPFormElementMetadata ;
      private short[] T000D28_A125WWPFormElementCaption ;
      private short[] T000D28_A99WWPFormElementParentId ;
      private bool[] T000D28_n99WWPFormElementParentId ;
      private short[] T000D29_A118WWPFormElementParentType ;
      private int[] T000D30_A102WWPFormInstanceId ;
      private short[] T000D30_A98WWPFormElementId ;
      private short[] T000D30_A103WWPFormInstanceElementId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_forminstance__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new UpdateCursor(def[23])
         ,new UpdateCursor(def[24])
         ,new UpdateCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000D2;
          prmT000D2 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmT000D3;
          prmT000D3 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmT000D4;
          prmT000D4 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmT000D5;
          prmT000D5 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000D6;
          prmT000D6 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmT000D7;
          prmT000D7 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmT000D8;
          prmT000D8 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000D9;
          prmT000D9 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmT000D10;
          prmT000D10 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000D11;
          prmT000D11 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmT000D12;
          prmT000D12 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmT000D13;
          prmT000D13 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmT000D14;
          prmT000D14 = new Object[] {
          new ParDef("WWPFormInstanceDate",GXType.Date,8,0) ,
          new ParDef("WWPFormInstanceRecordKey",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000D15;
          prmT000D15 = new Object[] {
          };
          Object[] prmT000D16;
          prmT000D16 = new Object[] {
          new ParDef("WWPFormInstanceDate",GXType.Date,8,0) ,
          new ParDef("WWPFormInstanceRecordKey",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmT000D17;
          prmT000D17 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmT000D18;
          prmT000D18 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
          };
          Object[] prmT000D19;
          prmT000D19 = new Object[] {
          };
          Object[] prmT000D20;
          prmT000D20 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmT000D21;
          prmT000D21 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmT000D22;
          prmT000D22 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000D23;
          prmT000D23 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmT000D24;
          prmT000D24 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElemChar",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WWPFormInstanceElemDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("WWPFormInstanceElemDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("WWPFormInstanceElemNumeric",GXType.Number,18,5){Nullable=true} ,
          new ParDef("WWPFormInstanceElemBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("WWPFormInstanceElemBoolean",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("WWPFormInstanceElemBlobFileType",GXType.VarChar,40,0) ,
          new ParDef("WWPFormInstanceElemBlobFileName",GXType.VarChar,40,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmT000D25;
          prmT000D25 = new Object[] {
          new ParDef("WWPFormInstanceElemChar",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("WWPFormInstanceElemDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("WWPFormInstanceElemDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("WWPFormInstanceElemNumeric",GXType.Number,18,5){Nullable=true} ,
          new ParDef("WWPFormInstanceElemBoolean",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("WWPFormInstanceElemBlobFileType",GXType.VarChar,40,0) ,
          new ParDef("WWPFormInstanceElemBlobFileName",GXType.VarChar,40,0) ,
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmT000D26;
          prmT000D26 = new Object[] {
          new ParDef("WWPFormInstanceElemBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmT000D27;
          prmT000D27 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
          new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
          };
          Object[] prmT000D28;
          prmT000D28 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementId",GXType.Int16,4,0)
          };
          Object[] prmT000D29;
          prmT000D29 = new Object[] {
          new ParDef("WWPFormId",GXType.Int16,4,0) ,
          new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000D30;
          prmT000D30 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000D2", "SELECT WWPFormInstanceId, WWPFormInstanceElementId, WWPFormInstanceElemChar, WWPFormInstanceElemDate, WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric, WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileType, WWPFormInstanceElemBlobFileName, WWPFormElementId, WWPFormInstanceElemBlob FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId  FOR UPDATE OF WWP_FormInstanceElement NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D3", "SELECT WWPFormInstanceId, WWPFormInstanceElementId, WWPFormInstanceElemChar, WWPFormInstanceElemDate, WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric, WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileType, WWPFormInstanceElemBlobFileName, WWPFormElementId, WWPFormInstanceElemBlob FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D4", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementTitle, WWPFormElementReferenceId, WWPFormElementDataType, WWPFormElementType, WWPFormElementMetadata, WWPFormElementCaption, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D5", "SELECT WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D6", "SELECT WWPFormInstanceId, WWPFormInstanceDate, WWPFormInstanceRecordKey, WWPFormId, WWPFormVersionNumber FROM WWP_FormInstance WHERE WWPFormInstanceId = :WWPFormInstanceId  FOR UPDATE OF WWP_FormInstance NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000D6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D7", "SELECT WWPFormInstanceId, WWPFormInstanceDate, WWPFormInstanceRecordKey, WWPFormId, WWPFormVersionNumber FROM WWP_FormInstance WHERE WWPFormInstanceId = :WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D8", "SELECT WWPFormTitle, WWPFormResume, WWPFormValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D9", "SELECT TM1.WWPFormInstanceId, TM1.WWPFormInstanceDate, T2.WWPFormTitle, T2.WWPFormResume, T2.WWPFormValidations, TM1.WWPFormInstanceRecordKey, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (WWP_FormInstance TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.WWPFormInstanceId = :WWPFormInstanceId ORDER BY TM1.WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D10", "SELECT WWPFormTitle, WWPFormResume, WWPFormValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D11", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE WWPFormInstanceId = :WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D12", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE ( WWPFormInstanceId > :WWPFormInstanceId) ORDER BY WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000D13", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE ( WWPFormInstanceId < :WWPFormInstanceId) ORDER BY WWPFormInstanceId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000D14", "SAVEPOINT gxupdate;INSERT INTO WWP_FormInstance(WWPFormInstanceDate, WWPFormInstanceRecordKey, WWPFormId, WWPFormVersionNumber) VALUES(:WWPFormInstanceDate, :WWPFormInstanceRecordKey, :WWPFormId, :WWPFormVersionNumber);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000D14)
             ,new CursorDef("T000D15", "SELECT currval('WWPFormInstanceId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D16", "SAVEPOINT gxupdate;UPDATE WWP_FormInstance SET WWPFormInstanceDate=:WWPFormInstanceDate, WWPFormInstanceRecordKey=:WWPFormInstanceRecordKey, WWPFormId=:WWPFormId, WWPFormVersionNumber=:WWPFormVersionNumber  WHERE WWPFormInstanceId = :WWPFormInstanceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000D16)
             ,new CursorDef("T000D17", "SAVEPOINT gxupdate;DELETE FROM WWP_FormInstance  WHERE WWPFormInstanceId = :WWPFormInstanceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000D17)
             ,new CursorDef("T000D18", "SELECT WWPFormTitle, WWPFormResume, WWPFormValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D19", "SELECT WWPFormInstanceId FROM WWP_FormInstance ORDER BY WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D19,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D20", "SELECT T2.WWPFormId, T2.WWPFormVersionNumber, T1.WWPFormInstanceId, T1.WWPFormInstanceElementId, T2.WWPFormElementTitle, T2.WWPFormElementReferenceId, T2.WWPFormElementDataType, T3.WWPFormElementType AS WWPFormElementParentType, T2.WWPFormElementType, T2.WWPFormElementMetadata, T2.WWPFormElementCaption, T1.WWPFormInstanceElemChar, T1.WWPFormInstanceElemDate, T1.WWPFormInstanceElemDateTime, T1.WWPFormInstanceElemNumeric, T1.WWPFormInstanceElemBoolean, T1.WWPFormInstanceElemBlobFileType, T1.WWPFormInstanceElemBlobFileName, T1.WWPFormElementId, T2.WWPFormElementParentId AS WWPFormElementParentId, T1.WWPFormInstanceElemBlob FROM ((WWP_FormInstanceElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = :WWPFormId AND T2.WWPFormVersionNumber = :WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementId) LEFT JOIN WWP_FormElement T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber AND T3.WWPFormElementId = T2.WWPFormElementParentId) WHERE T1.WWPFormInstanceId = :WWPFormInstanceId and T1.WWPFormInstanceElementId = :WWPFormInstanceElementId and T1.WWPFormElementId = :WWPFormElementId ORDER BY T1.WWPFormInstanceId, T1.WWPFormElementId, T1.WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D20,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D21", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementTitle, WWPFormElementReferenceId, WWPFormElementDataType, WWPFormElementType, WWPFormElementMetadata, WWPFormElementCaption, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D22", "SELECT WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D23", "SELECT WWPFormInstanceId, WWPFormElementId, WWPFormInstanceElementId FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D24", "SAVEPOINT gxupdate;INSERT INTO WWP_FormInstanceElement(WWPFormInstanceId, WWPFormInstanceElementId, WWPFormInstanceElemChar, WWPFormInstanceElemDate, WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric, WWPFormInstanceElemBlob, WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileType, WWPFormInstanceElemBlobFileName, WWPFormElementId) VALUES(:WWPFormInstanceId, :WWPFormInstanceElementId, :WWPFormInstanceElemChar, :WWPFormInstanceElemDate, :WWPFormInstanceElemDateTime, :WWPFormInstanceElemNumeric, :WWPFormInstanceElemBlob, :WWPFormInstanceElemBoolean, :WWPFormInstanceElemBlobFileType, :WWPFormInstanceElemBlobFileName, :WWPFormElementId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000D24)
             ,new CursorDef("T000D25", "SAVEPOINT gxupdate;UPDATE WWP_FormInstanceElement SET WWPFormInstanceElemChar=:WWPFormInstanceElemChar, WWPFormInstanceElemDate=:WWPFormInstanceElemDate, WWPFormInstanceElemDateTime=:WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric=:WWPFormInstanceElemNumeric, WWPFormInstanceElemBoolean=:WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileType=:WWPFormInstanceElemBlobFileType, WWPFormInstanceElemBlobFileName=:WWPFormInstanceElemBlobFileName  WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000D25)
             ,new CursorDef("T000D26", "SAVEPOINT gxupdate;UPDATE WWP_FormInstanceElement SET WWPFormInstanceElemBlob=:WWPFormInstanceElemBlob  WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000D26)
             ,new CursorDef("T000D27", "SAVEPOINT gxupdate;DELETE FROM WWP_FormInstanceElement  WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000D27)
             ,new CursorDef("T000D28", "SELECT WWPFormElementTitle, WWPFormElementReferenceId, WWPFormElementDataType, WWPFormElementType, WWPFormElementMetadata, WWPFormElementCaption, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D29", "SELECT WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D30", "SELECT WWPFormInstanceId, WWPFormElementId, WWPFormInstanceElementId FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId ORDER BY WWPFormInstanceId, WWPFormElementId, WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D30,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((short[]) buf[14])[0] = rslt.getShort(10);
                ((string[]) buf[15])[0] = rslt.getBLOBFile(11, rslt.getVarchar(8), rslt.getVarchar(9));
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((short[]) buf[14])[0] = rslt.getShort(10);
                ((string[]) buf[15])[0] = rslt.getBLOBFile(11, rslt.getVarchar(8), rslt.getVarchar(9));
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(15);
                ((bool[]) buf[18])[0] = rslt.wasNull(15);
                ((bool[]) buf[19])[0] = rslt.getBool(16);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((string[]) buf[21])[0] = rslt.getVarchar(17);
                ((string[]) buf[22])[0] = rslt.getVarchar(18);
                ((short[]) buf[23])[0] = rslt.getShort(19);
                ((short[]) buf[24])[0] = rslt.getShort(20);
                ((bool[]) buf[25])[0] = rslt.wasNull(20);
                ((string[]) buf[26])[0] = rslt.getBLOBFile(21, rslt.getVarchar(17), rslt.getVarchar(18));
                ((bool[]) buf[27])[0] = rslt.wasNull(21);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
             case 27 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
