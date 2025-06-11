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
   public class reembolsoww : GXDataArea
   {
      public reembolsoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoww( IGxContext context )
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
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbReembolsoStatusAtual_F = new GXCombobox();
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_114 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_114"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_114_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_114_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_114_idx = GetPar( "sGXsfl_114_idx");
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
         AV18ReembolsoPropostaPacienteClienteRazaoSocial1 = GetPar( "ReembolsoPropostaPacienteClienteRazaoSocial1");
         AV67WorkflowConvenioDesc1 = GetPar( "WorkflowConvenioDesc1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV22ReembolsoPropostaPacienteClienteRazaoSocial2 = GetPar( "ReembolsoPropostaPacienteClienteRazaoSocial2");
         AV68WorkflowConvenioDesc2 = GetPar( "WorkflowConvenioDesc2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV26ReembolsoPropostaPacienteClienteRazaoSocial3 = GetPar( "ReembolsoPropostaPacienteClienteRazaoSocial3");
         AV69WorkflowConvenioDesc3 = GetPar( "WorkflowConvenioDesc3");
         AV34ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV70Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV35TFReembolsoPropostaPacienteClienteRazaoSocial = GetPar( "TFReembolsoPropostaPacienteClienteRazaoSocial");
         AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = GetPar( "TFReembolsoPropostaPacienteClienteRazaoSocial_Sel");
         AV37TFReembolsoProtocolo = GetPar( "TFReembolsoProtocolo");
         AV38TFReembolsoProtocolo_Sel = GetPar( "TFReembolsoProtocolo_Sel");
         AV39TFReembolsoCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFReembolsoCreatedAt"));
         AV40TFReembolsoCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFReembolsoCreatedAt_To"));
         AV44TFReembolsoPropostaValor = NumberUtil.Val( GetPar( "TFReembolsoPropostaValor"), ".");
         AV45TFReembolsoPropostaValor_To = NumberUtil.Val( GetPar( "TFReembolsoPropostaValor_To"), ".");
         AV46TFReembolsoDataAberturaConvenio = context.localUtil.ParseDateParm( GetPar( "TFReembolsoDataAberturaConvenio"));
         AV47TFReembolsoDataAberturaConvenio_To = context.localUtil.ParseDateParm( GetPar( "TFReembolsoDataAberturaConvenio_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV57TFReembolsoStatusAtual_F_Sels);
         AV65TFWorkflowConvenioDesc = GetPar( "TFWorkflowConvenioDesc");
         AV66TFWorkflowConvenioDesc_Sel = GetPar( "TFWorkflowConvenioDesc_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV28DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV27DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoPropostaPacienteClienteRazaoSocial1, AV67WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoPropostaPacienteClienteRazaoSocial2, AV68WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoPropostaPacienteClienteRazaoSocial3, AV69WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV70Pgmname, AV15FilterFullText, AV35TFReembolsoPropostaPacienteClienteRazaoSocial, AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV37TFReembolsoProtocolo, AV38TFReembolsoProtocolo_Sel, AV39TFReembolsoCreatedAt, AV40TFReembolsoCreatedAt_To, AV44TFReembolsoPropostaValor, AV45TFReembolsoPropostaValor_To, AV46TFReembolsoDataAberturaConvenio, AV47TFReembolsoDataAberturaConvenio_To, AV57TFReembolsoStatusAtual_F_Sels, AV65TFWorkflowConvenioDesc, AV66TFWorkflowConvenioDesc_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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
         PA7N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7N2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reembolsoww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV70Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV70Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1", AV18ReembolsoPropostaPacienteClienteRazaoSocial1);
         GxWebStd.gx_hidden_field( context, "GXH_vWORKFLOWCONVENIODESC1", AV67WorkflowConvenioDesc1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2", AV22ReembolsoPropostaPacienteClienteRazaoSocial2);
         GxWebStd.gx_hidden_field( context, "GXH_vWORKFLOWCONVENIODESC2", AV68WorkflowConvenioDesc2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3", AV26ReembolsoPropostaPacienteClienteRazaoSocial3);
         GxWebStd.gx_hidden_field( context, "GXH_vWORKFLOWCONVENIODESC3", AV69WorkflowConvenioDesc3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_114", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_114), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV62GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV58DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV58DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_REEMBOLSOCREATEDATAUXDATE", context.localUtil.DToC( AV41DDO_ReembolsoCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_REEMBOLSOCREATEDATAUXDATETO", context.localUtil.DToC( AV42DDO_ReembolsoCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_REEMBOLSODATAABERTURACONVENIOAUXDATE", context.localUtil.DToC( AV48DDO_ReembolsoDataAberturaConvenioAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_REEMBOLSODATAABERTURACONVENIOAUXDATETO", context.localUtil.DToC( AV49DDO_ReembolsoDataAberturaConvenioAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV70Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV70Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", AV35TFReembolsoPropostaPacienteClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL", AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFREEMBOLSOPROTOCOLO", AV37TFReembolsoProtocolo);
         GxWebStd.gx_hidden_field( context, "vTFREEMBOLSOPROTOCOLO_SEL", AV38TFReembolsoProtocolo_Sel);
         GxWebStd.gx_hidden_field( context, "vTFREEMBOLSOCREATEDAT", context.localUtil.TToC( AV39TFReembolsoCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFREEMBOLSOCREATEDAT_TO", context.localUtil.TToC( AV40TFReembolsoCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFREEMBOLSOPROPOSTAVALOR", StringUtil.LTrim( StringUtil.NToC( AV44TFReembolsoPropostaValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFREEMBOLSOPROPOSTAVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV45TFReembolsoPropostaValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFREEMBOLSODATAABERTURACONVENIO", context.localUtil.DToC( AV46TFReembolsoDataAberturaConvenio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFREEMBOLSODATAABERTURACONVENIO_TO", context.localUtil.DToC( AV47TFReembolsoDataAberturaConvenio_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFREEMBOLSOSTATUSATUAL_F_SELS", AV57TFReembolsoStatusAtual_F_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFREEMBOLSOSTATUSATUAL_F_SELS", AV57TFReembolsoStatusAtual_F_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFWORKFLOWCONVENIODESC", AV65TFWorkflowConvenioDesc);
         GxWebStd.gx_hidden_field( context, "vTFWORKFLOWCONVENIODESC_SEL", AV66TFWorkflowConvenioDesc_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV28DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV27DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "WORKFLOWCONVENIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFREEMBOLSOSTATUSATUAL_F_SELSJSON", AV56TFReembolsoStatusAtual_F_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Width", StringUtil.RTrim( Dvpanel_tableheader_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_tableheader_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_tableheader_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Cls", StringUtil.RTrim( Dvpanel_tableheader_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Title", StringUtil.RTrim( Dvpanel_tableheader_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Iconposition", StringUtil.RTrim( Dvpanel_tableheader_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            WE7N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7N2( ) ;
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
         return formatLink("reembolsoww")  ;
      }

      public override string GetPgmname( )
      {
         return "ReembolsoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Reembolso" ;
      }

      protected void WB7N0( )
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
            ucDvpanel_tableheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableheader_Internalname, "DVPANEL_TABLEHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEHEADERContainer"+"TableHeader"+"\" style=\"display:none;\">") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(114), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV32ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ReembolsoWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ReembolsoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_ReembolsoWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ReembolsoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_7N2( true) ;
         }
         else
         {
            wb_table1_43_7N2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_7N2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ReembolsoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_ReembolsoWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ReembolsoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_68_7N2( true) ;
         }
         else
         {
            wb_table2_68_7N2( false) ;
         }
         return  ;
      }

      protected void wb_table2_68_7N2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ReembolsoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_ReembolsoWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ReembolsoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_93_7N2( true) ;
         }
         else
         {
            wb_table3_93_7N2( false) ;
         }
         return  ;
      }

      protected void wb_table3_93_7N2e( bool wbgen )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
            StartGridControl114( ) ;
         }
         if ( wbEnd == 114 )
         {
            wbEnd = 0;
            nRC_GXsfl_114 = (int)(nGXsfl_114_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV60GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV61GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV62GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ReembolsoWW.htm");
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
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV58DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_reembolsocreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_reembolsocreatedatauxdatetext_Internalname, AV43DDO_ReembolsoCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV43DDO_ReembolsoCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_reembolsocreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoWW.htm");
            /* User Defined Control */
            ucTfreembolsocreatedat_rangepicker.SetProperty("Start Date", AV41DDO_ReembolsoCreatedAtAuxDate);
            ucTfreembolsocreatedat_rangepicker.SetProperty("End Date", AV42DDO_ReembolsoCreatedAtAuxDateTo);
            ucTfreembolsocreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfreembolsocreatedat_rangepicker_Internalname, "TFREEMBOLSOCREATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_reembolsodataaberturaconvenioauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_reembolsodataaberturaconvenioauxdatetext_Internalname, AV50DDO_ReembolsoDataAberturaConvenioAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV50DDO_ReembolsoDataAberturaConvenioAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_reembolsodataaberturaconvenioauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoWW.htm");
            /* User Defined Control */
            ucTfreembolsodataaberturaconvenio_rangepicker.SetProperty("Start Date", AV48DDO_ReembolsoDataAberturaConvenioAuxDate);
            ucTfreembolsodataaberturaconvenio_rangepicker.SetProperty("End Date", AV49DDO_ReembolsoDataAberturaConvenioAuxDateTo);
            ucTfreembolsodataaberturaconvenio_rangepicker.Render(context, "wwp.daterangepicker", Tfreembolsodataaberturaconvenio_rangepicker_Internalname, "TFREEMBOLSODATAABERTURACONVENIO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 114 )
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
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START7N2( )
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
         Form.Meta.addItem("description", " Reembolso", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7N0( ) ;
      }

      protected void WS7N2( )
      {
         START7N2( ) ;
         EVT7N2( ) ;
      }

      protected void EVT7N2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E117N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E127N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E137N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E147N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E157N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E167N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E177N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E187N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E197N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E207N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E217N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E227N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E237N2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_114_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
                              SubsflControlProps_1142( ) ;
                              AV64Consulta = cgiGet( edtavConsulta_Internalname);
                              AssignAttri("", false, edtavConsulta_Internalname, AV64Consulta);
                              A518ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n518ReembolsoId = false;
                              A542ReembolsoPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n542ReembolsoPropostaId = false;
                              A550ReembolsoPropostaPacienteClienteRazaoSocial = StringUtil.Upper( cgiGet( edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname));
                              n550ReembolsoPropostaPacienteClienteRazaoSocial = false;
                              A558ReembolsoPropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoPropostaPacienteClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n558ReembolsoPropostaPacienteClienteId = false;
                              A546ReembolsoProtocolo = cgiGet( edtReembolsoProtocolo_Internalname);
                              n546ReembolsoProtocolo = false;
                              A522ReembolsoCreatedAt = context.localUtil.CToT( cgiGet( edtReembolsoCreatedAt_Internalname), 0);
                              n522ReembolsoCreatedAt = false;
                              A543ReembolsoPropostaValor = context.localUtil.CToN( cgiGet( edtReembolsoPropostaValor_Internalname), ",", ".");
                              n543ReembolsoPropostaValor = false;
                              A525ReembolsoDataAberturaConvenio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtReembolsoDataAberturaConvenio_Internalname), 0));
                              n525ReembolsoDataAberturaConvenio = false;
                              A544ReembolsoCreatedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoCreatedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n544ReembolsoCreatedBy = false;
                              A547ReembolsoEtapaUltimo_F = context.localUtil.CToT( cgiGet( edtReembolsoEtapaUltimo_F_Internalname), 0);
                              n547ReembolsoEtapaUltimo_F = false;
                              cmbReembolsoStatusAtual_F.Name = cmbReembolsoStatusAtual_F_Internalname;
                              cmbReembolsoStatusAtual_F.CurrentValue = cgiGet( cmbReembolsoStatusAtual_F_Internalname);
                              A548ReembolsoStatusAtual_F = cgiGet( cmbReembolsoStatusAtual_F_Internalname);
                              n548ReembolsoStatusAtual_F = false;
                              A736WorkflowConvenioDesc = cgiGet( edtWorkflowConvenioDesc_Internalname);
                              n736WorkflowConvenioDesc = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E247N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E257N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E267N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Reembolsopropostapacienteclienterazaosocial1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1"), AV18ReembolsoPropostaPacienteClienteRazaoSocial1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Workflowconveniodesc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vWORKFLOWCONVENIODESC1"), AV67WorkflowConvenioDesc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Reembolsopropostapacienteclienterazaosocial2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2"), AV22ReembolsoPropostaPacienteClienteRazaoSocial2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Workflowconveniodesc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vWORKFLOWCONVENIODESC2"), AV68WorkflowConvenioDesc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Reembolsopropostapacienteclienterazaosocial3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3"), AV26ReembolsoPropostaPacienteClienteRazaoSocial3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Workflowconveniodesc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vWORKFLOWCONVENIODESC3"), AV69WorkflowConvenioDesc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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

      protected void WE7N2( )
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

      protected void PA7N2( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_1142( ) ;
         while ( nGXsfl_114_idx <= nRC_GXsfl_114 )
         {
            sendrow_1142( ) ;
            nGXsfl_114_idx = ((subGrid_Islastpage==1)&&(nGXsfl_114_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_114_idx+1);
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       string AV18ReembolsoPropostaPacienteClienteRazaoSocial1 ,
                                       string AV67WorkflowConvenioDesc1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV22ReembolsoPropostaPacienteClienteRazaoSocial2 ,
                                       string AV68WorkflowConvenioDesc2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       string AV26ReembolsoPropostaPacienteClienteRazaoSocial3 ,
                                       string AV69WorkflowConvenioDesc3 ,
                                       short AV34ManageFiltersExecutionStep ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       string AV70Pgmname ,
                                       string AV15FilterFullText ,
                                       string AV35TFReembolsoPropostaPacienteClienteRazaoSocial ,
                                       string AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel ,
                                       string AV37TFReembolsoProtocolo ,
                                       string AV38TFReembolsoProtocolo_Sel ,
                                       DateTime AV39TFReembolsoCreatedAt ,
                                       DateTime AV40TFReembolsoCreatedAt_To ,
                                       decimal AV44TFReembolsoPropostaValor ,
                                       decimal AV45TFReembolsoPropostaValor_To ,
                                       DateTime AV46TFReembolsoDataAberturaConvenio ,
                                       DateTime AV47TFReembolsoDataAberturaConvenio_To ,
                                       GxSimpleCollection<string> AV57TFReembolsoStatusAtual_F_Sels ,
                                       string AV65TFWorkflowConvenioDesc ,
                                       string AV66TFWorkflowConvenioDesc_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF7N2( ) ;
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
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV70Pgmname = "ReembolsoWW";
         edtavConsulta_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV71Reembolsowwds_1_filterfulltext = AV15FilterFullText;
         AV72Reembolsowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV73Reembolsowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = AV18ReembolsoPropostaPacienteClienteRazaoSocial1;
         AV75Reembolsowwds_5_workflowconveniodesc1 = AV67WorkflowConvenioDesc1;
         AV76Reembolsowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV77Reembolsowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV78Reembolsowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = AV22ReembolsoPropostaPacienteClienteRazaoSocial2;
         AV80Reembolsowwds_10_workflowconveniodesc2 = AV68WorkflowConvenioDesc2;
         AV81Reembolsowwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV82Reembolsowwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV83Reembolsowwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = AV26ReembolsoPropostaPacienteClienteRazaoSocial3;
         AV85Reembolsowwds_15_workflowconveniodesc3 = AV69WorkflowConvenioDesc3;
         AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = AV35TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV88Reembolsowwds_18_tfreembolsoprotocolo = AV37TFReembolsoProtocolo;
         AV89Reembolsowwds_19_tfreembolsoprotocolo_sel = AV38TFReembolsoProtocolo_Sel;
         AV90Reembolsowwds_20_tfreembolsocreatedat = AV39TFReembolsoCreatedAt;
         AV91Reembolsowwds_21_tfreembolsocreatedat_to = AV40TFReembolsoCreatedAt_To;
         AV92Reembolsowwds_22_tfreembolsopropostavalor = AV44TFReembolsoPropostaValor;
         AV93Reembolsowwds_23_tfreembolsopropostavalor_to = AV45TFReembolsoPropostaValor_To;
         AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio = AV46TFReembolsoDataAberturaConvenio;
         AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = AV47TFReembolsoDataAberturaConvenio_To;
         AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels = AV57TFReembolsoStatusAtual_F_Sels;
         AV97Reembolsowwds_27_tfworkflowconveniodesc = AV65TFWorkflowConvenioDesc;
         AV98Reembolsowwds_28_tfworkflowconveniodesc_sel = AV66TFWorkflowConvenioDesc_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A548ReembolsoStatusAtual_F ,
                                              AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels ,
                                              AV72Reembolsowwds_2_dynamicfiltersselector1 ,
                                              AV73Reembolsowwds_3_dynamicfiltersoperator1 ,
                                              AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ,
                                              AV75Reembolsowwds_5_workflowconveniodesc1 ,
                                              AV76Reembolsowwds_6_dynamicfiltersenabled2 ,
                                              AV77Reembolsowwds_7_dynamicfiltersselector2 ,
                                              AV78Reembolsowwds_8_dynamicfiltersoperator2 ,
                                              AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ,
                                              AV80Reembolsowwds_10_workflowconveniodesc2 ,
                                              AV81Reembolsowwds_11_dynamicfiltersenabled3 ,
                                              AV82Reembolsowwds_12_dynamicfiltersselector3 ,
                                              AV83Reembolsowwds_13_dynamicfiltersoperator3 ,
                                              AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ,
                                              AV85Reembolsowwds_15_workflowconveniodesc3 ,
                                              AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                              AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ,
                                              AV89Reembolsowwds_19_tfreembolsoprotocolo_sel ,
                                              AV88Reembolsowwds_18_tfreembolsoprotocolo ,
                                              AV90Reembolsowwds_20_tfreembolsocreatedat ,
                                              AV91Reembolsowwds_21_tfreembolsocreatedat_to ,
                                              AV92Reembolsowwds_22_tfreembolsopropostavalor ,
                                              AV93Reembolsowwds_23_tfreembolsopropostavalor_to ,
                                              AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio ,
                                              AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ,
                                              AV98Reembolsowwds_28_tfworkflowconveniodesc_sel ,
                                              AV97Reembolsowwds_27_tfworkflowconveniodesc ,
                                              A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                              A736WorkflowConvenioDesc ,
                                              A546ReembolsoProtocolo ,
                                              A522ReembolsoCreatedAt ,
                                              A543ReembolsoPropostaValor ,
                                              A525ReembolsoDataAberturaConvenio ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV71Reembolsowwds_1_filterfulltext ,
                                              AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels.Count } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1), "%", "");
         lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1), "%", "");
         lV75Reembolsowwds_5_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV75Reembolsowwds_5_workflowconveniodesc1), "%", "");
         lV75Reembolsowwds_5_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV75Reembolsowwds_5_workflowconveniodesc1), "%", "");
         lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2), "%", "");
         lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2), "%", "");
         lV80Reembolsowwds_10_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV80Reembolsowwds_10_workflowconveniodesc2), "%", "");
         lV80Reembolsowwds_10_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV80Reembolsowwds_10_workflowconveniodesc2), "%", "");
         lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3), "%", "");
         lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3), "%", "");
         lV85Reembolsowwds_15_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV85Reembolsowwds_15_workflowconveniodesc3), "%", "");
         lV85Reembolsowwds_15_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV85Reembolsowwds_15_workflowconveniodesc3), "%", "");
         lV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial), "%", "");
         lV88Reembolsowwds_18_tfreembolsoprotocolo = StringUtil.Concat( StringUtil.RTrim( AV88Reembolsowwds_18_tfreembolsoprotocolo), "%", "");
         lV97Reembolsowwds_27_tfworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV97Reembolsowwds_27_tfworkflowconveniodesc), "%", "");
         /* Using cursor H007N3 */
         pr_default.execute(0, new Object[] {AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels.Count, lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1, lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1, lV75Reembolsowwds_5_workflowconveniodesc1, lV75Reembolsowwds_5_workflowconveniodesc1, lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2, lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2, lV80Reembolsowwds_10_workflowconveniodesc2, lV80Reembolsowwds_10_workflowconveniodesc2, lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3, lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3, lV85Reembolsowwds_15_workflowconveniodesc3, lV85Reembolsowwds_15_workflowconveniodesc3, lV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial, AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, lV88Reembolsowwds_18_tfreembolsoprotocolo, AV89Reembolsowwds_19_tfreembolsoprotocolo_sel, AV90Reembolsowwds_20_tfreembolsocreatedat, AV91Reembolsowwds_21_tfreembolsocreatedat_to, AV92Reembolsowwds_22_tfreembolsopropostavalor, AV93Reembolsowwds_23_tfreembolsopropostavalor_to, AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio, AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to, lV97Reembolsowwds_27_tfworkflowconveniodesc, AV98Reembolsowwds_28_tfworkflowconveniodesc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A742WorkflowConvenioId = H007N3_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = H007N3_n742WorkflowConvenioId[0];
            A736WorkflowConvenioDesc = H007N3_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = H007N3_n736WorkflowConvenioDesc[0];
            A544ReembolsoCreatedBy = H007N3_A544ReembolsoCreatedBy[0];
            n544ReembolsoCreatedBy = H007N3_n544ReembolsoCreatedBy[0];
            A525ReembolsoDataAberturaConvenio = H007N3_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = H007N3_n525ReembolsoDataAberturaConvenio[0];
            A543ReembolsoPropostaValor = H007N3_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = H007N3_n543ReembolsoPropostaValor[0];
            A522ReembolsoCreatedAt = H007N3_A522ReembolsoCreatedAt[0];
            n522ReembolsoCreatedAt = H007N3_n522ReembolsoCreatedAt[0];
            A546ReembolsoProtocolo = H007N3_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = H007N3_n546ReembolsoProtocolo[0];
            A558ReembolsoPropostaPacienteClienteId = H007N3_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = H007N3_n558ReembolsoPropostaPacienteClienteId[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = H007N3_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = H007N3_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A542ReembolsoPropostaId = H007N3_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = H007N3_n542ReembolsoPropostaId[0];
            A518ReembolsoId = H007N3_A518ReembolsoId[0];
            n518ReembolsoId = H007N3_n518ReembolsoId[0];
            A547ReembolsoEtapaUltimo_F = H007N3_A547ReembolsoEtapaUltimo_F[0];
            n547ReembolsoEtapaUltimo_F = H007N3_n547ReembolsoEtapaUltimo_F[0];
            A736WorkflowConvenioDesc = H007N3_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = H007N3_n736WorkflowConvenioDesc[0];
            A543ReembolsoPropostaValor = H007N3_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = H007N3_n543ReembolsoPropostaValor[0];
            A558ReembolsoPropostaPacienteClienteId = H007N3_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = H007N3_n558ReembolsoPropostaPacienteClienteId[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = H007N3_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = H007N3_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A547ReembolsoEtapaUltimo_F = H007N3_A547ReembolsoEtapaUltimo_F[0];
            n547ReembolsoEtapaUltimo_F = H007N3_n547ReembolsoEtapaUltimo_F[0];
            GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF7N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 114;
         /* Execute user event: Refresh */
         E257N2 ();
         nGXsfl_114_idx = 1;
         sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
         SubsflControlProps_1142( ) ;
         bGXsfl_114_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
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
            SubsflControlProps_1142( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A548ReembolsoStatusAtual_F ,
                                                 AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels ,
                                                 AV72Reembolsowwds_2_dynamicfiltersselector1 ,
                                                 AV73Reembolsowwds_3_dynamicfiltersoperator1 ,
                                                 AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ,
                                                 AV75Reembolsowwds_5_workflowconveniodesc1 ,
                                                 AV76Reembolsowwds_6_dynamicfiltersenabled2 ,
                                                 AV77Reembolsowwds_7_dynamicfiltersselector2 ,
                                                 AV78Reembolsowwds_8_dynamicfiltersoperator2 ,
                                                 AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ,
                                                 AV80Reembolsowwds_10_workflowconveniodesc2 ,
                                                 AV81Reembolsowwds_11_dynamicfiltersenabled3 ,
                                                 AV82Reembolsowwds_12_dynamicfiltersselector3 ,
                                                 AV83Reembolsowwds_13_dynamicfiltersoperator3 ,
                                                 AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ,
                                                 AV85Reembolsowwds_15_workflowconveniodesc3 ,
                                                 AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                                 AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ,
                                                 AV89Reembolsowwds_19_tfreembolsoprotocolo_sel ,
                                                 AV88Reembolsowwds_18_tfreembolsoprotocolo ,
                                                 AV90Reembolsowwds_20_tfreembolsocreatedat ,
                                                 AV91Reembolsowwds_21_tfreembolsocreatedat_to ,
                                                 AV92Reembolsowwds_22_tfreembolsopropostavalor ,
                                                 AV93Reembolsowwds_23_tfreembolsopropostavalor_to ,
                                                 AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio ,
                                                 AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ,
                                                 AV98Reembolsowwds_28_tfworkflowconveniodesc_sel ,
                                                 AV97Reembolsowwds_27_tfworkflowconveniodesc ,
                                                 A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                                 A736WorkflowConvenioDesc ,
                                                 A546ReembolsoProtocolo ,
                                                 A522ReembolsoCreatedAt ,
                                                 A543ReembolsoPropostaValor ,
                                                 A525ReembolsoDataAberturaConvenio ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV71Reembolsowwds_1_filterfulltext ,
                                                 AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels.Count } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1), "%", "");
            lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = StringUtil.Concat( StringUtil.RTrim( AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1), "%", "");
            lV75Reembolsowwds_5_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV75Reembolsowwds_5_workflowconveniodesc1), "%", "");
            lV75Reembolsowwds_5_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV75Reembolsowwds_5_workflowconveniodesc1), "%", "");
            lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2), "%", "");
            lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = StringUtil.Concat( StringUtil.RTrim( AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2), "%", "");
            lV80Reembolsowwds_10_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV80Reembolsowwds_10_workflowconveniodesc2), "%", "");
            lV80Reembolsowwds_10_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV80Reembolsowwds_10_workflowconveniodesc2), "%", "");
            lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3), "%", "");
            lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = StringUtil.Concat( StringUtil.RTrim( AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3), "%", "");
            lV85Reembolsowwds_15_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV85Reembolsowwds_15_workflowconveniodesc3), "%", "");
            lV85Reembolsowwds_15_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV85Reembolsowwds_15_workflowconveniodesc3), "%", "");
            lV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial), "%", "");
            lV88Reembolsowwds_18_tfreembolsoprotocolo = StringUtil.Concat( StringUtil.RTrim( AV88Reembolsowwds_18_tfreembolsoprotocolo), "%", "");
            lV97Reembolsowwds_27_tfworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV97Reembolsowwds_27_tfworkflowconveniodesc), "%", "");
            /* Using cursor H007N5 */
            pr_default.execute(1, new Object[] {AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels.Count, lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1, lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1, lV75Reembolsowwds_5_workflowconveniodesc1, lV75Reembolsowwds_5_workflowconveniodesc1, lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2, lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2, lV80Reembolsowwds_10_workflowconveniodesc2, lV80Reembolsowwds_10_workflowconveniodesc2, lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3, lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3, lV85Reembolsowwds_15_workflowconveniodesc3, lV85Reembolsowwds_15_workflowconveniodesc3, lV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial, AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, lV88Reembolsowwds_18_tfreembolsoprotocolo, AV89Reembolsowwds_19_tfreembolsoprotocolo_sel, AV90Reembolsowwds_20_tfreembolsocreatedat, AV91Reembolsowwds_21_tfreembolsocreatedat_to, AV92Reembolsowwds_22_tfreembolsopropostavalor, AV93Reembolsowwds_23_tfreembolsopropostavalor_to, AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio, AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to, lV97Reembolsowwds_27_tfworkflowconveniodesc, AV98Reembolsowwds_28_tfworkflowconveniodesc_sel});
            nGXsfl_114_idx = 1;
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A742WorkflowConvenioId = H007N5_A742WorkflowConvenioId[0];
               n742WorkflowConvenioId = H007N5_n742WorkflowConvenioId[0];
               A736WorkflowConvenioDesc = H007N5_A736WorkflowConvenioDesc[0];
               n736WorkflowConvenioDesc = H007N5_n736WorkflowConvenioDesc[0];
               A544ReembolsoCreatedBy = H007N5_A544ReembolsoCreatedBy[0];
               n544ReembolsoCreatedBy = H007N5_n544ReembolsoCreatedBy[0];
               A525ReembolsoDataAberturaConvenio = H007N5_A525ReembolsoDataAberturaConvenio[0];
               n525ReembolsoDataAberturaConvenio = H007N5_n525ReembolsoDataAberturaConvenio[0];
               A543ReembolsoPropostaValor = H007N5_A543ReembolsoPropostaValor[0];
               n543ReembolsoPropostaValor = H007N5_n543ReembolsoPropostaValor[0];
               A522ReembolsoCreatedAt = H007N5_A522ReembolsoCreatedAt[0];
               n522ReembolsoCreatedAt = H007N5_n522ReembolsoCreatedAt[0];
               A546ReembolsoProtocolo = H007N5_A546ReembolsoProtocolo[0];
               n546ReembolsoProtocolo = H007N5_n546ReembolsoProtocolo[0];
               A558ReembolsoPropostaPacienteClienteId = H007N5_A558ReembolsoPropostaPacienteClienteId[0];
               n558ReembolsoPropostaPacienteClienteId = H007N5_n558ReembolsoPropostaPacienteClienteId[0];
               A550ReembolsoPropostaPacienteClienteRazaoSocial = H007N5_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               n550ReembolsoPropostaPacienteClienteRazaoSocial = H007N5_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               A542ReembolsoPropostaId = H007N5_A542ReembolsoPropostaId[0];
               n542ReembolsoPropostaId = H007N5_n542ReembolsoPropostaId[0];
               A518ReembolsoId = H007N5_A518ReembolsoId[0];
               n518ReembolsoId = H007N5_n518ReembolsoId[0];
               A547ReembolsoEtapaUltimo_F = H007N5_A547ReembolsoEtapaUltimo_F[0];
               n547ReembolsoEtapaUltimo_F = H007N5_n547ReembolsoEtapaUltimo_F[0];
               A736WorkflowConvenioDesc = H007N5_A736WorkflowConvenioDesc[0];
               n736WorkflowConvenioDesc = H007N5_n736WorkflowConvenioDesc[0];
               A543ReembolsoPropostaValor = H007N5_A543ReembolsoPropostaValor[0];
               n543ReembolsoPropostaValor = H007N5_n543ReembolsoPropostaValor[0];
               A558ReembolsoPropostaPacienteClienteId = H007N5_A558ReembolsoPropostaPacienteClienteId[0];
               n558ReembolsoPropostaPacienteClienteId = H007N5_n558ReembolsoPropostaPacienteClienteId[0];
               A550ReembolsoPropostaPacienteClienteRazaoSocial = H007N5_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               n550ReembolsoPropostaPacienteClienteRazaoSocial = H007N5_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               A547ReembolsoEtapaUltimo_F = H007N5_A547ReembolsoEtapaUltimo_F[0];
               n547ReembolsoEtapaUltimo_F = H007N5_n547ReembolsoEtapaUltimo_F[0];
               /* Execute user event: Grid.Load */
               E267N2 ();
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 114;
            WB7N0( ) ;
         }
         bGXsfl_114_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7N2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV70Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV70Pgmname, "")), context));
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
         AV71Reembolsowwds_1_filterfulltext = AV15FilterFullText;
         AV72Reembolsowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV73Reembolsowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = AV18ReembolsoPropostaPacienteClienteRazaoSocial1;
         AV75Reembolsowwds_5_workflowconveniodesc1 = AV67WorkflowConvenioDesc1;
         AV76Reembolsowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV77Reembolsowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV78Reembolsowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = AV22ReembolsoPropostaPacienteClienteRazaoSocial2;
         AV80Reembolsowwds_10_workflowconveniodesc2 = AV68WorkflowConvenioDesc2;
         AV81Reembolsowwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV82Reembolsowwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV83Reembolsowwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = AV26ReembolsoPropostaPacienteClienteRazaoSocial3;
         AV85Reembolsowwds_15_workflowconveniodesc3 = AV69WorkflowConvenioDesc3;
         AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = AV35TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV88Reembolsowwds_18_tfreembolsoprotocolo = AV37TFReembolsoProtocolo;
         AV89Reembolsowwds_19_tfreembolsoprotocolo_sel = AV38TFReembolsoProtocolo_Sel;
         AV90Reembolsowwds_20_tfreembolsocreatedat = AV39TFReembolsoCreatedAt;
         AV91Reembolsowwds_21_tfreembolsocreatedat_to = AV40TFReembolsoCreatedAt_To;
         AV92Reembolsowwds_22_tfreembolsopropostavalor = AV44TFReembolsoPropostaValor;
         AV93Reembolsowwds_23_tfreembolsopropostavalor_to = AV45TFReembolsoPropostaValor_To;
         AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio = AV46TFReembolsoDataAberturaConvenio;
         AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = AV47TFReembolsoDataAberturaConvenio_To;
         AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels = AV57TFReembolsoStatusAtual_F_Sels;
         AV97Reembolsowwds_27_tfworkflowconveniodesc = AV65TFWorkflowConvenioDesc;
         AV98Reembolsowwds_28_tfworkflowconveniodesc_sel = AV66TFWorkflowConvenioDesc_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoPropostaPacienteClienteRazaoSocial1, AV67WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoPropostaPacienteClienteRazaoSocial2, AV68WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoPropostaPacienteClienteRazaoSocial3, AV69WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV70Pgmname, AV15FilterFullText, AV35TFReembolsoPropostaPacienteClienteRazaoSocial, AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV37TFReembolsoProtocolo, AV38TFReembolsoProtocolo_Sel, AV39TFReembolsoCreatedAt, AV40TFReembolsoCreatedAt_To, AV44TFReembolsoPropostaValor, AV45TFReembolsoPropostaValor_To, AV46TFReembolsoDataAberturaConvenio, AV47TFReembolsoDataAberturaConvenio_To, AV57TFReembolsoStatusAtual_F_Sels, AV65TFWorkflowConvenioDesc, AV66TFWorkflowConvenioDesc_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV71Reembolsowwds_1_filterfulltext = AV15FilterFullText;
         AV72Reembolsowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV73Reembolsowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = AV18ReembolsoPropostaPacienteClienteRazaoSocial1;
         AV75Reembolsowwds_5_workflowconveniodesc1 = AV67WorkflowConvenioDesc1;
         AV76Reembolsowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV77Reembolsowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV78Reembolsowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = AV22ReembolsoPropostaPacienteClienteRazaoSocial2;
         AV80Reembolsowwds_10_workflowconveniodesc2 = AV68WorkflowConvenioDesc2;
         AV81Reembolsowwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV82Reembolsowwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV83Reembolsowwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = AV26ReembolsoPropostaPacienteClienteRazaoSocial3;
         AV85Reembolsowwds_15_workflowconveniodesc3 = AV69WorkflowConvenioDesc3;
         AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = AV35TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV88Reembolsowwds_18_tfreembolsoprotocolo = AV37TFReembolsoProtocolo;
         AV89Reembolsowwds_19_tfreembolsoprotocolo_sel = AV38TFReembolsoProtocolo_Sel;
         AV90Reembolsowwds_20_tfreembolsocreatedat = AV39TFReembolsoCreatedAt;
         AV91Reembolsowwds_21_tfreembolsocreatedat_to = AV40TFReembolsoCreatedAt_To;
         AV92Reembolsowwds_22_tfreembolsopropostavalor = AV44TFReembolsoPropostaValor;
         AV93Reembolsowwds_23_tfreembolsopropostavalor_to = AV45TFReembolsoPropostaValor_To;
         AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio = AV46TFReembolsoDataAberturaConvenio;
         AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = AV47TFReembolsoDataAberturaConvenio_To;
         AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels = AV57TFReembolsoStatusAtual_F_Sels;
         AV97Reembolsowwds_27_tfworkflowconveniodesc = AV65TFWorkflowConvenioDesc;
         AV98Reembolsowwds_28_tfworkflowconveniodesc_sel = AV66TFWorkflowConvenioDesc_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoPropostaPacienteClienteRazaoSocial1, AV67WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoPropostaPacienteClienteRazaoSocial2, AV68WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoPropostaPacienteClienteRazaoSocial3, AV69WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV70Pgmname, AV15FilterFullText, AV35TFReembolsoPropostaPacienteClienteRazaoSocial, AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV37TFReembolsoProtocolo, AV38TFReembolsoProtocolo_Sel, AV39TFReembolsoCreatedAt, AV40TFReembolsoCreatedAt_To, AV44TFReembolsoPropostaValor, AV45TFReembolsoPropostaValor_To, AV46TFReembolsoDataAberturaConvenio, AV47TFReembolsoDataAberturaConvenio_To, AV57TFReembolsoStatusAtual_F_Sels, AV65TFWorkflowConvenioDesc, AV66TFWorkflowConvenioDesc_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV71Reembolsowwds_1_filterfulltext = AV15FilterFullText;
         AV72Reembolsowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV73Reembolsowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = AV18ReembolsoPropostaPacienteClienteRazaoSocial1;
         AV75Reembolsowwds_5_workflowconveniodesc1 = AV67WorkflowConvenioDesc1;
         AV76Reembolsowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV77Reembolsowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV78Reembolsowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = AV22ReembolsoPropostaPacienteClienteRazaoSocial2;
         AV80Reembolsowwds_10_workflowconveniodesc2 = AV68WorkflowConvenioDesc2;
         AV81Reembolsowwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV82Reembolsowwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV83Reembolsowwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = AV26ReembolsoPropostaPacienteClienteRazaoSocial3;
         AV85Reembolsowwds_15_workflowconveniodesc3 = AV69WorkflowConvenioDesc3;
         AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = AV35TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV88Reembolsowwds_18_tfreembolsoprotocolo = AV37TFReembolsoProtocolo;
         AV89Reembolsowwds_19_tfreembolsoprotocolo_sel = AV38TFReembolsoProtocolo_Sel;
         AV90Reembolsowwds_20_tfreembolsocreatedat = AV39TFReembolsoCreatedAt;
         AV91Reembolsowwds_21_tfreembolsocreatedat_to = AV40TFReembolsoCreatedAt_To;
         AV92Reembolsowwds_22_tfreembolsopropostavalor = AV44TFReembolsoPropostaValor;
         AV93Reembolsowwds_23_tfreembolsopropostavalor_to = AV45TFReembolsoPropostaValor_To;
         AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio = AV46TFReembolsoDataAberturaConvenio;
         AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = AV47TFReembolsoDataAberturaConvenio_To;
         AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels = AV57TFReembolsoStatusAtual_F_Sels;
         AV97Reembolsowwds_27_tfworkflowconveniodesc = AV65TFWorkflowConvenioDesc;
         AV98Reembolsowwds_28_tfworkflowconveniodesc_sel = AV66TFWorkflowConvenioDesc_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoPropostaPacienteClienteRazaoSocial1, AV67WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoPropostaPacienteClienteRazaoSocial2, AV68WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoPropostaPacienteClienteRazaoSocial3, AV69WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV70Pgmname, AV15FilterFullText, AV35TFReembolsoPropostaPacienteClienteRazaoSocial, AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV37TFReembolsoProtocolo, AV38TFReembolsoProtocolo_Sel, AV39TFReembolsoCreatedAt, AV40TFReembolsoCreatedAt_To, AV44TFReembolsoPropostaValor, AV45TFReembolsoPropostaValor_To, AV46TFReembolsoDataAberturaConvenio, AV47TFReembolsoDataAberturaConvenio_To, AV57TFReembolsoStatusAtual_F_Sels, AV65TFWorkflowConvenioDesc, AV66TFWorkflowConvenioDesc_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV71Reembolsowwds_1_filterfulltext = AV15FilterFullText;
         AV72Reembolsowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV73Reembolsowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = AV18ReembolsoPropostaPacienteClienteRazaoSocial1;
         AV75Reembolsowwds_5_workflowconveniodesc1 = AV67WorkflowConvenioDesc1;
         AV76Reembolsowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV77Reembolsowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV78Reembolsowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = AV22ReembolsoPropostaPacienteClienteRazaoSocial2;
         AV80Reembolsowwds_10_workflowconveniodesc2 = AV68WorkflowConvenioDesc2;
         AV81Reembolsowwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV82Reembolsowwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV83Reembolsowwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = AV26ReembolsoPropostaPacienteClienteRazaoSocial3;
         AV85Reembolsowwds_15_workflowconveniodesc3 = AV69WorkflowConvenioDesc3;
         AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = AV35TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV88Reembolsowwds_18_tfreembolsoprotocolo = AV37TFReembolsoProtocolo;
         AV89Reembolsowwds_19_tfreembolsoprotocolo_sel = AV38TFReembolsoProtocolo_Sel;
         AV90Reembolsowwds_20_tfreembolsocreatedat = AV39TFReembolsoCreatedAt;
         AV91Reembolsowwds_21_tfreembolsocreatedat_to = AV40TFReembolsoCreatedAt_To;
         AV92Reembolsowwds_22_tfreembolsopropostavalor = AV44TFReembolsoPropostaValor;
         AV93Reembolsowwds_23_tfreembolsopropostavalor_to = AV45TFReembolsoPropostaValor_To;
         AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio = AV46TFReembolsoDataAberturaConvenio;
         AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = AV47TFReembolsoDataAberturaConvenio_To;
         AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels = AV57TFReembolsoStatusAtual_F_Sels;
         AV97Reembolsowwds_27_tfworkflowconveniodesc = AV65TFWorkflowConvenioDesc;
         AV98Reembolsowwds_28_tfworkflowconveniodesc_sel = AV66TFWorkflowConvenioDesc_Sel;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoPropostaPacienteClienteRazaoSocial1, AV67WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoPropostaPacienteClienteRazaoSocial2, AV68WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoPropostaPacienteClienteRazaoSocial3, AV69WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV70Pgmname, AV15FilterFullText, AV35TFReembolsoPropostaPacienteClienteRazaoSocial, AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV37TFReembolsoProtocolo, AV38TFReembolsoProtocolo_Sel, AV39TFReembolsoCreatedAt, AV40TFReembolsoCreatedAt_To, AV44TFReembolsoPropostaValor, AV45TFReembolsoPropostaValor_To, AV46TFReembolsoDataAberturaConvenio, AV47TFReembolsoDataAberturaConvenio_To, AV57TFReembolsoStatusAtual_F_Sels, AV65TFWorkflowConvenioDesc, AV66TFWorkflowConvenioDesc_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV71Reembolsowwds_1_filterfulltext = AV15FilterFullText;
         AV72Reembolsowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV73Reembolsowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = AV18ReembolsoPropostaPacienteClienteRazaoSocial1;
         AV75Reembolsowwds_5_workflowconveniodesc1 = AV67WorkflowConvenioDesc1;
         AV76Reembolsowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV77Reembolsowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV78Reembolsowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = AV22ReembolsoPropostaPacienteClienteRazaoSocial2;
         AV80Reembolsowwds_10_workflowconveniodesc2 = AV68WorkflowConvenioDesc2;
         AV81Reembolsowwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV82Reembolsowwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV83Reembolsowwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = AV26ReembolsoPropostaPacienteClienteRazaoSocial3;
         AV85Reembolsowwds_15_workflowconveniodesc3 = AV69WorkflowConvenioDesc3;
         AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = AV35TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV88Reembolsowwds_18_tfreembolsoprotocolo = AV37TFReembolsoProtocolo;
         AV89Reembolsowwds_19_tfreembolsoprotocolo_sel = AV38TFReembolsoProtocolo_Sel;
         AV90Reembolsowwds_20_tfreembolsocreatedat = AV39TFReembolsoCreatedAt;
         AV91Reembolsowwds_21_tfreembolsocreatedat_to = AV40TFReembolsoCreatedAt_To;
         AV92Reembolsowwds_22_tfreembolsopropostavalor = AV44TFReembolsoPropostaValor;
         AV93Reembolsowwds_23_tfreembolsopropostavalor_to = AV45TFReembolsoPropostaValor_To;
         AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio = AV46TFReembolsoDataAberturaConvenio;
         AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = AV47TFReembolsoDataAberturaConvenio_To;
         AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels = AV57TFReembolsoStatusAtual_F_Sels;
         AV97Reembolsowwds_27_tfworkflowconveniodesc = AV65TFWorkflowConvenioDesc;
         AV98Reembolsowwds_28_tfworkflowconveniodesc_sel = AV66TFWorkflowConvenioDesc_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoPropostaPacienteClienteRazaoSocial1, AV67WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoPropostaPacienteClienteRazaoSocial2, AV68WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoPropostaPacienteClienteRazaoSocial3, AV69WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV70Pgmname, AV15FilterFullText, AV35TFReembolsoPropostaPacienteClienteRazaoSocial, AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV37TFReembolsoProtocolo, AV38TFReembolsoProtocolo_Sel, AV39TFReembolsoCreatedAt, AV40TFReembolsoCreatedAt_To, AV44TFReembolsoPropostaValor, AV45TFReembolsoPropostaValor_To, AV46TFReembolsoDataAberturaConvenio, AV47TFReembolsoDataAberturaConvenio_To, AV57TFReembolsoStatusAtual_F_Sels, AV65TFWorkflowConvenioDesc, AV66TFWorkflowConvenioDesc_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV70Pgmname = "ReembolsoWW";
         edtavConsulta_Enabled = 0;
         edtReembolsoId_Enabled = 0;
         edtReembolsoPropostaId_Enabled = 0;
         edtReembolsoPropostaPacienteClienteRazaoSocial_Enabled = 0;
         edtReembolsoPropostaPacienteClienteId_Enabled = 0;
         edtReembolsoProtocolo_Enabled = 0;
         edtReembolsoCreatedAt_Enabled = 0;
         edtReembolsoPropostaValor_Enabled = 0;
         edtReembolsoDataAberturaConvenio_Enabled = 0;
         edtReembolsoCreatedBy_Enabled = 0;
         edtReembolsoEtapaUltimo_F_Enabled = 0;
         cmbReembolsoStatusAtual_F.Enabled = 0;
         edtWorkflowConvenioDesc_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E247N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV32ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV58DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_114 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_114"), ",", "."), 18, MidpointRounding.ToEven));
            AV60GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV61GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV62GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV41DDO_ReembolsoCreatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_REEMBOLSOCREATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV41DDO_ReembolsoCreatedAtAuxDate", context.localUtil.Format(AV41DDO_ReembolsoCreatedAtAuxDate, "99/99/9999"));
            AV42DDO_ReembolsoCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_REEMBOLSOCREATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV42DDO_ReembolsoCreatedAtAuxDateTo", context.localUtil.Format(AV42DDO_ReembolsoCreatedAtAuxDateTo, "99/99/9999"));
            AV48DDO_ReembolsoDataAberturaConvenioAuxDate = context.localUtil.CToD( cgiGet( "vDDO_REEMBOLSODATAABERTURACONVENIOAUXDATE"), 0);
            AV49DDO_ReembolsoDataAberturaConvenioAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_REEMBOLSODATAABERTURACONVENIOAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Dvpanel_tableheader_Width = cgiGet( "DVPANEL_TABLEHEADER_Width");
            Dvpanel_tableheader_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autowidth"));
            Dvpanel_tableheader_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoheight"));
            Dvpanel_tableheader_Cls = cgiGet( "DVPANEL_TABLEHEADER_Cls");
            Dvpanel_tableheader_Title = cgiGet( "DVPANEL_TABLEHEADER_Title");
            Dvpanel_tableheader_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsible"));
            Dvpanel_tableheader_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsed"));
            Dvpanel_tableheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Showcollapseicon"));
            Dvpanel_tableheader_Iconposition = cgiGet( "DVPANEL_TABLEHEADER_Iconposition");
            Dvpanel_tableheader_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoscroll"));
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV16DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AV18ReembolsoPropostaPacienteClienteRazaoSocial1 = StringUtil.Upper( cgiGet( edtavReembolsopropostapacienteclienterazaosocial1_Internalname));
            AssignAttri("", false, "AV18ReembolsoPropostaPacienteClienteRazaoSocial1", AV18ReembolsoPropostaPacienteClienteRazaoSocial1);
            AV67WorkflowConvenioDesc1 = cgiGet( edtavWorkflowconveniodesc1_Internalname);
            AssignAttri("", false, "AV67WorkflowConvenioDesc1", AV67WorkflowConvenioDesc1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV22ReembolsoPropostaPacienteClienteRazaoSocial2 = StringUtil.Upper( cgiGet( edtavReembolsopropostapacienteclienterazaosocial2_Internalname));
            AssignAttri("", false, "AV22ReembolsoPropostaPacienteClienteRazaoSocial2", AV22ReembolsoPropostaPacienteClienteRazaoSocial2);
            AV68WorkflowConvenioDesc2 = cgiGet( edtavWorkflowconveniodesc2_Internalname);
            AssignAttri("", false, "AV68WorkflowConvenioDesc2", AV68WorkflowConvenioDesc2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AV26ReembolsoPropostaPacienteClienteRazaoSocial3 = StringUtil.Upper( cgiGet( edtavReembolsopropostapacienteclienterazaosocial3_Internalname));
            AssignAttri("", false, "AV26ReembolsoPropostaPacienteClienteRazaoSocial3", AV26ReembolsoPropostaPacienteClienteRazaoSocial3);
            AV69WorkflowConvenioDesc3 = cgiGet( edtavWorkflowconveniodesc3_Internalname);
            AssignAttri("", false, "AV69WorkflowConvenioDesc3", AV69WorkflowConvenioDesc3);
            AV43DDO_ReembolsoCreatedAtAuxDateText = cgiGet( edtavDdo_reembolsocreatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV43DDO_ReembolsoCreatedAtAuxDateText", AV43DDO_ReembolsoCreatedAtAuxDateText);
            AV50DDO_ReembolsoDataAberturaConvenioAuxDateText = cgiGet( edtavDdo_reembolsodataaberturaconvenioauxdatetext_Internalname);
            AssignAttri("", false, "AV50DDO_ReembolsoDataAberturaConvenioAuxDateText", AV50DDO_ReembolsoDataAberturaConvenioAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1"), AV18ReembolsoPropostaPacienteClienteRazaoSocial1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vWORKFLOWCONVENIODESC1"), AV67WorkflowConvenioDesc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2"), AV22ReembolsoPropostaPacienteClienteRazaoSocial2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vWORKFLOWCONVENIODESC2"), AV68WorkflowConvenioDesc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3"), AV26ReembolsoPropostaPacienteClienteRazaoSocial3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vWORKFLOWCONVENIODESC3"), AV69WorkflowConvenioDesc3) != 0 )
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
         E247N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E247N2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFREEMBOLSODATAABERTURACONVENIO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_reembolsodataaberturaconvenioauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFREEMBOLSOCREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_reembolsocreatedatauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV16DynamicFiltersSelector1 = "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Reembolso";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
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
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV58DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV58DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E257N2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV34ManageFiltersExecutionStep == 1 )
         {
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV34ManageFiltersExecutionStep == 2 )
         {
            AV34ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "WORKFLOWCONVENIODESC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "WORKFLOWCONVENIODESC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV23DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "WORKFLOWCONVENIODESC") == 0 )
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
         AV60GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV60GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV60GridCurrentPage), 10, 0));
         AV61GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV61GridPageCount", StringUtil.LTrimStr( (decimal)(AV61GridPageCount), 10, 0));
         GXt_char2 = AV62GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV70Pgmname, out  GXt_char2) ;
         AV62GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV62GridAppliedFilters", AV62GridAppliedFilters);
         cmbReembolsoStatusAtual_F_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbReembolsoStatusAtual_F_Internalname, "Columnheaderclass", cmbReembolsoStatusAtual_F_Columnheaderclass, !bGXsfl_114_Refreshing);
         AV71Reembolsowwds_1_filterfulltext = AV15FilterFullText;
         AV72Reembolsowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV73Reembolsowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = AV18ReembolsoPropostaPacienteClienteRazaoSocial1;
         AV75Reembolsowwds_5_workflowconveniodesc1 = AV67WorkflowConvenioDesc1;
         AV76Reembolsowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV77Reembolsowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV78Reembolsowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = AV22ReembolsoPropostaPacienteClienteRazaoSocial2;
         AV80Reembolsowwds_10_workflowconveniodesc2 = AV68WorkflowConvenioDesc2;
         AV81Reembolsowwds_11_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV82Reembolsowwds_12_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV83Reembolsowwds_13_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = AV26ReembolsoPropostaPacienteClienteRazaoSocial3;
         AV85Reembolsowwds_15_workflowconveniodesc3 = AV69WorkflowConvenioDesc3;
         AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = AV35TFReembolsoPropostaPacienteClienteRazaoSocial;
         AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel;
         AV88Reembolsowwds_18_tfreembolsoprotocolo = AV37TFReembolsoProtocolo;
         AV89Reembolsowwds_19_tfreembolsoprotocolo_sel = AV38TFReembolsoProtocolo_Sel;
         AV90Reembolsowwds_20_tfreembolsocreatedat = AV39TFReembolsoCreatedAt;
         AV91Reembolsowwds_21_tfreembolsocreatedat_to = AV40TFReembolsoCreatedAt_To;
         AV92Reembolsowwds_22_tfreembolsopropostavalor = AV44TFReembolsoPropostaValor;
         AV93Reembolsowwds_23_tfreembolsopropostavalor_to = AV45TFReembolsoPropostaValor_To;
         AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio = AV46TFReembolsoDataAberturaConvenio;
         AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = AV47TFReembolsoDataAberturaConvenio_To;
         AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels = AV57TFReembolsoStatusAtual_F_Sels;
         AV97Reembolsowwds_27_tfworkflowconveniodesc = AV65TFWorkflowConvenioDesc;
         AV98Reembolsowwds_28_tfworkflowconveniodesc_sel = AV66TFWorkflowConvenioDesc_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E127N2( )
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
            AV59PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV59PageToGo) ;
         }
      }

      protected void E137N2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E147N2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
               AV35TFReembolsoPropostaPacienteClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFReembolsoPropostaPacienteClienteRazaoSocial", AV35TFReembolsoPropostaPacienteClienteRazaoSocial);
               AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel", AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoProtocolo") == 0 )
            {
               AV37TFReembolsoProtocolo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFReembolsoProtocolo", AV37TFReembolsoProtocolo);
               AV38TFReembolsoProtocolo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFReembolsoProtocolo_Sel", AV38TFReembolsoProtocolo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoCreatedAt") == 0 )
            {
               AV39TFReembolsoCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV39TFReembolsoCreatedAt", context.localUtil.TToC( AV39TFReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
               AV40TFReembolsoCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV40TFReembolsoCreatedAt_To", context.localUtil.TToC( AV40TFReembolsoCreatedAt_To, 10, 8, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV40TFReembolsoCreatedAt_To) )
               {
                  AV40TFReembolsoCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV40TFReembolsoCreatedAt_To)), (short)(DateTimeUtil.Month( AV40TFReembolsoCreatedAt_To)), (short)(DateTimeUtil.Day( AV40TFReembolsoCreatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV40TFReembolsoCreatedAt_To", context.localUtil.TToC( AV40TFReembolsoCreatedAt_To, 10, 8, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoPropostaValor") == 0 )
            {
               AV44TFReembolsoPropostaValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV44TFReembolsoPropostaValor", StringUtil.LTrimStr( AV44TFReembolsoPropostaValor, 18, 2));
               AV45TFReembolsoPropostaValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV45TFReembolsoPropostaValor_To", StringUtil.LTrimStr( AV45TFReembolsoPropostaValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoDataAberturaConvenio") == 0 )
            {
               AV46TFReembolsoDataAberturaConvenio = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV46TFReembolsoDataAberturaConvenio", context.localUtil.Format(AV46TFReembolsoDataAberturaConvenio, "99/99/9999"));
               AV47TFReembolsoDataAberturaConvenio_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV47TFReembolsoDataAberturaConvenio_To", context.localUtil.Format(AV47TFReembolsoDataAberturaConvenio_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoStatusAtual_F") == 0 )
            {
               AV56TFReembolsoStatusAtual_F_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV56TFReembolsoStatusAtual_F_SelsJson", AV56TFReembolsoStatusAtual_F_SelsJson);
               AV57TFReembolsoStatusAtual_F_Sels.FromJSonString(AV56TFReembolsoStatusAtual_F_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkflowConvenioDesc") == 0 )
            {
               AV65TFWorkflowConvenioDesc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV65TFWorkflowConvenioDesc", AV65TFWorkflowConvenioDesc);
               AV66TFWorkflowConvenioDesc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV66TFWorkflowConvenioDesc_Sel", AV66TFWorkflowConvenioDesc_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57TFReembolsoStatusAtual_F_Sels", AV57TFReembolsoStatusAtual_F_Sels);
      }

      private void E267N2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV64Consulta = "<i class=\"fas fa-magnifying-glass-plus\"></i>";
            AssignAttri("", false, edtavConsulta_Internalname, AV64Consulta);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wreembolso"+UrlEncode(StringUtil.LTrimStr(A542ReembolsoPropostaId,9,0));
            edtavConsulta_Link = formatLink("wreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "workflowconvenio"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A742WorkflowConvenioId,9,0));
            edtWorkflowConvenioDesc_Link = formatLink("workflowconvenio") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "EM_ANALISE") == 0 )
            {
               cmbReembolsoStatusAtual_F_Columnclass = "WWColumn WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
            }
            else if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "FINALIZADO") == 0 )
            {
               cmbReembolsoStatusAtual_F_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "REANALISE") == 0 )
            {
               cmbReembolsoStatusAtual_F_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
            }
            else if ( StringUtil.StrCmp(A548ReembolsoStatusAtual_F, "") == 0 )
            {
               cmbReembolsoStatusAtual_F_Columnclass = "WWColumn WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
            }
            else
            {
               cmbReembolsoStatusAtual_F_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 114;
            }
            sendrow_1142( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_114_Refreshing )
         {
            DoAjaxLoad(114, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E197N2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoPropostaPacienteClienteRazaoSocial1, AV67WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoPropostaPacienteClienteRazaoSocial2, AV68WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoPropostaPacienteClienteRazaoSocial3, AV69WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV70Pgmname, AV15FilterFullText, AV35TFReembolsoPropostaPacienteClienteRazaoSocial, AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV37TFReembolsoProtocolo, AV38TFReembolsoProtocolo_Sel, AV39TFReembolsoCreatedAt, AV40TFReembolsoCreatedAt_To, AV44TFReembolsoPropostaValor, AV45TFReembolsoPropostaValor_To, AV46TFReembolsoDataAberturaConvenio, AV47TFReembolsoDataAberturaConvenio_To, AV57TFReembolsoStatusAtual_F_Sels, AV65TFWorkflowConvenioDesc, AV66TFWorkflowConvenioDesc_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E157N2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoPropostaPacienteClienteRazaoSocial1, AV67WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoPropostaPacienteClienteRazaoSocial2, AV68WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoPropostaPacienteClienteRazaoSocial3, AV69WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV70Pgmname, AV15FilterFullText, AV35TFReembolsoPropostaPacienteClienteRazaoSocial, AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV37TFReembolsoProtocolo, AV38TFReembolsoProtocolo_Sel, AV39TFReembolsoCreatedAt, AV40TFReembolsoCreatedAt_To, AV44TFReembolsoPropostaValor, AV45TFReembolsoPropostaValor_To, AV46TFReembolsoDataAberturaConvenio, AV47TFReembolsoDataAberturaConvenio_To, AV57TFReembolsoStatusAtual_F_Sels, AV65TFWorkflowConvenioDesc, AV66TFWorkflowConvenioDesc_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E207N2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E217N2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoPropostaPacienteClienteRazaoSocial1, AV67WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoPropostaPacienteClienteRazaoSocial2, AV68WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoPropostaPacienteClienteRazaoSocial3, AV69WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV70Pgmname, AV15FilterFullText, AV35TFReembolsoPropostaPacienteClienteRazaoSocial, AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV37TFReembolsoProtocolo, AV38TFReembolsoProtocolo_Sel, AV39TFReembolsoCreatedAt, AV40TFReembolsoCreatedAt_To, AV44TFReembolsoPropostaValor, AV45TFReembolsoPropostaValor_To, AV46TFReembolsoDataAberturaConvenio, AV47TFReembolsoDataAberturaConvenio_To, AV57TFReembolsoStatusAtual_F_Sels, AV65TFWorkflowConvenioDesc, AV66TFWorkflowConvenioDesc_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E167N2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoPropostaPacienteClienteRazaoSocial1, AV67WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoPropostaPacienteClienteRazaoSocial2, AV68WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoPropostaPacienteClienteRazaoSocial3, AV69WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV70Pgmname, AV15FilterFullText, AV35TFReembolsoPropostaPacienteClienteRazaoSocial, AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV37TFReembolsoProtocolo, AV38TFReembolsoProtocolo_Sel, AV39TFReembolsoCreatedAt, AV40TFReembolsoCreatedAt_To, AV44TFReembolsoPropostaValor, AV45TFReembolsoPropostaValor_To, AV46TFReembolsoDataAberturaConvenio, AV47TFReembolsoDataAberturaConvenio_To, AV57TFReembolsoStatusAtual_F_Sels, AV65TFWorkflowConvenioDesc, AV66TFWorkflowConvenioDesc_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E227N2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E177N2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ReembolsoPropostaPacienteClienteRazaoSocial1, AV67WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ReembolsoPropostaPacienteClienteRazaoSocial2, AV68WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ReembolsoPropostaPacienteClienteRazaoSocial3, AV69WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV70Pgmname, AV15FilterFullText, AV35TFReembolsoPropostaPacienteClienteRazaoSocial, AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, AV37TFReembolsoProtocolo, AV38TFReembolsoProtocolo_Sel, AV39TFReembolsoCreatedAt, AV40TFReembolsoCreatedAt_To, AV44TFReembolsoPropostaValor, AV45TFReembolsoPropostaValor_To, AV46TFReembolsoDataAberturaConvenio, AV47TFReembolsoDataAberturaConvenio_To, AV57TFReembolsoStatusAtual_F_Sels, AV65TFWorkflowConvenioDesc, AV66TFWorkflowConvenioDesc_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E237N2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E117N2( )
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
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("ReembolsoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV70Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("ReembolsoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV33ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ReembolsoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV33ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV70Pgmname+"GridState",  AV33ManageFiltersXml) ;
               AV10GridState.FromXml(AV33ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57TFReembolsoStatusAtual_F_Sels", AV57TFReembolsoStatusAtual_F_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E187N2( )
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
         new reembolsowwexport(context ).execute( out  AV29ExcelFilename, out  AV30ErrorMessage) ;
         if ( StringUtil.StrCmp(AV29ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV29ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV30ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57TFReembolsoStatusAtual_F_Sels", AV57TFReembolsoStatusAtual_F_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavReembolsopropostapacienteclienterazaosocial1_Visible = 0;
         AssignProp("", false, edtavReembolsopropostapacienteclienterazaosocial1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsopropostapacienteclienterazaosocial1_Visible), 5, 0), true);
         edtavWorkflowconveniodesc1_Visible = 0;
         AssignProp("", false, edtavWorkflowconveniodesc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWorkflowconveniodesc1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            edtavReembolsopropostapacienteclienterazaosocial1_Visible = 1;
            AssignProp("", false, edtavReembolsopropostapacienteclienterazaosocial1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsopropostapacienteclienterazaosocial1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "WORKFLOWCONVENIODESC") == 0 )
         {
            edtavWorkflowconveniodesc1_Visible = 1;
            AssignProp("", false, edtavWorkflowconveniodesc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWorkflowconveniodesc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavReembolsopropostapacienteclienterazaosocial2_Visible = 0;
         AssignProp("", false, edtavReembolsopropostapacienteclienterazaosocial2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsopropostapacienteclienterazaosocial2_Visible), 5, 0), true);
         edtavWorkflowconveniodesc2_Visible = 0;
         AssignProp("", false, edtavWorkflowconveniodesc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWorkflowconveniodesc2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            edtavReembolsopropostapacienteclienterazaosocial2_Visible = 1;
            AssignProp("", false, edtavReembolsopropostapacienteclienterazaosocial2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsopropostapacienteclienterazaosocial2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "WORKFLOWCONVENIODESC") == 0 )
         {
            edtavWorkflowconveniodesc2_Visible = 1;
            AssignProp("", false, edtavWorkflowconveniodesc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWorkflowconveniodesc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavReembolsopropostapacienteclienterazaosocial3_Visible = 0;
         AssignProp("", false, edtavReembolsopropostapacienteclienterazaosocial3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsopropostapacienteclienterazaosocial3_Visible), 5, 0), true);
         edtavWorkflowconveniodesc3_Visible = 0;
         AssignProp("", false, edtavWorkflowconveniodesc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWorkflowconveniodesc3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            edtavReembolsopropostapacienteclienterazaosocial3_Visible = 1;
            AssignProp("", false, edtavReembolsopropostapacienteclienterazaosocial3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReembolsopropostapacienteclienterazaosocial3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "WORKFLOWCONVENIODESC") == 0 )
         {
            edtavWorkflowconveniodesc3_Visible = 1;
            AssignProp("", false, edtavWorkflowconveniodesc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWorkflowconveniodesc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22ReembolsoPropostaPacienteClienteRazaoSocial2 = "";
         AssignAttri("", false, "AV22ReembolsoPropostaPacienteClienteRazaoSocial2", AV22ReembolsoPropostaPacienteClienteRazaoSocial2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV26ReembolsoPropostaPacienteClienteRazaoSocial3 = "";
         AssignAttri("", false, "AV26ReembolsoPropostaPacienteClienteRazaoSocial3", AV26ReembolsoPropostaPacienteClienteRazaoSocial3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV32ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ReembolsoWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV32ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV35TFReembolsoPropostaPacienteClienteRazaoSocial = "";
         AssignAttri("", false, "AV35TFReembolsoPropostaPacienteClienteRazaoSocial", AV35TFReembolsoPropostaPacienteClienteRazaoSocial);
         AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel", AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel);
         AV37TFReembolsoProtocolo = "";
         AssignAttri("", false, "AV37TFReembolsoProtocolo", AV37TFReembolsoProtocolo);
         AV38TFReembolsoProtocolo_Sel = "";
         AssignAttri("", false, "AV38TFReembolsoProtocolo_Sel", AV38TFReembolsoProtocolo_Sel);
         AV39TFReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV39TFReembolsoCreatedAt", context.localUtil.TToC( AV39TFReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         AV40TFReembolsoCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV40TFReembolsoCreatedAt_To", context.localUtil.TToC( AV40TFReembolsoCreatedAt_To, 10, 8, 0, 3, "/", ":", " "));
         AV44TFReembolsoPropostaValor = 0;
         AssignAttri("", false, "AV44TFReembolsoPropostaValor", StringUtil.LTrimStr( AV44TFReembolsoPropostaValor, 18, 2));
         AV45TFReembolsoPropostaValor_To = 0;
         AssignAttri("", false, "AV45TFReembolsoPropostaValor_To", StringUtil.LTrimStr( AV45TFReembolsoPropostaValor_To, 18, 2));
         AV46TFReembolsoDataAberturaConvenio = DateTime.MinValue;
         AssignAttri("", false, "AV46TFReembolsoDataAberturaConvenio", context.localUtil.Format(AV46TFReembolsoDataAberturaConvenio, "99/99/9999"));
         AV47TFReembolsoDataAberturaConvenio_To = DateTime.MinValue;
         AssignAttri("", false, "AV47TFReembolsoDataAberturaConvenio_To", context.localUtil.Format(AV47TFReembolsoDataAberturaConvenio_To, "99/99/9999"));
         AV57TFReembolsoStatusAtual_F_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV65TFWorkflowConvenioDesc = "";
         AssignAttri("", false, "AV65TFWorkflowConvenioDesc", AV65TFWorkflowConvenioDesc);
         AV66TFWorkflowConvenioDesc_Sel = "";
         AssignAttri("", false, "AV66TFWorkflowConvenioDesc_Sel", AV66TFWorkflowConvenioDesc_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18ReembolsoPropostaPacienteClienteRazaoSocial1 = "";
         AssignAttri("", false, "AV18ReembolsoPropostaPacienteClienteRazaoSocial1", AV18ReembolsoPropostaPacienteClienteRazaoSocial1);
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
         if ( StringUtil.StrCmp(AV31Session.Get(AV70Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV70Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV31Session.Get(AV70Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV99GXV1 = 1;
         while ( AV99GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV99GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV35TFReembolsoPropostaPacienteClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFReembolsoPropostaPacienteClienteRazaoSocial", AV35TFReembolsoPropostaPacienteClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel", AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROTOCOLO") == 0 )
            {
               AV37TFReembolsoProtocolo = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFReembolsoProtocolo", AV37TFReembolsoProtocolo);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROTOCOLO_SEL") == 0 )
            {
               AV38TFReembolsoProtocolo_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFReembolsoProtocolo_Sel", AV38TFReembolsoProtocolo_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOCREATEDAT") == 0 )
            {
               AV39TFReembolsoCreatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV39TFReembolsoCreatedAt", context.localUtil.TToC( AV39TFReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
               AV40TFReembolsoCreatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV40TFReembolsoCreatedAt_To", context.localUtil.TToC( AV40TFReembolsoCreatedAt_To, 10, 8, 0, 3, "/", ":", " "));
               AV41DDO_ReembolsoCreatedAtAuxDate = DateTimeUtil.ResetTime(AV39TFReembolsoCreatedAt);
               AssignAttri("", false, "AV41DDO_ReembolsoCreatedAtAuxDate", context.localUtil.Format(AV41DDO_ReembolsoCreatedAtAuxDate, "99/99/9999"));
               AV42DDO_ReembolsoCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV40TFReembolsoCreatedAt_To);
               AssignAttri("", false, "AV42DDO_ReembolsoCreatedAtAuxDateTo", context.localUtil.Format(AV42DDO_ReembolsoCreatedAtAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOPROPOSTAVALOR") == 0 )
            {
               AV44TFReembolsoPropostaValor = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV44TFReembolsoPropostaValor", StringUtil.LTrimStr( AV44TFReembolsoPropostaValor, 18, 2));
               AV45TFReembolsoPropostaValor_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV45TFReembolsoPropostaValor_To", StringUtil.LTrimStr( AV45TFReembolsoPropostaValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSODATAABERTURACONVENIO") == 0 )
            {
               AV46TFReembolsoDataAberturaConvenio = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV46TFReembolsoDataAberturaConvenio", context.localUtil.Format(AV46TFReembolsoDataAberturaConvenio, "99/99/9999"));
               AV47TFReembolsoDataAberturaConvenio_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV47TFReembolsoDataAberturaConvenio_To", context.localUtil.Format(AV47TFReembolsoDataAberturaConvenio_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOSTATUSATUAL_F_SEL") == 0 )
            {
               AV56TFReembolsoStatusAtual_F_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56TFReembolsoStatusAtual_F_SelsJson", AV56TFReembolsoStatusAtual_F_SelsJson);
               AV57TFReembolsoStatusAtual_F_Sels.FromJSonString(AV56TFReembolsoStatusAtual_F_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC") == 0 )
            {
               AV65TFWorkflowConvenioDesc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFWorkflowConvenioDesc", AV65TFWorkflowConvenioDesc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC_SEL") == 0 )
            {
               AV66TFWorkflowConvenioDesc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFWorkflowConvenioDesc_Sel", AV66TFWorkflowConvenioDesc_Sel);
            }
            AV99GXV1 = (int)(AV99GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel)),  AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFReembolsoProtocolo_Sel)),  AV38TFReembolsoProtocolo_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV57TFReembolsoStatusAtual_F_Sels.Count==0),  AV56TFReembolsoStatusAtual_F_SelsJson, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFWorkflowConvenioDesc_Sel)),  AV66TFWorkflowConvenioDesc_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"||||"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFReembolsoPropostaPacienteClienteRazaoSocial)),  AV35TFReembolsoPropostaPacienteClienteRazaoSocial, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFReembolsoProtocolo)),  AV37TFReembolsoProtocolo, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFWorkflowConvenioDesc)),  AV65TFWorkflowConvenioDesc, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+((DateTime.MinValue==AV39TFReembolsoCreatedAt) ? "" : context.localUtil.DToC( AV41DDO_ReembolsoCreatedAtAuxDate, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV44TFReembolsoPropostaValor) ? "" : StringUtil.Str( AV44TFReembolsoPropostaValor, 18, 2))+"|"+((DateTime.MinValue==AV46TFReembolsoDataAberturaConvenio) ? "" : context.localUtil.DToC( AV46TFReembolsoDataAberturaConvenio, 4, "/"))+"||"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV40TFReembolsoCreatedAt_To) ? "" : context.localUtil.DToC( AV42DDO_ReembolsoCreatedAtAuxDateTo, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV45TFReembolsoPropostaValor_To) ? "" : StringUtil.Str( AV45TFReembolsoPropostaValor_To, 18, 2))+"|"+((DateTime.MinValue==AV47TFReembolsoDataAberturaConvenio_To) ? "" : context.localUtil.DToC( AV47TFReembolsoDataAberturaConvenio_To, 4, "/"))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S212( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18ReembolsoPropostaPacienteClienteRazaoSocial1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18ReembolsoPropostaPacienteClienteRazaoSocial1", AV18ReembolsoPropostaPacienteClienteRazaoSocial1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "WORKFLOWCONVENIODESC") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV67WorkflowConvenioDesc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV67WorkflowConvenioDesc1", AV67WorkflowConvenioDesc1);
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
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV19DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22ReembolsoPropostaPacienteClienteRazaoSocial2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV22ReembolsoPropostaPacienteClienteRazaoSocial2", AV22ReembolsoPropostaPacienteClienteRazaoSocial2);
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "WORKFLOWCONVENIODESC") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV68WorkflowConvenioDesc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV68WorkflowConvenioDesc2", AV68WorkflowConvenioDesc2);
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
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV23DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV26ReembolsoPropostaPacienteClienteRazaoSocial3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV26ReembolsoPropostaPacienteClienteRazaoSocial3", AV26ReembolsoPropostaPacienteClienteRazaoSocial3);
                  }
                  else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "WORKFLOWCONVENIODESC") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV69WorkflowConvenioDesc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV69WorkflowConvenioDesc3", AV69WorkflowConvenioDesc3);
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
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV27DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV31Session.Get(AV70Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL",  "Paciente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFReembolsoPropostaPacienteClienteRazaoSocial)),  0,  AV35TFReembolsoPropostaPacienteClienteRazaoSocial,  AV35TFReembolsoPropostaPacienteClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel)),  AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel,  AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFREEMBOLSOPROTOCOLO",  "Protocolo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFReembolsoProtocolo)),  0,  AV37TFReembolsoProtocolo,  AV37TFReembolsoProtocolo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFReembolsoProtocolo_Sel)),  AV38TFReembolsoProtocolo_Sel,  AV38TFReembolsoProtocolo_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFREEMBOLSOCREATEDAT",  "Data de inicio",  !((DateTime.MinValue==AV39TFReembolsoCreatedAt)&&(DateTime.MinValue==AV40TFReembolsoCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV39TFReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV39TFReembolsoCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV39TFReembolsoCreatedAt, "99/99/9999 99:99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV40TFReembolsoCreatedAt_To, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV40TFReembolsoCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV40TFReembolsoCreatedAt_To, "99/99/9999 99:99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFREEMBOLSOPROPOSTAVALOR",  "Valor",  !((Convert.ToDecimal(0)==AV44TFReembolsoPropostaValor)&&(Convert.ToDecimal(0)==AV45TFReembolsoPropostaValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV44TFReembolsoPropostaValor, 18, 2)),  ((Convert.ToDecimal(0)==AV44TFReembolsoPropostaValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV44TFReembolsoPropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV45TFReembolsoPropostaValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV45TFReembolsoPropostaValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV45TFReembolsoPropostaValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFREEMBOLSODATAABERTURACONVENIO",  "Data abertura",  !((DateTime.MinValue==AV46TFReembolsoDataAberturaConvenio)&&(DateTime.MinValue==AV47TFReembolsoDataAberturaConvenio_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV46TFReembolsoDataAberturaConvenio, 4, "/")),  ((DateTime.MinValue==AV46TFReembolsoDataAberturaConvenio) ? "" : StringUtil.Trim( context.localUtil.Format( AV46TFReembolsoDataAberturaConvenio, "99/99/9999"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV47TFReembolsoDataAberturaConvenio_To, 4, "/")),  ((DateTime.MinValue==AV47TFReembolsoDataAberturaConvenio_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV47TFReembolsoDataAberturaConvenio_To, "99/99/9999")))) ;
         AV63AuxText = ((AV57TFReembolsoStatusAtual_F_Sels.Count==1) ? "["+((string)AV57TFReembolsoStatusAtual_F_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFREEMBOLSOSTATUSATUAL_F_SEL",  "Status",  !(AV57TFReembolsoStatusAtual_F_Sels.Count==0),  0,  AV57TFReembolsoStatusAtual_F_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV63AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV63AuxText, "[EM_ANALISE]", "Em análise"), "[FINALIZADO]", "Finalizado"), "[REANALISE]", "Reanálise"), "[]", "Não iniciado")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFWORKFLOWCONVENIODESC",  "Passo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFWorkflowConvenioDesc)),  0,  AV65TFWorkflowConvenioDesc,  AV65TFWorkflowConvenioDesc,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFWorkflowConvenioDesc_Sel)),  AV66TFWorkflowConvenioDesc_Sel,  AV66TFWorkflowConvenioDesc_Sel) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV70Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV28DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ReembolsoPropostaPacienteClienteRazaoSocial1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Razao Social",  AV17DynamicFiltersOperator1,  AV18ReembolsoPropostaPacienteClienteRazaoSocial1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18ReembolsoPropostaPacienteClienteRazaoSocial1, "Contém"+" "+AV18ReembolsoPropostaPacienteClienteRazaoSocial1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "WORKFLOWCONVENIODESC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV67WorkflowConvenioDesc1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Passo",  AV17DynamicFiltersOperator1,  AV67WorkflowConvenioDesc1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV67WorkflowConvenioDesc1, "Contém"+" "+AV67WorkflowConvenioDesc1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV20DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ReembolsoPropostaPacienteClienteRazaoSocial2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Razao Social",  AV21DynamicFiltersOperator2,  AV22ReembolsoPropostaPacienteClienteRazaoSocial2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV22ReembolsoPropostaPacienteClienteRazaoSocial2, "Contém"+" "+AV22ReembolsoPropostaPacienteClienteRazaoSocial2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "WORKFLOWCONVENIODESC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV68WorkflowConvenioDesc2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Passo",  AV21DynamicFiltersOperator2,  AV68WorkflowConvenioDesc2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV68WorkflowConvenioDesc2, "Contém"+" "+AV68WorkflowConvenioDesc2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV23DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV24DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ReembolsoPropostaPacienteClienteRazaoSocial3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Razao Social",  AV25DynamicFiltersOperator3,  AV26ReembolsoPropostaPacienteClienteRazaoSocial3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV26ReembolsoPropostaPacienteClienteRazaoSocial3, "Contém"+" "+AV26ReembolsoPropostaPacienteClienteRazaoSocial3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "WORKFLOWCONVENIODESC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV69WorkflowConvenioDesc3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Passo",  AV25DynamicFiltersOperator3,  AV69WorkflowConvenioDesc3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV69WorkflowConvenioDesc3, "Contém"+" "+AV69WorkflowConvenioDesc3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV70Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Reembolso";
         AV31Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_93_7N2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "", true, 0, "HLP_ReembolsoWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reembolsopropostapacienteclienterazaosocial3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsopropostapacienteclienterazaosocial3_Internalname, "Reembolso Proposta Paciente Cliente Razao Social3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsopropostapacienteclienterazaosocial3_Internalname, AV26ReembolsoPropostaPacienteClienteRazaoSocial3, StringUtil.RTrim( context.localUtil.Format( AV26ReembolsoPropostaPacienteClienteRazaoSocial3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsopropostapacienteclienterazaosocial3_Jsonclick, 0, "Attribute", "", "", "", "", edtavReembolsopropostapacienteclienterazaosocial3_Visible, edtavReembolsopropostapacienteclienterazaosocial3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_workflowconveniodesc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWorkflowconveniodesc3_Internalname, "Workflow Convenio Desc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWorkflowconveniodesc3_Internalname, AV69WorkflowConvenioDesc3, StringUtil.RTrim( context.localUtil.Format( AV69WorkflowConvenioDesc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWorkflowconveniodesc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavWorkflowconveniodesc3_Visible, edtavWorkflowconveniodesc3_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ReembolsoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_93_7N2e( true) ;
         }
         else
         {
            wb_table3_93_7N2e( false) ;
         }
      }

      protected void wb_table2_68_7N2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 0, "HLP_ReembolsoWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reembolsopropostapacienteclienterazaosocial2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsopropostapacienteclienterazaosocial2_Internalname, "Reembolso Proposta Paciente Cliente Razao Social2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsopropostapacienteclienterazaosocial2_Internalname, AV22ReembolsoPropostaPacienteClienteRazaoSocial2, StringUtil.RTrim( context.localUtil.Format( AV22ReembolsoPropostaPacienteClienteRazaoSocial2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsopropostapacienteclienterazaosocial2_Jsonclick, 0, "Attribute", "", "", "", "", edtavReembolsopropostapacienteclienterazaosocial2_Visible, edtavReembolsopropostapacienteclienterazaosocial2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_workflowconveniodesc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWorkflowconveniodesc2_Internalname, "Workflow Convenio Desc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWorkflowconveniodesc2_Internalname, AV68WorkflowConvenioDesc2, StringUtil.RTrim( context.localUtil.Format( AV68WorkflowConvenioDesc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWorkflowconveniodesc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavWorkflowconveniodesc2_Visible, edtavWorkflowconveniodesc2_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ReembolsoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ReembolsoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_68_7N2e( true) ;
         }
         else
         {
            wb_table2_68_7N2e( false) ;
         }
      }

      protected void wb_table1_43_7N2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_ReembolsoWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_reembolsopropostapacienteclienterazaosocial1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReembolsopropostapacienteclienterazaosocial1_Internalname, "Reembolso Proposta Paciente Cliente Razao Social1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReembolsopropostapacienteclienterazaosocial1_Internalname, AV18ReembolsoPropostaPacienteClienteRazaoSocial1, StringUtil.RTrim( context.localUtil.Format( AV18ReembolsoPropostaPacienteClienteRazaoSocial1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReembolsopropostapacienteclienterazaosocial1_Jsonclick, 0, "Attribute", "", "", "", "", edtavReembolsopropostapacienteclienterazaosocial1_Visible, edtavReembolsopropostapacienteclienterazaosocial1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_workflowconveniodesc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWorkflowconveniodesc1_Internalname, "Workflow Convenio Desc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWorkflowconveniodesc1_Internalname, AV67WorkflowConvenioDesc1, StringUtil.RTrim( context.localUtil.Format( AV67WorkflowConvenioDesc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWorkflowconveniodesc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavWorkflowconveniodesc1_Visible, edtavWorkflowconveniodesc1_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ReembolsoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ReembolsoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_7N2e( true) ;
         }
         else
         {
            wb_table1_43_7N2e( false) ;
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
         PA7N2( ) ;
         WS7N2( ) ;
         WE7N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101927495", true, true);
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
         context.AddJavascriptSource("reembolsoww.js", "?20256101927495", false, true);
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

      protected void SubsflControlProps_1142( )
      {
         edtavConsulta_Internalname = "vCONSULTA_"+sGXsfl_114_idx;
         edtReembolsoId_Internalname = "REEMBOLSOID_"+sGXsfl_114_idx;
         edtReembolsoPropostaId_Internalname = "REEMBOLSOPROPOSTAID_"+sGXsfl_114_idx;
         edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname = "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_"+sGXsfl_114_idx;
         edtReembolsoPropostaPacienteClienteId_Internalname = "REEMBOLSOPROPOSTAPACIENTECLIENTEID_"+sGXsfl_114_idx;
         edtReembolsoProtocolo_Internalname = "REEMBOLSOPROTOCOLO_"+sGXsfl_114_idx;
         edtReembolsoCreatedAt_Internalname = "REEMBOLSOCREATEDAT_"+sGXsfl_114_idx;
         edtReembolsoPropostaValor_Internalname = "REEMBOLSOPROPOSTAVALOR_"+sGXsfl_114_idx;
         edtReembolsoDataAberturaConvenio_Internalname = "REEMBOLSODATAABERTURACONVENIO_"+sGXsfl_114_idx;
         edtReembolsoCreatedBy_Internalname = "REEMBOLSOCREATEDBY_"+sGXsfl_114_idx;
         edtReembolsoEtapaUltimo_F_Internalname = "REEMBOLSOETAPAULTIMO_F_"+sGXsfl_114_idx;
         cmbReembolsoStatusAtual_F_Internalname = "REEMBOLSOSTATUSATUAL_F_"+sGXsfl_114_idx;
         edtWorkflowConvenioDesc_Internalname = "WORKFLOWCONVENIODESC_"+sGXsfl_114_idx;
      }

      protected void SubsflControlProps_fel_1142( )
      {
         edtavConsulta_Internalname = "vCONSULTA_"+sGXsfl_114_fel_idx;
         edtReembolsoId_Internalname = "REEMBOLSOID_"+sGXsfl_114_fel_idx;
         edtReembolsoPropostaId_Internalname = "REEMBOLSOPROPOSTAID_"+sGXsfl_114_fel_idx;
         edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname = "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_"+sGXsfl_114_fel_idx;
         edtReembolsoPropostaPacienteClienteId_Internalname = "REEMBOLSOPROPOSTAPACIENTECLIENTEID_"+sGXsfl_114_fel_idx;
         edtReembolsoProtocolo_Internalname = "REEMBOLSOPROTOCOLO_"+sGXsfl_114_fel_idx;
         edtReembolsoCreatedAt_Internalname = "REEMBOLSOCREATEDAT_"+sGXsfl_114_fel_idx;
         edtReembolsoPropostaValor_Internalname = "REEMBOLSOPROPOSTAVALOR_"+sGXsfl_114_fel_idx;
         edtReembolsoDataAberturaConvenio_Internalname = "REEMBOLSODATAABERTURACONVENIO_"+sGXsfl_114_fel_idx;
         edtReembolsoCreatedBy_Internalname = "REEMBOLSOCREATEDBY_"+sGXsfl_114_fel_idx;
         edtReembolsoEtapaUltimo_F_Internalname = "REEMBOLSOETAPAULTIMO_F_"+sGXsfl_114_fel_idx;
         cmbReembolsoStatusAtual_F_Internalname = "REEMBOLSOSTATUSATUAL_F_"+sGXsfl_114_fel_idx;
         edtWorkflowConvenioDesc_Internalname = "WORKFLOWCONVENIODESC_"+sGXsfl_114_fel_idx;
      }

      protected void sendrow_1142( )
      {
         sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
         SubsflControlProps_1142( ) ;
         WB7N0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_114_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_114_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_114_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_114_idx + "',114)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavConsulta_Internalname,StringUtil.RTrim( AV64Consulta),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavConsulta_Link,(string)"",(string)"",(string)"",(string)edtavConsulta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavConsulta_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A518ReembolsoId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoPropostaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A542ReembolsoPropostaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoPropostaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname,(string)A550ReembolsoPropostaPacienteClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A550ReembolsoPropostaPacienteClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoPropostaPacienteClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoPropostaPacienteClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A558ReembolsoPropostaPacienteClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A558ReembolsoPropostaPacienteClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoPropostaPacienteClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoProtocolo_Internalname,(string)A546ReembolsoProtocolo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoProtocolo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoCreatedAt_Internalname,context.localUtil.TToC( A522ReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A522ReembolsoCreatedAt, "99/99/9999 99:99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoPropostaValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A543ReembolsoPropostaValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A543ReembolsoPropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoPropostaValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoDataAberturaConvenio_Internalname,context.localUtil.Format(A525ReembolsoDataAberturaConvenio, "99/99/9999"),context.localUtil.Format( A525ReembolsoDataAberturaConvenio, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoDataAberturaConvenio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoCreatedBy_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A544ReembolsoCreatedBy), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoCreatedBy_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoEtapaUltimo_F_Internalname,context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A547ReembolsoEtapaUltimo_F, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoEtapaUltimo_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "REEMBOLSOSTATUSATUAL_F_" + sGXsfl_114_idx;
            cmbReembolsoStatusAtual_F.Name = GXCCtl;
            cmbReembolsoStatusAtual_F.WebTags = "";
            cmbReembolsoStatusAtual_F.addItem("", "", 0);
            cmbReembolsoStatusAtual_F.addItem("EM_ANALISE", "Em análise", 0);
            cmbReembolsoStatusAtual_F.addItem("FINALIZADO", "Finalizado", 0);
            cmbReembolsoStatusAtual_F.addItem("REANALISE", "Reanálise", 0);
            cmbReembolsoStatusAtual_F.addItem("", "Não iniciado", 0);
            if ( cmbReembolsoStatusAtual_F.ItemCount > 0 )
            {
               A548ReembolsoStatusAtual_F = cmbReembolsoStatusAtual_F.getValidValue(A548ReembolsoStatusAtual_F);
               n548ReembolsoStatusAtual_F = false;
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbReembolsoStatusAtual_F,(string)cmbReembolsoStatusAtual_F_Internalname,StringUtil.RTrim( A548ReembolsoStatusAtual_F),(short)1,(string)cmbReembolsoStatusAtual_F_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbReembolsoStatusAtual_F_Columnclass,(string)cmbReembolsoStatusAtual_F_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbReembolsoStatusAtual_F.CurrentValue = StringUtil.RTrim( A548ReembolsoStatusAtual_F);
            AssignProp("", false, cmbReembolsoStatusAtual_F_Internalname, "Values", (string)(cmbReembolsoStatusAtual_F.ToJavascriptSource()), !bGXsfl_114_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkflowConvenioDesc_Internalname,(string)A736WorkflowConvenioDesc,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtWorkflowConvenioDesc_Link,(string)"",(string)"",(string)"",(string)edtWorkflowConvenioDesc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes7N2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_114_idx = ((subGrid_Islastpage==1)&&(nGXsfl_114_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_114_idx+1);
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
         }
         /* End function sendrow_1142 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", "Razao Social", 0);
         cmbavDynamicfiltersselector1.addItem("WORKFLOWCONVENIODESC", "Passo", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", "Razao Social", 0);
         cmbavDynamicfiltersselector2.addItem("WORKFLOWCONVENIODESC", "Passo", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL", "Razao Social", 0);
         cmbavDynamicfiltersselector3.addItem("WORKFLOWCONVENIODESC", "Passo", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "REEMBOLSOSTATUSATUAL_F_" + sGXsfl_114_idx;
         cmbReembolsoStatusAtual_F.Name = GXCCtl;
         cmbReembolsoStatusAtual_F.WebTags = "";
         cmbReembolsoStatusAtual_F.addItem("", "", 0);
         cmbReembolsoStatusAtual_F.addItem("EM_ANALISE", "Em análise", 0);
         cmbReembolsoStatusAtual_F.addItem("FINALIZADO", "Finalizado", 0);
         cmbReembolsoStatusAtual_F.addItem("REANALISE", "Reanálise", 0);
         cmbReembolsoStatusAtual_F.addItem("", "Não iniciado", 0);
         if ( cmbReembolsoStatusAtual_F.ItemCount > 0 )
         {
            A548ReembolsoStatusAtual_F = cmbReembolsoStatusAtual_F.getValidValue(A548ReembolsoStatusAtual_F);
            n548ReembolsoStatusAtual_F = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl114( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"114\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Proposta Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Paciente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cliente Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Protocolo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data de inicio") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data abertura") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Created By") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Passo") ;
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
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV64Consulta)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavConsulta_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavConsulta_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A542ReembolsoPropostaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A550ReembolsoPropostaPacienteClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A558ReembolsoPropostaPacienteClienteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A546ReembolsoProtocolo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A522ReembolsoCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A543ReembolsoPropostaValor, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A525ReembolsoDataAberturaConvenio, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A544ReembolsoCreatedBy), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A547ReembolsoEtapaUltimo_F, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A548ReembolsoStatusAtual_F));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbReembolsoStatusAtual_F_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbReembolsoStatusAtual_F_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A736WorkflowConvenioDesc));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtWorkflowConvenioDesc_Link));
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
         bttBtnexport_Internalname = "BTNEXPORT";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavReembolsopropostapacienteclienterazaosocial1_Internalname = "vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1";
         cellFilter_reembolsopropostapacienteclienterazaosocial1_cell_Internalname = "FILTER_REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1_CELL";
         edtavWorkflowconveniodesc1_Internalname = "vWORKFLOWCONVENIODESC1";
         cellFilter_workflowconveniodesc1_cell_Internalname = "FILTER_WORKFLOWCONVENIODESC1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = "TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = "vDYNAMICFILTERSOPERATOR2";
         edtavReembolsopropostapacienteclienterazaosocial2_Internalname = "vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2";
         cellFilter_reembolsopropostapacienteclienterazaosocial2_cell_Internalname = "FILTER_REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2_CELL";
         edtavWorkflowconveniodesc2_Internalname = "vWORKFLOWCONVENIODESC2";
         cellFilter_workflowconveniodesc2_cell_Internalname = "FILTER_WORKFLOWCONVENIODESC2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = "TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = "vDYNAMICFILTERSOPERATOR3";
         edtavReembolsopropostapacienteclienterazaosocial3_Internalname = "vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3";
         cellFilter_reembolsopropostapacienteclienterazaosocial3_cell_Internalname = "FILTER_REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3_CELL";
         edtavWorkflowconveniodesc3_Internalname = "vWORKFLOWCONVENIODESC3";
         cellFilter_workflowconveniodesc3_cell_Internalname = "FILTER_WORKFLOWCONVENIODESC3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavConsulta_Internalname = "vCONSULTA";
         edtReembolsoId_Internalname = "REEMBOLSOID";
         edtReembolsoPropostaId_Internalname = "REEMBOLSOPROPOSTAID";
         edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname = "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL";
         edtReembolsoPropostaPacienteClienteId_Internalname = "REEMBOLSOPROPOSTAPACIENTECLIENTEID";
         edtReembolsoProtocolo_Internalname = "REEMBOLSOPROTOCOLO";
         edtReembolsoCreatedAt_Internalname = "REEMBOLSOCREATEDAT";
         edtReembolsoPropostaValor_Internalname = "REEMBOLSOPROPOSTAVALOR";
         edtReembolsoDataAberturaConvenio_Internalname = "REEMBOLSODATAABERTURACONVENIO";
         edtReembolsoCreatedBy_Internalname = "REEMBOLSOCREATEDBY";
         edtReembolsoEtapaUltimo_F_Internalname = "REEMBOLSOETAPAULTIMO_F";
         cmbReembolsoStatusAtual_F_Internalname = "REEMBOLSOSTATUSATUAL_F";
         edtWorkflowConvenioDesc_Internalname = "WORKFLOWCONVENIODESC";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_reembolsocreatedatauxdatetext_Internalname = "vDDO_REEMBOLSOCREATEDATAUXDATETEXT";
         Tfreembolsocreatedat_rangepicker_Internalname = "TFREEMBOLSOCREATEDAT_RANGEPICKER";
         divDdo_reembolsocreatedatauxdates_Internalname = "DDO_REEMBOLSOCREATEDATAUXDATES";
         edtavDdo_reembolsodataaberturaconvenioauxdatetext_Internalname = "vDDO_REEMBOLSODATAABERTURACONVENIOAUXDATETEXT";
         Tfreembolsodataaberturaconvenio_rangepicker_Internalname = "TFREEMBOLSODATAABERTURACONVENIO_RANGEPICKER";
         divDdo_reembolsodataaberturaconvenioauxdates_Internalname = "DDO_REEMBOLSODATAABERTURACONVENIOAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtWorkflowConvenioDesc_Jsonclick = "";
         edtWorkflowConvenioDesc_Link = "";
         cmbReembolsoStatusAtual_F_Jsonclick = "";
         cmbReembolsoStatusAtual_F_Columnclass = "WWColumn";
         edtReembolsoEtapaUltimo_F_Jsonclick = "";
         edtReembolsoCreatedBy_Jsonclick = "";
         edtReembolsoDataAberturaConvenio_Jsonclick = "";
         edtReembolsoPropostaValor_Jsonclick = "";
         edtReembolsoCreatedAt_Jsonclick = "";
         edtReembolsoProtocolo_Jsonclick = "";
         edtReembolsoPropostaPacienteClienteId_Jsonclick = "";
         edtReembolsoPropostaPacienteClienteRazaoSocial_Jsonclick = "";
         edtReembolsoPropostaId_Jsonclick = "";
         edtReembolsoId_Jsonclick = "";
         edtavConsulta_Jsonclick = "";
         edtavConsulta_Link = "";
         edtavConsulta_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavWorkflowconveniodesc1_Jsonclick = "";
         edtavWorkflowconveniodesc1_Enabled = 1;
         edtavReembolsopropostapacienteclienterazaosocial1_Jsonclick = "";
         edtavReembolsopropostapacienteclienterazaosocial1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavWorkflowconveniodesc2_Jsonclick = "";
         edtavWorkflowconveniodesc2_Enabled = 1;
         edtavReembolsopropostapacienteclienterazaosocial2_Jsonclick = "";
         edtavReembolsopropostapacienteclienterazaosocial2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavWorkflowconveniodesc3_Jsonclick = "";
         edtavWorkflowconveniodesc3_Enabled = 1;
         edtavReembolsopropostapacienteclienterazaosocial3_Jsonclick = "";
         edtavReembolsopropostapacienteclienterazaosocial3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavWorkflowconveniodesc3_Visible = 1;
         edtavReembolsopropostapacienteclienterazaosocial3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavWorkflowconveniodesc2_Visible = 1;
         edtavReembolsopropostapacienteclienterazaosocial2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavWorkflowconveniodesc1_Visible = 1;
         edtavReembolsopropostapacienteclienterazaosocial1_Visible = 1;
         cmbReembolsoStatusAtual_F_Columnheaderclass = "";
         edtWorkflowConvenioDesc_Enabled = 0;
         cmbReembolsoStatusAtual_F.Enabled = 0;
         edtReembolsoEtapaUltimo_F_Enabled = 0;
         edtReembolsoCreatedBy_Enabled = 0;
         edtReembolsoDataAberturaConvenio_Enabled = 0;
         edtReembolsoPropostaValor_Enabled = 0;
         edtReembolsoCreatedAt_Enabled = 0;
         edtReembolsoProtocolo_Enabled = 0;
         edtReembolsoPropostaPacienteClienteId_Enabled = 0;
         edtReembolsoPropostaPacienteClienteRazaoSocial_Enabled = 0;
         edtReembolsoPropostaId_Enabled = 0;
         edtReembolsoId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_reembolsodataaberturaconvenioauxdatetext_Jsonclick = "";
         edtavDdo_reembolsocreatedatauxdatetext_Jsonclick = "";
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
         Ddo_grid_Format = "|||18.2|||";
         Ddo_grid_Datalistproc = "ReembolsoWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||EM_ANALISE:Em análise,FINALIZADO:Finalizado,REANALISE:Reanálise,:Não iniciado|";
         Ddo_grid_Allowmultipleselection = "|||||T|";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic||||FixedValues|Dynamic";
         Ddo_grid_Includedatalist = "T|T||||T|T";
         Ddo_grid_Filterisrange = "||P|T|P||";
         Ddo_grid_Filtertype = "Character|Character|Date|Numeric|Date||Character";
         Ddo_grid_Includefilter = "T|T|T|T|T||T";
         Ddo_grid_Includesortasc = "T|T|T|T|T||T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5||6";
         Ddo_grid_Columnids = "3:ReembolsoPropostaPacienteClienteRazaoSocial|5:ReembolsoProtocolo|6:ReembolsoCreatedAt|7:ReembolsoPropostaValor|8:ReembolsoDataAberturaConvenio|11:ReembolsoStatusAtual_F|12:WorkflowConvenioDesc";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Reembolso";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E127N2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E137N2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E147N2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV56TFReembolsoStatusAtual_F_SelsJson","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E267N2","iparms":[{"av":"A542ReembolsoPropostaId","fld":"REEMBOLSOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A742WorkflowConvenioId","fld":"WORKFLOWCONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"A548ReembolsoStatusAtual_F","fld":"REEMBOLSOSTATUSATUAL_F","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV64Consulta","fld":"vCONSULTA","type":"char"},{"av":"edtavConsulta_Link","ctrl":"vCONSULTA","prop":"Link"},{"av":"edtWorkflowConvenioDesc_Link","ctrl":"WORKFLOWCONVENIODESC","prop":"Link"},{"av":"cmbReembolsoStatusAtual_F"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E197N2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E157N2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"edtavReembolsopropostapacienteclienterazaosocial2_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavReembolsopropostapacienteclienterazaosocial3_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"edtavReembolsopropostapacienteclienterazaosocial1_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E207N2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavReembolsopropostapacienteclienterazaosocial1_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E217N2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E167N2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"edtavReembolsopropostapacienteclienterazaosocial2_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavReembolsopropostapacienteclienterazaosocial3_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"edtavReembolsopropostapacienteclienterazaosocial1_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E227N2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavReembolsopropostapacienteclienterazaosocial2_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E177N2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"edtavReembolsopropostapacienteclienterazaosocial2_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavReembolsopropostapacienteclienterazaosocial3_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"edtavReembolsopropostapacienteclienterazaosocial1_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E237N2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavReembolsopropostapacienteclienterazaosocial3_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E117N2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV56TFReembolsoStatusAtual_F_SelsJson","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"},{"av":"AV41DDO_ReembolsoCreatedAtAuxDate","fld":"vDDO_REEMBOLSOCREATEDATAUXDATE","type":"date"},{"av":"AV42DDO_ReembolsoCreatedAtAuxDateTo","fld":"vDDO_REEMBOLSOCREATEDATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV56TFReembolsoStatusAtual_F_SelsJson","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"},{"av":"AV41DDO_ReembolsoCreatedAtAuxDate","fld":"vDDO_REEMBOLSOCREATEDATAUXDATE","type":"date"},{"av":"AV42DDO_ReembolsoCreatedAtAuxDateTo","fld":"vDDO_REEMBOLSOCREATEDATAUXDATETO","type":"date"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"edtavReembolsopropostapacienteclienterazaosocial1_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"edtavReembolsopropostapacienteclienterazaosocial2_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavReembolsopropostapacienteclienterazaosocial3_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"AV60GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbReembolsoStatusAtual_F"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E187N2","iparms":[{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV56TFReembolsoStatusAtual_F_SelsJson","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV41DDO_ReembolsoCreatedAtAuxDate","fld":"vDDO_REEMBOLSOCREATEDATAUXDATE","type":"date"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV42DDO_ReembolsoCreatedAtAuxDateTo","fld":"vDDO_REEMBOLSOCREATEDATAUXDATETO","type":"date"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ReembolsoPropostaPacienteClienteRazaoSocial1","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","pic":"@!","type":"svchar"},{"av":"AV67WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ReembolsoPropostaPacienteClienteRazaoSocial2","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","pic":"@!","type":"svchar"},{"av":"AV68WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ReembolsoPropostaPacienteClienteRazaoSocial3","fld":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","pic":"@!","type":"svchar"},{"av":"AV69WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFReembolsoPropostaPacienteClienteRazaoSocial","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel","fld":"vTFREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV37TFReembolsoProtocolo","fld":"vTFREEMBOLSOPROTOCOLO","type":"svchar"},{"av":"AV38TFReembolsoProtocolo_Sel","fld":"vTFREEMBOLSOPROTOCOLO_SEL","type":"svchar"},{"av":"AV39TFReembolsoCreatedAt","fld":"vTFREEMBOLSOCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV40TFReembolsoCreatedAt_To","fld":"vTFREEMBOLSOCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV44TFReembolsoPropostaValor","fld":"vTFREEMBOLSOPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFReembolsoPropostaValor_To","fld":"vTFREEMBOLSOPROPOSTAVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFReembolsoDataAberturaConvenio","fld":"vTFREEMBOLSODATAABERTURACONVENIO","type":"date"},{"av":"AV47TFReembolsoDataAberturaConvenio_To","fld":"vTFREEMBOLSODATAABERTURACONVENIO_TO","type":"date"},{"av":"AV57TFReembolsoStatusAtual_F_Sels","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELS","type":""},{"av":"AV65TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV66TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV56TFReembolsoStatusAtual_F_SelsJson","fld":"vTFREEMBOLSOSTATUSATUAL_F_SELSJSON","type":"vchar"},{"av":"AV41DDO_ReembolsoCreatedAtAuxDate","fld":"vDDO_REEMBOLSOCREATEDATAUXDATE","type":"date"},{"av":"AV42DDO_ReembolsoCreatedAtAuxDateTo","fld":"vDDO_REEMBOLSOCREATEDATAUXDATETO","type":"date"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavReembolsopropostapacienteclienterazaosocial1_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL1","prop":"Visible"},{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"edtavReembolsopropostapacienteclienterazaosocial2_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL2","prop":"Visible"},{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavReembolsopropostapacienteclienterazaosocial3_Visible","ctrl":"vREEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL3","prop":"Visible"},{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"}]}""");
         setEventMetadata("VALID_REEMBOLSOID","""{"handler":"Valid_Reembolsoid","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOPROPOSTAID","""{"handler":"Valid_Reembolsopropostaid","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL","""{"handler":"Valid_Reembolsopropostapacienteclienterazaosocial","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOPROPOSTAPACIENTECLIENTEID","""{"handler":"Valid_Reembolsopropostapacienteclienteid","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOPROTOCOLO","""{"handler":"Valid_Reembolsoprotocolo","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOPROPOSTAVALOR","""{"handler":"Valid_Reembolsopropostavalor","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOSTATUSATUAL_F","""{"handler":"Valid_Reembolsostatusatual_f","iparms":[]}""");
         setEventMetadata("VALID_WORKFLOWCONVENIODESC","""{"handler":"Valid_Workflowconveniodesc","iparms":[]}""");
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
         AV16DynamicFiltersSelector1 = "";
         AV18ReembolsoPropostaPacienteClienteRazaoSocial1 = "";
         AV67WorkflowConvenioDesc1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV22ReembolsoPropostaPacienteClienteRazaoSocial2 = "";
         AV68WorkflowConvenioDesc2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26ReembolsoPropostaPacienteClienteRazaoSocial3 = "";
         AV69WorkflowConvenioDesc3 = "";
         AV70Pgmname = "";
         AV15FilterFullText = "";
         AV35TFReembolsoPropostaPacienteClienteRazaoSocial = "";
         AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel = "";
         AV37TFReembolsoProtocolo = "";
         AV38TFReembolsoProtocolo_Sel = "";
         AV39TFReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         AV40TFReembolsoCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV46TFReembolsoDataAberturaConvenio = DateTime.MinValue;
         AV47TFReembolsoDataAberturaConvenio_To = DateTime.MinValue;
         AV57TFReembolsoStatusAtual_F_Sels = new GxSimpleCollection<string>();
         AV65TFWorkflowConvenioDesc = "";
         AV66TFWorkflowConvenioDesc_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV32ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV62GridAppliedFilters = "";
         AV58DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV41DDO_ReembolsoCreatedAtAuxDate = DateTime.MinValue;
         AV42DDO_ReembolsoCreatedAtAuxDateTo = DateTime.MinValue;
         AV48DDO_ReembolsoDataAberturaConvenioAuxDate = DateTime.MinValue;
         AV49DDO_ReembolsoDataAberturaConvenioAuxDateTo = DateTime.MinValue;
         AV56TFReembolsoStatusAtual_F_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
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
         AV43DDO_ReembolsoCreatedAtAuxDateText = "";
         ucTfreembolsocreatedat_rangepicker = new GXUserControl();
         AV50DDO_ReembolsoDataAberturaConvenioAuxDateText = "";
         ucTfreembolsodataaberturaconvenio_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV64Consulta = "";
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         A546ReembolsoProtocolo = "";
         A522ReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         A525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         A547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
         A548ReembolsoStatusAtual_F = "";
         A736WorkflowConvenioDesc = "";
         AV71Reembolsowwds_1_filterfulltext = "";
         AV72Reembolsowwds_2_dynamicfiltersselector1 = "";
         AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = "";
         AV75Reembolsowwds_5_workflowconveniodesc1 = "";
         AV77Reembolsowwds_7_dynamicfiltersselector2 = "";
         AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = "";
         AV80Reembolsowwds_10_workflowconveniodesc2 = "";
         AV82Reembolsowwds_12_dynamicfiltersselector3 = "";
         AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = "";
         AV85Reembolsowwds_15_workflowconveniodesc3 = "";
         AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = "";
         AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel = "";
         AV88Reembolsowwds_18_tfreembolsoprotocolo = "";
         AV89Reembolsowwds_19_tfreembolsoprotocolo_sel = "";
         AV90Reembolsowwds_20_tfreembolsocreatedat = (DateTime)(DateTime.MinValue);
         AV91Reembolsowwds_21_tfreembolsocreatedat_to = (DateTime)(DateTime.MinValue);
         AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio = DateTime.MinValue;
         AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to = DateTime.MinValue;
         AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels = new GxSimpleCollection<string>();
         AV97Reembolsowwds_27_tfworkflowconveniodesc = "";
         AV98Reembolsowwds_28_tfworkflowconveniodesc_sel = "";
         lV71Reembolsowwds_1_filterfulltext = "";
         lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 = "";
         lV75Reembolsowwds_5_workflowconveniodesc1 = "";
         lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 = "";
         lV80Reembolsowwds_10_workflowconveniodesc2 = "";
         lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 = "";
         lV85Reembolsowwds_15_workflowconveniodesc3 = "";
         lV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial = "";
         lV88Reembolsowwds_18_tfreembolsoprotocolo = "";
         lV97Reembolsowwds_27_tfworkflowconveniodesc = "";
         H007N3_A742WorkflowConvenioId = new int[1] ;
         H007N3_n742WorkflowConvenioId = new bool[] {false} ;
         H007N3_A736WorkflowConvenioDesc = new string[] {""} ;
         H007N3_n736WorkflowConvenioDesc = new bool[] {false} ;
         H007N3_A544ReembolsoCreatedBy = new short[1] ;
         H007N3_n544ReembolsoCreatedBy = new bool[] {false} ;
         H007N3_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         H007N3_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         H007N3_A543ReembolsoPropostaValor = new decimal[1] ;
         H007N3_n543ReembolsoPropostaValor = new bool[] {false} ;
         H007N3_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H007N3_n522ReembolsoCreatedAt = new bool[] {false} ;
         H007N3_A546ReembolsoProtocolo = new string[] {""} ;
         H007N3_n546ReembolsoProtocolo = new bool[] {false} ;
         H007N3_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         H007N3_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         H007N3_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H007N3_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H007N3_A542ReembolsoPropostaId = new int[1] ;
         H007N3_n542ReembolsoPropostaId = new bool[] {false} ;
         H007N3_A518ReembolsoId = new int[1] ;
         H007N3_n518ReembolsoId = new bool[] {false} ;
         H007N3_A547ReembolsoEtapaUltimo_F = new DateTime[] {DateTime.MinValue} ;
         H007N3_n547ReembolsoEtapaUltimo_F = new bool[] {false} ;
         H007N5_A742WorkflowConvenioId = new int[1] ;
         H007N5_n742WorkflowConvenioId = new bool[] {false} ;
         H007N5_A736WorkflowConvenioDesc = new string[] {""} ;
         H007N5_n736WorkflowConvenioDesc = new bool[] {false} ;
         H007N5_A544ReembolsoCreatedBy = new short[1] ;
         H007N5_n544ReembolsoCreatedBy = new bool[] {false} ;
         H007N5_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         H007N5_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         H007N5_A543ReembolsoPropostaValor = new decimal[1] ;
         H007N5_n543ReembolsoPropostaValor = new bool[] {false} ;
         H007N5_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H007N5_n522ReembolsoCreatedAt = new bool[] {false} ;
         H007N5_A546ReembolsoProtocolo = new string[] {""} ;
         H007N5_n546ReembolsoProtocolo = new bool[] {false} ;
         H007N5_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         H007N5_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         H007N5_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H007N5_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H007N5_A542ReembolsoPropostaId = new int[1] ;
         H007N5_n542ReembolsoPropostaId = new bool[] {false} ;
         H007N5_A518ReembolsoId = new int[1] ;
         H007N5_n518ReembolsoId = new bool[] {false} ;
         H007N5_A547ReembolsoEtapaUltimo_F = new DateTime[] {DateTime.MinValue} ;
         H007N5_n547ReembolsoEtapaUltimo_F = new bool[] {false} ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV33ManageFiltersXml = "";
         AV29ExcelFilename = "";
         AV30ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV31Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV63AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoww__default(),
            new Object[][] {
                new Object[] {
               H007N3_A742WorkflowConvenioId, H007N3_n742WorkflowConvenioId, H007N3_A736WorkflowConvenioDesc, H007N3_n736WorkflowConvenioDesc, H007N3_A544ReembolsoCreatedBy, H007N3_n544ReembolsoCreatedBy, H007N3_A525ReembolsoDataAberturaConvenio, H007N3_n525ReembolsoDataAberturaConvenio, H007N3_A543ReembolsoPropostaValor, H007N3_n543ReembolsoPropostaValor,
               H007N3_A522ReembolsoCreatedAt, H007N3_n522ReembolsoCreatedAt, H007N3_A546ReembolsoProtocolo, H007N3_n546ReembolsoProtocolo, H007N3_A558ReembolsoPropostaPacienteClienteId, H007N3_n558ReembolsoPropostaPacienteClienteId, H007N3_A550ReembolsoPropostaPacienteClienteRazaoSocial, H007N3_n550ReembolsoPropostaPacienteClienteRazaoSocial, H007N3_A542ReembolsoPropostaId, H007N3_n542ReembolsoPropostaId,
               H007N3_A518ReembolsoId, H007N3_A547ReembolsoEtapaUltimo_F, H007N3_n547ReembolsoEtapaUltimo_F
               }
               , new Object[] {
               H007N5_A742WorkflowConvenioId, H007N5_n742WorkflowConvenioId, H007N5_A736WorkflowConvenioDesc, H007N5_n736WorkflowConvenioDesc, H007N5_A544ReembolsoCreatedBy, H007N5_n544ReembolsoCreatedBy, H007N5_A525ReembolsoDataAberturaConvenio, H007N5_n525ReembolsoDataAberturaConvenio, H007N5_A543ReembolsoPropostaValor, H007N5_n543ReembolsoPropostaValor,
               H007N5_A522ReembolsoCreatedAt, H007N5_n522ReembolsoCreatedAt, H007N5_A546ReembolsoProtocolo, H007N5_n546ReembolsoProtocolo, H007N5_A558ReembolsoPropostaPacienteClienteId, H007N5_n558ReembolsoPropostaPacienteClienteId, H007N5_A550ReembolsoPropostaPacienteClienteRazaoSocial, H007N5_n550ReembolsoPropostaPacienteClienteRazaoSocial, H007N5_A542ReembolsoPropostaId, H007N5_n542ReembolsoPropostaId,
               H007N5_A518ReembolsoId, H007N5_A547ReembolsoEtapaUltimo_F, H007N5_n547ReembolsoEtapaUltimo_F
               }
            }
         );
         AV70Pgmname = "ReembolsoWW";
         /* GeneXus formulas. */
         AV70Pgmname = "ReembolsoWW";
         edtavConsulta_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV34ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A544ReembolsoCreatedBy ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV73Reembolsowwds_3_dynamicfiltersoperator1 ;
      private short AV78Reembolsowwds_8_dynamicfiltersoperator2 ;
      private short AV83Reembolsowwds_13_dynamicfiltersoperator3 ;
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
      private int nRC_GXsfl_114 ;
      private int nGXsfl_114_idx=1 ;
      private int A742WorkflowConvenioId ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A518ReembolsoId ;
      private int A542ReembolsoPropostaId ;
      private int A558ReembolsoPropostaPacienteClienteId ;
      private int subGrid_Islastpage ;
      private int edtavConsulta_Enabled ;
      private int AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels_Count ;
      private int edtReembolsoId_Enabled ;
      private int edtReembolsoPropostaId_Enabled ;
      private int edtReembolsoPropostaPacienteClienteRazaoSocial_Enabled ;
      private int edtReembolsoPropostaPacienteClienteId_Enabled ;
      private int edtReembolsoProtocolo_Enabled ;
      private int edtReembolsoCreatedAt_Enabled ;
      private int edtReembolsoPropostaValor_Enabled ;
      private int edtReembolsoDataAberturaConvenio_Enabled ;
      private int edtReembolsoCreatedBy_Enabled ;
      private int edtReembolsoEtapaUltimo_F_Enabled ;
      private int edtWorkflowConvenioDesc_Enabled ;
      private int AV59PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavReembolsopropostapacienteclienterazaosocial1_Visible ;
      private int edtavWorkflowconveniodesc1_Visible ;
      private int edtavReembolsopropostapacienteclienterazaosocial2_Visible ;
      private int edtavWorkflowconveniodesc2_Visible ;
      private int edtavReembolsopropostapacienteclienterazaosocial3_Visible ;
      private int edtavWorkflowconveniodesc3_Visible ;
      private int AV99GXV1 ;
      private int edtavReembolsopropostapacienteclienterazaosocial3_Enabled ;
      private int edtavWorkflowconveniodesc3_Enabled ;
      private int edtavReembolsopropostapacienteclienterazaosocial2_Enabled ;
      private int edtavWorkflowconveniodesc2_Enabled ;
      private int edtavReembolsopropostapacienteclienterazaosocial1_Enabled ;
      private int edtavWorkflowconveniodesc1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV60GridCurrentPage ;
      private long AV61GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV44TFReembolsoPropostaValor ;
      private decimal AV45TFReembolsoPropostaValor_To ;
      private decimal A543ReembolsoPropostaValor ;
      private decimal AV92Reembolsowwds_22_tfreembolsopropostavalor ;
      private decimal AV93Reembolsowwds_23_tfreembolsopropostavalor_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_114_idx="0001" ;
      private string AV70Pgmname ;
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
      private string Ddo_grid_Format ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
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
      private string divDdo_reembolsocreatedatauxdates_Internalname ;
      private string edtavDdo_reembolsocreatedatauxdatetext_Internalname ;
      private string edtavDdo_reembolsocreatedatauxdatetext_Jsonclick ;
      private string Tfreembolsocreatedat_rangepicker_Internalname ;
      private string divDdo_reembolsodataaberturaconvenioauxdates_Internalname ;
      private string edtavDdo_reembolsodataaberturaconvenioauxdatetext_Internalname ;
      private string edtavDdo_reembolsodataaberturaconvenioauxdatetext_Jsonclick ;
      private string Tfreembolsodataaberturaconvenio_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV64Consulta ;
      private string edtavConsulta_Internalname ;
      private string edtReembolsoId_Internalname ;
      private string edtReembolsoPropostaId_Internalname ;
      private string edtReembolsoPropostaPacienteClienteRazaoSocial_Internalname ;
      private string edtReembolsoPropostaPacienteClienteId_Internalname ;
      private string edtReembolsoProtocolo_Internalname ;
      private string edtReembolsoCreatedAt_Internalname ;
      private string edtReembolsoPropostaValor_Internalname ;
      private string edtReembolsoDataAberturaConvenio_Internalname ;
      private string edtReembolsoCreatedBy_Internalname ;
      private string edtReembolsoEtapaUltimo_F_Internalname ;
      private string cmbReembolsoStatusAtual_F_Internalname ;
      private string edtWorkflowConvenioDesc_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavReembolsopropostapacienteclienterazaosocial1_Internalname ;
      private string edtavWorkflowconveniodesc1_Internalname ;
      private string edtavReembolsopropostapacienteclienterazaosocial2_Internalname ;
      private string edtavWorkflowconveniodesc2_Internalname ;
      private string edtavReembolsopropostapacienteclienterazaosocial3_Internalname ;
      private string edtavWorkflowconveniodesc3_Internalname ;
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
      private string cmbReembolsoStatusAtual_F_Columnheaderclass ;
      private string edtavConsulta_Link ;
      private string GXEncryptionTmp ;
      private string edtWorkflowConvenioDesc_Link ;
      private string cmbReembolsoStatusAtual_F_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_reembolsopropostapacienteclienterazaosocial3_cell_Internalname ;
      private string edtavReembolsopropostapacienteclienterazaosocial3_Jsonclick ;
      private string cellFilter_workflowconveniodesc3_cell_Internalname ;
      private string edtavWorkflowconveniodesc3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_reembolsopropostapacienteclienterazaosocial2_cell_Internalname ;
      private string edtavReembolsopropostapacienteclienterazaosocial2_Jsonclick ;
      private string cellFilter_workflowconveniodesc2_cell_Internalname ;
      private string edtavWorkflowconveniodesc2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_reembolsopropostapacienteclienterazaosocial1_cell_Internalname ;
      private string edtavReembolsopropostapacienteclienterazaosocial1_Jsonclick ;
      private string cellFilter_workflowconveniodesc1_cell_Internalname ;
      private string edtavWorkflowconveniodesc1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_114_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavConsulta_Jsonclick ;
      private string edtReembolsoId_Jsonclick ;
      private string edtReembolsoPropostaId_Jsonclick ;
      private string edtReembolsoPropostaPacienteClienteRazaoSocial_Jsonclick ;
      private string edtReembolsoPropostaPacienteClienteId_Jsonclick ;
      private string edtReembolsoProtocolo_Jsonclick ;
      private string edtReembolsoCreatedAt_Jsonclick ;
      private string edtReembolsoPropostaValor_Jsonclick ;
      private string edtReembolsoDataAberturaConvenio_Jsonclick ;
      private string edtReembolsoCreatedBy_Jsonclick ;
      private string edtReembolsoEtapaUltimo_F_Jsonclick ;
      private string GXCCtl ;
      private string cmbReembolsoStatusAtual_F_Jsonclick ;
      private string edtWorkflowConvenioDesc_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV39TFReembolsoCreatedAt ;
      private DateTime AV40TFReembolsoCreatedAt_To ;
      private DateTime A522ReembolsoCreatedAt ;
      private DateTime A547ReembolsoEtapaUltimo_F ;
      private DateTime AV90Reembolsowwds_20_tfreembolsocreatedat ;
      private DateTime AV91Reembolsowwds_21_tfreembolsocreatedat_to ;
      private DateTime AV46TFReembolsoDataAberturaConvenio ;
      private DateTime AV47TFReembolsoDataAberturaConvenio_To ;
      private DateTime AV41DDO_ReembolsoCreatedAtAuxDate ;
      private DateTime AV42DDO_ReembolsoCreatedAtAuxDateTo ;
      private DateTime AV48DDO_ReembolsoDataAberturaConvenioAuxDate ;
      private DateTime AV49DDO_ReembolsoDataAberturaConvenioAuxDateTo ;
      private DateTime A525ReembolsoDataAberturaConvenio ;
      private DateTime AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio ;
      private DateTime AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV28DynamicFiltersIgnoreFirst ;
      private bool AV27DynamicFiltersRemoving ;
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
      private bool n518ReembolsoId ;
      private bool n542ReembolsoPropostaId ;
      private bool n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool n558ReembolsoPropostaPacienteClienteId ;
      private bool n546ReembolsoProtocolo ;
      private bool n522ReembolsoCreatedAt ;
      private bool n543ReembolsoPropostaValor ;
      private bool n525ReembolsoDataAberturaConvenio ;
      private bool n544ReembolsoCreatedBy ;
      private bool n547ReembolsoEtapaUltimo_F ;
      private bool n548ReembolsoStatusAtual_F ;
      private bool n736WorkflowConvenioDesc ;
      private bool AV76Reembolsowwds_6_dynamicfiltersenabled2 ;
      private bool AV81Reembolsowwds_11_dynamicfiltersenabled3 ;
      private bool n742WorkflowConvenioId ;
      private bool bGXsfl_114_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV56TFReembolsoStatusAtual_F_SelsJson ;
      private string AV33ManageFiltersXml ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18ReembolsoPropostaPacienteClienteRazaoSocial1 ;
      private string AV67WorkflowConvenioDesc1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22ReembolsoPropostaPacienteClienteRazaoSocial2 ;
      private string AV68WorkflowConvenioDesc2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26ReembolsoPropostaPacienteClienteRazaoSocial3 ;
      private string AV69WorkflowConvenioDesc3 ;
      private string AV15FilterFullText ;
      private string AV35TFReembolsoPropostaPacienteClienteRazaoSocial ;
      private string AV36TFReembolsoPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV37TFReembolsoProtocolo ;
      private string AV38TFReembolsoProtocolo_Sel ;
      private string AV65TFWorkflowConvenioDesc ;
      private string AV66TFWorkflowConvenioDesc_Sel ;
      private string AV62GridAppliedFilters ;
      private string AV43DDO_ReembolsoCreatedAtAuxDateText ;
      private string AV50DDO_ReembolsoDataAberturaConvenioAuxDateText ;
      private string A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string A546ReembolsoProtocolo ;
      private string A548ReembolsoStatusAtual_F ;
      private string A736WorkflowConvenioDesc ;
      private string AV71Reembolsowwds_1_filterfulltext ;
      private string AV72Reembolsowwds_2_dynamicfiltersselector1 ;
      private string AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ;
      private string AV75Reembolsowwds_5_workflowconveniodesc1 ;
      private string AV77Reembolsowwds_7_dynamicfiltersselector2 ;
      private string AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ;
      private string AV80Reembolsowwds_10_workflowconveniodesc2 ;
      private string AV82Reembolsowwds_12_dynamicfiltersselector3 ;
      private string AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ;
      private string AV85Reembolsowwds_15_workflowconveniodesc3 ;
      private string AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ;
      private string AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ;
      private string AV88Reembolsowwds_18_tfreembolsoprotocolo ;
      private string AV89Reembolsowwds_19_tfreembolsoprotocolo_sel ;
      private string AV97Reembolsowwds_27_tfworkflowconveniodesc ;
      private string AV98Reembolsowwds_28_tfworkflowconveniodesc_sel ;
      private string lV71Reembolsowwds_1_filterfulltext ;
      private string lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ;
      private string lV75Reembolsowwds_5_workflowconveniodesc1 ;
      private string lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ;
      private string lV80Reembolsowwds_10_workflowconveniodesc2 ;
      private string lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ;
      private string lV85Reembolsowwds_15_workflowconveniodesc3 ;
      private string lV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ;
      private string lV88Reembolsowwds_18_tfreembolsoprotocolo ;
      private string lV97Reembolsowwds_27_tfworkflowconveniodesc ;
      private string AV29ExcelFilename ;
      private string AV30ErrorMessage ;
      private string AV63AuxText ;
      private IGxSession AV31Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfreembolsocreatedat_rangepicker ;
      private GXUserControl ucTfreembolsodataaberturaconvenio_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbReembolsoStatusAtual_F ;
      private GxSimpleCollection<string> AV57TFReembolsoStatusAtual_F_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV32ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV58DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels ;
      private IDataStoreProvider pr_default ;
      private int[] H007N3_A742WorkflowConvenioId ;
      private bool[] H007N3_n742WorkflowConvenioId ;
      private string[] H007N3_A736WorkflowConvenioDesc ;
      private bool[] H007N3_n736WorkflowConvenioDesc ;
      private short[] H007N3_A544ReembolsoCreatedBy ;
      private bool[] H007N3_n544ReembolsoCreatedBy ;
      private DateTime[] H007N3_A525ReembolsoDataAberturaConvenio ;
      private bool[] H007N3_n525ReembolsoDataAberturaConvenio ;
      private decimal[] H007N3_A543ReembolsoPropostaValor ;
      private bool[] H007N3_n543ReembolsoPropostaValor ;
      private DateTime[] H007N3_A522ReembolsoCreatedAt ;
      private bool[] H007N3_n522ReembolsoCreatedAt ;
      private string[] H007N3_A546ReembolsoProtocolo ;
      private bool[] H007N3_n546ReembolsoProtocolo ;
      private int[] H007N3_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] H007N3_n558ReembolsoPropostaPacienteClienteId ;
      private string[] H007N3_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] H007N3_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private int[] H007N3_A542ReembolsoPropostaId ;
      private bool[] H007N3_n542ReembolsoPropostaId ;
      private int[] H007N3_A518ReembolsoId ;
      private bool[] H007N3_n518ReembolsoId ;
      private DateTime[] H007N3_A547ReembolsoEtapaUltimo_F ;
      private bool[] H007N3_n547ReembolsoEtapaUltimo_F ;
      private int[] H007N5_A742WorkflowConvenioId ;
      private bool[] H007N5_n742WorkflowConvenioId ;
      private string[] H007N5_A736WorkflowConvenioDesc ;
      private bool[] H007N5_n736WorkflowConvenioDesc ;
      private short[] H007N5_A544ReembolsoCreatedBy ;
      private bool[] H007N5_n544ReembolsoCreatedBy ;
      private DateTime[] H007N5_A525ReembolsoDataAberturaConvenio ;
      private bool[] H007N5_n525ReembolsoDataAberturaConvenio ;
      private decimal[] H007N5_A543ReembolsoPropostaValor ;
      private bool[] H007N5_n543ReembolsoPropostaValor ;
      private DateTime[] H007N5_A522ReembolsoCreatedAt ;
      private bool[] H007N5_n522ReembolsoCreatedAt ;
      private string[] H007N5_A546ReembolsoProtocolo ;
      private bool[] H007N5_n546ReembolsoProtocolo ;
      private int[] H007N5_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] H007N5_n558ReembolsoPropostaPacienteClienteId ;
      private string[] H007N5_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] H007N5_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private int[] H007N5_A542ReembolsoPropostaId ;
      private bool[] H007N5_n542ReembolsoPropostaId ;
      private int[] H007N5_A518ReembolsoId ;
      private bool[] H007N5_n518ReembolsoId ;
      private DateTime[] H007N5_A547ReembolsoEtapaUltimo_F ;
      private bool[] H007N5_n547ReembolsoEtapaUltimo_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reembolsoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007N3( IGxContext context ,
                                             string A548ReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels ,
                                             string AV72Reembolsowwds_2_dynamicfiltersselector1 ,
                                             short AV73Reembolsowwds_3_dynamicfiltersoperator1 ,
                                             string AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ,
                                             string AV75Reembolsowwds_5_workflowconveniodesc1 ,
                                             bool AV76Reembolsowwds_6_dynamicfiltersenabled2 ,
                                             string AV77Reembolsowwds_7_dynamicfiltersselector2 ,
                                             short AV78Reembolsowwds_8_dynamicfiltersoperator2 ,
                                             string AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ,
                                             string AV80Reembolsowwds_10_workflowconveniodesc2 ,
                                             bool AV81Reembolsowwds_11_dynamicfiltersenabled3 ,
                                             string AV82Reembolsowwds_12_dynamicfiltersselector3 ,
                                             short AV83Reembolsowwds_13_dynamicfiltersoperator3 ,
                                             string AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ,
                                             string AV85Reembolsowwds_15_workflowconveniodesc3 ,
                                             string AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                             string AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ,
                                             string AV89Reembolsowwds_19_tfreembolsoprotocolo_sel ,
                                             string AV88Reembolsowwds_18_tfreembolsoprotocolo ,
                                             DateTime AV90Reembolsowwds_20_tfreembolsocreatedat ,
                                             DateTime AV91Reembolsowwds_21_tfreembolsocreatedat_to ,
                                             decimal AV92Reembolsowwds_22_tfreembolsopropostavalor ,
                                             decimal AV93Reembolsowwds_23_tfreembolsopropostavalor_to ,
                                             DateTime AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio ,
                                             DateTime AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ,
                                             string AV98Reembolsowwds_28_tfworkflowconveniodesc_sel ,
                                             string AV97Reembolsowwds_27_tfworkflowconveniodesc ,
                                             string A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                             string A736WorkflowConvenioDesc ,
                                             string A546ReembolsoProtocolo ,
                                             DateTime A522ReembolsoCreatedAt ,
                                             decimal A543ReembolsoPropostaValor ,
                                             DateTime A525ReembolsoDataAberturaConvenio ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV71Reembolsowwds_1_filterfulltext ,
                                             int AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[25];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.WorkflowConvenioId, T2.WorkflowConvenioDesc, T1.ReembolsoCreatedBy, T1.ReembolsoDataAberturaConvenio, T3.PropostaValor AS ReembolsoPropostaValor, T1.ReembolsoCreatedAt, T1.ReembolsoProtocolo, T3.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T4.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T1.ReembolsoPropostaId AS ReembolsoPropostaId, T1.ReembolsoId, COALESCE( T5.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F FROM ((((Reembolso T1 LEFT JOIN WorkflowConvenio T2 ON T2.WorkflowConvenioId = T1.WorkflowConvenioId) LEFT JOIN Proposta T3 ON T3.PropostaId = T1.ReembolsoPropostaId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T1.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T5 ON T5.ReembolsoId = T1.ReembolsoId)";
         if ( ( StringUtil.StrCmp(AV72Reembolsowwds_2_dynamicfiltersselector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV73Reembolsowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reembolsowwds_2_dynamicfiltersselector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV73Reembolsowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reembolsowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV73Reembolsowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reembolsowwds_5_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV75Reembolsowwds_5_workflowconveniodesc1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reembolsowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV73Reembolsowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reembolsowwds_5_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV75Reembolsowwds_5_workflowconveniodesc1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( AV76Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Reembolsowwds_7_dynamicfiltersselector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV78Reembolsowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV76Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Reembolsowwds_7_dynamicfiltersselector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV78Reembolsowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV76Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Reembolsowwds_7_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV78Reembolsowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Reembolsowwds_10_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV80Reembolsowwds_10_workflowconveniodesc2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV76Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Reembolsowwds_7_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV78Reembolsowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Reembolsowwds_10_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV80Reembolsowwds_10_workflowconveniodesc2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV81Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Reembolsowwds_12_dynamicfiltersselector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV83Reembolsowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV81Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Reembolsowwds_12_dynamicfiltersselector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV83Reembolsowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV81Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Reembolsowwds_12_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV83Reembolsowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Reembolsowwds_15_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV85Reembolsowwds_15_workflowconveniodesc3)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV81Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Reembolsowwds_12_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV83Reembolsowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Reembolsowwds_15_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV85Reembolsowwds_15_workflowconveniodesc3)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosoc))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Reembolsowwds_19_tfreembolsoprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Reembolsowwds_18_tfreembolsoprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo like :lV88Reembolsowwds_18_tfreembolsoprotocolo)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Reembolsowwds_19_tfreembolsoprotocolo_sel)) && ! ( StringUtil.StrCmp(AV89Reembolsowwds_19_tfreembolsoprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo = ( :AV89Reembolsowwds_19_tfreembolsoprotocolo_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV89Reembolsowwds_19_tfreembolsoprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo IS NULL or (char_length(trim(trailing ' ' from T1.ReembolsoProtocolo))=0))");
         }
         if ( ! (DateTime.MinValue==AV90Reembolsowwds_20_tfreembolsocreatedat) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoCreatedAt >= :AV90Reembolsowwds_20_tfreembolsocreatedat)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Reembolsowwds_21_tfreembolsocreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoCreatedAt <= :AV91Reembolsowwds_21_tfreembolsocreatedat_to)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV92Reembolsowwds_22_tfreembolsopropostavalor) )
         {
            AddWhere(sWhereString, "(T3.PropostaValor >= :AV92Reembolsowwds_22_tfreembolsopropostavalor)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV93Reembolsowwds_23_tfreembolsopropostavalor_to) )
         {
            AddWhere(sWhereString, "(T3.PropostaValor <= :AV93Reembolsowwds_23_tfreembolsopropostavalor_to)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoDataAberturaConvenio >= :AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoDataAberturaConvenio <= :AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Reembolsowwds_28_tfworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Reembolsowwds_27_tfworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV97Reembolsowwds_27_tfworkflowconveniodesc)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Reembolsowwds_28_tfworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV98Reembolsowwds_28_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc = ( :AV98Reembolsowwds_28_tfworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( StringUtil.StrCmp(AV98Reembolsowwds_28_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T2.WorkflowConvenioDesc))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.ClienteRazaoSocial, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.ClienteRazaoSocial DESC, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ReembolsoProtocolo, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ReembolsoProtocolo DESC, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ReembolsoCreatedAt, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ReembolsoCreatedAt DESC, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.PropostaValor, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.PropostaValor DESC, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ReembolsoDataAberturaConvenio, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ReembolsoDataAberturaConvenio DESC, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.WorkflowConvenioDesc, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.WorkflowConvenioDesc DESC, T1.ReembolsoId";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H007N5( IGxContext context ,
                                             string A548ReembolsoStatusAtual_F ,
                                             GxSimpleCollection<string> AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels ,
                                             string AV72Reembolsowwds_2_dynamicfiltersselector1 ,
                                             short AV73Reembolsowwds_3_dynamicfiltersoperator1 ,
                                             string AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1 ,
                                             string AV75Reembolsowwds_5_workflowconveniodesc1 ,
                                             bool AV76Reembolsowwds_6_dynamicfiltersenabled2 ,
                                             string AV77Reembolsowwds_7_dynamicfiltersselector2 ,
                                             short AV78Reembolsowwds_8_dynamicfiltersoperator2 ,
                                             string AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2 ,
                                             string AV80Reembolsowwds_10_workflowconveniodesc2 ,
                                             bool AV81Reembolsowwds_11_dynamicfiltersenabled3 ,
                                             string AV82Reembolsowwds_12_dynamicfiltersselector3 ,
                                             short AV83Reembolsowwds_13_dynamicfiltersoperator3 ,
                                             string AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3 ,
                                             string AV85Reembolsowwds_15_workflowconveniodesc3 ,
                                             string AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel ,
                                             string AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial ,
                                             string AV89Reembolsowwds_19_tfreembolsoprotocolo_sel ,
                                             string AV88Reembolsowwds_18_tfreembolsoprotocolo ,
                                             DateTime AV90Reembolsowwds_20_tfreembolsocreatedat ,
                                             DateTime AV91Reembolsowwds_21_tfreembolsocreatedat_to ,
                                             decimal AV92Reembolsowwds_22_tfreembolsopropostavalor ,
                                             decimal AV93Reembolsowwds_23_tfreembolsopropostavalor_to ,
                                             DateTime AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio ,
                                             DateTime AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to ,
                                             string AV98Reembolsowwds_28_tfworkflowconveniodesc_sel ,
                                             string AV97Reembolsowwds_27_tfworkflowconveniodesc ,
                                             string A550ReembolsoPropostaPacienteClienteRazaoSocial ,
                                             string A736WorkflowConvenioDesc ,
                                             string A546ReembolsoProtocolo ,
                                             DateTime A522ReembolsoCreatedAt ,
                                             decimal A543ReembolsoPropostaValor ,
                                             DateTime A525ReembolsoDataAberturaConvenio ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV71Reembolsowwds_1_filterfulltext ,
                                             int AV96Reembolsowwds_26_tfreembolsostatusatual_f_sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[25];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.WorkflowConvenioId, T2.WorkflowConvenioDesc, T1.ReembolsoCreatedBy, T1.ReembolsoDataAberturaConvenio, T3.PropostaValor AS ReembolsoPropostaValor, T1.ReembolsoCreatedAt, T1.ReembolsoProtocolo, T3.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T4.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T1.ReembolsoPropostaId AS ReembolsoPropostaId, T1.ReembolsoId, COALESCE( T5.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F FROM ((((Reembolso T1 LEFT JOIN WorkflowConvenio T2 ON T2.WorkflowConvenioId = T1.WorkflowConvenioId) LEFT JOIN Proposta T3 ON T3.PropostaId = T1.ReembolsoPropostaId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T1.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T5 ON T5.ReembolsoId = T1.ReembolsoId)";
         if ( ( StringUtil.StrCmp(AV72Reembolsowwds_2_dynamicfiltersselector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV73Reembolsowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reembolsowwds_2_dynamicfiltersselector1, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV73Reembolsowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reembolsowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV73Reembolsowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reembolsowwds_5_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV75Reembolsowwds_5_workflowconveniodesc1)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Reembolsowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV73Reembolsowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reembolsowwds_5_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV75Reembolsowwds_5_workflowconveniodesc1)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( AV76Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Reembolsowwds_7_dynamicfiltersselector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV78Reembolsowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( AV76Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Reembolsowwds_7_dynamicfiltersselector2, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV78Reembolsowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( AV76Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Reembolsowwds_7_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV78Reembolsowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Reembolsowwds_10_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV80Reembolsowwds_10_workflowconveniodesc2)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( AV76Reembolsowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Reembolsowwds_7_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV78Reembolsowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Reembolsowwds_10_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV80Reembolsowwds_10_workflowconveniodesc2)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( AV81Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Reembolsowwds_12_dynamicfiltersselector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV83Reembolsowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( AV81Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Reembolsowwds_12_dynamicfiltersselector3, "REEMBOLSOPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 ) && ( AV83Reembolsowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocial3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like '%' || :lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( AV81Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Reembolsowwds_12_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV83Reembolsowwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Reembolsowwds_15_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV85Reembolsowwds_15_workflowconveniodesc3)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( AV81Reembolsowwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Reembolsowwds_12_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV83Reembolsowwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Reembolsowwds_15_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like '%' || :lV85Reembolsowwds_15_workflowconveniodesc3)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial like :lV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosoc)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial = ( :AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosoc))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T4.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Reembolsowwds_19_tfreembolsoprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Reembolsowwds_18_tfreembolsoprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo like :lV88Reembolsowwds_18_tfreembolsoprotocolo)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Reembolsowwds_19_tfreembolsoprotocolo_sel)) && ! ( StringUtil.StrCmp(AV89Reembolsowwds_19_tfreembolsoprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo = ( :AV89Reembolsowwds_19_tfreembolsoprotocolo_sel))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( StringUtil.StrCmp(AV89Reembolsowwds_19_tfreembolsoprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ReembolsoProtocolo IS NULL or (char_length(trim(trailing ' ' from T1.ReembolsoProtocolo))=0))");
         }
         if ( ! (DateTime.MinValue==AV90Reembolsowwds_20_tfreembolsocreatedat) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoCreatedAt >= :AV90Reembolsowwds_20_tfreembolsocreatedat)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Reembolsowwds_21_tfreembolsocreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoCreatedAt <= :AV91Reembolsowwds_21_tfreembolsocreatedat_to)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV92Reembolsowwds_22_tfreembolsopropostavalor) )
         {
            AddWhere(sWhereString, "(T3.PropostaValor >= :AV92Reembolsowwds_22_tfreembolsopropostavalor)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV93Reembolsowwds_23_tfreembolsopropostavalor_to) )
         {
            AddWhere(sWhereString, "(T3.PropostaValor <= :AV93Reembolsowwds_23_tfreembolsopropostavalor_to)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoDataAberturaConvenio >= :AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoDataAberturaConvenio <= :AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Reembolsowwds_28_tfworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Reembolsowwds_27_tfworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV97Reembolsowwds_27_tfworkflowconveniodesc)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Reembolsowwds_28_tfworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV98Reembolsowwds_28_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc = ( :AV98Reembolsowwds_28_tfworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( StringUtil.StrCmp(AV98Reembolsowwds_28_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T2.WorkflowConvenioDesc))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.ClienteRazaoSocial, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.ClienteRazaoSocial DESC, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ReembolsoProtocolo, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ReembolsoProtocolo DESC, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ReembolsoCreatedAt, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ReembolsoCreatedAt DESC, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.PropostaValor, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.PropostaValor DESC, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ReembolsoDataAberturaConvenio, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ReembolsoDataAberturaConvenio DESC, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.WorkflowConvenioDesc, T1.ReembolsoId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.WorkflowConvenioDesc DESC, T1.ReembolsoId";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H007N3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (decimal)dynConstraints[32] , (DateTime)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] );
               case 1 :
                     return conditional_H007N5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (decimal)dynConstraints[32] , (DateTime)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] );
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
          Object[] prmH007N3;
          prmH007N3 = new Object[] {
          new ParDef("AV96ReemCount",GXType.Int32,9,0) ,
          new ParDef("lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV75Reembolsowwds_5_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV75Reembolsowwds_5_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV80Reembolsowwds_10_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV80Reembolsowwds_10_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia",GXType.VarChar,150,0) ,
          new ParDef("lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia",GXType.VarChar,150,0) ,
          new ParDef("lV85Reembolsowwds_15_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV85Reembolsowwds_15_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV88Reembolsowwds_18_tfreembolsoprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV89Reembolsowwds_19_tfreembolsoprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("AV90Reembolsowwds_20_tfreembolsocreatedat",GXType.DateTime,10,8) ,
          new ParDef("AV91Reembolsowwds_21_tfreembolsocreatedat_to",GXType.DateTime,10,8) ,
          new ParDef("AV92Reembolsowwds_22_tfreembolsopropostavalor",GXType.Number,18,2) ,
          new ParDef("AV93Reembolsowwds_23_tfreembolsopropostavalor_to",GXType.Number,18,2) ,
          new ParDef("AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio",GXType.Date,8,0) ,
          new ParDef("AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to",GXType.Date,8,0) ,
          new ParDef("lV97Reembolsowwds_27_tfworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV98Reembolsowwds_28_tfworkflowconveniodesc_sel",GXType.VarChar,60,0)
          };
          Object[] prmH007N5;
          prmH007N5 = new Object[] {
          new ParDef("AV96ReemCount",GXType.Int32,9,0) ,
          new ParDef("lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV74Reembolsowwds_4_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV75Reembolsowwds_5_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV75Reembolsowwds_5_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV79Reembolsowwds_9_reembolsopropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("lV80Reembolsowwds_10_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV80Reembolsowwds_10_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia",GXType.VarChar,150,0) ,
          new ParDef("lV84Reembolsowwds_14_reembolsopropostapacienteclienterazaosocia",GXType.VarChar,150,0) ,
          new ParDef("lV85Reembolsowwds_15_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV85Reembolsowwds_15_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV86Reembolsowwds_16_tfreembolsopropostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("AV87Reembolsowwds_17_tfreembolsopropostapacienteclienterazaosoc",GXType.VarChar,150,0) ,
          new ParDef("lV88Reembolsowwds_18_tfreembolsoprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV89Reembolsowwds_19_tfreembolsoprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("AV90Reembolsowwds_20_tfreembolsocreatedat",GXType.DateTime,10,8) ,
          new ParDef("AV91Reembolsowwds_21_tfreembolsocreatedat_to",GXType.DateTime,10,8) ,
          new ParDef("AV92Reembolsowwds_22_tfreembolsopropostavalor",GXType.Number,18,2) ,
          new ParDef("AV93Reembolsowwds_23_tfreembolsopropostavalor_to",GXType.Number,18,2) ,
          new ParDef("AV94Reembolsowwds_24_tfreembolsodataaberturaconvenio",GXType.Date,8,0) ,
          new ParDef("AV95Reembolsowwds_25_tfreembolsodataaberturaconvenio_to",GXType.Date,8,0) ,
          new ParDef("lV97Reembolsowwds_27_tfworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV98Reembolsowwds_28_tfworkflowconveniodesc_sel",GXType.VarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007N3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007N5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007N5,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
       }
    }

 }

}
