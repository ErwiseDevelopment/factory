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
namespace GeneXus.Programs.costumer {
   public class invoice : GXDataArea
   {
      public invoice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public invoice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_NotaFiscalID )
      {
         this.AV8NotaFiscalID = aP0_NotaFiscalID;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavNotafiscalstatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "NotaFiscalID");
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
               gxfirstwebparm = GetFirstPar( "NotaFiscalID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "NotaFiscalID");
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.masterpagepfpj", "GeneXus.Programs.wwpbaseobjects.masterpagepfpj", new Object[] {context});
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
         PA8Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8Y2( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "costumer.invoice"+UrlEncode(AV8NotaFiscalID.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("costumer.invoice") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vNOTAFISCALID", AV8NotaFiscalID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTAFISCALID", GetSecureSignedToken( "", AV8NotaFiscalID, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vNOTAFISCALID", AV8NotaFiscalID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTAFISCALID", GetSecureSignedToken( "", AV8NotaFiscalID, context));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABSNOTA_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabsnota_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABSNOTA_Class", StringUtil.RTrim( Gxuitabspanel_tabsnota_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABSNOTA_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabsnota_Historymanagement));
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
         if ( ! ( WebComp_Wcnotafiscalitemww == null ) )
         {
            WebComp_Wcnotafiscalitemww.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE8Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8Y2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "costumer.invoice"+UrlEncode(AV8NotaFiscalID.ToString());
         return formatLink("costumer.invoice") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Costumer.invoice" ;
      }

      public override string GetPgmdesc( )
      {
         return "Detalhes da nota fiscal" ;
      }

      protected void WB8Y0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Costumer/invoice.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefirst_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotasummary_Internalname, 1, 0, "px", 0, "px", "card-dashboard", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblnotafiscal_Internalname, lblLblnotafiscal_Caption, "", "", lblLblnotafiscal_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Costumer/invoice.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavNotafiscalstatus_Internalname, "Nota Fiscal Status", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavNotafiscalstatus, cmbavNotafiscalstatus_Internalname, StringUtil.RTrim( AV5NotaFiscalStatus), 1, cmbavNotafiscalstatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavNotafiscalstatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_Costumer/invoice.htm");
            cmbavNotafiscalstatus.CurrentValue = StringUtil.RTrim( AV5NotaFiscalStatus);
            AssignProp("", false, cmbavNotafiscalstatus_Internalname, "Values", (string)(cmbavNotafiscalstatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNotafiscaldataemissao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNotafiscaldataemissao_Internalname, "Data", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavNotafiscaldataemissao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavNotafiscaldataemissao_Internalname, context.localUtil.TToC( AV6NotaFiscalDataEmissao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV6NotaFiscalDataEmissao, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNotafiscaldataemissao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavNotafiscaldataemissao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Costumer/invoice.htm");
            GxWebStd.gx_bitmap( context, edtavNotafiscaldataemissao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavNotafiscaldataemissao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Costumer/invoice.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNotafiscalquantidaderesumo_f_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNotafiscalquantidaderesumo_f_Internalname, "Itens", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNotafiscalquantidaderesumo_f_Internalname, AV7NotaFiscalQuantidadeResumo_F, StringUtil.RTrim( context.localUtil.Format( AV7NotaFiscalQuantidadeResumo_F, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNotafiscalquantidaderesumo_f_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavNotafiscalquantidaderesumo_f_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Costumer/invoice.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTotalsummary_Internalname, 1, 0, "px", 0, "px", "card-dashboard", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltotalsummary_Internalname, lblLbltotalsummary_Caption, "", "", lblLbltotalsummary_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Costumer/invoice.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltotalsoldsummary_Internalname, lblLbltotalsoldsummary_Caption, "", "", lblLbltotalsoldsummary_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Costumer/invoice.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucGxuitabspanel_tabsnota.SetProperty("PageCount", Gxuitabspanel_tabsnota_Pagecount);
            ucGxuitabspanel_tabsnota.SetProperty("Class", Gxuitabspanel_tabsnota_Class);
            ucGxuitabspanel_tabsnota.SetProperty("HistoryManagement", Gxuitabspanel_tabsnota_Historymanagement);
            ucGxuitabspanel_tabsnota.Render(context, "tab", Gxuitabspanel_tabsnota_Internalname, "GXUITABSPANEL_TABSNOTAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSNOTAContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabitendanota_title_Internalname, "Itens da nota", "", "", lblTabitendanota_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Costumer/invoice.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabItenDaNota") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSNOTAContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0055"+"", StringUtil.RTrim( WebComp_Wcnotafiscalitemww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0055"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcnotafiscalitemww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnotafiscalitemww), StringUtil.Lower( WebComp_Wcnotafiscalitemww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0055"+"");
                  }
                  WebComp_Wcnotafiscalitemww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnotafiscalitemww), StringUtil.Lower( WebComp_Wcnotafiscalitemww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START8Y2( )
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
         Form.Meta.addItem("description", "Detalhes da nota fiscal", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8Y0( ) ;
      }

      protected void WS8Y2( )
      {
         START8Y2( ) ;
         EVT8Y2( ) ;
      }

      protected void EVT8Y2( )
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
                              E118Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E128Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
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
                        if ( nCmpId == 55 )
                        {
                           OldWcnotafiscalitemww = cgiGet( "W0055");
                           if ( ( StringUtil.Len( OldWcnotafiscalitemww) == 0 ) || ( StringUtil.StrCmp(OldWcnotafiscalitemww, WebComp_Wcnotafiscalitemww_Component) != 0 ) )
                           {
                              WebComp_Wcnotafiscalitemww = getWebComponent(GetType(), "GeneXus.Programs", OldWcnotafiscalitemww, new Object[] {context} );
                              WebComp_Wcnotafiscalitemww.ComponentInit();
                              WebComp_Wcnotafiscalitemww.Name = "OldWcnotafiscalitemww";
                              WebComp_Wcnotafiscalitemww_Component = OldWcnotafiscalitemww;
                           }
                           if ( StringUtil.Len( WebComp_Wcnotafiscalitemww_Component) != 0 )
                           {
                              WebComp_Wcnotafiscalitemww.componentprocess("W0055", "", sEvt);
                           }
                           WebComp_Wcnotafiscalitemww_Component = OldWcnotafiscalitemww;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE8Y2( )
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

      protected void PA8Y2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "costumer.invoice")), "costumer.invoice") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "costumer.invoice")))) ;
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
                  gxfirstwebparm = GetFirstPar( "NotaFiscalID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV8NotaFiscalID = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV8NotaFiscalID", AV8NotaFiscalID.ToString());
                     GxWebStd.gx_hidden_field( context, "gxhash_vNOTAFISCALID", GetSecureSignedToken( "", AV8NotaFiscalID, context));
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
               GX_FocusControl = cmbavNotafiscalstatus_Internalname;
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
         if ( cmbavNotafiscalstatus.ItemCount > 0 )
         {
            AV5NotaFiscalStatus = cmbavNotafiscalstatus.getValidValue(AV5NotaFiscalStatus);
            AssignAttri("", false, "AV5NotaFiscalStatus", AV5NotaFiscalStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavNotafiscalstatus.CurrentValue = StringUtil.RTrim( AV5NotaFiscalStatus);
            AssignProp("", false, cmbavNotafiscalstatus_Internalname, "Values", cmbavNotafiscalstatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF8Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         cmbavNotafiscalstatus.Enabled = 0;
         AssignProp("", false, cmbavNotafiscalstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavNotafiscalstatus.Enabled), 5, 0), true);
         edtavNotafiscaldataemissao_Enabled = 0;
         AssignProp("", false, edtavNotafiscaldataemissao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotafiscaldataemissao_Enabled), 5, 0), true);
         edtavNotafiscalquantidaderesumo_f_Enabled = 0;
         AssignProp("", false, edtavNotafiscalquantidaderesumo_f_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotafiscalquantidaderesumo_f_Enabled), 5, 0), true);
      }

      protected void RF8Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcnotafiscalitemww_Component) != 0 )
               {
                  WebComp_Wcnotafiscalitemww.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E128Y2 ();
            WB8Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes8Y2( )
      {
      }

      protected void before_start_formulas( )
      {
         cmbavNotafiscalstatus.Enabled = 0;
         AssignProp("", false, cmbavNotafiscalstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavNotafiscalstatus.Enabled), 5, 0), true);
         edtavNotafiscaldataemissao_Enabled = 0;
         AssignProp("", false, edtavNotafiscaldataemissao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotafiscaldataemissao_Enabled), 5, 0), true);
         edtavNotafiscalquantidaderesumo_f_Enabled = 0;
         AssignProp("", false, edtavNotafiscalquantidaderesumo_f_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotafiscalquantidaderesumo_f_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E118Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Gxuitabspanel_tabsnota_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABSNOTA_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabsnota_Class = cgiGet( "GXUITABSPANEL_TABSNOTA_Class");
            Gxuitabspanel_tabsnota_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABSNOTA_Historymanagement"));
            /* Read variables values. */
            cmbavNotafiscalstatus.CurrentValue = cgiGet( cmbavNotafiscalstatus_Internalname);
            AV5NotaFiscalStatus = cgiGet( cmbavNotafiscalstatus_Internalname);
            AssignAttri("", false, "AV5NotaFiscalStatus", AV5NotaFiscalStatus);
            if ( context.localUtil.VCDateTime( cgiGet( edtavNotafiscaldataemissao_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Nota Fiscal Data Emissao"}), 1, "vNOTAFISCALDATAEMISSAO");
               GX_FocusControl = edtavNotafiscaldataemissao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV6NotaFiscalDataEmissao", context.localUtil.TToC( AV6NotaFiscalDataEmissao, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV6NotaFiscalDataEmissao = context.localUtil.CToT( cgiGet( edtavNotafiscaldataemissao_Internalname));
               AssignAttri("", false, "AV6NotaFiscalDataEmissao", context.localUtil.TToC( AV6NotaFiscalDataEmissao, 8, 5, 0, 3, "/", ":", " "));
            }
            AV7NotaFiscalQuantidadeResumo_F = cgiGet( edtavNotafiscalquantidaderesumo_f_Internalname);
            AssignAttri("", false, "AV7NotaFiscalQuantidadeResumo_F", AV7NotaFiscalQuantidadeResumo_F);
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
         E118Y2 ();
         if (returnInSub) return;
      }

      protected void E118Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H008Y4 */
         pr_default.execute(0, new Object[] {AV8NotaFiscalID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A794NotaFiscalId = H008Y4_A794NotaFiscalId[0];
            n794NotaFiscalId = H008Y4_n794NotaFiscalId[0];
            A799NotaFiscalNumero = H008Y4_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = H008Y4_n799NotaFiscalNumero[0];
            A800NotaFiscalDataEmissao = H008Y4_A800NotaFiscalDataEmissao[0];
            n800NotaFiscalDataEmissao = H008Y4_n800NotaFiscalDataEmissao[0];
            A874NotaFiscalValorTotal_F = H008Y4_A874NotaFiscalValorTotal_F[0];
            A875NotaFiscalValorTotalVendido_F = H008Y4_A875NotaFiscalValorTotalVendido_F[0];
            A877NotaFiscalQuantidadeDeItens_F = H008Y4_A877NotaFiscalQuantidadeDeItens_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = H008Y4_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A874NotaFiscalValorTotal_F = H008Y4_A874NotaFiscalValorTotal_F[0];
            A877NotaFiscalQuantidadeDeItens_F = H008Y4_A877NotaFiscalQuantidadeDeItens_F[0];
            A875NotaFiscalValorTotalVendido_F = H008Y4_A875NotaFiscalValorTotalVendido_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = H008Y4_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
            AssignAttri("", false, "A879NotaFiscalQuantidadeResumo_F", A879NotaFiscalQuantidadeResumo_F);
            A880NotaFiscalStatus = ((A878NotaFiscalQuantidadeDeItensVendidos_F==A877NotaFiscalQuantidadeDeItens_F) ? "Completo" : "Parcial");
            AssignAttri("", false, "A880NotaFiscalStatus", A880NotaFiscalStatus);
            lblLblnotafiscal_Caption = StringUtil.Format( "<h3>%1</h3>", A799NotaFiscalNumero, "", "", "", "", "", "", "", "");
            AssignProp("", false, lblLblnotafiscal_Internalname, "Caption", lblLblnotafiscal_Caption, true);
            lblLbltotalsummary_Caption = StringUtil.Format( "<div style=\"display:flex; flex-direction: column; align-items: flex-start; justify-content: center;\"><span>Valor total</span><h3>R$%1</h3></div>", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
            AssignProp("", false, lblLbltotalsummary_Internalname, "Caption", lblLbltotalsummary_Caption, true);
            lblLbltotalsoldsummary_Caption = StringUtil.Format( "<div style=\"display:flex; flex-direction: column; align-items: flex-start; justify-content: center;\"><span>Valor vendido</span><h3>R$%1</h3></div>", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
            AssignProp("", false, lblLbltotalsoldsummary_Internalname, "Caption", lblLbltotalsoldsummary_Caption, true);
            AV6NotaFiscalDataEmissao = A800NotaFiscalDataEmissao;
            AssignAttri("", false, "AV6NotaFiscalDataEmissao", context.localUtil.TToC( AV6NotaFiscalDataEmissao, 8, 5, 0, 3, "/", ":", " "));
            AV5NotaFiscalStatus = A880NotaFiscalStatus;
            AssignAttri("", false, "AV5NotaFiscalStatus", AV5NotaFiscalStatus);
            AV7NotaFiscalQuantidadeResumo_F = A879NotaFiscalQuantidadeResumo_F;
            AssignAttri("", false, "AV7NotaFiscalQuantidadeResumo_F", AV7NotaFiscalQuantidadeResumo_F);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcnotafiscalitemww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcnotafiscalitemww_Component), StringUtil.Lower( "NotaFiscalItemWW")) != 0 )
         {
            WebComp_Wcnotafiscalitemww = getWebComponent(GetType(), "GeneXus.Programs", "notafiscalitemww", new Object[] {context} );
            WebComp_Wcnotafiscalitemww.ComponentInit();
            WebComp_Wcnotafiscalitemww.Name = "NotaFiscalItemWW";
            WebComp_Wcnotafiscalitemww_Component = "NotaFiscalItemWW";
         }
         if ( StringUtil.Len( WebComp_Wcnotafiscalitemww_Component) != 0 )
         {
            WebComp_Wcnotafiscalitemww.setjustcreated();
            WebComp_Wcnotafiscalitemww.componentprepare(new Object[] {(string)"W0055",(string)"",(Guid)AV8NotaFiscalID,(string)AV5NotaFiscalStatus});
            WebComp_Wcnotafiscalitemww.componentbind(new Object[] {(string)"",(string)"vNOTAFISCALSTATUS"});
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E128Y2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8NotaFiscalID = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV8NotaFiscalID", AV8NotaFiscalID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vNOTAFISCALID", GetSecureSignedToken( "", AV8NotaFiscalID, context));
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
         PA8Y2( ) ;
         WS8Y2( ) ;
         WE8Y2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcnotafiscalitemww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcnotafiscalitemww_Component) != 0 )
            {
               WebComp_Wcnotafiscalitemww.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019275264", true, true);
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
         context.AddJavascriptSource("costumer/invoice.js", "?202561019275264", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavNotafiscalstatus.Name = "vNOTAFISCALSTATUS";
         cmbavNotafiscalstatus.WebTags = "";
         cmbavNotafiscalstatus.addItem("Parcial", "Parcial", 0);
         cmbavNotafiscalstatus.addItem("Completo", "Completo", 0);
         if ( cmbavNotafiscalstatus.ItemCount > 0 )
         {
            AV5NotaFiscalStatus = cmbavNotafiscalstatus.getValidValue(AV5NotaFiscalStatus);
            AssignAttri("", false, "AV5NotaFiscalStatus", AV5NotaFiscalStatus);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         lblLblnotafiscal_Internalname = "LBLNOTAFISCAL";
         cmbavNotafiscalstatus_Internalname = "vNOTAFISCALSTATUS";
         edtavNotafiscaldataemissao_Internalname = "vNOTAFISCALDATAEMISSAO";
         edtavNotafiscalquantidaderesumo_f_Internalname = "vNOTAFISCALQUANTIDADERESUMO_F";
         lblLbltotalsummary_Internalname = "LBLTOTALSUMMARY";
         lblLbltotalsoldsummary_Internalname = "LBLTOTALSOLDSUMMARY";
         divTotalsummary_Internalname = "TOTALSUMMARY";
         divTablenotasummary_Internalname = "TABLENOTASUMMARY";
         divTablefirst_Internalname = "TABLEFIRST";
         lblTabitendanota_title_Internalname = "TABITENDANOTA_TITLE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabsnota_Internalname = "GXUITABSPANEL_TABSNOTA";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
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
         lblLbltotalsoldsummary_Caption = "<div style=\"display:flex; flex-direction: column; align-items: flex-start; justify-content: center;\"><span>Valor vendido</span><h3>R$64.000,00</h3></div>";
         lblLbltotalsummary_Caption = "<div style=\"display:flex; flex-direction: column; align-items: flex-start; justify-content: center;\"><span>Valor total</span><h3>R$64.000,00</h3></div>";
         edtavNotafiscalquantidaderesumo_f_Jsonclick = "";
         edtavNotafiscalquantidaderesumo_f_Enabled = 1;
         edtavNotafiscaldataemissao_Jsonclick = "";
         edtavNotafiscaldataemissao_Enabled = 1;
         cmbavNotafiscalstatus_Jsonclick = "";
         cmbavNotafiscalstatus.Enabled = 1;
         lblLblnotafiscal_Caption = "<h3>20456</h3>";
         Gxuitabspanel_tabsnota_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabsnota_Class = "Tab";
         Gxuitabspanel_tabsnota_Pagecount = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Detalhes da nota fiscal";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV8NotaFiscalID","fld":"vNOTAFISCALID","hsh":true,"type":"guid"}]}""");
         setEventMetadata("VALIDV_NOTAFISCALSTATUS","""{"handler":"Validv_Notafiscalstatus","iparms":[]}""");
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
         wcpOAV8NotaFiscalID = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_cancel_Jsonclick = "";
         lblLblnotafiscal_Jsonclick = "";
         AV5NotaFiscalStatus = "";
         AV6NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
         AV7NotaFiscalQuantidadeResumo_F = "";
         lblLbltotalsummary_Jsonclick = "";
         lblLbltotalsoldsummary_Jsonclick = "";
         ucGxuitabspanel_tabsnota = new GXUserControl();
         lblTabitendanota_title_Jsonclick = "";
         WebComp_Wcnotafiscalitemww_Component = "";
         OldWcnotafiscalitemww = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H008Y4_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H008Y4_n794NotaFiscalId = new bool[] {false} ;
         H008Y4_A799NotaFiscalNumero = new string[] {""} ;
         H008Y4_n799NotaFiscalNumero = new bool[] {false} ;
         H008Y4_A800NotaFiscalDataEmissao = new DateTime[] {DateTime.MinValue} ;
         H008Y4_n800NotaFiscalDataEmissao = new bool[] {false} ;
         H008Y4_A874NotaFiscalValorTotal_F = new decimal[1] ;
         H008Y4_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         H008Y4_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         H008Y4_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         A794NotaFiscalId = Guid.Empty;
         A799NotaFiscalNumero = "";
         A800NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
         A879NotaFiscalQuantidadeResumo_F = "";
         A880NotaFiscalStatus = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costumer.invoice__default(),
            new Object[][] {
                new Object[] {
               H008Y4_A794NotaFiscalId, H008Y4_A799NotaFiscalNumero, H008Y4_n799NotaFiscalNumero, H008Y4_A800NotaFiscalDataEmissao, H008Y4_n800NotaFiscalDataEmissao, H008Y4_A874NotaFiscalValorTotal_F, H008Y4_A875NotaFiscalValorTotalVendido_F, H008Y4_A877NotaFiscalQuantidadeDeItens_F, H008Y4_A878NotaFiscalQuantidadeDeItensVendidos_F
               }
            }
         );
         WebComp_Wcnotafiscalitemww = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         cmbavNotafiscalstatus.Enabled = 0;
         edtavNotafiscaldataemissao_Enabled = 0;
         edtavNotafiscalquantidaderesumo_f_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short A877NotaFiscalQuantidadeDeItens_F ;
      private short A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private short nGXWrapped ;
      private int Gxuitabspanel_tabsnota_Pagecount ;
      private int edtavNotafiscaldataemissao_Enabled ;
      private int edtavNotafiscalquantidaderesumo_f_Enabled ;
      private int idxLst ;
      private decimal A874NotaFiscalValorTotal_F ;
      private decimal A875NotaFiscalValorTotalVendido_F ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Gxuitabspanel_tabsnota_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string divTablefirst_Internalname ;
      private string divTablenotasummary_Internalname ;
      private string lblLblnotafiscal_Internalname ;
      private string lblLblnotafiscal_Caption ;
      private string lblLblnotafiscal_Jsonclick ;
      private string cmbavNotafiscalstatus_Internalname ;
      private string cmbavNotafiscalstatus_Jsonclick ;
      private string edtavNotafiscaldataemissao_Internalname ;
      private string edtavNotafiscaldataemissao_Jsonclick ;
      private string edtavNotafiscalquantidaderesumo_f_Internalname ;
      private string edtavNotafiscalquantidaderesumo_f_Jsonclick ;
      private string divTotalsummary_Internalname ;
      private string lblLbltotalsummary_Internalname ;
      private string lblLbltotalsummary_Caption ;
      private string lblLbltotalsummary_Jsonclick ;
      private string lblLbltotalsoldsummary_Internalname ;
      private string lblLbltotalsoldsummary_Caption ;
      private string lblLbltotalsoldsummary_Jsonclick ;
      private string Gxuitabspanel_tabsnota_Internalname ;
      private string lblTabitendanota_title_Internalname ;
      private string lblTabitendanota_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string WebComp_Wcnotafiscalitemww_Component ;
      private string OldWcnotafiscalitemww ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private DateTime AV6NotaFiscalDataEmissao ;
      private DateTime A800NotaFiscalDataEmissao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Gxuitabspanel_tabsnota_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n794NotaFiscalId ;
      private bool n799NotaFiscalNumero ;
      private bool n800NotaFiscalDataEmissao ;
      private bool bDynCreated_Wcnotafiscalitemww ;
      private string AV5NotaFiscalStatus ;
      private string AV7NotaFiscalQuantidadeResumo_F ;
      private string A799NotaFiscalNumero ;
      private string A879NotaFiscalQuantidadeResumo_F ;
      private string A880NotaFiscalStatus ;
      private Guid AV8NotaFiscalID ;
      private Guid wcpOAV8NotaFiscalID ;
      private Guid A794NotaFiscalId ;
      private GXWebComponent WebComp_Wcnotafiscalitemww ;
      private GXUserControl ucGxuitabspanel_tabsnota ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavNotafiscalstatus ;
      private IDataStoreProvider pr_default ;
      private Guid[] H008Y4_A794NotaFiscalId ;
      private bool[] H008Y4_n794NotaFiscalId ;
      private string[] H008Y4_A799NotaFiscalNumero ;
      private bool[] H008Y4_n799NotaFiscalNumero ;
      private DateTime[] H008Y4_A800NotaFiscalDataEmissao ;
      private bool[] H008Y4_n800NotaFiscalDataEmissao ;
      private decimal[] H008Y4_A874NotaFiscalValorTotal_F ;
      private decimal[] H008Y4_A875NotaFiscalValorTotalVendido_F ;
      private short[] H008Y4_A877NotaFiscalQuantidadeDeItens_F ;
      private short[] H008Y4_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class invoice__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH008Y4;
          prmH008Y4 = new Object[] {
          new ParDef("AV8NotaFiscalID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H008Y4", "SELECT T1.NotaFiscalId, T1.NotaFiscalNumero, T1.NotaFiscalDataEmissao, COALESCE( T2.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F, COALESCE( T3.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T2.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItens_F, COALESCE( T3.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F FROM ((NotaFiscal T1 LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T1.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T2 ON T2.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T1.NotaFiscalId = NotaFiscalId) AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T3 ON T3.NotaFiscalId = T1.NotaFiscalId) WHERE T1.NotaFiscalId = :AV8NotaFiscalID ORDER BY T1.NotaFiscalId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008Y4,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((short[]) buf[8])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
