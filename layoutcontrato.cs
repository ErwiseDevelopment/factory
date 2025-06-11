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
   public class layoutcontrato : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "layoutcontrato")), "layoutcontrato") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "layoutcontrato")))) ;
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
                  AV7LayoutContratoId = (short)(Math.Round(NumberUtil.Val( GetPar( "LayoutContratoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7LayoutContratoId", StringUtil.LTrimStr( (decimal)(AV7LayoutContratoId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vLAYOUTCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7LayoutContratoId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", " Layout de contratos", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLayoutContratoDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public layoutcontrato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public layoutcontrato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_LayoutContratoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7LayoutContratoId = aP1_LayoutContratoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbLayoutContratoStatus = new GXCombobox();
         cmbLayoutContratoTipo = new GXCombobox();
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
         if ( cmbLayoutContratoStatus.ItemCount > 0 )
         {
            A156LayoutContratoStatus = StringUtil.StrToBool( cmbLayoutContratoStatus.getValidValue(StringUtil.BoolToStr( A156LayoutContratoStatus)));
            n156LayoutContratoStatus = false;
            AssignAttri("", false, "A156LayoutContratoStatus", A156LayoutContratoStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbLayoutContratoStatus.CurrentValue = StringUtil.BoolToStr( A156LayoutContratoStatus);
            AssignProp("", false, cmbLayoutContratoStatus_Internalname, "Values", cmbLayoutContratoStatus.ToJavascriptSource(), true);
         }
         if ( cmbLayoutContratoTipo.ItemCount > 0 )
         {
            A906LayoutContratoTipo = cmbLayoutContratoTipo.getValidValue(A906LayoutContratoTipo);
            n906LayoutContratoTipo = false;
            AssignAttri("", false, "A906LayoutContratoTipo", A906LayoutContratoTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbLayoutContratoTipo.CurrentValue = StringUtil.RTrim( A906LayoutContratoTipo);
            AssignProp("", false, cmbLayoutContratoTipo_Internalname, "Values", cmbLayoutContratoTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLayoutContratoDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLayoutContratoDescricao_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLayoutContratoDescricao_Internalname, A155LayoutContratoDescricao, StringUtil.RTrim( context.localUtil.Format( A155LayoutContratoDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLayoutContratoDescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtLayoutContratoDescricao_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LayoutContrato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbLayoutContratoStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbLayoutContratoStatus_Internalname, "Ativo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbLayoutContratoStatus, cmbLayoutContratoStatus_Internalname, StringUtil.BoolToStr( A156LayoutContratoStatus), 1, cmbLayoutContratoStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbLayoutContratoStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_LayoutContrato.htm");
         cmbLayoutContratoStatus.CurrentValue = StringUtil.BoolToStr( A156LayoutContratoStatus);
         AssignProp("", false, cmbLayoutContratoStatus_Internalname, "Values", (string)(cmbLayoutContratoStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbLayoutContratoTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbLayoutContratoTipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbLayoutContratoTipo, cmbLayoutContratoTipo_Internalname, StringUtil.RTrim( A906LayoutContratoTipo), 1, cmbLayoutContratoTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbLayoutContratoTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_LayoutContrato.htm");
         cmbLayoutContratoTipo.CurrentValue = StringUtil.RTrim( A906LayoutContratoTipo);
         AssignProp("", false, cmbLayoutContratoTipo_Internalname, "Values", (string)(cmbLayoutContratoTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutcontratotag_cell_Internalname, 1, 0, "px", 0, "px", divLayoutcontratotag_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtLayoutContratoTag_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLayoutContratoTag_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLayoutContratoTag_Internalname, "Tag", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLayoutContratoTag_Internalname, A1000LayoutContratoTag, StringUtil.RTrim( context.localUtil.Format( A1000LayoutContratoTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLayoutContratoTag_Jsonclick, 0, "AttributeFL", "", "", "", "", edtLayoutContratoTag_Visible, edtLayoutContratoTag_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LayoutContrato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Layoutcontratocorpo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, Layoutcontratocorpo_Internalname, "Corpo", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucLayoutcontratocorpo.SetProperty("Attribute", LayoutContratoCorpo);
         ucLayoutcontratocorpo.SetProperty("CaptionClass", Layoutcontratocorpo_Captionclass);
         ucLayoutcontratocorpo.SetProperty("CaptionStyle", Layoutcontratocorpo_Captionstyle);
         ucLayoutcontratocorpo.SetProperty("CaptionPosition", Layoutcontratocorpo_Captionposition);
         ucLayoutcontratocorpo.Render(context, "fckeditor", Layoutcontratocorpo_Internalname, "LAYOUTCONTRATOCORPOContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabletags_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         if ( ! isFullAjaxMode( ) )
         {
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0048"+"", StringUtil.RTrim( WebComp_Wctagsww_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent");
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0048"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wctagsww_Component) != 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWctagsww), StringUtil.Lower( WebComp_Wctagsww_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0048"+"");
               }
               WebComp_Wctagsww.componentdraw();
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWctagsww), StringUtil.Lower( WebComp_Wctagsww_Component)) != 0 )
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_LayoutContrato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_LayoutContrato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_LayoutContrato.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLayoutContratoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A154LayoutContratoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtLayoutContratoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A154LayoutContratoId), "ZZZ9") : context.localUtil.Format( (decimal)(A154LayoutContratoId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLayoutContratoId_Jsonclick, 0, "Attribute", "", "", "", "", edtLayoutContratoId_Visible, edtLayoutContratoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LayoutContrato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wctagsww_Component) != 0 )
               {
                  WebComp_Wctagsww.componentstart();
               }
            }
         }
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
         E110L2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z154LayoutContratoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z154LayoutContratoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z155LayoutContratoDescricao = cgiGet( "Z155LayoutContratoDescricao");
               n155LayoutContratoDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A155LayoutContratoDescricao)) ? true : false);
               Z156LayoutContratoStatus = StringUtil.StrToBool( cgiGet( "Z156LayoutContratoStatus"));
               n156LayoutContratoStatus = ((false==A156LayoutContratoStatus) ? true : false);
               Z906LayoutContratoTipo = cgiGet( "Z906LayoutContratoTipo");
               n906LayoutContratoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A906LayoutContratoTipo)) ? true : false);
               Z1000LayoutContratoTag = cgiGet( "Z1000LayoutContratoTag");
               n1000LayoutContratoTag = (String.IsNullOrEmpty(StringUtil.RTrim( A1000LayoutContratoTag)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7LayoutContratoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vLAYOUTCONTRATOID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A157LayoutContratoCorpo = cgiGet( "LAYOUTCONTRATOCORPO");
               n157LayoutContratoCorpo = false;
               n157LayoutContratoCorpo = (String.IsNullOrEmpty(StringUtil.RTrim( A157LayoutContratoCorpo)) ? true : false);
               Layoutcontratocorpo_Objectcall = cgiGet( "LAYOUTCONTRATOCORPO_Objectcall");
               Layoutcontratocorpo_Class = cgiGet( "LAYOUTCONTRATOCORPO_Class");
               Layoutcontratocorpo_Enabled = StringUtil.StrToBool( cgiGet( "LAYOUTCONTRATOCORPO_Enabled"));
               Layoutcontratocorpo_Width = cgiGet( "LAYOUTCONTRATOCORPO_Width");
               Layoutcontratocorpo_Height = cgiGet( "LAYOUTCONTRATOCORPO_Height");
               Layoutcontratocorpo_Skin = cgiGet( "LAYOUTCONTRATOCORPO_Skin");
               Layoutcontratocorpo_Toolbar = cgiGet( "LAYOUTCONTRATOCORPO_Toolbar");
               Layoutcontratocorpo_Customtoolbar = cgiGet( "LAYOUTCONTRATOCORPO_Customtoolbar");
               Layoutcontratocorpo_Customconfiguration = cgiGet( "LAYOUTCONTRATOCORPO_Customconfiguration");
               Layoutcontratocorpo_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "LAYOUTCONTRATOCORPO_Toolbarcancollapse"));
               Layoutcontratocorpo_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "LAYOUTCONTRATOCORPO_Toolbarexpanded"));
               Layoutcontratocorpo_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "LAYOUTCONTRATOCORPO_Color"), ",", "."), 18, MidpointRounding.ToEven));
               Layoutcontratocorpo_Buttonpressedid = cgiGet( "LAYOUTCONTRATOCORPO_Buttonpressedid");
               Layoutcontratocorpo_Captionvalue = cgiGet( "LAYOUTCONTRATOCORPO_Captionvalue");
               Layoutcontratocorpo_Captionclass = cgiGet( "LAYOUTCONTRATOCORPO_Captionclass");
               Layoutcontratocorpo_Captionstyle = cgiGet( "LAYOUTCONTRATOCORPO_Captionstyle");
               Layoutcontratocorpo_Captionposition = cgiGet( "LAYOUTCONTRATOCORPO_Captionposition");
               Layoutcontratocorpo_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "LAYOUTCONTRATOCORPO_Isabstractlayoutcontrol"));
               Layoutcontratocorpo_Coltitle = cgiGet( "LAYOUTCONTRATOCORPO_Coltitle");
               Layoutcontratocorpo_Coltitlefont = cgiGet( "LAYOUTCONTRATOCORPO_Coltitlefont");
               Layoutcontratocorpo_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "LAYOUTCONTRATOCORPO_Coltitlecolor"), ",", "."), 18, MidpointRounding.ToEven));
               Layoutcontratocorpo_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "LAYOUTCONTRATOCORPO_Usercontroliscolumn"));
               Layoutcontratocorpo_Visible = StringUtil.StrToBool( cgiGet( "LAYOUTCONTRATOCORPO_Visible"));
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
               A155LayoutContratoDescricao = cgiGet( edtLayoutContratoDescricao_Internalname);
               n155LayoutContratoDescricao = false;
               AssignAttri("", false, "A155LayoutContratoDescricao", A155LayoutContratoDescricao);
               n155LayoutContratoDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A155LayoutContratoDescricao)) ? true : false);
               cmbLayoutContratoStatus.CurrentValue = cgiGet( cmbLayoutContratoStatus_Internalname);
               A156LayoutContratoStatus = StringUtil.StrToBool( cgiGet( cmbLayoutContratoStatus_Internalname));
               n156LayoutContratoStatus = false;
               AssignAttri("", false, "A156LayoutContratoStatus", A156LayoutContratoStatus);
               n156LayoutContratoStatus = ((false==A156LayoutContratoStatus) ? true : false);
               cmbLayoutContratoTipo.CurrentValue = cgiGet( cmbLayoutContratoTipo_Internalname);
               A906LayoutContratoTipo = cgiGet( cmbLayoutContratoTipo_Internalname);
               n906LayoutContratoTipo = false;
               AssignAttri("", false, "A906LayoutContratoTipo", A906LayoutContratoTipo);
               n906LayoutContratoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A906LayoutContratoTipo)) ? true : false);
               A1000LayoutContratoTag = cgiGet( edtLayoutContratoTag_Internalname);
               n1000LayoutContratoTag = false;
               AssignAttri("", false, "A1000LayoutContratoTag", A1000LayoutContratoTag);
               n1000LayoutContratoTag = (String.IsNullOrEmpty(StringUtil.RTrim( A1000LayoutContratoTag)) ? true : false);
               A154LayoutContratoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtLayoutContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"LayoutContrato");
               A154LayoutContratoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtLayoutContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
               forbiddenHiddens.Add("LayoutContratoId", context.localUtil.Format( (decimal)(A154LayoutContratoId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A154LayoutContratoId != Z154LayoutContratoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("layoutcontrato:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A156LayoutContratoStatus = StringUtil.StrToBool( cgiGet( cmbLayoutContratoStatus_Internalname));
                  n156LayoutContratoStatus = false;
                  AssignAttri("", false, "A156LayoutContratoStatus", A156LayoutContratoStatus);
                  forbiddenHiddens2.Add("LayoutContratoStatus", StringUtil.BoolToStr( A156LayoutContratoStatus));
               }
               hsh2 = cgiGet( "hsh2");
               if ( ( ! ( ( A154LayoutContratoId != Z154LayoutContratoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens2.ToString(), hsh2, GXKey) )
               {
                  GXUtil.WriteLogError("layoutcontrato:[ CondSecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens2.ToJSonString());
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
                  A154LayoutContratoId = (short)(Math.Round(NumberUtil.Val( GetPar( "LayoutContratoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
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
                     sMode25 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode25;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound25 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0L0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "LAYOUTCONTRATOID");
                        AnyError = 1;
                        GX_FocusControl = edtLayoutContratoId_Internalname;
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
                           E110L2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120L2 ();
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
                  else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 4);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 48 )
                     {
                        OldWctagsww = cgiGet( "W0048");
                        if ( ( StringUtil.Len( OldWctagsww) == 0 ) || ( StringUtil.StrCmp(OldWctagsww, WebComp_Wctagsww_Component) != 0 ) )
                        {
                           WebComp_Wctagsww = getWebComponent(GetType(), "GeneXus.Programs", OldWctagsww, new Object[] {context} );
                           WebComp_Wctagsww.ComponentInit();
                           WebComp_Wctagsww.Name = "OldWctagsww";
                           WebComp_Wctagsww_Component = OldWctagsww;
                        }
                        if ( StringUtil.Len( WebComp_Wctagsww_Component) != 0 )
                        {
                           WebComp_Wctagsww.componentprocess("W0048", "", sEvt);
                        }
                        WebComp_Wctagsww_Component = OldWctagsww;
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
            E120L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0L25( ) ;
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
            DisableAttributes0L25( ) ;
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

      protected void CONFIRM_0L0( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0L25( ) ;
            }
            else
            {
               CheckExtendedTable0L25( ) ;
               CloseExtendedTableCursors0L25( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0L0( )
      {
      }

      protected void E110L2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtLayoutContratoId_Visible = 0;
         AssignProp("", false, edtLayoutContratoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLayoutContratoId_Visible), 5, 0), true);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wctagsww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wctagsww_Component), StringUtil.Lower( "TagsWW")) != 0 )
         {
            WebComp_Wctagsww = getWebComponent(GetType(), "GeneXus.Programs", "tagsww", new Object[] {context} );
            WebComp_Wctagsww.ComponentInit();
            WebComp_Wctagsww.Name = "TagsWW";
            WebComp_Wctagsww_Component = "TagsWW";
         }
         if ( StringUtil.Len( WebComp_Wctagsww_Component) != 0 )
         {
            WebComp_Wctagsww.setjustcreated();
            WebComp_Wctagsww.componentprepare(new Object[] {(string)"W0048",(string)""});
            WebComp_Wctagsww.componentbind(new Object[] {});
         }
      }

      protected void E120L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("layoutcontratoww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         edtLayoutContratoTag_Visible = 0;
         AssignProp("", false, edtLayoutContratoTag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLayoutContratoTag_Visible), 5, 0), true);
         divLayoutcontratotag_cell_Class = "Invisible";
         AssignProp("", false, divLayoutcontratotag_cell_Internalname, "Class", divLayoutcontratotag_cell_Class, true);
      }

      protected void ZM0L25( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z155LayoutContratoDescricao = T000L3_A155LayoutContratoDescricao[0];
               Z156LayoutContratoStatus = T000L3_A156LayoutContratoStatus[0];
               Z906LayoutContratoTipo = T000L3_A906LayoutContratoTipo[0];
               Z1000LayoutContratoTag = T000L3_A1000LayoutContratoTag[0];
            }
            else
            {
               Z155LayoutContratoDescricao = A155LayoutContratoDescricao;
               Z156LayoutContratoStatus = A156LayoutContratoStatus;
               Z906LayoutContratoTipo = A906LayoutContratoTipo;
               Z1000LayoutContratoTag = A1000LayoutContratoTag;
            }
         }
         if ( GX_JID == -12 )
         {
            Z154LayoutContratoId = A154LayoutContratoId;
            Z155LayoutContratoDescricao = A155LayoutContratoDescricao;
            Z156LayoutContratoStatus = A156LayoutContratoStatus;
            Z157LayoutContratoCorpo = A157LayoutContratoCorpo;
            Z906LayoutContratoTipo = A906LayoutContratoTipo;
            Z1000LayoutContratoTag = A1000LayoutContratoTag;
         }
      }

      protected void standaloneNotModal( )
      {
         edtLayoutContratoId_Enabled = 0;
         AssignProp("", false, edtLayoutContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLayoutContratoId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtLayoutContratoId_Enabled = 0;
         AssignProp("", false, edtLayoutContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLayoutContratoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7LayoutContratoId) )
         {
            A154LayoutContratoId = AV7LayoutContratoId;
            AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            cmbLayoutContratoStatus.Enabled = 0;
            AssignProp("", false, cmbLayoutContratoStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbLayoutContratoStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbLayoutContratoStatus.Enabled = 1;
            AssignProp("", false, cmbLayoutContratoStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbLayoutContratoStatus.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            cmbLayoutContratoStatus.Enabled = 0;
            AssignProp("", false, cmbLayoutContratoStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbLayoutContratoStatus.Enabled), 5, 0), true);
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
         if ( IsIns( )  && (false==A156LayoutContratoStatus) && ( Gx_BScreen == 0 ) )
         {
            A156LayoutContratoStatus = true;
            n156LayoutContratoStatus = false;
            AssignAttri("", false, "A156LayoutContratoStatus", A156LayoutContratoStatus);
         }
      }

      protected void Load0L25( )
      {
         /* Using cursor T000L4 */
         pr_default.execute(2, new Object[] {A154LayoutContratoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound25 = 1;
            A155LayoutContratoDescricao = T000L4_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = T000L4_n155LayoutContratoDescricao[0];
            AssignAttri("", false, "A155LayoutContratoDescricao", A155LayoutContratoDescricao);
            A156LayoutContratoStatus = T000L4_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = T000L4_n156LayoutContratoStatus[0];
            AssignAttri("", false, "A156LayoutContratoStatus", A156LayoutContratoStatus);
            A157LayoutContratoCorpo = T000L4_A157LayoutContratoCorpo[0];
            n157LayoutContratoCorpo = T000L4_n157LayoutContratoCorpo[0];
            A906LayoutContratoTipo = T000L4_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = T000L4_n906LayoutContratoTipo[0];
            AssignAttri("", false, "A906LayoutContratoTipo", A906LayoutContratoTipo);
            A1000LayoutContratoTag = T000L4_A1000LayoutContratoTag[0];
            n1000LayoutContratoTag = T000L4_n1000LayoutContratoTag[0];
            AssignAttri("", false, "A1000LayoutContratoTag", A1000LayoutContratoTag);
            ZM0L25( -12) ;
         }
         pr_default.close(2);
         OnLoadActions0L25( ) ;
      }

      protected void OnLoadActions0L25( )
      {
         edtLayoutContratoTag_Visible = ((StringUtil.StrCmp(A906LayoutContratoTipo, "A")==0) ? 1 : 0);
         AssignProp("", false, edtLayoutContratoTag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLayoutContratoTag_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") == 0 ) ) )
         {
            divLayoutcontratotag_cell_Class = "Invisible";
            AssignProp("", false, divLayoutcontratotag_cell_Internalname, "Class", divLayoutcontratotag_cell_Class, true);
         }
         else
         {
            if ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") == 0 )
            {
               divLayoutcontratotag_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
               AssignProp("", false, divLayoutcontratotag_cell_Internalname, "Class", divLayoutcontratotag_cell_Class, true);
            }
         }
         if ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") != 0 )
         {
            A1000LayoutContratoTag = "";
            n1000LayoutContratoTag = false;
            AssignAttri("", false, "A1000LayoutContratoTag", A1000LayoutContratoTag);
            n1000LayoutContratoTag = false;
            AssignAttri("", false, "A1000LayoutContratoTag", A1000LayoutContratoTag);
         }
      }

      protected void CheckExtendedTable0L25( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A155LayoutContratoDescricao)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "LAYOUTCONTRATODESCRICAO");
            AnyError = 1;
            GX_FocusControl = edtLayoutContratoDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A906LayoutContratoTipo, "C") == 0 ) || ( StringUtil.StrCmp(A906LayoutContratoTipo, "M") == 0 ) || ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A906LayoutContratoTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo fora do intervalo", "OutOfRange", 1, "LAYOUTCONTRATOTIPO");
            AnyError = 1;
            GX_FocusControl = cmbLayoutContratoTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         edtLayoutContratoTag_Visible = ((StringUtil.StrCmp(A906LayoutContratoTipo, "A")==0) ? 1 : 0);
         AssignProp("", false, edtLayoutContratoTag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLayoutContratoTag_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") == 0 ) ) )
         {
            divLayoutcontratotag_cell_Class = "Invisible";
            AssignProp("", false, divLayoutcontratotag_cell_Internalname, "Class", divLayoutcontratotag_cell_Class, true);
         }
         else
         {
            if ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") == 0 )
            {
               divLayoutcontratotag_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
               AssignProp("", false, divLayoutcontratotag_cell_Internalname, "Class", divLayoutcontratotag_cell_Class, true);
            }
         }
         if ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") != 0 )
         {
            A1000LayoutContratoTag = "";
            n1000LayoutContratoTag = false;
            AssignAttri("", false, "A1000LayoutContratoTag", A1000LayoutContratoTag);
            n1000LayoutContratoTag = false;
            AssignAttri("", false, "A1000LayoutContratoTag", A1000LayoutContratoTag);
         }
         if ( ( ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( A1000LayoutContratoTag)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Layout Contrato Tag", "", "", "", "", "", "", "", ""), 1, "LAYOUTCONTRATOTIPO");
            AnyError = 1;
            GX_FocusControl = cmbLayoutContratoTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0L25( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L25( )
      {
         /* Using cursor T000L5 */
         pr_default.execute(3, new Object[] {A154LayoutContratoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000L3 */
         pr_default.execute(1, new Object[] {A154LayoutContratoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L25( 12) ;
            RcdFound25 = 1;
            A154LayoutContratoId = T000L3_A154LayoutContratoId[0];
            AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
            A155LayoutContratoDescricao = T000L3_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = T000L3_n155LayoutContratoDescricao[0];
            AssignAttri("", false, "A155LayoutContratoDescricao", A155LayoutContratoDescricao);
            A156LayoutContratoStatus = T000L3_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = T000L3_n156LayoutContratoStatus[0];
            AssignAttri("", false, "A156LayoutContratoStatus", A156LayoutContratoStatus);
            A157LayoutContratoCorpo = T000L3_A157LayoutContratoCorpo[0];
            n157LayoutContratoCorpo = T000L3_n157LayoutContratoCorpo[0];
            A906LayoutContratoTipo = T000L3_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = T000L3_n906LayoutContratoTipo[0];
            AssignAttri("", false, "A906LayoutContratoTipo", A906LayoutContratoTipo);
            A1000LayoutContratoTag = T000L3_A1000LayoutContratoTag[0];
            n1000LayoutContratoTag = T000L3_n1000LayoutContratoTag[0];
            AssignAttri("", false, "A1000LayoutContratoTag", A1000LayoutContratoTag);
            Z154LayoutContratoId = A154LayoutContratoId;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0L25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0L25( ) ;
            }
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0L25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L25( ) ;
         if ( RcdFound25 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound25 = 0;
         /* Using cursor T000L6 */
         pr_default.execute(4, new Object[] {A154LayoutContratoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000L6_A154LayoutContratoId[0] < A154LayoutContratoId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000L6_A154LayoutContratoId[0] > A154LayoutContratoId ) ) )
            {
               A154LayoutContratoId = T000L6_A154LayoutContratoId[0];
               AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
               RcdFound25 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound25 = 0;
         /* Using cursor T000L7 */
         pr_default.execute(5, new Object[] {A154LayoutContratoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000L7_A154LayoutContratoId[0] > A154LayoutContratoId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000L7_A154LayoutContratoId[0] < A154LayoutContratoId ) ) )
            {
               A154LayoutContratoId = T000L7_A154LayoutContratoId[0];
               AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
               RcdFound25 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0L25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLayoutContratoDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0L25( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( A154LayoutContratoId != Z154LayoutContratoId )
               {
                  A154LayoutContratoId = Z154LayoutContratoId;
                  AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LAYOUTCONTRATOID");
                  AnyError = 1;
                  GX_FocusControl = edtLayoutContratoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLayoutContratoDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0L25( ) ;
                  GX_FocusControl = edtLayoutContratoDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A154LayoutContratoId != Z154LayoutContratoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtLayoutContratoDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0L25( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LAYOUTCONTRATOID");
                     AnyError = 1;
                     GX_FocusControl = edtLayoutContratoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtLayoutContratoDescricao_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0L25( ) ;
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
         if ( A154LayoutContratoId != Z154LayoutContratoId )
         {
            A154LayoutContratoId = Z154LayoutContratoId;
            AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LAYOUTCONTRATOID");
            AnyError = 1;
            GX_FocusControl = edtLayoutContratoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLayoutContratoDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0L25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000L2 */
            pr_default.execute(0, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LayoutContrato"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z155LayoutContratoDescricao, T000L2_A155LayoutContratoDescricao[0]) != 0 ) || ( Z156LayoutContratoStatus != T000L2_A156LayoutContratoStatus[0] ) || ( StringUtil.StrCmp(Z906LayoutContratoTipo, T000L2_A906LayoutContratoTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z1000LayoutContratoTag, T000L2_A1000LayoutContratoTag[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z155LayoutContratoDescricao, T000L2_A155LayoutContratoDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("layoutcontrato:[seudo value changed for attri]"+"LayoutContratoDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z155LayoutContratoDescricao);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A155LayoutContratoDescricao[0]);
               }
               if ( Z156LayoutContratoStatus != T000L2_A156LayoutContratoStatus[0] )
               {
                  GXUtil.WriteLog("layoutcontrato:[seudo value changed for attri]"+"LayoutContratoStatus");
                  GXUtil.WriteLogRaw("Old: ",Z156LayoutContratoStatus);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A156LayoutContratoStatus[0]);
               }
               if ( StringUtil.StrCmp(Z906LayoutContratoTipo, T000L2_A906LayoutContratoTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("layoutcontrato:[seudo value changed for attri]"+"LayoutContratoTipo");
                  GXUtil.WriteLogRaw("Old: ",Z906LayoutContratoTipo);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A906LayoutContratoTipo[0]);
               }
               if ( StringUtil.StrCmp(Z1000LayoutContratoTag, T000L2_A1000LayoutContratoTag[0]) != 0 )
               {
                  GXUtil.WriteLog("layoutcontrato:[seudo value changed for attri]"+"LayoutContratoTag");
                  GXUtil.WriteLogRaw("Old: ",Z1000LayoutContratoTag);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A1000LayoutContratoTag[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LayoutContrato"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L25( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L25( 0) ;
            CheckOptimisticConcurrency0L25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L8 */
                     pr_default.execute(6, new Object[] {n155LayoutContratoDescricao, A155LayoutContratoDescricao, n156LayoutContratoStatus, A156LayoutContratoStatus, n157LayoutContratoCorpo, A157LayoutContratoCorpo, n906LayoutContratoTipo, A906LayoutContratoTipo, n1000LayoutContratoTag, A1000LayoutContratoTag});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000L9 */
                     pr_default.execute(7);
                     A154LayoutContratoId = T000L9_A154LayoutContratoId[0];
                     AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("LayoutContrato");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0L0( ) ;
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
               Load0L25( ) ;
            }
            EndLevel0L25( ) ;
         }
         CloseExtendedTableCursors0L25( ) ;
      }

      protected void Update0L25( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L10 */
                     pr_default.execute(8, new Object[] {n155LayoutContratoDescricao, A155LayoutContratoDescricao, n156LayoutContratoStatus, A156LayoutContratoStatus, n157LayoutContratoCorpo, A157LayoutContratoCorpo, n906LayoutContratoTipo, A906LayoutContratoTipo, n1000LayoutContratoTag, A1000LayoutContratoTag, A154LayoutContratoId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("LayoutContrato");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LayoutContrato"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L25( ) ;
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
            EndLevel0L25( ) ;
         }
         CloseExtendedTableCursors0L25( ) ;
      }

      protected void DeferredUpdate0L25( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L25( ) ;
            AfterConfirm0L25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000L11 */
                  pr_default.execute(9, new Object[] {A154LayoutContratoId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("LayoutContrato");
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
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0L25( ) ;
         Gx_mode = sMode25;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0L25( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            edtLayoutContratoTag_Visible = ((StringUtil.StrCmp(A906LayoutContratoTipo, "A")==0) ? 1 : 0);
            AssignProp("", false, edtLayoutContratoTag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLayoutContratoTag_Visible), 5, 0), true);
            if ( ! ( ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") == 0 ) ) )
            {
               divLayoutcontratotag_cell_Class = "Invisible";
               AssignProp("", false, divLayoutcontratotag_cell_Internalname, "Class", divLayoutcontratotag_cell_Class, true);
            }
            else
            {
               if ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") == 0 )
               {
                  divLayoutcontratotag_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
                  AssignProp("", false, divLayoutcontratotag_cell_Internalname, "Class", divLayoutcontratotag_cell_Class, true);
               }
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000L12 */
            pr_default.execute(10, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotificacaoAgendada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000L13 */
            pr_default.execute(11, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuracoes"+" ("+"Sb Config Layout Contrato Compra Titulo"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000L14 */
            pr_default.execute(12, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuracoes"+" ("+"Sb Layout Promissoria Paciente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000L15 */
            pr_default.execute(13, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuracoes"+" ("+"Sb Layout Promissoria Clinica Taxa"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000L16 */
            pr_default.execute(14, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuracoes"+" ("+"Sb Layout Promissoria Clinica Emprestimo"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000L17 */
            pr_default.execute(15, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuracoes"+" ("+"Sb Layout Proposta Config"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void EndLevel0L25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("layoutcontrato",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("layoutcontrato",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0L25( )
      {
         /* Scan By routine */
         /* Using cursor T000L18 */
         pr_default.execute(16);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound25 = 1;
            A154LayoutContratoId = T000L18_A154LayoutContratoId[0];
            AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0L25( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound25 = 1;
            A154LayoutContratoId = T000L18_A154LayoutContratoId[0];
            AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
         }
      }

      protected void ScanEnd0L25( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0L25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L25( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L25( )
      {
         edtLayoutContratoDescricao_Enabled = 0;
         AssignProp("", false, edtLayoutContratoDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLayoutContratoDescricao_Enabled), 5, 0), true);
         cmbLayoutContratoStatus.Enabled = 0;
         AssignProp("", false, cmbLayoutContratoStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbLayoutContratoStatus.Enabled), 5, 0), true);
         cmbLayoutContratoTipo.Enabled = 0;
         AssignProp("", false, cmbLayoutContratoTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbLayoutContratoTipo.Enabled), 5, 0), true);
         edtLayoutContratoTag_Enabled = 0;
         AssignProp("", false, edtLayoutContratoTag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLayoutContratoTag_Enabled), 5, 0), true);
         edtLayoutContratoId_Enabled = 0;
         AssignProp("", false, edtLayoutContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLayoutContratoId_Enabled), 5, 0), true);
         Layoutcontratocorpo_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Layoutcontratocorpo_Internalname, "Enabled", StringUtil.BoolToStr( Layoutcontratocorpo_Enabled), true);
      }

      protected void send_integrity_lvl_hashes0L25( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0L0( )
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
         GXEncryptionTmp = "layoutcontrato"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7LayoutContratoId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("layoutcontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"LayoutContrato");
         forbiddenHiddens.Add("LayoutContratoId", context.localUtil.Format( (decimal)(A154LayoutContratoId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("layoutcontrato:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         forbiddenHiddens2 = new GXProperties();
         if ( IsIns( )  )
         {
            forbiddenHiddens2.Add("LayoutContratoStatus", StringUtil.BoolToStr( A156LayoutContratoStatus));
         }
         GxWebStd.gx_hidden_field( context, "hsh2", GetEncryptedHash( forbiddenHiddens2.ToString(), GXKey));
         GXUtil.WriteLogInfo("layoutcontrato:[ SendCondSecurityCheck value for]"+forbiddenHiddens2.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z154LayoutContratoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z154LayoutContratoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z155LayoutContratoDescricao", Z155LayoutContratoDescricao);
         GxWebStd.gx_boolean_hidden_field( context, "Z156LayoutContratoStatus", Z156LayoutContratoStatus);
         GxWebStd.gx_hidden_field( context, "Z906LayoutContratoTipo", Z906LayoutContratoTipo);
         GxWebStd.gx_hidden_field( context, "Z1000LayoutContratoTag", Z1000LayoutContratoTag);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vLAYOUTCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7LayoutContratoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLAYOUTCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7LayoutContratoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATOCORPO", A157LayoutContratoCorpo);
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATOCORPO_Objectcall", StringUtil.RTrim( Layoutcontratocorpo_Objectcall));
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATOCORPO_Enabled", StringUtil.BoolToStr( Layoutcontratocorpo_Enabled));
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATOCORPO_Captionclass", StringUtil.RTrim( Layoutcontratocorpo_Captionclass));
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATOCORPO_Captionstyle", StringUtil.RTrim( Layoutcontratocorpo_Captionstyle));
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATOCORPO_Captionposition", StringUtil.RTrim( Layoutcontratocorpo_Captionposition));
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
         if ( ! ( WebComp_Wctagsww == null ) )
         {
            WebComp_Wctagsww.componentjscripts();
         }
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wctagsww_Component) != 0 )
               {
                  WebComp_Wctagsww.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wctagsww_Component) != 0 )
               {
                  WebComp_Wctagsww.componentstart();
               }
            }
         }
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
         GXEncryptionTmp = "layoutcontrato"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7LayoutContratoId,4,0));
         return formatLink("layoutcontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "LayoutContrato" ;
      }

      public override string GetPgmdesc( )
      {
         return " Layout de contratos" ;
      }

      protected void InitializeNonKey0L25( )
      {
         A155LayoutContratoDescricao = "";
         n155LayoutContratoDescricao = false;
         AssignAttri("", false, "A155LayoutContratoDescricao", A155LayoutContratoDescricao);
         n155LayoutContratoDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A155LayoutContratoDescricao)) ? true : false);
         A157LayoutContratoCorpo = "";
         n157LayoutContratoCorpo = false;
         AssignAttri("", false, "A157LayoutContratoCorpo", A157LayoutContratoCorpo);
         A906LayoutContratoTipo = "";
         n906LayoutContratoTipo = false;
         AssignAttri("", false, "A906LayoutContratoTipo", A906LayoutContratoTipo);
         n906LayoutContratoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A906LayoutContratoTipo)) ? true : false);
         A1000LayoutContratoTag = "";
         n1000LayoutContratoTag = false;
         AssignAttri("", false, "A1000LayoutContratoTag", A1000LayoutContratoTag);
         n1000LayoutContratoTag = (String.IsNullOrEmpty(StringUtil.RTrim( A1000LayoutContratoTag)) ? true : false);
         A156LayoutContratoStatus = true;
         n156LayoutContratoStatus = false;
         AssignAttri("", false, "A156LayoutContratoStatus", A156LayoutContratoStatus);
         Z155LayoutContratoDescricao = "";
         Z156LayoutContratoStatus = false;
         Z906LayoutContratoTipo = "";
         Z1000LayoutContratoTag = "";
      }

      protected void InitAll0L25( )
      {
         A154LayoutContratoId = 0;
         AssignAttri("", false, "A154LayoutContratoId", StringUtil.LTrimStr( (decimal)(A154LayoutContratoId), 4, 0));
         InitializeNonKey0L25( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A156LayoutContratoStatus = i156LayoutContratoStatus;
         n156LayoutContratoStatus = false;
         AssignAttri("", false, "A156LayoutContratoStatus", A156LayoutContratoStatus);
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wctagsww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wctagsww_Component) != 0 )
            {
               WebComp_Wctagsww.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019131332", true, true);
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
         context.AddJavascriptSource("layoutcontrato.js", "?202561019131332", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtLayoutContratoDescricao_Internalname = "LAYOUTCONTRATODESCRICAO";
         cmbLayoutContratoStatus_Internalname = "LAYOUTCONTRATOSTATUS";
         cmbLayoutContratoTipo_Internalname = "LAYOUTCONTRATOTIPO";
         edtLayoutContratoTag_Internalname = "LAYOUTCONTRATOTAG";
         divLayoutcontratotag_cell_Internalname = "LAYOUTCONTRATOTAG_CELL";
         Layoutcontratocorpo_Internalname = "LAYOUTCONTRATOCORPO";
         divTabletags_Internalname = "TABLETAGS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtLayoutContratoId_Internalname = "LAYOUTCONTRATOID";
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
         Form.Caption = " Layout de contratos";
         edtLayoutContratoId_Jsonclick = "";
         edtLayoutContratoId_Enabled = 0;
         edtLayoutContratoId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         Layoutcontratocorpo_Captionposition = "Left";
         Layoutcontratocorpo_Captionstyle = "";
         Layoutcontratocorpo_Captionclass = " AttributeLabel";
         Layoutcontratocorpo_Enabled = Convert.ToBoolean( 1);
         edtLayoutContratoTag_Jsonclick = "";
         edtLayoutContratoTag_Enabled = 1;
         edtLayoutContratoTag_Visible = 1;
         divLayoutcontratotag_cell_Class = "col-xs-12";
         cmbLayoutContratoTipo_Jsonclick = "";
         cmbLayoutContratoTipo.Enabled = 1;
         cmbLayoutContratoStatus_Jsonclick = "";
         cmbLayoutContratoStatus.Enabled = 1;
         edtLayoutContratoDescricao_Jsonclick = "";
         edtLayoutContratoDescricao_Enabled = 1;
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
         cmbLayoutContratoStatus.Name = "LAYOUTCONTRATOSTATUS";
         cmbLayoutContratoStatus.WebTags = "";
         cmbLayoutContratoStatus.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbLayoutContratoStatus.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbLayoutContratoStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A156LayoutContratoStatus) )
            {
               A156LayoutContratoStatus = true;
               n156LayoutContratoStatus = false;
               AssignAttri("", false, "A156LayoutContratoStatus", A156LayoutContratoStatus);
            }
         }
         cmbLayoutContratoTipo.Name = "LAYOUTCONTRATOTIPO";
         cmbLayoutContratoTipo.WebTags = "";
         cmbLayoutContratoTipo.addItem("C", "Contrato", 0);
         cmbLayoutContratoTipo.addItem("M", "Mensagem", 0);
         cmbLayoutContratoTipo.addItem("A", "Acoplado", 0);
         if ( cmbLayoutContratoTipo.ItemCount > 0 )
         {
            A906LayoutContratoTipo = cmbLayoutContratoTipo.getValidValue(A906LayoutContratoTipo);
            n906LayoutContratoTipo = false;
            AssignAttri("", false, "A906LayoutContratoTipo", A906LayoutContratoTipo);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7LayoutContratoId","fld":"vLAYOUTCONTRATOID","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7LayoutContratoId","fld":"vLAYOUTCONTRATOID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A154LayoutContratoId","fld":"LAYOUTCONTRATOID","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120L2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_LAYOUTCONTRATODESCRICAO","""{"handler":"Valid_Layoutcontratodescricao","iparms":[]}""");
         setEventMetadata("VALID_LAYOUTCONTRATOTIPO","""{"handler":"Valid_Layoutcontratotipo","iparms":[]}""");
         setEventMetadata("VALID_LAYOUTCONTRATOTAG","""{"handler":"Valid_Layoutcontratotag","iparms":[]}""");
         setEventMetadata("VALID_LAYOUTCONTRATOID","""{"handler":"Valid_Layoutcontratoid","iparms":[]}""");
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
         Z155LayoutContratoDescricao = "";
         Z906LayoutContratoTipo = "";
         Z1000LayoutContratoTag = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A906LayoutContratoTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A155LayoutContratoDescricao = "";
         A1000LayoutContratoTag = "";
         ucLayoutcontratocorpo = new GXUserControl();
         LayoutContratoCorpo = "";
         WebComp_Wctagsww_Component = "";
         OldWctagsww = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A157LayoutContratoCorpo = "";
         Layoutcontratocorpo_Objectcall = "";
         Layoutcontratocorpo_Class = "";
         Layoutcontratocorpo_Width = "";
         Layoutcontratocorpo_Height = "";
         Layoutcontratocorpo_Skin = "";
         Layoutcontratocorpo_Toolbar = "";
         Layoutcontratocorpo_Customtoolbar = "";
         Layoutcontratocorpo_Customconfiguration = "";
         Layoutcontratocorpo_Buttonpressedid = "";
         Layoutcontratocorpo_Captionvalue = "";
         Layoutcontratocorpo_Coltitle = "";
         Layoutcontratocorpo_Coltitlefont = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         forbiddenHiddens2 = new GXProperties();
         hsh2 = "";
         sMode25 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z157LayoutContratoCorpo = "";
         T000L4_A154LayoutContratoId = new short[1] ;
         T000L4_A155LayoutContratoDescricao = new string[] {""} ;
         T000L4_n155LayoutContratoDescricao = new bool[] {false} ;
         T000L4_A156LayoutContratoStatus = new bool[] {false} ;
         T000L4_n156LayoutContratoStatus = new bool[] {false} ;
         T000L4_A157LayoutContratoCorpo = new string[] {""} ;
         T000L4_n157LayoutContratoCorpo = new bool[] {false} ;
         T000L4_A906LayoutContratoTipo = new string[] {""} ;
         T000L4_n906LayoutContratoTipo = new bool[] {false} ;
         T000L4_A1000LayoutContratoTag = new string[] {""} ;
         T000L4_n1000LayoutContratoTag = new bool[] {false} ;
         T000L5_A154LayoutContratoId = new short[1] ;
         T000L3_A154LayoutContratoId = new short[1] ;
         T000L3_A155LayoutContratoDescricao = new string[] {""} ;
         T000L3_n155LayoutContratoDescricao = new bool[] {false} ;
         T000L3_A156LayoutContratoStatus = new bool[] {false} ;
         T000L3_n156LayoutContratoStatus = new bool[] {false} ;
         T000L3_A157LayoutContratoCorpo = new string[] {""} ;
         T000L3_n157LayoutContratoCorpo = new bool[] {false} ;
         T000L3_A906LayoutContratoTipo = new string[] {""} ;
         T000L3_n906LayoutContratoTipo = new bool[] {false} ;
         T000L3_A1000LayoutContratoTag = new string[] {""} ;
         T000L3_n1000LayoutContratoTag = new bool[] {false} ;
         T000L6_A154LayoutContratoId = new short[1] ;
         T000L7_A154LayoutContratoId = new short[1] ;
         T000L2_A154LayoutContratoId = new short[1] ;
         T000L2_A155LayoutContratoDescricao = new string[] {""} ;
         T000L2_n155LayoutContratoDescricao = new bool[] {false} ;
         T000L2_A156LayoutContratoStatus = new bool[] {false} ;
         T000L2_n156LayoutContratoStatus = new bool[] {false} ;
         T000L2_A157LayoutContratoCorpo = new string[] {""} ;
         T000L2_n157LayoutContratoCorpo = new bool[] {false} ;
         T000L2_A906LayoutContratoTipo = new string[] {""} ;
         T000L2_n906LayoutContratoTipo = new bool[] {false} ;
         T000L2_A1000LayoutContratoTag = new string[] {""} ;
         T000L2_n1000LayoutContratoTag = new bool[] {false} ;
         T000L9_A154LayoutContratoId = new short[1] ;
         T000L12_A898NotificacaoAgendadaId = new int[1] ;
         T000L13_A299ConfiguracoesId = new int[1] ;
         T000L14_A299ConfiguracoesId = new int[1] ;
         T000L15_A299ConfiguracoesId = new int[1] ;
         T000L16_A299ConfiguracoesId = new int[1] ;
         T000L17_A299ConfiguracoesId = new int[1] ;
         T000L18_A154LayoutContratoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.layoutcontrato__default(),
            new Object[][] {
                new Object[] {
               T000L2_A154LayoutContratoId, T000L2_A155LayoutContratoDescricao, T000L2_n155LayoutContratoDescricao, T000L2_A156LayoutContratoStatus, T000L2_n156LayoutContratoStatus, T000L2_A157LayoutContratoCorpo, T000L2_n157LayoutContratoCorpo, T000L2_A906LayoutContratoTipo, T000L2_n906LayoutContratoTipo, T000L2_A1000LayoutContratoTag,
               T000L2_n1000LayoutContratoTag
               }
               , new Object[] {
               T000L3_A154LayoutContratoId, T000L3_A155LayoutContratoDescricao, T000L3_n155LayoutContratoDescricao, T000L3_A156LayoutContratoStatus, T000L3_n156LayoutContratoStatus, T000L3_A157LayoutContratoCorpo, T000L3_n157LayoutContratoCorpo, T000L3_A906LayoutContratoTipo, T000L3_n906LayoutContratoTipo, T000L3_A1000LayoutContratoTag,
               T000L3_n1000LayoutContratoTag
               }
               , new Object[] {
               T000L4_A154LayoutContratoId, T000L4_A155LayoutContratoDescricao, T000L4_n155LayoutContratoDescricao, T000L4_A156LayoutContratoStatus, T000L4_n156LayoutContratoStatus, T000L4_A157LayoutContratoCorpo, T000L4_n157LayoutContratoCorpo, T000L4_A906LayoutContratoTipo, T000L4_n906LayoutContratoTipo, T000L4_A1000LayoutContratoTag,
               T000L4_n1000LayoutContratoTag
               }
               , new Object[] {
               T000L5_A154LayoutContratoId
               }
               , new Object[] {
               T000L6_A154LayoutContratoId
               }
               , new Object[] {
               T000L7_A154LayoutContratoId
               }
               , new Object[] {
               }
               , new Object[] {
               T000L9_A154LayoutContratoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000L12_A898NotificacaoAgendadaId
               }
               , new Object[] {
               T000L13_A299ConfiguracoesId
               }
               , new Object[] {
               T000L14_A299ConfiguracoesId
               }
               , new Object[] {
               T000L15_A299ConfiguracoesId
               }
               , new Object[] {
               T000L16_A299ConfiguracoesId
               }
               , new Object[] {
               T000L17_A299ConfiguracoesId
               }
               , new Object[] {
               T000L18_A154LayoutContratoId
               }
            }
         );
         WebComp_Wctagsww = new GeneXus.Http.GXNullWebComponent();
         Z156LayoutContratoStatus = true;
         n156LayoutContratoStatus = false;
         A156LayoutContratoStatus = true;
         n156LayoutContratoStatus = false;
         i156LayoutContratoStatus = true;
         n156LayoutContratoStatus = false;
      }

      private short wcpOAV7LayoutContratoId ;
      private short Z154LayoutContratoId ;
      private short GxWebError ;
      private short AV7LayoutContratoId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A154LayoutContratoId ;
      private short Gx_BScreen ;
      private short RcdFound25 ;
      private short nCmpId ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtLayoutContratoDescricao_Enabled ;
      private int edtLayoutContratoTag_Visible ;
      private int edtLayoutContratoTag_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtLayoutContratoId_Enabled ;
      private int edtLayoutContratoId_Visible ;
      private int Layoutcontratocorpo_Color ;
      private int Layoutcontratocorpo_Coltitlecolor ;
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
      private string edtLayoutContratoDescricao_Internalname ;
      private string cmbLayoutContratoStatus_Internalname ;
      private string cmbLayoutContratoTipo_Internalname ;
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
      private string edtLayoutContratoDescricao_Jsonclick ;
      private string cmbLayoutContratoStatus_Jsonclick ;
      private string cmbLayoutContratoTipo_Jsonclick ;
      private string divLayoutcontratotag_cell_Internalname ;
      private string divLayoutcontratotag_cell_Class ;
      private string edtLayoutContratoTag_Internalname ;
      private string edtLayoutContratoTag_Jsonclick ;
      private string Layoutcontratocorpo_Internalname ;
      private string Layoutcontratocorpo_Captionclass ;
      private string Layoutcontratocorpo_Captionstyle ;
      private string Layoutcontratocorpo_Captionposition ;
      private string divTabletags_Internalname ;
      private string WebComp_Wctagsww_Component ;
      private string OldWctagsww ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtLayoutContratoId_Internalname ;
      private string edtLayoutContratoId_Jsonclick ;
      private string Layoutcontratocorpo_Objectcall ;
      private string Layoutcontratocorpo_Class ;
      private string Layoutcontratocorpo_Width ;
      private string Layoutcontratocorpo_Height ;
      private string Layoutcontratocorpo_Skin ;
      private string Layoutcontratocorpo_Toolbar ;
      private string Layoutcontratocorpo_Customtoolbar ;
      private string Layoutcontratocorpo_Customconfiguration ;
      private string Layoutcontratocorpo_Buttonpressedid ;
      private string Layoutcontratocorpo_Captionvalue ;
      private string Layoutcontratocorpo_Coltitle ;
      private string Layoutcontratocorpo_Coltitlefont ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string hsh2 ;
      private string sMode25 ;
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
      private bool Z156LayoutContratoStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A156LayoutContratoStatus ;
      private bool n156LayoutContratoStatus ;
      private bool n906LayoutContratoTipo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n155LayoutContratoDescricao ;
      private bool n1000LayoutContratoTag ;
      private bool n157LayoutContratoCorpo ;
      private bool Layoutcontratocorpo_Enabled ;
      private bool Layoutcontratocorpo_Toolbarcancollapse ;
      private bool Layoutcontratocorpo_Toolbarexpanded ;
      private bool Layoutcontratocorpo_Isabstractlayoutcontrol ;
      private bool Layoutcontratocorpo_Usercontroliscolumn ;
      private bool Layoutcontratocorpo_Visible ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool bDynCreated_Wctagsww ;
      private bool i156LayoutContratoStatus ;
      private string LayoutContratoCorpo ;
      private string A157LayoutContratoCorpo ;
      private string Z157LayoutContratoCorpo ;
      private string Z155LayoutContratoDescricao ;
      private string Z906LayoutContratoTipo ;
      private string Z1000LayoutContratoTag ;
      private string A906LayoutContratoTipo ;
      private string A155LayoutContratoDescricao ;
      private string A1000LayoutContratoTag ;
      private IGxSession AV12WebSession ;
      private GXWebComponent WebComp_Wctagsww ;
      private GXProperties forbiddenHiddens ;
      private GXProperties forbiddenHiddens2 ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucLayoutcontratocorpo ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbLayoutContratoStatus ;
      private GXCombobox cmbLayoutContratoTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T000L4_A154LayoutContratoId ;
      private string[] T000L4_A155LayoutContratoDescricao ;
      private bool[] T000L4_n155LayoutContratoDescricao ;
      private bool[] T000L4_A156LayoutContratoStatus ;
      private bool[] T000L4_n156LayoutContratoStatus ;
      private string[] T000L4_A157LayoutContratoCorpo ;
      private bool[] T000L4_n157LayoutContratoCorpo ;
      private string[] T000L4_A906LayoutContratoTipo ;
      private bool[] T000L4_n906LayoutContratoTipo ;
      private string[] T000L4_A1000LayoutContratoTag ;
      private bool[] T000L4_n1000LayoutContratoTag ;
      private short[] T000L5_A154LayoutContratoId ;
      private short[] T000L3_A154LayoutContratoId ;
      private string[] T000L3_A155LayoutContratoDescricao ;
      private bool[] T000L3_n155LayoutContratoDescricao ;
      private bool[] T000L3_A156LayoutContratoStatus ;
      private bool[] T000L3_n156LayoutContratoStatus ;
      private string[] T000L3_A157LayoutContratoCorpo ;
      private bool[] T000L3_n157LayoutContratoCorpo ;
      private string[] T000L3_A906LayoutContratoTipo ;
      private bool[] T000L3_n906LayoutContratoTipo ;
      private string[] T000L3_A1000LayoutContratoTag ;
      private bool[] T000L3_n1000LayoutContratoTag ;
      private short[] T000L6_A154LayoutContratoId ;
      private short[] T000L7_A154LayoutContratoId ;
      private short[] T000L2_A154LayoutContratoId ;
      private string[] T000L2_A155LayoutContratoDescricao ;
      private bool[] T000L2_n155LayoutContratoDescricao ;
      private bool[] T000L2_A156LayoutContratoStatus ;
      private bool[] T000L2_n156LayoutContratoStatus ;
      private string[] T000L2_A157LayoutContratoCorpo ;
      private bool[] T000L2_n157LayoutContratoCorpo ;
      private string[] T000L2_A906LayoutContratoTipo ;
      private bool[] T000L2_n906LayoutContratoTipo ;
      private string[] T000L2_A1000LayoutContratoTag ;
      private bool[] T000L2_n1000LayoutContratoTag ;
      private short[] T000L9_A154LayoutContratoId ;
      private int[] T000L12_A898NotificacaoAgendadaId ;
      private int[] T000L13_A299ConfiguracoesId ;
      private int[] T000L14_A299ConfiguracoesId ;
      private int[] T000L15_A299ConfiguracoesId ;
      private int[] T000L16_A299ConfiguracoesId ;
      private int[] T000L17_A299ConfiguracoesId ;
      private short[] T000L18_A154LayoutContratoId ;
   }

   public class layoutcontrato__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000L2;
          prmT000L2 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L3;
          prmT000L3 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L4;
          prmT000L4 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L5;
          prmT000L5 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L6;
          prmT000L6 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L7;
          prmT000L7 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L8;
          prmT000L8 = new Object[] {
          new ParDef("LayoutContratoDescricao",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("LayoutContratoStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("LayoutContratoCorpo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("LayoutContratoTipo",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("LayoutContratoTag",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000L9;
          prmT000L9 = new Object[] {
          };
          Object[] prmT000L10;
          prmT000L10 = new Object[] {
          new ParDef("LayoutContratoDescricao",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("LayoutContratoStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("LayoutContratoCorpo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("LayoutContratoTipo",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("LayoutContratoTag",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L11;
          prmT000L11 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L12;
          prmT000L12 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L13;
          prmT000L13 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L14;
          prmT000L14 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L15;
          prmT000L15 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L16;
          prmT000L16 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L17;
          prmT000L17 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmT000L18;
          prmT000L18 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000L2", "SELECT LayoutContratoId, LayoutContratoDescricao, LayoutContratoStatus, LayoutContratoCorpo, LayoutContratoTipo, LayoutContratoTag FROM LayoutContrato WHERE LayoutContratoId = :LayoutContratoId  FOR UPDATE OF LayoutContrato NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000L2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L3", "SELECT LayoutContratoId, LayoutContratoDescricao, LayoutContratoStatus, LayoutContratoCorpo, LayoutContratoTipo, LayoutContratoTag FROM LayoutContrato WHERE LayoutContratoId = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L4", "SELECT TM1.LayoutContratoId, TM1.LayoutContratoDescricao, TM1.LayoutContratoStatus, TM1.LayoutContratoCorpo, TM1.LayoutContratoTipo, TM1.LayoutContratoTag FROM LayoutContrato TM1 WHERE TM1.LayoutContratoId = :LayoutContratoId ORDER BY TM1.LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L5", "SELECT LayoutContratoId FROM LayoutContrato WHERE LayoutContratoId = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L6", "SELECT LayoutContratoId FROM LayoutContrato WHERE ( LayoutContratoId > :LayoutContratoId) ORDER BY LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000L7", "SELECT LayoutContratoId FROM LayoutContrato WHERE ( LayoutContratoId < :LayoutContratoId) ORDER BY LayoutContratoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000L8", "SAVEPOINT gxupdate;INSERT INTO LayoutContrato(LayoutContratoDescricao, LayoutContratoStatus, LayoutContratoCorpo, LayoutContratoTipo, LayoutContratoTag) VALUES(:LayoutContratoDescricao, :LayoutContratoStatus, :LayoutContratoCorpo, :LayoutContratoTipo, :LayoutContratoTag);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000L8)
             ,new CursorDef("T000L9", "SELECT currval('LayoutContratoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L10", "SAVEPOINT gxupdate;UPDATE LayoutContrato SET LayoutContratoDescricao=:LayoutContratoDescricao, LayoutContratoStatus=:LayoutContratoStatus, LayoutContratoCorpo=:LayoutContratoCorpo, LayoutContratoTipo=:LayoutContratoTipo, LayoutContratoTag=:LayoutContratoTag  WHERE LayoutContratoId = :LayoutContratoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000L10)
             ,new CursorDef("T000L11", "SAVEPOINT gxupdate;DELETE FROM LayoutContrato  WHERE LayoutContratoId = :LayoutContratoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000L11)
             ,new CursorDef("T000L12", "SELECT NotificacaoAgendadaId FROM NotificacaoAgendada WHERE NotificacaoAgendadaLayoutId = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000L13", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfigLayoutContratoCompraTitulo = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000L14", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfigLayoutPromissoriaPaciente = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000L15", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfigLayoutPromissoriaClinicaTaxa = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000L16", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfigLayoutPromissoriaClinicaEmprestimo = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L16,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000L17", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfiguracoesLayoutProposta = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L17,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000L18", "SELECT LayoutContratoId FROM LayoutContrato ORDER BY LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L18,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
