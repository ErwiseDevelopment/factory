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
   public class conta : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "conta")), "conta") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "conta")))) ;
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
                  AV7ContaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ContaId", StringUtil.LTrimStr( (decimal)(AV7ContaId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCONTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ContaId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Conta", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtContaNomeConta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public conta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ContaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ContaId = aP1_ContaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbContaStatus = new GXCombobox();
         chkContaProposta = new GXCheckbox();
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
         if ( cmbContaStatus.ItemCount > 0 )
         {
            A430ContaStatus = StringUtil.StrToBool( cmbContaStatus.getValidValue(StringUtil.BoolToStr( A430ContaStatus)));
            n430ContaStatus = false;
            AssignAttri("", false, "A430ContaStatus", A430ContaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbContaStatus.CurrentValue = StringUtil.BoolToStr( A430ContaStatus);
            AssignProp("", false, cmbContaStatus_Internalname, "Values", cmbContaStatus.ToJavascriptSource(), true);
         }
         A499ContaProposta = StringUtil.StrToBool( StringUtil.BoolToStr( A499ContaProposta));
         n499ContaProposta = false;
         AssignAttri("", false, "A499ContaProposta", A499ContaProposta);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContaNomeConta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContaNomeConta_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContaNomeConta_Internalname, A424ContaNomeConta, StringUtil.RTrim( context.localUtil.Format( A424ContaNomeConta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContaNomeConta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContaNomeConta_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Conta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbContaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbContaStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbContaStatus, cmbContaStatus_Internalname, StringUtil.BoolToStr( A430ContaStatus), 1, cmbContaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbContaStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_Conta.htm");
         cmbContaStatus.CurrentValue = StringUtil.BoolToStr( A430ContaStatus);
         AssignProp("", false, cmbContaStatus_Internalname, "Values", (string)(cmbContaStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkContaProposta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkContaProposta_Internalname, "Contra padrão para propostas", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkContaProposta_Internalname, StringUtil.BoolToStr( A499ContaProposta), "", "Contra padrão para propostas", 1, chkContaProposta.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(32, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,32);\"");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Conta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Conta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Conta.htm");
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
         GxWebStd.gx_single_line_edit( context, edtContaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtContaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A422ContaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A422ContaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContaId_Jsonclick, 0, "Attribute", "", "", "", "", edtContaId_Visible, edtContaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Conta.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContaSaldoAtual_Internalname, ((Convert.ToDecimal(0)==A423ContaSaldoAtual)&&IsIns( )||n423ContaSaldoAtual ? "" : StringUtil.LTrim( StringUtil.NToC( A423ContaSaldoAtual, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A423ContaSaldoAtual)&&IsIns( )||n423ContaSaldoAtual ? "" : StringUtil.LTrim( ((edtContaSaldoAtual_Enabled!=0) ? context.localUtil.Format( A423ContaSaldoAtual, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A423ContaSaldoAtual, "ZZZZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContaSaldoAtual_Jsonclick, 0, "Attribute", "", "", "", "", edtContaSaldoAtual_Visible, edtContaSaldoAtual_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Conta.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtContaDataUltimaAtualizacao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtContaDataUltimaAtualizacao_Internalname, context.localUtil.TToC( A425ContaDataUltimaAtualizacao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A425ContaDataUltimaAtualizacao, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContaDataUltimaAtualizacao_Jsonclick, 0, "Attribute", "", "", "", "", edtContaDataUltimaAtualizacao_Visible, edtContaDataUltimaAtualizacao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Conta.htm");
         GxWebStd.gx_bitmap( context, edtContaDataUltimaAtualizacao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtContaDataUltimaAtualizacao_Visible==0)||(edtContaDataUltimaAtualizacao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Conta.htm");
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
         E111P2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z422ContaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z425ContaDataUltimaAtualizacao = context.localUtil.CToT( cgiGet( "Z425ContaDataUltimaAtualizacao"), 0);
               n425ContaDataUltimaAtualizacao = ((DateTime.MinValue==A425ContaDataUltimaAtualizacao) ? true : false);
               Z423ContaSaldoAtual = context.localUtil.CToN( cgiGet( "Z423ContaSaldoAtual"), ",", ".");
               n423ContaSaldoAtual = ((Convert.ToDecimal(0)==A423ContaSaldoAtual) ? true : false);
               Z424ContaNomeConta = cgiGet( "Z424ContaNomeConta");
               n424ContaNomeConta = (String.IsNullOrEmpty(StringUtil.RTrim( A424ContaNomeConta)) ? true : false);
               Z430ContaStatus = StringUtil.StrToBool( cgiGet( "Z430ContaStatus"));
               n430ContaStatus = ((false==A430ContaStatus) ? true : false);
               Z499ContaProposta = StringUtil.StrToBool( cgiGet( "Z499ContaProposta"));
               n499ContaProposta = ((false==A499ContaProposta) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCONTAID"), ",", "."), 18, MidpointRounding.ToEven));
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
               A424ContaNomeConta = cgiGet( edtContaNomeConta_Internalname);
               n424ContaNomeConta = false;
               AssignAttri("", false, "A424ContaNomeConta", A424ContaNomeConta);
               n424ContaNomeConta = (String.IsNullOrEmpty(StringUtil.RTrim( A424ContaNomeConta)) ? true : false);
               cmbContaStatus.CurrentValue = cgiGet( cmbContaStatus_Internalname);
               A430ContaStatus = StringUtil.StrToBool( cgiGet( cmbContaStatus_Internalname));
               n430ContaStatus = false;
               AssignAttri("", false, "A430ContaStatus", A430ContaStatus);
               n430ContaStatus = ((false==A430ContaStatus) ? true : false);
               A499ContaProposta = StringUtil.StrToBool( cgiGet( chkContaProposta_Internalname));
               n499ContaProposta = false;
               AssignAttri("", false, "A499ContaProposta", A499ContaProposta);
               n499ContaProposta = ((false==A499ContaProposta) ? true : false);
               A422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n422ContaId = false;
               AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
               n423ContaSaldoAtual = ((StringUtil.StrCmp(cgiGet( edtContaSaldoAtual_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContaSaldoAtual_Internalname), ",", ".") < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtContaSaldoAtual_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTASALDOATUAL");
                  AnyError = 1;
                  GX_FocusControl = edtContaSaldoAtual_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A423ContaSaldoAtual = 0;
                  n423ContaSaldoAtual = false;
                  AssignAttri("", false, "A423ContaSaldoAtual", (n423ContaSaldoAtual ? "" : StringUtil.LTrim( StringUtil.NToC( A423ContaSaldoAtual, 18, 2, ".", ""))));
               }
               else
               {
                  A423ContaSaldoAtual = context.localUtil.CToN( cgiGet( edtContaSaldoAtual_Internalname), ",", ".");
                  AssignAttri("", false, "A423ContaSaldoAtual", (n423ContaSaldoAtual ? "" : StringUtil.LTrim( StringUtil.NToC( A423ContaSaldoAtual, 18, 2, ".", ""))));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtContaDataUltimaAtualizacao_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Conta Data Ultima Atualizacao"}), 1, "CONTADATAULTIMAATUALIZACAO");
                  AnyError = 1;
                  GX_FocusControl = edtContaDataUltimaAtualizacao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A425ContaDataUltimaAtualizacao = (DateTime)(DateTime.MinValue);
                  n425ContaDataUltimaAtualizacao = false;
                  AssignAttri("", false, "A425ContaDataUltimaAtualizacao", context.localUtil.TToC( A425ContaDataUltimaAtualizacao, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A425ContaDataUltimaAtualizacao = context.localUtil.CToT( cgiGet( edtContaDataUltimaAtualizacao_Internalname));
                  n425ContaDataUltimaAtualizacao = false;
                  AssignAttri("", false, "A425ContaDataUltimaAtualizacao", context.localUtil.TToC( A425ContaDataUltimaAtualizacao, 8, 5, 0, 3, "/", ":", " "));
               }
               n425ContaDataUltimaAtualizacao = ((DateTime.MinValue==A425ContaDataUltimaAtualizacao) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Conta");
               A422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n422ContaId = false;
               AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
               forbiddenHiddens.Add("ContaId", context.localUtil.Format( (decimal)(A422ContaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A422ContaId != Z422ContaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("conta:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A430ContaStatus = StringUtil.StrToBool( cgiGet( cmbContaStatus_Internalname));
                  n430ContaStatus = false;
                  AssignAttri("", false, "A430ContaStatus", A430ContaStatus);
                  forbiddenHiddens2.Add("ContaStatus", StringUtil.BoolToStr( A430ContaStatus));
               }
               hsh2 = cgiGet( "hsh2");
               if ( ( ! ( ( A422ContaId != Z422ContaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens2.ToString(), hsh2, GXKey) )
               {
                  GXUtil.WriteLogError("conta:[ CondSecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens2.ToJSonString());
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
                  A422ContaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContaId"), "."), 18, MidpointRounding.ToEven));
                  n422ContaId = false;
                  AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
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
                     sMode63 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode63;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound63 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1P0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CONTAID");
                        AnyError = 1;
                        GX_FocusControl = edtContaId_Internalname;
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
                           E111P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121P2 ();
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
            E121P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1P63( ) ;
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
            DisableAttributes1P63( ) ;
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

      protected void CONFIRM_1P0( )
      {
         BeforeValidate1P63( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1P63( ) ;
            }
            else
            {
               CheckExtendedTable1P63( ) ;
               CloseExtendedTableCursors1P63( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1P0( )
      {
      }

      protected void E111P2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtContaId_Visible = 0;
         AssignProp("", false, edtContaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtContaId_Visible), 5, 0), true);
         edtContaSaldoAtual_Visible = 0;
         AssignProp("", false, edtContaSaldoAtual_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtContaSaldoAtual_Visible), 5, 0), true);
         edtContaDataUltimaAtualizacao_Visible = 0;
         AssignProp("", false, edtContaDataUltimaAtualizacao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtContaDataUltimaAtualizacao_Visible), 5, 0), true);
      }

      protected void E121P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("contaww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1P63( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z425ContaDataUltimaAtualizacao = T001P3_A425ContaDataUltimaAtualizacao[0];
               Z423ContaSaldoAtual = T001P3_A423ContaSaldoAtual[0];
               Z424ContaNomeConta = T001P3_A424ContaNomeConta[0];
               Z430ContaStatus = T001P3_A430ContaStatus[0];
               Z499ContaProposta = T001P3_A499ContaProposta[0];
            }
            else
            {
               Z425ContaDataUltimaAtualizacao = A425ContaDataUltimaAtualizacao;
               Z423ContaSaldoAtual = A423ContaSaldoAtual;
               Z424ContaNomeConta = A424ContaNomeConta;
               Z430ContaStatus = A430ContaStatus;
               Z499ContaProposta = A499ContaProposta;
            }
         }
         if ( GX_JID == -7 )
         {
            Z422ContaId = A422ContaId;
            Z425ContaDataUltimaAtualizacao = A425ContaDataUltimaAtualizacao;
            Z423ContaSaldoAtual = A423ContaSaldoAtual;
            Z424ContaNomeConta = A424ContaNomeConta;
            Z430ContaStatus = A430ContaStatus;
            Z499ContaProposta = A499ContaProposta;
         }
      }

      protected void standaloneNotModal( )
      {
         edtContaId_Enabled = 0;
         AssignProp("", false, edtContaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtContaId_Enabled = 0;
         AssignProp("", false, edtContaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ContaId) )
         {
            A422ContaId = AV7ContaId;
            n422ContaId = false;
            AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            cmbContaStatus.Enabled = 0;
            AssignProp("", false, cmbContaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbContaStatus.Enabled), 5, 0), true);
         }
         else
         {
            cmbContaStatus.Enabled = 1;
            AssignProp("", false, cmbContaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbContaStatus.Enabled), 5, 0), true);
         }
         A425ContaDataUltimaAtualizacao = DateTimeUtil.ServerNow( context, pr_default);
         n425ContaDataUltimaAtualizacao = false;
         AssignAttri("", false, "A425ContaDataUltimaAtualizacao", context.localUtil.TToC( A425ContaDataUltimaAtualizacao, 8, 5, 0, 3, "/", ":", " "));
         if ( IsIns( )  )
         {
            cmbContaStatus.Enabled = 0;
            AssignProp("", false, cmbContaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbContaStatus.Enabled), 5, 0), true);
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
         if ( IsIns( )  && (false==A430ContaStatus) && ( Gx_BScreen == 0 ) )
         {
            A430ContaStatus = true;
            n430ContaStatus = false;
            AssignAttri("", false, "A430ContaStatus", A430ContaStatus);
         }
      }

      protected void Load1P63( )
      {
         /* Using cursor T001P4 */
         pr_default.execute(2, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound63 = 1;
            A425ContaDataUltimaAtualizacao = T001P4_A425ContaDataUltimaAtualizacao[0];
            n425ContaDataUltimaAtualizacao = T001P4_n425ContaDataUltimaAtualizacao[0];
            AssignAttri("", false, "A425ContaDataUltimaAtualizacao", context.localUtil.TToC( A425ContaDataUltimaAtualizacao, 8, 5, 0, 3, "/", ":", " "));
            A423ContaSaldoAtual = T001P4_A423ContaSaldoAtual[0];
            n423ContaSaldoAtual = T001P4_n423ContaSaldoAtual[0];
            AssignAttri("", false, "A423ContaSaldoAtual", ((Convert.ToDecimal(0)==A423ContaSaldoAtual)&&IsIns( )||n423ContaSaldoAtual ? "" : StringUtil.LTrim( StringUtil.NToC( A423ContaSaldoAtual, 18, 2, ".", ""))));
            A424ContaNomeConta = T001P4_A424ContaNomeConta[0];
            n424ContaNomeConta = T001P4_n424ContaNomeConta[0];
            AssignAttri("", false, "A424ContaNomeConta", A424ContaNomeConta);
            A430ContaStatus = T001P4_A430ContaStatus[0];
            n430ContaStatus = T001P4_n430ContaStatus[0];
            AssignAttri("", false, "A430ContaStatus", A430ContaStatus);
            A499ContaProposta = T001P4_A499ContaProposta[0];
            n499ContaProposta = T001P4_n499ContaProposta[0];
            AssignAttri("", false, "A499ContaProposta", A499ContaProposta);
            ZM1P63( -7) ;
         }
         pr_default.close(2);
         OnLoadActions1P63( ) ;
      }

      protected void OnLoadActions1P63( )
      {
      }

      protected void CheckExtendedTable1P63( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1P63( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1P63( )
      {
         /* Using cursor T001P5 */
         pr_default.execute(3, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound63 = 1;
         }
         else
         {
            RcdFound63 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001P3 */
         pr_default.execute(1, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1P63( 7) ;
            RcdFound63 = 1;
            A422ContaId = T001P3_A422ContaId[0];
            n422ContaId = T001P3_n422ContaId[0];
            AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
            A425ContaDataUltimaAtualizacao = T001P3_A425ContaDataUltimaAtualizacao[0];
            n425ContaDataUltimaAtualizacao = T001P3_n425ContaDataUltimaAtualizacao[0];
            AssignAttri("", false, "A425ContaDataUltimaAtualizacao", context.localUtil.TToC( A425ContaDataUltimaAtualizacao, 8, 5, 0, 3, "/", ":", " "));
            A423ContaSaldoAtual = T001P3_A423ContaSaldoAtual[0];
            n423ContaSaldoAtual = T001P3_n423ContaSaldoAtual[0];
            AssignAttri("", false, "A423ContaSaldoAtual", ((Convert.ToDecimal(0)==A423ContaSaldoAtual)&&IsIns( )||n423ContaSaldoAtual ? "" : StringUtil.LTrim( StringUtil.NToC( A423ContaSaldoAtual, 18, 2, ".", ""))));
            A424ContaNomeConta = T001P3_A424ContaNomeConta[0];
            n424ContaNomeConta = T001P3_n424ContaNomeConta[0];
            AssignAttri("", false, "A424ContaNomeConta", A424ContaNomeConta);
            A430ContaStatus = T001P3_A430ContaStatus[0];
            n430ContaStatus = T001P3_n430ContaStatus[0];
            AssignAttri("", false, "A430ContaStatus", A430ContaStatus);
            A499ContaProposta = T001P3_A499ContaProposta[0];
            n499ContaProposta = T001P3_n499ContaProposta[0];
            AssignAttri("", false, "A499ContaProposta", A499ContaProposta);
            Z422ContaId = A422ContaId;
            sMode63 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1P63( ) ;
            if ( AnyError == 1 )
            {
               RcdFound63 = 0;
               InitializeNonKey1P63( ) ;
            }
            Gx_mode = sMode63;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound63 = 0;
            InitializeNonKey1P63( ) ;
            sMode63 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode63;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1P63( ) ;
         if ( RcdFound63 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound63 = 0;
         /* Using cursor T001P6 */
         pr_default.execute(4, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001P6_A422ContaId[0] < A422ContaId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001P6_A422ContaId[0] > A422ContaId ) ) )
            {
               A422ContaId = T001P6_A422ContaId[0];
               n422ContaId = T001P6_n422ContaId[0];
               AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
               RcdFound63 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound63 = 0;
         /* Using cursor T001P7 */
         pr_default.execute(5, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001P7_A422ContaId[0] > A422ContaId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001P7_A422ContaId[0] < A422ContaId ) ) )
            {
               A422ContaId = T001P7_A422ContaId[0];
               n422ContaId = T001P7_n422ContaId[0];
               AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
               RcdFound63 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1P63( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtContaNomeConta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1P63( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound63 == 1 )
            {
               if ( A422ContaId != Z422ContaId )
               {
                  A422ContaId = Z422ContaId;
                  n422ContaId = false;
                  AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONTAID");
                  AnyError = 1;
                  GX_FocusControl = edtContaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtContaNomeConta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1P63( ) ;
                  GX_FocusControl = edtContaNomeConta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A422ContaId != Z422ContaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtContaNomeConta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1P63( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONTAID");
                     AnyError = 1;
                     GX_FocusControl = edtContaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtContaNomeConta_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1P63( ) ;
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
         if ( A422ContaId != Z422ContaId )
         {
            A422ContaId = Z422ContaId;
            n422ContaId = false;
            AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONTAID");
            AnyError = 1;
            GX_FocusControl = edtContaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtContaNomeConta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1P63( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001P2 */
            pr_default.execute(0, new Object[] {n422ContaId, A422ContaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Conta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z425ContaDataUltimaAtualizacao != T001P2_A425ContaDataUltimaAtualizacao[0] ) || ( Z423ContaSaldoAtual != T001P2_A423ContaSaldoAtual[0] ) || ( StringUtil.StrCmp(Z424ContaNomeConta, T001P2_A424ContaNomeConta[0]) != 0 ) || ( Z430ContaStatus != T001P2_A430ContaStatus[0] ) || ( Z499ContaProposta != T001P2_A499ContaProposta[0] ) )
            {
               if ( Z425ContaDataUltimaAtualizacao != T001P2_A425ContaDataUltimaAtualizacao[0] )
               {
                  GXUtil.WriteLog("conta:[seudo value changed for attri]"+"ContaDataUltimaAtualizacao");
                  GXUtil.WriteLogRaw("Old: ",Z425ContaDataUltimaAtualizacao);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A425ContaDataUltimaAtualizacao[0]);
               }
               if ( Z423ContaSaldoAtual != T001P2_A423ContaSaldoAtual[0] )
               {
                  GXUtil.WriteLog("conta:[seudo value changed for attri]"+"ContaSaldoAtual");
                  GXUtil.WriteLogRaw("Old: ",Z423ContaSaldoAtual);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A423ContaSaldoAtual[0]);
               }
               if ( StringUtil.StrCmp(Z424ContaNomeConta, T001P2_A424ContaNomeConta[0]) != 0 )
               {
                  GXUtil.WriteLog("conta:[seudo value changed for attri]"+"ContaNomeConta");
                  GXUtil.WriteLogRaw("Old: ",Z424ContaNomeConta);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A424ContaNomeConta[0]);
               }
               if ( Z430ContaStatus != T001P2_A430ContaStatus[0] )
               {
                  GXUtil.WriteLog("conta:[seudo value changed for attri]"+"ContaStatus");
                  GXUtil.WriteLogRaw("Old: ",Z430ContaStatus);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A430ContaStatus[0]);
               }
               if ( Z499ContaProposta != T001P2_A499ContaProposta[0] )
               {
                  GXUtil.WriteLog("conta:[seudo value changed for attri]"+"ContaProposta");
                  GXUtil.WriteLogRaw("Old: ",Z499ContaProposta);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A499ContaProposta[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Conta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1P63( )
      {
         BeforeValidate1P63( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1P63( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1P63( 0) ;
            CheckOptimisticConcurrency1P63( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1P63( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1P63( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001P8 */
                     pr_default.execute(6, new Object[] {n425ContaDataUltimaAtualizacao, A425ContaDataUltimaAtualizacao, n423ContaSaldoAtual, A423ContaSaldoAtual, n424ContaNomeConta, A424ContaNomeConta, n430ContaStatus, A430ContaStatus, n499ContaProposta, A499ContaProposta});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001P9 */
                     pr_default.execute(7);
                     A422ContaId = T001P9_A422ContaId[0];
                     n422ContaId = T001P9_n422ContaId[0];
                     AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Conta");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1P0( ) ;
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
               Load1P63( ) ;
            }
            EndLevel1P63( ) ;
         }
         CloseExtendedTableCursors1P63( ) ;
      }

      protected void Update1P63( )
      {
         BeforeValidate1P63( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1P63( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1P63( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1P63( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1P63( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001P10 */
                     pr_default.execute(8, new Object[] {n425ContaDataUltimaAtualizacao, A425ContaDataUltimaAtualizacao, n423ContaSaldoAtual, A423ContaSaldoAtual, n424ContaNomeConta, A424ContaNomeConta, n430ContaStatus, A430ContaStatus, n499ContaProposta, A499ContaProposta, n422ContaId, A422ContaId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Conta");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Conta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1P63( ) ;
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
            EndLevel1P63( ) ;
         }
         CloseExtendedTableCursors1P63( ) ;
      }

      protected void DeferredUpdate1P63( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1P63( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1P63( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1P63( ) ;
            AfterConfirm1P63( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1P63( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001P11 */
                  pr_default.execute(9, new Object[] {n422ContaId, A422ContaId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Conta");
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
         sMode63 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1P63( ) ;
         Gx_mode = sMode63;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1P63( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001P12 */
            pr_default.execute(10, new Object[] {n422ContaId, A422ContaId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TituloMovimento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T001P13 */
            pr_default.execute(11, new Object[] {n422ContaId, A422ContaId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel1P63( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1P63( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("conta",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("conta",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1P63( )
      {
         /* Scan By routine */
         /* Using cursor T001P14 */
         pr_default.execute(12);
         RcdFound63 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound63 = 1;
            A422ContaId = T001P14_A422ContaId[0];
            n422ContaId = T001P14_n422ContaId[0];
            AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1P63( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound63 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound63 = 1;
            A422ContaId = T001P14_A422ContaId[0];
            n422ContaId = T001P14_n422ContaId[0];
            AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
         }
      }

      protected void ScanEnd1P63( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1P63( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1P63( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1P63( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1P63( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1P63( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1P63( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1P63( )
      {
         edtContaNomeConta_Enabled = 0;
         AssignProp("", false, edtContaNomeConta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaNomeConta_Enabled), 5, 0), true);
         cmbContaStatus.Enabled = 0;
         AssignProp("", false, cmbContaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbContaStatus.Enabled), 5, 0), true);
         chkContaProposta.Enabled = 0;
         AssignProp("", false, chkContaProposta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkContaProposta.Enabled), 5, 0), true);
         edtContaId_Enabled = 0;
         AssignProp("", false, edtContaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaId_Enabled), 5, 0), true);
         edtContaSaldoAtual_Enabled = 0;
         AssignProp("", false, edtContaSaldoAtual_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaSaldoAtual_Enabled), 5, 0), true);
         edtContaDataUltimaAtualizacao_Enabled = 0;
         AssignProp("", false, edtContaDataUltimaAtualizacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContaDataUltimaAtualizacao_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1P63( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1P0( )
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
         GXEncryptionTmp = "conta"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ContaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("conta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Conta");
         forbiddenHiddens.Add("ContaId", context.localUtil.Format( (decimal)(A422ContaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("conta:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         forbiddenHiddens2 = new GXProperties();
         if ( IsIns( )  )
         {
            forbiddenHiddens2.Add("ContaStatus", StringUtil.BoolToStr( A430ContaStatus));
         }
         GxWebStd.gx_hidden_field( context, "hsh2", GetEncryptedHash( forbiddenHiddens2.ToString(), GXKey));
         GXUtil.WriteLogInfo("conta:[ SendCondSecurityCheck value for]"+forbiddenHiddens2.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z422ContaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z422ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z425ContaDataUltimaAtualizacao", context.localUtil.TToC( Z425ContaDataUltimaAtualizacao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z423ContaSaldoAtual", StringUtil.LTrim( StringUtil.NToC( Z423ContaSaldoAtual, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z424ContaNomeConta", Z424ContaNomeConta);
         GxWebStd.gx_boolean_hidden_field( context, "Z430ContaStatus", Z430ContaStatus);
         GxWebStd.gx_boolean_hidden_field( context, "Z499ContaProposta", Z499ContaProposta);
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
         GxWebStd.gx_hidden_field( context, "vCONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ContaId), "ZZZZZZZZ9"), context));
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
         GXEncryptionTmp = "conta"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ContaId,9,0));
         return formatLink("conta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Conta" ;
      }

      public override string GetPgmdesc( )
      {
         return "Conta" ;
      }

      protected void InitializeNonKey1P63( )
      {
         A425ContaDataUltimaAtualizacao = (DateTime)(DateTime.MinValue);
         n425ContaDataUltimaAtualizacao = false;
         AssignAttri("", false, "A425ContaDataUltimaAtualizacao", context.localUtil.TToC( A425ContaDataUltimaAtualizacao, 8, 5, 0, 3, "/", ":", " "));
         n425ContaDataUltimaAtualizacao = ((DateTime.MinValue==A425ContaDataUltimaAtualizacao) ? true : false);
         A423ContaSaldoAtual = 0;
         n423ContaSaldoAtual = false;
         AssignAttri("", false, "A423ContaSaldoAtual", ((Convert.ToDecimal(0)==A423ContaSaldoAtual)&&IsIns( )||n423ContaSaldoAtual ? "" : StringUtil.LTrim( StringUtil.NToC( A423ContaSaldoAtual, 18, 2, ".", ""))));
         n423ContaSaldoAtual = ((Convert.ToDecimal(0)==A423ContaSaldoAtual) ? true : false);
         A424ContaNomeConta = "";
         n424ContaNomeConta = false;
         AssignAttri("", false, "A424ContaNomeConta", A424ContaNomeConta);
         n424ContaNomeConta = (String.IsNullOrEmpty(StringUtil.RTrim( A424ContaNomeConta)) ? true : false);
         A499ContaProposta = false;
         n499ContaProposta = false;
         AssignAttri("", false, "A499ContaProposta", A499ContaProposta);
         n499ContaProposta = ((false==A499ContaProposta) ? true : false);
         A430ContaStatus = true;
         n430ContaStatus = false;
         AssignAttri("", false, "A430ContaStatus", A430ContaStatus);
         Z425ContaDataUltimaAtualizacao = (DateTime)(DateTime.MinValue);
         Z423ContaSaldoAtual = 0;
         Z424ContaNomeConta = "";
         Z430ContaStatus = false;
         Z499ContaProposta = false;
      }

      protected void InitAll1P63( )
      {
         A422ContaId = 0;
         n422ContaId = false;
         AssignAttri("", false, "A422ContaId", StringUtil.LTrimStr( (decimal)(A422ContaId), 9, 0));
         InitializeNonKey1P63( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A425ContaDataUltimaAtualizacao = i425ContaDataUltimaAtualizacao;
         n425ContaDataUltimaAtualizacao = false;
         AssignAttri("", false, "A425ContaDataUltimaAtualizacao", context.localUtil.TToC( A425ContaDataUltimaAtualizacao, 8, 5, 0, 3, "/", ":", " "));
         A430ContaStatus = i430ContaStatus;
         n430ContaStatus = false;
         AssignAttri("", false, "A430ContaStatus", A430ContaStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019165522", true, true);
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
         context.AddJavascriptSource("conta.js", "?202561019165522", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtContaNomeConta_Internalname = "CONTANOMECONTA";
         cmbContaStatus_Internalname = "CONTASTATUS";
         chkContaProposta_Internalname = "CONTAPROPOSTA";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtContaId_Internalname = "CONTAID";
         edtContaSaldoAtual_Internalname = "CONTASALDOATUAL";
         edtContaDataUltimaAtualizacao_Internalname = "CONTADATAULTIMAATUALIZACAO";
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
         Form.Caption = "Conta";
         edtContaDataUltimaAtualizacao_Jsonclick = "";
         edtContaDataUltimaAtualizacao_Enabled = 1;
         edtContaDataUltimaAtualizacao_Visible = 1;
         edtContaSaldoAtual_Jsonclick = "";
         edtContaSaldoAtual_Enabled = 1;
         edtContaSaldoAtual_Visible = 1;
         edtContaId_Jsonclick = "";
         edtContaId_Enabled = 0;
         edtContaId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkContaProposta.Enabled = 1;
         cmbContaStatus_Jsonclick = "";
         cmbContaStatus.Enabled = 1;
         edtContaNomeConta_Jsonclick = "";
         edtContaNomeConta_Enabled = 1;
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
         cmbContaStatus.Name = "CONTASTATUS";
         cmbContaStatus.WebTags = "";
         cmbContaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbContaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbContaStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A430ContaStatus) )
            {
               A430ContaStatus = true;
               n430ContaStatus = false;
               AssignAttri("", false, "A430ContaStatus", A430ContaStatus);
            }
         }
         chkContaProposta.Name = "CONTAPROPOSTA";
         chkContaProposta.WebTags = "";
         chkContaProposta.Caption = "Contra padrão para propostas";
         AssignProp("", false, chkContaProposta_Internalname, "TitleCaption", chkContaProposta.Caption, true);
         chkContaProposta.CheckedValue = "false";
         A499ContaProposta = StringUtil.StrToBool( StringUtil.BoolToStr( A499ContaProposta));
         n499ContaProposta = false;
         AssignAttri("", false, "A499ContaProposta", A499ContaProposta);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ContaId","fld":"vCONTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A499ContaProposta","fld":"CONTAPROPOSTA","type":"boolean"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A499ContaProposta","fld":"CONTAPROPOSTA","type":"boolean"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7ContaId","fld":"vCONTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A422ContaId","fld":"CONTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A499ContaProposta","fld":"CONTAPROPOSTA","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A499ContaProposta","fld":"CONTAPROPOSTA","type":"boolean"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121P2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"A499ContaProposta","fld":"CONTAPROPOSTA","type":"boolean"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A499ContaProposta","fld":"CONTAPROPOSTA","type":"boolean"}]}""");
         setEventMetadata("VALID_CONTAID","""{"handler":"Valid_Contaid","iparms":[{"av":"A499ContaProposta","fld":"CONTAPROPOSTA","type":"boolean"}]""");
         setEventMetadata("VALID_CONTAID",""","oparms":[{"av":"A499ContaProposta","fld":"CONTAPROPOSTA","type":"boolean"}]}""");
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
         Z425ContaDataUltimaAtualizacao = (DateTime)(DateTime.MinValue);
         Z424ContaNomeConta = "";
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
         A424ContaNomeConta = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A425ContaDataUltimaAtualizacao = (DateTime)(DateTime.MinValue);
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         forbiddenHiddens2 = new GXProperties();
         hsh2 = "";
         sMode63 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T001P4_A422ContaId = new int[1] ;
         T001P4_n422ContaId = new bool[] {false} ;
         T001P4_A425ContaDataUltimaAtualizacao = new DateTime[] {DateTime.MinValue} ;
         T001P4_n425ContaDataUltimaAtualizacao = new bool[] {false} ;
         T001P4_A423ContaSaldoAtual = new decimal[1] ;
         T001P4_n423ContaSaldoAtual = new bool[] {false} ;
         T001P4_A424ContaNomeConta = new string[] {""} ;
         T001P4_n424ContaNomeConta = new bool[] {false} ;
         T001P4_A430ContaStatus = new bool[] {false} ;
         T001P4_n430ContaStatus = new bool[] {false} ;
         T001P4_A499ContaProposta = new bool[] {false} ;
         T001P4_n499ContaProposta = new bool[] {false} ;
         T001P5_A422ContaId = new int[1] ;
         T001P5_n422ContaId = new bool[] {false} ;
         T001P3_A422ContaId = new int[1] ;
         T001P3_n422ContaId = new bool[] {false} ;
         T001P3_A425ContaDataUltimaAtualizacao = new DateTime[] {DateTime.MinValue} ;
         T001P3_n425ContaDataUltimaAtualizacao = new bool[] {false} ;
         T001P3_A423ContaSaldoAtual = new decimal[1] ;
         T001P3_n423ContaSaldoAtual = new bool[] {false} ;
         T001P3_A424ContaNomeConta = new string[] {""} ;
         T001P3_n424ContaNomeConta = new bool[] {false} ;
         T001P3_A430ContaStatus = new bool[] {false} ;
         T001P3_n430ContaStatus = new bool[] {false} ;
         T001P3_A499ContaProposta = new bool[] {false} ;
         T001P3_n499ContaProposta = new bool[] {false} ;
         T001P6_A422ContaId = new int[1] ;
         T001P6_n422ContaId = new bool[] {false} ;
         T001P7_A422ContaId = new int[1] ;
         T001P7_n422ContaId = new bool[] {false} ;
         T001P2_A422ContaId = new int[1] ;
         T001P2_n422ContaId = new bool[] {false} ;
         T001P2_A425ContaDataUltimaAtualizacao = new DateTime[] {DateTime.MinValue} ;
         T001P2_n425ContaDataUltimaAtualizacao = new bool[] {false} ;
         T001P2_A423ContaSaldoAtual = new decimal[1] ;
         T001P2_n423ContaSaldoAtual = new bool[] {false} ;
         T001P2_A424ContaNomeConta = new string[] {""} ;
         T001P2_n424ContaNomeConta = new bool[] {false} ;
         T001P2_A430ContaStatus = new bool[] {false} ;
         T001P2_n430ContaStatus = new bool[] {false} ;
         T001P2_A499ContaProposta = new bool[] {false} ;
         T001P2_n499ContaProposta = new bool[] {false} ;
         T001P9_A422ContaId = new int[1] ;
         T001P9_n422ContaId = new bool[] {false} ;
         T001P12_A270TituloMovimentoId = new int[1] ;
         T001P13_A261TituloId = new int[1] ;
         T001P14_A422ContaId = new int[1] ;
         T001P14_n422ContaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i425ContaDataUltimaAtualizacao = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conta__default(),
            new Object[][] {
                new Object[] {
               T001P2_A422ContaId, T001P2_A425ContaDataUltimaAtualizacao, T001P2_n425ContaDataUltimaAtualizacao, T001P2_A423ContaSaldoAtual, T001P2_n423ContaSaldoAtual, T001P2_A424ContaNomeConta, T001P2_n424ContaNomeConta, T001P2_A430ContaStatus, T001P2_n430ContaStatus, T001P2_A499ContaProposta,
               T001P2_n499ContaProposta
               }
               , new Object[] {
               T001P3_A422ContaId, T001P3_A425ContaDataUltimaAtualizacao, T001P3_n425ContaDataUltimaAtualizacao, T001P3_A423ContaSaldoAtual, T001P3_n423ContaSaldoAtual, T001P3_A424ContaNomeConta, T001P3_n424ContaNomeConta, T001P3_A430ContaStatus, T001P3_n430ContaStatus, T001P3_A499ContaProposta,
               T001P3_n499ContaProposta
               }
               , new Object[] {
               T001P4_A422ContaId, T001P4_A425ContaDataUltimaAtualizacao, T001P4_n425ContaDataUltimaAtualizacao, T001P4_A423ContaSaldoAtual, T001P4_n423ContaSaldoAtual, T001P4_A424ContaNomeConta, T001P4_n424ContaNomeConta, T001P4_A430ContaStatus, T001P4_n430ContaStatus, T001P4_A499ContaProposta,
               T001P4_n499ContaProposta
               }
               , new Object[] {
               T001P5_A422ContaId
               }
               , new Object[] {
               T001P6_A422ContaId
               }
               , new Object[] {
               T001P7_A422ContaId
               }
               , new Object[] {
               }
               , new Object[] {
               T001P9_A422ContaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001P12_A270TituloMovimentoId
               }
               , new Object[] {
               T001P13_A261TituloId
               }
               , new Object[] {
               T001P14_A422ContaId
               }
            }
         );
         Z430ContaStatus = true;
         n430ContaStatus = false;
         A430ContaStatus = true;
         n430ContaStatus = false;
         i430ContaStatus = true;
         n430ContaStatus = false;
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound63 ;
      private short gxajaxcallmode ;
      private int wcpOAV7ContaId ;
      private int Z422ContaId ;
      private int AV7ContaId ;
      private int trnEnded ;
      private int edtContaNomeConta_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A422ContaId ;
      private int edtContaId_Enabled ;
      private int edtContaId_Visible ;
      private int edtContaSaldoAtual_Enabled ;
      private int edtContaSaldoAtual_Visible ;
      private int edtContaDataUltimaAtualizacao_Visible ;
      private int edtContaDataUltimaAtualizacao_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private decimal Z423ContaSaldoAtual ;
      private decimal A423ContaSaldoAtual ;
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
      private string edtContaNomeConta_Internalname ;
      private string cmbContaStatus_Internalname ;
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
      private string edtContaNomeConta_Jsonclick ;
      private string cmbContaStatus_Jsonclick ;
      private string chkContaProposta_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtContaId_Internalname ;
      private string edtContaId_Jsonclick ;
      private string edtContaSaldoAtual_Internalname ;
      private string edtContaSaldoAtual_Jsonclick ;
      private string edtContaDataUltimaAtualizacao_Internalname ;
      private string edtContaDataUltimaAtualizacao_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string hsh2 ;
      private string sMode63 ;
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
      private DateTime Z425ContaDataUltimaAtualizacao ;
      private DateTime A425ContaDataUltimaAtualizacao ;
      private DateTime i425ContaDataUltimaAtualizacao ;
      private bool Z430ContaStatus ;
      private bool Z499ContaProposta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A430ContaStatus ;
      private bool n430ContaStatus ;
      private bool A499ContaProposta ;
      private bool n499ContaProposta ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n423ContaSaldoAtual ;
      private bool n425ContaDataUltimaAtualizacao ;
      private bool n424ContaNomeConta ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n422ContaId ;
      private bool returnInSub ;
      private bool i430ContaStatus ;
      private string Z424ContaNomeConta ;
      private string A424ContaNomeConta ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXProperties forbiddenHiddens2 ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbContaStatus ;
      private GXCheckbox chkContaProposta ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] T001P4_A422ContaId ;
      private bool[] T001P4_n422ContaId ;
      private DateTime[] T001P4_A425ContaDataUltimaAtualizacao ;
      private bool[] T001P4_n425ContaDataUltimaAtualizacao ;
      private decimal[] T001P4_A423ContaSaldoAtual ;
      private bool[] T001P4_n423ContaSaldoAtual ;
      private string[] T001P4_A424ContaNomeConta ;
      private bool[] T001P4_n424ContaNomeConta ;
      private bool[] T001P4_A430ContaStatus ;
      private bool[] T001P4_n430ContaStatus ;
      private bool[] T001P4_A499ContaProposta ;
      private bool[] T001P4_n499ContaProposta ;
      private int[] T001P5_A422ContaId ;
      private bool[] T001P5_n422ContaId ;
      private int[] T001P3_A422ContaId ;
      private bool[] T001P3_n422ContaId ;
      private DateTime[] T001P3_A425ContaDataUltimaAtualizacao ;
      private bool[] T001P3_n425ContaDataUltimaAtualizacao ;
      private decimal[] T001P3_A423ContaSaldoAtual ;
      private bool[] T001P3_n423ContaSaldoAtual ;
      private string[] T001P3_A424ContaNomeConta ;
      private bool[] T001P3_n424ContaNomeConta ;
      private bool[] T001P3_A430ContaStatus ;
      private bool[] T001P3_n430ContaStatus ;
      private bool[] T001P3_A499ContaProposta ;
      private bool[] T001P3_n499ContaProposta ;
      private int[] T001P6_A422ContaId ;
      private bool[] T001P6_n422ContaId ;
      private int[] T001P7_A422ContaId ;
      private bool[] T001P7_n422ContaId ;
      private int[] T001P2_A422ContaId ;
      private bool[] T001P2_n422ContaId ;
      private DateTime[] T001P2_A425ContaDataUltimaAtualizacao ;
      private bool[] T001P2_n425ContaDataUltimaAtualizacao ;
      private decimal[] T001P2_A423ContaSaldoAtual ;
      private bool[] T001P2_n423ContaSaldoAtual ;
      private string[] T001P2_A424ContaNomeConta ;
      private bool[] T001P2_n424ContaNomeConta ;
      private bool[] T001P2_A430ContaStatus ;
      private bool[] T001P2_n430ContaStatus ;
      private bool[] T001P2_A499ContaProposta ;
      private bool[] T001P2_n499ContaProposta ;
      private int[] T001P9_A422ContaId ;
      private bool[] T001P9_n422ContaId ;
      private int[] T001P12_A270TituloMovimentoId ;
      private int[] T001P13_A261TituloId ;
      private int[] T001P14_A422ContaId ;
      private bool[] T001P14_n422ContaId ;
   }

   public class conta__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT001P2;
          prmT001P2 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001P3;
          prmT001P3 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001P4;
          prmT001P4 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001P5;
          prmT001P5 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001P6;
          prmT001P6 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001P7;
          prmT001P7 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001P8;
          prmT001P8 = new Object[] {
          new ParDef("ContaDataUltimaAtualizacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaSaldoAtual",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ContaNomeConta",GXType.VarChar,60,2){Nullable=true} ,
          new ParDef("ContaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaProposta",GXType.Boolean,4,0){Nullable=true}
          };
          Object[] prmT001P9;
          prmT001P9 = new Object[] {
          };
          Object[] prmT001P10;
          prmT001P10 = new Object[] {
          new ParDef("ContaDataUltimaAtualizacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaSaldoAtual",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ContaNomeConta",GXType.VarChar,60,2){Nullable=true} ,
          new ParDef("ContaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaProposta",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001P11;
          prmT001P11 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001P12;
          prmT001P12 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001P13;
          prmT001P13 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001P14;
          prmT001P14 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T001P2", "SELECT ContaId, ContaDataUltimaAtualizacao, ContaSaldoAtual, ContaNomeConta, ContaStatus, ContaProposta FROM Conta WHERE ContaId = :ContaId  FOR UPDATE OF Conta NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001P2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001P3", "SELECT ContaId, ContaDataUltimaAtualizacao, ContaSaldoAtual, ContaNomeConta, ContaStatus, ContaProposta FROM Conta WHERE ContaId = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001P4", "SELECT TM1.ContaId, TM1.ContaDataUltimaAtualizacao, TM1.ContaSaldoAtual, TM1.ContaNomeConta, TM1.ContaStatus, TM1.ContaProposta FROM Conta TM1 WHERE TM1.ContaId = :ContaId ORDER BY TM1.ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001P5", "SELECT ContaId FROM Conta WHERE ContaId = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001P6", "SELECT ContaId FROM Conta WHERE ( ContaId > :ContaId) ORDER BY ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001P7", "SELECT ContaId FROM Conta WHERE ( ContaId < :ContaId) ORDER BY ContaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001P8", "SAVEPOINT gxupdate;INSERT INTO Conta(ContaDataUltimaAtualizacao, ContaSaldoAtual, ContaNomeConta, ContaStatus, ContaProposta) VALUES(:ContaDataUltimaAtualizacao, :ContaSaldoAtual, :ContaNomeConta, :ContaStatus, :ContaProposta);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001P8)
             ,new CursorDef("T001P9", "SELECT currval('ContaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001P10", "SAVEPOINT gxupdate;UPDATE Conta SET ContaDataUltimaAtualizacao=:ContaDataUltimaAtualizacao, ContaSaldoAtual=:ContaSaldoAtual, ContaNomeConta=:ContaNomeConta, ContaStatus=:ContaStatus, ContaProposta=:ContaProposta  WHERE ContaId = :ContaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001P10)
             ,new CursorDef("T001P11", "SAVEPOINT gxupdate;DELETE FROM Conta  WHERE ContaId = :ContaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001P11)
             ,new CursorDef("T001P12", "SELECT TituloMovimentoId FROM TituloMovimento WHERE TituloMovimentoConta = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001P13", "SELECT TituloId FROM Titulo WHERE ContaId = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001P14", "SELECT ContaId FROM Conta ORDER BY ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P14,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
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
