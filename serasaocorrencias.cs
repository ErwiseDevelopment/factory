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
   public class serasaocorrencias : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A662SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
            n662SerasaId = false;
            AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A662SerasaId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "serasaocorrencias")), "serasaocorrencias") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "serasaocorrencias")))) ;
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
                  AV7SerasaOcorrenciasId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaOcorrenciasId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(AV7SerasaOcorrenciasId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSERASAOCORRENCIASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SerasaOcorrenciasId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Serasa Ocorrencias", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSerasaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public serasaocorrencias( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasaocorrencias( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_SerasaOcorrenciasId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SerasaOcorrenciasId = aP1_SerasaOcorrenciasId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaOcorrenciasId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaOcorrenciasId_Internalname, "Ocorrencias Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaOcorrenciasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A726SerasaOcorrenciasId), 9, 0, ",", "")), StringUtil.LTrim( ((edtSerasaOcorrenciasId_Enabled!=0) ? context.localUtil.Format( (decimal)(A726SerasaOcorrenciasId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A726SerasaOcorrenciasId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaOcorrenciasId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaOcorrenciasId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SerasaOcorrencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedserasaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockserasaid_Internalname, "Serasa", "", "", lblTextblockserasaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_SerasaOcorrencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_serasaid.SetProperty("Caption", Combo_serasaid_Caption);
         ucCombo_serasaid.SetProperty("Cls", Combo_serasaid_Cls);
         ucCombo_serasaid.SetProperty("DataListProc", Combo_serasaid_Datalistproc);
         ucCombo_serasaid.SetProperty("DataListProcParametersPrefix", Combo_serasaid_Datalistprocparametersprefix);
         ucCombo_serasaid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_serasaid.SetProperty("DropDownOptionsData", AV13SerasaId_Data);
         ucCombo_serasaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_serasaid_Internalname, "COMBO_SERASAIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaId_Internalname, "Serasa Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaId_Internalname, ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ",", ""))), ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A662SerasaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaId_Jsonclick, 0, "Attribute", "", "", "", "", edtSerasaId_Visible, edtSerasaId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SerasaOcorrencias.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaOcorrenciasData_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaOcorrenciasData_Internalname, "da ocorrência", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSerasaOcorrenciasData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSerasaOcorrenciasData_Internalname, context.localUtil.Format(A727SerasaOcorrenciasData, "99/99/99"), context.localUtil.Format( A727SerasaOcorrenciasData, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaOcorrenciasData_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaOcorrenciasData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SerasaOcorrencias.htm");
         GxWebStd.gx_bitmap( context, edtSerasaOcorrenciasData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSerasaOcorrenciasData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_SerasaOcorrencias.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaOcorrenciasOrigem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaOcorrenciasOrigem_Internalname, "Origem", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaOcorrenciasOrigem_Internalname, A728SerasaOcorrenciasOrigem, StringUtil.RTrim( context.localUtil.Format( A728SerasaOcorrenciasOrigem, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaOcorrenciasOrigem_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaOcorrenciasOrigem_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaOcorrencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaOcorrenciasModalidade_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaOcorrenciasModalidade_Internalname, "Modalidade", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaOcorrenciasModalidade_Internalname, A729SerasaOcorrenciasModalidade, StringUtil.RTrim( context.localUtil.Format( A729SerasaOcorrenciasModalidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaOcorrenciasModalidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaOcorrenciasModalidade_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaOcorrencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaOcorrenciasTipoMoeda_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaOcorrenciasTipoMoeda_Internalname, "Tipo Moeda", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaOcorrenciasTipoMoeda_Internalname, A730SerasaOcorrenciasTipoMoeda, StringUtil.RTrim( context.localUtil.Format( A730SerasaOcorrenciasTipoMoeda, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaOcorrenciasTipoMoeda_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaOcorrenciasTipoMoeda_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaOcorrencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaOcorrenciasValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaOcorrenciasValor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaOcorrenciasValor_Internalname, ((Convert.ToDecimal(0)==A731SerasaOcorrenciasValor)&&IsIns( )||n731SerasaOcorrenciasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A731SerasaOcorrenciasValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A731SerasaOcorrenciasValor)&&IsIns( )||n731SerasaOcorrenciasValor ? "" : StringUtil.LTrim( ((edtSerasaOcorrenciasValor_Enabled!=0) ? context.localUtil.Format( A731SerasaOcorrenciasValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A731SerasaOcorrenciasValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaOcorrenciasValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaOcorrenciasValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_SerasaOcorrencias.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaOcorrencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaOcorrencias.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaOcorrencias.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_serasaid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboserasaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ComboSerasaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboserasaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ComboSerasaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV18ComboSerasaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboserasaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboserasaid_Visible, edtavComboserasaid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SerasaOcorrencias.htm");
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
         E112J2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vSERASAID_DATA"), AV13SerasaId_Data);
               /* Read saved values. */
               Z726SerasaOcorrenciasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z726SerasaOcorrenciasId"), ",", "."), 18, MidpointRounding.ToEven));
               Z727SerasaOcorrenciasData = context.localUtil.CToD( cgiGet( "Z727SerasaOcorrenciasData"), 0);
               n727SerasaOcorrenciasData = ((DateTime.MinValue==A727SerasaOcorrenciasData) ? true : false);
               Z728SerasaOcorrenciasOrigem = cgiGet( "Z728SerasaOcorrenciasOrigem");
               n728SerasaOcorrenciasOrigem = (String.IsNullOrEmpty(StringUtil.RTrim( A728SerasaOcorrenciasOrigem)) ? true : false);
               Z729SerasaOcorrenciasModalidade = cgiGet( "Z729SerasaOcorrenciasModalidade");
               n729SerasaOcorrenciasModalidade = (String.IsNullOrEmpty(StringUtil.RTrim( A729SerasaOcorrenciasModalidade)) ? true : false);
               Z730SerasaOcorrenciasTipoMoeda = cgiGet( "Z730SerasaOcorrenciasTipoMoeda");
               n730SerasaOcorrenciasTipoMoeda = (String.IsNullOrEmpty(StringUtil.RTrim( A730SerasaOcorrenciasTipoMoeda)) ? true : false);
               Z731SerasaOcorrenciasValor = context.localUtil.CToN( cgiGet( "Z731SerasaOcorrenciasValor"), ",", ".");
               n731SerasaOcorrenciasValor = ((Convert.ToDecimal(0)==A731SerasaOcorrenciasValor) ? true : false);
               Z662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z662SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
               n662SerasaId = ((0==A662SerasaId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N662SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
               n662SerasaId = ((0==A662SerasaId) ? true : false);
               AV7SerasaOcorrenciasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vSERASAOCORRENCIASID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SERASAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_SerasaId", StringUtil.LTrimStr( (decimal)(AV11Insert_SerasaId), 9, 0));
               AV19Pgmname = cgiGet( "vPGMNAME");
               Combo_serasaid_Objectcall = cgiGet( "COMBO_SERASAID_Objectcall");
               Combo_serasaid_Class = cgiGet( "COMBO_SERASAID_Class");
               Combo_serasaid_Icontype = cgiGet( "COMBO_SERASAID_Icontype");
               Combo_serasaid_Icon = cgiGet( "COMBO_SERASAID_Icon");
               Combo_serasaid_Caption = cgiGet( "COMBO_SERASAID_Caption");
               Combo_serasaid_Tooltip = cgiGet( "COMBO_SERASAID_Tooltip");
               Combo_serasaid_Cls = cgiGet( "COMBO_SERASAID_Cls");
               Combo_serasaid_Selectedvalue_set = cgiGet( "COMBO_SERASAID_Selectedvalue_set");
               Combo_serasaid_Selectedvalue_get = cgiGet( "COMBO_SERASAID_Selectedvalue_get");
               Combo_serasaid_Selectedtext_set = cgiGet( "COMBO_SERASAID_Selectedtext_set");
               Combo_serasaid_Selectedtext_get = cgiGet( "COMBO_SERASAID_Selectedtext_get");
               Combo_serasaid_Gamoauthtoken = cgiGet( "COMBO_SERASAID_Gamoauthtoken");
               Combo_serasaid_Ddointernalname = cgiGet( "COMBO_SERASAID_Ddointernalname");
               Combo_serasaid_Titlecontrolalign = cgiGet( "COMBO_SERASAID_Titlecontrolalign");
               Combo_serasaid_Dropdownoptionstype = cgiGet( "COMBO_SERASAID_Dropdownoptionstype");
               Combo_serasaid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SERASAID_Enabled"));
               Combo_serasaid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SERASAID_Visible"));
               Combo_serasaid_Titlecontrolidtoreplace = cgiGet( "COMBO_SERASAID_Titlecontrolidtoreplace");
               Combo_serasaid_Datalisttype = cgiGet( "COMBO_SERASAID_Datalisttype");
               Combo_serasaid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SERASAID_Allowmultipleselection"));
               Combo_serasaid_Datalistfixedvalues = cgiGet( "COMBO_SERASAID_Datalistfixedvalues");
               Combo_serasaid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SERASAID_Isgriditem"));
               Combo_serasaid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SERASAID_Hasdescription"));
               Combo_serasaid_Datalistproc = cgiGet( "COMBO_SERASAID_Datalistproc");
               Combo_serasaid_Datalistprocparametersprefix = cgiGet( "COMBO_SERASAID_Datalistprocparametersprefix");
               Combo_serasaid_Remoteservicesparameters = cgiGet( "COMBO_SERASAID_Remoteservicesparameters");
               Combo_serasaid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SERASAID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_serasaid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SERASAID_Includeonlyselectedoption"));
               Combo_serasaid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SERASAID_Includeselectalloption"));
               Combo_serasaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SERASAID_Emptyitem"));
               Combo_serasaid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SERASAID_Includeaddnewoption"));
               Combo_serasaid_Htmltemplate = cgiGet( "COMBO_SERASAID_Htmltemplate");
               Combo_serasaid_Multiplevaluestype = cgiGet( "COMBO_SERASAID_Multiplevaluestype");
               Combo_serasaid_Loadingdata = cgiGet( "COMBO_SERASAID_Loadingdata");
               Combo_serasaid_Noresultsfound = cgiGet( "COMBO_SERASAID_Noresultsfound");
               Combo_serasaid_Emptyitemtext = cgiGet( "COMBO_SERASAID_Emptyitemtext");
               Combo_serasaid_Onlyselectedvalues = cgiGet( "COMBO_SERASAID_Onlyselectedvalues");
               Combo_serasaid_Selectalltext = cgiGet( "COMBO_SERASAID_Selectalltext");
               Combo_serasaid_Multiplevaluesseparator = cgiGet( "COMBO_SERASAID_Multiplevaluesseparator");
               Combo_serasaid_Addnewoptiontext = cgiGet( "COMBO_SERASAID_Addnewoptiontext");
               Combo_serasaid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SERASAID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A726SerasaOcorrenciasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaOcorrenciasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
               n662SerasaId = ((StringUtil.StrCmp(cgiGet( edtSerasaId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASAID");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A662SerasaId = 0;
                  n662SerasaId = false;
                  AssignAttri("", false, "A662SerasaId", (n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
               }
               else
               {
                  A662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A662SerasaId", (n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
               }
               if ( context.localUtil.VCDate( cgiGet( edtSerasaOcorrenciasData_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data da ocorrência"}), 1, "SERASAOCORRENCIASDATA");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaOcorrenciasData_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A727SerasaOcorrenciasData = DateTime.MinValue;
                  n727SerasaOcorrenciasData = false;
                  AssignAttri("", false, "A727SerasaOcorrenciasData", context.localUtil.Format(A727SerasaOcorrenciasData, "99/99/99"));
               }
               else
               {
                  A727SerasaOcorrenciasData = context.localUtil.CToD( cgiGet( edtSerasaOcorrenciasData_Internalname), 2);
                  n727SerasaOcorrenciasData = false;
                  AssignAttri("", false, "A727SerasaOcorrenciasData", context.localUtil.Format(A727SerasaOcorrenciasData, "99/99/99"));
               }
               n727SerasaOcorrenciasData = ((DateTime.MinValue==A727SerasaOcorrenciasData) ? true : false);
               A728SerasaOcorrenciasOrigem = cgiGet( edtSerasaOcorrenciasOrigem_Internalname);
               n728SerasaOcorrenciasOrigem = false;
               AssignAttri("", false, "A728SerasaOcorrenciasOrigem", A728SerasaOcorrenciasOrigem);
               n728SerasaOcorrenciasOrigem = (String.IsNullOrEmpty(StringUtil.RTrim( A728SerasaOcorrenciasOrigem)) ? true : false);
               A729SerasaOcorrenciasModalidade = cgiGet( edtSerasaOcorrenciasModalidade_Internalname);
               n729SerasaOcorrenciasModalidade = false;
               AssignAttri("", false, "A729SerasaOcorrenciasModalidade", A729SerasaOcorrenciasModalidade);
               n729SerasaOcorrenciasModalidade = (String.IsNullOrEmpty(StringUtil.RTrim( A729SerasaOcorrenciasModalidade)) ? true : false);
               A730SerasaOcorrenciasTipoMoeda = cgiGet( edtSerasaOcorrenciasTipoMoeda_Internalname);
               n730SerasaOcorrenciasTipoMoeda = false;
               AssignAttri("", false, "A730SerasaOcorrenciasTipoMoeda", A730SerasaOcorrenciasTipoMoeda);
               n730SerasaOcorrenciasTipoMoeda = (String.IsNullOrEmpty(StringUtil.RTrim( A730SerasaOcorrenciasTipoMoeda)) ? true : false);
               n731SerasaOcorrenciasValor = ((StringUtil.StrCmp(cgiGet( edtSerasaOcorrenciasValor_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaOcorrenciasValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaOcorrenciasValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASAOCORRENCIASVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaOcorrenciasValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A731SerasaOcorrenciasValor = 0;
                  n731SerasaOcorrenciasValor = false;
                  AssignAttri("", false, "A731SerasaOcorrenciasValor", (n731SerasaOcorrenciasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A731SerasaOcorrenciasValor, 18, 2, ".", ""))));
               }
               else
               {
                  A731SerasaOcorrenciasValor = context.localUtil.CToN( cgiGet( edtSerasaOcorrenciasValor_Internalname), ",", ".");
                  AssignAttri("", false, "A731SerasaOcorrenciasValor", (n731SerasaOcorrenciasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A731SerasaOcorrenciasValor, 18, 2, ".", ""))));
               }
               AV18ComboSerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboserasaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18ComboSerasaId", StringUtil.LTrimStr( (decimal)(AV18ComboSerasaId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SerasaOcorrencias");
               A726SerasaOcorrenciasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaOcorrenciasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
               forbiddenHiddens.Add("SerasaOcorrenciasId", context.localUtil.Format( (decimal)(A726SerasaOcorrenciasId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_SerasaId", context.localUtil.Format( (decimal)(AV11Insert_SerasaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A726SerasaOcorrenciasId != Z726SerasaOcorrenciasId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("serasaocorrencias:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A726SerasaOcorrenciasId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaOcorrenciasId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
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
                     sMode89 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode89;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound89 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2J0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SERASAOCORRENCIASID");
                        AnyError = 1;
                        GX_FocusControl = edtSerasaOcorrenciasId_Internalname;
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
                           E112J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122J2 ();
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
            E122J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2J89( ) ;
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
            DisableAttributes2J89( ) ;
         }
         AssignProp("", false, edtavComboserasaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboserasaid_Enabled), 5, 0), true);
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

      protected void CONFIRM_2J0( )
      {
         BeforeValidate2J89( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2J89( ) ;
            }
            else
            {
               CheckExtendedTable2J89( ) ;
               CloseExtendedTableCursors2J89( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2J0( )
      {
      }

      protected void E112J2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtSerasaId_Visible = 0;
         AssignProp("", false, edtSerasaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSerasaId_Visible), 5, 0), true);
         AV18ComboSerasaId = 0;
         AssignAttri("", false, "AV18ComboSerasaId", StringUtil.LTrimStr( (decimal)(AV18ComboSerasaId), 9, 0));
         edtavComboserasaid_Visible = 0;
         AssignProp("", false, edtavComboserasaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboserasaid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSERASAID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV19Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV20GXV1 = 1;
            AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            while ( AV20GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV20GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SerasaId") == 0 )
               {
                  AV11Insert_SerasaId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_SerasaId", StringUtil.LTrimStr( (decimal)(AV11Insert_SerasaId), 9, 0));
                  if ( ! (0==AV11Insert_SerasaId) )
                  {
                     AV18ComboSerasaId = AV11Insert_SerasaId;
                     AssignAttri("", false, "AV18ComboSerasaId", StringUtil.LTrimStr( (decimal)(AV18ComboSerasaId), 9, 0));
                     Combo_serasaid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV18ComboSerasaId), 9, 0));
                     ucCombo_serasaid.SendProperty(context, "", false, Combo_serasaid_Internalname, "SelectedValue_set", Combo_serasaid_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new serasaocorrenciasloaddvcombo(context ).execute(  "SerasaId",  "GET",  false,  AV7SerasaOcorrenciasId,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_serasaid_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_serasaid.SendProperty(context, "", false, Combo_serasaid_Internalname, "SelectedText_set", Combo_serasaid_Selectedtext_set);
                     Combo_serasaid_Enabled = false;
                     ucCombo_serasaid.SendProperty(context, "", false, Combo_serasaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_serasaid_Enabled));
                  }
               }
               AV20GXV1 = (int)(AV20GXV1+1);
               AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            }
         }
      }

      protected void E122J2( )
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

      protected void S112( )
      {
         /* 'LOADCOMBOSERASAID' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new serasaocorrenciasloaddvcombo(context ).execute(  "SerasaId",  Gx_mode,  false,  AV7SerasaOcorrenciasId,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_serasaid_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_serasaid.SendProperty(context, "", false, Combo_serasaid_Internalname, "SelectedValue_set", Combo_serasaid_Selectedvalue_set);
         Combo_serasaid_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_serasaid.SendProperty(context, "", false, Combo_serasaid_Internalname, "SelectedText_set", Combo_serasaid_Selectedtext_set);
         AV18ComboSerasaId = (int)(Math.Round(NumberUtil.Val( AV15ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV18ComboSerasaId", StringUtil.LTrimStr( (decimal)(AV18ComboSerasaId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_serasaid_Enabled = false;
            ucCombo_serasaid.SendProperty(context, "", false, Combo_serasaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_serasaid_Enabled));
         }
      }

      protected void ZM2J89( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z727SerasaOcorrenciasData = T002J3_A727SerasaOcorrenciasData[0];
               Z728SerasaOcorrenciasOrigem = T002J3_A728SerasaOcorrenciasOrigem[0];
               Z729SerasaOcorrenciasModalidade = T002J3_A729SerasaOcorrenciasModalidade[0];
               Z730SerasaOcorrenciasTipoMoeda = T002J3_A730SerasaOcorrenciasTipoMoeda[0];
               Z731SerasaOcorrenciasValor = T002J3_A731SerasaOcorrenciasValor[0];
               Z662SerasaId = T002J3_A662SerasaId[0];
            }
            else
            {
               Z727SerasaOcorrenciasData = A727SerasaOcorrenciasData;
               Z728SerasaOcorrenciasOrigem = A728SerasaOcorrenciasOrigem;
               Z729SerasaOcorrenciasModalidade = A729SerasaOcorrenciasModalidade;
               Z730SerasaOcorrenciasTipoMoeda = A730SerasaOcorrenciasTipoMoeda;
               Z731SerasaOcorrenciasValor = A731SerasaOcorrenciasValor;
               Z662SerasaId = A662SerasaId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z726SerasaOcorrenciasId = A726SerasaOcorrenciasId;
            Z727SerasaOcorrenciasData = A727SerasaOcorrenciasData;
            Z728SerasaOcorrenciasOrigem = A728SerasaOcorrenciasOrigem;
            Z729SerasaOcorrenciasModalidade = A729SerasaOcorrenciasModalidade;
            Z730SerasaOcorrenciasTipoMoeda = A730SerasaOcorrenciasTipoMoeda;
            Z731SerasaOcorrenciasValor = A731SerasaOcorrenciasValor;
            Z662SerasaId = A662SerasaId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSerasaOcorrenciasId_Enabled = 0;
         AssignProp("", false, edtSerasaOcorrenciasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaOcorrenciasId_Enabled), 5, 0), true);
         AV19Pgmname = "SerasaOcorrencias";
         AssignAttri("", false, "AV19Pgmname", AV19Pgmname);
         edtSerasaOcorrenciasId_Enabled = 0;
         AssignProp("", false, edtSerasaOcorrenciasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaOcorrenciasId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SerasaOcorrenciasId) )
         {
            A726SerasaOcorrenciasId = AV7SerasaOcorrenciasId;
            AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_SerasaId) )
         {
            edtSerasaId_Enabled = 0;
            AssignProp("", false, edtSerasaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaId_Enabled), 5, 0), true);
         }
         else
         {
            edtSerasaId_Enabled = 1;
            AssignProp("", false, edtSerasaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_SerasaId) )
         {
            A662SerasaId = AV11Insert_SerasaId;
            n662SerasaId = false;
            AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV18ComboSerasaId) )
            {
               A662SerasaId = 0;
               n662SerasaId = false;
               AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
               n662SerasaId = true;
               n662SerasaId = true;
               AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV18ComboSerasaId) )
               {
                  A662SerasaId = AV18ComboSerasaId;
                  n662SerasaId = false;
                  AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
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
      }

      protected void Load2J89( )
      {
         /* Using cursor T002J5 */
         pr_default.execute(3, new Object[] {A726SerasaOcorrenciasId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound89 = 1;
            A727SerasaOcorrenciasData = T002J5_A727SerasaOcorrenciasData[0];
            n727SerasaOcorrenciasData = T002J5_n727SerasaOcorrenciasData[0];
            AssignAttri("", false, "A727SerasaOcorrenciasData", context.localUtil.Format(A727SerasaOcorrenciasData, "99/99/99"));
            A728SerasaOcorrenciasOrigem = T002J5_A728SerasaOcorrenciasOrigem[0];
            n728SerasaOcorrenciasOrigem = T002J5_n728SerasaOcorrenciasOrigem[0];
            AssignAttri("", false, "A728SerasaOcorrenciasOrigem", A728SerasaOcorrenciasOrigem);
            A729SerasaOcorrenciasModalidade = T002J5_A729SerasaOcorrenciasModalidade[0];
            n729SerasaOcorrenciasModalidade = T002J5_n729SerasaOcorrenciasModalidade[0];
            AssignAttri("", false, "A729SerasaOcorrenciasModalidade", A729SerasaOcorrenciasModalidade);
            A730SerasaOcorrenciasTipoMoeda = T002J5_A730SerasaOcorrenciasTipoMoeda[0];
            n730SerasaOcorrenciasTipoMoeda = T002J5_n730SerasaOcorrenciasTipoMoeda[0];
            AssignAttri("", false, "A730SerasaOcorrenciasTipoMoeda", A730SerasaOcorrenciasTipoMoeda);
            A731SerasaOcorrenciasValor = T002J5_A731SerasaOcorrenciasValor[0];
            n731SerasaOcorrenciasValor = T002J5_n731SerasaOcorrenciasValor[0];
            AssignAttri("", false, "A731SerasaOcorrenciasValor", ((Convert.ToDecimal(0)==A731SerasaOcorrenciasValor)&&IsIns( )||n731SerasaOcorrenciasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A731SerasaOcorrenciasValor, 18, 2, ".", ""))));
            A662SerasaId = T002J5_A662SerasaId[0];
            n662SerasaId = T002J5_n662SerasaId[0];
            AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            ZM2J89( -9) ;
         }
         pr_default.close(3);
         OnLoadActions2J89( ) ;
      }

      protected void OnLoadActions2J89( )
      {
      }

      protected void CheckExtendedTable2J89( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002J4 */
         pr_default.execute(2, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A662SerasaId) ) )
            {
               GX_msglist.addItem("Não existe 'Serasa'.", "ForeignKeyNotFound", 1, "SERASAID");
               AnyError = 1;
               GX_FocusControl = edtSerasaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         if ( ( A731SerasaOcorrenciasValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "SERASAOCORRENCIASVALOR");
            AnyError = 1;
            GX_FocusControl = edtSerasaOcorrenciasValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2J89( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( int A662SerasaId )
      {
         /* Using cursor T002J6 */
         pr_default.execute(4, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A662SerasaId) ) )
            {
               GX_msglist.addItem("Não existe 'Serasa'.", "ForeignKeyNotFound", 1, "SERASAID");
               AnyError = 1;
               GX_FocusControl = edtSerasaId_Internalname;
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

      protected void GetKey2J89( )
      {
         /* Using cursor T002J7 */
         pr_default.execute(5, new Object[] {A726SerasaOcorrenciasId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound89 = 1;
         }
         else
         {
            RcdFound89 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002J3 */
         pr_default.execute(1, new Object[] {A726SerasaOcorrenciasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2J89( 9) ;
            RcdFound89 = 1;
            A726SerasaOcorrenciasId = T002J3_A726SerasaOcorrenciasId[0];
            AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
            A727SerasaOcorrenciasData = T002J3_A727SerasaOcorrenciasData[0];
            n727SerasaOcorrenciasData = T002J3_n727SerasaOcorrenciasData[0];
            AssignAttri("", false, "A727SerasaOcorrenciasData", context.localUtil.Format(A727SerasaOcorrenciasData, "99/99/99"));
            A728SerasaOcorrenciasOrigem = T002J3_A728SerasaOcorrenciasOrigem[0];
            n728SerasaOcorrenciasOrigem = T002J3_n728SerasaOcorrenciasOrigem[0];
            AssignAttri("", false, "A728SerasaOcorrenciasOrigem", A728SerasaOcorrenciasOrigem);
            A729SerasaOcorrenciasModalidade = T002J3_A729SerasaOcorrenciasModalidade[0];
            n729SerasaOcorrenciasModalidade = T002J3_n729SerasaOcorrenciasModalidade[0];
            AssignAttri("", false, "A729SerasaOcorrenciasModalidade", A729SerasaOcorrenciasModalidade);
            A730SerasaOcorrenciasTipoMoeda = T002J3_A730SerasaOcorrenciasTipoMoeda[0];
            n730SerasaOcorrenciasTipoMoeda = T002J3_n730SerasaOcorrenciasTipoMoeda[0];
            AssignAttri("", false, "A730SerasaOcorrenciasTipoMoeda", A730SerasaOcorrenciasTipoMoeda);
            A731SerasaOcorrenciasValor = T002J3_A731SerasaOcorrenciasValor[0];
            n731SerasaOcorrenciasValor = T002J3_n731SerasaOcorrenciasValor[0];
            AssignAttri("", false, "A731SerasaOcorrenciasValor", ((Convert.ToDecimal(0)==A731SerasaOcorrenciasValor)&&IsIns( )||n731SerasaOcorrenciasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A731SerasaOcorrenciasValor, 18, 2, ".", ""))));
            A662SerasaId = T002J3_A662SerasaId[0];
            n662SerasaId = T002J3_n662SerasaId[0];
            AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            Z726SerasaOcorrenciasId = A726SerasaOcorrenciasId;
            sMode89 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2J89( ) ;
            if ( AnyError == 1 )
            {
               RcdFound89 = 0;
               InitializeNonKey2J89( ) ;
            }
            Gx_mode = sMode89;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound89 = 0;
            InitializeNonKey2J89( ) ;
            sMode89 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode89;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2J89( ) ;
         if ( RcdFound89 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound89 = 0;
         /* Using cursor T002J8 */
         pr_default.execute(6, new Object[] {A726SerasaOcorrenciasId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T002J8_A726SerasaOcorrenciasId[0] < A726SerasaOcorrenciasId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T002J8_A726SerasaOcorrenciasId[0] > A726SerasaOcorrenciasId ) ) )
            {
               A726SerasaOcorrenciasId = T002J8_A726SerasaOcorrenciasId[0];
               AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
               RcdFound89 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound89 = 0;
         /* Using cursor T002J9 */
         pr_default.execute(7, new Object[] {A726SerasaOcorrenciasId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T002J9_A726SerasaOcorrenciasId[0] > A726SerasaOcorrenciasId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T002J9_A726SerasaOcorrenciasId[0] < A726SerasaOcorrenciasId ) ) )
            {
               A726SerasaOcorrenciasId = T002J9_A726SerasaOcorrenciasId[0];
               AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
               RcdFound89 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2J89( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSerasaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2J89( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound89 == 1 )
            {
               if ( A726SerasaOcorrenciasId != Z726SerasaOcorrenciasId )
               {
                  A726SerasaOcorrenciasId = Z726SerasaOcorrenciasId;
                  AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SERASAOCORRENCIASID");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaOcorrenciasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSerasaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2J89( ) ;
                  GX_FocusControl = edtSerasaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A726SerasaOcorrenciasId != Z726SerasaOcorrenciasId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSerasaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2J89( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SERASAOCORRENCIASID");
                     AnyError = 1;
                     GX_FocusControl = edtSerasaOcorrenciasId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSerasaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2J89( ) ;
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
         if ( A726SerasaOcorrenciasId != Z726SerasaOcorrenciasId )
         {
            A726SerasaOcorrenciasId = Z726SerasaOcorrenciasId;
            AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SERASAOCORRENCIASID");
            AnyError = 1;
            GX_FocusControl = edtSerasaOcorrenciasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSerasaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2J89( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002J2 */
            pr_default.execute(0, new Object[] {A726SerasaOcorrenciasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaOcorrencias"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z727SerasaOcorrenciasData ) != DateTimeUtil.ResetTime ( T002J2_A727SerasaOcorrenciasData[0] ) ) || ( StringUtil.StrCmp(Z728SerasaOcorrenciasOrigem, T002J2_A728SerasaOcorrenciasOrigem[0]) != 0 ) || ( StringUtil.StrCmp(Z729SerasaOcorrenciasModalidade, T002J2_A729SerasaOcorrenciasModalidade[0]) != 0 ) || ( StringUtil.StrCmp(Z730SerasaOcorrenciasTipoMoeda, T002J2_A730SerasaOcorrenciasTipoMoeda[0]) != 0 ) || ( Z731SerasaOcorrenciasValor != T002J2_A731SerasaOcorrenciasValor[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z662SerasaId != T002J2_A662SerasaId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z727SerasaOcorrenciasData ) != DateTimeUtil.ResetTime ( T002J2_A727SerasaOcorrenciasData[0] ) )
               {
                  GXUtil.WriteLog("serasaocorrencias:[seudo value changed for attri]"+"SerasaOcorrenciasData");
                  GXUtil.WriteLogRaw("Old: ",Z727SerasaOcorrenciasData);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A727SerasaOcorrenciasData[0]);
               }
               if ( StringUtil.StrCmp(Z728SerasaOcorrenciasOrigem, T002J2_A728SerasaOcorrenciasOrigem[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaocorrencias:[seudo value changed for attri]"+"SerasaOcorrenciasOrigem");
                  GXUtil.WriteLogRaw("Old: ",Z728SerasaOcorrenciasOrigem);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A728SerasaOcorrenciasOrigem[0]);
               }
               if ( StringUtil.StrCmp(Z729SerasaOcorrenciasModalidade, T002J2_A729SerasaOcorrenciasModalidade[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaocorrencias:[seudo value changed for attri]"+"SerasaOcorrenciasModalidade");
                  GXUtil.WriteLogRaw("Old: ",Z729SerasaOcorrenciasModalidade);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A729SerasaOcorrenciasModalidade[0]);
               }
               if ( StringUtil.StrCmp(Z730SerasaOcorrenciasTipoMoeda, T002J2_A730SerasaOcorrenciasTipoMoeda[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaocorrencias:[seudo value changed for attri]"+"SerasaOcorrenciasTipoMoeda");
                  GXUtil.WriteLogRaw("Old: ",Z730SerasaOcorrenciasTipoMoeda);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A730SerasaOcorrenciasTipoMoeda[0]);
               }
               if ( Z731SerasaOcorrenciasValor != T002J2_A731SerasaOcorrenciasValor[0] )
               {
                  GXUtil.WriteLog("serasaocorrencias:[seudo value changed for attri]"+"SerasaOcorrenciasValor");
                  GXUtil.WriteLogRaw("Old: ",Z731SerasaOcorrenciasValor);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A731SerasaOcorrenciasValor[0]);
               }
               if ( Z662SerasaId != T002J2_A662SerasaId[0] )
               {
                  GXUtil.WriteLog("serasaocorrencias:[seudo value changed for attri]"+"SerasaId");
                  GXUtil.WriteLogRaw("Old: ",Z662SerasaId);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A662SerasaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SerasaOcorrencias"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2J89( )
      {
         BeforeValidate2J89( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2J89( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2J89( 0) ;
            CheckOptimisticConcurrency2J89( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2J89( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2J89( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002J10 */
                     pr_default.execute(8, new Object[] {n727SerasaOcorrenciasData, A727SerasaOcorrenciasData, n728SerasaOcorrenciasOrigem, A728SerasaOcorrenciasOrigem, n729SerasaOcorrenciasModalidade, A729SerasaOcorrenciasModalidade, n730SerasaOcorrenciasTipoMoeda, A730SerasaOcorrenciasTipoMoeda, n731SerasaOcorrenciasValor, A731SerasaOcorrenciasValor, n662SerasaId, A662SerasaId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002J11 */
                     pr_default.execute(9);
                     A726SerasaOcorrenciasId = T002J11_A726SerasaOcorrenciasId[0];
                     AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaOcorrencias");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2J0( ) ;
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
               Load2J89( ) ;
            }
            EndLevel2J89( ) ;
         }
         CloseExtendedTableCursors2J89( ) ;
      }

      protected void Update2J89( )
      {
         BeforeValidate2J89( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2J89( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2J89( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2J89( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2J89( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002J12 */
                     pr_default.execute(10, new Object[] {n727SerasaOcorrenciasData, A727SerasaOcorrenciasData, n728SerasaOcorrenciasOrigem, A728SerasaOcorrenciasOrigem, n729SerasaOcorrenciasModalidade, A729SerasaOcorrenciasModalidade, n730SerasaOcorrenciasTipoMoeda, A730SerasaOcorrenciasTipoMoeda, n731SerasaOcorrenciasValor, A731SerasaOcorrenciasValor, n662SerasaId, A662SerasaId, A726SerasaOcorrenciasId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaOcorrencias");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaOcorrencias"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2J89( ) ;
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
            EndLevel2J89( ) ;
         }
         CloseExtendedTableCursors2J89( ) ;
      }

      protected void DeferredUpdate2J89( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2J89( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2J89( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2J89( ) ;
            AfterConfirm2J89( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2J89( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002J13 */
                  pr_default.execute(11, new Object[] {A726SerasaOcorrenciasId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("SerasaOcorrencias");
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
         sMode89 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2J89( ) ;
         Gx_mode = sMode89;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2J89( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2J89( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2J89( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2J0( ) ;
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

      public void ScanStart2J89( )
      {
         /* Scan By routine */
         /* Using cursor T002J14 */
         pr_default.execute(12);
         RcdFound89 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound89 = 1;
            A726SerasaOcorrenciasId = T002J14_A726SerasaOcorrenciasId[0];
            AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2J89( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound89 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound89 = 1;
            A726SerasaOcorrenciasId = T002J14_A726SerasaOcorrenciasId[0];
            AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
         }
      }

      protected void ScanEnd2J89( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm2J89( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2J89( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2J89( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2J89( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2J89( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2J89( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2J89( )
      {
         edtSerasaOcorrenciasId_Enabled = 0;
         AssignProp("", false, edtSerasaOcorrenciasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaOcorrenciasId_Enabled), 5, 0), true);
         edtSerasaId_Enabled = 0;
         AssignProp("", false, edtSerasaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaId_Enabled), 5, 0), true);
         edtSerasaOcorrenciasData_Enabled = 0;
         AssignProp("", false, edtSerasaOcorrenciasData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaOcorrenciasData_Enabled), 5, 0), true);
         edtSerasaOcorrenciasOrigem_Enabled = 0;
         AssignProp("", false, edtSerasaOcorrenciasOrigem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaOcorrenciasOrigem_Enabled), 5, 0), true);
         edtSerasaOcorrenciasModalidade_Enabled = 0;
         AssignProp("", false, edtSerasaOcorrenciasModalidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaOcorrenciasModalidade_Enabled), 5, 0), true);
         edtSerasaOcorrenciasTipoMoeda_Enabled = 0;
         AssignProp("", false, edtSerasaOcorrenciasTipoMoeda_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaOcorrenciasTipoMoeda_Enabled), 5, 0), true);
         edtSerasaOcorrenciasValor_Enabled = 0;
         AssignProp("", false, edtSerasaOcorrenciasValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaOcorrenciasValor_Enabled), 5, 0), true);
         edtavComboserasaid_Enabled = 0;
         AssignProp("", false, edtavComboserasaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboserasaid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2J89( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2J0( )
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
         GXEncryptionTmp = "serasaocorrencias"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SerasaOcorrenciasId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("serasaocorrencias") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SerasaOcorrencias");
         forbiddenHiddens.Add("SerasaOcorrenciasId", context.localUtil.Format( (decimal)(A726SerasaOcorrenciasId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_SerasaId", context.localUtil.Format( (decimal)(AV11Insert_SerasaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("serasaocorrencias:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z726SerasaOcorrenciasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z726SerasaOcorrenciasId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z727SerasaOcorrenciasData", context.localUtil.DToC( Z727SerasaOcorrenciasData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z728SerasaOcorrenciasOrigem", Z728SerasaOcorrenciasOrigem);
         GxWebStd.gx_hidden_field( context, "Z729SerasaOcorrenciasModalidade", Z729SerasaOcorrenciasModalidade);
         GxWebStd.gx_hidden_field( context, "Z730SerasaOcorrenciasTipoMoeda", Z730SerasaOcorrenciasTipoMoeda);
         GxWebStd.gx_hidden_field( context, "Z731SerasaOcorrenciasValor", StringUtil.LTrim( StringUtil.NToC( Z731SerasaOcorrenciasValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z662SerasaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z662SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N662SerasaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSERASAID_DATA", AV13SerasaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSERASAID_DATA", AV13SerasaId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vSERASAOCORRENCIASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SerasaOcorrenciasId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSERASAOCORRENCIASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SerasaOcorrenciasId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SERASAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV19Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_SERASAID_Objectcall", StringUtil.RTrim( Combo_serasaid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SERASAID_Cls", StringUtil.RTrim( Combo_serasaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SERASAID_Selectedvalue_set", StringUtil.RTrim( Combo_serasaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SERASAID_Selectedtext_set", StringUtil.RTrim( Combo_serasaid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SERASAID_Enabled", StringUtil.BoolToStr( Combo_serasaid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SERASAID_Datalistproc", StringUtil.RTrim( Combo_serasaid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SERASAID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_serasaid_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "serasaocorrencias"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SerasaOcorrenciasId,9,0));
         return formatLink("serasaocorrencias") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SerasaOcorrencias" ;
      }

      public override string GetPgmdesc( )
      {
         return "Serasa Ocorrencias" ;
      }

      protected void InitializeNonKey2J89( )
      {
         A662SerasaId = 0;
         n662SerasaId = false;
         AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
         n662SerasaId = ((0==A662SerasaId) ? true : false);
         A727SerasaOcorrenciasData = DateTime.MinValue;
         n727SerasaOcorrenciasData = false;
         AssignAttri("", false, "A727SerasaOcorrenciasData", context.localUtil.Format(A727SerasaOcorrenciasData, "99/99/99"));
         n727SerasaOcorrenciasData = ((DateTime.MinValue==A727SerasaOcorrenciasData) ? true : false);
         A728SerasaOcorrenciasOrigem = "";
         n728SerasaOcorrenciasOrigem = false;
         AssignAttri("", false, "A728SerasaOcorrenciasOrigem", A728SerasaOcorrenciasOrigem);
         n728SerasaOcorrenciasOrigem = (String.IsNullOrEmpty(StringUtil.RTrim( A728SerasaOcorrenciasOrigem)) ? true : false);
         A729SerasaOcorrenciasModalidade = "";
         n729SerasaOcorrenciasModalidade = false;
         AssignAttri("", false, "A729SerasaOcorrenciasModalidade", A729SerasaOcorrenciasModalidade);
         n729SerasaOcorrenciasModalidade = (String.IsNullOrEmpty(StringUtil.RTrim( A729SerasaOcorrenciasModalidade)) ? true : false);
         A730SerasaOcorrenciasTipoMoeda = "";
         n730SerasaOcorrenciasTipoMoeda = false;
         AssignAttri("", false, "A730SerasaOcorrenciasTipoMoeda", A730SerasaOcorrenciasTipoMoeda);
         n730SerasaOcorrenciasTipoMoeda = (String.IsNullOrEmpty(StringUtil.RTrim( A730SerasaOcorrenciasTipoMoeda)) ? true : false);
         A731SerasaOcorrenciasValor = 0;
         n731SerasaOcorrenciasValor = false;
         AssignAttri("", false, "A731SerasaOcorrenciasValor", ((Convert.ToDecimal(0)==A731SerasaOcorrenciasValor)&&IsIns( )||n731SerasaOcorrenciasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A731SerasaOcorrenciasValor, 18, 2, ".", ""))));
         n731SerasaOcorrenciasValor = ((Convert.ToDecimal(0)==A731SerasaOcorrenciasValor) ? true : false);
         Z727SerasaOcorrenciasData = DateTime.MinValue;
         Z728SerasaOcorrenciasOrigem = "";
         Z729SerasaOcorrenciasModalidade = "";
         Z730SerasaOcorrenciasTipoMoeda = "";
         Z731SerasaOcorrenciasValor = 0;
         Z662SerasaId = 0;
      }

      protected void InitAll2J89( )
      {
         A726SerasaOcorrenciasId = 0;
         AssignAttri("", false, "A726SerasaOcorrenciasId", StringUtil.LTrimStr( (decimal)(A726SerasaOcorrenciasId), 9, 0));
         InitializeNonKey2J89( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019202628", true, true);
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
         context.AddJavascriptSource("serasaocorrencias.js", "?202561019202629", false, true);
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
         edtSerasaOcorrenciasId_Internalname = "SERASAOCORRENCIASID";
         lblTextblockserasaid_Internalname = "TEXTBLOCKSERASAID";
         Combo_serasaid_Internalname = "COMBO_SERASAID";
         edtSerasaId_Internalname = "SERASAID";
         divTablesplittedserasaid_Internalname = "TABLESPLITTEDSERASAID";
         edtSerasaOcorrenciasData_Internalname = "SERASAOCORRENCIASDATA";
         edtSerasaOcorrenciasOrigem_Internalname = "SERASAOCORRENCIASORIGEM";
         edtSerasaOcorrenciasModalidade_Internalname = "SERASAOCORRENCIASMODALIDADE";
         edtSerasaOcorrenciasTipoMoeda_Internalname = "SERASAOCORRENCIASTIPOMOEDA";
         edtSerasaOcorrenciasValor_Internalname = "SERASAOCORRENCIASVALOR";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboserasaid_Internalname = "vCOMBOSERASAID";
         divSectionattribute_serasaid_Internalname = "SECTIONATTRIBUTE_SERASAID";
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
         Form.Caption = "Serasa Ocorrencias";
         edtavComboserasaid_Jsonclick = "";
         edtavComboserasaid_Enabled = 0;
         edtavComboserasaid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSerasaOcorrenciasValor_Jsonclick = "";
         edtSerasaOcorrenciasValor_Enabled = 1;
         edtSerasaOcorrenciasTipoMoeda_Jsonclick = "";
         edtSerasaOcorrenciasTipoMoeda_Enabled = 1;
         edtSerasaOcorrenciasModalidade_Jsonclick = "";
         edtSerasaOcorrenciasModalidade_Enabled = 1;
         edtSerasaOcorrenciasOrigem_Jsonclick = "";
         edtSerasaOcorrenciasOrigem_Enabled = 1;
         edtSerasaOcorrenciasData_Jsonclick = "";
         edtSerasaOcorrenciasData_Enabled = 1;
         edtSerasaId_Jsonclick = "";
         edtSerasaId_Enabled = 1;
         edtSerasaId_Visible = 1;
         Combo_serasaid_Datalistprocparametersprefix = " \"ComboName\": \"SerasaId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"SerasaOcorrenciasId\": 0";
         Combo_serasaid_Datalistproc = "SerasaOcorrenciasLoadDVCombo";
         Combo_serasaid_Cls = "ExtendedCombo AttributeFL";
         Combo_serasaid_Caption = "";
         Combo_serasaid_Enabled = Convert.ToBoolean( -1);
         edtSerasaOcorrenciasId_Jsonclick = "";
         edtSerasaOcorrenciasId_Enabled = 0;
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

      public void Valid_Serasaid( )
      {
         /* Using cursor T002J15 */
         pr_default.execute(13, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A662SerasaId) ) )
            {
               GX_msglist.addItem("Não existe 'Serasa'.", "ForeignKeyNotFound", 1, "SERASAID");
               AnyError = 1;
               GX_FocusControl = edtSerasaId_Internalname;
            }
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SerasaOcorrenciasId","fld":"vSERASAOCORRENCIASID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SerasaOcorrenciasId","fld":"vSERASAOCORRENCIASID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A726SerasaOcorrenciasId","fld":"SERASAOCORRENCIASID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_SerasaId","fld":"vINSERT_SERASAID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122J2","iparms":[]}""");
         setEventMetadata("VALID_SERASAOCORRENCIASID","""{"handler":"Valid_Serasaocorrenciasid","iparms":[]}""");
         setEventMetadata("VALID_SERASAID","""{"handler":"Valid_Serasaid","iparms":[{"av":"A662SerasaId","fld":"SERASAID","pic":"ZZZZZZZZ9","nullAv":"n662SerasaId","type":"int"}]}""");
         setEventMetadata("VALID_SERASAOCORRENCIASVALOR","""{"handler":"Valid_Serasaocorrenciasvalor","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSERASAID","""{"handler":"Validv_Comboserasaid","iparms":[]}""");
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
         Z727SerasaOcorrenciasData = DateTime.MinValue;
         Z728SerasaOcorrenciasOrigem = "";
         Z729SerasaOcorrenciasModalidade = "";
         Z730SerasaOcorrenciasTipoMoeda = "";
         Combo_serasaid_Selectedvalue_get = "";
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
         lblTextblockserasaid_Jsonclick = "";
         ucCombo_serasaid = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13SerasaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A727SerasaOcorrenciasData = DateTime.MinValue;
         A728SerasaOcorrenciasOrigem = "";
         A729SerasaOcorrenciasModalidade = "";
         A730SerasaOcorrenciasTipoMoeda = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV19Pgmname = "";
         Combo_serasaid_Objectcall = "";
         Combo_serasaid_Class = "";
         Combo_serasaid_Icontype = "";
         Combo_serasaid_Icon = "";
         Combo_serasaid_Tooltip = "";
         Combo_serasaid_Selectedvalue_set = "";
         Combo_serasaid_Selectedtext_set = "";
         Combo_serasaid_Selectedtext_get = "";
         Combo_serasaid_Gamoauthtoken = "";
         Combo_serasaid_Ddointernalname = "";
         Combo_serasaid_Titlecontrolalign = "";
         Combo_serasaid_Dropdownoptionstype = "";
         Combo_serasaid_Titlecontrolidtoreplace = "";
         Combo_serasaid_Datalisttype = "";
         Combo_serasaid_Datalistfixedvalues = "";
         Combo_serasaid_Remoteservicesparameters = "";
         Combo_serasaid_Htmltemplate = "";
         Combo_serasaid_Multiplevaluestype = "";
         Combo_serasaid_Loadingdata = "";
         Combo_serasaid_Noresultsfound = "";
         Combo_serasaid_Emptyitemtext = "";
         Combo_serasaid_Onlyselectedvalues = "";
         Combo_serasaid_Selectalltext = "";
         Combo_serasaid_Multiplevaluesseparator = "";
         Combo_serasaid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode89 = "";
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
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV17Combo_DataJson = "";
         AV15ComboSelectedValue = "";
         AV16ComboSelectedText = "";
         GXt_char2 = "";
         T002J5_A726SerasaOcorrenciasId = new int[1] ;
         T002J5_A727SerasaOcorrenciasData = new DateTime[] {DateTime.MinValue} ;
         T002J5_n727SerasaOcorrenciasData = new bool[] {false} ;
         T002J5_A728SerasaOcorrenciasOrigem = new string[] {""} ;
         T002J5_n728SerasaOcorrenciasOrigem = new bool[] {false} ;
         T002J5_A729SerasaOcorrenciasModalidade = new string[] {""} ;
         T002J5_n729SerasaOcorrenciasModalidade = new bool[] {false} ;
         T002J5_A730SerasaOcorrenciasTipoMoeda = new string[] {""} ;
         T002J5_n730SerasaOcorrenciasTipoMoeda = new bool[] {false} ;
         T002J5_A731SerasaOcorrenciasValor = new decimal[1] ;
         T002J5_n731SerasaOcorrenciasValor = new bool[] {false} ;
         T002J5_A662SerasaId = new int[1] ;
         T002J5_n662SerasaId = new bool[] {false} ;
         T002J4_A662SerasaId = new int[1] ;
         T002J4_n662SerasaId = new bool[] {false} ;
         T002J6_A662SerasaId = new int[1] ;
         T002J6_n662SerasaId = new bool[] {false} ;
         T002J7_A726SerasaOcorrenciasId = new int[1] ;
         T002J3_A726SerasaOcorrenciasId = new int[1] ;
         T002J3_A727SerasaOcorrenciasData = new DateTime[] {DateTime.MinValue} ;
         T002J3_n727SerasaOcorrenciasData = new bool[] {false} ;
         T002J3_A728SerasaOcorrenciasOrigem = new string[] {""} ;
         T002J3_n728SerasaOcorrenciasOrigem = new bool[] {false} ;
         T002J3_A729SerasaOcorrenciasModalidade = new string[] {""} ;
         T002J3_n729SerasaOcorrenciasModalidade = new bool[] {false} ;
         T002J3_A730SerasaOcorrenciasTipoMoeda = new string[] {""} ;
         T002J3_n730SerasaOcorrenciasTipoMoeda = new bool[] {false} ;
         T002J3_A731SerasaOcorrenciasValor = new decimal[1] ;
         T002J3_n731SerasaOcorrenciasValor = new bool[] {false} ;
         T002J3_A662SerasaId = new int[1] ;
         T002J3_n662SerasaId = new bool[] {false} ;
         T002J8_A726SerasaOcorrenciasId = new int[1] ;
         T002J9_A726SerasaOcorrenciasId = new int[1] ;
         T002J2_A726SerasaOcorrenciasId = new int[1] ;
         T002J2_A727SerasaOcorrenciasData = new DateTime[] {DateTime.MinValue} ;
         T002J2_n727SerasaOcorrenciasData = new bool[] {false} ;
         T002J2_A728SerasaOcorrenciasOrigem = new string[] {""} ;
         T002J2_n728SerasaOcorrenciasOrigem = new bool[] {false} ;
         T002J2_A729SerasaOcorrenciasModalidade = new string[] {""} ;
         T002J2_n729SerasaOcorrenciasModalidade = new bool[] {false} ;
         T002J2_A730SerasaOcorrenciasTipoMoeda = new string[] {""} ;
         T002J2_n730SerasaOcorrenciasTipoMoeda = new bool[] {false} ;
         T002J2_A731SerasaOcorrenciasValor = new decimal[1] ;
         T002J2_n731SerasaOcorrenciasValor = new bool[] {false} ;
         T002J2_A662SerasaId = new int[1] ;
         T002J2_n662SerasaId = new bool[] {false} ;
         T002J11_A726SerasaOcorrenciasId = new int[1] ;
         T002J14_A726SerasaOcorrenciasId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T002J15_A662SerasaId = new int[1] ;
         T002J15_n662SerasaId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaocorrencias__default(),
            new Object[][] {
                new Object[] {
               T002J2_A726SerasaOcorrenciasId, T002J2_A727SerasaOcorrenciasData, T002J2_n727SerasaOcorrenciasData, T002J2_A728SerasaOcorrenciasOrigem, T002J2_n728SerasaOcorrenciasOrigem, T002J2_A729SerasaOcorrenciasModalidade, T002J2_n729SerasaOcorrenciasModalidade, T002J2_A730SerasaOcorrenciasTipoMoeda, T002J2_n730SerasaOcorrenciasTipoMoeda, T002J2_A731SerasaOcorrenciasValor,
               T002J2_n731SerasaOcorrenciasValor, T002J2_A662SerasaId, T002J2_n662SerasaId
               }
               , new Object[] {
               T002J3_A726SerasaOcorrenciasId, T002J3_A727SerasaOcorrenciasData, T002J3_n727SerasaOcorrenciasData, T002J3_A728SerasaOcorrenciasOrigem, T002J3_n728SerasaOcorrenciasOrigem, T002J3_A729SerasaOcorrenciasModalidade, T002J3_n729SerasaOcorrenciasModalidade, T002J3_A730SerasaOcorrenciasTipoMoeda, T002J3_n730SerasaOcorrenciasTipoMoeda, T002J3_A731SerasaOcorrenciasValor,
               T002J3_n731SerasaOcorrenciasValor, T002J3_A662SerasaId, T002J3_n662SerasaId
               }
               , new Object[] {
               T002J4_A662SerasaId
               }
               , new Object[] {
               T002J5_A726SerasaOcorrenciasId, T002J5_A727SerasaOcorrenciasData, T002J5_n727SerasaOcorrenciasData, T002J5_A728SerasaOcorrenciasOrigem, T002J5_n728SerasaOcorrenciasOrigem, T002J5_A729SerasaOcorrenciasModalidade, T002J5_n729SerasaOcorrenciasModalidade, T002J5_A730SerasaOcorrenciasTipoMoeda, T002J5_n730SerasaOcorrenciasTipoMoeda, T002J5_A731SerasaOcorrenciasValor,
               T002J5_n731SerasaOcorrenciasValor, T002J5_A662SerasaId, T002J5_n662SerasaId
               }
               , new Object[] {
               T002J6_A662SerasaId
               }
               , new Object[] {
               T002J7_A726SerasaOcorrenciasId
               }
               , new Object[] {
               T002J8_A726SerasaOcorrenciasId
               }
               , new Object[] {
               T002J9_A726SerasaOcorrenciasId
               }
               , new Object[] {
               }
               , new Object[] {
               T002J11_A726SerasaOcorrenciasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002J14_A726SerasaOcorrenciasId
               }
               , new Object[] {
               T002J15_A662SerasaId
               }
            }
         );
         AV19Pgmname = "SerasaOcorrencias";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound89 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7SerasaOcorrenciasId ;
      private int Z726SerasaOcorrenciasId ;
      private int Z662SerasaId ;
      private int N662SerasaId ;
      private int A662SerasaId ;
      private int AV7SerasaOcorrenciasId ;
      private int trnEnded ;
      private int A726SerasaOcorrenciasId ;
      private int edtSerasaOcorrenciasId_Enabled ;
      private int edtSerasaId_Visible ;
      private int edtSerasaId_Enabled ;
      private int edtSerasaOcorrenciasData_Enabled ;
      private int edtSerasaOcorrenciasOrigem_Enabled ;
      private int edtSerasaOcorrenciasModalidade_Enabled ;
      private int edtSerasaOcorrenciasTipoMoeda_Enabled ;
      private int edtSerasaOcorrenciasValor_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV18ComboSerasaId ;
      private int edtavComboserasaid_Enabled ;
      private int edtavComboserasaid_Visible ;
      private int AV11Insert_SerasaId ;
      private int Combo_serasaid_Datalistupdateminimumcharacters ;
      private int Combo_serasaid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV20GXV1 ;
      private int idxLst ;
      private decimal Z731SerasaOcorrenciasValor ;
      private decimal A731SerasaOcorrenciasValor ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_serasaid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSerasaId_Internalname ;
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
      private string edtSerasaOcorrenciasId_Internalname ;
      private string TempTags ;
      private string edtSerasaOcorrenciasId_Jsonclick ;
      private string divTablesplittedserasaid_Internalname ;
      private string lblTextblockserasaid_Internalname ;
      private string lblTextblockserasaid_Jsonclick ;
      private string Combo_serasaid_Caption ;
      private string Combo_serasaid_Cls ;
      private string Combo_serasaid_Datalistproc ;
      private string Combo_serasaid_Datalistprocparametersprefix ;
      private string Combo_serasaid_Internalname ;
      private string edtSerasaId_Jsonclick ;
      private string edtSerasaOcorrenciasData_Internalname ;
      private string edtSerasaOcorrenciasData_Jsonclick ;
      private string edtSerasaOcorrenciasOrigem_Internalname ;
      private string edtSerasaOcorrenciasOrigem_Jsonclick ;
      private string edtSerasaOcorrenciasModalidade_Internalname ;
      private string edtSerasaOcorrenciasModalidade_Jsonclick ;
      private string edtSerasaOcorrenciasTipoMoeda_Internalname ;
      private string edtSerasaOcorrenciasTipoMoeda_Jsonclick ;
      private string edtSerasaOcorrenciasValor_Internalname ;
      private string edtSerasaOcorrenciasValor_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_serasaid_Internalname ;
      private string edtavComboserasaid_Internalname ;
      private string edtavComboserasaid_Jsonclick ;
      private string AV19Pgmname ;
      private string Combo_serasaid_Objectcall ;
      private string Combo_serasaid_Class ;
      private string Combo_serasaid_Icontype ;
      private string Combo_serasaid_Icon ;
      private string Combo_serasaid_Tooltip ;
      private string Combo_serasaid_Selectedvalue_set ;
      private string Combo_serasaid_Selectedtext_set ;
      private string Combo_serasaid_Selectedtext_get ;
      private string Combo_serasaid_Gamoauthtoken ;
      private string Combo_serasaid_Ddointernalname ;
      private string Combo_serasaid_Titlecontrolalign ;
      private string Combo_serasaid_Dropdownoptionstype ;
      private string Combo_serasaid_Titlecontrolidtoreplace ;
      private string Combo_serasaid_Datalisttype ;
      private string Combo_serasaid_Datalistfixedvalues ;
      private string Combo_serasaid_Remoteservicesparameters ;
      private string Combo_serasaid_Htmltemplate ;
      private string Combo_serasaid_Multiplevaluestype ;
      private string Combo_serasaid_Loadingdata ;
      private string Combo_serasaid_Noresultsfound ;
      private string Combo_serasaid_Emptyitemtext ;
      private string Combo_serasaid_Onlyselectedvalues ;
      private string Combo_serasaid_Selectalltext ;
      private string Combo_serasaid_Multiplevaluesseparator ;
      private string Combo_serasaid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode89 ;
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
      private DateTime Z727SerasaOcorrenciasData ;
      private DateTime A727SerasaOcorrenciasData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n662SerasaId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n731SerasaOcorrenciasValor ;
      private bool n727SerasaOcorrenciasData ;
      private bool n728SerasaOcorrenciasOrigem ;
      private bool n729SerasaOcorrenciasModalidade ;
      private bool n730SerasaOcorrenciasTipoMoeda ;
      private bool Combo_serasaid_Enabled ;
      private bool Combo_serasaid_Visible ;
      private bool Combo_serasaid_Allowmultipleselection ;
      private bool Combo_serasaid_Isgriditem ;
      private bool Combo_serasaid_Hasdescription ;
      private bool Combo_serasaid_Includeonlyselectedoption ;
      private bool Combo_serasaid_Includeselectalloption ;
      private bool Combo_serasaid_Emptyitem ;
      private bool Combo_serasaid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV17Combo_DataJson ;
      private string Z728SerasaOcorrenciasOrigem ;
      private string Z729SerasaOcorrenciasModalidade ;
      private string Z730SerasaOcorrenciasTipoMoeda ;
      private string A728SerasaOcorrenciasOrigem ;
      private string A729SerasaOcorrenciasModalidade ;
      private string A730SerasaOcorrenciasTipoMoeda ;
      private string AV15ComboSelectedValue ;
      private string AV16ComboSelectedText ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_serasaid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13SerasaId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] T002J5_A726SerasaOcorrenciasId ;
      private DateTime[] T002J5_A727SerasaOcorrenciasData ;
      private bool[] T002J5_n727SerasaOcorrenciasData ;
      private string[] T002J5_A728SerasaOcorrenciasOrigem ;
      private bool[] T002J5_n728SerasaOcorrenciasOrigem ;
      private string[] T002J5_A729SerasaOcorrenciasModalidade ;
      private bool[] T002J5_n729SerasaOcorrenciasModalidade ;
      private string[] T002J5_A730SerasaOcorrenciasTipoMoeda ;
      private bool[] T002J5_n730SerasaOcorrenciasTipoMoeda ;
      private decimal[] T002J5_A731SerasaOcorrenciasValor ;
      private bool[] T002J5_n731SerasaOcorrenciasValor ;
      private int[] T002J5_A662SerasaId ;
      private bool[] T002J5_n662SerasaId ;
      private int[] T002J4_A662SerasaId ;
      private bool[] T002J4_n662SerasaId ;
      private int[] T002J6_A662SerasaId ;
      private bool[] T002J6_n662SerasaId ;
      private int[] T002J7_A726SerasaOcorrenciasId ;
      private int[] T002J3_A726SerasaOcorrenciasId ;
      private DateTime[] T002J3_A727SerasaOcorrenciasData ;
      private bool[] T002J3_n727SerasaOcorrenciasData ;
      private string[] T002J3_A728SerasaOcorrenciasOrigem ;
      private bool[] T002J3_n728SerasaOcorrenciasOrigem ;
      private string[] T002J3_A729SerasaOcorrenciasModalidade ;
      private bool[] T002J3_n729SerasaOcorrenciasModalidade ;
      private string[] T002J3_A730SerasaOcorrenciasTipoMoeda ;
      private bool[] T002J3_n730SerasaOcorrenciasTipoMoeda ;
      private decimal[] T002J3_A731SerasaOcorrenciasValor ;
      private bool[] T002J3_n731SerasaOcorrenciasValor ;
      private int[] T002J3_A662SerasaId ;
      private bool[] T002J3_n662SerasaId ;
      private int[] T002J8_A726SerasaOcorrenciasId ;
      private int[] T002J9_A726SerasaOcorrenciasId ;
      private int[] T002J2_A726SerasaOcorrenciasId ;
      private DateTime[] T002J2_A727SerasaOcorrenciasData ;
      private bool[] T002J2_n727SerasaOcorrenciasData ;
      private string[] T002J2_A728SerasaOcorrenciasOrigem ;
      private bool[] T002J2_n728SerasaOcorrenciasOrigem ;
      private string[] T002J2_A729SerasaOcorrenciasModalidade ;
      private bool[] T002J2_n729SerasaOcorrenciasModalidade ;
      private string[] T002J2_A730SerasaOcorrenciasTipoMoeda ;
      private bool[] T002J2_n730SerasaOcorrenciasTipoMoeda ;
      private decimal[] T002J2_A731SerasaOcorrenciasValor ;
      private bool[] T002J2_n731SerasaOcorrenciasValor ;
      private int[] T002J2_A662SerasaId ;
      private bool[] T002J2_n662SerasaId ;
      private int[] T002J11_A726SerasaOcorrenciasId ;
      private int[] T002J14_A726SerasaOcorrenciasId ;
      private int[] T002J15_A662SerasaId ;
      private bool[] T002J15_n662SerasaId ;
   }

   public class serasaocorrencias__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT002J2;
          prmT002J2 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmT002J3;
          prmT002J3 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmT002J4;
          prmT002J4 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002J5;
          prmT002J5 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmT002J6;
          prmT002J6 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002J7;
          prmT002J7 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmT002J8;
          prmT002J8 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmT002J9;
          prmT002J9 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmT002J10;
          prmT002J10 = new Object[] {
          new ParDef("SerasaOcorrenciasData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasOrigem",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasModalidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasTipoMoeda",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002J11;
          prmT002J11 = new Object[] {
          };
          Object[] prmT002J12;
          prmT002J12 = new Object[] {
          new ParDef("SerasaOcorrenciasData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasOrigem",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasModalidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasTipoMoeda",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmT002J13;
          prmT002J13 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmT002J14;
          prmT002J14 = new Object[] {
          };
          Object[] prmT002J15;
          prmT002J15 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T002J2", "SELECT SerasaOcorrenciasId, SerasaOcorrenciasData, SerasaOcorrenciasOrigem, SerasaOcorrenciasModalidade, SerasaOcorrenciasTipoMoeda, SerasaOcorrenciasValor, SerasaId FROM SerasaOcorrencias WHERE SerasaOcorrenciasId = :SerasaOcorrenciasId  FOR UPDATE OF SerasaOcorrencias NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002J2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002J3", "SELECT SerasaOcorrenciasId, SerasaOcorrenciasData, SerasaOcorrenciasOrigem, SerasaOcorrenciasModalidade, SerasaOcorrenciasTipoMoeda, SerasaOcorrenciasValor, SerasaId FROM SerasaOcorrencias WHERE SerasaOcorrenciasId = :SerasaOcorrenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002J4", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002J5", "SELECT TM1.SerasaOcorrenciasId, TM1.SerasaOcorrenciasData, TM1.SerasaOcorrenciasOrigem, TM1.SerasaOcorrenciasModalidade, TM1.SerasaOcorrenciasTipoMoeda, TM1.SerasaOcorrenciasValor, TM1.SerasaId FROM SerasaOcorrencias TM1 WHERE TM1.SerasaOcorrenciasId = :SerasaOcorrenciasId ORDER BY TM1.SerasaOcorrenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002J6", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002J7", "SELECT SerasaOcorrenciasId FROM SerasaOcorrencias WHERE SerasaOcorrenciasId = :SerasaOcorrenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002J8", "SELECT SerasaOcorrenciasId FROM SerasaOcorrencias WHERE ( SerasaOcorrenciasId > :SerasaOcorrenciasId) ORDER BY SerasaOcorrenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002J9", "SELECT SerasaOcorrenciasId FROM SerasaOcorrencias WHERE ( SerasaOcorrenciasId < :SerasaOcorrenciasId) ORDER BY SerasaOcorrenciasId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002J10", "SAVEPOINT gxupdate;INSERT INTO SerasaOcorrencias(SerasaOcorrenciasData, SerasaOcorrenciasOrigem, SerasaOcorrenciasModalidade, SerasaOcorrenciasTipoMoeda, SerasaOcorrenciasValor, SerasaId) VALUES(:SerasaOcorrenciasData, :SerasaOcorrenciasOrigem, :SerasaOcorrenciasModalidade, :SerasaOcorrenciasTipoMoeda, :SerasaOcorrenciasValor, :SerasaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002J10)
             ,new CursorDef("T002J11", "SELECT currval('SerasaOcorrenciasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002J12", "SAVEPOINT gxupdate;UPDATE SerasaOcorrencias SET SerasaOcorrenciasData=:SerasaOcorrenciasData, SerasaOcorrenciasOrigem=:SerasaOcorrenciasOrigem, SerasaOcorrenciasModalidade=:SerasaOcorrenciasModalidade, SerasaOcorrenciasTipoMoeda=:SerasaOcorrenciasTipoMoeda, SerasaOcorrenciasValor=:SerasaOcorrenciasValor, SerasaId=:SerasaId  WHERE SerasaOcorrenciasId = :SerasaOcorrenciasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002J12)
             ,new CursorDef("T002J13", "SAVEPOINT gxupdate;DELETE FROM SerasaOcorrencias  WHERE SerasaOcorrenciasId = :SerasaOcorrenciasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002J13)
             ,new CursorDef("T002J14", "SELECT SerasaOcorrenciasId FROM SerasaOcorrencias ORDER BY SerasaOcorrenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002J15", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J15,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
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
       }
    }

 }

}
