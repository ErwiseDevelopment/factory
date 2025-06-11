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
   public class workflowconvenio : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workflowconvenio")), "workflowconvenio") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workflowconvenio")))) ;
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
                  AV7WorkflowConvenioId = (int)(Math.Round(NumberUtil.Val( GetPar( "WorkflowConvenioId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(AV7WorkflowConvenioId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vWORKFLOWCONVENIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7WorkflowConvenioId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Workflow Convenio", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWorkflowConvenioDesc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public workflowconvenio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workflowconvenio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_WorkflowConvenioId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7WorkflowConvenioId = aP1_WorkflowConvenioId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbWorkflowConvenioStatus = new GXCombobox();
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
         if ( cmbWorkflowConvenioStatus.ItemCount > 0 )
         {
            A737WorkflowConvenioStatus = StringUtil.StrToBool( cmbWorkflowConvenioStatus.getValidValue(StringUtil.BoolToStr( A737WorkflowConvenioStatus)));
            n737WorkflowConvenioStatus = false;
            AssignAttri("", false, "A737WorkflowConvenioStatus", A737WorkflowConvenioStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWorkflowConvenioStatus.CurrentValue = StringUtil.BoolToStr( A737WorkflowConvenioStatus);
            AssignProp("", false, cmbWorkflowConvenioStatus_Internalname, "Values", cmbWorkflowConvenioStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWorkflowConvenioDesc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWorkflowConvenioDesc_Internalname, "Passo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWorkflowConvenioDesc_Internalname, A736WorkflowConvenioDesc, StringUtil.RTrim( context.localUtil.Format( A736WorkflowConvenioDesc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkflowConvenioDesc_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWorkflowConvenioDesc_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkflowConvenio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWorkflowConvenioSLA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWorkflowConvenioSLA_Internalname, "SLA", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWorkflowConvenioSLA_Internalname, ((0==A753WorkflowConvenioSLA)&&IsIns( )||n753WorkflowConvenioSLA ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A753WorkflowConvenioSLA), 4, 0, ",", ""))), ((0==A753WorkflowConvenioSLA)&&IsIns( )||n753WorkflowConvenioSLA ? "" : StringUtil.LTrim( ((edtWorkflowConvenioSLA_Enabled!=0) ? context.localUtil.Format( (decimal)(A753WorkflowConvenioSLA), "ZZZ9") : context.localUtil.Format( (decimal)(A753WorkflowConvenioSLA), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkflowConvenioSLA_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWorkflowConvenioSLA_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkflowConvenio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWorkflowConvenioStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWorkflowConvenioStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWorkflowConvenioStatus, cmbWorkflowConvenioStatus_Internalname, StringUtil.BoolToStr( A737WorkflowConvenioStatus), 1, cmbWorkflowConvenioStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbWorkflowConvenioStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_WorkflowConvenio.htm");
         cmbWorkflowConvenioStatus.CurrentValue = StringUtil.BoolToStr( A737WorkflowConvenioStatus);
         AssignProp("", false, cmbWorkflowConvenioStatus_Internalname, "Values", (string)(cmbWorkflowConvenioStatus.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkflowConvenio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkflowConvenio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkflowConvenio.htm");
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
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWorkflowConvenioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ",", "")), StringUtil.LTrim( ((edtWorkflowConvenioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A742WorkflowConvenioId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A742WorkflowConvenioId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkflowConvenioId_Jsonclick, 0, "Attribute", "", "", "", "", edtWorkflowConvenioId_Visible, edtWorkflowConvenioId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_WorkflowConvenio.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWorkflowConvenioCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWorkflowConvenioCreatedAt_Internalname, context.localUtil.TToC( A743WorkflowConvenioCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A743WorkflowConvenioCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkflowConvenioCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", edtWorkflowConvenioCreatedAt_Visible, edtWorkflowConvenioCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkflowConvenio.htm");
         GxWebStd.gx_bitmap( context, edtWorkflowConvenioCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtWorkflowConvenioCreatedAt_Visible==0)||(edtWorkflowConvenioCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WorkflowConvenio.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         E112M2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z742WorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z742WorkflowConvenioId"), ",", "."), 18, MidpointRounding.ToEven));
               Z743WorkflowConvenioCreatedAt = context.localUtil.CToT( cgiGet( "Z743WorkflowConvenioCreatedAt"), 0);
               n743WorkflowConvenioCreatedAt = ((DateTime.MinValue==A743WorkflowConvenioCreatedAt) ? true : false);
               Z737WorkflowConvenioStatus = StringUtil.StrToBool( cgiGet( "Z737WorkflowConvenioStatus"));
               n737WorkflowConvenioStatus = ((false==A737WorkflowConvenioStatus) ? true : false);
               Z736WorkflowConvenioDesc = cgiGet( "Z736WorkflowConvenioDesc");
               n736WorkflowConvenioDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A736WorkflowConvenioDesc)) ? true : false);
               Z753WorkflowConvenioSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z753WorkflowConvenioSLA"), ",", "."), 18, MidpointRounding.ToEven));
               n753WorkflowConvenioSLA = ((0==A753WorkflowConvenioSLA) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7WorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vWORKFLOWCONVENIOID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
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
               A736WorkflowConvenioDesc = cgiGet( edtWorkflowConvenioDesc_Internalname);
               n736WorkflowConvenioDesc = false;
               AssignAttri("", false, "A736WorkflowConvenioDesc", A736WorkflowConvenioDesc);
               n736WorkflowConvenioDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A736WorkflowConvenioDesc)) ? true : false);
               n753WorkflowConvenioSLA = ((StringUtil.StrCmp(cgiGet( edtWorkflowConvenioSLA_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtWorkflowConvenioSLA_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWorkflowConvenioSLA_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WORKFLOWCONVENIOSLA");
                  AnyError = 1;
                  GX_FocusControl = edtWorkflowConvenioSLA_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A753WorkflowConvenioSLA = 0;
                  n753WorkflowConvenioSLA = false;
                  AssignAttri("", false, "A753WorkflowConvenioSLA", (n753WorkflowConvenioSLA ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A753WorkflowConvenioSLA), 4, 0, ".", ""))));
               }
               else
               {
                  A753WorkflowConvenioSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkflowConvenioSLA_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A753WorkflowConvenioSLA", (n753WorkflowConvenioSLA ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A753WorkflowConvenioSLA), 4, 0, ".", ""))));
               }
               cmbWorkflowConvenioStatus.CurrentValue = cgiGet( cmbWorkflowConvenioStatus_Internalname);
               A737WorkflowConvenioStatus = StringUtil.StrToBool( cgiGet( cmbWorkflowConvenioStatus_Internalname));
               n737WorkflowConvenioStatus = false;
               AssignAttri("", false, "A737WorkflowConvenioStatus", A737WorkflowConvenioStatus);
               n737WorkflowConvenioStatus = ((false==A737WorkflowConvenioStatus) ? true : false);
               A742WorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkflowConvenioId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n742WorkflowConvenioId = false;
               AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
               if ( context.localUtil.VCDateTime( cgiGet( edtWorkflowConvenioCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Workflow Convenio Created At"}), 1, "WORKFLOWCONVENIOCREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtWorkflowConvenioCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
                  n743WorkflowConvenioCreatedAt = false;
                  AssignAttri("", false, "A743WorkflowConvenioCreatedAt", context.localUtil.TToC( A743WorkflowConvenioCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A743WorkflowConvenioCreatedAt = context.localUtil.CToT( cgiGet( edtWorkflowConvenioCreatedAt_Internalname));
                  n743WorkflowConvenioCreatedAt = false;
                  AssignAttri("", false, "A743WorkflowConvenioCreatedAt", context.localUtil.TToC( A743WorkflowConvenioCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n743WorkflowConvenioCreatedAt = ((DateTime.MinValue==A743WorkflowConvenioCreatedAt) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"WorkflowConvenio");
               A742WorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkflowConvenioId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n742WorkflowConvenioId = false;
               AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
               forbiddenHiddens.Add("WorkflowConvenioId", context.localUtil.Format( (decimal)(A742WorkflowConvenioId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A742WorkflowConvenioId != Z742WorkflowConvenioId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("workflowconvenio:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               forbiddenHiddens2 = new GXProperties();
               if ( IsIns( )  )
               {
                  A737WorkflowConvenioStatus = StringUtil.StrToBool( cgiGet( cmbWorkflowConvenioStatus_Internalname));
                  n737WorkflowConvenioStatus = false;
                  AssignAttri("", false, "A737WorkflowConvenioStatus", A737WorkflowConvenioStatus);
                  forbiddenHiddens2.Add("WorkflowConvenioStatus", StringUtil.BoolToStr( A737WorkflowConvenioStatus));
               }
               hsh2 = cgiGet( "hsh2");
               if ( ( ! ( ( A742WorkflowConvenioId != Z742WorkflowConvenioId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens2.ToString(), hsh2, GXKey) )
               {
                  GXUtil.WriteLogError("workflowconvenio:[ CondSecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens2.ToJSonString());
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
                  A742WorkflowConvenioId = (int)(Math.Round(NumberUtil.Val( GetPar( "WorkflowConvenioId"), "."), 18, MidpointRounding.ToEven));
                  n742WorkflowConvenioId = false;
                  AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
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
                     sMode91 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode91;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound91 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2M0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "WORKFLOWCONVENIOID");
                        AnyError = 1;
                        GX_FocusControl = edtWorkflowConvenioId_Internalname;
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
                           E112M2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122M2 ();
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
            E122M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2M91( ) ;
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
            DisableAttributes2M91( ) ;
         }
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

      protected void CONFIRM_2M0( )
      {
         BeforeValidate2M91( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2M91( ) ;
            }
            else
            {
               CheckExtendedTable2M91( ) ;
               CloseExtendedTableCursors2M91( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2M0( )
      {
      }

      protected void E112M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtWorkflowConvenioId_Visible = 0;
         AssignProp("", false, edtWorkflowConvenioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWorkflowConvenioId_Visible), 5, 0), true);
         edtWorkflowConvenioCreatedAt_Visible = 0;
         AssignProp("", false, edtWorkflowConvenioCreatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWorkflowConvenioCreatedAt_Visible), 5, 0), true);
      }

      protected void E122M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("workflowconvenioww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2M91( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z743WorkflowConvenioCreatedAt = T002M3_A743WorkflowConvenioCreatedAt[0];
               Z737WorkflowConvenioStatus = T002M3_A737WorkflowConvenioStatus[0];
               Z736WorkflowConvenioDesc = T002M3_A736WorkflowConvenioDesc[0];
               Z753WorkflowConvenioSLA = T002M3_A753WorkflowConvenioSLA[0];
            }
            else
            {
               Z743WorkflowConvenioCreatedAt = A743WorkflowConvenioCreatedAt;
               Z737WorkflowConvenioStatus = A737WorkflowConvenioStatus;
               Z736WorkflowConvenioDesc = A736WorkflowConvenioDesc;
               Z753WorkflowConvenioSLA = A753WorkflowConvenioSLA;
            }
         }
         if ( GX_JID == -9 )
         {
            Z742WorkflowConvenioId = A742WorkflowConvenioId;
            Z743WorkflowConvenioCreatedAt = A743WorkflowConvenioCreatedAt;
            Z737WorkflowConvenioStatus = A737WorkflowConvenioStatus;
            Z736WorkflowConvenioDesc = A736WorkflowConvenioDesc;
            Z753WorkflowConvenioSLA = A753WorkflowConvenioSLA;
         }
      }

      protected void standaloneNotModal( )
      {
         edtWorkflowConvenioId_Enabled = 0;
         AssignProp("", false, edtWorkflowConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkflowConvenioId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtWorkflowConvenioId_Enabled = 0;
         AssignProp("", false, edtWorkflowConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkflowConvenioId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7WorkflowConvenioId) )
         {
            A742WorkflowConvenioId = AV7WorkflowConvenioId;
            n742WorkflowConvenioId = false;
            AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A737WorkflowConvenioStatus = true;
            n737WorkflowConvenioStatus = false;
            AssignAttri("", false, "A737WorkflowConvenioStatus", A737WorkflowConvenioStatus);
         }
         if ( IsIns( )  )
         {
            cmbWorkflowConvenioStatus.Enabled = 0;
            AssignProp("", false, cmbWorkflowConvenioStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWorkflowConvenioStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbWorkflowConvenioStatus.Enabled = 1;
            AssignProp("", false, cmbWorkflowConvenioStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWorkflowConvenioStatus.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            cmbWorkflowConvenioStatus.Enabled = 0;
            AssignProp("", false, cmbWorkflowConvenioStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWorkflowConvenioStatus.Enabled), 5, 0), true);
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
         if ( IsIns( )  )
         {
            A743WorkflowConvenioCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n743WorkflowConvenioCreatedAt = false;
            AssignAttri("", false, "A743WorkflowConvenioCreatedAt", context.localUtil.TToC( A743WorkflowConvenioCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A743WorkflowConvenioCreatedAt) && ( Gx_BScreen == 0 ) )
            {
               A743WorkflowConvenioCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
               n743WorkflowConvenioCreatedAt = false;
               AssignAttri("", false, "A743WorkflowConvenioCreatedAt", context.localUtil.TToC( A743WorkflowConvenioCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
         }
      }

      protected void Load2M91( )
      {
         /* Using cursor T002M4 */
         pr_default.execute(2, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound91 = 1;
            A743WorkflowConvenioCreatedAt = T002M4_A743WorkflowConvenioCreatedAt[0];
            n743WorkflowConvenioCreatedAt = T002M4_n743WorkflowConvenioCreatedAt[0];
            AssignAttri("", false, "A743WorkflowConvenioCreatedAt", context.localUtil.TToC( A743WorkflowConvenioCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A737WorkflowConvenioStatus = T002M4_A737WorkflowConvenioStatus[0];
            n737WorkflowConvenioStatus = T002M4_n737WorkflowConvenioStatus[0];
            AssignAttri("", false, "A737WorkflowConvenioStatus", A737WorkflowConvenioStatus);
            A736WorkflowConvenioDesc = T002M4_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = T002M4_n736WorkflowConvenioDesc[0];
            AssignAttri("", false, "A736WorkflowConvenioDesc", A736WorkflowConvenioDesc);
            A753WorkflowConvenioSLA = T002M4_A753WorkflowConvenioSLA[0];
            n753WorkflowConvenioSLA = T002M4_n753WorkflowConvenioSLA[0];
            AssignAttri("", false, "A753WorkflowConvenioSLA", ((0==A753WorkflowConvenioSLA)&&IsIns( )||n753WorkflowConvenioSLA ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A753WorkflowConvenioSLA), 4, 0, ".", ""))));
            ZM2M91( -9) ;
         }
         pr_default.close(2);
         OnLoadActions2M91( ) ;
      }

      protected void OnLoadActions2M91( )
      {
      }

      protected void CheckExtendedTable2M91( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A736WorkflowConvenioDesc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Passo", "", "", "", "", "", "", "", ""), 1, "WORKFLOWCONVENIODESC");
            AnyError = 1;
            GX_FocusControl = edtWorkflowConvenioDesc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( A753WorkflowConvenioSLA < 0 )
         {
            GX_msglist.addItem("SLA não pode ser menor que 0", 1, "WORKFLOWCONVENIOSLA");
            AnyError = 1;
            GX_FocusControl = edtWorkflowConvenioSLA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2M91( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2M91( )
      {
         /* Using cursor T002M5 */
         pr_default.execute(3, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound91 = 1;
         }
         else
         {
            RcdFound91 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002M3 */
         pr_default.execute(1, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2M91( 9) ;
            RcdFound91 = 1;
            A742WorkflowConvenioId = T002M3_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = T002M3_n742WorkflowConvenioId[0];
            AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
            A743WorkflowConvenioCreatedAt = T002M3_A743WorkflowConvenioCreatedAt[0];
            n743WorkflowConvenioCreatedAt = T002M3_n743WorkflowConvenioCreatedAt[0];
            AssignAttri("", false, "A743WorkflowConvenioCreatedAt", context.localUtil.TToC( A743WorkflowConvenioCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A737WorkflowConvenioStatus = T002M3_A737WorkflowConvenioStatus[0];
            n737WorkflowConvenioStatus = T002M3_n737WorkflowConvenioStatus[0];
            AssignAttri("", false, "A737WorkflowConvenioStatus", A737WorkflowConvenioStatus);
            A736WorkflowConvenioDesc = T002M3_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = T002M3_n736WorkflowConvenioDesc[0];
            AssignAttri("", false, "A736WorkflowConvenioDesc", A736WorkflowConvenioDesc);
            A753WorkflowConvenioSLA = T002M3_A753WorkflowConvenioSLA[0];
            n753WorkflowConvenioSLA = T002M3_n753WorkflowConvenioSLA[0];
            AssignAttri("", false, "A753WorkflowConvenioSLA", ((0==A753WorkflowConvenioSLA)&&IsIns( )||n753WorkflowConvenioSLA ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A753WorkflowConvenioSLA), 4, 0, ".", ""))));
            Z742WorkflowConvenioId = A742WorkflowConvenioId;
            sMode91 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2M91( ) ;
            if ( AnyError == 1 )
            {
               RcdFound91 = 0;
               InitializeNonKey2M91( ) ;
            }
            Gx_mode = sMode91;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound91 = 0;
            InitializeNonKey2M91( ) ;
            sMode91 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode91;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2M91( ) ;
         if ( RcdFound91 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound91 = 0;
         /* Using cursor T002M6 */
         pr_default.execute(4, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T002M6_A742WorkflowConvenioId[0] < A742WorkflowConvenioId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T002M6_A742WorkflowConvenioId[0] > A742WorkflowConvenioId ) ) )
            {
               A742WorkflowConvenioId = T002M6_A742WorkflowConvenioId[0];
               n742WorkflowConvenioId = T002M6_n742WorkflowConvenioId[0];
               AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
               RcdFound91 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound91 = 0;
         /* Using cursor T002M7 */
         pr_default.execute(5, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T002M7_A742WorkflowConvenioId[0] > A742WorkflowConvenioId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T002M7_A742WorkflowConvenioId[0] < A742WorkflowConvenioId ) ) )
            {
               A742WorkflowConvenioId = T002M7_A742WorkflowConvenioId[0];
               n742WorkflowConvenioId = T002M7_n742WorkflowConvenioId[0];
               AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
               RcdFound91 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2M91( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWorkflowConvenioDesc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2M91( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound91 == 1 )
            {
               if ( A742WorkflowConvenioId != Z742WorkflowConvenioId )
               {
                  A742WorkflowConvenioId = Z742WorkflowConvenioId;
                  n742WorkflowConvenioId = false;
                  AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WORKFLOWCONVENIOID");
                  AnyError = 1;
                  GX_FocusControl = edtWorkflowConvenioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWorkflowConvenioDesc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2M91( ) ;
                  GX_FocusControl = edtWorkflowConvenioDesc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A742WorkflowConvenioId != Z742WorkflowConvenioId )
               {
                  /* Insert record */
                  GX_FocusControl = edtWorkflowConvenioDesc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2M91( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WORKFLOWCONVENIOID");
                     AnyError = 1;
                     GX_FocusControl = edtWorkflowConvenioId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtWorkflowConvenioDesc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2M91( ) ;
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
         if ( A742WorkflowConvenioId != Z742WorkflowConvenioId )
         {
            A742WorkflowConvenioId = Z742WorkflowConvenioId;
            n742WorkflowConvenioId = false;
            AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WORKFLOWCONVENIOID");
            AnyError = 1;
            GX_FocusControl = edtWorkflowConvenioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWorkflowConvenioDesc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2M91( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002M2 */
            pr_default.execute(0, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WorkflowConvenio"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z743WorkflowConvenioCreatedAt != T002M2_A743WorkflowConvenioCreatedAt[0] ) || ( Z737WorkflowConvenioStatus != T002M2_A737WorkflowConvenioStatus[0] ) || ( StringUtil.StrCmp(Z736WorkflowConvenioDesc, T002M2_A736WorkflowConvenioDesc[0]) != 0 ) || ( Z753WorkflowConvenioSLA != T002M2_A753WorkflowConvenioSLA[0] ) )
            {
               if ( Z743WorkflowConvenioCreatedAt != T002M2_A743WorkflowConvenioCreatedAt[0] )
               {
                  GXUtil.WriteLog("workflowconvenio:[seudo value changed for attri]"+"WorkflowConvenioCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z743WorkflowConvenioCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002M2_A743WorkflowConvenioCreatedAt[0]);
               }
               if ( Z737WorkflowConvenioStatus != T002M2_A737WorkflowConvenioStatus[0] )
               {
                  GXUtil.WriteLog("workflowconvenio:[seudo value changed for attri]"+"WorkflowConvenioStatus");
                  GXUtil.WriteLogRaw("Old: ",Z737WorkflowConvenioStatus);
                  GXUtil.WriteLogRaw("Current: ",T002M2_A737WorkflowConvenioStatus[0]);
               }
               if ( StringUtil.StrCmp(Z736WorkflowConvenioDesc, T002M2_A736WorkflowConvenioDesc[0]) != 0 )
               {
                  GXUtil.WriteLog("workflowconvenio:[seudo value changed for attri]"+"WorkflowConvenioDesc");
                  GXUtil.WriteLogRaw("Old: ",Z736WorkflowConvenioDesc);
                  GXUtil.WriteLogRaw("Current: ",T002M2_A736WorkflowConvenioDesc[0]);
               }
               if ( Z753WorkflowConvenioSLA != T002M2_A753WorkflowConvenioSLA[0] )
               {
                  GXUtil.WriteLog("workflowconvenio:[seudo value changed for attri]"+"WorkflowConvenioSLA");
                  GXUtil.WriteLogRaw("Old: ",Z753WorkflowConvenioSLA);
                  GXUtil.WriteLogRaw("Current: ",T002M2_A753WorkflowConvenioSLA[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WorkflowConvenio"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2M91( )
      {
         BeforeValidate2M91( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2M91( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2M91( 0) ;
            CheckOptimisticConcurrency2M91( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2M91( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2M91( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002M8 */
                     pr_default.execute(6, new Object[] {n743WorkflowConvenioCreatedAt, A743WorkflowConvenioCreatedAt, n737WorkflowConvenioStatus, A737WorkflowConvenioStatus, n736WorkflowConvenioDesc, A736WorkflowConvenioDesc, n753WorkflowConvenioSLA, A753WorkflowConvenioSLA});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002M9 */
                     pr_default.execute(7);
                     A742WorkflowConvenioId = T002M9_A742WorkflowConvenioId[0];
                     n742WorkflowConvenioId = T002M9_n742WorkflowConvenioId[0];
                     AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WorkflowConvenio");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2M0( ) ;
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
               Load2M91( ) ;
            }
            EndLevel2M91( ) ;
         }
         CloseExtendedTableCursors2M91( ) ;
      }

      protected void Update2M91( )
      {
         BeforeValidate2M91( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2M91( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2M91( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2M91( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2M91( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002M10 */
                     pr_default.execute(8, new Object[] {n743WorkflowConvenioCreatedAt, A743WorkflowConvenioCreatedAt, n737WorkflowConvenioStatus, A737WorkflowConvenioStatus, n736WorkflowConvenioDesc, A736WorkflowConvenioDesc, n753WorkflowConvenioSLA, A753WorkflowConvenioSLA, n742WorkflowConvenioId, A742WorkflowConvenioId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WorkflowConvenio");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WorkflowConvenio"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2M91( ) ;
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
            EndLevel2M91( ) ;
         }
         CloseExtendedTableCursors2M91( ) ;
      }

      protected void DeferredUpdate2M91( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2M91( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2M91( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2M91( ) ;
            AfterConfirm2M91( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2M91( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002M11 */
                  pr_default.execute(9, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WorkflowConvenio");
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
         sMode91 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2M91( ) ;
         Gx_mode = sMode91;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2M91( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T002M12 */
            pr_default.execute(10, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoFlowLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T002M13 */
            pr_default.execute(11, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel2M91( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2M91( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("workflowconvenio",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("workflowconvenio",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2M91( )
      {
         /* Scan By routine */
         /* Using cursor T002M14 */
         pr_default.execute(12);
         RcdFound91 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound91 = 1;
            A742WorkflowConvenioId = T002M14_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = T002M14_n742WorkflowConvenioId[0];
            AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2M91( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound91 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound91 = 1;
            A742WorkflowConvenioId = T002M14_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = T002M14_n742WorkflowConvenioId[0];
            AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
         }
      }

      protected void ScanEnd2M91( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm2M91( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2M91( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2M91( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2M91( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2M91( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2M91( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2M91( )
      {
         edtWorkflowConvenioDesc_Enabled = 0;
         AssignProp("", false, edtWorkflowConvenioDesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkflowConvenioDesc_Enabled), 5, 0), true);
         edtWorkflowConvenioSLA_Enabled = 0;
         AssignProp("", false, edtWorkflowConvenioSLA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkflowConvenioSLA_Enabled), 5, 0), true);
         cmbWorkflowConvenioStatus.Enabled = 0;
         AssignProp("", false, cmbWorkflowConvenioStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWorkflowConvenioStatus.Enabled), 5, 0), true);
         edtWorkflowConvenioId_Enabled = 0;
         AssignProp("", false, edtWorkflowConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkflowConvenioId_Enabled), 5, 0), true);
         edtWorkflowConvenioCreatedAt_Enabled = 0;
         AssignProp("", false, edtWorkflowConvenioCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkflowConvenioCreatedAt_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2M91( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2M0( )
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
         GXEncryptionTmp = "workflowconvenio"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7WorkflowConvenioId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("workflowconvenio") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"WorkflowConvenio");
         forbiddenHiddens.Add("WorkflowConvenioId", context.localUtil.Format( (decimal)(A742WorkflowConvenioId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("workflowconvenio:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         forbiddenHiddens2 = new GXProperties();
         if ( IsIns( )  )
         {
            forbiddenHiddens2.Add("WorkflowConvenioStatus", StringUtil.BoolToStr( A737WorkflowConvenioStatus));
         }
         GxWebStd.gx_hidden_field( context, "hsh2", GetEncryptedHash( forbiddenHiddens2.ToString(), GXKey));
         GXUtil.WriteLogInfo("workflowconvenio:[ SendCondSecurityCheck value for]"+forbiddenHiddens2.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z742WorkflowConvenioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z742WorkflowConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z743WorkflowConvenioCreatedAt", context.localUtil.TToC( Z743WorkflowConvenioCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z737WorkflowConvenioStatus", Z737WorkflowConvenioStatus);
         GxWebStd.gx_hidden_field( context, "Z736WorkflowConvenioDesc", Z736WorkflowConvenioDesc);
         GxWebStd.gx_hidden_field( context, "Z753WorkflowConvenioSLA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z753WorkflowConvenioSLA), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vWORKFLOWCONVENIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WorkflowConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWORKFLOWCONVENIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7WorkflowConvenioId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
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
         GXEncryptionTmp = "workflowconvenio"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7WorkflowConvenioId,9,0));
         return formatLink("workflowconvenio") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WorkflowConvenio" ;
      }

      public override string GetPgmdesc( )
      {
         return "Workflow Convenio" ;
      }

      protected void InitializeNonKey2M91( )
      {
         A743WorkflowConvenioCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n743WorkflowConvenioCreatedAt = false;
         AssignAttri("", false, "A743WorkflowConvenioCreatedAt", context.localUtil.TToC( A743WorkflowConvenioCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A737WorkflowConvenioStatus = false;
         n737WorkflowConvenioStatus = false;
         AssignAttri("", false, "A737WorkflowConvenioStatus", A737WorkflowConvenioStatus);
         n737WorkflowConvenioStatus = ((false==A737WorkflowConvenioStatus) ? true : false);
         A736WorkflowConvenioDesc = "";
         n736WorkflowConvenioDesc = false;
         AssignAttri("", false, "A736WorkflowConvenioDesc", A736WorkflowConvenioDesc);
         n736WorkflowConvenioDesc = (String.IsNullOrEmpty(StringUtil.RTrim( A736WorkflowConvenioDesc)) ? true : false);
         A753WorkflowConvenioSLA = 0;
         n753WorkflowConvenioSLA = false;
         AssignAttri("", false, "A753WorkflowConvenioSLA", ((0==A753WorkflowConvenioSLA)&&IsIns( )||n753WorkflowConvenioSLA ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A753WorkflowConvenioSLA), 4, 0, ".", ""))));
         n753WorkflowConvenioSLA = ((0==A753WorkflowConvenioSLA) ? true : false);
         Z743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         Z737WorkflowConvenioStatus = false;
         Z736WorkflowConvenioDesc = "";
         Z753WorkflowConvenioSLA = 0;
      }

      protected void InitAll2M91( )
      {
         A742WorkflowConvenioId = 0;
         n742WorkflowConvenioId = false;
         AssignAttri("", false, "A742WorkflowConvenioId", StringUtil.LTrimStr( (decimal)(A742WorkflowConvenioId), 9, 0));
         InitializeNonKey2M91( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A737WorkflowConvenioStatus = i737WorkflowConvenioStatus;
         n737WorkflowConvenioStatus = false;
         AssignAttri("", false, "A737WorkflowConvenioStatus", A737WorkflowConvenioStatus);
         A743WorkflowConvenioCreatedAt = i743WorkflowConvenioCreatedAt;
         n743WorkflowConvenioCreatedAt = false;
         AssignAttri("", false, "A743WorkflowConvenioCreatedAt", context.localUtil.TToC( A743WorkflowConvenioCreatedAt, 8, 5, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101921176", true, true);
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
         context.AddJavascriptSource("workflowconvenio.js", "?20256101921177", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtWorkflowConvenioDesc_Internalname = "WORKFLOWCONVENIODESC";
         edtWorkflowConvenioSLA_Internalname = "WORKFLOWCONVENIOSLA";
         cmbWorkflowConvenioStatus_Internalname = "WORKFLOWCONVENIOSTATUS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtWorkflowConvenioId_Internalname = "WORKFLOWCONVENIOID";
         edtWorkflowConvenioCreatedAt_Internalname = "WORKFLOWCONVENIOCREATEDAT";
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
         Form.Caption = "Workflow Convenio";
         edtWorkflowConvenioCreatedAt_Jsonclick = "";
         edtWorkflowConvenioCreatedAt_Enabled = 1;
         edtWorkflowConvenioCreatedAt_Visible = 1;
         edtWorkflowConvenioId_Jsonclick = "";
         edtWorkflowConvenioId_Enabled = 0;
         edtWorkflowConvenioId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbWorkflowConvenioStatus_Jsonclick = "";
         cmbWorkflowConvenioStatus.Enabled = 1;
         edtWorkflowConvenioSLA_Jsonclick = "";
         edtWorkflowConvenioSLA_Enabled = 1;
         edtWorkflowConvenioDesc_Jsonclick = "";
         edtWorkflowConvenioDesc_Enabled = 1;
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
         cmbWorkflowConvenioStatus.Name = "WORKFLOWCONVENIOSTATUS";
         cmbWorkflowConvenioStatus.WebTags = "";
         cmbWorkflowConvenioStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbWorkflowConvenioStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbWorkflowConvenioStatus.ItemCount > 0 )
         {
            A737WorkflowConvenioStatus = StringUtil.StrToBool( cmbWorkflowConvenioStatus.getValidValue(StringUtil.BoolToStr( A737WorkflowConvenioStatus)));
            n737WorkflowConvenioStatus = false;
            AssignAttri("", false, "A737WorkflowConvenioStatus", A737WorkflowConvenioStatus);
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7WorkflowConvenioId","fld":"vWORKFLOWCONVENIOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7WorkflowConvenioId","fld":"vWORKFLOWCONVENIOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A742WorkflowConvenioId","fld":"WORKFLOWCONVENIOID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122M2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_WORKFLOWCONVENIODESC","""{"handler":"Valid_Workflowconveniodesc","iparms":[]}""");
         setEventMetadata("VALID_WORKFLOWCONVENIOSLA","""{"handler":"Valid_Workflowconveniosla","iparms":[]}""");
         setEventMetadata("VALID_WORKFLOWCONVENIOID","""{"handler":"Valid_Workflowconvenioid","iparms":[]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         Z736WorkflowConvenioDesc = "";
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
         A736WorkflowConvenioDesc = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         forbiddenHiddens2 = new GXProperties();
         hsh2 = "";
         sMode91 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T002M4_A742WorkflowConvenioId = new int[1] ;
         T002M4_n742WorkflowConvenioId = new bool[] {false} ;
         T002M4_A743WorkflowConvenioCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002M4_n743WorkflowConvenioCreatedAt = new bool[] {false} ;
         T002M4_A737WorkflowConvenioStatus = new bool[] {false} ;
         T002M4_n737WorkflowConvenioStatus = new bool[] {false} ;
         T002M4_A736WorkflowConvenioDesc = new string[] {""} ;
         T002M4_n736WorkflowConvenioDesc = new bool[] {false} ;
         T002M4_A753WorkflowConvenioSLA = new short[1] ;
         T002M4_n753WorkflowConvenioSLA = new bool[] {false} ;
         T002M5_A742WorkflowConvenioId = new int[1] ;
         T002M5_n742WorkflowConvenioId = new bool[] {false} ;
         T002M3_A742WorkflowConvenioId = new int[1] ;
         T002M3_n742WorkflowConvenioId = new bool[] {false} ;
         T002M3_A743WorkflowConvenioCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002M3_n743WorkflowConvenioCreatedAt = new bool[] {false} ;
         T002M3_A737WorkflowConvenioStatus = new bool[] {false} ;
         T002M3_n737WorkflowConvenioStatus = new bool[] {false} ;
         T002M3_A736WorkflowConvenioDesc = new string[] {""} ;
         T002M3_n736WorkflowConvenioDesc = new bool[] {false} ;
         T002M3_A753WorkflowConvenioSLA = new short[1] ;
         T002M3_n753WorkflowConvenioSLA = new bool[] {false} ;
         T002M6_A742WorkflowConvenioId = new int[1] ;
         T002M6_n742WorkflowConvenioId = new bool[] {false} ;
         T002M7_A742WorkflowConvenioId = new int[1] ;
         T002M7_n742WorkflowConvenioId = new bool[] {false} ;
         T002M2_A742WorkflowConvenioId = new int[1] ;
         T002M2_n742WorkflowConvenioId = new bool[] {false} ;
         T002M2_A743WorkflowConvenioCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002M2_n743WorkflowConvenioCreatedAt = new bool[] {false} ;
         T002M2_A737WorkflowConvenioStatus = new bool[] {false} ;
         T002M2_n737WorkflowConvenioStatus = new bool[] {false} ;
         T002M2_A736WorkflowConvenioDesc = new string[] {""} ;
         T002M2_n736WorkflowConvenioDesc = new bool[] {false} ;
         T002M2_A753WorkflowConvenioSLA = new short[1] ;
         T002M2_n753WorkflowConvenioSLA = new bool[] {false} ;
         T002M9_A742WorkflowConvenioId = new int[1] ;
         T002M9_n742WorkflowConvenioId = new bool[] {false} ;
         T002M12_A746ReembolsoFlowLogId = new int[1] ;
         T002M13_A518ReembolsoId = new int[1] ;
         T002M14_A742WorkflowConvenioId = new int[1] ;
         T002M14_n742WorkflowConvenioId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workflowconvenio__default(),
            new Object[][] {
                new Object[] {
               T002M2_A742WorkflowConvenioId, T002M2_A743WorkflowConvenioCreatedAt, T002M2_n743WorkflowConvenioCreatedAt, T002M2_A737WorkflowConvenioStatus, T002M2_n737WorkflowConvenioStatus, T002M2_A736WorkflowConvenioDesc, T002M2_n736WorkflowConvenioDesc, T002M2_A753WorkflowConvenioSLA, T002M2_n753WorkflowConvenioSLA
               }
               , new Object[] {
               T002M3_A742WorkflowConvenioId, T002M3_A743WorkflowConvenioCreatedAt, T002M3_n743WorkflowConvenioCreatedAt, T002M3_A737WorkflowConvenioStatus, T002M3_n737WorkflowConvenioStatus, T002M3_A736WorkflowConvenioDesc, T002M3_n736WorkflowConvenioDesc, T002M3_A753WorkflowConvenioSLA, T002M3_n753WorkflowConvenioSLA
               }
               , new Object[] {
               T002M4_A742WorkflowConvenioId, T002M4_A743WorkflowConvenioCreatedAt, T002M4_n743WorkflowConvenioCreatedAt, T002M4_A737WorkflowConvenioStatus, T002M4_n737WorkflowConvenioStatus, T002M4_A736WorkflowConvenioDesc, T002M4_n736WorkflowConvenioDesc, T002M4_A753WorkflowConvenioSLA, T002M4_n753WorkflowConvenioSLA
               }
               , new Object[] {
               T002M5_A742WorkflowConvenioId
               }
               , new Object[] {
               T002M6_A742WorkflowConvenioId
               }
               , new Object[] {
               T002M7_A742WorkflowConvenioId
               }
               , new Object[] {
               }
               , new Object[] {
               T002M9_A742WorkflowConvenioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002M12_A746ReembolsoFlowLogId
               }
               , new Object[] {
               T002M13_A518ReembolsoId
               }
               , new Object[] {
               T002M14_A742WorkflowConvenioId
               }
            }
         );
         Z743WorkflowConvenioCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n743WorkflowConvenioCreatedAt = false;
         A743WorkflowConvenioCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n743WorkflowConvenioCreatedAt = false;
         i743WorkflowConvenioCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n743WorkflowConvenioCreatedAt = false;
      }

      private short Z753WorkflowConvenioSLA ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A753WorkflowConvenioSLA ;
      private short Gx_BScreen ;
      private short RcdFound91 ;
      private short gxajaxcallmode ;
      private int wcpOAV7WorkflowConvenioId ;
      private int Z742WorkflowConvenioId ;
      private int AV7WorkflowConvenioId ;
      private int trnEnded ;
      private int edtWorkflowConvenioDesc_Enabled ;
      private int edtWorkflowConvenioSLA_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A742WorkflowConvenioId ;
      private int edtWorkflowConvenioId_Enabled ;
      private int edtWorkflowConvenioId_Visible ;
      private int edtWorkflowConvenioCreatedAt_Visible ;
      private int edtWorkflowConvenioCreatedAt_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWorkflowConvenioDesc_Internalname ;
      private string cmbWorkflowConvenioStatus_Internalname ;
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
      private string edtWorkflowConvenioDesc_Jsonclick ;
      private string edtWorkflowConvenioSLA_Internalname ;
      private string edtWorkflowConvenioSLA_Jsonclick ;
      private string cmbWorkflowConvenioStatus_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtWorkflowConvenioId_Internalname ;
      private string edtWorkflowConvenioId_Jsonclick ;
      private string edtWorkflowConvenioCreatedAt_Internalname ;
      private string edtWorkflowConvenioCreatedAt_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string hsh2 ;
      private string sMode91 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z743WorkflowConvenioCreatedAt ;
      private DateTime A743WorkflowConvenioCreatedAt ;
      private DateTime i743WorkflowConvenioCreatedAt ;
      private bool Z737WorkflowConvenioStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A737WorkflowConvenioStatus ;
      private bool n737WorkflowConvenioStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n753WorkflowConvenioSLA ;
      private bool n743WorkflowConvenioCreatedAt ;
      private bool n736WorkflowConvenioDesc ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n742WorkflowConvenioId ;
      private bool returnInSub ;
      private bool i737WorkflowConvenioStatus ;
      private string Z736WorkflowConvenioDesc ;
      private string A736WorkflowConvenioDesc ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXProperties forbiddenHiddens2 ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWorkflowConvenioStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] T002M4_A742WorkflowConvenioId ;
      private bool[] T002M4_n742WorkflowConvenioId ;
      private DateTime[] T002M4_A743WorkflowConvenioCreatedAt ;
      private bool[] T002M4_n743WorkflowConvenioCreatedAt ;
      private bool[] T002M4_A737WorkflowConvenioStatus ;
      private bool[] T002M4_n737WorkflowConvenioStatus ;
      private string[] T002M4_A736WorkflowConvenioDesc ;
      private bool[] T002M4_n736WorkflowConvenioDesc ;
      private short[] T002M4_A753WorkflowConvenioSLA ;
      private bool[] T002M4_n753WorkflowConvenioSLA ;
      private int[] T002M5_A742WorkflowConvenioId ;
      private bool[] T002M5_n742WorkflowConvenioId ;
      private int[] T002M3_A742WorkflowConvenioId ;
      private bool[] T002M3_n742WorkflowConvenioId ;
      private DateTime[] T002M3_A743WorkflowConvenioCreatedAt ;
      private bool[] T002M3_n743WorkflowConvenioCreatedAt ;
      private bool[] T002M3_A737WorkflowConvenioStatus ;
      private bool[] T002M3_n737WorkflowConvenioStatus ;
      private string[] T002M3_A736WorkflowConvenioDesc ;
      private bool[] T002M3_n736WorkflowConvenioDesc ;
      private short[] T002M3_A753WorkflowConvenioSLA ;
      private bool[] T002M3_n753WorkflowConvenioSLA ;
      private int[] T002M6_A742WorkflowConvenioId ;
      private bool[] T002M6_n742WorkflowConvenioId ;
      private int[] T002M7_A742WorkflowConvenioId ;
      private bool[] T002M7_n742WorkflowConvenioId ;
      private int[] T002M2_A742WorkflowConvenioId ;
      private bool[] T002M2_n742WorkflowConvenioId ;
      private DateTime[] T002M2_A743WorkflowConvenioCreatedAt ;
      private bool[] T002M2_n743WorkflowConvenioCreatedAt ;
      private bool[] T002M2_A737WorkflowConvenioStatus ;
      private bool[] T002M2_n737WorkflowConvenioStatus ;
      private string[] T002M2_A736WorkflowConvenioDesc ;
      private bool[] T002M2_n736WorkflowConvenioDesc ;
      private short[] T002M2_A753WorkflowConvenioSLA ;
      private bool[] T002M2_n753WorkflowConvenioSLA ;
      private int[] T002M9_A742WorkflowConvenioId ;
      private bool[] T002M9_n742WorkflowConvenioId ;
      private int[] T002M12_A746ReembolsoFlowLogId ;
      private int[] T002M13_A518ReembolsoId ;
      private int[] T002M14_A742WorkflowConvenioId ;
      private bool[] T002M14_n742WorkflowConvenioId ;
   }

   public class workflowconvenio__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002M2;
          prmT002M2 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002M3;
          prmT002M3 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002M4;
          prmT002M4 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002M5;
          prmT002M5 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002M6;
          prmT002M6 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002M7;
          prmT002M7 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002M8;
          prmT002M8 = new Object[] {
          new ParDef("WorkflowConvenioCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("WorkflowConvenioStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("WorkflowConvenioDesc",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("WorkflowConvenioSLA",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002M9;
          prmT002M9 = new Object[] {
          };
          Object[] prmT002M10;
          prmT002M10 = new Object[] {
          new ParDef("WorkflowConvenioCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("WorkflowConvenioStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("WorkflowConvenioDesc",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("WorkflowConvenioSLA",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002M11;
          prmT002M11 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002M12;
          prmT002M12 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002M13;
          prmT002M13 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002M14;
          prmT002M14 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002M2", "SELECT WorkflowConvenioId, WorkflowConvenioCreatedAt, WorkflowConvenioStatus, WorkflowConvenioDesc, WorkflowConvenioSLA FROM WorkflowConvenio WHERE WorkflowConvenioId = :WorkflowConvenioId  FOR UPDATE OF WorkflowConvenio NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002M2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002M3", "SELECT WorkflowConvenioId, WorkflowConvenioCreatedAt, WorkflowConvenioStatus, WorkflowConvenioDesc, WorkflowConvenioSLA FROM WorkflowConvenio WHERE WorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002M4", "SELECT TM1.WorkflowConvenioId, TM1.WorkflowConvenioCreatedAt, TM1.WorkflowConvenioStatus, TM1.WorkflowConvenioDesc, TM1.WorkflowConvenioSLA FROM WorkflowConvenio TM1 WHERE TM1.WorkflowConvenioId = :WorkflowConvenioId ORDER BY TM1.WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002M5", "SELECT WorkflowConvenioId FROM WorkflowConvenio WHERE WorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002M6", "SELECT WorkflowConvenioId FROM WorkflowConvenio WHERE ( WorkflowConvenioId > :WorkflowConvenioId) ORDER BY WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002M7", "SELECT WorkflowConvenioId FROM WorkflowConvenio WHERE ( WorkflowConvenioId < :WorkflowConvenioId) ORDER BY WorkflowConvenioId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002M8", "SAVEPOINT gxupdate;INSERT INTO WorkflowConvenio(WorkflowConvenioCreatedAt, WorkflowConvenioStatus, WorkflowConvenioDesc, WorkflowConvenioSLA) VALUES(:WorkflowConvenioCreatedAt, :WorkflowConvenioStatus, :WorkflowConvenioDesc, :WorkflowConvenioSLA);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002M8)
             ,new CursorDef("T002M9", "SELECT currval('WorkflowConvenioId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002M10", "SAVEPOINT gxupdate;UPDATE WorkflowConvenio SET WorkflowConvenioCreatedAt=:WorkflowConvenioCreatedAt, WorkflowConvenioStatus=:WorkflowConvenioStatus, WorkflowConvenioDesc=:WorkflowConvenioDesc, WorkflowConvenioSLA=:WorkflowConvenioSLA  WHERE WorkflowConvenioId = :WorkflowConvenioId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002M10)
             ,new CursorDef("T002M11", "SAVEPOINT gxupdate;DELETE FROM WorkflowConvenio  WHERE WorkflowConvenioId = :WorkflowConvenioId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002M11)
             ,new CursorDef("T002M12", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE LogWorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002M13", "SELECT ReembolsoId FROM Reembolso WHERE WorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002M14", "SELECT WorkflowConvenioId FROM WorkflowConvenio ORDER BY WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M14,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
