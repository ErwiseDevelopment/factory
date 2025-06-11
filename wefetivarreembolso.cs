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
   public class wefetivarreembolso : GXDataArea
   {
      public wefetivarreembolso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wefetivarreembolso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ReembolsoId )
      {
         this.AV22ReembolsoId = aP0_ReembolsoId;
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
            gxfirstwebparm = GetFirstPar( "ReembolsoId");
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
               gxfirstwebparm = GetFirstPar( "ReembolsoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ReembolsoId");
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
         PA742( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START742( ) ;
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
         GXEncryptionTmp = "wefetivarreembolso"+UrlEncode(StringUtil.LTrimStr(AV22ReembolsoId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wefetivarreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTAID_DATA", AV11ContaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTAID_DATA", AV11ContaId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCATEGORIATITULOID_DATA", AV15CategoriaTituloId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCATEGORIATITULOID_DATA", AV15CategoriaTituloId_Data);
         }
         GxWebStd.gx_hidden_field( context, "CATEGORIATITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTANOMECONTA", A424ContaNomeConta);
         GxWebStd.gx_boolean_hidden_field( context, "CONTASTATUS", A430ContaStatus);
         GxWebStd.gx_hidden_field( context, "CONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Cls", StringUtil.RTrim( Combo_contaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Selectedvalue_set", StringUtil.RTrim( Combo_contaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Emptyitem", StringUtil.BoolToStr( Combo_contaid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Includeaddnewoption", StringUtil.BoolToStr( Combo_contaid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_CATEGORIATITULOID_Cls", StringUtil.RTrim( Combo_categoriatituloid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CATEGORIATITULOID_Selectedvalue_set", StringUtil.RTrim( Combo_categoriatituloid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CATEGORIATITULOID_Emptyitem", StringUtil.BoolToStr( Combo_categoriatituloid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CATEGORIATITULOID_Includeaddnewoption", StringUtil.BoolToStr( Combo_categoriatituloid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_CATEGORIATITULOID_Selectedvalue_get", StringUtil.RTrim( Combo_categoriatituloid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Selectedvalue_get", StringUtil.RTrim( Combo_contaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CATEGORIATITULOID_Selectedvalue_get", StringUtil.RTrim( Combo_categoriatituloid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Selectedvalue_get", StringUtil.RTrim( Combo_contaid_Selectedvalue_get));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE742( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT742( ) ;
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
         GXEncryptionTmp = "wefetivarreembolso"+UrlEncode(StringUtil.LTrimStr(AV22ReembolsoId,9,0));
         return formatLink("wefetivarreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WEfetivarReembolso" ;
      }

      public override string GetPgmdesc( )
      {
         return "Efetivar reembolso" ;
      }

      protected void WB740( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Paciente", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV16ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV16ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento_Internalname, "Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento_Internalname, AV17ClienteDocumento, StringUtil.RTrim( context.localUtil.Format( AV17ClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientedocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatoemail_Internalname, AV18ContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV18ContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatoemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsoprotocolo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoprotocolo_Internalname, "Protocolo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoprotocolo_Internalname, AV19ReembolsoProtocolo, StringUtil.RTrim( context.localUtil.Format( AV19ReembolsoProtocolo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoprotocolo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsoprotocolo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsodataaberturaconvenio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsodataaberturaconvenio_Internalname, "Data abertura no convênio", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavReembolsodataaberturaconvenio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavReembolsodataaberturaconvenio_Internalname, context.localUtil.Format(AV20ReembolsoDataAberturaConvenio, "99/99/9999"), context.localUtil.Format( AV20ReembolsoDataAberturaConvenio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsodataaberturaconvenio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsodataaberturaconvenio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_bitmap( context, edtavReembolsodataaberturaconvenio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavReembolsodataaberturaconvenio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WEfetivarReembolso.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsopropostavalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsopropostavalor_Internalname, "Valor do procedimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsopropostavalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV21ReembolsoPropostaValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavReembolsopropostavalor_Enabled!=0) ? context.localUtil.Format( AV21ReembolsoPropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV21ReembolsoPropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsopropostavalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsopropostavalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostavalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostavalor_Internalname, "Valor do procedimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostavalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV5PropostaValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavPropostavalor_Enabled!=0) ? context.localUtil.Format( AV5PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV5PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostavalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostavalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReembolsovalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsovalor_Internalname, "Valor do reembolso", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsovalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV6ReembolsoValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavReembolsovalor_Enabled!=0) ? context.localUtil.Format( AV6ReembolsoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV6ReembolsoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsovalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavReembolsovalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavData_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavData_Internalname, "Data do reembolso", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavData_Internalname, context.localUtil.Format(AV7Data, "99/99/99"), context.localUtil.Format( AV7Data, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavData_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_bitmap( context, edtavData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WEfetivarReembolso.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcontaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_contaid_Internalname, "Conta", "", "", lblTextblockcombo_contaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_contaid.SetProperty("Caption", Combo_contaid_Caption);
            ucCombo_contaid.SetProperty("Cls", Combo_contaid_Cls);
            ucCombo_contaid.SetProperty("EmptyItem", Combo_contaid_Emptyitem);
            ucCombo_contaid.SetProperty("IncludeAddNewOption", Combo_contaid_Includeaddnewoption);
            ucCombo_contaid.SetProperty("DropDownOptionsData", AV11ContaId_Data);
            ucCombo_contaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_contaid_Internalname, "COMBO_CONTAIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcategoriatituloid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_categoriatituloid_Internalname, "Categoria", "", "", lblTextblockcombo_categoriatituloid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_categoriatituloid.SetProperty("Caption", Combo_categoriatituloid_Caption);
            ucCombo_categoriatituloid.SetProperty("Cls", Combo_categoriatituloid_Cls);
            ucCombo_categoriatituloid.SetProperty("EmptyItem", Combo_categoriatituloid_Emptyitem);
            ucCombo_categoriatituloid.SetProperty("IncludeAddNewOption", Combo_categoriatituloid_Includeaddnewoption);
            ucCombo_categoriatituloid.SetProperty("DropDownOptionsData", AV15CategoriaTituloId_Data);
            ucCombo_categoriatituloid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_categoriatituloid_Internalname, "COMBO_CATEGORIATITULOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WEfetivarReembolso.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ContaId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8ContaId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavContaid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WEfetivarReembolso.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCategoriatituloid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9CategoriaTituloId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9CategoriaTituloId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCategoriatituloid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCategoriatituloid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WEfetivarReembolso.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START742( )
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
         Form.Meta.addItem("description", "Efetivar reembolso", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP740( ) ;
      }

      protected void WS742( )
      {
         START742( ) ;
         EVT742( ) ;
      }

      protected void EVT742( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_CONTAID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_contaid.Onoptionclicked */
                              E11742 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_CATEGORIATITULOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_categoriatituloid.Onoptionclicked */
                              E12742 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E13742 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E14742 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE742( )
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

      protected void PA742( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wefetivarreembolso")), "wefetivarreembolso") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wefetivarreembolso")))) ;
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
                  gxfirstwebparm = GetFirstPar( "ReembolsoId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV22ReembolsoId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV22ReembolsoId", StringUtil.LTrimStr( (decimal)(AV22ReembolsoId), 9, 0));
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
               GX_FocusControl = edtavClienterazaosocial_Internalname;
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
         RF742( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavClientedocumento_Enabled = 0;
         AssignProp("", false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), true);
         edtavContatoemail_Enabled = 0;
         AssignProp("", false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
         edtavReembolsoprotocolo_Enabled = 0;
         AssignProp("", false, edtavReembolsoprotocolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsoprotocolo_Enabled), 5, 0), true);
         edtavReembolsodataaberturaconvenio_Enabled = 0;
         AssignProp("", false, edtavReembolsodataaberturaconvenio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsodataaberturaconvenio_Enabled), 5, 0), true);
         edtavReembolsopropostavalor_Enabled = 0;
         AssignProp("", false, edtavReembolsopropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsopropostavalor_Enabled), 5, 0), true);
         edtavPropostavalor_Enabled = 0;
         AssignProp("", false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
      }

      protected void RF742( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14742 ();
            WB740( ) ;
         }
      }

      protected void send_integrity_lvl_hashes742( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavClientedocumento_Enabled = 0;
         AssignProp("", false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), true);
         edtavContatoemail_Enabled = 0;
         AssignProp("", false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
         edtavReembolsoprotocolo_Enabled = 0;
         AssignProp("", false, edtavReembolsoprotocolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsoprotocolo_Enabled), 5, 0), true);
         edtavReembolsodataaberturaconvenio_Enabled = 0;
         AssignProp("", false, edtavReembolsodataaberturaconvenio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsodataaberturaconvenio_Enabled), 5, 0), true);
         edtavReembolsopropostavalor_Enabled = 0;
         AssignProp("", false, edtavReembolsopropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsopropostavalor_Enabled), 5, 0), true);
         edtavPropostavalor_Enabled = 0;
         AssignProp("", false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP740( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13742 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vCONTAID_DATA"), AV11ContaId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCATEGORIATITULOID_DATA"), AV15CategoriaTituloId_Data);
            /* Read saved values. */
            Combo_contaid_Cls = cgiGet( "COMBO_CONTAID_Cls");
            Combo_contaid_Selectedvalue_set = cgiGet( "COMBO_CONTAID_Selectedvalue_set");
            Combo_contaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONTAID_Emptyitem"));
            Combo_contaid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CONTAID_Includeaddnewoption"));
            Combo_categoriatituloid_Cls = cgiGet( "COMBO_CATEGORIATITULOID_Cls");
            Combo_categoriatituloid_Selectedvalue_set = cgiGet( "COMBO_CATEGORIATITULOID_Selectedvalue_set");
            Combo_categoriatituloid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CATEGORIATITULOID_Emptyitem"));
            Combo_categoriatituloid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CATEGORIATITULOID_Includeaddnewoption"));
            Combo_categoriatituloid_Selectedvalue_get = cgiGet( "COMBO_CATEGORIATITULOID_Selectedvalue_get");
            Combo_contaid_Selectedvalue_get = cgiGet( "COMBO_CONTAID_Selectedvalue_get");
            /* Read variables values. */
            AV16ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AssignAttri("", false, "AV16ClienteRazaoSocial", AV16ClienteRazaoSocial);
            AV17ClienteDocumento = cgiGet( edtavClientedocumento_Internalname);
            AssignAttri("", false, "AV17ClienteDocumento", AV17ClienteDocumento);
            AV18ContatoEmail = cgiGet( edtavContatoemail_Internalname);
            AssignAttri("", false, "AV18ContatoEmail", AV18ContatoEmail);
            AV19ReembolsoProtocolo = cgiGet( edtavReembolsoprotocolo_Internalname);
            AssignAttri("", false, "AV19ReembolsoProtocolo", AV19ReembolsoProtocolo);
            if ( context.localUtil.VCDate( cgiGet( edtavReembolsodataaberturaconvenio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Reembolso Data Abertura Convenio"}), 1, "vREEMBOLSODATAABERTURACONVENIO");
               GX_FocusControl = edtavReembolsodataaberturaconvenio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20ReembolsoDataAberturaConvenio = DateTime.MinValue;
               AssignAttri("", false, "AV20ReembolsoDataAberturaConvenio", context.localUtil.Format(AV20ReembolsoDataAberturaConvenio, "99/99/9999"));
            }
            else
            {
               AV20ReembolsoDataAberturaConvenio = context.localUtil.CToD( cgiGet( edtavReembolsodataaberturaconvenio_Internalname), 2);
               AssignAttri("", false, "AV20ReembolsoDataAberturaConvenio", context.localUtil.Format(AV20ReembolsoDataAberturaConvenio, "99/99/9999"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavReembolsopropostavalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavReembolsopropostavalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREEMBOLSOPROPOSTAVALOR");
               GX_FocusControl = edtavReembolsopropostavalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV21ReembolsoPropostaValor = 0;
               AssignAttri("", false, "AV21ReembolsoPropostaValor", StringUtil.LTrimStr( AV21ReembolsoPropostaValor, 18, 2));
            }
            else
            {
               AV21ReembolsoPropostaValor = context.localUtil.CToN( cgiGet( edtavReembolsopropostavalor_Internalname), ",", ".");
               AssignAttri("", false, "AV21ReembolsoPropostaValor", StringUtil.LTrimStr( AV21ReembolsoPropostaValor, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAVALOR");
               GX_FocusControl = edtavPropostavalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5PropostaValor = 0;
               AssignAttri("", false, "AV5PropostaValor", StringUtil.LTrimStr( AV5PropostaValor, 18, 2));
            }
            else
            {
               AV5PropostaValor = context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".");
               AssignAttri("", false, "AV5PropostaValor", StringUtil.LTrimStr( AV5PropostaValor, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavReembolsovalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavReembolsovalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREEMBOLSOVALOR");
               GX_FocusControl = edtavReembolsovalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6ReembolsoValor = 0;
               AssignAttri("", false, "AV6ReembolsoValor", StringUtil.LTrimStr( AV6ReembolsoValor, 18, 2));
            }
            else
            {
               AV6ReembolsoValor = context.localUtil.CToN( cgiGet( edtavReembolsovalor_Internalname), ",", ".");
               AssignAttri("", false, "AV6ReembolsoValor", StringUtil.LTrimStr( AV6ReembolsoValor, 18, 2));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavData_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data"}), 1, "vDATA");
               GX_FocusControl = edtavData_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Data = DateTime.MinValue;
               AssignAttri("", false, "AV7Data", context.localUtil.Format(AV7Data, "99/99/99"));
            }
            else
            {
               AV7Data = context.localUtil.CToD( cgiGet( edtavData_Internalname), 2);
               AssignAttri("", false, "AV7Data", context.localUtil.Format(AV7Data, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContaid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContaid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTAID");
               GX_FocusControl = edtavContaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8ContaId = 0;
               AssignAttri("", false, "AV8ContaId", StringUtil.LTrimStr( (decimal)(AV8ContaId), 9, 0));
            }
            else
            {
               AV8ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavContaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8ContaId", StringUtil.LTrimStr( (decimal)(AV8ContaId), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCategoriatituloid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCategoriatituloid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCATEGORIATITULOID");
               GX_FocusControl = edtavCategoriatituloid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9CategoriaTituloId = 0;
               AssignAttri("", false, "AV9CategoriaTituloId", StringUtil.LTrimStr( (decimal)(AV9CategoriaTituloId), 9, 0));
            }
            else
            {
               AV9CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCategoriatituloid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9CategoriaTituloId", StringUtil.LTrimStr( (decimal)(AV9CategoriaTituloId), 9, 0));
            }
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
         E13742 ();
         if (returnInSub) return;
      }

      protected void E13742( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavCategoriatituloid_Visible = 0;
         AssignProp("", false, edtavCategoriatituloid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCategoriatituloid_Visible), 5, 0), true);
         edtavContaid_Visible = 0;
         AssignProp("", false, edtavContaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContaid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCONTAID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCATEGORIATITULOID' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E12742( )
      {
         /* Combo_categoriatituloid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_categoriatituloid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "categoriatitulo"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(AV9CategoriaTituloId,9,0));
            context.PopUp(formatLink("categoriatitulo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_categoriatituloid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOCATEGORIATITULOID' */
            S122 ();
            if (returnInSub) return;
            AV13ComboSelectedValue = AV14Session.Get("CATEGORIATITULOID");
            AV14Session.Remove("CATEGORIATITULOID");
            Combo_categoriatituloid_Selectedvalue_set = AV13ComboSelectedValue;
            ucCombo_categoriatituloid.SendProperty(context, "", false, Combo_categoriatituloid_Internalname, "SelectedValue_set", Combo_categoriatituloid_Selectedvalue_set);
            AV9CategoriaTituloId = (int)(Math.Round(NumberUtil.Val( AV13ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9CategoriaTituloId", StringUtil.LTrimStr( (decimal)(AV9CategoriaTituloId), 9, 0));
         }
         else
         {
            AV9CategoriaTituloId = (int)(Math.Round(NumberUtil.Val( Combo_categoriatituloid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9CategoriaTituloId", StringUtil.LTrimStr( (decimal)(AV9CategoriaTituloId), 9, 0));
            /* Execute user subroutine: 'LOADCOMBOCATEGORIATITULOID' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15CategoriaTituloId_Data", AV15CategoriaTituloId_Data);
      }

      protected void E11742( )
      {
         /* Combo_contaid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_contaid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "conta"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(AV8ContaId,9,0));
            context.PopUp(formatLink("conta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_contaid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOCONTAID' */
            S112 ();
            if (returnInSub) return;
            AV13ComboSelectedValue = AV14Session.Get("CONTAID");
            AV14Session.Remove("CONTAID");
            Combo_contaid_Selectedvalue_set = AV13ComboSelectedValue;
            ucCombo_contaid.SendProperty(context, "", false, Combo_contaid_Internalname, "SelectedValue_set", Combo_contaid_Selectedvalue_set);
            AV8ContaId = (int)(Math.Round(NumberUtil.Val( AV13ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8ContaId", StringUtil.LTrimStr( (decimal)(AV8ContaId), 9, 0));
         }
         else
         {
            AV8ContaId = (int)(Math.Round(NumberUtil.Val( Combo_contaid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8ContaId", StringUtil.LTrimStr( (decimal)(AV8ContaId), 9, 0));
            /* Execute user subroutine: 'LOADCOMBOCONTAID' */
            S112 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11ContaId_Data", AV11ContaId_Data);
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV10CheckRequiredFieldsResult = true;
         if ( (Convert.ToDecimal(0)==AV6ReembolsoValor) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Valor do reembolso", "", "", "", "", "", "", "", ""),  "error",  edtavReembolsovalor_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
         }
         if ( (DateTime.MinValue==AV7Data) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Data do reembolso", "", "", "", "", "", "", "", ""),  "error",  edtavData_Internalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
         }
         if ( (0==AV8ContaId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Selecione uma conta",  "error",  Combo_contaid_Ddointernalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
         }
         if ( (0==AV9CategoriaTituloId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Categoria", "", "", "", "", "", "", "", ""),  "error",  Combo_categoriatituloid_Ddointernalname,  "true",  ""));
            AV10CheckRequiredFieldsResult = false;
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOCATEGORIATITULOID' Routine */
         returnInSub = false;
         AV15CategoriaTituloId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H00742 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A426CategoriaTituloId = H00742_A426CategoriaTituloId[0];
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A426CategoriaTituloId), 9, 0));
            AV12Combo_DataItem.gxTpr_Title = StringUtil.Trim( context.localUtil.Format( (decimal)(A426CategoriaTituloId), "ZZZZZZZZ9"));
            AV15CategoriaTituloId_Data.Add(AV12Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_categoriatituloid_Selectedvalue_set = ((0==AV9CategoriaTituloId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV9CategoriaTituloId), 9, 0)));
         ucCombo_categoriatituloid.SendProperty(context, "", false, Combo_categoriatituloid_Internalname, "SelectedValue_set", Combo_categoriatituloid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCONTAID' Routine */
         returnInSub = false;
         AV11ContaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* Using cursor H00743 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A430ContaStatus = H00743_A430ContaStatus[0];
            n430ContaStatus = H00743_n430ContaStatus[0];
            A422ContaId = H00743_A422ContaId[0];
            A424ContaNomeConta = H00743_A424ContaNomeConta[0];
            n424ContaNomeConta = H00743_n424ContaNomeConta[0];
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A422ContaId), 9, 0));
            AV12Combo_DataItem.gxTpr_Title = A424ContaNomeConta;
            AV11ContaId_Data.Add(AV12Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_contaid_Selectedvalue_set = ((0==AV8ContaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV8ContaId), 9, 0)));
         ucCombo_contaid.SendProperty(context, "", false, Combo_contaid_Internalname, "SelectedValue_set", Combo_contaid_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E14742( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV22ReembolsoId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV22ReembolsoId", StringUtil.LTrimStr( (decimal)(AV22ReembolsoId), 9, 0));
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
         PA742( ) ;
         WS742( ) ;
         WE742( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019261842", true, true);
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
         context.AddJavascriptSource("wefetivarreembolso.js", "?202561019261843", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavClienterazaosocial_Internalname = "vCLIENTERAZAOSOCIAL";
         edtavClientedocumento_Internalname = "vCLIENTEDOCUMENTO";
         edtavContatoemail_Internalname = "vCONTATOEMAIL";
         edtavReembolsoprotocolo_Internalname = "vREEMBOLSOPROTOCOLO";
         edtavReembolsodataaberturaconvenio_Internalname = "vREEMBOLSODATAABERTURACONVENIO";
         edtavReembolsopropostavalor_Internalname = "vREEMBOLSOPROPOSTAVALOR";
         edtavPropostavalor_Internalname = "vPROPOSTAVALOR";
         edtavReembolsovalor_Internalname = "vREEMBOLSOVALOR";
         edtavData_Internalname = "vDATA";
         lblTextblockcombo_contaid_Internalname = "TEXTBLOCKCOMBO_CONTAID";
         Combo_contaid_Internalname = "COMBO_CONTAID";
         divTablesplittedcontaid_Internalname = "TABLESPLITTEDCONTAID";
         lblTextblockcombo_categoriatituloid_Internalname = "TEXTBLOCKCOMBO_CATEGORIATITULOID";
         Combo_categoriatituloid_Internalname = "COMBO_CATEGORIATITULOID";
         divTablesplittedcategoriatituloid_Internalname = "TABLESPLITTEDCATEGORIATITULOID";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavContaid_Internalname = "vCONTAID";
         edtavCategoriatituloid_Internalname = "vCATEGORIATITULOID";
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
         edtavCategoriatituloid_Jsonclick = "";
         edtavCategoriatituloid_Visible = 1;
         edtavContaid_Jsonclick = "";
         edtavContaid_Visible = 1;
         edtavData_Jsonclick = "";
         edtavData_Enabled = 1;
         edtavReembolsovalor_Jsonclick = "";
         edtavReembolsovalor_Enabled = 1;
         edtavPropostavalor_Jsonclick = "";
         edtavPropostavalor_Enabled = 1;
         edtavReembolsopropostavalor_Jsonclick = "";
         edtavReembolsopropostavalor_Enabled = 1;
         edtavReembolsodataaberturaconvenio_Jsonclick = "";
         edtavReembolsodataaberturaconvenio_Enabled = 1;
         edtavReembolsoprotocolo_Jsonclick = "";
         edtavReembolsoprotocolo_Enabled = 1;
         edtavContatoemail_Jsonclick = "";
         edtavContatoemail_Enabled = 1;
         edtavClientedocumento_Jsonclick = "";
         edtavClientedocumento_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         Combo_categoriatituloid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_categoriatituloid_Emptyitem = Convert.ToBoolean( 0);
         Combo_categoriatituloid_Cls = "ExtendedCombo AttributeFL";
         Combo_contaid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_contaid_Emptyitem = Convert.ToBoolean( 0);
         Combo_contaid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Efetivar reembolso";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("COMBO_CATEGORIATITULOID.ONOPTIONCLICKED","""{"handler":"E12742","iparms":[{"av":"Combo_categoriatituloid_Selectedvalue_get","ctrl":"COMBO_CATEGORIATITULOID","prop":"SelectedValue_get"},{"av":"AV9CategoriaTituloId","fld":"vCATEGORIATITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A426CategoriaTituloId","fld":"CATEGORIATITULOID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("COMBO_CATEGORIATITULOID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_categoriatituloid_Selectedvalue_set","ctrl":"COMBO_CATEGORIATITULOID","prop":"SelectedValue_set"},{"av":"AV9CategoriaTituloId","fld":"vCATEGORIATITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15CategoriaTituloId_Data","fld":"vCATEGORIATITULOID_DATA","type":""}]}""");
         setEventMetadata("COMBO_CONTAID.ONOPTIONCLICKED","""{"handler":"E11742","iparms":[{"av":"Combo_contaid_Selectedvalue_get","ctrl":"COMBO_CONTAID","prop":"SelectedValue_get"},{"av":"AV8ContaId","fld":"vCONTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A424ContaNomeConta","fld":"CONTANOMECONTA","type":"svchar"},{"av":"A430ContaStatus","fld":"CONTASTATUS","type":"boolean"},{"av":"A422ContaId","fld":"CONTAID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("COMBO_CONTAID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_contaid_Selectedvalue_set","ctrl":"COMBO_CONTAID","prop":"SelectedValue_set"},{"av":"AV8ContaId","fld":"vCONTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11ContaId_Data","fld":"vCONTAID_DATA","type":""}]}""");
         setEventMetadata("VALIDV_CONTATOEMAIL","""{"handler":"Validv_Contatoemail","iparms":[]}""");
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
         Combo_categoriatituloid_Selectedvalue_get = "";
         Combo_contaid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11ContaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV15CategoriaTituloId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A424ContaNomeConta = "";
         Combo_contaid_Selectedvalue_set = "";
         Combo_categoriatituloid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV16ClienteRazaoSocial = "";
         AV17ClienteDocumento = "";
         AV18ContatoEmail = "";
         AV19ReembolsoProtocolo = "";
         AV20ReembolsoDataAberturaConvenio = DateTime.MinValue;
         AV7Data = DateTime.MinValue;
         lblTextblockcombo_contaid_Jsonclick = "";
         ucCombo_contaid = new GXUserControl();
         Combo_contaid_Caption = "";
         lblTextblockcombo_categoriatituloid_Jsonclick = "";
         ucCombo_categoriatituloid = new GXUserControl();
         Combo_categoriatituloid_Caption = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV13ComboSelectedValue = "";
         AV14Session = context.GetSession();
         Combo_contaid_Ddointernalname = "";
         Combo_categoriatituloid_Ddointernalname = "";
         H00742_A426CategoriaTituloId = new int[1] ;
         AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H00743_A430ContaStatus = new bool[] {false} ;
         H00743_n430ContaStatus = new bool[] {false} ;
         H00743_A422ContaId = new int[1] ;
         H00743_A424ContaNomeConta = new string[] {""} ;
         H00743_n424ContaNomeConta = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wefetivarreembolso__default(),
            new Object[][] {
                new Object[] {
               H00742_A426CategoriaTituloId
               }
               , new Object[] {
               H00743_A430ContaStatus, H00743_n430ContaStatus, H00743_A422ContaId, H00743_A424ContaNomeConta, H00743_n424ContaNomeConta
               }
            }
         );
         /* GeneXus formulas. */
         edtavClienterazaosocial_Enabled = 0;
         edtavClientedocumento_Enabled = 0;
         edtavContatoemail_Enabled = 0;
         edtavReembolsoprotocolo_Enabled = 0;
         edtavReembolsodataaberturaconvenio_Enabled = 0;
         edtavReembolsopropostavalor_Enabled = 0;
         edtavPropostavalor_Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV22ReembolsoId ;
      private int wcpOAV22ReembolsoId ;
      private int A426CategoriaTituloId ;
      private int A422ContaId ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavClientedocumento_Enabled ;
      private int edtavContatoemail_Enabled ;
      private int edtavReembolsoprotocolo_Enabled ;
      private int edtavReembolsodataaberturaconvenio_Enabled ;
      private int edtavReembolsopropostavalor_Enabled ;
      private int edtavPropostavalor_Enabled ;
      private int edtavReembolsovalor_Enabled ;
      private int edtavData_Enabled ;
      private int AV8ContaId ;
      private int edtavContaid_Visible ;
      private int AV9CategoriaTituloId ;
      private int edtavCategoriatituloid_Visible ;
      private int idxLst ;
      private decimal AV21ReembolsoPropostaValor ;
      private decimal AV5PropostaValor ;
      private decimal AV6ReembolsoValor ;
      private string Combo_categoriatituloid_Selectedvalue_get ;
      private string Combo_contaid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_contaid_Cls ;
      private string Combo_contaid_Selectedvalue_set ;
      private string Combo_categoriatituloid_Cls ;
      private string Combo_categoriatituloid_Selectedvalue_set ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string edtavClienterazaosocial_Internalname ;
      private string TempTags ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string edtavClientedocumento_Internalname ;
      private string edtavClientedocumento_Jsonclick ;
      private string edtavContatoemail_Internalname ;
      private string edtavContatoemail_Jsonclick ;
      private string edtavReembolsoprotocolo_Internalname ;
      private string edtavReembolsoprotocolo_Jsonclick ;
      private string edtavReembolsodataaberturaconvenio_Internalname ;
      private string edtavReembolsodataaberturaconvenio_Jsonclick ;
      private string edtavReembolsopropostavalor_Internalname ;
      private string edtavReembolsopropostavalor_Jsonclick ;
      private string edtavPropostavalor_Internalname ;
      private string edtavPropostavalor_Jsonclick ;
      private string edtavReembolsovalor_Internalname ;
      private string edtavReembolsovalor_Jsonclick ;
      private string edtavData_Internalname ;
      private string edtavData_Jsonclick ;
      private string divTablesplittedcontaid_Internalname ;
      private string lblTextblockcombo_contaid_Internalname ;
      private string lblTextblockcombo_contaid_Jsonclick ;
      private string Combo_contaid_Caption ;
      private string Combo_contaid_Internalname ;
      private string divTablesplittedcategoriatituloid_Internalname ;
      private string lblTextblockcombo_categoriatituloid_Internalname ;
      private string lblTextblockcombo_categoriatituloid_Jsonclick ;
      private string Combo_categoriatituloid_Caption ;
      private string Combo_categoriatituloid_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavContaid_Internalname ;
      private string edtavContaid_Jsonclick ;
      private string edtavCategoriatituloid_Internalname ;
      private string edtavCategoriatituloid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Combo_contaid_Ddointernalname ;
      private string Combo_categoriatituloid_Ddointernalname ;
      private DateTime AV20ReembolsoDataAberturaConvenio ;
      private DateTime AV7Data ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A430ContaStatus ;
      private bool Combo_contaid_Emptyitem ;
      private bool Combo_contaid_Includeaddnewoption ;
      private bool Combo_categoriatituloid_Emptyitem ;
      private bool Combo_categoriatituloid_Includeaddnewoption ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV10CheckRequiredFieldsResult ;
      private bool n430ContaStatus ;
      private bool n424ContaNomeConta ;
      private string A424ContaNomeConta ;
      private string AV16ClienteRazaoSocial ;
      private string AV17ClienteDocumento ;
      private string AV18ContatoEmail ;
      private string AV19ReembolsoProtocolo ;
      private string AV13ComboSelectedValue ;
      private IGxSession AV14Session ;
      private GXUserControl ucCombo_contaid ;
      private GXUserControl ucCombo_categoriatituloid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11ContaId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15CategoriaTituloId_Data ;
      private IDataStoreProvider pr_default ;
      private int[] H00742_A426CategoriaTituloId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private bool[] H00743_A430ContaStatus ;
      private bool[] H00743_n430ContaStatus ;
      private int[] H00743_A422ContaId ;
      private string[] H00743_A424ContaNomeConta ;
      private bool[] H00743_n424ContaNomeConta ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wefetivarreembolso__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00742;
          prmH00742 = new Object[] {
          };
          Object[] prmH00743;
          prmH00743 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00742", "SELECT CategoriaTituloId FROM CategoriaTitulo ORDER BY CategoriaTituloId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00742,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00743", "SELECT ContaStatus, ContaId, ContaNomeConta FROM Conta WHERE ContaStatus ORDER BY ContaNomeConta ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00743,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
