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
   public class wpmodelocontrato : GXDataArea
   {
      public wpmodelocontrato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpmodelocontrato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           short aP1_LayoutContratoId )
      {
         this.AV8TrnMode = aP0_TrnMode;
         this.AV12LayoutContratoId = aP1_LayoutContratoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavLayoutcontrato_layoutcontratostatus = new GXCombobox();
         cmbavLayoutcontrato_layoutcontratotipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TrnMode");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA9V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9V2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal FormWithFixedActions\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpmodelocontrato"+UrlEncode(StringUtil.RTrim(AV8TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV12LayoutContratoId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("wpmodelocontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV8TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vLAYOUTCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12LayoutContratoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLAYOUTCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12LayoutContratoId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Layoutcontrato", AV5LayoutContrato);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Layoutcontrato", AV5LayoutContrato);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV8TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TrnMode, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV10CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV7Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV7Messages);
         }
         GxWebStd.gx_hidden_field( context, "vLAYOUTCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12LayoutContratoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLAYOUTCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12LayoutContratoId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLAYOUTCONTRATO", AV5LayoutContrato);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLAYOUTCONTRATO", AV5LayoutContrato);
         }
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATO_LAYOUTCONTRATOCORPO_Captionclass", StringUtil.RTrim( Layoutcontrato_layoutcontratocorpo_Captionclass));
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATO_LAYOUTCONTRATOCORPO_Captionstyle", StringUtil.RTrim( Layoutcontrato_layoutcontratocorpo_Captionstyle));
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATO_LAYOUTCONTRATOCORPO_Captionposition", StringUtil.RTrim( Layoutcontrato_layoutcontratocorpo_Captionposition));
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
         SendSecurityToken((string)(sPrefix));
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
         if ( ! ( WebComp_Wctagsww == null ) )
         {
            WebComp_Wctagsww.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormWithFixedActions" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE9V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9V2( ) ;
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
         GXEncryptionTmp = "wpmodelocontrato"+UrlEncode(StringUtil.RTrim(AV8TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV12LayoutContratoId,4,0));
         return formatLink("wpmodelocontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpModeloContrato" ;
      }

      public override string GetPgmdesc( )
      {
         return "Modelo de Contrato" ;
      }

      protected void WB9V0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLayoutcontrato_layoutcontratodescricao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLayoutcontrato_layoutcontratodescricao_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLayoutcontrato_layoutcontratodescricao_Internalname, AV5LayoutContrato.gxTpr_Layoutcontratodescricao, StringUtil.RTrim( context.localUtil.Format( AV5LayoutContrato.gxTpr_Layoutcontratodescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLayoutcontrato_layoutcontratodescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavLayoutcontrato_layoutcontratodescricao_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpModeloContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavLayoutcontrato_layoutcontratostatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLayoutcontrato_layoutcontratostatus_Internalname, "Ativo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLayoutcontrato_layoutcontratostatus, cmbavLayoutcontrato_layoutcontratostatus_Internalname, StringUtil.BoolToStr( AV5LayoutContrato.gxTpr_Layoutcontratostatus), 1, cmbavLayoutcontrato_layoutcontratostatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavLayoutcontrato_layoutcontratostatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_WpModeloContrato.htm");
            cmbavLayoutcontrato_layoutcontratostatus.CurrentValue = StringUtil.BoolToStr( AV5LayoutContrato.gxTpr_Layoutcontratostatus);
            AssignProp("", false, cmbavLayoutcontrato_layoutcontratostatus_Internalname, "Values", (string)(cmbavLayoutcontrato_layoutcontratostatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavLayoutcontrato_layoutcontratotipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLayoutcontrato_layoutcontratotipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLayoutcontrato_layoutcontratotipo, cmbavLayoutcontrato_layoutcontratotipo_Internalname, StringUtil.RTrim( AV5LayoutContrato.gxTpr_Layoutcontratotipo), 1, cmbavLayoutcontrato_layoutcontratotipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavLayoutcontrato_layoutcontratotipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_WpModeloContrato.htm");
            cmbavLayoutcontrato_layoutcontratotipo.CurrentValue = StringUtil.RTrim( AV5LayoutContrato.gxTpr_Layoutcontratotipo);
            AssignProp("", false, cmbavLayoutcontrato_layoutcontratotipo_Internalname, "Values", (string)(cmbavLayoutcontrato_layoutcontratotipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlayoutcontrato_layoutcontratocorpo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocklayoutcontrato_layoutcontratocorpo_Internalname, "Contrato Corpo", "", "", lblTextblocklayoutcontrato_layoutcontratocorpo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpModeloContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_43_9V2( true) ;
         }
         else
         {
            wb_table1_43_9V2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_9V2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0052"+"", StringUtil.RTrim( WebComp_Wctagsww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0052"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wctagsww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWctagsww), StringUtil.Lower( WebComp_Wctagsww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0052"+"");
                  }
                  WebComp_Wctagsww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWctagsww), StringUtil.Lower( WebComp_Wctagsww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpModeloContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpModeloContrato.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLayoutcontrato_layoutcontratoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5LayoutContrato.gxTpr_Layoutcontratoid), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5LayoutContrato.gxTpr_Layoutcontratoid), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLayoutcontrato_layoutcontratoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLayoutcontrato_layoutcontratoid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpModeloContrato.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLayoutcontrato_layoutcontratotag_Internalname, AV5LayoutContrato.gxTpr_Layoutcontratotag, StringUtil.RTrim( context.localUtil.Format( AV5LayoutContrato.gxTpr_Layoutcontratotag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLayoutcontrato_layoutcontratotag_Jsonclick, 0, "Attribute", "", "", "", "", edtavLayoutcontrato_layoutcontratotag_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpModeloContrato.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START9V2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
            }
         }
         Form.Meta.addItem("description", "Modelo de Contrato", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9V0( ) ;
      }

      protected void WS9V2( )
      {
         START9V2( ) ;
         EVT9V2( ) ;
      }

      protected void EVT9V2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E119V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E129V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E139V2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E149V2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 52 )
                        {
                           OldWctagsww = cgiGet( "W0052");
                           if ( ( StringUtil.Len( OldWctagsww) == 0 ) || ( StringUtil.StrCmp(OldWctagsww, WebComp_Wctagsww_Component) != 0 ) )
                           {
                              WebComp_Wctagsww = getWebComponent(GetType(), "GeneXus.Programs", OldWctagsww, new Object[] {context} );
                              WebComp_Wctagsww.ComponentInit();
                              WebComp_Wctagsww.Name = "OldWctagsww";
                              WebComp_Wctagsww_Component = OldWctagsww;
                           }
                           if ( StringUtil.Len( WebComp_Wctagsww_Component) != 0 )
                           {
                              WebComp_Wctagsww.componentprocess("W0052", "", sEvt);
                           }
                           WebComp_Wctagsww_Component = OldWctagsww;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE9V2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA9V2( )
      {
         if ( nDonePA == 0 )
         {
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpmodelocontrato")), "wpmodelocontrato") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpmodelocontrato")))) ;
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
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "TrnMode");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV8TrnMode = gxfirstwebparm;
                     AssignAttri("", false, "AV8TrnMode", AV8TrnMode);
                     GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TrnMode, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV12LayoutContratoId = (short)(Math.Round(NumberUtil.Val( GetPar( "LayoutContratoId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV12LayoutContratoId", StringUtil.LTrimStr( (decimal)(AV12LayoutContratoId), 4, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vLAYOUTCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12LayoutContratoId), "ZZZ9"), context));
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavLayoutcontrato_layoutcontratodescricao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavLayoutcontrato_layoutcontratostatus.ItemCount > 0 )
         {
            AV5LayoutContrato.gxTpr_Layoutcontratostatus = StringUtil.StrToBool( cmbavLayoutcontrato_layoutcontratostatus.getValidValue(StringUtil.BoolToStr( AV5LayoutContrato.gxTpr_Layoutcontratostatus)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLayoutcontrato_layoutcontratostatus.CurrentValue = StringUtil.BoolToStr( AV5LayoutContrato.gxTpr_Layoutcontratostatus);
            AssignProp("", false, cmbavLayoutcontrato_layoutcontratostatus_Internalname, "Values", cmbavLayoutcontrato_layoutcontratostatus.ToJavascriptSource(), true);
         }
         if ( cmbavLayoutcontrato_layoutcontratotipo.ItemCount > 0 )
         {
            AV5LayoutContrato.gxTpr_Layoutcontratotipo = cmbavLayoutcontrato_layoutcontratotipo.getValidValue(AV5LayoutContrato.gxTpr_Layoutcontratotipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLayoutcontrato_layoutcontratotipo.CurrentValue = StringUtil.RTrim( AV5LayoutContrato.gxTpr_Layoutcontratotipo);
            AssignProp("", false, cmbavLayoutcontrato_layoutcontratotipo_Internalname, "Values", cmbavLayoutcontrato_layoutcontratotipo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E129V2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wctagsww_Component) != 0 )
               {
                  WebComp_Wctagsww.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E149V2 ();
            WB9V0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes9V2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E119V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLAYOUTCONTRATO"), AV5LayoutContrato);
            ajax_req_read_hidden_sdt(cgiGet( "Layoutcontrato"), AV5LayoutContrato);
            /* Read saved values. */
            Layoutcontrato_layoutcontratocorpo_Captionclass = cgiGet( "LAYOUTCONTRATO_LAYOUTCONTRATOCORPO_Captionclass");
            Layoutcontrato_layoutcontratocorpo_Captionstyle = cgiGet( "LAYOUTCONTRATO_LAYOUTCONTRATOCORPO_Captionstyle");
            Layoutcontrato_layoutcontratocorpo_Captionposition = cgiGet( "LAYOUTCONTRATO_LAYOUTCONTRATOCORPO_Captionposition");
            Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
            Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
            Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
            Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
            Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
            Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
            Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
            Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
            Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
            Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
            /* Read variables values. */
            AV5LayoutContrato.gxTpr_Layoutcontratodescricao = cgiGet( edtavLayoutcontrato_layoutcontratodescricao_Internalname);
            cmbavLayoutcontrato_layoutcontratostatus.CurrentValue = cgiGet( cmbavLayoutcontrato_layoutcontratostatus_Internalname);
            AV5LayoutContrato.gxTpr_Layoutcontratostatus = StringUtil.StrToBool( cgiGet( cmbavLayoutcontrato_layoutcontratostatus_Internalname));
            cmbavLayoutcontrato_layoutcontratotipo.CurrentValue = cgiGet( cmbavLayoutcontrato_layoutcontratotipo_Internalname);
            AV5LayoutContrato.gxTpr_Layoutcontratotipo = cgiGet( cmbavLayoutcontrato_layoutcontratotipo_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLayoutcontrato_layoutcontratoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLayoutcontrato_layoutcontratoid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LAYOUTCONTRATO_LAYOUTCONTRATOID");
               GX_FocusControl = edtavLayoutcontrato_layoutcontratoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5LayoutContrato.gxTpr_Layoutcontratoid = 0;
            }
            else
            {
               AV5LayoutContrato.gxTpr_Layoutcontratoid = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavLayoutcontrato_layoutcontratoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV5LayoutContrato.gxTpr_Layoutcontratotag = cgiGet( edtavLayoutcontrato_layoutcontratotag_Internalname);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E119V2 ();
         if (returnInSub) return;
      }

      protected void E119V2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV9LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV8TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV8TrnMode, "INS") == 0 ) ) || ( ( StringUtil.StrCmp(AV8TrnMode, "UPD") == 0 ) ) || ( ( StringUtil.StrCmp(AV8TrnMode, "DLT") == 0 ) ) )
         {
            if ( StringUtil.StrCmp(AV8TrnMode, "INS") != 0 )
            {
               AV5LayoutContrato.Load(AV12LayoutContratoId);
               AV9LoadSuccess = AV5LayoutContrato.Success();
               if ( ! AV9LoadSuccess )
               {
                  AV7Messages = AV5LayoutContrato.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV8TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV8TrnMode, "DLT") == 0 ) )
               {
                  edtavLayoutcontrato_layoutcontratodescricao_Enabled = 0;
                  AssignProp("", false, edtavLayoutcontrato_layoutcontratodescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLayoutcontrato_layoutcontratodescricao_Enabled), 5, 0), true);
                  cmbavLayoutcontrato_layoutcontratostatus.Enabled = 0;
                  AssignProp("", false, cmbavLayoutcontrato_layoutcontratostatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavLayoutcontrato_layoutcontratostatus.Enabled), 5, 0), true);
                  cmbavLayoutcontrato_layoutcontratotipo.Enabled = 0;
                  AssignProp("", false, cmbavLayoutcontrato_layoutcontratotipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavLayoutcontrato_layoutcontratotipo.Enabled), 5, 0), true);
                  this.executeUsercontrolMethod("", false, "LAYOUTCONTRATO_LAYOUTCONTRATOCORPOContainer", "SetMode", "", new Object[] {(short)0,AV5LayoutContrato.gxTpr_Layoutcontratocorpo});
               }
            }
         }
         else
         {
            AV9LoadSuccess = false;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( AV9LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV8TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem("Confirme a eliminação dos dados.");
            }
         }
         edtavLayoutcontrato_layoutcontratoid_Visible = 0;
         AssignProp("", false, edtavLayoutcontrato_layoutcontratoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLayoutcontrato_layoutcontratoid_Visible), 5, 0), true);
         edtavLayoutcontrato_layoutcontratotag_Visible = 0;
         AssignProp("", false, edtavLayoutcontrato_layoutcontratotag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLayoutcontrato_layoutcontratotag_Visible), 5, 0), true);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wctagsww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wctagsww_Component), StringUtil.Lower( "TagsWW")) != 0 )
         {
            WebComp_Wctagsww = getWebComponent(GetType(), "GeneXus.Programs", "tagsww", new Object[] {context} );
            WebComp_Wctagsww.ComponentInit();
            WebComp_Wctagsww.Name = "TagsWW";
            WebComp_Wctagsww_Component = "TagsWW";
         }
         if ( StringUtil.Len( WebComp_Wctagsww_Component) != 0 )
         {
            WebComp_Wctagsww.setjustcreated();
            WebComp_Wctagsww.componentprepare(new Object[] {(string)"W0052",(string)""});
            WebComp_Wctagsww.componentbind(new Object[] {});
         }
      }

      protected void E129V2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E139V2 ();
         if (returnInSub) return;
      }

      protected void E139V2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV8TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV8TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S132 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV8TrnMode, "DLT") == 0 ) || AV10CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV8TrnMode, "DLT") == 0 )
               {
                  AV5LayoutContrato.Delete();
               }
               else
               {
                  AV5LayoutContrato.Save();
               }
               if ( AV5LayoutContrato.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S142 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV7Messages = AV5LayoutContrato.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5LayoutContrato", AV5LayoutContrato);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Messages", AV7Messages);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV8TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV10CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5LayoutContrato.gxTpr_Layoutcontratodescricao)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""),  "error",  edtavLayoutcontrato_layoutcontratodescricao_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV10CheckRequiredFieldsResult", AV10CheckRequiredFieldsResult);
         }
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV18GXV6 = 1;
         while ( AV18GXV6 <= AV7Messages.Count )
         {
            AV6Message = ((GeneXus.Utils.SdtMessages_Message)AV7Messages.Item(AV18GXV6));
            GX_msglist.addItem(AV6Message.gxTpr_Description);
            AV18GXV6 = (int)(AV18GXV6+1);
         }
      }

      protected void S142( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("wpmodelocontrato",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E149V2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_43_9V2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedlayoutcontrato_layoutcontratocorpo_Internalname, tblTablemergedlayoutcontrato_layoutcontratocorpo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucLayoutcontrato_layoutcontratocorpo.SetProperty("Attribute", AV5LayoutContrato);
            ucLayoutcontrato_layoutcontratocorpo.SetProperty("FieldSpecifier", Layoutcontrato_layoutcontratocorpo_Fieldspecifier);
            ucLayoutcontrato_layoutcontratocorpo.SetProperty("CaptionClass", Layoutcontrato_layoutcontratocorpo_Captionclass);
            ucLayoutcontrato_layoutcontratocorpo.SetProperty("CaptionStyle", Layoutcontrato_layoutcontratocorpo_Captionstyle);
            ucLayoutcontrato_layoutcontratocorpo.SetProperty("CaptionPosition", Layoutcontrato_layoutcontratocorpo_Captionposition);
            ucLayoutcontrato_layoutcontratocorpo.Render(context, "fckeditor", Layoutcontrato_layoutcontratocorpo_Internalname, "LAYOUTCONTRATO_LAYOUTCONTRATOCORPOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLayoutcontrato_layoutcontratocorpo_righttext_Internalname, " ", "", "", lblLayoutcontrato_layoutcontratocorpo_righttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_WpModeloContrato.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_9V2e( true) ;
         }
         else
         {
            wb_table1_43_9V2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV8TrnMode", AV8TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TrnMode, "")), context));
         AV12LayoutContratoId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV12LayoutContratoId", StringUtil.LTrimStr( (decimal)(AV12LayoutContratoId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vLAYOUTCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12LayoutContratoId), "ZZZ9"), context));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA9V2( ) ;
         WS9V2( ) ;
         WE9V2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wctagsww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wctagsww_Component) != 0 )
            {
               WebComp_Wctagsww.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019285040", true, true);
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
         context.AddJavascriptSource("wpmodelocontrato.js", "?202561019285041", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavLayoutcontrato_layoutcontratostatus.Name = "LAYOUTCONTRATO_LAYOUTCONTRATOSTATUS";
         cmbavLayoutcontrato_layoutcontratostatus.WebTags = "";
         cmbavLayoutcontrato_layoutcontratostatus.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavLayoutcontrato_layoutcontratostatus.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavLayoutcontrato_layoutcontratostatus.ItemCount > 0 )
         {
            AV5LayoutContrato.gxTpr_Layoutcontratostatus = StringUtil.StrToBool( cmbavLayoutcontrato_layoutcontratostatus.getValidValue(StringUtil.BoolToStr( AV5LayoutContrato.gxTpr_Layoutcontratostatus)));
         }
         cmbavLayoutcontrato_layoutcontratotipo.Name = "LAYOUTCONTRATO_LAYOUTCONTRATOTIPO";
         cmbavLayoutcontrato_layoutcontratotipo.WebTags = "";
         cmbavLayoutcontrato_layoutcontratotipo.addItem("C", "Contrato", 0);
         cmbavLayoutcontrato_layoutcontratotipo.addItem("M", "Mensagem", 0);
         cmbavLayoutcontrato_layoutcontratotipo.addItem("A", "Acoplado", 0);
         if ( cmbavLayoutcontrato_layoutcontratotipo.ItemCount > 0 )
         {
            AV5LayoutContrato.gxTpr_Layoutcontratotipo = cmbavLayoutcontrato_layoutcontratotipo.getValidValue(AV5LayoutContrato.gxTpr_Layoutcontratotipo);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavLayoutcontrato_layoutcontratodescricao_Internalname = "LAYOUTCONTRATO_LAYOUTCONTRATODESCRICAO";
         cmbavLayoutcontrato_layoutcontratostatus_Internalname = "LAYOUTCONTRATO_LAYOUTCONTRATOSTATUS";
         cmbavLayoutcontrato_layoutcontratotipo_Internalname = "LAYOUTCONTRATO_LAYOUTCONTRATOTIPO";
         lblTextblocklayoutcontrato_layoutcontratocorpo_Internalname = "TEXTBLOCKLAYOUTCONTRATO_LAYOUTCONTRATOCORPO";
         Layoutcontrato_layoutcontratocorpo_Internalname = "LAYOUTCONTRATO_LAYOUTCONTRATOCORPO";
         lblLayoutcontrato_layoutcontratocorpo_righttext_Internalname = "LAYOUTCONTRATO_LAYOUTCONTRATOCORPO_RIGHTTEXT";
         tblTablemergedlayoutcontrato_layoutcontratocorpo_Internalname = "TABLEMERGEDLAYOUTCONTRATO_LAYOUTCONTRATOCORPO";
         divTablesplittedlayoutcontrato_layoutcontratocorpo_Internalname = "TABLESPLITTEDLAYOUTCONTRATO_LAYOUTCONTRATOCORPO";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavLayoutcontrato_layoutcontratoid_Internalname = "LAYOUTCONTRATO_LAYOUTCONTRATOID";
         edtavLayoutcontrato_layoutcontratotag_Internalname = "LAYOUTCONTRATO_LAYOUTCONTRATOTAG";
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
         cmbavLayoutcontrato_layoutcontratotipo.Enabled = 1;
         cmbavLayoutcontrato_layoutcontratostatus.Enabled = 1;
         edtavLayoutcontrato_layoutcontratodescricao_Enabled = 1;
         edtavLayoutcontrato_layoutcontratotag_Jsonclick = "";
         edtavLayoutcontrato_layoutcontratotag_Visible = 1;
         edtavLayoutcontrato_layoutcontratoid_Jsonclick = "";
         edtavLayoutcontrato_layoutcontratoid_Visible = 1;
         bttBtnenter_Visible = 1;
         cmbavLayoutcontrato_layoutcontratotipo_Jsonclick = "";
         cmbavLayoutcontrato_layoutcontratotipo.Enabled = 1;
         cmbavLayoutcontrato_layoutcontratostatus_Jsonclick = "";
         cmbavLayoutcontrato_layoutcontratostatus.Enabled = 1;
         edtavLayoutcontrato_layoutcontratodescricao_Jsonclick = "";
         edtavLayoutcontrato_layoutcontratodescricao_Enabled = 1;
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
         Layoutcontrato_layoutcontratocorpo_Captionposition = "None";
         Layoutcontrato_layoutcontratocorpo_Captionstyle = "width: 25%;";
         Layoutcontrato_layoutcontratocorpo_Captionclass = "gx-form-item AttributeLabel";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Modelo de Contrato";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV8TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"},{"av":"AV12LayoutContratoId","fld":"vLAYOUTCONTRATOID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E139V2","iparms":[{"av":"AV8TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"},{"av":"AV10CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV5LayoutContrato","fld":"vLAYOUTCONTRATO","type":""},{"av":"AV7Messages","fld":"vMESSAGES","type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5LayoutContrato","fld":"vLAYOUTCONTRATO","type":""},{"av":"AV7Messages","fld":"vMESSAGES","type":""},{"av":"AV10CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
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

      public override void initialize( )
      {
         wcpOAV8TrnMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5LayoutContrato = new SdtLayoutContrato(context);
         AV7Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblocklayoutcontrato_layoutcontratocorpo_Jsonclick = "";
         WebComp_Wctagsww_Component = "";
         OldWctagsww = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV6Message = new GeneXus.Utils.SdtMessages_Message(context);
         sStyleString = "";
         ucLayoutcontrato_layoutcontratocorpo = new GXUserControl();
         Layoutcontrato_layoutcontratocorpo_Fieldspecifier = "";
         lblLayoutcontrato_layoutcontratocorpo_righttext_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpmodelocontrato__default(),
            new Object[][] {
            }
         );
         WebComp_Wctagsww = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV12LayoutContratoId ;
      private short wcpOAV12LayoutContratoId ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavLayoutcontrato_layoutcontratodescricao_Enabled ;
      private int bttBtnenter_Visible ;
      private int edtavLayoutcontrato_layoutcontratoid_Visible ;
      private int edtavLayoutcontrato_layoutcontratotag_Visible ;
      private int AV18GXV6 ;
      private int idxLst ;
      private string AV8TrnMode ;
      private string wcpOAV8TrnMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Layoutcontrato_layoutcontratocorpo_Captionclass ;
      private string Layoutcontrato_layoutcontratocorpo_Captionstyle ;
      private string Layoutcontrato_layoutcontratocorpo_Captionposition ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavLayoutcontrato_layoutcontratodescricao_Internalname ;
      private string TempTags ;
      private string edtavLayoutcontrato_layoutcontratodescricao_Jsonclick ;
      private string cmbavLayoutcontrato_layoutcontratostatus_Internalname ;
      private string cmbavLayoutcontrato_layoutcontratostatus_Jsonclick ;
      private string cmbavLayoutcontrato_layoutcontratotipo_Internalname ;
      private string cmbavLayoutcontrato_layoutcontratotipo_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divTablesplittedlayoutcontrato_layoutcontratocorpo_Internalname ;
      private string lblTextblocklayoutcontrato_layoutcontratocorpo_Internalname ;
      private string lblTextblocklayoutcontrato_layoutcontratocorpo_Jsonclick ;
      private string WebComp_Wctagsww_Component ;
      private string OldWctagsww ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavLayoutcontrato_layoutcontratoid_Internalname ;
      private string edtavLayoutcontrato_layoutcontratoid_Jsonclick ;
      private string edtavLayoutcontrato_layoutcontratotag_Internalname ;
      private string edtavLayoutcontrato_layoutcontratotag_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sStyleString ;
      private string tblTablemergedlayoutcontrato_layoutcontratocorpo_Internalname ;
      private string Layoutcontrato_layoutcontratocorpo_Fieldspecifier ;
      private string Layoutcontrato_layoutcontratocorpo_Internalname ;
      private string lblLayoutcontrato_layoutcontratocorpo_righttext_Internalname ;
      private string lblLayoutcontrato_layoutcontratocorpo_righttext_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10CheckRequiredFieldsResult ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9LoadSuccess ;
      private bool bDynCreated_Wctagsww ;
      private GXWebComponent WebComp_Wctagsww ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucLayoutcontrato_layoutcontratocorpo ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavLayoutcontrato_layoutcontratostatus ;
      private GXCombobox cmbavLayoutcontrato_layoutcontratotipo ;
      private SdtLayoutContrato AV5LayoutContrato ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV7Messages ;
      private GeneXus.Utils.SdtMessages_Message AV6Message ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpmodelocontrato__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
