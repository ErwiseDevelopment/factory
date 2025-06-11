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
   public class aprovacao : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A375AprovadoresId = (int)(Math.Round(NumberUtil.Val( GetPar( "AprovadoresId"), "."), 18, MidpointRounding.ToEven));
            n375AprovadoresId = false;
            AssignAttri("", false, "A375AprovadoresId", ((0==A375AprovadoresId)&&IsIns( )||n375AprovadoresId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A375AprovadoresId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A323PropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A328PropostaCratedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "PropostaCratedBy"), "."), 18, MidpointRounding.ToEven));
            n328PropostaCratedBy = false;
            AssignAttri("", false, "A328PropostaCratedBy", StringUtil.LTrimStr( (decimal)(A328PropostaCratedBy), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A328PropostaCratedBy) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "aprovacao")), "aprovacao") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "aprovacao")))) ;
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
                  AV7AprovacaoId = (int)(Math.Round(NumberUtil.Val( GetPar( "AprovacaoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7AprovacaoId", StringUtil.LTrimStr( (decimal)(AV7AprovacaoId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vAPROVACAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AprovacaoId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Aprovacao", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAprovadoresId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public aprovacao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprovacao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_AprovacaoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AprovacaoId = aP1_AprovacaoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbAprovacaoStatus = new GXCombobox();
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
         if ( cmbAprovacaoStatus.ItemCount > 0 )
         {
            A340AprovacaoStatus = cmbAprovacaoStatus.getValidValue(A340AprovacaoStatus);
            n340AprovacaoStatus = false;
            AssignAttri("", false, "A340AprovacaoStatus", A340AprovacaoStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAprovacaoStatus.CurrentValue = StringUtil.RTrim( A340AprovacaoStatus);
            AssignProp("", false, cmbAprovacaoStatus_Internalname, "Values", cmbAprovacaoStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAprovacaoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAprovacaoId_Internalname, "Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAprovacaoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A336AprovacaoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtAprovacaoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A336AprovacaoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A336AprovacaoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAprovacaoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAprovacaoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Aprovacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedaprovadoresid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockaprovadoresid_Internalname, "Aprovadores", "", "", lblTextblockaprovadoresid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Aprovacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_aprovadoresid.SetProperty("Caption", Combo_aprovadoresid_Caption);
         ucCombo_aprovadoresid.SetProperty("Cls", Combo_aprovadoresid_Cls);
         ucCombo_aprovadoresid.SetProperty("DataListProc", Combo_aprovadoresid_Datalistproc);
         ucCombo_aprovadoresid.SetProperty("DataListProcParametersPrefix", Combo_aprovadoresid_Datalistprocparametersprefix);
         ucCombo_aprovadoresid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_aprovadoresid.SetProperty("DropDownOptionsData", AV14AprovadoresId_Data);
         ucCombo_aprovadoresid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_aprovadoresid_Internalname, "COMBO_APROVADORESIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAprovadoresId_Internalname, "Aprovadores Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAprovadoresId_Internalname, ((0==A375AprovadoresId)&&IsIns( )||n375AprovadoresId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ",", ""))), ((0==A375AprovadoresId)&&IsIns( )||n375AprovadoresId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A375AprovadoresId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAprovadoresId_Jsonclick, 0, "Attribute", "", "", "", "", edtAprovadoresId_Visible, edtAprovadoresId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Aprovacao.htm");
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
         GxWebStd.gx_div_start( context, divTablesplittedpropostaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockpropostaid_Internalname, "Proposta", "", "", lblTextblockpropostaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Aprovacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_propostaid.SetProperty("Caption", Combo_propostaid_Caption);
         ucCombo_propostaid.SetProperty("Cls", Combo_propostaid_Cls);
         ucCombo_propostaid.SetProperty("DataListProc", Combo_propostaid_Datalistproc);
         ucCombo_propostaid.SetProperty("DataListProcParametersPrefix", Combo_propostaid_Datalistprocparametersprefix);
         ucCombo_propostaid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_propostaid.SetProperty("DropDownOptionsData", AV20PropostaId_Data);
         ucCombo_propostaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_propostaid_Internalname, "COMBO_PROPOSTAIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaId_Internalname, "Proposta Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaId_Internalname, ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", ""))), ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaId_Jsonclick, 0, "Attribute", "", "", "", "", edtPropostaId_Visible, edtPropostaId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Aprovacao.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAprovacaoEm_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAprovacaoEm_Internalname, "Aprovado em", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAprovacaoEm_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAprovacaoEm_Internalname, context.localUtil.TToC( A337AprovacaoEm, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A337AprovacaoEm, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAprovacaoEm_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAprovacaoEm_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Aprovacao.htm");
         GxWebStd.gx_bitmap( context, edtAprovacaoEm_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAprovacaoEm_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Aprovacao.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAprovacaoDecisao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAprovacaoDecisao_Internalname, "Decisao", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAprovacaoDecisao_Internalname, A338AprovacaoDecisao, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtAprovacaoDecisao_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Aprovacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbAprovacaoStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbAprovacaoStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbAprovacaoStatus, cmbAprovacaoStatus_Internalname, StringUtil.RTrim( A340AprovacaoStatus), 1, cmbAprovacaoStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbAprovacaoStatus.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_Aprovacao.htm");
         cmbAprovacaoStatus.CurrentValue = StringUtil.RTrim( A340AprovacaoStatus);
         AssignProp("", false, cmbAprovacaoStatus_Internalname, "Values", (string)(cmbAprovacaoStatus.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Aprovacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Aprovacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Aprovacao.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_aprovadoresid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboaprovadoresid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboAprovadoresId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboaprovadoresid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboAprovadoresId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboAprovadoresId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboaprovadoresid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboaprovadoresid_Visible, edtavComboaprovadoresid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Aprovacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_propostaid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombopropostaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ComboPropostaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavCombopropostaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV21ComboPropostaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV21ComboPropostaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopropostaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopropostaid_Visible, edtavCombopropostaid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Aprovacao.htm");
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
         E111C2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vAPROVADORESID_DATA"), AV14AprovadoresId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPROPOSTAID_DATA"), AV20PropostaId_Data);
               /* Read saved values. */
               Z336AprovacaoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z336AprovacaoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z337AprovacaoEm = context.localUtil.CToT( cgiGet( "Z337AprovacaoEm"), 0);
               n337AprovacaoEm = ((DateTime.MinValue==A337AprovacaoEm) ? true : false);
               Z338AprovacaoDecisao = cgiGet( "Z338AprovacaoDecisao");
               n338AprovacaoDecisao = (String.IsNullOrEmpty(StringUtil.RTrim( A338AprovacaoDecisao)) ? true : false);
               Z340AprovacaoStatus = cgiGet( "Z340AprovacaoStatus");
               n340AprovacaoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A340AprovacaoStatus)) ? true : false);
               Z323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z323PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n323PropostaId = ((0==A323PropostaId) ? true : false);
               Z375AprovadoresId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z375AprovadoresId"), ",", "."), 18, MidpointRounding.ToEven));
               n375AprovadoresId = ((0==A375AprovadoresId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N375AprovadoresId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N375AprovadoresId"), ",", "."), 18, MidpointRounding.ToEven));
               n375AprovadoresId = ((0==A375AprovadoresId) ? true : false);
               N323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N323PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n323PropostaId = ((0==A323PropostaId) ? true : false);
               AV7AprovacaoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vAPROVACAOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_AprovadoresId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_APROVADORESID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_AprovadoresId", StringUtil.LTrimStr( (decimal)(AV11Insert_AprovadoresId), 9, 0));
               AV12Insert_PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_PropostaId", StringUtil.LTrimStr( (decimal)(AV12Insert_PropostaId), 9, 0));
               A328PropostaCratedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTACRATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               A141SecUserName = cgiGet( "SECUSERNAME");
               n141SecUserName = false;
               AV22Pgmname = cgiGet( "vPGMNAME");
               Combo_aprovadoresid_Objectcall = cgiGet( "COMBO_APROVADORESID_Objectcall");
               Combo_aprovadoresid_Class = cgiGet( "COMBO_APROVADORESID_Class");
               Combo_aprovadoresid_Icontype = cgiGet( "COMBO_APROVADORESID_Icontype");
               Combo_aprovadoresid_Icon = cgiGet( "COMBO_APROVADORESID_Icon");
               Combo_aprovadoresid_Caption = cgiGet( "COMBO_APROVADORESID_Caption");
               Combo_aprovadoresid_Tooltip = cgiGet( "COMBO_APROVADORESID_Tooltip");
               Combo_aprovadoresid_Cls = cgiGet( "COMBO_APROVADORESID_Cls");
               Combo_aprovadoresid_Selectedvalue_set = cgiGet( "COMBO_APROVADORESID_Selectedvalue_set");
               Combo_aprovadoresid_Selectedvalue_get = cgiGet( "COMBO_APROVADORESID_Selectedvalue_get");
               Combo_aprovadoresid_Selectedtext_set = cgiGet( "COMBO_APROVADORESID_Selectedtext_set");
               Combo_aprovadoresid_Selectedtext_get = cgiGet( "COMBO_APROVADORESID_Selectedtext_get");
               Combo_aprovadoresid_Gamoauthtoken = cgiGet( "COMBO_APROVADORESID_Gamoauthtoken");
               Combo_aprovadoresid_Ddointernalname = cgiGet( "COMBO_APROVADORESID_Ddointernalname");
               Combo_aprovadoresid_Titlecontrolalign = cgiGet( "COMBO_APROVADORESID_Titlecontrolalign");
               Combo_aprovadoresid_Dropdownoptionstype = cgiGet( "COMBO_APROVADORESID_Dropdownoptionstype");
               Combo_aprovadoresid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_APROVADORESID_Enabled"));
               Combo_aprovadoresid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_APROVADORESID_Visible"));
               Combo_aprovadoresid_Titlecontrolidtoreplace = cgiGet( "COMBO_APROVADORESID_Titlecontrolidtoreplace");
               Combo_aprovadoresid_Datalisttype = cgiGet( "COMBO_APROVADORESID_Datalisttype");
               Combo_aprovadoresid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_APROVADORESID_Allowmultipleselection"));
               Combo_aprovadoresid_Datalistfixedvalues = cgiGet( "COMBO_APROVADORESID_Datalistfixedvalues");
               Combo_aprovadoresid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_APROVADORESID_Isgriditem"));
               Combo_aprovadoresid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_APROVADORESID_Hasdescription"));
               Combo_aprovadoresid_Datalistproc = cgiGet( "COMBO_APROVADORESID_Datalistproc");
               Combo_aprovadoresid_Datalistprocparametersprefix = cgiGet( "COMBO_APROVADORESID_Datalistprocparametersprefix");
               Combo_aprovadoresid_Remoteservicesparameters = cgiGet( "COMBO_APROVADORESID_Remoteservicesparameters");
               Combo_aprovadoresid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_APROVADORESID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_aprovadoresid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_APROVADORESID_Includeonlyselectedoption"));
               Combo_aprovadoresid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_APROVADORESID_Includeselectalloption"));
               Combo_aprovadoresid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_APROVADORESID_Emptyitem"));
               Combo_aprovadoresid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_APROVADORESID_Includeaddnewoption"));
               Combo_aprovadoresid_Htmltemplate = cgiGet( "COMBO_APROVADORESID_Htmltemplate");
               Combo_aprovadoresid_Multiplevaluestype = cgiGet( "COMBO_APROVADORESID_Multiplevaluestype");
               Combo_aprovadoresid_Loadingdata = cgiGet( "COMBO_APROVADORESID_Loadingdata");
               Combo_aprovadoresid_Noresultsfound = cgiGet( "COMBO_APROVADORESID_Noresultsfound");
               Combo_aprovadoresid_Emptyitemtext = cgiGet( "COMBO_APROVADORESID_Emptyitemtext");
               Combo_aprovadoresid_Onlyselectedvalues = cgiGet( "COMBO_APROVADORESID_Onlyselectedvalues");
               Combo_aprovadoresid_Selectalltext = cgiGet( "COMBO_APROVADORESID_Selectalltext");
               Combo_aprovadoresid_Multiplevaluesseparator = cgiGet( "COMBO_APROVADORESID_Multiplevaluesseparator");
               Combo_aprovadoresid_Addnewoptiontext = cgiGet( "COMBO_APROVADORESID_Addnewoptiontext");
               Combo_aprovadoresid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_APROVADORESID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_propostaid_Objectcall = cgiGet( "COMBO_PROPOSTAID_Objectcall");
               Combo_propostaid_Class = cgiGet( "COMBO_PROPOSTAID_Class");
               Combo_propostaid_Icontype = cgiGet( "COMBO_PROPOSTAID_Icontype");
               Combo_propostaid_Icon = cgiGet( "COMBO_PROPOSTAID_Icon");
               Combo_propostaid_Caption = cgiGet( "COMBO_PROPOSTAID_Caption");
               Combo_propostaid_Tooltip = cgiGet( "COMBO_PROPOSTAID_Tooltip");
               Combo_propostaid_Cls = cgiGet( "COMBO_PROPOSTAID_Cls");
               Combo_propostaid_Selectedvalue_set = cgiGet( "COMBO_PROPOSTAID_Selectedvalue_set");
               Combo_propostaid_Selectedvalue_get = cgiGet( "COMBO_PROPOSTAID_Selectedvalue_get");
               Combo_propostaid_Selectedtext_set = cgiGet( "COMBO_PROPOSTAID_Selectedtext_set");
               Combo_propostaid_Selectedtext_get = cgiGet( "COMBO_PROPOSTAID_Selectedtext_get");
               Combo_propostaid_Gamoauthtoken = cgiGet( "COMBO_PROPOSTAID_Gamoauthtoken");
               Combo_propostaid_Ddointernalname = cgiGet( "COMBO_PROPOSTAID_Ddointernalname");
               Combo_propostaid_Titlecontrolalign = cgiGet( "COMBO_PROPOSTAID_Titlecontrolalign");
               Combo_propostaid_Dropdownoptionstype = cgiGet( "COMBO_PROPOSTAID_Dropdownoptionstype");
               Combo_propostaid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Enabled"));
               Combo_propostaid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Visible"));
               Combo_propostaid_Titlecontrolidtoreplace = cgiGet( "COMBO_PROPOSTAID_Titlecontrolidtoreplace");
               Combo_propostaid_Datalisttype = cgiGet( "COMBO_PROPOSTAID_Datalisttype");
               Combo_propostaid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Allowmultipleselection"));
               Combo_propostaid_Datalistfixedvalues = cgiGet( "COMBO_PROPOSTAID_Datalistfixedvalues");
               Combo_propostaid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Isgriditem"));
               Combo_propostaid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Hasdescription"));
               Combo_propostaid_Datalistproc = cgiGet( "COMBO_PROPOSTAID_Datalistproc");
               Combo_propostaid_Datalistprocparametersprefix = cgiGet( "COMBO_PROPOSTAID_Datalistprocparametersprefix");
               Combo_propostaid_Remoteservicesparameters = cgiGet( "COMBO_PROPOSTAID_Remoteservicesparameters");
               Combo_propostaid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROPOSTAID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_propostaid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Includeonlyselectedoption"));
               Combo_propostaid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Includeselectalloption"));
               Combo_propostaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Emptyitem"));
               Combo_propostaid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTAID_Includeaddnewoption"));
               Combo_propostaid_Htmltemplate = cgiGet( "COMBO_PROPOSTAID_Htmltemplate");
               Combo_propostaid_Multiplevaluestype = cgiGet( "COMBO_PROPOSTAID_Multiplevaluestype");
               Combo_propostaid_Loadingdata = cgiGet( "COMBO_PROPOSTAID_Loadingdata");
               Combo_propostaid_Noresultsfound = cgiGet( "COMBO_PROPOSTAID_Noresultsfound");
               Combo_propostaid_Emptyitemtext = cgiGet( "COMBO_PROPOSTAID_Emptyitemtext");
               Combo_propostaid_Onlyselectedvalues = cgiGet( "COMBO_PROPOSTAID_Onlyselectedvalues");
               Combo_propostaid_Selectalltext = cgiGet( "COMBO_PROPOSTAID_Selectalltext");
               Combo_propostaid_Multiplevaluesseparator = cgiGet( "COMBO_PROPOSTAID_Multiplevaluesseparator");
               Combo_propostaid_Addnewoptiontext = cgiGet( "COMBO_PROPOSTAID_Addnewoptiontext");
               Combo_propostaid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROPOSTAID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A336AprovacaoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAprovacaoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
               n375AprovadoresId = ((StringUtil.StrCmp(cgiGet( edtAprovadoresId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtAprovadoresId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAprovadoresId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APROVADORESID");
                  AnyError = 1;
                  GX_FocusControl = edtAprovadoresId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A375AprovadoresId = 0;
                  n375AprovadoresId = false;
                  AssignAttri("", false, "A375AprovadoresId", (n375AprovadoresId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", ""))));
               }
               else
               {
                  A375AprovadoresId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAprovadoresId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A375AprovadoresId", (n375AprovadoresId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", ""))));
               }
               n323PropostaId = ((StringUtil.StrCmp(cgiGet( edtPropostaId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTAID");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A323PropostaId = 0;
                  n323PropostaId = false;
                  AssignAttri("", false, "A323PropostaId", (n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
               }
               else
               {
                  A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A323PropostaId", (n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtAprovacaoEm_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Aprovacao Em"}), 1, "APROVACAOEM");
                  AnyError = 1;
                  GX_FocusControl = edtAprovacaoEm_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A337AprovacaoEm = (DateTime)(DateTime.MinValue);
                  n337AprovacaoEm = false;
                  AssignAttri("", false, "A337AprovacaoEm", context.localUtil.TToC( A337AprovacaoEm, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A337AprovacaoEm = context.localUtil.CToT( cgiGet( edtAprovacaoEm_Internalname));
                  n337AprovacaoEm = false;
                  AssignAttri("", false, "A337AprovacaoEm", context.localUtil.TToC( A337AprovacaoEm, 10, 8, 0, 3, "/", ":", " "));
               }
               n337AprovacaoEm = ((DateTime.MinValue==A337AprovacaoEm) ? true : false);
               A338AprovacaoDecisao = cgiGet( edtAprovacaoDecisao_Internalname);
               n338AprovacaoDecisao = false;
               AssignAttri("", false, "A338AprovacaoDecisao", A338AprovacaoDecisao);
               n338AprovacaoDecisao = (String.IsNullOrEmpty(StringUtil.RTrim( A338AprovacaoDecisao)) ? true : false);
               cmbAprovacaoStatus.CurrentValue = cgiGet( cmbAprovacaoStatus_Internalname);
               A340AprovacaoStatus = cgiGet( cmbAprovacaoStatus_Internalname);
               n340AprovacaoStatus = false;
               AssignAttri("", false, "A340AprovacaoStatus", A340AprovacaoStatus);
               n340AprovacaoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A340AprovacaoStatus)) ? true : false);
               AV19ComboAprovadoresId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboaprovadoresid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ComboAprovadoresId", StringUtil.LTrimStr( (decimal)(AV19ComboAprovadoresId), 9, 0));
               AV21ComboPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombopropostaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21ComboPropostaId", StringUtil.LTrimStr( (decimal)(AV21ComboPropostaId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Aprovacao");
               A336AprovacaoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAprovacaoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
               forbiddenHiddens.Add("AprovacaoId", context.localUtil.Format( (decimal)(A336AprovacaoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_AprovadoresId", context.localUtil.Format( (decimal)(AV11Insert_AprovadoresId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_PropostaId", context.localUtil.Format( (decimal)(AV12Insert_PropostaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A336AprovacaoId != Z336AprovacaoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("aprovacao:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A336AprovacaoId = (int)(Math.Round(NumberUtil.Val( GetPar( "AprovacaoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
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
                     sMode51 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode51;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound51 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "APROVACAOID");
                        AnyError = 1;
                        GX_FocusControl = edtAprovacaoId_Internalname;
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
                           E111C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121C2 ();
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
            E121C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1C51( ) ;
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
            DisableAttributes1C51( ) ;
         }
         AssignProp("", false, edtavComboaprovadoresid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboaprovadoresid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombopropostaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopropostaid_Enabled), 5, 0), true);
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

      protected void CONFIRM_1C0( )
      {
         BeforeValidate1C51( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1C51( ) ;
            }
            else
            {
               CheckExtendedTable1C51( ) ;
               CloseExtendedTableCursors1C51( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1C0( )
      {
      }

      protected void E111C2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtPropostaId_Visible = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPropostaId_Visible), 5, 0), true);
         AV21ComboPropostaId = 0;
         AssignAttri("", false, "AV21ComboPropostaId", StringUtil.LTrimStr( (decimal)(AV21ComboPropostaId), 9, 0));
         edtavCombopropostaid_Visible = 0;
         AssignProp("", false, edtavCombopropostaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombopropostaid_Visible), 5, 0), true);
         edtAprovadoresId_Visible = 0;
         AssignProp("", false, edtAprovadoresId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAprovadoresId_Visible), 5, 0), true);
         AV19ComboAprovadoresId = 0;
         AssignAttri("", false, "AV19ComboAprovadoresId", StringUtil.LTrimStr( (decimal)(AV19ComboAprovadoresId), 9, 0));
         edtavComboaprovadoresid_Visible = 0;
         AssignProp("", false, edtavComboaprovadoresid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboaprovadoresid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOAPROVADORESID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPROPOSTAID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            while ( AV23GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "AprovadoresId") == 0 )
               {
                  AV11Insert_AprovadoresId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_AprovadoresId", StringUtil.LTrimStr( (decimal)(AV11Insert_AprovadoresId), 9, 0));
                  if ( ! (0==AV11Insert_AprovadoresId) )
                  {
                     AV19ComboAprovadoresId = AV11Insert_AprovadoresId;
                     AssignAttri("", false, "AV19ComboAprovadoresId", StringUtil.LTrimStr( (decimal)(AV19ComboAprovadoresId), 9, 0));
                     Combo_aprovadoresid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ComboAprovadoresId), 9, 0));
                     ucCombo_aprovadoresid.SendProperty(context, "", false, Combo_aprovadoresid_Internalname, "SelectedValue_set", Combo_aprovadoresid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new aprovacaoloaddvcombo(context ).execute(  "AprovadoresId",  "GET",  false,  AV7AprovacaoId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_aprovadoresid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_aprovadoresid.SendProperty(context, "", false, Combo_aprovadoresid_Internalname, "SelectedText_set", Combo_aprovadoresid_Selectedtext_set);
                     Combo_aprovadoresid_Enabled = false;
                     ucCombo_aprovadoresid.SendProperty(context, "", false, Combo_aprovadoresid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_aprovadoresid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaId") == 0 )
               {
                  AV12Insert_PropostaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_PropostaId", StringUtil.LTrimStr( (decimal)(AV12Insert_PropostaId), 9, 0));
                  if ( ! (0==AV12Insert_PropostaId) )
                  {
                     AV21ComboPropostaId = AV12Insert_PropostaId;
                     AssignAttri("", false, "AV21ComboPropostaId", StringUtil.LTrimStr( (decimal)(AV21ComboPropostaId), 9, 0));
                     Combo_propostaid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV21ComboPropostaId), 9, 0));
                     ucCombo_propostaid.SendProperty(context, "", false, Combo_propostaid_Internalname, "SelectedValue_set", Combo_propostaid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new aprovacaoloaddvcombo(context ).execute(  "PropostaId",  "GET",  false,  AV7AprovacaoId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_propostaid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_propostaid.SendProperty(context, "", false, Combo_propostaid_Internalname, "SelectedText_set", Combo_propostaid_Selectedtext_set);
                     Combo_propostaid_Enabled = false;
                     ucCombo_propostaid.SendProperty(context, "", false, Combo_propostaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_propostaid_Enabled));
                  }
               }
               AV23GXV1 = (int)(AV23GXV1+1);
               AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            }
         }
      }

      protected void E121C2( )
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
            GXEncryptionTmp = "aprovacaoww"+UrlEncode(StringUtil.LTrimStr(A323PropostaId,9,0));
            CallWebObject(formatLink("aprovacaoww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         /* 'LOADCOMBOPROPOSTAID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new aprovacaoloaddvcombo(context ).execute(  "PropostaId",  Gx_mode,  false,  AV7AprovacaoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_propostaid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_propostaid.SendProperty(context, "", false, Combo_propostaid_Internalname, "SelectedValue_set", Combo_propostaid_Selectedvalue_set);
         Combo_propostaid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_propostaid.SendProperty(context, "", false, Combo_propostaid_Internalname, "SelectedText_set", Combo_propostaid_Selectedtext_set);
         AV21ComboPropostaId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV21ComboPropostaId", StringUtil.LTrimStr( (decimal)(AV21ComboPropostaId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_propostaid_Enabled = false;
            ucCombo_propostaid.SendProperty(context, "", false, Combo_propostaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_propostaid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOAPROVADORESID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new aprovacaoloaddvcombo(context ).execute(  "AprovadoresId",  Gx_mode,  false,  AV7AprovacaoId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_aprovadoresid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_aprovadoresid.SendProperty(context, "", false, Combo_aprovadoresid_Internalname, "SelectedValue_set", Combo_aprovadoresid_Selectedvalue_set);
         Combo_aprovadoresid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_aprovadoresid.SendProperty(context, "", false, Combo_aprovadoresid_Internalname, "SelectedText_set", Combo_aprovadoresid_Selectedtext_set);
         AV19ComboAprovadoresId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV19ComboAprovadoresId", StringUtil.LTrimStr( (decimal)(AV19ComboAprovadoresId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_aprovadoresid_Enabled = false;
            ucCombo_aprovadoresid.SendProperty(context, "", false, Combo_aprovadoresid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_aprovadoresid_Enabled));
         }
      }

      protected void ZM1C51( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z337AprovacaoEm = T001C3_A337AprovacaoEm[0];
               Z338AprovacaoDecisao = T001C3_A338AprovacaoDecisao[0];
               Z340AprovacaoStatus = T001C3_A340AprovacaoStatus[0];
               Z323PropostaId = T001C3_A323PropostaId[0];
               Z375AprovadoresId = T001C3_A375AprovadoresId[0];
            }
            else
            {
               Z337AprovacaoEm = A337AprovacaoEm;
               Z338AprovacaoDecisao = A338AprovacaoDecisao;
               Z340AprovacaoStatus = A340AprovacaoStatus;
               Z323PropostaId = A323PropostaId;
               Z375AprovadoresId = A375AprovadoresId;
            }
         }
         if ( GX_JID == -12 )
         {
            Z336AprovacaoId = A336AprovacaoId;
            Z337AprovacaoEm = A337AprovacaoEm;
            Z338AprovacaoDecisao = A338AprovacaoDecisao;
            Z340AprovacaoStatus = A340AprovacaoStatus;
            Z323PropostaId = A323PropostaId;
            Z375AprovadoresId = A375AprovadoresId;
            Z328PropostaCratedBy = A328PropostaCratedBy;
            Z141SecUserName = A141SecUserName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtAprovacaoId_Enabled = 0;
         AssignProp("", false, edtAprovacaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAprovacaoId_Enabled), 5, 0), true);
         AV22Pgmname = "Aprovacao";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         edtAprovacaoId_Enabled = 0;
         AssignProp("", false, edtAprovacaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAprovacaoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7AprovacaoId) )
         {
            A336AprovacaoId = AV7AprovacaoId;
            AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_AprovadoresId) )
         {
            edtAprovadoresId_Enabled = 0;
            AssignProp("", false, edtAprovadoresId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAprovadoresId_Enabled), 5, 0), true);
         }
         else
         {
            edtAprovadoresId_Enabled = 1;
            AssignProp("", false, edtAprovadoresId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAprovadoresId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_PropostaId) )
         {
            edtPropostaId_Enabled = 0;
            AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         }
         else
         {
            edtPropostaId_Enabled = 1;
            AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_AprovadoresId) )
         {
            A375AprovadoresId = AV11Insert_AprovadoresId;
            n375AprovadoresId = false;
            AssignAttri("", false, "A375AprovadoresId", ((0==A375AprovadoresId)&&IsIns( )||n375AprovadoresId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboAprovadoresId) )
            {
               A375AprovadoresId = 0;
               n375AprovadoresId = false;
               AssignAttri("", false, "A375AprovadoresId", ((0==A375AprovadoresId)&&IsIns( )||n375AprovadoresId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", ""))));
               n375AprovadoresId = true;
               n375AprovadoresId = true;
               AssignAttri("", false, "A375AprovadoresId", ((0==A375AprovadoresId)&&IsIns( )||n375AprovadoresId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboAprovadoresId) )
               {
                  A375AprovadoresId = AV19ComboAprovadoresId;
                  n375AprovadoresId = false;
                  AssignAttri("", false, "A375AprovadoresId", ((0==A375AprovadoresId)&&IsIns( )||n375AprovadoresId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", ""))));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_PropostaId) )
         {
            A323PropostaId = AV12Insert_PropostaId;
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV21ComboPropostaId) )
            {
               A323PropostaId = 0;
               n323PropostaId = false;
               AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
               n323PropostaId = true;
               n323PropostaId = true;
               AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV21ComboPropostaId) )
               {
                  A323PropostaId = AV21ComboPropostaId;
                  n323PropostaId = false;
                  AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
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
            /* Using cursor T001C4 */
            pr_default.execute(2, new Object[] {n323PropostaId, A323PropostaId});
            A328PropostaCratedBy = T001C4_A328PropostaCratedBy[0];
            n328PropostaCratedBy = T001C4_n328PropostaCratedBy[0];
            pr_default.close(2);
            /* Using cursor T001C6 */
            pr_default.execute(4, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
            A141SecUserName = T001C6_A141SecUserName[0];
            n141SecUserName = T001C6_n141SecUserName[0];
            pr_default.close(4);
         }
      }

      protected void Load1C51( )
      {
         /* Using cursor T001C7 */
         pr_default.execute(5, new Object[] {A336AprovacaoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound51 = 1;
            A328PropostaCratedBy = T001C7_A328PropostaCratedBy[0];
            n328PropostaCratedBy = T001C7_n328PropostaCratedBy[0];
            A141SecUserName = T001C7_A141SecUserName[0];
            n141SecUserName = T001C7_n141SecUserName[0];
            A337AprovacaoEm = T001C7_A337AprovacaoEm[0];
            n337AprovacaoEm = T001C7_n337AprovacaoEm[0];
            AssignAttri("", false, "A337AprovacaoEm", context.localUtil.TToC( A337AprovacaoEm, 10, 8, 0, 3, "/", ":", " "));
            A338AprovacaoDecisao = T001C7_A338AprovacaoDecisao[0];
            n338AprovacaoDecisao = T001C7_n338AprovacaoDecisao[0];
            AssignAttri("", false, "A338AprovacaoDecisao", A338AprovacaoDecisao);
            A340AprovacaoStatus = T001C7_A340AprovacaoStatus[0];
            n340AprovacaoStatus = T001C7_n340AprovacaoStatus[0];
            AssignAttri("", false, "A340AprovacaoStatus", A340AprovacaoStatus);
            A323PropostaId = T001C7_A323PropostaId[0];
            n323PropostaId = T001C7_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            A375AprovadoresId = T001C7_A375AprovadoresId[0];
            n375AprovadoresId = T001C7_n375AprovadoresId[0];
            AssignAttri("", false, "A375AprovadoresId", ((0==A375AprovadoresId)&&IsIns( )||n375AprovadoresId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", ""))));
            ZM1C51( -12) ;
         }
         pr_default.close(5);
         OnLoadActions1C51( ) ;
      }

      protected void OnLoadActions1C51( )
      {
      }

      protected void CheckExtendedTable1C51( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001C5 */
         pr_default.execute(3, new Object[] {n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A375AprovadoresId) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "APROVADORESID");
               AnyError = 1;
               GX_FocusControl = edtAprovadoresId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T001C4 */
         pr_default.execute(2, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A328PropostaCratedBy = T001C4_A328PropostaCratedBy[0];
         n328PropostaCratedBy = T001C4_n328PropostaCratedBy[0];
         pr_default.close(2);
         /* Using cursor T001C6 */
         pr_default.execute(4, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A328PropostaCratedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTACRATEDBY");
               AnyError = 1;
            }
         }
         A141SecUserName = T001C6_A141SecUserName[0];
         n141SecUserName = T001C6_n141SecUserName[0];
         pr_default.close(4);
         if ( ! ( ( StringUtil.StrCmp(A340AprovacaoStatus, "APROVADO") == 0 ) || ( StringUtil.StrCmp(A340AprovacaoStatus, "REPROVADO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A340AprovacaoStatus)) ) )
         {
            GX_msglist.addItem("Campo Aprovacao Status fora do intervalo", "OutOfRange", 1, "APROVACAOSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbAprovacaoStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1C51( )
      {
         pr_default.close(3);
         pr_default.close(2);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( int A375AprovadoresId )
      {
         /* Using cursor T001C8 */
         pr_default.execute(6, new Object[] {n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A375AprovadoresId) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "APROVADORESID");
               AnyError = 1;
               GX_FocusControl = edtAprovadoresId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_13( int A323PropostaId )
      {
         /* Using cursor T001C9 */
         pr_default.execute(7, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A328PropostaCratedBy = T001C9_A328PropostaCratedBy[0];
         n328PropostaCratedBy = T001C9_n328PropostaCratedBy[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_15( short A328PropostaCratedBy )
      {
         /* Using cursor T001C10 */
         pr_default.execute(8, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A328PropostaCratedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTACRATEDBY");
               AnyError = 1;
            }
         }
         A141SecUserName = T001C10_A141SecUserName[0];
         n141SecUserName = T001C10_n141SecUserName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A141SecUserName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey1C51( )
      {
         /* Using cursor T001C11 */
         pr_default.execute(9, new Object[] {A336AprovacaoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound51 = 1;
         }
         else
         {
            RcdFound51 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001C3 */
         pr_default.execute(1, new Object[] {A336AprovacaoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1C51( 12) ;
            RcdFound51 = 1;
            A336AprovacaoId = T001C3_A336AprovacaoId[0];
            AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
            A337AprovacaoEm = T001C3_A337AprovacaoEm[0];
            n337AprovacaoEm = T001C3_n337AprovacaoEm[0];
            AssignAttri("", false, "A337AprovacaoEm", context.localUtil.TToC( A337AprovacaoEm, 10, 8, 0, 3, "/", ":", " "));
            A338AprovacaoDecisao = T001C3_A338AprovacaoDecisao[0];
            n338AprovacaoDecisao = T001C3_n338AprovacaoDecisao[0];
            AssignAttri("", false, "A338AprovacaoDecisao", A338AprovacaoDecisao);
            A340AprovacaoStatus = T001C3_A340AprovacaoStatus[0];
            n340AprovacaoStatus = T001C3_n340AprovacaoStatus[0];
            AssignAttri("", false, "A340AprovacaoStatus", A340AprovacaoStatus);
            A323PropostaId = T001C3_A323PropostaId[0];
            n323PropostaId = T001C3_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            A375AprovadoresId = T001C3_A375AprovadoresId[0];
            n375AprovadoresId = T001C3_n375AprovadoresId[0];
            AssignAttri("", false, "A375AprovadoresId", ((0==A375AprovadoresId)&&IsIns( )||n375AprovadoresId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", ""))));
            Z336AprovacaoId = A336AprovacaoId;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1C51( ) ;
            if ( AnyError == 1 )
            {
               RcdFound51 = 0;
               InitializeNonKey1C51( ) ;
            }
            Gx_mode = sMode51;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound51 = 0;
            InitializeNonKey1C51( ) ;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode51;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1C51( ) ;
         if ( RcdFound51 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound51 = 0;
         /* Using cursor T001C12 */
         pr_default.execute(10, new Object[] {A336AprovacaoId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T001C12_A336AprovacaoId[0] < A336AprovacaoId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T001C12_A336AprovacaoId[0] > A336AprovacaoId ) ) )
            {
               A336AprovacaoId = T001C12_A336AprovacaoId[0];
               AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
               RcdFound51 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound51 = 0;
         /* Using cursor T001C13 */
         pr_default.execute(11, new Object[] {A336AprovacaoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T001C13_A336AprovacaoId[0] > A336AprovacaoId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T001C13_A336AprovacaoId[0] < A336AprovacaoId ) ) )
            {
               A336AprovacaoId = T001C13_A336AprovacaoId[0];
               AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
               RcdFound51 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1C51( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAprovadoresId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1C51( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound51 == 1 )
            {
               if ( A336AprovacaoId != Z336AprovacaoId )
               {
                  A336AprovacaoId = Z336AprovacaoId;
                  AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "APROVACAOID");
                  AnyError = 1;
                  GX_FocusControl = edtAprovacaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAprovadoresId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1C51( ) ;
                  GX_FocusControl = edtAprovadoresId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A336AprovacaoId != Z336AprovacaoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtAprovadoresId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1C51( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "APROVACAOID");
                     AnyError = 1;
                     GX_FocusControl = edtAprovacaoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtAprovadoresId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1C51( ) ;
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
         if ( A336AprovacaoId != Z336AprovacaoId )
         {
            A336AprovacaoId = Z336AprovacaoId;
            AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "APROVACAOID");
            AnyError = 1;
            GX_FocusControl = edtAprovacaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAprovadoresId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1C51( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001C2 */
            pr_default.execute(0, new Object[] {A336AprovacaoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Aprovacao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z337AprovacaoEm != T001C2_A337AprovacaoEm[0] ) || ( StringUtil.StrCmp(Z338AprovacaoDecisao, T001C2_A338AprovacaoDecisao[0]) != 0 ) || ( StringUtil.StrCmp(Z340AprovacaoStatus, T001C2_A340AprovacaoStatus[0]) != 0 ) || ( Z323PropostaId != T001C2_A323PropostaId[0] ) || ( Z375AprovadoresId != T001C2_A375AprovadoresId[0] ) )
            {
               if ( Z337AprovacaoEm != T001C2_A337AprovacaoEm[0] )
               {
                  GXUtil.WriteLog("aprovacao:[seudo value changed for attri]"+"AprovacaoEm");
                  GXUtil.WriteLogRaw("Old: ",Z337AprovacaoEm);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A337AprovacaoEm[0]);
               }
               if ( StringUtil.StrCmp(Z338AprovacaoDecisao, T001C2_A338AprovacaoDecisao[0]) != 0 )
               {
                  GXUtil.WriteLog("aprovacao:[seudo value changed for attri]"+"AprovacaoDecisao");
                  GXUtil.WriteLogRaw("Old: ",Z338AprovacaoDecisao);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A338AprovacaoDecisao[0]);
               }
               if ( StringUtil.StrCmp(Z340AprovacaoStatus, T001C2_A340AprovacaoStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("aprovacao:[seudo value changed for attri]"+"AprovacaoStatus");
                  GXUtil.WriteLogRaw("Old: ",Z340AprovacaoStatus);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A340AprovacaoStatus[0]);
               }
               if ( Z323PropostaId != T001C2_A323PropostaId[0] )
               {
                  GXUtil.WriteLog("aprovacao:[seudo value changed for attri]"+"PropostaId");
                  GXUtil.WriteLogRaw("Old: ",Z323PropostaId);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A323PropostaId[0]);
               }
               if ( Z375AprovadoresId != T001C2_A375AprovadoresId[0] )
               {
                  GXUtil.WriteLog("aprovacao:[seudo value changed for attri]"+"AprovadoresId");
                  GXUtil.WriteLogRaw("Old: ",Z375AprovadoresId);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A375AprovadoresId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Aprovacao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1C51( )
      {
         BeforeValidate1C51( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C51( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1C51( 0) ;
            CheckOptimisticConcurrency1C51( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C51( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1C51( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C14 */
                     pr_default.execute(12, new Object[] {n337AprovacaoEm, A337AprovacaoEm, n338AprovacaoDecisao, A338AprovacaoDecisao, n340AprovacaoStatus, A340AprovacaoStatus, n323PropostaId, A323PropostaId, n375AprovadoresId, A375AprovadoresId});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001C15 */
                     pr_default.execute(13);
                     A336AprovacaoId = T001C15_A336AprovacaoId[0];
                     AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Aprovacao");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1C0( ) ;
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
               Load1C51( ) ;
            }
            EndLevel1C51( ) ;
         }
         CloseExtendedTableCursors1C51( ) ;
      }

      protected void Update1C51( )
      {
         BeforeValidate1C51( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C51( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C51( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C51( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1C51( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C16 */
                     pr_default.execute(14, new Object[] {n337AprovacaoEm, A337AprovacaoEm, n338AprovacaoDecisao, A338AprovacaoDecisao, n340AprovacaoStatus, A340AprovacaoStatus, n323PropostaId, A323PropostaId, n375AprovadoresId, A375AprovadoresId, A336AprovacaoId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Aprovacao");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Aprovacao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1C51( ) ;
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
            EndLevel1C51( ) ;
         }
         CloseExtendedTableCursors1C51( ) ;
      }

      protected void DeferredUpdate1C51( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1C51( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C51( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1C51( ) ;
            AfterConfirm1C51( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1C51( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001C17 */
                  pr_default.execute(15, new Object[] {A336AprovacaoId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("Aprovacao");
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
         sMode51 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1C51( ) ;
         Gx_mode = sMode51;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1C51( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001C18 */
            pr_default.execute(16, new Object[] {n323PropostaId, A323PropostaId});
            A328PropostaCratedBy = T001C18_A328PropostaCratedBy[0];
            n328PropostaCratedBy = T001C18_n328PropostaCratedBy[0];
            pr_default.close(16);
            /* Using cursor T001C19 */
            pr_default.execute(17, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
            A141SecUserName = T001C19_A141SecUserName[0];
            n141SecUserName = T001C19_n141SecUserName[0];
            pr_default.close(17);
         }
      }

      protected void EndLevel1C51( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1C51( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues1C0( ) ;
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

      public void ScanStart1C51( )
      {
         /* Scan By routine */
         /* Using cursor T001C20 */
         pr_default.execute(18);
         RcdFound51 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound51 = 1;
            A336AprovacaoId = T001C20_A336AprovacaoId[0];
            AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1C51( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound51 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound51 = 1;
            A336AprovacaoId = T001C20_A336AprovacaoId[0];
            AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
         }
      }

      protected void ScanEnd1C51( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm1C51( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1C51( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1C51( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1C51( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1C51( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1C51( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1C51( )
      {
         edtAprovacaoId_Enabled = 0;
         AssignProp("", false, edtAprovacaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAprovacaoId_Enabled), 5, 0), true);
         edtAprovadoresId_Enabled = 0;
         AssignProp("", false, edtAprovadoresId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAprovadoresId_Enabled), 5, 0), true);
         edtPropostaId_Enabled = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         edtAprovacaoEm_Enabled = 0;
         AssignProp("", false, edtAprovacaoEm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAprovacaoEm_Enabled), 5, 0), true);
         edtAprovacaoDecisao_Enabled = 0;
         AssignProp("", false, edtAprovacaoDecisao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAprovacaoDecisao_Enabled), 5, 0), true);
         cmbAprovacaoStatus.Enabled = 0;
         AssignProp("", false, cmbAprovacaoStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAprovacaoStatus.Enabled), 5, 0), true);
         edtavComboaprovadoresid_Enabled = 0;
         AssignProp("", false, edtavComboaprovadoresid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboaprovadoresid_Enabled), 5, 0), true);
         edtavCombopropostaid_Enabled = 0;
         AssignProp("", false, edtavCombopropostaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopropostaid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1C51( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1C0( )
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
         GXEncryptionTmp = "aprovacao"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AprovacaoId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("aprovacao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Aprovacao");
         forbiddenHiddens.Add("AprovacaoId", context.localUtil.Format( (decimal)(A336AprovacaoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_AprovadoresId", context.localUtil.Format( (decimal)(AV11Insert_AprovadoresId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_PropostaId", context.localUtil.Format( (decimal)(AV12Insert_PropostaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("aprovacao:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z336AprovacaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z336AprovacaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z337AprovacaoEm", context.localUtil.TToC( Z337AprovacaoEm, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z338AprovacaoDecisao", Z338AprovacaoDecisao);
         GxWebStd.gx_hidden_field( context, "Z340AprovacaoStatus", Z340AprovacaoStatus);
         GxWebStd.gx_hidden_field( context, "Z323PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z375AprovadoresId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z375AprovadoresId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N375AprovadoresId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N323PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAPROVADORESID_DATA", AV14AprovadoresId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAPROVADORESID_DATA", AV14AprovadoresId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROPOSTAID_DATA", AV20PropostaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROPOSTAID_DATA", AV20PropostaId_Data);
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
         GxWebStd.gx_hidden_field( context, "vAPROVACAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AprovacaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPROVACAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AprovacaoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_APROVADORESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_AprovadoresId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTACRATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSERNAME", A141SecUserName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_APROVADORESID_Objectcall", StringUtil.RTrim( Combo_aprovadoresid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_APROVADORESID_Cls", StringUtil.RTrim( Combo_aprovadoresid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_APROVADORESID_Selectedvalue_set", StringUtil.RTrim( Combo_aprovadoresid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_APROVADORESID_Selectedtext_set", StringUtil.RTrim( Combo_aprovadoresid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_APROVADORESID_Enabled", StringUtil.BoolToStr( Combo_aprovadoresid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_APROVADORESID_Datalistproc", StringUtil.RTrim( Combo_aprovadoresid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_APROVADORESID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_aprovadoresid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Objectcall", StringUtil.RTrim( Combo_propostaid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Cls", StringUtil.RTrim( Combo_propostaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Selectedvalue_set", StringUtil.RTrim( Combo_propostaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Selectedtext_set", StringUtil.RTrim( Combo_propostaid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Enabled", StringUtil.BoolToStr( Combo_propostaid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Datalistproc", StringUtil.RTrim( Combo_propostaid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTAID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_propostaid_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "aprovacao"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7AprovacaoId,9,0));
         return formatLink("aprovacao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Aprovacao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aprovacao" ;
      }

      protected void InitializeNonKey1C51( )
      {
         A328PropostaCratedBy = 0;
         n328PropostaCratedBy = false;
         AssignAttri("", false, "A328PropostaCratedBy", StringUtil.LTrimStr( (decimal)(A328PropostaCratedBy), 4, 0));
         A375AprovadoresId = 0;
         n375AprovadoresId = false;
         AssignAttri("", false, "A375AprovadoresId", ((0==A375AprovadoresId)&&IsIns( )||n375AprovadoresId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", ""))));
         n375AprovadoresId = ((0==A375AprovadoresId) ? true : false);
         A323PropostaId = 0;
         n323PropostaId = false;
         AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
         n323PropostaId = ((0==A323PropostaId) ? true : false);
         A141SecUserName = "";
         n141SecUserName = false;
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
         A337AprovacaoEm = (DateTime)(DateTime.MinValue);
         n337AprovacaoEm = false;
         AssignAttri("", false, "A337AprovacaoEm", context.localUtil.TToC( A337AprovacaoEm, 10, 8, 0, 3, "/", ":", " "));
         n337AprovacaoEm = ((DateTime.MinValue==A337AprovacaoEm) ? true : false);
         A338AprovacaoDecisao = "";
         n338AprovacaoDecisao = false;
         AssignAttri("", false, "A338AprovacaoDecisao", A338AprovacaoDecisao);
         n338AprovacaoDecisao = (String.IsNullOrEmpty(StringUtil.RTrim( A338AprovacaoDecisao)) ? true : false);
         A340AprovacaoStatus = "";
         n340AprovacaoStatus = false;
         AssignAttri("", false, "A340AprovacaoStatus", A340AprovacaoStatus);
         n340AprovacaoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A340AprovacaoStatus)) ? true : false);
         Z337AprovacaoEm = (DateTime)(DateTime.MinValue);
         Z338AprovacaoDecisao = "";
         Z340AprovacaoStatus = "";
         Z323PropostaId = 0;
         Z375AprovadoresId = 0;
      }

      protected void InitAll1C51( )
      {
         A336AprovacaoId = 0;
         AssignAttri("", false, "A336AprovacaoId", StringUtil.LTrimStr( (decimal)(A336AprovacaoId), 9, 0));
         InitializeNonKey1C51( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019155857", true, true);
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
         context.AddJavascriptSource("aprovacao.js", "?202561019155858", false, true);
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
         edtAprovacaoId_Internalname = "APROVACAOID";
         lblTextblockaprovadoresid_Internalname = "TEXTBLOCKAPROVADORESID";
         Combo_aprovadoresid_Internalname = "COMBO_APROVADORESID";
         edtAprovadoresId_Internalname = "APROVADORESID";
         divTablesplittedaprovadoresid_Internalname = "TABLESPLITTEDAPROVADORESID";
         lblTextblockpropostaid_Internalname = "TEXTBLOCKPROPOSTAID";
         Combo_propostaid_Internalname = "COMBO_PROPOSTAID";
         edtPropostaId_Internalname = "PROPOSTAID";
         divTablesplittedpropostaid_Internalname = "TABLESPLITTEDPROPOSTAID";
         edtAprovacaoEm_Internalname = "APROVACAOEM";
         edtAprovacaoDecisao_Internalname = "APROVACAODECISAO";
         cmbAprovacaoStatus_Internalname = "APROVACAOSTATUS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboaprovadoresid_Internalname = "vCOMBOAPROVADORESID";
         divSectionattribute_aprovadoresid_Internalname = "SECTIONATTRIBUTE_APROVADORESID";
         edtavCombopropostaid_Internalname = "vCOMBOPROPOSTAID";
         divSectionattribute_propostaid_Internalname = "SECTIONATTRIBUTE_PROPOSTAID";
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
         Form.Caption = "Aprovacao";
         edtavCombopropostaid_Jsonclick = "";
         edtavCombopropostaid_Enabled = 0;
         edtavCombopropostaid_Visible = 1;
         edtavComboaprovadoresid_Jsonclick = "";
         edtavComboaprovadoresid_Enabled = 0;
         edtavComboaprovadoresid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbAprovacaoStatus_Jsonclick = "";
         cmbAprovacaoStatus.Enabled = 1;
         edtAprovacaoDecisao_Enabled = 1;
         edtAprovacaoEm_Jsonclick = "";
         edtAprovacaoEm_Enabled = 1;
         edtPropostaId_Jsonclick = "";
         edtPropostaId_Enabled = 1;
         edtPropostaId_Visible = 1;
         Combo_propostaid_Datalistprocparametersprefix = " \"ComboName\": \"PropostaId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"AprovacaoId\": 0";
         Combo_propostaid_Datalistproc = "AprovacaoLoadDVCombo";
         Combo_propostaid_Cls = "ExtendedCombo AttributeFL";
         Combo_propostaid_Caption = "";
         Combo_propostaid_Enabled = Convert.ToBoolean( -1);
         edtAprovadoresId_Jsonclick = "";
         edtAprovadoresId_Enabled = 1;
         edtAprovadoresId_Visible = 1;
         Combo_aprovadoresid_Datalistprocparametersprefix = " \"ComboName\": \"AprovadoresId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"AprovacaoId\": 0";
         Combo_aprovadoresid_Datalistproc = "AprovacaoLoadDVCombo";
         Combo_aprovadoresid_Cls = "ExtendedCombo AttributeFL";
         Combo_aprovadoresid_Caption = "";
         Combo_aprovadoresid_Enabled = Convert.ToBoolean( -1);
         edtAprovacaoId_Jsonclick = "";
         edtAprovacaoId_Enabled = 0;
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
         cmbAprovacaoStatus.Name = "APROVACAOSTATUS";
         cmbAprovacaoStatus.WebTags = "";
         cmbAprovacaoStatus.addItem("APROVADO", "Aprovado", 0);
         cmbAprovacaoStatus.addItem("REPROVADO", "Reprovado", 0);
         if ( cmbAprovacaoStatus.ItemCount > 0 )
         {
            A340AprovacaoStatus = cmbAprovacaoStatus.getValidValue(A340AprovacaoStatus);
            n340AprovacaoStatus = false;
            AssignAttri("", false, "A340AprovacaoStatus", A340AprovacaoStatus);
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

      public void Valid_Aprovadoresid( )
      {
         /* Using cursor T001C21 */
         pr_default.execute(19, new Object[] {n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A375AprovadoresId) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "APROVADORESID");
               AnyError = 1;
               GX_FocusControl = edtAprovadoresId_Internalname;
            }
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Propostaid( )
      {
         n328PropostaCratedBy = false;
         n141SecUserName = false;
         /* Using cursor T001C18 */
         pr_default.execute(16, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaId_Internalname;
            }
         }
         A328PropostaCratedBy = T001C18_A328PropostaCratedBy[0];
         n328PropostaCratedBy = T001C18_n328PropostaCratedBy[0];
         pr_default.close(16);
         /* Using cursor T001C19 */
         pr_default.execute(17, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A328PropostaCratedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTACRATEDBY");
               AnyError = 1;
            }
         }
         A141SecUserName = T001C19_A141SecUserName[0];
         n141SecUserName = T001C19_n141SecUserName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A328PropostaCratedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", "")));
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7AprovacaoId","fld":"vAPROVACAOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7AprovacaoId","fld":"vAPROVACAOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A336AprovacaoId","fld":"APROVACAOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_AprovadoresId","fld":"vINSERT_APROVADORESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_PropostaId","fld":"vINSERT_PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121C2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","nullAv":"n323PropostaId","type":"int"}]}""");
         setEventMetadata("VALID_APROVACAOID","""{"handler":"Valid_Aprovacaoid","iparms":[]}""");
         setEventMetadata("VALID_APROVADORESID","""{"handler":"Valid_Aprovadoresid","iparms":[{"av":"A375AprovadoresId","fld":"APROVADORESID","pic":"ZZZZZZZZ9","nullAv":"n375AprovadoresId","type":"int"}]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","nullAv":"n323PropostaId","type":"int"},{"av":"A328PropostaCratedBy","fld":"PROPOSTACRATEDBY","pic":"ZZZ9","type":"int"},{"av":"A141SecUserName","fld":"SECUSERNAME","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_PROPOSTAID",""","oparms":[{"av":"A328PropostaCratedBy","fld":"PROPOSTACRATEDBY","pic":"ZZZ9","type":"int"},{"av":"A141SecUserName","fld":"SECUSERNAME","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALID_APROVACAOSTATUS","""{"handler":"Valid_Aprovacaostatus","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOAPROVADORESID","""{"handler":"Validv_Comboaprovadoresid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOPROPOSTAID","""{"handler":"Validv_Combopropostaid","iparms":[]}""");
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
         pr_default.close(19);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z337AprovacaoEm = (DateTime)(DateTime.MinValue);
         Z338AprovacaoDecisao = "";
         Z340AprovacaoStatus = "";
         Combo_propostaid_Selectedvalue_get = "";
         Combo_aprovadoresid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A340AprovacaoStatus = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblockaprovadoresid_Jsonclick = "";
         ucCombo_aprovadoresid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14AprovadoresId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockpropostaid_Jsonclick = "";
         ucCombo_propostaid = new GXUserControl();
         AV20PropostaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A337AprovacaoEm = (DateTime)(DateTime.MinValue);
         A338AprovacaoDecisao = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A141SecUserName = "";
         AV22Pgmname = "";
         Combo_aprovadoresid_Objectcall = "";
         Combo_aprovadoresid_Class = "";
         Combo_aprovadoresid_Icontype = "";
         Combo_aprovadoresid_Icon = "";
         Combo_aprovadoresid_Tooltip = "";
         Combo_aprovadoresid_Selectedvalue_set = "";
         Combo_aprovadoresid_Selectedtext_set = "";
         Combo_aprovadoresid_Selectedtext_get = "";
         Combo_aprovadoresid_Gamoauthtoken = "";
         Combo_aprovadoresid_Ddointernalname = "";
         Combo_aprovadoresid_Titlecontrolalign = "";
         Combo_aprovadoresid_Dropdownoptionstype = "";
         Combo_aprovadoresid_Titlecontrolidtoreplace = "";
         Combo_aprovadoresid_Datalisttype = "";
         Combo_aprovadoresid_Datalistfixedvalues = "";
         Combo_aprovadoresid_Remoteservicesparameters = "";
         Combo_aprovadoresid_Htmltemplate = "";
         Combo_aprovadoresid_Multiplevaluestype = "";
         Combo_aprovadoresid_Loadingdata = "";
         Combo_aprovadoresid_Noresultsfound = "";
         Combo_aprovadoresid_Emptyitemtext = "";
         Combo_aprovadoresid_Onlyselectedvalues = "";
         Combo_aprovadoresid_Selectalltext = "";
         Combo_aprovadoresid_Multiplevaluesseparator = "";
         Combo_aprovadoresid_Addnewoptiontext = "";
         Combo_propostaid_Objectcall = "";
         Combo_propostaid_Class = "";
         Combo_propostaid_Icontype = "";
         Combo_propostaid_Icon = "";
         Combo_propostaid_Tooltip = "";
         Combo_propostaid_Selectedvalue_set = "";
         Combo_propostaid_Selectedtext_set = "";
         Combo_propostaid_Selectedtext_get = "";
         Combo_propostaid_Gamoauthtoken = "";
         Combo_propostaid_Ddointernalname = "";
         Combo_propostaid_Titlecontrolalign = "";
         Combo_propostaid_Dropdownoptionstype = "";
         Combo_propostaid_Titlecontrolidtoreplace = "";
         Combo_propostaid_Datalisttype = "";
         Combo_propostaid_Datalistfixedvalues = "";
         Combo_propostaid_Remoteservicesparameters = "";
         Combo_propostaid_Htmltemplate = "";
         Combo_propostaid_Multiplevaluestype = "";
         Combo_propostaid_Loadingdata = "";
         Combo_propostaid_Noresultsfound = "";
         Combo_propostaid_Emptyitemtext = "";
         Combo_propostaid_Onlyselectedvalues = "";
         Combo_propostaid_Selectalltext = "";
         Combo_propostaid_Multiplevaluesseparator = "";
         Combo_propostaid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode51 = "";
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
         GXEncryptionTmp = "";
         GXt_char2 = "";
         Z141SecUserName = "";
         T001C4_A328PropostaCratedBy = new short[1] ;
         T001C4_n328PropostaCratedBy = new bool[] {false} ;
         T001C6_A141SecUserName = new string[] {""} ;
         T001C6_n141SecUserName = new bool[] {false} ;
         T001C7_A328PropostaCratedBy = new short[1] ;
         T001C7_n328PropostaCratedBy = new bool[] {false} ;
         T001C7_A336AprovacaoId = new int[1] ;
         T001C7_A141SecUserName = new string[] {""} ;
         T001C7_n141SecUserName = new bool[] {false} ;
         T001C7_A337AprovacaoEm = new DateTime[] {DateTime.MinValue} ;
         T001C7_n337AprovacaoEm = new bool[] {false} ;
         T001C7_A338AprovacaoDecisao = new string[] {""} ;
         T001C7_n338AprovacaoDecisao = new bool[] {false} ;
         T001C7_A340AprovacaoStatus = new string[] {""} ;
         T001C7_n340AprovacaoStatus = new bool[] {false} ;
         T001C7_A323PropostaId = new int[1] ;
         T001C7_n323PropostaId = new bool[] {false} ;
         T001C7_A375AprovadoresId = new int[1] ;
         T001C7_n375AprovadoresId = new bool[] {false} ;
         T001C5_A375AprovadoresId = new int[1] ;
         T001C5_n375AprovadoresId = new bool[] {false} ;
         T001C8_A375AprovadoresId = new int[1] ;
         T001C8_n375AprovadoresId = new bool[] {false} ;
         T001C9_A328PropostaCratedBy = new short[1] ;
         T001C9_n328PropostaCratedBy = new bool[] {false} ;
         T001C10_A141SecUserName = new string[] {""} ;
         T001C10_n141SecUserName = new bool[] {false} ;
         T001C11_A336AprovacaoId = new int[1] ;
         T001C3_A336AprovacaoId = new int[1] ;
         T001C3_A337AprovacaoEm = new DateTime[] {DateTime.MinValue} ;
         T001C3_n337AprovacaoEm = new bool[] {false} ;
         T001C3_A338AprovacaoDecisao = new string[] {""} ;
         T001C3_n338AprovacaoDecisao = new bool[] {false} ;
         T001C3_A340AprovacaoStatus = new string[] {""} ;
         T001C3_n340AprovacaoStatus = new bool[] {false} ;
         T001C3_A323PropostaId = new int[1] ;
         T001C3_n323PropostaId = new bool[] {false} ;
         T001C3_A375AprovadoresId = new int[1] ;
         T001C3_n375AprovadoresId = new bool[] {false} ;
         T001C12_A336AprovacaoId = new int[1] ;
         T001C13_A336AprovacaoId = new int[1] ;
         T001C2_A336AprovacaoId = new int[1] ;
         T001C2_A337AprovacaoEm = new DateTime[] {DateTime.MinValue} ;
         T001C2_n337AprovacaoEm = new bool[] {false} ;
         T001C2_A338AprovacaoDecisao = new string[] {""} ;
         T001C2_n338AprovacaoDecisao = new bool[] {false} ;
         T001C2_A340AprovacaoStatus = new string[] {""} ;
         T001C2_n340AprovacaoStatus = new bool[] {false} ;
         T001C2_A323PropostaId = new int[1] ;
         T001C2_n323PropostaId = new bool[] {false} ;
         T001C2_A375AprovadoresId = new int[1] ;
         T001C2_n375AprovadoresId = new bool[] {false} ;
         T001C15_A336AprovacaoId = new int[1] ;
         T001C18_A328PropostaCratedBy = new short[1] ;
         T001C18_n328PropostaCratedBy = new bool[] {false} ;
         T001C19_A141SecUserName = new string[] {""} ;
         T001C19_n141SecUserName = new bool[] {false} ;
         T001C20_A336AprovacaoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001C21_A375AprovadoresId = new int[1] ;
         T001C21_n375AprovadoresId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprovacao__default(),
            new Object[][] {
                new Object[] {
               T001C2_A336AprovacaoId, T001C2_A337AprovacaoEm, T001C2_n337AprovacaoEm, T001C2_A338AprovacaoDecisao, T001C2_n338AprovacaoDecisao, T001C2_A340AprovacaoStatus, T001C2_n340AprovacaoStatus, T001C2_A323PropostaId, T001C2_n323PropostaId, T001C2_A375AprovadoresId,
               T001C2_n375AprovadoresId
               }
               , new Object[] {
               T001C3_A336AprovacaoId, T001C3_A337AprovacaoEm, T001C3_n337AprovacaoEm, T001C3_A338AprovacaoDecisao, T001C3_n338AprovacaoDecisao, T001C3_A340AprovacaoStatus, T001C3_n340AprovacaoStatus, T001C3_A323PropostaId, T001C3_n323PropostaId, T001C3_A375AprovadoresId,
               T001C3_n375AprovadoresId
               }
               , new Object[] {
               T001C4_A328PropostaCratedBy, T001C4_n328PropostaCratedBy
               }
               , new Object[] {
               T001C5_A375AprovadoresId
               }
               , new Object[] {
               T001C6_A141SecUserName, T001C6_n141SecUserName
               }
               , new Object[] {
               T001C7_A328PropostaCratedBy, T001C7_n328PropostaCratedBy, T001C7_A336AprovacaoId, T001C7_A141SecUserName, T001C7_n141SecUserName, T001C7_A337AprovacaoEm, T001C7_n337AprovacaoEm, T001C7_A338AprovacaoDecisao, T001C7_n338AprovacaoDecisao, T001C7_A340AprovacaoStatus,
               T001C7_n340AprovacaoStatus, T001C7_A323PropostaId, T001C7_n323PropostaId, T001C7_A375AprovadoresId, T001C7_n375AprovadoresId
               }
               , new Object[] {
               T001C8_A375AprovadoresId
               }
               , new Object[] {
               T001C9_A328PropostaCratedBy, T001C9_n328PropostaCratedBy
               }
               , new Object[] {
               T001C10_A141SecUserName, T001C10_n141SecUserName
               }
               , new Object[] {
               T001C11_A336AprovacaoId
               }
               , new Object[] {
               T001C12_A336AprovacaoId
               }
               , new Object[] {
               T001C13_A336AprovacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               T001C15_A336AprovacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001C18_A328PropostaCratedBy, T001C18_n328PropostaCratedBy
               }
               , new Object[] {
               T001C19_A141SecUserName, T001C19_n141SecUserName
               }
               , new Object[] {
               T001C20_A336AprovacaoId
               }
               , new Object[] {
               T001C21_A375AprovadoresId
               }
            }
         );
         AV22Pgmname = "Aprovacao";
      }

      private short GxWebError ;
      private short A328PropostaCratedBy ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound51 ;
      private short gxcookieaux ;
      private short Z328PropostaCratedBy ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7AprovacaoId ;
      private int Z336AprovacaoId ;
      private int Z323PropostaId ;
      private int Z375AprovadoresId ;
      private int N375AprovadoresId ;
      private int N323PropostaId ;
      private int A375AprovadoresId ;
      private int A323PropostaId ;
      private int AV7AprovacaoId ;
      private int trnEnded ;
      private int A336AprovacaoId ;
      private int edtAprovacaoId_Enabled ;
      private int edtAprovadoresId_Visible ;
      private int edtAprovadoresId_Enabled ;
      private int edtPropostaId_Visible ;
      private int edtPropostaId_Enabled ;
      private int edtAprovacaoEm_Enabled ;
      private int edtAprovacaoDecisao_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboAprovadoresId ;
      private int edtavComboaprovadoresid_Enabled ;
      private int edtavComboaprovadoresid_Visible ;
      private int AV21ComboPropostaId ;
      private int edtavCombopropostaid_Enabled ;
      private int edtavCombopropostaid_Visible ;
      private int AV11Insert_AprovadoresId ;
      private int AV12Insert_PropostaId ;
      private int Combo_aprovadoresid_Datalistupdateminimumcharacters ;
      private int Combo_aprovadoresid_Gxcontroltype ;
      private int Combo_propostaid_Datalistupdateminimumcharacters ;
      private int Combo_propostaid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV23GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_propostaid_Selectedvalue_get ;
      private string Combo_aprovadoresid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAprovadoresId_Internalname ;
      private string cmbAprovacaoStatus_Internalname ;
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
      private string edtAprovacaoId_Internalname ;
      private string TempTags ;
      private string edtAprovacaoId_Jsonclick ;
      private string divTablesplittedaprovadoresid_Internalname ;
      private string lblTextblockaprovadoresid_Internalname ;
      private string lblTextblockaprovadoresid_Jsonclick ;
      private string Combo_aprovadoresid_Caption ;
      private string Combo_aprovadoresid_Cls ;
      private string Combo_aprovadoresid_Datalistproc ;
      private string Combo_aprovadoresid_Datalistprocparametersprefix ;
      private string Combo_aprovadoresid_Internalname ;
      private string edtAprovadoresId_Jsonclick ;
      private string divTablesplittedpropostaid_Internalname ;
      private string lblTextblockpropostaid_Internalname ;
      private string lblTextblockpropostaid_Jsonclick ;
      private string Combo_propostaid_Caption ;
      private string Combo_propostaid_Cls ;
      private string Combo_propostaid_Datalistproc ;
      private string Combo_propostaid_Datalistprocparametersprefix ;
      private string Combo_propostaid_Internalname ;
      private string edtPropostaId_Internalname ;
      private string edtPropostaId_Jsonclick ;
      private string edtAprovacaoEm_Internalname ;
      private string edtAprovacaoEm_Jsonclick ;
      private string edtAprovacaoDecisao_Internalname ;
      private string cmbAprovacaoStatus_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_aprovadoresid_Internalname ;
      private string edtavComboaprovadoresid_Internalname ;
      private string edtavComboaprovadoresid_Jsonclick ;
      private string divSectionattribute_propostaid_Internalname ;
      private string edtavCombopropostaid_Internalname ;
      private string edtavCombopropostaid_Jsonclick ;
      private string AV22Pgmname ;
      private string Combo_aprovadoresid_Objectcall ;
      private string Combo_aprovadoresid_Class ;
      private string Combo_aprovadoresid_Icontype ;
      private string Combo_aprovadoresid_Icon ;
      private string Combo_aprovadoresid_Tooltip ;
      private string Combo_aprovadoresid_Selectedvalue_set ;
      private string Combo_aprovadoresid_Selectedtext_set ;
      private string Combo_aprovadoresid_Selectedtext_get ;
      private string Combo_aprovadoresid_Gamoauthtoken ;
      private string Combo_aprovadoresid_Ddointernalname ;
      private string Combo_aprovadoresid_Titlecontrolalign ;
      private string Combo_aprovadoresid_Dropdownoptionstype ;
      private string Combo_aprovadoresid_Titlecontrolidtoreplace ;
      private string Combo_aprovadoresid_Datalisttype ;
      private string Combo_aprovadoresid_Datalistfixedvalues ;
      private string Combo_aprovadoresid_Remoteservicesparameters ;
      private string Combo_aprovadoresid_Htmltemplate ;
      private string Combo_aprovadoresid_Multiplevaluestype ;
      private string Combo_aprovadoresid_Loadingdata ;
      private string Combo_aprovadoresid_Noresultsfound ;
      private string Combo_aprovadoresid_Emptyitemtext ;
      private string Combo_aprovadoresid_Onlyselectedvalues ;
      private string Combo_aprovadoresid_Selectalltext ;
      private string Combo_aprovadoresid_Multiplevaluesseparator ;
      private string Combo_aprovadoresid_Addnewoptiontext ;
      private string Combo_propostaid_Objectcall ;
      private string Combo_propostaid_Class ;
      private string Combo_propostaid_Icontype ;
      private string Combo_propostaid_Icon ;
      private string Combo_propostaid_Tooltip ;
      private string Combo_propostaid_Selectedvalue_set ;
      private string Combo_propostaid_Selectedtext_set ;
      private string Combo_propostaid_Selectedtext_get ;
      private string Combo_propostaid_Gamoauthtoken ;
      private string Combo_propostaid_Ddointernalname ;
      private string Combo_propostaid_Titlecontrolalign ;
      private string Combo_propostaid_Dropdownoptionstype ;
      private string Combo_propostaid_Titlecontrolidtoreplace ;
      private string Combo_propostaid_Datalisttype ;
      private string Combo_propostaid_Datalistfixedvalues ;
      private string Combo_propostaid_Remoteservicesparameters ;
      private string Combo_propostaid_Htmltemplate ;
      private string Combo_propostaid_Multiplevaluestype ;
      private string Combo_propostaid_Loadingdata ;
      private string Combo_propostaid_Noresultsfound ;
      private string Combo_propostaid_Emptyitemtext ;
      private string Combo_propostaid_Onlyselectedvalues ;
      private string Combo_propostaid_Selectalltext ;
      private string Combo_propostaid_Multiplevaluesseparator ;
      private string Combo_propostaid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode51 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z337AprovacaoEm ;
      private DateTime A337AprovacaoEm ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n375AprovadoresId ;
      private bool n323PropostaId ;
      private bool n328PropostaCratedBy ;
      private bool wbErr ;
      private bool n340AprovacaoStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n337AprovacaoEm ;
      private bool n338AprovacaoDecisao ;
      private bool n141SecUserName ;
      private bool Combo_aprovadoresid_Enabled ;
      private bool Combo_aprovadoresid_Visible ;
      private bool Combo_aprovadoresid_Allowmultipleselection ;
      private bool Combo_aprovadoresid_Isgriditem ;
      private bool Combo_aprovadoresid_Hasdescription ;
      private bool Combo_aprovadoresid_Includeonlyselectedoption ;
      private bool Combo_aprovadoresid_Includeselectalloption ;
      private bool Combo_aprovadoresid_Emptyitem ;
      private bool Combo_aprovadoresid_Includeaddnewoption ;
      private bool Combo_propostaid_Enabled ;
      private bool Combo_propostaid_Visible ;
      private bool Combo_propostaid_Allowmultipleselection ;
      private bool Combo_propostaid_Isgriditem ;
      private bool Combo_propostaid_Hasdescription ;
      private bool Combo_propostaid_Includeonlyselectedoption ;
      private bool Combo_propostaid_Includeselectalloption ;
      private bool Combo_propostaid_Emptyitem ;
      private bool Combo_propostaid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV18Combo_DataJson ;
      private string Z338AprovacaoDecisao ;
      private string Z340AprovacaoStatus ;
      private string A340AprovacaoStatus ;
      private string A338AprovacaoDecisao ;
      private string A141SecUserName ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private string Z141SecUserName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_aprovadoresid ;
      private GXUserControl ucCombo_propostaid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAprovacaoStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14AprovadoresId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV20PropostaId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T001C4_A328PropostaCratedBy ;
      private bool[] T001C4_n328PropostaCratedBy ;
      private string[] T001C6_A141SecUserName ;
      private bool[] T001C6_n141SecUserName ;
      private short[] T001C7_A328PropostaCratedBy ;
      private bool[] T001C7_n328PropostaCratedBy ;
      private int[] T001C7_A336AprovacaoId ;
      private string[] T001C7_A141SecUserName ;
      private bool[] T001C7_n141SecUserName ;
      private DateTime[] T001C7_A337AprovacaoEm ;
      private bool[] T001C7_n337AprovacaoEm ;
      private string[] T001C7_A338AprovacaoDecisao ;
      private bool[] T001C7_n338AprovacaoDecisao ;
      private string[] T001C7_A340AprovacaoStatus ;
      private bool[] T001C7_n340AprovacaoStatus ;
      private int[] T001C7_A323PropostaId ;
      private bool[] T001C7_n323PropostaId ;
      private int[] T001C7_A375AprovadoresId ;
      private bool[] T001C7_n375AprovadoresId ;
      private int[] T001C5_A375AprovadoresId ;
      private bool[] T001C5_n375AprovadoresId ;
      private int[] T001C8_A375AprovadoresId ;
      private bool[] T001C8_n375AprovadoresId ;
      private short[] T001C9_A328PropostaCratedBy ;
      private bool[] T001C9_n328PropostaCratedBy ;
      private string[] T001C10_A141SecUserName ;
      private bool[] T001C10_n141SecUserName ;
      private int[] T001C11_A336AprovacaoId ;
      private int[] T001C3_A336AprovacaoId ;
      private DateTime[] T001C3_A337AprovacaoEm ;
      private bool[] T001C3_n337AprovacaoEm ;
      private string[] T001C3_A338AprovacaoDecisao ;
      private bool[] T001C3_n338AprovacaoDecisao ;
      private string[] T001C3_A340AprovacaoStatus ;
      private bool[] T001C3_n340AprovacaoStatus ;
      private int[] T001C3_A323PropostaId ;
      private bool[] T001C3_n323PropostaId ;
      private int[] T001C3_A375AprovadoresId ;
      private bool[] T001C3_n375AprovadoresId ;
      private int[] T001C12_A336AprovacaoId ;
      private int[] T001C13_A336AprovacaoId ;
      private int[] T001C2_A336AprovacaoId ;
      private DateTime[] T001C2_A337AprovacaoEm ;
      private bool[] T001C2_n337AprovacaoEm ;
      private string[] T001C2_A338AprovacaoDecisao ;
      private bool[] T001C2_n338AprovacaoDecisao ;
      private string[] T001C2_A340AprovacaoStatus ;
      private bool[] T001C2_n340AprovacaoStatus ;
      private int[] T001C2_A323PropostaId ;
      private bool[] T001C2_n323PropostaId ;
      private int[] T001C2_A375AprovadoresId ;
      private bool[] T001C2_n375AprovadoresId ;
      private int[] T001C15_A336AprovacaoId ;
      private short[] T001C18_A328PropostaCratedBy ;
      private bool[] T001C18_n328PropostaCratedBy ;
      private string[] T001C19_A141SecUserName ;
      private bool[] T001C19_n141SecUserName ;
      private int[] T001C20_A336AprovacaoId ;
      private int[] T001C21_A375AprovadoresId ;
      private bool[] T001C21_n375AprovadoresId ;
   }

   public class aprovacao__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[19])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001C2;
          prmT001C2 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001C3;
          prmT001C3 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001C4;
          prmT001C4 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001C5;
          prmT001C5 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001C6;
          prmT001C6 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001C7;
          prmT001C7 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001C8;
          prmT001C8 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001C9;
          prmT001C9 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001C10;
          prmT001C10 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001C11;
          prmT001C11 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001C12;
          prmT001C12 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001C13;
          prmT001C13 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001C14;
          prmT001C14 = new Object[] {
          new ParDef("AprovacaoEm",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AprovacaoDecisao",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("AprovacaoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001C15;
          prmT001C15 = new Object[] {
          };
          Object[] prmT001C16;
          prmT001C16 = new Object[] {
          new ParDef("AprovacaoEm",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AprovacaoDecisao",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("AprovacaoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001C17;
          prmT001C17 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001C18;
          prmT001C18 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001C19;
          prmT001C19 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001C20;
          prmT001C20 = new Object[] {
          };
          Object[] prmT001C21;
          prmT001C21 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001C2", "SELECT AprovacaoId, AprovacaoEm, AprovacaoDecisao, AprovacaoStatus, PropostaId, AprovadoresId FROM Aprovacao WHERE AprovacaoId = :AprovacaoId  FOR UPDATE OF Aprovacao NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C3", "SELECT AprovacaoId, AprovacaoEm, AprovacaoDecisao, AprovacaoStatus, PropostaId, AprovadoresId FROM Aprovacao WHERE AprovacaoId = :AprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C4", "SELECT PropostaCratedBy FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C5", "SELECT AprovadoresId FROM Aprovadores WHERE AprovadoresId = :AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C6", "SELECT SecUserName FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C7", "SELECT T2.PropostaCratedBy AS PropostaCratedBy, TM1.AprovacaoId, T3.SecUserName, TM1.AprovacaoEm, TM1.AprovacaoDecisao, TM1.AprovacaoStatus, TM1.PropostaId, TM1.AprovadoresId FROM ((Aprovacao TM1 LEFT JOIN Proposta T2 ON T2.PropostaId = TM1.PropostaId) LEFT JOIN SecUser T3 ON T3.SecUserId = T2.PropostaCratedBy) WHERE TM1.AprovacaoId = :AprovacaoId ORDER BY TM1.AprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C8", "SELECT AprovadoresId FROM Aprovadores WHERE AprovadoresId = :AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C9", "SELECT PropostaCratedBy FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C10", "SELECT SecUserName FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C11", "SELECT AprovacaoId FROM Aprovacao WHERE AprovacaoId = :AprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C12", "SELECT AprovacaoId FROM Aprovacao WHERE ( AprovacaoId > :AprovacaoId) ORDER BY AprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001C13", "SELECT AprovacaoId FROM Aprovacao WHERE ( AprovacaoId < :AprovacaoId) ORDER BY AprovacaoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001C14", "SAVEPOINT gxupdate;INSERT INTO Aprovacao(AprovacaoEm, AprovacaoDecisao, AprovacaoStatus, PropostaId, AprovadoresId) VALUES(:AprovacaoEm, :AprovacaoDecisao, :AprovacaoStatus, :PropostaId, :AprovadoresId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001C14)
             ,new CursorDef("T001C15", "SELECT currval('AprovacaoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C16", "SAVEPOINT gxupdate;UPDATE Aprovacao SET AprovacaoEm=:AprovacaoEm, AprovacaoDecisao=:AprovacaoDecisao, AprovacaoStatus=:AprovacaoStatus, PropostaId=:PropostaId, AprovadoresId=:AprovadoresId  WHERE AprovacaoId = :AprovacaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001C16)
             ,new CursorDef("T001C17", "SAVEPOINT gxupdate;DELETE FROM Aprovacao  WHERE AprovacaoId = :AprovacaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001C17)
             ,new CursorDef("T001C18", "SELECT PropostaCratedBy FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C19", "SELECT SecUserName FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C20", "SELECT AprovacaoId FROM Aprovacao ORDER BY AprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C20,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001C21", "SELECT AprovadoresId FROM Aprovadores WHERE AprovadoresId = :AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C21,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
