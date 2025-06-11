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
   public class wcreembolsoflowlog : GXWebComponent
   {
      public wcreembolsoflowlog( )
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

      public wcreembolsoflowlog( IGxContext context )
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
         cmbLogReembolsoStatusAtual_F = new GXCombobox();
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
         nRC_GXsfl_119 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_119"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_119_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_119_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_119_idx = GetPar( "sGXsfl_119_idx");
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV18LogWorkflowConvenioDesc1 = GetPar( "LogWorkflowConvenioDesc1");
         AV19ReembolsoFlowLogUserNome1 = GetPar( "ReembolsoFlowLogUserNome1");
         AV94ReembolsoPaciente1 = GetPar( "ReembolsoPaciente1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV23LogWorkflowConvenioDesc2 = GetPar( "LogWorkflowConvenioDesc2");
         AV24ReembolsoFlowLogUserNome2 = GetPar( "ReembolsoFlowLogUserNome2");
         AV95ReembolsoPaciente2 = GetPar( "ReembolsoPaciente2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV28LogWorkflowConvenioDesc3 = GetPar( "LogWorkflowConvenioDesc3");
         AV29ReembolsoFlowLogUserNome3 = GetPar( "ReembolsoFlowLogUserNome3");
         AV96ReembolsoPaciente3 = GetPar( "ReembolsoPaciente3");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6WWPContext);
         AV37ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV97Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV90TFReembolsoPropostaPacienteClienteRazaoSocial = GetPar( "TFReembolsoPropostaPacienteClienteRazaoSocial");
         AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = GetPar( "TFReembolsoPropostaPacienteClienteRazaoSocial_Sel");
         AV42TFLogWorkflowConvenioDesc = GetPar( "TFLogWorkflowConvenioDesc");
         AV43TFLogWorkflowConvenioDesc_Sel = GetPar( "TFLogWorkflowConvenioDesc_Sel");
         AV48TFReembolsoFlowLogDate = context.localUtil.ParseDTimeParm( GetPar( "TFReembolsoFlowLogDate"));
         AV49TFReembolsoFlowLogDate_To = context.localUtil.ParseDTimeParm( GetPar( "TFReembolsoFlowLogDate_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV83TFLogReembolsoStatusAtual_F_Sels);
         AV63TFReembolsoFlowLogDataSLA_F = context.localUtil.ParseDTimeParm( GetPar( "TFReembolsoFlowLogDataSLA_F"));
         AV64TFReembolsoFlowLogDataSLA_F_To = context.localUtil.ParseDTimeParm( GetPar( "TFReembolsoFlowLogDataSLA_F_To"));
         AV84TFReembolsoLogProtocolo = GetPar( "TFReembolsoLogProtocolo");
         AV85TFReembolsoLogProtocolo_Sel = GetPar( "TFReembolsoLogProtocolo_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV31DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV30DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18LogWorkflowConvenioDesc1, AV19ReembolsoFlowLogUserNome1, AV94ReembolsoPaciente1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23LogWorkflowConvenioDesc2, AV24ReembolsoFlowLogUserNome2, AV95ReembolsoPaciente2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LogWorkflowConvenioDesc3, AV29ReembolsoFlowLogUserNome3, AV96ReembolsoPaciente3, AV6WWPContext, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV97Pgmname, AV15FilterFullText, AV90TFReembolsoPropostaPacienteClienteRazaoSocial, AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV42TFLogWorkflowConvenioDesc, AV43TFLogWorkflowConvenioDesc_Sel, AV48TFReembolsoFlowLogDate, AV49TFReembolsoFlowLogDate_To, AV83TFLogReembolsoStatusAtual_F_Sels, AV63TFReembolsoFlowLogDataSLA_F, AV64TFReembolsoFlowLogDataSLA_F_To, AV84TFReembolsoLogProtocolo, AV85TFReembolsoLogProtocolo_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
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
            PA802( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV97Pgmname = "WcReembolsoFlowLog";
               edtavReembolso_Enabled = 0;
               AssignProp(sPrefix, false, edtavReembolso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolso_Enabled), 5, 0), !bGXsfl_119_Refreshing);
               edtavConsulta_Enabled = 0;
               AssignProp(sPrefix, false, edtavConsulta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConsulta_Enabled), 5, 0), !bGXsfl_119_Refreshing);
               WS802( ) ;
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
            context.SendWebValue( " Reembolso Flow Log") ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 133260), false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcreembolsoflowlog") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV97Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV97Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV6WWPContext, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vLOGWORKFLOWCONVENIODESC1", AV18LogWorkflowConvenioDesc1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vREEMBOLSOFLOWLOGUSERNOME1", AV19ReembolsoFlowLogUserNome1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vREEMBOLSOPACIENTE1", AV94ReembolsoPaciente1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vLOGWORKFLOWCONVENIODESC2", AV23LogWorkflowConvenioDesc2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vREEMBOLSOFLOWLOGUSERNOME2", AV24ReembolsoFlowLogUserNome2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vREEMBOLSOPACIENTE2", AV95ReembolsoPaciente2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vLOGWORKFLOWCONVENIODESC3", AV28LogWorkflowConvenioDesc3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vREEMBOLSOFLOWLOGUSERNOME3", AV29ReembolsoFlowLogUserNome3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vREEMBOLSOPACIENTE3", AV96ReembolsoPaciente3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_119", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_119), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV75GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV76GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV77GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV73DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV73DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_REEMBOLSOFLOWLOGDATEAUXDATE", context.localUtil.DToC( AV50DDO_ReembolsoFlowLogDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_REEMBOLSOFLOWLOGDATEAUXDATETO", context.localUtil.DToC( AV51DDO_ReembolsoFlowLogDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_REEMBOLSOFLOWLOGDATASLA_FAUXDATE", context.localUtil.DToC( AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_REEMBOLSOFLOWLOGDATASLA_FAUXDATETO", context.localUtil.DToC( AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV97Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV97Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", AV90TFReembolsoPropostaPacienteClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL", AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLOGWORKFLOWCONVENIODESC", AV42TFLogWorkflowConvenioDesc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLOGWORKFLOWCONVENIODESC_SEL", AV43TFLogWorkflowConvenioDesc_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOFLOWLOGDATE", context.localUtil.TToC( AV48TFReembolsoFlowLogDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOFLOWLOGDATE_TO", context.localUtil.TToC( AV49TFReembolsoFlowLogDate_To, 10, 8, 0, 0, "/", ":", " "));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS", AV83TFLogReembolsoStatusAtual_F_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS", AV83TFLogReembolsoStatusAtual_F_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOFLOWLOGDATASLA_F", context.localUtil.TToC( AV63TFReembolsoFlowLogDataSLA_F, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOFLOWLOGDATASLA_F_TO", context.localUtil.TToC( AV64TFReembolsoFlowLogDataSLA_F_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOLOGPROTOCOLO", AV84TFReembolsoLogProtocolo);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOLOGPROTOCOLO_SEL", AV85TFReembolsoLogProtocolo_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSIGNOREFIRST", AV31DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSREMOVING", AV30DynamicFiltersRemoving);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV6WWPContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"REEMBOLSOPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"REEMBOLSOSTATUSATUAL_F", A548ReembolsoStatusAtual_F);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLOGREEMBOLSOSTATUSATUAL_F_SELSJSON", AV82TFLogReembolsoStatusAtual_F_SelsJson);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm802( )
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
         return "WcReembolsoFlowLog" ;
      }

      public override string GetPgmdesc( )
      {
         return " Reembolso Flow Log" ;
      }

      protected void WB800( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcreembolsoflowlog");
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
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV35ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WcReembolsoFlowLog.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_WcReembolsoFlowLog.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_39_802( true) ;
         }
         else
         {
            wb_table1_39_802( false) ;
         }
         return  ;
      }

      protected void wb_table1_39_802e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 0, "HLP_WcReembolsoFlowLog.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_67_802( true) ;
         }
         else
         {
            wb_table2_67_802( false) ;
         }
         return  ;
      }

      protected void wb_table2_67_802e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_WcReembolsoFlowLog.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_95_802( true) ;
         }
         else
         {
            wb_table3_95_802( false) ;
         }
         return  ;
      }

      protected void wb_table3_95_802e( bool wbgen )
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
            StartGridControl119( ) ;
         }
         if ( wbEnd == 119 )
         {
            wbEnd = 0;
            nRC_GXsfl_119 = (int)(nGXsfl_119_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV75GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV76GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV77GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WcReembolsoFlowLog.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV73DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_reembolsoflowlogdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_reembolsoflowlogdateauxdatetext_Internalname, AV52DDO_ReembolsoFlowLogDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV52DDO_ReembolsoFlowLogDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_reembolsoflowlogdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcReembolsoFlowLog.htm");
            /* User Defined Control */
            ucTfreembolsoflowlogdate_rangepicker.SetProperty("Start Date", AV50DDO_ReembolsoFlowLogDateAuxDate);
            ucTfreembolsoflowlogdate_rangepicker.SetProperty("End Date", AV51DDO_ReembolsoFlowLogDateAuxDateTo);
            ucTfreembolsoflowlogdate_rangepicker.Render(context, "wwp.daterangepicker", Tfreembolsoflowlogdate_rangepicker_Internalname, sPrefix+"TFREEMBOLSOFLOWLOGDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_reembolsoflowlogdatasla_fauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_reembolsoflowlogdatasla_fauxdatetext_Internalname, AV67DDO_ReembolsoFlowLogDataSLA_FAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV67DDO_ReembolsoFlowLogDataSLA_FAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_reembolsoflowlogdatasla_fauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcReembolsoFlowLog.htm");
            /* User Defined Control */
            ucTfreembolsoflowlogdatasla_f_rangepicker.SetProperty("Start Date", AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate);
            ucTfreembolsoflowlogdatasla_f_rangepicker.SetProperty("End Date", AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo);
            ucTfreembolsoflowlogdatasla_f_rangepicker.Render(context, "wwp.daterangepicker", Tfreembolsoflowlogdatasla_f_rangepicker_Internalname, sPrefix+"TFREEMBOLSOFLOWLOGDATASLA_F_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 119 )
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

      protected void START802( )
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
            Form.Meta.addItem("description", " Reembolso Flow Log", 0) ;
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
               STRUP800( ) ;
            }
         }
      }

      protected void WS802( )
      {
         START802( ) ;
         EVT802( ) ;
      }

      protected void EVT802( )
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
                                 STRUP800( ) ;
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
                                 STRUP800( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11802 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP800( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12802 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP800( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13802 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP800( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E14802 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP800( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters1' */
                                    E15802 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP800( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters2' */
                                    E16802 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP800( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters3' */
                                    E17802 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP800( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters1' */
                                    E18802 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP800( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E19802 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP800( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters2' */
                                    E20802 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP800( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E21802 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP800( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E22802 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP800( ) ;
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
                                 STRUP800( ) ;
                              }
                              nGXsfl_119_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
                              SubsflControlProps_1192( ) ;
                              AV92Reembolso = cgiGet( edtavReembolso_Internalname);
                              AssignAttri(sPrefix, false, edtavReembolso_Internalname, AV92Reembolso);
                              AV93Consulta = cgiGet( edtavConsulta_Internalname);
                              AssignAttri(sPrefix, false, edtavConsulta_Internalname, AV93Consulta);
                              A550ReembolsoPropostaPacienteClienteRazaoSocial = StringUtil.Upper( cgiGet( edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname));
                              n550ReembolsoPropostaPacienteClienteRazaoSocial = false;
                              A746ReembolsoFlowLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoFlowLogId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A750LogWorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtLogWorkflowConvenioId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n750LogWorkflowConvenioId = false;
                              A752LogWorkflowConvenioDesc = cgiGet( edtLogWorkflowConvenioDesc_Internalname);
                              n752LogWorkflowConvenioDesc = false;
                              A747ReembolsoFlowLogDate = context.localUtil.CToT( cgiGet( edtReembolsoFlowLogDate_Internalname), 0);
                              n747ReembolsoFlowLogDate = false;
                              A744ReembolsoFlowLogUser = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoFlowLogUser_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n744ReembolsoFlowLogUser = false;
                              A745ReembolsoFlowLogUserNome = StringUtil.Upper( cgiGet( edtReembolsoFlowLogUserNome_Internalname));
                              n745ReembolsoFlowLogUserNome = false;
                              A748ReembolsoLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoLogId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n748ReembolsoLogId = false;
                              A749ReembolsoWorkFlowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoWorkFlowConvenioId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n749ReembolsoWorkFlowConvenioId = false;
                              A754ReembolsoWorkflowConvenioSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoWorkflowConvenioSLA_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n754ReembolsoWorkflowConvenioSLA = false;
                              cmbLogReembolsoStatusAtual_F.Name = cmbLogReembolsoStatusAtual_F_Internalname;
                              cmbLogReembolsoStatusAtual_F.CurrentValue = cgiGet( cmbLogReembolsoStatusAtual_F_Internalname);
                              A760LogReembolsoStatusAtual_F = cgiGet( cmbLogReembolsoStatusAtual_F_Internalname);
                              n760LogReembolsoStatusAtual_F = false;
                              A755ReembolsoFlowLogDataSLA_F = context.localUtil.CToT( cgiGet( edtReembolsoFlowLogDataSLA_F_Internalname), 0);
                              A763ReembolsoLogProtocolo = cgiGet( edtReembolsoLogProtocolo_Internalname);
                              n763ReembolsoLogProtocolo = false;
                              A761ReembolsoFlowLogDataFinal = context.localUtil.CToT( cgiGet( edtReembolsoFlowLogDataFinal_Internalname), 0);
                              n761ReembolsoFlowLogDataFinal = false;
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
                                          E23802 ();
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
                                          E24802 ();
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
                                          E25802 ();
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
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Logworkflowconveniodesc1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vLOGWORKFLOWCONVENIODESC1"), AV18LogWorkflowConvenioDesc1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Reembolsoflowlogusernome1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOFLOWLOGUSERNOME1"), AV19ReembolsoFlowLogUserNome1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Reembolsopaciente1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOPACIENTE1"), AV94ReembolsoPaciente1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Logworkflowconveniodesc2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vLOGWORKFLOWCONVENIODESC2"), AV23LogWorkflowConvenioDesc2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Reembolsoflowlogusernome2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOFLOWLOGUSERNOME2"), AV24ReembolsoFlowLogUserNome2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Reembolsopaciente2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOPACIENTE2"), AV95ReembolsoPaciente2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Logworkflowconveniodesc3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vLOGWORKFLOWCONVENIODESC3"), AV28LogWorkflowConvenioDesc3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Reembolsoflowlogusernome3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOFLOWLOGUSERNOME3"), AV29ReembolsoFlowLogUserNome3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Reembolsopaciente3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOPACIENTE3"), AV96ReembolsoPaciente3) != 0 )
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
                                       STRUP800( ) ;
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

      protected void WE802( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm802( ) ;
            }
         }
      }

      protected void PA802( )
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
         SubsflControlProps_1192( ) ;
         while ( nGXsfl_119_idx <= nRC_GXsfl_119 )
         {
            sendrow_1192( ) ;
            nGXsfl_119_idx = ((subGrid_Islastpage==1)&&(nGXsfl_119_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_119_idx+1);
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       string AV18LogWorkflowConvenioDesc1 ,
                                       string AV19ReembolsoFlowLogUserNome1 ,
                                       string AV94ReembolsoPaciente1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       string AV23LogWorkflowConvenioDesc2 ,
                                       string AV24ReembolsoFlowLogUserNome2 ,
                                       string AV95ReembolsoPaciente2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV28LogWorkflowConvenioDesc3 ,
                                       string AV29ReembolsoFlowLogUserNome3 ,
                                       string AV96ReembolsoPaciente3 ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ,
                                       short AV37ManageFiltersExecutionStep ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV97Pgmname ,
                                       string AV15FilterFullText ,
                                       string AV90TFReembolsoPropostaPacienteClienteRazaoSocial ,
                                       string AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel ,
                                       string AV42TFLogWorkflowConvenioDesc ,
                                       string AV43TFLogWorkflowConvenioDesc_Sel ,
                                       DateTime AV48TFReembolsoFlowLogDate ,
                                       DateTime AV49TFReembolsoFlowLogDate_To ,
                                       GxSimpleCollection<string> AV83TFLogReembolsoStatusAtual_F_Sels ,
                                       DateTime AV63TFReembolsoFlowLogDataSLA_F ,
                                       DateTime AV64TFReembolsoFlowLogDataSLA_F_To ,
                                       string AV84TFReembolsoLogProtocolo ,
                                       string AV85TFReembolsoLogProtocolo_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV31DynamicFiltersIgnoreFirst ,
                                       bool AV30DynamicFiltersRemoving ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF802( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF802( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV97Pgmname = "WcReembolsoFlowLog";
         edtavReembolso_Enabled = 0;
         edtavConsulta_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV98Wcreembolsoflowlogds_1_filterfulltext = AV15FilterFullText;
         AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = AV18LogWorkflowConvenioDesc1;
         AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = AV19ReembolsoFlowLogUserNome1;
         AV103Wcreembolsoflowlogds_6_reembolsopaciente1 = AV94ReembolsoPaciente1;
         AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = AV23LogWorkflowConvenioDesc2;
         AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = AV24ReembolsoFlowLogUserNome2;
         AV109Wcreembolsoflowlogds_12_reembolsopaciente2 = AV95ReembolsoPaciente2;
         AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = AV28LogWorkflowConvenioDesc3;
         AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = AV29ReembolsoFlowLogUserNome3;
         AV115Wcreembolsoflowlogds_18_reembolsopaciente3 = AV96ReembolsoPaciente3;
         AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = AV90TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel = AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = AV42TFLogWorkflowConvenioDesc;
         AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel = AV43TFLogWorkflowConvenioDesc_Sel;
         AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate = AV48TFReembolsoFlowLogDate;
         AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to = AV49TFReembolsoFlowLogDate_To;
         AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels = AV83TFLogReembolsoStatusAtual_F_Sels;
         AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f = AV63TFReembolsoFlowLogDataSLA_F;
         AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to = AV64TFReembolsoFlowLogDataSLA_F_To;
         AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo = AV84TFReembolsoLogProtocolo;
         AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel = AV85TFReembolsoLogProtocolo_Sel;
         GRID_nRecordCount = 0;
         GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
         GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A760LogReembolsoStatusAtual_F ,
                                              AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels ,
                                              AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 ,
                                              AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 ,
                                              AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ,
                                              AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ,
                                              AV103Wcreembolsoflowlogds_6_reembolsopaciente1 ,
                                              AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 ,
                                              AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 ,
                                              AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 ,
                                              AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ,
                                              AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ,
                                              AV109Wcreembolsoflowlogds_12_reembolsopaciente2 ,
                                              AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 ,
                                              AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 ,
                                              AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 ,
                                              AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ,
                                              AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ,
                                              AV115Wcreembolsoflowlogds_18_reembolsopaciente3 ,
                                              AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                              AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ,
                                              AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel ,
                                              AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ,
                                              AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate ,
                                              AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to ,
                                              AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f ,
                                              AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to ,
                                              AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel ,
                                              AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo ,
                                              AV6WWPContext.gxTpr_Secuserclienteid ,
                                              A752LogWorkflowConvenioDesc ,
                                              A745ReembolsoFlowLogUserNome ,
                                              A764ReembolsoPaciente ,
                                              A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                              A747ReembolsoFlowLogDate ,
                                              A754ReembolsoWorkflowConvenioSLA ,
                                              A763ReembolsoLogProtocolo ,
                                              A758ReembolsoPropostaClinicaId ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV98Wcreembolsoflowlogds_1_filterfulltext ,
                                              AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels.Count ,
                                              A755ReembolsoFlowLogDataSLA_F ,
                                              A749ReembolsoWorkFlowConvenioId ,
                                              A750LogWorkflowConvenioId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
         lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1), "%", "");
         lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1), "%", "");
         lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1), "%", "");
         lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1), "%", "");
         lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2), "%", "");
         lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2), "%", "");
         lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = StringUtil.Concat( StringUtil.RTrim( AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2), "%", "");
         lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = StringUtil.Concat( StringUtil.RTrim( AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2), "%", "");
         lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3), "%", "");
         lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3), "%", "");
         lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = StringUtil.Concat( StringUtil.RTrim( AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3), "%", "");
         lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = StringUtil.Concat( StringUtil.RTrim( AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3), "%", "");
         lV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial), "%", "");
         lV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc), "%", "");
         lV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo = StringUtil.Concat( StringUtil.RTrim( AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo), "%", "");
         /* Using cursor H00804 */
         pr_default.execute(0, new Object[] {AV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels.Count, lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1, lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1, lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1, lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1, lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2, lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2, lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2, lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2, lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3, lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3, lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3, lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3, lV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial, AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, lV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc, AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate, AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to, AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f, AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to, lV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo, AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, AV6WWPContext.gxTpr_Secuserclienteid, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A558ReembolsoPropostaPacienteClienteId = H00804_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = H00804_n558ReembolsoPropostaPacienteClienteId[0];
            A758ReembolsoPropostaClinicaId = H00804_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = H00804_n758ReembolsoPropostaClinicaId[0];
            A542ReembolsoPropostaId = H00804_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = H00804_n542ReembolsoPropostaId[0];
            A761ReembolsoFlowLogDataFinal = H00804_A761ReembolsoFlowLogDataFinal[0];
            n761ReembolsoFlowLogDataFinal = H00804_n761ReembolsoFlowLogDataFinal[0];
            A763ReembolsoLogProtocolo = H00804_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = H00804_n763ReembolsoLogProtocolo[0];
            A755ReembolsoFlowLogDataSLA_F = H00804_A755ReembolsoFlowLogDataSLA_F[0];
            A749ReembolsoWorkFlowConvenioId = H00804_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = H00804_n749ReembolsoWorkFlowConvenioId[0];
            A748ReembolsoLogId = H00804_A748ReembolsoLogId[0];
            n748ReembolsoLogId = H00804_n748ReembolsoLogId[0];
            A745ReembolsoFlowLogUserNome = H00804_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = H00804_n745ReembolsoFlowLogUserNome[0];
            A744ReembolsoFlowLogUser = H00804_A744ReembolsoFlowLogUser[0];
            n744ReembolsoFlowLogUser = H00804_n744ReembolsoFlowLogUser[0];
            A752LogWorkflowConvenioDesc = H00804_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = H00804_n752LogWorkflowConvenioDesc[0];
            A750LogWorkflowConvenioId = H00804_A750LogWorkflowConvenioId[0];
            n750LogWorkflowConvenioId = H00804_n750LogWorkflowConvenioId[0];
            A746ReembolsoFlowLogId = H00804_A746ReembolsoFlowLogId[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = H00804_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = H00804_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A747ReembolsoFlowLogDate = H00804_A747ReembolsoFlowLogDate[0];
            n747ReembolsoFlowLogDate = H00804_n747ReembolsoFlowLogDate[0];
            A754ReembolsoWorkflowConvenioSLA = H00804_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = H00804_n754ReembolsoWorkflowConvenioSLA[0];
            A760LogReembolsoStatusAtual_F = H00804_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = H00804_n760LogReembolsoStatusAtual_F[0];
            A542ReembolsoPropostaId = H00804_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = H00804_n542ReembolsoPropostaId[0];
            A763ReembolsoLogProtocolo = H00804_A763ReembolsoLogProtocolo[0];
            n763ReembolsoLogProtocolo = H00804_n763ReembolsoLogProtocolo[0];
            A749ReembolsoWorkFlowConvenioId = H00804_A749ReembolsoWorkFlowConvenioId[0];
            n749ReembolsoWorkFlowConvenioId = H00804_n749ReembolsoWorkFlowConvenioId[0];
            A558ReembolsoPropostaPacienteClienteId = H00804_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = H00804_n558ReembolsoPropostaPacienteClienteId[0];
            A758ReembolsoPropostaClinicaId = H00804_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = H00804_n758ReembolsoPropostaClinicaId[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = H00804_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = H00804_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A754ReembolsoWorkflowConvenioSLA = H00804_A754ReembolsoWorkflowConvenioSLA[0];
            n754ReembolsoWorkflowConvenioSLA = H00804_n754ReembolsoWorkflowConvenioSLA[0];
            A760LogReembolsoStatusAtual_F = H00804_A760LogReembolsoStatusAtual_F[0];
            n760LogReembolsoStatusAtual_F = H00804_n760LogReembolsoStatusAtual_F[0];
            A745ReembolsoFlowLogUserNome = H00804_A745ReembolsoFlowLogUserNome[0];
            n745ReembolsoFlowLogUserNome = H00804_n745ReembolsoFlowLogUserNome[0];
            A752LogWorkflowConvenioDesc = H00804_A752LogWorkflowConvenioDesc[0];
            n752LogWorkflowConvenioDesc = H00804_n752LogWorkflowConvenioDesc[0];
            GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF802( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 119;
         /* Execute user event: Refresh */
         E24802 ();
         nGXsfl_119_idx = 1;
         sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
         SubsflControlProps_1192( ) ;
         bGXsfl_119_Refreshing = true;
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
            SubsflControlProps_1192( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A760LogReembolsoStatusAtual_F ,
                                                 AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels ,
                                                 AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 ,
                                                 AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 ,
                                                 AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ,
                                                 AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ,
                                                 AV103Wcreembolsoflowlogds_6_reembolsopaciente1 ,
                                                 AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 ,
                                                 AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 ,
                                                 AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 ,
                                                 AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ,
                                                 AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ,
                                                 AV109Wcreembolsoflowlogds_12_reembolsopaciente2 ,
                                                 AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 ,
                                                 AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 ,
                                                 AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 ,
                                                 AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ,
                                                 AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ,
                                                 AV115Wcreembolsoflowlogds_18_reembolsopaciente3 ,
                                                 AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                                 AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ,
                                                 AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel ,
                                                 AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ,
                                                 AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate ,
                                                 AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to ,
                                                 AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f ,
                                                 AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to ,
                                                 AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel ,
                                                 AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo ,
                                                 AV6WWPContext.gxTpr_Secuserclienteid ,
                                                 A752LogWorkflowConvenioDesc ,
                                                 A745ReembolsoFlowLogUserNome ,
                                                 A764ReembolsoPaciente ,
                                                 A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                                 A747ReembolsoFlowLogDate ,
                                                 A754ReembolsoWorkflowConvenioSLA ,
                                                 A763ReembolsoLogProtocolo ,
                                                 A758ReembolsoPropostaClinicaId ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV98Wcreembolsoflowlogds_1_filterfulltext ,
                                                 AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels.Count ,
                                                 A755ReembolsoFlowLogDataSLA_F ,
                                                 A749ReembolsoWorkFlowConvenioId ,
                                                 A750LogWorkflowConvenioId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                                 }
            });
            lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
            lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
            lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
            lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
            lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
            lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
            lV98Wcreembolsoflowlogds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV98Wcreembolsoflowlogds_1_filterfulltext), "%", "");
            lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1), "%", "");
            lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1), "%", "");
            lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1), "%", "");
            lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1), "%", "");
            lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2), "%", "");
            lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2), "%", "");
            lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = StringUtil.Concat( StringUtil.RTrim( AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2), "%", "");
            lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = StringUtil.Concat( StringUtil.RTrim( AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2), "%", "");
            lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3), "%", "");
            lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3), "%", "");
            lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = StringUtil.Concat( StringUtil.RTrim( AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3), "%", "");
            lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = StringUtil.Concat( StringUtil.RTrim( AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3), "%", "");
            lV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial), "%", "");
            lV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc), "%", "");
            lV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo = StringUtil.Concat( StringUtil.RTrim( AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo), "%", "");
            /* Using cursor H00807 */
            pr_default.execute(1, new Object[] {AV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, lV98Wcreembolsoflowlogds_1_filterfulltext, AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels.Count, lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1, lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1, lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1, lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1, lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2, lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2, lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2, lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2, lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3, lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3, lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3, lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3, lV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial, AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, lV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc, AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate, AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to, AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f, AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to, lV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo, AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, AV6WWPContext.gxTpr_Secuserclienteid, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_119_idx = 1;
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A558ReembolsoPropostaPacienteClienteId = H00807_A558ReembolsoPropostaPacienteClienteId[0];
               n558ReembolsoPropostaPacienteClienteId = H00807_n558ReembolsoPropostaPacienteClienteId[0];
               A758ReembolsoPropostaClinicaId = H00807_A758ReembolsoPropostaClinicaId[0];
               n758ReembolsoPropostaClinicaId = H00807_n758ReembolsoPropostaClinicaId[0];
               A542ReembolsoPropostaId = H00807_A542ReembolsoPropostaId[0];
               n542ReembolsoPropostaId = H00807_n542ReembolsoPropostaId[0];
               A761ReembolsoFlowLogDataFinal = H00807_A761ReembolsoFlowLogDataFinal[0];
               n761ReembolsoFlowLogDataFinal = H00807_n761ReembolsoFlowLogDataFinal[0];
               A763ReembolsoLogProtocolo = H00807_A763ReembolsoLogProtocolo[0];
               n763ReembolsoLogProtocolo = H00807_n763ReembolsoLogProtocolo[0];
               A755ReembolsoFlowLogDataSLA_F = H00807_A755ReembolsoFlowLogDataSLA_F[0];
               A749ReembolsoWorkFlowConvenioId = H00807_A749ReembolsoWorkFlowConvenioId[0];
               n749ReembolsoWorkFlowConvenioId = H00807_n749ReembolsoWorkFlowConvenioId[0];
               A748ReembolsoLogId = H00807_A748ReembolsoLogId[0];
               n748ReembolsoLogId = H00807_n748ReembolsoLogId[0];
               A745ReembolsoFlowLogUserNome = H00807_A745ReembolsoFlowLogUserNome[0];
               n745ReembolsoFlowLogUserNome = H00807_n745ReembolsoFlowLogUserNome[0];
               A744ReembolsoFlowLogUser = H00807_A744ReembolsoFlowLogUser[0];
               n744ReembolsoFlowLogUser = H00807_n744ReembolsoFlowLogUser[0];
               A752LogWorkflowConvenioDesc = H00807_A752LogWorkflowConvenioDesc[0];
               n752LogWorkflowConvenioDesc = H00807_n752LogWorkflowConvenioDesc[0];
               A750LogWorkflowConvenioId = H00807_A750LogWorkflowConvenioId[0];
               n750LogWorkflowConvenioId = H00807_n750LogWorkflowConvenioId[0];
               A746ReembolsoFlowLogId = H00807_A746ReembolsoFlowLogId[0];
               A550ReembolsoPropostaPacienteClienteRazaoSocial = H00807_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               n550ReembolsoPropostaPacienteClienteRazaoSocial = H00807_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               A747ReembolsoFlowLogDate = H00807_A747ReembolsoFlowLogDate[0];
               n747ReembolsoFlowLogDate = H00807_n747ReembolsoFlowLogDate[0];
               A754ReembolsoWorkflowConvenioSLA = H00807_A754ReembolsoWorkflowConvenioSLA[0];
               n754ReembolsoWorkflowConvenioSLA = H00807_n754ReembolsoWorkflowConvenioSLA[0];
               A760LogReembolsoStatusAtual_F = H00807_A760LogReembolsoStatusAtual_F[0];
               n760LogReembolsoStatusAtual_F = H00807_n760LogReembolsoStatusAtual_F[0];
               A542ReembolsoPropostaId = H00807_A542ReembolsoPropostaId[0];
               n542ReembolsoPropostaId = H00807_n542ReembolsoPropostaId[0];
               A763ReembolsoLogProtocolo = H00807_A763ReembolsoLogProtocolo[0];
               n763ReembolsoLogProtocolo = H00807_n763ReembolsoLogProtocolo[0];
               A749ReembolsoWorkFlowConvenioId = H00807_A749ReembolsoWorkFlowConvenioId[0];
               n749ReembolsoWorkFlowConvenioId = H00807_n749ReembolsoWorkFlowConvenioId[0];
               A558ReembolsoPropostaPacienteClienteId = H00807_A558ReembolsoPropostaPacienteClienteId[0];
               n558ReembolsoPropostaPacienteClienteId = H00807_n558ReembolsoPropostaPacienteClienteId[0];
               A758ReembolsoPropostaClinicaId = H00807_A758ReembolsoPropostaClinicaId[0];
               n758ReembolsoPropostaClinicaId = H00807_n758ReembolsoPropostaClinicaId[0];
               A550ReembolsoPropostaPacienteClienteRazaoSocial = H00807_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               n550ReembolsoPropostaPacienteClienteRazaoSocial = H00807_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               A754ReembolsoWorkflowConvenioSLA = H00807_A754ReembolsoWorkflowConvenioSLA[0];
               n754ReembolsoWorkflowConvenioSLA = H00807_n754ReembolsoWorkflowConvenioSLA[0];
               A760LogReembolsoStatusAtual_F = H00807_A760LogReembolsoStatusAtual_F[0];
               n760LogReembolsoStatusAtual_F = H00807_n760LogReembolsoStatusAtual_F[0];
               A745ReembolsoFlowLogUserNome = H00807_A745ReembolsoFlowLogUserNome[0];
               n745ReembolsoFlowLogUserNome = H00807_n745ReembolsoFlowLogUserNome[0];
               A752LogWorkflowConvenioDesc = H00807_A752LogWorkflowConvenioDesc[0];
               n752LogWorkflowConvenioDesc = H00807_n752LogWorkflowConvenioDesc[0];
               /* Execute user event: Grid.Load */
               E25802 ();
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 119;
            WB800( ) ;
         }
         bGXsfl_119_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes802( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV97Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV97Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPCONTEXT", GetSecureSignedToken( sPrefix, AV6WWPContext, context));
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
         return (int)(subGridclient_rec_count_fnc()) ;
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
         AV98Wcreembolsoflowlogds_1_filterfulltext = AV15FilterFullText;
         AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = AV18LogWorkflowConvenioDesc1;
         AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = AV19ReembolsoFlowLogUserNome1;
         AV103Wcreembolsoflowlogds_6_reembolsopaciente1 = AV94ReembolsoPaciente1;
         AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = AV23LogWorkflowConvenioDesc2;
         AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = AV24ReembolsoFlowLogUserNome2;
         AV109Wcreembolsoflowlogds_12_reembolsopaciente2 = AV95ReembolsoPaciente2;
         AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = AV28LogWorkflowConvenioDesc3;
         AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = AV29ReembolsoFlowLogUserNome3;
         AV115Wcreembolsoflowlogds_18_reembolsopaciente3 = AV96ReembolsoPaciente3;
         AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = AV90TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel = AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = AV42TFLogWorkflowConvenioDesc;
         AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel = AV43TFLogWorkflowConvenioDesc_Sel;
         AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate = AV48TFReembolsoFlowLogDate;
         AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to = AV49TFReembolsoFlowLogDate_To;
         AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels = AV83TFLogReembolsoStatusAtual_F_Sels;
         AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f = AV63TFReembolsoFlowLogDataSLA_F;
         AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to = AV64TFReembolsoFlowLogDataSLA_F_To;
         AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo = AV84TFReembolsoLogProtocolo;
         AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel = AV85TFReembolsoLogProtocolo_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18LogWorkflowConvenioDesc1, AV19ReembolsoFlowLogUserNome1, AV94ReembolsoPaciente1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23LogWorkflowConvenioDesc2, AV24ReembolsoFlowLogUserNome2, AV95ReembolsoPaciente2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LogWorkflowConvenioDesc3, AV29ReembolsoFlowLogUserNome3, AV96ReembolsoPaciente3, AV6WWPContext, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV97Pgmname, AV15FilterFullText, AV90TFReembolsoPropostaPacienteClienteRazaoSocial, AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV42TFLogWorkflowConvenioDesc, AV43TFLogWorkflowConvenioDesc_Sel, AV48TFReembolsoFlowLogDate, AV49TFReembolsoFlowLogDate_To, AV83TFLogReembolsoStatusAtual_F_Sels, AV63TFReembolsoFlowLogDataSLA_F, AV64TFReembolsoFlowLogDataSLA_F_To, AV84TFReembolsoLogProtocolo, AV85TFReembolsoLogProtocolo_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV98Wcreembolsoflowlogds_1_filterfulltext = AV15FilterFullText;
         AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = AV18LogWorkflowConvenioDesc1;
         AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = AV19ReembolsoFlowLogUserNome1;
         AV103Wcreembolsoflowlogds_6_reembolsopaciente1 = AV94ReembolsoPaciente1;
         AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = AV23LogWorkflowConvenioDesc2;
         AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = AV24ReembolsoFlowLogUserNome2;
         AV109Wcreembolsoflowlogds_12_reembolsopaciente2 = AV95ReembolsoPaciente2;
         AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = AV28LogWorkflowConvenioDesc3;
         AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = AV29ReembolsoFlowLogUserNome3;
         AV115Wcreembolsoflowlogds_18_reembolsopaciente3 = AV96ReembolsoPaciente3;
         AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = AV90TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel = AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = AV42TFLogWorkflowConvenioDesc;
         AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel = AV43TFLogWorkflowConvenioDesc_Sel;
         AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate = AV48TFReembolsoFlowLogDate;
         AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to = AV49TFReembolsoFlowLogDate_To;
         AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels = AV83TFLogReembolsoStatusAtual_F_Sels;
         AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f = AV63TFReembolsoFlowLogDataSLA_F;
         AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to = AV64TFReembolsoFlowLogDataSLA_F_To;
         AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo = AV84TFReembolsoLogProtocolo;
         AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel = AV85TFReembolsoLogProtocolo_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18LogWorkflowConvenioDesc1, AV19ReembolsoFlowLogUserNome1, AV94ReembolsoPaciente1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23LogWorkflowConvenioDesc2, AV24ReembolsoFlowLogUserNome2, AV95ReembolsoPaciente2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LogWorkflowConvenioDesc3, AV29ReembolsoFlowLogUserNome3, AV96ReembolsoPaciente3, AV6WWPContext, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV97Pgmname, AV15FilterFullText, AV90TFReembolsoPropostaPacienteClienteRazaoSocial, AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV42TFLogWorkflowConvenioDesc, AV43TFLogWorkflowConvenioDesc_Sel, AV48TFReembolsoFlowLogDate, AV49TFReembolsoFlowLogDate_To, AV83TFLogReembolsoStatusAtual_F_Sels, AV63TFReembolsoFlowLogDataSLA_F, AV64TFReembolsoFlowLogDataSLA_F_To, AV84TFReembolsoLogProtocolo, AV85TFReembolsoLogProtocolo_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV98Wcreembolsoflowlogds_1_filterfulltext = AV15FilterFullText;
         AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = AV18LogWorkflowConvenioDesc1;
         AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = AV19ReembolsoFlowLogUserNome1;
         AV103Wcreembolsoflowlogds_6_reembolsopaciente1 = AV94ReembolsoPaciente1;
         AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = AV23LogWorkflowConvenioDesc2;
         AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = AV24ReembolsoFlowLogUserNome2;
         AV109Wcreembolsoflowlogds_12_reembolsopaciente2 = AV95ReembolsoPaciente2;
         AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = AV28LogWorkflowConvenioDesc3;
         AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = AV29ReembolsoFlowLogUserNome3;
         AV115Wcreembolsoflowlogds_18_reembolsopaciente3 = AV96ReembolsoPaciente3;
         AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = AV90TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel = AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = AV42TFLogWorkflowConvenioDesc;
         AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel = AV43TFLogWorkflowConvenioDesc_Sel;
         AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate = AV48TFReembolsoFlowLogDate;
         AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to = AV49TFReembolsoFlowLogDate_To;
         AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels = AV83TFLogReembolsoStatusAtual_F_Sels;
         AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f = AV63TFReembolsoFlowLogDataSLA_F;
         AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to = AV64TFReembolsoFlowLogDataSLA_F_To;
         AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo = AV84TFReembolsoLogProtocolo;
         AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel = AV85TFReembolsoLogProtocolo_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18LogWorkflowConvenioDesc1, AV19ReembolsoFlowLogUserNome1, AV94ReembolsoPaciente1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23LogWorkflowConvenioDesc2, AV24ReembolsoFlowLogUserNome2, AV95ReembolsoPaciente2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LogWorkflowConvenioDesc3, AV29ReembolsoFlowLogUserNome3, AV96ReembolsoPaciente3, AV6WWPContext, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV97Pgmname, AV15FilterFullText, AV90TFReembolsoPropostaPacienteClienteRazaoSocial, AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV42TFLogWorkflowConvenioDesc, AV43TFLogWorkflowConvenioDesc_Sel, AV48TFReembolsoFlowLogDate, AV49TFReembolsoFlowLogDate_To, AV83TFLogReembolsoStatusAtual_F_Sels, AV63TFReembolsoFlowLogDataSLA_F, AV64TFReembolsoFlowLogDataSLA_F_To, AV84TFReembolsoLogProtocolo, AV85TFReembolsoLogProtocolo_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV98Wcreembolsoflowlogds_1_filterfulltext = AV15FilterFullText;
         AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = AV18LogWorkflowConvenioDesc1;
         AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = AV19ReembolsoFlowLogUserNome1;
         AV103Wcreembolsoflowlogds_6_reembolsopaciente1 = AV94ReembolsoPaciente1;
         AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = AV23LogWorkflowConvenioDesc2;
         AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = AV24ReembolsoFlowLogUserNome2;
         AV109Wcreembolsoflowlogds_12_reembolsopaciente2 = AV95ReembolsoPaciente2;
         AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = AV28LogWorkflowConvenioDesc3;
         AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = AV29ReembolsoFlowLogUserNome3;
         AV115Wcreembolsoflowlogds_18_reembolsopaciente3 = AV96ReembolsoPaciente3;
         AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = AV90TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel = AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = AV42TFLogWorkflowConvenioDesc;
         AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel = AV43TFLogWorkflowConvenioDesc_Sel;
         AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate = AV48TFReembolsoFlowLogDate;
         AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to = AV49TFReembolsoFlowLogDate_To;
         AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels = AV83TFLogReembolsoStatusAtual_F_Sels;
         AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f = AV63TFReembolsoFlowLogDataSLA_F;
         AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to = AV64TFReembolsoFlowLogDataSLA_F_To;
         AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo = AV84TFReembolsoLogProtocolo;
         AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel = AV85TFReembolsoLogProtocolo_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18LogWorkflowConvenioDesc1, AV19ReembolsoFlowLogUserNome1, AV94ReembolsoPaciente1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23LogWorkflowConvenioDesc2, AV24ReembolsoFlowLogUserNome2, AV95ReembolsoPaciente2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LogWorkflowConvenioDesc3, AV29ReembolsoFlowLogUserNome3, AV96ReembolsoPaciente3, AV6WWPContext, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV97Pgmname, AV15FilterFullText, AV90TFReembolsoPropostaPacienteClienteRazaoSocial, AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV42TFLogWorkflowConvenioDesc, AV43TFLogWorkflowConvenioDesc_Sel, AV48TFReembolsoFlowLogDate, AV49TFReembolsoFlowLogDate_To, AV83TFLogReembolsoStatusAtual_F_Sels, AV63TFReembolsoFlowLogDataSLA_F, AV64TFReembolsoFlowLogDataSLA_F_To, AV84TFReembolsoLogProtocolo, AV85TFReembolsoLogProtocolo_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV98Wcreembolsoflowlogds_1_filterfulltext = AV15FilterFullText;
         AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = AV18LogWorkflowConvenioDesc1;
         AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = AV19ReembolsoFlowLogUserNome1;
         AV103Wcreembolsoflowlogds_6_reembolsopaciente1 = AV94ReembolsoPaciente1;
         AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = AV23LogWorkflowConvenioDesc2;
         AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = AV24ReembolsoFlowLogUserNome2;
         AV109Wcreembolsoflowlogds_12_reembolsopaciente2 = AV95ReembolsoPaciente2;
         AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = AV28LogWorkflowConvenioDesc3;
         AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = AV29ReembolsoFlowLogUserNome3;
         AV115Wcreembolsoflowlogds_18_reembolsopaciente3 = AV96ReembolsoPaciente3;
         AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = AV90TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel = AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = AV42TFLogWorkflowConvenioDesc;
         AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel = AV43TFLogWorkflowConvenioDesc_Sel;
         AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate = AV48TFReembolsoFlowLogDate;
         AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to = AV49TFReembolsoFlowLogDate_To;
         AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels = AV83TFLogReembolsoStatusAtual_F_Sels;
         AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f = AV63TFReembolsoFlowLogDataSLA_F;
         AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to = AV64TFReembolsoFlowLogDataSLA_F_To;
         AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo = AV84TFReembolsoLogProtocolo;
         AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel = AV85TFReembolsoLogProtocolo_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18LogWorkflowConvenioDesc1, AV19ReembolsoFlowLogUserNome1, AV94ReembolsoPaciente1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23LogWorkflowConvenioDesc2, AV24ReembolsoFlowLogUserNome2, AV95ReembolsoPaciente2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LogWorkflowConvenioDesc3, AV29ReembolsoFlowLogUserNome3, AV96ReembolsoPaciente3, AV6WWPContext, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV97Pgmname, AV15FilterFullText, AV90TFReembolsoPropostaPacienteClienteRazaoSocial, AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV42TFLogWorkflowConvenioDesc, AV43TFLogWorkflowConvenioDesc_Sel, AV48TFReembolsoFlowLogDate, AV49TFReembolsoFlowLogDate_To, AV83TFLogReembolsoStatusAtual_F_Sels, AV63TFReembolsoFlowLogDataSLA_F, AV64TFReembolsoFlowLogDataSLA_F_To, AV84TFReembolsoLogProtocolo, AV85TFReembolsoLogProtocolo_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV97Pgmname = "WcReembolsoFlowLog";
         edtavReembolso_Enabled = 0;
         edtavConsulta_Enabled = 0;
         edtReembolsoPropostaPacienteClienteRazaoSocial_Enabled = 0;
         edtReembolsoFlowLogId_Enabled = 0;
         edtLogWorkflowConvenioId_Enabled = 0;
         edtLogWorkflowConvenioDesc_Enabled = 0;
         edtReembolsoFlowLogDate_Enabled = 0;
         edtReembolsoFlowLogUser_Enabled = 0;
         edtReembolsoFlowLogUserNome_Enabled = 0;
         edtReembolsoLogId_Enabled = 0;
         edtReembolsoWorkFlowConvenioId_Enabled = 0;
         edtReembolsoWorkflowConvenioSLA_Enabled = 0;
         cmbLogReembolsoStatusAtual_F.Enabled = 0;
         edtReembolsoFlowLogDataSLA_F_Enabled = 0;
         edtReembolsoLogProtocolo_Enabled = 0;
         edtReembolsoFlowLogDataFinal_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP800( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E23802 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV35ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV73DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_119 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_119"), ",", "."), 18, MidpointRounding.ToEven));
            AV75GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV76GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV77GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV50DDO_ReembolsoFlowLogDateAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_REEMBOLSOFLOWLOGDATEAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV50DDO_ReembolsoFlowLogDateAuxDate", context.localUtil.Format(AV50DDO_ReembolsoFlowLogDateAuxDate, "99/99/99"));
            AV51DDO_ReembolsoFlowLogDateAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_REEMBOLSOFLOWLOGDATEAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV51DDO_ReembolsoFlowLogDateAuxDateTo", context.localUtil.Format(AV51DDO_ReembolsoFlowLogDateAuxDateTo, "99/99/99"));
            AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_REEMBOLSOFLOWLOGDATASLA_FAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate", context.localUtil.Format(AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate, "99/99/99"));
            AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_REEMBOLSOFLOWLOGDATASLA_FAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo", context.localUtil.Format(AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo, "99/99/99"));
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
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( sPrefix+"DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( sPrefix+"DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV16DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AV18LogWorkflowConvenioDesc1 = cgiGet( edtavLogworkflowconveniodesc1_Internalname);
            AssignAttri(sPrefix, false, "AV18LogWorkflowConvenioDesc1", AV18LogWorkflowConvenioDesc1);
            AV19ReembolsoFlowLogUserNome1 = StringUtil.Upper( cgiGet( edtavReembolsoflowlogusernome1_Internalname));
            AssignAttri(sPrefix, false, "AV19ReembolsoFlowLogUserNome1", AV19ReembolsoFlowLogUserNome1);
            AV94ReembolsoPaciente1 = StringUtil.Upper( cgiGet( edtavReembolsopaciente1_Internalname));
            AssignAttri(sPrefix, false, "AV94ReembolsoPaciente1", AV94ReembolsoPaciente1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AV23LogWorkflowConvenioDesc2 = cgiGet( edtavLogworkflowconveniodesc2_Internalname);
            AssignAttri(sPrefix, false, "AV23LogWorkflowConvenioDesc2", AV23LogWorkflowConvenioDesc2);
            AV24ReembolsoFlowLogUserNome2 = StringUtil.Upper( cgiGet( edtavReembolsoflowlogusernome2_Internalname));
            AssignAttri(sPrefix, false, "AV24ReembolsoFlowLogUserNome2", AV24ReembolsoFlowLogUserNome2);
            AV95ReembolsoPaciente2 = StringUtil.Upper( cgiGet( edtavReembolsopaciente2_Internalname));
            AssignAttri(sPrefix, false, "AV95ReembolsoPaciente2", AV95ReembolsoPaciente2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV28LogWorkflowConvenioDesc3 = cgiGet( edtavLogworkflowconveniodesc3_Internalname);
            AssignAttri(sPrefix, false, "AV28LogWorkflowConvenioDesc3", AV28LogWorkflowConvenioDesc3);
            AV29ReembolsoFlowLogUserNome3 = StringUtil.Upper( cgiGet( edtavReembolsoflowlogusernome3_Internalname));
            AssignAttri(sPrefix, false, "AV29ReembolsoFlowLogUserNome3", AV29ReembolsoFlowLogUserNome3);
            AV96ReembolsoPaciente3 = StringUtil.Upper( cgiGet( edtavReembolsopaciente3_Internalname));
            AssignAttri(sPrefix, false, "AV96ReembolsoPaciente3", AV96ReembolsoPaciente3);
            AV52DDO_ReembolsoFlowLogDateAuxDateText = cgiGet( edtavDdo_reembolsoflowlogdateauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV52DDO_ReembolsoFlowLogDateAuxDateText", AV52DDO_ReembolsoFlowLogDateAuxDateText);
            AV67DDO_ReembolsoFlowLogDataSLA_FAuxDateText = cgiGet( edtavDdo_reembolsoflowlogdatasla_fauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV67DDO_ReembolsoFlowLogDataSLA_FAuxDateText", AV67DDO_ReembolsoFlowLogDataSLA_FAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vLOGWORKFLOWCONVENIODESC1"), AV18LogWorkflowConvenioDesc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOFLOWLOGUSERNOME1"), AV19ReembolsoFlowLogUserNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOPACIENTE1"), AV94ReembolsoPaciente1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vLOGWORKFLOWCONVENIODESC2"), AV23LogWorkflowConvenioDesc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOFLOWLOGUSERNOME2"), AV24ReembolsoFlowLogUserNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOPACIENTE2"), AV95ReembolsoPaciente2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vLOGWORKFLOWCONVENIODESC3"), AV28LogWorkflowConvenioDesc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOFLOWLOGUSERNOME3"), AV29ReembolsoFlowLogUserNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vREEMBOLSOPACIENTE3"), AV96ReembolsoPaciente3) != 0 )
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
         E23802 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E23802( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV6WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV6WWPContext = GXt_SdtWWPContext1;
         this.executeUsercontrolMethod(sPrefix, false, "TFREEMBOLSOFLOWLOGDATASLA_F_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_reembolsoflowlogdatasla_fauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFREEMBOLSOFLOWLOGDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_reembolsoflowlogdateauxdatetext_Internalname});
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
         AV16DynamicFiltersSelector1 = "LOGWORKFLOWCONVENIODESC";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV21DynamicFiltersSelector2 = "LOGWORKFLOWCONVENIODESC";
         AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersSelector3 = "LOGWORKFLOWCONVENIODESC";
         AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
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
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV73DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV73DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E24802( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV37ManageFiltersExecutionStep == 1 )
         {
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV37ManageFiltersExecutionStep == 2 )
         {
            AV37ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "LOGWORKFLOWCONVENIODESC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOPACIENTE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "LOGWORKFLOWCONVENIODESC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REEMBOLSOPACIENTE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV25DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "LOGWORKFLOWCONVENIODESC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REEMBOLSOPACIENTE") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV75GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV75GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV75GridCurrentPage), 10, 0));
         AV76GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV76GridPageCount", StringUtil.LTrimStr( (decimal)(AV76GridPageCount), 10, 0));
         GXt_char3 = AV77GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV97Pgmname, out  GXt_char3) ;
         AV77GridAppliedFilters = GXt_char3;
         AssignAttri(sPrefix, false, "AV77GridAppliedFilters", AV77GridAppliedFilters);
         cmbLogReembolsoStatusAtual_F_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp(sPrefix, false, cmbLogReembolsoStatusAtual_F_Internalname, "Columnheaderclass", cmbLogReembolsoStatusAtual_F_Columnheaderclass, !bGXsfl_119_Refreshing);
         AV98Wcreembolsoflowlogds_1_filterfulltext = AV15FilterFullText;
         AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = AV18LogWorkflowConvenioDesc1;
         AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = AV19ReembolsoFlowLogUserNome1;
         AV103Wcreembolsoflowlogds_6_reembolsopaciente1 = AV94ReembolsoPaciente1;
         AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = AV23LogWorkflowConvenioDesc2;
         AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = AV24ReembolsoFlowLogUserNome2;
         AV109Wcreembolsoflowlogds_12_reembolsopaciente2 = AV95ReembolsoPaciente2;
         AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = AV28LogWorkflowConvenioDesc3;
         AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = AV29ReembolsoFlowLogUserNome3;
         AV115Wcreembolsoflowlogds_18_reembolsopaciente3 = AV96ReembolsoPaciente3;
         AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = AV90TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel = AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = AV42TFLogWorkflowConvenioDesc;
         AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel = AV43TFLogWorkflowConvenioDesc_Sel;
         AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate = AV48TFReembolsoFlowLogDate;
         AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to = AV49TFReembolsoFlowLogDate_To;
         AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels = AV83TFLogReembolsoStatusAtual_F_Sels;
         AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f = AV63TFReembolsoFlowLogDataSLA_F;
         AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to = AV64TFReembolsoFlowLogDataSLA_F_To;
         AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo = AV84TFReembolsoLogProtocolo;
         AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel = AV85TFReembolsoLogProtocolo_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6WWPContext", AV6WWPContext);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E12802( )
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
            AV74PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV74PageToGo) ;
         }
      }

      protected void E13802( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14802( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoPropostaPacienteClienteRazaoSocial") == 0 )
            {
               AV90TFReembolsoPropostaPacienteClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV90TFReembolsoPropostaPacienteClienteRazaoSocial", AV90TFReembolsoPropostaPacienteClienteRazaoSocial);
               AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel", AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LogWorkflowConvenioDesc") == 0 )
            {
               AV42TFLogWorkflowConvenioDesc = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV42TFLogWorkflowConvenioDesc", AV42TFLogWorkflowConvenioDesc);
               AV43TFLogWorkflowConvenioDesc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV43TFLogWorkflowConvenioDesc_Sel", AV43TFLogWorkflowConvenioDesc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoFlowLogDate") == 0 )
            {
               AV48TFReembolsoFlowLogDate = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV48TFReembolsoFlowLogDate", context.localUtil.TToC( AV48TFReembolsoFlowLogDate, 8, 5, 0, 3, "/", ":", " "));
               AV49TFReembolsoFlowLogDate_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV49TFReembolsoFlowLogDate_To", context.localUtil.TToC( AV49TFReembolsoFlowLogDate_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV49TFReembolsoFlowLogDate_To) )
               {
                  AV49TFReembolsoFlowLogDate_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV49TFReembolsoFlowLogDate_To)), (short)(DateTimeUtil.Month( AV49TFReembolsoFlowLogDate_To)), (short)(DateTimeUtil.Day( AV49TFReembolsoFlowLogDate_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV49TFReembolsoFlowLogDate_To", context.localUtil.TToC( AV49TFReembolsoFlowLogDate_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LogReembolsoStatusAtual_F") == 0 )
            {
               AV82TFLogReembolsoStatusAtual_F_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV82TFLogReembolsoStatusAtual_F_SelsJson", AV82TFLogReembolsoStatusAtual_F_SelsJson);
               AV83TFLogReembolsoStatusAtual_F_Sels.FromJSonString(AV82TFLogReembolsoStatusAtual_F_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoFlowLogDataSLA_F") == 0 )
            {
               AV63TFReembolsoFlowLogDataSLA_F = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV63TFReembolsoFlowLogDataSLA_F", context.localUtil.TToC( AV63TFReembolsoFlowLogDataSLA_F, 8, 5, 0, 3, "/", ":", " "));
               AV64TFReembolsoFlowLogDataSLA_F_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV64TFReembolsoFlowLogDataSLA_F_To", context.localUtil.TToC( AV64TFReembolsoFlowLogDataSLA_F_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV64TFReembolsoFlowLogDataSLA_F_To) )
               {
                  AV64TFReembolsoFlowLogDataSLA_F_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV64TFReembolsoFlowLogDataSLA_F_To)), (short)(DateTimeUtil.Month( AV64TFReembolsoFlowLogDataSLA_F_To)), (short)(DateTimeUtil.Day( AV64TFReembolsoFlowLogDataSLA_F_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV64TFReembolsoFlowLogDataSLA_F_To", context.localUtil.TToC( AV64TFReembolsoFlowLogDataSLA_F_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoLogProtocolo") == 0 )
            {
               AV84TFReembolsoLogProtocolo = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV84TFReembolsoLogProtocolo", AV84TFReembolsoLogProtocolo);
               AV85TFReembolsoLogProtocolo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV85TFReembolsoLogProtocolo_Sel", AV85TFReembolsoLogProtocolo_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV83TFLogReembolsoStatusAtual_F_Sels", AV83TFLogReembolsoStatusAtual_F_Sels);
      }

      private void E25802( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV92Reembolso = "<i class=\"fas fa-rotate-left\"></i>";
         AssignAttri(sPrefix, false, edtavReembolso_Internalname, AV92Reembolso);
         if ( ! (0==AV6WWPContext.gxTpr_Secuserclienteid) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpreembolso"+UrlEncode(StringUtil.LTrimStr(A542ReembolsoPropostaId,9,0));
            edtavReembolso_Link = formatLink("wpreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            edtavReembolso_Class = "Attribute";
         }
         else
         {
            edtavReembolso_Link = "";
            edtavReembolso_Class = "Invisible";
         }
         AV93Consulta = "<i class=\"fas fa-magnifying-glass-plus\"></i>";
         AssignAttri(sPrefix, false, edtavConsulta_Internalname, AV93Consulta);
         if ( (0==AV6WWPContext.gxTpr_Secuserclienteid) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wreembolso"+UrlEncode(StringUtil.LTrimStr(A542ReembolsoPropostaId,9,0));
            edtavConsulta_Link = formatLink("wreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            edtavConsulta_Class = "Attribute";
         }
         else
         {
            edtavConsulta_Link = "";
            edtavConsulta_Class = "Invisible";
         }
         if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "EM_ANALISE") == 0 )
         {
            cmbLogReembolsoStatusAtual_F_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
         }
         else if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "FINALIZADO") == 0 )
         {
            cmbLogReembolsoStatusAtual_F_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "REANALISE") == 0 )
         {
            cmbLogReembolsoStatusAtual_F_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
         }
         else if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "") == 0 )
         {
            cmbLogReembolsoStatusAtual_F_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
         }
         else
         {
            cmbLogReembolsoStatusAtual_F_Columnclass = "WWColumn hidden-xs";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 119;
         }
         sendrow_1192( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_119_Refreshing )
         {
            DoAjaxLoad(119, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E18802( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18LogWorkflowConvenioDesc1, AV19ReembolsoFlowLogUserNome1, AV94ReembolsoPaciente1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23LogWorkflowConvenioDesc2, AV24ReembolsoFlowLogUserNome2, AV95ReembolsoPaciente2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LogWorkflowConvenioDesc3, AV29ReembolsoFlowLogUserNome3, AV96ReembolsoPaciente3, AV6WWPContext, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV97Pgmname, AV15FilterFullText, AV90TFReembolsoPropostaPacienteClienteRazaoSocial, AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV42TFLogWorkflowConvenioDesc, AV43TFLogWorkflowConvenioDesc_Sel, AV48TFReembolsoFlowLogDate, AV49TFReembolsoFlowLogDate_To, AV83TFLogReembolsoStatusAtual_F_Sels, AV63TFReembolsoFlowLogDataSLA_F, AV64TFReembolsoFlowLogDataSLA_F_To, AV84TFReembolsoLogProtocolo, AV85TFReembolsoLogProtocolo_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6WWPContext", AV6WWPContext);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E15802( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = true;
         AssignAttri(sPrefix, false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
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
         AV30DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = false;
         AssignAttri(sPrefix, false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18LogWorkflowConvenioDesc1, AV19ReembolsoFlowLogUserNome1, AV94ReembolsoPaciente1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23LogWorkflowConvenioDesc2, AV24ReembolsoFlowLogUserNome2, AV95ReembolsoPaciente2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LogWorkflowConvenioDesc3, AV29ReembolsoFlowLogUserNome3, AV96ReembolsoPaciente3, AV6WWPContext, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV97Pgmname, AV15FilterFullText, AV90TFReembolsoPropostaPacienteClienteRazaoSocial, AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV42TFLogWorkflowConvenioDesc, AV43TFLogWorkflowConvenioDesc_Sel, AV48TFReembolsoFlowLogDate, AV49TFReembolsoFlowLogDate_To, AV83TFLogReembolsoStatusAtual_F_Sels, AV63TFReembolsoFlowLogDataSLA_F, AV64TFReembolsoFlowLogDataSLA_F_To, AV84TFReembolsoLogProtocolo, AV85TFReembolsoLogProtocolo_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E19802( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E20802( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18LogWorkflowConvenioDesc1, AV19ReembolsoFlowLogUserNome1, AV94ReembolsoPaciente1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23LogWorkflowConvenioDesc2, AV24ReembolsoFlowLogUserNome2, AV95ReembolsoPaciente2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LogWorkflowConvenioDesc3, AV29ReembolsoFlowLogUserNome3, AV96ReembolsoPaciente3, AV6WWPContext, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV97Pgmname, AV15FilterFullText, AV90TFReembolsoPropostaPacienteClienteRazaoSocial, AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV42TFLogWorkflowConvenioDesc, AV43TFLogWorkflowConvenioDesc_Sel, AV48TFReembolsoFlowLogDate, AV49TFReembolsoFlowLogDate_To, AV83TFLogReembolsoStatusAtual_F_Sels, AV63TFReembolsoFlowLogDataSLA_F, AV64TFReembolsoFlowLogDataSLA_F_To, AV84TFReembolsoLogProtocolo, AV85TFReembolsoLogProtocolo_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6WWPContext", AV6WWPContext);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E16802( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
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
         AV30DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18LogWorkflowConvenioDesc1, AV19ReembolsoFlowLogUserNome1, AV94ReembolsoPaciente1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23LogWorkflowConvenioDesc2, AV24ReembolsoFlowLogUserNome2, AV95ReembolsoPaciente2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LogWorkflowConvenioDesc3, AV29ReembolsoFlowLogUserNome3, AV96ReembolsoPaciente3, AV6WWPContext, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV97Pgmname, AV15FilterFullText, AV90TFReembolsoPropostaPacienteClienteRazaoSocial, AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV42TFLogWorkflowConvenioDesc, AV43TFLogWorkflowConvenioDesc_Sel, AV48TFReembolsoFlowLogDate, AV49TFReembolsoFlowLogDate_To, AV83TFLogReembolsoStatusAtual_F_Sels, AV63TFReembolsoFlowLogDataSLA_F, AV64TFReembolsoFlowLogDataSLA_F_To, AV84TFReembolsoLogProtocolo, AV85TFReembolsoLogProtocolo_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E21802( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E17802( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
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
         AV30DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18LogWorkflowConvenioDesc1, AV19ReembolsoFlowLogUserNome1, AV94ReembolsoPaciente1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23LogWorkflowConvenioDesc2, AV24ReembolsoFlowLogUserNome2, AV95ReembolsoPaciente2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LogWorkflowConvenioDesc3, AV29ReembolsoFlowLogUserNome3, AV96ReembolsoPaciente3, AV6WWPContext, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV97Pgmname, AV15FilterFullText, AV90TFReembolsoPropostaPacienteClienteRazaoSocial, AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV42TFLogWorkflowConvenioDesc, AV43TFLogWorkflowConvenioDesc_Sel, AV48TFReembolsoFlowLogDate, AV49TFReembolsoFlowLogDate_To, AV83TFLogReembolsoStatusAtual_F_Sels, AV63TFReembolsoFlowLogDataSLA_F, AV64TFReembolsoFlowLogDataSLA_F_To, AV84TFReembolsoLogProtocolo, AV85TFReembolsoLogProtocolo_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E22802( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E11802( )
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
            S182 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WcReembolsoFlowLogFilters")) + "," + UrlEncode(StringUtil.RTrim(AV97Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WcReembolsoFlowLogFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char3 = AV36ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WcReembolsoFlowLogFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV36ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV97Pgmname+"GridState",  AV36ManageFiltersXml) ;
               AV10GridState.FromXml(AV36ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S172 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV83TFLogReembolsoStatusAtual_F_Sels", AV83TFLogReembolsoStatusAtual_F_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavLogworkflowconveniodesc1_Visible = 0;
         AssignProp(sPrefix, false, edtavLogworkflowconveniodesc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLogworkflowconveniodesc1_Visible), 5, 0), true);
         edtavReembolsoflowlogusernome1_Visible = 0;
         AssignProp(sPrefix, false, edtavReembolsoflowlogusernome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsoflowlogusernome1_Visible), 5, 0), true);
         edtavReembolsopaciente1_Visible = 0;
         AssignProp(sPrefix, false, edtavReembolsopaciente1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsopaciente1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "LOGWORKFLOWCONVENIODESC") == 0 )
         {
            edtavLogworkflowconveniodesc1_Visible = 1;
            AssignProp(sPrefix, false, edtavLogworkflowconveniodesc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLogworkflowconveniodesc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 )
         {
            edtavReembolsoflowlogusernome1_Visible = 1;
            AssignProp(sPrefix, false, edtavReembolsoflowlogusernome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsoflowlogusernome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOPACIENTE") == 0 )
         {
            edtavReembolsopaciente1_Visible = 1;
            AssignProp(sPrefix, false, edtavReembolsopaciente1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsopaciente1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavLogworkflowconveniodesc2_Visible = 0;
         AssignProp(sPrefix, false, edtavLogworkflowconveniodesc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLogworkflowconveniodesc2_Visible), 5, 0), true);
         edtavReembolsoflowlogusernome2_Visible = 0;
         AssignProp(sPrefix, false, edtavReembolsoflowlogusernome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsoflowlogusernome2_Visible), 5, 0), true);
         edtavReembolsopaciente2_Visible = 0;
         AssignProp(sPrefix, false, edtavReembolsopaciente2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsopaciente2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "LOGWORKFLOWCONVENIODESC") == 0 )
         {
            edtavLogworkflowconveniodesc2_Visible = 1;
            AssignProp(sPrefix, false, edtavLogworkflowconveniodesc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLogworkflowconveniodesc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 )
         {
            edtavReembolsoflowlogusernome2_Visible = 1;
            AssignProp(sPrefix, false, edtavReembolsoflowlogusernome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsoflowlogusernome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REEMBOLSOPACIENTE") == 0 )
         {
            edtavReembolsopaciente2_Visible = 1;
            AssignProp(sPrefix, false, edtavReembolsopaciente2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsopaciente2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavLogworkflowconveniodesc3_Visible = 0;
         AssignProp(sPrefix, false, edtavLogworkflowconveniodesc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLogworkflowconveniodesc3_Visible), 5, 0), true);
         edtavReembolsoflowlogusernome3_Visible = 0;
         AssignProp(sPrefix, false, edtavReembolsoflowlogusernome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsoflowlogusernome3_Visible), 5, 0), true);
         edtavReembolsopaciente3_Visible = 0;
         AssignProp(sPrefix, false, edtavReembolsopaciente3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsopaciente3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "LOGWORKFLOWCONVENIODESC") == 0 )
         {
            edtavLogworkflowconveniodesc3_Visible = 1;
            AssignProp(sPrefix, false, edtavLogworkflowconveniodesc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLogworkflowconveniodesc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 )
         {
            edtavReembolsoflowlogusernome3_Visible = 1;
            AssignProp(sPrefix, false, edtavReembolsoflowlogusernome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsoflowlogusernome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REEMBOLSOPACIENTE") == 0 )
         {
            edtavReembolsopaciente3_Visible = 1;
            AssignProp(sPrefix, false, edtavReembolsopaciente3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsopaciente3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "LOGWORKFLOWCONVENIODESC";
         AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AV23LogWorkflowConvenioDesc2 = "";
         AssignAttri(sPrefix, false, "AV23LogWorkflowConvenioDesc2", AV23LogWorkflowConvenioDesc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "LOGWORKFLOWCONVENIODESC";
         AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AV28LogWorkflowConvenioDesc3 = "";
         AssignAttri(sPrefix, false, "AV28LogWorkflowConvenioDesc3", AV28LogWorkflowConvenioDesc3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV35ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WcReembolsoFlowLogFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV35ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV90TFReembolsoPropostaPacienteClienteRazaoSocial = "";
         AssignAttri(sPrefix, false, "AV90TFReembolsoPropostaPacienteClienteRazaoSocial", AV90TFReembolsoPropostaPacienteClienteRazaoSocial);
         AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = "";
         AssignAttri(sPrefix, false, "AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel", AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel);
         AV42TFLogWorkflowConvenioDesc = "";
         AssignAttri(sPrefix, false, "AV42TFLogWorkflowConvenioDesc", AV42TFLogWorkflowConvenioDesc);
         AV43TFLogWorkflowConvenioDesc_Sel = "";
         AssignAttri(sPrefix, false, "AV43TFLogWorkflowConvenioDesc_Sel", AV43TFLogWorkflowConvenioDesc_Sel);
         AV48TFReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV48TFReembolsoFlowLogDate", context.localUtil.TToC( AV48TFReembolsoFlowLogDate, 8, 5, 0, 3, "/", ":", " "));
         AV49TFReembolsoFlowLogDate_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV49TFReembolsoFlowLogDate_To", context.localUtil.TToC( AV49TFReembolsoFlowLogDate_To, 8, 5, 0, 3, "/", ":", " "));
         AV83TFLogReembolsoStatusAtual_F_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV63TFReembolsoFlowLogDataSLA_F = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV63TFReembolsoFlowLogDataSLA_F", context.localUtil.TToC( AV63TFReembolsoFlowLogDataSLA_F, 8, 5, 0, 3, "/", ":", " "));
         AV64TFReembolsoFlowLogDataSLA_F_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV64TFReembolsoFlowLogDataSLA_F_To", context.localUtil.TToC( AV64TFReembolsoFlowLogDataSLA_F_To, 8, 5, 0, 3, "/", ":", " "));
         AV84TFReembolsoLogProtocolo = "";
         AssignAttri(sPrefix, false, "AV84TFReembolsoLogProtocolo", AV84TFReembolsoLogProtocolo);
         AV85TFReembolsoLogProtocolo_Sel = "";
         AssignAttri(sPrefix, false, "AV85TFReembolsoLogProtocolo_Sel", AV85TFReembolsoLogProtocolo_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "LOGWORKFLOWCONVENIODESC";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18LogWorkflowConvenioDesc1 = "";
         AssignAttri(sPrefix, false, "AV18LogWorkflowConvenioDesc1", AV18LogWorkflowConvenioDesc1);
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
         if ( StringUtil.StrCmp(AV34Session.Get(AV97Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV97Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV34Session.Get(AV97Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S172 ();
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
         AV127GXV1 = 1;
         while ( AV127GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV127GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV90TFReembolsoPropostaPacienteClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV90TFReembolsoPropostaPacienteClienteRazaoSocial", AV90TFReembolsoPropostaPacienteClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel", AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFLOGWORKFLOWCONVENIODESC") == 0 )
            {
               AV42TFLogWorkflowConvenioDesc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV42TFLogWorkflowConvenioDesc", AV42TFLogWorkflowConvenioDesc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFLOGWORKFLOWCONVENIODESC_SEL") == 0 )
            {
               AV43TFLogWorkflowConvenioDesc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV43TFLogWorkflowConvenioDesc_Sel", AV43TFLogWorkflowConvenioDesc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOFLOWLOGDATE") == 0 )
            {
               AV48TFReembolsoFlowLogDate = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV48TFReembolsoFlowLogDate", context.localUtil.TToC( AV48TFReembolsoFlowLogDate, 8, 5, 0, 3, "/", ":", " "));
               AV49TFReembolsoFlowLogDate_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV49TFReembolsoFlowLogDate_To", context.localUtil.TToC( AV49TFReembolsoFlowLogDate_To, 8, 5, 0, 3, "/", ":", " "));
               AV50DDO_ReembolsoFlowLogDateAuxDate = DateTimeUtil.ResetTime(AV48TFReembolsoFlowLogDate);
               AssignAttri(sPrefix, false, "AV50DDO_ReembolsoFlowLogDateAuxDate", context.localUtil.Format(AV50DDO_ReembolsoFlowLogDateAuxDate, "99/99/99"));
               AV51DDO_ReembolsoFlowLogDateAuxDateTo = DateTimeUtil.ResetTime(AV49TFReembolsoFlowLogDate_To);
               AssignAttri(sPrefix, false, "AV51DDO_ReembolsoFlowLogDateAuxDateTo", context.localUtil.Format(AV51DDO_ReembolsoFlowLogDateAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFLOGREEMBOLSOSTATUSATUAL_F_SEL") == 0 )
            {
               AV82TFLogReembolsoStatusAtual_F_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV82TFLogReembolsoStatusAtual_F_SelsJson", AV82TFLogReembolsoStatusAtual_F_SelsJson);
               AV83TFLogReembolsoStatusAtual_F_Sels.FromJSonString(AV82TFLogReembolsoStatusAtual_F_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOFLOWLOGDATASLA_F") == 0 )
            {
               AV63TFReembolsoFlowLogDataSLA_F = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV63TFReembolsoFlowLogDataSLA_F", context.localUtil.TToC( AV63TFReembolsoFlowLogDataSLA_F, 8, 5, 0, 3, "/", ":", " "));
               AV64TFReembolsoFlowLogDataSLA_F_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV64TFReembolsoFlowLogDataSLA_F_To", context.localUtil.TToC( AV64TFReembolsoFlowLogDataSLA_F_To, 8, 5, 0, 3, "/", ":", " "));
               AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate = DateTimeUtil.ResetTime(AV63TFReembolsoFlowLogDataSLA_F);
               AssignAttri(sPrefix, false, "AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate", context.localUtil.Format(AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate, "99/99/99"));
               AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo = DateTimeUtil.ResetTime(AV64TFReembolsoFlowLogDataSLA_F_To);
               AssignAttri(sPrefix, false, "AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo", context.localUtil.Format(AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOLOGPROTOCOLO") == 0 )
            {
               AV84TFReembolsoLogProtocolo = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV84TFReembolsoLogProtocolo", AV84TFReembolsoLogProtocolo);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOLOGPROTOCOLO_SEL") == 0 )
            {
               AV85TFReembolsoLogProtocolo_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV85TFReembolsoLogProtocolo_Sel", AV85TFReembolsoLogProtocolo_Sel);
            }
            AV127GXV1 = (int)(AV127GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel)),  AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFLogWorkflowConvenioDesc_Sel)),  AV43TFLogWorkflowConvenioDesc_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV83TFLogReembolsoStatusAtual_F_Sels.Count==0),  AV82TFLogReembolsoStatusAtual_F_SelsJson, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV85TFReembolsoLogProtocolo_Sel)),  AV85TFReembolsoLogProtocolo_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"||"+GXt_char6+"||"+GXt_char7;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV90TFReembolsoPropostaPacienteClienteRazaoSocial)),  AV90TFReembolsoPropostaPacienteClienteRazaoSocial, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFLogWorkflowConvenioDesc)),  AV42TFLogWorkflowConvenioDesc, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV84TFReembolsoLogProtocolo)),  AV84TFReembolsoLogProtocolo, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+GXt_char6+"|"+((DateTime.MinValue==AV48TFReembolsoFlowLogDate) ? "" : context.localUtil.DToC( AV50DDO_ReembolsoFlowLogDateAuxDate, 4, "/"))+"||"+((DateTime.MinValue==AV63TFReembolsoFlowLogDataSLA_F) ? "" : context.localUtil.DToC( AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate, 4, "/"))+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV49TFReembolsoFlowLogDate_To) ? "" : context.localUtil.DToC( AV51DDO_ReembolsoFlowLogDateAuxDateTo, 4, "/"))+"||"+((DateTime.MinValue==AV64TFReembolsoFlowLogDataSLA_F_To) ? "" : context.localUtil.DToC( AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo, 4, "/"))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
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
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "LOGWORKFLOWCONVENIODESC") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18LogWorkflowConvenioDesc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV18LogWorkflowConvenioDesc1", AV18LogWorkflowConvenioDesc1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19ReembolsoFlowLogUserNome1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV19ReembolsoFlowLogUserNome1", AV19ReembolsoFlowLogUserNome1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOPACIENTE") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV94ReembolsoPaciente1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV94ReembolsoPaciente1", AV94ReembolsoPaciente1);
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
               AV20DynamicFiltersEnabled2 = true;
               AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "LOGWORKFLOWCONVENIODESC") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV23LogWorkflowConvenioDesc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV23LogWorkflowConvenioDesc2", AV23LogWorkflowConvenioDesc2);
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV24ReembolsoFlowLogUserNome2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV24ReembolsoFlowLogUserNome2", AV24ReembolsoFlowLogUserNome2);
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REEMBOLSOPACIENTE") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV95ReembolsoPaciente2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV95ReembolsoPaciente2", AV95ReembolsoPaciente2);
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
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "LOGWORKFLOWCONVENIODESC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28LogWorkflowConvenioDesc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV28LogWorkflowConvenioDesc3", AV28LogWorkflowConvenioDesc3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV29ReembolsoFlowLogUserNome3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV29ReembolsoFlowLogUserNome3", AV29ReembolsoFlowLogUserNome3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REEMBOLSOPACIENTE") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV96ReembolsoPaciente3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV96ReembolsoPaciente3", AV96ReembolsoPaciente3);
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
         if ( AV30DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV34Session.Get(AV97Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL",  "Paciente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV90TFReembolsoPropostaPacienteClienteRazaoSocial)),  0,  AV90TFReembolsoPropostaPacienteClienteRazaoSocial,  AV90TFReembolsoPropostaPacienteClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel)),  AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel,  AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFLOGWORKFLOWCONVENIODESC",  "Passo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFLogWorkflowConvenioDesc)),  0,  AV42TFLogWorkflowConvenioDesc,  AV42TFLogWorkflowConvenioDesc,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFLogWorkflowConvenioDesc_Sel)),  AV43TFLogWorkflowConvenioDesc_Sel,  AV43TFLogWorkflowConvenioDesc_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFREEMBOLSOFLOWLOGDATE",  "Data início",  !((DateTime.MinValue==AV48TFReembolsoFlowLogDate)&&(DateTime.MinValue==AV49TFReembolsoFlowLogDate_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV48TFReembolsoFlowLogDate, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV48TFReembolsoFlowLogDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV48TFReembolsoFlowLogDate, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV49TFReembolsoFlowLogDate_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV49TFReembolsoFlowLogDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV49TFReembolsoFlowLogDate_To, "99/99/99 99:99")))) ;
         AV81AuxText = ((AV83TFLogReembolsoStatusAtual_F_Sels.Count==1) ? "["+((string)AV83TFLogReembolsoStatusAtual_F_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFLOGREEMBOLSOSTATUSATUAL_F_SEL",  "Situação reembolso",  !(AV83TFLogReembolsoStatusAtual_F_Sels.Count==0),  0,  AV83TFLogReembolsoStatusAtual_F_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV81AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV81AuxText, "[EM_ANALISE]", "Em análise"), "[FINALIZADO]", "Finalizado"), "[REANALISE]", "Reanálise"), "[]", "Não iniciado")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFREEMBOLSOFLOWLOGDATASLA_F",  "Data desejada",  !((DateTime.MinValue==AV63TFReembolsoFlowLogDataSLA_F)&&(DateTime.MinValue==AV64TFReembolsoFlowLogDataSLA_F_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV63TFReembolsoFlowLogDataSLA_F, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV63TFReembolsoFlowLogDataSLA_F) ? "" : StringUtil.Trim( context.localUtil.Format( AV63TFReembolsoFlowLogDataSLA_F, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV64TFReembolsoFlowLogDataSLA_F_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV64TFReembolsoFlowLogDataSLA_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV64TFReembolsoFlowLogDataSLA_F_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREEMBOLSOLOGPROTOCOLO",  "Protocolo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV84TFReembolsoLogProtocolo)),  0,  AV84TFReembolsoLogProtocolo,  AV84TFReembolsoLogProtocolo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV85TFReembolsoLogProtocolo_Sel)),  AV85TFReembolsoLogProtocolo_Sel,  AV85TFReembolsoLogProtocolo_Sel) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV97Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV31DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "LOGWORKFLOWCONVENIODESC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18LogWorkflowConvenioDesc1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Convenio Desc",  AV17DynamicFiltersOperator1,  AV18LogWorkflowConvenioDesc1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18LogWorkflowConvenioDesc1, "Contém"+" "+AV18LogWorkflowConvenioDesc1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ReembolsoFlowLogUserNome1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "User Nome",  AV17DynamicFiltersOperator1,  AV19ReembolsoFlowLogUserNome1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV19ReembolsoFlowLogUserNome1, "Contém"+" "+AV19ReembolsoFlowLogUserNome1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOPACIENTE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV94ReembolsoPaciente1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Paciente",  AV17DynamicFiltersOperator1,  AV94ReembolsoPaciente1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV94ReembolsoPaciente1, "Contém"+" "+AV94ReembolsoPaciente1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV21DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "LOGWORKFLOWCONVENIODESC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23LogWorkflowConvenioDesc2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Convenio Desc",  AV22DynamicFiltersOperator2,  AV23LogWorkflowConvenioDesc2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV23LogWorkflowConvenioDesc2, "Contém"+" "+AV23LogWorkflowConvenioDesc2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ReembolsoFlowLogUserNome2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "User Nome",  AV22DynamicFiltersOperator2,  AV24ReembolsoFlowLogUserNome2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV24ReembolsoFlowLogUserNome2, "Contém"+" "+AV24ReembolsoFlowLogUserNome2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "REEMBOLSOPACIENTE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV95ReembolsoPaciente2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Paciente",  AV22DynamicFiltersOperator2,  AV95ReembolsoPaciente2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV95ReembolsoPaciente2, "Contém"+" "+AV95ReembolsoPaciente2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV25DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV26DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "LOGWORKFLOWCONVENIODESC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28LogWorkflowConvenioDesc3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Convenio Desc",  AV27DynamicFiltersOperator3,  AV28LogWorkflowConvenioDesc3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV28LogWorkflowConvenioDesc3, "Contém"+" "+AV28LogWorkflowConvenioDesc3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ReembolsoFlowLogUserNome3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "User Nome",  AV27DynamicFiltersOperator3,  AV29ReembolsoFlowLogUserNome3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV29ReembolsoFlowLogUserNome3, "Contém"+" "+AV29ReembolsoFlowLogUserNome3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "REEMBOLSOPACIENTE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV96ReembolsoPaciente3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Paciente",  AV27DynamicFiltersOperator3,  AV96ReembolsoPaciente3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV96ReembolsoPaciente3, "Contém"+" "+AV96ReembolsoPaciente3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV97Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "ReembolsoFlowLog";
         AV34Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_95_802( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 0, "HLP_WcReembolsoFlowLog.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_logworkflowconveniodesc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLogworkflowconveniodesc3_Internalname, "Log Workflow Convenio Desc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLogworkflowconveniodesc3_Internalname, AV28LogWorkflowConvenioDesc3, StringUtil.RTrim( context.localUtil.Format( AV28LogWorkflowConvenioDesc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLogworkflowconveniodesc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavLogworkflowconveniodesc3_Visible, edtavLogworkflowconveniodesc3_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reembolsoflowlogusernome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoflowlogusernome3_Internalname, "Reembolso Flow Log User Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoflowlogusernome3_Internalname, AV29ReembolsoFlowLogUserNome3, StringUtil.RTrim( context.localUtil.Format( AV29ReembolsoFlowLogUserNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,105);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoflowlogusernome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavReembolsoflowlogusernome3_Visible, edtavReembolsoflowlogusernome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reembolsopaciente3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsopaciente3_Internalname, "Reembolso Paciente3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsopaciente3_Internalname, AV96ReembolsoPaciente3, StringUtil.RTrim( context.localUtil.Format( AV96ReembolsoPaciente3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,108);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsopaciente3_Jsonclick, 0, "Attribute", "", "", "", "", edtavReembolsopaciente3_Visible, edtavReembolsopaciente3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WcReembolsoFlowLog.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_95_802e( true) ;
         }
         else
         {
            wb_table3_95_802e( false) ;
         }
      }

      protected void wb_table2_67_802( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_WcReembolsoFlowLog.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_logworkflowconveniodesc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLogworkflowconveniodesc2_Internalname, "Log Workflow Convenio Desc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLogworkflowconveniodesc2_Internalname, AV23LogWorkflowConvenioDesc2, StringUtil.RTrim( context.localUtil.Format( AV23LogWorkflowConvenioDesc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLogworkflowconveniodesc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavLogworkflowconveniodesc2_Visible, edtavLogworkflowconveniodesc2_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reembolsoflowlogusernome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoflowlogusernome2_Internalname, "Reembolso Flow Log User Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoflowlogusernome2_Internalname, AV24ReembolsoFlowLogUserNome2, StringUtil.RTrim( context.localUtil.Format( AV24ReembolsoFlowLogUserNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,77);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoflowlogusernome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavReembolsoflowlogusernome2_Visible, edtavReembolsoflowlogusernome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reembolsopaciente2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsopaciente2_Internalname, "Reembolso Paciente2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsopaciente2_Internalname, AV95ReembolsoPaciente2, StringUtil.RTrim( context.localUtil.Format( AV95ReembolsoPaciente2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,80);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsopaciente2_Jsonclick, 0, "Attribute", "", "", "", "", edtavReembolsopaciente2_Visible, edtavReembolsopaciente2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WcReembolsoFlowLog.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WcReembolsoFlowLog.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_67_802e( true) ;
         }
         else
         {
            wb_table2_67_802e( false) ;
         }
      }

      protected void wb_table1_39_802( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_WcReembolsoFlowLog.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_logworkflowconveniodesc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLogworkflowconveniodesc1_Internalname, "Log Workflow Convenio Desc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLogworkflowconveniodesc1_Internalname, AV18LogWorkflowConvenioDesc1, StringUtil.RTrim( context.localUtil.Format( AV18LogWorkflowConvenioDesc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLogworkflowconveniodesc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavLogworkflowconveniodesc1_Visible, edtavLogworkflowconveniodesc1_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reembolsoflowlogusernome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsoflowlogusernome1_Internalname, "Reembolso Flow Log User Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsoflowlogusernome1_Internalname, AV19ReembolsoFlowLogUserNome1, StringUtil.RTrim( context.localUtil.Format( AV19ReembolsoFlowLogUserNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsoflowlogusernome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavReembolsoflowlogusernome1_Visible, edtavReembolsoflowlogusernome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reembolsopaciente1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsopaciente1_Internalname, "Reembolso Paciente1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsopaciente1_Internalname, AV94ReembolsoPaciente1, StringUtil.RTrim( context.localUtil.Format( AV94ReembolsoPaciente1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsopaciente1_Jsonclick, 0, "Attribute", "", "", "", "", edtavReembolsopaciente1_Visible, edtavReembolsopaciente1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcReembolsoFlowLog.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WcReembolsoFlowLog.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WcReembolsoFlowLog.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_39_802e( true) ;
         }
         else
         {
            wb_table1_39_802e( false) ;
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
         PA802( ) ;
         WS802( ) ;
         WE802( ) ;
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
         PA802( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcreembolsoflowlog", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA802( ) ;
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
         PA802( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS802( ) ;
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
         WS802( ) ;
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
         WE802( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019211761", true, true);
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
         context.AddJavascriptSource("wcreembolsoflowlog.js", "?202561019211761", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1192( )
      {
         edtavReembolso_Internalname = sPrefix+"vREEMBOLSO_"+sGXsfl_119_idx;
         edtavConsulta_Internalname = sPrefix+"vCONSULTA_"+sGXsfl_119_idx;
         edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname = sPrefix+"REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_"+sGXsfl_119_idx;
         edtReembolsoFlowLogId_Internalname = sPrefix+"REEMBOLSOFLOWLOGID_"+sGXsfl_119_idx;
         edtLogWorkflowConvenioId_Internalname = sPrefix+"LOGWORKFLOWCONVENIOID_"+sGXsfl_119_idx;
         edtLogWorkflowConvenioDesc_Internalname = sPrefix+"LOGWORKFLOWCONVENIODESC_"+sGXsfl_119_idx;
         edtReembolsoFlowLogDate_Internalname = sPrefix+"REEMBOLSOFLOWLOGDATE_"+sGXsfl_119_idx;
         edtReembolsoFlowLogUser_Internalname = sPrefix+"REEMBOLSOFLOWLOGUSER_"+sGXsfl_119_idx;
         edtReembolsoFlowLogUserNome_Internalname = sPrefix+"REEMBOLSOFLOWLOGUSERNOME_"+sGXsfl_119_idx;
         edtReembolsoLogId_Internalname = sPrefix+"REEMBOLSOLOGID_"+sGXsfl_119_idx;
         edtReembolsoWorkFlowConvenioId_Internalname = sPrefix+"REEMBOLSOWORKFLOWCONVENIOID_"+sGXsfl_119_idx;
         edtReembolsoWorkflowConvenioSLA_Internalname = sPrefix+"REEMBOLSOWORKFLOWCONVENIOSLA_"+sGXsfl_119_idx;
         cmbLogReembolsoStatusAtual_F_Internalname = sPrefix+"LOGREEMBOLSOSTATUSATUAL_F_"+sGXsfl_119_idx;
         edtReembolsoFlowLogDataSLA_F_Internalname = sPrefix+"REEMBOLSOFLOWLOGDATASLA_F_"+sGXsfl_119_idx;
         edtReembolsoLogProtocolo_Internalname = sPrefix+"REEMBOLSOLOGPROTOCOLO_"+sGXsfl_119_idx;
         edtReembolsoFlowLogDataFinal_Internalname = sPrefix+"REEMBOLSOFLOWLOGDATAFINAL_"+sGXsfl_119_idx;
      }

      protected void SubsflControlProps_fel_1192( )
      {
         edtavReembolso_Internalname = sPrefix+"vREEMBOLSO_"+sGXsfl_119_fel_idx;
         edtavConsulta_Internalname = sPrefix+"vCONSULTA_"+sGXsfl_119_fel_idx;
         edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname = sPrefix+"REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_"+sGXsfl_119_fel_idx;
         edtReembolsoFlowLogId_Internalname = sPrefix+"REEMBOLSOFLOWLOGID_"+sGXsfl_119_fel_idx;
         edtLogWorkflowConvenioId_Internalname = sPrefix+"LOGWORKFLOWCONVENIOID_"+sGXsfl_119_fel_idx;
         edtLogWorkflowConvenioDesc_Internalname = sPrefix+"LOGWORKFLOWCONVENIODESC_"+sGXsfl_119_fel_idx;
         edtReembolsoFlowLogDate_Internalname = sPrefix+"REEMBOLSOFLOWLOGDATE_"+sGXsfl_119_fel_idx;
         edtReembolsoFlowLogUser_Internalname = sPrefix+"REEMBOLSOFLOWLOGUSER_"+sGXsfl_119_fel_idx;
         edtReembolsoFlowLogUserNome_Internalname = sPrefix+"REEMBOLSOFLOWLOGUSERNOME_"+sGXsfl_119_fel_idx;
         edtReembolsoLogId_Internalname = sPrefix+"REEMBOLSOLOGID_"+sGXsfl_119_fel_idx;
         edtReembolsoWorkFlowConvenioId_Internalname = sPrefix+"REEMBOLSOWORKFLOWCONVENIOID_"+sGXsfl_119_fel_idx;
         edtReembolsoWorkflowConvenioSLA_Internalname = sPrefix+"REEMBOLSOWORKFLOWCONVENIOSLA_"+sGXsfl_119_fel_idx;
         cmbLogReembolsoStatusAtual_F_Internalname = sPrefix+"LOGREEMBOLSOSTATUSATUAL_F_"+sGXsfl_119_fel_idx;
         edtReembolsoFlowLogDataSLA_F_Internalname = sPrefix+"REEMBOLSOFLOWLOGDATASLA_F_"+sGXsfl_119_fel_idx;
         edtReembolsoLogProtocolo_Internalname = sPrefix+"REEMBOLSOLOGPROTOCOLO_"+sGXsfl_119_fel_idx;
         edtReembolsoFlowLogDataFinal_Internalname = sPrefix+"REEMBOLSOFLOWLOGDATAFINAL_"+sGXsfl_119_fel_idx;
      }

      protected void sendrow_1192( )
      {
         sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
         SubsflControlProps_1192( ) ;
         WB800( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_119_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_119_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_119_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',119)\"";
            ROClassString = edtavReembolso_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavReembolso_Internalname,StringUtil.RTrim( AV92Reembolso),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavReembolso_Link,(string)"",(string)"Reembolso",(string)"",(string)edtavReembolso_Jsonclick,(short)0,(string)edtavReembolso_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavReembolso_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'" + sPrefix + "',false,'" + sGXsfl_119_idx + "',119)\"";
            ROClassString = edtavConsulta_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavConsulta_Internalname,StringUtil.RTrim( AV93Consulta),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavConsulta_Link,(string)"",(string)"",(string)"",(string)edtavConsulta_Jsonclick,(short)0,(string)edtavConsulta_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavConsulta_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname,(string)A550ReembolsoPropostaPacienteClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A550ReembolsoPropostaPacienteClienteRazaoSocial, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoPropostaPacienteClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoFlowLogId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A746ReembolsoFlowLogId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A746ReembolsoFlowLogId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoFlowLogId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLogWorkflowConvenioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A750LogWorkflowConvenioId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLogWorkflowConvenioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLogWorkflowConvenioDesc_Internalname,(string)A752LogWorkflowConvenioDesc,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLogWorkflowConvenioDesc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoFlowLogDate_Internalname,context.localUtil.TToC( A747ReembolsoFlowLogDate, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A747ReembolsoFlowLogDate, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoFlowLogDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoFlowLogUser_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A744ReembolsoFlowLogUser), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoFlowLogUser_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoFlowLogUserNome_Internalname,(string)A745ReembolsoFlowLogUserNome,StringUtil.RTrim( context.localUtil.Format( A745ReembolsoFlowLogUserNome, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoFlowLogUserNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoLogId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A748ReembolsoLogId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoLogId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoWorkFlowConvenioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A749ReembolsoWorkFlowConvenioId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoWorkFlowConvenioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoWorkflowConvenioSLA_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A754ReembolsoWorkflowConvenioSLA), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A754ReembolsoWorkflowConvenioSLA), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoWorkflowConvenioSLA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "LOGREEMBOLSOSTATUSATUAL_F_" + sGXsfl_119_idx;
            cmbLogReembolsoStatusAtual_F.Name = GXCCtl;
            cmbLogReembolsoStatusAtual_F.WebTags = "";
            cmbLogReembolsoStatusAtual_F.addItem("", "", 0);
            cmbLogReembolsoStatusAtual_F.addItem("EM_ANALISE", "Em análise", 0);
            cmbLogReembolsoStatusAtual_F.addItem("FINALIZADO", "Finalizado", 0);
            cmbLogReembolsoStatusAtual_F.addItem("REANALISE", "Reanálise", 0);
            cmbLogReembolsoStatusAtual_F.addItem("", "Não iniciado", 0);
            if ( cmbLogReembolsoStatusAtual_F.ItemCount > 0 )
            {
               A760LogReembolsoStatusAtual_F = cmbLogReembolsoStatusAtual_F.getValidValue(A760LogReembolsoStatusAtual_F);
               n760LogReembolsoStatusAtual_F = false;
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbLogReembolsoStatusAtual_F,(string)cmbLogReembolsoStatusAtual_F_Internalname,StringUtil.RTrim( A760LogReembolsoStatusAtual_F),(short)1,(string)cmbLogReembolsoStatusAtual_F_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbLogReembolsoStatusAtual_F_Columnclass,(string)cmbLogReembolsoStatusAtual_F_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbLogReembolsoStatusAtual_F.CurrentValue = StringUtil.RTrim( A760LogReembolsoStatusAtual_F);
            AssignProp(sPrefix, false, cmbLogReembolsoStatusAtual_F_Internalname, "Values", (string)(cmbLogReembolsoStatusAtual_F.ToJavascriptSource()), !bGXsfl_119_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoFlowLogDataSLA_F_Internalname,context.localUtil.TToC( A755ReembolsoFlowLogDataSLA_F, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A755ReembolsoFlowLogDataSLA_F, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoFlowLogDataSLA_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoLogProtocolo_Internalname,(string)A763ReembolsoLogProtocolo,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoLogProtocolo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoFlowLogDataFinal_Internalname,context.localUtil.TToC( A761ReembolsoFlowLogDataFinal, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A761ReembolsoFlowLogDataFinal, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoFlowLogDataFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes802( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_119_idx = ((subGrid_Islastpage==1)&&(nGXsfl_119_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_119_idx+1);
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
         }
         /* End function sendrow_1192 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("LOGWORKFLOWCONVENIODESC", "Convenio Desc", 0);
         cmbavDynamicfiltersselector1.addItem("REEMBOLSOFLOWLOGUSERNOME", "User Nome", 0);
         cmbavDynamicfiltersselector1.addItem("REEMBOLSOPACIENTE", "Paciente", 0);
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
         cmbavDynamicfiltersselector2.addItem("LOGWORKFLOWCONVENIODESC", "Convenio Desc", 0);
         cmbavDynamicfiltersselector2.addItem("REEMBOLSOFLOWLOGUSERNOME", "User Nome", 0);
         cmbavDynamicfiltersselector2.addItem("REEMBOLSOPACIENTE", "Paciente", 0);
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
         cmbavDynamicfiltersselector3.addItem("LOGWORKFLOWCONVENIODESC", "Convenio Desc", 0);
         cmbavDynamicfiltersselector3.addItem("REEMBOLSOFLOWLOGUSERNOME", "User Nome", 0);
         cmbavDynamicfiltersselector3.addItem("REEMBOLSOPACIENTE", "Paciente", 0);
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
         GXCCtl = "LOGREEMBOLSOSTATUSATUAL_F_" + sGXsfl_119_idx;
         cmbLogReembolsoStatusAtual_F.Name = GXCCtl;
         cmbLogReembolsoStatusAtual_F.WebTags = "";
         cmbLogReembolsoStatusAtual_F.addItem("", "", 0);
         cmbLogReembolsoStatusAtual_F.addItem("EM_ANALISE", "Em análise", 0);
         cmbLogReembolsoStatusAtual_F.addItem("FINALIZADO", "Finalizado", 0);
         cmbLogReembolsoStatusAtual_F.addItem("REANALISE", "Reanálise", 0);
         cmbLogReembolsoStatusAtual_F.addItem("", "Não iniciado", 0);
         if ( cmbLogReembolsoStatusAtual_F.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl119( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"119\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavReembolso_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavConsulta_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Paciente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Log Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Convenio Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Passo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data início") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Log User") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "User Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Log Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Convenio Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Convenio SLA") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Situação reembolso") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data desejada") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Protocolo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Data Final") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV92Reembolso)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavReembolso_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavReembolso_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavReembolso_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV93Consulta)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavConsulta_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavConsulta_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavConsulta_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A550ReembolsoPropostaPacienteClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A746ReembolsoFlowLogId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A752LogWorkflowConvenioDesc));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A747ReembolsoFlowLogDate, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A745ReembolsoFlowLogUserNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A754ReembolsoWorkflowConvenioSLA), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A760LogReembolsoStatusAtual_F));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbLogReembolsoStatusAtual_F_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbLogReembolsoStatusAtual_F_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A755ReembolsoFlowLogDataSLA_F, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A763ReembolsoLogProtocolo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A761ReembolsoFlowLogDataFinal, 10, 8, 0, 3, "/", ":", " ")));
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
         edtavLogworkflowconveniodesc1_Internalname = sPrefix+"vLOGWORKFLOWCONVENIODESC1";
         cellFilter_logworkflowconveniodesc1_cell_Internalname = sPrefix+"FILTER_LOGWORKFLOWCONVENIODESC1_CELL";
         edtavReembolsoflowlogusernome1_Internalname = sPrefix+"vREEMBOLSOFLOWLOGUSERNOME1";
         cellFilter_reembolsoflowlogusernome1_cell_Internalname = sPrefix+"FILTER_REEMBOLSOFLOWLOGUSERNOME1_CELL";
         edtavReembolsopaciente1_Internalname = sPrefix+"vREEMBOLSOPACIENTE1";
         cellFilter_reembolsopaciente1_cell_Internalname = sPrefix+"FILTER_REEMBOLSOPACIENTE1_CELL";
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
         edtavLogworkflowconveniodesc2_Internalname = sPrefix+"vLOGWORKFLOWCONVENIODESC2";
         cellFilter_logworkflowconveniodesc2_cell_Internalname = sPrefix+"FILTER_LOGWORKFLOWCONVENIODESC2_CELL";
         edtavReembolsoflowlogusernome2_Internalname = sPrefix+"vREEMBOLSOFLOWLOGUSERNOME2";
         cellFilter_reembolsoflowlogusernome2_cell_Internalname = sPrefix+"FILTER_REEMBOLSOFLOWLOGUSERNOME2_CELL";
         edtavReembolsopaciente2_Internalname = sPrefix+"vREEMBOLSOPACIENTE2";
         cellFilter_reembolsopaciente2_cell_Internalname = sPrefix+"FILTER_REEMBOLSOPACIENTE2_CELL";
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
         edtavLogworkflowconveniodesc3_Internalname = sPrefix+"vLOGWORKFLOWCONVENIODESC3";
         cellFilter_logworkflowconveniodesc3_cell_Internalname = sPrefix+"FILTER_LOGWORKFLOWCONVENIODESC3_CELL";
         edtavReembolsoflowlogusernome3_Internalname = sPrefix+"vREEMBOLSOFLOWLOGUSERNOME3";
         cellFilter_reembolsoflowlogusernome3_cell_Internalname = sPrefix+"FILTER_REEMBOLSOFLOWLOGUSERNOME3_CELL";
         edtavReembolsopaciente3_Internalname = sPrefix+"vREEMBOLSOPACIENTE3";
         cellFilter_reembolsopaciente3_cell_Internalname = sPrefix+"FILTER_REEMBOLSOPACIENTE3_CELL";
         imgRemovedynamicfilters3_Internalname = sPrefix+"REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = sPrefix+"TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = sPrefix+"ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtavReembolso_Internalname = sPrefix+"vREEMBOLSO";
         edtavConsulta_Internalname = sPrefix+"vCONSULTA";
         edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname = sPrefix+"REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         edtReembolsoFlowLogId_Internalname = sPrefix+"REEMBOLSOFLOWLOGID";
         edtLogWorkflowConvenioId_Internalname = sPrefix+"LOGWORKFLOWCONVENIOID";
         edtLogWorkflowConvenioDesc_Internalname = sPrefix+"LOGWORKFLOWCONVENIODESC";
         edtReembolsoFlowLogDate_Internalname = sPrefix+"REEMBOLSOFLOWLOGDATE";
         edtReembolsoFlowLogUser_Internalname = sPrefix+"REEMBOLSOFLOWLOGUSER";
         edtReembolsoFlowLogUserNome_Internalname = sPrefix+"REEMBOLSOFLOWLOGUSERNOME";
         edtReembolsoLogId_Internalname = sPrefix+"REEMBOLSOLOGID";
         edtReembolsoWorkFlowConvenioId_Internalname = sPrefix+"REEMBOLSOWORKFLOWCONVENIOID";
         edtReembolsoWorkflowConvenioSLA_Internalname = sPrefix+"REEMBOLSOWORKFLOWCONVENIOSLA";
         cmbLogReembolsoStatusAtual_F_Internalname = sPrefix+"LOGREEMBOLSOSTATUSATUAL_F";
         edtReembolsoFlowLogDataSLA_F_Internalname = sPrefix+"REEMBOLSOFLOWLOGDATASLA_F";
         edtReembolsoLogProtocolo_Internalname = sPrefix+"REEMBOLSOLOGPROTOCOLO";
         edtReembolsoFlowLogDataFinal_Internalname = sPrefix+"REEMBOLSOFLOWLOGDATAFINAL";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         lblJsdynamicfilters_Internalname = sPrefix+"JSDYNAMICFILTERS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_reembolsoflowlogdateauxdatetext_Internalname = sPrefix+"vDDO_REEMBOLSOFLOWLOGDATEAUXDATETEXT";
         Tfreembolsoflowlogdate_rangepicker_Internalname = sPrefix+"TFREEMBOLSOFLOWLOGDATE_RANGEPICKER";
         divDdo_reembolsoflowlogdateauxdates_Internalname = sPrefix+"DDO_REEMBOLSOFLOWLOGDATEAUXDATES";
         edtavDdo_reembolsoflowlogdatasla_fauxdatetext_Internalname = sPrefix+"vDDO_REEMBOLSOFLOWLOGDATASLA_FAUXDATETEXT";
         Tfreembolsoflowlogdatasla_f_rangepicker_Internalname = sPrefix+"TFREEMBOLSOFLOWLOGDATASLA_F_RANGEPICKER";
         divDdo_reembolsoflowlogdatasla_fauxdates_Internalname = sPrefix+"DDO_REEMBOLSOFLOWLOGDATASLA_FAUXDATES";
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
         edtReembolsoFlowLogDataFinal_Jsonclick = "";
         edtReembolsoLogProtocolo_Jsonclick = "";
         edtReembolsoFlowLogDataSLA_F_Jsonclick = "";
         cmbLogReembolsoStatusAtual_F_Jsonclick = "";
         cmbLogReembolsoStatusAtual_F_Columnclass = "WWColumn hidden-xs";
         edtReembolsoWorkflowConvenioSLA_Jsonclick = "";
         edtReembolsoWorkFlowConvenioId_Jsonclick = "";
         edtReembolsoLogId_Jsonclick = "";
         edtReembolsoFlowLogUserNome_Jsonclick = "";
         edtReembolsoFlowLogUser_Jsonclick = "";
         edtReembolsoFlowLogDate_Jsonclick = "";
         edtLogWorkflowConvenioDesc_Jsonclick = "";
         edtLogWorkflowConvenioId_Jsonclick = "";
         edtReembolsoFlowLogId_Jsonclick = "";
         edtReembolsoPropostaPacienteClienteRazaoSocial_Jsonclick = "";
         edtavConsulta_Jsonclick = "";
         edtavConsulta_Class = "Attribute";
         edtavConsulta_Link = "";
         edtavConsulta_Enabled = 0;
         edtavReembolso_Jsonclick = "";
         edtavReembolso_Class = "Attribute";
         edtavReembolso_Link = "";
         edtavReembolso_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavReembolsopaciente1_Jsonclick = "";
         edtavReembolsopaciente1_Enabled = 1;
         edtavReembolsoflowlogusernome1_Jsonclick = "";
         edtavReembolsoflowlogusernome1_Enabled = 1;
         edtavLogworkflowconveniodesc1_Jsonclick = "";
         edtavLogworkflowconveniodesc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavReembolsopaciente2_Jsonclick = "";
         edtavReembolsopaciente2_Enabled = 1;
         edtavReembolsoflowlogusernome2_Jsonclick = "";
         edtavReembolsoflowlogusernome2_Enabled = 1;
         edtavLogworkflowconveniodesc2_Jsonclick = "";
         edtavLogworkflowconveniodesc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavReembolsopaciente3_Jsonclick = "";
         edtavReembolsopaciente3_Enabled = 1;
         edtavReembolsoflowlogusernome3_Jsonclick = "";
         edtavReembolsoflowlogusernome3_Enabled = 1;
         edtavLogworkflowconveniodesc3_Jsonclick = "";
         edtavLogworkflowconveniodesc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavReembolsopaciente3_Visible = 1;
         edtavReembolsoflowlogusernome3_Visible = 1;
         edtavLogworkflowconveniodesc3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavReembolsopaciente2_Visible = 1;
         edtavReembolsoflowlogusernome2_Visible = 1;
         edtavLogworkflowconveniodesc2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavReembolsopaciente1_Visible = 1;
         edtavReembolsoflowlogusernome1_Visible = 1;
         edtavLogworkflowconveniodesc1_Visible = 1;
         cmbLogReembolsoStatusAtual_F_Columnheaderclass = "";
         edtReembolsoFlowLogDataFinal_Enabled = 0;
         edtReembolsoLogProtocolo_Enabled = 0;
         edtReembolsoFlowLogDataSLA_F_Enabled = 0;
         cmbLogReembolsoStatusAtual_F.Enabled = 0;
         edtReembolsoWorkflowConvenioSLA_Enabled = 0;
         edtReembolsoWorkFlowConvenioId_Enabled = 0;
         edtReembolsoLogId_Enabled = 0;
         edtReembolsoFlowLogUserNome_Enabled = 0;
         edtReembolsoFlowLogUser_Enabled = 0;
         edtReembolsoFlowLogDate_Enabled = 0;
         edtLogWorkflowConvenioDesc_Enabled = 0;
         edtLogWorkflowConvenioId_Enabled = 0;
         edtReembolsoFlowLogId_Enabled = 0;
         edtReembolsoPropostaPacienteClienteRazaoSocial_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_reembolsoflowlogdatasla_fauxdatetext_Jsonclick = "";
         edtavDdo_reembolsoflowlogdateauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "WcReembolsoFlowLogGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||EM_ANALISE:Em análise,FINALIZADO:Finalizado,REANALISE:Reanálise,:Não iniciado||";
         Ddo_grid_Allowmultipleselection = "|||T||";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic||FixedValues||Dynamic";
         Ddo_grid_Includedatalist = "T|T||T||T";
         Ddo_grid_Filterisrange = "||P||P|";
         Ddo_grid_Filtertype = "Character|Character|Date||Date|Character";
         Ddo_grid_Includefilter = "T|T|T||T|T";
         Ddo_grid_Includesortasc = "T|T|T|T||T";
         Ddo_grid_Columnssortvalues = "2|3|4|5||6";
         Ddo_grid_Columnids = "2:ReembolsoPropostaPacienteClienteRazaoSocial|5:LogWorkflowConvenioDesc|6:ReembolsoFlowLogDate|12:LogReembolsoStatusAtual_F|13:ReembolsoFlowLogDataSLA_F|14:ReembolsoLogProtocolo";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV90TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV43TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV48TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV83TFLogReembolsoStatusAtual_F_Sels","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV63TFReembolsoFlowLogDataSLA_F","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV64TFReembolsoFlowLogDataSLA_F_To","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV84TFReembolsoLogProtocolo","fld":"vTFREEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"AV85TFReembolsoLogProtocolo_Sel","fld":"vTFREEMBOLSOLOGPROTOCOLO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV75GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV76GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV77GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbLogReembolsoStatusAtual_F"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12802","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV90TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV43TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV48TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV83TFLogReembolsoStatusAtual_F_Sels","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV63TFReembolsoFlowLogDataSLA_F","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV64TFReembolsoFlowLogDataSLA_F_To","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV84TFReembolsoLogProtocolo","fld":"vTFREEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"AV85TFReembolsoLogProtocolo_Sel","fld":"vTFREEMBOLSOLOGPROTOCOLO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13802","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV90TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV43TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV48TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV83TFLogReembolsoStatusAtual_F_Sels","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV63TFReembolsoFlowLogDataSLA_F","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV64TFReembolsoFlowLogDataSLA_F_To","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV84TFReembolsoLogProtocolo","fld":"vTFREEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"AV85TFReembolsoLogProtocolo_Sel","fld":"vTFREEMBOLSOLOGPROTOCOLO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14802","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV90TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV43TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV48TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV83TFLogReembolsoStatusAtual_F_Sels","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV63TFReembolsoFlowLogDataSLA_F","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV64TFReembolsoFlowLogDataSLA_F_To","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV84TFReembolsoLogProtocolo","fld":"vTFREEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"AV85TFReembolsoLogProtocolo_Sel","fld":"vTFREEMBOLSOLOGPROTOCOLO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV84TFReembolsoLogProtocolo","fld":"vTFREEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"AV85TFReembolsoLogProtocolo_Sel","fld":"vTFREEMBOLSOLOGPROTOCOLO_SEL","type":"svchar"},{"av":"AV63TFReembolsoFlowLogDataSLA_F","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV64TFReembolsoFlowLogDataSLA_F_To","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV82TFLogReembolsoStatusAtual_F_SelsJson","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"},{"av":"AV83TFLogReembolsoStatusAtual_F_Sels","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV48TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV42TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV43TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV90TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E25802","iparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"A542ReembolsoPropostaId","fld":"REEMBOLSOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A548ReembolsoStatusAtual_F","fld":"REEMBOLSOSTATUSATUAL_F","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV92Reembolso","fld":"vREEMBOLSO","type":"char"},{"av":"edtavReembolso_Link","ctrl":"vREEMBOLSO","prop":"Link"},{"av":"edtavReembolso_Class","ctrl":"vREEMBOLSO","prop":"Class"},{"av":"AV93Consulta","fld":"vCONSULTA","type":"char"},{"av":"edtavConsulta_Link","ctrl":"vCONSULTA","prop":"Link"},{"av":"edtavConsulta_Class","ctrl":"vCONSULTA","prop":"Class"},{"av":"cmbLogReembolsoStatusAtual_F"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E18802","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV90TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV43TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV48TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV83TFLogReembolsoStatusAtual_F_Sels","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV63TFReembolsoFlowLogDataSLA_F","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV64TFReembolsoFlowLogDataSLA_F_To","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV84TFReembolsoLogProtocolo","fld":"vTFREEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"AV85TFReembolsoLogProtocolo_Sel","fld":"vTFREEMBOLSOLOGPROTOCOLO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV75GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV76GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV77GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbLogReembolsoStatusAtual_F"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E15802","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV90TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV43TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV48TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV83TFLogReembolsoStatusAtual_F_Sels","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV63TFReembolsoFlowLogDataSLA_F","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV64TFReembolsoFlowLogDataSLA_F_To","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV84TFReembolsoLogProtocolo","fld":"vTFREEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"AV85TFReembolsoLogProtocolo_Sel","fld":"vTFREEMBOLSOLOGPROTOCOLO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"edtavLogworkflowconveniodesc2_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome2_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME2","prop":"Visible"},{"av":"edtavReembolsopaciente2_Visible","ctrl":"vREEMBOLSOPACIENTE2","prop":"Visible"},{"av":"edtavLogworkflowconveniodesc3_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome3_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME3","prop":"Visible"},{"av":"edtavReembolsopaciente3_Visible","ctrl":"vREEMBOLSOPACIENTE3","prop":"Visible"},{"av":"edtavLogworkflowconveniodesc1_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome1_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME1","prop":"Visible"},{"av":"edtavReembolsopaciente1_Visible","ctrl":"vREEMBOLSOPACIENTE1","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV75GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV76GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV77GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbLogReembolsoStatusAtual_F"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E19802","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavLogworkflowconveniodesc1_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome1_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME1","prop":"Visible"},{"av":"edtavReembolsopaciente1_Visible","ctrl":"vREEMBOLSOPACIENTE1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E20802","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV90TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV43TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV48TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV83TFLogReembolsoStatusAtual_F_Sels","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV63TFReembolsoFlowLogDataSLA_F","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV64TFReembolsoFlowLogDataSLA_F_To","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV84TFReembolsoLogProtocolo","fld":"vTFREEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"AV85TFReembolsoLogProtocolo_Sel","fld":"vTFREEMBOLSOLOGPROTOCOLO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV75GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV76GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV77GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbLogReembolsoStatusAtual_F"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E16802","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV90TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV43TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV48TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV83TFLogReembolsoStatusAtual_F_Sels","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV63TFReembolsoFlowLogDataSLA_F","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV64TFReembolsoFlowLogDataSLA_F_To","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV84TFReembolsoLogProtocolo","fld":"vTFREEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"AV85TFReembolsoLogProtocolo_Sel","fld":"vTFREEMBOLSOLOGPROTOCOLO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"edtavLogworkflowconveniodesc2_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome2_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME2","prop":"Visible"},{"av":"edtavReembolsopaciente2_Visible","ctrl":"vREEMBOLSOPACIENTE2","prop":"Visible"},{"av":"edtavLogworkflowconveniodesc3_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome3_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME3","prop":"Visible"},{"av":"edtavReembolsopaciente3_Visible","ctrl":"vREEMBOLSOPACIENTE3","prop":"Visible"},{"av":"edtavLogworkflowconveniodesc1_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome1_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME1","prop":"Visible"},{"av":"edtavReembolsopaciente1_Visible","ctrl":"vREEMBOLSOPACIENTE1","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV75GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV76GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV77GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbLogReembolsoStatusAtual_F"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E21802","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavLogworkflowconveniodesc2_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome2_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME2","prop":"Visible"},{"av":"edtavReembolsopaciente2_Visible","ctrl":"vREEMBOLSOPACIENTE2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E17802","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV90TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV43TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV48TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV83TFLogReembolsoStatusAtual_F_Sels","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV63TFReembolsoFlowLogDataSLA_F","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV64TFReembolsoFlowLogDataSLA_F_To","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV84TFReembolsoLogProtocolo","fld":"vTFREEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"AV85TFReembolsoLogProtocolo_Sel","fld":"vTFREEMBOLSOLOGPROTOCOLO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"edtavLogworkflowconveniodesc2_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome2_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME2","prop":"Visible"},{"av":"edtavReembolsopaciente2_Visible","ctrl":"vREEMBOLSOPACIENTE2","prop":"Visible"},{"av":"edtavLogworkflowconveniodesc3_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome3_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME3","prop":"Visible"},{"av":"edtavReembolsopaciente3_Visible","ctrl":"vREEMBOLSOPACIENTE3","prop":"Visible"},{"av":"edtavLogworkflowconveniodesc1_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome1_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME1","prop":"Visible"},{"av":"edtavReembolsopaciente1_Visible","ctrl":"vREEMBOLSOPACIENTE1","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV75GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV76GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV77GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbLogReembolsoStatusAtual_F"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E22802","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavLogworkflowconveniodesc3_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome3_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME3","prop":"Visible"},{"av":"edtavReembolsopaciente3_Visible","ctrl":"vREEMBOLSOPACIENTE3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11802","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV97Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV90TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV43TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV48TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV83TFLogReembolsoStatusAtual_F_Sels","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV63TFReembolsoFlowLogDataSLA_F","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV64TFReembolsoFlowLogDataSLA_F_To","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV84TFReembolsoLogProtocolo","fld":"vTFREEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"AV85TFReembolsoLogProtocolo_Sel","fld":"vTFREEMBOLSOLOGPROTOCOLO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV82TFLogReembolsoStatusAtual_F_SelsJson","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"},{"av":"AV50DDO_ReembolsoFlowLogDateAuxDate","fld":"vDDO_REEMBOLSOFLOWLOGDATEAUXDATE","type":"date"},{"av":"AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate","fld":"vDDO_REEMBOLSOFLOWLOGDATASLA_FAUXDATE","type":"date"},{"av":"AV51DDO_ReembolsoFlowLogDateAuxDateTo","fld":"vDDO_REEMBOLSOFLOWLOGDATEAUXDATETO","type":"date"},{"av":"AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo","fld":"vDDO_REEMBOLSOFLOWLOGDATASLA_FAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV90TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV43TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV48TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV83TFLogReembolsoStatusAtual_F_Sels","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV63TFReembolsoFlowLogDataSLA_F","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV64TFReembolsoFlowLogDataSLA_F_To","fld":"vTFREEMBOLSOFLOWLOGDATASLA_F_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV84TFReembolsoLogProtocolo","fld":"vTFREEMBOLSOLOGPROTOCOLO","type":"svchar"},{"av":"AV85TFReembolsoLogProtocolo_Sel","fld":"vTFREEMBOLSOLOGPROTOCOLO_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18LogWorkflowConvenioDesc1","fld":"vLOGWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate","fld":"vDDO_REEMBOLSOFLOWLOGDATASLA_FAUXDATE","type":"date"},{"av":"AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo","fld":"vDDO_REEMBOLSOFLOWLOGDATASLA_FAUXDATETO","type":"date"},{"av":"AV82TFLogReembolsoStatusAtual_F_SelsJson","fld":"vTFLOGREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"},{"av":"AV50DDO_ReembolsoFlowLogDateAuxDate","fld":"vDDO_REEMBOLSOFLOWLOGDATEAUXDATE","type":"date"},{"av":"AV51DDO_ReembolsoFlowLogDateAuxDateTo","fld":"vDDO_REEMBOLSOFLOWLOGDATEAUXDATETO","type":"date"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV19ReembolsoFlowLogUserNome1","fld":"vREEMBOLSOFLOWLOGUSERNOME1","pic":"@!","type":"svchar"},{"av":"AV94ReembolsoPaciente1","fld":"vREEMBOLSOPACIENTE1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23LogWorkflowConvenioDesc2","fld":"vLOGWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV24ReembolsoFlowLogUserNome2","fld":"vREEMBOLSOFLOWLOGUSERNOME2","pic":"@!","type":"svchar"},{"av":"AV95ReembolsoPaciente2","fld":"vREEMBOLSOPACIENTE2","pic":"@!","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LogWorkflowConvenioDesc3","fld":"vLOGWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV29ReembolsoFlowLogUserNome3","fld":"vREEMBOLSOFLOWLOGUSERNOME3","pic":"@!","type":"svchar"},{"av":"AV96ReembolsoPaciente3","fld":"vREEMBOLSOPACIENTE3","pic":"@!","type":"svchar"},{"av":"edtavLogworkflowconveniodesc1_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome1_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME1","prop":"Visible"},{"av":"edtavReembolsopaciente1_Visible","ctrl":"vREEMBOLSOPACIENTE1","prop":"Visible"},{"av":"edtavLogworkflowconveniodesc2_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome2_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME2","prop":"Visible"},{"av":"edtavReembolsopaciente2_Visible","ctrl":"vREEMBOLSOPACIENTE2","prop":"Visible"},{"av":"edtavLogworkflowconveniodesc3_Visible","ctrl":"vLOGWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"edtavReembolsoflowlogusernome3_Visible","ctrl":"vREEMBOLSOFLOWLOGUSERNOME3","prop":"Visible"},{"av":"edtavReembolsopaciente3_Visible","ctrl":"vREEMBOLSOPACIENTE3","prop":"Visible"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV75GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV76GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV77GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbLogReembolsoStatusAtual_F"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VALID_LOGWORKFLOWCONVENIOID","""{"handler":"Valid_Logworkflowconvenioid","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOFLOWLOGUSER","""{"handler":"Valid_Reembolsoflowloguser","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOLOGID","""{"handler":"Valid_Reembolsologid","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOWORKFLOWCONVENIOID","""{"handler":"Valid_Reembolsoworkflowconvenioid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Reembolsoflowlogdatafinal","iparms":[]}""");
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
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV16DynamicFiltersSelector1 = "";
         AV18LogWorkflowConvenioDesc1 = "";
         AV19ReembolsoFlowLogUserNome1 = "";
         AV94ReembolsoPaciente1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV23LogWorkflowConvenioDesc2 = "";
         AV24ReembolsoFlowLogUserNome2 = "";
         AV95ReembolsoPaciente2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28LogWorkflowConvenioDesc3 = "";
         AV29ReembolsoFlowLogUserNome3 = "";
         AV96ReembolsoPaciente3 = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV97Pgmname = "";
         AV15FilterFullText = "";
         AV90TFReembolsoPropostaPacienteClienteRazaoSocial = "";
         AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = "";
         AV42TFLogWorkflowConvenioDesc = "";
         AV43TFLogWorkflowConvenioDesc_Sel = "";
         AV48TFReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         AV49TFReembolsoFlowLogDate_To = (DateTime)(DateTime.MinValue);
         AV83TFLogReembolsoStatusAtual_F_Sels = new GxSimpleCollection<string>();
         AV63TFReembolsoFlowLogDataSLA_F = (DateTime)(DateTime.MinValue);
         AV64TFReembolsoFlowLogDataSLA_F_To = (DateTime)(DateTime.MinValue);
         AV84TFReembolsoLogProtocolo = "";
         AV85TFReembolsoLogProtocolo_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV35ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV77GridAppliedFilters = "";
         AV73DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV50DDO_ReembolsoFlowLogDateAuxDate = DateTime.MinValue;
         AV51DDO_ReembolsoFlowLogDateAuxDateTo = DateTime.MinValue;
         AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate = DateTime.MinValue;
         AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo = DateTime.MinValue;
         A548ReembolsoStatusAtual_F = "";
         AV82TFLogReembolsoStatusAtual_F_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ucDvpanel_tableheader = new GXUserControl();
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         TempTags = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV52DDO_ReembolsoFlowLogDateAuxDateText = "";
         ucTfreembolsoflowlogdate_rangepicker = new GXUserControl();
         AV67DDO_ReembolsoFlowLogDataSLA_FAuxDateText = "";
         ucTfreembolsoflowlogdatasla_f_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV92Reembolso = "";
         AV93Consulta = "";
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         A752LogWorkflowConvenioDesc = "";
         A747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         A745ReembolsoFlowLogUserNome = "";
         A760LogReembolsoStatusAtual_F = "";
         A755ReembolsoFlowLogDataSLA_F = (DateTime)(DateTime.MinValue);
         A763ReembolsoLogProtocolo = "";
         A761ReembolsoFlowLogDataFinal = (DateTime)(DateTime.MinValue);
         AV98Wcreembolsoflowlogds_1_filterfulltext = "";
         AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 = "";
         AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = "";
         AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = "";
         AV103Wcreembolsoflowlogds_6_reembolsopaciente1 = "";
         AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 = "";
         AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = "";
         AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = "";
         AV109Wcreembolsoflowlogds_12_reembolsopaciente2 = "";
         AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 = "";
         AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = "";
         AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = "";
         AV115Wcreembolsoflowlogds_18_reembolsopaciente3 = "";
         AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = "";
         AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel = "";
         AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = "";
         AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel = "";
         AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate = (DateTime)(DateTime.MinValue);
         AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to = (DateTime)(DateTime.MinValue);
         AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels = new GxSimpleCollection<string>();
         AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f = (DateTime)(DateTime.MinValue);
         AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to = (DateTime)(DateTime.MinValue);
         AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo = "";
         AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel = "";
         lV98Wcreembolsoflowlogds_1_filterfulltext = "";
         lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 = "";
         lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 = "";
         lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 = "";
         lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 = "";
         lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 = "";
         lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 = "";
         lV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial = "";
         lV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc = "";
         lV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo = "";
         A764ReembolsoPaciente = "";
         H00804_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         H00804_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         H00804_A758ReembolsoPropostaClinicaId = new int[1] ;
         H00804_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         H00804_A542ReembolsoPropostaId = new int[1] ;
         H00804_n542ReembolsoPropostaId = new bool[] {false} ;
         H00804_A761ReembolsoFlowLogDataFinal = new DateTime[] {DateTime.MinValue} ;
         H00804_n761ReembolsoFlowLogDataFinal = new bool[] {false} ;
         H00804_A763ReembolsoLogProtocolo = new string[] {""} ;
         H00804_n763ReembolsoLogProtocolo = new bool[] {false} ;
         H00804_A755ReembolsoFlowLogDataSLA_F = new DateTime[] {DateTime.MinValue} ;
         H00804_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         H00804_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         H00804_A748ReembolsoLogId = new int[1] ;
         H00804_n748ReembolsoLogId = new bool[] {false} ;
         H00804_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         H00804_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         H00804_A744ReembolsoFlowLogUser = new short[1] ;
         H00804_n744ReembolsoFlowLogUser = new bool[] {false} ;
         H00804_A752LogWorkflowConvenioDesc = new string[] {""} ;
         H00804_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         H00804_A750LogWorkflowConvenioId = new int[1] ;
         H00804_n750LogWorkflowConvenioId = new bool[] {false} ;
         H00804_A746ReembolsoFlowLogId = new int[1] ;
         H00804_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H00804_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H00804_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         H00804_n747ReembolsoFlowLogDate = new bool[] {false} ;
         H00804_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         H00804_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         H00804_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         H00804_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         H00807_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         H00807_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         H00807_A758ReembolsoPropostaClinicaId = new int[1] ;
         H00807_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         H00807_A542ReembolsoPropostaId = new int[1] ;
         H00807_n542ReembolsoPropostaId = new bool[] {false} ;
         H00807_A761ReembolsoFlowLogDataFinal = new DateTime[] {DateTime.MinValue} ;
         H00807_n761ReembolsoFlowLogDataFinal = new bool[] {false} ;
         H00807_A763ReembolsoLogProtocolo = new string[] {""} ;
         H00807_n763ReembolsoLogProtocolo = new bool[] {false} ;
         H00807_A755ReembolsoFlowLogDataSLA_F = new DateTime[] {DateTime.MinValue} ;
         H00807_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         H00807_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         H00807_A748ReembolsoLogId = new int[1] ;
         H00807_n748ReembolsoLogId = new bool[] {false} ;
         H00807_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         H00807_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         H00807_A744ReembolsoFlowLogUser = new short[1] ;
         H00807_n744ReembolsoFlowLogUser = new bool[] {false} ;
         H00807_A752LogWorkflowConvenioDesc = new string[] {""} ;
         H00807_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         H00807_A750LogWorkflowConvenioId = new int[1] ;
         H00807_n750LogWorkflowConvenioId = new bool[] {false} ;
         H00807_A746ReembolsoFlowLogId = new int[1] ;
         H00807_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H00807_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H00807_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         H00807_n747ReembolsoFlowLogDate = new bool[] {false} ;
         H00807_A754ReembolsoWorkflowConvenioSLA = new short[1] ;
         H00807_n754ReembolsoWorkflowConvenioSLA = new bool[] {false} ;
         H00807_A760LogReembolsoStatusAtual_F = new string[] {""} ;
         H00807_n760LogReembolsoStatusAtual_F = new bool[] {false} ;
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV36ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV34Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV81AuxText = "";
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
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcreembolsoflowlog__default(),
            new Object[][] {
                new Object[] {
               H00804_A558ReembolsoPropostaPacienteClienteId, H00804_n558ReembolsoPropostaPacienteClienteId, H00804_A758ReembolsoPropostaClinicaId, H00804_n758ReembolsoPropostaClinicaId, H00804_A542ReembolsoPropostaId, H00804_n542ReembolsoPropostaId, H00804_A761ReembolsoFlowLogDataFinal, H00804_n761ReembolsoFlowLogDataFinal, H00804_A763ReembolsoLogProtocolo, H00804_n763ReembolsoLogProtocolo,
               H00804_A755ReembolsoFlowLogDataSLA_F, H00804_A749ReembolsoWorkFlowConvenioId, H00804_n749ReembolsoWorkFlowConvenioId, H00804_A748ReembolsoLogId, H00804_n748ReembolsoLogId, H00804_A745ReembolsoFlowLogUserNome, H00804_n745ReembolsoFlowLogUserNome, H00804_A744ReembolsoFlowLogUser, H00804_n744ReembolsoFlowLogUser, H00804_A752LogWorkflowConvenioDesc,
               H00804_n752LogWorkflowConvenioDesc, H00804_A750LogWorkflowConvenioId, H00804_n750LogWorkflowConvenioId, H00804_A746ReembolsoFlowLogId, H00804_A550ReembolsoPropostaPacienteClienteRazaoSocial, H00804_n550ReembolsoPropostaPacienteClienteRazaoSocial, H00804_A747ReembolsoFlowLogDate, H00804_n747ReembolsoFlowLogDate, H00804_A754ReembolsoWorkflowConvenioSLA, H00804_n754ReembolsoWorkflowConvenioSLA,
               H00804_A760LogReembolsoStatusAtual_F, H00804_n760LogReembolsoStatusAtual_F
               }
               , new Object[] {
               H00807_A558ReembolsoPropostaPacienteClienteId, H00807_n558ReembolsoPropostaPacienteClienteId, H00807_A758ReembolsoPropostaClinicaId, H00807_n758ReembolsoPropostaClinicaId, H00807_A542ReembolsoPropostaId, H00807_n542ReembolsoPropostaId, H00807_A761ReembolsoFlowLogDataFinal, H00807_n761ReembolsoFlowLogDataFinal, H00807_A763ReembolsoLogProtocolo, H00807_n763ReembolsoLogProtocolo,
               H00807_A755ReembolsoFlowLogDataSLA_F, H00807_A749ReembolsoWorkFlowConvenioId, H00807_n749ReembolsoWorkFlowConvenioId, H00807_A748ReembolsoLogId, H00807_n748ReembolsoLogId, H00807_A745ReembolsoFlowLogUserNome, H00807_n745ReembolsoFlowLogUserNome, H00807_A744ReembolsoFlowLogUser, H00807_n744ReembolsoFlowLogUser, H00807_A752LogWorkflowConvenioDesc,
               H00807_n752LogWorkflowConvenioDesc, H00807_A750LogWorkflowConvenioId, H00807_n750LogWorkflowConvenioId, H00807_A746ReembolsoFlowLogId, H00807_A550ReembolsoPropostaPacienteClienteRazaoSocial, H00807_n550ReembolsoPropostaPacienteClienteRazaoSocial, H00807_A747ReembolsoFlowLogDate, H00807_n747ReembolsoFlowLogDate, H00807_A754ReembolsoWorkflowConvenioSLA, H00807_n754ReembolsoWorkflowConvenioSLA,
               H00807_A760LogReembolsoStatusAtual_F, H00807_n760LogReembolsoStatusAtual_F
               }
            }
         );
         AV97Pgmname = "WcReembolsoFlowLog";
         /* GeneXus formulas. */
         AV97Pgmname = "WcReembolsoFlowLog";
         edtavReembolso_Enabled = 0;
         edtavConsulta_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV37ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A744ReembolsoFlowLogUser ;
      private short A754ReembolsoWorkflowConvenioSLA ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 ;
      private short AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 ;
      private short AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 ;
      private short AV6WWPContext_gxTpr_Secuserclienteid ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_119 ;
      private int nGXsfl_119_idx=1 ;
      private int edtavReembolso_Enabled ;
      private int edtavConsulta_Enabled ;
      private int A542ReembolsoPropostaId ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A746ReembolsoFlowLogId ;
      private int A750LogWorkflowConvenioId ;
      private int A748ReembolsoLogId ;
      private int A749ReembolsoWorkFlowConvenioId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels_Count ;
      private int A758ReembolsoPropostaClinicaId ;
      private int A558ReembolsoPropostaPacienteClienteId ;
      private int edtReembolsoPropostaPacienteClienteRazaoSocial_Enabled ;
      private int edtReembolsoFlowLogId_Enabled ;
      private int edtLogWorkflowConvenioId_Enabled ;
      private int edtLogWorkflowConvenioDesc_Enabled ;
      private int edtReembolsoFlowLogDate_Enabled ;
      private int edtReembolsoFlowLogUser_Enabled ;
      private int edtReembolsoFlowLogUserNome_Enabled ;
      private int edtReembolsoLogId_Enabled ;
      private int edtReembolsoWorkFlowConvenioId_Enabled ;
      private int edtReembolsoWorkflowConvenioSLA_Enabled ;
      private int edtReembolsoFlowLogDataSLA_F_Enabled ;
      private int edtReembolsoLogProtocolo_Enabled ;
      private int edtReembolsoFlowLogDataFinal_Enabled ;
      private int AV74PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavLogworkflowconveniodesc1_Visible ;
      private int edtavReembolsoflowlogusernome1_Visible ;
      private int edtavReembolsopaciente1_Visible ;
      private int edtavLogworkflowconveniodesc2_Visible ;
      private int edtavReembolsoflowlogusernome2_Visible ;
      private int edtavReembolsopaciente2_Visible ;
      private int edtavLogworkflowconveniodesc3_Visible ;
      private int edtavReembolsoflowlogusernome3_Visible ;
      private int edtavReembolsopaciente3_Visible ;
      private int AV127GXV1 ;
      private int edtavLogworkflowconveniodesc3_Enabled ;
      private int edtavReembolsoflowlogusernome3_Enabled ;
      private int edtavReembolsopaciente3_Enabled ;
      private int edtavLogworkflowconveniodesc2_Enabled ;
      private int edtavReembolsoflowlogusernome2_Enabled ;
      private int edtavReembolsopaciente2_Enabled ;
      private int edtavLogworkflowconveniodesc1_Enabled ;
      private int edtavReembolsoflowlogusernome1_Enabled ;
      private int edtavReembolsopaciente1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV75GridCurrentPage ;
      private long AV76GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_119_idx="0001" ;
      private string AV97Pgmname ;
      private string edtavReembolso_Internalname ;
      private string edtavConsulta_Internalname ;
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
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string TempTags ;
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
      private string ClassString ;
      private string StyleString ;
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
      private string divDdo_reembolsoflowlogdateauxdates_Internalname ;
      private string edtavDdo_reembolsoflowlogdateauxdatetext_Internalname ;
      private string edtavDdo_reembolsoflowlogdateauxdatetext_Jsonclick ;
      private string Tfreembolsoflowlogdate_rangepicker_Internalname ;
      private string divDdo_reembolsoflowlogdatasla_fauxdates_Internalname ;
      private string edtavDdo_reembolsoflowlogdatasla_fauxdatetext_Internalname ;
      private string edtavDdo_reembolsoflowlogdatasla_fauxdatetext_Jsonclick ;
      private string Tfreembolsoflowlogdatasla_f_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV92Reembolso ;
      private string AV93Consulta ;
      private string edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname ;
      private string edtReembolsoFlowLogId_Internalname ;
      private string edtLogWorkflowConvenioId_Internalname ;
      private string edtLogWorkflowConvenioDesc_Internalname ;
      private string edtReembolsoFlowLogDate_Internalname ;
      private string edtReembolsoFlowLogUser_Internalname ;
      private string edtReembolsoFlowLogUserNome_Internalname ;
      private string edtReembolsoLogId_Internalname ;
      private string edtReembolsoWorkFlowConvenioId_Internalname ;
      private string edtReembolsoWorkflowConvenioSLA_Internalname ;
      private string cmbLogReembolsoStatusAtual_F_Internalname ;
      private string edtReembolsoFlowLogDataSLA_F_Internalname ;
      private string edtReembolsoLogProtocolo_Internalname ;
      private string edtReembolsoFlowLogDataFinal_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavLogworkflowconveniodesc1_Internalname ;
      private string edtavReembolsoflowlogusernome1_Internalname ;
      private string edtavReembolsopaciente1_Internalname ;
      private string edtavLogworkflowconveniodesc2_Internalname ;
      private string edtavReembolsoflowlogusernome2_Internalname ;
      private string edtavReembolsopaciente2_Internalname ;
      private string edtavLogworkflowconveniodesc3_Internalname ;
      private string edtavReembolsoflowlogusernome3_Internalname ;
      private string edtavReembolsopaciente3_Internalname ;
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
      private string cmbLogReembolsoStatusAtual_F_Columnheaderclass ;
      private string edtavReembolso_Link ;
      private string GXEncryptionTmp ;
      private string edtavReembolso_Class ;
      private string edtavConsulta_Link ;
      private string edtavConsulta_Class ;
      private string cmbLogReembolsoStatusAtual_F_Columnclass ;
      private string GXt_char3 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_logworkflowconveniodesc3_cell_Internalname ;
      private string edtavLogworkflowconveniodesc3_Jsonclick ;
      private string cellFilter_reembolsoflowlogusernome3_cell_Internalname ;
      private string edtavReembolsoflowlogusernome3_Jsonclick ;
      private string cellFilter_reembolsopaciente3_cell_Internalname ;
      private string edtavReembolsopaciente3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_logworkflowconveniodesc2_cell_Internalname ;
      private string edtavLogworkflowconveniodesc2_Jsonclick ;
      private string cellFilter_reembolsoflowlogusernome2_cell_Internalname ;
      private string edtavReembolsoflowlogusernome2_Jsonclick ;
      private string cellFilter_reembolsopaciente2_cell_Internalname ;
      private string edtavReembolsopaciente2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_logworkflowconveniodesc1_cell_Internalname ;
      private string edtavLogworkflowconveniodesc1_Jsonclick ;
      private string cellFilter_reembolsoflowlogusernome1_cell_Internalname ;
      private string edtavReembolsoflowlogusernome1_Jsonclick ;
      private string cellFilter_reembolsopaciente1_cell_Internalname ;
      private string edtavReembolsopaciente1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_119_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavReembolso_Jsonclick ;
      private string edtavConsulta_Jsonclick ;
      private string edtReembolsoPropostaPacienteClienteRazaoSocial_Jsonclick ;
      private string edtReembolsoFlowLogId_Jsonclick ;
      private string edtLogWorkflowConvenioId_Jsonclick ;
      private string edtLogWorkflowConvenioDesc_Jsonclick ;
      private string edtReembolsoFlowLogDate_Jsonclick ;
      private string edtReembolsoFlowLogUser_Jsonclick ;
      private string edtReembolsoFlowLogUserNome_Jsonclick ;
      private string edtReembolsoLogId_Jsonclick ;
      private string edtReembolsoWorkFlowConvenioId_Jsonclick ;
      private string edtReembolsoWorkflowConvenioSLA_Jsonclick ;
      private string GXCCtl ;
      private string cmbLogReembolsoStatusAtual_F_Jsonclick ;
      private string edtReembolsoFlowLogDataSLA_F_Jsonclick ;
      private string edtReembolsoLogProtocolo_Jsonclick ;
      private string edtReembolsoFlowLogDataFinal_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV48TFReembolsoFlowLogDate ;
      private DateTime AV49TFReembolsoFlowLogDate_To ;
      private DateTime AV63TFReembolsoFlowLogDataSLA_F ;
      private DateTime AV64TFReembolsoFlowLogDataSLA_F_To ;
      private DateTime A747ReembolsoFlowLogDate ;
      private DateTime A755ReembolsoFlowLogDataSLA_F ;
      private DateTime A761ReembolsoFlowLogDataFinal ;
      private DateTime AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate ;
      private DateTime AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to ;
      private DateTime AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f ;
      private DateTime AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to ;
      private DateTime AV50DDO_ReembolsoFlowLogDateAuxDate ;
      private DateTime AV51DDO_ReembolsoFlowLogDateAuxDateTo ;
      private DateTime AV65DDO_ReembolsoFlowLogDataSLA_FAuxDate ;
      private DateTime AV66DDO_ReembolsoFlowLogDataSLA_FAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV31DynamicFiltersIgnoreFirst ;
      private bool AV30DynamicFiltersRemoving ;
      private bool bGXsfl_119_Refreshing=false ;
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
      private bool n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool n750LogWorkflowConvenioId ;
      private bool n752LogWorkflowConvenioDesc ;
      private bool n747ReembolsoFlowLogDate ;
      private bool n744ReembolsoFlowLogUser ;
      private bool n745ReembolsoFlowLogUserNome ;
      private bool n748ReembolsoLogId ;
      private bool n749ReembolsoWorkFlowConvenioId ;
      private bool n754ReembolsoWorkflowConvenioSLA ;
      private bool n760LogReembolsoStatusAtual_F ;
      private bool n763ReembolsoLogProtocolo ;
      private bool n761ReembolsoFlowLogDataFinal ;
      private bool AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 ;
      private bool AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 ;
      private bool n558ReembolsoPropostaPacienteClienteId ;
      private bool n758ReembolsoPropostaClinicaId ;
      private bool n542ReembolsoPropostaId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV82TFLogReembolsoStatusAtual_F_SelsJson ;
      private string AV36ManageFiltersXml ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18LogWorkflowConvenioDesc1 ;
      private string AV19ReembolsoFlowLogUserNome1 ;
      private string AV94ReembolsoPaciente1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV23LogWorkflowConvenioDesc2 ;
      private string AV24ReembolsoFlowLogUserNome2 ;
      private string AV95ReembolsoPaciente2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28LogWorkflowConvenioDesc3 ;
      private string AV29ReembolsoFlowLogUserNome3 ;
      private string AV96ReembolsoPaciente3 ;
      private string AV15FilterFullText ;
      private string AV90TFReembolsoPropostaPacienteClienteRazaoSocial ;
      private string AV91TFReembolsoPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV42TFLogWorkflowConvenioDesc ;
      private string AV43TFLogWorkflowConvenioDesc_Sel ;
      private string AV84TFReembolsoLogProtocolo ;
      private string AV85TFReembolsoLogProtocolo_Sel ;
      private string AV77GridAppliedFilters ;
      private string A548ReembolsoStatusAtual_F ;
      private string AV52DDO_ReembolsoFlowLogDateAuxDateText ;
      private string AV67DDO_ReembolsoFlowLogDataSLA_FAuxDateText ;
      private string A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string A752LogWorkflowConvenioDesc ;
      private string A745ReembolsoFlowLogUserNome ;
      private string A760LogReembolsoStatusAtual_F ;
      private string A763ReembolsoLogProtocolo ;
      private string AV98Wcreembolsoflowlogds_1_filterfulltext ;
      private string AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 ;
      private string AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ;
      private string AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ;
      private string AV103Wcreembolsoflowlogds_6_reembolsopaciente1 ;
      private string AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 ;
      private string AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ;
      private string AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ;
      private string AV109Wcreembolsoflowlogds_12_reembolsopaciente2 ;
      private string AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 ;
      private string AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ;
      private string AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ;
      private string AV115Wcreembolsoflowlogds_18_reembolsopaciente3 ;
      private string AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ;
      private string AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel ;
      private string AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ;
      private string AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel ;
      private string AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo ;
      private string AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel ;
      private string lV98Wcreembolsoflowlogds_1_filterfulltext ;
      private string lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ;
      private string lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ;
      private string lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ;
      private string lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ;
      private string lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ;
      private string lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ;
      private string lV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ;
      private string lV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ;
      private string lV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo ;
      private string A764ReembolsoPaciente ;
      private string AV81AuxText ;
      private IGxSession AV34Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfreembolsoflowlogdate_rangepicker ;
      private GXUserControl ucTfreembolsoflowlogdatasla_f_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbLogReembolsoStatusAtual_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GxSimpleCollection<string> AV83TFLogReembolsoStatusAtual_F_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV35ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV73DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels ;
      private IDataStoreProvider pr_default ;
      private int[] H00804_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] H00804_n558ReembolsoPropostaPacienteClienteId ;
      private int[] H00804_A758ReembolsoPropostaClinicaId ;
      private bool[] H00804_n758ReembolsoPropostaClinicaId ;
      private int[] H00804_A542ReembolsoPropostaId ;
      private bool[] H00804_n542ReembolsoPropostaId ;
      private DateTime[] H00804_A761ReembolsoFlowLogDataFinal ;
      private bool[] H00804_n761ReembolsoFlowLogDataFinal ;
      private string[] H00804_A763ReembolsoLogProtocolo ;
      private bool[] H00804_n763ReembolsoLogProtocolo ;
      private DateTime[] H00804_A755ReembolsoFlowLogDataSLA_F ;
      private int[] H00804_A749ReembolsoWorkFlowConvenioId ;
      private bool[] H00804_n749ReembolsoWorkFlowConvenioId ;
      private int[] H00804_A748ReembolsoLogId ;
      private bool[] H00804_n748ReembolsoLogId ;
      private string[] H00804_A745ReembolsoFlowLogUserNome ;
      private bool[] H00804_n745ReembolsoFlowLogUserNome ;
      private short[] H00804_A744ReembolsoFlowLogUser ;
      private bool[] H00804_n744ReembolsoFlowLogUser ;
      private string[] H00804_A752LogWorkflowConvenioDesc ;
      private bool[] H00804_n752LogWorkflowConvenioDesc ;
      private int[] H00804_A750LogWorkflowConvenioId ;
      private bool[] H00804_n750LogWorkflowConvenioId ;
      private int[] H00804_A746ReembolsoFlowLogId ;
      private string[] H00804_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] H00804_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private DateTime[] H00804_A747ReembolsoFlowLogDate ;
      private bool[] H00804_n747ReembolsoFlowLogDate ;
      private short[] H00804_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] H00804_n754ReembolsoWorkflowConvenioSLA ;
      private string[] H00804_A760LogReembolsoStatusAtual_F ;
      private bool[] H00804_n760LogReembolsoStatusAtual_F ;
      private int[] H00807_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] H00807_n558ReembolsoPropostaPacienteClienteId ;
      private int[] H00807_A758ReembolsoPropostaClinicaId ;
      private bool[] H00807_n758ReembolsoPropostaClinicaId ;
      private int[] H00807_A542ReembolsoPropostaId ;
      private bool[] H00807_n542ReembolsoPropostaId ;
      private DateTime[] H00807_A761ReembolsoFlowLogDataFinal ;
      private bool[] H00807_n761ReembolsoFlowLogDataFinal ;
      private string[] H00807_A763ReembolsoLogProtocolo ;
      private bool[] H00807_n763ReembolsoLogProtocolo ;
      private DateTime[] H00807_A755ReembolsoFlowLogDataSLA_F ;
      private int[] H00807_A749ReembolsoWorkFlowConvenioId ;
      private bool[] H00807_n749ReembolsoWorkFlowConvenioId ;
      private int[] H00807_A748ReembolsoLogId ;
      private bool[] H00807_n748ReembolsoLogId ;
      private string[] H00807_A745ReembolsoFlowLogUserNome ;
      private bool[] H00807_n745ReembolsoFlowLogUserNome ;
      private short[] H00807_A744ReembolsoFlowLogUser ;
      private bool[] H00807_n744ReembolsoFlowLogUser ;
      private string[] H00807_A752LogWorkflowConvenioDesc ;
      private bool[] H00807_n752LogWorkflowConvenioDesc ;
      private int[] H00807_A750LogWorkflowConvenioId ;
      private bool[] H00807_n750LogWorkflowConvenioId ;
      private int[] H00807_A746ReembolsoFlowLogId ;
      private string[] H00807_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] H00807_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private DateTime[] H00807_A747ReembolsoFlowLogDate ;
      private bool[] H00807_n747ReembolsoFlowLogDate ;
      private short[] H00807_A754ReembolsoWorkflowConvenioSLA ;
      private bool[] H00807_n754ReembolsoWorkflowConvenioSLA ;
      private string[] H00807_A760LogReembolsoStatusAtual_F ;
      private bool[] H00807_n760LogReembolsoStatusAtual_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wcreembolsoflowlog__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00804( IGxContext context ,
                                             string A760LogReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels ,
                                             string AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 ,
                                             short AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 ,
                                             string AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ,
                                             string AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ,
                                             string AV103Wcreembolsoflowlogds_6_reembolsopaciente1 ,
                                             bool AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 ,
                                             string AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 ,
                                             short AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 ,
                                             string AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ,
                                             string AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ,
                                             string AV109Wcreembolsoflowlogds_12_reembolsopaciente2 ,
                                             bool AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 ,
                                             string AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 ,
                                             short AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 ,
                                             string AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ,
                                             string AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ,
                                             string AV115Wcreembolsoflowlogds_18_reembolsopaciente3 ,
                                             string AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                             string AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ,
                                             string AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel ,
                                             string AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ,
                                             DateTime AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate ,
                                             DateTime AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to ,
                                             DateTime AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f ,
                                             DateTime AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to ,
                                             string AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel ,
                                             string AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo ,
                                             short AV6WWPContext_gxTpr_Secuserclienteid ,
                                             string A752LogWorkflowConvenioDesc ,
                                             string A745ReembolsoFlowLogUserNome ,
                                             string A764ReembolsoPaciente ,
                                             string A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                             DateTime A747ReembolsoFlowLogDate ,
                                             short A754ReembolsoWorkflowConvenioSLA ,
                                             string A763ReembolsoLogProtocolo ,
                                             int A758ReembolsoPropostaClinicaId ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV98Wcreembolsoflowlogds_1_filterfulltext ,
                                             int AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels_Count ,
                                             DateTime A755ReembolsoFlowLogDataSLA_F ,
                                             int A749ReembolsoWorkFlowConvenioId ,
                                             int A750LogWorkflowConvenioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[35];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T3.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T3.PropostaClinicaId AS ReembolsoPropostaClinicaId, T2.ReembolsoPropostaId AS ReembolsoPropostaId, T1.ReembolsoFlowLogDataFinal, T2.ReembolsoProtocolo AS ReembolsoLogProtocolo, (COALESCE( T1.ReembolsoFlowLogDate, DATE '00010101') + CAST (86400 * CAST(( COALESCE( T5.WorkflowConvenioSLA, 0)) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) AS ReembolsoFlowLogDataSLA_F, T2.WorkflowConvenioId AS ReembolsoWorkFlowConvenioId, T1.ReembolsoLogId AS ReembolsoLogId, T7.SecUserName AS ReembolsoFlowLogUserNome, T1.ReembolsoFlowLogUser AS ReembolsoFlowLogUser, T8.WorkflowConvenioDesc AS LogWorkflowConvenioDesc, T1.LogWorkflowConvenioId AS LogWorkflowConvenioId, T1.ReembolsoFlowLogId, T4.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T1.ReembolsoFlowLogDate, T5.WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA, COALESCE( T6.ReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F";
         sFromString = " FROM (((((((ReembolsoFlowLog T1 LEFT JOIN Reembolso T2 ON T2.ReembolsoId = T1.ReembolsoLogId) LEFT JOIN Proposta T3 ON T3.PropostaId = T2.ReembolsoPropostaId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.PropostaPacienteClienteId) LEFT JOIN WorkflowConvenio T5 ON T5.WorkflowConvenioId = T2.WorkflowConvenioId) LEFT JOIN LATERAL (SELECT MIN(T9.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T9.ReembolsoId FROM (ReembolsoEtapa T9 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T9.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T10 ON T10.ReembolsoId = T9.ReembolsoId) WHERE (T1.ReembolsoLogId = T9.ReembolsoId) AND (T9.ReembolsoEtapaCreatedAt = COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T10.ReembolsoEtapaUltimo_F, T9.ReembolsoId ) T6 ON T6.ReembolsoId = T1.ReembolsoLogId) LEFT JOIN SecUser T7 ON T7.SecUserId = T1.ReembolsoFlowLogUser) LEFT JOIN WorkflowConvenio T8 ON T8.WorkflowConvenioId = T1.LogWorkflowConvenioId)";
         sOrderString = "";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV98Wcreembolsoflowlogds_1_filterfulltext))=0) or ( ( T4.ClienteRazaoSocial like '%' || :lV98Wcreembolsoflowlogds_1_filterfulltext) or ( T8.WorkflowConvenioDesc like '%' || :lV98Wcreembolsoflowlogds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV98Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T6.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV98Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T6.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV98Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T6.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV98Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T6.ReembolsoStatusAtual_F, '') = ( '')) or ( T2.ReembolsoProtocolo like '%' || :lV98Wcreembolsoflowlogds_1_filterfulltext)))");
         AddWhere(sWhereString, "(:AV122WcrCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels, "COALESCE( T6.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "((COALESCE( T1.ReembolsoFlowLogDate, DATE '00010101') + CAST (86400 * CAST(( COALESCE( T5.WorkflowConvenioSLA, 0)) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) < NOW())");
         AddWhere(sWhereString, "(T2.WorkflowConvenioId = T1.LogWorkflowConvenioId)");
         AddWhere(sWhereString, "(COALESCE( T6.ReembolsoStatusAtual_F, '') <> ( 'FINALIZADO'))");
         if ( ( StringUtil.StrCmp(AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV116Wcreembolsoflowlogds_19_tfreembolsopropostapacientecliente)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacientecliente))");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( StringUtil.StrCmp(AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc = ( :AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( StringUtil.StrCmp(AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T8.WorkflowConvenioDesc))=0))");
         }
         if ( ! (DateTime.MinValue==AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate >= :AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate <= :AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f) )
         {
            AddWhere(sWhereString, "((T1.ReembolsoFlowLogDate + CAST (86400 * CAST(( T5.WorkflowConvenioSLA) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) >= :AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to) )
         {
            AddWhere(sWhereString, "((T1.ReembolsoFlowLogDate + CAST (86400 * CAST(( T5.WorkflowConvenioSLA) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) <= :AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T2.ReembolsoProtocolo like :lV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel)) && ! ( StringUtil.StrCmp(AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ReembolsoProtocolo = ( :AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel))");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( StringUtil.StrCmp(AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ReembolsoProtocolo IS NULL or (char_length(trim(trailing ' ' from T2.ReembolsoProtocolo))=0))");
         }
         if ( ! (0==AV6WWPContext_gxTpr_Secuserclienteid) )
         {
            AddWhere(sWhereString, "(T3.PropostaClinicaId = :AV6WWPCo_2Secuserclienteid)");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY ReembolsoFlowLogDataSLA_F DESC, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T4.ClienteRazaoSocial, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T4.ClienteRazaoSocial DESC, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T8.WorkflowConvenioDesc, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T8.WorkflowConvenioDesc DESC, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ReembolsoFlowLogDate, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ReembolsoFlowLogDate DESC, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T6.ReembolsoStatusAtual_F, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T6.ReembolsoStatusAtual_F DESC, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ReembolsoProtocolo, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ReembolsoProtocolo DESC, T1.ReembolsoFlowLogId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.ReembolsoFlowLogId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H00807( IGxContext context ,
                                             string A760LogReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels ,
                                             string AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1 ,
                                             short AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 ,
                                             string AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1 ,
                                             string AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1 ,
                                             string AV103Wcreembolsoflowlogds_6_reembolsopaciente1 ,
                                             bool AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 ,
                                             string AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2 ,
                                             short AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 ,
                                             string AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2 ,
                                             string AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2 ,
                                             string AV109Wcreembolsoflowlogds_12_reembolsopaciente2 ,
                                             bool AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 ,
                                             string AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3 ,
                                             short AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 ,
                                             string AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3 ,
                                             string AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3 ,
                                             string AV115Wcreembolsoflowlogds_18_reembolsopaciente3 ,
                                             string AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                             string AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial ,
                                             string AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel ,
                                             string AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc ,
                                             DateTime AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate ,
                                             DateTime AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to ,
                                             DateTime AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f ,
                                             DateTime AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to ,
                                             string AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel ,
                                             string AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo ,
                                             short AV6WWPContext_gxTpr_Secuserclienteid ,
                                             string A752LogWorkflowConvenioDesc ,
                                             string A745ReembolsoFlowLogUserNome ,
                                             string A764ReembolsoPaciente ,
                                             string A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                             DateTime A747ReembolsoFlowLogDate ,
                                             short A754ReembolsoWorkflowConvenioSLA ,
                                             string A763ReembolsoLogProtocolo ,
                                             int A758ReembolsoPropostaClinicaId ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV98Wcreembolsoflowlogds_1_filterfulltext ,
                                             int AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels_Count ,
                                             DateTime A755ReembolsoFlowLogDataSLA_F ,
                                             int A749ReembolsoWorkFlowConvenioId ,
                                             int A750LogWorkflowConvenioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[35];
         Object[] GXv_Object11 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T3.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T3.PropostaClinicaId AS ReembolsoPropostaClinicaId, T2.ReembolsoPropostaId AS ReembolsoPropostaId, T1.ReembolsoFlowLogDataFinal, T2.ReembolsoProtocolo AS ReembolsoLogProtocolo, (COALESCE( T1.ReembolsoFlowLogDate, DATE '00010101') + CAST (86400 * CAST(( COALESCE( T5.WorkflowConvenioSLA, 0)) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) AS ReembolsoFlowLogDataSLA_F, T2.WorkflowConvenioId AS ReembolsoWorkFlowConvenioId, T1.ReembolsoLogId AS ReembolsoLogId, T7.SecUserName AS ReembolsoFlowLogUserNome, T1.ReembolsoFlowLogUser AS ReembolsoFlowLogUser, T8.WorkflowConvenioDesc AS LogWorkflowConvenioDesc, T1.LogWorkflowConvenioId AS LogWorkflowConvenioId, T1.ReembolsoFlowLogId, T4.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T1.ReembolsoFlowLogDate, T5.WorkflowConvenioSLA AS ReembolsoWorkflowConvenioSLA, COALESCE( T6.ReembolsoStatusAtual_F, '') AS LogReembolsoStatusAtual_F";
         sFromString = " FROM (((((((ReembolsoFlowLog T1 LEFT JOIN Reembolso T2 ON T2.ReembolsoId = T1.ReembolsoLogId) LEFT JOIN Proposta T3 ON T3.PropostaId = T2.ReembolsoPropostaId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.PropostaPacienteClienteId) LEFT JOIN WorkflowConvenio T5 ON T5.WorkflowConvenioId = T2.WorkflowConvenioId) LEFT JOIN LATERAL (SELECT MIN(T9.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T9.ReembolsoId FROM (ReembolsoEtapa T9 LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T9.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T10 ON T10.ReembolsoId = T9.ReembolsoId) WHERE (T1.ReembolsoLogId = T9.ReembolsoId) AND (T9.ReembolsoEtapaCreatedAt = COALESCE( T10.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T10.ReembolsoEtapaUltimo_F, T9.ReembolsoId ) T6 ON T6.ReembolsoId = T1.ReembolsoLogId) LEFT JOIN SecUser T7 ON T7.SecUserId = T1.ReembolsoFlowLogUser) LEFT JOIN WorkflowConvenio T8 ON T8.WorkflowConvenioId = T1.LogWorkflowConvenioId)";
         sOrderString = "";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV98Wcreembolsoflowlogds_1_filterfulltext))=0) or ( ( T4.ClienteRazaoSocial like '%' || :lV98Wcreembolsoflowlogds_1_filterfulltext) or ( T8.WorkflowConvenioDesc like '%' || :lV98Wcreembolsoflowlogds_1_filterfulltext) or ( 'em análise' like '%' || LOWER(:lV98Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T6.ReembolsoStatusAtual_F, '') = ( 'EM_ANALISE')) or ( 'finalizado' like '%' || LOWER(:lV98Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T6.ReembolsoStatusAtual_F, '') = ( 'FINALIZADO')) or ( 'reanálise' like '%' || LOWER(:lV98Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T6.ReembolsoStatusAtual_F, '') = ( 'REANALISE')) or ( 'não iniciado' like '%' || LOWER(:lV98Wcreembolsoflowlogds_1_filterfulltext) and COALESCE( T6.ReembolsoStatusAtual_F, '') = ( '')) or ( T2.ReembolsoProtocolo like '%' || :lV98Wcreembolsoflowlogds_1_filterfulltext)))");
         AddWhere(sWhereString, "(:AV122WcrCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV122Wcreembolsoflowlogds_25_tflogreembolsostatusatual_f_sels, "COALESCE( T6.ReembolsoStatusAtual_F, '') IN (", ")")+"))");
         AddWhere(sWhereString, "((COALESCE( T1.ReembolsoFlowLogDate, DATE '00010101') + CAST (86400 * CAST(( COALESCE( T5.WorkflowConvenioSLA, 0)) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) < NOW())");
         AddWhere(sWhereString, "(T2.WorkflowConvenioId = T1.LogWorkflowConvenioId)");
         AddWhere(sWhereString, "(COALESCE( T6.ReembolsoStatusAtual_F, '') <> ( 'FINALIZADO'))");
         if ( ( StringUtil.StrCmp(AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV99Wcreembolsoflowlogds_2_dynamicfiltersselector1, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV100Wcreembolsoflowlogds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( AV104Wcreembolsoflowlogds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wcreembolsoflowlogds_8_dynamicfiltersselector2, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV106Wcreembolsoflowlogds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3, "LOGWORKFLOWCONVENIODESC") == 0 ) && ( AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like '%' || :lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( AV110Wcreembolsoflowlogds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV111Wcreembolsoflowlogds_14_dynamicfiltersselector3, "REEMBOLSOFLOWLOGUSERNOME") == 0 ) && ( AV112Wcreembolsoflowlogds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wcreembolsoflowlogds_19_tfreembolsopropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV116Wcreembolsoflowlogds_19_tfreembolsopropostapacientecliente)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacientecliente))");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( StringUtil.StrCmp(AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc like :lV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc = ( :AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( StringUtil.StrCmp(AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T8.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T8.WorkflowConvenioDesc))=0))");
         }
         if ( ! (DateTime.MinValue==AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate >= :AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate <= :AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f) )
         {
            AddWhere(sWhereString, "((T1.ReembolsoFlowLogDate + CAST (86400 * CAST(( T5.WorkflowConvenioSLA) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) >= :AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to) )
         {
            AddWhere(sWhereString, "((T1.ReembolsoFlowLogDate + CAST (86400 * CAST(( T5.WorkflowConvenioSLA) AS NUMERIC(15,10)) || ' SECOND' AS INTERVAL)) <= :AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to)");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T2.ReembolsoProtocolo like :lV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel)) && ! ( StringUtil.StrCmp(AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ReembolsoProtocolo = ( :AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel))");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( StringUtil.StrCmp(AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ReembolsoProtocolo IS NULL or (char_length(trim(trailing ' ' from T2.ReembolsoProtocolo))=0))");
         }
         if ( ! (0==AV6WWPContext_gxTpr_Secuserclienteid) )
         {
            AddWhere(sWhereString, "(T3.PropostaClinicaId = :AV6WWPCo_2Secuserclienteid)");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY ReembolsoFlowLogDataSLA_F DESC, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T4.ClienteRazaoSocial, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T4.ClienteRazaoSocial DESC, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T8.WorkflowConvenioDesc, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T8.WorkflowConvenioDesc DESC, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ReembolsoFlowLogDate, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ReembolsoFlowLogDate DESC, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T6.ReembolsoStatusAtual_F, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T6.ReembolsoStatusAtual_F DESC, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ReembolsoProtocolo, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ReembolsoProtocolo DESC, T1.ReembolsoFlowLogId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.ReembolsoFlowLogId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00804(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] , (string)dynConstraints[40] , (int)dynConstraints[41] , (DateTime)dynConstraints[42] , (int)dynConstraints[43] , (int)dynConstraints[44] );
               case 1 :
                     return conditional_H00807(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] , (string)dynConstraints[40] , (int)dynConstraints[41] , (DateTime)dynConstraints[42] , (int)dynConstraints[43] , (int)dynConstraints[44] );
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
          Object[] prmH00804;
          prmH00804 = new Object[] {
          new ParDef("AV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV122WcrCount",GXType.Int32,9,0) ,
          new ParDef("lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1",GXType.VarChar,100,0) ,
          new ParDef("lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1",GXType.VarChar,100,0) ,
          new ParDef("lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2",GXType.VarChar,100,0) ,
          new ParDef("lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2",GXType.VarChar,100,0) ,
          new ParDef("lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3",GXType.VarChar,100,0) ,
          new ParDef("lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3",GXType.VarChar,100,0) ,
          new ParDef("lV116Wcreembolsoflowlogds_19_tfreembolsopropostapacientecliente",GXType.VarChar,150,0) ,
          new ParDef("AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacientecliente",GXType.VarChar,150,0) ,
          new ParDef("lV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate",GXType.DateTime,8,5) ,
          new ParDef("AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to",GXType.DateTime,8,5) ,
          new ParDef("AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f",GXType.DateTime,8,5) ,
          new ParDef("AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to",GXType.DateTime,8,5) ,
          new ParDef("lV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("AV6WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00807;
          prmH00807 = new Object[] {
          new ParDef("AV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV98Wcreembolsoflowlogds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV122WcrCount",GXType.Int32,9,0) ,
          new ParDef("lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV101Wcreembolsoflowlogds_4_logworkflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1",GXType.VarChar,100,0) ,
          new ParDef("lV102Wcreembolsoflowlogds_5_reembolsoflowlogusernome1",GXType.VarChar,100,0) ,
          new ParDef("lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV107Wcreembolsoflowlogds_10_logworkflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2",GXType.VarChar,100,0) ,
          new ParDef("lV108Wcreembolsoflowlogds_11_reembolsoflowlogusernome2",GXType.VarChar,100,0) ,
          new ParDef("lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV113Wcreembolsoflowlogds_16_logworkflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3",GXType.VarChar,100,0) ,
          new ParDef("lV114Wcreembolsoflowlogds_17_reembolsoflowlogusernome3",GXType.VarChar,100,0) ,
          new ParDef("lV116Wcreembolsoflowlogds_19_tfreembolsopropostapacientecliente",GXType.VarChar,150,0) ,
          new ParDef("AV117Wcreembolsoflowlogds_20_tfreembolsopropostapacientecliente",GXType.VarChar,150,0) ,
          new ParDef("lV118Wcreembolsoflowlogds_21_tflogworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV119Wcreembolsoflowlogds_22_tflogworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV120Wcreembolsoflowlogds_23_tfreembolsoflowlogdate",GXType.DateTime,8,5) ,
          new ParDef("AV121Wcreembolsoflowlogds_24_tfreembolsoflowlogdate_to",GXType.DateTime,8,5) ,
          new ParDef("AV123Wcreembolsoflowlogds_26_tfreembolsoflowlogdatasla_f",GXType.DateTime,8,5) ,
          new ParDef("AV124Wcreembolsoflowlogds_27_tfreembolsoflowlogdatasla_f_to",GXType.DateTime,8,5) ,
          new ParDef("lV125Wcreembolsoflowlogds_28_tfreembolsologprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV126Wcreembolsoflowlogds_29_tfreembolsologprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("AV6WWPCo_2Secuserclienteid",GXType.Int16,4,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00804", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00804,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00807", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00807,11, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((string[]) buf[24])[0] = rslt.getVarchar(14);
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(15);
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                ((short[]) buf[28])[0] = rslt.getShort(16);
                ((bool[]) buf[29])[0] = rslt.wasNull(16);
                ((string[]) buf[30])[0] = rslt.getVarchar(17);
                ((bool[]) buf[31])[0] = rslt.wasNull(17);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((string[]) buf[24])[0] = rslt.getVarchar(14);
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(15);
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                ((short[]) buf[28])[0] = rslt.getShort(16);
                ((bool[]) buf[29])[0] = rslt.wasNull(16);
                ((string[]) buf[30])[0] = rslt.getVarchar(17);
                ((bool[]) buf[31])[0] = rslt.wasNull(17);
                return;
       }
    }

 }

}
