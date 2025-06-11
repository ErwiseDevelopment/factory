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
   public class notafiscalparcelamento : GXDataArea
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
            A794NotaFiscalId = StringUtil.StrToGuid( GetPar( "NotaFiscalId"));
            n794NotaFiscalId = false;
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A794NotaFiscalId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "notafiscalparcelamento")), "notafiscalparcelamento") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "notafiscalparcelamento")))) ;
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
                  AV7NotaFiscalParcelamentoID = StringUtil.StrToGuid( GetPar( "NotaFiscalParcelamentoID"));
                  AssignAttri("", false, "AV7NotaFiscalParcelamentoID", AV7NotaFiscalParcelamentoID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vNOTAFISCALPARCELAMENTOID", GetSecureSignedToken( "", AV7NotaFiscalParcelamentoID, context));
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
         Form.Meta.addItem("description", "Nota Fiscal Parcelamento", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNotaFiscalParcelamentoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public notafiscalparcelamento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notafiscalparcelamento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_NotaFiscalParcelamentoID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7NotaFiscalParcelamentoID = aP1_NotaFiscalParcelamentoID;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalParcelamentoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalParcelamentoID_Internalname, "Parcelamento ID", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalParcelamentoID_Internalname, A890NotaFiscalParcelamentoID.ToString(), A890NotaFiscalParcelamentoID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalParcelamentoID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNotaFiscalParcelamentoID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_NotaFiscalParcelamento.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblocknotafiscalid_Internalname, "Nota Fiscal", "", "", lblTextblocknotafiscalid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_NotaFiscalParcelamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_notafiscalid.SetProperty("Caption", Combo_notafiscalid_Caption);
         ucCombo_notafiscalid.SetProperty("Cls", Combo_notafiscalid_Cls);
         ucCombo_notafiscalid.SetProperty("DataListProc", Combo_notafiscalid_Datalistproc);
         ucCombo_notafiscalid.SetProperty("DataListProcParametersPrefix", Combo_notafiscalid_Datalistprocparametersprefix);
         ucCombo_notafiscalid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_notafiscalid.SetProperty("DropDownOptionsData", AV13NotaFiscalId_Data);
         ucCombo_notafiscalid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_notafiscalid_Internalname, "COMBO_NOTAFISCALIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalId_Internalname, "Nota Fiscal Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalId_Internalname, A794NotaFiscalId.ToString(), A794NotaFiscalId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalId_Jsonclick, 0, "Attribute", "", "", "", "", edtNotaFiscalId_Visible, edtNotaFiscalId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_NotaFiscalParcelamento.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalNumero_Internalname, "Nota Fiscal Numero", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalNumero_Internalname, A799NotaFiscalNumero, StringUtil.RTrim( context.localUtil.Format( A799NotaFiscalNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNotaFiscalNumero_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscalParcelamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalParcelamentoNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalParcelamentoNumero_Internalname, "Parcelamento Numero", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalParcelamentoNumero_Internalname, A891NotaFiscalParcelamentoNumero, StringUtil.RTrim( context.localUtil.Format( A891NotaFiscalParcelamentoNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalParcelamentoNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNotaFiscalParcelamentoNumero_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotaFiscalParcelamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalParcelamentoValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalParcelamentoValor_Internalname, "Parcelamento Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalParcelamentoValor_Internalname, ((Convert.ToDecimal(0)==A892NotaFiscalParcelamentoValor)&&IsIns( )||n892NotaFiscalParcelamentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A892NotaFiscalParcelamentoValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A892NotaFiscalParcelamentoValor)&&IsIns( )||n892NotaFiscalParcelamentoValor ? "" : StringUtil.LTrim( ((edtNotaFiscalParcelamentoValor_Enabled!=0) ? context.localUtil.Format( A892NotaFiscalParcelamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A892NotaFiscalParcelamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalParcelamentoValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNotaFiscalParcelamentoValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_NotaFiscalParcelamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotaFiscalParcelamentoVencimento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotaFiscalParcelamentoVencimento_Internalname, "Parcelamento Vencimento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNotaFiscalParcelamentoVencimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNotaFiscalParcelamentoVencimento_Internalname, context.localUtil.Format(A893NotaFiscalParcelamentoVencimento, "99/99/9999"), context.localUtil.Format( A893NotaFiscalParcelamentoVencimento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotaFiscalParcelamentoVencimento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNotaFiscalParcelamentoVencimento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotaFiscalParcelamento.htm");
         GxWebStd.gx_bitmap( context, edtNotaFiscalParcelamentoVencimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNotaFiscalParcelamentoVencimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_NotaFiscalParcelamento.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscalParcelamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscalParcelamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotaFiscalParcelamento.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_notafiscalid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombonotafiscalid_Internalname, AV18ComboNotaFiscalId.ToString(), AV18ComboNotaFiscalId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombonotafiscalid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombonotafiscalid_Visible, edtavCombonotafiscalid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_NotaFiscalParcelamento.htm");
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
         E112T2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vNOTAFISCALID_DATA"), AV13NotaFiscalId_Data);
               /* Read saved values. */
               Z890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( "Z890NotaFiscalParcelamentoID"));
               Z891NotaFiscalParcelamentoNumero = cgiGet( "Z891NotaFiscalParcelamentoNumero");
               n891NotaFiscalParcelamentoNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A891NotaFiscalParcelamentoNumero)) ? true : false);
               Z892NotaFiscalParcelamentoValor = context.localUtil.CToN( cgiGet( "Z892NotaFiscalParcelamentoValor"), ",", ".");
               n892NotaFiscalParcelamentoValor = ((Convert.ToDecimal(0)==A892NotaFiscalParcelamentoValor) ? true : false);
               Z893NotaFiscalParcelamentoVencimento = context.localUtil.CToD( cgiGet( "Z893NotaFiscalParcelamentoVencimento"), 0);
               n893NotaFiscalParcelamentoVencimento = ((DateTime.MinValue==A893NotaFiscalParcelamentoVencimento) ? true : false);
               Z895NotaFiscalParcelamentoValorTaxaAdministrativa = context.localUtil.CToN( cgiGet( "Z895NotaFiscalParcelamentoValorTaxaAdministrativa"), ",", ".");
               n895NotaFiscalParcelamentoValorTaxaAdministrativa = ((Convert.ToDecimal(0)==A895NotaFiscalParcelamentoValorTaxaAdministrativa) ? true : false);
               Z896NotaFiscalParcelamentoValorTaxaAnual = context.localUtil.CToN( cgiGet( "Z896NotaFiscalParcelamentoValorTaxaAnual"), ",", ".");
               n896NotaFiscalParcelamentoValorTaxaAnual = ((Convert.ToDecimal(0)==A896NotaFiscalParcelamentoValorTaxaAnual) ? true : false);
               Z897NotaFiscalParcelamentoLiquido = context.localUtil.CToN( cgiGet( "Z897NotaFiscalParcelamentoLiquido"), ",", ".");
               n897NotaFiscalParcelamentoLiquido = ((Convert.ToDecimal(0)==A897NotaFiscalParcelamentoLiquido) ? true : false);
               Z794NotaFiscalId = StringUtil.StrToGuid( cgiGet( "Z794NotaFiscalId"));
               n794NotaFiscalId = ((Guid.Empty==A794NotaFiscalId) ? true : false);
               A895NotaFiscalParcelamentoValorTaxaAdministrativa = context.localUtil.CToN( cgiGet( "Z895NotaFiscalParcelamentoValorTaxaAdministrativa"), ",", ".");
               n895NotaFiscalParcelamentoValorTaxaAdministrativa = false;
               n895NotaFiscalParcelamentoValorTaxaAdministrativa = ((Convert.ToDecimal(0)==A895NotaFiscalParcelamentoValorTaxaAdministrativa) ? true : false);
               A896NotaFiscalParcelamentoValorTaxaAnual = context.localUtil.CToN( cgiGet( "Z896NotaFiscalParcelamentoValorTaxaAnual"), ",", ".");
               n896NotaFiscalParcelamentoValorTaxaAnual = false;
               n896NotaFiscalParcelamentoValorTaxaAnual = ((Convert.ToDecimal(0)==A896NotaFiscalParcelamentoValorTaxaAnual) ? true : false);
               A897NotaFiscalParcelamentoLiquido = context.localUtil.CToN( cgiGet( "Z897NotaFiscalParcelamentoLiquido"), ",", ".");
               n897NotaFiscalParcelamentoLiquido = false;
               n897NotaFiscalParcelamentoLiquido = ((Convert.ToDecimal(0)==A897NotaFiscalParcelamentoLiquido) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N794NotaFiscalId = StringUtil.StrToGuid( cgiGet( "N794NotaFiscalId"));
               n794NotaFiscalId = ((Guid.Empty==A794NotaFiscalId) ? true : false);
               AV7NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( "vNOTAFISCALPARCELAMENTOID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_NotaFiscalId = StringUtil.StrToGuid( cgiGet( "vINSERT_NOTAFISCALID"));
               AssignAttri("", false, "AV11Insert_NotaFiscalId", AV11Insert_NotaFiscalId.ToString());
               A895NotaFiscalParcelamentoValorTaxaAdministrativa = context.localUtil.CToN( cgiGet( "NOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA"), ",", ".");
               n895NotaFiscalParcelamentoValorTaxaAdministrativa = ((Convert.ToDecimal(0)==A895NotaFiscalParcelamentoValorTaxaAdministrativa) ? true : false);
               A896NotaFiscalParcelamentoValorTaxaAnual = context.localUtil.CToN( cgiGet( "NOTAFISCALPARCELAMENTOVALORTAXAANUAL"), ",", ".");
               n896NotaFiscalParcelamentoValorTaxaAnual = ((Convert.ToDecimal(0)==A896NotaFiscalParcelamentoValorTaxaAnual) ? true : false);
               A897NotaFiscalParcelamentoLiquido = context.localUtil.CToN( cgiGet( "NOTAFISCALPARCELAMENTOLIQUIDO"), ",", ".");
               n897NotaFiscalParcelamentoLiquido = ((Convert.ToDecimal(0)==A897NotaFiscalParcelamentoLiquido) ? true : false);
               AV19Pgmname = cgiGet( "vPGMNAME");
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
               if ( StringUtil.StrCmp(cgiGet( edtNotaFiscalParcelamentoID_Internalname), "") == 0 )
               {
                  A890NotaFiscalParcelamentoID = Guid.Empty;
                  n890NotaFiscalParcelamentoID = true;
                  AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
               }
               else
               {
                  try
                  {
                     A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( edtNotaFiscalParcelamentoID_Internalname));
                     n890NotaFiscalParcelamentoID = false;
                     AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "NOTAFISCALPARCELAMENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtNotaFiscalParcelamentoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
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
               A799NotaFiscalNumero = cgiGet( edtNotaFiscalNumero_Internalname);
               n799NotaFiscalNumero = false;
               AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
               A891NotaFiscalParcelamentoNumero = cgiGet( edtNotaFiscalParcelamentoNumero_Internalname);
               n891NotaFiscalParcelamentoNumero = false;
               AssignAttri("", false, "A891NotaFiscalParcelamentoNumero", A891NotaFiscalParcelamentoNumero);
               n891NotaFiscalParcelamentoNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A891NotaFiscalParcelamentoNumero)) ? true : false);
               n892NotaFiscalParcelamentoValor = ((StringUtil.StrCmp(cgiGet( edtNotaFiscalParcelamentoValor_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtNotaFiscalParcelamentoValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNotaFiscalParcelamentoValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NOTAFISCALPARCELAMENTOVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtNotaFiscalParcelamentoValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A892NotaFiscalParcelamentoValor = 0;
                  n892NotaFiscalParcelamentoValor = false;
                  AssignAttri("", false, "A892NotaFiscalParcelamentoValor", (n892NotaFiscalParcelamentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A892NotaFiscalParcelamentoValor, 18, 2, ".", ""))));
               }
               else
               {
                  A892NotaFiscalParcelamentoValor = context.localUtil.CToN( cgiGet( edtNotaFiscalParcelamentoValor_Internalname), ",", ".");
                  AssignAttri("", false, "A892NotaFiscalParcelamentoValor", (n892NotaFiscalParcelamentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A892NotaFiscalParcelamentoValor, 18, 2, ".", ""))));
               }
               if ( context.localUtil.VCDate( cgiGet( edtNotaFiscalParcelamentoVencimento_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Nota Fiscal Parcelamento Vencimento"}), 1, "NOTAFISCALPARCELAMENTOVENCIMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtNotaFiscalParcelamentoVencimento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A893NotaFiscalParcelamentoVencimento = DateTime.MinValue;
                  n893NotaFiscalParcelamentoVencimento = false;
                  AssignAttri("", false, "A893NotaFiscalParcelamentoVencimento", context.localUtil.Format(A893NotaFiscalParcelamentoVencimento, "99/99/9999"));
               }
               else
               {
                  A893NotaFiscalParcelamentoVencimento = context.localUtil.CToD( cgiGet( edtNotaFiscalParcelamentoVencimento_Internalname), 2);
                  n893NotaFiscalParcelamentoVencimento = false;
                  AssignAttri("", false, "A893NotaFiscalParcelamentoVencimento", context.localUtil.Format(A893NotaFiscalParcelamentoVencimento, "99/99/9999"));
               }
               n893NotaFiscalParcelamentoVencimento = ((DateTime.MinValue==A893NotaFiscalParcelamentoVencimento) ? true : false);
               AV18ComboNotaFiscalId = StringUtil.StrToGuid( cgiGet( edtavCombonotafiscalid_Internalname));
               AssignAttri("", false, "AV18ComboNotaFiscalId", AV18ComboNotaFiscalId.ToString());
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"NotaFiscalParcelamento");
               forbiddenHiddens.Add("Insert_NotaFiscalId", AV11Insert_NotaFiscalId.ToString());
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("NotaFiscalParcelamentoValorTaxaAdministrativa", context.localUtil.Format( A895NotaFiscalParcelamentoValorTaxaAdministrativa, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("NotaFiscalParcelamentoValorTaxaAnual", context.localUtil.Format( A896NotaFiscalParcelamentoValorTaxaAnual, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("NotaFiscalParcelamentoLiquido", context.localUtil.Format( A897NotaFiscalParcelamentoLiquido, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A890NotaFiscalParcelamentoID != Z890NotaFiscalParcelamentoID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("notafiscalparcelamento:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( GetPar( "NotaFiscalParcelamentoID"));
                  n890NotaFiscalParcelamentoID = false;
                  AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7NotaFiscalParcelamentoID) )
                  {
                     A890NotaFiscalParcelamentoID = AV7NotaFiscalParcelamentoID;
                     n890NotaFiscalParcelamentoID = false;
                     AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A890NotaFiscalParcelamentoID) && ( Gx_BScreen == 0 ) )
                     {
                        A890NotaFiscalParcelamentoID = Guid.NewGuid( );
                        n890NotaFiscalParcelamentoID = false;
                        AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
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
                     sMode97 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7NotaFiscalParcelamentoID) )
                     {
                        A890NotaFiscalParcelamentoID = AV7NotaFiscalParcelamentoID;
                        n890NotaFiscalParcelamentoID = false;
                        AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A890NotaFiscalParcelamentoID) && ( Gx_BScreen == 0 ) )
                        {
                           A890NotaFiscalParcelamentoID = Guid.NewGuid( );
                           n890NotaFiscalParcelamentoID = false;
                           AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
                        }
                     }
                     Gx_mode = sMode97;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound97 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2T0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "NOTAFISCALPARCELAMENTOID");
                        AnyError = 1;
                        GX_FocusControl = edtNotaFiscalParcelamentoID_Internalname;
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
                           E122T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E112T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E132T2 ();
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
            E132T2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2T97( ) ;
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
            DisableAttributes2T97( ) ;
         }
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

      protected void CONFIRM_2T0( )
      {
         BeforeValidate2T97( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2T97( ) ;
            }
            else
            {
               CheckExtendedTable2T97( ) ;
               CloseExtendedTableCursors2T97( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2T0( )
      {
      }

      protected void E112T2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtNotaFiscalId_Visible = 0;
         AssignProp("", false, edtNotaFiscalId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNotaFiscalId_Visible), 5, 0), true);
         AV18ComboNotaFiscalId = Guid.Empty;
         AssignAttri("", false, "AV18ComboNotaFiscalId", AV18ComboNotaFiscalId.ToString());
         edtavCombonotafiscalid_Visible = 0;
         AssignProp("", false, edtavCombonotafiscalid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombonotafiscalid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBONOTAFISCALID' */
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
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "NotaFiscalId") == 0 )
               {
                  AV11Insert_NotaFiscalId = StringUtil.StrToGuid( AV12TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV11Insert_NotaFiscalId", AV11Insert_NotaFiscalId.ToString());
                  if ( ! (Guid.Empty==AV11Insert_NotaFiscalId) )
                  {
                     AV18ComboNotaFiscalId = AV11Insert_NotaFiscalId;
                     AssignAttri("", false, "AV18ComboNotaFiscalId", AV18ComboNotaFiscalId.ToString());
                     Combo_notafiscalid_Selectedvalue_set = StringUtil.Trim( AV18ComboNotaFiscalId.ToString());
                     ucCombo_notafiscalid.SendProperty(context, "", false, Combo_notafiscalid_Internalname, "SelectedValue_set", Combo_notafiscalid_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new notafiscalparcelamentoloaddvcombo(context ).execute(  "NotaFiscalId",  "GET",  false,  AV7NotaFiscalParcelamentoID,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_notafiscalid_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_notafiscalid.SendProperty(context, "", false, Combo_notafiscalid_Internalname, "SelectedText_set", Combo_notafiscalid_Selectedtext_set);
                     Combo_notafiscalid_Enabled = false;
                     ucCombo_notafiscalid.SendProperty(context, "", false, Combo_notafiscalid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_notafiscalid_Enabled));
                  }
               }
               AV20GXV1 = (int)(AV20GXV1+1);
               AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            }
         }
      }

      protected void E132T2( )
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

      protected void E122T2( )
      {
         /* Combo_notafiscalid_Onoptionclicked Routine */
         returnInSub = false;
         AV18ComboNotaFiscalId = StringUtil.StrToGuid( Combo_notafiscalid_Selectedvalue_get);
         AssignAttri("", false, "AV18ComboNotaFiscalId", AV18ComboNotaFiscalId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADCOMBONOTAFISCALID' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new notafiscalparcelamentoloaddvcombo(context ).execute(  "NotaFiscalId",  Gx_mode,  false,  AV7NotaFiscalParcelamentoID,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_notafiscalid_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_notafiscalid.SendProperty(context, "", false, Combo_notafiscalid_Internalname, "SelectedValue_set", Combo_notafiscalid_Selectedvalue_set);
         Combo_notafiscalid_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_notafiscalid.SendProperty(context, "", false, Combo_notafiscalid_Internalname, "SelectedText_set", Combo_notafiscalid_Selectedtext_set);
         AV18ComboNotaFiscalId = StringUtil.StrToGuid( AV15ComboSelectedValue);
         AssignAttri("", false, "AV18ComboNotaFiscalId", AV18ComboNotaFiscalId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_notafiscalid_Enabled = false;
            ucCombo_notafiscalid.SendProperty(context, "", false, Combo_notafiscalid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_notafiscalid_Enabled));
         }
      }

      protected void ZM2T97( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z891NotaFiscalParcelamentoNumero = T002T3_A891NotaFiscalParcelamentoNumero[0];
               Z892NotaFiscalParcelamentoValor = T002T3_A892NotaFiscalParcelamentoValor[0];
               Z893NotaFiscalParcelamentoVencimento = T002T3_A893NotaFiscalParcelamentoVencimento[0];
               Z895NotaFiscalParcelamentoValorTaxaAdministrativa = T002T3_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
               Z896NotaFiscalParcelamentoValorTaxaAnual = T002T3_A896NotaFiscalParcelamentoValorTaxaAnual[0];
               Z897NotaFiscalParcelamentoLiquido = T002T3_A897NotaFiscalParcelamentoLiquido[0];
               Z794NotaFiscalId = T002T3_A794NotaFiscalId[0];
            }
            else
            {
               Z891NotaFiscalParcelamentoNumero = A891NotaFiscalParcelamentoNumero;
               Z892NotaFiscalParcelamentoValor = A892NotaFiscalParcelamentoValor;
               Z893NotaFiscalParcelamentoVencimento = A893NotaFiscalParcelamentoVencimento;
               Z895NotaFiscalParcelamentoValorTaxaAdministrativa = A895NotaFiscalParcelamentoValorTaxaAdministrativa;
               Z896NotaFiscalParcelamentoValorTaxaAnual = A896NotaFiscalParcelamentoValorTaxaAnual;
               Z897NotaFiscalParcelamentoLiquido = A897NotaFiscalParcelamentoLiquido;
               Z794NotaFiscalId = A794NotaFiscalId;
            }
         }
         if ( GX_JID == -14 )
         {
            Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
            Z891NotaFiscalParcelamentoNumero = A891NotaFiscalParcelamentoNumero;
            Z892NotaFiscalParcelamentoValor = A892NotaFiscalParcelamentoValor;
            Z893NotaFiscalParcelamentoVencimento = A893NotaFiscalParcelamentoVencimento;
            Z895NotaFiscalParcelamentoValorTaxaAdministrativa = A895NotaFiscalParcelamentoValorTaxaAdministrativa;
            Z896NotaFiscalParcelamentoValorTaxaAnual = A896NotaFiscalParcelamentoValorTaxaAnual;
            Z897NotaFiscalParcelamentoLiquido = A897NotaFiscalParcelamentoLiquido;
            Z794NotaFiscalId = A794NotaFiscalId;
            Z799NotaFiscalNumero = A799NotaFiscalNumero;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV19Pgmname = "NotaFiscalParcelamento";
         AssignAttri("", false, "AV19Pgmname", AV19Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7NotaFiscalParcelamentoID) )
         {
            edtNotaFiscalParcelamentoID_Enabled = 0;
            AssignProp("", false, edtNotaFiscalParcelamentoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalParcelamentoID_Enabled), 5, 0), true);
         }
         else
         {
            edtNotaFiscalParcelamentoID_Enabled = 1;
            AssignProp("", false, edtNotaFiscalParcelamentoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalParcelamentoID_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7NotaFiscalParcelamentoID) )
         {
            edtNotaFiscalParcelamentoID_Enabled = 0;
            AssignProp("", false, edtNotaFiscalParcelamentoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalParcelamentoID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV11Insert_NotaFiscalId) )
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV11Insert_NotaFiscalId) )
         {
            A794NotaFiscalId = AV11Insert_NotaFiscalId;
            n794NotaFiscalId = false;
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV18ComboNotaFiscalId) )
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
               if ( ! (Guid.Empty==AV18ComboNotaFiscalId) )
               {
                  A794NotaFiscalId = AV18ComboNotaFiscalId;
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
         if ( ! (Guid.Empty==AV7NotaFiscalParcelamentoID) )
         {
            A890NotaFiscalParcelamentoID = AV7NotaFiscalParcelamentoID;
            n890NotaFiscalParcelamentoID = false;
            AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A890NotaFiscalParcelamentoID) && ( Gx_BScreen == 0 ) )
            {
               A890NotaFiscalParcelamentoID = Guid.NewGuid( );
               n890NotaFiscalParcelamentoID = false;
               AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T002T4 */
            pr_default.execute(2, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            A799NotaFiscalNumero = T002T4_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = T002T4_n799NotaFiscalNumero[0];
            AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
            pr_default.close(2);
         }
      }

      protected void Load2T97( )
      {
         /* Using cursor T002T5 */
         pr_default.execute(3, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound97 = 1;
            A799NotaFiscalNumero = T002T5_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = T002T5_n799NotaFiscalNumero[0];
            AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
            A891NotaFiscalParcelamentoNumero = T002T5_A891NotaFiscalParcelamentoNumero[0];
            n891NotaFiscalParcelamentoNumero = T002T5_n891NotaFiscalParcelamentoNumero[0];
            AssignAttri("", false, "A891NotaFiscalParcelamentoNumero", A891NotaFiscalParcelamentoNumero);
            A892NotaFiscalParcelamentoValor = T002T5_A892NotaFiscalParcelamentoValor[0];
            n892NotaFiscalParcelamentoValor = T002T5_n892NotaFiscalParcelamentoValor[0];
            AssignAttri("", false, "A892NotaFiscalParcelamentoValor", ((Convert.ToDecimal(0)==A892NotaFiscalParcelamentoValor)&&IsIns( )||n892NotaFiscalParcelamentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A892NotaFiscalParcelamentoValor, 18, 2, ".", ""))));
            A893NotaFiscalParcelamentoVencimento = T002T5_A893NotaFiscalParcelamentoVencimento[0];
            n893NotaFiscalParcelamentoVencimento = T002T5_n893NotaFiscalParcelamentoVencimento[0];
            AssignAttri("", false, "A893NotaFiscalParcelamentoVencimento", context.localUtil.Format(A893NotaFiscalParcelamentoVencimento, "99/99/9999"));
            A895NotaFiscalParcelamentoValorTaxaAdministrativa = T002T5_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            n895NotaFiscalParcelamentoValorTaxaAdministrativa = T002T5_n895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            A896NotaFiscalParcelamentoValorTaxaAnual = T002T5_A896NotaFiscalParcelamentoValorTaxaAnual[0];
            n896NotaFiscalParcelamentoValorTaxaAnual = T002T5_n896NotaFiscalParcelamentoValorTaxaAnual[0];
            A897NotaFiscalParcelamentoLiquido = T002T5_A897NotaFiscalParcelamentoLiquido[0];
            n897NotaFiscalParcelamentoLiquido = T002T5_n897NotaFiscalParcelamentoLiquido[0];
            A794NotaFiscalId = T002T5_A794NotaFiscalId[0];
            n794NotaFiscalId = T002T5_n794NotaFiscalId[0];
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            ZM2T97( -14) ;
         }
         pr_default.close(3);
         OnLoadActions2T97( ) ;
      }

      protected void OnLoadActions2T97( )
      {
      }

      protected void CheckExtendedTable2T97( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T002T4 */
         pr_default.execute(2, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
               GX_FocusControl = edtNotaFiscalId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A799NotaFiscalNumero = T002T4_A799NotaFiscalNumero[0];
         n799NotaFiscalNumero = T002T4_n799NotaFiscalNumero[0];
         AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
         pr_default.close(2);
         if ( ( A892NotaFiscalParcelamentoValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "NOTAFISCALPARCELAMENTOVALOR");
            AnyError = 1;
            GX_FocusControl = edtNotaFiscalParcelamentoValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A895NotaFiscalParcelamentoValorTaxaAdministrativa < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A896NotaFiscalParcelamentoValorTaxaAnual < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2T97( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( Guid A794NotaFiscalId )
      {
         /* Using cursor T002T6 */
         pr_default.execute(4, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
               GX_FocusControl = edtNotaFiscalId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A799NotaFiscalNumero = T002T6_A799NotaFiscalNumero[0];
         n799NotaFiscalNumero = T002T6_n799NotaFiscalNumero[0];
         AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A799NotaFiscalNumero)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey2T97( )
      {
         /* Using cursor T002T7 */
         pr_default.execute(5, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound97 = 1;
         }
         else
         {
            RcdFound97 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002T3 */
         pr_default.execute(1, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2T97( 14) ;
            RcdFound97 = 1;
            A890NotaFiscalParcelamentoID = T002T3_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = T002T3_n890NotaFiscalParcelamentoID[0];
            AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
            A891NotaFiscalParcelamentoNumero = T002T3_A891NotaFiscalParcelamentoNumero[0];
            n891NotaFiscalParcelamentoNumero = T002T3_n891NotaFiscalParcelamentoNumero[0];
            AssignAttri("", false, "A891NotaFiscalParcelamentoNumero", A891NotaFiscalParcelamentoNumero);
            A892NotaFiscalParcelamentoValor = T002T3_A892NotaFiscalParcelamentoValor[0];
            n892NotaFiscalParcelamentoValor = T002T3_n892NotaFiscalParcelamentoValor[0];
            AssignAttri("", false, "A892NotaFiscalParcelamentoValor", ((Convert.ToDecimal(0)==A892NotaFiscalParcelamentoValor)&&IsIns( )||n892NotaFiscalParcelamentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A892NotaFiscalParcelamentoValor, 18, 2, ".", ""))));
            A893NotaFiscalParcelamentoVencimento = T002T3_A893NotaFiscalParcelamentoVencimento[0];
            n893NotaFiscalParcelamentoVencimento = T002T3_n893NotaFiscalParcelamentoVencimento[0];
            AssignAttri("", false, "A893NotaFiscalParcelamentoVencimento", context.localUtil.Format(A893NotaFiscalParcelamentoVencimento, "99/99/9999"));
            A895NotaFiscalParcelamentoValorTaxaAdministrativa = T002T3_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            n895NotaFiscalParcelamentoValorTaxaAdministrativa = T002T3_n895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            A896NotaFiscalParcelamentoValorTaxaAnual = T002T3_A896NotaFiscalParcelamentoValorTaxaAnual[0];
            n896NotaFiscalParcelamentoValorTaxaAnual = T002T3_n896NotaFiscalParcelamentoValorTaxaAnual[0];
            A897NotaFiscalParcelamentoLiquido = T002T3_A897NotaFiscalParcelamentoLiquido[0];
            n897NotaFiscalParcelamentoLiquido = T002T3_n897NotaFiscalParcelamentoLiquido[0];
            A794NotaFiscalId = T002T3_A794NotaFiscalId[0];
            n794NotaFiscalId = T002T3_n794NotaFiscalId[0];
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
            sMode97 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2T97( ) ;
            if ( AnyError == 1 )
            {
               RcdFound97 = 0;
               InitializeNonKey2T97( ) ;
            }
            Gx_mode = sMode97;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound97 = 0;
            InitializeNonKey2T97( ) ;
            sMode97 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode97;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2T97( ) ;
         if ( RcdFound97 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound97 = 0;
         /* Using cursor T002T8 */
         pr_default.execute(6, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T002T8_A890NotaFiscalParcelamentoID[0], A890NotaFiscalParcelamentoID, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T002T8_A890NotaFiscalParcelamentoID[0], A890NotaFiscalParcelamentoID, 0) > 0 ) ) )
            {
               A890NotaFiscalParcelamentoID = T002T8_A890NotaFiscalParcelamentoID[0];
               n890NotaFiscalParcelamentoID = T002T8_n890NotaFiscalParcelamentoID[0];
               AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
               RcdFound97 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound97 = 0;
         /* Using cursor T002T9 */
         pr_default.execute(7, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T002T9_A890NotaFiscalParcelamentoID[0], A890NotaFiscalParcelamentoID, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T002T9_A890NotaFiscalParcelamentoID[0], A890NotaFiscalParcelamentoID, 0) < 0 ) ) )
            {
               A890NotaFiscalParcelamentoID = T002T9_A890NotaFiscalParcelamentoID[0];
               n890NotaFiscalParcelamentoID = T002T9_n890NotaFiscalParcelamentoID[0];
               AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
               RcdFound97 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2T97( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNotaFiscalParcelamentoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2T97( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound97 == 1 )
            {
               if ( A890NotaFiscalParcelamentoID != Z890NotaFiscalParcelamentoID )
               {
                  A890NotaFiscalParcelamentoID = Z890NotaFiscalParcelamentoID;
                  n890NotaFiscalParcelamentoID = false;
                  AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "NOTAFISCALPARCELAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtNotaFiscalParcelamentoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNotaFiscalParcelamentoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2T97( ) ;
                  GX_FocusControl = edtNotaFiscalParcelamentoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A890NotaFiscalParcelamentoID != Z890NotaFiscalParcelamentoID )
               {
                  /* Insert record */
                  GX_FocusControl = edtNotaFiscalParcelamentoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2T97( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "NOTAFISCALPARCELAMENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtNotaFiscalParcelamentoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtNotaFiscalParcelamentoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2T97( ) ;
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
         if ( A890NotaFiscalParcelamentoID != Z890NotaFiscalParcelamentoID )
         {
            A890NotaFiscalParcelamentoID = Z890NotaFiscalParcelamentoID;
            n890NotaFiscalParcelamentoID = false;
            AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "NOTAFISCALPARCELAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtNotaFiscalParcelamentoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNotaFiscalParcelamentoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2T97( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002T2 */
            pr_default.execute(0, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscalParcelamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z891NotaFiscalParcelamentoNumero, T002T2_A891NotaFiscalParcelamentoNumero[0]) != 0 ) || ( Z892NotaFiscalParcelamentoValor != T002T2_A892NotaFiscalParcelamentoValor[0] ) || ( DateTimeUtil.ResetTime ( Z893NotaFiscalParcelamentoVencimento ) != DateTimeUtil.ResetTime ( T002T2_A893NotaFiscalParcelamentoVencimento[0] ) ) || ( Z895NotaFiscalParcelamentoValorTaxaAdministrativa != T002T2_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0] ) || ( Z896NotaFiscalParcelamentoValorTaxaAnual != T002T2_A896NotaFiscalParcelamentoValorTaxaAnual[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z897NotaFiscalParcelamentoLiquido != T002T2_A897NotaFiscalParcelamentoLiquido[0] ) || ( Z794NotaFiscalId != T002T2_A794NotaFiscalId[0] ) )
            {
               if ( StringUtil.StrCmp(Z891NotaFiscalParcelamentoNumero, T002T2_A891NotaFiscalParcelamentoNumero[0]) != 0 )
               {
                  GXUtil.WriteLog("notafiscalparcelamento:[seudo value changed for attri]"+"NotaFiscalParcelamentoNumero");
                  GXUtil.WriteLogRaw("Old: ",Z891NotaFiscalParcelamentoNumero);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A891NotaFiscalParcelamentoNumero[0]);
               }
               if ( Z892NotaFiscalParcelamentoValor != T002T2_A892NotaFiscalParcelamentoValor[0] )
               {
                  GXUtil.WriteLog("notafiscalparcelamento:[seudo value changed for attri]"+"NotaFiscalParcelamentoValor");
                  GXUtil.WriteLogRaw("Old: ",Z892NotaFiscalParcelamentoValor);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A892NotaFiscalParcelamentoValor[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z893NotaFiscalParcelamentoVencimento ) != DateTimeUtil.ResetTime ( T002T2_A893NotaFiscalParcelamentoVencimento[0] ) )
               {
                  GXUtil.WriteLog("notafiscalparcelamento:[seudo value changed for attri]"+"NotaFiscalParcelamentoVencimento");
                  GXUtil.WriteLogRaw("Old: ",Z893NotaFiscalParcelamentoVencimento);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A893NotaFiscalParcelamentoVencimento[0]);
               }
               if ( Z895NotaFiscalParcelamentoValorTaxaAdministrativa != T002T2_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0] )
               {
                  GXUtil.WriteLog("notafiscalparcelamento:[seudo value changed for attri]"+"NotaFiscalParcelamentoValorTaxaAdministrativa");
                  GXUtil.WriteLogRaw("Old: ",Z895NotaFiscalParcelamentoValorTaxaAdministrativa);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0]);
               }
               if ( Z896NotaFiscalParcelamentoValorTaxaAnual != T002T2_A896NotaFiscalParcelamentoValorTaxaAnual[0] )
               {
                  GXUtil.WriteLog("notafiscalparcelamento:[seudo value changed for attri]"+"NotaFiscalParcelamentoValorTaxaAnual");
                  GXUtil.WriteLogRaw("Old: ",Z896NotaFiscalParcelamentoValorTaxaAnual);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A896NotaFiscalParcelamentoValorTaxaAnual[0]);
               }
               if ( Z897NotaFiscalParcelamentoLiquido != T002T2_A897NotaFiscalParcelamentoLiquido[0] )
               {
                  GXUtil.WriteLog("notafiscalparcelamento:[seudo value changed for attri]"+"NotaFiscalParcelamentoLiquido");
                  GXUtil.WriteLogRaw("Old: ",Z897NotaFiscalParcelamentoLiquido);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A897NotaFiscalParcelamentoLiquido[0]);
               }
               if ( Z794NotaFiscalId != T002T2_A794NotaFiscalId[0] )
               {
                  GXUtil.WriteLog("notafiscalparcelamento:[seudo value changed for attri]"+"NotaFiscalId");
                  GXUtil.WriteLogRaw("Old: ",Z794NotaFiscalId);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A794NotaFiscalId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotaFiscalParcelamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2T97( )
      {
         BeforeValidate2T97( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2T97( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2T97( 0) ;
            CheckOptimisticConcurrency2T97( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2T97( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2T97( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002T10 */
                     pr_default.execute(8, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID, n891NotaFiscalParcelamentoNumero, A891NotaFiscalParcelamentoNumero, n892NotaFiscalParcelamentoValor, A892NotaFiscalParcelamentoValor, n893NotaFiscalParcelamentoVencimento, A893NotaFiscalParcelamentoVencimento, n895NotaFiscalParcelamentoValorTaxaAdministrativa, A895NotaFiscalParcelamentoValorTaxaAdministrativa, n896NotaFiscalParcelamentoValorTaxaAnual, A896NotaFiscalParcelamentoValorTaxaAnual, n897NotaFiscalParcelamentoLiquido, A897NotaFiscalParcelamentoLiquido, n794NotaFiscalId, A794NotaFiscalId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("NotaFiscalParcelamento");
                     if ( (pr_default.getStatus(8) == 1) )
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
               Load2T97( ) ;
            }
            EndLevel2T97( ) ;
         }
         CloseExtendedTableCursors2T97( ) ;
      }

      protected void Update2T97( )
      {
         BeforeValidate2T97( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2T97( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2T97( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2T97( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2T97( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002T11 */
                     pr_default.execute(9, new Object[] {n891NotaFiscalParcelamentoNumero, A891NotaFiscalParcelamentoNumero, n892NotaFiscalParcelamentoValor, A892NotaFiscalParcelamentoValor, n893NotaFiscalParcelamentoVencimento, A893NotaFiscalParcelamentoVencimento, n895NotaFiscalParcelamentoValorTaxaAdministrativa, A895NotaFiscalParcelamentoValorTaxaAdministrativa, n896NotaFiscalParcelamentoValorTaxaAnual, A896NotaFiscalParcelamentoValorTaxaAnual, n897NotaFiscalParcelamentoLiquido, A897NotaFiscalParcelamentoLiquido, n794NotaFiscalId, A794NotaFiscalId, n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("NotaFiscalParcelamento");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscalParcelamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2T97( ) ;
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
            EndLevel2T97( ) ;
         }
         CloseExtendedTableCursors2T97( ) ;
      }

      protected void DeferredUpdate2T97( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2T97( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2T97( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2T97( ) ;
            AfterConfirm2T97( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2T97( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002T12 */
                  pr_default.execute(10, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("NotaFiscalParcelamento");
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
         sMode97 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2T97( ) ;
         Gx_mode = sMode97;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2T97( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002T13 */
            pr_default.execute(11, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            A799NotaFiscalNumero = T002T13_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = T002T13_n799NotaFiscalNumero[0];
            AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002T14 */
            pr_default.execute(12, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel2T97( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2T97( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2T0( ) ;
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

      public void ScanStart2T97( )
      {
         /* Scan By routine */
         /* Using cursor T002T15 */
         pr_default.execute(13);
         RcdFound97 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound97 = 1;
            A890NotaFiscalParcelamentoID = T002T15_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = T002T15_n890NotaFiscalParcelamentoID[0];
            AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2T97( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound97 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound97 = 1;
            A890NotaFiscalParcelamentoID = T002T15_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = T002T15_n890NotaFiscalParcelamentoID[0];
            AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
         }
      }

      protected void ScanEnd2T97( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm2T97( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2T97( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2T97( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2T97( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2T97( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2T97( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2T97( )
      {
         edtNotaFiscalParcelamentoID_Enabled = 0;
         AssignProp("", false, edtNotaFiscalParcelamentoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalParcelamentoID_Enabled), 5, 0), true);
         edtNotaFiscalId_Enabled = 0;
         AssignProp("", false, edtNotaFiscalId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalId_Enabled), 5, 0), true);
         edtNotaFiscalNumero_Enabled = 0;
         AssignProp("", false, edtNotaFiscalNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalNumero_Enabled), 5, 0), true);
         edtNotaFiscalParcelamentoNumero_Enabled = 0;
         AssignProp("", false, edtNotaFiscalParcelamentoNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalParcelamentoNumero_Enabled), 5, 0), true);
         edtNotaFiscalParcelamentoValor_Enabled = 0;
         AssignProp("", false, edtNotaFiscalParcelamentoValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalParcelamentoValor_Enabled), 5, 0), true);
         edtNotaFiscalParcelamentoVencimento_Enabled = 0;
         AssignProp("", false, edtNotaFiscalParcelamentoVencimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotaFiscalParcelamentoVencimento_Enabled), 5, 0), true);
         edtavCombonotafiscalid_Enabled = 0;
         AssignProp("", false, edtavCombonotafiscalid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonotafiscalid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2T97( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2T0( )
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
         GXEncryptionTmp = "notafiscalparcelamento"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7NotaFiscalParcelamentoID.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("notafiscalparcelamento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"NotaFiscalParcelamento");
         forbiddenHiddens.Add("Insert_NotaFiscalId", AV11Insert_NotaFiscalId.ToString());
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("NotaFiscalParcelamentoValorTaxaAdministrativa", context.localUtil.Format( A895NotaFiscalParcelamentoValorTaxaAdministrativa, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("NotaFiscalParcelamentoValorTaxaAnual", context.localUtil.Format( A896NotaFiscalParcelamentoValorTaxaAnual, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("NotaFiscalParcelamentoLiquido", context.localUtil.Format( A897NotaFiscalParcelamentoLiquido, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("notafiscalparcelamento:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z890NotaFiscalParcelamentoID", Z890NotaFiscalParcelamentoID.ToString());
         GxWebStd.gx_hidden_field( context, "Z891NotaFiscalParcelamentoNumero", Z891NotaFiscalParcelamentoNumero);
         GxWebStd.gx_hidden_field( context, "Z892NotaFiscalParcelamentoValor", StringUtil.LTrim( StringUtil.NToC( Z892NotaFiscalParcelamentoValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z893NotaFiscalParcelamentoVencimento", context.localUtil.DToC( Z893NotaFiscalParcelamentoVencimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z895NotaFiscalParcelamentoValorTaxaAdministrativa", StringUtil.LTrim( StringUtil.NToC( Z895NotaFiscalParcelamentoValorTaxaAdministrativa, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z896NotaFiscalParcelamentoValorTaxaAnual", StringUtil.LTrim( StringUtil.NToC( Z896NotaFiscalParcelamentoValorTaxaAnual, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z897NotaFiscalParcelamentoLiquido", StringUtil.LTrim( StringUtil.NToC( Z897NotaFiscalParcelamentoLiquido, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z794NotaFiscalId", Z794NotaFiscalId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N794NotaFiscalId", A794NotaFiscalId.ToString());
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTAFISCALID_DATA", AV13NotaFiscalId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTAFISCALID_DATA", AV13NotaFiscalId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vNOTAFISCALPARCELAMENTOID", AV7NotaFiscalParcelamentoID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTAFISCALPARCELAMENTOID", GetSecureSignedToken( "", AV7NotaFiscalParcelamentoID, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_NOTAFISCALID", AV11Insert_NotaFiscalId.ToString());
         GxWebStd.gx_hidden_field( context, "NOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA", StringUtil.LTrim( StringUtil.NToC( A895NotaFiscalParcelamentoValorTaxaAdministrativa, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALPARCELAMENTOVALORTAXAANUAL", StringUtil.LTrim( StringUtil.NToC( A896NotaFiscalParcelamentoValorTaxaAnual, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "NOTAFISCALPARCELAMENTOLIQUIDO", StringUtil.LTrim( StringUtil.NToC( A897NotaFiscalParcelamentoLiquido, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV19Pgmname));
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
         GXEncryptionTmp = "notafiscalparcelamento"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7NotaFiscalParcelamentoID.ToString());
         return formatLink("notafiscalparcelamento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "NotaFiscalParcelamento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Nota Fiscal Parcelamento" ;
      }

      protected void InitializeNonKey2T97( )
      {
         A794NotaFiscalId = Guid.Empty;
         n794NotaFiscalId = false;
         AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
         n794NotaFiscalId = ((Guid.Empty==A794NotaFiscalId) ? true : false);
         A799NotaFiscalNumero = "";
         n799NotaFiscalNumero = false;
         AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
         A891NotaFiscalParcelamentoNumero = "";
         n891NotaFiscalParcelamentoNumero = false;
         AssignAttri("", false, "A891NotaFiscalParcelamentoNumero", A891NotaFiscalParcelamentoNumero);
         n891NotaFiscalParcelamentoNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A891NotaFiscalParcelamentoNumero)) ? true : false);
         A892NotaFiscalParcelamentoValor = 0;
         n892NotaFiscalParcelamentoValor = false;
         AssignAttri("", false, "A892NotaFiscalParcelamentoValor", ((Convert.ToDecimal(0)==A892NotaFiscalParcelamentoValor)&&IsIns( )||n892NotaFiscalParcelamentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A892NotaFiscalParcelamentoValor, 18, 2, ".", ""))));
         n892NotaFiscalParcelamentoValor = ((Convert.ToDecimal(0)==A892NotaFiscalParcelamentoValor) ? true : false);
         A893NotaFiscalParcelamentoVencimento = DateTime.MinValue;
         n893NotaFiscalParcelamentoVencimento = false;
         AssignAttri("", false, "A893NotaFiscalParcelamentoVencimento", context.localUtil.Format(A893NotaFiscalParcelamentoVencimento, "99/99/9999"));
         n893NotaFiscalParcelamentoVencimento = ((DateTime.MinValue==A893NotaFiscalParcelamentoVencimento) ? true : false);
         A895NotaFiscalParcelamentoValorTaxaAdministrativa = 0;
         n895NotaFiscalParcelamentoValorTaxaAdministrativa = false;
         AssignAttri("", false, "A895NotaFiscalParcelamentoValorTaxaAdministrativa", ((Convert.ToDecimal(0)==A895NotaFiscalParcelamentoValorTaxaAdministrativa)&&IsIns( )||n895NotaFiscalParcelamentoValorTaxaAdministrativa ? "" : StringUtil.LTrim( StringUtil.NToC( A895NotaFiscalParcelamentoValorTaxaAdministrativa, 18, 2, ".", ""))));
         A896NotaFiscalParcelamentoValorTaxaAnual = 0;
         n896NotaFiscalParcelamentoValorTaxaAnual = false;
         AssignAttri("", false, "A896NotaFiscalParcelamentoValorTaxaAnual", ((Convert.ToDecimal(0)==A896NotaFiscalParcelamentoValorTaxaAnual)&&IsIns( )||n896NotaFiscalParcelamentoValorTaxaAnual ? "" : StringUtil.LTrim( StringUtil.NToC( A896NotaFiscalParcelamentoValorTaxaAnual, 18, 2, ".", ""))));
         A897NotaFiscalParcelamentoLiquido = 0;
         n897NotaFiscalParcelamentoLiquido = false;
         AssignAttri("", false, "A897NotaFiscalParcelamentoLiquido", ((Convert.ToDecimal(0)==A897NotaFiscalParcelamentoLiquido)&&IsIns( )||n897NotaFiscalParcelamentoLiquido ? "" : StringUtil.LTrim( StringUtil.NToC( A897NotaFiscalParcelamentoLiquido, 18, 2, ".", ""))));
         Z891NotaFiscalParcelamentoNumero = "";
         Z892NotaFiscalParcelamentoValor = 0;
         Z893NotaFiscalParcelamentoVencimento = DateTime.MinValue;
         Z895NotaFiscalParcelamentoValorTaxaAdministrativa = 0;
         Z896NotaFiscalParcelamentoValorTaxaAnual = 0;
         Z897NotaFiscalParcelamentoLiquido = 0;
         Z794NotaFiscalId = Guid.Empty;
      }

      protected void InitAll2T97( )
      {
         A890NotaFiscalParcelamentoID = Guid.NewGuid( );
         n890NotaFiscalParcelamentoID = false;
         AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
         InitializeNonKey2T97( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019213849", true, true);
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
         context.AddJavascriptSource("notafiscalparcelamento.js", "?202561019213849", false, true);
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
         edtNotaFiscalParcelamentoID_Internalname = "NOTAFISCALPARCELAMENTOID";
         lblTextblocknotafiscalid_Internalname = "TEXTBLOCKNOTAFISCALID";
         Combo_notafiscalid_Internalname = "COMBO_NOTAFISCALID";
         edtNotaFiscalId_Internalname = "NOTAFISCALID";
         divTablesplittednotafiscalid_Internalname = "TABLESPLITTEDNOTAFISCALID";
         edtNotaFiscalNumero_Internalname = "NOTAFISCALNUMERO";
         edtNotaFiscalParcelamentoNumero_Internalname = "NOTAFISCALPARCELAMENTONUMERO";
         edtNotaFiscalParcelamentoValor_Internalname = "NOTAFISCALPARCELAMENTOVALOR";
         edtNotaFiscalParcelamentoVencimento_Internalname = "NOTAFISCALPARCELAMENTOVENCIMENTO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = "Nota Fiscal Parcelamento";
         edtavCombonotafiscalid_Jsonclick = "";
         edtavCombonotafiscalid_Enabled = 0;
         edtavCombonotafiscalid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtNotaFiscalParcelamentoVencimento_Jsonclick = "";
         edtNotaFiscalParcelamentoVencimento_Enabled = 1;
         edtNotaFiscalParcelamentoValor_Jsonclick = "";
         edtNotaFiscalParcelamentoValor_Enabled = 1;
         edtNotaFiscalParcelamentoNumero_Jsonclick = "";
         edtNotaFiscalParcelamentoNumero_Enabled = 1;
         edtNotaFiscalNumero_Jsonclick = "";
         edtNotaFiscalNumero_Enabled = 0;
         edtNotaFiscalId_Jsonclick = "";
         edtNotaFiscalId_Enabled = 1;
         edtNotaFiscalId_Visible = 1;
         Combo_notafiscalid_Datalistprocparametersprefix = " \"ComboName\": \"NotaFiscalId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"NotaFiscalParcelamentoID\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_notafiscalid_Datalistproc = "NotaFiscalParcelamentoLoadDVCombo";
         Combo_notafiscalid_Cls = "ExtendedCombo AttributeFL";
         Combo_notafiscalid_Caption = "";
         Combo_notafiscalid_Enabled = Convert.ToBoolean( -1);
         edtNotaFiscalParcelamentoID_Jsonclick = "";
         edtNotaFiscalParcelamentoID_Enabled = 1;
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

      public void Valid_Notafiscalid( )
      {
         n794NotaFiscalId = false;
         n799NotaFiscalNumero = false;
         /* Using cursor T002T13 */
         pr_default.execute(11, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
               GX_FocusControl = edtNotaFiscalId_Internalname;
            }
         }
         A799NotaFiscalNumero = T002T13_A799NotaFiscalNumero[0];
         n799NotaFiscalNumero = T002T13_n799NotaFiscalNumero[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7NotaFiscalParcelamentoID","fld":"vNOTAFISCALPARCELAMENTOID","hsh":true,"type":"guid"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7NotaFiscalParcelamentoID","fld":"vNOTAFISCALPARCELAMENTOID","hsh":true,"type":"guid"},{"av":"AV11Insert_NotaFiscalId","fld":"vINSERT_NOTAFISCALID","type":"guid"},{"av":"A895NotaFiscalParcelamentoValorTaxaAdministrativa","fld":"NOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","nullAv":"n895NotaFiscalParcelamentoValorTaxaAdministrativa","type":"decimal"},{"av":"A896NotaFiscalParcelamentoValorTaxaAnual","fld":"NOTAFISCALPARCELAMENTOVALORTAXAANUAL","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","nullAv":"n896NotaFiscalParcelamentoValorTaxaAnual","type":"decimal"},{"av":"A897NotaFiscalParcelamentoLiquido","fld":"NOTAFISCALPARCELAMENTOLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","nullAv":"n897NotaFiscalParcelamentoLiquido","type":"decimal"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E132T2","iparms":[]}""");
         setEventMetadata("COMBO_NOTAFISCALID.ONOPTIONCLICKED","""{"handler":"E122T2","iparms":[{"av":"Combo_notafiscalid_Selectedvalue_get","ctrl":"COMBO_NOTAFISCALID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_NOTAFISCALID.ONOPTIONCLICKED",""","oparms":[{"av":"AV18ComboNotaFiscalId","fld":"vCOMBONOTAFISCALID","type":"guid"}]}""");
         setEventMetadata("VALID_NOTAFISCALPARCELAMENTOID","""{"handler":"Valid_Notafiscalparcelamentoid","iparms":[]}""");
         setEventMetadata("VALID_NOTAFISCALID","""{"handler":"Valid_Notafiscalid","iparms":[{"av":"A794NotaFiscalId","fld":"NOTAFISCALID","type":"guid"},{"av":"A799NotaFiscalNumero","fld":"NOTAFISCALNUMERO","type":"svchar"}]""");
         setEventMetadata("VALID_NOTAFISCALID",""","oparms":[{"av":"A799NotaFiscalNumero","fld":"NOTAFISCALNUMERO","type":"svchar"}]}""");
         setEventMetadata("VALID_NOTAFISCALPARCELAMENTOVALOR","""{"handler":"Valid_Notafiscalparcelamentovalor","iparms":[]}""");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7NotaFiscalParcelamentoID = Guid.Empty;
         Z890NotaFiscalParcelamentoID = Guid.Empty;
         Z891NotaFiscalParcelamentoNumero = "";
         Z893NotaFiscalParcelamentoVencimento = DateTime.MinValue;
         Z794NotaFiscalId = Guid.Empty;
         N794NotaFiscalId = Guid.Empty;
         Combo_notafiscalid_Selectedvalue_get = "";
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
         A890NotaFiscalParcelamentoID = Guid.Empty;
         lblTextblocknotafiscalid_Jsonclick = "";
         ucCombo_notafiscalid = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13NotaFiscalId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A799NotaFiscalNumero = "";
         A891NotaFiscalParcelamentoNumero = "";
         A893NotaFiscalParcelamentoVencimento = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV18ComboNotaFiscalId = Guid.Empty;
         AV11Insert_NotaFiscalId = Guid.Empty;
         AV19Pgmname = "";
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
         sMode97 = "";
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
         Z799NotaFiscalNumero = "";
         T002T4_A799NotaFiscalNumero = new string[] {""} ;
         T002T4_n799NotaFiscalNumero = new bool[] {false} ;
         T002T5_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T002T5_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         T002T5_A799NotaFiscalNumero = new string[] {""} ;
         T002T5_n799NotaFiscalNumero = new bool[] {false} ;
         T002T5_A891NotaFiscalParcelamentoNumero = new string[] {""} ;
         T002T5_n891NotaFiscalParcelamentoNumero = new bool[] {false} ;
         T002T5_A892NotaFiscalParcelamentoValor = new decimal[1] ;
         T002T5_n892NotaFiscalParcelamentoValor = new bool[] {false} ;
         T002T5_A893NotaFiscalParcelamentoVencimento = new DateTime[] {DateTime.MinValue} ;
         T002T5_n893NotaFiscalParcelamentoVencimento = new bool[] {false} ;
         T002T5_A895NotaFiscalParcelamentoValorTaxaAdministrativa = new decimal[1] ;
         T002T5_n895NotaFiscalParcelamentoValorTaxaAdministrativa = new bool[] {false} ;
         T002T5_A896NotaFiscalParcelamentoValorTaxaAnual = new decimal[1] ;
         T002T5_n896NotaFiscalParcelamentoValorTaxaAnual = new bool[] {false} ;
         T002T5_A897NotaFiscalParcelamentoLiquido = new decimal[1] ;
         T002T5_n897NotaFiscalParcelamentoLiquido = new bool[] {false} ;
         T002T5_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002T5_n794NotaFiscalId = new bool[] {false} ;
         T002T6_A799NotaFiscalNumero = new string[] {""} ;
         T002T6_n799NotaFiscalNumero = new bool[] {false} ;
         T002T7_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T002T7_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         T002T3_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T002T3_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         T002T3_A891NotaFiscalParcelamentoNumero = new string[] {""} ;
         T002T3_n891NotaFiscalParcelamentoNumero = new bool[] {false} ;
         T002T3_A892NotaFiscalParcelamentoValor = new decimal[1] ;
         T002T3_n892NotaFiscalParcelamentoValor = new bool[] {false} ;
         T002T3_A893NotaFiscalParcelamentoVencimento = new DateTime[] {DateTime.MinValue} ;
         T002T3_n893NotaFiscalParcelamentoVencimento = new bool[] {false} ;
         T002T3_A895NotaFiscalParcelamentoValorTaxaAdministrativa = new decimal[1] ;
         T002T3_n895NotaFiscalParcelamentoValorTaxaAdministrativa = new bool[] {false} ;
         T002T3_A896NotaFiscalParcelamentoValorTaxaAnual = new decimal[1] ;
         T002T3_n896NotaFiscalParcelamentoValorTaxaAnual = new bool[] {false} ;
         T002T3_A897NotaFiscalParcelamentoLiquido = new decimal[1] ;
         T002T3_n897NotaFiscalParcelamentoLiquido = new bool[] {false} ;
         T002T3_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002T3_n794NotaFiscalId = new bool[] {false} ;
         T002T8_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T002T8_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         T002T9_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T002T9_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         T002T2_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T002T2_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         T002T2_A891NotaFiscalParcelamentoNumero = new string[] {""} ;
         T002T2_n891NotaFiscalParcelamentoNumero = new bool[] {false} ;
         T002T2_A892NotaFiscalParcelamentoValor = new decimal[1] ;
         T002T2_n892NotaFiscalParcelamentoValor = new bool[] {false} ;
         T002T2_A893NotaFiscalParcelamentoVencimento = new DateTime[] {DateTime.MinValue} ;
         T002T2_n893NotaFiscalParcelamentoVencimento = new bool[] {false} ;
         T002T2_A895NotaFiscalParcelamentoValorTaxaAdministrativa = new decimal[1] ;
         T002T2_n895NotaFiscalParcelamentoValorTaxaAdministrativa = new bool[] {false} ;
         T002T2_A896NotaFiscalParcelamentoValorTaxaAnual = new decimal[1] ;
         T002T2_n896NotaFiscalParcelamentoValorTaxaAnual = new bool[] {false} ;
         T002T2_A897NotaFiscalParcelamentoLiquido = new decimal[1] ;
         T002T2_n897NotaFiscalParcelamentoLiquido = new bool[] {false} ;
         T002T2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T002T2_n794NotaFiscalId = new bool[] {false} ;
         T002T13_A799NotaFiscalNumero = new string[] {""} ;
         T002T13_n799NotaFiscalNumero = new bool[] {false} ;
         T002T14_A261TituloId = new int[1] ;
         T002T15_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T002T15_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalparcelamento__default(),
            new Object[][] {
                new Object[] {
               T002T2_A890NotaFiscalParcelamentoID, T002T2_A891NotaFiscalParcelamentoNumero, T002T2_n891NotaFiscalParcelamentoNumero, T002T2_A892NotaFiscalParcelamentoValor, T002T2_n892NotaFiscalParcelamentoValor, T002T2_A893NotaFiscalParcelamentoVencimento, T002T2_n893NotaFiscalParcelamentoVencimento, T002T2_A895NotaFiscalParcelamentoValorTaxaAdministrativa, T002T2_n895NotaFiscalParcelamentoValorTaxaAdministrativa, T002T2_A896NotaFiscalParcelamentoValorTaxaAnual,
               T002T2_n896NotaFiscalParcelamentoValorTaxaAnual, T002T2_A897NotaFiscalParcelamentoLiquido, T002T2_n897NotaFiscalParcelamentoLiquido, T002T2_A794NotaFiscalId, T002T2_n794NotaFiscalId
               }
               , new Object[] {
               T002T3_A890NotaFiscalParcelamentoID, T002T3_A891NotaFiscalParcelamentoNumero, T002T3_n891NotaFiscalParcelamentoNumero, T002T3_A892NotaFiscalParcelamentoValor, T002T3_n892NotaFiscalParcelamentoValor, T002T3_A893NotaFiscalParcelamentoVencimento, T002T3_n893NotaFiscalParcelamentoVencimento, T002T3_A895NotaFiscalParcelamentoValorTaxaAdministrativa, T002T3_n895NotaFiscalParcelamentoValorTaxaAdministrativa, T002T3_A896NotaFiscalParcelamentoValorTaxaAnual,
               T002T3_n896NotaFiscalParcelamentoValorTaxaAnual, T002T3_A897NotaFiscalParcelamentoLiquido, T002T3_n897NotaFiscalParcelamentoLiquido, T002T3_A794NotaFiscalId, T002T3_n794NotaFiscalId
               }
               , new Object[] {
               T002T4_A799NotaFiscalNumero, T002T4_n799NotaFiscalNumero
               }
               , new Object[] {
               T002T5_A890NotaFiscalParcelamentoID, T002T5_A799NotaFiscalNumero, T002T5_n799NotaFiscalNumero, T002T5_A891NotaFiscalParcelamentoNumero, T002T5_n891NotaFiscalParcelamentoNumero, T002T5_A892NotaFiscalParcelamentoValor, T002T5_n892NotaFiscalParcelamentoValor, T002T5_A893NotaFiscalParcelamentoVencimento, T002T5_n893NotaFiscalParcelamentoVencimento, T002T5_A895NotaFiscalParcelamentoValorTaxaAdministrativa,
               T002T5_n895NotaFiscalParcelamentoValorTaxaAdministrativa, T002T5_A896NotaFiscalParcelamentoValorTaxaAnual, T002T5_n896NotaFiscalParcelamentoValorTaxaAnual, T002T5_A897NotaFiscalParcelamentoLiquido, T002T5_n897NotaFiscalParcelamentoLiquido, T002T5_A794NotaFiscalId, T002T5_n794NotaFiscalId
               }
               , new Object[] {
               T002T6_A799NotaFiscalNumero, T002T6_n799NotaFiscalNumero
               }
               , new Object[] {
               T002T7_A890NotaFiscalParcelamentoID
               }
               , new Object[] {
               T002T8_A890NotaFiscalParcelamentoID
               }
               , new Object[] {
               T002T9_A890NotaFiscalParcelamentoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002T13_A799NotaFiscalNumero, T002T13_n799NotaFiscalNumero
               }
               , new Object[] {
               T002T14_A261TituloId
               }
               , new Object[] {
               T002T15_A890NotaFiscalParcelamentoID
               }
            }
         );
         Z890NotaFiscalParcelamentoID = Guid.NewGuid( );
         n890NotaFiscalParcelamentoID = false;
         A890NotaFiscalParcelamentoID = Guid.NewGuid( );
         n890NotaFiscalParcelamentoID = false;
         AV19Pgmname = "NotaFiscalParcelamento";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound97 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtNotaFiscalParcelamentoID_Enabled ;
      private int edtNotaFiscalId_Visible ;
      private int edtNotaFiscalId_Enabled ;
      private int edtNotaFiscalNumero_Enabled ;
      private int edtNotaFiscalParcelamentoNumero_Enabled ;
      private int edtNotaFiscalParcelamentoValor_Enabled ;
      private int edtNotaFiscalParcelamentoVencimento_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombonotafiscalid_Visible ;
      private int edtavCombonotafiscalid_Enabled ;
      private int Combo_notafiscalid_Datalistupdateminimumcharacters ;
      private int Combo_notafiscalid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV20GXV1 ;
      private int idxLst ;
      private decimal Z892NotaFiscalParcelamentoValor ;
      private decimal Z895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal Z896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal Z897NotaFiscalParcelamentoLiquido ;
      private decimal A892NotaFiscalParcelamentoValor ;
      private decimal A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal A896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal A897NotaFiscalParcelamentoLiquido ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_notafiscalid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNotaFiscalParcelamentoID_Internalname ;
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
      private string edtNotaFiscalParcelamentoID_Jsonclick ;
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
      private string edtNotaFiscalNumero_Internalname ;
      private string edtNotaFiscalNumero_Jsonclick ;
      private string edtNotaFiscalParcelamentoNumero_Internalname ;
      private string edtNotaFiscalParcelamentoNumero_Jsonclick ;
      private string edtNotaFiscalParcelamentoValor_Internalname ;
      private string edtNotaFiscalParcelamentoValor_Jsonclick ;
      private string edtNotaFiscalParcelamentoVencimento_Internalname ;
      private string edtNotaFiscalParcelamentoVencimento_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_notafiscalid_Internalname ;
      private string edtavCombonotafiscalid_Internalname ;
      private string edtavCombonotafiscalid_Jsonclick ;
      private string AV19Pgmname ;
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
      private string sMode97 ;
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
      private DateTime Z893NotaFiscalParcelamentoVencimento ;
      private DateTime A893NotaFiscalParcelamentoVencimento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n794NotaFiscalId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n892NotaFiscalParcelamentoValor ;
      private bool n891NotaFiscalParcelamentoNumero ;
      private bool n893NotaFiscalParcelamentoVencimento ;
      private bool n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool n896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool n897NotaFiscalParcelamentoLiquido ;
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
      private bool n890NotaFiscalParcelamentoID ;
      private bool n799NotaFiscalNumero ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV17Combo_DataJson ;
      private string Z891NotaFiscalParcelamentoNumero ;
      private string A799NotaFiscalNumero ;
      private string A891NotaFiscalParcelamentoNumero ;
      private string AV15ComboSelectedValue ;
      private string AV16ComboSelectedText ;
      private string Z799NotaFiscalNumero ;
      private Guid wcpOAV7NotaFiscalParcelamentoID ;
      private Guid Z890NotaFiscalParcelamentoID ;
      private Guid Z794NotaFiscalId ;
      private Guid N794NotaFiscalId ;
      private Guid A794NotaFiscalId ;
      private Guid AV7NotaFiscalParcelamentoID ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid AV18ComboNotaFiscalId ;
      private Guid AV11Insert_NotaFiscalId ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_notafiscalid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13NotaFiscalId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T002T4_A799NotaFiscalNumero ;
      private bool[] T002T4_n799NotaFiscalNumero ;
      private Guid[] T002T5_A890NotaFiscalParcelamentoID ;
      private bool[] T002T5_n890NotaFiscalParcelamentoID ;
      private string[] T002T5_A799NotaFiscalNumero ;
      private bool[] T002T5_n799NotaFiscalNumero ;
      private string[] T002T5_A891NotaFiscalParcelamentoNumero ;
      private bool[] T002T5_n891NotaFiscalParcelamentoNumero ;
      private decimal[] T002T5_A892NotaFiscalParcelamentoValor ;
      private bool[] T002T5_n892NotaFiscalParcelamentoValor ;
      private DateTime[] T002T5_A893NotaFiscalParcelamentoVencimento ;
      private bool[] T002T5_n893NotaFiscalParcelamentoVencimento ;
      private decimal[] T002T5_A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool[] T002T5_n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal[] T002T5_A896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool[] T002T5_n896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal[] T002T5_A897NotaFiscalParcelamentoLiquido ;
      private bool[] T002T5_n897NotaFiscalParcelamentoLiquido ;
      private Guid[] T002T5_A794NotaFiscalId ;
      private bool[] T002T5_n794NotaFiscalId ;
      private string[] T002T6_A799NotaFiscalNumero ;
      private bool[] T002T6_n799NotaFiscalNumero ;
      private Guid[] T002T7_A890NotaFiscalParcelamentoID ;
      private bool[] T002T7_n890NotaFiscalParcelamentoID ;
      private Guid[] T002T3_A890NotaFiscalParcelamentoID ;
      private bool[] T002T3_n890NotaFiscalParcelamentoID ;
      private string[] T002T3_A891NotaFiscalParcelamentoNumero ;
      private bool[] T002T3_n891NotaFiscalParcelamentoNumero ;
      private decimal[] T002T3_A892NotaFiscalParcelamentoValor ;
      private bool[] T002T3_n892NotaFiscalParcelamentoValor ;
      private DateTime[] T002T3_A893NotaFiscalParcelamentoVencimento ;
      private bool[] T002T3_n893NotaFiscalParcelamentoVencimento ;
      private decimal[] T002T3_A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool[] T002T3_n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal[] T002T3_A896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool[] T002T3_n896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal[] T002T3_A897NotaFiscalParcelamentoLiquido ;
      private bool[] T002T3_n897NotaFiscalParcelamentoLiquido ;
      private Guid[] T002T3_A794NotaFiscalId ;
      private bool[] T002T3_n794NotaFiscalId ;
      private Guid[] T002T8_A890NotaFiscalParcelamentoID ;
      private bool[] T002T8_n890NotaFiscalParcelamentoID ;
      private Guid[] T002T9_A890NotaFiscalParcelamentoID ;
      private bool[] T002T9_n890NotaFiscalParcelamentoID ;
      private Guid[] T002T2_A890NotaFiscalParcelamentoID ;
      private bool[] T002T2_n890NotaFiscalParcelamentoID ;
      private string[] T002T2_A891NotaFiscalParcelamentoNumero ;
      private bool[] T002T2_n891NotaFiscalParcelamentoNumero ;
      private decimal[] T002T2_A892NotaFiscalParcelamentoValor ;
      private bool[] T002T2_n892NotaFiscalParcelamentoValor ;
      private DateTime[] T002T2_A893NotaFiscalParcelamentoVencimento ;
      private bool[] T002T2_n893NotaFiscalParcelamentoVencimento ;
      private decimal[] T002T2_A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool[] T002T2_n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal[] T002T2_A896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool[] T002T2_n896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal[] T002T2_A897NotaFiscalParcelamentoLiquido ;
      private bool[] T002T2_n897NotaFiscalParcelamentoLiquido ;
      private Guid[] T002T2_A794NotaFiscalId ;
      private bool[] T002T2_n794NotaFiscalId ;
      private string[] T002T13_A799NotaFiscalNumero ;
      private bool[] T002T13_n799NotaFiscalNumero ;
      private int[] T002T14_A261TituloId ;
      private Guid[] T002T15_A890NotaFiscalParcelamentoID ;
      private bool[] T002T15_n890NotaFiscalParcelamentoID ;
   }

   public class notafiscalparcelamento__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002T2;
          prmT002T2 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T3;
          prmT002T3 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T4;
          prmT002T4 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T5;
          prmT002T5 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T6;
          prmT002T6 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T7;
          prmT002T7 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T8;
          prmT002T8 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T9;
          prmT002T9 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T10;
          prmT002T10 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoNumero",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoValorTaxaAdministrativa",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoValorTaxaAnual",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoLiquido",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T11;
          prmT002T11 = new Object[] {
          new ParDef("NotaFiscalParcelamentoNumero",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoValorTaxaAdministrativa",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoValorTaxaAnual",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoLiquido",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T12;
          prmT002T12 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T13;
          prmT002T13 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T14;
          prmT002T14 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT002T15;
          prmT002T15 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002T2", "SELECT NotaFiscalParcelamentoID, NotaFiscalParcelamentoNumero, NotaFiscalParcelamentoValor, NotaFiscalParcelamentoVencimento, NotaFiscalParcelamentoValorTaxaAdministrativa, NotaFiscalParcelamentoValorTaxaAnual, NotaFiscalParcelamentoLiquido, NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID  FOR UPDATE OF NotaFiscalParcelamento NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002T2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002T3", "SELECT NotaFiscalParcelamentoID, NotaFiscalParcelamentoNumero, NotaFiscalParcelamentoValor, NotaFiscalParcelamentoVencimento, NotaFiscalParcelamentoValorTaxaAdministrativa, NotaFiscalParcelamentoValorTaxaAnual, NotaFiscalParcelamentoLiquido, NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002T4", "SELECT NotaFiscalNumero FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002T5", "SELECT TM1.NotaFiscalParcelamentoID, T2.NotaFiscalNumero, TM1.NotaFiscalParcelamentoNumero, TM1.NotaFiscalParcelamentoValor, TM1.NotaFiscalParcelamentoVencimento, TM1.NotaFiscalParcelamentoValorTaxaAdministrativa, TM1.NotaFiscalParcelamentoValorTaxaAnual, TM1.NotaFiscalParcelamentoLiquido, TM1.NotaFiscalId FROM (NotaFiscalParcelamento TM1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = TM1.NotaFiscalId) WHERE TM1.NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ORDER BY TM1.NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002T6", "SELECT NotaFiscalNumero FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002T7", "SELECT NotaFiscalParcelamentoID FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002T8", "SELECT NotaFiscalParcelamentoID FROM NotaFiscalParcelamento WHERE ( NotaFiscalParcelamentoID > :NotaFiscalParcelamentoID) ORDER BY NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002T9", "SELECT NotaFiscalParcelamentoID FROM NotaFiscalParcelamento WHERE ( NotaFiscalParcelamentoID < :NotaFiscalParcelamentoID) ORDER BY NotaFiscalParcelamentoID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002T10", "SAVEPOINT gxupdate;INSERT INTO NotaFiscalParcelamento(NotaFiscalParcelamentoID, NotaFiscalParcelamentoNumero, NotaFiscalParcelamentoValor, NotaFiscalParcelamentoVencimento, NotaFiscalParcelamentoValorTaxaAdministrativa, NotaFiscalParcelamentoValorTaxaAnual, NotaFiscalParcelamentoLiquido, NotaFiscalId) VALUES(:NotaFiscalParcelamentoID, :NotaFiscalParcelamentoNumero, :NotaFiscalParcelamentoValor, :NotaFiscalParcelamentoVencimento, :NotaFiscalParcelamentoValorTaxaAdministrativa, :NotaFiscalParcelamentoValorTaxaAnual, :NotaFiscalParcelamentoLiquido, :NotaFiscalId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002T10)
             ,new CursorDef("T002T11", "SAVEPOINT gxupdate;UPDATE NotaFiscalParcelamento SET NotaFiscalParcelamentoNumero=:NotaFiscalParcelamentoNumero, NotaFiscalParcelamentoValor=:NotaFiscalParcelamentoValor, NotaFiscalParcelamentoVencimento=:NotaFiscalParcelamentoVencimento, NotaFiscalParcelamentoValorTaxaAdministrativa=:NotaFiscalParcelamentoValorTaxaAdministrativa, NotaFiscalParcelamentoValorTaxaAnual=:NotaFiscalParcelamentoValorTaxaAnual, NotaFiscalParcelamentoLiquido=:NotaFiscalParcelamentoLiquido, NotaFiscalId=:NotaFiscalId  WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002T11)
             ,new CursorDef("T002T12", "SAVEPOINT gxupdate;DELETE FROM NotaFiscalParcelamento  WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002T12)
             ,new CursorDef("T002T13", "SELECT NotaFiscalNumero FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002T14", "SELECT TituloId FROM Titulo WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002T15", "SELECT NotaFiscalParcelamentoID FROM NotaFiscalParcelamento ORDER BY NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T15,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((Guid[]) buf[15])[0] = rslt.getGuid(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 7 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
