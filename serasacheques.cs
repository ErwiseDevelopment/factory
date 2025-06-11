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
   public class serasacheques : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "serasacheques")), "serasacheques") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "serasacheques")))) ;
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
                  AV7SerasaChequesId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaChequesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7SerasaChequesId", StringUtil.LTrimStr( (decimal)(AV7SerasaChequesId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSERASACHEQUESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SerasaChequesId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Serasa Cheques", 0) ;
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

      public serasacheques( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasacheques( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_SerasaChequesId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SerasaChequesId = aP1_SerasaChequesId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaChequesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaChequesId_Internalname, "Cheques Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaChequesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A693SerasaChequesId), 9, 0, ",", "")), StringUtil.LTrim( ((edtSerasaChequesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A693SerasaChequesId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A693SerasaChequesId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaChequesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaChequesId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SerasaCheques.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblockserasaid_Internalname, "Serasa", "", "", lblTextblockserasaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_SerasaCheques.htm");
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
         GxWebStd.gx_single_line_edit( context, edtSerasaId_Internalname, ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ",", ""))), ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A662SerasaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaId_Jsonclick, 0, "Attribute", "", "", "", "", edtSerasaId_Visible, edtSerasaId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SerasaCheques.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaChequesTotalCons_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaChequesTotalCons_Internalname, "consultas cheques", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaChequesTotalCons_Internalname, ((Convert.ToDecimal(0)==A694SerasaChequesTotalCons)&&IsIns( )||n694SerasaChequesTotalCons ? "" : StringUtil.LTrim( StringUtil.NToC( A694SerasaChequesTotalCons, 15, 2, ",", ""))), ((Convert.ToDecimal(0)==A694SerasaChequesTotalCons)&&IsIns( )||n694SerasaChequesTotalCons ? "" : StringUtil.LTrim( ((edtSerasaChequesTotalCons_Enabled!=0) ? context.localUtil.Format( A694SerasaChequesTotalCons, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A694SerasaChequesTotalCons, "ZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaChequesTotalCons_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaChequesTotalCons_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SerasaCheques.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaChequesQtdSemFundo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaChequesQtdSemFundo_Internalname, "sem fundos", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaChequesQtdSemFundo_Internalname, ((Convert.ToDecimal(0)==A695SerasaChequesQtdSemFundo)&&IsIns( )||n695SerasaChequesQtdSemFundo ? "" : StringUtil.LTrim( StringUtil.NToC( A695SerasaChequesQtdSemFundo, 15, 2, ",", ""))), ((Convert.ToDecimal(0)==A695SerasaChequesQtdSemFundo)&&IsIns( )||n695SerasaChequesQtdSemFundo ? "" : StringUtil.LTrim( ((edtSerasaChequesQtdSemFundo_Enabled!=0) ? context.localUtil.Format( A695SerasaChequesQtdSemFundo, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A695SerasaChequesQtdSemFundo, "ZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaChequesQtdSemFundo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaChequesQtdSemFundo_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SerasaCheques.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaChequesUltOcorSus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaChequesUltOcorSus_Internalname, "cheque sustado", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSerasaChequesUltOcorSus_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSerasaChequesUltOcorSus_Internalname, context.localUtil.Format(A696SerasaChequesUltOcorSus, "99/99/99"), context.localUtil.Format( A696SerasaChequesUltOcorSus, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaChequesUltOcorSus_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaChequesUltOcorSus_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SerasaCheques.htm");
         GxWebStd.gx_bitmap( context, edtSerasaChequesUltOcorSus_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSerasaChequesUltOcorSus_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_SerasaCheques.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaChequesValorSemFundo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaChequesValorSemFundo_Internalname, "sem fundos", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaChequesValorSemFundo_Internalname, ((Convert.ToDecimal(0)==A697SerasaChequesValorSemFundo)&&IsIns( )||n697SerasaChequesValorSemFundo ? "" : StringUtil.LTrim( StringUtil.NToC( A697SerasaChequesValorSemFundo, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A697SerasaChequesValorSemFundo)&&IsIns( )||n697SerasaChequesValorSemFundo ? "" : StringUtil.LTrim( ((edtSerasaChequesValorSemFundo_Enabled!=0) ? context.localUtil.Format( A697SerasaChequesValorSemFundo, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A697SerasaChequesValorSemFundo, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaChequesValorSemFundo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaChequesValorSemFundo_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_SerasaCheques.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaChequesTotalSust_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaChequesTotalSust_Internalname, "cheque sustado", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaChequesTotalSust_Internalname, ((Convert.ToDecimal(0)==A698SerasaChequesTotalSust)&&IsIns( )||n698SerasaChequesTotalSust ? "" : StringUtil.LTrim( StringUtil.NToC( A698SerasaChequesTotalSust, 15, 2, ",", ""))), ((Convert.ToDecimal(0)==A698SerasaChequesTotalSust)&&IsIns( )||n698SerasaChequesTotalSust ? "" : StringUtil.LTrim( ((edtSerasaChequesTotalSust_Enabled!=0) ? context.localUtil.Format( A698SerasaChequesTotalSust, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A698SerasaChequesTotalSust, "ZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaChequesTotalSust_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaChequesTotalSust_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SerasaCheques.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaCheques.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaCheques.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaCheques.htm");
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
         GxWebStd.gx_single_line_edit( context, edtavComboserasaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ComboSerasaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboserasaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ComboSerasaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV18ComboSerasaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboserasaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboserasaid_Visible, edtavComboserasaid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SerasaCheques.htm");
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
         E112F2 ();
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
               Z693SerasaChequesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z693SerasaChequesId"), ",", "."), 18, MidpointRounding.ToEven));
               Z694SerasaChequesTotalCons = context.localUtil.CToN( cgiGet( "Z694SerasaChequesTotalCons"), ",", ".");
               n694SerasaChequesTotalCons = ((Convert.ToDecimal(0)==A694SerasaChequesTotalCons) ? true : false);
               Z695SerasaChequesQtdSemFundo = context.localUtil.CToN( cgiGet( "Z695SerasaChequesQtdSemFundo"), ",", ".");
               n695SerasaChequesQtdSemFundo = ((Convert.ToDecimal(0)==A695SerasaChequesQtdSemFundo) ? true : false);
               Z696SerasaChequesUltOcorSus = context.localUtil.CToD( cgiGet( "Z696SerasaChequesUltOcorSus"), 0);
               n696SerasaChequesUltOcorSus = ((DateTime.MinValue==A696SerasaChequesUltOcorSus) ? true : false);
               Z697SerasaChequesValorSemFundo = context.localUtil.CToN( cgiGet( "Z697SerasaChequesValorSemFundo"), ",", ".");
               n697SerasaChequesValorSemFundo = ((Convert.ToDecimal(0)==A697SerasaChequesValorSemFundo) ? true : false);
               Z698SerasaChequesTotalSust = context.localUtil.CToN( cgiGet( "Z698SerasaChequesTotalSust"), ",", ".");
               n698SerasaChequesTotalSust = ((Convert.ToDecimal(0)==A698SerasaChequesTotalSust) ? true : false);
               Z662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z662SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
               n662SerasaId = ((0==A662SerasaId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N662SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
               n662SerasaId = ((0==A662SerasaId) ? true : false);
               AV7SerasaChequesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vSERASACHEQUESID"), ",", "."), 18, MidpointRounding.ToEven));
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
               A693SerasaChequesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaChequesId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
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
               n694SerasaChequesTotalCons = ((StringUtil.StrCmp(cgiGet( edtSerasaChequesTotalCons_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaChequesTotalCons_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaChequesTotalCons_Internalname), ",", ".") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASACHEQUESTOTALCONS");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaChequesTotalCons_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A694SerasaChequesTotalCons = 0;
                  n694SerasaChequesTotalCons = false;
                  AssignAttri("", false, "A694SerasaChequesTotalCons", (n694SerasaChequesTotalCons ? "" : StringUtil.LTrim( StringUtil.NToC( A694SerasaChequesTotalCons, 15, 2, ".", ""))));
               }
               else
               {
                  A694SerasaChequesTotalCons = context.localUtil.CToN( cgiGet( edtSerasaChequesTotalCons_Internalname), ",", ".");
                  AssignAttri("", false, "A694SerasaChequesTotalCons", (n694SerasaChequesTotalCons ? "" : StringUtil.LTrim( StringUtil.NToC( A694SerasaChequesTotalCons, 15, 2, ".", ""))));
               }
               n695SerasaChequesQtdSemFundo = ((StringUtil.StrCmp(cgiGet( edtSerasaChequesQtdSemFundo_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaChequesQtdSemFundo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaChequesQtdSemFundo_Internalname), ",", ".") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASACHEQUESQTDSEMFUNDO");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaChequesQtdSemFundo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A695SerasaChequesQtdSemFundo = 0;
                  n695SerasaChequesQtdSemFundo = false;
                  AssignAttri("", false, "A695SerasaChequesQtdSemFundo", (n695SerasaChequesQtdSemFundo ? "" : StringUtil.LTrim( StringUtil.NToC( A695SerasaChequesQtdSemFundo, 15, 2, ".", ""))));
               }
               else
               {
                  A695SerasaChequesQtdSemFundo = context.localUtil.CToN( cgiGet( edtSerasaChequesQtdSemFundo_Internalname), ",", ".");
                  AssignAttri("", false, "A695SerasaChequesQtdSemFundo", (n695SerasaChequesQtdSemFundo ? "" : StringUtil.LTrim( StringUtil.NToC( A695SerasaChequesQtdSemFundo, 15, 2, ".", ""))));
               }
               if ( context.localUtil.VCDate( cgiGet( edtSerasaChequesUltOcorSus_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data última ocorrência cheque sustado"}), 1, "SERASACHEQUESULTOCORSUS");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaChequesUltOcorSus_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A696SerasaChequesUltOcorSus = DateTime.MinValue;
                  n696SerasaChequesUltOcorSus = false;
                  AssignAttri("", false, "A696SerasaChequesUltOcorSus", context.localUtil.Format(A696SerasaChequesUltOcorSus, "99/99/99"));
               }
               else
               {
                  A696SerasaChequesUltOcorSus = context.localUtil.CToD( cgiGet( edtSerasaChequesUltOcorSus_Internalname), 2);
                  n696SerasaChequesUltOcorSus = false;
                  AssignAttri("", false, "A696SerasaChequesUltOcorSus", context.localUtil.Format(A696SerasaChequesUltOcorSus, "99/99/99"));
               }
               n696SerasaChequesUltOcorSus = ((DateTime.MinValue==A696SerasaChequesUltOcorSus) ? true : false);
               n697SerasaChequesValorSemFundo = ((StringUtil.StrCmp(cgiGet( edtSerasaChequesValorSemFundo_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaChequesValorSemFundo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaChequesValorSemFundo_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASACHEQUESVALORSEMFUNDO");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaChequesValorSemFundo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A697SerasaChequesValorSemFundo = 0;
                  n697SerasaChequesValorSemFundo = false;
                  AssignAttri("", false, "A697SerasaChequesValorSemFundo", (n697SerasaChequesValorSemFundo ? "" : StringUtil.LTrim( StringUtil.NToC( A697SerasaChequesValorSemFundo, 18, 2, ".", ""))));
               }
               else
               {
                  A697SerasaChequesValorSemFundo = context.localUtil.CToN( cgiGet( edtSerasaChequesValorSemFundo_Internalname), ",", ".");
                  AssignAttri("", false, "A697SerasaChequesValorSemFundo", (n697SerasaChequesValorSemFundo ? "" : StringUtil.LTrim( StringUtil.NToC( A697SerasaChequesValorSemFundo, 18, 2, ".", ""))));
               }
               n698SerasaChequesTotalSust = ((StringUtil.StrCmp(cgiGet( edtSerasaChequesTotalSust_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaChequesTotalSust_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaChequesTotalSust_Internalname), ",", ".") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASACHEQUESTOTALSUST");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaChequesTotalSust_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A698SerasaChequesTotalSust = 0;
                  n698SerasaChequesTotalSust = false;
                  AssignAttri("", false, "A698SerasaChequesTotalSust", (n698SerasaChequesTotalSust ? "" : StringUtil.LTrim( StringUtil.NToC( A698SerasaChequesTotalSust, 15, 2, ".", ""))));
               }
               else
               {
                  A698SerasaChequesTotalSust = context.localUtil.CToN( cgiGet( edtSerasaChequesTotalSust_Internalname), ",", ".");
                  AssignAttri("", false, "A698SerasaChequesTotalSust", (n698SerasaChequesTotalSust ? "" : StringUtil.LTrim( StringUtil.NToC( A698SerasaChequesTotalSust, 15, 2, ".", ""))));
               }
               AV18ComboSerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboserasaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18ComboSerasaId", StringUtil.LTrimStr( (decimal)(AV18ComboSerasaId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SerasaCheques");
               A693SerasaChequesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaChequesId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
               forbiddenHiddens.Add("SerasaChequesId", context.localUtil.Format( (decimal)(A693SerasaChequesId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_SerasaId", context.localUtil.Format( (decimal)(AV11Insert_SerasaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A693SerasaChequesId != Z693SerasaChequesId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("serasacheques:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A693SerasaChequesId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaChequesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
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
                     sMode85 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode85;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound85 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2F0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SERASACHEQUESID");
                        AnyError = 1;
                        GX_FocusControl = edtSerasaChequesId_Internalname;
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
                           E112F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122F2 ();
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
            E122F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2F85( ) ;
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
            DisableAttributes2F85( ) ;
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

      protected void CONFIRM_2F0( )
      {
         BeforeValidate2F85( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2F85( ) ;
            }
            else
            {
               CheckExtendedTable2F85( ) ;
               CloseExtendedTableCursors2F85( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2F0( )
      {
      }

      protected void E112F2( )
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
                     new serasachequesloaddvcombo(context ).execute(  "SerasaId",  "GET",  false,  AV7SerasaChequesId,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
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

      protected void E122F2( )
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
         new serasachequesloaddvcombo(context ).execute(  "SerasaId",  Gx_mode,  false,  AV7SerasaChequesId,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
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

      protected void ZM2F85( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z694SerasaChequesTotalCons = T002F3_A694SerasaChequesTotalCons[0];
               Z695SerasaChequesQtdSemFundo = T002F3_A695SerasaChequesQtdSemFundo[0];
               Z696SerasaChequesUltOcorSus = T002F3_A696SerasaChequesUltOcorSus[0];
               Z697SerasaChequesValorSemFundo = T002F3_A697SerasaChequesValorSemFundo[0];
               Z698SerasaChequesTotalSust = T002F3_A698SerasaChequesTotalSust[0];
               Z662SerasaId = T002F3_A662SerasaId[0];
            }
            else
            {
               Z694SerasaChequesTotalCons = A694SerasaChequesTotalCons;
               Z695SerasaChequesQtdSemFundo = A695SerasaChequesQtdSemFundo;
               Z696SerasaChequesUltOcorSus = A696SerasaChequesUltOcorSus;
               Z697SerasaChequesValorSemFundo = A697SerasaChequesValorSemFundo;
               Z698SerasaChequesTotalSust = A698SerasaChequesTotalSust;
               Z662SerasaId = A662SerasaId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z693SerasaChequesId = A693SerasaChequesId;
            Z694SerasaChequesTotalCons = A694SerasaChequesTotalCons;
            Z695SerasaChequesQtdSemFundo = A695SerasaChequesQtdSemFundo;
            Z696SerasaChequesUltOcorSus = A696SerasaChequesUltOcorSus;
            Z697SerasaChequesValorSemFundo = A697SerasaChequesValorSemFundo;
            Z698SerasaChequesTotalSust = A698SerasaChequesTotalSust;
            Z662SerasaId = A662SerasaId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSerasaChequesId_Enabled = 0;
         AssignProp("", false, edtSerasaChequesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaChequesId_Enabled), 5, 0), true);
         AV19Pgmname = "SerasaCheques";
         AssignAttri("", false, "AV19Pgmname", AV19Pgmname);
         edtSerasaChequesId_Enabled = 0;
         AssignProp("", false, edtSerasaChequesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaChequesId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SerasaChequesId) )
         {
            A693SerasaChequesId = AV7SerasaChequesId;
            AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
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

      protected void Load2F85( )
      {
         /* Using cursor T002F5 */
         pr_default.execute(3, new Object[] {A693SerasaChequesId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound85 = 1;
            A694SerasaChequesTotalCons = T002F5_A694SerasaChequesTotalCons[0];
            n694SerasaChequesTotalCons = T002F5_n694SerasaChequesTotalCons[0];
            AssignAttri("", false, "A694SerasaChequesTotalCons", ((Convert.ToDecimal(0)==A694SerasaChequesTotalCons)&&IsIns( )||n694SerasaChequesTotalCons ? "" : StringUtil.LTrim( StringUtil.NToC( A694SerasaChequesTotalCons, 15, 2, ".", ""))));
            A695SerasaChequesQtdSemFundo = T002F5_A695SerasaChequesQtdSemFundo[0];
            n695SerasaChequesQtdSemFundo = T002F5_n695SerasaChequesQtdSemFundo[0];
            AssignAttri("", false, "A695SerasaChequesQtdSemFundo", ((Convert.ToDecimal(0)==A695SerasaChequesQtdSemFundo)&&IsIns( )||n695SerasaChequesQtdSemFundo ? "" : StringUtil.LTrim( StringUtil.NToC( A695SerasaChequesQtdSemFundo, 15, 2, ".", ""))));
            A696SerasaChequesUltOcorSus = T002F5_A696SerasaChequesUltOcorSus[0];
            n696SerasaChequesUltOcorSus = T002F5_n696SerasaChequesUltOcorSus[0];
            AssignAttri("", false, "A696SerasaChequesUltOcorSus", context.localUtil.Format(A696SerasaChequesUltOcorSus, "99/99/99"));
            A697SerasaChequesValorSemFundo = T002F5_A697SerasaChequesValorSemFundo[0];
            n697SerasaChequesValorSemFundo = T002F5_n697SerasaChequesValorSemFundo[0];
            AssignAttri("", false, "A697SerasaChequesValorSemFundo", ((Convert.ToDecimal(0)==A697SerasaChequesValorSemFundo)&&IsIns( )||n697SerasaChequesValorSemFundo ? "" : StringUtil.LTrim( StringUtil.NToC( A697SerasaChequesValorSemFundo, 18, 2, ".", ""))));
            A698SerasaChequesTotalSust = T002F5_A698SerasaChequesTotalSust[0];
            n698SerasaChequesTotalSust = T002F5_n698SerasaChequesTotalSust[0];
            AssignAttri("", false, "A698SerasaChequesTotalSust", ((Convert.ToDecimal(0)==A698SerasaChequesTotalSust)&&IsIns( )||n698SerasaChequesTotalSust ? "" : StringUtil.LTrim( StringUtil.NToC( A698SerasaChequesTotalSust, 15, 2, ".", ""))));
            A662SerasaId = T002F5_A662SerasaId[0];
            n662SerasaId = T002F5_n662SerasaId[0];
            AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            ZM2F85( -9) ;
         }
         pr_default.close(3);
         OnLoadActions2F85( ) ;
      }

      protected void OnLoadActions2F85( )
      {
      }

      protected void CheckExtendedTable2F85( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002F4 */
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
         if ( ( A697SerasaChequesValorSemFundo < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "SERASACHEQUESVALORSEMFUNDO");
            AnyError = 1;
            GX_FocusControl = edtSerasaChequesValorSemFundo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2F85( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( int A662SerasaId )
      {
         /* Using cursor T002F6 */
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

      protected void GetKey2F85( )
      {
         /* Using cursor T002F7 */
         pr_default.execute(5, new Object[] {A693SerasaChequesId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound85 = 1;
         }
         else
         {
            RcdFound85 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002F3 */
         pr_default.execute(1, new Object[] {A693SerasaChequesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2F85( 9) ;
            RcdFound85 = 1;
            A693SerasaChequesId = T002F3_A693SerasaChequesId[0];
            AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
            A694SerasaChequesTotalCons = T002F3_A694SerasaChequesTotalCons[0];
            n694SerasaChequesTotalCons = T002F3_n694SerasaChequesTotalCons[0];
            AssignAttri("", false, "A694SerasaChequesTotalCons", ((Convert.ToDecimal(0)==A694SerasaChequesTotalCons)&&IsIns( )||n694SerasaChequesTotalCons ? "" : StringUtil.LTrim( StringUtil.NToC( A694SerasaChequesTotalCons, 15, 2, ".", ""))));
            A695SerasaChequesQtdSemFundo = T002F3_A695SerasaChequesQtdSemFundo[0];
            n695SerasaChequesQtdSemFundo = T002F3_n695SerasaChequesQtdSemFundo[0];
            AssignAttri("", false, "A695SerasaChequesQtdSemFundo", ((Convert.ToDecimal(0)==A695SerasaChequesQtdSemFundo)&&IsIns( )||n695SerasaChequesQtdSemFundo ? "" : StringUtil.LTrim( StringUtil.NToC( A695SerasaChequesQtdSemFundo, 15, 2, ".", ""))));
            A696SerasaChequesUltOcorSus = T002F3_A696SerasaChequesUltOcorSus[0];
            n696SerasaChequesUltOcorSus = T002F3_n696SerasaChequesUltOcorSus[0];
            AssignAttri("", false, "A696SerasaChequesUltOcorSus", context.localUtil.Format(A696SerasaChequesUltOcorSus, "99/99/99"));
            A697SerasaChequesValorSemFundo = T002F3_A697SerasaChequesValorSemFundo[0];
            n697SerasaChequesValorSemFundo = T002F3_n697SerasaChequesValorSemFundo[0];
            AssignAttri("", false, "A697SerasaChequesValorSemFundo", ((Convert.ToDecimal(0)==A697SerasaChequesValorSemFundo)&&IsIns( )||n697SerasaChequesValorSemFundo ? "" : StringUtil.LTrim( StringUtil.NToC( A697SerasaChequesValorSemFundo, 18, 2, ".", ""))));
            A698SerasaChequesTotalSust = T002F3_A698SerasaChequesTotalSust[0];
            n698SerasaChequesTotalSust = T002F3_n698SerasaChequesTotalSust[0];
            AssignAttri("", false, "A698SerasaChequesTotalSust", ((Convert.ToDecimal(0)==A698SerasaChequesTotalSust)&&IsIns( )||n698SerasaChequesTotalSust ? "" : StringUtil.LTrim( StringUtil.NToC( A698SerasaChequesTotalSust, 15, 2, ".", ""))));
            A662SerasaId = T002F3_A662SerasaId[0];
            n662SerasaId = T002F3_n662SerasaId[0];
            AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            Z693SerasaChequesId = A693SerasaChequesId;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2F85( ) ;
            if ( AnyError == 1 )
            {
               RcdFound85 = 0;
               InitializeNonKey2F85( ) ;
            }
            Gx_mode = sMode85;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound85 = 0;
            InitializeNonKey2F85( ) ;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode85;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2F85( ) ;
         if ( RcdFound85 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound85 = 0;
         /* Using cursor T002F8 */
         pr_default.execute(6, new Object[] {A693SerasaChequesId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T002F8_A693SerasaChequesId[0] < A693SerasaChequesId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T002F8_A693SerasaChequesId[0] > A693SerasaChequesId ) ) )
            {
               A693SerasaChequesId = T002F8_A693SerasaChequesId[0];
               AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
               RcdFound85 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound85 = 0;
         /* Using cursor T002F9 */
         pr_default.execute(7, new Object[] {A693SerasaChequesId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T002F9_A693SerasaChequesId[0] > A693SerasaChequesId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T002F9_A693SerasaChequesId[0] < A693SerasaChequesId ) ) )
            {
               A693SerasaChequesId = T002F9_A693SerasaChequesId[0];
               AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
               RcdFound85 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2F85( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSerasaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2F85( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound85 == 1 )
            {
               if ( A693SerasaChequesId != Z693SerasaChequesId )
               {
                  A693SerasaChequesId = Z693SerasaChequesId;
                  AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SERASACHEQUESID");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaChequesId_Internalname;
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
                  Update2F85( ) ;
                  GX_FocusControl = edtSerasaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A693SerasaChequesId != Z693SerasaChequesId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSerasaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2F85( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SERASACHEQUESID");
                     AnyError = 1;
                     GX_FocusControl = edtSerasaChequesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSerasaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2F85( ) ;
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
         if ( A693SerasaChequesId != Z693SerasaChequesId )
         {
            A693SerasaChequesId = Z693SerasaChequesId;
            AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SERASACHEQUESID");
            AnyError = 1;
            GX_FocusControl = edtSerasaChequesId_Internalname;
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

      protected void CheckOptimisticConcurrency2F85( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002F2 */
            pr_default.execute(0, new Object[] {A693SerasaChequesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaCheques"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z694SerasaChequesTotalCons != T002F2_A694SerasaChequesTotalCons[0] ) || ( Z695SerasaChequesQtdSemFundo != T002F2_A695SerasaChequesQtdSemFundo[0] ) || ( DateTimeUtil.ResetTime ( Z696SerasaChequesUltOcorSus ) != DateTimeUtil.ResetTime ( T002F2_A696SerasaChequesUltOcorSus[0] ) ) || ( Z697SerasaChequesValorSemFundo != T002F2_A697SerasaChequesValorSemFundo[0] ) || ( Z698SerasaChequesTotalSust != T002F2_A698SerasaChequesTotalSust[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z662SerasaId != T002F2_A662SerasaId[0] ) )
            {
               if ( Z694SerasaChequesTotalCons != T002F2_A694SerasaChequesTotalCons[0] )
               {
                  GXUtil.WriteLog("serasacheques:[seudo value changed for attri]"+"SerasaChequesTotalCons");
                  GXUtil.WriteLogRaw("Old: ",Z694SerasaChequesTotalCons);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A694SerasaChequesTotalCons[0]);
               }
               if ( Z695SerasaChequesQtdSemFundo != T002F2_A695SerasaChequesQtdSemFundo[0] )
               {
                  GXUtil.WriteLog("serasacheques:[seudo value changed for attri]"+"SerasaChequesQtdSemFundo");
                  GXUtil.WriteLogRaw("Old: ",Z695SerasaChequesQtdSemFundo);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A695SerasaChequesQtdSemFundo[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z696SerasaChequesUltOcorSus ) != DateTimeUtil.ResetTime ( T002F2_A696SerasaChequesUltOcorSus[0] ) )
               {
                  GXUtil.WriteLog("serasacheques:[seudo value changed for attri]"+"SerasaChequesUltOcorSus");
                  GXUtil.WriteLogRaw("Old: ",Z696SerasaChequesUltOcorSus);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A696SerasaChequesUltOcorSus[0]);
               }
               if ( Z697SerasaChequesValorSemFundo != T002F2_A697SerasaChequesValorSemFundo[0] )
               {
                  GXUtil.WriteLog("serasacheques:[seudo value changed for attri]"+"SerasaChequesValorSemFundo");
                  GXUtil.WriteLogRaw("Old: ",Z697SerasaChequesValorSemFundo);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A697SerasaChequesValorSemFundo[0]);
               }
               if ( Z698SerasaChequesTotalSust != T002F2_A698SerasaChequesTotalSust[0] )
               {
                  GXUtil.WriteLog("serasacheques:[seudo value changed for attri]"+"SerasaChequesTotalSust");
                  GXUtil.WriteLogRaw("Old: ",Z698SerasaChequesTotalSust);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A698SerasaChequesTotalSust[0]);
               }
               if ( Z662SerasaId != T002F2_A662SerasaId[0] )
               {
                  GXUtil.WriteLog("serasacheques:[seudo value changed for attri]"+"SerasaId");
                  GXUtil.WriteLogRaw("Old: ",Z662SerasaId);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A662SerasaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SerasaCheques"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2F85( )
      {
         BeforeValidate2F85( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2F85( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2F85( 0) ;
            CheckOptimisticConcurrency2F85( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2F85( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2F85( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002F10 */
                     pr_default.execute(8, new Object[] {n694SerasaChequesTotalCons, A694SerasaChequesTotalCons, n695SerasaChequesQtdSemFundo, A695SerasaChequesQtdSemFundo, n696SerasaChequesUltOcorSus, A696SerasaChequesUltOcorSus, n697SerasaChequesValorSemFundo, A697SerasaChequesValorSemFundo, n698SerasaChequesTotalSust, A698SerasaChequesTotalSust, n662SerasaId, A662SerasaId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002F11 */
                     pr_default.execute(9);
                     A693SerasaChequesId = T002F11_A693SerasaChequesId[0];
                     AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaCheques");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2F0( ) ;
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
               Load2F85( ) ;
            }
            EndLevel2F85( ) ;
         }
         CloseExtendedTableCursors2F85( ) ;
      }

      protected void Update2F85( )
      {
         BeforeValidate2F85( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2F85( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2F85( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2F85( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2F85( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002F12 */
                     pr_default.execute(10, new Object[] {n694SerasaChequesTotalCons, A694SerasaChequesTotalCons, n695SerasaChequesQtdSemFundo, A695SerasaChequesQtdSemFundo, n696SerasaChequesUltOcorSus, A696SerasaChequesUltOcorSus, n697SerasaChequesValorSemFundo, A697SerasaChequesValorSemFundo, n698SerasaChequesTotalSust, A698SerasaChequesTotalSust, n662SerasaId, A662SerasaId, A693SerasaChequesId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaCheques");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaCheques"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2F85( ) ;
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
            EndLevel2F85( ) ;
         }
         CloseExtendedTableCursors2F85( ) ;
      }

      protected void DeferredUpdate2F85( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2F85( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2F85( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2F85( ) ;
            AfterConfirm2F85( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2F85( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002F13 */
                  pr_default.execute(11, new Object[] {A693SerasaChequesId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("SerasaCheques");
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
         sMode85 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2F85( ) ;
         Gx_mode = sMode85;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2F85( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2F85( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2F85( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2F0( ) ;
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

      public void ScanStart2F85( )
      {
         /* Scan By routine */
         /* Using cursor T002F14 */
         pr_default.execute(12);
         RcdFound85 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound85 = 1;
            A693SerasaChequesId = T002F14_A693SerasaChequesId[0];
            AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2F85( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound85 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound85 = 1;
            A693SerasaChequesId = T002F14_A693SerasaChequesId[0];
            AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
         }
      }

      protected void ScanEnd2F85( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm2F85( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2F85( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2F85( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2F85( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2F85( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2F85( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2F85( )
      {
         edtSerasaChequesId_Enabled = 0;
         AssignProp("", false, edtSerasaChequesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaChequesId_Enabled), 5, 0), true);
         edtSerasaId_Enabled = 0;
         AssignProp("", false, edtSerasaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaId_Enabled), 5, 0), true);
         edtSerasaChequesTotalCons_Enabled = 0;
         AssignProp("", false, edtSerasaChequesTotalCons_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaChequesTotalCons_Enabled), 5, 0), true);
         edtSerasaChequesQtdSemFundo_Enabled = 0;
         AssignProp("", false, edtSerasaChequesQtdSemFundo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaChequesQtdSemFundo_Enabled), 5, 0), true);
         edtSerasaChequesUltOcorSus_Enabled = 0;
         AssignProp("", false, edtSerasaChequesUltOcorSus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaChequesUltOcorSus_Enabled), 5, 0), true);
         edtSerasaChequesValorSemFundo_Enabled = 0;
         AssignProp("", false, edtSerasaChequesValorSemFundo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaChequesValorSemFundo_Enabled), 5, 0), true);
         edtSerasaChequesTotalSust_Enabled = 0;
         AssignProp("", false, edtSerasaChequesTotalSust_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaChequesTotalSust_Enabled), 5, 0), true);
         edtavComboserasaid_Enabled = 0;
         AssignProp("", false, edtavComboserasaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboserasaid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2F85( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2F0( )
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
         GXEncryptionTmp = "serasacheques"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SerasaChequesId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("serasacheques") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SerasaCheques");
         forbiddenHiddens.Add("SerasaChequesId", context.localUtil.Format( (decimal)(A693SerasaChequesId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_SerasaId", context.localUtil.Format( (decimal)(AV11Insert_SerasaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("serasacheques:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z693SerasaChequesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z693SerasaChequesId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z694SerasaChequesTotalCons", StringUtil.LTrim( StringUtil.NToC( Z694SerasaChequesTotalCons, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z695SerasaChequesQtdSemFundo", StringUtil.LTrim( StringUtil.NToC( Z695SerasaChequesQtdSemFundo, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z696SerasaChequesUltOcorSus", context.localUtil.DToC( Z696SerasaChequesUltOcorSus, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z697SerasaChequesValorSemFundo", StringUtil.LTrim( StringUtil.NToC( Z697SerasaChequesValorSemFundo, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z698SerasaChequesTotalSust", StringUtil.LTrim( StringUtil.NToC( Z698SerasaChequesTotalSust, 15, 2, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vSERASACHEQUESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SerasaChequesId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSERASACHEQUESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SerasaChequesId), "ZZZZZZZZ9"), context));
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
         GXEncryptionTmp = "serasacheques"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SerasaChequesId,9,0));
         return formatLink("serasacheques") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SerasaCheques" ;
      }

      public override string GetPgmdesc( )
      {
         return "Serasa Cheques" ;
      }

      protected void InitializeNonKey2F85( )
      {
         A662SerasaId = 0;
         n662SerasaId = false;
         AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
         n662SerasaId = ((0==A662SerasaId) ? true : false);
         A694SerasaChequesTotalCons = 0;
         n694SerasaChequesTotalCons = false;
         AssignAttri("", false, "A694SerasaChequesTotalCons", ((Convert.ToDecimal(0)==A694SerasaChequesTotalCons)&&IsIns( )||n694SerasaChequesTotalCons ? "" : StringUtil.LTrim( StringUtil.NToC( A694SerasaChequesTotalCons, 15, 2, ".", ""))));
         n694SerasaChequesTotalCons = ((Convert.ToDecimal(0)==A694SerasaChequesTotalCons) ? true : false);
         A695SerasaChequesQtdSemFundo = 0;
         n695SerasaChequesQtdSemFundo = false;
         AssignAttri("", false, "A695SerasaChequesQtdSemFundo", ((Convert.ToDecimal(0)==A695SerasaChequesQtdSemFundo)&&IsIns( )||n695SerasaChequesQtdSemFundo ? "" : StringUtil.LTrim( StringUtil.NToC( A695SerasaChequesQtdSemFundo, 15, 2, ".", ""))));
         n695SerasaChequesQtdSemFundo = ((Convert.ToDecimal(0)==A695SerasaChequesQtdSemFundo) ? true : false);
         A696SerasaChequesUltOcorSus = DateTime.MinValue;
         n696SerasaChequesUltOcorSus = false;
         AssignAttri("", false, "A696SerasaChequesUltOcorSus", context.localUtil.Format(A696SerasaChequesUltOcorSus, "99/99/99"));
         n696SerasaChequesUltOcorSus = ((DateTime.MinValue==A696SerasaChequesUltOcorSus) ? true : false);
         A697SerasaChequesValorSemFundo = 0;
         n697SerasaChequesValorSemFundo = false;
         AssignAttri("", false, "A697SerasaChequesValorSemFundo", ((Convert.ToDecimal(0)==A697SerasaChequesValorSemFundo)&&IsIns( )||n697SerasaChequesValorSemFundo ? "" : StringUtil.LTrim( StringUtil.NToC( A697SerasaChequesValorSemFundo, 18, 2, ".", ""))));
         n697SerasaChequesValorSemFundo = ((Convert.ToDecimal(0)==A697SerasaChequesValorSemFundo) ? true : false);
         A698SerasaChequesTotalSust = 0;
         n698SerasaChequesTotalSust = false;
         AssignAttri("", false, "A698SerasaChequesTotalSust", ((Convert.ToDecimal(0)==A698SerasaChequesTotalSust)&&IsIns( )||n698SerasaChequesTotalSust ? "" : StringUtil.LTrim( StringUtil.NToC( A698SerasaChequesTotalSust, 15, 2, ".", ""))));
         n698SerasaChequesTotalSust = ((Convert.ToDecimal(0)==A698SerasaChequesTotalSust) ? true : false);
         Z694SerasaChequesTotalCons = 0;
         Z695SerasaChequesQtdSemFundo = 0;
         Z696SerasaChequesUltOcorSus = DateTime.MinValue;
         Z697SerasaChequesValorSemFundo = 0;
         Z698SerasaChequesTotalSust = 0;
         Z662SerasaId = 0;
      }

      protected void InitAll2F85( )
      {
         A693SerasaChequesId = 0;
         AssignAttri("", false, "A693SerasaChequesId", StringUtil.LTrimStr( (decimal)(A693SerasaChequesId), 9, 0));
         InitializeNonKey2F85( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019195394", true, true);
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
         context.AddJavascriptSource("serasacheques.js", "?202561019195395", false, true);
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
         edtSerasaChequesId_Internalname = "SERASACHEQUESID";
         lblTextblockserasaid_Internalname = "TEXTBLOCKSERASAID";
         Combo_serasaid_Internalname = "COMBO_SERASAID";
         edtSerasaId_Internalname = "SERASAID";
         divTablesplittedserasaid_Internalname = "TABLESPLITTEDSERASAID";
         edtSerasaChequesTotalCons_Internalname = "SERASACHEQUESTOTALCONS";
         edtSerasaChequesQtdSemFundo_Internalname = "SERASACHEQUESQTDSEMFUNDO";
         edtSerasaChequesUltOcorSus_Internalname = "SERASACHEQUESULTOCORSUS";
         edtSerasaChequesValorSemFundo_Internalname = "SERASACHEQUESVALORSEMFUNDO";
         edtSerasaChequesTotalSust_Internalname = "SERASACHEQUESTOTALSUST";
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
         Form.Caption = "Serasa Cheques";
         edtavComboserasaid_Jsonclick = "";
         edtavComboserasaid_Enabled = 0;
         edtavComboserasaid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSerasaChequesTotalSust_Jsonclick = "";
         edtSerasaChequesTotalSust_Enabled = 1;
         edtSerasaChequesValorSemFundo_Jsonclick = "";
         edtSerasaChequesValorSemFundo_Enabled = 1;
         edtSerasaChequesUltOcorSus_Jsonclick = "";
         edtSerasaChequesUltOcorSus_Enabled = 1;
         edtSerasaChequesQtdSemFundo_Jsonclick = "";
         edtSerasaChequesQtdSemFundo_Enabled = 1;
         edtSerasaChequesTotalCons_Jsonclick = "";
         edtSerasaChequesTotalCons_Enabled = 1;
         edtSerasaId_Jsonclick = "";
         edtSerasaId_Enabled = 1;
         edtSerasaId_Visible = 1;
         Combo_serasaid_Datalistprocparametersprefix = " \"ComboName\": \"SerasaId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"SerasaChequesId\": 0";
         Combo_serasaid_Datalistproc = "SerasaChequesLoadDVCombo";
         Combo_serasaid_Cls = "ExtendedCombo AttributeFL";
         Combo_serasaid_Caption = "";
         Combo_serasaid_Enabled = Convert.ToBoolean( -1);
         edtSerasaChequesId_Jsonclick = "";
         edtSerasaChequesId_Enabled = 0;
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
         /* Using cursor T002F15 */
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SerasaChequesId","fld":"vSERASACHEQUESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SerasaChequesId","fld":"vSERASACHEQUESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A693SerasaChequesId","fld":"SERASACHEQUESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_SerasaId","fld":"vINSERT_SERASAID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122F2","iparms":[]}""");
         setEventMetadata("VALID_SERASACHEQUESID","""{"handler":"Valid_Serasachequesid","iparms":[]}""");
         setEventMetadata("VALID_SERASAID","""{"handler":"Valid_Serasaid","iparms":[{"av":"A662SerasaId","fld":"SERASAID","pic":"ZZZZZZZZ9","nullAv":"n662SerasaId","type":"int"}]}""");
         setEventMetadata("VALID_SERASACHEQUESVALORSEMFUNDO","""{"handler":"Valid_Serasachequesvalorsemfundo","iparms":[]}""");
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
         Z696SerasaChequesUltOcorSus = DateTime.MinValue;
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
         A696SerasaChequesUltOcorSus = DateTime.MinValue;
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
         sMode85 = "";
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
         T002F5_A693SerasaChequesId = new int[1] ;
         T002F5_A694SerasaChequesTotalCons = new decimal[1] ;
         T002F5_n694SerasaChequesTotalCons = new bool[] {false} ;
         T002F5_A695SerasaChequesQtdSemFundo = new decimal[1] ;
         T002F5_n695SerasaChequesQtdSemFundo = new bool[] {false} ;
         T002F5_A696SerasaChequesUltOcorSus = new DateTime[] {DateTime.MinValue} ;
         T002F5_n696SerasaChequesUltOcorSus = new bool[] {false} ;
         T002F5_A697SerasaChequesValorSemFundo = new decimal[1] ;
         T002F5_n697SerasaChequesValorSemFundo = new bool[] {false} ;
         T002F5_A698SerasaChequesTotalSust = new decimal[1] ;
         T002F5_n698SerasaChequesTotalSust = new bool[] {false} ;
         T002F5_A662SerasaId = new int[1] ;
         T002F5_n662SerasaId = new bool[] {false} ;
         T002F4_A662SerasaId = new int[1] ;
         T002F4_n662SerasaId = new bool[] {false} ;
         T002F6_A662SerasaId = new int[1] ;
         T002F6_n662SerasaId = new bool[] {false} ;
         T002F7_A693SerasaChequesId = new int[1] ;
         T002F3_A693SerasaChequesId = new int[1] ;
         T002F3_A694SerasaChequesTotalCons = new decimal[1] ;
         T002F3_n694SerasaChequesTotalCons = new bool[] {false} ;
         T002F3_A695SerasaChequesQtdSemFundo = new decimal[1] ;
         T002F3_n695SerasaChequesQtdSemFundo = new bool[] {false} ;
         T002F3_A696SerasaChequesUltOcorSus = new DateTime[] {DateTime.MinValue} ;
         T002F3_n696SerasaChequesUltOcorSus = new bool[] {false} ;
         T002F3_A697SerasaChequesValorSemFundo = new decimal[1] ;
         T002F3_n697SerasaChequesValorSemFundo = new bool[] {false} ;
         T002F3_A698SerasaChequesTotalSust = new decimal[1] ;
         T002F3_n698SerasaChequesTotalSust = new bool[] {false} ;
         T002F3_A662SerasaId = new int[1] ;
         T002F3_n662SerasaId = new bool[] {false} ;
         T002F8_A693SerasaChequesId = new int[1] ;
         T002F9_A693SerasaChequesId = new int[1] ;
         T002F2_A693SerasaChequesId = new int[1] ;
         T002F2_A694SerasaChequesTotalCons = new decimal[1] ;
         T002F2_n694SerasaChequesTotalCons = new bool[] {false} ;
         T002F2_A695SerasaChequesQtdSemFundo = new decimal[1] ;
         T002F2_n695SerasaChequesQtdSemFundo = new bool[] {false} ;
         T002F2_A696SerasaChequesUltOcorSus = new DateTime[] {DateTime.MinValue} ;
         T002F2_n696SerasaChequesUltOcorSus = new bool[] {false} ;
         T002F2_A697SerasaChequesValorSemFundo = new decimal[1] ;
         T002F2_n697SerasaChequesValorSemFundo = new bool[] {false} ;
         T002F2_A698SerasaChequesTotalSust = new decimal[1] ;
         T002F2_n698SerasaChequesTotalSust = new bool[] {false} ;
         T002F2_A662SerasaId = new int[1] ;
         T002F2_n662SerasaId = new bool[] {false} ;
         T002F11_A693SerasaChequesId = new int[1] ;
         T002F14_A693SerasaChequesId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T002F15_A662SerasaId = new int[1] ;
         T002F15_n662SerasaId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasacheques__default(),
            new Object[][] {
                new Object[] {
               T002F2_A693SerasaChequesId, T002F2_A694SerasaChequesTotalCons, T002F2_n694SerasaChequesTotalCons, T002F2_A695SerasaChequesQtdSemFundo, T002F2_n695SerasaChequesQtdSemFundo, T002F2_A696SerasaChequesUltOcorSus, T002F2_n696SerasaChequesUltOcorSus, T002F2_A697SerasaChequesValorSemFundo, T002F2_n697SerasaChequesValorSemFundo, T002F2_A698SerasaChequesTotalSust,
               T002F2_n698SerasaChequesTotalSust, T002F2_A662SerasaId, T002F2_n662SerasaId
               }
               , new Object[] {
               T002F3_A693SerasaChequesId, T002F3_A694SerasaChequesTotalCons, T002F3_n694SerasaChequesTotalCons, T002F3_A695SerasaChequesQtdSemFundo, T002F3_n695SerasaChequesQtdSemFundo, T002F3_A696SerasaChequesUltOcorSus, T002F3_n696SerasaChequesUltOcorSus, T002F3_A697SerasaChequesValorSemFundo, T002F3_n697SerasaChequesValorSemFundo, T002F3_A698SerasaChequesTotalSust,
               T002F3_n698SerasaChequesTotalSust, T002F3_A662SerasaId, T002F3_n662SerasaId
               }
               , new Object[] {
               T002F4_A662SerasaId
               }
               , new Object[] {
               T002F5_A693SerasaChequesId, T002F5_A694SerasaChequesTotalCons, T002F5_n694SerasaChequesTotalCons, T002F5_A695SerasaChequesQtdSemFundo, T002F5_n695SerasaChequesQtdSemFundo, T002F5_A696SerasaChequesUltOcorSus, T002F5_n696SerasaChequesUltOcorSus, T002F5_A697SerasaChequesValorSemFundo, T002F5_n697SerasaChequesValorSemFundo, T002F5_A698SerasaChequesTotalSust,
               T002F5_n698SerasaChequesTotalSust, T002F5_A662SerasaId, T002F5_n662SerasaId
               }
               , new Object[] {
               T002F6_A662SerasaId
               }
               , new Object[] {
               T002F7_A693SerasaChequesId
               }
               , new Object[] {
               T002F8_A693SerasaChequesId
               }
               , new Object[] {
               T002F9_A693SerasaChequesId
               }
               , new Object[] {
               }
               , new Object[] {
               T002F11_A693SerasaChequesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002F14_A693SerasaChequesId
               }
               , new Object[] {
               T002F15_A662SerasaId
               }
            }
         );
         AV19Pgmname = "SerasaCheques";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound85 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7SerasaChequesId ;
      private int Z693SerasaChequesId ;
      private int Z662SerasaId ;
      private int N662SerasaId ;
      private int A662SerasaId ;
      private int AV7SerasaChequesId ;
      private int trnEnded ;
      private int A693SerasaChequesId ;
      private int edtSerasaChequesId_Enabled ;
      private int edtSerasaId_Visible ;
      private int edtSerasaId_Enabled ;
      private int edtSerasaChequesTotalCons_Enabled ;
      private int edtSerasaChequesQtdSemFundo_Enabled ;
      private int edtSerasaChequesUltOcorSus_Enabled ;
      private int edtSerasaChequesValorSemFundo_Enabled ;
      private int edtSerasaChequesTotalSust_Enabled ;
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
      private decimal Z694SerasaChequesTotalCons ;
      private decimal Z695SerasaChequesQtdSemFundo ;
      private decimal Z697SerasaChequesValorSemFundo ;
      private decimal Z698SerasaChequesTotalSust ;
      private decimal A694SerasaChequesTotalCons ;
      private decimal A695SerasaChequesQtdSemFundo ;
      private decimal A697SerasaChequesValorSemFundo ;
      private decimal A698SerasaChequesTotalSust ;
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
      private string edtSerasaChequesId_Internalname ;
      private string TempTags ;
      private string edtSerasaChequesId_Jsonclick ;
      private string divTablesplittedserasaid_Internalname ;
      private string lblTextblockserasaid_Internalname ;
      private string lblTextblockserasaid_Jsonclick ;
      private string Combo_serasaid_Caption ;
      private string Combo_serasaid_Cls ;
      private string Combo_serasaid_Datalistproc ;
      private string Combo_serasaid_Datalistprocparametersprefix ;
      private string Combo_serasaid_Internalname ;
      private string edtSerasaId_Jsonclick ;
      private string edtSerasaChequesTotalCons_Internalname ;
      private string edtSerasaChequesTotalCons_Jsonclick ;
      private string edtSerasaChequesQtdSemFundo_Internalname ;
      private string edtSerasaChequesQtdSemFundo_Jsonclick ;
      private string edtSerasaChequesUltOcorSus_Internalname ;
      private string edtSerasaChequesUltOcorSus_Jsonclick ;
      private string edtSerasaChequesValorSemFundo_Internalname ;
      private string edtSerasaChequesValorSemFundo_Jsonclick ;
      private string edtSerasaChequesTotalSust_Internalname ;
      private string edtSerasaChequesTotalSust_Jsonclick ;
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
      private string sMode85 ;
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
      private DateTime Z696SerasaChequesUltOcorSus ;
      private DateTime A696SerasaChequesUltOcorSus ;
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
      private bool n694SerasaChequesTotalCons ;
      private bool n695SerasaChequesQtdSemFundo ;
      private bool n697SerasaChequesValorSemFundo ;
      private bool n698SerasaChequesTotalSust ;
      private bool n696SerasaChequesUltOcorSus ;
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
      private int[] T002F5_A693SerasaChequesId ;
      private decimal[] T002F5_A694SerasaChequesTotalCons ;
      private bool[] T002F5_n694SerasaChequesTotalCons ;
      private decimal[] T002F5_A695SerasaChequesQtdSemFundo ;
      private bool[] T002F5_n695SerasaChequesQtdSemFundo ;
      private DateTime[] T002F5_A696SerasaChequesUltOcorSus ;
      private bool[] T002F5_n696SerasaChequesUltOcorSus ;
      private decimal[] T002F5_A697SerasaChequesValorSemFundo ;
      private bool[] T002F5_n697SerasaChequesValorSemFundo ;
      private decimal[] T002F5_A698SerasaChequesTotalSust ;
      private bool[] T002F5_n698SerasaChequesTotalSust ;
      private int[] T002F5_A662SerasaId ;
      private bool[] T002F5_n662SerasaId ;
      private int[] T002F4_A662SerasaId ;
      private bool[] T002F4_n662SerasaId ;
      private int[] T002F6_A662SerasaId ;
      private bool[] T002F6_n662SerasaId ;
      private int[] T002F7_A693SerasaChequesId ;
      private int[] T002F3_A693SerasaChequesId ;
      private decimal[] T002F3_A694SerasaChequesTotalCons ;
      private bool[] T002F3_n694SerasaChequesTotalCons ;
      private decimal[] T002F3_A695SerasaChequesQtdSemFundo ;
      private bool[] T002F3_n695SerasaChequesQtdSemFundo ;
      private DateTime[] T002F3_A696SerasaChequesUltOcorSus ;
      private bool[] T002F3_n696SerasaChequesUltOcorSus ;
      private decimal[] T002F3_A697SerasaChequesValorSemFundo ;
      private bool[] T002F3_n697SerasaChequesValorSemFundo ;
      private decimal[] T002F3_A698SerasaChequesTotalSust ;
      private bool[] T002F3_n698SerasaChequesTotalSust ;
      private int[] T002F3_A662SerasaId ;
      private bool[] T002F3_n662SerasaId ;
      private int[] T002F8_A693SerasaChequesId ;
      private int[] T002F9_A693SerasaChequesId ;
      private int[] T002F2_A693SerasaChequesId ;
      private decimal[] T002F2_A694SerasaChequesTotalCons ;
      private bool[] T002F2_n694SerasaChequesTotalCons ;
      private decimal[] T002F2_A695SerasaChequesQtdSemFundo ;
      private bool[] T002F2_n695SerasaChequesQtdSemFundo ;
      private DateTime[] T002F2_A696SerasaChequesUltOcorSus ;
      private bool[] T002F2_n696SerasaChequesUltOcorSus ;
      private decimal[] T002F2_A697SerasaChequesValorSemFundo ;
      private bool[] T002F2_n697SerasaChequesValorSemFundo ;
      private decimal[] T002F2_A698SerasaChequesTotalSust ;
      private bool[] T002F2_n698SerasaChequesTotalSust ;
      private int[] T002F2_A662SerasaId ;
      private bool[] T002F2_n662SerasaId ;
      private int[] T002F11_A693SerasaChequesId ;
      private int[] T002F14_A693SerasaChequesId ;
      private int[] T002F15_A662SerasaId ;
      private bool[] T002F15_n662SerasaId ;
   }

   public class serasacheques__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT002F2;
          prmT002F2 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmT002F3;
          prmT002F3 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmT002F4;
          prmT002F4 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002F5;
          prmT002F5 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmT002F6;
          prmT002F6 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002F7;
          prmT002F7 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmT002F8;
          prmT002F8 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmT002F9;
          prmT002F9 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmT002F10;
          prmT002F10 = new Object[] {
          new ParDef("SerasaChequesTotalCons",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaChequesQtdSemFundo",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaChequesUltOcorSus",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaChequesValorSemFundo",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaChequesTotalSust",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002F11;
          prmT002F11 = new Object[] {
          };
          Object[] prmT002F12;
          prmT002F12 = new Object[] {
          new ParDef("SerasaChequesTotalCons",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaChequesQtdSemFundo",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaChequesUltOcorSus",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaChequesValorSemFundo",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaChequesTotalSust",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmT002F13;
          prmT002F13 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmT002F14;
          prmT002F14 = new Object[] {
          };
          Object[] prmT002F15;
          prmT002F15 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T002F2", "SELECT SerasaChequesId, SerasaChequesTotalCons, SerasaChequesQtdSemFundo, SerasaChequesUltOcorSus, SerasaChequesValorSemFundo, SerasaChequesTotalSust, SerasaId FROM SerasaCheques WHERE SerasaChequesId = :SerasaChequesId  FOR UPDATE OF SerasaCheques NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002F2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002F3", "SELECT SerasaChequesId, SerasaChequesTotalCons, SerasaChequesQtdSemFundo, SerasaChequesUltOcorSus, SerasaChequesValorSemFundo, SerasaChequesTotalSust, SerasaId FROM SerasaCheques WHERE SerasaChequesId = :SerasaChequesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002F4", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002F5", "SELECT TM1.SerasaChequesId, TM1.SerasaChequesTotalCons, TM1.SerasaChequesQtdSemFundo, TM1.SerasaChequesUltOcorSus, TM1.SerasaChequesValorSemFundo, TM1.SerasaChequesTotalSust, TM1.SerasaId FROM SerasaCheques TM1 WHERE TM1.SerasaChequesId = :SerasaChequesId ORDER BY TM1.SerasaChequesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002F6", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002F7", "SELECT SerasaChequesId FROM SerasaCheques WHERE SerasaChequesId = :SerasaChequesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002F8", "SELECT SerasaChequesId FROM SerasaCheques WHERE ( SerasaChequesId > :SerasaChequesId) ORDER BY SerasaChequesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002F9", "SELECT SerasaChequesId FROM SerasaCheques WHERE ( SerasaChequesId < :SerasaChequesId) ORDER BY SerasaChequesId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002F10", "SAVEPOINT gxupdate;INSERT INTO SerasaCheques(SerasaChequesTotalCons, SerasaChequesQtdSemFundo, SerasaChequesUltOcorSus, SerasaChequesValorSemFundo, SerasaChequesTotalSust, SerasaId) VALUES(:SerasaChequesTotalCons, :SerasaChequesQtdSemFundo, :SerasaChequesUltOcorSus, :SerasaChequesValorSemFundo, :SerasaChequesTotalSust, :SerasaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002F10)
             ,new CursorDef("T002F11", "SELECT currval('SerasaChequesId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002F12", "SAVEPOINT gxupdate;UPDATE SerasaCheques SET SerasaChequesTotalCons=:SerasaChequesTotalCons, SerasaChequesQtdSemFundo=:SerasaChequesQtdSemFundo, SerasaChequesUltOcorSus=:SerasaChequesUltOcorSus, SerasaChequesValorSemFundo=:SerasaChequesValorSemFundo, SerasaChequesTotalSust=:SerasaChequesTotalSust, SerasaId=:SerasaId  WHERE SerasaChequesId = :SerasaChequesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002F12)
             ,new CursorDef("T002F13", "SAVEPOINT gxupdate;DELETE FROM SerasaCheques  WHERE SerasaChequesId = :SerasaChequesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002F13)
             ,new CursorDef("T002F14", "SELECT SerasaChequesId FROM SerasaCheques ORDER BY SerasaChequesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002F15", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F15,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
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
