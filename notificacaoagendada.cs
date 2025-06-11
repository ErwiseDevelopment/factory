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
   public class notificacaoagendada : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A904NotificacaoAgendadaLayoutId = (short)(Math.Round(NumberUtil.Val( GetPar( "NotificacaoAgendadaLayoutId"), "."), 18, MidpointRounding.ToEven));
            n904NotificacaoAgendadaLayoutId = false;
            AssignAttri("", false, "A904NotificacaoAgendadaLayoutId", ((0==A904NotificacaoAgendadaLayoutId)&&IsIns( )||n904NotificacaoAgendadaLayoutId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A904NotificacaoAgendadaLayoutId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "notificacaoagendada")), "notificacaoagendada") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "notificacaoagendada")))) ;
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
                  AV7NotificacaoAgendadaId = (int)(Math.Round(NumberUtil.Val( GetPar( "NotificacaoAgendadaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(AV7NotificacaoAgendadaId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICACAOAGENDADAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7NotificacaoAgendadaId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Agendar Notificação", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNotificacaoAgendadaDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public notificacaoagendada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notificacaoagendada( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_NotificacaoAgendadaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7NotificacaoAgendadaId = aP1_NotificacaoAgendadaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbNotificacaoAgendadaOrigem = new GXCombobox();
         cmbNotificacaoAgendadaMomentoEnvio = new GXCombobox();
         cmbNotificacaoAgendadaTipo = new GXCombobox();
         cmbNotificacaoAgendadaStatus = new GXCombobox();
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
         if ( cmbNotificacaoAgendadaOrigem.ItemCount > 0 )
         {
            A899NotificacaoAgendadaOrigem = cmbNotificacaoAgendadaOrigem.getValidValue(A899NotificacaoAgendadaOrigem);
            AssignAttri("", false, "A899NotificacaoAgendadaOrigem", A899NotificacaoAgendadaOrigem);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificacaoAgendadaOrigem.CurrentValue = StringUtil.RTrim( A899NotificacaoAgendadaOrigem);
            AssignProp("", false, cmbNotificacaoAgendadaOrigem_Internalname, "Values", cmbNotificacaoAgendadaOrigem.ToJavascriptSource(), true);
         }
         if ( cmbNotificacaoAgendadaMomentoEnvio.ItemCount > 0 )
         {
            A902NotificacaoAgendadaMomentoEnvio = cmbNotificacaoAgendadaMomentoEnvio.getValidValue(A902NotificacaoAgendadaMomentoEnvio);
            n902NotificacaoAgendadaMomentoEnvio = false;
            AssignAttri("", false, "A902NotificacaoAgendadaMomentoEnvio", A902NotificacaoAgendadaMomentoEnvio);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificacaoAgendadaMomentoEnvio.CurrentValue = StringUtil.RTrim( A902NotificacaoAgendadaMomentoEnvio);
            AssignProp("", false, cmbNotificacaoAgendadaMomentoEnvio_Internalname, "Values", cmbNotificacaoAgendadaMomentoEnvio.ToJavascriptSource(), true);
         }
         if ( cmbNotificacaoAgendadaTipo.ItemCount > 0 )
         {
            A903NotificacaoAgendadaTipo = cmbNotificacaoAgendadaTipo.getValidValue(A903NotificacaoAgendadaTipo);
            n903NotificacaoAgendadaTipo = false;
            AssignAttri("", false, "A903NotificacaoAgendadaTipo", A903NotificacaoAgendadaTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificacaoAgendadaTipo.CurrentValue = StringUtil.RTrim( A903NotificacaoAgendadaTipo);
            AssignProp("", false, cmbNotificacaoAgendadaTipo_Internalname, "Values", cmbNotificacaoAgendadaTipo.ToJavascriptSource(), true);
         }
         if ( cmbNotificacaoAgendadaStatus.ItemCount > 0 )
         {
            A905NotificacaoAgendadaStatus = StringUtil.StrToBool( cmbNotificacaoAgendadaStatus.getValidValue(StringUtil.BoolToStr( A905NotificacaoAgendadaStatus)));
            n905NotificacaoAgendadaStatus = false;
            AssignAttri("", false, "A905NotificacaoAgendadaStatus", A905NotificacaoAgendadaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNotificacaoAgendadaStatus.CurrentValue = StringUtil.BoolToStr( A905NotificacaoAgendadaStatus);
            AssignProp("", false, cmbNotificacaoAgendadaStatus_Internalname, "Values", cmbNotificacaoAgendadaStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotificacaoAgendadaOrigem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotificacaoAgendadaOrigem_Internalname, "Origem da Notificação", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotificacaoAgendadaOrigem, cmbNotificacaoAgendadaOrigem_Internalname, StringUtil.RTrim( A899NotificacaoAgendadaOrigem), 1, cmbNotificacaoAgendadaOrigem_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNotificacaoAgendadaOrigem.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_NotificacaoAgendada.htm");
         cmbNotificacaoAgendadaOrigem.CurrentValue = StringUtil.RTrim( A899NotificacaoAgendadaOrigem);
         AssignProp("", false, cmbNotificacaoAgendadaOrigem_Internalname, "Values", (string)(cmbNotificacaoAgendadaOrigem.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaDescricao_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaDescricao_Internalname, A900NotificacaoAgendadaDescricao, StringUtil.RTrim( context.localUtil.Format( A900NotificacaoAgendadaDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaDescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNotificacaoAgendadaDescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_NotificacaoAgendada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNotificacaoAgendadaDias_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaDias_Internalname, "Número de dias", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaDias_Internalname, ((0==A901NotificacaoAgendadaDias)&&IsIns( )||n901NotificacaoAgendadaDias ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A901NotificacaoAgendadaDias), 9, 0, ",", ""))), ((0==A901NotificacaoAgendadaDias)&&IsIns( )||n901NotificacaoAgendadaDias ? "" : StringUtil.LTrim( ((edtNotificacaoAgendadaDias_Enabled!=0) ? context.localUtil.Format( (decimal)(A901NotificacaoAgendadaDias), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A901NotificacaoAgendadaDias), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaDias_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNotificacaoAgendadaDias_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotificacaoAgendada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotificacaoAgendadaMomentoEnvio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotificacaoAgendadaMomentoEnvio_Internalname, "Momento de Envio", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotificacaoAgendadaMomentoEnvio, cmbNotificacaoAgendadaMomentoEnvio_Internalname, StringUtil.RTrim( A902NotificacaoAgendadaMomentoEnvio), 1, cmbNotificacaoAgendadaMomentoEnvio_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNotificacaoAgendadaMomentoEnvio.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_NotificacaoAgendada.htm");
         cmbNotificacaoAgendadaMomentoEnvio.CurrentValue = StringUtil.RTrim( A902NotificacaoAgendadaMomentoEnvio);
         AssignProp("", false, cmbNotificacaoAgendadaMomentoEnvio_Internalname, "Values", (string)(cmbNotificacaoAgendadaMomentoEnvio.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotificacaoAgendadaTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotificacaoAgendadaTipo_Internalname, "Tipo de Notificação", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotificacaoAgendadaTipo, cmbNotificacaoAgendadaTipo_Internalname, StringUtil.RTrim( A903NotificacaoAgendadaTipo), 1, cmbNotificacaoAgendadaTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNotificacaoAgendadaTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_NotificacaoAgendada.htm");
         cmbNotificacaoAgendadaTipo.CurrentValue = StringUtil.RTrim( A903NotificacaoAgendadaTipo);
         AssignProp("", false, cmbNotificacaoAgendadaTipo_Internalname, "Values", (string)(cmbNotificacaoAgendadaTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittednotificacaoagendadalayoutid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocknotificacaoagendadalayoutid_Internalname, "Layout de Envio", "", "", lblTextblocknotificacaoagendadalayoutid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_NotificacaoAgendada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_notificacaoagendadalayoutid.SetProperty("Caption", Combo_notificacaoagendadalayoutid_Caption);
         ucCombo_notificacaoagendadalayoutid.SetProperty("Cls", Combo_notificacaoagendadalayoutid_Cls);
         ucCombo_notificacaoagendadalayoutid.SetProperty("EmptyItem", Combo_notificacaoagendadalayoutid_Emptyitem);
         ucCombo_notificacaoagendadalayoutid.SetProperty("DropDownOptionsData", AV13NotificacaoAgendadaLayoutId_Data);
         ucCombo_notificacaoagendadalayoutid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_notificacaoagendadalayoutid_Internalname, "COMBO_NOTIFICACAOAGENDADALAYOUTIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNotificacaoAgendadaLayoutId_Internalname, "Layout de Envio", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaLayoutId_Internalname, ((0==A904NotificacaoAgendadaLayoutId)&&IsIns( )||n904NotificacaoAgendadaLayoutId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0, ",", ""))), ((0==A904NotificacaoAgendadaLayoutId)&&IsIns( )||n904NotificacaoAgendadaLayoutId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A904NotificacaoAgendadaLayoutId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaLayoutId_Jsonclick, 0, "Attribute", "", "", "", "", edtNotificacaoAgendadaLayoutId_Visible, edtNotificacaoAgendadaLayoutId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotificacaoAgendada.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNotificacaoAgendadaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNotificacaoAgendadaStatus_Internalname, "Ativo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNotificacaoAgendadaStatus, cmbNotificacaoAgendadaStatus_Internalname, StringUtil.BoolToStr( A905NotificacaoAgendadaStatus), 1, cmbNotificacaoAgendadaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbNotificacaoAgendadaStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "", true, 0, "HLP_NotificacaoAgendada.htm");
         cmbNotificacaoAgendadaStatus.CurrentValue = StringUtil.BoolToStr( A905NotificacaoAgendadaStatus);
         AssignProp("", false, cmbNotificacaoAgendadaStatus_Internalname, "Values", (string)(cmbNotificacaoAgendadaStatus.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendada.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_notificacaoagendadalayoutid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombonotificacaoagendadalayoutid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15ComboNotificacaoAgendadaLayoutId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCombonotificacaoagendadalayoutid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15ComboNotificacaoAgendadaLayoutId), "ZZZ9") : context.localUtil.Format( (decimal)(AV15ComboNotificacaoAgendadaLayoutId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombonotificacaoagendadalayoutid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombonotificacaoagendadalayoutid_Visible, edtavCombonotificacaoagendadalayoutid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_NotificacaoAgendada.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNotificacaoAgendadaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A898NotificacaoAgendadaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtNotificacaoAgendadaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A898NotificacaoAgendadaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A898NotificacaoAgendadaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNotificacaoAgendadaId_Jsonclick, 0, "Attribute", "", "", "", "", edtNotificacaoAgendadaId_Visible, edtNotificacaoAgendadaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_NotificacaoAgendada.htm");
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
         E112U2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICACAOAGENDADALAYOUTID_DATA"), AV13NotificacaoAgendadaLayoutId_Data);
               /* Read saved values. */
               Z898NotificacaoAgendadaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z898NotificacaoAgendadaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z899NotificacaoAgendadaOrigem = cgiGet( "Z899NotificacaoAgendadaOrigem");
               Z900NotificacaoAgendadaDescricao = cgiGet( "Z900NotificacaoAgendadaDescricao");
               Z901NotificacaoAgendadaDias = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z901NotificacaoAgendadaDias"), ",", "."), 18, MidpointRounding.ToEven));
               n901NotificacaoAgendadaDias = ((0==A901NotificacaoAgendadaDias) ? true : false);
               Z902NotificacaoAgendadaMomentoEnvio = cgiGet( "Z902NotificacaoAgendadaMomentoEnvio");
               n902NotificacaoAgendadaMomentoEnvio = (String.IsNullOrEmpty(StringUtil.RTrim( A902NotificacaoAgendadaMomentoEnvio)) ? true : false);
               Z903NotificacaoAgendadaTipo = cgiGet( "Z903NotificacaoAgendadaTipo");
               n903NotificacaoAgendadaTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A903NotificacaoAgendadaTipo)) ? true : false);
               Z905NotificacaoAgendadaStatus = StringUtil.StrToBool( cgiGet( "Z905NotificacaoAgendadaStatus"));
               n905NotificacaoAgendadaStatus = ((false==A905NotificacaoAgendadaStatus) ? true : false);
               Z904NotificacaoAgendadaLayoutId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z904NotificacaoAgendadaLayoutId"), ",", "."), 18, MidpointRounding.ToEven));
               n904NotificacaoAgendadaLayoutId = ((0==A904NotificacaoAgendadaLayoutId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N904NotificacaoAgendadaLayoutId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N904NotificacaoAgendadaLayoutId"), ",", "."), 18, MidpointRounding.ToEven));
               n904NotificacaoAgendadaLayoutId = ((0==A904NotificacaoAgendadaLayoutId) ? true : false);
               A907NotificacaoAgendadaOffsetDias = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NOTIFICACAOAGENDADAOFFSETDIAS"), ",", "."), 18, MidpointRounding.ToEven));
               AV7NotificacaoAgendadaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vNOTIFICACAOAGENDADAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_NotificacaoAgendadaLayoutId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_NOTIFICACAOAGENDADALAYOUTID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_NotificacaoAgendadaLayoutId", StringUtil.LTrimStr( (decimal)(AV11Insert_NotificacaoAgendadaLayoutId), 4, 0));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               AV17Pgmname = cgiGet( "vPGMNAME");
               Combo_notificacaoagendadalayoutid_Objectcall = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Objectcall");
               Combo_notificacaoagendadalayoutid_Class = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Class");
               Combo_notificacaoagendadalayoutid_Icontype = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Icontype");
               Combo_notificacaoagendadalayoutid_Icon = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Icon");
               Combo_notificacaoagendadalayoutid_Caption = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Caption");
               Combo_notificacaoagendadalayoutid_Tooltip = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Tooltip");
               Combo_notificacaoagendadalayoutid_Cls = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Cls");
               Combo_notificacaoagendadalayoutid_Selectedvalue_set = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Selectedvalue_set");
               Combo_notificacaoagendadalayoutid_Selectedvalue_get = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Selectedvalue_get");
               Combo_notificacaoagendadalayoutid_Selectedtext_set = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Selectedtext_set");
               Combo_notificacaoagendadalayoutid_Selectedtext_get = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Selectedtext_get");
               Combo_notificacaoagendadalayoutid_Gamoauthtoken = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Gamoauthtoken");
               Combo_notificacaoagendadalayoutid_Ddointernalname = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Ddointernalname");
               Combo_notificacaoagendadalayoutid_Titlecontrolalign = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Titlecontrolalign");
               Combo_notificacaoagendadalayoutid_Dropdownoptionstype = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Dropdownoptionstype");
               Combo_notificacaoagendadalayoutid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Enabled"));
               Combo_notificacaoagendadalayoutid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Visible"));
               Combo_notificacaoagendadalayoutid_Titlecontrolidtoreplace = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Titlecontrolidtoreplace");
               Combo_notificacaoagendadalayoutid_Datalisttype = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Datalisttype");
               Combo_notificacaoagendadalayoutid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Allowmultipleselection"));
               Combo_notificacaoagendadalayoutid_Datalistfixedvalues = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Datalistfixedvalues");
               Combo_notificacaoagendadalayoutid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Isgriditem"));
               Combo_notificacaoagendadalayoutid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Hasdescription"));
               Combo_notificacaoagendadalayoutid_Datalistproc = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Datalistproc");
               Combo_notificacaoagendadalayoutid_Datalistprocparametersprefix = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Datalistprocparametersprefix");
               Combo_notificacaoagendadalayoutid_Remoteservicesparameters = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Remoteservicesparameters");
               Combo_notificacaoagendadalayoutid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_notificacaoagendadalayoutid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Includeonlyselectedoption"));
               Combo_notificacaoagendadalayoutid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Includeselectalloption"));
               Combo_notificacaoagendadalayoutid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Emptyitem"));
               Combo_notificacaoagendadalayoutid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Includeaddnewoption"));
               Combo_notificacaoagendadalayoutid_Htmltemplate = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Htmltemplate");
               Combo_notificacaoagendadalayoutid_Multiplevaluestype = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Multiplevaluestype");
               Combo_notificacaoagendadalayoutid_Loadingdata = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Loadingdata");
               Combo_notificacaoagendadalayoutid_Noresultsfound = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Noresultsfound");
               Combo_notificacaoagendadalayoutid_Emptyitemtext = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Emptyitemtext");
               Combo_notificacaoagendadalayoutid_Onlyselectedvalues = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Onlyselectedvalues");
               Combo_notificacaoagendadalayoutid_Selectalltext = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Selectalltext");
               Combo_notificacaoagendadalayoutid_Multiplevaluesseparator = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Multiplevaluesseparator");
               Combo_notificacaoagendadalayoutid_Addnewoptiontext = cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Addnewoptiontext");
               Combo_notificacaoagendadalayoutid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NOTIFICACAOAGENDADALAYOUTID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               cmbNotificacaoAgendadaOrigem.CurrentValue = cgiGet( cmbNotificacaoAgendadaOrigem_Internalname);
               A899NotificacaoAgendadaOrigem = cgiGet( cmbNotificacaoAgendadaOrigem_Internalname);
               AssignAttri("", false, "A899NotificacaoAgendadaOrigem", A899NotificacaoAgendadaOrigem);
               A900NotificacaoAgendadaDescricao = cgiGet( edtNotificacaoAgendadaDescricao_Internalname);
               AssignAttri("", false, "A900NotificacaoAgendadaDescricao", A900NotificacaoAgendadaDescricao);
               n901NotificacaoAgendadaDias = ((StringUtil.StrCmp(cgiGet( edtNotificacaoAgendadaDias_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaDias_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaDias_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NOTIFICACAOAGENDADADIAS");
                  AnyError = 1;
                  GX_FocusControl = edtNotificacaoAgendadaDias_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A901NotificacaoAgendadaDias = 0;
                  n901NotificacaoAgendadaDias = false;
                  AssignAttri("", false, "A901NotificacaoAgendadaDias", (n901NotificacaoAgendadaDias ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A901NotificacaoAgendadaDias), 9, 0, ".", ""))));
               }
               else
               {
                  A901NotificacaoAgendadaDias = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaDias_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A901NotificacaoAgendadaDias", (n901NotificacaoAgendadaDias ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A901NotificacaoAgendadaDias), 9, 0, ".", ""))));
               }
               cmbNotificacaoAgendadaMomentoEnvio.CurrentValue = cgiGet( cmbNotificacaoAgendadaMomentoEnvio_Internalname);
               A902NotificacaoAgendadaMomentoEnvio = cgiGet( cmbNotificacaoAgendadaMomentoEnvio_Internalname);
               n902NotificacaoAgendadaMomentoEnvio = false;
               AssignAttri("", false, "A902NotificacaoAgendadaMomentoEnvio", A902NotificacaoAgendadaMomentoEnvio);
               n902NotificacaoAgendadaMomentoEnvio = (String.IsNullOrEmpty(StringUtil.RTrim( A902NotificacaoAgendadaMomentoEnvio)) ? true : false);
               cmbNotificacaoAgendadaTipo.CurrentValue = cgiGet( cmbNotificacaoAgendadaTipo_Internalname);
               A903NotificacaoAgendadaTipo = cgiGet( cmbNotificacaoAgendadaTipo_Internalname);
               n903NotificacaoAgendadaTipo = false;
               AssignAttri("", false, "A903NotificacaoAgendadaTipo", A903NotificacaoAgendadaTipo);
               n904NotificacaoAgendadaLayoutId = ((StringUtil.StrCmp(cgiGet( edtNotificacaoAgendadaLayoutId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaLayoutId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaLayoutId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NOTIFICACAOAGENDADALAYOUTID");
                  AnyError = 1;
                  GX_FocusControl = edtNotificacaoAgendadaLayoutId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A904NotificacaoAgendadaLayoutId = 0;
                  n904NotificacaoAgendadaLayoutId = false;
                  AssignAttri("", false, "A904NotificacaoAgendadaLayoutId", (n904NotificacaoAgendadaLayoutId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0, ".", ""))));
               }
               else
               {
                  A904NotificacaoAgendadaLayoutId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaLayoutId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A904NotificacaoAgendadaLayoutId", (n904NotificacaoAgendadaLayoutId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0, ".", ""))));
               }
               cmbNotificacaoAgendadaStatus.CurrentValue = cgiGet( cmbNotificacaoAgendadaStatus_Internalname);
               A905NotificacaoAgendadaStatus = StringUtil.StrToBool( cgiGet( cmbNotificacaoAgendadaStatus_Internalname));
               n905NotificacaoAgendadaStatus = false;
               AssignAttri("", false, "A905NotificacaoAgendadaStatus", A905NotificacaoAgendadaStatus);
               n905NotificacaoAgendadaStatus = ((false==A905NotificacaoAgendadaStatus) ? true : false);
               AV15ComboNotificacaoAgendadaLayoutId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombonotificacaoagendadalayoutid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15ComboNotificacaoAgendadaLayoutId", StringUtil.LTrimStr( (decimal)(AV15ComboNotificacaoAgendadaLayoutId), 4, 0));
               A898NotificacaoAgendadaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"NotificacaoAgendada");
               A899NotificacaoAgendadaOrigem = cgiGet( cmbNotificacaoAgendadaOrigem_Internalname);
               AssignAttri("", false, "A899NotificacaoAgendadaOrigem", A899NotificacaoAgendadaOrigem);
               forbiddenHiddens.Add("NotificacaoAgendadaOrigem", StringUtil.RTrim( context.localUtil.Format( A899NotificacaoAgendadaOrigem, "")));
               A903NotificacaoAgendadaTipo = cgiGet( cmbNotificacaoAgendadaTipo_Internalname);
               n903NotificacaoAgendadaTipo = false;
               AssignAttri("", false, "A903NotificacaoAgendadaTipo", A903NotificacaoAgendadaTipo);
               forbiddenHiddens.Add("NotificacaoAgendadaTipo", StringUtil.RTrim( context.localUtil.Format( A903NotificacaoAgendadaTipo, "")));
               A898NotificacaoAgendadaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
               forbiddenHiddens.Add("NotificacaoAgendadaId", context.localUtil.Format( (decimal)(A898NotificacaoAgendadaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_NotificacaoAgendadaLayoutId", context.localUtil.Format( (decimal)(AV11Insert_NotificacaoAgendadaLayoutId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A898NotificacaoAgendadaId != Z898NotificacaoAgendadaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("notificacaoagendada:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A898NotificacaoAgendadaId = (int)(Math.Round(NumberUtil.Val( GetPar( "NotificacaoAgendadaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
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
                     sMode98 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode98;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound98 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2U0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "NOTIFICACAOAGENDADAID");
                        AnyError = 1;
                        GX_FocusControl = edtNotificacaoAgendadaId_Internalname;
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
                           E112U2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122U2 ();
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
            E122U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2U98( ) ;
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
            DisableAttributes2U98( ) ;
         }
         AssignProp("", false, edtavCombonotificacaoagendadalayoutid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonotificacaoagendadalayoutid_Enabled), 5, 0), true);
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

      protected void CONFIRM_2U0( )
      {
         BeforeValidate2U98( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2U98( ) ;
            }
            else
            {
               CheckExtendedTable2U98( ) ;
               CloseExtendedTableCursors2U98( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2U0( )
      {
      }

      protected void E112U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         edtNotificacaoAgendadaLayoutId_Visible = 0;
         AssignProp("", false, edtNotificacaoAgendadaLayoutId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaLayoutId_Visible), 5, 0), true);
         AV15ComboNotificacaoAgendadaLayoutId = 0;
         AssignAttri("", false, "AV15ComboNotificacaoAgendadaLayoutId", StringUtil.LTrimStr( (decimal)(AV15ComboNotificacaoAgendadaLayoutId), 4, 0));
         edtavCombonotificacaoagendadalayoutid_Visible = 0;
         AssignProp("", false, edtavCombonotificacaoagendadalayoutid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombonotificacaoagendadalayoutid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBONOTIFICACAOAGENDADALAYOUTID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV17Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV18GXV1 = 1;
            AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            while ( AV18GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV18GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "NotificacaoAgendadaLayoutId") == 0 )
               {
                  AV11Insert_NotificacaoAgendadaLayoutId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_NotificacaoAgendadaLayoutId", StringUtil.LTrimStr( (decimal)(AV11Insert_NotificacaoAgendadaLayoutId), 4, 0));
                  if ( ! (0==AV11Insert_NotificacaoAgendadaLayoutId) )
                  {
                     AV15ComboNotificacaoAgendadaLayoutId = AV11Insert_NotificacaoAgendadaLayoutId;
                     AssignAttri("", false, "AV15ComboNotificacaoAgendadaLayoutId", StringUtil.LTrimStr( (decimal)(AV15ComboNotificacaoAgendadaLayoutId), 4, 0));
                     Combo_notificacaoagendadalayoutid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV15ComboNotificacaoAgendadaLayoutId), 4, 0));
                     ucCombo_notificacaoagendadalayoutid.SendProperty(context, "", false, Combo_notificacaoagendadalayoutid_Internalname, "SelectedValue_set", Combo_notificacaoagendadalayoutid_Selectedvalue_set);
                     Combo_notificacaoagendadalayoutid_Enabled = false;
                     ucCombo_notificacaoagendadalayoutid.SendProperty(context, "", false, Combo_notificacaoagendadalayoutid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_notificacaoagendadalayoutid_Enabled));
                  }
               }
               AV18GXV1 = (int)(AV18GXV1+1);
               AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            }
         }
         edtNotificacaoAgendadaId_Visible = 0;
         AssignProp("", false, edtNotificacaoAgendadaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaId_Visible), 5, 0), true);
      }

      protected void E122U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("notificacaoagendadaww") );
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
         /* 'LOADCOMBONOTIFICACAOAGENDADALAYOUTID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV13NotificacaoAgendadaLayoutId_Data;
         new notificacaoagendadaloaddvcombo(context ).execute(  "NotificacaoAgendadaLayoutId",  Gx_mode,  AV7NotificacaoAgendadaId, out  AV14ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AV13NotificacaoAgendadaLayoutId_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         Combo_notificacaoagendadalayoutid_Selectedvalue_set = AV14ComboSelectedValue;
         ucCombo_notificacaoagendadalayoutid.SendProperty(context, "", false, Combo_notificacaoagendadalayoutid_Internalname, "SelectedValue_set", Combo_notificacaoagendadalayoutid_Selectedvalue_set);
         AV15ComboNotificacaoAgendadaLayoutId = (short)(Math.Round(NumberUtil.Val( AV14ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV15ComboNotificacaoAgendadaLayoutId", StringUtil.LTrimStr( (decimal)(AV15ComboNotificacaoAgendadaLayoutId), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_notificacaoagendadalayoutid_Enabled = false;
            ucCombo_notificacaoagendadalayoutid.SendProperty(context, "", false, Combo_notificacaoagendadalayoutid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_notificacaoagendadalayoutid_Enabled));
         }
      }

      protected void ZM2U98( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z899NotificacaoAgendadaOrigem = T002U3_A899NotificacaoAgendadaOrigem[0];
               Z900NotificacaoAgendadaDescricao = T002U3_A900NotificacaoAgendadaDescricao[0];
               Z901NotificacaoAgendadaDias = T002U3_A901NotificacaoAgendadaDias[0];
               Z902NotificacaoAgendadaMomentoEnvio = T002U3_A902NotificacaoAgendadaMomentoEnvio[0];
               Z903NotificacaoAgendadaTipo = T002U3_A903NotificacaoAgendadaTipo[0];
               Z905NotificacaoAgendadaStatus = T002U3_A905NotificacaoAgendadaStatus[0];
               Z904NotificacaoAgendadaLayoutId = T002U3_A904NotificacaoAgendadaLayoutId[0];
            }
            else
            {
               Z899NotificacaoAgendadaOrigem = A899NotificacaoAgendadaOrigem;
               Z900NotificacaoAgendadaDescricao = A900NotificacaoAgendadaDescricao;
               Z901NotificacaoAgendadaDias = A901NotificacaoAgendadaDias;
               Z902NotificacaoAgendadaMomentoEnvio = A902NotificacaoAgendadaMomentoEnvio;
               Z903NotificacaoAgendadaTipo = A903NotificacaoAgendadaTipo;
               Z905NotificacaoAgendadaStatus = A905NotificacaoAgendadaStatus;
               Z904NotificacaoAgendadaLayoutId = A904NotificacaoAgendadaLayoutId;
            }
         }
         if ( GX_JID == -16 )
         {
            Z898NotificacaoAgendadaId = A898NotificacaoAgendadaId;
            Z899NotificacaoAgendadaOrigem = A899NotificacaoAgendadaOrigem;
            Z900NotificacaoAgendadaDescricao = A900NotificacaoAgendadaDescricao;
            Z901NotificacaoAgendadaDias = A901NotificacaoAgendadaDias;
            Z902NotificacaoAgendadaMomentoEnvio = A902NotificacaoAgendadaMomentoEnvio;
            Z903NotificacaoAgendadaTipo = A903NotificacaoAgendadaTipo;
            Z905NotificacaoAgendadaStatus = A905NotificacaoAgendadaStatus;
            Z904NotificacaoAgendadaLayoutId = A904NotificacaoAgendadaLayoutId;
         }
      }

      protected void standaloneNotModal( )
      {
         cmbNotificacaoAgendadaOrigem.Enabled = 0;
         AssignProp("", false, cmbNotificacaoAgendadaOrigem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificacaoAgendadaOrigem.Enabled), 5, 0), true);
         cmbNotificacaoAgendadaTipo.Enabled = 0;
         AssignProp("", false, cmbNotificacaoAgendadaTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificacaoAgendadaTipo.Enabled), 5, 0), true);
         edtNotificacaoAgendadaId_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaId_Enabled), 5, 0), true);
         AV17Pgmname = "NotificacaoAgendada";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         cmbNotificacaoAgendadaOrigem.Enabled = 0;
         AssignProp("", false, cmbNotificacaoAgendadaOrigem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificacaoAgendadaOrigem.Enabled), 5, 0), true);
         cmbNotificacaoAgendadaTipo.Enabled = 0;
         AssignProp("", false, cmbNotificacaoAgendadaTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificacaoAgendadaTipo.Enabled), 5, 0), true);
         edtNotificacaoAgendadaId_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7NotificacaoAgendadaId) )
         {
            A898NotificacaoAgendadaId = AV7NotificacaoAgendadaId;
            AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_NotificacaoAgendadaLayoutId) )
         {
            edtNotificacaoAgendadaLayoutId_Enabled = 0;
            AssignProp("", false, edtNotificacaoAgendadaLayoutId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaLayoutId_Enabled), 5, 0), true);
         }
         else
         {
            edtNotificacaoAgendadaLayoutId_Enabled = 1;
            AssignProp("", false, edtNotificacaoAgendadaLayoutId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaLayoutId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_NotificacaoAgendadaLayoutId) )
         {
            A904NotificacaoAgendadaLayoutId = AV11Insert_NotificacaoAgendadaLayoutId;
            n904NotificacaoAgendadaLayoutId = false;
            AssignAttri("", false, "A904NotificacaoAgendadaLayoutId", ((0==A904NotificacaoAgendadaLayoutId)&&IsIns( )||n904NotificacaoAgendadaLayoutId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV15ComboNotificacaoAgendadaLayoutId) )
            {
               A904NotificacaoAgendadaLayoutId = 0;
               n904NotificacaoAgendadaLayoutId = false;
               AssignAttri("", false, "A904NotificacaoAgendadaLayoutId", ((0==A904NotificacaoAgendadaLayoutId)&&IsIns( )||n904NotificacaoAgendadaLayoutId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0, ".", ""))));
               n904NotificacaoAgendadaLayoutId = true;
               n904NotificacaoAgendadaLayoutId = true;
               AssignAttri("", false, "A904NotificacaoAgendadaLayoutId", ((0==A904NotificacaoAgendadaLayoutId)&&IsIns( )||n904NotificacaoAgendadaLayoutId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV15ComboNotificacaoAgendadaLayoutId) )
               {
                  A904NotificacaoAgendadaLayoutId = AV15ComboNotificacaoAgendadaLayoutId;
                  n904NotificacaoAgendadaLayoutId = false;
                  AssignAttri("", false, "A904NotificacaoAgendadaLayoutId", ((0==A904NotificacaoAgendadaLayoutId)&&IsIns( )||n904NotificacaoAgendadaLayoutId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0, ".", ""))));
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
         if ( IsIns( )  && (false==A905NotificacaoAgendadaStatus) && ( Gx_BScreen == 0 ) )
         {
            A905NotificacaoAgendadaStatus = true;
            n905NotificacaoAgendadaStatus = false;
            AssignAttri("", false, "A905NotificacaoAgendadaStatus", A905NotificacaoAgendadaStatus);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load2U98( )
      {
         /* Using cursor T002U5 */
         pr_default.execute(3, new Object[] {A898NotificacaoAgendadaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound98 = 1;
            A899NotificacaoAgendadaOrigem = T002U5_A899NotificacaoAgendadaOrigem[0];
            AssignAttri("", false, "A899NotificacaoAgendadaOrigem", A899NotificacaoAgendadaOrigem);
            A900NotificacaoAgendadaDescricao = T002U5_A900NotificacaoAgendadaDescricao[0];
            AssignAttri("", false, "A900NotificacaoAgendadaDescricao", A900NotificacaoAgendadaDescricao);
            A901NotificacaoAgendadaDias = T002U5_A901NotificacaoAgendadaDias[0];
            n901NotificacaoAgendadaDias = T002U5_n901NotificacaoAgendadaDias[0];
            AssignAttri("", false, "A901NotificacaoAgendadaDias", ((0==A901NotificacaoAgendadaDias)&&IsIns( )||n901NotificacaoAgendadaDias ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A901NotificacaoAgendadaDias), 9, 0, ".", ""))));
            A902NotificacaoAgendadaMomentoEnvio = T002U5_A902NotificacaoAgendadaMomentoEnvio[0];
            n902NotificacaoAgendadaMomentoEnvio = T002U5_n902NotificacaoAgendadaMomentoEnvio[0];
            AssignAttri("", false, "A902NotificacaoAgendadaMomentoEnvio", A902NotificacaoAgendadaMomentoEnvio);
            A903NotificacaoAgendadaTipo = T002U5_A903NotificacaoAgendadaTipo[0];
            n903NotificacaoAgendadaTipo = T002U5_n903NotificacaoAgendadaTipo[0];
            AssignAttri("", false, "A903NotificacaoAgendadaTipo", A903NotificacaoAgendadaTipo);
            A905NotificacaoAgendadaStatus = T002U5_A905NotificacaoAgendadaStatus[0];
            n905NotificacaoAgendadaStatus = T002U5_n905NotificacaoAgendadaStatus[0];
            AssignAttri("", false, "A905NotificacaoAgendadaStatus", A905NotificacaoAgendadaStatus);
            A904NotificacaoAgendadaLayoutId = T002U5_A904NotificacaoAgendadaLayoutId[0];
            n904NotificacaoAgendadaLayoutId = T002U5_n904NotificacaoAgendadaLayoutId[0];
            AssignAttri("", false, "A904NotificacaoAgendadaLayoutId", ((0==A904NotificacaoAgendadaLayoutId)&&IsIns( )||n904NotificacaoAgendadaLayoutId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0, ".", ""))));
            ZM2U98( -16) ;
         }
         pr_default.close(3);
         OnLoadActions2U98( ) ;
      }

      protected void OnLoadActions2U98( )
      {
         A907NotificacaoAgendadaOffsetDias = ((StringUtil.StrCmp(A902NotificacaoAgendadaMomentoEnvio, "D")==0) ? A901NotificacaoAgendadaDias*-1 : A901NotificacaoAgendadaDias);
         AssignAttri("", false, "A907NotificacaoAgendadaOffsetDias", StringUtil.LTrimStr( (decimal)(A907NotificacaoAgendadaOffsetDias), 9, 0));
      }

      protected void CheckExtendedTable2U98( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A900NotificacaoAgendadaDescricao)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "NOTIFICACAOAGENDADADESCRICAO");
            AnyError = 1;
            GX_FocusControl = edtNotificacaoAgendadaDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A907NotificacaoAgendadaOffsetDias = ((StringUtil.StrCmp(A902NotificacaoAgendadaMomentoEnvio, "D")==0) ? A901NotificacaoAgendadaDias*-1 : A901NotificacaoAgendadaDias);
         AssignAttri("", false, "A907NotificacaoAgendadaOffsetDias", StringUtil.LTrimStr( (decimal)(A907NotificacaoAgendadaOffsetDias), 9, 0));
         if ( (0==A901NotificacaoAgendadaDias) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Quantidade de dias", "", "", "", "", "", "", "", ""), 1, "NOTIFICACAOAGENDADADIAS");
            AnyError = 1;
            GX_FocusControl = edtNotificacaoAgendadaDias_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A902NotificacaoAgendadaMomentoEnvio, "A") == 0 ) || ( StringUtil.StrCmp(A902NotificacaoAgendadaMomentoEnvio, "D") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A902NotificacaoAgendadaMomentoEnvio)) ) )
         {
            GX_msglist.addItem("Campo Momento do Envio fora do intervalo", "OutOfRange", 1, "NOTIFICACAOAGENDADAMOMENTOENVIO");
            AnyError = 1;
            GX_FocusControl = cmbNotificacaoAgendadaMomentoEnvio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002U4 */
         pr_default.execute(2, new Object[] {n904NotificacaoAgendadaLayoutId, A904NotificacaoAgendadaLayoutId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A904NotificacaoAgendadaLayoutId) ) )
            {
               GX_msglist.addItem("Não existe 'Layout da Notificação Agendada'.", "ForeignKeyNotFound", 1, "NOTIFICACAOAGENDADALAYOUTID");
               AnyError = 1;
               GX_FocusControl = edtNotificacaoAgendadaLayoutId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         if ( (0==A904NotificacaoAgendadaLayoutId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Layout de Envio", "", "", "", "", "", "", "", ""), 1, "NOTIFICACAOAGENDADALAYOUTID");
            AnyError = 1;
            GX_FocusControl = edtNotificacaoAgendadaLayoutId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2U98( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( short A904NotificacaoAgendadaLayoutId )
      {
         /* Using cursor T002U6 */
         pr_default.execute(4, new Object[] {n904NotificacaoAgendadaLayoutId, A904NotificacaoAgendadaLayoutId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A904NotificacaoAgendadaLayoutId) ) )
            {
               GX_msglist.addItem("Não existe 'Layout da Notificação Agendada'.", "ForeignKeyNotFound", 1, "NOTIFICACAOAGENDADALAYOUTID");
               AnyError = 1;
               GX_FocusControl = edtNotificacaoAgendadaLayoutId_Internalname;
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

      protected void GetKey2U98( )
      {
         /* Using cursor T002U7 */
         pr_default.execute(5, new Object[] {A898NotificacaoAgendadaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound98 = 1;
         }
         else
         {
            RcdFound98 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002U3 */
         pr_default.execute(1, new Object[] {A898NotificacaoAgendadaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2U98( 16) ;
            RcdFound98 = 1;
            A898NotificacaoAgendadaId = T002U3_A898NotificacaoAgendadaId[0];
            AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
            A899NotificacaoAgendadaOrigem = T002U3_A899NotificacaoAgendadaOrigem[0];
            AssignAttri("", false, "A899NotificacaoAgendadaOrigem", A899NotificacaoAgendadaOrigem);
            A900NotificacaoAgendadaDescricao = T002U3_A900NotificacaoAgendadaDescricao[0];
            AssignAttri("", false, "A900NotificacaoAgendadaDescricao", A900NotificacaoAgendadaDescricao);
            A901NotificacaoAgendadaDias = T002U3_A901NotificacaoAgendadaDias[0];
            n901NotificacaoAgendadaDias = T002U3_n901NotificacaoAgendadaDias[0];
            AssignAttri("", false, "A901NotificacaoAgendadaDias", ((0==A901NotificacaoAgendadaDias)&&IsIns( )||n901NotificacaoAgendadaDias ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A901NotificacaoAgendadaDias), 9, 0, ".", ""))));
            A902NotificacaoAgendadaMomentoEnvio = T002U3_A902NotificacaoAgendadaMomentoEnvio[0];
            n902NotificacaoAgendadaMomentoEnvio = T002U3_n902NotificacaoAgendadaMomentoEnvio[0];
            AssignAttri("", false, "A902NotificacaoAgendadaMomentoEnvio", A902NotificacaoAgendadaMomentoEnvio);
            A903NotificacaoAgendadaTipo = T002U3_A903NotificacaoAgendadaTipo[0];
            n903NotificacaoAgendadaTipo = T002U3_n903NotificacaoAgendadaTipo[0];
            AssignAttri("", false, "A903NotificacaoAgendadaTipo", A903NotificacaoAgendadaTipo);
            A905NotificacaoAgendadaStatus = T002U3_A905NotificacaoAgendadaStatus[0];
            n905NotificacaoAgendadaStatus = T002U3_n905NotificacaoAgendadaStatus[0];
            AssignAttri("", false, "A905NotificacaoAgendadaStatus", A905NotificacaoAgendadaStatus);
            A904NotificacaoAgendadaLayoutId = T002U3_A904NotificacaoAgendadaLayoutId[0];
            n904NotificacaoAgendadaLayoutId = T002U3_n904NotificacaoAgendadaLayoutId[0];
            AssignAttri("", false, "A904NotificacaoAgendadaLayoutId", ((0==A904NotificacaoAgendadaLayoutId)&&IsIns( )||n904NotificacaoAgendadaLayoutId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0, ".", ""))));
            Z898NotificacaoAgendadaId = A898NotificacaoAgendadaId;
            sMode98 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2U98( ) ;
            if ( AnyError == 1 )
            {
               RcdFound98 = 0;
               InitializeNonKey2U98( ) ;
            }
            Gx_mode = sMode98;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound98 = 0;
            InitializeNonKey2U98( ) ;
            sMode98 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode98;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2U98( ) ;
         if ( RcdFound98 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound98 = 0;
         /* Using cursor T002U8 */
         pr_default.execute(6, new Object[] {A898NotificacaoAgendadaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T002U8_A898NotificacaoAgendadaId[0] < A898NotificacaoAgendadaId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T002U8_A898NotificacaoAgendadaId[0] > A898NotificacaoAgendadaId ) ) )
            {
               A898NotificacaoAgendadaId = T002U8_A898NotificacaoAgendadaId[0];
               AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
               RcdFound98 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound98 = 0;
         /* Using cursor T002U9 */
         pr_default.execute(7, new Object[] {A898NotificacaoAgendadaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T002U9_A898NotificacaoAgendadaId[0] > A898NotificacaoAgendadaId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T002U9_A898NotificacaoAgendadaId[0] < A898NotificacaoAgendadaId ) ) )
            {
               A898NotificacaoAgendadaId = T002U9_A898NotificacaoAgendadaId[0];
               AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
               RcdFound98 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2U98( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNotificacaoAgendadaDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2U98( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound98 == 1 )
            {
               if ( A898NotificacaoAgendadaId != Z898NotificacaoAgendadaId )
               {
                  A898NotificacaoAgendadaId = Z898NotificacaoAgendadaId;
                  AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "NOTIFICACAOAGENDADAID");
                  AnyError = 1;
                  GX_FocusControl = edtNotificacaoAgendadaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNotificacaoAgendadaDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2U98( ) ;
                  GX_FocusControl = edtNotificacaoAgendadaDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A898NotificacaoAgendadaId != Z898NotificacaoAgendadaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtNotificacaoAgendadaDescricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2U98( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "NOTIFICACAOAGENDADAID");
                     AnyError = 1;
                     GX_FocusControl = edtNotificacaoAgendadaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtNotificacaoAgendadaDescricao_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2U98( ) ;
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
         if ( A898NotificacaoAgendadaId != Z898NotificacaoAgendadaId )
         {
            A898NotificacaoAgendadaId = Z898NotificacaoAgendadaId;
            AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "NOTIFICACAOAGENDADAID");
            AnyError = 1;
            GX_FocusControl = edtNotificacaoAgendadaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNotificacaoAgendadaDescricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2U98( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002U2 */
            pr_default.execute(0, new Object[] {A898NotificacaoAgendadaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotificacaoAgendada"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z899NotificacaoAgendadaOrigem, T002U2_A899NotificacaoAgendadaOrigem[0]) != 0 ) || ( StringUtil.StrCmp(Z900NotificacaoAgendadaDescricao, T002U2_A900NotificacaoAgendadaDescricao[0]) != 0 ) || ( Z901NotificacaoAgendadaDias != T002U2_A901NotificacaoAgendadaDias[0] ) || ( StringUtil.StrCmp(Z902NotificacaoAgendadaMomentoEnvio, T002U2_A902NotificacaoAgendadaMomentoEnvio[0]) != 0 ) || ( StringUtil.StrCmp(Z903NotificacaoAgendadaTipo, T002U2_A903NotificacaoAgendadaTipo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z905NotificacaoAgendadaStatus != T002U2_A905NotificacaoAgendadaStatus[0] ) || ( Z904NotificacaoAgendadaLayoutId != T002U2_A904NotificacaoAgendadaLayoutId[0] ) )
            {
               if ( StringUtil.StrCmp(Z899NotificacaoAgendadaOrigem, T002U2_A899NotificacaoAgendadaOrigem[0]) != 0 )
               {
                  GXUtil.WriteLog("notificacaoagendada:[seudo value changed for attri]"+"NotificacaoAgendadaOrigem");
                  GXUtil.WriteLogRaw("Old: ",Z899NotificacaoAgendadaOrigem);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A899NotificacaoAgendadaOrigem[0]);
               }
               if ( StringUtil.StrCmp(Z900NotificacaoAgendadaDescricao, T002U2_A900NotificacaoAgendadaDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("notificacaoagendada:[seudo value changed for attri]"+"NotificacaoAgendadaDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z900NotificacaoAgendadaDescricao);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A900NotificacaoAgendadaDescricao[0]);
               }
               if ( Z901NotificacaoAgendadaDias != T002U2_A901NotificacaoAgendadaDias[0] )
               {
                  GXUtil.WriteLog("notificacaoagendada:[seudo value changed for attri]"+"NotificacaoAgendadaDias");
                  GXUtil.WriteLogRaw("Old: ",Z901NotificacaoAgendadaDias);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A901NotificacaoAgendadaDias[0]);
               }
               if ( StringUtil.StrCmp(Z902NotificacaoAgendadaMomentoEnvio, T002U2_A902NotificacaoAgendadaMomentoEnvio[0]) != 0 )
               {
                  GXUtil.WriteLog("notificacaoagendada:[seudo value changed for attri]"+"NotificacaoAgendadaMomentoEnvio");
                  GXUtil.WriteLogRaw("Old: ",Z902NotificacaoAgendadaMomentoEnvio);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A902NotificacaoAgendadaMomentoEnvio[0]);
               }
               if ( StringUtil.StrCmp(Z903NotificacaoAgendadaTipo, T002U2_A903NotificacaoAgendadaTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("notificacaoagendada:[seudo value changed for attri]"+"NotificacaoAgendadaTipo");
                  GXUtil.WriteLogRaw("Old: ",Z903NotificacaoAgendadaTipo);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A903NotificacaoAgendadaTipo[0]);
               }
               if ( Z905NotificacaoAgendadaStatus != T002U2_A905NotificacaoAgendadaStatus[0] )
               {
                  GXUtil.WriteLog("notificacaoagendada:[seudo value changed for attri]"+"NotificacaoAgendadaStatus");
                  GXUtil.WriteLogRaw("Old: ",Z905NotificacaoAgendadaStatus);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A905NotificacaoAgendadaStatus[0]);
               }
               if ( Z904NotificacaoAgendadaLayoutId != T002U2_A904NotificacaoAgendadaLayoutId[0] )
               {
                  GXUtil.WriteLog("notificacaoagendada:[seudo value changed for attri]"+"NotificacaoAgendadaLayoutId");
                  GXUtil.WriteLogRaw("Old: ",Z904NotificacaoAgendadaLayoutId);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A904NotificacaoAgendadaLayoutId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotificacaoAgendada"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2U98( )
      {
         BeforeValidate2U98( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2U98( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2U98( 0) ;
            CheckOptimisticConcurrency2U98( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2U98( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2U98( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002U10 */
                     pr_default.execute(8, new Object[] {A899NotificacaoAgendadaOrigem, A900NotificacaoAgendadaDescricao, n901NotificacaoAgendadaDias, A901NotificacaoAgendadaDias, n902NotificacaoAgendadaMomentoEnvio, A902NotificacaoAgendadaMomentoEnvio, n903NotificacaoAgendadaTipo, A903NotificacaoAgendadaTipo, n905NotificacaoAgendadaStatus, A905NotificacaoAgendadaStatus, n904NotificacaoAgendadaLayoutId, A904NotificacaoAgendadaLayoutId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002U11 */
                     pr_default.execute(9);
                     A898NotificacaoAgendadaId = T002U11_A898NotificacaoAgendadaId[0];
                     AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendada");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2U0( ) ;
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
               Load2U98( ) ;
            }
            EndLevel2U98( ) ;
         }
         CloseExtendedTableCursors2U98( ) ;
      }

      protected void Update2U98( )
      {
         BeforeValidate2U98( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2U98( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2U98( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2U98( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2U98( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002U12 */
                     pr_default.execute(10, new Object[] {A899NotificacaoAgendadaOrigem, A900NotificacaoAgendadaDescricao, n901NotificacaoAgendadaDias, A901NotificacaoAgendadaDias, n902NotificacaoAgendadaMomentoEnvio, A902NotificacaoAgendadaMomentoEnvio, n903NotificacaoAgendadaTipo, A903NotificacaoAgendadaTipo, n905NotificacaoAgendadaStatus, A905NotificacaoAgendadaStatus, n904NotificacaoAgendadaLayoutId, A904NotificacaoAgendadaLayoutId, A898NotificacaoAgendadaId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendada");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotificacaoAgendada"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2U98( ) ;
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
            EndLevel2U98( ) ;
         }
         CloseExtendedTableCursors2U98( ) ;
      }

      protected void DeferredUpdate2U98( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2U98( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2U98( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2U98( ) ;
            AfterConfirm2U98( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2U98( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002U13 */
                  pr_default.execute(11, new Object[] {A898NotificacaoAgendadaId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendada");
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
         sMode98 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2U98( ) ;
         Gx_mode = sMode98;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2U98( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A907NotificacaoAgendadaOffsetDias = ((StringUtil.StrCmp(A902NotificacaoAgendadaMomentoEnvio, "D")==0) ? A901NotificacaoAgendadaDias*-1 : A901NotificacaoAgendadaDias);
            AssignAttri("", false, "A907NotificacaoAgendadaOffsetDias", StringUtil.LTrimStr( (decimal)(A907NotificacaoAgendadaOffsetDias), 9, 0));
         }
      }

      protected void EndLevel2U98( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2U98( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("notificacaoagendada",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("notificacaoagendada",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2U98( )
      {
         /* Scan By routine */
         /* Using cursor T002U14 */
         pr_default.execute(12);
         RcdFound98 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound98 = 1;
            A898NotificacaoAgendadaId = T002U14_A898NotificacaoAgendadaId[0];
            AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2U98( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound98 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound98 = 1;
            A898NotificacaoAgendadaId = T002U14_A898NotificacaoAgendadaId[0];
            AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
         }
      }

      protected void ScanEnd2U98( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm2U98( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2U98( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2U98( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2U98( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2U98( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2U98( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2U98( )
      {
         cmbNotificacaoAgendadaOrigem.Enabled = 0;
         AssignProp("", false, cmbNotificacaoAgendadaOrigem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificacaoAgendadaOrigem.Enabled), 5, 0), true);
         edtNotificacaoAgendadaDescricao_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaDescricao_Enabled), 5, 0), true);
         edtNotificacaoAgendadaDias_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaDias_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaDias_Enabled), 5, 0), true);
         cmbNotificacaoAgendadaMomentoEnvio.Enabled = 0;
         AssignProp("", false, cmbNotificacaoAgendadaMomentoEnvio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificacaoAgendadaMomentoEnvio.Enabled), 5, 0), true);
         cmbNotificacaoAgendadaTipo.Enabled = 0;
         AssignProp("", false, cmbNotificacaoAgendadaTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificacaoAgendadaTipo.Enabled), 5, 0), true);
         edtNotificacaoAgendadaLayoutId_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaLayoutId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaLayoutId_Enabled), 5, 0), true);
         cmbNotificacaoAgendadaStatus.Enabled = 0;
         AssignProp("", false, cmbNotificacaoAgendadaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNotificacaoAgendadaStatus.Enabled), 5, 0), true);
         edtavCombonotificacaoagendadalayoutid_Enabled = 0;
         AssignProp("", false, edtavCombonotificacaoagendadalayoutid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonotificacaoagendadalayoutid_Enabled), 5, 0), true);
         edtNotificacaoAgendadaId_Enabled = 0;
         AssignProp("", false, edtNotificacaoAgendadaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNotificacaoAgendadaId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2U98( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2U0( )
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
         GXEncryptionTmp = "notificacaoagendada"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7NotificacaoAgendadaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("notificacaoagendada") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"NotificacaoAgendada");
         forbiddenHiddens.Add("NotificacaoAgendadaOrigem", StringUtil.RTrim( context.localUtil.Format( A899NotificacaoAgendadaOrigem, "")));
         forbiddenHiddens.Add("NotificacaoAgendadaTipo", StringUtil.RTrim( context.localUtil.Format( A903NotificacaoAgendadaTipo, "")));
         forbiddenHiddens.Add("NotificacaoAgendadaId", context.localUtil.Format( (decimal)(A898NotificacaoAgendadaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_NotificacaoAgendadaLayoutId", context.localUtil.Format( (decimal)(AV11Insert_NotificacaoAgendadaLayoutId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("notificacaoagendada:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z898NotificacaoAgendadaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z898NotificacaoAgendadaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z899NotificacaoAgendadaOrigem", Z899NotificacaoAgendadaOrigem);
         GxWebStd.gx_hidden_field( context, "Z900NotificacaoAgendadaDescricao", Z900NotificacaoAgendadaDescricao);
         GxWebStd.gx_hidden_field( context, "Z901NotificacaoAgendadaDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z901NotificacaoAgendadaDias), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z902NotificacaoAgendadaMomentoEnvio", Z902NotificacaoAgendadaMomentoEnvio);
         GxWebStd.gx_hidden_field( context, "Z903NotificacaoAgendadaTipo", Z903NotificacaoAgendadaTipo);
         GxWebStd.gx_boolean_hidden_field( context, "Z905NotificacaoAgendadaStatus", Z905NotificacaoAgendadaStatus);
         GxWebStd.gx_hidden_field( context, "Z904NotificacaoAgendadaLayoutId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z904NotificacaoAgendadaLayoutId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N904NotificacaoAgendadaLayoutId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTIFICACAOAGENDADALAYOUTID_DATA", AV13NotificacaoAgendadaLayoutId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICACAOAGENDADALAYOUTID_DATA", AV13NotificacaoAgendadaLayoutId_Data);
         }
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
         GxWebStd.gx_hidden_field( context, "NOTIFICACAOAGENDADAOFFSETDIAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A907NotificacaoAgendadaOffsetDias), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vNOTIFICACAOAGENDADAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7NotificacaoAgendadaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTIFICACAOAGENDADAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7NotificacaoAgendadaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_NOTIFICACAOAGENDADALAYOUTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_NotificacaoAgendadaLayoutId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV17Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_NOTIFICACAOAGENDADALAYOUTID_Objectcall", StringUtil.RTrim( Combo_notificacaoagendadalayoutid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_NOTIFICACAOAGENDADALAYOUTID_Cls", StringUtil.RTrim( Combo_notificacaoagendadalayoutid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_NOTIFICACAOAGENDADALAYOUTID_Selectedvalue_set", StringUtil.RTrim( Combo_notificacaoagendadalayoutid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NOTIFICACAOAGENDADALAYOUTID_Enabled", StringUtil.BoolToStr( Combo_notificacaoagendadalayoutid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_NOTIFICACAOAGENDADALAYOUTID_Emptyitem", StringUtil.BoolToStr( Combo_notificacaoagendadalayoutid_Emptyitem));
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
         GXEncryptionTmp = "notificacaoagendada"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7NotificacaoAgendadaId,9,0));
         return formatLink("notificacaoagendada") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "NotificacaoAgendada" ;
      }

      public override string GetPgmdesc( )
      {
         return "Agendar Notificação" ;
      }

      protected void InitializeNonKey2U98( )
      {
         A904NotificacaoAgendadaLayoutId = 0;
         n904NotificacaoAgendadaLayoutId = false;
         AssignAttri("", false, "A904NotificacaoAgendadaLayoutId", ((0==A904NotificacaoAgendadaLayoutId)&&IsIns( )||n904NotificacaoAgendadaLayoutId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A904NotificacaoAgendadaLayoutId), 4, 0, ".", ""))));
         n904NotificacaoAgendadaLayoutId = ((0==A904NotificacaoAgendadaLayoutId) ? true : false);
         A907NotificacaoAgendadaOffsetDias = 0;
         AssignAttri("", false, "A907NotificacaoAgendadaOffsetDias", StringUtil.LTrimStr( (decimal)(A907NotificacaoAgendadaOffsetDias), 9, 0));
         A899NotificacaoAgendadaOrigem = "";
         AssignAttri("", false, "A899NotificacaoAgendadaOrigem", A899NotificacaoAgendadaOrigem);
         A900NotificacaoAgendadaDescricao = "";
         AssignAttri("", false, "A900NotificacaoAgendadaDescricao", A900NotificacaoAgendadaDescricao);
         A901NotificacaoAgendadaDias = 0;
         n901NotificacaoAgendadaDias = false;
         AssignAttri("", false, "A901NotificacaoAgendadaDias", ((0==A901NotificacaoAgendadaDias)&&IsIns( )||n901NotificacaoAgendadaDias ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A901NotificacaoAgendadaDias), 9, 0, ".", ""))));
         n901NotificacaoAgendadaDias = ((0==A901NotificacaoAgendadaDias) ? true : false);
         A902NotificacaoAgendadaMomentoEnvio = "";
         n902NotificacaoAgendadaMomentoEnvio = false;
         AssignAttri("", false, "A902NotificacaoAgendadaMomentoEnvio", A902NotificacaoAgendadaMomentoEnvio);
         n902NotificacaoAgendadaMomentoEnvio = (String.IsNullOrEmpty(StringUtil.RTrim( A902NotificacaoAgendadaMomentoEnvio)) ? true : false);
         A903NotificacaoAgendadaTipo = "";
         n903NotificacaoAgendadaTipo = false;
         AssignAttri("", false, "A903NotificacaoAgendadaTipo", A903NotificacaoAgendadaTipo);
         n903NotificacaoAgendadaTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A903NotificacaoAgendadaTipo)) ? true : false);
         A905NotificacaoAgendadaStatus = true;
         n905NotificacaoAgendadaStatus = false;
         AssignAttri("", false, "A905NotificacaoAgendadaStatus", A905NotificacaoAgendadaStatus);
         Z899NotificacaoAgendadaOrigem = "";
         Z900NotificacaoAgendadaDescricao = "";
         Z901NotificacaoAgendadaDias = 0;
         Z902NotificacaoAgendadaMomentoEnvio = "";
         Z903NotificacaoAgendadaTipo = "";
         Z905NotificacaoAgendadaStatus = false;
         Z904NotificacaoAgendadaLayoutId = 0;
      }

      protected void InitAll2U98( )
      {
         A898NotificacaoAgendadaId = 0;
         AssignAttri("", false, "A898NotificacaoAgendadaId", StringUtil.LTrimStr( (decimal)(A898NotificacaoAgendadaId), 9, 0));
         InitializeNonKey2U98( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A905NotificacaoAgendadaStatus = i905NotificacaoAgendadaStatus;
         n905NotificacaoAgendadaStatus = false;
         AssignAttri("", false, "A905NotificacaoAgendadaStatus", A905NotificacaoAgendadaStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101921424", true, true);
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
         context.AddJavascriptSource("notificacaoagendada.js", "?20256101921425", false, true);
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
         cmbNotificacaoAgendadaOrigem_Internalname = "NOTIFICACAOAGENDADAORIGEM";
         edtNotificacaoAgendadaDescricao_Internalname = "NOTIFICACAOAGENDADADESCRICAO";
         edtNotificacaoAgendadaDias_Internalname = "NOTIFICACAOAGENDADADIAS";
         cmbNotificacaoAgendadaMomentoEnvio_Internalname = "NOTIFICACAOAGENDADAMOMENTOENVIO";
         cmbNotificacaoAgendadaTipo_Internalname = "NOTIFICACAOAGENDADATIPO";
         lblTextblocknotificacaoagendadalayoutid_Internalname = "TEXTBLOCKNOTIFICACAOAGENDADALAYOUTID";
         Combo_notificacaoagendadalayoutid_Internalname = "COMBO_NOTIFICACAOAGENDADALAYOUTID";
         edtNotificacaoAgendadaLayoutId_Internalname = "NOTIFICACAOAGENDADALAYOUTID";
         divTablesplittednotificacaoagendadalayoutid_Internalname = "TABLESPLITTEDNOTIFICACAOAGENDADALAYOUTID";
         cmbNotificacaoAgendadaStatus_Internalname = "NOTIFICACAOAGENDADASTATUS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombonotificacaoagendadalayoutid_Internalname = "vCOMBONOTIFICACAOAGENDADALAYOUTID";
         divSectionattribute_notificacaoagendadalayoutid_Internalname = "SECTIONATTRIBUTE_NOTIFICACAOAGENDADALAYOUTID";
         edtNotificacaoAgendadaId_Internalname = "NOTIFICACAOAGENDADAID";
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
         Form.Caption = "Agendar Notificação";
         edtNotificacaoAgendadaId_Jsonclick = "";
         edtNotificacaoAgendadaId_Enabled = 0;
         edtNotificacaoAgendadaId_Visible = 1;
         edtavCombonotificacaoagendadalayoutid_Jsonclick = "";
         edtavCombonotificacaoagendadalayoutid_Enabled = 0;
         edtavCombonotificacaoagendadalayoutid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbNotificacaoAgendadaStatus_Jsonclick = "";
         cmbNotificacaoAgendadaStatus.Enabled = 1;
         edtNotificacaoAgendadaLayoutId_Jsonclick = "";
         edtNotificacaoAgendadaLayoutId_Enabled = 1;
         edtNotificacaoAgendadaLayoutId_Visible = 1;
         Combo_notificacaoagendadalayoutid_Emptyitem = Convert.ToBoolean( 0);
         Combo_notificacaoagendadalayoutid_Cls = "ExtendedCombo AttributeFL";
         Combo_notificacaoagendadalayoutid_Enabled = Convert.ToBoolean( -1);
         cmbNotificacaoAgendadaTipo_Jsonclick = "";
         cmbNotificacaoAgendadaTipo.Enabled = 0;
         cmbNotificacaoAgendadaMomentoEnvio_Jsonclick = "";
         cmbNotificacaoAgendadaMomentoEnvio.Enabled = 1;
         edtNotificacaoAgendadaDias_Jsonclick = "";
         edtNotificacaoAgendadaDias_Enabled = 1;
         edtNotificacaoAgendadaDescricao_Jsonclick = "";
         edtNotificacaoAgendadaDescricao_Enabled = 1;
         cmbNotificacaoAgendadaOrigem_Jsonclick = "";
         cmbNotificacaoAgendadaOrigem.Enabled = 0;
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
         cmbNotificacaoAgendadaOrigem.Name = "NOTIFICACAOAGENDADAORIGEM";
         cmbNotificacaoAgendadaOrigem.WebTags = "";
         cmbNotificacaoAgendadaOrigem.addItem("R", "Título a receber", 0);
         if ( cmbNotificacaoAgendadaOrigem.ItemCount > 0 )
         {
            A899NotificacaoAgendadaOrigem = cmbNotificacaoAgendadaOrigem.getValidValue(A899NotificacaoAgendadaOrigem);
            AssignAttri("", false, "A899NotificacaoAgendadaOrigem", A899NotificacaoAgendadaOrigem);
         }
         cmbNotificacaoAgendadaMomentoEnvio.Name = "NOTIFICACAOAGENDADAMOMENTOENVIO";
         cmbNotificacaoAgendadaMomentoEnvio.WebTags = "";
         cmbNotificacaoAgendadaMomentoEnvio.addItem("A", "Antes", 0);
         cmbNotificacaoAgendadaMomentoEnvio.addItem("D", "Depois", 0);
         if ( cmbNotificacaoAgendadaMomentoEnvio.ItemCount > 0 )
         {
            A902NotificacaoAgendadaMomentoEnvio = cmbNotificacaoAgendadaMomentoEnvio.getValidValue(A902NotificacaoAgendadaMomentoEnvio);
            n902NotificacaoAgendadaMomentoEnvio = false;
            AssignAttri("", false, "A902NotificacaoAgendadaMomentoEnvio", A902NotificacaoAgendadaMomentoEnvio);
         }
         cmbNotificacaoAgendadaTipo.Name = "NOTIFICACAOAGENDADATIPO";
         cmbNotificacaoAgendadaTipo.WebTags = "";
         cmbNotificacaoAgendadaTipo.addItem("E", "Email", 0);
         if ( cmbNotificacaoAgendadaTipo.ItemCount > 0 )
         {
            A903NotificacaoAgendadaTipo = cmbNotificacaoAgendadaTipo.getValidValue(A903NotificacaoAgendadaTipo);
            n903NotificacaoAgendadaTipo = false;
            AssignAttri("", false, "A903NotificacaoAgendadaTipo", A903NotificacaoAgendadaTipo);
         }
         cmbNotificacaoAgendadaStatus.Name = "NOTIFICACAOAGENDADASTATUS";
         cmbNotificacaoAgendadaStatus.WebTags = "";
         cmbNotificacaoAgendadaStatus.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbNotificacaoAgendadaStatus.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbNotificacaoAgendadaStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A905NotificacaoAgendadaStatus) )
            {
               A905NotificacaoAgendadaStatus = true;
               n905NotificacaoAgendadaStatus = false;
               AssignAttri("", false, "A905NotificacaoAgendadaStatus", A905NotificacaoAgendadaStatus);
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

      public void Valid_Notificacaoagendadalayoutid( )
      {
         /* Using cursor T002U15 */
         pr_default.execute(13, new Object[] {n904NotificacaoAgendadaLayoutId, A904NotificacaoAgendadaLayoutId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A904NotificacaoAgendadaLayoutId) ) )
            {
               GX_msglist.addItem("Não existe 'Layout da Notificação Agendada'.", "ForeignKeyNotFound", 1, "NOTIFICACAOAGENDADALAYOUTID");
               AnyError = 1;
               GX_FocusControl = edtNotificacaoAgendadaLayoutId_Internalname;
            }
         }
         pr_default.close(13);
         if ( (0==A904NotificacaoAgendadaLayoutId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Layout de Envio", "", "", "", "", "", "", "", ""), 1, "NOTIFICACAOAGENDADALAYOUTID");
            AnyError = 1;
            GX_FocusControl = edtNotificacaoAgendadaLayoutId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7NotificacaoAgendadaId","fld":"vNOTIFICACAOAGENDADAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7NotificacaoAgendadaId","fld":"vNOTIFICACAOAGENDADAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"cmbNotificacaoAgendadaOrigem"},{"av":"A899NotificacaoAgendadaOrigem","fld":"NOTIFICACAOAGENDADAORIGEM","type":"svchar"},{"av":"cmbNotificacaoAgendadaTipo"},{"av":"A903NotificacaoAgendadaTipo","fld":"NOTIFICACAOAGENDADATIPO","type":"svchar"},{"av":"A898NotificacaoAgendadaId","fld":"NOTIFICACAOAGENDADAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_NotificacaoAgendadaLayoutId","fld":"vINSERT_NOTIFICACAOAGENDADALAYOUTID","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122U2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_NOTIFICACAOAGENDADADESCRICAO","""{"handler":"Valid_Notificacaoagendadadescricao","iparms":[]}""");
         setEventMetadata("VALID_NOTIFICACAOAGENDADADIAS","""{"handler":"Valid_Notificacaoagendadadias","iparms":[]}""");
         setEventMetadata("VALID_NOTIFICACAOAGENDADAMOMENTOENVIO","""{"handler":"Valid_Notificacaoagendadamomentoenvio","iparms":[]}""");
         setEventMetadata("VALID_NOTIFICACAOAGENDADALAYOUTID","""{"handler":"Valid_Notificacaoagendadalayoutid","iparms":[{"av":"A904NotificacaoAgendadaLayoutId","fld":"NOTIFICACAOAGENDADALAYOUTID","pic":"ZZZ9","nullAv":"n904NotificacaoAgendadaLayoutId","type":"int"}]}""");
         setEventMetadata("VALIDV_COMBONOTIFICACAOAGENDADALAYOUTID","""{"handler":"Validv_Combonotificacaoagendadalayoutid","iparms":[]}""");
         setEventMetadata("VALID_NOTIFICACAOAGENDADAID","""{"handler":"Valid_Notificacaoagendadaid","iparms":[]}""");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z899NotificacaoAgendadaOrigem = "";
         Z900NotificacaoAgendadaDescricao = "";
         Z902NotificacaoAgendadaMomentoEnvio = "";
         Z903NotificacaoAgendadaTipo = "";
         Combo_notificacaoagendadalayoutid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A899NotificacaoAgendadaOrigem = "";
         A902NotificacaoAgendadaMomentoEnvio = "";
         A903NotificacaoAgendadaTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A900NotificacaoAgendadaDescricao = "";
         lblTextblocknotificacaoagendadalayoutid_Jsonclick = "";
         ucCombo_notificacaoagendadalayoutid = new GXUserControl();
         Combo_notificacaoagendadalayoutid_Caption = "";
         AV13NotificacaoAgendadaLayoutId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV17Pgmname = "";
         Combo_notificacaoagendadalayoutid_Objectcall = "";
         Combo_notificacaoagendadalayoutid_Class = "";
         Combo_notificacaoagendadalayoutid_Icontype = "";
         Combo_notificacaoagendadalayoutid_Icon = "";
         Combo_notificacaoagendadalayoutid_Tooltip = "";
         Combo_notificacaoagendadalayoutid_Selectedvalue_set = "";
         Combo_notificacaoagendadalayoutid_Selectedtext_set = "";
         Combo_notificacaoagendadalayoutid_Selectedtext_get = "";
         Combo_notificacaoagendadalayoutid_Gamoauthtoken = "";
         Combo_notificacaoagendadalayoutid_Ddointernalname = "";
         Combo_notificacaoagendadalayoutid_Titlecontrolalign = "";
         Combo_notificacaoagendadalayoutid_Dropdownoptionstype = "";
         Combo_notificacaoagendadalayoutid_Titlecontrolidtoreplace = "";
         Combo_notificacaoagendadalayoutid_Datalisttype = "";
         Combo_notificacaoagendadalayoutid_Datalistfixedvalues = "";
         Combo_notificacaoagendadalayoutid_Datalistproc = "";
         Combo_notificacaoagendadalayoutid_Datalistprocparametersprefix = "";
         Combo_notificacaoagendadalayoutid_Remoteservicesparameters = "";
         Combo_notificacaoagendadalayoutid_Htmltemplate = "";
         Combo_notificacaoagendadalayoutid_Multiplevaluestype = "";
         Combo_notificacaoagendadalayoutid_Loadingdata = "";
         Combo_notificacaoagendadalayoutid_Noresultsfound = "";
         Combo_notificacaoagendadalayoutid_Emptyitemtext = "";
         Combo_notificacaoagendadalayoutid_Onlyselectedvalues = "";
         Combo_notificacaoagendadalayoutid_Selectalltext = "";
         Combo_notificacaoagendadalayoutid_Multiplevaluesseparator = "";
         Combo_notificacaoagendadalayoutid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode98 = "";
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
         GXt_objcol_SdtDVB_SDTComboData_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV14ComboSelectedValue = "";
         T002U5_A898NotificacaoAgendadaId = new int[1] ;
         T002U5_A899NotificacaoAgendadaOrigem = new string[] {""} ;
         T002U5_A900NotificacaoAgendadaDescricao = new string[] {""} ;
         T002U5_A901NotificacaoAgendadaDias = new int[1] ;
         T002U5_n901NotificacaoAgendadaDias = new bool[] {false} ;
         T002U5_A902NotificacaoAgendadaMomentoEnvio = new string[] {""} ;
         T002U5_n902NotificacaoAgendadaMomentoEnvio = new bool[] {false} ;
         T002U5_A903NotificacaoAgendadaTipo = new string[] {""} ;
         T002U5_n903NotificacaoAgendadaTipo = new bool[] {false} ;
         T002U5_A905NotificacaoAgendadaStatus = new bool[] {false} ;
         T002U5_n905NotificacaoAgendadaStatus = new bool[] {false} ;
         T002U5_A904NotificacaoAgendadaLayoutId = new short[1] ;
         T002U5_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         T002U4_A904NotificacaoAgendadaLayoutId = new short[1] ;
         T002U4_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         T002U6_A904NotificacaoAgendadaLayoutId = new short[1] ;
         T002U6_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         T002U7_A898NotificacaoAgendadaId = new int[1] ;
         T002U3_A898NotificacaoAgendadaId = new int[1] ;
         T002U3_A899NotificacaoAgendadaOrigem = new string[] {""} ;
         T002U3_A900NotificacaoAgendadaDescricao = new string[] {""} ;
         T002U3_A901NotificacaoAgendadaDias = new int[1] ;
         T002U3_n901NotificacaoAgendadaDias = new bool[] {false} ;
         T002U3_A902NotificacaoAgendadaMomentoEnvio = new string[] {""} ;
         T002U3_n902NotificacaoAgendadaMomentoEnvio = new bool[] {false} ;
         T002U3_A903NotificacaoAgendadaTipo = new string[] {""} ;
         T002U3_n903NotificacaoAgendadaTipo = new bool[] {false} ;
         T002U3_A905NotificacaoAgendadaStatus = new bool[] {false} ;
         T002U3_n905NotificacaoAgendadaStatus = new bool[] {false} ;
         T002U3_A904NotificacaoAgendadaLayoutId = new short[1] ;
         T002U3_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         T002U8_A898NotificacaoAgendadaId = new int[1] ;
         T002U9_A898NotificacaoAgendadaId = new int[1] ;
         T002U2_A898NotificacaoAgendadaId = new int[1] ;
         T002U2_A899NotificacaoAgendadaOrigem = new string[] {""} ;
         T002U2_A900NotificacaoAgendadaDescricao = new string[] {""} ;
         T002U2_A901NotificacaoAgendadaDias = new int[1] ;
         T002U2_n901NotificacaoAgendadaDias = new bool[] {false} ;
         T002U2_A902NotificacaoAgendadaMomentoEnvio = new string[] {""} ;
         T002U2_n902NotificacaoAgendadaMomentoEnvio = new bool[] {false} ;
         T002U2_A903NotificacaoAgendadaTipo = new string[] {""} ;
         T002U2_n903NotificacaoAgendadaTipo = new bool[] {false} ;
         T002U2_A905NotificacaoAgendadaStatus = new bool[] {false} ;
         T002U2_n905NotificacaoAgendadaStatus = new bool[] {false} ;
         T002U2_A904NotificacaoAgendadaLayoutId = new short[1] ;
         T002U2_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         T002U11_A898NotificacaoAgendadaId = new int[1] ;
         T002U14_A898NotificacaoAgendadaId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T002U15_A904NotificacaoAgendadaLayoutId = new short[1] ;
         T002U15_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notificacaoagendada__default(),
            new Object[][] {
                new Object[] {
               T002U2_A898NotificacaoAgendadaId, T002U2_A899NotificacaoAgendadaOrigem, T002U2_A900NotificacaoAgendadaDescricao, T002U2_A901NotificacaoAgendadaDias, T002U2_n901NotificacaoAgendadaDias, T002U2_A902NotificacaoAgendadaMomentoEnvio, T002U2_n902NotificacaoAgendadaMomentoEnvio, T002U2_A903NotificacaoAgendadaTipo, T002U2_n903NotificacaoAgendadaTipo, T002U2_A905NotificacaoAgendadaStatus,
               T002U2_n905NotificacaoAgendadaStatus, T002U2_A904NotificacaoAgendadaLayoutId, T002U2_n904NotificacaoAgendadaLayoutId
               }
               , new Object[] {
               T002U3_A898NotificacaoAgendadaId, T002U3_A899NotificacaoAgendadaOrigem, T002U3_A900NotificacaoAgendadaDescricao, T002U3_A901NotificacaoAgendadaDias, T002U3_n901NotificacaoAgendadaDias, T002U3_A902NotificacaoAgendadaMomentoEnvio, T002U3_n902NotificacaoAgendadaMomentoEnvio, T002U3_A903NotificacaoAgendadaTipo, T002U3_n903NotificacaoAgendadaTipo, T002U3_A905NotificacaoAgendadaStatus,
               T002U3_n905NotificacaoAgendadaStatus, T002U3_A904NotificacaoAgendadaLayoutId, T002U3_n904NotificacaoAgendadaLayoutId
               }
               , new Object[] {
               T002U4_A904NotificacaoAgendadaLayoutId
               }
               , new Object[] {
               T002U5_A898NotificacaoAgendadaId, T002U5_A899NotificacaoAgendadaOrigem, T002U5_A900NotificacaoAgendadaDescricao, T002U5_A901NotificacaoAgendadaDias, T002U5_n901NotificacaoAgendadaDias, T002U5_A902NotificacaoAgendadaMomentoEnvio, T002U5_n902NotificacaoAgendadaMomentoEnvio, T002U5_A903NotificacaoAgendadaTipo, T002U5_n903NotificacaoAgendadaTipo, T002U5_A905NotificacaoAgendadaStatus,
               T002U5_n905NotificacaoAgendadaStatus, T002U5_A904NotificacaoAgendadaLayoutId, T002U5_n904NotificacaoAgendadaLayoutId
               }
               , new Object[] {
               T002U6_A904NotificacaoAgendadaLayoutId
               }
               , new Object[] {
               T002U7_A898NotificacaoAgendadaId
               }
               , new Object[] {
               T002U8_A898NotificacaoAgendadaId
               }
               , new Object[] {
               T002U9_A898NotificacaoAgendadaId
               }
               , new Object[] {
               }
               , new Object[] {
               T002U11_A898NotificacaoAgendadaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002U14_A898NotificacaoAgendadaId
               }
               , new Object[] {
               T002U15_A904NotificacaoAgendadaLayoutId
               }
            }
         );
         AV17Pgmname = "NotificacaoAgendada";
         Z905NotificacaoAgendadaStatus = true;
         n905NotificacaoAgendadaStatus = false;
         A905NotificacaoAgendadaStatus = true;
         n905NotificacaoAgendadaStatus = false;
         i905NotificacaoAgendadaStatus = true;
         n905NotificacaoAgendadaStatus = false;
      }

      private short Z904NotificacaoAgendadaLayoutId ;
      private short N904NotificacaoAgendadaLayoutId ;
      private short GxWebError ;
      private short A904NotificacaoAgendadaLayoutId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV15ComboNotificacaoAgendadaLayoutId ;
      private short AV11Insert_NotificacaoAgendadaLayoutId ;
      private short Gx_BScreen ;
      private short RcdFound98 ;
      private short gxajaxcallmode ;
      private int wcpOAV7NotificacaoAgendadaId ;
      private int Z898NotificacaoAgendadaId ;
      private int Z901NotificacaoAgendadaDias ;
      private int AV7NotificacaoAgendadaId ;
      private int trnEnded ;
      private int edtNotificacaoAgendadaDescricao_Enabled ;
      private int A901NotificacaoAgendadaDias ;
      private int edtNotificacaoAgendadaDias_Enabled ;
      private int edtNotificacaoAgendadaLayoutId_Visible ;
      private int edtNotificacaoAgendadaLayoutId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombonotificacaoagendadalayoutid_Enabled ;
      private int edtavCombonotificacaoagendadalayoutid_Visible ;
      private int A898NotificacaoAgendadaId ;
      private int edtNotificacaoAgendadaId_Enabled ;
      private int edtNotificacaoAgendadaId_Visible ;
      private int A907NotificacaoAgendadaOffsetDias ;
      private int Combo_notificacaoagendadalayoutid_Datalistupdateminimumcharacters ;
      private int Combo_notificacaoagendadalayoutid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV18GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_notificacaoagendadalayoutid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNotificacaoAgendadaDescricao_Internalname ;
      private string cmbNotificacaoAgendadaOrigem_Internalname ;
      private string cmbNotificacaoAgendadaMomentoEnvio_Internalname ;
      private string cmbNotificacaoAgendadaTipo_Internalname ;
      private string cmbNotificacaoAgendadaStatus_Internalname ;
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
      private string cmbNotificacaoAgendadaOrigem_Jsonclick ;
      private string edtNotificacaoAgendadaDescricao_Jsonclick ;
      private string edtNotificacaoAgendadaDias_Internalname ;
      private string edtNotificacaoAgendadaDias_Jsonclick ;
      private string cmbNotificacaoAgendadaMomentoEnvio_Jsonclick ;
      private string cmbNotificacaoAgendadaTipo_Jsonclick ;
      private string divTablesplittednotificacaoagendadalayoutid_Internalname ;
      private string lblTextblocknotificacaoagendadalayoutid_Internalname ;
      private string lblTextblocknotificacaoagendadalayoutid_Jsonclick ;
      private string Combo_notificacaoagendadalayoutid_Caption ;
      private string Combo_notificacaoagendadalayoutid_Cls ;
      private string Combo_notificacaoagendadalayoutid_Internalname ;
      private string edtNotificacaoAgendadaLayoutId_Internalname ;
      private string edtNotificacaoAgendadaLayoutId_Jsonclick ;
      private string cmbNotificacaoAgendadaStatus_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_notificacaoagendadalayoutid_Internalname ;
      private string edtavCombonotificacaoagendadalayoutid_Internalname ;
      private string edtavCombonotificacaoagendadalayoutid_Jsonclick ;
      private string edtNotificacaoAgendadaId_Internalname ;
      private string edtNotificacaoAgendadaId_Jsonclick ;
      private string AV17Pgmname ;
      private string Combo_notificacaoagendadalayoutid_Objectcall ;
      private string Combo_notificacaoagendadalayoutid_Class ;
      private string Combo_notificacaoagendadalayoutid_Icontype ;
      private string Combo_notificacaoagendadalayoutid_Icon ;
      private string Combo_notificacaoagendadalayoutid_Tooltip ;
      private string Combo_notificacaoagendadalayoutid_Selectedvalue_set ;
      private string Combo_notificacaoagendadalayoutid_Selectedtext_set ;
      private string Combo_notificacaoagendadalayoutid_Selectedtext_get ;
      private string Combo_notificacaoagendadalayoutid_Gamoauthtoken ;
      private string Combo_notificacaoagendadalayoutid_Ddointernalname ;
      private string Combo_notificacaoagendadalayoutid_Titlecontrolalign ;
      private string Combo_notificacaoagendadalayoutid_Dropdownoptionstype ;
      private string Combo_notificacaoagendadalayoutid_Titlecontrolidtoreplace ;
      private string Combo_notificacaoagendadalayoutid_Datalisttype ;
      private string Combo_notificacaoagendadalayoutid_Datalistfixedvalues ;
      private string Combo_notificacaoagendadalayoutid_Datalistproc ;
      private string Combo_notificacaoagendadalayoutid_Datalistprocparametersprefix ;
      private string Combo_notificacaoagendadalayoutid_Remoteservicesparameters ;
      private string Combo_notificacaoagendadalayoutid_Htmltemplate ;
      private string Combo_notificacaoagendadalayoutid_Multiplevaluestype ;
      private string Combo_notificacaoagendadalayoutid_Loadingdata ;
      private string Combo_notificacaoagendadalayoutid_Noresultsfound ;
      private string Combo_notificacaoagendadalayoutid_Emptyitemtext ;
      private string Combo_notificacaoagendadalayoutid_Onlyselectedvalues ;
      private string Combo_notificacaoagendadalayoutid_Selectalltext ;
      private string Combo_notificacaoagendadalayoutid_Multiplevaluesseparator ;
      private string Combo_notificacaoagendadalayoutid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode98 ;
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
      private bool Z905NotificacaoAgendadaStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n904NotificacaoAgendadaLayoutId ;
      private bool wbErr ;
      private bool n902NotificacaoAgendadaMomentoEnvio ;
      private bool n903NotificacaoAgendadaTipo ;
      private bool A905NotificacaoAgendadaStatus ;
      private bool n905NotificacaoAgendadaStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n901NotificacaoAgendadaDias ;
      private bool Combo_notificacaoagendadalayoutid_Emptyitem ;
      private bool Combo_notificacaoagendadalayoutid_Enabled ;
      private bool Combo_notificacaoagendadalayoutid_Visible ;
      private bool Combo_notificacaoagendadalayoutid_Allowmultipleselection ;
      private bool Combo_notificacaoagendadalayoutid_Isgriditem ;
      private bool Combo_notificacaoagendadalayoutid_Hasdescription ;
      private bool Combo_notificacaoagendadalayoutid_Includeonlyselectedoption ;
      private bool Combo_notificacaoagendadalayoutid_Includeselectalloption ;
      private bool Combo_notificacaoagendadalayoutid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i905NotificacaoAgendadaStatus ;
      private string Z899NotificacaoAgendadaOrigem ;
      private string Z900NotificacaoAgendadaDescricao ;
      private string Z902NotificacaoAgendadaMomentoEnvio ;
      private string Z903NotificacaoAgendadaTipo ;
      private string A899NotificacaoAgendadaOrigem ;
      private string A902NotificacaoAgendadaMomentoEnvio ;
      private string A903NotificacaoAgendadaTipo ;
      private string A900NotificacaoAgendadaDescricao ;
      private string AV14ComboSelectedValue ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_notificacaoagendadalayoutid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbNotificacaoAgendadaOrigem ;
      private GXCombobox cmbNotificacaoAgendadaMomentoEnvio ;
      private GXCombobox cmbNotificacaoAgendadaTipo ;
      private GXCombobox cmbNotificacaoAgendadaStatus ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13NotificacaoAgendadaLayoutId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private IDataStoreProvider pr_default ;
      private int[] T002U5_A898NotificacaoAgendadaId ;
      private string[] T002U5_A899NotificacaoAgendadaOrigem ;
      private string[] T002U5_A900NotificacaoAgendadaDescricao ;
      private int[] T002U5_A901NotificacaoAgendadaDias ;
      private bool[] T002U5_n901NotificacaoAgendadaDias ;
      private string[] T002U5_A902NotificacaoAgendadaMomentoEnvio ;
      private bool[] T002U5_n902NotificacaoAgendadaMomentoEnvio ;
      private string[] T002U5_A903NotificacaoAgendadaTipo ;
      private bool[] T002U5_n903NotificacaoAgendadaTipo ;
      private bool[] T002U5_A905NotificacaoAgendadaStatus ;
      private bool[] T002U5_n905NotificacaoAgendadaStatus ;
      private short[] T002U5_A904NotificacaoAgendadaLayoutId ;
      private bool[] T002U5_n904NotificacaoAgendadaLayoutId ;
      private short[] T002U4_A904NotificacaoAgendadaLayoutId ;
      private bool[] T002U4_n904NotificacaoAgendadaLayoutId ;
      private short[] T002U6_A904NotificacaoAgendadaLayoutId ;
      private bool[] T002U6_n904NotificacaoAgendadaLayoutId ;
      private int[] T002U7_A898NotificacaoAgendadaId ;
      private int[] T002U3_A898NotificacaoAgendadaId ;
      private string[] T002U3_A899NotificacaoAgendadaOrigem ;
      private string[] T002U3_A900NotificacaoAgendadaDescricao ;
      private int[] T002U3_A901NotificacaoAgendadaDias ;
      private bool[] T002U3_n901NotificacaoAgendadaDias ;
      private string[] T002U3_A902NotificacaoAgendadaMomentoEnvio ;
      private bool[] T002U3_n902NotificacaoAgendadaMomentoEnvio ;
      private string[] T002U3_A903NotificacaoAgendadaTipo ;
      private bool[] T002U3_n903NotificacaoAgendadaTipo ;
      private bool[] T002U3_A905NotificacaoAgendadaStatus ;
      private bool[] T002U3_n905NotificacaoAgendadaStatus ;
      private short[] T002U3_A904NotificacaoAgendadaLayoutId ;
      private bool[] T002U3_n904NotificacaoAgendadaLayoutId ;
      private int[] T002U8_A898NotificacaoAgendadaId ;
      private int[] T002U9_A898NotificacaoAgendadaId ;
      private int[] T002U2_A898NotificacaoAgendadaId ;
      private string[] T002U2_A899NotificacaoAgendadaOrigem ;
      private string[] T002U2_A900NotificacaoAgendadaDescricao ;
      private int[] T002U2_A901NotificacaoAgendadaDias ;
      private bool[] T002U2_n901NotificacaoAgendadaDias ;
      private string[] T002U2_A902NotificacaoAgendadaMomentoEnvio ;
      private bool[] T002U2_n902NotificacaoAgendadaMomentoEnvio ;
      private string[] T002U2_A903NotificacaoAgendadaTipo ;
      private bool[] T002U2_n903NotificacaoAgendadaTipo ;
      private bool[] T002U2_A905NotificacaoAgendadaStatus ;
      private bool[] T002U2_n905NotificacaoAgendadaStatus ;
      private short[] T002U2_A904NotificacaoAgendadaLayoutId ;
      private bool[] T002U2_n904NotificacaoAgendadaLayoutId ;
      private int[] T002U11_A898NotificacaoAgendadaId ;
      private int[] T002U14_A898NotificacaoAgendadaId ;
      private short[] T002U15_A904NotificacaoAgendadaLayoutId ;
      private bool[] T002U15_n904NotificacaoAgendadaLayoutId ;
   }

   public class notificacaoagendada__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT002U2;
          prmT002U2 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmT002U3;
          prmT002U3 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmT002U4;
          prmT002U4 = new Object[] {
          new ParDef("NotificacaoAgendadaLayoutId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002U5;
          prmT002U5 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmT002U6;
          prmT002U6 = new Object[] {
          new ParDef("NotificacaoAgendadaLayoutId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002U7;
          prmT002U7 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmT002U8;
          prmT002U8 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmT002U9;
          prmT002U9 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmT002U10;
          prmT002U10 = new Object[] {
          new ParDef("NotificacaoAgendadaOrigem",GXType.VarChar,1,0) ,
          new ParDef("NotificacaoAgendadaDescricao",GXType.VarChar,120,0) ,
          new ParDef("NotificacaoAgendadaDias",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaMomentoEnvio",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaTipo",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaLayoutId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002U11;
          prmT002U11 = new Object[] {
          };
          Object[] prmT002U12;
          prmT002U12 = new Object[] {
          new ParDef("NotificacaoAgendadaOrigem",GXType.VarChar,1,0) ,
          new ParDef("NotificacaoAgendadaDescricao",GXType.VarChar,120,0) ,
          new ParDef("NotificacaoAgendadaDias",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaMomentoEnvio",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaTipo",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaLayoutId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmT002U13;
          prmT002U13 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmT002U14;
          prmT002U14 = new Object[] {
          };
          Object[] prmT002U15;
          prmT002U15 = new Object[] {
          new ParDef("NotificacaoAgendadaLayoutId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T002U2", "SELECT NotificacaoAgendadaId, NotificacaoAgendadaOrigem, NotificacaoAgendadaDescricao, NotificacaoAgendadaDias, NotificacaoAgendadaMomentoEnvio, NotificacaoAgendadaTipo, NotificacaoAgendadaStatus, NotificacaoAgendadaLayoutId FROM NotificacaoAgendada WHERE NotificacaoAgendadaId = :NotificacaoAgendadaId  FOR UPDATE OF NotificacaoAgendada NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002U2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002U3", "SELECT NotificacaoAgendadaId, NotificacaoAgendadaOrigem, NotificacaoAgendadaDescricao, NotificacaoAgendadaDias, NotificacaoAgendadaMomentoEnvio, NotificacaoAgendadaTipo, NotificacaoAgendadaStatus, NotificacaoAgendadaLayoutId FROM NotificacaoAgendada WHERE NotificacaoAgendadaId = :NotificacaoAgendadaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002U4", "SELECT LayoutContratoId AS NotificacaoAgendadaLayoutId FROM LayoutContrato WHERE LayoutContratoId = :NotificacaoAgendadaLayoutId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002U5", "SELECT TM1.NotificacaoAgendadaId, TM1.NotificacaoAgendadaOrigem, TM1.NotificacaoAgendadaDescricao, TM1.NotificacaoAgendadaDias, TM1.NotificacaoAgendadaMomentoEnvio, TM1.NotificacaoAgendadaTipo, TM1.NotificacaoAgendadaStatus, TM1.NotificacaoAgendadaLayoutId AS NotificacaoAgendadaLayoutId FROM NotificacaoAgendada TM1 WHERE TM1.NotificacaoAgendadaId = :NotificacaoAgendadaId ORDER BY TM1.NotificacaoAgendadaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002U6", "SELECT LayoutContratoId AS NotificacaoAgendadaLayoutId FROM LayoutContrato WHERE LayoutContratoId = :NotificacaoAgendadaLayoutId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002U7", "SELECT NotificacaoAgendadaId FROM NotificacaoAgendada WHERE NotificacaoAgendadaId = :NotificacaoAgendadaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002U8", "SELECT NotificacaoAgendadaId FROM NotificacaoAgendada WHERE ( NotificacaoAgendadaId > :NotificacaoAgendadaId) ORDER BY NotificacaoAgendadaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002U9", "SELECT NotificacaoAgendadaId FROM NotificacaoAgendada WHERE ( NotificacaoAgendadaId < :NotificacaoAgendadaId) ORDER BY NotificacaoAgendadaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002U10", "SAVEPOINT gxupdate;INSERT INTO NotificacaoAgendada(NotificacaoAgendadaOrigem, NotificacaoAgendadaDescricao, NotificacaoAgendadaDias, NotificacaoAgendadaMomentoEnvio, NotificacaoAgendadaTipo, NotificacaoAgendadaStatus, NotificacaoAgendadaLayoutId) VALUES(:NotificacaoAgendadaOrigem, :NotificacaoAgendadaDescricao, :NotificacaoAgendadaDias, :NotificacaoAgendadaMomentoEnvio, :NotificacaoAgendadaTipo, :NotificacaoAgendadaStatus, :NotificacaoAgendadaLayoutId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002U10)
             ,new CursorDef("T002U11", "SELECT currval('NotificacaoAgendadaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002U12", "SAVEPOINT gxupdate;UPDATE NotificacaoAgendada SET NotificacaoAgendadaOrigem=:NotificacaoAgendadaOrigem, NotificacaoAgendadaDescricao=:NotificacaoAgendadaDescricao, NotificacaoAgendadaDias=:NotificacaoAgendadaDias, NotificacaoAgendadaMomentoEnvio=:NotificacaoAgendadaMomentoEnvio, NotificacaoAgendadaTipo=:NotificacaoAgendadaTipo, NotificacaoAgendadaStatus=:NotificacaoAgendadaStatus, NotificacaoAgendadaLayoutId=:NotificacaoAgendadaLayoutId  WHERE NotificacaoAgendadaId = :NotificacaoAgendadaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002U12)
             ,new CursorDef("T002U13", "SAVEPOINT gxupdate;DELETE FROM NotificacaoAgendada  WHERE NotificacaoAgendadaId = :NotificacaoAgendadaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002U13)
             ,new CursorDef("T002U14", "SELECT NotificacaoAgendadaId FROM NotificacaoAgendada ORDER BY NotificacaoAgendadaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002U15", "SELECT LayoutContratoId AS NotificacaoAgendadaLayoutId FROM LayoutContrato WHERE LayoutContratoId = :NotificacaoAgendadaLayoutId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U15,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((short[]) buf[11])[0] = rslt.getShort(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((short[]) buf[11])[0] = rslt.getShort(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((short[]) buf[11])[0] = rslt.getShort(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
