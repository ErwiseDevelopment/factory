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
   public class assinatura : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A238AssinaturaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaId"), "."), 18, MidpointRounding.ToEven));
            n238AssinaturaId = false;
            AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A238AssinaturaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A227ContratoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoId"), "."), 18, MidpointRounding.ToEven));
            n227ContratoId = false;
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A227ContratoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A231ArquivoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ArquivoId"), "."), 18, MidpointRounding.ToEven));
            n231ArquivoId = false;
            AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A231ArquivoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A578ArquivoAssinadoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ArquivoAssinadoId"), "."), 18, MidpointRounding.ToEven));
            n578ArquivoAssinadoId = false;
            AssignAttri("", false, "A578ArquivoAssinadoId", ((0==A578ArquivoAssinadoId)&&IsIns( )||n578ArquivoAssinadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A578ArquivoAssinadoId), 8, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A578ArquivoAssinadoId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "assinatura")), "assinatura") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "assinatura")))) ;
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
                  AV7AssinaturaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7AssinaturaId", StringUtil.LTrimStr( (decimal)(AV7AssinaturaId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AssinaturaId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Assinatura", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbAssinaturaStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public assinatura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinatura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_AssinaturaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AssinaturaId = aP1_AssinaturaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbAssinaturaStatus = new GXCombobox();
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
         if ( cmbAssinaturaStatus.ItemCount > 0 )
         {
            A239AssinaturaStatus = cmbAssinaturaStatus.getValidValue(A239AssinaturaStatus);
            n239AssinaturaStatus = false;
            AssignAttri("", false, "A239AssinaturaStatus", A239AssinaturaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAssinaturaStatus.CurrentValue = StringUtil.RTrim( A239AssinaturaStatus);
            AssignProp("", false, cmbAssinaturaStatus_Internalname, "Values", cmbAssinaturaStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaId_Internalname, "Assinatura Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A238AssinaturaId), 10, 0, ",", "")), StringUtil.LTrim( ((edtAssinaturaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A238AssinaturaId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A238AssinaturaId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAssinaturaId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Assinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbAssinaturaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbAssinaturaStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbAssinaturaStatus, cmbAssinaturaStatus_Internalname, StringUtil.RTrim( A239AssinaturaStatus), 1, cmbAssinaturaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbAssinaturaStatus.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_Assinatura.htm");
         cmbAssinaturaStatus.CurrentValue = StringUtil.RTrim( A239AssinaturaStatus);
         AssignProp("", false, cmbAssinaturaStatus_Internalname, "Values", (string)(cmbAssinaturaStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcontratoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcontratoid_Internalname, "Contrato", "", "", lblTextblockcontratoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Assinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_contratoid.SetProperty("Caption", Combo_contratoid_Caption);
         ucCombo_contratoid.SetProperty("Cls", Combo_contratoid_Cls);
         ucCombo_contratoid.SetProperty("DataListProc", Combo_contratoid_Datalistproc);
         ucCombo_contratoid.SetProperty("DataListProcParametersPrefix", Combo_contratoid_Datalistprocparametersprefix);
         ucCombo_contratoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_contratoid.SetProperty("DropDownOptionsData", AV14ContratoId_Data);
         ucCombo_contratoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_contratoid_Internalname, "COMBO_CONTRATOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContratoId_Internalname, "Contrato Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContratoId_Internalname, ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", ""))), ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContratoId_Jsonclick, 0, "Attribute", "", "", "", "", edtContratoId_Visible, edtContratoId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Assinatura.htm");
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
         GxWebStd.gx_div_start( context, divTablesplittedarquivoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockarquivoid_Internalname, "Arquivo Id", "", "", lblTextblockarquivoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Assinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_arquivoid.SetProperty("Caption", Combo_arquivoid_Caption);
         ucCombo_arquivoid.SetProperty("Cls", Combo_arquivoid_Cls);
         ucCombo_arquivoid.SetProperty("DataListProc", Combo_arquivoid_Datalistproc);
         ucCombo_arquivoid.SetProperty("DataListProcParametersPrefix", Combo_arquivoid_Datalistprocparametersprefix);
         ucCombo_arquivoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_arquivoid.SetProperty("DropDownOptionsData", AV20ArquivoId_Data);
         ucCombo_arquivoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_arquivoid_Internalname, "COMBO_ARQUIVOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtArquivoId_Internalname, "Arquivo Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtArquivoId_Internalname, ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ",", ""))), ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A231ArquivoId), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtArquivoId_Jsonclick, 0, "Attribute", "", "", "", "", edtArquivoId_Visible, edtArquivoId_Enabled, 1, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Assinatura.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaArquivoAssinado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaArquivoAssinado_Internalname, "Arquivo Assinado", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         ClassString = "AttributeFL";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         edtAssinaturaArquivoAssinado_Filename = A257AssinaturaArquivoAssinadoNome;
         edtAssinaturaArquivoAssinado_Filetype = "";
         AssignProp("", false, edtAssinaturaArquivoAssinado_Internalname, "Filetype", edtAssinaturaArquivoAssinado_Filetype, true);
         edtAssinaturaArquivoAssinado_Filetype = A256AssinaturaArquivoAssinadoExtensao;
         AssignProp("", false, edtAssinaturaArquivoAssinado_Internalname, "Filetype", edtAssinaturaArquivoAssinado_Filetype, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A240AssinaturaArquivoAssinado)) )
         {
            gxblobfileaux.Source = A240AssinaturaArquivoAssinado;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtAssinaturaArquivoAssinado_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtAssinaturaArquivoAssinado_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A240AssinaturaArquivoAssinado = gxblobfileaux.GetURI();
               n240AssinaturaArquivoAssinado = false;
               AssignAttri("", false, "A240AssinaturaArquivoAssinado", A240AssinaturaArquivoAssinado);
               AssignProp("", false, edtAssinaturaArquivoAssinado_Internalname, "URL", context.PathToRelativeUrl( A240AssinaturaArquivoAssinado), true);
               edtAssinaturaArquivoAssinado_Filetype = gxblobfileaux.GetExtension();
               AssignProp("", false, edtAssinaturaArquivoAssinado_Internalname, "Filetype", edtAssinaturaArquivoAssinado_Filetype, true);
            }
            AssignProp("", false, edtAssinaturaArquivoAssinado_Internalname, "URL", context.PathToRelativeUrl( A240AssinaturaArquivoAssinado), true);
         }
         GxWebStd.gx_blob_field( context, edtAssinaturaArquivoAssinado_Internalname, StringUtil.RTrim( A240AssinaturaArquivoAssinado), context.PathToRelativeUrl( A240AssinaturaArquivoAssinado), (String.IsNullOrEmpty(StringUtil.RTrim( edtAssinaturaArquivoAssinado_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtAssinaturaArquivoAssinado_Filetype)) ? A240AssinaturaArquivoAssinado : edtAssinaturaArquivoAssinado_Filetype)) : edtAssinaturaArquivoAssinado_Contenttype), true, "", edtAssinaturaArquivoAssinado_Parameters, 0, edtAssinaturaArquivoAssinado_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtAssinaturaArquivoAssinado_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "HLP_Assinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaPublicKey_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaPublicKey_Internalname, "Public Key", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaPublicKey_Internalname, A241AssinaturaPublicKey.ToString(), A241AssinaturaPublicKey.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaPublicKey_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAssinaturaPublicKey_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Assinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaPaginaConsulta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaPaginaConsulta_Internalname, "Pagina Consulta", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaPaginaConsulta_Internalname, A364AssinaturaPaginaConsulta, StringUtil.RTrim( context.localUtil.Format( A364AssinaturaPaginaConsulta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaPaginaConsulta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAssinaturaPaginaConsulta_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Assinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaToken_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaToken_Internalname, "Token", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAssinaturaToken_Internalname, A365AssinaturaToken, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtAssinaturaToken_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "512", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Assinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaFinalizadoData_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaFinalizadoData_Internalname, "Finalizada em", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAssinaturaFinalizadoData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAssinaturaFinalizadoData_Internalname, context.localUtil.TToC( A366AssinaturaFinalizadoData, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A366AssinaturaFinalizadoData, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaFinalizadoData_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAssinaturaFinalizadoData_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Assinatura.htm");
         GxWebStd.gx_bitmap( context, edtAssinaturaFinalizadoData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAssinaturaFinalizadoData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Assinatura.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipantes_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipantes_F_Internalname, "Participantes_F", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipantes_F_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A367AssinaturaParticipantes_F), 4, 0, ",", "")), StringUtil.LTrim( ((edtAssinaturaParticipantes_F_Enabled!=0) ? context.localUtil.Format( (decimal)(A367AssinaturaParticipantes_F), "ZZZ9") : context.localUtil.Format( (decimal)(A367AssinaturaParticipantes_F), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipantes_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAssinaturaParticipantes_F_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Assinatura.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Assinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Assinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Assinatura.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_contratoid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombocontratoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboContratoId), 6, 0, ",", "")), StringUtil.LTrim( ((edtavCombocontratoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboContratoId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboContratoId), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocontratoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocontratoid_Visible, edtavCombocontratoid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Assinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_arquivoid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboarquivoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ComboArquivoId), 8, 0, ",", "")), StringUtil.LTrim( ((edtavComboarquivoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV21ComboArquivoId), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV21ComboArquivoId), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboarquivoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboarquivoid_Visible, edtavComboarquivoid_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Assinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaArquivoAssinadoNome_Internalname, A257AssinaturaArquivoAssinadoNome, StringUtil.RTrim( context.localUtil.Format( A257AssinaturaArquivoAssinadoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaArquivoAssinadoNome_Jsonclick, 0, "Attribute", "", "", "", "", edtAssinaturaArquivoAssinadoNome_Visible, edtAssinaturaArquivoAssinadoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Assinatura.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaArquivoAssinadoExtensao_Internalname, A256AssinaturaArquivoAssinadoExtensao, StringUtil.RTrim( context.localUtil.Format( A256AssinaturaArquivoAssinadoExtensao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaArquivoAssinadoExtensao_Jsonclick, 0, "Attribute", "", "", "", "", edtAssinaturaArquivoAssinadoExtensao_Visible, edtAssinaturaArquivoAssinadoExtensao_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Assinatura.htm");
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
         E11112 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCONTRATOID_DATA"), AV14ContratoId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vARQUIVOID_DATA"), AV20ArquivoId_Data);
               /* Read saved values. */
               Z238AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z238AssinaturaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z239AssinaturaStatus = cgiGet( "Z239AssinaturaStatus");
               n239AssinaturaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A239AssinaturaStatus)) ? true : false);
               Z241AssinaturaPublicKey = StringUtil.StrToGuid( cgiGet( "Z241AssinaturaPublicKey"));
               n241AssinaturaPublicKey = ((Guid.Empty==A241AssinaturaPublicKey) ? true : false);
               Z364AssinaturaPaginaConsulta = cgiGet( "Z364AssinaturaPaginaConsulta");
               n364AssinaturaPaginaConsulta = (String.IsNullOrEmpty(StringUtil.RTrim( A364AssinaturaPaginaConsulta)) ? true : false);
               Z365AssinaturaToken = cgiGet( "Z365AssinaturaToken");
               n365AssinaturaToken = (String.IsNullOrEmpty(StringUtil.RTrim( A365AssinaturaToken)) ? true : false);
               Z368AssinaturaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z368AssinaturaMes"), ",", "."), 18, MidpointRounding.ToEven));
               n368AssinaturaMes = ((0==A368AssinaturaMes) ? true : false);
               Z371AssinaturaMesNome = cgiGet( "Z371AssinaturaMesNome");
               n371AssinaturaMesNome = (String.IsNullOrEmpty(StringUtil.RTrim( A371AssinaturaMesNome)) ? true : false);
               Z369AssinaturaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z369AssinaturaAno"), ",", "."), 18, MidpointRounding.ToEven));
               n369AssinaturaAno = ((0==A369AssinaturaAno) ? true : false);
               Z366AssinaturaFinalizadoData = context.localUtil.CToT( cgiGet( "Z366AssinaturaFinalizadoData"), 0);
               n366AssinaturaFinalizadoData = ((DateTime.MinValue==A366AssinaturaFinalizadoData) ? true : false);
               Z227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z227ContratoId"), ",", "."), 18, MidpointRounding.ToEven));
               n227ContratoId = ((0==A227ContratoId) ? true : false);
               Z231ArquivoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z231ArquivoId"), ",", "."), 18, MidpointRounding.ToEven));
               n231ArquivoId = ((0==A231ArquivoId) ? true : false);
               Z578ArquivoAssinadoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z578ArquivoAssinadoId"), ",", "."), 18, MidpointRounding.ToEven));
               n578ArquivoAssinadoId = ((0==A578ArquivoAssinadoId) ? true : false);
               A368AssinaturaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z368AssinaturaMes"), ",", "."), 18, MidpointRounding.ToEven));
               n368AssinaturaMes = false;
               n368AssinaturaMes = ((0==A368AssinaturaMes) ? true : false);
               A371AssinaturaMesNome = cgiGet( "Z371AssinaturaMesNome");
               n371AssinaturaMesNome = false;
               n371AssinaturaMesNome = (String.IsNullOrEmpty(StringUtil.RTrim( A371AssinaturaMesNome)) ? true : false);
               A369AssinaturaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z369AssinaturaAno"), ",", "."), 18, MidpointRounding.ToEven));
               n369AssinaturaAno = false;
               n369AssinaturaAno = ((0==A369AssinaturaAno) ? true : false);
               A578ArquivoAssinadoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z578ArquivoAssinadoId"), ",", "."), 18, MidpointRounding.ToEven));
               n578ArquivoAssinadoId = false;
               n578ArquivoAssinadoId = ((0==A578ArquivoAssinadoId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N227ContratoId"), ",", "."), 18, MidpointRounding.ToEven));
               n227ContratoId = ((0==A227ContratoId) ? true : false);
               N231ArquivoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N231ArquivoId"), ",", "."), 18, MidpointRounding.ToEven));
               n231ArquivoId = ((0==A231ArquivoId) ? true : false);
               N578ArquivoAssinadoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N578ArquivoAssinadoId"), ",", "."), 18, MidpointRounding.ToEven));
               n578ArquivoAssinadoId = ((0==A578ArquivoAssinadoId) ? true : false);
               AV7AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vASSINATURAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONTRATOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_ContratoId", StringUtil.LTrimStr( (decimal)(AV11Insert_ContratoId), 6, 0));
               AV12Insert_ArquivoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ARQUIVOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_ArquivoId", StringUtil.LTrimStr( (decimal)(AV12Insert_ArquivoId), 8, 0));
               AV22Insert_ArquivoAssinadoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ARQUIVOASSINADOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22Insert_ArquivoAssinadoId", StringUtil.LTrimStr( (decimal)(AV22Insert_ArquivoAssinadoId), 8, 0));
               A578ArquivoAssinadoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ARQUIVOASSINADOID"), ",", "."), 18, MidpointRounding.ToEven));
               n578ArquivoAssinadoId = ((0==A578ArquivoAssinadoId) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A368AssinaturaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ASSINATURAMES"), ",", "."), 18, MidpointRounding.ToEven));
               n368AssinaturaMes = ((0==A368AssinaturaMes) ? true : false);
               A371AssinaturaMesNome = cgiGet( "ASSINATURAMESNOME");
               n371AssinaturaMesNome = (String.IsNullOrEmpty(StringUtil.RTrim( A371AssinaturaMesNome)) ? true : false);
               A369AssinaturaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ASSINATURAANO"), ",", "."), 18, MidpointRounding.ToEven));
               n369AssinaturaAno = ((0==A369AssinaturaAno) ? true : false);
               A228ContratoNome = cgiGet( "CONTRATONOME");
               n228ContratoNome = false;
               A362ContratoDataInicial = context.localUtil.CToD( cgiGet( "CONTRATODATAINICIAL"), 0);
               n362ContratoDataInicial = false;
               A363ContratoDataFinal = context.localUtil.CToD( cgiGet( "CONTRATODATAFINAL"), 0);
               n363ContratoDataFinal = false;
               AV23Pgmname = cgiGet( "vPGMNAME");
               Combo_contratoid_Objectcall = cgiGet( "COMBO_CONTRATOID_Objectcall");
               Combo_contratoid_Class = cgiGet( "COMBO_CONTRATOID_Class");
               Combo_contratoid_Icontype = cgiGet( "COMBO_CONTRATOID_Icontype");
               Combo_contratoid_Icon = cgiGet( "COMBO_CONTRATOID_Icon");
               Combo_contratoid_Caption = cgiGet( "COMBO_CONTRATOID_Caption");
               Combo_contratoid_Tooltip = cgiGet( "COMBO_CONTRATOID_Tooltip");
               Combo_contratoid_Cls = cgiGet( "COMBO_CONTRATOID_Cls");
               Combo_contratoid_Selectedvalue_set = cgiGet( "COMBO_CONTRATOID_Selectedvalue_set");
               Combo_contratoid_Selectedvalue_get = cgiGet( "COMBO_CONTRATOID_Selectedvalue_get");
               Combo_contratoid_Selectedtext_set = cgiGet( "COMBO_CONTRATOID_Selectedtext_set");
               Combo_contratoid_Selectedtext_get = cgiGet( "COMBO_CONTRATOID_Selectedtext_get");
               Combo_contratoid_Gamoauthtoken = cgiGet( "COMBO_CONTRATOID_Gamoauthtoken");
               Combo_contratoid_Ddointernalname = cgiGet( "COMBO_CONTRATOID_Ddointernalname");
               Combo_contratoid_Titlecontrolalign = cgiGet( "COMBO_CONTRATOID_Titlecontrolalign");
               Combo_contratoid_Dropdownoptionstype = cgiGet( "COMBO_CONTRATOID_Dropdownoptionstype");
               Combo_contratoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Enabled"));
               Combo_contratoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Visible"));
               Combo_contratoid_Titlecontrolidtoreplace = cgiGet( "COMBO_CONTRATOID_Titlecontrolidtoreplace");
               Combo_contratoid_Datalisttype = cgiGet( "COMBO_CONTRATOID_Datalisttype");
               Combo_contratoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Allowmultipleselection"));
               Combo_contratoid_Datalistfixedvalues = cgiGet( "COMBO_CONTRATOID_Datalistfixedvalues");
               Combo_contratoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Isgriditem"));
               Combo_contratoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Hasdescription"));
               Combo_contratoid_Datalistproc = cgiGet( "COMBO_CONTRATOID_Datalistproc");
               Combo_contratoid_Datalistprocparametersprefix = cgiGet( "COMBO_CONTRATOID_Datalistprocparametersprefix");
               Combo_contratoid_Remoteservicesparameters = cgiGet( "COMBO_CONTRATOID_Remoteservicesparameters");
               Combo_contratoid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CONTRATOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_contratoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Includeonlyselectedoption"));
               Combo_contratoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Includeselectalloption"));
               Combo_contratoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Emptyitem"));
               Combo_contratoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Includeaddnewoption"));
               Combo_contratoid_Htmltemplate = cgiGet( "COMBO_CONTRATOID_Htmltemplate");
               Combo_contratoid_Multiplevaluestype = cgiGet( "COMBO_CONTRATOID_Multiplevaluestype");
               Combo_contratoid_Loadingdata = cgiGet( "COMBO_CONTRATOID_Loadingdata");
               Combo_contratoid_Noresultsfound = cgiGet( "COMBO_CONTRATOID_Noresultsfound");
               Combo_contratoid_Emptyitemtext = cgiGet( "COMBO_CONTRATOID_Emptyitemtext");
               Combo_contratoid_Onlyselectedvalues = cgiGet( "COMBO_CONTRATOID_Onlyselectedvalues");
               Combo_contratoid_Selectalltext = cgiGet( "COMBO_CONTRATOID_Selectalltext");
               Combo_contratoid_Multiplevaluesseparator = cgiGet( "COMBO_CONTRATOID_Multiplevaluesseparator");
               Combo_contratoid_Addnewoptiontext = cgiGet( "COMBO_CONTRATOID_Addnewoptiontext");
               Combo_contratoid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CONTRATOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_arquivoid_Objectcall = cgiGet( "COMBO_ARQUIVOID_Objectcall");
               Combo_arquivoid_Class = cgiGet( "COMBO_ARQUIVOID_Class");
               Combo_arquivoid_Icontype = cgiGet( "COMBO_ARQUIVOID_Icontype");
               Combo_arquivoid_Icon = cgiGet( "COMBO_ARQUIVOID_Icon");
               Combo_arquivoid_Caption = cgiGet( "COMBO_ARQUIVOID_Caption");
               Combo_arquivoid_Tooltip = cgiGet( "COMBO_ARQUIVOID_Tooltip");
               Combo_arquivoid_Cls = cgiGet( "COMBO_ARQUIVOID_Cls");
               Combo_arquivoid_Selectedvalue_set = cgiGet( "COMBO_ARQUIVOID_Selectedvalue_set");
               Combo_arquivoid_Selectedvalue_get = cgiGet( "COMBO_ARQUIVOID_Selectedvalue_get");
               Combo_arquivoid_Selectedtext_set = cgiGet( "COMBO_ARQUIVOID_Selectedtext_set");
               Combo_arquivoid_Selectedtext_get = cgiGet( "COMBO_ARQUIVOID_Selectedtext_get");
               Combo_arquivoid_Gamoauthtoken = cgiGet( "COMBO_ARQUIVOID_Gamoauthtoken");
               Combo_arquivoid_Ddointernalname = cgiGet( "COMBO_ARQUIVOID_Ddointernalname");
               Combo_arquivoid_Titlecontrolalign = cgiGet( "COMBO_ARQUIVOID_Titlecontrolalign");
               Combo_arquivoid_Dropdownoptionstype = cgiGet( "COMBO_ARQUIVOID_Dropdownoptionstype");
               Combo_arquivoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ARQUIVOID_Enabled"));
               Combo_arquivoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ARQUIVOID_Visible"));
               Combo_arquivoid_Titlecontrolidtoreplace = cgiGet( "COMBO_ARQUIVOID_Titlecontrolidtoreplace");
               Combo_arquivoid_Datalisttype = cgiGet( "COMBO_ARQUIVOID_Datalisttype");
               Combo_arquivoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ARQUIVOID_Allowmultipleselection"));
               Combo_arquivoid_Datalistfixedvalues = cgiGet( "COMBO_ARQUIVOID_Datalistfixedvalues");
               Combo_arquivoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ARQUIVOID_Isgriditem"));
               Combo_arquivoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ARQUIVOID_Hasdescription"));
               Combo_arquivoid_Datalistproc = cgiGet( "COMBO_ARQUIVOID_Datalistproc");
               Combo_arquivoid_Datalistprocparametersprefix = cgiGet( "COMBO_ARQUIVOID_Datalistprocparametersprefix");
               Combo_arquivoid_Remoteservicesparameters = cgiGet( "COMBO_ARQUIVOID_Remoteservicesparameters");
               Combo_arquivoid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ARQUIVOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_arquivoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ARQUIVOID_Includeonlyselectedoption"));
               Combo_arquivoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ARQUIVOID_Includeselectalloption"));
               Combo_arquivoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ARQUIVOID_Emptyitem"));
               Combo_arquivoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ARQUIVOID_Includeaddnewoption"));
               Combo_arquivoid_Htmltemplate = cgiGet( "COMBO_ARQUIVOID_Htmltemplate");
               Combo_arquivoid_Multiplevaluestype = cgiGet( "COMBO_ARQUIVOID_Multiplevaluestype");
               Combo_arquivoid_Loadingdata = cgiGet( "COMBO_ARQUIVOID_Loadingdata");
               Combo_arquivoid_Noresultsfound = cgiGet( "COMBO_ARQUIVOID_Noresultsfound");
               Combo_arquivoid_Emptyitemtext = cgiGet( "COMBO_ARQUIVOID_Emptyitemtext");
               Combo_arquivoid_Onlyselectedvalues = cgiGet( "COMBO_ARQUIVOID_Onlyselectedvalues");
               Combo_arquivoid_Selectalltext = cgiGet( "COMBO_ARQUIVOID_Selectalltext");
               Combo_arquivoid_Multiplevaluesseparator = cgiGet( "COMBO_ARQUIVOID_Multiplevaluesseparator");
               Combo_arquivoid_Addnewoptiontext = cgiGet( "COMBO_ARQUIVOID_Addnewoptiontext");
               Combo_arquivoid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ARQUIVOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               edtAssinaturaArquivoAssinado_Filetype = cgiGet( "ASSINATURAARQUIVOASSINADO_Filetype");
               edtAssinaturaArquivoAssinado_Filename = cgiGet( "ASSINATURAARQUIVOASSINADO_Filename");
               edtAssinaturaArquivoAssinado_Filename = cgiGet( "ASSINATURAARQUIVOASSINADO_Filename");
               edtAssinaturaArquivoAssinado_Filetype = cgiGet( "ASSINATURAARQUIVOASSINADO_Filetype");
               /* Read variables values. */
               A238AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n238AssinaturaId = false;
               AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
               cmbAssinaturaStatus.CurrentValue = cgiGet( cmbAssinaturaStatus_Internalname);
               A239AssinaturaStatus = cgiGet( cmbAssinaturaStatus_Internalname);
               n239AssinaturaStatus = false;
               AssignAttri("", false, "A239AssinaturaStatus", A239AssinaturaStatus);
               n239AssinaturaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A239AssinaturaStatus)) ? true : false);
               n227ContratoId = ((StringUtil.StrCmp(cgiGet( edtContratoId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTRATOID");
                  AnyError = 1;
                  GX_FocusControl = edtContratoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A227ContratoId = 0;
                  n227ContratoId = false;
                  AssignAttri("", false, "A227ContratoId", (n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
               }
               else
               {
                  A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A227ContratoId", (n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
               }
               n231ArquivoId = ((StringUtil.StrCmp(cgiGet( edtArquivoId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtArquivoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtArquivoId_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ARQUIVOID");
                  AnyError = 1;
                  GX_FocusControl = edtArquivoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A231ArquivoId = 0;
                  n231ArquivoId = false;
                  AssignAttri("", false, "A231ArquivoId", (n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
               }
               else
               {
                  A231ArquivoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtArquivoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A231ArquivoId", (n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
               }
               A240AssinaturaArquivoAssinado = cgiGet( edtAssinaturaArquivoAssinado_Internalname);
               n240AssinaturaArquivoAssinado = false;
               AssignAttri("", false, "A240AssinaturaArquivoAssinado", A240AssinaturaArquivoAssinado);
               n240AssinaturaArquivoAssinado = (String.IsNullOrEmpty(StringUtil.RTrim( A240AssinaturaArquivoAssinado)) ? true : false);
               if ( StringUtil.StrCmp(cgiGet( edtAssinaturaPublicKey_Internalname), "") == 0 )
               {
                  A241AssinaturaPublicKey = Guid.Empty;
                  n241AssinaturaPublicKey = true;
                  AssignAttri("", false, "A241AssinaturaPublicKey", A241AssinaturaPublicKey.ToString());
               }
               else
               {
                  try
                  {
                     A241AssinaturaPublicKey = StringUtil.StrToGuid( cgiGet( edtAssinaturaPublicKey_Internalname));
                     n241AssinaturaPublicKey = false;
                     AssignAttri("", false, "A241AssinaturaPublicKey", A241AssinaturaPublicKey.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ASSINATURAPUBLICKEY");
                     AnyError = 1;
                     GX_FocusControl = edtAssinaturaPublicKey_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n241AssinaturaPublicKey = ((Guid.Empty==A241AssinaturaPublicKey) ? true : false);
               A364AssinaturaPaginaConsulta = cgiGet( edtAssinaturaPaginaConsulta_Internalname);
               n364AssinaturaPaginaConsulta = false;
               AssignAttri("", false, "A364AssinaturaPaginaConsulta", A364AssinaturaPaginaConsulta);
               n364AssinaturaPaginaConsulta = (String.IsNullOrEmpty(StringUtil.RTrim( A364AssinaturaPaginaConsulta)) ? true : false);
               A365AssinaturaToken = cgiGet( edtAssinaturaToken_Internalname);
               n365AssinaturaToken = false;
               AssignAttri("", false, "A365AssinaturaToken", A365AssinaturaToken);
               n365AssinaturaToken = (String.IsNullOrEmpty(StringUtil.RTrim( A365AssinaturaToken)) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtAssinaturaFinalizadoData_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Assinatura Finalizada em"}), 1, "ASSINATURAFINALIZADODATA");
                  AnyError = 1;
                  GX_FocusControl = edtAssinaturaFinalizadoData_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
                  n366AssinaturaFinalizadoData = false;
                  AssignAttri("", false, "A366AssinaturaFinalizadoData", context.localUtil.TToC( A366AssinaturaFinalizadoData, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A366AssinaturaFinalizadoData = context.localUtil.CToT( cgiGet( edtAssinaturaFinalizadoData_Internalname));
                  n366AssinaturaFinalizadoData = false;
                  AssignAttri("", false, "A366AssinaturaFinalizadoData", context.localUtil.TToC( A366AssinaturaFinalizadoData, 8, 5, 0, 3, "/", ":", " "));
               }
               n366AssinaturaFinalizadoData = ((DateTime.MinValue==A366AssinaturaFinalizadoData) ? true : false);
               A367AssinaturaParticipantes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaParticipantes_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n367AssinaturaParticipantes_F = false;
               AssignAttri("", false, "A367AssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(A367AssinaturaParticipantes_F), 4, 0));
               AV19ComboContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombocontratoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ComboContratoId", StringUtil.LTrimStr( (decimal)(AV19ComboContratoId), 6, 0));
               AV21ComboArquivoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboarquivoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21ComboArquivoId", StringUtil.LTrimStr( (decimal)(AV21ComboArquivoId), 8, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A240AssinaturaArquivoAssinado)) )
               {
                  edtAssinaturaArquivoAssinado_Filename = (string)(CGIGetFileName(edtAssinaturaArquivoAssinado_Internalname));
                  edtAssinaturaArquivoAssinado_Filetype = (string)(CGIGetFileType(edtAssinaturaArquivoAssinado_Internalname));
               }
               A256AssinaturaArquivoAssinadoExtensao = edtAssinaturaArquivoAssinado_Filetype;
               n256AssinaturaArquivoAssinadoExtensao = false;
               AssignAttri("", false, "A256AssinaturaArquivoAssinadoExtensao", A256AssinaturaArquivoAssinadoExtensao);
               A257AssinaturaArquivoAssinadoNome = edtAssinaturaArquivoAssinado_Filename;
               n257AssinaturaArquivoAssinadoNome = false;
               AssignAttri("", false, "A257AssinaturaArquivoAssinadoNome", A257AssinaturaArquivoAssinadoNome);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( A240AssinaturaArquivoAssinado)) )
               {
                  GXCCtlgxBlob = "ASSINATURAARQUIVOASSINADO" + "_gxBlob";
                  A240AssinaturaArquivoAssinado = cgiGet( GXCCtlgxBlob);
                  n240AssinaturaArquivoAssinado = false;
                  n240AssinaturaArquivoAssinado = (String.IsNullOrEmpty(StringUtil.RTrim( A240AssinaturaArquivoAssinado)) ? true : false);
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Assinatura");
               A238AssinaturaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n238AssinaturaId = false;
               AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
               forbiddenHiddens.Add("AssinaturaId", context.localUtil.Format( (decimal)(A238AssinaturaId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ContratoId", context.localUtil.Format( (decimal)(AV11Insert_ContratoId), "ZZZZZ9"));
               forbiddenHiddens.Add("Insert_ArquivoId", context.localUtil.Format( (decimal)(AV12Insert_ArquivoId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ArquivoAssinadoId", context.localUtil.Format( (decimal)(AV22Insert_ArquivoAssinadoId), "ZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("AssinaturaMes", context.localUtil.Format( (decimal)(A368AssinaturaMes), "ZZZ9"));
               forbiddenHiddens.Add("AssinaturaMesNome", StringUtil.RTrim( context.localUtil.Format( A371AssinaturaMesNome, "")));
               forbiddenHiddens.Add("AssinaturaAno", context.localUtil.Format( (decimal)(A369AssinaturaAno), "ZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A238AssinaturaId != Z238AssinaturaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("assinatura:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A238AssinaturaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaId"), "."), 18, MidpointRounding.ToEven));
                  n238AssinaturaId = false;
                  AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
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
                     sMode40 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode40;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound40 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_110( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ASSINATURAID");
                        AnyError = 1;
                        GX_FocusControl = edtAssinaturaId_Internalname;
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
                           E11112 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12112 ();
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
            E12112 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1140( ) ;
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
            DisableAttributes1140( ) ;
         }
         AssignProp("", false, edtavCombocontratoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocontratoid_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboarquivoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboarquivoid_Enabled), 5, 0), true);
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

      protected void CONFIRM_110( )
      {
         BeforeValidate1140( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1140( ) ;
            }
            else
            {
               CheckExtendedTable1140( ) ;
               CloseExtendedTableCursors1140( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption110( )
      {
      }

      protected void E11112( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtArquivoId_Visible = 0;
         AssignProp("", false, edtArquivoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtArquivoId_Visible), 5, 0), true);
         AV21ComboArquivoId = 0;
         AssignAttri("", false, "AV21ComboArquivoId", StringUtil.LTrimStr( (decimal)(AV21ComboArquivoId), 8, 0));
         edtavComboarquivoid_Visible = 0;
         AssignProp("", false, edtavComboarquivoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboarquivoid_Visible), 5, 0), true);
         edtContratoId_Visible = 0;
         AssignProp("", false, edtContratoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtContratoId_Visible), 5, 0), true);
         AV19ComboContratoId = 0;
         AssignAttri("", false, "AV19ComboContratoId", StringUtil.LTrimStr( (decimal)(AV19ComboContratoId), 6, 0));
         edtavCombocontratoid_Visible = 0;
         AssignProp("", false, edtavCombocontratoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocontratoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCONTRATOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOARQUIVOID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            while ( AV24GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ContratoId") == 0 )
               {
                  AV11Insert_ContratoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ContratoId", StringUtil.LTrimStr( (decimal)(AV11Insert_ContratoId), 6, 0));
                  if ( ! (0==AV11Insert_ContratoId) )
                  {
                     AV19ComboContratoId = AV11Insert_ContratoId;
                     AssignAttri("", false, "AV19ComboContratoId", StringUtil.LTrimStr( (decimal)(AV19ComboContratoId), 6, 0));
                     Combo_contratoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ComboContratoId), 6, 0));
                     ucCombo_contratoid.SendProperty(context, "", false, Combo_contratoid_Internalname, "SelectedValue_set", Combo_contratoid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new assinaturaloaddvcombo(context ).execute(  "ContratoId",  "GET",  false,  AV7AssinaturaId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_contratoid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_contratoid.SendProperty(context, "", false, Combo_contratoid_Internalname, "SelectedText_set", Combo_contratoid_Selectedtext_set);
                     Combo_contratoid_Enabled = false;
                     ucCombo_contratoid.SendProperty(context, "", false, Combo_contratoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_contratoid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ArquivoId") == 0 )
               {
                  AV12Insert_ArquivoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_ArquivoId", StringUtil.LTrimStr( (decimal)(AV12Insert_ArquivoId), 8, 0));
                  if ( ! (0==AV12Insert_ArquivoId) )
                  {
                     AV21ComboArquivoId = AV12Insert_ArquivoId;
                     AssignAttri("", false, "AV21ComboArquivoId", StringUtil.LTrimStr( (decimal)(AV21ComboArquivoId), 8, 0));
                     Combo_arquivoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV21ComboArquivoId), 8, 0));
                     ucCombo_arquivoid.SendProperty(context, "", false, Combo_arquivoid_Internalname, "SelectedValue_set", Combo_arquivoid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new assinaturaloaddvcombo(context ).execute(  "ArquivoId",  "GET",  false,  AV7AssinaturaId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_arquivoid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_arquivoid.SendProperty(context, "", false, Combo_arquivoid_Internalname, "SelectedText_set", Combo_arquivoid_Selectedtext_set);
                     Combo_arquivoid_Enabled = false;
                     ucCombo_arquivoid.SendProperty(context, "", false, Combo_arquivoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_arquivoid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ArquivoAssinadoId") == 0 )
               {
                  AV22Insert_ArquivoAssinadoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV22Insert_ArquivoAssinadoId", StringUtil.LTrimStr( (decimal)(AV22Insert_ArquivoAssinadoId), 8, 0));
               }
               AV24GXV1 = (int)(AV24GXV1+1);
               AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            }
         }
         edtAssinaturaArquivoAssinadoNome_Visible = 0;
         AssignProp("", false, edtAssinaturaArquivoAssinadoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAssinaturaArquivoAssinadoNome_Visible), 5, 0), true);
         edtAssinaturaArquivoAssinadoExtensao_Visible = 0;
         AssignProp("", false, edtAssinaturaArquivoAssinadoExtensao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAssinaturaArquivoAssinadoExtensao_Visible), 5, 0), true);
      }

      protected void E12112( )
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
         /* 'LOADCOMBOARQUIVOID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new assinaturaloaddvcombo(context ).execute(  "ArquivoId",  Gx_mode,  false,  AV7AssinaturaId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_arquivoid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_arquivoid.SendProperty(context, "", false, Combo_arquivoid_Internalname, "SelectedValue_set", Combo_arquivoid_Selectedvalue_set);
         Combo_arquivoid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_arquivoid.SendProperty(context, "", false, Combo_arquivoid_Internalname, "SelectedText_set", Combo_arquivoid_Selectedtext_set);
         AV21ComboArquivoId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV21ComboArquivoId", StringUtil.LTrimStr( (decimal)(AV21ComboArquivoId), 8, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_arquivoid_Enabled = false;
            ucCombo_arquivoid.SendProperty(context, "", false, Combo_arquivoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_arquivoid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCONTRATOID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new assinaturaloaddvcombo(context ).execute(  "ContratoId",  Gx_mode,  false,  AV7AssinaturaId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_contratoid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_contratoid.SendProperty(context, "", false, Combo_contratoid_Internalname, "SelectedValue_set", Combo_contratoid_Selectedvalue_set);
         Combo_contratoid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_contratoid.SendProperty(context, "", false, Combo_contratoid_Internalname, "SelectedText_set", Combo_contratoid_Selectedtext_set);
         AV19ComboContratoId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV19ComboContratoId", StringUtil.LTrimStr( (decimal)(AV19ComboContratoId), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_contratoid_Enabled = false;
            ucCombo_contratoid.SendProperty(context, "", false, Combo_contratoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_contratoid_Enabled));
         }
      }

      protected void ZM1140( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z239AssinaturaStatus = T00113_A239AssinaturaStatus[0];
               Z241AssinaturaPublicKey = T00113_A241AssinaturaPublicKey[0];
               Z364AssinaturaPaginaConsulta = T00113_A364AssinaturaPaginaConsulta[0];
               Z365AssinaturaToken = T00113_A365AssinaturaToken[0];
               Z368AssinaturaMes = T00113_A368AssinaturaMes[0];
               Z371AssinaturaMesNome = T00113_A371AssinaturaMesNome[0];
               Z369AssinaturaAno = T00113_A369AssinaturaAno[0];
               Z366AssinaturaFinalizadoData = T00113_A366AssinaturaFinalizadoData[0];
               Z227ContratoId = T00113_A227ContratoId[0];
               Z231ArquivoId = T00113_A231ArquivoId[0];
               Z578ArquivoAssinadoId = T00113_A578ArquivoAssinadoId[0];
            }
            else
            {
               Z239AssinaturaStatus = A239AssinaturaStatus;
               Z241AssinaturaPublicKey = A241AssinaturaPublicKey;
               Z364AssinaturaPaginaConsulta = A364AssinaturaPaginaConsulta;
               Z365AssinaturaToken = A365AssinaturaToken;
               Z368AssinaturaMes = A368AssinaturaMes;
               Z371AssinaturaMesNome = A371AssinaturaMesNome;
               Z369AssinaturaAno = A369AssinaturaAno;
               Z366AssinaturaFinalizadoData = A366AssinaturaFinalizadoData;
               Z227ContratoId = A227ContratoId;
               Z231ArquivoId = A231ArquivoId;
               Z578ArquivoAssinadoId = A578ArquivoAssinadoId;
            }
         }
         if ( GX_JID == -16 )
         {
            Z238AssinaturaId = A238AssinaturaId;
            Z239AssinaturaStatus = A239AssinaturaStatus;
            Z240AssinaturaArquivoAssinado = A240AssinaturaArquivoAssinado;
            Z241AssinaturaPublicKey = A241AssinaturaPublicKey;
            Z364AssinaturaPaginaConsulta = A364AssinaturaPaginaConsulta;
            Z365AssinaturaToken = A365AssinaturaToken;
            Z368AssinaturaMes = A368AssinaturaMes;
            Z371AssinaturaMesNome = A371AssinaturaMesNome;
            Z369AssinaturaAno = A369AssinaturaAno;
            Z366AssinaturaFinalizadoData = A366AssinaturaFinalizadoData;
            Z256AssinaturaArquivoAssinadoExtensao = A256AssinaturaArquivoAssinadoExtensao;
            Z257AssinaturaArquivoAssinadoNome = A257AssinaturaArquivoAssinadoNome;
            Z227ContratoId = A227ContratoId;
            Z231ArquivoId = A231ArquivoId;
            Z578ArquivoAssinadoId = A578ArquivoAssinadoId;
            Z367AssinaturaParticipantes_F = A367AssinaturaParticipantes_F;
            Z228ContratoNome = A228ContratoNome;
            Z362ContratoDataInicial = A362ContratoDataInicial;
            Z363ContratoDataFinal = A363ContratoDataFinal;
         }
      }

      protected void standaloneNotModal( )
      {
         edtAssinaturaId_Enabled = 0;
         AssignProp("", false, edtAssinaturaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV23Pgmname = "Assinatura";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         edtAssinaturaId_Enabled = 0;
         AssignProp("", false, edtAssinaturaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7AssinaturaId) )
         {
            A238AssinaturaId = AV7AssinaturaId;
            n238AssinaturaId = false;
            AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ContratoId) )
         {
            edtContratoId_Enabled = 0;
            AssignProp("", false, edtContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoId_Enabled), 5, 0), true);
         }
         else
         {
            edtContratoId_Enabled = 1;
            AssignProp("", false, edtContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ArquivoId) )
         {
            edtArquivoId_Enabled = 0;
            AssignProp("", false, edtArquivoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtArquivoId_Enabled), 5, 0), true);
         }
         else
         {
            edtArquivoId_Enabled = 1;
            AssignProp("", false, edtArquivoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtArquivoId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ContratoId) )
         {
            A227ContratoId = AV11Insert_ContratoId;
            n227ContratoId = false;
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboContratoId) )
            {
               A227ContratoId = 0;
               n227ContratoId = false;
               AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
               n227ContratoId = true;
               n227ContratoId = true;
               AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboContratoId) )
               {
                  A227ContratoId = AV19ComboContratoId;
                  n227ContratoId = false;
                  AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
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
         if ( IsIns( )  && (Guid.Empty==A241AssinaturaPublicKey) && ( Gx_BScreen == 0 ) )
         {
            A241AssinaturaPublicKey = Guid.NewGuid( );
            n241AssinaturaPublicKey = false;
            AssignAttri("", false, "A241AssinaturaPublicKey", A241AssinaturaPublicKey.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00118 */
            pr_default.execute(5, new Object[] {n238AssinaturaId, A238AssinaturaId});
            if ( (pr_default.getStatus(5) != 101) )
            {
               A367AssinaturaParticipantes_F = T00118_A367AssinaturaParticipantes_F[0];
               n367AssinaturaParticipantes_F = T00118_n367AssinaturaParticipantes_F[0];
               AssignAttri("", false, "A367AssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(A367AssinaturaParticipantes_F), 4, 0));
            }
            else
            {
               A367AssinaturaParticipantes_F = 0;
               n367AssinaturaParticipantes_F = false;
               AssignAttri("", false, "A367AssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(A367AssinaturaParticipantes_F), 4, 0));
            }
            pr_default.close(5);
            /* Using cursor T00114 */
            pr_default.execute(2, new Object[] {n227ContratoId, A227ContratoId});
            A228ContratoNome = T00114_A228ContratoNome[0];
            n228ContratoNome = T00114_n228ContratoNome[0];
            A362ContratoDataInicial = T00114_A362ContratoDataInicial[0];
            n362ContratoDataInicial = T00114_n362ContratoDataInicial[0];
            A363ContratoDataFinal = T00114_A363ContratoDataFinal[0];
            n363ContratoDataFinal = T00114_n363ContratoDataFinal[0];
            pr_default.close(2);
         }
      }

      protected void Load1140( )
      {
         /* Using cursor T001110 */
         pr_default.execute(6, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound40 = 1;
            A239AssinaturaStatus = T001110_A239AssinaturaStatus[0];
            n239AssinaturaStatus = T001110_n239AssinaturaStatus[0];
            AssignAttri("", false, "A239AssinaturaStatus", A239AssinaturaStatus);
            A228ContratoNome = T001110_A228ContratoNome[0];
            n228ContratoNome = T001110_n228ContratoNome[0];
            A362ContratoDataInicial = T001110_A362ContratoDataInicial[0];
            n362ContratoDataInicial = T001110_n362ContratoDataInicial[0];
            A363ContratoDataFinal = T001110_A363ContratoDataFinal[0];
            n363ContratoDataFinal = T001110_n363ContratoDataFinal[0];
            A241AssinaturaPublicKey = T001110_A241AssinaturaPublicKey[0];
            n241AssinaturaPublicKey = T001110_n241AssinaturaPublicKey[0];
            AssignAttri("", false, "A241AssinaturaPublicKey", A241AssinaturaPublicKey.ToString());
            A364AssinaturaPaginaConsulta = T001110_A364AssinaturaPaginaConsulta[0];
            n364AssinaturaPaginaConsulta = T001110_n364AssinaturaPaginaConsulta[0];
            AssignAttri("", false, "A364AssinaturaPaginaConsulta", A364AssinaturaPaginaConsulta);
            A365AssinaturaToken = T001110_A365AssinaturaToken[0];
            n365AssinaturaToken = T001110_n365AssinaturaToken[0];
            AssignAttri("", false, "A365AssinaturaToken", A365AssinaturaToken);
            A368AssinaturaMes = T001110_A368AssinaturaMes[0];
            n368AssinaturaMes = T001110_n368AssinaturaMes[0];
            A371AssinaturaMesNome = T001110_A371AssinaturaMesNome[0];
            n371AssinaturaMesNome = T001110_n371AssinaturaMesNome[0];
            A369AssinaturaAno = T001110_A369AssinaturaAno[0];
            n369AssinaturaAno = T001110_n369AssinaturaAno[0];
            A366AssinaturaFinalizadoData = T001110_A366AssinaturaFinalizadoData[0];
            n366AssinaturaFinalizadoData = T001110_n366AssinaturaFinalizadoData[0];
            AssignAttri("", false, "A366AssinaturaFinalizadoData", context.localUtil.TToC( A366AssinaturaFinalizadoData, 8, 5, 0, 3, "/", ":", " "));
            A256AssinaturaArquivoAssinadoExtensao = T001110_A256AssinaturaArquivoAssinadoExtensao[0];
            n256AssinaturaArquivoAssinadoExtensao = T001110_n256AssinaturaArquivoAssinadoExtensao[0];
            AssignAttri("", false, "A256AssinaturaArquivoAssinadoExtensao", A256AssinaturaArquivoAssinadoExtensao);
            edtAssinaturaArquivoAssinado_Filetype = A256AssinaturaArquivoAssinadoExtensao;
            AssignProp("", false, edtAssinaturaArquivoAssinado_Internalname, "Filetype", edtAssinaturaArquivoAssinado_Filetype, true);
            A257AssinaturaArquivoAssinadoNome = T001110_A257AssinaturaArquivoAssinadoNome[0];
            n257AssinaturaArquivoAssinadoNome = T001110_n257AssinaturaArquivoAssinadoNome[0];
            AssignAttri("", false, "A257AssinaturaArquivoAssinadoNome", A257AssinaturaArquivoAssinadoNome);
            edtAssinaturaArquivoAssinado_Filename = A257AssinaturaArquivoAssinadoNome;
            A227ContratoId = T001110_A227ContratoId[0];
            n227ContratoId = T001110_n227ContratoId[0];
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            A231ArquivoId = T001110_A231ArquivoId[0];
            n231ArquivoId = T001110_n231ArquivoId[0];
            AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
            A578ArquivoAssinadoId = T001110_A578ArquivoAssinadoId[0];
            n578ArquivoAssinadoId = T001110_n578ArquivoAssinadoId[0];
            A367AssinaturaParticipantes_F = T001110_A367AssinaturaParticipantes_F[0];
            n367AssinaturaParticipantes_F = T001110_n367AssinaturaParticipantes_F[0];
            AssignAttri("", false, "A367AssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(A367AssinaturaParticipantes_F), 4, 0));
            A240AssinaturaArquivoAssinado = T001110_A240AssinaturaArquivoAssinado[0];
            n240AssinaturaArquivoAssinado = T001110_n240AssinaturaArquivoAssinado[0];
            AssignAttri("", false, "A240AssinaturaArquivoAssinado", A240AssinaturaArquivoAssinado);
            AssignProp("", false, edtAssinaturaArquivoAssinado_Internalname, "URL", context.PathToRelativeUrl( A240AssinaturaArquivoAssinado), true);
            ZM1140( -16) ;
         }
         pr_default.close(6);
         OnLoadActions1140( ) ;
      }

      protected void OnLoadActions1140( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ArquivoId) )
         {
            A231ArquivoId = AV12Insert_ArquivoId;
            n231ArquivoId = false;
            AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV21ComboArquivoId) )
            {
               A231ArquivoId = 0;
               n231ArquivoId = false;
               AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
               n231ArquivoId = true;
               n231ArquivoId = true;
               AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV21ComboArquivoId) )
               {
                  A231ArquivoId = AV21ComboArquivoId;
                  n231ArquivoId = false;
                  AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A231ArquivoId) )
                  {
                     A231ArquivoId = 0;
                     n231ArquivoId = false;
                     AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
                     n231ArquivoId = true;
                     n231ArquivoId = true;
                     AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_ArquivoAssinadoId) )
         {
            A578ArquivoAssinadoId = AV22Insert_ArquivoAssinadoId;
            n578ArquivoAssinadoId = false;
            AssignAttri("", false, "A578ArquivoAssinadoId", ((0==A578ArquivoAssinadoId)&&IsIns( )||n578ArquivoAssinadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A578ArquivoAssinadoId), 8, 0, ".", ""))));
         }
         else
         {
            if ( (0==A578ArquivoAssinadoId) )
            {
               A578ArquivoAssinadoId = 0;
               n578ArquivoAssinadoId = false;
               AssignAttri("", false, "A578ArquivoAssinadoId", ((0==A578ArquivoAssinadoId)&&IsIns( )||n578ArquivoAssinadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A578ArquivoAssinadoId), 8, 0, ".", ""))));
               n578ArquivoAssinadoId = true;
               n578ArquivoAssinadoId = true;
               AssignAttri("", false, "A578ArquivoAssinadoId", ((0==A578ArquivoAssinadoId)&&IsIns( )||n578ArquivoAssinadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A578ArquivoAssinadoId), 8, 0, ".", ""))));
            }
         }
      }

      protected void CheckExtendedTable1140( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ArquivoId) )
         {
            A231ArquivoId = AV12Insert_ArquivoId;
            n231ArquivoId = false;
            AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV21ComboArquivoId) )
            {
               A231ArquivoId = 0;
               n231ArquivoId = false;
               AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
               n231ArquivoId = true;
               n231ArquivoId = true;
               AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV21ComboArquivoId) )
               {
                  A231ArquivoId = AV21ComboArquivoId;
                  n231ArquivoId = false;
                  AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A231ArquivoId) )
                  {
                     A231ArquivoId = 0;
                     n231ArquivoId = false;
                     AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
                     n231ArquivoId = true;
                     n231ArquivoId = true;
                     AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_ArquivoAssinadoId) )
         {
            A578ArquivoAssinadoId = AV22Insert_ArquivoAssinadoId;
            n578ArquivoAssinadoId = false;
            AssignAttri("", false, "A578ArquivoAssinadoId", ((0==A578ArquivoAssinadoId)&&IsIns( )||n578ArquivoAssinadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A578ArquivoAssinadoId), 8, 0, ".", ""))));
         }
         else
         {
            if ( (0==A578ArquivoAssinadoId) )
            {
               A578ArquivoAssinadoId = 0;
               n578ArquivoAssinadoId = false;
               AssignAttri("", false, "A578ArquivoAssinadoId", ((0==A578ArquivoAssinadoId)&&IsIns( )||n578ArquivoAssinadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A578ArquivoAssinadoId), 8, 0, ".", ""))));
               n578ArquivoAssinadoId = true;
               n578ArquivoAssinadoId = true;
               AssignAttri("", false, "A578ArquivoAssinadoId", ((0==A578ArquivoAssinadoId)&&IsIns( )||n578ArquivoAssinadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A578ArquivoAssinadoId), 8, 0, ".", ""))));
            }
         }
         /* Using cursor T00118 */
         pr_default.execute(5, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A367AssinaturaParticipantes_F = T00118_A367AssinaturaParticipantes_F[0];
            n367AssinaturaParticipantes_F = T00118_n367AssinaturaParticipantes_F[0];
            AssignAttri("", false, "A367AssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(A367AssinaturaParticipantes_F), 4, 0));
         }
         else
         {
            A367AssinaturaParticipantes_F = 0;
            n367AssinaturaParticipantes_F = false;
            AssignAttri("", false, "A367AssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(A367AssinaturaParticipantes_F), 4, 0));
         }
         pr_default.close(5);
         if ( ! ( ( StringUtil.StrCmp(A239AssinaturaStatus, "ENVIADO") == 0 ) || ( StringUtil.StrCmp(A239AssinaturaStatus, "REJEITADO") == 0 ) || ( StringUtil.StrCmp(A239AssinaturaStatus, "CANCELADO") == 0 ) || ( StringUtil.StrCmp(A239AssinaturaStatus, "ASSINADO") == 0 ) || ( StringUtil.StrCmp(A239AssinaturaStatus, "AGUARDANDO_ENVIO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A239AssinaturaStatus)) ) )
         {
            GX_msglist.addItem("Campo Assinatura Status fora do intervalo", "OutOfRange", 1, "ASSINATURASTATUS");
            AnyError = 1;
            GX_FocusControl = cmbAssinaturaStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00114 */
         pr_default.execute(2, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A228ContratoNome = T00114_A228ContratoNome[0];
         n228ContratoNome = T00114_n228ContratoNome[0];
         A362ContratoDataInicial = T00114_A362ContratoDataInicial[0];
         n362ContratoDataInicial = T00114_n362ContratoDataInicial[0];
         A363ContratoDataFinal = T00114_A363ContratoDataFinal[0];
         n363ContratoDataFinal = T00114_n363ContratoDataFinal[0];
         pr_default.close(2);
         /* Using cursor T00115 */
         pr_default.execute(3, new Object[] {n231ArquivoId, A231ArquivoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A231ArquivoId) ) )
            {
               GX_msglist.addItem("Não existe 'Arquivo'.", "ForeignKeyNotFound", 1, "ARQUIVOID");
               AnyError = 1;
               GX_FocusControl = edtArquivoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T00116 */
         pr_default.execute(4, new Object[] {n578ArquivoAssinadoId, A578ArquivoAssinadoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A578ArquivoAssinadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Arquivo Assinado'.", "ForeignKeyNotFound", 1, "ARQUIVOASSINADOID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1140( )
      {
         pr_default.close(5);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_20( long A238AssinaturaId )
      {
         /* Using cursor T001112 */
         pr_default.execute(7, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A367AssinaturaParticipantes_F = T001112_A367AssinaturaParticipantes_F[0];
            n367AssinaturaParticipantes_F = T001112_n367AssinaturaParticipantes_F[0];
            AssignAttri("", false, "A367AssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(A367AssinaturaParticipantes_F), 4, 0));
         }
         else
         {
            A367AssinaturaParticipantes_F = 0;
            n367AssinaturaParticipantes_F = false;
            AssignAttri("", false, "A367AssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(A367AssinaturaParticipantes_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A367AssinaturaParticipantes_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_17( int A227ContratoId )
      {
         /* Using cursor T001113 */
         pr_default.execute(8, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A228ContratoNome = T001113_A228ContratoNome[0];
         n228ContratoNome = T001113_n228ContratoNome[0];
         A362ContratoDataInicial = T001113_A362ContratoDataInicial[0];
         n362ContratoDataInicial = T001113_n362ContratoDataInicial[0];
         A363ContratoDataFinal = T001113_A363ContratoDataFinal[0];
         n363ContratoDataFinal = T001113_n363ContratoDataFinal[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A228ContratoNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A362ContratoDataInicial, "99/99/99"))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A363ContratoDataFinal, "99/99/99"))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_18( int A231ArquivoId )
      {
         /* Using cursor T001114 */
         pr_default.execute(9, new Object[] {n231ArquivoId, A231ArquivoId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A231ArquivoId) ) )
            {
               GX_msglist.addItem("Não existe 'Arquivo'.", "ForeignKeyNotFound", 1, "ARQUIVOID");
               AnyError = 1;
               GX_FocusControl = edtArquivoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_19( int A578ArquivoAssinadoId )
      {
         /* Using cursor T001115 */
         pr_default.execute(10, new Object[] {n578ArquivoAssinadoId, A578ArquivoAssinadoId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A578ArquivoAssinadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Arquivo Assinado'.", "ForeignKeyNotFound", 1, "ARQUIVOASSINADOID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey1140( )
      {
         /* Using cursor T001116 */
         pr_default.execute(11, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound40 = 1;
         }
         else
         {
            RcdFound40 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00113 */
         pr_default.execute(1, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1140( 16) ;
            RcdFound40 = 1;
            A238AssinaturaId = T00113_A238AssinaturaId[0];
            n238AssinaturaId = T00113_n238AssinaturaId[0];
            AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
            A239AssinaturaStatus = T00113_A239AssinaturaStatus[0];
            n239AssinaturaStatus = T00113_n239AssinaturaStatus[0];
            AssignAttri("", false, "A239AssinaturaStatus", A239AssinaturaStatus);
            A241AssinaturaPublicKey = T00113_A241AssinaturaPublicKey[0];
            n241AssinaturaPublicKey = T00113_n241AssinaturaPublicKey[0];
            AssignAttri("", false, "A241AssinaturaPublicKey", A241AssinaturaPublicKey.ToString());
            A364AssinaturaPaginaConsulta = T00113_A364AssinaturaPaginaConsulta[0];
            n364AssinaturaPaginaConsulta = T00113_n364AssinaturaPaginaConsulta[0];
            AssignAttri("", false, "A364AssinaturaPaginaConsulta", A364AssinaturaPaginaConsulta);
            A365AssinaturaToken = T00113_A365AssinaturaToken[0];
            n365AssinaturaToken = T00113_n365AssinaturaToken[0];
            AssignAttri("", false, "A365AssinaturaToken", A365AssinaturaToken);
            A368AssinaturaMes = T00113_A368AssinaturaMes[0];
            n368AssinaturaMes = T00113_n368AssinaturaMes[0];
            A371AssinaturaMesNome = T00113_A371AssinaturaMesNome[0];
            n371AssinaturaMesNome = T00113_n371AssinaturaMesNome[0];
            A369AssinaturaAno = T00113_A369AssinaturaAno[0];
            n369AssinaturaAno = T00113_n369AssinaturaAno[0];
            A366AssinaturaFinalizadoData = T00113_A366AssinaturaFinalizadoData[0];
            n366AssinaturaFinalizadoData = T00113_n366AssinaturaFinalizadoData[0];
            AssignAttri("", false, "A366AssinaturaFinalizadoData", context.localUtil.TToC( A366AssinaturaFinalizadoData, 8, 5, 0, 3, "/", ":", " "));
            A256AssinaturaArquivoAssinadoExtensao = T00113_A256AssinaturaArquivoAssinadoExtensao[0];
            n256AssinaturaArquivoAssinadoExtensao = T00113_n256AssinaturaArquivoAssinadoExtensao[0];
            AssignAttri("", false, "A256AssinaturaArquivoAssinadoExtensao", A256AssinaturaArquivoAssinadoExtensao);
            edtAssinaturaArquivoAssinado_Filetype = A256AssinaturaArquivoAssinadoExtensao;
            AssignProp("", false, edtAssinaturaArquivoAssinado_Internalname, "Filetype", edtAssinaturaArquivoAssinado_Filetype, true);
            A257AssinaturaArquivoAssinadoNome = T00113_A257AssinaturaArquivoAssinadoNome[0];
            n257AssinaturaArquivoAssinadoNome = T00113_n257AssinaturaArquivoAssinadoNome[0];
            AssignAttri("", false, "A257AssinaturaArquivoAssinadoNome", A257AssinaturaArquivoAssinadoNome);
            edtAssinaturaArquivoAssinado_Filename = A257AssinaturaArquivoAssinadoNome;
            A227ContratoId = T00113_A227ContratoId[0];
            n227ContratoId = T00113_n227ContratoId[0];
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            A231ArquivoId = T00113_A231ArquivoId[0];
            n231ArquivoId = T00113_n231ArquivoId[0];
            AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
            A578ArquivoAssinadoId = T00113_A578ArquivoAssinadoId[0];
            n578ArquivoAssinadoId = T00113_n578ArquivoAssinadoId[0];
            A240AssinaturaArquivoAssinado = T00113_A240AssinaturaArquivoAssinado[0];
            n240AssinaturaArquivoAssinado = T00113_n240AssinaturaArquivoAssinado[0];
            AssignAttri("", false, "A240AssinaturaArquivoAssinado", A240AssinaturaArquivoAssinado);
            AssignProp("", false, edtAssinaturaArquivoAssinado_Internalname, "URL", context.PathToRelativeUrl( A240AssinaturaArquivoAssinado), true);
            Z238AssinaturaId = A238AssinaturaId;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1140( ) ;
            if ( AnyError == 1 )
            {
               RcdFound40 = 0;
               InitializeNonKey1140( ) ;
            }
            Gx_mode = sMode40;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound40 = 0;
            InitializeNonKey1140( ) ;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode40;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1140( ) ;
         if ( RcdFound40 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound40 = 0;
         /* Using cursor T001117 */
         pr_default.execute(12, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T001117_A238AssinaturaId[0] < A238AssinaturaId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T001117_A238AssinaturaId[0] > A238AssinaturaId ) ) )
            {
               A238AssinaturaId = T001117_A238AssinaturaId[0];
               n238AssinaturaId = T001117_n238AssinaturaId[0];
               AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
               RcdFound40 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound40 = 0;
         /* Using cursor T001118 */
         pr_default.execute(13, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T001118_A238AssinaturaId[0] > A238AssinaturaId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T001118_A238AssinaturaId[0] < A238AssinaturaId ) ) )
            {
               A238AssinaturaId = T001118_A238AssinaturaId[0];
               n238AssinaturaId = T001118_n238AssinaturaId[0];
               AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
               RcdFound40 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1140( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbAssinaturaStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1140( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound40 == 1 )
            {
               if ( A238AssinaturaId != Z238AssinaturaId )
               {
                  A238AssinaturaId = Z238AssinaturaId;
                  n238AssinaturaId = false;
                  AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ASSINATURAID");
                  AnyError = 1;
                  GX_FocusControl = edtAssinaturaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbAssinaturaStatus_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1140( ) ;
                  GX_FocusControl = cmbAssinaturaStatus_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A238AssinaturaId != Z238AssinaturaId )
               {
                  /* Insert record */
                  GX_FocusControl = cmbAssinaturaStatus_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1140( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ASSINATURAID");
                     AnyError = 1;
                     GX_FocusControl = edtAssinaturaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbAssinaturaStatus_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1140( ) ;
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
         if ( A238AssinaturaId != Z238AssinaturaId )
         {
            A238AssinaturaId = Z238AssinaturaId;
            n238AssinaturaId = false;
            AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ASSINATURAID");
            AnyError = 1;
            GX_FocusControl = edtAssinaturaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbAssinaturaStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1140( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00112 */
            pr_default.execute(0, new Object[] {n238AssinaturaId, A238AssinaturaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Assinatura"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z239AssinaturaStatus, T00112_A239AssinaturaStatus[0]) != 0 ) || ( Z241AssinaturaPublicKey != T00112_A241AssinaturaPublicKey[0] ) || ( StringUtil.StrCmp(Z364AssinaturaPaginaConsulta, T00112_A364AssinaturaPaginaConsulta[0]) != 0 ) || ( StringUtil.StrCmp(Z365AssinaturaToken, T00112_A365AssinaturaToken[0]) != 0 ) || ( Z368AssinaturaMes != T00112_A368AssinaturaMes[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z371AssinaturaMesNome, T00112_A371AssinaturaMesNome[0]) != 0 ) || ( Z369AssinaturaAno != T00112_A369AssinaturaAno[0] ) || ( Z366AssinaturaFinalizadoData != T00112_A366AssinaturaFinalizadoData[0] ) || ( Z227ContratoId != T00112_A227ContratoId[0] ) || ( Z231ArquivoId != T00112_A231ArquivoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z578ArquivoAssinadoId != T00112_A578ArquivoAssinadoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z239AssinaturaStatus, T00112_A239AssinaturaStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("assinatura:[seudo value changed for attri]"+"AssinaturaStatus");
                  GXUtil.WriteLogRaw("Old: ",Z239AssinaturaStatus);
                  GXUtil.WriteLogRaw("Current: ",T00112_A239AssinaturaStatus[0]);
               }
               if ( Z241AssinaturaPublicKey != T00112_A241AssinaturaPublicKey[0] )
               {
                  GXUtil.WriteLog("assinatura:[seudo value changed for attri]"+"AssinaturaPublicKey");
                  GXUtil.WriteLogRaw("Old: ",Z241AssinaturaPublicKey);
                  GXUtil.WriteLogRaw("Current: ",T00112_A241AssinaturaPublicKey[0]);
               }
               if ( StringUtil.StrCmp(Z364AssinaturaPaginaConsulta, T00112_A364AssinaturaPaginaConsulta[0]) != 0 )
               {
                  GXUtil.WriteLog("assinatura:[seudo value changed for attri]"+"AssinaturaPaginaConsulta");
                  GXUtil.WriteLogRaw("Old: ",Z364AssinaturaPaginaConsulta);
                  GXUtil.WriteLogRaw("Current: ",T00112_A364AssinaturaPaginaConsulta[0]);
               }
               if ( StringUtil.StrCmp(Z365AssinaturaToken, T00112_A365AssinaturaToken[0]) != 0 )
               {
                  GXUtil.WriteLog("assinatura:[seudo value changed for attri]"+"AssinaturaToken");
                  GXUtil.WriteLogRaw("Old: ",Z365AssinaturaToken);
                  GXUtil.WriteLogRaw("Current: ",T00112_A365AssinaturaToken[0]);
               }
               if ( Z368AssinaturaMes != T00112_A368AssinaturaMes[0] )
               {
                  GXUtil.WriteLog("assinatura:[seudo value changed for attri]"+"AssinaturaMes");
                  GXUtil.WriteLogRaw("Old: ",Z368AssinaturaMes);
                  GXUtil.WriteLogRaw("Current: ",T00112_A368AssinaturaMes[0]);
               }
               if ( StringUtil.StrCmp(Z371AssinaturaMesNome, T00112_A371AssinaturaMesNome[0]) != 0 )
               {
                  GXUtil.WriteLog("assinatura:[seudo value changed for attri]"+"AssinaturaMesNome");
                  GXUtil.WriteLogRaw("Old: ",Z371AssinaturaMesNome);
                  GXUtil.WriteLogRaw("Current: ",T00112_A371AssinaturaMesNome[0]);
               }
               if ( Z369AssinaturaAno != T00112_A369AssinaturaAno[0] )
               {
                  GXUtil.WriteLog("assinatura:[seudo value changed for attri]"+"AssinaturaAno");
                  GXUtil.WriteLogRaw("Old: ",Z369AssinaturaAno);
                  GXUtil.WriteLogRaw("Current: ",T00112_A369AssinaturaAno[0]);
               }
               if ( Z366AssinaturaFinalizadoData != T00112_A366AssinaturaFinalizadoData[0] )
               {
                  GXUtil.WriteLog("assinatura:[seudo value changed for attri]"+"AssinaturaFinalizadoData");
                  GXUtil.WriteLogRaw("Old: ",Z366AssinaturaFinalizadoData);
                  GXUtil.WriteLogRaw("Current: ",T00112_A366AssinaturaFinalizadoData[0]);
               }
               if ( Z227ContratoId != T00112_A227ContratoId[0] )
               {
                  GXUtil.WriteLog("assinatura:[seudo value changed for attri]"+"ContratoId");
                  GXUtil.WriteLogRaw("Old: ",Z227ContratoId);
                  GXUtil.WriteLogRaw("Current: ",T00112_A227ContratoId[0]);
               }
               if ( Z231ArquivoId != T00112_A231ArquivoId[0] )
               {
                  GXUtil.WriteLog("assinatura:[seudo value changed for attri]"+"ArquivoId");
                  GXUtil.WriteLogRaw("Old: ",Z231ArquivoId);
                  GXUtil.WriteLogRaw("Current: ",T00112_A231ArquivoId[0]);
               }
               if ( Z578ArquivoAssinadoId != T00112_A578ArquivoAssinadoId[0] )
               {
                  GXUtil.WriteLog("assinatura:[seudo value changed for attri]"+"ArquivoAssinadoId");
                  GXUtil.WriteLogRaw("Old: ",Z578ArquivoAssinadoId);
                  GXUtil.WriteLogRaw("Current: ",T00112_A578ArquivoAssinadoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Assinatura"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1140( )
      {
         BeforeValidate1140( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1140( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1140( 0) ;
            CheckOptimisticConcurrency1140( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1140( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1140( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001119 */
                     A256AssinaturaArquivoAssinadoExtensao = edtAssinaturaArquivoAssinado_Filetype;
                     n256AssinaturaArquivoAssinadoExtensao = false;
                     AssignAttri("", false, "A256AssinaturaArquivoAssinadoExtensao", A256AssinaturaArquivoAssinadoExtensao);
                     A257AssinaturaArquivoAssinadoNome = edtAssinaturaArquivoAssinado_Filename;
                     n257AssinaturaArquivoAssinadoNome = false;
                     AssignAttri("", false, "A257AssinaturaArquivoAssinadoNome", A257AssinaturaArquivoAssinadoNome);
                     pr_default.execute(14, new Object[] {n239AssinaturaStatus, A239AssinaturaStatus, n240AssinaturaArquivoAssinado, A240AssinaturaArquivoAssinado, n241AssinaturaPublicKey, A241AssinaturaPublicKey, n364AssinaturaPaginaConsulta, A364AssinaturaPaginaConsulta, n365AssinaturaToken, A365AssinaturaToken, n368AssinaturaMes, A368AssinaturaMes, n371AssinaturaMesNome, A371AssinaturaMesNome, n369AssinaturaAno, A369AssinaturaAno, n366AssinaturaFinalizadoData, A366AssinaturaFinalizadoData, n256AssinaturaArquivoAssinadoExtensao, A256AssinaturaArquivoAssinadoExtensao, n257AssinaturaArquivoAssinadoNome, A257AssinaturaArquivoAssinadoNome, n227ContratoId, A227ContratoId, n231ArquivoId, A231ArquivoId, n578ArquivoAssinadoId, A578ArquivoAssinadoId});
                     pr_default.close(14);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001120 */
                     pr_default.execute(15);
                     A238AssinaturaId = T001120_A238AssinaturaId[0];
                     n238AssinaturaId = T001120_n238AssinaturaId[0];
                     AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Assinatura");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption110( ) ;
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
               Load1140( ) ;
            }
            EndLevel1140( ) ;
         }
         CloseExtendedTableCursors1140( ) ;
      }

      protected void Update1140( )
      {
         BeforeValidate1140( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1140( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1140( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1140( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1140( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001121 */
                     A256AssinaturaArquivoAssinadoExtensao = edtAssinaturaArquivoAssinado_Filetype;
                     n256AssinaturaArquivoAssinadoExtensao = false;
                     AssignAttri("", false, "A256AssinaturaArquivoAssinadoExtensao", A256AssinaturaArquivoAssinadoExtensao);
                     A257AssinaturaArquivoAssinadoNome = edtAssinaturaArquivoAssinado_Filename;
                     n257AssinaturaArquivoAssinadoNome = false;
                     AssignAttri("", false, "A257AssinaturaArquivoAssinadoNome", A257AssinaturaArquivoAssinadoNome);
                     pr_default.execute(16, new Object[] {n239AssinaturaStatus, A239AssinaturaStatus, n241AssinaturaPublicKey, A241AssinaturaPublicKey, n364AssinaturaPaginaConsulta, A364AssinaturaPaginaConsulta, n365AssinaturaToken, A365AssinaturaToken, n368AssinaturaMes, A368AssinaturaMes, n371AssinaturaMesNome, A371AssinaturaMesNome, n369AssinaturaAno, A369AssinaturaAno, n366AssinaturaFinalizadoData, A366AssinaturaFinalizadoData, n256AssinaturaArquivoAssinadoExtensao, A256AssinaturaArquivoAssinadoExtensao, n257AssinaturaArquivoAssinadoNome, A257AssinaturaArquivoAssinadoNome, n227ContratoId, A227ContratoId, n231ArquivoId, A231ArquivoId, n578ArquivoAssinadoId, A578ArquivoAssinadoId, n238AssinaturaId, A238AssinaturaId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Assinatura");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Assinatura"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1140( ) ;
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
            EndLevel1140( ) ;
         }
         CloseExtendedTableCursors1140( ) ;
      }

      protected void DeferredUpdate1140( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001122 */
            pr_default.execute(17, new Object[] {n240AssinaturaArquivoAssinado, A240AssinaturaArquivoAssinado, n238AssinaturaId, A238AssinaturaId});
            pr_default.close(17);
            pr_default.SmartCacheProvider.SetUpdated("Assinatura");
         }
      }

      protected void delete( )
      {
         BeforeValidate1140( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1140( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1140( ) ;
            AfterConfirm1140( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1140( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001123 */
                  pr_default.execute(18, new Object[] {n238AssinaturaId, A238AssinaturaId});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("Assinatura");
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
         sMode40 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1140( ) ;
         Gx_mode = sMode40;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1140( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001125 */
            pr_default.execute(19, new Object[] {n238AssinaturaId, A238AssinaturaId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A367AssinaturaParticipantes_F = T001125_A367AssinaturaParticipantes_F[0];
               n367AssinaturaParticipantes_F = T001125_n367AssinaturaParticipantes_F[0];
               AssignAttri("", false, "A367AssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(A367AssinaturaParticipantes_F), 4, 0));
            }
            else
            {
               A367AssinaturaParticipantes_F = 0;
               n367AssinaturaParticipantes_F = false;
               AssignAttri("", false, "A367AssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(A367AssinaturaParticipantes_F), 4, 0));
            }
            pr_default.close(19);
            /* Using cursor T001126 */
            pr_default.execute(20, new Object[] {n227ContratoId, A227ContratoId});
            A228ContratoNome = T001126_A228ContratoNome[0];
            n228ContratoNome = T001126_n228ContratoNome[0];
            A362ContratoDataInicial = T001126_A362ContratoDataInicial[0];
            n362ContratoDataInicial = T001126_n362ContratoDataInicial[0];
            A363ContratoDataFinal = T001126_A363ContratoDataFinal[0];
            n363ContratoDataFinal = T001126_n363ContratoDataFinal[0];
            pr_default.close(20);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001127 */
            pr_default.execute(21, new Object[] {n238AssinaturaId, A238AssinaturaId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaContratoAssinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T001128 */
            pr_default.execute(22, new Object[] {n238AssinaturaId, A238AssinaturaId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"AssinaturaParticipante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
         }
      }

      protected void EndLevel1140( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1140( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues110( ) ;
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

      public void ScanStart1140( )
      {
         /* Scan By routine */
         /* Using cursor T001129 */
         pr_default.execute(23);
         RcdFound40 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound40 = 1;
            A238AssinaturaId = T001129_A238AssinaturaId[0];
            n238AssinaturaId = T001129_n238AssinaturaId[0];
            AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1140( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound40 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound40 = 1;
            A238AssinaturaId = T001129_A238AssinaturaId[0];
            n238AssinaturaId = T001129_n238AssinaturaId[0];
            AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
         }
      }

      protected void ScanEnd1140( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm1140( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1140( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1140( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1140( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1140( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1140( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1140( )
      {
         edtAssinaturaId_Enabled = 0;
         AssignProp("", false, edtAssinaturaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaId_Enabled), 5, 0), true);
         cmbAssinaturaStatus.Enabled = 0;
         AssignProp("", false, cmbAssinaturaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAssinaturaStatus.Enabled), 5, 0), true);
         edtContratoId_Enabled = 0;
         AssignProp("", false, edtContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoId_Enabled), 5, 0), true);
         edtArquivoId_Enabled = 0;
         AssignProp("", false, edtArquivoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtArquivoId_Enabled), 5, 0), true);
         edtAssinaturaArquivoAssinado_Enabled = 0;
         AssignProp("", false, edtAssinaturaArquivoAssinado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaArquivoAssinado_Enabled), 5, 0), true);
         edtAssinaturaPublicKey_Enabled = 0;
         AssignProp("", false, edtAssinaturaPublicKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaPublicKey_Enabled), 5, 0), true);
         edtAssinaturaPaginaConsulta_Enabled = 0;
         AssignProp("", false, edtAssinaturaPaginaConsulta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaPaginaConsulta_Enabled), 5, 0), true);
         edtAssinaturaToken_Enabled = 0;
         AssignProp("", false, edtAssinaturaToken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaToken_Enabled), 5, 0), true);
         edtAssinaturaFinalizadoData_Enabled = 0;
         AssignProp("", false, edtAssinaturaFinalizadoData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaFinalizadoData_Enabled), 5, 0), true);
         edtAssinaturaParticipantes_F_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipantes_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipantes_F_Enabled), 5, 0), true);
         edtavCombocontratoid_Enabled = 0;
         AssignProp("", false, edtavCombocontratoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocontratoid_Enabled), 5, 0), true);
         edtavComboarquivoid_Enabled = 0;
         AssignProp("", false, edtavComboarquivoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboarquivoid_Enabled), 5, 0), true);
         edtAssinaturaArquivoAssinadoNome_Enabled = 0;
         AssignProp("", false, edtAssinaturaArquivoAssinadoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaArquivoAssinadoNome_Enabled), 5, 0), true);
         edtAssinaturaArquivoAssinadoExtensao_Enabled = 0;
         AssignProp("", false, edtAssinaturaArquivoAssinadoExtensao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaArquivoAssinadoExtensao_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1140( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues110( )
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
         GXEncryptionTmp = "assinatura"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AssinaturaId,10,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("assinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Assinatura");
         forbiddenHiddens.Add("AssinaturaId", context.localUtil.Format( (decimal)(A238AssinaturaId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ContratoId", context.localUtil.Format( (decimal)(AV11Insert_ContratoId), "ZZZZZ9"));
         forbiddenHiddens.Add("Insert_ArquivoId", context.localUtil.Format( (decimal)(AV12Insert_ArquivoId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ArquivoAssinadoId", context.localUtil.Format( (decimal)(AV22Insert_ArquivoAssinadoId), "ZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("AssinaturaMes", context.localUtil.Format( (decimal)(A368AssinaturaMes), "ZZZ9"));
         forbiddenHiddens.Add("AssinaturaMesNome", StringUtil.RTrim( context.localUtil.Format( A371AssinaturaMesNome, "")));
         forbiddenHiddens.Add("AssinaturaAno", context.localUtil.Format( (decimal)(A369AssinaturaAno), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("assinatura:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z238AssinaturaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z238AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z239AssinaturaStatus", Z239AssinaturaStatus);
         GxWebStd.gx_hidden_field( context, "Z241AssinaturaPublicKey", Z241AssinaturaPublicKey.ToString());
         GxWebStd.gx_hidden_field( context, "Z364AssinaturaPaginaConsulta", Z364AssinaturaPaginaConsulta);
         GxWebStd.gx_hidden_field( context, "Z365AssinaturaToken", Z365AssinaturaToken);
         GxWebStd.gx_hidden_field( context, "Z368AssinaturaMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z368AssinaturaMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z371AssinaturaMesNome", Z371AssinaturaMesNome);
         GxWebStd.gx_hidden_field( context, "Z369AssinaturaAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z369AssinaturaAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z366AssinaturaFinalizadoData", context.localUtil.TToC( Z366AssinaturaFinalizadoData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z227ContratoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z227ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z231ArquivoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z231ArquivoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z578ArquivoAssinadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z578ArquivoAssinadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N227ContratoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N231ArquivoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N578ArquivoAssinadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A578ArquivoAssinadoId), 8, 0, ",", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTRATOID_DATA", AV14ContratoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTRATOID_DATA", AV14ContratoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARQUIVOID_DATA", AV20ArquivoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARQUIVOID_DATA", AV20ArquivoId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AssinaturaId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ARQUIVOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_ArquivoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ARQUIVOASSINADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Insert_ArquivoAssinadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ARQUIVOASSINADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A578ArquivoAssinadoId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ASSINATURAMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A368AssinaturaMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ASSINATURAMESNOME", A371AssinaturaMesNome);
         GxWebStd.gx_hidden_field( context, "ASSINATURAANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A369AssinaturaAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATONOME", A228ContratoNome);
         GxWebStd.gx_hidden_field( context, "CONTRATODATAINICIAL", context.localUtil.DToC( A362ContratoDataInicial, 0, "/"));
         GxWebStd.gx_hidden_field( context, "CONTRATODATAFINAL", context.localUtil.DToC( A363ContratoDataFinal, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
         GXCCtlgxBlob = "ASSINATURAARQUIVOASSINADO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A240AssinaturaArquivoAssinado);
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Objectcall", StringUtil.RTrim( Combo_contratoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Cls", StringUtil.RTrim( Combo_contratoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Selectedvalue_set", StringUtil.RTrim( Combo_contratoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Selectedtext_set", StringUtil.RTrim( Combo_contratoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Enabled", StringUtil.BoolToStr( Combo_contratoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Datalistproc", StringUtil.RTrim( Combo_contratoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_contratoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_ARQUIVOID_Objectcall", StringUtil.RTrim( Combo_arquivoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ARQUIVOID_Cls", StringUtil.RTrim( Combo_arquivoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ARQUIVOID_Selectedvalue_set", StringUtil.RTrim( Combo_arquivoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ARQUIVOID_Selectedtext_set", StringUtil.RTrim( Combo_arquivoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ARQUIVOID_Enabled", StringUtil.BoolToStr( Combo_arquivoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ARQUIVOID_Datalistproc", StringUtil.RTrim( Combo_arquivoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ARQUIVOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_arquivoid_Datalistprocparametersprefix));
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
         GxWebStd.gx_hidden_field( context, "ASSINATURAARQUIVOASSINADO_Filetype", StringUtil.RTrim( edtAssinaturaArquivoAssinado_Filetype));
         GxWebStd.gx_hidden_field( context, "ASSINATURAARQUIVOASSINADO_Filename", StringUtil.RTrim( edtAssinaturaArquivoAssinado_Filename));
         GxWebStd.gx_hidden_field( context, "ASSINATURAARQUIVOASSINADO_Filename", StringUtil.RTrim( edtAssinaturaArquivoAssinado_Filename));
         GxWebStd.gx_hidden_field( context, "ASSINATURAARQUIVOASSINADO_Filetype", StringUtil.RTrim( edtAssinaturaArquivoAssinado_Filetype));
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
         GXEncryptionTmp = "assinatura"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AssinaturaId,10,0));
         return formatLink("assinatura") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Assinatura" ;
      }

      public override string GetPgmdesc( )
      {
         return "Assinatura" ;
      }

      protected void InitializeNonKey1140( )
      {
         A227ContratoId = 0;
         n227ContratoId = false;
         AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
         n227ContratoId = ((0==A227ContratoId) ? true : false);
         A231ArquivoId = 0;
         n231ArquivoId = false;
         AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
         n231ArquivoId = ((0==A231ArquivoId) ? true : false);
         A578ArquivoAssinadoId = 0;
         n578ArquivoAssinadoId = false;
         AssignAttri("", false, "A578ArquivoAssinadoId", ((0==A578ArquivoAssinadoId)&&IsIns( )||n578ArquivoAssinadoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A578ArquivoAssinadoId), 8, 0, ".", ""))));
         A239AssinaturaStatus = "";
         n239AssinaturaStatus = false;
         AssignAttri("", false, "A239AssinaturaStatus", A239AssinaturaStatus);
         n239AssinaturaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A239AssinaturaStatus)) ? true : false);
         A228ContratoNome = "";
         n228ContratoNome = false;
         AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
         A362ContratoDataInicial = DateTime.MinValue;
         n362ContratoDataInicial = false;
         AssignAttri("", false, "A362ContratoDataInicial", context.localUtil.Format(A362ContratoDataInicial, "99/99/99"));
         A363ContratoDataFinal = DateTime.MinValue;
         n363ContratoDataFinal = false;
         AssignAttri("", false, "A363ContratoDataFinal", context.localUtil.Format(A363ContratoDataFinal, "99/99/99"));
         A240AssinaturaArquivoAssinado = "";
         n240AssinaturaArquivoAssinado = false;
         AssignAttri("", false, "A240AssinaturaArquivoAssinado", A240AssinaturaArquivoAssinado);
         AssignProp("", false, edtAssinaturaArquivoAssinado_Internalname, "URL", context.PathToRelativeUrl( A240AssinaturaArquivoAssinado), true);
         n240AssinaturaArquivoAssinado = (String.IsNullOrEmpty(StringUtil.RTrim( A240AssinaturaArquivoAssinado)) ? true : false);
         A364AssinaturaPaginaConsulta = "";
         n364AssinaturaPaginaConsulta = false;
         AssignAttri("", false, "A364AssinaturaPaginaConsulta", A364AssinaturaPaginaConsulta);
         n364AssinaturaPaginaConsulta = (String.IsNullOrEmpty(StringUtil.RTrim( A364AssinaturaPaginaConsulta)) ? true : false);
         A365AssinaturaToken = "";
         n365AssinaturaToken = false;
         AssignAttri("", false, "A365AssinaturaToken", A365AssinaturaToken);
         n365AssinaturaToken = (String.IsNullOrEmpty(StringUtil.RTrim( A365AssinaturaToken)) ? true : false);
         A368AssinaturaMes = 0;
         n368AssinaturaMes = false;
         AssignAttri("", false, "A368AssinaturaMes", ((0==A368AssinaturaMes)&&IsIns( )||n368AssinaturaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A368AssinaturaMes), 4, 0, ".", ""))));
         A371AssinaturaMesNome = "";
         n371AssinaturaMesNome = false;
         AssignAttri("", false, "A371AssinaturaMesNome", A371AssinaturaMesNome);
         A369AssinaturaAno = 0;
         n369AssinaturaAno = false;
         AssignAttri("", false, "A369AssinaturaAno", ((0==A369AssinaturaAno)&&IsIns( )||n369AssinaturaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A369AssinaturaAno), 4, 0, ".", ""))));
         A366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         n366AssinaturaFinalizadoData = false;
         AssignAttri("", false, "A366AssinaturaFinalizadoData", context.localUtil.TToC( A366AssinaturaFinalizadoData, 8, 5, 0, 3, "/", ":", " "));
         n366AssinaturaFinalizadoData = ((DateTime.MinValue==A366AssinaturaFinalizadoData) ? true : false);
         A367AssinaturaParticipantes_F = 0;
         n367AssinaturaParticipantes_F = false;
         AssignAttri("", false, "A367AssinaturaParticipantes_F", StringUtil.LTrimStr( (decimal)(A367AssinaturaParticipantes_F), 4, 0));
         A256AssinaturaArquivoAssinadoExtensao = "";
         n256AssinaturaArquivoAssinadoExtensao = false;
         AssignAttri("", false, "A256AssinaturaArquivoAssinadoExtensao", A256AssinaturaArquivoAssinadoExtensao);
         n256AssinaturaArquivoAssinadoExtensao = (String.IsNullOrEmpty(StringUtil.RTrim( A256AssinaturaArquivoAssinadoExtensao)) ? true : false);
         A257AssinaturaArquivoAssinadoNome = "";
         n257AssinaturaArquivoAssinadoNome = false;
         AssignAttri("", false, "A257AssinaturaArquivoAssinadoNome", A257AssinaturaArquivoAssinadoNome);
         n257AssinaturaArquivoAssinadoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A257AssinaturaArquivoAssinadoNome)) ? true : false);
         A241AssinaturaPublicKey = Guid.NewGuid( );
         n241AssinaturaPublicKey = false;
         AssignAttri("", false, "A241AssinaturaPublicKey", A241AssinaturaPublicKey.ToString());
         Z239AssinaturaStatus = "";
         Z241AssinaturaPublicKey = Guid.Empty;
         Z364AssinaturaPaginaConsulta = "";
         Z365AssinaturaToken = "";
         Z368AssinaturaMes = 0;
         Z371AssinaturaMesNome = "";
         Z369AssinaturaAno = 0;
         Z366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         Z227ContratoId = 0;
         Z231ArquivoId = 0;
         Z578ArquivoAssinadoId = 0;
      }

      protected void InitAll1140( )
      {
         A238AssinaturaId = 0;
         n238AssinaturaId = false;
         AssignAttri("", false, "A238AssinaturaId", StringUtil.LTrimStr( (decimal)(A238AssinaturaId), 10, 0));
         InitializeNonKey1140( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A241AssinaturaPublicKey = i241AssinaturaPublicKey;
         n241AssinaturaPublicKey = false;
         AssignAttri("", false, "A241AssinaturaPublicKey", A241AssinaturaPublicKey.ToString());
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101914613", true, true);
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
         context.AddJavascriptSource("assinatura.js", "?20256101914613", false, true);
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
         edtAssinaturaId_Internalname = "ASSINATURAID";
         cmbAssinaturaStatus_Internalname = "ASSINATURASTATUS";
         lblTextblockcontratoid_Internalname = "TEXTBLOCKCONTRATOID";
         Combo_contratoid_Internalname = "COMBO_CONTRATOID";
         edtContratoId_Internalname = "CONTRATOID";
         divTablesplittedcontratoid_Internalname = "TABLESPLITTEDCONTRATOID";
         lblTextblockarquivoid_Internalname = "TEXTBLOCKARQUIVOID";
         Combo_arquivoid_Internalname = "COMBO_ARQUIVOID";
         edtArquivoId_Internalname = "ARQUIVOID";
         divTablesplittedarquivoid_Internalname = "TABLESPLITTEDARQUIVOID";
         edtAssinaturaArquivoAssinado_Internalname = "ASSINATURAARQUIVOASSINADO";
         edtAssinaturaPublicKey_Internalname = "ASSINATURAPUBLICKEY";
         edtAssinaturaPaginaConsulta_Internalname = "ASSINATURAPAGINACONSULTA";
         edtAssinaturaToken_Internalname = "ASSINATURATOKEN";
         edtAssinaturaFinalizadoData_Internalname = "ASSINATURAFINALIZADODATA";
         edtAssinaturaParticipantes_F_Internalname = "ASSINATURAPARTICIPANTES_F";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocontratoid_Internalname = "vCOMBOCONTRATOID";
         divSectionattribute_contratoid_Internalname = "SECTIONATTRIBUTE_CONTRATOID";
         edtavComboarquivoid_Internalname = "vCOMBOARQUIVOID";
         divSectionattribute_arquivoid_Internalname = "SECTIONATTRIBUTE_ARQUIVOID";
         edtAssinaturaArquivoAssinadoNome_Internalname = "ASSINATURAARQUIVOASSINADONOME";
         edtAssinaturaArquivoAssinadoExtensao_Internalname = "ASSINATURAARQUIVOASSINADOEXTENSAO";
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
         Form.Caption = "Assinatura";
         edtAssinaturaArquivoAssinado_Filename = "";
         edtAssinaturaArquivoAssinadoExtensao_Jsonclick = "";
         edtAssinaturaArquivoAssinadoExtensao_Enabled = 1;
         edtAssinaturaArquivoAssinadoExtensao_Visible = 1;
         edtAssinaturaArquivoAssinadoNome_Jsonclick = "";
         edtAssinaturaArquivoAssinadoNome_Enabled = 1;
         edtAssinaturaArquivoAssinadoNome_Visible = 1;
         edtavComboarquivoid_Jsonclick = "";
         edtavComboarquivoid_Enabled = 0;
         edtavComboarquivoid_Visible = 1;
         edtavCombocontratoid_Jsonclick = "";
         edtavCombocontratoid_Enabled = 0;
         edtavCombocontratoid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtAssinaturaParticipantes_F_Jsonclick = "";
         edtAssinaturaParticipantes_F_Enabled = 0;
         edtAssinaturaFinalizadoData_Jsonclick = "";
         edtAssinaturaFinalizadoData_Enabled = 1;
         edtAssinaturaToken_Enabled = 1;
         edtAssinaturaPaginaConsulta_Jsonclick = "";
         edtAssinaturaPaginaConsulta_Enabled = 1;
         edtAssinaturaPublicKey_Jsonclick = "";
         edtAssinaturaPublicKey_Enabled = 1;
         edtAssinaturaArquivoAssinado_Jsonclick = "";
         edtAssinaturaArquivoAssinado_Parameters = "";
         edtAssinaturaArquivoAssinado_Contenttype = "";
         edtAssinaturaArquivoAssinado_Filetype = "";
         edtAssinaturaArquivoAssinado_Enabled = 1;
         edtArquivoId_Jsonclick = "";
         edtArquivoId_Enabled = 1;
         edtArquivoId_Visible = 1;
         Combo_arquivoid_Datalistprocparametersprefix = " \"ComboName\": \"ArquivoId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"AssinaturaId\": 0";
         Combo_arquivoid_Datalistproc = "AssinaturaLoadDVCombo";
         Combo_arquivoid_Cls = "ExtendedCombo AttributeFL";
         Combo_arquivoid_Caption = "";
         Combo_arquivoid_Enabled = Convert.ToBoolean( -1);
         edtContratoId_Jsonclick = "";
         edtContratoId_Enabled = 1;
         edtContratoId_Visible = 1;
         Combo_contratoid_Datalistprocparametersprefix = " \"ComboName\": \"ContratoId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"AssinaturaId\": 0";
         Combo_contratoid_Datalistproc = "AssinaturaLoadDVCombo";
         Combo_contratoid_Cls = "ExtendedCombo AttributeFL";
         Combo_contratoid_Caption = "";
         Combo_contratoid_Enabled = Convert.ToBoolean( -1);
         cmbAssinaturaStatus_Jsonclick = "";
         cmbAssinaturaStatus.Enabled = 1;
         edtAssinaturaId_Jsonclick = "";
         edtAssinaturaId_Enabled = 0;
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
         cmbAssinaturaStatus.Name = "ASSINATURASTATUS";
         cmbAssinaturaStatus.WebTags = "";
         cmbAssinaturaStatus.addItem("ENVIADO", "Enviado", 0);
         cmbAssinaturaStatus.addItem("REJEITADO", "Rejeitado", 0);
         cmbAssinaturaStatus.addItem("CANCELADO", "Cancelado", 0);
         cmbAssinaturaStatus.addItem("ASSINADO", "Assinado", 0);
         cmbAssinaturaStatus.addItem("AGUARDANDO_ENVIO", "Aguardando envio", 0);
         if ( cmbAssinaturaStatus.ItemCount > 0 )
         {
            A239AssinaturaStatus = cmbAssinaturaStatus.getValidValue(A239AssinaturaStatus);
            n239AssinaturaStatus = false;
            AssignAttri("", false, "A239AssinaturaStatus", A239AssinaturaStatus);
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

      public void Valid_Assinaturaid( )
      {
         n238AssinaturaId = false;
         n367AssinaturaParticipantes_F = false;
         /* Using cursor T001125 */
         pr_default.execute(19, new Object[] {n238AssinaturaId, A238AssinaturaId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A367AssinaturaParticipantes_F = T001125_A367AssinaturaParticipantes_F[0];
            n367AssinaturaParticipantes_F = T001125_n367AssinaturaParticipantes_F[0];
         }
         else
         {
            A367AssinaturaParticipantes_F = 0;
            n367AssinaturaParticipantes_F = false;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A367AssinaturaParticipantes_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A367AssinaturaParticipantes_F), 4, 0, ".", "")));
      }

      public void Valid_Contratoid( )
      {
         n228ContratoNome = false;
         n362ContratoDataInicial = false;
         n363ContratoDataFinal = false;
         /* Using cursor T001126 */
         pr_default.execute(20, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
            }
         }
         A228ContratoNome = T001126_A228ContratoNome[0];
         n228ContratoNome = T001126_n228ContratoNome[0];
         A362ContratoDataInicial = T001126_A362ContratoDataInicial[0];
         n362ContratoDataInicial = T001126_n362ContratoDataInicial[0];
         A363ContratoDataFinal = T001126_A363ContratoDataFinal[0];
         n363ContratoDataFinal = T001126_n363ContratoDataFinal[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
         AssignAttri("", false, "A362ContratoDataInicial", context.localUtil.Format(A362ContratoDataInicial, "99/99/99"));
         AssignAttri("", false, "A363ContratoDataFinal", context.localUtil.Format(A363ContratoDataFinal, "99/99/99"));
      }

      public void Valid_Arquivoid( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ArquivoId) )
         {
            A231ArquivoId = AV12Insert_ArquivoId;
            n231ArquivoId = false;
         }
         else
         {
            if ( (0==AV21ComboArquivoId) )
            {
               A231ArquivoId = 0;
               n231ArquivoId = false;
               n231ArquivoId = true;
               n231ArquivoId = true;
            }
            else
            {
               if ( ! (0==AV21ComboArquivoId) )
               {
                  A231ArquivoId = AV21ComboArquivoId;
                  n231ArquivoId = false;
               }
               else
               {
                  if ( (0==A231ArquivoId) )
                  {
                     A231ArquivoId = 0;
                     n231ArquivoId = false;
                     n231ArquivoId = true;
                     n231ArquivoId = true;
                  }
               }
            }
         }
         /* Using cursor T001130 */
         pr_default.execute(24, new Object[] {n231ArquivoId, A231ArquivoId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A231ArquivoId) ) )
            {
               GX_msglist.addItem("Não existe 'Arquivo'.", "ForeignKeyNotFound", 1, "ARQUIVOID");
               AnyError = 1;
               GX_FocusControl = edtArquivoId_Internalname;
            }
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A231ArquivoId", ((0==A231ArquivoId)&&IsIns( )||n231ArquivoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A231ArquivoId), 8, 0, ".", ""))));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV11Insert_ContratoId","fld":"vINSERT_CONTRATOID","pic":"ZZZZZ9","type":"int"},{"av":"AV12Insert_ArquivoId","fld":"vINSERT_ARQUIVOID","pic":"ZZZZZZZ9","type":"int"},{"av":"AV22Insert_ArquivoAssinadoId","fld":"vINSERT_ARQUIVOASSINADOID","pic":"ZZZZZZZ9","type":"int"},{"av":"A368AssinaturaMes","fld":"ASSINATURAMES","pic":"ZZZ9","nullAv":"n368AssinaturaMes","type":"int"},{"av":"A371AssinaturaMesNome","fld":"ASSINATURAMESNOME","type":"svchar"},{"av":"A369AssinaturaAno","fld":"ASSINATURAANO","pic":"ZZZ9","nullAv":"n369AssinaturaAno","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12112","iparms":[]}""");
         setEventMetadata("VALID_ASSINATURAID","""{"handler":"Valid_Assinaturaid","iparms":[{"av":"A238AssinaturaId","fld":"ASSINATURAID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"A367AssinaturaParticipantes_F","fld":"ASSINATURAPARTICIPANTES_F","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("VALID_ASSINATURAID",""","oparms":[{"av":"A367AssinaturaParticipantes_F","fld":"ASSINATURAPARTICIPANTES_F","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("VALID_ASSINATURASTATUS","""{"handler":"Valid_Assinaturastatus","iparms":[]}""");
         setEventMetadata("VALID_CONTRATOID","""{"handler":"Valid_Contratoid","iparms":[{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","nullAv":"n227ContratoId","type":"int"},{"av":"A228ContratoNome","fld":"CONTRATONOME","type":"svchar"},{"av":"A362ContratoDataInicial","fld":"CONTRATODATAINICIAL","type":"date"},{"av":"A363ContratoDataFinal","fld":"CONTRATODATAFINAL","type":"date"}]""");
         setEventMetadata("VALID_CONTRATOID",""","oparms":[{"av":"A228ContratoNome","fld":"CONTRATONOME","type":"svchar"},{"av":"A362ContratoDataInicial","fld":"CONTRATODATAINICIAL","type":"date"},{"av":"A363ContratoDataFinal","fld":"CONTRATODATAFINAL","type":"date"}]}""");
         setEventMetadata("VALID_ARQUIVOID","""{"handler":"Valid_Arquivoid","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV12Insert_ArquivoId","fld":"vINSERT_ARQUIVOID","pic":"ZZZZZZZ9","type":"int"},{"av":"AV21ComboArquivoId","fld":"vCOMBOARQUIVOID","pic":"ZZZZZZZ9","type":"int"},{"av":"A231ArquivoId","fld":"ARQUIVOID","pic":"ZZZZZZZ9","nullAv":"n231ArquivoId","type":"int"}]""");
         setEventMetadata("VALID_ARQUIVOID",""","oparms":[{"av":"A231ArquivoId","fld":"ARQUIVOID","pic":"ZZZZZZZ9","nullAv":"n231ArquivoId","type":"int"}]}""");
         setEventMetadata("VALID_ASSINATURAPUBLICKEY","""{"handler":"Valid_Assinaturapublickey","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOCONTRATOID","""{"handler":"Validv_Combocontratoid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOARQUIVOID","""{"handler":"Validv_Comboarquivoid","iparms":[]}""");
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
         pr_default.close(20);
         pr_default.close(24);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z239AssinaturaStatus = "";
         Z241AssinaturaPublicKey = Guid.Empty;
         Z364AssinaturaPaginaConsulta = "";
         Z365AssinaturaToken = "";
         Z371AssinaturaMesNome = "";
         Z366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         Combo_arquivoid_Selectedvalue_get = "";
         Combo_contratoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A239AssinaturaStatus = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblockcontratoid_Jsonclick = "";
         ucCombo_contratoid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14ContratoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockarquivoid_Jsonclick = "";
         ucCombo_arquivoid = new GXUserControl();
         AV20ArquivoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A257AssinaturaArquivoAssinadoNome = "";
         A256AssinaturaArquivoAssinadoExtensao = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         A240AssinaturaArquivoAssinado = "";
         A241AssinaturaPublicKey = Guid.Empty;
         A364AssinaturaPaginaConsulta = "";
         A365AssinaturaToken = "";
         A366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A371AssinaturaMesNome = "";
         A228ContratoNome = "";
         A362ContratoDataInicial = DateTime.MinValue;
         A363ContratoDataFinal = DateTime.MinValue;
         AV23Pgmname = "";
         Combo_contratoid_Objectcall = "";
         Combo_contratoid_Class = "";
         Combo_contratoid_Icontype = "";
         Combo_contratoid_Icon = "";
         Combo_contratoid_Tooltip = "";
         Combo_contratoid_Selectedvalue_set = "";
         Combo_contratoid_Selectedtext_set = "";
         Combo_contratoid_Selectedtext_get = "";
         Combo_contratoid_Gamoauthtoken = "";
         Combo_contratoid_Ddointernalname = "";
         Combo_contratoid_Titlecontrolalign = "";
         Combo_contratoid_Dropdownoptionstype = "";
         Combo_contratoid_Titlecontrolidtoreplace = "";
         Combo_contratoid_Datalisttype = "";
         Combo_contratoid_Datalistfixedvalues = "";
         Combo_contratoid_Remoteservicesparameters = "";
         Combo_contratoid_Htmltemplate = "";
         Combo_contratoid_Multiplevaluestype = "";
         Combo_contratoid_Loadingdata = "";
         Combo_contratoid_Noresultsfound = "";
         Combo_contratoid_Emptyitemtext = "";
         Combo_contratoid_Onlyselectedvalues = "";
         Combo_contratoid_Selectalltext = "";
         Combo_contratoid_Multiplevaluesseparator = "";
         Combo_contratoid_Addnewoptiontext = "";
         Combo_arquivoid_Objectcall = "";
         Combo_arquivoid_Class = "";
         Combo_arquivoid_Icontype = "";
         Combo_arquivoid_Icon = "";
         Combo_arquivoid_Tooltip = "";
         Combo_arquivoid_Selectedvalue_set = "";
         Combo_arquivoid_Selectedtext_set = "";
         Combo_arquivoid_Selectedtext_get = "";
         Combo_arquivoid_Gamoauthtoken = "";
         Combo_arquivoid_Ddointernalname = "";
         Combo_arquivoid_Titlecontrolalign = "";
         Combo_arquivoid_Dropdownoptionstype = "";
         Combo_arquivoid_Titlecontrolidtoreplace = "";
         Combo_arquivoid_Datalisttype = "";
         Combo_arquivoid_Datalistfixedvalues = "";
         Combo_arquivoid_Remoteservicesparameters = "";
         Combo_arquivoid_Htmltemplate = "";
         Combo_arquivoid_Multiplevaluestype = "";
         Combo_arquivoid_Loadingdata = "";
         Combo_arquivoid_Noresultsfound = "";
         Combo_arquivoid_Emptyitemtext = "";
         Combo_arquivoid_Onlyselectedvalues = "";
         Combo_arquivoid_Selectalltext = "";
         Combo_arquivoid_Multiplevaluesseparator = "";
         Combo_arquivoid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         GXCCtlgxBlob = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode40 = "";
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
         Z240AssinaturaArquivoAssinado = "";
         Z256AssinaturaArquivoAssinadoExtensao = "";
         Z257AssinaturaArquivoAssinadoNome = "";
         Z228ContratoNome = "";
         Z362ContratoDataInicial = DateTime.MinValue;
         Z363ContratoDataFinal = DateTime.MinValue;
         T00118_A367AssinaturaParticipantes_F = new short[1] ;
         T00118_n367AssinaturaParticipantes_F = new bool[] {false} ;
         T00114_A228ContratoNome = new string[] {""} ;
         T00114_n228ContratoNome = new bool[] {false} ;
         T00114_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         T00114_n362ContratoDataInicial = new bool[] {false} ;
         T00114_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         T00114_n363ContratoDataFinal = new bool[] {false} ;
         T001110_A238AssinaturaId = new long[1] ;
         T001110_n238AssinaturaId = new bool[] {false} ;
         T001110_A239AssinaturaStatus = new string[] {""} ;
         T001110_n239AssinaturaStatus = new bool[] {false} ;
         T001110_A228ContratoNome = new string[] {""} ;
         T001110_n228ContratoNome = new bool[] {false} ;
         T001110_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         T001110_n362ContratoDataInicial = new bool[] {false} ;
         T001110_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         T001110_n363ContratoDataFinal = new bool[] {false} ;
         T001110_A241AssinaturaPublicKey = new Guid[] {Guid.Empty} ;
         T001110_n241AssinaturaPublicKey = new bool[] {false} ;
         T001110_A364AssinaturaPaginaConsulta = new string[] {""} ;
         T001110_n364AssinaturaPaginaConsulta = new bool[] {false} ;
         T001110_A365AssinaturaToken = new string[] {""} ;
         T001110_n365AssinaturaToken = new bool[] {false} ;
         T001110_A368AssinaturaMes = new short[1] ;
         T001110_n368AssinaturaMes = new bool[] {false} ;
         T001110_A371AssinaturaMesNome = new string[] {""} ;
         T001110_n371AssinaturaMesNome = new bool[] {false} ;
         T001110_A369AssinaturaAno = new short[1] ;
         T001110_n369AssinaturaAno = new bool[] {false} ;
         T001110_A366AssinaturaFinalizadoData = new DateTime[] {DateTime.MinValue} ;
         T001110_n366AssinaturaFinalizadoData = new bool[] {false} ;
         T001110_A256AssinaturaArquivoAssinadoExtensao = new string[] {""} ;
         T001110_n256AssinaturaArquivoAssinadoExtensao = new bool[] {false} ;
         T001110_A257AssinaturaArquivoAssinadoNome = new string[] {""} ;
         T001110_n257AssinaturaArquivoAssinadoNome = new bool[] {false} ;
         T001110_A227ContratoId = new int[1] ;
         T001110_n227ContratoId = new bool[] {false} ;
         T001110_A231ArquivoId = new int[1] ;
         T001110_n231ArquivoId = new bool[] {false} ;
         T001110_A578ArquivoAssinadoId = new int[1] ;
         T001110_n578ArquivoAssinadoId = new bool[] {false} ;
         T001110_A367AssinaturaParticipantes_F = new short[1] ;
         T001110_n367AssinaturaParticipantes_F = new bool[] {false} ;
         T001110_A240AssinaturaArquivoAssinado = new string[] {""} ;
         T001110_n240AssinaturaArquivoAssinado = new bool[] {false} ;
         T00115_A231ArquivoId = new int[1] ;
         T00115_n231ArquivoId = new bool[] {false} ;
         T00116_A578ArquivoAssinadoId = new int[1] ;
         T00116_n578ArquivoAssinadoId = new bool[] {false} ;
         T001112_A367AssinaturaParticipantes_F = new short[1] ;
         T001112_n367AssinaturaParticipantes_F = new bool[] {false} ;
         T001113_A228ContratoNome = new string[] {""} ;
         T001113_n228ContratoNome = new bool[] {false} ;
         T001113_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         T001113_n362ContratoDataInicial = new bool[] {false} ;
         T001113_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         T001113_n363ContratoDataFinal = new bool[] {false} ;
         T001114_A231ArquivoId = new int[1] ;
         T001114_n231ArquivoId = new bool[] {false} ;
         T001115_A578ArquivoAssinadoId = new int[1] ;
         T001115_n578ArquivoAssinadoId = new bool[] {false} ;
         T001116_A238AssinaturaId = new long[1] ;
         T001116_n238AssinaturaId = new bool[] {false} ;
         T00113_A238AssinaturaId = new long[1] ;
         T00113_n238AssinaturaId = new bool[] {false} ;
         T00113_A239AssinaturaStatus = new string[] {""} ;
         T00113_n239AssinaturaStatus = new bool[] {false} ;
         T00113_A241AssinaturaPublicKey = new Guid[] {Guid.Empty} ;
         T00113_n241AssinaturaPublicKey = new bool[] {false} ;
         T00113_A364AssinaturaPaginaConsulta = new string[] {""} ;
         T00113_n364AssinaturaPaginaConsulta = new bool[] {false} ;
         T00113_A365AssinaturaToken = new string[] {""} ;
         T00113_n365AssinaturaToken = new bool[] {false} ;
         T00113_A368AssinaturaMes = new short[1] ;
         T00113_n368AssinaturaMes = new bool[] {false} ;
         T00113_A371AssinaturaMesNome = new string[] {""} ;
         T00113_n371AssinaturaMesNome = new bool[] {false} ;
         T00113_A369AssinaturaAno = new short[1] ;
         T00113_n369AssinaturaAno = new bool[] {false} ;
         T00113_A366AssinaturaFinalizadoData = new DateTime[] {DateTime.MinValue} ;
         T00113_n366AssinaturaFinalizadoData = new bool[] {false} ;
         T00113_A256AssinaturaArquivoAssinadoExtensao = new string[] {""} ;
         T00113_n256AssinaturaArquivoAssinadoExtensao = new bool[] {false} ;
         T00113_A257AssinaturaArquivoAssinadoNome = new string[] {""} ;
         T00113_n257AssinaturaArquivoAssinadoNome = new bool[] {false} ;
         T00113_A227ContratoId = new int[1] ;
         T00113_n227ContratoId = new bool[] {false} ;
         T00113_A231ArquivoId = new int[1] ;
         T00113_n231ArquivoId = new bool[] {false} ;
         T00113_A578ArquivoAssinadoId = new int[1] ;
         T00113_n578ArquivoAssinadoId = new bool[] {false} ;
         T00113_A240AssinaturaArquivoAssinado = new string[] {""} ;
         T00113_n240AssinaturaArquivoAssinado = new bool[] {false} ;
         T001117_A238AssinaturaId = new long[1] ;
         T001117_n238AssinaturaId = new bool[] {false} ;
         T001118_A238AssinaturaId = new long[1] ;
         T001118_n238AssinaturaId = new bool[] {false} ;
         T00112_A238AssinaturaId = new long[1] ;
         T00112_n238AssinaturaId = new bool[] {false} ;
         T00112_A239AssinaturaStatus = new string[] {""} ;
         T00112_n239AssinaturaStatus = new bool[] {false} ;
         T00112_A241AssinaturaPublicKey = new Guid[] {Guid.Empty} ;
         T00112_n241AssinaturaPublicKey = new bool[] {false} ;
         T00112_A364AssinaturaPaginaConsulta = new string[] {""} ;
         T00112_n364AssinaturaPaginaConsulta = new bool[] {false} ;
         T00112_A365AssinaturaToken = new string[] {""} ;
         T00112_n365AssinaturaToken = new bool[] {false} ;
         T00112_A368AssinaturaMes = new short[1] ;
         T00112_n368AssinaturaMes = new bool[] {false} ;
         T00112_A371AssinaturaMesNome = new string[] {""} ;
         T00112_n371AssinaturaMesNome = new bool[] {false} ;
         T00112_A369AssinaturaAno = new short[1] ;
         T00112_n369AssinaturaAno = new bool[] {false} ;
         T00112_A366AssinaturaFinalizadoData = new DateTime[] {DateTime.MinValue} ;
         T00112_n366AssinaturaFinalizadoData = new bool[] {false} ;
         T00112_A256AssinaturaArquivoAssinadoExtensao = new string[] {""} ;
         T00112_n256AssinaturaArquivoAssinadoExtensao = new bool[] {false} ;
         T00112_A257AssinaturaArquivoAssinadoNome = new string[] {""} ;
         T00112_n257AssinaturaArquivoAssinadoNome = new bool[] {false} ;
         T00112_A227ContratoId = new int[1] ;
         T00112_n227ContratoId = new bool[] {false} ;
         T00112_A231ArquivoId = new int[1] ;
         T00112_n231ArquivoId = new bool[] {false} ;
         T00112_A578ArquivoAssinadoId = new int[1] ;
         T00112_n578ArquivoAssinadoId = new bool[] {false} ;
         T00112_A240AssinaturaArquivoAssinado = new string[] {""} ;
         T00112_n240AssinaturaArquivoAssinado = new bool[] {false} ;
         T001120_A238AssinaturaId = new long[1] ;
         T001120_n238AssinaturaId = new bool[] {false} ;
         T001125_A367AssinaturaParticipantes_F = new short[1] ;
         T001125_n367AssinaturaParticipantes_F = new bool[] {false} ;
         T001126_A228ContratoNome = new string[] {""} ;
         T001126_n228ContratoNome = new bool[] {false} ;
         T001126_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         T001126_n362ContratoDataInicial = new bool[] {false} ;
         T001126_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         T001126_n363ContratoDataFinal = new bool[] {false} ;
         T001127_A572PropostaContratoAssinaturaId = new int[1] ;
         T001128_A242AssinaturaParticipanteId = new int[1] ;
         T001129_A238AssinaturaId = new long[1] ;
         T001129_n238AssinaturaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i241AssinaturaPublicKey = Guid.Empty;
         T001130_A231ArquivoId = new int[1] ;
         T001130_n231ArquivoId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinatura__default(),
            new Object[][] {
                new Object[] {
               T00112_A238AssinaturaId, T00112_A239AssinaturaStatus, T00112_n239AssinaturaStatus, T00112_A241AssinaturaPublicKey, T00112_n241AssinaturaPublicKey, T00112_A364AssinaturaPaginaConsulta, T00112_n364AssinaturaPaginaConsulta, T00112_A365AssinaturaToken, T00112_n365AssinaturaToken, T00112_A368AssinaturaMes,
               T00112_n368AssinaturaMes, T00112_A371AssinaturaMesNome, T00112_n371AssinaturaMesNome, T00112_A369AssinaturaAno, T00112_n369AssinaturaAno, T00112_A366AssinaturaFinalizadoData, T00112_n366AssinaturaFinalizadoData, T00112_A256AssinaturaArquivoAssinadoExtensao, T00112_n256AssinaturaArquivoAssinadoExtensao, T00112_A257AssinaturaArquivoAssinadoNome,
               T00112_n257AssinaturaArquivoAssinadoNome, T00112_A227ContratoId, T00112_n227ContratoId, T00112_A231ArquivoId, T00112_n231ArquivoId, T00112_A578ArquivoAssinadoId, T00112_n578ArquivoAssinadoId, T00112_A240AssinaturaArquivoAssinado, T00112_n240AssinaturaArquivoAssinado
               }
               , new Object[] {
               T00113_A238AssinaturaId, T00113_A239AssinaturaStatus, T00113_n239AssinaturaStatus, T00113_A241AssinaturaPublicKey, T00113_n241AssinaturaPublicKey, T00113_A364AssinaturaPaginaConsulta, T00113_n364AssinaturaPaginaConsulta, T00113_A365AssinaturaToken, T00113_n365AssinaturaToken, T00113_A368AssinaturaMes,
               T00113_n368AssinaturaMes, T00113_A371AssinaturaMesNome, T00113_n371AssinaturaMesNome, T00113_A369AssinaturaAno, T00113_n369AssinaturaAno, T00113_A366AssinaturaFinalizadoData, T00113_n366AssinaturaFinalizadoData, T00113_A256AssinaturaArquivoAssinadoExtensao, T00113_n256AssinaturaArquivoAssinadoExtensao, T00113_A257AssinaturaArquivoAssinadoNome,
               T00113_n257AssinaturaArquivoAssinadoNome, T00113_A227ContratoId, T00113_n227ContratoId, T00113_A231ArquivoId, T00113_n231ArquivoId, T00113_A578ArquivoAssinadoId, T00113_n578ArquivoAssinadoId, T00113_A240AssinaturaArquivoAssinado, T00113_n240AssinaturaArquivoAssinado
               }
               , new Object[] {
               T00114_A228ContratoNome, T00114_n228ContratoNome, T00114_A362ContratoDataInicial, T00114_n362ContratoDataInicial, T00114_A363ContratoDataFinal, T00114_n363ContratoDataFinal
               }
               , new Object[] {
               T00115_A231ArquivoId
               }
               , new Object[] {
               T00116_A578ArquivoAssinadoId
               }
               , new Object[] {
               T00118_A367AssinaturaParticipantes_F, T00118_n367AssinaturaParticipantes_F
               }
               , new Object[] {
               T001110_A238AssinaturaId, T001110_A239AssinaturaStatus, T001110_n239AssinaturaStatus, T001110_A228ContratoNome, T001110_n228ContratoNome, T001110_A362ContratoDataInicial, T001110_n362ContratoDataInicial, T001110_A363ContratoDataFinal, T001110_n363ContratoDataFinal, T001110_A241AssinaturaPublicKey,
               T001110_n241AssinaturaPublicKey, T001110_A364AssinaturaPaginaConsulta, T001110_n364AssinaturaPaginaConsulta, T001110_A365AssinaturaToken, T001110_n365AssinaturaToken, T001110_A368AssinaturaMes, T001110_n368AssinaturaMes, T001110_A371AssinaturaMesNome, T001110_n371AssinaturaMesNome, T001110_A369AssinaturaAno,
               T001110_n369AssinaturaAno, T001110_A366AssinaturaFinalizadoData, T001110_n366AssinaturaFinalizadoData, T001110_A256AssinaturaArquivoAssinadoExtensao, T001110_n256AssinaturaArquivoAssinadoExtensao, T001110_A257AssinaturaArquivoAssinadoNome, T001110_n257AssinaturaArquivoAssinadoNome, T001110_A227ContratoId, T001110_n227ContratoId, T001110_A231ArquivoId,
               T001110_n231ArquivoId, T001110_A578ArquivoAssinadoId, T001110_n578ArquivoAssinadoId, T001110_A367AssinaturaParticipantes_F, T001110_n367AssinaturaParticipantes_F, T001110_A240AssinaturaArquivoAssinado, T001110_n240AssinaturaArquivoAssinado
               }
               , new Object[] {
               T001112_A367AssinaturaParticipantes_F, T001112_n367AssinaturaParticipantes_F
               }
               , new Object[] {
               T001113_A228ContratoNome, T001113_n228ContratoNome, T001113_A362ContratoDataInicial, T001113_n362ContratoDataInicial, T001113_A363ContratoDataFinal, T001113_n363ContratoDataFinal
               }
               , new Object[] {
               T001114_A231ArquivoId
               }
               , new Object[] {
               T001115_A578ArquivoAssinadoId
               }
               , new Object[] {
               T001116_A238AssinaturaId
               }
               , new Object[] {
               T001117_A238AssinaturaId
               }
               , new Object[] {
               T001118_A238AssinaturaId
               }
               , new Object[] {
               }
               , new Object[] {
               T001120_A238AssinaturaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001125_A367AssinaturaParticipantes_F, T001125_n367AssinaturaParticipantes_F
               }
               , new Object[] {
               T001126_A228ContratoNome, T001126_n228ContratoNome, T001126_A362ContratoDataInicial, T001126_n362ContratoDataInicial, T001126_A363ContratoDataFinal, T001126_n363ContratoDataFinal
               }
               , new Object[] {
               T001127_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               T001128_A242AssinaturaParticipanteId
               }
               , new Object[] {
               T001129_A238AssinaturaId
               }
               , new Object[] {
               T001130_A231ArquivoId
               }
            }
         );
         Z241AssinaturaPublicKey = Guid.NewGuid( );
         n241AssinaturaPublicKey = false;
         A241AssinaturaPublicKey = Guid.NewGuid( );
         n241AssinaturaPublicKey = false;
         i241AssinaturaPublicKey = Guid.NewGuid( );
         n241AssinaturaPublicKey = false;
         AV23Pgmname = "Assinatura";
      }

      private short Z368AssinaturaMes ;
      private short Z369AssinaturaAno ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A367AssinaturaParticipantes_F ;
      private short A368AssinaturaMes ;
      private short A369AssinaturaAno ;
      private short Gx_BScreen ;
      private short RcdFound40 ;
      private short Z367AssinaturaParticipantes_F ;
      private short gxajaxcallmode ;
      private int Z227ContratoId ;
      private int Z231ArquivoId ;
      private int Z578ArquivoAssinadoId ;
      private int N227ContratoId ;
      private int N231ArquivoId ;
      private int N578ArquivoAssinadoId ;
      private int A227ContratoId ;
      private int A231ArquivoId ;
      private int A578ArquivoAssinadoId ;
      private int trnEnded ;
      private int edtAssinaturaId_Enabled ;
      private int edtContratoId_Visible ;
      private int edtContratoId_Enabled ;
      private int edtArquivoId_Visible ;
      private int edtArquivoId_Enabled ;
      private int edtAssinaturaArquivoAssinado_Enabled ;
      private int edtAssinaturaPublicKey_Enabled ;
      private int edtAssinaturaPaginaConsulta_Enabled ;
      private int edtAssinaturaToken_Enabled ;
      private int edtAssinaturaFinalizadoData_Enabled ;
      private int edtAssinaturaParticipantes_F_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboContratoId ;
      private int edtavCombocontratoid_Enabled ;
      private int edtavCombocontratoid_Visible ;
      private int AV21ComboArquivoId ;
      private int edtavComboarquivoid_Enabled ;
      private int edtavComboarquivoid_Visible ;
      private int edtAssinaturaArquivoAssinadoNome_Visible ;
      private int edtAssinaturaArquivoAssinadoNome_Enabled ;
      private int edtAssinaturaArquivoAssinadoExtensao_Visible ;
      private int edtAssinaturaArquivoAssinadoExtensao_Enabled ;
      private int AV11Insert_ContratoId ;
      private int AV12Insert_ArquivoId ;
      private int AV22Insert_ArquivoAssinadoId ;
      private int Combo_contratoid_Datalistupdateminimumcharacters ;
      private int Combo_contratoid_Gxcontroltype ;
      private int Combo_arquivoid_Datalistupdateminimumcharacters ;
      private int Combo_arquivoid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV24GXV1 ;
      private int idxLst ;
      private long wcpOAV7AssinaturaId ;
      private long Z238AssinaturaId ;
      private long A238AssinaturaId ;
      private long AV7AssinaturaId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_arquivoid_Selectedvalue_get ;
      private string Combo_contratoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbAssinaturaStatus_Internalname ;
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
      private string edtAssinaturaId_Internalname ;
      private string TempTags ;
      private string edtAssinaturaId_Jsonclick ;
      private string cmbAssinaturaStatus_Jsonclick ;
      private string divTablesplittedcontratoid_Internalname ;
      private string lblTextblockcontratoid_Internalname ;
      private string lblTextblockcontratoid_Jsonclick ;
      private string Combo_contratoid_Caption ;
      private string Combo_contratoid_Cls ;
      private string Combo_contratoid_Datalistproc ;
      private string Combo_contratoid_Datalistprocparametersprefix ;
      private string Combo_contratoid_Internalname ;
      private string edtContratoId_Internalname ;
      private string edtContratoId_Jsonclick ;
      private string divTablesplittedarquivoid_Internalname ;
      private string lblTextblockarquivoid_Internalname ;
      private string lblTextblockarquivoid_Jsonclick ;
      private string Combo_arquivoid_Caption ;
      private string Combo_arquivoid_Cls ;
      private string Combo_arquivoid_Datalistproc ;
      private string Combo_arquivoid_Datalistprocparametersprefix ;
      private string Combo_arquivoid_Internalname ;
      private string edtArquivoId_Internalname ;
      private string edtArquivoId_Jsonclick ;
      private string edtAssinaturaArquivoAssinado_Internalname ;
      private string edtAssinaturaArquivoAssinado_Filename ;
      private string edtAssinaturaArquivoAssinado_Filetype ;
      private string edtAssinaturaArquivoAssinado_Contenttype ;
      private string edtAssinaturaArquivoAssinado_Parameters ;
      private string edtAssinaturaArquivoAssinado_Jsonclick ;
      private string edtAssinaturaPublicKey_Internalname ;
      private string edtAssinaturaPublicKey_Jsonclick ;
      private string edtAssinaturaPaginaConsulta_Internalname ;
      private string edtAssinaturaPaginaConsulta_Jsonclick ;
      private string edtAssinaturaToken_Internalname ;
      private string edtAssinaturaFinalizadoData_Internalname ;
      private string edtAssinaturaFinalizadoData_Jsonclick ;
      private string edtAssinaturaParticipantes_F_Internalname ;
      private string edtAssinaturaParticipantes_F_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_contratoid_Internalname ;
      private string edtavCombocontratoid_Internalname ;
      private string edtavCombocontratoid_Jsonclick ;
      private string divSectionattribute_arquivoid_Internalname ;
      private string edtavComboarquivoid_Internalname ;
      private string edtavComboarquivoid_Jsonclick ;
      private string edtAssinaturaArquivoAssinadoNome_Internalname ;
      private string edtAssinaturaArquivoAssinadoNome_Jsonclick ;
      private string edtAssinaturaArquivoAssinadoExtensao_Internalname ;
      private string edtAssinaturaArquivoAssinadoExtensao_Jsonclick ;
      private string AV23Pgmname ;
      private string Combo_contratoid_Objectcall ;
      private string Combo_contratoid_Class ;
      private string Combo_contratoid_Icontype ;
      private string Combo_contratoid_Icon ;
      private string Combo_contratoid_Tooltip ;
      private string Combo_contratoid_Selectedvalue_set ;
      private string Combo_contratoid_Selectedtext_set ;
      private string Combo_contratoid_Selectedtext_get ;
      private string Combo_contratoid_Gamoauthtoken ;
      private string Combo_contratoid_Ddointernalname ;
      private string Combo_contratoid_Titlecontrolalign ;
      private string Combo_contratoid_Dropdownoptionstype ;
      private string Combo_contratoid_Titlecontrolidtoreplace ;
      private string Combo_contratoid_Datalisttype ;
      private string Combo_contratoid_Datalistfixedvalues ;
      private string Combo_contratoid_Remoteservicesparameters ;
      private string Combo_contratoid_Htmltemplate ;
      private string Combo_contratoid_Multiplevaluestype ;
      private string Combo_contratoid_Loadingdata ;
      private string Combo_contratoid_Noresultsfound ;
      private string Combo_contratoid_Emptyitemtext ;
      private string Combo_contratoid_Onlyselectedvalues ;
      private string Combo_contratoid_Selectalltext ;
      private string Combo_contratoid_Multiplevaluesseparator ;
      private string Combo_contratoid_Addnewoptiontext ;
      private string Combo_arquivoid_Objectcall ;
      private string Combo_arquivoid_Class ;
      private string Combo_arquivoid_Icontype ;
      private string Combo_arquivoid_Icon ;
      private string Combo_arquivoid_Tooltip ;
      private string Combo_arquivoid_Selectedvalue_set ;
      private string Combo_arquivoid_Selectedtext_set ;
      private string Combo_arquivoid_Selectedtext_get ;
      private string Combo_arquivoid_Gamoauthtoken ;
      private string Combo_arquivoid_Ddointernalname ;
      private string Combo_arquivoid_Titlecontrolalign ;
      private string Combo_arquivoid_Dropdownoptionstype ;
      private string Combo_arquivoid_Titlecontrolidtoreplace ;
      private string Combo_arquivoid_Datalisttype ;
      private string Combo_arquivoid_Datalistfixedvalues ;
      private string Combo_arquivoid_Remoteservicesparameters ;
      private string Combo_arquivoid_Htmltemplate ;
      private string Combo_arquivoid_Multiplevaluestype ;
      private string Combo_arquivoid_Loadingdata ;
      private string Combo_arquivoid_Noresultsfound ;
      private string Combo_arquivoid_Emptyitemtext ;
      private string Combo_arquivoid_Onlyselectedvalues ;
      private string Combo_arquivoid_Selectalltext ;
      private string Combo_arquivoid_Multiplevaluesseparator ;
      private string Combo_arquivoid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string GXCCtlgxBlob ;
      private string hsh ;
      private string sMode40 ;
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
      private DateTime Z366AssinaturaFinalizadoData ;
      private DateTime A366AssinaturaFinalizadoData ;
      private DateTime A362ContratoDataInicial ;
      private DateTime A363ContratoDataFinal ;
      private DateTime Z362ContratoDataInicial ;
      private DateTime Z363ContratoDataFinal ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n238AssinaturaId ;
      private bool n227ContratoId ;
      private bool n231ArquivoId ;
      private bool n578ArquivoAssinadoId ;
      private bool wbErr ;
      private bool n239AssinaturaStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n240AssinaturaArquivoAssinado ;
      private bool n241AssinaturaPublicKey ;
      private bool n364AssinaturaPaginaConsulta ;
      private bool n365AssinaturaToken ;
      private bool n368AssinaturaMes ;
      private bool n371AssinaturaMesNome ;
      private bool n369AssinaturaAno ;
      private bool n366AssinaturaFinalizadoData ;
      private bool n228ContratoNome ;
      private bool n362ContratoDataInicial ;
      private bool n363ContratoDataFinal ;
      private bool Combo_contratoid_Enabled ;
      private bool Combo_contratoid_Visible ;
      private bool Combo_contratoid_Allowmultipleselection ;
      private bool Combo_contratoid_Isgriditem ;
      private bool Combo_contratoid_Hasdescription ;
      private bool Combo_contratoid_Includeonlyselectedoption ;
      private bool Combo_contratoid_Includeselectalloption ;
      private bool Combo_contratoid_Emptyitem ;
      private bool Combo_contratoid_Includeaddnewoption ;
      private bool Combo_arquivoid_Enabled ;
      private bool Combo_arquivoid_Visible ;
      private bool Combo_arquivoid_Allowmultipleselection ;
      private bool Combo_arquivoid_Isgriditem ;
      private bool Combo_arquivoid_Hasdescription ;
      private bool Combo_arquivoid_Includeonlyselectedoption ;
      private bool Combo_arquivoid_Includeselectalloption ;
      private bool Combo_arquivoid_Emptyitem ;
      private bool Combo_arquivoid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n367AssinaturaParticipantes_F ;
      private bool n256AssinaturaArquivoAssinadoExtensao ;
      private bool n257AssinaturaArquivoAssinadoNome ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV18Combo_DataJson ;
      private string Z239AssinaturaStatus ;
      private string Z364AssinaturaPaginaConsulta ;
      private string Z365AssinaturaToken ;
      private string Z371AssinaturaMesNome ;
      private string A239AssinaturaStatus ;
      private string A257AssinaturaArquivoAssinadoNome ;
      private string A256AssinaturaArquivoAssinadoExtensao ;
      private string A364AssinaturaPaginaConsulta ;
      private string A365AssinaturaToken ;
      private string A371AssinaturaMesNome ;
      private string A228ContratoNome ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private string Z256AssinaturaArquivoAssinadoExtensao ;
      private string Z257AssinaturaArquivoAssinadoNome ;
      private string Z228ContratoNome ;
      private Guid Z241AssinaturaPublicKey ;
      private Guid A241AssinaturaPublicKey ;
      private Guid i241AssinaturaPublicKey ;
      private string A240AssinaturaArquivoAssinado ;
      private string Z240AssinaturaArquivoAssinado ;
      private IGxSession AV10WebSession ;
      private GxFile gxblobfileaux ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_contratoid ;
      private GXUserControl ucCombo_arquivoid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAssinaturaStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14ContratoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV20ArquivoId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T00118_A367AssinaturaParticipantes_F ;
      private bool[] T00118_n367AssinaturaParticipantes_F ;
      private string[] T00114_A228ContratoNome ;
      private bool[] T00114_n228ContratoNome ;
      private DateTime[] T00114_A362ContratoDataInicial ;
      private bool[] T00114_n362ContratoDataInicial ;
      private DateTime[] T00114_A363ContratoDataFinal ;
      private bool[] T00114_n363ContratoDataFinal ;
      private long[] T001110_A238AssinaturaId ;
      private bool[] T001110_n238AssinaturaId ;
      private string[] T001110_A239AssinaturaStatus ;
      private bool[] T001110_n239AssinaturaStatus ;
      private string[] T001110_A228ContratoNome ;
      private bool[] T001110_n228ContratoNome ;
      private DateTime[] T001110_A362ContratoDataInicial ;
      private bool[] T001110_n362ContratoDataInicial ;
      private DateTime[] T001110_A363ContratoDataFinal ;
      private bool[] T001110_n363ContratoDataFinal ;
      private Guid[] T001110_A241AssinaturaPublicKey ;
      private bool[] T001110_n241AssinaturaPublicKey ;
      private string[] T001110_A364AssinaturaPaginaConsulta ;
      private bool[] T001110_n364AssinaturaPaginaConsulta ;
      private string[] T001110_A365AssinaturaToken ;
      private bool[] T001110_n365AssinaturaToken ;
      private short[] T001110_A368AssinaturaMes ;
      private bool[] T001110_n368AssinaturaMes ;
      private string[] T001110_A371AssinaturaMesNome ;
      private bool[] T001110_n371AssinaturaMesNome ;
      private short[] T001110_A369AssinaturaAno ;
      private bool[] T001110_n369AssinaturaAno ;
      private DateTime[] T001110_A366AssinaturaFinalizadoData ;
      private bool[] T001110_n366AssinaturaFinalizadoData ;
      private string[] T001110_A256AssinaturaArquivoAssinadoExtensao ;
      private bool[] T001110_n256AssinaturaArquivoAssinadoExtensao ;
      private string[] T001110_A257AssinaturaArquivoAssinadoNome ;
      private bool[] T001110_n257AssinaturaArquivoAssinadoNome ;
      private int[] T001110_A227ContratoId ;
      private bool[] T001110_n227ContratoId ;
      private int[] T001110_A231ArquivoId ;
      private bool[] T001110_n231ArquivoId ;
      private int[] T001110_A578ArquivoAssinadoId ;
      private bool[] T001110_n578ArquivoAssinadoId ;
      private short[] T001110_A367AssinaturaParticipantes_F ;
      private bool[] T001110_n367AssinaturaParticipantes_F ;
      private string[] T001110_A240AssinaturaArquivoAssinado ;
      private bool[] T001110_n240AssinaturaArquivoAssinado ;
      private int[] T00115_A231ArquivoId ;
      private bool[] T00115_n231ArquivoId ;
      private int[] T00116_A578ArquivoAssinadoId ;
      private bool[] T00116_n578ArquivoAssinadoId ;
      private short[] T001112_A367AssinaturaParticipantes_F ;
      private bool[] T001112_n367AssinaturaParticipantes_F ;
      private string[] T001113_A228ContratoNome ;
      private bool[] T001113_n228ContratoNome ;
      private DateTime[] T001113_A362ContratoDataInicial ;
      private bool[] T001113_n362ContratoDataInicial ;
      private DateTime[] T001113_A363ContratoDataFinal ;
      private bool[] T001113_n363ContratoDataFinal ;
      private int[] T001114_A231ArquivoId ;
      private bool[] T001114_n231ArquivoId ;
      private int[] T001115_A578ArquivoAssinadoId ;
      private bool[] T001115_n578ArquivoAssinadoId ;
      private long[] T001116_A238AssinaturaId ;
      private bool[] T001116_n238AssinaturaId ;
      private long[] T00113_A238AssinaturaId ;
      private bool[] T00113_n238AssinaturaId ;
      private string[] T00113_A239AssinaturaStatus ;
      private bool[] T00113_n239AssinaturaStatus ;
      private Guid[] T00113_A241AssinaturaPublicKey ;
      private bool[] T00113_n241AssinaturaPublicKey ;
      private string[] T00113_A364AssinaturaPaginaConsulta ;
      private bool[] T00113_n364AssinaturaPaginaConsulta ;
      private string[] T00113_A365AssinaturaToken ;
      private bool[] T00113_n365AssinaturaToken ;
      private short[] T00113_A368AssinaturaMes ;
      private bool[] T00113_n368AssinaturaMes ;
      private string[] T00113_A371AssinaturaMesNome ;
      private bool[] T00113_n371AssinaturaMesNome ;
      private short[] T00113_A369AssinaturaAno ;
      private bool[] T00113_n369AssinaturaAno ;
      private DateTime[] T00113_A366AssinaturaFinalizadoData ;
      private bool[] T00113_n366AssinaturaFinalizadoData ;
      private string[] T00113_A256AssinaturaArquivoAssinadoExtensao ;
      private bool[] T00113_n256AssinaturaArquivoAssinadoExtensao ;
      private string[] T00113_A257AssinaturaArquivoAssinadoNome ;
      private bool[] T00113_n257AssinaturaArquivoAssinadoNome ;
      private int[] T00113_A227ContratoId ;
      private bool[] T00113_n227ContratoId ;
      private int[] T00113_A231ArquivoId ;
      private bool[] T00113_n231ArquivoId ;
      private int[] T00113_A578ArquivoAssinadoId ;
      private bool[] T00113_n578ArquivoAssinadoId ;
      private string[] T00113_A240AssinaturaArquivoAssinado ;
      private bool[] T00113_n240AssinaturaArquivoAssinado ;
      private long[] T001117_A238AssinaturaId ;
      private bool[] T001117_n238AssinaturaId ;
      private long[] T001118_A238AssinaturaId ;
      private bool[] T001118_n238AssinaturaId ;
      private long[] T00112_A238AssinaturaId ;
      private bool[] T00112_n238AssinaturaId ;
      private string[] T00112_A239AssinaturaStatus ;
      private bool[] T00112_n239AssinaturaStatus ;
      private Guid[] T00112_A241AssinaturaPublicKey ;
      private bool[] T00112_n241AssinaturaPublicKey ;
      private string[] T00112_A364AssinaturaPaginaConsulta ;
      private bool[] T00112_n364AssinaturaPaginaConsulta ;
      private string[] T00112_A365AssinaturaToken ;
      private bool[] T00112_n365AssinaturaToken ;
      private short[] T00112_A368AssinaturaMes ;
      private bool[] T00112_n368AssinaturaMes ;
      private string[] T00112_A371AssinaturaMesNome ;
      private bool[] T00112_n371AssinaturaMesNome ;
      private short[] T00112_A369AssinaturaAno ;
      private bool[] T00112_n369AssinaturaAno ;
      private DateTime[] T00112_A366AssinaturaFinalizadoData ;
      private bool[] T00112_n366AssinaturaFinalizadoData ;
      private string[] T00112_A256AssinaturaArquivoAssinadoExtensao ;
      private bool[] T00112_n256AssinaturaArquivoAssinadoExtensao ;
      private string[] T00112_A257AssinaturaArquivoAssinadoNome ;
      private bool[] T00112_n257AssinaturaArquivoAssinadoNome ;
      private int[] T00112_A227ContratoId ;
      private bool[] T00112_n227ContratoId ;
      private int[] T00112_A231ArquivoId ;
      private bool[] T00112_n231ArquivoId ;
      private int[] T00112_A578ArquivoAssinadoId ;
      private bool[] T00112_n578ArquivoAssinadoId ;
      private string[] T00112_A240AssinaturaArquivoAssinado ;
      private bool[] T00112_n240AssinaturaArquivoAssinado ;
      private long[] T001120_A238AssinaturaId ;
      private bool[] T001120_n238AssinaturaId ;
      private short[] T001125_A367AssinaturaParticipantes_F ;
      private bool[] T001125_n367AssinaturaParticipantes_F ;
      private string[] T001126_A228ContratoNome ;
      private bool[] T001126_n228ContratoNome ;
      private DateTime[] T001126_A362ContratoDataInicial ;
      private bool[] T001126_n362ContratoDataInicial ;
      private DateTime[] T001126_A363ContratoDataFinal ;
      private bool[] T001126_n363ContratoDataFinal ;
      private int[] T001127_A572PropostaContratoAssinaturaId ;
      private int[] T001128_A242AssinaturaParticipanteId ;
      private long[] T001129_A238AssinaturaId ;
      private bool[] T001129_n238AssinaturaId ;
      private int[] T001130_A231ArquivoId ;
      private bool[] T001130_n231ArquivoId ;
   }

   public class assinatura__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00112;
          prmT00112 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT00113;
          prmT00113 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT00114;
          prmT00114 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00115;
          prmT00115 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT00116;
          prmT00116 = new Object[] {
          new ParDef("ArquivoAssinadoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT00118;
          prmT00118 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001110;
          prmT001110 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001112;
          prmT001112 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001113;
          prmT001113 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT001114;
          prmT001114 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT001115;
          prmT001115 = new Object[] {
          new ParDef("ArquivoAssinadoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT001116;
          prmT001116 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001117;
          prmT001117 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001118;
          prmT001118 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001119;
          prmT001119 = new Object[] {
          new ParDef("AssinaturaStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaArquivoAssinado",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("AssinaturaPublicKey",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AssinaturaPaginaConsulta",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("AssinaturaToken",GXType.VarChar,512,0){Nullable=true} ,
          new ParDef("AssinaturaMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AssinaturaMesNome",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AssinaturaFinalizadoData",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AssinaturaArquivoAssinadoExtensao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaArquivoAssinadoNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("ArquivoAssinadoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmT001120;
          prmT001120 = new Object[] {
          };
          Object[] prmT001121;
          prmT001121 = new Object[] {
          new ParDef("AssinaturaStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaPublicKey",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AssinaturaPaginaConsulta",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("AssinaturaToken",GXType.VarChar,512,0){Nullable=true} ,
          new ParDef("AssinaturaMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AssinaturaMesNome",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AssinaturaFinalizadoData",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AssinaturaArquivoAssinadoExtensao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaArquivoAssinadoNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("ArquivoAssinadoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001122;
          prmT001122 = new Object[] {
          new ParDef("AssinaturaArquivoAssinado",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001123;
          prmT001123 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001125;
          prmT001125 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001126;
          prmT001126 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT001127;
          prmT001127 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001128;
          prmT001128 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT001129;
          prmT001129 = new Object[] {
          };
          Object[] prmT001130;
          prmT001130 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00112", "SELECT AssinaturaId, AssinaturaStatus, AssinaturaPublicKey, AssinaturaPaginaConsulta, AssinaturaToken, AssinaturaMes, AssinaturaMesNome, AssinaturaAno, AssinaturaFinalizadoData, AssinaturaArquivoAssinadoExtensao, AssinaturaArquivoAssinadoNome, ContratoId, ArquivoId, ArquivoAssinadoId, AssinaturaArquivoAssinado FROM Assinatura WHERE AssinaturaId = :AssinaturaId  FOR UPDATE OF Assinatura NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00112,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00113", "SELECT AssinaturaId, AssinaturaStatus, AssinaturaPublicKey, AssinaturaPaginaConsulta, AssinaturaToken, AssinaturaMes, AssinaturaMesNome, AssinaturaAno, AssinaturaFinalizadoData, AssinaturaArquivoAssinadoExtensao, AssinaturaArquivoAssinadoNome, ContratoId, ArquivoId, ArquivoAssinadoId, AssinaturaArquivoAssinado FROM Assinatura WHERE AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00113,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00114", "SELECT ContratoNome, ContratoDataInicial, ContratoDataFinal FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00114,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00115", "SELECT ArquivoId FROM Arquivo WHERE ArquivoId = :ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00115,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00116", "SELECT ArquivoId AS ArquivoAssinadoId FROM Arquivo WHERE ArquivoId = :ArquivoAssinadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00116,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00118", "SELECT COALESCE( T1.AssinaturaParticipantes_F, 0) AS AssinaturaParticipantes_F FROM (SELECT COUNT(*) AS AssinaturaParticipantes_F, AssinaturaId FROM AssinaturaParticipante GROUP BY AssinaturaId ) T1 WHERE T1.AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00118,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001110", "SELECT TM1.AssinaturaId, TM1.AssinaturaStatus, T3.ContratoNome, T3.ContratoDataInicial, T3.ContratoDataFinal, TM1.AssinaturaPublicKey, TM1.AssinaturaPaginaConsulta, TM1.AssinaturaToken, TM1.AssinaturaMes, TM1.AssinaturaMesNome, TM1.AssinaturaAno, TM1.AssinaturaFinalizadoData, TM1.AssinaturaArquivoAssinadoExtensao, TM1.AssinaturaArquivoAssinadoNome, TM1.ContratoId, TM1.ArquivoId, TM1.ArquivoAssinadoId AS ArquivoAssinadoId, COALESCE( T2.AssinaturaParticipantes_F, 0) AS AssinaturaParticipantes_F, TM1.AssinaturaArquivoAssinado FROM ((Assinatura TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS AssinaturaParticipantes_F, AssinaturaId FROM AssinaturaParticipante WHERE TM1.AssinaturaId = AssinaturaId GROUP BY AssinaturaId ) T2 ON T2.AssinaturaId = TM1.AssinaturaId) LEFT JOIN Contrato T3 ON T3.ContratoId = TM1.ContratoId) WHERE TM1.AssinaturaId = :AssinaturaId ORDER BY TM1.AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001110,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001112", "SELECT COALESCE( T1.AssinaturaParticipantes_F, 0) AS AssinaturaParticipantes_F FROM (SELECT COUNT(*) AS AssinaturaParticipantes_F, AssinaturaId FROM AssinaturaParticipante GROUP BY AssinaturaId ) T1 WHERE T1.AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001112,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001113", "SELECT ContratoNome, ContratoDataInicial, ContratoDataFinal FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001113,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001114", "SELECT ArquivoId FROM Arquivo WHERE ArquivoId = :ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001114,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001115", "SELECT ArquivoId AS ArquivoAssinadoId FROM Arquivo WHERE ArquivoId = :ArquivoAssinadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001115,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001116", "SELECT AssinaturaId FROM Assinatura WHERE AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001116,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001117", "SELECT AssinaturaId FROM Assinatura WHERE ( AssinaturaId > :AssinaturaId) ORDER BY AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001117,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001118", "SELECT AssinaturaId FROM Assinatura WHERE ( AssinaturaId < :AssinaturaId) ORDER BY AssinaturaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001118,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001119", "SAVEPOINT gxupdate;INSERT INTO Assinatura(AssinaturaStatus, AssinaturaArquivoAssinado, AssinaturaPublicKey, AssinaturaPaginaConsulta, AssinaturaToken, AssinaturaMes, AssinaturaMesNome, AssinaturaAno, AssinaturaFinalizadoData, AssinaturaArquivoAssinadoExtensao, AssinaturaArquivoAssinadoNome, ContratoId, ArquivoId, ArquivoAssinadoId) VALUES(:AssinaturaStatus, :AssinaturaArquivoAssinado, :AssinaturaPublicKey, :AssinaturaPaginaConsulta, :AssinaturaToken, :AssinaturaMes, :AssinaturaMesNome, :AssinaturaAno, :AssinaturaFinalizadoData, :AssinaturaArquivoAssinadoExtensao, :AssinaturaArquivoAssinadoNome, :ContratoId, :ArquivoId, :ArquivoAssinadoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001119)
             ,new CursorDef("T001120", "SELECT currval('AssinaturaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001120,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001121", "SAVEPOINT gxupdate;UPDATE Assinatura SET AssinaturaStatus=:AssinaturaStatus, AssinaturaPublicKey=:AssinaturaPublicKey, AssinaturaPaginaConsulta=:AssinaturaPaginaConsulta, AssinaturaToken=:AssinaturaToken, AssinaturaMes=:AssinaturaMes, AssinaturaMesNome=:AssinaturaMesNome, AssinaturaAno=:AssinaturaAno, AssinaturaFinalizadoData=:AssinaturaFinalizadoData, AssinaturaArquivoAssinadoExtensao=:AssinaturaArquivoAssinadoExtensao, AssinaturaArquivoAssinadoNome=:AssinaturaArquivoAssinadoNome, ContratoId=:ContratoId, ArquivoId=:ArquivoId, ArquivoAssinadoId=:ArquivoAssinadoId  WHERE AssinaturaId = :AssinaturaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001121)
             ,new CursorDef("T001122", "SAVEPOINT gxupdate;UPDATE Assinatura SET AssinaturaArquivoAssinado=:AssinaturaArquivoAssinado  WHERE AssinaturaId = :AssinaturaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001122)
             ,new CursorDef("T001123", "SAVEPOINT gxupdate;DELETE FROM Assinatura  WHERE AssinaturaId = :AssinaturaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001123)
             ,new CursorDef("T001125", "SELECT COALESCE( T1.AssinaturaParticipantes_F, 0) AS AssinaturaParticipantes_F FROM (SELECT COUNT(*) AS AssinaturaParticipantes_F, AssinaturaId FROM AssinaturaParticipante GROUP BY AssinaturaId ) T1 WHERE T1.AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001125,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001126", "SELECT ContratoNome, ContratoDataInicial, ContratoDataFinal FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001126,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001127", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaAssinatura = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001127,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001128", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaId = :AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001128,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001129", "SELECT AssinaturaId FROM Assinatura ORDER BY AssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001129,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001130", "SELECT ArquivoId FROM Arquivo WHERE ArquivoId = :ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001130,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getBLOBFile(15, rslt.getVarchar(10), rslt.getVarchar(11));
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getBLOBFile(15, rslt.getVarchar(10), rslt.getVarchar(11));
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((Guid[]) buf[9])[0] = rslt.getGuid(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((int[]) buf[27])[0] = rslt.getInt(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((short[]) buf[33])[0] = rslt.getShort(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getBLOBFile(19, rslt.getVarchar(13), rslt.getVarchar(14));
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 12 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 13 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 15 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 23 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
