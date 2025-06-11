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
   public class notafiscalitem : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A323PropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A794NotaFiscalId = StringUtil.StrToGuid( GetPar( "NotaFiscalId"));
            n794NotaFiscalId = false;
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A794NotaFiscalId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "notafiscalitem")), "notafiscalitem") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "notafiscalitem")))) ;
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
                  AV7NotaFiscalItemId = StringUtil.StrToGuid( GetPar( "NotaFiscalItemId"));
                  AssignAttri("", false, "AV7NotaFiscalItemId", AV7NotaFiscalItemId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vNOTAFISCALITEMID", GetSecureSignedToken( "", AV7NotaFiscalItemId, context));
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
         Form.Meta.addItem("description", "Nota Fiscal Item", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNotaFiscalItemId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public notafiscalitem( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notafiscalitem( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_NotaFiscalItemId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7NotaFiscalItemId = aP1_NotaFiscalItemId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalItemId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalItemId_Internalname, "Item Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalItemId_Internalname, A830NotaFiscalItemId.ToString(), A830NotaFiscalItemId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalItemId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNotaFiscalItemId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_NotaFiscalItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedpropostaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockpropostaid_Internalname, "Proposta", "", "", lblTextblockpropostaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_NotaFiscalItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_propostaid.SetProperty("Caption", Combo_propostaid_Caption);
         ucCombo_propostaid.SetProperty("Cls", Combo_propostaid_Cls);
         ucCombo_propostaid.SetProperty("DataListProc", Combo_propostaid_Datalistproc);
         ucCombo_propostaid.SetProperty("DataListProcParametersPrefix", Combo_propostaid_Datalistprocparametersprefix);
         ucCombo_propostaid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_propostaid.SetProperty("DropDownOptionsData", AV14PropostaId_Data);
         ucCombo_propostaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_propostaid_Internalname, "COMBO_PROPOSTAIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaId_Internalname, "Proposta Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaId_Internalname, ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", ""))), ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaId_Jsonclick, 0, "Attribute", "", "", "", "", edtPropostaId_Visible, edtPropostaId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_NotaFiscalItem.htm");
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
         GxWebStd.gx_div_start( context, divTablesplittednotafiscalid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocknotafiscalid_Internalname, "Nota Fiscal", "", "", lblTextblocknotafiscalid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_NotaFiscalItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_notafiscalid.SetProperty("Caption", Combo_notafiscalid_Caption);
         ucCombo_notafiscalid.SetProperty("Cls", Combo_notafiscalid_Cls);
         ucCombo_notafiscalid.SetProperty("DataListProc", Combo_notafiscalid_Datalistproc);
         ucCombo_notafiscalid.SetProperty("DataListProcParametersPrefix", Combo_notafiscalid_Datalistprocparametersprefix);
         ucCombo_notafiscalid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_notafiscalid.SetProperty("DropDownOptionsData", AV20NotaFiscalId_Data);
         ucCombo_notafiscalid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_notafiscalid_Internalname, "COMBO_NOTAFISCALIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalId_Internalname, "Nota Fiscal Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalId_Internalname, A794NotaFiscalId.ToString(), A794NotaFiscalId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalId_Jsonclick, 0, "Attribute", "", "", "", "", edtNotaFiscalId_Visible, edtNotaFiscalId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_NotaFiscalItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscalItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscalItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscalItem.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_propostaid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombopropostaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboPropostaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavCombopropostaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboPropostaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboPropostaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopropostaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopropostaid_Visible, edtavCombopropostaid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotaFiscalItem.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_notafiscalid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombonotafiscalid_Internalname, AV21ComboNotaFiscalId.ToString(), AV21ComboNotaFiscalId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombonotafiscalid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombonotafiscalid_Visible, edtavCombonotafiscalid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_NotaFiscalItem.htm");
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
         E112O2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPROPOSTAID_DATA"), AV14PropostaId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vNOTAFISCALID_DATA"), AV20NotaFiscalId_Data);
               /* Read saved values. */
               Z830NotaFiscalItemId = StringUtil.StrToGuid( cgiGet( "Z830NotaFiscalItemId"));
               Z831NotaFiscalItemCodigo = cgiGet( "Z831NotaFiscalItemCodigo");
               n831NotaFiscalItemCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A831NotaFiscalItemCodigo)) ? true : false);
               Z832NotaFiscalItemCFOP = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z832NotaFiscalItemCFOP"), ",", "."), 18, MidpointRounding.ToEven));
               n832NotaFiscalItemCFOP = ((0==A832NotaFiscalItemCFOP) ? true : false);
               Z833NotaFiscalItemDescricao = cgiGet( "Z833NotaFiscalItemDescricao");
               n833NotaFiscalItemDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A833NotaFiscalItemDescricao)) ? true : false);
               Z834NotaFiscalItemNCM = cgiGet( "Z834NotaFiscalItemNCM");
               n834NotaFiscalItemNCM = (String.IsNullOrEmpty(StringUtil.RTrim( A834NotaFiscalItemNCM)) ? true : false);
               Z835NotaFiscalItemCodigoEAN = cgiGet( "Z835NotaFiscalItemCodigoEAN");
               n835NotaFiscalItemCodigoEAN = (String.IsNullOrEmpty(StringUtil.RTrim( A835NotaFiscalItemCodigoEAN)) ? true : false);
               Z836NotaFiscalItemUnidadeComercial = cgiGet( "Z836NotaFiscalItemUnidadeComercial");
               n836NotaFiscalItemUnidadeComercial = (String.IsNullOrEmpty(StringUtil.RTrim( A836NotaFiscalItemUnidadeComercial)) ? true : false);
               Z837NotaFiscalItemQuantidade = context.localUtil.CToN( cgiGet( "Z837NotaFiscalItemQuantidade"), ",", ".");
               n837NotaFiscalItemQuantidade = ((Convert.ToDecimal(0)==A837NotaFiscalItemQuantidade) ? true : false);
               Z838NotaFiscalItemValorUnitario = context.localUtil.CToN( cgiGet( "Z838NotaFiscalItemValorUnitario"), ",", ".");
               n838NotaFiscalItemValorUnitario = ((Convert.ToDecimal(0)==A838NotaFiscalItemValorUnitario) ? true : false);
               Z839NotaFiscalItemValorTotal = context.localUtil.CToN( cgiGet( "Z839NotaFiscalItemValorTotal"), ",", ".");
               n839NotaFiscalItemValorTotal = ((Convert.ToDecimal(0)==A839NotaFiscalItemValorTotal) ? true : false);
               Z840NotaFiscalItemCodBarGTIN = cgiGet( "Z840NotaFiscalItemCodBarGTIN");
               n840NotaFiscalItemCodBarGTIN = (String.IsNullOrEmpty(StringUtil.RTrim( A840NotaFiscalItemCodBarGTIN)) ? true : false);
               Z841NotaFiscalItemUnidadeTributavel = cgiGet( "Z841NotaFiscalItemUnidadeTributavel");
               n841NotaFiscalItemUnidadeTributavel = (String.IsNullOrEmpty(StringUtil.RTrim( A841NotaFiscalItemUnidadeTributavel)) ? true : false);
               Z842NotaFiscalItemValorUnTributavel = context.localUtil.CToN( cgiGet( "Z842NotaFiscalItemValorUnTributavel"), ",", ".");
               n842NotaFiscalItemValorUnTributavel = ((Convert.ToDecimal(0)==A842NotaFiscalItemValorUnTributavel) ? true : false);
               Z843NotaFiscalItemQtdTributavel = context.localUtil.CToN( cgiGet( "Z843NotaFiscalItemQtdTributavel"), ",", ".");
               n843NotaFiscalItemQtdTributavel = ((Convert.ToDecimal(0)==A843NotaFiscalItemQtdTributavel) ? true : false);
               Z844NotaFiscalItemValorFrete = context.localUtil.CToN( cgiGet( "Z844NotaFiscalItemValorFrete"), ",", ".");
               n844NotaFiscalItemValorFrete = ((Convert.ToDecimal(0)==A844NotaFiscalItemValorFrete) ? true : false);
               Z845NotaFiscalItemDesconto = context.localUtil.CToN( cgiGet( "Z845NotaFiscalItemDesconto"), ",", ".");
               n845NotaFiscalItemDesconto = ((Convert.ToDecimal(0)==A845NotaFiscalItemDesconto) ? true : false);
               Z846NotaFiscalItemIndicadorValorTotal = cgiGet( "Z846NotaFiscalItemIndicadorValorTotal");
               n846NotaFiscalItemIndicadorValorTotal = (String.IsNullOrEmpty(StringUtil.RTrim( A846NotaFiscalItemIndicadorValorTotal)) ? true : false);
               Z847NotaFiscalItemNumPedido = cgiGet( "Z847NotaFiscalItemNumPedido");
               n847NotaFiscalItemNumPedido = (String.IsNullOrEmpty(StringUtil.RTrim( A847NotaFiscalItemNumPedido)) ? true : false);
               Z848NotaFiscalItemNumItem = cgiGet( "Z848NotaFiscalItemNumItem");
               n848NotaFiscalItemNumItem = (String.IsNullOrEmpty(StringUtil.RTrim( A848NotaFiscalItemNumItem)) ? true : false);
               Z851NotaFiscalItemVendido = cgiGet( "Z851NotaFiscalItemVendido");
               n851NotaFiscalItemVendido = (String.IsNullOrEmpty(StringUtil.RTrim( A851NotaFiscalItemVendido)) ? true : false);
               Z323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z323PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n323PropostaId = ((0==A323PropostaId) ? true : false);
               Z794NotaFiscalId = StringUtil.StrToGuid( cgiGet( "Z794NotaFiscalId"));
               n794NotaFiscalId = ((Guid.Empty==A794NotaFiscalId) ? true : false);
               A831NotaFiscalItemCodigo = cgiGet( "Z831NotaFiscalItemCodigo");
               n831NotaFiscalItemCodigo = false;
               n831NotaFiscalItemCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A831NotaFiscalItemCodigo)) ? true : false);
               A832NotaFiscalItemCFOP = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z832NotaFiscalItemCFOP"), ",", "."), 18, MidpointRounding.ToEven));
               n832NotaFiscalItemCFOP = false;
               n832NotaFiscalItemCFOP = ((0==A832NotaFiscalItemCFOP) ? true : false);
               A833NotaFiscalItemDescricao = cgiGet( "Z833NotaFiscalItemDescricao");
               n833NotaFiscalItemDescricao = false;
               n833NotaFiscalItemDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A833NotaFiscalItemDescricao)) ? true : false);
               A834NotaFiscalItemNCM = cgiGet( "Z834NotaFiscalItemNCM");
               n834NotaFiscalItemNCM = false;
               n834NotaFiscalItemNCM = (String.IsNullOrEmpty(StringUtil.RTrim( A834NotaFiscalItemNCM)) ? true : false);
               A835NotaFiscalItemCodigoEAN = cgiGet( "Z835NotaFiscalItemCodigoEAN");
               n835NotaFiscalItemCodigoEAN = false;
               n835NotaFiscalItemCodigoEAN = (String.IsNullOrEmpty(StringUtil.RTrim( A835NotaFiscalItemCodigoEAN)) ? true : false);
               A836NotaFiscalItemUnidadeComercial = cgiGet( "Z836NotaFiscalItemUnidadeComercial");
               n836NotaFiscalItemUnidadeComercial = false;
               n836NotaFiscalItemUnidadeComercial = (String.IsNullOrEmpty(StringUtil.RTrim( A836NotaFiscalItemUnidadeComercial)) ? true : false);
               A837NotaFiscalItemQuantidade = context.localUtil.CToN( cgiGet( "Z837NotaFiscalItemQuantidade"), ",", ".");
               n837NotaFiscalItemQuantidade = false;
               n837NotaFiscalItemQuantidade = ((Convert.ToDecimal(0)==A837NotaFiscalItemQuantidade) ? true : false);
               A838NotaFiscalItemValorUnitario = context.localUtil.CToN( cgiGet( "Z838NotaFiscalItemValorUnitario"), ",", ".");
               n838NotaFiscalItemValorUnitario = false;
               n838NotaFiscalItemValorUnitario = ((Convert.ToDecimal(0)==A838NotaFiscalItemValorUnitario) ? true : false);
               A839NotaFiscalItemValorTotal = context.localUtil.CToN( cgiGet( "Z839NotaFiscalItemValorTotal"), ",", ".");
               n839NotaFiscalItemValorTotal = false;
               n839NotaFiscalItemValorTotal = ((Convert.ToDecimal(0)==A839NotaFiscalItemValorTotal) ? true : false);
               A840NotaFiscalItemCodBarGTIN = cgiGet( "Z840NotaFiscalItemCodBarGTIN");
               n840NotaFiscalItemCodBarGTIN = false;
               n840NotaFiscalItemCodBarGTIN = (String.IsNullOrEmpty(StringUtil.RTrim( A840NotaFiscalItemCodBarGTIN)) ? true : false);
               A841NotaFiscalItemUnidadeTributavel = cgiGet( "Z841NotaFiscalItemUnidadeTributavel");
               n841NotaFiscalItemUnidadeTributavel = false;
               n841NotaFiscalItemUnidadeTributavel = (String.IsNullOrEmpty(StringUtil.RTrim( A841NotaFiscalItemUnidadeTributavel)) ? true : false);
               A842NotaFiscalItemValorUnTributavel = context.localUtil.CToN( cgiGet( "Z842NotaFiscalItemValorUnTributavel"), ",", ".");
               n842NotaFiscalItemValorUnTributavel = false;
               n842NotaFiscalItemValorUnTributavel = ((Convert.ToDecimal(0)==A842NotaFiscalItemValorUnTributavel) ? true : false);
               A843NotaFiscalItemQtdTributavel = context.localUtil.CToN( cgiGet( "Z843NotaFiscalItemQtdTributavel"), ",", ".");
               n843NotaFiscalItemQtdTributavel = false;
               n843NotaFiscalItemQtdTributavel = ((Convert.ToDecimal(0)==A843NotaFiscalItemQtdTributavel) ? true : false);
               A844NotaFiscalItemValorFrete = context.localUtil.CToN( cgiGet( "Z844NotaFiscalItemValorFrete"), ",", ".");
               n844NotaFiscalItemValorFrete = false;
               n844NotaFiscalItemValorFrete = ((Convert.ToDecimal(0)==A844NotaFiscalItemValorFrete) ? true : false);
               A845NotaFiscalItemDesconto = context.localUtil.CToN( cgiGet( "Z845NotaFiscalItemDesconto"), ",", ".");
               n845NotaFiscalItemDesconto = false;
               n845NotaFiscalItemDesconto = ((Convert.ToDecimal(0)==A845NotaFiscalItemDesconto) ? true : false);
               A846NotaFiscalItemIndicadorValorTotal = cgiGet( "Z846NotaFiscalItemIndicadorValorTotal");
               n846NotaFiscalItemIndicadorValorTotal = false;
               n846NotaFiscalItemIndicadorValorTotal = (String.IsNullOrEmpty(StringUtil.RTrim( A846NotaFiscalItemIndicadorValorTotal)) ? true : false);
               A847NotaFiscalItemNumPedido = cgiGet( "Z847NotaFiscalItemNumPedido");
               n847NotaFiscalItemNumPedido = false;
               n847NotaFiscalItemNumPedido = (String.IsNullOrEmpty(StringUtil.RTrim( A847NotaFiscalItemNumPedido)) ? true : false);
               A848NotaFiscalItemNumItem = cgiGet( "Z848NotaFiscalItemNumItem");
               n848NotaFiscalItemNumItem = false;
               n848NotaFiscalItemNumItem = (String.IsNullOrEmpty(StringUtil.RTrim( A848NotaFiscalItemNumItem)) ? true : false);
               A851NotaFiscalItemVendido = cgiGet( "Z851NotaFiscalItemVendido");
               n851NotaFiscalItemVendido = false;
               n851NotaFiscalItemVendido = (String.IsNullOrEmpty(StringUtil.RTrim( A851NotaFiscalItemVendido)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N323PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n323PropostaId = ((0==A323PropostaId) ? true : false);
               N794NotaFiscalId = StringUtil.StrToGuid( cgiGet( "N794NotaFiscalId"));
               n794NotaFiscalId = ((Guid.Empty==A794NotaFiscalId) ? true : false);
               AV7NotaFiscalItemId = StringUtil.StrToGuid( cgiGet( "vNOTAFISCALITEMID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_PropostaId", StringUtil.LTrimStr( (decimal)(AV11Insert_PropostaId), 9, 0));
               AV12Insert_NotaFiscalId = StringUtil.StrToGuid( cgiGet( "vINSERT_NOTAFISCALID"));
               AssignAttri("", false, "AV12Insert_NotaFiscalId", AV12Insert_NotaFiscalId.ToString());
               A831NotaFiscalItemCodigo = cgiGet( "NOTAFISCALITEMCODIGO");
               n831NotaFiscalItemCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A831NotaFiscalItemCodigo)) ? true : false);
               A832NotaFiscalItemCFOP = (short)(Math.Round(context.localUtil.CToN( cgiGet( "NOTAFISCALITEMCFOP"), ",", "."), 18, MidpointRounding.ToEven));
               n832NotaFiscalItemCFOP = ((0==A832NotaFiscalItemCFOP) ? true : false);
               A833NotaFiscalItemDescricao = cgiGet( "NOTAFISCALITEMDESCRICAO");
               n833NotaFiscalItemDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A833NotaFiscalItemDescricao)) ? true : false);
               A834NotaFiscalItemNCM = cgiGet( "NOTAFISCALITEMNCM");
               n834NotaFiscalItemNCM = (String.IsNullOrEmpty(StringUtil.RTrim( A834NotaFiscalItemNCM)) ? true : false);
               A835NotaFiscalItemCodigoEAN = cgiGet( "NOTAFISCALITEMCODIGOEAN");
               n835NotaFiscalItemCodigoEAN = (String.IsNullOrEmpty(StringUtil.RTrim( A835NotaFiscalItemCodigoEAN)) ? true : false);
               A836NotaFiscalItemUnidadeComercial = cgiGet( "NOTAFISCALITEMUNIDADECOMERCIAL");
               n836NotaFiscalItemUnidadeComercial = (String.IsNullOrEmpty(StringUtil.RTrim( A836NotaFiscalItemUnidadeComercial)) ? true : false);
               A837NotaFiscalItemQuantidade = context.localUtil.CToN( cgiGet( "NOTAFISCALITEMQUANTIDADE"), ",", ".");
               n837NotaFiscalItemQuantidade = ((Convert.ToDecimal(0)==A837NotaFiscalItemQuantidade) ? true : false);
               A838NotaFiscalItemValorUnitario = context.localUtil.CToN( cgiGet( "NOTAFISCALITEMVALORUNITARIO"), ",", ".");
               n838NotaFiscalItemValorUnitario = ((Convert.ToDecimal(0)==A838NotaFiscalItemValorUnitario) ? true : false);
               A839NotaFiscalItemValorTotal = context.localUtil.CToN( cgiGet( "NOTAFISCALITEMVALORTOTAL"), ",", ".");
               n839NotaFiscalItemValorTotal = ((Convert.ToDecimal(0)==A839NotaFiscalItemValorTotal) ? true : false);
               A840NotaFiscalItemCodBarGTIN = cgiGet( "NOTAFISCALITEMCODBARGTIN");
               n840NotaFiscalItemCodBarGTIN = (String.IsNullOrEmpty(StringUtil.RTrim( A840NotaFiscalItemCodBarGTIN)) ? true : false);
               A841NotaFiscalItemUnidadeTributavel = cgiGet( "NOTAFISCALITEMUNIDADETRIBUTAVEL");
               n841NotaFiscalItemUnidadeTributavel = (String.IsNullOrEmpty(StringUtil.RTrim( A841NotaFiscalItemUnidadeTributavel)) ? true : false);
               A842NotaFiscalItemValorUnTributavel = context.localUtil.CToN( cgiGet( "NOTAFISCALITEMVALORUNTRIBUTAVEL"), ",", ".");
               n842NotaFiscalItemValorUnTributavel = ((Convert.ToDecimal(0)==A842NotaFiscalItemValorUnTributavel) ? true : false);
               A843NotaFiscalItemQtdTributavel = context.localUtil.CToN( cgiGet( "NOTAFISCALITEMQTDTRIBUTAVEL"), ",", ".");
               n843NotaFiscalItemQtdTributavel = ((Convert.ToDecimal(0)==A843NotaFiscalItemQtdTributavel) ? true : false);
               A844NotaFiscalItemValorFrete = context.localUtil.CToN( cgiGet( "NOTAFISCALITEMVALORFRETE"), ",", ".");
               n844NotaFiscalItemValorFrete = ((Convert.ToDecimal(0)==A844NotaFiscalItemValorFrete) ? true : false);
               A845NotaFiscalItemDesconto = context.localUtil.CToN( cgiGet( "NOTAFISCALITEMDESCONTO"), ",", ".");
               n845NotaFiscalItemDesconto = ((Convert.ToDecimal(0)==A845NotaFiscalItemDesconto) ? true : false);
               A846NotaFiscalItemIndicadorValorTotal = cgiGet( "NOTAFISCALITEMINDICADORVALORTOTAL");
               n846NotaFiscalItemIndicadorValorTotal = (String.IsNullOrEmpty(StringUtil.RTrim( A846NotaFiscalItemIndicadorValorTotal)) ? true : false);
               A847NotaFiscalItemNumPedido = cgiGet( "NOTAFISCALITEMNUMPEDIDO");
               n847NotaFiscalItemNumPedido = (String.IsNullOrEmpty(StringUtil.RTrim( A847NotaFiscalItemNumPedido)) ? true : false);
               A848NotaFiscalItemNumItem = cgiGet( "NOTAFISCALITEMNUMITEM");
               n848NotaFiscalItemNumItem = (String.IsNullOrEmpty(StringUtil.RTrim( A848NotaFiscalItemNumItem)) ? true : false);
               A851NotaFiscalItemVendido = cgiGet( "NOTAFISCALITEMVENDIDO");
               n851NotaFiscalItemVendido = (String.IsNullOrEmpty(StringUtil.RTrim( A851NotaFiscalItemVendido)) ? true : false);
               AV22Pgmname = cgiGet( "vPGMNAME");
               Combo_propostaid_Objectcall = cgiGet( "COMBO_PROPOSTAID_Objectcall");
               Combo_propostaid_Class = cgiGet( "COMBO_PROPOSTAID_Class");
               Combo_propostaid_Icontype = cgiGet( "COMBO_PROPOSTAID_Icontype");
               Combo_propostaid_Icon = cgiGet( "COMBO_PROPOSTAID_Icon");
               Combo_propostaid_Caption = cgiGet( "COMBO_PROPOSTAID_Caption");
               Combo_propostaid_Tooltip = cgiGet( "COMBO_PROPOSTAID_Tooltip");
               Combo_propostaid_Cls = cgiGet( "COMBO_PROPOSTAID_Cls");
               Combo_propostaid_Selectedvalue_set = cgiGet( "COMBO_PROPOSTAID_Selectedvalue_set");
               Combo_propostaid_Selectedvalue_get = cgiGet( "COMBO_PROPOSTAID_Selectedvalue_get");
               Combo_propostaid_Selectedtext_set = cgiGet( "COMBO_PROPOSTAID_Selectedtext_set");
               Combo_propostaid_Selectedtext_get = cgiGet( "COMBO_PROPOSTAID_Selectedtext_get");
               Combo_propostaid_Gamoauthtoken = cgiGet( "COMBO_PROPOSTAID_Gamoauthtoken");
               Combo_propostaid_Ddointernalname = cgiGet( "COMBO_PROPOSTAID_Ddointernalname");
               Combo_propostaid_Titlecontrolalign = cgiGet( "COMBO_PROPOSTAID_Titlecontrolalign");
               Combo_propostaid_Dropdownoptionstype = cgiGet( "COMBO_PROPOSTAID_Dropdownoptionstype");
               Combo_propostaid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Enabled"));
               Combo_propostaid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Visible"));
               Combo_propostaid_Titlecontrolidtoreplace = cgiGet( "COMBO_PROPOSTAID_Titlecontrolidtoreplace");
               Combo_propostaid_Datalisttype = cgiGet( "COMBO_PROPOSTAID_Datalisttype");
               Combo_propostaid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Allowmultipleselection"));
               Combo_propostaid_Datalistfixedvalues = cgiGet( "COMBO_PROPOSTAID_Datalistfixedvalues");
               Combo_propostaid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Isgriditem"));
               Combo_propostaid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Hasdescription"));
               Combo_propostaid_Datalistproc = cgiGet( "COMBO_PROPOSTAID_Datalistproc");
               Combo_propostaid_Datalistprocparametersprefix = cgiGet( "COMBO_PROPOSTAID_Datalistprocparametersprefix");
               Combo_propostaid_Remoteservicesparameters = cgiGet( "COMBO_PROPOSTAID_Remoteservicesparameters");
               Combo_propostaid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROPOSTAID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_propostaid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Includeonlyselectedoption"));
               Combo_propostaid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Includeselectalloption"));
               Combo_propostaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Emptyitem"));
               Combo_propostaid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Includeaddnewoption"));
               Combo_propostaid_Htmltemplate = cgiGet( "COMBO_PROPOSTAID_Htmltemplate");
               Combo_propostaid_Multiplevaluestype = cgiGet( "COMBO_PROPOSTAID_Multiplevaluestype");
               Combo_propostaid_Loadingdata = cgiGet( "COMBO_PROPOSTAID_Loadingdata");
               Combo_propostaid_Noresultsfound = cgiGet( "COMBO_PROPOSTAID_Noresultsfound");
               Combo_propostaid_Emptyitemtext = cgiGet( "COMBO_PROPOSTAID_Emptyitemtext");
               Combo_propostaid_Onlyselectedvalues = cgiGet( "COMBO_PROPOSTAID_Onlyselectedvalues");
               Combo_propostaid_Selectalltext = cgiGet( "COMBO_PROPOSTAID_Selectalltext");
               Combo_propostaid_Multiplevaluesseparator = cgiGet( "COMBO_PROPOSTAID_Multiplevaluesseparator");
               Combo_propostaid_Addnewoptiontext = cgiGet( "COMBO_PROPOSTAID_Addnewoptiontext");
               Combo_propostaid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROPOSTAID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_notafiscalid_Objectcall = cgiGet( "COMBO_NOTAFISCALID_Objectcall");
               Combo_notafiscalid_Class = cgiGet( "COMBO_NOTAFISCALID_Class");
               Combo_notafiscalid_Icontype = cgiGet( "COMBO_NOTAFISCALID_Icontype");
               Combo_notafiscalid_Icon = cgiGet( "COMBO_NOTAFISCALID_Icon");
               Combo_notafiscalid_Caption = cgiGet( "COMBO_NOTAFISCALID_Caption");
               Combo_notafiscalid_Tooltip = cgiGet( "COMBO_NOTAFISCALID_Tooltip");
               Combo_notafiscalid_Cls = cgiGet( "COMBO_NOTAFISCALID_Cls");
               Combo_notafiscalid_Selectedvalue_set = cgiGet( "COMBO_NOTAFISCALID_Selectedvalue_set");
               Combo_notafiscalid_Selectedvalue_get = cgiGet( "COMBO_NOTAFISCALID_Selectedvalue_get");
               Combo_notafiscalid_Selectedtext_set = cgiGet( "COMBO_NOTAFISCALID_Selectedtext_set");
               Combo_notafiscalid_Selectedtext_get = cgiGet( "COMBO_NOTAFISCALID_Selectedtext_get");
               Combo_notafiscalid_Gamoauthtoken = cgiGet( "COMBO_NOTAFISCALID_Gamoauthtoken");
               Combo_notafiscalid_Ddointernalname = cgiGet( "COMBO_NOTAFISCALID_Ddointernalname");
               Combo_notafiscalid_Titlecontrolalign = cgiGet( "COMBO_NOTAFISCALID_Titlecontrolalign");
               Combo_notafiscalid_Dropdownoptionstype = cgiGet( "COMBO_NOTAFISCALID_Dropdownoptionstype");
               Combo_notafiscalid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_NOTAFISCALID_Enabled"));
               Combo_notafiscalid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_NOTAFISCALID_Visible"));
               Combo_notafiscalid_Titlecontrolidtoreplace = cgiGet( "COMBO_NOTAFISCALID_Titlecontrolidtoreplace");
               Combo_notafiscalid_Datalisttype = cgiGet( "COMBO_NOTAFISCALID_Datalisttype");
               Combo_notafiscalid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_NOTAFISCALID_Allowmultipleselection"));
               Combo_notafiscalid_Datalistfixedvalues = cgiGet( "COMBO_NOTAFISCALID_Datalistfixedvalues");
               Combo_notafiscalid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_NOTAFISCALID_Isgriditem"));
               Combo_notafiscalid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_NOTAFISCALID_Hasdescription"));
               Combo_notafiscalid_Datalistproc = cgiGet( "COMBO_NOTAFISCALID_Datalistproc");
               Combo_notafiscalid_Datalistprocparametersprefix = cgiGet( "COMBO_NOTAFISCALID_Datalistprocparametersprefix");
               Combo_notafiscalid_Remoteservicesparameters = cgiGet( "COMBO_NOTAFISCALID_Remoteservicesparameters");
               Combo_notafiscalid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NOTAFISCALID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_notafiscalid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_NOTAFISCALID_Includeonlyselectedoption"));
               Combo_notafiscalid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_NOTAFISCALID_Includeselectalloption"));
               Combo_notafiscalid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_NOTAFISCALID_Emptyitem"));
               Combo_notafiscalid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_NOTAFISCALID_Includeaddnewoption"));
               Combo_notafiscalid_Htmltemplate = cgiGet( "COMBO_NOTAFISCALID_Htmltemplate");
               Combo_notafiscalid_Multiplevaluestype = cgiGet( "COMBO_NOTAFISCALID_Multiplevaluestype");
               Combo_notafiscalid_Loadingdata = cgiGet( "COMBO_NOTAFISCALID_Loadingdata");
               Combo_notafiscalid_Noresultsfound = cgiGet( "COMBO_NOTAFISCALID_Noresultsfound");
               Combo_notafiscalid_Emptyitemtext = cgiGet( "COMBO_NOTAFISCALID_Emptyitemtext");
               Combo_notafiscalid_Onlyselectedvalues = cgiGet( "COMBO_NOTAFISCALID_Onlyselectedvalues");
               Combo_notafiscalid_Selectalltext = cgiGet( "COMBO_NOTAFISCALID_Selectalltext");
               Combo_notafiscalid_Multiplevaluesseparator = cgiGet( "COMBO_NOTAFISCALID_Multiplevaluesseparator");
               Combo_notafiscalid_Addnewoptiontext = cgiGet( "COMBO_NOTAFISCALID_Addnewoptiontext");
               Combo_notafiscalid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NOTAFISCALID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               if ( StringUtil.StrCmp(cgiGet( edtNotaFiscalItemId_Internalname), "") == 0 )
               {
                  A830NotaFiscalItemId = Guid.Empty;
                  AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
               }
               else
               {
                  try
                  {
                     A830NotaFiscalItemId = StringUtil.StrToGuid( cgiGet( edtNotaFiscalItemId_Internalname));
                     AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "NOTAFISCALITEMID");
                     AnyError = 1;
                     GX_FocusControl = edtNotaFiscalItemId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n323PropostaId = ((StringUtil.StrCmp(cgiGet( edtPropostaId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTAID");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A323PropostaId = 0;
                  n323PropostaId = false;
                  AssignAttri("", false, "A323PropostaId", (n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
               }
               else
               {
                  A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A323PropostaId", (n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
               }
               if ( StringUtil.StrCmp(cgiGet( edtNotaFiscalId_Internalname), "") == 0 )
               {
                  A794NotaFiscalId = Guid.Empty;
                  n794NotaFiscalId = true;
                  AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
               }
               else
               {
                  try
                  {
                     A794NotaFiscalId = StringUtil.StrToGuid( cgiGet( edtNotaFiscalId_Internalname));
                     n794NotaFiscalId = false;
                     AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "NOTAFISCALID");
                     AnyError = 1;
                     GX_FocusControl = edtNotaFiscalId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n794NotaFiscalId = ((Guid.Empty==A794NotaFiscalId) ? true : false);
               AV19ComboPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombopropostaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ComboPropostaId", StringUtil.LTrimStr( (decimal)(AV19ComboPropostaId), 9, 0));
               AV21ComboNotaFiscalId = StringUtil.StrToGuid( cgiGet( edtavCombonotafiscalid_Internalname));
               AssignAttri("", false, "AV21ComboNotaFiscalId", AV21ComboNotaFiscalId.ToString());
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"NotaFiscalItem");
               forbiddenHiddens.Add("Insert_PropostaId", context.localUtil.Format( (decimal)(AV11Insert_PropostaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_NotaFiscalId", AV12Insert_NotaFiscalId.ToString());
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("NotaFiscalItemCodigo", StringUtil.RTrim( context.localUtil.Format( A831NotaFiscalItemCodigo, "")));
               forbiddenHiddens.Add("NotaFiscalItemCFOP", context.localUtil.Format( (decimal)(A832NotaFiscalItemCFOP), "ZZZ9"));
               forbiddenHiddens.Add("NotaFiscalItemDescricao", StringUtil.RTrim( context.localUtil.Format( A833NotaFiscalItemDescricao, "")));
               forbiddenHiddens.Add("NotaFiscalItemNCM", StringUtil.RTrim( context.localUtil.Format( A834NotaFiscalItemNCM, "")));
               forbiddenHiddens.Add("NotaFiscalItemCodigoEAN", StringUtil.RTrim( context.localUtil.Format( A835NotaFiscalItemCodigoEAN, "")));
               forbiddenHiddens.Add("NotaFiscalItemUnidadeComercial", StringUtil.RTrim( context.localUtil.Format( A836NotaFiscalItemUnidadeComercial, "")));
               forbiddenHiddens.Add("NotaFiscalItemQuantidade", context.localUtil.Format( A837NotaFiscalItemQuantidade, "ZZZZZZZZZZ9.999999"));
               forbiddenHiddens.Add("NotaFiscalItemValorUnitario", context.localUtil.Format( A838NotaFiscalItemValorUnitario, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("NotaFiscalItemValorTotal", context.localUtil.Format( A839NotaFiscalItemValorTotal, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("NotaFiscalItemCodBarGTIN", StringUtil.RTrim( context.localUtil.Format( A840NotaFiscalItemCodBarGTIN, "")));
               forbiddenHiddens.Add("NotaFiscalItemUnidadeTributavel", StringUtil.RTrim( context.localUtil.Format( A841NotaFiscalItemUnidadeTributavel, "")));
               forbiddenHiddens.Add("NotaFiscalItemValorUnTributavel", context.localUtil.Format( A842NotaFiscalItemValorUnTributavel, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("NotaFiscalItemQtdTributavel", context.localUtil.Format( A843NotaFiscalItemQtdTributavel, "ZZZZZZZZZZ9.999999"));
               forbiddenHiddens.Add("NotaFiscalItemValorFrete", context.localUtil.Format( A844NotaFiscalItemValorFrete, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("NotaFiscalItemDesconto", context.localUtil.Format( A845NotaFiscalItemDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("NotaFiscalItemIndicadorValorTotal", StringUtil.RTrim( context.localUtil.Format( A846NotaFiscalItemIndicadorValorTotal, "")));
               forbiddenHiddens.Add("NotaFiscalItemNumPedido", StringUtil.RTrim( context.localUtil.Format( A847NotaFiscalItemNumPedido, "")));
               forbiddenHiddens.Add("NotaFiscalItemNumItem", StringUtil.RTrim( context.localUtil.Format( A848NotaFiscalItemNumItem, "")));
               forbiddenHiddens.Add("NotaFiscalItemVendido", StringUtil.RTrim( context.localUtil.Format( A851NotaFiscalItemVendido, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A830NotaFiscalItemId != Z830NotaFiscalItemId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("notafiscalitem:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A830NotaFiscalItemId = StringUtil.StrToGuid( GetPar( "NotaFiscalItemId"));
                  AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7NotaFiscalItemId) )
                  {
                     A830NotaFiscalItemId = AV7NotaFiscalItemId;
                     AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A830NotaFiscalItemId) && ( Gx_BScreen == 0 ) )
                     {
                        A830NotaFiscalItemId = Guid.NewGuid( );
                        AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode94 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7NotaFiscalItemId) )
                     {
                        A830NotaFiscalItemId = AV7NotaFiscalItemId;
                        AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A830NotaFiscalItemId) && ( Gx_BScreen == 0 ) )
                        {
                           A830NotaFiscalItemId = Guid.NewGuid( );
                           AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
                        }
                     }
                     Gx_mode = sMode94;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound94 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2O0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "NOTAFISCALITEMID");
                        AnyError = 1;
                        GX_FocusControl = edtNotaFiscalItemId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_NOTAFISCALID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_notafiscalid.Onoptionclicked */
                           E122O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E112O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E132O2 ();
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
            E132O2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2O94( ) ;
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
            DisableAttributes2O94( ) ;
         }
         AssignProp("", false, edtavCombopropostaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopropostaid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombonotafiscalid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonotafiscalid_Enabled), 5, 0), true);
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

      protected void CONFIRM_2O0( )
      {
         BeforeValidate2O94( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2O94( ) ;
            }
            else
            {
               CheckExtendedTable2O94( ) ;
               CloseExtendedTableCursors2O94( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2O0( )
      {
      }

      protected void E112O2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtNotaFiscalId_Visible = 0;
         AssignProp("", false, edtNotaFiscalId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNotaFiscalId_Visible), 5, 0), true);
         AV21ComboNotaFiscalId = Guid.Empty;
         AssignAttri("", false, "AV21ComboNotaFiscalId", AV21ComboNotaFiscalId.ToString());
         edtavCombonotafiscalid_Visible = 0;
         AssignProp("", false, edtavCombonotafiscalid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombonotafiscalid_Visible), 5, 0), true);
         edtPropostaId_Visible = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPropostaId_Visible), 5, 0), true);
         AV19ComboPropostaId = 0;
         AssignAttri("", false, "AV19ComboPropostaId", StringUtil.LTrimStr( (decimal)(AV19ComboPropostaId), 9, 0));
         edtavCombopropostaid_Visible = 0;
         AssignProp("", false, edtavCombopropostaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombopropostaid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPROPOSTAID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBONOTAFISCALID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            while ( AV23GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaId") == 0 )
               {
                  AV11Insert_PropostaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_PropostaId", StringUtil.LTrimStr( (decimal)(AV11Insert_PropostaId), 9, 0));
                  if ( ! (0==AV11Insert_PropostaId) )
                  {
                     AV19ComboPropostaId = AV11Insert_PropostaId;
                     AssignAttri("", false, "AV19ComboPropostaId", StringUtil.LTrimStr( (decimal)(AV19ComboPropostaId), 9, 0));
                     Combo_propostaid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ComboPropostaId), 9, 0));
                     ucCombo_propostaid.SendProperty(context, "", false, Combo_propostaid_Internalname, "SelectedValue_set", Combo_propostaid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new notafiscalitemloaddvcombo(context ).execute(  "PropostaId",  "GET",  false,  AV7NotaFiscalItemId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_propostaid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_propostaid.SendProperty(context, "", false, Combo_propostaid_Internalname, "SelectedText_set", Combo_propostaid_Selectedtext_set);
                     Combo_propostaid_Enabled = false;
                     ucCombo_propostaid.SendProperty(context, "", false, Combo_propostaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_propostaid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "NotaFiscalId") == 0 )
               {
                  AV12Insert_NotaFiscalId = StringUtil.StrToGuid( AV13TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV12Insert_NotaFiscalId", AV12Insert_NotaFiscalId.ToString());
                  if ( ! (Guid.Empty==AV12Insert_NotaFiscalId) )
                  {
                     AV21ComboNotaFiscalId = AV12Insert_NotaFiscalId;
                     AssignAttri("", false, "AV21ComboNotaFiscalId", AV21ComboNotaFiscalId.ToString());
                     Combo_notafiscalid_Selectedvalue_set = StringUtil.Trim( AV21ComboNotaFiscalId.ToString());
                     ucCombo_notafiscalid.SendProperty(context, "", false, Combo_notafiscalid_Internalname, "SelectedValue_set", Combo_notafiscalid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new notafiscalitemloaddvcombo(context ).execute(  "NotaFiscalId",  "GET",  false,  AV7NotaFiscalItemId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_notafiscalid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_notafiscalid.SendProperty(context, "", false, Combo_notafiscalid_Internalname, "SelectedText_set", Combo_notafiscalid_Selectedtext_set);
                     Combo_notafiscalid_Enabled = false;
                     ucCombo_notafiscalid.SendProperty(context, "", false, Combo_notafiscalid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_notafiscalid_Enabled));
                  }
               }
               AV23GXV1 = (int)(AV23GXV1+1);
               AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            }
         }
      }

      protected void E132O2( )
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

      protected void E122O2( )
      {
         /* Combo_notafiscalid_Onoptionclicked Routine */
         returnInSub = false;
         AV21ComboNotaFiscalId = StringUtil.StrToGuid( Combo_notafiscalid_Selectedvalue_get);
         AssignAttri("", false, "AV21ComboNotaFiscalId", AV21ComboNotaFiscalId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADCOMBONOTAFISCALID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new notafiscalitemloaddvcombo(context ).execute(  "NotaFiscalId",  Gx_mode,  false,  AV7NotaFiscalItemId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_notafiscalid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_notafiscalid.SendProperty(context, "", false, Combo_notafiscalid_Internalname, "SelectedValue_set", Combo_notafiscalid_Selectedvalue_set);
         Combo_notafiscalid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_notafiscalid.SendProperty(context, "", false, Combo_notafiscalid_Internalname, "SelectedText_set", Combo_notafiscalid_Selectedtext_set);
         AV21ComboNotaFiscalId = StringUtil.StrToGuid( AV16ComboSelectedValue);
         AssignAttri("", false, "AV21ComboNotaFiscalId", AV21ComboNotaFiscalId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_notafiscalid_Enabled = false;
            ucCombo_notafiscalid.SendProperty(context, "", false, Combo_notafiscalid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_notafiscalid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPROPOSTAID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new notafiscalitemloaddvcombo(context ).execute(  "PropostaId",  Gx_mode,  false,  AV7NotaFiscalItemId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_propostaid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_propostaid.SendProperty(context, "", false, Combo_propostaid_Internalname, "SelectedValue_set", Combo_propostaid_Selectedvalue_set);
         Combo_propostaid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_propostaid.SendProperty(context, "", false, Combo_propostaid_Internalname, "SelectedText_set", Combo_propostaid_Selectedtext_set);
         AV19ComboPropostaId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV19ComboPropostaId", StringUtil.LTrimStr( (decimal)(AV19ComboPropostaId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_propostaid_Enabled = false;
            ucCombo_propostaid.SendProperty(context, "", false, Combo_propostaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_propostaid_Enabled));
         }
      }

      protected void ZM2O94( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z831NotaFiscalItemCodigo = T002O3_A831NotaFiscalItemCodigo[0];
               Z832NotaFiscalItemCFOP = T002O3_A832NotaFiscalItemCFOP[0];
               Z833NotaFiscalItemDescricao = T002O3_A833NotaFiscalItemDescricao[0];
               Z834NotaFiscalItemNCM = T002O3_A834NotaFiscalItemNCM[0];
               Z835NotaFiscalItemCodigoEAN = T002O3_A835NotaFiscalItemCodigoEAN[0];
               Z836NotaFiscalItemUnidadeComercial = T002O3_A836NotaFiscalItemUnidadeComercial[0];
               Z837NotaFiscalItemQuantidade = T002O3_A837NotaFiscalItemQuantidade[0];
               Z838NotaFiscalItemValorUnitario = T002O3_A838NotaFiscalItemValorUnitario[0];
               Z839NotaFiscalItemValorTotal = T002O3_A839NotaFiscalItemValorTotal[0];
               Z840NotaFiscalItemCodBarGTIN = T002O3_A840NotaFiscalItemCodBarGTIN[0];
               Z841NotaFiscalItemUnidadeTributavel = T002O3_A841NotaFiscalItemUnidadeTributavel[0];
               Z842NotaFiscalItemValorUnTributavel = T002O3_A842NotaFiscalItemValorUnTributavel[0];
               Z843NotaFiscalItemQtdTributavel = T002O3_A843NotaFiscalItemQtdTributavel[0];
               Z844NotaFiscalItemValorFrete = T002O3_A844NotaFiscalItemValorFrete[0];
               Z845NotaFiscalItemDesconto = T002O3_A845NotaFiscalItemDesconto[0];
               Z846NotaFiscalItemIndicadorValorTotal = T002O3_A846NotaFiscalItemIndicadorValorTotal[0];
               Z847NotaFiscalItemNumPedido = T002O3_A847NotaFiscalItemNumPedido[0];
               Z848NotaFiscalItemNumItem = T002O3_A848NotaFiscalItemNumItem[0];
               Z851NotaFiscalItemVendido = T002O3_A851NotaFiscalItemVendido[0];
               Z323PropostaId = T002O3_A323PropostaId[0];
               Z794NotaFiscalId = T002O3_A794NotaFiscalId[0];
            }
            else
            {
               Z831NotaFiscalItemCodigo = A831NotaFiscalItemCodigo;
               Z832NotaFiscalItemCFOP = A832NotaFiscalItemCFOP;
               Z833NotaFiscalItemDescricao = A833NotaFiscalItemDescricao;
               Z834NotaFiscalItemNCM = A834NotaFiscalItemNCM;
               Z835NotaFiscalItemCodigoEAN = A835NotaFiscalItemCodigoEAN;
               Z836NotaFiscalItemUnidadeComercial = A836NotaFiscalItemUnidadeComercial;
               Z837NotaFiscalItemQuantidade = A837NotaFiscalItemQuantidade;
               Z838NotaFiscalItemValorUnitario = A838NotaFiscalItemValorUnitario;
               Z839NotaFiscalItemValorTotal = A839NotaFiscalItemValorTotal;
               Z840NotaFiscalItemCodBarGTIN = A840NotaFiscalItemCodBarGTIN;
               Z841NotaFiscalItemUnidadeTributavel = A841NotaFiscalItemUnidadeTributavel;
               Z842NotaFiscalItemValorUnTributavel = A842NotaFiscalItemValorUnTributavel;
               Z843NotaFiscalItemQtdTributavel = A843NotaFiscalItemQtdTributavel;
               Z844NotaFiscalItemValorFrete = A844NotaFiscalItemValorFrete;
               Z845NotaFiscalItemDesconto = A845NotaFiscalItemDesconto;
               Z846NotaFiscalItemIndicadorValorTotal = A846NotaFiscalItemIndicadorValorTotal;
               Z847NotaFiscalItemNumPedido = A847NotaFiscalItemNumPedido;
               Z848NotaFiscalItemNumItem = A848NotaFiscalItemNumItem;
               Z851NotaFiscalItemVendido = A851NotaFiscalItemVendido;
               Z323PropostaId = A323PropostaId;
               Z794NotaFiscalId = A794NotaFiscalId;
            }
         }
         if ( GX_JID == -14 )
         {
            Z830NotaFiscalItemId = A830NotaFiscalItemId;
            Z831NotaFiscalItemCodigo = A831NotaFiscalItemCodigo;
            Z832NotaFiscalItemCFOP = A832NotaFiscalItemCFOP;
            Z833NotaFiscalItemDescricao = A833NotaFiscalItemDescricao;
            Z834NotaFiscalItemNCM = A834NotaFiscalItemNCM;
            Z835NotaFiscalItemCodigoEAN = A835NotaFiscalItemCodigoEAN;
            Z836NotaFiscalItemUnidadeComercial = A836NotaFiscalItemUnidadeComercial;
            Z837NotaFiscalItemQuantidade = A837NotaFiscalItemQuantidade;
            Z838NotaFiscalItemValorUnitario = A838NotaFiscalItemValorUnitario;
            Z839NotaFiscalItemValorTotal = A839NotaFiscalItemValorTotal;
            Z840NotaFiscalItemCodBarGTIN = A840NotaFiscalItemCodBarGTIN;
            Z841NotaFiscalItemUnidadeTributavel = A841NotaFiscalItemUnidadeTributavel;
            Z842NotaFiscalItemValorUnTributavel = A842NotaFiscalItemValorUnTributavel;
            Z843NotaFiscalItemQtdTributavel = A843NotaFiscalItemQtdTributavel;
            Z844NotaFiscalItemValorFrete = A844NotaFiscalItemValorFrete;
            Z845NotaFiscalItemDesconto = A845NotaFiscalItemDesconto;
            Z846NotaFiscalItemIndicadorValorTotal = A846NotaFiscalItemIndicadorValorTotal;
            Z847NotaFiscalItemNumPedido = A847NotaFiscalItemNumPedido;
            Z848NotaFiscalItemNumItem = A848NotaFiscalItemNumItem;
            Z851NotaFiscalItemVendido = A851NotaFiscalItemVendido;
            Z323PropostaId = A323PropostaId;
            Z794NotaFiscalId = A794NotaFiscalId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV22Pgmname = "NotaFiscalItem";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7NotaFiscalItemId) )
         {
            edtNotaFiscalItemId_Enabled = 0;
            AssignProp("", false, edtNotaFiscalItemId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalItemId_Enabled), 5, 0), true);
         }
         else
         {
            edtNotaFiscalItemId_Enabled = 1;
            AssignProp("", false, edtNotaFiscalItemId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalItemId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7NotaFiscalItemId) )
         {
            edtNotaFiscalItemId_Enabled = 0;
            AssignProp("", false, edtNotaFiscalItemId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalItemId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PropostaId) )
         {
            edtPropostaId_Enabled = 0;
            AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         }
         else
         {
            edtPropostaId_Enabled = 1;
            AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV12Insert_NotaFiscalId) )
         {
            edtNotaFiscalId_Enabled = 0;
            AssignProp("", false, edtNotaFiscalId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalId_Enabled), 5, 0), true);
         }
         else
         {
            edtNotaFiscalId_Enabled = 1;
            AssignProp("", false, edtNotaFiscalId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV12Insert_NotaFiscalId) )
         {
            A794NotaFiscalId = AV12Insert_NotaFiscalId;
            n794NotaFiscalId = false;
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV21ComboNotaFiscalId) )
            {
               A794NotaFiscalId = Guid.Empty;
               n794NotaFiscalId = false;
               AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
               n794NotaFiscalId = true;
               n794NotaFiscalId = true;
               AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV21ComboNotaFiscalId) )
               {
                  A794NotaFiscalId = AV21ComboNotaFiscalId;
                  n794NotaFiscalId = false;
                  AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
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
         if ( ! (Guid.Empty==AV7NotaFiscalItemId) )
         {
            A830NotaFiscalItemId = AV7NotaFiscalItemId;
            AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A830NotaFiscalItemId) && ( Gx_BScreen == 0 ) )
            {
               A830NotaFiscalItemId = Guid.NewGuid( );
               AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load2O94( )
      {
         /* Using cursor T002O6 */
         pr_default.execute(4, new Object[] {A830NotaFiscalItemId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound94 = 1;
            A831NotaFiscalItemCodigo = T002O6_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = T002O6_n831NotaFiscalItemCodigo[0];
            A832NotaFiscalItemCFOP = T002O6_A832NotaFiscalItemCFOP[0];
            n832NotaFiscalItemCFOP = T002O6_n832NotaFiscalItemCFOP[0];
            A833NotaFiscalItemDescricao = T002O6_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = T002O6_n833NotaFiscalItemDescricao[0];
            A834NotaFiscalItemNCM = T002O6_A834NotaFiscalItemNCM[0];
            n834NotaFiscalItemNCM = T002O6_n834NotaFiscalItemNCM[0];
            A835NotaFiscalItemCodigoEAN = T002O6_A835NotaFiscalItemCodigoEAN[0];
            n835NotaFiscalItemCodigoEAN = T002O6_n835NotaFiscalItemCodigoEAN[0];
            A836NotaFiscalItemUnidadeComercial = T002O6_A836NotaFiscalItemUnidadeComercial[0];
            n836NotaFiscalItemUnidadeComercial = T002O6_n836NotaFiscalItemUnidadeComercial[0];
            A837NotaFiscalItemQuantidade = T002O6_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = T002O6_n837NotaFiscalItemQuantidade[0];
            A838NotaFiscalItemValorUnitario = T002O6_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = T002O6_n838NotaFiscalItemValorUnitario[0];
            A839NotaFiscalItemValorTotal = T002O6_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = T002O6_n839NotaFiscalItemValorTotal[0];
            A840NotaFiscalItemCodBarGTIN = T002O6_A840NotaFiscalItemCodBarGTIN[0];
            n840NotaFiscalItemCodBarGTIN = T002O6_n840NotaFiscalItemCodBarGTIN[0];
            A841NotaFiscalItemUnidadeTributavel = T002O6_A841NotaFiscalItemUnidadeTributavel[0];
            n841NotaFiscalItemUnidadeTributavel = T002O6_n841NotaFiscalItemUnidadeTributavel[0];
            A842NotaFiscalItemValorUnTributavel = T002O6_A842NotaFiscalItemValorUnTributavel[0];
            n842NotaFiscalItemValorUnTributavel = T002O6_n842NotaFiscalItemValorUnTributavel[0];
            A843NotaFiscalItemQtdTributavel = T002O6_A843NotaFiscalItemQtdTributavel[0];
            n843NotaFiscalItemQtdTributavel = T002O6_n843NotaFiscalItemQtdTributavel[0];
            A844NotaFiscalItemValorFrete = T002O6_A844NotaFiscalItemValorFrete[0];
            n844NotaFiscalItemValorFrete = T002O6_n844NotaFiscalItemValorFrete[0];
            A845NotaFiscalItemDesconto = T002O6_A845NotaFiscalItemDesconto[0];
            n845NotaFiscalItemDesconto = T002O6_n845NotaFiscalItemDesconto[0];
            A846NotaFiscalItemIndicadorValorTotal = T002O6_A846NotaFiscalItemIndicadorValorTotal[0];
            n846NotaFiscalItemIndicadorValorTotal = T002O6_n846NotaFiscalItemIndicadorValorTotal[0];
            A847NotaFiscalItemNumPedido = T002O6_A847NotaFiscalItemNumPedido[0];
            n847NotaFiscalItemNumPedido = T002O6_n847NotaFiscalItemNumPedido[0];
            A848NotaFiscalItemNumItem = T002O6_A848NotaFiscalItemNumItem[0];
            n848NotaFiscalItemNumItem = T002O6_n848NotaFiscalItemNumItem[0];
            A851NotaFiscalItemVendido = T002O6_A851NotaFiscalItemVendido[0];
            n851NotaFiscalItemVendido = T002O6_n851NotaFiscalItemVendido[0];
            A323PropostaId = T002O6_A323PropostaId[0];
            n323PropostaId = T002O6_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            A794NotaFiscalId = T002O6_A794NotaFiscalId[0];
            n794NotaFiscalId = T002O6_n794NotaFiscalId[0];
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            ZM2O94( -14) ;
         }
         pr_default.close(4);
         OnLoadActions2O94( ) ;
      }

      protected void OnLoadActions2O94( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PropostaId) )
         {
            A323PropostaId = AV11Insert_PropostaId;
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboPropostaId) )
            {
               A323PropostaId = 0;
               n323PropostaId = false;
               AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
               n323PropostaId = true;
               n323PropostaId = true;
               AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboPropostaId) )
               {
                  A323PropostaId = AV19ComboPropostaId;
                  n323PropostaId = false;
                  AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A323PropostaId) )
                  {
                     A323PropostaId = 0;
                     n323PropostaId = false;
                     AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
                     n323PropostaId = true;
                     n323PropostaId = true;
                     AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
                  }
               }
            }
         }
      }

      protected void CheckExtendedTable2O94( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PropostaId) )
         {
            A323PropostaId = AV11Insert_PropostaId;
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboPropostaId) )
            {
               A323PropostaId = 0;
               n323PropostaId = false;
               AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
               n323PropostaId = true;
               n323PropostaId = true;
               AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboPropostaId) )
               {
                  A323PropostaId = AV19ComboPropostaId;
                  n323PropostaId = false;
                  AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A323PropostaId) )
                  {
                     A323PropostaId = 0;
                     n323PropostaId = false;
                     AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
                     n323PropostaId = true;
                     n323PropostaId = true;
                     AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
                  }
               }
            }
         }
         /* Using cursor T002O4 */
         pr_default.execute(2, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         /* Using cursor T002O5 */
         pr_default.execute(3, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
               GX_FocusControl = edtNotaFiscalId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2O94( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( int A323PropostaId )
      {
         /* Using cursor T002O7 */
         pr_default.execute(5, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaId_Internalname;
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

      protected void gxLoad_16( Guid A794NotaFiscalId )
      {
         /* Using cursor T002O8 */
         pr_default.execute(6, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
               GX_FocusControl = edtNotaFiscalId_Internalname;
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

      protected void GetKey2O94( )
      {
         /* Using cursor T002O9 */
         pr_default.execute(7, new Object[] {A830NotaFiscalItemId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound94 = 1;
         }
         else
         {
            RcdFound94 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002O3 */
         pr_default.execute(1, new Object[] {A830NotaFiscalItemId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2O94( 14) ;
            RcdFound94 = 1;
            A830NotaFiscalItemId = T002O3_A830NotaFiscalItemId[0];
            AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
            A831NotaFiscalItemCodigo = T002O3_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = T002O3_n831NotaFiscalItemCodigo[0];
            A832NotaFiscalItemCFOP = T002O3_A832NotaFiscalItemCFOP[0];
            n832NotaFiscalItemCFOP = T002O3_n832NotaFiscalItemCFOP[0];
            A833NotaFiscalItemDescricao = T002O3_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = T002O3_n833NotaFiscalItemDescricao[0];
            A834NotaFiscalItemNCM = T002O3_A834NotaFiscalItemNCM[0];
            n834NotaFiscalItemNCM = T002O3_n834NotaFiscalItemNCM[0];
            A835NotaFiscalItemCodigoEAN = T002O3_A835NotaFiscalItemCodigoEAN[0];
            n835NotaFiscalItemCodigoEAN = T002O3_n835NotaFiscalItemCodigoEAN[0];
            A836NotaFiscalItemUnidadeComercial = T002O3_A836NotaFiscalItemUnidadeComercial[0];
            n836NotaFiscalItemUnidadeComercial = T002O3_n836NotaFiscalItemUnidadeComercial[0];
            A837NotaFiscalItemQuantidade = T002O3_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = T002O3_n837NotaFiscalItemQuantidade[0];
            A838NotaFiscalItemValorUnitario = T002O3_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = T002O3_n838NotaFiscalItemValorUnitario[0];
            A839NotaFiscalItemValorTotal = T002O3_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = T002O3_n839NotaFiscalItemValorTotal[0];
            A840NotaFiscalItemCodBarGTIN = T002O3_A840NotaFiscalItemCodBarGTIN[0];
            n840NotaFiscalItemCodBarGTIN = T002O3_n840NotaFiscalItemCodBarGTIN[0];
            A841NotaFiscalItemUnidadeTributavel = T002O3_A841NotaFiscalItemUnidadeTributavel[0];
            n841NotaFiscalItemUnidadeTributavel = T002O3_n841NotaFiscalItemUnidadeTributavel[0];
            A842NotaFiscalItemValorUnTributavel = T002O3_A842NotaFiscalItemValorUnTributavel[0];
            n842NotaFiscalItemValorUnTributavel = T002O3_n842NotaFiscalItemValorUnTributavel[0];
            A843NotaFiscalItemQtdTributavel = T002O3_A843NotaFiscalItemQtdTributavel[0];
            n843NotaFiscalItemQtdTributavel = T002O3_n843NotaFiscalItemQtdTributavel[0];
            A844NotaFiscalItemValorFrete = T002O3_A844NotaFiscalItemValorFrete[0];
            n844NotaFiscalItemValorFrete = T002O3_n844NotaFiscalItemValorFrete[0];
            A845NotaFiscalItemDesconto = T002O3_A845NotaFiscalItemDesconto[0];
            n845NotaFiscalItemDesconto = T002O3_n845NotaFiscalItemDesconto[0];
            A846NotaFiscalItemIndicadorValorTotal = T002O3_A846NotaFiscalItemIndicadorValorTotal[0];
            n846NotaFiscalItemIndicadorValorTotal = T002O3_n846NotaFiscalItemIndicadorValorTotal[0];
            A847NotaFiscalItemNumPedido = T002O3_A847NotaFiscalItemNumPedido[0];
            n847NotaFiscalItemNumPedido = T002O3_n847NotaFiscalItemNumPedido[0];
            A848NotaFiscalItemNumItem = T002O3_A848NotaFiscalItemNumItem[0];
            n848NotaFiscalItemNumItem = T002O3_n848NotaFiscalItemNumItem[0];
            A851NotaFiscalItemVendido = T002O3_A851NotaFiscalItemVendido[0];
            n851NotaFiscalItemVendido = T002O3_n851NotaFiscalItemVendido[0];
            A323PropostaId = T002O3_A323PropostaId[0];
            n323PropostaId = T002O3_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            A794NotaFiscalId = T002O3_A794NotaFiscalId[0];
            n794NotaFiscalId = T002O3_n794NotaFiscalId[0];
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            Z830NotaFiscalItemId = A830NotaFiscalItemId;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2O94( ) ;
            if ( AnyError == 1 )
            {
               RcdFound94 = 0;
               InitializeNonKey2O94( ) ;
            }
            Gx_mode = sMode94;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound94 = 0;
            InitializeNonKey2O94( ) ;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode94;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2O94( ) ;
         if ( RcdFound94 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound94 = 0;
         /* Using cursor T002O10 */
         pr_default.execute(8, new Object[] {A830NotaFiscalItemId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T002O10_A830NotaFiscalItemId[0], A830NotaFiscalItemId, 0) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T002O10_A830NotaFiscalItemId[0], A830NotaFiscalItemId, 0) > 0 ) ) )
            {
               A830NotaFiscalItemId = T002O10_A830NotaFiscalItemId[0];
               AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
               RcdFound94 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound94 = 0;
         /* Using cursor T002O11 */
         pr_default.execute(9, new Object[] {A830NotaFiscalItemId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T002O11_A830NotaFiscalItemId[0], A830NotaFiscalItemId, 0) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T002O11_A830NotaFiscalItemId[0], A830NotaFiscalItemId, 0) < 0 ) ) )
            {
               A830NotaFiscalItemId = T002O11_A830NotaFiscalItemId[0];
               AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
               RcdFound94 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2O94( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNotaFiscalItemId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2O94( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound94 == 1 )
            {
               if ( A830NotaFiscalItemId != Z830NotaFiscalItemId )
               {
                  A830NotaFiscalItemId = Z830NotaFiscalItemId;
                  AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "NOTAFISCALITEMID");
                  AnyError = 1;
                  GX_FocusControl = edtNotaFiscalItemId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNotaFiscalItemId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2O94( ) ;
                  GX_FocusControl = edtNotaFiscalItemId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A830NotaFiscalItemId != Z830NotaFiscalItemId )
               {
                  /* Insert record */
                  GX_FocusControl = edtNotaFiscalItemId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2O94( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "NOTAFISCALITEMID");
                     AnyError = 1;
                     GX_FocusControl = edtNotaFiscalItemId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtNotaFiscalItemId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2O94( ) ;
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
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A830NotaFiscalItemId != Z830NotaFiscalItemId )
         {
            A830NotaFiscalItemId = Z830NotaFiscalItemId;
            AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "NOTAFISCALITEMID");
            AnyError = 1;
            GX_FocusControl = edtNotaFiscalItemId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNotaFiscalItemId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2O94( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002O2 */
            pr_default.execute(0, new Object[] {A830NotaFiscalItemId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscalItem"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z831NotaFiscalItemCodigo, T002O2_A831NotaFiscalItemCodigo[0]) != 0 ) || ( Z832NotaFiscalItemCFOP != T002O2_A832NotaFiscalItemCFOP[0] ) || ( StringUtil.StrCmp(Z833NotaFiscalItemDescricao, T002O2_A833NotaFiscalItemDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z834NotaFiscalItemNCM, T002O2_A834NotaFiscalItemNCM[0]) != 0 ) || ( StringUtil.StrCmp(Z835NotaFiscalItemCodigoEAN, T002O2_A835NotaFiscalItemCodigoEAN[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z836NotaFiscalItemUnidadeComercial, T002O2_A836NotaFiscalItemUnidadeComercial[0]) != 0 ) || ( Z837NotaFiscalItemQuantidade != T002O2_A837NotaFiscalItemQuantidade[0] ) || ( Z838NotaFiscalItemValorUnitario != T002O2_A838NotaFiscalItemValorUnitario[0] ) || ( Z839NotaFiscalItemValorTotal != T002O2_A839NotaFiscalItemValorTotal[0] ) || ( StringUtil.StrCmp(Z840NotaFiscalItemCodBarGTIN, T002O2_A840NotaFiscalItemCodBarGTIN[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z841NotaFiscalItemUnidadeTributavel, T002O2_A841NotaFiscalItemUnidadeTributavel[0]) != 0 ) || ( Z842NotaFiscalItemValorUnTributavel != T002O2_A842NotaFiscalItemValorUnTributavel[0] ) || ( Z843NotaFiscalItemQtdTributavel != T002O2_A843NotaFiscalItemQtdTributavel[0] ) || ( Z844NotaFiscalItemValorFrete != T002O2_A844NotaFiscalItemValorFrete[0] ) || ( Z845NotaFiscalItemDesconto != T002O2_A845NotaFiscalItemDesconto[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z846NotaFiscalItemIndicadorValorTotal, T002O2_A846NotaFiscalItemIndicadorValorTotal[0]) != 0 ) || ( StringUtil.StrCmp(Z847NotaFiscalItemNumPedido, T002O2_A847NotaFiscalItemNumPedido[0]) != 0 ) || ( StringUtil.StrCmp(Z848NotaFiscalItemNumItem, T002O2_A848NotaFiscalItemNumItem[0]) != 0 ) || ( StringUtil.StrCmp(Z851NotaFiscalItemVendido, T002O2_A851NotaFiscalItemVendido[0]) != 0 ) || ( Z323PropostaId != T002O2_A323PropostaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z794NotaFiscalId != T002O2_A794NotaFiscalId[0] ) )
            {
               if ( StringUtil.StrCmp(Z831NotaFiscalItemCodigo, T002O2_A831NotaFiscalItemCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z831NotaFiscalItemCodigo);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A831NotaFiscalItemCodigo[0]);
               }
               if ( Z832NotaFiscalItemCFOP != T002O2_A832NotaFiscalItemCFOP[0] )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemCFOP");
                  GXUtil.WriteLogRaw("Old: ",Z832NotaFiscalItemCFOP);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A832NotaFiscalItemCFOP[0]);
               }
               if ( StringUtil.StrCmp(Z833NotaFiscalItemDescricao, T002O2_A833NotaFiscalItemDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z833NotaFiscalItemDescricao);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A833NotaFiscalItemDescricao[0]);
               }
               if ( StringUtil.StrCmp(Z834NotaFiscalItemNCM, T002O2_A834NotaFiscalItemNCM[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemNCM");
                  GXUtil.WriteLogRaw("Old: ",Z834NotaFiscalItemNCM);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A834NotaFiscalItemNCM[0]);
               }
               if ( StringUtil.StrCmp(Z835NotaFiscalItemCodigoEAN, T002O2_A835NotaFiscalItemCodigoEAN[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemCodigoEAN");
                  GXUtil.WriteLogRaw("Old: ",Z835NotaFiscalItemCodigoEAN);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A835NotaFiscalItemCodigoEAN[0]);
               }
               if ( StringUtil.StrCmp(Z836NotaFiscalItemUnidadeComercial, T002O2_A836NotaFiscalItemUnidadeComercial[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemUnidadeComercial");
                  GXUtil.WriteLogRaw("Old: ",Z836NotaFiscalItemUnidadeComercial);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A836NotaFiscalItemUnidadeComercial[0]);
               }
               if ( Z837NotaFiscalItemQuantidade != T002O2_A837NotaFiscalItemQuantidade[0] )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemQuantidade");
                  GXUtil.WriteLogRaw("Old: ",Z837NotaFiscalItemQuantidade);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A837NotaFiscalItemQuantidade[0]);
               }
               if ( Z838NotaFiscalItemValorUnitario != T002O2_A838NotaFiscalItemValorUnitario[0] )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemValorUnitario");
                  GXUtil.WriteLogRaw("Old: ",Z838NotaFiscalItemValorUnitario);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A838NotaFiscalItemValorUnitario[0]);
               }
               if ( Z839NotaFiscalItemValorTotal != T002O2_A839NotaFiscalItemValorTotal[0] )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemValorTotal");
                  GXUtil.WriteLogRaw("Old: ",Z839NotaFiscalItemValorTotal);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A839NotaFiscalItemValorTotal[0]);
               }
               if ( StringUtil.StrCmp(Z840NotaFiscalItemCodBarGTIN, T002O2_A840NotaFiscalItemCodBarGTIN[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemCodBarGTIN");
                  GXUtil.WriteLogRaw("Old: ",Z840NotaFiscalItemCodBarGTIN);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A840NotaFiscalItemCodBarGTIN[0]);
               }
               if ( StringUtil.StrCmp(Z841NotaFiscalItemUnidadeTributavel, T002O2_A841NotaFiscalItemUnidadeTributavel[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemUnidadeTributavel");
                  GXUtil.WriteLogRaw("Old: ",Z841NotaFiscalItemUnidadeTributavel);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A841NotaFiscalItemUnidadeTributavel[0]);
               }
               if ( Z842NotaFiscalItemValorUnTributavel != T002O2_A842NotaFiscalItemValorUnTributavel[0] )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemValorUnTributavel");
                  GXUtil.WriteLogRaw("Old: ",Z842NotaFiscalItemValorUnTributavel);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A842NotaFiscalItemValorUnTributavel[0]);
               }
               if ( Z843NotaFiscalItemQtdTributavel != T002O2_A843NotaFiscalItemQtdTributavel[0] )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemQtdTributavel");
                  GXUtil.WriteLogRaw("Old: ",Z843NotaFiscalItemQtdTributavel);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A843NotaFiscalItemQtdTributavel[0]);
               }
               if ( Z844NotaFiscalItemValorFrete != T002O2_A844NotaFiscalItemValorFrete[0] )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemValorFrete");
                  GXUtil.WriteLogRaw("Old: ",Z844NotaFiscalItemValorFrete);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A844NotaFiscalItemValorFrete[0]);
               }
               if ( Z845NotaFiscalItemDesconto != T002O2_A845NotaFiscalItemDesconto[0] )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemDesconto");
                  GXUtil.WriteLogRaw("Old: ",Z845NotaFiscalItemDesconto);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A845NotaFiscalItemDesconto[0]);
               }
               if ( StringUtil.StrCmp(Z846NotaFiscalItemIndicadorValorTotal, T002O2_A846NotaFiscalItemIndicadorValorTotal[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemIndicadorValorTotal");
                  GXUtil.WriteLogRaw("Old: ",Z846NotaFiscalItemIndicadorValorTotal);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A846NotaFiscalItemIndicadorValorTotal[0]);
               }
               if ( StringUtil.StrCmp(Z847NotaFiscalItemNumPedido, T002O2_A847NotaFiscalItemNumPedido[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemNumPedido");
                  GXUtil.WriteLogRaw("Old: ",Z847NotaFiscalItemNumPedido);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A847NotaFiscalItemNumPedido[0]);
               }
               if ( StringUtil.StrCmp(Z848NotaFiscalItemNumItem, T002O2_A848NotaFiscalItemNumItem[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemNumItem");
                  GXUtil.WriteLogRaw("Old: ",Z848NotaFiscalItemNumItem);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A848NotaFiscalItemNumItem[0]);
               }
               if ( StringUtil.StrCmp(Z851NotaFiscalItemVendido, T002O2_A851NotaFiscalItemVendido[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalItemVendido");
                  GXUtil.WriteLogRaw("Old: ",Z851NotaFiscalItemVendido);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A851NotaFiscalItemVendido[0]);
               }
               if ( Z323PropostaId != T002O2_A323PropostaId[0] )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"PropostaId");
                  GXUtil.WriteLogRaw("Old: ",Z323PropostaId);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A323PropostaId[0]);
               }
               if ( Z794NotaFiscalId != T002O2_A794NotaFiscalId[0] )
               {
                  GXUtil.WriteLog("notafiscalitem:[seudo value changed for attri]"+"NotaFiscalId");
                  GXUtil.WriteLogRaw("Old: ",Z794NotaFiscalId);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A794NotaFiscalId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotaFiscalItem"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2O94( )
      {
         BeforeValidate2O94( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2O94( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2O94( 0) ;
            CheckOptimisticConcurrency2O94( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2O94( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2O94( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002O12 */
                     pr_default.execute(10, new Object[] {A830NotaFiscalItemId, n831NotaFiscalItemCodigo, A831NotaFiscalItemCodigo, n832NotaFiscalItemCFOP, A832NotaFiscalItemCFOP, n833NotaFiscalItemDescricao, A833NotaFiscalItemDescricao, n834NotaFiscalItemNCM, A834NotaFiscalItemNCM, n835NotaFiscalItemCodigoEAN, A835NotaFiscalItemCodigoEAN, n836NotaFiscalItemUnidadeComercial, A836NotaFiscalItemUnidadeComercial, n837NotaFiscalItemQuantidade, A837NotaFiscalItemQuantidade, n838NotaFiscalItemValorUnitario, A838NotaFiscalItemValorUnitario, n839NotaFiscalItemValorTotal, A839NotaFiscalItemValorTotal, n840NotaFiscalItemCodBarGTIN, A840NotaFiscalItemCodBarGTIN, n841NotaFiscalItemUnidadeTributavel, A841NotaFiscalItemUnidadeTributavel, n842NotaFiscalItemValorUnTributavel, A842NotaFiscalItemValorUnTributavel, n843NotaFiscalItemQtdTributavel, A843NotaFiscalItemQtdTributavel, n844NotaFiscalItemValorFrete, A844NotaFiscalItemValorFrete, n845NotaFiscalItemDesconto, A845NotaFiscalItemDesconto, n846NotaFiscalItemIndicadorValorTotal, A846NotaFiscalItemIndicadorValorTotal, n847NotaFiscalItemNumPedido, A847NotaFiscalItemNumPedido, n848NotaFiscalItemNumItem, A848NotaFiscalItemNumItem, n851NotaFiscalItemVendido, A851NotaFiscalItemVendido, n323PropostaId, A323PropostaId, n794NotaFiscalId, A794NotaFiscalId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("NotaFiscalItem");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
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
            else
            {
               Load2O94( ) ;
            }
            EndLevel2O94( ) ;
         }
         CloseExtendedTableCursors2O94( ) ;
      }

      protected void Update2O94( )
      {
         BeforeValidate2O94( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2O94( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2O94( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2O94( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2O94( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002O13 */
                     pr_default.execute(11, new Object[] {n831NotaFiscalItemCodigo, A831NotaFiscalItemCodigo, n832NotaFiscalItemCFOP, A832NotaFiscalItemCFOP, n833NotaFiscalItemDescricao, A833NotaFiscalItemDescricao, n834NotaFiscalItemNCM, A834NotaFiscalItemNCM, n835NotaFiscalItemCodigoEAN, A835NotaFiscalItemCodigoEAN, n836NotaFiscalItemUnidadeComercial, A836NotaFiscalItemUnidadeComercial, n837NotaFiscalItemQuantidade, A837NotaFiscalItemQuantidade, n838NotaFiscalItemValorUnitario, A838NotaFiscalItemValorUnitario, n839NotaFiscalItemValorTotal, A839NotaFiscalItemValorTotal, n840NotaFiscalItemCodBarGTIN, A840NotaFiscalItemCodBarGTIN, n841NotaFiscalItemUnidadeTributavel, A841NotaFiscalItemUnidadeTributavel, n842NotaFiscalItemValorUnTributavel, A842NotaFiscalItemValorUnTributavel, n843NotaFiscalItemQtdTributavel, A843NotaFiscalItemQtdTributavel, n844NotaFiscalItemValorFrete, A844NotaFiscalItemValorFrete, n845NotaFiscalItemDesconto, A845NotaFiscalItemDesconto, n846NotaFiscalItemIndicadorValorTotal, A846NotaFiscalItemIndicadorValorTotal, n847NotaFiscalItemNumPedido, A847NotaFiscalItemNumPedido, n848NotaFiscalItemNumItem, A848NotaFiscalItemNumItem, n851NotaFiscalItemVendido, A851NotaFiscalItemVendido, n323PropostaId, A323PropostaId, n794NotaFiscalId, A794NotaFiscalId, A830NotaFiscalItemId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("NotaFiscalItem");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscalItem"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2O94( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
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
            EndLevel2O94( ) ;
         }
         CloseExtendedTableCursors2O94( ) ;
      }

      protected void DeferredUpdate2O94( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2O94( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2O94( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2O94( ) ;
            AfterConfirm2O94( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2O94( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002O14 */
                  pr_default.execute(12, new Object[] {A830NotaFiscalItemId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("NotaFiscalItem");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
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
         sMode94 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2O94( ) ;
         Gx_mode = sMode94;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2O94( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2O94( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2O94( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2O0( ) ;
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

      public void ScanStart2O94( )
      {
         /* Scan By routine */
         /* Using cursor T002O15 */
         pr_default.execute(13);
         RcdFound94 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound94 = 1;
            A830NotaFiscalItemId = T002O15_A830NotaFiscalItemId[0];
            AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2O94( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound94 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound94 = 1;
            A830NotaFiscalItemId = T002O15_A830NotaFiscalItemId[0];
            AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
         }
      }

      protected void ScanEnd2O94( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm2O94( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2O94( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2O94( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2O94( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2O94( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2O94( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2O94( )
      {
         edtNotaFiscalItemId_Enabled = 0;
         AssignProp("", false, edtNotaFiscalItemId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalItemId_Enabled), 5, 0), true);
         edtPropostaId_Enabled = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         edtNotaFiscalId_Enabled = 0;
         AssignProp("", false, edtNotaFiscalId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalId_Enabled), 5, 0), true);
         edtavCombopropostaid_Enabled = 0;
         AssignProp("", false, edtavCombopropostaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopropostaid_Enabled), 5, 0), true);
         edtavCombonotafiscalid_Enabled = 0;
         AssignProp("", false, edtavCombonotafiscalid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonotafiscalid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2O94( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2O0( )
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
         GXEncryptionTmp = "notafiscalitem"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7NotaFiscalItemId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("notafiscalitem") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"NotaFiscalItem");
         forbiddenHiddens.Add("Insert_PropostaId", context.localUtil.Format( (decimal)(AV11Insert_PropostaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_NotaFiscalId", AV12Insert_NotaFiscalId.ToString());
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("NotaFiscalItemCodigo", StringUtil.RTrim( context.localUtil.Format( A831NotaFiscalItemCodigo, "")));
         forbiddenHiddens.Add("NotaFiscalItemCFOP", context.localUtil.Format( (decimal)(A832NotaFiscalItemCFOP), "ZZZ9"));
         forbiddenHiddens.Add("NotaFiscalItemDescricao", StringUtil.RTrim( context.localUtil.Format( A833NotaFiscalItemDescricao, "")));
         forbiddenHiddens.Add("NotaFiscalItemNCM", StringUtil.RTrim( context.localUtil.Format( A834NotaFiscalItemNCM, "")));
         forbiddenHiddens.Add("NotaFiscalItemCodigoEAN", StringUtil.RTrim( context.localUtil.Format( A835NotaFiscalItemCodigoEAN, "")));
         forbiddenHiddens.Add("NotaFiscalItemUnidadeComercial", StringUtil.RTrim( context.localUtil.Format( A836NotaFiscalItemUnidadeComercial, "")));
         forbiddenHiddens.Add("NotaFiscalItemQuantidade", context.localUtil.Format( A837NotaFiscalItemQuantidade, "ZZZZZZZZZZ9.999999"));
         forbiddenHiddens.Add("NotaFiscalItemValorUnitario", context.localUtil.Format( A838NotaFiscalItemValorUnitario, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("NotaFiscalItemValorTotal", context.localUtil.Format( A839NotaFiscalItemValorTotal, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("NotaFiscalItemCodBarGTIN", StringUtil.RTrim( context.localUtil.Format( A840NotaFiscalItemCodBarGTIN, "")));
         forbiddenHiddens.Add("NotaFiscalItemUnidadeTributavel", StringUtil.RTrim( context.localUtil.Format( A841NotaFiscalItemUnidadeTributavel, "")));
         forbiddenHiddens.Add("NotaFiscalItemValorUnTributavel", context.localUtil.Format( A842NotaFiscalItemValorUnTributavel, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("NotaFiscalItemQtdTributavel", context.localUtil.Format( A843NotaFiscalItemQtdTributavel, "ZZZZZZZZZZ9.999999"));
         forbiddenHiddens.Add("NotaFiscalItemValorFrete", context.localUtil.Format( A844NotaFiscalItemValorFrete, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("NotaFiscalItemDesconto", context.localUtil.Format( A845NotaFiscalItemDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("NotaFiscalItemIndicadorValorTotal", StringUtil.RTrim( context.localUtil.Format( A846NotaFiscalItemIndicadorValorTotal, "")));
         forbiddenHiddens.Add("NotaFiscalItemNumPedido", StringUtil.RTrim( context.localUtil.Format( A847NotaFiscalItemNumPedido, "")));
         forbiddenHiddens.Add("NotaFiscalItemNumItem", StringUtil.RTrim( context.localUtil.Format( A848NotaFiscalItemNumItem, "")));
         forbiddenHiddens.Add("NotaFiscalItemVendido", StringUtil.RTrim( context.localUtil.Format( A851NotaFiscalItemVendido, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("notafiscalitem:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z830NotaFiscalItemId", Z830NotaFiscalItemId.ToString());
         GxWebStd.gx_hidden_field( context, "Z831NotaFiscalItemCodigo", Z831NotaFiscalItemCodigo);
         GxWebStd.gx_hidden_field( context, "Z832NotaFiscalItemCFOP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z832NotaFiscalItemCFOP), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z833NotaFiscalItemDescricao", Z833NotaFiscalItemDescricao);
         GxWebStd.gx_hidden_field( context, "Z834NotaFiscalItemNCM", Z834NotaFiscalItemNCM);
         GxWebStd.gx_hidden_field( context, "Z835NotaFiscalItemCodigoEAN", Z835NotaFiscalItemCodigoEAN);
         GxWebStd.gx_hidden_field( context, "Z836NotaFiscalItemUnidadeComercial", Z836NotaFiscalItemUnidadeComercial);
         GxWebStd.gx_hidden_field( context, "Z837NotaFiscalItemQuantidade", StringUtil.LTrim( StringUtil.NToC( Z837NotaFiscalItemQuantidade, 18, 6, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z838NotaFiscalItemValorUnitario", StringUtil.LTrim( StringUtil.NToC( Z838NotaFiscalItemValorUnitario, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z839NotaFiscalItemValorTotal", StringUtil.LTrim( StringUtil.NToC( Z839NotaFiscalItemValorTotal, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z840NotaFiscalItemCodBarGTIN", Z840NotaFiscalItemCodBarGTIN);
         GxWebStd.gx_hidden_field( context, "Z841NotaFiscalItemUnidadeTributavel", Z841NotaFiscalItemUnidadeTributavel);
         GxWebStd.gx_hidden_field( context, "Z842NotaFiscalItemValorUnTributavel", StringUtil.LTrim( StringUtil.NToC( Z842NotaFiscalItemValorUnTributavel, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z843NotaFiscalItemQtdTributavel", StringUtil.LTrim( StringUtil.NToC( Z843NotaFiscalItemQtdTributavel, 18, 6, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z844NotaFiscalItemValorFrete", StringUtil.LTrim( StringUtil.NToC( Z844NotaFiscalItemValorFrete, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z845NotaFiscalItemDesconto", StringUtil.LTrim( StringUtil.NToC( Z845NotaFiscalItemDesconto, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z846NotaFiscalItemIndicadorValorTotal", Z846NotaFiscalItemIndicadorValorTotal);
         GxWebStd.gx_hidden_field( context, "Z847NotaFiscalItemNumPedido", Z847NotaFiscalItemNumPedido);
         GxWebStd.gx_hidden_field( context, "Z848NotaFiscalItemNumItem", Z848NotaFiscalItemNumItem);
         GxWebStd.gx_hidden_field( context, "Z851NotaFiscalItemVendido", Z851NotaFiscalItemVendido);
         GxWebStd.gx_hidden_field( context, "Z323PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z794NotaFiscalId", Z794NotaFiscalId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N323PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N794NotaFiscalId", A794NotaFiscalId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROPOSTAID_DATA", AV14PropostaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROPOSTAID_DATA", AV14PropostaId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTAFISCALID_DATA", AV20NotaFiscalId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTAFISCALID_DATA", AV20NotaFiscalId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vNOTAFISCALITEMID", AV7NotaFiscalItemId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTAFISCALITEMID", GetSecureSignedToken( "", AV7NotaFiscalItemId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_NOTAFISCALID", AV12Insert_NotaFiscalId.ToString());
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMCODIGO", A831NotaFiscalItemCodigo);
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMCFOP", StringUtil.LTrim( StringUtil.NToC( (decimal)(A832NotaFiscalItemCFOP), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMDESCRICAO", A833NotaFiscalItemDescricao);
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMNCM", A834NotaFiscalItemNCM);
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMCODIGOEAN", A835NotaFiscalItemCodigoEAN);
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMUNIDADECOMERCIAL", A836NotaFiscalItemUnidadeComercial);
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMQUANTIDADE", StringUtil.LTrim( StringUtil.NToC( A837NotaFiscalItemQuantidade, 18, 6, ",", "")));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMVALORUNITARIO", StringUtil.LTrim( StringUtil.NToC( A838NotaFiscalItemValorUnitario, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMVALORTOTAL", StringUtil.LTrim( StringUtil.NToC( A839NotaFiscalItemValorTotal, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMCODBARGTIN", A840NotaFiscalItemCodBarGTIN);
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMUNIDADETRIBUTAVEL", A841NotaFiscalItemUnidadeTributavel);
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMVALORUNTRIBUTAVEL", StringUtil.LTrim( StringUtil.NToC( A842NotaFiscalItemValorUnTributavel, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMQTDTRIBUTAVEL", StringUtil.LTrim( StringUtil.NToC( A843NotaFiscalItemQtdTributavel, 18, 6, ",", "")));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMVALORFRETE", StringUtil.LTrim( StringUtil.NToC( A844NotaFiscalItemValorFrete, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMDESCONTO", StringUtil.LTrim( StringUtil.NToC( A845NotaFiscalItemDesconto, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMINDICADORVALORTOTAL", A846NotaFiscalItemIndicadorValorTotal);
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMNUMPEDIDO", A847NotaFiscalItemNumPedido);
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMNUMITEM", A848NotaFiscalItemNumItem);
         GxWebStd.gx_hidden_field( context, "NOTAFISCALITEMVENDIDO", A851NotaFiscalItemVendido);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Objectcall", StringUtil.RTrim( Combo_propostaid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Cls", StringUtil.RTrim( Combo_propostaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Selectedvalue_set", StringUtil.RTrim( Combo_propostaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Selectedtext_set", StringUtil.RTrim( Combo_propostaid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Enabled", StringUtil.BoolToStr( Combo_propostaid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Datalistproc", StringUtil.RTrim( Combo_propostaid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_propostaid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_NOTAFISCALID_Objectcall", StringUtil.RTrim( Combo_notafiscalid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_NOTAFISCALID_Cls", StringUtil.RTrim( Combo_notafiscalid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_NOTAFISCALID_Selectedvalue_set", StringUtil.RTrim( Combo_notafiscalid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NOTAFISCALID_Selectedtext_set", StringUtil.RTrim( Combo_notafiscalid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NOTAFISCALID_Enabled", StringUtil.BoolToStr( Combo_notafiscalid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_NOTAFISCALID_Datalistproc", StringUtil.RTrim( Combo_notafiscalid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_NOTAFISCALID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_notafiscalid_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "notafiscalitem"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7NotaFiscalItemId.ToString());
         return formatLink("notafiscalitem") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "NotaFiscalItem" ;
      }

      public override string GetPgmdesc( )
      {
         return "Nota Fiscal Item" ;
      }

      protected void InitializeNonKey2O94( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
         n323PropostaId = ((0==A323PropostaId) ? true : false);
         A794NotaFiscalId = Guid.Empty;
         n794NotaFiscalId = false;
         AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
         n794NotaFiscalId = ((Guid.Empty==A794NotaFiscalId) ? true : false);
         A831NotaFiscalItemCodigo = "";
         n831NotaFiscalItemCodigo = false;
         AssignAttri("", false, "A831NotaFiscalItemCodigo", A831NotaFiscalItemCodigo);
         A832NotaFiscalItemCFOP = 0;
         n832NotaFiscalItemCFOP = false;
         AssignAttri("", false, "A832NotaFiscalItemCFOP", ((0==A832NotaFiscalItemCFOP)&&IsIns( )||n832NotaFiscalItemCFOP ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A832NotaFiscalItemCFOP), 4, 0, ".", ""))));
         A833NotaFiscalItemDescricao = "";
         n833NotaFiscalItemDescricao = false;
         AssignAttri("", false, "A833NotaFiscalItemDescricao", A833NotaFiscalItemDescricao);
         A834NotaFiscalItemNCM = "";
         n834NotaFiscalItemNCM = false;
         AssignAttri("", false, "A834NotaFiscalItemNCM", A834NotaFiscalItemNCM);
         A835NotaFiscalItemCodigoEAN = "";
         n835NotaFiscalItemCodigoEAN = false;
         AssignAttri("", false, "A835NotaFiscalItemCodigoEAN", A835NotaFiscalItemCodigoEAN);
         A836NotaFiscalItemUnidadeComercial = "";
         n836NotaFiscalItemUnidadeComercial = false;
         AssignAttri("", false, "A836NotaFiscalItemUnidadeComercial", A836NotaFiscalItemUnidadeComercial);
         A837NotaFiscalItemQuantidade = 0;
         n837NotaFiscalItemQuantidade = false;
         AssignAttri("", false, "A837NotaFiscalItemQuantidade", ((Convert.ToDecimal(0)==A837NotaFiscalItemQuantidade)&&IsIns( )||n837NotaFiscalItemQuantidade ? "" : StringUtil.LTrim( StringUtil.NToC( A837NotaFiscalItemQuantidade, 18, 6, ".", ""))));
         A838NotaFiscalItemValorUnitario = 0;
         n838NotaFiscalItemValorUnitario = false;
         AssignAttri("", false, "A838NotaFiscalItemValorUnitario", ((Convert.ToDecimal(0)==A838NotaFiscalItemValorUnitario)&&IsIns( )||n838NotaFiscalItemValorUnitario ? "" : StringUtil.LTrim( StringUtil.NToC( A838NotaFiscalItemValorUnitario, 18, 2, ".", ""))));
         A839NotaFiscalItemValorTotal = 0;
         n839NotaFiscalItemValorTotal = false;
         AssignAttri("", false, "A839NotaFiscalItemValorTotal", ((Convert.ToDecimal(0)==A839NotaFiscalItemValorTotal)&&IsIns( )||n839NotaFiscalItemValorTotal ? "" : StringUtil.LTrim( StringUtil.NToC( A839NotaFiscalItemValorTotal, 18, 2, ".", ""))));
         A840NotaFiscalItemCodBarGTIN = "";
         n840NotaFiscalItemCodBarGTIN = false;
         AssignAttri("", false, "A840NotaFiscalItemCodBarGTIN", A840NotaFiscalItemCodBarGTIN);
         A841NotaFiscalItemUnidadeTributavel = "";
         n841NotaFiscalItemUnidadeTributavel = false;
         AssignAttri("", false, "A841NotaFiscalItemUnidadeTributavel", A841NotaFiscalItemUnidadeTributavel);
         A842NotaFiscalItemValorUnTributavel = 0;
         n842NotaFiscalItemValorUnTributavel = false;
         AssignAttri("", false, "A842NotaFiscalItemValorUnTributavel", ((Convert.ToDecimal(0)==A842NotaFiscalItemValorUnTributavel)&&IsIns( )||n842NotaFiscalItemValorUnTributavel ? "" : StringUtil.LTrim( StringUtil.NToC( A842NotaFiscalItemValorUnTributavel, 18, 2, ".", ""))));
         A843NotaFiscalItemQtdTributavel = 0;
         n843NotaFiscalItemQtdTributavel = false;
         AssignAttri("", false, "A843NotaFiscalItemQtdTributavel", ((Convert.ToDecimal(0)==A843NotaFiscalItemQtdTributavel)&&IsIns( )||n843NotaFiscalItemQtdTributavel ? "" : StringUtil.LTrim( StringUtil.NToC( A843NotaFiscalItemQtdTributavel, 18, 6, ".", ""))));
         A844NotaFiscalItemValorFrete = 0;
         n844NotaFiscalItemValorFrete = false;
         AssignAttri("", false, "A844NotaFiscalItemValorFrete", ((Convert.ToDecimal(0)==A844NotaFiscalItemValorFrete)&&IsIns( )||n844NotaFiscalItemValorFrete ? "" : StringUtil.LTrim( StringUtil.NToC( A844NotaFiscalItemValorFrete, 18, 2, ".", ""))));
         A845NotaFiscalItemDesconto = 0;
         n845NotaFiscalItemDesconto = false;
         AssignAttri("", false, "A845NotaFiscalItemDesconto", ((Convert.ToDecimal(0)==A845NotaFiscalItemDesconto)&&IsIns( )||n845NotaFiscalItemDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A845NotaFiscalItemDesconto, 18, 2, ".", ""))));
         A846NotaFiscalItemIndicadorValorTotal = "";
         n846NotaFiscalItemIndicadorValorTotal = false;
         AssignAttri("", false, "A846NotaFiscalItemIndicadorValorTotal", A846NotaFiscalItemIndicadorValorTotal);
         A847NotaFiscalItemNumPedido = "";
         n847NotaFiscalItemNumPedido = false;
         AssignAttri("", false, "A847NotaFiscalItemNumPedido", A847NotaFiscalItemNumPedido);
         A848NotaFiscalItemNumItem = "";
         n848NotaFiscalItemNumItem = false;
         AssignAttri("", false, "A848NotaFiscalItemNumItem", A848NotaFiscalItemNumItem);
         A851NotaFiscalItemVendido = "";
         n851NotaFiscalItemVendido = false;
         AssignAttri("", false, "A851NotaFiscalItemVendido", A851NotaFiscalItemVendido);
         Z831NotaFiscalItemCodigo = "";
         Z832NotaFiscalItemCFOP = 0;
         Z833NotaFiscalItemDescricao = "";
         Z834NotaFiscalItemNCM = "";
         Z835NotaFiscalItemCodigoEAN = "";
         Z836NotaFiscalItemUnidadeComercial = "";
         Z837NotaFiscalItemQuantidade = 0;
         Z838NotaFiscalItemValorUnitario = 0;
         Z839NotaFiscalItemValorTotal = 0;
         Z840NotaFiscalItemCodBarGTIN = "";
         Z841NotaFiscalItemUnidadeTributavel = "";
         Z842NotaFiscalItemValorUnTributavel = 0;
         Z843NotaFiscalItemQtdTributavel = 0;
         Z844NotaFiscalItemValorFrete = 0;
         Z845NotaFiscalItemDesconto = 0;
         Z846NotaFiscalItemIndicadorValorTotal = "";
         Z847NotaFiscalItemNumPedido = "";
         Z848NotaFiscalItemNumItem = "";
         Z851NotaFiscalItemVendido = "";
         Z323PropostaId = 0;
         Z794NotaFiscalId = Guid.Empty;
      }

      protected void InitAll2O94( )
      {
         A830NotaFiscalItemId = Guid.NewGuid( );
         AssignAttri("", false, "A830NotaFiscalItemId", A830NotaFiscalItemId.ToString());
         InitializeNonKey2O94( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019205773", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("notafiscalitem.js", "?202561019205773", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         edtNotaFiscalItemId_Internalname = "NOTAFISCALITEMID";
         lblTextblockpropostaid_Internalname = "TEXTBLOCKPROPOSTAID";
         Combo_propostaid_Internalname = "COMBO_PROPOSTAID";
         edtPropostaId_Internalname = "PROPOSTAID";
         divTablesplittedpropostaid_Internalname = "TABLESPLITTEDPROPOSTAID";
         lblTextblocknotafiscalid_Internalname = "TEXTBLOCKNOTAFISCALID";
         Combo_notafiscalid_Internalname = "COMBO_NOTAFISCALID";
         edtNotaFiscalId_Internalname = "NOTAFISCALID";
         divTablesplittednotafiscalid_Internalname = "TABLESPLITTEDNOTAFISCALID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombopropostaid_Internalname = "vCOMBOPROPOSTAID";
         divSectionattribute_propostaid_Internalname = "SECTIONATTRIBUTE_PROPOSTAID";
         edtavCombonotafiscalid_Internalname = "vCOMBONOTAFISCALID";
         divSectionattribute_notafiscalid_Internalname = "SECTIONATTRIBUTE_NOTAFISCALID";
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
         Form.Caption = "Nota Fiscal Item";
         edtavCombonotafiscalid_Jsonclick = "";
         edtavCombonotafiscalid_Enabled = 0;
         edtavCombonotafiscalid_Visible = 1;
         edtavCombopropostaid_Jsonclick = "";
         edtavCombopropostaid_Enabled = 0;
         edtavCombopropostaid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtNotaFiscalId_Jsonclick = "";
         edtNotaFiscalId_Enabled = 1;
         edtNotaFiscalId_Visible = 1;
         Combo_notafiscalid_Datalistprocparametersprefix = " \"ComboName\": \"NotaFiscalId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"NotaFiscalItemId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_notafiscalid_Datalistproc = "NotaFiscalItemLoadDVCombo";
         Combo_notafiscalid_Cls = "ExtendedCombo AttributeFL";
         Combo_notafiscalid_Caption = "";
         Combo_notafiscalid_Enabled = Convert.ToBoolean( -1);
         edtPropostaId_Jsonclick = "";
         edtPropostaId_Enabled = 1;
         edtPropostaId_Visible = 1;
         Combo_propostaid_Datalistprocparametersprefix = " \"ComboName\": \"PropostaId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"NotaFiscalItemId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_propostaid_Datalistproc = "NotaFiscalItemLoadDVCombo";
         Combo_propostaid_Cls = "ExtendedCombo AttributeFL";
         Combo_propostaid_Caption = "";
         Combo_propostaid_Enabled = Convert.ToBoolean( -1);
         edtNotaFiscalItemId_Jsonclick = "";
         edtNotaFiscalItemId_Enabled = 1;
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

      public void Valid_Propostaid( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PropostaId) )
         {
            A323PropostaId = AV11Insert_PropostaId;
            n323PropostaId = false;
         }
         else
         {
            if ( (0==AV19ComboPropostaId) )
            {
               A323PropostaId = 0;
               n323PropostaId = false;
               n323PropostaId = true;
               n323PropostaId = true;
            }
            else
            {
               if ( ! (0==AV19ComboPropostaId) )
               {
                  A323PropostaId = AV19ComboPropostaId;
                  n323PropostaId = false;
               }
               else
               {
                  if ( (0==A323PropostaId) )
                  {
                     A323PropostaId = 0;
                     n323PropostaId = false;
                     n323PropostaId = true;
                     n323PropostaId = true;
                  }
               }
            }
         }
         /* Using cursor T002O16 */
         pr_default.execute(14, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaId_Internalname;
            }
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
      }

      public void Valid_Notafiscalid( )
      {
         n794NotaFiscalId = false;
         /* Using cursor T002O17 */
         pr_default.execute(15, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
               GX_FocusControl = edtNotaFiscalId_Internalname;
            }
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7NotaFiscalItemId","fld":"vNOTAFISCALITEMID","hsh":true,"type":"guid"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7NotaFiscalItemId","fld":"vNOTAFISCALITEMID","hsh":true,"type":"guid"},{"av":"AV11Insert_PropostaId","fld":"vINSERT_PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_NotaFiscalId","fld":"vINSERT_NOTAFISCALID","type":"guid"},{"av":"A831NotaFiscalItemCodigo","fld":"NOTAFISCALITEMCODIGO","type":"svchar"},{"av":"A832NotaFiscalItemCFOP","fld":"NOTAFISCALITEMCFOP","pic":"ZZZ9","nullAv":"n832NotaFiscalItemCFOP","type":"int"},{"av":"A833NotaFiscalItemDescricao","fld":"NOTAFISCALITEMDESCRICAO","type":"svchar"},{"av":"A834NotaFiscalItemNCM","fld":"NOTAFISCALITEMNCM","type":"svchar"},{"av":"A835NotaFiscalItemCodigoEAN","fld":"NOTAFISCALITEMCODIGOEAN","type":"svchar"},{"av":"A836NotaFiscalItemUnidadeComercial","fld":"NOTAFISCALITEMUNIDADECOMERCIAL","type":"svchar"},{"av":"A837NotaFiscalItemQuantidade","fld":"NOTAFISCALITEMQUANTIDADE","pic":"ZZZZZZZZZZ9.999999","nullAv":"n837NotaFiscalItemQuantidade","type":"decimal"},{"av":"A838NotaFiscalItemValorUnitario","fld":"NOTAFISCALITEMVALORUNITARIO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","nullAv":"n838NotaFiscalItemValorUnitario","type":"decimal"},{"av":"A839NotaFiscalItemValorTotal","fld":"NOTAFISCALITEMVALORTOTAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","nullAv":"n839NotaFiscalItemValorTotal","type":"decimal"},{"av":"A840NotaFiscalItemCodBarGTIN","fld":"NOTAFISCALITEMCODBARGTIN","type":"svchar"},{"av":"A841NotaFiscalItemUnidadeTributavel","fld":"NOTAFISCALITEMUNIDADETRIBUTAVEL","type":"svchar"},{"av":"A842NotaFiscalItemValorUnTributavel","fld":"NOTAFISCALITEMVALORUNTRIBUTAVEL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","nullAv":"n842NotaFiscalItemValorUnTributavel","type":"decimal"},{"av":"A843NotaFiscalItemQtdTributavel","fld":"NOTAFISCALITEMQTDTRIBUTAVEL","pic":"ZZZZZZZZZZ9.999999","nullAv":"n843NotaFiscalItemQtdTributavel","type":"decimal"},{"av":"A844NotaFiscalItemValorFrete","fld":"NOTAFISCALITEMVALORFRETE","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","nullAv":"n844NotaFiscalItemValorFrete","type":"decimal"},{"av":"A845NotaFiscalItemDesconto","fld":"NOTAFISCALITEMDESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","nullAv":"n845NotaFiscalItemDesconto","type":"decimal"},{"av":"A846NotaFiscalItemIndicadorValorTotal","fld":"NOTAFISCALITEMINDICADORVALORTOTAL","type":"svchar"},{"av":"A847NotaFiscalItemNumPedido","fld":"NOTAFISCALITEMNUMPEDIDO","type":"svchar"},{"av":"A848NotaFiscalItemNumItem","fld":"NOTAFISCALITEMNUMITEM","type":"svchar"},{"av":"A851NotaFiscalItemVendido","fld":"NOTAFISCALITEMVENDIDO","type":"svchar"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E132O2","iparms":[]}""");
         setEventMetadata("COMBO_NOTAFISCALID.ONOPTIONCLICKED","""{"handler":"E122O2","iparms":[{"av":"Combo_notafiscalid_Selectedvalue_get","ctrl":"COMBO_NOTAFISCALID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_NOTAFISCALID.ONOPTIONCLICKED",""","oparms":[{"av":"AV21ComboNotaFiscalId","fld":"vCOMBONOTAFISCALID","type":"guid"}]}""");
         setEventMetadata("VALID_NOTAFISCALITEMID","""{"handler":"Valid_Notafiscalitemid","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV11Insert_PropostaId","fld":"vINSERT_PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV19ComboPropostaId","fld":"vCOMBOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","nullAv":"n323PropostaId","type":"int"}]""");
         setEventMetadata("VALID_PROPOSTAID",""","oparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","nullAv":"n323PropostaId","type":"int"}]}""");
         setEventMetadata("VALID_NOTAFISCALID","""{"handler":"Valid_Notafiscalid","iparms":[{"av":"A794NotaFiscalId","fld":"NOTAFISCALID","type":"guid"}]}""");
         setEventMetadata("VALIDV_COMBOPROPOSTAID","""{"handler":"Validv_Combopropostaid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBONOTAFISCALID","""{"handler":"Validv_Combonotafiscalid","iparms":[]}""");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7NotaFiscalItemId = Guid.Empty;
         Z830NotaFiscalItemId = Guid.Empty;
         Z831NotaFiscalItemCodigo = "";
         Z833NotaFiscalItemDescricao = "";
         Z834NotaFiscalItemNCM = "";
         Z835NotaFiscalItemCodigoEAN = "";
         Z836NotaFiscalItemUnidadeComercial = "";
         Z840NotaFiscalItemCodBarGTIN = "";
         Z841NotaFiscalItemUnidadeTributavel = "";
         Z846NotaFiscalItemIndicadorValorTotal = "";
         Z847NotaFiscalItemNumPedido = "";
         Z848NotaFiscalItemNumItem = "";
         Z851NotaFiscalItemVendido = "";
         Z794NotaFiscalId = Guid.Empty;
         N794NotaFiscalId = Guid.Empty;
         Combo_notafiscalid_Selectedvalue_get = "";
         Combo_propostaid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A794NotaFiscalId = Guid.Empty;
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
         A830NotaFiscalItemId = Guid.Empty;
         lblTextblockpropostaid_Jsonclick = "";
         ucCombo_propostaid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14PropostaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblocknotafiscalid_Jsonclick = "";
         ucCombo_notafiscalid = new GXUserControl();
         AV20NotaFiscalId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV21ComboNotaFiscalId = Guid.Empty;
         A831NotaFiscalItemCodigo = "";
         A833NotaFiscalItemDescricao = "";
         A834NotaFiscalItemNCM = "";
         A835NotaFiscalItemCodigoEAN = "";
         A836NotaFiscalItemUnidadeComercial = "";
         A840NotaFiscalItemCodBarGTIN = "";
         A841NotaFiscalItemUnidadeTributavel = "";
         A846NotaFiscalItemIndicadorValorTotal = "";
         A847NotaFiscalItemNumPedido = "";
         A848NotaFiscalItemNumItem = "";
         A851NotaFiscalItemVendido = "";
         AV12Insert_NotaFiscalId = Guid.Empty;
         AV22Pgmname = "";
         Combo_propostaid_Objectcall = "";
         Combo_propostaid_Class = "";
         Combo_propostaid_Icontype = "";
         Combo_propostaid_Icon = "";
         Combo_propostaid_Tooltip = "";
         Combo_propostaid_Selectedvalue_set = "";
         Combo_propostaid_Selectedtext_set = "";
         Combo_propostaid_Selectedtext_get = "";
         Combo_propostaid_Gamoauthtoken = "";
         Combo_propostaid_Ddointernalname = "";
         Combo_propostaid_Titlecontrolalign = "";
         Combo_propostaid_Dropdownoptionstype = "";
         Combo_propostaid_Titlecontrolidtoreplace = "";
         Combo_propostaid_Datalisttype = "";
         Combo_propostaid_Datalistfixedvalues = "";
         Combo_propostaid_Remoteservicesparameters = "";
         Combo_propostaid_Htmltemplate = "";
         Combo_propostaid_Multiplevaluestype = "";
         Combo_propostaid_Loadingdata = "";
         Combo_propostaid_Noresultsfound = "";
         Combo_propostaid_Emptyitemtext = "";
         Combo_propostaid_Onlyselectedvalues = "";
         Combo_propostaid_Selectalltext = "";
         Combo_propostaid_Multiplevaluesseparator = "";
         Combo_propostaid_Addnewoptiontext = "";
         Combo_notafiscalid_Objectcall = "";
         Combo_notafiscalid_Class = "";
         Combo_notafiscalid_Icontype = "";
         Combo_notafiscalid_Icon = "";
         Combo_notafiscalid_Tooltip = "";
         Combo_notafiscalid_Selectedvalue_set = "";
         Combo_notafiscalid_Selectedtext_set = "";
         Combo_notafiscalid_Selectedtext_get = "";
         Combo_notafiscalid_Gamoauthtoken = "";
         Combo_notafiscalid_Ddointernalname = "";
         Combo_notafiscalid_Titlecontrolalign = "";
         Combo_notafiscalid_Dropdownoptionstype = "";
         Combo_notafiscalid_Titlecontrolidtoreplace = "";
         Combo_notafiscalid_Datalisttype = "";
         Combo_notafiscalid_Datalistfixedvalues = "";
         Combo_notafiscalid_Remoteservicesparameters = "";
         Combo_notafiscalid_Htmltemplate = "";
         Combo_notafiscalid_Multiplevaluestype = "";
         Combo_notafiscalid_Loadingdata = "";
         Combo_notafiscalid_Noresultsfound = "";
         Combo_notafiscalid_Emptyitemtext = "";
         Combo_notafiscalid_Onlyselectedvalues = "";
         Combo_notafiscalid_Selectalltext = "";
         Combo_notafiscalid_Multiplevaluesseparator = "";
         Combo_notafiscalid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode94 = "";
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
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV18Combo_DataJson = "";
         AV16ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         GXt_char2 = "";
         T002O6_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         T002O6_A831NotaFiscalItemCodigo = new string[] {""} ;
         T002O6_n831NotaFiscalItemCodigo = new bool[] {false} ;
         T002O6_A832NotaFiscalItemCFOP = new short[1] ;
         T002O6_n832NotaFiscalItemCFOP = new bool[] {false} ;
         T002O6_A833NotaFiscalItemDescricao = new string[] {""} ;
         T002O6_n833NotaFiscalItemDescricao = new bool[] {false} ;
         T002O6_A834NotaFiscalItemNCM = new string[] {""} ;
         T002O6_n834NotaFiscalItemNCM = new bool[] {false} ;
         T002O6_A835NotaFiscalItemCodigoEAN = new string[] {""} ;
         T002O6_n835NotaFiscalItemCodigoEAN = new bool[] {false} ;
         T002O6_A836NotaFiscalItemUnidadeComercial = new string[] {""} ;
         T002O6_n836NotaFiscalItemUnidadeComercial = new bool[] {false} ;
         T002O6_A837NotaFiscalItemQuantidade = new decimal[1] ;
         T002O6_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         T002O6_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         T002O6_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         T002O6_A839NotaFiscalItemValorTotal = new decimal[1] ;
         T002O6_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         T002O6_A840NotaFiscalItemCodBarGTIN = new string[] {""} ;
         T002O6_n840NotaFiscalItemCodBarGTIN = new bool[] {false} ;
         T002O6_A841NotaFiscalItemUnidadeTributavel = new string[] {""} ;
         T002O6_n841NotaFiscalItemUnidadeTributavel = new bool[] {false} ;
         T002O6_A842NotaFiscalItemValorUnTributavel = new decimal[1] ;
         T002O6_n842NotaFiscalItemValorUnTributavel = new bool[] {false} ;
         T002O6_A843NotaFiscalItemQtdTributavel = new decimal[1] ;
         T002O6_n843NotaFiscalItemQtdTributavel = new bool[] {false} ;
         T002O6_A844NotaFiscalItemValorFrete = new decimal[1] ;
         T002O6_n844NotaFiscalItemValorFrete = new bool[] {false} ;
         T002O6_A845NotaFiscalItemDesconto = new decimal[1] ;
         T002O6_n845NotaFiscalItemDesconto = new bool[] {false} ;
         T002O6_A846NotaFiscalItemIndicadorValorTotal = new string[] {""} ;
         T002O6_n846NotaFiscalItemIndicadorValorTotal = new bool[] {false} ;
         T002O6_A847NotaFiscalItemNumPedido = new string[] {""} ;
         T002O6_n847NotaFiscalItemNumPedido = new bool[] {false} ;
         T002O6_A848NotaFiscalItemNumItem = new string[] {""} ;
         T002O6_n848NotaFiscalItemNumItem = new bool[] {false} ;
         T002O6_A851NotaFiscalItemVendido = new string[] {""} ;
         T002O6_n851NotaFiscalItemVendido = new bool[] {false} ;
         T002O6_A323PropostaId = new int[1] ;
         T002O6_n323PropostaId = new bool[] {false} ;
         T002O6_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002O6_n794NotaFiscalId = new bool[] {false} ;
         T002O4_A323PropostaId = new int[1] ;
         T002O4_n323PropostaId = new bool[] {false} ;
         T002O5_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002O5_n794NotaFiscalId = new bool[] {false} ;
         T002O7_A323PropostaId = new int[1] ;
         T002O7_n323PropostaId = new bool[] {false} ;
         T002O8_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002O8_n794NotaFiscalId = new bool[] {false} ;
         T002O9_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         T002O3_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         T002O3_A831NotaFiscalItemCodigo = new string[] {""} ;
         T002O3_n831NotaFiscalItemCodigo = new bool[] {false} ;
         T002O3_A832NotaFiscalItemCFOP = new short[1] ;
         T002O3_n832NotaFiscalItemCFOP = new bool[] {false} ;
         T002O3_A833NotaFiscalItemDescricao = new string[] {""} ;
         T002O3_n833NotaFiscalItemDescricao = new bool[] {false} ;
         T002O3_A834NotaFiscalItemNCM = new string[] {""} ;
         T002O3_n834NotaFiscalItemNCM = new bool[] {false} ;
         T002O3_A835NotaFiscalItemCodigoEAN = new string[] {""} ;
         T002O3_n835NotaFiscalItemCodigoEAN = new bool[] {false} ;
         T002O3_A836NotaFiscalItemUnidadeComercial = new string[] {""} ;
         T002O3_n836NotaFiscalItemUnidadeComercial = new bool[] {false} ;
         T002O3_A837NotaFiscalItemQuantidade = new decimal[1] ;
         T002O3_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         T002O3_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         T002O3_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         T002O3_A839NotaFiscalItemValorTotal = new decimal[1] ;
         T002O3_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         T002O3_A840NotaFiscalItemCodBarGTIN = new string[] {""} ;
         T002O3_n840NotaFiscalItemCodBarGTIN = new bool[] {false} ;
         T002O3_A841NotaFiscalItemUnidadeTributavel = new string[] {""} ;
         T002O3_n841NotaFiscalItemUnidadeTributavel = new bool[] {false} ;
         T002O3_A842NotaFiscalItemValorUnTributavel = new decimal[1] ;
         T002O3_n842NotaFiscalItemValorUnTributavel = new bool[] {false} ;
         T002O3_A843NotaFiscalItemQtdTributavel = new decimal[1] ;
         T002O3_n843NotaFiscalItemQtdTributavel = new bool[] {false} ;
         T002O3_A844NotaFiscalItemValorFrete = new decimal[1] ;
         T002O3_n844NotaFiscalItemValorFrete = new bool[] {false} ;
         T002O3_A845NotaFiscalItemDesconto = new decimal[1] ;
         T002O3_n845NotaFiscalItemDesconto = new bool[] {false} ;
         T002O3_A846NotaFiscalItemIndicadorValorTotal = new string[] {""} ;
         T002O3_n846NotaFiscalItemIndicadorValorTotal = new bool[] {false} ;
         T002O3_A847NotaFiscalItemNumPedido = new string[] {""} ;
         T002O3_n847NotaFiscalItemNumPedido = new bool[] {false} ;
         T002O3_A848NotaFiscalItemNumItem = new string[] {""} ;
         T002O3_n848NotaFiscalItemNumItem = new bool[] {false} ;
         T002O3_A851NotaFiscalItemVendido = new string[] {""} ;
         T002O3_n851NotaFiscalItemVendido = new bool[] {false} ;
         T002O3_A323PropostaId = new int[1] ;
         T002O3_n323PropostaId = new bool[] {false} ;
         T002O3_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002O3_n794NotaFiscalId = new bool[] {false} ;
         T002O10_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         T002O11_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         T002O2_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         T002O2_A831NotaFiscalItemCodigo = new string[] {""} ;
         T002O2_n831NotaFiscalItemCodigo = new bool[] {false} ;
         T002O2_A832NotaFiscalItemCFOP = new short[1] ;
         T002O2_n832NotaFiscalItemCFOP = new bool[] {false} ;
         T002O2_A833NotaFiscalItemDescricao = new string[] {""} ;
         T002O2_n833NotaFiscalItemDescricao = new bool[] {false} ;
         T002O2_A834NotaFiscalItemNCM = new string[] {""} ;
         T002O2_n834NotaFiscalItemNCM = new bool[] {false} ;
         T002O2_A835NotaFiscalItemCodigoEAN = new string[] {""} ;
         T002O2_n835NotaFiscalItemCodigoEAN = new bool[] {false} ;
         T002O2_A836NotaFiscalItemUnidadeComercial = new string[] {""} ;
         T002O2_n836NotaFiscalItemUnidadeComercial = new bool[] {false} ;
         T002O2_A837NotaFiscalItemQuantidade = new decimal[1] ;
         T002O2_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         T002O2_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         T002O2_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         T002O2_A839NotaFiscalItemValorTotal = new decimal[1] ;
         T002O2_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         T002O2_A840NotaFiscalItemCodBarGTIN = new string[] {""} ;
         T002O2_n840NotaFiscalItemCodBarGTIN = new bool[] {false} ;
         T002O2_A841NotaFiscalItemUnidadeTributavel = new string[] {""} ;
         T002O2_n841NotaFiscalItemUnidadeTributavel = new bool[] {false} ;
         T002O2_A842NotaFiscalItemValorUnTributavel = new decimal[1] ;
         T002O2_n842NotaFiscalItemValorUnTributavel = new bool[] {false} ;
         T002O2_A843NotaFiscalItemQtdTributavel = new decimal[1] ;
         T002O2_n843NotaFiscalItemQtdTributavel = new bool[] {false} ;
         T002O2_A844NotaFiscalItemValorFrete = new decimal[1] ;
         T002O2_n844NotaFiscalItemValorFrete = new bool[] {false} ;
         T002O2_A845NotaFiscalItemDesconto = new decimal[1] ;
         T002O2_n845NotaFiscalItemDesconto = new bool[] {false} ;
         T002O2_A846NotaFiscalItemIndicadorValorTotal = new string[] {""} ;
         T002O2_n846NotaFiscalItemIndicadorValorTotal = new bool[] {false} ;
         T002O2_A847NotaFiscalItemNumPedido = new string[] {""} ;
         T002O2_n847NotaFiscalItemNumPedido = new bool[] {false} ;
         T002O2_A848NotaFiscalItemNumItem = new string[] {""} ;
         T002O2_n848NotaFiscalItemNumItem = new bool[] {false} ;
         T002O2_A851NotaFiscalItemVendido = new string[] {""} ;
         T002O2_n851NotaFiscalItemVendido = new bool[] {false} ;
         T002O2_A323PropostaId = new int[1] ;
         T002O2_n323PropostaId = new bool[] {false} ;
         T002O2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002O2_n794NotaFiscalId = new bool[] {false} ;
         T002O15_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T002O16_A323PropostaId = new int[1] ;
         T002O16_n323PropostaId = new bool[] {false} ;
         T002O17_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002O17_n794NotaFiscalId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalitem__default(),
            new Object[][] {
                new Object[] {
               T002O2_A830NotaFiscalItemId, T002O2_A831NotaFiscalItemCodigo, T002O2_n831NotaFiscalItemCodigo, T002O2_A832NotaFiscalItemCFOP, T002O2_n832NotaFiscalItemCFOP, T002O2_A833NotaFiscalItemDescricao, T002O2_n833NotaFiscalItemDescricao, T002O2_A834NotaFiscalItemNCM, T002O2_n834NotaFiscalItemNCM, T002O2_A835NotaFiscalItemCodigoEAN,
               T002O2_n835NotaFiscalItemCodigoEAN, T002O2_A836NotaFiscalItemUnidadeComercial, T002O2_n836NotaFiscalItemUnidadeComercial, T002O2_A837NotaFiscalItemQuantidade, T002O2_n837NotaFiscalItemQuantidade, T002O2_A838NotaFiscalItemValorUnitario, T002O2_n838NotaFiscalItemValorUnitario, T002O2_A839NotaFiscalItemValorTotal, T002O2_n839NotaFiscalItemValorTotal, T002O2_A840NotaFiscalItemCodBarGTIN,
               T002O2_n840NotaFiscalItemCodBarGTIN, T002O2_A841NotaFiscalItemUnidadeTributavel, T002O2_n841NotaFiscalItemUnidadeTributavel, T002O2_A842NotaFiscalItemValorUnTributavel, T002O2_n842NotaFiscalItemValorUnTributavel, T002O2_A843NotaFiscalItemQtdTributavel, T002O2_n843NotaFiscalItemQtdTributavel, T002O2_A844NotaFiscalItemValorFrete, T002O2_n844NotaFiscalItemValorFrete, T002O2_A845NotaFiscalItemDesconto,
               T002O2_n845NotaFiscalItemDesconto, T002O2_A846NotaFiscalItemIndicadorValorTotal, T002O2_n846NotaFiscalItemIndicadorValorTotal, T002O2_A847NotaFiscalItemNumPedido, T002O2_n847NotaFiscalItemNumPedido, T002O2_A848NotaFiscalItemNumItem, T002O2_n848NotaFiscalItemNumItem, T002O2_A851NotaFiscalItemVendido, T002O2_n851NotaFiscalItemVendido, T002O2_A323PropostaId,
               T002O2_n323PropostaId, T002O2_A794NotaFiscalId, T002O2_n794NotaFiscalId
               }
               , new Object[] {
               T002O3_A830NotaFiscalItemId, T002O3_A831NotaFiscalItemCodigo, T002O3_n831NotaFiscalItemCodigo, T002O3_A832NotaFiscalItemCFOP, T002O3_n832NotaFiscalItemCFOP, T002O3_A833NotaFiscalItemDescricao, T002O3_n833NotaFiscalItemDescricao, T002O3_A834NotaFiscalItemNCM, T002O3_n834NotaFiscalItemNCM, T002O3_A835NotaFiscalItemCodigoEAN,
               T002O3_n835NotaFiscalItemCodigoEAN, T002O3_A836NotaFiscalItemUnidadeComercial, T002O3_n836NotaFiscalItemUnidadeComercial, T002O3_A837NotaFiscalItemQuantidade, T002O3_n837NotaFiscalItemQuantidade, T002O3_A838NotaFiscalItemValorUnitario, T002O3_n838NotaFiscalItemValorUnitario, T002O3_A839NotaFiscalItemValorTotal, T002O3_n839NotaFiscalItemValorTotal, T002O3_A840NotaFiscalItemCodBarGTIN,
               T002O3_n840NotaFiscalItemCodBarGTIN, T002O3_A841NotaFiscalItemUnidadeTributavel, T002O3_n841NotaFiscalItemUnidadeTributavel, T002O3_A842NotaFiscalItemValorUnTributavel, T002O3_n842NotaFiscalItemValorUnTributavel, T002O3_A843NotaFiscalItemQtdTributavel, T002O3_n843NotaFiscalItemQtdTributavel, T002O3_A844NotaFiscalItemValorFrete, T002O3_n844NotaFiscalItemValorFrete, T002O3_A845NotaFiscalItemDesconto,
               T002O3_n845NotaFiscalItemDesconto, T002O3_A846NotaFiscalItemIndicadorValorTotal, T002O3_n846NotaFiscalItemIndicadorValorTotal, T002O3_A847NotaFiscalItemNumPedido, T002O3_n847NotaFiscalItemNumPedido, T002O3_A848NotaFiscalItemNumItem, T002O3_n848NotaFiscalItemNumItem, T002O3_A851NotaFiscalItemVendido, T002O3_n851NotaFiscalItemVendido, T002O3_A323PropostaId,
               T002O3_n323PropostaId, T002O3_A794NotaFiscalId, T002O3_n794NotaFiscalId
               }
               , new Object[] {
               T002O4_A323PropostaId
               }
               , new Object[] {
               T002O5_A794NotaFiscalId
               }
               , new Object[] {
               T002O6_A830NotaFiscalItemId, T002O6_A831NotaFiscalItemCodigo, T002O6_n831NotaFiscalItemCodigo, T002O6_A832NotaFiscalItemCFOP, T002O6_n832NotaFiscalItemCFOP, T002O6_A833NotaFiscalItemDescricao, T002O6_n833NotaFiscalItemDescricao, T002O6_A834NotaFiscalItemNCM, T002O6_n834NotaFiscalItemNCM, T002O6_A835NotaFiscalItemCodigoEAN,
               T002O6_n835NotaFiscalItemCodigoEAN, T002O6_A836NotaFiscalItemUnidadeComercial, T002O6_n836NotaFiscalItemUnidadeComercial, T002O6_A837NotaFiscalItemQuantidade, T002O6_n837NotaFiscalItemQuantidade, T002O6_A838NotaFiscalItemValorUnitario, T002O6_n838NotaFiscalItemValorUnitario, T002O6_A839NotaFiscalItemValorTotal, T002O6_n839NotaFiscalItemValorTotal, T002O6_A840NotaFiscalItemCodBarGTIN,
               T002O6_n840NotaFiscalItemCodBarGTIN, T002O6_A841NotaFiscalItemUnidadeTributavel, T002O6_n841NotaFiscalItemUnidadeTributavel, T002O6_A842NotaFiscalItemValorUnTributavel, T002O6_n842NotaFiscalItemValorUnTributavel, T002O6_A843NotaFiscalItemQtdTributavel, T002O6_n843NotaFiscalItemQtdTributavel, T002O6_A844NotaFiscalItemValorFrete, T002O6_n844NotaFiscalItemValorFrete, T002O6_A845NotaFiscalItemDesconto,
               T002O6_n845NotaFiscalItemDesconto, T002O6_A846NotaFiscalItemIndicadorValorTotal, T002O6_n846NotaFiscalItemIndicadorValorTotal, T002O6_A847NotaFiscalItemNumPedido, T002O6_n847NotaFiscalItemNumPedido, T002O6_A848NotaFiscalItemNumItem, T002O6_n848NotaFiscalItemNumItem, T002O6_A851NotaFiscalItemVendido, T002O6_n851NotaFiscalItemVendido, T002O6_A323PropostaId,
               T002O6_n323PropostaId, T002O6_A794NotaFiscalId, T002O6_n794NotaFiscalId
               }
               , new Object[] {
               T002O7_A323PropostaId
               }
               , new Object[] {
               T002O8_A794NotaFiscalId
               }
               , new Object[] {
               T002O9_A830NotaFiscalItemId
               }
               , new Object[] {
               T002O10_A830NotaFiscalItemId
               }
               , new Object[] {
               T002O11_A830NotaFiscalItemId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002O15_A830NotaFiscalItemId
               }
               , new Object[] {
               T002O16_A323PropostaId
               }
               , new Object[] {
               T002O17_A794NotaFiscalId
               }
            }
         );
         Z830NotaFiscalItemId = Guid.NewGuid( );
         A830NotaFiscalItemId = Guid.NewGuid( );
         AV22Pgmname = "NotaFiscalItem";
      }

      private short Z832NotaFiscalItemCFOP ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A832NotaFiscalItemCFOP ;
      private short Gx_BScreen ;
      private short RcdFound94 ;
      private short gxajaxcallmode ;
      private int Z323PropostaId ;
      private int N323PropostaId ;
      private int A323PropostaId ;
      private int trnEnded ;
      private int edtNotaFiscalItemId_Enabled ;
      private int edtPropostaId_Visible ;
      private int edtPropostaId_Enabled ;
      private int edtNotaFiscalId_Visible ;
      private int edtNotaFiscalId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboPropostaId ;
      private int edtavCombopropostaid_Enabled ;
      private int edtavCombopropostaid_Visible ;
      private int edtavCombonotafiscalid_Visible ;
      private int edtavCombonotafiscalid_Enabled ;
      private int AV11Insert_PropostaId ;
      private int Combo_propostaid_Datalistupdateminimumcharacters ;
      private int Combo_propostaid_Gxcontroltype ;
      private int Combo_notafiscalid_Datalistupdateminimumcharacters ;
      private int Combo_notafiscalid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV23GXV1 ;
      private int idxLst ;
      private decimal Z837NotaFiscalItemQuantidade ;
      private decimal Z838NotaFiscalItemValorUnitario ;
      private decimal Z839NotaFiscalItemValorTotal ;
      private decimal Z842NotaFiscalItemValorUnTributavel ;
      private decimal Z843NotaFiscalItemQtdTributavel ;
      private decimal Z844NotaFiscalItemValorFrete ;
      private decimal Z845NotaFiscalItemDesconto ;
      private decimal A837NotaFiscalItemQuantidade ;
      private decimal A838NotaFiscalItemValorUnitario ;
      private decimal A839NotaFiscalItemValorTotal ;
      private decimal A842NotaFiscalItemValorUnTributavel ;
      private decimal A843NotaFiscalItemQtdTributavel ;
      private decimal A844NotaFiscalItemValorFrete ;
      private decimal A845NotaFiscalItemDesconto ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_notafiscalid_Selectedvalue_get ;
      private string Combo_propostaid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNotaFiscalItemId_Internalname ;
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
      private string edtNotaFiscalItemId_Jsonclick ;
      private string divTablesplittedpropostaid_Internalname ;
      private string lblTextblockpropostaid_Internalname ;
      private string lblTextblockpropostaid_Jsonclick ;
      private string Combo_propostaid_Caption ;
      private string Combo_propostaid_Cls ;
      private string Combo_propostaid_Datalistproc ;
      private string Combo_propostaid_Datalistprocparametersprefix ;
      private string Combo_propostaid_Internalname ;
      private string edtPropostaId_Internalname ;
      private string edtPropostaId_Jsonclick ;
      private string divTablesplittednotafiscalid_Internalname ;
      private string lblTextblocknotafiscalid_Internalname ;
      private string lblTextblocknotafiscalid_Jsonclick ;
      private string Combo_notafiscalid_Caption ;
      private string Combo_notafiscalid_Cls ;
      private string Combo_notafiscalid_Datalistproc ;
      private string Combo_notafiscalid_Datalistprocparametersprefix ;
      private string Combo_notafiscalid_Internalname ;
      private string edtNotaFiscalId_Internalname ;
      private string edtNotaFiscalId_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_propostaid_Internalname ;
      private string edtavCombopropostaid_Internalname ;
      private string edtavCombopropostaid_Jsonclick ;
      private string divSectionattribute_notafiscalid_Internalname ;
      private string edtavCombonotafiscalid_Internalname ;
      private string edtavCombonotafiscalid_Jsonclick ;
      private string AV22Pgmname ;
      private string Combo_propostaid_Objectcall ;
      private string Combo_propostaid_Class ;
      private string Combo_propostaid_Icontype ;
      private string Combo_propostaid_Icon ;
      private string Combo_propostaid_Tooltip ;
      private string Combo_propostaid_Selectedvalue_set ;
      private string Combo_propostaid_Selectedtext_set ;
      private string Combo_propostaid_Selectedtext_get ;
      private string Combo_propostaid_Gamoauthtoken ;
      private string Combo_propostaid_Ddointernalname ;
      private string Combo_propostaid_Titlecontrolalign ;
      private string Combo_propostaid_Dropdownoptionstype ;
      private string Combo_propostaid_Titlecontrolidtoreplace ;
      private string Combo_propostaid_Datalisttype ;
      private string Combo_propostaid_Datalistfixedvalues ;
      private string Combo_propostaid_Remoteservicesparameters ;
      private string Combo_propostaid_Htmltemplate ;
      private string Combo_propostaid_Multiplevaluestype ;
      private string Combo_propostaid_Loadingdata ;
      private string Combo_propostaid_Noresultsfound ;
      private string Combo_propostaid_Emptyitemtext ;
      private string Combo_propostaid_Onlyselectedvalues ;
      private string Combo_propostaid_Selectalltext ;
      private string Combo_propostaid_Multiplevaluesseparator ;
      private string Combo_propostaid_Addnewoptiontext ;
      private string Combo_notafiscalid_Objectcall ;
      private string Combo_notafiscalid_Class ;
      private string Combo_notafiscalid_Icontype ;
      private string Combo_notafiscalid_Icon ;
      private string Combo_notafiscalid_Tooltip ;
      private string Combo_notafiscalid_Selectedvalue_set ;
      private string Combo_notafiscalid_Selectedtext_set ;
      private string Combo_notafiscalid_Selectedtext_get ;
      private string Combo_notafiscalid_Gamoauthtoken ;
      private string Combo_notafiscalid_Ddointernalname ;
      private string Combo_notafiscalid_Titlecontrolalign ;
      private string Combo_notafiscalid_Dropdownoptionstype ;
      private string Combo_notafiscalid_Titlecontrolidtoreplace ;
      private string Combo_notafiscalid_Datalisttype ;
      private string Combo_notafiscalid_Datalistfixedvalues ;
      private string Combo_notafiscalid_Remoteservicesparameters ;
      private string Combo_notafiscalid_Htmltemplate ;
      private string Combo_notafiscalid_Multiplevaluestype ;
      private string Combo_notafiscalid_Loadingdata ;
      private string Combo_notafiscalid_Noresultsfound ;
      private string Combo_notafiscalid_Emptyitemtext ;
      private string Combo_notafiscalid_Onlyselectedvalues ;
      private string Combo_notafiscalid_Selectalltext ;
      private string Combo_notafiscalid_Multiplevaluesseparator ;
      private string Combo_notafiscalid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode94 ;
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
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n323PropostaId ;
      private bool n794NotaFiscalId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n831NotaFiscalItemCodigo ;
      private bool n832NotaFiscalItemCFOP ;
      private bool n833NotaFiscalItemDescricao ;
      private bool n834NotaFiscalItemNCM ;
      private bool n835NotaFiscalItemCodigoEAN ;
      private bool n836NotaFiscalItemUnidadeComercial ;
      private bool n837NotaFiscalItemQuantidade ;
      private bool n838NotaFiscalItemValorUnitario ;
      private bool n839NotaFiscalItemValorTotal ;
      private bool n840NotaFiscalItemCodBarGTIN ;
      private bool n841NotaFiscalItemUnidadeTributavel ;
      private bool n842NotaFiscalItemValorUnTributavel ;
      private bool n843NotaFiscalItemQtdTributavel ;
      private bool n844NotaFiscalItemValorFrete ;
      private bool n845NotaFiscalItemDesconto ;
      private bool n846NotaFiscalItemIndicadorValorTotal ;
      private bool n847NotaFiscalItemNumPedido ;
      private bool n848NotaFiscalItemNumItem ;
      private bool n851NotaFiscalItemVendido ;
      private bool Combo_propostaid_Enabled ;
      private bool Combo_propostaid_Visible ;
      private bool Combo_propostaid_Allowmultipleselection ;
      private bool Combo_propostaid_Isgriditem ;
      private bool Combo_propostaid_Hasdescription ;
      private bool Combo_propostaid_Includeonlyselectedoption ;
      private bool Combo_propostaid_Includeselectalloption ;
      private bool Combo_propostaid_Emptyitem ;
      private bool Combo_propostaid_Includeaddnewoption ;
      private bool Combo_notafiscalid_Enabled ;
      private bool Combo_notafiscalid_Visible ;
      private bool Combo_notafiscalid_Allowmultipleselection ;
      private bool Combo_notafiscalid_Isgriditem ;
      private bool Combo_notafiscalid_Hasdescription ;
      private bool Combo_notafiscalid_Includeonlyselectedoption ;
      private bool Combo_notafiscalid_Includeselectalloption ;
      private bool Combo_notafiscalid_Emptyitem ;
      private bool Combo_notafiscalid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV18Combo_DataJson ;
      private string Z831NotaFiscalItemCodigo ;
      private string Z833NotaFiscalItemDescricao ;
      private string Z834NotaFiscalItemNCM ;
      private string Z835NotaFiscalItemCodigoEAN ;
      private string Z836NotaFiscalItemUnidadeComercial ;
      private string Z840NotaFiscalItemCodBarGTIN ;
      private string Z841NotaFiscalItemUnidadeTributavel ;
      private string Z846NotaFiscalItemIndicadorValorTotal ;
      private string Z847NotaFiscalItemNumPedido ;
      private string Z848NotaFiscalItemNumItem ;
      private string Z851NotaFiscalItemVendido ;
      private string A831NotaFiscalItemCodigo ;
      private string A833NotaFiscalItemDescricao ;
      private string A834NotaFiscalItemNCM ;
      private string A835NotaFiscalItemCodigoEAN ;
      private string A836NotaFiscalItemUnidadeComercial ;
      private string A840NotaFiscalItemCodBarGTIN ;
      private string A841NotaFiscalItemUnidadeTributavel ;
      private string A846NotaFiscalItemIndicadorValorTotal ;
      private string A847NotaFiscalItemNumPedido ;
      private string A848NotaFiscalItemNumItem ;
      private string A851NotaFiscalItemVendido ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private Guid wcpOAV7NotaFiscalItemId ;
      private Guid Z830NotaFiscalItemId ;
      private Guid Z794NotaFiscalId ;
      private Guid N794NotaFiscalId ;
      private Guid A794NotaFiscalId ;
      private Guid AV7NotaFiscalItemId ;
      private Guid A830NotaFiscalItemId ;
      private Guid AV21ComboNotaFiscalId ;
      private Guid AV12Insert_NotaFiscalId ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_propostaid ;
      private GXUserControl ucCombo_notafiscalid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14PropostaId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV20NotaFiscalId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] T002O6_A830NotaFiscalItemId ;
      private string[] T002O6_A831NotaFiscalItemCodigo ;
      private bool[] T002O6_n831NotaFiscalItemCodigo ;
      private short[] T002O6_A832NotaFiscalItemCFOP ;
      private bool[] T002O6_n832NotaFiscalItemCFOP ;
      private string[] T002O6_A833NotaFiscalItemDescricao ;
      private bool[] T002O6_n833NotaFiscalItemDescricao ;
      private string[] T002O6_A834NotaFiscalItemNCM ;
      private bool[] T002O6_n834NotaFiscalItemNCM ;
      private string[] T002O6_A835NotaFiscalItemCodigoEAN ;
      private bool[] T002O6_n835NotaFiscalItemCodigoEAN ;
      private string[] T002O6_A836NotaFiscalItemUnidadeComercial ;
      private bool[] T002O6_n836NotaFiscalItemUnidadeComercial ;
      private decimal[] T002O6_A837NotaFiscalItemQuantidade ;
      private bool[] T002O6_n837NotaFiscalItemQuantidade ;
      private decimal[] T002O6_A838NotaFiscalItemValorUnitario ;
      private bool[] T002O6_n838NotaFiscalItemValorUnitario ;
      private decimal[] T002O6_A839NotaFiscalItemValorTotal ;
      private bool[] T002O6_n839NotaFiscalItemValorTotal ;
      private string[] T002O6_A840NotaFiscalItemCodBarGTIN ;
      private bool[] T002O6_n840NotaFiscalItemCodBarGTIN ;
      private string[] T002O6_A841NotaFiscalItemUnidadeTributavel ;
      private bool[] T002O6_n841NotaFiscalItemUnidadeTributavel ;
      private decimal[] T002O6_A842NotaFiscalItemValorUnTributavel ;
      private bool[] T002O6_n842NotaFiscalItemValorUnTributavel ;
      private decimal[] T002O6_A843NotaFiscalItemQtdTributavel ;
      private bool[] T002O6_n843NotaFiscalItemQtdTributavel ;
      private decimal[] T002O6_A844NotaFiscalItemValorFrete ;
      private bool[] T002O6_n844NotaFiscalItemValorFrete ;
      private decimal[] T002O6_A845NotaFiscalItemDesconto ;
      private bool[] T002O6_n845NotaFiscalItemDesconto ;
      private string[] T002O6_A846NotaFiscalItemIndicadorValorTotal ;
      private bool[] T002O6_n846NotaFiscalItemIndicadorValorTotal ;
      private string[] T002O6_A847NotaFiscalItemNumPedido ;
      private bool[] T002O6_n847NotaFiscalItemNumPedido ;
      private string[] T002O6_A848NotaFiscalItemNumItem ;
      private bool[] T002O6_n848NotaFiscalItemNumItem ;
      private string[] T002O6_A851NotaFiscalItemVendido ;
      private bool[] T002O6_n851NotaFiscalItemVendido ;
      private int[] T002O6_A323PropostaId ;
      private bool[] T002O6_n323PropostaId ;
      private Guid[] T002O6_A794NotaFiscalId ;
      private bool[] T002O6_n794NotaFiscalId ;
      private int[] T002O4_A323PropostaId ;
      private bool[] T002O4_n323PropostaId ;
      private Guid[] T002O5_A794NotaFiscalId ;
      private bool[] T002O5_n794NotaFiscalId ;
      private int[] T002O7_A323PropostaId ;
      private bool[] T002O7_n323PropostaId ;
      private Guid[] T002O8_A794NotaFiscalId ;
      private bool[] T002O8_n794NotaFiscalId ;
      private Guid[] T002O9_A830NotaFiscalItemId ;
      private Guid[] T002O3_A830NotaFiscalItemId ;
      private string[] T002O3_A831NotaFiscalItemCodigo ;
      private bool[] T002O3_n831NotaFiscalItemCodigo ;
      private short[] T002O3_A832NotaFiscalItemCFOP ;
      private bool[] T002O3_n832NotaFiscalItemCFOP ;
      private string[] T002O3_A833NotaFiscalItemDescricao ;
      private bool[] T002O3_n833NotaFiscalItemDescricao ;
      private string[] T002O3_A834NotaFiscalItemNCM ;
      private bool[] T002O3_n834NotaFiscalItemNCM ;
      private string[] T002O3_A835NotaFiscalItemCodigoEAN ;
      private bool[] T002O3_n835NotaFiscalItemCodigoEAN ;
      private string[] T002O3_A836NotaFiscalItemUnidadeComercial ;
      private bool[] T002O3_n836NotaFiscalItemUnidadeComercial ;
      private decimal[] T002O3_A837NotaFiscalItemQuantidade ;
      private bool[] T002O3_n837NotaFiscalItemQuantidade ;
      private decimal[] T002O3_A838NotaFiscalItemValorUnitario ;
      private bool[] T002O3_n838NotaFiscalItemValorUnitario ;
      private decimal[] T002O3_A839NotaFiscalItemValorTotal ;
      private bool[] T002O3_n839NotaFiscalItemValorTotal ;
      private string[] T002O3_A840NotaFiscalItemCodBarGTIN ;
      private bool[] T002O3_n840NotaFiscalItemCodBarGTIN ;
      private string[] T002O3_A841NotaFiscalItemUnidadeTributavel ;
      private bool[] T002O3_n841NotaFiscalItemUnidadeTributavel ;
      private decimal[] T002O3_A842NotaFiscalItemValorUnTributavel ;
      private bool[] T002O3_n842NotaFiscalItemValorUnTributavel ;
      private decimal[] T002O3_A843NotaFiscalItemQtdTributavel ;
      private bool[] T002O3_n843NotaFiscalItemQtdTributavel ;
      private decimal[] T002O3_A844NotaFiscalItemValorFrete ;
      private bool[] T002O3_n844NotaFiscalItemValorFrete ;
      private decimal[] T002O3_A845NotaFiscalItemDesconto ;
      private bool[] T002O3_n845NotaFiscalItemDesconto ;
      private string[] T002O3_A846NotaFiscalItemIndicadorValorTotal ;
      private bool[] T002O3_n846NotaFiscalItemIndicadorValorTotal ;
      private string[] T002O3_A847NotaFiscalItemNumPedido ;
      private bool[] T002O3_n847NotaFiscalItemNumPedido ;
      private string[] T002O3_A848NotaFiscalItemNumItem ;
      private bool[] T002O3_n848NotaFiscalItemNumItem ;
      private string[] T002O3_A851NotaFiscalItemVendido ;
      private bool[] T002O3_n851NotaFiscalItemVendido ;
      private int[] T002O3_A323PropostaId ;
      private bool[] T002O3_n323PropostaId ;
      private Guid[] T002O3_A794NotaFiscalId ;
      private bool[] T002O3_n794NotaFiscalId ;
      private Guid[] T002O10_A830NotaFiscalItemId ;
      private Guid[] T002O11_A830NotaFiscalItemId ;
      private Guid[] T002O2_A830NotaFiscalItemId ;
      private string[] T002O2_A831NotaFiscalItemCodigo ;
      private bool[] T002O2_n831NotaFiscalItemCodigo ;
      private short[] T002O2_A832NotaFiscalItemCFOP ;
      private bool[] T002O2_n832NotaFiscalItemCFOP ;
      private string[] T002O2_A833NotaFiscalItemDescricao ;
      private bool[] T002O2_n833NotaFiscalItemDescricao ;
      private string[] T002O2_A834NotaFiscalItemNCM ;
      private bool[] T002O2_n834NotaFiscalItemNCM ;
      private string[] T002O2_A835NotaFiscalItemCodigoEAN ;
      private bool[] T002O2_n835NotaFiscalItemCodigoEAN ;
      private string[] T002O2_A836NotaFiscalItemUnidadeComercial ;
      private bool[] T002O2_n836NotaFiscalItemUnidadeComercial ;
      private decimal[] T002O2_A837NotaFiscalItemQuantidade ;
      private bool[] T002O2_n837NotaFiscalItemQuantidade ;
      private decimal[] T002O2_A838NotaFiscalItemValorUnitario ;
      private bool[] T002O2_n838NotaFiscalItemValorUnitario ;
      private decimal[] T002O2_A839NotaFiscalItemValorTotal ;
      private bool[] T002O2_n839NotaFiscalItemValorTotal ;
      private string[] T002O2_A840NotaFiscalItemCodBarGTIN ;
      private bool[] T002O2_n840NotaFiscalItemCodBarGTIN ;
      private string[] T002O2_A841NotaFiscalItemUnidadeTributavel ;
      private bool[] T002O2_n841NotaFiscalItemUnidadeTributavel ;
      private decimal[] T002O2_A842NotaFiscalItemValorUnTributavel ;
      private bool[] T002O2_n842NotaFiscalItemValorUnTributavel ;
      private decimal[] T002O2_A843NotaFiscalItemQtdTributavel ;
      private bool[] T002O2_n843NotaFiscalItemQtdTributavel ;
      private decimal[] T002O2_A844NotaFiscalItemValorFrete ;
      private bool[] T002O2_n844NotaFiscalItemValorFrete ;
      private decimal[] T002O2_A845NotaFiscalItemDesconto ;
      private bool[] T002O2_n845NotaFiscalItemDesconto ;
      private string[] T002O2_A846NotaFiscalItemIndicadorValorTotal ;
      private bool[] T002O2_n846NotaFiscalItemIndicadorValorTotal ;
      private string[] T002O2_A847NotaFiscalItemNumPedido ;
      private bool[] T002O2_n847NotaFiscalItemNumPedido ;
      private string[] T002O2_A848NotaFiscalItemNumItem ;
      private bool[] T002O2_n848NotaFiscalItemNumItem ;
      private string[] T002O2_A851NotaFiscalItemVendido ;
      private bool[] T002O2_n851NotaFiscalItemVendido ;
      private int[] T002O2_A323PropostaId ;
      private bool[] T002O2_n323PropostaId ;
      private Guid[] T002O2_A794NotaFiscalId ;
      private bool[] T002O2_n794NotaFiscalId ;
      private Guid[] T002O15_A830NotaFiscalItemId ;
      private int[] T002O16_A323PropostaId ;
      private bool[] T002O16_n323PropostaId ;
      private Guid[] T002O17_A794NotaFiscalId ;
      private bool[] T002O17_n794NotaFiscalId ;
   }

   public class notafiscalitem__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
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
          Object[] prmT002O2;
          prmT002O2 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002O3;
          prmT002O3 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002O4;
          prmT002O4 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002O5;
          prmT002O5 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002O6;
          prmT002O6 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002O7;
          prmT002O7 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002O8;
          prmT002O8 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002O9;
          prmT002O9 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002O10;
          prmT002O10 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002O11;
          prmT002O11 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002O12;
          prmT002O12 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotaFiscalItemCodigo",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemCFOP",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotaFiscalItemDescricao",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("NotaFiscalItemNCM",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemCodigoEAN",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemUnidadeComercial",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemQuantidade",GXType.Number,18,6){Nullable=true} ,
          new ParDef("NotaFiscalItemValorUnitario",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemValorTotal",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemCodBarGTIN",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalItemUnidadeTributavel",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemValorUnTributavel",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemQtdTributavel",GXType.Number,18,6){Nullable=true} ,
          new ParDef("NotaFiscalItemValorFrete",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemIndicadorValorTotal",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemNumPedido",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemNumItem",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemVendido",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002O13;
          prmT002O13 = new Object[] {
          new ParDef("NotaFiscalItemCodigo",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemCFOP",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotaFiscalItemDescricao",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("NotaFiscalItemNCM",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemCodigoEAN",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemUnidadeComercial",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemQuantidade",GXType.Number,18,6){Nullable=true} ,
          new ParDef("NotaFiscalItemValorUnitario",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemValorTotal",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemCodBarGTIN",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalItemUnidadeTributavel",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemValorUnTributavel",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemQtdTributavel",GXType.Number,18,6){Nullable=true} ,
          new ParDef("NotaFiscalItemValorFrete",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemIndicadorValorTotal",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemNumPedido",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemNumItem",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemVendido",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002O14;
          prmT002O14 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmT002O15;
          prmT002O15 = new Object[] {
          };
          Object[] prmT002O16;
          prmT002O16 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002O17;
          prmT002O17 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T002O2", "SELECT NotaFiscalItemId, NotaFiscalItemCodigo, NotaFiscalItemCFOP, NotaFiscalItemDescricao, NotaFiscalItemNCM, NotaFiscalItemCodigoEAN, NotaFiscalItemUnidadeComercial, NotaFiscalItemQuantidade, NotaFiscalItemValorUnitario, NotaFiscalItemValorTotal, NotaFiscalItemCodBarGTIN, NotaFiscalItemUnidadeTributavel, NotaFiscalItemValorUnTributavel, NotaFiscalItemQtdTributavel, NotaFiscalItemValorFrete, NotaFiscalItemDesconto, NotaFiscalItemIndicadorValorTotal, NotaFiscalItemNumPedido, NotaFiscalItemNumItem, NotaFiscalItemVendido, PropostaId, NotaFiscalId FROM NotaFiscalItem WHERE NotaFiscalItemId = :NotaFiscalItemId  FOR UPDATE OF NotaFiscalItem NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002O2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002O3", "SELECT NotaFiscalItemId, NotaFiscalItemCodigo, NotaFiscalItemCFOP, NotaFiscalItemDescricao, NotaFiscalItemNCM, NotaFiscalItemCodigoEAN, NotaFiscalItemUnidadeComercial, NotaFiscalItemQuantidade, NotaFiscalItemValorUnitario, NotaFiscalItemValorTotal, NotaFiscalItemCodBarGTIN, NotaFiscalItemUnidadeTributavel, NotaFiscalItemValorUnTributavel, NotaFiscalItemQtdTributavel, NotaFiscalItemValorFrete, NotaFiscalItemDesconto, NotaFiscalItemIndicadorValorTotal, NotaFiscalItemNumPedido, NotaFiscalItemNumItem, NotaFiscalItemVendido, PropostaId, NotaFiscalId FROM NotaFiscalItem WHERE NotaFiscalItemId = :NotaFiscalItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002O4", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002O5", "SELECT NotaFiscalId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002O6", "SELECT TM1.NotaFiscalItemId, TM1.NotaFiscalItemCodigo, TM1.NotaFiscalItemCFOP, TM1.NotaFiscalItemDescricao, TM1.NotaFiscalItemNCM, TM1.NotaFiscalItemCodigoEAN, TM1.NotaFiscalItemUnidadeComercial, TM1.NotaFiscalItemQuantidade, TM1.NotaFiscalItemValorUnitario, TM1.NotaFiscalItemValorTotal, TM1.NotaFiscalItemCodBarGTIN, TM1.NotaFiscalItemUnidadeTributavel, TM1.NotaFiscalItemValorUnTributavel, TM1.NotaFiscalItemQtdTributavel, TM1.NotaFiscalItemValorFrete, TM1.NotaFiscalItemDesconto, TM1.NotaFiscalItemIndicadorValorTotal, TM1.NotaFiscalItemNumPedido, TM1.NotaFiscalItemNumItem, TM1.NotaFiscalItemVendido, TM1.PropostaId, TM1.NotaFiscalId FROM NotaFiscalItem TM1 WHERE TM1.NotaFiscalItemId = :NotaFiscalItemId ORDER BY TM1.NotaFiscalItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002O7", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002O8", "SELECT NotaFiscalId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002O9", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE NotaFiscalItemId = :NotaFiscalItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002O10", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE ( NotaFiscalItemId > :NotaFiscalItemId) ORDER BY NotaFiscalItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002O11", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE ( NotaFiscalItemId < :NotaFiscalItemId) ORDER BY NotaFiscalItemId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002O12", "SAVEPOINT gxupdate;INSERT INTO NotaFiscalItem(NotaFiscalItemId, NotaFiscalItemCodigo, NotaFiscalItemCFOP, NotaFiscalItemDescricao, NotaFiscalItemNCM, NotaFiscalItemCodigoEAN, NotaFiscalItemUnidadeComercial, NotaFiscalItemQuantidade, NotaFiscalItemValorUnitario, NotaFiscalItemValorTotal, NotaFiscalItemCodBarGTIN, NotaFiscalItemUnidadeTributavel, NotaFiscalItemValorUnTributavel, NotaFiscalItemQtdTributavel, NotaFiscalItemValorFrete, NotaFiscalItemDesconto, NotaFiscalItemIndicadorValorTotal, NotaFiscalItemNumPedido, NotaFiscalItemNumItem, NotaFiscalItemVendido, PropostaId, NotaFiscalId) VALUES(:NotaFiscalItemId, :NotaFiscalItemCodigo, :NotaFiscalItemCFOP, :NotaFiscalItemDescricao, :NotaFiscalItemNCM, :NotaFiscalItemCodigoEAN, :NotaFiscalItemUnidadeComercial, :NotaFiscalItemQuantidade, :NotaFiscalItemValorUnitario, :NotaFiscalItemValorTotal, :NotaFiscalItemCodBarGTIN, :NotaFiscalItemUnidadeTributavel, :NotaFiscalItemValorUnTributavel, :NotaFiscalItemQtdTributavel, :NotaFiscalItemValorFrete, :NotaFiscalItemDesconto, :NotaFiscalItemIndicadorValorTotal, :NotaFiscalItemNumPedido, :NotaFiscalItemNumItem, :NotaFiscalItemVendido, :PropostaId, :NotaFiscalId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002O12)
             ,new CursorDef("T002O13", "SAVEPOINT gxupdate;UPDATE NotaFiscalItem SET NotaFiscalItemCodigo=:NotaFiscalItemCodigo, NotaFiscalItemCFOP=:NotaFiscalItemCFOP, NotaFiscalItemDescricao=:NotaFiscalItemDescricao, NotaFiscalItemNCM=:NotaFiscalItemNCM, NotaFiscalItemCodigoEAN=:NotaFiscalItemCodigoEAN, NotaFiscalItemUnidadeComercial=:NotaFiscalItemUnidadeComercial, NotaFiscalItemQuantidade=:NotaFiscalItemQuantidade, NotaFiscalItemValorUnitario=:NotaFiscalItemValorUnitario, NotaFiscalItemValorTotal=:NotaFiscalItemValorTotal, NotaFiscalItemCodBarGTIN=:NotaFiscalItemCodBarGTIN, NotaFiscalItemUnidadeTributavel=:NotaFiscalItemUnidadeTributavel, NotaFiscalItemValorUnTributavel=:NotaFiscalItemValorUnTributavel, NotaFiscalItemQtdTributavel=:NotaFiscalItemQtdTributavel, NotaFiscalItemValorFrete=:NotaFiscalItemValorFrete, NotaFiscalItemDesconto=:NotaFiscalItemDesconto, NotaFiscalItemIndicadorValorTotal=:NotaFiscalItemIndicadorValorTotal, NotaFiscalItemNumPedido=:NotaFiscalItemNumPedido, NotaFiscalItemNumItem=:NotaFiscalItemNumItem, NotaFiscalItemVendido=:NotaFiscalItemVendido, PropostaId=:PropostaId, NotaFiscalId=:NotaFiscalId  WHERE NotaFiscalItemId = :NotaFiscalItemId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002O13)
             ,new CursorDef("T002O14", "SAVEPOINT gxupdate;DELETE FROM NotaFiscalItem  WHERE NotaFiscalItemId = :NotaFiscalItemId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002O14)
             ,new CursorDef("T002O15", "SELECT NotaFiscalItemId FROM NotaFiscalItem ORDER BY NotaFiscalItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002O16", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002O17", "SELECT NotaFiscalId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O17,1, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((Guid[]) buf[41])[0] = rslt.getGuid(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((Guid[]) buf[41])[0] = rslt.getGuid(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((Guid[]) buf[41])[0] = rslt.getGuid(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 7 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 8 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 9 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 13 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
