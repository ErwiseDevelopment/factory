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
   public class documentos : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "documentos")), "documentos") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "documentos")))) ;
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
                  AV7DocumentosId = (int)(Math.Round(NumberUtil.Val( GetPar( "DocumentosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7DocumentosId", StringUtil.LTrimStr( (decimal)(AV7DocumentosId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7DocumentosId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Documentos", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDocumentosDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public documentos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_DocumentosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7DocumentosId = aP1_DocumentosId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbDocumentosStatus = new GXCombobox();
         cmbDocumentoObrigatorio = new GXCombobox();
         cmbDocumentoObrigatorioReembolso = new GXCombobox();
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
         if ( cmbDocumentosStatus.ItemCount > 0 )
         {
            A407DocumentosStatus = StringUtil.StrToBool( cmbDocumentosStatus.getValidValue(StringUtil.BoolToStr( A407DocumentosStatus)));
            n407DocumentosStatus = false;
            AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
            AssignProp("", false, cmbDocumentosStatus_Internalname, "Values", cmbDocumentosStatus.ToJavascriptSource(), true);
         }
         if ( cmbDocumentoObrigatorio.ItemCount > 0 )
         {
            A413DocumentoObrigatorio = StringUtil.StrToBool( cmbDocumentoObrigatorio.getValidValue(StringUtil.BoolToStr( A413DocumentoObrigatorio)));
            n413DocumentoObrigatorio = false;
            AssignAttri("", false, "A413DocumentoObrigatorio", A413DocumentoObrigatorio);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDocumentoObrigatorio.CurrentValue = StringUtil.BoolToStr( A413DocumentoObrigatorio);
            AssignProp("", false, cmbDocumentoObrigatorio_Internalname, "Values", cmbDocumentoObrigatorio.ToJavascriptSource(), true);
         }
         if ( cmbDocumentoObrigatorioReembolso.ItemCount > 0 )
         {
            A536DocumentoObrigatorioReembolso = StringUtil.StrToBool( cmbDocumentoObrigatorioReembolso.getValidValue(StringUtil.BoolToStr( A536DocumentoObrigatorioReembolso)));
            n536DocumentoObrigatorioReembolso = false;
            AssignAttri("", false, "A536DocumentoObrigatorioReembolso", A536DocumentoObrigatorioReembolso);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDocumentoObrigatorioReembolso.CurrentValue = StringUtil.BoolToStr( A536DocumentoObrigatorioReembolso);
            AssignProp("", false, cmbDocumentoObrigatorioReembolso_Internalname, "Values", cmbDocumentoObrigatorioReembolso.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocumentosDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocumentosDescricao_Internalname, "Descricao", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentosDescricao_Internalname, A406DocumentosDescricao, StringUtil.RTrim( context.localUtil.Format( A406DocumentosDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentosDescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocumentosDescricao_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Documentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbDocumentosStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbDocumentosStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbDocumentosStatus, cmbDocumentosStatus_Internalname, StringUtil.BoolToStr( A407DocumentosStatus), 1, cmbDocumentosStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbDocumentosStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Documentos.htm");
         cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
         AssignProp("", false, cmbDocumentosStatus_Internalname, "Values", (string)(cmbDocumentosStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbDocumentoObrigatorio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbDocumentoObrigatorio_Internalname, "Obrigatorio", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbDocumentoObrigatorio, cmbDocumentoObrigatorio_Internalname, StringUtil.BoolToStr( A413DocumentoObrigatorio), 1, cmbDocumentoObrigatorio_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbDocumentoObrigatorio.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_Documentos.htm");
         cmbDocumentoObrigatorio.CurrentValue = StringUtil.BoolToStr( A413DocumentoObrigatorio);
         AssignProp("", false, cmbDocumentoObrigatorio_Internalname, "Values", (string)(cmbDocumentoObrigatorio.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbDocumentoObrigatorioReembolso_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbDocumentoObrigatorioReembolso_Internalname, "Obrigatorio Reembolso", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbDocumentoObrigatorioReembolso, cmbDocumentoObrigatorioReembolso_Internalname, StringUtil.BoolToStr( A536DocumentoObrigatorioReembolso), 1, cmbDocumentoObrigatorioReembolso_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbDocumentoObrigatorioReembolso.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_Documentos.htm");
         cmbDocumentoObrigatorioReembolso.CurrentValue = StringUtil.BoolToStr( A536DocumentoObrigatorioReembolso);
         AssignProp("", false, cmbDocumentoObrigatorioReembolso_Internalname, "Values", (string)(cmbDocumentoObrigatorioReembolso.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Documentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Documentos.htm");
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
         GxWebStd.gx_single_line_edit( context, edtDocumentosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ",", "")), StringUtil.LTrim( ((edtDocumentosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A405DocumentosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A405DocumentosId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentosId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocumentosId_Visible, edtDocumentosId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Documentos.htm");
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
         E111M2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z405DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z405DocumentosId"), ",", "."), 18, MidpointRounding.ToEven));
               Z407DocumentosStatus = StringUtil.StrToBool( cgiGet( "Z407DocumentosStatus"));
               n407DocumentosStatus = ((false==A407DocumentosStatus) ? true : false);
               Z406DocumentosDescricao = cgiGet( "Z406DocumentosDescricao");
               n406DocumentosDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A406DocumentosDescricao)) ? true : false);
               Z413DocumentoObrigatorio = StringUtil.StrToBool( cgiGet( "Z413DocumentoObrigatorio"));
               n413DocumentoObrigatorio = ((false==A413DocumentoObrigatorio) ? true : false);
               Z536DocumentoObrigatorioReembolso = StringUtil.StrToBool( cgiGet( "Z536DocumentoObrigatorioReembolso"));
               n536DocumentoObrigatorioReembolso = ((false==A536DocumentoObrigatorioReembolso) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vDOCUMENTOSID"), ",", "."), 18, MidpointRounding.ToEven));
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
               A406DocumentosDescricao = cgiGet( edtDocumentosDescricao_Internalname);
               n406DocumentosDescricao = false;
               AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
               n406DocumentosDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A406DocumentosDescricao)) ? true : false);
               cmbDocumentosStatus.CurrentValue = cgiGet( cmbDocumentosStatus_Internalname);
               A407DocumentosStatus = StringUtil.StrToBool( cgiGet( cmbDocumentosStatus_Internalname));
               n407DocumentosStatus = false;
               AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
               n407DocumentosStatus = ((false==A407DocumentosStatus) ? true : false);
               cmbDocumentoObrigatorio.CurrentValue = cgiGet( cmbDocumentoObrigatorio_Internalname);
               A413DocumentoObrigatorio = StringUtil.StrToBool( cgiGet( cmbDocumentoObrigatorio_Internalname));
               n413DocumentoObrigatorio = false;
               AssignAttri("", false, "A413DocumentoObrigatorio", A413DocumentoObrigatorio);
               n413DocumentoObrigatorio = ((false==A413DocumentoObrigatorio) ? true : false);
               cmbDocumentoObrigatorioReembolso.CurrentValue = cgiGet( cmbDocumentoObrigatorioReembolso_Internalname);
               A536DocumentoObrigatorioReembolso = StringUtil.StrToBool( cgiGet( cmbDocumentoObrigatorioReembolso_Internalname));
               n536DocumentoObrigatorioReembolso = false;
               AssignAttri("", false, "A536DocumentoObrigatorioReembolso", A536DocumentoObrigatorioReembolso);
               n536DocumentoObrigatorioReembolso = ((false==A536DocumentoObrigatorioReembolso) ? true : false);
               A405DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDocumentosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n405DocumentosId = false;
               AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Documentos");
               A405DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDocumentosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n405DocumentosId = false;
               AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
               forbiddenHiddens.Add("DocumentosId", context.localUtil.Format( (decimal)(A405DocumentosId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A405DocumentosId != Z405DocumentosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("documentos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A407DocumentosStatus = StringUtil.StrToBool( cgiGet( cmbDocumentosStatus_Internalname));
                  n407DocumentosStatus = false;
                  AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
                  forbiddenHiddens2.Add("DocumentosStatus", StringUtil.BoolToStr( A407DocumentosStatus));
               }
               hsh2 = cgiGet( "hsh2");
               if ( ( ! ( ( A405DocumentosId != Z405DocumentosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens2.ToString(), hsh2, GXKey) )
               {
                  GXUtil.WriteLogError("documentos:[ CondSecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens2.ToJSonString());
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
                  A405DocumentosId = (int)(Math.Round(NumberUtil.Val( GetPar( "DocumentosId"), "."), 18, MidpointRounding.ToEven));
                  n405DocumentosId = false;
                  AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
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
                     sMode60 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode60;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound60 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1M0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "DOCUMENTOSID");
                        AnyError = 1;
                        GX_FocusControl = edtDocumentosId_Internalname;
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
                           E111M2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121M2 ();
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
            E121M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1M60( ) ;
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
         if ( IsDsp( ) || IsDlt( ) )
         {
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes1M60( ) ;
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

      protected void CONFIRM_1M0( )
      {
         BeforeValidate1M60( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1M60( ) ;
            }
            else
            {
               CheckExtendedTable1M60( ) ;
               CloseExtendedTableCursors1M60( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1M0( )
      {
      }

      protected void E111M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtDocumentosId_Visible = 0;
         AssignProp("", false, edtDocumentosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentosId_Visible), 5, 0), true);
      }

      protected void E121M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("documentosww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1M60( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z407DocumentosStatus = T001M3_A407DocumentosStatus[0];
               Z406DocumentosDescricao = T001M3_A406DocumentosDescricao[0];
               Z413DocumentoObrigatorio = T001M3_A413DocumentoObrigatorio[0];
               Z536DocumentoObrigatorioReembolso = T001M3_A536DocumentoObrigatorioReembolso[0];
            }
            else
            {
               Z407DocumentosStatus = A407DocumentosStatus;
               Z406DocumentosDescricao = A406DocumentosDescricao;
               Z413DocumentoObrigatorio = A413DocumentoObrigatorio;
               Z536DocumentoObrigatorioReembolso = A536DocumentoObrigatorioReembolso;
            }
         }
         if ( GX_JID == -6 )
         {
            Z405DocumentosId = A405DocumentosId;
            Z407DocumentosStatus = A407DocumentosStatus;
            Z406DocumentosDescricao = A406DocumentosDescricao;
            Z413DocumentoObrigatorio = A413DocumentoObrigatorio;
            Z536DocumentoObrigatorioReembolso = A536DocumentoObrigatorioReembolso;
         }
      }

      protected void standaloneNotModal( )
      {
         edtDocumentosId_Enabled = 0;
         AssignProp("", false, edtDocumentosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentosId_Enabled), 5, 0), true);
         edtDocumentosId_Enabled = 0;
         AssignProp("", false, edtDocumentosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentosId_Enabled), 5, 0), true);
         if ( ! (0==AV7DocumentosId) )
         {
            A405DocumentosId = AV7DocumentosId;
            n405DocumentosId = false;
            AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            cmbDocumentosStatus.Enabled = 0;
            AssignProp("", false, cmbDocumentosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDocumentosStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbDocumentosStatus.Enabled = 1;
            AssignProp("", false, cmbDocumentosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDocumentosStatus.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            A407DocumentosStatus = true;
            n407DocumentosStatus = false;
            AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
         }
         if ( IsIns( )  )
         {
            cmbDocumentosStatus.Enabled = 0;
            AssignProp("", false, cmbDocumentosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDocumentosStatus.Enabled), 5, 0), true);
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
      }

      protected void Load1M60( )
      {
         /* Using cursor T001M4 */
         pr_default.execute(2, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound60 = 1;
            A407DocumentosStatus = T001M4_A407DocumentosStatus[0];
            n407DocumentosStatus = T001M4_n407DocumentosStatus[0];
            AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
            A406DocumentosDescricao = T001M4_A406DocumentosDescricao[0];
            n406DocumentosDescricao = T001M4_n406DocumentosDescricao[0];
            AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
            A413DocumentoObrigatorio = T001M4_A413DocumentoObrigatorio[0];
            n413DocumentoObrigatorio = T001M4_n413DocumentoObrigatorio[0];
            AssignAttri("", false, "A413DocumentoObrigatorio", A413DocumentoObrigatorio);
            A536DocumentoObrigatorioReembolso = T001M4_A536DocumentoObrigatorioReembolso[0];
            n536DocumentoObrigatorioReembolso = T001M4_n536DocumentoObrigatorioReembolso[0];
            AssignAttri("", false, "A536DocumentoObrigatorioReembolso", A536DocumentoObrigatorioReembolso);
            ZM1M60( -6) ;
         }
         pr_default.close(2);
         OnLoadActions1M60( ) ;
      }

      protected void OnLoadActions1M60( )
      {
      }

      protected void CheckExtendedTable1M60( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1M60( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1M60( )
      {
         /* Using cursor T001M5 */
         pr_default.execute(3, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound60 = 1;
         }
         else
         {
            RcdFound60 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001M3 */
         pr_default.execute(1, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1M60( 6) ;
            RcdFound60 = 1;
            A405DocumentosId = T001M3_A405DocumentosId[0];
            n405DocumentosId = T001M3_n405DocumentosId[0];
            AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
            A407DocumentosStatus = T001M3_A407DocumentosStatus[0];
            n407DocumentosStatus = T001M3_n407DocumentosStatus[0];
            AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
            A406DocumentosDescricao = T001M3_A406DocumentosDescricao[0];
            n406DocumentosDescricao = T001M3_n406DocumentosDescricao[0];
            AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
            A413DocumentoObrigatorio = T001M3_A413DocumentoObrigatorio[0];
            n413DocumentoObrigatorio = T001M3_n413DocumentoObrigatorio[0];
            AssignAttri("", false, "A413DocumentoObrigatorio", A413DocumentoObrigatorio);
            A536DocumentoObrigatorioReembolso = T001M3_A536DocumentoObrigatorioReembolso[0];
            n536DocumentoObrigatorioReembolso = T001M3_n536DocumentoObrigatorioReembolso[0];
            AssignAttri("", false, "A536DocumentoObrigatorioReembolso", A536DocumentoObrigatorioReembolso);
            Z405DocumentosId = A405DocumentosId;
            sMode60 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1M60( ) ;
            if ( AnyError == 1 )
            {
               RcdFound60 = 0;
               InitializeNonKey1M60( ) ;
            }
            Gx_mode = sMode60;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound60 = 0;
            InitializeNonKey1M60( ) ;
            sMode60 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode60;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1M60( ) ;
         if ( RcdFound60 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound60 = 0;
         /* Using cursor T001M6 */
         pr_default.execute(4, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001M6_A405DocumentosId[0] < A405DocumentosId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001M6_A405DocumentosId[0] > A405DocumentosId ) ) )
            {
               A405DocumentosId = T001M6_A405DocumentosId[0];
               n405DocumentosId = T001M6_n405DocumentosId[0];
               AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
               RcdFound60 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound60 = 0;
         /* Using cursor T001M7 */
         pr_default.execute(5, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001M7_A405DocumentosId[0] > A405DocumentosId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001M7_A405DocumentosId[0] < A405DocumentosId ) ) )
            {
               A405DocumentosId = T001M7_A405DocumentosId[0];
               n405DocumentosId = T001M7_n405DocumentosId[0];
               AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
               RcdFound60 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1M60( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDocumentosDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1M60( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound60 == 1 )
            {
               if ( A405DocumentosId != Z405DocumentosId )
               {
                  A405DocumentosId = Z405DocumentosId;
                  n405DocumentosId = false;
                  AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DOCUMENTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtDocumentosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDocumentosDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1M60( ) ;
                  GX_FocusControl = edtDocumentosDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A405DocumentosId != Z405DocumentosId )
               {
                  /* Insert record */
                  GX_FocusControl = edtDocumentosDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1M60( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DOCUMENTOSID");
                     AnyError = 1;
                     GX_FocusControl = edtDocumentosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtDocumentosDescricao_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1M60( ) ;
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
         if ( A405DocumentosId != Z405DocumentosId )
         {
            A405DocumentosId = Z405DocumentosId;
            n405DocumentosId = false;
            AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DOCUMENTOSID");
            AnyError = 1;
            GX_FocusControl = edtDocumentosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDocumentosDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1M60( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001M2 */
            pr_default.execute(0, new Object[] {n405DocumentosId, A405DocumentosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Documentos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z407DocumentosStatus != T001M2_A407DocumentosStatus[0] ) || ( StringUtil.StrCmp(Z406DocumentosDescricao, T001M2_A406DocumentosDescricao[0]) != 0 ) || ( Z413DocumentoObrigatorio != T001M2_A413DocumentoObrigatorio[0] ) || ( Z536DocumentoObrigatorioReembolso != T001M2_A536DocumentoObrigatorioReembolso[0] ) )
            {
               if ( Z407DocumentosStatus != T001M2_A407DocumentosStatus[0] )
               {
                  GXUtil.WriteLog("documentos:[seudo value changed for attri]"+"DocumentosStatus");
                  GXUtil.WriteLogRaw("Old: ",Z407DocumentosStatus);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A407DocumentosStatus[0]);
               }
               if ( StringUtil.StrCmp(Z406DocumentosDescricao, T001M2_A406DocumentosDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("documentos:[seudo value changed for attri]"+"DocumentosDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z406DocumentosDescricao);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A406DocumentosDescricao[0]);
               }
               if ( Z413DocumentoObrigatorio != T001M2_A413DocumentoObrigatorio[0] )
               {
                  GXUtil.WriteLog("documentos:[seudo value changed for attri]"+"DocumentoObrigatorio");
                  GXUtil.WriteLogRaw("Old: ",Z413DocumentoObrigatorio);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A413DocumentoObrigatorio[0]);
               }
               if ( Z536DocumentoObrigatorioReembolso != T001M2_A536DocumentoObrigatorioReembolso[0] )
               {
                  GXUtil.WriteLog("documentos:[seudo value changed for attri]"+"DocumentoObrigatorioReembolso");
                  GXUtil.WriteLogRaw("Old: ",Z536DocumentoObrigatorioReembolso);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A536DocumentoObrigatorioReembolso[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Documentos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1M60( )
      {
         BeforeValidate1M60( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M60( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1M60( 0) ;
            CheckOptimisticConcurrency1M60( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M60( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1M60( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001M8 */
                     pr_default.execute(6, new Object[] {n407DocumentosStatus, A407DocumentosStatus, n406DocumentosDescricao, A406DocumentosDescricao, n413DocumentoObrigatorio, A413DocumentoObrigatorio, n536DocumentoObrigatorioReembolso, A536DocumentoObrigatorioReembolso});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001M9 */
                     pr_default.execute(7);
                     A405DocumentosId = T001M9_A405DocumentosId[0];
                     n405DocumentosId = T001M9_n405DocumentosId[0];
                     AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Documentos");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1M0( ) ;
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
               Load1M60( ) ;
            }
            EndLevel1M60( ) ;
         }
         CloseExtendedTableCursors1M60( ) ;
      }

      protected void Update1M60( )
      {
         BeforeValidate1M60( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M60( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M60( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M60( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1M60( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001M10 */
                     pr_default.execute(8, new Object[] {n407DocumentosStatus, A407DocumentosStatus, n406DocumentosDescricao, A406DocumentosDescricao, n413DocumentoObrigatorio, A413DocumentoObrigatorio, n536DocumentoObrigatorioReembolso, A536DocumentoObrigatorioReembolso, n405DocumentosId, A405DocumentosId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Documentos");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Documentos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1M60( ) ;
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
            EndLevel1M60( ) ;
         }
         CloseExtendedTableCursors1M60( ) ;
      }

      protected void DeferredUpdate1M60( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1M60( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M60( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1M60( ) ;
            AfterConfirm1M60( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1M60( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001M11 */
                  pr_default.execute(9, new Object[] {n405DocumentosId, A405DocumentosId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Documentos");
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
         sMode60 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1M60( ) ;
         Gx_mode = sMode60;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1M60( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001M12 */
            pr_default.execute(10, new Object[] {n405DocumentosId, A405DocumentosId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T001M13 */
            pr_default.execute(11, new Object[] {n405DocumentosId, A405DocumentosId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T001M14 */
            pr_default.execute(12, new Object[] {n405DocumentosId, A405DocumentosId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaDocumentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel1M60( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1M60( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("documentos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("documentos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1M60( )
      {
         /* Scan By routine */
         /* Using cursor T001M15 */
         pr_default.execute(13);
         RcdFound60 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound60 = 1;
            A405DocumentosId = T001M15_A405DocumentosId[0];
            n405DocumentosId = T001M15_n405DocumentosId[0];
            AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1M60( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound60 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound60 = 1;
            A405DocumentosId = T001M15_A405DocumentosId[0];
            n405DocumentosId = T001M15_n405DocumentosId[0];
            AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
         }
      }

      protected void ScanEnd1M60( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1M60( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1M60( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1M60( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1M60( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1M60( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1M60( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1M60( )
      {
         edtDocumentosDescricao_Enabled = 0;
         AssignProp("", false, edtDocumentosDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentosDescricao_Enabled), 5, 0), true);
         cmbDocumentosStatus.Enabled = 0;
         AssignProp("", false, cmbDocumentosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDocumentosStatus.Enabled), 5, 0), true);
         cmbDocumentoObrigatorio.Enabled = 0;
         AssignProp("", false, cmbDocumentoObrigatorio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDocumentoObrigatorio.Enabled), 5, 0), true);
         cmbDocumentoObrigatorioReembolso.Enabled = 0;
         AssignProp("", false, cmbDocumentoObrigatorioReembolso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDocumentoObrigatorioReembolso.Enabled), 5, 0), true);
         edtDocumentosId_Enabled = 0;
         AssignProp("", false, edtDocumentosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentosId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1M60( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1M0( )
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
         GXEncryptionTmp = "documentos"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DocumentosId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("documentos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Documentos");
         forbiddenHiddens.Add("DocumentosId", context.localUtil.Format( (decimal)(A405DocumentosId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("documentos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         forbiddenHiddens2 = new GXProperties();
         if ( IsIns( )  )
         {
            forbiddenHiddens2.Add("DocumentosStatus", StringUtil.BoolToStr( A407DocumentosStatus));
         }
         GxWebStd.gx_hidden_field( context, "hsh2", GetEncryptedHash( forbiddenHiddens2.ToString(), GXKey));
         GXUtil.WriteLogInfo("documentos:[ SendCondSecurityCheck value for]"+forbiddenHiddens2.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z405DocumentosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z405DocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z407DocumentosStatus", Z407DocumentosStatus);
         GxWebStd.gx_hidden_field( context, "Z406DocumentosDescricao", Z406DocumentosDescricao);
         GxWebStd.gx_boolean_hidden_field( context, "Z413DocumentoObrigatorio", Z413DocumentoObrigatorio);
         GxWebStd.gx_boolean_hidden_field( context, "Z536DocumentoObrigatorioReembolso", Z536DocumentoObrigatorioReembolso);
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
         GxWebStd.gx_hidden_field( context, "vDOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCUMENTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7DocumentosId), "ZZZZZZZZ9"), context));
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
         GXEncryptionTmp = "documentos"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DocumentosId,9,0));
         return formatLink("documentos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Documentos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Documentos" ;
      }

      protected void InitializeNonKey1M60( )
      {
         A407DocumentosStatus = false;
         n407DocumentosStatus = false;
         AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
         n407DocumentosStatus = ((false==A407DocumentosStatus) ? true : false);
         A406DocumentosDescricao = "";
         n406DocumentosDescricao = false;
         AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
         n406DocumentosDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A406DocumentosDescricao)) ? true : false);
         A413DocumentoObrigatorio = false;
         n413DocumentoObrigatorio = false;
         AssignAttri("", false, "A413DocumentoObrigatorio", A413DocumentoObrigatorio);
         n413DocumentoObrigatorio = ((false==A413DocumentoObrigatorio) ? true : false);
         A536DocumentoObrigatorioReembolso = false;
         n536DocumentoObrigatorioReembolso = false;
         AssignAttri("", false, "A536DocumentoObrigatorioReembolso", A536DocumentoObrigatorioReembolso);
         n536DocumentoObrigatorioReembolso = ((false==A536DocumentoObrigatorioReembolso) ? true : false);
         Z407DocumentosStatus = false;
         Z406DocumentosDescricao = "";
         Z413DocumentoObrigatorio = false;
         Z536DocumentoObrigatorioReembolso = false;
      }

      protected void InitAll1M60( )
      {
         A405DocumentosId = 0;
         n405DocumentosId = false;
         AssignAttri("", false, "A405DocumentosId", StringUtil.LTrimStr( (decimal)(A405DocumentosId), 9, 0));
         InitializeNonKey1M60( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A407DocumentosStatus = i407DocumentosStatus;
         n407DocumentosStatus = false;
         AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019164745", true, true);
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
         context.AddJavascriptSource("documentos.js", "?202561019164745", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtDocumentosDescricao_Internalname = "DOCUMENTOSDESCRICAO";
         cmbDocumentosStatus_Internalname = "DOCUMENTOSSTATUS";
         cmbDocumentoObrigatorio_Internalname = "DOCUMENTOOBRIGATORIO";
         cmbDocumentoObrigatorioReembolso_Internalname = "DOCUMENTOOBRIGATORIOREEMBOLSO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtDocumentosId_Internalname = "DOCUMENTOSID";
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
         Form.Caption = "Documentos";
         edtDocumentosId_Jsonclick = "";
         edtDocumentosId_Enabled = 0;
         edtDocumentosId_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbDocumentoObrigatorioReembolso_Jsonclick = "";
         cmbDocumentoObrigatorioReembolso.Enabled = 1;
         cmbDocumentoObrigatorio_Jsonclick = "";
         cmbDocumentoObrigatorio.Enabled = 1;
         cmbDocumentosStatus_Jsonclick = "";
         cmbDocumentosStatus.Enabled = 1;
         edtDocumentosDescricao_Jsonclick = "";
         edtDocumentosDescricao_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Documentos";
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
         cmbDocumentosStatus.Name = "DOCUMENTOSSTATUS";
         cmbDocumentosStatus.WebTags = "";
         cmbDocumentosStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbDocumentosStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbDocumentosStatus.ItemCount > 0 )
         {
            A407DocumentosStatus = StringUtil.StrToBool( cmbDocumentosStatus.getValidValue(StringUtil.BoolToStr( A407DocumentosStatus)));
            n407DocumentosStatus = false;
            AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
         }
         cmbDocumentoObrigatorio.Name = "DOCUMENTOOBRIGATORIO";
         cmbDocumentoObrigatorio.WebTags = "";
         cmbDocumentoObrigatorio.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbDocumentoObrigatorio.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbDocumentoObrigatorio.ItemCount > 0 )
         {
            A413DocumentoObrigatorio = StringUtil.StrToBool( cmbDocumentoObrigatorio.getValidValue(StringUtil.BoolToStr( A413DocumentoObrigatorio)));
            n413DocumentoObrigatorio = false;
            AssignAttri("", false, "A413DocumentoObrigatorio", A413DocumentoObrigatorio);
         }
         cmbDocumentoObrigatorioReembolso.Name = "DOCUMENTOOBRIGATORIOREEMBOLSO";
         cmbDocumentoObrigatorioReembolso.WebTags = "";
         cmbDocumentoObrigatorioReembolso.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbDocumentoObrigatorioReembolso.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbDocumentoObrigatorioReembolso.ItemCount > 0 )
         {
            A536DocumentoObrigatorioReembolso = StringUtil.StrToBool( cmbDocumentoObrigatorioReembolso.getValidValue(StringUtil.BoolToStr( A536DocumentoObrigatorioReembolso)));
            n536DocumentoObrigatorioReembolso = false;
            AssignAttri("", false, "A536DocumentoObrigatorioReembolso", A536DocumentoObrigatorioReembolso);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7DocumentosId","fld":"vDOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7DocumentosId","fld":"vDOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121M2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_DOCUMENTOSID","""{"handler":"Valid_Documentosid","iparms":[]}""");
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
         Z406DocumentosDescricao = "";
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
         A406DocumentosDescricao = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         forbiddenHiddens2 = new GXProperties();
         hsh2 = "";
         sMode60 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T001M4_A405DocumentosId = new int[1] ;
         T001M4_n405DocumentosId = new bool[] {false} ;
         T001M4_A407DocumentosStatus = new bool[] {false} ;
         T001M4_n407DocumentosStatus = new bool[] {false} ;
         T001M4_A406DocumentosDescricao = new string[] {""} ;
         T001M4_n406DocumentosDescricao = new bool[] {false} ;
         T001M4_A413DocumentoObrigatorio = new bool[] {false} ;
         T001M4_n413DocumentoObrigatorio = new bool[] {false} ;
         T001M4_A536DocumentoObrigatorioReembolso = new bool[] {false} ;
         T001M4_n536DocumentoObrigatorioReembolso = new bool[] {false} ;
         T001M5_A405DocumentosId = new int[1] ;
         T001M5_n405DocumentosId = new bool[] {false} ;
         T001M3_A405DocumentosId = new int[1] ;
         T001M3_n405DocumentosId = new bool[] {false} ;
         T001M3_A407DocumentosStatus = new bool[] {false} ;
         T001M3_n407DocumentosStatus = new bool[] {false} ;
         T001M3_A406DocumentosDescricao = new string[] {""} ;
         T001M3_n406DocumentosDescricao = new bool[] {false} ;
         T001M3_A413DocumentoObrigatorio = new bool[] {false} ;
         T001M3_n413DocumentoObrigatorio = new bool[] {false} ;
         T001M3_A536DocumentoObrigatorioReembolso = new bool[] {false} ;
         T001M3_n536DocumentoObrigatorioReembolso = new bool[] {false} ;
         T001M6_A405DocumentosId = new int[1] ;
         T001M6_n405DocumentosId = new bool[] {false} ;
         T001M7_A405DocumentosId = new int[1] ;
         T001M7_n405DocumentosId = new bool[] {false} ;
         T001M2_A405DocumentosId = new int[1] ;
         T001M2_n405DocumentosId = new bool[] {false} ;
         T001M2_A407DocumentosStatus = new bool[] {false} ;
         T001M2_n407DocumentosStatus = new bool[] {false} ;
         T001M2_A406DocumentosDescricao = new string[] {""} ;
         T001M2_n406DocumentosDescricao = new bool[] {false} ;
         T001M2_A413DocumentoObrigatorio = new bool[] {false} ;
         T001M2_n413DocumentoObrigatorio = new bool[] {false} ;
         T001M2_A536DocumentoObrigatorioReembolso = new bool[] {false} ;
         T001M2_n536DocumentoObrigatorioReembolso = new bool[] {false} ;
         T001M9_A405DocumentosId = new int[1] ;
         T001M9_n405DocumentosId = new bool[] {false} ;
         T001M12_A599ClienteDocumentoId = new int[1] ;
         T001M13_A529ReembolsoDocumentoId = new int[1] ;
         T001M14_A414PropostaDocumentosId = new int[1] ;
         T001M15_A405DocumentosId = new int[1] ;
         T001M15_n405DocumentosId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentos__default(),
            new Object[][] {
                new Object[] {
               T001M2_A405DocumentosId, T001M2_A407DocumentosStatus, T001M2_n407DocumentosStatus, T001M2_A406DocumentosDescricao, T001M2_n406DocumentosDescricao, T001M2_A413DocumentoObrigatorio, T001M2_n413DocumentoObrigatorio, T001M2_A536DocumentoObrigatorioReembolso, T001M2_n536DocumentoObrigatorioReembolso
               }
               , new Object[] {
               T001M3_A405DocumentosId, T001M3_A407DocumentosStatus, T001M3_n407DocumentosStatus, T001M3_A406DocumentosDescricao, T001M3_n406DocumentosDescricao, T001M3_A413DocumentoObrigatorio, T001M3_n413DocumentoObrigatorio, T001M3_A536DocumentoObrigatorioReembolso, T001M3_n536DocumentoObrigatorioReembolso
               }
               , new Object[] {
               T001M4_A405DocumentosId, T001M4_A407DocumentosStatus, T001M4_n407DocumentosStatus, T001M4_A406DocumentosDescricao, T001M4_n406DocumentosDescricao, T001M4_A413DocumentoObrigatorio, T001M4_n413DocumentoObrigatorio, T001M4_A536DocumentoObrigatorioReembolso, T001M4_n536DocumentoObrigatorioReembolso
               }
               , new Object[] {
               T001M5_A405DocumentosId
               }
               , new Object[] {
               T001M6_A405DocumentosId
               }
               , new Object[] {
               T001M7_A405DocumentosId
               }
               , new Object[] {
               }
               , new Object[] {
               T001M9_A405DocumentosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001M12_A599ClienteDocumentoId
               }
               , new Object[] {
               T001M13_A529ReembolsoDocumentoId
               }
               , new Object[] {
               T001M14_A414PropostaDocumentosId
               }
               , new Object[] {
               T001M15_A405DocumentosId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound60 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7DocumentosId ;
      private int Z405DocumentosId ;
      private int AV7DocumentosId ;
      private int trnEnded ;
      private int edtDocumentosDescricao_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int A405DocumentosId ;
      private int edtDocumentosId_Enabled ;
      private int edtDocumentosId_Visible ;
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
      private string edtDocumentosDescricao_Internalname ;
      private string cmbDocumentosStatus_Internalname ;
      private string cmbDocumentoObrigatorio_Internalname ;
      private string cmbDocumentoObrigatorioReembolso_Internalname ;
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
      private string edtDocumentosDescricao_Jsonclick ;
      private string cmbDocumentosStatus_Jsonclick ;
      private string cmbDocumentoObrigatorio_Jsonclick ;
      private string cmbDocumentoObrigatorioReembolso_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtDocumentosId_Internalname ;
      private string edtDocumentosId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string hsh2 ;
      private string sMode60 ;
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
      private bool Z407DocumentosStatus ;
      private bool Z413DocumentoObrigatorio ;
      private bool Z536DocumentoObrigatorioReembolso ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A407DocumentosStatus ;
      private bool n407DocumentosStatus ;
      private bool A413DocumentoObrigatorio ;
      private bool n413DocumentoObrigatorio ;
      private bool A536DocumentoObrigatorioReembolso ;
      private bool n536DocumentoObrigatorioReembolso ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n406DocumentosDescricao ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n405DocumentosId ;
      private bool returnInSub ;
      private bool i407DocumentosStatus ;
      private string Z406DocumentosDescricao ;
      private string A406DocumentosDescricao ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXProperties forbiddenHiddens2 ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbDocumentosStatus ;
      private GXCombobox cmbDocumentoObrigatorio ;
      private GXCombobox cmbDocumentoObrigatorioReembolso ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] T001M4_A405DocumentosId ;
      private bool[] T001M4_n405DocumentosId ;
      private bool[] T001M4_A407DocumentosStatus ;
      private bool[] T001M4_n407DocumentosStatus ;
      private string[] T001M4_A406DocumentosDescricao ;
      private bool[] T001M4_n406DocumentosDescricao ;
      private bool[] T001M4_A413DocumentoObrigatorio ;
      private bool[] T001M4_n413DocumentoObrigatorio ;
      private bool[] T001M4_A536DocumentoObrigatorioReembolso ;
      private bool[] T001M4_n536DocumentoObrigatorioReembolso ;
      private int[] T001M5_A405DocumentosId ;
      private bool[] T001M5_n405DocumentosId ;
      private int[] T001M3_A405DocumentosId ;
      private bool[] T001M3_n405DocumentosId ;
      private bool[] T001M3_A407DocumentosStatus ;
      private bool[] T001M3_n407DocumentosStatus ;
      private string[] T001M3_A406DocumentosDescricao ;
      private bool[] T001M3_n406DocumentosDescricao ;
      private bool[] T001M3_A413DocumentoObrigatorio ;
      private bool[] T001M3_n413DocumentoObrigatorio ;
      private bool[] T001M3_A536DocumentoObrigatorioReembolso ;
      private bool[] T001M3_n536DocumentoObrigatorioReembolso ;
      private int[] T001M6_A405DocumentosId ;
      private bool[] T001M6_n405DocumentosId ;
      private int[] T001M7_A405DocumentosId ;
      private bool[] T001M7_n405DocumentosId ;
      private int[] T001M2_A405DocumentosId ;
      private bool[] T001M2_n405DocumentosId ;
      private bool[] T001M2_A407DocumentosStatus ;
      private bool[] T001M2_n407DocumentosStatus ;
      private string[] T001M2_A406DocumentosDescricao ;
      private bool[] T001M2_n406DocumentosDescricao ;
      private bool[] T001M2_A413DocumentoObrigatorio ;
      private bool[] T001M2_n413DocumentoObrigatorio ;
      private bool[] T001M2_A536DocumentoObrigatorioReembolso ;
      private bool[] T001M2_n536DocumentoObrigatorioReembolso ;
      private int[] T001M9_A405DocumentosId ;
      private bool[] T001M9_n405DocumentosId ;
      private int[] T001M12_A599ClienteDocumentoId ;
      private int[] T001M13_A529ReembolsoDocumentoId ;
      private int[] T001M14_A414PropostaDocumentosId ;
      private int[] T001M15_A405DocumentosId ;
      private bool[] T001M15_n405DocumentosId ;
   }

   public class documentos__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001M2;
          prmT001M2 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001M3;
          prmT001M3 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001M4;
          prmT001M4 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001M5;
          prmT001M5 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001M6;
          prmT001M6 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001M7;
          prmT001M7 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001M8;
          prmT001M8 = new Object[] {
          new ParDef("DocumentosStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("DocumentosDescricao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("DocumentoObrigatorio",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("DocumentoObrigatorioReembolso",GXType.Boolean,4,0){Nullable=true}
          };
          Object[] prmT001M9;
          prmT001M9 = new Object[] {
          };
          Object[] prmT001M10;
          prmT001M10 = new Object[] {
          new ParDef("DocumentosStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("DocumentosDescricao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("DocumentoObrigatorio",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("DocumentoObrigatorioReembolso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001M11;
          prmT001M11 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001M12;
          prmT001M12 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001M13;
          prmT001M13 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001M14;
          prmT001M14 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001M15;
          prmT001M15 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T001M2", "SELECT DocumentosId, DocumentosStatus, DocumentosDescricao, DocumentoObrigatorio, DocumentoObrigatorioReembolso FROM Documentos WHERE DocumentosId = :DocumentosId  FOR UPDATE OF Documentos NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001M2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001M3", "SELECT DocumentosId, DocumentosStatus, DocumentosDescricao, DocumentoObrigatorio, DocumentoObrigatorioReembolso FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001M4", "SELECT TM1.DocumentosId, TM1.DocumentosStatus, TM1.DocumentosDescricao, TM1.DocumentoObrigatorio, TM1.DocumentoObrigatorioReembolso FROM Documentos TM1 WHERE TM1.DocumentosId = :DocumentosId ORDER BY TM1.DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001M5", "SELECT DocumentosId FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001M6", "SELECT DocumentosId FROM Documentos WHERE ( DocumentosId > :DocumentosId) ORDER BY DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001M7", "SELECT DocumentosId FROM Documentos WHERE ( DocumentosId < :DocumentosId) ORDER BY DocumentosId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001M8", "SAVEPOINT gxupdate;INSERT INTO Documentos(DocumentosStatus, DocumentosDescricao, DocumentoObrigatorio, DocumentoObrigatorioReembolso) VALUES(:DocumentosStatus, :DocumentosDescricao, :DocumentoObrigatorio, :DocumentoObrigatorioReembolso);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001M8)
             ,new CursorDef("T001M9", "SELECT currval('DocumentosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001M10", "SAVEPOINT gxupdate;UPDATE Documentos SET DocumentosStatus=:DocumentosStatus, DocumentosDescricao=:DocumentosDescricao, DocumentoObrigatorio=:DocumentoObrigatorio, DocumentoObrigatorioReembolso=:DocumentoObrigatorioReembolso  WHERE DocumentosId = :DocumentosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001M10)
             ,new CursorDef("T001M11", "SAVEPOINT gxupdate;DELETE FROM Documentos  WHERE DocumentosId = :DocumentosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001M11)
             ,new CursorDef("T001M12", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001M13", "SELECT ReembolsoDocumentoId FROM ReembolsoDocumento WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001M14", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001M15", "SELECT DocumentosId FROM Documentos ORDER BY DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M15,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
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
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
