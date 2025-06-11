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
   public class serasaenderecos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
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
            gxLoad_9( A662SerasaId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "serasaenderecos")), "serasaenderecos") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "serasaenderecos")))) ;
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
                  AV7SerasaEnderecosId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaEnderecosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(AV7SerasaEnderecosId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSERASAENDERECOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SerasaEnderecosId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Serasa Enderecos", 0) ;
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

      public serasaenderecos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasaenderecos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_SerasaEnderecosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SerasaEnderecosId = aP1_SerasaEnderecosId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaEnderecosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaEnderecosId_Internalname, "Enderecos Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaEnderecosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A716SerasaEnderecosId), 9, 0, ",", "")), StringUtil.LTrim( ((edtSerasaEnderecosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A716SerasaEnderecosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A716SerasaEnderecosId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaEnderecosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaEnderecosId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SerasaEnderecos.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblockserasaid_Internalname, "Serasa", "", "", lblTextblockserasaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_SerasaEnderecos.htm");
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
         GxWebStd.gx_single_line_edit( context, edtSerasaId_Internalname, ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ",", ""))), ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A662SerasaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaId_Jsonclick, 0, "Attribute", "", "", "", "", edtSerasaId_Visible, edtSerasaId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SerasaEnderecos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaEnderecosLogr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaEnderecosLogr_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaEnderecosLogr_Internalname, A717SerasaEnderecosLogr, StringUtil.RTrim( context.localUtil.Format( A717SerasaEnderecosLogr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaEnderecosLogr_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaEnderecosLogr_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaEnderecos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaEnderecosNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaEnderecosNum_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaEnderecosNum_Internalname, A718SerasaEnderecosNum, StringUtil.RTrim( context.localUtil.Format( A718SerasaEnderecosNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaEnderecosNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaEnderecosNum_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaEnderecos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaEnderecosCompl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaEnderecosCompl_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaEnderecosCompl_Internalname, A719SerasaEnderecosCompl, StringUtil.RTrim( context.localUtil.Format( A719SerasaEnderecosCompl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaEnderecosCompl_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaEnderecosCompl_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaEnderecos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaEnderecosBairro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaEnderecosBairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaEnderecosBairro_Internalname, A720SerasaEnderecosBairro, StringUtil.RTrim( context.localUtil.Format( A720SerasaEnderecosBairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaEnderecosBairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaEnderecosBairro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaEnderecos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaEnderecosCidade_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaEnderecosCidade_Internalname, "Cidad", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaEnderecosCidade_Internalname, A721SerasaEnderecosCidade, StringUtil.RTrim( context.localUtil.Format( A721SerasaEnderecosCidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaEnderecosCidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaEnderecosCidade_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaEnderecos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaEnderecosEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaEnderecosEstado_Internalname, "Estado", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaEnderecosEstado_Internalname, A722SerasaEnderecosEstado, StringUtil.RTrim( context.localUtil.Format( A722SerasaEnderecosEstado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaEnderecosEstado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaEnderecosEstado_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaEnderecos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaEnderecosCEP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaEnderecosCEP_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaEnderecosCEP_Internalname, A723SerasaEnderecosCEP, StringUtil.RTrim( context.localUtil.Format( A723SerasaEnderecosCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaEnderecosCEP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaEnderecosCEP_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaEnderecos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaEnderecosTelDDD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaEnderecosTelDDD_Internalname, "DDD", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaEnderecosTelDDD_Internalname, A724SerasaEnderecosTelDDD, StringUtil.RTrim( context.localUtil.Format( A724SerasaEnderecosTelDDD, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaEnderecosTelDDD_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaEnderecosTelDDD_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaEnderecos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaEnderecosTel_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaEnderecosTel_Internalname, "Telefone", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaEnderecosTel_Internalname, A725SerasaEnderecosTel, StringUtil.RTrim( context.localUtil.Format( A725SerasaEnderecosTel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaEnderecosTel_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaEnderecosTel_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaEnderecos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaEnderecos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaEnderecos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SerasaEnderecos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboserasaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ComboSerasaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboserasaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ComboSerasaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV18ComboSerasaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboserasaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboserasaid_Visible, edtavComboserasaid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SerasaEnderecos.htm");
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
         E112I2 ();
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
               Z716SerasaEnderecosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z716SerasaEnderecosId"), ",", "."), 18, MidpointRounding.ToEven));
               Z717SerasaEnderecosLogr = cgiGet( "Z717SerasaEnderecosLogr");
               n717SerasaEnderecosLogr = (String.IsNullOrEmpty(StringUtil.RTrim( A717SerasaEnderecosLogr)) ? true : false);
               Z718SerasaEnderecosNum = cgiGet( "Z718SerasaEnderecosNum");
               n718SerasaEnderecosNum = (String.IsNullOrEmpty(StringUtil.RTrim( A718SerasaEnderecosNum)) ? true : false);
               Z719SerasaEnderecosCompl = cgiGet( "Z719SerasaEnderecosCompl");
               n719SerasaEnderecosCompl = (String.IsNullOrEmpty(StringUtil.RTrim( A719SerasaEnderecosCompl)) ? true : false);
               Z720SerasaEnderecosBairro = cgiGet( "Z720SerasaEnderecosBairro");
               n720SerasaEnderecosBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A720SerasaEnderecosBairro)) ? true : false);
               Z721SerasaEnderecosCidade = cgiGet( "Z721SerasaEnderecosCidade");
               n721SerasaEnderecosCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A721SerasaEnderecosCidade)) ? true : false);
               Z722SerasaEnderecosEstado = cgiGet( "Z722SerasaEnderecosEstado");
               n722SerasaEnderecosEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A722SerasaEnderecosEstado)) ? true : false);
               Z723SerasaEnderecosCEP = cgiGet( "Z723SerasaEnderecosCEP");
               n723SerasaEnderecosCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A723SerasaEnderecosCEP)) ? true : false);
               Z724SerasaEnderecosTelDDD = cgiGet( "Z724SerasaEnderecosTelDDD");
               n724SerasaEnderecosTelDDD = (String.IsNullOrEmpty(StringUtil.RTrim( A724SerasaEnderecosTelDDD)) ? true : false);
               Z725SerasaEnderecosTel = cgiGet( "Z725SerasaEnderecosTel");
               n725SerasaEnderecosTel = (String.IsNullOrEmpty(StringUtil.RTrim( A725SerasaEnderecosTel)) ? true : false);
               Z662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z662SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
               n662SerasaId = ((0==A662SerasaId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N662SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
               n662SerasaId = ((0==A662SerasaId) ? true : false);
               AV7SerasaEnderecosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vSERASAENDERECOSID"), ",", "."), 18, MidpointRounding.ToEven));
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
               A716SerasaEnderecosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaEnderecosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
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
               A717SerasaEnderecosLogr = cgiGet( edtSerasaEnderecosLogr_Internalname);
               n717SerasaEnderecosLogr = false;
               AssignAttri("", false, "A717SerasaEnderecosLogr", A717SerasaEnderecosLogr);
               n717SerasaEnderecosLogr = (String.IsNullOrEmpty(StringUtil.RTrim( A717SerasaEnderecosLogr)) ? true : false);
               A718SerasaEnderecosNum = cgiGet( edtSerasaEnderecosNum_Internalname);
               n718SerasaEnderecosNum = false;
               AssignAttri("", false, "A718SerasaEnderecosNum", A718SerasaEnderecosNum);
               n718SerasaEnderecosNum = (String.IsNullOrEmpty(StringUtil.RTrim( A718SerasaEnderecosNum)) ? true : false);
               A719SerasaEnderecosCompl = cgiGet( edtSerasaEnderecosCompl_Internalname);
               n719SerasaEnderecosCompl = false;
               AssignAttri("", false, "A719SerasaEnderecosCompl", A719SerasaEnderecosCompl);
               n719SerasaEnderecosCompl = (String.IsNullOrEmpty(StringUtil.RTrim( A719SerasaEnderecosCompl)) ? true : false);
               A720SerasaEnderecosBairro = cgiGet( edtSerasaEnderecosBairro_Internalname);
               n720SerasaEnderecosBairro = false;
               AssignAttri("", false, "A720SerasaEnderecosBairro", A720SerasaEnderecosBairro);
               n720SerasaEnderecosBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A720SerasaEnderecosBairro)) ? true : false);
               A721SerasaEnderecosCidade = cgiGet( edtSerasaEnderecosCidade_Internalname);
               n721SerasaEnderecosCidade = false;
               AssignAttri("", false, "A721SerasaEnderecosCidade", A721SerasaEnderecosCidade);
               n721SerasaEnderecosCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A721SerasaEnderecosCidade)) ? true : false);
               A722SerasaEnderecosEstado = cgiGet( edtSerasaEnderecosEstado_Internalname);
               n722SerasaEnderecosEstado = false;
               AssignAttri("", false, "A722SerasaEnderecosEstado", A722SerasaEnderecosEstado);
               n722SerasaEnderecosEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A722SerasaEnderecosEstado)) ? true : false);
               A723SerasaEnderecosCEP = cgiGet( edtSerasaEnderecosCEP_Internalname);
               n723SerasaEnderecosCEP = false;
               AssignAttri("", false, "A723SerasaEnderecosCEP", A723SerasaEnderecosCEP);
               n723SerasaEnderecosCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A723SerasaEnderecosCEP)) ? true : false);
               A724SerasaEnderecosTelDDD = cgiGet( edtSerasaEnderecosTelDDD_Internalname);
               n724SerasaEnderecosTelDDD = false;
               AssignAttri("", false, "A724SerasaEnderecosTelDDD", A724SerasaEnderecosTelDDD);
               n724SerasaEnderecosTelDDD = (String.IsNullOrEmpty(StringUtil.RTrim( A724SerasaEnderecosTelDDD)) ? true : false);
               A725SerasaEnderecosTel = cgiGet( edtSerasaEnderecosTel_Internalname);
               n725SerasaEnderecosTel = false;
               AssignAttri("", false, "A725SerasaEnderecosTel", A725SerasaEnderecosTel);
               n725SerasaEnderecosTel = (String.IsNullOrEmpty(StringUtil.RTrim( A725SerasaEnderecosTel)) ? true : false);
               AV18ComboSerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboserasaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18ComboSerasaId", StringUtil.LTrimStr( (decimal)(AV18ComboSerasaId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SerasaEnderecos");
               A716SerasaEnderecosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaEnderecosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
               forbiddenHiddens.Add("SerasaEnderecosId", context.localUtil.Format( (decimal)(A716SerasaEnderecosId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_SerasaId", context.localUtil.Format( (decimal)(AV11Insert_SerasaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A716SerasaEnderecosId != Z716SerasaEnderecosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("serasaenderecos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A716SerasaEnderecosId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaEnderecosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
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
                     sMode88 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode88;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound88 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2I0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SERASAENDERECOSID");
                        AnyError = 1;
                        GX_FocusControl = edtSerasaEnderecosId_Internalname;
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
                           E112I2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122I2 ();
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
            E122I2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2I88( ) ;
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
            DisableAttributes2I88( ) ;
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

      protected void CONFIRM_2I0( )
      {
         BeforeValidate2I88( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2I88( ) ;
            }
            else
            {
               CheckExtendedTable2I88( ) ;
               CloseExtendedTableCursors2I88( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2I0( )
      {
      }

      protected void E112I2( )
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
                     new serasaenderecosloaddvcombo(context ).execute(  "SerasaId",  "GET",  false,  AV7SerasaEnderecosId,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
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

      protected void E122I2( )
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
         new serasaenderecosloaddvcombo(context ).execute(  "SerasaId",  Gx_mode,  false,  AV7SerasaEnderecosId,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
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

      protected void ZM2I88( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z717SerasaEnderecosLogr = T002I3_A717SerasaEnderecosLogr[0];
               Z718SerasaEnderecosNum = T002I3_A718SerasaEnderecosNum[0];
               Z719SerasaEnderecosCompl = T002I3_A719SerasaEnderecosCompl[0];
               Z720SerasaEnderecosBairro = T002I3_A720SerasaEnderecosBairro[0];
               Z721SerasaEnderecosCidade = T002I3_A721SerasaEnderecosCidade[0];
               Z722SerasaEnderecosEstado = T002I3_A722SerasaEnderecosEstado[0];
               Z723SerasaEnderecosCEP = T002I3_A723SerasaEnderecosCEP[0];
               Z724SerasaEnderecosTelDDD = T002I3_A724SerasaEnderecosTelDDD[0];
               Z725SerasaEnderecosTel = T002I3_A725SerasaEnderecosTel[0];
               Z662SerasaId = T002I3_A662SerasaId[0];
            }
            else
            {
               Z717SerasaEnderecosLogr = A717SerasaEnderecosLogr;
               Z718SerasaEnderecosNum = A718SerasaEnderecosNum;
               Z719SerasaEnderecosCompl = A719SerasaEnderecosCompl;
               Z720SerasaEnderecosBairro = A720SerasaEnderecosBairro;
               Z721SerasaEnderecosCidade = A721SerasaEnderecosCidade;
               Z722SerasaEnderecosEstado = A722SerasaEnderecosEstado;
               Z723SerasaEnderecosCEP = A723SerasaEnderecosCEP;
               Z724SerasaEnderecosTelDDD = A724SerasaEnderecosTelDDD;
               Z725SerasaEnderecosTel = A725SerasaEnderecosTel;
               Z662SerasaId = A662SerasaId;
            }
         }
         if ( GX_JID == -8 )
         {
            Z716SerasaEnderecosId = A716SerasaEnderecosId;
            Z717SerasaEnderecosLogr = A717SerasaEnderecosLogr;
            Z718SerasaEnderecosNum = A718SerasaEnderecosNum;
            Z719SerasaEnderecosCompl = A719SerasaEnderecosCompl;
            Z720SerasaEnderecosBairro = A720SerasaEnderecosBairro;
            Z721SerasaEnderecosCidade = A721SerasaEnderecosCidade;
            Z722SerasaEnderecosEstado = A722SerasaEnderecosEstado;
            Z723SerasaEnderecosCEP = A723SerasaEnderecosCEP;
            Z724SerasaEnderecosTelDDD = A724SerasaEnderecosTelDDD;
            Z725SerasaEnderecosTel = A725SerasaEnderecosTel;
            Z662SerasaId = A662SerasaId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSerasaEnderecosId_Enabled = 0;
         AssignProp("", false, edtSerasaEnderecosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaEnderecosId_Enabled), 5, 0), true);
         AV19Pgmname = "SerasaEnderecos";
         AssignAttri("", false, "AV19Pgmname", AV19Pgmname);
         edtSerasaEnderecosId_Enabled = 0;
         AssignProp("", false, edtSerasaEnderecosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaEnderecosId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SerasaEnderecosId) )
         {
            A716SerasaEnderecosId = AV7SerasaEnderecosId;
            AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
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

      protected void Load2I88( )
      {
         /* Using cursor T002I5 */
         pr_default.execute(3, new Object[] {A716SerasaEnderecosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound88 = 1;
            A717SerasaEnderecosLogr = T002I5_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = T002I5_n717SerasaEnderecosLogr[0];
            AssignAttri("", false, "A717SerasaEnderecosLogr", A717SerasaEnderecosLogr);
            A718SerasaEnderecosNum = T002I5_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = T002I5_n718SerasaEnderecosNum[0];
            AssignAttri("", false, "A718SerasaEnderecosNum", A718SerasaEnderecosNum);
            A719SerasaEnderecosCompl = T002I5_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = T002I5_n719SerasaEnderecosCompl[0];
            AssignAttri("", false, "A719SerasaEnderecosCompl", A719SerasaEnderecosCompl);
            A720SerasaEnderecosBairro = T002I5_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = T002I5_n720SerasaEnderecosBairro[0];
            AssignAttri("", false, "A720SerasaEnderecosBairro", A720SerasaEnderecosBairro);
            A721SerasaEnderecosCidade = T002I5_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = T002I5_n721SerasaEnderecosCidade[0];
            AssignAttri("", false, "A721SerasaEnderecosCidade", A721SerasaEnderecosCidade);
            A722SerasaEnderecosEstado = T002I5_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = T002I5_n722SerasaEnderecosEstado[0];
            AssignAttri("", false, "A722SerasaEnderecosEstado", A722SerasaEnderecosEstado);
            A723SerasaEnderecosCEP = T002I5_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = T002I5_n723SerasaEnderecosCEP[0];
            AssignAttri("", false, "A723SerasaEnderecosCEP", A723SerasaEnderecosCEP);
            A724SerasaEnderecosTelDDD = T002I5_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = T002I5_n724SerasaEnderecosTelDDD[0];
            AssignAttri("", false, "A724SerasaEnderecosTelDDD", A724SerasaEnderecosTelDDD);
            A725SerasaEnderecosTel = T002I5_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = T002I5_n725SerasaEnderecosTel[0];
            AssignAttri("", false, "A725SerasaEnderecosTel", A725SerasaEnderecosTel);
            A662SerasaId = T002I5_A662SerasaId[0];
            n662SerasaId = T002I5_n662SerasaId[0];
            AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            ZM2I88( -8) ;
         }
         pr_default.close(3);
         OnLoadActions2I88( ) ;
      }

      protected void OnLoadActions2I88( )
      {
      }

      protected void CheckExtendedTable2I88( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002I4 */
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
      }

      protected void CloseExtendedTableCursors2I88( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( int A662SerasaId )
      {
         /* Using cursor T002I6 */
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

      protected void GetKey2I88( )
      {
         /* Using cursor T002I7 */
         pr_default.execute(5, new Object[] {A716SerasaEnderecosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound88 = 1;
         }
         else
         {
            RcdFound88 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002I3 */
         pr_default.execute(1, new Object[] {A716SerasaEnderecosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2I88( 8) ;
            RcdFound88 = 1;
            A716SerasaEnderecosId = T002I3_A716SerasaEnderecosId[0];
            AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
            A717SerasaEnderecosLogr = T002I3_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = T002I3_n717SerasaEnderecosLogr[0];
            AssignAttri("", false, "A717SerasaEnderecosLogr", A717SerasaEnderecosLogr);
            A718SerasaEnderecosNum = T002I3_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = T002I3_n718SerasaEnderecosNum[0];
            AssignAttri("", false, "A718SerasaEnderecosNum", A718SerasaEnderecosNum);
            A719SerasaEnderecosCompl = T002I3_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = T002I3_n719SerasaEnderecosCompl[0];
            AssignAttri("", false, "A719SerasaEnderecosCompl", A719SerasaEnderecosCompl);
            A720SerasaEnderecosBairro = T002I3_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = T002I3_n720SerasaEnderecosBairro[0];
            AssignAttri("", false, "A720SerasaEnderecosBairro", A720SerasaEnderecosBairro);
            A721SerasaEnderecosCidade = T002I3_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = T002I3_n721SerasaEnderecosCidade[0];
            AssignAttri("", false, "A721SerasaEnderecosCidade", A721SerasaEnderecosCidade);
            A722SerasaEnderecosEstado = T002I3_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = T002I3_n722SerasaEnderecosEstado[0];
            AssignAttri("", false, "A722SerasaEnderecosEstado", A722SerasaEnderecosEstado);
            A723SerasaEnderecosCEP = T002I3_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = T002I3_n723SerasaEnderecosCEP[0];
            AssignAttri("", false, "A723SerasaEnderecosCEP", A723SerasaEnderecosCEP);
            A724SerasaEnderecosTelDDD = T002I3_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = T002I3_n724SerasaEnderecosTelDDD[0];
            AssignAttri("", false, "A724SerasaEnderecosTelDDD", A724SerasaEnderecosTelDDD);
            A725SerasaEnderecosTel = T002I3_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = T002I3_n725SerasaEnderecosTel[0];
            AssignAttri("", false, "A725SerasaEnderecosTel", A725SerasaEnderecosTel);
            A662SerasaId = T002I3_A662SerasaId[0];
            n662SerasaId = T002I3_n662SerasaId[0];
            AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            Z716SerasaEnderecosId = A716SerasaEnderecosId;
            sMode88 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2I88( ) ;
            if ( AnyError == 1 )
            {
               RcdFound88 = 0;
               InitializeNonKey2I88( ) ;
            }
            Gx_mode = sMode88;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound88 = 0;
            InitializeNonKey2I88( ) ;
            sMode88 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode88;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2I88( ) ;
         if ( RcdFound88 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound88 = 0;
         /* Using cursor T002I8 */
         pr_default.execute(6, new Object[] {A716SerasaEnderecosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T002I8_A716SerasaEnderecosId[0] < A716SerasaEnderecosId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T002I8_A716SerasaEnderecosId[0] > A716SerasaEnderecosId ) ) )
            {
               A716SerasaEnderecosId = T002I8_A716SerasaEnderecosId[0];
               AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
               RcdFound88 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound88 = 0;
         /* Using cursor T002I9 */
         pr_default.execute(7, new Object[] {A716SerasaEnderecosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T002I9_A716SerasaEnderecosId[0] > A716SerasaEnderecosId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T002I9_A716SerasaEnderecosId[0] < A716SerasaEnderecosId ) ) )
            {
               A716SerasaEnderecosId = T002I9_A716SerasaEnderecosId[0];
               AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
               RcdFound88 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2I88( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSerasaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2I88( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound88 == 1 )
            {
               if ( A716SerasaEnderecosId != Z716SerasaEnderecosId )
               {
                  A716SerasaEnderecosId = Z716SerasaEnderecosId;
                  AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SERASAENDERECOSID");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaEnderecosId_Internalname;
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
                  Update2I88( ) ;
                  GX_FocusControl = edtSerasaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A716SerasaEnderecosId != Z716SerasaEnderecosId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSerasaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2I88( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SERASAENDERECOSID");
                     AnyError = 1;
                     GX_FocusControl = edtSerasaEnderecosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSerasaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2I88( ) ;
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
         if ( A716SerasaEnderecosId != Z716SerasaEnderecosId )
         {
            A716SerasaEnderecosId = Z716SerasaEnderecosId;
            AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SERASAENDERECOSID");
            AnyError = 1;
            GX_FocusControl = edtSerasaEnderecosId_Internalname;
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

      protected void CheckOptimisticConcurrency2I88( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002I2 */
            pr_default.execute(0, new Object[] {A716SerasaEnderecosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaEnderecos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z717SerasaEnderecosLogr, T002I2_A717SerasaEnderecosLogr[0]) != 0 ) || ( StringUtil.StrCmp(Z718SerasaEnderecosNum, T002I2_A718SerasaEnderecosNum[0]) != 0 ) || ( StringUtil.StrCmp(Z719SerasaEnderecosCompl, T002I2_A719SerasaEnderecosCompl[0]) != 0 ) || ( StringUtil.StrCmp(Z720SerasaEnderecosBairro, T002I2_A720SerasaEnderecosBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z721SerasaEnderecosCidade, T002I2_A721SerasaEnderecosCidade[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z722SerasaEnderecosEstado, T002I2_A722SerasaEnderecosEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z723SerasaEnderecosCEP, T002I2_A723SerasaEnderecosCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z724SerasaEnderecosTelDDD, T002I2_A724SerasaEnderecosTelDDD[0]) != 0 ) || ( StringUtil.StrCmp(Z725SerasaEnderecosTel, T002I2_A725SerasaEnderecosTel[0]) != 0 ) || ( Z662SerasaId != T002I2_A662SerasaId[0] ) )
            {
               if ( StringUtil.StrCmp(Z717SerasaEnderecosLogr, T002I2_A717SerasaEnderecosLogr[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaenderecos:[seudo value changed for attri]"+"SerasaEnderecosLogr");
                  GXUtil.WriteLogRaw("Old: ",Z717SerasaEnderecosLogr);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A717SerasaEnderecosLogr[0]);
               }
               if ( StringUtil.StrCmp(Z718SerasaEnderecosNum, T002I2_A718SerasaEnderecosNum[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaenderecos:[seudo value changed for attri]"+"SerasaEnderecosNum");
                  GXUtil.WriteLogRaw("Old: ",Z718SerasaEnderecosNum);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A718SerasaEnderecosNum[0]);
               }
               if ( StringUtil.StrCmp(Z719SerasaEnderecosCompl, T002I2_A719SerasaEnderecosCompl[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaenderecos:[seudo value changed for attri]"+"SerasaEnderecosCompl");
                  GXUtil.WriteLogRaw("Old: ",Z719SerasaEnderecosCompl);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A719SerasaEnderecosCompl[0]);
               }
               if ( StringUtil.StrCmp(Z720SerasaEnderecosBairro, T002I2_A720SerasaEnderecosBairro[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaenderecos:[seudo value changed for attri]"+"SerasaEnderecosBairro");
                  GXUtil.WriteLogRaw("Old: ",Z720SerasaEnderecosBairro);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A720SerasaEnderecosBairro[0]);
               }
               if ( StringUtil.StrCmp(Z721SerasaEnderecosCidade, T002I2_A721SerasaEnderecosCidade[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaenderecos:[seudo value changed for attri]"+"SerasaEnderecosCidade");
                  GXUtil.WriteLogRaw("Old: ",Z721SerasaEnderecosCidade);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A721SerasaEnderecosCidade[0]);
               }
               if ( StringUtil.StrCmp(Z722SerasaEnderecosEstado, T002I2_A722SerasaEnderecosEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaenderecos:[seudo value changed for attri]"+"SerasaEnderecosEstado");
                  GXUtil.WriteLogRaw("Old: ",Z722SerasaEnderecosEstado);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A722SerasaEnderecosEstado[0]);
               }
               if ( StringUtil.StrCmp(Z723SerasaEnderecosCEP, T002I2_A723SerasaEnderecosCEP[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaenderecos:[seudo value changed for attri]"+"SerasaEnderecosCEP");
                  GXUtil.WriteLogRaw("Old: ",Z723SerasaEnderecosCEP);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A723SerasaEnderecosCEP[0]);
               }
               if ( StringUtil.StrCmp(Z724SerasaEnderecosTelDDD, T002I2_A724SerasaEnderecosTelDDD[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaenderecos:[seudo value changed for attri]"+"SerasaEnderecosTelDDD");
                  GXUtil.WriteLogRaw("Old: ",Z724SerasaEnderecosTelDDD);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A724SerasaEnderecosTelDDD[0]);
               }
               if ( StringUtil.StrCmp(Z725SerasaEnderecosTel, T002I2_A725SerasaEnderecosTel[0]) != 0 )
               {
                  GXUtil.WriteLog("serasaenderecos:[seudo value changed for attri]"+"SerasaEnderecosTel");
                  GXUtil.WriteLogRaw("Old: ",Z725SerasaEnderecosTel);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A725SerasaEnderecosTel[0]);
               }
               if ( Z662SerasaId != T002I2_A662SerasaId[0] )
               {
                  GXUtil.WriteLog("serasaenderecos:[seudo value changed for attri]"+"SerasaId");
                  GXUtil.WriteLogRaw("Old: ",Z662SerasaId);
                  GXUtil.WriteLogRaw("Current: ",T002I2_A662SerasaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SerasaEnderecos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2I88( )
      {
         BeforeValidate2I88( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2I88( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2I88( 0) ;
            CheckOptimisticConcurrency2I88( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2I88( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2I88( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002I10 */
                     pr_default.execute(8, new Object[] {n717SerasaEnderecosLogr, A717SerasaEnderecosLogr, n718SerasaEnderecosNum, A718SerasaEnderecosNum, n719SerasaEnderecosCompl, A719SerasaEnderecosCompl, n720SerasaEnderecosBairro, A720SerasaEnderecosBairro, n721SerasaEnderecosCidade, A721SerasaEnderecosCidade, n722SerasaEnderecosEstado, A722SerasaEnderecosEstado, n723SerasaEnderecosCEP, A723SerasaEnderecosCEP, n724SerasaEnderecosTelDDD, A724SerasaEnderecosTelDDD, n725SerasaEnderecosTel, A725SerasaEnderecosTel, n662SerasaId, A662SerasaId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002I11 */
                     pr_default.execute(9);
                     A716SerasaEnderecosId = T002I11_A716SerasaEnderecosId[0];
                     AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaEnderecos");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2I0( ) ;
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
               Load2I88( ) ;
            }
            EndLevel2I88( ) ;
         }
         CloseExtendedTableCursors2I88( ) ;
      }

      protected void Update2I88( )
      {
         BeforeValidate2I88( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2I88( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2I88( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2I88( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2I88( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002I12 */
                     pr_default.execute(10, new Object[] {n717SerasaEnderecosLogr, A717SerasaEnderecosLogr, n718SerasaEnderecosNum, A718SerasaEnderecosNum, n719SerasaEnderecosCompl, A719SerasaEnderecosCompl, n720SerasaEnderecosBairro, A720SerasaEnderecosBairro, n721SerasaEnderecosCidade, A721SerasaEnderecosCidade, n722SerasaEnderecosEstado, A722SerasaEnderecosEstado, n723SerasaEnderecosCEP, A723SerasaEnderecosCEP, n724SerasaEnderecosTelDDD, A724SerasaEnderecosTelDDD, n725SerasaEnderecosTel, A725SerasaEnderecosTel, n662SerasaId, A662SerasaId, A716SerasaEnderecosId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaEnderecos");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaEnderecos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2I88( ) ;
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
            EndLevel2I88( ) ;
         }
         CloseExtendedTableCursors2I88( ) ;
      }

      protected void DeferredUpdate2I88( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2I88( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2I88( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2I88( ) ;
            AfterConfirm2I88( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2I88( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002I13 */
                  pr_default.execute(11, new Object[] {A716SerasaEnderecosId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("SerasaEnderecos");
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
         sMode88 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2I88( ) ;
         Gx_mode = sMode88;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2I88( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2I88( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2I88( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2I0( ) ;
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

      public void ScanStart2I88( )
      {
         /* Scan By routine */
         /* Using cursor T002I14 */
         pr_default.execute(12);
         RcdFound88 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound88 = 1;
            A716SerasaEnderecosId = T002I14_A716SerasaEnderecosId[0];
            AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2I88( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound88 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound88 = 1;
            A716SerasaEnderecosId = T002I14_A716SerasaEnderecosId[0];
            AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
         }
      }

      protected void ScanEnd2I88( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm2I88( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2I88( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2I88( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2I88( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2I88( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2I88( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2I88( )
      {
         edtSerasaEnderecosId_Enabled = 0;
         AssignProp("", false, edtSerasaEnderecosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaEnderecosId_Enabled), 5, 0), true);
         edtSerasaId_Enabled = 0;
         AssignProp("", false, edtSerasaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaId_Enabled), 5, 0), true);
         edtSerasaEnderecosLogr_Enabled = 0;
         AssignProp("", false, edtSerasaEnderecosLogr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaEnderecosLogr_Enabled), 5, 0), true);
         edtSerasaEnderecosNum_Enabled = 0;
         AssignProp("", false, edtSerasaEnderecosNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaEnderecosNum_Enabled), 5, 0), true);
         edtSerasaEnderecosCompl_Enabled = 0;
         AssignProp("", false, edtSerasaEnderecosCompl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaEnderecosCompl_Enabled), 5, 0), true);
         edtSerasaEnderecosBairro_Enabled = 0;
         AssignProp("", false, edtSerasaEnderecosBairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaEnderecosBairro_Enabled), 5, 0), true);
         edtSerasaEnderecosCidade_Enabled = 0;
         AssignProp("", false, edtSerasaEnderecosCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaEnderecosCidade_Enabled), 5, 0), true);
         edtSerasaEnderecosEstado_Enabled = 0;
         AssignProp("", false, edtSerasaEnderecosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaEnderecosEstado_Enabled), 5, 0), true);
         edtSerasaEnderecosCEP_Enabled = 0;
         AssignProp("", false, edtSerasaEnderecosCEP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaEnderecosCEP_Enabled), 5, 0), true);
         edtSerasaEnderecosTelDDD_Enabled = 0;
         AssignProp("", false, edtSerasaEnderecosTelDDD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaEnderecosTelDDD_Enabled), 5, 0), true);
         edtSerasaEnderecosTel_Enabled = 0;
         AssignProp("", false, edtSerasaEnderecosTel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaEnderecosTel_Enabled), 5, 0), true);
         edtavComboserasaid_Enabled = 0;
         AssignProp("", false, edtavComboserasaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboserasaid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2I88( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2I0( )
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
         GXEncryptionTmp = "serasaenderecos"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SerasaEnderecosId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("serasaenderecos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SerasaEnderecos");
         forbiddenHiddens.Add("SerasaEnderecosId", context.localUtil.Format( (decimal)(A716SerasaEnderecosId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_SerasaId", context.localUtil.Format( (decimal)(AV11Insert_SerasaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("serasaenderecos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z716SerasaEnderecosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z716SerasaEnderecosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z717SerasaEnderecosLogr", Z717SerasaEnderecosLogr);
         GxWebStd.gx_hidden_field( context, "Z718SerasaEnderecosNum", Z718SerasaEnderecosNum);
         GxWebStd.gx_hidden_field( context, "Z719SerasaEnderecosCompl", Z719SerasaEnderecosCompl);
         GxWebStd.gx_hidden_field( context, "Z720SerasaEnderecosBairro", Z720SerasaEnderecosBairro);
         GxWebStd.gx_hidden_field( context, "Z721SerasaEnderecosCidade", Z721SerasaEnderecosCidade);
         GxWebStd.gx_hidden_field( context, "Z722SerasaEnderecosEstado", Z722SerasaEnderecosEstado);
         GxWebStd.gx_hidden_field( context, "Z723SerasaEnderecosCEP", Z723SerasaEnderecosCEP);
         GxWebStd.gx_hidden_field( context, "Z724SerasaEnderecosTelDDD", Z724SerasaEnderecosTelDDD);
         GxWebStd.gx_hidden_field( context, "Z725SerasaEnderecosTel", Z725SerasaEnderecosTel);
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
         GxWebStd.gx_hidden_field( context, "vSERASAENDERECOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SerasaEnderecosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSERASAENDERECOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SerasaEnderecosId), "ZZZZZZZZ9"), context));
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
         GXEncryptionTmp = "serasaenderecos"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SerasaEnderecosId,9,0));
         return formatLink("serasaenderecos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SerasaEnderecos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Serasa Enderecos" ;
      }

      protected void InitializeNonKey2I88( )
      {
         A662SerasaId = 0;
         n662SerasaId = false;
         AssignAttri("", false, "A662SerasaId", ((0==A662SerasaId)&&IsIns( )||n662SerasaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
         n662SerasaId = ((0==A662SerasaId) ? true : false);
         A717SerasaEnderecosLogr = "";
         n717SerasaEnderecosLogr = false;
         AssignAttri("", false, "A717SerasaEnderecosLogr", A717SerasaEnderecosLogr);
         n717SerasaEnderecosLogr = (String.IsNullOrEmpty(StringUtil.RTrim( A717SerasaEnderecosLogr)) ? true : false);
         A718SerasaEnderecosNum = "";
         n718SerasaEnderecosNum = false;
         AssignAttri("", false, "A718SerasaEnderecosNum", A718SerasaEnderecosNum);
         n718SerasaEnderecosNum = (String.IsNullOrEmpty(StringUtil.RTrim( A718SerasaEnderecosNum)) ? true : false);
         A719SerasaEnderecosCompl = "";
         n719SerasaEnderecosCompl = false;
         AssignAttri("", false, "A719SerasaEnderecosCompl", A719SerasaEnderecosCompl);
         n719SerasaEnderecosCompl = (String.IsNullOrEmpty(StringUtil.RTrim( A719SerasaEnderecosCompl)) ? true : false);
         A720SerasaEnderecosBairro = "";
         n720SerasaEnderecosBairro = false;
         AssignAttri("", false, "A720SerasaEnderecosBairro", A720SerasaEnderecosBairro);
         n720SerasaEnderecosBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A720SerasaEnderecosBairro)) ? true : false);
         A721SerasaEnderecosCidade = "";
         n721SerasaEnderecosCidade = false;
         AssignAttri("", false, "A721SerasaEnderecosCidade", A721SerasaEnderecosCidade);
         n721SerasaEnderecosCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A721SerasaEnderecosCidade)) ? true : false);
         A722SerasaEnderecosEstado = "";
         n722SerasaEnderecosEstado = false;
         AssignAttri("", false, "A722SerasaEnderecosEstado", A722SerasaEnderecosEstado);
         n722SerasaEnderecosEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A722SerasaEnderecosEstado)) ? true : false);
         A723SerasaEnderecosCEP = "";
         n723SerasaEnderecosCEP = false;
         AssignAttri("", false, "A723SerasaEnderecosCEP", A723SerasaEnderecosCEP);
         n723SerasaEnderecosCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A723SerasaEnderecosCEP)) ? true : false);
         A724SerasaEnderecosTelDDD = "";
         n724SerasaEnderecosTelDDD = false;
         AssignAttri("", false, "A724SerasaEnderecosTelDDD", A724SerasaEnderecosTelDDD);
         n724SerasaEnderecosTelDDD = (String.IsNullOrEmpty(StringUtil.RTrim( A724SerasaEnderecosTelDDD)) ? true : false);
         A725SerasaEnderecosTel = "";
         n725SerasaEnderecosTel = false;
         AssignAttri("", false, "A725SerasaEnderecosTel", A725SerasaEnderecosTel);
         n725SerasaEnderecosTel = (String.IsNullOrEmpty(StringUtil.RTrim( A725SerasaEnderecosTel)) ? true : false);
         Z717SerasaEnderecosLogr = "";
         Z718SerasaEnderecosNum = "";
         Z719SerasaEnderecosCompl = "";
         Z720SerasaEnderecosBairro = "";
         Z721SerasaEnderecosCidade = "";
         Z722SerasaEnderecosEstado = "";
         Z723SerasaEnderecosCEP = "";
         Z724SerasaEnderecosTelDDD = "";
         Z725SerasaEnderecosTel = "";
         Z662SerasaId = 0;
      }

      protected void InitAll2I88( )
      {
         A716SerasaEnderecosId = 0;
         AssignAttri("", false, "A716SerasaEnderecosId", StringUtil.LTrimStr( (decimal)(A716SerasaEnderecosId), 9, 0));
         InitializeNonKey2I88( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019202435", true, true);
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
         context.AddJavascriptSource("serasaenderecos.js", "?202561019202436", false, true);
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
         edtSerasaEnderecosId_Internalname = "SERASAENDERECOSID";
         lblTextblockserasaid_Internalname = "TEXTBLOCKSERASAID";
         Combo_serasaid_Internalname = "COMBO_SERASAID";
         edtSerasaId_Internalname = "SERASAID";
         divTablesplittedserasaid_Internalname = "TABLESPLITTEDSERASAID";
         edtSerasaEnderecosLogr_Internalname = "SERASAENDERECOSLOGR";
         edtSerasaEnderecosNum_Internalname = "SERASAENDERECOSNUM";
         edtSerasaEnderecosCompl_Internalname = "SERASAENDERECOSCOMPL";
         edtSerasaEnderecosBairro_Internalname = "SERASAENDERECOSBAIRRO";
         edtSerasaEnderecosCidade_Internalname = "SERASAENDERECOSCIDADE";
         edtSerasaEnderecosEstado_Internalname = "SERASAENDERECOSESTADO";
         edtSerasaEnderecosCEP_Internalname = "SERASAENDERECOSCEP";
         edtSerasaEnderecosTelDDD_Internalname = "SERASAENDERECOSTELDDD";
         edtSerasaEnderecosTel_Internalname = "SERASAENDERECOSTEL";
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
         Form.Caption = "Serasa Enderecos";
         edtavComboserasaid_Jsonclick = "";
         edtavComboserasaid_Enabled = 0;
         edtavComboserasaid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSerasaEnderecosTel_Jsonclick = "";
         edtSerasaEnderecosTel_Enabled = 1;
         edtSerasaEnderecosTelDDD_Jsonclick = "";
         edtSerasaEnderecosTelDDD_Enabled = 1;
         edtSerasaEnderecosCEP_Jsonclick = "";
         edtSerasaEnderecosCEP_Enabled = 1;
         edtSerasaEnderecosEstado_Jsonclick = "";
         edtSerasaEnderecosEstado_Enabled = 1;
         edtSerasaEnderecosCidade_Jsonclick = "";
         edtSerasaEnderecosCidade_Enabled = 1;
         edtSerasaEnderecosBairro_Jsonclick = "";
         edtSerasaEnderecosBairro_Enabled = 1;
         edtSerasaEnderecosCompl_Jsonclick = "";
         edtSerasaEnderecosCompl_Enabled = 1;
         edtSerasaEnderecosNum_Jsonclick = "";
         edtSerasaEnderecosNum_Enabled = 1;
         edtSerasaEnderecosLogr_Jsonclick = "";
         edtSerasaEnderecosLogr_Enabled = 1;
         edtSerasaId_Jsonclick = "";
         edtSerasaId_Enabled = 1;
         edtSerasaId_Visible = 1;
         Combo_serasaid_Datalistprocparametersprefix = " \"ComboName\": \"SerasaId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"SerasaEnderecosId\": 0";
         Combo_serasaid_Datalistproc = "SerasaEnderecosLoadDVCombo";
         Combo_serasaid_Cls = "ExtendedCombo AttributeFL";
         Combo_serasaid_Caption = "";
         Combo_serasaid_Enabled = Convert.ToBoolean( -1);
         edtSerasaEnderecosId_Jsonclick = "";
         edtSerasaEnderecosId_Enabled = 0;
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
         /* Using cursor T002I15 */
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SerasaEnderecosId","fld":"vSERASAENDERECOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SerasaEnderecosId","fld":"vSERASAENDERECOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A716SerasaEnderecosId","fld":"SERASAENDERECOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_SerasaId","fld":"vINSERT_SERASAID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122I2","iparms":[]}""");
         setEventMetadata("VALID_SERASAENDERECOSID","""{"handler":"Valid_Serasaenderecosid","iparms":[]}""");
         setEventMetadata("VALID_SERASAID","""{"handler":"Valid_Serasaid","iparms":[{"av":"A662SerasaId","fld":"SERASAID","pic":"ZZZZZZZZ9","nullAv":"n662SerasaId","type":"int"}]}""");
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
         Z717SerasaEnderecosLogr = "";
         Z718SerasaEnderecosNum = "";
         Z719SerasaEnderecosCompl = "";
         Z720SerasaEnderecosBairro = "";
         Z721SerasaEnderecosCidade = "";
         Z722SerasaEnderecosEstado = "";
         Z723SerasaEnderecosCEP = "";
         Z724SerasaEnderecosTelDDD = "";
         Z725SerasaEnderecosTel = "";
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
         A717SerasaEnderecosLogr = "";
         A718SerasaEnderecosNum = "";
         A719SerasaEnderecosCompl = "";
         A720SerasaEnderecosBairro = "";
         A721SerasaEnderecosCidade = "";
         A722SerasaEnderecosEstado = "";
         A723SerasaEnderecosCEP = "";
         A724SerasaEnderecosTelDDD = "";
         A725SerasaEnderecosTel = "";
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
         sMode88 = "";
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
         T002I5_A716SerasaEnderecosId = new int[1] ;
         T002I5_A717SerasaEnderecosLogr = new string[] {""} ;
         T002I5_n717SerasaEnderecosLogr = new bool[] {false} ;
         T002I5_A718SerasaEnderecosNum = new string[] {""} ;
         T002I5_n718SerasaEnderecosNum = new bool[] {false} ;
         T002I5_A719SerasaEnderecosCompl = new string[] {""} ;
         T002I5_n719SerasaEnderecosCompl = new bool[] {false} ;
         T002I5_A720SerasaEnderecosBairro = new string[] {""} ;
         T002I5_n720SerasaEnderecosBairro = new bool[] {false} ;
         T002I5_A721SerasaEnderecosCidade = new string[] {""} ;
         T002I5_n721SerasaEnderecosCidade = new bool[] {false} ;
         T002I5_A722SerasaEnderecosEstado = new string[] {""} ;
         T002I5_n722SerasaEnderecosEstado = new bool[] {false} ;
         T002I5_A723SerasaEnderecosCEP = new string[] {""} ;
         T002I5_n723SerasaEnderecosCEP = new bool[] {false} ;
         T002I5_A724SerasaEnderecosTelDDD = new string[] {""} ;
         T002I5_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         T002I5_A725SerasaEnderecosTel = new string[] {""} ;
         T002I5_n725SerasaEnderecosTel = new bool[] {false} ;
         T002I5_A662SerasaId = new int[1] ;
         T002I5_n662SerasaId = new bool[] {false} ;
         T002I4_A662SerasaId = new int[1] ;
         T002I4_n662SerasaId = new bool[] {false} ;
         T002I6_A662SerasaId = new int[1] ;
         T002I6_n662SerasaId = new bool[] {false} ;
         T002I7_A716SerasaEnderecosId = new int[1] ;
         T002I3_A716SerasaEnderecosId = new int[1] ;
         T002I3_A717SerasaEnderecosLogr = new string[] {""} ;
         T002I3_n717SerasaEnderecosLogr = new bool[] {false} ;
         T002I3_A718SerasaEnderecosNum = new string[] {""} ;
         T002I3_n718SerasaEnderecosNum = new bool[] {false} ;
         T002I3_A719SerasaEnderecosCompl = new string[] {""} ;
         T002I3_n719SerasaEnderecosCompl = new bool[] {false} ;
         T002I3_A720SerasaEnderecosBairro = new string[] {""} ;
         T002I3_n720SerasaEnderecosBairro = new bool[] {false} ;
         T002I3_A721SerasaEnderecosCidade = new string[] {""} ;
         T002I3_n721SerasaEnderecosCidade = new bool[] {false} ;
         T002I3_A722SerasaEnderecosEstado = new string[] {""} ;
         T002I3_n722SerasaEnderecosEstado = new bool[] {false} ;
         T002I3_A723SerasaEnderecosCEP = new string[] {""} ;
         T002I3_n723SerasaEnderecosCEP = new bool[] {false} ;
         T002I3_A724SerasaEnderecosTelDDD = new string[] {""} ;
         T002I3_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         T002I3_A725SerasaEnderecosTel = new string[] {""} ;
         T002I3_n725SerasaEnderecosTel = new bool[] {false} ;
         T002I3_A662SerasaId = new int[1] ;
         T002I3_n662SerasaId = new bool[] {false} ;
         T002I8_A716SerasaEnderecosId = new int[1] ;
         T002I9_A716SerasaEnderecosId = new int[1] ;
         T002I2_A716SerasaEnderecosId = new int[1] ;
         T002I2_A717SerasaEnderecosLogr = new string[] {""} ;
         T002I2_n717SerasaEnderecosLogr = new bool[] {false} ;
         T002I2_A718SerasaEnderecosNum = new string[] {""} ;
         T002I2_n718SerasaEnderecosNum = new bool[] {false} ;
         T002I2_A719SerasaEnderecosCompl = new string[] {""} ;
         T002I2_n719SerasaEnderecosCompl = new bool[] {false} ;
         T002I2_A720SerasaEnderecosBairro = new string[] {""} ;
         T002I2_n720SerasaEnderecosBairro = new bool[] {false} ;
         T002I2_A721SerasaEnderecosCidade = new string[] {""} ;
         T002I2_n721SerasaEnderecosCidade = new bool[] {false} ;
         T002I2_A722SerasaEnderecosEstado = new string[] {""} ;
         T002I2_n722SerasaEnderecosEstado = new bool[] {false} ;
         T002I2_A723SerasaEnderecosCEP = new string[] {""} ;
         T002I2_n723SerasaEnderecosCEP = new bool[] {false} ;
         T002I2_A724SerasaEnderecosTelDDD = new string[] {""} ;
         T002I2_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         T002I2_A725SerasaEnderecosTel = new string[] {""} ;
         T002I2_n725SerasaEnderecosTel = new bool[] {false} ;
         T002I2_A662SerasaId = new int[1] ;
         T002I2_n662SerasaId = new bool[] {false} ;
         T002I11_A716SerasaEnderecosId = new int[1] ;
         T002I14_A716SerasaEnderecosId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T002I15_A662SerasaId = new int[1] ;
         T002I15_n662SerasaId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaenderecos__default(),
            new Object[][] {
                new Object[] {
               T002I2_A716SerasaEnderecosId, T002I2_A717SerasaEnderecosLogr, T002I2_n717SerasaEnderecosLogr, T002I2_A718SerasaEnderecosNum, T002I2_n718SerasaEnderecosNum, T002I2_A719SerasaEnderecosCompl, T002I2_n719SerasaEnderecosCompl, T002I2_A720SerasaEnderecosBairro, T002I2_n720SerasaEnderecosBairro, T002I2_A721SerasaEnderecosCidade,
               T002I2_n721SerasaEnderecosCidade, T002I2_A722SerasaEnderecosEstado, T002I2_n722SerasaEnderecosEstado, T002I2_A723SerasaEnderecosCEP, T002I2_n723SerasaEnderecosCEP, T002I2_A724SerasaEnderecosTelDDD, T002I2_n724SerasaEnderecosTelDDD, T002I2_A725SerasaEnderecosTel, T002I2_n725SerasaEnderecosTel, T002I2_A662SerasaId,
               T002I2_n662SerasaId
               }
               , new Object[] {
               T002I3_A716SerasaEnderecosId, T002I3_A717SerasaEnderecosLogr, T002I3_n717SerasaEnderecosLogr, T002I3_A718SerasaEnderecosNum, T002I3_n718SerasaEnderecosNum, T002I3_A719SerasaEnderecosCompl, T002I3_n719SerasaEnderecosCompl, T002I3_A720SerasaEnderecosBairro, T002I3_n720SerasaEnderecosBairro, T002I3_A721SerasaEnderecosCidade,
               T002I3_n721SerasaEnderecosCidade, T002I3_A722SerasaEnderecosEstado, T002I3_n722SerasaEnderecosEstado, T002I3_A723SerasaEnderecosCEP, T002I3_n723SerasaEnderecosCEP, T002I3_A724SerasaEnderecosTelDDD, T002I3_n724SerasaEnderecosTelDDD, T002I3_A725SerasaEnderecosTel, T002I3_n725SerasaEnderecosTel, T002I3_A662SerasaId,
               T002I3_n662SerasaId
               }
               , new Object[] {
               T002I4_A662SerasaId
               }
               , new Object[] {
               T002I5_A716SerasaEnderecosId, T002I5_A717SerasaEnderecosLogr, T002I5_n717SerasaEnderecosLogr, T002I5_A718SerasaEnderecosNum, T002I5_n718SerasaEnderecosNum, T002I5_A719SerasaEnderecosCompl, T002I5_n719SerasaEnderecosCompl, T002I5_A720SerasaEnderecosBairro, T002I5_n720SerasaEnderecosBairro, T002I5_A721SerasaEnderecosCidade,
               T002I5_n721SerasaEnderecosCidade, T002I5_A722SerasaEnderecosEstado, T002I5_n722SerasaEnderecosEstado, T002I5_A723SerasaEnderecosCEP, T002I5_n723SerasaEnderecosCEP, T002I5_A724SerasaEnderecosTelDDD, T002I5_n724SerasaEnderecosTelDDD, T002I5_A725SerasaEnderecosTel, T002I5_n725SerasaEnderecosTel, T002I5_A662SerasaId,
               T002I5_n662SerasaId
               }
               , new Object[] {
               T002I6_A662SerasaId
               }
               , new Object[] {
               T002I7_A716SerasaEnderecosId
               }
               , new Object[] {
               T002I8_A716SerasaEnderecosId
               }
               , new Object[] {
               T002I9_A716SerasaEnderecosId
               }
               , new Object[] {
               }
               , new Object[] {
               T002I11_A716SerasaEnderecosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002I14_A716SerasaEnderecosId
               }
               , new Object[] {
               T002I15_A662SerasaId
               }
            }
         );
         AV19Pgmname = "SerasaEnderecos";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound88 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7SerasaEnderecosId ;
      private int Z716SerasaEnderecosId ;
      private int Z662SerasaId ;
      private int N662SerasaId ;
      private int A662SerasaId ;
      private int AV7SerasaEnderecosId ;
      private int trnEnded ;
      private int A716SerasaEnderecosId ;
      private int edtSerasaEnderecosId_Enabled ;
      private int edtSerasaId_Visible ;
      private int edtSerasaId_Enabled ;
      private int edtSerasaEnderecosLogr_Enabled ;
      private int edtSerasaEnderecosNum_Enabled ;
      private int edtSerasaEnderecosCompl_Enabled ;
      private int edtSerasaEnderecosBairro_Enabled ;
      private int edtSerasaEnderecosCidade_Enabled ;
      private int edtSerasaEnderecosEstado_Enabled ;
      private int edtSerasaEnderecosCEP_Enabled ;
      private int edtSerasaEnderecosTelDDD_Enabled ;
      private int edtSerasaEnderecosTel_Enabled ;
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
      private string edtSerasaEnderecosId_Internalname ;
      private string TempTags ;
      private string edtSerasaEnderecosId_Jsonclick ;
      private string divTablesplittedserasaid_Internalname ;
      private string lblTextblockserasaid_Internalname ;
      private string lblTextblockserasaid_Jsonclick ;
      private string Combo_serasaid_Caption ;
      private string Combo_serasaid_Cls ;
      private string Combo_serasaid_Datalistproc ;
      private string Combo_serasaid_Datalistprocparametersprefix ;
      private string Combo_serasaid_Internalname ;
      private string edtSerasaId_Jsonclick ;
      private string edtSerasaEnderecosLogr_Internalname ;
      private string edtSerasaEnderecosLogr_Jsonclick ;
      private string edtSerasaEnderecosNum_Internalname ;
      private string edtSerasaEnderecosNum_Jsonclick ;
      private string edtSerasaEnderecosCompl_Internalname ;
      private string edtSerasaEnderecosCompl_Jsonclick ;
      private string edtSerasaEnderecosBairro_Internalname ;
      private string edtSerasaEnderecosBairro_Jsonclick ;
      private string edtSerasaEnderecosCidade_Internalname ;
      private string edtSerasaEnderecosCidade_Jsonclick ;
      private string edtSerasaEnderecosEstado_Internalname ;
      private string edtSerasaEnderecosEstado_Jsonclick ;
      private string edtSerasaEnderecosCEP_Internalname ;
      private string edtSerasaEnderecosCEP_Jsonclick ;
      private string edtSerasaEnderecosTelDDD_Internalname ;
      private string edtSerasaEnderecosTelDDD_Jsonclick ;
      private string edtSerasaEnderecosTel_Internalname ;
      private string edtSerasaEnderecosTel_Jsonclick ;
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
      private string sMode88 ;
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
      private bool n662SerasaId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n717SerasaEnderecosLogr ;
      private bool n718SerasaEnderecosNum ;
      private bool n719SerasaEnderecosCompl ;
      private bool n720SerasaEnderecosBairro ;
      private bool n721SerasaEnderecosCidade ;
      private bool n722SerasaEnderecosEstado ;
      private bool n723SerasaEnderecosCEP ;
      private bool n724SerasaEnderecosTelDDD ;
      private bool n725SerasaEnderecosTel ;
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
      private string Z717SerasaEnderecosLogr ;
      private string Z718SerasaEnderecosNum ;
      private string Z719SerasaEnderecosCompl ;
      private string Z720SerasaEnderecosBairro ;
      private string Z721SerasaEnderecosCidade ;
      private string Z722SerasaEnderecosEstado ;
      private string Z723SerasaEnderecosCEP ;
      private string Z724SerasaEnderecosTelDDD ;
      private string Z725SerasaEnderecosTel ;
      private string A717SerasaEnderecosLogr ;
      private string A718SerasaEnderecosNum ;
      private string A719SerasaEnderecosCompl ;
      private string A720SerasaEnderecosBairro ;
      private string A721SerasaEnderecosCidade ;
      private string A722SerasaEnderecosEstado ;
      private string A723SerasaEnderecosCEP ;
      private string A724SerasaEnderecosTelDDD ;
      private string A725SerasaEnderecosTel ;
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
      private int[] T002I5_A716SerasaEnderecosId ;
      private string[] T002I5_A717SerasaEnderecosLogr ;
      private bool[] T002I5_n717SerasaEnderecosLogr ;
      private string[] T002I5_A718SerasaEnderecosNum ;
      private bool[] T002I5_n718SerasaEnderecosNum ;
      private string[] T002I5_A719SerasaEnderecosCompl ;
      private bool[] T002I5_n719SerasaEnderecosCompl ;
      private string[] T002I5_A720SerasaEnderecosBairro ;
      private bool[] T002I5_n720SerasaEnderecosBairro ;
      private string[] T002I5_A721SerasaEnderecosCidade ;
      private bool[] T002I5_n721SerasaEnderecosCidade ;
      private string[] T002I5_A722SerasaEnderecosEstado ;
      private bool[] T002I5_n722SerasaEnderecosEstado ;
      private string[] T002I5_A723SerasaEnderecosCEP ;
      private bool[] T002I5_n723SerasaEnderecosCEP ;
      private string[] T002I5_A724SerasaEnderecosTelDDD ;
      private bool[] T002I5_n724SerasaEnderecosTelDDD ;
      private string[] T002I5_A725SerasaEnderecosTel ;
      private bool[] T002I5_n725SerasaEnderecosTel ;
      private int[] T002I5_A662SerasaId ;
      private bool[] T002I5_n662SerasaId ;
      private int[] T002I4_A662SerasaId ;
      private bool[] T002I4_n662SerasaId ;
      private int[] T002I6_A662SerasaId ;
      private bool[] T002I6_n662SerasaId ;
      private int[] T002I7_A716SerasaEnderecosId ;
      private int[] T002I3_A716SerasaEnderecosId ;
      private string[] T002I3_A717SerasaEnderecosLogr ;
      private bool[] T002I3_n717SerasaEnderecosLogr ;
      private string[] T002I3_A718SerasaEnderecosNum ;
      private bool[] T002I3_n718SerasaEnderecosNum ;
      private string[] T002I3_A719SerasaEnderecosCompl ;
      private bool[] T002I3_n719SerasaEnderecosCompl ;
      private string[] T002I3_A720SerasaEnderecosBairro ;
      private bool[] T002I3_n720SerasaEnderecosBairro ;
      private string[] T002I3_A721SerasaEnderecosCidade ;
      private bool[] T002I3_n721SerasaEnderecosCidade ;
      private string[] T002I3_A722SerasaEnderecosEstado ;
      private bool[] T002I3_n722SerasaEnderecosEstado ;
      private string[] T002I3_A723SerasaEnderecosCEP ;
      private bool[] T002I3_n723SerasaEnderecosCEP ;
      private string[] T002I3_A724SerasaEnderecosTelDDD ;
      private bool[] T002I3_n724SerasaEnderecosTelDDD ;
      private string[] T002I3_A725SerasaEnderecosTel ;
      private bool[] T002I3_n725SerasaEnderecosTel ;
      private int[] T002I3_A662SerasaId ;
      private bool[] T002I3_n662SerasaId ;
      private int[] T002I8_A716SerasaEnderecosId ;
      private int[] T002I9_A716SerasaEnderecosId ;
      private int[] T002I2_A716SerasaEnderecosId ;
      private string[] T002I2_A717SerasaEnderecosLogr ;
      private bool[] T002I2_n717SerasaEnderecosLogr ;
      private string[] T002I2_A718SerasaEnderecosNum ;
      private bool[] T002I2_n718SerasaEnderecosNum ;
      private string[] T002I2_A719SerasaEnderecosCompl ;
      private bool[] T002I2_n719SerasaEnderecosCompl ;
      private string[] T002I2_A720SerasaEnderecosBairro ;
      private bool[] T002I2_n720SerasaEnderecosBairro ;
      private string[] T002I2_A721SerasaEnderecosCidade ;
      private bool[] T002I2_n721SerasaEnderecosCidade ;
      private string[] T002I2_A722SerasaEnderecosEstado ;
      private bool[] T002I2_n722SerasaEnderecosEstado ;
      private string[] T002I2_A723SerasaEnderecosCEP ;
      private bool[] T002I2_n723SerasaEnderecosCEP ;
      private string[] T002I2_A724SerasaEnderecosTelDDD ;
      private bool[] T002I2_n724SerasaEnderecosTelDDD ;
      private string[] T002I2_A725SerasaEnderecosTel ;
      private bool[] T002I2_n725SerasaEnderecosTel ;
      private int[] T002I2_A662SerasaId ;
      private bool[] T002I2_n662SerasaId ;
      private int[] T002I11_A716SerasaEnderecosId ;
      private int[] T002I14_A716SerasaEnderecosId ;
      private int[] T002I15_A662SerasaId ;
      private bool[] T002I15_n662SerasaId ;
   }

   public class serasaenderecos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT002I2;
          prmT002I2 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmT002I3;
          prmT002I3 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmT002I4;
          prmT002I4 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002I5;
          prmT002I5 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmT002I6;
          prmT002I6 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002I7;
          prmT002I7 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmT002I8;
          prmT002I8 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmT002I9;
          prmT002I9 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmT002I10;
          prmT002I10 = new Object[] {
          new ParDef("SerasaEnderecosLogr",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaEnderecosNum",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosCompl",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("SerasaEnderecosBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaEnderecosCidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosEstado",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosTelDDD",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosTel",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002I11;
          prmT002I11 = new Object[] {
          };
          Object[] prmT002I12;
          prmT002I12 = new Object[] {
          new ParDef("SerasaEnderecosLogr",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaEnderecosNum",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosCompl",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("SerasaEnderecosBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaEnderecosCidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosEstado",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosTelDDD",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosTel",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmT002I13;
          prmT002I13 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmT002I14;
          prmT002I14 = new Object[] {
          };
          Object[] prmT002I15;
          prmT002I15 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T002I2", "SELECT SerasaEnderecosId, SerasaEnderecosLogr, SerasaEnderecosNum, SerasaEnderecosCompl, SerasaEnderecosBairro, SerasaEnderecosCidade, SerasaEnderecosEstado, SerasaEnderecosCEP, SerasaEnderecosTelDDD, SerasaEnderecosTel, SerasaId FROM SerasaEnderecos WHERE SerasaEnderecosId = :SerasaEnderecosId  FOR UPDATE OF SerasaEnderecos NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002I2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002I3", "SELECT SerasaEnderecosId, SerasaEnderecosLogr, SerasaEnderecosNum, SerasaEnderecosCompl, SerasaEnderecosBairro, SerasaEnderecosCidade, SerasaEnderecosEstado, SerasaEnderecosCEP, SerasaEnderecosTelDDD, SerasaEnderecosTel, SerasaId FROM SerasaEnderecos WHERE SerasaEnderecosId = :SerasaEnderecosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002I4", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002I5", "SELECT TM1.SerasaEnderecosId, TM1.SerasaEnderecosLogr, TM1.SerasaEnderecosNum, TM1.SerasaEnderecosCompl, TM1.SerasaEnderecosBairro, TM1.SerasaEnderecosCidade, TM1.SerasaEnderecosEstado, TM1.SerasaEnderecosCEP, TM1.SerasaEnderecosTelDDD, TM1.SerasaEnderecosTel, TM1.SerasaId FROM SerasaEnderecos TM1 WHERE TM1.SerasaEnderecosId = :SerasaEnderecosId ORDER BY TM1.SerasaEnderecosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002I6", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002I7", "SELECT SerasaEnderecosId FROM SerasaEnderecos WHERE SerasaEnderecosId = :SerasaEnderecosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002I8", "SELECT SerasaEnderecosId FROM SerasaEnderecos WHERE ( SerasaEnderecosId > :SerasaEnderecosId) ORDER BY SerasaEnderecosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002I9", "SELECT SerasaEnderecosId FROM SerasaEnderecos WHERE ( SerasaEnderecosId < :SerasaEnderecosId) ORDER BY SerasaEnderecosId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002I10", "SAVEPOINT gxupdate;INSERT INTO SerasaEnderecos(SerasaEnderecosLogr, SerasaEnderecosNum, SerasaEnderecosCompl, SerasaEnderecosBairro, SerasaEnderecosCidade, SerasaEnderecosEstado, SerasaEnderecosCEP, SerasaEnderecosTelDDD, SerasaEnderecosTel, SerasaId) VALUES(:SerasaEnderecosLogr, :SerasaEnderecosNum, :SerasaEnderecosCompl, :SerasaEnderecosBairro, :SerasaEnderecosCidade, :SerasaEnderecosEstado, :SerasaEnderecosCEP, :SerasaEnderecosTelDDD, :SerasaEnderecosTel, :SerasaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002I10)
             ,new CursorDef("T002I11", "SELECT currval('SerasaEnderecosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002I12", "SAVEPOINT gxupdate;UPDATE SerasaEnderecos SET SerasaEnderecosLogr=:SerasaEnderecosLogr, SerasaEnderecosNum=:SerasaEnderecosNum, SerasaEnderecosCompl=:SerasaEnderecosCompl, SerasaEnderecosBairro=:SerasaEnderecosBairro, SerasaEnderecosCidade=:SerasaEnderecosCidade, SerasaEnderecosEstado=:SerasaEnderecosEstado, SerasaEnderecosCEP=:SerasaEnderecosCEP, SerasaEnderecosTelDDD=:SerasaEnderecosTelDDD, SerasaEnderecosTel=:SerasaEnderecosTel, SerasaId=:SerasaId  WHERE SerasaEnderecosId = :SerasaEnderecosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002I12)
             ,new CursorDef("T002I13", "SAVEPOINT gxupdate;DELETE FROM SerasaEnderecos  WHERE SerasaEnderecosId = :SerasaEnderecosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002I13)
             ,new CursorDef("T002I14", "SELECT SerasaEnderecosId FROM SerasaEnderecos ORDER BY SerasaEnderecosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002I15", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002I15,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
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
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
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
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
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
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
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
