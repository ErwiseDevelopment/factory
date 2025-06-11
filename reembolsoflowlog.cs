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
   public class reembolsoflowlog : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A750LogWorkflowConvenioId = (int)(Math.Round(NumberUtil.Val( GetPar( "LogWorkflowConvenioId"), "."), 18, MidpointRounding.ToEven));
            n750LogWorkflowConvenioId = false;
            AssignAttri("", false, "A750LogWorkflowConvenioId", ((0==A750LogWorkflowConvenioId)&&IsIns( )||n750LogWorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A750LogWorkflowConvenioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A744ReembolsoFlowLogUser = (short)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoFlowLogUser"), "."), 18, MidpointRounding.ToEven));
            n744ReembolsoFlowLogUser = false;
            AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A744ReembolsoFlowLogUser) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A748ReembolsoLogId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoLogId"), "."), 18, MidpointRounding.ToEven));
            n748ReembolsoLogId = false;
            AssignAttri("", false, "A748ReembolsoLogId", ((0==A748ReembolsoLogId)&&IsIns( )||n748ReembolsoLogId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A748ReembolsoLogId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A749ReembolsoWorkFlowConvenioId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoWorkFlowConvenioId"), "."), 18, MidpointRounding.ToEven));
            n749ReembolsoWorkFlowConvenioId = false;
            AssignAttri("", false, "A749ReembolsoWorkFlowConvenioId", StringUtil.LTrimStr( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A749ReembolsoWorkFlowConvenioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A748ReembolsoLogId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoLogId"), "."), 18, MidpointRounding.ToEven));
            n748ReembolsoLogId = false;
            AssignAttri("", false, "A748ReembolsoLogId", ((0==A748ReembolsoLogId)&&IsIns( )||n748ReembolsoLogId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A748ReembolsoLogId) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "reembolsoflowlog")), "reembolsoflowlog") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "reembolsoflowlog")))) ;
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
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7ReembolsoFlowLogId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoFlowLogId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(AV7ReembolsoFlowLogId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOFLOWLOGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ReembolsoFlowLogId), "ZZZZZZZZ9"), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
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
         Form.Meta.addItem("description", "Reembolso Flow Log", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLogWorkflowConvenioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public reembolsoflowlog( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoflowlog( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ReembolsoFlowLogId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ReembolsoFlowLogId = aP1_ReembolsoFlowLogId;
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction TableMainFixedActions", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
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
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoFlowLogId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoFlowLogId_Internalname, "Log Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoFlowLogId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A746ReembolsoFlowLogId), 9, 0, ",", "")), StringUtil.LTrim( ((edtReembolsoFlowLogId_Enabled!=0) ? context.localUtil.Format( (decimal)(A746ReembolsoFlowLogId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A746ReembolsoFlowLogId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoFlowLogId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoFlowLogId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedlogworkflowconvenioid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocklogworkflowconvenioid_Internalname, "Workflow Convenio", "", "", lblTextblocklogworkflowconvenioid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_logworkflowconvenioid.SetProperty("Caption", Combo_logworkflowconvenioid_Caption);
         ucCombo_logworkflowconvenioid.SetProperty("Cls", Combo_logworkflowconvenioid_Cls);
         ucCombo_logworkflowconvenioid.SetProperty("DataListProc", Combo_logworkflowconvenioid_Datalistproc);
         ucCombo_logworkflowconvenioid.SetProperty("DataListProcParametersPrefix", Combo_logworkflowconvenioid_Datalistprocparametersprefix);
         ucCombo_logworkflowconvenioid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_logworkflowconvenioid.SetProperty("DropDownOptionsData", AV15LogWorkflowConvenioId_Data);
         ucCombo_logworkflowconvenioid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_logworkflowconvenioid_Internalname, "COMBO_LOGWORKFLOWCONVENIOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLogWorkflowConvenioId_Internalname, "Log Workflow Convenio Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLogWorkflowConvenioId_Internalname, ((0==A750LogWorkflowConvenioId)&&IsIns( )||n750LogWorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ",", ""))), ((0==A750LogWorkflowConvenioId)&&IsIns( )||n750LogWorkflowConvenioId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A750LogWorkflowConvenioId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLogWorkflowConvenioId_Jsonclick, 0, "Attribute", "", "", "", "", edtLogWorkflowConvenioId_Visible, edtLogWorkflowConvenioId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoFlowLogDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoFlowLogDate_Internalname, "Log Date", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtReembolsoFlowLogDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtReembolsoFlowLogDate_Internalname, context.localUtil.TToC( A747ReembolsoFlowLogDate, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A747ReembolsoFlowLogDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoFlowLogDate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoFlowLogDate_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_bitmap( context, edtReembolsoFlowLogDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtReembolsoFlowLogDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ReembolsoFlowLog.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedreembolsoflowloguser_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockreembolsoflowloguser_Internalname, "Usuário", "", "", lblTextblockreembolsoflowloguser_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_reembolsoflowloguser.SetProperty("Caption", Combo_reembolsoflowloguser_Caption);
         ucCombo_reembolsoflowloguser.SetProperty("Cls", Combo_reembolsoflowloguser_Cls);
         ucCombo_reembolsoflowloguser.SetProperty("DataListProc", Combo_reembolsoflowloguser_Datalistproc);
         ucCombo_reembolsoflowloguser.SetProperty("DataListProcParametersPrefix", Combo_reembolsoflowloguser_Datalistprocparametersprefix);
         ucCombo_reembolsoflowloguser.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_reembolsoflowloguser.SetProperty("DropDownOptionsData", AV22ReembolsoFlowLogUser_Data);
         ucCombo_reembolsoflowloguser.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_reembolsoflowloguser_Internalname, "COMBO_REEMBOLSOFLOWLOGUSERContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoFlowLogUser_Internalname, "Reembolso Flow Log User", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoFlowLogUser_Internalname, ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ",", ""))), ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A744ReembolsoFlowLogUser), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoFlowLogUser_Jsonclick, 0, "Attribute", "", "", "", "", edtReembolsoFlowLogUser_Visible, edtReembolsoFlowLogUser_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedreembolsologid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockreembolsologid_Internalname, "Reembolso", "", "", lblTextblockreembolsologid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_reembolsologid.SetProperty("Caption", Combo_reembolsologid_Caption);
         ucCombo_reembolsologid.SetProperty("Cls", Combo_reembolsologid_Cls);
         ucCombo_reembolsologid.SetProperty("DataListProc", Combo_reembolsologid_Datalistproc);
         ucCombo_reembolsologid.SetProperty("DataListProcParametersPrefix", Combo_reembolsologid_Datalistprocparametersprefix);
         ucCombo_reembolsologid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_reembolsologid.SetProperty("DropDownOptionsData", AV25ReembolsoLogId_Data);
         ucCombo_reembolsologid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_reembolsologid_Internalname, "COMBO_REEMBOLSOLOGIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoLogId_Internalname, "Reembolso Log Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoLogId_Internalname, ((0==A748ReembolsoLogId)&&IsIns( )||n748ReembolsoLogId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ",", ""))), ((0==A748ReembolsoLogId)&&IsIns( )||n748ReembolsoLogId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A748ReembolsoLogId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoLogId_Jsonclick, 0, "Attribute", "", "", "", "", edtReembolsoLogId_Visible, edtReembolsoLogId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoWorkFlowConvenioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoWorkFlowConvenioId_Internalname, "Convenio Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoWorkFlowConvenioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0, ",", "")), StringUtil.LTrim( ((edtReembolsoWorkFlowConvenioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A749ReembolsoWorkFlowConvenioId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A749ReembolsoWorkFlowConvenioId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoWorkFlowConvenioId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoWorkFlowConvenioId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoFlowLog.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoFlowLog.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_logworkflowconvenioid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombologworkflowconvenioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboLogWorkflowConvenioId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavCombologworkflowconvenioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboLogWorkflowConvenioId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV20ComboLogWorkflowConvenioId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombologworkflowconvenioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombologworkflowconvenioid_Visible, edtavCombologworkflowconvenioid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_reembolsoflowloguser_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboreembolsoflowloguser_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ComboReembolsoFlowLogUser), 4, 0, ",", "")), StringUtil.LTrim( ((edtavComboreembolsoflowloguser_Enabled!=0) ? context.localUtil.Format( (decimal)(AV23ComboReembolsoFlowLogUser), "ZZZ9") : context.localUtil.Format( (decimal)(AV23ComboReembolsoFlowLogUser), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboreembolsoflowloguser_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboreembolsoflowloguser_Visible, edtavComboreembolsoflowloguser_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_reembolsologid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboreembolsologid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ComboReembolsoLogId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboreembolsologid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV26ComboReembolsoLogId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV26ComboReembolsoLogId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboreembolsologid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboreembolsologid_Visible, edtavComboreembolsologid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoFlowLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112K2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vLOGWORKFLOWCONVENIOID_DATA"), AV15LogWorkflowConvenioId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vREEMBOLSOFLOWLOGUSER_DATA"), AV22ReembolsoFlowLogUser_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vREEMBOLSOLOGID_DATA"), AV25ReembolsoLogId_Data);
               /* Read saved values. */
               Z746ReembolsoFlowLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z746ReembolsoFlowLogId"), ",", "."), 18, MidpointRounding.ToEven));
               Z747ReembolsoFlowLogDate = context.localUtil.CToT( cgiGet( "Z747ReembolsoFlowLogDate"), 0);
               n747ReembolsoFlowLogDate = ((DateTime.MinValue==A747ReembolsoFlowLogDate) ? true : false);
               Z761ReembolsoFlowLogDataFinal = context.localUtil.CToT( cgiGet( "Z761ReembolsoFlowLogDataFinal"), 0);
               n761ReembolsoFlowLogDataFinal = ((DateTime.MinValue==A761ReembolsoFlowLogDataFinal) ? true : false);
               Z750LogWorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z750LogWorkflowConvenioId"), ",", "."), 18, MidpointRounding.ToEven));
               n750LogWorkflowConvenioId = ((0==A750LogWorkflowConvenioId) ? true : false);
               Z744ReembolsoFlowLogUser = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z744ReembolsoFlowLogUser"), ",", "."), 18, MidpointRounding.ToEven));
               n744ReembolsoFlowLogUser = ((0==A744ReembolsoFlowLogUser) ? true : false);
               Z748ReembolsoLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z748ReembolsoLogId"), ",", "."), 18, MidpointRounding.ToEven));
               n748ReembolsoLogId = ((0==A748ReembolsoLogId) ? true : false);
               A761ReembolsoFlowLogDataFinal = context.localUtil.CToT( cgiGet( "Z761ReembolsoFlowLogDataFinal"), 0);
               n761ReembolsoFlowLogDataFinal = false;
               n761ReembolsoFlowLogDataFinal = ((DateTime.MinValue==A761ReembolsoFlowLogDataFinal) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N750LogWorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N750LogWorkflowConvenioId"), ",", "."), 18, MidpointRounding.ToEven));
               n750LogWorkflowConvenioId = ((0==A750LogWorkflowConvenioId) ? true : false);
               N744ReembolsoFlowLogUser = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N744ReembolsoFlowLogUser"), ",", "."), 18, MidpointRounding.ToEven));
               n744ReembolsoFlowLogUser = ((0==A744ReembolsoFlowLogUser) ? true : false);
               N748ReembolsoLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N748ReembolsoLogId"), ",", "."), 18, MidpointRounding.ToEven));
               n748ReembolsoLogId = ((0==A748ReembolsoLogId) ? true : false);
               A754ReembolsoWorkflowConvenioSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( "REEMBOLSOWORKFLOWCONVENIOSLA"), ",", "."), 18, MidpointRounding.ToEven));
               n754ReembolsoWorkflowConvenioSLA = false;
               A755ReembolsoFlowLogDataSLA_F = context.localUtil.CToT( cgiGet( "REEMBOLSOFLOWLOGDATASLA_F"), 0);
               AV7ReembolsoFlowLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vREEMBOLSOFLOWLOGID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_LogWorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_LOGWORKFLOWCONVENIOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_LogWorkflowConvenioId", StringUtil.LTrimStr( (decimal)(AV11Insert_LogWorkflowConvenioId), 9, 0));
               AV12Insert_ReembolsoFlowLogUser = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_REEMBOLSOFLOWLOGUSER"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_ReembolsoFlowLogUser", StringUtil.LTrimStr( (decimal)(AV12Insert_ReembolsoFlowLogUser), 4, 0));
               AV13Insert_ReembolsoLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_REEMBOLSOLOGID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13Insert_ReembolsoLogId", StringUtil.LTrimStr( (decimal)(AV13Insert_ReembolsoLogId), 9, 0));
               A761ReembolsoFlowLogDataFinal = context.localUtil.CToT( cgiGet( "REEMBOLSOFLOWLOGDATAFINAL"), 0);
               n761ReembolsoFlowLogDataFinal = ((DateTime.MinValue==A761ReembolsoFlowLogDataFinal) ? true : false);
               A752LogWorkflowConvenioDesc = cgiGet( "LOGWORKFLOWCONVENIODESC");
               n752LogWorkflowConvenioDesc = false;
               A745ReembolsoFlowLogUserNome = cgiGet( "REEMBOLSOFLOWLOGUSERNOME");
               n745ReembolsoFlowLogUserNome = false;
               A763ReembolsoLogProtocolo = cgiGet( "REEMBOLSOLOGPROTOCOLO");
               n763ReembolsoLogProtocolo = false;
               A760LogReembolsoStatusAtual_F = cgiGet( "LOGREEMBOLSOSTATUSATUAL_F");
               n760LogReembolsoStatusAtual_F = false;
               AV28Pgmname = cgiGet( "vPGMNAME");
               Combo_logworkflowconvenioid_Objectcall = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Objectcall");
               Combo_logworkflowconvenioid_Class = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Class");
               Combo_logworkflowconvenioid_Icontype = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Icontype");
               Combo_logworkflowconvenioid_Icon = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Icon");
               Combo_logworkflowconvenioid_Caption = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Caption");
               Combo_logworkflowconvenioid_Tooltip = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Tooltip");
               Combo_logworkflowconvenioid_Cls = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Cls");
               Combo_logworkflowconvenioid_Selectedvalue_set = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Selectedvalue_set");
               Combo_logworkflowconvenioid_Selectedvalue_get = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Selectedvalue_get");
               Combo_logworkflowconvenioid_Selectedtext_set = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Selectedtext_set");
               Combo_logworkflowconvenioid_Selectedtext_get = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Selectedtext_get");
               Combo_logworkflowconvenioid_Gamoauthtoken = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Gamoauthtoken");
               Combo_logworkflowconvenioid_Ddointernalname = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Ddointernalname");
               Combo_logworkflowconvenioid_Titlecontrolalign = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Titlecontrolalign");
               Combo_logworkflowconvenioid_Dropdownoptionstype = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Dropdownoptionstype");
               Combo_logworkflowconvenioid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Enabled"));
               Combo_logworkflowconvenioid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Visible"));
               Combo_logworkflowconvenioid_Titlecontrolidtoreplace = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Titlecontrolidtoreplace");
               Combo_logworkflowconvenioid_Datalisttype = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Datalisttype");
               Combo_logworkflowconvenioid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Allowmultipleselection"));
               Combo_logworkflowconvenioid_Datalistfixedvalues = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Datalistfixedvalues");
               Combo_logworkflowconvenioid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Isgriditem"));
               Combo_logworkflowconvenioid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Hasdescription"));
               Combo_logworkflowconvenioid_Datalistproc = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Datalistproc");
               Combo_logworkflowconvenioid_Datalistprocparametersprefix = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Datalistprocparametersprefix");
               Combo_logworkflowconvenioid_Remoteservicesparameters = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Remoteservicesparameters");
               Combo_logworkflowconvenioid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_logworkflowconvenioid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Includeonlyselectedoption"));
               Combo_logworkflowconvenioid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Includeselectalloption"));
               Combo_logworkflowconvenioid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Emptyitem"));
               Combo_logworkflowconvenioid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Includeaddnewoption"));
               Combo_logworkflowconvenioid_Htmltemplate = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Htmltemplate");
               Combo_logworkflowconvenioid_Multiplevaluestype = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Multiplevaluestype");
               Combo_logworkflowconvenioid_Loadingdata = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Loadingdata");
               Combo_logworkflowconvenioid_Noresultsfound = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Noresultsfound");
               Combo_logworkflowconvenioid_Emptyitemtext = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Emptyitemtext");
               Combo_logworkflowconvenioid_Onlyselectedvalues = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Onlyselectedvalues");
               Combo_logworkflowconvenioid_Selectalltext = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Selectalltext");
               Combo_logworkflowconvenioid_Multiplevaluesseparator = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Multiplevaluesseparator");
               Combo_logworkflowconvenioid_Addnewoptiontext = cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Addnewoptiontext");
               Combo_logworkflowconvenioid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_LOGWORKFLOWCONVENIOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_reembolsoflowloguser_Objectcall = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Objectcall");
               Combo_reembolsoflowloguser_Class = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Class");
               Combo_reembolsoflowloguser_Icontype = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Icontype");
               Combo_reembolsoflowloguser_Icon = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Icon");
               Combo_reembolsoflowloguser_Caption = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Caption");
               Combo_reembolsoflowloguser_Tooltip = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Tooltip");
               Combo_reembolsoflowloguser_Cls = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Cls");
               Combo_reembolsoflowloguser_Selectedvalue_set = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Selectedvalue_set");
               Combo_reembolsoflowloguser_Selectedvalue_get = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Selectedvalue_get");
               Combo_reembolsoflowloguser_Selectedtext_set = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Selectedtext_set");
               Combo_reembolsoflowloguser_Selectedtext_get = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Selectedtext_get");
               Combo_reembolsoflowloguser_Gamoauthtoken = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Gamoauthtoken");
               Combo_reembolsoflowloguser_Ddointernalname = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Ddointernalname");
               Combo_reembolsoflowloguser_Titlecontrolalign = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Titlecontrolalign");
               Combo_reembolsoflowloguser_Dropdownoptionstype = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Dropdownoptionstype");
               Combo_reembolsoflowloguser_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Enabled"));
               Combo_reembolsoflowloguser_Visible = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Visible"));
               Combo_reembolsoflowloguser_Titlecontrolidtoreplace = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Titlecontrolidtoreplace");
               Combo_reembolsoflowloguser_Datalisttype = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Datalisttype");
               Combo_reembolsoflowloguser_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Allowmultipleselection"));
               Combo_reembolsoflowloguser_Datalistfixedvalues = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Datalistfixedvalues");
               Combo_reembolsoflowloguser_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Isgriditem"));
               Combo_reembolsoflowloguser_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Hasdescription"));
               Combo_reembolsoflowloguser_Datalistproc = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Datalistproc");
               Combo_reembolsoflowloguser_Datalistprocparametersprefix = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Datalistprocparametersprefix");
               Combo_reembolsoflowloguser_Remoteservicesparameters = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Remoteservicesparameters");
               Combo_reembolsoflowloguser_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_reembolsoflowloguser_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Includeonlyselectedoption"));
               Combo_reembolsoflowloguser_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Includeselectalloption"));
               Combo_reembolsoflowloguser_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Emptyitem"));
               Combo_reembolsoflowloguser_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Includeaddnewoption"));
               Combo_reembolsoflowloguser_Htmltemplate = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Htmltemplate");
               Combo_reembolsoflowloguser_Multiplevaluestype = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Multiplevaluestype");
               Combo_reembolsoflowloguser_Loadingdata = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Loadingdata");
               Combo_reembolsoflowloguser_Noresultsfound = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Noresultsfound");
               Combo_reembolsoflowloguser_Emptyitemtext = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Emptyitemtext");
               Combo_reembolsoflowloguser_Onlyselectedvalues = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Onlyselectedvalues");
               Combo_reembolsoflowloguser_Selectalltext = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Selectalltext");
               Combo_reembolsoflowloguser_Multiplevaluesseparator = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Multiplevaluesseparator");
               Combo_reembolsoflowloguser_Addnewoptiontext = cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Addnewoptiontext");
               Combo_reembolsoflowloguser_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REEMBOLSOFLOWLOGUSER_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_reembolsologid_Objectcall = cgiGet( "COMBO_REEMBOLSOLOGID_Objectcall");
               Combo_reembolsologid_Class = cgiGet( "COMBO_REEMBOLSOLOGID_Class");
               Combo_reembolsologid_Icontype = cgiGet( "COMBO_REEMBOLSOLOGID_Icontype");
               Combo_reembolsologid_Icon = cgiGet( "COMBO_REEMBOLSOLOGID_Icon");
               Combo_reembolsologid_Caption = cgiGet( "COMBO_REEMBOLSOLOGID_Caption");
               Combo_reembolsologid_Tooltip = cgiGet( "COMBO_REEMBOLSOLOGID_Tooltip");
               Combo_reembolsologid_Cls = cgiGet( "COMBO_REEMBOLSOLOGID_Cls");
               Combo_reembolsologid_Selectedvalue_set = cgiGet( "COMBO_REEMBOLSOLOGID_Selectedvalue_set");
               Combo_reembolsologid_Selectedvalue_get = cgiGet( "COMBO_REEMBOLSOLOGID_Selectedvalue_get");
               Combo_reembolsologid_Selectedtext_set = cgiGet( "COMBO_REEMBOLSOLOGID_Selectedtext_set");
               Combo_reembolsologid_Selectedtext_get = cgiGet( "COMBO_REEMBOLSOLOGID_Selectedtext_get");
               Combo_reembolsologid_Gamoauthtoken = cgiGet( "COMBO_REEMBOLSOLOGID_Gamoauthtoken");
               Combo_reembolsologid_Ddointernalname = cgiGet( "COMBO_REEMBOLSOLOGID_Ddointernalname");
               Combo_reembolsologid_Titlecontrolalign = cgiGet( "COMBO_REEMBOLSOLOGID_Titlecontrolalign");
               Combo_reembolsologid_Dropdownoptionstype = cgiGet( "COMBO_REEMBOLSOLOGID_Dropdownoptionstype");
               Combo_reembolsologid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOLOGID_Enabled"));
               Combo_reembolsologid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOLOGID_Visible"));
               Combo_reembolsologid_Titlecontrolidtoreplace = cgiGet( "COMBO_REEMBOLSOLOGID_Titlecontrolidtoreplace");
               Combo_reembolsologid_Datalisttype = cgiGet( "COMBO_REEMBOLSOLOGID_Datalisttype");
               Combo_reembolsologid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOLOGID_Allowmultipleselection"));
               Combo_reembolsologid_Datalistfixedvalues = cgiGet( "COMBO_REEMBOLSOLOGID_Datalistfixedvalues");
               Combo_reembolsologid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOLOGID_Isgriditem"));
               Combo_reembolsologid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOLOGID_Hasdescription"));
               Combo_reembolsologid_Datalistproc = cgiGet( "COMBO_REEMBOLSOLOGID_Datalistproc");
               Combo_reembolsologid_Datalistprocparametersprefix = cgiGet( "COMBO_REEMBOLSOLOGID_Datalistprocparametersprefix");
               Combo_reembolsologid_Remoteservicesparameters = cgiGet( "COMBO_REEMBOLSOLOGID_Remoteservicesparameters");
               Combo_reembolsologid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REEMBOLSOLOGID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_reembolsologid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOLOGID_Includeonlyselectedoption"));
               Combo_reembolsologid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOLOGID_Includeselectalloption"));
               Combo_reembolsologid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOLOGID_Emptyitem"));
               Combo_reembolsologid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOLOGID_Includeaddnewoption"));
               Combo_reembolsologid_Htmltemplate = cgiGet( "COMBO_REEMBOLSOLOGID_Htmltemplate");
               Combo_reembolsologid_Multiplevaluestype = cgiGet( "COMBO_REEMBOLSOLOGID_Multiplevaluestype");
               Combo_reembolsologid_Loadingdata = cgiGet( "COMBO_REEMBOLSOLOGID_Loadingdata");
               Combo_reembolsologid_Noresultsfound = cgiGet( "COMBO_REEMBOLSOLOGID_Noresultsfound");
               Combo_reembolsologid_Emptyitemtext = cgiGet( "COMBO_REEMBOLSOLOGID_Emptyitemtext");
               Combo_reembolsologid_Onlyselectedvalues = cgiGet( "COMBO_REEMBOLSOLOGID_Onlyselectedvalues");
               Combo_reembolsologid_Selectalltext = cgiGet( "COMBO_REEMBOLSOLOGID_Selectalltext");
               Combo_reembolsologid_Multiplevaluesseparator = cgiGet( "COMBO_REEMBOLSOLOGID_Multiplevaluesseparator");
               Combo_reembolsologid_Addnewoptiontext = cgiGet( "COMBO_REEMBOLSOLOGID_Addnewoptiontext");
               Combo_reembolsologid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REEMBOLSOLOGID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Titletype = cgiGet( "DVPANEL_TABLEATTRIBUTES_Titletype");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A746ReembolsoFlowLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoFlowLogId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
               n750LogWorkflowConvenioId = ((StringUtil.StrCmp(cgiGet( edtLogWorkflowConvenioId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtLogWorkflowConvenioId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLogWorkflowConvenioId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LOGWORKFLOWCONVENIOID");
                  AnyError = 1;
                  GX_FocusControl = edtLogWorkflowConvenioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A750LogWorkflowConvenioId = 0;
                  n750LogWorkflowConvenioId = false;
                  AssignAttri("", false, "A750LogWorkflowConvenioId", (n750LogWorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ".", ""))));
               }
               else
               {
                  A750LogWorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtLogWorkflowConvenioId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A750LogWorkflowConvenioId", (n750LogWorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ".", ""))));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtReembolsoFlowLogDate_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Reembolso Flow Log Date"}), 1, "REEMBOLSOFLOWLOGDATE");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoFlowLogDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
                  n747ReembolsoFlowLogDate = false;
                  AssignAttri("", false, "A747ReembolsoFlowLogDate", context.localUtil.TToC( A747ReembolsoFlowLogDate, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A747ReembolsoFlowLogDate = context.localUtil.CToT( cgiGet( edtReembolsoFlowLogDate_Internalname));
                  n747ReembolsoFlowLogDate = false;
                  AssignAttri("", false, "A747ReembolsoFlowLogDate", context.localUtil.TToC( A747ReembolsoFlowLogDate, 8, 5, 0, 3, "/", ":", " "));
               }
               n747ReembolsoFlowLogDate = ((DateTime.MinValue==A747ReembolsoFlowLogDate) ? true : false);
               n744ReembolsoFlowLogUser = ((StringUtil.StrCmp(cgiGet( edtReembolsoFlowLogUser_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoFlowLogUser_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoFlowLogUser_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOFLOWLOGUSER");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoFlowLogUser_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A744ReembolsoFlowLogUser = 0;
                  n744ReembolsoFlowLogUser = false;
                  AssignAttri("", false, "A744ReembolsoFlowLogUser", (n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
               }
               else
               {
                  A744ReembolsoFlowLogUser = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoFlowLogUser_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A744ReembolsoFlowLogUser", (n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
               }
               n748ReembolsoLogId = ((StringUtil.StrCmp(cgiGet( edtReembolsoLogId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoLogId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoLogId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOLOGID");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoLogId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A748ReembolsoLogId = 0;
                  n748ReembolsoLogId = false;
                  AssignAttri("", false, "A748ReembolsoLogId", (n748ReembolsoLogId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
               }
               else
               {
                  A748ReembolsoLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoLogId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A748ReembolsoLogId", (n748ReembolsoLogId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
               }
               A749ReembolsoWorkFlowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoWorkFlowConvenioId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n749ReembolsoWorkFlowConvenioId = false;
               AssignAttri("", false, "A749ReembolsoWorkFlowConvenioId", StringUtil.LTrimStr( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0));
               AV20ComboLogWorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombologworkflowconvenioid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ComboLogWorkflowConvenioId", StringUtil.LTrimStr( (decimal)(AV20ComboLogWorkflowConvenioId), 9, 0));
               AV23ComboReembolsoFlowLogUser = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboreembolsoflowloguser_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV23ComboReembolsoFlowLogUser", StringUtil.LTrimStr( (decimal)(AV23ComboReembolsoFlowLogUser), 4, 0));
               AV26ComboReembolsoLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboreembolsologid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26ComboReembolsoLogId", StringUtil.LTrimStr( (decimal)(AV26ComboReembolsoLogId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ReembolsoFlowLog");
               A746ReembolsoFlowLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoFlowLogId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
               forbiddenHiddens.Add("ReembolsoFlowLogId", context.localUtil.Format( (decimal)(A746ReembolsoFlowLogId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_LogWorkflowConvenioId", context.localUtil.Format( (decimal)(AV11Insert_LogWorkflowConvenioId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ReembolsoFlowLogUser", context.localUtil.Format( (decimal)(AV12Insert_ReembolsoFlowLogUser), "ZZZ9"));
               forbiddenHiddens.Add("Insert_ReembolsoLogId", context.localUtil.Format( (decimal)(AV13Insert_ReembolsoLogId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ReembolsoFlowLogDataFinal", context.localUtil.Format( A761ReembolsoFlowLogDataFinal, "99/99/99 99:99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A746ReembolsoFlowLogId != Z746ReembolsoFlowLogId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("reembolsoflowlog:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A746ReembolsoFlowLogId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoFlowLogId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode92 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode92;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound92 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2K0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "REEMBOLSOFLOWLOGID");
                        AnyError = 1;
                        GX_FocusControl = edtReembolsoFlowLogId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E112K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            /* Execute user event: After Trn */
            E122K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2K92( ) ;
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
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes2K92( ) ;
         }
         AssignProp("", false, edtavCombologworkflowconvenioid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombologworkflowconvenioid_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboreembolsoflowloguser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreembolsoflowloguser_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboreembolsologid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreembolsologid_Enabled), 5, 0), true);
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

      protected void CONFIRM_2K0( )
      {
         BeforeValidate2K92( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2K92( ) ;
            }
            else
            {
               CheckExtendedTable2K92( ) ;
               CloseExtendedTableCursors2K92( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2K0( )
      {
      }

      protected void E112K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtReembolsoLogId_Visible = 0;
         AssignProp("", false, edtReembolsoLogId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReembolsoLogId_Visible), 5, 0), true);
         AV26ComboReembolsoLogId = 0;
         AssignAttri("", false, "AV26ComboReembolsoLogId", StringUtil.LTrimStr( (decimal)(AV26ComboReembolsoLogId), 9, 0));
         edtavComboreembolsologid_Visible = 0;
         AssignProp("", false, edtavComboreembolsologid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboreembolsologid_Visible), 5, 0), true);
         edtReembolsoFlowLogUser_Visible = 0;
         AssignProp("", false, edtReembolsoFlowLogUser_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReembolsoFlowLogUser_Visible), 5, 0), true);
         AV23ComboReembolsoFlowLogUser = 0;
         AssignAttri("", false, "AV23ComboReembolsoFlowLogUser", StringUtil.LTrimStr( (decimal)(AV23ComboReembolsoFlowLogUser), 4, 0));
         edtavComboreembolsoflowloguser_Visible = 0;
         AssignProp("", false, edtavComboreembolsoflowloguser_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboreembolsoflowloguser_Visible), 5, 0), true);
         edtLogWorkflowConvenioId_Visible = 0;
         AssignProp("", false, edtLogWorkflowConvenioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLogWorkflowConvenioId_Visible), 5, 0), true);
         AV20ComboLogWorkflowConvenioId = 0;
         AssignAttri("", false, "AV20ComboLogWorkflowConvenioId", StringUtil.LTrimStr( (decimal)(AV20ComboLogWorkflowConvenioId), 9, 0));
         edtavCombologworkflowconvenioid_Visible = 0;
         AssignProp("", false, edtavCombologworkflowconvenioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombologworkflowconvenioid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOLOGWORKFLOWCONVENIOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOREEMBOLSOFLOWLOGUSER' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOREEMBOLSOLOGID' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV28Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV29GXV1 = 1;
            AssignAttri("", false, "AV29GXV1", StringUtil.LTrimStr( (decimal)(AV29GXV1), 8, 0));
            while ( AV29GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV29GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "LogWorkflowConvenioId") == 0 )
               {
                  AV11Insert_LogWorkflowConvenioId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_LogWorkflowConvenioId", StringUtil.LTrimStr( (decimal)(AV11Insert_LogWorkflowConvenioId), 9, 0));
                  if ( ! (0==AV11Insert_LogWorkflowConvenioId) )
                  {
                     AV20ComboLogWorkflowConvenioId = AV11Insert_LogWorkflowConvenioId;
                     AssignAttri("", false, "AV20ComboLogWorkflowConvenioId", StringUtil.LTrimStr( (decimal)(AV20ComboLogWorkflowConvenioId), 9, 0));
                     Combo_logworkflowconvenioid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboLogWorkflowConvenioId), 9, 0));
                     ucCombo_logworkflowconvenioid.SendProperty(context, "", false, Combo_logworkflowconvenioid_Internalname, "SelectedValue_set", Combo_logworkflowconvenioid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new reembolsoflowlogloaddvcombo(context ).execute(  "LogWorkflowConvenioId",  "GET",  false,  AV7ReembolsoFlowLogId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_logworkflowconvenioid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_logworkflowconvenioid.SendProperty(context, "", false, Combo_logworkflowconvenioid_Internalname, "SelectedText_set", Combo_logworkflowconvenioid_Selectedtext_set);
                     Combo_logworkflowconvenioid_Enabled = false;
                     ucCombo_logworkflowconvenioid.SendProperty(context, "", false, Combo_logworkflowconvenioid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_logworkflowconvenioid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ReembolsoFlowLogUser") == 0 )
               {
                  AV12Insert_ReembolsoFlowLogUser = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_ReembolsoFlowLogUser", StringUtil.LTrimStr( (decimal)(AV12Insert_ReembolsoFlowLogUser), 4, 0));
                  if ( ! (0==AV12Insert_ReembolsoFlowLogUser) )
                  {
                     AV23ComboReembolsoFlowLogUser = AV12Insert_ReembolsoFlowLogUser;
                     AssignAttri("", false, "AV23ComboReembolsoFlowLogUser", StringUtil.LTrimStr( (decimal)(AV23ComboReembolsoFlowLogUser), 4, 0));
                     Combo_reembolsoflowloguser_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV23ComboReembolsoFlowLogUser), 4, 0));
                     ucCombo_reembolsoflowloguser.SendProperty(context, "", false, Combo_reembolsoflowloguser_Internalname, "SelectedValue_set", Combo_reembolsoflowloguser_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new reembolsoflowlogloaddvcombo(context ).execute(  "ReembolsoFlowLogUser",  "GET",  false,  AV7ReembolsoFlowLogId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_reembolsoflowloguser_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_reembolsoflowloguser.SendProperty(context, "", false, Combo_reembolsoflowloguser_Internalname, "SelectedText_set", Combo_reembolsoflowloguser_Selectedtext_set);
                     Combo_reembolsoflowloguser_Enabled = false;
                     ucCombo_reembolsoflowloguser.SendProperty(context, "", false, Combo_reembolsoflowloguser_Internalname, "Enabled", StringUtil.BoolToStr( Combo_reembolsoflowloguser_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ReembolsoLogId") == 0 )
               {
                  AV13Insert_ReembolsoLogId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_ReembolsoLogId", StringUtil.LTrimStr( (decimal)(AV13Insert_ReembolsoLogId), 9, 0));
                  if ( ! (0==AV13Insert_ReembolsoLogId) )
                  {
                     AV26ComboReembolsoLogId = AV13Insert_ReembolsoLogId;
                     AssignAttri("", false, "AV26ComboReembolsoLogId", StringUtil.LTrimStr( (decimal)(AV26ComboReembolsoLogId), 9, 0));
                     Combo_reembolsologid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV26ComboReembolsoLogId), 9, 0));
                     ucCombo_reembolsologid.SendProperty(context, "", false, Combo_reembolsologid_Internalname, "SelectedValue_set", Combo_reembolsologid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new reembolsoflowlogloaddvcombo(context ).execute(  "ReembolsoLogId",  "GET",  false,  AV7ReembolsoFlowLogId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_reembolsologid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_reembolsologid.SendProperty(context, "", false, Combo_reembolsologid_Internalname, "SelectedText_set", Combo_reembolsologid_Selectedtext_set);
                     Combo_reembolsologid_Enabled = false;
                     ucCombo_reembolsologid.SendProperty(context, "", false, Combo_reembolsologid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_reembolsologid_Enabled));
                  }
               }
               AV29GXV1 = (int)(AV29GXV1+1);
               AssignAttri("", false, "AV29GXV1", StringUtil.LTrimStr( (decimal)(AV29GXV1), 8, 0));
            }
         }
      }

      protected void E122K2( )
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

      protected void S132( )
      {
         /* 'LOADCOMBOREEMBOLSOLOGID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new reembolsoflowlogloaddvcombo(context ).execute(  "ReembolsoLogId",  Gx_mode,  false,  AV7ReembolsoFlowLogId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_reembolsologid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_reembolsologid.SendProperty(context, "", false, Combo_reembolsologid_Internalname, "SelectedValue_set", Combo_reembolsologid_Selectedvalue_set);
         Combo_reembolsologid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_reembolsologid.SendProperty(context, "", false, Combo_reembolsologid_Internalname, "SelectedText_set", Combo_reembolsologid_Selectedtext_set);
         AV26ComboReembolsoLogId = (int)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV26ComboReembolsoLogId", StringUtil.LTrimStr( (decimal)(AV26ComboReembolsoLogId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_reembolsologid_Enabled = false;
            ucCombo_reembolsologid.SendProperty(context, "", false, Combo_reembolsologid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_reembolsologid_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOREEMBOLSOFLOWLOGUSER' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new reembolsoflowlogloaddvcombo(context ).execute(  "ReembolsoFlowLogUser",  Gx_mode,  false,  AV7ReembolsoFlowLogId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_reembolsoflowloguser_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_reembolsoflowloguser.SendProperty(context, "", false, Combo_reembolsoflowloguser_Internalname, "SelectedValue_set", Combo_reembolsoflowloguser_Selectedvalue_set);
         Combo_reembolsoflowloguser_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_reembolsoflowloguser.SendProperty(context, "", false, Combo_reembolsoflowloguser_Internalname, "SelectedText_set", Combo_reembolsoflowloguser_Selectedtext_set);
         AV23ComboReembolsoFlowLogUser = (short)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV23ComboReembolsoFlowLogUser", StringUtil.LTrimStr( (decimal)(AV23ComboReembolsoFlowLogUser), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_reembolsoflowloguser_Enabled = false;
            ucCombo_reembolsoflowloguser.SendProperty(context, "", false, Combo_reembolsoflowloguser_Internalname, "Enabled", StringUtil.BoolToStr( Combo_reembolsoflowloguser_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOLOGWORKFLOWCONVENIOID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new reembolsoflowlogloaddvcombo(context ).execute(  "LogWorkflowConvenioId",  Gx_mode,  false,  AV7ReembolsoFlowLogId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_logworkflowconvenioid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_logworkflowconvenioid.SendProperty(context, "", false, Combo_logworkflowconvenioid_Internalname, "SelectedValue_set", Combo_logworkflowconvenioid_Selectedvalue_set);
         Combo_logworkflowconvenioid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_logworkflowconvenioid.SendProperty(context, "", false, Combo_logworkflowconvenioid_Internalname, "SelectedText_set", Combo_logworkflowconvenioid_Selectedtext_set);
         AV20ComboLogWorkflowConvenioId = (int)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV20ComboLogWorkflowConvenioId", StringUtil.LTrimStr( (decimal)(AV20ComboLogWorkflowConvenioId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_logworkflowconvenioid_Enabled = false;
            ucCombo_logworkflowconvenioid.SendProperty(context, "", false, Combo_logworkflowconvenioid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_logworkflowconvenioid_Enabled));
         }
      }

      protected void ZM2K92( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z747ReembolsoFlowLogDate = T002K3_A747ReembolsoFlowLogDate[0];
               Z761ReembolsoFlowLogDataFinal = T002K3_A761ReembolsoFlowLogDataFinal[0];
               Z750LogWorkflowConvenioId = T002K3_A750LogWorkflowConvenioId[0];
               Z744ReembolsoFlowLogUser = T002K3_A744ReembolsoFlowLogUser[0];
               Z748ReembolsoLogId = T002K3_A748ReembolsoLogId[0];
            }
            else
            {
               Z747ReembolsoFlowLogDate = A747ReembolsoFlowLogDate;
               Z761ReembolsoFlowLogDataFinal = A761ReembolsoFlowLogDataFinal;
               Z750LogWorkflowConvenioId = A750LogWorkflowConvenioId;
               Z744ReembolsoFlowLogUser = A744ReembolsoFlowLogUser;
               Z748ReembolsoLogId = A748ReembolsoLogId;
            }
         }
         if ( GX_JID == -15 )
         {
            Z746ReembolsoFlowLogId = A746ReembolsoFlowLogId;
            Z747ReembolsoFlowLogDate = A747ReembolsoFlowLogDate;
            Z761ReembolsoFlowLogDataFinal = A761ReembolsoFlowLogDataFinal;
            Z750LogWorkflowConvenioId = A750LogWorkflowConvenioId;
            Z744ReembolsoFlowLogUser = A744ReembolsoFlowLogUser;
            Z748ReembolsoLogId = A748ReembolsoLogId;
            Z752LogWorkflowConvenioDesc = A752LogWorkflowConvenioDesc;
            Z745ReembolsoFlowLogUserNome = A745ReembolsoFlowLogUserNome;
            Z763ReembolsoLogProtocolo = A763ReembolsoLogProtocolo;
            Z749ReembolsoWorkFlowConvenioId = A749ReembolsoWorkFlowConvenioId;
            Z754ReembolsoWorkflowConvenioSLA = A754ReembolsoWorkflowConvenioSLA;
            Z760LogReembolsoStatusAtual_F = A760LogReembolsoStatusAtual_F;
         }
      }

      protected void standaloneNotModal( )
      {
         edtReembolsoFlowLogId_Enabled = 0;
         AssignProp("", false, edtReembolsoFlowLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoFlowLogId_Enabled), 5, 0), true);
         AV28Pgmname = "ReembolsoFlowLog";
         AssignAttri("", false, "AV28Pgmname", AV28Pgmname);
         edtReembolsoFlowLogId_Enabled = 0;
         AssignProp("", false, edtReembolsoFlowLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoFlowLogId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ReembolsoFlowLogId) )
         {
            A746ReembolsoFlowLogId = AV7ReembolsoFlowLogId;
            AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_LogWorkflowConvenioId) )
         {
            edtLogWorkflowConvenioId_Enabled = 0;
            AssignProp("", false, edtLogWorkflowConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLogWorkflowConvenioId_Enabled), 5, 0), true);
         }
         else
         {
            edtLogWorkflowConvenioId_Enabled = 1;
            AssignProp("", false, edtLogWorkflowConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLogWorkflowConvenioId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ReembolsoFlowLogUser) )
         {
            edtReembolsoFlowLogUser_Enabled = 0;
            AssignProp("", false, edtReembolsoFlowLogUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoFlowLogUser_Enabled), 5, 0), true);
         }
         else
         {
            edtReembolsoFlowLogUser_Enabled = 1;
            AssignProp("", false, edtReembolsoFlowLogUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoFlowLogUser_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ReembolsoLogId) )
         {
            edtReembolsoLogId_Enabled = 0;
            AssignProp("", false, edtReembolsoLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoLogId_Enabled), 5, 0), true);
         }
         else
         {
            edtReembolsoLogId_Enabled = 1;
            AssignProp("", false, edtReembolsoLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoLogId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_LogWorkflowConvenioId) )
         {
            A750LogWorkflowConvenioId = AV11Insert_LogWorkflowConvenioId;
            n750LogWorkflowConvenioId = false;
            AssignAttri("", false, "A750LogWorkflowConvenioId", ((0==A750LogWorkflowConvenioId)&&IsIns( )||n750LogWorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV20ComboLogWorkflowConvenioId) )
            {
               A750LogWorkflowConvenioId = 0;
               n750LogWorkflowConvenioId = false;
               AssignAttri("", false, "A750LogWorkflowConvenioId", ((0==A750LogWorkflowConvenioId)&&IsIns( )||n750LogWorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ".", ""))));
               n750LogWorkflowConvenioId = true;
               n750LogWorkflowConvenioId = true;
               AssignAttri("", false, "A750LogWorkflowConvenioId", ((0==A750LogWorkflowConvenioId)&&IsIns( )||n750LogWorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV20ComboLogWorkflowConvenioId) )
               {
                  A750LogWorkflowConvenioId = AV20ComboLogWorkflowConvenioId;
                  n750LogWorkflowConvenioId = false;
                  AssignAttri("", false, "A750LogWorkflowConvenioId", ((0==A750LogWorkflowConvenioId)&&IsIns( )||n750LogWorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ".", ""))));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ReembolsoLogId) )
         {
            A748ReembolsoLogId = AV13Insert_ReembolsoLogId;
            n748ReembolsoLogId = false;
            AssignAttri("", false, "A748ReembolsoLogId", ((0==A748ReembolsoLogId)&&IsIns( )||n748ReembolsoLogId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV26ComboReembolsoLogId) )
            {
               A748ReembolsoLogId = 0;
               n748ReembolsoLogId = false;
               AssignAttri("", false, "A748ReembolsoLogId", ((0==A748ReembolsoLogId)&&IsIns( )||n748ReembolsoLogId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
               n748ReembolsoLogId = true;
               n748ReembolsoLogId = true;
               AssignAttri("", false, "A748ReembolsoLogId", ((0==A748ReembolsoLogId)&&IsIns( )||n748ReembolsoLogId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV26ComboReembolsoLogId) )
               {
                  A748ReembolsoLogId = AV26ComboReembolsoLogId;
                  n748ReembolsoLogId = false;
                  AssignAttri("", false, "A748ReembolsoLogId", ((0==A748ReembolsoLogId)&&IsIns( )||n748ReembolsoLogId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
               }
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T002K4 */
            pr_default.execute(2, new Object[] {n750LogWorkflowConvenioId, A750LogWorkflowConvenioId});
            A752LogWorkflowConvenioDesc = T002K4_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = T002K4_n752LogWorkflowConvenioDesc[0];
            pr_default.close(2);
            /* Using cursor T002K6 */
            pr_default.execute(4, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
            A763ReembolsoLogProtocolo = T002K6_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = T002K6_n763ReembolsoLogProtocolo[0];
            A749ReembolsoWorkFlowConvenioId = T002K6_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = T002K6_n749ReembolsoWorkFlowConvenioId[0];
            AssignAttri("", false, "A749ReembolsoWorkFlowConvenioId", StringUtil.LTrimStr( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0));
            pr_default.close(4);
            /* Using cursor T002K7 */
            pr_default.execute(5, new Object[] {n749ReembolsoWorkFlowConvenioId, A749ReembolsoWorkFlowConvenioId});
            A754ReembolsoWorkflowConvenioSLA = T002K7_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = T002K7_n754ReembolsoWorkflowConvenioSLA[0];
            pr_default.close(5);
            /* Using cursor T002K10 */
            pr_default.execute(6, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
            if ( (pr_default.getStatus(6) != 101) )
            {
               A760LogReembolsoStatusAtual_F = T002K10_A760LogReembolsoStatusAtual_F[0];
               n760LogReembolsoStatusAtual_F = T002K10_n760LogReembolsoStatusAtual_F[0];
            }
            else
            {
               A760LogReembolsoStatusAtual_F = "";
               n760LogReembolsoStatusAtual_F = false;
               AssignAttri("", false, "A760LogReembolsoStatusAtual_F", A760LogReembolsoStatusAtual_F);
            }
            pr_default.close(6);
         }
      }

      protected void Load2K92( )
      {
         /* Using cursor T002K13 */
         pr_default.execute(7, new Object[] {A746ReembolsoFlowLogId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound92 = 1;
            A752LogWorkflowConvenioDesc = T002K13_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = T002K13_n752LogWorkflowConvenioDesc[0];
            A747ReembolsoFlowLogDate = T002K13_A747ReembolsoFlowLogDate[0];
            n747ReembolsoFlowLogDate = T002K13_n747ReembolsoFlowLogDate[0];
            AssignAttri("", false, "A747ReembolsoFlowLogDate", context.localUtil.TToC( A747ReembolsoFlowLogDate, 8, 5, 0, 3, "/", ":", " "));
            A745ReembolsoFlowLogUserNome = T002K13_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = T002K13_n745ReembolsoFlowLogUserNome[0];
            A754ReembolsoWorkflowConvenioSLA = T002K13_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = T002K13_n754ReembolsoWorkflowConvenioSLA[0];
            A763ReembolsoLogProtocolo = T002K13_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = T002K13_n763ReembolsoLogProtocolo[0];
            A761ReembolsoFlowLogDataFinal = T002K13_A761ReembolsoFlowLogDataFinal[0];
            n761ReembolsoFlowLogDataFinal = T002K13_n761ReembolsoFlowLogDataFinal[0];
            A750LogWorkflowConvenioId = T002K13_A750LogWorkflowConvenioId[0];
            n750LogWorkflowConvenioId = T002K13_n750LogWorkflowConvenioId[0];
            AssignAttri("", false, "A750LogWorkflowConvenioId", ((0==A750LogWorkflowConvenioId)&&IsIns( )||n750LogWorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ".", ""))));
            A744ReembolsoFlowLogUser = T002K13_A744ReembolsoFlowLogUser[0];
            n744ReembolsoFlowLogUser = T002K13_n744ReembolsoFlowLogUser[0];
            AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
            A748ReembolsoLogId = T002K13_A748ReembolsoLogId[0];
            n748ReembolsoLogId = T002K13_n748ReembolsoLogId[0];
            AssignAttri("", false, "A748ReembolsoLogId", ((0==A748ReembolsoLogId)&&IsIns( )||n748ReembolsoLogId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
            A749ReembolsoWorkFlowConvenioId = T002K13_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = T002K13_n749ReembolsoWorkFlowConvenioId[0];
            AssignAttri("", false, "A749ReembolsoWorkFlowConvenioId", StringUtil.LTrimStr( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0));
            A760LogReembolsoStatusAtual_F = T002K13_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = T002K13_n760LogReembolsoStatusAtual_F[0];
            ZM2K92( -15) ;
         }
         pr_default.close(7);
         OnLoadActions2K92( ) ;
      }

      protected void OnLoadActions2K92( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ReembolsoFlowLogUser) )
         {
            A744ReembolsoFlowLogUser = AV12Insert_ReembolsoFlowLogUser;
            n744ReembolsoFlowLogUser = false;
            AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV23ComboReembolsoFlowLogUser) )
            {
               A744ReembolsoFlowLogUser = 0;
               n744ReembolsoFlowLogUser = false;
               AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
               n744ReembolsoFlowLogUser = true;
               n744ReembolsoFlowLogUser = true;
               AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV23ComboReembolsoFlowLogUser) )
               {
                  A744ReembolsoFlowLogUser = AV23ComboReembolsoFlowLogUser;
                  n744ReembolsoFlowLogUser = false;
                  AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A744ReembolsoFlowLogUser) )
                  {
                     A744ReembolsoFlowLogUser = 0;
                     n744ReembolsoFlowLogUser = false;
                     AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
                     n744ReembolsoFlowLogUser = true;
                     n744ReembolsoFlowLogUser = true;
                     AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
                  }
               }
            }
         }
         A755ReembolsoFlowLogDataSLA_F = DateTimeUtil.TAdd( A747ReembolsoFlowLogDate, 86400*(A754ReembolsoWorkflowConvenioSLA));
         AssignAttri("", false, "A755ReembolsoFlowLogDataSLA_F", context.localUtil.TToC( A755ReembolsoFlowLogDataSLA_F, 8, 5, 0, 3, "/", ":", " "));
      }

      protected void CheckExtendedTable2K92( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ReembolsoFlowLogUser) )
         {
            A744ReembolsoFlowLogUser = AV12Insert_ReembolsoFlowLogUser;
            n744ReembolsoFlowLogUser = false;
            AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV23ComboReembolsoFlowLogUser) )
            {
               A744ReembolsoFlowLogUser = 0;
               n744ReembolsoFlowLogUser = false;
               AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
               n744ReembolsoFlowLogUser = true;
               n744ReembolsoFlowLogUser = true;
               AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV23ComboReembolsoFlowLogUser) )
               {
                  A744ReembolsoFlowLogUser = AV23ComboReembolsoFlowLogUser;
                  n744ReembolsoFlowLogUser = false;
                  AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A744ReembolsoFlowLogUser) )
                  {
                     A744ReembolsoFlowLogUser = 0;
                     n744ReembolsoFlowLogUser = false;
                     AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
                     n744ReembolsoFlowLogUser = true;
                     n744ReembolsoFlowLogUser = true;
                     AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
                  }
               }
            }
         }
         /* Using cursor T002K4 */
         pr_default.execute(2, new Object[] {n750LogWorkflowConvenioId, A750LogWorkflowConvenioId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A750LogWorkflowConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Reembolso Flow Log'.", "ForeignKeyNotFound", 1, "LOGWORKFLOWCONVENIOID");
               AnyError = 1;
               GX_FocusControl = edtLogWorkflowConvenioId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A752LogWorkflowConvenioDesc = T002K4_A752LogWorkflowConvenioDesc[0];
         n752LogWorkflowConvenioDesc = T002K4_n752LogWorkflowConvenioDesc[0];
         pr_default.close(2);
         /* Using cursor T002K5 */
         pr_default.execute(3, new Object[] {n744ReembolsoFlowLogUser, A744ReembolsoFlowLogUser});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A744ReembolsoFlowLogUser) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso Flow Log Sec User'.", "ForeignKeyNotFound", 1, "REEMBOLSOFLOWLOGUSER");
               AnyError = 1;
               GX_FocusControl = edtReembolsoFlowLogUser_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A745ReembolsoFlowLogUserNome = T002K5_A745ReembolsoFlowLogUserNome[0];
         n745ReembolsoFlowLogUserNome = T002K5_n745ReembolsoFlowLogUserNome[0];
         pr_default.close(3);
         /* Using cursor T002K6 */
         pr_default.execute(4, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A748ReembolsoLogId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Reembolso Log'.", "ForeignKeyNotFound", 1, "REEMBOLSOLOGID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoLogId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A763ReembolsoLogProtocolo = T002K6_A763ReembolsoLogProtocolo[0];
         n763ReembolsoLogProtocolo = T002K6_n763ReembolsoLogProtocolo[0];
         A749ReembolsoWorkFlowConvenioId = T002K6_A749ReembolsoWorkFlowConvenioId[0];
         n749ReembolsoWorkFlowConvenioId = T002K6_n749ReembolsoWorkFlowConvenioId[0];
         AssignAttri("", false, "A749ReembolsoWorkFlowConvenioId", StringUtil.LTrimStr( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0));
         pr_default.close(4);
         /* Using cursor T002K7 */
         pr_default.execute(5, new Object[] {n749ReembolsoWorkFlowConvenioId, A749ReembolsoWorkFlowConvenioId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A749ReembolsoWorkFlowConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Reembolso Log'.", "ForeignKeyNotFound", 1, "REEMBOLSOWORKFLOWCONVENIOID");
               AnyError = 1;
            }
         }
         A754ReembolsoWorkflowConvenioSLA = T002K7_A754ReembolsoWorkflowConvenioSLA[0];
         n754ReembolsoWorkflowConvenioSLA = T002K7_n754ReembolsoWorkflowConvenioSLA[0];
         pr_default.close(5);
         A755ReembolsoFlowLogDataSLA_F = DateTimeUtil.TAdd( A747ReembolsoFlowLogDate, 86400*(A754ReembolsoWorkflowConvenioSLA));
         AssignAttri("", false, "A755ReembolsoFlowLogDataSLA_F", context.localUtil.TToC( A755ReembolsoFlowLogDataSLA_F, 8, 5, 0, 3, "/", ":", " "));
         /* Using cursor T002K10 */
         pr_default.execute(6, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A760LogReembolsoStatusAtual_F = T002K10_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = T002K10_n760LogReembolsoStatusAtual_F[0];
         }
         else
         {
            A760LogReembolsoStatusAtual_F = "";
            n760LogReembolsoStatusAtual_F = false;
            AssignAttri("", false, "A760LogReembolsoStatusAtual_F", A760LogReembolsoStatusAtual_F);
         }
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors2K92( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( int A750LogWorkflowConvenioId )
      {
         /* Using cursor T002K14 */
         pr_default.execute(8, new Object[] {n750LogWorkflowConvenioId, A750LogWorkflowConvenioId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A750LogWorkflowConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Reembolso Flow Log'.", "ForeignKeyNotFound", 1, "LOGWORKFLOWCONVENIOID");
               AnyError = 1;
               GX_FocusControl = edtLogWorkflowConvenioId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A752LogWorkflowConvenioDesc = T002K14_A752LogWorkflowConvenioDesc[0];
         n752LogWorkflowConvenioDesc = T002K14_n752LogWorkflowConvenioDesc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A752LogWorkflowConvenioDesc)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_17( short A744ReembolsoFlowLogUser )
      {
         /* Using cursor T002K15 */
         pr_default.execute(9, new Object[] {n744ReembolsoFlowLogUser, A744ReembolsoFlowLogUser});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A744ReembolsoFlowLogUser) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso Flow Log Sec User'.", "ForeignKeyNotFound", 1, "REEMBOLSOFLOWLOGUSER");
               AnyError = 1;
               GX_FocusControl = edtReembolsoFlowLogUser_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A745ReembolsoFlowLogUserNome = T002K15_A745ReembolsoFlowLogUserNome[0];
         n745ReembolsoFlowLogUserNome = T002K15_n745ReembolsoFlowLogUserNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A745ReembolsoFlowLogUserNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_18( int A748ReembolsoLogId )
      {
         /* Using cursor T002K16 */
         pr_default.execute(10, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A748ReembolsoLogId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Reembolso Log'.", "ForeignKeyNotFound", 1, "REEMBOLSOLOGID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoLogId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A763ReembolsoLogProtocolo = T002K16_A763ReembolsoLogProtocolo[0];
         n763ReembolsoLogProtocolo = T002K16_n763ReembolsoLogProtocolo[0];
         A749ReembolsoWorkFlowConvenioId = T002K16_A749ReembolsoWorkFlowConvenioId[0];
         n749ReembolsoWorkFlowConvenioId = T002K16_n749ReembolsoWorkFlowConvenioId[0];
         AssignAttri("", false, "A749ReembolsoWorkFlowConvenioId", StringUtil.LTrimStr( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A763ReembolsoLogProtocolo)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_19( int A749ReembolsoWorkFlowConvenioId )
      {
         /* Using cursor T002K17 */
         pr_default.execute(11, new Object[] {n749ReembolsoWorkFlowConvenioId, A749ReembolsoWorkFlowConvenioId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A749ReembolsoWorkFlowConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Reembolso Log'.", "ForeignKeyNotFound", 1, "REEMBOLSOWORKFLOWCONVENIOID");
               AnyError = 1;
            }
         }
         A754ReembolsoWorkflowConvenioSLA = T002K17_A754ReembolsoWorkflowConvenioSLA[0];
         n754ReembolsoWorkflowConvenioSLA = T002K17_n754ReembolsoWorkflowConvenioSLA[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A754ReembolsoWorkflowConvenioSLA), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_20( int A748ReembolsoLogId )
      {
         /* Using cursor T002K20 */
         pr_default.execute(12, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A760LogReembolsoStatusAtual_F = T002K20_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = T002K20_n760LogReembolsoStatusAtual_F[0];
         }
         else
         {
            A760LogReembolsoStatusAtual_F = "";
            n760LogReembolsoStatusAtual_F = false;
            AssignAttri("", false, "A760LogReembolsoStatusAtual_F", A760LogReembolsoStatusAtual_F);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A760LogReembolsoStatusAtual_F)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey2K92( )
      {
         /* Using cursor T002K21 */
         pr_default.execute(13, new Object[] {A746ReembolsoFlowLogId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound92 = 1;
         }
         else
         {
            RcdFound92 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002K3 */
         pr_default.execute(1, new Object[] {A746ReembolsoFlowLogId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2K92( 15) ;
            RcdFound92 = 1;
            A746ReembolsoFlowLogId = T002K3_A746ReembolsoFlowLogId[0];
            AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
            A747ReembolsoFlowLogDate = T002K3_A747ReembolsoFlowLogDate[0];
            n747ReembolsoFlowLogDate = T002K3_n747ReembolsoFlowLogDate[0];
            AssignAttri("", false, "A747ReembolsoFlowLogDate", context.localUtil.TToC( A747ReembolsoFlowLogDate, 8, 5, 0, 3, "/", ":", " "));
            A761ReembolsoFlowLogDataFinal = T002K3_A761ReembolsoFlowLogDataFinal[0];
            n761ReembolsoFlowLogDataFinal = T002K3_n761ReembolsoFlowLogDataFinal[0];
            A750LogWorkflowConvenioId = T002K3_A750LogWorkflowConvenioId[0];
            n750LogWorkflowConvenioId = T002K3_n750LogWorkflowConvenioId[0];
            AssignAttri("", false, "A750LogWorkflowConvenioId", ((0==A750LogWorkflowConvenioId)&&IsIns( )||n750LogWorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ".", ""))));
            A744ReembolsoFlowLogUser = T002K3_A744ReembolsoFlowLogUser[0];
            n744ReembolsoFlowLogUser = T002K3_n744ReembolsoFlowLogUser[0];
            AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
            A748ReembolsoLogId = T002K3_A748ReembolsoLogId[0];
            n748ReembolsoLogId = T002K3_n748ReembolsoLogId[0];
            AssignAttri("", false, "A748ReembolsoLogId", ((0==A748ReembolsoLogId)&&IsIns( )||n748ReembolsoLogId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
            Z746ReembolsoFlowLogId = A746ReembolsoFlowLogId;
            sMode92 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2K92( ) ;
            if ( AnyError == 1 )
            {
               RcdFound92 = 0;
               InitializeNonKey2K92( ) ;
            }
            Gx_mode = sMode92;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound92 = 0;
            InitializeNonKey2K92( ) ;
            sMode92 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode92;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2K92( ) ;
         if ( RcdFound92 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound92 = 0;
         /* Using cursor T002K22 */
         pr_default.execute(14, new Object[] {A746ReembolsoFlowLogId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T002K22_A746ReembolsoFlowLogId[0] < A746ReembolsoFlowLogId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T002K22_A746ReembolsoFlowLogId[0] > A746ReembolsoFlowLogId ) ) )
            {
               A746ReembolsoFlowLogId = T002K22_A746ReembolsoFlowLogId[0];
               AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
               RcdFound92 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound92 = 0;
         /* Using cursor T002K23 */
         pr_default.execute(15, new Object[] {A746ReembolsoFlowLogId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T002K23_A746ReembolsoFlowLogId[0] > A746ReembolsoFlowLogId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T002K23_A746ReembolsoFlowLogId[0] < A746ReembolsoFlowLogId ) ) )
            {
               A746ReembolsoFlowLogId = T002K23_A746ReembolsoFlowLogId[0];
               AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
               RcdFound92 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2K92( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLogWorkflowConvenioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2K92( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound92 == 1 )
            {
               if ( A746ReembolsoFlowLogId != Z746ReembolsoFlowLogId )
               {
                  A746ReembolsoFlowLogId = Z746ReembolsoFlowLogId;
                  AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REEMBOLSOFLOWLOGID");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoFlowLogId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLogWorkflowConvenioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2K92( ) ;
                  GX_FocusControl = edtLogWorkflowConvenioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A746ReembolsoFlowLogId != Z746ReembolsoFlowLogId )
               {
                  /* Insert record */
                  GX_FocusControl = edtLogWorkflowConvenioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2K92( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REEMBOLSOFLOWLOGID");
                     AnyError = 1;
                     GX_FocusControl = edtReembolsoFlowLogId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtLogWorkflowConvenioId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2K92( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A746ReembolsoFlowLogId != Z746ReembolsoFlowLogId )
         {
            A746ReembolsoFlowLogId = Z746ReembolsoFlowLogId;
            AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REEMBOLSOFLOWLOGID");
            AnyError = 1;
            GX_FocusControl = edtReembolsoFlowLogId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLogWorkflowConvenioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2K92( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002K2 */
            pr_default.execute(0, new Object[] {A746ReembolsoFlowLogId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoFlowLog"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z747ReembolsoFlowLogDate != T002K2_A747ReembolsoFlowLogDate[0] ) || ( Z761ReembolsoFlowLogDataFinal != T002K2_A761ReembolsoFlowLogDataFinal[0] ) || ( Z750LogWorkflowConvenioId != T002K2_A750LogWorkflowConvenioId[0] ) || ( Z744ReembolsoFlowLogUser != T002K2_A744ReembolsoFlowLogUser[0] ) || ( Z748ReembolsoLogId != T002K2_A748ReembolsoLogId[0] ) )
            {
               if ( Z747ReembolsoFlowLogDate != T002K2_A747ReembolsoFlowLogDate[0] )
               {
                  GXUtil.WriteLog("reembolsoflowlog:[seudo value changed for attri]"+"ReembolsoFlowLogDate");
                  GXUtil.WriteLogRaw("Old: ",Z747ReembolsoFlowLogDate);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A747ReembolsoFlowLogDate[0]);
               }
               if ( Z761ReembolsoFlowLogDataFinal != T002K2_A761ReembolsoFlowLogDataFinal[0] )
               {
                  GXUtil.WriteLog("reembolsoflowlog:[seudo value changed for attri]"+"ReembolsoFlowLogDataFinal");
                  GXUtil.WriteLogRaw("Old: ",Z761ReembolsoFlowLogDataFinal);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A761ReembolsoFlowLogDataFinal[0]);
               }
               if ( Z750LogWorkflowConvenioId != T002K2_A750LogWorkflowConvenioId[0] )
               {
                  GXUtil.WriteLog("reembolsoflowlog:[seudo value changed for attri]"+"LogWorkflowConvenioId");
                  GXUtil.WriteLogRaw("Old: ",Z750LogWorkflowConvenioId);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A750LogWorkflowConvenioId[0]);
               }
               if ( Z744ReembolsoFlowLogUser != T002K2_A744ReembolsoFlowLogUser[0] )
               {
                  GXUtil.WriteLog("reembolsoflowlog:[seudo value changed for attri]"+"ReembolsoFlowLogUser");
                  GXUtil.WriteLogRaw("Old: ",Z744ReembolsoFlowLogUser);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A744ReembolsoFlowLogUser[0]);
               }
               if ( Z748ReembolsoLogId != T002K2_A748ReembolsoLogId[0] )
               {
                  GXUtil.WriteLog("reembolsoflowlog:[seudo value changed for attri]"+"ReembolsoLogId");
                  GXUtil.WriteLogRaw("Old: ",Z748ReembolsoLogId);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A748ReembolsoLogId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ReembolsoFlowLog"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2K92( )
      {
         BeforeValidate2K92( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K92( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2K92( 0) ;
            CheckOptimisticConcurrency2K92( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K92( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2K92( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002K24 */
                     pr_default.execute(16, new Object[] {n747ReembolsoFlowLogDate, A747ReembolsoFlowLogDate, n761ReembolsoFlowLogDataFinal, A761ReembolsoFlowLogDataFinal, n750LogWorkflowConvenioId, A750LogWorkflowConvenioId, n744ReembolsoFlowLogUser, A744ReembolsoFlowLogUser, n748ReembolsoLogId, A748ReembolsoLogId});
                     pr_default.close(16);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002K25 */
                     pr_default.execute(17);
                     A746ReembolsoFlowLogId = T002K25_A746ReembolsoFlowLogId[0];
                     AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoFlowLog");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2K0( ) ;
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
               Load2K92( ) ;
            }
            EndLevel2K92( ) ;
         }
         CloseExtendedTableCursors2K92( ) ;
      }

      protected void Update2K92( )
      {
         BeforeValidate2K92( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K92( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K92( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K92( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2K92( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002K26 */
                     pr_default.execute(18, new Object[] {n747ReembolsoFlowLogDate, A747ReembolsoFlowLogDate, n761ReembolsoFlowLogDataFinal, A761ReembolsoFlowLogDataFinal, n750LogWorkflowConvenioId, A750LogWorkflowConvenioId, n744ReembolsoFlowLogUser, A744ReembolsoFlowLogUser, n748ReembolsoLogId, A748ReembolsoLogId, A746ReembolsoFlowLogId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoFlowLog");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoFlowLog"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2K92( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
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
            EndLevel2K92( ) ;
         }
         CloseExtendedTableCursors2K92( ) ;
      }

      protected void DeferredUpdate2K92( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2K92( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K92( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2K92( ) ;
            AfterConfirm2K92( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2K92( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002K27 */
                  pr_default.execute(19, new Object[] {A746ReembolsoFlowLogId});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("ReembolsoFlowLog");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
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
         sMode92 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2K92( ) ;
         Gx_mode = sMode92;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2K92( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002K28 */
            pr_default.execute(20, new Object[] {n750LogWorkflowConvenioId, A750LogWorkflowConvenioId});
            A752LogWorkflowConvenioDesc = T002K28_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = T002K28_n752LogWorkflowConvenioDesc[0];
            pr_default.close(20);
            /* Using cursor T002K29 */
            pr_default.execute(21, new Object[] {n744ReembolsoFlowLogUser, A744ReembolsoFlowLogUser});
            A745ReembolsoFlowLogUserNome = T002K29_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = T002K29_n745ReembolsoFlowLogUserNome[0];
            pr_default.close(21);
            /* Using cursor T002K30 */
            pr_default.execute(22, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
            A763ReembolsoLogProtocolo = T002K30_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = T002K30_n763ReembolsoLogProtocolo[0];
            A749ReembolsoWorkFlowConvenioId = T002K30_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = T002K30_n749ReembolsoWorkFlowConvenioId[0];
            AssignAttri("", false, "A749ReembolsoWorkFlowConvenioId", StringUtil.LTrimStr( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0));
            pr_default.close(22);
            /* Using cursor T002K31 */
            pr_default.execute(23, new Object[] {n749ReembolsoWorkFlowConvenioId, A749ReembolsoWorkFlowConvenioId});
            A754ReembolsoWorkflowConvenioSLA = T002K31_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = T002K31_n754ReembolsoWorkflowConvenioSLA[0];
            pr_default.close(23);
            A755ReembolsoFlowLogDataSLA_F = DateTimeUtil.TAdd( A747ReembolsoFlowLogDate, 86400*(A754ReembolsoWorkflowConvenioSLA));
            AssignAttri("", false, "A755ReembolsoFlowLogDataSLA_F", context.localUtil.TToC( A755ReembolsoFlowLogDataSLA_F, 8, 5, 0, 3, "/", ":", " "));
            /* Using cursor T002K34 */
            pr_default.execute(24, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               A760LogReembolsoStatusAtual_F = T002K34_A760LogReembolsoStatusAtual_F[0];
               n760LogReembolsoStatusAtual_F = T002K34_n760LogReembolsoStatusAtual_F[0];
            }
            else
            {
               A760LogReembolsoStatusAtual_F = "";
               n760LogReembolsoStatusAtual_F = false;
               AssignAttri("", false, "A760LogReembolsoStatusAtual_F", A760LogReembolsoStatusAtual_F);
            }
            pr_default.close(24);
         }
      }

      protected void EndLevel2K92( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2K92( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2K0( ) ;
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

      public void ScanStart2K92( )
      {
         /* Scan By routine */
         /* Using cursor T002K35 */
         pr_default.execute(25);
         RcdFound92 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound92 = 1;
            A746ReembolsoFlowLogId = T002K35_A746ReembolsoFlowLogId[0];
            AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2K92( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound92 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound92 = 1;
            A746ReembolsoFlowLogId = T002K35_A746ReembolsoFlowLogId[0];
            AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
         }
      }

      protected void ScanEnd2K92( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm2K92( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2K92( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2K92( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2K92( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2K92( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2K92( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2K92( )
      {
         edtReembolsoFlowLogId_Enabled = 0;
         AssignProp("", false, edtReembolsoFlowLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoFlowLogId_Enabled), 5, 0), true);
         edtLogWorkflowConvenioId_Enabled = 0;
         AssignProp("", false, edtLogWorkflowConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLogWorkflowConvenioId_Enabled), 5, 0), true);
         edtReembolsoFlowLogDate_Enabled = 0;
         AssignProp("", false, edtReembolsoFlowLogDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoFlowLogDate_Enabled), 5, 0), true);
         edtReembolsoFlowLogUser_Enabled = 0;
         AssignProp("", false, edtReembolsoFlowLogUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoFlowLogUser_Enabled), 5, 0), true);
         edtReembolsoLogId_Enabled = 0;
         AssignProp("", false, edtReembolsoLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoLogId_Enabled), 5, 0), true);
         edtReembolsoWorkFlowConvenioId_Enabled = 0;
         AssignProp("", false, edtReembolsoWorkFlowConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoWorkFlowConvenioId_Enabled), 5, 0), true);
         edtavCombologworkflowconvenioid_Enabled = 0;
         AssignProp("", false, edtavCombologworkflowconvenioid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombologworkflowconvenioid_Enabled), 5, 0), true);
         edtavComboreembolsoflowloguser_Enabled = 0;
         AssignProp("", false, edtavComboreembolsoflowloguser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreembolsoflowloguser_Enabled), 5, 0), true);
         edtavComboreembolsologid_Enabled = 0;
         AssignProp("", false, edtavComboreembolsologid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreembolsologid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2K92( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2K0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormWithFixedActions\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "reembolsoflowlog"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ReembolsoFlowLogId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("reembolsoflowlog") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormWithFixedActions", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ReembolsoFlowLog");
         forbiddenHiddens.Add("ReembolsoFlowLogId", context.localUtil.Format( (decimal)(A746ReembolsoFlowLogId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_LogWorkflowConvenioId", context.localUtil.Format( (decimal)(AV11Insert_LogWorkflowConvenioId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ReembolsoFlowLogUser", context.localUtil.Format( (decimal)(AV12Insert_ReembolsoFlowLogUser), "ZZZ9"));
         forbiddenHiddens.Add("Insert_ReembolsoLogId", context.localUtil.Format( (decimal)(AV13Insert_ReembolsoLogId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ReembolsoFlowLogDataFinal", context.localUtil.Format( A761ReembolsoFlowLogDataFinal, "99/99/99 99:99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("reembolsoflowlog:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z746ReembolsoFlowLogId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z746ReembolsoFlowLogId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z747ReembolsoFlowLogDate", context.localUtil.TToC( Z747ReembolsoFlowLogDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z761ReembolsoFlowLogDataFinal", context.localUtil.TToC( Z761ReembolsoFlowLogDataFinal, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z750LogWorkflowConvenioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z750LogWorkflowConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z744ReembolsoFlowLogUser", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z744ReembolsoFlowLogUser), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z748ReembolsoLogId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z748ReembolsoLogId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N750LogWorkflowConvenioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N744ReembolsoFlowLogUser", StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N748ReembolsoLogId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLOGWORKFLOWCONVENIOID_DATA", AV15LogWorkflowConvenioId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLOGWORKFLOWCONVENIOID_DATA", AV15LogWorkflowConvenioId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vREEMBOLSOFLOWLOGUSER_DATA", AV22ReembolsoFlowLogUser_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vREEMBOLSOFLOWLOGUSER_DATA", AV22ReembolsoFlowLogUser_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vREEMBOLSOLOGID_DATA", AV25ReembolsoLogId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vREEMBOLSOLOGID_DATA", AV25ReembolsoLogId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "REEMBOLSOWORKFLOWCONVENIOSLA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A754ReembolsoWorkflowConvenioSLA), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "REEMBOLSOFLOWLOGDATASLA_F", context.localUtil.TToC( A755ReembolsoFlowLogDataSLA_F, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOFLOWLOGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ReembolsoFlowLogId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOFLOWLOGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ReembolsoFlowLogId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_LOGWORKFLOWCONVENIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_LogWorkflowConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_REEMBOLSOFLOWLOGUSER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_ReembolsoFlowLogUser), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_REEMBOLSOLOGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ReembolsoLogId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "REEMBOLSOFLOWLOGDATAFINAL", context.localUtil.TToC( A761ReembolsoFlowLogDataFinal, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "LOGWORKFLOWCONVENIODESC", A752LogWorkflowConvenioDesc);
         GxWebStd.gx_hidden_field( context, "REEMBOLSOFLOWLOGUSERNOME", A745ReembolsoFlowLogUserNome);
         GxWebStd.gx_hidden_field( context, "REEMBOLSOLOGPROTOCOLO", A763ReembolsoLogProtocolo);
         GxWebStd.gx_hidden_field( context, "LOGREEMBOLSOSTATUSATUAL_F", A760LogReembolsoStatusAtual_F);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_LOGWORKFLOWCONVENIOID_Objectcall", StringUtil.RTrim( Combo_logworkflowconvenioid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_LOGWORKFLOWCONVENIOID_Cls", StringUtil.RTrim( Combo_logworkflowconvenioid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_LOGWORKFLOWCONVENIOID_Selectedvalue_set", StringUtil.RTrim( Combo_logworkflowconvenioid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOGWORKFLOWCONVENIOID_Selectedtext_set", StringUtil.RTrim( Combo_logworkflowconvenioid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_LOGWORKFLOWCONVENIOID_Enabled", StringUtil.BoolToStr( Combo_logworkflowconvenioid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_LOGWORKFLOWCONVENIOID_Datalistproc", StringUtil.RTrim( Combo_logworkflowconvenioid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_LOGWORKFLOWCONVENIOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_logworkflowconvenioid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOFLOWLOGUSER_Objectcall", StringUtil.RTrim( Combo_reembolsoflowloguser_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOFLOWLOGUSER_Cls", StringUtil.RTrim( Combo_reembolsoflowloguser_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOFLOWLOGUSER_Selectedvalue_set", StringUtil.RTrim( Combo_reembolsoflowloguser_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOFLOWLOGUSER_Selectedtext_set", StringUtil.RTrim( Combo_reembolsoflowloguser_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOFLOWLOGUSER_Enabled", StringUtil.BoolToStr( Combo_reembolsoflowloguser_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOFLOWLOGUSER_Datalistproc", StringUtil.RTrim( Combo_reembolsoflowloguser_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOFLOWLOGUSER_Datalistprocparametersprefix", StringUtil.RTrim( Combo_reembolsoflowloguser_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOLOGID_Objectcall", StringUtil.RTrim( Combo_reembolsologid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOLOGID_Cls", StringUtil.RTrim( Combo_reembolsologid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOLOGID_Selectedvalue_set", StringUtil.RTrim( Combo_reembolsologid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOLOGID_Selectedtext_set", StringUtil.RTrim( Combo_reembolsologid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOLOGID_Enabled", StringUtil.BoolToStr( Combo_reembolsologid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOLOGID_Datalistproc", StringUtil.RTrim( Combo_reembolsologid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOLOGID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_reembolsologid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
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
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormWithFixedActions" : Form.Class)+"-fx");
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "reembolsoflowlog"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ReembolsoFlowLogId,9,0));
         return formatLink("reembolsoflowlog") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ReembolsoFlowLog" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reembolso Flow Log" ;
      }

      protected void InitializeNonKey2K92( )
      {
         A750LogWorkflowConvenioId = 0;
         n750LogWorkflowConvenioId = false;
         AssignAttri("", false, "A750LogWorkflowConvenioId", ((0==A750LogWorkflowConvenioId)&&IsIns( )||n750LogWorkflowConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ".", ""))));
         n750LogWorkflowConvenioId = ((0==A750LogWorkflowConvenioId) ? true : false);
         A744ReembolsoFlowLogUser = 0;
         n744ReembolsoFlowLogUser = false;
         AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
         n744ReembolsoFlowLogUser = ((0==A744ReembolsoFlowLogUser) ? true : false);
         A748ReembolsoLogId = 0;
         n748ReembolsoLogId = false;
         AssignAttri("", false, "A748ReembolsoLogId", ((0==A748ReembolsoLogId)&&IsIns( )||n748ReembolsoLogId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
         n748ReembolsoLogId = ((0==A748ReembolsoLogId) ? true : false);
         A755ReembolsoFlowLogDataSLA_F = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A755ReembolsoFlowLogDataSLA_F", context.localUtil.TToC( A755ReembolsoFlowLogDataSLA_F, 8, 5, 0, 3, "/", ":", " "));
         A752LogWorkflowConvenioDesc = "";
         n752LogWorkflowConvenioDesc = false;
         AssignAttri("", false, "A752LogWorkflowConvenioDesc", A752LogWorkflowConvenioDesc);
         A747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         n747ReembolsoFlowLogDate = false;
         AssignAttri("", false, "A747ReembolsoFlowLogDate", context.localUtil.TToC( A747ReembolsoFlowLogDate, 8, 5, 0, 3, "/", ":", " "));
         n747ReembolsoFlowLogDate = ((DateTime.MinValue==A747ReembolsoFlowLogDate) ? true : false);
         A745ReembolsoFlowLogUserNome = "";
         n745ReembolsoFlowLogUserNome = false;
         AssignAttri("", false, "A745ReembolsoFlowLogUserNome", A745ReembolsoFlowLogUserNome);
         A749ReembolsoWorkFlowConvenioId = 0;
         n749ReembolsoWorkFlowConvenioId = false;
         AssignAttri("", false, "A749ReembolsoWorkFlowConvenioId", StringUtil.LTrimStr( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0));
         A754ReembolsoWorkflowConvenioSLA = 0;
         n754ReembolsoWorkflowConvenioSLA = false;
         AssignAttri("", false, "A754ReembolsoWorkflowConvenioSLA", StringUtil.LTrimStr( (decimal)(A754ReembolsoWorkflowConvenioSLA), 4, 0));
         A760LogReembolsoStatusAtual_F = "";
         n760LogReembolsoStatusAtual_F = false;
         AssignAttri("", false, "A760LogReembolsoStatusAtual_F", A760LogReembolsoStatusAtual_F);
         A763ReembolsoLogProtocolo = "";
         n763ReembolsoLogProtocolo = false;
         AssignAttri("", false, "A763ReembolsoLogProtocolo", A763ReembolsoLogProtocolo);
         A764ReembolsoPaciente = "";
         AssignAttri("", false, "A764ReembolsoPaciente", A764ReembolsoPaciente);
         A761ReembolsoFlowLogDataFinal = (DateTime)(DateTime.MinValue);
         n761ReembolsoFlowLogDataFinal = false;
         AssignAttri("", false, "A761ReembolsoFlowLogDataFinal", context.localUtil.TToC( A761ReembolsoFlowLogDataFinal, 8, 5, 0, 3, "/", ":", " "));
         Z747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         Z761ReembolsoFlowLogDataFinal = (DateTime)(DateTime.MinValue);
         Z750LogWorkflowConvenioId = 0;
         Z744ReembolsoFlowLogUser = 0;
         Z748ReembolsoLogId = 0;
      }

      protected void InitAll2K92( )
      {
         A746ReembolsoFlowLogId = 0;
         AssignAttri("", false, "A746ReembolsoFlowLogId", StringUtil.LTrimStr( (decimal)(A746ReembolsoFlowLogId), 9, 0));
         InitializeNonKey2K92( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019205666", true, true);
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
         context.AddJavascriptSource("reembolsoflowlog.js", "?202561019205667", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtReembolsoFlowLogId_Internalname = "REEMBOLSOFLOWLOGID";
         lblTextblocklogworkflowconvenioid_Internalname = "TEXTBLOCKLOGWORKFLOWCONVENIOID";
         Combo_logworkflowconvenioid_Internalname = "COMBO_LOGWORKFLOWCONVENIOID";
         edtLogWorkflowConvenioId_Internalname = "LOGWORKFLOWCONVENIOID";
         divTablesplittedlogworkflowconvenioid_Internalname = "TABLESPLITTEDLOGWORKFLOWCONVENIOID";
         edtReembolsoFlowLogDate_Internalname = "REEMBOLSOFLOWLOGDATE";
         lblTextblockreembolsoflowloguser_Internalname = "TEXTBLOCKREEMBOLSOFLOWLOGUSER";
         Combo_reembolsoflowloguser_Internalname = "COMBO_REEMBOLSOFLOWLOGUSER";
         edtReembolsoFlowLogUser_Internalname = "REEMBOLSOFLOWLOGUSER";
         divTablesplittedreembolsoflowloguser_Internalname = "TABLESPLITTEDREEMBOLSOFLOWLOGUSER";
         lblTextblockreembolsologid_Internalname = "TEXTBLOCKREEMBOLSOLOGID";
         Combo_reembolsologid_Internalname = "COMBO_REEMBOLSOLOGID";
         edtReembolsoLogId_Internalname = "REEMBOLSOLOGID";
         divTablesplittedreembolsologid_Internalname = "TABLESPLITTEDREEMBOLSOLOGID";
         edtReembolsoWorkFlowConvenioId_Internalname = "REEMBOLSOWORKFLOWCONVENIOID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombologworkflowconvenioid_Internalname = "vCOMBOLOGWORKFLOWCONVENIOID";
         divSectionattribute_logworkflowconvenioid_Internalname = "SECTIONATTRIBUTE_LOGWORKFLOWCONVENIOID";
         edtavComboreembolsoflowloguser_Internalname = "vCOMBOREEMBOLSOFLOWLOGUSER";
         divSectionattribute_reembolsoflowloguser_Internalname = "SECTIONATTRIBUTE_REEMBOLSOFLOWLOGUSER";
         edtavComboreembolsologid_Internalname = "vCOMBOREEMBOLSOLOGID";
         divSectionattribute_reembolsologid_Internalname = "SECTIONATTRIBUTE_REEMBOLSOLOGID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
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
         Form.Caption = "Reembolso Flow Log";
         edtavComboreembolsologid_Jsonclick = "";
         edtavComboreembolsologid_Enabled = 0;
         edtavComboreembolsologid_Visible = 1;
         edtavComboreembolsoflowloguser_Jsonclick = "";
         edtavComboreembolsoflowloguser_Enabled = 0;
         edtavComboreembolsoflowloguser_Visible = 1;
         edtavCombologworkflowconvenioid_Jsonclick = "";
         edtavCombologworkflowconvenioid_Enabled = 0;
         edtavCombologworkflowconvenioid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtReembolsoWorkFlowConvenioId_Jsonclick = "";
         edtReembolsoWorkFlowConvenioId_Enabled = 0;
         edtReembolsoLogId_Jsonclick = "";
         edtReembolsoLogId_Enabled = 1;
         edtReembolsoLogId_Visible = 1;
         Combo_reembolsologid_Datalistprocparametersprefix = " \"ComboName\": \"ReembolsoLogId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ReembolsoFlowLogId\": 0";
         Combo_reembolsologid_Datalistproc = "ReembolsoFlowLogLoadDVCombo";
         Combo_reembolsologid_Cls = "ExtendedCombo AttributeFL";
         Combo_reembolsologid_Caption = "";
         Combo_reembolsologid_Enabled = Convert.ToBoolean( -1);
         edtReembolsoFlowLogUser_Jsonclick = "";
         edtReembolsoFlowLogUser_Enabled = 1;
         edtReembolsoFlowLogUser_Visible = 1;
         Combo_reembolsoflowloguser_Datalistprocparametersprefix = " \"ComboName\": \"ReembolsoFlowLogUser\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ReembolsoFlowLogId\": 0";
         Combo_reembolsoflowloguser_Datalistproc = "ReembolsoFlowLogLoadDVCombo";
         Combo_reembolsoflowloguser_Cls = "ExtendedCombo AttributeFL";
         Combo_reembolsoflowloguser_Caption = "";
         Combo_reembolsoflowloguser_Enabled = Convert.ToBoolean( -1);
         edtReembolsoFlowLogDate_Jsonclick = "";
         edtReembolsoFlowLogDate_Enabled = 1;
         edtLogWorkflowConvenioId_Jsonclick = "";
         edtLogWorkflowConvenioId_Enabled = 1;
         edtLogWorkflowConvenioId_Visible = 1;
         Combo_logworkflowconvenioid_Datalistprocparametersprefix = " \"ComboName\": \"LogWorkflowConvenioId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ReembolsoFlowLogId\": 0";
         Combo_logworkflowconvenioid_Datalistproc = "ReembolsoFlowLogLoadDVCombo";
         Combo_logworkflowconvenioid_Cls = "ExtendedCombo AttributeFL";
         Combo_logworkflowconvenioid_Caption = "";
         Combo_logworkflowconvenioid_Enabled = Convert.ToBoolean( -1);
         edtReembolsoFlowLogId_Jsonclick = "";
         edtReembolsoFlowLogId_Enabled = 0;
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

      public void Valid_Logworkflowconvenioid( )
      {
         n752LogWorkflowConvenioDesc = false;
         /* Using cursor T002K28 */
         pr_default.execute(20, new Object[] {n750LogWorkflowConvenioId, A750LogWorkflowConvenioId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A750LogWorkflowConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Reembolso Flow Log'.", "ForeignKeyNotFound", 1, "LOGWORKFLOWCONVENIOID");
               AnyError = 1;
               GX_FocusControl = edtLogWorkflowConvenioId_Internalname;
            }
         }
         A752LogWorkflowConvenioDesc = T002K28_A752LogWorkflowConvenioDesc[0];
         n752LogWorkflowConvenioDesc = T002K28_n752LogWorkflowConvenioDesc[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A752LogWorkflowConvenioDesc", A752LogWorkflowConvenioDesc);
      }

      public void Valid_Reembolsoflowloguser( )
      {
         n745ReembolsoFlowLogUserNome = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ReembolsoFlowLogUser) )
         {
            A744ReembolsoFlowLogUser = AV12Insert_ReembolsoFlowLogUser;
            n744ReembolsoFlowLogUser = false;
         }
         else
         {
            if ( (0==AV23ComboReembolsoFlowLogUser) )
            {
               A744ReembolsoFlowLogUser = 0;
               n744ReembolsoFlowLogUser = false;
               n744ReembolsoFlowLogUser = true;
               n744ReembolsoFlowLogUser = true;
            }
            else
            {
               if ( ! (0==AV23ComboReembolsoFlowLogUser) )
               {
                  A744ReembolsoFlowLogUser = AV23ComboReembolsoFlowLogUser;
                  n744ReembolsoFlowLogUser = false;
               }
               else
               {
                  if ( (0==A744ReembolsoFlowLogUser) )
                  {
                     A744ReembolsoFlowLogUser = 0;
                     n744ReembolsoFlowLogUser = false;
                     n744ReembolsoFlowLogUser = true;
                     n744ReembolsoFlowLogUser = true;
                  }
               }
            }
         }
         /* Using cursor T002K29 */
         pr_default.execute(21, new Object[] {n744ReembolsoFlowLogUser, A744ReembolsoFlowLogUser});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A744ReembolsoFlowLogUser) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso Flow Log Sec User'.", "ForeignKeyNotFound", 1, "REEMBOLSOFLOWLOGUSER");
               AnyError = 1;
               GX_FocusControl = edtReembolsoFlowLogUser_Internalname;
            }
         }
         A745ReembolsoFlowLogUserNome = T002K29_A745ReembolsoFlowLogUserNome[0];
         n745ReembolsoFlowLogUserNome = T002K29_n745ReembolsoFlowLogUserNome[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A744ReembolsoFlowLogUser", ((0==A744ReembolsoFlowLogUser)&&IsIns( )||n744ReembolsoFlowLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
         AssignAttri("", false, "A745ReembolsoFlowLogUserNome", A745ReembolsoFlowLogUserNome);
      }

      public void Valid_Reembolsologid( )
      {
         n749ReembolsoWorkFlowConvenioId = false;
         n747ReembolsoFlowLogDate = false;
         n754ReembolsoWorkflowConvenioSLA = false;
         n763ReembolsoLogProtocolo = false;
         n760LogReembolsoStatusAtual_F = false;
         /* Using cursor T002K30 */
         pr_default.execute(22, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( (0==A748ReembolsoLogId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Reembolso Log'.", "ForeignKeyNotFound", 1, "REEMBOLSOLOGID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoLogId_Internalname;
            }
         }
         A763ReembolsoLogProtocolo = T002K30_A763ReembolsoLogProtocolo[0];
         n763ReembolsoLogProtocolo = T002K30_n763ReembolsoLogProtocolo[0];
         A749ReembolsoWorkFlowConvenioId = T002K30_A749ReembolsoWorkFlowConvenioId[0];
         n749ReembolsoWorkFlowConvenioId = T002K30_n749ReembolsoWorkFlowConvenioId[0];
         pr_default.close(22);
         /* Using cursor T002K31 */
         pr_default.execute(23, new Object[] {n749ReembolsoWorkFlowConvenioId, A749ReembolsoWorkFlowConvenioId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A749ReembolsoWorkFlowConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Reembolso Log'.", "ForeignKeyNotFound", 1, "REEMBOLSOWORKFLOWCONVENIOID");
               AnyError = 1;
            }
         }
         A754ReembolsoWorkflowConvenioSLA = T002K31_A754ReembolsoWorkflowConvenioSLA[0];
         n754ReembolsoWorkflowConvenioSLA = T002K31_n754ReembolsoWorkflowConvenioSLA[0];
         pr_default.close(23);
         A755ReembolsoFlowLogDataSLA_F = DateTimeUtil.TAdd( A747ReembolsoFlowLogDate, 86400*(A754ReembolsoWorkflowConvenioSLA));
         /* Using cursor T002K34 */
         pr_default.execute(24, new Object[] {n748ReembolsoLogId, A748ReembolsoLogId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            A760LogReembolsoStatusAtual_F = T002K34_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = T002K34_n760LogReembolsoStatusAtual_F[0];
         }
         else
         {
            A760LogReembolsoStatusAtual_F = "";
            n760LogReembolsoStatusAtual_F = false;
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A763ReembolsoLogProtocolo", A763ReembolsoLogProtocolo);
         AssignAttri("", false, "A749ReembolsoWorkFlowConvenioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0, ".", "")));
         AssignAttri("", false, "A754ReembolsoWorkflowConvenioSLA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A754ReembolsoWorkflowConvenioSLA), 4, 0, ".", "")));
         AssignAttri("", false, "A755ReembolsoFlowLogDataSLA_F", context.localUtil.TToC( A755ReembolsoFlowLogDataSLA_F, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A760LogReembolsoStatusAtual_F", A760LogReembolsoStatusAtual_F);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ReembolsoFlowLogId","fld":"vREEMBOLSOFLOWLOGID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ReembolsoFlowLogId","fld":"vREEMBOLSOFLOWLOGID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A746ReembolsoFlowLogId","fld":"REEMBOLSOFLOWLOGID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_LogWorkflowConvenioId","fld":"vINSERT_LOGWORKFLOWCONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_ReembolsoFlowLogUser","fld":"vINSERT_REEMBOLSOFLOWLOGUSER","pic":"ZZZ9","type":"int"},{"av":"AV13Insert_ReembolsoLogId","fld":"vINSERT_REEMBOLSOLOGID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A761ReembolsoFlowLogDataFinal","fld":"REEMBOLSOFLOWLOGDATAFINAL","pic":"99/99/99 99:99","type":"dtime"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122K2","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOFLOWLOGID","""{"handler":"Valid_Reembolsoflowlogid","iparms":[]}""");
         setEventMetadata("VALID_LOGWORKFLOWCONVENIOID","""{"handler":"Valid_Logworkflowconvenioid","iparms":[{"av":"A750LogWorkflowConvenioId","fld":"LOGWORKFLOWCONVENIOID","pic":"ZZZZZZZZ9","nullAv":"n750LogWorkflowConvenioId","type":"int"},{"av":"A752LogWorkflowConvenioDesc","fld":"LOGWORKFLOWCONVENIODESC","type":"svchar"}]""");
         setEventMetadata("VALID_LOGWORKFLOWCONVENIOID",""","oparms":[{"av":"A752LogWorkflowConvenioDesc","fld":"LOGWORKFLOWCONVENIODESC","type":"svchar"}]}""");
         setEventMetadata("VALID_REEMBOLSOFLOWLOGDATE","""{"handler":"Valid_Reembolsoflowlogdate","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOFLOWLOGUSER","""{"handler":"Valid_Reembolsoflowloguser","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV12Insert_ReembolsoFlowLogUser","fld":"vINSERT_REEMBOLSOFLOWLOGUSER","pic":"ZZZ9","type":"int"},{"av":"AV23ComboReembolsoFlowLogUser","fld":"vCOMBOREEMBOLSOFLOWLOGUSER","pic":"ZZZ9","type":"int"},{"av":"A744ReembolsoFlowLogUser","fld":"REEMBOLSOFLOWLOGUSER","pic":"ZZZ9","nullAv":"n744ReembolsoFlowLogUser","type":"int"},{"av":"A745ReembolsoFlowLogUserNome","fld":"REEMBOLSOFLOWLOGUSERNOME","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_REEMBOLSOFLOWLOGUSER",""","oparms":[{"av":"A744ReembolsoFlowLogUser","fld":"REEMBOLSOFLOWLOGUSER","pic":"ZZZ9","nullAv":"n744ReembolsoFlowLogUser","type":"int"},{"av":"A745ReembolsoFlowLogUserNome","fld":"REEMBOLSOFLOWLOGUSERNOME","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALID_REEMBOLSOLOGID","""{"handler":"Valid_Reembolsologid","iparms":[{"av":"A748ReembolsoLogId","fld":"REEMBOLSOLOGID","pic":"ZZZZZZZZ9","nullAv":"n748ReembolsoLogId","type":"int"},{"av":"A749ReembolsoWorkFlowConvenioId","fld":"REEMBOLSOWORKFLOWCONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A747ReembolsoFlowLogDate","fld":"REEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"A754ReembolsoWorkflowConvenioSLA","fld":"REEMBOLSOWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"A763ReembolsoLogProtocolo","fld":"REEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"A755ReembolsoFlowLogDataSLA_F","fld":"REEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"A760LogReembolsoStatusAtual_F","fld":"LOGREEMBOLSOSTATUSATUAL_F","type":"svchar"}]""");
         setEventMetadata("VALID_REEMBOLSOLOGID",""","oparms":[{"av":"A763ReembolsoLogProtocolo","fld":"REEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"A749ReembolsoWorkFlowConvenioId","fld":"REEMBOLSOWORKFLOWCONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A754ReembolsoWorkflowConvenioSLA","fld":"REEMBOLSOWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"A755ReembolsoFlowLogDataSLA_F","fld":"REEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"A760LogReembolsoStatusAtual_F","fld":"LOGREEMBOLSOSTATUSATUAL_F","type":"svchar"}]}""");
         setEventMetadata("VALID_REEMBOLSOWORKFLOWCONVENIOID","""{"handler":"Valid_Reembolsoworkflowconvenioid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOLOGWORKFLOWCONVENIOID","""{"handler":"Validv_Combologworkflowconvenioid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOREEMBOLSOFLOWLOGUSER","""{"handler":"Validv_Comboreembolsoflowloguser","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOREEMBOLSOLOGID","""{"handler":"Validv_Comboreembolsologid","iparms":[]}""");
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
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(24);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         Z761ReembolsoFlowLogDataFinal = (DateTime)(DateTime.MinValue);
         Combo_reembolsologid_Selectedvalue_get = "";
         Combo_reembolsoflowloguser_Selectedvalue_get = "";
         Combo_logworkflowconvenioid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblocklogworkflowconvenioid_Jsonclick = "";
         ucCombo_logworkflowconvenioid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15LogWorkflowConvenioId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         lblTextblockreembolsoflowloguser_Jsonclick = "";
         ucCombo_reembolsoflowloguser = new GXUserControl();
         AV22ReembolsoFlowLogUser_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockreembolsologid_Jsonclick = "";
         ucCombo_reembolsologid = new GXUserControl();
         AV25ReembolsoLogId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A761ReembolsoFlowLogDataFinal = (DateTime)(DateTime.MinValue);
         A755ReembolsoFlowLogDataSLA_F = (DateTime)(DateTime.MinValue);
         A752LogWorkflowConvenioDesc = "";
         A745ReembolsoFlowLogUserNome = "";
         A763ReembolsoLogProtocolo = "";
         A760LogReembolsoStatusAtual_F = "";
         AV28Pgmname = "";
         Combo_logworkflowconvenioid_Objectcall = "";
         Combo_logworkflowconvenioid_Class = "";
         Combo_logworkflowconvenioid_Icontype = "";
         Combo_logworkflowconvenioid_Icon = "";
         Combo_logworkflowconvenioid_Tooltip = "";
         Combo_logworkflowconvenioid_Selectedvalue_set = "";
         Combo_logworkflowconvenioid_Selectedtext_set = "";
         Combo_logworkflowconvenioid_Selectedtext_get = "";
         Combo_logworkflowconvenioid_Gamoauthtoken = "";
         Combo_logworkflowconvenioid_Ddointernalname = "";
         Combo_logworkflowconvenioid_Titlecontrolalign = "";
         Combo_logworkflowconvenioid_Dropdownoptionstype = "";
         Combo_logworkflowconvenioid_Titlecontrolidtoreplace = "";
         Combo_logworkflowconvenioid_Datalisttype = "";
         Combo_logworkflowconvenioid_Datalistfixedvalues = "";
         Combo_logworkflowconvenioid_Remoteservicesparameters = "";
         Combo_logworkflowconvenioid_Htmltemplate = "";
         Combo_logworkflowconvenioid_Multiplevaluestype = "";
         Combo_logworkflowconvenioid_Loadingdata = "";
         Combo_logworkflowconvenioid_Noresultsfound = "";
         Combo_logworkflowconvenioid_Emptyitemtext = "";
         Combo_logworkflowconvenioid_Onlyselectedvalues = "";
         Combo_logworkflowconvenioid_Selectalltext = "";
         Combo_logworkflowconvenioid_Multiplevaluesseparator = "";
         Combo_logworkflowconvenioid_Addnewoptiontext = "";
         Combo_reembolsoflowloguser_Objectcall = "";
         Combo_reembolsoflowloguser_Class = "";
         Combo_reembolsoflowloguser_Icontype = "";
         Combo_reembolsoflowloguser_Icon = "";
         Combo_reembolsoflowloguser_Tooltip = "";
         Combo_reembolsoflowloguser_Selectedvalue_set = "";
         Combo_reembolsoflowloguser_Selectedtext_set = "";
         Combo_reembolsoflowloguser_Selectedtext_get = "";
         Combo_reembolsoflowloguser_Gamoauthtoken = "";
         Combo_reembolsoflowloguser_Ddointernalname = "";
         Combo_reembolsoflowloguser_Titlecontrolalign = "";
         Combo_reembolsoflowloguser_Dropdownoptionstype = "";
         Combo_reembolsoflowloguser_Titlecontrolidtoreplace = "";
         Combo_reembolsoflowloguser_Datalisttype = "";
         Combo_reembolsoflowloguser_Datalistfixedvalues = "";
         Combo_reembolsoflowloguser_Remoteservicesparameters = "";
         Combo_reembolsoflowloguser_Htmltemplate = "";
         Combo_reembolsoflowloguser_Multiplevaluestype = "";
         Combo_reembolsoflowloguser_Loadingdata = "";
         Combo_reembolsoflowloguser_Noresultsfound = "";
         Combo_reembolsoflowloguser_Emptyitemtext = "";
         Combo_reembolsoflowloguser_Onlyselectedvalues = "";
         Combo_reembolsoflowloguser_Selectalltext = "";
         Combo_reembolsoflowloguser_Multiplevaluesseparator = "";
         Combo_reembolsoflowloguser_Addnewoptiontext = "";
         Combo_reembolsologid_Objectcall = "";
         Combo_reembolsologid_Class = "";
         Combo_reembolsologid_Icontype = "";
         Combo_reembolsologid_Icon = "";
         Combo_reembolsologid_Tooltip = "";
         Combo_reembolsologid_Selectedvalue_set = "";
         Combo_reembolsologid_Selectedtext_set = "";
         Combo_reembolsologid_Selectedtext_get = "";
         Combo_reembolsologid_Gamoauthtoken = "";
         Combo_reembolsologid_Ddointernalname = "";
         Combo_reembolsologid_Titlecontrolalign = "";
         Combo_reembolsologid_Dropdownoptionstype = "";
         Combo_reembolsologid_Titlecontrolidtoreplace = "";
         Combo_reembolsologid_Datalisttype = "";
         Combo_reembolsologid_Datalistfixedvalues = "";
         Combo_reembolsologid_Remoteservicesparameters = "";
         Combo_reembolsologid_Htmltemplate = "";
         Combo_reembolsologid_Multiplevaluestype = "";
         Combo_reembolsologid_Loadingdata = "";
         Combo_reembolsologid_Noresultsfound = "";
         Combo_reembolsologid_Emptyitemtext = "";
         Combo_reembolsologid_Onlyselectedvalues = "";
         Combo_reembolsologid_Selectalltext = "";
         Combo_reembolsologid_Multiplevaluesseparator = "";
         Combo_reembolsologid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode92 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char2 = "";
         Z752LogWorkflowConvenioDesc = "";
         Z745ReembolsoFlowLogUserNome = "";
         Z763ReembolsoLogProtocolo = "";
         Z760LogReembolsoStatusAtual_F = "";
         T002K4_A752LogWorkflowConvenioDesc = new string[] {""} ;
         T002K4_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         T002K6_A763ReembolsoLogProtocolo = new string[] {""} ;
         T002K6_n763ReembolsoLogProtocolo = new bool[] {false} ;
         T002K6_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         T002K6_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         T002K7_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         T002K7_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         T002K10_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         T002K10_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         T002K13_A746ReembolsoFlowLogId = new int[1] ;
         T002K13_A752LogWorkflowConvenioDesc = new string[] {""} ;
         T002K13_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         T002K13_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         T002K13_n747ReembolsoFlowLogDate = new bool[] {false} ;
         T002K13_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         T002K13_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         T002K13_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         T002K13_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         T002K13_A763ReembolsoLogProtocolo = new string[] {""} ;
         T002K13_n763ReembolsoLogProtocolo = new bool[] {false} ;
         T002K13_A761ReembolsoFlowLogDataFinal = new DateTime[] {DateTime.MinValue} ;
         T002K13_n761ReembolsoFlowLogDataFinal = new bool[] {false} ;
         T002K13_A750LogWorkflowConvenioId = new int[1] ;
         T002K13_n750LogWorkflowConvenioId = new bool[] {false} ;
         T002K13_A744ReembolsoFlowLogUser = new short[1] ;
         T002K13_n744ReembolsoFlowLogUser = new bool[] {false} ;
         T002K13_A748ReembolsoLogId = new int[1] ;
         T002K13_n748ReembolsoLogId = new bool[] {false} ;
         T002K13_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         T002K13_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         T002K13_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         T002K13_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         T002K5_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         T002K5_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         T002K14_A752LogWorkflowConvenioDesc = new string[] {""} ;
         T002K14_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         T002K15_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         T002K15_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         T002K16_A763ReembolsoLogProtocolo = new string[] {""} ;
         T002K16_n763ReembolsoLogProtocolo = new bool[] {false} ;
         T002K16_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         T002K16_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         T002K17_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         T002K17_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         T002K20_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         T002K20_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         T002K21_A746ReembolsoFlowLogId = new int[1] ;
         T002K3_A746ReembolsoFlowLogId = new int[1] ;
         T002K3_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         T002K3_n747ReembolsoFlowLogDate = new bool[] {false} ;
         T002K3_A761ReembolsoFlowLogDataFinal = new DateTime[] {DateTime.MinValue} ;
         T002K3_n761ReembolsoFlowLogDataFinal = new bool[] {false} ;
         T002K3_A750LogWorkflowConvenioId = new int[1] ;
         T002K3_n750LogWorkflowConvenioId = new bool[] {false} ;
         T002K3_A744ReembolsoFlowLogUser = new short[1] ;
         T002K3_n744ReembolsoFlowLogUser = new bool[] {false} ;
         T002K3_A748ReembolsoLogId = new int[1] ;
         T002K3_n748ReembolsoLogId = new bool[] {false} ;
         T002K22_A746ReembolsoFlowLogId = new int[1] ;
         T002K23_A746ReembolsoFlowLogId = new int[1] ;
         T002K2_A746ReembolsoFlowLogId = new int[1] ;
         T002K2_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         T002K2_n747ReembolsoFlowLogDate = new bool[] {false} ;
         T002K2_A761ReembolsoFlowLogDataFinal = new DateTime[] {DateTime.MinValue} ;
         T002K2_n761ReembolsoFlowLogDataFinal = new bool[] {false} ;
         T002K2_A750LogWorkflowConvenioId = new int[1] ;
         T002K2_n750LogWorkflowConvenioId = new bool[] {false} ;
         T002K2_A744ReembolsoFlowLogUser = new short[1] ;
         T002K2_n744ReembolsoFlowLogUser = new bool[] {false} ;
         T002K2_A748ReembolsoLogId = new int[1] ;
         T002K2_n748ReembolsoLogId = new bool[] {false} ;
         T002K25_A746ReembolsoFlowLogId = new int[1] ;
         T002K28_A752LogWorkflowConvenioDesc = new string[] {""} ;
         T002K28_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         T002K29_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         T002K29_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         T002K30_A763ReembolsoLogProtocolo = new string[] {""} ;
         T002K30_n763ReembolsoLogProtocolo = new bool[] {false} ;
         T002K30_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         T002K30_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         T002K31_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         T002K31_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         T002K34_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         T002K34_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         T002K35_A746ReembolsoFlowLogId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         A764ReembolsoPaciente = "";
         Z755ReembolsoFlowLogDataSLA_F = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoflowlog__default(),
            new Object[][] {
                new Object[] {
               T002K2_A746ReembolsoFlowLogId, T002K2_A747ReembolsoFlowLogDate, T002K2_n747ReembolsoFlowLogDate, T002K2_A761ReembolsoFlowLogDataFinal, T002K2_n761ReembolsoFlowLogDataFinal, T002K2_A750LogWorkflowConvenioId, T002K2_n750LogWorkflowConvenioId, T002K2_A744ReembolsoFlowLogUser, T002K2_n744ReembolsoFlowLogUser, T002K2_A748ReembolsoLogId,
               T002K2_n748ReembolsoLogId
               }
               , new Object[] {
               T002K3_A746ReembolsoFlowLogId, T002K3_A747ReembolsoFlowLogDate, T002K3_n747ReembolsoFlowLogDate, T002K3_A761ReembolsoFlowLogDataFinal, T002K3_n761ReembolsoFlowLogDataFinal, T002K3_A750LogWorkflowConvenioId, T002K3_n750LogWorkflowConvenioId, T002K3_A744ReembolsoFlowLogUser, T002K3_n744ReembolsoFlowLogUser, T002K3_A748ReembolsoLogId,
               T002K3_n748ReembolsoLogId
               }
               , new Object[] {
               T002K4_A752LogWorkflowConvenioDesc, T002K4_n752LogWorkflowConvenioDesc
               }
               , new Object[] {
               T002K5_A745ReembolsoFlowLogUserNome, T002K5_n745ReembolsoFlowLogUserNome
               }
               , new Object[] {
               T002K6_A763ReembolsoLogProtocolo, T002K6_n763ReembolsoLogProtocolo, T002K6_A749ReembolsoWorkFlowConvenioId, T002K6_n749ReembolsoWorkFlowConvenioId
               }
               , new Object[] {
               T002K7_A754ReembolsoWorkflowConvenioSLA, T002K7_n754ReembolsoWorkflowConvenioSLA
               }
               , new Object[] {
               T002K10_A760LogReembolsoStatusAtual_F, T002K10_n760LogReembolsoStatusAtual_F
               }
               , new Object[] {
               T002K13_A746ReembolsoFlowLogId, T002K13_A752LogWorkflowConvenioDesc, T002K13_n752LogWorkflowConvenioDesc, T002K13_A747ReembolsoFlowLogDate, T002K13_n747ReembolsoFlowLogDate, T002K13_A745ReembolsoFlowLogUserNome, T002K13_n745ReembolsoFlowLogUserNome, T002K13_A754ReembolsoWorkflowConvenioSLA, T002K13_n754ReembolsoWorkflowConvenioSLA, T002K13_A763ReembolsoLogProtocolo,
               T002K13_n763ReembolsoLogProtocolo, T002K13_A761ReembolsoFlowLogDataFinal, T002K13_n761ReembolsoFlowLogDataFinal, T002K13_A750LogWorkflowConvenioId, T002K13_n750LogWorkflowConvenioId, T002K13_A744ReembolsoFlowLogUser, T002K13_n744ReembolsoFlowLogUser, T002K13_A748ReembolsoLogId, T002K13_n748ReembolsoLogId, T002K13_A749ReembolsoWorkFlowConvenioId,
               T002K13_n749ReembolsoWorkFlowConvenioId, T002K13_A760LogReembolsoStatusAtual_F, T002K13_n760LogReembolsoStatusAtual_F
               }
               , new Object[] {
               T002K14_A752LogWorkflowConvenioDesc, T002K14_n752LogWorkflowConvenioDesc
               }
               , new Object[] {
               T002K15_A745ReembolsoFlowLogUserNome, T002K15_n745ReembolsoFlowLogUserNome
               }
               , new Object[] {
               T002K16_A763ReembolsoLogProtocolo, T002K16_n763ReembolsoLogProtocolo, T002K16_A749ReembolsoWorkFlowConvenioId, T002K16_n749ReembolsoWorkFlowConvenioId
               }
               , new Object[] {
               T002K17_A754ReembolsoWorkflowConvenioSLA, T002K17_n754ReembolsoWorkflowConvenioSLA
               }
               , new Object[] {
               T002K20_A760LogReembolsoStatusAtual_F, T002K20_n760LogReembolsoStatusAtual_F
               }
               , new Object[] {
               T002K21_A746ReembolsoFlowLogId
               }
               , new Object[] {
               T002K22_A746ReembolsoFlowLogId
               }
               , new Object[] {
               T002K23_A746ReembolsoFlowLogId
               }
               , new Object[] {
               }
               , new Object[] {
               T002K25_A746ReembolsoFlowLogId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002K28_A752LogWorkflowConvenioDesc, T002K28_n752LogWorkflowConvenioDesc
               }
               , new Object[] {
               T002K29_A745ReembolsoFlowLogUserNome, T002K29_n745ReembolsoFlowLogUserNome
               }
               , new Object[] {
               T002K30_A763ReembolsoLogProtocolo, T002K30_n763ReembolsoLogProtocolo, T002K30_A749ReembolsoWorkFlowConvenioId, T002K30_n749ReembolsoWorkFlowConvenioId
               }
               , new Object[] {
               T002K31_A754ReembolsoWorkflowConvenioSLA, T002K31_n754ReembolsoWorkflowConvenioSLA
               }
               , new Object[] {
               T002K34_A760LogReembolsoStatusAtual_F, T002K34_n760LogReembolsoStatusAtual_F
               }
               , new Object[] {
               T002K35_A746ReembolsoFlowLogId
               }
            }
         );
         AV28Pgmname = "ReembolsoFlowLog";
      }

      private short Z744ReembolsoFlowLogUser ;
      private short N744ReembolsoFlowLogUser ;
      private short GxWebError ;
      private short A744ReembolsoFlowLogUser ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV23ComboReembolsoFlowLogUser ;
      private short A754ReembolsoWorkflowConvenioSLA ;
      private short AV12Insert_ReembolsoFlowLogUser ;
      private short RcdFound92 ;
      private short Z754ReembolsoWorkflowConvenioSLA ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7ReembolsoFlowLogId ;
      private int Z746ReembolsoFlowLogId ;
      private int Z750LogWorkflowConvenioId ;
      private int Z748ReembolsoLogId ;
      private int N750LogWorkflowConvenioId ;
      private int N748ReembolsoLogId ;
      private int A750LogWorkflowConvenioId ;
      private int A748ReembolsoLogId ;
      private int A749ReembolsoWorkFlowConvenioId ;
      private int AV7ReembolsoFlowLogId ;
      private int trnEnded ;
      private int A746ReembolsoFlowLogId ;
      private int edtReembolsoFlowLogId_Enabled ;
      private int edtLogWorkflowConvenioId_Visible ;
      private int edtLogWorkflowConvenioId_Enabled ;
      private int edtReembolsoFlowLogDate_Enabled ;
      private int edtReembolsoFlowLogUser_Visible ;
      private int edtReembolsoFlowLogUser_Enabled ;
      private int edtReembolsoLogId_Visible ;
      private int edtReembolsoLogId_Enabled ;
      private int edtReembolsoWorkFlowConvenioId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV20ComboLogWorkflowConvenioId ;
      private int edtavCombologworkflowconvenioid_Enabled ;
      private int edtavCombologworkflowconvenioid_Visible ;
      private int edtavComboreembolsoflowloguser_Enabled ;
      private int edtavComboreembolsoflowloguser_Visible ;
      private int AV26ComboReembolsoLogId ;
      private int edtavComboreembolsologid_Enabled ;
      private int edtavComboreembolsologid_Visible ;
      private int AV11Insert_LogWorkflowConvenioId ;
      private int AV13Insert_ReembolsoLogId ;
      private int Combo_logworkflowconvenioid_Datalistupdateminimumcharacters ;
      private int Combo_logworkflowconvenioid_Gxcontroltype ;
      private int Combo_reembolsoflowloguser_Datalistupdateminimumcharacters ;
      private int Combo_reembolsoflowloguser_Gxcontroltype ;
      private int Combo_reembolsologid_Datalistupdateminimumcharacters ;
      private int Combo_reembolsologid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV29GXV1 ;
      private int Z749ReembolsoWorkFlowConvenioId ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_reembolsologid_Selectedvalue_get ;
      private string Combo_reembolsoflowloguser_Selectedvalue_get ;
      private string Combo_logworkflowconvenioid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLogWorkflowConvenioId_Internalname ;
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
      private string edtReembolsoFlowLogId_Internalname ;
      private string TempTags ;
      private string edtReembolsoFlowLogId_Jsonclick ;
      private string divTablesplittedlogworkflowconvenioid_Internalname ;
      private string lblTextblocklogworkflowconvenioid_Internalname ;
      private string lblTextblocklogworkflowconvenioid_Jsonclick ;
      private string Combo_logworkflowconvenioid_Caption ;
      private string Combo_logworkflowconvenioid_Cls ;
      private string Combo_logworkflowconvenioid_Datalistproc ;
      private string Combo_logworkflowconvenioid_Datalistprocparametersprefix ;
      private string Combo_logworkflowconvenioid_Internalname ;
      private string edtLogWorkflowConvenioId_Jsonclick ;
      private string edtReembolsoFlowLogDate_Internalname ;
      private string edtReembolsoFlowLogDate_Jsonclick ;
      private string divTablesplittedreembolsoflowloguser_Internalname ;
      private string lblTextblockreembolsoflowloguser_Internalname ;
      private string lblTextblockreembolsoflowloguser_Jsonclick ;
      private string Combo_reembolsoflowloguser_Caption ;
      private string Combo_reembolsoflowloguser_Cls ;
      private string Combo_reembolsoflowloguser_Datalistproc ;
      private string Combo_reembolsoflowloguser_Datalistprocparametersprefix ;
      private string Combo_reembolsoflowloguser_Internalname ;
      private string edtReembolsoFlowLogUser_Internalname ;
      private string edtReembolsoFlowLogUser_Jsonclick ;
      private string divTablesplittedreembolsologid_Internalname ;
      private string lblTextblockreembolsologid_Internalname ;
      private string lblTextblockreembolsologid_Jsonclick ;
      private string Combo_reembolsologid_Caption ;
      private string Combo_reembolsologid_Cls ;
      private string Combo_reembolsologid_Datalistproc ;
      private string Combo_reembolsologid_Datalistprocparametersprefix ;
      private string Combo_reembolsologid_Internalname ;
      private string edtReembolsoLogId_Internalname ;
      private string edtReembolsoLogId_Jsonclick ;
      private string edtReembolsoWorkFlowConvenioId_Internalname ;
      private string edtReembolsoWorkFlowConvenioId_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_logworkflowconvenioid_Internalname ;
      private string edtavCombologworkflowconvenioid_Internalname ;
      private string edtavCombologworkflowconvenioid_Jsonclick ;
      private string divSectionattribute_reembolsoflowloguser_Internalname ;
      private string edtavComboreembolsoflowloguser_Internalname ;
      private string edtavComboreembolsoflowloguser_Jsonclick ;
      private string divSectionattribute_reembolsologid_Internalname ;
      private string edtavComboreembolsologid_Internalname ;
      private string edtavComboreembolsologid_Jsonclick ;
      private string AV28Pgmname ;
      private string Combo_logworkflowconvenioid_Objectcall ;
      private string Combo_logworkflowconvenioid_Class ;
      private string Combo_logworkflowconvenioid_Icontype ;
      private string Combo_logworkflowconvenioid_Icon ;
      private string Combo_logworkflowconvenioid_Tooltip ;
      private string Combo_logworkflowconvenioid_Selectedvalue_set ;
      private string Combo_logworkflowconvenioid_Selectedtext_set ;
      private string Combo_logworkflowconvenioid_Selectedtext_get ;
      private string Combo_logworkflowconvenioid_Gamoauthtoken ;
      private string Combo_logworkflowconvenioid_Ddointernalname ;
      private string Combo_logworkflowconvenioid_Titlecontrolalign ;
      private string Combo_logworkflowconvenioid_Dropdownoptionstype ;
      private string Combo_logworkflowconvenioid_Titlecontrolidtoreplace ;
      private string Combo_logworkflowconvenioid_Datalisttype ;
      private string Combo_logworkflowconvenioid_Datalistfixedvalues ;
      private string Combo_logworkflowconvenioid_Remoteservicesparameters ;
      private string Combo_logworkflowconvenioid_Htmltemplate ;
      private string Combo_logworkflowconvenioid_Multiplevaluestype ;
      private string Combo_logworkflowconvenioid_Loadingdata ;
      private string Combo_logworkflowconvenioid_Noresultsfound ;
      private string Combo_logworkflowconvenioid_Emptyitemtext ;
      private string Combo_logworkflowconvenioid_Onlyselectedvalues ;
      private string Combo_logworkflowconvenioid_Selectalltext ;
      private string Combo_logworkflowconvenioid_Multiplevaluesseparator ;
      private string Combo_logworkflowconvenioid_Addnewoptiontext ;
      private string Combo_reembolsoflowloguser_Objectcall ;
      private string Combo_reembolsoflowloguser_Class ;
      private string Combo_reembolsoflowloguser_Icontype ;
      private string Combo_reembolsoflowloguser_Icon ;
      private string Combo_reembolsoflowloguser_Tooltip ;
      private string Combo_reembolsoflowloguser_Selectedvalue_set ;
      private string Combo_reembolsoflowloguser_Selectedtext_set ;
      private string Combo_reembolsoflowloguser_Selectedtext_get ;
      private string Combo_reembolsoflowloguser_Gamoauthtoken ;
      private string Combo_reembolsoflowloguser_Ddointernalname ;
      private string Combo_reembolsoflowloguser_Titlecontrolalign ;
      private string Combo_reembolsoflowloguser_Dropdownoptionstype ;
      private string Combo_reembolsoflowloguser_Titlecontrolidtoreplace ;
      private string Combo_reembolsoflowloguser_Datalisttype ;
      private string Combo_reembolsoflowloguser_Datalistfixedvalues ;
      private string Combo_reembolsoflowloguser_Remoteservicesparameters ;
      private string Combo_reembolsoflowloguser_Htmltemplate ;
      private string Combo_reembolsoflowloguser_Multiplevaluestype ;
      private string Combo_reembolsoflowloguser_Loadingdata ;
      private string Combo_reembolsoflowloguser_Noresultsfound ;
      private string Combo_reembolsoflowloguser_Emptyitemtext ;
      private string Combo_reembolsoflowloguser_Onlyselectedvalues ;
      private string Combo_reembolsoflowloguser_Selectalltext ;
      private string Combo_reembolsoflowloguser_Multiplevaluesseparator ;
      private string Combo_reembolsoflowloguser_Addnewoptiontext ;
      private string Combo_reembolsologid_Objectcall ;
      private string Combo_reembolsologid_Class ;
      private string Combo_reembolsologid_Icontype ;
      private string Combo_reembolsologid_Icon ;
      private string Combo_reembolsologid_Tooltip ;
      private string Combo_reembolsologid_Selectedvalue_set ;
      private string Combo_reembolsologid_Selectedtext_set ;
      private string Combo_reembolsologid_Selectedtext_get ;
      private string Combo_reembolsologid_Gamoauthtoken ;
      private string Combo_reembolsologid_Ddointernalname ;
      private string Combo_reembolsologid_Titlecontrolalign ;
      private string Combo_reembolsologid_Dropdownoptionstype ;
      private string Combo_reembolsologid_Titlecontrolidtoreplace ;
      private string Combo_reembolsologid_Datalisttype ;
      private string Combo_reembolsologid_Datalistfixedvalues ;
      private string Combo_reembolsologid_Remoteservicesparameters ;
      private string Combo_reembolsologid_Htmltemplate ;
      private string Combo_reembolsologid_Multiplevaluestype ;
      private string Combo_reembolsologid_Loadingdata ;
      private string Combo_reembolsologid_Noresultsfound ;
      private string Combo_reembolsologid_Emptyitemtext ;
      private string Combo_reembolsologid_Onlyselectedvalues ;
      private string Combo_reembolsologid_Selectalltext ;
      private string Combo_reembolsologid_Multiplevaluesseparator ;
      private string Combo_reembolsologid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode92 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z747ReembolsoFlowLogDate ;
      private DateTime Z761ReembolsoFlowLogDataFinal ;
      private DateTime A747ReembolsoFlowLogDate ;
      private DateTime A761ReembolsoFlowLogDataFinal ;
      private DateTime A755ReembolsoFlowLogDataSLA_F ;
      private DateTime Z755ReembolsoFlowLogDataSLA_F ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n750LogWorkflowConvenioId ;
      private bool n744ReembolsoFlowLogUser ;
      private bool n748ReembolsoLogId ;
      private bool n749ReembolsoWorkFlowConvenioId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n747ReembolsoFlowLogDate ;
      private bool n761ReembolsoFlowLogDataFinal ;
      private bool n754ReembolsoWorkflowConvenioSLA ;
      private bool n752LogWorkflowConvenioDesc ;
      private bool n745ReembolsoFlowLogUserNome ;
      private bool n763ReembolsoLogProtocolo ;
      private bool n760LogReembolsoStatusAtual_F ;
      private bool Combo_logworkflowconvenioid_Enabled ;
      private bool Combo_logworkflowconvenioid_Visible ;
      private bool Combo_logworkflowconvenioid_Allowmultipleselection ;
      private bool Combo_logworkflowconvenioid_Isgriditem ;
      private bool Combo_logworkflowconvenioid_Hasdescription ;
      private bool Combo_logworkflowconvenioid_Includeonlyselectedoption ;
      private bool Combo_logworkflowconvenioid_Includeselectalloption ;
      private bool Combo_logworkflowconvenioid_Emptyitem ;
      private bool Combo_logworkflowconvenioid_Includeaddnewoption ;
      private bool Combo_reembolsoflowloguser_Enabled ;
      private bool Combo_reembolsoflowloguser_Visible ;
      private bool Combo_reembolsoflowloguser_Allowmultipleselection ;
      private bool Combo_reembolsoflowloguser_Isgriditem ;
      private bool Combo_reembolsoflowloguser_Hasdescription ;
      private bool Combo_reembolsoflowloguser_Includeonlyselectedoption ;
      private bool Combo_reembolsoflowloguser_Includeselectalloption ;
      private bool Combo_reembolsoflowloguser_Emptyitem ;
      private bool Combo_reembolsoflowloguser_Includeaddnewoption ;
      private bool Combo_reembolsologid_Enabled ;
      private bool Combo_reembolsologid_Visible ;
      private bool Combo_reembolsologid_Allowmultipleselection ;
      private bool Combo_reembolsologid_Isgriditem ;
      private bool Combo_reembolsologid_Hasdescription ;
      private bool Combo_reembolsologid_Includeonlyselectedoption ;
      private bool Combo_reembolsologid_Includeselectalloption ;
      private bool Combo_reembolsologid_Emptyitem ;
      private bool Combo_reembolsologid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string A752LogWorkflowConvenioDesc ;
      private string A745ReembolsoFlowLogUserNome ;
      private string A763ReembolsoLogProtocolo ;
      private string A760LogReembolsoStatusAtual_F ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z752LogWorkflowConvenioDesc ;
      private string Z745ReembolsoFlowLogUserNome ;
      private string Z763ReembolsoLogProtocolo ;
      private string Z760LogReembolsoStatusAtual_F ;
      private string A764ReembolsoPaciente ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_logworkflowconvenioid ;
      private GXUserControl ucCombo_reembolsoflowloguser ;
      private GXUserControl ucCombo_reembolsologid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15LogWorkflowConvenioId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22ReembolsoFlowLogUser_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV25ReembolsoLogId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T002K4_A752LogWorkflowConvenioDesc ;
      private bool[] T002K4_n752LogWorkflowConvenioDesc ;
      private string[] T002K6_A763ReembolsoLogProtocolo ;
      private bool[] T002K6_n763ReembolsoLogProtocolo ;
      private int[] T002K6_A749ReembolsoWorkFlowConvenioId ;
      private bool[] T002K6_n749ReembolsoWorkFlowConvenioId ;
      private short[] T002K7_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] T002K7_n754ReembolsoWorkflowConvenioSLA ;
      private string[] T002K10_A760LogReembolsoStatusAtual_F ;
      private bool[] T002K10_n760LogReembolsoStatusAtual_F ;
      private int[] T002K13_A746ReembolsoFlowLogId ;
      private string[] T002K13_A752LogWorkflowConvenioDesc ;
      private bool[] T002K13_n752LogWorkflowConvenioDesc ;
      private DateTime[] T002K13_A747ReembolsoFlowLogDate ;
      private bool[] T002K13_n747ReembolsoFlowLogDate ;
      private string[] T002K13_A745ReembolsoFlowLogUserNome ;
      private bool[] T002K13_n745ReembolsoFlowLogUserNome ;
      private short[] T002K13_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] T002K13_n754ReembolsoWorkflowConvenioSLA ;
      private string[] T002K13_A763ReembolsoLogProtocolo ;
      private bool[] T002K13_n763ReembolsoLogProtocolo ;
      private DateTime[] T002K13_A761ReembolsoFlowLogDataFinal ;
      private bool[] T002K13_n761ReembolsoFlowLogDataFinal ;
      private int[] T002K13_A750LogWorkflowConvenioId ;
      private bool[] T002K13_n750LogWorkflowConvenioId ;
      private short[] T002K13_A744ReembolsoFlowLogUser ;
      private bool[] T002K13_n744ReembolsoFlowLogUser ;
      private int[] T002K13_A748ReembolsoLogId ;
      private bool[] T002K13_n748ReembolsoLogId ;
      private int[] T002K13_A749ReembolsoWorkFlowConvenioId ;
      private bool[] T002K13_n749ReembolsoWorkFlowConvenioId ;
      private string[] T002K13_A760LogReembolsoStatusAtual_F ;
      private bool[] T002K13_n760LogReembolsoStatusAtual_F ;
      private string[] T002K5_A745ReembolsoFlowLogUserNome ;
      private bool[] T002K5_n745ReembolsoFlowLogUserNome ;
      private string[] T002K14_A752LogWorkflowConvenioDesc ;
      private bool[] T002K14_n752LogWorkflowConvenioDesc ;
      private string[] T002K15_A745ReembolsoFlowLogUserNome ;
      private bool[] T002K15_n745ReembolsoFlowLogUserNome ;
      private string[] T002K16_A763ReembolsoLogProtocolo ;
      private bool[] T002K16_n763ReembolsoLogProtocolo ;
      private int[] T002K16_A749ReembolsoWorkFlowConvenioId ;
      private bool[] T002K16_n749ReembolsoWorkFlowConvenioId ;
      private short[] T002K17_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] T002K17_n754ReembolsoWorkflowConvenioSLA ;
      private string[] T002K20_A760LogReembolsoStatusAtual_F ;
      private bool[] T002K20_n760LogReembolsoStatusAtual_F ;
      private int[] T002K21_A746ReembolsoFlowLogId ;
      private int[] T002K3_A746ReembolsoFlowLogId ;
      private DateTime[] T002K3_A747ReembolsoFlowLogDate ;
      private bool[] T002K3_n747ReembolsoFlowLogDate ;
      private DateTime[] T002K3_A761ReembolsoFlowLogDataFinal ;
      private bool[] T002K3_n761ReembolsoFlowLogDataFinal ;
      private int[] T002K3_A750LogWorkflowConvenioId ;
      private bool[] T002K3_n750LogWorkflowConvenioId ;
      private short[] T002K3_A744ReembolsoFlowLogUser ;
      private bool[] T002K3_n744ReembolsoFlowLogUser ;
      private int[] T002K3_A748ReembolsoLogId ;
      private bool[] T002K3_n748ReembolsoLogId ;
      private int[] T002K22_A746ReembolsoFlowLogId ;
      private int[] T002K23_A746ReembolsoFlowLogId ;
      private int[] T002K2_A746ReembolsoFlowLogId ;
      private DateTime[] T002K2_A747ReembolsoFlowLogDate ;
      private bool[] T002K2_n747ReembolsoFlowLogDate ;
      private DateTime[] T002K2_A761ReembolsoFlowLogDataFinal ;
      private bool[] T002K2_n761ReembolsoFlowLogDataFinal ;
      private int[] T002K2_A750LogWorkflowConvenioId ;
      private bool[] T002K2_n750LogWorkflowConvenioId ;
      private short[] T002K2_A744ReembolsoFlowLogUser ;
      private bool[] T002K2_n744ReembolsoFlowLogUser ;
      private int[] T002K2_A748ReembolsoLogId ;
      private bool[] T002K2_n748ReembolsoLogId ;
      private int[] T002K25_A746ReembolsoFlowLogId ;
      private string[] T002K28_A752LogWorkflowConvenioDesc ;
      private bool[] T002K28_n752LogWorkflowConvenioDesc ;
      private string[] T002K29_A745ReembolsoFlowLogUserNome ;
      private bool[] T002K29_n745ReembolsoFlowLogUserNome ;
      private string[] T002K30_A763ReembolsoLogProtocolo ;
      private bool[] T002K30_n763ReembolsoLogProtocolo ;
      private int[] T002K30_A749ReembolsoWorkFlowConvenioId ;
      private bool[] T002K30_n749ReembolsoWorkFlowConvenioId ;
      private short[] T002K31_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] T002K31_n754ReembolsoWorkflowConvenioSLA ;
      private string[] T002K34_A760LogReembolsoStatusAtual_F ;
      private bool[] T002K34_n760LogReembolsoStatusAtual_F ;
      private int[] T002K35_A746ReembolsoFlowLogId ;
   }

   public class reembolsoflowlog__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002K2;
          prmT002K2 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmT002K3;
          prmT002K3 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmT002K4;
          prmT002K4 = new Object[] {
          new ParDef("LogWorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K5;
          prmT002K5 = new Object[] {
          new ParDef("ReembolsoFlowLogUser",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002K6;
          prmT002K6 = new Object[] {
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K7;
          prmT002K7 = new Object[] {
          new ParDef("ReembolsoWorkFlowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K10;
          prmT002K10 = new Object[] {
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K13;
          prmT002K13 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmT002K14;
          prmT002K14 = new Object[] {
          new ParDef("LogWorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K15;
          prmT002K15 = new Object[] {
          new ParDef("ReembolsoFlowLogUser",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002K16;
          prmT002K16 = new Object[] {
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K17;
          prmT002K17 = new Object[] {
          new ParDef("ReembolsoWorkFlowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K20;
          prmT002K20 = new Object[] {
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K21;
          prmT002K21 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmT002K22;
          prmT002K22 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmT002K23;
          prmT002K23 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmT002K24;
          prmT002K24 = new Object[] {
          new ParDef("ReembolsoFlowLogDate",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoFlowLogDataFinal",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("LogWorkflowConvenioId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoFlowLogUser",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K25;
          prmT002K25 = new Object[] {
          };
          Object[] prmT002K26;
          prmT002K26 = new Object[] {
          new ParDef("ReembolsoFlowLogDate",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoFlowLogDataFinal",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("LogWorkflowConvenioId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoFlowLogUser",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmT002K27;
          prmT002K27 = new Object[] {
          new ParDef("ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmT002K28;
          prmT002K28 = new Object[] {
          new ParDef("LogWorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K29;
          prmT002K29 = new Object[] {
          new ParDef("ReembolsoFlowLogUser",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002K30;
          prmT002K30 = new Object[] {
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K31;
          prmT002K31 = new Object[] {
          new ParDef("ReembolsoWorkFlowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K34;
          prmT002K34 = new Object[] {
          new ParDef("ReembolsoLogId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002K35;
          prmT002K35 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002K2", "SELECT ReembolsoFlowLogId, ReembolsoFlowLogDate, ReembolsoFlowLogDataFinal, LogWorkflowConvenioId, ReembolsoFlowLogUser, ReembolsoLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogId = :ReembolsoFlowLogId  FOR UPDATE OF ReembolsoFlowLog NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002K2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K3", "SELECT ReembolsoFlowLogId, ReembolsoFlowLogDate, ReembolsoFlowLogDataFinal, LogWorkflowConvenioId, ReembolsoFlowLogUser, ReembolsoLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogId = :ReembolsoFlowLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K4", "SELECT WorkflowConvenioDesc AS LogWorkflowConvenioDesc FROM WorkflowConvenio WHERE WorkflowConvenioId = :LogWorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K5", "SELECT SecUserName AS ReembolsoFlowLogUserNome FROM SecUser WHERE SecUserId = :ReembolsoFlowLogUser ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K6", "SELECT ReembolsoProtocolo AS ReembolsoLogProtocolo, WorkflowConvenioId AS ReembolsoWorkFlowConvenioId FROM Reembolso WHERE ReembolsoId = :ReembolsoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K7", "SELECT WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA FROM WorkflowConvenio WHERE WorkflowConvenioId = :ReembolsoWorkFlowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K10", "SELECT COALESCE( T1.LogReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F FROM (SELECT MIN(T2.ReembolsoEtapaStatus) AS LogReembolsoStatusAtual_F, COALESCE( T3.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T2.ReembolsoId FROM (ReembolsoEtapa T2 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T2.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T3 ON T3.ReembolsoId = T2.ReembolsoId) WHERE T2.ReembolsoEtapaCreatedAt = COALESCE( T3.ReembolsoEtapaUltimo_F, DATE '00010101') GROUP BY T3.ReembolsoEtapaUltimo_F, T2.ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K13", "SELECT TM1.ReembolsoFlowLogId, T2.WorkflowConvenioDesc AS LogWorkflowConvenioDesc, TM1.ReembolsoFlowLogDate, T3.SecUserName AS ReembolsoFlowLogUserNome, T5.WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA, T4.ReembolsoProtocolo AS ReembolsoLogProtocolo, TM1.ReembolsoFlowLogDataFinal, TM1.LogWorkflowConvenioId AS LogWorkflowConvenioId, TM1.ReembolsoFlowLogUser AS ReembolsoFlowLogUser, TM1.ReembolsoLogId AS ReembolsoLogId, T4.WorkflowConvenioId AS ReembolsoWorkFlowConvenioId, COALESCE( T6.LogReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F FROM (((((ReembolsoFlowLog TM1 LEFT JOIN WorkflowConvenio T2 ON T2.WorkflowConvenioId = TM1.LogWorkflowConvenioId) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.ReembolsoFlowLogUser) LEFT JOIN Reembolso T4 ON T4.ReembolsoId = TM1.ReembolsoLogId) LEFT JOIN WorkflowConvenio T5 ON T5.WorkflowConvenioId = T4.WorkflowConvenioId) LEFT JOIN LATERAL (SELECT MIN(T7.ReembolsoEtapaStatus) AS LogReembolsoStatusAtual_F, COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T7.ReembolsoId FROM (ReembolsoEtapa T7 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T7.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T8 ON T8.ReembolsoId = T7.ReembolsoId) WHERE (TM1.ReembolsoLogId = T7.ReembolsoId) AND (T7.ReembolsoEtapaCreatedAt = COALESCE( T8.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T8.ReembolsoEtapaUltimo_F, T7.ReembolsoId ) T6 ON T6.ReembolsoId = TM1.ReembolsoLogId) WHERE TM1.ReembolsoFlowLogId = :ReembolsoFlowLogId ORDER BY TM1.ReembolsoFlowLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K14", "SELECT WorkflowConvenioDesc AS LogWorkflowConvenioDesc FROM WorkflowConvenio WHERE WorkflowConvenioId = :LogWorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K15", "SELECT SecUserName AS ReembolsoFlowLogUserNome FROM SecUser WHERE SecUserId = :ReembolsoFlowLogUser ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K16", "SELECT ReembolsoProtocolo AS ReembolsoLogProtocolo, WorkflowConvenioId AS ReembolsoWorkFlowConvenioId FROM Reembolso WHERE ReembolsoId = :ReembolsoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K17", "SELECT WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA FROM WorkflowConvenio WHERE WorkflowConvenioId = :ReembolsoWorkFlowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K20", "SELECT COALESCE( T1.LogReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F FROM (SELECT MIN(T2.ReembolsoEtapaStatus) AS LogReembolsoStatusAtual_F, COALESCE( T3.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T2.ReembolsoId FROM (ReembolsoEtapa T2 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T2.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T3 ON T3.ReembolsoId = T2.ReembolsoId) WHERE T2.ReembolsoEtapaCreatedAt = COALESCE( T3.ReembolsoEtapaUltimo_F, DATE '00010101') GROUP BY T3.ReembolsoEtapaUltimo_F, T2.ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K21", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogId = :ReembolsoFlowLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K22", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE ( ReembolsoFlowLogId > :ReembolsoFlowLogId) ORDER BY ReembolsoFlowLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002K23", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE ( ReembolsoFlowLogId < :ReembolsoFlowLogId) ORDER BY ReembolsoFlowLogId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K23,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002K24", "SAVEPOINT gxupdate;INSERT INTO ReembolsoFlowLog(ReembolsoFlowLogDate, ReembolsoFlowLogDataFinal, LogWorkflowConvenioId, ReembolsoFlowLogUser, ReembolsoLogId) VALUES(:ReembolsoFlowLogDate, :ReembolsoFlowLogDataFinal, :LogWorkflowConvenioId, :ReembolsoFlowLogUser, :ReembolsoLogId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002K24)
             ,new CursorDef("T002K25", "SELECT currval('ReembolsoFlowLogId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K26", "SAVEPOINT gxupdate;UPDATE ReembolsoFlowLog SET ReembolsoFlowLogDate=:ReembolsoFlowLogDate, ReembolsoFlowLogDataFinal=:ReembolsoFlowLogDataFinal, LogWorkflowConvenioId=:LogWorkflowConvenioId, ReembolsoFlowLogUser=:ReembolsoFlowLogUser, ReembolsoLogId=:ReembolsoLogId  WHERE ReembolsoFlowLogId = :ReembolsoFlowLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002K26)
             ,new CursorDef("T002K27", "SAVEPOINT gxupdate;DELETE FROM ReembolsoFlowLog  WHERE ReembolsoFlowLogId = :ReembolsoFlowLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002K27)
             ,new CursorDef("T002K28", "SELECT WorkflowConvenioDesc AS LogWorkflowConvenioDesc FROM WorkflowConvenio WHERE WorkflowConvenioId = :LogWorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K29", "SELECT SecUserName AS ReembolsoFlowLogUserNome FROM SecUser WHERE SecUserId = :ReembolsoFlowLogUser ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K30", "SELECT ReembolsoProtocolo AS ReembolsoLogProtocolo, WorkflowConvenioId AS ReembolsoWorkFlowConvenioId FROM Reembolso WHERE ReembolsoId = :ReembolsoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K30,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K31", "SELECT WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA FROM WorkflowConvenio WHERE WorkflowConvenioId = :ReembolsoWorkFlowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K31,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K34", "SELECT COALESCE( T1.LogReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F FROM (SELECT MIN(T2.ReembolsoEtapaStatus) AS LogReembolsoStatusAtual_F, COALESCE( T3.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T2.ReembolsoId FROM (ReembolsoEtapa T2 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T2.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T3 ON T3.ReembolsoId = T2.ReembolsoId) WHERE T2.ReembolsoEtapaCreatedAt = COALESCE( T3.ReembolsoEtapaUltimo_F, DATE '00010101') GROUP BY T3.ReembolsoEtapaUltimo_F, T2.ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K34,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002K35", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog ORDER BY ReembolsoFlowLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K35,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
