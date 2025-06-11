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
   public class wpassinaturas : GXDataArea
   {
      public wpassinaturas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpassinaturas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_AssinaturaId )
      {
         this.AV8AssinaturaId = aP0_AssinaturaId;
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "AssinaturaId");
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
               gxfirstwebparm = GetFirstPar( "AssinaturaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AssinaturaId");
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
         PA6F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6F2( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCPdfViewerRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
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
         GXEncryptionTmp = "wpassinaturas"+UrlEncode(StringUtil.LTrimStr(AV8AssinaturaId,10,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpassinaturas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vASSINADOARQUIVO", AV20AssinadoArquivo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vASSINADOARQUIVO", AV20AssinadoArquivo);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINADOARQUIVO", GetSecureSignedToken( "", AV20AssinadoArquivo, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARQUIVO", AV10Arquivo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARQUIVO", AV10Arquivo);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vARQUIVO", GetSecureSignedToken( "", AV10Arquivo, context));
         GxWebStd.gx_hidden_field( context, "vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8AssinaturaId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vASSINADOARQUIVO", AV20AssinadoArquivo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vASSINADOARQUIVO", AV20AssinadoArquivo);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINADOARQUIVO", GetSecureSignedToken( "", AV20AssinadoArquivo, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARQUIVO", AV10Arquivo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARQUIVO", AV10Arquivo);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vARQUIVO", GetSecureSignedToken( "", AV10Arquivo, context));
         GxWebStd.gx_hidden_field( context, "vASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8AssinaturaId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8AssinaturaId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "UCCONTRATO_Path", StringUtil.RTrim( Uccontrato_Path));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW_Target", StringUtil.RTrim( Innewwindow_Target));
         GxWebStd.gx_hidden_field( context, "vARQUIVO_Arquivoblob", AV10Arquivo.gxTpr_Arquivoblob);
         GxWebStd.gx_hidden_field( context, "vASSINADOARQUIVO_Arquivoblob", AV20AssinadoArquivo.gxTpr_Arquivoblob);
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
         if ( ! ( WebComp_Wcwcassinantes == null ) )
         {
            WebComp_Wcwcassinantes.componentjscripts();
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
            WE6F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6F2( ) ;
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
         GXEncryptionTmp = "wpassinaturas"+UrlEncode(StringUtil.LTrimStr(AV8AssinaturaId,10,0));
         return formatLink("wpassinaturas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpAssinaturas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Assinaturas" ;
      }

      protected void WB6F0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContratonome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContratonome_Internalname, "Contrato", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContratonome_Internalname, AV17ContratoNome, StringUtil.RTrim( context.localUtil.Format( AV17ContratoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContratonome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContratonome_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
            ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
            ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, "GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblParticipantes_title_Internalname, "Participantes", "", "", lblParticipantes_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpAssinaturas.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Participantes") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepart_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0028"+"", StringUtil.RTrim( WebComp_Wcwcassinantes_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0028"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcassinantes_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcassinantes), StringUtil.Lower( WebComp_Wcwcassinantes_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0028"+"");
                  }
                  WebComp_Wcwcassinantes.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcassinantes), StringUtil.Lower( WebComp_Wcwcassinantes_Component)) != 0 )
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblContrato_title_Internalname, "Contrato", "", "", lblContrato_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpAssinaturas.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Contrato") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontrato_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndownload_Internalname, "", "Download", bttBtndownload_Jsonclick, 5, "Download", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DODOWNLOAD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndownloadassinado_Internalname, "", "Download Arquivo Assinado", bttBtndownloadassinado_Jsonclick, 5, "Download Arquivo Assinado", "", StyleString, ClassString, bttBtndownloadassinado_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DODOWNLOADASSINADO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblThehtml_Internalname, "<div id=\"the-canvas\"></div>", "", "", lblThehtml_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpAssinaturas.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucUccontrato.Render(context, "ucpdfviewer", Uccontrato_Internalname, "UCCONTRATOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucInnewwindow.Render(context, "innewwindow", Innewwindow_Internalname, "INNEWWINDOWContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpAssinaturas.htm");
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

      protected void START6F2( )
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
         Form.Meta.addItem("description", "Assinaturas", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP6F0( ) ;
      }

      protected void WS6F2( )
      {
         START6F2( ) ;
         EVT6F2( ) ;
      }

      protected void EVT6F2( )
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
                              E116F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E126F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODOWNLOAD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoDownload' */
                              E136F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODOWNLOADASSINADO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoDownloadAssinado' */
                              E146F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E156F2 ();
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
                        if ( nCmpId == 28 )
                        {
                           OldWcwcassinantes = cgiGet( "W0028");
                           if ( ( StringUtil.Len( OldWcwcassinantes) == 0 ) || ( StringUtil.StrCmp(OldWcwcassinantes, WebComp_Wcwcassinantes_Component) != 0 ) )
                           {
                              WebComp_Wcwcassinantes = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcassinantes, new Object[] {context} );
                              WebComp_Wcwcassinantes.ComponentInit();
                              WebComp_Wcwcassinantes.Name = "OldWcwcassinantes";
                              WebComp_Wcwcassinantes_Component = OldWcwcassinantes;
                           }
                           if ( StringUtil.Len( WebComp_Wcwcassinantes_Component) != 0 )
                           {
                              WebComp_Wcwcassinantes.componentprocess("W0028", "", sEvt);
                           }
                           WebComp_Wcwcassinantes_Component = OldWcwcassinantes;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE6F2( )
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

      protected void PA6F2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpassinaturas")), "wpassinaturas") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpassinaturas")))) ;
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
                  gxfirstwebparm = GetFirstPar( "AssinaturaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV8AssinaturaId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV8AssinaturaId", StringUtil.LTrimStr( (decimal)(AV8AssinaturaId), 10, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8AssinaturaId), "ZZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavContratonome_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavContratonome_Enabled = 0;
         AssignProp("", false, edtavContratonome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContratonome_Enabled), 5, 0), true);
      }

      protected void RF6F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E126F2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwcassinantes_Component) != 0 )
               {
                  WebComp_Wcwcassinantes.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E156F2 ();
            WB6F0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6F2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vASSINADOARQUIVO", AV20AssinadoArquivo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vASSINADOARQUIVO", AV20AssinadoArquivo);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINADOARQUIVO", GetSecureSignedToken( "", AV20AssinadoArquivo, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARQUIVO", AV10Arquivo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARQUIVO", AV10Arquivo);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vARQUIVO", GetSecureSignedToken( "", AV10Arquivo, context));
      }

      protected void before_start_formulas( )
      {
         edtavContratonome_Enabled = 0;
         AssignProp("", false, edtavContratonome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContratonome_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E116F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Uccontrato_Path = cgiGet( "UCCONTRATO_Path");
            Gxuitabspanel_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
            Innewwindow_Target = cgiGet( "INNEWWINDOW_Target");
            /* Read variables values. */
            AV17ContratoNome = cgiGet( edtavContratonome_Internalname);
            AssignAttri("", false, "AV17ContratoNome", AV17ContratoNome);
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
         E116F2 ();
         if (returnInSub) return;
      }

      protected void E116F2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Using cursor H006F2 */
         pr_default.execute(0, new Object[] {AV8AssinaturaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = H006F2_A227ContratoId[0];
            n227ContratoId = H006F2_n227ContratoId[0];
            A238AssinaturaId = H006F2_A238AssinaturaId[0];
            A239AssinaturaStatus = H006F2_A239AssinaturaStatus[0];
            n239AssinaturaStatus = H006F2_n239AssinaturaStatus[0];
            A231ArquivoId = H006F2_A231ArquivoId[0];
            n231ArquivoId = H006F2_n231ArquivoId[0];
            A228ContratoNome = H006F2_A228ContratoNome[0];
            n228ContratoNome = H006F2_n228ContratoNome[0];
            A578ArquivoAssinadoId = H006F2_A578ArquivoAssinadoId[0];
            n578ArquivoAssinadoId = H006F2_n578ArquivoAssinadoId[0];
            A228ContratoNome = H006F2_A228ContratoNome[0];
            n228ContratoNome = H006F2_n228ContratoNome[0];
            AV5AssinaturaStatus = A239AssinaturaStatus;
            AV9ArquivoId = A231ArquivoId;
            AV17ContratoNome = A228ContratoNome;
            AssignAttri("", false, "AV17ContratoNome", AV17ContratoNome);
            AV19ArquivoAssinadoId = A578ArquivoAssinadoId;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV10Arquivo.Load(AV9ArquivoId);
         AV20AssinadoArquivo.Load(AV19ArquivoAssinadoId);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcassinantes = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcassinantes_Component), StringUtil.Lower( "WcAssinantes")) != 0 )
         {
            WebComp_Wcwcassinantes = getWebComponent(GetType(), "GeneXus.Programs", "wcassinantes", new Object[] {context} );
            WebComp_Wcwcassinantes.ComponentInit();
            WebComp_Wcwcassinantes.Name = "WcAssinantes";
            WebComp_Wcwcassinantes_Component = "WcAssinantes";
         }
         if ( StringUtil.Len( WebComp_Wcwcassinantes_Component) != 0 )
         {
            WebComp_Wcwcassinantes.setjustcreated();
            WebComp_Wcwcassinantes.componentprepare(new Object[] {(string)"W0028",(string)"",(long)AV8AssinaturaId});
            WebComp_Wcwcassinantes.componentbind(new Object[] {(string)""});
         }
         AV14NomeDoArquivo = Guid.NewGuid( ).ToString();
         AV15Path = ".\\PrivateTempStorage\\" + AV14NomeDoArquivo + ".pdf";
         AV11File.Source = AV15Path;
         AV15Path = StringUtil.StringReplace( AV15Path, ".\\PrivateTempStorage\\", "./PrivateTempStorage/");
         Uccontrato_Path = AV15Path;
         ucUccontrato.SendProperty(context, "", false, Uccontrato_Internalname, "path", Uccontrato_Path);
         if ( AV11File.Exists() )
         {
            AV11File.Delete();
         }
         AV11File.Source = AV15Path;
         AV11File.FromBase64(context.FileToBase64( AV10Arquivo.gxTpr_Arquivoblob));
         AV11File.Create();
      }

      protected void E126F2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E136F2( )
      {
         /* 'DoDownload' Routine */
         returnInSub = false;
         AV12GUID = Guid.NewGuid( );
         AV13Source = "./privatetempstorage/" + StringUtil.Trim( AV12GUID.ToString()) + ".pdf";
         AV11File.Source = AV13Source;
         AV11File.FromBase64(context.FileToBase64( AV10Arquivo.gxTpr_Arquivoblob));
         AV11File.Create();
         Innewwindow_Target = AV13Source;
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E146F2( )
      {
         /* 'DoDownloadAssinado' Routine */
         returnInSub = false;
         AV12GUID = Guid.NewGuid( );
         AV13Source = "./privatetempstorage/" + StringUtil.Trim( AV12GUID.ToString()) + ".pdf";
         AV11File.Source = AV13Source;
         AV11File.FromBase64(context.FileToBase64( AV20AssinadoArquivo.gxTpr_Arquivoblob));
         AV11File.Create();
         Innewwindow_Target = AV13Source;
         ucInnewwindow.SendProperty(context, "", false, Innewwindow_Internalname, "Target", Innewwindow_Target);
         this.executeUsercontrolMethod("", false, "INNEWWINDOWContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20AssinadoArquivo.gxTpr_Arquivoblob)) ) )
         {
            bttBtndownloadassinado_Visible = 0;
            AssignProp("", false, bttBtndownloadassinado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndownloadassinado_Visible), 5, 0), true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E156F2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8AssinaturaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV8AssinaturaId", StringUtil.LTrimStr( (decimal)(AV8AssinaturaId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vASSINATURAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8AssinaturaId), "ZZZZZZZZZ9"), context));
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
         PA6F2( ) ;
         WS6F2( ) ;
         WE6F2( ) ;
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
         if ( ! ( WebComp_Wcwcassinantes == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcassinantes_Component) != 0 )
            {
               WebComp_Wcwcassinantes.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101926104", true, true);
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
         context.AddJavascriptSource("wpassinaturas.js", "?20256101926104", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCPdfViewerRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavContratonome_Internalname = "vCONTRATONOME";
         lblParticipantes_title_Internalname = "PARTICIPANTES_TITLE";
         divTablepart_Internalname = "TABLEPART";
         lblContrato_title_Internalname = "CONTRATO_TITLE";
         bttBtndownload_Internalname = "BTNDOWNLOAD";
         bttBtndownloadassinado_Internalname = "BTNDOWNLOADASSINADO";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         lblThehtml_Internalname = "THEHTML";
         Uccontrato_Internalname = "UCCONTRATO";
         divTablecontrato_Internalname = "TABLECONTRATO";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
         Innewwindow_Internalname = "INNEWWINDOW";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtncancel_Internalname = "BTNCANCEL";
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
         bttBtndownloadassinado_Visible = 1;
         edtavContratonome_Jsonclick = "";
         edtavContratonome_Enabled = 1;
         Innewwindow_Target = "";
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 2;
         Uccontrato_Path = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Assinaturas";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV20AssinadoArquivo","fld":"vASSINADOARQUIVO","hsh":true,"type":""},{"av":"AV10Arquivo","fld":"vARQUIVO","hsh":true,"type":""},{"av":"AV8AssinaturaId","fld":"vASSINATURAID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNDOWNLOADASSINADO","prop":"Visible"}]}""");
         setEventMetadata("'DODOWNLOAD'","""{"handler":"E136F2","iparms":[{"av":"AV10Arquivo","fld":"vARQUIVO","hsh":true,"type":""}]""");
         setEventMetadata("'DODOWNLOAD'",""","oparms":[{"av":"Innewwindow_Target","ctrl":"INNEWWINDOW","prop":"Target"}]}""");
         setEventMetadata("'DODOWNLOADASSINADO'","""{"handler":"E146F2","iparms":[{"av":"AV20AssinadoArquivo","fld":"vASSINADOARQUIVO","hsh":true,"type":""}]""");
         setEventMetadata("'DODOWNLOADASSINADO'",""","oparms":[{"av":"Innewwindow_Target","ctrl":"INNEWWINDOW","prop":"Target"}]}""");
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
         AV10Arquivo = new SdtArquivo(context);
         AV20AssinadoArquivo = new SdtArquivo(context);
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
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV17ContratoNome = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblParticipantes_title_Jsonclick = "";
         WebComp_Wcwcassinantes_Component = "";
         OldWcwcassinantes = "";
         lblContrato_title_Jsonclick = "";
         bttBtndownload_Jsonclick = "";
         bttBtndownloadassinado_Jsonclick = "";
         lblThehtml_Jsonclick = "";
         ucUccontrato = new GXUserControl();
         ucInnewwindow = new GXUserControl();
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H006F2_A227ContratoId = new int[1] ;
         H006F2_n227ContratoId = new bool[] {false} ;
         H006F2_A238AssinaturaId = new long[1] ;
         H006F2_A239AssinaturaStatus = new string[] {""} ;
         H006F2_n239AssinaturaStatus = new bool[] {false} ;
         H006F2_A231ArquivoId = new int[1] ;
         H006F2_n231ArquivoId = new bool[] {false} ;
         H006F2_A228ContratoNome = new string[] {""} ;
         H006F2_n228ContratoNome = new bool[] {false} ;
         H006F2_A578ArquivoAssinadoId = new int[1] ;
         H006F2_n578ArquivoAssinadoId = new bool[] {false} ;
         A239AssinaturaStatus = "";
         A228ContratoNome = "";
         AV5AssinaturaStatus = "";
         AV14NomeDoArquivo = "";
         AV15Path = "";
         AV11File = new GxFile(context.GetPhysicalPath());
         AV12GUID = Guid.Empty;
         AV13Source = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpassinaturas__default(),
            new Object[][] {
                new Object[] {
               H006F2_A227ContratoId, H006F2_n227ContratoId, H006F2_A238AssinaturaId, H006F2_A239AssinaturaStatus, H006F2_n239AssinaturaStatus, H006F2_A231ArquivoId, H006F2_n231ArquivoId, H006F2_A228ContratoNome, H006F2_n228ContratoNome, H006F2_A578ArquivoAssinadoId,
               H006F2_n578ArquivoAssinadoId
               }
            }
         );
         WebComp_Wcwcassinantes = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavContratonome_Enabled = 0;
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
      private short nGXWrapped ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int edtavContratonome_Enabled ;
      private int bttBtndownloadassinado_Visible ;
      private int A227ContratoId ;
      private int A231ArquivoId ;
      private int A578ArquivoAssinadoId ;
      private int AV9ArquivoId ;
      private int AV19ArquivoAssinadoId ;
      private int idxLst ;
      private long AV8AssinaturaId ;
      private long wcpOAV8AssinaturaId ;
      private long A238AssinaturaId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Uccontrato_Path ;
      private string Gxuitabspanel_tabs1_Class ;
      private string Innewwindow_Target ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string edtavContratonome_Internalname ;
      private string TempTags ;
      private string edtavContratonome_Jsonclick ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblParticipantes_title_Internalname ;
      private string lblParticipantes_title_Jsonclick ;
      private string divTablepart_Internalname ;
      private string WebComp_Wcwcassinantes_Component ;
      private string OldWcwcassinantes ;
      private string lblContrato_title_Internalname ;
      private string lblContrato_title_Jsonclick ;
      private string divTablecontrato_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string bttBtndownload_Internalname ;
      private string bttBtndownload_Jsonclick ;
      private string bttBtndownloadassinado_Internalname ;
      private string bttBtndownloadassinado_Jsonclick ;
      private string lblThehtml_Internalname ;
      private string lblThehtml_Jsonclick ;
      private string Uccontrato_Internalname ;
      private string Innewwindow_Internalname ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n227ContratoId ;
      private bool n239AssinaturaStatus ;
      private bool n231ArquivoId ;
      private bool n228ContratoNome ;
      private bool n578ArquivoAssinadoId ;
      private bool bDynCreated_Wcwcassinantes ;
      private string AV17ContratoNome ;
      private string A239AssinaturaStatus ;
      private string A228ContratoNome ;
      private string AV5AssinaturaStatus ;
      private string AV14NomeDoArquivo ;
      private string AV15Path ;
      private string AV13Source ;
      private Guid AV12GUID ;
      private GXWebComponent WebComp_Wcwcassinantes ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucUccontrato ;
      private GXUserControl ucInnewwindow ;
      private GxFile AV11File ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private SdtArquivo AV10Arquivo ;
      private SdtArquivo AV20AssinadoArquivo ;
      private IDataStoreProvider pr_default ;
      private int[] H006F2_A227ContratoId ;
      private bool[] H006F2_n227ContratoId ;
      private long[] H006F2_A238AssinaturaId ;
      private string[] H006F2_A239AssinaturaStatus ;
      private bool[] H006F2_n239AssinaturaStatus ;
      private int[] H006F2_A231ArquivoId ;
      private bool[] H006F2_n231ArquivoId ;
      private string[] H006F2_A228ContratoNome ;
      private bool[] H006F2_n228ContratoNome ;
      private int[] H006F2_A578ArquivoAssinadoId ;
      private bool[] H006F2_n578ArquivoAssinadoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpassinaturas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH006F2;
          prmH006F2 = new Object[] {
          new ParDef("AV8AssinaturaId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006F2", "SELECT T1.ContratoId, T1.AssinaturaId, T1.AssinaturaStatus, T1.ArquivoId, T2.ContratoNome, T1.ArquivoAssinadoId FROM (Assinatura T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) WHERE T1.AssinaturaId = :AV8AssinaturaId ORDER BY T1.AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006F2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
