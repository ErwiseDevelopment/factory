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
   public class tipocliente : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "tipocliente")), "tipocliente") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "tipocliente")))) ;
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
                  AV7TipoClienteId = (short)(Math.Round(NumberUtil.Val( GetPar( "TipoClienteId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7TipoClienteId", StringUtil.LTrimStr( (decimal)(AV7TipoClienteId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTIPOCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipoClienteId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Tipo Cliente", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipoClienteDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tipocliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipocliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_TipoClienteId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TipoClienteId = aP1_TipoClienteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTipoClienteTipoPessoa = new GXCombobox();
         cmbTipoClientePortal = new GXCombobox();
         cmbTipoClientePortalPjPf = new GXCombobox();
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
         if ( cmbTipoClienteTipoPessoa.ItemCount > 0 )
         {
            A194TipoClienteTipoPessoa = cmbTipoClienteTipoPessoa.getValidValue(A194TipoClienteTipoPessoa);
            n194TipoClienteTipoPessoa = false;
            AssignAttri("", false, "A194TipoClienteTipoPessoa", A194TipoClienteTipoPessoa);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTipoClienteTipoPessoa.CurrentValue = StringUtil.RTrim( A194TipoClienteTipoPessoa);
            AssignProp("", false, cmbTipoClienteTipoPessoa_Internalname, "Values", cmbTipoClienteTipoPessoa.ToJavascriptSource(), true);
         }
         if ( cmbTipoClientePortal.ItemCount > 0 )
         {
            A207TipoClientePortal = StringUtil.StrToBool( cmbTipoClientePortal.getValidValue(StringUtil.BoolToStr( A207TipoClientePortal)));
            n207TipoClientePortal = false;
            AssignAttri("", false, "A207TipoClientePortal", A207TipoClientePortal);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTipoClientePortal.CurrentValue = StringUtil.BoolToStr( A207TipoClientePortal);
            AssignProp("", false, cmbTipoClientePortal_Internalname, "Values", cmbTipoClientePortal.ToJavascriptSource(), true);
         }
         if ( cmbTipoClientePortalPjPf.ItemCount > 0 )
         {
            A793TipoClientePortalPjPf = StringUtil.StrToBool( cmbTipoClientePortalPjPf.getValidValue(StringUtil.BoolToStr( A793TipoClientePortalPjPf)));
            n793TipoClientePortalPjPf = false;
            AssignAttri("", false, "A793TipoClientePortalPjPf", A793TipoClientePortalPjPf);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTipoClientePortalPjPf.CurrentValue = StringUtil.BoolToStr( A793TipoClientePortalPjPf);
            AssignProp("", false, cmbTipoClientePortalPjPf_Internalname, "Values", cmbTipoClientePortalPjPf.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTipoClienteDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoClienteDescricao_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoClienteDescricao_Internalname, A193TipoClienteDescricao, StringUtil.RTrim( context.localUtil.Format( A193TipoClienteDescricao, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoClienteDescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTipoClienteDescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TipoCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTipoClienteTipoPessoa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTipoClienteTipoPessoa_Internalname, "Tipo Pessoa", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTipoClienteTipoPessoa, cmbTipoClienteTipoPessoa_Internalname, StringUtil.RTrim( A194TipoClienteTipoPessoa), 1, cmbTipoClienteTipoPessoa_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbTipoClienteTipoPessoa.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_TipoCliente.htm");
         cmbTipoClienteTipoPessoa.CurrentValue = StringUtil.RTrim( A194TipoClienteTipoPessoa);
         AssignProp("", false, cmbTipoClienteTipoPessoa_Internalname, "Values", (string)(cmbTipoClienteTipoPessoa.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTipoClientePortal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTipoClientePortal_Internalname, "Acesso ao portal clinica", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTipoClientePortal, cmbTipoClientePortal_Internalname, StringUtil.BoolToStr( A207TipoClientePortal), 1, cmbTipoClientePortal_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbTipoClientePortal.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 0, "HLP_TipoCliente.htm");
         cmbTipoClientePortal.CurrentValue = StringUtil.BoolToStr( A207TipoClientePortal);
         AssignProp("", false, cmbTipoClientePortal_Internalname, "Values", (string)(cmbTipoClientePortal.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTipoClientePortalPjPf_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTipoClientePortalPjPf_Internalname, "Acesso ao portal PF/PJ", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTipoClientePortalPjPf, cmbTipoClientePortalPjPf_Internalname, StringUtil.BoolToStr( A793TipoClientePortalPjPf), 1, cmbTipoClientePortalPjPf_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbTipoClientePortalPjPf.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_TipoCliente.htm");
         cmbTipoClientePortalPjPf.CurrentValue = StringUtil.BoolToStr( A793TipoClientePortalPjPf);
         AssignProp("", false, cmbTipoClientePortalPjPf_Internalname, "Values", (string)(cmbTipoClientePortalPjPf.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoCliente.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ",", "")), StringUtil.LTrim( ((edtTipoClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A192TipoClienteId), "ZZZ9") : context.localUtil.Format( (decimal)(A192TipoClienteId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoClienteId_Jsonclick, 0, "Attribute", "", "", "", "", edtTipoClienteId_Visible, edtTipoClienteId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TipoCliente.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTipoClienteCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTipoClienteCreatedAt_Internalname, context.localUtil.TToC( A195TipoClienteCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A195TipoClienteCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoClienteCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", edtTipoClienteCreatedAt_Visible, edtTipoClienteCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TipoCliente.htm");
         GxWebStd.gx_bitmap( context, edtTipoClienteCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTipoClienteCreatedAt_Visible==0)||(edtTipoClienteCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TipoCliente.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTipoClienteUpdateAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTipoClienteUpdateAt_Internalname, context.localUtil.TToC( A196TipoClienteUpdateAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A196TipoClienteUpdateAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoClienteUpdateAt_Jsonclick, 0, "Attribute", "", "", "", "", edtTipoClienteUpdateAt_Visible, edtTipoClienteUpdateAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TipoCliente.htm");
         GxWebStd.gx_bitmap( context, edtTipoClienteUpdateAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTipoClienteUpdateAt_Visible==0)||(edtTipoClienteUpdateAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TipoCliente.htm");
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
         E110S2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z192TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z192TipoClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               Z195TipoClienteCreatedAt = context.localUtil.CToT( cgiGet( "Z195TipoClienteCreatedAt"), 0);
               n195TipoClienteCreatedAt = ((DateTime.MinValue==A195TipoClienteCreatedAt) ? true : false);
               Z193TipoClienteDescricao = cgiGet( "Z193TipoClienteDescricao");
               n193TipoClienteDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A193TipoClienteDescricao)) ? true : false);
               Z194TipoClienteTipoPessoa = cgiGet( "Z194TipoClienteTipoPessoa");
               n194TipoClienteTipoPessoa = (String.IsNullOrEmpty(StringUtil.RTrim( A194TipoClienteTipoPessoa)) ? true : false);
               Z207TipoClientePortal = StringUtil.StrToBool( cgiGet( "Z207TipoClientePortal"));
               n207TipoClientePortal = ((false==A207TipoClientePortal) ? true : false);
               Z793TipoClientePortalPjPf = StringUtil.StrToBool( cgiGet( "Z793TipoClientePortalPjPf"));
               n793TipoClientePortalPjPf = ((false==A793TipoClientePortalPjPf) ? true : false);
               Z219TipoClienteFinancia = StringUtil.StrToBool( cgiGet( "Z219TipoClienteFinancia"));
               n219TipoClienteFinancia = ((false==A219TipoClienteFinancia) ? true : false);
               Z196TipoClienteUpdateAt = context.localUtil.CToT( cgiGet( "Z196TipoClienteUpdateAt"), 0);
               n196TipoClienteUpdateAt = ((DateTime.MinValue==A196TipoClienteUpdateAt) ? true : false);
               A219TipoClienteFinancia = StringUtil.StrToBool( cgiGet( "Z219TipoClienteFinancia"));
               n219TipoClienteFinancia = false;
               n219TipoClienteFinancia = ((false==A219TipoClienteFinancia) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vTIPOCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               A219TipoClienteFinancia = StringUtil.StrToBool( cgiGet( "TIPOCLIENTEFINANCIA"));
               n219TipoClienteFinancia = ((false==A219TipoClienteFinancia) ? true : false);
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
               A193TipoClienteDescricao = StringUtil.Upper( cgiGet( edtTipoClienteDescricao_Internalname));
               n193TipoClienteDescricao = false;
               AssignAttri("", false, "A193TipoClienteDescricao", A193TipoClienteDescricao);
               n193TipoClienteDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A193TipoClienteDescricao)) ? true : false);
               cmbTipoClienteTipoPessoa.CurrentValue = cgiGet( cmbTipoClienteTipoPessoa_Internalname);
               A194TipoClienteTipoPessoa = cgiGet( cmbTipoClienteTipoPessoa_Internalname);
               n194TipoClienteTipoPessoa = false;
               AssignAttri("", false, "A194TipoClienteTipoPessoa", A194TipoClienteTipoPessoa);
               n194TipoClienteTipoPessoa = (String.IsNullOrEmpty(StringUtil.RTrim( A194TipoClienteTipoPessoa)) ? true : false);
               cmbTipoClientePortal.CurrentValue = cgiGet( cmbTipoClientePortal_Internalname);
               A207TipoClientePortal = StringUtil.StrToBool( cgiGet( cmbTipoClientePortal_Internalname));
               n207TipoClientePortal = false;
               AssignAttri("", false, "A207TipoClientePortal", A207TipoClientePortal);
               n207TipoClientePortal = ((false==A207TipoClientePortal) ? true : false);
               cmbTipoClientePortalPjPf.CurrentValue = cgiGet( cmbTipoClientePortalPjPf_Internalname);
               A793TipoClientePortalPjPf = StringUtil.StrToBool( cgiGet( cmbTipoClientePortalPjPf_Internalname));
               n793TipoClientePortalPjPf = false;
               AssignAttri("", false, "A793TipoClientePortalPjPf", A793TipoClientePortalPjPf);
               n793TipoClientePortalPjPf = ((false==A793TipoClientePortalPjPf) ? true : false);
               A192TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n192TipoClienteId = false;
               AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
               if ( context.localUtil.VCDateTime( cgiGet( edtTipoClienteCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Tipo Cliente Created At"}), 1, "TIPOCLIENTECREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtTipoClienteCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A195TipoClienteCreatedAt = (DateTime)(DateTime.MinValue);
                  n195TipoClienteCreatedAt = false;
                  AssignAttri("", false, "A195TipoClienteCreatedAt", context.localUtil.TToC( A195TipoClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A195TipoClienteCreatedAt = context.localUtil.CToT( cgiGet( edtTipoClienteCreatedAt_Internalname));
                  n195TipoClienteCreatedAt = false;
                  AssignAttri("", false, "A195TipoClienteCreatedAt", context.localUtil.TToC( A195TipoClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n195TipoClienteCreatedAt = ((DateTime.MinValue==A195TipoClienteCreatedAt) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtTipoClienteUpdateAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Tipo Cliente Update At"}), 1, "TIPOCLIENTEUPDATEAT");
                  AnyError = 1;
                  GX_FocusControl = edtTipoClienteUpdateAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A196TipoClienteUpdateAt = (DateTime)(DateTime.MinValue);
                  n196TipoClienteUpdateAt = false;
                  AssignAttri("", false, "A196TipoClienteUpdateAt", context.localUtil.TToC( A196TipoClienteUpdateAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A196TipoClienteUpdateAt = context.localUtil.CToT( cgiGet( edtTipoClienteUpdateAt_Internalname));
                  n196TipoClienteUpdateAt = false;
                  AssignAttri("", false, "A196TipoClienteUpdateAt", context.localUtil.TToC( A196TipoClienteUpdateAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n196TipoClienteUpdateAt = ((DateTime.MinValue==A196TipoClienteUpdateAt) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TipoCliente");
               A192TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n192TipoClienteId = false;
               AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
               forbiddenHiddens.Add("TipoClienteId", context.localUtil.Format( (decimal)(A192TipoClienteId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("TipoClienteFinancia", StringUtil.BoolToStr( A219TipoClienteFinancia));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A192TipoClienteId != Z192TipoClienteId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("tipocliente:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A192TipoClienteId = (short)(Math.Round(NumberUtil.Val( GetPar( "TipoClienteId"), "."), 18, MidpointRounding.ToEven));
                  n192TipoClienteId = false;
                  AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
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
                     sMode32 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode32;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound32 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0S0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TIPOCLIENTEID");
                        AnyError = 1;
                        GX_FocusControl = edtTipoClienteId_Internalname;
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
                           E110S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120S2 ();
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
            E120S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0S32( ) ;
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
            DisableAttributes0S32( ) ;
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

      protected void CONFIRM_0S0( )
      {
         BeforeValidate0S32( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0S32( ) ;
            }
            else
            {
               CheckExtendedTable0S32( ) ;
               CloseExtendedTableCursors0S32( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0S0( )
      {
      }

      protected void E110S2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         edtTipoClienteId_Visible = 0;
         AssignProp("", false, edtTipoClienteId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipoClienteId_Visible), 5, 0), true);
         edtTipoClienteCreatedAt_Visible = 0;
         AssignProp("", false, edtTipoClienteCreatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipoClienteCreatedAt_Visible), 5, 0), true);
         edtTipoClienteUpdateAt_Visible = 0;
         AssignProp("", false, edtTipoClienteUpdateAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipoClienteUpdateAt_Visible), 5, 0), true);
      }

      protected void E120S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("tipoclienteww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0S32( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z195TipoClienteCreatedAt = T000S3_A195TipoClienteCreatedAt[0];
               Z193TipoClienteDescricao = T000S3_A193TipoClienteDescricao[0];
               Z194TipoClienteTipoPessoa = T000S3_A194TipoClienteTipoPessoa[0];
               Z207TipoClientePortal = T000S3_A207TipoClientePortal[0];
               Z793TipoClientePortalPjPf = T000S3_A793TipoClientePortalPjPf[0];
               Z219TipoClienteFinancia = T000S3_A219TipoClienteFinancia[0];
               Z196TipoClienteUpdateAt = T000S3_A196TipoClienteUpdateAt[0];
            }
            else
            {
               Z195TipoClienteCreatedAt = A195TipoClienteCreatedAt;
               Z193TipoClienteDescricao = A193TipoClienteDescricao;
               Z194TipoClienteTipoPessoa = A194TipoClienteTipoPessoa;
               Z207TipoClientePortal = A207TipoClientePortal;
               Z793TipoClientePortalPjPf = A793TipoClientePortalPjPf;
               Z219TipoClienteFinancia = A219TipoClienteFinancia;
               Z196TipoClienteUpdateAt = A196TipoClienteUpdateAt;
            }
         }
         if ( GX_JID == -7 )
         {
            Z192TipoClienteId = A192TipoClienteId;
            Z195TipoClienteCreatedAt = A195TipoClienteCreatedAt;
            Z193TipoClienteDescricao = A193TipoClienteDescricao;
            Z194TipoClienteTipoPessoa = A194TipoClienteTipoPessoa;
            Z207TipoClientePortal = A207TipoClientePortal;
            Z793TipoClientePortalPjPf = A793TipoClientePortalPjPf;
            Z219TipoClienteFinancia = A219TipoClienteFinancia;
            Z196TipoClienteUpdateAt = A196TipoClienteUpdateAt;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTipoClienteId_Enabled = 0;
         AssignProp("", false, edtTipoClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoClienteId_Enabled), 5, 0), true);
         edtTipoClienteId_Enabled = 0;
         AssignProp("", false, edtTipoClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoClienteId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TipoClienteId) )
         {
            A192TipoClienteId = AV7TipoClienteId;
            n192TipoClienteId = false;
            AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A195TipoClienteCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n195TipoClienteCreatedAt = false;
            AssignAttri("", false, "A195TipoClienteCreatedAt", context.localUtil.TToC( A195TipoClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
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

      protected void Load0S32( )
      {
         /* Using cursor T000S4 */
         pr_default.execute(2, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound32 = 1;
            A195TipoClienteCreatedAt = T000S4_A195TipoClienteCreatedAt[0];
            n195TipoClienteCreatedAt = T000S4_n195TipoClienteCreatedAt[0];
            AssignAttri("", false, "A195TipoClienteCreatedAt", context.localUtil.TToC( A195TipoClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A193TipoClienteDescricao = T000S4_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = T000S4_n193TipoClienteDescricao[0];
            AssignAttri("", false, "A193TipoClienteDescricao", A193TipoClienteDescricao);
            A194TipoClienteTipoPessoa = T000S4_A194TipoClienteTipoPessoa[0];
            n194TipoClienteTipoPessoa = T000S4_n194TipoClienteTipoPessoa[0];
            AssignAttri("", false, "A194TipoClienteTipoPessoa", A194TipoClienteTipoPessoa);
            A207TipoClientePortal = T000S4_A207TipoClientePortal[0];
            n207TipoClientePortal = T000S4_n207TipoClientePortal[0];
            AssignAttri("", false, "A207TipoClientePortal", A207TipoClientePortal);
            A793TipoClientePortalPjPf = T000S4_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = T000S4_n793TipoClientePortalPjPf[0];
            AssignAttri("", false, "A793TipoClientePortalPjPf", A793TipoClientePortalPjPf);
            A219TipoClienteFinancia = T000S4_A219TipoClienteFinancia[0];
            n219TipoClienteFinancia = T000S4_n219TipoClienteFinancia[0];
            A196TipoClienteUpdateAt = T000S4_A196TipoClienteUpdateAt[0];
            n196TipoClienteUpdateAt = T000S4_n196TipoClienteUpdateAt[0];
            AssignAttri("", false, "A196TipoClienteUpdateAt", context.localUtil.TToC( A196TipoClienteUpdateAt, 8, 5, 0, 3, "/", ":", " "));
            ZM0S32( -7) ;
         }
         pr_default.close(2);
         OnLoadActions0S32( ) ;
      }

      protected void OnLoadActions0S32( )
      {
      }

      protected void CheckExtendedTable0S32( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A193TipoClienteDescricao)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "TIPOCLIENTEDESCRICAO");
            AnyError = 1;
            GX_FocusControl = edtTipoClienteDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A194TipoClienteTipoPessoa, "FISICA") == 0 ) || ( StringUtil.StrCmp(A194TipoClienteTipoPessoa, "JURIDICA") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A194TipoClienteTipoPessoa)) ) )
         {
            GX_msglist.addItem("Campo Tipo Cliente Tipo Pessoa fora do intervalo", "OutOfRange", 1, "TIPOCLIENTETIPOPESSOA");
            AnyError = 1;
            GX_FocusControl = cmbTipoClienteTipoPessoa_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( A207TipoClientePortal && A793TipoClientePortalPjPf )
         {
            GX_msglist.addItem("Não é possível ter acesso á ambos portais", 1, "TIPOCLIENTEPORTAL");
            AnyError = 1;
            GX_FocusControl = cmbTipoClientePortal_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0S32( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0S32( )
      {
         /* Using cursor T000S5 */
         pr_default.execute(3, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000S3 */
         pr_default.execute(1, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0S32( 7) ;
            RcdFound32 = 1;
            A192TipoClienteId = T000S3_A192TipoClienteId[0];
            n192TipoClienteId = T000S3_n192TipoClienteId[0];
            AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
            A195TipoClienteCreatedAt = T000S3_A195TipoClienteCreatedAt[0];
            n195TipoClienteCreatedAt = T000S3_n195TipoClienteCreatedAt[0];
            AssignAttri("", false, "A195TipoClienteCreatedAt", context.localUtil.TToC( A195TipoClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A193TipoClienteDescricao = T000S3_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = T000S3_n193TipoClienteDescricao[0];
            AssignAttri("", false, "A193TipoClienteDescricao", A193TipoClienteDescricao);
            A194TipoClienteTipoPessoa = T000S3_A194TipoClienteTipoPessoa[0];
            n194TipoClienteTipoPessoa = T000S3_n194TipoClienteTipoPessoa[0];
            AssignAttri("", false, "A194TipoClienteTipoPessoa", A194TipoClienteTipoPessoa);
            A207TipoClientePortal = T000S3_A207TipoClientePortal[0];
            n207TipoClientePortal = T000S3_n207TipoClientePortal[0];
            AssignAttri("", false, "A207TipoClientePortal", A207TipoClientePortal);
            A793TipoClientePortalPjPf = T000S3_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = T000S3_n793TipoClientePortalPjPf[0];
            AssignAttri("", false, "A793TipoClientePortalPjPf", A793TipoClientePortalPjPf);
            A219TipoClienteFinancia = T000S3_A219TipoClienteFinancia[0];
            n219TipoClienteFinancia = T000S3_n219TipoClienteFinancia[0];
            A196TipoClienteUpdateAt = T000S3_A196TipoClienteUpdateAt[0];
            n196TipoClienteUpdateAt = T000S3_n196TipoClienteUpdateAt[0];
            AssignAttri("", false, "A196TipoClienteUpdateAt", context.localUtil.TToC( A196TipoClienteUpdateAt, 8, 5, 0, 3, "/", ":", " "));
            Z192TipoClienteId = A192TipoClienteId;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0S32( ) ;
            if ( AnyError == 1 )
            {
               RcdFound32 = 0;
               InitializeNonKey0S32( ) ;
            }
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey0S32( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0S32( ) ;
         if ( RcdFound32 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound32 = 0;
         /* Using cursor T000S6 */
         pr_default.execute(4, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000S6_A192TipoClienteId[0] < A192TipoClienteId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000S6_A192TipoClienteId[0] > A192TipoClienteId ) ) )
            {
               A192TipoClienteId = T000S6_A192TipoClienteId[0];
               n192TipoClienteId = T000S6_n192TipoClienteId[0];
               AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
               RcdFound32 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound32 = 0;
         /* Using cursor T000S7 */
         pr_default.execute(5, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000S7_A192TipoClienteId[0] > A192TipoClienteId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000S7_A192TipoClienteId[0] < A192TipoClienteId ) ) )
            {
               A192TipoClienteId = T000S7_A192TipoClienteId[0];
               n192TipoClienteId = T000S7_n192TipoClienteId[0];
               AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
               RcdFound32 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0S32( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipoClienteDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0S32( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound32 == 1 )
            {
               if ( A192TipoClienteId != Z192TipoClienteId )
               {
                  A192TipoClienteId = Z192TipoClienteId;
                  n192TipoClienteId = false;
                  AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPOCLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtTipoClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipoClienteDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0S32( ) ;
                  GX_FocusControl = edtTipoClienteDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A192TipoClienteId != Z192TipoClienteId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTipoClienteDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0S32( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPOCLIENTEID");
                     AnyError = 1;
                     GX_FocusControl = edtTipoClienteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTipoClienteDescricao_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0S32( ) ;
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
         if ( A192TipoClienteId != Z192TipoClienteId )
         {
            A192TipoClienteId = Z192TipoClienteId;
            n192TipoClienteId = false;
            AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPOCLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtTipoClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipoClienteDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0S32( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000S2 */
            pr_default.execute(0, new Object[] {n192TipoClienteId, A192TipoClienteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoCliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z195TipoClienteCreatedAt != T000S2_A195TipoClienteCreatedAt[0] ) || ( StringUtil.StrCmp(Z193TipoClienteDescricao, T000S2_A193TipoClienteDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z194TipoClienteTipoPessoa, T000S2_A194TipoClienteTipoPessoa[0]) != 0 ) || ( Z207TipoClientePortal != T000S2_A207TipoClientePortal[0] ) || ( Z793TipoClientePortalPjPf != T000S2_A793TipoClientePortalPjPf[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z219TipoClienteFinancia != T000S2_A219TipoClienteFinancia[0] ) || ( Z196TipoClienteUpdateAt != T000S2_A196TipoClienteUpdateAt[0] ) )
            {
               if ( Z195TipoClienteCreatedAt != T000S2_A195TipoClienteCreatedAt[0] )
               {
                  GXUtil.WriteLog("tipocliente:[seudo value changed for attri]"+"TipoClienteCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z195TipoClienteCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A195TipoClienteCreatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z193TipoClienteDescricao, T000S2_A193TipoClienteDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("tipocliente:[seudo value changed for attri]"+"TipoClienteDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z193TipoClienteDescricao);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A193TipoClienteDescricao[0]);
               }
               if ( StringUtil.StrCmp(Z194TipoClienteTipoPessoa, T000S2_A194TipoClienteTipoPessoa[0]) != 0 )
               {
                  GXUtil.WriteLog("tipocliente:[seudo value changed for attri]"+"TipoClienteTipoPessoa");
                  GXUtil.WriteLogRaw("Old: ",Z194TipoClienteTipoPessoa);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A194TipoClienteTipoPessoa[0]);
               }
               if ( Z207TipoClientePortal != T000S2_A207TipoClientePortal[0] )
               {
                  GXUtil.WriteLog("tipocliente:[seudo value changed for attri]"+"TipoClientePortal");
                  GXUtil.WriteLogRaw("Old: ",Z207TipoClientePortal);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A207TipoClientePortal[0]);
               }
               if ( Z793TipoClientePortalPjPf != T000S2_A793TipoClientePortalPjPf[0] )
               {
                  GXUtil.WriteLog("tipocliente:[seudo value changed for attri]"+"TipoClientePortalPjPf");
                  GXUtil.WriteLogRaw("Old: ",Z793TipoClientePortalPjPf);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A793TipoClientePortalPjPf[0]);
               }
               if ( Z219TipoClienteFinancia != T000S2_A219TipoClienteFinancia[0] )
               {
                  GXUtil.WriteLog("tipocliente:[seudo value changed for attri]"+"TipoClienteFinancia");
                  GXUtil.WriteLogRaw("Old: ",Z219TipoClienteFinancia);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A219TipoClienteFinancia[0]);
               }
               if ( Z196TipoClienteUpdateAt != T000S2_A196TipoClienteUpdateAt[0] )
               {
                  GXUtil.WriteLog("tipocliente:[seudo value changed for attri]"+"TipoClienteUpdateAt");
                  GXUtil.WriteLogRaw("Old: ",Z196TipoClienteUpdateAt);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A196TipoClienteUpdateAt[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TipoCliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S32( )
      {
         BeforeValidate0S32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S32( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S32( 0) ;
            CheckOptimisticConcurrency0S32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S8 */
                     pr_default.execute(6, new Object[] {n195TipoClienteCreatedAt, A195TipoClienteCreatedAt, n193TipoClienteDescricao, A193TipoClienteDescricao, n194TipoClienteTipoPessoa, A194TipoClienteTipoPessoa, n207TipoClientePortal, A207TipoClientePortal, n793TipoClientePortalPjPf, A793TipoClientePortalPjPf, n219TipoClienteFinancia, A219TipoClienteFinancia, n196TipoClienteUpdateAt, A196TipoClienteUpdateAt});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000S9 */
                     pr_default.execute(7);
                     A192TipoClienteId = T000S9_A192TipoClienteId[0];
                     n192TipoClienteId = T000S9_n192TipoClienteId[0];
                     AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("TipoCliente");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0S0( ) ;
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
               Load0S32( ) ;
            }
            EndLevel0S32( ) ;
         }
         CloseExtendedTableCursors0S32( ) ;
      }

      protected void Update0S32( )
      {
         BeforeValidate0S32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S32( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S10 */
                     pr_default.execute(8, new Object[] {n195TipoClienteCreatedAt, A195TipoClienteCreatedAt, n193TipoClienteDescricao, A193TipoClienteDescricao, n194TipoClienteTipoPessoa, A194TipoClienteTipoPessoa, n207TipoClientePortal, A207TipoClientePortal, n793TipoClientePortalPjPf, A793TipoClientePortalPjPf, n219TipoClienteFinancia, A219TipoClienteFinancia, n196TipoClienteUpdateAt, A196TipoClienteUpdateAt, n192TipoClienteId, A192TipoClienteId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("TipoCliente");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoCliente"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0S32( ) ;
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
            EndLevel0S32( ) ;
         }
         CloseExtendedTableCursors0S32( ) ;
      }

      protected void DeferredUpdate0S32( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0S32( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S32( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S32( ) ;
            AfterConfirm0S32( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S32( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000S11 */
                  pr_default.execute(9, new Object[] {n192TipoClienteId, A192TipoClienteId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("TipoCliente");
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
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0S32( ) ;
         Gx_mode = sMode32;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0S32( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000S12 */
            pr_default.execute(10, new Object[] {n192TipoClienteId, A192TipoClienteId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel0S32( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0S32( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("tipocliente",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("tipocliente",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0S32( )
      {
         /* Scan By routine */
         /* Using cursor T000S13 */
         pr_default.execute(11);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound32 = 1;
            A192TipoClienteId = T000S13_A192TipoClienteId[0];
            n192TipoClienteId = T000S13_n192TipoClienteId[0];
            AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0S32( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound32 = 1;
            A192TipoClienteId = T000S13_A192TipoClienteId[0];
            n192TipoClienteId = T000S13_n192TipoClienteId[0];
            AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
         }
      }

      protected void ScanEnd0S32( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0S32( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S32( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S32( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S32( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S32( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S32( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S32( )
      {
         edtTipoClienteDescricao_Enabled = 0;
         AssignProp("", false, edtTipoClienteDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoClienteDescricao_Enabled), 5, 0), true);
         cmbTipoClienteTipoPessoa.Enabled = 0;
         AssignProp("", false, cmbTipoClienteTipoPessoa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTipoClienteTipoPessoa.Enabled), 5, 0), true);
         cmbTipoClientePortal.Enabled = 0;
         AssignProp("", false, cmbTipoClientePortal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTipoClientePortal.Enabled), 5, 0), true);
         cmbTipoClientePortalPjPf.Enabled = 0;
         AssignProp("", false, cmbTipoClientePortalPjPf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTipoClientePortalPjPf.Enabled), 5, 0), true);
         edtTipoClienteId_Enabled = 0;
         AssignProp("", false, edtTipoClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoClienteId_Enabled), 5, 0), true);
         edtTipoClienteCreatedAt_Enabled = 0;
         AssignProp("", false, edtTipoClienteCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoClienteCreatedAt_Enabled), 5, 0), true);
         edtTipoClienteUpdateAt_Enabled = 0;
         AssignProp("", false, edtTipoClienteUpdateAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoClienteUpdateAt_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0S32( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0S0( )
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
         GXEncryptionTmp = "tipocliente"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TipoClienteId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("tipocliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TipoCliente");
         forbiddenHiddens.Add("TipoClienteId", context.localUtil.Format( (decimal)(A192TipoClienteId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("TipoClienteFinancia", StringUtil.BoolToStr( A219TipoClienteFinancia));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tipocliente:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z192TipoClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z192TipoClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z195TipoClienteCreatedAt", context.localUtil.TToC( Z195TipoClienteCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z193TipoClienteDescricao", Z193TipoClienteDescricao);
         GxWebStd.gx_hidden_field( context, "Z194TipoClienteTipoPessoa", Z194TipoClienteTipoPessoa);
         GxWebStd.gx_boolean_hidden_field( context, "Z207TipoClientePortal", Z207TipoClientePortal);
         GxWebStd.gx_boolean_hidden_field( context, "Z793TipoClientePortalPjPf", Z793TipoClientePortalPjPf);
         GxWebStd.gx_boolean_hidden_field( context, "Z219TipoClienteFinancia", Z219TipoClienteFinancia);
         GxWebStd.gx_hidden_field( context, "Z196TipoClienteUpdateAt", context.localUtil.TToC( Z196TipoClienteUpdateAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV12TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV12TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vTIPOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TipoClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPOCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipoClienteId), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "TIPOCLIENTEFINANCIA", A219TipoClienteFinancia);
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
         GXEncryptionTmp = "tipocliente"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TipoClienteId,4,0));
         return formatLink("tipocliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "TipoCliente" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo Cliente" ;
      }

      protected void InitializeNonKey0S32( )
      {
         A195TipoClienteCreatedAt = (DateTime)(DateTime.MinValue);
         n195TipoClienteCreatedAt = false;
         AssignAttri("", false, "A195TipoClienteCreatedAt", context.localUtil.TToC( A195TipoClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         n195TipoClienteCreatedAt = ((DateTime.MinValue==A195TipoClienteCreatedAt) ? true : false);
         A193TipoClienteDescricao = "";
         n193TipoClienteDescricao = false;
         AssignAttri("", false, "A193TipoClienteDescricao", A193TipoClienteDescricao);
         n193TipoClienteDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A193TipoClienteDescricao)) ? true : false);
         A194TipoClienteTipoPessoa = "";
         n194TipoClienteTipoPessoa = false;
         AssignAttri("", false, "A194TipoClienteTipoPessoa", A194TipoClienteTipoPessoa);
         n194TipoClienteTipoPessoa = (String.IsNullOrEmpty(StringUtil.RTrim( A194TipoClienteTipoPessoa)) ? true : false);
         A207TipoClientePortal = false;
         n207TipoClientePortal = false;
         AssignAttri("", false, "A207TipoClientePortal", A207TipoClientePortal);
         n207TipoClientePortal = ((false==A207TipoClientePortal) ? true : false);
         A793TipoClientePortalPjPf = false;
         n793TipoClientePortalPjPf = false;
         AssignAttri("", false, "A793TipoClientePortalPjPf", A793TipoClientePortalPjPf);
         n793TipoClientePortalPjPf = ((false==A793TipoClientePortalPjPf) ? true : false);
         A219TipoClienteFinancia = false;
         n219TipoClienteFinancia = false;
         AssignAttri("", false, "A219TipoClienteFinancia", A219TipoClienteFinancia);
         A196TipoClienteUpdateAt = (DateTime)(DateTime.MinValue);
         n196TipoClienteUpdateAt = false;
         AssignAttri("", false, "A196TipoClienteUpdateAt", context.localUtil.TToC( A196TipoClienteUpdateAt, 8, 5, 0, 3, "/", ":", " "));
         n196TipoClienteUpdateAt = ((DateTime.MinValue==A196TipoClienteUpdateAt) ? true : false);
         Z195TipoClienteCreatedAt = (DateTime)(DateTime.MinValue);
         Z193TipoClienteDescricao = "";
         Z194TipoClienteTipoPessoa = "";
         Z207TipoClientePortal = false;
         Z793TipoClientePortalPjPf = false;
         Z219TipoClienteFinancia = false;
         Z196TipoClienteUpdateAt = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll0S32( )
      {
         A192TipoClienteId = 0;
         n192TipoClienteId = false;
         AssignAttri("", false, "A192TipoClienteId", StringUtil.LTrimStr( (decimal)(A192TipoClienteId), 4, 0));
         InitializeNonKey0S32( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A195TipoClienteCreatedAt = i195TipoClienteCreatedAt;
         n195TipoClienteCreatedAt = false;
         AssignAttri("", false, "A195TipoClienteCreatedAt", context.localUtil.TToC( A195TipoClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019132967", true, true);
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
         context.AddJavascriptSource("tipocliente.js", "?202561019132967", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO";
         cmbTipoClienteTipoPessoa_Internalname = "TIPOCLIENTETIPOPESSOA";
         cmbTipoClientePortal_Internalname = "TIPOCLIENTEPORTAL";
         cmbTipoClientePortalPjPf_Internalname = "TIPOCLIENTEPORTALPJPF";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtTipoClienteId_Internalname = "TIPOCLIENTEID";
         edtTipoClienteCreatedAt_Internalname = "TIPOCLIENTECREATEDAT";
         edtTipoClienteUpdateAt_Internalname = "TIPOCLIENTEUPDATEAT";
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
         Form.Caption = "Tipo Cliente";
         edtTipoClienteUpdateAt_Jsonclick = "";
         edtTipoClienteUpdateAt_Enabled = 1;
         edtTipoClienteUpdateAt_Visible = 1;
         edtTipoClienteCreatedAt_Jsonclick = "";
         edtTipoClienteCreatedAt_Enabled = 1;
         edtTipoClienteCreatedAt_Visible = 1;
         edtTipoClienteId_Jsonclick = "";
         edtTipoClienteId_Enabled = 0;
         edtTipoClienteId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbTipoClientePortalPjPf_Jsonclick = "";
         cmbTipoClientePortalPjPf.Enabled = 1;
         cmbTipoClientePortal_Jsonclick = "";
         cmbTipoClientePortal.Enabled = 1;
         cmbTipoClienteTipoPessoa_Jsonclick = "";
         cmbTipoClienteTipoPessoa.Enabled = 1;
         edtTipoClienteDescricao_Jsonclick = "";
         edtTipoClienteDescricao_Enabled = 1;
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
         cmbTipoClienteTipoPessoa.Name = "TIPOCLIENTETIPOPESSOA";
         cmbTipoClienteTipoPessoa.WebTags = "";
         cmbTipoClienteTipoPessoa.addItem("FISICA", "Física", 0);
         cmbTipoClienteTipoPessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbTipoClienteTipoPessoa.ItemCount > 0 )
         {
            A194TipoClienteTipoPessoa = cmbTipoClienteTipoPessoa.getValidValue(A194TipoClienteTipoPessoa);
            n194TipoClienteTipoPessoa = false;
            AssignAttri("", false, "A194TipoClienteTipoPessoa", A194TipoClienteTipoPessoa);
         }
         cmbTipoClientePortal.Name = "TIPOCLIENTEPORTAL";
         cmbTipoClientePortal.WebTags = "";
         cmbTipoClientePortal.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbTipoClientePortal.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbTipoClientePortal.ItemCount > 0 )
         {
            A207TipoClientePortal = StringUtil.StrToBool( cmbTipoClientePortal.getValidValue(StringUtil.BoolToStr( A207TipoClientePortal)));
            n207TipoClientePortal = false;
            AssignAttri("", false, "A207TipoClientePortal", A207TipoClientePortal);
         }
         cmbTipoClientePortalPjPf.Name = "TIPOCLIENTEPORTALPJPF";
         cmbTipoClientePortalPjPf.WebTags = "";
         cmbTipoClientePortalPjPf.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbTipoClientePortalPjPf.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbTipoClientePortalPjPf.ItemCount > 0 )
         {
            A793TipoClientePortalPjPf = StringUtil.StrToBool( cmbTipoClientePortalPjPf.getValidValue(StringUtil.BoolToStr( A793TipoClientePortalPjPf)));
            n793TipoClientePortalPjPf = false;
            AssignAttri("", false, "A793TipoClientePortalPjPf", A793TipoClientePortalPjPf);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV12TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7TipoClienteId","fld":"vTIPOCLIENTEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A192TipoClienteId","fld":"TIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"A219TipoClienteFinancia","fld":"TIPOCLIENTEFINANCIA","type":"boolean"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120S2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV12TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_TIPOCLIENTEDESCRICAO","""{"handler":"Valid_Tipoclientedescricao","iparms":[]}""");
         setEventMetadata("VALID_TIPOCLIENTETIPOPESSOA","""{"handler":"Valid_Tipoclientetipopessoa","iparms":[]}""");
         setEventMetadata("VALID_TIPOCLIENTEPORTAL","""{"handler":"Valid_Tipoclienteportal","iparms":[]}""");
         setEventMetadata("VALID_TIPOCLIENTEPORTALPJPF","""{"handler":"Valid_Tipoclienteportalpjpf","iparms":[]}""");
         setEventMetadata("VALID_TIPOCLIENTEID","""{"handler":"Valid_Tipoclienteid","iparms":[]}""");
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
         Z195TipoClienteCreatedAt = (DateTime)(DateTime.MinValue);
         Z193TipoClienteDescricao = "";
         Z194TipoClienteTipoPessoa = "";
         Z196TipoClienteUpdateAt = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A194TipoClienteTipoPessoa = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A193TipoClienteDescricao = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A195TipoClienteCreatedAt = (DateTime)(DateTime.MinValue);
         A196TipoClienteUpdateAt = (DateTime)(DateTime.MinValue);
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode32 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         T000S4_A192TipoClienteId = new short[1] ;
         T000S4_n192TipoClienteId = new bool[] {false} ;
         T000S4_A195TipoClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T000S4_n195TipoClienteCreatedAt = new bool[] {false} ;
         T000S4_A193TipoClienteDescricao = new string[] {""} ;
         T000S4_n193TipoClienteDescricao = new bool[] {false} ;
         T000S4_A194TipoClienteTipoPessoa = new string[] {""} ;
         T000S4_n194TipoClienteTipoPessoa = new bool[] {false} ;
         T000S4_A207TipoClientePortal = new bool[] {false} ;
         T000S4_n207TipoClientePortal = new bool[] {false} ;
         T000S4_A793TipoClientePortalPjPf = new bool[] {false} ;
         T000S4_n793TipoClientePortalPjPf = new bool[] {false} ;
         T000S4_A219TipoClienteFinancia = new bool[] {false} ;
         T000S4_n219TipoClienteFinancia = new bool[] {false} ;
         T000S4_A196TipoClienteUpdateAt = new DateTime[] {DateTime.MinValue} ;
         T000S4_n196TipoClienteUpdateAt = new bool[] {false} ;
         T000S5_A192TipoClienteId = new short[1] ;
         T000S5_n192TipoClienteId = new bool[] {false} ;
         T000S3_A192TipoClienteId = new short[1] ;
         T000S3_n192TipoClienteId = new bool[] {false} ;
         T000S3_A195TipoClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T000S3_n195TipoClienteCreatedAt = new bool[] {false} ;
         T000S3_A193TipoClienteDescricao = new string[] {""} ;
         T000S3_n193TipoClienteDescricao = new bool[] {false} ;
         T000S3_A194TipoClienteTipoPessoa = new string[] {""} ;
         T000S3_n194TipoClienteTipoPessoa = new bool[] {false} ;
         T000S3_A207TipoClientePortal = new bool[] {false} ;
         T000S3_n207TipoClientePortal = new bool[] {false} ;
         T000S3_A793TipoClientePortalPjPf = new bool[] {false} ;
         T000S3_n793TipoClientePortalPjPf = new bool[] {false} ;
         T000S3_A219TipoClienteFinancia = new bool[] {false} ;
         T000S3_n219TipoClienteFinancia = new bool[] {false} ;
         T000S3_A196TipoClienteUpdateAt = new DateTime[] {DateTime.MinValue} ;
         T000S3_n196TipoClienteUpdateAt = new bool[] {false} ;
         T000S6_A192TipoClienteId = new short[1] ;
         T000S6_n192TipoClienteId = new bool[] {false} ;
         T000S7_A192TipoClienteId = new short[1] ;
         T000S7_n192TipoClienteId = new bool[] {false} ;
         T000S2_A192TipoClienteId = new short[1] ;
         T000S2_n192TipoClienteId = new bool[] {false} ;
         T000S2_A195TipoClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T000S2_n195TipoClienteCreatedAt = new bool[] {false} ;
         T000S2_A193TipoClienteDescricao = new string[] {""} ;
         T000S2_n193TipoClienteDescricao = new bool[] {false} ;
         T000S2_A194TipoClienteTipoPessoa = new string[] {""} ;
         T000S2_n194TipoClienteTipoPessoa = new bool[] {false} ;
         T000S2_A207TipoClientePortal = new bool[] {false} ;
         T000S2_n207TipoClientePortal = new bool[] {false} ;
         T000S2_A793TipoClientePortalPjPf = new bool[] {false} ;
         T000S2_n793TipoClientePortalPjPf = new bool[] {false} ;
         T000S2_A219TipoClienteFinancia = new bool[] {false} ;
         T000S2_n219TipoClienteFinancia = new bool[] {false} ;
         T000S2_A196TipoClienteUpdateAt = new DateTime[] {DateTime.MinValue} ;
         T000S2_n196TipoClienteUpdateAt = new bool[] {false} ;
         T000S9_A192TipoClienteId = new short[1] ;
         T000S9_n192TipoClienteId = new bool[] {false} ;
         T000S12_A168ClienteId = new int[1] ;
         T000S13_A192TipoClienteId = new short[1] ;
         T000S13_n192TipoClienteId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i195TipoClienteCreatedAt = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipocliente__default(),
            new Object[][] {
                new Object[] {
               T000S2_A192TipoClienteId, T000S2_A195TipoClienteCreatedAt, T000S2_n195TipoClienteCreatedAt, T000S2_A193TipoClienteDescricao, T000S2_n193TipoClienteDescricao, T000S2_A194TipoClienteTipoPessoa, T000S2_n194TipoClienteTipoPessoa, T000S2_A207TipoClientePortal, T000S2_n207TipoClientePortal, T000S2_A793TipoClientePortalPjPf,
               T000S2_n793TipoClientePortalPjPf, T000S2_A219TipoClienteFinancia, T000S2_n219TipoClienteFinancia, T000S2_A196TipoClienteUpdateAt, T000S2_n196TipoClienteUpdateAt
               }
               , new Object[] {
               T000S3_A192TipoClienteId, T000S3_A195TipoClienteCreatedAt, T000S3_n195TipoClienteCreatedAt, T000S3_A193TipoClienteDescricao, T000S3_n193TipoClienteDescricao, T000S3_A194TipoClienteTipoPessoa, T000S3_n194TipoClienteTipoPessoa, T000S3_A207TipoClientePortal, T000S3_n207TipoClientePortal, T000S3_A793TipoClientePortalPjPf,
               T000S3_n793TipoClientePortalPjPf, T000S3_A219TipoClienteFinancia, T000S3_n219TipoClienteFinancia, T000S3_A196TipoClienteUpdateAt, T000S3_n196TipoClienteUpdateAt
               }
               , new Object[] {
               T000S4_A192TipoClienteId, T000S4_A195TipoClienteCreatedAt, T000S4_n195TipoClienteCreatedAt, T000S4_A193TipoClienteDescricao, T000S4_n193TipoClienteDescricao, T000S4_A194TipoClienteTipoPessoa, T000S4_n194TipoClienteTipoPessoa, T000S4_A207TipoClientePortal, T000S4_n207TipoClientePortal, T000S4_A793TipoClientePortalPjPf,
               T000S4_n793TipoClientePortalPjPf, T000S4_A219TipoClienteFinancia, T000S4_n219TipoClienteFinancia, T000S4_A196TipoClienteUpdateAt, T000S4_n196TipoClienteUpdateAt
               }
               , new Object[] {
               T000S5_A192TipoClienteId
               }
               , new Object[] {
               T000S6_A192TipoClienteId
               }
               , new Object[] {
               T000S7_A192TipoClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               T000S9_A192TipoClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000S12_A168ClienteId
               }
               , new Object[] {
               T000S13_A192TipoClienteId
               }
            }
         );
      }

      private short wcpOAV7TipoClienteId ;
      private short Z192TipoClienteId ;
      private short GxWebError ;
      private short AV7TipoClienteId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A192TipoClienteId ;
      private short RcdFound32 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtTipoClienteDescricao_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtTipoClienteId_Enabled ;
      private int edtTipoClienteId_Visible ;
      private int edtTipoClienteCreatedAt_Visible ;
      private int edtTipoClienteCreatedAt_Enabled ;
      private int edtTipoClienteUpdateAt_Visible ;
      private int edtTipoClienteUpdateAt_Enabled ;
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
      private string edtTipoClienteDescricao_Internalname ;
      private string cmbTipoClienteTipoPessoa_Internalname ;
      private string cmbTipoClientePortal_Internalname ;
      private string cmbTipoClientePortalPjPf_Internalname ;
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
      private string edtTipoClienteDescricao_Jsonclick ;
      private string cmbTipoClienteTipoPessoa_Jsonclick ;
      private string cmbTipoClientePortal_Jsonclick ;
      private string cmbTipoClientePortalPjPf_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtTipoClienteId_Internalname ;
      private string edtTipoClienteId_Jsonclick ;
      private string edtTipoClienteCreatedAt_Internalname ;
      private string edtTipoClienteCreatedAt_Jsonclick ;
      private string edtTipoClienteUpdateAt_Internalname ;
      private string edtTipoClienteUpdateAt_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode32 ;
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
      private DateTime Z195TipoClienteCreatedAt ;
      private DateTime Z196TipoClienteUpdateAt ;
      private DateTime A195TipoClienteCreatedAt ;
      private DateTime A196TipoClienteUpdateAt ;
      private DateTime i195TipoClienteCreatedAt ;
      private bool Z207TipoClientePortal ;
      private bool Z793TipoClientePortalPjPf ;
      private bool Z219TipoClienteFinancia ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n194TipoClienteTipoPessoa ;
      private bool A207TipoClientePortal ;
      private bool n207TipoClientePortal ;
      private bool A793TipoClientePortalPjPf ;
      private bool n793TipoClientePortalPjPf ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n195TipoClienteCreatedAt ;
      private bool n193TipoClienteDescricao ;
      private bool n219TipoClienteFinancia ;
      private bool A219TipoClienteFinancia ;
      private bool n196TipoClienteUpdateAt ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n192TipoClienteId ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z193TipoClienteDescricao ;
      private string Z194TipoClienteTipoPessoa ;
      private string A194TipoClienteTipoPessoa ;
      private string A193TipoClienteDescricao ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTipoClienteTipoPessoa ;
      private GXCombobox cmbTipoClientePortal ;
      private GXCombobox cmbTipoClientePortalPjPf ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV12TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T000S4_A192TipoClienteId ;
      private bool[] T000S4_n192TipoClienteId ;
      private DateTime[] T000S4_A195TipoClienteCreatedAt ;
      private bool[] T000S4_n195TipoClienteCreatedAt ;
      private string[] T000S4_A193TipoClienteDescricao ;
      private bool[] T000S4_n193TipoClienteDescricao ;
      private string[] T000S4_A194TipoClienteTipoPessoa ;
      private bool[] T000S4_n194TipoClienteTipoPessoa ;
      private bool[] T000S4_A207TipoClientePortal ;
      private bool[] T000S4_n207TipoClientePortal ;
      private bool[] T000S4_A793TipoClientePortalPjPf ;
      private bool[] T000S4_n793TipoClientePortalPjPf ;
      private bool[] T000S4_A219TipoClienteFinancia ;
      private bool[] T000S4_n219TipoClienteFinancia ;
      private DateTime[] T000S4_A196TipoClienteUpdateAt ;
      private bool[] T000S4_n196TipoClienteUpdateAt ;
      private short[] T000S5_A192TipoClienteId ;
      private bool[] T000S5_n192TipoClienteId ;
      private short[] T000S3_A192TipoClienteId ;
      private bool[] T000S3_n192TipoClienteId ;
      private DateTime[] T000S3_A195TipoClienteCreatedAt ;
      private bool[] T000S3_n195TipoClienteCreatedAt ;
      private string[] T000S3_A193TipoClienteDescricao ;
      private bool[] T000S3_n193TipoClienteDescricao ;
      private string[] T000S3_A194TipoClienteTipoPessoa ;
      private bool[] T000S3_n194TipoClienteTipoPessoa ;
      private bool[] T000S3_A207TipoClientePortal ;
      private bool[] T000S3_n207TipoClientePortal ;
      private bool[] T000S3_A793TipoClientePortalPjPf ;
      private bool[] T000S3_n793TipoClientePortalPjPf ;
      private bool[] T000S3_A219TipoClienteFinancia ;
      private bool[] T000S3_n219TipoClienteFinancia ;
      private DateTime[] T000S3_A196TipoClienteUpdateAt ;
      private bool[] T000S3_n196TipoClienteUpdateAt ;
      private short[] T000S6_A192TipoClienteId ;
      private bool[] T000S6_n192TipoClienteId ;
      private short[] T000S7_A192TipoClienteId ;
      private bool[] T000S7_n192TipoClienteId ;
      private short[] T000S2_A192TipoClienteId ;
      private bool[] T000S2_n192TipoClienteId ;
      private DateTime[] T000S2_A195TipoClienteCreatedAt ;
      private bool[] T000S2_n195TipoClienteCreatedAt ;
      private string[] T000S2_A193TipoClienteDescricao ;
      private bool[] T000S2_n193TipoClienteDescricao ;
      private string[] T000S2_A194TipoClienteTipoPessoa ;
      private bool[] T000S2_n194TipoClienteTipoPessoa ;
      private bool[] T000S2_A207TipoClientePortal ;
      private bool[] T000S2_n207TipoClientePortal ;
      private bool[] T000S2_A793TipoClientePortalPjPf ;
      private bool[] T000S2_n793TipoClientePortalPjPf ;
      private bool[] T000S2_A219TipoClienteFinancia ;
      private bool[] T000S2_n219TipoClienteFinancia ;
      private DateTime[] T000S2_A196TipoClienteUpdateAt ;
      private bool[] T000S2_n196TipoClienteUpdateAt ;
      private short[] T000S9_A192TipoClienteId ;
      private bool[] T000S9_n192TipoClienteId ;
      private int[] T000S12_A168ClienteId ;
      private short[] T000S13_A192TipoClienteId ;
      private bool[] T000S13_n192TipoClienteId ;
   }

   public class tipocliente__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000S2;
          prmT000S2 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000S3;
          prmT000S3 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000S4;
          prmT000S4 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000S5;
          prmT000S5 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000S6;
          prmT000S6 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000S7;
          prmT000S7 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000S8;
          prmT000S8 = new Object[] {
          new ParDef("TipoClienteCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("TipoClienteDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TipoClienteTipoPessoa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TipoClientePortal",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TipoClientePortalPjPf",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TipoClienteFinancia",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TipoClienteUpdateAt",GXType.DateTime,8,5){Nullable=true}
          };
          Object[] prmT000S9;
          prmT000S9 = new Object[] {
          };
          Object[] prmT000S10;
          prmT000S10 = new Object[] {
          new ParDef("TipoClienteCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("TipoClienteDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TipoClienteTipoPessoa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TipoClientePortal",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TipoClientePortalPjPf",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TipoClienteFinancia",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TipoClienteUpdateAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000S11;
          prmT000S11 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000S12;
          prmT000S12 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000S13;
          prmT000S13 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000S2", "SELECT TipoClienteId, TipoClienteCreatedAt, TipoClienteDescricao, TipoClienteTipoPessoa, TipoClientePortal, TipoClientePortalPjPf, TipoClienteFinancia, TipoClienteUpdateAt FROM TipoCliente WHERE TipoClienteId = :TipoClienteId  FOR UPDATE OF TipoCliente NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000S2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S3", "SELECT TipoClienteId, TipoClienteCreatedAt, TipoClienteDescricao, TipoClienteTipoPessoa, TipoClientePortal, TipoClientePortalPjPf, TipoClienteFinancia, TipoClienteUpdateAt FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S4", "SELECT TM1.TipoClienteId, TM1.TipoClienteCreatedAt, TM1.TipoClienteDescricao, TM1.TipoClienteTipoPessoa, TM1.TipoClientePortal, TM1.TipoClientePortalPjPf, TM1.TipoClienteFinancia, TM1.TipoClienteUpdateAt FROM TipoCliente TM1 WHERE TM1.TipoClienteId = :TipoClienteId ORDER BY TM1.TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S5", "SELECT TipoClienteId FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S6", "SELECT TipoClienteId FROM TipoCliente WHERE ( TipoClienteId > :TipoClienteId) ORDER BY TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000S7", "SELECT TipoClienteId FROM TipoCliente WHERE ( TipoClienteId < :TipoClienteId) ORDER BY TipoClienteId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000S8", "SAVEPOINT gxupdate;INSERT INTO TipoCliente(TipoClienteCreatedAt, TipoClienteDescricao, TipoClienteTipoPessoa, TipoClientePortal, TipoClientePortalPjPf, TipoClienteFinancia, TipoClienteUpdateAt) VALUES(:TipoClienteCreatedAt, :TipoClienteDescricao, :TipoClienteTipoPessoa, :TipoClientePortal, :TipoClientePortalPjPf, :TipoClienteFinancia, :TipoClienteUpdateAt);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000S8)
             ,new CursorDef("T000S9", "SELECT currval('TipoClienteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S10", "SAVEPOINT gxupdate;UPDATE TipoCliente SET TipoClienteCreatedAt=:TipoClienteCreatedAt, TipoClienteDescricao=:TipoClienteDescricao, TipoClienteTipoPessoa=:TipoClienteTipoPessoa, TipoClientePortal=:TipoClientePortal, TipoClientePortalPjPf=:TipoClientePortalPjPf, TipoClienteFinancia=:TipoClienteFinancia, TipoClienteUpdateAt=:TipoClienteUpdateAt  WHERE TipoClienteId = :TipoClienteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000S10)
             ,new CursorDef("T000S11", "SAVEPOINT gxupdate;DELETE FROM TipoCliente  WHERE TipoClienteId = :TipoClienteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000S11)
             ,new CursorDef("T000S12", "SELECT ClienteId FROM Cliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000S13", "SELECT TipoClienteId FROM TipoCliente ORDER BY TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S13,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
