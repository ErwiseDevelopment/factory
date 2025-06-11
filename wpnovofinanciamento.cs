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
   public class wpnovofinanciamento : GXDataArea
   {
      public wpnovofinanciamento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpnovofinanciamento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavClientetipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpagecliente", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpagecliente", new Object[] {context});
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
         PA4D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4D2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpnovofinanciamento") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV39WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV39WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV39WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETIPOPESSOA", AV24ClienteTipoPessoa);
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETIPOPESSOA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24ClienteTipoPessoa, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTETIPO_DATA", AV22ClienteTipo_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTETIPO_DATA", AV22ClienteTipo_Data);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISCPFUSED", AV36IsCPFUsed);
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38ClienteId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV39WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV39WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV39WWPContext, context));
         GxWebStd.gx_hidden_field( context, "CLIENTEDOCUMENTO", A169ClienteDocumento);
         GxWebStd.gx_hidden_field( context, "CLIENTERAZAOSOCIAL", A170ClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ENDERECOBAIRRO", A184EnderecoBairro);
         GxWebStd.gx_hidden_field( context, "ENDERECOCEP", A182EnderecoCEP);
         GxWebStd.gx_hidden_field( context, "ENDERECOCIDADE", A185EnderecoCidade);
         GxWebStd.gx_hidden_field( context, "ENDERECOCOMPLEMENTO", A191EnderecoComplemento);
         GxWebStd.gx_hidden_field( context, "ENDERECOLOGRADOURO", A183EnderecoLogradouro);
         GxWebStd.gx_hidden_field( context, "ENDERECONUMERO", A190EnderecoNumero);
         GxWebStd.gx_hidden_field( context, "CONTATODDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A198ContatoDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTATODDI", StringUtil.LTrim( StringUtil.NToC( (decimal)(A199ContatoDDI), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTATOEMAIL", A201ContatoEmail);
         GxWebStd.gx_hidden_field( context, "CONTATONUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A200ContatoNumero), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTATOTELEFONEDDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A203ContatoTelefoneDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTATOTELEFONEDDI", StringUtil.LTrim( StringUtil.NToC( (decimal)(A204ContatoTelefoneDDI), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTATOTELEFONENUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A202ContatoTelefoneNumero), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vCLIENTETIPOPESSOA", AV24ClienteTipoPessoa);
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETIPOPESSOA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24ClienteTipoPessoa, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vENDERECOCOMPLETO", AV29EnderecoCompleto);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vENDERECOCOMPLETO", AV29EnderecoCompleto);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTETIPO_Cls", StringUtil.RTrim( Combo_clientetipo_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTETIPO_Selectedvalue_set", StringUtil.RTrim( Combo_clientetipo_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTETIPO_Emptyitem", StringUtil.BoolToStr( Combo_clientetipo_Emptyitem));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Width", StringUtil.RTrim( Dvpanel_tableinfo_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Autowidth", StringUtil.BoolToStr( Dvpanel_tableinfo_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Autoheight", StringUtil.BoolToStr( Dvpanel_tableinfo_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Cls", StringUtil.RTrim( Dvpanel_tableinfo_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Title", StringUtil.RTrim( Dvpanel_tableinfo_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Collapsible", StringUtil.BoolToStr( Dvpanel_tableinfo_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Collapsed", StringUtil.BoolToStr( Dvpanel_tableinfo_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableinfo_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Iconposition", StringUtil.RTrim( Dvpanel_tableinfo_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEINFO_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableinfo_Autoscroll));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTETIPO_Selectedvalue_get", StringUtil.RTrim( Combo_clientetipo_Selectedvalue_get));
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
            WE4D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4D2( ) ;
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
         return formatLink("wpnovofinanciamento")  ;
      }

      public override string GetPgmname( )
      {
         return "WpNovoFinanciamento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Novo financiamento" ;
      }

      protected void WB4D0( )
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
            /* User Defined Control */
            ucDvpanel_tableinfo.SetProperty("Width", Dvpanel_tableinfo_Width);
            ucDvpanel_tableinfo.SetProperty("AutoWidth", Dvpanel_tableinfo_Autowidth);
            ucDvpanel_tableinfo.SetProperty("AutoHeight", Dvpanel_tableinfo_Autoheight);
            ucDvpanel_tableinfo.SetProperty("Cls", Dvpanel_tableinfo_Cls);
            ucDvpanel_tableinfo.SetProperty("Title", Dvpanel_tableinfo_Title);
            ucDvpanel_tableinfo.SetProperty("Collapsible", Dvpanel_tableinfo_Collapsible);
            ucDvpanel_tableinfo.SetProperty("Collapsed", Dvpanel_tableinfo_Collapsed);
            ucDvpanel_tableinfo.SetProperty("ShowCollapseIcon", Dvpanel_tableinfo_Showcollapseicon);
            ucDvpanel_tableinfo.SetProperty("IconPosition", Dvpanel_tableinfo_Iconposition);
            ucDvpanel_tableinfo.SetProperty("AutoScroll", Dvpanel_tableinfo_Autoscroll);
            ucDvpanel_tableinfo.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableinfo_Internalname, "DVPANEL_TABLEINFOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEINFOContainer"+"TableInfo"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableinfo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento_Internalname, AV5ClienteDocumento, StringUtil.RTrim( context.localUtil.Format( AV5ClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientedocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Nome completo", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV6ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV6ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedclientetipo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_clientetipo_Internalname, "Tipo", "", "", lblTextblockcombo_clientetipo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_clientetipo.SetProperty("Caption", Combo_clientetipo_Caption);
            ucCombo_clientetipo.SetProperty("Cls", Combo_clientetipo_Cls);
            ucCombo_clientetipo.SetProperty("EmptyItem", Combo_clientetipo_Emptyitem);
            ucCombo_clientetipo.SetProperty("DropDownOptionsData", AV22ClienteTipo_Data);
            ucCombo_clientetipo.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_clientetipo_Internalname, "COMBO_CLIENTETIPOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavValor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValor_Internalname, "Valor do financiamento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV27Valor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavValor_Enabled!=0) ? context.localUtil.Format( AV27Valor, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV27Valor, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Endereço", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovoFinanciamento.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableendereco_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCep_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCep_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCep_Internalname, AV28CEP, StringUtil.RTrim( context.localUtil.Format( AV28CEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCep_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCep_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnderecobairro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnderecobairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecobairro_Internalname, AV9EnderecoBairro, StringUtil.RTrim( context.localUtil.Format( AV9EnderecoBairro, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecobairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEnderecobairro_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnderecocidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnderecocidade_Internalname, "Cidade", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecocidade_Internalname, AV10EnderecoCidade, StringUtil.RTrim( context.localUtil.Format( AV10EnderecoCidade, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecocidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEnderecocidade_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnderecocomplemento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnderecocomplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecocomplemento_Internalname, AV11EnderecoComplemento, StringUtil.RTrim( context.localUtil.Format( AV11EnderecoComplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecocomplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEnderecocomplemento_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnderecologradouro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnderecologradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecologradouro_Internalname, AV12EnderecoLogradouro, StringUtil.RTrim( context.localUtil.Format( AV12EnderecoLogradouro, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecologradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEnderecologradouro_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEndereconumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEndereconumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEndereconumero_Internalname, AV13EnderecoNumero, StringUtil.RTrim( context.localUtil.Format( AV13EnderecoNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEndereconumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavEndereconumero_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Contato", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovoFinanciamento.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontatos_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatoemail_Internalname, AV14ContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV14ContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatoemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, "Celular", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovoFinanciamento.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecelular_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatoddd_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatoddd_Internalname, "DDD", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatoddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15ContatoDDD), 4, 0, ",", "")), StringUtil.LTrim( ((edtavContatoddd_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15ContatoDDD), "ZZZ9") : context.localUtil.Format( (decimal)(AV15ContatoDDD), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatoddd_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatoddd_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatonumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatonumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatonumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17ContatoNumero), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContatonumero_Enabled!=0) ? context.localUtil.Format( (decimal)(AV17ContatoNumero), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV17ContatoNumero), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatonumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatonumero_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, "Telefone", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovoFinanciamento.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletelefone_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatotelefoneddd_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatotelefoneddd_Internalname, "DDD", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatotelefoneddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ContatoTelefoneDDD), 4, 0, ",", "")), StringUtil.LTrim( ((edtavContatotelefoneddd_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ContatoTelefoneDDD), "ZZZ9") : context.localUtil.Format( (decimal)(AV18ContatoTelefoneDDD), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatotelefoneddd_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatotelefoneddd_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatotelefonenumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatotelefonenumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatotelefonenumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ContatoTelefoneNumero), 18, 0, ",", "")), StringUtil.LTrim( ((edtavContatotelefonenumero_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ContatoTelefoneNumero), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV20ContatoTelefoneNumero), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatotelefonenumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatotelefonenumero_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpNovoFinanciamento.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClientetipo, cmbavClientetipo_Internalname, StringUtil.RTrim( AV7ClienteTipo), 1, cmbavClientetipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavClientetipo.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"", "", true, 0, "HLP_WpNovoFinanciamento.htm");
            cmbavClientetipo.CurrentValue = StringUtil.RTrim( AV7ClienteTipo);
            AssignProp("", false, cmbavClientetipo_Internalname, "Values", (string)(cmbavClientetipo.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnderecocep_Internalname, AV8EnderecoCEP, StringUtil.RTrim( context.localUtil.Format( AV8EnderecoCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnderecocep_Jsonclick, 0, "Attribute", "", "", "", "", edtavEnderecocep_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovoFinanciamento.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4D2( )
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
         Form.Meta.addItem("description", "Novo financiamento", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4D0( ) ;
      }

      protected void WS4D2( )
      {
         START4D2( ) ;
         EVT4D2( ) ;
      }

      protected void EVT4D2( )
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
                              E114D2 ();
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
                                    E124D2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCLIENTEDOCUMENTO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCEP.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E144D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E154D2 ();
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

      protected void WE4D2( )
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

      protected void PA4D2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               GX_FocusControl = edtavClientedocumento_Internalname;
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
         if ( cmbavClientetipo.ItemCount > 0 )
         {
            AV7ClienteTipo = cmbavClientetipo.getValidValue(AV7ClienteTipo);
            AssignAttri("", false, "AV7ClienteTipo", AV7ClienteTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClientetipo.CurrentValue = StringUtil.RTrim( AV7ClienteTipo);
            AssignProp("", false, cmbavClientetipo_Internalname, "Values", cmbavClientetipo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF4D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E154D2 ();
            WB4D0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4D2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV39WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV39WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV39WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vCLIENTETIPOPESSOA", AV24ClienteTipoPessoa);
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETIPOPESSOA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24ClienteTipoPessoa, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vCLIENTETIPO_DATA"), AV22ClienteTipo_Data);
            /* Read saved values. */
            Combo_clientetipo_Cls = cgiGet( "COMBO_CLIENTETIPO_Cls");
            Combo_clientetipo_Selectedvalue_set = cgiGet( "COMBO_CLIENTETIPO_Selectedvalue_set");
            Combo_clientetipo_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTETIPO_Emptyitem"));
            Dvpanel_tableinfo_Width = cgiGet( "DVPANEL_TABLEINFO_Width");
            Dvpanel_tableinfo_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINFO_Autowidth"));
            Dvpanel_tableinfo_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINFO_Autoheight"));
            Dvpanel_tableinfo_Cls = cgiGet( "DVPANEL_TABLEINFO_Cls");
            Dvpanel_tableinfo_Title = cgiGet( "DVPANEL_TABLEINFO_Title");
            Dvpanel_tableinfo_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINFO_Collapsible"));
            Dvpanel_tableinfo_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINFO_Collapsed"));
            Dvpanel_tableinfo_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINFO_Showcollapseicon"));
            Dvpanel_tableinfo_Iconposition = cgiGet( "DVPANEL_TABLEINFO_Iconposition");
            Dvpanel_tableinfo_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEINFO_Autoscroll"));
            /* Read variables values. */
            AV5ClienteDocumento = cgiGet( edtavClientedocumento_Internalname);
            AssignAttri("", false, "AV5ClienteDocumento", AV5ClienteDocumento);
            AV6ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AssignAttri("", false, "AV6ClienteRazaoSocial", AV6ClienteRazaoSocial);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALOR");
               GX_FocusControl = edtavValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27Valor = 0;
               AssignAttri("", false, "AV27Valor", StringUtil.LTrimStr( AV27Valor, 18, 2));
            }
            else
            {
               AV27Valor = context.localUtil.CToN( cgiGet( edtavValor_Internalname), ",", ".");
               AssignAttri("", false, "AV27Valor", StringUtil.LTrimStr( AV27Valor, 18, 2));
            }
            AV28CEP = cgiGet( edtavCep_Internalname);
            AssignAttri("", false, "AV28CEP", AV28CEP);
            AV9EnderecoBairro = StringUtil.Upper( cgiGet( edtavEnderecobairro_Internalname));
            AssignAttri("", false, "AV9EnderecoBairro", AV9EnderecoBairro);
            AV10EnderecoCidade = StringUtil.Upper( cgiGet( edtavEnderecocidade_Internalname));
            AssignAttri("", false, "AV10EnderecoCidade", AV10EnderecoCidade);
            AV11EnderecoComplemento = cgiGet( edtavEnderecocomplemento_Internalname);
            AssignAttri("", false, "AV11EnderecoComplemento", AV11EnderecoComplemento);
            AV12EnderecoLogradouro = StringUtil.Upper( cgiGet( edtavEnderecologradouro_Internalname));
            AssignAttri("", false, "AV12EnderecoLogradouro", AV12EnderecoLogradouro);
            AV13EnderecoNumero = cgiGet( edtavEndereconumero_Internalname);
            AssignAttri("", false, "AV13EnderecoNumero", AV13EnderecoNumero);
            AV14ContatoEmail = cgiGet( edtavContatoemail_Internalname);
            AssignAttri("", false, "AV14ContatoEmail", AV14ContatoEmail);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContatoddd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContatoddd_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTATODDD");
               GX_FocusControl = edtavContatoddd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15ContatoDDD = 0;
               AssignAttri("", false, "AV15ContatoDDD", StringUtil.LTrimStr( (decimal)(AV15ContatoDDD), 4, 0));
            }
            else
            {
               AV15ContatoDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavContatoddd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15ContatoDDD", StringUtil.LTrimStr( (decimal)(AV15ContatoDDD), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContatonumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContatonumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTATONUMERO");
               GX_FocusControl = edtavContatonumero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17ContatoNumero = 0;
               AssignAttri("", false, "AV17ContatoNumero", StringUtil.LTrimStr( (decimal)(AV17ContatoNumero), 18, 0));
            }
            else
            {
               AV17ContatoNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavContatonumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV17ContatoNumero", StringUtil.LTrimStr( (decimal)(AV17ContatoNumero), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContatotelefoneddd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContatotelefoneddd_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTATOTELEFONEDDD");
               GX_FocusControl = edtavContatotelefoneddd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18ContatoTelefoneDDD = 0;
               AssignAttri("", false, "AV18ContatoTelefoneDDD", StringUtil.LTrimStr( (decimal)(AV18ContatoTelefoneDDD), 4, 0));
            }
            else
            {
               AV18ContatoTelefoneDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavContatotelefoneddd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18ContatoTelefoneDDD", StringUtil.LTrimStr( (decimal)(AV18ContatoTelefoneDDD), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContatotelefonenumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContatotelefonenumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTATOTELEFONENUMERO");
               GX_FocusControl = edtavContatotelefonenumero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20ContatoTelefoneNumero = 0;
               AssignAttri("", false, "AV20ContatoTelefoneNumero", StringUtil.LTrimStr( (decimal)(AV20ContatoTelefoneNumero), 18, 0));
            }
            else
            {
               AV20ContatoTelefoneNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavContatotelefonenumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ContatoTelefoneNumero", StringUtil.LTrimStr( (decimal)(AV20ContatoTelefoneNumero), 18, 0));
            }
            cmbavClientetipo.CurrentValue = cgiGet( cmbavClientetipo_Internalname);
            AV7ClienteTipo = cgiGet( cmbavClientetipo_Internalname);
            AssignAttri("", false, "AV7ClienteTipo", AV7ClienteTipo);
            AV8EnderecoCEP = cgiGet( edtavEnderecocep_Internalname);
            AssignAttri("", false, "AV8EnderecoCEP", AV8EnderecoCEP);
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
         E114D2 ();
         if (returnInSub) return;
      }

      protected void E114D2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV39WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV39WWPContext = GXt_SdtWWPContext1;
         cmbavClientetipo.Visible = 0;
         AssignProp("", false, cmbavClientetipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavClientetipo.Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCLIENTETIPO' */
         S112 ();
         if (returnInSub) return;
         this.executeExternalObjectMethod("", false, "WWPActions", "Mask_Apply", new Object[] {(string)edtavClientedocumento_Internalname,"000.000.000-00",(bool)false,(bool)false}, false);
         edtavEnderecocep_Visible = 0;
         AssignProp("", false, edtavEnderecocep_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEnderecocep_Visible), 5, 0), true);
         AV24ClienteTipoPessoa = "FISICA";
         AssignAttri("", false, "AV24ClienteTipoPessoa", AV24ClienteTipoPessoa);
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTETIPOPESSOA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24ClienteTipoPessoa, "")), context));
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E124D2 ();
         if (returnInSub) return;
      }

      protected void E124D2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( AV36IsCPFUsed )
         {
            AV37Financiamento = new SdtFinanciamento(context);
            AV37Financiamento.gxTpr_Clienteid = AV38ClienteId;
            AV37Financiamento.gxTpr_Financiamentovalor = AV27Valor;
            AV37Financiamento.gxTpr_Financiamentostatus = "EM_ANALISE";
            AV37Financiamento.gxTpr_Intermediadorclienteid = AV39WWPContext.gxTpr_Ownerid;
            AV37Financiamento.Save();
            if ( AV37Financiamento.Success() )
            {
               context.CommitDataStores("wpnovofinanciamento",pr_default);
            }
            else
            {
               GX_msglist.addItem(((GeneXus.Utils.SdtMessages_Message)AV37Financiamento.GetMessages().Item(1)).gxTpr_Description);
            }
         }
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV21CheckRequiredFieldsResult = true;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5ClienteDocumento)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CPF", "", "", "", "", "", "", "", ""),  "error",  edtavClientedocumento_Internalname,  "true",  ""));
            AV21CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6ClienteRazaoSocial)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Nome completo", "", "", "", "", "", "", "", ""),  "error",  edtavClienterazaosocial_Internalname,  "true",  ""));
            AV21CheckRequiredFieldsResult = false;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7ClienteTipo)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Tipo", "", "", "", "", "", "", "", ""),  "error",  Combo_clientetipo_Ddointernalname,  "true",  ""));
            AV21CheckRequiredFieldsResult = false;
         }
         /* Execute user subroutine: 'VALIDADOCUMENTO' */
         S122 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCLIENTETIPO' Routine */
         returnInSub = false;
         AV7ClienteTipo = "";
         AssignAttri("", false, "AV7ClienteTipo", AV7ClienteTipo);
         /* Using cursor H004D2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A219TipoClienteFinancia = H004D2_A219TipoClienteFinancia[0];
            n219TipoClienteFinancia = H004D2_n219TipoClienteFinancia[0];
            A192TipoClienteId = H004D2_A192TipoClienteId[0];
            A193TipoClienteDescricao = H004D2_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = H004D2_n193TipoClienteDescricao[0];
            AV23Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV23Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A192TipoClienteId), 4, 0));
            AV23Combo_DataItem.gxTpr_Title = A193TipoClienteDescricao;
            AV22ClienteTipo_Data.Add(AV23Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_clientetipo_Selectedvalue_set = AV7ClienteTipo;
         ucCombo_clientetipo.SendProperty(context, "", false, Combo_clientetipo_Internalname, "SelectedValue_set", Combo_clientetipo_Selectedvalue_set);
      }

      protected void E134D2( )
      {
         /* Clientedocumento_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDADOCUMENTO' */
         S122 ();
         if (returnInSub) return;
         AV35AuxClienteDocumento = StringUtil.StringReplace( AV5ClienteDocumento, "-", "");
         AssignAttri("", false, "AV35AuxClienteDocumento", AV35AuxClienteDocumento);
         AV35AuxClienteDocumento = StringUtil.StringReplace( AV35AuxClienteDocumento, ".", "");
         AssignAttri("", false, "AV35AuxClienteDocumento", AV35AuxClienteDocumento);
         AV36IsCPFUsed = false;
         AssignAttri("", false, "AV36IsCPFUsed", AV36IsCPFUsed);
         /* Using cursor H004D3 */
         pr_default.execute(1, new Object[] {AV35AuxClienteDocumento});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A169ClienteDocumento = H004D3_A169ClienteDocumento[0];
            n169ClienteDocumento = H004D3_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = H004D3_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H004D3_n170ClienteRazaoSocial[0];
            A168ClienteId = H004D3_A168ClienteId[0];
            A184EnderecoBairro = H004D3_A184EnderecoBairro[0];
            n184EnderecoBairro = H004D3_n184EnderecoBairro[0];
            A182EnderecoCEP = H004D3_A182EnderecoCEP[0];
            n182EnderecoCEP = H004D3_n182EnderecoCEP[0];
            A185EnderecoCidade = H004D3_A185EnderecoCidade[0];
            n185EnderecoCidade = H004D3_n185EnderecoCidade[0];
            A191EnderecoComplemento = H004D3_A191EnderecoComplemento[0];
            n191EnderecoComplemento = H004D3_n191EnderecoComplemento[0];
            A183EnderecoLogradouro = H004D3_A183EnderecoLogradouro[0];
            n183EnderecoLogradouro = H004D3_n183EnderecoLogradouro[0];
            A190EnderecoNumero = H004D3_A190EnderecoNumero[0];
            n190EnderecoNumero = H004D3_n190EnderecoNumero[0];
            A198ContatoDDD = H004D3_A198ContatoDDD[0];
            n198ContatoDDD = H004D3_n198ContatoDDD[0];
            A199ContatoDDI = H004D3_A199ContatoDDI[0];
            n199ContatoDDI = H004D3_n199ContatoDDI[0];
            A201ContatoEmail = H004D3_A201ContatoEmail[0];
            n201ContatoEmail = H004D3_n201ContatoEmail[0];
            A200ContatoNumero = H004D3_A200ContatoNumero[0];
            n200ContatoNumero = H004D3_n200ContatoNumero[0];
            A203ContatoTelefoneDDD = H004D3_A203ContatoTelefoneDDD[0];
            n203ContatoTelefoneDDD = H004D3_n203ContatoTelefoneDDD[0];
            A204ContatoTelefoneDDI = H004D3_A204ContatoTelefoneDDI[0];
            n204ContatoTelefoneDDI = H004D3_n204ContatoTelefoneDDI[0];
            A202ContatoTelefoneNumero = H004D3_A202ContatoTelefoneNumero[0];
            n202ContatoTelefoneNumero = H004D3_n202ContatoTelefoneNumero[0];
            AV36IsCPFUsed = true;
            AssignAttri("", false, "AV36IsCPFUsed", AV36IsCPFUsed);
            AV6ClienteRazaoSocial = A170ClienteRazaoSocial;
            AssignAttri("", false, "AV6ClienteRazaoSocial", AV6ClienteRazaoSocial);
            AV38ClienteId = A168ClienteId;
            AssignAttri("", false, "AV38ClienteId", StringUtil.LTrimStr( (decimal)(AV38ClienteId), 9, 0));
            AV9EnderecoBairro = A184EnderecoBairro;
            AssignAttri("", false, "AV9EnderecoBairro", AV9EnderecoBairro);
            AV8EnderecoCEP = A182EnderecoCEP;
            AssignAttri("", false, "AV8EnderecoCEP", AV8EnderecoCEP);
            AV28CEP = A182EnderecoCEP;
            AssignAttri("", false, "AV28CEP", AV28CEP);
            AV10EnderecoCidade = A185EnderecoCidade;
            AssignAttri("", false, "AV10EnderecoCidade", AV10EnderecoCidade);
            AV11EnderecoComplemento = A191EnderecoComplemento;
            AssignAttri("", false, "AV11EnderecoComplemento", AV11EnderecoComplemento);
            AV12EnderecoLogradouro = A183EnderecoLogradouro;
            AssignAttri("", false, "AV12EnderecoLogradouro", AV12EnderecoLogradouro);
            AV13EnderecoNumero = A190EnderecoNumero;
            AssignAttri("", false, "AV13EnderecoNumero", AV13EnderecoNumero);
            edtavEnderecobairro_Enabled = 0;
            AssignProp("", false, edtavEnderecobairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecobairro_Enabled), 5, 0), true);
            edtavEnderecocidade_Enabled = 0;
            AssignProp("", false, edtavEnderecocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecocidade_Enabled), 5, 0), true);
            edtavEnderecologradouro_Enabled = 0;
            AssignProp("", false, edtavEnderecologradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecologradouro_Enabled), 5, 0), true);
            AV15ContatoDDD = A198ContatoDDD;
            AssignAttri("", false, "AV15ContatoDDD", StringUtil.LTrimStr( (decimal)(AV15ContatoDDD), 4, 0));
            AV16ContatoDDI = A199ContatoDDI;
            AV14ContatoEmail = A201ContatoEmail;
            AssignAttri("", false, "AV14ContatoEmail", AV14ContatoEmail);
            AV17ContatoNumero = A200ContatoNumero;
            AssignAttri("", false, "AV17ContatoNumero", StringUtil.LTrimStr( (decimal)(AV17ContatoNumero), 18, 0));
            AV18ContatoTelefoneDDD = A203ContatoTelefoneDDD;
            AssignAttri("", false, "AV18ContatoTelefoneDDD", StringUtil.LTrimStr( (decimal)(AV18ContatoTelefoneDDD), 4, 0));
            AV19ContatoTelefoneDDI = A204ContatoTelefoneDDI;
            AV20ContatoTelefoneNumero = A202ContatoTelefoneNumero;
            AssignAttri("", false, "AV20ContatoTelefoneNumero", StringUtil.LTrimStr( (decimal)(AV20ContatoTelefoneNumero), 18, 0));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         /*  Sending Event outputs  */
      }

      protected void E144D2( )
      {
         /* Cep_Controlvaluechanged Routine */
         returnInSub = false;
         AV28CEP = StringUtil.StringReplace( AV28CEP, "-", "");
         AssignAttri("", false, "AV28CEP", AV28CEP);
         AV29EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28CEP)) )
         {
            new GeneXus.Programs.myobjects.viacep.cepparaendereco(context ).execute(  AV28CEP, out  AV30ModeloRetorno, out  AV31Mensagem) ;
            AV29EnderecoCompleto.FromJSonString(AV30ModeloRetorno, null);
            /* Execute user subroutine: 'VALIDACEP' */
            S132 ();
            if (returnInSub) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29EnderecoCompleto.gxTpr_Cep)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "",  "error",  edtavEndereconumero_Internalname,  "true",  ""));
         }
         AV9EnderecoBairro = AV29EnderecoCompleto.gxTpr_Bairro;
         AssignAttri("", false, "AV9EnderecoBairro", AV9EnderecoBairro);
         AV10EnderecoCidade = AV29EnderecoCompleto.gxTpr_Localidade;
         AssignAttri("", false, "AV10EnderecoCidade", AV10EnderecoCidade);
         AV12EnderecoLogradouro = AV29EnderecoCompleto.gxTpr_Logradouro;
         AssignAttri("", false, "AV12EnderecoLogradouro", AV12EnderecoLogradouro);
         AV33MunicipioCodigo = AV29EnderecoCompleto.gxTpr_Ibge;
         edtavEnderecobairro_Enabled = ((String.IsNullOrEmpty(StringUtil.RTrim( AV29EnderecoCompleto.gxTpr_Bairro)) ? true : false) ? 1 : 0);
         AssignProp("", false, edtavEnderecobairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecobairro_Enabled), 5, 0), true);
         edtavEnderecocidade_Enabled = ((String.IsNullOrEmpty(StringUtil.RTrim( AV29EnderecoCompleto.gxTpr_Localidade)) ? true : false) ? 1 : 0);
         AssignProp("", false, edtavEnderecocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecocidade_Enabled), 5, 0), true);
         edtavEnderecologradouro_Enabled = ((String.IsNullOrEmpty(StringUtil.RTrim( AV29EnderecoCompleto.gxTpr_Logradouro)) ? true : false) ? 1 : 0);
         AssignProp("", false, edtavEnderecologradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnderecologradouro_Enabled), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29EnderecoCompleto", AV29EnderecoCompleto);
      }

      protected void S132( )
      {
         /* 'VALIDACEP' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29EnderecoCompleto.gxTpr_Cep)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CEP não encontrado",  "error",  edtavCep_Internalname,  "true",  ""));
            AV21CheckRequiredFieldsResult = false;
         }
      }

      protected void S122( )
      {
         /* 'VALIDADOCUMENTO' Routine */
         returnInSub = false;
         GXt_char2 = "";
         new prvalidcpf(context ).execute(  AV24ClienteTipoPessoa,  AV5ClienteDocumento, out  AV25IsOK, out  GXt_char2) ;
         if ( ! AV25IsOK )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Documento inválido, verifique!",  "error",  edtavClientedocumento_Internalname,  "true",  ""));
            AV21CheckRequiredFieldsResult = false;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E154D2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA4D2( ) ;
         WS4D2( ) ;
         WE4D2( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019241963", true, true);
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
         context.AddJavascriptSource("wpnovofinanciamento.js", "?202561019241963", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavClientetipo.Name = "vCLIENTETIPO";
         cmbavClientetipo.WebTags = "";
         cmbavClientetipo.addItem("CLINICA", "Clinica", 0);
         cmbavClientetipo.addItem("PACIENTE", "Paciente", 0);
         cmbavClientetipo.addItem("FORNECEDOR", "Fornecedor", 0);
         cmbavClientetipo.addItem("PARCEIRO", "Parceiro", 0);
         if ( cmbavClientetipo.ItemCount > 0 )
         {
            AV7ClienteTipo = cmbavClientetipo.getValidValue(AV7ClienteTipo);
            AssignAttri("", false, "AV7ClienteTipo", AV7ClienteTipo);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavClientedocumento_Internalname = "vCLIENTEDOCUMENTO";
         edtavClienterazaosocial_Internalname = "vCLIENTERAZAOSOCIAL";
         lblTextblockcombo_clientetipo_Internalname = "TEXTBLOCKCOMBO_CLIENTETIPO";
         Combo_clientetipo_Internalname = "COMBO_CLIENTETIPO";
         divTablesplittedclientetipo_Internalname = "TABLESPLITTEDCLIENTETIPO";
         edtavValor_Internalname = "vVALOR";
         edtavCep_Internalname = "vCEP";
         edtavEnderecobairro_Internalname = "vENDERECOBAIRRO";
         edtavEnderecocidade_Internalname = "vENDERECOCIDADE";
         edtavEnderecocomplemento_Internalname = "vENDERECOCOMPLEMENTO";
         edtavEnderecologradouro_Internalname = "vENDERECOLOGRADOURO";
         edtavEndereconumero_Internalname = "vENDERECONUMERO";
         divTableendereco_Internalname = "TABLEENDERECO";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         edtavContatoemail_Internalname = "vCONTATOEMAIL";
         edtavContatoddd_Internalname = "vCONTATODDD";
         edtavContatonumero_Internalname = "vCONTATONUMERO";
         divTablecelular_Internalname = "TABLECELULAR";
         grpUnnamedgroup3_Internalname = "UNNAMEDGROUP3";
         edtavContatotelefoneddd_Internalname = "vCONTATOTELEFONEDDD";
         edtavContatotelefonenumero_Internalname = "vCONTATOTELEFONENUMERO";
         divTabletelefone_Internalname = "TABLETELEFONE";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         divTablecontatos_Internalname = "TABLECONTATOS";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         divTableinfo_Internalname = "TABLEINFO";
         Dvpanel_tableinfo_Internalname = "DVPANEL_TABLEINFO";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         divTablemain_Internalname = "TABLEMAIN";
         cmbavClientetipo_Internalname = "vCLIENTETIPO";
         edtavEnderecocep_Internalname = "vENDERECOCEP";
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
         edtavEnderecocep_Jsonclick = "";
         edtavEnderecocep_Visible = 1;
         cmbavClientetipo_Jsonclick = "";
         cmbavClientetipo.Visible = 1;
         edtavContatotelefonenumero_Jsonclick = "";
         edtavContatotelefonenumero_Enabled = 1;
         edtavContatotelefoneddd_Jsonclick = "";
         edtavContatotelefoneddd_Enabled = 1;
         edtavContatonumero_Jsonclick = "";
         edtavContatonumero_Enabled = 1;
         edtavContatoddd_Jsonclick = "";
         edtavContatoddd_Enabled = 1;
         edtavContatoemail_Jsonclick = "";
         edtavContatoemail_Enabled = 1;
         edtavEndereconumero_Jsonclick = "";
         edtavEndereconumero_Enabled = 1;
         edtavEnderecologradouro_Jsonclick = "";
         edtavEnderecologradouro_Enabled = 1;
         edtavEnderecocomplemento_Jsonclick = "";
         edtavEnderecocomplemento_Enabled = 1;
         edtavEnderecocidade_Jsonclick = "";
         edtavEnderecocidade_Enabled = 1;
         edtavEnderecobairro_Jsonclick = "";
         edtavEnderecobairro_Enabled = 1;
         edtavCep_Jsonclick = "";
         edtavCep_Enabled = 1;
         edtavValor_Jsonclick = "";
         edtavValor_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         edtavClientedocumento_Jsonclick = "";
         edtavClientedocumento_Enabled = 1;
         Dvpanel_tableinfo_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableinfo_Iconposition = "Right";
         Dvpanel_tableinfo_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableinfo_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableinfo_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableinfo_Title = "Informações";
         Dvpanel_tableinfo_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableinfo_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableinfo_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableinfo_Width = "100%";
         Combo_clientetipo_Emptyitem = Convert.ToBoolean( 0);
         Combo_clientetipo_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Novo financiamento";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV39WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV24ClienteTipoPessoa","fld":"vCLIENTETIPOPESSOA","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("ENTER","""{"handler":"E124D2","iparms":[{"av":"AV36IsCPFUsed","fld":"vISCPFUSED","type":"boolean"},{"av":"AV38ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV27Valor","fld":"vVALOR","pic":"ZZZZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV39WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VCLIENTEDOCUMENTO.CONTROLVALUECHANGED","""{"handler":"E134D2","iparms":[{"av":"AV5ClienteDocumento","fld":"vCLIENTEDOCUMENTO","type":"svchar"},{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A184EnderecoBairro","fld":"ENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"A182EnderecoCEP","fld":"ENDERECOCEP","type":"svchar"},{"av":"A185EnderecoCidade","fld":"ENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"A191EnderecoComplemento","fld":"ENDERECOCOMPLEMENTO","type":"svchar"},{"av":"A183EnderecoLogradouro","fld":"ENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"A190EnderecoNumero","fld":"ENDERECONUMERO","type":"svchar"},{"av":"A198ContatoDDD","fld":"CONTATODDD","pic":"ZZZ9","type":"int"},{"av":"A199ContatoDDI","fld":"CONTATODDI","pic":"ZZZ9","type":"int"},{"av":"A201ContatoEmail","fld":"CONTATOEMAIL","type":"svchar"},{"av":"A200ContatoNumero","fld":"CONTATONUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"A203ContatoTelefoneDDD","fld":"CONTATOTELEFONEDDD","pic":"ZZZ9","type":"int"},{"av":"A204ContatoTelefoneDDI","fld":"CONTATOTELEFONEDDI","pic":"ZZZ9","type":"int"},{"av":"A202ContatoTelefoneNumero","fld":"CONTATOTELEFONENUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV24ClienteTipoPessoa","fld":"vCLIENTETIPOPESSOA","hsh":true,"type":"svchar"}]""");
         setEventMetadata("VCLIENTEDOCUMENTO.CONTROLVALUECHANGED",""","oparms":[{"av":"AV35AuxClienteDocumento","fld":"vAUXCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV36IsCPFUsed","fld":"vISCPFUSED","type":"boolean"},{"av":"AV6ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV38ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV9EnderecoBairro","fld":"vENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"AV8EnderecoCEP","fld":"vENDERECOCEP","type":"svchar"},{"av":"AV28CEP","fld":"vCEP","type":"svchar"},{"av":"AV10EnderecoCidade","fld":"vENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"AV11EnderecoComplemento","fld":"vENDERECOCOMPLEMENTO","type":"svchar"},{"av":"AV12EnderecoLogradouro","fld":"vENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"AV13EnderecoNumero","fld":"vENDERECONUMERO","type":"svchar"},{"av":"edtavEnderecobairro_Enabled","ctrl":"vENDERECOBAIRRO","prop":"Enabled"},{"av":"edtavEnderecocidade_Enabled","ctrl":"vENDERECOCIDADE","prop":"Enabled"},{"av":"edtavEnderecologradouro_Enabled","ctrl":"vENDERECOLOGRADOURO","prop":"Enabled"},{"av":"AV15ContatoDDD","fld":"vCONTATODDD","pic":"ZZZ9","type":"int"},{"av":"AV14ContatoEmail","fld":"vCONTATOEMAIL","type":"svchar"},{"av":"AV17ContatoNumero","fld":"vCONTATONUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"},{"av":"AV18ContatoTelefoneDDD","fld":"vCONTATOTELEFONEDDD","pic":"ZZZ9","type":"int"},{"av":"AV20ContatoTelefoneNumero","fld":"vCONTATOTELEFONENUMERO","pic":"ZZZZZZZZZZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VCEP.CONTROLVALUECHANGED","""{"handler":"E144D2","iparms":[{"av":"AV28CEP","fld":"vCEP","type":"svchar"},{"av":"AV29EnderecoCompleto","fld":"vENDERECOCOMPLETO","type":""}]""");
         setEventMetadata("VCEP.CONTROLVALUECHANGED",""","oparms":[{"av":"AV28CEP","fld":"vCEP","type":"svchar"},{"av":"AV29EnderecoCompleto","fld":"vENDERECOCOMPLETO","type":""},{"av":"AV9EnderecoBairro","fld":"vENDERECOBAIRRO","pic":"@!","type":"svchar"},{"av":"AV10EnderecoCidade","fld":"vENDERECOCIDADE","pic":"@!","type":"svchar"},{"av":"AV12EnderecoLogradouro","fld":"vENDERECOLOGRADOURO","pic":"@!","type":"svchar"},{"av":"edtavEnderecobairro_Enabled","ctrl":"vENDERECOBAIRRO","prop":"Enabled"},{"av":"edtavEnderecocidade_Enabled","ctrl":"vENDERECOCIDADE","prop":"Enabled"},{"av":"edtavEnderecologradouro_Enabled","ctrl":"vENDERECOLOGRADOURO","prop":"Enabled"}]}""");
         setEventMetadata("VALIDV_CONTATOEMAIL","""{"handler":"Validv_Contatoemail","iparms":[]}""");
         setEventMetadata("VALIDV_CLIENTETIPO","""{"handler":"Validv_Clientetipo","iparms":[]}""");
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
         Combo_clientetipo_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV39WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV24ClienteTipoPessoa = "";
         GXKey = "";
         AV22ClienteTipo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A169ClienteDocumento = "";
         A170ClienteRazaoSocial = "";
         A184EnderecoBairro = "";
         A182EnderecoCEP = "";
         A185EnderecoCidade = "";
         A191EnderecoComplemento = "";
         A183EnderecoLogradouro = "";
         A190EnderecoNumero = "";
         A201ContatoEmail = "";
         AV29EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         Combo_clientetipo_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableinfo = new GXUserControl();
         TempTags = "";
         AV5ClienteDocumento = "";
         AV6ClienteRazaoSocial = "";
         lblTextblockcombo_clientetipo_Jsonclick = "";
         ucCombo_clientetipo = new GXUserControl();
         Combo_clientetipo_Caption = "";
         AV28CEP = "";
         AV9EnderecoBairro = "";
         AV10EnderecoCidade = "";
         AV11EnderecoComplemento = "";
         AV12EnderecoLogradouro = "";
         AV13EnderecoNumero = "";
         AV14ContatoEmail = "";
         bttBtnenter_Jsonclick = "";
         AV7ClienteTipo = "";
         AV8EnderecoCEP = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Financiamento = new SdtFinanciamento(context);
         Combo_clientetipo_Ddointernalname = "";
         H004D2_A219TipoClienteFinancia = new bool[] {false} ;
         H004D2_n219TipoClienteFinancia = new bool[] {false} ;
         H004D2_A192TipoClienteId = new short[1] ;
         H004D2_A193TipoClienteDescricao = new string[] {""} ;
         H004D2_n193TipoClienteDescricao = new bool[] {false} ;
         A193TipoClienteDescricao = "";
         AV23Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV35AuxClienteDocumento = "";
         H004D3_A169ClienteDocumento = new string[] {""} ;
         H004D3_n169ClienteDocumento = new bool[] {false} ;
         H004D3_A170ClienteRazaoSocial = new string[] {""} ;
         H004D3_n170ClienteRazaoSocial = new bool[] {false} ;
         H004D3_A168ClienteId = new int[1] ;
         H004D3_A184EnderecoBairro = new string[] {""} ;
         H004D3_n184EnderecoBairro = new bool[] {false} ;
         H004D3_A182EnderecoCEP = new string[] {""} ;
         H004D3_n182EnderecoCEP = new bool[] {false} ;
         H004D3_A185EnderecoCidade = new string[] {""} ;
         H004D3_n185EnderecoCidade = new bool[] {false} ;
         H004D3_A191EnderecoComplemento = new string[] {""} ;
         H004D3_n191EnderecoComplemento = new bool[] {false} ;
         H004D3_A183EnderecoLogradouro = new string[] {""} ;
         H004D3_n183EnderecoLogradouro = new bool[] {false} ;
         H004D3_A190EnderecoNumero = new string[] {""} ;
         H004D3_n190EnderecoNumero = new bool[] {false} ;
         H004D3_A198ContatoDDD = new short[1] ;
         H004D3_n198ContatoDDD = new bool[] {false} ;
         H004D3_A199ContatoDDI = new short[1] ;
         H004D3_n199ContatoDDI = new bool[] {false} ;
         H004D3_A201ContatoEmail = new string[] {""} ;
         H004D3_n201ContatoEmail = new bool[] {false} ;
         H004D3_A200ContatoNumero = new long[1] ;
         H004D3_n200ContatoNumero = new bool[] {false} ;
         H004D3_A203ContatoTelefoneDDD = new short[1] ;
         H004D3_n203ContatoTelefoneDDD = new bool[] {false} ;
         H004D3_A204ContatoTelefoneDDI = new short[1] ;
         H004D3_n204ContatoTelefoneDDI = new bool[] {false} ;
         H004D3_A202ContatoTelefoneNumero = new long[1] ;
         H004D3_n202ContatoTelefoneNumero = new bool[] {false} ;
         AV30ModeloRetorno = "";
         AV31Mensagem = "";
         AV33MunicipioCodigo = "";
         GXt_char2 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpnovofinanciamento__default(),
            new Object[][] {
                new Object[] {
               H004D2_A219TipoClienteFinancia, H004D2_n219TipoClienteFinancia, H004D2_A192TipoClienteId, H004D2_A193TipoClienteDescricao, H004D2_n193TipoClienteDescricao
               }
               , new Object[] {
               H004D3_A169ClienteDocumento, H004D3_n169ClienteDocumento, H004D3_A170ClienteRazaoSocial, H004D3_n170ClienteRazaoSocial, H004D3_A168ClienteId, H004D3_A184EnderecoBairro, H004D3_n184EnderecoBairro, H004D3_A182EnderecoCEP, H004D3_n182EnderecoCEP, H004D3_A185EnderecoCidade,
               H004D3_n185EnderecoCidade, H004D3_A191EnderecoComplemento, H004D3_n191EnderecoComplemento, H004D3_A183EnderecoLogradouro, H004D3_n183EnderecoLogradouro, H004D3_A190EnderecoNumero, H004D3_n190EnderecoNumero, H004D3_A198ContatoDDD, H004D3_n198ContatoDDD, H004D3_A199ContatoDDI,
               H004D3_n199ContatoDDI, H004D3_A201ContatoEmail, H004D3_n201ContatoEmail, H004D3_A200ContatoNumero, H004D3_n200ContatoNumero, H004D3_A203ContatoTelefoneDDD, H004D3_n203ContatoTelefoneDDD, H004D3_A204ContatoTelefoneDDI, H004D3_n204ContatoTelefoneDDI, H004D3_A202ContatoTelefoneNumero,
               H004D3_n202ContatoTelefoneNumero
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short A198ContatoDDD ;
      private short A199ContatoDDI ;
      private short A203ContatoTelefoneDDD ;
      private short A204ContatoTelefoneDDI ;
      private short wbEnd ;
      private short wbStart ;
      private short AV15ContatoDDD ;
      private short AV18ContatoTelefoneDDD ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A192TipoClienteId ;
      private short AV16ContatoDDI ;
      private short AV19ContatoTelefoneDDI ;
      private short nGXWrapped ;
      private int AV38ClienteId ;
      private int A168ClienteId ;
      private int edtavClientedocumento_Enabled ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavValor_Enabled ;
      private int edtavCep_Enabled ;
      private int edtavEnderecobairro_Enabled ;
      private int edtavEnderecocidade_Enabled ;
      private int edtavEnderecocomplemento_Enabled ;
      private int edtavEnderecologradouro_Enabled ;
      private int edtavEndereconumero_Enabled ;
      private int edtavContatoemail_Enabled ;
      private int edtavContatoddd_Enabled ;
      private int edtavContatonumero_Enabled ;
      private int edtavContatotelefoneddd_Enabled ;
      private int edtavContatotelefonenumero_Enabled ;
      private int edtavEnderecocep_Visible ;
      private int idxLst ;
      private long A200ContatoNumero ;
      private long A202ContatoTelefoneNumero ;
      private long AV17ContatoNumero ;
      private long AV20ContatoTelefoneNumero ;
      private decimal AV27Valor ;
      private string Combo_clientetipo_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_clientetipo_Cls ;
      private string Combo_clientetipo_Selectedvalue_set ;
      private string Dvpanel_tableinfo_Width ;
      private string Dvpanel_tableinfo_Cls ;
      private string Dvpanel_tableinfo_Title ;
      private string Dvpanel_tableinfo_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableinfo_Internalname ;
      private string divTableinfo_Internalname ;
      private string edtavClientedocumento_Internalname ;
      private string TempTags ;
      private string edtavClientedocumento_Jsonclick ;
      private string edtavClienterazaosocial_Internalname ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string divTablesplittedclientetipo_Internalname ;
      private string lblTextblockcombo_clientetipo_Internalname ;
      private string lblTextblockcombo_clientetipo_Jsonclick ;
      private string Combo_clientetipo_Caption ;
      private string Combo_clientetipo_Internalname ;
      private string edtavValor_Internalname ;
      private string edtavValor_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableendereco_Internalname ;
      private string edtavCep_Internalname ;
      private string edtavCep_Jsonclick ;
      private string edtavEnderecobairro_Internalname ;
      private string edtavEnderecobairro_Jsonclick ;
      private string edtavEnderecocidade_Internalname ;
      private string edtavEnderecocidade_Jsonclick ;
      private string edtavEnderecocomplemento_Internalname ;
      private string edtavEnderecocomplemento_Jsonclick ;
      private string edtavEnderecologradouro_Internalname ;
      private string edtavEnderecologradouro_Jsonclick ;
      private string edtavEndereconumero_Internalname ;
      private string edtavEndereconumero_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTablecontatos_Internalname ;
      private string edtavContatoemail_Internalname ;
      private string edtavContatoemail_Jsonclick ;
      private string grpUnnamedgroup3_Internalname ;
      private string divTablecelular_Internalname ;
      private string edtavContatoddd_Internalname ;
      private string edtavContatoddd_Jsonclick ;
      private string edtavContatonumero_Internalname ;
      private string edtavContatonumero_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divTabletelefone_Internalname ;
      private string edtavContatotelefoneddd_Internalname ;
      private string edtavContatotelefoneddd_Jsonclick ;
      private string edtavContatotelefonenumero_Internalname ;
      private string edtavContatotelefonenumero_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string cmbavClientetipo_Internalname ;
      private string cmbavClientetipo_Jsonclick ;
      private string edtavEnderecocep_Internalname ;
      private string edtavEnderecocep_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string Combo_clientetipo_Ddointernalname ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV36IsCPFUsed ;
      private bool Combo_clientetipo_Emptyitem ;
      private bool Dvpanel_tableinfo_Autowidth ;
      private bool Dvpanel_tableinfo_Autoheight ;
      private bool Dvpanel_tableinfo_Collapsible ;
      private bool Dvpanel_tableinfo_Collapsed ;
      private bool Dvpanel_tableinfo_Showcollapseicon ;
      private bool Dvpanel_tableinfo_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV21CheckRequiredFieldsResult ;
      private bool A219TipoClienteFinancia ;
      private bool n219TipoClienteFinancia ;
      private bool n193TipoClienteDescricao ;
      private bool n169ClienteDocumento ;
      private bool n170ClienteRazaoSocial ;
      private bool n184EnderecoBairro ;
      private bool n182EnderecoCEP ;
      private bool n185EnderecoCidade ;
      private bool n191EnderecoComplemento ;
      private bool n183EnderecoLogradouro ;
      private bool n190EnderecoNumero ;
      private bool n198ContatoDDD ;
      private bool n199ContatoDDI ;
      private bool n201ContatoEmail ;
      private bool n200ContatoNumero ;
      private bool n203ContatoTelefoneDDD ;
      private bool n204ContatoTelefoneDDI ;
      private bool n202ContatoTelefoneNumero ;
      private bool AV25IsOK ;
      private string AV30ModeloRetorno ;
      private string AV24ClienteTipoPessoa ;
      private string A169ClienteDocumento ;
      private string A170ClienteRazaoSocial ;
      private string A184EnderecoBairro ;
      private string A182EnderecoCEP ;
      private string A185EnderecoCidade ;
      private string A191EnderecoComplemento ;
      private string A183EnderecoLogradouro ;
      private string A190EnderecoNumero ;
      private string A201ContatoEmail ;
      private string AV5ClienteDocumento ;
      private string AV6ClienteRazaoSocial ;
      private string AV28CEP ;
      private string AV9EnderecoBairro ;
      private string AV10EnderecoCidade ;
      private string AV11EnderecoComplemento ;
      private string AV12EnderecoLogradouro ;
      private string AV13EnderecoNumero ;
      private string AV14ContatoEmail ;
      private string AV7ClienteTipo ;
      private string AV8EnderecoCEP ;
      private string A193TipoClienteDescricao ;
      private string AV35AuxClienteDocumento ;
      private string AV31Mensagem ;
      private string AV33MunicipioCodigo ;
      private GXUserControl ucDvpanel_tableinfo ;
      private GXUserControl ucCombo_clientetipo ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavClientetipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV39WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22ClienteTipo_Data ;
      private GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto AV29EnderecoCompleto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private SdtFinanciamento AV37Financiamento ;
      private IDataStoreProvider pr_default ;
      private bool[] H004D2_A219TipoClienteFinancia ;
      private bool[] H004D2_n219TipoClienteFinancia ;
      private short[] H004D2_A192TipoClienteId ;
      private string[] H004D2_A193TipoClienteDescricao ;
      private bool[] H004D2_n193TipoClienteDescricao ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV23Combo_DataItem ;
      private string[] H004D3_A169ClienteDocumento ;
      private bool[] H004D3_n169ClienteDocumento ;
      private string[] H004D3_A170ClienteRazaoSocial ;
      private bool[] H004D3_n170ClienteRazaoSocial ;
      private int[] H004D3_A168ClienteId ;
      private string[] H004D3_A184EnderecoBairro ;
      private bool[] H004D3_n184EnderecoBairro ;
      private string[] H004D3_A182EnderecoCEP ;
      private bool[] H004D3_n182EnderecoCEP ;
      private string[] H004D3_A185EnderecoCidade ;
      private bool[] H004D3_n185EnderecoCidade ;
      private string[] H004D3_A191EnderecoComplemento ;
      private bool[] H004D3_n191EnderecoComplemento ;
      private string[] H004D3_A183EnderecoLogradouro ;
      private bool[] H004D3_n183EnderecoLogradouro ;
      private string[] H004D3_A190EnderecoNumero ;
      private bool[] H004D3_n190EnderecoNumero ;
      private short[] H004D3_A198ContatoDDD ;
      private bool[] H004D3_n198ContatoDDD ;
      private short[] H004D3_A199ContatoDDI ;
      private bool[] H004D3_n199ContatoDDI ;
      private string[] H004D3_A201ContatoEmail ;
      private bool[] H004D3_n201ContatoEmail ;
      private long[] H004D3_A200ContatoNumero ;
      private bool[] H004D3_n200ContatoNumero ;
      private short[] H004D3_A203ContatoTelefoneDDD ;
      private bool[] H004D3_n203ContatoTelefoneDDD ;
      private short[] H004D3_A204ContatoTelefoneDDI ;
      private bool[] H004D3_n204ContatoTelefoneDDI ;
      private long[] H004D3_A202ContatoTelefoneNumero ;
      private bool[] H004D3_n202ContatoTelefoneNumero ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpnovofinanciamento__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004D2;
          prmH004D2 = new Object[] {
          };
          Object[] prmH004D3;
          prmH004D3 = new Object[] {
          new ParDef("AV35AuxClienteDocumento",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004D2", "SELECT TipoClienteFinancia, TipoClienteId, TipoClienteDescricao FROM TipoCliente WHERE TipoClienteFinancia ORDER BY TipoClienteDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004D2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004D3", "SELECT ClienteDocumento, ClienteRazaoSocial, ClienteId, EnderecoBairro, EnderecoCEP, EnderecoCidade, EnderecoComplemento, EnderecoLogradouro, EnderecoNumero, ContatoDDD, ContatoDDI, ContatoEmail, ContatoNumero, ContatoTelefoneDDD, ContatoTelefoneDDI, ContatoTelefoneNumero FROM Cliente WHERE ClienteDocumento = ( :AV35AuxClienteDocumento) ORDER BY ClienteDocumento ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004D3,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((long[]) buf[23])[0] = rslt.getLong(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((long[]) buf[29])[0] = rslt.getLong(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
       }
    }

 }

}
