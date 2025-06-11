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
   public class secuserlog : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
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
            gxLoad_9( A133SecUserId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "secuserlog")), "secuserlog") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "secuserlog")))) ;
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
                  AV7SecUserLogId = (int)(Math.Round(NumberUtil.Val( GetPar( "SecUserLogId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7SecUserLogId", StringUtil.LTrimStr( (decimal)(AV7SecUserLogId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERLOGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SecUserLogId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Log entrada de usuário", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public secuserlog( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserlog( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_SecUserLogId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SecUserLogId = aP1_SecUserLogId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserLogId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserLogId_Internalname, "Log Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserLogId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A559SecUserLogId), 9, 0, ",", "")), StringUtil.LTrim( ((edtSecUserLogId_Enabled!=0) ? context.localUtil.Format( (decimal)(A559SecUserLogId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A559SecUserLogId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserLogId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecUserLogId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SecUserLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsecuserid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksecuserid_Internalname, "Usuário", "", "", lblTextblocksecuserid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_SecUserLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_secuserid.SetProperty("Caption", Combo_secuserid_Caption);
         ucCombo_secuserid.SetProperty("Cls", Combo_secuserid_Cls);
         ucCombo_secuserid.SetProperty("DataListProc", Combo_secuserid_Datalistproc);
         ucCombo_secuserid.SetProperty("DataListProcParametersPrefix", Combo_secuserid_Datalistprocparametersprefix);
         ucCombo_secuserid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_secuserid.SetProperty("DropDownOptionsData", AV13SecUserId_Data);
         ucCombo_secuserid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_secuserid_Internalname, "COMBO_SECUSERIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserId_Internalname, "Usuário", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserId_Internalname, ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", ""))), ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserId_Jsonclick, 0, "Attribute", "", "", "", "", edtSecUserId_Visible, edtSecUserId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SecUserLog.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserFullName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserFullName_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserFullName_Internalname, A143SecUserFullName, StringUtil.RTrim( context.localUtil.Format( A143SecUserFullName, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserFullName_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSecUserFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserLog.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserLog.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_secuserid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosecuserid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ComboSecUserId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCombosecuserid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ComboSecUserId), "ZZZ9") : context.localUtil.Format( (decimal)(AV18ComboSecUserId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosecuserid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosecuserid_Visible, edtavCombosecuserid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SecUserLog.htm");
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
         E11252 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vSECUSERID_DATA"), AV13SecUserId_Data);
               /* Read saved values. */
               Z559SecUserLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z559SecUserLogId"), ",", "."), 18, MidpointRounding.ToEven));
               Z560SecUserLogDateTime = context.localUtil.CToT( cgiGet( "Z560SecUserLogDateTime"), 0);
               n560SecUserLogDateTime = ((DateTime.MinValue==A560SecUserLogDateTime) ? true : false);
               Z133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z133SecUserId"), ",", "."), 18, MidpointRounding.ToEven));
               n133SecUserId = ((0==A133SecUserId) ? true : false);
               A560SecUserLogDateTime = context.localUtil.CToT( cgiGet( "Z560SecUserLogDateTime"), 0);
               n560SecUserLogDateTime = false;
               n560SecUserLogDateTime = ((DateTime.MinValue==A560SecUserLogDateTime) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N133SecUserId"), ",", "."), 18, MidpointRounding.ToEven));
               n133SecUserId = ((0==A133SecUserId) ? true : false);
               AV7SecUserLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vSECUSERLOGID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECUSERID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_SecUserId", StringUtil.LTrimStr( (decimal)(AV11Insert_SecUserId), 4, 0));
               A560SecUserLogDateTime = context.localUtil.CToT( cgiGet( "SECUSERLOGDATETIME"), 0);
               n560SecUserLogDateTime = ((DateTime.MinValue==A560SecUserLogDateTime) ? true : false);
               A141SecUserName = cgiGet( "SECUSERNAME");
               n141SecUserName = false;
               AV19Pgmname = cgiGet( "vPGMNAME");
               Combo_secuserid_Objectcall = cgiGet( "COMBO_SECUSERID_Objectcall");
               Combo_secuserid_Class = cgiGet( "COMBO_SECUSERID_Class");
               Combo_secuserid_Icontype = cgiGet( "COMBO_SECUSERID_Icontype");
               Combo_secuserid_Icon = cgiGet( "COMBO_SECUSERID_Icon");
               Combo_secuserid_Caption = cgiGet( "COMBO_SECUSERID_Caption");
               Combo_secuserid_Tooltip = cgiGet( "COMBO_SECUSERID_Tooltip");
               Combo_secuserid_Cls = cgiGet( "COMBO_SECUSERID_Cls");
               Combo_secuserid_Selectedvalue_set = cgiGet( "COMBO_SECUSERID_Selectedvalue_set");
               Combo_secuserid_Selectedvalue_get = cgiGet( "COMBO_SECUSERID_Selectedvalue_get");
               Combo_secuserid_Selectedtext_set = cgiGet( "COMBO_SECUSERID_Selectedtext_set");
               Combo_secuserid_Selectedtext_get = cgiGet( "COMBO_SECUSERID_Selectedtext_get");
               Combo_secuserid_Gamoauthtoken = cgiGet( "COMBO_SECUSERID_Gamoauthtoken");
               Combo_secuserid_Ddointernalname = cgiGet( "COMBO_SECUSERID_Ddointernalname");
               Combo_secuserid_Titlecontrolalign = cgiGet( "COMBO_SECUSERID_Titlecontrolalign");
               Combo_secuserid_Dropdownoptionstype = cgiGet( "COMBO_SECUSERID_Dropdownoptionstype");
               Combo_secuserid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Enabled"));
               Combo_secuserid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Visible"));
               Combo_secuserid_Titlecontrolidtoreplace = cgiGet( "COMBO_SECUSERID_Titlecontrolidtoreplace");
               Combo_secuserid_Datalisttype = cgiGet( "COMBO_SECUSERID_Datalisttype");
               Combo_secuserid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Allowmultipleselection"));
               Combo_secuserid_Datalistfixedvalues = cgiGet( "COMBO_SECUSERID_Datalistfixedvalues");
               Combo_secuserid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Isgriditem"));
               Combo_secuserid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Hasdescription"));
               Combo_secuserid_Datalistproc = cgiGet( "COMBO_SECUSERID_Datalistproc");
               Combo_secuserid_Datalistprocparametersprefix = cgiGet( "COMBO_SECUSERID_Datalistprocparametersprefix");
               Combo_secuserid_Remoteservicesparameters = cgiGet( "COMBO_SECUSERID_Remoteservicesparameters");
               Combo_secuserid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SECUSERID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_secuserid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Includeonlyselectedoption"));
               Combo_secuserid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Includeselectalloption"));
               Combo_secuserid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Emptyitem"));
               Combo_secuserid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Includeaddnewoption"));
               Combo_secuserid_Htmltemplate = cgiGet( "COMBO_SECUSERID_Htmltemplate");
               Combo_secuserid_Multiplevaluestype = cgiGet( "COMBO_SECUSERID_Multiplevaluestype");
               Combo_secuserid_Loadingdata = cgiGet( "COMBO_SECUSERID_Loadingdata");
               Combo_secuserid_Noresultsfound = cgiGet( "COMBO_SECUSERID_Noresultsfound");
               Combo_secuserid_Emptyitemtext = cgiGet( "COMBO_SECUSERID_Emptyitemtext");
               Combo_secuserid_Onlyselectedvalues = cgiGet( "COMBO_SECUSERID_Onlyselectedvalues");
               Combo_secuserid_Selectalltext = cgiGet( "COMBO_SECUSERID_Selectalltext");
               Combo_secuserid_Multiplevaluesseparator = cgiGet( "COMBO_SECUSERID_Multiplevaluesseparator");
               Combo_secuserid_Addnewoptiontext = cgiGet( "COMBO_SECUSERID_Addnewoptiontext");
               Combo_secuserid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SECUSERID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A559SecUserLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserLogId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
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
               A143SecUserFullName = StringUtil.Upper( cgiGet( edtSecUserFullName_Internalname));
               n143SecUserFullName = false;
               AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
               AV18ComboSecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombosecuserid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18ComboSecUserId", StringUtil.LTrimStr( (decimal)(AV18ComboSecUserId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SecUserLog");
               A559SecUserLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserLogId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
               forbiddenHiddens.Add("SecUserLogId", context.localUtil.Format( (decimal)(A559SecUserLogId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_SecUserId", context.localUtil.Format( (decimal)(AV11Insert_SecUserId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("SecUserLogDateTime", context.localUtil.Format( A560SecUserLogDateTime, "99/99/9999 99:99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A559SecUserLogId != Z559SecUserLogId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("secuserlog:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A559SecUserLogId = (int)(Math.Round(NumberUtil.Val( GetPar( "SecUserLogId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
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
                     sMode77 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode77;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound77 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_250( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SECUSERLOGID");
                        AnyError = 1;
                        GX_FocusControl = edtSecUserLogId_Internalname;
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
                           E11252 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12252 ();
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
            E12252 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2577( ) ;
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
            DisableAttributes2577( ) ;
         }
         AssignProp("", false, edtavCombosecuserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosecuserid_Enabled), 5, 0), true);
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

      protected void CONFIRM_250( )
      {
         BeforeValidate2577( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2577( ) ;
            }
            else
            {
               CheckExtendedTable2577( ) ;
               CloseExtendedTableCursors2577( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption250( )
      {
      }

      protected void E11252( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtSecUserId_Visible = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserId_Visible), 5, 0), true);
         AV18ComboSecUserId = 0;
         AssignAttri("", false, "AV18ComboSecUserId", StringUtil.LTrimStr( (decimal)(AV18ComboSecUserId), 4, 0));
         edtavCombosecuserid_Visible = 0;
         AssignProp("", false, edtavCombosecuserid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosecuserid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSECUSERID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV19Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV20GXV1 = 1;
            AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            while ( AV20GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV20GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SecUserId") == 0 )
               {
                  AV11Insert_SecUserId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_SecUserId", StringUtil.LTrimStr( (decimal)(AV11Insert_SecUserId), 4, 0));
                  if ( ! (0==AV11Insert_SecUserId) )
                  {
                     AV18ComboSecUserId = AV11Insert_SecUserId;
                     AssignAttri("", false, "AV18ComboSecUserId", StringUtil.LTrimStr( (decimal)(AV18ComboSecUserId), 4, 0));
                     Combo_secuserid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV18ComboSecUserId), 4, 0));
                     ucCombo_secuserid.SendProperty(context, "", false, Combo_secuserid_Internalname, "SelectedValue_set", Combo_secuserid_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new secuserlogloaddvcombo(context ).execute(  "SecUserId",  "GET",  false,  AV7SecUserLogId,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_secuserid_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_secuserid.SendProperty(context, "", false, Combo_secuserid_Internalname, "SelectedText_set", Combo_secuserid_Selectedtext_set);
                     Combo_secuserid_Enabled = false;
                     ucCombo_secuserid.SendProperty(context, "", false, Combo_secuserid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_secuserid_Enabled));
                  }
               }
               AV20GXV1 = (int)(AV20GXV1+1);
               AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            }
         }
      }

      protected void E12252( )
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

      protected void S112( )
      {
         /* 'LOADCOMBOSECUSERID' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new secuserlogloaddvcombo(context ).execute(  "SecUserId",  Gx_mode,  false,  AV7SecUserLogId,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_secuserid_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_secuserid.SendProperty(context, "", false, Combo_secuserid_Internalname, "SelectedValue_set", Combo_secuserid_Selectedvalue_set);
         Combo_secuserid_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_secuserid.SendProperty(context, "", false, Combo_secuserid_Internalname, "SelectedText_set", Combo_secuserid_Selectedtext_set);
         AV18ComboSecUserId = (short)(Math.Round(NumberUtil.Val( AV15ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV18ComboSecUserId", StringUtil.LTrimStr( (decimal)(AV18ComboSecUserId), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_secuserid_Enabled = false;
            ucCombo_secuserid.SendProperty(context, "", false, Combo_secuserid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_secuserid_Enabled));
         }
      }

      protected void ZM2577( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z560SecUserLogDateTime = T00253_A560SecUserLogDateTime[0];
               Z133SecUserId = T00253_A133SecUserId[0];
            }
            else
            {
               Z560SecUserLogDateTime = A560SecUserLogDateTime;
               Z133SecUserId = A133SecUserId;
            }
         }
         if ( GX_JID == -8 )
         {
            Z559SecUserLogId = A559SecUserLogId;
            Z560SecUserLogDateTime = A560SecUserLogDateTime;
            Z133SecUserId = A133SecUserId;
            Z141SecUserName = A141SecUserName;
            Z143SecUserFullName = A143SecUserFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSecUserLogId_Enabled = 0;
         AssignProp("", false, edtSecUserLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserLogId_Enabled), 5, 0), true);
         AV19Pgmname = "SecUserLog";
         AssignAttri("", false, "AV19Pgmname", AV19Pgmname);
         edtSecUserLogId_Enabled = 0;
         AssignProp("", false, edtSecUserLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserLogId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SecUserLogId) )
         {
            A559SecUserLogId = AV7SecUserLogId;
            AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_SecUserId) )
         {
            edtSecUserId_Enabled = 0;
            AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         }
         else
         {
            edtSecUserId_Enabled = 1;
            AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_SecUserId) )
         {
            A133SecUserId = AV11Insert_SecUserId;
            n133SecUserId = false;
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV18ComboSecUserId) )
            {
               A133SecUserId = 0;
               n133SecUserId = false;
               AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
               n133SecUserId = true;
               n133SecUserId = true;
               AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV18ComboSecUserId) )
               {
                  A133SecUserId = AV18ComboSecUserId;
                  n133SecUserId = false;
                  AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
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
            /* Using cursor T00254 */
            pr_default.execute(2, new Object[] {n133SecUserId, A133SecUserId});
            A141SecUserName = T00254_A141SecUserName[0];
            n141SecUserName = T00254_n141SecUserName[0];
            A143SecUserFullName = T00254_A143SecUserFullName[0];
            n143SecUserFullName = T00254_n143SecUserFullName[0];
            AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
            pr_default.close(2);
         }
      }

      protected void Load2577( )
      {
         /* Using cursor T00255 */
         pr_default.execute(3, new Object[] {A559SecUserLogId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound77 = 1;
            A141SecUserName = T00255_A141SecUserName[0];
            n141SecUserName = T00255_n141SecUserName[0];
            A143SecUserFullName = T00255_A143SecUserFullName[0];
            n143SecUserFullName = T00255_n143SecUserFullName[0];
            AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
            A560SecUserLogDateTime = T00255_A560SecUserLogDateTime[0];
            n560SecUserLogDateTime = T00255_n560SecUserLogDateTime[0];
            A133SecUserId = T00255_A133SecUserId[0];
            n133SecUserId = T00255_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            ZM2577( -8) ;
         }
         pr_default.close(3);
         OnLoadActions2577( ) ;
      }

      protected void OnLoadActions2577( )
      {
      }

      protected void CheckExtendedTable2577( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00254 */
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
         A141SecUserName = T00254_A141SecUserName[0];
         n141SecUserName = T00254_n141SecUserName[0];
         A143SecUserFullName = T00254_A143SecUserFullName[0];
         n143SecUserFullName = T00254_n143SecUserFullName[0];
         AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors2577( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( short A133SecUserId )
      {
         /* Using cursor T00256 */
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
         A141SecUserName = T00256_A141SecUserName[0];
         n141SecUserName = T00256_n141SecUserName[0];
         A143SecUserFullName = T00256_A143SecUserFullName[0];
         n143SecUserFullName = T00256_n143SecUserFullName[0];
         AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A141SecUserName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A143SecUserFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey2577( )
      {
         /* Using cursor T00257 */
         pr_default.execute(5, new Object[] {A559SecUserLogId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound77 = 1;
         }
         else
         {
            RcdFound77 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00253 */
         pr_default.execute(1, new Object[] {A559SecUserLogId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2577( 8) ;
            RcdFound77 = 1;
            A559SecUserLogId = T00253_A559SecUserLogId[0];
            AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
            A560SecUserLogDateTime = T00253_A560SecUserLogDateTime[0];
            n560SecUserLogDateTime = T00253_n560SecUserLogDateTime[0];
            A133SecUserId = T00253_A133SecUserId[0];
            n133SecUserId = T00253_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            Z559SecUserLogId = A559SecUserLogId;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2577( ) ;
            if ( AnyError == 1 )
            {
               RcdFound77 = 0;
               InitializeNonKey2577( ) ;
            }
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound77 = 0;
            InitializeNonKey2577( ) ;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2577( ) ;
         if ( RcdFound77 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound77 = 0;
         /* Using cursor T00258 */
         pr_default.execute(6, new Object[] {A559SecUserLogId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00258_A559SecUserLogId[0] < A559SecUserLogId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00258_A559SecUserLogId[0] > A559SecUserLogId ) ) )
            {
               A559SecUserLogId = T00258_A559SecUserLogId[0];
               AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
               RcdFound77 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound77 = 0;
         /* Using cursor T00259 */
         pr_default.execute(7, new Object[] {A559SecUserLogId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00259_A559SecUserLogId[0] > A559SecUserLogId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00259_A559SecUserLogId[0] < A559SecUserLogId ) ) )
            {
               A559SecUserLogId = T00259_A559SecUserLogId[0];
               AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
               RcdFound77 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2577( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2577( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound77 == 1 )
            {
               if ( A559SecUserLogId != Z559SecUserLogId )
               {
                  A559SecUserLogId = Z559SecUserLogId;
                  AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECUSERLOGID");
                  AnyError = 1;
                  GX_FocusControl = edtSecUserLogId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2577( ) ;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A559SecUserLogId != Z559SecUserLogId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2577( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECUSERLOGID");
                     AnyError = 1;
                     GX_FocusControl = edtSecUserLogId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSecUserId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2577( ) ;
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
         if ( A559SecUserLogId != Z559SecUserLogId )
         {
            A559SecUserLogId = Z559SecUserLogId;
            AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECUSERLOGID");
            AnyError = 1;
            GX_FocusControl = edtSecUserLogId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2577( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00252 */
            pr_default.execute(0, new Object[] {A559SecUserLogId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserLog"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z560SecUserLogDateTime != T00252_A560SecUserLogDateTime[0] ) || ( Z133SecUserId != T00252_A133SecUserId[0] ) )
            {
               if ( Z560SecUserLogDateTime != T00252_A560SecUserLogDateTime[0] )
               {
                  GXUtil.WriteLog("secuserlog:[seudo value changed for attri]"+"SecUserLogDateTime");
                  GXUtil.WriteLogRaw("Old: ",Z560SecUserLogDateTime);
                  GXUtil.WriteLogRaw("Current: ",T00252_A560SecUserLogDateTime[0]);
               }
               if ( Z133SecUserId != T00252_A133SecUserId[0] )
               {
                  GXUtil.WriteLog("secuserlog:[seudo value changed for attri]"+"SecUserId");
                  GXUtil.WriteLogRaw("Old: ",Z133SecUserId);
                  GXUtil.WriteLogRaw("Current: ",T00252_A133SecUserId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUserLog"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2577( )
      {
         BeforeValidate2577( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2577( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2577( 0) ;
            CheckOptimisticConcurrency2577( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2577( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2577( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002510 */
                     pr_default.execute(8, new Object[] {n560SecUserLogDateTime, A560SecUserLogDateTime, n133SecUserId, A133SecUserId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002511 */
                     pr_default.execute(9);
                     A559SecUserLogId = T002511_A559SecUserLogId[0];
                     AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserLog");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption250( ) ;
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
               Load2577( ) ;
            }
            EndLevel2577( ) ;
         }
         CloseExtendedTableCursors2577( ) ;
      }

      protected void Update2577( )
      {
         BeforeValidate2577( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2577( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2577( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2577( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2577( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002512 */
                     pr_default.execute(10, new Object[] {n560SecUserLogDateTime, A560SecUserLogDateTime, n133SecUserId, A133SecUserId, A559SecUserLogId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserLog");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserLog"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2577( ) ;
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
            EndLevel2577( ) ;
         }
         CloseExtendedTableCursors2577( ) ;
      }

      protected void DeferredUpdate2577( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2577( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2577( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2577( ) ;
            AfterConfirm2577( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2577( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002513 */
                  pr_default.execute(11, new Object[] {A559SecUserLogId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("SecUserLog");
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
         sMode77 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2577( ) ;
         Gx_mode = sMode77;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2577( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002514 */
            pr_default.execute(12, new Object[] {n133SecUserId, A133SecUserId});
            A141SecUserName = T002514_A141SecUserName[0];
            n141SecUserName = T002514_n141SecUserName[0];
            A143SecUserFullName = T002514_A143SecUserFullName[0];
            n143SecUserFullName = T002514_n143SecUserFullName[0];
            AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
            pr_default.close(12);
         }
      }

      protected void EndLevel2577( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2577( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues250( ) ;
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

      public void ScanStart2577( )
      {
         /* Scan By routine */
         /* Using cursor T002515 */
         pr_default.execute(13);
         RcdFound77 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound77 = 1;
            A559SecUserLogId = T002515_A559SecUserLogId[0];
            AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2577( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound77 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound77 = 1;
            A559SecUserLogId = T002515_A559SecUserLogId[0];
            AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
         }
      }

      protected void ScanEnd2577( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm2577( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2577( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2577( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2577( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2577( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2577( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2577( )
      {
         edtSecUserLogId_Enabled = 0;
         AssignProp("", false, edtSecUserLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserLogId_Enabled), 5, 0), true);
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         edtSecUserFullName_Enabled = 0;
         AssignProp("", false, edtSecUserFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserFullName_Enabled), 5, 0), true);
         edtavCombosecuserid_Enabled = 0;
         AssignProp("", false, edtavCombosecuserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosecuserid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2577( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues250( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "secuserlog"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SecUserLogId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("secuserlog") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SecUserLog");
         forbiddenHiddens.Add("SecUserLogId", context.localUtil.Format( (decimal)(A559SecUserLogId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_SecUserId", context.localUtil.Format( (decimal)(AV11Insert_SecUserId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("SecUserLogDateTime", context.localUtil.Format( A560SecUserLogDateTime, "99/99/9999 99:99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("secuserlog:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z559SecUserLogId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z559SecUserLogId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z560SecUserLogDateTime", context.localUtil.TToC( Z560SecUserLogDateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z133SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N133SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSECUSERID_DATA", AV13SecUserId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSECUSERID_DATA", AV13SecUserId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vSECUSERLOGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SecUserLogId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECUSERLOGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SecUserLogId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSERLOGDATETIME", context.localUtil.TToC( A560SecUserLogDateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "SECUSERNAME", A141SecUserName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV19Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Objectcall", StringUtil.RTrim( Combo_secuserid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Cls", StringUtil.RTrim( Combo_secuserid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Selectedvalue_set", StringUtil.RTrim( Combo_secuserid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Selectedtext_set", StringUtil.RTrim( Combo_secuserid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Enabled", StringUtil.BoolToStr( Combo_secuserid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Datalistproc", StringUtil.RTrim( Combo_secuserid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_secuserid_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "secuserlog"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SecUserLogId,9,0));
         return formatLink("secuserlog") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SecUserLog" ;
      }

      public override string GetPgmdesc( )
      {
         return "Log entrada de usuário" ;
      }

      protected void InitializeNonKey2577( )
      {
         A133SecUserId = 0;
         n133SecUserId = false;
         AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
         n133SecUserId = ((0==A133SecUserId) ? true : false);
         A141SecUserName = "";
         n141SecUserName = false;
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
         A143SecUserFullName = "";
         n143SecUserFullName = false;
         AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
         A560SecUserLogDateTime = (DateTime)(DateTime.MinValue);
         n560SecUserLogDateTime = false;
         AssignAttri("", false, "A560SecUserLogDateTime", context.localUtil.TToC( A560SecUserLogDateTime, 10, 5, 0, 3, "/", ":", " "));
         Z560SecUserLogDateTime = (DateTime)(DateTime.MinValue);
         Z133SecUserId = 0;
      }

      protected void InitAll2577( )
      {
         A559SecUserLogId = 0;
         AssignAttri("", false, "A559SecUserLogId", StringUtil.LTrimStr( (decimal)(A559SecUserLogId), 9, 0));
         InitializeNonKey2577( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019185397", true, true);
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
         context.AddJavascriptSource("secuserlog.js", "?202561019185397", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSecUserLogId_Internalname = "SECUSERLOGID";
         lblTextblocksecuserid_Internalname = "TEXTBLOCKSECUSERID";
         Combo_secuserid_Internalname = "COMBO_SECUSERID";
         edtSecUserId_Internalname = "SECUSERID";
         divTablesplittedsecuserid_Internalname = "TABLESPLITTEDSECUSERID";
         edtSecUserFullName_Internalname = "SECUSERFULLNAME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombosecuserid_Internalname = "vCOMBOSECUSERID";
         divSectionattribute_secuserid_Internalname = "SECTIONATTRIBUTE_SECUSERID";
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
         Form.Caption = "Log entrada de usuário";
         edtavCombosecuserid_Jsonclick = "";
         edtavCombosecuserid_Enabled = 0;
         edtavCombosecuserid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSecUserFullName_Jsonclick = "";
         edtSecUserFullName_Enabled = 0;
         edtSecUserId_Jsonclick = "";
         edtSecUserId_Enabled = 1;
         edtSecUserId_Visible = 1;
         Combo_secuserid_Datalistprocparametersprefix = " \"ComboName\": \"SecUserId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"SecUserLogId\": 0";
         Combo_secuserid_Datalistproc = "SecUserLogLoadDVCombo";
         Combo_secuserid_Cls = "ExtendedCombo AttributeFL";
         Combo_secuserid_Caption = "";
         Combo_secuserid_Enabled = Convert.ToBoolean( -1);
         edtSecUserLogId_Jsonclick = "";
         edtSecUserLogId_Enabled = 0;
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

      public void Valid_Secuserid( )
      {
         n141SecUserName = false;
         n143SecUserFullName = false;
         /* Using cursor T002514 */
         pr_default.execute(12, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
            }
         }
         A141SecUserName = T002514_A141SecUserName[0];
         n141SecUserName = T002514_n141SecUserName[0];
         A143SecUserFullName = T002514_A143SecUserFullName[0];
         n143SecUserFullName = T002514_n143SecUserFullName[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
         AssignAttri("", false, "A143SecUserFullName", A143SecUserFullName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SecUserLogId","fld":"vSECUSERLOGID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SecUserLogId","fld":"vSECUSERLOGID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A559SecUserLogId","fld":"SECUSERLOGID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_SecUserId","fld":"vINSERT_SECUSERID","pic":"ZZZ9","type":"int"},{"av":"A560SecUserLogDateTime","fld":"SECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12252","iparms":[]}""");
         setEventMetadata("VALID_SECUSERLOGID","""{"handler":"Valid_Secuserlogid","iparms":[]}""");
         setEventMetadata("VALID_SECUSERID","""{"handler":"Valid_Secuserid","iparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","nullAv":"n133SecUserId","type":"int"},{"av":"A141SecUserName","fld":"SECUSERNAME","pic":"@!","type":"svchar"},{"av":"A143SecUserFullName","fld":"SECUSERFULLNAME","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_SECUSERID",""","oparms":[{"av":"A141SecUserName","fld":"SECUSERNAME","pic":"@!","type":"svchar"},{"av":"A143SecUserFullName","fld":"SECUSERFULLNAME","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALIDV_COMBOSECUSERID","""{"handler":"Validv_Combosecuserid","iparms":[]}""");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z560SecUserLogDateTime = (DateTime)(DateTime.MinValue);
         Combo_secuserid_Selectedvalue_get = "";
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
         lblTextblocksecuserid_Jsonclick = "";
         ucCombo_secuserid = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13SecUserId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A143SecUserFullName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A560SecUserLogDateTime = (DateTime)(DateTime.MinValue);
         A141SecUserName = "";
         AV19Pgmname = "";
         Combo_secuserid_Objectcall = "";
         Combo_secuserid_Class = "";
         Combo_secuserid_Icontype = "";
         Combo_secuserid_Icon = "";
         Combo_secuserid_Tooltip = "";
         Combo_secuserid_Selectedvalue_set = "";
         Combo_secuserid_Selectedtext_set = "";
         Combo_secuserid_Selectedtext_get = "";
         Combo_secuserid_Gamoauthtoken = "";
         Combo_secuserid_Ddointernalname = "";
         Combo_secuserid_Titlecontrolalign = "";
         Combo_secuserid_Dropdownoptionstype = "";
         Combo_secuserid_Titlecontrolidtoreplace = "";
         Combo_secuserid_Datalisttype = "";
         Combo_secuserid_Datalistfixedvalues = "";
         Combo_secuserid_Remoteservicesparameters = "";
         Combo_secuserid_Htmltemplate = "";
         Combo_secuserid_Multiplevaluestype = "";
         Combo_secuserid_Loadingdata = "";
         Combo_secuserid_Noresultsfound = "";
         Combo_secuserid_Emptyitemtext = "";
         Combo_secuserid_Onlyselectedvalues = "";
         Combo_secuserid_Selectalltext = "";
         Combo_secuserid_Multiplevaluesseparator = "";
         Combo_secuserid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode77 = "";
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
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV17Combo_DataJson = "";
         AV15ComboSelectedValue = "";
         AV16ComboSelectedText = "";
         GXt_char2 = "";
         Z141SecUserName = "";
         Z143SecUserFullName = "";
         T00254_A141SecUserName = new string[] {""} ;
         T00254_n141SecUserName = new bool[] {false} ;
         T00254_A143SecUserFullName = new string[] {""} ;
         T00254_n143SecUserFullName = new bool[] {false} ;
         T00255_A559SecUserLogId = new int[1] ;
         T00255_A141SecUserName = new string[] {""} ;
         T00255_n141SecUserName = new bool[] {false} ;
         T00255_A143SecUserFullName = new string[] {""} ;
         T00255_n143SecUserFullName = new bool[] {false} ;
         T00255_A560SecUserLogDateTime = new DateTime[] {DateTime.MinValue} ;
         T00255_n560SecUserLogDateTime = new bool[] {false} ;
         T00255_A133SecUserId = new short[1] ;
         T00255_n133SecUserId = new bool[] {false} ;
         T00256_A141SecUserName = new string[] {""} ;
         T00256_n141SecUserName = new bool[] {false} ;
         T00256_A143SecUserFullName = new string[] {""} ;
         T00256_n143SecUserFullName = new bool[] {false} ;
         T00257_A559SecUserLogId = new int[1] ;
         T00253_A559SecUserLogId = new int[1] ;
         T00253_A560SecUserLogDateTime = new DateTime[] {DateTime.MinValue} ;
         T00253_n560SecUserLogDateTime = new bool[] {false} ;
         T00253_A133SecUserId = new short[1] ;
         T00253_n133SecUserId = new bool[] {false} ;
         T00258_A559SecUserLogId = new int[1] ;
         T00259_A559SecUserLogId = new int[1] ;
         T00252_A559SecUserLogId = new int[1] ;
         T00252_A560SecUserLogDateTime = new DateTime[] {DateTime.MinValue} ;
         T00252_n560SecUserLogDateTime = new bool[] {false} ;
         T00252_A133SecUserId = new short[1] ;
         T00252_n133SecUserId = new bool[] {false} ;
         T002511_A559SecUserLogId = new int[1] ;
         T002514_A141SecUserName = new string[] {""} ;
         T002514_n141SecUserName = new bool[] {false} ;
         T002514_A143SecUserFullName = new string[] {""} ;
         T002514_n143SecUserFullName = new bool[] {false} ;
         T002515_A559SecUserLogId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuserlog__default(),
            new Object[][] {
                new Object[] {
               T00252_A559SecUserLogId, T00252_A560SecUserLogDateTime, T00252_n560SecUserLogDateTime, T00252_A133SecUserId, T00252_n133SecUserId
               }
               , new Object[] {
               T00253_A559SecUserLogId, T00253_A560SecUserLogDateTime, T00253_n560SecUserLogDateTime, T00253_A133SecUserId, T00253_n133SecUserId
               }
               , new Object[] {
               T00254_A141SecUserName, T00254_n141SecUserName, T00254_A143SecUserFullName, T00254_n143SecUserFullName
               }
               , new Object[] {
               T00255_A559SecUserLogId, T00255_A141SecUserName, T00255_n141SecUserName, T00255_A143SecUserFullName, T00255_n143SecUserFullName, T00255_A560SecUserLogDateTime, T00255_n560SecUserLogDateTime, T00255_A133SecUserId, T00255_n133SecUserId
               }
               , new Object[] {
               T00256_A141SecUserName, T00256_n141SecUserName, T00256_A143SecUserFullName, T00256_n143SecUserFullName
               }
               , new Object[] {
               T00257_A559SecUserLogId
               }
               , new Object[] {
               T00258_A559SecUserLogId
               }
               , new Object[] {
               T00259_A559SecUserLogId
               }
               , new Object[] {
               }
               , new Object[] {
               T002511_A559SecUserLogId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002514_A141SecUserName, T002514_n141SecUserName, T002514_A143SecUserFullName, T002514_n143SecUserFullName
               }
               , new Object[] {
               T002515_A559SecUserLogId
               }
            }
         );
         AV19Pgmname = "SecUserLog";
      }

      private short Z133SecUserId ;
      private short N133SecUserId ;
      private short GxWebError ;
      private short A133SecUserId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV18ComboSecUserId ;
      private short AV11Insert_SecUserId ;
      private short RcdFound77 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7SecUserLogId ;
      private int Z559SecUserLogId ;
      private int AV7SecUserLogId ;
      private int trnEnded ;
      private int A559SecUserLogId ;
      private int edtSecUserLogId_Enabled ;
      private int edtSecUserId_Visible ;
      private int edtSecUserId_Enabled ;
      private int edtSecUserFullName_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombosecuserid_Enabled ;
      private int edtavCombosecuserid_Visible ;
      private int Combo_secuserid_Datalistupdateminimumcharacters ;
      private int Combo_secuserid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV20GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_secuserid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSecUserId_Internalname ;
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
      private string edtSecUserLogId_Internalname ;
      private string TempTags ;
      private string edtSecUserLogId_Jsonclick ;
      private string divTablesplittedsecuserid_Internalname ;
      private string lblTextblocksecuserid_Internalname ;
      private string lblTextblocksecuserid_Jsonclick ;
      private string Combo_secuserid_Caption ;
      private string Combo_secuserid_Cls ;
      private string Combo_secuserid_Datalistproc ;
      private string Combo_secuserid_Datalistprocparametersprefix ;
      private string Combo_secuserid_Internalname ;
      private string edtSecUserId_Jsonclick ;
      private string edtSecUserFullName_Internalname ;
      private string edtSecUserFullName_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_secuserid_Internalname ;
      private string edtavCombosecuserid_Internalname ;
      private string edtavCombosecuserid_Jsonclick ;
      private string AV19Pgmname ;
      private string Combo_secuserid_Objectcall ;
      private string Combo_secuserid_Class ;
      private string Combo_secuserid_Icontype ;
      private string Combo_secuserid_Icon ;
      private string Combo_secuserid_Tooltip ;
      private string Combo_secuserid_Selectedvalue_set ;
      private string Combo_secuserid_Selectedtext_set ;
      private string Combo_secuserid_Selectedtext_get ;
      private string Combo_secuserid_Gamoauthtoken ;
      private string Combo_secuserid_Ddointernalname ;
      private string Combo_secuserid_Titlecontrolalign ;
      private string Combo_secuserid_Dropdownoptionstype ;
      private string Combo_secuserid_Titlecontrolidtoreplace ;
      private string Combo_secuserid_Datalisttype ;
      private string Combo_secuserid_Datalistfixedvalues ;
      private string Combo_secuserid_Remoteservicesparameters ;
      private string Combo_secuserid_Htmltemplate ;
      private string Combo_secuserid_Multiplevaluestype ;
      private string Combo_secuserid_Loadingdata ;
      private string Combo_secuserid_Noresultsfound ;
      private string Combo_secuserid_Emptyitemtext ;
      private string Combo_secuserid_Onlyselectedvalues ;
      private string Combo_secuserid_Selectalltext ;
      private string Combo_secuserid_Multiplevaluesseparator ;
      private string Combo_secuserid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode77 ;
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
      private DateTime Z560SecUserLogDateTime ;
      private DateTime A560SecUserLogDateTime ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n133SecUserId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n560SecUserLogDateTime ;
      private bool n141SecUserName ;
      private bool Combo_secuserid_Enabled ;
      private bool Combo_secuserid_Visible ;
      private bool Combo_secuserid_Allowmultipleselection ;
      private bool Combo_secuserid_Isgriditem ;
      private bool Combo_secuserid_Hasdescription ;
      private bool Combo_secuserid_Includeonlyselectedoption ;
      private bool Combo_secuserid_Includeselectalloption ;
      private bool Combo_secuserid_Emptyitem ;
      private bool Combo_secuserid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n143SecUserFullName ;
      private bool returnInSub ;
      private string AV17Combo_DataJson ;
      private string A143SecUserFullName ;
      private string A141SecUserName ;
      private string AV15ComboSelectedValue ;
      private string AV16ComboSelectedText ;
      private string Z141SecUserName ;
      private string Z143SecUserFullName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_secuserid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13SecUserId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00254_A141SecUserName ;
      private bool[] T00254_n141SecUserName ;
      private string[] T00254_A143SecUserFullName ;
      private bool[] T00254_n143SecUserFullName ;
      private int[] T00255_A559SecUserLogId ;
      private string[] T00255_A141SecUserName ;
      private bool[] T00255_n141SecUserName ;
      private string[] T00255_A143SecUserFullName ;
      private bool[] T00255_n143SecUserFullName ;
      private DateTime[] T00255_A560SecUserLogDateTime ;
      private bool[] T00255_n560SecUserLogDateTime ;
      private short[] T00255_A133SecUserId ;
      private bool[] T00255_n133SecUserId ;
      private string[] T00256_A141SecUserName ;
      private bool[] T00256_n141SecUserName ;
      private string[] T00256_A143SecUserFullName ;
      private bool[] T00256_n143SecUserFullName ;
      private int[] T00257_A559SecUserLogId ;
      private int[] T00253_A559SecUserLogId ;
      private DateTime[] T00253_A560SecUserLogDateTime ;
      private bool[] T00253_n560SecUserLogDateTime ;
      private short[] T00253_A133SecUserId ;
      private bool[] T00253_n133SecUserId ;
      private int[] T00258_A559SecUserLogId ;
      private int[] T00259_A559SecUserLogId ;
      private int[] T00252_A559SecUserLogId ;
      private DateTime[] T00252_A560SecUserLogDateTime ;
      private bool[] T00252_n560SecUserLogDateTime ;
      private short[] T00252_A133SecUserId ;
      private bool[] T00252_n133SecUserId ;
      private int[] T002511_A559SecUserLogId ;
      private string[] T002514_A141SecUserName ;
      private bool[] T002514_n141SecUserName ;
      private string[] T002514_A143SecUserFullName ;
      private bool[] T002514_n143SecUserFullName ;
      private int[] T002515_A559SecUserLogId ;
   }

   public class secuserlog__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00252;
          prmT00252 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmT00253;
          prmT00253 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmT00254;
          prmT00254 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00255;
          prmT00255 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmT00256;
          prmT00256 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00257;
          prmT00257 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmT00258;
          prmT00258 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmT00259;
          prmT00259 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmT002510;
          prmT002510 = new Object[] {
          new ParDef("SecUserLogDateTime",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002511;
          prmT002511 = new Object[] {
          };
          Object[] prmT002512;
          prmT002512 = new Object[] {
          new ParDef("SecUserLogDateTime",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmT002513;
          prmT002513 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmT002514;
          prmT002514 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002515;
          prmT002515 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00252", "SELECT SecUserLogId, SecUserLogDateTime, SecUserId FROM SecUserLog WHERE SecUserLogId = :SecUserLogId  FOR UPDATE OF SecUserLog NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00252,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00253", "SELECT SecUserLogId, SecUserLogDateTime, SecUserId FROM SecUserLog WHERE SecUserLogId = :SecUserLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00253,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00254", "SELECT SecUserName, SecUserFullName FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00254,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00255", "SELECT TM1.SecUserLogId, T2.SecUserName, T2.SecUserFullName, TM1.SecUserLogDateTime, TM1.SecUserId FROM (SecUserLog TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.SecUserId) WHERE TM1.SecUserLogId = :SecUserLogId ORDER BY TM1.SecUserLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00255,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00256", "SELECT SecUserName, SecUserFullName FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00256,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00257", "SELECT SecUserLogId FROM SecUserLog WHERE SecUserLogId = :SecUserLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00257,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00258", "SELECT SecUserLogId FROM SecUserLog WHERE ( SecUserLogId > :SecUserLogId) ORDER BY SecUserLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00258,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00259", "SELECT SecUserLogId FROM SecUserLog WHERE ( SecUserLogId < :SecUserLogId) ORDER BY SecUserLogId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00259,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002510", "SAVEPOINT gxupdate;INSERT INTO SecUserLog(SecUserLogDateTime, SecUserId) VALUES(:SecUserLogDateTime, :SecUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002510)
             ,new CursorDef("T002511", "SELECT currval('SecUserLogId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002511,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002512", "SAVEPOINT gxupdate;UPDATE SecUserLog SET SecUserLogDateTime=:SecUserLogDateTime, SecUserId=:SecUserId  WHERE SecUserLogId = :SecUserLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002512)
             ,new CursorDef("T002513", "SAVEPOINT gxupdate;DELETE FROM SecUserLog  WHERE SecUserLogId = :SecUserLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002513)
             ,new CursorDef("T002514", "SELECT SecUserName, SecUserFullName FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002514,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002515", "SELECT SecUserLogId FROM SecUserLog ORDER BY SecUserLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002515,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
