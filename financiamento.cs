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
   public class financiamento : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A168ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A220IntermediadorClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "IntermediadorClienteId"), "."), 18, MidpointRounding.ToEven));
            n220IntermediadorClienteId = false;
            AssignAttri("", false, "A220IntermediadorClienteId", ((0==A220IntermediadorClienteId)&&IsIns( )||n220IntermediadorClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A220IntermediadorClienteId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "financiamento")), "financiamento") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "financiamento")))) ;
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
                  AV7FinanciamentoId = (int)(Math.Round(NumberUtil.Val( GetPar( "FinanciamentoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7FinanciamentoId", StringUtil.LTrimStr( (decimal)(AV7FinanciamentoId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFINANCIAMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FinanciamentoId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Financiamento", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public financiamento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public financiamento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_FinanciamentoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7FinanciamentoId = aP1_FinanciamentoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFinanciamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFinanciamentoId_Internalname, "Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFinanciamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A223FinanciamentoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtFinanciamentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A223FinanciamentoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A223FinanciamentoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFinanciamentoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtFinanciamentoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Financiamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedclienteid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockclienteid_Internalname, "Cliente", "", "", lblTextblockclienteid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Financiamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_clienteid.SetProperty("Caption", Combo_clienteid_Caption);
         ucCombo_clienteid.SetProperty("Cls", Combo_clienteid_Cls);
         ucCombo_clienteid.SetProperty("DataListProc", Combo_clienteid_Datalistproc);
         ucCombo_clienteid.SetProperty("DataListProcParametersPrefix", Combo_clienteid_Datalistprocparametersprefix);
         ucCombo_clienteid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_clienteid.SetProperty("DropDownOptionsData", AV14ClienteId_Data);
         ucCombo_clienteid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_clienteid_Internalname, "COMBO_CLIENTEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Cliente Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", ""))), ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteId_Visible, edtClienteId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Financiamento.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteRazaoSocial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteRazaoSocial_Internalname, "Razão social", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteRazaoSocial_Internalname, A170ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteRazaoSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClienteRazaoSocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Financiamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFinanciamentoValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFinanciamentoValor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFinanciamentoValor_Internalname, ((Convert.ToDecimal(0)==A224FinanciamentoValor)&&IsIns( )||n224FinanciamentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A224FinanciamentoValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A224FinanciamentoValor)&&IsIns( )||n224FinanciamentoValor ? "" : StringUtil.LTrim( ((edtFinanciamentoValor_Enabled!=0) ? context.localUtil.Format( A224FinanciamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A224FinanciamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFinanciamentoValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtFinanciamentoValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Financiamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedintermediadorclienteid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockintermediadorclienteid_Internalname, "Cliente", "", "", lblTextblockintermediadorclienteid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Financiamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_intermediadorclienteid.SetProperty("Caption", Combo_intermediadorclienteid_Caption);
         ucCombo_intermediadorclienteid.SetProperty("Cls", Combo_intermediadorclienteid_Cls);
         ucCombo_intermediadorclienteid.SetProperty("DataListProc", Combo_intermediadorclienteid_Datalistproc);
         ucCombo_intermediadorclienteid.SetProperty("DataListProcParametersPrefix", Combo_intermediadorclienteid_Datalistprocparametersprefix);
         ucCombo_intermediadorclienteid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_intermediadorclienteid.SetProperty("DropDownOptionsData", AV20IntermediadorClienteId_Data);
         ucCombo_intermediadorclienteid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_intermediadorclienteid_Internalname, "COMBO_INTERMEDIADORCLIENTEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIntermediadorClienteId_Internalname, "Intermediador Cliente Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIntermediadorClienteId_Internalname, ((0==A220IntermediadorClienteId)&&IsIns( )||n220IntermediadorClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ",", ""))), ((0==A220IntermediadorClienteId)&&IsIns( )||n220IntermediadorClienteId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A220IntermediadorClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIntermediadorClienteId_Jsonclick, 0, "Attribute", "", "", "", "", edtIntermediadorClienteId_Visible, edtIntermediadorClienteId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Financiamento.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIntermediadorClienteRazaoSocial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIntermediadorClienteRazaoSocial_Internalname, "Razao Social", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIntermediadorClienteRazaoSocial_Internalname, A221IntermediadorClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( A221IntermediadorClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIntermediadorClienteRazaoSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtIntermediadorClienteRazaoSocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Financiamento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Financiamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Financiamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Financiamento.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_clienteid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboClienteId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboclienteid_Visible, edtavComboclienteid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Financiamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_intermediadorclienteid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombointermediadorclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ComboIntermediadorClienteId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavCombointermediadorclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV21ComboIntermediadorClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV21ComboIntermediadorClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombointermediadorclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombointermediadorclienteid_Visible, edtavCombointermediadorclienteid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Financiamento.htm");
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
         E110W2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCLIENTEID_DATA"), AV14ClienteId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vINTERMEDIADORCLIENTEID_DATA"), AV20IntermediadorClienteId_Data);
               /* Read saved values. */
               Z223FinanciamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z223FinanciamentoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z224FinanciamentoValor = context.localUtil.CToN( cgiGet( "Z224FinanciamentoValor"), ",", ".");
               n224FinanciamentoValor = ((Convert.ToDecimal(0)==A224FinanciamentoValor) ? true : false);
               Z225FinanciamentoStatus = cgiGet( "Z225FinanciamentoStatus");
               n225FinanciamentoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A225FinanciamentoStatus)) ? true : false);
               Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               Z220IntermediadorClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z220IntermediadorClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n220IntermediadorClienteId = ((0==A220IntermediadorClienteId) ? true : false);
               A225FinanciamentoStatus = cgiGet( "Z225FinanciamentoStatus");
               n225FinanciamentoStatus = false;
               n225FinanciamentoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A225FinanciamentoStatus)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               N220IntermediadorClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N220IntermediadorClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n220IntermediadorClienteId = ((0==A220IntermediadorClienteId) ? true : false);
               AV7FinanciamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vFINANCIAMENTOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 9, 0));
               AV12Insert_IntermediadorClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_INTERMEDIADORCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_IntermediadorClienteId", StringUtil.LTrimStr( (decimal)(AV12Insert_IntermediadorClienteId), 9, 0));
               A225FinanciamentoStatus = cgiGet( "FINANCIAMENTOSTATUS");
               n225FinanciamentoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A225FinanciamentoStatus)) ? true : false);
               A169ClienteDocumento = cgiGet( "CLIENTEDOCUMENTO");
               n169ClienteDocumento = false;
               A222IntermediadorClienteDocumento = cgiGet( "INTERMEDIADORCLIENTEDOCUMENTO");
               n222IntermediadorClienteDocumento = false;
               AV23Pgmname = cgiGet( "vPGMNAME");
               Combo_clienteid_Objectcall = cgiGet( "COMBO_CLIENTEID_Objectcall");
               Combo_clienteid_Class = cgiGet( "COMBO_CLIENTEID_Class");
               Combo_clienteid_Icontype = cgiGet( "COMBO_CLIENTEID_Icontype");
               Combo_clienteid_Icon = cgiGet( "COMBO_CLIENTEID_Icon");
               Combo_clienteid_Caption = cgiGet( "COMBO_CLIENTEID_Caption");
               Combo_clienteid_Tooltip = cgiGet( "COMBO_CLIENTEID_Tooltip");
               Combo_clienteid_Cls = cgiGet( "COMBO_CLIENTEID_Cls");
               Combo_clienteid_Selectedvalue_set = cgiGet( "COMBO_CLIENTEID_Selectedvalue_set");
               Combo_clienteid_Selectedvalue_get = cgiGet( "COMBO_CLIENTEID_Selectedvalue_get");
               Combo_clienteid_Selectedtext_set = cgiGet( "COMBO_CLIENTEID_Selectedtext_set");
               Combo_clienteid_Selectedtext_get = cgiGet( "COMBO_CLIENTEID_Selectedtext_get");
               Combo_clienteid_Gamoauthtoken = cgiGet( "COMBO_CLIENTEID_Gamoauthtoken");
               Combo_clienteid_Ddointernalname = cgiGet( "COMBO_CLIENTEID_Ddointernalname");
               Combo_clienteid_Titlecontrolalign = cgiGet( "COMBO_CLIENTEID_Titlecontrolalign");
               Combo_clienteid_Dropdownoptionstype = cgiGet( "COMBO_CLIENTEID_Dropdownoptionstype");
               Combo_clienteid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Enabled"));
               Combo_clienteid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Visible"));
               Combo_clienteid_Titlecontrolidtoreplace = cgiGet( "COMBO_CLIENTEID_Titlecontrolidtoreplace");
               Combo_clienteid_Datalisttype = cgiGet( "COMBO_CLIENTEID_Datalisttype");
               Combo_clienteid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Allowmultipleselection"));
               Combo_clienteid_Datalistfixedvalues = cgiGet( "COMBO_CLIENTEID_Datalistfixedvalues");
               Combo_clienteid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Isgriditem"));
               Combo_clienteid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Hasdescription"));
               Combo_clienteid_Datalistproc = cgiGet( "COMBO_CLIENTEID_Datalistproc");
               Combo_clienteid_Datalistprocparametersprefix = cgiGet( "COMBO_CLIENTEID_Datalistprocparametersprefix");
               Combo_clienteid_Remoteservicesparameters = cgiGet( "COMBO_CLIENTEID_Remoteservicesparameters");
               Combo_clienteid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CLIENTEID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_clienteid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Includeonlyselectedoption"));
               Combo_clienteid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Includeselectalloption"));
               Combo_clienteid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Emptyitem"));
               Combo_clienteid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Includeaddnewoption"));
               Combo_clienteid_Htmltemplate = cgiGet( "COMBO_CLIENTEID_Htmltemplate");
               Combo_clienteid_Multiplevaluestype = cgiGet( "COMBO_CLIENTEID_Multiplevaluestype");
               Combo_clienteid_Loadingdata = cgiGet( "COMBO_CLIENTEID_Loadingdata");
               Combo_clienteid_Noresultsfound = cgiGet( "COMBO_CLIENTEID_Noresultsfound");
               Combo_clienteid_Emptyitemtext = cgiGet( "COMBO_CLIENTEID_Emptyitemtext");
               Combo_clienteid_Onlyselectedvalues = cgiGet( "COMBO_CLIENTEID_Onlyselectedvalues");
               Combo_clienteid_Selectalltext = cgiGet( "COMBO_CLIENTEID_Selectalltext");
               Combo_clienteid_Multiplevaluesseparator = cgiGet( "COMBO_CLIENTEID_Multiplevaluesseparator");
               Combo_clienteid_Addnewoptiontext = cgiGet( "COMBO_CLIENTEID_Addnewoptiontext");
               Combo_clienteid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CLIENTEID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_intermediadorclienteid_Objectcall = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Objectcall");
               Combo_intermediadorclienteid_Class = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Class");
               Combo_intermediadorclienteid_Icontype = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Icontype");
               Combo_intermediadorclienteid_Icon = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Icon");
               Combo_intermediadorclienteid_Caption = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Caption");
               Combo_intermediadorclienteid_Tooltip = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Tooltip");
               Combo_intermediadorclienteid_Cls = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Cls");
               Combo_intermediadorclienteid_Selectedvalue_set = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Selectedvalue_set");
               Combo_intermediadorclienteid_Selectedvalue_get = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Selectedvalue_get");
               Combo_intermediadorclienteid_Selectedtext_set = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Selectedtext_set");
               Combo_intermediadorclienteid_Selectedtext_get = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Selectedtext_get");
               Combo_intermediadorclienteid_Gamoauthtoken = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Gamoauthtoken");
               Combo_intermediadorclienteid_Ddointernalname = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Ddointernalname");
               Combo_intermediadorclienteid_Titlecontrolalign = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Titlecontrolalign");
               Combo_intermediadorclienteid_Dropdownoptionstype = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Dropdownoptionstype");
               Combo_intermediadorclienteid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Enabled"));
               Combo_intermediadorclienteid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Visible"));
               Combo_intermediadorclienteid_Titlecontrolidtoreplace = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Titlecontrolidtoreplace");
               Combo_intermediadorclienteid_Datalisttype = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Datalisttype");
               Combo_intermediadorclienteid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Allowmultipleselection"));
               Combo_intermediadorclienteid_Datalistfixedvalues = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Datalistfixedvalues");
               Combo_intermediadorclienteid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Isgriditem"));
               Combo_intermediadorclienteid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Hasdescription"));
               Combo_intermediadorclienteid_Datalistproc = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Datalistproc");
               Combo_intermediadorclienteid_Datalistprocparametersprefix = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Datalistprocparametersprefix");
               Combo_intermediadorclienteid_Remoteservicesparameters = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Remoteservicesparameters");
               Combo_intermediadorclienteid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_intermediadorclienteid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Includeonlyselectedoption"));
               Combo_intermediadorclienteid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Includeselectalloption"));
               Combo_intermediadorclienteid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Emptyitem"));
               Combo_intermediadorclienteid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Includeaddnewoption"));
               Combo_intermediadorclienteid_Htmltemplate = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Htmltemplate");
               Combo_intermediadorclienteid_Multiplevaluestype = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Multiplevaluestype");
               Combo_intermediadorclienteid_Loadingdata = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Loadingdata");
               Combo_intermediadorclienteid_Noresultsfound = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Noresultsfound");
               Combo_intermediadorclienteid_Emptyitemtext = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Emptyitemtext");
               Combo_intermediadorclienteid_Onlyselectedvalues = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Onlyselectedvalues");
               Combo_intermediadorclienteid_Selectalltext = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Selectalltext");
               Combo_intermediadorclienteid_Multiplevaluesseparator = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Multiplevaluesseparator");
               Combo_intermediadorclienteid_Addnewoptiontext = cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Addnewoptiontext");
               Combo_intermediadorclienteid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_INTERMEDIADORCLIENTEID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A223FinanciamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFinanciamentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
               n168ClienteId = ((StringUtil.StrCmp(cgiGet( edtClienteId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A168ClienteId = 0;
                  n168ClienteId = false;
                  AssignAttri("", false, "A168ClienteId", (n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
               }
               else
               {
                  A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A168ClienteId", (n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
               }
               A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
               n170ClienteRazaoSocial = false;
               AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
               n224FinanciamentoValor = ((StringUtil.StrCmp(cgiGet( edtFinanciamentoValor_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtFinanciamentoValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFinanciamentoValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FINANCIAMENTOVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtFinanciamentoValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A224FinanciamentoValor = 0;
                  n224FinanciamentoValor = false;
                  AssignAttri("", false, "A224FinanciamentoValor", (n224FinanciamentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A224FinanciamentoValor, 18, 2, ".", ""))));
               }
               else
               {
                  A224FinanciamentoValor = context.localUtil.CToN( cgiGet( edtFinanciamentoValor_Internalname), ",", ".");
                  AssignAttri("", false, "A224FinanciamentoValor", (n224FinanciamentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A224FinanciamentoValor, 18, 2, ".", ""))));
               }
               n220IntermediadorClienteId = ((StringUtil.StrCmp(cgiGet( edtIntermediadorClienteId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtIntermediadorClienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIntermediadorClienteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INTERMEDIADORCLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtIntermediadorClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A220IntermediadorClienteId = 0;
                  n220IntermediadorClienteId = false;
                  AssignAttri("", false, "A220IntermediadorClienteId", (n220IntermediadorClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ".", ""))));
               }
               else
               {
                  A220IntermediadorClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtIntermediadorClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A220IntermediadorClienteId", (n220IntermediadorClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ".", ""))));
               }
               A221IntermediadorClienteRazaoSocial = StringUtil.Upper( cgiGet( edtIntermediadorClienteRazaoSocial_Internalname));
               n221IntermediadorClienteRazaoSocial = false;
               AssignAttri("", false, "A221IntermediadorClienteRazaoSocial", A221IntermediadorClienteRazaoSocial);
               AV19ComboClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ComboClienteId", StringUtil.LTrimStr( (decimal)(AV19ComboClienteId), 9, 0));
               AV21ComboIntermediadorClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombointermediadorclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21ComboIntermediadorClienteId", StringUtil.LTrimStr( (decimal)(AV21ComboIntermediadorClienteId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Financiamento");
               A223FinanciamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFinanciamentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
               forbiddenHiddens.Add("FinanciamentoId", context.localUtil.Format( (decimal)(A223FinanciamentoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ClienteId", context.localUtil.Format( (decimal)(AV11Insert_ClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_IntermediadorClienteId", context.localUtil.Format( (decimal)(AV12Insert_IntermediadorClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("FinanciamentoStatus", StringUtil.RTrim( context.localUtil.Format( A225FinanciamentoStatus, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A223FinanciamentoId != Z223FinanciamentoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("financiamento:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A223FinanciamentoId = (int)(Math.Round(NumberUtil.Val( GetPar( "FinanciamentoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
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
                     sMode35 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode35;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound35 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0W0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "FINANCIAMENTOID");
                        AnyError = 1;
                        GX_FocusControl = edtFinanciamentoId_Internalname;
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
                           E110W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120W2 ();
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
            E120W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0W35( ) ;
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
            DisableAttributes0W35( ) ;
         }
         AssignProp("", false, edtavComboclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboclienteid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombointermediadorclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombointermediadorclienteid_Enabled), 5, 0), true);
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

      protected void CONFIRM_0W0( )
      {
         BeforeValidate0W35( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0W35( ) ;
            }
            else
            {
               CheckExtendedTable0W35( ) ;
               CloseExtendedTableCursors0W35( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0W0( )
      {
      }

      protected void E110W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtIntermediadorClienteId_Visible = 0;
         AssignProp("", false, edtIntermediadorClienteId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIntermediadorClienteId_Visible), 5, 0), true);
         AV21ComboIntermediadorClienteId = 0;
         AssignAttri("", false, "AV21ComboIntermediadorClienteId", StringUtil.LTrimStr( (decimal)(AV21ComboIntermediadorClienteId), 9, 0));
         edtavCombointermediadorclienteid_Visible = 0;
         AssignProp("", false, edtavCombointermediadorclienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombointermediadorclienteid_Visible), 5, 0), true);
         edtClienteId_Visible = 0;
         AssignProp("", false, edtClienteId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteId_Visible), 5, 0), true);
         AV19ComboClienteId = 0;
         AssignAttri("", false, "AV19ComboClienteId", StringUtil.LTrimStr( (decimal)(AV19ComboClienteId), 9, 0));
         edtavComboclienteid_Visible = 0;
         AssignProp("", false, edtavComboclienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboclienteid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCLIENTEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOINTERMEDIADORCLIENTEID' */
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
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV11Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 9, 0));
                  if ( ! (0==AV11Insert_ClienteId) )
                  {
                     AV19ComboClienteId = AV11Insert_ClienteId;
                     AssignAttri("", false, "AV19ComboClienteId", StringUtil.LTrimStr( (decimal)(AV19ComboClienteId), 9, 0));
                     Combo_clienteid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ComboClienteId), 9, 0));
                     ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "SelectedValue_set", Combo_clienteid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new financiamentoloaddvcombo(context ).execute(  "ClienteId",  "GET",  false,  AV7FinanciamentoId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_clienteid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "SelectedText_set", Combo_clienteid_Selectedtext_set);
                     Combo_clienteid_Enabled = false;
                     ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_clienteid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "IntermediadorClienteId") == 0 )
               {
                  AV12Insert_IntermediadorClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_IntermediadorClienteId", StringUtil.LTrimStr( (decimal)(AV12Insert_IntermediadorClienteId), 9, 0));
                  if ( ! (0==AV12Insert_IntermediadorClienteId) )
                  {
                     AV21ComboIntermediadorClienteId = AV12Insert_IntermediadorClienteId;
                     AssignAttri("", false, "AV21ComboIntermediadorClienteId", StringUtil.LTrimStr( (decimal)(AV21ComboIntermediadorClienteId), 9, 0));
                     Combo_intermediadorclienteid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV21ComboIntermediadorClienteId), 9, 0));
                     ucCombo_intermediadorclienteid.SendProperty(context, "", false, Combo_intermediadorclienteid_Internalname, "SelectedValue_set", Combo_intermediadorclienteid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new financiamentoloaddvcombo(context ).execute(  "IntermediadorClienteId",  "GET",  false,  AV7FinanciamentoId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_intermediadorclienteid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_intermediadorclienteid.SendProperty(context, "", false, Combo_intermediadorclienteid_Internalname, "SelectedText_set", Combo_intermediadorclienteid_Selectedtext_set);
                     Combo_intermediadorclienteid_Enabled = false;
                     ucCombo_intermediadorclienteid.SendProperty(context, "", false, Combo_intermediadorclienteid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_intermediadorclienteid_Enabled));
                  }
               }
               AV24GXV1 = (int)(AV24GXV1+1);
               AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            }
         }
      }

      protected void E120W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("financiamentoww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'LOADCOMBOINTERMEDIADORCLIENTEID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new financiamentoloaddvcombo(context ).execute(  "IntermediadorClienteId",  Gx_mode,  false,  AV7FinanciamentoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_intermediadorclienteid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_intermediadorclienteid.SendProperty(context, "", false, Combo_intermediadorclienteid_Internalname, "SelectedValue_set", Combo_intermediadorclienteid_Selectedvalue_set);
         Combo_intermediadorclienteid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_intermediadorclienteid.SendProperty(context, "", false, Combo_intermediadorclienteid_Internalname, "SelectedText_set", Combo_intermediadorclienteid_Selectedtext_set);
         AV21ComboIntermediadorClienteId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV21ComboIntermediadorClienteId", StringUtil.LTrimStr( (decimal)(AV21ComboIntermediadorClienteId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_intermediadorclienteid_Enabled = false;
            ucCombo_intermediadorclienteid.SendProperty(context, "", false, Combo_intermediadorclienteid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_intermediadorclienteid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCLIENTEID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new financiamentoloaddvcombo(context ).execute(  "ClienteId",  Gx_mode,  false,  AV7FinanciamentoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_clienteid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "SelectedValue_set", Combo_clienteid_Selectedvalue_set);
         Combo_clienteid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "SelectedText_set", Combo_clienteid_Selectedtext_set);
         AV19ComboClienteId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV19ComboClienteId", StringUtil.LTrimStr( (decimal)(AV19ComboClienteId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_clienteid_Enabled = false;
            ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_clienteid_Enabled));
         }
      }

      protected void ZM0W35( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z224FinanciamentoValor = T000W3_A224FinanciamentoValor[0];
               Z225FinanciamentoStatus = T000W3_A225FinanciamentoStatus[0];
               Z168ClienteId = T000W3_A168ClienteId[0];
               Z220IntermediadorClienteId = T000W3_A220IntermediadorClienteId[0];
            }
            else
            {
               Z224FinanciamentoValor = A224FinanciamentoValor;
               Z225FinanciamentoStatus = A225FinanciamentoStatus;
               Z168ClienteId = A168ClienteId;
               Z220IntermediadorClienteId = A220IntermediadorClienteId;
            }
         }
         if ( GX_JID == -12 )
         {
            Z223FinanciamentoId = A223FinanciamentoId;
            Z224FinanciamentoValor = A224FinanciamentoValor;
            Z225FinanciamentoStatus = A225FinanciamentoStatus;
            Z168ClienteId = A168ClienteId;
            Z220IntermediadorClienteId = A220IntermediadorClienteId;
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
            Z169ClienteDocumento = A169ClienteDocumento;
            Z221IntermediadorClienteRazaoSocial = A221IntermediadorClienteRazaoSocial;
            Z222IntermediadorClienteDocumento = A222IntermediadorClienteDocumento;
         }
      }

      protected void standaloneNotModal( )
      {
         edtFinanciamentoId_Enabled = 0;
         AssignProp("", false, edtFinanciamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFinanciamentoId_Enabled), 5, 0), true);
         AV23Pgmname = "Financiamento";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         edtFinanciamentoId_Enabled = 0;
         AssignProp("", false, edtFinanciamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFinanciamentoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7FinanciamentoId) )
         {
            A223FinanciamentoId = AV7FinanciamentoId;
            AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
         {
            edtClienteId_Enabled = 0;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
         else
         {
            edtClienteId_Enabled = 1;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_IntermediadorClienteId) )
         {
            edtIntermediadorClienteId_Enabled = 0;
            AssignProp("", false, edtIntermediadorClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIntermediadorClienteId_Enabled), 5, 0), true);
         }
         else
         {
            edtIntermediadorClienteId_Enabled = 1;
            AssignProp("", false, edtIntermediadorClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIntermediadorClienteId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
         {
            A168ClienteId = AV11Insert_ClienteId;
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboClienteId) )
            {
               A168ClienteId = 0;
               n168ClienteId = false;
               AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
               n168ClienteId = true;
               n168ClienteId = true;
               AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboClienteId) )
               {
                  A168ClienteId = AV19ComboClienteId;
                  n168ClienteId = false;
                  AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_IntermediadorClienteId) )
         {
            A220IntermediadorClienteId = AV12Insert_IntermediadorClienteId;
            n220IntermediadorClienteId = false;
            AssignAttri("", false, "A220IntermediadorClienteId", ((0==A220IntermediadorClienteId)&&IsIns( )||n220IntermediadorClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV21ComboIntermediadorClienteId) )
            {
               A220IntermediadorClienteId = 0;
               n220IntermediadorClienteId = false;
               AssignAttri("", false, "A220IntermediadorClienteId", ((0==A220IntermediadorClienteId)&&IsIns( )||n220IntermediadorClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ".", ""))));
               n220IntermediadorClienteId = true;
               n220IntermediadorClienteId = true;
               AssignAttri("", false, "A220IntermediadorClienteId", ((0==A220IntermediadorClienteId)&&IsIns( )||n220IntermediadorClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV21ComboIntermediadorClienteId) )
               {
                  A220IntermediadorClienteId = AV21ComboIntermediadorClienteId;
                  n220IntermediadorClienteId = false;
                  AssignAttri("", false, "A220IntermediadorClienteId", ((0==A220IntermediadorClienteId)&&IsIns( )||n220IntermediadorClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ".", ""))));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000W4 */
            pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
            A170ClienteRazaoSocial = T000W4_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = T000W4_n170ClienteRazaoSocial[0];
            AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
            A169ClienteDocumento = T000W4_A169ClienteDocumento[0];
            n169ClienteDocumento = T000W4_n169ClienteDocumento[0];
            pr_default.close(2);
            /* Using cursor T000W5 */
            pr_default.execute(3, new Object[] {n220IntermediadorClienteId, A220IntermediadorClienteId});
            A221IntermediadorClienteRazaoSocial = T000W5_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = T000W5_n221IntermediadorClienteRazaoSocial[0];
            AssignAttri("", false, "A221IntermediadorClienteRazaoSocial", A221IntermediadorClienteRazaoSocial);
            A222IntermediadorClienteDocumento = T000W5_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = T000W5_n222IntermediadorClienteDocumento[0];
            pr_default.close(3);
         }
      }

      protected void Load0W35( )
      {
         /* Using cursor T000W6 */
         pr_default.execute(4, new Object[] {A223FinanciamentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound35 = 1;
            A170ClienteRazaoSocial = T000W6_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = T000W6_n170ClienteRazaoSocial[0];
            AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
            A169ClienteDocumento = T000W6_A169ClienteDocumento[0];
            n169ClienteDocumento = T000W6_n169ClienteDocumento[0];
            A224FinanciamentoValor = T000W6_A224FinanciamentoValor[0];
            n224FinanciamentoValor = T000W6_n224FinanciamentoValor[0];
            AssignAttri("", false, "A224FinanciamentoValor", ((Convert.ToDecimal(0)==A224FinanciamentoValor)&&IsIns( )||n224FinanciamentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A224FinanciamentoValor, 18, 2, ".", ""))));
            A225FinanciamentoStatus = T000W6_A225FinanciamentoStatus[0];
            n225FinanciamentoStatus = T000W6_n225FinanciamentoStatus[0];
            A221IntermediadorClienteRazaoSocial = T000W6_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = T000W6_n221IntermediadorClienteRazaoSocial[0];
            AssignAttri("", false, "A221IntermediadorClienteRazaoSocial", A221IntermediadorClienteRazaoSocial);
            A222IntermediadorClienteDocumento = T000W6_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = T000W6_n222IntermediadorClienteDocumento[0];
            A168ClienteId = T000W6_A168ClienteId[0];
            n168ClienteId = T000W6_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A220IntermediadorClienteId = T000W6_A220IntermediadorClienteId[0];
            n220IntermediadorClienteId = T000W6_n220IntermediadorClienteId[0];
            AssignAttri("", false, "A220IntermediadorClienteId", ((0==A220IntermediadorClienteId)&&IsIns( )||n220IntermediadorClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ".", ""))));
            ZM0W35( -12) ;
         }
         pr_default.close(4);
         OnLoadActions0W35( ) ;
      }

      protected void OnLoadActions0W35( )
      {
      }

      protected void CheckExtendedTable0W35( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000W4 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A170ClienteRazaoSocial = T000W4_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = T000W4_n170ClienteRazaoSocial[0];
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         A169ClienteDocumento = T000W4_A169ClienteDocumento[0];
         n169ClienteDocumento = T000W4_n169ClienteDocumento[0];
         pr_default.close(2);
         if ( ( A224FinanciamentoValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "FINANCIAMENTOVALOR");
            AnyError = 1;
            GX_FocusControl = edtFinanciamentoValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000W5 */
         pr_default.execute(3, new Object[] {n220IntermediadorClienteId, A220IntermediadorClienteId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A220IntermediadorClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'SBFin Cli Int'.", "ForeignKeyNotFound", 1, "INTERMEDIADORCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtIntermediadorClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A221IntermediadorClienteRazaoSocial = T000W5_A221IntermediadorClienteRazaoSocial[0];
         n221IntermediadorClienteRazaoSocial = T000W5_n221IntermediadorClienteRazaoSocial[0];
         AssignAttri("", false, "A221IntermediadorClienteRazaoSocial", A221IntermediadorClienteRazaoSocial);
         A222IntermediadorClienteDocumento = T000W5_A222IntermediadorClienteDocumento[0];
         n222IntermediadorClienteDocumento = T000W5_n222IntermediadorClienteDocumento[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0W35( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( int A168ClienteId )
      {
         /* Using cursor T000W7 */
         pr_default.execute(5, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A170ClienteRazaoSocial = T000W7_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = T000W7_n170ClienteRazaoSocial[0];
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         A169ClienteDocumento = T000W7_A169ClienteDocumento[0];
         n169ClienteDocumento = T000W7_n169ClienteDocumento[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A170ClienteRazaoSocial)+"\""+","+"\""+GXUtil.EncodeJSConstant( A169ClienteDocumento)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_14( int A220IntermediadorClienteId )
      {
         /* Using cursor T000W8 */
         pr_default.execute(6, new Object[] {n220IntermediadorClienteId, A220IntermediadorClienteId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A220IntermediadorClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'SBFin Cli Int'.", "ForeignKeyNotFound", 1, "INTERMEDIADORCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtIntermediadorClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A221IntermediadorClienteRazaoSocial = T000W8_A221IntermediadorClienteRazaoSocial[0];
         n221IntermediadorClienteRazaoSocial = T000W8_n221IntermediadorClienteRazaoSocial[0];
         AssignAttri("", false, "A221IntermediadorClienteRazaoSocial", A221IntermediadorClienteRazaoSocial);
         A222IntermediadorClienteDocumento = T000W8_A222IntermediadorClienteDocumento[0];
         n222IntermediadorClienteDocumento = T000W8_n222IntermediadorClienteDocumento[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A221IntermediadorClienteRazaoSocial)+"\""+","+"\""+GXUtil.EncodeJSConstant( A222IntermediadorClienteDocumento)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0W35( )
      {
         /* Using cursor T000W9 */
         pr_default.execute(7, new Object[] {A223FinanciamentoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound35 = 1;
         }
         else
         {
            RcdFound35 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000W3 */
         pr_default.execute(1, new Object[] {A223FinanciamentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0W35( 12) ;
            RcdFound35 = 1;
            A223FinanciamentoId = T000W3_A223FinanciamentoId[0];
            AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
            A224FinanciamentoValor = T000W3_A224FinanciamentoValor[0];
            n224FinanciamentoValor = T000W3_n224FinanciamentoValor[0];
            AssignAttri("", false, "A224FinanciamentoValor", ((Convert.ToDecimal(0)==A224FinanciamentoValor)&&IsIns( )||n224FinanciamentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A224FinanciamentoValor, 18, 2, ".", ""))));
            A225FinanciamentoStatus = T000W3_A225FinanciamentoStatus[0];
            n225FinanciamentoStatus = T000W3_n225FinanciamentoStatus[0];
            A168ClienteId = T000W3_A168ClienteId[0];
            n168ClienteId = T000W3_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A220IntermediadorClienteId = T000W3_A220IntermediadorClienteId[0];
            n220IntermediadorClienteId = T000W3_n220IntermediadorClienteId[0];
            AssignAttri("", false, "A220IntermediadorClienteId", ((0==A220IntermediadorClienteId)&&IsIns( )||n220IntermediadorClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ".", ""))));
            Z223FinanciamentoId = A223FinanciamentoId;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0W35( ) ;
            if ( AnyError == 1 )
            {
               RcdFound35 = 0;
               InitializeNonKey0W35( ) ;
            }
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound35 = 0;
            InitializeNonKey0W35( ) ;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0W35( ) ;
         if ( RcdFound35 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound35 = 0;
         /* Using cursor T000W10 */
         pr_default.execute(8, new Object[] {A223FinanciamentoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000W10_A223FinanciamentoId[0] < A223FinanciamentoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000W10_A223FinanciamentoId[0] > A223FinanciamentoId ) ) )
            {
               A223FinanciamentoId = T000W10_A223FinanciamentoId[0];
               AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
               RcdFound35 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound35 = 0;
         /* Using cursor T000W11 */
         pr_default.execute(9, new Object[] {A223FinanciamentoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000W11_A223FinanciamentoId[0] > A223FinanciamentoId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000W11_A223FinanciamentoId[0] < A223FinanciamentoId ) ) )
            {
               A223FinanciamentoId = T000W11_A223FinanciamentoId[0];
               AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
               RcdFound35 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0W35( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0W35( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound35 == 1 )
            {
               if ( A223FinanciamentoId != Z223FinanciamentoId )
               {
                  A223FinanciamentoId = Z223FinanciamentoId;
                  AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FINANCIAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtFinanciamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0W35( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A223FinanciamentoId != Z223FinanciamentoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0W35( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FINANCIAMENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtFinanciamentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtClienteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0W35( ) ;
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
         if ( A223FinanciamentoId != Z223FinanciamentoId )
         {
            A223FinanciamentoId = Z223FinanciamentoId;
            AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FINANCIAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtFinanciamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0W35( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000W2 */
            pr_default.execute(0, new Object[] {A223FinanciamentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Financiamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z224FinanciamentoValor != T000W2_A224FinanciamentoValor[0] ) || ( StringUtil.StrCmp(Z225FinanciamentoStatus, T000W2_A225FinanciamentoStatus[0]) != 0 ) || ( Z168ClienteId != T000W2_A168ClienteId[0] ) || ( Z220IntermediadorClienteId != T000W2_A220IntermediadorClienteId[0] ) )
            {
               if ( Z224FinanciamentoValor != T000W2_A224FinanciamentoValor[0] )
               {
                  GXUtil.WriteLog("financiamento:[seudo value changed for attri]"+"FinanciamentoValor");
                  GXUtil.WriteLogRaw("Old: ",Z224FinanciamentoValor);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A224FinanciamentoValor[0]);
               }
               if ( StringUtil.StrCmp(Z225FinanciamentoStatus, T000W2_A225FinanciamentoStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("financiamento:[seudo value changed for attri]"+"FinanciamentoStatus");
                  GXUtil.WriteLogRaw("Old: ",Z225FinanciamentoStatus);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A225FinanciamentoStatus[0]);
               }
               if ( Z168ClienteId != T000W2_A168ClienteId[0] )
               {
                  GXUtil.WriteLog("financiamento:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z168ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A168ClienteId[0]);
               }
               if ( Z220IntermediadorClienteId != T000W2_A220IntermediadorClienteId[0] )
               {
                  GXUtil.WriteLog("financiamento:[seudo value changed for attri]"+"IntermediadorClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z220IntermediadorClienteId);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A220IntermediadorClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Financiamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W35( )
      {
         BeforeValidate0W35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W35( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W35( 0) ;
            CheckOptimisticConcurrency0W35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W12 */
                     pr_default.execute(10, new Object[] {n224FinanciamentoValor, A224FinanciamentoValor, n225FinanciamentoStatus, A225FinanciamentoStatus, n168ClienteId, A168ClienteId, n220IntermediadorClienteId, A220IntermediadorClienteId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000W13 */
                     pr_default.execute(11);
                     A223FinanciamentoId = T000W13_A223FinanciamentoId[0];
                     AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Financiamento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0W0( ) ;
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
               Load0W35( ) ;
            }
            EndLevel0W35( ) ;
         }
         CloseExtendedTableCursors0W35( ) ;
      }

      protected void Update0W35( )
      {
         BeforeValidate0W35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W35( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W14 */
                     pr_default.execute(12, new Object[] {n224FinanciamentoValor, A224FinanciamentoValor, n225FinanciamentoStatus, A225FinanciamentoStatus, n168ClienteId, A168ClienteId, n220IntermediadorClienteId, A220IntermediadorClienteId, A223FinanciamentoId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Financiamento");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Financiamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W35( ) ;
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
            EndLevel0W35( ) ;
         }
         CloseExtendedTableCursors0W35( ) ;
      }

      protected void DeferredUpdate0W35( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0W35( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W35( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W35( ) ;
            AfterConfirm0W35( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W35( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000W15 */
                  pr_default.execute(13, new Object[] {A223FinanciamentoId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("Financiamento");
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
         sMode35 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0W35( ) ;
         Gx_mode = sMode35;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0W35( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000W16 */
            pr_default.execute(14, new Object[] {n168ClienteId, A168ClienteId});
            A170ClienteRazaoSocial = T000W16_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = T000W16_n170ClienteRazaoSocial[0];
            AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
            A169ClienteDocumento = T000W16_A169ClienteDocumento[0];
            n169ClienteDocumento = T000W16_n169ClienteDocumento[0];
            pr_default.close(14);
            /* Using cursor T000W17 */
            pr_default.execute(15, new Object[] {n220IntermediadorClienteId, A220IntermediadorClienteId});
            A221IntermediadorClienteRazaoSocial = T000W17_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = T000W17_n221IntermediadorClienteRazaoSocial[0];
            AssignAttri("", false, "A221IntermediadorClienteRazaoSocial", A221IntermediadorClienteRazaoSocial);
            A222IntermediadorClienteDocumento = T000W17_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = T000W17_n222IntermediadorClienteDocumento[0];
            pr_default.close(15);
         }
      }

      protected void EndLevel0W35( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0W35( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues0W0( ) ;
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

      public void ScanStart0W35( )
      {
         /* Scan By routine */
         /* Using cursor T000W18 */
         pr_default.execute(16);
         RcdFound35 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound35 = 1;
            A223FinanciamentoId = T000W18_A223FinanciamentoId[0];
            AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0W35( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound35 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound35 = 1;
            A223FinanciamentoId = T000W18_A223FinanciamentoId[0];
            AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
         }
      }

      protected void ScanEnd0W35( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0W35( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W35( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W35( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W35( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W35( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W35( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W35( )
      {
         edtFinanciamentoId_Enabled = 0;
         AssignProp("", false, edtFinanciamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFinanciamentoId_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtClienteRazaoSocial_Enabled = 0;
         AssignProp("", false, edtClienteRazaoSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteRazaoSocial_Enabled), 5, 0), true);
         edtFinanciamentoValor_Enabled = 0;
         AssignProp("", false, edtFinanciamentoValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFinanciamentoValor_Enabled), 5, 0), true);
         edtIntermediadorClienteId_Enabled = 0;
         AssignProp("", false, edtIntermediadorClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIntermediadorClienteId_Enabled), 5, 0), true);
         edtIntermediadorClienteRazaoSocial_Enabled = 0;
         AssignProp("", false, edtIntermediadorClienteRazaoSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIntermediadorClienteRazaoSocial_Enabled), 5, 0), true);
         edtavComboclienteid_Enabled = 0;
         AssignProp("", false, edtavComboclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboclienteid_Enabled), 5, 0), true);
         edtavCombointermediadorclienteid_Enabled = 0;
         AssignProp("", false, edtavCombointermediadorclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombointermediadorclienteid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0W35( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0W0( )
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
         GXEncryptionTmp = "financiamento"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7FinanciamentoId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("financiamento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Financiamento");
         forbiddenHiddens.Add("FinanciamentoId", context.localUtil.Format( (decimal)(A223FinanciamentoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ClienteId", context.localUtil.Format( (decimal)(AV11Insert_ClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_IntermediadorClienteId", context.localUtil.Format( (decimal)(AV12Insert_IntermediadorClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("FinanciamentoStatus", StringUtil.RTrim( context.localUtil.Format( A225FinanciamentoStatus, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("financiamento:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z223FinanciamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z223FinanciamentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z224FinanciamentoValor", StringUtil.LTrim( StringUtil.NToC( Z224FinanciamentoValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z225FinanciamentoStatus", Z225FinanciamentoStatus);
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z220IntermediadorClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z220IntermediadorClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N220IntermediadorClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ",", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTEID_DATA", AV14ClienteId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTEID_DATA", AV14ClienteId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vINTERMEDIADORCLIENTEID_DATA", AV20IntermediadorClienteId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vINTERMEDIADORCLIENTEID_DATA", AV20IntermediadorClienteId_Data);
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
         GxWebStd.gx_hidden_field( context, "vFINANCIAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7FinanciamentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFINANCIAMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FinanciamentoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_INTERMEDIADORCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_IntermediadorClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "FINANCIAMENTOSTATUS", A225FinanciamentoStatus);
         GxWebStd.gx_hidden_field( context, "CLIENTEDOCUMENTO", A169ClienteDocumento);
         GxWebStd.gx_hidden_field( context, "INTERMEDIADORCLIENTEDOCUMENTO", A222IntermediadorClienteDocumento);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Objectcall", StringUtil.RTrim( Combo_clienteid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Cls", StringUtil.RTrim( Combo_clienteid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Selectedvalue_set", StringUtil.RTrim( Combo_clienteid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Selectedtext_set", StringUtil.RTrim( Combo_clienteid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Enabled", StringUtil.BoolToStr( Combo_clienteid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Datalistproc", StringUtil.RTrim( Combo_clienteid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_clienteid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_INTERMEDIADORCLIENTEID_Objectcall", StringUtil.RTrim( Combo_intermediadorclienteid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_INTERMEDIADORCLIENTEID_Cls", StringUtil.RTrim( Combo_intermediadorclienteid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_INTERMEDIADORCLIENTEID_Selectedvalue_set", StringUtil.RTrim( Combo_intermediadorclienteid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_INTERMEDIADORCLIENTEID_Selectedtext_set", StringUtil.RTrim( Combo_intermediadorclienteid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_INTERMEDIADORCLIENTEID_Enabled", StringUtil.BoolToStr( Combo_intermediadorclienteid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_INTERMEDIADORCLIENTEID_Datalistproc", StringUtil.RTrim( Combo_intermediadorclienteid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_INTERMEDIADORCLIENTEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_intermediadorclienteid_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "financiamento"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7FinanciamentoId,9,0));
         return formatLink("financiamento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Financiamento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Financiamento" ;
      }

      protected void InitializeNonKey0W35( )
      {
         A168ClienteId = 0;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         n168ClienteId = ((0==A168ClienteId) ? true : false);
         A220IntermediadorClienteId = 0;
         n220IntermediadorClienteId = false;
         AssignAttri("", false, "A220IntermediadorClienteId", ((0==A220IntermediadorClienteId)&&IsIns( )||n220IntermediadorClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ".", ""))));
         n220IntermediadorClienteId = ((0==A220IntermediadorClienteId) ? true : false);
         A170ClienteRazaoSocial = "";
         n170ClienteRazaoSocial = false;
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         A169ClienteDocumento = "";
         n169ClienteDocumento = false;
         AssignAttri("", false, "A169ClienteDocumento", A169ClienteDocumento);
         A224FinanciamentoValor = 0;
         n224FinanciamentoValor = false;
         AssignAttri("", false, "A224FinanciamentoValor", ((Convert.ToDecimal(0)==A224FinanciamentoValor)&&IsIns( )||n224FinanciamentoValor ? "" : StringUtil.LTrim( StringUtil.NToC( A224FinanciamentoValor, 18, 2, ".", ""))));
         n224FinanciamentoValor = ((Convert.ToDecimal(0)==A224FinanciamentoValor) ? true : false);
         A225FinanciamentoStatus = "";
         n225FinanciamentoStatus = false;
         AssignAttri("", false, "A225FinanciamentoStatus", A225FinanciamentoStatus);
         A221IntermediadorClienteRazaoSocial = "";
         n221IntermediadorClienteRazaoSocial = false;
         AssignAttri("", false, "A221IntermediadorClienteRazaoSocial", A221IntermediadorClienteRazaoSocial);
         A222IntermediadorClienteDocumento = "";
         n222IntermediadorClienteDocumento = false;
         AssignAttri("", false, "A222IntermediadorClienteDocumento", A222IntermediadorClienteDocumento);
         Z224FinanciamentoValor = 0;
         Z225FinanciamentoStatus = "";
         Z168ClienteId = 0;
         Z220IntermediadorClienteId = 0;
      }

      protected void InitAll0W35( )
      {
         A223FinanciamentoId = 0;
         AssignAttri("", false, "A223FinanciamentoId", StringUtil.LTrimStr( (decimal)(A223FinanciamentoId), 9, 0));
         InitializeNonKey0W35( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019134673", true, true);
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
         context.AddJavascriptSource("financiamento.js", "?202561019134673", false, true);
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
         edtFinanciamentoId_Internalname = "FINANCIAMENTOID";
         lblTextblockclienteid_Internalname = "TEXTBLOCKCLIENTEID";
         Combo_clienteid_Internalname = "COMBO_CLIENTEID";
         edtClienteId_Internalname = "CLIENTEID";
         divTablesplittedclienteid_Internalname = "TABLESPLITTEDCLIENTEID";
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL";
         edtFinanciamentoValor_Internalname = "FINANCIAMENTOVALOR";
         lblTextblockintermediadorclienteid_Internalname = "TEXTBLOCKINTERMEDIADORCLIENTEID";
         Combo_intermediadorclienteid_Internalname = "COMBO_INTERMEDIADORCLIENTEID";
         edtIntermediadorClienteId_Internalname = "INTERMEDIADORCLIENTEID";
         divTablesplittedintermediadorclienteid_Internalname = "TABLESPLITTEDINTERMEDIADORCLIENTEID";
         edtIntermediadorClienteRazaoSocial_Internalname = "INTERMEDIADORCLIENTERAZAOSOCIAL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboclienteid_Internalname = "vCOMBOCLIENTEID";
         divSectionattribute_clienteid_Internalname = "SECTIONATTRIBUTE_CLIENTEID";
         edtavCombointermediadorclienteid_Internalname = "vCOMBOINTERMEDIADORCLIENTEID";
         divSectionattribute_intermediadorclienteid_Internalname = "SECTIONATTRIBUTE_INTERMEDIADORCLIENTEID";
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
         Form.Caption = "Financiamento";
         edtavCombointermediadorclienteid_Jsonclick = "";
         edtavCombointermediadorclienteid_Enabled = 0;
         edtavCombointermediadorclienteid_Visible = 1;
         edtavComboclienteid_Jsonclick = "";
         edtavComboclienteid_Enabled = 0;
         edtavComboclienteid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtIntermediadorClienteRazaoSocial_Jsonclick = "";
         edtIntermediadorClienteRazaoSocial_Enabled = 0;
         edtIntermediadorClienteId_Jsonclick = "";
         edtIntermediadorClienteId_Enabled = 1;
         edtIntermediadorClienteId_Visible = 1;
         Combo_intermediadorclienteid_Datalistprocparametersprefix = " \"ComboName\": \"IntermediadorClienteId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"FinanciamentoId\": 0";
         Combo_intermediadorclienteid_Datalistproc = "FinanciamentoLoadDVCombo";
         Combo_intermediadorclienteid_Cls = "ExtendedCombo AttributeFL";
         Combo_intermediadorclienteid_Caption = "";
         Combo_intermediadorclienteid_Enabled = Convert.ToBoolean( -1);
         edtFinanciamentoValor_Jsonclick = "";
         edtFinanciamentoValor_Enabled = 1;
         edtClienteRazaoSocial_Jsonclick = "";
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtClienteId_Visible = 1;
         Combo_clienteid_Datalistprocparametersprefix = " \"ComboName\": \"ClienteId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"FinanciamentoId\": 0";
         Combo_clienteid_Datalistproc = "FinanciamentoLoadDVCombo";
         Combo_clienteid_Cls = "ExtendedCombo AttributeFL";
         Combo_clienteid_Caption = "";
         Combo_clienteid_Enabled = Convert.ToBoolean( -1);
         edtFinanciamentoId_Jsonclick = "";
         edtFinanciamentoId_Enabled = 0;
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

      public void Valid_Clienteid( )
      {
         n170ClienteRazaoSocial = false;
         n169ClienteDocumento = false;
         /* Using cursor T000W16 */
         pr_default.execute(14, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
            }
         }
         A170ClienteRazaoSocial = T000W16_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = T000W16_n170ClienteRazaoSocial[0];
         A169ClienteDocumento = T000W16_A169ClienteDocumento[0];
         n169ClienteDocumento = T000W16_n169ClienteDocumento[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         AssignAttri("", false, "A169ClienteDocumento", A169ClienteDocumento);
      }

      public void Valid_Intermediadorclienteid( )
      {
         n221IntermediadorClienteRazaoSocial = false;
         n222IntermediadorClienteDocumento = false;
         /* Using cursor T000W17 */
         pr_default.execute(15, new Object[] {n220IntermediadorClienteId, A220IntermediadorClienteId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A220IntermediadorClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'SBFin Cli Int'.", "ForeignKeyNotFound", 1, "INTERMEDIADORCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtIntermediadorClienteId_Internalname;
            }
         }
         A221IntermediadorClienteRazaoSocial = T000W17_A221IntermediadorClienteRazaoSocial[0];
         n221IntermediadorClienteRazaoSocial = T000W17_n221IntermediadorClienteRazaoSocial[0];
         A222IntermediadorClienteDocumento = T000W17_A222IntermediadorClienteDocumento[0];
         n222IntermediadorClienteDocumento = T000W17_n222IntermediadorClienteDocumento[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A221IntermediadorClienteRazaoSocial", A221IntermediadorClienteRazaoSocial);
         AssignAttri("", false, "A222IntermediadorClienteDocumento", A222IntermediadorClienteDocumento);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7FinanciamentoId","fld":"vFINANCIAMENTOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7FinanciamentoId","fld":"vFINANCIAMENTOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A223FinanciamentoId","fld":"FINANCIAMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_ClienteId","fld":"vINSERT_CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_IntermediadorClienteId","fld":"vINSERT_INTERMEDIADORCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A225FinanciamentoStatus","fld":"FINANCIAMENTOSTATUS","type":"svchar"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120W2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_FINANCIAMENTOID","""{"handler":"Valid_Financiamentoid","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"}]""");
         setEventMetadata("VALID_CLIENTEID",""","oparms":[{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"}]}""");
         setEventMetadata("VALID_FINANCIAMENTOVALOR","""{"handler":"Valid_Financiamentovalor","iparms":[]}""");
         setEventMetadata("VALID_INTERMEDIADORCLIENTEID","""{"handler":"Valid_Intermediadorclienteid","iparms":[{"av":"A220IntermediadorClienteId","fld":"INTERMEDIADORCLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n220IntermediadorClienteId","type":"int"},{"av":"A221IntermediadorClienteRazaoSocial","fld":"INTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A222IntermediadorClienteDocumento","fld":"INTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"}]""");
         setEventMetadata("VALID_INTERMEDIADORCLIENTEID",""","oparms":[{"av":"A221IntermediadorClienteRazaoSocial","fld":"INTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A222IntermediadorClienteDocumento","fld":"INTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"}]}""");
         setEventMetadata("VALIDV_COMBOCLIENTEID","""{"handler":"Validv_Comboclienteid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOINTERMEDIADORCLIENTEID","""{"handler":"Validv_Combointermediadorclienteid","iparms":[]}""");
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
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z225FinanciamentoStatus = "";
         Combo_intermediadorclienteid_Selectedvalue_get = "";
         Combo_clienteid_Selectedvalue_get = "";
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
         lblTextblockclienteid_Jsonclick = "";
         ucCombo_clienteid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14ClienteId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A170ClienteRazaoSocial = "";
         lblTextblockintermediadorclienteid_Jsonclick = "";
         ucCombo_intermediadorclienteid = new GXUserControl();
         AV20IntermediadorClienteId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A221IntermediadorClienteRazaoSocial = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A225FinanciamentoStatus = "";
         A169ClienteDocumento = "";
         A222IntermediadorClienteDocumento = "";
         AV23Pgmname = "";
         Combo_clienteid_Objectcall = "";
         Combo_clienteid_Class = "";
         Combo_clienteid_Icontype = "";
         Combo_clienteid_Icon = "";
         Combo_clienteid_Tooltip = "";
         Combo_clienteid_Selectedvalue_set = "";
         Combo_clienteid_Selectedtext_set = "";
         Combo_clienteid_Selectedtext_get = "";
         Combo_clienteid_Gamoauthtoken = "";
         Combo_clienteid_Ddointernalname = "";
         Combo_clienteid_Titlecontrolalign = "";
         Combo_clienteid_Dropdownoptionstype = "";
         Combo_clienteid_Titlecontrolidtoreplace = "";
         Combo_clienteid_Datalisttype = "";
         Combo_clienteid_Datalistfixedvalues = "";
         Combo_clienteid_Remoteservicesparameters = "";
         Combo_clienteid_Htmltemplate = "";
         Combo_clienteid_Multiplevaluestype = "";
         Combo_clienteid_Loadingdata = "";
         Combo_clienteid_Noresultsfound = "";
         Combo_clienteid_Emptyitemtext = "";
         Combo_clienteid_Onlyselectedvalues = "";
         Combo_clienteid_Selectalltext = "";
         Combo_clienteid_Multiplevaluesseparator = "";
         Combo_clienteid_Addnewoptiontext = "";
         Combo_intermediadorclienteid_Objectcall = "";
         Combo_intermediadorclienteid_Class = "";
         Combo_intermediadorclienteid_Icontype = "";
         Combo_intermediadorclienteid_Icon = "";
         Combo_intermediadorclienteid_Tooltip = "";
         Combo_intermediadorclienteid_Selectedvalue_set = "";
         Combo_intermediadorclienteid_Selectedtext_set = "";
         Combo_intermediadorclienteid_Selectedtext_get = "";
         Combo_intermediadorclienteid_Gamoauthtoken = "";
         Combo_intermediadorclienteid_Ddointernalname = "";
         Combo_intermediadorclienteid_Titlecontrolalign = "";
         Combo_intermediadorclienteid_Dropdownoptionstype = "";
         Combo_intermediadorclienteid_Titlecontrolidtoreplace = "";
         Combo_intermediadorclienteid_Datalisttype = "";
         Combo_intermediadorclienteid_Datalistfixedvalues = "";
         Combo_intermediadorclienteid_Remoteservicesparameters = "";
         Combo_intermediadorclienteid_Htmltemplate = "";
         Combo_intermediadorclienteid_Multiplevaluestype = "";
         Combo_intermediadorclienteid_Loadingdata = "";
         Combo_intermediadorclienteid_Noresultsfound = "";
         Combo_intermediadorclienteid_Emptyitemtext = "";
         Combo_intermediadorclienteid_Onlyselectedvalues = "";
         Combo_intermediadorclienteid_Selectalltext = "";
         Combo_intermediadorclienteid_Multiplevaluesseparator = "";
         Combo_intermediadorclienteid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode35 = "";
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
         Z170ClienteRazaoSocial = "";
         Z169ClienteDocumento = "";
         Z221IntermediadorClienteRazaoSocial = "";
         Z222IntermediadorClienteDocumento = "";
         T000W4_A170ClienteRazaoSocial = new string[] {""} ;
         T000W4_n170ClienteRazaoSocial = new bool[] {false} ;
         T000W4_A169ClienteDocumento = new string[] {""} ;
         T000W4_n169ClienteDocumento = new bool[] {false} ;
         T000W5_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         T000W5_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         T000W5_A222IntermediadorClienteDocumento = new string[] {""} ;
         T000W5_n222IntermediadorClienteDocumento = new bool[] {false} ;
         T000W6_A223FinanciamentoId = new int[1] ;
         T000W6_A170ClienteRazaoSocial = new string[] {""} ;
         T000W6_n170ClienteRazaoSocial = new bool[] {false} ;
         T000W6_A169ClienteDocumento = new string[] {""} ;
         T000W6_n169ClienteDocumento = new bool[] {false} ;
         T000W6_A224FinanciamentoValor = new decimal[1] ;
         T000W6_n224FinanciamentoValor = new bool[] {false} ;
         T000W6_A225FinanciamentoStatus = new string[] {""} ;
         T000W6_n225FinanciamentoStatus = new bool[] {false} ;
         T000W6_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         T000W6_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         T000W6_A222IntermediadorClienteDocumento = new string[] {""} ;
         T000W6_n222IntermediadorClienteDocumento = new bool[] {false} ;
         T000W6_A168ClienteId = new int[1] ;
         T000W6_n168ClienteId = new bool[] {false} ;
         T000W6_A220IntermediadorClienteId = new int[1] ;
         T000W6_n220IntermediadorClienteId = new bool[] {false} ;
         T000W7_A170ClienteRazaoSocial = new string[] {""} ;
         T000W7_n170ClienteRazaoSocial = new bool[] {false} ;
         T000W7_A169ClienteDocumento = new string[] {""} ;
         T000W7_n169ClienteDocumento = new bool[] {false} ;
         T000W8_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         T000W8_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         T000W8_A222IntermediadorClienteDocumento = new string[] {""} ;
         T000W8_n222IntermediadorClienteDocumento = new bool[] {false} ;
         T000W9_A223FinanciamentoId = new int[1] ;
         T000W3_A223FinanciamentoId = new int[1] ;
         T000W3_A224FinanciamentoValor = new decimal[1] ;
         T000W3_n224FinanciamentoValor = new bool[] {false} ;
         T000W3_A225FinanciamentoStatus = new string[] {""} ;
         T000W3_n225FinanciamentoStatus = new bool[] {false} ;
         T000W3_A168ClienteId = new int[1] ;
         T000W3_n168ClienteId = new bool[] {false} ;
         T000W3_A220IntermediadorClienteId = new int[1] ;
         T000W3_n220IntermediadorClienteId = new bool[] {false} ;
         T000W10_A223FinanciamentoId = new int[1] ;
         T000W11_A223FinanciamentoId = new int[1] ;
         T000W2_A223FinanciamentoId = new int[1] ;
         T000W2_A224FinanciamentoValor = new decimal[1] ;
         T000W2_n224FinanciamentoValor = new bool[] {false} ;
         T000W2_A225FinanciamentoStatus = new string[] {""} ;
         T000W2_n225FinanciamentoStatus = new bool[] {false} ;
         T000W2_A168ClienteId = new int[1] ;
         T000W2_n168ClienteId = new bool[] {false} ;
         T000W2_A220IntermediadorClienteId = new int[1] ;
         T000W2_n220IntermediadorClienteId = new bool[] {false} ;
         T000W13_A223FinanciamentoId = new int[1] ;
         T000W16_A170ClienteRazaoSocial = new string[] {""} ;
         T000W16_n170ClienteRazaoSocial = new bool[] {false} ;
         T000W16_A169ClienteDocumento = new string[] {""} ;
         T000W16_n169ClienteDocumento = new bool[] {false} ;
         T000W17_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         T000W17_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         T000W17_A222IntermediadorClienteDocumento = new string[] {""} ;
         T000W17_n222IntermediadorClienteDocumento = new bool[] {false} ;
         T000W18_A223FinanciamentoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.financiamento__default(),
            new Object[][] {
                new Object[] {
               T000W2_A223FinanciamentoId, T000W2_A224FinanciamentoValor, T000W2_n224FinanciamentoValor, T000W2_A225FinanciamentoStatus, T000W2_n225FinanciamentoStatus, T000W2_A168ClienteId, T000W2_n168ClienteId, T000W2_A220IntermediadorClienteId, T000W2_n220IntermediadorClienteId
               }
               , new Object[] {
               T000W3_A223FinanciamentoId, T000W3_A224FinanciamentoValor, T000W3_n224FinanciamentoValor, T000W3_A225FinanciamentoStatus, T000W3_n225FinanciamentoStatus, T000W3_A168ClienteId, T000W3_n168ClienteId, T000W3_A220IntermediadorClienteId, T000W3_n220IntermediadorClienteId
               }
               , new Object[] {
               T000W4_A170ClienteRazaoSocial, T000W4_n170ClienteRazaoSocial, T000W4_A169ClienteDocumento, T000W4_n169ClienteDocumento
               }
               , new Object[] {
               T000W5_A221IntermediadorClienteRazaoSocial, T000W5_n221IntermediadorClienteRazaoSocial, T000W5_A222IntermediadorClienteDocumento, T000W5_n222IntermediadorClienteDocumento
               }
               , new Object[] {
               T000W6_A223FinanciamentoId, T000W6_A170ClienteRazaoSocial, T000W6_n170ClienteRazaoSocial, T000W6_A169ClienteDocumento, T000W6_n169ClienteDocumento, T000W6_A224FinanciamentoValor, T000W6_n224FinanciamentoValor, T000W6_A225FinanciamentoStatus, T000W6_n225FinanciamentoStatus, T000W6_A221IntermediadorClienteRazaoSocial,
               T000W6_n221IntermediadorClienteRazaoSocial, T000W6_A222IntermediadorClienteDocumento, T000W6_n222IntermediadorClienteDocumento, T000W6_A168ClienteId, T000W6_n168ClienteId, T000W6_A220IntermediadorClienteId, T000W6_n220IntermediadorClienteId
               }
               , new Object[] {
               T000W7_A170ClienteRazaoSocial, T000W7_n170ClienteRazaoSocial, T000W7_A169ClienteDocumento, T000W7_n169ClienteDocumento
               }
               , new Object[] {
               T000W8_A221IntermediadorClienteRazaoSocial, T000W8_n221IntermediadorClienteRazaoSocial, T000W8_A222IntermediadorClienteDocumento, T000W8_n222IntermediadorClienteDocumento
               }
               , new Object[] {
               T000W9_A223FinanciamentoId
               }
               , new Object[] {
               T000W10_A223FinanciamentoId
               }
               , new Object[] {
               T000W11_A223FinanciamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               T000W13_A223FinanciamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000W16_A170ClienteRazaoSocial, T000W16_n170ClienteRazaoSocial, T000W16_A169ClienteDocumento, T000W16_n169ClienteDocumento
               }
               , new Object[] {
               T000W17_A221IntermediadorClienteRazaoSocial, T000W17_n221IntermediadorClienteRazaoSocial, T000W17_A222IntermediadorClienteDocumento, T000W17_n222IntermediadorClienteDocumento
               }
               , new Object[] {
               T000W18_A223FinanciamentoId
               }
            }
         );
         AV23Pgmname = "Financiamento";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound35 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7FinanciamentoId ;
      private int Z223FinanciamentoId ;
      private int Z168ClienteId ;
      private int Z220IntermediadorClienteId ;
      private int N168ClienteId ;
      private int N220IntermediadorClienteId ;
      private int A168ClienteId ;
      private int A220IntermediadorClienteId ;
      private int AV7FinanciamentoId ;
      private int trnEnded ;
      private int A223FinanciamentoId ;
      private int edtFinanciamentoId_Enabled ;
      private int edtClienteId_Visible ;
      private int edtClienteId_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtFinanciamentoValor_Enabled ;
      private int edtIntermediadorClienteId_Visible ;
      private int edtIntermediadorClienteId_Enabled ;
      private int edtIntermediadorClienteRazaoSocial_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboClienteId ;
      private int edtavComboclienteid_Enabled ;
      private int edtavComboclienteid_Visible ;
      private int AV21ComboIntermediadorClienteId ;
      private int edtavCombointermediadorclienteid_Enabled ;
      private int edtavCombointermediadorclienteid_Visible ;
      private int AV11Insert_ClienteId ;
      private int AV12Insert_IntermediadorClienteId ;
      private int Combo_clienteid_Datalistupdateminimumcharacters ;
      private int Combo_clienteid_Gxcontroltype ;
      private int Combo_intermediadorclienteid_Datalistupdateminimumcharacters ;
      private int Combo_intermediadorclienteid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV24GXV1 ;
      private int idxLst ;
      private decimal Z224FinanciamentoValor ;
      private decimal A224FinanciamentoValor ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_intermediadorclienteid_Selectedvalue_get ;
      private string Combo_clienteid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtClienteId_Internalname ;
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
      private string edtFinanciamentoId_Internalname ;
      private string TempTags ;
      private string edtFinanciamentoId_Jsonclick ;
      private string divTablesplittedclienteid_Internalname ;
      private string lblTextblockclienteid_Internalname ;
      private string lblTextblockclienteid_Jsonclick ;
      private string Combo_clienteid_Caption ;
      private string Combo_clienteid_Cls ;
      private string Combo_clienteid_Datalistproc ;
      private string Combo_clienteid_Datalistprocparametersprefix ;
      private string Combo_clienteid_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtFinanciamentoValor_Internalname ;
      private string edtFinanciamentoValor_Jsonclick ;
      private string divTablesplittedintermediadorclienteid_Internalname ;
      private string lblTextblockintermediadorclienteid_Internalname ;
      private string lblTextblockintermediadorclienteid_Jsonclick ;
      private string Combo_intermediadorclienteid_Caption ;
      private string Combo_intermediadorclienteid_Cls ;
      private string Combo_intermediadorclienteid_Datalistproc ;
      private string Combo_intermediadorclienteid_Datalistprocparametersprefix ;
      private string Combo_intermediadorclienteid_Internalname ;
      private string edtIntermediadorClienteId_Internalname ;
      private string edtIntermediadorClienteId_Jsonclick ;
      private string edtIntermediadorClienteRazaoSocial_Internalname ;
      private string edtIntermediadorClienteRazaoSocial_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_clienteid_Internalname ;
      private string edtavComboclienteid_Internalname ;
      private string edtavComboclienteid_Jsonclick ;
      private string divSectionattribute_intermediadorclienteid_Internalname ;
      private string edtavCombointermediadorclienteid_Internalname ;
      private string edtavCombointermediadorclienteid_Jsonclick ;
      private string AV23Pgmname ;
      private string Combo_clienteid_Objectcall ;
      private string Combo_clienteid_Class ;
      private string Combo_clienteid_Icontype ;
      private string Combo_clienteid_Icon ;
      private string Combo_clienteid_Tooltip ;
      private string Combo_clienteid_Selectedvalue_set ;
      private string Combo_clienteid_Selectedtext_set ;
      private string Combo_clienteid_Selectedtext_get ;
      private string Combo_clienteid_Gamoauthtoken ;
      private string Combo_clienteid_Ddointernalname ;
      private string Combo_clienteid_Titlecontrolalign ;
      private string Combo_clienteid_Dropdownoptionstype ;
      private string Combo_clienteid_Titlecontrolidtoreplace ;
      private string Combo_clienteid_Datalisttype ;
      private string Combo_clienteid_Datalistfixedvalues ;
      private string Combo_clienteid_Remoteservicesparameters ;
      private string Combo_clienteid_Htmltemplate ;
      private string Combo_clienteid_Multiplevaluestype ;
      private string Combo_clienteid_Loadingdata ;
      private string Combo_clienteid_Noresultsfound ;
      private string Combo_clienteid_Emptyitemtext ;
      private string Combo_clienteid_Onlyselectedvalues ;
      private string Combo_clienteid_Selectalltext ;
      private string Combo_clienteid_Multiplevaluesseparator ;
      private string Combo_clienteid_Addnewoptiontext ;
      private string Combo_intermediadorclienteid_Objectcall ;
      private string Combo_intermediadorclienteid_Class ;
      private string Combo_intermediadorclienteid_Icontype ;
      private string Combo_intermediadorclienteid_Icon ;
      private string Combo_intermediadorclienteid_Tooltip ;
      private string Combo_intermediadorclienteid_Selectedvalue_set ;
      private string Combo_intermediadorclienteid_Selectedtext_set ;
      private string Combo_intermediadorclienteid_Selectedtext_get ;
      private string Combo_intermediadorclienteid_Gamoauthtoken ;
      private string Combo_intermediadorclienteid_Ddointernalname ;
      private string Combo_intermediadorclienteid_Titlecontrolalign ;
      private string Combo_intermediadorclienteid_Dropdownoptionstype ;
      private string Combo_intermediadorclienteid_Titlecontrolidtoreplace ;
      private string Combo_intermediadorclienteid_Datalisttype ;
      private string Combo_intermediadorclienteid_Datalistfixedvalues ;
      private string Combo_intermediadorclienteid_Remoteservicesparameters ;
      private string Combo_intermediadorclienteid_Htmltemplate ;
      private string Combo_intermediadorclienteid_Multiplevaluestype ;
      private string Combo_intermediadorclienteid_Loadingdata ;
      private string Combo_intermediadorclienteid_Noresultsfound ;
      private string Combo_intermediadorclienteid_Emptyitemtext ;
      private string Combo_intermediadorclienteid_Onlyselectedvalues ;
      private string Combo_intermediadorclienteid_Selectalltext ;
      private string Combo_intermediadorclienteid_Multiplevaluesseparator ;
      private string Combo_intermediadorclienteid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode35 ;
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
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n168ClienteId ;
      private bool n220IntermediadorClienteId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n224FinanciamentoValor ;
      private bool n225FinanciamentoStatus ;
      private bool n169ClienteDocumento ;
      private bool n222IntermediadorClienteDocumento ;
      private bool Combo_clienteid_Enabled ;
      private bool Combo_clienteid_Visible ;
      private bool Combo_clienteid_Allowmultipleselection ;
      private bool Combo_clienteid_Isgriditem ;
      private bool Combo_clienteid_Hasdescription ;
      private bool Combo_clienteid_Includeonlyselectedoption ;
      private bool Combo_clienteid_Includeselectalloption ;
      private bool Combo_clienteid_Emptyitem ;
      private bool Combo_clienteid_Includeaddnewoption ;
      private bool Combo_intermediadorclienteid_Enabled ;
      private bool Combo_intermediadorclienteid_Visible ;
      private bool Combo_intermediadorclienteid_Allowmultipleselection ;
      private bool Combo_intermediadorclienteid_Isgriditem ;
      private bool Combo_intermediadorclienteid_Hasdescription ;
      private bool Combo_intermediadorclienteid_Includeonlyselectedoption ;
      private bool Combo_intermediadorclienteid_Includeselectalloption ;
      private bool Combo_intermediadorclienteid_Emptyitem ;
      private bool Combo_intermediadorclienteid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n170ClienteRazaoSocial ;
      private bool n221IntermediadorClienteRazaoSocial ;
      private bool returnInSub ;
      private string AV18Combo_DataJson ;
      private string Z225FinanciamentoStatus ;
      private string A170ClienteRazaoSocial ;
      private string A221IntermediadorClienteRazaoSocial ;
      private string A225FinanciamentoStatus ;
      private string A169ClienteDocumento ;
      private string A222IntermediadorClienteDocumento ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private string Z170ClienteRazaoSocial ;
      private string Z169ClienteDocumento ;
      private string Z221IntermediadorClienteRazaoSocial ;
      private string Z222IntermediadorClienteDocumento ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_clienteid ;
      private GXUserControl ucCombo_intermediadorclienteid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14ClienteId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV20IntermediadorClienteId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000W4_A170ClienteRazaoSocial ;
      private bool[] T000W4_n170ClienteRazaoSocial ;
      private string[] T000W4_A169ClienteDocumento ;
      private bool[] T000W4_n169ClienteDocumento ;
      private string[] T000W5_A221IntermediadorClienteRazaoSocial ;
      private bool[] T000W5_n221IntermediadorClienteRazaoSocial ;
      private string[] T000W5_A222IntermediadorClienteDocumento ;
      private bool[] T000W5_n222IntermediadorClienteDocumento ;
      private int[] T000W6_A223FinanciamentoId ;
      private string[] T000W6_A170ClienteRazaoSocial ;
      private bool[] T000W6_n170ClienteRazaoSocial ;
      private string[] T000W6_A169ClienteDocumento ;
      private bool[] T000W6_n169ClienteDocumento ;
      private decimal[] T000W6_A224FinanciamentoValor ;
      private bool[] T000W6_n224FinanciamentoValor ;
      private string[] T000W6_A225FinanciamentoStatus ;
      private bool[] T000W6_n225FinanciamentoStatus ;
      private string[] T000W6_A221IntermediadorClienteRazaoSocial ;
      private bool[] T000W6_n221IntermediadorClienteRazaoSocial ;
      private string[] T000W6_A222IntermediadorClienteDocumento ;
      private bool[] T000W6_n222IntermediadorClienteDocumento ;
      private int[] T000W6_A168ClienteId ;
      private bool[] T000W6_n168ClienteId ;
      private int[] T000W6_A220IntermediadorClienteId ;
      private bool[] T000W6_n220IntermediadorClienteId ;
      private string[] T000W7_A170ClienteRazaoSocial ;
      private bool[] T000W7_n170ClienteRazaoSocial ;
      private string[] T000W7_A169ClienteDocumento ;
      private bool[] T000W7_n169ClienteDocumento ;
      private string[] T000W8_A221IntermediadorClienteRazaoSocial ;
      private bool[] T000W8_n221IntermediadorClienteRazaoSocial ;
      private string[] T000W8_A222IntermediadorClienteDocumento ;
      private bool[] T000W8_n222IntermediadorClienteDocumento ;
      private int[] T000W9_A223FinanciamentoId ;
      private int[] T000W3_A223FinanciamentoId ;
      private decimal[] T000W3_A224FinanciamentoValor ;
      private bool[] T000W3_n224FinanciamentoValor ;
      private string[] T000W3_A225FinanciamentoStatus ;
      private bool[] T000W3_n225FinanciamentoStatus ;
      private int[] T000W3_A168ClienteId ;
      private bool[] T000W3_n168ClienteId ;
      private int[] T000W3_A220IntermediadorClienteId ;
      private bool[] T000W3_n220IntermediadorClienteId ;
      private int[] T000W10_A223FinanciamentoId ;
      private int[] T000W11_A223FinanciamentoId ;
      private int[] T000W2_A223FinanciamentoId ;
      private decimal[] T000W2_A224FinanciamentoValor ;
      private bool[] T000W2_n224FinanciamentoValor ;
      private string[] T000W2_A225FinanciamentoStatus ;
      private bool[] T000W2_n225FinanciamentoStatus ;
      private int[] T000W2_A168ClienteId ;
      private bool[] T000W2_n168ClienteId ;
      private int[] T000W2_A220IntermediadorClienteId ;
      private bool[] T000W2_n220IntermediadorClienteId ;
      private int[] T000W13_A223FinanciamentoId ;
      private string[] T000W16_A170ClienteRazaoSocial ;
      private bool[] T000W16_n170ClienteRazaoSocial ;
      private string[] T000W16_A169ClienteDocumento ;
      private bool[] T000W16_n169ClienteDocumento ;
      private string[] T000W17_A221IntermediadorClienteRazaoSocial ;
      private bool[] T000W17_n221IntermediadorClienteRazaoSocial ;
      private string[] T000W17_A222IntermediadorClienteDocumento ;
      private bool[] T000W17_n222IntermediadorClienteDocumento ;
      private int[] T000W18_A223FinanciamentoId ;
   }

   public class financiamento__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
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
          Object[] prmT000W2;
          prmT000W2 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmT000W3;
          prmT000W3 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmT000W4;
          prmT000W4 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000W5;
          prmT000W5 = new Object[] {
          new ParDef("IntermediadorClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000W6;
          prmT000W6 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmT000W7;
          prmT000W7 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000W8;
          prmT000W8 = new Object[] {
          new ParDef("IntermediadorClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000W9;
          prmT000W9 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmT000W10;
          prmT000W10 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmT000W11;
          prmT000W11 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmT000W12;
          prmT000W12 = new Object[] {
          new ParDef("FinanciamentoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("FinanciamentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("IntermediadorClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000W13;
          prmT000W13 = new Object[] {
          };
          Object[] prmT000W14;
          prmT000W14 = new Object[] {
          new ParDef("FinanciamentoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("FinanciamentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("IntermediadorClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmT000W15;
          prmT000W15 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmT000W16;
          prmT000W16 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000W17;
          prmT000W17 = new Object[] {
          new ParDef("IntermediadorClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000W18;
          prmT000W18 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000W2", "SELECT FinanciamentoId, FinanciamentoValor, FinanciamentoStatus, ClienteId, IntermediadorClienteId FROM Financiamento WHERE FinanciamentoId = :FinanciamentoId  FOR UPDATE OF Financiamento NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000W2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W3", "SELECT FinanciamentoId, FinanciamentoValor, FinanciamentoStatus, ClienteId, IntermediadorClienteId FROM Financiamento WHERE FinanciamentoId = :FinanciamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W4", "SELECT ClienteRazaoSocial, ClienteDocumento FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W5", "SELECT ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, ClienteDocumento AS IntermediadorClienteDocumento FROM Cliente WHERE ClienteId = :IntermediadorClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W6", "SELECT TM1.FinanciamentoId, T2.ClienteRazaoSocial, T2.ClienteDocumento, TM1.FinanciamentoValor, TM1.FinanciamentoStatus, T3.ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, T3.ClienteDocumento AS IntermediadorClienteDocumento, TM1.ClienteId, TM1.IntermediadorClienteId AS IntermediadorClienteId FROM ((Financiamento TM1 LEFT JOIN Cliente T2 ON T2.ClienteId = TM1.ClienteId) LEFT JOIN Cliente T3 ON T3.ClienteId = TM1.IntermediadorClienteId) WHERE TM1.FinanciamentoId = :FinanciamentoId ORDER BY TM1.FinanciamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W7", "SELECT ClienteRazaoSocial, ClienteDocumento FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W8", "SELECT ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, ClienteDocumento AS IntermediadorClienteDocumento FROM Cliente WHERE ClienteId = :IntermediadorClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W9", "SELECT FinanciamentoId FROM Financiamento WHERE FinanciamentoId = :FinanciamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W10", "SELECT FinanciamentoId FROM Financiamento WHERE ( FinanciamentoId > :FinanciamentoId) ORDER BY FinanciamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000W11", "SELECT FinanciamentoId FROM Financiamento WHERE ( FinanciamentoId < :FinanciamentoId) ORDER BY FinanciamentoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000W12", "SAVEPOINT gxupdate;INSERT INTO Financiamento(FinanciamentoValor, FinanciamentoStatus, ClienteId, IntermediadorClienteId) VALUES(:FinanciamentoValor, :FinanciamentoStatus, :ClienteId, :IntermediadorClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000W12)
             ,new CursorDef("T000W13", "SELECT currval('FinanciamentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W14", "SAVEPOINT gxupdate;UPDATE Financiamento SET FinanciamentoValor=:FinanciamentoValor, FinanciamentoStatus=:FinanciamentoStatus, ClienteId=:ClienteId, IntermediadorClienteId=:IntermediadorClienteId  WHERE FinanciamentoId = :FinanciamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W14)
             ,new CursorDef("T000W15", "SAVEPOINT gxupdate;DELETE FROM Financiamento  WHERE FinanciamentoId = :FinanciamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W15)
             ,new CursorDef("T000W16", "SELECT ClienteRazaoSocial, ClienteDocumento FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W17", "SELECT ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, ClienteDocumento AS IntermediadorClienteDocumento FROM Cliente WHERE ClienteId = :IntermediadorClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W18", "SELECT FinanciamentoId FROM Financiamento ORDER BY FinanciamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W18,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
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
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
