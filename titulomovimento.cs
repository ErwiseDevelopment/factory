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
   public class titulomovimento : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A288TipoPagamentoId = (int)(Math.Round(NumberUtil.Val( GetPar( "TipoPagamentoId"), "."), 18, MidpointRounding.ToEven));
            n288TipoPagamentoId = false;
            AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A288TipoPagamentoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A433TituloMovimentoConta = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloMovimentoConta"), "."), 18, MidpointRounding.ToEven));
            n433TituloMovimentoConta = false;
            AssignAttri("", false, "A433TituloMovimentoConta", ((0==A433TituloMovimentoConta)&&IsIns( )||n433TituloMovimentoConta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A433TituloMovimentoConta), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A433TituloMovimentoConta) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "titulomovimento")), "titulomovimento") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "titulomovimento")))) ;
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
                  AV7TituloMovimentoId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloMovimentoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7TituloMovimentoId", StringUtil.LTrimStr( (decimal)(AV7TituloMovimentoId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTITULOMOVIMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TituloMovimentoId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Titulo Movimento", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipoPagamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public titulomovimento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public titulomovimento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TituloMovimentoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TituloMovimentoId = aP1_TituloMovimentoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTituloMovimentoTipo = new GXCombobox();
         chkTituloMovimentoSoma = new GXCheckbox();
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
         if ( cmbTituloMovimentoTipo.ItemCount > 0 )
         {
            A272TituloMovimentoTipo = cmbTituloMovimentoTipo.getValidValue(A272TituloMovimentoTipo);
            n272TituloMovimentoTipo = false;
            AssignAttri("", false, "A272TituloMovimentoTipo", A272TituloMovimentoTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTituloMovimentoTipo.CurrentValue = StringUtil.RTrim( A272TituloMovimentoTipo);
            AssignProp("", false, cmbTituloMovimentoTipo_Internalname, "Values", cmbTituloMovimentoTipo.ToJavascriptSource(), true);
         }
         A274TituloMovimentoSoma = StringUtil.StrToBool( StringUtil.BoolToStr( A274TituloMovimentoSoma));
         n274TituloMovimentoSoma = false;
         AssignAttri("", false, "A274TituloMovimentoSoma", A274TituloMovimentoSoma);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloMovimentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloMovimentoId_Internalname, "Movimento Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloMovimentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A270TituloMovimentoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtTituloMovimentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A270TituloMovimentoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A270TituloMovimentoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloMovimentoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloMovimentoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_TituloMovimento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedtipopagamentoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktipopagamentoid_Internalname, "Tipo Pagamento", "", "", lblTextblocktipopagamentoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_TituloMovimento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_tipopagamentoid.SetProperty("Caption", Combo_tipopagamentoid_Caption);
         ucCombo_tipopagamentoid.SetProperty("Cls", Combo_tipopagamentoid_Cls);
         ucCombo_tipopagamentoid.SetProperty("DataListProc", Combo_tipopagamentoid_Datalistproc);
         ucCombo_tipopagamentoid.SetProperty("DataListProcParametersPrefix", Combo_tipopagamentoid_Datalistprocparametersprefix);
         ucCombo_tipopagamentoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_tipopagamentoid.SetProperty("DropDownOptionsData", AV14TipoPagamentoId_Data);
         ucCombo_tipopagamentoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tipopagamentoid_Internalname, "COMBO_TIPOPAGAMENTOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoPagamentoId_Internalname, "Tipo Pagamento Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoPagamentoId_Internalname, ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ",", ""))), ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A288TipoPagamentoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoPagamentoId_Jsonclick, 0, "Attribute", "", "", "", "", edtTipoPagamentoId_Visible, edtTipoPagamentoId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_TituloMovimento.htm");
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
         GxWebStd.gx_div_start( context, divTablesplittedtituloid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktituloid_Internalname, "Titulo", "", "", lblTextblocktituloid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_TituloMovimento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_tituloid.SetProperty("Caption", Combo_tituloid_Caption);
         ucCombo_tituloid.SetProperty("Cls", Combo_tituloid_Cls);
         ucCombo_tituloid.SetProperty("DataListProc", Combo_tituloid_Datalistproc);
         ucCombo_tituloid.SetProperty("DataListProcParametersPrefix", Combo_tituloid_Datalistprocparametersprefix);
         ucCombo_tituloid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_tituloid.SetProperty("DropDownOptionsData", AV20TituloId_Data);
         ucCombo_tituloid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tituloid_Internalname, "COMBO_TITULOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloId_Internalname, "Titulo Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloId_Internalname, ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ",", ""))), ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloId_Jsonclick, 0, "Attribute", "", "", "", "", edtTituloId_Visible, edtTituloId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_TituloMovimento.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloMovimentoValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloMovimentoValor_Internalname, "Valor movimento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloMovimentoValor_Internalname, ((Convert.ToDecimal(0)==A271TituloMovimentoValor)&&IsIns( )||n271TituloMovimentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A271TituloMovimentoValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A271TituloMovimentoValor)&&IsIns( )||n271TituloMovimentoValor ? "" : StringUtil.LTrim( ((edtTituloMovimentoValor_Enabled!=0) ? context.localUtil.Format( A271TituloMovimentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A271TituloMovimentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloMovimentoValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloMovimentoValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_TituloMovimento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTituloMovimentoTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTituloMovimentoTipo_Internalname, "Tipo baixa", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTituloMovimentoTipo, cmbTituloMovimentoTipo_Internalname, StringUtil.RTrim( A272TituloMovimentoTipo), 1, cmbTituloMovimentoTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbTituloMovimentoTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_TituloMovimento.htm");
         cmbTituloMovimentoTipo.CurrentValue = StringUtil.RTrim( A272TituloMovimentoTipo);
         AssignProp("", false, cmbTituloMovimentoTipo_Internalname, "Values", (string)(cmbTituloMovimentoTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkTituloMovimentoSoma_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTituloMovimentoSoma_Internalname, "Movimento Soma", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTituloMovimentoSoma_Internalname, StringUtil.BoolToStr( A274TituloMovimentoSoma), "", "Movimento Soma", 1, chkTituloMovimentoSoma.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloMovimentoDataCredito_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloMovimentoDataCredito_Internalname, "Data de crédito", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTituloMovimentoDataCredito_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTituloMovimentoDataCredito_Internalname, context.localUtil.Format(A279TituloMovimentoDataCredito, "99/99/9999"), context.localUtil.Format( A279TituloMovimentoDataCredito, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloMovimentoDataCredito_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloMovimentoDataCredito_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TituloMovimento.htm");
         GxWebStd.gx_bitmap( context, edtTituloMovimentoDataCredito_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTituloMovimentoDataCredito_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TituloMovimento.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloMovimentoCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloMovimentoCreatedAt_Internalname, "Criado em", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTituloMovimentoCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTituloMovimentoCreatedAt_Internalname, context.localUtil.TToC( A280TituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A280TituloMovimentoCreatedAt, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloMovimentoCreatedAt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloMovimentoCreatedAt_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TituloMovimento.htm");
         GxWebStd.gx_bitmap( context, edtTituloMovimentoCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTituloMovimentoCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TituloMovimento.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloMovimentoUpdatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloMovimentoUpdatedAt_Internalname, "Atualizado em", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTituloMovimentoUpdatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTituloMovimentoUpdatedAt_Internalname, context.localUtil.TToC( A281TituloMovimentoUpdatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A281TituloMovimentoUpdatedAt, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloMovimentoUpdatedAt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloMovimentoUpdatedAt_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TituloMovimento.htm");
         GxWebStd.gx_bitmap( context, edtTituloMovimentoUpdatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTituloMovimentoUpdatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TituloMovimento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TituloMovimento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TituloMovimento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TituloMovimento.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_tipopagamentoid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombotipopagamentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboTipoPagamentoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavCombotipopagamentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboTipoPagamentoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboTipoPagamentoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombotipopagamentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombotipopagamentoid_Visible, edtavCombotipopagamentoid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TituloMovimento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_tituloid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombotituloid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ComboTituloId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavCombotituloid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV21ComboTituloId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV21ComboTituloId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombotituloid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombotituloid_Visible, edtavCombotituloid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TituloMovimento.htm");
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
         E11162 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vTIPOPAGAMENTOID_DATA"), AV14TipoPagamentoId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vTITULOID_DATA"), AV20TituloId_Data);
               /* Read saved values. */
               Z270TituloMovimentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z270TituloMovimentoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z280TituloMovimentoCreatedAt = context.localUtil.CToT( cgiGet( "Z280TituloMovimentoCreatedAt"), 0);
               n280TituloMovimentoCreatedAt = ((DateTime.MinValue==A280TituloMovimentoCreatedAt) ? true : false);
               Z281TituloMovimentoUpdatedAt = context.localUtil.CToT( cgiGet( "Z281TituloMovimentoUpdatedAt"), 0);
               n281TituloMovimentoUpdatedAt = ((DateTime.MinValue==A281TituloMovimentoUpdatedAt) ? true : false);
               Z271TituloMovimentoValor = context.localUtil.CToN( cgiGet( "Z271TituloMovimentoValor"), ",", ".");
               n271TituloMovimentoValor = ((Convert.ToDecimal(0)==A271TituloMovimentoValor) ? true : false);
               Z272TituloMovimentoTipo = cgiGet( "Z272TituloMovimentoTipo");
               n272TituloMovimentoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A272TituloMovimentoTipo)) ? true : false);
               Z274TituloMovimentoSoma = StringUtil.StrToBool( cgiGet( "Z274TituloMovimentoSoma"));
               n274TituloMovimentoSoma = ((false==A274TituloMovimentoSoma) ? true : false);
               Z279TituloMovimentoDataCredito = context.localUtil.CToD( cgiGet( "Z279TituloMovimentoDataCredito"), 0);
               n279TituloMovimentoDataCredito = ((DateTime.MinValue==A279TituloMovimentoDataCredito) ? true : false);
               Z432TituloMovimentoOpe = cgiGet( "Z432TituloMovimentoOpe");
               n432TituloMovimentoOpe = (String.IsNullOrEmpty(StringUtil.RTrim( A432TituloMovimentoOpe)) ? true : false);
               Z288TipoPagamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z288TipoPagamentoId"), ",", "."), 18, MidpointRounding.ToEven));
               n288TipoPagamentoId = ((0==A288TipoPagamentoId) ? true : false);
               Z261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z261TituloId"), ",", "."), 18, MidpointRounding.ToEven));
               n261TituloId = ((0==A261TituloId) ? true : false);
               Z433TituloMovimentoConta = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z433TituloMovimentoConta"), ",", "."), 18, MidpointRounding.ToEven));
               n433TituloMovimentoConta = ((0==A433TituloMovimentoConta) ? true : false);
               A432TituloMovimentoOpe = cgiGet( "Z432TituloMovimentoOpe");
               n432TituloMovimentoOpe = false;
               n432TituloMovimentoOpe = (String.IsNullOrEmpty(StringUtil.RTrim( A432TituloMovimentoOpe)) ? true : false);
               A433TituloMovimentoConta = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z433TituloMovimentoConta"), ",", "."), 18, MidpointRounding.ToEven));
               n433TituloMovimentoConta = false;
               n433TituloMovimentoConta = ((0==A433TituloMovimentoConta) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N288TipoPagamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N288TipoPagamentoId"), ",", "."), 18, MidpointRounding.ToEven));
               n288TipoPagamentoId = ((0==A288TipoPagamentoId) ? true : false);
               N261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N261TituloId"), ",", "."), 18, MidpointRounding.ToEven));
               n261TituloId = ((0==A261TituloId) ? true : false);
               N433TituloMovimentoConta = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N433TituloMovimentoConta"), ",", "."), 18, MidpointRounding.ToEven));
               n433TituloMovimentoConta = ((0==A433TituloMovimentoConta) ? true : false);
               AV7TituloMovimentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vTITULOMOVIMENTOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_TipoPagamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TIPOPAGAMENTOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_TipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV11Insert_TipoPagamentoId), 9, 0));
               AV12Insert_TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TITULOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_TituloId", StringUtil.LTrimStr( (decimal)(AV12Insert_TituloId), 9, 0));
               AV22Insert_TituloMovimentoConta = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TITULOMOVIMENTOCONTA"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22Insert_TituloMovimentoConta", StringUtil.LTrimStr( (decimal)(AV22Insert_TituloMovimentoConta), 9, 0));
               A433TituloMovimentoConta = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TITULOMOVIMENTOCONTA"), ",", "."), 18, MidpointRounding.ToEven));
               n433TituloMovimentoConta = ((0==A433TituloMovimentoConta) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A432TituloMovimentoOpe = cgiGet( "TITULOMOVIMENTOOPE");
               n432TituloMovimentoOpe = (String.IsNullOrEmpty(StringUtil.RTrim( A432TituloMovimentoOpe)) ? true : false);
               A289TipoPagamentoNome = cgiGet( "TIPOPAGAMENTONOME");
               AV24Pgmname = cgiGet( "vPGMNAME");
               Combo_tipopagamentoid_Objectcall = cgiGet( "COMBO_TIPOPAGAMENTOID_Objectcall");
               Combo_tipopagamentoid_Class = cgiGet( "COMBO_TIPOPAGAMENTOID_Class");
               Combo_tipopagamentoid_Icontype = cgiGet( "COMBO_TIPOPAGAMENTOID_Icontype");
               Combo_tipopagamentoid_Icon = cgiGet( "COMBO_TIPOPAGAMENTOID_Icon");
               Combo_tipopagamentoid_Caption = cgiGet( "COMBO_TIPOPAGAMENTOID_Caption");
               Combo_tipopagamentoid_Tooltip = cgiGet( "COMBO_TIPOPAGAMENTOID_Tooltip");
               Combo_tipopagamentoid_Cls = cgiGet( "COMBO_TIPOPAGAMENTOID_Cls");
               Combo_tipopagamentoid_Selectedvalue_set = cgiGet( "COMBO_TIPOPAGAMENTOID_Selectedvalue_set");
               Combo_tipopagamentoid_Selectedvalue_get = cgiGet( "COMBO_TIPOPAGAMENTOID_Selectedvalue_get");
               Combo_tipopagamentoid_Selectedtext_set = cgiGet( "COMBO_TIPOPAGAMENTOID_Selectedtext_set");
               Combo_tipopagamentoid_Selectedtext_get = cgiGet( "COMBO_TIPOPAGAMENTOID_Selectedtext_get");
               Combo_tipopagamentoid_Gamoauthtoken = cgiGet( "COMBO_TIPOPAGAMENTOID_Gamoauthtoken");
               Combo_tipopagamentoid_Ddointernalname = cgiGet( "COMBO_TIPOPAGAMENTOID_Ddointernalname");
               Combo_tipopagamentoid_Titlecontrolalign = cgiGet( "COMBO_TIPOPAGAMENTOID_Titlecontrolalign");
               Combo_tipopagamentoid_Dropdownoptionstype = cgiGet( "COMBO_TIPOPAGAMENTOID_Dropdownoptionstype");
               Combo_tipopagamentoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Enabled"));
               Combo_tipopagamentoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Visible"));
               Combo_tipopagamentoid_Titlecontrolidtoreplace = cgiGet( "COMBO_TIPOPAGAMENTOID_Titlecontrolidtoreplace");
               Combo_tipopagamentoid_Datalisttype = cgiGet( "COMBO_TIPOPAGAMENTOID_Datalisttype");
               Combo_tipopagamentoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Allowmultipleselection"));
               Combo_tipopagamentoid_Datalistfixedvalues = cgiGet( "COMBO_TIPOPAGAMENTOID_Datalistfixedvalues");
               Combo_tipopagamentoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Isgriditem"));
               Combo_tipopagamentoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Hasdescription"));
               Combo_tipopagamentoid_Datalistproc = cgiGet( "COMBO_TIPOPAGAMENTOID_Datalistproc");
               Combo_tipopagamentoid_Datalistprocparametersprefix = cgiGet( "COMBO_TIPOPAGAMENTOID_Datalistprocparametersprefix");
               Combo_tipopagamentoid_Remoteservicesparameters = cgiGet( "COMBO_TIPOPAGAMENTOID_Remoteservicesparameters");
               Combo_tipopagamentoid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_TIPOPAGAMENTOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_tipopagamentoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Includeonlyselectedoption"));
               Combo_tipopagamentoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Includeselectalloption"));
               Combo_tipopagamentoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Emptyitem"));
               Combo_tipopagamentoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPOPAGAMENTOID_Includeaddnewoption"));
               Combo_tipopagamentoid_Htmltemplate = cgiGet( "COMBO_TIPOPAGAMENTOID_Htmltemplate");
               Combo_tipopagamentoid_Multiplevaluestype = cgiGet( "COMBO_TIPOPAGAMENTOID_Multiplevaluestype");
               Combo_tipopagamentoid_Loadingdata = cgiGet( "COMBO_TIPOPAGAMENTOID_Loadingdata");
               Combo_tipopagamentoid_Noresultsfound = cgiGet( "COMBO_TIPOPAGAMENTOID_Noresultsfound");
               Combo_tipopagamentoid_Emptyitemtext = cgiGet( "COMBO_TIPOPAGAMENTOID_Emptyitemtext");
               Combo_tipopagamentoid_Onlyselectedvalues = cgiGet( "COMBO_TIPOPAGAMENTOID_Onlyselectedvalues");
               Combo_tipopagamentoid_Selectalltext = cgiGet( "COMBO_TIPOPAGAMENTOID_Selectalltext");
               Combo_tipopagamentoid_Multiplevaluesseparator = cgiGet( "COMBO_TIPOPAGAMENTOID_Multiplevaluesseparator");
               Combo_tipopagamentoid_Addnewoptiontext = cgiGet( "COMBO_TIPOPAGAMENTOID_Addnewoptiontext");
               Combo_tipopagamentoid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_TIPOPAGAMENTOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_tituloid_Objectcall = cgiGet( "COMBO_TITULOID_Objectcall");
               Combo_tituloid_Class = cgiGet( "COMBO_TITULOID_Class");
               Combo_tituloid_Icontype = cgiGet( "COMBO_TITULOID_Icontype");
               Combo_tituloid_Icon = cgiGet( "COMBO_TITULOID_Icon");
               Combo_tituloid_Caption = cgiGet( "COMBO_TITULOID_Caption");
               Combo_tituloid_Tooltip = cgiGet( "COMBO_TITULOID_Tooltip");
               Combo_tituloid_Cls = cgiGet( "COMBO_TITULOID_Cls");
               Combo_tituloid_Selectedvalue_set = cgiGet( "COMBO_TITULOID_Selectedvalue_set");
               Combo_tituloid_Selectedvalue_get = cgiGet( "COMBO_TITULOID_Selectedvalue_get");
               Combo_tituloid_Selectedtext_set = cgiGet( "COMBO_TITULOID_Selectedtext_set");
               Combo_tituloid_Selectedtext_get = cgiGet( "COMBO_TITULOID_Selectedtext_get");
               Combo_tituloid_Gamoauthtoken = cgiGet( "COMBO_TITULOID_Gamoauthtoken");
               Combo_tituloid_Ddointernalname = cgiGet( "COMBO_TITULOID_Ddointernalname");
               Combo_tituloid_Titlecontrolalign = cgiGet( "COMBO_TITULOID_Titlecontrolalign");
               Combo_tituloid_Dropdownoptionstype = cgiGet( "COMBO_TITULOID_Dropdownoptionstype");
               Combo_tituloid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Enabled"));
               Combo_tituloid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Visible"));
               Combo_tituloid_Titlecontrolidtoreplace = cgiGet( "COMBO_TITULOID_Titlecontrolidtoreplace");
               Combo_tituloid_Datalisttype = cgiGet( "COMBO_TITULOID_Datalisttype");
               Combo_tituloid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Allowmultipleselection"));
               Combo_tituloid_Datalistfixedvalues = cgiGet( "COMBO_TITULOID_Datalistfixedvalues");
               Combo_tituloid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Isgriditem"));
               Combo_tituloid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Hasdescription"));
               Combo_tituloid_Datalistproc = cgiGet( "COMBO_TITULOID_Datalistproc");
               Combo_tituloid_Datalistprocparametersprefix = cgiGet( "COMBO_TITULOID_Datalistprocparametersprefix");
               Combo_tituloid_Remoteservicesparameters = cgiGet( "COMBO_TITULOID_Remoteservicesparameters");
               Combo_tituloid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_TITULOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_tituloid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Includeonlyselectedoption"));
               Combo_tituloid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Includeselectalloption"));
               Combo_tituloid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Emptyitem"));
               Combo_tituloid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TITULOID_Includeaddnewoption"));
               Combo_tituloid_Htmltemplate = cgiGet( "COMBO_TITULOID_Htmltemplate");
               Combo_tituloid_Multiplevaluestype = cgiGet( "COMBO_TITULOID_Multiplevaluestype");
               Combo_tituloid_Loadingdata = cgiGet( "COMBO_TITULOID_Loadingdata");
               Combo_tituloid_Noresultsfound = cgiGet( "COMBO_TITULOID_Noresultsfound");
               Combo_tituloid_Emptyitemtext = cgiGet( "COMBO_TITULOID_Emptyitemtext");
               Combo_tituloid_Onlyselectedvalues = cgiGet( "COMBO_TITULOID_Onlyselectedvalues");
               Combo_tituloid_Selectalltext = cgiGet( "COMBO_TITULOID_Selectalltext");
               Combo_tituloid_Multiplevaluesseparator = cgiGet( "COMBO_TITULOID_Multiplevaluesseparator");
               Combo_tituloid_Addnewoptiontext = cgiGet( "COMBO_TITULOID_Addnewoptiontext");
               Combo_tituloid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_TITULOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A270TituloMovimentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloMovimentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
               n288TipoPagamentoId = ((StringUtil.StrCmp(cgiGet( edtTipoPagamentoId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipoPagamentoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipoPagamentoId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPOPAGAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtTipoPagamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A288TipoPagamentoId = 0;
                  n288TipoPagamentoId = false;
                  AssignAttri("", false, "A288TipoPagamentoId", (n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
               }
               else
               {
                  A288TipoPagamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoPagamentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A288TipoPagamentoId", (n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
               }
               n261TituloId = ((StringUtil.StrCmp(cgiGet( edtTituloId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TITULOID");
                  AnyError = 1;
                  GX_FocusControl = edtTituloId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A261TituloId = 0;
                  n261TituloId = false;
                  AssignAttri("", false, "A261TituloId", (n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
               }
               else
               {
                  A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A261TituloId", (n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
               }
               n271TituloMovimentoValor = ((StringUtil.StrCmp(cgiGet( edtTituloMovimentoValor_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTituloMovimentoValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTituloMovimentoValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TITULOMOVIMENTOVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtTituloMovimentoValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A271TituloMovimentoValor = 0;
                  n271TituloMovimentoValor = false;
                  AssignAttri("", false, "A271TituloMovimentoValor", (n271TituloMovimentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A271TituloMovimentoValor, 18, 2, ".", ""))));
               }
               else
               {
                  A271TituloMovimentoValor = context.localUtil.CToN( cgiGet( edtTituloMovimentoValor_Internalname), ",", ".");
                  AssignAttri("", false, "A271TituloMovimentoValor", (n271TituloMovimentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A271TituloMovimentoValor, 18, 2, ".", ""))));
               }
               cmbTituloMovimentoTipo.CurrentValue = cgiGet( cmbTituloMovimentoTipo_Internalname);
               A272TituloMovimentoTipo = cgiGet( cmbTituloMovimentoTipo_Internalname);
               n272TituloMovimentoTipo = false;
               AssignAttri("", false, "A272TituloMovimentoTipo", A272TituloMovimentoTipo);
               n272TituloMovimentoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A272TituloMovimentoTipo)) ? true : false);
               A274TituloMovimentoSoma = StringUtil.StrToBool( cgiGet( chkTituloMovimentoSoma_Internalname));
               n274TituloMovimentoSoma = false;
               AssignAttri("", false, "A274TituloMovimentoSoma", A274TituloMovimentoSoma);
               n274TituloMovimentoSoma = ((false==A274TituloMovimentoSoma) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtTituloMovimentoDataCredito_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data de crédito"}), 1, "TITULOMOVIMENTODATACREDITO");
                  AnyError = 1;
                  GX_FocusControl = edtTituloMovimentoDataCredito_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A279TituloMovimentoDataCredito = DateTime.MinValue;
                  n279TituloMovimentoDataCredito = false;
                  AssignAttri("", false, "A279TituloMovimentoDataCredito", context.localUtil.Format(A279TituloMovimentoDataCredito, "99/99/9999"));
               }
               else
               {
                  A279TituloMovimentoDataCredito = context.localUtil.CToD( cgiGet( edtTituloMovimentoDataCredito_Internalname), 2);
                  n279TituloMovimentoDataCredito = false;
                  AssignAttri("", false, "A279TituloMovimentoDataCredito", context.localUtil.Format(A279TituloMovimentoDataCredito, "99/99/9999"));
               }
               n279TituloMovimentoDataCredito = ((DateTime.MinValue==A279TituloMovimentoDataCredito) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtTituloMovimentoCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Criado em"}), 1, "TITULOMOVIMENTOCREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtTituloMovimentoCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A280TituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
                  n280TituloMovimentoCreatedAt = false;
                  AssignAttri("", false, "A280TituloMovimentoCreatedAt", context.localUtil.TToC( A280TituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A280TituloMovimentoCreatedAt = context.localUtil.CToT( cgiGet( edtTituloMovimentoCreatedAt_Internalname));
                  n280TituloMovimentoCreatedAt = false;
                  AssignAttri("", false, "A280TituloMovimentoCreatedAt", context.localUtil.TToC( A280TituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
               }
               n280TituloMovimentoCreatedAt = ((DateTime.MinValue==A280TituloMovimentoCreatedAt) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtTituloMovimentoUpdatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Atualizado em"}), 1, "TITULOMOVIMENTOUPDATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtTituloMovimentoUpdatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A281TituloMovimentoUpdatedAt = (DateTime)(DateTime.MinValue);
                  n281TituloMovimentoUpdatedAt = false;
                  AssignAttri("", false, "A281TituloMovimentoUpdatedAt", context.localUtil.TToC( A281TituloMovimentoUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A281TituloMovimentoUpdatedAt = context.localUtil.CToT( cgiGet( edtTituloMovimentoUpdatedAt_Internalname));
                  n281TituloMovimentoUpdatedAt = false;
                  AssignAttri("", false, "A281TituloMovimentoUpdatedAt", context.localUtil.TToC( A281TituloMovimentoUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
               }
               n281TituloMovimentoUpdatedAt = ((DateTime.MinValue==A281TituloMovimentoUpdatedAt) ? true : false);
               AV19ComboTipoPagamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombotipopagamentoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ComboTipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV19ComboTipoPagamentoId), 9, 0));
               AV21ComboTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombotituloid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21ComboTituloId", StringUtil.LTrimStr( (decimal)(AV21ComboTituloId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TituloMovimento");
               A270TituloMovimentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloMovimentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
               forbiddenHiddens.Add("TituloMovimentoId", context.localUtil.Format( (decimal)(A270TituloMovimentoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_TipoPagamentoId", context.localUtil.Format( (decimal)(AV11Insert_TipoPagamentoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_TituloId", context.localUtil.Format( (decimal)(AV12Insert_TituloId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_TituloMovimentoConta", context.localUtil.Format( (decimal)(AV22Insert_TituloMovimentoConta), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("TituloMovimentoOpe", StringUtil.RTrim( context.localUtil.Format( A432TituloMovimentoOpe, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A270TituloMovimentoId != Z270TituloMovimentoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("titulomovimento:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A270TituloMovimentoId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloMovimentoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
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
                     sMode45 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode45;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound45 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_160( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TITULOMOVIMENTOID");
                        AnyError = 1;
                        GX_FocusControl = edtTituloMovimentoId_Internalname;
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
                           E11162 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12162 ();
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
            E12162 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1645( ) ;
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
            DisableAttributes1645( ) ;
         }
         AssignProp("", false, edtavCombotipopagamentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotipopagamentoid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombotituloid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotituloid_Enabled), 5, 0), true);
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

      protected void CONFIRM_160( )
      {
         BeforeValidate1645( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1645( ) ;
            }
            else
            {
               CheckExtendedTable1645( ) ;
               CloseExtendedTableCursors1645( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption160( )
      {
      }

      protected void E11162( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtTituloId_Visible = 0;
         AssignProp("", false, edtTituloId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTituloId_Visible), 5, 0), true);
         AV21ComboTituloId = 0;
         AssignAttri("", false, "AV21ComboTituloId", StringUtil.LTrimStr( (decimal)(AV21ComboTituloId), 9, 0));
         edtavCombotituloid_Visible = 0;
         AssignProp("", false, edtavCombotituloid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombotituloid_Visible), 5, 0), true);
         edtTipoPagamentoId_Visible = 0;
         AssignProp("", false, edtTipoPagamentoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipoPagamentoId_Visible), 5, 0), true);
         AV19ComboTipoPagamentoId = 0;
         AssignAttri("", false, "AV19ComboTipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV19ComboTipoPagamentoId), 9, 0));
         edtavCombotipopagamentoid_Visible = 0;
         AssignProp("", false, edtavCombotipopagamentoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombotipopagamentoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTIPOPAGAMENTOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOTITULOID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            while ( AV25GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TipoPagamentoId") == 0 )
               {
                  AV11Insert_TipoPagamentoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_TipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV11Insert_TipoPagamentoId), 9, 0));
                  if ( ! (0==AV11Insert_TipoPagamentoId) )
                  {
                     AV19ComboTipoPagamentoId = AV11Insert_TipoPagamentoId;
                     AssignAttri("", false, "AV19ComboTipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV19ComboTipoPagamentoId), 9, 0));
                     Combo_tipopagamentoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ComboTipoPagamentoId), 9, 0));
                     ucCombo_tipopagamentoid.SendProperty(context, "", false, Combo_tipopagamentoid_Internalname, "SelectedValue_set", Combo_tipopagamentoid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new titulomovimentoloaddvcombo(context ).execute(  "TipoPagamentoId",  "GET",  false,  AV7TituloMovimentoId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_tipopagamentoid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_tipopagamentoid.SendProperty(context, "", false, Combo_tipopagamentoid_Internalname, "SelectedText_set", Combo_tipopagamentoid_Selectedtext_set);
                     Combo_tipopagamentoid_Enabled = false;
                     ucCombo_tipopagamentoid.SendProperty(context, "", false, Combo_tipopagamentoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tipopagamentoid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TituloId") == 0 )
               {
                  AV12Insert_TituloId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_TituloId", StringUtil.LTrimStr( (decimal)(AV12Insert_TituloId), 9, 0));
                  if ( ! (0==AV12Insert_TituloId) )
                  {
                     AV21ComboTituloId = AV12Insert_TituloId;
                     AssignAttri("", false, "AV21ComboTituloId", StringUtil.LTrimStr( (decimal)(AV21ComboTituloId), 9, 0));
                     Combo_tituloid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV21ComboTituloId), 9, 0));
                     ucCombo_tituloid.SendProperty(context, "", false, Combo_tituloid_Internalname, "SelectedValue_set", Combo_tituloid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new titulomovimentoloaddvcombo(context ).execute(  "TituloId",  "GET",  false,  AV7TituloMovimentoId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_tituloid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_tituloid.SendProperty(context, "", false, Combo_tituloid_Internalname, "SelectedText_set", Combo_tituloid_Selectedtext_set);
                     Combo_tituloid_Enabled = false;
                     ucCombo_tituloid.SendProperty(context, "", false, Combo_tituloid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tituloid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TituloMovimentoConta") == 0 )
               {
                  AV22Insert_TituloMovimentoConta = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV22Insert_TituloMovimentoConta", StringUtil.LTrimStr( (decimal)(AV22Insert_TituloMovimentoConta), 9, 0));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
               AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            }
         }
      }

      protected void E12162( )
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

      protected void S122( )
      {
         /* 'LOADCOMBOTITULOID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new titulomovimentoloaddvcombo(context ).execute(  "TituloId",  Gx_mode,  false,  AV7TituloMovimentoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_tituloid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_tituloid.SendProperty(context, "", false, Combo_tituloid_Internalname, "SelectedValue_set", Combo_tituloid_Selectedvalue_set);
         Combo_tituloid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_tituloid.SendProperty(context, "", false, Combo_tituloid_Internalname, "SelectedText_set", Combo_tituloid_Selectedtext_set);
         AV21ComboTituloId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV21ComboTituloId", StringUtil.LTrimStr( (decimal)(AV21ComboTituloId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_tituloid_Enabled = false;
            ucCombo_tituloid.SendProperty(context, "", false, Combo_tituloid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tituloid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOTIPOPAGAMENTOID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new titulomovimentoloaddvcombo(context ).execute(  "TipoPagamentoId",  Gx_mode,  false,  AV7TituloMovimentoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_tipopagamentoid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_tipopagamentoid.SendProperty(context, "", false, Combo_tipopagamentoid_Internalname, "SelectedValue_set", Combo_tipopagamentoid_Selectedvalue_set);
         Combo_tipopagamentoid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_tipopagamentoid.SendProperty(context, "", false, Combo_tipopagamentoid_Internalname, "SelectedText_set", Combo_tipopagamentoid_Selectedtext_set);
         AV19ComboTipoPagamentoId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV19ComboTipoPagamentoId", StringUtil.LTrimStr( (decimal)(AV19ComboTipoPagamentoId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_tipopagamentoid_Enabled = false;
            ucCombo_tipopagamentoid.SendProperty(context, "", false, Combo_tipopagamentoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tipopagamentoid_Enabled));
         }
      }

      protected void ZM1645( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z280TituloMovimentoCreatedAt = T00163_A280TituloMovimentoCreatedAt[0];
               Z281TituloMovimentoUpdatedAt = T00163_A281TituloMovimentoUpdatedAt[0];
               Z271TituloMovimentoValor = T00163_A271TituloMovimentoValor[0];
               Z272TituloMovimentoTipo = T00163_A272TituloMovimentoTipo[0];
               Z274TituloMovimentoSoma = T00163_A274TituloMovimentoSoma[0];
               Z279TituloMovimentoDataCredito = T00163_A279TituloMovimentoDataCredito[0];
               Z432TituloMovimentoOpe = T00163_A432TituloMovimentoOpe[0];
               Z288TipoPagamentoId = T00163_A288TipoPagamentoId[0];
               Z261TituloId = T00163_A261TituloId[0];
               Z433TituloMovimentoConta = T00163_A433TituloMovimentoConta[0];
            }
            else
            {
               Z280TituloMovimentoCreatedAt = A280TituloMovimentoCreatedAt;
               Z281TituloMovimentoUpdatedAt = A281TituloMovimentoUpdatedAt;
               Z271TituloMovimentoValor = A271TituloMovimentoValor;
               Z272TituloMovimentoTipo = A272TituloMovimentoTipo;
               Z274TituloMovimentoSoma = A274TituloMovimentoSoma;
               Z279TituloMovimentoDataCredito = A279TituloMovimentoDataCredito;
               Z432TituloMovimentoOpe = A432TituloMovimentoOpe;
               Z288TipoPagamentoId = A288TipoPagamentoId;
               Z261TituloId = A261TituloId;
               Z433TituloMovimentoConta = A433TituloMovimentoConta;
            }
         }
         if ( GX_JID == -17 )
         {
            Z270TituloMovimentoId = A270TituloMovimentoId;
            Z280TituloMovimentoCreatedAt = A280TituloMovimentoCreatedAt;
            Z281TituloMovimentoUpdatedAt = A281TituloMovimentoUpdatedAt;
            Z271TituloMovimentoValor = A271TituloMovimentoValor;
            Z272TituloMovimentoTipo = A272TituloMovimentoTipo;
            Z274TituloMovimentoSoma = A274TituloMovimentoSoma;
            Z279TituloMovimentoDataCredito = A279TituloMovimentoDataCredito;
            Z432TituloMovimentoOpe = A432TituloMovimentoOpe;
            Z288TipoPagamentoId = A288TipoPagamentoId;
            Z261TituloId = A261TituloId;
            Z433TituloMovimentoConta = A433TituloMovimentoConta;
            Z289TipoPagamentoNome = A289TipoPagamentoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTituloMovimentoId_Enabled = 0;
         AssignProp("", false, edtTituloMovimentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloMovimentoId_Enabled), 5, 0), true);
         AV24Pgmname = "TituloMovimento";
         AssignAttri("", false, "AV24Pgmname", AV24Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtTituloMovimentoId_Enabled = 0;
         AssignProp("", false, edtTituloMovimentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloMovimentoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TituloMovimentoId) )
         {
            A270TituloMovimentoId = AV7TituloMovimentoId;
            AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_TipoPagamentoId) )
         {
            edtTipoPagamentoId_Enabled = 0;
            AssignProp("", false, edtTipoPagamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoPagamentoId_Enabled), 5, 0), true);
         }
         else
         {
            edtTipoPagamentoId_Enabled = 1;
            AssignProp("", false, edtTipoPagamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoPagamentoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TituloId) )
         {
            edtTituloId_Enabled = 0;
            AssignProp("", false, edtTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloId_Enabled), 5, 0), true);
         }
         else
         {
            edtTituloId_Enabled = 1;
            AssignProp("", false, edtTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            A281TituloMovimentoUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n281TituloMovimentoUpdatedAt = false;
            AssignAttri("", false, "A281TituloMovimentoUpdatedAt", context.localUtil.TToC( A281TituloMovimentoUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
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
         if ( IsIns( )  )
         {
            A280TituloMovimentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n280TituloMovimentoCreatedAt = false;
            AssignAttri("", false, "A280TituloMovimentoCreatedAt", context.localUtil.TToC( A280TituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A280TituloMovimentoCreatedAt) && ( Gx_BScreen == 0 ) )
            {
               A280TituloMovimentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
               n280TituloMovimentoCreatedAt = false;
               AssignAttri("", false, "A280TituloMovimentoCreatedAt", context.localUtil.TToC( A280TituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
            }
         }
      }

      protected void Load1645( )
      {
         /* Using cursor T00167 */
         pr_default.execute(5, new Object[] {A270TituloMovimentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound45 = 1;
            A280TituloMovimentoCreatedAt = T00167_A280TituloMovimentoCreatedAt[0];
            n280TituloMovimentoCreatedAt = T00167_n280TituloMovimentoCreatedAt[0];
            AssignAttri("", false, "A280TituloMovimentoCreatedAt", context.localUtil.TToC( A280TituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
            A281TituloMovimentoUpdatedAt = T00167_A281TituloMovimentoUpdatedAt[0];
            n281TituloMovimentoUpdatedAt = T00167_n281TituloMovimentoUpdatedAt[0];
            AssignAttri("", false, "A281TituloMovimentoUpdatedAt", context.localUtil.TToC( A281TituloMovimentoUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
            A271TituloMovimentoValor = T00167_A271TituloMovimentoValor[0];
            n271TituloMovimentoValor = T00167_n271TituloMovimentoValor[0];
            AssignAttri("", false, "A271TituloMovimentoValor", ((Convert.ToDecimal(0)==A271TituloMovimentoValor)&&IsIns( )||n271TituloMovimentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A271TituloMovimentoValor, 18, 2, ".", ""))));
            A272TituloMovimentoTipo = T00167_A272TituloMovimentoTipo[0];
            n272TituloMovimentoTipo = T00167_n272TituloMovimentoTipo[0];
            AssignAttri("", false, "A272TituloMovimentoTipo", A272TituloMovimentoTipo);
            A274TituloMovimentoSoma = T00167_A274TituloMovimentoSoma[0];
            n274TituloMovimentoSoma = T00167_n274TituloMovimentoSoma[0];
            AssignAttri("", false, "A274TituloMovimentoSoma", A274TituloMovimentoSoma);
            A279TituloMovimentoDataCredito = T00167_A279TituloMovimentoDataCredito[0];
            n279TituloMovimentoDataCredito = T00167_n279TituloMovimentoDataCredito[0];
            AssignAttri("", false, "A279TituloMovimentoDataCredito", context.localUtil.Format(A279TituloMovimentoDataCredito, "99/99/9999"));
            A289TipoPagamentoNome = T00167_A289TipoPagamentoNome[0];
            A432TituloMovimentoOpe = T00167_A432TituloMovimentoOpe[0];
            n432TituloMovimentoOpe = T00167_n432TituloMovimentoOpe[0];
            A288TipoPagamentoId = T00167_A288TipoPagamentoId[0];
            n288TipoPagamentoId = T00167_n288TipoPagamentoId[0];
            AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
            A261TituloId = T00167_A261TituloId[0];
            n261TituloId = T00167_n261TituloId[0];
            AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            A433TituloMovimentoConta = T00167_A433TituloMovimentoConta[0];
            n433TituloMovimentoConta = T00167_n433TituloMovimentoConta[0];
            ZM1645( -17) ;
         }
         pr_default.close(5);
         OnLoadActions1645( ) ;
      }

      protected void OnLoadActions1645( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_TipoPagamentoId) )
         {
            A288TipoPagamentoId = AV11Insert_TipoPagamentoId;
            n288TipoPagamentoId = false;
            AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboTipoPagamentoId) )
            {
               A288TipoPagamentoId = 0;
               n288TipoPagamentoId = false;
               AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
               n288TipoPagamentoId = true;
               n288TipoPagamentoId = true;
               AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboTipoPagamentoId) )
               {
                  A288TipoPagamentoId = AV19ComboTipoPagamentoId;
                  n288TipoPagamentoId = false;
                  AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A288TipoPagamentoId) )
                  {
                     A288TipoPagamentoId = 0;
                     n288TipoPagamentoId = false;
                     AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
                     n288TipoPagamentoId = true;
                     n288TipoPagamentoId = true;
                     AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TituloId) )
         {
            A261TituloId = AV12Insert_TituloId;
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV21ComboTituloId) )
            {
               A261TituloId = 0;
               n261TituloId = false;
               AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
               n261TituloId = true;
               n261TituloId = true;
               AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV21ComboTituloId) )
               {
                  A261TituloId = AV21ComboTituloId;
                  n261TituloId = false;
                  AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A261TituloId) )
                  {
                     A261TituloId = 0;
                     n261TituloId = false;
                     AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
                     n261TituloId = true;
                     n261TituloId = true;
                     AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_TituloMovimentoConta) )
         {
            A433TituloMovimentoConta = AV22Insert_TituloMovimentoConta;
            n433TituloMovimentoConta = false;
            AssignAttri("", false, "A433TituloMovimentoConta", ((0==A433TituloMovimentoConta)&&IsIns( )||n433TituloMovimentoConta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A433TituloMovimentoConta), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A433TituloMovimentoConta) )
            {
               A433TituloMovimentoConta = 0;
               n433TituloMovimentoConta = false;
               AssignAttri("", false, "A433TituloMovimentoConta", ((0==A433TituloMovimentoConta)&&IsIns( )||n433TituloMovimentoConta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A433TituloMovimentoConta), 9, 0, ".", ""))));
               n433TituloMovimentoConta = true;
               n433TituloMovimentoConta = true;
               AssignAttri("", false, "A433TituloMovimentoConta", ((0==A433TituloMovimentoConta)&&IsIns( )||n433TituloMovimentoConta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A433TituloMovimentoConta), 9, 0, ".", ""))));
            }
         }
      }

      protected void CheckExtendedTable1645( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_TipoPagamentoId) )
         {
            A288TipoPagamentoId = AV11Insert_TipoPagamentoId;
            n288TipoPagamentoId = false;
            AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboTipoPagamentoId) )
            {
               A288TipoPagamentoId = 0;
               n288TipoPagamentoId = false;
               AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
               n288TipoPagamentoId = true;
               n288TipoPagamentoId = true;
               AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboTipoPagamentoId) )
               {
                  A288TipoPagamentoId = AV19ComboTipoPagamentoId;
                  n288TipoPagamentoId = false;
                  AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A288TipoPagamentoId) )
                  {
                     A288TipoPagamentoId = 0;
                     n288TipoPagamentoId = false;
                     AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
                     n288TipoPagamentoId = true;
                     n288TipoPagamentoId = true;
                     AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TituloId) )
         {
            A261TituloId = AV12Insert_TituloId;
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV21ComboTituloId) )
            {
               A261TituloId = 0;
               n261TituloId = false;
               AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
               n261TituloId = true;
               n261TituloId = true;
               AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV21ComboTituloId) )
               {
                  A261TituloId = AV21ComboTituloId;
                  n261TituloId = false;
                  AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A261TituloId) )
                  {
                     A261TituloId = 0;
                     n261TituloId = false;
                     AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
                     n261TituloId = true;
                     n261TituloId = true;
                     AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_TituloMovimentoConta) )
         {
            A433TituloMovimentoConta = AV22Insert_TituloMovimentoConta;
            n433TituloMovimentoConta = false;
            AssignAttri("", false, "A433TituloMovimentoConta", ((0==A433TituloMovimentoConta)&&IsIns( )||n433TituloMovimentoConta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A433TituloMovimentoConta), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A433TituloMovimentoConta) )
            {
               A433TituloMovimentoConta = 0;
               n433TituloMovimentoConta = false;
               AssignAttri("", false, "A433TituloMovimentoConta", ((0==A433TituloMovimentoConta)&&IsIns( )||n433TituloMovimentoConta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A433TituloMovimentoConta), 9, 0, ".", ""))));
               n433TituloMovimentoConta = true;
               n433TituloMovimentoConta = true;
               AssignAttri("", false, "A433TituloMovimentoConta", ((0==A433TituloMovimentoConta)&&IsIns( )||n433TituloMovimentoConta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A433TituloMovimentoConta), 9, 0, ".", ""))));
            }
         }
         /* Using cursor T00164 */
         pr_default.execute(2, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A288TipoPagamentoId) ) )
            {
               GX_msglist.addItem("Não existe 'TipoPagamento'.", "ForeignKeyNotFound", 1, "TIPOPAGAMENTOID");
               AnyError = 1;
               GX_FocusControl = edtTipoPagamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A289TipoPagamentoNome = T00164_A289TipoPagamentoNome[0];
         pr_default.close(2);
         /* Using cursor T00165 */
         pr_default.execute(3, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A261TituloId) ) )
            {
               GX_msglist.addItem("Não existe 'Titulo'.", "ForeignKeyNotFound", 1, "TITULOID");
               AnyError = 1;
               GX_FocusControl = edtTituloId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         if ( ( A271TituloMovimentoValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "TITULOMOVIMENTOVALOR");
            AnyError = 1;
            GX_FocusControl = edtTituloMovimentoValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A272TituloMovimentoTipo, "Baixa") == 0 ) || ( StringUtil.StrCmp(A272TituloMovimentoTipo, "Juros") == 0 ) || ( StringUtil.StrCmp(A272TituloMovimentoTipo, "Taxa") == 0 ) || ( StringUtil.StrCmp(A272TituloMovimentoTipo, "Multa") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A272TituloMovimentoTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo baixa fora do intervalo", "OutOfRange", 1, "TITULOMOVIMENTOTIPO");
            AnyError = 1;
            GX_FocusControl = cmbTituloMovimentoTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00166 */
         pr_default.execute(4, new Object[] {n433TituloMovimentoConta, A433TituloMovimentoConta});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A433TituloMovimentoConta) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Conta Movimento Id'.", "ForeignKeyNotFound", 1, "TITULOMOVIMENTOCONTA");
               AnyError = 1;
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1645( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_18( int A288TipoPagamentoId )
      {
         /* Using cursor T00168 */
         pr_default.execute(6, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A288TipoPagamentoId) ) )
            {
               GX_msglist.addItem("Não existe 'TipoPagamento'.", "ForeignKeyNotFound", 1, "TIPOPAGAMENTOID");
               AnyError = 1;
               GX_FocusControl = edtTipoPagamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A289TipoPagamentoNome = T00168_A289TipoPagamentoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A289TipoPagamentoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_19( int A261TituloId )
      {
         /* Using cursor T00169 */
         pr_default.execute(7, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A261TituloId) ) )
            {
               GX_msglist.addItem("Não existe 'Titulo'.", "ForeignKeyNotFound", 1, "TITULOID");
               AnyError = 1;
               GX_FocusControl = edtTituloId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_20( int A433TituloMovimentoConta )
      {
         /* Using cursor T001610 */
         pr_default.execute(8, new Object[] {n433TituloMovimentoConta, A433TituloMovimentoConta});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A433TituloMovimentoConta) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Conta Movimento Id'.", "ForeignKeyNotFound", 1, "TITULOMOVIMENTOCONTA");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey1645( )
      {
         /* Using cursor T001611 */
         pr_default.execute(9, new Object[] {A270TituloMovimentoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound45 = 1;
         }
         else
         {
            RcdFound45 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00163 */
         pr_default.execute(1, new Object[] {A270TituloMovimentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1645( 17) ;
            RcdFound45 = 1;
            A270TituloMovimentoId = T00163_A270TituloMovimentoId[0];
            AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
            A280TituloMovimentoCreatedAt = T00163_A280TituloMovimentoCreatedAt[0];
            n280TituloMovimentoCreatedAt = T00163_n280TituloMovimentoCreatedAt[0];
            AssignAttri("", false, "A280TituloMovimentoCreatedAt", context.localUtil.TToC( A280TituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
            A281TituloMovimentoUpdatedAt = T00163_A281TituloMovimentoUpdatedAt[0];
            n281TituloMovimentoUpdatedAt = T00163_n281TituloMovimentoUpdatedAt[0];
            AssignAttri("", false, "A281TituloMovimentoUpdatedAt", context.localUtil.TToC( A281TituloMovimentoUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
            A271TituloMovimentoValor = T00163_A271TituloMovimentoValor[0];
            n271TituloMovimentoValor = T00163_n271TituloMovimentoValor[0];
            AssignAttri("", false, "A271TituloMovimentoValor", ((Convert.ToDecimal(0)==A271TituloMovimentoValor)&&IsIns( )||n271TituloMovimentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A271TituloMovimentoValor, 18, 2, ".", ""))));
            A272TituloMovimentoTipo = T00163_A272TituloMovimentoTipo[0];
            n272TituloMovimentoTipo = T00163_n272TituloMovimentoTipo[0];
            AssignAttri("", false, "A272TituloMovimentoTipo", A272TituloMovimentoTipo);
            A274TituloMovimentoSoma = T00163_A274TituloMovimentoSoma[0];
            n274TituloMovimentoSoma = T00163_n274TituloMovimentoSoma[0];
            AssignAttri("", false, "A274TituloMovimentoSoma", A274TituloMovimentoSoma);
            A279TituloMovimentoDataCredito = T00163_A279TituloMovimentoDataCredito[0];
            n279TituloMovimentoDataCredito = T00163_n279TituloMovimentoDataCredito[0];
            AssignAttri("", false, "A279TituloMovimentoDataCredito", context.localUtil.Format(A279TituloMovimentoDataCredito, "99/99/9999"));
            A432TituloMovimentoOpe = T00163_A432TituloMovimentoOpe[0];
            n432TituloMovimentoOpe = T00163_n432TituloMovimentoOpe[0];
            A288TipoPagamentoId = T00163_A288TipoPagamentoId[0];
            n288TipoPagamentoId = T00163_n288TipoPagamentoId[0];
            AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
            A261TituloId = T00163_A261TituloId[0];
            n261TituloId = T00163_n261TituloId[0];
            AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            A433TituloMovimentoConta = T00163_A433TituloMovimentoConta[0];
            n433TituloMovimentoConta = T00163_n433TituloMovimentoConta[0];
            Z270TituloMovimentoId = A270TituloMovimentoId;
            sMode45 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1645( ) ;
            if ( AnyError == 1 )
            {
               RcdFound45 = 0;
               InitializeNonKey1645( ) ;
            }
            Gx_mode = sMode45;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound45 = 0;
            InitializeNonKey1645( ) ;
            sMode45 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode45;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1645( ) ;
         if ( RcdFound45 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound45 = 0;
         /* Using cursor T001612 */
         pr_default.execute(10, new Object[] {A270TituloMovimentoId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T001612_A270TituloMovimentoId[0] < A270TituloMovimentoId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T001612_A270TituloMovimentoId[0] > A270TituloMovimentoId ) ) )
            {
               A270TituloMovimentoId = T001612_A270TituloMovimentoId[0];
               AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
               RcdFound45 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound45 = 0;
         /* Using cursor T001613 */
         pr_default.execute(11, new Object[] {A270TituloMovimentoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T001613_A270TituloMovimentoId[0] > A270TituloMovimentoId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T001613_A270TituloMovimentoId[0] < A270TituloMovimentoId ) ) )
            {
               A270TituloMovimentoId = T001613_A270TituloMovimentoId[0];
               AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
               RcdFound45 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1645( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipoPagamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1645( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound45 == 1 )
            {
               if ( A270TituloMovimentoId != Z270TituloMovimentoId )
               {
                  A270TituloMovimentoId = Z270TituloMovimentoId;
                  AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TITULOMOVIMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtTituloMovimentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipoPagamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1645( ) ;
                  GX_FocusControl = edtTipoPagamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A270TituloMovimentoId != Z270TituloMovimentoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTipoPagamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1645( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TITULOMOVIMENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtTituloMovimentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTipoPagamentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1645( ) ;
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
         if ( A270TituloMovimentoId != Z270TituloMovimentoId )
         {
            A270TituloMovimentoId = Z270TituloMovimentoId;
            AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TITULOMOVIMENTOID");
            AnyError = 1;
            GX_FocusControl = edtTituloMovimentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipoPagamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1645( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00162 */
            pr_default.execute(0, new Object[] {A270TituloMovimentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TituloMovimento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z280TituloMovimentoCreatedAt != T00162_A280TituloMovimentoCreatedAt[0] ) || ( Z281TituloMovimentoUpdatedAt != T00162_A281TituloMovimentoUpdatedAt[0] ) || ( Z271TituloMovimentoValor != T00162_A271TituloMovimentoValor[0] ) || ( StringUtil.StrCmp(Z272TituloMovimentoTipo, T00162_A272TituloMovimentoTipo[0]) != 0 ) || ( Z274TituloMovimentoSoma != T00162_A274TituloMovimentoSoma[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z279TituloMovimentoDataCredito ) != DateTimeUtil.ResetTime ( T00162_A279TituloMovimentoDataCredito[0] ) ) || ( StringUtil.StrCmp(Z432TituloMovimentoOpe, T00162_A432TituloMovimentoOpe[0]) != 0 ) || ( Z288TipoPagamentoId != T00162_A288TipoPagamentoId[0] ) || ( Z261TituloId != T00162_A261TituloId[0] ) || ( Z433TituloMovimentoConta != T00162_A433TituloMovimentoConta[0] ) )
            {
               if ( Z280TituloMovimentoCreatedAt != T00162_A280TituloMovimentoCreatedAt[0] )
               {
                  GXUtil.WriteLog("titulomovimento:[seudo value changed for attri]"+"TituloMovimentoCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z280TituloMovimentoCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00162_A280TituloMovimentoCreatedAt[0]);
               }
               if ( Z281TituloMovimentoUpdatedAt != T00162_A281TituloMovimentoUpdatedAt[0] )
               {
                  GXUtil.WriteLog("titulomovimento:[seudo value changed for attri]"+"TituloMovimentoUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z281TituloMovimentoUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00162_A281TituloMovimentoUpdatedAt[0]);
               }
               if ( Z271TituloMovimentoValor != T00162_A271TituloMovimentoValor[0] )
               {
                  GXUtil.WriteLog("titulomovimento:[seudo value changed for attri]"+"TituloMovimentoValor");
                  GXUtil.WriteLogRaw("Old: ",Z271TituloMovimentoValor);
                  GXUtil.WriteLogRaw("Current: ",T00162_A271TituloMovimentoValor[0]);
               }
               if ( StringUtil.StrCmp(Z272TituloMovimentoTipo, T00162_A272TituloMovimentoTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("titulomovimento:[seudo value changed for attri]"+"TituloMovimentoTipo");
                  GXUtil.WriteLogRaw("Old: ",Z272TituloMovimentoTipo);
                  GXUtil.WriteLogRaw("Current: ",T00162_A272TituloMovimentoTipo[0]);
               }
               if ( Z274TituloMovimentoSoma != T00162_A274TituloMovimentoSoma[0] )
               {
                  GXUtil.WriteLog("titulomovimento:[seudo value changed for attri]"+"TituloMovimentoSoma");
                  GXUtil.WriteLogRaw("Old: ",Z274TituloMovimentoSoma);
                  GXUtil.WriteLogRaw("Current: ",T00162_A274TituloMovimentoSoma[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z279TituloMovimentoDataCredito ) != DateTimeUtil.ResetTime ( T00162_A279TituloMovimentoDataCredito[0] ) )
               {
                  GXUtil.WriteLog("titulomovimento:[seudo value changed for attri]"+"TituloMovimentoDataCredito");
                  GXUtil.WriteLogRaw("Old: ",Z279TituloMovimentoDataCredito);
                  GXUtil.WriteLogRaw("Current: ",T00162_A279TituloMovimentoDataCredito[0]);
               }
               if ( StringUtil.StrCmp(Z432TituloMovimentoOpe, T00162_A432TituloMovimentoOpe[0]) != 0 )
               {
                  GXUtil.WriteLog("titulomovimento:[seudo value changed for attri]"+"TituloMovimentoOpe");
                  GXUtil.WriteLogRaw("Old: ",Z432TituloMovimentoOpe);
                  GXUtil.WriteLogRaw("Current: ",T00162_A432TituloMovimentoOpe[0]);
               }
               if ( Z288TipoPagamentoId != T00162_A288TipoPagamentoId[0] )
               {
                  GXUtil.WriteLog("titulomovimento:[seudo value changed for attri]"+"TipoPagamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z288TipoPagamentoId);
                  GXUtil.WriteLogRaw("Current: ",T00162_A288TipoPagamentoId[0]);
               }
               if ( Z261TituloId != T00162_A261TituloId[0] )
               {
                  GXUtil.WriteLog("titulomovimento:[seudo value changed for attri]"+"TituloId");
                  GXUtil.WriteLogRaw("Old: ",Z261TituloId);
                  GXUtil.WriteLogRaw("Current: ",T00162_A261TituloId[0]);
               }
               if ( Z433TituloMovimentoConta != T00162_A433TituloMovimentoConta[0] )
               {
                  GXUtil.WriteLog("titulomovimento:[seudo value changed for attri]"+"TituloMovimentoConta");
                  GXUtil.WriteLogRaw("Old: ",Z433TituloMovimentoConta);
                  GXUtil.WriteLogRaw("Current: ",T00162_A433TituloMovimentoConta[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TituloMovimento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1645( )
      {
         BeforeValidate1645( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1645( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1645( 0) ;
            CheckOptimisticConcurrency1645( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1645( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1645( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001614 */
                     pr_default.execute(12, new Object[] {n280TituloMovimentoCreatedAt, A280TituloMovimentoCreatedAt, n281TituloMovimentoUpdatedAt, A281TituloMovimentoUpdatedAt, n271TituloMovimentoValor, A271TituloMovimentoValor, n272TituloMovimentoTipo, A272TituloMovimentoTipo, n274TituloMovimentoSoma, A274TituloMovimentoSoma, n279TituloMovimentoDataCredito, A279TituloMovimentoDataCredito, n432TituloMovimentoOpe, A432TituloMovimentoOpe, n288TipoPagamentoId, A288TipoPagamentoId, n261TituloId, A261TituloId, n433TituloMovimentoConta, A433TituloMovimentoConta});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001615 */
                     pr_default.execute(13);
                     A270TituloMovimentoId = T001615_A270TituloMovimentoId[0];
                     AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("TituloMovimento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption160( ) ;
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
               Load1645( ) ;
            }
            EndLevel1645( ) ;
         }
         CloseExtendedTableCursors1645( ) ;
      }

      protected void Update1645( )
      {
         BeforeValidate1645( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1645( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1645( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1645( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1645( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001616 */
                     pr_default.execute(14, new Object[] {n280TituloMovimentoCreatedAt, A280TituloMovimentoCreatedAt, n281TituloMovimentoUpdatedAt, A281TituloMovimentoUpdatedAt, n271TituloMovimentoValor, A271TituloMovimentoValor, n272TituloMovimentoTipo, A272TituloMovimentoTipo, n274TituloMovimentoSoma, A274TituloMovimentoSoma, n279TituloMovimentoDataCredito, A279TituloMovimentoDataCredito, n432TituloMovimentoOpe, A432TituloMovimentoOpe, n288TipoPagamentoId, A288TipoPagamentoId, n261TituloId, A261TituloId, n433TituloMovimentoConta, A433TituloMovimentoConta, A270TituloMovimentoId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("TituloMovimento");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TituloMovimento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1645( ) ;
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
            EndLevel1645( ) ;
         }
         CloseExtendedTableCursors1645( ) ;
      }

      protected void DeferredUpdate1645( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1645( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1645( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1645( ) ;
            AfterConfirm1645( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1645( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001617 */
                  pr_default.execute(15, new Object[] {A270TituloMovimentoId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("TituloMovimento");
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
         sMode45 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1645( ) ;
         Gx_mode = sMode45;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1645( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001618 */
            pr_default.execute(16, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
            A289TipoPagamentoNome = T001618_A289TipoPagamentoNome[0];
            pr_default.close(16);
         }
      }

      protected void EndLevel1645( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1645( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("titulomovimento",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues160( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("titulomovimento",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1645( )
      {
         /* Scan By routine */
         /* Using cursor T001619 */
         pr_default.execute(17);
         RcdFound45 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound45 = 1;
            A270TituloMovimentoId = T001619_A270TituloMovimentoId[0];
            AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1645( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound45 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound45 = 1;
            A270TituloMovimentoId = T001619_A270TituloMovimentoId[0];
            AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
         }
      }

      protected void ScanEnd1645( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm1645( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1645( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1645( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1645( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1645( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1645( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1645( )
      {
         edtTituloMovimentoId_Enabled = 0;
         AssignProp("", false, edtTituloMovimentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloMovimentoId_Enabled), 5, 0), true);
         edtTipoPagamentoId_Enabled = 0;
         AssignProp("", false, edtTipoPagamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoPagamentoId_Enabled), 5, 0), true);
         edtTituloId_Enabled = 0;
         AssignProp("", false, edtTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloId_Enabled), 5, 0), true);
         edtTituloMovimentoValor_Enabled = 0;
         AssignProp("", false, edtTituloMovimentoValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloMovimentoValor_Enabled), 5, 0), true);
         cmbTituloMovimentoTipo.Enabled = 0;
         AssignProp("", false, cmbTituloMovimentoTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTituloMovimentoTipo.Enabled), 5, 0), true);
         chkTituloMovimentoSoma.Enabled = 0;
         AssignProp("", false, chkTituloMovimentoSoma_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTituloMovimentoSoma.Enabled), 5, 0), true);
         edtTituloMovimentoDataCredito_Enabled = 0;
         AssignProp("", false, edtTituloMovimentoDataCredito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloMovimentoDataCredito_Enabled), 5, 0), true);
         edtTituloMovimentoCreatedAt_Enabled = 0;
         AssignProp("", false, edtTituloMovimentoCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloMovimentoCreatedAt_Enabled), 5, 0), true);
         edtTituloMovimentoUpdatedAt_Enabled = 0;
         AssignProp("", false, edtTituloMovimentoUpdatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloMovimentoUpdatedAt_Enabled), 5, 0), true);
         edtavCombotipopagamentoid_Enabled = 0;
         AssignProp("", false, edtavCombotipopagamentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotipopagamentoid_Enabled), 5, 0), true);
         edtavCombotituloid_Enabled = 0;
         AssignProp("", false, edtavCombotituloid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotituloid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1645( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues160( )
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
         GXEncryptionTmp = "titulomovimento"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TituloMovimentoId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("titulomovimento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TituloMovimento");
         forbiddenHiddens.Add("TituloMovimentoId", context.localUtil.Format( (decimal)(A270TituloMovimentoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_TipoPagamentoId", context.localUtil.Format( (decimal)(AV11Insert_TipoPagamentoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_TituloId", context.localUtil.Format( (decimal)(AV12Insert_TituloId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_TituloMovimentoConta", context.localUtil.Format( (decimal)(AV22Insert_TituloMovimentoConta), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("TituloMovimentoOpe", StringUtil.RTrim( context.localUtil.Format( A432TituloMovimentoOpe, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("titulomovimento:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z270TituloMovimentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z270TituloMovimentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z280TituloMovimentoCreatedAt", context.localUtil.TToC( Z280TituloMovimentoCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z281TituloMovimentoUpdatedAt", context.localUtil.TToC( Z281TituloMovimentoUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z271TituloMovimentoValor", StringUtil.LTrim( StringUtil.NToC( Z271TituloMovimentoValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z272TituloMovimentoTipo", Z272TituloMovimentoTipo);
         GxWebStd.gx_boolean_hidden_field( context, "Z274TituloMovimentoSoma", Z274TituloMovimentoSoma);
         GxWebStd.gx_hidden_field( context, "Z279TituloMovimentoDataCredito", context.localUtil.DToC( Z279TituloMovimentoDataCredito, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z432TituloMovimentoOpe", Z432TituloMovimentoOpe);
         GxWebStd.gx_hidden_field( context, "Z288TipoPagamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z288TipoPagamentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z261TituloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z261TituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z433TituloMovimentoConta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z433TituloMovimentoConta), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N288TipoPagamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N261TituloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N433TituloMovimentoConta", StringUtil.LTrim( StringUtil.NToC( (decimal)(A433TituloMovimentoConta), 9, 0, ",", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPOPAGAMENTOID_DATA", AV14TipoPagamentoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPOPAGAMENTOID_DATA", AV14TipoPagamentoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTITULOID_DATA", AV20TituloId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTITULOID_DATA", AV20TituloId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vTITULOMOVIMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TituloMovimentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTITULOMOVIMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TituloMovimentoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPOPAGAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_TipoPagamentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_TituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TITULOMOVIMENTOCONTA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Insert_TituloMovimentoConta), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOMOVIMENTOCONTA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A433TituloMovimentoConta), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOMOVIMENTOOPE", A432TituloMovimentoOpe);
         GxWebStd.gx_hidden_field( context, "TIPOPAGAMENTONOME", A289TipoPagamentoNome);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV24Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Objectcall", StringUtil.RTrim( Combo_tipopagamentoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Cls", StringUtil.RTrim( Combo_tipopagamentoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Selectedvalue_set", StringUtil.RTrim( Combo_tipopagamentoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Selectedtext_set", StringUtil.RTrim( Combo_tipopagamentoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Enabled", StringUtil.BoolToStr( Combo_tipopagamentoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Datalistproc", StringUtil.RTrim( Combo_tipopagamentoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPOPAGAMENTOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_tipopagamentoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Objectcall", StringUtil.RTrim( Combo_tituloid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Cls", StringUtil.RTrim( Combo_tituloid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Selectedvalue_set", StringUtil.RTrim( Combo_tituloid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Selectedtext_set", StringUtil.RTrim( Combo_tituloid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Enabled", StringUtil.BoolToStr( Combo_tituloid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Datalistproc", StringUtil.RTrim( Combo_tituloid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_TITULOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_tituloid_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "titulomovimento"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TituloMovimentoId,9,0));
         return formatLink("titulomovimento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "TituloMovimento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Titulo Movimento" ;
      }

      protected void InitializeNonKey1645( )
      {
         A288TipoPagamentoId = 0;
         n288TipoPagamentoId = false;
         AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
         n288TipoPagamentoId = ((0==A288TipoPagamentoId) ? true : false);
         A261TituloId = 0;
         n261TituloId = false;
         AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
         n261TituloId = ((0==A261TituloId) ? true : false);
         A433TituloMovimentoConta = 0;
         n433TituloMovimentoConta = false;
         AssignAttri("", false, "A433TituloMovimentoConta", ((0==A433TituloMovimentoConta)&&IsIns( )||n433TituloMovimentoConta ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A433TituloMovimentoConta), 9, 0, ".", ""))));
         A280TituloMovimentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n280TituloMovimentoCreatedAt = false;
         AssignAttri("", false, "A280TituloMovimentoCreatedAt", context.localUtil.TToC( A280TituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         A281TituloMovimentoUpdatedAt = (DateTime)(DateTime.MinValue);
         n281TituloMovimentoUpdatedAt = false;
         AssignAttri("", false, "A281TituloMovimentoUpdatedAt", context.localUtil.TToC( A281TituloMovimentoUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
         n281TituloMovimentoUpdatedAt = ((DateTime.MinValue==A281TituloMovimentoUpdatedAt) ? true : false);
         A271TituloMovimentoValor = 0;
         n271TituloMovimentoValor = false;
         AssignAttri("", false, "A271TituloMovimentoValor", ((Convert.ToDecimal(0)==A271TituloMovimentoValor)&&IsIns( )||n271TituloMovimentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A271TituloMovimentoValor, 18, 2, ".", ""))));
         n271TituloMovimentoValor = ((Convert.ToDecimal(0)==A271TituloMovimentoValor) ? true : false);
         A272TituloMovimentoTipo = "";
         n272TituloMovimentoTipo = false;
         AssignAttri("", false, "A272TituloMovimentoTipo", A272TituloMovimentoTipo);
         n272TituloMovimentoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A272TituloMovimentoTipo)) ? true : false);
         A274TituloMovimentoSoma = false;
         n274TituloMovimentoSoma = false;
         AssignAttri("", false, "A274TituloMovimentoSoma", A274TituloMovimentoSoma);
         n274TituloMovimentoSoma = ((false==A274TituloMovimentoSoma) ? true : false);
         A279TituloMovimentoDataCredito = DateTime.MinValue;
         n279TituloMovimentoDataCredito = false;
         AssignAttri("", false, "A279TituloMovimentoDataCredito", context.localUtil.Format(A279TituloMovimentoDataCredito, "99/99/9999"));
         n279TituloMovimentoDataCredito = ((DateTime.MinValue==A279TituloMovimentoDataCredito) ? true : false);
         A289TipoPagamentoNome = "";
         AssignAttri("", false, "A289TipoPagamentoNome", A289TipoPagamentoNome);
         A432TituloMovimentoOpe = "";
         n432TituloMovimentoOpe = false;
         AssignAttri("", false, "A432TituloMovimentoOpe", A432TituloMovimentoOpe);
         Z280TituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         Z281TituloMovimentoUpdatedAt = (DateTime)(DateTime.MinValue);
         Z271TituloMovimentoValor = 0;
         Z272TituloMovimentoTipo = "";
         Z274TituloMovimentoSoma = false;
         Z279TituloMovimentoDataCredito = DateTime.MinValue;
         Z432TituloMovimentoOpe = "";
         Z288TipoPagamentoId = 0;
         Z261TituloId = 0;
         Z433TituloMovimentoConta = 0;
      }

      protected void InitAll1645( )
      {
         A270TituloMovimentoId = 0;
         AssignAttri("", false, "A270TituloMovimentoId", StringUtil.LTrimStr( (decimal)(A270TituloMovimentoId), 9, 0));
         InitializeNonKey1645( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A280TituloMovimentoCreatedAt = i280TituloMovimentoCreatedAt;
         n280TituloMovimentoCreatedAt = false;
         AssignAttri("", false, "A280TituloMovimentoCreatedAt", context.localUtil.TToC( A280TituloMovimentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019144775", true, true);
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
         context.AddJavascriptSource("titulomovimento.js", "?202561019144775", false, true);
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
         edtTituloMovimentoId_Internalname = "TITULOMOVIMENTOID";
         lblTextblocktipopagamentoid_Internalname = "TEXTBLOCKTIPOPAGAMENTOID";
         Combo_tipopagamentoid_Internalname = "COMBO_TIPOPAGAMENTOID";
         edtTipoPagamentoId_Internalname = "TIPOPAGAMENTOID";
         divTablesplittedtipopagamentoid_Internalname = "TABLESPLITTEDTIPOPAGAMENTOID";
         lblTextblocktituloid_Internalname = "TEXTBLOCKTITULOID";
         Combo_tituloid_Internalname = "COMBO_TITULOID";
         edtTituloId_Internalname = "TITULOID";
         divTablesplittedtituloid_Internalname = "TABLESPLITTEDTITULOID";
         edtTituloMovimentoValor_Internalname = "TITULOMOVIMENTOVALOR";
         cmbTituloMovimentoTipo_Internalname = "TITULOMOVIMENTOTIPO";
         chkTituloMovimentoSoma_Internalname = "TITULOMOVIMENTOSOMA";
         edtTituloMovimentoDataCredito_Internalname = "TITULOMOVIMENTODATACREDITO";
         edtTituloMovimentoCreatedAt_Internalname = "TITULOMOVIMENTOCREATEDAT";
         edtTituloMovimentoUpdatedAt_Internalname = "TITULOMOVIMENTOUPDATEDAT";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombotipopagamentoid_Internalname = "vCOMBOTIPOPAGAMENTOID";
         divSectionattribute_tipopagamentoid_Internalname = "SECTIONATTRIBUTE_TIPOPAGAMENTOID";
         edtavCombotituloid_Internalname = "vCOMBOTITULOID";
         divSectionattribute_tituloid_Internalname = "SECTIONATTRIBUTE_TITULOID";
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
         Form.Caption = "Titulo Movimento";
         edtavCombotituloid_Jsonclick = "";
         edtavCombotituloid_Enabled = 0;
         edtavCombotituloid_Visible = 1;
         edtavCombotipopagamentoid_Jsonclick = "";
         edtavCombotipopagamentoid_Enabled = 0;
         edtavCombotipopagamentoid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTituloMovimentoUpdatedAt_Jsonclick = "";
         edtTituloMovimentoUpdatedAt_Enabled = 1;
         edtTituloMovimentoCreatedAt_Jsonclick = "";
         edtTituloMovimentoCreatedAt_Enabled = 1;
         edtTituloMovimentoDataCredito_Jsonclick = "";
         edtTituloMovimentoDataCredito_Enabled = 1;
         chkTituloMovimentoSoma.Enabled = 1;
         cmbTituloMovimentoTipo_Jsonclick = "";
         cmbTituloMovimentoTipo.Enabled = 1;
         edtTituloMovimentoValor_Jsonclick = "";
         edtTituloMovimentoValor_Enabled = 1;
         edtTituloId_Jsonclick = "";
         edtTituloId_Enabled = 1;
         edtTituloId_Visible = 1;
         Combo_tituloid_Datalistprocparametersprefix = " \"ComboName\": \"TituloId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"TituloMovimentoId\": 0";
         Combo_tituloid_Datalistproc = "TituloMovimentoLoadDVCombo";
         Combo_tituloid_Cls = "ExtendedCombo AttributeFL";
         Combo_tituloid_Caption = "";
         Combo_tituloid_Enabled = Convert.ToBoolean( -1);
         edtTipoPagamentoId_Jsonclick = "";
         edtTipoPagamentoId_Enabled = 1;
         edtTipoPagamentoId_Visible = 1;
         Combo_tipopagamentoid_Datalistprocparametersprefix = " \"ComboName\": \"TipoPagamentoId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"TituloMovimentoId\": 0";
         Combo_tipopagamentoid_Datalistproc = "TituloMovimentoLoadDVCombo";
         Combo_tipopagamentoid_Cls = "ExtendedCombo AttributeFL";
         Combo_tipopagamentoid_Caption = "";
         Combo_tipopagamentoid_Enabled = Convert.ToBoolean( -1);
         edtTituloMovimentoId_Jsonclick = "";
         edtTituloMovimentoId_Enabled = 0;
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
         cmbTituloMovimentoTipo.Name = "TITULOMOVIMENTOTIPO";
         cmbTituloMovimentoTipo.WebTags = "";
         cmbTituloMovimentoTipo.addItem("Baixa", "Baixa", 0);
         cmbTituloMovimentoTipo.addItem("Juros", "Juros", 0);
         cmbTituloMovimentoTipo.addItem("Taxa", "Taxa", 0);
         cmbTituloMovimentoTipo.addItem("Multa", "Multa", 0);
         if ( cmbTituloMovimentoTipo.ItemCount > 0 )
         {
            A272TituloMovimentoTipo = cmbTituloMovimentoTipo.getValidValue(A272TituloMovimentoTipo);
            n272TituloMovimentoTipo = false;
            AssignAttri("", false, "A272TituloMovimentoTipo", A272TituloMovimentoTipo);
         }
         chkTituloMovimentoSoma.Name = "TITULOMOVIMENTOSOMA";
         chkTituloMovimentoSoma.WebTags = "";
         chkTituloMovimentoSoma.Caption = "Movimento Soma";
         AssignProp("", false, chkTituloMovimentoSoma_Internalname, "TitleCaption", chkTituloMovimentoSoma.Caption, true);
         chkTituloMovimentoSoma.CheckedValue = "false";
         A274TituloMovimentoSoma = StringUtil.StrToBool( StringUtil.BoolToStr( A274TituloMovimentoSoma));
         n274TituloMovimentoSoma = false;
         AssignAttri("", false, "A274TituloMovimentoSoma", A274TituloMovimentoSoma);
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

      public void Valid_Tipopagamentoid( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_TipoPagamentoId) )
         {
            A288TipoPagamentoId = AV11Insert_TipoPagamentoId;
            n288TipoPagamentoId = false;
         }
         else
         {
            if ( (0==AV19ComboTipoPagamentoId) )
            {
               A288TipoPagamentoId = 0;
               n288TipoPagamentoId = false;
               n288TipoPagamentoId = true;
               n288TipoPagamentoId = true;
            }
            else
            {
               if ( ! (0==AV19ComboTipoPagamentoId) )
               {
                  A288TipoPagamentoId = AV19ComboTipoPagamentoId;
                  n288TipoPagamentoId = false;
               }
               else
               {
                  if ( (0==A288TipoPagamentoId) )
                  {
                     A288TipoPagamentoId = 0;
                     n288TipoPagamentoId = false;
                     n288TipoPagamentoId = true;
                     n288TipoPagamentoId = true;
                  }
               }
            }
         }
         /* Using cursor T001618 */
         pr_default.execute(16, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A288TipoPagamentoId) ) )
            {
               GX_msglist.addItem("Não existe 'TipoPagamento'.", "ForeignKeyNotFound", 1, "TIPOPAGAMENTOID");
               AnyError = 1;
               GX_FocusControl = edtTipoPagamentoId_Internalname;
            }
         }
         A289TipoPagamentoNome = T001618_A289TipoPagamentoNome[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A288TipoPagamentoId", ((0==A288TipoPagamentoId)&&IsIns( )||n288TipoPagamentoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TipoPagamentoId), 9, 0, ".", ""))));
         AssignAttri("", false, "A289TipoPagamentoNome", A289TipoPagamentoNome);
      }

      public void Valid_Tituloid( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TituloId) )
         {
            A261TituloId = AV12Insert_TituloId;
            n261TituloId = false;
         }
         else
         {
            if ( (0==AV21ComboTituloId) )
            {
               A261TituloId = 0;
               n261TituloId = false;
               n261TituloId = true;
               n261TituloId = true;
            }
            else
            {
               if ( ! (0==AV21ComboTituloId) )
               {
                  A261TituloId = AV21ComboTituloId;
                  n261TituloId = false;
               }
               else
               {
                  if ( (0==A261TituloId) )
                  {
                     A261TituloId = 0;
                     n261TituloId = false;
                     n261TituloId = true;
                     n261TituloId = true;
                  }
               }
            }
         }
         /* Using cursor T001620 */
         pr_default.execute(18, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A261TituloId) ) )
            {
               GX_msglist.addItem("Não existe 'Titulo'.", "ForeignKeyNotFound", 1, "TITULOID");
               AnyError = 1;
               GX_FocusControl = edtTituloId_Internalname;
            }
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A261TituloId", ((0==A261TituloId)&&IsIns( )||n261TituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7TituloMovimentoId","fld":"vTITULOMOVIMENTOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7TituloMovimentoId","fld":"vTITULOMOVIMENTOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A270TituloMovimentoId","fld":"TITULOMOVIMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_TipoPagamentoId","fld":"vINSERT_TIPOPAGAMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_TituloId","fld":"vINSERT_TITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV22Insert_TituloMovimentoConta","fld":"vINSERT_TITULOMOVIMENTOCONTA","pic":"ZZZZZZZZ9","type":"int"},{"av":"A432TituloMovimentoOpe","fld":"TITULOMOVIMENTOOPE","type":"svchar"},{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12162","iparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]}""");
         setEventMetadata("VALID_TITULOMOVIMENTOID","""{"handler":"Valid_Titulomovimentoid","iparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]""");
         setEventMetadata("VALID_TITULOMOVIMENTOID",""","oparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]}""");
         setEventMetadata("VALID_TIPOPAGAMENTOID","""{"handler":"Valid_Tipopagamentoid","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV11Insert_TipoPagamentoId","fld":"vINSERT_TIPOPAGAMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV19ComboTipoPagamentoId","fld":"vCOMBOTIPOPAGAMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A288TipoPagamentoId","fld":"TIPOPAGAMENTOID","pic":"ZZZZZZZZ9","nullAv":"n288TipoPagamentoId","type":"int"},{"av":"A289TipoPagamentoNome","fld":"TIPOPAGAMENTONOME","type":"svchar"},{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]""");
         setEventMetadata("VALID_TIPOPAGAMENTOID",""","oparms":[{"av":"A288TipoPagamentoId","fld":"TIPOPAGAMENTOID","pic":"ZZZZZZZZ9","nullAv":"n288TipoPagamentoId","type":"int"},{"av":"A289TipoPagamentoNome","fld":"TIPOPAGAMENTONOME","type":"svchar"},{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]}""");
         setEventMetadata("VALID_TITULOID","""{"handler":"Valid_Tituloid","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV12Insert_TituloId","fld":"vINSERT_TITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21ComboTituloId","fld":"vCOMBOTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","nullAv":"n261TituloId","type":"int"},{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]""");
         setEventMetadata("VALID_TITULOID",""","oparms":[{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","nullAv":"n261TituloId","type":"int"},{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]}""");
         setEventMetadata("VALID_TITULOMOVIMENTOVALOR","""{"handler":"Valid_Titulomovimentovalor","iparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]""");
         setEventMetadata("VALID_TITULOMOVIMENTOVALOR",""","oparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]}""");
         setEventMetadata("VALID_TITULOMOVIMENTOTIPO","""{"handler":"Valid_Titulomovimentotipo","iparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]""");
         setEventMetadata("VALID_TITULOMOVIMENTOTIPO",""","oparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]}""");
         setEventMetadata("VALIDV_COMBOTIPOPAGAMENTOID","""{"handler":"Validv_Combotipopagamentoid","iparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]""");
         setEventMetadata("VALIDV_COMBOTIPOPAGAMENTOID",""","oparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]}""");
         setEventMetadata("VALIDV_COMBOTITULOID","""{"handler":"Validv_Combotituloid","iparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]""");
         setEventMetadata("VALIDV_COMBOTITULOID",""","oparms":[{"av":"A274TituloMovimentoSoma","fld":"TITULOMOVIMENTOSOMA","type":"boolean"}]}""");
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
         pr_default.close(16);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z280TituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         Z281TituloMovimentoUpdatedAt = (DateTime)(DateTime.MinValue);
         Z272TituloMovimentoTipo = "";
         Z279TituloMovimentoDataCredito = DateTime.MinValue;
         Z432TituloMovimentoOpe = "";
         Combo_tituloid_Selectedvalue_get = "";
         Combo_tipopagamentoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A272TituloMovimentoTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblocktipopagamentoid_Jsonclick = "";
         ucCombo_tipopagamentoid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14TipoPagamentoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblocktituloid_Jsonclick = "";
         ucCombo_tituloid = new GXUserControl();
         AV20TituloId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A279TituloMovimentoDataCredito = DateTime.MinValue;
         A280TituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         A281TituloMovimentoUpdatedAt = (DateTime)(DateTime.MinValue);
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A432TituloMovimentoOpe = "";
         A289TipoPagamentoNome = "";
         AV24Pgmname = "";
         Combo_tipopagamentoid_Objectcall = "";
         Combo_tipopagamentoid_Class = "";
         Combo_tipopagamentoid_Icontype = "";
         Combo_tipopagamentoid_Icon = "";
         Combo_tipopagamentoid_Tooltip = "";
         Combo_tipopagamentoid_Selectedvalue_set = "";
         Combo_tipopagamentoid_Selectedtext_set = "";
         Combo_tipopagamentoid_Selectedtext_get = "";
         Combo_tipopagamentoid_Gamoauthtoken = "";
         Combo_tipopagamentoid_Ddointernalname = "";
         Combo_tipopagamentoid_Titlecontrolalign = "";
         Combo_tipopagamentoid_Dropdownoptionstype = "";
         Combo_tipopagamentoid_Titlecontrolidtoreplace = "";
         Combo_tipopagamentoid_Datalisttype = "";
         Combo_tipopagamentoid_Datalistfixedvalues = "";
         Combo_tipopagamentoid_Remoteservicesparameters = "";
         Combo_tipopagamentoid_Htmltemplate = "";
         Combo_tipopagamentoid_Multiplevaluestype = "";
         Combo_tipopagamentoid_Loadingdata = "";
         Combo_tipopagamentoid_Noresultsfound = "";
         Combo_tipopagamentoid_Emptyitemtext = "";
         Combo_tipopagamentoid_Onlyselectedvalues = "";
         Combo_tipopagamentoid_Selectalltext = "";
         Combo_tipopagamentoid_Multiplevaluesseparator = "";
         Combo_tipopagamentoid_Addnewoptiontext = "";
         Combo_tituloid_Objectcall = "";
         Combo_tituloid_Class = "";
         Combo_tituloid_Icontype = "";
         Combo_tituloid_Icon = "";
         Combo_tituloid_Tooltip = "";
         Combo_tituloid_Selectedvalue_set = "";
         Combo_tituloid_Selectedtext_set = "";
         Combo_tituloid_Selectedtext_get = "";
         Combo_tituloid_Gamoauthtoken = "";
         Combo_tituloid_Ddointernalname = "";
         Combo_tituloid_Titlecontrolalign = "";
         Combo_tituloid_Dropdownoptionstype = "";
         Combo_tituloid_Titlecontrolidtoreplace = "";
         Combo_tituloid_Datalisttype = "";
         Combo_tituloid_Datalistfixedvalues = "";
         Combo_tituloid_Remoteservicesparameters = "";
         Combo_tituloid_Htmltemplate = "";
         Combo_tituloid_Multiplevaluestype = "";
         Combo_tituloid_Loadingdata = "";
         Combo_tituloid_Noresultsfound = "";
         Combo_tituloid_Emptyitemtext = "";
         Combo_tituloid_Onlyselectedvalues = "";
         Combo_tituloid_Selectalltext = "";
         Combo_tituloid_Multiplevaluesseparator = "";
         Combo_tituloid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode45 = "";
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
         Z289TipoPagamentoNome = "";
         T00167_A270TituloMovimentoId = new int[1] ;
         T00167_A280TituloMovimentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00167_n280TituloMovimentoCreatedAt = new bool[] {false} ;
         T00167_A281TituloMovimentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00167_n281TituloMovimentoUpdatedAt = new bool[] {false} ;
         T00167_A271TituloMovimentoValor = new decimal[1] ;
         T00167_n271TituloMovimentoValor = new bool[] {false} ;
         T00167_A272TituloMovimentoTipo = new string[] {""} ;
         T00167_n272TituloMovimentoTipo = new bool[] {false} ;
         T00167_A274TituloMovimentoSoma = new bool[] {false} ;
         T00167_n274TituloMovimentoSoma = new bool[] {false} ;
         T00167_A279TituloMovimentoDataCredito = new DateTime[] {DateTime.MinValue} ;
         T00167_n279TituloMovimentoDataCredito = new bool[] {false} ;
         T00167_A289TipoPagamentoNome = new string[] {""} ;
         T00167_A432TituloMovimentoOpe = new string[] {""} ;
         T00167_n432TituloMovimentoOpe = new bool[] {false} ;
         T00167_A288TipoPagamentoId = new int[1] ;
         T00167_n288TipoPagamentoId = new bool[] {false} ;
         T00167_A261TituloId = new int[1] ;
         T00167_n261TituloId = new bool[] {false} ;
         T00167_A433TituloMovimentoConta = new int[1] ;
         T00167_n433TituloMovimentoConta = new bool[] {false} ;
         T00164_A289TipoPagamentoNome = new string[] {""} ;
         T00165_A261TituloId = new int[1] ;
         T00165_n261TituloId = new bool[] {false} ;
         T00166_A433TituloMovimentoConta = new int[1] ;
         T00166_n433TituloMovimentoConta = new bool[] {false} ;
         T00168_A289TipoPagamentoNome = new string[] {""} ;
         T00169_A261TituloId = new int[1] ;
         T00169_n261TituloId = new bool[] {false} ;
         T001610_A433TituloMovimentoConta = new int[1] ;
         T001610_n433TituloMovimentoConta = new bool[] {false} ;
         T001611_A270TituloMovimentoId = new int[1] ;
         T00163_A270TituloMovimentoId = new int[1] ;
         T00163_A280TituloMovimentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00163_n280TituloMovimentoCreatedAt = new bool[] {false} ;
         T00163_A281TituloMovimentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00163_n281TituloMovimentoUpdatedAt = new bool[] {false} ;
         T00163_A271TituloMovimentoValor = new decimal[1] ;
         T00163_n271TituloMovimentoValor = new bool[] {false} ;
         T00163_A272TituloMovimentoTipo = new string[] {""} ;
         T00163_n272TituloMovimentoTipo = new bool[] {false} ;
         T00163_A274TituloMovimentoSoma = new bool[] {false} ;
         T00163_n274TituloMovimentoSoma = new bool[] {false} ;
         T00163_A279TituloMovimentoDataCredito = new DateTime[] {DateTime.MinValue} ;
         T00163_n279TituloMovimentoDataCredito = new bool[] {false} ;
         T00163_A432TituloMovimentoOpe = new string[] {""} ;
         T00163_n432TituloMovimentoOpe = new bool[] {false} ;
         T00163_A288TipoPagamentoId = new int[1] ;
         T00163_n288TipoPagamentoId = new bool[] {false} ;
         T00163_A261TituloId = new int[1] ;
         T00163_n261TituloId = new bool[] {false} ;
         T00163_A433TituloMovimentoConta = new int[1] ;
         T00163_n433TituloMovimentoConta = new bool[] {false} ;
         T001612_A270TituloMovimentoId = new int[1] ;
         T001613_A270TituloMovimentoId = new int[1] ;
         T00162_A270TituloMovimentoId = new int[1] ;
         T00162_A280TituloMovimentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00162_n280TituloMovimentoCreatedAt = new bool[] {false} ;
         T00162_A281TituloMovimentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T00162_n281TituloMovimentoUpdatedAt = new bool[] {false} ;
         T00162_A271TituloMovimentoValor = new decimal[1] ;
         T00162_n271TituloMovimentoValor = new bool[] {false} ;
         T00162_A272TituloMovimentoTipo = new string[] {""} ;
         T00162_n272TituloMovimentoTipo = new bool[] {false} ;
         T00162_A274TituloMovimentoSoma = new bool[] {false} ;
         T00162_n274TituloMovimentoSoma = new bool[] {false} ;
         T00162_A279TituloMovimentoDataCredito = new DateTime[] {DateTime.MinValue} ;
         T00162_n279TituloMovimentoDataCredito = new bool[] {false} ;
         T00162_A432TituloMovimentoOpe = new string[] {""} ;
         T00162_n432TituloMovimentoOpe = new bool[] {false} ;
         T00162_A288TipoPagamentoId = new int[1] ;
         T00162_n288TipoPagamentoId = new bool[] {false} ;
         T00162_A261TituloId = new int[1] ;
         T00162_n261TituloId = new bool[] {false} ;
         T00162_A433TituloMovimentoConta = new int[1] ;
         T00162_n433TituloMovimentoConta = new bool[] {false} ;
         T001615_A270TituloMovimentoId = new int[1] ;
         T001618_A289TipoPagamentoNome = new string[] {""} ;
         T001619_A270TituloMovimentoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i280TituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         T001620_A261TituloId = new int[1] ;
         T001620_n261TituloId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.titulomovimento__default(),
            new Object[][] {
                new Object[] {
               T00162_A270TituloMovimentoId, T00162_A280TituloMovimentoCreatedAt, T00162_n280TituloMovimentoCreatedAt, T00162_A281TituloMovimentoUpdatedAt, T00162_n281TituloMovimentoUpdatedAt, T00162_A271TituloMovimentoValor, T00162_n271TituloMovimentoValor, T00162_A272TituloMovimentoTipo, T00162_n272TituloMovimentoTipo, T00162_A274TituloMovimentoSoma,
               T00162_n274TituloMovimentoSoma, T00162_A279TituloMovimentoDataCredito, T00162_n279TituloMovimentoDataCredito, T00162_A432TituloMovimentoOpe, T00162_n432TituloMovimentoOpe, T00162_A288TipoPagamentoId, T00162_n288TipoPagamentoId, T00162_A261TituloId, T00162_n261TituloId, T00162_A433TituloMovimentoConta,
               T00162_n433TituloMovimentoConta
               }
               , new Object[] {
               T00163_A270TituloMovimentoId, T00163_A280TituloMovimentoCreatedAt, T00163_n280TituloMovimentoCreatedAt, T00163_A281TituloMovimentoUpdatedAt, T00163_n281TituloMovimentoUpdatedAt, T00163_A271TituloMovimentoValor, T00163_n271TituloMovimentoValor, T00163_A272TituloMovimentoTipo, T00163_n272TituloMovimentoTipo, T00163_A274TituloMovimentoSoma,
               T00163_n274TituloMovimentoSoma, T00163_A279TituloMovimentoDataCredito, T00163_n279TituloMovimentoDataCredito, T00163_A432TituloMovimentoOpe, T00163_n432TituloMovimentoOpe, T00163_A288TipoPagamentoId, T00163_n288TipoPagamentoId, T00163_A261TituloId, T00163_n261TituloId, T00163_A433TituloMovimentoConta,
               T00163_n433TituloMovimentoConta
               }
               , new Object[] {
               T00164_A289TipoPagamentoNome
               }
               , new Object[] {
               T00165_A261TituloId
               }
               , new Object[] {
               T00166_A433TituloMovimentoConta
               }
               , new Object[] {
               T00167_A270TituloMovimentoId, T00167_A280TituloMovimentoCreatedAt, T00167_n280TituloMovimentoCreatedAt, T00167_A281TituloMovimentoUpdatedAt, T00167_n281TituloMovimentoUpdatedAt, T00167_A271TituloMovimentoValor, T00167_n271TituloMovimentoValor, T00167_A272TituloMovimentoTipo, T00167_n272TituloMovimentoTipo, T00167_A274TituloMovimentoSoma,
               T00167_n274TituloMovimentoSoma, T00167_A279TituloMovimentoDataCredito, T00167_n279TituloMovimentoDataCredito, T00167_A289TipoPagamentoNome, T00167_A432TituloMovimentoOpe, T00167_n432TituloMovimentoOpe, T00167_A288TipoPagamentoId, T00167_n288TipoPagamentoId, T00167_A261TituloId, T00167_n261TituloId,
               T00167_A433TituloMovimentoConta, T00167_n433TituloMovimentoConta
               }
               , new Object[] {
               T00168_A289TipoPagamentoNome
               }
               , new Object[] {
               T00169_A261TituloId
               }
               , new Object[] {
               T001610_A433TituloMovimentoConta
               }
               , new Object[] {
               T001611_A270TituloMovimentoId
               }
               , new Object[] {
               T001612_A270TituloMovimentoId
               }
               , new Object[] {
               T001613_A270TituloMovimentoId
               }
               , new Object[] {
               }
               , new Object[] {
               T001615_A270TituloMovimentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001618_A289TipoPagamentoNome
               }
               , new Object[] {
               T001619_A270TituloMovimentoId
               }
               , new Object[] {
               T001620_A261TituloId
               }
            }
         );
         AV24Pgmname = "TituloMovimento";
         Z280TituloMovimentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n280TituloMovimentoCreatedAt = false;
         A280TituloMovimentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n280TituloMovimentoCreatedAt = false;
         i280TituloMovimentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n280TituloMovimentoCreatedAt = false;
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound45 ;
      private short gxajaxcallmode ;
      private int wcpOAV7TituloMovimentoId ;
      private int Z270TituloMovimentoId ;
      private int Z288TipoPagamentoId ;
      private int Z261TituloId ;
      private int Z433TituloMovimentoConta ;
      private int N288TipoPagamentoId ;
      private int N261TituloId ;
      private int N433TituloMovimentoConta ;
      private int A288TipoPagamentoId ;
      private int A261TituloId ;
      private int A433TituloMovimentoConta ;
      private int AV7TituloMovimentoId ;
      private int trnEnded ;
      private int A270TituloMovimentoId ;
      private int edtTituloMovimentoId_Enabled ;
      private int edtTipoPagamentoId_Visible ;
      private int edtTipoPagamentoId_Enabled ;
      private int edtTituloId_Visible ;
      private int edtTituloId_Enabled ;
      private int edtTituloMovimentoValor_Enabled ;
      private int edtTituloMovimentoDataCredito_Enabled ;
      private int edtTituloMovimentoCreatedAt_Enabled ;
      private int edtTituloMovimentoUpdatedAt_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboTipoPagamentoId ;
      private int edtavCombotipopagamentoid_Enabled ;
      private int edtavCombotipopagamentoid_Visible ;
      private int AV21ComboTituloId ;
      private int edtavCombotituloid_Enabled ;
      private int edtavCombotituloid_Visible ;
      private int AV11Insert_TipoPagamentoId ;
      private int AV12Insert_TituloId ;
      private int AV22Insert_TituloMovimentoConta ;
      private int Combo_tipopagamentoid_Datalistupdateminimumcharacters ;
      private int Combo_tipopagamentoid_Gxcontroltype ;
      private int Combo_tituloid_Datalistupdateminimumcharacters ;
      private int Combo_tituloid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV25GXV1 ;
      private int idxLst ;
      private decimal Z271TituloMovimentoValor ;
      private decimal A271TituloMovimentoValor ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_tituloid_Selectedvalue_get ;
      private string Combo_tipopagamentoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipoPagamentoId_Internalname ;
      private string cmbTituloMovimentoTipo_Internalname ;
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
      private string edtTituloMovimentoId_Internalname ;
      private string TempTags ;
      private string edtTituloMovimentoId_Jsonclick ;
      private string divTablesplittedtipopagamentoid_Internalname ;
      private string lblTextblocktipopagamentoid_Internalname ;
      private string lblTextblocktipopagamentoid_Jsonclick ;
      private string Combo_tipopagamentoid_Caption ;
      private string Combo_tipopagamentoid_Cls ;
      private string Combo_tipopagamentoid_Datalistproc ;
      private string Combo_tipopagamentoid_Datalistprocparametersprefix ;
      private string Combo_tipopagamentoid_Internalname ;
      private string edtTipoPagamentoId_Jsonclick ;
      private string divTablesplittedtituloid_Internalname ;
      private string lblTextblocktituloid_Internalname ;
      private string lblTextblocktituloid_Jsonclick ;
      private string Combo_tituloid_Caption ;
      private string Combo_tituloid_Cls ;
      private string Combo_tituloid_Datalistproc ;
      private string Combo_tituloid_Datalistprocparametersprefix ;
      private string Combo_tituloid_Internalname ;
      private string edtTituloId_Internalname ;
      private string edtTituloId_Jsonclick ;
      private string edtTituloMovimentoValor_Internalname ;
      private string edtTituloMovimentoValor_Jsonclick ;
      private string cmbTituloMovimentoTipo_Jsonclick ;
      private string chkTituloMovimentoSoma_Internalname ;
      private string edtTituloMovimentoDataCredito_Internalname ;
      private string edtTituloMovimentoDataCredito_Jsonclick ;
      private string edtTituloMovimentoCreatedAt_Internalname ;
      private string edtTituloMovimentoCreatedAt_Jsonclick ;
      private string edtTituloMovimentoUpdatedAt_Internalname ;
      private string edtTituloMovimentoUpdatedAt_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_tipopagamentoid_Internalname ;
      private string edtavCombotipopagamentoid_Internalname ;
      private string edtavCombotipopagamentoid_Jsonclick ;
      private string divSectionattribute_tituloid_Internalname ;
      private string edtavCombotituloid_Internalname ;
      private string edtavCombotituloid_Jsonclick ;
      private string AV24Pgmname ;
      private string Combo_tipopagamentoid_Objectcall ;
      private string Combo_tipopagamentoid_Class ;
      private string Combo_tipopagamentoid_Icontype ;
      private string Combo_tipopagamentoid_Icon ;
      private string Combo_tipopagamentoid_Tooltip ;
      private string Combo_tipopagamentoid_Selectedvalue_set ;
      private string Combo_tipopagamentoid_Selectedtext_set ;
      private string Combo_tipopagamentoid_Selectedtext_get ;
      private string Combo_tipopagamentoid_Gamoauthtoken ;
      private string Combo_tipopagamentoid_Ddointernalname ;
      private string Combo_tipopagamentoid_Titlecontrolalign ;
      private string Combo_tipopagamentoid_Dropdownoptionstype ;
      private string Combo_tipopagamentoid_Titlecontrolidtoreplace ;
      private string Combo_tipopagamentoid_Datalisttype ;
      private string Combo_tipopagamentoid_Datalistfixedvalues ;
      private string Combo_tipopagamentoid_Remoteservicesparameters ;
      private string Combo_tipopagamentoid_Htmltemplate ;
      private string Combo_tipopagamentoid_Multiplevaluestype ;
      private string Combo_tipopagamentoid_Loadingdata ;
      private string Combo_tipopagamentoid_Noresultsfound ;
      private string Combo_tipopagamentoid_Emptyitemtext ;
      private string Combo_tipopagamentoid_Onlyselectedvalues ;
      private string Combo_tipopagamentoid_Selectalltext ;
      private string Combo_tipopagamentoid_Multiplevaluesseparator ;
      private string Combo_tipopagamentoid_Addnewoptiontext ;
      private string Combo_tituloid_Objectcall ;
      private string Combo_tituloid_Class ;
      private string Combo_tituloid_Icontype ;
      private string Combo_tituloid_Icon ;
      private string Combo_tituloid_Tooltip ;
      private string Combo_tituloid_Selectedvalue_set ;
      private string Combo_tituloid_Selectedtext_set ;
      private string Combo_tituloid_Selectedtext_get ;
      private string Combo_tituloid_Gamoauthtoken ;
      private string Combo_tituloid_Ddointernalname ;
      private string Combo_tituloid_Titlecontrolalign ;
      private string Combo_tituloid_Dropdownoptionstype ;
      private string Combo_tituloid_Titlecontrolidtoreplace ;
      private string Combo_tituloid_Datalisttype ;
      private string Combo_tituloid_Datalistfixedvalues ;
      private string Combo_tituloid_Remoteservicesparameters ;
      private string Combo_tituloid_Htmltemplate ;
      private string Combo_tituloid_Multiplevaluestype ;
      private string Combo_tituloid_Loadingdata ;
      private string Combo_tituloid_Noresultsfound ;
      private string Combo_tituloid_Emptyitemtext ;
      private string Combo_tituloid_Onlyselectedvalues ;
      private string Combo_tituloid_Selectalltext ;
      private string Combo_tituloid_Multiplevaluesseparator ;
      private string Combo_tituloid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode45 ;
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
      private DateTime Z280TituloMovimentoCreatedAt ;
      private DateTime Z281TituloMovimentoUpdatedAt ;
      private DateTime A280TituloMovimentoCreatedAt ;
      private DateTime A281TituloMovimentoUpdatedAt ;
      private DateTime i280TituloMovimentoCreatedAt ;
      private DateTime Z279TituloMovimentoDataCredito ;
      private DateTime A279TituloMovimentoDataCredito ;
      private bool Z274TituloMovimentoSoma ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n288TipoPagamentoId ;
      private bool n261TituloId ;
      private bool n433TituloMovimentoConta ;
      private bool wbErr ;
      private bool n272TituloMovimentoTipo ;
      private bool A274TituloMovimentoSoma ;
      private bool n274TituloMovimentoSoma ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n271TituloMovimentoValor ;
      private bool n280TituloMovimentoCreatedAt ;
      private bool n281TituloMovimentoUpdatedAt ;
      private bool n279TituloMovimentoDataCredito ;
      private bool n432TituloMovimentoOpe ;
      private bool Combo_tipopagamentoid_Enabled ;
      private bool Combo_tipopagamentoid_Visible ;
      private bool Combo_tipopagamentoid_Allowmultipleselection ;
      private bool Combo_tipopagamentoid_Isgriditem ;
      private bool Combo_tipopagamentoid_Hasdescription ;
      private bool Combo_tipopagamentoid_Includeonlyselectedoption ;
      private bool Combo_tipopagamentoid_Includeselectalloption ;
      private bool Combo_tipopagamentoid_Emptyitem ;
      private bool Combo_tipopagamentoid_Includeaddnewoption ;
      private bool Combo_tituloid_Enabled ;
      private bool Combo_tituloid_Visible ;
      private bool Combo_tituloid_Allowmultipleselection ;
      private bool Combo_tituloid_Isgriditem ;
      private bool Combo_tituloid_Hasdescription ;
      private bool Combo_tituloid_Includeonlyselectedoption ;
      private bool Combo_tituloid_Includeselectalloption ;
      private bool Combo_tituloid_Emptyitem ;
      private bool Combo_tituloid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV18Combo_DataJson ;
      private string Z272TituloMovimentoTipo ;
      private string Z432TituloMovimentoOpe ;
      private string A272TituloMovimentoTipo ;
      private string A432TituloMovimentoOpe ;
      private string A289TipoPagamentoNome ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private string Z289TipoPagamentoNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_tipopagamentoid ;
      private GXUserControl ucCombo_tituloid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTituloMovimentoTipo ;
      private GXCheckbox chkTituloMovimentoSoma ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14TipoPagamentoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV20TituloId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] T00167_A270TituloMovimentoId ;
      private DateTime[] T00167_A280TituloMovimentoCreatedAt ;
      private bool[] T00167_n280TituloMovimentoCreatedAt ;
      private DateTime[] T00167_A281TituloMovimentoUpdatedAt ;
      private bool[] T00167_n281TituloMovimentoUpdatedAt ;
      private decimal[] T00167_A271TituloMovimentoValor ;
      private bool[] T00167_n271TituloMovimentoValor ;
      private string[] T00167_A272TituloMovimentoTipo ;
      private bool[] T00167_n272TituloMovimentoTipo ;
      private bool[] T00167_A274TituloMovimentoSoma ;
      private bool[] T00167_n274TituloMovimentoSoma ;
      private DateTime[] T00167_A279TituloMovimentoDataCredito ;
      private bool[] T00167_n279TituloMovimentoDataCredito ;
      private string[] T00167_A289TipoPagamentoNome ;
      private string[] T00167_A432TituloMovimentoOpe ;
      private bool[] T00167_n432TituloMovimentoOpe ;
      private int[] T00167_A288TipoPagamentoId ;
      private bool[] T00167_n288TipoPagamentoId ;
      private int[] T00167_A261TituloId ;
      private bool[] T00167_n261TituloId ;
      private int[] T00167_A433TituloMovimentoConta ;
      private bool[] T00167_n433TituloMovimentoConta ;
      private string[] T00164_A289TipoPagamentoNome ;
      private int[] T00165_A261TituloId ;
      private bool[] T00165_n261TituloId ;
      private int[] T00166_A433TituloMovimentoConta ;
      private bool[] T00166_n433TituloMovimentoConta ;
      private string[] T00168_A289TipoPagamentoNome ;
      private int[] T00169_A261TituloId ;
      private bool[] T00169_n261TituloId ;
      private int[] T001610_A433TituloMovimentoConta ;
      private bool[] T001610_n433TituloMovimentoConta ;
      private int[] T001611_A270TituloMovimentoId ;
      private int[] T00163_A270TituloMovimentoId ;
      private DateTime[] T00163_A280TituloMovimentoCreatedAt ;
      private bool[] T00163_n280TituloMovimentoCreatedAt ;
      private DateTime[] T00163_A281TituloMovimentoUpdatedAt ;
      private bool[] T00163_n281TituloMovimentoUpdatedAt ;
      private decimal[] T00163_A271TituloMovimentoValor ;
      private bool[] T00163_n271TituloMovimentoValor ;
      private string[] T00163_A272TituloMovimentoTipo ;
      private bool[] T00163_n272TituloMovimentoTipo ;
      private bool[] T00163_A274TituloMovimentoSoma ;
      private bool[] T00163_n274TituloMovimentoSoma ;
      private DateTime[] T00163_A279TituloMovimentoDataCredito ;
      private bool[] T00163_n279TituloMovimentoDataCredito ;
      private string[] T00163_A432TituloMovimentoOpe ;
      private bool[] T00163_n432TituloMovimentoOpe ;
      private int[] T00163_A288TipoPagamentoId ;
      private bool[] T00163_n288TipoPagamentoId ;
      private int[] T00163_A261TituloId ;
      private bool[] T00163_n261TituloId ;
      private int[] T00163_A433TituloMovimentoConta ;
      private bool[] T00163_n433TituloMovimentoConta ;
      private int[] T001612_A270TituloMovimentoId ;
      private int[] T001613_A270TituloMovimentoId ;
      private int[] T00162_A270TituloMovimentoId ;
      private DateTime[] T00162_A280TituloMovimentoCreatedAt ;
      private bool[] T00162_n280TituloMovimentoCreatedAt ;
      private DateTime[] T00162_A281TituloMovimentoUpdatedAt ;
      private bool[] T00162_n281TituloMovimentoUpdatedAt ;
      private decimal[] T00162_A271TituloMovimentoValor ;
      private bool[] T00162_n271TituloMovimentoValor ;
      private string[] T00162_A272TituloMovimentoTipo ;
      private bool[] T00162_n272TituloMovimentoTipo ;
      private bool[] T00162_A274TituloMovimentoSoma ;
      private bool[] T00162_n274TituloMovimentoSoma ;
      private DateTime[] T00162_A279TituloMovimentoDataCredito ;
      private bool[] T00162_n279TituloMovimentoDataCredito ;
      private string[] T00162_A432TituloMovimentoOpe ;
      private bool[] T00162_n432TituloMovimentoOpe ;
      private int[] T00162_A288TipoPagamentoId ;
      private bool[] T00162_n288TipoPagamentoId ;
      private int[] T00162_A261TituloId ;
      private bool[] T00162_n261TituloId ;
      private int[] T00162_A433TituloMovimentoConta ;
      private bool[] T00162_n433TituloMovimentoConta ;
      private int[] T001615_A270TituloMovimentoId ;
      private string[] T001618_A289TipoPagamentoNome ;
      private int[] T001619_A270TituloMovimentoId ;
      private int[] T001620_A261TituloId ;
      private bool[] T001620_n261TituloId ;
   }

   public class titulomovimento__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00162;
          prmT00162 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmT00163;
          prmT00163 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmT00164;
          prmT00164 = new Object[] {
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00165;
          prmT00165 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00166;
          prmT00166 = new Object[] {
          new ParDef("TituloMovimentoConta",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00167;
          prmT00167 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmT00168;
          prmT00168 = new Object[] {
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00169;
          prmT00169 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001610;
          prmT001610 = new Object[] {
          new ParDef("TituloMovimentoConta",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001611;
          prmT001611 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmT001612;
          prmT001612 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmT001613;
          prmT001613 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmT001614;
          prmT001614 = new Object[] {
          new ParDef("TituloMovimentoCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TituloMovimentoUpdatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TituloMovimentoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloMovimentoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TituloMovimentoSoma",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloMovimentoDataCredito",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloMovimentoOpe",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloMovimentoConta",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001615;
          prmT001615 = new Object[] {
          };
          Object[] prmT001616;
          prmT001616 = new Object[] {
          new ParDef("TituloMovimentoCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TituloMovimentoUpdatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TituloMovimentoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloMovimentoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TituloMovimentoSoma",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloMovimentoDataCredito",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloMovimentoOpe",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloMovimentoConta",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmT001617;
          prmT001617 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmT001618;
          prmT001618 = new Object[] {
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001619;
          prmT001619 = new Object[] {
          };
          Object[] prmT001620;
          prmT001620 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00162", "SELECT TituloMovimentoId, TituloMovimentoCreatedAt, TituloMovimentoUpdatedAt, TituloMovimentoValor, TituloMovimentoTipo, TituloMovimentoSoma, TituloMovimentoDataCredito, TituloMovimentoOpe, TipoPagamentoId, TituloId, TituloMovimentoConta FROM TituloMovimento WHERE TituloMovimentoId = :TituloMovimentoId  FOR UPDATE OF TituloMovimento NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00162,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00163", "SELECT TituloMovimentoId, TituloMovimentoCreatedAt, TituloMovimentoUpdatedAt, TituloMovimentoValor, TituloMovimentoTipo, TituloMovimentoSoma, TituloMovimentoDataCredito, TituloMovimentoOpe, TipoPagamentoId, TituloId, TituloMovimentoConta FROM TituloMovimento WHERE TituloMovimentoId = :TituloMovimentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00163,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00164", "SELECT TipoPagamentoNome FROM TipoPagamento WHERE TipoPagamentoId = :TipoPagamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00164,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00165", "SELECT TituloId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00165,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00166", "SELECT ContaId AS TituloMovimentoConta FROM Conta WHERE ContaId = :TituloMovimentoConta ",true, GxErrorMask.GX_NOMASK, false, this,prmT00166,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00167", "SELECT TM1.TituloMovimentoId, TM1.TituloMovimentoCreatedAt, TM1.TituloMovimentoUpdatedAt, TM1.TituloMovimentoValor, TM1.TituloMovimentoTipo, TM1.TituloMovimentoSoma, TM1.TituloMovimentoDataCredito, T2.TipoPagamentoNome, TM1.TituloMovimentoOpe, TM1.TipoPagamentoId, TM1.TituloId, TM1.TituloMovimentoConta AS TituloMovimentoConta FROM (TituloMovimento TM1 LEFT JOIN TipoPagamento T2 ON T2.TipoPagamentoId = TM1.TipoPagamentoId) WHERE TM1.TituloMovimentoId = :TituloMovimentoId ORDER BY TM1.TituloMovimentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00167,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00168", "SELECT TipoPagamentoNome FROM TipoPagamento WHERE TipoPagamentoId = :TipoPagamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00168,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00169", "SELECT TituloId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00169,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001610", "SELECT ContaId AS TituloMovimentoConta FROM Conta WHERE ContaId = :TituloMovimentoConta ",true, GxErrorMask.GX_NOMASK, false, this,prmT001610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001611", "SELECT TituloMovimentoId FROM TituloMovimento WHERE TituloMovimentoId = :TituloMovimentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001612", "SELECT TituloMovimentoId FROM TituloMovimento WHERE ( TituloMovimentoId > :TituloMovimentoId) ORDER BY TituloMovimentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001612,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001613", "SELECT TituloMovimentoId FROM TituloMovimento WHERE ( TituloMovimentoId < :TituloMovimentoId) ORDER BY TituloMovimentoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001613,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001614", "SAVEPOINT gxupdate;INSERT INTO TituloMovimento(TituloMovimentoCreatedAt, TituloMovimentoUpdatedAt, TituloMovimentoValor, TituloMovimentoTipo, TituloMovimentoSoma, TituloMovimentoDataCredito, TituloMovimentoOpe, TipoPagamentoId, TituloId, TituloMovimentoConta) VALUES(:TituloMovimentoCreatedAt, :TituloMovimentoUpdatedAt, :TituloMovimentoValor, :TituloMovimentoTipo, :TituloMovimentoSoma, :TituloMovimentoDataCredito, :TituloMovimentoOpe, :TipoPagamentoId, :TituloId, :TituloMovimentoConta);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001614)
             ,new CursorDef("T001615", "SELECT currval('TituloMovimentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001615,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001616", "SAVEPOINT gxupdate;UPDATE TituloMovimento SET TituloMovimentoCreatedAt=:TituloMovimentoCreatedAt, TituloMovimentoUpdatedAt=:TituloMovimentoUpdatedAt, TituloMovimentoValor=:TituloMovimentoValor, TituloMovimentoTipo=:TituloMovimentoTipo, TituloMovimentoSoma=:TituloMovimentoSoma, TituloMovimentoDataCredito=:TituloMovimentoDataCredito, TituloMovimentoOpe=:TituloMovimentoOpe, TipoPagamentoId=:TipoPagamentoId, TituloId=:TituloId, TituloMovimentoConta=:TituloMovimentoConta  WHERE TituloMovimentoId = :TituloMovimentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001616)
             ,new CursorDef("T001617", "SAVEPOINT gxupdate;DELETE FROM TituloMovimento  WHERE TituloMovimentoId = :TituloMovimentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001617)
             ,new CursorDef("T001618", "SELECT TipoPagamentoNome FROM TipoPagamento WHERE TipoPagamentoId = :TipoPagamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001618,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001619", "SELECT TituloMovimentoId FROM TituloMovimento ORDER BY TituloMovimentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001619,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001620", "SELECT TituloId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001620,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((string[]) buf[14])[0] = rslt.getVarchar(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((int[]) buf[16])[0] = rslt.getInt(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((int[]) buf[18])[0] = rslt.getInt(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((int[]) buf[20])[0] = rslt.getInt(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
