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
   public class wcimportarnotafiscal : GXWebComponent
   {
      public wcimportarnotafiscal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wcimportarnotafiscal( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Produtosnotafiscal") == 0 )
               {
                  gxnrProdutosnotafiscal_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Produtosnotafiscal") == 0 )
               {
                  gxgrProdutosnotafiscal_refresh_invoke( ) ;
                  return  ;
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrProdutosnotafiscal_newrow_invoke( )
      {
         nRC_GXsfl_40 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_40"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_40_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_40_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_40_idx = GetPar( "sGXsfl_40_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrProdutosnotafiscal_newrow( ) ;
         /* End function gxnrProdutosnotafiscal_newrow_invoke */
      }

      protected void gxgrProdutosnotafiscal_refresh_invoke( )
      {
         ajax_req_read_hidden_sdt(GetNextPar( ), AV15Array_SdProdutoNotaFiscal);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrProdutosnotafiscal_refresh( AV15Array_SdProdutoNotaFiscal, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrProdutosnotafiscal_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA8O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS8O2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Importa nota fiscal") ;
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
         }
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
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVTabsTransform/DVTabsTransformRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcimportarnotafiscal") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_40", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_40), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV8UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV8UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFAILEDFILES", AV9FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFAILEDFILES", AV9FailedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDPRODUTONOTAFISCAL", AV15Array_SdProdutoNotaFiscal);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDPRODUTONOTAFISCAL", AV15Array_SdProdutoNotaFiscal);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV5CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDNOTAFISCAL", AV14Array_SdNotaFiscal);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDNOTAFISCAL", AV14Array_SdNotaFiscal);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTABSACTIVEPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TabsActivePage), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subProdutosnotafiscal_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subProdutosnotafiscal_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"XMLSNOTAFISCAL_Autoupload", StringUtil.BoolToStr( Xmlsnotafiscal_Autoupload));
         GxWebStd.gx_hidden_field( context, sPrefix+"XMLSNOTAFISCAL_Hideadditionalbuttons", StringUtil.BoolToStr( Xmlsnotafiscal_Hideadditionalbuttons));
         GxWebStd.gx_hidden_field( context, sPrefix+"XMLSNOTAFISCAL_Enableuploadedfilecanceling", StringUtil.BoolToStr( Xmlsnotafiscal_Enableuploadedfilecanceling));
         GxWebStd.gx_hidden_field( context, sPrefix+"XMLSNOTAFISCAL_Disableimageresize", StringUtil.BoolToStr( Xmlsnotafiscal_Disableimageresize));
         GxWebStd.gx_hidden_field( context, sPrefix+"XMLSNOTAFISCAL_Maxnumberoffiles", StringUtil.LTrim( StringUtil.NToC( (decimal)(Xmlsnotafiscal_Maxnumberoffiles), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"XMLSNOTAFISCAL_Autodisableaddingfiles", StringUtil.BoolToStr( Xmlsnotafiscal_Autodisableaddingfiles));
         GxWebStd.gx_hidden_field( context, sPrefix+"XMLSNOTAFISCAL_Acceptedfiletypes", StringUtil.RTrim( Xmlsnotafiscal_Acceptedfiletypes));
         GxWebStd.gx_hidden_field( context, sPrefix+"XMLSNOTAFISCAL_Customfiletypes", StringUtil.RTrim( Xmlsnotafiscal_Customfiletypes));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_STEPS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_steps_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_STEPS_Class", StringUtil.RTrim( Gxuitabspanel_steps_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_STEPS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_steps_Historymanagement));
         GxWebStd.gx_hidden_field( context, sPrefix+"WIZARD_STEPS_Tabsinternalname", StringUtil.RTrim( Wizard_steps_Tabsinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"WIZARD_STEPS_Transformtype", StringUtil.RTrim( Wizard_steps_Transformtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"WIZARD_STEPS_Wizardarrowselectedunselectedimage", StringUtil.RTrim( Wizard_steps_Wizardarrowselectedunselectedimage));
         GxWebStd.gx_hidden_field( context, sPrefix+"WIZARD_STEPS_Wizardarrowunselectedselectedimage", StringUtil.RTrim( Wizard_steps_Wizardarrowunselectedselectedimage));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUTOSNOTAFISCAL_Class", StringUtil.RTrim( subProdutosnotafiscal_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUTOSNOTAFISCAL_Flexdirection", StringUtil.RTrim( subProdutosnotafiscal_Flexdirection));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_STEPS_Activepage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_steps_Activepage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_STEPS_Activepage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_steps_Activepage), 9, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm8O2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            if ( ! ( WebComp_Wcwclinhaprodutonota == null ) )
            {
               WebComp_Wcwclinhaprodutonota.componentjscripts();
            }
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WcImportarNotaFiscal" ;
      }

      public override string GetPgmdesc( )
      {
         return "Importa nota fiscal" ;
      }

      protected void WB8O0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcimportarnotafiscal");
               context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
               context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
               context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVTabsTransform/DVTabsTransformRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainFixedActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableWizardMainWithShadow", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_steps.SetProperty("PageCount", Gxuitabspanel_steps_Pagecount);
            ucGxuitabspanel_steps.SetProperty("Class", Gxuitabspanel_steps_Class);
            ucGxuitabspanel_steps.SetProperty("HistoryManagement", Gxuitabspanel_steps_Historymanagement);
            ucGxuitabspanel_steps.Render(context, "tab", Gxuitabspanel_steps_Internalname, sPrefix+"GXUITABSPANEL_STEPSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_STEPSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabimportnota_title_Internalname, "Importar nota(s)", "", "", lblTabimportnota_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WcImportarNotaFiscal.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabImportNota") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_STEPSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotasflex_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap;justify-content:center;align-items:center;align-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabeluploaddataxml_Internalname, "<h3>Upload de Notas Fiscais</h3>", "", "", lblLabeluploaddataxml_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImportarNotaFiscal.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabeldescriptionuploaddata_Internalname, "<h4>Faça o upload dos arquivos XML das notas fiscais para iniciar o processo de venda de títulos.</h4>", "", "", lblLabeldescriptionuploaddata_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImportarNotaFiscal.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableimportxml_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucXmlsnotafiscal.SetProperty("AutoUpload", Xmlsnotafiscal_Autoupload);
            ucXmlsnotafiscal.SetProperty("HideAdditionalButtons", Xmlsnotafiscal_Hideadditionalbuttons);
            ucXmlsnotafiscal.SetProperty("TooltipText", Xmlsnotafiscal_Tooltiptext);
            ucXmlsnotafiscal.SetProperty("EnableUploadedFileCanceling", Xmlsnotafiscal_Enableuploadedfilecanceling);
            ucXmlsnotafiscal.SetProperty("DisableImageResize", Xmlsnotafiscal_Disableimageresize);
            ucXmlsnotafiscal.SetProperty("MaxNumberOfFiles", Xmlsnotafiscal_Maxnumberoffiles);
            ucXmlsnotafiscal.SetProperty("AutoDisableAddingFiles", Xmlsnotafiscal_Autodisableaddingfiles);
            ucXmlsnotafiscal.SetProperty("AcceptedFileTypes", Xmlsnotafiscal_Acceptedfiletypes);
            ucXmlsnotafiscal.SetProperty("CustomFileTypes", Xmlsnotafiscal_Customfiletypes);
            ucXmlsnotafiscal.SetProperty("UploadedFiles", AV8UploadedFiles);
            ucXmlsnotafiscal.SetProperty("FailedFiles", AV9FailedFiles);
            ucXmlsnotafiscal.Render(context, "fileupload", Xmlsnotafiscal_Internalname, sPrefix+"XMLSNOTAFISCALContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_STEPSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabitens_title_Internalname, "Itens", "", "", lblTabitens_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WcImportarNotaFiscal.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabItens") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_STEPSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            ProdutosnotafiscalContainer.SetIsFreestyle(true);
            ProdutosnotafiscalContainer.SetWrapped(nGXWrapped);
            StartGridControl40( ) ;
         }
         if ( wbEnd == 40 )
         {
            wbEnd = 0;
            nRC_GXsfl_40 = (int)(nGXsfl_40_idx-1);
            if ( ProdutosnotafiscalContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"ProdutosnotafiscalContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Produtosnotafiscal", ProdutosnotafiscalContainer, subProdutosnotafiscal_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"ProdutosnotafiscalContainerData", ProdutosnotafiscalContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"ProdutosnotafiscalContainerData"+"V", ProdutosnotafiscalContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"ProdutosnotafiscalContainerData"+"V"+"\" value='"+ProdutosnotafiscalContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault ButtonWizard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardprevious_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Anterior", bttBtnwizardprevious_Jsonclick, 7, "Anterior", "", StyleString, ClassString, bttBtnwizardprevious_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e118o1_client"+"'", TempTags, "", 2, "HLP_WcImportarNotaFiscal.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtncancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WcImportarNotaFiscal.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button ButtonWizard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardnext_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Próximo", bttBtnwizardnext_Jsonclick, 5, "Próximo", "", StyleString, ClassString, bttBtnwizardnext_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'WIZARDNEXT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WcImportarNotaFiscal.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WcImportarNotaFiscal.htm");
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
            /* User Defined Control */
            ucWizard_steps.SetProperty("TransformType", Wizard_steps_Transformtype);
            ucWizard_steps.Render(context, "dvelop.dvtabstransform", Wizard_steps_Internalname, sPrefix+"WIZARD_STEPSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 40 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( ProdutosnotafiscalContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"ProdutosnotafiscalContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Produtosnotafiscal", ProdutosnotafiscalContainer, subProdutosnotafiscal_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"ProdutosnotafiscalContainerData", ProdutosnotafiscalContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"ProdutosnotafiscalContainerData"+"V", ProdutosnotafiscalContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"ProdutosnotafiscalContainerData"+"V"+"\" value='"+ProdutosnotafiscalContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START8O2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
               }
            }
            Form.Meta.addItem("description", "Importa nota fiscal", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP8O0( ) ;
            }
         }
      }

      protected void WS8O2( )
      {
         START8O2( ) ;
         EVT8O2( ) ;
      }

      protected void EVT8O2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDNEXT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardNext' */
                                    E128O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "PRODUTOSNOTAFISCAL.LOAD") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8O0( ) ;
                              }
                              nGXsfl_40_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
                              SubsflControlProps_402( ) ;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E138O2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "PRODUTOSNOTAFISCAL.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Produtosnotafiscal.Load */
                                          E148O2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP8O0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 44 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0044" + sEvtType;
                           OldWcwclinhaprodutonota = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldWcwclinhaprodutonota) == 0 ) || ( StringUtil.StrCmp(OldWcwclinhaprodutonota, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldWcwclinhaprodutonota, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldWcwclinhaprodutonota";
                              WebComp_GX_Process_Component = OldWcwclinhaprodutonota;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0044", sEvtType, sEvt);
                           }
                           nGXsfl_40_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Wcwclinhaprodutonota";
                           WebComp_GX_Process_Component = OldWcwclinhaprodutonota;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE8O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm8O2( ) ;
            }
         }
      }

      protected void PA8O2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrProdutosnotafiscal_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_402( ) ;
         while ( nGXsfl_40_idx <= nRC_GXsfl_40 )
         {
            sendrow_402( ) ;
            nGXsfl_40_idx = ((subProdutosnotafiscal_Islastpage==1)&&(nGXsfl_40_idx+1>subProdutosnotafiscal_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( ProdutosnotafiscalContainer)) ;
         /* End function gxnrProdutosnotafiscal_newrow */
      }

      protected void gxgrProdutosnotafiscal_refresh( GXBaseCollection<SdtSdProdutoNotaFiscal> AV15Array_SdProdutoNotaFiscal ,
                                                     string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         PRODUTOSNOTAFISCAL_nCurrentRecord = 0;
         RF8O2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrProdutosnotafiscal_refresh */
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
         RF8O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF8O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            ProdutosnotafiscalContainer.ClearRows();
         }
         wbStart = 40;
         nGXsfl_40_idx = 1;
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         bGXsfl_40_Refreshing = true;
         ProdutosnotafiscalContainer.AddObjectProperty("GridName", "Produtosnotafiscal");
         ProdutosnotafiscalContainer.AddObjectProperty("CmpContext", sPrefix);
         ProdutosnotafiscalContainer.AddObjectProperty("InMasterPage", "false");
         ProdutosnotafiscalContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         ProdutosnotafiscalContainer.AddObjectProperty("Class", "FreeStyleGrid");
         ProdutosnotafiscalContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         ProdutosnotafiscalContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         ProdutosnotafiscalContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subProdutosnotafiscal_Backcolorstyle), 1, 0, ".", "")));
         ProdutosnotafiscalContainer.PageSize = subProdutosnotafiscal_fnc_Recordsperpage( );
         if ( subProdutosnotafiscal_Islastpage != 0 )
         {
            PRODUTOSNOTAFISCAL_nFirstRecordOnPage = (long)(subProdutosnotafiscal_fnc_Recordcount( )-subProdutosnotafiscal_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"PRODUTOSNOTAFISCAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(PRODUTOSNOTAFISCAL_nFirstRecordOnPage), 15, 0, ".", "")));
            ProdutosnotafiscalContainer.AddObjectProperty("PRODUTOSNOTAFISCAL_nFirstRecordOnPage", PRODUTOSNOTAFISCAL_nFirstRecordOnPage);
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwclinhaprodutonota_Component) != 0 )
               {
                  WebComp_Wcwclinhaprodutonota.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_402( ) ;
            /* Execute user event: Produtosnotafiscal.Load */
            E148O2 ();
            wbEnd = 40;
            WB8O0( ) ;
         }
         bGXsfl_40_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8O2( )
      {
      }

      protected int subProdutosnotafiscal_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subProdutosnotafiscal_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subProdutosnotafiscal_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subProdutosnotafiscal_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E138O2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV8UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFAILEDFILES"), AV9FailedFiles);
            /* Read saved values. */
            nRC_GXsfl_40 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_40"), ",", "."), 18, MidpointRounding.ToEven));
            AV7TabsActivePage = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vTABSACTIVEPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            subProdutosnotafiscal_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subProdutosnotafiscal_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            Xmlsnotafiscal_Autoupload = StringUtil.StrToBool( cgiGet( sPrefix+"XMLSNOTAFISCAL_Autoupload"));
            Xmlsnotafiscal_Hideadditionalbuttons = StringUtil.StrToBool( cgiGet( sPrefix+"XMLSNOTAFISCAL_Hideadditionalbuttons"));
            Xmlsnotafiscal_Enableuploadedfilecanceling = StringUtil.StrToBool( cgiGet( sPrefix+"XMLSNOTAFISCAL_Enableuploadedfilecanceling"));
            Xmlsnotafiscal_Disableimageresize = StringUtil.StrToBool( cgiGet( sPrefix+"XMLSNOTAFISCAL_Disableimageresize"));
            Xmlsnotafiscal_Maxnumberoffiles = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"XMLSNOTAFISCAL_Maxnumberoffiles"), ",", "."), 18, MidpointRounding.ToEven));
            Xmlsnotafiscal_Autodisableaddingfiles = StringUtil.StrToBool( cgiGet( sPrefix+"XMLSNOTAFISCAL_Autodisableaddingfiles"));
            Xmlsnotafiscal_Acceptedfiletypes = cgiGet( sPrefix+"XMLSNOTAFISCAL_Acceptedfiletypes");
            Xmlsnotafiscal_Customfiletypes = cgiGet( sPrefix+"XMLSNOTAFISCAL_Customfiletypes");
            Gxuitabspanel_steps_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GXUITABSPANEL_STEPS_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_steps_Class = cgiGet( sPrefix+"GXUITABSPANEL_STEPS_Class");
            Gxuitabspanel_steps_Historymanagement = StringUtil.StrToBool( cgiGet( sPrefix+"GXUITABSPANEL_STEPS_Historymanagement"));
            Wizard_steps_Tabsinternalname = cgiGet( sPrefix+"WIZARD_STEPS_Tabsinternalname");
            Wizard_steps_Transformtype = cgiGet( sPrefix+"WIZARD_STEPS_Transformtype");
            Wizard_steps_Wizardarrowselectedunselectedimage = cgiGet( sPrefix+"WIZARD_STEPS_Wizardarrowselectedunselectedimage");
            Wizard_steps_Wizardarrowunselectedselectedimage = cgiGet( sPrefix+"WIZARD_STEPS_Wizardarrowunselectedselectedimage");
            subProdutosnotafiscal_Class = cgiGet( sPrefix+"PRODUTOSNOTAFISCAL_Class");
            subProdutosnotafiscal_Flexdirection = cgiGet( sPrefix+"PRODUTOSNOTAFISCAL_Flexdirection");
            Gxuitabspanel_steps_Activepage = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GXUITABSPANEL_STEPS_Activepage"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
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
         E138O2 ();
         if (returnInSub) return;
      }

      protected void E138O2( )
      {
         /* Start Routine */
         returnInSub = false;
         Wizard_steps_Tabsinternalname = "GXUITabsPanel_Steps";
         ucWizard_steps.SendProperty(context, sPrefix, false, Wizard_steps_Internalname, "TabsInternalName", Wizard_steps_Tabsinternalname);
         Wizard_steps_Wizardarrowselectedunselectedimage = context.convertURL( (string)(context.GetImagePath( "2fe377a7-df7d-42aa-84d4-4f1b853d50aa", "", context.GetTheme( ))));
         ucWizard_steps.SendProperty(context, sPrefix, false, Wizard_steps_Internalname, "WizardArrowSelectedUnSelectedImage", Wizard_steps_Wizardarrowselectedunselectedimage);
         Wizard_steps_Wizardarrowunselectedselectedimage = context.convertURL( (string)(context.GetImagePath( "8f7f2ead-3d17-4e23-a450-7d98b62b7f40", "", context.GetTheme( ))));
         ucWizard_steps.SendProperty(context, sPrefix, false, Wizard_steps_Internalname, "WizardArrowUnSelectedSelectedImage", Wizard_steps_Wizardarrowunselectedselectedimage);
         bttBtnenter_Visible = 0;
         AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         bttBtnwizardprevious_Visible = 0;
         AssignProp(sPrefix, false, bttBtnwizardprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardprevious_Visible), 5, 0), true);
      }

      private void E148O2( )
      {
         /* Produtosnotafiscal_Load Routine */
         returnInSub = false;
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV15Array_SdProdutoNotaFiscal.Count )
         {
            AV17SdProdutoNotaFiscal = ((SdtSdProdutoNotaFiscal)AV15Array_SdProdutoNotaFiscal.Item(AV19GXV1));
            AV18JSON = AV17SdProdutoNotaFiscal.ToJSonString(false, true);
            /* Object Property */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               bDynCreated_Wcwclinhaprodutonota = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwclinhaprodutonota_Component), StringUtil.Lower( "WcLinhaProdutoNota")) != 0 )
            {
               WebComp_Wcwclinhaprodutonota = getWebComponent(GetType(), "GeneXus.Programs", "wclinhaprodutonota", new Object[] {context} );
               WebComp_Wcwclinhaprodutonota.ComponentInit();
               WebComp_Wcwclinhaprodutonota.Name = "WcLinhaProdutoNota";
               WebComp_Wcwclinhaprodutonota_Component = "WcLinhaProdutoNota";
            }
            if ( StringUtil.Len( WebComp_Wcwclinhaprodutonota_Component) != 0 )
            {
               WebComp_Wcwclinhaprodutonota.setjustcreated();
               WebComp_Wcwclinhaprodutonota.componentprepare(new Object[] {(string)sPrefix+"W0044",(string)sGXsfl_40_idx,(string)AV18JSON});
               WebComp_Wcwclinhaprodutonota.componentbind(new Object[] {(string)""});
            }
            if ( ! bGXsfl_40_Refreshing )
            {
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwclinhaprodutonota )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0044"+sGXsfl_40_idx);
                  WebComp_Wcwclinhaprodutonota.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            AV19GXV1 = (int)(AV19GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E128O2( )
      {
         /* 'WizardNext' Routine */
         returnInSub = false;
         AV7TabsActivePage = (short)(Gxuitabspanel_steps_Activepage);
         if ( AV7TabsActivePage == 1 )
         {
            /* Execute user subroutine: 'LERXMLS' */
            S112 ();
            if (returnInSub) return;
         }
         AV7TabsActivePage = (short)(Gxuitabspanel_steps_Activepage);
         if ( AV7TabsActivePage == 1 )
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS_TABIMPORTNOTA' */
            S122 ();
            if (returnInSub) return;
         }
         if ( AV5CheckRequiredFieldsResult )
         {
            AV7TabsActivePage = (short)(AV7TabsActivePage+1);
            this.executeUsercontrolMethod(sPrefix, false, "GXUITABSPANEL_STEPSContainer", "SelectTab", "", new Object[] {(short)AV7TabsActivePage});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV14Array_SdNotaFiscal", AV14Array_SdNotaFiscal);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV15Array_SdProdutoNotaFiscal", AV15Array_SdProdutoNotaFiscal);
      }

      protected void S132( )
      {
         /* 'UPDATE WIZARD STEPS BUTTONS VISIBILITY' Routine */
         returnInSub = false;
         bttBtnwizardprevious_Visible = (((Gxuitabspanel_steps_Activepage!=1)) ? 1 : 0);
         AssignProp(sPrefix, false, bttBtnwizardprevious_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardprevious_Visible), 5, 0), true);
         bttBtncancel_Visible = (((Gxuitabspanel_steps_Activepage==1)) ? 1 : 0);
         AssignProp(sPrefix, false, bttBtncancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncancel_Visible), 5, 0), true);
         bttBtnwizardnext_Visible = (((Gxuitabspanel_steps_Activepage!=2)) ? 1 : 0);
         AssignProp(sPrefix, false, bttBtnwizardnext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnwizardnext_Visible), 5, 0), true);
         bttBtnenter_Visible = (((Gxuitabspanel_steps_Activepage==2)) ? 1 : 0);
         AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS_TABIMPORTNOTA' Routine */
         returnInSub = false;
         AV5CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         if ( AV14Array_SdNotaFiscal.Count == 0 )
         {
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
            GXt_char1 = "Não é possivel prosseguir sem nenhum XML";
            new message(context ).gxep_erro( ref  GXt_char1) ;
         }
      }

      protected void S112( )
      {
         /* 'LERXMLS' Routine */
         returnInSub = false;
         AV14Array_SdNotaFiscal = new GXBaseCollection<SdtSdNotaFiscal>( context, "SdNotaFiscal", "Factory21");
         AV20GXV2 = 1;
         while ( AV20GXV2 <= AV8UploadedFiles.Count )
         {
            AV10FileUploadData = ((SdtFileUploadData)AV8UploadedFiles.Item(AV20GXV2));
            AV11File = new GxFile(context.GetPhysicalPath());
            AV11File.Source = "publictempstorage/teste.xml";
            AV11File.Create();
            AV11File.FromBase64(context.FileToBase64( AV10FileUploadData.gxTpr_File));
            AV12StringNota = AV11File.ReadAllText("");
            new prlerxml(context ).execute(  AV12StringNota, out  AV13SdNotaFiscal) ;
            AV14Array_SdNotaFiscal.Add(AV13SdNotaFiscal, 0);
            AV20GXV2 = (int)(AV20GXV2+1);
         }
         AV15Array_SdProdutoNotaFiscal = new GXBaseCollection<SdtSdProdutoNotaFiscal>( context, "SdProdutoNotaFiscal", "Factory21");
         AV21GXV3 = 1;
         while ( AV21GXV3 <= AV14Array_SdNotaFiscal.Count )
         {
            AV13SdNotaFiscal = ((SdtSdNotaFiscal)AV14Array_SdNotaFiscal.Item(AV21GXV3));
            AV22GXV4 = 1;
            while ( AV22GXV4 <= AV13SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Det.Count )
            {
               AV16SdNotaFiscalDet = ((SdtSdNotaFiscal_NFe_infNFe_detItem)AV13SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Det.Item(AV22GXV4));
               AV17SdProdutoNotaFiscal = new SdtSdProdutoNotaFiscal(context);
               AV17SdProdutoNotaFiscal.FromJSonString(AV16SdNotaFiscalDet.gxTpr_Prod.ToJSonString(false, true), null);
               AV17SdProdutoNotaFiscal.gxTpr_Cnfe = AV13SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Cnf;
               AV15Array_SdProdutoNotaFiscal.Add(AV17SdProdutoNotaFiscal, 0);
               AV22GXV4 = (int)(AV22GXV4+1);
            }
            AV21GXV3 = (int)(AV21GXV3+1);
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
         PA8O2( ) ;
         WS8O2( ) ;
         WE8O2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SESSION ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA8O2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcimportarnotafiscal", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA8O2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA8O2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS8O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS8O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE8O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
         if ( ! ( WebComp_GX_Process == null ) )
         {
            WebComp_GX_Process.componentjscripts();
         }
         if ( ! ( WebComp_Wcwclinhaprodutonota == null ) )
         {
            WebComp_Wcwclinhaprodutonota.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwclinhaprodutonota == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwclinhaprodutonota_Component) != 0 )
            {
               WebComp_Wcwclinhaprodutonota.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101963420", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("wcimportarnotafiscal.js", "?20256101963421", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVTabsTransform/DVTabsTransformRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_402( )
      {
      }

      protected void SubsflControlProps_fel_402( )
      {
      }

      protected void sendrow_402( )
      {
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         WB8O0( ) ;
         ProdutosnotafiscalRow = GXWebRow.GetNew(context,ProdutosnotafiscalContainer);
         if ( subProdutosnotafiscal_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subProdutosnotafiscal_Backstyle = 0;
            if ( StringUtil.StrCmp(subProdutosnotafiscal_Class, "") != 0 )
            {
               subProdutosnotafiscal_Linesclass = subProdutosnotafiscal_Class+"Odd";
            }
         }
         else if ( subProdutosnotafiscal_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subProdutosnotafiscal_Backstyle = 0;
            subProdutosnotafiscal_Backcolor = subProdutosnotafiscal_Allbackcolor;
            if ( StringUtil.StrCmp(subProdutosnotafiscal_Class, "") != 0 )
            {
               subProdutosnotafiscal_Linesclass = subProdutosnotafiscal_Class+"Uniform";
            }
         }
         else if ( subProdutosnotafiscal_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subProdutosnotafiscal_Backstyle = 1;
            if ( StringUtil.StrCmp(subProdutosnotafiscal_Class, "") != 0 )
            {
               subProdutosnotafiscal_Linesclass = subProdutosnotafiscal_Class+"Odd";
            }
            subProdutosnotafiscal_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subProdutosnotafiscal_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subProdutosnotafiscal_Backstyle = 1;
            subProdutosnotafiscal_Backcolor = (int)(0xFFFFFF);
            if ( StringUtil.StrCmp(subProdutosnotafiscal_Class, "") != 0 )
            {
               subProdutosnotafiscal_Linesclass = subProdutosnotafiscal_Class+"Odd";
            }
         }
         /* Start of Columns property logic. */
         /* Div Control */
         ProdutosnotafiscalRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divProdutosnotafiscallayouttable_Internalname+"_"+sGXsfl_40_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         ProdutosnotafiscalRow.AddRenderProperties(ProdutosnotafiscalColumn);
         /* Div Control */
         ProdutosnotafiscalRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         ProdutosnotafiscalRow.AddRenderProperties(ProdutosnotafiscalColumn);
         /* Div Control */
         ProdutosnotafiscalRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         ProdutosnotafiscalRow.AddRenderProperties(ProdutosnotafiscalColumn);
         /* WebComponent */
         GxWebStd.gx_hidden_field( context, sPrefix+"W0044"+sGXsfl_40_idx, StringUtil.RTrim( WebComp_Wcwclinhaprodutonota_Component));
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
         context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0044"+sGXsfl_40_idx+"\""+"") ;
         context.WriteHtmlText( ">") ;
         if ( bGXsfl_40_Refreshing )
         {
            if ( StringUtil.Len( WebComp_Wcwclinhaprodutonota_Component) != 0 )
            {
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0044"+sGXsfl_40_idx, cgiGet( "_EventName"), 1) != 0 ) )
               {
                  if ( 1 != 0 )
                  {
                     if ( StringUtil.Len( WebComp_Wcwclinhaprodutonota_Component) != 0 )
                     {
                        WebComp_Wcwclinhaprodutonota.componentstart();
                     }
                  }
               }
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcwclinhaprodutonota), StringUtil.Lower( WebComp_Wcwclinhaprodutonota_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0044"+sGXsfl_40_idx);
               }
               WebComp_Wcwclinhaprodutonota.componentdraw();
               if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcwclinhaprodutonota), StringUtil.Lower( WebComp_Wcwclinhaprodutonota_Component)) != 0 ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         context.WriteHtmlText( "</div>") ;
         WebComp_Wcwclinhaprodutonota_Component = "";
         WebComp_Wcwclinhaprodutonota.componentjscripts();
         ProdutosnotafiscalRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Wcwclinhaprodutonota"});
         ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         ProdutosnotafiscalRow.AddRenderProperties(ProdutosnotafiscalColumn);
         ProdutosnotafiscalRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         ProdutosnotafiscalRow.AddRenderProperties(ProdutosnotafiscalColumn);
         ProdutosnotafiscalRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         ProdutosnotafiscalRow.AddRenderProperties(ProdutosnotafiscalColumn);
         ProdutosnotafiscalRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         ProdutosnotafiscalRow.AddRenderProperties(ProdutosnotafiscalColumn);
         send_integrity_lvl_hashes8O2( ) ;
         /* End of Columns property logic. */
         ProdutosnotafiscalContainer.AddRow(ProdutosnotafiscalRow);
         nGXsfl_40_idx = ((subProdutosnotafiscal_Islastpage==1)&&(nGXsfl_40_idx+1>subProdutosnotafiscal_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         /* End function sendrow_402 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl40( )
      {
         if ( ProdutosnotafiscalContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"ProdutosnotafiscalContainer"+"DivS\" data-gxgridid=\"40\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subProdutosnotafiscal_Internalname, subProdutosnotafiscal_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            ProdutosnotafiscalContainer.AddObjectProperty("GridName", "Produtosnotafiscal");
         }
         else
         {
            ProdutosnotafiscalContainer.AddObjectProperty("GridName", "Produtosnotafiscal");
            ProdutosnotafiscalContainer.AddObjectProperty("Header", subProdutosnotafiscal_Header);
            ProdutosnotafiscalContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            ProdutosnotafiscalContainer.AddObjectProperty("Class", "FreeStyleGrid");
            ProdutosnotafiscalContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            ProdutosnotafiscalContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            ProdutosnotafiscalContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subProdutosnotafiscal_Backcolorstyle), 1, 0, ".", "")));
            ProdutosnotafiscalContainer.AddObjectProperty("CmpContext", sPrefix);
            ProdutosnotafiscalContainer.AddObjectProperty("InMasterPage", "false");
            ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            ProdutosnotafiscalContainer.AddColumnProperties(ProdutosnotafiscalColumn);
            ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            ProdutosnotafiscalContainer.AddColumnProperties(ProdutosnotafiscalColumn);
            ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            ProdutosnotafiscalContainer.AddColumnProperties(ProdutosnotafiscalColumn);
            ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            ProdutosnotafiscalContainer.AddColumnProperties(ProdutosnotafiscalColumn);
            ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            ProdutosnotafiscalContainer.AddColumnProperties(ProdutosnotafiscalColumn);
            ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            ProdutosnotafiscalContainer.AddColumnProperties(ProdutosnotafiscalColumn);
            ProdutosnotafiscalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            ProdutosnotafiscalContainer.AddColumnProperties(ProdutosnotafiscalColumn);
            ProdutosnotafiscalContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subProdutosnotafiscal_Selectedindex), 4, 0, ".", "")));
            ProdutosnotafiscalContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subProdutosnotafiscal_Allowselection), 1, 0, ".", "")));
            ProdutosnotafiscalContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subProdutosnotafiscal_Selectioncolor), 9, 0, ".", "")));
            ProdutosnotafiscalContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subProdutosnotafiscal_Allowhovering), 1, 0, ".", "")));
            ProdutosnotafiscalContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subProdutosnotafiscal_Hoveringcolor), 9, 0, ".", "")));
            ProdutosnotafiscalContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subProdutosnotafiscal_Allowcollapsing), 1, 0, ".", "")));
            ProdutosnotafiscalContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subProdutosnotafiscal_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTabimportnota_title_Internalname = sPrefix+"TABIMPORTNOTA_TITLE";
         lblLabeluploaddataxml_Internalname = sPrefix+"LABELUPLOADDATAXML";
         lblLabeldescriptionuploaddata_Internalname = sPrefix+"LABELDESCRIPTIONUPLOADDATA";
         Xmlsnotafiscal_Internalname = sPrefix+"XMLSNOTAFISCAL";
         divTableimportxml_Internalname = sPrefix+"TABLEIMPORTXML";
         divTablenotasflex_Internalname = sPrefix+"TABLENOTASFLEX";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         lblTabitens_title_Internalname = sPrefix+"TABITENS_TITLE";
         divProdutosnotafiscallayouttable_Internalname = sPrefix+"PRODUTOSNOTAFISCALLAYOUTTABLE";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Gxuitabspanel_steps_Internalname = sPrefix+"GXUITABSPANEL_STEPS";
         bttBtnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         bttBtnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Wizard_steps_Internalname = sPrefix+"WIZARD_STEPS";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subProdutosnotafiscal_Internalname = sPrefix+"PRODUTOSNOTAFISCAL";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subProdutosnotafiscal_Allowcollapsing = 0;
         subProdutosnotafiscal_Backcolorstyle = 0;
         bttBtnenter_Visible = 1;
         bttBtnwizardnext_Visible = 1;
         bttBtncancel_Visible = 1;
         bttBtnwizardprevious_Visible = 1;
         Xmlsnotafiscal_Tooltiptext = "";
         subProdutosnotafiscal_Flexdirection = "column";
         subProdutosnotafiscal_Class = "FreeStyleGrid";
         Wizard_steps_Wizardarrowunselectedselectedimage = "";
         Wizard_steps_Wizardarrowselectedunselectedimage = "";
         Wizard_steps_Transformtype = "WizardArrow";
         Wizard_steps_Tabsinternalname = "";
         Gxuitabspanel_steps_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_steps_Class = "Tab";
         Gxuitabspanel_steps_Pagecount = 2;
         Xmlsnotafiscal_Customfiletypes = "xml";
         Xmlsnotafiscal_Acceptedfiletypes = "custom";
         Xmlsnotafiscal_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Xmlsnotafiscal_Maxnumberoffiles = 0;
         Xmlsnotafiscal_Disableimageresize = Convert.ToBoolean( 0);
         Xmlsnotafiscal_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Xmlsnotafiscal_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Xmlsnotafiscal_Autoupload = Convert.ToBoolean( -1);
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"PRODUTOSNOTAFISCAL_nFirstRecordOnPage","type":"int"},{"av":"PRODUTOSNOTAFISCAL_nEOF","type":"int"},{"av":"AV15Array_SdProdutoNotaFiscal","fld":"vARRAY_SDPRODUTONOTAFISCAL","type":""},{"av":"sPrefix","type":"char"}]}""");
         setEventMetadata("PRODUTOSNOTAFISCAL.LOAD","""{"handler":"E148O2","iparms":[{"av":"AV15Array_SdProdutoNotaFiscal","fld":"vARRAY_SDPRODUTONOTAFISCAL","type":""}]""");
         setEventMetadata("PRODUTOSNOTAFISCAL.LOAD",""","oparms":[{"ctrl":"WCWCLINHAPRODUTONOTA"}]}""");
         setEventMetadata("'WIZARDNEXT'","""{"handler":"E128O2","iparms":[{"av":"Gxuitabspanel_steps_Activepage","ctrl":"GXUITABSPANEL_STEPS","prop":"ActivePage"},{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV8UploadedFiles","fld":"vUPLOADEDFILES","type":""},{"av":"AV14Array_SdNotaFiscal","fld":"vARRAY_SDNOTAFISCAL","type":""}]""");
         setEventMetadata("'WIZARDNEXT'",""","oparms":[{"av":"AV14Array_SdNotaFiscal","fld":"vARRAY_SDNOTAFISCAL","type":""},{"av":"AV15Array_SdProdutoNotaFiscal","fld":"vARRAY_SDPRODUTONOTAFISCAL","type":""},{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E118O1","iparms":[{"av":"Gxuitabspanel_steps_Activepage","ctrl":"GXUITABSPANEL_STEPS","prop":"ActivePage"}]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15Array_SdProdutoNotaFiscal = new GXBaseCollection<SdtSdProdutoNotaFiscal>( context, "SdProdutoNotaFiscal", "Factory21");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV8UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Factory21");
         AV9FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Factory21");
         AV14Array_SdNotaFiscal = new GXBaseCollection<SdtSdNotaFiscal>( context, "SdNotaFiscal", "Factory21");
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_steps = new GXUserControl();
         lblTabimportnota_title_Jsonclick = "";
         lblLabeluploaddataxml_Jsonclick = "";
         lblLabeldescriptionuploaddata_Jsonclick = "";
         ucXmlsnotafiscal = new GXUserControl();
         lblTabitens_title_Jsonclick = "";
         ProdutosnotafiscalContainer = new GXWebGrid( context);
         sStyleString = "";
         TempTags = "";
         bttBtnwizardprevious_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         bttBtnwizardnext_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         ucWizard_steps = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldWcwclinhaprodutonota = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         WebComp_Wcwclinhaprodutonota_Component = "";
         AV17SdProdutoNotaFiscal = new SdtSdProdutoNotaFiscal(context);
         AV18JSON = "";
         GXt_char1 = "";
         AV10FileUploadData = new SdtFileUploadData(context);
         AV11File = new GxFile(context.GetPhysicalPath());
         AV12StringNota = "";
         AV13SdNotaFiscal = new SdtSdNotaFiscal(context);
         AV16SdNotaFiscalDet = new SdtSdNotaFiscal_NFe_infNFe_detItem(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ProdutosnotafiscalRow = new GXWebRow();
         subProdutosnotafiscal_Linesclass = "";
         ProdutosnotafiscalColumn = new GXWebColumn();
         subProdutosnotafiscal_Header = "";
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcwclinhaprodutonota = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV7TabsActivePage ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subProdutosnotafiscal_Backcolorstyle ;
      private short nGXWrapped ;
      private short subProdutosnotafiscal_Backstyle ;
      private short subProdutosnotafiscal_Allowselection ;
      private short subProdutosnotafiscal_Allowhovering ;
      private short subProdutosnotafiscal_Allowcollapsing ;
      private short subProdutosnotafiscal_Collapsed ;
      private short PRODUTOSNOTAFISCAL_nEOF ;
      private int Gxuitabspanel_steps_Activepage ;
      private int nRC_GXsfl_40 ;
      private int subProdutosnotafiscal_Recordcount ;
      private int nGXsfl_40_idx=1 ;
      private int Xmlsnotafiscal_Maxnumberoffiles ;
      private int Gxuitabspanel_steps_Pagecount ;
      private int bttBtnwizardprevious_Visible ;
      private int bttBtncancel_Visible ;
      private int bttBtnwizardnext_Visible ;
      private int bttBtnenter_Visible ;
      private int nGXsfl_40_webc_idx=0 ;
      private int subProdutosnotafiscal_Islastpage ;
      private int AV19GXV1 ;
      private int AV20GXV2 ;
      private int AV21GXV3 ;
      private int AV22GXV4 ;
      private int idxLst ;
      private int subProdutosnotafiscal_Backcolor ;
      private int subProdutosnotafiscal_Allbackcolor ;
      private int subProdutosnotafiscal_Selectedindex ;
      private int subProdutosnotafiscal_Selectioncolor ;
      private int subProdutosnotafiscal_Hoveringcolor ;
      private long PRODUTOSNOTAFISCAL_nCurrentRecord ;
      private long PRODUTOSNOTAFISCAL_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_40_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Xmlsnotafiscal_Acceptedfiletypes ;
      private string Xmlsnotafiscal_Customfiletypes ;
      private string Gxuitabspanel_steps_Class ;
      private string Wizard_steps_Tabsinternalname ;
      private string Wizard_steps_Transformtype ;
      private string Wizard_steps_Wizardarrowselectedunselectedimage ;
      private string Wizard_steps_Wizardarrowunselectedselectedimage ;
      private string subProdutosnotafiscal_Class ;
      private string subProdutosnotafiscal_Flexdirection ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Gxuitabspanel_steps_Internalname ;
      private string lblTabimportnota_title_Internalname ;
      private string lblTabimportnota_title_Jsonclick ;
      private string divTableattributes_Internalname ;
      private string divTablenotasflex_Internalname ;
      private string lblLabeluploaddataxml_Internalname ;
      private string lblLabeluploaddataxml_Jsonclick ;
      private string lblLabeldescriptionuploaddata_Internalname ;
      private string lblLabeldescriptionuploaddata_Jsonclick ;
      private string divTableimportxml_Internalname ;
      private string Xmlsnotafiscal_Tooltiptext ;
      private string Xmlsnotafiscal_Internalname ;
      private string lblTabitens_title_Internalname ;
      private string lblTabitens_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string sStyleString ;
      private string subProdutosnotafiscal_Internalname ;
      private string TempTags ;
      private string bttBtnwizardprevious_Internalname ;
      private string bttBtnwizardprevious_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string bttBtnwizardnext_Internalname ;
      private string bttBtnwizardnext_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Wizard_steps_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string OldWcwclinhaprodutonota ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string WebComp_Wcwclinhaprodutonota_Component ;
      private string GXt_char1 ;
      private string subProdutosnotafiscal_Linesclass ;
      private string divProdutosnotafiscallayouttable_Internalname ;
      private string subProdutosnotafiscal_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV5CheckRequiredFieldsResult ;
      private bool Xmlsnotafiscal_Autoupload ;
      private bool Xmlsnotafiscal_Hideadditionalbuttons ;
      private bool Xmlsnotafiscal_Enableuploadedfilecanceling ;
      private bool Xmlsnotafiscal_Disableimageresize ;
      private bool Xmlsnotafiscal_Autodisableaddingfiles ;
      private bool Gxuitabspanel_steps_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_40_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcwclinhaprodutonota ;
      private string AV18JSON ;
      private string AV12StringNota ;
      private GXWebComponent WebComp_Wcwclinhaprodutonota ;
      private GXWebGrid ProdutosnotafiscalContainer ;
      private GXWebRow ProdutosnotafiscalRow ;
      private GXWebColumn ProdutosnotafiscalColumn ;
      private GXUserControl ucGxuitabspanel_steps ;
      private GXUserControl ucXmlsnotafiscal ;
      private GXUserControl ucWizard_steps ;
      private GXWebForm Form ;
      private GxFile AV11File ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSdProdutoNotaFiscal> AV15Array_SdProdutoNotaFiscal ;
      private GXBaseCollection<SdtFileUploadData> AV8UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV9FailedFiles ;
      private GXBaseCollection<SdtSdNotaFiscal> AV14Array_SdNotaFiscal ;
      private GXWebComponent WebComp_GX_Process ;
      private SdtSdProdutoNotaFiscal AV17SdProdutoNotaFiscal ;
      private SdtFileUploadData AV10FileUploadData ;
      private SdtSdNotaFiscal AV13SdNotaFiscal ;
      private SdtSdNotaFiscal_NFe_infNFe_detItem AV16SdNotaFiscalDet ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
