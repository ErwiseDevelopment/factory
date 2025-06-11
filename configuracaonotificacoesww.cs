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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class configuracaonotificacoesww : GXWebComponent
   {
      public configuracaonotificacoesww( )
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

      public configuracaonotificacoesww( IGxContext context )
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
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  gxnrGrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  gxgrGrid_refresh_invoke( ) ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_107 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_107"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_107_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_107_idx = GetPar( "sGXsfl_107_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV14FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV15DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV17ConfiguracaoNotificacoesEmail1 = GetPar( "ConfiguracaoNotificacoesEmail1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV21ConfiguracaoNotificacoesEmail2 = GetPar( "ConfiguracaoNotificacoesEmail2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV25ConfiguracaoNotificacoesEmail3 = GetPar( "ConfiguracaoNotificacoesEmail3");
         AV33ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV44Pgmname = GetPar( "Pgmname");
         AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV22DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV34TFConfiguracaoNotificacoesEmail = GetPar( "TFConfiguracaoNotificacoesEmail");
         AV35TFConfiguracaoNotificacoesEmail_Sel = GetPar( "TFConfiguracaoNotificacoesEmail_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV27DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV26DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConfiguracaoNotificacoesEmail1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConfiguracaoNotificacoesEmail2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConfiguracaoNotificacoesEmail3, AV33ManageFiltersExecutionStep, AV44Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV34TFConfiguracaoNotificacoesEmail, AV35TFConfiguracaoNotificacoesEmail_Sel, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            PA6G2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV44Pgmname = "ConfiguracaoNotificacoesWW";
               edtavDisplay_Enabled = 0;
               AssignProp(sPrefix, false, edtavDisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDisplay_Enabled), 5, 0), !bGXsfl_107_Refreshing);
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_107_Refreshing);
               edtavDelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_107_Refreshing);
               WS6G2( ) ;
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
            context.SendWebValue( " Configuracao Notificacoes") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracaonotificacoesww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV14FilterFullText);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vCONFIGURACAONOTIFICACOESEMAIL1", AV17ConfiguracaoNotificacoesEmail1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vCONFIGURACAONOTIFICACOESEMAIL2", AV21ConfiguracaoNotificacoesEmail2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3", AV23DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vCONFIGURACAONOTIFICACOESEMAIL3", AV25ConfiguracaoNotificacoesEmail3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_107", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_107), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV31ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV31ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV40GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV36DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV36DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV22DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCONFIGURACAONOTIFICACOESEMAIL", AV34TFConfiguracaoNotificacoesEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL", AV35TFConfiguracaoNotificacoesEmail_Sel);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV13OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSIGNOREFIRST", AV27DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSREMOVING", AV26DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Width", StringUtil.RTrim( Dvpanel_tableheader_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_tableheader_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_tableheader_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Cls", StringUtil.RTrim( Dvpanel_tableheader_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Title", StringUtil.RTrim( Dvpanel_tableheader_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Iconposition", StringUtil.RTrim( Dvpanel_tableheader_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm6G2( )
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
         return "ConfiguracaoNotificacoesWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Configuracao Notificacoes" ;
      }

      protected void WB6G0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "configuracaonotificacoesww");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableheader.SetProperty("Width", Dvpanel_tableheader_Width);
            ucDvpanel_tableheader.SetProperty("AutoWidth", Dvpanel_tableheader_Autowidth);
            ucDvpanel_tableheader.SetProperty("AutoHeight", Dvpanel_tableheader_Autoheight);
            ucDvpanel_tableheader.SetProperty("Cls", Dvpanel_tableheader_Cls);
            ucDvpanel_tableheader.SetProperty("Title", Dvpanel_tableheader_Title);
            ucDvpanel_tableheader.SetProperty("Collapsible", Dvpanel_tableheader_Collapsible);
            ucDvpanel_tableheader.SetProperty("Collapsed", Dvpanel_tableheader_Collapsed);
            ucDvpanel_tableheader.SetProperty("ShowCollapseIcon", Dvpanel_tableheader_Showcollapseicon);
            ucDvpanel_tableheader.SetProperty("IconPosition", Dvpanel_tableheader_Iconposition);
            ucDvpanel_tableheader.SetProperty("AutoScroll", Dvpanel_tableheader_Autoscroll);
            ucDvpanel_tableheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableheader_Internalname, sPrefix+"DVPANEL_TABLEHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TABLEHEADERContainer"+"TableHeader"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ConfiguracaoNotificacoesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ConfiguracaoNotificacoesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV31ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV14FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ConfiguracaoNotificacoesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellAdvancedFiltersHidden", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedfilterscontainer_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfilters_Internalname, 1, 0, "px", 0, "px", "TableDynamicFiltersFlex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ConfiguracaoNotificacoesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_ConfiguracaoNotificacoesWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ConfiguracaoNotificacoesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_6G2( true) ;
         }
         else
         {
            wb_table1_45_6G2( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_6G2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ConfiguracaoNotificacoesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 0, "HLP_ConfiguracaoNotificacoesWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ConfiguracaoNotificacoesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_67_6G2( true) ;
         }
         else
         {
            wb_table2_67_6G2( false) ;
         }
         return  ;
      }

      protected void wb_table2_67_6G2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ConfiguracaoNotificacoesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 0, "HLP_ConfiguracaoNotificacoesWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ConfiguracaoNotificacoesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_89_6G2( true) ;
         }
         else
         {
            wb_table3_89_6G2( false) ;
         }
         return  ;
      }

      protected void wb_table3_89_6G2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl107( ) ;
         }
         if ( wbEnd == 107 )
         {
            wbEnd = 0;
            nRC_GXsfl_107 = (int)(nGXsfl_107_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV38GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV39GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV40GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ConfiguracaoNotificacoesWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV36DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 107 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START6G2( )
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
            Form.Meta.addItem("description", " Configuracao Notificacoes", 0) ;
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
               STRUP6G0( ) ;
            }
         }
      }

      protected void WS6G2( )
      {
         START6G2( ) ;
         EVT6G2( ) ;
      }

      protected void EVT6G2( )
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
                                 STRUP6G0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E116G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E126G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E136G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E146G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters1' */
                                    E156G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters2' */
                                    E166G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters3' */
                                    E176G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E186G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E196G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters1' */
                                    E206G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E216G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters2' */
                                    E226G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E236G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E246G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFilterfulltext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
                              SubsflControlProps_1072( ) ;
                              AV41Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV41Display);
                              AV42Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV42Update);
                              AV43Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri(sPrefix, false, edtavDelete_Internalname, AV43Delete);
                              A491ConfiguracaoNotificacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtConfiguracaoNotificacoesId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A492ConfiguracaoNotificacoesEmail = cgiGet( edtConfiguracaoNotificacoesEmail_Internalname);
                              n492ConfiguracaoNotificacoesEmail = false;
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E256G2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E266G2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E276G2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV13OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1"), AV15DynamicFiltersSelector1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV16DynamicFiltersOperator1 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Configuracaonotificacoesemail1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vCONFIGURACAONOTIFICACOESEMAIL1"), AV17ConfiguracaoNotificacoesEmail1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV20DynamicFiltersOperator2 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Configuracaonotificacoesemail2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vCONFIGURACAONOTIFICACOESEMAIL2"), AV21ConfiguracaoNotificacoesEmail2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV23DynamicFiltersSelector3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV24DynamicFiltersOperator3 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Configuracaonotificacoesemail3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vCONFIGURACAONOTIFICACOESEMAIL3"), AV25ConfiguracaoNotificacoesEmail3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
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
                                       STRUP6G0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE6G2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6G2( ) ;
            }
         }
      }

      protected void PA6G2( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1072( ) ;
         while ( nGXsfl_107_idx <= nRC_GXsfl_107 )
         {
            sendrow_1072( ) ;
            nGXsfl_107_idx = ((subGrid_Islastpage==1)&&(nGXsfl_107_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_idx+1);
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       bool AV13OrderedDsc ,
                                       string AV14FilterFullText ,
                                       string AV15DynamicFiltersSelector1 ,
                                       short AV16DynamicFiltersOperator1 ,
                                       string AV17ConfiguracaoNotificacoesEmail1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       short AV20DynamicFiltersOperator2 ,
                                       string AV21ConfiguracaoNotificacoesEmail2 ,
                                       string AV23DynamicFiltersSelector3 ,
                                       short AV24DynamicFiltersOperator3 ,
                                       string AV25ConfiguracaoNotificacoesEmail3 ,
                                       short AV33ManageFiltersExecutionStep ,
                                       string AV44Pgmname ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV22DynamicFiltersEnabled3 ,
                                       string AV34TFConfiguracaoNotificacoesEmail ,
                                       string AV35TFConfiguracaoNotificacoesEmail_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst ,
                                       bool AV26DynamicFiltersRemoving ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF6G2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_CONFIGURACAONOTIFICACOESID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A491ConfiguracaoNotificacoesId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"CONFIGURACAONOTIFICACOESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A491ConfiguracaoNotificacoesId), 9, 0, ".", "")));
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
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV15DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV15DynamicFiltersSelector1);
            AssignAttri(sPrefix, false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV16DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV19DynamicFiltersSelector2);
            AssignAttri(sPrefix, false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV20DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV23DynamicFiltersSelector3);
            AssignAttri(sPrefix, false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV44Pgmname = "ConfiguracaoNotificacoesWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF6G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 107;
         /* Execute user event: Refresh */
         E266G2 ();
         nGXsfl_107_idx = 1;
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         bGXsfl_107_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar GridWithBorderColor WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1072( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV45Configuracaonotificacoeswwds_1_filterfulltext ,
                                                 AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 ,
                                                 AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 ,
                                                 AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ,
                                                 AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 ,
                                                 AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 ,
                                                 AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 ,
                                                 AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ,
                                                 AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 ,
                                                 AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 ,
                                                 AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 ,
                                                 AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ,
                                                 AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel ,
                                                 AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ,
                                                 A492ConfiguracaoNotificacoesEmail ,
                                                 AV13OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV45Configuracaonotificacoeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Configuracaonotificacoeswwds_1_filterfulltext), "%", "");
            lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = StringUtil.Concat( StringUtil.RTrim( AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1), "%", "");
            lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = StringUtil.Concat( StringUtil.RTrim( AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1), "%", "");
            lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = StringUtil.Concat( StringUtil.RTrim( AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2), "%", "");
            lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = StringUtil.Concat( StringUtil.RTrim( AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2), "%", "");
            lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = StringUtil.Concat( StringUtil.RTrim( AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3), "%", "");
            lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = StringUtil.Concat( StringUtil.RTrim( AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3), "%", "");
            lV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = StringUtil.Concat( StringUtil.RTrim( AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail), "%", "");
            /* Using cursor H006G2 */
            pr_default.execute(0, new Object[] {lV45Configuracaonotificacoeswwds_1_filterfulltext, lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1, lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1, lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2, lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2, lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3, lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3, lV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail, AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_107_idx = 1;
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A492ConfiguracaoNotificacoesEmail = H006G2_A492ConfiguracaoNotificacoesEmail[0];
               n492ConfiguracaoNotificacoesEmail = H006G2_n492ConfiguracaoNotificacoesEmail[0];
               A491ConfiguracaoNotificacoesId = H006G2_A491ConfiguracaoNotificacoesId[0];
               /* Execute user event: Grid.Load */
               E276G2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 107;
            WB6G0( ) ;
         }
         bGXsfl_107_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6G2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_CONFIGURACAONOTIFICACOESID"+"_"+sGXsfl_107_idx, GetSecureSignedToken( sPrefix+sGXsfl_107_idx, context.localUtil.Format( (decimal)(A491ConfiguracaoNotificacoesId), "ZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV45Configuracaonotificacoeswwds_1_filterfulltext = AV14FilterFullText;
         AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = AV17ConfiguracaoNotificacoesEmail1;
         AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = AV21ConfiguracaoNotificacoesEmail2;
         AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = AV25ConfiguracaoNotificacoesEmail3;
         AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = AV34TFConfiguracaoNotificacoesEmail;
         AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel = AV35TFConfiguracaoNotificacoesEmail_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV45Configuracaonotificacoeswwds_1_filterfulltext ,
                                              AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 ,
                                              AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 ,
                                              AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ,
                                              AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 ,
                                              AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 ,
                                              AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 ,
                                              AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ,
                                              AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 ,
                                              AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 ,
                                              AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 ,
                                              AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ,
                                              AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel ,
                                              AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ,
                                              A492ConfiguracaoNotificacoesEmail ,
                                              AV13OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV45Configuracaonotificacoeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Configuracaonotificacoeswwds_1_filterfulltext), "%", "");
         lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = StringUtil.Concat( StringUtil.RTrim( AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1), "%", "");
         lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = StringUtil.Concat( StringUtil.RTrim( AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1), "%", "");
         lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = StringUtil.Concat( StringUtil.RTrim( AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2), "%", "");
         lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = StringUtil.Concat( StringUtil.RTrim( AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2), "%", "");
         lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = StringUtil.Concat( StringUtil.RTrim( AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3), "%", "");
         lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = StringUtil.Concat( StringUtil.RTrim( AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3), "%", "");
         lV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = StringUtil.Concat( StringUtil.RTrim( AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail), "%", "");
         /* Using cursor H006G3 */
         pr_default.execute(1, new Object[] {lV45Configuracaonotificacoeswwds_1_filterfulltext, lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1, lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1, lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2, lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2, lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3, lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3, lV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail, AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel});
         GRID_nRecordCount = H006G3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV45Configuracaonotificacoeswwds_1_filterfulltext = AV14FilterFullText;
         AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = AV17ConfiguracaoNotificacoesEmail1;
         AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = AV21ConfiguracaoNotificacoesEmail2;
         AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = AV25ConfiguracaoNotificacoesEmail3;
         AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = AV34TFConfiguracaoNotificacoesEmail;
         AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel = AV35TFConfiguracaoNotificacoesEmail_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConfiguracaoNotificacoesEmail1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConfiguracaoNotificacoesEmail2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConfiguracaoNotificacoesEmail3, AV33ManageFiltersExecutionStep, AV44Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV34TFConfiguracaoNotificacoesEmail, AV35TFConfiguracaoNotificacoesEmail_Sel, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV45Configuracaonotificacoeswwds_1_filterfulltext = AV14FilterFullText;
         AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = AV17ConfiguracaoNotificacoesEmail1;
         AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = AV21ConfiguracaoNotificacoesEmail2;
         AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = AV25ConfiguracaoNotificacoesEmail3;
         AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = AV34TFConfiguracaoNotificacoesEmail;
         AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel = AV35TFConfiguracaoNotificacoesEmail_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConfiguracaoNotificacoesEmail1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConfiguracaoNotificacoesEmail2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConfiguracaoNotificacoesEmail3, AV33ManageFiltersExecutionStep, AV44Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV34TFConfiguracaoNotificacoesEmail, AV35TFConfiguracaoNotificacoesEmail_Sel, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV45Configuracaonotificacoeswwds_1_filterfulltext = AV14FilterFullText;
         AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = AV17ConfiguracaoNotificacoesEmail1;
         AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = AV21ConfiguracaoNotificacoesEmail2;
         AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = AV25ConfiguracaoNotificacoesEmail3;
         AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = AV34TFConfiguracaoNotificacoesEmail;
         AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel = AV35TFConfiguracaoNotificacoesEmail_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConfiguracaoNotificacoesEmail1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConfiguracaoNotificacoesEmail2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConfiguracaoNotificacoesEmail3, AV33ManageFiltersExecutionStep, AV44Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV34TFConfiguracaoNotificacoesEmail, AV35TFConfiguracaoNotificacoesEmail_Sel, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV45Configuracaonotificacoeswwds_1_filterfulltext = AV14FilterFullText;
         AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = AV17ConfiguracaoNotificacoesEmail1;
         AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = AV21ConfiguracaoNotificacoesEmail2;
         AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = AV25ConfiguracaoNotificacoesEmail3;
         AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = AV34TFConfiguracaoNotificacoesEmail;
         AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel = AV35TFConfiguracaoNotificacoesEmail_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConfiguracaoNotificacoesEmail1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConfiguracaoNotificacoesEmail2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConfiguracaoNotificacoesEmail3, AV33ManageFiltersExecutionStep, AV44Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV34TFConfiguracaoNotificacoesEmail, AV35TFConfiguracaoNotificacoesEmail_Sel, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV45Configuracaonotificacoeswwds_1_filterfulltext = AV14FilterFullText;
         AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = AV17ConfiguracaoNotificacoesEmail1;
         AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = AV21ConfiguracaoNotificacoesEmail2;
         AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = AV25ConfiguracaoNotificacoesEmail3;
         AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = AV34TFConfiguracaoNotificacoesEmail;
         AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel = AV35TFConfiguracaoNotificacoesEmail_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConfiguracaoNotificacoesEmail1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConfiguracaoNotificacoesEmail2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConfiguracaoNotificacoesEmail3, AV33ManageFiltersExecutionStep, AV44Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV34TFConfiguracaoNotificacoesEmail, AV35TFConfiguracaoNotificacoesEmail_Sel, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV44Pgmname = "ConfiguracaoNotificacoesWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtConfiguracaoNotificacoesId_Enabled = 0;
         edtConfiguracaoNotificacoesEmail_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E256G2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV31ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV36DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_107 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_107"), ",", "."), 18, MidpointRounding.ToEven));
            AV38GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV39GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV40GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Dvpanel_tableheader_Width = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Width");
            Dvpanel_tableheader_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Autowidth"));
            Dvpanel_tableheader_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Autoheight"));
            Dvpanel_tableheader_Cls = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Cls");
            Dvpanel_tableheader_Title = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Title");
            Dvpanel_tableheader_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Collapsible"));
            Dvpanel_tableheader_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Collapsed"));
            Dvpanel_tableheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Showcollapseicon"));
            Dvpanel_tableheader_Iconposition = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Iconposition");
            Dvpanel_tableheader_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Autoscroll"));
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( sPrefix+"GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV14FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV14FilterFullText", AV14FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV15DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri(sPrefix, false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV16DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AV17ConfiguracaoNotificacoesEmail1 = cgiGet( edtavConfiguracaonotificacoesemail1_Internalname);
            AssignAttri(sPrefix, false, "AV17ConfiguracaoNotificacoesEmail1", AV17ConfiguracaoNotificacoesEmail1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri(sPrefix, false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV20DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AV21ConfiguracaoNotificacoesEmail2 = cgiGet( edtavConfiguracaonotificacoesemail2_Internalname);
            AssignAttri(sPrefix, false, "AV21ConfiguracaoNotificacoesEmail2", AV21ConfiguracaoNotificacoesEmail2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV23DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri(sPrefix, false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV24DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AV25ConfiguracaoNotificacoesEmail3 = cgiGet( edtavConfiguracaonotificacoesemail3_Internalname);
            AssignAttri(sPrefix, false, "AV25ConfiguracaoNotificacoesEmail3", AV25ConfiguracaoNotificacoesEmail3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV13OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1"), AV15DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV16DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vCONFIGURACAONOTIFICACOESEMAIL1"), AV17ConfiguracaoNotificacoesEmail1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV20DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vCONFIGURACAONOTIFICACOESEMAIL2"), AV21ConfiguracaoNotificacoesEmail2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV23DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV24DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vCONFIGURACAONOTIFICACOESEMAIL3"), AV25ConfiguracaoNotificacoesEmail3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E256G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E256G2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "CONFIGURACAONOTIFICACOESEMAIL";
         AssignAttri(sPrefix, false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV19DynamicFiltersSelector2 = "CONFIGURACAONOTIFICACOESEMAIL";
         AssignAttri(sPrefix, false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector3 = "CONFIGURACAONOTIFICACOESEMAIL";
         AssignAttri(sPrefix, false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV36DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV36DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E266G2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV33ManageFiltersExecutionStep == 1 )
         {
            AV33ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV33ManageFiltersExecutionStep == 2 )
         {
            AV33ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV38GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV38GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV38GridCurrentPage), 10, 0));
         AV39GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV39GridPageCount", StringUtil.LTrimStr( (decimal)(AV39GridPageCount), 10, 0));
         GXt_char2 = AV40GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV44Pgmname, out  GXt_char2) ;
         AV40GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV40GridAppliedFilters", AV40GridAppliedFilters);
         AV45Configuracaonotificacoeswwds_1_filterfulltext = AV14FilterFullText;
         AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = AV17ConfiguracaoNotificacoesEmail1;
         AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = AV21ConfiguracaoNotificacoesEmail2;
         AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = AV25ConfiguracaoNotificacoesEmail3;
         AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = AV34TFConfiguracaoNotificacoesEmail;
         AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel = AV35TFConfiguracaoNotificacoesEmail_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ManageFiltersData", AV31ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E126G2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV37PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV37PageToGo) ;
         }
      }

      protected void E136G2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E146G2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ConfiguracaoNotificacoesEmail") == 0 )
            {
               AV34TFConfiguracaoNotificacoesEmail = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV34TFConfiguracaoNotificacoesEmail", AV34TFConfiguracaoNotificacoesEmail);
               AV35TFConfiguracaoNotificacoesEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV35TFConfiguracaoNotificacoesEmail_Sel", AV35TFConfiguracaoNotificacoesEmail_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E276G2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV41Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri(sPrefix, false, edtavDisplay_Internalname, AV41Display);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "configuracaonotificacoes"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A491ConfiguracaoNotificacoesId,9,0));
         edtavDisplay_Link = formatLink("configuracaonotificacoes") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV42Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV42Update);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "configuracaonotificacoes"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A491ConfiguracaoNotificacoesId,9,0));
         edtavUpdate_Link = formatLink("configuracaonotificacoes") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV43Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri(sPrefix, false, edtavDelete_Internalname, AV43Delete);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "configuracaonotificacoes"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A491ConfiguracaoNotificacoesId,9,0));
         edtavDelete_Link = formatLink("configuracaonotificacoes") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 107;
         }
         sendrow_1072( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_107_Refreshing )
         {
            DoAjaxLoad(107, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E206G2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = true;
         AssignAttri(sPrefix, false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E156G2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV26DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV27DynamicFiltersIgnoreFirst = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersIgnoreFirst", AV27DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV27DynamicFiltersIgnoreFirst = false;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersIgnoreFirst", AV27DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConfiguracaoNotificacoesEmail1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConfiguracaoNotificacoesEmail2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConfiguracaoNotificacoesEmail3, AV33ManageFiltersExecutionStep, AV44Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV34TFConfiguracaoNotificacoesEmail, AV35TFConfiguracaoNotificacoesEmail_Sel, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ManageFiltersData", AV31ManageFiltersData);
      }

      protected void E216G2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E226G2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled3 = true;
         AssignAttri(sPrefix, false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E166G2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV26DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConfiguracaoNotificacoesEmail1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConfiguracaoNotificacoesEmail2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConfiguracaoNotificacoesEmail3, AV33ManageFiltersExecutionStep, AV44Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV34TFConfiguracaoNotificacoesEmail, AV35TFConfiguracaoNotificacoesEmail_Sel, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ManageFiltersData", AV31ManageFiltersData);
      }

      protected void E236G2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E176G2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV26DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV14FilterFullText, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ConfiguracaoNotificacoesEmail1, AV19DynamicFiltersSelector2, AV20DynamicFiltersOperator2, AV21ConfiguracaoNotificacoesEmail2, AV23DynamicFiltersSelector3, AV24DynamicFiltersOperator3, AV25ConfiguracaoNotificacoesEmail3, AV33ManageFiltersExecutionStep, AV44Pgmname, AV18DynamicFiltersEnabled2, AV22DynamicFiltersEnabled3, AV34TFConfiguracaoNotificacoesEmail, AV35TFConfiguracaoNotificacoesEmail_Sel, AV10GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ManageFiltersData", AV31ManageFiltersData);
      }

      protected void E246G2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E116G2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("ConfiguracaoNotificacoesWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV44Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV33ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("ConfiguracaoNotificacoesWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV33ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV33ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV33ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV32ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ConfiguracaoNotificacoesWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV32ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S222 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV44Pgmname+"GridState",  AV32ManageFiltersXml) ;
               AV10GridState.FromXml(AV32ManageFiltersXml, null, "", "");
               AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S232 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S212 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV31ManageFiltersData", AV31ManageFiltersData);
      }

      protected void E186G2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "configuracaonotificacoes"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("configuracaonotificacoes") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E196G2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new configuracaonotificacoeswwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
         if ( StringUtil.StrCmp(AV28ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV28ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV29ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void S182( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = "-1:"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavConfiguracaonotificacoesemail1_Visible = 0;
         AssignProp(sPrefix, false, edtavConfiguracaonotificacoesemail1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfiguracaonotificacoesemail1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 )
         {
            edtavConfiguracaonotificacoesemail1_Visible = 1;
            AssignProp(sPrefix, false, edtavConfiguracaonotificacoesemail1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfiguracaonotificacoesemail1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavConfiguracaonotificacoesemail2_Visible = 0;
         AssignProp(sPrefix, false, edtavConfiguracaonotificacoesemail2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfiguracaonotificacoesemail2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 )
         {
            edtavConfiguracaonotificacoesemail2_Visible = 1;
            AssignProp(sPrefix, false, edtavConfiguracaonotificacoesemail2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfiguracaonotificacoesemail2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavConfiguracaonotificacoesemail3_Visible = 0;
         AssignProp(sPrefix, false, edtavConfiguracaonotificacoesemail3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfiguracaonotificacoesemail3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 )
         {
            edtavConfiguracaonotificacoesemail3_Visible = 1;
            AssignProp(sPrefix, false, edtavConfiguracaonotificacoesemail3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfiguracaonotificacoesemail3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         AV19DynamicFiltersSelector2 = "CONFIGURACAONOTIFICACOESEMAIL";
         AssignAttri(sPrefix, false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
         AV21ConfiguracaoNotificacoesEmail2 = "";
         AssignAttri(sPrefix, false, "AV21ConfiguracaoNotificacoesEmail2", AV21ConfiguracaoNotificacoesEmail2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
         AV23DynamicFiltersSelector3 = "CONFIGURACAONOTIFICACOESEMAIL";
         AssignAttri(sPrefix, false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
         AV24DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
         AV25ConfiguracaoNotificacoesEmail3 = "";
         AssignAttri(sPrefix, false, "AV25ConfiguracaoNotificacoesEmail3", AV25ConfiguracaoNotificacoesEmail3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV31ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ConfiguracaoNotificacoesWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV31ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV14FilterFullText = "";
         AssignAttri(sPrefix, false, "AV14FilterFullText", AV14FilterFullText);
         AV34TFConfiguracaoNotificacoesEmail = "";
         AssignAttri(sPrefix, false, "AV34TFConfiguracaoNotificacoesEmail", AV34TFConfiguracaoNotificacoesEmail);
         AV35TFConfiguracaoNotificacoesEmail_Sel = "";
         AssignAttri(sPrefix, false, "AV35TFConfiguracaoNotificacoesEmail_Sel", AV35TFConfiguracaoNotificacoesEmail_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV15DynamicFiltersSelector1 = "CONFIGURACAONOTIFICACOESEMAIL";
         AssignAttri(sPrefix, false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         AV16DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AV17ConfiguracaoNotificacoesEmail1 = "";
         AssignAttri(sPrefix, false, "AV17ConfiguracaoNotificacoesEmail1", AV17ConfiguracaoNotificacoesEmail1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get(AV44Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV44Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV30Session.Get(AV44Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV14FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV14FilterFullText", AV14FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONFIGURACAONOTIFICACOESEMAIL") == 0 )
            {
               AV34TFConfiguracaoNotificacoesEmail = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV34TFConfiguracaoNotificacoesEmail", AV34TFConfiguracaoNotificacoesEmail);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONFIGURACAONOTIFICACOESEMAIL_SEL") == 0 )
            {
               AV35TFConfiguracaoNotificacoesEmail_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFConfiguracaoNotificacoesEmail_Sel", AV35TFConfiguracaoNotificacoesEmail_Sel);
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFConfiguracaoNotificacoesEmail_Sel)),  AV35TFConfiguracaoNotificacoesEmail_Sel, out  GXt_char2) ;
         Ddo_grid_Selectedvalue_set = GXt_char2;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFConfiguracaoNotificacoesEmail)),  AV34TFConfiguracaoNotificacoesEmail, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char2;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S212( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV15DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri(sPrefix, false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17ConfiguracaoNotificacoesEmail1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV17ConfiguracaoNotificacoesEmail1", AV17ConfiguracaoNotificacoesEmail1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV18DynamicFiltersEnabled2 = true;
               AssignAttri(sPrefix, false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri(sPrefix, false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV20DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
                  AV21ConfiguracaoNotificacoesEmail2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV21ConfiguracaoNotificacoesEmail2", AV21ConfiguracaoNotificacoesEmail2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV22DynamicFiltersEnabled3 = true;
                  AssignAttri(sPrefix, false, "AV22DynamicFiltersEnabled3", AV22DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri(sPrefix, false, "AV23DynamicFiltersSelector3", AV23DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV24DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
                     AV25ConfiguracaoNotificacoesEmail3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV25ConfiguracaoNotificacoesEmail3", AV25ConfiguracaoNotificacoesEmail3);
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S142 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+"});</script>";
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV26DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV30Session.Get(AV44Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)),  0,  AV14FilterFullText,  AV14FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCONFIGURACAONOTIFICACOESEMAIL",  "E-mail",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFConfiguracaoNotificacoesEmail)),  0,  AV34TFConfiguracaoNotificacoesEmail,  AV34TFConfiguracaoNotificacoesEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFConfiguracaoNotificacoesEmail_Sel)),  AV35TFConfiguracaoNotificacoesEmail_Sel,  AV35TFConfiguracaoNotificacoesEmail_Sel) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV44Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV27DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV15DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17ConfiguracaoNotificacoesEmail1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Notificacoes Email",  AV16DynamicFiltersOperator1,  AV17ConfiguracaoNotificacoesEmail1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV17ConfiguracaoNotificacoesEmail1, "Contém"+" "+AV17ConfiguracaoNotificacoesEmail1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV19DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ConfiguracaoNotificacoesEmail2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Notificacoes Email",  AV20DynamicFiltersOperator2,  AV21ConfiguracaoNotificacoesEmail2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV21ConfiguracaoNotificacoesEmail2, "Contém"+" "+AV21ConfiguracaoNotificacoesEmail2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ConfiguracaoNotificacoesEmail3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Notificacoes Email",  AV24DynamicFiltersOperator3,  AV25ConfiguracaoNotificacoesEmail3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV25ConfiguracaoNotificacoesEmail3, "Contém"+" "+AV25ConfiguracaoNotificacoesEmail3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV44Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "ConfiguracaoNotificacoes";
         AV30Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_89_6G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters3_Internalname, tblTablemergeddynamicfilters3_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator3_Internalname, "Dynamic Filters Operator3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_ConfiguracaoNotificacoesWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_configuracaonotificacoesemail3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfiguracaonotificacoesemail3_Internalname, "Configuracao Notificacoes Email3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfiguracaonotificacoesemail3_Internalname, AV25ConfiguracaoNotificacoesEmail3, StringUtil.RTrim( context.localUtil.Format( AV25ConfiguracaoNotificacoesEmail3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfiguracaonotificacoesemail3_Jsonclick, 0, "Attribute", "", "", "", "", edtavConfiguracaonotificacoesemail3_Visible, edtavConfiguracaonotificacoesemail3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_ConfiguracaoNotificacoesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ConfiguracaoNotificacoesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_89_6G2e( true) ;
         }
         else
         {
            wb_table3_89_6G2e( false) ;
         }
      }

      protected void wb_table2_67_6G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters2_Internalname, tblTablemergeddynamicfilters2_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator2_Internalname, "Dynamic Filters Operator2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_ConfiguracaoNotificacoesWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_configuracaonotificacoesemail2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfiguracaonotificacoesemail2_Internalname, "Configuracao Notificacoes Email2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfiguracaonotificacoesemail2_Internalname, AV21ConfiguracaoNotificacoesEmail2, StringUtil.RTrim( context.localUtil.Format( AV21ConfiguracaoNotificacoesEmail2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfiguracaonotificacoesemail2_Jsonclick, 0, "Attribute", "", "", "", "", edtavConfiguracaonotificacoesemail2_Visible, edtavConfiguracaonotificacoesemail2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_ConfiguracaoNotificacoesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ConfiguracaoNotificacoesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ConfiguracaoNotificacoesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_67_6G2e( true) ;
         }
         else
         {
            wb_table2_67_6G2e( false) ;
         }
      }

      protected void wb_table1_45_6G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters1_Internalname, tblTablemergeddynamicfilters1_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator1_Internalname, "Dynamic Filters Operator1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_ConfiguracaoNotificacoesWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_configuracaonotificacoesemail1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfiguracaonotificacoesemail1_Internalname, "Configuracao Notificacoes Email1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfiguracaonotificacoesemail1_Internalname, AV17ConfiguracaoNotificacoesEmail1, StringUtil.RTrim( context.localUtil.Format( AV17ConfiguracaoNotificacoesEmail1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfiguracaonotificacoesemail1_Jsonclick, 0, "Attribute", "", "", "", "", edtavConfiguracaonotificacoesemail1_Visible, edtavConfiguracaonotificacoesemail1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_ConfiguracaoNotificacoesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ConfiguracaoNotificacoesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ConfiguracaoNotificacoesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_6G2e( true) ;
         }
         else
         {
            wb_table1_45_6G2e( false) ;
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
         PA6G2( ) ;
         WS6G2( ) ;
         WE6G2( ) ;
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
         PA6G2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "configuracaonotificacoesww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6G2( ) ;
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
         PA6G2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6G2( ) ;
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
         WS6G2( ) ;
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
         WE6G2( ) ;
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
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101918577", true, true);
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
         context.AddJavascriptSource("configuracaonotificacoesww.js", "?20256101918577", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1072( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_107_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_107_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_107_idx;
         edtConfiguracaoNotificacoesId_Internalname = sPrefix+"CONFIGURACAONOTIFICACOESID_"+sGXsfl_107_idx;
         edtConfiguracaoNotificacoesEmail_Internalname = sPrefix+"CONFIGURACAONOTIFICACOESEMAIL_"+sGXsfl_107_idx;
      }

      protected void SubsflControlProps_fel_1072( )
      {
         edtavDisplay_Internalname = sPrefix+"vDISPLAY_"+sGXsfl_107_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_107_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_107_fel_idx;
         edtConfiguracaoNotificacoesId_Internalname = sPrefix+"CONFIGURACAONOTIFICACOESID_"+sGXsfl_107_fel_idx;
         edtConfiguracaoNotificacoesEmail_Internalname = sPrefix+"CONFIGURACAONOTIFICACOESEMAIL_"+sGXsfl_107_fel_idx;
      }

      protected void sendrow_1072( )
      {
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         WB6G0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_107_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_107_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_107_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',107)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV41Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',107)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV42Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'" + sGXsfl_107_idx + "',107)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV43Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfiguracaoNotificacoesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A491ConfiguracaoNotificacoesId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A491ConfiguracaoNotificacoesId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConfiguracaoNotificacoesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConfiguracaoNotificacoesEmail_Internalname,(string)A492ConfiguracaoNotificacoesEmail,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A492ConfiguracaoNotificacoesEmail,(string)"",(string)"",(string)"",(string)edtConfiguracaoNotificacoesEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes6G2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_107_idx = ((subGrid_Islastpage==1)&&(nGXsfl_107_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_idx+1);
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
         }
         /* End function sendrow_1072 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("CONFIGURACAONOTIFICACOESEMAIL", "Notificacoes Email", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("CONFIGURACAONOTIFICACOESEMAIL", "Notificacoes Email", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CONFIGURACAONOTIFICACOESEMAIL", "Notificacoes Email", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl107( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"107\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar GridWithBorderColor WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Notificacoes Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "E-mail") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar GridWithBorderColor WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV41Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV42Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV43Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A491ConfiguracaoNotificacoesId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A492ConfiguracaoNotificacoesEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
         bttBtnexport_Internalname = sPrefix+"BTNEXPORT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = sPrefix+"DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR1";
         edtavConfiguracaonotificacoesemail1_Internalname = sPrefix+"vCONFIGURACAONOTIFICACOESEMAIL1";
         cellFilter_configuracaonotificacoesemail1_cell_Internalname = sPrefix+"FILTER_CONFIGURACAONOTIFICACOESEMAIL1_CELL";
         imgAdddynamicfilters1_Internalname = sPrefix+"ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = sPrefix+"DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = sPrefix+"REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = sPrefix+"DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR2";
         edtavConfiguracaonotificacoesemail2_Internalname = sPrefix+"vCONFIGURACAONOTIFICACOESEMAIL2";
         cellFilter_configuracaonotificacoesemail2_cell_Internalname = sPrefix+"FILTER_CONFIGURACAONOTIFICACOESEMAIL2_CELL";
         imgAdddynamicfilters2_Internalname = sPrefix+"ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = sPrefix+"DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = sPrefix+"REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = sPrefix+"DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR3";
         edtavConfiguracaonotificacoesemail3_Internalname = sPrefix+"vCONFIGURACAONOTIFICACOESEMAIL3";
         cellFilter_configuracaonotificacoesemail3_cell_Internalname = sPrefix+"FILTER_CONFIGURACAONOTIFICACOESEMAIL3_CELL";
         imgRemovedynamicfilters3_Internalname = sPrefix+"REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = sPrefix+"TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = sPrefix+"ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = sPrefix+"vDISPLAY";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         edtConfiguracaoNotificacoesId_Internalname = sPrefix+"CONFIGURACAONOTIFICACOESID";
         edtConfiguracaoNotificacoesEmail_Internalname = sPrefix+"CONFIGURACAONOTIFICACOESEMAIL";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         lblJsdynamicfilters_Internalname = sPrefix+"JSDYNAMICFILTERS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtConfiguracaoNotificacoesEmail_Jsonclick = "";
         edtConfiguracaoNotificacoesId_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavConfiguracaonotificacoesemail1_Jsonclick = "";
         edtavConfiguracaonotificacoesemail1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavConfiguracaonotificacoesemail2_Jsonclick = "";
         edtavConfiguracaonotificacoesemail2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavConfiguracaonotificacoesemail3_Jsonclick = "";
         edtavConfiguracaonotificacoesemail3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavConfiguracaonotificacoesemail3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavConfiguracaonotificacoesemail2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavConfiguracaonotificacoesemail1_Visible = 1;
         edtConfiguracaoNotificacoesEmail_Enabled = 0;
         edtConfiguracaoNotificacoesId_Enabled = 0;
         subGrid_Sortable = 0;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Fixedcolumns = ";L;L;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "ConfiguracaoNotificacoesWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "-1";
         Ddo_grid_Columnids = "4:ConfiguracaoNotificacoesEmail";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Dvpanel_tableheader_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Iconposition = "Right";
         Dvpanel_tableheader_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Title = "Opções";
         Dvpanel_tableheader_Cls = "PanelNoHeader";
         Dvpanel_tableheader_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Width = "100%";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV34TFConfiguracaoNotificacoesEmail","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL","type":"svchar"},{"av":"AV35TFConfiguracaoNotificacoesEmail_Sel","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E126G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV34TFConfiguracaoNotificacoesEmail","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL","type":"svchar"},{"av":"AV35TFConfiguracaoNotificacoesEmail_Sel","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E136G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV34TFConfiguracaoNotificacoesEmail","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL","type":"svchar"},{"av":"AV35TFConfiguracaoNotificacoesEmail_Sel","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E146G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV34TFConfiguracaoNotificacoesEmail","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL","type":"svchar"},{"av":"AV35TFConfiguracaoNotificacoesEmail_Sel","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV34TFConfiguracaoNotificacoesEmail","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL","type":"svchar"},{"av":"AV35TFConfiguracaoNotificacoesEmail_Sel","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E276G2","iparms":[{"av":"A491ConfiguracaoNotificacoesId","fld":"CONFIGURACAONOTIFICACOESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV41Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV42Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV43Delete","fld":"vDELETE","type":"char"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E206G2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E156G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV34TFConfiguracaoNotificacoesEmail","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL","type":"svchar"},{"av":"AV35TFConfiguracaoNotificacoesEmail_Sel","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavConfiguracaonotificacoesemail2_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL2","prop":"Visible"},{"av":"edtavConfiguracaonotificacoesemail3_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL3","prop":"Visible"},{"av":"edtavConfiguracaonotificacoesemail1_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL1","prop":"Visible"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E216G2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavConfiguracaonotificacoesemail1_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E226G2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E166G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV34TFConfiguracaoNotificacoesEmail","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL","type":"svchar"},{"av":"AV35TFConfiguracaoNotificacoesEmail_Sel","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavConfiguracaonotificacoesemail2_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL2","prop":"Visible"},{"av":"edtavConfiguracaonotificacoesemail3_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL3","prop":"Visible"},{"av":"edtavConfiguracaonotificacoesemail1_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL1","prop":"Visible"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E236G2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavConfiguracaonotificacoesemail2_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E176G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV34TFConfiguracaoNotificacoesEmail","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL","type":"svchar"},{"av":"AV35TFConfiguracaoNotificacoesEmail_Sel","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavConfiguracaonotificacoesemail2_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL2","prop":"Visible"},{"av":"edtavConfiguracaonotificacoesemail3_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL3","prop":"Visible"},{"av":"edtavConfiguracaonotificacoesemail1_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL1","prop":"Visible"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E246G2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavConfiguracaonotificacoesemail3_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E116G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV34TFConfiguracaoNotificacoesEmail","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL","type":"svchar"},{"av":"AV35TFConfiguracaoNotificacoesEmail_Sel","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV34TFConfiguracaoNotificacoesEmail","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL","type":"svchar"},{"av":"AV35TFConfiguracaoNotificacoesEmail_Sel","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"edtavConfiguracaonotificacoesemail1_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL1","prop":"Visible"},{"av":"edtavConfiguracaonotificacoesemail2_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL2","prop":"Visible"},{"av":"edtavConfiguracaonotificacoesemail3_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL3","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV31ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E186G2","iparms":[{"av":"A491ConfiguracaoNotificacoesId","fld":"CONFIGURACAONOTIFICACOESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E196G2","iparms":[{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV35TFConfiguracaoNotificacoesEmail_Sel","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL","type":"svchar"},{"av":"AV34TFConfiguracaoNotificacoesEmail","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL","type":"svchar"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV16DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV17ConfiguracaoNotificacoesEmail1","fld":"vCONFIGURACAONOTIFICACOESEMAIL1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV20DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV21ConfiguracaoNotificacoesEmail2","fld":"vCONFIGURACAONOTIFICACOESEMAIL2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV23DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV24DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV25ConfiguracaoNotificacoesEmail3","fld":"vCONFIGURACAONOTIFICACOESEMAIL3","type":"svchar"},{"av":"AV33ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV22DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV34TFConfiguracaoNotificacoesEmail","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL","type":"svchar"},{"av":"AV35TFConfiguracaoNotificacoesEmail_Sel","fld":"vTFCONFIGURACAONOTIFICACOESEMAIL_SEL","type":"svchar"},{"av":"AV27DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV26DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavConfiguracaonotificacoesemail1_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL1","prop":"Visible"},{"av":"edtavConfiguracaonotificacoesemail2_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL2","prop":"Visible"},{"av":"edtavConfiguracaonotificacoesemail3_Visible","ctrl":"vCONFIGURACAONOTIFICACOESEMAIL3","prop":"Visible"}]}""");
         setEventMetadata("VALIDV_CONFIGURACAONOTIFICACOESEMAIL1","""{"handler":"Validv_Configuracaonotificacoesemail1","iparms":[]}""");
         setEventMetadata("VALIDV_CONFIGURACAONOTIFICACOESEMAIL2","""{"handler":"Validv_Configuracaonotificacoesemail2","iparms":[]}""");
         setEventMetadata("VALIDV_CONFIGURACAONOTIFICACOESEMAIL3","""{"handler":"Validv_Configuracaonotificacoesemail3","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Configuracaonotificacoesemail","iparms":[]}""");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV14FilterFullText = "";
         AV15DynamicFiltersSelector1 = "";
         AV17ConfiguracaoNotificacoesEmail1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV21ConfiguracaoNotificacoesEmail2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25ConfiguracaoNotificacoesEmail3 = "";
         AV44Pgmname = "";
         AV34TFConfiguracaoNotificacoesEmail = "";
         AV35TFConfiguracaoNotificacoesEmail_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV31ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40GridAppliedFilters = "";
         AV36DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnexport_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV41Display = "";
         AV42Update = "";
         AV43Delete = "";
         A492ConfiguracaoNotificacoesEmail = "";
         lV45Configuracaonotificacoeswwds_1_filterfulltext = "";
         lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = "";
         lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = "";
         lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = "";
         lV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = "";
         AV45Configuracaonotificacoeswwds_1_filterfulltext = "";
         AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 = "";
         AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 = "";
         AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 = "";
         AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 = "";
         AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 = "";
         AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 = "";
         AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel = "";
         AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail = "";
         H006G2_A492ConfiguracaoNotificacoesEmail = new string[] {""} ;
         H006G2_n492ConfiguracaoNotificacoesEmail = new bool[] {false} ;
         H006G2_A491ConfiguracaoNotificacoesId = new int[1] ;
         H006G3_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV32ManageFiltersXml = "";
         AV28ExcelFilename = "";
         AV29ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV30Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracaonotificacoesww__default(),
            new Object[][] {
                new Object[] {
               H006G2_A492ConfiguracaoNotificacoesEmail, H006G2_n492ConfiguracaoNotificacoesEmail, H006G2_A491ConfiguracaoNotificacoesId
               }
               , new Object[] {
               H006G3_AGRID_nRecordCount
               }
            }
         );
         AV44Pgmname = "ConfiguracaoNotificacoesWW";
         /* GeneXus formulas. */
         AV44Pgmname = "ConfiguracaoNotificacoesWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV16DynamicFiltersOperator1 ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV33ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 ;
      private short AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 ;
      private short AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_107 ;
      private int nGXsfl_107_idx=1 ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A491ConfiguracaoNotificacoesId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtConfiguracaoNotificacoesId_Enabled ;
      private int edtConfiguracaoNotificacoesEmail_Enabled ;
      private int AV37PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavConfiguracaonotificacoesemail1_Visible ;
      private int edtavConfiguracaonotificacoesemail2_Visible ;
      private int edtavConfiguracaonotificacoesemail3_Visible ;
      private int AV59GXV1 ;
      private int edtavConfiguracaonotificacoesemail3_Enabled ;
      private int edtavConfiguracaonotificacoesemail2_Enabled ;
      private int edtavConfiguracaonotificacoesemail1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV38GridCurrentPage ;
      private long AV39GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_107_idx="0001" ;
      private string AV44Pgmname ;
      private string edtavDisplay_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Dvpanel_tableheader_Width ;
      private string Dvpanel_tableheader_Cls ;
      private string Dvpanel_tableheader_Title ;
      private string Dvpanel_tableheader_Iconposition ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnexport_Internalname ;
      private string bttBtnexport_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divAdvancedfilterscontainer_Internalname ;
      private string divTabledynamicfilters_Internalname ;
      private string divTabledynamicfiltersrow1_Internalname ;
      private string lblDynamicfiltersprefix1_Internalname ;
      private string lblDynamicfiltersprefix1_Jsonclick ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersselector1_Jsonclick ;
      private string lblDynamicfiltersmiddle1_Internalname ;
      private string lblDynamicfiltersmiddle1_Jsonclick ;
      private string divTabledynamicfiltersrow2_Internalname ;
      private string lblDynamicfiltersprefix2_Internalname ;
      private string lblDynamicfiltersprefix2_Jsonclick ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersselector2_Jsonclick ;
      private string lblDynamicfiltersmiddle2_Internalname ;
      private string lblDynamicfiltersmiddle2_Jsonclick ;
      private string divTabledynamicfiltersrow3_Internalname ;
      private string lblDynamicfiltersprefix3_Internalname ;
      private string lblDynamicfiltersprefix3_Jsonclick ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersselector3_Jsonclick ;
      private string lblDynamicfiltersmiddle3_Internalname ;
      private string lblDynamicfiltersmiddle3_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV41Display ;
      private string AV42Update ;
      private string AV43Delete ;
      private string edtConfiguracaoNotificacoesId_Internalname ;
      private string edtConfiguracaoNotificacoesEmail_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavConfiguracaonotificacoesemail1_Internalname ;
      private string edtavConfiguracaonotificacoesemail2_Internalname ;
      private string edtavConfiguracaonotificacoesemail3_Internalname ;
      private string imgAdddynamicfilters1_Jsonclick ;
      private string imgAdddynamicfilters1_Internalname ;
      private string imgRemovedynamicfilters1_Jsonclick ;
      private string imgRemovedynamicfilters1_Internalname ;
      private string imgAdddynamicfilters2_Jsonclick ;
      private string imgAdddynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters2_Jsonclick ;
      private string imgRemovedynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters3_Jsonclick ;
      private string imgRemovedynamicfilters3_Internalname ;
      private string edtavDisplay_Link ;
      private string GXEncryptionTmp ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_configuracaonotificacoesemail3_cell_Internalname ;
      private string edtavConfiguracaonotificacoesemail3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_configuracaonotificacoesemail2_cell_Internalname ;
      private string edtavConfiguracaonotificacoesemail2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_configuracaonotificacoesemail1_cell_Internalname ;
      private string edtavConfiguracaonotificacoesemail1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_107_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtConfiguracaoNotificacoesId_Jsonclick ;
      private string edtConfiguracaoNotificacoesEmail_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV27DynamicFiltersIgnoreFirst ;
      private bool AV26DynamicFiltersRemoving ;
      private bool bGXsfl_107_Refreshing=false ;
      private bool Dvpanel_tableheader_Autowidth ;
      private bool Dvpanel_tableheader_Autoheight ;
      private bool Dvpanel_tableheader_Collapsible ;
      private bool Dvpanel_tableheader_Collapsed ;
      private bool Dvpanel_tableheader_Showcollapseicon ;
      private bool Dvpanel_tableheader_Autoscroll ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n492ConfiguracaoNotificacoesEmail ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 ;
      private bool AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV32ManageFiltersXml ;
      private string AV14FilterFullText ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV17ConfiguracaoNotificacoesEmail1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV21ConfiguracaoNotificacoesEmail2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV25ConfiguracaoNotificacoesEmail3 ;
      private string AV34TFConfiguracaoNotificacoesEmail ;
      private string AV35TFConfiguracaoNotificacoesEmail_Sel ;
      private string AV40GridAppliedFilters ;
      private string A492ConfiguracaoNotificacoesEmail ;
      private string lV45Configuracaonotificacoeswwds_1_filterfulltext ;
      private string lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ;
      private string lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ;
      private string lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ;
      private string lV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ;
      private string AV45Configuracaonotificacoeswwds_1_filterfulltext ;
      private string AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 ;
      private string AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ;
      private string AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 ;
      private string AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ;
      private string AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 ;
      private string AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ;
      private string AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel ;
      private string AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private IGxSession AV30Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV31ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV36DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H006G2_A492ConfiguracaoNotificacoesEmail ;
      private bool[] H006G2_n492ConfiguracaoNotificacoesEmail ;
      private int[] H006G2_A491ConfiguracaoNotificacoesId ;
      private long[] H006G3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class configuracaonotificacoesww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H006G2( IGxContext context ,
                                             string AV45Configuracaonotificacoeswwds_1_filterfulltext ,
                                             string AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 ,
                                             short AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 ,
                                             string AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ,
                                             bool AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 ,
                                             string AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 ,
                                             short AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 ,
                                             string AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ,
                                             bool AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 ,
                                             string AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 ,
                                             short AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 ,
                                             string AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ,
                                             string AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel ,
                                             string AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ,
                                             string A492ConfiguracaoNotificacoesEmail ,
                                             bool AV13OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ConfiguracaoNotificacoesEmail, ConfiguracaoNotificacoesId";
         sFromString = " FROM ConfiguracaoNotificacoes";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Configuracaonotificacoeswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ConfiguracaoNotificacoesEmail like '%' || :lV45Configuracaonotificacoeswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like '%' || :lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like '%' || :lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesema)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like '%' || :lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesema)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoese)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel)) && ! ( StringUtil.StrCmp(AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail = ( :AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoese))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail IS NULL or (char_length(trim(trailing ' ' from ConfiguracaoNotificacoesEmail))=0))");
         }
         if ( ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY ConfiguracaoNotificacoesEmail, ConfiguracaoNotificacoesId";
         }
         else if ( AV13OrderedDsc )
         {
            sOrderString += " ORDER BY ConfiguracaoNotificacoesEmail DESC, ConfiguracaoNotificacoesId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY ConfiguracaoNotificacoesId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H006G3( IGxContext context ,
                                             string AV45Configuracaonotificacoeswwds_1_filterfulltext ,
                                             string AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1 ,
                                             short AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 ,
                                             string AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1 ,
                                             bool AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 ,
                                             string AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2 ,
                                             short AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 ,
                                             string AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2 ,
                                             bool AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 ,
                                             string AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3 ,
                                             short AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 ,
                                             string AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3 ,
                                             string AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel ,
                                             string AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail ,
                                             string A492ConfiguracaoNotificacoesEmail ,
                                             bool AV13OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[9];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ConfiguracaoNotificacoes";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Configuracaonotificacoeswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ConfiguracaoNotificacoesEmail like '%' || :lV45Configuracaonotificacoeswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV46Configuracaonotificacoeswwds_2_dynamicfiltersselector1, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV47Configuracaonotificacoeswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemail1)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like '%' || :lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV49Configuracaonotificacoeswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV50Configuracaonotificacoeswwds_6_dynamicfiltersselector2, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV51Configuracaonotificacoeswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemail2)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like '%' || :lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemai)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesema)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV53Configuracaonotificacoeswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV54Configuracaonotificacoeswwds_10_dynamicfiltersselector3, "CONFIGURACAONOTIFICACOESEMAIL") == 0 ) && ( AV55Configuracaonotificacoeswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracaonotificacoeswwds_12_configuracaonotificacoesemail3)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like '%' || :lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesema)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoesemail)) ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail like :lV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoese)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel)) && ! ( StringUtil.StrCmp(AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail = ( :AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoese))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ConfiguracaoNotificacoesEmail IS NULL or (char_length(trim(trailing ' ' from ConfiguracaoNotificacoesEmail))=0))");
         }
         scmdbuf += sWhereString;
         if ( ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H006G2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] );
               case 1 :
                     return conditional_H006G3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH006G2;
          prmH006G2 = new Object[] {
          new ParDef("lV45Configuracaonotificacoeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesema",GXType.VarChar,100,0) ,
          new ParDef("lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesema",GXType.VarChar,100,0) ,
          new ParDef("lV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoese",GXType.VarChar,100,0) ,
          new ParDef("AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoese",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH006G3;
          prmH006G3 = new Object[] {
          new ParDef("lV45Configuracaonotificacoeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV48Configuracaonotificacoeswwds_4_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV52Configuracaonotificacoeswwds_8_configuracaonotificacoesemai",GXType.VarChar,100,0) ,
          new ParDef("lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesema",GXType.VarChar,100,0) ,
          new ParDef("lV56Configuracaonotificacoeswwds_12_configuracaonotificacoesema",GXType.VarChar,100,0) ,
          new ParDef("lV57Configuracaonotificacoeswwds_13_tfconfiguracaonotificacoese",GXType.VarChar,100,0) ,
          new ParDef("AV58Configuracaonotificacoeswwds_14_tfconfiguracaonotificacoese",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006G2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006G3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
