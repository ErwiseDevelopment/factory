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
   public class convenio : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "convenio")), "convenio") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "convenio")))) ;
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
                  AV7ConvenioId = (int)(Math.Round(NumberUtil.Val( GetPar( "ConvenioId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ConvenioId", StringUtil.LTrimStr( (decimal)(AV7ConvenioId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCONVENIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ConvenioId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Convenio", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtConvenioDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public convenio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public convenio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ConvenioId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ConvenioId = aP1_ConvenioId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbConvenioStatus = new GXCombobox();
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
         if ( cmbConvenioStatus.ItemCount > 0 )
         {
            A412ConvenioStatus = StringUtil.StrToBool( cmbConvenioStatus.getValidValue(StringUtil.BoolToStr( A412ConvenioStatus)));
            AssignAttri("", false, "A412ConvenioStatus", A412ConvenioStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConvenioStatus.CurrentValue = StringUtil.BoolToStr( A412ConvenioStatus);
            AssignProp("", false, cmbConvenioStatus_Internalname, "Values", cmbConvenioStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtConvenioDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConvenioDescricao_Internalname, "Descricao", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConvenioDescricao_Internalname, A411ConvenioDescricao, StringUtil.RTrim( context.localUtil.Format( A411ConvenioDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConvenioDescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtConvenioDescricao_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Convenio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbConvenioStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbConvenioStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConvenioStatus, cmbConvenioStatus_Internalname, StringUtil.BoolToStr( A412ConvenioStatus), 1, cmbConvenioStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbConvenioStatus.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Convenio.htm");
         cmbConvenioStatus.CurrentValue = StringUtil.BoolToStr( A412ConvenioStatus);
         AssignProp("", false, cmbConvenioStatus_Internalname, "Values", (string)(cmbConvenioStatus.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Convenio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Convenio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Convenio.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConvenioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ",", "")), StringUtil.LTrim( ((edtConvenioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A410ConvenioId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A410ConvenioId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConvenioId_Jsonclick, 0, "Attribute", "", "", "", "", edtConvenioId_Visible, edtConvenioId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Convenio.htm");
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
         E111N2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z410ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z410ConvenioId"), ",", "."), 18, MidpointRounding.ToEven));
               Z411ConvenioDescricao = cgiGet( "Z411ConvenioDescricao");
               n411ConvenioDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A411ConvenioDescricao)) ? true : false);
               Z412ConvenioStatus = StringUtil.StrToBool( cgiGet( "Z412ConvenioStatus"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCONVENIOID"), ",", "."), 18, MidpointRounding.ToEven));
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
               A411ConvenioDescricao = cgiGet( edtConvenioDescricao_Internalname);
               n411ConvenioDescricao = false;
               AssignAttri("", false, "A411ConvenioDescricao", A411ConvenioDescricao);
               n411ConvenioDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A411ConvenioDescricao)) ? true : false);
               cmbConvenioStatus.CurrentValue = cgiGet( cmbConvenioStatus_Internalname);
               A412ConvenioStatus = StringUtil.StrToBool( cgiGet( cmbConvenioStatus_Internalname));
               AssignAttri("", false, "A412ConvenioStatus", A412ConvenioStatus);
               A410ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtConvenioId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n410ConvenioId = false;
               AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Convenio");
               A410ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtConvenioId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n410ConvenioId = false;
               AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
               forbiddenHiddens.Add("ConvenioId", context.localUtil.Format( (decimal)(A410ConvenioId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A410ConvenioId != Z410ConvenioId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("convenio:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A410ConvenioId = (int)(Math.Round(NumberUtil.Val( GetPar( "ConvenioId"), "."), 18, MidpointRounding.ToEven));
                  n410ConvenioId = false;
                  AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
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
                     sMode61 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode61;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound61 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1N0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CONVENIOID");
                        AnyError = 1;
                        GX_FocusControl = edtConvenioId_Internalname;
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
                           E111N2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121N2 ();
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
            E121N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1N61( ) ;
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
            DisableAttributes1N61( ) ;
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

      protected void CONFIRM_1N0( )
      {
         BeforeValidate1N61( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1N61( ) ;
            }
            else
            {
               CheckExtendedTable1N61( ) ;
               CloseExtendedTableCursors1N61( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1N0( )
      {
      }

      protected void E111N2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtConvenioId_Visible = 0;
         AssignProp("", false, edtConvenioId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtConvenioId_Visible), 5, 0), true);
      }

      protected void E121N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("convenioww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1N61( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z411ConvenioDescricao = T001N3_A411ConvenioDescricao[0];
               Z412ConvenioStatus = T001N3_A412ConvenioStatus[0];
            }
            else
            {
               Z411ConvenioDescricao = A411ConvenioDescricao;
               Z412ConvenioStatus = A412ConvenioStatus;
            }
         }
         if ( GX_JID == -3 )
         {
            Z410ConvenioId = A410ConvenioId;
            Z411ConvenioDescricao = A411ConvenioDescricao;
            Z412ConvenioStatus = A412ConvenioStatus;
         }
      }

      protected void standaloneNotModal( )
      {
         edtConvenioId_Enabled = 0;
         AssignProp("", false, edtConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConvenioId_Enabled), 5, 0), true);
         edtConvenioId_Enabled = 0;
         AssignProp("", false, edtConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConvenioId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ConvenioId) )
         {
            A410ConvenioId = AV7ConvenioId;
            n410ConvenioId = false;
            AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
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

      protected void Load1N61( )
      {
         /* Using cursor T001N4 */
         pr_default.execute(2, new Object[] {n410ConvenioId, A410ConvenioId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound61 = 1;
            A411ConvenioDescricao = T001N4_A411ConvenioDescricao[0];
            n411ConvenioDescricao = T001N4_n411ConvenioDescricao[0];
            AssignAttri("", false, "A411ConvenioDescricao", A411ConvenioDescricao);
            A412ConvenioStatus = T001N4_A412ConvenioStatus[0];
            AssignAttri("", false, "A412ConvenioStatus", A412ConvenioStatus);
            ZM1N61( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1N61( ) ;
      }

      protected void OnLoadActions1N61( )
      {
      }

      protected void CheckExtendedTable1N61( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1N61( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1N61( )
      {
         /* Using cursor T001N5 */
         pr_default.execute(3, new Object[] {n410ConvenioId, A410ConvenioId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound61 = 1;
         }
         else
         {
            RcdFound61 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001N3 */
         pr_default.execute(1, new Object[] {n410ConvenioId, A410ConvenioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1N61( 3) ;
            RcdFound61 = 1;
            A410ConvenioId = T001N3_A410ConvenioId[0];
            n410ConvenioId = T001N3_n410ConvenioId[0];
            AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
            A411ConvenioDescricao = T001N3_A411ConvenioDescricao[0];
            n411ConvenioDescricao = T001N3_n411ConvenioDescricao[0];
            AssignAttri("", false, "A411ConvenioDescricao", A411ConvenioDescricao);
            A412ConvenioStatus = T001N3_A412ConvenioStatus[0];
            AssignAttri("", false, "A412ConvenioStatus", A412ConvenioStatus);
            Z410ConvenioId = A410ConvenioId;
            sMode61 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1N61( ) ;
            if ( AnyError == 1 )
            {
               RcdFound61 = 0;
               InitializeNonKey1N61( ) ;
            }
            Gx_mode = sMode61;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound61 = 0;
            InitializeNonKey1N61( ) ;
            sMode61 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode61;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1N61( ) ;
         if ( RcdFound61 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound61 = 0;
         /* Using cursor T001N6 */
         pr_default.execute(4, new Object[] {n410ConvenioId, A410ConvenioId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001N6_A410ConvenioId[0] < A410ConvenioId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001N6_A410ConvenioId[0] > A410ConvenioId ) ) )
            {
               A410ConvenioId = T001N6_A410ConvenioId[0];
               n410ConvenioId = T001N6_n410ConvenioId[0];
               AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
               RcdFound61 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound61 = 0;
         /* Using cursor T001N7 */
         pr_default.execute(5, new Object[] {n410ConvenioId, A410ConvenioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001N7_A410ConvenioId[0] > A410ConvenioId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001N7_A410ConvenioId[0] < A410ConvenioId ) ) )
            {
               A410ConvenioId = T001N7_A410ConvenioId[0];
               n410ConvenioId = T001N7_n410ConvenioId[0];
               AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
               RcdFound61 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1N61( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtConvenioDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1N61( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound61 == 1 )
            {
               if ( A410ConvenioId != Z410ConvenioId )
               {
                  A410ConvenioId = Z410ConvenioId;
                  n410ConvenioId = false;
                  AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONVENIOID");
                  AnyError = 1;
                  GX_FocusControl = edtConvenioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtConvenioDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1N61( ) ;
                  GX_FocusControl = edtConvenioDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A410ConvenioId != Z410ConvenioId )
               {
                  /* Insert record */
                  GX_FocusControl = edtConvenioDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1N61( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONVENIOID");
                     AnyError = 1;
                     GX_FocusControl = edtConvenioId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtConvenioDescricao_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1N61( ) ;
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
         if ( A410ConvenioId != Z410ConvenioId )
         {
            A410ConvenioId = Z410ConvenioId;
            n410ConvenioId = false;
            AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONVENIOID");
            AnyError = 1;
            GX_FocusControl = edtConvenioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtConvenioDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1N61( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001N2 */
            pr_default.execute(0, new Object[] {n410ConvenioId, A410ConvenioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Convenio"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z411ConvenioDescricao, T001N2_A411ConvenioDescricao[0]) != 0 ) || ( Z412ConvenioStatus != T001N2_A412ConvenioStatus[0] ) )
            {
               if ( StringUtil.StrCmp(Z411ConvenioDescricao, T001N2_A411ConvenioDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("convenio:[seudo value changed for attri]"+"ConvenioDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z411ConvenioDescricao);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A411ConvenioDescricao[0]);
               }
               if ( Z412ConvenioStatus != T001N2_A412ConvenioStatus[0] )
               {
                  GXUtil.WriteLog("convenio:[seudo value changed for attri]"+"ConvenioStatus");
                  GXUtil.WriteLogRaw("Old: ",Z412ConvenioStatus);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A412ConvenioStatus[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Convenio"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1N61( )
      {
         BeforeValidate1N61( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1N61( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1N61( 0) ;
            CheckOptimisticConcurrency1N61( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1N61( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1N61( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001N8 */
                     pr_default.execute(6, new Object[] {n411ConvenioDescricao, A411ConvenioDescricao, A412ConvenioStatus});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001N9 */
                     pr_default.execute(7);
                     A410ConvenioId = T001N9_A410ConvenioId[0];
                     n410ConvenioId = T001N9_n410ConvenioId[0];
                     AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Convenio");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1N0( ) ;
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
               Load1N61( ) ;
            }
            EndLevel1N61( ) ;
         }
         CloseExtendedTableCursors1N61( ) ;
      }

      protected void Update1N61( )
      {
         BeforeValidate1N61( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1N61( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1N61( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1N61( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1N61( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001N10 */
                     pr_default.execute(8, new Object[] {n411ConvenioDescricao, A411ConvenioDescricao, A412ConvenioStatus, n410ConvenioId, A410ConvenioId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Convenio");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Convenio"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1N61( ) ;
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
            EndLevel1N61( ) ;
         }
         CloseExtendedTableCursors1N61( ) ;
      }

      protected void DeferredUpdate1N61( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1N61( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1N61( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1N61( ) ;
            AfterConfirm1N61( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1N61( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001N11 */
                  pr_default.execute(9, new Object[] {n410ConvenioId, A410ConvenioId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Convenio");
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
         sMode61 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1N61( ) ;
         Gx_mode = sMode61;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1N61( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001N12 */
            pr_default.execute(10, new Object[] {n410ConvenioId, A410ConvenioId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T001N13 */
            pr_default.execute(11, new Object[] {n410ConvenioId, A410ConvenioId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ConvenioCategoria"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel1N61( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1N61( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("convenio",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("convenio",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1N61( )
      {
         /* Scan By routine */
         /* Using cursor T001N14 */
         pr_default.execute(12);
         RcdFound61 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound61 = 1;
            A410ConvenioId = T001N14_A410ConvenioId[0];
            n410ConvenioId = T001N14_n410ConvenioId[0];
            AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1N61( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound61 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound61 = 1;
            A410ConvenioId = T001N14_A410ConvenioId[0];
            n410ConvenioId = T001N14_n410ConvenioId[0];
            AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
         }
      }

      protected void ScanEnd1N61( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1N61( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1N61( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1N61( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1N61( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1N61( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1N61( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1N61( )
      {
         edtConvenioDescricao_Enabled = 0;
         AssignProp("", false, edtConvenioDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConvenioDescricao_Enabled), 5, 0), true);
         cmbConvenioStatus.Enabled = 0;
         AssignProp("", false, cmbConvenioStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConvenioStatus.Enabled), 5, 0), true);
         edtConvenioId_Enabled = 0;
         AssignProp("", false, edtConvenioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConvenioId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1N61( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1N0( )
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
         GXEncryptionTmp = "convenio"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ConvenioId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("convenio") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Convenio");
         forbiddenHiddens.Add("ConvenioId", context.localUtil.Format( (decimal)(A410ConvenioId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("convenio:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z410ConvenioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z410ConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z411ConvenioDescricao", Z411ConvenioDescricao);
         GxWebStd.gx_boolean_hidden_field( context, "Z412ConvenioStatus", Z412ConvenioStatus);
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
         GxWebStd.gx_hidden_field( context, "vCONVENIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCONVENIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ConvenioId), "ZZZZZZZZ9"), context));
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
         GXEncryptionTmp = "convenio"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ConvenioId,9,0));
         return formatLink("convenio") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Convenio" ;
      }

      public override string GetPgmdesc( )
      {
         return "Convenio" ;
      }

      protected void InitializeNonKey1N61( )
      {
         A411ConvenioDescricao = "";
         n411ConvenioDescricao = false;
         AssignAttri("", false, "A411ConvenioDescricao", A411ConvenioDescricao);
         n411ConvenioDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A411ConvenioDescricao)) ? true : false);
         A412ConvenioStatus = false;
         AssignAttri("", false, "A412ConvenioStatus", A412ConvenioStatus);
         Z411ConvenioDescricao = "";
         Z412ConvenioStatus = false;
      }

      protected void InitAll1N61( )
      {
         A410ConvenioId = 0;
         n410ConvenioId = false;
         AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
         InitializeNonKey1N61( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019164357", true, true);
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
         context.AddJavascriptSource("convenio.js", "?202561019164358", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtConvenioDescricao_Internalname = "CONVENIODESCRICAO";
         cmbConvenioStatus_Internalname = "CONVENIOSTATUS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = "Convenio";
         edtConvenioId_Jsonclick = "";
         edtConvenioId_Enabled = 0;
         edtConvenioId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbConvenioStatus_Jsonclick = "";
         cmbConvenioStatus.Enabled = 1;
         edtConvenioDescricao_Jsonclick = "";
         edtConvenioDescricao_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Convênio";
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
         cmbConvenioStatus.Name = "CONVENIOSTATUS";
         cmbConvenioStatus.WebTags = "";
         cmbConvenioStatus.addItem(StringUtil.BoolToStr( true), "sim", 0);
         cmbConvenioStatus.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbConvenioStatus.ItemCount > 0 )
         {
            A412ConvenioStatus = StringUtil.StrToBool( cmbConvenioStatus.getValidValue(StringUtil.BoolToStr( A412ConvenioStatus)));
            AssignAttri("", false, "A412ConvenioStatus", A412ConvenioStatus);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A410ConvenioId","fld":"CONVENIOID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121N2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_CONVENIOID","""{"handler":"Valid_Convenioid","iparms":[]}""");
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
         Z411ConvenioDescricao = "";
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
         A411ConvenioDescricao = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode61 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T001N4_A410ConvenioId = new int[1] ;
         T001N4_n410ConvenioId = new bool[] {false} ;
         T001N4_A411ConvenioDescricao = new string[] {""} ;
         T001N4_n411ConvenioDescricao = new bool[] {false} ;
         T001N4_A412ConvenioStatus = new bool[] {false} ;
         T001N5_A410ConvenioId = new int[1] ;
         T001N5_n410ConvenioId = new bool[] {false} ;
         T001N3_A410ConvenioId = new int[1] ;
         T001N3_n410ConvenioId = new bool[] {false} ;
         T001N3_A411ConvenioDescricao = new string[] {""} ;
         T001N3_n411ConvenioDescricao = new bool[] {false} ;
         T001N3_A412ConvenioStatus = new bool[] {false} ;
         T001N6_A410ConvenioId = new int[1] ;
         T001N6_n410ConvenioId = new bool[] {false} ;
         T001N7_A410ConvenioId = new int[1] ;
         T001N7_n410ConvenioId = new bool[] {false} ;
         T001N2_A410ConvenioId = new int[1] ;
         T001N2_n410ConvenioId = new bool[] {false} ;
         T001N2_A411ConvenioDescricao = new string[] {""} ;
         T001N2_n411ConvenioDescricao = new bool[] {false} ;
         T001N2_A412ConvenioStatus = new bool[] {false} ;
         T001N9_A410ConvenioId = new int[1] ;
         T001N9_n410ConvenioId = new bool[] {false} ;
         T001N12_A168ClienteId = new int[1] ;
         T001N13_A493ConvenioCategoriaId = new int[1] ;
         T001N14_A410ConvenioId = new int[1] ;
         T001N14_n410ConvenioId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.convenio__default(),
            new Object[][] {
                new Object[] {
               T001N2_A410ConvenioId, T001N2_A411ConvenioDescricao, T001N2_n411ConvenioDescricao, T001N2_A412ConvenioStatus
               }
               , new Object[] {
               T001N3_A410ConvenioId, T001N3_A411ConvenioDescricao, T001N3_n411ConvenioDescricao, T001N3_A412ConvenioStatus
               }
               , new Object[] {
               T001N4_A410ConvenioId, T001N4_A411ConvenioDescricao, T001N4_n411ConvenioDescricao, T001N4_A412ConvenioStatus
               }
               , new Object[] {
               T001N5_A410ConvenioId
               }
               , new Object[] {
               T001N6_A410ConvenioId
               }
               , new Object[] {
               T001N7_A410ConvenioId
               }
               , new Object[] {
               }
               , new Object[] {
               T001N9_A410ConvenioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001N12_A168ClienteId
               }
               , new Object[] {
               T001N13_A493ConvenioCategoriaId
               }
               , new Object[] {
               T001N14_A410ConvenioId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound61 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7ConvenioId ;
      private int Z410ConvenioId ;
      private int AV7ConvenioId ;
      private int trnEnded ;
      private int edtConvenioDescricao_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A410ConvenioId ;
      private int edtConvenioId_Enabled ;
      private int edtConvenioId_Visible ;
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
      private string edtConvenioDescricao_Internalname ;
      private string cmbConvenioStatus_Internalname ;
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
      private string edtConvenioDescricao_Jsonclick ;
      private string cmbConvenioStatus_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtConvenioId_Internalname ;
      private string edtConvenioId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode61 ;
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
      private bool Z412ConvenioStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A412ConvenioStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n411ConvenioDescricao ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n410ConvenioId ;
      private bool returnInSub ;
      private string Z411ConvenioDescricao ;
      private string A411ConvenioDescricao ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbConvenioStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] T001N4_A410ConvenioId ;
      private bool[] T001N4_n410ConvenioId ;
      private string[] T001N4_A411ConvenioDescricao ;
      private bool[] T001N4_n411ConvenioDescricao ;
      private bool[] T001N4_A412ConvenioStatus ;
      private int[] T001N5_A410ConvenioId ;
      private bool[] T001N5_n410ConvenioId ;
      private int[] T001N3_A410ConvenioId ;
      private bool[] T001N3_n410ConvenioId ;
      private string[] T001N3_A411ConvenioDescricao ;
      private bool[] T001N3_n411ConvenioDescricao ;
      private bool[] T001N3_A412ConvenioStatus ;
      private int[] T001N6_A410ConvenioId ;
      private bool[] T001N6_n410ConvenioId ;
      private int[] T001N7_A410ConvenioId ;
      private bool[] T001N7_n410ConvenioId ;
      private int[] T001N2_A410ConvenioId ;
      private bool[] T001N2_n410ConvenioId ;
      private string[] T001N2_A411ConvenioDescricao ;
      private bool[] T001N2_n411ConvenioDescricao ;
      private bool[] T001N2_A412ConvenioStatus ;
      private int[] T001N9_A410ConvenioId ;
      private bool[] T001N9_n410ConvenioId ;
      private int[] T001N12_A168ClienteId ;
      private int[] T001N13_A493ConvenioCategoriaId ;
      private int[] T001N14_A410ConvenioId ;
      private bool[] T001N14_n410ConvenioId ;
   }

   public class convenio__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT001N2;
          prmT001N2 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001N3;
          prmT001N3 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001N4;
          prmT001N4 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001N5;
          prmT001N5 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001N6;
          prmT001N6 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001N7;
          prmT001N7 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001N8;
          prmT001N8 = new Object[] {
          new ParDef("ConvenioDescricao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConvenioStatus",GXType.Boolean,4,0)
          };
          Object[] prmT001N9;
          prmT001N9 = new Object[] {
          };
          Object[] prmT001N10;
          prmT001N10 = new Object[] {
          new ParDef("ConvenioDescricao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConvenioStatus",GXType.Boolean,4,0) ,
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001N11;
          prmT001N11 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001N12;
          prmT001N12 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001N13;
          prmT001N13 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001N14;
          prmT001N14 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T001N2", "SELECT ConvenioId, ConvenioDescricao, ConvenioStatus FROM Convenio WHERE ConvenioId = :ConvenioId  FOR UPDATE OF Convenio NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001N2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001N3", "SELECT ConvenioId, ConvenioDescricao, ConvenioStatus FROM Convenio WHERE ConvenioId = :ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001N4", "SELECT TM1.ConvenioId, TM1.ConvenioDescricao, TM1.ConvenioStatus FROM Convenio TM1 WHERE TM1.ConvenioId = :ConvenioId ORDER BY TM1.ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001N5", "SELECT ConvenioId FROM Convenio WHERE ConvenioId = :ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001N6", "SELECT ConvenioId FROM Convenio WHERE ( ConvenioId > :ConvenioId) ORDER BY ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001N7", "SELECT ConvenioId FROM Convenio WHERE ( ConvenioId < :ConvenioId) ORDER BY ConvenioId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001N8", "SAVEPOINT gxupdate;INSERT INTO Convenio(ConvenioDescricao, ConvenioStatus) VALUES(:ConvenioDescricao, :ConvenioStatus);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001N8)
             ,new CursorDef("T001N9", "SELECT currval('ConvenioId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001N10", "SAVEPOINT gxupdate;UPDATE Convenio SET ConvenioDescricao=:ConvenioDescricao, ConvenioStatus=:ConvenioStatus  WHERE ConvenioId = :ConvenioId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001N10)
             ,new CursorDef("T001N11", "SAVEPOINT gxupdate;DELETE FROM Convenio  WHERE ConvenioId = :ConvenioId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001N11)
             ,new CursorDef("T001N12", "SELECT ClienteId FROM Cliente WHERE ClienteConvenio = :ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001N13", "SELECT ConvenioCategoriaId FROM ConvenioCategoria WHERE ConvenioId = :ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001N14", "SELECT ConvenioId FROM Convenio ORDER BY ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N14,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
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
