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
   public class conveniocategoria : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A410ConvenioId = (int)(Math.Round(NumberUtil.Val( GetPar( "ConvenioId"), "."), 18, MidpointRounding.ToEven));
            n410ConvenioId = false;
            AssignAttri("", false, "A410ConvenioId", ((0==A410ConvenioId)&&IsIns( )||n410ConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A410ConvenioId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "conveniocategoria")), "conveniocategoria") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "conveniocategoria")))) ;
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
                  AV7ConvenioCategoriaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ConvenioCategoriaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV7ConvenioCategoriaId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCONVENIOCATEGORIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ConvenioCategoriaId), "ZZZZZZZZ9"), context));
                  AV13ConvenioId = (int)(Math.Round(NumberUtil.Val( GetPar( "ConvenioId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13ConvenioId", StringUtil.LTrimStr( (decimal)(AV13ConvenioId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCONVENIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13ConvenioId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Convenio Categoria", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtConvenioCategoriaDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public conveniocategoria( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conveniocategoria( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ConvenioCategoriaId ,
                           int aP2_ConvenioId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ConvenioCategoriaId = aP1_ConvenioCategoriaId;
         this.AV13ConvenioId = aP2_ConvenioId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbConvenioCategoriaStatus = new GXCombobox();
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
         if ( cmbConvenioCategoriaStatus.ItemCount > 0 )
         {
            A495ConvenioCategoriaStatus = StringUtil.StrToBool( cmbConvenioCategoriaStatus.getValidValue(StringUtil.BoolToStr( A495ConvenioCategoriaStatus)));
            n495ConvenioCategoriaStatus = false;
            AssignAttri("", false, "A495ConvenioCategoriaStatus", A495ConvenioCategoriaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConvenioCategoriaStatus.CurrentValue = StringUtil.BoolToStr( A495ConvenioCategoriaStatus);
            AssignProp("", false, cmbConvenioCategoriaStatus_Internalname, "Values", cmbConvenioCategoriaStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConvenioCategoriaDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConvenioCategoriaDescricao_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConvenioCategoriaDescricao_Internalname, A494ConvenioCategoriaDescricao, StringUtil.RTrim( context.localUtil.Format( A494ConvenioCategoriaDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConvenioCategoriaDescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConvenioCategoriaDescricao_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ConvenioCategoria.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbConvenioCategoriaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConvenioCategoriaStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConvenioCategoriaStatus, cmbConvenioCategoriaStatus_Internalname, StringUtil.BoolToStr( A495ConvenioCategoriaStatus), 1, cmbConvenioCategoriaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbConvenioCategoriaStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_ConvenioCategoria.htm");
         cmbConvenioCategoriaStatus.CurrentValue = StringUtil.BoolToStr( A495ConvenioCategoriaStatus);
         AssignProp("", false, cmbConvenioCategoriaStatus_Internalname, "Values", (string)(cmbConvenioCategoriaStatus.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ConvenioCategoria.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ConvenioCategoria.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ConvenioCategoria.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConvenioCategoriaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtConvenioCategoriaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A493ConvenioCategoriaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A493ConvenioCategoriaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConvenioCategoriaId_Jsonclick, 0, "Attribute", "", "", "", "", edtConvenioCategoriaId_Visible, edtConvenioCategoriaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ConvenioCategoria.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConvenioId_Internalname, ((0==A410ConvenioId)&&IsIns( )||n410ConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ",", ""))), ((0==A410ConvenioId)&&IsIns( )||n410ConvenioId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A410ConvenioId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConvenioId_Jsonclick, 0, "Attribute", "", "", "", "", edtConvenioId_Visible, edtConvenioId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ConvenioCategoria.htm");
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
         E111W2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z493ConvenioCategoriaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z493ConvenioCategoriaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z494ConvenioCategoriaDescricao = cgiGet( "Z494ConvenioCategoriaDescricao");
               n494ConvenioCategoriaDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A494ConvenioCategoriaDescricao)) ? true : false);
               Z495ConvenioCategoriaStatus = StringUtil.StrToBool( cgiGet( "Z495ConvenioCategoriaStatus"));
               n495ConvenioCategoriaStatus = ((false==A495ConvenioCategoriaStatus) ? true : false);
               Z410ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z410ConvenioId"), ",", "."), 18, MidpointRounding.ToEven));
               n410ConvenioId = ((0==A410ConvenioId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N410ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N410ConvenioId"), ",", "."), 18, MidpointRounding.ToEven));
               n410ConvenioId = ((0==A410ConvenioId) ? true : false);
               AV7ConvenioCategoriaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCONVENIOCATEGORIAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONVENIOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_ConvenioId", StringUtil.LTrimStr( (decimal)(AV11Insert_ConvenioId), 9, 0));
               AV13ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCONVENIOID"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               AV15Pgmname = cgiGet( "vPGMNAME");
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
               A494ConvenioCategoriaDescricao = cgiGet( edtConvenioCategoriaDescricao_Internalname);
               n494ConvenioCategoriaDescricao = false;
               AssignAttri("", false, "A494ConvenioCategoriaDescricao", A494ConvenioCategoriaDescricao);
               n494ConvenioCategoriaDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A494ConvenioCategoriaDescricao)) ? true : false);
               cmbConvenioCategoriaStatus.CurrentValue = cgiGet( cmbConvenioCategoriaStatus_Internalname);
               A495ConvenioCategoriaStatus = StringUtil.StrToBool( cgiGet( cmbConvenioCategoriaStatus_Internalname));
               n495ConvenioCategoriaStatus = false;
               AssignAttri("", false, "A495ConvenioCategoriaStatus", A495ConvenioCategoriaStatus);
               n495ConvenioCategoriaStatus = ((false==A495ConvenioCategoriaStatus) ? true : false);
               A493ConvenioCategoriaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtConvenioCategoriaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n493ConvenioCategoriaId = false;
               AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
               n410ConvenioId = ((StringUtil.StrCmp(cgiGet( edtConvenioId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtConvenioId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConvenioId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONVENIOID");
                  AnyError = 1;
                  GX_FocusControl = edtConvenioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A410ConvenioId = 0;
                  n410ConvenioId = false;
                  AssignAttri("", false, "A410ConvenioId", (n410ConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ".", ""))));
               }
               else
               {
                  A410ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtConvenioId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A410ConvenioId", (n410ConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ".", ""))));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ConvenioCategoria");
               A493ConvenioCategoriaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtConvenioCategoriaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n493ConvenioCategoriaId = false;
               AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
               forbiddenHiddens.Add("ConvenioCategoriaId", context.localUtil.Format( (decimal)(A493ConvenioCategoriaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ConvenioId", context.localUtil.Format( (decimal)(AV11Insert_ConvenioId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A493ConvenioCategoriaId != Z493ConvenioCategoriaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("conveniocategoria:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A493ConvenioCategoriaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ConvenioCategoriaId"), "."), 18, MidpointRounding.ToEven));
                  n493ConvenioCategoriaId = false;
                  AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
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
                     sMode70 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode70;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound70 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1W0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CONVENIOCATEGORIAID");
                        AnyError = 1;
                        GX_FocusControl = edtConvenioCategoriaId_Internalname;
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
                           E111W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121W2 ();
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
            E121W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1W70( ) ;
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
            DisableAttributes1W70( ) ;
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

      protected void CONFIRM_1W0( )
      {
         BeforeValidate1W70( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1W70( ) ;
            }
            else
            {
               CheckExtendedTable1W70( ) ;
               CloseExtendedTableCursors1W70( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1W0( )
      {
      }

      protected void E111W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ConvenioId") == 0 )
               {
                  AV11Insert_ConvenioId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ConvenioId", StringUtil.LTrimStr( (decimal)(AV11Insert_ConvenioId), 9, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            }
         }
         edtConvenioCategoriaId_Visible = 0;
         AssignProp("", false, edtConvenioCategoriaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtConvenioCategoriaId_Visible), 5, 0), true);
         edtConvenioId_Visible = 0;
         AssignProp("", false, edtConvenioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtConvenioId_Visible), 5, 0), true);
      }

      protected void E121W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "conveniocategoriaww"+UrlEncode(StringUtil.LTrimStr(A410ConvenioId,9,0));
            CallWebObject(formatLink("conveniocategoriaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1W70( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z494ConvenioCategoriaDescricao = T001W3_A494ConvenioCategoriaDescricao[0];
               Z495ConvenioCategoriaStatus = T001W3_A495ConvenioCategoriaStatus[0];
               Z410ConvenioId = T001W3_A410ConvenioId[0];
            }
            else
            {
               Z494ConvenioCategoriaDescricao = A494ConvenioCategoriaDescricao;
               Z495ConvenioCategoriaStatus = A495ConvenioCategoriaStatus;
               Z410ConvenioId = A410ConvenioId;
            }
         }
         if ( GX_JID == -11 )
         {
            Z493ConvenioCategoriaId = A493ConvenioCategoriaId;
            Z494ConvenioCategoriaDescricao = A494ConvenioCategoriaDescricao;
            Z495ConvenioCategoriaStatus = A495ConvenioCategoriaStatus;
            Z410ConvenioId = A410ConvenioId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtConvenioCategoriaId_Enabled = 0;
         AssignProp("", false, edtConvenioCategoriaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConvenioCategoriaId_Enabled), 5, 0), true);
         AV15Pgmname = "ConvenioCategoria";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtConvenioCategoriaId_Enabled = 0;
         AssignProp("", false, edtConvenioCategoriaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConvenioCategoriaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ConvenioCategoriaId) )
         {
            A493ConvenioCategoriaId = AV7ConvenioCategoriaId;
            n493ConvenioCategoriaId = false;
            AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ConvenioId) )
         {
            edtConvenioId_Enabled = 0;
            AssignProp("", false, edtConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConvenioId_Enabled), 5, 0), true);
         }
         else
         {
            edtConvenioId_Enabled = 1;
            AssignProp("", false, edtConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConvenioId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            cmbConvenioCategoriaStatus.Enabled = 0;
            AssignProp("", false, cmbConvenioCategoriaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConvenioCategoriaStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbConvenioCategoriaStatus.Enabled = 1;
            AssignProp("", false, cmbConvenioCategoriaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConvenioCategoriaStatus.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            cmbConvenioCategoriaStatus.Enabled = 0;
            AssignProp("", false, cmbConvenioCategoriaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConvenioCategoriaStatus.Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ConvenioId) )
         {
            A410ConvenioId = AV11Insert_ConvenioId;
            n410ConvenioId = false;
            AssignAttri("", false, "A410ConvenioId", ((0==A410ConvenioId)&&IsIns( )||n410ConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ".", ""))));
         }
         else
         {
            if ( IsIns( )  && (0==A410ConvenioId) && ( Gx_BScreen == 0 ) )
            {
               A410ConvenioId = AV13ConvenioId;
               n410ConvenioId = false;
               AssignAttri("", false, "A410ConvenioId", ((0==A410ConvenioId)&&IsIns( )||n410ConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ".", ""))));
            }
         }
         if ( IsIns( )  && (false==A495ConvenioCategoriaStatus) && ( Gx_BScreen == 0 ) )
         {
            A495ConvenioCategoriaStatus = true;
            n495ConvenioCategoriaStatus = false;
            AssignAttri("", false, "A495ConvenioCategoriaStatus", A495ConvenioCategoriaStatus);
         }
      }

      protected void Load1W70( )
      {
         /* Using cursor T001W5 */
         pr_default.execute(3, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound70 = 1;
            A494ConvenioCategoriaDescricao = T001W5_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = T001W5_n494ConvenioCategoriaDescricao[0];
            AssignAttri("", false, "A494ConvenioCategoriaDescricao", A494ConvenioCategoriaDescricao);
            A495ConvenioCategoriaStatus = T001W5_A495ConvenioCategoriaStatus[0];
            n495ConvenioCategoriaStatus = T001W5_n495ConvenioCategoriaStatus[0];
            AssignAttri("", false, "A495ConvenioCategoriaStatus", A495ConvenioCategoriaStatus);
            A410ConvenioId = T001W5_A410ConvenioId[0];
            n410ConvenioId = T001W5_n410ConvenioId[0];
            AssignAttri("", false, "A410ConvenioId", ((0==A410ConvenioId)&&IsIns( )||n410ConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ".", ""))));
            ZM1W70( -11) ;
         }
         pr_default.close(3);
         OnLoadActions1W70( ) ;
      }

      protected void OnLoadActions1W70( )
      {
      }

      protected void CheckExtendedTable1W70( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001W4 */
         pr_default.execute(2, new Object[] {n410ConvenioId, A410ConvenioId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A410ConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'Convenio'.", "ForeignKeyNotFound", 1, "CONVENIOID");
               AnyError = 1;
               GX_FocusControl = edtConvenioId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1W70( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A410ConvenioId )
      {
         /* Using cursor T001W6 */
         pr_default.execute(4, new Object[] {n410ConvenioId, A410ConvenioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A410ConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'Convenio'.", "ForeignKeyNotFound", 1, "CONVENIOID");
               AnyError = 1;
               GX_FocusControl = edtConvenioId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1W70( )
      {
         /* Using cursor T001W7 */
         pr_default.execute(5, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound70 = 1;
         }
         else
         {
            RcdFound70 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001W3 */
         pr_default.execute(1, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1W70( 11) ;
            RcdFound70 = 1;
            A493ConvenioCategoriaId = T001W3_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = T001W3_n493ConvenioCategoriaId[0];
            AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
            A494ConvenioCategoriaDescricao = T001W3_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = T001W3_n494ConvenioCategoriaDescricao[0];
            AssignAttri("", false, "A494ConvenioCategoriaDescricao", A494ConvenioCategoriaDescricao);
            A495ConvenioCategoriaStatus = T001W3_A495ConvenioCategoriaStatus[0];
            n495ConvenioCategoriaStatus = T001W3_n495ConvenioCategoriaStatus[0];
            AssignAttri("", false, "A495ConvenioCategoriaStatus", A495ConvenioCategoriaStatus);
            A410ConvenioId = T001W3_A410ConvenioId[0];
            n410ConvenioId = T001W3_n410ConvenioId[0];
            AssignAttri("", false, "A410ConvenioId", ((0==A410ConvenioId)&&IsIns( )||n410ConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ".", ""))));
            Z493ConvenioCategoriaId = A493ConvenioCategoriaId;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1W70( ) ;
            if ( AnyError == 1 )
            {
               RcdFound70 = 0;
               InitializeNonKey1W70( ) ;
            }
            Gx_mode = sMode70;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound70 = 0;
            InitializeNonKey1W70( ) ;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode70;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1W70( ) ;
         if ( RcdFound70 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound70 = 0;
         /* Using cursor T001W8 */
         pr_default.execute(6, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001W8_A493ConvenioCategoriaId[0] < A493ConvenioCategoriaId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001W8_A493ConvenioCategoriaId[0] > A493ConvenioCategoriaId ) ) )
            {
               A493ConvenioCategoriaId = T001W8_A493ConvenioCategoriaId[0];
               n493ConvenioCategoriaId = T001W8_n493ConvenioCategoriaId[0];
               AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
               RcdFound70 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound70 = 0;
         /* Using cursor T001W9 */
         pr_default.execute(7, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001W9_A493ConvenioCategoriaId[0] > A493ConvenioCategoriaId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001W9_A493ConvenioCategoriaId[0] < A493ConvenioCategoriaId ) ) )
            {
               A493ConvenioCategoriaId = T001W9_A493ConvenioCategoriaId[0];
               n493ConvenioCategoriaId = T001W9_n493ConvenioCategoriaId[0];
               AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
               RcdFound70 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1W70( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtConvenioCategoriaDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1W70( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound70 == 1 )
            {
               if ( A493ConvenioCategoriaId != Z493ConvenioCategoriaId )
               {
                  A493ConvenioCategoriaId = Z493ConvenioCategoriaId;
                  n493ConvenioCategoriaId = false;
                  AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONVENIOCATEGORIAID");
                  AnyError = 1;
                  GX_FocusControl = edtConvenioCategoriaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtConvenioCategoriaDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1W70( ) ;
                  GX_FocusControl = edtConvenioCategoriaDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A493ConvenioCategoriaId != Z493ConvenioCategoriaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtConvenioCategoriaDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1W70( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONVENIOCATEGORIAID");
                     AnyError = 1;
                     GX_FocusControl = edtConvenioCategoriaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtConvenioCategoriaDescricao_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1W70( ) ;
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
         if ( A493ConvenioCategoriaId != Z493ConvenioCategoriaId )
         {
            A493ConvenioCategoriaId = Z493ConvenioCategoriaId;
            n493ConvenioCategoriaId = false;
            AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONVENIOCATEGORIAID");
            AnyError = 1;
            GX_FocusControl = edtConvenioCategoriaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtConvenioCategoriaDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1W70( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001W2 */
            pr_default.execute(0, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConvenioCategoria"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z494ConvenioCategoriaDescricao, T001W2_A494ConvenioCategoriaDescricao[0]) != 0 ) || ( Z495ConvenioCategoriaStatus != T001W2_A495ConvenioCategoriaStatus[0] ) || ( Z410ConvenioId != T001W2_A410ConvenioId[0] ) )
            {
               if ( StringUtil.StrCmp(Z494ConvenioCategoriaDescricao, T001W2_A494ConvenioCategoriaDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("conveniocategoria:[seudo value changed for attri]"+"ConvenioCategoriaDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z494ConvenioCategoriaDescricao);
                  GXUtil.WriteLogRaw("Current: ",T001W2_A494ConvenioCategoriaDescricao[0]);
               }
               if ( Z495ConvenioCategoriaStatus != T001W2_A495ConvenioCategoriaStatus[0] )
               {
                  GXUtil.WriteLog("conveniocategoria:[seudo value changed for attri]"+"ConvenioCategoriaStatus");
                  GXUtil.WriteLogRaw("Old: ",Z495ConvenioCategoriaStatus);
                  GXUtil.WriteLogRaw("Current: ",T001W2_A495ConvenioCategoriaStatus[0]);
               }
               if ( Z410ConvenioId != T001W2_A410ConvenioId[0] )
               {
                  GXUtil.WriteLog("conveniocategoria:[seudo value changed for attri]"+"ConvenioId");
                  GXUtil.WriteLogRaw("Old: ",Z410ConvenioId);
                  GXUtil.WriteLogRaw("Current: ",T001W2_A410ConvenioId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ConvenioCategoria"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1W70( )
      {
         BeforeValidate1W70( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W70( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1W70( 0) ;
            CheckOptimisticConcurrency1W70( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W70( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1W70( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001W10 */
                     pr_default.execute(8, new Object[] {n494ConvenioCategoriaDescricao, A494ConvenioCategoriaDescricao, n495ConvenioCategoriaStatus, A495ConvenioCategoriaStatus, n410ConvenioId, A410ConvenioId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001W11 */
                     pr_default.execute(9);
                     A493ConvenioCategoriaId = T001W11_A493ConvenioCategoriaId[0];
                     n493ConvenioCategoriaId = T001W11_n493ConvenioCategoriaId[0];
                     AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("ConvenioCategoria");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1W0( ) ;
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
               Load1W70( ) ;
            }
            EndLevel1W70( ) ;
         }
         CloseExtendedTableCursors1W70( ) ;
      }

      protected void Update1W70( )
      {
         BeforeValidate1W70( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W70( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W70( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W70( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1W70( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001W12 */
                     pr_default.execute(10, new Object[] {n494ConvenioCategoriaDescricao, A494ConvenioCategoriaDescricao, n495ConvenioCategoriaStatus, A495ConvenioCategoriaStatus, n410ConvenioId, A410ConvenioId, n493ConvenioCategoriaId, A493ConvenioCategoriaId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("ConvenioCategoria");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConvenioCategoria"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1W70( ) ;
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
            EndLevel1W70( ) ;
         }
         CloseExtendedTableCursors1W70( ) ;
      }

      protected void DeferredUpdate1W70( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1W70( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W70( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1W70( ) ;
            AfterConfirm1W70( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1W70( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001W13 */
                  pr_default.execute(11, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("ConvenioCategoria");
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
         sMode70 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1W70( ) ;
         Gx_mode = sMode70;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1W70( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001W14 */
            pr_default.execute(12, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel1W70( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1W70( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("conveniocategoria",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("conveniocategoria",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1W70( )
      {
         /* Scan By routine */
         /* Using cursor T001W15 */
         pr_default.execute(13);
         RcdFound70 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound70 = 1;
            A493ConvenioCategoriaId = T001W15_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = T001W15_n493ConvenioCategoriaId[0];
            AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1W70( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound70 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound70 = 1;
            A493ConvenioCategoriaId = T001W15_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = T001W15_n493ConvenioCategoriaId[0];
            AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
         }
      }

      protected void ScanEnd1W70( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1W70( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1W70( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1W70( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1W70( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1W70( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1W70( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1W70( )
      {
         edtConvenioCategoriaDescricao_Enabled = 0;
         AssignProp("", false, edtConvenioCategoriaDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConvenioCategoriaDescricao_Enabled), 5, 0), true);
         cmbConvenioCategoriaStatus.Enabled = 0;
         AssignProp("", false, cmbConvenioCategoriaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConvenioCategoriaStatus.Enabled), 5, 0), true);
         edtConvenioCategoriaId_Enabled = 0;
         AssignProp("", false, edtConvenioCategoriaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConvenioCategoriaId_Enabled), 5, 0), true);
         edtConvenioId_Enabled = 0;
         AssignProp("", false, edtConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConvenioId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1W70( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1W0( )
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
         GXEncryptionTmp = "conveniocategoria"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ConvenioCategoriaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13ConvenioId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("conveniocategoria") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ConvenioCategoria");
         forbiddenHiddens.Add("ConvenioCategoriaId", context.localUtil.Format( (decimal)(A493ConvenioCategoriaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ConvenioId", context.localUtil.Format( (decimal)(AV11Insert_ConvenioId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("conveniocategoria:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z493ConvenioCategoriaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z493ConvenioCategoriaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z494ConvenioCategoriaDescricao", Z494ConvenioCategoriaDescricao);
         GxWebStd.gx_boolean_hidden_field( context, "Z495ConvenioCategoriaStatus", Z495ConvenioCategoriaStatus);
         GxWebStd.gx_hidden_field( context, "Z410ConvenioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z410ConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N410ConvenioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vCONVENIOCATEGORIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ConvenioCategoriaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONVENIOCATEGORIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ConvenioCategoriaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONVENIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vCONVENIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13ConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONVENIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13ConvenioId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
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
         GXEncryptionTmp = "conveniocategoria"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ConvenioCategoriaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13ConvenioId,9,0));
         return formatLink("conveniocategoria") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ConvenioCategoria" ;
      }

      public override string GetPgmdesc( )
      {
         return "Convenio Categoria" ;
      }

      protected void InitializeNonKey1W70( )
      {
         A494ConvenioCategoriaDescricao = "";
         n494ConvenioCategoriaDescricao = false;
         AssignAttri("", false, "A494ConvenioCategoriaDescricao", A494ConvenioCategoriaDescricao);
         n494ConvenioCategoriaDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A494ConvenioCategoriaDescricao)) ? true : false);
         A410ConvenioId = AV13ConvenioId;
         n410ConvenioId = false;
         AssignAttri("", false, "A410ConvenioId", ((0==A410ConvenioId)&&IsIns( )||n410ConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ".", ""))));
         A495ConvenioCategoriaStatus = true;
         n495ConvenioCategoriaStatus = false;
         AssignAttri("", false, "A495ConvenioCategoriaStatus", A495ConvenioCategoriaStatus);
         Z494ConvenioCategoriaDescricao = "";
         Z495ConvenioCategoriaStatus = false;
         Z410ConvenioId = 0;
      }

      protected void InitAll1W70( )
      {
         A493ConvenioCategoriaId = 0;
         n493ConvenioCategoriaId = false;
         AssignAttri("", false, "A493ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(A493ConvenioCategoriaId), 9, 0));
         InitializeNonKey1W70( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A410ConvenioId = i410ConvenioId;
         n410ConvenioId = false;
         AssignAttri("", false, "A410ConvenioId", ((0==A410ConvenioId)&&IsIns( )||n410ConvenioId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ".", ""))));
         A495ConvenioCategoriaStatus = i495ConvenioCategoriaStatus;
         n495ConvenioCategoriaStatus = false;
         AssignAttri("", false, "A495ConvenioCategoriaStatus", A495ConvenioCategoriaStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019175955", true, true);
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
         context.AddJavascriptSource("conveniocategoria.js", "?202561019175955", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtConvenioCategoriaDescricao_Internalname = "CONVENIOCATEGORIADESCRICAO";
         cmbConvenioCategoriaStatus_Internalname = "CONVENIOCATEGORIASTATUS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtConvenioCategoriaId_Internalname = "CONVENIOCATEGORIAID";
         edtConvenioId_Internalname = "CONVENIOID";
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
         Form.Caption = "Convenio Categoria";
         edtConvenioId_Jsonclick = "";
         edtConvenioId_Enabled = 1;
         edtConvenioId_Visible = 1;
         edtConvenioCategoriaId_Jsonclick = "";
         edtConvenioCategoriaId_Enabled = 0;
         edtConvenioCategoriaId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbConvenioCategoriaStatus_Jsonclick = "";
         cmbConvenioCategoriaStatus.Enabled = 1;
         edtConvenioCategoriaDescricao_Jsonclick = "";
         edtConvenioCategoriaDescricao_Enabled = 1;
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
         cmbConvenioCategoriaStatus.Name = "CONVENIOCATEGORIASTATUS";
         cmbConvenioCategoriaStatus.WebTags = "";
         cmbConvenioCategoriaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbConvenioCategoriaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbConvenioCategoriaStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A495ConvenioCategoriaStatus) )
            {
               A495ConvenioCategoriaStatus = true;
               n495ConvenioCategoriaStatus = false;
               AssignAttri("", false, "A495ConvenioCategoriaStatus", A495ConvenioCategoriaStatus);
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

      public void Valid_Convenioid( )
      {
         /* Using cursor T001W16 */
         pr_default.execute(14, new Object[] {n410ConvenioId, A410ConvenioId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A410ConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'Convenio'.", "ForeignKeyNotFound", 1, "CONVENIOID");
               AnyError = 1;
               GX_FocusControl = edtConvenioId_Internalname;
            }
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ConvenioCategoriaId","fld":"vCONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV13ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7ConvenioCategoriaId","fld":"vCONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV13ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A493ConvenioCategoriaId","fld":"CONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_ConvenioId","fld":"vINSERT_CONVENIOID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121W2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"A410ConvenioId","fld":"CONVENIOID","pic":"ZZZZZZZZ9","nullAv":"n410ConvenioId","type":"int"}]}""");
         setEventMetadata("VALID_CONVENIOCATEGORIAID","""{"handler":"Valid_Conveniocategoriaid","iparms":[]}""");
         setEventMetadata("VALID_CONVENIOID","""{"handler":"Valid_Convenioid","iparms":[{"av":"A410ConvenioId","fld":"CONVENIOID","pic":"ZZZZZZZZ9","nullAv":"n410ConvenioId","type":"int"}]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z494ConvenioCategoriaDescricao = "";
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
         A494ConvenioCategoriaDescricao = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV15Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode70 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         GXEncryptionTmp = "";
         T001W5_A493ConvenioCategoriaId = new int[1] ;
         T001W5_n493ConvenioCategoriaId = new bool[] {false} ;
         T001W5_A494ConvenioCategoriaDescricao = new string[] {""} ;
         T001W5_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         T001W5_A495ConvenioCategoriaStatus = new bool[] {false} ;
         T001W5_n495ConvenioCategoriaStatus = new bool[] {false} ;
         T001W5_A410ConvenioId = new int[1] ;
         T001W5_n410ConvenioId = new bool[] {false} ;
         T001W4_A410ConvenioId = new int[1] ;
         T001W4_n410ConvenioId = new bool[] {false} ;
         T001W6_A410ConvenioId = new int[1] ;
         T001W6_n410ConvenioId = new bool[] {false} ;
         T001W7_A493ConvenioCategoriaId = new int[1] ;
         T001W7_n493ConvenioCategoriaId = new bool[] {false} ;
         T001W3_A493ConvenioCategoriaId = new int[1] ;
         T001W3_n493ConvenioCategoriaId = new bool[] {false} ;
         T001W3_A494ConvenioCategoriaDescricao = new string[] {""} ;
         T001W3_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         T001W3_A495ConvenioCategoriaStatus = new bool[] {false} ;
         T001W3_n495ConvenioCategoriaStatus = new bool[] {false} ;
         T001W3_A410ConvenioId = new int[1] ;
         T001W3_n410ConvenioId = new bool[] {false} ;
         T001W8_A493ConvenioCategoriaId = new int[1] ;
         T001W8_n493ConvenioCategoriaId = new bool[] {false} ;
         T001W9_A493ConvenioCategoriaId = new int[1] ;
         T001W9_n493ConvenioCategoriaId = new bool[] {false} ;
         T001W2_A493ConvenioCategoriaId = new int[1] ;
         T001W2_n493ConvenioCategoriaId = new bool[] {false} ;
         T001W2_A494ConvenioCategoriaDescricao = new string[] {""} ;
         T001W2_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         T001W2_A495ConvenioCategoriaStatus = new bool[] {false} ;
         T001W2_n495ConvenioCategoriaStatus = new bool[] {false} ;
         T001W2_A410ConvenioId = new int[1] ;
         T001W2_n410ConvenioId = new bool[] {false} ;
         T001W11_A493ConvenioCategoriaId = new int[1] ;
         T001W11_n493ConvenioCategoriaId = new bool[] {false} ;
         T001W14_A323PropostaId = new int[1] ;
         T001W15_A493ConvenioCategoriaId = new int[1] ;
         T001W15_n493ConvenioCategoriaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001W16_A410ConvenioId = new int[1] ;
         T001W16_n410ConvenioId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conveniocategoria__default(),
            new Object[][] {
                new Object[] {
               T001W2_A493ConvenioCategoriaId, T001W2_A494ConvenioCategoriaDescricao, T001W2_n494ConvenioCategoriaDescricao, T001W2_A495ConvenioCategoriaStatus, T001W2_n495ConvenioCategoriaStatus, T001W2_A410ConvenioId, T001W2_n410ConvenioId
               }
               , new Object[] {
               T001W3_A493ConvenioCategoriaId, T001W3_A494ConvenioCategoriaDescricao, T001W3_n494ConvenioCategoriaDescricao, T001W3_A495ConvenioCategoriaStatus, T001W3_n495ConvenioCategoriaStatus, T001W3_A410ConvenioId, T001W3_n410ConvenioId
               }
               , new Object[] {
               T001W4_A410ConvenioId
               }
               , new Object[] {
               T001W5_A493ConvenioCategoriaId, T001W5_A494ConvenioCategoriaDescricao, T001W5_n494ConvenioCategoriaDescricao, T001W5_A495ConvenioCategoriaStatus, T001W5_n495ConvenioCategoriaStatus, T001W5_A410ConvenioId, T001W5_n410ConvenioId
               }
               , new Object[] {
               T001W6_A410ConvenioId
               }
               , new Object[] {
               T001W7_A493ConvenioCategoriaId
               }
               , new Object[] {
               T001W8_A493ConvenioCategoriaId
               }
               , new Object[] {
               T001W9_A493ConvenioCategoriaId
               }
               , new Object[] {
               }
               , new Object[] {
               T001W11_A493ConvenioCategoriaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001W14_A323PropostaId
               }
               , new Object[] {
               T001W15_A493ConvenioCategoriaId
               }
               , new Object[] {
               T001W16_A410ConvenioId
               }
            }
         );
         AV15Pgmname = "ConvenioCategoria";
         Z495ConvenioCategoriaStatus = true;
         n495ConvenioCategoriaStatus = false;
         A495ConvenioCategoriaStatus = true;
         n495ConvenioCategoriaStatus = false;
         i495ConvenioCategoriaStatus = true;
         n495ConvenioCategoriaStatus = false;
         Z410ConvenioId = 0;
         n410ConvenioId = true;
         N410ConvenioId = 0;
         n410ConvenioId = true;
         i410ConvenioId = 0;
         n410ConvenioId = true;
         A410ConvenioId = 0;
         n410ConvenioId = true;
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound70 ;
      private short gxcookieaux ;
      private short gxajaxcallmode ;
      private int wcpOAV7ConvenioCategoriaId ;
      private int wcpOAV13ConvenioId ;
      private int Z493ConvenioCategoriaId ;
      private int Z410ConvenioId ;
      private int N410ConvenioId ;
      private int A410ConvenioId ;
      private int AV7ConvenioCategoriaId ;
      private int AV13ConvenioId ;
      private int trnEnded ;
      private int edtConvenioCategoriaDescricao_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A493ConvenioCategoriaId ;
      private int edtConvenioCategoriaId_Enabled ;
      private int edtConvenioCategoriaId_Visible ;
      private int edtConvenioId_Visible ;
      private int edtConvenioId_Enabled ;
      private int AV11Insert_ConvenioId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV16GXV1 ;
      private int i410ConvenioId ;
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
      private string edtConvenioCategoriaDescricao_Internalname ;
      private string cmbConvenioCategoriaStatus_Internalname ;
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
      private string edtConvenioCategoriaDescricao_Jsonclick ;
      private string cmbConvenioCategoriaStatus_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtConvenioCategoriaId_Internalname ;
      private string edtConvenioCategoriaId_Jsonclick ;
      private string edtConvenioId_Internalname ;
      private string edtConvenioId_Jsonclick ;
      private string AV15Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode70 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z495ConvenioCategoriaStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n410ConvenioId ;
      private bool wbErr ;
      private bool A495ConvenioCategoriaStatus ;
      private bool n495ConvenioCategoriaStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n493ConvenioCategoriaId ;
      private bool returnInSub ;
      private bool i495ConvenioCategoriaStatus ;
      private string Z494ConvenioCategoriaDescricao ;
      private string A494ConvenioCategoriaDescricao ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbConvenioCategoriaStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] T001W5_A493ConvenioCategoriaId ;
      private bool[] T001W5_n493ConvenioCategoriaId ;
      private string[] T001W5_A494ConvenioCategoriaDescricao ;
      private bool[] T001W5_n494ConvenioCategoriaDescricao ;
      private bool[] T001W5_A495ConvenioCategoriaStatus ;
      private bool[] T001W5_n495ConvenioCategoriaStatus ;
      private int[] T001W5_A410ConvenioId ;
      private bool[] T001W5_n410ConvenioId ;
      private int[] T001W4_A410ConvenioId ;
      private bool[] T001W4_n410ConvenioId ;
      private int[] T001W6_A410ConvenioId ;
      private bool[] T001W6_n410ConvenioId ;
      private int[] T001W7_A493ConvenioCategoriaId ;
      private bool[] T001W7_n493ConvenioCategoriaId ;
      private int[] T001W3_A493ConvenioCategoriaId ;
      private bool[] T001W3_n493ConvenioCategoriaId ;
      private string[] T001W3_A494ConvenioCategoriaDescricao ;
      private bool[] T001W3_n494ConvenioCategoriaDescricao ;
      private bool[] T001W3_A495ConvenioCategoriaStatus ;
      private bool[] T001W3_n495ConvenioCategoriaStatus ;
      private int[] T001W3_A410ConvenioId ;
      private bool[] T001W3_n410ConvenioId ;
      private int[] T001W8_A493ConvenioCategoriaId ;
      private bool[] T001W8_n493ConvenioCategoriaId ;
      private int[] T001W9_A493ConvenioCategoriaId ;
      private bool[] T001W9_n493ConvenioCategoriaId ;
      private int[] T001W2_A493ConvenioCategoriaId ;
      private bool[] T001W2_n493ConvenioCategoriaId ;
      private string[] T001W2_A494ConvenioCategoriaDescricao ;
      private bool[] T001W2_n494ConvenioCategoriaDescricao ;
      private bool[] T001W2_A495ConvenioCategoriaStatus ;
      private bool[] T001W2_n495ConvenioCategoriaStatus ;
      private int[] T001W2_A410ConvenioId ;
      private bool[] T001W2_n410ConvenioId ;
      private int[] T001W11_A493ConvenioCategoriaId ;
      private bool[] T001W11_n493ConvenioCategoriaId ;
      private int[] T001W14_A323PropostaId ;
      private int[] T001W15_A493ConvenioCategoriaId ;
      private bool[] T001W15_n493ConvenioCategoriaId ;
      private int[] T001W16_A410ConvenioId ;
      private bool[] T001W16_n410ConvenioId ;
   }

   public class conveniocategoria__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001W2;
          prmT001W2 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001W3;
          prmT001W3 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001W4;
          prmT001W4 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001W5;
          prmT001W5 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001W6;
          prmT001W6 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001W7;
          prmT001W7 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001W8;
          prmT001W8 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001W9;
          prmT001W9 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001W10;
          prmT001W10 = new Object[] {
          new ParDef("ConvenioCategoriaDescricao",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("ConvenioCategoriaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001W11;
          prmT001W11 = new Object[] {
          };
          Object[] prmT001W12;
          prmT001W12 = new Object[] {
          new ParDef("ConvenioCategoriaDescricao",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("ConvenioCategoriaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001W13;
          prmT001W13 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001W14;
          prmT001W14 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001W15;
          prmT001W15 = new Object[] {
          };
          Object[] prmT001W16;
          prmT001W16 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001W2", "SELECT ConvenioCategoriaId, ConvenioCategoriaDescricao, ConvenioCategoriaStatus, ConvenioId FROM ConvenioCategoria WHERE ConvenioCategoriaId = :ConvenioCategoriaId  FOR UPDATE OF ConvenioCategoria NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001W2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001W3", "SELECT ConvenioCategoriaId, ConvenioCategoriaDescricao, ConvenioCategoriaStatus, ConvenioId FROM ConvenioCategoria WHERE ConvenioCategoriaId = :ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001W4", "SELECT ConvenioId FROM Convenio WHERE ConvenioId = :ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001W5", "SELECT TM1.ConvenioCategoriaId, TM1.ConvenioCategoriaDescricao, TM1.ConvenioCategoriaStatus, TM1.ConvenioId FROM ConvenioCategoria TM1 WHERE TM1.ConvenioCategoriaId = :ConvenioCategoriaId ORDER BY TM1.ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001W6", "SELECT ConvenioId FROM Convenio WHERE ConvenioId = :ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001W7", "SELECT ConvenioCategoriaId FROM ConvenioCategoria WHERE ConvenioCategoriaId = :ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001W8", "SELECT ConvenioCategoriaId FROM ConvenioCategoria WHERE ( ConvenioCategoriaId > :ConvenioCategoriaId) ORDER BY ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001W9", "SELECT ConvenioCategoriaId FROM ConvenioCategoria WHERE ( ConvenioCategoriaId < :ConvenioCategoriaId) ORDER BY ConvenioCategoriaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001W10", "SAVEPOINT gxupdate;INSERT INTO ConvenioCategoria(ConvenioCategoriaDescricao, ConvenioCategoriaStatus, ConvenioId) VALUES(:ConvenioCategoriaDescricao, :ConvenioCategoriaStatus, :ConvenioId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001W10)
             ,new CursorDef("T001W11", "SELECT currval('ConvenioCategoriaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001W12", "SAVEPOINT gxupdate;UPDATE ConvenioCategoria SET ConvenioCategoriaDescricao=:ConvenioCategoriaDescricao, ConvenioCategoriaStatus=:ConvenioCategoriaStatus, ConvenioId=:ConvenioId  WHERE ConvenioCategoriaId = :ConvenioCategoriaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001W12)
             ,new CursorDef("T001W13", "SAVEPOINT gxupdate;DELETE FROM ConvenioCategoria  WHERE ConvenioCategoriaId = :ConvenioCategoriaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001W13)
             ,new CursorDef("T001W14", "SELECT PropostaId FROM Proposta WHERE ConvenioCategoriaId = :ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001W15", "SELECT ConvenioCategoriaId FROM ConvenioCategoria ORDER BY ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001W16", "SELECT ConvenioId FROM Convenio WHERE ConvenioId = :ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W16,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
