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
   public class serasaacoes : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "serasaacoes")), "serasaacoes") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "serasaacoes")))) ;
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
                  AV7SerasaAcoesId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaAcoesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7SerasaAcoesId", StringUtil.LTrimStr( (decimal)(AV7SerasaAcoesId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSERASAACOESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SerasaAcoesId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Serasa Acoes", 0) ;
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

      public serasaacoes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasaacoes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_SerasaAcoesId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SerasaAcoesId = aP1_SerasaAcoesId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaAcoesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaAcoesId_Internalname, "Acoes Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaAcoesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A699SerasaAcoesId), 9, 0, ",", "")), StringUtil.LTrim( ((edtSerasaAcoesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A699SerasaAcoesId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A699SerasaAcoesId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaAcoesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaAcoesId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SerasaAcoes.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblockserasaid_Internalname, "Serasa", "", "", lblTextblockserasaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_SerasaAcoes.htm");
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
         GxWebStd.gx_single_line_edit( context, edtSerasaId_Internalname, ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ",", ""))), ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A662SerasaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaId_Jsonclick, 0, "Attribute", "", "", "", "", edtSerasaId_Visible, edtSerasaId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SerasaAcoes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaAcoesData_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaAcoesData_Internalname, "da ocorrência", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSerasaAcoesData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSerasaAcoesData_Internalname, context.localUtil.Format(A700SerasaAcoesData, "99/99/99"), context.localUtil.Format( A700SerasaAcoesData, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaAcoesData_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaAcoesData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SerasaAcoes.htm");
         GxWebStd.gx_bitmap( context, edtSerasaAcoesData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSerasaAcoesData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_SerasaAcoes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaAcoesNatureza_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaAcoesNatureza_Internalname, "Natureza", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaAcoesNatureza_Internalname, A701SerasaAcoesNatureza, StringUtil.RTrim( context.localUtil.Format( A701SerasaAcoesNatureza, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaAcoesNatureza_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaAcoesNatureza_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaAcoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaAcoesValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaAcoesValor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaAcoesValor_Internalname, ((Convert.ToDecimal(0)==A702SerasaAcoesValor)&&IsIns( )||n702SerasaAcoesValor ? "" : StringUtil.LTrim( StringUtil.NToC( A702SerasaAcoesValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A702SerasaAcoesValor)&&IsIns( )||n702SerasaAcoesValor ? "" : StringUtil.LTrim( ((edtSerasaAcoesValor_Enabled!=0) ? context.localUtil.Format( A702SerasaAcoesValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A702SerasaAcoesValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaAcoesValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaAcoesValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_SerasaAcoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaAcoesDistribuidor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaAcoesDistribuidor_Internalname, "Distribuidor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaAcoesDistribuidor_Internalname, A703SerasaAcoesDistribuidor, StringUtil.RTrim( context.localUtil.Format( A703SerasaAcoesDistribuidor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaAcoesDistribuidor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaAcoesDistribuidor_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaAcoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaAcoesVara_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaAcoesVara_Internalname, "Vara", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaAcoesVara_Internalname, A704SerasaAcoesVara, StringUtil.RTrim( context.localUtil.Format( A704SerasaAcoesVara, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaAcoesVara_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaAcoesVara_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaAcoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaAcoesCidade_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaAcoesCidade_Internalname, "Cidade", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaAcoesCidade_Internalname, A705SerasaAcoesCidade, StringUtil.RTrim( context.localUtil.Format( A705SerasaAcoesCidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaAcoesCidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaAcoesCidade_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaAcoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaAcoesUF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaAcoesUF_Internalname, "UF", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaAcoesUF_Internalname, A706SerasaAcoesUF, StringUtil.RTrim( context.localUtil.Format( A706SerasaAcoesUF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaAcoesUF_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaAcoesUF_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaAcoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaAcoesPrincipal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaAcoesPrincipal_Internalname, "Principal", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaAcoesPrincipal_Internalname, A707SerasaAcoesPrincipal, StringUtil.RTrim( context.localUtil.Format( A707SerasaAcoesPrincipal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaAcoesPrincipal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaAcoesPrincipal_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaAcoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaAcoesTipoMoeda_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaAcoesTipoMoeda_Internalname, "moeda", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaAcoesTipoMoeda_Internalname, A708SerasaAcoesTipoMoeda, StringUtil.RTrim( context.localUtil.Format( A708SerasaAcoesTipoMoeda, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaAcoesTipoMoeda_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaAcoesTipoMoeda_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaAcoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaAcoesQtdOco_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaAcoesQtdOco_Internalname, "de ações", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaAcoesQtdOco_Internalname, ((0==A709SerasaAcoesQtdOco)&&IsIns( )||n709SerasaAcoesQtdOco ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A709SerasaAcoesQtdOco), 4, 0, ",", ""))), ((0==A709SerasaAcoesQtdOco)&&IsIns( )||n709SerasaAcoesQtdOco ? "" : StringUtil.LTrim( ((edtSerasaAcoesQtdOco_Enabled!=0) ? context.localUtil.Format( (decimal)(A709SerasaAcoesQtdOco), "ZZZ9") : context.localUtil.Format( (decimal)(A709SerasaAcoesQtdOco), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaAcoesQtdOco_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaAcoesQtdOco_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SerasaAcoes.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaAcoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaAcoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaAcoes.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboserasaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ComboSerasaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboserasaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ComboSerasaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV18ComboSerasaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboserasaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboserasaid_Visible, edtavComboserasaid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SerasaAcoes.htm");
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
         E112G2 ();
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
               Z699SerasaAcoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z699SerasaAcoesId"), ",", "."), 18, MidpointRounding.ToEven));
               Z700SerasaAcoesData = context.localUtil.CToD( cgiGet( "Z700SerasaAcoesData"), 0);
               n700SerasaAcoesData = ((DateTime.MinValue==A700SerasaAcoesData) ? true : false);
               Z701SerasaAcoesNatureza = cgiGet( "Z701SerasaAcoesNatureza");
               n701SerasaAcoesNatureza = (String.IsNullOrEmpty(StringUtil.RTrim( A701SerasaAcoesNatureza)) ? true : false);
               Z702SerasaAcoesValor = context.localUtil.CToN( cgiGet( "Z702SerasaAcoesValor"), ",", ".");
               n702SerasaAcoesValor = ((Convert.ToDecimal(0)==A702SerasaAcoesValor) ? true : false);
               Z703SerasaAcoesDistribuidor = cgiGet( "Z703SerasaAcoesDistribuidor");
               n703SerasaAcoesDistribuidor = (String.IsNullOrEmpty(StringUtil.RTrim( A703SerasaAcoesDistribuidor)) ? true : false);
               Z704SerasaAcoesVara = cgiGet( "Z704SerasaAcoesVara");
               n704SerasaAcoesVara = (String.IsNullOrEmpty(StringUtil.RTrim( A704SerasaAcoesVara)) ? true : false);
               Z705SerasaAcoesCidade = cgiGet( "Z705SerasaAcoesCidade");
               n705SerasaAcoesCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A705SerasaAcoesCidade)) ? true : false);
               Z706SerasaAcoesUF = cgiGet( "Z706SerasaAcoesUF");
               n706SerasaAcoesUF = (String.IsNullOrEmpty(StringUtil.RTrim( A706SerasaAcoesUF)) ? true : false);
               Z707SerasaAcoesPrincipal = cgiGet( "Z707SerasaAcoesPrincipal");
               n707SerasaAcoesPrincipal = (String.IsNullOrEmpty(StringUtil.RTrim( A707SerasaAcoesPrincipal)) ? true : false);
               Z708SerasaAcoesTipoMoeda = cgiGet( "Z708SerasaAcoesTipoMoeda");
               n708SerasaAcoesTipoMoeda = (String.IsNullOrEmpty(StringUtil.RTrim( A708SerasaAcoesTipoMoeda)) ? true : false);
               Z709SerasaAcoesQtdOco = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z709SerasaAcoesQtdOco"), ",", "."), 18, MidpointRounding.ToEven));
               n709SerasaAcoesQtdOco = ((0==A709SerasaAcoesQtdOco) ? true : false);
               Z662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z662SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
               n662SerasaId = ((0==A662SerasaId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N662SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
               n662SerasaId = ((0==A662SerasaId) ? true : false);
               AV7SerasaAcoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vSERASAACOESID"), ",", "."), 18, MidpointRounding.ToEven));
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
               A699SerasaAcoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaAcoesId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
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
               if ( context.localUtil.VCDate( cgiGet( edtSerasaAcoesData_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data da ocorrência"}), 1, "SERASAACOESDATA");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaAcoesData_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A700SerasaAcoesData = DateTime.MinValue;
                  n700SerasaAcoesData = false;
                  AssignAttri("", false, "A700SerasaAcoesData", context.localUtil.Format(A700SerasaAcoesData, "99/99/99"));
               }
               else
               {
                  A700SerasaAcoesData = context.localUtil.CToD( cgiGet( edtSerasaAcoesData_Internalname), 2);
                  n700SerasaAcoesData = false;
                  AssignAttri("", false, "A700SerasaAcoesData", context.localUtil.Format(A700SerasaAcoesData, "99/99/99"));
               }
               n700SerasaAcoesData = ((DateTime.MinValue==A700SerasaAcoesData) ? true : false);
               A701SerasaAcoesNatureza = cgiGet( edtSerasaAcoesNatureza_Internalname);
               n701SerasaAcoesNatureza = false;
               AssignAttri("", false, "A701SerasaAcoesNatureza", A701SerasaAcoesNatureza);
               n701SerasaAcoesNatureza = (String.IsNullOrEmpty(StringUtil.RTrim( A701SerasaAcoesNatureza)) ? true : false);
               n702SerasaAcoesValor = ((StringUtil.StrCmp(cgiGet( edtSerasaAcoesValor_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaAcoesValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaAcoesValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASAACOESVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaAcoesValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A702SerasaAcoesValor = 0;
                  n702SerasaAcoesValor = false;
                  AssignAttri("", false, "A702SerasaAcoesValor", (n702SerasaAcoesValor ? "" : StringUtil.LTrim( StringUtil.NToC( A702SerasaAcoesValor, 18, 2, ".", ""))));
               }
               else
               {
                  A702SerasaAcoesValor = context.localUtil.CToN( cgiGet( edtSerasaAcoesValor_Internalname), ",", ".");
                  AssignAttri("", false, "A702SerasaAcoesValor", (n702SerasaAcoesValor ? "" : StringUtil.LTrim( StringUtil.NToC( A702SerasaAcoesValor, 18, 2, ".", ""))));
               }
               A703SerasaAcoesDistribuidor = cgiGet( edtSerasaAcoesDistribuidor_Internalname);
               n703SerasaAcoesDistribuidor = false;
               AssignAttri("", false, "A703SerasaAcoesDistribuidor", A703SerasaAcoesDistribuidor);
               n703SerasaAcoesDistribuidor = (String.IsNullOrEmpty(StringUtil.RTrim( A703SerasaAcoesDistribuidor)) ? true : false);
               A704SerasaAcoesVara = cgiGet( edtSerasaAcoesVara_Internalname);
               n704SerasaAcoesVara = false;
               AssignAttri("", false, "A704SerasaAcoesVara", A704SerasaAcoesVara);
               n704SerasaAcoesVara = (String.IsNullOrEmpty(StringUtil.RTrim( A704SerasaAcoesVara)) ? true : false);
               A705SerasaAcoesCidade = cgiGet( edtSerasaAcoesCidade_Internalname);
               n705SerasaAcoesCidade = false;
               AssignAttri("", false, "A705SerasaAcoesCidade", A705SerasaAcoesCidade);
               n705SerasaAcoesCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A705SerasaAcoesCidade)) ? true : false);
               A706SerasaAcoesUF = cgiGet( edtSerasaAcoesUF_Internalname);
               n706SerasaAcoesUF = false;
               AssignAttri("", false, "A706SerasaAcoesUF", A706SerasaAcoesUF);
               n706SerasaAcoesUF = (String.IsNullOrEmpty(StringUtil.RTrim( A706SerasaAcoesUF)) ? true : false);
               A707SerasaAcoesPrincipal = cgiGet( edtSerasaAcoesPrincipal_Internalname);
               n707SerasaAcoesPrincipal = false;
               AssignAttri("", false, "A707SerasaAcoesPrincipal", A707SerasaAcoesPrincipal);
               n707SerasaAcoesPrincipal = (String.IsNullOrEmpty(StringUtil.RTrim( A707SerasaAcoesPrincipal)) ? true : false);
               A708SerasaAcoesTipoMoeda = cgiGet( edtSerasaAcoesTipoMoeda_Internalname);
               n708SerasaAcoesTipoMoeda = false;
               AssignAttri("", false, "A708SerasaAcoesTipoMoeda", A708SerasaAcoesTipoMoeda);
               n708SerasaAcoesTipoMoeda = (String.IsNullOrEmpty(StringUtil.RTrim( A708SerasaAcoesTipoMoeda)) ? true : false);
               n709SerasaAcoesQtdOco = ((StringUtil.StrCmp(cgiGet( edtSerasaAcoesQtdOco_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaAcoesQtdOco_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaAcoesQtdOco_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASAACOESQTDOCO");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaAcoesQtdOco_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A709SerasaAcoesQtdOco = 0;
                  n709SerasaAcoesQtdOco = false;
                  AssignAttri("", false, "A709SerasaAcoesQtdOco", (n709SerasaAcoesQtdOco ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A709SerasaAcoesQtdOco), 4, 0, ".", ""))));
               }
               else
               {
                  A709SerasaAcoesQtdOco = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaAcoesQtdOco_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A709SerasaAcoesQtdOco", (n709SerasaAcoesQtdOco ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A709SerasaAcoesQtdOco), 4, 0, ".", ""))));
               }
               AV18ComboSerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboserasaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18ComboSerasaId", StringUtil.LTrimStr( (decimal)(AV18ComboSerasaId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SerasaAcoes");
               A699SerasaAcoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaAcoesId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
               forbiddenHiddens.Add("SerasaAcoesId", context.localUtil.Format( (decimal)(A699SerasaAcoesId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_SerasaId", context.localUtil.Format( (decimal)(AV11Insert_SerasaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A699SerasaAcoesId != Z699SerasaAcoesId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("serasaacoes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A699SerasaAcoesId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaAcoesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
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
                     sMode86 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode86;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound86 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2G0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SERASAACOESID");
                        AnyError = 1;
                        GX_FocusControl = edtSerasaAcoesId_Internalname;
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
                           E112G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122G2 ();
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
            E122G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2G86( ) ;
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
            DisableAttributes2G86( ) ;
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

      protected void CONFIRM_2G0( )
      {
         BeforeValidate2G86( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2G86( ) ;
            }
            else
            {
               CheckExtendedTable2G86( ) ;
               CloseExtendedTableCursors2G86( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2G0( )
      {
      }

      protected void E112G2( )
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
                     new serasaacoesloaddvcombo(context ).execute(  "SerasaId",  "GET",  false,  AV7SerasaAcoesId,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
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

      protected void E122G2( )
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
         new serasaacoesloaddvcombo(context ).execute(  "SerasaId",  Gx_mode,  false,  AV7SerasaAcoesId,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
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

      protected void ZM2G86( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z700SerasaAcoesData = T002G3_A700SerasaAcoesData[0];
               Z701SerasaAcoesNatureza = T002G3_A701SerasaAcoesNatureza[0];
               Z702SerasaAcoesValor = T002G3_A702SerasaAcoesValor[0];
               Z703SerasaAcoesDistribuidor = T002G3_A703SerasaAcoesDistribuidor[0];
               Z704SerasaAcoesVara = T002G3_A704SerasaAcoesVara[0];
               Z705SerasaAcoesCidade = T002G3_A705SerasaAcoesCidade[0];
               Z706SerasaAcoesUF = T002G3_A706SerasaAcoesUF[0];
               Z707SerasaAcoesPrincipal = T002G3_A707SerasaAcoesPrincipal[0];
               Z708SerasaAcoesTipoMoeda = T002G3_A708SerasaAcoesTipoMoeda[0];
               Z709SerasaAcoesQtdOco = T002G3_A709SerasaAcoesQtdOco[0];
               Z662SerasaId = T002G3_A662SerasaId[0];
            }
            else
            {
               Z700SerasaAcoesData = A700SerasaAcoesData;
               Z701SerasaAcoesNatureza = A701SerasaAcoesNatureza;
               Z702SerasaAcoesValor = A702SerasaAcoesValor;
               Z703SerasaAcoesDistribuidor = A703SerasaAcoesDistribuidor;
               Z704SerasaAcoesVara = A704SerasaAcoesVara;
               Z705SerasaAcoesCidade = A705SerasaAcoesCidade;
               Z706SerasaAcoesUF = A706SerasaAcoesUF;
               Z707SerasaAcoesPrincipal = A707SerasaAcoesPrincipal;
               Z708SerasaAcoesTipoMoeda = A708SerasaAcoesTipoMoeda;
               Z709SerasaAcoesQtdOco = A709SerasaAcoesQtdOco;
               Z662SerasaId = A662SerasaId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z699SerasaAcoesId = A699SerasaAcoesId;
            Z700SerasaAcoesData = A700SerasaAcoesData;
            Z701SerasaAcoesNatureza = A701SerasaAcoesNatureza;
            Z702SerasaAcoesValor = A702SerasaAcoesValor;
            Z703SerasaAcoesDistribuidor = A703SerasaAcoesDistribuidor;
            Z704SerasaAcoesVara = A704SerasaAcoesVara;
            Z705SerasaAcoesCidade = A705SerasaAcoesCidade;
            Z706SerasaAcoesUF = A706SerasaAcoesUF;
            Z707SerasaAcoesPrincipal = A707SerasaAcoesPrincipal;
            Z708SerasaAcoesTipoMoeda = A708SerasaAcoesTipoMoeda;
            Z709SerasaAcoesQtdOco = A709SerasaAcoesQtdOco;
            Z662SerasaId = A662SerasaId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSerasaAcoesId_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesId_Enabled), 5, 0), true);
         AV19Pgmname = "SerasaAcoes";
         AssignAttri("", false, "AV19Pgmname", AV19Pgmname);
         edtSerasaAcoesId_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SerasaAcoesId) )
         {
            A699SerasaAcoesId = AV7SerasaAcoesId;
            AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
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

      protected void Load2G86( )
      {
         /* Using cursor T002G5 */
         pr_default.execute(3, new Object[] {A699SerasaAcoesId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound86 = 1;
            A700SerasaAcoesData = T002G5_A700SerasaAcoesData[0];
            n700SerasaAcoesData = T002G5_n700SerasaAcoesData[0];
            AssignAttri("", false, "A700SerasaAcoesData", context.localUtil.Format(A700SerasaAcoesData, "99/99/99"));
            A701SerasaAcoesNatureza = T002G5_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = T002G5_n701SerasaAcoesNatureza[0];
            AssignAttri("", false, "A701SerasaAcoesNatureza", A701SerasaAcoesNatureza);
            A702SerasaAcoesValor = T002G5_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = T002G5_n702SerasaAcoesValor[0];
            AssignAttri("", false, "A702SerasaAcoesValor", ((Convert.ToDecimal(0)==A702SerasaAcoesValor)&&IsIns( )||n702SerasaAcoesValor ? "" : StringUtil.LTrim( StringUtil.NToC( A702SerasaAcoesValor, 18, 2, ".", ""))));
            A703SerasaAcoesDistribuidor = T002G5_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = T002G5_n703SerasaAcoesDistribuidor[0];
            AssignAttri("", false, "A703SerasaAcoesDistribuidor", A703SerasaAcoesDistribuidor);
            A704SerasaAcoesVara = T002G5_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = T002G5_n704SerasaAcoesVara[0];
            AssignAttri("", false, "A704SerasaAcoesVara", A704SerasaAcoesVara);
            A705SerasaAcoesCidade = T002G5_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = T002G5_n705SerasaAcoesCidade[0];
            AssignAttri("", false, "A705SerasaAcoesCidade", A705SerasaAcoesCidade);
            A706SerasaAcoesUF = T002G5_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = T002G5_n706SerasaAcoesUF[0];
            AssignAttri("", false, "A706SerasaAcoesUF", A706SerasaAcoesUF);
            A707SerasaAcoesPrincipal = T002G5_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = T002G5_n707SerasaAcoesPrincipal[0];
            AssignAttri("", false, "A707SerasaAcoesPrincipal", A707SerasaAcoesPrincipal);
            A708SerasaAcoesTipoMoeda = T002G5_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = T002G5_n708SerasaAcoesTipoMoeda[0];
            AssignAttri("", false, "A708SerasaAcoesTipoMoeda", A708SerasaAcoesTipoMoeda);
            A709SerasaAcoesQtdOco = T002G5_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = T002G5_n709SerasaAcoesQtdOco[0];
            AssignAttri("", false, "A709SerasaAcoesQtdOco", ((0==A709SerasaAcoesQtdOco)&&IsIns( )||n709SerasaAcoesQtdOco ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A709SerasaAcoesQtdOco), 4, 0, ".", ""))));
            A662SerasaId = T002G5_A662SerasaId[0];
            n662SerasaId = T002G5_n662SerasaId[0];
            AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            ZM2G86( -9) ;
         }
         pr_default.close(3);
         OnLoadActions2G86( ) ;
      }

      protected void OnLoadActions2G86( )
      {
      }

      protected void CheckExtendedTable2G86( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002G4 */
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
         if ( ( A702SerasaAcoesValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "SERASAACOESVALOR");
            AnyError = 1;
            GX_FocusControl = edtSerasaAcoesValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2G86( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( int A662SerasaId )
      {
         /* Using cursor T002G6 */
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

      protected void GetKey2G86( )
      {
         /* Using cursor T002G7 */
         pr_default.execute(5, new Object[] {A699SerasaAcoesId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound86 = 1;
         }
         else
         {
            RcdFound86 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002G3 */
         pr_default.execute(1, new Object[] {A699SerasaAcoesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2G86( 9) ;
            RcdFound86 = 1;
            A699SerasaAcoesId = T002G3_A699SerasaAcoesId[0];
            AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
            A700SerasaAcoesData = T002G3_A700SerasaAcoesData[0];
            n700SerasaAcoesData = T002G3_n700SerasaAcoesData[0];
            AssignAttri("", false, "A700SerasaAcoesData", context.localUtil.Format(A700SerasaAcoesData, "99/99/99"));
            A701SerasaAcoesNatureza = T002G3_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = T002G3_n701SerasaAcoesNatureza[0];
            AssignAttri("", false, "A701SerasaAcoesNatureza", A701SerasaAcoesNatureza);
            A702SerasaAcoesValor = T002G3_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = T002G3_n702SerasaAcoesValor[0];
            AssignAttri("", false, "A702SerasaAcoesValor", ((Convert.ToDecimal(0)==A702SerasaAcoesValor)&&IsIns( )||n702SerasaAcoesValor ? "" : StringUtil.LTrim( StringUtil.NToC( A702SerasaAcoesValor, 18, 2, ".", ""))));
            A703SerasaAcoesDistribuidor = T002G3_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = T002G3_n703SerasaAcoesDistribuidor[0];
            AssignAttri("", false, "A703SerasaAcoesDistribuidor", A703SerasaAcoesDistribuidor);
            A704SerasaAcoesVara = T002G3_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = T002G3_n704SerasaAcoesVara[0];
            AssignAttri("", false, "A704SerasaAcoesVara", A704SerasaAcoesVara);
            A705SerasaAcoesCidade = T002G3_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = T002G3_n705SerasaAcoesCidade[0];
            AssignAttri("", false, "A705SerasaAcoesCidade", A705SerasaAcoesCidade);
            A706SerasaAcoesUF = T002G3_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = T002G3_n706SerasaAcoesUF[0];
            AssignAttri("", false, "A706SerasaAcoesUF", A706SerasaAcoesUF);
            A707SerasaAcoesPrincipal = T002G3_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = T002G3_n707SerasaAcoesPrincipal[0];
            AssignAttri("", false, "A707SerasaAcoesPrincipal", A707SerasaAcoesPrincipal);
            A708SerasaAcoesTipoMoeda = T002G3_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = T002G3_n708SerasaAcoesTipoMoeda[0];
            AssignAttri("", false, "A708SerasaAcoesTipoMoeda", A708SerasaAcoesTipoMoeda);
            A709SerasaAcoesQtdOco = T002G3_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = T002G3_n709SerasaAcoesQtdOco[0];
            AssignAttri("", false, "A709SerasaAcoesQtdOco", ((0==A709SerasaAcoesQtdOco)&&IsIns( )||n709SerasaAcoesQtdOco ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A709SerasaAcoesQtdOco), 4, 0, ".", ""))));
            A662SerasaId = T002G3_A662SerasaId[0];
            n662SerasaId = T002G3_n662SerasaId[0];
            AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            Z699SerasaAcoesId = A699SerasaAcoesId;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2G86( ) ;
            if ( AnyError == 1 )
            {
               RcdFound86 = 0;
               InitializeNonKey2G86( ) ;
            }
            Gx_mode = sMode86;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound86 = 0;
            InitializeNonKey2G86( ) ;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode86;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2G86( ) ;
         if ( RcdFound86 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound86 = 0;
         /* Using cursor T002G8 */
         pr_default.execute(6, new Object[] {A699SerasaAcoesId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T002G8_A699SerasaAcoesId[0] < A699SerasaAcoesId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T002G8_A699SerasaAcoesId[0] > A699SerasaAcoesId ) ) )
            {
               A699SerasaAcoesId = T002G8_A699SerasaAcoesId[0];
               AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
               RcdFound86 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound86 = 0;
         /* Using cursor T002G9 */
         pr_default.execute(7, new Object[] {A699SerasaAcoesId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T002G9_A699SerasaAcoesId[0] > A699SerasaAcoesId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T002G9_A699SerasaAcoesId[0] < A699SerasaAcoesId ) ) )
            {
               A699SerasaAcoesId = T002G9_A699SerasaAcoesId[0];
               AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
               RcdFound86 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2G86( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSerasaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2G86( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound86 == 1 )
            {
               if ( A699SerasaAcoesId != Z699SerasaAcoesId )
               {
                  A699SerasaAcoesId = Z699SerasaAcoesId;
                  AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SERASAACOESID");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaAcoesId_Internalname;
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
                  Update2G86( ) ;
                  GX_FocusControl = edtSerasaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A699SerasaAcoesId != Z699SerasaAcoesId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSerasaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2G86( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SERASAACOESID");
                     AnyError = 1;
                     GX_FocusControl = edtSerasaAcoesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSerasaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2G86( ) ;
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
         if ( A699SerasaAcoesId != Z699SerasaAcoesId )
         {
            A699SerasaAcoesId = Z699SerasaAcoesId;
            AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SERASAACOESID");
            AnyError = 1;
            GX_FocusControl = edtSerasaAcoesId_Internalname;
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

      protected void CheckOptimisticConcurrency2G86( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002G2 */
            pr_default.execute(0, new Object[] {A699SerasaAcoesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaAcoes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z700SerasaAcoesData ) != DateTimeUtil.ResetTime ( T002G2_A700SerasaAcoesData[0] ) ) || ( StringUtil.StrCmp(Z701SerasaAcoesNatureza, T002G2_A701SerasaAcoesNatureza[0]) != 0 ) || ( Z702SerasaAcoesValor != T002G2_A702SerasaAcoesValor[0] ) || ( StringUtil.StrCmp(Z703SerasaAcoesDistribuidor, T002G2_A703SerasaAcoesDistribuidor[0]) != 0 ) || ( StringUtil.StrCmp(Z704SerasaAcoesVara, T002G2_A704SerasaAcoesVara[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z705SerasaAcoesCidade, T002G2_A705SerasaAcoesCidade[0]) != 0 ) || ( StringUtil.StrCmp(Z706SerasaAcoesUF, T002G2_A706SerasaAcoesUF[0]) != 0 ) || ( StringUtil.StrCmp(Z707SerasaAcoesPrincipal, T002G2_A707SerasaAcoesPrincipal[0]) != 0 ) || ( StringUtil.StrCmp(Z708SerasaAcoesTipoMoeda, T002G2_A708SerasaAcoesTipoMoeda[0]) != 0 ) || ( Z709SerasaAcoesQtdOco != T002G2_A709SerasaAcoesQtdOco[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z662SerasaId != T002G2_A662SerasaId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z700SerasaAcoesData ) != DateTimeUtil.ResetTime ( T002G2_A700SerasaAcoesData[0] ) )
               {
                  GXUtil.WriteLog("serasaacoes:[seudo value changed for attri]"+"SerasaAcoesData");
                  GXUtil.WriteLogRaw("Old: ",Z700SerasaAcoesData);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A700SerasaAcoesData[0]);
               }
               if ( StringUtil.StrCmp(Z701SerasaAcoesNatureza, T002G2_A701SerasaAcoesNatureza[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaacoes:[seudo value changed for attri]"+"SerasaAcoesNatureza");
                  GXUtil.WriteLogRaw("Old: ",Z701SerasaAcoesNatureza);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A701SerasaAcoesNatureza[0]);
               }
               if ( Z702SerasaAcoesValor != T002G2_A702SerasaAcoesValor[0] )
               {
                  GXUtil.WriteLog("serasaacoes:[seudo value changed for attri]"+"SerasaAcoesValor");
                  GXUtil.WriteLogRaw("Old: ",Z702SerasaAcoesValor);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A702SerasaAcoesValor[0]);
               }
               if ( StringUtil.StrCmp(Z703SerasaAcoesDistribuidor, T002G2_A703SerasaAcoesDistribuidor[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaacoes:[seudo value changed for attri]"+"SerasaAcoesDistribuidor");
                  GXUtil.WriteLogRaw("Old: ",Z703SerasaAcoesDistribuidor);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A703SerasaAcoesDistribuidor[0]);
               }
               if ( StringUtil.StrCmp(Z704SerasaAcoesVara, T002G2_A704SerasaAcoesVara[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaacoes:[seudo value changed for attri]"+"SerasaAcoesVara");
                  GXUtil.WriteLogRaw("Old: ",Z704SerasaAcoesVara);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A704SerasaAcoesVara[0]);
               }
               if ( StringUtil.StrCmp(Z705SerasaAcoesCidade, T002G2_A705SerasaAcoesCidade[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaacoes:[seudo value changed for attri]"+"SerasaAcoesCidade");
                  GXUtil.WriteLogRaw("Old: ",Z705SerasaAcoesCidade);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A705SerasaAcoesCidade[0]);
               }
               if ( StringUtil.StrCmp(Z706SerasaAcoesUF, T002G2_A706SerasaAcoesUF[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaacoes:[seudo value changed for attri]"+"SerasaAcoesUF");
                  GXUtil.WriteLogRaw("Old: ",Z706SerasaAcoesUF);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A706SerasaAcoesUF[0]);
               }
               if ( StringUtil.StrCmp(Z707SerasaAcoesPrincipal, T002G2_A707SerasaAcoesPrincipal[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaacoes:[seudo value changed for attri]"+"SerasaAcoesPrincipal");
                  GXUtil.WriteLogRaw("Old: ",Z707SerasaAcoesPrincipal);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A707SerasaAcoesPrincipal[0]);
               }
               if ( StringUtil.StrCmp(Z708SerasaAcoesTipoMoeda, T002G2_A708SerasaAcoesTipoMoeda[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaacoes:[seudo value changed for attri]"+"SerasaAcoesTipoMoeda");
                  GXUtil.WriteLogRaw("Old: ",Z708SerasaAcoesTipoMoeda);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A708SerasaAcoesTipoMoeda[0]);
               }
               if ( Z709SerasaAcoesQtdOco != T002G2_A709SerasaAcoesQtdOco[0] )
               {
                  GXUtil.WriteLog("serasaacoes:[seudo value changed for attri]"+"SerasaAcoesQtdOco");
                  GXUtil.WriteLogRaw("Old: ",Z709SerasaAcoesQtdOco);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A709SerasaAcoesQtdOco[0]);
               }
               if ( Z662SerasaId != T002G2_A662SerasaId[0] )
               {
                  GXUtil.WriteLog("serasaacoes:[seudo value changed for attri]"+"SerasaId");
                  GXUtil.WriteLogRaw("Old: ",Z662SerasaId);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A662SerasaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SerasaAcoes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2G86( )
      {
         BeforeValidate2G86( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2G86( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2G86( 0) ;
            CheckOptimisticConcurrency2G86( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2G86( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2G86( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002G10 */
                     pr_default.execute(8, new Object[] {n700SerasaAcoesData, A700SerasaAcoesData, n701SerasaAcoesNatureza, A701SerasaAcoesNatureza, n702SerasaAcoesValor, A702SerasaAcoesValor, n703SerasaAcoesDistribuidor, A703SerasaAcoesDistribuidor, n704SerasaAcoesVara, A704SerasaAcoesVara, n705SerasaAcoesCidade, A705SerasaAcoesCidade, n706SerasaAcoesUF, A706SerasaAcoesUF, n707SerasaAcoesPrincipal, A707SerasaAcoesPrincipal, n708SerasaAcoesTipoMoeda, A708SerasaAcoesTipoMoeda, n709SerasaAcoesQtdOco, A709SerasaAcoesQtdOco, n662SerasaId, A662SerasaId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002G11 */
                     pr_default.execute(9);
                     A699SerasaAcoesId = T002G11_A699SerasaAcoesId[0];
                     AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaAcoes");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2G0( ) ;
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
               Load2G86( ) ;
            }
            EndLevel2G86( ) ;
         }
         CloseExtendedTableCursors2G86( ) ;
      }

      protected void Update2G86( )
      {
         BeforeValidate2G86( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2G86( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2G86( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2G86( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2G86( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002G12 */
                     pr_default.execute(10, new Object[] {n700SerasaAcoesData, A700SerasaAcoesData, n701SerasaAcoesNatureza, A701SerasaAcoesNatureza, n702SerasaAcoesValor, A702SerasaAcoesValor, n703SerasaAcoesDistribuidor, A703SerasaAcoesDistribuidor, n704SerasaAcoesVara, A704SerasaAcoesVara, n705SerasaAcoesCidade, A705SerasaAcoesCidade, n706SerasaAcoesUF, A706SerasaAcoesUF, n707SerasaAcoesPrincipal, A707SerasaAcoesPrincipal, n708SerasaAcoesTipoMoeda, A708SerasaAcoesTipoMoeda, n709SerasaAcoesQtdOco, A709SerasaAcoesQtdOco, n662SerasaId, A662SerasaId, A699SerasaAcoesId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaAcoes");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaAcoes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2G86( ) ;
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
            EndLevel2G86( ) ;
         }
         CloseExtendedTableCursors2G86( ) ;
      }

      protected void DeferredUpdate2G86( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2G86( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2G86( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2G86( ) ;
            AfterConfirm2G86( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2G86( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002G13 */
                  pr_default.execute(11, new Object[] {A699SerasaAcoesId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("SerasaAcoes");
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
         sMode86 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2G86( ) ;
         Gx_mode = sMode86;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2G86( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2G86( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2G86( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2G0( ) ;
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

      public void ScanStart2G86( )
      {
         /* Scan By routine */
         /* Using cursor T002G14 */
         pr_default.execute(12);
         RcdFound86 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound86 = 1;
            A699SerasaAcoesId = T002G14_A699SerasaAcoesId[0];
            AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2G86( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound86 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound86 = 1;
            A699SerasaAcoesId = T002G14_A699SerasaAcoesId[0];
            AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
         }
      }

      protected void ScanEnd2G86( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm2G86( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2G86( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2G86( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2G86( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2G86( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2G86( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2G86( )
      {
         edtSerasaAcoesId_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesId_Enabled), 5, 0), true);
         edtSerasaId_Enabled = 0;
         AssignProp("", false, edtSerasaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaId_Enabled), 5, 0), true);
         edtSerasaAcoesData_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesData_Enabled), 5, 0), true);
         edtSerasaAcoesNatureza_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesNatureza_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesNatureza_Enabled), 5, 0), true);
         edtSerasaAcoesValor_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesValor_Enabled), 5, 0), true);
         edtSerasaAcoesDistribuidor_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesDistribuidor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesDistribuidor_Enabled), 5, 0), true);
         edtSerasaAcoesVara_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesVara_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesVara_Enabled), 5, 0), true);
         edtSerasaAcoesCidade_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesCidade_Enabled), 5, 0), true);
         edtSerasaAcoesUF_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesUF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesUF_Enabled), 5, 0), true);
         edtSerasaAcoesPrincipal_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesPrincipal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesPrincipal_Enabled), 5, 0), true);
         edtSerasaAcoesTipoMoeda_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesTipoMoeda_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesTipoMoeda_Enabled), 5, 0), true);
         edtSerasaAcoesQtdOco_Enabled = 0;
         AssignProp("", false, edtSerasaAcoesQtdOco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaAcoesQtdOco_Enabled), 5, 0), true);
         edtavComboserasaid_Enabled = 0;
         AssignProp("", false, edtavComboserasaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboserasaid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2G86( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2G0( )
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
         GXEncryptionTmp = "serasaacoes"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SerasaAcoesId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("serasaacoes") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SerasaAcoes");
         forbiddenHiddens.Add("SerasaAcoesId", context.localUtil.Format( (decimal)(A699SerasaAcoesId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_SerasaId", context.localUtil.Format( (decimal)(AV11Insert_SerasaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("serasaacoes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z699SerasaAcoesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z699SerasaAcoesId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z700SerasaAcoesData", context.localUtil.DToC( Z700SerasaAcoesData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z701SerasaAcoesNatureza", Z701SerasaAcoesNatureza);
         GxWebStd.gx_hidden_field( context, "Z702SerasaAcoesValor", StringUtil.LTrim( StringUtil.NToC( Z702SerasaAcoesValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z703SerasaAcoesDistribuidor", Z703SerasaAcoesDistribuidor);
         GxWebStd.gx_hidden_field( context, "Z704SerasaAcoesVara", Z704SerasaAcoesVara);
         GxWebStd.gx_hidden_field( context, "Z705SerasaAcoesCidade", Z705SerasaAcoesCidade);
         GxWebStd.gx_hidden_field( context, "Z706SerasaAcoesUF", Z706SerasaAcoesUF);
         GxWebStd.gx_hidden_field( context, "Z707SerasaAcoesPrincipal", Z707SerasaAcoesPrincipal);
         GxWebStd.gx_hidden_field( context, "Z708SerasaAcoesTipoMoeda", Z708SerasaAcoesTipoMoeda);
         GxWebStd.gx_hidden_field( context, "Z709SerasaAcoesQtdOco", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z709SerasaAcoesQtdOco), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vSERASAACOESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SerasaAcoesId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSERASAACOESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SerasaAcoesId), "ZZZZZZZZ9"), context));
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
         GXEncryptionTmp = "serasaacoes"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SerasaAcoesId,9,0));
         return formatLink("serasaacoes") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SerasaAcoes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Serasa Acoes" ;
      }

      protected void InitializeNonKey2G86( )
      {
         A662SerasaId = 0;
         n662SerasaId = false;
         AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
         n662SerasaId = ((0==A662SerasaId) ? true : false);
         A700SerasaAcoesData = DateTime.MinValue;
         n700SerasaAcoesData = false;
         AssignAttri("", false, "A700SerasaAcoesData", context.localUtil.Format(A700SerasaAcoesData, "99/99/99"));
         n700SerasaAcoesData = ((DateTime.MinValue==A700SerasaAcoesData) ? true : false);
         A701SerasaAcoesNatureza = "";
         n701SerasaAcoesNatureza = false;
         AssignAttri("", false, "A701SerasaAcoesNatureza", A701SerasaAcoesNatureza);
         n701SerasaAcoesNatureza = (String.IsNullOrEmpty(StringUtil.RTrim( A701SerasaAcoesNatureza)) ? true : false);
         A702SerasaAcoesValor = 0;
         n702SerasaAcoesValor = false;
         AssignAttri("", false, "A702SerasaAcoesValor", ((Convert.ToDecimal(0)==A702SerasaAcoesValor)&&IsIns( )||n702SerasaAcoesValor ? "" : StringUtil.LTrim( StringUtil.NToC( A702SerasaAcoesValor, 18, 2, ".", ""))));
         n702SerasaAcoesValor = ((Convert.ToDecimal(0)==A702SerasaAcoesValor) ? true : false);
         A703SerasaAcoesDistribuidor = "";
         n703SerasaAcoesDistribuidor = false;
         AssignAttri("", false, "A703SerasaAcoesDistribuidor", A703SerasaAcoesDistribuidor);
         n703SerasaAcoesDistribuidor = (String.IsNullOrEmpty(StringUtil.RTrim( A703SerasaAcoesDistribuidor)) ? true : false);
         A704SerasaAcoesVara = "";
         n704SerasaAcoesVara = false;
         AssignAttri("", false, "A704SerasaAcoesVara", A704SerasaAcoesVara);
         n704SerasaAcoesVara = (String.IsNullOrEmpty(StringUtil.RTrim( A704SerasaAcoesVara)) ? true : false);
         A705SerasaAcoesCidade = "";
         n705SerasaAcoesCidade = false;
         AssignAttri("", false, "A705SerasaAcoesCidade", A705SerasaAcoesCidade);
         n705SerasaAcoesCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A705SerasaAcoesCidade)) ? true : false);
         A706SerasaAcoesUF = "";
         n706SerasaAcoesUF = false;
         AssignAttri("", false, "A706SerasaAcoesUF", A706SerasaAcoesUF);
         n706SerasaAcoesUF = (String.IsNullOrEmpty(StringUtil.RTrim( A706SerasaAcoesUF)) ? true : false);
         A707SerasaAcoesPrincipal = "";
         n707SerasaAcoesPrincipal = false;
         AssignAttri("", false, "A707SerasaAcoesPrincipal", A707SerasaAcoesPrincipal);
         n707SerasaAcoesPrincipal = (String.IsNullOrEmpty(StringUtil.RTrim( A707SerasaAcoesPrincipal)) ? true : false);
         A708SerasaAcoesTipoMoeda = "";
         n708SerasaAcoesTipoMoeda = false;
         AssignAttri("", false, "A708SerasaAcoesTipoMoeda", A708SerasaAcoesTipoMoeda);
         n708SerasaAcoesTipoMoeda = (String.IsNullOrEmpty(StringUtil.RTrim( A708SerasaAcoesTipoMoeda)) ? true : false);
         A709SerasaAcoesQtdOco = 0;
         n709SerasaAcoesQtdOco = false;
         AssignAttri("", false, "A709SerasaAcoesQtdOco", ((0==A709SerasaAcoesQtdOco)&&IsIns( )||n709SerasaAcoesQtdOco ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A709SerasaAcoesQtdOco), 4, 0, ".", ""))));
         n709SerasaAcoesQtdOco = ((0==A709SerasaAcoesQtdOco) ? true : false);
         Z700SerasaAcoesData = DateTime.MinValue;
         Z701SerasaAcoesNatureza = "";
         Z702SerasaAcoesValor = 0;
         Z703SerasaAcoesDistribuidor = "";
         Z704SerasaAcoesVara = "";
         Z705SerasaAcoesCidade = "";
         Z706SerasaAcoesUF = "";
         Z707SerasaAcoesPrincipal = "";
         Z708SerasaAcoesTipoMoeda = "";
         Z709SerasaAcoesQtdOco = 0;
         Z662SerasaId = 0;
      }

      protected void InitAll2G86( )
      {
         A699SerasaAcoesId = 0;
         AssignAttri("", false, "A699SerasaAcoesId", StringUtil.LTrimStr( (decimal)(A699SerasaAcoesId), 9, 0));
         InitializeNonKey2G86( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101920573", true, true);
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
         context.AddJavascriptSource("serasaacoes.js", "?20256101920573", false, true);
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
         edtSerasaAcoesId_Internalname = "SERASAACOESID";
         lblTextblockserasaid_Internalname = "TEXTBLOCKSERASAID";
         Combo_serasaid_Internalname = "COMBO_SERASAID";
         edtSerasaId_Internalname = "SERASAID";
         divTablesplittedserasaid_Internalname = "TABLESPLITTEDSERASAID";
         edtSerasaAcoesData_Internalname = "SERASAACOESDATA";
         edtSerasaAcoesNatureza_Internalname = "SERASAACOESNATUREZA";
         edtSerasaAcoesValor_Internalname = "SERASAACOESVALOR";
         edtSerasaAcoesDistribuidor_Internalname = "SERASAACOESDISTRIBUIDOR";
         edtSerasaAcoesVara_Internalname = "SERASAACOESVARA";
         edtSerasaAcoesCidade_Internalname = "SERASAACOESCIDADE";
         edtSerasaAcoesUF_Internalname = "SERASAACOESUF";
         edtSerasaAcoesPrincipal_Internalname = "SERASAACOESPRINCIPAL";
         edtSerasaAcoesTipoMoeda_Internalname = "SERASAACOESTIPOMOEDA";
         edtSerasaAcoesQtdOco_Internalname = "SERASAACOESQTDOCO";
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
         Form.Caption = "Serasa Acoes";
         edtavComboserasaid_Jsonclick = "";
         edtavComboserasaid_Enabled = 0;
         edtavComboserasaid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSerasaAcoesQtdOco_Jsonclick = "";
         edtSerasaAcoesQtdOco_Enabled = 1;
         edtSerasaAcoesTipoMoeda_Jsonclick = "";
         edtSerasaAcoesTipoMoeda_Enabled = 1;
         edtSerasaAcoesPrincipal_Jsonclick = "";
         edtSerasaAcoesPrincipal_Enabled = 1;
         edtSerasaAcoesUF_Jsonclick = "";
         edtSerasaAcoesUF_Enabled = 1;
         edtSerasaAcoesCidade_Jsonclick = "";
         edtSerasaAcoesCidade_Enabled = 1;
         edtSerasaAcoesVara_Jsonclick = "";
         edtSerasaAcoesVara_Enabled = 1;
         edtSerasaAcoesDistribuidor_Jsonclick = "";
         edtSerasaAcoesDistribuidor_Enabled = 1;
         edtSerasaAcoesValor_Jsonclick = "";
         edtSerasaAcoesValor_Enabled = 1;
         edtSerasaAcoesNatureza_Jsonclick = "";
         edtSerasaAcoesNatureza_Enabled = 1;
         edtSerasaAcoesData_Jsonclick = "";
         edtSerasaAcoesData_Enabled = 1;
         edtSerasaId_Jsonclick = "";
         edtSerasaId_Enabled = 1;
         edtSerasaId_Visible = 1;
         Combo_serasaid_Datalistprocparametersprefix = " \"ComboName\": \"SerasaId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"SerasaAcoesId\": 0";
         Combo_serasaid_Datalistproc = "SerasaAcoesLoadDVCombo";
         Combo_serasaid_Cls = "ExtendedCombo AttributeFL";
         Combo_serasaid_Caption = "";
         Combo_serasaid_Enabled = Convert.ToBoolean( -1);
         edtSerasaAcoesId_Jsonclick = "";
         edtSerasaAcoesId_Enabled = 0;
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
         /* Using cursor T002G15 */
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SerasaAcoesId","fld":"vSERASAACOESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SerasaAcoesId","fld":"vSERASAACOESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A699SerasaAcoesId","fld":"SERASAACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_SerasaId","fld":"vINSERT_SERASAID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122G2","iparms":[]}""");
         setEventMetadata("VALID_SERASAACOESID","""{"handler":"Valid_Serasaacoesid","iparms":[]}""");
         setEventMetadata("VALID_SERASAID","""{"handler":"Valid_Serasaid","iparms":[{"av":"A662SerasaId","fld":"SERASAID","pic":"ZZZZZZZZ9","nullAv":"n662SerasaId","type":"int"}]}""");
         setEventMetadata("VALID_SERASAACOESVALOR","""{"handler":"Valid_Serasaacoesvalor","iparms":[]}""");
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
         Z700SerasaAcoesData = DateTime.MinValue;
         Z701SerasaAcoesNatureza = "";
         Z703SerasaAcoesDistribuidor = "";
         Z704SerasaAcoesVara = "";
         Z705SerasaAcoesCidade = "";
         Z706SerasaAcoesUF = "";
         Z707SerasaAcoesPrincipal = "";
         Z708SerasaAcoesTipoMoeda = "";
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
         A700SerasaAcoesData = DateTime.MinValue;
         A701SerasaAcoesNatureza = "";
         A703SerasaAcoesDistribuidor = "";
         A704SerasaAcoesVara = "";
         A705SerasaAcoesCidade = "";
         A706SerasaAcoesUF = "";
         A707SerasaAcoesPrincipal = "";
         A708SerasaAcoesTipoMoeda = "";
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
         sMode86 = "";
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
         T002G5_A699SerasaAcoesId = new int[1] ;
         T002G5_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         T002G5_n700SerasaAcoesData = new bool[] {false} ;
         T002G5_A701SerasaAcoesNatureza = new string[] {""} ;
         T002G5_n701SerasaAcoesNatureza = new bool[] {false} ;
         T002G5_A702SerasaAcoesValor = new decimal[1] ;
         T002G5_n702SerasaAcoesValor = new bool[] {false} ;
         T002G5_A703SerasaAcoesDistribuidor = new string[] {""} ;
         T002G5_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         T002G5_A704SerasaAcoesVara = new string[] {""} ;
         T002G5_n704SerasaAcoesVara = new bool[] {false} ;
         T002G5_A705SerasaAcoesCidade = new string[] {""} ;
         T002G5_n705SerasaAcoesCidade = new bool[] {false} ;
         T002G5_A706SerasaAcoesUF = new string[] {""} ;
         T002G5_n706SerasaAcoesUF = new bool[] {false} ;
         T002G5_A707SerasaAcoesPrincipal = new string[] {""} ;
         T002G5_n707SerasaAcoesPrincipal = new bool[] {false} ;
         T002G5_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         T002G5_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         T002G5_A709SerasaAcoesQtdOco = new short[1] ;
         T002G5_n709SerasaAcoesQtdOco = new bool[] {false} ;
         T002G5_A662SerasaId = new int[1] ;
         T002G5_n662SerasaId = new bool[] {false} ;
         T002G4_A662SerasaId = new int[1] ;
         T002G4_n662SerasaId = new bool[] {false} ;
         T002G6_A662SerasaId = new int[1] ;
         T002G6_n662SerasaId = new bool[] {false} ;
         T002G7_A699SerasaAcoesId = new int[1] ;
         T002G3_A699SerasaAcoesId = new int[1] ;
         T002G3_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         T002G3_n700SerasaAcoesData = new bool[] {false} ;
         T002G3_A701SerasaAcoesNatureza = new string[] {""} ;
         T002G3_n701SerasaAcoesNatureza = new bool[] {false} ;
         T002G3_A702SerasaAcoesValor = new decimal[1] ;
         T002G3_n702SerasaAcoesValor = new bool[] {false} ;
         T002G3_A703SerasaAcoesDistribuidor = new string[] {""} ;
         T002G3_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         T002G3_A704SerasaAcoesVara = new string[] {""} ;
         T002G3_n704SerasaAcoesVara = new bool[] {false} ;
         T002G3_A705SerasaAcoesCidade = new string[] {""} ;
         T002G3_n705SerasaAcoesCidade = new bool[] {false} ;
         T002G3_A706SerasaAcoesUF = new string[] {""} ;
         T002G3_n706SerasaAcoesUF = new bool[] {false} ;
         T002G3_A707SerasaAcoesPrincipal = new string[] {""} ;
         T002G3_n707SerasaAcoesPrincipal = new bool[] {false} ;
         T002G3_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         T002G3_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         T002G3_A709SerasaAcoesQtdOco = new short[1] ;
         T002G3_n709SerasaAcoesQtdOco = new bool[] {false} ;
         T002G3_A662SerasaId = new int[1] ;
         T002G3_n662SerasaId = new bool[] {false} ;
         T002G8_A699SerasaAcoesId = new int[1] ;
         T002G9_A699SerasaAcoesId = new int[1] ;
         T002G2_A699SerasaAcoesId = new int[1] ;
         T002G2_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         T002G2_n700SerasaAcoesData = new bool[] {false} ;
         T002G2_A701SerasaAcoesNatureza = new string[] {""} ;
         T002G2_n701SerasaAcoesNatureza = new bool[] {false} ;
         T002G2_A702SerasaAcoesValor = new decimal[1] ;
         T002G2_n702SerasaAcoesValor = new bool[] {false} ;
         T002G2_A703SerasaAcoesDistribuidor = new string[] {""} ;
         T002G2_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         T002G2_A704SerasaAcoesVara = new string[] {""} ;
         T002G2_n704SerasaAcoesVara = new bool[] {false} ;
         T002G2_A705SerasaAcoesCidade = new string[] {""} ;
         T002G2_n705SerasaAcoesCidade = new bool[] {false} ;
         T002G2_A706SerasaAcoesUF = new string[] {""} ;
         T002G2_n706SerasaAcoesUF = new bool[] {false} ;
         T002G2_A707SerasaAcoesPrincipal = new string[] {""} ;
         T002G2_n707SerasaAcoesPrincipal = new bool[] {false} ;
         T002G2_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         T002G2_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         T002G2_A709SerasaAcoesQtdOco = new short[1] ;
         T002G2_n709SerasaAcoesQtdOco = new bool[] {false} ;
         T002G2_A662SerasaId = new int[1] ;
         T002G2_n662SerasaId = new bool[] {false} ;
         T002G11_A699SerasaAcoesId = new int[1] ;
         T002G14_A699SerasaAcoesId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T002G15_A662SerasaId = new int[1] ;
         T002G15_n662SerasaId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaacoes__default(),
            new Object[][] {
                new Object[] {
               T002G2_A699SerasaAcoesId, T002G2_A700SerasaAcoesData, T002G2_n700SerasaAcoesData, T002G2_A701SerasaAcoesNatureza, T002G2_n701SerasaAcoesNatureza, T002G2_A702SerasaAcoesValor, T002G2_n702SerasaAcoesValor, T002G2_A703SerasaAcoesDistribuidor, T002G2_n703SerasaAcoesDistribuidor, T002G2_A704SerasaAcoesVara,
               T002G2_n704SerasaAcoesVara, T002G2_A705SerasaAcoesCidade, T002G2_n705SerasaAcoesCidade, T002G2_A706SerasaAcoesUF, T002G2_n706SerasaAcoesUF, T002G2_A707SerasaAcoesPrincipal, T002G2_n707SerasaAcoesPrincipal, T002G2_A708SerasaAcoesTipoMoeda, T002G2_n708SerasaAcoesTipoMoeda, T002G2_A709SerasaAcoesQtdOco,
               T002G2_n709SerasaAcoesQtdOco, T002G2_A662SerasaId, T002G2_n662SerasaId
               }
               , new Object[] {
               T002G3_A699SerasaAcoesId, T002G3_A700SerasaAcoesData, T002G3_n700SerasaAcoesData, T002G3_A701SerasaAcoesNatureza, T002G3_n701SerasaAcoesNatureza, T002G3_A702SerasaAcoesValor, T002G3_n702SerasaAcoesValor, T002G3_A703SerasaAcoesDistribuidor, T002G3_n703SerasaAcoesDistribuidor, T002G3_A704SerasaAcoesVara,
               T002G3_n704SerasaAcoesVara, T002G3_A705SerasaAcoesCidade, T002G3_n705SerasaAcoesCidade, T002G3_A706SerasaAcoesUF, T002G3_n706SerasaAcoesUF, T002G3_A707SerasaAcoesPrincipal, T002G3_n707SerasaAcoesPrincipal, T002G3_A708SerasaAcoesTipoMoeda, T002G3_n708SerasaAcoesTipoMoeda, T002G3_A709SerasaAcoesQtdOco,
               T002G3_n709SerasaAcoesQtdOco, T002G3_A662SerasaId, T002G3_n662SerasaId
               }
               , new Object[] {
               T002G4_A662SerasaId
               }
               , new Object[] {
               T002G5_A699SerasaAcoesId, T002G5_A700SerasaAcoesData, T002G5_n700SerasaAcoesData, T002G5_A701SerasaAcoesNatureza, T002G5_n701SerasaAcoesNatureza, T002G5_A702SerasaAcoesValor, T002G5_n702SerasaAcoesValor, T002G5_A703SerasaAcoesDistribuidor, T002G5_n703SerasaAcoesDistribuidor, T002G5_A704SerasaAcoesVara,
               T002G5_n704SerasaAcoesVara, T002G5_A705SerasaAcoesCidade, T002G5_n705SerasaAcoesCidade, T002G5_A706SerasaAcoesUF, T002G5_n706SerasaAcoesUF, T002G5_A707SerasaAcoesPrincipal, T002G5_n707SerasaAcoesPrincipal, T002G5_A708SerasaAcoesTipoMoeda, T002G5_n708SerasaAcoesTipoMoeda, T002G5_A709SerasaAcoesQtdOco,
               T002G5_n709SerasaAcoesQtdOco, T002G5_A662SerasaId, T002G5_n662SerasaId
               }
               , new Object[] {
               T002G6_A662SerasaId
               }
               , new Object[] {
               T002G7_A699SerasaAcoesId
               }
               , new Object[] {
               T002G8_A699SerasaAcoesId
               }
               , new Object[] {
               T002G9_A699SerasaAcoesId
               }
               , new Object[] {
               }
               , new Object[] {
               T002G11_A699SerasaAcoesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002G14_A699SerasaAcoesId
               }
               , new Object[] {
               T002G15_A662SerasaId
               }
            }
         );
         AV19Pgmname = "SerasaAcoes";
      }

      private short Z709SerasaAcoesQtdOco ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A709SerasaAcoesQtdOco ;
      private short RcdFound86 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7SerasaAcoesId ;
      private int Z699SerasaAcoesId ;
      private int Z662SerasaId ;
      private int N662SerasaId ;
      private int A662SerasaId ;
      private int AV7SerasaAcoesId ;
      private int trnEnded ;
      private int A699SerasaAcoesId ;
      private int edtSerasaAcoesId_Enabled ;
      private int edtSerasaId_Visible ;
      private int edtSerasaId_Enabled ;
      private int edtSerasaAcoesData_Enabled ;
      private int edtSerasaAcoesNatureza_Enabled ;
      private int edtSerasaAcoesValor_Enabled ;
      private int edtSerasaAcoesDistribuidor_Enabled ;
      private int edtSerasaAcoesVara_Enabled ;
      private int edtSerasaAcoesCidade_Enabled ;
      private int edtSerasaAcoesUF_Enabled ;
      private int edtSerasaAcoesPrincipal_Enabled ;
      private int edtSerasaAcoesTipoMoeda_Enabled ;
      private int edtSerasaAcoesQtdOco_Enabled ;
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
      private decimal Z702SerasaAcoesValor ;
      private decimal A702SerasaAcoesValor ;
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
      private string edtSerasaAcoesId_Internalname ;
      private string TempTags ;
      private string edtSerasaAcoesId_Jsonclick ;
      private string divTablesplittedserasaid_Internalname ;
      private string lblTextblockserasaid_Internalname ;
      private string lblTextblockserasaid_Jsonclick ;
      private string Combo_serasaid_Caption ;
      private string Combo_serasaid_Cls ;
      private string Combo_serasaid_Datalistproc ;
      private string Combo_serasaid_Datalistprocparametersprefix ;
      private string Combo_serasaid_Internalname ;
      private string edtSerasaId_Jsonclick ;
      private string edtSerasaAcoesData_Internalname ;
      private string edtSerasaAcoesData_Jsonclick ;
      private string edtSerasaAcoesNatureza_Internalname ;
      private string edtSerasaAcoesNatureza_Jsonclick ;
      private string edtSerasaAcoesValor_Internalname ;
      private string edtSerasaAcoesValor_Jsonclick ;
      private string edtSerasaAcoesDistribuidor_Internalname ;
      private string edtSerasaAcoesDistribuidor_Jsonclick ;
      private string edtSerasaAcoesVara_Internalname ;
      private string edtSerasaAcoesVara_Jsonclick ;
      private string edtSerasaAcoesCidade_Internalname ;
      private string edtSerasaAcoesCidade_Jsonclick ;
      private string edtSerasaAcoesUF_Internalname ;
      private string edtSerasaAcoesUF_Jsonclick ;
      private string edtSerasaAcoesPrincipal_Internalname ;
      private string edtSerasaAcoesPrincipal_Jsonclick ;
      private string edtSerasaAcoesTipoMoeda_Internalname ;
      private string edtSerasaAcoesTipoMoeda_Jsonclick ;
      private string edtSerasaAcoesQtdOco_Internalname ;
      private string edtSerasaAcoesQtdOco_Jsonclick ;
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
      private string sMode86 ;
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
      private DateTime Z700SerasaAcoesData ;
      private DateTime A700SerasaAcoesData ;
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
      private bool n702SerasaAcoesValor ;
      private bool n709SerasaAcoesQtdOco ;
      private bool n700SerasaAcoesData ;
      private bool n701SerasaAcoesNatureza ;
      private bool n703SerasaAcoesDistribuidor ;
      private bool n704SerasaAcoesVara ;
      private bool n705SerasaAcoesCidade ;
      private bool n706SerasaAcoesUF ;
      private bool n707SerasaAcoesPrincipal ;
      private bool n708SerasaAcoesTipoMoeda ;
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
      private string Z701SerasaAcoesNatureza ;
      private string Z703SerasaAcoesDistribuidor ;
      private string Z704SerasaAcoesVara ;
      private string Z705SerasaAcoesCidade ;
      private string Z706SerasaAcoesUF ;
      private string Z707SerasaAcoesPrincipal ;
      private string Z708SerasaAcoesTipoMoeda ;
      private string A701SerasaAcoesNatureza ;
      private string A703SerasaAcoesDistribuidor ;
      private string A704SerasaAcoesVara ;
      private string A705SerasaAcoesCidade ;
      private string A706SerasaAcoesUF ;
      private string A707SerasaAcoesPrincipal ;
      private string A708SerasaAcoesTipoMoeda ;
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
      private int[] T002G5_A699SerasaAcoesId ;
      private DateTime[] T002G5_A700SerasaAcoesData ;
      private bool[] T002G5_n700SerasaAcoesData ;
      private string[] T002G5_A701SerasaAcoesNatureza ;
      private bool[] T002G5_n701SerasaAcoesNatureza ;
      private decimal[] T002G5_A702SerasaAcoesValor ;
      private bool[] T002G5_n702SerasaAcoesValor ;
      private string[] T002G5_A703SerasaAcoesDistribuidor ;
      private bool[] T002G5_n703SerasaAcoesDistribuidor ;
      private string[] T002G5_A704SerasaAcoesVara ;
      private bool[] T002G5_n704SerasaAcoesVara ;
      private string[] T002G5_A705SerasaAcoesCidade ;
      private bool[] T002G5_n705SerasaAcoesCidade ;
      private string[] T002G5_A706SerasaAcoesUF ;
      private bool[] T002G5_n706SerasaAcoesUF ;
      private string[] T002G5_A707SerasaAcoesPrincipal ;
      private bool[] T002G5_n707SerasaAcoesPrincipal ;
      private string[] T002G5_A708SerasaAcoesTipoMoeda ;
      private bool[] T002G5_n708SerasaAcoesTipoMoeda ;
      private short[] T002G5_A709SerasaAcoesQtdOco ;
      private bool[] T002G5_n709SerasaAcoesQtdOco ;
      private int[] T002G5_A662SerasaId ;
      private bool[] T002G5_n662SerasaId ;
      private int[] T002G4_A662SerasaId ;
      private bool[] T002G4_n662SerasaId ;
      private int[] T002G6_A662SerasaId ;
      private bool[] T002G6_n662SerasaId ;
      private int[] T002G7_A699SerasaAcoesId ;
      private int[] T002G3_A699SerasaAcoesId ;
      private DateTime[] T002G3_A700SerasaAcoesData ;
      private bool[] T002G3_n700SerasaAcoesData ;
      private string[] T002G3_A701SerasaAcoesNatureza ;
      private bool[] T002G3_n701SerasaAcoesNatureza ;
      private decimal[] T002G3_A702SerasaAcoesValor ;
      private bool[] T002G3_n702SerasaAcoesValor ;
      private string[] T002G3_A703SerasaAcoesDistribuidor ;
      private bool[] T002G3_n703SerasaAcoesDistribuidor ;
      private string[] T002G3_A704SerasaAcoesVara ;
      private bool[] T002G3_n704SerasaAcoesVara ;
      private string[] T002G3_A705SerasaAcoesCidade ;
      private bool[] T002G3_n705SerasaAcoesCidade ;
      private string[] T002G3_A706SerasaAcoesUF ;
      private bool[] T002G3_n706SerasaAcoesUF ;
      private string[] T002G3_A707SerasaAcoesPrincipal ;
      private bool[] T002G3_n707SerasaAcoesPrincipal ;
      private string[] T002G3_A708SerasaAcoesTipoMoeda ;
      private bool[] T002G3_n708SerasaAcoesTipoMoeda ;
      private short[] T002G3_A709SerasaAcoesQtdOco ;
      private bool[] T002G3_n709SerasaAcoesQtdOco ;
      private int[] T002G3_A662SerasaId ;
      private bool[] T002G3_n662SerasaId ;
      private int[] T002G8_A699SerasaAcoesId ;
      private int[] T002G9_A699SerasaAcoesId ;
      private int[] T002G2_A699SerasaAcoesId ;
      private DateTime[] T002G2_A700SerasaAcoesData ;
      private bool[] T002G2_n700SerasaAcoesData ;
      private string[] T002G2_A701SerasaAcoesNatureza ;
      private bool[] T002G2_n701SerasaAcoesNatureza ;
      private decimal[] T002G2_A702SerasaAcoesValor ;
      private bool[] T002G2_n702SerasaAcoesValor ;
      private string[] T002G2_A703SerasaAcoesDistribuidor ;
      private bool[] T002G2_n703SerasaAcoesDistribuidor ;
      private string[] T002G2_A704SerasaAcoesVara ;
      private bool[] T002G2_n704SerasaAcoesVara ;
      private string[] T002G2_A705SerasaAcoesCidade ;
      private bool[] T002G2_n705SerasaAcoesCidade ;
      private string[] T002G2_A706SerasaAcoesUF ;
      private bool[] T002G2_n706SerasaAcoesUF ;
      private string[] T002G2_A707SerasaAcoesPrincipal ;
      private bool[] T002G2_n707SerasaAcoesPrincipal ;
      private string[] T002G2_A708SerasaAcoesTipoMoeda ;
      private bool[] T002G2_n708SerasaAcoesTipoMoeda ;
      private short[] T002G2_A709SerasaAcoesQtdOco ;
      private bool[] T002G2_n709SerasaAcoesQtdOco ;
      private int[] T002G2_A662SerasaId ;
      private bool[] T002G2_n662SerasaId ;
      private int[] T002G11_A699SerasaAcoesId ;
      private int[] T002G14_A699SerasaAcoesId ;
      private int[] T002G15_A662SerasaId ;
      private bool[] T002G15_n662SerasaId ;
   }

   public class serasaacoes__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT002G2;
          prmT002G2 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmT002G3;
          prmT002G3 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmT002G4;
          prmT002G4 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002G5;
          prmT002G5 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmT002G6;
          prmT002G6 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002G7;
          prmT002G7 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmT002G8;
          prmT002G8 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmT002G9;
          prmT002G9 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmT002G10;
          prmT002G10 = new Object[] {
          new ParDef("SerasaAcoesData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaAcoesNatureza",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaAcoesValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaAcoesDistribuidor",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaAcoesVara",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesCidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesPrincipal",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesTipoMoeda",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesQtdOco",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002G11;
          prmT002G11 = new Object[] {
          };
          Object[] prmT002G12;
          prmT002G12 = new Object[] {
          new ParDef("SerasaAcoesData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaAcoesNatureza",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaAcoesValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaAcoesDistribuidor",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaAcoesVara",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesCidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesPrincipal",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesTipoMoeda",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesQtdOco",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmT002G13;
          prmT002G13 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmT002G14;
          prmT002G14 = new Object[] {
          };
          Object[] prmT002G15;
          prmT002G15 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T002G2", "SELECT SerasaAcoesId, SerasaAcoesData, SerasaAcoesNatureza, SerasaAcoesValor, SerasaAcoesDistribuidor, SerasaAcoesVara, SerasaAcoesCidade, SerasaAcoesUF, SerasaAcoesPrincipal, SerasaAcoesTipoMoeda, SerasaAcoesQtdOco, SerasaId FROM SerasaAcoes WHERE SerasaAcoesId = :SerasaAcoesId  FOR UPDATE OF SerasaAcoes NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002G2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002G3", "SELECT SerasaAcoesId, SerasaAcoesData, SerasaAcoesNatureza, SerasaAcoesValor, SerasaAcoesDistribuidor, SerasaAcoesVara, SerasaAcoesCidade, SerasaAcoesUF, SerasaAcoesPrincipal, SerasaAcoesTipoMoeda, SerasaAcoesQtdOco, SerasaId FROM SerasaAcoes WHERE SerasaAcoesId = :SerasaAcoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002G4", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002G5", "SELECT TM1.SerasaAcoesId, TM1.SerasaAcoesData, TM1.SerasaAcoesNatureza, TM1.SerasaAcoesValor, TM1.SerasaAcoesDistribuidor, TM1.SerasaAcoesVara, TM1.SerasaAcoesCidade, TM1.SerasaAcoesUF, TM1.SerasaAcoesPrincipal, TM1.SerasaAcoesTipoMoeda, TM1.SerasaAcoesQtdOco, TM1.SerasaId FROM SerasaAcoes TM1 WHERE TM1.SerasaAcoesId = :SerasaAcoesId ORDER BY TM1.SerasaAcoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002G6", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002G7", "SELECT SerasaAcoesId FROM SerasaAcoes WHERE SerasaAcoesId = :SerasaAcoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002G8", "SELECT SerasaAcoesId FROM SerasaAcoes WHERE ( SerasaAcoesId > :SerasaAcoesId) ORDER BY SerasaAcoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002G9", "SELECT SerasaAcoesId FROM SerasaAcoes WHERE ( SerasaAcoesId < :SerasaAcoesId) ORDER BY SerasaAcoesId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002G10", "SAVEPOINT gxupdate;INSERT INTO SerasaAcoes(SerasaAcoesData, SerasaAcoesNatureza, SerasaAcoesValor, SerasaAcoesDistribuidor, SerasaAcoesVara, SerasaAcoesCidade, SerasaAcoesUF, SerasaAcoesPrincipal, SerasaAcoesTipoMoeda, SerasaAcoesQtdOco, SerasaId) VALUES(:SerasaAcoesData, :SerasaAcoesNatureza, :SerasaAcoesValor, :SerasaAcoesDistribuidor, :SerasaAcoesVara, :SerasaAcoesCidade, :SerasaAcoesUF, :SerasaAcoesPrincipal, :SerasaAcoesTipoMoeda, :SerasaAcoesQtdOco, :SerasaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002G10)
             ,new CursorDef("T002G11", "SELECT currval('SerasaAcoesId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002G12", "SAVEPOINT gxupdate;UPDATE SerasaAcoes SET SerasaAcoesData=:SerasaAcoesData, SerasaAcoesNatureza=:SerasaAcoesNatureza, SerasaAcoesValor=:SerasaAcoesValor, SerasaAcoesDistribuidor=:SerasaAcoesDistribuidor, SerasaAcoesVara=:SerasaAcoesVara, SerasaAcoesCidade=:SerasaAcoesCidade, SerasaAcoesUF=:SerasaAcoesUF, SerasaAcoesPrincipal=:SerasaAcoesPrincipal, SerasaAcoesTipoMoeda=:SerasaAcoesTipoMoeda, SerasaAcoesQtdOco=:SerasaAcoesQtdOco, SerasaId=:SerasaId  WHERE SerasaAcoesId = :SerasaAcoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002G12)
             ,new CursorDef("T002G13", "SAVEPOINT gxupdate;DELETE FROM SerasaAcoes  WHERE SerasaAcoesId = :SerasaAcoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002G13)
             ,new CursorDef("T002G14", "SELECT SerasaAcoesId FROM SerasaAcoes ORDER BY SerasaAcoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002G15", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G15,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
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
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
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
