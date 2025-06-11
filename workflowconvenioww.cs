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
   public class workflowconvenioww : GXDataArea
   {
      public workflowconvenioww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workflowconvenioww( IGxContext context )
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
         cmbWorkflowConvenioStatus = new GXCombobox();
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
         nRC_GXsfl_109 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_109"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_109_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_109_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_109_idx = GetPar( "sGXsfl_109_idx");
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
         AV15FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV18WorkflowConvenioDesc1 = GetPar( "WorkflowConvenioDesc1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV22WorkflowConvenioDesc2 = GetPar( "WorkflowConvenioDesc2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV26WorkflowConvenioDesc3 = GetPar( "WorkflowConvenioDesc3");
         AV34ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV51Pgmname = GetPar( "Pgmname");
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV35TFWorkflowConvenioDesc = GetPar( "TFWorkflowConvenioDesc");
         AV36TFWorkflowConvenioDesc_Sel = GetPar( "TFWorkflowConvenioDesc_Sel");
         AV37TFWorkflowConvenioStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWorkflowConvenioStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         AV38TFWorkflowConvenioCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFWorkflowConvenioCreatedAt"));
         AV39TFWorkflowConvenioCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFWorkflowConvenioCreatedAt_To"));
         AV49TFWorkflowConvenioSLA = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWorkflowConvenioSLA"), "."), 18, MidpointRounding.ToEven));
         AV50TFWorkflowConvenioSLA_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWorkflowConvenioSLA_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV28DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV27DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFWorkflowConvenioDesc, AV36TFWorkflowConvenioDesc_Sel, AV37TFWorkflowConvenioStatus_Sel, AV38TFWorkflowConvenioCreatedAt, AV39TFWorkflowConvenioCreatedAt_To, AV49TFWorkflowConvenioSLA, AV50TFWorkflowConvenioSLA_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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
         PA7Z2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7Z2( ) ;
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workflowconvenioww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vWORKFLOWCONVENIODESC1", AV18WorkflowConvenioDesc1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vWORKFLOWCONVENIODESC2", AV22WorkflowConvenioDesc2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vWORKFLOWCONVENIODESC3", AV26WorkflowConvenioDesc3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_109", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_109), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV47GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV43DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV43DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_WORKFLOWCONVENIOCREATEDATAUXDATE", context.localUtil.DToC( AV40DDO_WorkflowConvenioCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_WORKFLOWCONVENIOCREATEDATAUXDATETO", context.localUtil.DToC( AV41DDO_WorkflowConvenioCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFWORKFLOWCONVENIODESC", AV35TFWorkflowConvenioDesc);
         GxWebStd.gx_hidden_field( context, "vTFWORKFLOWCONVENIODESC_SEL", AV36TFWorkflowConvenioDesc_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWORKFLOWCONVENIOSTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37TFWorkflowConvenioStatus_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFWORKFLOWCONVENIOCREATEDAT", context.localUtil.TToC( AV38TFWorkflowConvenioCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFWORKFLOWCONVENIOCREATEDAT_TO", context.localUtil.TToC( AV39TFWorkflowConvenioCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFWORKFLOWCONVENIOSLA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49TFWorkflowConvenioSLA), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFWORKFLOWCONVENIOSLA_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50TFWorkflowConvenioSLA_To), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE7Z2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7Z2( ) ;
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
         return formatLink("workflowconvenioww")  ;
      }

      public override string GetPgmname( )
      {
         return "WorkflowConvenioWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Workflow Convenio" ;
      }

      protected void WB7Z0( )
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
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkflowConvenioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkflowConvenioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkflowConvenioWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WorkflowConvenioWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WorkflowConvenioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_WorkflowConvenioWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WorkflowConvenioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_47_7Z2( true) ;
         }
         else
         {
            wb_table1_47_7Z2( false) ;
         }
         return  ;
      }

      protected void wb_table1_47_7Z2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WorkflowConvenioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 0, "HLP_WorkflowConvenioWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WorkflowConvenioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_69_7Z2( true) ;
         }
         else
         {
            wb_table2_69_7Z2( false) ;
         }
         return  ;
      }

      protected void wb_table2_69_7Z2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WorkflowConvenioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_WorkflowConvenioWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WorkflowConvenioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_91_7Z2( true) ;
         }
         else
         {
            wb_table3_91_7Z2( false) ;
         }
         return  ;
      }

      protected void wb_table3_91_7Z2e( bool wbgen )
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
            StartGridControl109( ) ;
         }
         if ( wbEnd == 109 )
         {
            wbEnd = 0;
            nRC_GXsfl_109 = (int)(nGXsfl_109_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV45GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV46GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV47GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WorkflowConvenioWW.htm");
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
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV43DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_workflowconveniocreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_workflowconveniocreatedatauxdatetext_Internalname, AV42DDO_WorkflowConvenioCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV42DDO_WorkflowConvenioCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_workflowconveniocreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkflowConvenioWW.htm");
            /* User Defined Control */
            ucTfworkflowconveniocreatedat_rangepicker.SetProperty("Start Date", AV40DDO_WorkflowConvenioCreatedAtAuxDate);
            ucTfworkflowconveniocreatedat_rangepicker.SetProperty("End Date", AV41DDO_WorkflowConvenioCreatedAtAuxDateTo);
            ucTfworkflowconveniocreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfworkflowconveniocreatedat_rangepicker_Internalname, "TFWORKFLOWCONVENIOCREATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 109 )
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

      protected void START7Z2( )
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
         Form.Meta.addItem("description", " Workflow Convenio", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7Z0( ) ;
      }

      protected void WS7Z2( )
      {
         START7Z2( ) ;
         EVT7Z2( ) ;
      }

      protected void EVT7Z2( )
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
                              E117Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E127Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E137Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E147Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E157Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E167Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E177Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E187Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E197Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E207Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E217Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E227Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E237Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E247Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E257Z2 ();
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
                              nGXsfl_109_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
                              SubsflControlProps_1092( ) ;
                              AV48Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV48Update);
                              A742WorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkflowConvenioId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A736WorkflowConvenioDesc = cgiGet( edtWorkflowConvenioDesc_Internalname);
                              n736WorkflowConvenioDesc = false;
                              cmbWorkflowConvenioStatus.Name = cmbWorkflowConvenioStatus_Internalname;
                              cmbWorkflowConvenioStatus.CurrentValue = cgiGet( cmbWorkflowConvenioStatus_Internalname);
                              A737WorkflowConvenioStatus = StringUtil.StrToBool( cgiGet( cmbWorkflowConvenioStatus_Internalname));
                              n737WorkflowConvenioStatus = false;
                              A743WorkflowConvenioCreatedAt = context.localUtil.CToT( cgiGet( edtWorkflowConvenioCreatedAt_Internalname), 0);
                              n743WorkflowConvenioCreatedAt = false;
                              A753WorkflowConvenioSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkflowConvenioSLA_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n753WorkflowConvenioSLA = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E267Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E277Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E287Z2 ();
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
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
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
                                       /* Set Refresh If Workflowconveniodesc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vWORKFLOWCONVENIODESC1"), AV18WorkflowConvenioDesc1) != 0 )
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
                                       /* Set Refresh If Workflowconveniodesc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vWORKFLOWCONVENIODESC2"), AV22WorkflowConvenioDesc2) != 0 )
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
                                       /* Set Refresh If Workflowconveniodesc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vWORKFLOWCONVENIODESC3"), AV26WorkflowConvenioDesc3) != 0 )
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

      protected void WE7Z2( )
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

      protected void PA7Z2( )
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
         SubsflControlProps_1092( ) ;
         while ( nGXsfl_109_idx <= nRC_GXsfl_109 )
         {
            sendrow_1092( ) ;
            nGXsfl_109_idx = ((subGrid_Islastpage==1)&&(nGXsfl_109_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_109_idx+1);
            sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
            SubsflControlProps_1092( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV15FilterFullText ,
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       string AV18WorkflowConvenioDesc1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV22WorkflowConvenioDesc2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       string AV26WorkflowConvenioDesc3 ,
                                       short AV34ManageFiltersExecutionStep ,
                                       string AV51Pgmname ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       string AV35TFWorkflowConvenioDesc ,
                                       string AV36TFWorkflowConvenioDesc_Sel ,
                                       short AV37TFWorkflowConvenioStatus_Sel ,
                                       DateTime AV38TFWorkflowConvenioCreatedAt ,
                                       DateTime AV39TFWorkflowConvenioCreatedAt_To ,
                                       short AV49TFWorkflowConvenioSLA ,
                                       short AV50TFWorkflowConvenioSLA_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF7Z2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WORKFLOWCONVENIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A742WorkflowConvenioId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WORKFLOWCONVENIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ".", "")));
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
         RF7Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV51Pgmname = "WorkflowConvenioWW";
         edtavUpdate_Enabled = 0;
      }

      protected void RF7Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 109;
         /* Execute user event: Refresh */
         E277Z2 ();
         nGXsfl_109_idx = 1;
         sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
         SubsflControlProps_1092( ) ;
         bGXsfl_109_Refreshing = true;
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
            SubsflControlProps_1092( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV52Workflowconveniowwds_1_filterfulltext ,
                                                 AV53Workflowconveniowwds_2_dynamicfiltersselector1 ,
                                                 AV54Workflowconveniowwds_3_dynamicfiltersoperator1 ,
                                                 AV55Workflowconveniowwds_4_workflowconveniodesc1 ,
                                                 AV56Workflowconveniowwds_5_dynamicfiltersenabled2 ,
                                                 AV57Workflowconveniowwds_6_dynamicfiltersselector2 ,
                                                 AV58Workflowconveniowwds_7_dynamicfiltersoperator2 ,
                                                 AV59Workflowconveniowwds_8_workflowconveniodesc2 ,
                                                 AV60Workflowconveniowwds_9_dynamicfiltersenabled3 ,
                                                 AV61Workflowconveniowwds_10_dynamicfiltersselector3 ,
                                                 AV62Workflowconveniowwds_11_dynamicfiltersoperator3 ,
                                                 AV63Workflowconveniowwds_12_workflowconveniodesc3 ,
                                                 AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel ,
                                                 AV64Workflowconveniowwds_13_tfworkflowconveniodesc ,
                                                 AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel ,
                                                 AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat ,
                                                 AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ,
                                                 AV69Workflowconveniowwds_18_tfworkflowconveniosla ,
                                                 AV70Workflowconveniowwds_19_tfworkflowconveniosla_to ,
                                                 A736WorkflowConvenioDesc ,
                                                 A737WorkflowConvenioStatus ,
                                                 A753WorkflowConvenioSLA ,
                                                 A743WorkflowConvenioCreatedAt ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV52Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Workflowconveniowwds_1_filterfulltext), "%", "");
            lV52Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Workflowconveniowwds_1_filterfulltext), "%", "");
            lV52Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Workflowconveniowwds_1_filterfulltext), "%", "");
            lV52Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Workflowconveniowwds_1_filterfulltext), "%", "");
            lV55Workflowconveniowwds_4_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV55Workflowconveniowwds_4_workflowconveniodesc1), "%", "");
            lV55Workflowconveniowwds_4_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV55Workflowconveniowwds_4_workflowconveniodesc1), "%", "");
            lV59Workflowconveniowwds_8_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV59Workflowconveniowwds_8_workflowconveniodesc2), "%", "");
            lV59Workflowconveniowwds_8_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV59Workflowconveniowwds_8_workflowconveniodesc2), "%", "");
            lV63Workflowconveniowwds_12_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV63Workflowconveniowwds_12_workflowconveniodesc3), "%", "");
            lV63Workflowconveniowwds_12_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV63Workflowconveniowwds_12_workflowconveniodesc3), "%", "");
            lV64Workflowconveniowwds_13_tfworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV64Workflowconveniowwds_13_tfworkflowconveniodesc), "%", "");
            /* Using cursor H007Z2 */
            pr_default.execute(0, new Object[] {lV52Workflowconveniowwds_1_filterfulltext, lV52Workflowconveniowwds_1_filterfulltext, lV52Workflowconveniowwds_1_filterfulltext, lV52Workflowconveniowwds_1_filterfulltext, lV55Workflowconveniowwds_4_workflowconveniodesc1, lV55Workflowconveniowwds_4_workflowconveniodesc1, lV59Workflowconveniowwds_8_workflowconveniodesc2, lV59Workflowconveniowwds_8_workflowconveniodesc2, lV63Workflowconveniowwds_12_workflowconveniodesc3, lV63Workflowconveniowwds_12_workflowconveniodesc3, lV64Workflowconveniowwds_13_tfworkflowconveniodesc, AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel, AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat, AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to, AV69Workflowconveniowwds_18_tfworkflowconveniosla, AV70Workflowconveniowwds_19_tfworkflowconveniosla_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_109_idx = 1;
            sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
            SubsflControlProps_1092( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A753WorkflowConvenioSLA = H007Z2_A753WorkflowConvenioSLA[0];
               n753WorkflowConvenioSLA = H007Z2_n753WorkflowConvenioSLA[0];
               A743WorkflowConvenioCreatedAt = H007Z2_A743WorkflowConvenioCreatedAt[0];
               n743WorkflowConvenioCreatedAt = H007Z2_n743WorkflowConvenioCreatedAt[0];
               A737WorkflowConvenioStatus = H007Z2_A737WorkflowConvenioStatus[0];
               n737WorkflowConvenioStatus = H007Z2_n737WorkflowConvenioStatus[0];
               A736WorkflowConvenioDesc = H007Z2_A736WorkflowConvenioDesc[0];
               n736WorkflowConvenioDesc = H007Z2_n736WorkflowConvenioDesc[0];
               A742WorkflowConvenioId = H007Z2_A742WorkflowConvenioId[0];
               /* Execute user event: Grid.Load */
               E287Z2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 109;
            WB7Z0( ) ;
         }
         bGXsfl_109_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7Z2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WORKFLOWCONVENIOID"+"_"+sGXsfl_109_idx, GetSecureSignedToken( sGXsfl_109_idx, context.localUtil.Format( (decimal)(A742WorkflowConvenioId), "ZZZZZZZZ9"), context));
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
         AV52Workflowconveniowwds_1_filterfulltext = AV15FilterFullText;
         AV53Workflowconveniowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Workflowconveniowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Workflowconveniowwds_4_workflowconveniodesc1 = AV18WorkflowConvenioDesc1;
         AV56Workflowconveniowwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Workflowconveniowwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Workflowconveniowwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Workflowconveniowwds_8_workflowconveniodesc2 = AV22WorkflowConvenioDesc2;
         AV60Workflowconveniowwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Workflowconveniowwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Workflowconveniowwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Workflowconveniowwds_12_workflowconveniodesc3 = AV26WorkflowConvenioDesc3;
         AV64Workflowconveniowwds_13_tfworkflowconveniodesc = AV35TFWorkflowConvenioDesc;
         AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel = AV36TFWorkflowConvenioDesc_Sel;
         AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel = AV37TFWorkflowConvenioStatus_Sel;
         AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat = AV38TFWorkflowConvenioCreatedAt;
         AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = AV39TFWorkflowConvenioCreatedAt_To;
         AV69Workflowconveniowwds_18_tfworkflowconveniosla = AV49TFWorkflowConvenioSLA;
         AV70Workflowconveniowwds_19_tfworkflowconveniosla_to = AV50TFWorkflowConvenioSLA_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV52Workflowconveniowwds_1_filterfulltext ,
                                              AV53Workflowconveniowwds_2_dynamicfiltersselector1 ,
                                              AV54Workflowconveniowwds_3_dynamicfiltersoperator1 ,
                                              AV55Workflowconveniowwds_4_workflowconveniodesc1 ,
                                              AV56Workflowconveniowwds_5_dynamicfiltersenabled2 ,
                                              AV57Workflowconveniowwds_6_dynamicfiltersselector2 ,
                                              AV58Workflowconveniowwds_7_dynamicfiltersoperator2 ,
                                              AV59Workflowconveniowwds_8_workflowconveniodesc2 ,
                                              AV60Workflowconveniowwds_9_dynamicfiltersenabled3 ,
                                              AV61Workflowconveniowwds_10_dynamicfiltersselector3 ,
                                              AV62Workflowconveniowwds_11_dynamicfiltersoperator3 ,
                                              AV63Workflowconveniowwds_12_workflowconveniodesc3 ,
                                              AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel ,
                                              AV64Workflowconveniowwds_13_tfworkflowconveniodesc ,
                                              AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel ,
                                              AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat ,
                                              AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ,
                                              AV69Workflowconveniowwds_18_tfworkflowconveniosla ,
                                              AV70Workflowconveniowwds_19_tfworkflowconveniosla_to ,
                                              A736WorkflowConvenioDesc ,
                                              A737WorkflowConvenioStatus ,
                                              A753WorkflowConvenioSLA ,
                                              A743WorkflowConvenioCreatedAt ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Workflowconveniowwds_1_filterfulltext), "%", "");
         lV52Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Workflowconveniowwds_1_filterfulltext), "%", "");
         lV52Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Workflowconveniowwds_1_filterfulltext), "%", "");
         lV52Workflowconveniowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Workflowconveniowwds_1_filterfulltext), "%", "");
         lV55Workflowconveniowwds_4_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV55Workflowconveniowwds_4_workflowconveniodesc1), "%", "");
         lV55Workflowconveniowwds_4_workflowconveniodesc1 = StringUtil.Concat( StringUtil.RTrim( AV55Workflowconveniowwds_4_workflowconveniodesc1), "%", "");
         lV59Workflowconveniowwds_8_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV59Workflowconveniowwds_8_workflowconveniodesc2), "%", "");
         lV59Workflowconveniowwds_8_workflowconveniodesc2 = StringUtil.Concat( StringUtil.RTrim( AV59Workflowconveniowwds_8_workflowconveniodesc2), "%", "");
         lV63Workflowconveniowwds_12_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV63Workflowconveniowwds_12_workflowconveniodesc3), "%", "");
         lV63Workflowconveniowwds_12_workflowconveniodesc3 = StringUtil.Concat( StringUtil.RTrim( AV63Workflowconveniowwds_12_workflowconveniodesc3), "%", "");
         lV64Workflowconveniowwds_13_tfworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV64Workflowconveniowwds_13_tfworkflowconveniodesc), "%", "");
         /* Using cursor H007Z3 */
         pr_default.execute(1, new Object[] {lV52Workflowconveniowwds_1_filterfulltext, lV52Workflowconveniowwds_1_filterfulltext, lV52Workflowconveniowwds_1_filterfulltext, lV52Workflowconveniowwds_1_filterfulltext, lV55Workflowconveniowwds_4_workflowconveniodesc1, lV55Workflowconveniowwds_4_workflowconveniodesc1, lV59Workflowconveniowwds_8_workflowconveniodesc2, lV59Workflowconveniowwds_8_workflowconveniodesc2, lV63Workflowconveniowwds_12_workflowconveniodesc3, lV63Workflowconveniowwds_12_workflowconveniodesc3, lV64Workflowconveniowwds_13_tfworkflowconveniodesc, AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel, AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat, AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to, AV69Workflowconveniowwds_18_tfworkflowconveniosla, AV70Workflowconveniowwds_19_tfworkflowconveniosla_to});
         GRID_nRecordCount = H007Z3_AGRID_nRecordCount[0];
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
         AV52Workflowconveniowwds_1_filterfulltext = AV15FilterFullText;
         AV53Workflowconveniowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Workflowconveniowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Workflowconveniowwds_4_workflowconveniodesc1 = AV18WorkflowConvenioDesc1;
         AV56Workflowconveniowwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Workflowconveniowwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Workflowconveniowwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Workflowconveniowwds_8_workflowconveniodesc2 = AV22WorkflowConvenioDesc2;
         AV60Workflowconveniowwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Workflowconveniowwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Workflowconveniowwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Workflowconveniowwds_12_workflowconveniodesc3 = AV26WorkflowConvenioDesc3;
         AV64Workflowconveniowwds_13_tfworkflowconveniodesc = AV35TFWorkflowConvenioDesc;
         AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel = AV36TFWorkflowConvenioDesc_Sel;
         AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel = AV37TFWorkflowConvenioStatus_Sel;
         AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat = AV38TFWorkflowConvenioCreatedAt;
         AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = AV39TFWorkflowConvenioCreatedAt_To;
         AV69Workflowconveniowwds_18_tfworkflowconveniosla = AV49TFWorkflowConvenioSLA;
         AV70Workflowconveniowwds_19_tfworkflowconveniosla_to = AV50TFWorkflowConvenioSLA_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFWorkflowConvenioDesc, AV36TFWorkflowConvenioDesc_Sel, AV37TFWorkflowConvenioStatus_Sel, AV38TFWorkflowConvenioCreatedAt, AV39TFWorkflowConvenioCreatedAt_To, AV49TFWorkflowConvenioSLA, AV50TFWorkflowConvenioSLA_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV52Workflowconveniowwds_1_filterfulltext = AV15FilterFullText;
         AV53Workflowconveniowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Workflowconveniowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Workflowconveniowwds_4_workflowconveniodesc1 = AV18WorkflowConvenioDesc1;
         AV56Workflowconveniowwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Workflowconveniowwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Workflowconveniowwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Workflowconveniowwds_8_workflowconveniodesc2 = AV22WorkflowConvenioDesc2;
         AV60Workflowconveniowwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Workflowconveniowwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Workflowconveniowwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Workflowconveniowwds_12_workflowconveniodesc3 = AV26WorkflowConvenioDesc3;
         AV64Workflowconveniowwds_13_tfworkflowconveniodesc = AV35TFWorkflowConvenioDesc;
         AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel = AV36TFWorkflowConvenioDesc_Sel;
         AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel = AV37TFWorkflowConvenioStatus_Sel;
         AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat = AV38TFWorkflowConvenioCreatedAt;
         AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = AV39TFWorkflowConvenioCreatedAt_To;
         AV69Workflowconveniowwds_18_tfworkflowconveniosla = AV49TFWorkflowConvenioSLA;
         AV70Workflowconveniowwds_19_tfworkflowconveniosla_to = AV50TFWorkflowConvenioSLA_To;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFWorkflowConvenioDesc, AV36TFWorkflowConvenioDesc_Sel, AV37TFWorkflowConvenioStatus_Sel, AV38TFWorkflowConvenioCreatedAt, AV39TFWorkflowConvenioCreatedAt_To, AV49TFWorkflowConvenioSLA, AV50TFWorkflowConvenioSLA_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV52Workflowconveniowwds_1_filterfulltext = AV15FilterFullText;
         AV53Workflowconveniowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Workflowconveniowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Workflowconveniowwds_4_workflowconveniodesc1 = AV18WorkflowConvenioDesc1;
         AV56Workflowconveniowwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Workflowconveniowwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Workflowconveniowwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Workflowconveniowwds_8_workflowconveniodesc2 = AV22WorkflowConvenioDesc2;
         AV60Workflowconveniowwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Workflowconveniowwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Workflowconveniowwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Workflowconveniowwds_12_workflowconveniodesc3 = AV26WorkflowConvenioDesc3;
         AV64Workflowconveniowwds_13_tfworkflowconveniodesc = AV35TFWorkflowConvenioDesc;
         AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel = AV36TFWorkflowConvenioDesc_Sel;
         AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel = AV37TFWorkflowConvenioStatus_Sel;
         AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat = AV38TFWorkflowConvenioCreatedAt;
         AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = AV39TFWorkflowConvenioCreatedAt_To;
         AV69Workflowconveniowwds_18_tfworkflowconveniosla = AV49TFWorkflowConvenioSLA;
         AV70Workflowconveniowwds_19_tfworkflowconveniosla_to = AV50TFWorkflowConvenioSLA_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFWorkflowConvenioDesc, AV36TFWorkflowConvenioDesc_Sel, AV37TFWorkflowConvenioStatus_Sel, AV38TFWorkflowConvenioCreatedAt, AV39TFWorkflowConvenioCreatedAt_To, AV49TFWorkflowConvenioSLA, AV50TFWorkflowConvenioSLA_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV52Workflowconveniowwds_1_filterfulltext = AV15FilterFullText;
         AV53Workflowconveniowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Workflowconveniowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Workflowconveniowwds_4_workflowconveniodesc1 = AV18WorkflowConvenioDesc1;
         AV56Workflowconveniowwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Workflowconveniowwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Workflowconveniowwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Workflowconveniowwds_8_workflowconveniodesc2 = AV22WorkflowConvenioDesc2;
         AV60Workflowconveniowwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Workflowconveniowwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Workflowconveniowwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Workflowconveniowwds_12_workflowconveniodesc3 = AV26WorkflowConvenioDesc3;
         AV64Workflowconveniowwds_13_tfworkflowconveniodesc = AV35TFWorkflowConvenioDesc;
         AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel = AV36TFWorkflowConvenioDesc_Sel;
         AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel = AV37TFWorkflowConvenioStatus_Sel;
         AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat = AV38TFWorkflowConvenioCreatedAt;
         AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = AV39TFWorkflowConvenioCreatedAt_To;
         AV69Workflowconveniowwds_18_tfworkflowconveniosla = AV49TFWorkflowConvenioSLA;
         AV70Workflowconveniowwds_19_tfworkflowconveniosla_to = AV50TFWorkflowConvenioSLA_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFWorkflowConvenioDesc, AV36TFWorkflowConvenioDesc_Sel, AV37TFWorkflowConvenioStatus_Sel, AV38TFWorkflowConvenioCreatedAt, AV39TFWorkflowConvenioCreatedAt_To, AV49TFWorkflowConvenioSLA, AV50TFWorkflowConvenioSLA_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV52Workflowconveniowwds_1_filterfulltext = AV15FilterFullText;
         AV53Workflowconveniowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Workflowconveniowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Workflowconveniowwds_4_workflowconveniodesc1 = AV18WorkflowConvenioDesc1;
         AV56Workflowconveniowwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Workflowconveniowwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Workflowconveniowwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Workflowconveniowwds_8_workflowconveniodesc2 = AV22WorkflowConvenioDesc2;
         AV60Workflowconveniowwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Workflowconveniowwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Workflowconveniowwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Workflowconveniowwds_12_workflowconveniodesc3 = AV26WorkflowConvenioDesc3;
         AV64Workflowconveniowwds_13_tfworkflowconveniodesc = AV35TFWorkflowConvenioDesc;
         AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel = AV36TFWorkflowConvenioDesc_Sel;
         AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel = AV37TFWorkflowConvenioStatus_Sel;
         AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat = AV38TFWorkflowConvenioCreatedAt;
         AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = AV39TFWorkflowConvenioCreatedAt_To;
         AV69Workflowconveniowwds_18_tfworkflowconveniosla = AV49TFWorkflowConvenioSLA;
         AV70Workflowconveniowwds_19_tfworkflowconveniosla_to = AV50TFWorkflowConvenioSLA_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFWorkflowConvenioDesc, AV36TFWorkflowConvenioDesc_Sel, AV37TFWorkflowConvenioStatus_Sel, AV38TFWorkflowConvenioCreatedAt, AV39TFWorkflowConvenioCreatedAt_To, AV49TFWorkflowConvenioSLA, AV50TFWorkflowConvenioSLA_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV51Pgmname = "WorkflowConvenioWW";
         edtavUpdate_Enabled = 0;
         edtWorkflowConvenioId_Enabled = 0;
         edtWorkflowConvenioDesc_Enabled = 0;
         cmbWorkflowConvenioStatus.Enabled = 0;
         edtWorkflowConvenioCreatedAt_Enabled = 0;
         edtWorkflowConvenioSLA_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E267Z2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV32ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV43DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_109 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_109"), ",", "."), 18, MidpointRounding.ToEven));
            AV45GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV46GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV47GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV40DDO_WorkflowConvenioCreatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_WORKFLOWCONVENIOCREATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV40DDO_WorkflowConvenioCreatedAtAuxDate", context.localUtil.Format(AV40DDO_WorkflowConvenioCreatedAtAuxDate, "99/99/99"));
            AV41DDO_WorkflowConvenioCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_WORKFLOWCONVENIOCREATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV41DDO_WorkflowConvenioCreatedAtAuxDateTo", context.localUtil.Format(AV41DDO_WorkflowConvenioCreatedAtAuxDateTo, "99/99/99"));
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
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
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
            AV18WorkflowConvenioDesc1 = cgiGet( edtavWorkflowconveniodesc1_Internalname);
            AssignAttri("", false, "AV18WorkflowConvenioDesc1", AV18WorkflowConvenioDesc1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV22WorkflowConvenioDesc2 = cgiGet( edtavWorkflowconveniodesc2_Internalname);
            AssignAttri("", false, "AV22WorkflowConvenioDesc2", AV22WorkflowConvenioDesc2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AV26WorkflowConvenioDesc3 = cgiGet( edtavWorkflowconveniodesc3_Internalname);
            AssignAttri("", false, "AV26WorkflowConvenioDesc3", AV26WorkflowConvenioDesc3);
            AV42DDO_WorkflowConvenioCreatedAtAuxDateText = cgiGet( edtavDdo_workflowconveniocreatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV42DDO_WorkflowConvenioCreatedAtAuxDateText", AV42DDO_WorkflowConvenioCreatedAtAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vWORKFLOWCONVENIODESC1"), AV18WorkflowConvenioDesc1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vWORKFLOWCONVENIODESC2"), AV22WorkflowConvenioDesc2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vWORKFLOWCONVENIODESC3"), AV26WorkflowConvenioDesc3) != 0 )
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
         E267Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E267Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFWORKFLOWCONVENIOCREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_workflowconveniocreatedatauxdatetext_Internalname});
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
         AV16DynamicFiltersSelector1 = "WORKFLOWCONVENIODESC";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "WORKFLOWCONVENIODESC";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "WORKFLOWCONVENIODESC";
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
         Form.Caption = " Workflow Convenio";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV43DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV43DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E277Z2( )
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
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV45GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV45GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV45GridCurrentPage), 10, 0));
         AV46GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV46GridPageCount", StringUtil.LTrimStr( (decimal)(AV46GridPageCount), 10, 0));
         GXt_char2 = AV47GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV51Pgmname, out  GXt_char2) ;
         AV47GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV47GridAppliedFilters", AV47GridAppliedFilters);
         AV52Workflowconveniowwds_1_filterfulltext = AV15FilterFullText;
         AV53Workflowconveniowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Workflowconveniowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Workflowconveniowwds_4_workflowconveniodesc1 = AV18WorkflowConvenioDesc1;
         AV56Workflowconveniowwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Workflowconveniowwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Workflowconveniowwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Workflowconveniowwds_8_workflowconveniodesc2 = AV22WorkflowConvenioDesc2;
         AV60Workflowconveniowwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Workflowconveniowwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Workflowconveniowwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Workflowconveniowwds_12_workflowconveniodesc3 = AV26WorkflowConvenioDesc3;
         AV64Workflowconveniowwds_13_tfworkflowconveniodesc = AV35TFWorkflowConvenioDesc;
         AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel = AV36TFWorkflowConvenioDesc_Sel;
         AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel = AV37TFWorkflowConvenioStatus_Sel;
         AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat = AV38TFWorkflowConvenioCreatedAt;
         AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = AV39TFWorkflowConvenioCreatedAt_To;
         AV69Workflowconveniowwds_18_tfworkflowconveniosla = AV49TFWorkflowConvenioSLA;
         AV70Workflowconveniowwds_19_tfworkflowconveniosla_to = AV50TFWorkflowConvenioSLA_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E127Z2( )
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
            AV44PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV44PageToGo) ;
         }
      }

      protected void E137Z2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E147Z2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkflowConvenioDesc") == 0 )
            {
               AV35TFWorkflowConvenioDesc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFWorkflowConvenioDesc", AV35TFWorkflowConvenioDesc);
               AV36TFWorkflowConvenioDesc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFWorkflowConvenioDesc_Sel", AV36TFWorkflowConvenioDesc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkflowConvenioStatus") == 0 )
            {
               AV37TFWorkflowConvenioStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV37TFWorkflowConvenioStatus_Sel", StringUtil.Str( (decimal)(AV37TFWorkflowConvenioStatus_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkflowConvenioCreatedAt") == 0 )
            {
               AV38TFWorkflowConvenioCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV38TFWorkflowConvenioCreatedAt", context.localUtil.TToC( AV38TFWorkflowConvenioCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV39TFWorkflowConvenioCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV39TFWorkflowConvenioCreatedAt_To", context.localUtil.TToC( AV39TFWorkflowConvenioCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV39TFWorkflowConvenioCreatedAt_To) )
               {
                  AV39TFWorkflowConvenioCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV39TFWorkflowConvenioCreatedAt_To)), (short)(DateTimeUtil.Month( AV39TFWorkflowConvenioCreatedAt_To)), (short)(DateTimeUtil.Day( AV39TFWorkflowConvenioCreatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV39TFWorkflowConvenioCreatedAt_To", context.localUtil.TToC( AV39TFWorkflowConvenioCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkflowConvenioSLA") == 0 )
            {
               AV49TFWorkflowConvenioSLA = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV49TFWorkflowConvenioSLA", StringUtil.LTrimStr( (decimal)(AV49TFWorkflowConvenioSLA), 4, 0));
               AV50TFWorkflowConvenioSLA_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFWorkflowConvenioSLA_To", StringUtil.LTrimStr( (decimal)(AV50TFWorkflowConvenioSLA_To), 4, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E287Z2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV48Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV48Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workflowconvenio"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A742WorkflowConvenioId,9,0));
         edtavUpdate_Link = formatLink("workflowconvenio") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workflowconvenio"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A742WorkflowConvenioId,9,0));
         edtWorkflowConvenioDesc_Link = formatLink("workflowconvenio") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 109;
         }
         sendrow_1092( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_109_Refreshing )
         {
            DoAjaxLoad(109, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E217Z2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E157Z2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFWorkflowConvenioDesc, AV36TFWorkflowConvenioDesc_Sel, AV37TFWorkflowConvenioStatus_Sel, AV38TFWorkflowConvenioCreatedAt, AV39TFWorkflowConvenioCreatedAt_To, AV49TFWorkflowConvenioSLA, AV50TFWorkflowConvenioSLA_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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

      protected void E227Z2( )
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

      protected void E237Z2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E167Z2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFWorkflowConvenioDesc, AV36TFWorkflowConvenioDesc_Sel, AV37TFWorkflowConvenioStatus_Sel, AV38TFWorkflowConvenioCreatedAt, AV39TFWorkflowConvenioCreatedAt_To, AV49TFWorkflowConvenioSLA, AV50TFWorkflowConvenioSLA_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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

      protected void E247Z2( )
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

      protected void E177Z2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18WorkflowConvenioDesc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22WorkflowConvenioDesc2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26WorkflowConvenioDesc3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV35TFWorkflowConvenioDesc, AV36TFWorkflowConvenioDesc_Sel, AV37TFWorkflowConvenioStatus_Sel, AV38TFWorkflowConvenioCreatedAt, AV39TFWorkflowConvenioCreatedAt_To, AV49TFWorkflowConvenioSLA, AV50TFWorkflowConvenioSLA_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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

      protected void E257Z2( )
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

      protected void E117Z2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WorkflowConvenioWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV51Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WorkflowConvenioWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV33ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WorkflowConvenioWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV51Pgmname+"GridState",  AV33ManageFiltersXml) ;
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

      protected void E187Z2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workflowconvenio"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("workflowconvenio") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E197Z2( )
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
         new workflowconveniowwexport(context ).execute( out  AV29ExcelFilename, out  AV30ErrorMessage) ;
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

      protected void E207Z2( )
      {
         /* 'DoExportReport' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("workflowconveniowwexportreport") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
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
         edtavWorkflowconveniodesc1_Visible = 0;
         AssignProp("", false, edtavWorkflowconveniodesc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWorkflowconveniodesc1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "WORKFLOWCONVENIODESC") == 0 )
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
         edtavWorkflowconveniodesc2_Visible = 0;
         AssignProp("", false, edtavWorkflowconveniodesc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWorkflowconveniodesc2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "WORKFLOWCONVENIODESC") == 0 )
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
         edtavWorkflowconveniodesc3_Visible = 0;
         AssignProp("", false, edtavWorkflowconveniodesc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWorkflowconveniodesc3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "WORKFLOWCONVENIODESC") == 0 )
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
         AV20DynamicFiltersSelector2 = "WORKFLOWCONVENIODESC";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22WorkflowConvenioDesc2 = "";
         AssignAttri("", false, "AV22WorkflowConvenioDesc2", AV22WorkflowConvenioDesc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "WORKFLOWCONVENIODESC";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV26WorkflowConvenioDesc3 = "";
         AssignAttri("", false, "AV26WorkflowConvenioDesc3", AV26WorkflowConvenioDesc3);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WorkflowConvenioWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV32ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV35TFWorkflowConvenioDesc = "";
         AssignAttri("", false, "AV35TFWorkflowConvenioDesc", AV35TFWorkflowConvenioDesc);
         AV36TFWorkflowConvenioDesc_Sel = "";
         AssignAttri("", false, "AV36TFWorkflowConvenioDesc_Sel", AV36TFWorkflowConvenioDesc_Sel);
         AV37TFWorkflowConvenioStatus_Sel = 0;
         AssignAttri("", false, "AV37TFWorkflowConvenioStatus_Sel", StringUtil.Str( (decimal)(AV37TFWorkflowConvenioStatus_Sel), 1, 0));
         AV38TFWorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV38TFWorkflowConvenioCreatedAt", context.localUtil.TToC( AV38TFWorkflowConvenioCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV39TFWorkflowConvenioCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV39TFWorkflowConvenioCreatedAt_To", context.localUtil.TToC( AV39TFWorkflowConvenioCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         AV49TFWorkflowConvenioSLA = 0;
         AssignAttri("", false, "AV49TFWorkflowConvenioSLA", StringUtil.LTrimStr( (decimal)(AV49TFWorkflowConvenioSLA), 4, 0));
         AV50TFWorkflowConvenioSLA_To = 0;
         AssignAttri("", false, "AV50TFWorkflowConvenioSLA_To", StringUtil.LTrimStr( (decimal)(AV50TFWorkflowConvenioSLA_To), 4, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "WORKFLOWCONVENIODESC";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18WorkflowConvenioDesc1 = "";
         AssignAttri("", false, "AV18WorkflowConvenioDesc1", AV18WorkflowConvenioDesc1);
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
         if ( StringUtil.StrCmp(AV31Session.Get(AV51Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV51Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV31Session.Get(AV51Pgmname+"GridState"), null, "", "");
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
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV71GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC") == 0 )
            {
               AV35TFWorkflowConvenioDesc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFWorkflowConvenioDesc", AV35TFWorkflowConvenioDesc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIODESC_SEL") == 0 )
            {
               AV36TFWorkflowConvenioDesc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFWorkflowConvenioDesc_Sel", AV36TFWorkflowConvenioDesc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIOSTATUS_SEL") == 0 )
            {
               AV37TFWorkflowConvenioStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV37TFWorkflowConvenioStatus_Sel", StringUtil.Str( (decimal)(AV37TFWorkflowConvenioStatus_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIOCREATEDAT") == 0 )
            {
               AV38TFWorkflowConvenioCreatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV38TFWorkflowConvenioCreatedAt", context.localUtil.TToC( AV38TFWorkflowConvenioCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV39TFWorkflowConvenioCreatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV39TFWorkflowConvenioCreatedAt_To", context.localUtil.TToC( AV39TFWorkflowConvenioCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV40DDO_WorkflowConvenioCreatedAtAuxDate = DateTimeUtil.ResetTime(AV38TFWorkflowConvenioCreatedAt);
               AssignAttri("", false, "AV40DDO_WorkflowConvenioCreatedAtAuxDate", context.localUtil.Format(AV40DDO_WorkflowConvenioCreatedAtAuxDate, "99/99/99"));
               AV41DDO_WorkflowConvenioCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV39TFWorkflowConvenioCreatedAt_To);
               AssignAttri("", false, "AV41DDO_WorkflowConvenioCreatedAtAuxDateTo", context.localUtil.Format(AV41DDO_WorkflowConvenioCreatedAtAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFWORKFLOWCONVENIOSLA") == 0 )
            {
               AV49TFWorkflowConvenioSLA = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV49TFWorkflowConvenioSLA", StringUtil.LTrimStr( (decimal)(AV49TFWorkflowConvenioSLA), 4, 0));
               AV50TFWorkflowConvenioSLA_To = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFWorkflowConvenioSLA_To", StringUtil.LTrimStr( (decimal)(AV50TFWorkflowConvenioSLA_To), 4, 0));
            }
            AV71GXV1 = (int)(AV71GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWorkflowConvenioDesc_Sel)),  AV36TFWorkflowConvenioDesc_Sel, out  GXt_char2) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+((0==AV37TFWorkflowConvenioStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV37TFWorkflowConvenioStatus_Sel), 1, 0))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWorkflowConvenioDesc)),  AV35TFWorkflowConvenioDesc, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char2+"||"+((DateTime.MinValue==AV38TFWorkflowConvenioCreatedAt) ? "" : context.localUtil.DToC( AV40DDO_WorkflowConvenioCreatedAtAuxDate, 4, "/"))+"|"+((0==AV49TFWorkflowConvenioSLA) ? "" : StringUtil.Str( (decimal)(AV49TFWorkflowConvenioSLA), 4, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV39TFWorkflowConvenioCreatedAt_To) ? "" : context.localUtil.DToC( AV41DDO_WorkflowConvenioCreatedAtAuxDateTo, 4, "/"))+"|"+((0==AV50TFWorkflowConvenioSLA_To) ? "" : StringUtil.Str( (decimal)(AV50TFWorkflowConvenioSLA_To), 4, 0));
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "WORKFLOWCONVENIODESC") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18WorkflowConvenioDesc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18WorkflowConvenioDesc1", AV18WorkflowConvenioDesc1);
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
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "WORKFLOWCONVENIODESC") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22WorkflowConvenioDesc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV22WorkflowConvenioDesc2", AV22WorkflowConvenioDesc2);
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
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "WORKFLOWCONVENIODESC") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV26WorkflowConvenioDesc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV26WorkflowConvenioDesc3", AV26WorkflowConvenioDesc3);
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
         AV10GridState.FromXml(AV31Session.Get(AV51Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFWORKFLOWCONVENIODESC",  "Passo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWorkflowConvenioDesc)),  0,  AV35TFWorkflowConvenioDesc,  AV35TFWorkflowConvenioDesc,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWorkflowConvenioDesc_Sel)),  AV36TFWorkflowConvenioDesc_Sel,  AV36TFWorkflowConvenioDesc_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFWORKFLOWCONVENIOSTATUS_SEL",  "Status",  !(0==AV37TFWorkflowConvenioStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV37TFWorkflowConvenioStatus_Sel), 1, 0)),  ((AV37TFWorkflowConvenioStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFWORKFLOWCONVENIOCREATEDAT",  "Created At",  !((DateTime.MinValue==AV38TFWorkflowConvenioCreatedAt)&&(DateTime.MinValue==AV39TFWorkflowConvenioCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV38TFWorkflowConvenioCreatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV38TFWorkflowConvenioCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV38TFWorkflowConvenioCreatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV39TFWorkflowConvenioCreatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV39TFWorkflowConvenioCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV39TFWorkflowConvenioCreatedAt_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFWORKFLOWCONVENIOSLA",  "SLA",  !((0==AV49TFWorkflowConvenioSLA)&&(0==AV50TFWorkflowConvenioSLA_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV49TFWorkflowConvenioSLA), 4, 0)),  ((0==AV49TFWorkflowConvenioSLA) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV49TFWorkflowConvenioSLA), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV50TFWorkflowConvenioSLA_To), 4, 0)),  ((0==AV50TFWorkflowConvenioSLA_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV50TFWorkflowConvenioSLA_To), "ZZZ9")))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV51Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "WORKFLOWCONVENIODESC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18WorkflowConvenioDesc1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Passo",  AV17DynamicFiltersOperator1,  AV18WorkflowConvenioDesc1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18WorkflowConvenioDesc1, "Contém"+" "+AV18WorkflowConvenioDesc1, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "WORKFLOWCONVENIODESC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22WorkflowConvenioDesc2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Passo",  AV21DynamicFiltersOperator2,  AV22WorkflowConvenioDesc2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV22WorkflowConvenioDesc2, "Contém"+" "+AV22WorkflowConvenioDesc2, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "WORKFLOWCONVENIODESC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26WorkflowConvenioDesc3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Passo",  AV25DynamicFiltersOperator3,  AV26WorkflowConvenioDesc3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV26WorkflowConvenioDesc3, "Contém"+" "+AV26WorkflowConvenioDesc3, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV51Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "WorkflowConvenio";
         AV31Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_91_7Z2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", true, 0, "HLP_WorkflowConvenioWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_workflowconveniodesc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWorkflowconveniodesc3_Internalname, "Workflow Convenio Desc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWorkflowconveniodesc3_Internalname, AV26WorkflowConvenioDesc3, StringUtil.RTrim( context.localUtil.Format( AV26WorkflowConvenioDesc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWorkflowconveniodesc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavWorkflowconveniodesc3_Visible, edtavWorkflowconveniodesc3_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkflowConvenioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WorkflowConvenioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_91_7Z2e( true) ;
         }
         else
         {
            wb_table3_91_7Z2e( false) ;
         }
      }

      protected void wb_table2_69_7Z2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_WorkflowConvenioWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_workflowconveniodesc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWorkflowconveniodesc2_Internalname, "Workflow Convenio Desc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWorkflowconveniodesc2_Internalname, AV22WorkflowConvenioDesc2, StringUtil.RTrim( context.localUtil.Format( AV22WorkflowConvenioDesc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWorkflowconveniodesc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavWorkflowconveniodesc2_Visible, edtavWorkflowconveniodesc2_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkflowConvenioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WorkflowConvenioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WorkflowConvenioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_69_7Z2e( true) ;
         }
         else
         {
            wb_table2_69_7Z2e( false) ;
         }
      }

      protected void wb_table1_47_7Z2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_WorkflowConvenioWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_workflowconveniodesc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWorkflowconveniodesc1_Internalname, "Workflow Convenio Desc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWorkflowconveniodesc1_Internalname, AV18WorkflowConvenioDesc1, StringUtil.RTrim( context.localUtil.Format( AV18WorkflowConvenioDesc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWorkflowconveniodesc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavWorkflowconveniodesc1_Visible, edtavWorkflowconveniodesc1_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkflowConvenioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WorkflowConvenioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WorkflowConvenioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_47_7Z2e( true) ;
         }
         else
         {
            wb_table1_47_7Z2e( false) ;
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
         PA7Z2( ) ;
         WS7Z2( ) ;
         WE7Z2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019272683", true, true);
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
         context.AddJavascriptSource("workflowconvenioww.js", "?202561019272684", false, true);
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1092( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_109_idx;
         edtWorkflowConvenioId_Internalname = "WORKFLOWCONVENIOID_"+sGXsfl_109_idx;
         edtWorkflowConvenioDesc_Internalname = "WORKFLOWCONVENIODESC_"+sGXsfl_109_idx;
         cmbWorkflowConvenioStatus_Internalname = "WORKFLOWCONVENIOSTATUS_"+sGXsfl_109_idx;
         edtWorkflowConvenioCreatedAt_Internalname = "WORKFLOWCONVENIOCREATEDAT_"+sGXsfl_109_idx;
         edtWorkflowConvenioSLA_Internalname = "WORKFLOWCONVENIOSLA_"+sGXsfl_109_idx;
      }

      protected void SubsflControlProps_fel_1092( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_109_fel_idx;
         edtWorkflowConvenioId_Internalname = "WORKFLOWCONVENIOID_"+sGXsfl_109_fel_idx;
         edtWorkflowConvenioDesc_Internalname = "WORKFLOWCONVENIODESC_"+sGXsfl_109_fel_idx;
         cmbWorkflowConvenioStatus_Internalname = "WORKFLOWCONVENIOSTATUS_"+sGXsfl_109_fel_idx;
         edtWorkflowConvenioCreatedAt_Internalname = "WORKFLOWCONVENIOCREATEDAT_"+sGXsfl_109_fel_idx;
         edtWorkflowConvenioSLA_Internalname = "WORKFLOWCONVENIOSLA_"+sGXsfl_109_fel_idx;
      }

      protected void sendrow_1092( )
      {
         sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
         SubsflControlProps_1092( ) ;
         WB7Z0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_109_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_109_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_109_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_109_idx + "',109)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV48Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkflowConvenioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A742WorkflowConvenioId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkflowConvenioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkflowConvenioDesc_Internalname,(string)A736WorkflowConvenioDesc,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtWorkflowConvenioDesc_Link,(string)"",(string)"",(string)"",(string)edtWorkflowConvenioDesc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbWorkflowConvenioStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WORKFLOWCONVENIOSTATUS_" + sGXsfl_109_idx;
               cmbWorkflowConvenioStatus.Name = GXCCtl;
               cmbWorkflowConvenioStatus.WebTags = "";
               cmbWorkflowConvenioStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
               cmbWorkflowConvenioStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
               if ( cmbWorkflowConvenioStatus.ItemCount > 0 )
               {
                  A737WorkflowConvenioStatus = StringUtil.StrToBool( cmbWorkflowConvenioStatus.getValidValue(StringUtil.BoolToStr( A737WorkflowConvenioStatus)));
                  n737WorkflowConvenioStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWorkflowConvenioStatus,(string)cmbWorkflowConvenioStatus_Internalname,StringUtil.BoolToStr( A737WorkflowConvenioStatus),(short)1,(string)cmbWorkflowConvenioStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWorkflowConvenioStatus.CurrentValue = StringUtil.BoolToStr( A737WorkflowConvenioStatus);
            AssignProp("", false, cmbWorkflowConvenioStatus_Internalname, "Values", (string)(cmbWorkflowConvenioStatus.ToJavascriptSource()), !bGXsfl_109_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkflowConvenioCreatedAt_Internalname,context.localUtil.TToC( A743WorkflowConvenioCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A743WorkflowConvenioCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkflowConvenioCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkflowConvenioSLA_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A753WorkflowConvenioSLA), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A753WorkflowConvenioSLA), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkflowConvenioSLA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes7Z2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_109_idx = ((subGrid_Islastpage==1)&&(nGXsfl_109_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_109_idx+1);
            sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
            SubsflControlProps_1092( ) ;
         }
         /* End function sendrow_1092 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
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
         GXCCtl = "WORKFLOWCONVENIOSTATUS_" + sGXsfl_109_idx;
         cmbWorkflowConvenioStatus.Name = GXCCtl;
         cmbWorkflowConvenioStatus.WebTags = "";
         cmbWorkflowConvenioStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbWorkflowConvenioStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbWorkflowConvenioStatus.ItemCount > 0 )
         {
            A737WorkflowConvenioStatus = StringUtil.StrToBool( cmbWorkflowConvenioStatus.getValidValue(StringUtil.BoolToStr( A737WorkflowConvenioStatus)));
            n737WorkflowConvenioStatus = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl109( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"109\">") ;
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
            context.SendWebValue( "Convenio Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Passo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Created At") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "SLA") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV48Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A742WorkflowConvenioId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A736WorkflowConvenioDesc));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtWorkflowConvenioDesc_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A737WorkflowConvenioStatus)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A743WorkflowConvenioCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A753WorkflowConvenioSLA), 4, 0, ".", ""))));
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
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnexport_Internalname = "BTNEXPORT";
         bttBtnexportreport_Internalname = "BTNEXPORTREPORT";
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
         edtavUpdate_Internalname = "vUPDATE";
         edtWorkflowConvenioId_Internalname = "WORKFLOWCONVENIOID";
         edtWorkflowConvenioDesc_Internalname = "WORKFLOWCONVENIODESC";
         cmbWorkflowConvenioStatus_Internalname = "WORKFLOWCONVENIOSTATUS";
         edtWorkflowConvenioCreatedAt_Internalname = "WORKFLOWCONVENIOCREATEDAT";
         edtWorkflowConvenioSLA_Internalname = "WORKFLOWCONVENIOSLA";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_workflowconveniocreatedatauxdatetext_Internalname = "vDDO_WORKFLOWCONVENIOCREATEDATAUXDATETEXT";
         Tfworkflowconveniocreatedat_rangepicker_Internalname = "TFWORKFLOWCONVENIOCREATEDAT_RANGEPICKER";
         divDdo_workflowconveniocreatedatauxdates_Internalname = "DDO_WORKFLOWCONVENIOCREATEDATAUXDATES";
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
         edtWorkflowConvenioSLA_Jsonclick = "";
         edtWorkflowConvenioCreatedAt_Jsonclick = "";
         cmbWorkflowConvenioStatus_Jsonclick = "";
         edtWorkflowConvenioDesc_Jsonclick = "";
         edtWorkflowConvenioDesc_Link = "";
         edtWorkflowConvenioId_Jsonclick = "";
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavWorkflowconveniodesc1_Jsonclick = "";
         edtavWorkflowconveniodesc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavWorkflowconveniodesc2_Jsonclick = "";
         edtavWorkflowconveniodesc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavWorkflowconveniodesc3_Jsonclick = "";
         edtavWorkflowconveniodesc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavWorkflowconveniodesc3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavWorkflowconveniodesc2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavWorkflowconveniodesc1_Visible = 1;
         edtWorkflowConvenioSLA_Enabled = 0;
         edtWorkflowConvenioCreatedAt_Enabled = 0;
         cmbWorkflowConvenioStatus.Enabled = 0;
         edtWorkflowConvenioDesc_Enabled = 0;
         edtWorkflowConvenioId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_workflowconveniocreatedatauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Format = "|||4.0";
         Ddo_grid_Datalistproc = "WorkflowConvenioWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|1:WWP_TSChecked,2:WWP_TSUnChecked||";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues||";
         Ddo_grid_Includedatalist = "T|T||";
         Ddo_grid_Filterisrange = "||P|T";
         Ddo_grid_Filtertype = "Character||Date|Numeric";
         Ddo_grid_Includefilter = "T||T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "2:WorkflowConvenioDesc|3:WorkflowConvenioStatus|4:WorkflowConvenioCreatedAt|5:WorkflowConvenioSLA";
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
         Form.Caption = " Workflow Convenio";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E127Z2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E137Z2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E147Z2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E287Z2","iparms":[{"av":"A742WorkflowConvenioId","fld":"WORKFLOWCONVENIOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV48Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"edtWorkflowConvenioDesc_Link","ctrl":"WORKFLOWCONVENIODESC","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E217Z2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E157Z2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E227Z2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E237Z2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E167Z2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E247Z2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E177Z2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV45GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E257Z2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E117Z2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV40DDO_WorkflowConvenioCreatedAtAuxDate","fld":"vDDO_WORKFLOWCONVENIOCREATEDATAUXDATE","type":"date"},{"av":"AV41DDO_WorkflowConvenioCreatedAtAuxDateTo","fld":"vDDO_WORKFLOWCONVENIOCREATEDATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV40DDO_WorkflowConvenioCreatedAtAuxDate","fld":"vDDO_WORKFLOWCONVENIOCREATEDATAUXDATE","type":"date"},{"av":"AV41DDO_WorkflowConvenioCreatedAtAuxDateTo","fld":"vDDO_WORKFLOWCONVENIOCREATEDATAUXDATETO","type":"date"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"},{"av":"AV45GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E187Z2","iparms":[{"av":"A742WorkflowConvenioId","fld":"WORKFLOWCONVENIOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E197Z2","iparms":[{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40DDO_WorkflowConvenioCreatedAtAuxDate","fld":"vDDO_WORKFLOWCONVENIOCREATEDATAUXDATE","type":"date"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV41DDO_WorkflowConvenioCreatedAtAuxDateTo","fld":"vDDO_WORKFLOWCONVENIOCREATEDATAUXDATETO","type":"date"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV40DDO_WorkflowConvenioCreatedAtAuxDate","fld":"vDDO_WORKFLOWCONVENIOCREATEDATAUXDATE","type":"date"},{"av":"AV41DDO_WorkflowConvenioCreatedAtAuxDateTo","fld":"vDDO_WORKFLOWCONVENIOCREATEDATAUXDATETO","type":"date"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"}]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E207Z2","iparms":[{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV40DDO_WorkflowConvenioCreatedAtAuxDate","fld":"vDDO_WORKFLOWCONVENIOCREATEDATAUXDATE","type":"date"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV41DDO_WorkflowConvenioCreatedAtAuxDateTo","fld":"vDDO_WORKFLOWCONVENIOCREATEDATAUXDATETO","type":"date"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18WorkflowConvenioDesc1","fld":"vWORKFLOWCONVENIODESC1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22WorkflowConvenioDesc2","fld":"vWORKFLOWCONVENIODESC2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26WorkflowConvenioDesc3","fld":"vWORKFLOWCONVENIODESC3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV35TFWorkflowConvenioDesc","fld":"vTFWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV36TFWorkflowConvenioDesc_Sel","fld":"vTFWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV37TFWorkflowConvenioStatus_Sel","fld":"vTFWORKFLOWCONVENIOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFWorkflowConvenioCreatedAt","fld":"vTFWORKFLOWCONVENIOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV39TFWorkflowConvenioCreatedAt_To","fld":"vTFWORKFLOWCONVENIOCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFWorkflowConvenioSLA","fld":"vTFWORKFLOWCONVENIOSLA","pic":"ZZZ9","type":"int"},{"av":"AV50TFWorkflowConvenioSLA_To","fld":"vTFWORKFLOWCONVENIOSLA_TO","pic":"ZZZ9","type":"int"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV40DDO_WorkflowConvenioCreatedAtAuxDate","fld":"vDDO_WORKFLOWCONVENIOCREATEDATAUXDATE","type":"date"},{"av":"AV41DDO_WorkflowConvenioCreatedAtAuxDateTo","fld":"vDDO_WORKFLOWCONVENIOCREATEDATAUXDATETO","type":"date"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavWorkflowconveniodesc1_Visible","ctrl":"vWORKFLOWCONVENIODESC1","prop":"Visible"},{"av":"edtavWorkflowconveniodesc2_Visible","ctrl":"vWORKFLOWCONVENIODESC2","prop":"Visible"},{"av":"edtavWorkflowconveniodesc3_Visible","ctrl":"vWORKFLOWCONVENIODESC3","prop":"Visible"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Workflowconveniosla","iparms":[]}""");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV18WorkflowConvenioDesc1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV22WorkflowConvenioDesc2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26WorkflowConvenioDesc3 = "";
         AV51Pgmname = "";
         AV35TFWorkflowConvenioDesc = "";
         AV36TFWorkflowConvenioDesc_Sel = "";
         AV38TFWorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         AV39TFWorkflowConvenioCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV32ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV47GridAppliedFilters = "";
         AV43DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV40DDO_WorkflowConvenioCreatedAtAuxDate = DateTime.MinValue;
         AV41DDO_WorkflowConvenioCreatedAtAuxDateTo = DateTime.MinValue;
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
         bttBtninsert_Jsonclick = "";
         bttBtnexport_Jsonclick = "";
         bttBtnexportreport_Jsonclick = "";
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
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV42DDO_WorkflowConvenioCreatedAtAuxDateText = "";
         ucTfworkflowconveniocreatedat_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV48Update = "";
         A736WorkflowConvenioDesc = "";
         A743WorkflowConvenioCreatedAt = (DateTime)(DateTime.MinValue);
         lV52Workflowconveniowwds_1_filterfulltext = "";
         lV55Workflowconveniowwds_4_workflowconveniodesc1 = "";
         lV59Workflowconveniowwds_8_workflowconveniodesc2 = "";
         lV63Workflowconveniowwds_12_workflowconveniodesc3 = "";
         lV64Workflowconveniowwds_13_tfworkflowconveniodesc = "";
         AV52Workflowconveniowwds_1_filterfulltext = "";
         AV53Workflowconveniowwds_2_dynamicfiltersselector1 = "";
         AV55Workflowconveniowwds_4_workflowconveniodesc1 = "";
         AV57Workflowconveniowwds_6_dynamicfiltersselector2 = "";
         AV59Workflowconveniowwds_8_workflowconveniodesc2 = "";
         AV61Workflowconveniowwds_10_dynamicfiltersselector3 = "";
         AV63Workflowconveniowwds_12_workflowconveniodesc3 = "";
         AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel = "";
         AV64Workflowconveniowwds_13_tfworkflowconveniodesc = "";
         AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat = (DateTime)(DateTime.MinValue);
         AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to = (DateTime)(DateTime.MinValue);
         H007Z2_A753WorkflowConvenioSLA = new short[1] ;
         H007Z2_n753WorkflowConvenioSLA = new bool[] {false} ;
         H007Z2_A743WorkflowConvenioCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H007Z2_n743WorkflowConvenioCreatedAt = new bool[] {false} ;
         H007Z2_A737WorkflowConvenioStatus = new bool[] {false} ;
         H007Z2_n737WorkflowConvenioStatus = new bool[] {false} ;
         H007Z2_A736WorkflowConvenioDesc = new string[] {""} ;
         H007Z2_n736WorkflowConvenioDesc = new bool[] {false} ;
         H007Z2_A742WorkflowConvenioId = new int[1] ;
         H007Z3_AGRID_nRecordCount = new long[1] ;
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
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workflowconvenioww__default(),
            new Object[][] {
                new Object[] {
               H007Z2_A753WorkflowConvenioSLA, H007Z2_n753WorkflowConvenioSLA, H007Z2_A743WorkflowConvenioCreatedAt, H007Z2_n743WorkflowConvenioCreatedAt, H007Z2_A737WorkflowConvenioStatus, H007Z2_n737WorkflowConvenioStatus, H007Z2_A736WorkflowConvenioDesc, H007Z2_n736WorkflowConvenioDesc, H007Z2_A742WorkflowConvenioId
               }
               , new Object[] {
               H007Z3_AGRID_nRecordCount
               }
            }
         );
         AV51Pgmname = "WorkflowConvenioWW";
         /* GeneXus formulas. */
         AV51Pgmname = "WorkflowConvenioWW";
         edtavUpdate_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV34ManageFiltersExecutionStep ;
      private short AV37TFWorkflowConvenioStatus_Sel ;
      private short AV49TFWorkflowConvenioSLA ;
      private short AV50TFWorkflowConvenioSLA_To ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A753WorkflowConvenioSLA ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV54Workflowconveniowwds_3_dynamicfiltersoperator1 ;
      private short AV58Workflowconveniowwds_7_dynamicfiltersoperator2 ;
      private short AV62Workflowconveniowwds_11_dynamicfiltersoperator3 ;
      private short AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel ;
      private short AV69Workflowconveniowwds_18_tfworkflowconveniosla ;
      private short AV70Workflowconveniowwds_19_tfworkflowconveniosla_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_109 ;
      private int nGXsfl_109_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A742WorkflowConvenioId ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWorkflowConvenioId_Enabled ;
      private int edtWorkflowConvenioDesc_Enabled ;
      private int edtWorkflowConvenioCreatedAt_Enabled ;
      private int edtWorkflowConvenioSLA_Enabled ;
      private int AV44PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavWorkflowconveniodesc1_Visible ;
      private int edtavWorkflowconveniodesc2_Visible ;
      private int edtavWorkflowconveniodesc3_Visible ;
      private int AV71GXV1 ;
      private int edtavWorkflowconveniodesc3_Enabled ;
      private int edtavWorkflowconveniodesc2_Enabled ;
      private int edtavWorkflowconveniodesc1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV45GridCurrentPage ;
      private long AV46GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_109_idx="0001" ;
      private string AV51Pgmname ;
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
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
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
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnexport_Internalname ;
      private string bttBtnexport_Jsonclick ;
      private string bttBtnexportreport_Internalname ;
      private string bttBtnexportreport_Jsonclick ;
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
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_workflowconveniocreatedatauxdates_Internalname ;
      private string edtavDdo_workflowconveniocreatedatauxdatetext_Internalname ;
      private string edtavDdo_workflowconveniocreatedatauxdatetext_Jsonclick ;
      private string Tfworkflowconveniocreatedat_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV48Update ;
      private string edtavUpdate_Internalname ;
      private string edtWorkflowConvenioId_Internalname ;
      private string edtWorkflowConvenioDesc_Internalname ;
      private string cmbWorkflowConvenioStatus_Internalname ;
      private string edtWorkflowConvenioCreatedAt_Internalname ;
      private string edtWorkflowConvenioSLA_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavWorkflowconveniodesc1_Internalname ;
      private string edtavWorkflowconveniodesc2_Internalname ;
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
      private string edtavUpdate_Link ;
      private string GXEncryptionTmp ;
      private string edtWorkflowConvenioDesc_Link ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_workflowconveniodesc3_cell_Internalname ;
      private string edtavWorkflowconveniodesc3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_workflowconveniodesc2_cell_Internalname ;
      private string edtavWorkflowconveniodesc2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_workflowconveniodesc1_cell_Internalname ;
      private string edtavWorkflowconveniodesc1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_109_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtWorkflowConvenioId_Jsonclick ;
      private string edtWorkflowConvenioDesc_Jsonclick ;
      private string GXCCtl ;
      private string cmbWorkflowConvenioStatus_Jsonclick ;
      private string edtWorkflowConvenioCreatedAt_Jsonclick ;
      private string edtWorkflowConvenioSLA_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV38TFWorkflowConvenioCreatedAt ;
      private DateTime AV39TFWorkflowConvenioCreatedAt_To ;
      private DateTime A743WorkflowConvenioCreatedAt ;
      private DateTime AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat ;
      private DateTime AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ;
      private DateTime AV40DDO_WorkflowConvenioCreatedAtAuxDate ;
      private DateTime AV41DDO_WorkflowConvenioCreatedAtAuxDateTo ;
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
      private bool n736WorkflowConvenioDesc ;
      private bool A737WorkflowConvenioStatus ;
      private bool n737WorkflowConvenioStatus ;
      private bool n743WorkflowConvenioCreatedAt ;
      private bool n753WorkflowConvenioSLA ;
      private bool bGXsfl_109_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV56Workflowconveniowwds_5_dynamicfiltersenabled2 ;
      private bool AV60Workflowconveniowwds_9_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV33ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18WorkflowConvenioDesc1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22WorkflowConvenioDesc2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26WorkflowConvenioDesc3 ;
      private string AV35TFWorkflowConvenioDesc ;
      private string AV36TFWorkflowConvenioDesc_Sel ;
      private string AV47GridAppliedFilters ;
      private string AV42DDO_WorkflowConvenioCreatedAtAuxDateText ;
      private string A736WorkflowConvenioDesc ;
      private string lV52Workflowconveniowwds_1_filterfulltext ;
      private string lV55Workflowconveniowwds_4_workflowconveniodesc1 ;
      private string lV59Workflowconveniowwds_8_workflowconveniodesc2 ;
      private string lV63Workflowconveniowwds_12_workflowconveniodesc3 ;
      private string lV64Workflowconveniowwds_13_tfworkflowconveniodesc ;
      private string AV52Workflowconveniowwds_1_filterfulltext ;
      private string AV53Workflowconveniowwds_2_dynamicfiltersselector1 ;
      private string AV55Workflowconveniowwds_4_workflowconveniodesc1 ;
      private string AV57Workflowconveniowwds_6_dynamicfiltersselector2 ;
      private string AV59Workflowconveniowwds_8_workflowconveniodesc2 ;
      private string AV61Workflowconveniowwds_10_dynamicfiltersselector3 ;
      private string AV63Workflowconveniowwds_12_workflowconveniodesc3 ;
      private string AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel ;
      private string AV64Workflowconveniowwds_13_tfworkflowconveniodesc ;
      private string AV29ExcelFilename ;
      private string AV30ErrorMessage ;
      private IGxSession AV31Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfworkflowconveniocreatedat_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbWorkflowConvenioStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV32ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV43DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private short[] H007Z2_A753WorkflowConvenioSLA ;
      private bool[] H007Z2_n753WorkflowConvenioSLA ;
      private DateTime[] H007Z2_A743WorkflowConvenioCreatedAt ;
      private bool[] H007Z2_n743WorkflowConvenioCreatedAt ;
      private bool[] H007Z2_A737WorkflowConvenioStatus ;
      private bool[] H007Z2_n737WorkflowConvenioStatus ;
      private string[] H007Z2_A736WorkflowConvenioDesc ;
      private bool[] H007Z2_n736WorkflowConvenioDesc ;
      private int[] H007Z2_A742WorkflowConvenioId ;
      private long[] H007Z3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class workflowconvenioww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007Z2( IGxContext context ,
                                             string AV52Workflowconveniowwds_1_filterfulltext ,
                                             string AV53Workflowconveniowwds_2_dynamicfiltersselector1 ,
                                             short AV54Workflowconveniowwds_3_dynamicfiltersoperator1 ,
                                             string AV55Workflowconveniowwds_4_workflowconveniodesc1 ,
                                             bool AV56Workflowconveniowwds_5_dynamicfiltersenabled2 ,
                                             string AV57Workflowconveniowwds_6_dynamicfiltersselector2 ,
                                             short AV58Workflowconveniowwds_7_dynamicfiltersoperator2 ,
                                             string AV59Workflowconveniowwds_8_workflowconveniodesc2 ,
                                             bool AV60Workflowconveniowwds_9_dynamicfiltersenabled3 ,
                                             string AV61Workflowconveniowwds_10_dynamicfiltersselector3 ,
                                             short AV62Workflowconveniowwds_11_dynamicfiltersoperator3 ,
                                             string AV63Workflowconveniowwds_12_workflowconveniodesc3 ,
                                             string AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel ,
                                             string AV64Workflowconveniowwds_13_tfworkflowconveniodesc ,
                                             short AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel ,
                                             DateTime AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat ,
                                             DateTime AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ,
                                             short AV69Workflowconveniowwds_18_tfworkflowconveniosla ,
                                             short AV70Workflowconveniowwds_19_tfworkflowconveniosla_to ,
                                             string A736WorkflowConvenioDesc ,
                                             bool A737WorkflowConvenioStatus ,
                                             short A753WorkflowConvenioSLA ,
                                             DateTime A743WorkflowConvenioCreatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[19];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " WorkflowConvenioSLA, WorkflowConvenioCreatedAt, WorkflowConvenioStatus, WorkflowConvenioDesc, WorkflowConvenioId";
         sFromString = " FROM WorkflowConvenio";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Workflowconveniowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WorkflowConvenioDesc like '%' || :lV52Workflowconveniowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV52Workflowconveniowwds_1_filterfulltext) and WorkflowConvenioStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV52Workflowconveniowwds_1_filterfulltext) and WorkflowConvenioStatus = FALSE) or ( SUBSTR(TO_CHAR(WorkflowConvenioSLA,'9999'), 2) like '%' || :lV52Workflowconveniowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Workflowconveniowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV54Workflowconveniowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workflowconveniowwds_4_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV55Workflowconveniowwds_4_workflowconveniodesc1)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Workflowconveniowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV54Workflowconveniowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workflowconveniowwds_4_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV55Workflowconveniowwds_4_workflowconveniodesc1)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV56Workflowconveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Workflowconveniowwds_6_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV58Workflowconveniowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Workflowconveniowwds_8_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV59Workflowconveniowwds_8_workflowconveniodesc2)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV56Workflowconveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Workflowconveniowwds_6_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV58Workflowconveniowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Workflowconveniowwds_8_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV59Workflowconveniowwds_8_workflowconveniodesc2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV60Workflowconveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Workflowconveniowwds_10_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV62Workflowconveniowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Workflowconveniowwds_12_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV63Workflowconveniowwds_12_workflowconveniodesc3)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV60Workflowconveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Workflowconveniowwds_10_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV62Workflowconveniowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Workflowconveniowwds_12_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV63Workflowconveniowwds_12_workflowconveniodesc3)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workflowconveniowwds_13_tfworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV64Workflowconveniowwds_13_tfworkflowconveniodesc)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc = ( :AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from WorkflowConvenioDesc))=0))");
         }
         if ( AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioStatus = TRUE)");
         }
         if ( AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioCreatedAt >= :AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioCreatedAt <= :AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (0==AV69Workflowconveniowwds_18_tfworkflowconveniosla) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioSLA >= :AV69Workflowconveniowwds_18_tfworkflowconveniosla)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (0==AV70Workflowconveniowwds_19_tfworkflowconveniosla_to) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioSLA <= :AV70Workflowconveniowwds_19_tfworkflowconveniosla_to)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY WorkflowConvenioDesc, WorkflowConvenioId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY WorkflowConvenioDesc DESC, WorkflowConvenioId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY WorkflowConvenioStatus, WorkflowConvenioId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY WorkflowConvenioStatus DESC, WorkflowConvenioId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY WorkflowConvenioCreatedAt, WorkflowConvenioId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY WorkflowConvenioCreatedAt DESC, WorkflowConvenioId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY WorkflowConvenioSLA, WorkflowConvenioId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY WorkflowConvenioSLA DESC, WorkflowConvenioId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY WorkflowConvenioId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H007Z3( IGxContext context ,
                                             string AV52Workflowconveniowwds_1_filterfulltext ,
                                             string AV53Workflowconveniowwds_2_dynamicfiltersselector1 ,
                                             short AV54Workflowconveniowwds_3_dynamicfiltersoperator1 ,
                                             string AV55Workflowconveniowwds_4_workflowconveniodesc1 ,
                                             bool AV56Workflowconveniowwds_5_dynamicfiltersenabled2 ,
                                             string AV57Workflowconveniowwds_6_dynamicfiltersselector2 ,
                                             short AV58Workflowconveniowwds_7_dynamicfiltersoperator2 ,
                                             string AV59Workflowconveniowwds_8_workflowconveniodesc2 ,
                                             bool AV60Workflowconveniowwds_9_dynamicfiltersenabled3 ,
                                             string AV61Workflowconveniowwds_10_dynamicfiltersselector3 ,
                                             short AV62Workflowconveniowwds_11_dynamicfiltersoperator3 ,
                                             string AV63Workflowconveniowwds_12_workflowconveniodesc3 ,
                                             string AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel ,
                                             string AV64Workflowconveniowwds_13_tfworkflowconveniodesc ,
                                             short AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel ,
                                             DateTime AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat ,
                                             DateTime AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to ,
                                             short AV69Workflowconveniowwds_18_tfworkflowconveniosla ,
                                             short AV70Workflowconveniowwds_19_tfworkflowconveniosla_to ,
                                             string A736WorkflowConvenioDesc ,
                                             bool A737WorkflowConvenioStatus ,
                                             short A753WorkflowConvenioSLA ,
                                             DateTime A743WorkflowConvenioCreatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[16];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM WorkflowConvenio";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Workflowconveniowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WorkflowConvenioDesc like '%' || :lV52Workflowconveniowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV52Workflowconveniowwds_1_filterfulltext) and WorkflowConvenioStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV52Workflowconveniowwds_1_filterfulltext) and WorkflowConvenioStatus = FALSE) or ( SUBSTR(TO_CHAR(WorkflowConvenioSLA,'9999'), 2) like '%' || :lV52Workflowconveniowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Workflowconveniowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV54Workflowconveniowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workflowconveniowwds_4_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV55Workflowconveniowwds_4_workflowconveniodesc1)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Workflowconveniowwds_2_dynamicfiltersselector1, "WORKFLOWCONVENIODESC") == 0 ) && ( AV54Workflowconveniowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workflowconveniowwds_4_workflowconveniodesc1)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV55Workflowconveniowwds_4_workflowconveniodesc1)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV56Workflowconveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Workflowconveniowwds_6_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV58Workflowconveniowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Workflowconveniowwds_8_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV59Workflowconveniowwds_8_workflowconveniodesc2)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV56Workflowconveniowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Workflowconveniowwds_6_dynamicfiltersselector2, "WORKFLOWCONVENIODESC") == 0 ) && ( AV58Workflowconveniowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Workflowconveniowwds_8_workflowconveniodesc2)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV59Workflowconveniowwds_8_workflowconveniodesc2)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV60Workflowconveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Workflowconveniowwds_10_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV62Workflowconveniowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Workflowconveniowwds_12_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV63Workflowconveniowwds_12_workflowconveniodesc3)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV60Workflowconveniowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Workflowconveniowwds_10_dynamicfiltersselector3, "WORKFLOWCONVENIODESC") == 0 ) && ( AV62Workflowconveniowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Workflowconveniowwds_12_workflowconveniodesc3)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV63Workflowconveniowwds_12_workflowconveniodesc3)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workflowconveniowwds_13_tfworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like :lV64Workflowconveniowwds_13_tfworkflowconveniodesc)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc = ( :AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from WorkflowConvenioDesc))=0))");
         }
         if ( AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioStatus = TRUE)");
         }
         if ( AV66Workflowconveniowwds_15_tfworkflowconveniostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(WorkflowConvenioStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioCreatedAt >= :AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioCreatedAt <= :AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! (0==AV69Workflowconveniowwds_18_tfworkflowconveniosla) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioSLA >= :AV69Workflowconveniowwds_18_tfworkflowconveniosla)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! (0==AV70Workflowconveniowwds_19_tfworkflowconveniosla_to) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioSLA <= :AV70Workflowconveniowwds_19_tfworkflowconveniosla_to)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
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
                     return conditional_H007Z2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (bool)dynConstraints[20] , (short)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
               case 1 :
                     return conditional_H007Z3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (bool)dynConstraints[20] , (short)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmH007Z2;
          prmH007Z2 = new Object[] {
          new ParDef("lV52Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workflowconveniowwds_4_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV55Workflowconveniowwds_4_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV59Workflowconveniowwds_8_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV59Workflowconveniowwds_8_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV63Workflowconveniowwds_12_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV63Workflowconveniowwds_12_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV64Workflowconveniowwds_13_tfworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV69Workflowconveniowwds_18_tfworkflowconveniosla",GXType.Int16,4,0) ,
          new ParDef("AV70Workflowconveniowwds_19_tfworkflowconveniosla_to",GXType.Int16,4,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH007Z3;
          prmH007Z3 = new Object[] {
          new ParDef("lV52Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Workflowconveniowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workflowconveniowwds_4_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV55Workflowconveniowwds_4_workflowconveniodesc1",GXType.VarChar,60,0) ,
          new ParDef("lV59Workflowconveniowwds_8_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV59Workflowconveniowwds_8_workflowconveniodesc2",GXType.VarChar,60,0) ,
          new ParDef("lV63Workflowconveniowwds_12_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV63Workflowconveniowwds_12_workflowconveniodesc3",GXType.VarChar,60,0) ,
          new ParDef("lV64Workflowconveniowwds_13_tfworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV65Workflowconveniowwds_14_tfworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV67Workflowconveniowwds_16_tfworkflowconveniocreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV68Workflowconveniowwds_17_tfworkflowconveniocreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV69Workflowconveniowwds_18_tfworkflowconveniosla",GXType.Int16,4,0) ,
          new ParDef("AV70Workflowconveniowwds_19_tfworkflowconveniosla_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007Z2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007Z3,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
