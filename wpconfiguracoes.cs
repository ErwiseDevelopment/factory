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
   public class wpconfiguracoes : GXDataArea
   {
      public wpconfiguracoes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpconfiguracoes( IGxContext context )
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
         cmbavConfiguracoesserasaanotacoescompletas = new GXCombobox();
         cmbavConfiguracoesserasaconsultadetalhada = new GXCombobox();
         cmbavConfiguracoesserasahistoricopagamento = new GXCombobox();
         cmbavConfiguracoesserasaparticipacaosocietaria = new GXCombobox();
         cmbavConfiguracoesserasarendaestimada = new GXCombobox();
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
         PA542( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START542( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("UserControls/UcColorpickerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpconfiguracoes") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONFIGURACOESCATEGORIATITULO_DATA", AV46ConfiguracoesCategoriaTitulo_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONFIGURACOESCATEGORIATITULO_DATA", AV46ConfiguracoesCategoriaTitulo_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONFIGLAYOUTCONTRATOCOMPRATITULO_DATA", AV53ConfigLayoutContratoCompraTitulo_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONFIGLAYOUTCONTRATOCOMPRATITULO_DATA", AV53ConfigLayoutContratoCompraTitulo_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONFIGURACOESLAYOUTPROPOSTA_DATA", AV35ConfiguracoesLayoutProposta_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONFIGURACOESLAYOUTPROPOSTA_DATA", AV35ConfiguracoesLayoutProposta_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO_DATA", AV42ConfigLayoutPromissoriaClinicaEmprestimo_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO_DATA", AV42ConfigLayoutPromissoriaClinicaEmprestimo_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONFIGLAYOUTPROMISSORIACLINICATAXA_DATA", AV43ConfigLayoutPromissoriaClinicaTaxa_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONFIGLAYOUTPROMISSORIACLINICATAXA_DATA", AV43ConfigLayoutPromissoriaClinicaTaxa_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONFIGLAYOUTPROMISSORIAPACIENTE_DATA", AV44ConfigLayoutPromissoriaPaciente_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONFIGLAYOUTPROMISSORIAPACIENTE_DATA", AV44ConfigLayoutPromissoriaPaciente_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUPLOADEDFILES", AV6UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUPLOADEDFILES", AV6UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFAILEDFILES", AV7FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFAILEDFILES", AV7FailedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARRAY_EMAIL", AV31Array_Email);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARRAY_EMAIL", AV31Array_Email);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONFIGURACOES", AV9Configuracoes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONFIGURACOES", AV9Configuracoes);
         }
         GxWebStd.gx_hidden_field( context, "vSOURCE", AV14Source);
         GxWebStd.gx_hidden_field( context, "vAUXCONFIGURACOESIMAGEMLOGIN", AV18AuxConfiguracoesImagemLogin);
         GxWebStd.gx_hidden_field( context, "vCONFIGURACOESIMAGEMLOGIN", AV5ConfiguracoesImagemLogin);
         GxWebStd.gx_hidden_field( context, "vCONFIGURACOESIMAGEMLOGINEXTENCAO", AV10ConfiguracoesImagemLoginExtencao);
         GxWebStd.gx_hidden_field( context, "vCONFIGURACOESIMAGEMLOGINNOMEINTEIRO", AV13ConfiguracoesImagemLoginNomeInteiro);
         GxWebStd.gx_hidden_field( context, "vCONFIGURACOESIMAGEMLOGINTAMANHO", StringUtil.LTrim( StringUtil.NToC( AV12ConfiguracoesImagemLoginTamanho, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vAUXCONFIGURACOESIMAGEMHEADER", AV25AuxConfiguracoesImagemHeader);
         GxWebStd.gx_hidden_field( context, "vCONFIGURACOESIMAGEMHEADER", AV20ConfiguracoesImagemHeader);
         GxWebStd.gx_hidden_field( context, "vCONFIGURACOESIMAGEMHEADEREXTENCAO", AV22ConfiguracoesImagemHeaderExtencao);
         GxWebStd.gx_hidden_field( context, "vCONFIGURACOESIMAGEMHEADERNOME", AV21ConfiguracoesImagemHeaderNome);
         GxWebStd.gx_hidden_field( context, "vCONFIGURACOESIMAGEMHEADERNOMEINTEIRO", AV23ConfiguracoesImagemHeaderNomeInteiro);
         GxWebStd.gx_hidden_field( context, "vCONFIGURACOESIMAGEMHEADERTAMANHO", StringUtil.LTrim( StringUtil.NToC( AV24ConfiguracoesImagemHeaderTamanho, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vSOURCECABECALHO", AV28SourceCabecalho);
         GxWebStd.gx_hidden_field( context, "vCOLOR", AV11Color);
         GxWebStd.gx_hidden_field( context, "vDMCONFIGURACAOIMAGEM", AV19DmConfiguracaoImagem);
         GxWebStd.gx_hidden_field( context, "vJSON", AV17JSON);
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGURACOESCATEGORIATITULO_Cls", StringUtil.RTrim( Combo_configuracoescategoriatitulo_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGURACOESCATEGORIATITULO_Selectedvalue_set", StringUtil.RTrim( Combo_configuracoescategoriatitulo_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGURACOESCATEGORIATITULO_Emptyitem", StringUtil.BoolToStr( Combo_configuracoescategoriatitulo_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTCONTRATOCOMPRATITULO_Cls", StringUtil.RTrim( Combo_configlayoutcontratocompratitulo_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTCONTRATOCOMPRATITULO_Selectedvalue_set", StringUtil.RTrim( Combo_configlayoutcontratocompratitulo_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTCONTRATOCOMPRATITULO_Emptyitem", StringUtil.BoolToStr( Combo_configlayoutcontratocompratitulo_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGURACOESLAYOUTPROPOSTA_Cls", StringUtil.RTrim( Combo_configuracoeslayoutproposta_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGURACOESLAYOUTPROPOSTA_Selectedvalue_set", StringUtil.RTrim( Combo_configuracoeslayoutproposta_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGURACOESLAYOUTPROPOSTA_Emptyitem", StringUtil.BoolToStr( Combo_configuracoeslayoutproposta_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO_Cls", StringUtil.RTrim( Combo_configlayoutpromissoriaclinicaemprestimo_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO_Selectedvalue_set", StringUtil.RTrim( Combo_configlayoutpromissoriaclinicaemprestimo_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO_Emptyitem", StringUtil.BoolToStr( Combo_configlayoutpromissoriaclinicaemprestimo_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTPROMISSORIACLINICATAXA_Cls", StringUtil.RTrim( Combo_configlayoutpromissoriaclinicataxa_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTPROMISSORIACLINICATAXA_Selectedvalue_set", StringUtil.RTrim( Combo_configlayoutpromissoriaclinicataxa_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTPROMISSORIACLINICATAXA_Emptyitem", StringUtil.BoolToStr( Combo_configlayoutpromissoriaclinicataxa_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTPROMISSORIAPACIENTE_Cls", StringUtil.RTrim( Combo_configlayoutpromissoriapaciente_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTPROMISSORIAPACIENTE_Selectedvalue_set", StringUtil.RTrim( Combo_configlayoutpromissoriapaciente_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTPROMISSORIAPACIENTE_Emptyitem", StringUtil.BoolToStr( Combo_configlayoutpromissoriapaciente_Emptyitem));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS2_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs2_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS2_Class", StringUtil.RTrim( Gxuitabspanel_tabs2_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS2_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs2_Historymanagement));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEIMAGEMLOGIN_Width", StringUtil.RTrim( Dvpanel_tableimagemlogin_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEIMAGEMLOGIN_Autowidth", StringUtil.BoolToStr( Dvpanel_tableimagemlogin_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEIMAGEMLOGIN_Autoheight", StringUtil.BoolToStr( Dvpanel_tableimagemlogin_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEIMAGEMLOGIN_Cls", StringUtil.RTrim( Dvpanel_tableimagemlogin_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEIMAGEMLOGIN_Title", StringUtil.RTrim( Dvpanel_tableimagemlogin_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEIMAGEMLOGIN_Collapsible", StringUtil.BoolToStr( Dvpanel_tableimagemlogin_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEIMAGEMLOGIN_Collapsed", StringUtil.BoolToStr( Dvpanel_tableimagemlogin_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEIMAGEMLOGIN_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableimagemlogin_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEIMAGEMLOGIN_Iconposition", StringUtil.RTrim( Dvpanel_tableimagemlogin_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEIMAGEMLOGIN_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableimagemlogin_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELIMAGEMHEADER_Width", StringUtil.RTrim( Dvpanel_panelimagemheader_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELIMAGEMHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_panelimagemheader_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELIMAGEMHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_panelimagemheader_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELIMAGEMHEADER_Cls", StringUtil.RTrim( Dvpanel_panelimagemheader_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELIMAGEMHEADER_Title", StringUtil.RTrim( Dvpanel_panelimagemheader_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELIMAGEMHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_panelimagemheader_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELIMAGEMHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_panelimagemheader_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELIMAGEMHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_panelimagemheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELIMAGEMHEADER_Iconposition", StringUtil.RTrim( Dvpanel_panelimagemheader_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELIMAGEMHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_panelimagemheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, "UCFILE_Autoupload", StringUtil.BoolToStr( Ucfile_Autoupload));
         GxWebStd.gx_hidden_field( context, "UCFILE_Enableuploadedfilecanceling", StringUtil.BoolToStr( Ucfile_Enableuploadedfilecanceling));
         GxWebStd.gx_hidden_field( context, "UCFILE_Maxfilesize", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucfile_Maxfilesize), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCFILE_Maxnumberoffiles", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucfile_Maxnumberoffiles), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCFILE_Acceptedfiletypes", StringUtil.RTrim( Ucfile_Acceptedfiletypes));
         GxWebStd.gx_hidden_field( context, "UCFILE_Customfiletypes", StringUtil.RTrim( Ucfile_Customfiletypes));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "COLORPICKER_Gxcontrol", StringUtil.RTrim( Colorpicker_Gxcontrol));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTPROMISSORIAPACIENTE_Selectedvalue_get", StringUtil.RTrim( Combo_configlayoutpromissoriapaciente_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTPROMISSORIACLINICATAXA_Selectedvalue_get", StringUtil.RTrim( Combo_configlayoutpromissoriaclinicataxa_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO_Selectedvalue_get", StringUtil.RTrim( Combo_configlayoutpromissoriaclinicaemprestimo_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGURACOESLAYOUTPROPOSTA_Selectedvalue_get", StringUtil.RTrim( Combo_configuracoeslayoutproposta_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGLAYOUTCONTRATOCOMPRATITULO_Selectedvalue_get", StringUtil.RTrim( Combo_configlayoutcontratocompratitulo_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CONFIGURACOESCATEGORIATITULO_Selectedvalue_get", StringUtil.RTrim( Combo_configuracoescategoriatitulo_Selectedvalue_get));
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
         if ( ! ( WebComp_Wcwcimagem == null ) )
         {
            WebComp_Wcwcimagem.componentjscripts();
         }
         if ( ! ( WebComp_Wcimagemcabecalho == null ) )
         {
            WebComp_Wcimagemcabecalho.componentjscripts();
         }
         if ( ! ( WebComp_Wcservidorsmtpww == null ) )
         {
            WebComp_Wcservidorsmtpww.componentjscripts();
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
            WE542( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT542( ) ;
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
         return formatLink("wpconfiguracoes")  ;
      }

      public override string GetPgmname( )
      {
         return "WpConfiguracoes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Configurações" ;
      }

      protected void WB540( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Salvar configurações", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpConfiguracoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
            ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
            ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, "GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeral_title_Internalname, "Geral", "", "", lblGeral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Geral") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegeral_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconfiguracoescategoriatitulo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_configuracoescategoriatitulo_Internalname, "Categoria de título das propostas", "", "", lblTextblockcombo_configuracoescategoriatitulo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_configuracoescategoriatitulo.SetProperty("Caption", Combo_configuracoescategoriatitulo_Caption);
            ucCombo_configuracoescategoriatitulo.SetProperty("Cls", Combo_configuracoescategoriatitulo_Cls);
            ucCombo_configuracoescategoriatitulo.SetProperty("EmptyItem", Combo_configuracoescategoriatitulo_Emptyitem);
            ucCombo_configuracoescategoriatitulo.SetProperty("DropDownOptionsData", AV46ConfiguracoesCategoriaTitulo_Data);
            ucCombo_configuracoescategoriatitulo.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_configuracoescategoriatitulo_Internalname, "COMBO_CONFIGURACOESCATEGORIATITULOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabgerais_title_Internalname, "Layouts", "", "", lblTabgerais_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabGerais") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs2.SetProperty("PageCount", Gxuitabspanel_tabs2_Pagecount);
            ucGxuitabspanel_tabs2.SetProperty("Class", Gxuitabspanel_tabs2_Class);
            ucGxuitabspanel_tabs2.SetProperty("HistoryManagement", Gxuitabspanel_tabs2_Historymanagement);
            ucGxuitabspanel_tabs2.Render(context, "tab", Gxuitabspanel_tabs2_Internalname, "GXUITABSPANEL_TABS2Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS2Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabfactory_title_Internalname, "Factory", "", "", lblTabfactory_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabFactory") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS2Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabfactory_title_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconfiglayoutcontratocompratitulo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_configlayoutcontratocompratitulo_Internalname, "Layout contrato compra de título", "", "", lblTextblockcombo_configlayoutcontratocompratitulo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_configlayoutcontratocompratitulo.SetProperty("Caption", Combo_configlayoutcontratocompratitulo_Caption);
            ucCombo_configlayoutcontratocompratitulo.SetProperty("Cls", Combo_configlayoutcontratocompratitulo_Cls);
            ucCombo_configlayoutcontratocompratitulo.SetProperty("EmptyItem", Combo_configlayoutcontratocompratitulo_Emptyitem);
            ucCombo_configlayoutcontratocompratitulo.SetProperty("DropDownOptionsData", AV53ConfigLayoutContratoCompraTitulo_Data);
            ucCombo_configlayoutcontratocompratitulo.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_configlayoutcontratocompratitulo_Internalname, "COMBO_CONFIGLAYOUTCONTRATOCOMPRATITULOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS2Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabclinica_title_Internalname, "Clinica", "", "", lblTabclinica_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabClinica") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS2Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabclinica_title_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconfiguracoeslayoutproposta_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_configuracoeslayoutproposta_Internalname, "Layout da proposta", "", "", lblTextblockcombo_configuracoeslayoutproposta_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_configuracoeslayoutproposta.SetProperty("Caption", Combo_configuracoeslayoutproposta_Caption);
            ucCombo_configuracoeslayoutproposta.SetProperty("Cls", Combo_configuracoeslayoutproposta_Cls);
            ucCombo_configuracoeslayoutproposta.SetProperty("EmptyItem", Combo_configuracoeslayoutproposta_Emptyitem);
            ucCombo_configuracoeslayoutproposta.SetProperty("DropDownOptionsData", AV35ConfiguracoesLayoutProposta_Data);
            ucCombo_configuracoeslayoutproposta.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_configuracoeslayoutproposta_Internalname, "COMBO_CONFIGURACOESLAYOUTPROPOSTAContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconfiglayoutpromissoriaclinicaemprestimo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_configlayoutpromissoriaclinicaemprestimo_Internalname, "Layout da nota promissória da clinica - empréstimo", "", "", lblTextblockcombo_configlayoutpromissoriaclinicaemprestimo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_configlayoutpromissoriaclinicaemprestimo.SetProperty("Caption", Combo_configlayoutpromissoriaclinicaemprestimo_Caption);
            ucCombo_configlayoutpromissoriaclinicaemprestimo.SetProperty("Cls", Combo_configlayoutpromissoriaclinicaemprestimo_Cls);
            ucCombo_configlayoutpromissoriaclinicaemprestimo.SetProperty("EmptyItem", Combo_configlayoutpromissoriaclinicaemprestimo_Emptyitem);
            ucCombo_configlayoutpromissoriaclinicaemprestimo.SetProperty("DropDownOptionsData", AV42ConfigLayoutPromissoriaClinicaEmprestimo_Data);
            ucCombo_configlayoutpromissoriaclinicaemprestimo.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_configlayoutpromissoriaclinicaemprestimo_Internalname, "COMBO_CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMOContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconfiglayoutpromissoriaclinicataxa_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_configlayoutpromissoriaclinicataxa_Internalname, "Layout da nota promissória da clinica - taxa", "", "", lblTextblockcombo_configlayoutpromissoriaclinicataxa_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_configlayoutpromissoriaclinicataxa.SetProperty("Caption", Combo_configlayoutpromissoriaclinicataxa_Caption);
            ucCombo_configlayoutpromissoriaclinicataxa.SetProperty("Cls", Combo_configlayoutpromissoriaclinicataxa_Cls);
            ucCombo_configlayoutpromissoriaclinicataxa.SetProperty("EmptyItem", Combo_configlayoutpromissoriaclinicataxa_Emptyitem);
            ucCombo_configlayoutpromissoriaclinicataxa.SetProperty("DropDownOptionsData", AV43ConfigLayoutPromissoriaClinicaTaxa_Data);
            ucCombo_configlayoutpromissoriaclinicataxa.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_configlayoutpromissoriaclinicataxa_Internalname, "COMBO_CONFIGLAYOUTPROMISSORIACLINICATAXAContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconfiglayoutpromissoriapaciente_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_configlayoutpromissoriapaciente_Internalname, "Layout da nota promissória do paciente", "", "", lblTextblockcombo_configlayoutpromissoriapaciente_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_configlayoutpromissoriapaciente.SetProperty("Caption", Combo_configlayoutpromissoriapaciente_Caption);
            ucCombo_configlayoutpromissoriapaciente.SetProperty("Cls", Combo_configlayoutpromissoriapaciente_Cls);
            ucCombo_configlayoutpromissoriapaciente.SetProperty("EmptyItem", Combo_configlayoutpromissoriapaciente_Emptyitem);
            ucCombo_configlayoutpromissoriapaciente.SetProperty("DropDownOptionsData", AV44ConfigLayoutPromissoriaPaciente_Data);
            ucCombo_configlayoutpromissoriapaciente.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_configlayoutpromissoriapaciente_Internalname, "COMBO_CONFIGLAYOUTPROMISSORIAPACIENTEContainer");
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
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabimagens_title_Internalname, "Imagens", "", "", lblTabimagens_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "tabImagens") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableimagegeight_Internalname, 1, 0, "px", divTableimagegeight_Height, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableimagemlogin.SetProperty("Width", Dvpanel_tableimagemlogin_Width);
            ucDvpanel_tableimagemlogin.SetProperty("AutoWidth", Dvpanel_tableimagemlogin_Autowidth);
            ucDvpanel_tableimagemlogin.SetProperty("AutoHeight", Dvpanel_tableimagemlogin_Autoheight);
            ucDvpanel_tableimagemlogin.SetProperty("Cls", Dvpanel_tableimagemlogin_Cls);
            ucDvpanel_tableimagemlogin.SetProperty("Title", Dvpanel_tableimagemlogin_Title);
            ucDvpanel_tableimagemlogin.SetProperty("Collapsible", Dvpanel_tableimagemlogin_Collapsible);
            ucDvpanel_tableimagemlogin.SetProperty("Collapsed", Dvpanel_tableimagemlogin_Collapsed);
            ucDvpanel_tableimagemlogin.SetProperty("ShowCollapseIcon", Dvpanel_tableimagemlogin_Showcollapseicon);
            ucDvpanel_tableimagemlogin.SetProperty("IconPosition", Dvpanel_tableimagemlogin_Iconposition);
            ucDvpanel_tableimagemlogin.SetProperty("AutoScroll", Dvpanel_tableimagemlogin_Autoscroll);
            ucDvpanel_tableimagemlogin.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableimagemlogin_Internalname, "DVPANEL_TABLEIMAGEMLOGINContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEIMAGEMLOGINContainer"+"TableImagemLogin"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableimagemlogin_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblimagelogin_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_109_542( true) ;
         }
         else
         {
            wb_table1_109_542( false) ;
         }
         return  ;
      }

      protected void wb_table1_109_542e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_panelimagemheader.SetProperty("Width", Dvpanel_panelimagemheader_Width);
            ucDvpanel_panelimagemheader.SetProperty("AutoWidth", Dvpanel_panelimagemheader_Autowidth);
            ucDvpanel_panelimagemheader.SetProperty("AutoHeight", Dvpanel_panelimagemheader_Autoheight);
            ucDvpanel_panelimagemheader.SetProperty("Cls", Dvpanel_panelimagemheader_Cls);
            ucDvpanel_panelimagemheader.SetProperty("Title", Dvpanel_panelimagemheader_Title);
            ucDvpanel_panelimagemheader.SetProperty("Collapsible", Dvpanel_panelimagemheader_Collapsible);
            ucDvpanel_panelimagemheader.SetProperty("Collapsed", Dvpanel_panelimagemheader_Collapsed);
            ucDvpanel_panelimagemheader.SetProperty("ShowCollapseIcon", Dvpanel_panelimagemheader_Showcollapseicon);
            ucDvpanel_panelimagemheader.SetProperty("IconPosition", Dvpanel_panelimagemheader_Iconposition);
            ucDvpanel_panelimagemheader.SetProperty("AutoScroll", Dvpanel_panelimagemheader_Autoscroll);
            ucDvpanel_panelimagemheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_panelimagemheader_Internalname, "DVPANEL_PANELIMAGEMHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PANELIMAGEMHEADERContainer"+"PanelImagemHeader"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPanelimagemheader_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblimagecabecalho_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableimagecabeca_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0132"+"", StringUtil.RTrim( WebComp_Wcimagemcabecalho_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0132"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcimagemcabecalho_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcimagemcabecalho), StringUtil.Lower( WebComp_Wcimagemcabecalho_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0132"+"");
                  }
                  WebComp_Wcimagemcabecalho.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcimagemcabecalho), StringUtil.Lower( WebComp_Wcimagemcabecalho_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblServidoremail_title_Internalname, "Servidor de e-mail", "", "", lblServidoremail_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "ServidorEmail") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavTesteemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTesteemail_Internalname, "E-mail", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTesteemail_Internalname, AV30TesteEmail, StringUtil.RTrim( context.localUtil.Format( AV30TesteEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+AV30TesteEmail, "", "", "", edtavTesteemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTesteemail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_WpConfiguracoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnactesteemail_Internalname, "", "Testar envio de e-mail", bttBtnactesteemail_Jsonclick, 5, "Testar envio de e-mail", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOACTESTEEMAIL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpConfiguracoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletesteemailspace_Internalname, 1, 0, "px", divTabletesteemailspace_Height, "px", "Table", "start", "top", "", "", "div");
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
               GxWebStd.gx_hidden_field( context, "W0152"+"", StringUtil.RTrim( WebComp_Wcservidorsmtpww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0152"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcservidorsmtpww_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcservidorsmtpww), StringUtil.Lower( WebComp_Wcservidorsmtpww_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0152"+"");
                  }
                  WebComp_Wcservidorsmtpww.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcservidorsmtpww), StringUtil.Lower( WebComp_Wcservidorsmtpww_Component)) != 0 )
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title5"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCertificadodigital_title_Internalname, "Certificado", "", "", lblCertificadodigital_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "CertificadoDigital") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcfile.SetProperty("AutoUpload", Ucfile_Autoupload);
            ucUcfile.SetProperty("TooltipText", Ucfile_Tooltiptext);
            ucUcfile.SetProperty("EnableUploadedFileCanceling", Ucfile_Enableuploadedfilecanceling);
            ucUcfile.SetProperty("MaxFileSize", Ucfile_Maxfilesize);
            ucUcfile.SetProperty("MaxNumberOfFiles", Ucfile_Maxnumberoffiles);
            ucUcfile.SetProperty("AcceptedFileTypes", Ucfile_Acceptedfiletypes);
            ucUcfile.SetProperty("CustomFileTypes", Ucfile_Customfiletypes);
            ucUcfile.SetProperty("UploadedFiles", AV6UploadedFiles);
            ucUcfile.SetProperty("FailedFiles", AV7FailedFiles);
            ucUcfile.Render(context, "fileupload", Ucfile_Internalname, "UCFILEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavConfiguracaosenhapfx_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfiguracaosenhapfx_Internalname, "Senha do certificado", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfiguracaosenhapfx_Internalname, AV37ConfiguracaoSenhaPFX, StringUtil.RTrim( context.localUtil.Format( AV37ConfiguracaoSenhaPFX, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,165);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfiguracaosenhapfx_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavConfiguracaosenhapfx_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_WpConfiguracoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title6"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSerasa_title_Internalname, "Serasa", "", "", lblSerasa_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpConfiguracoes.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Serasa") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel6"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavConfiguracoesserasaanotacoescompletas_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConfiguracoesserasaanotacoescompletas_Internalname, "Anotações completas", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConfiguracoesserasaanotacoescompletas, cmbavConfiguracoesserasaanotacoescompletas_Internalname, StringUtil.BoolToStr( AV47ConfiguracoesSerasaAnotacoesCompletas), 1, cmbavConfiguracoesserasaanotacoescompletas_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavConfiguracoesserasaanotacoescompletas.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,175);\"", "", true, 0, "HLP_WpConfiguracoes.htm");
            cmbavConfiguracoesserasaanotacoescompletas.CurrentValue = StringUtil.BoolToStr( AV47ConfiguracoesSerasaAnotacoesCompletas);
            AssignProp("", false, cmbavConfiguracoesserasaanotacoescompletas_Internalname, "Values", (string)(cmbavConfiguracoesserasaanotacoescompletas.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavConfiguracoesserasaconsultadetalhada_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConfiguracoesserasaconsultadetalhada_Internalname, "Consulta detalhada", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConfiguracoesserasaconsultadetalhada, cmbavConfiguracoesserasaconsultadetalhada_Internalname, StringUtil.BoolToStr( AV48ConfiguracoesSerasaConsultaDetalhada), 1, cmbavConfiguracoesserasaconsultadetalhada_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavConfiguracoesserasaconsultadetalhada.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,180);\"", "", true, 0, "HLP_WpConfiguracoes.htm");
            cmbavConfiguracoesserasaconsultadetalhada.CurrentValue = StringUtil.BoolToStr( AV48ConfiguracoesSerasaConsultaDetalhada);
            AssignProp("", false, cmbavConfiguracoesserasaconsultadetalhada_Internalname, "Values", (string)(cmbavConfiguracoesserasaconsultadetalhada.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavConfiguracoesserasahistoricopagamento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConfiguracoesserasahistoricopagamento_Internalname, "Histórico pagamento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 185,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConfiguracoesserasahistoricopagamento, cmbavConfiguracoesserasahistoricopagamento_Internalname, StringUtil.BoolToStr( AV49ConfiguracoesSerasaHistoricoPagamento), 1, cmbavConfiguracoesserasahistoricopagamento_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavConfiguracoesserasahistoricopagamento.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,185);\"", "", true, 0, "HLP_WpConfiguracoes.htm");
            cmbavConfiguracoesserasahistoricopagamento.CurrentValue = StringUtil.BoolToStr( AV49ConfiguracoesSerasaHistoricoPagamento);
            AssignProp("", false, cmbavConfiguracoesserasahistoricopagamento_Internalname, "Values", (string)(cmbavConfiguracoesserasahistoricopagamento.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavConfiguracoesserasaparticipacaosocietaria_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConfiguracoesserasaparticipacaosocietaria_Internalname, "Participação societária", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConfiguracoesserasaparticipacaosocietaria, cmbavConfiguracoesserasaparticipacaosocietaria_Internalname, StringUtil.BoolToStr( AV50ConfiguracoesSerasaParticipacaoSocietaria), 1, cmbavConfiguracoesserasaparticipacaosocietaria_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavConfiguracoesserasaparticipacaosocietaria.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,190);\"", "", true, 0, "HLP_WpConfiguracoes.htm");
            cmbavConfiguracoesserasaparticipacaosocietaria.CurrentValue = StringUtil.BoolToStr( AV50ConfiguracoesSerasaParticipacaoSocietaria);
            AssignProp("", false, cmbavConfiguracoesserasaparticipacaosocietaria_Internalname, "Values", (string)(cmbavConfiguracoesserasaparticipacaosocietaria.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavConfiguracoesserasarendaestimada_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConfiguracoesserasarendaestimada_Internalname, "Renda estimada", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 195,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConfiguracoesserasarendaestimada, cmbavConfiguracoesserasarendaestimada_Internalname, StringUtil.BoolToStr( AV51ConfiguracoesSerasaRendaEstimada), 1, cmbavConfiguracoesserasarendaestimada_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavConfiguracoesserasarendaestimada.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,195);\"", "", true, 0, "HLP_WpConfiguracoes.htm");
            cmbavConfiguracoesserasarendaestimada.CurrentValue = StringUtil.BoolToStr( AV51ConfiguracoesSerasaRendaEstimada);
            AssignProp("", false, cmbavConfiguracoesserasarendaestimada_Internalname, "Values", (string)(cmbavConfiguracoesserasarendaestimada.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
            /* User Defined Control */
            ucColorpicker.Render(context, "uccolorpicker", Colorpicker_Internalname, "COLORPICKERContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfiguracoescategoriatitulo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45ConfiguracoesCategoriaTitulo), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV45ConfiguracoesCategoriaTitulo), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,202);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfiguracoescategoriatitulo_Jsonclick, 0, "Attribute", "", "", "", "", edtavConfiguracoescategoriatitulo_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConfiguracoes.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 203,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfiglayoutcontratocompratitulo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52ConfigLayoutContratoCompraTitulo), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV52ConfigLayoutContratoCompraTitulo), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,203);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfiglayoutcontratocompratitulo_Jsonclick, 0, "Attribute", "", "", "", "", edtavConfiglayoutcontratocompratitulo_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConfiguracoes.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfiguracoeslayoutproposta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ConfiguracoesLayoutProposta), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34ConfiguracoesLayoutProposta), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,204);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfiguracoeslayoutproposta_Jsonclick, 0, "Attribute", "", "", "", "", edtavConfiguracoeslayoutproposta_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConfiguracoes.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 205,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfiglayoutpromissoriaclinicaemprestimo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39ConfigLayoutPromissoriaClinicaEmprestimo), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,205);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfiglayoutpromissoriaclinicaemprestimo_Jsonclick, 0, "Attribute", "", "", "", "", edtavConfiglayoutpromissoriaclinicaemprestimo_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConfiguracoes.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfiglayoutpromissoriaclinicataxa_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ConfigLayoutPromissoriaClinicaTaxa), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40ConfigLayoutPromissoriaClinicaTaxa), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,206);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfiglayoutpromissoriaclinicataxa_Jsonclick, 0, "Attribute", "", "", "", "", edtavConfiglayoutpromissoriaclinicataxa_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConfiguracoes.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfiglayoutpromissoriapaciente_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41ConfigLayoutPromissoriaPaciente), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV41ConfigLayoutPromissoriaPaciente), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,207);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfiglayoutpromissoriapaciente_Jsonclick, 0, "Attribute", "", "", "", "", edtavConfiglayoutpromissoriapaciente_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpConfiguracoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START542( )
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
         Form.Meta.addItem("description", "Configurações", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP540( ) ;
      }

      protected void WS542( )
      {
         START542( ) ;
         EVT542( ) ;
      }

      protected void EVT542( )
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
                              E11542 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOACTESTEEMAIL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAcTesteEmail' */
                              E12542 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E13542 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSELECTEDCOLOR.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14542 ();
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
                                    E15542 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TABLEIMAGE.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Tableimage.Click */
                              E16542 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TABLEIMAGECABECA.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Tableimagecabeca.Click */
                              E17542 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.CONFIGURACOES_REFRESH_IMAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E18542 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E19542 ();
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
                        if ( nCmpId == 115 )
                        {
                           OldWcwcimagem = cgiGet( "W0115");
                           if ( ( StringUtil.Len( OldWcwcimagem) == 0 ) || ( StringUtil.StrCmp(OldWcwcimagem, WebComp_Wcwcimagem_Component) != 0 ) )
                           {
                              WebComp_Wcwcimagem = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcimagem, new Object[] {context} );
                              WebComp_Wcwcimagem.ComponentInit();
                              WebComp_Wcwcimagem.Name = "OldWcwcimagem";
                              WebComp_Wcwcimagem_Component = OldWcwcimagem;
                           }
                           if ( StringUtil.Len( WebComp_Wcwcimagem_Component) != 0 )
                           {
                              WebComp_Wcwcimagem.componentprocess("W0115", "", sEvt);
                           }
                           WebComp_Wcwcimagem_Component = OldWcwcimagem;
                        }
                        else if ( nCmpId == 132 )
                        {
                           OldWcimagemcabecalho = cgiGet( "W0132");
                           if ( ( StringUtil.Len( OldWcimagemcabecalho) == 0 ) || ( StringUtil.StrCmp(OldWcimagemcabecalho, WebComp_Wcimagemcabecalho_Component) != 0 ) )
                           {
                              WebComp_Wcimagemcabecalho = getWebComponent(GetType(), "GeneXus.Programs", OldWcimagemcabecalho, new Object[] {context} );
                              WebComp_Wcimagemcabecalho.ComponentInit();
                              WebComp_Wcimagemcabecalho.Name = "OldWcimagemcabecalho";
                              WebComp_Wcimagemcabecalho_Component = OldWcimagemcabecalho;
                           }
                           if ( StringUtil.Len( WebComp_Wcimagemcabecalho_Component) != 0 )
                           {
                              WebComp_Wcimagemcabecalho.componentprocess("W0132", "", sEvt);
                           }
                           WebComp_Wcimagemcabecalho_Component = OldWcimagemcabecalho;
                        }
                        else if ( nCmpId == 152 )
                        {
                           OldWcservidorsmtpww = cgiGet( "W0152");
                           if ( ( StringUtil.Len( OldWcservidorsmtpww) == 0 ) || ( StringUtil.StrCmp(OldWcservidorsmtpww, WebComp_Wcservidorsmtpww_Component) != 0 ) )
                           {
                              WebComp_Wcservidorsmtpww = getWebComponent(GetType(), "GeneXus.Programs", OldWcservidorsmtpww, new Object[] {context} );
                              WebComp_Wcservidorsmtpww.ComponentInit();
                              WebComp_Wcservidorsmtpww.Name = "OldWcservidorsmtpww";
                              WebComp_Wcservidorsmtpww_Component = OldWcservidorsmtpww;
                           }
                           if ( StringUtil.Len( WebComp_Wcservidorsmtpww_Component) != 0 )
                           {
                              WebComp_Wcservidorsmtpww.componentprocess("W0152", "", sEvt);
                           }
                           WebComp_Wcservidorsmtpww_Component = OldWcservidorsmtpww;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE542( )
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

      protected void PA542( )
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
               GX_FocusControl = edtavSelectedcolor_Internalname;
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
         if ( cmbavConfiguracoesserasaanotacoescompletas.ItemCount > 0 )
         {
            AV47ConfiguracoesSerasaAnotacoesCompletas = StringUtil.StrToBool( cmbavConfiguracoesserasaanotacoescompletas.getValidValue(StringUtil.BoolToStr( AV47ConfiguracoesSerasaAnotacoesCompletas)));
            AssignAttri("", false, "AV47ConfiguracoesSerasaAnotacoesCompletas", AV47ConfiguracoesSerasaAnotacoesCompletas);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConfiguracoesserasaanotacoescompletas.CurrentValue = StringUtil.BoolToStr( AV47ConfiguracoesSerasaAnotacoesCompletas);
            AssignProp("", false, cmbavConfiguracoesserasaanotacoescompletas_Internalname, "Values", cmbavConfiguracoesserasaanotacoescompletas.ToJavascriptSource(), true);
         }
         if ( cmbavConfiguracoesserasaconsultadetalhada.ItemCount > 0 )
         {
            AV48ConfiguracoesSerasaConsultaDetalhada = StringUtil.StrToBool( cmbavConfiguracoesserasaconsultadetalhada.getValidValue(StringUtil.BoolToStr( AV48ConfiguracoesSerasaConsultaDetalhada)));
            AssignAttri("", false, "AV48ConfiguracoesSerasaConsultaDetalhada", AV48ConfiguracoesSerasaConsultaDetalhada);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConfiguracoesserasaconsultadetalhada.CurrentValue = StringUtil.BoolToStr( AV48ConfiguracoesSerasaConsultaDetalhada);
            AssignProp("", false, cmbavConfiguracoesserasaconsultadetalhada_Internalname, "Values", cmbavConfiguracoesserasaconsultadetalhada.ToJavascriptSource(), true);
         }
         if ( cmbavConfiguracoesserasahistoricopagamento.ItemCount > 0 )
         {
            AV49ConfiguracoesSerasaHistoricoPagamento = StringUtil.StrToBool( cmbavConfiguracoesserasahistoricopagamento.getValidValue(StringUtil.BoolToStr( AV49ConfiguracoesSerasaHistoricoPagamento)));
            AssignAttri("", false, "AV49ConfiguracoesSerasaHistoricoPagamento", AV49ConfiguracoesSerasaHistoricoPagamento);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConfiguracoesserasahistoricopagamento.CurrentValue = StringUtil.BoolToStr( AV49ConfiguracoesSerasaHistoricoPagamento);
            AssignProp("", false, cmbavConfiguracoesserasahistoricopagamento_Internalname, "Values", cmbavConfiguracoesserasahistoricopagamento.ToJavascriptSource(), true);
         }
         if ( cmbavConfiguracoesserasaparticipacaosocietaria.ItemCount > 0 )
         {
            AV50ConfiguracoesSerasaParticipacaoSocietaria = StringUtil.StrToBool( cmbavConfiguracoesserasaparticipacaosocietaria.getValidValue(StringUtil.BoolToStr( AV50ConfiguracoesSerasaParticipacaoSocietaria)));
            AssignAttri("", false, "AV50ConfiguracoesSerasaParticipacaoSocietaria", AV50ConfiguracoesSerasaParticipacaoSocietaria);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConfiguracoesserasaparticipacaosocietaria.CurrentValue = StringUtil.BoolToStr( AV50ConfiguracoesSerasaParticipacaoSocietaria);
            AssignProp("", false, cmbavConfiguracoesserasaparticipacaosocietaria_Internalname, "Values", cmbavConfiguracoesserasaparticipacaosocietaria.ToJavascriptSource(), true);
         }
         if ( cmbavConfiguracoesserasarendaestimada.ItemCount > 0 )
         {
            AV51ConfiguracoesSerasaRendaEstimada = StringUtil.StrToBool( cmbavConfiguracoesserasarendaestimada.getValidValue(StringUtil.BoolToStr( AV51ConfiguracoesSerasaRendaEstimada)));
            AssignAttri("", false, "AV51ConfiguracoesSerasaRendaEstimada", AV51ConfiguracoesSerasaRendaEstimada);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConfiguracoesserasarendaestimada.CurrentValue = StringUtil.BoolToStr( AV51ConfiguracoesSerasaRendaEstimada);
            AssignProp("", false, cmbavConfiguracoesserasarendaestimada_Internalname, "Values", cmbavConfiguracoesserasarendaestimada.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF542( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF542( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E13542 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwcimagem_Component) != 0 )
               {
                  WebComp_Wcwcimagem.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcimagemcabecalho_Component) != 0 )
               {
                  WebComp_Wcimagemcabecalho.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcservidorsmtpww_Component) != 0 )
               {
                  WebComp_Wcservidorsmtpww.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E19542 ();
            WB540( ) ;
         }
      }

      protected void send_integrity_lvl_hashes542( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP540( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11542 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vCONFIGURACOESCATEGORIATITULO_DATA"), AV46ConfiguracoesCategoriaTitulo_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCONFIGLAYOUTCONTRATOCOMPRATITULO_DATA"), AV53ConfigLayoutContratoCompraTitulo_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCONFIGURACOESLAYOUTPROPOSTA_DATA"), AV35ConfiguracoesLayoutProposta_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO_DATA"), AV42ConfigLayoutPromissoriaClinicaEmprestimo_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCONFIGLAYOUTPROMISSORIACLINICATAXA_DATA"), AV43ConfigLayoutPromissoriaClinicaTaxa_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCONFIGLAYOUTPROMISSORIAPACIENTE_DATA"), AV44ConfigLayoutPromissoriaPaciente_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vUPLOADEDFILES"), AV6UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( "vFAILEDFILES"), AV7FailedFiles);
            /* Read saved values. */
            Combo_configuracoescategoriatitulo_Cls = cgiGet( "COMBO_CONFIGURACOESCATEGORIATITULO_Cls");
            Combo_configuracoescategoriatitulo_Selectedvalue_set = cgiGet( "COMBO_CONFIGURACOESCATEGORIATITULO_Selectedvalue_set");
            Combo_configuracoescategoriatitulo_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONFIGURACOESCATEGORIATITULO_Emptyitem"));
            Combo_configlayoutcontratocompratitulo_Cls = cgiGet( "COMBO_CONFIGLAYOUTCONTRATOCOMPRATITULO_Cls");
            Combo_configlayoutcontratocompratitulo_Selectedvalue_set = cgiGet( "COMBO_CONFIGLAYOUTCONTRATOCOMPRATITULO_Selectedvalue_set");
            Combo_configlayoutcontratocompratitulo_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONFIGLAYOUTCONTRATOCOMPRATITULO_Emptyitem"));
            Combo_configuracoeslayoutproposta_Cls = cgiGet( "COMBO_CONFIGURACOESLAYOUTPROPOSTA_Cls");
            Combo_configuracoeslayoutproposta_Selectedvalue_set = cgiGet( "COMBO_CONFIGURACOESLAYOUTPROPOSTA_Selectedvalue_set");
            Combo_configuracoeslayoutproposta_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONFIGURACOESLAYOUTPROPOSTA_Emptyitem"));
            Combo_configlayoutpromissoriaclinicaemprestimo_Cls = cgiGet( "COMBO_CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO_Cls");
            Combo_configlayoutpromissoriaclinicaemprestimo_Selectedvalue_set = cgiGet( "COMBO_CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO_Selectedvalue_set");
            Combo_configlayoutpromissoriaclinicaemprestimo_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO_Emptyitem"));
            Combo_configlayoutpromissoriaclinicataxa_Cls = cgiGet( "COMBO_CONFIGLAYOUTPROMISSORIACLINICATAXA_Cls");
            Combo_configlayoutpromissoriaclinicataxa_Selectedvalue_set = cgiGet( "COMBO_CONFIGLAYOUTPROMISSORIACLINICATAXA_Selectedvalue_set");
            Combo_configlayoutpromissoriaclinicataxa_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONFIGLAYOUTPROMISSORIACLINICATAXA_Emptyitem"));
            Combo_configlayoutpromissoriapaciente_Cls = cgiGet( "COMBO_CONFIGLAYOUTPROMISSORIAPACIENTE_Cls");
            Combo_configlayoutpromissoriapaciente_Selectedvalue_set = cgiGet( "COMBO_CONFIGLAYOUTPROMISSORIAPACIENTE_Selectedvalue_set");
            Combo_configlayoutpromissoriapaciente_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONFIGLAYOUTPROMISSORIAPACIENTE_Emptyitem"));
            Gxuitabspanel_tabs2_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS2_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs2_Class = cgiGet( "GXUITABSPANEL_TABS2_Class");
            Gxuitabspanel_tabs2_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS2_Historymanagement"));
            Dvpanel_tableimagemlogin_Width = cgiGet( "DVPANEL_TABLEIMAGEMLOGIN_Width");
            Dvpanel_tableimagemlogin_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEIMAGEMLOGIN_Autowidth"));
            Dvpanel_tableimagemlogin_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEIMAGEMLOGIN_Autoheight"));
            Dvpanel_tableimagemlogin_Cls = cgiGet( "DVPANEL_TABLEIMAGEMLOGIN_Cls");
            Dvpanel_tableimagemlogin_Title = cgiGet( "DVPANEL_TABLEIMAGEMLOGIN_Title");
            Dvpanel_tableimagemlogin_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEIMAGEMLOGIN_Collapsible"));
            Dvpanel_tableimagemlogin_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEIMAGEMLOGIN_Collapsed"));
            Dvpanel_tableimagemlogin_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEIMAGEMLOGIN_Showcollapseicon"));
            Dvpanel_tableimagemlogin_Iconposition = cgiGet( "DVPANEL_TABLEIMAGEMLOGIN_Iconposition");
            Dvpanel_tableimagemlogin_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEIMAGEMLOGIN_Autoscroll"));
            Dvpanel_panelimagemheader_Width = cgiGet( "DVPANEL_PANELIMAGEMHEADER_Width");
            Dvpanel_panelimagemheader_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELIMAGEMHEADER_Autowidth"));
            Dvpanel_panelimagemheader_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELIMAGEMHEADER_Autoheight"));
            Dvpanel_panelimagemheader_Cls = cgiGet( "DVPANEL_PANELIMAGEMHEADER_Cls");
            Dvpanel_panelimagemheader_Title = cgiGet( "DVPANEL_PANELIMAGEMHEADER_Title");
            Dvpanel_panelimagemheader_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELIMAGEMHEADER_Collapsible"));
            Dvpanel_panelimagemheader_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELIMAGEMHEADER_Collapsed"));
            Dvpanel_panelimagemheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELIMAGEMHEADER_Showcollapseicon"));
            Dvpanel_panelimagemheader_Iconposition = cgiGet( "DVPANEL_PANELIMAGEMHEADER_Iconposition");
            Dvpanel_panelimagemheader_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELIMAGEMHEADER_Autoscroll"));
            Ucfile_Autoupload = StringUtil.StrToBool( cgiGet( "UCFILE_Autoupload"));
            Ucfile_Enableuploadedfilecanceling = StringUtil.StrToBool( cgiGet( "UCFILE_Enableuploadedfilecanceling"));
            Ucfile_Maxfilesize = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCFILE_Maxfilesize"), ",", "."), 18, MidpointRounding.ToEven));
            Ucfile_Maxnumberoffiles = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCFILE_Maxnumberoffiles"), ",", "."), 18, MidpointRounding.ToEven));
            Ucfile_Acceptedfiletypes = cgiGet( "UCFILE_Acceptedfiletypes");
            Ucfile_Customfiletypes = cgiGet( "UCFILE_Customfiletypes");
            Gxuitabspanel_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
            Colorpicker_Gxcontrol = cgiGet( "COLORPICKER_Gxcontrol");
            /* Read variables values. */
            AV33SelectedColor = cgiGet( edtavSelectedcolor_Internalname);
            AssignAttri("", false, "AV33SelectedColor", AV33SelectedColor);
            AV30TesteEmail = cgiGet( edtavTesteemail_Internalname);
            AssignAttri("", false, "AV30TesteEmail", AV30TesteEmail);
            AV37ConfiguracaoSenhaPFX = cgiGet( edtavConfiguracaosenhapfx_Internalname);
            AssignAttri("", false, "AV37ConfiguracaoSenhaPFX", AV37ConfiguracaoSenhaPFX);
            cmbavConfiguracoesserasaanotacoescompletas.CurrentValue = cgiGet( cmbavConfiguracoesserasaanotacoescompletas_Internalname);
            AV47ConfiguracoesSerasaAnotacoesCompletas = StringUtil.StrToBool( cgiGet( cmbavConfiguracoesserasaanotacoescompletas_Internalname));
            AssignAttri("", false, "AV47ConfiguracoesSerasaAnotacoesCompletas", AV47ConfiguracoesSerasaAnotacoesCompletas);
            cmbavConfiguracoesserasaconsultadetalhada.CurrentValue = cgiGet( cmbavConfiguracoesserasaconsultadetalhada_Internalname);
            AV48ConfiguracoesSerasaConsultaDetalhada = StringUtil.StrToBool( cgiGet( cmbavConfiguracoesserasaconsultadetalhada_Internalname));
            AssignAttri("", false, "AV48ConfiguracoesSerasaConsultaDetalhada", AV48ConfiguracoesSerasaConsultaDetalhada);
            cmbavConfiguracoesserasahistoricopagamento.CurrentValue = cgiGet( cmbavConfiguracoesserasahistoricopagamento_Internalname);
            AV49ConfiguracoesSerasaHistoricoPagamento = StringUtil.StrToBool( cgiGet( cmbavConfiguracoesserasahistoricopagamento_Internalname));
            AssignAttri("", false, "AV49ConfiguracoesSerasaHistoricoPagamento", AV49ConfiguracoesSerasaHistoricoPagamento);
            cmbavConfiguracoesserasaparticipacaosocietaria.CurrentValue = cgiGet( cmbavConfiguracoesserasaparticipacaosocietaria_Internalname);
            AV50ConfiguracoesSerasaParticipacaoSocietaria = StringUtil.StrToBool( cgiGet( cmbavConfiguracoesserasaparticipacaosocietaria_Internalname));
            AssignAttri("", false, "AV50ConfiguracoesSerasaParticipacaoSocietaria", AV50ConfiguracoesSerasaParticipacaoSocietaria);
            cmbavConfiguracoesserasarendaestimada.CurrentValue = cgiGet( cmbavConfiguracoesserasarendaestimada_Internalname);
            AV51ConfiguracoesSerasaRendaEstimada = StringUtil.StrToBool( cgiGet( cmbavConfiguracoesserasarendaestimada_Internalname));
            AssignAttri("", false, "AV51ConfiguracoesSerasaRendaEstimada", AV51ConfiguracoesSerasaRendaEstimada);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConfiguracoescategoriatitulo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConfiguracoescategoriatitulo_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONFIGURACOESCATEGORIATITULO");
               GX_FocusControl = edtavConfiguracoescategoriatitulo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV45ConfiguracoesCategoriaTitulo = 0;
               AssignAttri("", false, "AV45ConfiguracoesCategoriaTitulo", StringUtil.LTrimStr( (decimal)(AV45ConfiguracoesCategoriaTitulo), 9, 0));
            }
            else
            {
               AV45ConfiguracoesCategoriaTitulo = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavConfiguracoescategoriatitulo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45ConfiguracoesCategoriaTitulo", StringUtil.LTrimStr( (decimal)(AV45ConfiguracoesCategoriaTitulo), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConfiglayoutcontratocompratitulo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConfiglayoutcontratocompratitulo_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONFIGLAYOUTCONTRATOCOMPRATITULO");
               GX_FocusControl = edtavConfiglayoutcontratocompratitulo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV52ConfigLayoutContratoCompraTitulo = 0;
               AssignAttri("", false, "AV52ConfigLayoutContratoCompraTitulo", StringUtil.LTrimStr( (decimal)(AV52ConfigLayoutContratoCompraTitulo), 4, 0));
            }
            else
            {
               AV52ConfigLayoutContratoCompraTitulo = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavConfiglayoutcontratocompratitulo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV52ConfigLayoutContratoCompraTitulo", StringUtil.LTrimStr( (decimal)(AV52ConfigLayoutContratoCompraTitulo), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConfiguracoeslayoutproposta_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConfiguracoeslayoutproposta_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONFIGURACOESLAYOUTPROPOSTA");
               GX_FocusControl = edtavConfiguracoeslayoutproposta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34ConfiguracoesLayoutProposta = 0;
               AssignAttri("", false, "AV34ConfiguracoesLayoutProposta", StringUtil.LTrimStr( (decimal)(AV34ConfiguracoesLayoutProposta), 4, 0));
            }
            else
            {
               AV34ConfiguracoesLayoutProposta = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavConfiguracoeslayoutproposta_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV34ConfiguracoesLayoutProposta", StringUtil.LTrimStr( (decimal)(AV34ConfiguracoesLayoutProposta), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConfiglayoutpromissoriaclinicaemprestimo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConfiglayoutpromissoriaclinicaemprestimo_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO");
               GX_FocusControl = edtavConfiglayoutpromissoriaclinicaemprestimo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39ConfigLayoutPromissoriaClinicaEmprestimo = 0;
               AssignAttri("", false, "AV39ConfigLayoutPromissoriaClinicaEmprestimo", StringUtil.LTrimStr( (decimal)(AV39ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0));
            }
            else
            {
               AV39ConfigLayoutPromissoriaClinicaEmprestimo = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavConfiglayoutpromissoriaclinicaemprestimo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV39ConfigLayoutPromissoriaClinicaEmprestimo", StringUtil.LTrimStr( (decimal)(AV39ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConfiglayoutpromissoriaclinicataxa_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConfiglayoutpromissoriaclinicataxa_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONFIGLAYOUTPROMISSORIACLINICATAXA");
               GX_FocusControl = edtavConfiglayoutpromissoriaclinicataxa_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40ConfigLayoutPromissoriaClinicaTaxa = 0;
               AssignAttri("", false, "AV40ConfigLayoutPromissoriaClinicaTaxa", StringUtil.LTrimStr( (decimal)(AV40ConfigLayoutPromissoriaClinicaTaxa), 4, 0));
            }
            else
            {
               AV40ConfigLayoutPromissoriaClinicaTaxa = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavConfiglayoutpromissoriaclinicataxa_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV40ConfigLayoutPromissoriaClinicaTaxa", StringUtil.LTrimStr( (decimal)(AV40ConfigLayoutPromissoriaClinicaTaxa), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConfiglayoutpromissoriapaciente_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConfiglayoutpromissoriapaciente_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONFIGLAYOUTPROMISSORIAPACIENTE");
               GX_FocusControl = edtavConfiglayoutpromissoriapaciente_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV41ConfigLayoutPromissoriaPaciente = 0;
               AssignAttri("", false, "AV41ConfigLayoutPromissoriaPaciente", StringUtil.LTrimStr( (decimal)(AV41ConfigLayoutPromissoriaPaciente), 4, 0));
            }
            else
            {
               AV41ConfigLayoutPromissoriaPaciente = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavConfiglayoutpromissoriapaciente_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41ConfigLayoutPromissoriaPaciente", StringUtil.LTrimStr( (decimal)(AV41ConfigLayoutPromissoriaPaciente), 4, 0));
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
         E11542 ();
         if (returnInSub) return;
      }

      protected void E11542( )
      {
         /* Start Routine */
         returnInSub = false;
         Colorpicker_Gxcontrol = edtavSelectedcolor_Internalname;
         ucColorpicker.SendProperty(context, "", false, Colorpicker_Internalname, "GxControl", Colorpicker_Gxcontrol);
         /* Using cursor H00542 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A299ConfiguracoesId = H00542_A299ConfiguracoesId[0];
            AV9Configuracoes.Load(A299ConfiguracoesId);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV5ConfiguracoesImagemLogin = AV9Configuracoes.gxTpr_Configuracoesimagemlogin;
         AssignAttri("", false, "AV5ConfiguracoesImagemLogin", AV5ConfiguracoesImagemLogin);
         AV18AuxConfiguracoesImagemLogin = AV5ConfiguracoesImagemLogin;
         AssignAttri("", false, "AV18AuxConfiguracoesImagemLogin", AV18AuxConfiguracoesImagemLogin);
         AV20ConfiguracoesImagemHeader = AV9Configuracoes.gxTpr_Configuracoesimagemheader;
         AssignAttri("", false, "AV20ConfiguracoesImagemHeader", AV20ConfiguracoesImagemHeader);
         AV25AuxConfiguracoesImagemHeader = AV20ConfiguracoesImagemHeader;
         AssignAttri("", false, "AV25AuxConfiguracoesImagemHeader", AV25AuxConfiguracoesImagemHeader);
         AV34ConfiguracoesLayoutProposta = AV9Configuracoes.gxTpr_Configuracoeslayoutproposta;
         AssignAttri("", false, "AV34ConfiguracoesLayoutProposta", StringUtil.LTrimStr( (decimal)(AV34ConfiguracoesLayoutProposta), 4, 0));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Configuracoes.gxTpr_Configuracoesimagemloginnome)) )
         {
            AV14Source = "resources/" + StringUtil.Trim( AV9Configuracoes.gxTpr_Configuracoesimagemloginnome) + "." + StringUtil.Trim( AV9Configuracoes.gxTpr_Configuracoesimagemloginextencao);
            AssignAttri("", false, "AV14Source", AV14Source);
            AV15File.Source = AV14Source;
            AV15File.FromBase64(context.FileToBase64( AV9Configuracoes.gxTpr_Configuracoesimagemlogin));
            AV15File.Create();
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Configuracoes.gxTpr_Configuracoesimagemheadernome)) )
         {
            AV28SourceCabecalho = "resources/" + StringUtil.Trim( AV9Configuracoes.gxTpr_Configuracoesimagemheadernome) + "." + StringUtil.Trim( AV9Configuracoes.gxTpr_Configuracoesimagemheaderextencao);
            AssignAttri("", false, "AV28SourceCabecalho", AV28SourceCabecalho);
            AV27HeaderFile.Source = AV28SourceCabecalho;
            AV27HeaderFile.FromBase64(context.FileToBase64( AV9Configuracoes.gxTpr_Configuracoesimagemlogin));
            AV27HeaderFile.Create();
         }
         AV11Color = AV9Configuracoes.gxTpr_Configuracoesimagemloginbackground;
         AssignAttri("", false, "AV11Color", AV11Color);
         AV33SelectedColor = AV11Color;
         AssignAttri("", false, "AV33SelectedColor", AV33SelectedColor);
         AV10ConfiguracoesImagemLoginExtencao = AV9Configuracoes.gxTpr_Configuracoesimagemloginextencao;
         AssignAttri("", false, "AV10ConfiguracoesImagemLoginExtencao", AV10ConfiguracoesImagemLoginExtencao);
         AV13ConfiguracoesImagemLoginNomeInteiro = AV9Configuracoes.gxTpr_Configuracoesimagemloginnomeinteiro;
         AssignAttri("", false, "AV13ConfiguracoesImagemLoginNomeInteiro", AV13ConfiguracoesImagemLoginNomeInteiro);
         AV12ConfiguracoesImagemLoginTamanho = AV9Configuracoes.gxTpr_Configuracoesimagemlogintamanho;
         AssignAttri("", false, "AV12ConfiguracoesImagemLoginTamanho", StringUtil.LTrimStr( AV12ConfiguracoesImagemLoginTamanho, 18, 2));
         AV39ConfigLayoutPromissoriaClinicaEmprestimo = AV9Configuracoes.gxTpr_Configlayoutpromissoriaclinicaemprestimo;
         AssignAttri("", false, "AV39ConfigLayoutPromissoriaClinicaEmprestimo", StringUtil.LTrimStr( (decimal)(AV39ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0));
         AV40ConfigLayoutPromissoriaClinicaTaxa = AV9Configuracoes.gxTpr_Configlayoutpromissoriaclinicataxa;
         AssignAttri("", false, "AV40ConfigLayoutPromissoriaClinicaTaxa", StringUtil.LTrimStr( (decimal)(AV40ConfigLayoutPromissoriaClinicaTaxa), 4, 0));
         AV41ConfigLayoutPromissoriaPaciente = AV9Configuracoes.gxTpr_Configlayoutpromissoriapaciente;
         AssignAttri("", false, "AV41ConfigLayoutPromissoriaPaciente", StringUtil.LTrimStr( (decimal)(AV41ConfigLayoutPromissoriaPaciente), 4, 0));
         AV45ConfiguracoesCategoriaTitulo = AV9Configuracoes.gxTpr_Configuracoescategoriatitulo;
         AssignAttri("", false, "AV45ConfiguracoesCategoriaTitulo", StringUtil.LTrimStr( (decimal)(AV45ConfiguracoesCategoriaTitulo), 9, 0));
         AV47ConfiguracoesSerasaAnotacoesCompletas = AV9Configuracoes.gxTpr_Configuracoesserasaanotacoescompletas;
         AssignAttri("", false, "AV47ConfiguracoesSerasaAnotacoesCompletas", AV47ConfiguracoesSerasaAnotacoesCompletas);
         AV48ConfiguracoesSerasaConsultaDetalhada = AV9Configuracoes.gxTpr_Configuracoesserasaconsultadetalhada;
         AssignAttri("", false, "AV48ConfiguracoesSerasaConsultaDetalhada", AV48ConfiguracoesSerasaConsultaDetalhada);
         AV50ConfiguracoesSerasaParticipacaoSocietaria = AV9Configuracoes.gxTpr_Configuracoesserasaparticipacaosocietaria;
         AssignAttri("", false, "AV50ConfiguracoesSerasaParticipacaoSocietaria", AV50ConfiguracoesSerasaParticipacaoSocietaria);
         AV52ConfigLayoutContratoCompraTitulo = AV9Configuracoes.gxTpr_Configlayoutcontratocompratitulo;
         AssignAttri("", false, "AV52ConfigLayoutContratoCompraTitulo", StringUtil.LTrimStr( (decimal)(AV52ConfigLayoutContratoCompraTitulo), 4, 0));
         AV51ConfiguracoesSerasaRendaEstimada = AV9Configuracoes.gxTpr_Configuracoesserasarendaestimada;
         AssignAttri("", false, "AV51ConfiguracoesSerasaRendaEstimada", AV51ConfiguracoesSerasaRendaEstimada);
         AV49ConfiguracoesSerasaHistoricoPagamento = AV9Configuracoes.gxTpr_Configuracoesserasahistoricopagamento;
         AssignAttri("", false, "AV49ConfiguracoesSerasaHistoricoPagamento", AV49ConfiguracoesSerasaHistoricoPagamento);
         divTabletesteemailspace_Height = 30;
         AssignProp("", false, divTabletesteemailspace_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTabletesteemailspace_Height), 9, 0), true);
         divTableimagegeight_Height = 30;
         AssignProp("", false, divTableimagegeight_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTableimagegeight_Height), 9, 0), true);
         edtavConfiglayoutpromissoriapaciente_Visible = 0;
         AssignProp("", false, edtavConfiglayoutpromissoriapaciente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfiglayoutpromissoriapaciente_Visible), 5, 0), true);
         edtavConfiglayoutpromissoriaclinicataxa_Visible = 0;
         AssignProp("", false, edtavConfiglayoutpromissoriaclinicataxa_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfiglayoutpromissoriaclinicataxa_Visible), 5, 0), true);
         edtavConfiglayoutpromissoriaclinicaemprestimo_Visible = 0;
         AssignProp("", false, edtavConfiglayoutpromissoriaclinicaemprestimo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfiglayoutpromissoriaclinicaemprestimo_Visible), 5, 0), true);
         edtavConfiguracoeslayoutproposta_Visible = 0;
         AssignProp("", false, edtavConfiguracoeslayoutproposta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfiguracoeslayoutproposta_Visible), 5, 0), true);
         edtavConfiglayoutcontratocompratitulo_Visible = 0;
         AssignProp("", false, edtavConfiglayoutcontratocompratitulo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfiglayoutcontratocompratitulo_Visible), 5, 0), true);
         edtavConfiguracoescategoriatitulo_Visible = 0;
         AssignProp("", false, edtavConfiguracoescategoriatitulo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfiguracoescategoriatitulo_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCONFIGURACOESCATEGORIATITULO' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCONFIGLAYOUTCONTRATOCOMPRATITULO' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCONFIGURACOESLAYOUTPROPOSTA' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCONFIGLAYOUTPROMISSORIACLINICATAXA' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCONFIGLAYOUTPROMISSORIAPACIENTE' */
         S162 ();
         if (returnInSub) return;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcservidorsmtpww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcservidorsmtpww_Component), StringUtil.Lower( "ServidorSMTPWW")) != 0 )
         {
            WebComp_Wcservidorsmtpww = getWebComponent(GetType(), "GeneXus.Programs", "servidorsmtpww", new Object[] {context} );
            WebComp_Wcservidorsmtpww.ComponentInit();
            WebComp_Wcservidorsmtpww.Name = "ServidorSMTPWW";
            WebComp_Wcservidorsmtpww_Component = "ServidorSMTPWW";
         }
         if ( StringUtil.Len( WebComp_Wcservidorsmtpww_Component) != 0 )
         {
            WebComp_Wcservidorsmtpww.setjustcreated();
            WebComp_Wcservidorsmtpww.componentprepare(new Object[] {(string)"W0152",(string)""});
            WebComp_Wcservidorsmtpww.componentbind(new Object[] {});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcimagemcabecalho = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcimagemcabecalho_Component), StringUtil.Lower( "WcImagem")) != 0 )
         {
            WebComp_Wcimagemcabecalho = getWebComponent(GetType(), "GeneXus.Programs", "wcimagem", new Object[] {context} );
            WebComp_Wcimagemcabecalho.ComponentInit();
            WebComp_Wcimagemcabecalho.Name = "WcImagem";
            WebComp_Wcimagemcabecalho_Component = "WcImagem";
         }
         if ( StringUtil.Len( WebComp_Wcimagemcabecalho_Component) != 0 )
         {
            WebComp_Wcimagemcabecalho.setjustcreated();
            WebComp_Wcimagemcabecalho.componentprepare(new Object[] {(string)"W0132",(string)"",(string)AV28SourceCabecalho,(string)AV29ColorCabecalho});
            WebComp_Wcimagemcabecalho.componentbind(new Object[] {(string)"",(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcimagem = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcimagem_Component), StringUtil.Lower( "WcImagem")) != 0 )
         {
            WebComp_Wcwcimagem = getWebComponent(GetType(), "GeneXus.Programs", "wcimagem", new Object[] {context} );
            WebComp_Wcwcimagem.ComponentInit();
            WebComp_Wcwcimagem.Name = "WcImagem";
            WebComp_Wcwcimagem_Component = "WcImagem";
         }
         if ( StringUtil.Len( WebComp_Wcwcimagem_Component) != 0 )
         {
            WebComp_Wcwcimagem.setjustcreated();
            WebComp_Wcwcimagem.componentprepare(new Object[] {(string)"W0115",(string)"",(string)AV14Source,(string)AV11Color});
            WebComp_Wcwcimagem.componentbind(new Object[] {(string)"",(string)""});
         }
      }

      protected void E12542( )
      {
         /* 'DoAcTesteEmail' Routine */
         returnInSub = false;
         AV31Array_Email.Add(AV30TesteEmail, 0);
         new sendemail(context ).execute(  "ERWISE: E-mail de teste",  "Isso é um teste!",  AV31Array_Email, out  AV32message) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32message)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "E-mail enviado!",  "success",  "",  "true",  ""));
         }
         else
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV32message,  "error",  "",  "true",  ""));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31Array_Email", AV31Array_Email);
      }

      protected void S162( )
      {
         /* 'LOADCOMBOCONFIGLAYOUTPROMISSORIAPACIENTE' Routine */
         returnInSub = false;
         /* Using cursor H00543 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A906LayoutContratoTipo = H00543_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = H00543_n906LayoutContratoTipo[0];
            A156LayoutContratoStatus = H00543_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = H00543_n156LayoutContratoStatus[0];
            A154LayoutContratoId = H00543_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = H00543_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = H00543_n155LayoutContratoDescricao[0];
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A154LayoutContratoId), 4, 0));
            AV36Combo_DataItem.gxTpr_Title = A155LayoutContratoDescricao;
            AV44ConfigLayoutPromissoriaPaciente_Data.Add(AV36Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_configlayoutpromissoriapaciente_Selectedvalue_set = ((0==AV41ConfigLayoutPromissoriaPaciente) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV41ConfigLayoutPromissoriaPaciente), 4, 0)));
         ucCombo_configlayoutpromissoriapaciente.SendProperty(context, "", false, Combo_configlayoutpromissoriapaciente_Internalname, "SelectedValue_set", Combo_configlayoutpromissoriapaciente_Selectedvalue_set);
      }

      protected void S152( )
      {
         /* 'LOADCOMBOCONFIGLAYOUTPROMISSORIACLINICATAXA' Routine */
         returnInSub = false;
         /* Using cursor H00544 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A906LayoutContratoTipo = H00544_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = H00544_n906LayoutContratoTipo[0];
            A156LayoutContratoStatus = H00544_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = H00544_n156LayoutContratoStatus[0];
            A154LayoutContratoId = H00544_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = H00544_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = H00544_n155LayoutContratoDescricao[0];
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A154LayoutContratoId), 4, 0));
            AV36Combo_DataItem.gxTpr_Title = A155LayoutContratoDescricao;
            AV43ConfigLayoutPromissoriaClinicaTaxa_Data.Add(AV36Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_configlayoutpromissoriaclinicataxa_Selectedvalue_set = ((0==AV40ConfigLayoutPromissoriaClinicaTaxa) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV40ConfigLayoutPromissoriaClinicaTaxa), 4, 0)));
         ucCombo_configlayoutpromissoriaclinicataxa.SendProperty(context, "", false, Combo_configlayoutpromissoriaclinicataxa_Internalname, "SelectedValue_set", Combo_configlayoutpromissoriaclinicataxa_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOCONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO' Routine */
         returnInSub = false;
         /* Using cursor H00545 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A906LayoutContratoTipo = H00545_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = H00545_n906LayoutContratoTipo[0];
            A156LayoutContratoStatus = H00545_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = H00545_n156LayoutContratoStatus[0];
            A154LayoutContratoId = H00545_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = H00545_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = H00545_n155LayoutContratoDescricao[0];
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A154LayoutContratoId), 4, 0));
            AV36Combo_DataItem.gxTpr_Title = A155LayoutContratoDescricao;
            AV42ConfigLayoutPromissoriaClinicaEmprestimo_Data.Add(AV36Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_configlayoutpromissoriaclinicaemprestimo_Selectedvalue_set = ((0==AV39ConfigLayoutPromissoriaClinicaEmprestimo) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV39ConfigLayoutPromissoriaClinicaEmprestimo), 4, 0)));
         ucCombo_configlayoutpromissoriaclinicaemprestimo.SendProperty(context, "", false, Combo_configlayoutpromissoriaclinicaemprestimo_Internalname, "SelectedValue_set", Combo_configlayoutpromissoriaclinicaemprestimo_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCONFIGURACOESLAYOUTPROPOSTA' Routine */
         returnInSub = false;
         /* Using cursor H00546 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A906LayoutContratoTipo = H00546_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = H00546_n906LayoutContratoTipo[0];
            A154LayoutContratoId = H00546_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = H00546_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = H00546_n155LayoutContratoDescricao[0];
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A154LayoutContratoId), 4, 0));
            AV36Combo_DataItem.gxTpr_Title = A155LayoutContratoDescricao;
            AV35ConfiguracoesLayoutProposta_Data.Add(AV36Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_configuracoeslayoutproposta_Selectedvalue_set = ((0==AV34ConfiguracoesLayoutProposta) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV34ConfiguracoesLayoutProposta), 4, 0)));
         ucCombo_configuracoeslayoutproposta.SendProperty(context, "", false, Combo_configuracoeslayoutproposta_Internalname, "SelectedValue_set", Combo_configuracoeslayoutproposta_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOCONFIGLAYOUTCONTRATOCOMPRATITULO' Routine */
         returnInSub = false;
         /* Using cursor H00547 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A906LayoutContratoTipo = H00547_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = H00547_n906LayoutContratoTipo[0];
            A156LayoutContratoStatus = H00547_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = H00547_n156LayoutContratoStatus[0];
            A154LayoutContratoId = H00547_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = H00547_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = H00547_n155LayoutContratoDescricao[0];
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A154LayoutContratoId), 4, 0));
            AV36Combo_DataItem.gxTpr_Title = A155LayoutContratoDescricao;
            AV53ConfigLayoutContratoCompraTitulo_Data.Add(AV36Combo_DataItem, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         Combo_configlayoutcontratocompratitulo_Selectedvalue_set = ((0==AV52ConfigLayoutContratoCompraTitulo) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV52ConfigLayoutContratoCompraTitulo), 4, 0)));
         ucCombo_configlayoutcontratocompratitulo.SendProperty(context, "", false, Combo_configlayoutcontratocompratitulo_Internalname, "SelectedValue_set", Combo_configlayoutcontratocompratitulo_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCONFIGURACOESCATEGORIATITULO' Routine */
         returnInSub = false;
         /* Using cursor H00548 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A426CategoriaTituloId = H00548_A426CategoriaTituloId[0];
            A427CategoriaTituloNome = H00548_A427CategoriaTituloNome[0];
            n427CategoriaTituloNome = H00548_n427CategoriaTituloNome[0];
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A426CategoriaTituloId), 9, 0));
            AV36Combo_DataItem.gxTpr_Title = A427CategoriaTituloNome;
            AV46ConfiguracoesCategoriaTitulo_Data.Add(AV36Combo_DataItem, 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         Combo_configuracoescategoriatitulo_Selectedvalue_set = ((0==AV45ConfiguracoesCategoriaTitulo) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV45ConfiguracoesCategoriaTitulo), 9, 0)));
         ucCombo_configuracoescategoriatitulo.SendProperty(context, "", false, Combo_configuracoescategoriatitulo_Internalname, "SelectedValue_set", Combo_configuracoescategoriatitulo_Selectedvalue_set);
      }

      protected void E13542( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Configuracoes.gxTpr_Configuracoesimagemloginbackground)) )
         {
         }
      }

      protected void E14542( )
      {
         /* Selectedcolor_Controlvaluechanged Routine */
         returnInSub = false;
         AV11Color = AV33SelectedColor;
         AssignAttri("", false, "AV11Color", AV11Color);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwcimagem = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcimagem_Component), StringUtil.Lower( "WcImagem")) != 0 )
         {
            WebComp_Wcwcimagem = getWebComponent(GetType(), "GeneXus.Programs", "wcimagem", new Object[] {context} );
            WebComp_Wcwcimagem.ComponentInit();
            WebComp_Wcwcimagem.Name = "WcImagem";
            WebComp_Wcwcimagem_Component = "WcImagem";
         }
         if ( StringUtil.Len( WebComp_Wcwcimagem_Component) != 0 )
         {
            WebComp_Wcwcimagem.setjustcreated();
            WebComp_Wcwcimagem.componentprepare(new Object[] {(string)"W0115",(string)"",(string)AV14Source,(string)AV11Color});
            WebComp_Wcwcimagem.componentbind(new Object[] {(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwcimagem )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0115"+"");
            WebComp_Wcwcimagem.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E15542 ();
         if (returnInSub) return;
      }

      protected void E15542( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18AuxConfiguracoesImagemLogin, AV5ConfiguracoesImagemLogin) != 0 )
         {
            AV9Configuracoes.gxTpr_Configuracoesimagemlogin = AV5ConfiguracoesImagemLogin;
            AV9Configuracoes.gxTpr_Configuracoesimagemloginextencao = AV10ConfiguracoesImagemLoginExtencao;
            AV9Configuracoes.gxTpr_Configuracoesimagemloginnome = "ImagemLogin";
            AV9Configuracoes.gxTpr_Configuracoesimagemloginnomeinteiro = AV13ConfiguracoesImagemLoginNomeInteiro;
            AV9Configuracoes.gxTpr_Configuracoesimagemlogintamanho = AV12ConfiguracoesImagemLoginTamanho;
         }
         if ( StringUtil.StrCmp(AV25AuxConfiguracoesImagemHeader, AV20ConfiguracoesImagemHeader) != 0 )
         {
            AV9Configuracoes.gxTpr_Configuracoesimagemheader = AV20ConfiguracoesImagemHeader;
            AV9Configuracoes.gxTpr_Configuracoesimagemheaderextencao = AV22ConfiguracoesImagemHeaderExtencao;
            AV9Configuracoes.gxTpr_Configuracoesimagemheadernome = AV21ConfiguracoesImagemHeaderNome;
            AV9Configuracoes.gxTpr_Configuracoesimagemheadernomeinteiro = AV23ConfiguracoesImagemHeaderNomeInteiro;
            AV9Configuracoes.gxTpr_Configuracoesimagemheadertamanho = AV24ConfiguracoesImagemHeaderTamanho;
            this.executeExternalObjectMethod("", false, "GlobalEvents", "Master_ChangeImage", new Object[] {(string)AV28SourceCabecalho}, true);
         }
         AV9Configuracoes.gxTpr_Configlayoutpromissoriaclinicaemprestimo = AV39ConfigLayoutPromissoriaClinicaEmprestimo;
         AV9Configuracoes.gxTpr_Configlayoutpromissoriaclinicataxa = AV40ConfigLayoutPromissoriaClinicaTaxa;
         AV9Configuracoes.gxTpr_Configlayoutpromissoriapaciente = AV41ConfigLayoutPromissoriaPaciente;
         AV9Configuracoes.gxTpr_Configuracoeslayoutproposta = AV34ConfiguracoesLayoutProposta;
         AV9Configuracoes.gxTpr_Configuracoesimagemloginbackground = AV11Color;
         AV9Configuracoes.gxTpr_Configuracoescategoriatitulo = AV45ConfiguracoesCategoriaTitulo;
         AV9Configuracoes.gxTpr_Configuracoesserasaanotacoescompletas = AV47ConfiguracoesSerasaAnotacoesCompletas;
         AV9Configuracoes.gxTpr_Configuracoesserasaconsultadetalhada = AV48ConfiguracoesSerasaConsultaDetalhada;
         AV9Configuracoes.gxTpr_Configuracoesserasaparticipacaosocietaria = AV50ConfiguracoesSerasaParticipacaoSocietaria;
         AV9Configuracoes.gxTpr_Configuracoesserasarendaestimada = AV51ConfiguracoesSerasaRendaEstimada;
         AV9Configuracoes.gxTpr_Configuracoesserasahistoricopagamento = AV49ConfiguracoesSerasaHistoricoPagamento;
         AV9Configuracoes.gxTpr_Configlayoutcontratocompratitulo = AV52ConfigLayoutContratoCompraTitulo;
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV6UploadedFiles.Count )
         {
            AV8FileUploadData = ((SdtFileUploadData)AV6UploadedFiles.Item(AV66GXV1));
            AV38Blob = AV8FileUploadData.gxTpr_File;
            AV66GXV1 = (int)(AV66GXV1+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Blob)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ConfiguracaoSenhaPFX)) )
         {
            AV9Configuracoes.gxTpr_Configuracoesarquivopfx = AV38Blob;
            AV9Configuracoes.gxTpr_Configuracaosenhapfx = AV37ConfiguracaoSenhaPFX;
         }
         AV9Configuracoes.Save();
         if ( AV9Configuracoes.Success() )
         {
            context.CommitDataStores("wpconfiguracoes",pr_default);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Configurações salvas",  "success",  "",  "true",  ""));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9Configuracoes", AV9Configuracoes);
      }

      protected void E16542( )
      {
         /* Tableimage_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpimagelogin"+UrlEncode(StringUtil.RTrim("Login"));
         context.PopUp(formatLink("wpimagelogin") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
      }

      protected void E17542( )
      {
         /* Tableimagecabeca_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpimagelogin"+UrlEncode(StringUtil.RTrim("Cabecalho"));
         context.PopUp(formatLink("wpimagelogin") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
      }

      protected void E18542( )
      {
         /* General\GlobalEvents_Configuracoes_refresh_image Routine */
         returnInSub = false;
         AV8FileUploadData.FromJSonString(AV17JSON, null);
         if ( StringUtil.StrCmp(AV19DmConfiguracaoImagem, "Login") == 0 )
         {
            AV14Source = "resources/Imagemlogin." + StringUtil.Trim( AV8FileUploadData.gxTpr_Extension);
            AssignAttri("", false, "AV14Source", AV14Source);
            AV15File.Source = AV14Source;
            AV15File.FromBase64(context.FileToBase64( AV8FileUploadData.gxTpr_File));
            AV15File.Create();
            AV26ConfiguracoesImagemLoginNome = "Imagelogin";
            AV5ConfiguracoesImagemLogin = AV8FileUploadData.gxTpr_File;
            AssignAttri("", false, "AV5ConfiguracoesImagemLogin", AV5ConfiguracoesImagemLogin);
            AV10ConfiguracoesImagemLoginExtencao = AV8FileUploadData.gxTpr_Extension;
            AssignAttri("", false, "AV10ConfiguracoesImagemLoginExtencao", AV10ConfiguracoesImagemLoginExtencao);
            AV13ConfiguracoesImagemLoginNomeInteiro = AV8FileUploadData.gxTpr_Fullname;
            AssignAttri("", false, "AV13ConfiguracoesImagemLoginNomeInteiro", AV13ConfiguracoesImagemLoginNomeInteiro);
            AV12ConfiguracoesImagemLoginTamanho = (decimal)(AV8FileUploadData.gxTpr_Size);
            AssignAttri("", false, "AV12ConfiguracoesImagemLoginTamanho", StringUtil.LTrimStr( AV12ConfiguracoesImagemLoginTamanho, 18, 2));
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcwcimagem = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcimagem_Component), StringUtil.Lower( "WcImagem")) != 0 )
            {
               WebComp_Wcwcimagem = getWebComponent(GetType(), "GeneXus.Programs", "wcimagem", new Object[] {context} );
               WebComp_Wcwcimagem.ComponentInit();
               WebComp_Wcwcimagem.Name = "WcImagem";
               WebComp_Wcwcimagem_Component = "WcImagem";
            }
            if ( StringUtil.Len( WebComp_Wcwcimagem_Component) != 0 )
            {
               WebComp_Wcwcimagem.setjustcreated();
               WebComp_Wcwcimagem.componentprepare(new Object[] {(string)"W0115",(string)"",(string)AV14Source,(string)AV11Color});
               WebComp_Wcwcimagem.componentbind(new Object[] {(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwcimagem )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0115"+"");
               WebComp_Wcwcimagem.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(AV19DmConfiguracaoImagem, "Cabecalho") == 0 )
         {
            AV28SourceCabecalho = "resources/Imagemheader." + StringUtil.Trim( AV8FileUploadData.gxTpr_Extension);
            AssignAttri("", false, "AV28SourceCabecalho", AV28SourceCabecalho);
            AV27HeaderFile.Source = AV28SourceCabecalho;
            AV27HeaderFile.FromBase64(context.FileToBase64( AV8FileUploadData.gxTpr_File));
            AV27HeaderFile.Create();
            AV29ColorCabecalho = "#fff";
            AssignAttri("", false, "AV29ColorCabecalho", AV29ColorCabecalho);
            AV20ConfiguracoesImagemHeader = AV8FileUploadData.gxTpr_File;
            AssignAttri("", false, "AV20ConfiguracoesImagemHeader", AV20ConfiguracoesImagemHeader);
            AV21ConfiguracoesImagemHeaderNome = "Imagemheader";
            AssignAttri("", false, "AV21ConfiguracoesImagemHeaderNome", AV21ConfiguracoesImagemHeaderNome);
            AV22ConfiguracoesImagemHeaderExtencao = AV8FileUploadData.gxTpr_Extension;
            AssignAttri("", false, "AV22ConfiguracoesImagemHeaderExtencao", AV22ConfiguracoesImagemHeaderExtencao);
            AV23ConfiguracoesImagemHeaderNomeInteiro = AV8FileUploadData.gxTpr_Fullname;
            AssignAttri("", false, "AV23ConfiguracoesImagemHeaderNomeInteiro", AV23ConfiguracoesImagemHeaderNomeInteiro);
            AV24ConfiguracoesImagemHeaderTamanho = (decimal)(AV8FileUploadData.gxTpr_Size);
            AssignAttri("", false, "AV24ConfiguracoesImagemHeaderTamanho", StringUtil.LTrimStr( AV24ConfiguracoesImagemHeaderTamanho, 18, 2));
            AV29ColorCabecalho = "";
            AssignAttri("", false, "AV29ColorCabecalho", AV29ColorCabecalho);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcimagemcabecalho = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcimagemcabecalho_Component), StringUtil.Lower( "WcImagem")) != 0 )
            {
               WebComp_Wcimagemcabecalho = getWebComponent(GetType(), "GeneXus.Programs", "wcimagem", new Object[] {context} );
               WebComp_Wcimagemcabecalho.ComponentInit();
               WebComp_Wcimagemcabecalho.Name = "WcImagem";
               WebComp_Wcimagemcabecalho_Component = "WcImagem";
            }
            if ( StringUtil.Len( WebComp_Wcimagemcabecalho_Component) != 0 )
            {
               WebComp_Wcimagemcabecalho.setjustcreated();
               WebComp_Wcimagemcabecalho.componentprepare(new Object[] {(string)"W0132",(string)"",(string)AV28SourceCabecalho,(string)AV29ColorCabecalho});
               WebComp_Wcimagemcabecalho.componentbind(new Object[] {(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcimagemcabecalho )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0132"+"");
               WebComp_Wcimagemcabecalho.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E19542( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_109_542( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedtableimage_Internalname, tblTablemergedtableimage_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableimage_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0115"+"", StringUtil.RTrim( WebComp_Wcwcimagem_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0115"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwcimagem_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcimagem), StringUtil.Lower( WebComp_Wcwcimagem_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0115"+"");
                  }
                  WebComp_Wcwcimagem.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcimagem), StringUtil.Lower( WebComp_Wcwcimagem_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecolorselector_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap;align-items:center;align-content:flex-start;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSelectedcolor_Internalname, "Selected Color", "gx-form-item collor-pickerLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSelectedcolor_Internalname, StringUtil.RTrim( AV33SelectedColor), StringUtil.RTrim( context.localUtil.Format( AV33SelectedColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSelectedcolor_Jsonclick, 0, "collor-picker", "", "", "", "", 1, edtavSelectedcolor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpConfiguracoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_109_542e( true) ;
         }
         else
         {
            wb_table1_109_542e( false) ;
         }
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
         PA542( ) ;
         WS542( ) ;
         WE542( ) ;
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
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwcimagem == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcimagem_Component) != 0 )
            {
               WebComp_Wcwcimagem.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcimagemcabecalho == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcimagemcabecalho_Component) != 0 )
            {
               WebComp_Wcimagemcabecalho.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcservidorsmtpww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcservidorsmtpww_Component) != 0 )
            {
               WebComp_Wcservidorsmtpww.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019251445", true, true);
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
         context.AddJavascriptSource("wpconfiguracoes.js", "?202561019251446", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("UserControls/UcColorpickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavConfiguracoesserasaanotacoescompletas.Name = "vCONFIGURACOESSERASAANOTACOESCOMPLETAS";
         cmbavConfiguracoesserasaanotacoescompletas.WebTags = "";
         cmbavConfiguracoesserasaanotacoescompletas.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavConfiguracoesserasaanotacoescompletas.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavConfiguracoesserasaanotacoescompletas.ItemCount > 0 )
         {
            AV47ConfiguracoesSerasaAnotacoesCompletas = StringUtil.StrToBool( cmbavConfiguracoesserasaanotacoescompletas.getValidValue(StringUtil.BoolToStr( AV47ConfiguracoesSerasaAnotacoesCompletas)));
            AssignAttri("", false, "AV47ConfiguracoesSerasaAnotacoesCompletas", AV47ConfiguracoesSerasaAnotacoesCompletas);
         }
         cmbavConfiguracoesserasaconsultadetalhada.Name = "vCONFIGURACOESSERASACONSULTADETALHADA";
         cmbavConfiguracoesserasaconsultadetalhada.WebTags = "";
         cmbavConfiguracoesserasaconsultadetalhada.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavConfiguracoesserasaconsultadetalhada.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavConfiguracoesserasaconsultadetalhada.ItemCount > 0 )
         {
            AV48ConfiguracoesSerasaConsultaDetalhada = StringUtil.StrToBool( cmbavConfiguracoesserasaconsultadetalhada.getValidValue(StringUtil.BoolToStr( AV48ConfiguracoesSerasaConsultaDetalhada)));
            AssignAttri("", false, "AV48ConfiguracoesSerasaConsultaDetalhada", AV48ConfiguracoesSerasaConsultaDetalhada);
         }
         cmbavConfiguracoesserasahistoricopagamento.Name = "vCONFIGURACOESSERASAHISTORICOPAGAMENTO";
         cmbavConfiguracoesserasahistoricopagamento.WebTags = "";
         cmbavConfiguracoesserasahistoricopagamento.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavConfiguracoesserasahistoricopagamento.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavConfiguracoesserasahistoricopagamento.ItemCount > 0 )
         {
            AV49ConfiguracoesSerasaHistoricoPagamento = StringUtil.StrToBool( cmbavConfiguracoesserasahistoricopagamento.getValidValue(StringUtil.BoolToStr( AV49ConfiguracoesSerasaHistoricoPagamento)));
            AssignAttri("", false, "AV49ConfiguracoesSerasaHistoricoPagamento", AV49ConfiguracoesSerasaHistoricoPagamento);
         }
         cmbavConfiguracoesserasaparticipacaosocietaria.Name = "vCONFIGURACOESSERASAPARTICIPACAOSOCIETARIA";
         cmbavConfiguracoesserasaparticipacaosocietaria.WebTags = "";
         cmbavConfiguracoesserasaparticipacaosocietaria.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavConfiguracoesserasaparticipacaosocietaria.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavConfiguracoesserasaparticipacaosocietaria.ItemCount > 0 )
         {
            AV50ConfiguracoesSerasaParticipacaoSocietaria = StringUtil.StrToBool( cmbavConfiguracoesserasaparticipacaosocietaria.getValidValue(StringUtil.BoolToStr( AV50ConfiguracoesSerasaParticipacaoSocietaria)));
            AssignAttri("", false, "AV50ConfiguracoesSerasaParticipacaoSocietaria", AV50ConfiguracoesSerasaParticipacaoSocietaria);
         }
         cmbavConfiguracoesserasarendaestimada.Name = "vCONFIGURACOESSERASARENDAESTIMADA";
         cmbavConfiguracoesserasarendaestimada.WebTags = "";
         cmbavConfiguracoesserasarendaestimada.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavConfiguracoesserasarendaestimada.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavConfiguracoesserasarendaestimada.ItemCount > 0 )
         {
            AV51ConfiguracoesSerasaRendaEstimada = StringUtil.StrToBool( cmbavConfiguracoesserasarendaestimada.getValidValue(StringUtil.BoolToStr( AV51ConfiguracoesSerasaRendaEstimada)));
            AssignAttri("", false, "AV51ConfiguracoesSerasaRendaEstimada", AV51ConfiguracoesSerasaRendaEstimada);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnenter_Internalname = "BTNENTER";
         lblGeral_title_Internalname = "GERAL_TITLE";
         lblTextblockcombo_configuracoescategoriatitulo_Internalname = "TEXTBLOCKCOMBO_CONFIGURACOESCATEGORIATITULO";
         Combo_configuracoescategoriatitulo_Internalname = "COMBO_CONFIGURACOESCATEGORIATITULO";
         divTablesplittedconfiguracoescategoriatitulo_Internalname = "TABLESPLITTEDCONFIGURACOESCATEGORIATITULO";
         divTablegeral_Internalname = "TABLEGERAL";
         lblTabgerais_title_Internalname = "TABGERAIS_TITLE";
         lblTabfactory_title_Internalname = "TABFACTORY_TITLE";
         lblTextblockcombo_configlayoutcontratocompratitulo_Internalname = "TEXTBLOCKCOMBO_CONFIGLAYOUTCONTRATOCOMPRATITULO";
         Combo_configlayoutcontratocompratitulo_Internalname = "COMBO_CONFIGLAYOUTCONTRATOCOMPRATITULO";
         divTablesplittedconfiglayoutcontratocompratitulo_Internalname = "TABLESPLITTEDCONFIGLAYOUTCONTRATOCOMPRATITULO";
         divTabfactory_title_Internalname = "FACTORY";
         lblTabclinica_title_Internalname = "TABCLINICA_TITLE";
         lblTextblockcombo_configuracoeslayoutproposta_Internalname = "TEXTBLOCKCOMBO_CONFIGURACOESLAYOUTPROPOSTA";
         Combo_configuracoeslayoutproposta_Internalname = "COMBO_CONFIGURACOESLAYOUTPROPOSTA";
         divTablesplittedconfiguracoeslayoutproposta_Internalname = "TABLESPLITTEDCONFIGURACOESLAYOUTPROPOSTA";
         lblTextblockcombo_configlayoutpromissoriaclinicaemprestimo_Internalname = "TEXTBLOCKCOMBO_CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO";
         Combo_configlayoutpromissoriaclinicaemprestimo_Internalname = "COMBO_CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO";
         divTablesplittedconfiglayoutpromissoriaclinicaemprestimo_Internalname = "TABLESPLITTEDCONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO";
         lblTextblockcombo_configlayoutpromissoriaclinicataxa_Internalname = "TEXTBLOCKCOMBO_CONFIGLAYOUTPROMISSORIACLINICATAXA";
         Combo_configlayoutpromissoriaclinicataxa_Internalname = "COMBO_CONFIGLAYOUTPROMISSORIACLINICATAXA";
         divTablesplittedconfiglayoutpromissoriaclinicataxa_Internalname = "TABLESPLITTEDCONFIGLAYOUTPROMISSORIACLINICATAXA";
         lblTextblockcombo_configlayoutpromissoriapaciente_Internalname = "TEXTBLOCKCOMBO_CONFIGLAYOUTPROMISSORIAPACIENTE";
         Combo_configlayoutpromissoriapaciente_Internalname = "COMBO_CONFIGLAYOUTPROMISSORIAPACIENTE";
         divTablesplittedconfiglayoutpromissoriapaciente_Internalname = "TABLESPLITTEDCONFIGLAYOUTPROMISSORIAPACIENTE";
         divTabclinica_title_Internalname = "CLINICA";
         Gxuitabspanel_tabs2_Internalname = "GXUITABSPANEL_TABS2";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         lblTabimagens_title_Internalname = "TABIMAGENS_TITLE";
         divTableimagegeight_Internalname = "TABLEIMAGEGEIGHT";
         divTableimage_Internalname = "TABLEIMAGE";
         edtavSelectedcolor_Internalname = "vSELECTEDCOLOR";
         divTablecolorselector_Internalname = "TABLECOLORSELECTOR";
         tblTablemergedtableimage_Internalname = "TABLEMERGEDTABLEIMAGE";
         divTblimagelogin_Internalname = "TBLIMAGELOGIN";
         divTableimagemlogin_Internalname = "TABLEIMAGEMLOGIN";
         Dvpanel_tableimagemlogin_Internalname = "DVPANEL_TABLEIMAGEMLOGIN";
         divTableimagecabeca_Internalname = "TABLEIMAGECABECA";
         divTblimagecabecalho_Internalname = "TBLIMAGECABECALHO";
         divPanelimagemheader_Internalname = "PANELIMAGEMHEADER";
         Dvpanel_panelimagemheader_Internalname = "DVPANEL_PANELIMAGEMHEADER";
         divTablecontent_Internalname = "TABLECONTENT";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         lblServidoremail_title_Internalname = "SERVIDOREMAIL_TITLE";
         edtavTesteemail_Internalname = "vTESTEEMAIL";
         bttBtnactesteemail_Internalname = "BTNACTESTEEMAIL";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         divTabletesteemailspace_Internalname = "TABLETESTEEMAILSPACE";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         lblCertificadodigital_title_Internalname = "CERTIFICADODIGITAL_TITLE";
         Ucfile_Internalname = "UCFILE";
         edtavConfiguracaosenhapfx_Internalname = "vCONFIGURACAOSENHAPFX";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblSerasa_title_Internalname = "SERASA_TITLE";
         cmbavConfiguracoesserasaanotacoescompletas_Internalname = "vCONFIGURACOESSERASAANOTACOESCOMPLETAS";
         cmbavConfiguracoesserasaconsultadetalhada_Internalname = "vCONFIGURACOESSERASACONSULTADETALHADA";
         cmbavConfiguracoesserasahistoricopagamento_Internalname = "vCONFIGURACOESSERASAHISTORICOPAGAMENTO";
         cmbavConfiguracoesserasaparticipacaosocietaria_Internalname = "vCONFIGURACOESSERASAPARTICIPACAOSOCIETARIA";
         cmbavConfiguracoesserasarendaestimada_Internalname = "vCONFIGURACOESSERASARENDAESTIMADA";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
         Colorpicker_Internalname = "COLORPICKER";
         divTablemain_Internalname = "TABLEMAIN";
         edtavConfiguracoescategoriatitulo_Internalname = "vCONFIGURACOESCATEGORIATITULO";
         edtavConfiglayoutcontratocompratitulo_Internalname = "vCONFIGLAYOUTCONTRATOCOMPRATITULO";
         edtavConfiguracoeslayoutproposta_Internalname = "vCONFIGURACOESLAYOUTPROPOSTA";
         edtavConfiglayoutpromissoriaclinicaemprestimo_Internalname = "vCONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO";
         edtavConfiglayoutpromissoriaclinicataxa_Internalname = "vCONFIGLAYOUTPROMISSORIACLINICATAXA";
         edtavConfiglayoutpromissoriapaciente_Internalname = "vCONFIGLAYOUTPROMISSORIAPACIENTE";
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
         edtavSelectedcolor_Jsonclick = "";
         edtavSelectedcolor_Enabled = 1;
         edtavConfiglayoutpromissoriapaciente_Jsonclick = "";
         edtavConfiglayoutpromissoriapaciente_Visible = 1;
         edtavConfiglayoutpromissoriaclinicataxa_Jsonclick = "";
         edtavConfiglayoutpromissoriaclinicataxa_Visible = 1;
         edtavConfiglayoutpromissoriaclinicaemprestimo_Jsonclick = "";
         edtavConfiglayoutpromissoriaclinicaemprestimo_Visible = 1;
         edtavConfiguracoeslayoutproposta_Jsonclick = "";
         edtavConfiguracoeslayoutproposta_Visible = 1;
         edtavConfiglayoutcontratocompratitulo_Jsonclick = "";
         edtavConfiglayoutcontratocompratitulo_Visible = 1;
         edtavConfiguracoescategoriatitulo_Jsonclick = "";
         edtavConfiguracoescategoriatitulo_Visible = 1;
         cmbavConfiguracoesserasarendaestimada_Jsonclick = "";
         cmbavConfiguracoesserasarendaestimada.Enabled = 1;
         cmbavConfiguracoesserasaparticipacaosocietaria_Jsonclick = "";
         cmbavConfiguracoesserasaparticipacaosocietaria.Enabled = 1;
         cmbavConfiguracoesserasahistoricopagamento_Jsonclick = "";
         cmbavConfiguracoesserasahistoricopagamento.Enabled = 1;
         cmbavConfiguracoesserasaconsultadetalhada_Jsonclick = "";
         cmbavConfiguracoesserasaconsultadetalhada.Enabled = 1;
         cmbavConfiguracoesserasaanotacoescompletas_Jsonclick = "";
         cmbavConfiguracoesserasaanotacoescompletas.Enabled = 1;
         edtavConfiguracaosenhapfx_Jsonclick = "";
         edtavConfiguracaosenhapfx_Enabled = 1;
         Ucfile_Tooltiptext = "";
         divTabletesteemailspace_Height = 0;
         edtavTesteemail_Jsonclick = "";
         edtavTesteemail_Enabled = 1;
         divTableimagegeight_Height = 0;
         Colorpicker_Gxcontrol = "";
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 6;
         Ucfile_Customfiletypes = "pfx";
         Ucfile_Acceptedfiletypes = "custom";
         Ucfile_Maxnumberoffiles = 1;
         Ucfile_Maxfilesize = 134217728;
         Ucfile_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Ucfile_Autoupload = Convert.ToBoolean( -1);
         Dvpanel_panelimagemheader_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panelimagemheader_Iconposition = "Right";
         Dvpanel_panelimagemheader_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panelimagemheader_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panelimagemheader_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panelimagemheader_Title = "Imagem do cabeçalho";
         Dvpanel_panelimagemheader_Cls = "PanelCard_GrayTitle";
         Dvpanel_panelimagemheader_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panelimagemheader_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panelimagemheader_Width = "100%";
         Dvpanel_tableimagemlogin_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableimagemlogin_Iconposition = "Right";
         Dvpanel_tableimagemlogin_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableimagemlogin_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableimagemlogin_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableimagemlogin_Title = "Imagem do login";
         Dvpanel_tableimagemlogin_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableimagemlogin_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableimagemlogin_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableimagemlogin_Width = "100%";
         Gxuitabspanel_tabs2_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs2_Class = "Tab";
         Gxuitabspanel_tabs2_Pagecount = 2;
         Combo_configlayoutpromissoriapaciente_Emptyitem = Convert.ToBoolean( 0);
         Combo_configlayoutpromissoriapaciente_Cls = "ExtendedCombo AttributeFL";
         Combo_configlayoutpromissoriaclinicataxa_Emptyitem = Convert.ToBoolean( 0);
         Combo_configlayoutpromissoriaclinicataxa_Cls = "ExtendedCombo AttributeFL";
         Combo_configlayoutpromissoriaclinicaemprestimo_Emptyitem = Convert.ToBoolean( 0);
         Combo_configlayoutpromissoriaclinicaemprestimo_Cls = "ExtendedCombo AttributeFL";
         Combo_configuracoeslayoutproposta_Emptyitem = Convert.ToBoolean( 0);
         Combo_configuracoeslayoutproposta_Cls = "ExtendedCombo AttributeFL";
         Combo_configlayoutcontratocompratitulo_Emptyitem = Convert.ToBoolean( 0);
         Combo_configlayoutcontratocompratitulo_Cls = "ExtendedCombo AttributeFL";
         Combo_configuracoescategoriatitulo_Emptyitem = Convert.ToBoolean( 0);
         Combo_configuracoescategoriatitulo_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Configurações";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV9Configuracoes","fld":"vCONFIGURACOES","type":""}]}""");
         setEventMetadata("'DOACTESTEEMAIL'","""{"handler":"E12542","iparms":[{"av":"AV30TesteEmail","fld":"vTESTEEMAIL","type":"svchar"},{"av":"AV31Array_Email","fld":"vARRAY_EMAIL","type":""}]""");
         setEventMetadata("'DOACTESTEEMAIL'",""","oparms":[{"av":"AV31Array_Email","fld":"vARRAY_EMAIL","type":""}]}""");
         setEventMetadata("VSELECTEDCOLOR.CONTROLVALUECHANGED","""{"handler":"E14542","iparms":[{"av":"AV33SelectedColor","fld":"vSELECTEDCOLOR","type":"char"},{"av":"AV14Source","fld":"vSOURCE","type":"svchar"}]""");
         setEventMetadata("VSELECTEDCOLOR.CONTROLVALUECHANGED",""","oparms":[{"av":"AV11Color","fld":"vCOLOR","type":"svchar"},{"ctrl":"WCWCIMAGEM"}]}""");
         setEventMetadata("ENTER","""{"handler":"E15542","iparms":[{"av":"AV18AuxConfiguracoesImagemLogin","fld":"vAUXCONFIGURACOESIMAGEMLOGIN","type":"bitstr"},{"av":"AV5ConfiguracoesImagemLogin","fld":"vCONFIGURACOESIMAGEMLOGIN","type":"bitstr"},{"av":"AV9Configuracoes","fld":"vCONFIGURACOES","type":""},{"av":"AV10ConfiguracoesImagemLoginExtencao","fld":"vCONFIGURACOESIMAGEMLOGINEXTENCAO","type":"svchar"},{"av":"AV13ConfiguracoesImagemLoginNomeInteiro","fld":"vCONFIGURACOESIMAGEMLOGINNOMEINTEIRO","type":"svchar"},{"av":"AV12ConfiguracoesImagemLoginTamanho","fld":"vCONFIGURACOESIMAGEMLOGINTAMANHO","pic":"ZZZZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV25AuxConfiguracoesImagemHeader","fld":"vAUXCONFIGURACOESIMAGEMHEADER","type":"bitstr"},{"av":"AV20ConfiguracoesImagemHeader","fld":"vCONFIGURACOESIMAGEMHEADER","type":"bitstr"},{"av":"AV22ConfiguracoesImagemHeaderExtencao","fld":"vCONFIGURACOESIMAGEMHEADEREXTENCAO","type":"svchar"},{"av":"AV21ConfiguracoesImagemHeaderNome","fld":"vCONFIGURACOESIMAGEMHEADERNOME","type":"svchar"},{"av":"AV23ConfiguracoesImagemHeaderNomeInteiro","fld":"vCONFIGURACOESIMAGEMHEADERNOMEINTEIRO","type":"svchar"},{"av":"AV24ConfiguracoesImagemHeaderTamanho","fld":"vCONFIGURACOESIMAGEMHEADERTAMANHO","pic":"ZZZZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV28SourceCabecalho","fld":"vSOURCECABECALHO","type":"svchar"},{"av":"AV39ConfigLayoutPromissoriaClinicaEmprestimo","fld":"vCONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO","pic":"ZZZ9","type":"int"},{"av":"AV40ConfigLayoutPromissoriaClinicaTaxa","fld":"vCONFIGLAYOUTPROMISSORIACLINICATAXA","pic":"ZZZ9","type":"int"},{"av":"AV41ConfigLayoutPromissoriaPaciente","fld":"vCONFIGLAYOUTPROMISSORIAPACIENTE","pic":"ZZZ9","type":"int"},{"av":"AV34ConfiguracoesLayoutProposta","fld":"vCONFIGURACOESLAYOUTPROPOSTA","pic":"ZZZ9","type":"int"},{"av":"AV11Color","fld":"vCOLOR","type":"svchar"},{"av":"AV45ConfiguracoesCategoriaTitulo","fld":"vCONFIGURACOESCATEGORIATITULO","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavConfiguracoesserasaanotacoescompletas"},{"av":"AV47ConfiguracoesSerasaAnotacoesCompletas","fld":"vCONFIGURACOESSERASAANOTACOESCOMPLETAS","type":"boolean"},{"av":"cmbavConfiguracoesserasaconsultadetalhada"},{"av":"AV48ConfiguracoesSerasaConsultaDetalhada","fld":"vCONFIGURACOESSERASACONSULTADETALHADA","type":"boolean"},{"av":"cmbavConfiguracoesserasaparticipacaosocietaria"},{"av":"AV50ConfiguracoesSerasaParticipacaoSocietaria","fld":"vCONFIGURACOESSERASAPARTICIPACAOSOCIETARIA","type":"boolean"},{"av":"cmbavConfiguracoesserasarendaestimada"},{"av":"AV51ConfiguracoesSerasaRendaEstimada","fld":"vCONFIGURACOESSERASARENDAESTIMADA","type":"boolean"},{"av":"cmbavConfiguracoesserasahistoricopagamento"},{"av":"AV49ConfiguracoesSerasaHistoricoPagamento","fld":"vCONFIGURACOESSERASAHISTORICOPAGAMENTO","type":"boolean"},{"av":"AV52ConfigLayoutContratoCompraTitulo","fld":"vCONFIGLAYOUTCONTRATOCOMPRATITULO","pic":"ZZZ9","type":"int"},{"av":"AV6UploadedFiles","fld":"vUPLOADEDFILES","type":""},{"av":"AV37ConfiguracaoSenhaPFX","fld":"vCONFIGURACAOSENHAPFX","type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV9Configuracoes","fld":"vCONFIGURACOES","type":""}]}""");
         setEventMetadata("TABLEIMAGE.CLICK","""{"handler":"E16542","iparms":[]}""");
         setEventMetadata("TABLEIMAGECABECA.CLICK","""{"handler":"E17542","iparms":[]}""");
         setEventMetadata("GLOBALEVENTS.CONFIGURACOES_REFRESH_IMAGE","""{"handler":"E18542","iparms":[{"av":"AV19DmConfiguracaoImagem","fld":"vDMCONFIGURACAOIMAGEM","type":"svchar"},{"av":"AV17JSON","fld":"vJSON","type":"svchar"},{"av":"AV11Color","fld":"vCOLOR","type":"svchar"}]""");
         setEventMetadata("GLOBALEVENTS.CONFIGURACOES_REFRESH_IMAGE",""","oparms":[{"av":"AV14Source","fld":"vSOURCE","type":"svchar"},{"av":"AV5ConfiguracoesImagemLogin","fld":"vCONFIGURACOESIMAGEMLOGIN","type":"bitstr"},{"av":"AV10ConfiguracoesImagemLoginExtencao","fld":"vCONFIGURACOESIMAGEMLOGINEXTENCAO","type":"svchar"},{"av":"AV13ConfiguracoesImagemLoginNomeInteiro","fld":"vCONFIGURACOESIMAGEMLOGINNOMEINTEIRO","type":"svchar"},{"av":"AV12ConfiguracoesImagemLoginTamanho","fld":"vCONFIGURACOESIMAGEMLOGINTAMANHO","pic":"ZZZZZZZZZZZZZZ9.99","type":"decimal"},{"ctrl":"WCWCIMAGEM"},{"av":"AV28SourceCabecalho","fld":"vSOURCECABECALHO","type":"svchar"},{"av":"AV29ColorCabecalho","fld":"vCOLORCABECALHO","type":"svchar"},{"av":"AV20ConfiguracoesImagemHeader","fld":"vCONFIGURACOESIMAGEMHEADER","type":"bitstr"},{"av":"AV21ConfiguracoesImagemHeaderNome","fld":"vCONFIGURACOESIMAGEMHEADERNOME","type":"svchar"},{"av":"AV22ConfiguracoesImagemHeaderExtencao","fld":"vCONFIGURACOESIMAGEMHEADEREXTENCAO","type":"svchar"},{"av":"AV23ConfiguracoesImagemHeaderNomeInteiro","fld":"vCONFIGURACOESIMAGEMHEADERNOMEINTEIRO","type":"svchar"},{"av":"AV24ConfiguracoesImagemHeaderTamanho","fld":"vCONFIGURACOESIMAGEMHEADERTAMANHO","pic":"ZZZZZZZZZZZZZZ9.99","type":"decimal"},{"ctrl":"WCIMAGEMCABECALHO"}]}""");
         setEventMetadata("VALIDV_TESTEEMAIL","""{"handler":"Validv_Testeemail","iparms":[]}""");
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         Combo_configlayoutpromissoriapaciente_Selectedvalue_get = "";
         Combo_configlayoutpromissoriaclinicataxa_Selectedvalue_get = "";
         Combo_configlayoutpromissoriaclinicaemprestimo_Selectedvalue_get = "";
         Combo_configuracoeslayoutproposta_Selectedvalue_get = "";
         Combo_configlayoutcontratocompratitulo_Selectedvalue_get = "";
         Combo_configuracoescategoriatitulo_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV46ConfiguracoesCategoriaTitulo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV53ConfigLayoutContratoCompraTitulo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV35ConfiguracoesLayoutProposta_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV42ConfigLayoutPromissoriaClinicaEmprestimo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV43ConfigLayoutPromissoriaClinicaTaxa_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV44ConfigLayoutPromissoriaPaciente_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV6UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Factory21");
         AV7FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Factory21");
         AV31Array_Email = new GxSimpleCollection<string>();
         AV9Configuracoes = new SdtConfiguracoes(context);
         AV14Source = "";
         AV18AuxConfiguracoesImagemLogin = "";
         AV5ConfiguracoesImagemLogin = "";
         AV10ConfiguracoesImagemLoginExtencao = "";
         AV13ConfiguracoesImagemLoginNomeInteiro = "";
         AV25AuxConfiguracoesImagemHeader = "";
         AV20ConfiguracoesImagemHeader = "";
         AV22ConfiguracoesImagemHeaderExtencao = "";
         AV21ConfiguracoesImagemHeaderNome = "";
         AV23ConfiguracoesImagemHeaderNomeInteiro = "";
         AV28SourceCabecalho = "";
         AV11Color = "";
         AV19DmConfiguracaoImagem = "";
         AV17JSON = "";
         Combo_configuracoescategoriatitulo_Selectedvalue_set = "";
         Combo_configlayoutcontratocompratitulo_Selectedvalue_set = "";
         Combo_configuracoeslayoutproposta_Selectedvalue_set = "";
         Combo_configlayoutpromissoriaclinicaemprestimo_Selectedvalue_set = "";
         Combo_configlayoutpromissoriaclinicataxa_Selectedvalue_set = "";
         Combo_configlayoutpromissoriapaciente_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnenter_Jsonclick = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblGeral_title_Jsonclick = "";
         lblTextblockcombo_configuracoescategoriatitulo_Jsonclick = "";
         ucCombo_configuracoescategoriatitulo = new GXUserControl();
         Combo_configuracoescategoriatitulo_Caption = "";
         lblTabgerais_title_Jsonclick = "";
         ucGxuitabspanel_tabs2 = new GXUserControl();
         lblTabfactory_title_Jsonclick = "";
         lblTextblockcombo_configlayoutcontratocompratitulo_Jsonclick = "";
         ucCombo_configlayoutcontratocompratitulo = new GXUserControl();
         Combo_configlayoutcontratocompratitulo_Caption = "";
         lblTabclinica_title_Jsonclick = "";
         lblTextblockcombo_configuracoeslayoutproposta_Jsonclick = "";
         ucCombo_configuracoeslayoutproposta = new GXUserControl();
         Combo_configuracoeslayoutproposta_Caption = "";
         lblTextblockcombo_configlayoutpromissoriaclinicaemprestimo_Jsonclick = "";
         ucCombo_configlayoutpromissoriaclinicaemprestimo = new GXUserControl();
         Combo_configlayoutpromissoriaclinicaemprestimo_Caption = "";
         lblTextblockcombo_configlayoutpromissoriaclinicataxa_Jsonclick = "";
         ucCombo_configlayoutpromissoriaclinicataxa = new GXUserControl();
         Combo_configlayoutpromissoriaclinicataxa_Caption = "";
         lblTextblockcombo_configlayoutpromissoriapaciente_Jsonclick = "";
         ucCombo_configlayoutpromissoriapaciente = new GXUserControl();
         Combo_configlayoutpromissoriapaciente_Caption = "";
         lblTabimagens_title_Jsonclick = "";
         ucDvpanel_tableimagemlogin = new GXUserControl();
         ucDvpanel_panelimagemheader = new GXUserControl();
         WebComp_Wcimagemcabecalho_Component = "";
         OldWcimagemcabecalho = "";
         lblServidoremail_title_Jsonclick = "";
         AV30TesteEmail = "";
         bttBtnactesteemail_Jsonclick = "";
         WebComp_Wcservidorsmtpww_Component = "";
         OldWcservidorsmtpww = "";
         lblCertificadodigital_title_Jsonclick = "";
         ucUcfile = new GXUserControl();
         AV37ConfiguracaoSenhaPFX = "";
         lblSerasa_title_Jsonclick = "";
         ucColorpicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldWcwcimagem = "";
         WebComp_Wcwcimagem_Component = "";
         AV33SelectedColor = "";
         H00542_A299ConfiguracoesId = new int[1] ;
         AV15File = new GxFile(context.GetPhysicalPath());
         AV27HeaderFile = new GxFile(context.GetPhysicalPath());
         AV29ColorCabecalho = "";
         AV32message = "";
         H00543_A906LayoutContratoTipo = new string[] {""} ;
         H00543_n906LayoutContratoTipo = new bool[] {false} ;
         H00543_A156LayoutContratoStatus = new bool[] {false} ;
         H00543_n156LayoutContratoStatus = new bool[] {false} ;
         H00543_A154LayoutContratoId = new short[1] ;
         H00543_A155LayoutContratoDescricao = new string[] {""} ;
         H00543_n155LayoutContratoDescricao = new bool[] {false} ;
         A906LayoutContratoTipo = "";
         A155LayoutContratoDescricao = "";
         AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H00544_A906LayoutContratoTipo = new string[] {""} ;
         H00544_n906LayoutContratoTipo = new bool[] {false} ;
         H00544_A156LayoutContratoStatus = new bool[] {false} ;
         H00544_n156LayoutContratoStatus = new bool[] {false} ;
         H00544_A154LayoutContratoId = new short[1] ;
         H00544_A155LayoutContratoDescricao = new string[] {""} ;
         H00544_n155LayoutContratoDescricao = new bool[] {false} ;
         H00545_A906LayoutContratoTipo = new string[] {""} ;
         H00545_n906LayoutContratoTipo = new bool[] {false} ;
         H00545_A156LayoutContratoStatus = new bool[] {false} ;
         H00545_n156LayoutContratoStatus = new bool[] {false} ;
         H00545_A154LayoutContratoId = new short[1] ;
         H00545_A155LayoutContratoDescricao = new string[] {""} ;
         H00545_n155LayoutContratoDescricao = new bool[] {false} ;
         H00546_A906LayoutContratoTipo = new string[] {""} ;
         H00546_n906LayoutContratoTipo = new bool[] {false} ;
         H00546_A154LayoutContratoId = new short[1] ;
         H00546_A155LayoutContratoDescricao = new string[] {""} ;
         H00546_n155LayoutContratoDescricao = new bool[] {false} ;
         H00547_A906LayoutContratoTipo = new string[] {""} ;
         H00547_n906LayoutContratoTipo = new bool[] {false} ;
         H00547_A156LayoutContratoStatus = new bool[] {false} ;
         H00547_n156LayoutContratoStatus = new bool[] {false} ;
         H00547_A154LayoutContratoId = new short[1] ;
         H00547_A155LayoutContratoDescricao = new string[] {""} ;
         H00547_n155LayoutContratoDescricao = new bool[] {false} ;
         H00548_A426CategoriaTituloId = new int[1] ;
         H00548_A427CategoriaTituloNome = new string[] {""} ;
         H00548_n427CategoriaTituloNome = new bool[] {false} ;
         A427CategoriaTituloNome = "";
         AV8FileUploadData = new SdtFileUploadData(context);
         AV38Blob = "";
         GXEncryptionTmp = "";
         AV26ConfiguracoesImagemLoginNome = "";
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpconfiguracoes__default(),
            new Object[][] {
                new Object[] {
               H00542_A299ConfiguracoesId
               }
               , new Object[] {
               H00543_A906LayoutContratoTipo, H00543_n906LayoutContratoTipo, H00543_A156LayoutContratoStatus, H00543_n156LayoutContratoStatus, H00543_A154LayoutContratoId, H00543_A155LayoutContratoDescricao, H00543_n155LayoutContratoDescricao
               }
               , new Object[] {
               H00544_A906LayoutContratoTipo, H00544_n906LayoutContratoTipo, H00544_A156LayoutContratoStatus, H00544_n156LayoutContratoStatus, H00544_A154LayoutContratoId, H00544_A155LayoutContratoDescricao, H00544_n155LayoutContratoDescricao
               }
               , new Object[] {
               H00545_A906LayoutContratoTipo, H00545_n906LayoutContratoTipo, H00545_A156LayoutContratoStatus, H00545_n156LayoutContratoStatus, H00545_A154LayoutContratoId, H00545_A155LayoutContratoDescricao, H00545_n155LayoutContratoDescricao
               }
               , new Object[] {
               H00546_A906LayoutContratoTipo, H00546_n906LayoutContratoTipo, H00546_A154LayoutContratoId, H00546_A155LayoutContratoDescricao, H00546_n155LayoutContratoDescricao
               }
               , new Object[] {
               H00547_A906LayoutContratoTipo, H00547_n906LayoutContratoTipo, H00547_A156LayoutContratoStatus, H00547_n156LayoutContratoStatus, H00547_A154LayoutContratoId, H00547_A155LayoutContratoDescricao, H00547_n155LayoutContratoDescricao
               }
               , new Object[] {
               H00548_A426CategoriaTituloId, H00548_A427CategoriaTituloNome, H00548_n427CategoriaTituloNome
               }
            }
         );
         WebComp_Wcwcimagem = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcimagemcabecalho = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcservidorsmtpww = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV52ConfigLayoutContratoCompraTitulo ;
      private short AV34ConfiguracoesLayoutProposta ;
      private short AV39ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short AV40ConfigLayoutPromissoriaClinicaTaxa ;
      private short AV41ConfigLayoutPromissoriaPaciente ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A154LayoutContratoId ;
      private short nGXWrapped ;
      private int Gxuitabspanel_tabs2_Pagecount ;
      private int Ucfile_Maxfilesize ;
      private int Ucfile_Maxnumberoffiles ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int divTableimagegeight_Height ;
      private int edtavTesteemail_Enabled ;
      private int divTabletesteemailspace_Height ;
      private int edtavConfiguracaosenhapfx_Enabled ;
      private int AV45ConfiguracoesCategoriaTitulo ;
      private int edtavConfiguracoescategoriatitulo_Visible ;
      private int edtavConfiglayoutcontratocompratitulo_Visible ;
      private int edtavConfiguracoeslayoutproposta_Visible ;
      private int edtavConfiglayoutpromissoriaclinicaemprestimo_Visible ;
      private int edtavConfiglayoutpromissoriaclinicataxa_Visible ;
      private int edtavConfiglayoutpromissoriapaciente_Visible ;
      private int A299ConfiguracoesId ;
      private int A426CategoriaTituloId ;
      private int AV66GXV1 ;
      private int edtavSelectedcolor_Enabled ;
      private int idxLst ;
      private decimal AV12ConfiguracoesImagemLoginTamanho ;
      private decimal AV24ConfiguracoesImagemHeaderTamanho ;
      private string Combo_configlayoutpromissoriapaciente_Selectedvalue_get ;
      private string Combo_configlayoutpromissoriaclinicataxa_Selectedvalue_get ;
      private string Combo_configlayoutpromissoriaclinicaemprestimo_Selectedvalue_get ;
      private string Combo_configuracoeslayoutproposta_Selectedvalue_get ;
      private string Combo_configlayoutcontratocompratitulo_Selectedvalue_get ;
      private string Combo_configuracoescategoriatitulo_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_configuracoescategoriatitulo_Cls ;
      private string Combo_configuracoescategoriatitulo_Selectedvalue_set ;
      private string Combo_configlayoutcontratocompratitulo_Cls ;
      private string Combo_configlayoutcontratocompratitulo_Selectedvalue_set ;
      private string Combo_configuracoeslayoutproposta_Cls ;
      private string Combo_configuracoeslayoutproposta_Selectedvalue_set ;
      private string Combo_configlayoutpromissoriaclinicaemprestimo_Cls ;
      private string Combo_configlayoutpromissoriaclinicaemprestimo_Selectedvalue_set ;
      private string Combo_configlayoutpromissoriaclinicataxa_Cls ;
      private string Combo_configlayoutpromissoriaclinicataxa_Selectedvalue_set ;
      private string Combo_configlayoutpromissoriapaciente_Cls ;
      private string Combo_configlayoutpromissoriapaciente_Selectedvalue_set ;
      private string Gxuitabspanel_tabs2_Class ;
      private string Dvpanel_tableimagemlogin_Width ;
      private string Dvpanel_tableimagemlogin_Cls ;
      private string Dvpanel_tableimagemlogin_Title ;
      private string Dvpanel_tableimagemlogin_Iconposition ;
      private string Dvpanel_panelimagemheader_Width ;
      private string Dvpanel_panelimagemheader_Cls ;
      private string Dvpanel_panelimagemheader_Title ;
      private string Dvpanel_panelimagemheader_Iconposition ;
      private string Ucfile_Acceptedfiletypes ;
      private string Ucfile_Customfiletypes ;
      private string Gxuitabspanel_tabs1_Class ;
      private string Colorpicker_Gxcontrol ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblGeral_title_Internalname ;
      private string lblGeral_title_Jsonclick ;
      private string divTablegeral_Internalname ;
      private string divTablesplittedconfiguracoescategoriatitulo_Internalname ;
      private string lblTextblockcombo_configuracoescategoriatitulo_Internalname ;
      private string lblTextblockcombo_configuracoescategoriatitulo_Jsonclick ;
      private string Combo_configuracoescategoriatitulo_Caption ;
      private string Combo_configuracoescategoriatitulo_Internalname ;
      private string lblTabgerais_title_Internalname ;
      private string lblTabgerais_title_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string Gxuitabspanel_tabs2_Internalname ;
      private string lblTabfactory_title_Internalname ;
      private string lblTabfactory_title_Jsonclick ;
      private string divTabfactory_title_Internalname ;
      private string divTablesplittedconfiglayoutcontratocompratitulo_Internalname ;
      private string lblTextblockcombo_configlayoutcontratocompratitulo_Internalname ;
      private string lblTextblockcombo_configlayoutcontratocompratitulo_Jsonclick ;
      private string Combo_configlayoutcontratocompratitulo_Caption ;
      private string Combo_configlayoutcontratocompratitulo_Internalname ;
      private string lblTabclinica_title_Internalname ;
      private string lblTabclinica_title_Jsonclick ;
      private string divTabclinica_title_Internalname ;
      private string divTablesplittedconfiguracoeslayoutproposta_Internalname ;
      private string lblTextblockcombo_configuracoeslayoutproposta_Internalname ;
      private string lblTextblockcombo_configuracoeslayoutproposta_Jsonclick ;
      private string Combo_configuracoeslayoutproposta_Caption ;
      private string Combo_configuracoeslayoutproposta_Internalname ;
      private string divTablesplittedconfiglayoutpromissoriaclinicaemprestimo_Internalname ;
      private string lblTextblockcombo_configlayoutpromissoriaclinicaemprestimo_Internalname ;
      private string lblTextblockcombo_configlayoutpromissoriaclinicaemprestimo_Jsonclick ;
      private string Combo_configlayoutpromissoriaclinicaemprestimo_Caption ;
      private string Combo_configlayoutpromissoriaclinicaemprestimo_Internalname ;
      private string divTablesplittedconfiglayoutpromissoriaclinicataxa_Internalname ;
      private string lblTextblockcombo_configlayoutpromissoriaclinicataxa_Internalname ;
      private string lblTextblockcombo_configlayoutpromissoriaclinicataxa_Jsonclick ;
      private string Combo_configlayoutpromissoriaclinicataxa_Caption ;
      private string Combo_configlayoutpromissoriaclinicataxa_Internalname ;
      private string divTablesplittedconfiglayoutpromissoriapaciente_Internalname ;
      private string lblTextblockcombo_configlayoutpromissoriapaciente_Internalname ;
      private string lblTextblockcombo_configlayoutpromissoriapaciente_Jsonclick ;
      private string Combo_configlayoutpromissoriapaciente_Caption ;
      private string Combo_configlayoutpromissoriapaciente_Internalname ;
      private string lblTabimagens_title_Internalname ;
      private string lblTabimagens_title_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string divTableimagegeight_Internalname ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableimagemlogin_Internalname ;
      private string divTableimagemlogin_Internalname ;
      private string divTblimagelogin_Internalname ;
      private string Dvpanel_panelimagemheader_Internalname ;
      private string divPanelimagemheader_Internalname ;
      private string divTblimagecabecalho_Internalname ;
      private string divTableimagecabeca_Internalname ;
      private string WebComp_Wcimagemcabecalho_Component ;
      private string OldWcimagemcabecalho ;
      private string lblServidoremail_title_Internalname ;
      private string lblServidoremail_title_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string edtavTesteemail_Internalname ;
      private string edtavTesteemail_Jsonclick ;
      private string bttBtnactesteemail_Internalname ;
      private string bttBtnactesteemail_Jsonclick ;
      private string divTabletesteemailspace_Internalname ;
      private string WebComp_Wcservidorsmtpww_Component ;
      private string OldWcservidorsmtpww ;
      private string lblCertificadodigital_title_Internalname ;
      private string lblCertificadodigital_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string Ucfile_Tooltiptext ;
      private string Ucfile_Internalname ;
      private string edtavConfiguracaosenhapfx_Internalname ;
      private string edtavConfiguracaosenhapfx_Jsonclick ;
      private string lblSerasa_title_Internalname ;
      private string lblSerasa_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string cmbavConfiguracoesserasaanotacoescompletas_Internalname ;
      private string cmbavConfiguracoesserasaanotacoescompletas_Jsonclick ;
      private string cmbavConfiguracoesserasaconsultadetalhada_Internalname ;
      private string cmbavConfiguracoesserasaconsultadetalhada_Jsonclick ;
      private string cmbavConfiguracoesserasahistoricopagamento_Internalname ;
      private string cmbavConfiguracoesserasahistoricopagamento_Jsonclick ;
      private string cmbavConfiguracoesserasaparticipacaosocietaria_Internalname ;
      private string cmbavConfiguracoesserasaparticipacaosocietaria_Jsonclick ;
      private string cmbavConfiguracoesserasarendaestimada_Internalname ;
      private string cmbavConfiguracoesserasarendaestimada_Jsonclick ;
      private string Colorpicker_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavConfiguracoescategoriatitulo_Internalname ;
      private string edtavConfiguracoescategoriatitulo_Jsonclick ;
      private string edtavConfiglayoutcontratocompratitulo_Internalname ;
      private string edtavConfiglayoutcontratocompratitulo_Jsonclick ;
      private string edtavConfiguracoeslayoutproposta_Internalname ;
      private string edtavConfiguracoeslayoutproposta_Jsonclick ;
      private string edtavConfiglayoutpromissoriaclinicaemprestimo_Internalname ;
      private string edtavConfiglayoutpromissoriaclinicaemprestimo_Jsonclick ;
      private string edtavConfiglayoutpromissoriaclinicataxa_Internalname ;
      private string edtavConfiglayoutpromissoriaclinicataxa_Jsonclick ;
      private string edtavConfiglayoutpromissoriapaciente_Internalname ;
      private string edtavConfiglayoutpromissoriapaciente_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string OldWcwcimagem ;
      private string WebComp_Wcwcimagem_Component ;
      private string edtavSelectedcolor_Internalname ;
      private string AV33SelectedColor ;
      private string GXEncryptionTmp ;
      private string sStyleString ;
      private string tblTablemergedtableimage_Internalname ;
      private string divTableimage_Internalname ;
      private string divTablecolorselector_Internalname ;
      private string edtavSelectedcolor_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Combo_configuracoescategoriatitulo_Emptyitem ;
      private bool Combo_configlayoutcontratocompratitulo_Emptyitem ;
      private bool Combo_configuracoeslayoutproposta_Emptyitem ;
      private bool Combo_configlayoutpromissoriaclinicaemprestimo_Emptyitem ;
      private bool Combo_configlayoutpromissoriaclinicataxa_Emptyitem ;
      private bool Combo_configlayoutpromissoriapaciente_Emptyitem ;
      private bool Gxuitabspanel_tabs2_Historymanagement ;
      private bool Dvpanel_tableimagemlogin_Autowidth ;
      private bool Dvpanel_tableimagemlogin_Autoheight ;
      private bool Dvpanel_tableimagemlogin_Collapsible ;
      private bool Dvpanel_tableimagemlogin_Collapsed ;
      private bool Dvpanel_tableimagemlogin_Showcollapseicon ;
      private bool Dvpanel_tableimagemlogin_Autoscroll ;
      private bool Dvpanel_panelimagemheader_Autowidth ;
      private bool Dvpanel_panelimagemheader_Autoheight ;
      private bool Dvpanel_panelimagemheader_Collapsible ;
      private bool Dvpanel_panelimagemheader_Collapsed ;
      private bool Dvpanel_panelimagemheader_Showcollapseicon ;
      private bool Dvpanel_panelimagemheader_Autoscroll ;
      private bool Ucfile_Autoupload ;
      private bool Ucfile_Enableuploadedfilecanceling ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool wbLoad ;
      private bool AV47ConfiguracoesSerasaAnotacoesCompletas ;
      private bool AV48ConfiguracoesSerasaConsultaDetalhada ;
      private bool AV49ConfiguracoesSerasaHistoricoPagamento ;
      private bool AV50ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool AV51ConfiguracoesSerasaRendaEstimada ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcservidorsmtpww ;
      private bool bDynCreated_Wcimagemcabecalho ;
      private bool bDynCreated_Wcwcimagem ;
      private bool n906LayoutContratoTipo ;
      private bool A156LayoutContratoStatus ;
      private bool n156LayoutContratoStatus ;
      private bool n155LayoutContratoDescricao ;
      private bool n427CategoriaTituloNome ;
      private string AV14Source ;
      private string AV10ConfiguracoesImagemLoginExtencao ;
      private string AV13ConfiguracoesImagemLoginNomeInteiro ;
      private string AV22ConfiguracoesImagemHeaderExtencao ;
      private string AV21ConfiguracoesImagemHeaderNome ;
      private string AV23ConfiguracoesImagemHeaderNomeInteiro ;
      private string AV28SourceCabecalho ;
      private string AV11Color ;
      private string AV19DmConfiguracaoImagem ;
      private string AV17JSON ;
      private string AV30TesteEmail ;
      private string AV37ConfiguracaoSenhaPFX ;
      private string AV29ColorCabecalho ;
      private string AV32message ;
      private string A906LayoutContratoTipo ;
      private string A155LayoutContratoDescricao ;
      private string A427CategoriaTituloNome ;
      private string AV26ConfiguracoesImagemLoginNome ;
      private string AV18AuxConfiguracoesImagemLogin ;
      private string AV5ConfiguracoesImagemLogin ;
      private string AV25AuxConfiguracoesImagemHeader ;
      private string AV20ConfiguracoesImagemHeader ;
      private string AV38Blob ;
      private GXWebComponent WebComp_Wcwcimagem ;
      private GXWebComponent WebComp_Wcimagemcabecalho ;
      private GXWebComponent WebComp_Wcservidorsmtpww ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucCombo_configuracoescategoriatitulo ;
      private GXUserControl ucGxuitabspanel_tabs2 ;
      private GXUserControl ucCombo_configlayoutcontratocompratitulo ;
      private GXUserControl ucCombo_configuracoeslayoutproposta ;
      private GXUserControl ucCombo_configlayoutpromissoriaclinicaemprestimo ;
      private GXUserControl ucCombo_configlayoutpromissoriaclinicataxa ;
      private GXUserControl ucCombo_configlayoutpromissoriapaciente ;
      private GXUserControl ucDvpanel_tableimagemlogin ;
      private GXUserControl ucDvpanel_panelimagemheader ;
      private GXUserControl ucUcfile ;
      private GXUserControl ucColorpicker ;
      private GxFile AV15File ;
      private GxFile AV27HeaderFile ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavConfiguracoesserasaanotacoescompletas ;
      private GXCombobox cmbavConfiguracoesserasaconsultadetalhada ;
      private GXCombobox cmbavConfiguracoesserasahistoricopagamento ;
      private GXCombobox cmbavConfiguracoesserasaparticipacaosocietaria ;
      private GXCombobox cmbavConfiguracoesserasarendaestimada ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV46ConfiguracoesCategoriaTitulo_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV53ConfigLayoutContratoCompraTitulo_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV35ConfiguracoesLayoutProposta_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV42ConfigLayoutPromissoriaClinicaEmprestimo_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV43ConfigLayoutPromissoriaClinicaTaxa_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV44ConfigLayoutPromissoriaPaciente_Data ;
      private GXBaseCollection<SdtFileUploadData> AV6UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV7FailedFiles ;
      private GxSimpleCollection<string> AV31Array_Email ;
      private SdtConfiguracoes AV9Configuracoes ;
      private IDataStoreProvider pr_default ;
      private int[] H00542_A299ConfiguracoesId ;
      private string[] H00543_A906LayoutContratoTipo ;
      private bool[] H00543_n906LayoutContratoTipo ;
      private bool[] H00543_A156LayoutContratoStatus ;
      private bool[] H00543_n156LayoutContratoStatus ;
      private short[] H00543_A154LayoutContratoId ;
      private string[] H00543_A155LayoutContratoDescricao ;
      private bool[] H00543_n155LayoutContratoDescricao ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV36Combo_DataItem ;
      private string[] H00544_A906LayoutContratoTipo ;
      private bool[] H00544_n906LayoutContratoTipo ;
      private bool[] H00544_A156LayoutContratoStatus ;
      private bool[] H00544_n156LayoutContratoStatus ;
      private short[] H00544_A154LayoutContratoId ;
      private string[] H00544_A155LayoutContratoDescricao ;
      private bool[] H00544_n155LayoutContratoDescricao ;
      private string[] H00545_A906LayoutContratoTipo ;
      private bool[] H00545_n906LayoutContratoTipo ;
      private bool[] H00545_A156LayoutContratoStatus ;
      private bool[] H00545_n156LayoutContratoStatus ;
      private short[] H00545_A154LayoutContratoId ;
      private string[] H00545_A155LayoutContratoDescricao ;
      private bool[] H00545_n155LayoutContratoDescricao ;
      private string[] H00546_A906LayoutContratoTipo ;
      private bool[] H00546_n906LayoutContratoTipo ;
      private short[] H00546_A154LayoutContratoId ;
      private string[] H00546_A155LayoutContratoDescricao ;
      private bool[] H00546_n155LayoutContratoDescricao ;
      private string[] H00547_A906LayoutContratoTipo ;
      private bool[] H00547_n906LayoutContratoTipo ;
      private bool[] H00547_A156LayoutContratoStatus ;
      private bool[] H00547_n156LayoutContratoStatus ;
      private short[] H00547_A154LayoutContratoId ;
      private string[] H00547_A155LayoutContratoDescricao ;
      private bool[] H00547_n155LayoutContratoDescricao ;
      private int[] H00548_A426CategoriaTituloId ;
      private string[] H00548_A427CategoriaTituloNome ;
      private bool[] H00548_n427CategoriaTituloNome ;
      private SdtFileUploadData AV8FileUploadData ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpconfiguracoes__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00542;
          prmH00542 = new Object[] {
          };
          Object[] prmH00543;
          prmH00543 = new Object[] {
          };
          Object[] prmH00544;
          prmH00544 = new Object[] {
          };
          Object[] prmH00545;
          prmH00545 = new Object[] {
          };
          Object[] prmH00546;
          prmH00546 = new Object[] {
          };
          Object[] prmH00547;
          prmH00547 = new Object[] {
          };
          Object[] prmH00548;
          prmH00548 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00542", "SELECT ConfiguracoesId FROM Configuracoes ORDER BY ConfiguracoesId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00542,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00543", "SELECT LayoutContratoTipo, LayoutContratoStatus, LayoutContratoId, LayoutContratoDescricao FROM LayoutContrato WHERE (LayoutContratoStatus) AND (LayoutContratoTipo = ( 'C')) ORDER BY LayoutContratoDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00543,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00544", "SELECT LayoutContratoTipo, LayoutContratoStatus, LayoutContratoId, LayoutContratoDescricao FROM LayoutContrato WHERE (LayoutContratoStatus) AND (LayoutContratoTipo = ( 'C')) ORDER BY LayoutContratoDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00544,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00545", "SELECT LayoutContratoTipo, LayoutContratoStatus, LayoutContratoId, LayoutContratoDescricao FROM LayoutContrato WHERE (LayoutContratoStatus) AND (LayoutContratoTipo = ( 'C')) ORDER BY LayoutContratoDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00545,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00546", "SELECT LayoutContratoTipo, LayoutContratoId, LayoutContratoDescricao FROM LayoutContrato WHERE LayoutContratoTipo = ( 'C') or (char_length(trim(trailing ' ' from LayoutContratoTipo))=0) ORDER BY LayoutContratoDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00546,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00547", "SELECT LayoutContratoTipo, LayoutContratoStatus, LayoutContratoId, LayoutContratoDescricao FROM LayoutContrato WHERE (LayoutContratoStatus) AND (LayoutContratoTipo = ( 'C')) ORDER BY LayoutContratoDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00547,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00548", "SELECT CategoriaTituloId, CategoriaTituloNome FROM CategoriaTitulo ORDER BY CategoriaTituloNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00548,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
