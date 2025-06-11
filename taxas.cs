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
   public class taxas : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
         {
            A868TaxasCreatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "TaxasCreatedBy"), "."), 18, MidpointRounding.ToEven));
            n868TaxasCreatedBy = false;
            AssignAttri("", false, "A868TaxasCreatedBy", ((0==A868TaxasCreatedBy)&&IsIns( )||n868TaxasCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A868TaxasCreatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_25( A868TaxasCreatedBy) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_26") == 0 )
         {
            A869TaxasUpdatedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "TaxasUpdatedBy"), "."), 18, MidpointRounding.ToEven));
            n869TaxasUpdatedBy = false;
            AssignAttri("", false, "A869TaxasUpdatedBy", ((0==A869TaxasUpdatedBy)&&IsIns( )||n869TaxasUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A869TaxasUpdatedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_26( A869TaxasUpdatedBy) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "taxas")), "taxas") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "taxas")))) ;
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
                  AV7TaxasId = (int)(Math.Round(NumberUtil.Val( GetPar( "TaxasId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7TaxasId", StringUtil.LTrimStr( (decimal)(AV7TaxasId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTAXASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TaxasId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Taxas", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTaxasPercentual_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public taxas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public taxas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TaxasId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TaxasId = aP1_TaxasId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblLblmessage_Internalname, lblLblmessage_Caption, "", "", lblLblmessage_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Taxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTaxasPercentual_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTaxasPercentual_Internalname, "Taxa de administração", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTaxasPercentual_Internalname, ((Convert.ToDecimal(0)==A864TaxasPercentual)&&IsIns( )||n864TaxasPercentual ? "" : StringUtil.LTrim( StringUtil.NToC( A864TaxasPercentual, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A864TaxasPercentual)&&IsIns( )||n864TaxasPercentual ? "" : StringUtil.LTrim( ((edtTaxasPercentual_Enabled!=0) ? context.localUtil.Format( A864TaxasPercentual, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A864TaxasPercentual, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTaxasPercentual_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTaxasPercentual_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_Taxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTaxasPercentualAnual_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTaxasPercentualAnual_Internalname, "Taxa % Anual", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTaxasPercentualAnual_Internalname, ((Convert.ToDecimal(0)==A894TaxasPercentualAnual)&&IsIns( )||n894TaxasPercentualAnual ? "" : StringUtil.LTrim( StringUtil.NToC( A894TaxasPercentualAnual, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A894TaxasPercentualAnual)&&IsIns( )||n894TaxasPercentualAnual ? "" : StringUtil.LTrim( ((edtTaxasPercentualAnual_Enabled!=0) ? context.localUtil.Format( A894TaxasPercentualAnual, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A894TaxasPercentualAnual, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTaxasPercentualAnual_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTaxasPercentualAnual_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_Taxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTaxasValorMinimo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTaxasValorMinimo_Internalname, "Valor Mínimo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTaxasValorMinimo_Internalname, ((Convert.ToDecimal(0)==A865TaxasValorMinimo)&&IsIns( )||n865TaxasValorMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A865TaxasValorMinimo, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A865TaxasValorMinimo)&&IsIns( )||n865TaxasValorMinimo ? "" : StringUtil.LTrim( ((edtTaxasValorMinimo_Enabled!=0) ? context.localUtil.Format( A865TaxasValorMinimo, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A865TaxasValorMinimo, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTaxasValorMinimo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTaxasValorMinimo_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Taxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedtaxascreatedat_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTextblocktaxascreatedat_cell_Internalname, 1, 0, "px", 0, "px", divTextblocktaxascreatedat_cell_Class, "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktaxascreatedat_Internalname, "Criado em", "", "", lblTextblocktaxascreatedat_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Taxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedtaxascreatedat_Internalname, tblTablemergedtaxascreatedat_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td id=\""+cellTaxascreatedat_cell_Internalname+"\"  class='"+cellTaxascreatedat_cell_Class+"'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTaxasCreatedAt_Internalname, "Taxas Created At", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTaxasCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTaxasCreatedAt_Internalname, context.localUtil.TToC( A866TaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A866TaxasCreatedAt, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTaxasCreatedAt_Jsonclick, 0, "AttributeFL", "", "", "", "", edtTaxasCreatedAt_Visible, edtTaxasCreatedAt_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Taxas.htm");
         GxWebStd.gx_bitmap( context, edtTaxasCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTaxasCreatedAt_Visible==0)||(edtTaxasCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Taxas.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td id=\""+cellTaxascreatedname_cell_Internalname+"\"  class='"+cellTaxascreatedname_cell_Class+"'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtTaxasCreatedName_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtTaxasCreatedName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTaxasCreatedName_Internalname, "Por", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTaxasCreatedName_Internalname, A872TaxasCreatedName, StringUtil.RTrim( context.localUtil.Format( A872TaxasCreatedName, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTaxasCreatedName_Jsonclick, 0, "AttributeFL", "", "", "", "", edtTaxasCreatedName_Visible, edtTaxasCreatedName_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Taxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
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
         GxWebStd.gx_div_start( context, divTablesplittedtaxasupdatedat_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTextblocktaxasupdatedat_cell_Internalname, 1, 0, "px", 0, "px", divTextblocktaxasupdatedat_cell_Class, "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktaxasupdatedat_Internalname, "Atualizado em", "", "", lblTextblocktaxasupdatedat_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Taxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedtaxasupdatedat_Internalname, tblTablemergedtaxasupdatedat_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td id=\""+cellTaxasupdatedat_cell_Internalname+"\"  class='"+cellTaxasupdatedat_cell_Class+"'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTaxasUpdatedAt_Internalname, "Taxas Updated At", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTaxasUpdatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTaxasUpdatedAt_Internalname, context.localUtil.TToC( A867TaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A867TaxasUpdatedAt, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTaxasUpdatedAt_Jsonclick, 0, "AttributeFL", "", "", "", "", edtTaxasUpdatedAt_Visible, edtTaxasUpdatedAt_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Taxas.htm");
         GxWebStd.gx_bitmap( context, edtTaxasUpdatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTaxasUpdatedAt_Visible==0)||(edtTaxasUpdatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Taxas.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td id=\""+cellTaxasupdatedname_cell_Internalname+"\"  class='"+cellTaxasupdatedname_cell_Class+"'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtTaxasUpdatedName_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtTaxasUpdatedName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTaxasUpdatedName_Internalname, "Por", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTaxasUpdatedName_Internalname, A873TaxasUpdatedName, StringUtil.RTrim( context.localUtil.Format( A873TaxasUpdatedName, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTaxasUpdatedName_Jsonclick, 0, "AttributeFL", "", "", "", "", edtTaxasUpdatedName_Visible, edtTaxasUpdatedName_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Taxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Taxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Taxas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Taxas.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTaxasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A863TaxasId), 9, 0, ",", "")), StringUtil.LTrim( ((edtTaxasId_Enabled!=0) ? context.localUtil.Format( (decimal)(A863TaxasId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A863TaxasId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTaxasId_Jsonclick, 0, "Attribute", "", "", "", "", edtTaxasId_Visible, edtTaxasId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Taxas.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTaxasCreatedBy_Internalname, ((0==A868TaxasCreatedBy)&&IsIns( )||n868TaxasCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A868TaxasCreatedBy), 4, 0, ",", ""))), ((0==A868TaxasCreatedBy)&&IsIns( )||n868TaxasCreatedBy ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A868TaxasCreatedBy), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTaxasCreatedBy_Jsonclick, 0, "Attribute", "", "", "", "", edtTaxasCreatedBy_Visible, edtTaxasCreatedBy_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Taxas.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTaxasUpdatedBy_Internalname, ((0==A869TaxasUpdatedBy)&&IsIns( )||n869TaxasUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A869TaxasUpdatedBy), 4, 0, ",", ""))), ((0==A869TaxasUpdatedBy)&&IsIns( )||n869TaxasUpdatedBy ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A869TaxasUpdatedBy), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTaxasUpdatedBy_Jsonclick, 0, "Attribute", "", "", "", "", edtTaxasUpdatedBy_Visible, edtTaxasUpdatedBy_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Taxas.htm");
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
         E112Q2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z863TaxasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z863TaxasId"), ",", "."), 18, MidpointRounding.ToEven));
               Z866TaxasCreatedAt = context.localUtil.CToT( cgiGet( "Z866TaxasCreatedAt"), 0);
               n866TaxasCreatedAt = ((DateTime.MinValue==A866TaxasCreatedAt) ? true : false);
               Z867TaxasUpdatedAt = context.localUtil.CToT( cgiGet( "Z867TaxasUpdatedAt"), 0);
               n867TaxasUpdatedAt = ((DateTime.MinValue==A867TaxasUpdatedAt) ? true : false);
               Z864TaxasPercentual = context.localUtil.CToN( cgiGet( "Z864TaxasPercentual"), ",", ".");
               n864TaxasPercentual = ((Convert.ToDecimal(0)==A864TaxasPercentual) ? true : false);
               Z894TaxasPercentualAnual = context.localUtil.CToN( cgiGet( "Z894TaxasPercentualAnual"), ",", ".");
               n894TaxasPercentualAnual = ((Convert.ToDecimal(0)==A894TaxasPercentualAnual) ? true : false);
               Z865TaxasValorMinimo = context.localUtil.CToN( cgiGet( "Z865TaxasValorMinimo"), ",", ".");
               n865TaxasValorMinimo = ((Convert.ToDecimal(0)==A865TaxasValorMinimo) ? true : false);
               Z868TaxasCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z868TaxasCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n868TaxasCreatedBy = ((0==A868TaxasCreatedBy) ? true : false);
               Z869TaxasUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z869TaxasUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n869TaxasUpdatedBy = ((0==A869TaxasUpdatedBy) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N868TaxasCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N868TaxasCreatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n868TaxasCreatedBy = ((0==A868TaxasCreatedBy) ? true : false);
               N869TaxasUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N869TaxasUpdatedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n869TaxasUpdatedBy = ((0==A869TaxasUpdatedBy) ? true : false);
               AV7TaxasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vTAXASID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_TaxasCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TAXASCREATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_TaxasCreatedBy", StringUtil.LTrimStr( (decimal)(AV11Insert_TaxasCreatedBy), 4, 0));
               AV12Insert_TaxasUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TAXASUPDATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_TaxasUpdatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_TaxasUpdatedBy), 4, 0));
               AV24Pgmname = cgiGet( "vPGMNAME");
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
               n864TaxasPercentual = ((StringUtil.StrCmp(cgiGet( edtTaxasPercentual_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTaxasPercentual_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTaxasPercentual_Internalname), ",", ".") > 99999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TAXASPERCENTUAL");
                  AnyError = 1;
                  GX_FocusControl = edtTaxasPercentual_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A864TaxasPercentual = 0;
                  n864TaxasPercentual = false;
                  AssignAttri("", false, "A864TaxasPercentual", (n864TaxasPercentual ? "" : StringUtil.LTrim( StringUtil.NToC( A864TaxasPercentual, 16, 4, ".", ""))));
               }
               else
               {
                  A864TaxasPercentual = context.localUtil.CToN( cgiGet( edtTaxasPercentual_Internalname), ",", ".");
                  AssignAttri("", false, "A864TaxasPercentual", (n864TaxasPercentual ? "" : StringUtil.LTrim( StringUtil.NToC( A864TaxasPercentual, 16, 4, ".", ""))));
               }
               n894TaxasPercentualAnual = ((StringUtil.StrCmp(cgiGet( edtTaxasPercentualAnual_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTaxasPercentualAnual_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTaxasPercentualAnual_Internalname), ",", ".") > 99999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TAXASPERCENTUALANUAL");
                  AnyError = 1;
                  GX_FocusControl = edtTaxasPercentualAnual_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A894TaxasPercentualAnual = 0;
                  n894TaxasPercentualAnual = false;
                  AssignAttri("", false, "A894TaxasPercentualAnual", (n894TaxasPercentualAnual ? "" : StringUtil.LTrim( StringUtil.NToC( A894TaxasPercentualAnual, 16, 4, ".", ""))));
               }
               else
               {
                  A894TaxasPercentualAnual = context.localUtil.CToN( cgiGet( edtTaxasPercentualAnual_Internalname), ",", ".");
                  AssignAttri("", false, "A894TaxasPercentualAnual", (n894TaxasPercentualAnual ? "" : StringUtil.LTrim( StringUtil.NToC( A894TaxasPercentualAnual, 16, 4, ".", ""))));
               }
               n865TaxasValorMinimo = ((StringUtil.StrCmp(cgiGet( edtTaxasValorMinimo_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTaxasValorMinimo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTaxasValorMinimo_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TAXASVALORMINIMO");
                  AnyError = 1;
                  GX_FocusControl = edtTaxasValorMinimo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A865TaxasValorMinimo = 0;
                  n865TaxasValorMinimo = false;
                  AssignAttri("", false, "A865TaxasValorMinimo", (n865TaxasValorMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A865TaxasValorMinimo, 18, 2, ".", ""))));
               }
               else
               {
                  A865TaxasValorMinimo = context.localUtil.CToN( cgiGet( edtTaxasValorMinimo_Internalname), ",", ".");
                  AssignAttri("", false, "A865TaxasValorMinimo", (n865TaxasValorMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A865TaxasValorMinimo, 18, 2, ".", ""))));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtTaxasCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Taxas Created At"}), 1, "TAXASCREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtTaxasCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A866TaxasCreatedAt = (DateTime)(DateTime.MinValue);
                  n866TaxasCreatedAt = false;
                  AssignAttri("", false, "A866TaxasCreatedAt", context.localUtil.TToC( A866TaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A866TaxasCreatedAt = context.localUtil.CToT( cgiGet( edtTaxasCreatedAt_Internalname));
                  n866TaxasCreatedAt = false;
                  AssignAttri("", false, "A866TaxasCreatedAt", context.localUtil.TToC( A866TaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "));
               }
               n866TaxasCreatedAt = ((DateTime.MinValue==A866TaxasCreatedAt) ? true : false);
               A872TaxasCreatedName = StringUtil.Upper( cgiGet( edtTaxasCreatedName_Internalname));
               n872TaxasCreatedName = false;
               AssignAttri("", false, "A872TaxasCreatedName", A872TaxasCreatedName);
               if ( context.localUtil.VCDateTime( cgiGet( edtTaxasUpdatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Taxas Updated At"}), 1, "TAXASUPDATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtTaxasUpdatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A867TaxasUpdatedAt = (DateTime)(DateTime.MinValue);
                  n867TaxasUpdatedAt = false;
                  AssignAttri("", false, "A867TaxasUpdatedAt", context.localUtil.TToC( A867TaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A867TaxasUpdatedAt = context.localUtil.CToT( cgiGet( edtTaxasUpdatedAt_Internalname));
                  n867TaxasUpdatedAt = false;
                  AssignAttri("", false, "A867TaxasUpdatedAt", context.localUtil.TToC( A867TaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
               }
               n867TaxasUpdatedAt = ((DateTime.MinValue==A867TaxasUpdatedAt) ? true : false);
               A873TaxasUpdatedName = StringUtil.Upper( cgiGet( edtTaxasUpdatedName_Internalname));
               n873TaxasUpdatedName = false;
               AssignAttri("", false, "A873TaxasUpdatedName", A873TaxasUpdatedName);
               A863TaxasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTaxasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
               n868TaxasCreatedBy = ((StringUtil.StrCmp(cgiGet( edtTaxasCreatedBy_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTaxasCreatedBy_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTaxasCreatedBy_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TAXASCREATEDBY");
                  AnyError = 1;
                  GX_FocusControl = edtTaxasCreatedBy_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A868TaxasCreatedBy = 0;
                  n868TaxasCreatedBy = false;
                  AssignAttri("", false, "A868TaxasCreatedBy", (n868TaxasCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A868TaxasCreatedBy), 4, 0, ".", ""))));
               }
               else
               {
                  A868TaxasCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTaxasCreatedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A868TaxasCreatedBy", (n868TaxasCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A868TaxasCreatedBy), 4, 0, ".", ""))));
               }
               n869TaxasUpdatedBy = ((StringUtil.StrCmp(cgiGet( edtTaxasUpdatedBy_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTaxasUpdatedBy_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTaxasUpdatedBy_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TAXASUPDATEDBY");
                  AnyError = 1;
                  GX_FocusControl = edtTaxasUpdatedBy_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A869TaxasUpdatedBy = 0;
                  n869TaxasUpdatedBy = false;
                  AssignAttri("", false, "A869TaxasUpdatedBy", (n869TaxasUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A869TaxasUpdatedBy), 4, 0, ".", ""))));
               }
               else
               {
                  A869TaxasUpdatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTaxasUpdatedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A869TaxasUpdatedBy", (n869TaxasUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A869TaxasUpdatedBy), 4, 0, ".", ""))));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Taxas");
               A863TaxasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTaxasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
               forbiddenHiddens.Add("TaxasId", context.localUtil.Format( (decimal)(A863TaxasId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_TaxasCreatedBy", context.localUtil.Format( (decimal)(AV11Insert_TaxasCreatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Insert_TaxasUpdatedBy", context.localUtil.Format( (decimal)(AV12Insert_TaxasUpdatedBy), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A863TaxasId != Z863TaxasId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("taxas:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A863TaxasId = (int)(Math.Round(NumberUtil.Val( GetPar( "TaxasId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
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
                     sMode96 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode96;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound96 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2Q0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TAXASID");
                        AnyError = 1;
                        GX_FocusControl = edtTaxasId_Internalname;
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
                           E112Q2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122Q2 ();
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
            E122Q2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2Q96( ) ;
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
            DisableAttributes2Q96( ) ;
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

      protected void CONFIRM_2Q0( )
      {
         BeforeValidate2Q96( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2Q96( ) ;
            }
            else
            {
               CheckExtendedTable2Q96( ) ;
               CloseExtendedTableCursors2Q96( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2Q0( )
      {
      }

      protected void E112Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
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
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TaxasCreatedBy") == 0 )
               {
                  AV11Insert_TaxasCreatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_TaxasCreatedBy", StringUtil.LTrimStr( (decimal)(AV11Insert_TaxasCreatedBy), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TaxasUpdatedBy") == 0 )
               {
                  AV12Insert_TaxasUpdatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_TaxasUpdatedBy", StringUtil.LTrimStr( (decimal)(AV12Insert_TaxasUpdatedBy), 4, 0));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
               AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            }
         }
         edtTaxasId_Visible = 0;
         AssignProp("", false, edtTaxasId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTaxasId_Visible), 5, 0), true);
         edtTaxasCreatedBy_Visible = 0;
         AssignProp("", false, edtTaxasCreatedBy_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTaxasCreatedBy_Visible), 5, 0), true);
         edtTaxasUpdatedBy_Visible = 0;
         AssignProp("", false, edtTaxasUpdatedBy_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTaxasUpdatedBy_Visible), 5, 0), true);
         AV23HTML += "<div style=\"font-family: Arial, sans-serif; max-width: 800px; margin: 10px auto; padding: 15px; border: 1px solid #e0e0e0; border-radius: 5px; background-color: #f9f9f9; box-shadow: 0 2px 5px rgba(0,0,0,0.1)\">";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "<div style=\"border-left: 4px solid #08A086; padding-left: 15px; margin-bottom: 15px\">";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "<h3 style=\"color: #08A086; margin-top: 0; font-size: 18px\">Orientações para preenchimento</h3>";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "</div>";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "<ul style=\"list-style-type: none; padding-left: 5px; margin: 0\">";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "<li style=\"margin-bottom: 12px; padding-left: 10px; border-left: 3px solid #08A086\">";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "<div><strong style=\"color: #333\">Taxa de administração:</strong> ";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "<span style=\"color: #555\">Esta taxa é aplicada sobre o valor total. Se o valor for definido como 0 (zero), nenhuma taxa de administração será aplicada.</span>";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "</div></li>";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "<li style=\"margin-bottom: 12px; padding-left: 10px; border-left: 3px solid #08A086\">";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "<div><strong style=\"color: #333\">Taxa % Anual:</strong> ";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "<span style=\"color: #555\">Esta taxa é aplicada sobre o valor total e calculada proporcionalmente ao período. Por exemplo, para uma taxa anual de 12%, o cálculo será: (1 + 0,12)^(dias/365), onde \"dias\" representa o período em dias.</span>";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "</div></li>";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "<li style=\"margin-bottom: 12px; padding-left: 10px; border-left: 3px solid #08A086\">";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "<div><strong style=\"color: #333\">Valor Mínimo:</strong> ";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "<span style=\"color: #555\">Se o valor for definido como 0 (zero), não será estabelecido um valor mínimo para a operação.</span>";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "</div></li>";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "</ul>";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         AV23HTML += "</div>";
         AssignAttri("", false, "AV23HTML", AV23HTML);
         lblLblmessage_Caption = AV23HTML;
         AssignProp("", false, lblLblmessage_Internalname, "Caption", lblLblmessage_Caption, true);
      }

      protected void E122Q2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("taxasww") );
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
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         edtTaxasCreatedAt_Visible = 0;
         AssignProp("", false, edtTaxasCreatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTaxasCreatedAt_Visible), 5, 0), true);
         cellTaxascreatedat_cell_Class = "Invisible";
         AssignProp("", false, cellTaxascreatedat_cell_Internalname, "Class", cellTaxascreatedat_cell_Class, true);
         divTextblocktaxascreatedat_cell_Class = "Invisible";
         AssignProp("", false, divTextblocktaxascreatedat_cell_Internalname, "Class", divTextblocktaxascreatedat_cell_Class, true);
         edtTaxasCreatedName_Visible = 0;
         AssignProp("", false, edtTaxasCreatedName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTaxasCreatedName_Visible), 5, 0), true);
         cellTaxascreatedname_cell_Class = "Invisible";
         AssignProp("", false, cellTaxascreatedname_cell_Internalname, "Class", cellTaxascreatedname_cell_Class, true);
         edtTaxasUpdatedAt_Visible = 0;
         AssignProp("", false, edtTaxasUpdatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTaxasUpdatedAt_Visible), 5, 0), true);
         cellTaxasupdatedat_cell_Class = "Invisible";
         AssignProp("", false, cellTaxasupdatedat_cell_Internalname, "Class", cellTaxasupdatedat_cell_Class, true);
         divTextblocktaxasupdatedat_cell_Class = "Invisible";
         AssignProp("", false, divTextblocktaxasupdatedat_cell_Internalname, "Class", divTextblocktaxasupdatedat_cell_Class, true);
         edtTaxasUpdatedName_Visible = 0;
         AssignProp("", false, edtTaxasUpdatedName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTaxasUpdatedName_Visible), 5, 0), true);
         cellTaxasupdatedname_cell_Class = "Invisible";
         AssignProp("", false, cellTaxasupdatedname_cell_Internalname, "Class", cellTaxasupdatedname_cell_Class, true);
      }

      protected void ZM2Q96( short GX_JID )
      {
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z866TaxasCreatedAt = T002Q3_A866TaxasCreatedAt[0];
               Z867TaxasUpdatedAt = T002Q3_A867TaxasUpdatedAt[0];
               Z864TaxasPercentual = T002Q3_A864TaxasPercentual[0];
               Z894TaxasPercentualAnual = T002Q3_A894TaxasPercentualAnual[0];
               Z865TaxasValorMinimo = T002Q3_A865TaxasValorMinimo[0];
               Z868TaxasCreatedBy = T002Q3_A868TaxasCreatedBy[0];
               Z869TaxasUpdatedBy = T002Q3_A869TaxasUpdatedBy[0];
            }
            else
            {
               Z866TaxasCreatedAt = A866TaxasCreatedAt;
               Z867TaxasUpdatedAt = A867TaxasUpdatedAt;
               Z864TaxasPercentual = A864TaxasPercentual;
               Z894TaxasPercentualAnual = A894TaxasPercentualAnual;
               Z865TaxasValorMinimo = A865TaxasValorMinimo;
               Z868TaxasCreatedBy = A868TaxasCreatedBy;
               Z869TaxasUpdatedBy = A869TaxasUpdatedBy;
            }
         }
         if ( GX_JID == -24 )
         {
            Z863TaxasId = A863TaxasId;
            Z866TaxasCreatedAt = A866TaxasCreatedAt;
            Z867TaxasUpdatedAt = A867TaxasUpdatedAt;
            Z864TaxasPercentual = A864TaxasPercentual;
            Z894TaxasPercentualAnual = A894TaxasPercentualAnual;
            Z865TaxasValorMinimo = A865TaxasValorMinimo;
            Z868TaxasCreatedBy = A868TaxasCreatedBy;
            Z869TaxasUpdatedBy = A869TaxasUpdatedBy;
            Z872TaxasCreatedName = A872TaxasCreatedName;
            Z873TaxasUpdatedName = A873TaxasUpdatedName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTaxasId_Enabled = 0;
         AssignProp("", false, edtTaxasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasId_Enabled), 5, 0), true);
         edtTaxasCreatedAt_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? 1 : 0);
         AssignProp("", false, edtTaxasCreatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTaxasCreatedAt_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) )
         {
            cellTaxascreatedat_cell_Class = "Invisible";
            AssignProp("", false, cellTaxascreatedat_cell_Internalname, "Class", cellTaxascreatedat_cell_Class, true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
            {
               cellTaxascreatedat_cell_Class = "MergeDataCell";
               AssignProp("", false, cellTaxascreatedat_cell_Internalname, "Class", cellTaxascreatedat_cell_Class, true);
            }
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) )
         {
            divTextblocktaxascreatedat_cell_Class = "Invisible";
            AssignProp("", false, divTextblocktaxascreatedat_cell_Internalname, "Class", divTextblocktaxascreatedat_cell_Class, true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
            {
               divTextblocktaxascreatedat_cell_Class = "col-sm-3 MergeLabelCell";
               AssignProp("", false, divTextblocktaxascreatedat_cell_Internalname, "Class", divTextblocktaxascreatedat_cell_Class, true);
            }
         }
         edtTaxasCreatedName_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? 1 : 0);
         AssignProp("", false, edtTaxasCreatedName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTaxasCreatedName_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) )
         {
            cellTaxascreatedname_cell_Class = "Invisible";
            AssignProp("", false, cellTaxascreatedname_cell_Internalname, "Class", cellTaxascreatedname_cell_Class, true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
            {
               cellTaxascreatedname_cell_Class = "DataContentCellFL";
               AssignProp("", false, cellTaxascreatedname_cell_Internalname, "Class", cellTaxascreatedname_cell_Class, true);
            }
         }
         edtTaxasUpdatedAt_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? 1 : 0);
         AssignProp("", false, edtTaxasUpdatedAt_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTaxasUpdatedAt_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) )
         {
            cellTaxasupdatedat_cell_Class = "Invisible";
            AssignProp("", false, cellTaxasupdatedat_cell_Internalname, "Class", cellTaxasupdatedat_cell_Class, true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
            {
               cellTaxasupdatedat_cell_Class = "MergeDataCell";
               AssignProp("", false, cellTaxasupdatedat_cell_Internalname, "Class", cellTaxasupdatedat_cell_Class, true);
            }
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) )
         {
            divTextblocktaxasupdatedat_cell_Class = "Invisible";
            AssignProp("", false, divTextblocktaxasupdatedat_cell_Internalname, "Class", divTextblocktaxasupdatedat_cell_Class, true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
            {
               divTextblocktaxasupdatedat_cell_Class = "col-sm-3 MergeLabelCell";
               AssignProp("", false, divTextblocktaxasupdatedat_cell_Internalname, "Class", divTextblocktaxasupdatedat_cell_Class, true);
            }
         }
         edtTaxasUpdatedName_Visible = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? 1 : 0);
         AssignProp("", false, edtTaxasUpdatedName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTaxasUpdatedName_Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) )
         {
            cellTaxasupdatedname_cell_Class = "Invisible";
            AssignProp("", false, cellTaxasupdatedname_cell_Internalname, "Class", cellTaxasupdatedname_cell_Class, true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
            {
               cellTaxasupdatedname_cell_Class = "DataContentCellFL";
               AssignProp("", false, cellTaxasupdatedname_cell_Internalname, "Class", cellTaxasupdatedname_cell_Class, true);
            }
         }
         AV24Pgmname = "Taxas";
         AssignAttri("", false, "AV24Pgmname", AV24Pgmname);
         edtTaxasId_Enabled = 0;
         AssignProp("", false, edtTaxasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TaxasId) )
         {
            A863TaxasId = AV7TaxasId;
            AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_TaxasCreatedBy) )
         {
            edtTaxasCreatedBy_Enabled = 0;
            AssignProp("", false, edtTaxasCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasCreatedBy_Enabled), 5, 0), true);
         }
         else
         {
            edtTaxasCreatedBy_Enabled = 1;
            AssignProp("", false, edtTaxasCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasCreatedBy_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TaxasUpdatedBy) )
         {
            edtTaxasUpdatedBy_Enabled = 0;
            AssignProp("", false, edtTaxasUpdatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasUpdatedBy_Enabled), 5, 0), true);
         }
         else
         {
            edtTaxasUpdatedBy_Enabled = 1;
            AssignProp("", false, edtTaxasUpdatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasUpdatedBy_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A866TaxasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n866TaxasCreatedAt = false;
            AssignAttri("", false, "A866TaxasCreatedAt", context.localUtil.TToC( A866TaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         }
         if ( IsUpd( )  )
         {
            A867TaxasUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n867TaxasUpdatedAt = false;
            AssignAttri("", false, "A867TaxasUpdatedAt", context.localUtil.TToC( A867TaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_TaxasCreatedBy) )
         {
            A868TaxasCreatedBy = AV11Insert_TaxasCreatedBy;
            n868TaxasCreatedBy = false;
            AssignAttri("", false, "A868TaxasCreatedBy", ((0==A868TaxasCreatedBy)&&IsIns( )||n868TaxasCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A868TaxasCreatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( IsIns( )  )
            {
               A868TaxasCreatedBy = AV8WWPContext.gxTpr_Userid;
               n868TaxasCreatedBy = false;
               AssignAttri("", false, "A868TaxasCreatedBy", ((0==A868TaxasCreatedBy)&&IsIns( )||n868TaxasCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A868TaxasCreatedBy), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TaxasUpdatedBy) )
         {
            A869TaxasUpdatedBy = AV12Insert_TaxasUpdatedBy;
            n869TaxasUpdatedBy = false;
            AssignAttri("", false, "A869TaxasUpdatedBy", ((0==A869TaxasUpdatedBy)&&IsIns( )||n869TaxasUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A869TaxasUpdatedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A869TaxasUpdatedBy = AV8WWPContext.gxTpr_Userid;
               n869TaxasUpdatedBy = false;
               AssignAttri("", false, "A869TaxasUpdatedBy", ((0==A869TaxasUpdatedBy)&&IsIns( )||n869TaxasUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A869TaxasUpdatedBy), 4, 0, ".", ""))));
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
            /* Using cursor T002Q4 */
            pr_default.execute(2, new Object[] {n868TaxasCreatedBy, A868TaxasCreatedBy});
            A872TaxasCreatedName = T002Q4_A872TaxasCreatedName[0];
            n872TaxasCreatedName = T002Q4_n872TaxasCreatedName[0];
            AssignAttri("", false, "A872TaxasCreatedName", A872TaxasCreatedName);
            pr_default.close(2);
            /* Using cursor T002Q5 */
            pr_default.execute(3, new Object[] {n869TaxasUpdatedBy, A869TaxasUpdatedBy});
            A873TaxasUpdatedName = T002Q5_A873TaxasUpdatedName[0];
            n873TaxasUpdatedName = T002Q5_n873TaxasUpdatedName[0];
            AssignAttri("", false, "A873TaxasUpdatedName", A873TaxasUpdatedName);
            pr_default.close(3);
         }
      }

      protected void Load2Q96( )
      {
         /* Using cursor T002Q6 */
         pr_default.execute(4, new Object[] {A863TaxasId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound96 = 1;
            A866TaxasCreatedAt = T002Q6_A866TaxasCreatedAt[0];
            n866TaxasCreatedAt = T002Q6_n866TaxasCreatedAt[0];
            AssignAttri("", false, "A866TaxasCreatedAt", context.localUtil.TToC( A866TaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "));
            A867TaxasUpdatedAt = T002Q6_A867TaxasUpdatedAt[0];
            n867TaxasUpdatedAt = T002Q6_n867TaxasUpdatedAt[0];
            AssignAttri("", false, "A867TaxasUpdatedAt", context.localUtil.TToC( A867TaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
            A864TaxasPercentual = T002Q6_A864TaxasPercentual[0];
            n864TaxasPercentual = T002Q6_n864TaxasPercentual[0];
            AssignAttri("", false, "A864TaxasPercentual", ((Convert.ToDecimal(0)==A864TaxasPercentual)&&IsIns( )||n864TaxasPercentual ? "" : StringUtil.LTrim( StringUtil.NToC( A864TaxasPercentual, 16, 4, ".", ""))));
            A894TaxasPercentualAnual = T002Q6_A894TaxasPercentualAnual[0];
            n894TaxasPercentualAnual = T002Q6_n894TaxasPercentualAnual[0];
            AssignAttri("", false, "A894TaxasPercentualAnual", ((Convert.ToDecimal(0)==A894TaxasPercentualAnual)&&IsIns( )||n894TaxasPercentualAnual ? "" : StringUtil.LTrim( StringUtil.NToC( A894TaxasPercentualAnual, 16, 4, ".", ""))));
            A865TaxasValorMinimo = T002Q6_A865TaxasValorMinimo[0];
            n865TaxasValorMinimo = T002Q6_n865TaxasValorMinimo[0];
            AssignAttri("", false, "A865TaxasValorMinimo", ((Convert.ToDecimal(0)==A865TaxasValorMinimo)&&IsIns( )||n865TaxasValorMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A865TaxasValorMinimo, 18, 2, ".", ""))));
            A872TaxasCreatedName = T002Q6_A872TaxasCreatedName[0];
            n872TaxasCreatedName = T002Q6_n872TaxasCreatedName[0];
            AssignAttri("", false, "A872TaxasCreatedName", A872TaxasCreatedName);
            A873TaxasUpdatedName = T002Q6_A873TaxasUpdatedName[0];
            n873TaxasUpdatedName = T002Q6_n873TaxasUpdatedName[0];
            AssignAttri("", false, "A873TaxasUpdatedName", A873TaxasUpdatedName);
            A868TaxasCreatedBy = T002Q6_A868TaxasCreatedBy[0];
            n868TaxasCreatedBy = T002Q6_n868TaxasCreatedBy[0];
            AssignAttri("", false, "A868TaxasCreatedBy", ((0==A868TaxasCreatedBy)&&IsIns( )||n868TaxasCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A868TaxasCreatedBy), 4, 0, ".", ""))));
            A869TaxasUpdatedBy = T002Q6_A869TaxasUpdatedBy[0];
            n869TaxasUpdatedBy = T002Q6_n869TaxasUpdatedBy[0];
            AssignAttri("", false, "A869TaxasUpdatedBy", ((0==A869TaxasUpdatedBy)&&IsIns( )||n869TaxasUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A869TaxasUpdatedBy), 4, 0, ".", ""))));
            ZM2Q96( -24) ;
         }
         pr_default.close(4);
         OnLoadActions2Q96( ) ;
      }

      protected void OnLoadActions2Q96( )
      {
      }

      protected void CheckExtendedTable2Q96( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ( A865TaxasValorMinimo < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "TAXASVALORMINIMO");
            AnyError = 1;
            GX_FocusControl = edtTaxasValorMinimo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002Q4 */
         pr_default.execute(2, new Object[] {n868TaxasCreatedBy, A868TaxasCreatedBy});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A868TaxasCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Taxas Created By'.", "ForeignKeyNotFound", 1, "TAXASCREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtTaxasCreatedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A872TaxasCreatedName = T002Q4_A872TaxasCreatedName[0];
         n872TaxasCreatedName = T002Q4_n872TaxasCreatedName[0];
         AssignAttri("", false, "A872TaxasCreatedName", A872TaxasCreatedName);
         pr_default.close(2);
         /* Using cursor T002Q5 */
         pr_default.execute(3, new Object[] {n869TaxasUpdatedBy, A869TaxasUpdatedBy});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A869TaxasUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Taxas Updated By'.", "ForeignKeyNotFound", 1, "TAXASUPDATEDBY");
               AnyError = 1;
               GX_FocusControl = edtTaxasUpdatedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A873TaxasUpdatedName = T002Q5_A873TaxasUpdatedName[0];
         n873TaxasUpdatedName = T002Q5_n873TaxasUpdatedName[0];
         AssignAttri("", false, "A873TaxasUpdatedName", A873TaxasUpdatedName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2Q96( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_25( short A868TaxasCreatedBy )
      {
         /* Using cursor T002Q7 */
         pr_default.execute(5, new Object[] {n868TaxasCreatedBy, A868TaxasCreatedBy});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A868TaxasCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Taxas Created By'.", "ForeignKeyNotFound", 1, "TAXASCREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtTaxasCreatedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A872TaxasCreatedName = T002Q7_A872TaxasCreatedName[0];
         n872TaxasCreatedName = T002Q7_n872TaxasCreatedName[0];
         AssignAttri("", false, "A872TaxasCreatedName", A872TaxasCreatedName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A872TaxasCreatedName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_26( short A869TaxasUpdatedBy )
      {
         /* Using cursor T002Q8 */
         pr_default.execute(6, new Object[] {n869TaxasUpdatedBy, A869TaxasUpdatedBy});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A869TaxasUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Taxas Updated By'.", "ForeignKeyNotFound", 1, "TAXASUPDATEDBY");
               AnyError = 1;
               GX_FocusControl = edtTaxasUpdatedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A873TaxasUpdatedName = T002Q8_A873TaxasUpdatedName[0];
         n873TaxasUpdatedName = T002Q8_n873TaxasUpdatedName[0];
         AssignAttri("", false, "A873TaxasUpdatedName", A873TaxasUpdatedName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A873TaxasUpdatedName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey2Q96( )
      {
         /* Using cursor T002Q9 */
         pr_default.execute(7, new Object[] {A863TaxasId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound96 = 1;
         }
         else
         {
            RcdFound96 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002Q3 */
         pr_default.execute(1, new Object[] {A863TaxasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2Q96( 24) ;
            RcdFound96 = 1;
            A863TaxasId = T002Q3_A863TaxasId[0];
            AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
            A866TaxasCreatedAt = T002Q3_A866TaxasCreatedAt[0];
            n866TaxasCreatedAt = T002Q3_n866TaxasCreatedAt[0];
            AssignAttri("", false, "A866TaxasCreatedAt", context.localUtil.TToC( A866TaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "));
            A867TaxasUpdatedAt = T002Q3_A867TaxasUpdatedAt[0];
            n867TaxasUpdatedAt = T002Q3_n867TaxasUpdatedAt[0];
            AssignAttri("", false, "A867TaxasUpdatedAt", context.localUtil.TToC( A867TaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
            A864TaxasPercentual = T002Q3_A864TaxasPercentual[0];
            n864TaxasPercentual = T002Q3_n864TaxasPercentual[0];
            AssignAttri("", false, "A864TaxasPercentual", ((Convert.ToDecimal(0)==A864TaxasPercentual)&&IsIns( )||n864TaxasPercentual ? "" : StringUtil.LTrim( StringUtil.NToC( A864TaxasPercentual, 16, 4, ".", ""))));
            A894TaxasPercentualAnual = T002Q3_A894TaxasPercentualAnual[0];
            n894TaxasPercentualAnual = T002Q3_n894TaxasPercentualAnual[0];
            AssignAttri("", false, "A894TaxasPercentualAnual", ((Convert.ToDecimal(0)==A894TaxasPercentualAnual)&&IsIns( )||n894TaxasPercentualAnual ? "" : StringUtil.LTrim( StringUtil.NToC( A894TaxasPercentualAnual, 16, 4, ".", ""))));
            A865TaxasValorMinimo = T002Q3_A865TaxasValorMinimo[0];
            n865TaxasValorMinimo = T002Q3_n865TaxasValorMinimo[0];
            AssignAttri("", false, "A865TaxasValorMinimo", ((Convert.ToDecimal(0)==A865TaxasValorMinimo)&&IsIns( )||n865TaxasValorMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A865TaxasValorMinimo, 18, 2, ".", ""))));
            A868TaxasCreatedBy = T002Q3_A868TaxasCreatedBy[0];
            n868TaxasCreatedBy = T002Q3_n868TaxasCreatedBy[0];
            AssignAttri("", false, "A868TaxasCreatedBy", ((0==A868TaxasCreatedBy)&&IsIns( )||n868TaxasCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A868TaxasCreatedBy), 4, 0, ".", ""))));
            A869TaxasUpdatedBy = T002Q3_A869TaxasUpdatedBy[0];
            n869TaxasUpdatedBy = T002Q3_n869TaxasUpdatedBy[0];
            AssignAttri("", false, "A869TaxasUpdatedBy", ((0==A869TaxasUpdatedBy)&&IsIns( )||n869TaxasUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A869TaxasUpdatedBy), 4, 0, ".", ""))));
            Z863TaxasId = A863TaxasId;
            sMode96 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2Q96( ) ;
            if ( AnyError == 1 )
            {
               RcdFound96 = 0;
               InitializeNonKey2Q96( ) ;
            }
            Gx_mode = sMode96;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound96 = 0;
            InitializeNonKey2Q96( ) ;
            sMode96 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode96;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2Q96( ) ;
         if ( RcdFound96 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound96 = 0;
         /* Using cursor T002Q10 */
         pr_default.execute(8, new Object[] {A863TaxasId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T002Q10_A863TaxasId[0] < A863TaxasId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T002Q10_A863TaxasId[0] > A863TaxasId ) ) )
            {
               A863TaxasId = T002Q10_A863TaxasId[0];
               AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
               RcdFound96 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound96 = 0;
         /* Using cursor T002Q11 */
         pr_default.execute(9, new Object[] {A863TaxasId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002Q11_A863TaxasId[0] > A863TaxasId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002Q11_A863TaxasId[0] < A863TaxasId ) ) )
            {
               A863TaxasId = T002Q11_A863TaxasId[0];
               AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
               RcdFound96 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2Q96( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTaxasPercentual_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2Q96( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound96 == 1 )
            {
               if ( A863TaxasId != Z863TaxasId )
               {
                  A863TaxasId = Z863TaxasId;
                  AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TAXASID");
                  AnyError = 1;
                  GX_FocusControl = edtTaxasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTaxasPercentual_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2Q96( ) ;
                  GX_FocusControl = edtTaxasPercentual_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A863TaxasId != Z863TaxasId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTaxasPercentual_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2Q96( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TAXASID");
                     AnyError = 1;
                     GX_FocusControl = edtTaxasId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTaxasPercentual_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2Q96( ) ;
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
         if ( A863TaxasId != Z863TaxasId )
         {
            A863TaxasId = Z863TaxasId;
            AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TAXASID");
            AnyError = 1;
            GX_FocusControl = edtTaxasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTaxasPercentual_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2Q96( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002Q2 */
            pr_default.execute(0, new Object[] {A863TaxasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Taxas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z866TaxasCreatedAt != T002Q2_A866TaxasCreatedAt[0] ) || ( Z867TaxasUpdatedAt != T002Q2_A867TaxasUpdatedAt[0] ) || ( Z864TaxasPercentual != T002Q2_A864TaxasPercentual[0] ) || ( Z894TaxasPercentualAnual != T002Q2_A894TaxasPercentualAnual[0] ) || ( Z865TaxasValorMinimo != T002Q2_A865TaxasValorMinimo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z868TaxasCreatedBy != T002Q2_A868TaxasCreatedBy[0] ) || ( Z869TaxasUpdatedBy != T002Q2_A869TaxasUpdatedBy[0] ) )
            {
               if ( Z866TaxasCreatedAt != T002Q2_A866TaxasCreatedAt[0] )
               {
                  GXUtil.WriteLog("taxas:[seudo value changed for attri]"+"TaxasCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z866TaxasCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A866TaxasCreatedAt[0]);
               }
               if ( Z867TaxasUpdatedAt != T002Q2_A867TaxasUpdatedAt[0] )
               {
                  GXUtil.WriteLog("taxas:[seudo value changed for attri]"+"TaxasUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z867TaxasUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A867TaxasUpdatedAt[0]);
               }
               if ( Z864TaxasPercentual != T002Q2_A864TaxasPercentual[0] )
               {
                  GXUtil.WriteLog("taxas:[seudo value changed for attri]"+"TaxasPercentual");
                  GXUtil.WriteLogRaw("Old: ",Z864TaxasPercentual);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A864TaxasPercentual[0]);
               }
               if ( Z894TaxasPercentualAnual != T002Q2_A894TaxasPercentualAnual[0] )
               {
                  GXUtil.WriteLog("taxas:[seudo value changed for attri]"+"TaxasPercentualAnual");
                  GXUtil.WriteLogRaw("Old: ",Z894TaxasPercentualAnual);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A894TaxasPercentualAnual[0]);
               }
               if ( Z865TaxasValorMinimo != T002Q2_A865TaxasValorMinimo[0] )
               {
                  GXUtil.WriteLog("taxas:[seudo value changed for attri]"+"TaxasValorMinimo");
                  GXUtil.WriteLogRaw("Old: ",Z865TaxasValorMinimo);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A865TaxasValorMinimo[0]);
               }
               if ( Z868TaxasCreatedBy != T002Q2_A868TaxasCreatedBy[0] )
               {
                  GXUtil.WriteLog("taxas:[seudo value changed for attri]"+"TaxasCreatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z868TaxasCreatedBy);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A868TaxasCreatedBy[0]);
               }
               if ( Z869TaxasUpdatedBy != T002Q2_A869TaxasUpdatedBy[0] )
               {
                  GXUtil.WriteLog("taxas:[seudo value changed for attri]"+"TaxasUpdatedBy");
                  GXUtil.WriteLogRaw("Old: ",Z869TaxasUpdatedBy);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A869TaxasUpdatedBy[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Taxas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2Q96( )
      {
         BeforeValidate2Q96( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Q96( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2Q96( 0) ;
            CheckOptimisticConcurrency2Q96( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Q96( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2Q96( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Q12 */
                     pr_default.execute(10, new Object[] {n866TaxasCreatedAt, A866TaxasCreatedAt, n867TaxasUpdatedAt, A867TaxasUpdatedAt, n864TaxasPercentual, A864TaxasPercentual, n894TaxasPercentualAnual, A894TaxasPercentualAnual, n865TaxasValorMinimo, A865TaxasValorMinimo, n868TaxasCreatedBy, A868TaxasCreatedBy, n869TaxasUpdatedBy, A869TaxasUpdatedBy});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002Q13 */
                     pr_default.execute(11);
                     A863TaxasId = T002Q13_A863TaxasId[0];
                     AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Taxas");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2Q0( ) ;
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
               Load2Q96( ) ;
            }
            EndLevel2Q96( ) ;
         }
         CloseExtendedTableCursors2Q96( ) ;
      }

      protected void Update2Q96( )
      {
         BeforeValidate2Q96( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Q96( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Q96( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Q96( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2Q96( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Q14 */
                     pr_default.execute(12, new Object[] {n866TaxasCreatedAt, A866TaxasCreatedAt, n867TaxasUpdatedAt, A867TaxasUpdatedAt, n864TaxasPercentual, A864TaxasPercentual, n894TaxasPercentualAnual, A894TaxasPercentualAnual, n865TaxasValorMinimo, A865TaxasValorMinimo, n868TaxasCreatedBy, A868TaxasCreatedBy, n869TaxasUpdatedBy, A869TaxasUpdatedBy, A863TaxasId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Taxas");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Taxas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2Q96( ) ;
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
            EndLevel2Q96( ) ;
         }
         CloseExtendedTableCursors2Q96( ) ;
      }

      protected void DeferredUpdate2Q96( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2Q96( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Q96( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2Q96( ) ;
            AfterConfirm2Q96( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2Q96( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002Q15 */
                  pr_default.execute(13, new Object[] {A863TaxasId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("Taxas");
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
         sMode96 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2Q96( ) ;
         Gx_mode = sMode96;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2Q96( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002Q16 */
            pr_default.execute(14, new Object[] {n868TaxasCreatedBy, A868TaxasCreatedBy});
            A872TaxasCreatedName = T002Q16_A872TaxasCreatedName[0];
            n872TaxasCreatedName = T002Q16_n872TaxasCreatedName[0];
            AssignAttri("", false, "A872TaxasCreatedName", A872TaxasCreatedName);
            pr_default.close(14);
            /* Using cursor T002Q17 */
            pr_default.execute(15, new Object[] {n869TaxasUpdatedBy, A869TaxasUpdatedBy});
            A873TaxasUpdatedName = T002Q17_A873TaxasUpdatedName[0];
            n873TaxasUpdatedName = T002Q17_n873TaxasUpdatedName[0];
            AssignAttri("", false, "A873TaxasUpdatedName", A873TaxasUpdatedName);
            pr_default.close(15);
         }
      }

      protected void EndLevel2Q96( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2Q96( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("taxas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("taxas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2Q96( )
      {
         /* Scan By routine */
         /* Using cursor T002Q18 */
         pr_default.execute(16);
         RcdFound96 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound96 = 1;
            A863TaxasId = T002Q18_A863TaxasId[0];
            AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2Q96( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound96 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound96 = 1;
            A863TaxasId = T002Q18_A863TaxasId[0];
            AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
         }
      }

      protected void ScanEnd2Q96( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm2Q96( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2Q96( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2Q96( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2Q96( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2Q96( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2Q96( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2Q96( )
      {
         edtTaxasPercentual_Enabled = 0;
         AssignProp("", false, edtTaxasPercentual_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasPercentual_Enabled), 5, 0), true);
         edtTaxasPercentualAnual_Enabled = 0;
         AssignProp("", false, edtTaxasPercentualAnual_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasPercentualAnual_Enabled), 5, 0), true);
         edtTaxasValorMinimo_Enabled = 0;
         AssignProp("", false, edtTaxasValorMinimo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasValorMinimo_Enabled), 5, 0), true);
         edtTaxasCreatedAt_Enabled = 0;
         AssignProp("", false, edtTaxasCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasCreatedAt_Enabled), 5, 0), true);
         edtTaxasCreatedName_Enabled = 0;
         AssignProp("", false, edtTaxasCreatedName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasCreatedName_Enabled), 5, 0), true);
         edtTaxasUpdatedAt_Enabled = 0;
         AssignProp("", false, edtTaxasUpdatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasUpdatedAt_Enabled), 5, 0), true);
         edtTaxasUpdatedName_Enabled = 0;
         AssignProp("", false, edtTaxasUpdatedName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasUpdatedName_Enabled), 5, 0), true);
         edtTaxasId_Enabled = 0;
         AssignProp("", false, edtTaxasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasId_Enabled), 5, 0), true);
         edtTaxasCreatedBy_Enabled = 0;
         AssignProp("", false, edtTaxasCreatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasCreatedBy_Enabled), 5, 0), true);
         edtTaxasUpdatedBy_Enabled = 0;
         AssignProp("", false, edtTaxasUpdatedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxasUpdatedBy_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2Q96( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2Q0( )
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
         GXEncryptionTmp = "taxas"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TaxasId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("taxas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Taxas");
         forbiddenHiddens.Add("TaxasId", context.localUtil.Format( (decimal)(A863TaxasId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_TaxasCreatedBy", context.localUtil.Format( (decimal)(AV11Insert_TaxasCreatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Insert_TaxasUpdatedBy", context.localUtil.Format( (decimal)(AV12Insert_TaxasUpdatedBy), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("taxas:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z863TaxasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z863TaxasId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z866TaxasCreatedAt", context.localUtil.TToC( Z866TaxasCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z867TaxasUpdatedAt", context.localUtil.TToC( Z867TaxasUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z864TaxasPercentual", StringUtil.LTrim( StringUtil.NToC( Z864TaxasPercentual, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z894TaxasPercentualAnual", StringUtil.LTrim( StringUtil.NToC( Z894TaxasPercentualAnual, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z865TaxasValorMinimo", StringUtil.LTrim( StringUtil.NToC( Z865TaxasValorMinimo, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z868TaxasCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z868TaxasCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z869TaxasUpdatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z869TaxasUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N868TaxasCreatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A868TaxasCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N869TaxasUpdatedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A869TaxasUpdatedBy), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vTAXASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TaxasId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTAXASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TaxasId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_TAXASCREATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_TaxasCreatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TAXASUPDATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_TaxasUpdatedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV24Pgmname));
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
         GXEncryptionTmp = "taxas"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TaxasId,9,0));
         return formatLink("taxas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Taxas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Taxas" ;
      }

      protected void InitializeNonKey2Q96( )
      {
         A868TaxasCreatedBy = 0;
         n868TaxasCreatedBy = false;
         AssignAttri("", false, "A868TaxasCreatedBy", ((0==A868TaxasCreatedBy)&&IsIns( )||n868TaxasCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A868TaxasCreatedBy), 4, 0, ".", ""))));
         n868TaxasCreatedBy = ((0==A868TaxasCreatedBy) ? true : false);
         A869TaxasUpdatedBy = 0;
         n869TaxasUpdatedBy = false;
         AssignAttri("", false, "A869TaxasUpdatedBy", ((0==A869TaxasUpdatedBy)&&IsIns( )||n869TaxasUpdatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A869TaxasUpdatedBy), 4, 0, ".", ""))));
         n869TaxasUpdatedBy = ((0==A869TaxasUpdatedBy) ? true : false);
         A866TaxasCreatedAt = (DateTime)(DateTime.MinValue);
         n866TaxasCreatedAt = false;
         AssignAttri("", false, "A866TaxasCreatedAt", context.localUtil.TToC( A866TaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         n866TaxasCreatedAt = ((DateTime.MinValue==A866TaxasCreatedAt) ? true : false);
         A867TaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         n867TaxasUpdatedAt = false;
         AssignAttri("", false, "A867TaxasUpdatedAt", context.localUtil.TToC( A867TaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
         n867TaxasUpdatedAt = ((DateTime.MinValue==A867TaxasUpdatedAt) ? true : false);
         A864TaxasPercentual = 0;
         n864TaxasPercentual = false;
         AssignAttri("", false, "A864TaxasPercentual", ((Convert.ToDecimal(0)==A864TaxasPercentual)&&IsIns( )||n864TaxasPercentual ? "" : StringUtil.LTrim( StringUtil.NToC( A864TaxasPercentual, 16, 4, ".", ""))));
         n864TaxasPercentual = ((Convert.ToDecimal(0)==A864TaxasPercentual) ? true : false);
         A894TaxasPercentualAnual = 0;
         n894TaxasPercentualAnual = false;
         AssignAttri("", false, "A894TaxasPercentualAnual", ((Convert.ToDecimal(0)==A894TaxasPercentualAnual)&&IsIns( )||n894TaxasPercentualAnual ? "" : StringUtil.LTrim( StringUtil.NToC( A894TaxasPercentualAnual, 16, 4, ".", ""))));
         n894TaxasPercentualAnual = ((Convert.ToDecimal(0)==A894TaxasPercentualAnual) ? true : false);
         A865TaxasValorMinimo = 0;
         n865TaxasValorMinimo = false;
         AssignAttri("", false, "A865TaxasValorMinimo", ((Convert.ToDecimal(0)==A865TaxasValorMinimo)&&IsIns( )||n865TaxasValorMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A865TaxasValorMinimo, 18, 2, ".", ""))));
         n865TaxasValorMinimo = ((Convert.ToDecimal(0)==A865TaxasValorMinimo) ? true : false);
         A872TaxasCreatedName = "";
         n872TaxasCreatedName = false;
         AssignAttri("", false, "A872TaxasCreatedName", A872TaxasCreatedName);
         A873TaxasUpdatedName = "";
         n873TaxasUpdatedName = false;
         AssignAttri("", false, "A873TaxasUpdatedName", A873TaxasUpdatedName);
         Z866TaxasCreatedAt = (DateTime)(DateTime.MinValue);
         Z867TaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         Z864TaxasPercentual = 0;
         Z894TaxasPercentualAnual = 0;
         Z865TaxasValorMinimo = 0;
         Z868TaxasCreatedBy = 0;
         Z869TaxasUpdatedBy = 0;
      }

      protected void InitAll2Q96( )
      {
         A863TaxasId = 0;
         AssignAttri("", false, "A863TaxasId", StringUtil.LTrimStr( (decimal)(A863TaxasId), 9, 0));
         InitializeNonKey2Q96( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A866TaxasCreatedAt = i866TaxasCreatedAt;
         n866TaxasCreatedAt = false;
         AssignAttri("", false, "A866TaxasCreatedAt", context.localUtil.TToC( A866TaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         A868TaxasCreatedBy = i868TaxasCreatedBy;
         n868TaxasCreatedBy = false;
         AssignAttri("", false, "A868TaxasCreatedBy", ((0==A868TaxasCreatedBy)&&IsIns( )||n868TaxasCreatedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A868TaxasCreatedBy), 4, 0, ".", ""))));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019212740", true, true);
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
         context.AddJavascriptSource("taxas.js", "?202561019212741", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblLblmessage_Internalname = "LBLMESSAGE";
         edtTaxasPercentual_Internalname = "TAXASPERCENTUAL";
         edtTaxasPercentualAnual_Internalname = "TAXASPERCENTUALANUAL";
         edtTaxasValorMinimo_Internalname = "TAXASVALORMINIMO";
         lblTextblocktaxascreatedat_Internalname = "TEXTBLOCKTAXASCREATEDAT";
         divTextblocktaxascreatedat_cell_Internalname = "TEXTBLOCKTAXASCREATEDAT_CELL";
         edtTaxasCreatedAt_Internalname = "TAXASCREATEDAT";
         cellTaxascreatedat_cell_Internalname = "TAXASCREATEDAT_CELL";
         edtTaxasCreatedName_Internalname = "TAXASCREATEDNAME";
         cellTaxascreatedname_cell_Internalname = "TAXASCREATEDNAME_CELL";
         tblTablemergedtaxascreatedat_Internalname = "TABLEMERGEDTAXASCREATEDAT";
         divTablesplittedtaxascreatedat_Internalname = "TABLESPLITTEDTAXASCREATEDAT";
         lblTextblocktaxasupdatedat_Internalname = "TEXTBLOCKTAXASUPDATEDAT";
         divTextblocktaxasupdatedat_cell_Internalname = "TEXTBLOCKTAXASUPDATEDAT_CELL";
         edtTaxasUpdatedAt_Internalname = "TAXASUPDATEDAT";
         cellTaxasupdatedat_cell_Internalname = "TAXASUPDATEDAT_CELL";
         edtTaxasUpdatedName_Internalname = "TAXASUPDATEDNAME";
         cellTaxasupdatedname_cell_Internalname = "TAXASUPDATEDNAME_CELL";
         tblTablemergedtaxasupdatedat_Internalname = "TABLEMERGEDTAXASUPDATEDAT";
         divTablesplittedtaxasupdatedat_Internalname = "TABLESPLITTEDTAXASUPDATEDAT";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtTaxasId_Internalname = "TAXASID";
         edtTaxasCreatedBy_Internalname = "TAXASCREATEDBY";
         edtTaxasUpdatedBy_Internalname = "TAXASUPDATEDBY";
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
         Form.Caption = "Taxas";
         edtTaxasUpdatedBy_Jsonclick = "";
         edtTaxasUpdatedBy_Enabled = 1;
         edtTaxasUpdatedBy_Visible = 1;
         edtTaxasCreatedBy_Jsonclick = "";
         edtTaxasCreatedBy_Enabled = 1;
         edtTaxasCreatedBy_Visible = 1;
         edtTaxasId_Jsonclick = "";
         edtTaxasId_Enabled = 0;
         edtTaxasId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTaxasUpdatedName_Jsonclick = "";
         edtTaxasUpdatedName_Enabled = 0;
         edtTaxasUpdatedName_Visible = 1;
         cellTaxasupdatedname_cell_Class = "";
         edtTaxasUpdatedAt_Jsonclick = "";
         edtTaxasUpdatedAt_Enabled = 1;
         edtTaxasUpdatedAt_Visible = 1;
         cellTaxasupdatedat_cell_Class = "";
         divTextblocktaxasupdatedat_cell_Class = "col-xs-12 col-sm-3";
         edtTaxasCreatedName_Jsonclick = "";
         edtTaxasCreatedName_Enabled = 0;
         edtTaxasCreatedName_Visible = 1;
         cellTaxascreatedname_cell_Class = "";
         edtTaxasCreatedAt_Jsonclick = "";
         edtTaxasCreatedAt_Enabled = 1;
         edtTaxasCreatedAt_Visible = 1;
         cellTaxascreatedat_cell_Class = "";
         divTextblocktaxascreatedat_cell_Class = "col-xs-12 col-sm-3";
         edtTaxasValorMinimo_Jsonclick = "";
         edtTaxasValorMinimo_Enabled = 1;
         edtTaxasPercentualAnual_Jsonclick = "";
         edtTaxasPercentualAnual_Enabled = 1;
         edtTaxasPercentual_Jsonclick = "";
         edtTaxasPercentual_Enabled = 1;
         lblLblmessage_Caption = "<span></span>";
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

      public void Valid_Taxascreatedby( )
      {
         n872TaxasCreatedName = false;
         /* Using cursor T002Q16 */
         pr_default.execute(14, new Object[] {n868TaxasCreatedBy, A868TaxasCreatedBy});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A868TaxasCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Taxas Created By'.", "ForeignKeyNotFound", 1, "TAXASCREATEDBY");
               AnyError = 1;
               GX_FocusControl = edtTaxasCreatedBy_Internalname;
            }
         }
         A872TaxasCreatedName = T002Q16_A872TaxasCreatedName[0];
         n872TaxasCreatedName = T002Q16_n872TaxasCreatedName[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A872TaxasCreatedName", A872TaxasCreatedName);
      }

      public void Valid_Taxasupdatedby( )
      {
         n873TaxasUpdatedName = false;
         /* Using cursor T002Q17 */
         pr_default.execute(15, new Object[] {n869TaxasUpdatedBy, A869TaxasUpdatedBy});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A869TaxasUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Taxas Updated By'.", "ForeignKeyNotFound", 1, "TAXASUPDATEDBY");
               AnyError = 1;
               GX_FocusControl = edtTaxasUpdatedBy_Internalname;
            }
         }
         A873TaxasUpdatedName = T002Q17_A873TaxasUpdatedName[0];
         n873TaxasUpdatedName = T002Q17_n873TaxasUpdatedName[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A873TaxasUpdatedName", A873TaxasUpdatedName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7TaxasId","fld":"vTAXASID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7TaxasId","fld":"vTAXASID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A863TaxasId","fld":"TAXASID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_TaxasCreatedBy","fld":"vINSERT_TAXASCREATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV12Insert_TaxasUpdatedBy","fld":"vINSERT_TAXASUPDATEDBY","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122Q2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_TAXASVALORMINIMO","""{"handler":"Valid_Taxasvalorminimo","iparms":[]}""");
         setEventMetadata("VALID_TAXASID","""{"handler":"Valid_Taxasid","iparms":[]}""");
         setEventMetadata("VALID_TAXASCREATEDBY","""{"handler":"Valid_Taxascreatedby","iparms":[{"av":"A868TaxasCreatedBy","fld":"TAXASCREATEDBY","pic":"ZZZ9","nullAv":"n868TaxasCreatedBy","type":"int"},{"av":"A872TaxasCreatedName","fld":"TAXASCREATEDNAME","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_TAXASCREATEDBY",""","oparms":[{"av":"A872TaxasCreatedName","fld":"TAXASCREATEDNAME","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALID_TAXASUPDATEDBY","""{"handler":"Valid_Taxasupdatedby","iparms":[{"av":"A869TaxasUpdatedBy","fld":"TAXASUPDATEDBY","pic":"ZZZ9","nullAv":"n869TaxasUpdatedBy","type":"int"},{"av":"A873TaxasUpdatedName","fld":"TAXASUPDATEDNAME","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_TAXASUPDATEDBY",""","oparms":[{"av":"A873TaxasUpdatedName","fld":"TAXASUPDATEDNAME","pic":"@!","type":"svchar"}]}""");
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
         Z866TaxasCreatedAt = (DateTime)(DateTime.MinValue);
         Z867TaxasUpdatedAt = (DateTime)(DateTime.MinValue);
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
         lblLblmessage_Jsonclick = "";
         TempTags = "";
         lblTextblocktaxascreatedat_Jsonclick = "";
         sStyleString = "";
         A866TaxasCreatedAt = (DateTime)(DateTime.MinValue);
         A872TaxasCreatedName = "";
         lblTextblocktaxasupdatedat_Jsonclick = "";
         A867TaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         A873TaxasUpdatedName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV24Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode96 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV23HTML = "";
         Z872TaxasCreatedName = "";
         Z873TaxasUpdatedName = "";
         T002Q4_A872TaxasCreatedName = new string[] {""} ;
         T002Q4_n872TaxasCreatedName = new bool[] {false} ;
         T002Q5_A873TaxasUpdatedName = new string[] {""} ;
         T002Q5_n873TaxasUpdatedName = new bool[] {false} ;
         T002Q6_A863TaxasId = new int[1] ;
         T002Q6_A866TaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Q6_n866TaxasCreatedAt = new bool[] {false} ;
         T002Q6_A867TaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Q6_n867TaxasUpdatedAt = new bool[] {false} ;
         T002Q6_A864TaxasPercentual = new decimal[1] ;
         T002Q6_n864TaxasPercentual = new bool[] {false} ;
         T002Q6_A894TaxasPercentualAnual = new decimal[1] ;
         T002Q6_n894TaxasPercentualAnual = new bool[] {false} ;
         T002Q6_A865TaxasValorMinimo = new decimal[1] ;
         T002Q6_n865TaxasValorMinimo = new bool[] {false} ;
         T002Q6_A872TaxasCreatedName = new string[] {""} ;
         T002Q6_n872TaxasCreatedName = new bool[] {false} ;
         T002Q6_A873TaxasUpdatedName = new string[] {""} ;
         T002Q6_n873TaxasUpdatedName = new bool[] {false} ;
         T002Q6_A868TaxasCreatedBy = new short[1] ;
         T002Q6_n868TaxasCreatedBy = new bool[] {false} ;
         T002Q6_A869TaxasUpdatedBy = new short[1] ;
         T002Q6_n869TaxasUpdatedBy = new bool[] {false} ;
         T002Q7_A872TaxasCreatedName = new string[] {""} ;
         T002Q7_n872TaxasCreatedName = new bool[] {false} ;
         T002Q8_A873TaxasUpdatedName = new string[] {""} ;
         T002Q8_n873TaxasUpdatedName = new bool[] {false} ;
         T002Q9_A863TaxasId = new int[1] ;
         T002Q3_A863TaxasId = new int[1] ;
         T002Q3_A866TaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Q3_n866TaxasCreatedAt = new bool[] {false} ;
         T002Q3_A867TaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Q3_n867TaxasUpdatedAt = new bool[] {false} ;
         T002Q3_A864TaxasPercentual = new decimal[1] ;
         T002Q3_n864TaxasPercentual = new bool[] {false} ;
         T002Q3_A894TaxasPercentualAnual = new decimal[1] ;
         T002Q3_n894TaxasPercentualAnual = new bool[] {false} ;
         T002Q3_A865TaxasValorMinimo = new decimal[1] ;
         T002Q3_n865TaxasValorMinimo = new bool[] {false} ;
         T002Q3_A868TaxasCreatedBy = new short[1] ;
         T002Q3_n868TaxasCreatedBy = new bool[] {false} ;
         T002Q3_A869TaxasUpdatedBy = new short[1] ;
         T002Q3_n869TaxasUpdatedBy = new bool[] {false} ;
         T002Q10_A863TaxasId = new int[1] ;
         T002Q11_A863TaxasId = new int[1] ;
         T002Q2_A863TaxasId = new int[1] ;
         T002Q2_A866TaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Q2_n866TaxasCreatedAt = new bool[] {false} ;
         T002Q2_A867TaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T002Q2_n867TaxasUpdatedAt = new bool[] {false} ;
         T002Q2_A864TaxasPercentual = new decimal[1] ;
         T002Q2_n864TaxasPercentual = new bool[] {false} ;
         T002Q2_A894TaxasPercentualAnual = new decimal[1] ;
         T002Q2_n894TaxasPercentualAnual = new bool[] {false} ;
         T002Q2_A865TaxasValorMinimo = new decimal[1] ;
         T002Q2_n865TaxasValorMinimo = new bool[] {false} ;
         T002Q2_A868TaxasCreatedBy = new short[1] ;
         T002Q2_n868TaxasCreatedBy = new bool[] {false} ;
         T002Q2_A869TaxasUpdatedBy = new short[1] ;
         T002Q2_n869TaxasUpdatedBy = new bool[] {false} ;
         T002Q13_A863TaxasId = new int[1] ;
         T002Q16_A872TaxasCreatedName = new string[] {""} ;
         T002Q16_n872TaxasCreatedName = new bool[] {false} ;
         T002Q17_A873TaxasUpdatedName = new string[] {""} ;
         T002Q17_n873TaxasUpdatedName = new bool[] {false} ;
         T002Q18_A863TaxasId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i866TaxasCreatedAt = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.taxas__default(),
            new Object[][] {
                new Object[] {
               T002Q2_A863TaxasId, T002Q2_A866TaxasCreatedAt, T002Q2_n866TaxasCreatedAt, T002Q2_A867TaxasUpdatedAt, T002Q2_n867TaxasUpdatedAt, T002Q2_A864TaxasPercentual, T002Q2_n864TaxasPercentual, T002Q2_A894TaxasPercentualAnual, T002Q2_n894TaxasPercentualAnual, T002Q2_A865TaxasValorMinimo,
               T002Q2_n865TaxasValorMinimo, T002Q2_A868TaxasCreatedBy, T002Q2_n868TaxasCreatedBy, T002Q2_A869TaxasUpdatedBy, T002Q2_n869TaxasUpdatedBy
               }
               , new Object[] {
               T002Q3_A863TaxasId, T002Q3_A866TaxasCreatedAt, T002Q3_n866TaxasCreatedAt, T002Q3_A867TaxasUpdatedAt, T002Q3_n867TaxasUpdatedAt, T002Q3_A864TaxasPercentual, T002Q3_n864TaxasPercentual, T002Q3_A894TaxasPercentualAnual, T002Q3_n894TaxasPercentualAnual, T002Q3_A865TaxasValorMinimo,
               T002Q3_n865TaxasValorMinimo, T002Q3_A868TaxasCreatedBy, T002Q3_n868TaxasCreatedBy, T002Q3_A869TaxasUpdatedBy, T002Q3_n869TaxasUpdatedBy
               }
               , new Object[] {
               T002Q4_A872TaxasCreatedName, T002Q4_n872TaxasCreatedName
               }
               , new Object[] {
               T002Q5_A873TaxasUpdatedName, T002Q5_n873TaxasUpdatedName
               }
               , new Object[] {
               T002Q6_A863TaxasId, T002Q6_A866TaxasCreatedAt, T002Q6_n866TaxasCreatedAt, T002Q6_A867TaxasUpdatedAt, T002Q6_n867TaxasUpdatedAt, T002Q6_A864TaxasPercentual, T002Q6_n864TaxasPercentual, T002Q6_A894TaxasPercentualAnual, T002Q6_n894TaxasPercentualAnual, T002Q6_A865TaxasValorMinimo,
               T002Q6_n865TaxasValorMinimo, T002Q6_A872TaxasCreatedName, T002Q6_n872TaxasCreatedName, T002Q6_A873TaxasUpdatedName, T002Q6_n873TaxasUpdatedName, T002Q6_A868TaxasCreatedBy, T002Q6_n868TaxasCreatedBy, T002Q6_A869TaxasUpdatedBy, T002Q6_n869TaxasUpdatedBy
               }
               , new Object[] {
               T002Q7_A872TaxasCreatedName, T002Q7_n872TaxasCreatedName
               }
               , new Object[] {
               T002Q8_A873TaxasUpdatedName, T002Q8_n873TaxasUpdatedName
               }
               , new Object[] {
               T002Q9_A863TaxasId
               }
               , new Object[] {
               T002Q10_A863TaxasId
               }
               , new Object[] {
               T002Q11_A863TaxasId
               }
               , new Object[] {
               }
               , new Object[] {
               T002Q13_A863TaxasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002Q16_A872TaxasCreatedName, T002Q16_n872TaxasCreatedName
               }
               , new Object[] {
               T002Q17_A873TaxasUpdatedName, T002Q17_n873TaxasUpdatedName
               }
               , new Object[] {
               T002Q18_A863TaxasId
               }
            }
         );
         AV24Pgmname = "Taxas";
      }

      private short Z868TaxasCreatedBy ;
      private short Z869TaxasUpdatedBy ;
      private short N868TaxasCreatedBy ;
      private short N869TaxasUpdatedBy ;
      private short GxWebError ;
      private short A868TaxasCreatedBy ;
      private short A869TaxasUpdatedBy ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short AV11Insert_TaxasCreatedBy ;
      private short AV12Insert_TaxasUpdatedBy ;
      private short RcdFound96 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short i868TaxasCreatedBy ;
      private int wcpOAV7TaxasId ;
      private int Z863TaxasId ;
      private int AV7TaxasId ;
      private int trnEnded ;
      private int edtTaxasPercentual_Enabled ;
      private int edtTaxasPercentualAnual_Enabled ;
      private int edtTaxasValorMinimo_Enabled ;
      private int edtTaxasCreatedAt_Visible ;
      private int edtTaxasCreatedAt_Enabled ;
      private int edtTaxasCreatedName_Visible ;
      private int edtTaxasCreatedName_Enabled ;
      private int edtTaxasUpdatedAt_Visible ;
      private int edtTaxasUpdatedAt_Enabled ;
      private int edtTaxasUpdatedName_Visible ;
      private int edtTaxasUpdatedName_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A863TaxasId ;
      private int edtTaxasId_Enabled ;
      private int edtTaxasId_Visible ;
      private int edtTaxasCreatedBy_Visible ;
      private int edtTaxasCreatedBy_Enabled ;
      private int edtTaxasUpdatedBy_Visible ;
      private int edtTaxasUpdatedBy_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV25GXV1 ;
      private int idxLst ;
      private decimal Z864TaxasPercentual ;
      private decimal Z894TaxasPercentualAnual ;
      private decimal Z865TaxasValorMinimo ;
      private decimal A864TaxasPercentual ;
      private decimal A894TaxasPercentualAnual ;
      private decimal A865TaxasValorMinimo ;
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
      private string edtTaxasPercentual_Internalname ;
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
      private string lblLblmessage_Internalname ;
      private string lblLblmessage_Caption ;
      private string lblLblmessage_Jsonclick ;
      private string TempTags ;
      private string edtTaxasPercentual_Jsonclick ;
      private string edtTaxasPercentualAnual_Internalname ;
      private string edtTaxasPercentualAnual_Jsonclick ;
      private string edtTaxasValorMinimo_Internalname ;
      private string edtTaxasValorMinimo_Jsonclick ;
      private string divTablesplittedtaxascreatedat_Internalname ;
      private string divTextblocktaxascreatedat_cell_Internalname ;
      private string divTextblocktaxascreatedat_cell_Class ;
      private string lblTextblocktaxascreatedat_Internalname ;
      private string lblTextblocktaxascreatedat_Jsonclick ;
      private string sStyleString ;
      private string tblTablemergedtaxascreatedat_Internalname ;
      private string cellTaxascreatedat_cell_Internalname ;
      private string cellTaxascreatedat_cell_Class ;
      private string edtTaxasCreatedAt_Internalname ;
      private string edtTaxasCreatedAt_Jsonclick ;
      private string cellTaxascreatedname_cell_Internalname ;
      private string cellTaxascreatedname_cell_Class ;
      private string edtTaxasCreatedName_Internalname ;
      private string edtTaxasCreatedName_Jsonclick ;
      private string divTablesplittedtaxasupdatedat_Internalname ;
      private string divTextblocktaxasupdatedat_cell_Internalname ;
      private string divTextblocktaxasupdatedat_cell_Class ;
      private string lblTextblocktaxasupdatedat_Internalname ;
      private string lblTextblocktaxasupdatedat_Jsonclick ;
      private string tblTablemergedtaxasupdatedat_Internalname ;
      private string cellTaxasupdatedat_cell_Internalname ;
      private string cellTaxasupdatedat_cell_Class ;
      private string edtTaxasUpdatedAt_Internalname ;
      private string edtTaxasUpdatedAt_Jsonclick ;
      private string cellTaxasupdatedname_cell_Internalname ;
      private string cellTaxasupdatedname_cell_Class ;
      private string edtTaxasUpdatedName_Internalname ;
      private string edtTaxasUpdatedName_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtTaxasId_Internalname ;
      private string edtTaxasId_Jsonclick ;
      private string edtTaxasCreatedBy_Internalname ;
      private string edtTaxasCreatedBy_Jsonclick ;
      private string edtTaxasUpdatedBy_Internalname ;
      private string edtTaxasUpdatedBy_Jsonclick ;
      private string AV24Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode96 ;
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
      private DateTime Z866TaxasCreatedAt ;
      private DateTime Z867TaxasUpdatedAt ;
      private DateTime A866TaxasCreatedAt ;
      private DateTime A867TaxasUpdatedAt ;
      private DateTime i866TaxasCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n868TaxasCreatedBy ;
      private bool n869TaxasUpdatedBy ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n864TaxasPercentual ;
      private bool n894TaxasPercentualAnual ;
      private bool n865TaxasValorMinimo ;
      private bool n866TaxasCreatedAt ;
      private bool n867TaxasUpdatedAt ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n872TaxasCreatedName ;
      private bool n873TaxasUpdatedName ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV23HTML ;
      private string A872TaxasCreatedName ;
      private string A873TaxasUpdatedName ;
      private string Z872TaxasCreatedName ;
      private string Z873TaxasUpdatedName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T002Q4_A872TaxasCreatedName ;
      private bool[] T002Q4_n872TaxasCreatedName ;
      private string[] T002Q5_A873TaxasUpdatedName ;
      private bool[] T002Q5_n873TaxasUpdatedName ;
      private int[] T002Q6_A863TaxasId ;
      private DateTime[] T002Q6_A866TaxasCreatedAt ;
      private bool[] T002Q6_n866TaxasCreatedAt ;
      private DateTime[] T002Q6_A867TaxasUpdatedAt ;
      private bool[] T002Q6_n867TaxasUpdatedAt ;
      private decimal[] T002Q6_A864TaxasPercentual ;
      private bool[] T002Q6_n864TaxasPercentual ;
      private decimal[] T002Q6_A894TaxasPercentualAnual ;
      private bool[] T002Q6_n894TaxasPercentualAnual ;
      private decimal[] T002Q6_A865TaxasValorMinimo ;
      private bool[] T002Q6_n865TaxasValorMinimo ;
      private string[] T002Q6_A872TaxasCreatedName ;
      private bool[] T002Q6_n872TaxasCreatedName ;
      private string[] T002Q6_A873TaxasUpdatedName ;
      private bool[] T002Q6_n873TaxasUpdatedName ;
      private short[] T002Q6_A868TaxasCreatedBy ;
      private bool[] T002Q6_n868TaxasCreatedBy ;
      private short[] T002Q6_A869TaxasUpdatedBy ;
      private bool[] T002Q6_n869TaxasUpdatedBy ;
      private string[] T002Q7_A872TaxasCreatedName ;
      private bool[] T002Q7_n872TaxasCreatedName ;
      private string[] T002Q8_A873TaxasUpdatedName ;
      private bool[] T002Q8_n873TaxasUpdatedName ;
      private int[] T002Q9_A863TaxasId ;
      private int[] T002Q3_A863TaxasId ;
      private DateTime[] T002Q3_A866TaxasCreatedAt ;
      private bool[] T002Q3_n866TaxasCreatedAt ;
      private DateTime[] T002Q3_A867TaxasUpdatedAt ;
      private bool[] T002Q3_n867TaxasUpdatedAt ;
      private decimal[] T002Q3_A864TaxasPercentual ;
      private bool[] T002Q3_n864TaxasPercentual ;
      private decimal[] T002Q3_A894TaxasPercentualAnual ;
      private bool[] T002Q3_n894TaxasPercentualAnual ;
      private decimal[] T002Q3_A865TaxasValorMinimo ;
      private bool[] T002Q3_n865TaxasValorMinimo ;
      private short[] T002Q3_A868TaxasCreatedBy ;
      private bool[] T002Q3_n868TaxasCreatedBy ;
      private short[] T002Q3_A869TaxasUpdatedBy ;
      private bool[] T002Q3_n869TaxasUpdatedBy ;
      private int[] T002Q10_A863TaxasId ;
      private int[] T002Q11_A863TaxasId ;
      private int[] T002Q2_A863TaxasId ;
      private DateTime[] T002Q2_A866TaxasCreatedAt ;
      private bool[] T002Q2_n866TaxasCreatedAt ;
      private DateTime[] T002Q2_A867TaxasUpdatedAt ;
      private bool[] T002Q2_n867TaxasUpdatedAt ;
      private decimal[] T002Q2_A864TaxasPercentual ;
      private bool[] T002Q2_n864TaxasPercentual ;
      private decimal[] T002Q2_A894TaxasPercentualAnual ;
      private bool[] T002Q2_n894TaxasPercentualAnual ;
      private decimal[] T002Q2_A865TaxasValorMinimo ;
      private bool[] T002Q2_n865TaxasValorMinimo ;
      private short[] T002Q2_A868TaxasCreatedBy ;
      private bool[] T002Q2_n868TaxasCreatedBy ;
      private short[] T002Q2_A869TaxasUpdatedBy ;
      private bool[] T002Q2_n869TaxasUpdatedBy ;
      private int[] T002Q13_A863TaxasId ;
      private string[] T002Q16_A872TaxasCreatedName ;
      private bool[] T002Q16_n872TaxasCreatedName ;
      private string[] T002Q17_A873TaxasUpdatedName ;
      private bool[] T002Q17_n873TaxasUpdatedName ;
      private int[] T002Q18_A863TaxasId ;
   }

   public class taxas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT002Q2;
          prmT002Q2 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmT002Q3;
          prmT002Q3 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmT002Q4;
          prmT002Q4 = new Object[] {
          new ParDef("TaxasCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Q5;
          prmT002Q5 = new Object[] {
          new ParDef("TaxasUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Q6;
          prmT002Q6 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmT002Q7;
          prmT002Q7 = new Object[] {
          new ParDef("TaxasCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Q8;
          prmT002Q8 = new Object[] {
          new ParDef("TaxasUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Q9;
          prmT002Q9 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmT002Q10;
          prmT002Q10 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmT002Q11;
          prmT002Q11 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmT002Q12;
          prmT002Q12 = new Object[] {
          new ParDef("TaxasCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TaxasUpdatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TaxasPercentual",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TaxasPercentualAnual",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TaxasValorMinimo",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TaxasCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TaxasUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Q13;
          prmT002Q13 = new Object[] {
          };
          Object[] prmT002Q14;
          prmT002Q14 = new Object[] {
          new ParDef("TaxasCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TaxasUpdatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TaxasPercentual",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TaxasPercentualAnual",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TaxasValorMinimo",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TaxasCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TaxasUpdatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmT002Q15;
          prmT002Q15 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmT002Q16;
          prmT002Q16 = new Object[] {
          new ParDef("TaxasCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Q17;
          prmT002Q17 = new Object[] {
          new ParDef("TaxasUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002Q18;
          prmT002Q18 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002Q2", "SELECT TaxasId, TaxasCreatedAt, TaxasUpdatedAt, TaxasPercentual, TaxasPercentualAnual, TaxasValorMinimo, TaxasCreatedBy, TaxasUpdatedBy FROM Taxas WHERE TaxasId = :TaxasId  FOR UPDATE OF Taxas NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Q3", "SELECT TaxasId, TaxasCreatedAt, TaxasUpdatedAt, TaxasPercentual, TaxasPercentualAnual, TaxasValorMinimo, TaxasCreatedBy, TaxasUpdatedBy FROM Taxas WHERE TaxasId = :TaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Q4", "SELECT SecUserFullName AS TaxasCreatedName FROM SecUser WHERE SecUserId = :TaxasCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Q5", "SELECT SecUserFullName AS TaxasUpdatedName FROM SecUser WHERE SecUserId = :TaxasUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Q6", "SELECT TM1.TaxasId, TM1.TaxasCreatedAt, TM1.TaxasUpdatedAt, TM1.TaxasPercentual, TM1.TaxasPercentualAnual, TM1.TaxasValorMinimo, T2.SecUserFullName AS TaxasCreatedName, T3.SecUserFullName AS TaxasUpdatedName, TM1.TaxasCreatedBy AS TaxasCreatedBy, TM1.TaxasUpdatedBy AS TaxasUpdatedBy FROM ((Taxas TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.TaxasCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.TaxasUpdatedBy) WHERE TM1.TaxasId = :TaxasId ORDER BY TM1.TaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Q7", "SELECT SecUserFullName AS TaxasCreatedName FROM SecUser WHERE SecUserId = :TaxasCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Q8", "SELECT SecUserFullName AS TaxasUpdatedName FROM SecUser WHERE SecUserId = :TaxasUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Q9", "SELECT TaxasId FROM Taxas WHERE TaxasId = :TaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Q10", "SELECT TaxasId FROM Taxas WHERE ( TaxasId > :TaxasId) ORDER BY TaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002Q11", "SELECT TaxasId FROM Taxas WHERE ( TaxasId < :TaxasId) ORDER BY TaxasId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002Q12", "SAVEPOINT gxupdate;INSERT INTO Taxas(TaxasCreatedAt, TaxasUpdatedAt, TaxasPercentual, TaxasPercentualAnual, TaxasValorMinimo, TaxasCreatedBy, TaxasUpdatedBy) VALUES(:TaxasCreatedAt, :TaxasUpdatedAt, :TaxasPercentual, :TaxasPercentualAnual, :TaxasValorMinimo, :TaxasCreatedBy, :TaxasUpdatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002Q12)
             ,new CursorDef("T002Q13", "SELECT currval('TaxasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Q14", "SAVEPOINT gxupdate;UPDATE Taxas SET TaxasCreatedAt=:TaxasCreatedAt, TaxasUpdatedAt=:TaxasUpdatedAt, TaxasPercentual=:TaxasPercentual, TaxasPercentualAnual=:TaxasPercentualAnual, TaxasValorMinimo=:TaxasValorMinimo, TaxasCreatedBy=:TaxasCreatedBy, TaxasUpdatedBy=:TaxasUpdatedBy  WHERE TaxasId = :TaxasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002Q14)
             ,new CursorDef("T002Q15", "SAVEPOINT gxupdate;DELETE FROM Taxas  WHERE TaxasId = :TaxasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002Q15)
             ,new CursorDef("T002Q16", "SELECT SecUserFullName AS TaxasCreatedName FROM SecUser WHERE SecUserId = :TaxasCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Q17", "SELECT SecUserFullName AS TaxasUpdatedName FROM SecUser WHERE SecUserId = :TaxasUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002Q18", "SELECT TaxasId FROM Taxas ORDER BY TaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q18,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
