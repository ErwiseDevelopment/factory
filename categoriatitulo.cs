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
   public class categoriatitulo : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "categoriatitulo")), "categoriatitulo") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "categoriatitulo")))) ;
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
                  AV7CategoriaTituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "CategoriaTituloId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7CategoriaTituloId", StringUtil.LTrimStr( (decimal)(AV7CategoriaTituloId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCATEGORIATITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CategoriaTituloId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Categoria Titulo", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCategoriaTituloNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public categoriatitulo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public categoriatitulo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_CategoriaTituloId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CategoriaTituloId = aP1_CategoriaTituloId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCategoriaStatus = new GXCombobox();
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
         if ( cmbCategoriaStatus.ItemCount > 0 )
         {
            A431CategoriaStatus = StringUtil.StrToBool( cmbCategoriaStatus.getValidValue(StringUtil.BoolToStr( A431CategoriaStatus)));
            n431CategoriaStatus = false;
            AssignAttri("", false, "A431CategoriaStatus", A431CategoriaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCategoriaStatus.CurrentValue = StringUtil.BoolToStr( A431CategoriaStatus);
            AssignProp("", false, cmbCategoriaStatus_Internalname, "Values", cmbCategoriaStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCategoriaTituloNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoriaTituloNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoriaTituloNome_Internalname, A427CategoriaTituloNome, StringUtil.RTrim( context.localUtil.Format( A427CategoriaTituloNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaTituloNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCategoriaTituloNome_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CategoriaTitulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCategoriaTituloDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoriaTituloDescricao_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoriaTituloDescricao_Internalname, A428CategoriaTituloDescricao, StringUtil.RTrim( context.localUtil.Format( A428CategoriaTituloDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaTituloDescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCategoriaTituloDescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CategoriaTitulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbCategoriaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCategoriaStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCategoriaStatus, cmbCategoriaStatus_Internalname, StringUtil.BoolToStr( A431CategoriaStatus), 1, cmbCategoriaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbCategoriaStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_CategoriaTitulo.htm");
         cmbCategoriaStatus.CurrentValue = StringUtil.BoolToStr( A431CategoriaStatus);
         AssignProp("", false, cmbCategoriaStatus_Internalname, "Values", (string)(cmbCategoriaStatus.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CategoriaTitulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CategoriaTitulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CategoriaTitulo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCategoriaTituloId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ",", "")), StringUtil.LTrim( ((edtCategoriaTituloId_Enabled!=0) ? context.localUtil.Format( (decimal)(A426CategoriaTituloId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A426CategoriaTituloId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaTituloId_Jsonclick, 0, "Attribute", "", "", "", "", edtCategoriaTituloId_Visible, edtCategoriaTituloId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CategoriaTitulo.htm");
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
         E111Q2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z426CategoriaTituloId"), ",", "."), 18, MidpointRounding.ToEven));
               Z427CategoriaTituloNome = cgiGet( "Z427CategoriaTituloNome");
               n427CategoriaTituloNome = (String.IsNullOrEmpty(StringUtil.RTrim( A427CategoriaTituloNome)) ? true : false);
               Z428CategoriaTituloDescricao = cgiGet( "Z428CategoriaTituloDescricao");
               n428CategoriaTituloDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A428CategoriaTituloDescricao)) ? true : false);
               Z431CategoriaStatus = StringUtil.StrToBool( cgiGet( "Z431CategoriaStatus"));
               n431CategoriaStatus = ((false==A431CategoriaStatus) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCATEGORIATITULOID"), ",", "."), 18, MidpointRounding.ToEven));
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
               A427CategoriaTituloNome = cgiGet( edtCategoriaTituloNome_Internalname);
               n427CategoriaTituloNome = false;
               AssignAttri("", false, "A427CategoriaTituloNome", A427CategoriaTituloNome);
               n427CategoriaTituloNome = (String.IsNullOrEmpty(StringUtil.RTrim( A427CategoriaTituloNome)) ? true : false);
               A428CategoriaTituloDescricao = cgiGet( edtCategoriaTituloDescricao_Internalname);
               n428CategoriaTituloDescricao = false;
               AssignAttri("", false, "A428CategoriaTituloDescricao", A428CategoriaTituloDescricao);
               n428CategoriaTituloDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A428CategoriaTituloDescricao)) ? true : false);
               cmbCategoriaStatus.CurrentValue = cgiGet( cmbCategoriaStatus_Internalname);
               A431CategoriaStatus = StringUtil.StrToBool( cgiGet( cmbCategoriaStatus_Internalname));
               n431CategoriaStatus = false;
               AssignAttri("", false, "A431CategoriaStatus", A431CategoriaStatus);
               n431CategoriaStatus = ((false==A431CategoriaStatus) ? true : false);
               A426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoriaTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n426CategoriaTituloId = false;
               AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CategoriaTitulo");
               A426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoriaTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n426CategoriaTituloId = false;
               AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
               forbiddenHiddens.Add("CategoriaTituloId", context.localUtil.Format( (decimal)(A426CategoriaTituloId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A426CategoriaTituloId != Z426CategoriaTituloId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("categoriatitulo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A431CategoriaStatus = StringUtil.StrToBool( cgiGet( cmbCategoriaStatus_Internalname));
                  n431CategoriaStatus = false;
                  AssignAttri("", false, "A431CategoriaStatus", A431CategoriaStatus);
                  forbiddenHiddens2.Add("CategoriaStatus", StringUtil.BoolToStr( A431CategoriaStatus));
               }
               hsh2 = cgiGet( "hsh2");
               if ( ( ! ( ( A426CategoriaTituloId != Z426CategoriaTituloId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens2.ToString(), hsh2, GXKey) )
               {
                  GXUtil.WriteLogError("categoriatitulo:[ CondSecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens2.ToJSonString());
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
                  A426CategoriaTituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "CategoriaTituloId"), "."), 18, MidpointRounding.ToEven));
                  n426CategoriaTituloId = false;
                  AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
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
                     sMode64 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode64;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound64 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1Q0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CATEGORIATITULOID");
                        AnyError = 1;
                        GX_FocusControl = edtCategoriaTituloId_Internalname;
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
                           E111Q2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121Q2 ();
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
            E121Q2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1Q64( ) ;
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
            DisableAttributes1Q64( ) ;
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

      protected void CONFIRM_1Q0( )
      {
         BeforeValidate1Q64( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Q64( ) ;
            }
            else
            {
               CheckExtendedTable1Q64( ) ;
               CloseExtendedTableCursors1Q64( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1Q0( )
      {
      }

      protected void E111Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtCategoriaTituloId_Visible = 0;
         AssignProp("", false, edtCategoriaTituloId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCategoriaTituloId_Visible), 5, 0), true);
      }

      protected void E121Q2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("categoriatituloww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1Q64( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z427CategoriaTituloNome = T001Q3_A427CategoriaTituloNome[0];
               Z428CategoriaTituloDescricao = T001Q3_A428CategoriaTituloDescricao[0];
               Z431CategoriaStatus = T001Q3_A431CategoriaStatus[0];
            }
            else
            {
               Z427CategoriaTituloNome = A427CategoriaTituloNome;
               Z428CategoriaTituloDescricao = A428CategoriaTituloDescricao;
               Z431CategoriaStatus = A431CategoriaStatus;
            }
         }
         if ( GX_JID == -8 )
         {
            Z426CategoriaTituloId = A426CategoriaTituloId;
            Z427CategoriaTituloNome = A427CategoriaTituloNome;
            Z428CategoriaTituloDescricao = A428CategoriaTituloDescricao;
            Z431CategoriaStatus = A431CategoriaStatus;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCategoriaTituloId_Enabled = 0;
         AssignProp("", false, edtCategoriaTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaTituloId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCategoriaTituloId_Enabled = 0;
         AssignProp("", false, edtCategoriaTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaTituloId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CategoriaTituloId) )
         {
            A426CategoriaTituloId = AV7CategoriaTituloId;
            n426CategoriaTituloId = false;
            AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            cmbCategoriaStatus.Enabled = 0;
            AssignProp("", false, cmbCategoriaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCategoriaStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbCategoriaStatus.Enabled = 1;
            AssignProp("", false, cmbCategoriaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCategoriaStatus.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            cmbCategoriaStatus.Enabled = 0;
            AssignProp("", false, cmbCategoriaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCategoriaStatus.Enabled), 5, 0), true);
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
         if ( IsIns( )  && (false==A431CategoriaStatus) && ( Gx_BScreen == 0 ) )
         {
            A431CategoriaStatus = true;
            n431CategoriaStatus = false;
            AssignAttri("", false, "A431CategoriaStatus", A431CategoriaStatus);
         }
      }

      protected void Load1Q64( )
      {
         /* Using cursor T001Q4 */
         pr_default.execute(2, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound64 = 1;
            A427CategoriaTituloNome = T001Q4_A427CategoriaTituloNome[0];
            n427CategoriaTituloNome = T001Q4_n427CategoriaTituloNome[0];
            AssignAttri("", false, "A427CategoriaTituloNome", A427CategoriaTituloNome);
            A428CategoriaTituloDescricao = T001Q4_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = T001Q4_n428CategoriaTituloDescricao[0];
            AssignAttri("", false, "A428CategoriaTituloDescricao", A428CategoriaTituloDescricao);
            A431CategoriaStatus = T001Q4_A431CategoriaStatus[0];
            n431CategoriaStatus = T001Q4_n431CategoriaStatus[0];
            AssignAttri("", false, "A431CategoriaStatus", A431CategoriaStatus);
            ZM1Q64( -8) ;
         }
         pr_default.close(2);
         OnLoadActions1Q64( ) ;
      }

      protected void OnLoadActions1Q64( )
      {
      }

      protected void CheckExtendedTable1Q64( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A427CategoriaTituloNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Categoria Titulo Nome", "", "", "", "", "", "", "", ""), 1, "CATEGORIATITULONOME");
            AnyError = 1;
            GX_FocusControl = edtCategoriaTituloNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A428CategoriaTituloDescricao)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Categoria Titulo Descricao", "", "", "", "", "", "", "", ""), 1, "CATEGORIATITULODESCRICAO");
            AnyError = 1;
            GX_FocusControl = edtCategoriaTituloDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1Q64( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1Q64( )
      {
         /* Using cursor T001Q5 */
         pr_default.execute(3, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound64 = 1;
         }
         else
         {
            RcdFound64 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001Q3 */
         pr_default.execute(1, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Q64( 8) ;
            RcdFound64 = 1;
            A426CategoriaTituloId = T001Q3_A426CategoriaTituloId[0];
            n426CategoriaTituloId = T001Q3_n426CategoriaTituloId[0];
            AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
            A427CategoriaTituloNome = T001Q3_A427CategoriaTituloNome[0];
            n427CategoriaTituloNome = T001Q3_n427CategoriaTituloNome[0];
            AssignAttri("", false, "A427CategoriaTituloNome", A427CategoriaTituloNome);
            A428CategoriaTituloDescricao = T001Q3_A428CategoriaTituloDescricao[0];
            n428CategoriaTituloDescricao = T001Q3_n428CategoriaTituloDescricao[0];
            AssignAttri("", false, "A428CategoriaTituloDescricao", A428CategoriaTituloDescricao);
            A431CategoriaStatus = T001Q3_A431CategoriaStatus[0];
            n431CategoriaStatus = T001Q3_n431CategoriaStatus[0];
            AssignAttri("", false, "A431CategoriaStatus", A431CategoriaStatus);
            Z426CategoriaTituloId = A426CategoriaTituloId;
            sMode64 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1Q64( ) ;
            if ( AnyError == 1 )
            {
               RcdFound64 = 0;
               InitializeNonKey1Q64( ) ;
            }
            Gx_mode = sMode64;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound64 = 0;
            InitializeNonKey1Q64( ) ;
            sMode64 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode64;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Q64( ) ;
         if ( RcdFound64 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound64 = 0;
         /* Using cursor T001Q6 */
         pr_default.execute(4, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001Q6_A426CategoriaTituloId[0] < A426CategoriaTituloId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001Q6_A426CategoriaTituloId[0] > A426CategoriaTituloId ) ) )
            {
               A426CategoriaTituloId = T001Q6_A426CategoriaTituloId[0];
               n426CategoriaTituloId = T001Q6_n426CategoriaTituloId[0];
               AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
               RcdFound64 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound64 = 0;
         /* Using cursor T001Q7 */
         pr_default.execute(5, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001Q7_A426CategoriaTituloId[0] > A426CategoriaTituloId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001Q7_A426CategoriaTituloId[0] < A426CategoriaTituloId ) ) )
            {
               A426CategoriaTituloId = T001Q7_A426CategoriaTituloId[0];
               n426CategoriaTituloId = T001Q7_n426CategoriaTituloId[0];
               AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
               RcdFound64 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1Q64( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCategoriaTituloNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1Q64( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound64 == 1 )
            {
               if ( A426CategoriaTituloId != Z426CategoriaTituloId )
               {
                  A426CategoriaTituloId = Z426CategoriaTituloId;
                  n426CategoriaTituloId = false;
                  AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CATEGORIATITULOID");
                  AnyError = 1;
                  GX_FocusControl = edtCategoriaTituloId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCategoriaTituloNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1Q64( ) ;
                  GX_FocusControl = edtCategoriaTituloNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A426CategoriaTituloId != Z426CategoriaTituloId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCategoriaTituloNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1Q64( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CATEGORIATITULOID");
                     AnyError = 1;
                     GX_FocusControl = edtCategoriaTituloId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCategoriaTituloNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1Q64( ) ;
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
         if ( A426CategoriaTituloId != Z426CategoriaTituloId )
         {
            A426CategoriaTituloId = Z426CategoriaTituloId;
            n426CategoriaTituloId = false;
            AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CATEGORIATITULOID");
            AnyError = 1;
            GX_FocusControl = edtCategoriaTituloId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCategoriaTituloNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1Q64( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Q2 */
            pr_default.execute(0, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CategoriaTitulo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z427CategoriaTituloNome, T001Q2_A427CategoriaTituloNome[0]) != 0 ) || ( StringUtil.StrCmp(Z428CategoriaTituloDescricao, T001Q2_A428CategoriaTituloDescricao[0]) != 0 ) || ( Z431CategoriaStatus != T001Q2_A431CategoriaStatus[0] ) )
            {
               if ( StringUtil.StrCmp(Z427CategoriaTituloNome, T001Q2_A427CategoriaTituloNome[0]) != 0 )
               {
                  GXUtil.WriteLog("categoriatitulo:[seudo value changed for attri]"+"CategoriaTituloNome");
                  GXUtil.WriteLogRaw("Old: ",Z427CategoriaTituloNome);
                  GXUtil.WriteLogRaw("Current: ",T001Q2_A427CategoriaTituloNome[0]);
               }
               if ( StringUtil.StrCmp(Z428CategoriaTituloDescricao, T001Q2_A428CategoriaTituloDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("categoriatitulo:[seudo value changed for attri]"+"CategoriaTituloDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z428CategoriaTituloDescricao);
                  GXUtil.WriteLogRaw("Current: ",T001Q2_A428CategoriaTituloDescricao[0]);
               }
               if ( Z431CategoriaStatus != T001Q2_A431CategoriaStatus[0] )
               {
                  GXUtil.WriteLog("categoriatitulo:[seudo value changed for attri]"+"CategoriaStatus");
                  GXUtil.WriteLogRaw("Old: ",Z431CategoriaStatus);
                  GXUtil.WriteLogRaw("Current: ",T001Q2_A431CategoriaStatus[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CategoriaTitulo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Q64( )
      {
         BeforeValidate1Q64( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q64( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Q64( 0) ;
            CheckOptimisticConcurrency1Q64( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q64( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Q64( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Q8 */
                     pr_default.execute(6, new Object[] {n427CategoriaTituloNome, A427CategoriaTituloNome, n428CategoriaTituloDescricao, A428CategoriaTituloDescricao, n431CategoriaStatus, A431CategoriaStatus});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001Q9 */
                     pr_default.execute(7);
                     A426CategoriaTituloId = T001Q9_A426CategoriaTituloId[0];
                     n426CategoriaTituloId = T001Q9_n426CategoriaTituloId[0];
                     AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("CategoriaTitulo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1Q0( ) ;
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
               Load1Q64( ) ;
            }
            EndLevel1Q64( ) ;
         }
         CloseExtendedTableCursors1Q64( ) ;
      }

      protected void Update1Q64( )
      {
         BeforeValidate1Q64( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Q64( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q64( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Q64( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Q64( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Q10 */
                     pr_default.execute(8, new Object[] {n427CategoriaTituloNome, A427CategoriaTituloNome, n428CategoriaTituloDescricao, A428CategoriaTituloDescricao, n431CategoriaStatus, A431CategoriaStatus, n426CategoriaTituloId, A426CategoriaTituloId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("CategoriaTitulo");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CategoriaTitulo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Q64( ) ;
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
            EndLevel1Q64( ) ;
         }
         CloseExtendedTableCursors1Q64( ) ;
      }

      protected void DeferredUpdate1Q64( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1Q64( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Q64( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Q64( ) ;
            AfterConfirm1Q64( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Q64( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001Q11 */
                  pr_default.execute(9, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("CategoriaTitulo");
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
         sMode64 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Q64( ) ;
         Gx_mode = sMode64;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Q64( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001Q12 */
            pr_default.execute(10, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuracoes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T001Q13 */
            pr_default.execute(11, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel1Q64( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Q64( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("categoriatitulo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("categoriatitulo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1Q64( )
      {
         /* Scan By routine */
         /* Using cursor T001Q14 */
         pr_default.execute(12);
         RcdFound64 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound64 = 1;
            A426CategoriaTituloId = T001Q14_A426CategoriaTituloId[0];
            n426CategoriaTituloId = T001Q14_n426CategoriaTituloId[0];
            AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Q64( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound64 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound64 = 1;
            A426CategoriaTituloId = T001Q14_A426CategoriaTituloId[0];
            n426CategoriaTituloId = T001Q14_n426CategoriaTituloId[0];
            AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
         }
      }

      protected void ScanEnd1Q64( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1Q64( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Q64( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Q64( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Q64( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Q64( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Q64( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Q64( )
      {
         edtCategoriaTituloNome_Enabled = 0;
         AssignProp("", false, edtCategoriaTituloNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaTituloNome_Enabled), 5, 0), true);
         edtCategoriaTituloDescricao_Enabled = 0;
         AssignProp("", false, edtCategoriaTituloDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaTituloDescricao_Enabled), 5, 0), true);
         cmbCategoriaStatus.Enabled = 0;
         AssignProp("", false, cmbCategoriaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCategoriaStatus.Enabled), 5, 0), true);
         edtCategoriaTituloId_Enabled = 0;
         AssignProp("", false, edtCategoriaTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaTituloId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1Q64( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1Q0( )
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
         GXEncryptionTmp = "categoriatitulo"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CategoriaTituloId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("categoriatitulo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CategoriaTitulo");
         forbiddenHiddens.Add("CategoriaTituloId", context.localUtil.Format( (decimal)(A426CategoriaTituloId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("categoriatitulo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         forbiddenHiddens2 = new GXProperties();
         if ( IsIns( )  )
         {
            forbiddenHiddens2.Add("CategoriaStatus", StringUtil.BoolToStr( A431CategoriaStatus));
         }
         GxWebStd.gx_hidden_field( context, "hsh2", GetEncryptedHash( forbiddenHiddens2.ToString(), GXKey));
         GXUtil.WriteLogInfo("categoriatitulo:[ SendCondSecurityCheck value for]"+forbiddenHiddens2.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z426CategoriaTituloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z426CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z427CategoriaTituloNome", Z427CategoriaTituloNome);
         GxWebStd.gx_hidden_field( context, "Z428CategoriaTituloDescricao", Z428CategoriaTituloDescricao);
         GxWebStd.gx_boolean_hidden_field( context, "Z431CategoriaStatus", Z431CategoriaStatus);
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
         GxWebStd.gx_hidden_field( context, "vCATEGORIATITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCATEGORIATITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CategoriaTituloId), "ZZZZZZZZ9"), context));
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
         GXEncryptionTmp = "categoriatitulo"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CategoriaTituloId,9,0));
         return formatLink("categoriatitulo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "CategoriaTitulo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Categoria Titulo" ;
      }

      protected void InitializeNonKey1Q64( )
      {
         A427CategoriaTituloNome = "";
         n427CategoriaTituloNome = false;
         AssignAttri("", false, "A427CategoriaTituloNome", A427CategoriaTituloNome);
         n427CategoriaTituloNome = (String.IsNullOrEmpty(StringUtil.RTrim( A427CategoriaTituloNome)) ? true : false);
         A428CategoriaTituloDescricao = "";
         n428CategoriaTituloDescricao = false;
         AssignAttri("", false, "A428CategoriaTituloDescricao", A428CategoriaTituloDescricao);
         n428CategoriaTituloDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A428CategoriaTituloDescricao)) ? true : false);
         A431CategoriaStatus = true;
         n431CategoriaStatus = false;
         AssignAttri("", false, "A431CategoriaStatus", A431CategoriaStatus);
         Z427CategoriaTituloNome = "";
         Z428CategoriaTituloDescricao = "";
         Z431CategoriaStatus = false;
      }

      protected void InitAll1Q64( )
      {
         A426CategoriaTituloId = 0;
         n426CategoriaTituloId = false;
         AssignAttri("", false, "A426CategoriaTituloId", StringUtil.LTrimStr( (decimal)(A426CategoriaTituloId), 9, 0));
         InitializeNonKey1Q64( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A431CategoriaStatus = i431CategoriaStatus;
         n431CategoriaStatus = false;
         AssignAttri("", false, "A431CategoriaStatus", A431CategoriaStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019172236", true, true);
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
         context.AddJavascriptSource("categoriatitulo.js", "?202561019172236", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCategoriaTituloNome_Internalname = "CATEGORIATITULONOME";
         edtCategoriaTituloDescricao_Internalname = "CATEGORIATITULODESCRICAO";
         cmbCategoriaStatus_Internalname = "CATEGORIASTATUS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtCategoriaTituloId_Internalname = "CATEGORIATITULOID";
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
         Form.Caption = "Categoria Titulo";
         edtCategoriaTituloId_Jsonclick = "";
         edtCategoriaTituloId_Enabled = 0;
         edtCategoriaTituloId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbCategoriaStatus_Jsonclick = "";
         cmbCategoriaStatus.Enabled = 1;
         edtCategoriaTituloDescricao_Jsonclick = "";
         edtCategoriaTituloDescricao_Enabled = 1;
         edtCategoriaTituloNome_Jsonclick = "";
         edtCategoriaTituloNome_Enabled = 1;
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
         cmbCategoriaStatus.Name = "CATEGORIASTATUS";
         cmbCategoriaStatus.WebTags = "";
         cmbCategoriaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbCategoriaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbCategoriaStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A431CategoriaStatus) )
            {
               A431CategoriaStatus = true;
               n431CategoriaStatus = false;
               AssignAttri("", false, "A431CategoriaStatus", A431CategoriaStatus);
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7CategoriaTituloId","fld":"vCATEGORIATITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7CategoriaTituloId","fld":"vCATEGORIATITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A426CategoriaTituloId","fld":"CATEGORIATITULOID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121Q2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_CATEGORIATITULONOME","""{"handler":"Valid_Categoriatitulonome","iparms":[]}""");
         setEventMetadata("VALID_CATEGORIATITULODESCRICAO","""{"handler":"Valid_Categoriatitulodescricao","iparms":[]}""");
         setEventMetadata("VALID_CATEGORIATITULOID","""{"handler":"Valid_Categoriatituloid","iparms":[]}""");
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
         Z427CategoriaTituloNome = "";
         Z428CategoriaTituloDescricao = "";
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
         A427CategoriaTituloNome = "";
         A428CategoriaTituloDescricao = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         forbiddenHiddens2 = new GXProperties();
         hsh2 = "";
         sMode64 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T001Q4_A426CategoriaTituloId = new int[1] ;
         T001Q4_n426CategoriaTituloId = new bool[] {false} ;
         T001Q4_A427CategoriaTituloNome = new string[] {""} ;
         T001Q4_n427CategoriaTituloNome = new bool[] {false} ;
         T001Q4_A428CategoriaTituloDescricao = new string[] {""} ;
         T001Q4_n428CategoriaTituloDescricao = new bool[] {false} ;
         T001Q4_A431CategoriaStatus = new bool[] {false} ;
         T001Q4_n431CategoriaStatus = new bool[] {false} ;
         T001Q5_A426CategoriaTituloId = new int[1] ;
         T001Q5_n426CategoriaTituloId = new bool[] {false} ;
         T001Q3_A426CategoriaTituloId = new int[1] ;
         T001Q3_n426CategoriaTituloId = new bool[] {false} ;
         T001Q3_A427CategoriaTituloNome = new string[] {""} ;
         T001Q3_n427CategoriaTituloNome = new bool[] {false} ;
         T001Q3_A428CategoriaTituloDescricao = new string[] {""} ;
         T001Q3_n428CategoriaTituloDescricao = new bool[] {false} ;
         T001Q3_A431CategoriaStatus = new bool[] {false} ;
         T001Q3_n431CategoriaStatus = new bool[] {false} ;
         T001Q6_A426CategoriaTituloId = new int[1] ;
         T001Q6_n426CategoriaTituloId = new bool[] {false} ;
         T001Q7_A426CategoriaTituloId = new int[1] ;
         T001Q7_n426CategoriaTituloId = new bool[] {false} ;
         T001Q2_A426CategoriaTituloId = new int[1] ;
         T001Q2_n426CategoriaTituloId = new bool[] {false} ;
         T001Q2_A427CategoriaTituloNome = new string[] {""} ;
         T001Q2_n427CategoriaTituloNome = new bool[] {false} ;
         T001Q2_A428CategoriaTituloDescricao = new string[] {""} ;
         T001Q2_n428CategoriaTituloDescricao = new bool[] {false} ;
         T001Q2_A431CategoriaStatus = new bool[] {false} ;
         T001Q2_n431CategoriaStatus = new bool[] {false} ;
         T001Q9_A426CategoriaTituloId = new int[1] ;
         T001Q9_n426CategoriaTituloId = new bool[] {false} ;
         T001Q12_A299ConfiguracoesId = new int[1] ;
         T001Q13_A261TituloId = new int[1] ;
         T001Q14_A426CategoriaTituloId = new int[1] ;
         T001Q14_n426CategoriaTituloId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.categoriatitulo__default(),
            new Object[][] {
                new Object[] {
               T001Q2_A426CategoriaTituloId, T001Q2_A427CategoriaTituloNome, T001Q2_n427CategoriaTituloNome, T001Q2_A428CategoriaTituloDescricao, T001Q2_n428CategoriaTituloDescricao, T001Q2_A431CategoriaStatus, T001Q2_n431CategoriaStatus
               }
               , new Object[] {
               T001Q3_A426CategoriaTituloId, T001Q3_A427CategoriaTituloNome, T001Q3_n427CategoriaTituloNome, T001Q3_A428CategoriaTituloDescricao, T001Q3_n428CategoriaTituloDescricao, T001Q3_A431CategoriaStatus, T001Q3_n431CategoriaStatus
               }
               , new Object[] {
               T001Q4_A426CategoriaTituloId, T001Q4_A427CategoriaTituloNome, T001Q4_n427CategoriaTituloNome, T001Q4_A428CategoriaTituloDescricao, T001Q4_n428CategoriaTituloDescricao, T001Q4_A431CategoriaStatus, T001Q4_n431CategoriaStatus
               }
               , new Object[] {
               T001Q5_A426CategoriaTituloId
               }
               , new Object[] {
               T001Q6_A426CategoriaTituloId
               }
               , new Object[] {
               T001Q7_A426CategoriaTituloId
               }
               , new Object[] {
               }
               , new Object[] {
               T001Q9_A426CategoriaTituloId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Q12_A299ConfiguracoesId
               }
               , new Object[] {
               T001Q13_A261TituloId
               }
               , new Object[] {
               T001Q14_A426CategoriaTituloId
               }
            }
         );
         Z431CategoriaStatus = true;
         n431CategoriaStatus = false;
         A431CategoriaStatus = true;
         n431CategoriaStatus = false;
         i431CategoriaStatus = true;
         n431CategoriaStatus = false;
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound64 ;
      private short gxajaxcallmode ;
      private int wcpOAV7CategoriaTituloId ;
      private int Z426CategoriaTituloId ;
      private int AV7CategoriaTituloId ;
      private int trnEnded ;
      private int edtCategoriaTituloNome_Enabled ;
      private int edtCategoriaTituloDescricao_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A426CategoriaTituloId ;
      private int edtCategoriaTituloId_Enabled ;
      private int edtCategoriaTituloId_Visible ;
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
      private string edtCategoriaTituloNome_Internalname ;
      private string cmbCategoriaStatus_Internalname ;
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
      private string edtCategoriaTituloNome_Jsonclick ;
      private string edtCategoriaTituloDescricao_Internalname ;
      private string edtCategoriaTituloDescricao_Jsonclick ;
      private string cmbCategoriaStatus_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCategoriaTituloId_Internalname ;
      private string edtCategoriaTituloId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string hsh2 ;
      private string sMode64 ;
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
      private bool Z431CategoriaStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A431CategoriaStatus ;
      private bool n431CategoriaStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n427CategoriaTituloNome ;
      private bool n428CategoriaTituloDescricao ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n426CategoriaTituloId ;
      private bool returnInSub ;
      private bool i431CategoriaStatus ;
      private string Z427CategoriaTituloNome ;
      private string Z428CategoriaTituloDescricao ;
      private string A427CategoriaTituloNome ;
      private string A428CategoriaTituloDescricao ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXProperties forbiddenHiddens2 ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCategoriaStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] T001Q4_A426CategoriaTituloId ;
      private bool[] T001Q4_n426CategoriaTituloId ;
      private string[] T001Q4_A427CategoriaTituloNome ;
      private bool[] T001Q4_n427CategoriaTituloNome ;
      private string[] T001Q4_A428CategoriaTituloDescricao ;
      private bool[] T001Q4_n428CategoriaTituloDescricao ;
      private bool[] T001Q4_A431CategoriaStatus ;
      private bool[] T001Q4_n431CategoriaStatus ;
      private int[] T001Q5_A426CategoriaTituloId ;
      private bool[] T001Q5_n426CategoriaTituloId ;
      private int[] T001Q3_A426CategoriaTituloId ;
      private bool[] T001Q3_n426CategoriaTituloId ;
      private string[] T001Q3_A427CategoriaTituloNome ;
      private bool[] T001Q3_n427CategoriaTituloNome ;
      private string[] T001Q3_A428CategoriaTituloDescricao ;
      private bool[] T001Q3_n428CategoriaTituloDescricao ;
      private bool[] T001Q3_A431CategoriaStatus ;
      private bool[] T001Q3_n431CategoriaStatus ;
      private int[] T001Q6_A426CategoriaTituloId ;
      private bool[] T001Q6_n426CategoriaTituloId ;
      private int[] T001Q7_A426CategoriaTituloId ;
      private bool[] T001Q7_n426CategoriaTituloId ;
      private int[] T001Q2_A426CategoriaTituloId ;
      private bool[] T001Q2_n426CategoriaTituloId ;
      private string[] T001Q2_A427CategoriaTituloNome ;
      private bool[] T001Q2_n427CategoriaTituloNome ;
      private string[] T001Q2_A428CategoriaTituloDescricao ;
      private bool[] T001Q2_n428CategoriaTituloDescricao ;
      private bool[] T001Q2_A431CategoriaStatus ;
      private bool[] T001Q2_n431CategoriaStatus ;
      private int[] T001Q9_A426CategoriaTituloId ;
      private bool[] T001Q9_n426CategoriaTituloId ;
      private int[] T001Q12_A299ConfiguracoesId ;
      private int[] T001Q13_A261TituloId ;
      private int[] T001Q14_A426CategoriaTituloId ;
      private bool[] T001Q14_n426CategoriaTituloId ;
   }

   public class categoriatitulo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT001Q2;
          prmT001Q2 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Q3;
          prmT001Q3 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Q4;
          prmT001Q4 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Q5;
          prmT001Q5 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Q6;
          prmT001Q6 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Q7;
          prmT001Q7 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Q8;
          prmT001Q8 = new Object[] {
          new ParDef("CategoriaTituloNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("CategoriaTituloDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("CategoriaStatus",GXType.Boolean,4,0){Nullable=true}
          };
          Object[] prmT001Q9;
          prmT001Q9 = new Object[] {
          };
          Object[] prmT001Q10;
          prmT001Q10 = new Object[] {
          new ParDef("CategoriaTituloNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("CategoriaTituloDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("CategoriaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Q11;
          prmT001Q11 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Q12;
          prmT001Q12 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Q13;
          prmT001Q13 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001Q14;
          prmT001Q14 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T001Q2", "SELECT CategoriaTituloId, CategoriaTituloNome, CategoriaTituloDescricao, CategoriaStatus FROM CategoriaTitulo WHERE CategoriaTituloId = :CategoriaTituloId  FOR UPDATE OF CategoriaTitulo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Q3", "SELECT CategoriaTituloId, CategoriaTituloNome, CategoriaTituloDescricao, CategoriaStatus FROM CategoriaTitulo WHERE CategoriaTituloId = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Q4", "SELECT TM1.CategoriaTituloId, TM1.CategoriaTituloNome, TM1.CategoriaTituloDescricao, TM1.CategoriaStatus FROM CategoriaTitulo TM1 WHERE TM1.CategoriaTituloId = :CategoriaTituloId ORDER BY TM1.CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Q5", "SELECT CategoriaTituloId FROM CategoriaTitulo WHERE CategoriaTituloId = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Q6", "SELECT CategoriaTituloId FROM CategoriaTitulo WHERE ( CategoriaTituloId > :CategoriaTituloId) ORDER BY CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Q7", "SELECT CategoriaTituloId FROM CategoriaTitulo WHERE ( CategoriaTituloId < :CategoriaTituloId) ORDER BY CategoriaTituloId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Q8", "SAVEPOINT gxupdate;INSERT INTO CategoriaTitulo(CategoriaTituloNome, CategoriaTituloDescricao, CategoriaStatus) VALUES(:CategoriaTituloNome, :CategoriaTituloDescricao, :CategoriaStatus);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001Q8)
             ,new CursorDef("T001Q9", "SELECT currval('CategoriaTituloId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001Q10", "SAVEPOINT gxupdate;UPDATE CategoriaTitulo SET CategoriaTituloNome=:CategoriaTituloNome, CategoriaTituloDescricao=:CategoriaTituloDescricao, CategoriaStatus=:CategoriaStatus  WHERE CategoriaTituloId = :CategoriaTituloId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Q10)
             ,new CursorDef("T001Q11", "SAVEPOINT gxupdate;DELETE FROM CategoriaTitulo  WHERE CategoriaTituloId = :CategoriaTituloId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001Q11)
             ,new CursorDef("T001Q12", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfiguracoesCategoriaTitulo = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Q13", "SELECT TituloId FROM Titulo WHERE CategoriaTituloId = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001Q14", "SELECT CategoriaTituloId FROM CategoriaTitulo ORDER BY CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Q14,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
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
